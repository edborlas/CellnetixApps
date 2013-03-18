using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Database;
namespace CellNetixApps.Source.Controls
{
    public partial class cConsult : DevExpress.XtraEditors.XtraUserControl
    {
        public cConsult()
        {
            InitializeComponent();
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Program.lPathologists = cMethods.GetPatholigists();
            foreach (cUser user in Program.lPathologists.Where(x=>x.UserTypeID == (int)Enums.UserTypes.Pathologist))
            {
                ComboboxItem ci = new ComboboxItem();
                ci.Text = user.Name;
                ci.Value = user;
                cbRequest.Items.Add(ci);
                cbResponse.Items.Add(ci);
                if (Program.User != null)
                {
                    if (user.UserID == Program.User.UserID)
                    {
                        cbRequest.SelectedItem = ci;
                        cbResponse.SelectedItem = ci;
                    }
                }
            }
        }

        private void bRequest_Click(object sender, EventArgs e)
        {
            string description = this.lRequest.Text;
            string note = this.tbRequest.Text;
            ComboboxItem ci = (ComboboxItem)this.cbRequest.SelectedItem;
            cUser user = (cUser)ci.Value;
            savenote(description, note, user);
            this.tbRequest.Text = string.Empty;
        }

        private void bResponse_Click(object sender, EventArgs e)
        {
            string description = this.lResponse.Text;
            string note = this.tbResponse.Text;
            ComboboxItem ci = (ComboboxItem)this.cbRequest.SelectedItem;
            cUser user = (cUser)ci.Value;
            savenote(description, note, user);
            this.tbResponse.Text = string.Empty;
            
        }

        void savenote(string description, string note, cUser user)
        {
            if (Program.Acc == null || Program.Acc.AccID == 0)
            {
                MessageBox.Show("No Case Currently Loaded");
            }
            else
            {
                PowerPathDataContext pdb = new PowerPathDataContext();
                pdb.stprc_clntx_path_add_note_logic(Program.Acc.AccID, user.PPuserID, description, note, (char)Enums.Note.Insert,null);
                if (user.UserID != Program.User.UserID)
                    cMethods.SendEmail(user.Email, description, note + "\n\nThis email was sent from the PathPortal.");

                Program.frmPath.PopulateNotes();
            }
        }
    }
}
