namespace INVENTORY.UI
{
    partial class fPReturns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fPReturns));
            this.grdPReturns = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnReturnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnContactNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnPaidAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnDueAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdPReturns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdPReturns
            // 
            this.grdPReturns.Location = new System.Drawing.Point(7, 125);
            this.grdPReturns.LookAndFeel.SkinMaskColor = System.Drawing.Color.SlateGray;
            this.grdPReturns.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.SlateGray;
            this.grdPReturns.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdPReturns.LookAndFeel.UseWindowsXPTheme = true;
            this.grdPReturns.MainView = this.gridView1;
            this.grdPReturns.Name = "grdPReturns";
            this.grdPReturns.Size = new System.Drawing.Size(850, 403);
            this.grdPReturns.TabIndex = 19;
            this.grdPReturns.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdPReturns.Click += new System.EventHandler(this.grdReturns_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clnReturnDate,
            this.clnInvoiceNo,
            this.clnContactNo,
            this.clnSupplier,
            this.clnPaidAmount,
            this.clnDueAmount,
            this.clnStatus});
            this.gridView1.GridControl = this.grdPReturns;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // clnReturnDate
            // 
            this.clnReturnDate.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnReturnDate.AppearanceCell.Options.UseFont = true;
            this.clnReturnDate.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnReturnDate.AppearanceHeader.Options.UseFont = true;
            this.clnReturnDate.AppearanceHeader.Options.UseTextOptions = true;
            this.clnReturnDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clnReturnDate.Caption = "ReturnDate";
            this.clnReturnDate.FieldName = "ReturnDate";
            this.clnReturnDate.Name = "clnReturnDate";
            this.clnReturnDate.OptionsColumn.AllowEdit = false;
            this.clnReturnDate.Visible = true;
            this.clnReturnDate.VisibleIndex = 0;
            this.clnReturnDate.Width = 102;
            // 
            // clnInvoiceNo
            // 
            this.clnInvoiceNo.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnInvoiceNo.AppearanceCell.Options.UseFont = true;
            this.clnInvoiceNo.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnInvoiceNo.AppearanceHeader.Options.UseFont = true;
            this.clnInvoiceNo.AppearanceHeader.Options.UseTextOptions = true;
            this.clnInvoiceNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clnInvoiceNo.Caption = "Invoice No";
            this.clnInvoiceNo.FieldName = "InvoiceNo";
            this.clnInvoiceNo.Name = "clnInvoiceNo";
            this.clnInvoiceNo.OptionsColumn.AllowEdit = false;
            this.clnInvoiceNo.Visible = true;
            this.clnInvoiceNo.VisibleIndex = 1;
            this.clnInvoiceNo.Width = 102;
            // 
            // clnContactNo
            // 
            this.clnContactNo.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnContactNo.AppearanceCell.Options.UseFont = true;
            this.clnContactNo.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnContactNo.AppearanceHeader.Options.UseFont = true;
            this.clnContactNo.AppearanceHeader.Options.UseTextOptions = true;
            this.clnContactNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clnContactNo.Caption = "Contact No";
            this.clnContactNo.FieldName = "ContactNo";
            this.clnContactNo.Name = "clnContactNo";
            this.clnContactNo.Visible = true;
            this.clnContactNo.VisibleIndex = 3;
            this.clnContactNo.Width = 87;
            // 
            // clnSupplier
            // 
            this.clnSupplier.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnSupplier.AppearanceCell.Options.UseFont = true;
            this.clnSupplier.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnSupplier.AppearanceHeader.Options.UseFont = true;
            this.clnSupplier.AppearanceHeader.Options.UseTextOptions = true;
            this.clnSupplier.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clnSupplier.Caption = "Supplier";
            this.clnSupplier.FieldName = "Supplier";
            this.clnSupplier.Name = "clnSupplier";
            this.clnSupplier.Visible = true;
            this.clnSupplier.VisibleIndex = 2;
            this.clnSupplier.Width = 149;
            // 
            // clnPaidAmount
            // 
            this.clnPaidAmount.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnPaidAmount.AppearanceCell.Options.UseFont = true;
            this.clnPaidAmount.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnPaidAmount.AppearanceHeader.Options.UseFont = true;
            this.clnPaidAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.clnPaidAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clnPaidAmount.Caption = "PaidAmount";
            this.clnPaidAmount.FieldName = "PaidAmount";
            this.clnPaidAmount.Name = "clnPaidAmount";
            this.clnPaidAmount.OptionsColumn.AllowEdit = false;
            this.clnPaidAmount.Visible = true;
            this.clnPaidAmount.VisibleIndex = 4;
            this.clnPaidAmount.Width = 87;
            // 
            // clnDueAmount
            // 
            this.clnDueAmount.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnDueAmount.AppearanceCell.Options.UseFont = true;
            this.clnDueAmount.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnDueAmount.AppearanceHeader.Options.UseFont = true;
            this.clnDueAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.clnDueAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clnDueAmount.Caption = "Due Amount";
            this.clnDueAmount.FieldName = "DueAmount";
            this.clnDueAmount.Name = "clnDueAmount";
            this.clnDueAmount.OptionsColumn.AllowEdit = false;
            this.clnDueAmount.Visible = true;
            this.clnDueAmount.VisibleIndex = 5;
            this.clnDueAmount.Width = 101;
            // 
            // clnStatus
            // 
            this.clnStatus.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnStatus.AppearanceCell.Options.UseFont = true;
            this.clnStatus.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnStatus.AppearanceHeader.Options.UseFont = true;
            this.clnStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.clnStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.clnStatus.Caption = "Status";
            this.clnStatus.FieldName = "Status";
            this.clnStatus.Name = "clnStatus";
            this.clnStatus.OptionsColumn.AllowEdit = false;
            this.clnStatus.Width = 80;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.grdPReturns);
            this.groupBox1.Location = new System.Drawing.Point(3, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(864, 540);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(9, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 89);
            this.panel1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(483, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 41);
            this.label1.TabIndex = 16;
            this.label1.Text = "Purchase Product Return";
            // 
            // btnPrint
            // 
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPrint.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(289, 4);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 78);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "&Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(13, 544);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(58, 19);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "lblTotal";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(4, 4);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(94, 78);
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
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(382, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 78);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(97, 4);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(99, 78);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "btnEdit";
            this.btnEdit.Text = "&Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(193, 4);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 78);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "btnDelete";
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.grdReturns_Click);
            // 
            // fPReturns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(870, 545);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fPReturns";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "polokhan100@gmail.com";
            this.Load += new System.EventHandler(this.fPReturns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPReturns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdPReturns;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clnReturnDate;
        private DevExpress.XtraGrid.Columns.GridColumn clnInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn clnContactNo;
        private DevExpress.XtraGrid.Columns.GridColumn clnSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn clnPaidAmount;
        private DevExpress.XtraGrid.Columns.GridColumn clnDueAmount;
        private DevExpress.XtraGrid.Columns.GridColumn clnStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
    }
}