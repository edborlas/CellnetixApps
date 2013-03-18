using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace CellNetixApps.Source.Embed_and_Cut
{
    public partial class frmSearchableAddSlides : CellNetixApps.Source.Login_and_General.frmSearchableSelection
    {
        protected const int NUM_POP_TILES = 2;
        public frmSearchableAddSlides(List<String> allTileInfo) : base(allTileInfo, "Slide Types", false)
        {
            InitializeComponent();
            tcPopularSlides.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
            //Add popular tiles
            int popTilesFound = 0;
            int index = 0;
            while (index < allTileInfo.Count && popTilesFound < NUM_POP_TILES)
            {
                if (allTileInfo[index] == "H&E" || allTileInfo[index] == "UNS")
                {
                    TileItem ti = new TileItem();
                    ti.Text = allTileInfo[index];
                    ti.Tag = index;
                    ti.IsLarge = true;
                    ti.ItemClick += ti_ItemClick;//This uses base's ti_itemClick!
                    tgPopularSlides.Items.Add(ti);
                    ++popTilesFound;
                }
                ++index;
            }
        }


        /// <summary>Only here so the designer doesnt mess up. DO NOT USE </summary>
        protected frmSearchableAddSlides()
        {
            InitializeComponent();
        }
    }
}