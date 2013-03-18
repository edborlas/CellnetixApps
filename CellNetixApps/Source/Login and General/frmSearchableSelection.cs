using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Classes;

namespace CellNetixApps.Source.Login_and_General
{
    public partial class frmSearchableSelection : DevExpress.XtraEditors.XtraForm
    {
        public const int NO_SELECTION_MADE = -1;
        public int clickedIndex;
        protected bool clickExits;
        protected TileItem lastClicked = null;
        List<TileItem> allTiles = new List<TileItem>();

        /// <summary>A generic form for when you want to let the user search through all of the tiles with the keyboard (on screen keyboard provided).</summary>
        /// <param name="mustSelect">This will make the form close as soon as the user clicks (Assumes there is at least one tile)</param>
        public frmSearchableSelection(List<String> allTileInfo, String optionalHeaderText = "", bool mustSelect = true)
        {
            InitializeComponent();
            //colors
            if (mustSelect)
            {
                tiClose.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
                tcSelection.AppearanceItem.Normal.BackColor = Program.ColorLink;
            }
            else
            {//can use close button, so add the click listener
                tiClose.AppearanceItem.Normal.BackColor = Program.ColorLink;
                tiClose.ItemClick += tiClose_ItemClick;
                tcSelection.AppearanceItem.Normal.BackColor = Program.ColorToggledOff; // red means it can be toggled
            }
            tiKeyboard.AppearanceItem.Normal.BackColor = Program.ColorLink;
            //Adds the tiles and assigns the tag as the index!
            for(int i = 0; i < allTileInfo.Count; i++)
            {
                TileItem ti = new TileItem();
                ti.Text = allTileInfo[i];
                ti.Tag = i;
                ti.IsLarge = true;
                ti.ItemClick += ti_ItemClick;
                tgSelection.Items.Add(ti);
                allTiles.Add(ti);
            }
            lOptionalHeaderText.Text = optionalHeaderText;
            clickedIndex = NO_SELECTION_MADE;
            clickExits = mustSelect;
            ActiveControl = teFilter;
        }

        void tiClose_ItemClick(object sender, TileItemEventArgs e)
        { this.Close(); }

        //Note: This is used by this form's children. Be cautious when making changes as they could have cascading effects.
        protected void ti_ItemClick(object sender, TileItemEventArgs e)
        {
            if (clickExits)
            {
                lastClicked = e.Item;
                this.Close();
            }
            else
            {//toggle the check box and the color
                if (lastClicked != null)
                {
                    lastClicked.Checked = false;
                    lastClicked.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
                }
                if (lastClicked == e.Item)
                    lastClicked = null;
                else
                {
                    lastClicked = e.Item;
                    lastClicked.Checked = true;
                    lastClicked.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
                }
            }
        }

        private void tiKeyboard_ItemClick(object sender, TileItemEventArgs e)
        { cMethods.StartOSK(); }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            cMethods.StopOSK();
            if (lastClicked != null)
                clickedIndex = (int)lastClicked.Tag;
        }

        private void teFilter_TextChanged(object sender, EventArgs e)
        {
            String filterBy = teFilter.Text.ToUpper();
            if (filterBy != "")
            {
                tgSelection.Items.Clear();
                foreach (TileItem ti in allTiles)
                {
                    if(ti.Text.ToUpper().Contains(filterBy))
                        tgSelection.Items.Add(ti);
                }
            }
            else if (tgSelection.Items.Count != allTiles.Count)
            {//not sure if this will every be equal... depends on how fast the event fires
                tgSelection.Items.Clear();
                foreach (TileItem ti in allTiles)
                    tgSelection.Items.Add(ti);
            }
        }

        /// <summary> Always has focus </summary>
        private void teFilter_Leave(object sender, EventArgs e)
        { teFilter.Focus(); }

        //this is simply for inheritance reasons. Needed to be able to see the designer...
        protected frmSearchableSelection()
        {
            InitializeComponent();
        }
    }
}