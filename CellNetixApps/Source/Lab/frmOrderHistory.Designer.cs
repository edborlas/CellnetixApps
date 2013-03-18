namespace CellNetixApps.Source.Lab
{
    partial class frmOrderHistory
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
            this.lAccesionNo = new DevExpress.XtraEditors.LabelControl();
            this.bClose = new DevExpress.XtraEditors.SimpleButton();
            this.gSlides = new DevExpress.XtraGrid.GridControl();
            this.gvSlides = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.bSearch = new DevExpress.XtraEditors.SimpleButton();
            this.tbScan = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gSlides)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSlides)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbScan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lAccesionNo
            // 
            this.lAccesionNo.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAccesionNo.Location = new System.Drawing.Point(44, 5);
            this.lAccesionNo.Name = "lAccesionNo";
            this.lAccesionNo.Size = new System.Drawing.Size(181, 39);
            this.lAccesionNo.TabIndex = 15;
            this.lAccesionNo.Text = "lAccessionNo";
            // 
            // bClose
            // 
            this.bClose.Appearance.Font = new System.Drawing.Font("Tahoma", 24F);
            this.bClose.Appearance.Options.UseFont = true;
            this.bClose.Location = new System.Drawing.Point(45, 669);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(180, 83);
            this.bClose.TabIndex = 14;
            this.bClose.Text = "Close";
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // gSlides
            // 
            this.gSlides.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.gSlides.Location = new System.Drawing.Point(44, 215);
            this.gSlides.MainView = this.gvSlides;
            this.gSlides.Name = "gSlides";
            this.gSlides.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2});
            this.gSlides.Size = new System.Drawing.Size(1162, 436);
            this.gSlides.TabIndex = 13;
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
            this.gvSlides.GridControl = this.gSlides;
            this.gvSlides.Name = "gvSlides";
            this.gvSlides.OptionsCustomization.AllowGroup = false;
            this.gvSlides.OptionsView.RowAutoHeight = true;
            this.gvSlides.OptionsView.ShowGroupPanel = false;
            this.gvSlides.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // bSearch
            // 
            this.bSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 24F);
            this.bSearch.Appearance.Options.UseFont = true;
            this.bSearch.Location = new System.Drawing.Point(45, 111);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(180, 84);
            this.bSearch.TabIndex = 16;
            this.bSearch.Text = "Search";
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // tbScan
            // 
            this.tbScan.Location = new System.Drawing.Point(44, 61);
            this.tbScan.Name = "tbScan";
            this.tbScan.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.tbScan.Properties.Appearance.Options.UseFont = true;
            this.tbScan.Size = new System.Drawing.Size(222, 44);
            this.tbScan.TabIndex = 19;
            this.tbScan.Leave += new System.EventHandler(this.tbScan_Leave);
            // 
            // frmOrderHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 761);
            this.ControlBox = false;
            this.Controls.Add(this.tbScan);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.lAccesionNo);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.gSlides);
            this.MinimizeBox = false;
            this.Name = "frmOrderHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.gSlides)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSlides)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbScan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lAccesionNo;
        private DevExpress.XtraEditors.SimpleButton bClose;
        private DevExpress.XtraGrid.GridControl gSlides;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSlides;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraEditors.SimpleButton bSearch;
        private DevExpress.XtraEditors.TextEdit tbScan;
    }
}