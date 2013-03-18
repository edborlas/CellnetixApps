using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Forms;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Database;
using CellNetixApps.Source.Tickets;//for recenttcikets

namespace CellNetixApps.Source.Embed.Forms
{
    /// <summary>
    /// Assumptions:
    /// The correct/current Accession Number is inside of Program.Acc.AccessionNo.
    /// That the Program.User.userID is the correct user that is submitting the ticket.
    /// </summary>
    /// <author>NLucyk</author>
    public partial class frmTicket : DevExpress.XtraEditors.XtraForm
    {
        #region Global Variables
        // The tileitem lists are for when their respective tilegroup is cleared of items and needs blank tiles with click listeners already attached.
        List<TileItem> lAllTicketErrorTiles = new List<TileItem>();
        List<TileItem> lAllTicketItemTiles = new List<TileItem>();
        Hashtable htAllTicketErrorAttributes = new Hashtable();
        Enums.TicketRecType recType;
        int stageID;
        cTicketError clickedTicket = null;
        bool stageIDChanged = true;//this is for mitigating the db hits for the case details. Initially true so that the first clickedTicket works.
        TileItem selectedTicketItem = null;
        TileItem changeCase;
        cAcc initialCase = null;
        List<cBlock> initialBlocks;
        List<cSlide> initialSlides;
        List<cSpecimen> initialSpecimen;
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
        const int PAGE_SIZE = 20;
        #endregion
        #region initialize
        /// <summary>
        /// Creates a menu for the user to select what type of ticket they want to submit and a menu to submit that selected ticket.
        /// </summary>
        /// <param name="stage_ID">If you do not know what to pass here you are most likely looking for the frmTicketMainMenu class.</param>
        /// <param name="stageName">This is the string that is displayed to the user at the top left of the initial (ticket error) menu (not displayed in the submission screen)</param>
        public frmTicket(int stage_ID, string stageName = null)
        {
            stageID = stage_ID;
            InitializeComponent();
            initialize();
            if (stageName != null)
                this.lTicketType.Text = stageName;
            else
                this.lTicketType.Visible = false;
            ColorTiles();
            showTickets();
        }

        private void ColorTiles()
        {
            cMethods.ColorTiles(tcMyTickets, Program.ColorLink);
            cMethods.ColorTiles(tcSidebar, Program.ColorLink);
            cMethods.ColorTiles(tcSubmission, Program.ColorLink);
            cMethods.ColorTiles(tcTicketItems, Program.ColorToggledOff);
            cMethods.ColorTiles(tc, Program.ColorLink);
            tcTicketDetails.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
            tcTicketDetails.AppearanceItem.Normal.BorderColor = Color.Black;
        }

        /// <remarks>
        /// Assumes that the ticketStageID of cutting and embed won't change (doesn't open the database to search for them). 19 and 20 are hardcoded in for cutting and embedding respectively.
        /// This was done because the assumption that the "Description" (which would have to be used to search for the ticketSourceID) won't change is just as good as the assumption that the ticketStageID wont.
        /// </remarks>
        void initialize()
        {
            this.cbResponse.Visible = false;
            this.cbPPNotes.Visible = false;
            cMethods.GetTicketErrors(stageID);
            this.tiSideBarBack.ItemClick += tiSideBarBack_ItemClick;
            this.tiSideBarNext.ItemClick += tiSideBarNext_ItemClick;
            this.tiSideBarClose.ItemClick += tiSideBarClose_ItemClick;
            this.tiSubmissionCancel.ItemClick += tiSubmissionCancel_ItemClick;
            this.tiSubmissionSubmit.ItemClick += tiSubmissionSubmit_ItemClick;
            this.tiSideBarStages.ItemClick += tiSideBarStages_ItemClick;
            for (int i = 0; i < PAGE_SIZE; i++)
            {
                tgLeftL.Items[i].ItemClick += t_ItemClick;
                lAllTicketErrorTiles.Add(tgLeftL.Items[i]);
                tgTicketItems.Items[i].ItemClick += ticketItem_ItemClick;
                lAllTicketItemTiles.Add(tgTicketItems.Items[i]);
            }
            Program.LastAction = DateTime.Now;
            //To allow the user to change the case they are looking at later
            changeCase = new TileItem();
            changeCase.BackgroundImage = global::CellNetixApps.Properties.Resources.change;
            changeCase.BackgroundImageAlignment = TileItemContentAlignment.BottomCenter;
            changeCase.AppearanceItem.Normal.BackColor = Program.ColorLink;
            changeCase.ItemClick += changeCase_ItemClick;
            changeCase.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            changeCase.Text = "Change Case";
            if (Program.Acc != null)
            {
                initialCase = Program.Acc;
                initialBlocks = Program.Blocks;
                initialSlides = Program.Slides;
                initialSpecimen = Program.Specimens;
            }
        }
        #endregion
        #region Ticket Error Screen

