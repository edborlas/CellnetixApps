namespace CellNetixApps.Source.Rules
{
    partial class frmRule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gcValueTypes = new DevExpress.XtraGrid.GridControl();
            this.gvValueTypes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cVTDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cVTID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcValues = new DevExpress.XtraGrid.GridControl();
            this.gvValues = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbValueType = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gcR = new DevExpress.XtraGrid.GridControl();
            this.gvR = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcrID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcrOrganization = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbrOrganization = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gcrFacility = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcrRevCenter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcrFeeSchedule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcrCaseType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcrRefMD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcrSpecimen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcValueTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvValueTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbValueType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbrOrganization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcValueTypes
            // 
            this.gcValueTypes.Location = new System.Drawing.Point(1067, 60);
            this.gcValueTypes.MainView = this.gvValueTypes;
            this.gcValueTypes.Name = "gcValueTypes";
            this.gcValueTypes.Size = new System.Drawing.Size(296, 533);
            this.gcValueTypes.TabIndex = 9;
            this.gcValueTypes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvValueTypes});
            // 
            // gvValueTypes
            // 
            this.gvValueTypes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cVTDescription,
            this.cVTID});
            this.gvValueTypes.GridControl = this.gcValueTypes;
            this.gvValueTypes.Name = "gvValueTypes";
            this.gvValueTypes.OptionsDetail.EnableMasterViewMode = false;
            this.gvValueTypes.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvValueTypes.OptionsView.RowAutoHeight = true;
            this.gvValueTypes.OptionsView.ShowGroupPanel = false;
            this.gvValueTypes.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gvValueTypes.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gvValueTypes_BeforeLeaveRow);
            this.gvValueTypes.DoubleClick += new System.EventHandler(this.gvValueTypes_DoubleClick);
            // 
            // cVTDescription
            // 
            this.cVTDescription.Caption = "Description";
            this.cVTDescription.FieldName = "Description";
            this.cVTDescription.Name = "cVTDescription";
            this.cVTDescription.Visible = true;
            this.cVTDescription.VisibleIndex = 0;
            // 
            // cVTID
            // 
            this.cVTID.FieldName = "ID";
            this.cVTID.Name = "cVTID";
            // 
            // gcValues
            // 
            this.gcValues.Location = new System.Drawing.Point(635, 60);
            this.gcValues.MainView = this.gvValues;
            this.gcValues.Name = "gcValues";
            this.gcValues.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbValueType});
            this.gcValues.Size = new System.Drawing.Size(313, 533);
            this.gcValues.TabIndex = 10;
            this.gcValues.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvValues});
            // 
            // gvValues
            // 
            this.gvValues.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gvValues.GridControl = this.gcValues;
            this.gvValues.Name = "gvValues";
            this.gvValues.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvValues.OptionsView.RowAutoHeight = true;
            this.gvValues.OptionsView.ShowGroupPanel = false;
            this.gvValues.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gvValues.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gvValues_BeforeLeaveRow);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Description";
            this.gridColumn1.FieldName = "Description";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "ID";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Value_Type_ID";
            this.gridColumn3.ColumnEdit = this.cbValueType;
            this.gridColumn3.FieldName = "Value_Type_ID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // cbValueType
            // 
            this.cbValueType.AutoHeight = false;
            this.cbValueType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbValueType.DisplayMember = "Description";
            this.cbValueType.Name = "cbValueType";
            this.cbValueType.ValueMember = "ID";
            this.cbValueType.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsBehavior.AutoPopulateColumns = false;
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16.25F);
            this.labelControl1.Location = new System.Drawing.Point(1067, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(119, 27);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Value Types";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 16.25F);
            this.labelControl2.Location = new System.Drawing.Point(635, 23);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 27);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Values";
            // 
            // gcR
            // 
            gridLevelNode1.LevelTemplate = this.gridView1;
            gridLevelNode1.RelationName = "gvRDetails";
            this.gcR.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcR.Location = new System.Drawing.Point(12, 60);
            this.gcR.MainView = this.gvR;
            this.gcR.Name = "gcR";
            this.gcR.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbrOrganization});
            this.gcR.Size = new System.Drawing.Size(587, 533);
            this.gcR.TabIndex = 13;
            this.gcR.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvR,
            this.gridView1});
            // 
            // gvR
            // 
            this.gvR.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcrID,
            this.gcrOrganization,
            this.gcrFacility,
            this.gcrRevCenter,
            this.gcrFeeSchedule,
            this.gcrCaseType,
            this.gcrRefMD,
            this.gcrSpecimen});
            this.gvR.GridControl = this.gcR;
            this.gvR.Name = "gvR";
            this.gvR.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvR.OptionsView.RowAutoHeight = true;
            this.gvR.OptionsView.ShowGroupPanel = false;
            this.gvR.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gvR.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gvR_BeforeLeaveRow);
            // 
            // gcrID
            // 
            this.gcrID.FieldName = "ID";
            this.gcrID.Name = "gcrID";
            // 
            // gcrOrganization
            // 
            this.gcrOrganization.Caption = "Organization";
            this.gcrOrganization.ColumnEdit = this.cbrOrganization;
            this.gcrOrganization.FieldName = "Organization";
            this.gcrOrganization.Name = "gcrOrganization";
            this.gcrOrganization.Visible = true;
            this.gcrOrganization.VisibleIndex = 0;
            // 
            // cbrOrganization
            // 
            this.cbrOrganization.AutoHeight = false;
            this.cbrOrganization.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbrOrganization.DisplayMember = "Description";
            this.cbrOrganization.Name = "cbrOrganization";
            this.cbrOrganization.ValueMember = "ID";
            this.cbrOrganization.View = this.gridView3;
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.AutoPopulateColumns = false;
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 16.25F);
            this.labelControl3.Location = new System.Drawing.Point(12, 23);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(53, 27);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Rules";
            // 
            // gcrFacility
            // 
            this.gcrFacility.Caption = "Facility";
            this.gcrFacility.FieldName = "Facility";
            this.gcrFacility.Name = "gcrFacility";
            this.gcrFacility.Visible = true;
            this.gcrFacility.VisibleIndex = 1;
            // 
            // gcrRevCenter
            // 
            this.gcrRevCenter.Caption = "Rev Center";
            this.gcrRevCenter.FieldName = "Rev_Center";
            this.gcrRevCenter.Name = "gcrRevCenter";
            this.gcrRevCenter.Visible = true;
            this.gcrRevCenter.VisibleIndex = 2;
            // 
            // gcrFeeSchedule
            // 
            this.gcrFeeSchedule.Caption = "Fee Schedule";
            this.gcrFeeSchedule.FieldName = "Fee_Schedule";
            this.gcrFeeSchedule.Name = "gcrFeeSchedule";
            this.gcrFeeSchedule.Visible = true;
            this.gcrFeeSchedule.VisibleIndex = 3;
            // 
            // gcrCaseType
            // 
            this.gcrCaseType.Caption = "Case Type";
            this.gcrCaseType.FieldName = "Case_Type";
            this.gcrCaseType.Name = "gcrCaseType";
            this.gcrCaseType.Visible = true;
            this.gcrCaseType.VisibleIndex = 4;
            // 
            // gcrRefMD
            // 
            this.gcrRefMD.Caption = "RefMD";
            this.gcrRefMD.FieldName = "RefMD";
            this.gcrRefMD.Name = "gcrRefMD";
            this.gcrRefMD.Visible = true;
            this.gcrRefMD.VisibleIndex = 5;
            // 
            // gcrSpecimen
            // 
            this.gcrSpecimen.Caption = "Specimen";
            this.gcrSpecimen.FieldName = "Specimen";
            this.gcrSpecimen.Name = "gcrSpecimen";
            this.gcrSpecimen.Visible = true;
            this.gcrSpecimen.VisibleIndex = 6;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.GridControl = this.gcR;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Value_Type";
            this.gridColumn4.FieldName = "Value_Type";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Description";
            this.gridColumn5.FieldName = "Description";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // frmRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 700);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.gcR);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gcValues);
            this.Controls.Add(this.gcValueTypes);
            this.Name = "frmRule";
            this.Text = "frmRule";
            ((System.ComponentModel.ISupportInitialize)(this.gcValueTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvValueTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbValueType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbrOrganization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcValueTypes;
        private DevExpress.XtraGrid.Views.Grid.GridView gvValueTypes;
        private DevExpress.XtraGrid.Columns.GridColumn cVTDescription;
        private DevExpress.XtraGrid.Columns.GridColumn cVTID;
        private DevExpress.XtraGrid.GridControl gcValues;
        private DevExpress.XtraGrid.Views.Grid.GridView gvValues;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit cbValueType;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.GridControl gcR;
        private DevExpress.XtraGrid.Views.Grid.GridView gvR;
        private DevExpress.XtraGrid.Columns.GridColumn gcrID;
        private DevExpress.XtraGrid.Columns.GridColumn gcrOrganization;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit cbrOrganization;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn gcrFacility;
        private DevExpress.XtraGrid.Columns.GridColumn gcrRevCenter;
        private DevExpress.XtraGrid.Columns.GridColumn gcrFeeSchedule;
        private DevExpress.XtraGrid.Columns.GridColumn gcrCaseType;
        private DevExpress.XtraGrid.Columns.GridColumn gcrRefMD;
        private DevExpress.XtraGrid.Columns.GridColumn gcrSpecimen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}