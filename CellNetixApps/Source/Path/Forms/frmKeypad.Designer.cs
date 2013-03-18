namespace CellNetixApps.Source.Path.Forms
{
    partial class frmKeypad
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
            this.lStartLevel = new DevExpress.XtraEditors.LabelControl();
            this.lLevels = new DevExpress.XtraEditors.LabelControl();
            this.lAccessionNo = new DevExpress.XtraEditors.LabelControl();
            this.bCancel = new DevExpress.XtraEditors.SimpleButton();
            this.bSave = new DevExpress.XtraEditors.SimpleButton();
            this.cKeypadLevels = new CellNetixApps.Source.Controls.cKeypad();
            this.cKeypadStartLevel = new CellNetixApps.Source.Controls.cKeypad();
            this.SuspendLayout();
            // 
            // lStartLevel
            // 
            this.lStartLevel.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStartLevel.Location = new System.Drawing.Point(30, 45);
            this.lStartLevel.Name = "lStartLevel";
            this.lStartLevel.Size = new System.Drawing.Size(152, 39);
            this.lStartLevel.TabIndex = 18;
            this.lStartLevel.Text = "Start Level";
            // 
            // lLevels
            // 
            this.lLevels.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLevels.Location = new System.Drawing.Point(422, 45);
            this.lLevels.Name = "lLevels";
            this.lLevels.Size = new System.Drawing.Size(87, 39);
            this.lLevels.TabIndex = 19;
            this.lLevels.Text = "Levels";
            // 
            // lAccessionNo
            // 
            this.lAccessionNo.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAccessionNo.Location = new System.Drawing.Point(1, 0);
            this.lAccessionNo.Name = "lAccessionNo";
            this.lAccessionNo.Size = new System.Drawing.Size(181, 39);
            this.lAccessionNo.TabIndex = 20;
            this.lAccessionNo.Text = "lAccessionNo";
            // 
            // bCancel
            // 
            this.bCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.bCancel.Appearance.Options.UseFont = true;
            this.bCancel.Location = new System.Drawing.Point(483, 745);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(245, 67);
            this.bCancel.TabIndex = 24;
            this.bCancel.Text = "Cancel";
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSave
            // 
            this.bSave.Appearance.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.bSave.Appearance.Options.UseFont = true;
            this.bSave.Location = new System.Drawing.Point(63, 745);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(245, 67);
            this.bSave.TabIndex = 23;
            this.bSave.Text = "Save";
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // cKeypadLevels
            // 
            this.cKeypadLevels.Location = new System.Drawing.Point(422, 85);
            this.cKeypadLevels.Name = "cKeypadLevels";
            this.cKeypadLevels.Size = new System.Drawing.Size(371, 654);
            this.cKeypadLevels.TabIndex = 10;
            // 
            // cKeypadStartLevel
            // 
            this.cKeypadStartLevel.Location = new System.Drawing.Point(25, 86);
            this.cKeypadStartLevel.Name = "cKeypadStartLevel";
            this.cKeypadStartLevel.Size = new System.Drawing.Size(372, 653);
            this.cKeypadStartLevel.TabIndex = 9;
            // 
            // frmKeypad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 821);
            this.ControlBox = false;
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.lAccessionNo);
            this.Controls.Add(this.lLevels);
            this.Controls.Add(this.lStartLevel);
            this.Controls.Add(this.cKeypadLevels);
            this.Controls.Add(this.cKeypadStartLevel);
            this.Name = "frmKeypad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.cKeypad cKeypadStartLevel;
        private Controls.cKeypad cKeypadLevels;
        private DevExpress.XtraEditors.LabelControl lStartLevel;
        private DevExpress.XtraEditors.LabelControl lLevels;
        private DevExpress.XtraEditors.LabelControl lAccessionNo;
        private DevExpress.XtraEditors.SimpleButton bCancel;
        private DevExpress.XtraEditors.SimpleButton bSave;

    }
}