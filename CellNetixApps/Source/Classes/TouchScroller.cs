using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Forms;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Database;
using System.Threading;
using IDAutomation.Windows.Forms.DataMatrixBarcode;
using CellNetixApps.Source.Embed_and_Cut;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace CellNetixApps.Source.Classes
{
    /// <summary>
    /// The draw backs to this class are that the columns are not resizable by the user. You must know how much space you want each column to take up.
    /// </summary>
    class TouchScroller
    {
        bool dragging;
        int mouseY;
        Point newScrollPos = new Point(0, 0);
        System.Windows.Forms.Timer timeScroll = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer inertiaTimer = new System.Windows.Forms.Timer();
        XtraScrollableControl table;
        bool okToScroll;
        int inertia;
        const int SCROLL_WAIT = 20;
        const int SCROLL_MAX = 5;
        const int SCROLL_MIN = -5;
        const int EMPTY_SPACE = 30;
        const int SCROLLBAR = 25;
        const int INTERTIA_DECAY = 1;
        /// <summary>Assumes the scroll bar width is 25. All columns should have the same number of elements in them.</summary>
        /// <param name="columnSizePercentage">Do not go over 1. Needs to be in the same order as the columns! This should be in parellel with columns.</param>
        /// <param name="columns">These should be in the order that you want them listed!</param>
        public TouchScroller(XtraScrollableControl scroll,Font font,int numColumns, List<double> columnSizePercentage, params List<string>[] columns)
        {
            timeScroll.Enabled = false;
            timeScroll.Interval = SCROLL_WAIT;
            timeScroll.Tick += new EventHandler(timeScroll_Tick);
            inertiaTimer.Enabled = false;
            inertiaTimer.Interval = SCROLL_WAIT;
            inertiaTimer.Tick += new EventHandler(inertia_Tick);
            table = scroll;
            table.AutoScrollMinSize = new Size(0, table.Height + 1);//Scroll bar will always be shown.
            int rowHeight;
            int tableWidth = table.Width - SCROLLBAR;
            //Cycles through
            for (int i = 0; i < columns[0].Count; i++)
            {
                PanelControl row = new PanelControl();
                //row.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                row.Appearance.BackColor = Color.White;
                rowHeight = 0;
                for (int j = 0; j < numColumns; j++)
                {
                    LabelControl cell = new LabelControl();
                    cell.Text = Environment.NewLine + columns[j][i] + "\n\t";//tacked on because the last line was getting deleted. This creates a line for it to cut off
                    cell.Width = (int)(tableWidth * columnSizePercentage[j]);
                    cell.AutoSizeMode = LabelAutoSizeMode.Vertical;
                    cell.Font = font;
                    row.Controls.Add(cell);
                    cell.Height = cell.CalcBestSize().Height;
                    if (cell.Height > rowHeight)
                        rowHeight = cell.Height;
                    cell.Dock = DockStyle.Right;

                    cell.MouseDown += MouseDown;
                    cell.MouseUp += MouseUp;
                    cell.MouseMove += MouseMove;
                 //   cell.MouseWheel += MouseWheel;
                }
                foreach (LabelControl cellInRow in row.Controls)
                {
                    //needs to be another loop to know what the biggest cell is. Borders look funny if they aren't the same size.
                    cellInRow.AutoSizeMode = LabelAutoSizeMode.None;//can't change height in LabelAutoSizeMode.Vertical
                    cellInRow.Height = rowHeight;
                    cellInRow.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
                    cellInRow.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    cellInRow.Appearance.BackColor = Color.White;
                    cellInRow.Appearance.ForeColor = Color.Black;
                    cellInRow.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                }
                table.Controls.Add(row);
                row.Height = rowHeight + EMPTY_SPACE;
                row.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
                row.Dock = DockStyle.Top;
                row.MouseDown += MouseDown;
                row.MouseUp += MouseUp;
               // row.FireScrollEventOnMouseWheel = true;
               // row.MouseWheel += MouseWheel;
                row.MouseMove += MouseMove;
            }
        }

        #region Scroll Events
        //Just like on a phone, when dragged downward the notes will scroll up!
        //and vice versa.
        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging && okToScroll)
            {
                int difference = e.Y - mouseY;
                mouseY = e.Y;
                if (difference != 0)
                {
                    difference /= 2;
                    //if (difference > SCROLL_MAX)
                    //    difference = SCROLL_MAX;
                    //else if (difference < SCROLL_MIN)
                    //    difference = SCROLL_MIN;
                    newScrollPos.Y = (table.AutoScrollPosition.Y * -1) - difference;
                    table.AutoScrollPosition = newScrollPos;
                    okToScroll = false;
                    inertia = (difference/4) * 3;//capture 75% of the last movement speed
                }
            }
        }

        void timeScroll_Tick(object sender, EventArgs e)
        { okToScroll = true; }

        void inertia_Tick(object sender, EventArgs e)
        {
            newScrollPos.Y = (table.AutoScrollPosition.Y * -1) - inertia;
            table.AutoScrollPosition = newScrollPos;
            inertia -= inertia > 0 ? INTERTIA_DECAY : -INTERTIA_DECAY;
            if (inertia == 0)
            {//will only work if the inertia decay is = 1...
                timeScroll.Enabled = false;
                inertiaTimer.Enabled = false;
            }
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            mouseY = e.Y;
            timeScroll.Enabled = true;
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            inertiaTimer.Enabled = true;
            dragging = false;
        }
        #endregion
    }
}
