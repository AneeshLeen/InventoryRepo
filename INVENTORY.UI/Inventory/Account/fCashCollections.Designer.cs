namespace INVENTORY.UI
{
    partial class fCashCollections
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCashCollections));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMoneyReceipt = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.grdCashCollections = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnEntryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnContactNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnAccountNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCashCollections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnMoneyReceipt);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(35, 39);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 83);
            this.panel1.TabIndex = 11;
            // 
            // btnMoneyReceipt
            // 
            this.btnMoneyReceipt.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoneyReceipt.Image = ((System.Drawing.Image)(resources.GetObject("btnMoneyReceipt.Image")));
            this.btnMoneyReceipt.Location = new System.Drawing.Point(185, 2);
            this.btnMoneyReceipt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoneyReceipt.Name = "btnMoneyReceipt";
            this.btnMoneyReceipt.Size = new System.Drawing.Size(94, 78);
            this.btnMoneyReceipt.TabIndex = 12;
            this.btnMoneyReceipt.Text = "&M.Receipt";
            this.btnMoneyReceipt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMoneyReceipt.UseVisualStyleBackColor = true;
            this.btnMoneyReceipt.Click += new System.EventHandler(this.btnMoneyReceipt_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(12, 581);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(65, 21);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "lblTotal";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(2, 1);
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
            this.btnClose.Location = new System.Drawing.Point(372, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 78);
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
            this.btnEdit.Location = new System.Drawing.Point(94, 2);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 78);
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
            this.btnDelete.Location = new System.Drawing.Point(279, 2);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 78);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "btnDelete";
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(341, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(161, 21);
            this.label12.TabIndex = 13;
            this.label12.Text = "Cash Receive History";
            // 
            // grdCashCollections
            // 
            this.grdCashCollections.Location = new System.Drawing.Point(35, 129);
            this.grdCashCollections.LookAndFeel.SkinMaskColor = System.Drawing.Color.SlateGray;
            this.grdCashCollections.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.SlateGray;
            this.grdCashCollections.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdCashCollections.LookAndFeel.UseWindowsXPTheme = true;
            this.grdCashCollections.MainView = this.gridView1;
            this.grdCashCollections.Name = "grdCashCollections";
            this.grdCashCollections.Size = new System.Drawing.Size(467, 407);
            this.grdCashCollections.TabIndex = 13;
            this.grdCashCollections.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clnEntryDate,
            this.clnName,
            this.clnContactNo,
            this.clnAccountNo,
            this.clnAmount,
            this.clnStatus});
            this.gridView1.GridControl = this.grdCashCollections;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // clnEntryDate
            // 
            this.clnEntryDate.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnEntryDate.AppearanceCell.Options.UseFont = true;
            this.clnEntryDate.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnEntryDate.AppearanceHeader.Options.UseFont = true;
            this.clnEntryDate.Caption = "Entry Date";
            this.clnEntryDate.FieldName = "EntryDate";
            this.clnEntryDate.Name = "clnEntryDate";
            this.clnEntryDate.OptionsColumn.AllowEdit = false;
            this.clnEntryDate.Visible = true;
            this.clnEntryDate.VisibleIndex = 0;
            // 
            // clnName
            // 
            this.clnName.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnName.AppearanceCell.Options.UseFont = true;
            this.clnName.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnName.AppearanceHeader.Options.UseFont = true;
            this.clnName.Caption = "Name";
            this.clnName.FieldName = "Name";
            this.clnName.Name = "clnName";
            this.clnName.OptionsColumn.AllowEdit = false;
            this.clnName.Visible = true;
            this.clnName.VisibleIndex = 1;
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
            this.clnContactNo.VisibleIndex = 2;
            // 
            // clnAccountNo
            // 
            this.clnAccountNo.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnAccountNo.AppearanceCell.Options.UseFont = true;
            this.clnAccountNo.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnAccountNo.AppearanceHeader.Options.UseFont = true;
            this.clnAccountNo.Caption = "Account No";
            this.clnAccountNo.FieldName = "AccountNo";
            this.clnAccountNo.Name = "clnAccountNo";
            this.clnAccountNo.OptionsColumn.AllowEdit = false;
            this.clnAccountNo.Visible = true;
            this.clnAccountNo.VisibleIndex = 3;
            // 
            // clnAmount
            // 
            this.clnAmount.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnAmount.AppearanceCell.Options.UseFont = true;
            this.clnAmount.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnAmount.AppearanceHeader.Options.UseFont = true;
            this.clnAmount.Caption = "Amount";
            this.clnAmount.FieldName = "Amount";
            this.clnAmount.Name = "clnAmount";
            this.clnAmount.OptionsColumn.AllowEdit = false;
            this.clnAmount.Visible = true;
            this.clnAmount.VisibleIndex = 4;
            // 
            // clnStatus
            // 
            this.clnStatus.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnStatus.AppearanceCell.Options.UseFont = true;
            this.clnStatus.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnStatus.AppearanceHeader.Options.UseFont = true;
            this.clnStatus.Caption = "Status";
            this.clnStatus.FieldName = "Status";
            this.clnStatus.Name = "clnStatus";
            this.clnStatus.OptionsColumn.AllowEdit = false;
            this.clnStatus.Visible = true;
            this.clnStatus.VisibleIndex = 5;
            // 
            // fCashCollections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1265, 574);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.grdCashCollections);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(160, 120);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fCashCollections";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "polokhan100@gmail.com";
            this.Load += new System.EventHandler(this.fCashCollections_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCashCollections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private DevExpress.XtraGrid.GridControl grdCashCollections;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clnEntryDate;
        private DevExpress.XtraGrid.Columns.GridColumn clnName;
        private DevExpress.XtraGrid.Columns.GridColumn clnContactNo;
        private DevExpress.XtraGrid.Columns.GridColumn clnAccountNo;
        private DevExpress.XtraGrid.Columns.GridColumn clnAmount;
        private DevExpress.XtraGrid.Columns.GridColumn clnStatus;
        private System.Windows.Forms.Button btnMoneyReceipt;
        private System.Windows.Forms.Label label12;
    }
}