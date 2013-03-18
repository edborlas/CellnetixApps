using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Classes;

namespace CellNetixApps.Source.Forms
{
    /// <summary>
    /// A general selection popup. The tiles' text displayed to the user will be populated from the List<String> passed to the constructor.
    /// The selection the user makes can be retrieved by accessing the frmMultiSelectionPopup's returnedIndex.
    /// Note: the tiles (populated with the allTileInfo passed) displayed to the user will be sorted into alphabetical order to make sense to the user.
    /// </summary>
    public partial class frmMultiSelectionPopup : DevExpress.XtraEditors.XtraForm
    {
        TileItem selectedTileItem = null;
        public int returnedIndex;
        List<TileItem> lAllTileItems = new List<TileItem>();
        List<String> lAllTileInfo = new List<String>();
        List<String> lCorrectIndecies = new List<string>();
        const int PAGE_SIZE = 20;
        bool closeOnClick;
        /// <summary>
        /// An array of all of the counters used in the ticket error screen. Use the constants instead of hardcoding the indicies.
        /// <para>********************************************************************</para>
        /// <para>********************* Index Naming Schema **********************</para>
        /// <para>********************************************************************</para>
        /// <para>"Current" counters represent what is currently being shown to the user.</para>
        /// <para>"Previous" counters represent what was shown to the user last page</para>
        /// <para>"Next" counters represent what will be shown to the user next page.</para>
        /// <para>"Start" counters represent on which object the page starts on (not zero-based)</para>
        /// <para>"End" counters represent on which object the page ends on (not zero-based)</para>
        /// </summary>
        int[] counters = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
        #region Indices for Counters
        const int MAIN_COUNT = 0;
        const int CURRENT_START_COUNT = 1;
        const int CURRENT_END_COUNT = 2;
        const int PREVIOUS_START_COUNT = 3;
        const int PREVIOUS_END_COUNT = 4;
        const int NEXT_START_COUNT = 5;
        const int NEXT_END_COUNT = 6;
        //NOTE: it is assumed in the getCount function that CURRENT_START_COUNT will precede all the other counts besides MAIN_COUNT.
        #endregion
        /// <param name="allTileInfo">What will be displayed on the tiles presented to the user.</param>
        /// <param name="optionalHeaderText">An optional label to display to the user. It is displayed at the top middle of the form.</param>
        /// <param name="mustSelect">Removes the close button so the user must select something. Only use this with closeOnClick!</param>
        public frmMultiSelectionPopup(List<String> allTileInfo, String optionalHeaderText = "",bool closeOnClick = false, bool mustSelect = false)
        {
            //idea: this could probably be generalized further with a boolean that controls the sidebar's visibility. For things that you know won't have more than one page.
            foreach(String temp in allTileInfo)
                lAllTileInfo.Add(temp);//done to avoid aliasing.
            lCorrectIndecies = allTileInfo;
            InitializeComponent();
            if (optionalHeaderText != "")
            {
                lOptionalHeaderText.Text = optionalHeaderText;
                lOptionalHeaderText.Visible = true;
            }
            for(int i=0; i<tgSelectionItems.Items.Count;i++)
            {
                tgSelectionItems.Items[i].ItemClick += ti_ItemClick;
                tgSelectionItems.Items[i].Tag = i;
                lAllTileItems.Add(tgSelectionItems.Items[i]);
            }
            lAllTileInfo.Sort();//sorts alphabetically
            showTiles();
            this.closeOnClick = closeOnClick;
            if (mustSelect)
                tgSidebar.Items.Remove(tiSideBarClose);
            Program.LastAction = DateTime.Now;
            //Cellapps Coloring
            colorTiles(closeOnClick);
        }

