namespace CellNetixApps.Source.Path.Forms
{
    partial class frmEditImage
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
            this.pTop = new System.Windows.Forms.Panel();
            this.bSave = new System.Windows.Forms.Button();
            this.bCenter = new System.Windows.Forms.Button();
            this.bUndo = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.bCropBLeft = new System.Windows.Forms.Button();
            this.bCropBRight = new System.Windows.Forms.Button();
            this.bCropTRight = new System.Windows.Forms.Button();
            this.bCropTLeft = new System.Windows.Forms.Button();
            this.pBottom = new System.Windows.Forms.Panel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clb_Slides = new System.Windows.Forms.CheckedListBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lDescription = new System.Windows.Forms.Label();
            this.pTop.SuspendLayout();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTop
            // 
            this.pTop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pTop.Controls.Add(this.bSave);
            this.pTop.Controls.Add(this.bCenter);
            this.pTop.Controls.Add(this.bUndo);
            this.pTop.Controls.Add(this.bDelete);
            this.pTop.Controls.Add(this.bCropBLeft);
            this.pTop.Controls.Add(this.bCropBRight);
            this.pTop.Controls.Add(this.bCropTRight);
            this.pTop.Controls.Add(this.bCropTLeft);
            this.pTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTop.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pTop.Location = new System.Drawing.Point(0, 0);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(1084, 52);
            this.pTop.TabIndex = 0;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(10, 8);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(74, 33);
            this.bSave.TabIndex = 9;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCenter
            // 
            this.bCenter.Location = new System.Drawing.Point(583, 8);
            this.bCenter.Name = "bCenter";
            this.bCenter.Size = new System.Drawing.Size(124, 33);
            this.bCenter.TabIndex = 8;
            this.bCenter.Text = "Crop Center";
            this.bCenter.UseVisualStyleBackColor = true;
            this.bCenter.Click += new System.EventHandler(this.bCenter_Click);
            // 
            // bUndo
            // 
            this.bUndo.Location = new System.Drawing.Point(193, 7);
            this.bUndo.Name = "bUndo";
            this.bUndo.Size = new System.Drawing.Size(74, 33);
            this.bUndo.TabIndex = 5;
            this.bUndo.Text = "Undo";
            this.bUndo.UseVisualStyleBackColor = true;
            this.bUndo.Click += new System.EventHandler(this.bUndo_Click);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(90, 7);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(97, 34);
            this.bDelete.TabIndex = 4;
            this.bDelete.Text = "Delete";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bCropBLeft
            // 
            this.bCropBLeft.Location = new System.Drawing.Point(747, 8);
            this.bCropBLeft.Name = "bCropBLeft";
            this.bCropBLeft.Size = new System.Drawing.Size(152, 33);
            this.bCropBLeft.TabIndex = 3;
            this.bCropBLeft.Text = "Crop Bottom Left";
            this.bCropBLeft.UseVisualStyleBackColor = true;
            this.bCropBLeft.Click += new System.EventHandler(this.bCropBLeft_Click);
            // 
            // bCropBRight
            // 
            this.bCropBRight.Location = new System.Drawing.Point(905, 8);
            this.bCropBRight.Name = "bCropBRight";
            this.bCropBRight.Size = new System.Drawing.Size(165, 33);
            this.bCropBRight.TabIndex = 2;
            this.bCropBRight.Text = "Crop Bottom Right";
            this.bCropBRight.UseVisualStyleBackColor = true;
            this.bCropBRight.Click += new System.EventHandler(this.bCropBRight_Click);
            // 
            // bCropTRight
            // 
            this.bCropTRight.Location = new System.Drawing.Point(417, 8);
            this.bCropTRight.Name = "bCropTRight";
            this.bCropTRight.Size = new System.Drawing.Size(131, 33);
            this.bCropTRight.TabIndex = 1;
            this.bCropTRight.Text = "Crop Top Right";
            this.bCropTRight.UseVisualStyleBackColor = true;
            this.bCropTRight.Click += new System.EventHandler(this.bCropTRight_Click);
            // 
            // bCropTLeft
            // 
            this.bCropTLeft.Location = new System.Drawing.Point(287, 8);
            this.bCropTLeft.Name = "bCropTLeft";
            this.bCropTLeft.Size = new System.Drawing.Size(124, 33);
            this.bCropTLeft.TabIndex = 0;
            this.bCropTLeft.Text = "Crop Top Left";
            this.bCropTLeft.UseVisualStyleBackColor = true;
            this.bCropTLeft.Click += new System.EventHandler(this.bCropTLeft_Click);
            // 
            // pBottom
            // 
            this.pBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBottom.Controls.Add(this.pbImage);
            this.pBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pBottom.Location = new System.Drawing.Point(0, 182);
            this.pBottom.Name = "pBottom";
            this.pBottom.Size = new System.Drawing.Size(1084, 824);
            this.pBottom.TabIndex = 1;
            // 
            // pbImage
            // 
            this.pbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage.Location = new System.Drawing.Point(0, 0);
            this.pbImage.Name = "pbImage";
            this.pbImage.Padding = new System.Windows.Forms.Padding(10);
            this.pbImage.Size = new System.Drawing.Size(1080, 820);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lDescription);
            this.panel1.Controls.Add(this.tbDescription);
            this.panel1.Controls.Add(this.clb_Slides);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 130);
            this.panel1.TabIndex = 2;
            // 
            // clb_Slides
            // 
            this.clb_Slides.CheckOnClick = true;
            this.clb_Slides.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clb_Slides.FormattingEnabled = true;
            this.clb_Slides.Location = new System.Drawing.Point(10, 4);
            this.clb_Slides.MultiColumn = true;
            this.clb_Slides.Name = "clb_Slides";
            this.clb_Slides.Size = new System.Drawing.Size(1060, 76);
            this.clb_Slides.TabIndex = 0;
            this.clb_Slides.SelectedIndexChanged += new System.EventHandler(this.clb_Slides_SelectedIndexChanged);
            // 
            // tbDescription
            // 
            this.tbDescription.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.tbDescription.Location = new System.Drawing.Point(217, 90);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(345, 31);
            this.tbDescription.TabIndex = 8;
            // 
            // lDescription
            // 
            this.lDescription.AutoSize = true;
            this.lDescription.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDescription.Location = new System.Drawing.Point(10, 91);
            this.lDescription.Name = "lDescription";
            this.lDescription.Size = new System.Drawing.Size(110, 26);
            this.lDescription.TabIndex = 20;
            this.lDescription.Text = "Description";
            // 
            // frmEditImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 1007);
            this.Controls.Add(this.pBottom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pTop);
            this.Name = "frmEditImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEditImage";
            this.pTop.ResumeLayout(false);
            this.pBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pTop;
        private System.Windows.Forms.Panel pBottom;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button bCropTLeft;
        private System.Windows.Forms.Button bCropBLeft;
        private System.Windows.Forms.Button bCropBRight;
        private System.Windows.Forms.Button bCropTRight;
        private System.Windows.Forms.Button bUndo;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bCenter;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox clb_Slides;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lDescription;
    }
}