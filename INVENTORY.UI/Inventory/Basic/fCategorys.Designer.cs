namespace INVENTORY.UI
{
    partial class fCategorys
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCategorys));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grdCategorys = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnTaxPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnCategoryType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCategorys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(37, 67);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 91);
            this.panel1.TabIndex = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(17, 152);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(60, 19);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "lblTotal";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(5, 8);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(93, 81);
            this.btnNew.TabIndex = 0;
            this.btnNew.Tag = "btnAdd";
            this.btnNew.Text = "&New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(302, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 81);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(104, 8);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 81);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "btnEdit";
            this.btnEdit.Text = "&Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(202, 8);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 81);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "btnDelete";
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grdCategorys
            // 
            gridLevelNode1.RelationName = "Level1";
            this.grdCategorys.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdCategorys.Location = new System.Drawing.Point(37, 165);
            this.grdCategorys.LookAndFeel.SkinMaskColor = System.Drawing.Color.SlateGray;
            this.grdCategorys.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.SlateGray;
            this.grdCategorys.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdCategorys.LookAndFeel.UseWindowsXPTheme = true;
            this.grdCategorys.MainView = this.gridView1;
            this.grdCategorys.Name = "grdCategorys";
            this.grdCategorys.Size = new System.Drawing.Size(408, 294);
            this.grdCategorys.TabIndex = 7;
            this.grdCategorys.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdCategorys.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdCategorys_MouseDoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clnCode,
            this.clnName,
            this.clnTaxPercentage,
            this.clnCategoryType});
            this.gridView1.GridControl = this.grdCategorys;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // clnCode
            // 
            this.clnCode.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnCode.AppearanceCell.Options.UseFont = true;
            this.clnCode.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnCode.AppearanceHeader.Options.UseFont = true;
            this.clnCode.Caption = "Code";
            this.clnCode.FieldName = "Code";
            this.clnCode.Name = "clnCode";
            this.clnCode.OptionsColumn.AllowEdit = false;
            this.clnCode.Visible = true;
            this.clnCode.VisibleIndex = 0;
            this.clnCode.Width = 123;
            // 
            // clnName
            // 
            this.clnName.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnName.AppearanceCell.Options.UseFont = true;
            this.clnName.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnName.AppearanceHeader.Options.UseFont = true;
            this.clnName.Caption = "Name";
            this.clnName.FieldName = "Name";
            this.clnName.Name = "clnName";
            this.clnName.OptionsColumn.AllowEdit = false;
            this.clnName.Visible = true;
            this.clnName.VisibleIndex = 1;
            this.clnName.Width = 296;
            // 
            // clnTaxPercentage
            // 
            this.clnTaxPercentage.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnTaxPercentage.AppearanceCell.Options.UseFont = true;
            this.clnTaxPercentage.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnTaxPercentage.AppearanceHeader.Options.UseFont = true;
            this.clnTaxPercentage.Caption = "Tax%";
            this.clnTaxPercentage.FieldName = "TaxPercentage";
            this.clnTaxPercentage.Name = "clnTaxPercentage";
            this.clnTaxPercentage.OptionsColumn.AllowEdit = false;
            this.clnTaxPercentage.Visible = true;
            this.clnTaxPercentage.VisibleIndex = 2;
            this.clnTaxPercentage.Width = 123;
            // 
            // clnCategoryType
            // 
            this.clnCategoryType.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnCategoryType.AppearanceCell.Options.UseFont = true;
            this.clnCategoryType.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnCategoryType.AppearanceHeader.Options.UseFont = true;
            this.clnCategoryType.Caption = "Category";
            this.clnCategoryType.FieldName = "CategoryType";
            this.clnCategoryType.Name = "clnCategoryType";
            this.clnCategoryType.OptionsColumn.AllowEdit = false;
            this.clnCategoryType.Visible = true;
            this.clnCategoryType.VisibleIndex = 3;
            this.clnCategoryType.Width = 123;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 54);
            this.label1.TabIndex = 17;
            this.label1.Text = "Department";
            // 
            // fCategorys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1279, 564);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdCategorys);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(160, 120);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fCategorys";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "All Category";
            this.Load += new System.EventHandler(this.fCategorys_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCategorys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblTotal;
        private DevExpress.XtraGrid.GridControl grdCategorys;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clnCode;
        private DevExpress.XtraGrid.Columns.GridColumn clnName;
        private DevExpress.XtraGrid.Columns.GridColumn clnTaxPercentage;
        private DevExpress.XtraGrid.Columns.GridColumn clnCategoryType;
        private System.Windows.Forms.Label label1;
    }
}