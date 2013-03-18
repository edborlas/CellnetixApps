using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using CellNetixApps.Source.Database;
using System.Linq;
using CellNetixApps.Source.Classes;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using DevExpress.Utils;
using DevExpress.XtraBars.Ribbon;
using DevExpress.Utils.Drawing;
using DevExpress.LookAndFeel;
using System.Threading;
using CellNetixApps.Source.Embed.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.Skins;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;

namespace CellNetixApps.Source.Path.Forms
{
    /// <summary>
    /// A form for when the user clicks the "Pathologist" button. Allows the user to enter a case and see all the relevant information about it. Including: images, specimens, slides, phone numbers,
    /// notes, results and much more.
    /// </summary>
    public partial class frmPath : DevExpress.XtraEditors.XtraForm
    {

        Thread tPicture;
        ToolsDataContext tdb = new ToolsDataContext();
        CellappsDataContext cdb = new CellappsDataContext();
        PowerPathDataContext pdb = new PowerPathDataContext();
        /// <summary>
        /// Initializes the components and sets the events for the case scan.
        /// </summary>
        public frmPath()
        {
            InitializeComponent();
            Program.frmPath = this;
            this.ActiveControl = this.teCaseScan;
            this.teCaseScan.Leave += tbScan_Leave;
            this.teCaseScan.Focus();
            populateOnce();
            Point p = new Point(1, 1);
            this.Location = p;


            new TouchScrollHelper(gvCalendarSchedule);
            new TouchScrollHelper(gvCaseBlocks);
            new TouchScrollHelper(gvCaseChargeCodes);
            new TouchScrollHelper(gvCaseICD9);
            new TouchScrollHelper(gvCaseSlides);
            new TouchScrollHelper(gvCaseSpecimens);
            // new TouchScrollHelper(gvNotesNotes);
            // new TouchScrollHelper(gvPhoneNumbers);
            //  new TouchScrollHelper(gvQueueAssignedCases);
            // new TouchScrollHelper(gvQueueOrders);
            new TouchScrollHelper(gvResultsResults);

            //new TouchScrollHelper(

        }



        /// <summary>
        /// Checks if the user entered something acceptable and then populates the page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tbScan_Leave(object sender, EventArgs e)
        {
            string sText = this.teCaseScan.Text;
            if (sText.Length > 1)
            {
                cAcc acc = new cAcc(sText);
                if (acc != null & acc.AccID > 0)
                {
                    Program.Acc = acc;
                    populatePage();
                    //Thread tRegistry = new Thread(setRegistry);
                    // tRegistry.Start();
                    setRegistry();
                    System.Threading.Thread.Sleep(100);
                    SendKeys.Send("^{F12}");
                }
                else
                {
                    MessageBox.Show("'" + sText + "' is not a valid scan.", "Invalid Scan");
                }
                this.teCaseScan.Text = string.Empty;
                this.ActiveControl = this.teCaseScan;
            }

        }

        private void setRegistry()
        {

            //System.Environment.SetEnvironmentVariable("Accession_No", Program.Acc.AccessionNo, EnvironmentVariableTarget.Machine);

            var query = from sl in pdb.acc_slides
                        where sl.acc_id == Program.Acc.AccID
                        select sl;
            string list = string.Join(",", (from l in query select cdb.EncodeBarcode(l.id, "3")).ToArray());
            //  System.Environment.SetEnvironmentVariable("Slide_IDs", list, EnvironmentVariableTarget.Machine);

            ModifyRegistry mr = new ModifyRegistry();
            mr.Write("Accession_No", Program.Acc.AccessionNo);
            mr.Write("Slide_IDs", list);
        }


        private void cHome_TextChanged(object sender, EventArgs e)
        {
            TextEdit te = sender as TextEdit;

            int rowIndex = this.gvPhoneNumbers.FocusedRowHandle;
            string newValue = te.EditValue.ToString();
            int phoneID = Convert.ToInt32(this.gvPhoneNumbers.GetRowCellValue(rowIndex, this.cPhoneID));



            if (phoneID > 0)
            {
                var query = (from p in cdb.Phone_Numbers
                             where p.Phone_Number_ID == phoneID
                             select p).Single();

                cPhoneNumbers cp = Program.PhoneNumbers.Find(x => x.PhoneNumberID == phoneID);

                switch (te.AccessibilityObject.Name)
                {
                    case "rPhoneName":
                        query.Name = newValue;
                        cp.Name = newValue;
                        break;
                    case "rPhoneNote":
                        query.Note = newValue;
                        cp.Note = newValue;
                        break;
                    case "rPhoneWork":
                        query.Work_Phone = newValue;
                        cp.WorkNumber = newValue;
                        break;
                    case "rPhoneMobile":
                        query.Mobile_Phone = newValue;
                        cp.MobileNumber = newValue;
                        break;
                    case "rPhoneHome":
                        query.Home_Phone = newValue;
                        cp.HomeNumber = newValue;
                        break;
                }
                cdb.SubmitChanges();
            }

        }



