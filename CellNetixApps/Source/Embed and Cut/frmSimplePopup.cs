using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CellNetixApps.Source.Embed.Forms
{
    public partial class frmSimplePopup : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// A generic popup window with a message and an OK button.
        /// </summary>
        /// <param name="msgToUser">What to display to the user</param>
        /// <param name="negativeMsg">An optional parameter. When set to true it turns the text of the message to red to let the user know something went wrong.</param>
        public frmSimplePopup(String msgToUser, bool negativeMsg = false, String windowTitle = "")
        {
            InitializeComponent();
            this.lMessage.Text = msgToUser;
            if (negativeMsg)
                this.lMessage.ForeColor = Color.Red;
            this.Text = windowTitle;
        }

        private void bOK_Click(object sender, EventArgs e)
        {this.Close();}
    }
}