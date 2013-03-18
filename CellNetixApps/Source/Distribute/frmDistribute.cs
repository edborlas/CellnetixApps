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
using Inlite.ClearImage;
using System.IO;
using CellNetixApps.Source.Database;
using CellNetixApps.Source.Forms;
using CellNetixApps.Source.Path.Forms;
using CellNetixApps.Source.Embed.Forms;
using System.Threading;
using System.Diagnostics;

namespace CellNetixApps.Source.Distribute
{
    public partial class frmDistribute : DevExpress.XtraEditors.XtraForm
    {
        Bitmap trayfullBitmap;
        Bitmap trayBitamp;
        CellappsDataContext db = new CellappsDataContext();
        cTray tray;
        List<cBarcode> lBarcodes;
        List<cSlide> lSlides;
        List<cSlide> lManuallyAddedSlides = new List<cSlide>();
        List<cTime> lTime;
        const string trayJPG = @"C:\Image\tray_image.jpg";
        const string trayJPGCropped = @"C:\Image\tray_image2.jpg";
        CiServer ci;

        Color BackColorComplete = Color.FromArgb(51, 102, 204);
        Color BackColorComplete2 = Color.FromArgb(51, 102, 255);

        Color BackColorPending = Color.FromArgb(104, 0, 0);
        Color BackColorPending2 = Color.FromArgb(120, 0, 0);
        bool library = false;
        #region "Contructor"

        public frmDistribute()
        {
            InitializeComponent();
            //db.CommandTimeout 
            if (Program.Machine.Attributes.Contains((int)Enums.MachineAttribtues.Library))
            {
                library = true;
            }

            Program.lDestinations = cMethods.getDestinations();
            Program.lPathologists = cMethods.GetPatholigists();
            Program.lOverrides = cMethods.GetOverrides();
            Program.frmDistribute = this;
            mapNetworkDrive();
            ReloadForm(false);
            deleteFiles();
        }


        public static void mapNetworkDrive()
        {
            Process.Start("net.exe", @"USE y:   \\cel-web-008\reports /user:cellnetix\uuser zxc1234! /persistent:yes");
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Program.frmLogin.LogOut();
        }

        #endregion

        #region "Background Workers & Timer"

        void timerTrayImage_Tick(object sender, EventArgs e)
        {
            if (this.Visible && !cMethods.IsFileLocked(trayJPG) && File.Exists(trayJPG))
            {
                Application.UseWaitCursor = true;
                if (bwProcessBarcodes.IsBusy != true)
                {

                    bwProcessBarcodes.RunWorkerAsync();
                }
            }
        }
        void bwProcessBarcodes_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }


        void bwProcessBarcodes_DoWork(object sender, DoWorkEventArgs e)
        {
            Graphics g = null;
            Bitmap bmpLocal = null;
            try
            {


                ci = Inlite.ClearImageNet.Server.GetThreadServer();

                ReloadForm(true);
                addTime("Resize Picture");

                trayfullBitmap = new Bitmap(trayJPG);
                Rectangle rec = new Rectangle(850, 1500, 4500, trayfullBitmap.Height - 850);
                bmpLocal = cMethods.Distribute.Copy(trayfullBitmap, rec);
                bmpLocal.Save(trayJPGCropped, System.Drawing.Imaging.ImageFormat.Jpeg);
                trayBitamp = new Bitmap(trayJPGCropped);
                g = Graphics.FromImage(trayBitamp);


                lBarcodes = cMethods.Distribute.ReadBarcodes(trayBitamp, ci);
                addTime("Read Barcodes");
                cMethods.Distribute.FindSlideLocations(lBarcodes);
                lManuallyAddedSlides.Clear();//new picture means they haven't scanned any slides yet.
                lSlides = cMethods.Distribute.CreateAllSlides(lBarcodes, db);
                addTime("Create Slides");
                cMethods.Distribute.DrawSlideRectangles(lSlides, g);
                cMethods.Distribute.WriteSlideText(lSlides, g);//draws the big rects and their texts but doesnt size them
                addTime("Draw Slides");
                tray = cMethods.Distribute.CreateTray(cMethods.Distribute.ReadTrayBarcode(trayfullBitmap, ci), db);


            }
            catch (Exception ex)
            {

                MessageBox.Show("ERROR READING SLIDES. TRY AGAIN OR USE A DIFFERENT TRAY. APPLICATION CLOSING. PRESS F1 to restart " + ex.Message);
                bwProcessBarcodes.CancelAsync();
                Application.Exit();
            }
            finally
            {
                trayfullBitmap.Dispose();
                g.Dispose();
                bmpLocal.Dispose();
                //upload file to database
                if (!cMethods.IsFileLocked(trayJPG))
                {
                    File.Delete(trayJPG);
                }

            }
            Application.UseWaitCursor = false;
            Cursor.Current = Cursors.Arrow;
        }

