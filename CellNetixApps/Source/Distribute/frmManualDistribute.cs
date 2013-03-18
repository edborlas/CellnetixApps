using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Database;
using System.Linq;
using CellNetixApps.Source.Embed.Forms;
namespace CellNetixApps.Source.Distribute
{
    public partial class frmManualDistribute : DevExpress.XtraEditors.XtraForm
    {
        cTray tray;
        CellappsDataContext db = new CellappsDataContext();
        List<cLocation> lLocations;
        public frmManualDistribute()
        {
            InitializeComponent();

            this.pOpenShipments.Enabled = false;
            lLocations = cMethods.getDestinations();
        
            resetPage();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
        }

        private void tbScan_Leave(object sender, EventArgs e)
        {
            string sText = this.tbScan.Text;
            if (sText.Length > 1)
            {
                this.tbScan.Text = string.Empty;
                cAcc acc = new cAcc(sText); //"S12-064167"
                Program.Acc = acc;

                loadPage();
                this.ActiveControl = this.tbScan;
            }
        }


        private void tiStart_ItemClick(object sender, TileItemEventArgs e)
        {
            this.pOpenShipments.Enabled = true;
            this.ActiveControl = this.tbScan;
            int itemID = db.SP_CreateCIForTray((int)Enums.ItemTypes.Tray, Program.User.Machine.LocationID, Program.User.Machine.MachineID, Program.User.UserID);
            tray = cMethods.Distribute.CreateTray("BT" + itemID, db);
            cLocation l = lLocations.Where(x => x.locationID == 18960).First();
            tray.Desination = l;
            tray.AssignedTo = Program.User;
            cOverride co = new cOverride();
            co.Required = false;
            tray.Override = co;

            this.tiStart.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
            this.tiStart.AppearanceItem.Normal.BackColor2 = Program.ColorToggledOn;
        }

        void ti_ItemClick(object sender, TileItemEventArgs e)
        {
            if (e.Item.Tag is cSlide)
            {
                TileItem ti = e.Item;
                cSlide sl = (cSlide)e.Item.Tag;
                if (!sl.DistributeComplete)
                {
                    db.SP_Insert_Item_Group_Items(sl.ItemID, tray.ItemGroupID, (int)Enums.ItemGroupItemTypes.Child, Program.User.UserID);
                    sl.DistributeComplete = true;
                    ti.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
                    ti.AppearanceItem.Normal.BackColor2 = Program.ColorToggledOn;
                }
                else
                {
                    frmSimplePopup frm = new frmSimplePopup("Already On Shipment", true, "Error");
                    frm.ShowDialog();
                }

            }
            this.ActiveControl = this.tbScan;
        }

        private void tiShipment_ItemClick(object sender, TileItemEventArgs e)
        {
            this.tiShipment.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
            this.tiShipment.AppearanceItem.Normal.BackColor2 = Program.ColorToggledOn;
            int itemID = cMethods.Distribute.CreateShipment(tray, db);
            db.SP_Complete_Shipment_Part_1(itemID, Program.User.UserID, Program.User.Machine.LocationID, Program.User.UserID);
            resetPage();
        }

        void loadPage()
        {
            this.tileGroup2.Items.Clear();
            ToolsDataContext tdb = new ToolsDataContext();
            this.gCaseSlides.DataSource = tdb.SP_PP_Get_Case_Details(Program.Acc.AccID);
            cMethods.GetCaseSlides();
            
       
            SP.PowerPath.GetCtraxDetailsList();
            foreach (cSlide sl in Program.Slides)
            {
                TileItem ti = new TileItem();
                string txt = "<size=20>" + sl.Label + "</size><size=15><color=black>    " + sl.Levels + "</color></size><size=10> " + sl.Code + "</size><br><size=12>" + sl.SpecimenDescription + "</size><br>" +  sl.Instructions;
                ti.Text = txt;
                ti.Tag = sl;
                ti.IsLarge = true;
                ti.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
                ti.AppearanceItem.Normal.BackColor2 = Program.ColorToggledOff;
                ti.AppearanceItem.Normal.BorderColor = Color.Black;
                ti.ItemClick += ti_ItemClick;
                tileGroup2.Items.Add(ti);

            }
        }

        void resetPage()
        {
            this.tileGroup2.Items.Clear();
     
            this.tiShipment.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
            this.tiShipment.AppearanceItem.Normal.BackColor2 = Program.ColorToggledOff;
            this.tiStart.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
            this.tiStart.AppearanceItem.Normal.BackColor2 = Program.ColorToggledOff;
            this.pOpenShipments.Enabled = false;
            this.gCaseSlides.DataSource = null;
        }

    }
}