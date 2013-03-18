namespace CellNetixApps.Source.Login_and_General
{
    partial class frmSearchableSelection
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
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            this.tcSelection = new DevExpress.XtraEditors.TileControl();
            this.tgSelection = new DevExpress.XtraEditors.TileGroup();
            this.teFilter = new DevExpress.XtraEditors.TextEdit();
            this.tcKeyboard = new DevExpress.XtraEditors.TileControl();
            this.tgKeyboard = new DevExpress.XtraEditors.TileGroup();
            this.tiKeyboard = new DevExpress.XtraEditors.TileItem();
            this.tcClose = new DevExpress.XtraEditors.TileControl();
            this.tgClose = new DevExpress.XtraEditors.TileGroup();
            this.tiClose = new DevExpress.XtraEditors.TileItem();
            this.lSelectMsg = new DevExpress.XtraEditors.LabelControl();
            this.lOptionalHeaderText = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.teFilter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tcSelection
            // 
            this.tcSelection.AllowDrag = false;
            this.tcSelection.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tcSelection.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.tcSelection.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tcSelection.AppearanceItem.Normal.Options.UseFont = true;
            this.tcSelection.Groups.Add(this.tgSelection);
            this.tcSelection.ItemSize = 100;
            this.tcSelection.Location = new System.Drawing.Point(12, 155);
            this.tcSelection.MaxId = 9;
            this.tcSelection.Name = "tcSelection";
            this.tcSelection.Size = new System.Drawing.Size(1150, 641);
            this.tcSelection.TabIndex = 0;
            this.tcSelection.Text = "tileControl1";
            // 
            // tgSelection
            // 
            this.tgSelection.Name = "tgSelection";
            this.tgSelection.Text = null;
            // 
            // teFilter
            // 
            this.teFilter.Location = new System.Drawing.Point(12, 66);
            this.teFilter.Name = "teFilter";
            this.teFilter.Size = new System.Drawing.Size(173, 20);
            this.teFilter.TabIndex = 2;
            this.teFilter.TextChanged += new System.EventHandler(this.teFilter_TextChanged);
            this.teFilter.Leave += new System.EventHandler(this.teFilter_Leave);
            // 
            // tcKeyboard
            // 
            this.tcKeyboard.AllowDrag = false;
            this.tcKeyboard.Groups.Add(this.tgKeyboard);
            this.tcKeyboard.Location = new System.Drawing.Point(191, 12);
            this.tcKeyboard.MaxId = 2;
            this.tcKeyboard.Name = "tcKeyboard";
            this.tcKeyboard.Size = new System.Drawing.Size(196, 158);
            this.tcKeyboard.TabIndex = 3;
            this.tcKeyboard.Text = "tileControl2";
            // 
            // tgKeyboard
            // 
            this.tgKeyboard.Items.Add(this.tiKeyboard);
            this.tgKeyboard.Name = "tgKeyboard";
            this.tgKeyboard.Text = null;
            // 
            // tiKeyboard
            // 
            this.tiKeyboard.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiKeyboard.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.tiKeyboard.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiKeyboard.AppearanceItem.Normal.Options.UseFont = true;
            this.tiKeyboard.BackgroundImage = global::CellNetixApps.Properties.Resources.Keyboard;
            this.tiKeyboard.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement3.Text = "Keyboard";
            this.tiKeyboard.Elements.Add(tileItemElement3);
            this.tiKeyboard.Id = 0;
            this.tiKeyboard.Name = "tiKeyboard";
            this.tiKeyboard.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiKeyboard_ItemClick);
            // 
            // tcClose
            // 
            this.tcClose.AllowDrag = false;
            this.tcClose.Groups.Add(this.tgClose);
            this.tcClose.Location = new System.Drawing.Point(966, 12);
            this.tcClose.MaxId = 2;
            this.tcClose.Name = "tcClose";
            this.tcClose.Size = new System.Drawing.Size(196, 158);
            this.tcClose.TabIndex = 4;
            this.tcClose.Text = "tileControl3";
            // 
            // tgClose
            // 
            this.tgClose.Items.Add(this.tiClose);
            this.tgClose.Name = "tgClose";
            this.tgClose.Text = null;
            // 
            // tiClose
            // 
            this.tiClose.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiClose.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.tiClose.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiClose.AppearanceItem.Normal.Options.UseFont = true;
            this.tiClose.BackgroundImage = global::CellNetixApps.Properties.Resources.minus;
            this.tiClose.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement4.Text = "Close";
            this.tiClose.Elements.Add(tileItemElement4);
            this.tiClose.Id = 0;
            this.tiClose.Name = "tiClose";
            // 
            // lSelectMsg
            // 
            this.lSelectMsg.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSelectMsg.Location = new System.Drawing.Point(499, 155);
            this.lSelectMsg.Name = "lSelectMsg";
            this.lSelectMsg.Size = new System.Drawing.Size(172, 39);
            this.lSelectMsg.TabIndex = 19;
            this.lSelectMsg.Text = "Select a Tile";
            // 
            // lOptionalHeaderText
            // 
            this.lOptionalHeaderText.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lOptionalHeaderText.Location = new System.Drawing.Point(734, 12);
            this.lOptionalHeaderText.Name = "lOptionalHeaderText";
            this.lOptionalHeaderText.Size = new System.Drawing.Size(118, 39);
            this.lOptionalHeaderText.TabIndex = 21;
            this.lOptionalHeaderText.Text = "Optional";
            this.lOptionalHeaderText.Visible = false;
            // 
            // frmSearchableSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 808);
            this.ControlBox = false;
            this.Controls.Add(this.lOptionalHeaderText);
            this.Controls.Add(this.lSelectMsg);
            this.Controls.Add(this.tcClose);
            this.Controls.Add(this.tcKeyboard);
            this.Controls.Add(this.teFilter);
            this.Controls.Add(this.tcSelection);
            this.Name = "frmSearchableSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.teFilter.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected DevExpress.XtraEditors.TileControl tcSelection;
        protected DevExpress.XtraEditors.TextEdit teFilter;
        protected DevExpress.XtraEditors.TileControl tcKeyboard;
        protected DevExpress.XtraEditors.TileGroup tgKeyboard;
        protected DevExpress.XtraEditors.TileControl tcClose;
        protected DevExpress.XtraEditors.TileGroup tgClose;
        protected DevExpress.XtraEditors.TileItem tiClose;
        protected DevExpress.XtraEditors.TileItem tiKeyboard;
        protected DevExpress.XtraEditors.TileGroup tgSelection;
        protected DevExpress.XtraEditors.LabelControl lSelectMsg;
        protected DevExpress.XtraEditors.LabelControl lOptionalHeaderText;
    }
}