        private void colorTiles(bool clickCloses)
        {
            if (clickCloses)
            {
                foreach (TileItem ti in tgSelectionItems.Items)
                    ti.AppearanceItem.Normal.BackColor = Program.ColorLink;
            }
            else
            {
                foreach (TileItem ti in tgSelectionItems.Items)
                    ti.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
            }
            tiSideBarClose.AppearanceItem.Normal.BackColor = Program.ColorLink;
        }
        private void showTiles()
        {
            tgSelectionItems.Items.Clear();
            cMethods.AddTiles(lAllTileItems, tgSelectionItems);
            FormatTileItems(this.tgSelectionItems, ref counters[MAIN_COUNT]);//not sure if tile group should be ref
            cMethods.SetCountersForMultiPageForms(lAllTileInfo.Count, ref counters, PAGE_SIZE);
            string EndC;
            string StartC;
            //these 3 if statements check to see if the first letter of the first and last item on the page have the same starting letter. If they do it doesn't show a range
            //and instead just says the letter that the user is seeing.
            //if they aren't the same it will give a range e.g., A - G
            if (lAllTileInfo[Math.Abs(counters[CURRENT_START_COUNT] - 1)].Substring(0, 1).Equals(lAllTileInfo[Math.Abs(counters[CURRENT_END_COUNT] - 1)].Substring(0, 1)))
                this.lCount.Text = lAllTileInfo.Count.ToString() + " Items. Viewing " + lAllTileInfo[Math.Abs(counters[CURRENT_START_COUNT] - 1)].Substring(0, 1);
            else
                this.lCount.Text = lAllTileInfo.Count.ToString() + " Items. Viewing " + lAllTileInfo[Math.Abs(counters[CURRENT_START_COUNT] - 1)].Substring(0, 1) + " - " + lAllTileInfo[Math.Abs(counters[CURRENT_END_COUNT] - 1)].Substring(0, 1);
            if (lAllTileInfo[Math.Abs(counters[NEXT_START_COUNT] - 1)].Substring(0, 1).Equals(lAllTileInfo[Math.Abs(counters[NEXT_END_COUNT] - 1)].Substring(0, 1)))
               EndC = "<size=20>Next</size><br><size=12>" + lAllTileInfo[Math.Abs(counters[NEXT_START_COUNT]-1)].Substring(0,1)+"</size>";
            else
               EndC = "<size=20>Next</size><br><size=12>" + lAllTileInfo[Math.Abs(counters[NEXT_START_COUNT]-1)].Substring(0,1) + " - " + lAllTileInfo[Math.Abs(counters[NEXT_END_COUNT]-1)].Substring(0,1) + "</size>";
            if (lAllTileInfo[Math.Abs(counters[PREVIOUS_START_COUNT] - 1)].Substring(0, 1).Equals(lAllTileInfo[Math.Abs(counters[PREVIOUS_END_COUNT] - 1)].Substring(0, 1)))
                StartC = "<size=20>Back</size><br><size=12>" + lAllTileInfo[Math.Abs(counters[PREVIOUS_START_COUNT] - 1)].Substring(0, 1) + "</size>";
            else
                StartC="<size=20>Back</size><br><size=12>" + lAllTileInfo[Math.Abs(counters[PREVIOUS_START_COUNT] - 1)].Substring(0, 1) + " - " + lAllTileInfo[Math.Abs(counters[PREVIOUS_END_COUNT] - 1)].Substring(0, 1) + "</size>";

            string back = "<size=20>Back</size><br><size=12>";
            string next = "<size=20>Next</size><br><size=12>";
            this.tiSideBarBack.Tag = true;
            this.tiSideBarNext.Tag = true;
            this.tiSideBarBack.AppearanceItem.Normal.BackColor = Program.ColorLink;
            this.tiSideBarNext.AppearanceItem.Normal.BackColor = Program.ColorLink;
            cMethods.RemoveEmptyTiles(tgSelectionItems, counters[CURRENT_END_COUNT], PAGE_SIZE);
            if (counters[PREVIOUS_START_COUNT] < 1 || counters[PREVIOUS_START_COUNT] == counters[PREVIOUS_END_COUNT])
            {//if there is no previous page, gray out the button and disable it
                StartC = back;
                this.tiSideBarBack.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
                this.tiSideBarBack.Tag = false;
            }
            if (counters[CURRENT_END_COUNT] == lAllTileInfo.Count)
            {//if there is no next page, gray out the button and disable it
                EndC = next;
                this.tiSideBarNext.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
                this.tiSideBarNext.Tag = false;
            }
            this.tiSideBarNext.Text = EndC;
            this.tiSideBarBack.Text = StartC;
        }
        void removeEmptyTiles(TileGroup tg)
        {
            int lastIndexOnPage = counters[CURRENT_END_COUNT] % PAGE_SIZE;
            if (lastIndexOnPage != 0)//divisible by pagesize so all the tile's have something on them.
            {
                for (int i = PAGE_SIZE - 1; i >= lastIndexOnPage; i--)
                    tg.Items.RemoveAt(i);
            }
        }
        /// <summary>
        /// Sets all the counters in counters[] to what they should be for the current page. filledTileTotal should be the total number of tile items over all pages of the tilegroup.
        /// </summary>
        /// <param name="filledTileTotal"></param>
        void setCounters(int filledTileTotal)
        {
            counters[CURRENT_START_COUNT] = ((counters[MAIN_COUNT] / (PAGE_SIZE + 1)) * (PAGE_SIZE)) + 1;//if showing 1-20, should be 1. if showing 21-40 should be 21 and so forth...
            //example of ^: let pagesize=20, counters[maincount]=24 so currentstartcount should = 21.
            // 24/(20+1) = 1 (int division). 1*20 = 20. 20+1 = 1.
            counters[CURRENT_END_COUNT] = counters[MAIN_COUNT];
            counters[PREVIOUS_START_COUNT] = counters[CURRENT_START_COUNT] - PAGE_SIZE;
            counters[PREVIOUS_END_COUNT] = counters[CURRENT_START_COUNT] - 1;
            counters[NEXT_START_COUNT] = counters[CURRENT_END_COUNT] + 1;
            counters[NEXT_END_COUNT] = counters[CURRENT_END_COUNT] + PAGE_SIZE;
            for (int i = CURRENT_START_COUNT; i < counters.Length; i++)
            {
                if (filledTileTotal == 1)
                    counters[i] = 1;
                else if (counters[i] > filledTileTotal)
                    counters[i] = filledTileTotal;
                else if (counters[i] < 0)
                    counters[i] = 0;
            }
        }

