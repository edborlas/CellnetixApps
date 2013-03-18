namespace CellNetixApps.Source.Distribute
{
    partial class frmPrintTray
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
            this.bClose = new DevExpress.XtraEditors.SimpleButton();
            this.tbScan = new DevExpress.XtraEditors.TextEdit();
            this.cbClose = new System.Windows.Forms.CheckBox();
            this.lScan = new System.Windows.Forms.Label();
            this.bPrint = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbScan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bClose
            // 
            this.bClose.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bClose.Appearance.Options.UseFont = true;
            this.bClose.Location = new System.Drawing.Point(17, 159);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(211, 113);
            this.bClose.TabIndex = 0;
            this.bClose.Text = "Close";
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // tbScan
            // 
            this.tbScan.Location = new System.Drawing.Point(17, 52);
            this.tbScan.Name = "tbScan";
            this.tbScan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18.25F);
            this.tbScan.Properties.Appearance.Options.UseFont = true;
            this.tbScan.Size = new System.Drawing.Size(209, 36);
            this.tbScan.TabIndex = 1;
            this.tbScan.Leave += new System.EventHandler(this.tbScan_Leave);
            // 
            // cbClose
            // 
            this.cbClose.AutoSize = true;
            this.cbClose.Checked = true;
            this.cbClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClose.Font = new System.Drawing.Font("Tahoma", 18.25F);
            this.cbClose.Location = new System.Drawing.Point(17, 105);
            this.cbClose.Name = "cbClose";
            this.cbClose.Size = new System.Drawing.Size(211, 34);
            this.cbClose.TabIndex = 17;
            this.cbClose.Text = "Close After Print";
            this.cbClose.UseVisualStyleBackColor = true;
            // 
            // lScan
            // 
            this.lScan.AutoSize = true;
            this.lScan.Font = new System.Drawing.Font("Tahoma", 18.25F);
            this.lScan.Location = new System.Drawing.Point(12, 9);
            this.lScan.Name = "lScan";
            this.lScan.Size = new System.Drawing.Size(289, 30);
            this.lScan.TabIndex = 18;
            this.lScan.Text = "Scan Tray to Print Labels";
            // 
            // bPrint
            // 
            this.bPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bPrint.Appearance.Options.UseFont = true;
            this.bPrint.Location = new System.Drawing.Point(253, 159);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(211, 113);
            this.bPrint.TabIndex = 19;
            this.bPrint.Text = "Print 10 New Labels";
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // frmPrintTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 393);
            this.ControlBox = false;
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.lScan);
            this.Controls.Add(this.cbClose);
            this.Controls.Add(this.tbScan);
            this.Controls.Add(this.bClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrintTray";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.tbScan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bClose;
        private DevExpress.XtraEditors.TextEdit tbScan;
        private System.Windows.Forms.CheckBox cbClose;
        private System.Windows.Forms.Label lScan;
        private DevExpress.XtraEditors.SimpleButton bPrint;
    }
}