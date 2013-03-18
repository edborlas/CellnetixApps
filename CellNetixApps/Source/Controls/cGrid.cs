using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Classes;

namespace CellNetixApps.Source.Controls
{
    public partial class cGrid : DevExpress.XtraEditors.XtraUserControl
    {
        public cGrid()
        {
            InitializeComponent();

        }

        public void Populate(Enums.FormControls FC, IQueryable<object> query)
        {
            cMethods.FormatGrid(gv, bID, cID, FC);
            this.gc.DataSource = query;
        }

        private void bID_Click(object sender, EventArgs e)
        {
            int rowIndex = this.gv.FocusedRowHandle;
            string id = this.gv.GetRowCellValue(rowIndex, this.cID).ToString();
            MessageBox.Show(id);
        }
    }
}
