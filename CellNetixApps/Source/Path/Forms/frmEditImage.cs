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
using System.Drawing.Drawing2D;
namespace CellNetixApps.Source.Path.Forms
{
    public partial class frmEditImage : DevExpress.XtraEditors.XtraForm
    {

        private frmPath frmPath;
        CheckBox cbReport;
        public frmEditImage(frmPath frmStartPath)
        {
            InitializeComponent();
            frmPath = frmStartPath;
            pbImage.ImageLocation = Program.imageLocation;
            this.pbImage.MouseDown += new MouseEventHandler(pbImage_MouseDown);
            this.pbImage.MouseMove += new MouseEventHandler(pbImage_MouseMove);
            this.pbImage.Paint += new PaintEventHandler(pbImage_Paint);
            this.pbImage.MouseUp += new MouseEventHandler(pbImage_MouseUp);

            foreach (cSlide slide in Program.Slides)
            {
                string slideName = slide.Label + " " + slide.Description;

                if (Program.Slides.Count == 1)
                {
                    this.clb_Slides.Items.Add(slideName, true);
                    this.tbDescription.Text = slideName;
                }
                else
                {
                    this.clb_Slides.Items.Add(slideName);
                }
            }

            Label l = new Label();
            l.Text = "Include In Report?";
            l.Width = 190;
            l.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 15);
            Point pl = new Point(600, 90);
            l.Location = pl;
            cbReport = new CheckBox();
            Point p = new Point(800, 90);
            cbReport.Location = p;
            this.panel1.Controls.Add(l);
            this.panel1.Controls.Add(cbReport);
        }

