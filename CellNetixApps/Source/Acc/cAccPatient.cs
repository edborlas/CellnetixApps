using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using CellNetixApps.Source.Classes;

namespace CellNetixApps.Source.Acc
{
    public partial class cAccPatient : DevExpress.XtraEditors.XtraUserControl, iAcc
    {
        IQueryable<cPatient> Query;
        List<cPatient> lPatients;
        List<TextEdit> lTb = new List<TextEdit>();
        public cAccPatient()
        {
            InitializeComponent();
            Query = cMethods.GetPatients();

            foreach (Control c in this.Controls)
            {
                if (c is TextEdit)
                {
                    lTb.Add((TextEdit)c);
                }
            }

        }

        public void LoadData()
        {
            this.cAccSidebar1.LoadData();
        }


        private void bSearch_Click(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            gcResults.DataSource = cMethods.Search(lTb, Query);
            Application.UseWaitCursor = false;
        }

        private void bName_Click(object sender, EventArgs e)
        {
            int rowIndex = this.gvResults.FocusedRowHandle;
            string id = this.gvResults.GetRowCellValue(rowIndex, this.gcId).ToString();
            MessageBox.Show(id);
        }


    }
}