        void populateOnce()
        {
            // this.cWebsiteSlideRequest.SetURL("http://intra/SS/Lists/Slide%20%20Block%20Requests/NewForm.aspx");
            //  this.cWebsiteSpecimenPull.SetURL("http://intra/histology/Lists/Histology%20Block%20Requests/NewForm.aspx");
            cMethods.GetPhoneNumbers();
            cMethods.GetTemplates();
            cMethods.GetTemplateData();
            cMethods.GetDivisions();

            populatePhoneDivisions();
            searchPhoneNumbers();
            this.cPhoneHome.ColumnEdit.EditValueChanged += cHome_TextChanged;
            this.cPhoneMobile.ColumnEdit.EditValueChanged += cHome_TextChanged;
            this.cPhoneName.ColumnEdit.EditValueChanged += cHome_TextChanged;
            this.cPhoneNote.ColumnEdit.EditValueChanged += cHome_TextChanged;
            this.cPhoneWork.ColumnEdit.EditValueChanged += cHome_TextChanged;
            this.gvPhoneNumbers.ShowingEditor += gvPhoneNumbers_ShowingEditor;
            //Set events for the views/grids
            this.cvCaseDetails.CustomDrawCardCaption += cvCaseDetails_CustomDrawCardCaption;
            this.lvcCaseSlideThumb.MouseDown += lvcCaseSlideThumb_MouseDown;
            this.cCaseSpecimensDescription.ColumnEdit.EditValueChanged += cCaseSpecimensDescription_TextChanged;
            this.gLinks.DataSource = cMethods.GetWebsites();
            ModifyRegistry mr = new ModifyRegistry();
            mr.Write("Accession_No", string.Empty);
            mr.Write("Slide_IDs", string.Empty);

            string theme = mr.Read("App_Skin");
            if (theme == null)
            {
                UserLookAndFeel.Default.SetSkinStyle("Metropolis Dark");

                mr.Write("App_Skin", "Metropolis Dark");
            }
            else
            {
                UserLookAndFeel.Default.SetSkinStyle(theme);
            }

            foreach (SkinContainer cnt in SkinManager.Default.Skins)
            {
                cbSkin.Properties.Items.Add(cnt.SkinName);

                if (cnt.SkinName == mr.Read("App_Skin"))
                    cbSkin.SelectedItem = cnt.SkinName;
            }

            List<cNoteTopic> lTopics = cMethods.getNoteTopics();



            foreach (cNoteTopic note in lTopics)
            {
                ComboboxItem ci = new ComboboxItem();
                ci.Text = note.Description;
                ci.Value = note.NoteTopicID;
                cbNoteTopics.Items.Add(ci);
            }
            Program.lPathologists = cMethods.GetPatholigists();
            foreach (cUser user in Program.lPathologists.Where(x => x.UserTypeID == (int)Enums.UserTypes.Pathologist))
            {
                ComboboxItem ci = new ComboboxItem();
                ci.Text = user.Name;
                ci.Value = user;
                cbNoteUsers.Items.Add(ci);
            }

            ComboboxItem ciSelect = new ComboboxItem();
            ciSelect.Text = "Please Select";
            ciSelect.Value = "0";
            cbNoteUsers.Items.Insert(0, ciSelect);
            cbNoteUsers.SelectedIndex = 0;
            cbNoteTopics.Items.Insert(0, ciSelect);
            cbNoteTopics.SelectedIndex = 0;
        }

        public void PopulateNotes()
        {
            bwNotes.RunWorkerAsync();
        }


