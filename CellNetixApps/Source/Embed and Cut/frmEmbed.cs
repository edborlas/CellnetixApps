using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Forms;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Database;
using System.Threading;
using IDAutomation.Windows.Forms.DataMatrixBarcode;
using CellNetixApps.Source.Embed_and_Cut;


namespace CellNetixApps.Source.Embed.Forms
{
    public partial class frmEmbed : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        List<TileItem> lAllTiles = new List<TileItem>();
        List<TileItem> lCompletedBlocks = new List<TileItem>();
        List<cBlock> lBlocks = new List<cBlock>();
        Enums.Mode mode;
        //Scrolling stuff**********
  
        Point newScrollPos = new Point(0, 0);
        System.Windows.Forms.Timer timeScroll = new System.Windows.Forms.Timer();
    
        const int SCROLL_WAIT = 20;
        const int SCROLL_MAX = 5;
        const int SCROLL_MIN = -5;
        //**************************
        ToolsDataContext tdb = new ToolsDataContext();
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
        #region Indices for Counters
        const int MAIN_COUNT = 0;
        const int CURRENT_START_COUNT = 1;
        const int CURRENT_END_COUNT = 2;
        const int PREVIOUS_START_COUNT = 3;
        const int PREVIOUS_END_COUNT = 4;
        const int NEXT_START_COUNT = 5;
        const int NEXT_END_COUNT = 6;
        //NOTE: it is assumed in the getCount function that CURRENT_START_COUNT will precede all the other counts besides MAIN_COUNT.
        #endregion
        const int PAGE_SIZE = 18;
        #endregion

        #region Set Up
        public frmEmbed(Enums.Mode m)
        {
            InitializeComponent();
            Program.frmEmbed = this;
            mode = m;
            inialize();
        }

        void inialize()
        {
            //click listeners
            this.tbScan.Leave += tbScan_Leave;
            this.tiSideBarBack.ItemClick += tiSideBarBack_ItemClick;
            this.tiSideBarNext.ItemClick += tiSideBarNext_ItemClick;
            this.tiSidebarUndo.ItemClick += tiSidebarUndo_ItemClick;
            this.tiOtherTicket.ItemClick += tiOtherTicket_ItemClick;
            this.tiOtherLogOff.ItemClick += tiOtherLogOff_ItemClick;
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
            this.lCount.Text = string.Empty;
            colorTiles();
        }

        void colorTiles()
        {
            cMethods.ColorTiles(tcOther, Program.ColorLink);
            tiSideBarCaseNote.AppearanceItem.Normal.BackColor = Program.ColorLink;
            tiSideBarBack.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
            tiSideBarNext.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
            tiSidebarUndo.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
        }

        void hide()
        {
            this.tc.Visible = false;
            this.lAccesionNo.Visible = false;
            this.lCount.Visible = false;
        }

        void show()
        {
            this.tcSidebar.Visible = true;
            this.lAccesionNo.Visible = true;
            this.lCount.Visible = true;
            this.tiSidebarUndo.Text = "<size=20>Undo</size>";
        }

        #endregion

        #region TileItem stuff
        private void loadNotesAndGross()
        {
            Invoke(new MethodInvoker(
                delegate
                {
                    SetNotes();
                    setGross();
                }
            ));
        }

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
        //Displays for both slides and blocks depending on the mode
        void displayTileItems()
        {
            this.tc.Visible = true;
            tgLeftL.Items.Clear();
            cMethods.AddTiles(lAllTiles, tgLeftL);
            //format tiles
            foreach (TileItem t in this.tgLeftL.Items)
            {
                counters[MAIN_COUNT] = cMethods.FormatTilesEmbed(t, lBlocks, counters[MAIN_COUNT]);
            }
            cMethods.SetCountersForMultiPageForms(lBlocks.Count, ref counters, PAGE_SIZE);
            cMethods.RemoveEmptyTiles(tgLeftL, counters[CURRENT_END_COUNT], PAGE_SIZE);
            string StartC = "";
            string EndC = "";

            //set the texts shown to the user
            this.lCount.Text = lBlocks.Count.ToString() + " Blocks. Viewing " + lBlocks[Math.Abs(counters[CURRENT_START_COUNT] - 1)].BlockName + " To " + lBlocks[Math.Abs(counters[CURRENT_END_COUNT] - 1)].BlockName;
            StartC = "<size=20>Back</size><br><size=12>" + lBlocks[Math.Abs(counters[PREVIOUS_START_COUNT] - 1)].BlockName + " to " + lBlocks[Math.Abs(counters[PREVIOUS_END_COUNT] - 1)].BlockName + "</size>";
            EndC = "<size=20>Next</size><br><size=12>" + lBlocks[Math.Abs(counters[NEXT_START_COUNT] - 1)].BlockName + " to " + lBlocks[Math.Abs(counters[NEXT_END_COUNT] - 1)].BlockName + "</size>";
            string back = "<size=20>Back</size><br><size=12>";
            string next = "<size=20>Next</size><br><size=12>";
            this.tiSideBarBack.Tag = true;
            this.tiSideBarNext.Tag = true;
            this.tiSideBarBack.AppearanceItem.Normal.BackColor = Program.ColorLink;
            this.tiSideBarNext.AppearanceItem.Normal.BackColor = Program.ColorLink;
            if (counters[PREVIOUS_START_COUNT] < 1 || counters[PREVIOUS_START_COUNT] == counters[PREVIOUS_END_COUNT])
            {//if there is no previous page, gray out the button and disable it
                StartC = back;
                this.tiSideBarBack.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
                this.tiSideBarBack.Tag = false;
            }
            if (counters[CURRENT_END_COUNT] == lBlocks.Count)
            {//if there is no next page, gray out the button and disable it
                EndC = next;
                this.tiSideBarNext.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
                this.tiSideBarNext.Tag = false;
            }
            this.tiSideBarNext.Text = EndC;
            this.tiSideBarBack.Text = StartC;
        }
        #endregion

