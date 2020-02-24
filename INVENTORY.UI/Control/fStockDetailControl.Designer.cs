namespace INVENTORY.UI
{
    partial class fStockDetailControl
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.lblTotal = new System.Windows.Forms.Label();
            this.grdItems = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Color = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IMEI = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(642, 9);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(60, 19);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "lblTotal";
            // 
            // grdItems
            // 
            gridLevelNode1.RelationName = "Level1";
            this.grdItems.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdItems.Location = new System.Drawing.Point(3, 3);
            this.grdItems.LookAndFeel.SkinMaskColor = System.Drawing.Color.SlateGray;
            this.grdItems.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.SlateGray;
            this.grdItems.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdItems.LookAndFeel.UseWindowsXPTheme = true;
            this.grdItems.MainView = this.gridView1;
            this.grdItems.Name = "grdItems";
            this.grdItems.Size = new System.Drawing.Size(503, 391);
            this.grdItems.TabIndex = 15;
            this.grdItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdItems_MouseDoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clnProduct,
            this.clnCompany,
            this.clnCategory,
            this.Color,
            this.IMEI});
            this.gridView1.GridControl = this.grdItems;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // clnProduct
            // 
            this.clnProduct.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnProduct.AppearanceCell.Options.UseFont = true;
            this.clnProduct.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnProduct.AppearanceHeader.Options.UseFont = true;
            this.clnProduct.Caption = "Model Name";
            this.clnProduct.FieldName = "Name";
            this.clnProduct.Name = "clnProduct";
            this.clnProduct.OptionsColumn.AllowEdit = false;
            this.clnProduct.Visible = true;
            this.clnProduct.VisibleIndex = 0;
            this.clnProduct.Width = 157;
            // 
            // clnCompany
            // 
            this.clnCompany.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnCompany.AppearanceCell.Options.UseFont = true;
            this.clnCompany.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnCompany.AppearanceHeader.Options.UseFont = true;
            this.clnCompany.Caption = "Company";
            this.clnCompany.FieldName = "Company";
            this.clnCompany.Name = "clnCompany";
            this.clnCompany.OptionsColumn.AllowEdit = false;
            this.clnCompany.Visible = true;
            this.clnCompany.VisibleIndex = 2;
            this.clnCompany.Width = 126;
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
            this.clnCategory.VisibleIndex = 1;
            this.clnCategory.Width = 144;
            // 
            // Color
            // 
            this.Color.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Color.AppearanceCell.Options.UseFont = true;
            this.Color.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Color.AppearanceHeader.Options.UseFont = true;
            this.Color.Caption = "Color";
            this.Color.FieldName = "Color";
            this.Color.Name = "Color";
            this.Color.Visible = true;
            this.Color.VisibleIndex = 3;
            this.Color.Width = 67;
            // 
            // IMEI
            // 
            this.IMEI.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IMEI.AppearanceCell.Options.UseFont = true;
            this.IMEI.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IMEI.AppearanceHeader.Options.UseFont = true;
            this.IMEI.Caption = "IMEI";
            this.IMEI.FieldName = "IMEI";
            this.IMEI.Name = "IMEI";
            this.IMEI.Visible = true;
            this.IMEI.VisibleIndex = 4;
            this.IMEI.Width = 194;
            // 
            // fStockDetailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(499, 395);
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.lblTotal);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fStockDetailControl";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Control";
            this.Load += new System.EventHandler(this.fProductControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private DevExpress.XtraGrid.GridControl grdItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clnProduct;
        private DevExpress.XtraGrid.Columns.GridColumn clnCompany;
        private DevExpress.XtraGrid.Columns.GridColumn clnCategory;
        private DevExpress.XtraGrid.Columns.GridColumn Color;
        private DevExpress.XtraGrid.Columns.GridColumn IMEI;

    }
}