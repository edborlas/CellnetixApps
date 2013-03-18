using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Embed.Forms;
using CellNetixApps.Source.Tickets;

namespace CellNetixApps.Source.Forms
{
    public partial class frmTicketMainMenu : DevExpress.XtraEditors.XtraForm
    {
        //private bool exitApp = true;
        List<cTicketStage> lAllStages = new List<cTicketStage>();
        public frmTicketMainMenu()
        {
            InitializeComponent();
            ColorTiles();
            populateStages();
            Program.LastAction = DateTime.Now;
        }
        private void ColorTiles()
        {
            cMethods.ColorTiles(tcOther, Program.ColorLink);
            cMethods.ColorTiles(tcRecent, Program.ColorLink);
            cMethods.ColorTiles(tcStages, Program.ColorLink);
        }
        private void populateStages()
        {
            lAllStages = cMethods.GetTicketStages();
            for (int i = 0; i < lAllStages.Count; i++)
            {
                TileItem ti = new TileItem();
                ti.IsLarge = true;
                ti.ItemClick += ti_ItemClick;
                ti.Tag = lAllStages[i].stageID;
                ti.Text = lAllStages[i].description;
                tgStages.Items.Add(ti);
            }
        }
        void ti_ItemClick(object sender, TileItemEventArgs e)
        {
            Program.LastAction = DateTime.Now;
            int stageID = (int)e.Item.Tag;
            frmTicket errorSelection = new frmTicket(stageID, e.Item.Text);
            errorSelection.ShowDialog();
        }

        //protected override void OnClosed(EventArgs e)
        //{
        //    base.OnClosed(e);
        //    if (exitApp)
        //        Application.Exit();
        //}

        private void tiOtherLogOff_ItemClick(object sender, TileItemEventArgs e)
        {
            //exitApp = false;
            Program.frmLogin.Initalize(Enums.Mode.Logout);
            Program.frmLogin.Visible = true;
            this.Close();
        }

        private void tiRecentTickets_ItemClick(object sender, TileItemEventArgs e)
        {
            frmRecentTickets recentTicks = new frmRecentTickets();
            recentTicks.ShowDialog();
        }
    }
}