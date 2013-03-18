namespace CellNetixApps.Source.Path.Forms
{
    partial class frmScanBarcode
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
            this.lScan = new System.Windows.Forms.Label();
            this.tbScan = new DevExpress.XtraEditors.TextEdit();
            this.bDone = new DevExpress.XtraEditors.SimpleButton();
            this.bCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbScan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lScan
            // 
            this.lScan.AutoSize = true;
            this.lScan.Font = new System.Drawing.Font("Tahoma", 18.25F);
            this.lScan.Location = new System.Drawing.Point(12, 9);
            this.lScan.Name = "lScan";
            this.lScan.Size = new System.Drawing.Size(375, 30);
            this.lScan.TabIndex = 20;
            this.lScan.Text = "Scan Slide or Type Accession No";
            // 
            // tbScan
            // 
            this.tbScan.Location = new System.Drawing.Point(88, 62);
            this.tbScan.Name = "tbScan";
            this.tbScan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18.25F);
            this.tbScan.Properties.Appearance.Options.UseFont = true;
            this.tbScan.Size = new System.Drawing.Size(209, 36);
            this.tbScan.TabIndex = 19;
            this.tbScan.Leave += new System.EventHandler(this.tbScan_Leave);
            // 
            // bDone
            // 
            this.bDone.Location = new System.Drawing.Point(12, 116);
            this.bDone.Name = "bDone";
            this.bDone.Size = new System.Drawing.Size(174, 47);
            this.bDone.TabIndex = 21;
            this.bDone.Text = "Done";
            this.bDone.Click += new System.EventHandler(this.bDone_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(213, 116);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(174, 47);
            this.bCancel.TabIndex = 22;
            this.bCancel.Text = "Cancel";
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // frmScanBarcode
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 182);
            this.ControlBox = false;
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bDone);
            this.Controls.Add(this.lScan);
            this.Controls.Add(this.tbScan);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmScanBarcode";
            ((System.ComponentModel.ISupportInitialize)(this.tbScan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lScan;
        private DevExpress.XtraEditors.TextEdit tbScan;
        private DevExpress.XtraEditors.SimpleButton bDone;
        private DevExpress.XtraEditors.SimpleButton bCancel;
    }
}