namespace CellNetixApps.Source.Acc
{
    partial class cAccSidebar
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
            this.bBack = new DevExpress.XtraEditors.SimpleButton();
            this.bNext = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gcHistory = new DevExpress.XtraGrid.GridControl();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bBack
            // 
            this.bBack.Appearance.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.bBack.Appearance.Options.UseFont = true;
            this.bBack.Location = new System.Drawing.Point(23, 107);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(141, 56);
            this.bBack.TabIndex = 36;
            this.bBack.Text = "<- Back";
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // bNext
            // 
            this.bNext.Appearance.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.bNext.Appearance.Options.UseFont = true;
            this.bNext.Location = new System.Drawing.Point(23, 27);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(141, 56);
            this.bNext.TabIndex = 35;
            this.bNext.Text = "Next ->";
            this.bNext.Click += new System.EventHandler(this.bNext_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.panelControl1.Controls.Add(this.gcHistory);
            this.panelControl1.Controls.Add(this.bBack);
            this.panelControl1.Controls.Add(this.bNext);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(200, 1024);
            this.panelControl1.TabIndex = 37;
            // 
            // gcHistory
            // 
            this.gcHistory.Location = new System.Drawing.Point(6, 179);
            this.gcHistory.MainView = this.cardView1;
            this.gcHistory.Name = "gcHistory";
            this.gcHistory.Size = new System.Drawing.Size(189, 660);
            this.gcHistory.TabIndex = 37;
            this.gcHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardView1});
            // 
            // cardView1
            // 
            this.cardView1.FocusedCardTopFieldIndex = 0;
            this.cardView1.GridControl = this.gcHistory;
            this.cardView1.Name = "cardView1";
            this.cardView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // cAccSidebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "cAccSidebar";
            this.Size = new System.Drawing.Size(200, 1024);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bBack;
        private DevExpress.XtraEditors.SimpleButton bNext;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gcHistory;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
    }
}
