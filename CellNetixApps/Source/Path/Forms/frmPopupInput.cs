using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Distribute;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Database;
using CellNetixApps.Source.Embed.Forms;

namespace CellNetixApps.Source.Path.Forms
{
    public partial class frmPopupInput : DevExpress.XtraEditors.XtraForm
    {
        frmDistribute frmDistribute;
        CellappsDataContext db;
        Enums.Mode mode;
        int traySlot;
        List<cSlide> lSlides;
        public frmPopupInput(frmDistribute frm, CellappsDataContext db, Enums.Mode mode,string message, List<cSlide> lSlides, int traySlot = 0)
        {
            InitializeComponent();
            this.frmDistribute = frm;
            this.db = db;
            this.mode = mode;
            this.traySlot = traySlot;
            this.lMessage.Text = message;
            switch (mode)
            {
                case Enums.Mode.EditTray:
                    this.bCancel.Enabled = false;
                    break;
                case Enums.Mode.EditSlide:
                    this.bCancel.Enabled = true;
                    this.lSlides = lSlides;
                    break;
            }
            this.ActiveControl = this.tbScan;
        }

        private void tbScan_Leave(object sender, EventArgs e)
        {
            string sText = this.tbScan.Text;
            if (sText.Length > 0)
            {
                switch (mode)
                {
                    case Enums.Mode.EditTray:
                        tray(sText);
                        break;
                    case Enums.Mode.EditSlide:
                        slide(sText);
                        break;
                }
            }
        }

        void slide(string sText)
        {
            int encodedValue = cMethods.ConvertAmp(sText);
            cSlide sl = cMethods.Distribute.CreateSlide(encodedValue, db);
            sl.TraySlot = traySlot;
            var query = from currSlides in lSlides
                        where currSlides.SlideID == sl.SlideID
                        select currSlides;
            if (query != null & query.Count() > 0)
            {
                int tmpSlot = query.FirstOrDefault().TraySlot;
                this.tbScan.Text = string.Empty;
                frmSimplePopup frm = new frmSimplePopup("Slide already in tray in slot " + tmpSlot, true);
                frm.ShowDialog();
                this.ActiveControl = this.tbScan;
            }
            else if (sl.ItemID != 0)
            {
                frmDistribute.UpdateSlide(sl);
                this.Close();
            }
            else
            {
                this.Close();
            }
         
        }

        void tray(string sText)
        {
            cTray tray = cMethods.Distribute.CreateTray(sText, db);
            if (tray.ItemID != 0)
            {
                frmDistribute.UpdateTray(tray);
                this.Close();
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}