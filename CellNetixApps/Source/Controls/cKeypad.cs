using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Classes;

namespace CellNetixApps.Source.Controls
{
    public partial class cKeypad : DevExpress.XtraEditors.XtraUserControl
    {

        public cKeypad()
        {
            InitializeComponent();
          
            foreach (TileItem t in this.tg1.Items)
            {
                t.ItemClick += t_ItemClick;
            }
            foreach (TileItem t in this.tg2.Items)
            {
                t.ItemClick += t_ItemClick;
            }
            foreach (TileItem t in this.tg3.Items)
            {
                t.ItemClick += t_ItemClick;
            }
            foreach (TileItem t in this.tg4.Items)
            {
                t.ItemClick += t_ItemClick;
            }
            foreach (TileItem t in this.tg5.Items)
            {
                t.ItemClick += t_ItemClick;
            }
            //this.ActiveControl = this.tbNumber;
        }

        void t_ItemClick(object sender, TileItemEventArgs e)
        {
            string tbText = this.seStart.EditValue.ToString();
            int num = Convert.ToInt32(e.Item.Tag);
            if (num > -1)
            {
                tbText += num;
            }
            else
            {
                tbText = string.Empty;
            }
            this.seStart.EditValue = tbText;
        }

        public int GetValue()
        {
            int value = -1;
            string tbText = this.seStart.EditValue.ToString();
            if (cMethods.isNumeric(tbText))
            {
                value = Convert.ToInt32(tbText);
            }
            return value;
        }

    }
}
