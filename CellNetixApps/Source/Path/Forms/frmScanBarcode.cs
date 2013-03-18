using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Classes;

namespace CellNetixApps.Source.Path.Forms
{
    public partial class frmScanBarcode : DevExpress.XtraEditors.XtraForm
    {
        cAcc acc;
        public frmScanBarcode(string caption = "Scan Slide or Type Accession No")
        {
            InitializeComponent();
        }

        private void tbScan_Leave(object sender, EventArgs e)
        {
            createAcc();
        }

        private void bDone_Click(object sender, EventArgs e)
        {
            createAcc();
        }

        void createAcc()
        {
            string sText = this.tbScan.Text;
            if (sText.Length > 1)
            {
               acc = new cAcc(sText);
                if (acc.AccID > 0)
                {
                
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Not a valid Case");
                }
            }
        }

        public cAcc GetResult()
        {
            return acc;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}