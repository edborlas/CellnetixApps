namespace CellNetixApps.Source.Tickets
{
    partial class frmRecentTickets
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
            DevExpress.XtraEditors.TileItemElement tileItemElement41 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecentTickets));
            DevExpress.XtraEditors.TileItemElement tileItemElement42 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement43 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement44 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement45 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement46 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement47 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement48 = new DevExpress.XtraEditors.TileItemElement();
            this.tabRecentTickets = new DevExpress.XtraTab.XtraTabControl();
            this.tabTemplate = new DevExpress.XtraTab.XtraTabPage();
            this.lCreated = new DevExpress.XtraEditors.LabelControl();
            this.lTicketNum = new DevExpress.XtraEditors.LabelControl();
            this.tcSaveTemplate = new DevExpress.XtraEditors.TileControl();
            this.tileGroup3 = new DevExpress.XtraEditors.TileGroup();
            this.save = new DevExpress.XtraEditors.TileItem();
            this.lAccessionNumber = new DevExpress.XtraEditors.LabelControl();
            this.lNotes = new DevExpress.XtraEditors.LabelControl();
            this.meNotes = new DevExpress.XtraEditors.MemoEdit();
            this.tcTicketPropertiesTemplate = new DevExpress.XtraEditors.TileControl();
            this.tgTicketPropertiesTemplate = new DevExpress.XtraEditors.TileGroup();
            this.stage = new DevExpress.XtraEditors.TileItem();
            this.error = new DevExpress.XtraEditors.TileItem();
            this.classification = new DevExpress.XtraEditors.TileItem();
            this.status = new DevExpress.XtraEditors.TileItem();
            this.tcTransitions = new DevExpress.XtraEditors.TileControl();
            this.tgTransitions = new DevExpress.XtraEditors.TileGroup();
            this.tiTransitionsLogOff = new DevExpress.XtraEditors.TileItem();
            this.tiTransitionsMainMenu = new DevExpress.XtraEditors.TileItem();
            this.tiTransitionsKeyboard = new DevExpress.XtraEditors.TileItem();
            this.lNoneFound = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabRecentTickets)).BeginInit();
            this.tabRecentTickets.SuspendLayout();
            this.tabTemplate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meNotes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabRecentTickets
            // 
            this.tabRecentTickets.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabRecentTickets.Location = new System.Drawing.Point(0, 123);
            this.tabRecentTickets.Name = "tabRecentTickets";
            this.tabRecentTickets.SelectedTabPage = this.tabTemplate;
            this.tabRecentTickets.Size = new System.Drawing.Size(1324, 703);
            this.tabRecentTickets.TabIndex = 0;
            this.tabRecentTickets.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabTemplate});
            // 
            // tabTemplate
            // 
            this.tabTemplate.Controls.Add(this.lCreated);
            this.tabTemplate.Controls.Add(this.lTicketNum);
            this.tabTemplate.Controls.Add(this.tcSaveTemplate);
            this.tabTemplate.Controls.Add(this.lAccessionNumber);
            this.tabTemplate.Controls.Add(this.lNotes);
            this.tabTemplate.Controls.Add(this.meNotes);
            this.tabTemplate.Controls.Add(this.tcTicketPropertiesTemplate);
            this.tabTemplate.Name = "tabTemplate";
            this.tabTemplate.Size = new System.Drawing.Size(1318, 675);
            this.tabTemplate.Text = "Template for tickets";
            this.tabTemplate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scroll_MouseDown);
            this.tabTemplate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Scroll_MouseUp);
            // 
            // lCreated
            // 
            this.lCreated.Appearance.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lCreated.Location = new System.Drawing.Point(365, 105);
            this.lCreated.Name = "lCreated";
            this.lCreated.Size = new System.Drawing.Size(127, 45);
            this.lCreated.TabIndex = 25;
            this.lCreated.Text = "Created: ";
            // 
            // lTicketNum
            // 
            this.lTicketNum.Appearance.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lTicketNum.Location = new System.Drawing.Point(516, 54);
            this.lTicketNum.Name = "lTicketNum";
            this.lTicketNum.Size = new System.Drawing.Size(112, 45);
            this.lTicketNum.TabIndex = 24;
            this.lTicketNum.Text = "Ticket #";
            // 
            // tcSaveTemplate
            // 
            this.tcSaveTemplate.Groups.Add(this.tileGroup3);
            this.tcSaveTemplate.Location = new System.Drawing.Point(20, 3);
            this.tcSaveTemplate.MaxId = 1;
            this.tcSaveTemplate.Name = "tcSaveTemplate";
            this.tcSaveTemplate.Size = new System.Drawing.Size(288, 156);
            this.tcSaveTemplate.TabIndex = 4;
            this.tcSaveTemplate.Text = "tileControl2";
            // 
            // tileGroup3
            // 
            this.tileGroup3.Items.Add(this.save);
            this.tileGroup3.Name = "tileGroup3";
            this.tileGroup3.Text = null;
            // 
            // save
            // 
            this.save.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.save.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.save.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.save.AppearanceItem.Normal.Options.UseFont = true;
            this.save.BackgroundImage = global::CellNetixApps.Properties.Resources.save;
            this.save.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement41.Text = "save";
            this.save.Elements.Add(tileItemElement41);
            this.save.Id = 0;
            this.save.IsLarge = true;
            this.save.Name = "save";
            this.save.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.save_ItemClick);
            // 
            // lAccessionNumber
            // 
            this.lAccessionNumber.Appearance.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lAccessionNumber.Location = new System.Drawing.Point(498, 3);
            this.lAccessionNumber.Name = "lAccessionNumber";
            this.lAccessionNumber.Size = new System.Drawing.Size(267, 45);
            this.lAccessionNumber.TabIndex = 3;
            this.lAccessionNumber.Text = "Accession Number";
            // 
            // lNotes
            // 
            this.lNotes.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lNotes.Location = new System.Drawing.Point(11, 406);
            this.lNotes.Name = "lNotes";
            this.lNotes.Size = new System.Drawing.Size(49, 25);
            this.lNotes.TabIndex = 2;
            this.lNotes.Text = "Notes";
            // 
            // meNotes
            // 
            this.meNotes.EditValue = resources.GetString("meNotes.EditValue");
            this.meNotes.Location = new System.Drawing.Point(11, 437);
            this.meNotes.Name = "meNotes";
            this.meNotes.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.meNotes.Properties.Appearance.Options.UseFont = true;
            this.meNotes.Size = new System.Drawing.Size(1299, 231);
            this.meNotes.TabIndex = 1;
            // 
            // tcTicketPropertiesTemplate
            // 
            this.tcTicketPropertiesTemplate.Groups.Add(this.tgTicketPropertiesTemplate);
            this.tcTicketPropertiesTemplate.Location = new System.Drawing.Point(11, 226);
            this.tcTicketPropertiesTemplate.MaxId = 4;
            this.tcTicketPropertiesTemplate.Name = "tcTicketPropertiesTemplate";
            this.tcTicketPropertiesTemplate.Size = new System.Drawing.Size(1300, 155);
            this.tcTicketPropertiesTemplate.TabIndex = 0;
            this.tcTicketPropertiesTemplate.Text = "tcTicketProperties";
            // 
            // tgTicketPropertiesTemplate
            // 
            this.tgTicketPropertiesTemplate.Items.Add(this.stage);
            this.tgTicketPropertiesTemplate.Items.Add(this.error);
            this.tgTicketPropertiesTemplate.Items.Add(this.classification);
            this.tgTicketPropertiesTemplate.Items.Add(this.status);
            this.tgTicketPropertiesTemplate.Name = "tgTicketPropertiesTemplate";
            this.tgTicketPropertiesTemplate.Text = null;
            // 
            // stage
            // 
            this.stage.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.stage.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.stage.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.stage.AppearanceItem.Normal.Options.UseFont = true;
            this.stage.BackgroundImage = global::CellNetixApps.Properties.Resources.folder;
            this.stage.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement42.Text = "Stage";
            this.stage.Elements.Add(tileItemElement42);
            this.stage.Id = 0;
            this.stage.IsLarge = true;
            this.stage.Name = "stage";
            this.stage.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.stage_ItemClick);
            // 
            // error
            // 
            this.error.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.error.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.error.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.error.AppearanceItem.Normal.Options.UseFont = true;
            this.error.BackgroundImage = global::CellNetixApps.Properties.Resources.Microscope;
            this.error.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement43.Text = "Error";
            this.error.Elements.Add(tileItemElement43);
            this.error.Id = 1;
            this.error.IsLarge = true;
            this.error.Name = "error";
            this.error.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.error_ItemClick);
            // 
            // classification
            // 
            this.classification.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.classification.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.classification.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.classification.AppearanceItem.Normal.Options.UseFont = true;
            this.classification.BackgroundImage = global::CellNetixApps.Properties.Resources.error;
            this.classification.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement44.Text = "Classification";
            this.classification.Elements.Add(tileItemElement44);
            this.classification.Id = 2;
            this.classification.IsLarge = true;
            this.classification.Name = "classification";
            this.classification.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.classification_ItemClick);
            // 
            // status
            // 
            this.status.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.status.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.status.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.status.AppearanceItem.Normal.Options.UseFont = true;
            this.status.BackgroundImage = global::CellNetixApps.Properties.Resources.check;
            this.status.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement45.Text = "Status";
            this.status.Elements.Add(tileItemElement45);
            this.status.Id = 3;
            this.status.IsLarge = true;
            this.status.Name = "status";
            this.status.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.status_ItemClick);
            // 
            // tcTransitions
            // 
            this.tcTransitions.AllowDrag = false;
            this.tcTransitions.Groups.Add(this.tgTransitions);
            this.tcTransitions.ItemSize = 110;
            this.tcTransitions.Location = new System.Drawing.Point(0, 3);
            this.tcTransitions.MaxId = 19;
            this.tcTransitions.Name = "tcTransitions";
            this.tcTransitions.Padding = new System.Windows.Forms.Padding(0);
            this.tcTransitions.Size = new System.Drawing.Size(384, 123);
            this.tcTransitions.TabIndex = 23;
            this.tcTransitions.Text = "tileControl1";
            // 
            // tgTransitions
            // 
            this.tgTransitions.Items.Add(this.tiTransitionsLogOff);
            this.tgTransitions.Items.Add(this.tiTransitionsMainMenu);
            this.tgTransitions.Items.Add(this.tiTransitionsKeyboard);
            this.tgTransitions.Name = "tgTransitions";
            this.tgTransitions.Text = null;
            // 
            // tiTransitionsLogOff
            // 
            this.tiTransitionsLogOff.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiTransitionsLogOff.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.tiTransitionsLogOff.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiTransitionsLogOff.AppearanceItem.Normal.Options.UseFont = true;
            this.tiTransitionsLogOff.BackgroundImage = global::CellNetixApps.Properties.Resources.Logout;
            this.tiTransitionsLogOff.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement46.Text = "Log Off";
            this.tiTransitionsLogOff.Elements.Add(tileItemElement46);
            this.tiTransitionsLogOff.Id = 14;
            this.tiTransitionsLogOff.Name = "tiTransitionsLogOff";
            this.tiTransitionsLogOff.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiTransitionsLogOff_ItemClick);
            // 
            // tiTransitionsMainMenu
            // 
            this.tiTransitionsMainMenu.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiTransitionsMainMenu.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tiTransitionsMainMenu.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiTransitionsMainMenu.AppearanceItem.Normal.Options.UseFont = true;
            this.tiTransitionsMainMenu.BackgroundImage = global::CellNetixApps.Properties.Resources.ticket;
            this.tiTransitionsMainMenu.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement47.Text = "Main Menu";
            this.tiTransitionsMainMenu.Elements.Add(tileItemElement47);
            this.tiTransitionsMainMenu.Id = 17;
            this.tiTransitionsMainMenu.Name = "tiTransitionsMainMenu";
            this.tiTransitionsMainMenu.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiTransitionsMainMenu_ItemClick);
            // 
            // tiTransitionsKeyboard
            // 
            this.tiTransitionsKeyboard.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiTransitionsKeyboard.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tiTransitionsKeyboard.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiTransitionsKeyboard.AppearanceItem.Normal.Options.UseFont = true;
            this.tiTransitionsKeyboard.BackgroundImage = global::CellNetixApps.Properties.Resources.Keyboard;
            this.tiTransitionsKeyboard.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement48.Text = "KeyBoard";
            this.tiTransitionsKeyboard.Elements.Add(tileItemElement48);
            this.tiTransitionsKeyboard.Id = 18;
            this.tiTransitionsKeyboard.Name = "tiTransitionsKeyboard";
            this.tiTransitionsKeyboard.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.keyboard_ItemClick);
            // 
            // lNoneFound
            // 
            this.lNoneFound.Appearance.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lNoneFound.Location = new System.Drawing.Point(517, 12);
            this.lNoneFound.Name = "lNoneFound";
            this.lNoneFound.Size = new System.Drawing.Size(345, 45);
            this.lNoneFound.TabIndex = 24;
            this.lNoneFound.Text = "No Active Tickets Found";
            this.lNoneFound.Visible = false;
            // 
            // frmRecentTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 826);
            this.ControlBox = false;
            this.Controls.Add(this.lNoneFound);
            this.Controls.Add(this.tcTransitions);
            this.Controls.Add(this.tabRecentTickets);
            this.Name = "frmRecentTickets";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.tabRecentTickets)).EndInit();
            this.tabRecentTickets.ResumeLayout(false);
            this.tabTemplate.ResumeLayout(false);
            this.tabTemplate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meNotes.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabRecentTickets;
        private DevExpress.XtraTab.XtraTabPage tabTemplate;
        private DevExpress.XtraEditors.TileControl tcTransitions;
        private DevExpress.XtraEditors.TileGroup tgTransitions;
        private DevExpress.XtraEditors.TileItem tiTransitionsLogOff;
        private DevExpress.XtraEditors.TileItem tiTransitionsMainMenu;
        private DevExpress.XtraEditors.LabelControl lNotes;
        private DevExpress.XtraEditors.MemoEdit meNotes;
        private DevExpress.XtraEditors.TileControl tcTicketPropertiesTemplate;
        private DevExpress.XtraEditors.TileGroup tgTicketPropertiesTemplate;
        private DevExpress.XtraEditors.TileItem stage;
        private DevExpress.XtraEditors.TileItem error;
        private DevExpress.XtraEditors.TileItem classification;
        private DevExpress.XtraEditors.TileItem status;
        private DevExpress.XtraEditors.LabelControl lAccessionNumber;
        private DevExpress.XtraEditors.TileControl tcSaveTemplate;
        private DevExpress.XtraEditors.TileGroup tileGroup3;
        private DevExpress.XtraEditors.TileItem save;
        private DevExpress.XtraEditors.LabelControl lTicketNum;
        private DevExpress.XtraEditors.LabelControl lNoneFound;
        private DevExpress.XtraEditors.LabelControl lCreated;
        private DevExpress.XtraEditors.TileItem tiTransitionsKeyboard;
    }
}