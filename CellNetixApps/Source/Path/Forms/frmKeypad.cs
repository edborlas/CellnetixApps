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

namespace CellNetixApps.Source.Path.Forms
{
    public partial class frmKeypad : DevExpress.XtraEditors.XtraForm
    {
        cSlide sl;
        TileItem ti;
        public frmKeypad(TileItem ti)
        {
            InitializeComponent();
            this.sl = (cSlide)ti.Tag;
            this.ti = ti;
            this.lAccessionNo.Text = sl.AccessionNo + " " + sl.Label;
        }

 
        private void bSave_Click(object sender, EventArgs e)
        {
            int startlevel = cKeypadStartLevel.GetValue();
            int levels = cKeypadLevels.GetValue();

            sl.StartLevel = startlevel;
            sl.EndLevel = levels;
            PowerPathDataContext db = new PowerPathDataContext();
            ToolsDataContext tdb = new ToolsDataContext();
            db.stprc_clntx_path_add_slides_logic(sl.AccID, sl.BlockID, sl.Code, (byte)startlevel, (byte)levels, sl.SlideID, null, 'U');
            sl.Levels = tdb.fn_clntx_get_level_info(sl.StartLevel, sl.EndLevel);
            cMethods.FormatTileCut(ti, sl);
            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}