        /// <summary>
        /// This is public because it will get updated from frmEditImage
        /// </summary>
        public void PopulateSlideImages()
        {
            Invoke(new MethodInvoker(delegate
            {
                this.gCaseSlideThumb.DataSource = null;
                if (Program.Acc != null)
                    SP.Tools.PopulateGridControl(this.gCaseSlideThumb, "SP_PP_Get_Acc_Images", "@acc_id", Program.Acc.AccID.ToString());
            }));

        }
        /// <summary>
        /// When the user presses the mouse button, this function will check to see if it was on a fieldvalue and if it was in the thumbnail column
        /// (aka on the thumbnail pic). If the user did click on the thumbnail, it launches a new form as a popup window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvcCaseSlideThumb_MouseDown(object sender, MouseEventArgs e)
        {
            LayoutView view = sender as LayoutView;
            LayoutViewHitInfo hitInfo = view.CalcHitInfo(e.Location);
            try
            {
                DXMouseEventArgs.GetMouseArgs(e).Handled = (hitInfo.HitTest == LayoutViewHitTest.FieldValue) && (hitInfo.Column == this.cCaseSlideThumbThumbnail);
                //clicked on the image in layoutviewcolumn1
                if (DXMouseEventArgs.GetMouseArgs(e).Handled)
                {
                    //gets image name
                    string acc_image_id = view.GetRowCellValue(hitInfo.RowHandle, this.cCaseSlideThumbImageID).ToString();
                    frmPopup frm = new frmPopup(acc_image_id);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Assigns the Accession Number to the caption of the customcard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cvCaseDetails_CustomDrawCardCaption(object sender, DevExpress.XtraGrid.Views.Card.CardCaptionCustomDrawEventArgs e)
        {
            e.CardCaption = Program.Acc.AccessionNo;
        }
        /// <summary>
        /// Closes the Application
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            webBrowser1.Visible = false;
            webBrowser3.Visible = false;
            while (webBrowser1.IsBusy)
            {
                Application.DoEvents();
            }
            while (webBrowser3.IsBusy)
            {
                Application.DoEvents();
            }
            webBrowser1.Dispose();
            CoFreeUnusedLibraries();
            webBrowser3.Dispose();
            CoFreeUnusedLibraries();
            //Application.Exit();
            Environment.Exit(0);
        }
        [DllImport("ole32.dll")]
        private static extern void CoFreeUnusedLibraries();

        protected override void OnClosing(CancelEventArgs e)
        {

            base.OnClosing(e);
            cScreenShare1.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            ModifyRegistry mr = new ModifyRegistry();
            mr.Write("Accession_No", string.Empty);
            mr.Write("Slide_IDs", string.Empty);

            if (bwSlides.IsBusy)
                bwSlides.CancelAsync();
            if (bwSpecimens.IsBusy)
                bwSpecimens.CancelAsync();
            if (bwBlocks.IsBusy)
                bwBlocks.CancelAsync();
            if (bwCharges.IsBusy)
                bwBlocks.CancelAsync();
            if (bwICD9.IsBusy)
                bwICD9.CancelAsync();
            if (bwNotes.IsBusy)
                bwNotes.CancelAsync();
            if (bwGrids.IsBusy)
                bwGrids.CancelAsync();

            this.wbTickets.Dispose();
            this.wbMDB.Dispose();

            if (tPicture != null)
            {
                tPicture.Abort();
            }
        }

        /// <summary>
        /// Handles updating the description to what the user just put in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>The firing mode is set to buffered (the user can push enter to fire) or it will wait 5secs after a user is done typing.</remarks>
        private void cCaseSpecimensDescription_TextChanged(object sender, EventArgs e)
        {
            TextEdit descriptionEdit = sender as TextEdit;
            int rowIndex = this.gvCaseSpecimens.FocusedRowHandle;
            string newValue = descriptionEdit.EditValue.ToString();
            string specID = this.gvCaseSpecimens.GetRowCellValue(rowIndex, this.cCaseSpecimensSpecimenID).ToString();

        }

        /// <summary>
        /// Creates a thread for the new picture. Also deletes the temp pic if it exists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bTakePicture_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {

            if (Program.Acc == null)
            {
                MessageBox.Show("No case is loaded.  Please scan a slide before taking a picture.");
            }
            else
            {
                this.bTakePicture.Enabled = false;
                if (System.IO.File.Exists(Program.Root + @"CellNetixApps\pic.jpg"))
                {
                    System.IO.File.Delete(Program.Root + @"CellNetixApps\pic.jpg");
                }
                if (TwainLib.Twain.ScreenBitDepth < 15)
                {
                    MessageBox.Show("Need high/true-color video mode!", "Screen Bit Depth", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    TwainGui.MainFrame mf = new TwainGui.MainFrame();
                }
                catch (ObjectDisposedException)
                {
                }
                tPicture = new Thread(openEditIfImageExists);
                tPicture.Start();
            }
        }
        public void EnablebTakePicture()
        {
            Invoke(new MethodInvoker(delegate
            {
                this.bTakePicture.Enabled = true;
            }));
        }

        /// <summary>
        /// Opens a new frmEditImage form if the file exists.
        /// </summary>
        private void openEditIfImageExists()
        {
            while (!System.IO.File.Exists(Program.Root + @"CellNetixApps\pic.jpg"))
            {
                System.Threading.Thread.Sleep(500);

            }
            Application.Run(new frmEditImage(this));
            tPicture.Join();
        }
        /// <summary>
        /// Sets the theme as Metropolis Dark
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDark_Click(object sender, EventArgs e)
        {
            UserLookAndFeel.Default.SetSkinStyle("Metropolis Dark");
            ModifyRegistry mr = new ModifyRegistry();
            mr.Write("App_Skin", "Metropolis Dark");

        }
        /// <summary>
        /// Sets the theme as Metropolis (light)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bLight_Click(object sender, EventArgs e)
        {
            UserLookAndFeel.Default.SetSkinStyle("Metropolis");
            ModifyRegistry mr = new ModifyRegistry();
            mr.Write("App_Skin", "Metropolis");
        }

        private void bTicket_Click(object sender, EventArgs e)
        {
            frmTicket frm = new frmTicket(14);
            frm.ShowDialog();
        }

        //this is disabled
        private void timerRefresh_Tick(object sender, EventArgs e)
        {

            //this.gQueueAssignedCases.DataSource = tdb.SP_PP_Get_Path_Assigned_Cases(Program.User.PPuserID);
            //this.gQueueOrders.DataSource = tdb.stprc_clntx_pathologist_open_orders(Program.User.PPuserID);
            //if (Program.Acc != null && Program.Acc.AccID > 0)
            //{
            //    this.gResultsResults.DataSource = tdb.SP_PP_Get_Case_Results(Program.Acc.AccID);
            //    cMethods.GetCaseNotes();
            //    this.gNotesNotes.DataSource = Program.CaseNotes;
            //    //update images if there is something new added\
            //    if (Program.Images != null)
            //    {
            //        int startCount = Program.Images.Count;
            //        cMethods.GetImages();
            //        int endCount = Program.Images.Count;
            //        if (startCount != endCount)
            //        {

            //            glCaseImages.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            //            glCaseImages.Gallery.ImageSize = new Size(670, 850);
            //            glCaseImages.Gallery.ShowItemText = true;
            //            glCaseImages.Gallery.Groups.Clear();
            //            glResultsReqImages.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            //            glResultsReqImages.Gallery.ImageSize = new Size(670, 850);
            //            glResultsReqImages.Gallery.ShowItemText = true;
            //            glResultsReqImages.Gallery.Groups.Clear();
            //            //Make groups for the pictures to be in
            //            GalleryItemGroup group1 = new GalleryItemGroup();
            //            group1.Caption = "Req Images";
            //            glCaseImages.Gallery.Groups.Add(group1);
            //            GalleryItemGroup groupReqResults = new GalleryItemGroup();
            //            groupReqResults.Caption = "Req Images";
            //            glResultsReqImages.Gallery.Groups.Add(groupReqResults);
            //            //Populate the galleries
            //            foreach (cImage ci in Program.Images)
            //            {
            //                group1.Items.Add(new GalleryItem(ci.imgImage, ci.Description, ""));
            //                groupReqResults.Items.Add(new GalleryItem(ci.imgImage, ci.Description, ""));
            //            }
            //        }
            //    }
            //}
        }


        private void frmPath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.F12)
            {
                this.ActiveControl = this.teCaseScan;
            }
        }

