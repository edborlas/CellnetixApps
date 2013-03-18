namespace CellNetixApps.Source.Acc
{
    partial class cAccScan
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
            this.imageSlider1 = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.lImageCount = new DevExpress.XtraEditors.LabelControl();
            this.cAccSidebar1 = new CellNetixApps.Source.Acc.cAccSidebar();
            this.bDelete = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // imageSlider1
            // 
            this.imageSlider1.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.Stretch;
            this.imageSlider1.Location = new System.Drawing.Point(206, 47);
            this.imageSlider1.Name = "imageSlider1";
            this.imageSlider1.Size = new System.Drawing.Size(848, 1096);
            this.imageSlider1.TabIndex = 32;
            this.imageSlider1.Text = "imageSlider1";
            // 
            // lImageCount
            // 
            this.lImageCount.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lImageCount.Location = new System.Drawing.Point(206, 7);
            this.lImageCount.Name = "lImageCount";
            this.lImageCount.Size = new System.Drawing.Size(112, 25);
            this.lImageCount.TabIndex = 33;
            this.lImageCount.Text = "0 Req Images";
            // 
            // cAccSidebar1
            // 
            this.cAccSidebar1.Location = new System.Drawing.Point(0, 0);
            this.cAccSidebar1.Name = "cAccSidebar1";
            this.cAccSidebar1.Size = new System.Drawing.Size(200, 1024);
            this.cAccSidebar1.TabIndex = 31;
            // 
            // bDelete
            // 
            this.bDelete.Appearance.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.bDelete.Appearance.Options.UseFont = true;
            this.bDelete.Location = new System.Drawing.Point(351, 3);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(141, 38);
            this.bDelete.TabIndex = 36;
            this.bDelete.Text = "Delete Images";
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // cAccScan
            // 
            this.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.lImageCount);
            this.Controls.Add(this.imageSlider1);
            this.Controls.Add(this.cAccSidebar1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "cAccScan";
            this.Size = new System.Drawing.Size(1920, 1654);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private cAccSidebar cAccSidebar1;
        private DevExpress.XtraEditors.Controls.ImageSlider imageSlider1;
        private DevExpress.XtraEditors.LabelControl lImageCount;
        private DevExpress.XtraEditors.SimpleButton bDelete;
    }
}
