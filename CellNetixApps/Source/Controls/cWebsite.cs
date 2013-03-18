using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CellNetixApps.Source.Controls
{
    public partial class cWebsite : DevExpress.XtraEditors.XtraUserControl
    {
        public cWebsite()
        {
            InitializeComponent();
            this.Browser.ScriptErrorsSuppressed = true;
        }

        public void SetURL(string url)
        {
            Uri u = new Uri(url);
            this.Browser.Url = u;
        }


    }
}
