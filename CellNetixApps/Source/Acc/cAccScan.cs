using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using CellNetixApps.Source.Classes;
using System.Threading;

namespace CellNetixApps.Source.Acc
{
    public partial class cAccScan : DevExpress.XtraEditors.XtraUserControl, iAcc
    {
        System.Windows.Forms.Timer tLookForImages;
        public cAccScan()
        {
            InitializeComponent();
            tLookForImages = new System.Windows.Forms.Timer();
            tLookForImages.Tick += tLookForImages_Tick;
            tLookForImages.Interval = 1000;
            tLookForImages.Enabled = true;
        }

        void tLookForImages_Tick(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\CellNetixApps\Images\");
            int count = 0;
            foreach (FileInfo fi in di.GetFiles("*.jpg"))
            {
                Image image;
                FileStream myStream = null;
                try
                {
                    myStream = new FileStream(fi.FullName, FileMode.Open);
                    image = Image.FromStream(myStream);
                    Image fullsize = cMethods.GetThumb(image, 1024);
                    Image thumsize = cMethods.GetThumb(image);
                    cImage ci = new cImage();
                    ci.imgImage = image;
                    ci.ImageThubnail = cMethods.ImageToByte(thumsize);
                 //   ci.Image = cMethods.ImageToByte(fullsize);
                    cMethods.Acc.lImages.Add(ci);
                    count++;
                }
                finally
                {
                    myStream.Close();
                    myStream.Dispose();
                }

       
            }
            if (count > 0)
            {
                foreach (FileInfo fis in di.GetFiles("*.*"))
                {

                    if (!cMethods.IsFileLocked(fis.FullName))
                        File.Delete(fis.FullName);
                }
                LoadData();
            }
            //int count = 0;
            //foreach (FileInfo fi in di.GetFiles("*.jpg"))
            //{
            //    string time = cMethods.CurrentTime();
            //    cMethods.SaveThumb(fi.FullName, @"C:\CellNetixApps\Images\Pending\" + time + ".jpg", 1024);
            //    cMethods.SaveThumb(fi.FullName, @"C:\CellNetixApps\Images\Pending\" + time + ".thumb");
            //    if (!cMethods.IsFileLocked(fi.FullName))
            //        File.Delete(fi.FullName);
            //    count++;
            //}
            //if (count > 0)
            //    LoadData();

        }


        public void LoadData()
        {
            this.imageSlider1.Images.Clear();
            foreach (cImage ci in cMethods.Acc.lImages)
            {
                this.imageSlider1.Images.Add(ci.imgImage);
            }
            //DirectoryInfo di = new DirectoryInfo(@"C:\CellNetixApps\Images\Pending\");
            //foreach (FileInfo fi in di.GetFiles("*.jpg"))
            //{
            //    Image image;
            //    FileStream myStream = null;
            //    try
            //    {
            //        myStream = new FileStream(fi.FullName, FileMode.Open);
            //        image = Image.FromStream(myStream);
            //        writeCaseNumber("S12-900500", image);
            //        this.imageSlider1.Images.Add(image);
            //    }
            //    finally
            //    {
            //        myStream.Close();
            //        myStream.Dispose();
            //    }
            //}

            this.lImageCount.Text = imageSlider1.Images.Count + " Req Images";
        }

        void writeCaseNumber(string caseNo, Image img)
        {
            Graphics g = Graphics.FromImage(img);

            char[] AccessionNo = caseNo.ToCharArray();
            int startPoint = 260;
            for (int i = 0; i < AccessionNo.Length; i++)
            {
                startPoint += 25;
                Point pAccession = new Point(10, startPoint);
                g.DrawString(AccessionNo[i].ToString(), new Font("Arial", 15), Brushes.Black, pAccession);
                //  g.Dispose();
            }
            g.Dispose();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            this.imageSlider1.Images.Clear();
            DirectoryInfo di = new DirectoryInfo(@"C:\CellNetixApps\Images\Pending\");
            foreach (FileInfo fi in di.GetFiles("*.*"))
            {
                fi.Delete();
            }
            LoadData();
        }
    }
}
