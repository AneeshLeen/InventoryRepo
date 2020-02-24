namespace INVENTORY.UI
{
    partial class fMultipleSelectControl
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
            this.clSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnCName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnContactNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdMultipleSelect = new DevExpress.XtraGrid.GridControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMultipleSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // clSelect
            // 
            this.clSelect.Caption = "Select";
            this.clSelect.Name = "clSelect";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(414, 54);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(52, 21);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "label1";
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(251, 16);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(104, 32);
            this.btnSelect.TabIndex = 18;
            this.btnSelect.Text = "&Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 335);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 54);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(356, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 32);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clnCode,
            this.clnName,
            this.clnCName,
            this.clnContactNo});
            this.gridView1.GridControl = this.grdMultipleSelect;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsSelection.InvertSelection = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
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
            this.clnCode.VisibleIndex = 1;
            this.clnCode.Width = 98;
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
            this.clnName.VisibleIndex = 2;
            this.clnName.Width = 174;
            // 
            // clnCName
            // 
            this.clnCName.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnCName.AppearanceCell.Options.UseFont = true;
            this.clnCName.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnCName.AppearanceHeader.Options.UseFont = true;
            this.clnCName.Caption = "Company Name";
            this.clnCName.FieldName = "CName";
            this.clnCName.Name = "clnCName";
            this.clnCName.OptionsColumn.AllowEdit = false;
            this.clnCName.Visible = true;
            this.clnCName.VisibleIndex = 3;
            this.clnCName.Width = 226;
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
            this.clnContactNo.VisibleIndex = 4;
            this.clnContactNo.Width = 176;
            // 
            // grdMultipleSelect
            // 
            this.grdMultipleSelect.Location = new System.Drawing.Point(6, 3);
            this.grdMultipleSelect.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdMultipleSelect.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdMultipleSelect.LookAndFeel.UseWindowsXPTheme = true;
            this.grdMultipleSelect.MainView = this.gridView1;
            this.grdMultipleSelect.Name = "grdMultipleSelect";
            this.grdMultipleSelect.Size = new System.Drawing.Size(483, 331);
            this.grdMultipleSelect.TabIndex = 16;
            this.grdMultipleSelect.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdMultipleSelect.Click += new System.EventHandler(this.grdCustomers_Click);
            // 
            // fMultipleSelectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(495, 397);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.grdMultipleSelect);
            this.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fMultipleSelectControl";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "All Client";
            this.Load += new System.EventHandler(this.fMultipleSelectControl_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMultipleSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn clSelect;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clnCode;
        private DevExpress.XtraGrid.Columns.GridColumn clnName;
        private DevExpress.XtraGrid.Columns.GridColumn clnCName;
        private DevExpress.XtraGrid.Columns.GridColumn clnContactNo;
        private DevExpress.XtraGrid.GridControl grdMultipleSelect;
        private System.Windows.Forms.Button btnClose;
    }
}