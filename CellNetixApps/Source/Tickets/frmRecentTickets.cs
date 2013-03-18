using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Database;
using CellNetixApps.Source.Forms;
using CellNetixApps.Source.Embed.Forms;//for simple popup

namespace CellNetixApps.Source.Tickets
{
    public partial class frmRecentTickets : DevExpress.XtraEditors.XtraForm
    {
        const int SHRINK_FACTOR = 3;
        const int NUM_OF_TRACKED_CONTROLS = 2;
        const int INDEX_OF_TRACKED_TC = 0;
        const int INDEX_OF_TRACKED_MEMO = 1;
        const int SWITCH_TABS = 100;
        const int STAGE_TILE_INDEX = 0;
        const int ERROR_TILE_INDEX = 1;
        const int CLASSIFICATION_TILE_INDEX = 2;
        const int STATUS_TILE_INDEX = 3;
        Color errorSelectedColor;
        int lastXPos;
        //There is two lists per tile due to needing a list of strings for the multi-select form used.
        List<Ticket> lAllTickets;//user's recent tickets
        List<Ticket_Error_Classification> lAllClassifications;
        List<Ticket_Statuse> lAllStatuses;
        List<cTicketStage> lAllStages;
        List<Ticket_Error> lAllErrors;
        List<string> lNamesStageDescriptions = new List<string>();
        List<string> lNamesClassifications = new List<string>();
        List<string> lNamesStatuses = new List<string>();
        List<string> lNamesStageErrors = new List<string>();//this will change when the user clicks the error tile
        List<Ticket_Error> lCurrentStagesErrors = new List<Ticket_Error>();//this will change when the user clicks the error tile. It's a subset of lAllErrors.
        List<bool> lOkToSave = new List<bool>();
        List<List<Control>> controlsToTrack = new List<List<Control>>();
        public frmRecentTickets()
        {
            InitializeComponent();
            Program.LastAction = DateTime.Now;
            SetUpTickets();
            this.tiTransitionsLogOff.Text = "<size=14.25>Log Off</size><br><size=7>" + Program.User.Name + "</size>";
        }

        private void PopulateLists()
        {
            lAllStages = cMethods.GetTicketStages();
            lAllClassifications = cMethods.GetTicketClassifications();
            lAllStatuses = cMethods.GetTicketStatuses();
            lAllTickets = cMethods.GetRecentTickets(Program.User.UserID);
            lAllErrors = cMethods.GetAllTicketErrors();
            foreach (cTicketStage st in lAllStages)
                lNamesStageDescriptions.Add(st.description);
            foreach (Ticket_Error_Classification classif in lAllClassifications)
                lNamesClassifications.Add(classif.Description);
            foreach (Ticket_Statuse stat in lAllStatuses)
                lNamesStatuses.Add(stat.Description);
        }

        /// <summary>
        /// Uses the cellapps colors to color all the tiles.
        /// </summary>
        private void colorTiles()
        {
            cMethods.ColorTiles(tcSaveTemplate, Program.ColorLink);
            cMethods.ColorTiles(tcTicketPropertiesTemplate, Program.ColorToggledOn);
            cMethods.ColorTiles(tcTransitions, Program.ColorLink);
        }

