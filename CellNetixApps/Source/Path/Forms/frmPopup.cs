using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using CellNetixApps.Source.Classes;

namespace CellNetixApps.Source.Path.Forms
{
    public partial class frmPopup : DevExpress.XtraEditors.XtraForm
    {
        public frmPopup(string acc_image_id)
        {
            InitializeComponent();
            //get the image to display
            Bitmap bmp = null;
            foreach (cImage i in Program.CaseSlideImages)
            {
                if (i.AccImageID.ToString() == acc_image_id)
                {
                    bmp = i.bmpImage;
                    break;
                }
            }
            if (bmp != null)
                this.pictureBox1.Image = (Image)bmp;
        }
    }
}