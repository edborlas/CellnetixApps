namespace CellNetixApps.Source.Embed_and_Cut
{
    partial class frmCaseNotes
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
            this.tcTopics = new DevExpress.XtraEditors.TileControl();
            this.tgTopics = new DevExpress.XtraEditors.TileGroup();
            this.meNotes = new DevExpress.XtraEditors.MemoEdit();
            this.lNotes = new DevExpress.XtraEditors.LabelControl();
            this.lTopics = new DevExpress.XtraEditors.LabelControl();
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.tiCancel = new DevExpress.XtraEditors.TileItem();
            this.tiKeyboard = new DevExpress.XtraEditors.TileItem();
            this.tiSubmit = new DevExpress.XtraEditors.TileItem();
            this.lAccessionNo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.meNotes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tcTopics
            // 
            this.tcTopics.AllowDrag = false;
            this.tcTopics.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tcTopics.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tcTopics.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tcTopics.AppearanceItem.Normal.Options.UseFont = true;
            this.tcTopics.Groups.Add(this.tgTopics);
            this.tcTopics.Location = new System.Drawing.Point(13, 38);
            this.tcTopics.MaxId = 1;
            this.tcTopics.Name = "tcTopics";
            this.tcTopics.Padding = new System.Windows.Forms.Padding(0);
            this.tcTopics.Size = new System.Drawing.Size(971, 304);
            this.tcTopics.TabIndex = 0;
            this.tcTopics.Text = "tileControl1";
            // 
            // tgTopics
            // 
            this.tgTopics.Name = "tgTopics";
            this.tgTopics.Text = null;
            // 
            // meNotes
            // 
            this.meNotes.Location = new System.Drawing.Point(12, 372);
            this.meNotes.Name = "meNotes";
            this.meNotes.Size = new System.Drawing.Size(971, 173);
            this.meNotes.TabIndex = 1;
            this.meNotes.TextChanged += new System.EventHandler(this.meNotes_TextChanged);
            // 
            // lNotes
            // 
            this.lNotes.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lNotes.Location = new System.Drawing.Point(13, 334);
            this.lNotes.Name = "lNotes";
            this.lNotes.Size = new System.Drawing.Size(63, 32);
            this.lNotes.TabIndex = 2;
            this.lNotes.Text = "Notes";
            // 
            // lTopics
            // 
            this.lTopics.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lTopics.Location = new System.Drawing.Point(12, 12);
            this.lTopics.Name = "lTopics";
            this.lTopics.Size = new System.Drawing.Size(129, 32);
            this.lTopics.TabIndex = 3;
            this.lTopics.Text = "Select Topic";
            // 
            // tileControl1
            // 
            this.tileControl1.Groups.Add(this.tileGroup2);
            this.tileControl1.Location = new System.Drawing.Point(12, 552);
            this.tileControl1.MaxId = 5;
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.Size = new System.Drawing.Size(971, 153);
            this.tileControl1.TabIndex = 4;
            this.tileControl1.Text = "tileControl1";
            // 
            // tileGroup2
            // 
            this.tileGroup2.Items.Add(this.tiCancel);
            this.tileGroup2.Items.Add(this.tiKeyboard);
            this.tileGroup2.Items.Add(this.tiSubmit);
            this.tileGroup2.Name = "tileGroup2";
            this.tileGroup2.Text = null;
            // 
            // tiCancel
            // 
            this.tiCancel.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiCancel.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.tiCancel.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiCancel.AppearanceItem.Normal.Options.UseFont = true;
            this.tiCancel.BackgroundImage = global::CellNetixApps.Properties.Resources.cancel;
            this.tiCancel.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement1.Text = "Cancel";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            this.tiCancel.Elements.Add(tileItemElement1);
            this.tiCancel.Id = 2;
            this.tiCancel.IsLarge = true;
            this.tiCancel.Name = "tiCancel";
            this.tiCancel.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiCancel_ItemClick);
            // 
            // tiKeyboard
            // 
            this.tiKeyboard.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiKeyboard.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.tiKeyboard.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiKeyboard.AppearanceItem.Normal.Options.UseFont = true;
            this.tiKeyboard.BackgroundImage = global::CellNetixApps.Properties.Resources.Keyboard;
            this.tiKeyboard.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement2.Text = "Keyboard";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            this.tiKeyboard.Elements.Add(tileItemElement2);
            this.tiKeyboard.Id = 3;
            this.tiKeyboard.IsLarge = true;
            this.tiKeyboard.Name = "tiKeyboard";
            this.tiKeyboard.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiKeyboard_ItemClick);
            // 
            // tiSubmit
            // 
            this.tiSubmit.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiSubmit.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.tiSubmit.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiSubmit.AppearanceItem.Normal.Options.UseFont = true;
            this.tiSubmit.BackgroundImage = global::CellNetixApps.Properties.Resources.check;
            this.tiSubmit.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement3.Text = "Submit";
            tileItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            this.tiSubmit.Elements.Add(tileItemElement3);
            this.tiSubmit.Id = 4;
            this.tiSubmit.IsLarge = true;
            this.tiSubmit.Name = "tiSubmit";
            this.tiSubmit.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiSubmit_ItemClick);
            // 
            // lAccessionNo
            // 
            this.lAccessionNo.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lAccessionNo.Location = new System.Drawing.Point(821, 12);
            this.lAccessionNo.Name = "lAccessionNo";
            this.lAccessionNo.Size = new System.Drawing.Size(64, 32);
            this.lAccessionNo.TabIndex = 5;
            this.lAccessionNo.Text = "Case#";
            // 
            // frmCaseNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 706);
            this.ControlBox = false;
            this.Controls.Add(this.lAccessionNo);
            this.Controls.Add(this.tileControl1);
            this.Controls.Add(this.lTopics);
            this.Controls.Add(this.lNotes);
            this.Controls.Add(this.meNotes);
            this.Controls.Add(this.tcTopics);
            this.Name = "frmCaseNotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.meNotes.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TileControl tcTopics;
        private DevExpress.XtraEditors.TileGroup tgTopics;
        private DevExpress.XtraEditors.MemoEdit meNotes;
        private DevExpress.XtraEditors.LabelControl lNotes;
        private DevExpress.XtraEditors.LabelControl lTopics;
        private DevExpress.XtraEditors.TileControl tileControl1;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileItem tiCancel;
        private DevExpress.XtraEditors.TileItem tiKeyboard;
        private DevExpress.XtraEditors.TileItem tiSubmit;
        private DevExpress.XtraEditors.LabelControl lAccessionNo;
    }
}