        public void FormatTileItems(TileGroup tg, ref int count)
        {
            foreach (TileItem t in tg.Items)
            {
                if (lAllTileInfo.Count > count)
                {
                    String tileItemText = lAllTileInfo[count];
                    if (tileItemText != null)
                    {
                        t.Text = "<size=18>" + tileItemText + "</size>";
                        count++;
                    }
                }
            }
        }
        void ti_ItemClick(object sender, TileItemEventArgs e)
        {
            //The color changes is only red and blue because if the color should be
            //green when unselected, then once the user clicks it'll go straight away and wont change the color anyway.
            if (selectedTileItem != null)
            {
                selectedTileItem.Checked = false;
                selectedTileItem.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
            }
            if (selectedTileItem != e.Item)
            {
                selectedTileItem = e.Item;
                selectedTileItem.Checked = true;
                selectedTileItem.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
            }
            else
                selectedTileItem = null;//unselectTileItem

            if (closeOnClick)
            {
                close(e);
            }
        }

        private void tiSideBarClose_ItemClick(object sender, TileItemEventArgs e)
        {
            close(e);
        }


        void close(TileItemEventArgs e)
        {
            Program.LastAction = DateTime.Now;
            if (selectedTileItem != null)
            {

                returnedIndex = (counters[CURRENT_START_COUNT] - 1) + (int)selectedTileItem.Tag;//the -1 makes it an index rather than a non-zero based number.
                if (!lCorrectIndecies[returnedIndex].Equals(lAllTileInfo[returnedIndex]))
                    returnedIndex = lCorrectIndecies.IndexOf(lAllTileInfo[returnedIndex]);

            }
            else
                returnedIndex = -1;
            Close();
        }

        private void tiSideBarBack_ItemClick(object sender, TileItemEventArgs e)
        {
            if (e.Item.Tag != null && (bool)e.Item.Tag)
            {
                int tilesOnCurrentPage = counters[MAIN_COUNT] % PAGE_SIZE;
                if (tilesOnCurrentPage == 0)//if multiple of 20
                    tilesOnCurrentPage = PAGE_SIZE;
                //minus 21-40 from main count, this is because count should start at the first index of the page and end at the last index of the page (in showticket functions)
                counters[MAIN_COUNT] -= (PAGE_SIZE + tilesOnCurrentPage);
                if (selectedTileItem != null)
                {
                    selectedTileItem.Checked = false;
                    selectedTileItem = null;//selections end if page is turned.
                }
                showTiles();
            }
        }

        private void tiSideBarNext_ItemClick(object sender, TileItemEventArgs e)
        {
            if (e.Item.Tag != null && (bool)e.Item.Tag)
            {
                if (selectedTileItem != null)
                {
                    selectedTileItem.Checked = false;
                    selectedTileItem = null;
                }
                showTiles();
            }
        }

    }
}