        #region Events
        void tiSidebarUndo_ItemClick(object sender, TileItemEventArgs e)
        {
            int index = lCompletedBlocks.Count - 1;
            if (lCompletedBlocks.Count > 0)
            {
                TileItem ti = lCompletedBlocks[index];
                UndoBlock(ti);
                if (lCompletedBlocks.Count <= 0)
                    this.tiSidebarUndo.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
            }
        }
        void tiOtherTicket_ItemClick(object sender, TileItemEventArgs e)
        { cMethods.GoToTicketFromAForm(Enums.Mode.Embed); }

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
            if (o is cBlock)
            {
                cBlock bl = (cBlock)o;
                if (!bl.EmbedComplete)
                {
                    completeBlock(e.Item);
                }
                else
                {
                    frmDialog frm = new frmDialog(e.Item);
                    frm.ShowDialog();
                }
            }
        }

        private void tiOtherLogOff_ItemClick(object sender, TileItemEventArgs e)
        { Program.frmLogin.Initalize(Enums.Mode.Logout); }

        void tbScan_Leave(object sender, EventArgs e)
        {
            string sText = this.tbScan.Text;
            if (sText.Length > 1)
            {
                Program.LastAction = DateTime.Now;
                counters[MAIN_COUNT] = 0;
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
                else
                {
                    tgLeftL.Items.Clear();
                    if (!bwLoad.IsBusy)
                        bwLoad.RunWorkerAsync();

                    this.lAccesionNo.Text = Program.Acc.AccessionNo;
                    show();

                    Thread tNotesAndGross = new Thread(loadNotesAndGross);
                    tNotesAndGross.Start();

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
                    //cMethods.GetCaseBlocks();

                }


                //{
                //    lBlocks.Clear();
                //    this.lAccesionNo.Text = Program.Acc.AccessionNo;
                //    lBlocks = Program.Blocks;
                //    show();

                //    Thread tNotesAndGross = new Thread(loadNotesAndGross);
                //    tNotesAndGross.Start();
                //    displayTileItems();
                //}
            }
            this.tbScan.Text = string.Empty;
            this.ActiveControl = this.tbScan;
        }

        #endregion

        #region Complete and Undo block/slide
        private void completeBlock(TileItem ti)
        {
            cBlock bl = (cBlock)ti.Tag;
            CellappsDataContext db = new CellappsDataContext();
            db.SP_InsertItem_Log(bl.ItemGroupID, (int)Enums.ItemStatus.EmbedComplete, Program.User.Machine.LocationID, Program.User.UserID, Program.User.Machine.MachineID);
            bl.EmbedComplete = true;
            bl.EmbedTime = DateTime.Now;
            bl.EmbedBy = Program.User.Name;
            bl.EmbedByID = Program.User.UserID;
            lCompletedBlocks.Add(ti);
            cMethods.FormatTileEmbed(ti, bl);
            string undo = "<size=20>Undo</size><br><size=12>" + bl.BlockName + "</size>";
            this.tiSidebarUndo.Text = undo;
            this.tiSidebarUndo.AppearanceItem.Normal.BackColor = Program.ColorLink;
        }

        public void UndoBlock(TileItem ti)
        {
            cBlock bl = (cBlock)ti.Tag;
            CellappsDataContext db = new CellappsDataContext();
            //    delete item log
            cMethods.DeleteItemLog(bl.ItemGroupID);
            bl.EmbedComplete = false;
            bl.EmbedTime = DateTime.Now;
            bl.EmbedBy = string.Empty;
            bl.EmbedByID = 0;
            lCompletedBlocks.Remove(ti);
            cMethods.FormatTileEmbed(ti, bl);
            string undo = "<size=20>Undo</size>";
            if (lCompletedBlocks.Count > 0)
            {
                int index = lCompletedBlocks.Count - 1;
                TileItem tiNew = lCompletedBlocks[index];
                cBlock blNew = (cBlock)tiNew.Tag;
                undo = "<size=20>Undo</size><br><size=12>" + blNew.BlockName + "</size>";
            }
            this.tiSidebarUndo.Text = undo;
        }
        #endregion

        private void bwLoad_DoWork(object sender, DoWorkEventArgs e)
        {

            cMethods.GetCaseBlocks();
            if (Program.Blocks.Count > 0)
            {
                lBlocks.Clear();

                lBlocks = Program.Blocks;
                // loadNotesAndGross();


            }
        }

        private void bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //displayTileItems(); //calling display tile items twice makes it so completed blocks aren't blue. Why are you doing this? - Nathan

            displayTileItems();

        }

        private void tiSideBarCaseNote_ItemClick(object sender, TileItemEventArgs e)
        {
            frmCaseNotes caseNote = new frmCaseNotes();
            caseNote.ShowDialog();
            SetNotes();
        }



    }

}