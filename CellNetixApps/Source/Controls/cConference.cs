using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using CellNetixApps.Source.Path.Forms;
using System.Diagnostics;
using CellNetixApps.Source.Classes;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Views.Base;
using CellNetixApps.Source.Database;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;

namespace CellNetixApps.Source.Controls
{
    public partial class cConference : DevExpress.XtraEditors.XtraUserControl
    {
        DirectoryInfo currDirectory;
        string ConferenceDirectory;
        CellappsDataContext db;
        public cConference()
        {
            InitializeComponent();
            db = new CellappsDataContext();
            populateCbConferences(0);
            UpdatePage();
            this.pStep1.Enabled = true;
            this.pStep2.Enabled = false;
            this.pStep3.Enabled = false;

        }

        #region "Step One"

        void cbConferences_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbConferences.SelectedIndex > 0)
            {
                ComboboxItem ci = (ComboboxItem)this.cbConferences.SelectedItem;
                Program.Conference = (Conference)ci.Value;
                ConferenceDirectory = Program.ConferenceFolder + "\\" + Program.Conference.Description;
                currDirectory = new DirectoryInfo(ConferenceDirectory);

                populateGrid();
                this.pStep1.Enabled = true;
                this.pStep2.Enabled = true;
                this.pStep3.Enabled = true;
            }
        }

        void bNewConference_Click(object sender, EventArgs e)
        {
            string name = tbNewConference.Text;
            if (name.Length > 0)
            {
                ConferenceDirectory = Program.ConferenceFolder + "\\" + name;
                Directory.CreateDirectory(ConferenceDirectory);

                Conference c = new Conference();
                c.Description = name;
                c.User_ID = Program.User.UserID;
                c.Active = true;
                db.Conferences.InsertOnSubmit(c);
                db.SubmitChanges();


                populateCbConferences(cbConferences.Items.Count);
            }
            this.tbNewConference.Text = string.Empty;

        }

        void bDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Confirm Deletion", "Delete", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    /*
                    FileInfo[] fi = currDirectory.GetFiles("*.*");

                    foreach (FileInfo f in fi)
                    {
                        f.Delete();
                    }
                    Directory.Delete(ConferenceDirectory);
                     * */
                    var query = from c in db.Conferences
                                where c.Conference_ID == Program.Conference.Conference_ID
                                select c;
                    query.First().Active = false;

                    var query2 = from ci in db.Conference_Images
                                 where ci.Conference_ID == Program.Conference.Conference_ID
                                 select ci;
                    foreach (Conference_Image img in query2)
                    {
                        img.Active = false;
                    }

                    db.SubmitChanges();
                    populateCbConferences(0);
                    populateGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void populateCbConferences(int selectedIndex)
        {
            cbConferences.Items.Clear();
            //DirectoryInfo di = new DirectoryInfo(Program.ConfrenceFolder);
            //foreach (DirectoryInfo d in di.GetDirectories())
            //{
            //    cbConferences.Items.Add(d.Name);
            //}
            //cbConferences.SelectedItem = selectedItem;
            if (Program.User != null)
            {
                var query = from c in db.Conferences
                            where c.User_ID == Program.User.UserID && c.Active == true
                            select c;
                if (query != null)
                {
                    foreach (Conference cf in query)
                    {
                        ComboboxItem ci = new ComboboxItem();
                        ci.Text = cf.Description;
                        ci.Value = cf;
                        this.cbConferences.Items.Add(ci);
                    }

                    ComboboxItem plz = new ComboboxItem();
                    plz.Text = "Please Select";
                    plz.Value = 0;
                    this.cbConferences.Items.Insert(0, plz);
                    this.cbConferences.SelectedIndex = selectedIndex;
                }
            }

        }



        #endregion

        #region "Step Two"

        void bTakePicture_Click(object sender, EventArgs e)
        {
            try
            {
                if (currDirectory != null)
                {
                    if (Program.Acc == null)
                    {
                        frmScanBarcode frm = new frmScanBarcode();
                        frm.ShowDialog();
                        Program.Acc = frm.GetResult();
                        if (Program.Acc == null)
                        {
                            this.lCase.Text = "Current Case: None";
                        }
                        else
                        {
                            this.lCase.Text = "Current Case: " + Program.Acc.AccessionNo;
                        }
                    }
                    if (Program.Acc != null)
                    {
                        takePicture();
                    }
                }
                else
                {
                    MessageBox.Show("Select Conference");
                }
            }
            catch (ObjectDisposedException)
            {
            }
        }

        private void bChangeCase_Click(object sender, EventArgs e)
        {
            this.ActiveControl = this.tbNewConference;
            frmScanBarcode frm = new frmScanBarcode();
            frm.ShowDialog();
            Program.Acc = frm.GetResult();
            if (Program.Acc == null)
            {
                this.lCase.Text = "Current Case: None";
            }
            else
            {
                this.lCase.Text = "Current Case: " + Program.Acc.AccessionNo;
            }
        }
        void takePicture()
        {
            cPatient cp = cMethods.GetPatient();
            string initials = cp.First_name.ToUpper().Substring(0, 1) + cp.Last_name.ToUpper().Substring(0, 1);
            int count = 1;

            FileInfo[] files = currDirectory.GetFiles("*.jpg");

            foreach (FileInfo file in files)
            {
                if (file.Name.StartsWith(initials))
                    count++;
            }

            string countNumbers = count.ToString();
            while (countNumbers.Length < 3)
                countNumbers = "0" + countNumbers;

            string name = initials + "_" + countNumbers + "_" + Program.Acc.AccessionNo + ".jpg";

            Program.SlideFileName = ConferenceDirectory + "\\" + name;
            TwainGui.MainFrame mf = new TwainGui.MainFrame();


        }

        #endregion

        #region "Step Three"

        void bFolder_Click(object sender, EventArgs e)
        {
            Process.Start(ConferenceDirectory);
        }


        void populateGrid()
        {

            if (Program.Conference != null)
            {
                this.gcConference.DataSource = db.SP_Get_Conference_Images(Program.Conference.Conference_ID);
            }
        }

        #endregion

        public void UpdatePage()
        {
            Program.cConference = this;
            Program.SlideFileName = string.Empty;
            populateGrid();

            if (Program.Acc == null)
            {
                this.lCase.Text = "Current Case: None";
            }
            else
            {
                this.lCase.Text = "Current Case: " + Program.Acc.AccessionNo;
            }
        }

        void CreatePowerPoint()
        {
            const int BLANKSPACE = 10;//so the picture doesn't scrunch up
            string strTemplate =
               @"\\cel-fil-001\Software\Custom_Apps\CellNetixApps\PowerPoint\template.pot";

            bool bAssistantOn;

            PowerPoint.Application objApp;
            PowerPoint.Presentations objPresSet;
            PowerPoint._Presentation objPres;
            PowerPoint.Slides objSlides;
            PowerPoint._Slide objSlide;
            PowerPoint.TextRange objTextRng;

            //Create a new presentation based on a template.
            objApp = new PowerPoint.Application();
            objApp.Visible = MsoTriState.msoTrue;
            objPresSet = objApp.Presentations;
            objPres = objPresSet.Open(strTemplate,
                MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
            objSlides = objPres.Slides;

            //Build Slide #1:
            //Add text to the slide, change the font and insert/position a 
            //picture on the first slide.
            if (ConferenceDirectory.Length > 0)
            {

                try
                {
                    var query = from ci in db.Conference_Images
                                where ci.Conference_ID == Program.Conference.Conference_ID
                                select ci;

                    foreach (Conference_Image ce in query)
                    {



                        //  string picFromDB = ConferenceDirectory + @"\picFromDB.jpg";
                        string name = ConferenceDirectory + @"\temp.jpg";
                        if (File.Exists(name))
                            File.Delete(name);
                        objSlide = objSlides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);//a blank slide
                        //Text
                        objSlide.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 0, 0, objPres.PageSetup.SlideWidth, 100);
                        objTextRng = objSlide.Shapes[1].TextFrame.TextRange;
                        objTextRng.Text = ce.Description;
                        objTextRng.Font.Name = "Calibri";
                        objTextRng.Font.Size = 24;
                        int heightOfText = Convert.ToInt32(objTextRng.BoundHeight) + BLANKSPACE;
                        //Picture
                        MemoryStream ms = new MemoryStream(ce.Photo.ToArray());
                        Image i = Bitmap.FromStream(ms);
                        int width = i.Width;
                        int height = i.Height;
                        cMethods.SaveForPowerPoint(i, name, objPres, heightOfText);
                        // Image i = Bitmap.FromFile(name);
                        objSlide.Shapes.AddPicture(name, MsoTriState.msoFalse, MsoTriState.msoTrue,
                           0, heightOfText, width, height);
                        i.Dispose();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            try
            {
                bAssistantOn = objApp.Assistant.On;
                objApp.Assistant.On = false;
                //Reenable Office Assisant, if it was on:
                if (bAssistantOn)
                {
                    objApp.Assistant.On = true;
                    objApp.Assistant.Visible = false;
                }
            }
            catch (Exception)
            {

            }
        }

        void ShowPresentation()
        {
            const int BLANKSPACE = 10;//so the picture doesn't scrunch up
            string strTemplate =
               @"\\cel-fil-001\Software\Custom_Apps\CellNetixApps\PowerPoint\template.pot";

            bool bAssistantOn;

            PowerPoint.Application objApp;
            PowerPoint.Presentations objPresSet;
            PowerPoint._Presentation objPres;
            PowerPoint.Slides objSlides;
            PowerPoint._Slide objSlide;
            PowerPoint.TextRange objTextRng;
            // PowerPoint.Shapes objShapes;
            //  PowerPoint.Shape objShape;
            // PowerPoint.SlideShowWindows objSSWs;
            // PowerPoint.SlideShowTransition objSST;
            // PowerPoint.SlideShowSettings objSSS;
            //PowerPoint.SlideRange objSldRng;


            //Create a new presentation based on a template.
            objApp = new PowerPoint.Application();
            objApp.Visible = MsoTriState.msoTrue;
            objPresSet = objApp.Presentations;
            objPres = objPresSet.Open(strTemplate,
                MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
            objSlides = objPres.Slides;

            //Build Slide #1:
            //Add text to the slide, change the font and insert/position a 
            //picture on the first slide.


            if (ConferenceDirectory.Length > 0)
            {

                try
                {
                    FileInfo[] fi = currDirectory.GetFiles("*.jpg");
                    foreach (FileInfo f in fi)
                    {
                        string picFromDB = ConferenceDirectory + @"\picFromDB.jpg";
                        string name = ConferenceDirectory + @"\temp.jpg";
                        if (File.Exists(name))
                            File.Delete(name);
                        objSlide = objSlides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);//a blank slide
                        //Text
                        objSlide.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 0, 0, objPres.PageSetup.SlideWidth, 100);
                        objTextRng = objSlide.Shapes[1].TextFrame.TextRange;
                        objTextRng.Text = f.Name;
                        objTextRng.Font.Name = "Calibri";
                        objTextRng.Font.Size = 24;
                        int heightOfText = Convert.ToInt32(objTextRng.BoundHeight) + BLANKSPACE;
                        //Picture
                        cMethods.SaveForPowerpoint(f.FullName, name, objPres, heightOfText);
                        Image i = Bitmap.FromFile(name);
                        objSlide.Shapes.AddPicture(name, MsoTriState.msoFalse, MsoTriState.msoTrue,
                            0, heightOfText, i.Width, i.Height);
                        i.Dispose();
                        //500,350
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }




            ////Modify the slide show transition settings for all 3 slides in
            ////the presentation.
            //int[] SlideIdx = new int[3];
            //for (int i = 0; i < 3; i++) SlideIdx[i] = i + 1;
            //objSldRng = objSlides.Range(SlideIdx);
            //objSST = objSldRng.SlideShowTransition;
            //objSST.AdvanceOnTime = MsoTriState.msoTrue;
            //objSST.AdvanceTime = 3;
            //objSST.EntryEffect = PowerPoint.PpEntryEffect.ppEffectBoxOut;

            //Prevent Office Assistant from displaying alert messages:
            try
            {
                bAssistantOn = objApp.Assistant.On;
                objApp.Assistant.On = false;



                ////Run the Slide show from slides 1 thru 3.
                //objSSS = objPres.SlideShowSettings;
                //objSSS.StartingSlide = 1;
                //objSSS.EndingSlide = 3;
                //objSSS.Run();

                //Wait for the slide show to end.
                //objSSWs = objApp.SlideShowWindows;
                //while (objSSWs.Count >= 1) System.Threading.Thread.Sleep(100);

                //Reenable Office Assisant, if it was on:
                if (bAssistantOn)
                {
                    objApp.Assistant.On = true;
                    objApp.Assistant.Visible = false;
                }
            }
            catch (Exception)
            {

            }

            //Close the presentation without saving changes and quit PowerPoint.
            // objPres.Close();
            //  objApp.Quit();
        }

        void bPowerPoint_Click(object sender, EventArgs e)
        {
            CreatePowerPoint();
            // ShowPresentation();
            GC.Collect();
        }

        void rDescription_Leave(object sender, EventArgs e)
        {
            Conference_Image ci = conferenceImage();
            TextEdit te = sender as TextEdit;
            string newValue = te.EditValue.ToString();

            var query = from conf in db.Conference_Images
                        where conf.Conference_Image_ID == ci.Conference_Image_ID
                        select conf;
            query.First().Description = newValue;
            db.SubmitChanges();
            populateGrid();

        }

        void rActive_CheckedChanged(object sender, EventArgs e)
        {
            Conference_Image ci = conferenceImage();
            CheckEdit ce = sender as CheckEdit;
            deactivate(ci);
        }

        void deactivate(Conference_Image ci)
        {

            var query = from conf in db.Conference_Images
                        where conf.Conference_Image_ID == ci.Conference_Image_ID
                        select conf;
            query.First().Active = false;
            db.SubmitChanges();
            populateGrid();
        }


        //void rChangeCase_Click(object sender, EventArgs e)
        //{
        //    Conference_Image ci = conferenceImage();
        //    frmScanBarcode frm = new frmScanBarcode();
        //    frm.ShowDialog();
        //    cAcc acc = frm.GetResult();
        //    var query = from conf in db.Conference_Images
        //                where conf.Conference_Image_ID == ci.Conference_Image_ID
        //                select conf;
        //    query.First().Accession_No = acc.AccessionNo;
        //    db.SubmitChanges();
        //    populateGrid();
        //}

        //void rChangeSlide_Click(object sender, EventArgs e)
        //{
        //    Conference_Image ci = conferenceImage();
        //    frmScanBarcode frm = new frmScanBarcode();
        //    frm.ShowDialog();
        //    cAcc acc = frm.GetResult();
        //    if (acc.currentSlideID > 0)
        //    {
        //        var query = from conf in db.Conference_Images
        //                    where conf.Conference_Image_ID == ci.Conference_Image_ID
        //                    select conf;
        //        query.First().Slide_ID = acc.currentSlideID;
        //        db.SubmitChanges();
        //        populateGrid();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Not a valid slide");
        //    }
        //}

        void rFile_Click(object sender, EventArgs e)
        {
            Conference_Image ci = conferenceImage();
            if (ci != null)
            {
                if (File.Exists(ci.Full_Path))
                {
                    Process.Start(ci.Full_Path);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("File Has Been Deleted in Folder. Unable to preview. Remove from Conference?", "Error", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        deactivate(ci);
                    }
                }

            }
        }

        Conference_Image conferenceImage()
        {
            int rowIndex = this.gvConference.FocusedRowHandle;
            int conferenceImageID = Convert.ToInt32(this.gvConference.GetRowCellValue(rowIndex, this.cConferenceImageID));

            Conference_Image ci = null;
            try
            {
                ci = db.Conference_Images.Where(x => x.Conference_Image_ID == conferenceImageID).First();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return ci;
        }

        void bReconcile_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FileInfo[] fi = currDirectory.GetFiles("*.jpg");

            var query = from ci in db.Conference_Images
                        where ci.Conference_ID == Program.Conference.Conference_ID
                        select ci;

            foreach (FileInfo f in fi)
            {
                bool found = false;
                Bitmap i = (Bitmap)Bitmap.FromFile(f.FullName);

                foreach (Conference_Image img in query)
                {

                    MemoryStream ms2 = new MemoryStream(img.Photo.ToArray());

                    Bitmap i2 = new Bitmap(ms2);

                    if (ImageCompareString(i, i2))
                    {
                        found = true;

                    }
                    //this gives a gdi+ error so i dont want to figure it out

                    //foreach (FileInfo fil in fi)
                    //{
                    //    bool onlyInDB = false;
                    //    if (ImageCompareString(i, i2))
                    //    {
                    //        onlyInDB = true;

                    //    }
                    //    if (onlyInDB)
                    //    {
                    //        Bitmap bmpTemp = (Bitmap)i2.Clone();
                    //        bmpTemp.Save(img.Full_Path);
                    //        bmpTemp.Dispose();
                    //    }
                    //}

                }
                if (!found)
                {
                    Program.SlideFileName = f.FullName;
                    cMethods.InsertConferenceImage(null);
                }
            }

            this.Cursor = Cursors.Arrow;
            populateGrid();
        }

        public static bool ImageCompareString(Bitmap firstImage, Bitmap secondImage)
        {
            MemoryStream ms = new MemoryStream();
            firstImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            String firstBitmap = Convert.ToBase64String(ms.ToArray());
            ms.Position = 0;

            secondImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            String secondBitmap = Convert.ToBase64String(ms.ToArray());

            if (firstBitmap.Equals(secondBitmap))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void bWebsite_Click(object sender, EventArgs e)
        {
            Process.Start("https://conference.cellnetix.com");
        }


        private void gcConference_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void gcConference_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void gcConference_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void bUp_Click(object sender, EventArgs e)
        {
            Conference_Image img = conferenceImage();

            int sort = img.Sort_Order;

            var query = from ci in db.Conference_Images
                        where ci.Conference_ID == Program.Conference.Conference_ID && ci.Active == true
                        select ci;

            if (sort == query.Count()) //already highest
                return;

            foreach (Conference_Image c in query)
            {
                if (c.Sort_Order == sort) //increase the number you are matching
                {
                    c.Sort_Order += 1;
                }
                else if (c.Sort_Order == sort + 1) //decrease the next number
                {
                    c.Sort_Order -= 1;
                }
            }
            db.SubmitChanges();
            populateGrid();

        }

        private void bDown_Click(object sender, EventArgs e)
        {
            Conference_Image img = conferenceImage();

            int sort = img.Sort_Order;

            var query = from ci in db.Conference_Images
                        where ci.Conference_ID == Program.Conference.Conference_ID && ci.Active == true
                        select ci;

            if (sort == 1) //already lowest
                return;

            foreach (Conference_Image c in query)
            {
                if (c.Sort_Order == sort) //increase the number you are matching
                {
                    c.Sort_Order -= 1;
                }
                else if (c.Sort_Order == sort - 1) //decrease the next number
                {
                    c.Sort_Order += 1;
                }
            }
            db.SubmitChanges();
            populateGrid();
        }

        private void gcConference_Leave(object sender, EventArgs e)
        {
            SetFocusedAppearance(false);
        }

        private void gcConference_Enter(object sender, EventArgs e)
        {
            SetFocusedAppearance(true);
        }
        private void SetFocusedAppearance(bool isFocused)
        {
           
            gvConference.OptionsSelection.EnableAppearanceFocusedRow = isFocused;
            gvConference.OptionsSelection.EnableAppearanceFocusedCell = isFocused;
        }
    }
}
