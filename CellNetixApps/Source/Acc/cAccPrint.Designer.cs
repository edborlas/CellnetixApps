namespace CellNetixApps.Source.Acc
{
    partial class cAccPrint
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
            this.cAccSidebar1 = new CellNetixApps.Source.Acc.cAccSidebar();
            this.SuspendLayout();
            // 
            // cAccSidebar1
            // 
            this.cAccSidebar1.Location = new System.Drawing.Point(0, 0);
            this.cAccSidebar1.Name = "cAccSidebar1";
            this.cAccSidebar1.Size = new System.Drawing.Size(200, 1024);
            this.cAccSidebar1.TabIndex = 31;
            // 
            // cAccPrint
            // 
            this.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cAccSidebar1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "cAccPrint";
            this.Size = new System.Drawing.Size(1920, 1654);
            this.ResumeLayout(false);

        }

        #endregion

        private cAccSidebar cAccSidebar1;
    }
}
