using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using CellNetixApps.Source.Classes;

namespace CellNetixApps.Source.Acc
{
    public partial class frmAcc : DevExpress.XtraEditors.XtraForm
    {

        public frmAcc()
        {
            InitializeComponent();
            addTabs();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Environment.Exit(0);
        }

        /// <summary>
        /// Adds all the User Controls in Enums.AccControls as tabs to the page
        /// </summary>
        void addTabs()
        {
            XtraTabControl tc = new XtraTabControl();
            tc.Location = new Point(0, 0);
            tc.Dock = DockStyle.Fill;
            tc.SelectedPageChanged += tc_SelectedPageChanged;
            this.Controls.Add(tc);
            cMethods.Acc.AccTabControl = tc;
            cMethods.Acc.lAccTabs = new List<XtraTabPage>();
            var controls = Enum.GetValues(typeof(Enums.AccControls));
            foreach (Enums.AccControls uc in controls)
            {
                XtraTabPage tp = new XtraTabPage();
                tp.Controls.Add(cMethods.Acc.GetAccUserControl(uc));
                tp.Text = uc.ToString();
                tp.Tag = uc;
                tc.TabPages.Add(tp);
                cMethods.Acc.lAccTabs.Add(tp);
            }
        }

        void tc_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            cMethods.Acc.GetAccUserControl((Enums.AccControls)e.Page.Tag);
     
        }


    }
}