        protected override void OnClosed(EventArgs e)
        {
            if (System.IO.File.Exists(Program.imageLocation))
            {
                try
                {
                    System.IO.File.Delete(Program.imageLocation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (System.IO.File.Exists(Program.imageThumbLocation))
            {
                try
                {
                    System.IO.File.Delete(Program.imageThumbLocation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            frmPath.EnablebTakePicture();
            base.OnClosed(e);

        }



        private bool _selecting;
        private Rectangle _selection;

        private void pbImage_MouseDown(object sender, MouseEventArgs e)
        {
            // Starting point of the selection:
            if (e.Button == MouseButtons.Left)
            {
                _selecting = true;
                _selection = new Rectangle(new Point(e.X, e.Y), new Size());
            }
        }

        private void pbImage_MouseMove(object sender, MouseEventArgs e)
        {
            // Update the actual size of the selection:
            if (_selecting)
            {
                _selection.Width = e.X - _selection.X;
                _selection.Height = e.Y - _selection.Y;

                // Redraw the picturebox:
                this.pbImage.Refresh();
            }
        }

        private void pbImage_Paint(object sender, PaintEventArgs e)
        {
            if (_selecting)
            {
                // Draw a rectangle displaying the current selection
                Pen pen = Pens.GreenYellow;
                e.Graphics.DrawRectangle(pen, _selection);
            }
        }

        private void pbImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left &&
                _selecting &&
                _selection.Size != new Size())
            {
                // Create cropped image:
                //   Image img = this.pbImage.Image.Crop(_selection);

                // Fit image to the picturebox:
                this.pbImage.Image = cropImage(Fit(this.pbImage.Image, this.pbImage), _selection);

                _selecting = false;
            }
            else
                _selecting = false;
        }


        private Image Fit(Image image, PictureBox picBox)
        {
            Bitmap bmp = null;
            Graphics g;

            // Scale:
            double scaleY = (double)image.Width / picBox.Width;
            double scaleX = (double)image.Height / picBox.Height;
            double scale = scaleY < scaleX ? scaleX : scaleY;

            // Create new bitmap:
            bmp = new Bitmap(
                (int)((double)image.Width / scale),
                (int)((double)image.Height / scale));

            // Set resolution of the new image:
            bmp.SetResolution(
                image.HorizontalResolution,
                image.VerticalResolution);

            // Create graphics:
            g = Graphics.FromImage(bmp);

            // Set interpolation mode:
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Draw the new image:
            g.DrawImage(
                image,
                new Rectangle(            // Destination
                    0, 0,
                    bmp.Width, bmp.Height),
                new Rectangle(            // Source
                    0, 0,
                    image.Width, image.Height),
                GraphicsUnit.Pixel);

            // Release the resources of the graphics:
            g.Dispose();

            // Release the resources of the origin image:
            image.Dispose();

            return bmp;
        }


        private void bCropTLeft_Click(object sender, EventArgs e)
        {
            this.pbImage.Image = cropImage(Fit(this.pbImage.Image, this.pbImage), new Rectangle(0, 0, (pbImage.Width / 2), (pbImage.Height / 2)));
        }

        private void bCropTRight_Click(object sender, EventArgs e)
        {
            int width = pbImage.Width;
            int height = pbImage.Height;

            int okwidth = (int)(width / 2.1);
            int okheight = (int)(height / 2.1);

            this.pbImage.Image = cropImage(Fit(this.pbImage.Image, this.pbImage), new Rectangle(okheight, 0, okwidth, okheight));
        }

        private void bCropBLeft_Click(object sender, EventArgs e)
        {
            int width = pbImage.Width;
            int height = pbImage.Height;

            int okwidth = (int)(width / 2.1);
            int okheight = (int)(height / 2.1);

            this.pbImage.Image = cropImage(Fit(this.pbImage.Image, this.pbImage), new Rectangle(0, okheight, okwidth, okheight));
        }

        private void bCropBRight_Click(object sender, EventArgs e)
        {

            int width = pbImage.Width;
            int height = pbImage.Height;

            int okwidth = (int)(width / 2.1);
            int okheight = (int)(height / 2.1);

            this.pbImage.Image = cropImage(Fit(this.pbImage.Image, this.pbImage), new Rectangle(okwidth, okheight, okwidth, okheight));
        }

        private void bCenter_Click(object sender, EventArgs e)
        {
            int width = pbImage.Width;
            int height = pbImage.Height;

            int okwidth = (int)(width / 2.1);
            int okheight = (int)(height / 2.1);

            this.pbImage.Image = cropImage(Fit(this.pbImage.Image, this.pbImage), new Rectangle((width / 4), (height / 4), okwidth, okheight));
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Program.imageLocation))
            {
                System.IO.File.Delete(Program.imageLocation);
            }
            this.Close();
        }

        private void bUndo_Click(object sender, EventArgs e)
        {
            pbImage.ImageLocation = Program.imageLocation;
        }

        private Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }

        private void bSave_Click(object sender, EventArgs e)
        {

            cMethods.SaveThumb(Program.imageLocation, Program.imageThumbLocation);
            byte[] fullimage = cMethods.Getpic(Program.imageLocation);
            byte[] thumbimage = cMethods.Getpic(Program.imageThumbLocation);

            string description = this.tbDescription.Text;
            if (description == string.Empty)
            {
                MessageBox.Show("Description Required");
            } 
            else
            {
                //Random r = new Random();
                //int random = r.Next(100, 1000);

                CellappsDataContext db = new CellappsDataContext();

                string countNumbers = (Program.CaseSlideImages.Count +1).ToString();
                while (countNumbers.Length < 3)
                    countNumbers = "0" + countNumbers;

                int caseImageID = db.SP_Insert_Case_Images(Program.Acc.AccessionNo, fullimage, thumbimage, 3, Program.Acc.AccessionNo + "_" + countNumbers, getSlideID());

                db.SP_Insert_Case_Image_log(Program.Acc.AccessionNo, Program.User.UserID, 6, 0, caseImageID);


                char includeInReport = 'N';
                if (cbReport.Checked)
                    includeInReport = 'Y';

                ToolsDataContext tdb = new ToolsDataContext();
                tdb.stprc_clntx_pp_image_insert(0, description, Program.User.PPuserID, includeInReport);
                frmPath.PopulateSlideImages();
                frmPath.EnablebTakePicture();
                this.Close();
            }
        }


        private int getSlideID()
        {
            int slideID = 0;
            foreach (string s in this.clb_Slides.CheckedItems)
            {
                foreach (cSlide slide in Program.Slides)
                {
                    string name = slide.Label + " " + slide.Description;

                    if (name.Trim() == s.Trim())
                    {
                        slideID = slide.SlideID;
                    }

                }
            }
            return slideID;
        }

        private void clb_Slides_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (string s in this.clb_Slides.CheckedItems)
            {
                this.tbDescription.Text = s;
            }
        }







    }




}
