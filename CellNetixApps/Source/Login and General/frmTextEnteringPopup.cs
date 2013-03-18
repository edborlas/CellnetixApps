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
namespace CellNetixApps.Source.Forms
{
    public partial class frmTextEnteringPopup : DevExpress.XtraEditors.XtraForm
    {
        public String whatTheUserEntered = "";
        private bool singleLineMode;
        private bool caseNumberValidation;
        /// <summary>
        /// A generalized popup window for entering text. Allows you to give the user some instructions and get what their response is via whatTheUserEntered.
        /// </summary>
        /// <param name="instructionsToUser">Header text of instructions</param>
        /// <param name="singleLineText">Whether it's a single line of text. False for multi line</param>
        /// <param name="caseNumber">Whether the input should validate the entry as a case number. If this is set so should single line or it will not work.</param>
        //Notes: I decided to add the case number bool even though it goes against the generalized ideology. Because. I think case number
        //is a frequent issue and this class may be reused later for a case number entry. So it might help.
        public frmTextEnteringPopup(String instructionsToUser, bool singleLineText, bool caseNumber)
        {
            InitializeComponent();
            lInstructions.Text = instructionsToUser;
            meUserEntered.Visible = !singleLineText;
            tbScan.Visible = singleLineText;
            singleLineMode = singleLineText;
            caseNumberValidation = caseNumber;
        }
        /// <summary>Grab the focus for where the user is inputting value. Is in this method because in the constructor it fires too soon and doesn't grab focus.</summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (singleLineMode)
                tbScan.Focus();
            else
                meUserEntered.Focus();
        }
        private void tiButtonsSubmit_ItemClick(object sender, TileItemEventArgs e)
        {
            submit();
        }

        void submit()
        {
            if (caseNumberValidation)
            {//check to make sure it's a valid case
                string sText = this.tbScan.Text;
                this.tbScan.Text = string.Empty;
                if (sText.Length > 1)
                {
                    cAcc acc = new cAcc(sText);
                    Program.Acc = acc;
                    if (Program.Acc.AccID == 0)
                    {
                        frmSimplePopup frm = new frmSimplePopup("Block Doesn't Exist in PowerPath", true);
                        frm.ShowDialog();
                        this.ActiveControl = this.tbScan;
                        return;
                    }
                    whatTheUserEntered = tbScan.Text;
                }
                else
                    this.ActiveControl = this.tbScan;
            }
            else
                whatTheUserEntered = singleLineMode ? tbScan.Text : meUserEntered.Text;
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            cMethods.StopOSK();
        }
        private void tiButtonsKeyboard_ItemClick(object sender, TileItemEventArgs e)
        {
            cMethods.StartOSK();
            if (singleLineMode)
                tbScan.Focus();
            else
                meUserEntered.Focus();
        }
        //catch the enter
        private void tbScan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                tiButtonsSubmit_ItemClick(null, null);
        }
        private void meUserEntered_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                tiButtonsSubmit_ItemClick(null, null);
        }

        private void tbScan_Leave(object sender, EventArgs e)
        {
            submit();
        }
    }
}