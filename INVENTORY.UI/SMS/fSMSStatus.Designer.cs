namespace INVENTORY.UI
{
    partial class fSMSStatus
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
            this.grdSMS = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnSMS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnSDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnSTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSMS
            // 
            this.grdSMS.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdSMS.Location = new System.Drawing.Point(3, 2);
            this.grdSMS.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdSMS.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdSMS.LookAndFeel.UseWindowsXPTheme = true;
            this.grdSMS.MainView = this.gridView1;
            this.grdSMS.Name = "grdSMS";
            this.grdSMS.Size = new System.Drawing.Size(895, 408);
            this.grdSMS.TabIndex = 11;
            this.grdSMS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clnCode,
            this.clnSMS,
            this.clnSDate,
            this.clnSTo,
            this.clnStatus});
            this.gridView1.GridControl = this.grdSMS;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // clnCode
            // 
            this.clnCode.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnCode.AppearanceCell.Options.UseFont = true;
            this.clnCode.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnCode.AppearanceHeader.Options.UseFont = true;
            this.clnCode.Caption = "Code";
            this.clnCode.FieldName = "Code";
            this.clnCode.Name = "clnCode";
            this.clnCode.OptionsColumn.AllowEdit = false;
            this.clnCode.Visible = true;
            this.clnCode.VisibleIndex = 0;
            this.clnCode.Width = 101;
            // 
            // clnSMS
            // 
            this.clnSMS.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnSMS.AppearanceCell.Options.UseFont = true;
            this.clnSMS.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnSMS.AppearanceHeader.Options.UseFont = true;
            this.clnSMS.Caption = "SMS";
            this.clnSMS.FieldName = "SMS";
            this.clnSMS.Name = "clnSMS";
            this.clnSMS.OptionsColumn.AllowEdit = false;
            this.clnSMS.Visible = true;
            this.clnSMS.VisibleIndex = 2;
            this.clnSMS.Width = 415;
            // 
            // clnSDate
            // 
            this.clnSDate.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnSDate.AppearanceCell.Options.UseFont = true;
            this.clnSDate.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnSDate.AppearanceHeader.Options.UseFont = true;
            this.clnSDate.Caption = "Date";
            this.clnSDate.FieldName = "SDate";
            this.clnSDate.Name = "clnSDate";
            this.clnSDate.OptionsColumn.AllowEdit = false;
            this.clnSDate.Visible = true;
            this.clnSDate.VisibleIndex = 1;
            this.clnSDate.Width = 119;
            // 
            // clnSTo
            // 
            this.clnSTo.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnSTo.AppearanceCell.Options.UseFont = true;
            this.clnSTo.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnSTo.AppearanceHeader.Options.UseFont = true;
            this.clnSTo.Caption = "Receiver";
            this.clnSTo.FieldName = "STO";
            this.clnSTo.Name = "clnSTo";
            this.clnSTo.OptionsColumn.AllowEdit = false;
            this.clnSTo.Visible = true;
            this.clnSTo.VisibleIndex = 3;
            this.clnSTo.Width = 149;
            // 
            // clnStatus
            // 
            this.clnStatus.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clnStatus.AppearanceCell.Options.UseFont = true;
            this.clnStatus.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnStatus.AppearanceHeader.Options.UseFont = true;
            this.clnStatus.Caption = "Status";
            this.clnStatus.FieldName = "Status";
            this.clnStatus.Name = "clnStatus";
            this.clnStatus.OptionsColumn.AllowEdit = false;
            this.clnStatus.Visible = true;
            this.clnStatus.VisibleIndex = 4;
            this.clnStatus.Width = 93;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(811, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "label2";
            // 
            // fSMSStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(904, 415);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grdSMS);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fSMSStatus";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "wecoderz.com";
            this.Load += new System.EventHandler(this.fSMSStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdSMS;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clnCode;
        private DevExpress.XtraGrid.Columns.GridColumn clnSMS;
        private DevExpress.XtraGrid.Columns.GridColumn clnSDate;
        private DevExpress.XtraGrid.Columns.GridColumn clnSTo;
        private DevExpress.XtraGrid.Columns.GridColumn clnStatus;
        private System.Windows.Forms.Label label2;
    }
}