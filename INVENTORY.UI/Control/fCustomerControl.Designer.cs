namespace INVENTORY.UI
{
    partial class fCustomerControl
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
            this.grdCustomers = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnCName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnContactNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(653, 6);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(60, 19);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "lblTotal";
            // 
            // grdCustomers
            // 
            this.grdCustomers.Location = new System.Drawing.Point(-1, 3);
            this.grdCustomers.LookAndFeel.SkinMaskColor = System.Drawing.Color.SlateGray;
            this.grdCustomers.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.SlateGray;
            this.grdCustomers.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdCustomers.LookAndFeel.UseWindowsXPTheme = true;
            this.grdCustomers.MainView = this.gridView1;
            this.grdCustomers.Name = "grdCustomers";
            this.grdCustomers.Size = new System.Drawing.Size(558, 387);
            this.grdCustomers.TabIndex = 15;
            this.grdCustomers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdCustomers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdCustomers_MouseDoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clnCode,
            this.clnName,
            this.clnCName,
            this.clnContactNo,
            this.clnAddress});
            this.gridView1.GridControl = this.grdCustomers;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // clnCode
            // 
            this.clnCode.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnCode.AppearanceCell.Options.UseFont = true;
            this.clnCode.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnCode.AppearanceHeader.Options.UseFont = true;
            this.clnCode.Caption = "A/C";
            this.clnCode.FieldName = "Code";
            this.clnCode.Name = "clnCode";
            this.clnCode.OptionsColumn.AllowEdit = false;
            this.clnCode.Visible = true;
            this.clnCode.VisibleIndex = 0;
            this.clnCode.Width = 89;
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
            this.clnName.Width = 182;
            // 
            // clnCName
            // 
            this.clnCName.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnCName.AppearanceCell.Options.UseFont = true;
            this.clnCName.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnCName.AppearanceHeader.Options.UseFont = true;
            this.clnCName.Caption = "Father Name";
            this.clnCName.FieldName = "CName";
            this.clnCName.Name = "clnCName";
            this.clnCName.OptionsColumn.AllowEdit = false;
            this.clnCName.Visible = true;
            this.clnCName.VisibleIndex = 2;
            this.clnCName.Width = 178;
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
            this.clnContactNo.VisibleIndex = 3;
            this.clnContactNo.Width = 142;
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
            this.clnAddress.Width = 132;
            // 
            // fCustomerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(560, 393);
            this.Controls.Add(this.grdCustomers);
            this.Controls.Add(this.lblTotal);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fCustomerControl";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Control";
            this.Load += new System.EventHandler(this.fCustomerControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private DevExpress.XtraGrid.GridControl grdCustomers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clnCode;
        private DevExpress.XtraGrid.Columns.GridColumn clnName;
        private DevExpress.XtraGrid.Columns.GridColumn clnCName;
        private DevExpress.XtraGrid.Columns.GridColumn clnContactNo;
        private DevExpress.XtraGrid.Columns.GridColumn clnAddress;
    }
}