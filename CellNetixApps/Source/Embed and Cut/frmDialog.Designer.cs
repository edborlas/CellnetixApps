namespace CellNetixApps.Source.Embed.Forms
{
    partial class frmDialog
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
            this.bYes = new DevExpress.XtraEditors.SimpleButton();
            this.bNo = new DevExpress.XtraEditors.SimpleButton();
            this.lMessage = new DevExpress.XtraEditors.LabelControl();
            this.bOK = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // bYes
            // 
            this.bYes.Appearance.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bYes.Appearance.Options.UseFont = true;
            this.bYes.Location = new System.Drawing.Point(31, 189);
            this.bYes.Margin = new System.Windows.Forms.Padding(5);
            this.bYes.Name = "bYes";
            this.bYes.Size = new System.Drawing.Size(220, 127);
            this.bYes.TabIndex = 0;
            this.bYes.Text = "Yes";
            this.bYes.Click += new System.EventHandler(this.bYes_Click);
            // 
            // bNo
            // 
            this.bNo.Appearance.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bNo.Appearance.Options.UseFont = true;
            this.bNo.Location = new System.Drawing.Point(563, 189);
            this.bNo.Margin = new System.Windows.Forms.Padding(5);
            this.bNo.Name = "bNo";
            this.bNo.Size = new System.Drawing.Size(220, 127);
            this.bNo.TabIndex = 1;
            this.bNo.Text = "No";
            this.bNo.Click += new System.EventHandler(this.bNo_Click);
            // 
            // lMessage
            // 
            this.lMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMessage.Location = new System.Drawing.Point(50, 21);
            this.lMessage.Margin = new System.Windows.Forms.Padding(5);
            this.lMessage.Name = "lMessage";
            this.lMessage.Size = new System.Drawing.Size(108, 33);
            this.lMessage.TabIndex = 2;
            this.lMessage.Text = "lMessage";
            // 
            // bOK
            // 
            this.bOK.Appearance.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bOK.Appearance.Options.UseFont = true;
            this.bOK.Location = new System.Drawing.Point(303, 189);
            this.bOK.Margin = new System.Windows.Forms.Padding(5);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(220, 127);
            this.bOK.TabIndex = 3;
            this.bOK.Text = "OK";
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // frmDialog
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 349);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.lMessage);
            this.Controls.Add(this.bNo);
            this.Controls.Add(this.bYes);
            this.LookAndFeel.SkinName = "Metropolis";
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bYes;
        private DevExpress.XtraEditors.SimpleButton bNo;
        private DevExpress.XtraEditors.LabelControl lMessage;
        private DevExpress.XtraEditors.SimpleButton bOK;
    }
}