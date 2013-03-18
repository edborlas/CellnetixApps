namespace CellNetixApps.Source.Controls
{
    partial class cGrid
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
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bID = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bID)).BeginInit();
            this.SuspendLayout();
            // 
            // gc
            // 
            this.gc.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gc.Location = new System.Drawing.Point(4, 5);
            this.gc.MainView = this.gv;
            this.gc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gc.Name = "gc";
            this.gc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.bID});
            this.gc.Size = new System.Drawing.Size(416, 236);
            this.gc.TabIndex = 3;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv.Appearance.HeaderPanel.Options.UseFont = true;
            this.gv.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv.Appearance.Row.Options.UseFont = true;
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cID});
            this.gv.GridControl = this.gc;
            this.gv.Name = "gv";
            this.gv.OptionsCustomization.AllowGroup = false;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gv.OptionsView.ShowIndicator = false;
            // 
            // cID
            // 
            this.cID.Caption = "Id";
            this.cID.ColumnEdit = this.bID;
            this.cID.FieldName = "Id";
            this.cID.Name = "cID";
            this.cID.Visible = true;
            this.cID.VisibleIndex = 0;
            // 
            // bID
            // 
            this.bID.AutoHeight = false;
            this.bID.Name = "bID";
            this.bID.Click += new System.EventHandler(this.bID_Click);
            // 
            // cGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gc);
            this.Name = "cGrid";
            this.Size = new System.Drawing.Size(431, 249);
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn cID;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit bID;

    }
}
