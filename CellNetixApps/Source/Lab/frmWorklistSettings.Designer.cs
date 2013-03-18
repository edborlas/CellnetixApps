namespace CellNetixApps.Source.Lab
{
    partial class frmWorklistSettings
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
            this.tileControl2 = new DevExpress.XtraEditors.TileControl();
            this.tileGroup3 = new DevExpress.XtraEditors.TileGroup();
            this.tiFacility = new DevExpress.XtraEditors.TileItem();
            this.tiLabDept = new DevExpress.XtraEditors.TileItem();
            this.tiLabDeptWorklist = new DevExpress.XtraEditors.TileItem();
            this.bClose = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // tileControl2
            // 
            this.tileControl2.AllowDrag = false;
            this.tileControl2.Groups.Add(this.tileGroup3);
            this.tileControl2.ItemSize = 100;
            this.tileControl2.Location = new System.Drawing.Point(12, 12);
            this.tileControl2.MaxId = 3;
            this.tileControl2.Name = "tileControl2";
            this.tileControl2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileControl2.Padding = new System.Windows.Forms.Padding(0);
            this.tileControl2.Size = new System.Drawing.Size(222, 324);
            this.tileControl2.TabIndex = 1;
            // 
            // tileGroup3
            // 
            this.tileGroup3.Items.Add(this.tiFacility);
            this.tileGroup3.Items.Add(this.tiLabDept);
            this.tileGroup3.Items.Add(this.tiLabDeptWorklist);
            this.tileGroup3.Name = "tileGroup3";
            this.tileGroup3.Text = null;
            // 
            // tiFacility
            // 
            this.tiFacility.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.tiFacility.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.tiFacility.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiFacility.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.tiFacility.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tiFacility.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiFacility.AppearanceItem.Normal.Options.UseFont = true;
            this.tiFacility.AppearanceItem.Normal.Options.UseTextOptions = true;
            this.tiFacility.AppearanceItem.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tileItemElement1.Text = "Facility   Seattle";
            this.tiFacility.Elements.Add(tileItemElement1);
            this.tiFacility.Id = 0;
            this.tiFacility.IsLarge = true;
            this.tiFacility.Name = "tiFacility";
            this.tiFacility.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiFacility_ItemClick);
            // 
            // tiLabDept
            // 
            this.tiLabDept.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.tiLabDept.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.tiLabDept.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiLabDept.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.tiLabDept.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tiLabDept.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiLabDept.AppearanceItem.Normal.Options.UseFont = true;
            this.tiLabDept.AppearanceItem.Normal.Options.UseTextOptions = true;
            this.tiLabDept.AppearanceItem.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tileItemElement2.Text = "Lab   Seattle Cytology";
            this.tiLabDept.Elements.Add(tileItemElement2);
            this.tiLabDept.Id = 1;
            this.tiLabDept.IsLarge = true;
            this.tiLabDept.Name = "tiLabDept";
            this.tiLabDept.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiLabDept_ItemClick);
            // 
            // tiLabDeptWorklist
            // 
            this.tiLabDeptWorklist.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.tiLabDeptWorklist.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.tiLabDeptWorklist.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiLabDeptWorklist.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.tiLabDeptWorklist.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tiLabDeptWorklist.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiLabDeptWorklist.AppearanceItem.Normal.Options.UseFont = true;
            this.tiLabDeptWorklist.AppearanceItem.Normal.Options.UseTextOptions = true;
            this.tiLabDeptWorklist.AppearanceItem.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tileItemElement3.Text = "Worklist   Special Stains";
            this.tiLabDeptWorklist.Elements.Add(tileItemElement3);
            this.tiLabDeptWorklist.Id = 2;
            this.tiLabDeptWorklist.IsLarge = true;
            this.tiLabDeptWorklist.Name = "tiLabDeptWorklist";
            this.tiLabDeptWorklist.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tiLabDeptWorklist_ItemClick);
            // 
            // bClose
            // 
            this.bClose.Appearance.Font = new System.Drawing.Font("Tahoma", 24F);
            this.bClose.Appearance.Options.UseFont = true;
            this.bClose.Location = new System.Drawing.Point(30, 351);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(180, 83);
            this.bClose.TabIndex = 15;
            this.bClose.Text = "Close";
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // frmWorklistSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 446);
            this.ControlBox = false;
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.tileControl2);
            this.Name = "frmWorklistSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TileControl tileControl2;
        private DevExpress.XtraEditors.TileGroup tileGroup3;
        private DevExpress.XtraEditors.TileItem tiFacility;
        private DevExpress.XtraEditors.TileItem tiLabDept;
        private DevExpress.XtraEditors.TileItem tiLabDeptWorklist;
        private DevExpress.XtraEditors.SimpleButton bClose;
    }
}