        /// <summary>
        /// Sets up the tabs based off the template tabpage. Changes to the template will affect all of the pages.
        /// </summary>
        private void SetUpTickets()
        {
            PopulateLists();
            colorTiles();
            if (lAllTickets.Count != 0)
            {
                for (int i = 0; i < lAllTickets.Count; i++)
                {
                    List<Control> temp = new List<Control>(NUM_OF_TRACKED_CONTROLS);
                    //set labels
                    LabelControl accNo = new LabelControl();
                    LabelControl labelNotes = new LabelControl();
                    LabelControl ticketNumber = new LabelControl();
                    LabelControl dateCreated = new LabelControl();
                    accNo.Text = lAllTickets[i].Accession_No;
                    accNo.Appearance.Font = lAccessionNumber.Appearance.Font;
                    labelNotes.Text = "Notes";
                    labelNotes.Appearance.Font = lNotes.Appearance.Font;
                    ticketNumber.Font = lTicketNum.Font;
                    ticketNumber.Text = "Ticket #" + (i + 1);
                    dateCreated.Font = lCreated.Font;
                    dateCreated.Text = "Created: " + lAllTickets[i].Date_Created;
                    //set notes
                    MemoEdit ticketNotes = new MemoEdit();
                    ticketNotes.Text = lAllTickets[i].Ticket_Details;
                    ticketNotes.Font = meNotes.Font;
                    //tile stuff
                    TileControl tcSelections = new TileControl();
                    TileItem ticketStage = new TileItem();
                    TileItem ticketError = new TileItem();
                    TileItem ticketClassification = new TileItem();
                    TileItem ticketStatus = new TileItem();
                    TileGroup tgSelections = new TileGroup();
                    //for save
                    TileControl tcSave = new TileControl();
                    TileItem ticketSave = new TileItem();
                    TileGroup tgSave = new TileGroup();
                    tcSave.AllowDrag = false;
                    tcSelections.AllowDrag = false;

                    //****************Set up the tiles***********************
                    //status
                    Ticket_Statuse initialStatus = (from stat in lAllStatuses
                                                    where stat.Ticket_Status_ID == lAllTickets[i].Ticket_Status_ID
                                                    select stat).First();//grabs the first status
                    ticketStatus.AppearanceItem.Normal.BackColor = status.AppearanceItem.Normal.BackColor;
                    ticketStatus.Text = "Status\n<size=" + (status.AppearanceItem.Normal.FontHeight / SHRINK_FACTOR) + ">" + initialStatus.Description + "</size>";
                    ticketStatus.Tag = initialStatus;
                    ticketStatus.AppearanceItem.Normal.Font = status.AppearanceItem.Normal.Font;
                    ticketStatus.BackgroundImage = status.BackgroundImage;
                    ticketStatus.BackgroundImageAlignment = status.BackgroundImageAlignment;
                    ticketStatus.IsLarge = status.IsLarge;
                    //stage
                    cTicketStage initialStage = (from st in lAllStages
                                                 where st.stageID == lAllTickets[i].Ticket_Stage_ID
                                                 select st).First();//grabs the first stage
                    ticketStage.AppearanceItem.Normal.BackColor = stage.AppearanceItem.Normal.BackColor;
                    ticketStage.Text = "Stage\n\n<size=" + (stage.AppearanceItem.Normal.FontHeight / SHRINK_FACTOR) + ">" + initialStage.description + "</size>";
                    ticketStage.Tag = initialStage;
                    ticketStage.AppearanceItem.Normal.Font = stage.AppearanceItem.Normal.Font;
                    ticketStage.BackgroundImage = stage.BackgroundImage;
                    ticketStage.BackgroundImageAlignment = stage.BackgroundImageAlignment;
                    ticketStage.IsLarge = stage.IsLarge;
                    //classification
                    Ticket_Error_Classification initialClassif = (from classif in lAllClassifications
                                                                  where classif.Ticket_Error_Classification_ID == lAllTickets[i].Ticket_Error_Classification_ID
                                                                  select classif).First();//grabs the first classification
                    ticketClassification.AppearanceItem.Normal.BackColor = classification.AppearanceItem.Normal.BackColor;
                    ticketClassification.Text = "Classification\n<size=" + (classification.AppearanceItem.Normal.FontHeight / SHRINK_FACTOR) + ">" + initialClassif.Description + "</size>";
                    ticketClassification.Tag = initialClassif;
                    ticketClassification.AppearanceItem.Normal.Font = classification.AppearanceItem.Normal.Font;
                    ticketClassification.BackgroundImage = classification.BackgroundImage;
                    ticketClassification.BackgroundImageAlignment = classification.BackgroundImageAlignment;
                    ticketClassification.IsLarge = classification.IsLarge;
                    //error
                    Ticket_Error initialErr = (from err in lAllErrors
                                               where err.Ticket_Error_ID == lAllTickets[i].Ticket_Error_ID
                                               select err).First();//grabs the name of the error to show to the user
                    errorSelectedColor = ticketError.AppearanceItem.Normal.BackColor = error.AppearanceItem.Normal.BackColor;
                    ticketError.Text = "Error\n<size=" + (error.AppearanceItem.Normal.FontHeight / SHRINK_FACTOR) + ">" + initialErr.Description + "</size>";
                    ticketError.Tag = initialErr;
                    ticketError.AppearanceItem.Normal.Font = error.AppearanceItem.Normal.Font;
                    ticketError.BackgroundImage = error.BackgroundImage;
                    ticketError.BackgroundImageAlignment = error.BackgroundImageAlignment;
                    ticketError.IsLarge = error.IsLarge;
                    //save
                    ticketSave.AppearanceItem.Normal.BackColor = save.AppearanceItem.Normal.BackColor;
                    ticketSave.Text = "Save\n\n<size=" + (save.AppearanceItem.Normal.FontHeight / SHRINK_FACTOR) + ">" + "Ticket #" + (i + 1) + "</size>";
                    ticketSave.AppearanceItem.Normal.Font = save.AppearanceItem.Normal.Font;
                    ticketSave.BackgroundImage = save.BackgroundImage;
                    ticketSave.BackgroundImageAlignment = save.BackgroundImageAlignment;
                    ticketSave.IsLarge = save.IsLarge;
                    ticketSave.Tag = true;
                    //Add all of the tiles together (in correct order!)
                    tgSelections.Items.Add(ticketStage);
                    tgSelections.Items.Add(ticketError);
                    tgSelections.Items.Add(ticketClassification);
                    tgSelections.Items.Add(ticketStatus);
                    tgSave.Items.Add(ticketSave);
                    tcSave.Groups.Add(tgSave);
                    tcSelections.Groups.Add(tgSelections);

                    //create page to put them on
                    DevExpress.XtraTab.XtraTabPage page = new DevExpress.XtraTab.XtraTabPage();
                    page.Text = "Ticket #" + (i + 1);
                    //add to new page
                    page.Controls.Add(ticketNotes);
                    page.Controls.Add(tcSelections);
                    page.Controls.Add(tcSave);
                    page.Controls.Add(labelNotes);
                    page.Controls.Add(accNo);
                    page.Controls.Add(ticketNumber);
                    page.Controls.Add(dateCreated);

                    //set size and location of added controls
                    labelNotes.Location = lNotes.Location;
                    dateCreated.Location = lCreated.Location;
                    accNo.Location = lAccessionNumber.Location;
                    ticketNumber.Location = lTicketNum.Location;
                    tcSelections.Size = tcTicketPropertiesTemplate.Size;
                    tcSelections.Location = tcTicketPropertiesTemplate.Location;
                    tcSave.Size = tcSaveTemplate.Size;
                    tcSave.Location = tcSaveTemplate.Location;
                    ticketNotes.Location = meNotes.Location;
                    ticketNotes.Size = meNotes.Size;
                    tabRecentTickets.TabPages.Add(page);

                    //add click listeners
                    ticketError.ItemClick += error_ItemClick;
                    ticketStage.ItemClick += stage_ItemClick;
                    ticketClassification.ItemClick += classification_ItemClick;
                    ticketStatus.ItemClick += status_ItemClick;
                    ticketSave.ItemClick += save_ItemClick;
                    page.MouseDown += Scroll_MouseDown;
                    page.MouseUp += Scroll_MouseUp;

                    //initial ticket will be ok to save
                    lOkToSave.Add(true);

                    //track the controls for saving later
                    temp.Add(tcSelections);//ORDER MATTERS!
                    temp.Add(ticketNotes);
                    controlsToTrack.Add(temp);
                }
            }
            else
                lNoneFound.Visible = true;

            tabRecentTickets.TabPages.RemoveAt(0); // removes the template page so the user doesnt see it
        }