        private void showTickets()
        {
            tgLeftL.Items.Clear();

            cMethods.AddTiles(lAllTicketErrorTiles, tgLeftL);
            cMethods.FormatTicketErrorTiles(this.tgLeftL, ref counters[MAIN_COUNT]);//not sure if tile group should be ref
            cMethods.SetCountersForMultiPageForms(Program.TicketErrors.Count, ref counters, PAGE_SIZE);
            //even though the user probably doesn't need to know the range of tickets on the pages, it's kinda cool.
            if (counters[CURRENT_START_COUNT] == counters[CURRENT_END_COUNT])
                this.lCount.Text = Program.TicketErrors.Count.ToString() + " Error Types. Viewing #" + counters[CURRENT_START_COUNT];
            else
                this.lCount.Text = Program.TicketErrors.Count.ToString() + " Error Types. Viewing #" + counters[CURRENT_START_COUNT] + " To #" + counters[CURRENT_END_COUNT];
            string back = "<size=20>Back</size><br><size=12>";
            string StartC = "<size=20>Back</size><br><size=12>" + counters[PREVIOUS_START_COUNT] + " to " + counters[PREVIOUS_END_COUNT] + "</size>";
            string EndC = "<size=20>Next</size><br><size=12>" + counters[NEXT_START_COUNT] + " to " + counters[NEXT_END_COUNT] + "</size>";
            string next = "<size=20>Next</size><br><size=12>";
            this.tiSideBarBack.Tag = true;
            this.tiSideBarNext.Tag = true;
            this.tiSideBarBack.AppearanceItem.Normal.BackColor = Program.ColorLink;
            this.tiSideBarNext.AppearanceItem.Normal.BackColor = Program.ColorLink;
            if (counters[MAIN_COUNT] % PAGE_SIZE != 0)
                removeEmptyTiles(tgLeftL);
            if (counters[PREVIOUS_START_COUNT] < 1 || counters[PREVIOUS_START_COUNT] == counters[PREVIOUS_END_COUNT])
            {//if there is no previous page, gray out the button and disable it
                StartC = back;
                this.tiSideBarBack.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
                this.tiSideBarBack.Tag = false;
            }
            if (counters[CURRENT_END_COUNT] == Program.TicketErrors.Count)
            {//if there is no next page, gray out the button and disable it
                EndC = next;
                this.tiSideBarNext.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
                this.tiSideBarNext.Tag = false;
            }
            this.tiSideBarNext.Text = EndC;
            this.tiSideBarBack.Text = StartC;
        }
        void t_ItemClick(object sender, TileItemEventArgs e)
        {
            //launch ticket submission form
            if (e.Item.Tag is cTicketError)
            {
                Program.LastAction = DateTime.Now;
                cTicketError newlyClicked = (cTicketError)e.Item.Tag;
                if (clickedTicket != null)
                    stageIDChanged = newlyClicked.ticketErrorID != clickedTicket.ticketErrorID;
                clickedTicket = newlyClicked;
                ticketSubmissionScreenSetup();
            }
        }

