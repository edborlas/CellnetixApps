using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Database;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Forms;
using CellNetixApps.Source.Embed.Forms;
using CellNetixApps.Source.Controls;
using System.Threading;
namespace CellNetixApps.Source.Lab
{

    /*
     * stp_lab_worklistResult REFMD_ID = accession no without prefix
     */
    public partial class frmWorklist : DevExpress.XtraEditors.XtraForm
    {
        List<lab_dept_worklist> lWorklist;
        List<stp_lab_worklistResult> Results;
        List<stp_lab_worklistResult> WorkingResults;

        int Lab_FacilityID, Lab_DepartmentID, Lab_WorklistID;
        Enums.Mode CurrentMode;
        Enums.Mode SortMode;
        Enums.Mode FilterMode;
        Enums.Mode SearchMode;
        c10key key;
        Thread PrintThread;

        public frmWorklist()
        {
            InitializeComponent();
            cMethods.GetLabDeptWorklists(ref lWorklist);
            cMethods.ReadRegistryValues(ref Lab_FacilityID, ref Lab_DepartmentID, ref Lab_WorklistID);
            cMethods.printerSelectionScreen(Classes.Enums.Mode.Report, false, false);
            key = new c10key(this);
            key.Location = new Point(5, 47);
            this.pKeypad.Controls.Add(key);
            this.tiLogOff.Text = "<size=14.25>Log Off</size><br><size=7>" + Program.User.Name + "</size>";
            if (Program.User.Printer != null)
            {
                this.tiPrinter.Text = "Printer<br><size=7>" + Program.User.Printer.Description + "</size>";
            }
            else
            {
                cMethods.printerSelectionScreen(Enums.Mode.Cut);
                this.tiPrinter.Text = "Printer<br><size=7>" + Program.User.Printer.Description + "</size>";
            }
            SortMode = Enums.Mode.lab_procedure_description;
            CurrentMode = Enums.Mode.History;
            FilterMode = Enums.Mode.FilterNone;
            SearchMode = Enums.Mode.SearchEverything;
            changeMode(FilterMode);
            changeMode(CurrentMode);
            changeMode(SortMode);
            changeMode(SearchMode);

            getOrders();

            this.tileGroup6.Items.Remove(tiMode);
            this.ActiveControl = this.tbScan;
        }

        void getOrders()
        {
            PowerPathDataContext db = new PowerPathDataContext();
            Results = db.stp_lab_worklist((short)Lab_WorklistID, 'O').ToList();
            IQueryable<stp_lab_worklistResult> test = db.stp_lab_worklist((short)Lab_WorklistID, 'O').AsQueryable();

            WorkingResults = Results.ToList();
            foreach (stp_lab_worklistResult r in WorkingResults)
            {
                if (r.accession_no != null)
                    r.ref_md = r.accession_no.Split('-')[1];
                // r.specimen_sequence = WorkingResults.Count(x => x.acc_id == r.acc_id);
            }

            Search(string.Empty);
            this.tiRefresh.Text = "Refresh\n<size=8>" + DateTime.Now.ToString(@"MM/dd HH:mm:ss tt") + "</size>";
        }

        public void Search(string sText)
        {
            if (sText == string.Empty)
                key.Clear();

            IQueryable<stp_lab_worklistResult> tempQuery = Results.AsQueryable();
            var searchResults = (IQueryable<stp_lab_worklistResult>)cMethods.Search(tempQuery, "ref_md", sText, "status", (char)tiFilter.Tag, SortMode.ToString());

            try
            {
                WorkingResults = searchResults.ToList();
            }
            catch (Exception)
            {
                //no results
                return; 
            }


            tg.Items.Clear();
            tcOrders.ItemSize = 180;

            foreach (stp_lab_worklistResult order in WorkingResults)
            {
                TileItem ti = new TileItem();
                Orders ord = new Orders();
                ord.order = order;
                ord.mode = SortMode;
                ti.Tag = ord;
                cMethods.WriteWorklistTileText(ti, order, SortMode);
                ti.ItemClick += ti_ItemClick;
                tg.Items.Add(ti);
            }
            updateCount();
        }

        void updateCount()
        {
            string worklistName = lWorklist.Where(x => x.id == Lab_WorklistID).Select(x => x.name).First();
            this.lCaseCount.Text = tg.Items.Count + " Results";
            this.lWorklistName.Text = worklistName + " Worklist";
        }

        public void WorklistChanged(int worklistID)
        {
            Lab_WorklistID = worklistID;
            getOrders();
            updateCount();
        }

