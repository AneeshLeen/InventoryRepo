namespace INVENTORY.UI
{
    partial class fColorControl
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
            this.grdColors = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnSLNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnColorCode = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdColors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(375, 7);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(60, 19);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "lblTotal";
            // 
            // grdColors
            // 
            this.grdColors.Location = new System.Drawing.Point(5, 3);
            this.grdColors.LookAndFeel.SkinMaskColor = System.Drawing.Color.SlateGray;
            this.grdColors.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.SlateGray;
            this.grdColors.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdColors.LookAndFeel.UseWindowsXPTheme = true;
            this.grdColors.MainView = this.gridView1;
            this.grdColors.Name = "grdColors";
            this.grdColors.Size = new System.Drawing.Size(432, 328);
            this.grdColors.TabIndex = 14;
            this.grdColors.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdColors.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdColors_MouseDoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clnSLNo,
            this.clnColorCode});
            this.gridView1.GridControl = this.grdColors;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // clnSLNo
            // 
            this.clnSLNo.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnSLNo.AppearanceCell.Options.UseFont = true;
            this.clnSLNo.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnSLNo.AppearanceHeader.Options.UseFont = true;
            this.clnSLNo.Caption = "SLNo";
            this.clnSLNo.FieldName = "SLNo";
            this.clnSLNo.Name = "clnSLNo";
            this.clnSLNo.OptionsColumn.AllowEdit = false;
            this.clnSLNo.Visible = true;
            this.clnSLNo.VisibleIndex = 0;
            this.clnSLNo.Width = 118;
            // 
            // clnColorCode
            // 
            this.clnColorCode.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnColorCode.AppearanceCell.Options.UseFont = true;
            this.clnColorCode.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnColorCode.AppearanceHeader.Options.UseFont = true;
            this.clnColorCode.Caption = "Color Code";
            this.clnColorCode.FieldName = "ColorCode";
            this.clnColorCode.Name = "clnColorCode";
            this.clnColorCode.OptionsColumn.AllowEdit = false;
            this.clnColorCode.Visible = true;
            this.clnColorCode.VisibleIndex = 1;
            this.clnColorCode.Width = 300;
            // 
            // fColorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(442, 336);
            this.Controls.Add(this.grdColors);
            this.Controls.Add(this.lblTotal);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fColorControl";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color Control";
            this.Load += new System.EventHandler(this.fColorControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdColors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private DevExpress.XtraGrid.GridControl grdColors;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clnSLNo;
        private DevExpress.XtraGrid.Columns.GridColumn clnColorCode;
    }
}