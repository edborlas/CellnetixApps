using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CellNetixApps.Source.Path.Forms
{
    public partial class frmScreen : DevExpress.XtraEditors.XtraForm
    {
        public frmScreen(string connectionString)
        {
            InitializeComponent();
            axRDPViewer1.Connect(connectionString, "User1", "");
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            axRDPViewer1.Disconnect();
        }
    }
}