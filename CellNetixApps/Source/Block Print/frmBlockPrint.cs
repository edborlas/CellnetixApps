using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Database;
using CellNetixApps.Source.Embed.Forms;
using CellNetixApps.Source.Forms;
using Microsoft.Win32;

namespace CellNetixApps.Source.Block_Print
{
    public partial class frmBlockPrint : DevExpress.XtraEditors.XtraForm
    {
        private List<cBlock> lBlocks = new List<cBlock>();
        private int selectedCount = 0;

        public frmBlockPrint()
        {
            InitializeComponent();
            tiPrinterSelectAll.Tag = false;
            tiPrintSelectedButton.Tag = false;
            tiPrinterLogout.Tag = true;
            this.ActiveControl = tbScan;
            GetDefaultPrinter();
            ShowPrinterDesc();
            tiPrinterLogout.Text = "<size=20>Log Off</size><br><size=10>" + Program.User.Name + "</size>";
            //Added so if the colors change it won't have to be inputted manually.
            foreach(TileItem ti in tgPrinter.Items)
                ti.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
            tcBlocks.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
        }

        private void GetDefaultPrinter()
        {
            ModifyRegistry mr = new ModifyRegistry();
            string printDesc = mr.Read("BlockPrintPrinter");
            if (printDesc == null)
            {
                cMethods.printerSelectionScreen(Enums.Mode.BlockPrint, true);//need to change this when done testing to what it would actually be.
                this.tiPrinterSettings.Text = "<size=20>Printer</size><br><size=8>" + Program.User.Printer.Description + "</size>";
                mr.Write("BlockPrintPrinter", Program.User.Printer.Description);
            }
            else
                Program.User.Printer = cMethods.GetSinglePrinter((int)Enums.PrinterTypes.BlockPrint, printDesc);
        }

        private void ShowPrinterDesc()
        {
            if (Program.User.Printer != null)
                this.tiPrinterSettings.Text = "<size=20>Printer</size><br><size=8>" + Program.User.Printer.Description + "</size>";
            else
                tiPrinterSettings_ItemClick(null, null);//make the user select their printer
        }
        private void tiPrinterSettings_ItemClick(object sender, TileItemEventArgs e)
        {
            ModifyRegistry mr = new ModifyRegistry();
            cMethods.printerSelectionScreen(Enums.Mode.BlockPrint);//need to change this when done testing to what it would actually be.
            this.tiPrinterSettings.Text = "<size=20>Printer</size><br><size=8>" + Program.User.Printer.Description + "</size>";
            mr.Write("BlockPrintPrinter", Program.User.Printer.Description);
        }
        private void Setup()
        {
            PrinterSelectButtonDisable();
            tiPrinterPrintAll.AppearanceItem.Normal.BackColor = Color.Gray;
        }
        private void tbScan_Leave(object sender, EventArgs e)
        {
            string sText = this.tbScan.Text;
            if (sText.Length > 1)
            {
                Program.LastAction = DateTime.Now;
                Setup();
                cAcc acc = new cAcc(sText);
                Program.Acc = acc;
                if (Program.Acc.AccID == 0)
                {
                    frmSimplePopup frm = new frmSimplePopup("Block Doesn't Exist in PowerPath", true);
                    frm.ShowDialog();
                    this.tbScan.Text = string.Empty;
                    this.ActiveControl = this.tbScan;
                    return;
                }
                bwLoad.RunWorkerAsync();
            }
            this.tbScan.Text = string.Empty;
            this.ActiveControl = this.tbScan;
        }

        private void PopulateTiles()
        {
            tgBlocks.Items.Clear();
            foreach(cBlock block in lBlocks)
            {
                TileItem ti = new TileItem();
                ti.ItemClick += ti_ItemClick;
                ti.Tag = block;
                ti.Text = block.BlockName;
                tgBlocks.Items.Add(ti);
            }
        }
        void ti_ItemClick(object sender, TileItemEventArgs e)
        {
            Program.LastAction = DateTime.Now;
            TileItem clicked = e.Item;
            if (!clicked.Checked)
                SelectTile(clicked);
            else
                UnselectTile(clicked);
        }

        private void SelectTile(TileItem clicked)
        {
            clicked.Checked = true;
            clicked.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
            selectedCount++;
            if (selectedCount == 1)
                PrinterSelectButtonEnable();
        }
        private void UnselectTile(TileItem clicked)
        {
            clicked.Checked = false;
            clicked.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
            selectedCount--;
            if (selectedCount <= 0)
                PrinterSelectButtonDisable();
        }

        private void PrinterSelectButtonEnable()
        {
            tiPrintSelectedButton.Tag = true;
            tiPrintSelectedButton.AppearanceItem.Normal.BackColor = Program.ColorLink;
        }
        private void PrinterSelectButtonDisable()
        {
            tiPrintSelectedButton.Tag = false;
            tiPrintSelectedButton.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
            selectedCount = 0; //Just in case the user selects all, de-selects all manually and then clicks de-select all button.
            tiPrinterSelectAll.Tag = false;
            tiPrinterSelectAll.Text = "Select All";
        }

