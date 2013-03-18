using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Forms;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Database;
using System.Threading;
using IDAutomation.Windows.Forms.DataMatrixBarcode;
using CellNetixApps.Source.Embed_and_Cut;
using System.Runtime.InteropServices;
using System.Diagnostics;
using CellNetixApps.Source.Path.Forms;
using CellNetixApps.Source.Lab;
using CellNetixApps.Source.Login_and_General;
using DevExpress.LookAndFeel;
using CellNetixApps.Source.Acc;


namespace CellNetixApps.Source.Embed.Forms
{
    public partial class frmCut : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        List<TileItem> lAllTiles = new List<TileItem>();
        List<cSlide> lSlides = new List<cSlide>();
        Enums.Mode mode;
        ToolsDataContext tdb = new ToolsDataContext();
        Thread PrintThread;
        //**************************
        /// <summary>
        /// An array of all of the counters used in the ticket error screen. Use the constants instead of hardcoding the indicies.
        /// <para>********************************************************************</para>
        /// <para>********************* Index Naming Schema **********************</para>
        /// <para>********************************************************************</para>
        /// <para>"Current" counters represent what is currently being shown to the user.</para>
        /// <para>"Previous" counters represent what was shown to the user last page</para>
        /// <para>"Next" counters represent what will be shown to the user next page.</para>
        /// <para>"Start" counters represent on which object the page starts on (not zero-based)</para>
        /// <para>"End" counters represent on which object the page ends on (not zero-based)</para>
        /// </summary>
        int[] counters = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
        //Indices for Counters
        const int MAIN_COUNT = 0;
        const int CURRENT_START_COUNT = 1;
        const int CURRENT_END_COUNT = 2;
        const int PREVIOUS_START_COUNT = 3;
        const int PREVIOUS_END_COUNT = 4;
        const int NEXT_START_COUNT = 5;
        const int NEXT_END_COUNT = 6;
        //NOTE: it is assumed in the getCount function that CURRENT_START_COUNT will precede all the other counts besides MAIN_COUNT.
        const int PAGE_SIZE = 21;
        #endregion

        #region Set Up
        public frmCut()
        {
            InitializeComponent();
            Program.frmCut = this;
            mode = Enums.Mode.Cut;
            inialize();
        }

        private void ColorTiles()
        {
            tiModeBack.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
            tiModeNext.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
            tiPrinterViewAll.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
            tiPrinterPrintAll.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
            tiPrinterAutoPrint.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
            tiModeMode.AppearanceItem.Normal.BackColor = Program.ColorLink;
            tiPrinterSettings.AppearanceItem.Normal.BackColor = Program.ColorLink;
            cMethods.ColorTiles(tcOther, Program.ColorLink);
            tiAddSlide.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
            tiCaseOptionNote.AppearanceItem.Normal.BackColor = Program.ColorLink;
        }

        void inialize()
        {
            //click listeners
            this.tbScan.Leave += tbScan_Leave;
            this.tiModeBack.ItemClick += tiSideBarBack_ItemClick;
            this.tiModeNext.ItemClick += tiSideBarNext_ItemClick;
            this.tiOtherTicket.ItemClick += tiOtherTicket_ItemClick;
            this.tiOtherLogOff.ItemClick += tiOtherLogOff_ItemClick;
            this.tiPrinterPrintAll.ItemClick += tiPrinterPrintAll_ItemClick;
            this.tiPrinterAutoPrint.ItemClick += tiPrinterAutoPrint_ItemClick;
            this.tiPrinterSettings.ItemClick += tiPrinterSettings_ItemClick;
            //Printer set up
            ShowPrinterDescr();
            setAutoPrint(true);
            //Tile item set up
            foreach (TileItem t in this.tgLeftL.Items)
            {
                t.ItemClick += t_ItemClick;
                lAllTiles.Add(t);
            }
            //UI stuff
            this.ActiveControl = this.tbScan;
            hide();
            this.tbScan.Text = string.Empty;
            this.tiOtherLogOff.Text = "<size=14.25>Log Off</size><br><size=7>" + Program.User.Name + "</size>";
            Program.LastAction = DateTime.Now;
            tiModeMode.Text = "Current Mode\nPrint";
            tiModeMode.Tag = Enums.Mode.Print;
            ColorTiles();
        }

