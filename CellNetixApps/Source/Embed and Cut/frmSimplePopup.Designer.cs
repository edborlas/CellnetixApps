namespace CellNetixApps.Source.Embed.Forms
{
    partial class frmSimplePopup
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
            this.SuspendLayout();
            // 
            // lMessage
            // 
            this.lMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lMessage.Location = new System.Drawing.Point(12, 68);
            this.lMessage.Name = "lMessage";
            this.lMessage.Size = new System.Drawing.Size(196, 33);
            this.lMessage.TabIndex = 1;
            this.lMessage.Text = "Message to User";
            // 
            // bOK
            // 
            this.bOK.Appearance.Font = new System.Drawing.Font("Tahoma", 24F);
            this.bOK.Appearance.Options.UseFont = true;
            this.bOK.Location = new System.Drawing.Point(240, 209);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(262, 142);
            this.bOK.TabIndex = 0;
            this.bOK.Text = "OK";
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // frmSimplePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 363);
            this.ControlBox = false;
            this.Controls.Add(this.lMessage);
            this.Controls.Add(this.bOK);
            this.Name = "frmSimplePopup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bOK;
        private DevExpress.XtraEditors.LabelControl lMessage;
    }
}