        private void tiPrinterSelectAll_ItemClick(object sender, TileItemEventArgs e)
        {
            if (tgBlocks.Items.Count > 0)
            {
                if (!(bool)tiPrinterSelectAll.Tag)
                    selectAlltiles();
                else
                    deselectAllTiles();
            }
        }

        private void selectAlltiles()
        {
            tiPrinterSelectAll.Tag = true;
            tiPrinterSelectAll.Text = "De-Select    All";
            foreach (TileItem ti in tgBlocks.Items)
            {
                SelectTile(ti);
            }
            selectedCount = tgBlocks.Items.Count;//Just in case the user selects all, de-selects all manually and then clicks de-select all button.
        }

        private void deselectAllTiles()
        {
            foreach (TileItem ti in tgBlocks.Items)
            {
                UnselectTile(ti);
            }
        }
        private void bwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            cMethods.GetCaseBlocks();
            if (Program.Blocks.Count > 0)
            {
                lBlocks.Clear();
                lBlocks = Program.Blocks;
                PopulateTiles();
                tiPrinterPrintAll.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
            }
        }

        private void bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        { this.lCaseNumber.Text = Program.Acc.AccessionNo; }

        private void tiPrintSelectedButton_ItemClick(object sender, TileItemEventArgs e)
        {
            if ((bool)tiPrintSelectedButton.Tag)
            {
                Thread printThread = new Thread(PrintThreadFunction);
                printThread.Start();
            }
        }
        private void PrintThreadFunction()
        {
            this.tiPrinterLogout.Tag = false;//don't allow the user to break the app by logging out.
            this.tiPrinterLogout.AppearanceItem.Normal.BackColor = Color.Gray;
            bool foundAllTilesSelected = false;
            int index = 0;
            Random randomizer = new Random();
            ToolsDataContext db = new ToolsDataContext();
            string blockIDs = "";

            //Let the user know they have to wait.
            tiPrintSelectedButton.AppearanceItem.Normal.BackColor = Color.Gray;
            tiPrintSelectedButton.Text = "Printing Selection...";
            tiPrintSelectedButton.Elements[1].Text = "This may take a little while. Please be patient.";
            tiPrinterLogout.Text = "Waiting for Printing";

            string printerName = Program.User.Printer.Description;
            int counterForTextFileToPrint = randomizer.Next(1001);//make it very unlikely that the two people will get the same file name.
            while (!foundAllTilesSelected && index < tgBlocks.Items.Count)
            {
                if (tgBlocks.Items[index].Checked)
                {
                    tiPrintSelectedButton.Elements[2].Text = "Now Printing " + tgBlocks.Items[index].Text;
                    cBlock currentBlock = (cBlock)tgBlocks.Items[index].Tag;
                    string blockID = currentBlock.BlockID.ToString();
                    blockIDs += blockID + ",";
                    try
                    {
                        string printer = Program.User.Printer.Description;
                        int? batchID = 0;
                        db.stprc_clntx_blocks_batch_id(blockID, ref batchID);
                        CrystalReport rpt = new CrystalReport("BlockPrint", "1", DBNull.Value, DBNull.Value, batchID, printerName);
                        rpt.PrintToTextFile(printer, counterForTextFileToPrint);
                        counterForTextFileToPrint++;
                        System.Threading.Thread.Sleep(500);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    UnselectTile(tgBlocks.Items[index]);
                }
                if (selectedCount <= 0)
                    foundAllTilesSelected = true;
                index++;
            }
            //Reset tiles back
            tiPrintSelectedButton.Text = "Print Selected";
            tiPrintSelectedButton.Elements[2].Text = "";
            tiPrintSelectedButton.Elements[1].Text = "";
            this.tiPrinterLogout.Tag = true;
            this.tiPrinterLogout.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
            tiPrinterLogout.Text = "Logout";
        }

        private void tiPrinterLogout_ItemClick(object sender, TileItemEventArgs e)
        {
            if((bool)tiPrinterLogout.Tag)
                Program.frmLogin.Initalize(Enums.Mode.Logout);
        }

        private void tiPrinterTicket_ItemClick(object sender, TileItemEventArgs e)
        {
            frmTicket frm = new frmTicket(4);//4 is the gross ticket stage id!
            frm.ShowDialog();
        }

        private void tiPrinterPrintAll_ItemClick(object sender, TileItemEventArgs e)
        {
            //Clicks select all and then print for the user. IN A SINGLE BUTTON PRESS! HOW CONVIENENT!
            tiPrinterSelectAll_ItemClick(sender, e);
            tiPrintSelectedButton_ItemClick(sender, e);
        }
    }
}