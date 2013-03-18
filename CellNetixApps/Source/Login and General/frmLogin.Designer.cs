namespace CellNetixApps.Source.Forms
{
    partial class frmLogin
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
            DevExpress.XtraEditors.TileItemElement tileItemElement9 = new DevExpress.XtraEditors.TileItemElement();
            this.lTitle = new DevExpress.XtraEditors.LabelControl();
            this.tcLogin = new DevExpress.XtraEditors.TileControl();
            this.tgLogin = new DevExpress.XtraEditors.TileGroup();
            this.tiEmbed = new DevExpress.XtraEditors.TileItem();
            this.tiCut = new DevExpress.XtraEditors.TileItem();
            this.tiDistribute = new DevExpress.XtraEditors.TileItem();
            this.tiTicket = new DevExpress.XtraEditors.TileItem();
            this.tiPath = new DevExpress.XtraEditors.TileItem();
            this.tiBlockPrint = new DevExpress.XtraEditors.TileItem();
            this.tiManualDistribute = new DevExpress.XtraEditors.TileItem();
            this.tiWorklist = new DevExpress.XtraEditors.TileItem();
            this.tileGroup1 = new DevExpress.XtraEditors.TileGroup();
            this.bAdmin = new DevExpress.XtraEditors.SimpleButton();
            this.pLogin = new System.Windows.Forms.Panel();
            this.bLogSomeoneIn = new DevExpress.XtraEditors.SimpleButton();
            this.lVersion = new DevExpress.XtraEditors.LabelControl();
            this.tiAccession = new DevExpress.XtraEditors.TileItem();
            this.pLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lTitle
            // 
            this.lTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 24F);
            this.lTitle.Location = new System.Drawing.Point(514, 128);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(299, 39);
            this.lTitle.TabIndex = 2;
            this.lTitle.Text = "Scan Badge To Login";
            // 
            // tcLogin
            // 
            this.tcLogin.AllowDrag = false;
            this.tcLogin.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.tcLogin.AppearanceItem.Normal.Options.UseFont = true;
            this.tcLogin.Groups.Add(this.tgLogin);
            this.tcLogin.Location = new System.Drawing.Point(3, 219);
            this.tcLogin.MaxId = 16;
            this.tcLogin.Name = "tcLogin";
            this.tcLogin.Size = new System.Drawing.Size(1312, 468);
            this.tcLogin.TabIndex = 3;
            this.tcLogin.Text = "tileControl1";
            // 
            // tgLogin
            // 
            this.tgLogin.Items.Add(this.tiEmbed);
            this.tgLogin.Items.Add(this.tiCut);
            this.tgLogin.Items.Add(this.tiDistribute);
            this.tgLogin.Items.Add(this.tiTicket);
            this.tgLogin.Items.Add(this.tiPath);
            this.tgLogin.Items.Add(this.tiBlockPrint);
            this.tgLogin.Items.Add(this.tiManualDistribute);
            this.tgLogin.Items.Add(this.tiWorklist);
            this.tgLogin.Items.Add(this.tiAccession);
            this.tgLogin.Name = "tgLogin";
            this.tgLogin.Text = null;
            // 
            // tiEmbed
            // 
            this.tiEmbed.AppearanceItem.Hovered.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.tiEmbed.AppearanceItem.Hovered.Options.UseFont = true;
            this.tiEmbed.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiEmbed.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.tiEmbed.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiEmbed.AppearanceItem.Normal.Options.UseFont = true;
            this.tiEmbed.AppearanceItem.Selected.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.tiEmbed.AppearanceItem.Selected.Options.UseFont = true;
            tileItemElement1.Text = "Embed";
            this.tiEmbed.Elements.Add(tileItemElement1);
            this.tiEmbed.Id = 5;
            this.tiEmbed.IsLarge = true;
            this.tiEmbed.Name = "tiEmbed";
            // 
            // tiCut
            // 
            this.tiCut.AppearanceItem.Hovered.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.tiCut.AppearanceItem.Hovered.Options.UseFont = true;
            this.tiCut.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiCut.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.tiCut.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiCut.AppearanceItem.Normal.Options.UseFont = true;
            this.tiCut.AppearanceItem.Selected.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.tiCut.AppearanceItem.Selected.Options.UseFont = true;
            tileItemElement2.Text = "Cut";
            this.tiCut.Elements.Add(tileItemElement2);
            this.tiCut.Id = 4;
            this.tiCut.IsLarge = true;
            this.tiCut.Name = "tiCut";
            // 
            // tiDistribute
            // 
            this.tiDistribute.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiDistribute.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.tiDistribute.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiDistribute.AppearanceItem.Normal.Options.UseFont = true;
            this.tiDistribute.AppearanceItem.Selected.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.tiDistribute.AppearanceItem.Selected.Options.UseFont = true;
            tileItemElement3.Text = "Distribute";
            this.tiDistribute.Elements.Add(tileItemElement3);
            this.tiDistribute.Id = 6;
            this.tiDistribute.IsLarge = true;
            this.tiDistribute.Name = "tiDistribute";
            // 
            // tiTicket
            // 
            this.tiTicket.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiTicket.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.tiTicket.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiTicket.AppearanceItem.Normal.Options.UseFont = true;
            tileItemElement4.Text = "Ticket";
            this.tiTicket.Elements.Add(tileItemElement4);
            this.tiTicket.Id = 8;
            this.tiTicket.IsLarge = true;
            this.tiTicket.Name = "tiTicket";
            // 
            // tiPath
            // 
            this.tiPath.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiPath.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.tiPath.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiPath.AppearanceItem.Normal.Options.UseFont = true;
            tileItemElement5.Text = "Pathologist";
            this.tiPath.Elements.Add(tileItemElement5);
            this.tiPath.Id = 9;
            this.tiPath.IsLarge = true;
            this.tiPath.Name = "tiPath";
            // 
            // tiBlockPrint
            // 
            this.tiBlockPrint.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiBlockPrint.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.tiBlockPrint.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiBlockPrint.AppearanceItem.Normal.Options.UseFont = true;
            tileItemElement6.Text = "BlockPrint";
            this.tiBlockPrint.Elements.Add(tileItemElement6);
            this.tiBlockPrint.Id = 11;
            this.tiBlockPrint.IsLarge = true;
            this.tiBlockPrint.Name = "tiBlockPrint";
            this.tiBlockPrint.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiBlockPrint_ItemClick);
            // 
            // tiManualDistribute
            // 
            this.tiManualDistribute.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiManualDistribute.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.tiManualDistribute.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiManualDistribute.AppearanceItem.Normal.Options.UseFont = true;
            tileItemElement7.Text = "Manual Distribute";
            this.tiManualDistribute.Elements.Add(tileItemElement7);
            this.tiManualDistribute.Id = 12;
            this.tiManualDistribute.IsLarge = true;
            this.tiManualDistribute.Name = "tiManualDistribute";
            this.tiManualDistribute.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiManualDistribute_ItemClick);
            // 
            // tiWorklist
            // 
            this.tiWorklist.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiWorklist.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.tiWorklist.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiWorklist.AppearanceItem.Normal.Options.UseFont = true;
            tileItemElement8.Text = "Worklist";
            this.tiWorklist.Elements.Add(tileItemElement8);
            this.tiWorklist.Id = 13;
            this.tiWorklist.IsLarge = true;
            this.tiWorklist.Name = "tiWorklist";
            this.tiWorklist.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiWorklist_ItemClick);
            // 
            // tileGroup1
            // 
            this.tileGroup1.Name = "tileGroup1";
            this.tileGroup1.Text = null;
            // 
            // bAdmin
            // 
            this.bAdmin.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.bAdmin.Appearance.Options.UseFont = true;
            this.bAdmin.Location = new System.Drawing.Point(12, 12);
            this.bAdmin.Name = "bAdmin";
            this.bAdmin.Size = new System.Drawing.Size(176, 67);
            this.bAdmin.TabIndex = 4;
            this.bAdmin.Text = "Login";
            this.bAdmin.Visible = false;
            this.bAdmin.Click += new System.EventHandler(this.bAdmin_Click);
            // 
            // pLogin
            // 
            this.pLogin.Controls.Add(this.bLogSomeoneIn);
            this.pLogin.Controls.Add(this.lVersion);
            this.pLogin.Controls.Add(this.lTitle);
            this.pLogin.Controls.Add(this.tcLogin);
            this.pLogin.Controls.Add(this.bAdmin);
            this.pLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLogin.Location = new System.Drawing.Point(0, 0);
            this.pLogin.Name = "pLogin";
            this.pLogin.Size = new System.Drawing.Size(1383, 796);
            this.pLogin.TabIndex = 5;
            // 
            // bLogSomeoneIn
            // 
            this.bLogSomeoneIn.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.bLogSomeoneIn.Appearance.Options.UseFont = true;
            this.bLogSomeoneIn.Location = new System.Drawing.Point(12, 85);
            this.bLogSomeoneIn.Name = "bLogSomeoneIn";
            this.bLogSomeoneIn.Size = new System.Drawing.Size(176, 67);
            this.bLogSomeoneIn.TabIndex = 6;
            this.bLogSomeoneIn.Text = "Log in Another User";
            this.bLogSomeoneIn.Visible = false;
            this.bLogSomeoneIn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bLogSomeoneIn_Click);
            // 
            // lVersion
            // 
            this.lVersion.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.lVersion.Location = new System.Drawing.Point(12, 174);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(46, 17);
            this.lVersion.TabIndex = 5;
            this.lVersion.Text = "lVersion";
            // 
            // tiAccession
            // 
            tileItemElement9.Text = "Accession";
            this.tiAccession.Elements.Add(tileItemElement9);
            this.tiAccession.Id = 15;
            this.tiAccession.IsLarge = true;
            this.tiAccession.Name = "tiAccession";
            this.tiAccession.ItemPress += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiAccession_ItemPress);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 796);
            this.Controls.Add(this.pLogin);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CellNetix Apps";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pLogin.ResumeLayout(false);
            this.pLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lTitle;
        private DevExpress.XtraEditors.TileControl tcLogin;
        private DevExpress.XtraEditors.TileGroup tgLogin;
        private DevExpress.XtraEditors.TileItem tiCut;
        private DevExpress.XtraEditors.TileItem tiEmbed;
        private DevExpress.XtraEditors.TileItem tiDistribute;
        private DevExpress.XtraEditors.TileGroup tileGroup1;
        private DevExpress.XtraEditors.TileItem tiTicket;
        private DevExpress.XtraEditors.TileItem tiPath;
        private DevExpress.XtraEditors.SimpleButton bAdmin;
        private System.Windows.Forms.Panel pLogin;
        private DevExpress.XtraEditors.LabelControl lVersion;
        private DevExpress.XtraEditors.SimpleButton bLogSomeoneIn;
        private DevExpress.XtraEditors.TileItem tiBlockPrint;
        private DevExpress.XtraEditors.TileItem tiManualDistribute;
        private DevExpress.XtraEditors.TileItem tiWorklist;
        private DevExpress.XtraEditors.TileItem tiAccession;

    }
}