        private void getAccNo()
        {
            if (Program.Acc == null)
            {
                frmTextEnteringPopup getPLNo = new frmTextEnteringPopup("Please Enter the Case Number: ",true, true);
                getPLNo.ShowDialog();
            }
            switch (recType)
            {
                case Enums.TicketRecType.Blocks:
                    if (Program.Blocks == null)
                    {
                        cMethods.GetCaseBlocks();
                        if (Program.Blocks.Count <= 0)
                            recType = Enums.TicketRecType.None;
                    }
                    break;
                case Enums.TicketRecType.Slides:
                    if (Program.Slides == null)
                    {
                        cMethods.GetCaseSlides();
                        if (Program.Slides.Count <= 0)
                            recType = Enums.TicketRecType.None;
                    }
                    break;
                case Enums.TicketRecType.Specimens:
                    if (Program.Specimens == null)
                    {
                        cMethods.GetCaseSpecimens();
                        if (Program.Specimens.Count <= 0)
                            recType = Enums.TicketRecType.None;
                    }
                    break;
            }
        }
        private void getRecType()
        {
            List<Enums.TicketRecType> lRecTypes = cMethods.getTicketRecTypes(clickedTicket.ticketErrorID);//Enums.TicketRecType.Blocks;
            if (lRecTypes.Count > 1)
            {
                List<String> tileTextForPopup = new List<string>();
                foreach (Enums.TicketRecType temp in lRecTypes)
                    tileTextForPopup.Add(temp.ToString());
                String headerTextForPopup = "Please select a rec type";//change this to something the user will understand.
                bool userDidntSelectTile = true;
                while (userDidntSelectTile)
                {
                    frmMultiSelectionPopup recTypeSelection = new frmMultiSelectionPopup(tileTextForPopup, headerTextForPopup);
                    recTypeSelection.ShowDialog();
                    int selectionOfUser = recTypeSelection.returnedIndex;
                    if (selectionOfUser != -1)
                    {
                        recType = lRecTypes[selectionOfUser];
                        userDidntSelectTile = false;
                    }
                    else
                        headerTextForPopup = "You must select a rec type.";
                }
            }
            else if (lRecTypes.Count == 1)
                recType = lRecTypes[0];
            else
                recType = Enums.TicketRecType.None;
        }
        #endregion
        #region Ticket Submission Screen

