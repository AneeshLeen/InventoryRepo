namespace INVENTORY.UI
{
    partial class fProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fProducts));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grdProducts = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(24, 36);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 81);
            this.panel1.TabIndex = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(9, 557);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(60, 19);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "lblTotal";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNew.Location = new System.Drawing.Point(4, 3);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(92, 72);
            this.btnNew.TabIndex = 0;
            this.btnNew.Tag = "btnAdd";
            this.btnNew.Text = "&New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(366, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 72);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEdit.Location = new System.Drawing.Point(94, 3);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(92, 72);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "btnEdit";
            this.btnEdit.Text = "&Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReport.Location = new System.Drawing.Point(275, 2);
            this.btnReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(92, 72);
            this.btnReport.TabIndex = 2;
            this.btnReport.Tag = "";
            this.btnReport.Text = "&Print";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(184, 3);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 72);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "btnDelete";
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(390, -6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 41);
            this.label1.TabIndex = 17;
            this.label1.Text = "Items";
            // 
            // grdProducts
            // 
            this.grdProducts.Location = new System.Drawing.Point(24, 119);
            this.grdProducts.LookAndFeel.SkinMaskColor = System.Drawing.Color.SlateGray;
            this.grdProducts.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.SlateGray;
            this.grdProducts.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdProducts.LookAndFeel.UseWindowsXPTheme = true;
            this.grdProducts.MainView = this.gridView1;
            this.grdProducts.Name = "grdProducts";
            this.grdProducts.Size = new System.Drawing.Size(459, 421);
            this.grdProducts.TabIndex = 10;
            this.grdProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdProducts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdProducts_MouseDoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clnCode,
            this.clnName,
            this.clnCompany,
            this.clnCategory,
            this.clnSize});
            this.gridView1.GridControl = this.grdProducts;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // clnCode
            // 
            this.clnCode.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnCode.AppearanceCell.Options.UseFont = true;
            this.clnCode.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnCode.AppearanceHeader.Options.UseFont = true;
            this.clnCode.Caption = "Code";
            this.clnCode.FieldName = "Code";
            this.clnCode.Name = "clnCode";
            this.clnCode.OptionsColumn.AllowEdit = false;
            this.clnCode.Visible = true;
            this.clnCode.VisibleIndex = 0;
            this.clnCode.Width = 71;
            // 
            // clnName
            // 
            this.clnName.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnName.AppearanceCell.Options.UseFont = true;
            this.clnName.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnName.AppearanceHeader.Options.UseFont = true;
            this.clnName.Caption = "Name";
            this.clnName.FieldName = "Name";
            this.clnName.Name = "clnName";
            this.clnName.OptionsColumn.AllowEdit = false;
            this.clnName.Visible = true;
            this.clnName.VisibleIndex = 1;
            this.clnName.Width = 162;
            // 
            // clnCompany
            // 
            this.clnCompany.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnCompany.AppearanceCell.Options.UseFont = true;
            this.clnCompany.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnCompany.AppearanceHeader.Options.UseFont = true;
            this.clnCompany.Caption = "Brand";
            this.clnCompany.FieldName = "Company";
            this.clnCompany.Name = "clnCompany";
            this.clnCompany.OptionsColumn.AllowEdit = false;
            this.clnCompany.Visible = true;
            this.clnCompany.VisibleIndex = 3;
            this.clnCompany.Width = 230;
            // 
            // clnCategory
            // 
            this.clnCategory.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnCategory.AppearanceCell.Options.UseFont = true;
            this.clnCategory.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnCategory.AppearanceHeader.Options.UseFont = true;
            this.clnCategory.Caption = "Category";
            this.clnCategory.FieldName = "Category";
            this.clnCategory.Name = "clnCategory";
            this.clnCategory.OptionsColumn.AllowEdit = false;
            this.clnCategory.Visible = true;
            this.clnCategory.VisibleIndex = 2;
            this.clnCategory.Width = 148;
            // 
            // clnSize
            // 
            this.clnSize.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnSize.AppearanceCell.Options.UseFont = true;
            this.clnSize.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnSize.AppearanceHeader.Options.UseFont = true;
            this.clnSize.Caption = "Size/Color";
            this.clnSize.FieldName = "Size";
            this.clnSize.Name = "clnSize";
            this.clnSize.Width = 143;
            // 
            // fProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1298, 630);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdProducts);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(160, 120);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fProducts";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Product Module";
            this.Load += new System.EventHandler(this.fProducts_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label lblTotal;
        private DevExpress.XtraGrid.GridControl grdProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clnCode;
        private DevExpress.XtraGrid.Columns.GridColumn clnName;
        private DevExpress.XtraGrid.Columns.GridColumn clnCompany;
        private DevExpress.XtraGrid.Columns.GridColumn clnCategory;
        private DevExpress.XtraGrid.Columns.GridColumn clnSize;
        private System.Windows.Forms.Label label1;
    }
}