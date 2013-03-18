namespace CellNetixApps.Source.Embed_and_Cut
{
    partial class frmAllSlides
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
            this.gSlides = new DevExpress.XtraGrid.GridControl();
            this.gvSlides = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cLabel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cCutHistory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.bClose = new DevExpress.XtraEditors.SimpleButton();
            this.lAccesionNo = new DevExpress.XtraEditors.LabelControl();
            this.gInstructions = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gSlides)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSlides)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // gSlides
            // 
            this.gSlides.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.gSlides.Location = new System.Drawing.Point(12, 61);
            this.gSlides.MainView = this.gvSlides;
            this.gSlides.Name = "gSlides";
            this.gSlides.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2});
            this.gSlides.Size = new System.Drawing.Size(1162, 595);
            this.gSlides.TabIndex = 4;
            this.gSlides.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSlides});
            // 
            // gvSlides
            // 
            this.gvSlides.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 16.25F);
            this.gvSlides.Appearance.FixedLine.Options.UseFont = true;
            this.gvSlides.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 16.25F);
            this.gvSlides.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvSlides.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.gvSlides.Appearance.Row.Options.UseFont = true;
            this.gvSlides.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cLabel,
            this.cCode,
            this.gInstructions,
            this.cCutHistory});
            this.gvSlides.GridControl = this.gSlides;
            this.gvSlides.Name = "gvSlides";
            this.gvSlides.OptionsCustomization.AllowGroup = false;
            this.gvSlides.OptionsView.RowAutoHeight = true;
            this.gvSlides.OptionsView.ShowGroupPanel = false;
            this.gvSlides.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            // 
            // cLabel
            // 
            this.cLabel.AppearanceCell.Options.UseTextOptions = true;
            this.cLabel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cLabel.AppearanceHeader.Options.UseTextOptions = true;
            this.cLabel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cLabel.Caption = "Label";
            this.cLabel.FieldName = "Label";
            this.cLabel.FieldNameSortGroup = "Label";
            this.cLabel.Name = "cLabel";
            this.cLabel.Visible = true;
            this.cLabel.VisibleIndex = 0;
            this.cLabel.Width = 69;
            // 
            // cCode
            // 
            this.cCode.AppearanceCell.Options.UseTextOptions = true;
            this.cCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cCode.AppearanceHeader.Options.UseTextOptions = true;
            this.cCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cCode.Caption = "Code";
            this.cCode.FieldName = "Code";
            this.cCode.FieldNameSortGroup = "Code";
            this.cCode.Name = "cCode";
            this.cCode.Visible = true;
            this.cCode.VisibleIndex = 1;
            this.cCode.Width = 95;
            // 
            // cCutHistory
            // 
            this.cCutHistory.Caption = "Cut History";
            this.cCutHistory.ColumnEdit = this.repositoryItemMemoEdit2;
            this.cCutHistory.FieldName = "CutHistory";
            this.cCutHistory.FieldNameSortGroup = "CutHistory";
            this.cCutHistory.Name = "cCutHistory";
            this.cCutHistory.OptionsColumn.AllowEdit = false;
            this.cCutHistory.Visible = true;
            this.cCutHistory.VisibleIndex = 3;
            this.cCutHistory.Width = 373;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // bClose
            // 
            this.bClose.Appearance.Font = new System.Drawing.Font("Tahoma", 24F);
            this.bClose.Appearance.Options.UseFont = true;
            this.bClose.Location = new System.Drawing.Point(435, 675);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(262, 113);
            this.bClose.TabIndex = 5;
            this.bClose.Text = "Close";
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // lAccesionNo
            // 
            this.lAccesionNo.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAccesionNo.Location = new System.Drawing.Point(12, 12);
            this.lAccesionNo.Name = "lAccesionNo";
            this.lAccesionNo.Size = new System.Drawing.Size(181, 39);
            this.lAccesionNo.TabIndex = 12;
            this.lAccesionNo.Text = "lAccessionNo";
            // 
            // gInstructions
            // 
            this.gInstructions.Caption = "Instructions";
            this.gInstructions.FieldName = "Instructions";
            this.gInstructions.Name = "gInstructions";
            this.gInstructions.Visible = true;
            this.gInstructions.VisibleIndex = 2;
            this.gInstructions.Width = 210;
            // 
            // frmAllSlides
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 787);
            this.ControlBox = false;
            this.Controls.Add(this.lAccesionNo);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.gSlides);
            this.Name = "frmAllSlides";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.gSlides)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSlides)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gSlides;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSlides;
        private DevExpress.XtraGrid.Columns.GridColumn cLabel;
        private DevExpress.XtraGrid.Columns.GridColumn cCode;
        private DevExpress.XtraGrid.Columns.GridColumn cCutHistory;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraEditors.SimpleButton bClose;
        private DevExpress.XtraEditors.LabelControl lAccesionNo;
        private DevExpress.XtraGrid.Columns.GridColumn gInstructions;


    }
}