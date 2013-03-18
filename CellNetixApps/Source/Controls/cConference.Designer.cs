namespace CellNetixApps.Source.Controls
{
    partial class cConference
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.pStep1 = new DevExpress.XtraEditors.PanelControl();
            this.bDelete = new DevExpress.XtraEditors.SimpleButton();
            this.lNewConference = new System.Windows.Forms.Label();
            this.bNewConference = new DevExpress.XtraEditors.SimpleButton();
            this.lMyConferences = new System.Windows.Forms.Label();
            this.cbConferences = new System.Windows.Forms.ComboBox();
            this.tbNewConference = new DevExpress.XtraEditors.TextEdit();
            this.pStep2 = new DevExpress.XtraEditors.PanelControl();
            this.bChangeCase = new DevExpress.XtraEditors.SimpleButton();
            this.lCase = new System.Windows.Forms.Label();
            this.bTakePicture = new DevExpress.XtraEditors.SimpleButton();
            this.pStep3 = new DevExpress.XtraEditors.PanelControl();
            this.bWebsite = new DevExpress.XtraEditors.SimpleButton();
            this.bReconcile = new DevExpress.XtraEditors.SimpleButton();
            this.gcConference = new DevExpress.XtraGrid.GridControl();
            this.gvConference = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cConferenceImageID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rFile = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.cAccessionNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cSlide = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rDescription = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rActive = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.bPowerPoint = new DevExpress.XtraEditors.SimpleButton();
            this.bFolder = new DevExpress.XtraEditors.SimpleButton();
            this.gSortOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bUp = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.cDown = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bDown = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pStep1)).BeginInit();
            this.pStep1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbNewConference.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pStep2)).BeginInit();
            this.pStep2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pStep3)).BeginInit();
            this.pStep3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcConference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pStep1
            // 
            this.pStep1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pStep1.Controls.Add(this.bDelete);
            this.pStep1.Controls.Add(this.lNewConference);
            this.pStep1.Controls.Add(this.bNewConference);
            this.pStep1.Controls.Add(this.lMyConferences);
            this.pStep1.Controls.Add(this.cbConferences);
            this.pStep1.Controls.Add(this.tbNewConference);
            this.pStep1.Location = new System.Drawing.Point(3, 3);
            this.pStep1.Name = "pStep1";
            this.pStep1.Size = new System.Drawing.Size(460, 144);
            this.pStep1.TabIndex = 0;
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(5, 85);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(195, 40);
            this.bDelete.TabIndex = 6;
            this.bDelete.Text = "Archive Selected";
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // lNewConference
            // 
            this.lNewConference.AutoSize = true;
            this.lNewConference.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.lNewConference.Location = new System.Drawing.Point(261, 12);
            this.lNewConference.Name = "lNewConference";
            this.lNewConference.Size = new System.Drawing.Size(148, 23);
            this.lNewConference.TabIndex = 5;
            this.lNewConference.Text = "New Conference";
            // 
            // bNewConference
            // 
            this.bNewConference.Location = new System.Drawing.Point(260, 84);
            this.bNewConference.Name = "bNewConference";
            this.bNewConference.Size = new System.Drawing.Size(195, 40);
            this.bNewConference.TabIndex = 2;
            this.bNewConference.Text = "Create";
            this.bNewConference.Click += new System.EventHandler(this.bNewConference_Click);
            // 
            // lMyConferences
            // 
            this.lMyConferences.AutoSize = true;
            this.lMyConferences.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.lMyConferences.Location = new System.Drawing.Point(7, 12);
            this.lMyConferences.Name = "lMyConferences";
            this.lMyConferences.Size = new System.Drawing.Size(143, 23);
            this.lMyConferences.TabIndex = 4;
            this.lMyConferences.Text = "My Conferences";
            // 
            // cbConferences
            // 
            this.cbConferences.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConferences.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.cbConferences.FormattingEnabled = true;
            this.cbConferences.Location = new System.Drawing.Point(5, 48);
            this.cbConferences.Name = "cbConferences";
            this.cbConferences.Size = new System.Drawing.Size(212, 31);
            this.cbConferences.TabIndex = 3;
            this.cbConferences.SelectedIndexChanged += new System.EventHandler(this.cbConferences_SelectedIndexChanged);
            // 
            // tbNewConference
            // 
            this.tbNewConference.Location = new System.Drawing.Point(260, 48);
            this.tbNewConference.Name = "tbNewConference";
            this.tbNewConference.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.tbNewConference.Properties.Appearance.Options.UseFont = true;
            this.tbNewConference.Size = new System.Drawing.Size(195, 30);
            this.tbNewConference.TabIndex = 1;
            // 
            // pStep2
            // 
            this.pStep2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pStep2.Controls.Add(this.bChangeCase);
            this.pStep2.Controls.Add(this.lCase);
            this.pStep2.Location = new System.Drawing.Point(467, 3);
            this.pStep2.Name = "pStep2";
            this.pStep2.Size = new System.Drawing.Size(460, 144);
            this.pStep2.TabIndex = 1;
            // 
            // bChangeCase
            // 
            this.bChangeCase.Location = new System.Drawing.Point(22, 84);
            this.bChangeCase.Name = "bChangeCase";
            this.bChangeCase.Size = new System.Drawing.Size(195, 40);
            this.bChangeCase.TabIndex = 5;
            this.bChangeCase.Text = "Change Case";
            this.bChangeCase.Click += new System.EventHandler(this.bChangeCase_Click);
            // 
            // lCase
            // 
            this.lCase.AutoSize = true;
            this.lCase.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.lCase.Location = new System.Drawing.Point(18, 12);
            this.lCase.Name = "lCase";
            this.lCase.Size = new System.Drawing.Size(118, 23);
            this.lCase.TabIndex = 4;
            this.lCase.Text = "Current Case";
            // 
            // bTakePicture
            // 
            this.bTakePicture.BackgroundImage = global::CellNetixApps.Properties.Resources.camera;
            this.bTakePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bTakePicture.Location = new System.Drawing.Point(5, 46);
            this.bTakePicture.Name = "bTakePicture";
            this.bTakePicture.Size = new System.Drawing.Size(156, 40);
            this.bTakePicture.TabIndex = 3;
            this.bTakePicture.Text = "Take Picture";
            this.bTakePicture.Click += new System.EventHandler(this.bTakePicture_Click);
            // 
            // pStep3
            // 
            this.pStep3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pStep3.Controls.Add(this.bWebsite);
            this.pStep3.Controls.Add(this.bReconcile);
            this.pStep3.Controls.Add(this.gcConference);
            this.pStep3.Controls.Add(this.bTakePicture);
            this.pStep3.Controls.Add(this.bPowerPoint);
            this.pStep3.Controls.Add(this.bFolder);
            this.pStep3.Location = new System.Drawing.Point(3, 153);
            this.pStep3.Name = "pStep3";
            this.pStep3.Size = new System.Drawing.Size(924, 834);
            this.pStep3.TabIndex = 2;
            // 
            // bWebsite
            // 
            this.bWebsite.Location = new System.Drawing.Point(753, 46);
            this.bWebsite.Name = "bWebsite";
            this.bWebsite.Size = new System.Drawing.Size(156, 40);
            this.bWebsite.TabIndex = 9;
            this.bWebsite.Text = "Conference Website";
            this.bWebsite.Click += new System.EventHandler(this.bWebsite_Click);
            // 
            // bReconcile
            // 
            this.bReconcile.Location = new System.Drawing.Point(374, 46);
            this.bReconcile.Name = "bReconcile";
            this.bReconcile.Size = new System.Drawing.Size(156, 40);
            this.bReconcile.TabIndex = 8;
            this.bReconcile.Text = "Reconcile Images";
            this.bReconcile.Click += new System.EventHandler(this.bReconcile_Click);
            // 
            // gcConference
            // 
            this.gcConference.AllowDrop = true;
            gridLevelNode1.RelationName = "Level1";
            this.gcConference.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcConference.Location = new System.Drawing.Point(0, 112);
            this.gcConference.MainView = this.gvConference;
            this.gcConference.Name = "gcConference";
            this.gcConference.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rDescription,
            this.rActive,
            this.rFile,
            this.bUp,
            this.bDown});
            this.gcConference.Size = new System.Drawing.Size(919, 598);
            this.gcConference.TabIndex = 7;
            this.gcConference.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvConference});
            this.gcConference.Enter += new System.EventHandler(this.gcConference_Enter);
            this.gcConference.Leave += new System.EventHandler(this.gcConference_Leave);
            // 
            // gvConference
            // 
            this.gvConference.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cConferenceImageID,
            this.cFileName,
            this.cAccessionNo,
            this.cSlide,
            this.cDescription,
            this.gSortOrder,
            this.gcUp,
            this.cDown,
            this.gActive});
            this.gvConference.GridControl = this.gcConference;
            this.gvConference.Name = "gvConference";
            this.gvConference.OptionsView.RowAutoHeight = true;
            this.gvConference.OptionsView.ShowGroupPanel = false;
            this.gvConference.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            // 
            // cConferenceImageID
            // 
            this.cConferenceImageID.FieldName = "Conference_Image_ID";
            this.cConferenceImageID.Name = "cConferenceImageID";
            this.cConferenceImageID.OptionsFilter.AllowAutoFilter = false;
            this.cConferenceImageID.OptionsFilter.AllowFilter = false;
            // 
            // cFileName
            // 
            this.cFileName.Caption = "File Name";
            this.cFileName.ColumnEdit = this.rFile;
            this.cFileName.FieldName = "File_Name";
            this.cFileName.Name = "cFileName";
            this.cFileName.OptionsColumn.AllowSize = false;
            this.cFileName.OptionsFilter.AllowAutoFilter = false;
            this.cFileName.OptionsFilter.AllowFilter = false;
            this.cFileName.Visible = true;
            this.cFileName.VisibleIndex = 0;
            this.cFileName.Width = 134;
            // 
            // rFile
            // 
            this.rFile.AutoHeight = false;
            this.rFile.Name = "rFile";
            this.rFile.Click += new System.EventHandler(this.rFile_Click);
            // 
            // cAccessionNo
            // 
            this.cAccessionNo.Caption = "Accession No";
            this.cAccessionNo.FieldName = "Accession_No";
            this.cAccessionNo.Name = "cAccessionNo";
            this.cAccessionNo.OptionsColumn.AllowEdit = false;
            this.cAccessionNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.cAccessionNo.OptionsFilter.AllowAutoFilter = false;
            this.cAccessionNo.OptionsFilter.AllowFilter = false;
            this.cAccessionNo.Visible = true;
            this.cAccessionNo.VisibleIndex = 1;
            this.cAccessionNo.Width = 114;
            // 
            // cSlide
            // 
            this.cSlide.Caption = "Slide";
            this.cSlide.FieldName = "Slide";
            this.cSlide.Name = "cSlide";
            this.cSlide.OptionsColumn.AllowEdit = false;
            this.cSlide.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.cSlide.OptionsFilter.AllowAutoFilter = false;
            this.cSlide.OptionsFilter.AllowFilter = false;
            this.cSlide.Visible = true;
            this.cSlide.VisibleIndex = 2;
            // 
            // cDescription
            // 
            this.cDescription.Caption = "Description";
            this.cDescription.ColumnEdit = this.rDescription;
            this.cDescription.FieldName = "Description";
            this.cDescription.Name = "cDescription";
            this.cDescription.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.cDescription.OptionsFilter.AllowAutoFilter = false;
            this.cDescription.OptionsFilter.AllowFilter = false;
            this.cDescription.Visible = true;
            this.cDescription.VisibleIndex = 3;
            this.cDescription.Width = 343;
            // 
            // rDescription
            // 
            this.rDescription.AccessibleName = "rDescription";
            this.rDescription.AutoHeight = false;
            this.rDescription.Name = "rDescription";
            this.rDescription.NullText = "Up";
            this.rDescription.Tag = "rDescription";
            this.rDescription.Leave += new System.EventHandler(this.rDescription_Leave);
            // 
            // gActive
            // 
            this.gActive.Caption = "Active";
            this.gActive.ColumnEdit = this.rActive;
            this.gActive.FieldName = "Active";
            this.gActive.Name = "gActive";
            this.gActive.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gActive.OptionsFilter.AllowAutoFilter = false;
            this.gActive.OptionsFilter.AllowFilter = false;
            this.gActive.Visible = true;
            this.gActive.VisibleIndex = 7;
            this.gActive.Width = 59;
            // 
            // rActive
            // 
            this.rActive.AccessibleName = "rPhoneShow";
            this.rActive.AutoHeight = false;
            this.rActive.Name = "rActive";
            this.rActive.CheckedChanged += new System.EventHandler(this.rActive_CheckedChanged);
            // 
            // bPowerPoint
            // 
            this.bPowerPoint.Location = new System.Drawing.Point(185, 46);
            this.bPowerPoint.Name = "bPowerPoint";
            this.bPowerPoint.Size = new System.Drawing.Size(156, 40);
            this.bPowerPoint.TabIndex = 6;
            this.bPowerPoint.Text = "Create PowerPoint";
            this.bPowerPoint.Click += new System.EventHandler(this.bPowerPoint_Click);
            // 
            // bFolder
            // 
            this.bFolder.Location = new System.Drawing.Point(568, 46);
            this.bFolder.Name = "bFolder";
            this.bFolder.Size = new System.Drawing.Size(156, 40);
            this.bFolder.TabIndex = 5;
            this.bFolder.Text = "View Conference Folder";
            this.bFolder.Click += new System.EventHandler(this.bFolder_Click);
            // 
            // gSortOrder
            // 
            this.gSortOrder.Caption = "Order";
            this.gSortOrder.FieldName = "Sort_Order";
            this.gSortOrder.Name = "gSortOrder";
            this.gSortOrder.Visible = true;
            this.gSortOrder.VisibleIndex = 4;
            // 
            // gcUp
            // 
            this.gcUp.Caption = "Up";
            this.gcUp.ColumnEdit = this.bUp;
            this.gcUp.Name = "gcUp";
            this.gcUp.Visible = true;
            this.gcUp.VisibleIndex = 5;
            // 
            // bUp
            // 
            this.bUp.AutoHeight = false;
            this.bUp.Name = "bUp";
            this.bUp.NullText = "Up";
            this.bUp.Click += new System.EventHandler(this.bUp_Click);
            // 
            // cDown
            // 
            this.cDown.Caption = "Down";
            this.cDown.ColumnEdit = this.bDown;
            this.cDown.Name = "cDown";
            this.cDown.Visible = true;
            this.cDown.VisibleIndex = 6;
            // 
            // bDown
            // 
            this.bDown.AutoHeight = false;
            this.bDown.Name = "bDown";
            this.bDown.NullText = "Down";
            this.bDown.Click += new System.EventHandler(this.bDown_Click);
            // 
            // cConference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pStep3);
            this.Controls.Add(this.pStep2);
            this.Controls.Add(this.pStep1);
            this.Name = "cConference";
            this.Size = new System.Drawing.Size(930, 990);
            ((System.ComponentModel.ISupportInitialize)(this.pStep1)).EndInit();
            this.pStep1.ResumeLayout(false);
            this.pStep1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbNewConference.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pStep2)).EndInit();
            this.pStep2.ResumeLayout(false);
            this.pStep2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pStep3)).EndInit();
            this.pStep3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcConference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pStep1;
        private System.Windows.Forms.Label lNewConference;
        private System.Windows.Forms.Label lMyConferences;
        private System.Windows.Forms.ComboBox cbConferences;
        private DevExpress.XtraEditors.SimpleButton bNewConference;
        private DevExpress.XtraEditors.TextEdit tbNewConference;
        private DevExpress.XtraEditors.PanelControl pStep2;
        private DevExpress.XtraEditors.SimpleButton bTakePicture;
        private DevExpress.XtraEditors.PanelControl pStep3;
        private DevExpress.XtraEditors.SimpleButton bFolder;
        private DevExpress.XtraEditors.SimpleButton bDelete;
        private System.Windows.Forms.Label lCase;
        private DevExpress.XtraEditors.SimpleButton bChangeCase;
        private DevExpress.XtraEditors.SimpleButton bPowerPoint;
        private DevExpress.XtraGrid.GridControl gcConference;
        private DevExpress.XtraGrid.Views.Grid.GridView gvConference;
        private DevExpress.XtraGrid.Columns.GridColumn cDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rDescription;
        private DevExpress.XtraGrid.Columns.GridColumn cConferenceImageID;
        private DevExpress.XtraGrid.Columns.GridColumn gActive;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rActive;
        private DevExpress.XtraGrid.Columns.GridColumn cAccessionNo;
        private DevExpress.XtraGrid.Columns.GridColumn cFileName;
        private DevExpress.XtraGrid.Columns.GridColumn cSlide;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rFile;
        private DevExpress.XtraEditors.SimpleButton bReconcile;
        private DevExpress.XtraEditors.SimpleButton bWebsite;
        private DevExpress.XtraGrid.Columns.GridColumn gSortOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gcUp;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit bUp;
        private DevExpress.XtraGrid.Columns.GridColumn cDown;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit bDown;
    }
}