        void bwProcessBarcodes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.pbTray.Image = trayBitamp;
                this.lTrayName.Text = tray.Name;

                addTime("Check Override Required");

                addTime("Done");
                addTime("Total");
                Thread tSlideCounts = new Thread(slideCounts);
                tSlideCounts.Start();
                if (tray.Name == "Temp Tray")
                {
                    frmPopupInput frm = new frmPopupInput(this, db, Enums.Mode.EditTray, "Scan Tray Barcode", lSlides);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void slideCounts()
        {
            //var queryShip = db.SP_Get_Shipments_Assigned_To_ID(tray.AssignedTo.UserID, Program.User.Machine.LocationID);
            //List<SP_Get_Shipments_Assigned_To_IDResult> lShip = queryShip.ToList();
            //tgOpenShipments.Items.Clear();
            //foreach (SP_Get_Shipments_Assigned_To_IDResult sp in lShip)
            //{
            //    cTray tempTray = tray;
            //    tempTray.ManifestItemID = sp.Item_ID;
            //    TileItem ti = new TileItem();
            //    ti.Tag = tempTray;
            //    ti.Text = sp.Manifest + "<br>C:" + sp.Time + "<br>CB:" + sp.Created_By + "<br>D:" + sp.Destination;
            //    ti.IsLarge = true;
            //    ti.ItemClick += ti_ItemClick;

            //    tgOpenShipments.Items.Add(ti);
            //}


            cMethods.Distribute.SetTrayAssignedTo(lSlides, tray);
            cMethods.Distribute.AddSlidesToTray(lSlides, tray, library);
            List<SP_Get_Slide_Counts_In_TrayResult> lSr = db.SP_Get_Slide_Counts_In_Tray(tray.ItemID).ToList();
            Invoke(new MethodInvoker(delegate
            {
                this.lTrayName.Text += " Slides Found: " + lSlides.Count;
                this.gCase.DataSource = lSr;
                cMethods.Distribute.SetTrayDestAndDetails(tray, gCalendarSchedule, tgProperties, tgOpenShipments, true, db); //here because grids databind needs to be in main thread
                cMethods.Distribute.PopulateActivity(db, tgActivity);
            }));
        }



        #endregion

        #region "Item Clicks"

        void tiButtonsTrayItem_ItemClick(object sender, TileItemEventArgs e)
        {
            frmPrintTray frm = new frmPrintTray();
            frm.ShowDialog();
        }

        void tiButtonsStart_ItemClick(object sender, TileItemEventArgs e)
        {
            tiButtonsStart.AppearanceItem.Normal.BackColor = BackColorComplete;
            tiButtonsStart.AppearanceItem.Normal.BackColor2 = BackColorComplete2;
            SendKeys.Send("{F12}");
            lTime = new List<cTime>();
            addTime("Take Picture");
        }

        void tiPropertiesPathologist_ItemClick(object sender, TileItemEventArgs e)
        {
            if (tray == null) return;

            List<String> pathNames = new List<string>();
            for (int i = 0; i < Program.lPathologists.Count; i++)
            {
                pathNames.Add(Program.lPathologists[i].Name);
            }
            frmMultiSelectionPopup select = new frmMultiSelectionPopup(pathNames, "", true);
            select.ShowDialog();
            int index = select.returnedIndex;
            if (index != -1)
            {
                cUser user = Program.lPathologists[index];
                tiPropertiesPathologist.Tag = user;
                tray.AssignedTo = user;
                tray.Override.Required = true; //change path override always required
                cMethods.Distribute.SetTrayDestAndDetails(tray, gCalendarSchedule, tgProperties, tgOpenShipments, true, db);
            }
        }

        void tiPropertiesOverride_ItemClick(object sender, TileItemEventArgs e)
        {
            if (tray == null) return;

            List<String> overrides = new List<string>();
            for (int i = 0; i < Program.lOverrides.Count; i++)
            {
                overrides.Add(Program.lOverrides[i].Description);
            }
            frmMultiSelectionPopup select = new frmMultiSelectionPopup(overrides, "", true);
            select.ShowDialog();
            int index = select.returnedIndex;
            if (index != -1)
            {
                cOverride co = Program.lOverrides[index];
                tiPropertiesOverride.Tag = co;
                tray.Override = co;
                cMethods.Distribute.SetTrayDestAndDetails(tray, gCalendarSchedule, tgProperties, tgOpenShipments, false, db);
            }

        }

        void tiPropertiesDestination_ItemClick(object sender, TileItemEventArgs e)
        {
            if (tray == null) return;
            List<String> destNames = new List<string>();
            for (int i = 0; i < Program.lDestinations.Count; i++)
            {
                destNames.Add(Program.lDestinations[i].description);
            }
            frmMultiSelectionPopup select = new frmMultiSelectionPopup(destNames, "", true);
            select.ShowDialog();
            int index = select.returnedIndex;
            if (index != -1)
            {
                cLocation l = Program.lDestinations[index];
                tiPropertiesDestination.Tag = l;
                tray.Desination = l;
                tray.Override.Required = true; //change dest override always required
                cMethods.Distribute.SetTrayDestAndDetails(tray, gCalendarSchedule, tgProperties, tgOpenShipments, false, db);

            }
        }

        void tiButtonsSettings_ItemClick(object sender, TileItemEventArgs e)
        {
            cMethods.printerSelectionScreen(Enums.Mode.Distribute);
            this.tiButtonsSettings.Text = "<size=14.25>Printer</size><br><size=7>" + Program.User.Printer.Description + "</size>";
        }

        void tiButtonsBack_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Visible = false;
            Program.frmLogin.Initalize(Enums.Mode.Logout);
            Program.frmLogin.Visible = true;
        }

