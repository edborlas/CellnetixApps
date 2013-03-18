using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Lab;

namespace CellNetixApps.Source.Controls
{
    public partial class c10key : DevExpress.XtraEditors.XtraUserControl
    {
        XtraForm frm;
        public c10key(XtraForm frm)
        {
            InitializeComponent();
            this.frm = frm;
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
               // t.ItemClick += t_ItemClick;
                t.ItemPress += t_ItemPress;
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

        void t_ItemPress(object sender, TileItemEventArgs e)
        {
            string tbText = this.tNum.Text;
            int num = Convert.ToInt32(e.Item.Tag);
            if (num > -1)
            {
                tbText += num;
            }
            else
            {
                tbText = string.Empty;
            }
            this.tNum.Text = tbText;
            if (frm is frmWorklist)
            {
                frmWorklist frmWorklist = (frmWorklist)frm;
                frmWorklist.Search(tbText);
            }
        }

        void t_ItemClick(object sender, TileItemEventArgs e)
        {
            string tbText = this.tNum.Text;
            int num = Convert.ToInt32(e.Item.Tag);
            if (num > -1)
            {
                tbText += num;
            }
            else
            {
                tbText = string.Empty;
            }
            this.tNum.Text = tbText;
            if (frm is frmWorklist)
            {
                frmWorklist frmWorklist = (frmWorklist)frm;
                frmWorklist.Search(tbText);
            }
        }

        public int GetValue()
        {
            int value = -1;
            string tbText = this.tNum.Text;
            if (cMethods.isNumeric(tbText))
            {
                value = Convert.ToInt32(tbText);
            }
            return value;
        }

        public void Clear()
        {
            this.tNum.Text = string.Empty;
        }
    }
}