        private void tiTransitionsLogOff_ItemClick(object sender, TileItemEventArgs e)
        { Program.frmLogin.Initalize(Enums.Mode.Logout); }

        private void tiTransitionsMainMenu_ItemClick(object sender, TileItemEventArgs e)
        { this.Close(); }

        #region tile clicks
        private void stage_ItemClick(object sender, TileItemEventArgs e)
        {
            TileItem clicked = sender as TileItem;
            frmMultiSelectionPopup stages = new frmMultiSelectionPopup(lNamesStageDescriptions, "Select a Stage");
            stages.ShowDialog();
            if (stages.returnedIndex != -1 && (cTicketStage)clicked.Tag != lAllStages[stages.returnedIndex])//nothing or the same thing clicked
            {
                clicked.Tag = lAllStages[stages.returnedIndex];
                clicked.Text = "Stage\n<size=" + (clicked.AppearanceItem.Normal.FontHeight / SHRINK_FACTOR) + ">" + lNamesStageDescriptions[stages.returnedIndex] + "</size>";
                //They need to select an error that goes with this stage
                TileItem tickErrorTile = clicked.Group.Items[ERROR_TILE_INDEX];
                tickErrorTile.Text = "Error\n<size=" + (clicked.AppearanceItem.Normal.FontHeight / SHRINK_FACTOR) + ">Need to Select an Error</size>";
                tickErrorTile.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
                tickErrorTile.Tag = null;
                //no longer ok to save this specific ticket
                lOkToSave[tabRecentTickets.SelectedTabPageIndex] = false;//it's easier to do it this way than through the .Tag
            }
        }

