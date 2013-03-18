namespace CellNetixApps.Source.Acc
{
    partial class cAccCif
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tbScan = new DevExpress.XtraEditors.TextEdit();
            this.cellappsDataSet1 = new CellNetixApps.CELLAPPSDataSet();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.cAccSidebar1 = new CellNetixApps.Source.Acc.cAccSidebar();
            ((System.ComponentModel.ISupportInitialize)(this.tbScan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellappsDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16.25F);
            this.labelControl1.Location = new System.Drawing.Point(206, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(157, 27);
            this.labelControl1.TabIndex = 27;
            this.labelControl1.Text = "Scan CIF or Req";
            // 
            // tbScan
            // 
            this.tbScan.Location = new System.Drawing.Point(206, 36);
            this.tbScan.Name = "tbScan";
            this.tbScan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16.25F);
            this.tbScan.Properties.Appearance.Options.UseFont = true;
            this.tbScan.Size = new System.Drawing.Size(183, 34);
            this.tbScan.TabIndex = 26;
            this.tbScan.Leave += new System.EventHandler(this.tbScan_Leave);
            // 
            // cellappsDataSet1
            // 
            this.cellappsDataSet1.DataSetName = "CELLAPPSDataSet";
            this.cellappsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "CI65867436";
            this.textEdit1.Location = new System.Drawing.Point(600, 75);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(100, 20);
            this.textEdit1.TabIndex = 30;
            // 
            // cAccSidebar1
            // 
            this.cAccSidebar1.Location = new System.Drawing.Point(0, 0);
            this.cAccSidebar1.Name = "cAccSidebar1";
            this.cAccSidebar1.Size = new System.Drawing.Size(200, 1024);
            this.cAccSidebar1.TabIndex = 32;
            // 
            // cAccCif
            // 
            this.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cAccSidebar1);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tbScan);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "cAccCif";
            this.Size = new System.Drawing.Size(1920, 1654);
            ((System.ComponentModel.ISupportInitialize)(this.tbScan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellappsDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit tbScan;
        private CELLAPPSDataSet cellappsDataSet1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private cAccSidebar cAccSidebar1;
    }
}
