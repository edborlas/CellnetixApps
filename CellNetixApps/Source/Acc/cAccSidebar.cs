using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using CellNetixApps.Source.Classes;
namespace CellNetixApps.Source.Acc
{
    public partial class cAccSidebar : DevExpress.XtraEditors.XtraUserControl, iAcc
    {
        public cAccSidebar()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            List<cCase> lcase = new List<cCase>();
            lcase.Add(cMethods.Acc.cCase);
            this.gcHistory.DataSource = lcase;
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            cMethods.Acc.MoveTab((int)Enums.Move.Next, (XtraTabPage)this.Parent.Parent);
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            cMethods.Acc.MoveTab((int)Enums.Move.Back, (XtraTabPage)this.Parent.Parent);
        }


    }
}
