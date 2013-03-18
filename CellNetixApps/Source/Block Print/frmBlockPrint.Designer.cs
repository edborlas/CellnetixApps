namespace CellNetixApps.Source.Block_Print
{
    partial class frmBlockPrint
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
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement8 = new DevExpress.XtraEditors.TileItemElement();
            this.tgPrinter = new DevExpress.XtraEditors.TileGroup();
            this.tiPrinterPrintAll = new DevExpress.XtraEditors.TileItem();
            this.tiPrinterSelectAll = new DevExpress.XtraEditors.TileItem();
            this.tiPrinterSettings = new DevExpress.XtraEditors.TileItem();
            this.tiPrinterLogout = new DevExpress.XtraEditors.TileItem();
            this.tiPrinterTicket = new DevExpress.XtraEditors.TileItem();
            this.tcPrinter = new DevExpress.XtraEditors.TileControl();
            this.lScanSpecimen = new DevExpress.XtraEditors.LabelControl();
            this.tbScan = new DevExpress.XtraEditors.TextEdit();
            this.tgBlocks = new DevExpress.XtraEditors.TileGroup();
            this.tcBlocks = new DevExpress.XtraEditors.TileControl();
            this.tcPrintSelected = new DevExpress.XtraEditors.TileControl();
            this.tgPrintSelected = new DevExpress.XtraEditors.TileGroup();
            this.tiPrintSelectedButton = new DevExpress.XtraEditors.TileItem();
            this.lCaseNumber = new DevExpress.XtraEditors.LabelControl();
            this.bwLoad = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.tbScan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tgPrinter
            // 
            this.tgPrinter.Items.Add(this.tiPrinterPrintAll);
            this.tgPrinter.Items.Add(this.tiPrinterSelectAll);
            this.tgPrinter.Items.Add(this.tiPrinterSettings);
            this.tgPrinter.Items.Add(this.tiPrinterLogout);
            this.tgPrinter.Items.Add(this.tiPrinterTicket);
            this.tgPrinter.Name = "tgPrinter";
            this.tgPrinter.Text = null;
            // 
            // tiPrinterPrintAll
            // 
            this.tiPrinterPrintAll.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiPrinterPrintAll.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.tiPrinterPrintAll.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiPrinterPrintAll.AppearanceItem.Normal.Options.UseFont = true;
            this.tiPrinterPrintAll.BackgroundImage = global::CellNetixApps.Properties.Resources.Printer;
            this.tiPrinterPrintAll.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement1.Text = "Print All";
            this.tiPrinterPrintAll.Elements.Add(tileItemElement1);
            this.tiPrinterPrintAll.Id = 17;
            this.tiPrinterPrintAll.Name = "tiPrinterPrintAll";
            this.tiPrinterPrintAll.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiPrinterPrintAll_ItemClick);
            // 
            // tiPrinterSelectAll
            // 
            this.tiPrinterSelectAll.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiPrinterSelectAll.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.tiPrinterSelectAll.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiPrinterSelectAll.AppearanceItem.Normal.Options.UseFont = true;
            this.tiPrinterSelectAll.BackgroundImage = global::CellNetixApps.Properties.Resources.check;
            this.tiPrinterSelectAll.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement2.Text = "Select All";
            this.tiPrinterSelectAll.Elements.Add(tileItemElement2);
            this.tiPrinterSelectAll.Id = 10;
            this.tiPrinterSelectAll.Name = "tiPrinterSelectAll";
            this.tiPrinterSelectAll.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiPrinterSelectAll_ItemClick);
            // 
            // tiPrinterSettings
            // 
            this.tiPrinterSettings.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiPrinterSettings.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.tiPrinterSettings.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiPrinterSettings.AppearanceItem.Normal.Options.UseFont = true;
            this.tiPrinterSettings.BackgroundImage = global::CellNetixApps.Properties.Resources.settings;
            this.tiPrinterSettings.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement3.Text = "Printer";
            this.tiPrinterSettings.Elements.Add(tileItemElement3);
            this.tiPrinterSettings.Id = 12;
            this.tiPrinterSettings.Name = "tiPrinterSettings";
            this.tiPrinterSettings.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiPrinterSettings_ItemClick);
            // 
            // tiPrinterLogout
            // 
            this.tiPrinterLogout.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiPrinterLogout.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.tiPrinterLogout.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiPrinterLogout.AppearanceItem.Normal.Options.UseFont = true;
            this.tiPrinterLogout.BackgroundImage = global::CellNetixApps.Properties.Resources.Logout;
            this.tiPrinterLogout.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement4.Text = "Log Out";
            this.tiPrinterLogout.Elements.Add(tileItemElement4);
            this.tiPrinterLogout.Id = 15;
            this.tiPrinterLogout.Name = "tiPrinterLogout";
            this.tiPrinterLogout.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiPrinterLogout_ItemClick);
            // 
            // tiPrinterTicket
            // 
            this.tiPrinterTicket.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiPrinterTicket.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.tiPrinterTicket.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiPrinterTicket.AppearanceItem.Normal.Options.UseFont = true;
            this.tiPrinterTicket.BackgroundImage = global::CellNetixApps.Properties.Resources.ticket;
            this.tiPrinterTicket.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement5.Text = "Ticket";
            this.tiPrinterTicket.Elements.Add(tileItemElement5);
            this.tiPrinterTicket.Id = 16;
            this.tiPrinterTicket.Name = "tiPrinterTicket";
            this.tiPrinterTicket.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiPrinterTicket_ItemClick);
            // 
            // tcPrinter
            // 
            this.tcPrinter.Groups.Add(this.tgPrinter);
            this.tcPrinter.Location = new System.Drawing.Point(550, 12);
            this.tcPrinter.MaxId = 18;
            this.tcPrinter.Name = "tcPrinter";
            this.tcPrinter.Padding = new System.Windows.Forms.Padding(0);
            this.tcPrinter.Size = new System.Drawing.Size(640, 132);
            this.tcPrinter.TabIndex = 21;
            this.tcPrinter.Text = "tileControl3";
            // 
            // lScanSpecimen
            // 
            this.lScanSpecimen.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lScanSpecimen.Location = new System.Drawing.Point(12, 12);
            this.lScanSpecimen.Name = "lScanSpecimen";
            this.lScanSpecimen.Size = new System.Drawing.Size(129, 23);
            this.lScanSpecimen.TabIndex = 23;
            this.lScanSpecimen.Text = "Scan Specimen";
            // 
            // tbScan
            // 
            this.tbScan.Location = new System.Drawing.Point(12, 38);
            this.tbScan.Name = "tbScan";
            this.tbScan.Size = new System.Drawing.Size(143, 20);
            this.tbScan.TabIndex = 22;
            this.tbScan.Leave += new System.EventHandler(this.tbScan_Leave);
            // 
            // tgBlocks
            // 
            this.tgBlocks.Name = "tgBlocks";
            this.tgBlocks.Text = null;
            // 
            // tcBlocks
            // 
            this.tcBlocks.AllowDrag = false;
            this.tcBlocks.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tcBlocks.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 16F);
            this.tcBlocks.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tcBlocks.AppearanceItem.Normal.Options.UseFont = true;
            this.tcBlocks.Groups.Add(this.tgBlocks);
            this.tcBlocks.ItemSize = 100;
            this.tcBlocks.Location = new System.Drawing.Point(12, 159);
            this.tcBlocks.MaxId = 41;
            this.tcBlocks.Name = "tcBlocks";
            this.tcBlocks.RowCount = 4;
            this.tcBlocks.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollBar;
            this.tcBlocks.Size = new System.Drawing.Size(1167, 501);
            this.tcBlocks.TabIndex = 24;
            this.tcBlocks.Text = "tileControl1";
            // 
            // tcPrintSelected
            // 
            this.tcPrintSelected.AllowDrag = false;
            this.tcPrintSelected.Groups.Add(this.tgPrintSelected);
            this.tcPrintSelected.ItemSize = 145;
            this.tcPrintSelected.Location = new System.Drawing.Point(161, 3);
            this.tcPrintSelected.MaxId = 2;
            this.tcPrintSelected.Name = "tcPrintSelected";
            this.tcPrintSelected.Size = new System.Drawing.Size(454, 150);
            this.tcPrintSelected.TabIndex = 25;
            this.tcPrintSelected.Text = "tileControl1";
            // 
            // tgPrintSelected
            // 
            this.tgPrintSelected.Items.Add(this.tiPrintSelectedButton);
            this.tgPrintSelected.Name = "tgPrintSelected";
            this.tgPrintSelected.Text = null;
            // 
            // tiPrintSelectedButton
            // 
            this.tiPrintSelectedButton.AppearanceItem.Normal.BackColor = System.Drawing.Color.DimGray;
            this.tiPrintSelectedButton.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiPrintSelectedButton.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 18F);
            this.tiPrintSelectedButton.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tiPrintSelectedButton.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiPrintSelectedButton.AppearanceItem.Normal.Options.UseFont = true;
            tileItemElement6.Text = "Print Selected";
            tileItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement7.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 7F);
            tileItemElement7.Appearance.Normal.Options.UseFont = true;
            tileItemElement7.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            tileItemElement7.Text = "";
            tileItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileItemElement7.TextLocation = new System.Drawing.Point(50, 95);
            tileItemElement8.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 8F);
            tileItemElement8.Appearance.Normal.Options.UseFont = true;
            tileItemElement8.Text = "";
            tileItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            this.tiPrintSelectedButton.Elements.Add(tileItemElement6);
            this.tiPrintSelectedButton.Elements.Add(tileItemElement7);
            this.tiPrintSelectedButton.Elements.Add(tileItemElement8);
            this.tiPrintSelectedButton.Id = 1;
            this.tiPrintSelectedButton.IsLarge = true;
            this.tiPrintSelectedButton.Name = "tiPrintSelectedButton";
            this.tiPrintSelectedButton.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiPrintSelectedButton_ItemClick);
            // 
            // lCaseNumber
            // 
            this.lCaseNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lCaseNumber.Location = new System.Drawing.Point(12, 159);
            this.lCaseNumber.Name = "lCaseNumber";
            this.lCaseNumber.Size = new System.Drawing.Size(113, 23);
            this.lCaseNumber.TabIndex = 26;
            this.lCaseNumber.Text = "Case Number";
            // 
            // bwLoad
            // 
            this.bwLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwLoad_DoWork);
            this.bwLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwLoad_RunWorkerCompleted);
            // 
            // frmBlockPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 660);
            this.ControlBox = false;
            this.Controls.Add(this.tcPrinter);
            this.Controls.Add(this.lCaseNumber);
            this.Controls.Add(this.tcPrintSelected);
            this.Controls.Add(this.tcBlocks);
            this.Controls.Add(this.lScanSpecimen);
            this.Controls.Add(this.tbScan);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBlockPrint";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.tbScan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TileItem tiPrinterSettings;
        private DevExpress.XtraEditors.TileGroup tgPrinter;
        private DevExpress.XtraEditors.TileItem tiPrinterSelectAll;
        private DevExpress.XtraEditors.TileControl tcPrinter;
        private DevExpress.XtraEditors.LabelControl lScanSpecimen;
        private DevExpress.XtraEditors.TextEdit tbScan;
        private DevExpress.XtraEditors.TileGroup tgBlocks;
        private DevExpress.XtraEditors.TileControl tcBlocks;
        private DevExpress.XtraEditors.TileControl tcPrintSelected;
        private DevExpress.XtraEditors.TileGroup tgPrintSelected;
        private DevExpress.XtraEditors.TileItem tiPrintSelectedButton;
        private DevExpress.XtraEditors.LabelControl lCaseNumber;
        private System.ComponentModel.BackgroundWorker bwLoad;
        private DevExpress.XtraEditors.TileItem tiPrinterLogout;
        private DevExpress.XtraEditors.TileItem tiPrinterPrintAll;
        private DevExpress.XtraEditors.TileItem tiPrinterTicket;
    }
}