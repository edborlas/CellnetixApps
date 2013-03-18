namespace CellNetixApps.Source.Forms
{
    partial class frmTextEnteringPopup
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
            this.meUserEntered = new DevExpress.XtraEditors.MemoEdit();
            this.tcButtons = new DevExpress.XtraEditors.TileControl();
            this.tgButtons = new DevExpress.XtraEditors.TileGroup();
            this.tiButtonsKeyboard = new DevExpress.XtraEditors.TileItem();
            this.tiButtonsSubmit = new DevExpress.XtraEditors.TileItem();
            this.lInstructions = new DevExpress.XtraEditors.LabelControl();
            this.tbScan = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.meUserEntered.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbScan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // meUserEntered
            // 
            this.meUserEntered.Location = new System.Drawing.Point(12, 111);
            this.meUserEntered.Name = "meUserEntered";
            this.meUserEntered.Size = new System.Drawing.Size(646, 193);
            this.meUserEntered.TabIndex = 0;
            this.meUserEntered.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.meUserEntered_KeyPress);
            // 
            // tcButtons
            // 
            this.tcButtons.AllowDrag = false;
            this.tcButtons.Groups.Add(this.tgButtons);
            this.tcButtons.Location = new System.Drawing.Point(51, 342);
            this.tcButtons.MaxId = 8;
            this.tcButtons.Name = "tcButtons";
            this.tcButtons.Size = new System.Drawing.Size(566, 159);
            this.tcButtons.TabIndex = 1;
            this.tcButtons.Text = "tileControl1";
            // 
            // tgButtons
            // 
            this.tgButtons.Items.Add(this.tiButtonsKeyboard);
            this.tgButtons.Items.Add(this.tiButtonsSubmit);
            this.tgButtons.Name = "tgButtons";
            this.tgButtons.Text = null;
            // 
            // tiButtonsKeyboard
            // 
            this.tiButtonsKeyboard.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.tiButtonsKeyboard.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiButtonsKeyboard.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.tiButtonsKeyboard.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tiButtonsKeyboard.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiButtonsKeyboard.AppearanceItem.Normal.Options.UseFont = true;
            this.tiButtonsKeyboard.BackgroundImage = global::CellNetixApps.Properties.Resources.Keyboard;
            this.tiButtonsKeyboard.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement1.Text = "KeyBoard";
            this.tiButtonsKeyboard.Elements.Add(tileItemElement1);
            this.tiButtonsKeyboard.Id = 7;
            this.tiButtonsKeyboard.Name = "tiButtonsKeyboard";
            this.tiButtonsKeyboard.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiButtonsKeyboard_ItemClick);
            // 
            // tiButtonsSubmit
            // 
            this.tiButtonsSubmit.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.tiButtonsSubmit.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiButtonsSubmit.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.tiButtonsSubmit.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tiButtonsSubmit.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiButtonsSubmit.AppearanceItem.Normal.Options.UseFont = true;
            this.tiButtonsSubmit.BackgroundImage = global::CellNetixApps.Properties.Resources.check;
            this.tiButtonsSubmit.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement2.Text = "Submit";
            this.tiButtonsSubmit.Elements.Add(tileItemElement2);
            this.tiButtonsSubmit.Id = 5;
            this.tiButtonsSubmit.Name = "tiButtonsSubmit";
            this.tiButtonsSubmit.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiButtonsSubmit_ItemClick);
            // 
            // lInstructions
            // 
            this.lInstructions.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            this.lInstructions.Location = new System.Drawing.Point(24, 76);
            this.lInstructions.Name = "lInstructions";
            this.lInstructions.Size = new System.Drawing.Size(269, 29);
            this.lInstructions.TabIndex = 2;
            this.lInstructions.Text = "Instructions to User Here";
            // 
            // tbScan
            // 
            this.tbScan.Location = new System.Drawing.Point(24, 111);
            this.tbScan.Name = "tbScan";
            this.tbScan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            this.tbScan.Properties.Appearance.Options.UseFont = true;
            this.tbScan.Size = new System.Drawing.Size(216, 36);
            this.tbScan.TabIndex = 17;
            this.tbScan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbScan_KeyPress);
            this.tbScan.Leave += new System.EventHandler(this.tbScan_Leave);
            // 
            // frmTextEnteringPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 513);
            this.ControlBox = false;
            this.Controls.Add(this.tbScan);
            this.Controls.Add(this.lInstructions);
            this.Controls.Add(this.tcButtons);
            this.Controls.Add(this.meUserEntered);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTextEnteringPopup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.meUserEntered.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbScan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit meUserEntered;
        private DevExpress.XtraEditors.TileControl tcButtons;
        private DevExpress.XtraEditors.TileGroup tgButtons;
        private DevExpress.XtraEditors.TileItem tiButtonsSubmit;
        private DevExpress.XtraEditors.TileItem tiButtonsKeyboard;
        private DevExpress.XtraEditors.LabelControl lInstructions;
        private DevExpress.XtraEditors.TextEdit tbScan;
    }
}