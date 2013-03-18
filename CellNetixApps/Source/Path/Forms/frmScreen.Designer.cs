namespace CellNetixApps.Source.Path.Forms
{
    partial class frmScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScreen));
            this.axRDPViewer1 = new AxRDPCOMAPILib.AxRDPViewer();
            ((System.ComponentModel.ISupportInitialize)(this.axRDPViewer1)).BeginInit();
            this.SuspendLayout();
            // 
            // axRDPViewer1
            // 
            this.axRDPViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axRDPViewer1.Enabled = true;
            this.axRDPViewer1.Location = new System.Drawing.Point(0, 0);
            this.axRDPViewer1.Name = "axRDPViewer1";
            this.axRDPViewer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axRDPViewer1.OcxState")));
            this.axRDPViewer1.Size = new System.Drawing.Size(944, 502);
            this.axRDPViewer1.TabIndex = 8;
            // 
            // frmScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 502);
            this.Controls.Add(this.axRDPViewer1);
            this.Name = "frmScreen";
            this.ShowIcon = false;
            this.Text = "Telepathology";
            ((System.ComponentModel.ISupportInitialize)(this.axRDPViewer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxRDPCOMAPILib.AxRDPViewer axRDPViewer1;
    }
}