namespace INVENTORY.UI
{
    partial class fNewProductControl
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.grdProducts = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnCom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnCate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Color = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnSize = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(604, 7);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(60, 19);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "lblTotal";
            // 
            // grdProducts
            // 
            this.grdProducts.Location = new System.Drawing.Point(3, 3);
            this.grdProducts.LookAndFeel.SkinMaskColor = System.Drawing.Color.SlateGray;
            this.grdProducts.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.SlateGray;
            this.grdProducts.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdProducts.LookAndFeel.UseWindowsXPTheme = true;
            this.grdProducts.MainView = this.gridView1;
            this.grdProducts.Name = "grdProducts";
            this.grdProducts.Size = new System.Drawing.Size(469, 383);
            this.grdProducts.TabIndex = 17;
            this.grdProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdProducts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdProducts_MouseDoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clnCode,
            this.clnName,
            this.clnCom,
            this.clnCate,
            this.Color,
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
            this.clnName.Width = 114;
            // 
            // clnCom
            // 
            this.clnCom.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnCom.AppearanceCell.Options.UseFont = true;
            this.clnCom.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnCom.AppearanceHeader.Options.UseFont = true;
            this.clnCom.Caption = "Company";
            this.clnCom.FieldName = "Company";
            this.clnCom.Name = "clnCom";
            this.clnCom.OptionsColumn.AllowEdit = false;
            this.clnCom.Visible = true;
            this.clnCom.VisibleIndex = 2;
            this.clnCom.Width = 90;
            // 
            // clnCate
            // 
            this.clnCate.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnCate.AppearanceCell.Options.UseFont = true;
            this.clnCate.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnCate.AppearanceHeader.Options.UseFont = true;
            this.clnCate.Caption = "Category";
            this.clnCate.FieldName = "Category";
            this.clnCate.Name = "clnCate";
            this.clnCate.OptionsColumn.AllowEdit = false;
            this.clnCate.Visible = true;
            this.clnCate.VisibleIndex = 3;
            // 
            // Color
            // 
            this.Color.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Color.AppearanceCell.Options.UseFont = true;
            this.Color.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Color.AppearanceHeader.Options.UseFont = true;
            this.Color.Caption = "Color";
            this.Color.FieldName = "Color";
            this.Color.Name = "Color";
            this.Color.Visible = true;
            this.Color.VisibleIndex = 4;
            this.Color.Width = 70;
            // 
            // clnSize
            // 
            this.clnSize.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnSize.AppearanceCell.Options.UseFont = true;
            this.clnSize.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnSize.AppearanceHeader.Options.UseFont = true;
            this.clnSize.Caption = "BarCode";
            this.clnSize.FieldName = "Size";
            this.clnSize.Name = "clnSize";
            this.clnSize.Visible = true;
            this.clnSize.VisibleIndex = 5;
            this.clnSize.Width = 94;
            // 
            // fNewProductControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(474, 388);
            this.Controls.Add(this.grdProducts);
            this.Controls.Add(this.lblTotal);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fNewProductControl";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product Control";
            this.Load += new System.EventHandler(this.fProductControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private DevExpress.XtraGrid.GridControl grdProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clnCode;
        private DevExpress.XtraGrid.Columns.GridColumn clnName;
        private DevExpress.XtraGrid.Columns.GridColumn clnCom;
        private DevExpress.XtraGrid.Columns.GridColumn clnCate;
        private DevExpress.XtraGrid.Columns.GridColumn clnSize;
        private DevExpress.XtraGrid.Columns.GridColumn Color;

    }
}