        public void ShowPrinterDescr()
        {
            this.tiPrinterSettings.AppearanceItem.Normal.BackColor = Program.ColorLink;
            if (Program.User.Printer != null)
            {
                this.tiPrinterSettings.Text = "Printer<br><size=7>" + Program.User.Printer.Description + "</size>";
            }
            else
            {
                cMethods.printerSelectionScreen(mode, true);
                this.tiPrinterSettings.Text = "Printer<br><size=7>" + Program.User.Printer.Description + "</size>";
            }
        }

        void hide()
        {
            this.tc.Visible = false;
            this.lAccesionNo.Visible = false;
            //this.lGross.Visible = false;
            //this.scrollGross.Visible = false;
            //this.lNotesNote.Visible = false;
            //this.lNotesBy.Visible = false;
            //this.lNotesTopic.Visible = false;
            //this.lCount.Visible = false;
            //  this.pbRush.Visible = false;
        }

        void show()
        {
            this.lAccesionNo.Visible = true;
            //this.lGross.Visible = true;
            //this.scrollGross.Visible = true;
            //this.lNotesNote.Visible = true;
            //this.lNotesBy.Visible = true;
            //this.lNotesTopic.Visible = true;
            //this.lNotesNote.Text = "Note";//text changes if no notes are present.
            //this.lCount.Visible = true;
            this.tc.Visible = true;
            this.tiPrinterPrintAll.AppearanceItem.Normal.BackColor = Program.ColorLink;
            //this.tiPrinterPrintAll.AppearanceItem.Normal.BackColor2 = Program.ColorGreen;
            this.tiPrinterViewAll.AppearanceItem.Normal.BackColor = Program.ColorLink;
            if (Program.Acc.accessionNumScanned)
                this.tiAddSlide.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
            else
                this.tiAddSlide.AppearanceItem.Normal.BackColor = Program.ColorLink;
        }
        //Assumes that program.acc.accID is valid... make sure it is!
        void setGross()
        {
            const int FONTSIZE = 11;
            List<string> grossDescriptions = cMethods.GetGrossNotes(Program.Acc.AccID);
            this.scrollGross.Controls.Clear();
            if (grossDescriptions.Count <= 0)
                grossDescriptions.Add("No Gross Description Found");
            List<double> percent = new List<double>();
            percent.Add(1.0);//take up 100% of the scroll (one column)
            TouchScroller ts = new TouchScroller(scrollGross, new Font("Tahoma", FONTSIZE), 1, percent, grossDescriptions);
        }
        void SetNotes()
        {
            const int FONTSIZE = 11;
            cMethods.GetCaseNotes();
            this.scrollNotes.Controls.Clear();     
            List<string> test = (from l in Program.CaseNotes select l.Topic.ToUpper() + "\n" + l.By + "\n" + l.LastEdit + "\n" + l.Note + "\n").ToList<string>();
            if (test.Count <= 0)
                test.Add("No Case Notes Found");
            test.Reverse();//reverse chronological order
            List<double> percent = new List<double>();
            percent.Add(1.0);//take up 100% of the scroll (one column)
            TouchScroller ts = new TouchScroller(scrollNotes, new Font("Tahoma", FONTSIZE), 1, percent, test);
        }
        #endregion

        #region TileItem stuff


        private void loadNotesAndGross()
        {
            Invoke(new MethodInvoker(
                delegate
                {
                    //this.gNotes.DataSource = Program.CaseNotes;
                    SetNotes();
                    setGross();
                }
            ));
        }

        void loadSlides()
        {
            try
            {
                SP.PowerPath.GetCtraxDetailsList();
                foreach (TileItem t in this.tgLeftL.Items)
                {
                    cSlide sl = (cSlide)t.Tag;
                    // SP.PowerPath.GetSlideCtraxDetails(sl);
                    Invoke(new MethodInvoker(
                    delegate
                    {
                        cMethods.FormatTileCut(t, sl);
                    }
                    ));
                }

                //foreach (cSlide sl in lSlides)
                //{
                //    //SP.PowerPath.GetSlideCtraxDetails(sl);

                //}
            }
            catch (InvalidOperationException)
            {
            }

            if ((bool)this.tiPrinterAutoPrint.Tag)
            {
                printAll();
            }
        }