        private void error_ItemClick(object sender, TileItemEventArgs e)
        {
            Program.LastAction = DateTime.Now;
            TileItem clicked = sender as TileItem;
            TileItem stageTile = clicked.Group.Items[STAGE_TILE_INDEX];
            int stageID = ((cTicketStage)stageTile.Tag).stageID;
            //**********grabs all the errors in the stage*************\\
            lCurrentStagesErrors = (from err in lAllErrors
                                    where err.Ticket_Stage_ID == stageID
                                    select err).ToList();
            lNamesStageErrors.Clear();
            foreach (Ticket_Error te in lCurrentStagesErrors)
                lNamesStageErrors.Add(te.Description);
            //********************************************************\\
            frmMultiSelectionPopup errrs = new frmMultiSelectionPopup(lNamesStageErrors, "Select an Error");
            errrs.ShowDialog();
            if (errrs.returnedIndex != -1)
            {
                clicked.Text = "Error\n<size=" + (clicked.AppearanceItem.Normal.FontHeight / SHRINK_FACTOR) + ">" + lNamesStageErrors[errrs.returnedIndex] + "</size>";
                clicked.AppearanceItem.Normal.BackColor = errorSelectedColor;//back to it's normal color if it was red
                clicked.Tag = lCurrentStagesErrors[errrs.returnedIndex];//to make it easier in the constructor this is just the ID not the object.
                lOkToSave[tabRecentTickets.SelectedTabPageIndex] = true;//this makes tracking when to save easier.
            }
        }

        private void classification_ItemClick(object sender, TileItemEventArgs e)
        {
            Program.LastAction = DateTime.Now;
            TileItem clicked = sender as TileItem;
            frmMultiSelectionPopup classif = new frmMultiSelectionPopup(lNamesClassifications, "Select a Classification");
            classif.ShowDialog();
            if (classif.returnedIndex != -1)
            {
                clicked.Tag = lAllClassifications[classif.returnedIndex];
                clicked.Text = "Classification\n<size=" + (clicked.AppearanceItem.Normal.FontHeight / SHRINK_FACTOR) + ">" + lNamesClassifications[classif.returnedIndex];
            }
        }

