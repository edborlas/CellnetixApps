using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Embed.Forms;
using CellNetixApps.Source.Distribute;
using CellNetixApps.Source.Database;

namespace CellNetixApps.Source.Embed.Forms
{
    public partial class frmDialog : DevExpress.XtraEditors.XtraForm
    {
        TileItem ti;
        public frmDialog(TileItem ti)
        {
            InitializeComponent();
            this.ti = ti;

            if (ti.Tag is cBlock)
            {
                cBlock bl = (cBlock)ti.Tag;
                int userID = Program.User.UserID;
                int emedByID = bl.EmbedByID;

                if (userID != emedByID)
                {
                    this.lMessage.Text = "You did not embed this block\nCannot Undo";
                    this.bYes.Visible = false;
                    this.bNo.Visible = false;
                }
                else
                {
                    this.lMessage.Text = "Undo Block " + bl.BlockName + "?";
                    this.bOK.Visible = false;
                }
            }
            else if (ti.Tag is cSlide)
            {
                cSlide sl = (cSlide)ti.Tag;
                this.lMessage.Text = "Slide " + sl.Label + "has already been printed. Reprint?";
                this.bOK.Visible = false;
            }
            else if (ti.Tag is cTray)
            {
                cTray tray = (cTray)ti.Tag;
                this.lMessage.Text = "Print MA" + tray.ManifestItemID + "?";
                this.bOK.Visible = false;
            }
            else if (ti.Tag is Int32)
            {
                this.lMessage.Text = "Reprint MA" + (int)ti.Tag + "?";
                this.bOK.Visible = false;
            }
        }

        private void bYes_Click(object sender, EventArgs e)
        {
            if (Program.frmCut != null && ti.Tag is cSlide)
            {
                cSlide sl = (cSlide)ti.Tag;
                Program.frmCut.CompleteSlide(sl);
            }
            else if (Program.frmEmbed != null && ti.Tag is cBlock)
            {
                Program.frmEmbed.UndoBlock(ti);
            }
            else if (Program.frmDistribute != null)
            {
                //print
                if (ti.Tag is cTray)
                {
                    cTray tray = (cTray)ti.Tag;
                    string errMsg = null;
                    try
                    {
                        cMethods.NiceLabel.PrintManifestLabel(tray);
                    }
                    catch (Exception ex)
                    {

                        errMsg = ex.Message;
                    }


                    if (errMsg != null)
                    {
                        frmSimplePopup frm = new frmSimplePopup(errMsg, true, "Error Printing");
                        frm.ShowDialog();
                    }
                    Program.frmDistribute.ReloadForm(false);
                }
                else if (ti.Tag is Int32)
                {
                    cMethods.NiceLabel.PrintManifestLabel((int)ti.Tag);
                }


                
            }

            this.Close();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bNo_Click(object sender, EventArgs e)
        {
            if (Program.frmDistribute != null)
            {
                Program.frmDistribute.ReloadForm(false);
            }
            this.Close();
        }


    }
}