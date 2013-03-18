using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Database;
using CellNetixApps.Source.Classes;

namespace CellNetixApps.Source.Lab
{
    public partial class frmOrderHistory : DevExpress.XtraEditors.XtraForm
    {
        stp_lab_worklistResult order;
        public frmOrderHistory(stp_lab_worklistResult order)
        {
            InitializeComponent();
            this.order = order;
            if (order != null)
            {
                CellappsDataContext db = new CellappsDataContext();
                this.gSlides.DataSource = db.SP_PP_Get_Order_history(order.id);
                this.lAccesionNo.Text = order.accession_no + ' ' + order.source_slide_no;
            }
            else
            {
                this.lAccesionNo.Text = "Type Accession No To Search";
                this.ActiveControl = this.tbScan;
            }
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void tbScan_Leave(object sender, EventArgs e)
        {
            search();
        }

        void search()
        {
            CellappsDataContext db = new CellappsDataContext();
            string sText = this.tbScan.Text;
            if (sText.Length > 1)
            {
                cAcc acc = new cAcc(sText);
                if (acc.AccID > 0)
                {
                    this.gSlides.DataSource = db.SP_PP_Get_Order_history_AccessionNo(acc.AccessionNo);
                }
                else
                {
                    MessageBox.Show("Accession Number Not Found, Or Incorrect Format");
                }
            }
            this.tbScan.Text = string.Empty;
        }
    }
}