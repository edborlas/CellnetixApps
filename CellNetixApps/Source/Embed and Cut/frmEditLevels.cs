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
using CellNetixApps.Source.Database;

namespace CellNetixApps.Source.Embed_and_Cut
{
    public partial class frmEditLevels : DevExpress.XtraEditors.XtraForm
    {
        cSlide sl;
        TileItem ti;
        public frmEditLevels(cSlide sl, TileItem ti)
        {
            InitializeComponent();
            this.sl = sl;
            this.ti = ti;
            this.seStart.EditValue = sl.StartLevel;
            this.seTotal.EditValue = sl.EndLevel;
            this.ActiveControl = this.bCancel;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            PowerPathDataContext pdb = new PowerPathDataContext();

            if (cMethods.isNumeric(seStart.EditValue.ToString()) && cMethods.isNumeric(seTotal.EditValue.ToString()))
            {
                byte bStart = Convert.ToByte(this.seStart.EditValue);
                byte bEnd = Convert.ToByte(this.seTotal.EditValue);
                pdb.stprc_clntx_path_add_slides_logic(sl.AccID, null, null, bStart, bEnd, sl.SlideID, null, 'U');
                sl.StartLevel = Convert.ToInt32(seStart.EditValue);
                sl.EndLevel = Convert.ToInt32(seTotal.EditValue);
                sl.Levels = "L" + sl.StartLevel + "-" + sl.EndLevel;
                cMethods.FormatTileCut(ti, sl);
                this.Close();
            }
            else
            {
                MessageBox.Show("Not a valid level value");
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}