        void changeMode(Enums.Mode mode)
        {
            switch (mode)
            {
                case Enums.Mode.InProcess:
                    this.tiMode.Text = "Mode\nComplete";
                    this.tiMode.Tag = 'C';
                    CurrentMode = Enums.Mode.Complete;
                    tiMode.BackgroundImage = global::CellNetixApps.Properties.Resources.Complete;
                    break;
                case Enums.Mode.Complete:
                    this.tiMode.Text = "Mode\nNew";
                    this.tiMode.Tag = 'N';
                    CurrentMode = Enums.Mode.New;
                    tiMode.BackgroundImage = global::CellNetixApps.Properties.Resources.New;
                    break;
                case Enums.Mode.New:
                    this.tiMode.Text = "Mode\nPrint";
                    this.tiMode.Tag = 'P';
                    CurrentMode = Enums.Mode.Print;
                    tiMode.BackgroundImage = global::CellNetixApps.Properties.Resources.Printer;
                    break;
                case Enums.Mode.Print:
                    this.tiMode.Text = "Mode\nHistory";
                    this.tiMode.Tag = 'H';
                    CurrentMode = Enums.Mode.History;
                    tiMode.BackgroundImage = global::CellNetixApps.Properties.Resources.search;
                    break;
                case Enums.Mode.History:
                    this.tiMode.Text = "Mode\nIn Process";
                    this.tiMode.Tag = 'I';
                    CurrentMode = Enums.Mode.InProcess;
                    tiMode.BackgroundImage = global::CellNetixApps.Properties.Resources.working;
                    break;
                case Enums.Mode.accession_no:
                    this.tiSort.Text = "Sorted By\nDate";
                    SortMode = Enums.Mode.ordered_date;
                    break;
                case Enums.Mode.ordered_date:
                    this.tiSort.Text = "Sorted By\nProcedure";
                    SortMode = Enums.Mode.lab_procedure_description;
                    break;
                case Enums.Mode.lab_procedure_description:
                    this.tiSort.Text = "Sorted By\nCase No";
                    SortMode = Enums.Mode.accession_no;
                    break;
                case Enums.Mode.FilterNew:
                    this.tiFilter.Text = "Filtered By\nIn Process";
                    this.tiFilter.Tag = 'I';
                    FilterMode = Enums.Mode.FilterInProcess;
                    break;
                case Enums.Mode.FilterInProcess:
                    this.tiFilter.Text = "Filtered By\nAll";
                    this.tiFilter.Tag = 'O';
                    FilterMode = Enums.Mode.FilterNone;
                    break;
                case Enums.Mode.FilterNone:
                    this.tiFilter.Text = "Filtered By\nOrdered";
                    this.tiFilter.Tag = 'N';
                    FilterMode = Enums.Mode.FilterNew;
                    break;
            }
            updateCount();
        }

        void ti_ItemClick(object sender, TileItemEventArgs e)
        {
            Orders ord = (Orders)e.Item.Tag;
            stp_lab_worklistResult order = ord.order;

            TileItem ti = e.Item;

            if (ti.Checked)
            {
                ti.Checked = false;
            }
            else
            {
                ti.Checked = true;
                switch (order.status)
                {
                    case 'N':
                        order.status = 'I';
                        break;
                    case 'I':
                        order.status = 'C';
                        break;
                    case 'C':
                        order.status = 'N';
                        break;
                }
                cMethods.WriteWorklistTileText(e.Item, order, Enums.Mode.lab_procedure_description);
                cMethods.InsertAccessionLog(order, this.lWorklistName.Text);
                ToolsDataContext tdb = new ToolsDataContext();
                tdb.stprc_clntx_set_acc_order_status_web(order.id, order.status, Program.User.PPuserID);
            }
            updateCount();
        }

        #region "Sidebar"

        void tbScan_Leave(object sender, EventArgs e)
        {
            string sText = this.tbScan.Text;
            if (sText.Length > 0)
            {
                cAcc acc = new cAcc(sText);
                if (acc.AccID > 0)
                {
                    Search(acc.AccessionNo.Split('-')[1]);
                }
            }
            this.tbScan.Text = string.Empty;
            this.ActiveControl = this.tbScan;
        }

        void tiMode_ItemClick(object sender, TileItemEventArgs e)
        {
            changeMode(CurrentMode);
        }

        void tiSort_ItemClick(object sender, TileItemEventArgs e)
        {
            changeMode(SortMode);
            Search(string.Empty);
        }

        private void tiPrintWorklist_ItemClick(object sender, TileItemEventArgs e)
        {
            PrintThread = new Thread(print);
            PrintThread.Start();

        }

        private void print(object obj)
        {
            string numbers = string.Empty;

            int count = 0;
            List<string> lIds = new List<string>();
            foreach (TileItem ti in tg.Items)
            {
                if (ti.Checked)
                {
                    ++count;
                    lIds.Add(((Orders)ti.Tag).order.id.ToString());
                }
            }
            if (count > 0)
            {
                numbers = string.Join(",", lIds.ToArray());
            }
            else
            {
                numbers = string.Join(",", WorkingResults.Select(x => x.id).ToArray());
            }



            CrystalReport cr = new Classes.CrystalReport("Worklist", "1", numbers, Program.User.Name, this.lWorklistName.Text, null);
            string errMsg = cr.PrintToCustomPrinter(Program.User.Printer.UNC);
            if (errMsg != null)
            {
                MessageBox.Show(errMsg);
            }
        }

        void tiLogOff_ItemClick(object sender, TileItemEventArgs e)
        {
            Program.frmLogin.Initalize(Enums.Mode.Logout);
        }

        private void tiPrinter_ItemClick(object sender, TileItemEventArgs e)
        {
            cMethods.printerSelectionScreen(Enums.Mode.Report);
            this.tiPrinter.Text = "Printer<br><size=8>" + Program.User.Printer.Description + "</size>";
        }

        private void tiCut_ItemClick(object sender, TileItemEventArgs e)
        {
            cMethods.SetDefaultPrinter();
            frmCut frm = new frmCut();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void tiFilter_ItemClick(object sender, TileItemEventArgs e)
        {
            changeMode(FilterMode);
            Search(string.Empty);
        }

        private void tiSearch_ItemClick(object sender, TileItemEventArgs e)
        {
            frmOrderHistory frmH = new frmOrderHistory(null);
            frmH.ShowDialog();
        }

        private void tiChangeWorklist_ItemClick(object sender, TileItemEventArgs e)
        {
            frmWorklistSettings frm = new frmWorklistSettings(this);
            frm.ShowDialog();
        }

        private void tiRefresh_ItemClick(object sender, TileItemEventArgs e)
        {
            getOrders();
        }

        #endregion

        class Orders
        {
            public stp_lab_worklistResult order { get; set; }
            public Enums.Mode mode { get; set; }
        }


    }
}