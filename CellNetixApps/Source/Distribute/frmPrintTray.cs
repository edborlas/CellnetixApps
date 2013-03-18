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
using System.Threading;

namespace CellNetixApps.Source.Distribute
{
    public partial class frmPrintTray : DevExpress.XtraEditors.XtraForm
    {
        string sText = string.Empty;
        CellappsDataContext db = new CellappsDataContext();
        public frmPrintTray()
        {
            InitializeComponent();
            this.ActiveControl = this.tbScan;
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbScan_Leave(object sender, EventArgs e)
        {

            sText = this.tbScan.Text.ToUpper();
            if (sText.Length == 0)
                return;

            if (sText.Length > 2)
            {
                if (sText.StartsWith("BT"))
                {
                    string id = sText.Replace("BT", "");
                    if (cMethods.isNumeric(id))
                    {

                        Thread t = new Thread(new ThreadStart(printThread));
                        t.Start();
                    }
                    else
                    {
                        MessageBox.Show(sText + " Is not a valid tray");
                    }
                }
                else
                {
                    MessageBox.Show(sText + " Is not a valid tray");
                }
            }
            this.tbScan.Text = string.Empty;
            this.ActiveControl = this.tbScan;
            if (this.cbClose.Checked)
                this.Close();
        }

        private void printThread()
        {
            cTray tray = cMethods.Distribute.CreateTray(sText, db);
            cMethods.NiceLabel.PrintTrayLabel(tray, 1);
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                int itemID = db.SP_CreateCIForTray((int)Enums.ItemTypes.Tray, Program.User.Machine.LocationID, Program.User.Machine.MachineID, Program.User.UserID);
                sText = "BT" + itemID;
                cTray tray = cMethods.Distribute.CreateTray(sText, db);
                cMethods.NiceLabel.PrintTrayLabel(tray, 2);

            }
            if (this.cbClose.Checked)
                this.Close();
        }
    }
}