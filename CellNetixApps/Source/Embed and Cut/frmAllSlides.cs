using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Database;
namespace CellNetixApps.Source.Embed_and_Cut
{
    public partial class frmAllSlides : DevExpress.XtraEditors.XtraForm
    {
        public frmAllSlides()
        {
            InitializeComponent();
            SP.PowerPath.GetAllSlideCtraxDetailsList();
            this.gSlides.DataSource = Program.Slides;
            new TouchScrollHelper(gvSlides);
            this.lAccesionNo.Text = Program.Acc.AccessionNo;
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}