        public void CompleteSlide(cSlide sl, bool printInBackground = true)
        {
            // cSlide sl = (cSlide)ti.Tag;
            bool err = false;
            DateTime tenSecondsAgo = DateTime.Now.AddSeconds(-15);
            if (sl.CutTime > tenSecondsAgo)
            {

                frmSimplePopup frms = new frmSimplePopup(sl.Label + " printed in last 15 seconds", true, "Can't Print Yet");
                frms.ShowDialog();
                //    this.lError.Text = sl.Label + " printed in last 15 seconds";
            }
            else
            {


                try
                {
                    CellappsDataContext db = new CellappsDataContext();
                    db.SP_InsertItem_Log(sl.ItemGroupID, (int)Enums.ItemStatus.CutComplete, Program.User.Machine.LocationID, Program.User.UserID, Program.User.Machine.MachineID);
                    sl.CutComplete = true;
                    sl.CutTime = DateTime.Now;
                    sl.CutBy = Program.User.Name;
                    sl.CutByID = Program.User.UserID;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    err = true;
                }
                finally
                {
                    if (!err)
                    {
                        foreach (TileItem til in this.tgLeftL.Items)
                        {
                            cSlide tslide = (cSlide)til.Tag;
                            if (tslide == sl)
                                cMethods.FormatTileCut(til, sl);
                        }

                        //cMethods.FormatTileCut(ti, sl);
                        string undo = "<size=20>Undo</size><br><size=12>" + sl.Label + "</size>";
                        if (printInBackground)
                        {
                            PrintThread = new Thread(print);
                            PrintThread.Start(sl);
                        }
                        else
                        {
                            print(sl);
                        }
                    }
                }

            }
        }

        void displayTileItems()
        {
            tgLeftL.Items.Clear();
            cMethods.AddTiles(lAllTiles, tgLeftL);
            //format tiles
            foreach (TileItem t in this.tgLeftL.Items)
            {
                counters[MAIN_COUNT] = cMethods.FormatTilesCut(t, lSlides, counters[MAIN_COUNT]);
            }
            cMethods.SetCountersForMultiPageForms(lSlides.Count, ref counters, PAGE_SIZE);
            cMethods.RemoveEmptyTiles(tgLeftL, counters[CURRENT_END_COUNT], PAGE_SIZE);
            string StartC = "";
            string EndC = "";

            //set the texts shown to the user
            this.lCount.Text = lSlides.Count.ToString() + " Slides"; // Viewing " + lSlides[Math.Abs(counters[CURRENT_START_COUNT] - 1)].Label + " To " + lSlides[Math.Abs(counters[CURRENT_END_COUNT] - 1)].Label;
            StartC = "Back " + lSlides[Math.Abs(counters[PREVIOUS_START_COUNT] - 1)].Label + " to " + lSlides[Math.Abs(counters[PREVIOUS_END_COUNT] - 1)].Label;
            EndC = "Next " + lSlides[Math.Abs(counters[NEXT_START_COUNT] - 1)].Label + " to " + lSlides[Math.Abs(counters[NEXT_END_COUNT] - 1)].Label;


            string back = "Back";
            string next = "Next";
            this.tiModeBack.Tag = true;
            this.tiModeNext.Tag = true;
            this.tiModeBack.AppearanceItem.Normal.BackColor = Program.ColorLink;
            //this.tiModeBack.AppearanceItem.Normal.BackColor2 = Program.ColorGreen;
            this.tiModeNext.AppearanceItem.Normal.BackColor = Program.ColorLink;
            //this.tiModeNext.AppearanceItem.Normal.BackColor2 = Program.ColorGreen;
            if (counters[PREVIOUS_START_COUNT] < 1 || counters[PREVIOUS_START_COUNT] == counters[PREVIOUS_END_COUNT])
            {//if there is no previous page, gray out the button and disable it
                StartC = back;
                this.tiModeBack.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
                //this.tiModeBack.AppearanceItem.Normal.BackColor2 = Program.ColorGray;
                this.tiModeBack.Tag = false;
            }
            if (counters[CURRENT_END_COUNT] == lSlides.Count)
            {//if there is no next page, gray out the button and disable it
                EndC = next;
                this.tiModeNext.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
                //this.tiModeNext.AppearanceItem.Normal.BackColor2 = Program.ColorGray;
                this.tiModeNext.Tag = false;
            }
            //this.tiSideBarNext.Text = EndC;
            tiModeNext.Elements.Clear();
            TileItemElement element1 = new TileItemElement();
            element1.Text = EndC;
            element1.TextAlignment = TileItemContentAlignment.TopLeft;
            tiModeNext.Elements.Add(element1);


            // this.tiSideBarBack.Text = StartC;
            tiModeBack.Elements.Clear();
            TileItemElement element2 = new TileItemElement();
            element2.Text = StartC;
            element2.TextAlignment = TileItemContentAlignment.TopLeft;
            tiModeBack.Elements.Add(element2);
        }
        #endregion