        private void status_ItemClick(object sender, TileItemEventArgs e)
        {
            Program.LastAction = DateTime.Now;
            TileItem clicked = sender as TileItem;
            frmMultiSelectionPopup stat = new frmMultiSelectionPopup(lNamesStatuses, "Select a Status");
            stat.ShowDialog();
            if (stat.returnedIndex != -1)
            {
                clicked.Tag = lAllStatuses[stat.returnedIndex];
                clicked.Text = "Status\n<size=" + (clicked.AppearanceItem.Normal.FontHeight / SHRINK_FACTOR) + ">" + lNamesStatuses[stat.returnedIndex];
            }
        }

        private void save_ItemClick(object sender, TileItemEventArgs e)
        {
            Program.LastAction = DateTime.Now;
            int pageIndex = tabRecentTickets.SelectedTabPageIndex;
            if (lOkToSave[pageIndex])
            {
                //Grab all the tiles and notes needed to update the ticket
                TileControl tiles = (TileControl)controlsToTrack[pageIndex][INDEX_OF_TRACKED_TC];
                MemoEdit tickNotes = (MemoEdit)controlsToTrack[pageIndex][INDEX_OF_TRACKED_MEMO];
                TileGroup grp = tiles.Groups[0];//should only be one group
                TileItem tiStage = grp.Items[STAGE_TILE_INDEX];
                TileItem tiError = grp.Items[ERROR_TILE_INDEX];
                TileItem tiClassif = grp.Items[CLASSIFICATION_TILE_INDEX];
                TileItem tiStatus = grp.Items[STATUS_TILE_INDEX];

                Ticket tickToUpdate = lAllTickets[pageIndex];
                //Assign the update to the ticket
                tickToUpdate.Date_Modified = DateTime.Now;
                tickToUpdate.Modified_By_ID = Program.User.UserID;
                tickToUpdate.Ticket_Details = tickNotes.Text;
                tickToUpdate.Ticket_Stage_ID = ((cTicketStage)tiStage.Tag).stageID;
                tickToUpdate.Ticket_Error_ID = ((Ticket_Error)tiError.Tag).Ticket_Error_ID;
                tickToUpdate.Ticket_Error_Classification_ID = ((Ticket_Error_Classification)tiClassif.Tag).Ticket_Error_Classification_ID;
                tickToUpdate.Ticket_Status_ID = ((Ticket_Statuse)tiStatus.Tag).Ticket_Status_ID;
                //Submit the ticket to the database
                cMethods.UpdateTicket(tickToUpdate);
                frmSimplePopup pop = new frmSimplePopup("Ticket Saved!");
                pop.ShowDialog();
            }
        }
        #endregion

        #region touch scroll
        private void Scroll_MouseDown(object sender, MouseEventArgs e)
        { lastXPos = e.X; }

        private void Scroll_MouseUp(object sender, MouseEventArgs e)
        {
            //a postive distance means that the user pressed down and swiped LEFT
            //a negative distance means that the user pressed down and swiped RIGHT
            //I'm not sure why it's the reverse of what it usually is...
            int distance = lastXPos - e.X;
            if (distance >= SWITCH_TABS && tabRecentTickets.SelectedTabPageIndex < tabRecentTickets.TabPages.Count-1)//right
            {
                tabRecentTickets.SelectedTabPage = tabRecentTickets.TabPages[tabRecentTickets.SelectedTabPageIndex + 1];
                this.Refresh();
            }
            else if ((distance <= -SWITCH_TABS) && tabRecentTickets.SelectedTabPageIndex > 0)//left
            {
                tabRecentTickets.SelectedTabPage = tabRecentTickets.TabPages[tabRecentTickets.SelectedTabPageIndex - 1];
                this.Refresh();
            }
            Program.LastAction = DateTime.Now;
        }
        #endregion

        #region keyboard and closing
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            cMethods.StopOSK();
        }
        private void keyboard_ItemClick(object sender, TileItemEventArgs e)
        {
            cMethods.StartOSK();
            //So the user can type right away
            int pageIndex = tabRecentTickets.SelectedTabPageIndex;
            controlsToTrack[pageIndex][INDEX_OF_TRACKED_MEMO].Focus();
        }
        #endregion
    }
}