        private void showTicketItems()
        {
            string StartC = "";
            string EndC = "";
            int totalOfItems=0;



            tgTicketItems.Items.Clear();
            cMethods.AddTiles(lAllTicketItemTiles, tgTicketItems);
            cMethods.FormatTicketItemTiles(this.tgTicketItems, ref counters[MAIN_COUNT], recType);
            //Changes what is displayed to the user depending on what recType it is (e.g., slides will tell the user to select a slide and give slide-based info on the tiles)
            switch(recType)
            {//the if-else's are for when there is not a range of tiles shown to the user. This will replace "Viewing A-A" with "Viewing A".
                case Enums.TicketRecType.Slides:
                    totalOfItems = Program.Slides.Count;
                    this.lTicketItem.Text = "Please select a slide";
                    cMethods.SetCountersForMultiPageForms(Program.Slides.Count, ref counters, PAGE_SIZE);
                    if (Program.Slides[Math.Abs(counters[CURRENT_START_COUNT] - 1)].Label == Program.Slides[Math.Abs(counters[CURRENT_END_COUNT] - 1)].Label)
                        this.lTicketItemCount.Text = totalOfItems.ToString() + " Slides. Viewing " + Program.Slides[Math.Abs(counters[CURRENT_START_COUNT] - 1)].Label;
                    else
                        this.lTicketItemCount.Text = totalOfItems.ToString() + " Slides. Viewing " + Program.Slides[Math.Abs(counters[CURRENT_START_COUNT] - 1)].Label + " To " + Program.Slides[Math.Abs(counters[CURRENT_END_COUNT] - 1)].Label;
                    if (Program.Slides[Math.Abs(counters[PREVIOUS_START_COUNT] - 1)].Label == Program.Slides[Math.Abs(counters[PREVIOUS_END_COUNT] - 1)].Label)
                        StartC = "<size=20>Back</size><br><size=12>" + Program.Slides[Math.Abs(counters[PREVIOUS_START_COUNT] - 1)].Label + "</size>";
                    else
                        StartC = "<size=20>Back</size><br><size=12>" + Program.Slides[Math.Abs(counters[PREVIOUS_START_COUNT] - 1)].Label + " to " + Program.Slides[Math.Abs(counters[PREVIOUS_END_COUNT] - 1)].Label + "</size>";
                    if (Program.Slides[Math.Abs(counters[NEXT_START_COUNT] - 1)].Label == Program.Slides[Math.Abs(counters[NEXT_END_COUNT] - 1)].Label)
                        EndC = "<size=20>Next</size><br><size=12>" + Program.Slides[Math.Abs(counters[NEXT_START_COUNT] - 1)].Label + "</size>";
                    else
                        EndC = "<size=20>Next</size><br><size=12>" + Program.Slides[Math.Abs(counters[NEXT_START_COUNT] - 1)].Label + " to " + Program.Slides[Math.Abs(counters[NEXT_END_COUNT] - 1)].Label + "</size>";
                    break;
                case Enums.TicketRecType.Blocks:
                    totalOfItems = Program.Blocks.Count;
                    this.lTicketItem.Text = "Please select a block";
                    cMethods.SetCountersForMultiPageForms(Program.Blocks.Count, ref counters, PAGE_SIZE);
                    if (Program.Blocks[Math.Abs(counters[CURRENT_START_COUNT] - 1)].BlockName == Program.Blocks[Math.Abs(counters[CURRENT_END_COUNT] - 1)].BlockName)
                        this.lTicketItemCount.Text = totalOfItems.ToString() + " Blocks. Viewing " + Program.Blocks[Math.Abs(counters[CURRENT_START_COUNT] - 1)].BlockName;
                    else
                        this.lTicketItemCount.Text = totalOfItems.ToString() + " Blocks. Viewing " + Program.Blocks[Math.Abs(counters[CURRENT_START_COUNT] - 1)].BlockName + " To " + Program.Blocks[Math.Abs(counters[CURRENT_END_COUNT] - 1)].BlockName;
                    if (Program.Blocks[Math.Abs(counters[PREVIOUS_START_COUNT] - 1)].BlockName == Program.Blocks[Math.Abs(counters[PREVIOUS_END_COUNT] - 1)].BlockName)
                        StartC = "<size=20>Back</size><br><size=12>" + Program.Blocks[Math.Abs(counters[PREVIOUS_START_COUNT] - 1)].BlockName + "</size>";
                    else
                        StartC = "<size=20>Back</size><br><size=12>" + Program.Blocks[Math.Abs(counters[PREVIOUS_START_COUNT] - 1)].BlockName + " to " + Program.Blocks[Math.Abs(counters[PREVIOUS_END_COUNT] - 1)].BlockName + "</size>";
                    if(Program.Blocks[Math.Abs(counters[NEXT_START_COUNT] - 1)].BlockName == Program.Blocks[Math.Abs(counters[NEXT_END_COUNT] - 1)].BlockName)
                        EndC = "<size=20>Next</size><br><size=12>" + Program.Blocks[Math.Abs(counters[NEXT_START_COUNT] - 1)].BlockName + "</size>";
                    else
                    EndC = "<size=20>Next</size><br><size=12>" + Program.Blocks[Math.Abs(counters[NEXT_START_COUNT] - 1)].BlockName + " to " + Program.Blocks[Math.Abs(counters[NEXT_END_COUNT] - 1)].BlockName + "</size>";
                    break;
                case Enums.TicketRecType.Specimens:
                    totalOfItems = Program.Specimens.Count;
                    this.lTicketItem.Text = "Please select a specimen";
                    cMethods.SetCountersForMultiPageForms(Program.Specimens.Count, ref counters, PAGE_SIZE);
                    if (Program.Specimens[Math.Abs(counters[CURRENT_START_COUNT] - 1)].Label == Program.Specimens[Math.Abs(counters[CURRENT_END_COUNT] - 1)].Label)
                        this.lTicketItemCount.Text = totalOfItems.ToString() + " Specimens. Viewing " + Program.Specimens[Math.Abs(counters[CURRENT_START_COUNT] - 1)].Label;
                    else
                        this.lTicketItemCount.Text = totalOfItems.ToString() + " Specimens. Viewing " + Program.Specimens[Math.Abs(counters[CURRENT_START_COUNT] - 1)].Label + " To " + Program.Specimens[Math.Abs(counters[CURRENT_END_COUNT] - 1)].Label;
                    if (Program.Specimens[Math.Abs(counters[PREVIOUS_START_COUNT] - 1)].Label == Program.Specimens[Math.Abs(counters[PREVIOUS_END_COUNT] - 1)].Label)
                        StartC = "<size=20>Back</size><br><size=12>" + Program.Specimens[Math.Abs(counters[PREVIOUS_START_COUNT] - 1)].Label + "</size>";
                    else
                        StartC = "<size=20>Back</size><br><size=12>" + Program.Specimens[Math.Abs(counters[PREVIOUS_START_COUNT] - 1)].Label + " to " + Program.Specimens[Math.Abs(counters[PREVIOUS_END_COUNT] - 1)].Label + "</size>";
                    if (Program.Specimens[Math.Abs(counters[NEXT_START_COUNT] - 1)].Label == Program.Specimens[Math.Abs(counters[NEXT_END_COUNT] - 1)].Label)
                        EndC = "<size=20>Next</size><br><size=12>" + Program.Specimens[Math.Abs(counters[NEXT_START_COUNT] - 1)].Label + "</size>";
                    else
                        EndC = "<size=20>Next</size><br><size=12>" + Program.Specimens[Math.Abs(counters[NEXT_START_COUNT] - 1)].Label + " to " + Program.Specimens[Math.Abs(counters[NEXT_END_COUNT] - 1)].Label + "</size>";
                    break;
            }
            if (counters[MAIN_COUNT] % PAGE_SIZE != 0)
                removeEmptyTiles(tgTicketItems);
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
            if (counters[CURRENT_END_COUNT] == totalOfItems)
            {//if there is no next page, gray out the button and disable it
                EndC = next;
                this.tiSideBarNext.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
                this.tiSideBarNext.Tag = false;
            }
            this.tiSideBarNext.Text = EndC;
            this.tiSideBarBack.Text = StartC;
        }
        /// <summary>
        /// Unchecks the selected item and changes it's background color back to the unselected color.
        /// </summary>
        void unselectTicketItem()
        {
            if (selectedTicketItem != null)
            {
                selectedTicketItem.Checked = false;
                selectedTicketItem.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
            }
        }
        //enables the button and changes it color to show the user it can be clicked now.
        void tiSubmissionSubmit_Enabled()
        {
            this.tiSubmissionSubmit.Tag = true;
            this.tiSubmissionSubmit.AppearanceItem.Normal.BackColor = Program.ColorLink;
        }
        void tiSubmissionSubmit_ItemClick(object sender, TileItemEventArgs e)
        {
            if (e.Item.Tag != null && (bool)e.Item.Tag)
            {//by getting into this if, it is assumed that there is a selected ticketItem, if it is not of rectype none.
                this.lSubmitFailed.Visible = false;
                int ticketID = 0;
                switch (recType)
                {//controls what to submit with the ticket
                    case Enums.TicketRecType.Slides:
                        cSlide slide = (cSlide)selectedTicketItem.Tag;
                        ticketID = cMethods.insertTicket(clickedTicket, this.meTicketNotes.Text, stageID, Program.User.UserID, slide.ItemID, slide.AccID, null, Program.Acc.AccessionNo, cbResponse.Checked);
                        break;
                    case Enums.TicketRecType.Blocks:
                        cBlock block = (cBlock)selectedTicketItem.Tag;
                        ticketID = cMethods.insertTicket(clickedTicket, this.meTicketNotes.Text, stageID, Program.User.UserID, block.ItemID, block.AccID, null, Program.Acc.AccessionNo, cbResponse.Checked);
                        break;
                    case Enums.TicketRecType.Specimens:
                        cSpecimen speci = (cSpecimen)selectedTicketItem.Tag;
                        ticketID = cMethods.insertTicket(clickedTicket, this.meTicketNotes.Text, stageID, Program.User.UserID, accID: speci.AccID, accNo: Program.Acc.AccessionNo,Urgent: cbResponse.Checked);
                        break;
                    case Enums.TicketRecType.None:
                        ticketID = cMethods.insertTicket(clickedTicket, this.meTicketNotes.Text, stageID, Program.User.UserID, accNo: Program.Acc.AccessionNo,Urgent: cbResponse.Checked);
                        break;
                }

                if (cbResponse.Checked)
                {
                    string groupEmail = cMethods.GetGroupEmail(clickedTicket.sourceOwnerID);
                    cMethods.SendEmail(groupEmail, "New Ticket - Ticket #" + ticketID + " " + Program.Acc.AccessionNo + " " + clickedTicket.source, this.meTicketNotes.Text);
                }

                foreach (TileItem detail in tgTicketDetails.Items)
                {
                    if (detail.Checked)
                    {
                        int ticketDetailID = (int)detail.Tag;

                        CellappsDataContext tdb = new CellappsDataContext();
                        Ticket_Detail_Log tdl = new Ticket_Detail_Log();
                        tdl.Ticket_Detail_ID = ticketDetailID;
                        tdl.Ticket_ID = ticketID;
                        tdb.Ticket_Detail_Logs.InsertOnSubmit(tdl);
                        tdb.SubmitChanges();
                        //put into table that hasn't been made yet
                    }
                }
                addCaseNote();
                frmSimplePopup popup = (ticketID != 0) ? new frmSimplePopup("Ticket Submission Successful!") : new frmSimplePopup("Ticket Submission has Failed.\n\t\tPlease try again.", true);
                popup.ShowDialog();
                ticketErrorsScreenSetup();
            }
            else
                this.lSubmitFailed.Visible = true;
        }


