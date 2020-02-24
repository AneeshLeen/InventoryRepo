namespace INVENTORY.UI
{
    partial class fSOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSOrders));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdStocks = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnSCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnTPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnSStockID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblStockTotal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPOS = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grdOrders = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnContactNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnTotalAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnDueAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnRecAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStocks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(987, 415);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(38, 30);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Visible = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.SlateGray;
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(30, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Orders";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.SlateGray;
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(30, 0);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Stock";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdStocks);
            this.groupBox3.Controls.Add(this.lblStockTotal);
            this.groupBox3.Location = new System.Drawing.Point(7, -39);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(926, 523);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // grdStocks
            // 
            this.grdStocks.Location = new System.Drawing.Point(6, 45);
            this.grdStocks.LookAndFeel.SkinMaskColor = System.Drawing.Color.SlateGray;
            this.grdStocks.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.SlateGray;
            this.grdStocks.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdStocks.LookAndFeel.UseWindowsXPTheme = true;
            this.grdStocks.MainView = this.gridView3;
            this.grdStocks.Name = "grdStocks";
            this.grdStocks.Size = new System.Drawing.Size(914, 472);
            this.grdStocks.TabIndex = 38;
            this.grdStocks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3,
            this.gridView2});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gridView3.GridControl = this.grdStocks;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsFind.AlwaysVisible = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "Stock Code";
            this.gridColumn1.FieldName = "StockCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 85;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "Product Name";
            this.gridColumn2.FieldName = "ProductName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 183;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "Category";
            this.gridColumn3.FieldName = "Category";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 154;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "Company";
            this.gridColumn4.FieldName = "Company";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 136;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.Caption = "Qty";
            this.gridColumn5.FieldName = "Qty";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 90;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "Pur.Rate";
            this.gridColumn6.FieldName = "PurRate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 92;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.Caption = "Total Price";
            this.gridColumn7.FieldName = "TotalPrice";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 107;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "StockID";
            this.gridColumn8.FieldName = "StockID";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 51;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn9.AppearanceCell.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.Caption = "Color";
            this.gridColumn9.FieldName = "Color";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 107;
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
            this.clnSCode.Width = 87;
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
            this.clnProduct.Width = 187;
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
            this.clnCategory.Width = 158;
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
            this.clnCompany.Width = 139;
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
            this.clnQty.Width = 92;
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
            this.clnRate.Width = 94;
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
            this.clnTPrice.VisibleIndex = 6;
            this.clnTPrice.Width = 146;
            // 
            // clnSStockID
            // 
            this.clnSStockID.Caption = "StockID";
            this.clnSStockID.FieldName = "StockID";
            this.clnSStockID.Name = "clnSStockID";
            this.clnSStockID.Width = 20;
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
            this.clnColor.Width = 102;
            // 
            // lblStockTotal
            // 
            this.lblStockTotal.AutoSize = true;
            this.lblStockTotal.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockTotal.Location = new System.Drawing.Point(852, 21);
            this.lblStockTotal.Name = "lblStockTotal";
            this.lblStockTotal.Size = new System.Drawing.Size(67, 21);
            this.lblStockTotal.TabIndex = 14;
            this.lblStockTotal.Text = "lblStock";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(944, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(55, 30);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(538, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 41);
            this.label1.TabIndex = 17;
            this.label1.Text = "Previous Sales Invoices";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPOS);
            this.groupBox2.Controls.Add(this.btnReturn);
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.btnInvoice);
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Location = new System.Drawing.Point(34, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(738, 97);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnPOS
            // 
            this.btnPOS.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPOS.Image = ((System.Drawing.Image)(resources.GetObject("btnPOS.Image")));
            this.btnPOS.Location = new System.Drawing.Point(423, 15);
            this.btnPOS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Size = new System.Drawing.Size(106, 78);
            this.btnPOS.TabIndex = 15;
            this.btnPOS.Text = "&POS";
            this.btnPOS.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPOS.UseVisualStyleBackColor = true;
            this.btnPOS.Click += new System.EventHandler(this.btnPOS_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Image = ((System.Drawing.Image)(resources.GetObject("btnReturn.Image")));
            this.btnReturn.Location = new System.Drawing.Point(318, 14);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(106, 78);
            this.btnReturn.TabIndex = 14;
            this.btnReturn.Tag = "";
            this.btnReturn.Text = "&Return";
            this.btnReturn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(18, 539);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(65, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "lblTotal";
            // 
            // btnInvoice
            // 
            this.btnInvoice.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnInvoice.Image")));
            this.btnInvoice.Location = new System.Drawing.Point(214, 14);
            this.btnInvoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(106, 78);
            this.btnInvoice.TabIndex = 2;
            this.btnInvoice.Text = "&Invoice";
            this.btnInvoice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(3, 14);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(106, 78);
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
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(632, 14);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 78);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "&Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(109, 14);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(106, 78);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "btnEdit";
            this.btnEdit.Text = "&Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(528, 14);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(106, 78);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Tag = "btnDelete";
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grdOrders
            // 
            this.grdOrders.Location = new System.Drawing.Point(34, 161);
            this.grdOrders.LookAndFeel.SkinMaskColor = System.Drawing.Color.SlateGray;
            this.grdOrders.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.SlateGray;
            this.grdOrders.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.grdOrders.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdOrders.LookAndFeel.UseWindowsXPTheme = true;
            this.grdOrders.MainView = this.gridView1;
            this.grdOrders.Name = "grdOrders";
            this.grdOrders.Size = new System.Drawing.Size(1193, 389);
            this.grdOrders.TabIndex = 22;
            this.grdOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdOrders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdOrders_MouseDoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clnOrderDate,
            this.clnInvoiceNo,
            this.clnCustomer,
            this.clnContactNo,
            this.clnTotalAmt,
            this.clnDueAmt,
            this.clnStatus,
            this.clnRecAmt,
            this.clnAddress});
            this.gridView1.GridControl = this.grdOrders;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // clnOrderDate
            // 
            this.clnOrderDate.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnOrderDate.AppearanceCell.Options.UseFont = true;
            this.clnOrderDate.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnOrderDate.AppearanceHeader.Options.UseFont = true;
            this.clnOrderDate.Caption = "Sales Date";
            this.clnOrderDate.FieldName = "OrderDate";
            this.clnOrderDate.Name = "clnOrderDate";
            this.clnOrderDate.OptionsColumn.AllowEdit = false;
            this.clnOrderDate.Visible = true;
            this.clnOrderDate.VisibleIndex = 0;
            this.clnOrderDate.Width = 118;
            // 
            // clnInvoiceNo
            // 
            this.clnInvoiceNo.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnInvoiceNo.AppearanceCell.Options.UseFont = true;
            this.clnInvoiceNo.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnInvoiceNo.AppearanceHeader.Options.UseFont = true;
            this.clnInvoiceNo.Caption = "Invoice No";
            this.clnInvoiceNo.FieldName = "InvoiceNo";
            this.clnInvoiceNo.Name = "clnInvoiceNo";
            this.clnInvoiceNo.OptionsColumn.AllowEdit = false;
            this.clnInvoiceNo.Visible = true;
            this.clnInvoiceNo.VisibleIndex = 1;
            this.clnInvoiceNo.Width = 104;
            // 
            // clnCustomer
            // 
            this.clnCustomer.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnCustomer.AppearanceCell.Options.UseFont = true;
            this.clnCustomer.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnCustomer.AppearanceHeader.Options.UseFont = true;
            this.clnCustomer.Caption = "Customer";
            this.clnCustomer.FieldName = "Customer";
            this.clnCustomer.Name = "clnCustomer";
            this.clnCustomer.OptionsColumn.AllowEdit = false;
            this.clnCustomer.Visible = true;
            this.clnCustomer.VisibleIndex = 2;
            this.clnCustomer.Width = 220;
            // 
            // clnContactNo
            // 
            this.clnContactNo.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnContactNo.AppearanceCell.Options.UseFont = true;
            this.clnContactNo.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnContactNo.AppearanceHeader.Options.UseFont = true;
            this.clnContactNo.Caption = "Contact No";
            this.clnContactNo.FieldName = "ContactNo";
            this.clnContactNo.Name = "clnContactNo";
            this.clnContactNo.OptionsColumn.AllowEdit = false;
            this.clnContactNo.Visible = true;
            this.clnContactNo.VisibleIndex = 4;
            this.clnContactNo.Width = 169;
            // 
            // clnTotalAmt
            // 
            this.clnTotalAmt.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnTotalAmt.AppearanceCell.Options.UseFont = true;
            this.clnTotalAmt.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnTotalAmt.AppearanceHeader.Options.UseFont = true;
            this.clnTotalAmt.Caption = "Total Amt";
            this.clnTotalAmt.FieldName = "TotalAmt";
            this.clnTotalAmt.Name = "clnTotalAmt";
            this.clnTotalAmt.OptionsColumn.AllowEdit = false;
            this.clnTotalAmt.Visible = true;
            this.clnTotalAmt.VisibleIndex = 5;
            this.clnTotalAmt.Width = 126;
            // 
            // clnDueAmt
            // 
            this.clnDueAmt.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnDueAmt.AppearanceCell.Options.UseFont = true;
            this.clnDueAmt.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnDueAmt.AppearanceHeader.Options.UseFont = true;
            this.clnDueAmt.Caption = "Due Amt";
            this.clnDueAmt.FieldName = "DueAmt";
            this.clnDueAmt.Name = "clnDueAmt";
            this.clnDueAmt.OptionsColumn.AllowEdit = false;
            this.clnDueAmt.Visible = true;
            this.clnDueAmt.VisibleIndex = 7;
            this.clnDueAmt.Width = 84;
            // 
            // clnStatus
            // 
            this.clnStatus.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnStatus.AppearanceCell.Options.UseFont = true;
            this.clnStatus.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnStatus.AppearanceHeader.Options.UseFont = true;
            this.clnStatus.Caption = "Status";
            this.clnStatus.FieldName = "Status";
            this.clnStatus.Name = "clnStatus";
            this.clnStatus.OptionsColumn.AllowEdit = false;
            this.clnStatus.Width = 127;
            // 
            // clnRecAmt
            // 
            this.clnRecAmt.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnRecAmt.AppearanceCell.Options.UseFont = true;
            this.clnRecAmt.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold);
            this.clnRecAmt.AppearanceHeader.Options.UseFont = true;
            this.clnRecAmt.Caption = "Rec.Amt";
            this.clnRecAmt.FieldName = "RecAmt";
            this.clnRecAmt.Name = "clnRecAmt";
            this.clnRecAmt.Visible = true;
            this.clnRecAmt.VisibleIndex = 6;
            // 
            // clnAddress
            // 
            this.clnAddress.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnAddress.AppearanceCell.Options.UseFont = true;
            this.clnAddress.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold);
            this.clnAddress.AppearanceHeader.Options.UseFont = true;
            this.clnAddress.Caption = "Address";
            this.clnAddress.FieldName = "Address";
            this.clnAddress.Name = "clnAddress";
            this.clnAddress.Visible = true;
            this.clnAddress.VisibleIndex = 3;
            // 
            // fSOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1288, 589);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.grdOrders);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(160, 120);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fSOrders";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "polokhan100@gmail.com";
            this.Load += new System.EventHandler(this.fOrders_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStocks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblStockTotal;
        private System.Windows.Forms.Button btnReturn;
        private DevExpress.XtraGrid.GridControl grdOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clnOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn clnInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn clnCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn clnContactNo;
        private DevExpress.XtraGrid.Columns.GridColumn clnTotalAmt;
        private DevExpress.XtraGrid.Columns.GridColumn clnDueAmt;
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
        private DevExpress.XtraGrid.Columns.GridColumn clnSStockID;
        private System.Windows.Forms.Button btnPOS;
        private DevExpress.XtraGrid.Columns.GridColumn clnColor;
        private DevExpress.XtraGrid.Columns.GridColumn clnRecAmt;
        private DevExpress.XtraGrid.Columns.GridColumn clnAddress;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private System.Windows.Forms.Label label1;
    }
}