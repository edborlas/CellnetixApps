namespace CellNetixApps.Source.Embed_and_Cut
{
    partial class frmEditLevels
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.seStart = new DevExpress.XtraEditors.SpinEdit();
            this.lScanBlock = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.bSave = new DevExpress.XtraEditors.SimpleButton();
            this.bCancel = new DevExpress.XtraEditors.SimpleButton();
            this.seTotal = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.seStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTotal.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // seStart
            // 
            this.seStart.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seStart.Location = new System.Drawing.Point(35, 204);
            this.seStart.Name = "seStart";
            this.seStart.Properties.AllowFocused = false;
            this.seStart.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 120.25F, System.Drawing.FontStyle.Bold);
            this.seStart.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Tahoma", 18.25F);
            serializableAppearanceObject1.Options.UseFont = true;
            this.seStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", 100, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.seStart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.seStart.Properties.IsFloatValue = false;
            this.seStart.Properties.Mask.EditMask = "N00";
            this.seStart.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.seStart.Size = new System.Drawing.Size(300, 218);
            this.seStart.TabIndex = 4;
            // 
            // lScanBlock
            // 
            this.lScanBlock.Appearance.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.lScanBlock.Location = new System.Drawing.Point(12, 12);
            this.lScanBlock.Name = "lScanBlock";
            this.lScanBlock.Size = new System.Drawing.Size(126, 37);
            this.lScanBlock.TabIndex = 18;
            this.lScanBlock.Text = "Scan Block";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.labelControl1.Location = new System.Drawing.Point(35, 149);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(123, 37);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "Start Level";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.labelControl2.Location = new System.Drawing.Point(489, 149);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 37);
            this.labelControl2.TabIndex = 20;
            this.labelControl2.Text = "Levels";
            // 
            // bSave
            // 
            this.bSave.Appearance.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.bSave.Appearance.Options.UseFont = true;
            this.bSave.Location = new System.Drawing.Point(35, 541);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(245, 67);
            this.bSave.TabIndex = 21;
            this.bSave.Text = "Save";
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.bCancel.Appearance.Options.UseFont = true;
            this.bCancel.Location = new System.Drawing.Point(489, 541);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(245, 67);
            this.bCancel.TabIndex = 22;
            this.bCancel.Text = "Cancel";
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // seTotal
            // 
            this.seTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seTotal.Location = new System.Drawing.Point(489, 204);
            this.seTotal.Name = "seTotal";
            this.seTotal.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 120.25F, System.Drawing.FontStyle.Bold);
            this.seTotal.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject2.Font = new System.Drawing.Font("Tahoma", 18.25F);
            serializableAppearanceObject2.Options.UseFont = true;
            this.seTotal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", 100, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.seTotal.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.seTotal.Properties.IsFloatValue = false;
            this.seTotal.Properties.Mask.EditMask = "N00";
            this.seTotal.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.seTotal.Size = new System.Drawing.Size(300, 218);
            this.seTotal.TabIndex = 23;
            // 
            // frmEditLevels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 647);
            this.ControlBox = false;
            this.Controls.Add(this.seTotal);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lScanBlock);
            this.Controls.Add(this.seStart);
            this.Name = "frmEditLevels";
            ((System.ComponentModel.ISupportInitialize)(this.seStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTotal.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit seStart;
        private DevExpress.XtraEditors.LabelControl lScanBlock;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton bSave;
        private DevExpress.XtraEditors.SimpleButton bCancel;
        private DevExpress.XtraEditors.SpinEdit seTotal;
    }
}