        void addCaseNote()
        {
            
            string note = this.meTicketNotes.Text;
            if (Program.Acc == null)
            {
                MessageBox.Show("Please Scan a slide or type Accession No to bring up a case first");
                return;
            }

            if (cbPPNotes.SelectedIndex > 0)
            {
                ComboboxItem ci = (ComboboxItem)cbPPNotes.SelectedItem;
                string topic = ci.Text;
                PowerPathDataContext pdb = new PowerPathDataContext();
                pdb.stprc_clntx_path_add_note_logic(Program.Acc.AccID, Program.User.PPuserID, topic, note, (char)Enums.Note.Insert,null);
            }

        }

        void tiSubmissionCancel_ItemClick(object sender, TileItemEventArgs e)
        { ticketErrorsScreenSetup(); }
        void ticketItem_ItemClick(object sender, TileItemEventArgs e)
        {
            unselectTicketItem();
            if (selectedTicketItem != e.Item)
            {
                selectedTicketItem = e.Item;
                tiSubmissionSubmit_Enabled();
                selectedTicketItem.Checked = true;
                selectedTicketItem.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
            }
            else
            {
                selectedTicketItem = null;//unselectTicketItem
                //disable submit button
                this.tiSubmissionSubmit.Tag = false;
                this.tiSubmissionSubmit.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
            }
        }
        private void tiKeyboard_ItemClick(object sender, TileItemEventArgs e)
        {
            cMethods.StartOSK();
            meTicketNotes.Focus();
        }

