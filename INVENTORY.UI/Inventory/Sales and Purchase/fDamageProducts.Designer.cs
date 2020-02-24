namespace INVENTORY.UI
{
    partial class fDamageProducts
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grdDProducts = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnEDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnPRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnTPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDProducts)).BeginInit();
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
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(624, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 531);
            this.panel1.TabIndex = 7;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(16, 498);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(65, 21);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "lblTotal";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(7, 6);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(99, 32);
            this.btnNew.TabIndex = 0;
            this.btnNew.Tag = "btnAdd";
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(7, 70);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 32);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(7, 38);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(99, 32);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "btnEdit";
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(6, 187);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 32);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "btnDelete";
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grdDProducts
            // 
            this.grdDProducts.Location = new System.Drawing.Point(6, 8);
            this.grdDProducts.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdDProducts.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdDProducts.LookAndFeel.UseWindowsXPTheme = true;
            this.grdDProducts.MainView = this.gridView1;
            this.grdDProducts.Name = "grdDProducts";
            this.grdDProducts.Size = new System.Drawing.Size(612, 532);
            this.grdDProducts.TabIndex = 8;
            this.grdDProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clnID,
            this.clnEDate,
            this.clnProduct,
            this.clnQty,
            this.clnPRate,
            this.clnTPrice});
            this.gridView1.GridControl = this.grdDProducts;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // clnID
            // 
            this.clnID.Caption = "ID";
            this.clnID.FieldName = "ID";
            this.clnID.Name = "clnID";
            this.clnID.Width = 30;
            // 
            // clnEDate
            // 
            this.clnEDate.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnEDate.AppearanceCell.Options.UseFont = true;
            this.clnEDate.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnEDate.AppearanceHeader.Options.UseFont = true;
            this.clnEDate.Caption = "Entry Date";
            this.clnEDate.FieldName = "EDate";
            this.clnEDate.Name = "clnEDate";
            this.clnEDate.OptionsColumn.AllowEdit = false;
            this.clnEDate.Visible = true;
            this.clnEDate.VisibleIndex = 0;
            this.clnEDate.Width = 112;
            // 
            // clnProduct
            // 
            this.clnProduct.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnProduct.AppearanceCell.Options.UseFont = true;
            this.clnProduct.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnProduct.AppearanceHeader.Options.UseFont = true;
            this.clnProduct.Caption = "Product";
            this.clnProduct.FieldName = "Product";
            this.clnProduct.Name = "clnProduct";
            this.clnProduct.OptionsColumn.AllowEdit = false;
            this.clnProduct.Visible = true;
            this.clnProduct.VisibleIndex = 1;
            this.clnProduct.Width = 112;
            // 
            // clnQty
            // 
            this.clnQty.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnQty.AppearanceCell.Options.UseFont = true;
            this.clnQty.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnQty.AppearanceHeader.Options.UseFont = true;
            this.clnQty.Caption = "Qty";
            this.clnQty.FieldName = "Qty";
            this.clnQty.Name = "clnQty";
            this.clnQty.Visible = true;
            this.clnQty.VisibleIndex = 2;
            this.clnQty.Width = 112;
            // 
            // clnPRate
            // 
            this.clnPRate.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnPRate.AppearanceCell.Options.UseFont = true;
            this.clnPRate.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnPRate.AppearanceHeader.Options.UseFont = true;
            this.clnPRate.Caption = "P. Rate";
            this.clnPRate.FieldName = "PRate";
            this.clnPRate.Name = "clnPRate";
            this.clnPRate.Visible = true;
            this.clnPRate.VisibleIndex = 3;
            this.clnPRate.Width = 112;
            // 
            // clnTPrice
            // 
            this.clnTPrice.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnTPrice.AppearanceCell.Options.UseFont = true;
            this.clnTPrice.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnTPrice.AppearanceHeader.Options.UseFont = true;
            this.clnTPrice.Caption = "Total Price";
            this.clnTPrice.FieldName = "TPrice";
            this.clnTPrice.Name = "clnTPrice";
            this.clnTPrice.Visible = true;
            this.clnTPrice.VisibleIndex = 4;
            this.clnTPrice.Width = 116;
            // 
            // fDamageProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(741, 545);
            this.Controls.Add(this.grdDProducts);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fDamageProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Damage Products";
            this.Load += new System.EventHandler(this.fDamageProducts_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDProducts)).EndInit();
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
        private DevExpress.XtraGrid.GridControl grdDProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clnID;
        private DevExpress.XtraGrid.Columns.GridColumn clnEDate;
        private DevExpress.XtraGrid.Columns.GridColumn clnProduct;
        private DevExpress.XtraGrid.Columns.GridColumn clnQty;
        private DevExpress.XtraGrid.Columns.GridColumn clnPRate;
        private DevExpress.XtraGrid.Columns.GridColumn clnTPrice;
    }
}