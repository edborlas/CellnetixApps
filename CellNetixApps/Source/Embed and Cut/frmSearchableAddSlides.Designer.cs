namespace CellNetixApps.Source.Embed_and_Cut
{
    partial class frmSearchableAddSlides : CellNetixApps.Source.Login_and_General.frmSearchableSelection
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
            this.tcPopularSlides = new DevExpress.XtraEditors.TileControl();
            this.tgPopularSlides = new DevExpress.XtraEditors.TileGroup();
            this.lSearch = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.teFilter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tcSelection
            // 
            this.tcSelection.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tcSelection.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.tcSelection.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tcSelection.AppearanceItem.Normal.Options.UseFont = true;
            // 
            // teFilter
            // 
            this.teFilter.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.teFilter.Properties.Appearance.Options.UseFont = true;
            this.teFilter.Size = new System.Drawing.Size(173, 30);
            // 
            // tiClose
            // 
            this.tiClose.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiClose.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.tiClose.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiClose.AppearanceItem.Normal.Options.UseFont = true;
            // 
            // tiKeyboard
            // 
            this.tiKeyboard.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tiKeyboard.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.tiKeyboard.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tiKeyboard.AppearanceItem.Normal.Options.UseFont = true;
            // 
            // lSelectMsg
            // 
            this.lSelectMsg.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSelectMsg.Location = new System.Drawing.Point(497, 155);
            this.lSelectMsg.Size = new System.Drawing.Size(189, 39);
            this.lSelectMsg.Text = "Select a Slide";
            // 
            // lOptionalHeaderText
            // 
            this.lOptionalHeaderText.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lOptionalHeaderText.Location = new System.Drawing.Point(1059, 176);
            this.lOptionalHeaderText.Size = new System.Drawing.Size(77, 39);
            this.lOptionalHeaderText.Text = "blank";
            // 
            // tcPopularSlides
            // 
            this.tcPopularSlides.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tcPopularSlides.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.tcPopularSlides.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tcPopularSlides.AppearanceItem.Normal.Options.UseFont = true;
            this.tcPopularSlides.Groups.Add(this.tgPopularSlides);
            this.tcPopularSlides.ItemSize = 100;
            this.tcPopularSlides.Location = new System.Drawing.Point(393, 12);
            this.tcPopularSlides.MaxId = 5;
            this.tcPopularSlides.Name = "tcPopularSlides";
            this.tcPopularSlides.Size = new System.Drawing.Size(567, 158);
            this.tcPopularSlides.TabIndex = 22;
            this.tcPopularSlides.Text = "tileControl1";
            // 
            // tgPopularSlides
            // 
            this.tgPopularSlides.Name = "tgPopularSlides";
            this.tgPopularSlides.Text = null;
            // 
            // lSearch
            // 
            this.lSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.lSearch.Location = new System.Drawing.Point(12, 37);
            this.lSearch.Name = "lSearch";
            this.lSearch.Size = new System.Drawing.Size(106, 23);
            this.lSearch.TabIndex = 23;
            this.lSearch.Text = "Search Code";
            // 
            // frmSearchableAddSlides
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 830);
            this.Controls.Add(this.lSearch);
            this.Controls.Add(this.tcPopularSlides);
            this.Name = "frmSearchableAddSlides";
            this.Controls.SetChildIndex(this.tcSelection, 0);
            this.Controls.SetChildIndex(this.teFilter, 0);
            this.Controls.SetChildIndex(this.tcKeyboard, 0);
            this.Controls.SetChildIndex(this.tcClose, 0);
            this.Controls.SetChildIndex(this.lOptionalHeaderText, 0);
            this.Controls.SetChildIndex(this.tcPopularSlides, 0);
            this.Controls.SetChildIndex(this.lSelectMsg, 0);
            this.Controls.SetChildIndex(this.lSearch, 0);
            ((System.ComponentModel.ISupportInitialize)(this.teFilter.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TileControl tcPopularSlides;
        private DevExpress.XtraEditors.TileGroup tgPopularSlides;
        private DevExpress.XtraEditors.LabelControl lSearch;
    }
}