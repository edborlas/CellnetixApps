namespace CellNetixApps.Source.Controls
{
    partial class cConsult
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
            this.lRequest = new DevExpress.XtraEditors.LabelControl();
            this.lResponse = new DevExpress.XtraEditors.LabelControl();
            this.cbRequest = new System.Windows.Forms.ComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.bRequest = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tbRequest = new DevExpress.XtraRichEdit.RichEditControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.bResponse = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.tbResponse = new DevExpress.XtraRichEdit.RichEditControl();
            this.cbResponse = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lRequest
            // 
            this.lRequest.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lRequest.Location = new System.Drawing.Point(103, 16);
            this.lRequest.Name = "lRequest";
            this.lRequest.Size = new System.Drawing.Size(219, 25);
            this.lRequest.TabIndex = 37;
            this.lRequest.Text = "Internal Consult Request";
            // 
            // lResponse
            // 
            this.lResponse.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lResponse.Location = new System.Drawing.Point(104, 16);
            this.lResponse.Name = "lResponse";
            this.lResponse.Size = new System.Drawing.Size(232, 25);
            this.lResponse.TabIndex = 38;
            this.lResponse.Text = "Internal Consult Response";
            // 
            // cbRequest
            // 
            this.cbRequest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRequest.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.cbRequest.FormattingEnabled = true;
            this.cbRequest.Location = new System.Drawing.Point(5, 279);
            this.cbRequest.Name = "cbRequest";
            this.cbRequest.Size = new System.Drawing.Size(219, 33);
            this.cbRequest.TabIndex = 43;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.bRequest);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.tbRequest);
            this.panelControl1.Controls.Add(this.cbRequest);
            this.panelControl1.Controls.Add(this.lRequest);
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(454, 478);
            this.panelControl1.TabIndex = 45;
            // 
            // bRequest
            // 
            this.bRequest.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.bRequest.Appearance.Options.UseFont = true;
            this.bRequest.Location = new System.Drawing.Point(5, 338);
            this.bRequest.Name = "bRequest";
            this.bRequest.Size = new System.Drawing.Size(219, 62);
            this.bRequest.TabIndex = 50;
            this.bRequest.Text = "Save Request";
            this.bRequest.Click += new System.EventHandler(this.bRequest_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.labelControl2.Location = new System.Drawing.Point(5, 252);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(20, 25);
            this.labelControl2.TabIndex = 49;
            this.labelControl2.Text = "By";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.labelControl3.Location = new System.Drawing.Point(5, 71);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(131, 25);
            this.labelControl3.TabIndex = 48;
            this.labelControl3.Text = "Note (Optional)";
            // 
            // tbRequest
            // 
            this.tbRequest.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.tbRequest.Appearance.Text.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            this.tbRequest.Appearance.Text.Options.UseFont = true;
            this.tbRequest.Location = new System.Drawing.Point(5, 102);
            this.tbRequest.Name = "tbRequest";
            this.tbRequest.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.tbRequest.Options.MailMerge.KeepLastParagraph = false;
            this.tbRequest.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.tbRequest.ShowCaretInReadOnly = false;
            this.tbRequest.Size = new System.Drawing.Size(290, 144);
            this.tbRequest.TabIndex = 47;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.bResponse);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.tbResponse);
            this.panelControl2.Controls.Add(this.cbResponse);
            this.panelControl2.Controls.Add(this.lResponse);
            this.panelControl2.Location = new System.Drawing.Point(463, 3);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(464, 478);
            this.panelControl2.TabIndex = 46;
            // 
            // bResponse
            // 
            this.bResponse.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.bResponse.Appearance.Options.UseFont = true;
            this.bResponse.Location = new System.Drawing.Point(5, 338);
            this.bResponse.Name = "bResponse";
            this.bResponse.Size = new System.Drawing.Size(219, 62);
            this.bResponse.TabIndex = 54;
            this.bResponse.Text = "Save Response";
            this.bResponse.Click += new System.EventHandler(this.bResponse_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.labelControl4.Location = new System.Drawing.Point(5, 252);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(20, 25);
            this.labelControl4.TabIndex = 53;
            this.labelControl4.Text = "By";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.labelControl5.Location = new System.Drawing.Point(5, 71);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(131, 25);
            this.labelControl5.TabIndex = 52;
            this.labelControl5.Text = "Note (Optional)";
            // 
            // tbResponse
            // 
            this.tbResponse.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.tbResponse.Appearance.Text.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            this.tbResponse.Appearance.Text.Options.UseFont = true;
            this.tbResponse.Location = new System.Drawing.Point(5, 102);
            this.tbResponse.Name = "tbResponse";
            this.tbResponse.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.tbResponse.Options.MailMerge.KeepLastParagraph = false;
            this.tbResponse.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.tbResponse.ShowCaretInReadOnly = false;
            this.tbResponse.Size = new System.Drawing.Size(290, 144);
            this.tbResponse.TabIndex = 51;
            // 
            // cbResponse
            // 
            this.cbResponse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResponse.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.cbResponse.FormattingEnabled = true;
            this.cbResponse.Location = new System.Drawing.Point(5, 279);
            this.cbResponse.Name = "cbResponse";
            this.cbResponse.Size = new System.Drawing.Size(219, 33);
            this.cbResponse.TabIndex = 50;
            // 
            // cConsult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "cConsult";
            this.Size = new System.Drawing.Size(930, 990);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lRequest;
        private DevExpress.XtraEditors.LabelControl lResponse;
        private System.Windows.Forms.ComboBox cbRequest;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraRichEdit.RichEditControl tbRequest;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraRichEdit.RichEditControl tbResponse;
        private System.Windows.Forms.ComboBox cbResponse;
        private DevExpress.XtraEditors.SimpleButton bRequest;
        private DevExpress.XtraEditors.SimpleButton bResponse;
    }
}