        void tiButtonsClearTray_ItemClick(object sender, TileItemEventArgs e)
        {
            if (tray != null)
            {
                db.SP_Delete_Slides_From_Tray(tray.ItemGroupID);
                ReloadForm(false);
            }
        }

        void tiButtonsPrint_ItemClick(object sender, TileItemEventArgs e)
        {
            if (tray == null)
                return;


            if (library)
            {
                cLocation cl = Program.lDestinations.Where(l => l.locationID == 1342).First(); //slide library
                cUser cu = Program.lPathologists.Where(p => p.UserID == 401).First(); //librarian

                tray.Desination = cl;
                tray.AssignedTo = cu;
                tiButtonsPrint.AppearanceItem.Normal.BackColor = BackColorComplete;
                tiButtonsPrint.AppearanceItem.Normal.BackColor2 = BackColorComplete2;
                cMethods.Distribute.CreateShipment(tray, db);
                insertManualSlides();



                db.SP_Complete_Shipment_Part_1(tray.ManifestItemID, Program.User.UserID, cl.locationID, Program.Machine.MachineID);
                ReloadForm(false);
            }
            else
            {

                if (tray.Desination == null)
                {
                    frmSimplePopup frm = new frmSimplePopup("No Destination Selected", true);
                    frm.ShowDialog();
                }
                else if (tray.Override.Required == true && tray.Override.Description == null)
                {
                    frmSimplePopup frm = new frmSimplePopup("No Override Reason Selected", true);
                    frm.ShowDialog();
                }
                else
                {
                    tiButtonsPrint.AppearanceItem.Normal.BackColor = BackColorComplete;
                    tiButtonsPrint.AppearanceItem.Normal.BackColor2 = BackColorComplete2;
                    cMethods.Distribute.CreateShipment(tray, db);
                    insertManualSlides();
                    this.tiButtonsPrint.Tag = tray;
                    frmDialog frm = new frmDialog(e.Item);
                    frm.ShowDialog();
                }
            }
        }

