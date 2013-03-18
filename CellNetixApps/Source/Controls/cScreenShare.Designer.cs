namespace CellNetixApps.Source.Controls
{
    partial class cScreenShare
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bDisconnect = new DevExpress.XtraEditors.SimpleButton();
            this.gcUserStatus = new DevExpress.XtraGrid.GridControl();
            this.gvUserStatus = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bName = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.cExtension = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cIpAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lHeader = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcUserStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bName)).BeginInit();
            this.SuspendLayout();
            // 
            // bDisconnect
            // 
            this.bDisconnect.Location = new System.Drawing.Point(460, 44);
            this.bDisconnect.Name = "bDisconnect";
            this.bDisconnect.Size = new System.Drawing.Size(152, 63);
            this.bDisconnect.TabIndex = 2;
            this.bDisconnect.Text = "Disconnect";
            this.bDisconnect.Click += new System.EventHandler(this.bDisconnect_Click);
            // 
            // gcUserStatus
            // 
            this.gcUserStatus.Location = new System.Drawing.Point(17, 44);
            this.gcUserStatus.MainView = this.gvUserStatus;
            this.gcUserStatus.Name = "gcUserStatus";
            this.gcUserStatus.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.bName});
            this.gcUserStatus.Size = new System.Drawing.Size(413, 855);
            this.gcUserStatus.TabIndex = 8;
            this.gcUserStatus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUserStatus});
            // 
            // gvUserStatus
            // 
            this.gvUserStatus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cName,
            this.cExtension,
            this.cStatus,
            this.cUserID,
            this.cIpAddress});
            this.gvUserStatus.GridControl = this.gcUserStatus;
            this.gvUserStatus.Name = "gvUserStatus";
            this.gvUserStatus.OptionsView.RowAutoHeight = true;
            this.gvUserStatus.OptionsView.ShowGroupPanel = false;
            this.gvUserStatus.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gvUserStatus.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvUserStatus_RowCellStyle);
            // 
            // cName
            // 
            this.cName.Caption = "Name";
            this.cName.ColumnEdit = this.bName;
            this.cName.FieldName = "Name";
            this.cName.Name = "cName";
            this.cName.OptionsFilter.AllowAutoFilter = false;
            this.cName.OptionsFilter.AllowFilter = false;
            this.cName.Visible = true;
            this.cName.VisibleIndex = 0;
            this.cName.Width = 215;
            // 
            // bName
            // 
            this.bName.AutoHeight = false;
            this.bName.Name = "bName";
            this.bName.Click += new System.EventHandler(this.bName_Click);
            // 
            // cExtension
            // 
            this.cExtension.Caption = "Ext";
            this.cExtension.FieldName = "Extension";
            this.cExtension.Name = "cExtension";
            this.cExtension.OptionsColumn.AllowEdit = false;
            this.cExtension.Visible = true;
            this.cExtension.VisibleIndex = 1;
            // 
            // cStatus
            // 
            this.cStatus.Caption = "Status";
            this.cStatus.FieldName = "Status";
            this.cStatus.Name = "cStatus";
            this.cStatus.OptionsColumn.AllowEdit = false;
            this.cStatus.OptionsFilter.AllowAutoFilter = false;
            this.cStatus.OptionsFilter.AllowFilter = false;
            this.cStatus.Visible = true;
            this.cStatus.VisibleIndex = 2;
            this.cStatus.Width = 99;
            // 
            // cUserID
            // 
            this.cUserID.FieldName = "User_ID";
            this.cUserID.Name = "cUserID";
            // 
            // cIpAddress
            // 
            this.cIpAddress.FieldName = "ip_address";
            this.cIpAddress.Name = "cIpAddress";
            // 
            // lHeader
            // 
            this.lHeader.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lHeader.Location = new System.Drawing.Point(17, 13);
            this.lHeader.Name = "lHeader";
            this.lHeader.Size = new System.Drawing.Size(413, 25);
            this.lHeader.TabIndex = 9;
            this.lHeader.Text = "Select Pathologist To Start Telepathology With";
            // 
            // cScreenShare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lHeader);
            this.Controls.Add(this.gcUserStatus);
            this.Controls.Add(this.bDisconnect);
            this.Name = "cScreenShare";
            this.Size = new System.Drawing.Size(858, 911);
            ((System.ComponentModel.ISupportInitialize)(this.gcUserStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bDisconnect;
        private DevExpress.XtraGrid.GridControl gcUserStatus;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUserStatus;
        private DevExpress.XtraGrid.Columns.GridColumn cName;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit bName;
        private DevExpress.XtraGrid.Columns.GridColumn cStatus;
        private DevExpress.XtraGrid.Columns.GridColumn cUserID;
        private DevExpress.XtraGrid.Columns.GridColumn cExtension;
        private DevExpress.XtraEditors.LabelControl lHeader;
        private DevExpress.XtraGrid.Columns.GridColumn cIpAddress;
      //  private AxRDPViewer axRDPViewer1;
    }
}