        #region Event Handlers

        void tiOtherTicket_ItemClick(object sender, TileItemEventArgs e)
        { cMethods.GoToTicketFromAForm(Enums.Mode.Cut); }

        void tiSideBarNext_ItemClick(object sender, TileItemEventArgs e)
        {
            if (e.Item.Tag != null && (bool)e.Item.Tag)
            {
                displayTileItems();
            }
        }

        void tiSideBarBack_ItemClick(object sender, TileItemEventArgs e)
        {
            if (e.Item.Tag != null && (bool)e.Item.Tag)
            {
                int tilesOnCurrentPage = counters[MAIN_COUNT] % PAGE_SIZE;
                if (tilesOnCurrentPage == 0)//if multiple of 20
                    tilesOnCurrentPage = PAGE_SIZE;
                //minus 21-40 from main count, this is because count should start at the first index of the page and end at the last index of the page (in showticket functions)
                counters[MAIN_COUNT] -= (PAGE_SIZE + tilesOnCurrentPage);
                displayTileItems();
            }

        }

        void t_ItemClick(object sender, TileItemEventArgs e)
        {
            Program.LastAction = DateTime.Now;
            object o = e.Item.Tag;
            if (o is cSlide)
            {
                cSlide sl = (cSlide)o;
                switch ((Enums.Mode)tiModeMode.Tag)
                {
                    case Enums.Mode.Print:
                        if (!sl.CutComplete)
                        {
                           
                            CompleteSlide(sl);
                        }
                        else
                        {
                            frmDialog frm = new frmDialog(e.Item);
                            frm.ShowDialog();
                        }
                        break;
                    case Enums.Mode.Delete:
                        if (this.tiModeMode.Text.Contains("Scan Badge"))
                        {
                            frmSimplePopup frm = new frmSimplePopup("Scan Badge To Delete Slides", true);
                            frm.ShowDialog();
                        }
                        else
                        {
                            if (e.Item.Checked)
                            {
                                PowerPathDataContext pdb = new PowerPathDataContext();
                                //DialogResult dr = MessageBox.Show("Confirm Delete " + sl.Label, "Delete?", MessageBoxButtons.YesNo);
                                //if (dr == System.Windows.Forms.DialogResult.Yes)
                                //{
                                pdb.stprc_clntx_path_add_slides_logic(sl.AccID, null, null, null, null, sl.SlideID, null, 'D');
                                lSlides.Remove(sl);
                                this.tgLeftL.Items.Remove(e.Item);
                            }
                            e.Item.Checked = true;
                           // }
                        }
                        break;
                    case Enums.Mode.Edit:
                        frmKeypad frmE = new frmKeypad(e.Item);
                        frmE.ShowDialog();
                        break;
                    case Enums.Mode.IHC:
                        try
                        {
                            CellappsDataContext db = new CellappsDataContext();
                            db.SP_InsertItem_LogWithNote(sl.ItemGroupID, (int)Enums.ItemStatus.CutComplete, Program.User.Machine.LocationID, Program.User.UserID, Program.User.Machine.MachineID, "IHC Complete", DateTime.Now);
                            //db.SP_InsertItem_Log(sl.ItemGroupID, (int)Enums.ItemStatus.CutComplete, Program.User.Machine.LocationID, Program.User.UserID, Program.User.Machine.MachineID);
                            sl.CutComplete = true;
                            sl.CutTime = DateTime.Now;
                            sl.CutBy = Program.User.Name;
                            sl.CutByID = Program.User.UserID;
                            cMethods.FormatTileCut(e.Item, sl);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        break;
                }

            }
        }

        private void tiOtherLogOff_ItemClick(object sender, TileItemEventArgs e)
        { Program.frmLogin.Initalize(Enums.Mode.Logout); }

        void tiPrinterSettings_ItemClick(object sender, TileItemEventArgs e)
        {
            cMethods.printerSelectionScreen(mode);
            this.tiPrinterSettings.Text = "<size=20>Printer</size><br><size=8>" + Program.User.Printer.Description + "</size>";
        }

        void tiPrinterAutoPrint_ItemClick(object sender, TileItemEventArgs e)
        {
            setAutoPrint((bool)e.Item.Tag);
        }

        void tbScan_Leave(object sender, EventArgs e)
        {
            string sText = this.tbScan.Text;
            this.tbScan.Text = string.Empty;
            if (sText.Length > 1)
            {
                tiModeMode.Text = "Current Mode\nPrint";
                this.tiModeMode.BackgroundImage = global::CellNetixApps.Properties.Resources.Printer;
                tiModeMode.Tag = Enums.Mode.Print;
                counters[MAIN_COUNT] = 0;
                cAcc acc = new cAcc(sText);
                Program.Acc = acc;
                cMethods.GetCaseSlides();
                if (Program.Acc.AccID == 0)
                {

                    frmSimplePopup frm = new frmSimplePopup("Block Doesn't Exist in PowerPath", true);
                    frm.ShowDialog();

                    this.ActiveControl = this.tbScan;
                    return;
                }
                this.lAccesionNo.Text = Program.Acc.AccessionNo;
                if (Program.Slides.Count > 0)
                {
                    //    this.pbRush.Visible = false;
                    if (Program.Acc.Priority_Name == Enums.Priority.Rush)
                    {
                        this.lAccesionNo.ForeColor = Color.Red;
                        this.lAccesionNo.Text += ": RUSH CASE";
                        //  this.pbRush.Visible = true;
                        //frmSimplePopup frm = new frmSimplePopup(Program.Acc.AccessionNo + " RUSH CASE!");
                        //frm.ShowDialog();
                    }
                    else
                    {
                        this.lAccesionNo.ForeColor = Color.White;
                    }

                    lSlides.Clear();


                    if (Program.Acc.accessionNumScanned)
                    {
                        lSlides = Program.Slides;
                    }
                    else
                    {
                        foreach (cSlide sl in Program.Slides)
                        {
                            if (sl.BlockID == Program.Acc.currentBlockID)
                            {
                                lSlides.Add(sl);
                            }
                        }
                        if (lSlides.Count == 0) //there are no slides for the block
                        {
                            frmSimplePopup frm = new frmSimplePopup("No Slides for the Block", true);
                            frm.ShowDialog();
                            this.tbScan.Text = string.Empty;
                            this.ActiveControl = this.tbScan;
                            return;
                        }
                    }
                    show();
                    displayTileItems();
                    Thread tLoad = new Thread(loadSlides);
                    tLoad.Start();

                    Thread tNotesAndGross = new Thread(loadNotesAndGross);
                    tNotesAndGross.Start();
                }
            }
            this.tbScan.Text = string.Empty;
            //    this.ActiveControl = this.scrollNotes;
            this.ActiveControl = this.tbScan;
        }

        void tiPrinterPrintAll_ItemClick(object sender, TileItemEventArgs e)
        {
            PrintThread = new Thread(printAll);
            PrintThread.Start();
            //  printAll();
        }
        #endregion

        #region Printer
        void printAll()
        {

            Program.LastAction = DateTime.Now;

            if (Program.Slides == null) return;

            int count = lSlides.Where(x => x.CutComplete).Count();

            // 20121112 Ed Borlas - This was commented out - for reasons unknown. uncommented it to see if it resovles the problem
            if (count > 0)
            {
                frmSimplePopup popup = new frmSimplePopup(count + " Slide(s) For This Case Have Already Been Printed.\nAuto Print/Print All Not Available");
                popup.ShowDialog();
                return;
            }

            if (!Program.Acc.accessionNumScanned)
            {
                int counter = 0;
                foreach (cSlide sl in lSlides)
                {
                    Invoke(new MethodInvoker(
                    delegate
                    {
                        //this.gNotes.DataSource = Program.CaseNotes;
                        this.tbScan.Enabled = false;
                        counter += 1;
                        this.lPrinting.Text = "Printing " + counter + " of " + lSlides.Count;
                    }
                    ));
                    CompleteSlide(sl, true);
                    System.Threading.Thread.Sleep(2000);
                }
            }
            else
            {
                frmSimplePopup popup = new frmSimplePopup("Print All is Disabled When Block Not Scanned");
                popup.ShowDialog();
            }
            Invoke(new MethodInvoker(
            delegate
            {
            //this.gNotes.DataSource = Program.CaseNotes;
                this.lPrinting.Text = string.Empty;
                this.tbScan.Enabled = true;
                this.ActiveControl = this.tbScan;
                this.tbScan.Focus();
                this.ActiveControl = this.tbScan;
                this.tbScan.Focus();
            }
            ));
        }

        void setAutoPrint(bool on)
        {
            if (on)
            {
                this.tiPrinterAutoPrint.Text = "Auto Print\nOFF";
                this.tiPrinterAutoPrint.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
                //this.tiPrinterAutoPrint.AppearanceItem.Normal.BackColor2 = Program.ColorGray;
                this.tiPrinterAutoPrint.Tag = false;
            }
            else
            {
                this.tiPrinterAutoPrint.Text = "Auto Print\nON";
                this.tiPrinterAutoPrint.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
               // this.tiPrinterAutoPrint.AppearanceItem.Normal.BackColor2 = Program.ColorGreen;
                this.tiPrinterAutoPrint.Tag = true;
            }
        }

        public void print(object slide)
        {
            cSlide sl = (cSlide)slide;
            cMethods.NiceLabel.PrintSlideLabel(sl);

        }
        #endregion

        private void tiSideBarViewAll_ItemClick(object sender, TileItemEventArgs e)
        {
            if (Program.Acc != null)
            {
                frmAllSlides frm = new frmAllSlides();
                frm.ShowDialog();
            }
        }
        private void tiSideBarMode_ItemClick(object sender, TileItemEventArgs e)
        {
            tBadge.Enabled = false;
            switch ((Enums.Mode)e.Item.Tag)
            {
                case Enums.Mode.Print:
                    tiModeMode.Text = "Current Mode\nEdit Levels";
                    this.tiModeMode.BackgroundImage = global::CellNetixApps.Properties.Resources.edit;
                    e.Item.Tag = Enums.Mode.Edit;
                    break;
                case Enums.Mode.Edit:
                    tiModeMode.Text = "Current Mode\n<color=red>Delete - Scan Badge</color>";
                    this.tiModeMode.BackgroundImage = global::CellNetixApps.Properties.Resources.delete;
                    e.Item.Tag = Enums.Mode.Delete;
                    tBadge.Enabled = true;
                    break;
                case Enums.Mode.Delete:
                    tiModeMode.Text = "Current Mode\nIHC";
                    this.tiModeMode.BackgroundImage = global::CellNetixApps.Properties.Resources.chemistry;
                    e.Item.Tag = Enums.Mode.IHC;
                    break;
                case Enums.Mode.IHC:
                    tiModeMode.Text = "Current Mode\nPrint";
                    this.tiModeMode.BackgroundImage = global::CellNetixApps.Properties.Resources.Printer;
                    e.Item.Tag = Enums.Mode.Print;
                    break;
            }

        }

        private void tiAddUnstained_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!Program.Acc.accessionNumScanned)
            {
                PowerPathDataContext pdb = new PowerPathDataContext();
                pdb.stprc_clntx_path_add_slides_logic(Program.Acc.AccID, Program.Acc.currentBlockID, "UNS", null, null, null, getNextSlide(), 'A');
                counters[MAIN_COUNT] = 0;
                cMethods.GetCaseSlides();
                lSlides.Clear();
                foreach (cSlide sl in Program.Slides)
                {
                    if (sl.BlockID == Program.Acc.currentBlockID)
                    {
                        lSlides.Add(sl);
                    }
                }
                show();
                displayTileItems();
                Thread tLoad = new Thread(loadSlides);
                tLoad.Start();
            }
        }

        private void tiAddHE_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!Program.Acc.accessionNumScanned)
            {
                PowerPathDataContext pdb = new PowerPathDataContext();
                pdb.stprc_clntx_path_add_slides_logic(Program.Acc.AccID, Program.Acc.currentBlockID, "H&E", null, null, null, getNextSlide(), 'A');
                counters[MAIN_COUNT] = 0;
                cMethods.GetCaseSlides();
                lSlides.Clear();
                foreach (cSlide sl in Program.Slides)
                {
                    if (sl.BlockID == Program.Acc.currentBlockID)
                    {
                        lSlides.Add(sl);
                    }
                }
                show();
                displayTileItems();
                Thread tLoad = new Thread(loadSlides);
                tLoad.Start();
            }
        }

        int getNextSlide()
        {
            int id = 0;
            var list = from d in lSlides
                       orderby d.Slide_No
                       select d.Slide_No;

            var result = Enumerable.Range(0, 1000).Except(list);

            id = result.Min();
            int[] test = result.ToArray();
            id = test[1];

            return id;
        }

        private void tBadge_Tick(object sender, EventArgs e)
        {
            int bNumber = ProximityReader.ReadBadge();
            if (bNumber != 0)
            {
                tiModeMode.Text = "Current Mode\nDelete";
            }
        }

        private void tiWorklist_ItemClick(object sender, TileItemEventArgs e)
        {
            cMethods.printerSelectionScreen(Classes.Enums.Mode.Report, false, false);
            frmWorklist frm = new frmWorklist();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void tiAddSlide_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!Program.Acc.accessionNumScanned)
            {
                List<String> slideTypes = new List<string>();
                PowerPathDataContext pdb = new PowerPathDataContext();
                var query = from lp in pdb.lab_procedures
                            where lp.active == 'Y' && lp.preparation_catg == 'L' && !lp.code.StartsWith("Q")
                            orderby lp.code
                            select lp;

                foreach (lab_procedure ax in query)
                {
                    string pe = ax.code;
                    slideTypes.Add(pe);
                }

                frmSearchableAddSlides addSlideType = new frmSearchableAddSlides(slideTypes);
                addSlideType.ShowDialog();
                if (addSlideType.clickedIndex != frmSearchableAddSlides.NO_SELECTION_MADE)
                {
                    try
                    {
                        pdb.stprc_clntx_path_add_slides_logic(Program.Acc.AccID, Program.Acc.currentBlockID, slideTypes[addSlideType.clickedIndex], null, null, null, getNextSlide(), 'A');
                        counters[MAIN_COUNT] = 0;
                        cMethods.GetCaseSlides();
                        lSlides.Clear();
                        foreach (cSlide sl in Program.Slides)
                        {
                            if (sl.BlockID == Program.Acc.currentBlockID)
                            {
                                lSlides.Add(sl);
                            }
                        }
                        show();
                        displayTileItems();
                        Thread tLoad = new Thread(loadSlides);
                        tLoad.Start();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                }
            }
        }

        private void tiCaseOptionNote_ItemClick(object sender, TileItemEventArgs e)
        {
            frmCaseNotes caseNote = new frmCaseNotes();
            caseNote.ShowDialog();
            SetNotes();
        }
    }

}