        #endregion
        #region Generalized Functions
        void resetCounters()
        {
            for (int i = 0; i < counters.Length; i++)
            {
                counters[i] = 0;
            }
        }
        ///<summary>
        ///removes the excess tiles that may occur in the last page. Assumes the tilegroup has at most page_size items 
        ///and that the MAIN_COUNT index keeps count of the last filled tile on the page
        ///</summary>
        void removeEmptyTiles(TileGroup tg)
        {
            int lastPositionOnPage = counters[CURRENT_END_COUNT] % PAGE_SIZE;
            if (lastPositionOnPage != 0)//divisible by pagesize so all the tile's have something on them.
            {
                for (int i = PAGE_SIZE - 1; i >= lastPositionOnPage; i--)
                    tg.Items.RemoveAt(i);
            }
        }

        #endregion
        #region sidebar controls

        void tiSideBarClose_ItemClick(object sender, TileItemEventArgs e)
        { this.Close(); }

        void tiSideBarNext_ItemClick(object sender, TileItemEventArgs e)
        {
            if (e.Item.Tag != null && (bool)e.Item.Tag)
            {
                if (this.tgLeftL.Visible == true)
                    showTickets();
                else if(this.tgTicketItems.Visible==true)
                    showTicketItems();
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
                if (this.tgLeftL.Visible == true)
                {
                    tgLeftL.Items.Clear();
                    showTickets();
                }
                else if (this.tgTicketItems.Visible == true)
                {
                    tgTicketItems.Items.Clear();
                    showTicketItems();
                }
            }
        }