        void insertManualSlides()
        {
            foreach (cSlide sl in lSlides)
            {
                bool manual = false;
                foreach (cSlide m in lManuallyAddedSlides)
                {
                    if (m.SlideID == sl.SlideID)
                    {
                        manual = true;
                        break;
                    }
                }
                cMethods.Distribute.LogManuallyAddedSlide(sl, manual, db);
            }
        }
        #endregion

        #region "Mouse Click"

        void pbTray_MouseDown(object sender, MouseEventArgs e)
        {

            if (Program.TraySlots == null)
                return;

            Rectangle rec = new Rectangle(e.X * 4, e.Y * 4, 25, 25); //dont ask about the *4

            //loop through all the tray slots 
            //see if it can find the rectangle that we created with the mouse click
            foreach (cTraySlot slot in Program.TraySlots)
            {
                Rectangle trayRec = slot.Rectangle;
                if (trayRec.Contains(rec))
                {
                    var query = from l in lSlides
                                where l.TraySlot == slot.Slot
                                select l;
                    //if the slot doesnt have a slot in it
                    if (query.Count() == 0)
                    {
                        frmPopupInput frm = new frmPopupInput(this, db, Enums.Mode.EditSlide, "Add Slide in Slot " + slot.Slot, lSlides, slot.Slot);
                        frm.ShowDialog();
                    }
                }
            }

        }

        #endregion

        #region "Methods"

        void addTime(string action)
        {

            Invoke(new MethodInvoker(delegate
            {
                if (lTime == null)
                    lTime = new List<cTime>();
                cMethods.Distribute.AddTime(action, lTime);
                this.gcTime.DataSource = lTime;
                this.gcTime.RefreshDataSource();
            }));
        }

        public void UpdateTray(cTray tray)
        {
            this.tray = tray;
            cMethods.Distribute.AddSlidesToTray(lSlides, tray, library);
            cMethods.Distribute.SetTrayAssignedTo(lSlides, tray);
            this.gCase.DataSource = db.SP_Get_Slide_Counts_In_Tray(tray.ItemID);
            cMethods.Distribute.SetTrayDestAndDetails(tray, gCalendarSchedule, tgProperties, tgOpenShipments, true, db); //here because grids databind needs to be in main thread

        }

        public void UpdateSlide(cSlide sl)
        {
            lSlides.Add(sl);
            lManuallyAddedSlides.Add(sl);
            //lSlides = lSlides.OrderBy(x => x.TraySlot).ToList(); Ordering is taken care of in add slides

            Graphics g = Graphics.FromImage(trayBitamp);


            cMethods.Distribute.DrawSlideRectangles(lSlides, g);
            cMethods.Distribute.WriteSlideText(lSlides, g);//draws the big rects and their texts but doesnt size them

            cMethods.Distribute.AddSlidesToTray(lSlides, tray, library);
            cMethods.Distribute.SetTrayAssignedTo(lSlides, tray);


            g.Dispose();
            this.pbTray.Image = trayBitamp;
            this.gCase.DataSource = db.SP_Get_Slide_Counts_In_Tray(tray.ItemID);
            cMethods.Distribute.SetTrayDestAndDetails(tray, gCalendarSchedule, tgProperties, tgOpenShipments, true, db); //here because grids databind needs to be in main thread

        }

