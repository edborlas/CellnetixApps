using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Database;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
namespace CellNetixApps.Source.Rules
{
    public partial class frmRule : DevExpress.XtraEditors.XtraForm
    {

        RulesDataContext dbVT = new RulesDataContext();
        RulesDataContext dbV = new RulesDataContext();
        RulesDataContext dbR = new RulesDataContext();
        public frmRule()
        {
            InitializeComponent();

            var query = from vt in dbVT.Value_Types
                        select vt;

            this.gcValueTypes.DataSource = query;

            var queryV = from v in dbV.Values
                         select v;
            this.gcValues.DataSource = queryV;


            // this.cbValueType.View.Columns.AddField("Description");


            // cbValueType.ValueMember = "ID";
            GridColumn col2 = cbValueType.View.Columns.AddField("Description");
            col2.VisibleIndex = 1;
            col2.Caption = "Description";

            this.cbValueType.DataSource = query;

            var queryR = from r in dbR.Rules
                         select r;

            this.gcR.DataSource = queryR;

            this.cbrOrganization.DataSource = query;
            addColumn(this.cbrOrganization, 1, "Organization");


                         //       select new
                         //{
                         //    ID = r.ID,
                         //    Organization = r.Organization,
                         //    Facility = r.Facility,
                         //    Rev_Center = r.Rev_Center,
                         //    Fee_Schedule = r.Fee_Schedule,
                         //    Specimen = r.Specimen,
                         //    Case_Type = r.Case_Type,
                         //    RefMD = r.RefMD
                         //};

        }


        void addColumn(RepositoryItemGridLookUpEdit r, int index, string fieldName)
        {
            GridColumn col2 = r.View.Columns.AddField("Description");
            col2.VisibleIndex = index;
            col2.Caption = fieldName;
        }


        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Environment.Exit(0);
        }



        private void gvValueTypes_DoubleClick(object sender, EventArgs e)
        {
            int rowIndex = this.gvValueTypes.FocusedRowHandle;
            string description = this.gvValueTypes.GetRowCellValue(rowIndex, this.cVTDescription).ToString();

            DialogResult dr = MessageBox.Show("Delete: " + description + "?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    this.gvValueTypes.DeleteSelectedRows();
                    dbVT.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gvValueTypes_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            dbVT.SubmitChanges();  //this.gvValueTypes.IsNewItemRow(rowIndex))
        }

        private void gvValues_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            dbV.SubmitChanges();
        }

        private void gvR_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            dbR.SubmitChanges();
        }
    }
}