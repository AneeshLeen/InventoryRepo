namespace INVENTORY.UI
{
    partial class fPurchaseOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fPurchaseOrders));
            this.tbcPurchaseOrder = new System.Windows.Forms.TabControl();
            this.tbPOrder = new System.Windows.Forms.TabPage();
            this.tbpStock = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdStocks = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnSCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnTPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnSStockID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnStockEdit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numChangePrice = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numCurrPrice = new System.Windows.Forms.NumericUpDown();
            this.lblStockTotal = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnPOInvoice = new System.Windows.Forms.Button();
            this.btnBGen = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPOrderNew = new System.Windows.Forms.Button();
            this.btnPOrderClose = new System.Windows.Forms.Button();
            this.btnPOrderDelete = new System.Windows.Forms.Button();
            this.grdPOrders = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnODate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnChallanNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnSName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnComName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnContactNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnStockID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnNetAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnPaidAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnPaymentDue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbcPurchaseOrder.SuspendLayout();
            this.tbpStock.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStocks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrPrice)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcPurchaseOrder
            // 
            this.tbcPurchaseOrder.Controls.Add(this.tbPOrder);
            this.tbcPurchaseOrder.Controls.Add(this.tbpStock);
            this.tbcPurchaseOrder.Location = new System.Drawing.Point(27, 411);
            this.tbcPurchaseOrder.Name = "tbcPurchaseOrder";
            this.tbcPurchaseOrder.SelectedIndex = 0;
            this.tbcPurchaseOrder.Size = new System.Drawing.Size(65, 84);
            this.tbcPurchaseOrder.TabIndex = 0;
            this.tbcPurchaseOrder.Visible = false;
            this.tbcPurchaseOrder.SelectedIndexChanged += new System.EventHandler(this.tbcPurchaseOrder_SelectedIndexChanged);
            // 
            // tbPOrder
            // 
            this.tbPOrder.BackColor = System.Drawing.Color.SlateGray;
            this.tbPOrder.Location = new System.Drawing.Point(4, 27);
            this.tbPOrder.Name = "tbPOrder";
            this.tbPOrder.Size = new System.Drawing.Size(57, 53);
            this.tbPOrder.TabIndex = 3;
            this.tbPOrder.Text = "Purchase Order";
            // 
            // tbpStock
            // 
            this.tbpStock.BackColor = System.Drawing.Color.SlateGray;
            this.tbpStock.Controls.Add(this.groupBox3);
            this.tbpStock.Location = new System.Drawing.Point(4, 27);
            this.tbpStock.Name = "tbpStock";
            this.tbpStock.Size = new System.Drawing.Size(57, 53);
            this.tbpStock.TabIndex = 2;
            this.tbpStock.Text = "Stock";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdStocks);
            this.groupBox3.Controls.Add(this.btnStockEdit);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.numChangePrice);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.numCurrPrice);
            this.groupBox3.Controls.Add(this.lblStockTotal);
            this.groupBox3.Location = new System.Drawing.Point(6, -3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(946, 590);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // grdStocks
            // 
            this.grdStocks.Location = new System.Drawing.Point(7, 78);
            this.grdStocks.LookAndFeel.SkinMaskColor = System.Drawing.Color.SlateGray;
            this.grdStocks.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.SlateGray;
            this.grdStocks.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdStocks.LookAndFeel.UseWindowsXPTheme = true;
            this.grdStocks.MainView = this.gridView3;
            this.grdStocks.Name = "grdStocks";
            this.grdStocks.Size = new System.Drawing.Size(916, 506);
            this.grdStocks.TabIndex = 37;
            this.grdStocks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3,
            this.gridView2});
            this.grdStocks.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdStocks_MouseDoubleClick);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gridView3.GridControl = this.grdStocks;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsFind.AlwaysVisible = true;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "Stock Code";
            this.gridColumn2.FieldName = "StockCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "Product Name";
            this.gridColumn3.FieldName = "ProductName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 151;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "Category";
            this.gridColumn4.FieldName = "Category";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 143;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.Caption = "Company";
            this.gridColumn5.FieldName = "Company";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 120;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "Qty";
            this.gridColumn6.FieldName = "Qty";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 78;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.Caption = "Pur.Rate";
            this.gridColumn7.FieldName = "PurRate";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 99;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.Caption = "Total Price";
            this.gridColumn8.FieldName = "TotalPrice";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            this.gridColumn8.Width = 108;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "StockID";
            this.gridColumn9.FieldName = "StockID";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Width = 41;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11.25F);
            this.gridColumn10.AppearanceCell.Options.UseFont = true;
            this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridColumn10.AppearanceHeader.Options.UseFont = true;
            this.gridColumn10.Caption = "MRP";
            this.gridColumn10.FieldName = "MRP";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            this.gridColumn10.Width = 95;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn11.AppearanceCell.Options.UseFont = true;
            this.gridColumn11.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn11.AppearanceHeader.Options.UseFont = true;
            this.gridColumn11.Caption = "Color";
            this.gridColumn11.FieldName = "Color";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn11.Width = 107;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clnSCode,
            this.clnProduct,
            this.clnCategory,
            this.clnCompany,
            this.clnQty,
            this.clnRate,
            this.clnTPrice,
            this.clnSStockID,
            this.gridColumn1,
            this.clnColor});
            this.gridView2.GridControl = this.grdStocks;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsFind.AlwaysVisible = true;
            // 
            // clnSCode
            // 
            this.clnSCode.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnSCode.AppearanceCell.Options.UseFont = true;
            this.clnSCode.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnSCode.AppearanceHeader.Options.UseFont = true;
            this.clnSCode.Caption = "Stock Code";
            this.clnSCode.FieldName = "StockCode";
            this.clnSCode.Name = "clnSCode";
            this.clnSCode.OptionsColumn.AllowEdit = false;
            this.clnSCode.Visible = true;
            this.clnSCode.VisibleIndex = 0;
            this.clnSCode.Width = 82;
            // 
            // clnProduct
            // 
            this.clnProduct.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnProduct.AppearanceCell.Options.UseFont = true;
            this.clnProduct.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnProduct.AppearanceHeader.Options.UseFont = true;
            this.clnProduct.Caption = "Product Name";
            this.clnProduct.FieldName = "ProductName";
            this.clnProduct.Name = "clnProduct";
            this.clnProduct.OptionsColumn.AllowEdit = false;
            this.clnProduct.Visible = true;
            this.clnProduct.VisibleIndex = 1;
            this.clnProduct.Width = 154;
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
            this.clnCategory.Width = 146;
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
            this.clnCompany.VisibleIndex = 3;
            this.clnCompany.Width = 123;
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
            this.clnQty.OptionsColumn.AllowEdit = false;
            this.clnQty.Visible = true;
            this.clnQty.VisibleIndex = 4;
            this.clnQty.Width = 80;
            // 
            // clnRate
            // 
            this.clnRate.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnRate.AppearanceCell.Options.UseFont = true;
            this.clnRate.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnRate.AppearanceHeader.Options.UseFont = true;
            this.clnRate.Caption = "Pur.Rate";
            this.clnRate.FieldName = "PurRate";
            this.clnRate.Name = "clnRate";
            this.clnRate.OptionsColumn.AllowEdit = false;
            this.clnRate.Visible = true;
            this.clnRate.VisibleIndex = 5;
            this.clnRate.Width = 101;
            // 
            // clnTPrice
            // 
            this.clnTPrice.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnTPrice.AppearanceCell.Options.UseFont = true;
            this.clnTPrice.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnTPrice.AppearanceHeader.Options.UseFont = true;
            this.clnTPrice.Caption = "Total Price";
            this.clnTPrice.FieldName = "TotalPrice";
            this.clnTPrice.Name = "clnTPrice";
            this.clnTPrice.OptionsColumn.AllowEdit = false;
            this.clnTPrice.Visible = true;
            this.clnTPrice.VisibleIndex = 7;
            this.clnTPrice.Width = 133;
            // 
            // clnSStockID
            // 
            this.clnSStockID.Caption = "StockID";
            this.clnSStockID.FieldName = "StockID";
            this.clnSStockID.Name = "clnSStockID";
            this.clnSStockID.Width = 20;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "MRP";
            this.gridColumn1.FieldName = "MRP";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 98;
            // 
            // clnColor
            // 
            this.clnColor.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnColor.AppearanceCell.Options.UseFont = true;
            this.clnColor.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnColor.AppearanceHeader.Options.UseFont = true;
            this.clnColor.Caption = "Color";
            this.clnColor.FieldName = "Color";
            this.clnColor.Name = "clnColor";
            this.clnColor.Width = 105;
            // 
            // btnStockEdit
            // 
            this.btnStockEdit.Location = new System.Drawing.Point(493, 23);
            this.btnStockEdit.Name = "btnStockEdit";
            this.btnStockEdit.Size = new System.Drawing.Size(93, 31);
            this.btnStockEdit.TabIndex = 2;
            this.btnStockEdit.Text = "&Update";
            this.btnStockEdit.UseVisualStyleBackColor = true;
            this.btnStockEdit.Click += new System.EventHandler(this.btnStockEdit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(269, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 22);
            this.label7.TabIndex = 36;
            this.label7.Text = "New Price";
            // 
            // numChangePrice
            // 
            this.numChangePrice.DecimalPlaces = 2;
            this.numChangePrice.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numChangePrice.Location = new System.Drawing.Point(376, 25);
            this.numChangePrice.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numChangePrice.Name = "numChangePrice";
            this.numChangePrice.Size = new System.Drawing.Size(100, 29);
            this.numChangePrice.TabIndex = 1;
            this.numChangePrice.Enter += new System.EventHandler(this.numChangePrice_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 22);
            this.label6.TabIndex = 35;
            this.label6.Text = "Current. Price";
            // 
            // numCurrPrice
            // 
            this.numCurrPrice.DecimalPlaces = 2;
            this.numCurrPrice.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCurrPrice.Location = new System.Drawing.Point(141, 27);
            this.numCurrPrice.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numCurrPrice.Name = "numCurrPrice";
            this.numCurrPrice.ReadOnly = true;
            this.numCurrPrice.Size = new System.Drawing.Size(112, 29);
            this.numCurrPrice.TabIndex = 0;
            this.numCurrPrice.Enter += new System.EventHandler(this.numCurrPrice_Enter);
            // 
            // lblStockTotal
            // 
            this.lblStockTotal.AutoSize = true;
            this.lblStockTotal.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockTotal.Location = new System.Drawing.Point(961, 19);
            this.lblStockTotal.Name = "lblStockTotal";
            this.lblStockTotal.Size = new System.Drawing.Size(67, 21);
            this.lblStockTotal.TabIndex = 13;
            this.lblStockTotal.Text = "lblStock";
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(128, 483);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(70, 110);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(517, -7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 41);
            this.label1.TabIndex = 18;
            this.label1.Text = "Previous Challan";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnPOInvoice);
            this.groupBox4.Controls.Add(this.btnBGen);
            this.groupBox4.Controls.Add(this.btnEdit);
            this.groupBox4.Controls.Add(this.btnReturn);
            this.groupBox4.Controls.Add(this.lblTotal);
            this.groupBox4.Controls.Add(this.btnPOrderNew);
            this.groupBox4.Controls.Add(this.btnPOrderClose);
            this.groupBox4.Controls.Add(this.btnPOrderDelete);
            this.groupBox4.Location = new System.Drawing.Point(12, 28);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(755, 106);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // btnPOInvoice
            // 
            this.btnPOInvoice.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPOInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnPOInvoice.Image")));
            this.btnPOInvoice.Location = new System.Drawing.Point(215, 18);
            this.btnPOInvoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPOInvoice.Name = "btnPOInvoice";
            this.btnPOInvoice.Size = new System.Drawing.Size(106, 78);
            this.btnPOInvoice.TabIndex = 18;
            this.btnPOInvoice.Tag = "btnAdd";
            this.btnPOInvoice.Text = "&Invoice";
            this.btnPOInvoice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPOInvoice.UseVisualStyleBackColor = true;
            this.btnPOInvoice.Click += new System.EventHandler(this.btnPOInvoice_Click);
            // 
            // btnBGen
            // 
            this.btnBGen.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBGen.Image = ((System.Drawing.Image)(resources.GetObject("btnBGen.Image")));
            this.btnBGen.Location = new System.Drawing.Point(639, 21);
            this.btnBGen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBGen.Name = "btnBGen";
            this.btnBGen.Size = new System.Drawing.Size(106, 78);
            this.btnBGen.TabIndex = 17;
            this.btnBGen.Tag = "btnAdd";
            this.btnBGen.Text = "&Barcode";
            this.btnBGen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBGen.UseVisualStyleBackColor = true;
            this.btnBGen.Visible = false;
            this.btnBGen.Click += new System.EventHandler(this.btnBGen_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(109, 18);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(106, 78);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Tag = "btnEdit";
            this.btnEdit.Text = "&Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Image = ((System.Drawing.Image)(resources.GetObject("btnReturn.Image")));
            this.btnReturn.Location = new System.Drawing.Point(533, 21);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(106, 78);
            this.btnReturn.TabIndex = 13;
            this.btnReturn.Tag = "";
            this.btnReturn.Text = "&Return";
            this.btnReturn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Visible = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(17, 549);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(65, 21);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "lblTotal";
            // 
            // btnPOrderNew
            // 
            this.btnPOrderNew.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPOrderNew.Image = ((System.Drawing.Image)(resources.GetObject("btnPOrderNew.Image")));
            this.btnPOrderNew.Location = new System.Drawing.Point(3, 18);
            this.btnPOrderNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPOrderNew.Name = "btnPOrderNew";
            this.btnPOrderNew.Size = new System.Drawing.Size(106, 78);
            this.btnPOrderNew.TabIndex = 4;
            this.btnPOrderNew.Tag = "btnAdd";
            this.btnPOrderNew.Text = "&New";
            this.btnPOrderNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPOrderNew.UseVisualStyleBackColor = true;
            this.btnPOrderNew.Click += new System.EventHandler(this.btnPOrderNew_Click);
            // 
            // btnPOrderClose
            // 
            this.btnPOrderClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPOrderClose.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPOrderClose.Image = ((System.Drawing.Image)(resources.GetObject("btnPOrderClose.Image")));
            this.btnPOrderClose.Location = new System.Drawing.Point(321, 19);
            this.btnPOrderClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPOrderClose.Name = "btnPOrderClose";
            this.btnPOrderClose.Size = new System.Drawing.Size(106, 78);
            this.btnPOrderClose.TabIndex = 7;
            this.btnPOrderClose.Text = "&Close";
            this.btnPOrderClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPOrderClose.UseVisualStyleBackColor = true;
            this.btnPOrderClose.Click += new System.EventHandler(this.btnPOrderClose_Click);
            // 
            // btnPOrderDelete
            // 
            this.btnPOrderDelete.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPOrderDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnPOrderDelete.Image")));
            this.btnPOrderDelete.Location = new System.Drawing.Point(427, 20);
            this.btnPOrderDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPOrderDelete.Name = "btnPOrderDelete";
            this.btnPOrderDelete.Size = new System.Drawing.Size(106, 78);
            this.btnPOrderDelete.TabIndex = 6;
            this.btnPOrderDelete.Tag = "btnDelete";
            this.btnPOrderDelete.Text = "&Delete";
            this.btnPOrderDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPOrderDelete.UseVisualStyleBackColor = true;
            this.btnPOrderDelete.Visible = false;
            this.btnPOrderDelete.Click += new System.EventHandler(this.btnPOrderDelete_Click);
            // 
            // grdPOrders
            // 
            this.grdPOrders.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPOrders.Location = new System.Drawing.Point(12, 135);
            this.grdPOrders.LookAndFeel.SkinMaskColor = System.Drawing.Color.SlateGray;
            this.grdPOrders.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.SlateGray;
            this.grdPOrders.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdPOrders.LookAndFeel.UseWindowsXPTheme = true;
            this.grdPOrders.MainView = this.gridView1;
            this.grdPOrders.Name = "grdPOrders";
            this.grdPOrders.Size = new System.Drawing.Size(1244, 439);
            this.grdPOrders.TabIndex = 1;
            this.grdPOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdPOrders.Click += new System.EventHandler(this.grdPOrders_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clnODate,
            this.clnChallanNo,
            this.clnSName,
            this.clnComName,
            this.clnContactNo,
            this.clnStatus,
            this.clnStockID,
            this.clnNetAmt,
            this.clnPaidAmt,
            this.clnPaymentDue,
            this.clnAddress});
            this.gridView1.GridControl = this.grdPOrders;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // clnODate
            // 
            this.clnODate.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnODate.AppearanceCell.Options.UseFont = true;
            this.clnODate.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnODate.AppearanceHeader.Options.UseFont = true;
            this.clnODate.Caption = "Pur. Date";
            this.clnODate.FieldName = "OrderDate";
            this.clnODate.Name = "clnODate";
            this.clnODate.OptionsColumn.AllowEdit = false;
            this.clnODate.Visible = true;
            this.clnODate.VisibleIndex = 2;
            this.clnODate.Width = 100;
            // 
            // clnChallanNo
            // 
            this.clnChallanNo.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnChallanNo.AppearanceCell.Options.UseFont = true;
            this.clnChallanNo.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnChallanNo.AppearanceHeader.Options.UseFont = true;
            this.clnChallanNo.Caption = "Challan No";
            this.clnChallanNo.FieldName = "ChallanNo";
            this.clnChallanNo.Name = "clnChallanNo";
            this.clnChallanNo.OptionsColumn.AllowEdit = false;
            this.clnChallanNo.Visible = true;
            this.clnChallanNo.VisibleIndex = 1;
            this.clnChallanNo.Width = 110;
            // 
            // clnSName
            // 
            this.clnSName.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnSName.AppearanceCell.Options.UseFont = true;
            this.clnSName.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnSName.AppearanceHeader.Options.UseFont = true;
            this.clnSName.Caption = "Supplier Name";
            this.clnSName.FieldName = "SupplierName";
            this.clnSName.Name = "clnSName";
            this.clnSName.OptionsColumn.AllowEdit = false;
            this.clnSName.Visible = true;
            this.clnSName.VisibleIndex = 0;
            this.clnSName.Width = 135;
            // 
            // clnComName
            // 
            this.clnComName.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnComName.AppearanceCell.Options.UseFont = true;
            this.clnComName.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnComName.AppearanceHeader.Options.UseFont = true;
            this.clnComName.Caption = "Owner";
            this.clnComName.FieldName = "CompanyName";
            this.clnComName.Name = "clnComName";
            this.clnComName.OptionsColumn.AllowEdit = false;
            this.clnComName.Visible = true;
            this.clnComName.VisibleIndex = 3;
            this.clnComName.Width = 162;
            // 
            // clnContactNo
            // 
            this.clnContactNo.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnContactNo.AppearanceCell.Options.UseFont = true;
            this.clnContactNo.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnContactNo.AppearanceHeader.Options.UseFont = true;
            this.clnContactNo.Caption = "Contact No";
            this.clnContactNo.FieldName = "ContactNo";
            this.clnContactNo.Name = "clnContactNo";
            this.clnContactNo.OptionsColumn.AllowEdit = false;
            this.clnContactNo.Visible = true;
            this.clnContactNo.VisibleIndex = 5;
            this.clnContactNo.Width = 148;
            // 
            // clnStatus
            // 
            this.clnStatus.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnStatus.AppearanceCell.Options.UseFont = true;
            this.clnStatus.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnStatus.AppearanceHeader.Options.UseFont = true;
            this.clnStatus.Caption = "Status";
            this.clnStatus.FieldName = "Status";
            this.clnStatus.Name = "clnStatus";
            this.clnStatus.OptionsColumn.AllowEdit = false;
            this.clnStatus.Width = 115;
            // 
            // clnStockID
            // 
            this.clnStockID.Caption = "StockID";
            this.clnStockID.FieldName = "StockID";
            this.clnStockID.Name = "clnStockID";
            // 
            // clnNetAmt
            // 
            this.clnNetAmt.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnNetAmt.AppearanceCell.Options.UseFont = true;
            this.clnNetAmt.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnNetAmt.AppearanceHeader.Options.UseFont = true;
            this.clnNetAmt.Caption = "NetAmt";
            this.clnNetAmt.FieldName = "NetAmt";
            this.clnNetAmt.Name = "clnNetAmt";
            this.clnNetAmt.Visible = true;
            this.clnNetAmt.VisibleIndex = 6;
            this.clnNetAmt.Width = 84;
            // 
            // clnPaidAmt
            // 
            this.clnPaidAmt.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnPaidAmt.AppearanceCell.Options.UseFont = true;
            this.clnPaidAmt.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnPaidAmt.AppearanceHeader.Options.UseFont = true;
            this.clnPaidAmt.Caption = "PaidAmt";
            this.clnPaidAmt.FieldName = "PaidAmt";
            this.clnPaidAmt.Name = "clnPaidAmt";
            this.clnPaidAmt.Visible = true;
            this.clnPaidAmt.VisibleIndex = 7;
            this.clnPaidAmt.Width = 84;
            // 
            // clnPaymentDue
            // 
            this.clnPaymentDue.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnPaymentDue.AppearanceCell.Options.UseFont = true;
            this.clnPaymentDue.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnPaymentDue.AppearanceHeader.Options.UseFont = true;
            this.clnPaymentDue.Caption = "PaymentDue";
            this.clnPaymentDue.FieldName = "PaymentDue";
            this.clnPaymentDue.Name = "clnPaymentDue";
            this.clnPaymentDue.Visible = true;
            this.clnPaymentDue.VisibleIndex = 8;
            this.clnPaymentDue.Width = 91;
            // 
            // clnAddress
            // 
            this.clnAddress.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnAddress.AppearanceCell.Options.UseFont = true;
            this.clnAddress.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnAddress.AppearanceHeader.Options.UseFont = true;
            this.clnAddress.Caption = "Address";
            this.clnAddress.FieldName = "Address";
            this.clnAddress.Name = "clnAddress";
            this.clnAddress.Visible = true;
            this.clnAddress.VisibleIndex = 4;
            // 
            // fPurchaseOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1268, 652);
            this.Controls.Add(this.grdPOrders);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tbcPurchaseOrder);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(160, 120);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fPurchaseOrders";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "wecoder.com";
            this.Load += new System.EventHandler(this.fPurchaseOrders_Load);
            this.tbcPurchaseOrder.ResumeLayout(false);
            this.tbpStock.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStocks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChangePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrPrice)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbcPurchaseOrder;
        private System.Windows.Forms.TabPage tbpStock;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabPage tbPOrder;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnPOrderNew;
        private System.Windows.Forms.Button btnPOrderClose;
        private System.Windows.Forms.Button btnPOrderDelete;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblStockTotal;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnStockEdit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numChangePrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numCurrPrice;
        private DevExpress.XtraGrid.GridControl grdPOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clnODate;
        private DevExpress.XtraGrid.Columns.GridColumn clnChallanNo;
        private DevExpress.XtraGrid.Columns.GridColumn clnSName;
        private DevExpress.XtraGrid.Columns.GridColumn clnComName;
        private DevExpress.XtraGrid.Columns.GridColumn clnContactNo;
        private DevExpress.XtraGrid.Columns.GridColumn clnStatus;
        private DevExpress.XtraGrid.GridControl grdStocks;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn clnSCode;
        private DevExpress.XtraGrid.Columns.GridColumn clnProduct;
        private DevExpress.XtraGrid.Columns.GridColumn clnCategory;
        private DevExpress.XtraGrid.Columns.GridColumn clnCompany;
        private DevExpress.XtraGrid.Columns.GridColumn clnQty;
        private DevExpress.XtraGrid.Columns.GridColumn clnRate;
        private DevExpress.XtraGrid.Columns.GridColumn clnTPrice;
        private DevExpress.XtraGrid.Columns.GridColumn clnStockID;
        private DevExpress.XtraGrid.Columns.GridColumn clnSStockID;
        private System.Windows.Forms.Button btnBGen;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.Button btnPOInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn clnColor;
        private DevExpress.XtraGrid.Columns.GridColumn clnNetAmt;
        private DevExpress.XtraGrid.Columns.GridColumn clnPaidAmt;
        private DevExpress.XtraGrid.Columns.GridColumn clnPaymentDue;
        private DevExpress.XtraGrid.Columns.GridColumn clnAddress;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private System.Windows.Forms.Label label1;
    }
}