        public void ReloadForm(bool isBackgroundThread)
        {
            if (isBackgroundThread)
            {
                Invoke(new MethodInvoker(delegate
                {
                    reload();
                }));
            }
            else
            {
                reload();
            }

            this.tgOpenShipments.Items.Clear();
            lBarcodes = null;
            lSlides = null;
            lSlides = new List<cSlide>();
            tray = null;
            this.tiButtonsPrint.Tag = null;
            Program.TraySlots = null;

        }

        void reload()
        {
            tiPropertiesPathologist.AppearanceItem.Normal.BackColor = BackColorPending;
            tiPropertiesPathologist.AppearanceItem.Normal.BackColor2 = BackColorPending2;
            tiPropertiesDestination.AppearanceItem.Normal.BackColor = BackColorPending;
            tiPropertiesDestination.AppearanceItem.Normal.BackColor2 = BackColorPending2;
            tiPropertiesOverride.AppearanceItem.Normal.BackColor = BackColorPending;
            tiPropertiesOverride.AppearanceItem.Normal.BackColor2 = BackColorPending2;
            tiButtonsStart.AppearanceItem.Normal.BackColor = BackColorPending;
            tiButtonsStart.AppearanceItem.Normal.BackColor2 = BackColorPending2;
            tiButtonsPrint.AppearanceItem.Normal.BackColor = BackColorPending;
            tiButtonsPrint.AppearanceItem.Normal.BackColor2 = BackColorPending2;


            this.tiButtonsSettings.Text = "<size=24.25>Printer</size><br><size=7>" + Program.User.Printer.Description + "</size>";
            this.tiButtonsBack.Text = "<size=24.25>Log Off</size><br><size=7>" + Program.User.Name + "</size>";
            this.tiPropertiesPathologist.Text = "<size=24>Pathologist</size>";
            this.tiPropertiesDestination.Text = "<size=24>Destination</size>";
            this.tiPropertiesOverride.Text = "<size=24>Override Reason</size>";
            this.lTrayName.Text = string.Empty;
            this.pbTray.Image = null;
            this.gCalendarSchedule.DataSource = null;
            //reset tile items 
            this.gCase.DataSource = null;
            this.gcTime.DataSource = null;
            if (this.trayfullBitmap != null)
                this.trayfullBitmap.Dispose();

            if (this.trayBitamp != null)
                this.trayBitamp.Dispose();

            if (library)
            {
                if (tgProperties.Items.Contains(tiPropertiesPathologist))
                    this.tgProperties.Items.Remove(tiPropertiesPathologist);
                if (tgProperties.Items.Contains(tiPropertiesOverride))
                    this.tgProperties.Items.Remove(tiPropertiesOverride);
                if (tgProperties.Items.Contains(tiPropertiesDestination))
                    this.tgProperties.Items.Remove(tiPropertiesDestination);
                this.pOpenShipments.Visible = false;
                this.pHistory.Visible = false;
                this.gcTime.Visible = false;
            }
        }

        /// <summary>
        /// Delete any images when the page loads
        /// </summary>
        void deleteFiles()
        {
            if (!cMethods.IsFileLocked(trayJPG))
            {
                try
                {
                    if (File.Exists(trayJPG))
                        File.Delete(trayJPG);
                }
                catch (Exception)
                {
                }

            }

            if (!cMethods.IsFileLocked(trayJPGCropped))
            {
                try
                {
                    if (File.Exists(trayJPGCropped))
                        File.Delete(trayJPGCropped);
                }
                catch (Exception)
                {
                }
            }
        }

        #endregion





    }
}