namespace CellNetixApps.Source.Path.Forms
{
    partial class frmPopupInput
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
            this.lMessage = new DevExpress.XtraEditors.LabelControl();
            this.bOK = new DevExpress.XtraEditors.SimpleButton();
            this.tbScan = new DevExpress.XtraEditors.TextEdit();
            this.bCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbScan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lMessage
            // 
            this.lMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lMessage.Location = new System.Drawing.Point(16, 23);
            this.lMessage.Name = "lMessage";
            this.lMessage.Size = new System.Drawing.Size(196, 33);
            this.lMessage.TabIndex = 3;
            this.lMessage.Text = "Message to User";
            // 
            // bOK
            // 
            this.bOK.Appearance.Font = new System.Drawing.Font("Tahoma", 24F);
            this.bOK.Appearance.Options.UseFont = true;
            this.bOK.Location = new System.Drawing.Point(27, 192);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(262, 142);
            this.bOK.TabIndex = 2;
            this.bOK.Text = "OK";
            // 
            // tbScan
            // 
            this.tbScan.Location = new System.Drawing.Point(198, 102);
            this.tbScan.Name = "tbScan";
            this.tbScan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.tbScan.Properties.Appearance.Options.UseFont = true;
            this.tbScan.Size = new System.Drawing.Size(262, 40);
            this.tbScan.TabIndex = 4;
            this.tbScan.Leave += new System.EventHandler(this.tbScan_Leave);
            // 
            // bCancel
            // 
            this.bCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 24F);
            this.bCancel.Appearance.Options.UseFont = true;
            this.bCancel.Location = new System.Drawing.Point(430, 192);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(262, 142);
            this.bCancel.TabIndex = 5;
            this.bCancel.Text = "Cancel";
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // frmPopupInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 375);
            this.ControlBox = false;
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.tbScan);
            this.Controls.Add(this.lMessage);
            this.Controls.Add(this.bOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPopupInput";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.tbScan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lMessage;
        private DevExpress.XtraEditors.SimpleButton bOK;
        private DevExpress.XtraEditors.TextEdit tbScan;
        private DevExpress.XtraEditors.SimpleButton bCancel;
    }
}