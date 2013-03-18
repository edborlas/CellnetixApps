namespace CellNetixApps.Source.Distribute
{
    partial class frmManualDistribute
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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.tcProperties = new DevExpress.XtraEditors.TileControl();
            this.tgProperties = new DevExpress.XtraEditors.TileGroup();
            this.tiStart = new DevExpress.XtraEditors.TileItem();
            this.tileControl2 = new DevExpress.XtraEditors.TileControl();
            this.tileGroup1 = new DevExpress.XtraEditors.TileGroup();
            this.tiShipment = new DevExpress.XtraEditors.TileItem();
            this.pOpenShipments = new DevExpress.XtraEditors.PanelControl();
            this.tbScan = new DevExpress.XtraEditors.TextEdit();
            this.lScan = new DevExpress.XtraEditors.LabelControl();
            this.gCaseSlides = new DevExpress.XtraGrid.GridControl();
            this.gvCaseSlides = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cCaseSlidesLabel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cCaseSlidesCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cCaseSlideCtraxStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pOpenShipments)).BeginInit();
            this.pOpenShipments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbScan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCaseSlides)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCaseSlides)).BeginInit();
            this.SuspendLayout();
            // 
            // tileControl1
            // 
            this.tileControl1.AllowDrag = false;
            this.tileControl1.Groups.Add(this.tileGroup2);
            this.tileControl1.Location = new System.Drawing.Point(12, 221);
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.Size = new System.Drawing.Size(1389, 629);
            this.tileControl1.TabIndex = 0;
            this.tileControl1.Text = "tileControl1";
            // 
            // tileGroup2
            // 
            this.tileGroup2.Name = "tileGroup2";
            this.tileGroup2.Text = null;
            // 
            // tcProperties
            // 
            this.tcProperties.AllowDrag = false;
            this.tcProperties.Cursor = System.Windows.Forms.Cursors.Default;
            this.tcProperties.Groups.Add(this.tgProperties);
            this.tcProperties.ItemSize = 175;
            this.tcProperties.Location = new System.Drawing.Point(12, 12);
            this.tcProperties.MaxId = 7;
            this.tcProperties.Name = "tcProperties";
            this.tcProperties.Padding = new System.Windows.Forms.Padding(0);
            this.tcProperties.Size = new System.Drawing.Size(389, 184);
            this.tcProperties.TabIndex = 6;
            this.tcProperties.Text = "tileControl1";
            // 
            // tgProperties
            // 
            this.tgProperties.Items.Add(this.tiStart);
            this.tgProperties.Name = "tgProperties";
            this.tgProperties.Text = null;
            // 
            // tiStart
            // 
            this.tiStart.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.tiStart.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.tiStart.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiStart.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 24.25F);
            this.tiStart.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tiStart.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiStart.AppearanceItem.Normal.Options.UseFont = true;
            this.tiStart.BackgroundImage = global::CellNetixApps.Properties.Resources.play;
            this.tiStart.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement1.Text = "Start";
            this.tiStart.Elements.Add(tileItemElement1);
            this.tiStart.Id = 5;
            this.tiStart.IsLarge = true;
            this.tiStart.Name = "tiStart";
            this.tiStart.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiStart_ItemClick);
            // 
            // tileControl2
            // 
            this.tileControl2.AllowDrag = false;
            this.tileControl2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tileControl2.Groups.Add(this.tileGroup1);
            this.tileControl2.ItemSize = 175;
            this.tileControl2.Location = new System.Drawing.Point(1023, 12);
            this.tileControl2.MaxId = 7;
            this.tileControl2.Name = "tileControl2";
            this.tileControl2.Padding = new System.Windows.Forms.Padding(0);
            this.tileControl2.Size = new System.Drawing.Size(378, 184);
            this.tileControl2.TabIndex = 7;
            this.tileControl2.Text = "tileControl1";
            // 
            // tileGroup1
            // 
            this.tileGroup1.Items.Add(this.tiShipment);
            this.tileGroup1.Name = "tileGroup1";
            this.tileGroup1.Text = null;
            // 
            // tiShipment
            // 
            this.tiShipment.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.tiShipment.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.tiShipment.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiShipment.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 24.25F);
            this.tiShipment.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tiShipment.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiShipment.AppearanceItem.Normal.Options.UseFont = true;
            this.tiShipment.BackgroundImage = global::CellNetixApps.Properties.Resources.Truck;
            this.tiShipment.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement2.Text = "Create Shipment";
            this.tiShipment.Elements.Add(tileItemElement2);
            this.tiShipment.Id = 6;
            this.tiShipment.IsLarge = true;
            this.tiShipment.Name = "tiShipment";
            this.tiShipment.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiShipment_ItemClick);
            // 
            // pOpenShipments
            // 
            this.pOpenShipments.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.pOpenShipments.Controls.Add(this.tbScan);
            this.pOpenShipments.Controls.Add(this.lScan);
            this.pOpenShipments.Location = new System.Drawing.Point(636, 12);
            this.pOpenShipments.Name = "pOpenShipments";
            this.pOpenShipments.Size = new System.Drawing.Size(156, 101);
            this.pOpenShipments.TabIndex = 13;
            // 
            // tbScan
            // 
            this.tbScan.Location = new System.Drawing.Point(6, 61);
            this.tbScan.Name = "tbScan";
            this.tbScan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.tbScan.Properties.Appearance.Options.UseFont = true;
            this.tbScan.Size = new System.Drawing.Size(120, 26);
            this.tbScan.TabIndex = 17;
            this.tbScan.Leave += new System.EventHandler(this.tbScan_Leave);
            // 
            // lScan
            // 
            this.lScan.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.lScan.Location = new System.Drawing.Point(6, 6);
            this.lScan.Name = "lScan";
            this.lScan.Size = new System.Drawing.Size(87, 23);
            this.lScan.TabIndex = 12;
            this.lScan.Text = "Scan Slide";
            // 
            // gCaseSlides
            // 
            this.gCaseSlides.Location = new System.Drawing.Point(423, 114);
            this.gCaseSlides.MainView = this.gvCaseSlides;
            this.gCaseSlides.Name = "gCaseSlides";
            this.gCaseSlides.Size = new System.Drawing.Size(579, 101);
            this.gCaseSlides.TabIndex = 14;
            this.gCaseSlides.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCaseSlides});
            // 
            // gvCaseSlides
            // 
            this.gvCaseSlides.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.gvCaseSlides.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvCaseSlides.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.gvCaseSlides.Appearance.Row.Options.UseFont = true;
            this.gvCaseSlides.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cCaseSlidesLabel,
            this.cCaseSlidesCode,
            this.cCaseSlideCtraxStatus});
            this.gvCaseSlides.GridControl = this.gCaseSlides;
            this.gvCaseSlides.Name = "gvCaseSlides";
            this.gvCaseSlides.OptionsBehavior.Editable = false;
            this.gvCaseSlides.OptionsCustomization.AllowGroup = false;
            this.gvCaseSlides.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvCaseSlides.OptionsView.RowAutoHeight = true;
            this.gvCaseSlides.OptionsView.ShowGroupPanel = false;
            this.gvCaseSlides.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gvCaseSlides.OptionsView.ShowIndicator = false;
            // 
            // cCaseSlidesLabel
            // 
            this.cCaseSlidesLabel.Caption = "Accession Number";
            this.cCaseSlidesLabel.FieldName = "Accession_Number";
            this.cCaseSlidesLabel.Name = "cCaseSlidesLabel";
            this.cCaseSlidesLabel.Visible = true;
            this.cCaseSlidesLabel.VisibleIndex = 0;
            this.cCaseSlidesLabel.Width = 166;
            // 
            // cCaseSlidesCode
            // 
            this.cCaseSlidesCode.Caption = "Case Priority";
            this.cCaseSlidesCode.FieldName = "Case_Priority";
            this.cCaseSlidesCode.Name = "cCaseSlidesCode";
            this.cCaseSlidesCode.Visible = true;
            this.cCaseSlidesCode.VisibleIndex = 1;
            this.cCaseSlidesCode.Width = 118;
            // 
            // cCaseSlideCtraxStatus
            // 
            this.cCaseSlideCtraxStatus.Caption = "Assigned Pathologist";
            this.cCaseSlideCtraxStatus.FieldName = "Assigned_Pathologist";
            this.cCaseSlideCtraxStatus.Name = "cCaseSlideCtraxStatus";
            this.cCaseSlideCtraxStatus.Visible = true;
            this.cCaseSlideCtraxStatus.VisibleIndex = 2;
            this.cCaseSlideCtraxStatus.Width = 293;
            // 
            // frmManualDistribute
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1834, 893);
            this.Controls.Add(this.gCaseSlides);
            this.Controls.Add(this.pOpenShipments);
            this.Controls.Add(this.tileControl2);
            this.Controls.Add(this.tcProperties);
            this.Controls.Add(this.tileControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManualDistribute";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pOpenShipments)).EndInit();
            this.pOpenShipments.ResumeLayout(false);
            this.pOpenShipments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbScan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCaseSlides)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCaseSlides)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TileControl tileControl1;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileControl tcProperties;
        private DevExpress.XtraEditors.TileGroup tgProperties;
        private DevExpress.XtraEditors.TileItem tiStart;
        private DevExpress.XtraEditors.TileControl tileControl2;
        private DevExpress.XtraEditors.TileGroup tileGroup1;
        private DevExpress.XtraEditors.TileItem tiShipment;
        private DevExpress.XtraEditors.PanelControl pOpenShipments;
        private DevExpress.XtraEditors.LabelControl lScan;
        private DevExpress.XtraEditors.TextEdit tbScan;
        private DevExpress.XtraGrid.GridControl gCaseSlides;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCaseSlides;
        private DevExpress.XtraGrid.Columns.GridColumn cCaseSlidesLabel;
        private DevExpress.XtraGrid.Columns.GridColumn cCaseSlidesCode;
        private DevExpress.XtraGrid.Columns.GridColumn cCaseSlideCtraxStatus;
    }
}