        void changeCase_ItemClick(object sender, TileItemEventArgs e)
        {
            Program.LastAction = DateTime.Now;
            //copy paste code from getAccNo but without the checking for null....
            frmTextEnteringPopup getPLNo = new frmTextEnteringPopup("Please Enter the Case Number: ", true, true);
            getPLNo.ShowDialog();
            switch (recType)
            {
                case Enums.TicketRecType.Blocks:
                    cMethods.GetCaseBlocks();
                    if (Program.Blocks.Count <= 0)
                        recType = Enums.TicketRecType.None;
                    break;
                case Enums.TicketRecType.Slides:
                    cMethods.GetCaseSlides();
                    if (Program.Slides.Count <= 0)
                        recType = Enums.TicketRecType.None;
                    break;
                case Enums.TicketRecType.Specimens:
                    cMethods.GetCaseSpecimens();
                    if (Program.Specimens.Count <= 0)
                        recType = Enums.TicketRecType.None;
                    break;
            }
            //remove it so there isnt two
            tgSidebar.Items.Remove(changeCase);
            //add it so it can remove it....... this is dumb
            tgSidebar.Items.Add(tiSideBarStages);
            ticketSubmissionScreenSetup();//inefficient because it's going to check the recType but you already know the rectype.
        }
        
        void tiSideBarStages_ItemClick(object sender, TileItemEventArgs e)
        {
            int formOpenedBeforeThisOne = Application.OpenForms.Count - 2; //open applications are stored sequentially. So the last one will be this opened form.
            //Assumes that the forms are opened with ShowDialog (there can't be a form between this one and the main menu if they have main menu open).
            if (Application.OpenForms[formOpenedBeforeThisOne].Name != "frmTicketMainMenu")
            {
                frmTicketMainMenu stages = new frmTicketMainMenu();
                stages.ShowDialog();
            }
            this.Close();
        }