        private void frmPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                this.tbTabs.SelectedTabPage = this.tbCase;
                this.ActiveControl = this.teCaseScan;

            }

            if (tbTabs.SelectedTabPage.Name == "tbCase")
            {
                if (e.KeyCode == Keys.Left)
                {
                    imgReqCase.SlidePrev();
                }
                if (e.KeyCode == Keys.Right)
                {
                    imgReqCase.SlideNext();

                }
            }
            if (tbTabs.SelectedTabPage.Name == "tpReport")
            {
                if (e.KeyCode == Keys.Left)
                {
                    imgReqResults.SlidePrev();
                }
                if (e.KeyCode == Keys.Right)
                {
                    imgReqResults.SlideNext();

                }
            }
        }

        private void bTemplate_Click(object sender, EventArgs e)
        {
            frmTemplate frm = new frmTemplate();
            frm.ShowDialog();
        }


        private void cbSkin_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxEdit comboBox = sender as ComboBoxEdit;
            string skinName = comboBox.Text;
            UserLookAndFeel.Default.SetSkinStyle(skinName);
            ModifyRegistry mr = new ModifyRegistry();
            mr.Write("App_Skin", skinName);

         
        }

        private void tbRibonControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            Program.cConference = null;
            Program.SlideFileName = string.Empty;
            switch (e.Page.Name)
            {
                case "tbConferences":
                    cConference1.UpdatePage();
                    break;
                case "tbQueue":
                    this.lQueueLastUpdate.Text = "Last Updated: " + DateTime.Now.ToString();
                    this.gQueueAssignedCases.DataSource = null;
                    this.gQueueOrders.DataSource = null;
                    this.gQueueAssignedCases.DataSource = tdb.SP_PP_Get_Path_Assigned_Cases(Program.User.PPuserID);
                    this.gQueueOrders.DataSource = tdb.stprc_clntx_pathologist_open_orders(Program.User.PPuserID);
                    break;
                case "tpReport":
                    if (Program.Acc != null)
                        this.gResultsResults.DataSource = tdb.SP_PP_Get_Case_Results(Program.Acc.AccID);
                    break;
                case "tbCase":
                    this.ActiveControl = this.teCaseScan;
                    break;
                case "tbPhoneNumbersNumbers":
                    this.ActiveControl = this.tbPhoneNumbersNumbers;
                    break;
                case "tpDeliveries":
                    this.gcDeliveries.DataSource = cdb.SP_Get_Pathologist_Deliveries(Program.User.UserID);
                    break;
                case "tbTelepathology":
                    this.cScreenShare1.Load();
                    break;
            }
        }

        private void rLink_Click(object sender, EventArgs e)
        {

            HyperLinkEdit r = (HyperLinkEdit)sender;
            int rowIndex = this.gvLinks.FocusedRowHandle;

            string fullname = this.gvLinks.GetRowCellValue(rowIndex, this.cLinkURL).ToString();
            Process.Start(fullname);

        }



        /// <summary>
        /// Populates all of the objects in each tab and sets the properties needed for it to look nice.
        /// </summary>
        void populatePage()
        {
            EnablebTakePicture();
            if (tPicture != null)
            {
                tPicture.Abort();
            }
            bwSlides.RunWorkerAsync();
            bwSpecimens.RunWorkerAsync();
            bwBlocks.RunWorkerAsync();
            bwCharges.RunWorkerAsync();
            bwICD9.RunWorkerAsync();
            bwNotes.RunWorkerAsync();
            bwSlideImages.RunWorkerAsync();
            bwImages.RunWorkerAsync();
            bwGrids.RunWorkerAsync();
            queueOrdersSortButton.Enabled = true;//for sorting on the queue tab
        }



        private void bwSlides_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Program.Acc != null)
            {
                cMethods.GetCaseSlides();
                SP.PowerPath.GetCtraxDetailsList();
            }
        }

        private void bwSlides_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.gCaseSlides.DataSource = null;

            if (Program.Acc != null)
            {
                this.gCaseSlides.DataSource = Program.Slides;
                this.gvCaseSlides.BestFitColumns();
            }
        }

        private void bwSpecimens_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Program.Acc != null)
            {
                cMethods.GetCaseSpecimens();
            }
        }

        private void bwSpecimens_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.gCaseSpecimens.DataSource = null;
            if (Program.Acc != null)
            {
                this.gCaseSpecimens.DataSource = Program.Specimens;
                this.gvCaseSpecimens.BestFitColumns();
            }
        }

        private void bwBlocks_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Program.Acc != null)
            {
                cMethods.GetCaseBlocks();
            }
        }

        private void bwBlocks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.gCaseBlocks.DataSource = null;
            if (Program.Acc != null)
            {
                this.gCaseBlocks.DataSource = Program.Blocks;
                this.cCaseBlocksBlockName.MaxWidth = this.gCaseBlocks.Width / 2;
                this.gvCaseBlocks.BestFitColumns();
            }
        }

        private void bwCharges_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Program.Acc != null)
            {
                cMethods.GetCaseCharges();
            }
        }

        private void bwCharges_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.gCaseChargeCodes.DataSource = null;
            if (Program.Acc != null)
            {
                this.gCaseChargeCodes.DataSource = Program.CaseCharges;
                this.cCaseChargeCodesDescription.MaxWidth = this.gCaseChargeCodes.Width / 2 + this.gCaseChargeCodes.Width / 4;
                this.gvCaseChargeCodes.BestFitColumns();
            }
        }

        private void bwICD9_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Program.Acc != null)
            {
                cMethods.GetCaseICD9();
            }
        }

        private void bwICD9_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.gCaseICD9.DataSource = null;
            if (Program.Acc != null)
            {
                this.gCaseICD9.DataSource = Program.CaseICD9s;
                this.cCaseICD9Description.MaxWidth = this.gCaseICD9.Width / 2 + this.gCaseICD9.Width / 4;
                this.gvCaseICD9.BestFitColumns();
            }
        }

        private void bwNotes_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Program.Acc != null)
            {
                cMethods.GetCaseNotes();

            }
        }

        private void bwNotes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.gNotesNotes.DataSource = null;
            this.lNotesHeader.Text = "Case Notes";
            if (Program.Acc != null)
            {
                this.gNotesNotes.DataSource = Program.CaseNotes;
                this.lNotesHeader.Text = Program.Acc.AccessionNo + " Case Notes";
                this.cNotesNotesNote.MaxWidth = this.gNotesNotes.Width / 2;
                this.gvNotesNotes.BestFitColumns();
            }

        }

        private void bwSlideImages_DoWork(object sender, DoWorkEventArgs e)
        {

            if (Program.Acc != null)
            {
                cMethods.GetCaseSlideImages();
                PopulateSlideImages();
            }
        }

        private void bwSlideImages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Program.Acc == null)
            {
                this.gCaseSlideThumb.DataSource = null;
            }
        }

        private void bwImages_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Program.Acc != null)
            {
                cMethods.GetImages();
            }
        }

        private void bwImages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

          //  glResultsReqImages.Gallery.Groups.Clear();
            imgReqCase.Images.Clear();
            if (Program.Acc != null && Program.Images != null)
            {

                //glResultsReqImages.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
                //glResultsReqImages.Gallery.ImageSize = new Size(670, 850);
                //glResultsReqImages.Gallery.ShowItemText = true;
                //glResultsReqImages.Gallery.Groups.Clear();
                ////Make groups for the pictures to be in
                //GalleryItemGroup group1 = new GalleryItemGroup();
                //group1.Caption = "Req Images";
                //GalleryItemGroup groupReqResults = new GalleryItemGroup();
                //groupReqResults.Caption = "Req Images";
                //glResultsReqImages.Gallery.Groups.Add(groupReqResults);
                ////Populate the galleries

             
                if (Program.Images == null)
                {
                    this.lReqImage.Text = string.Empty;
                }
                else
                {
                    this.lReqImage.Visible = true;
                    this.lReqImage.Text = Program.Images.Count + " Req Images";
                }

                foreach (cImage ci in Program.Images)
                {
                  //  group1.Items.Add(new GalleryItem(ci.imgImage, ci.Description, ""));
                    // groupReqResults.Items.Add(new GalleryItem(ci.imgImage, ci.Description, ""));
                    imgReqCase.Images.Add(ci.imgImage);
                    imgReqResults.Images.Add(ci.imgImage);
                }
            }
        }

        private void bwGrids_DoWork(object sender, DoWorkEventArgs e)
        {

            Invoke(new MethodInvoker(delegate
            {
                this.gCaseDetails.DataSource = null;
                this.gResultsResults.DataSource = null;
                if (Program.Acc != null)
                {
                    this.gCaseDetails.DataSource = tdb.SP_PP_Get_Case_Details_Portal(Program.Acc.AccID);
                    this.gResultsResults.DataSource = tdb.SP_PP_Get_Case_Results(Program.Acc.AccID);
                }
                this.gQueueAssignedCases.DataSource = tdb.SP_PP_Get_Path_Assigned_Cases(Program.User.PPuserID);
                this.gQueueOrders.DataSource = tdb.stprc_clntx_pathologist_open_orders(Program.User.PPuserID);
                this.gCalendarSchedule.DataSource = cdb.SP_Get_Pathologist_Location_From_Calix_Today(Program.User.UserID);
            }));

        }

        private void bwGrids_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
         //   this.gvResultsResults.BestFitColumns();

            //2/13/13 turning off
            //SendKeys.Send("{F12}");
        }

        //Assigns color to the cells. Rush orders turn red.
        private void gvQueueAssignedCases_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Priority" && e.CellValue.ToString().Contains("RUSH"))
                e.Appearance.BackColor = Color.Red;
        }

        //scrolls to the clicked image. To make this scroll faster set glCaseImages.Gallery.ScrollSpeed
        //private void galleryControlGallery1_ItemClick(object sender, GalleryItemClickEventArgs e)
        //{ glCaseImages.Gallery.ScrollTo(e.Item, true); }




        private void bNotesSave_Click(object sender, EventArgs e)
        {
            string description = this.cbNoteTopics.Text;
            string note = this.tbCaseNote.Text;
            if (Program.Acc == null)
            {
                MessageBox.Show("Please Scan a slide or type Accession No to bring up a case first");
                return;
            }



            if (cbNoteTopics.SelectedIndex > 0)
            {
                pdb.stprc_clntx_path_add_note_logic(Program.Acc.AccID, Program.User.PPuserID, description, note, (char)Enums.Note.Insert, null);
                bwNotes.RunWorkerAsync();
                ComboboxItem ci = (ComboboxItem)cbNoteUsers.SelectedItem;
                if (ci.Value is cUser)
                {
                    cUser user = (cUser)ci.Value;
                    //cdb.SP_Send_Email(user.Email, Program.Acc.AccessionNo + " " + description, note);
                    cMethods.SendEmail(user.Email, Program.Acc.AccessionNo + " " + description, note + "\n\nThis email was sent from the PathPortal.");
                }
                bNotesCancel_Click(null, null);
            }
            else
            {
                MessageBox.Show("Topic Required");
            }





        }

        private void bNotesCancel_Click(object sender, EventArgs e)
        {
            cbNoteUsers.SelectedIndex = 0;
            cbNoteTopics.SelectedIndex = 0;
            tbCaseNote.Text = string.Empty;
        }

        private void bNewCase_Click(object sender, EventArgs e)
        {
            Program.Acc = null;
            populatePage();
            SendKeys.Send("^{F11}");
        }

        private void bQueueAssignedCases_Click(object sender, EventArgs e)
        {
            int rowIndex = this.gvQueueAssignedCases.FocusedRowHandle;
            string acc = this.gvQueueAssignedCases.GetRowCellValue(rowIndex, this.cQueueAssignedCasesACC).ToString();
            cAcc a = new cAcc(acc);
            Program.Acc = a;
            populatePage();
            setRegistry();
            System.Threading.Thread.Sleep(100);
            SendKeys.Send("^{F12}");
        }

        private void bQueueOrders_Click(object sender, EventArgs e)
        {
            int rowIndex = this.gvQueueOrders.FocusedRowHandle;
            string acc = this.gvQueueOrders.GetRowCellValue(rowIndex, this.cQueueOrdersAccessionNo).ToString();
            cAcc a = new cAcc(acc);
            Program.Acc = a;
            populatePage();
            setRegistry();
            System.Threading.Thread.Sleep(100);
            SendKeys.Send("^{F12}");
        }

        #region "Phone"




        private void bAddPhoneNumber_Click(object sender, EventArgs e)
        {
            frmPhone frm = new frmPhone(this);
            frm.ShowDialog();
        }

        private void cbPhoneDivisions_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchPhoneNumbers();
        }


        private void txtNumbers_EditValueChanged(object sender, EventArgs e)
        {
            searchPhoneNumbers();
        }

        public void searchPhoneNumbers()
        {
            this.gcPhoneNumbersPhoneNumbers.DataSource = null;
            string sText = this.tePhoneNumbersSearch.Text.Trim().ToLower();
            List<cPhoneNumbers> al = new List<cPhoneNumbers>();
            ComboboxItem ci = (ComboboxItem)this.cbPhoneDivisions.SelectedItem;
            int divisionID = Convert.ToInt32(ci.Value);
            if (sText.Length == 0)
            {
                if (divisionID == 0)
                {
                    this.gcPhoneNumbersPhoneNumbers.DataSource = Program.PhoneNumbers;
                }
                else
                {
                    this.gcPhoneNumbersPhoneNumbers.DataSource = Program.PhoneNumbers.Where(x => x.DivisionID == divisionID || x.DivisionID == 0);
                }

            }
            else
            {
                if (divisionID == 0)
                {
                    var query = from p in Program.PhoneNumbers
                                .Where(x => x.HomeNumber.Contains(sText) || x.WorkNumber.Contains(sText) || x.MobileNumber.Contains(sText) || x.Name.ToLower().Contains(sText) || x.Note.ToLower().Contains(sText))

                                select p;

                    this.gcPhoneNumbersPhoneNumbers.DataSource = query;
                }
                else
                {
                    var query = from p in Program.PhoneNumbers
                                 .Where(x => x.DivisionID == 0 && x.DivisionID == divisionID && x.HomeNumber.Contains(sText) || x.WorkNumber.Contains(sText) || x.MobileNumber.Contains(sText) || x.Name.ToLower().Contains(sText) || x.Note.ToLower().Contains(sText))

                                select p;

                    this.gcPhoneNumbersPhoneNumbers.DataSource = query;
                }
            }
        }


        private void rPhoneShow_EditValueChanged(object sender, EventArgs e)
        {
            CheckEdit r = (CheckEdit)sender;
            int rowIndex = this.gvPhoneNumbers.FocusedRowHandle;

            int phoneID = Convert.ToInt32(this.gvPhoneNumbers.GetRowCellValue(rowIndex, this.cPhoneID));
            if (phoneID > 0 && !r.Checked)
            {
                //delete
                var query = (from p in cdb.Phone_Numbers
                             where p.Phone_Number_ID == phoneID
                             select p).Single();

                cPhoneNumbers cp = Program.PhoneNumbers.Find(x => x.PhoneNumberID == phoneID);

                cdb.Phone_Numbers.DeleteOnSubmit(query);
                cdb.SubmitChanges();
                Program.PhoneNumbers.Remove(cp);
                searchPhoneNumbers();
            }
        }

        private void rPhoneLink_Click(object sender, EventArgs e)
        {
            int rowIndex = this.gvPhoneNumbers.FocusedRowHandle;
            string email = this.gvPhoneNumbers.GetRowCellValue(rowIndex, this.cPhoneEmail).ToString();
            if (email != "" && email != null)
                Process.Start("mailto: " + email);
        }

        private void populatePhoneDivisions()
        {
            int count = 1;
            int index = 0;
            foreach (Division d in Program.lDivisions)
            {
                ComboboxItem ci = new ComboboxItem();
                ci.Text = d.Description;
                ci.Value = d.Division_ID;
                this.cbPhoneDivisions.Items.Add(ci);
                if (d.Division_ID == Program.User.DivisionID)
                    index = count;

                count++;
            }
            ComboboxItem ciSelect = new ComboboxItem();
            ciSelect.Text = "Show All";
            ciSelect.Value = 0;
            cbPhoneDivisions.Items.Insert(0, ciSelect);
            this.cbPhoneDivisions.SelectedIndex = index;


        }


        void gvPhoneNumbers_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView gv = (GridView)sender;
            int rowIndex = this.gvPhoneNumbers.FocusedRowHandle;
            int phoneID = Convert.ToInt32(this.gvPhoneNumbers.GetRowCellValue(rowIndex, this.cPhoneID));
            if (phoneID == 0)
            {
                switch (gv.FocusedColumn.FieldName)
                {
                    case "Email":
                        break;
                    default:
                        e.Cancel = true;
                        break;
                }
            }
        }

        #endregion

        private void bSidebarTicket_Click(object sender, EventArgs e)
        {
            frmTicket frm = new frmTicket(14);
            frm.ShowDialog();
        }

        private void tbGvNotes_Leave(object sender, EventArgs e)
        {

            int rowIndex = this.gvNotesNotes.FocusedRowHandle;



            //    this.gNotesNotes.DataSource = Program.CaseNotes;
            bool err = updateNote(rowIndex);

            //if (!err)
            //{
            //    if (rowIndex > 0)
            //    {
            //        --rowIndex;
            //        err = updateNote(rowIndex);
            //    }
            //    if (rowIndex +2 < gvNotesNotes.RowCount)
            //    {
            //        err = updateNote(rowIndex+2);
            //    }
            //}

            //err = updateNote(rowIndex + 2);
            if (!err)
            {
                cMethods.GetCaseNotes();
                this.gNotesNotes.DataSource = Program.CaseNotes;
            }
        }

        bool updateNote(int rowIndex)
        {
            int noteID = Convert.ToInt32(this.gvNotesNotes.GetRowCellValue(rowIndex, this.cNotesNotesID));
            string topic = this.gvNotesNotes.GetRowCellValue(rowIndex, this.cNotesNotesTopic).ToString();
            string note = this.gvNotesNotes.GetRowCellValue(rowIndex, this.cNotesNotesNote).ToString();
            cCaseNote oldNote = cMethods.GetCaseNotes(noteID);

            bool err = false;
            if (note.Trim() != oldNote.Note.Trim())
            {
                try
                {
                    pdb.stprc_clntx_path_add_note_logic(Program.Acc.AccID, Program.User.PPuserID, topic, note, (char)Enums.Note.Update, noteID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    err = true;

                }
            }
            return err;
        }


        private void gvNotesNotes_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView gv = (GridView)sender;
            int rowIndex = this.gvNotesNotes.FocusedRowHandle;
            int authorID = Convert.ToInt32(this.gvNotesNotes.GetRowCellValue(rowIndex, this.cNotesNotesAuthorID));
            if (authorID != Program.User.PPuserID)
            {
                e.Cancel = true;
            }
        }
        Enums.Mode deliveries = Enums.Mode.Collappse;
        private void bDeliveriesExpand_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switch (deliveries)
            {
                case Enums.Mode.Expand:
                    gvDeliveries.CollapseAllGroups();
                    this.bDeliveriesExpand.Text = "Expand";
                    deliveries = Enums.Mode.Collappse;
                    break;
                case Enums.Mode.Collappse:
                    gvDeliveries.ExpandAllGroups();
                    this.bDeliveriesExpand.Text = "Collapse";
                    deliveries = Enums.Mode.Expand;
                    break;
            }
   

        }

        private void queueOrdersSortButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Program.Acc != null)
            {
                if (queueOrdersSortButton.Checked)
                {
                    queueOrdersSortButton.Text = "Show All Cases";
                    gvQueueOrders.ActiveFilter.Add(cQueueOrdersAccessionNo, new ColumnFilterInfo("[accession_no] = '" + Program.Acc.AccessionNo + "'"));
                }
                else
                {
                    gvQueueOrders.ActiveFilter.Clear();
                    queueOrdersSortButton.Text = "Show Only Current Case";
                }
            }
        }

    

        //private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        //{
        //    int oldValue = e.OldValue;
        //    int newValue = e.NewValue;
        //    if (newValue > oldValue)
        //    {
        //        imageSlider1.SlideNext();
        //    }
        //    else
        //    {
        //        imageSlider1.SlidePrev();
        //    }
        //    //ScrollEventType s = e.Type;
        //    //switch (e.Type)
        //    //{
        //    //    case ScrollEventType.SmallIncrement:
        //    //    case ScrollEventType.LargeIncrement:
        //    //        imageSlider1.SlideNext();
        //    //        break;
        //    //    case ScrollEventType.SmallDecrement:
        //    //    case ScrollEventType.LargeDecrement:
        //    //        imageSlider1.SlidePrev();
        //    //        break;
        //    //    case ScrollEventType.First:

        //    //        break;
        //    //    case ScrollEventType.Last:
        //    //        break;
        //    //}

        //}

        //public class MyImageSlider : ImageSlider
        //{
        //    protected override bool PrepareNewItem(bool next)
        //    {
        //        if (next && CurrentImageIndex == Images.Count - 1)
        //        {
        //            SetCurrentImage(Images[CurrentImageIndex]);
        //            SetNextImage(Images[0]);
        //            return true;
        //        }
        //        if (!next && CurrentImageIndex == 0)
        //        {
        //            SetCurrentImage(Images[CurrentImageIndex]);
        //            SetNextImage(Images[Images.Count - 1]);
        //            return true;
        //        }
        //        return base.PrepareNewItem(next);
        //    }

        //    protected override bool HasNextItem
        //    {
        //        get { return true; }
        //    }

        //    protected override bool HasPrevItem
        //    {
        //        get { return true; }
        //    }

        //    protected override void OnSlideNext()
        //    {
        //        if (CurrentImageIndex < Images.Count - 1)
        //        {
        //            SetCurrentImageIndex(CurrentImageIndex + 1);
        //        }
        //        else
        //        {
        //            SetCurrentImageIndex(0);
        //        }
        //    }

        //    protected override void OnSlidePrev()
        //    {
        //        if (CurrentImageIndex > 0)
        //        {
        //            SetCurrentImageIndex(CurrentImageIndex - 1);
        //        }
        //        else
        //        {
        //            SetCurrentImageIndex(Images.Count - 1);
        //        }
        //    }

        //    private void SetCurrentImage(Image image)
        //    {
        //        typeof(ImageSlider).GetProperty("CurrentImage").SetValue(this, image, null);
        //    }

        //    private void SetNextImage(Image image)
        //    {
        //        typeof(ImageSlider).GetProperty("NextImage").SetValue(this, image, null);
        //    }

        //    private void SetCurrentImageIndex(int value)
        //    {
        //        typeof(ImageSlider).GetProperty("CurrentImageIndex", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this, value, null);
        //    }

        //}
    }
}