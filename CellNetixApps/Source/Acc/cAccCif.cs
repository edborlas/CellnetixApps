using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Classes;
using DevExpress.XtraTab;

namespace CellNetixApps.Source.Acc
{
    public partial class cAccCif : DevExpress.XtraEditors.XtraUserControl , iAcc
    {
        public cAccCif()
        {
            InitializeComponent();
        }

        public void LoadData()
        {

        }

        private void tbScan_Leave(object sender, EventArgs e)
        {
            cMethods.Acc.SearchCIF(this.tbScan.Text);
            cMethods.Acc.MoveTab((int)Enums.Move.Next, (XtraTabPage)this.Parent);
        }




    }
}