        #endregion
        #region Screen Transitions
        /// <summary> Sets up the visibility and booleans needed for the user to return to the tickets error screen (where the user can select a type of ticket to submit). </summary>
        void ticketErrorsScreenSetup()
        {
            this.cbResponse.Visible = false;
            this.cbPPNotes.Visible = false;
            Program.LastAction = DateTime.Now;
            this.lTicketInstructions.Visible = false;
            this.tgLeftL.Visible = true;
            this.lTicketType.Visible = true;
            this.lCount.Visible = true;
            this.lTicketItemCount.Visible = false;
            this.meTicketNotes.Visible = false;
            this.tcSubmission.Visible = false;
            this.lTicketNotes.Visible = false;
            this.tcTicketItems.Visible = false;
            this.lSubmitFailed.Visible = false;
            this.tcTicketDetails.Visible = false;
            unselectTicketItem();
            selectedTicketItem = null;
            resetCounters();
            showTickets();
            this.lCaseNumber.Visible = false;
            this.tgSidebar.Items.Remove(changeCase);
            this.tgSidebar.Items.Add(tiSideBarStages);
        }
        /// <summary> Sets up the visibility and booleans needed for when the user clicks on a ticket type (ticket submission screen).</summary>
        void ticketSubmissionScreenSetup()
        {
            Program.LastAction = DateTime.Now;
            this.tiSubmissionSubmit.Tag = false;
            this.tiSubmissionSubmit.AppearanceItem.Normal.BackColor = Program.ColorDisabled;

            getRecType();
            getAccNo();

            //Show case number and allow to change it
            this.lCaseNumber.Text = Program.Acc.AccessionNo;
            this.lCaseNumber.Visible = true;
            tgSidebar.Items.Remove(tiSideBarStages);
            tgSidebar.Items.Add(changeCase);

            if (recType != Enums.TicketRecType.None)
            {
                resetCounters();
                showTicketItems();
                this.tcTicketItems.Visible = true;
                this.lTicketItemCount.Visible = true;
            }
            else
            {
                tgTicketItems.Items.Clear();//in case they came form a case with stuff.
                //reset back and next so they don't hold onto their value of the previous screen
                this.tiSideBarBack.Text = "<size=20>Back</size><br><size=12>";
                this.tiSideBarNext.Text = "<size=20>Next</size><br><size=12>";
                this.tiSideBarNext.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
                this.tiSideBarNext.Tag = false;
                this.tiSideBarBack.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
                this.tiSideBarBack.Tag = false;

                this.tcTicketItems.Visible = false;
                this.lTicketItemCount.Visible = false;
                tiSubmissionSubmit_Enabled();
            }
            this.lTicketInstructions.Text = "Review and Submit Ticket for Error:\n\t" + clickedTicket.description;
            this.lTicketInstructions.Visible = true;
            this.tgLeftL.Visible = false;
            this.lTicketType.Visible = false;
            this.lCount.Visible = false;
            this.meTicketNotes.Visible = true;
            this.tcSubmission.Visible = true;
            this.lTicketNotes.Visible = true;
            this.lSubmitFailed.Visible = false;

            this.cbResponse.Visible = true;
            this.cbPPNotes.Visible = true;
            this.tcTicketDetails.Visible = true;
            List<cNoteTopic> lTopics = cMethods.getNoteTopics();



            foreach (cNoteTopic note in lTopics)
            {
                ComboboxItem ci = new ComboboxItem();
                ci.Text = note.Description;
                ci.Value = note.NoteTopicID;
                cbPPNotes.Items.Add(ci);
            }

            ComboboxItem ciSelect = new ComboboxItem();
            ciSelect.Text = "(Optional) Add to Case Note - Select PP Note Topic";
            ciSelect.Value = "0";
            cbPPNotes.Items.Insert(0, ciSelect);
            cbPPNotes.SelectedIndex = 0;


            this.meTicketNotes.Text = string.Empty;
            //Ticket details
            if (stageIDChanged)//mitigate db hit. Initially true so it will work with the first clicked ticket!
            {//so if they change cases or something it won't hit the db. This might be overkill (as the probability of going into the same ticketerror might be low...)
                tgTicketDetails.Items.Clear();
                CellappsDataContext db = new CellappsDataContext();
                var query = from ted in db.Ticket_Error_Details
                            join te in db.Ticket_Details on ted.Ticket_Detail_ID equals te.Ticket_Detail_ID
                            where ted.Ticket_Error_ID == clickedTicket.ticketErrorID
                            select te;
                if (query != null && query.Count() > 0)
                {
                    foreach (Ticket_Detail td in query)
                    {
                        TileItem tickDetail = new TileItem();
                        tickDetail.IsLarge = true;
                        tickDetail.Text = td.Description;
                        tickDetail.Tag = td.Ticket_Detail_ID;
                        tickDetail.ItemClick += tickDetail_ItemClick;
                        tgTicketDetails.Items.Add(tickDetail);
                    }
                }
            }

        }

        void tickDetail_ItemClick(object sender, TileItemEventArgs e)
        {
            TileItem clicked = e.Item;
            //toggle color and checked for the item.
            if (clicked.Checked)
            {
                clicked.Checked = false;
                clicked.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
            }
            else
            {
                clicked.Checked = true;
                clicked.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
            }
        }
        #endregion

        protected override void OnClosing(CancelEventArgs e)
        {
            if (initialCase != null)
            {//to avoid messing up CCUT or CEMBED
                Program.Acc = initialCase;
                Program.Blocks = initialBlocks;
                Program.Slides = initialSlides;
                Program.Specimens = initialSpecimen;
            }
            base.OnClosing(e);
        }

        private void tiMyTickets_ItemClick(object sender, TileItemEventArgs e)
        {
            frmRecentTickets recentTicks = new frmRecentTickets();
            recentTicks.ShowDialog();
        }
    }
}
