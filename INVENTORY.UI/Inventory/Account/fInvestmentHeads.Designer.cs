namespace INVENTORY.UI
{
    partial class fInvestmentHeads
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
            this.tbInvestment = new System.Windows.Forms.TabControl();
            this.tpFixedAsset = new System.Windows.Forms.TabPage();
            this.grdInvFixed = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnTranType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tpCurrAsset = new System.Windows.Forms.TabPage();
            this.grdInvCurrent = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewInvCurr = new System.Windows.Forms.Button();
            this.btnCloseInvCurr = new System.Windows.Forms.Button();
            this.btnEditInvCurr = new System.Windows.Forms.Button();
            this.btnDelInvCurr = new System.Windows.Forms.Button();
            this.tpLiability = new System.Windows.Forms.TabPage();
            this.grdLiability = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNewLiability = new System.Windows.Forms.Button();
            this.btnCloseLiability = new System.Windows.Forms.Button();
            this.btnEditLiability = new System.Windows.Forms.Button();
            this.btnDelLiability = new System.Windows.Forms.Button();
            this.tbInvestment.SuspendLayout();
            this.tpFixedAsset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvFixed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tpCurrAsset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.tpLiability.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLiability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInvestment
            // 
            this.tbInvestment.Controls.Add(this.tpFixedAsset);
            this.tbInvestment.Controls.Add(this.tpCurrAsset);
            this.tbInvestment.Controls.Add(this.tpLiability);
            this.tbInvestment.Location = new System.Drawing.Point(6, 8);
            this.tbInvestment.Name = "tbInvestment";
            this.tbInvestment.SelectedIndex = 0;
            this.tbInvestment.Size = new System.Drawing.Size(661, 561);
            this.tbInvestment.TabIndex = 0;
            this.tbInvestment.SelectedIndexChanged += new System.EventHandler(this.tbInvestment_SelectedIndexChanged);
            // 
            // tpFixedAsset
            // 
            this.tpFixedAsset.BackColor = System.Drawing.Color.SlateGray;
            this.tpFixedAsset.Controls.Add(this.grdInvFixed);
            this.tpFixedAsset.Controls.Add(this.panel1);
            this.tpFixedAsset.Location = new System.Drawing.Point(4, 27);
            this.tpFixedAsset.Name = "tpFixedAsset";
            this.tpFixedAsset.Padding = new System.Windows.Forms.Padding(3);
            this.tpFixedAsset.Size = new System.Drawing.Size(653, 530);
            this.tpFixedAsset.TabIndex = 0;
            this.tpFixedAsset.Text = "Fixed Asset";
            // 
            // grdInvFixed
            // 
            this.grdInvFixed.Location = new System.Drawing.Point(7, 5);
            this.grdInvFixed.LookAndFeel.SkinMaskColor = System.Drawing.Color.SlateGray;
            this.grdInvFixed.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.SlateGray;
            this.grdInvFixed.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdInvFixed.LookAndFeel.UseWindowsXPTheme = true;
            this.grdInvFixed.MainView = this.gridView1;
            this.grdInvFixed.Name = "grdInvFixed";
            this.grdInvFixed.Size = new System.Drawing.Size(529, 517);
            this.grdInvFixed.TabIndex = 14;
            this.grdInvFixed.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clnCode,
            this.clnName,
            this.clnTranType});
            this.gridView1.GridControl = this.grdInvFixed;
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
            this.clnCode.Width = 105;
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
            this.clnName.Width = 184;
            // 
            // clnTranType
            // 
            this.clnTranType.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnTranType.AppearanceCell.Options.UseFont = true;
            this.clnTranType.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnTranType.AppearanceHeader.Options.UseFont = true;
            this.clnTranType.Caption = "Tran Type";
            this.clnTranType.FieldName = "TranType";
            this.clnTranType.Name = "clnTranType";
            this.clnTranType.Width = 101;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(541, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 518);
            this.panel1.TabIndex = 13;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(20, 476);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(60, 19);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "lblTotal";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(5, 8);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(94, 30);
            this.btnNew.TabIndex = 0;
            this.btnNew.Tag = "btnAdd";
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(5, 96);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(5, 37);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 30);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "btnEdit";
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(5, 67);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "btnDelete";
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tpCurrAsset
            // 
            this.tpCurrAsset.BackColor = System.Drawing.Color.SlateGray;
            this.tpCurrAsset.Controls.Add(this.grdInvCurrent);
            this.tpCurrAsset.Controls.Add(this.panel2);
            this.tpCurrAsset.Location = new System.Drawing.Point(4, 27);
            this.tpCurrAsset.Name = "tpCurrAsset";
            this.tpCurrAsset.Padding = new System.Windows.Forms.Padding(3);
            this.tpCurrAsset.Size = new System.Drawing.Size(653, 530);
            this.tpCurrAsset.TabIndex = 1;
            this.tpCurrAsset.Text = "Current Asset";
            // 
            // grdInvCurrent
            // 
            this.grdInvCurrent.Location = new System.Drawing.Point(6, 5);
            this.grdInvCurrent.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdInvCurrent.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdInvCurrent.LookAndFeel.UseWindowsXPTheme = true;
            this.grdInvCurrent.MainView = this.gridView2;
            this.grdInvCurrent.Name = "grdInvCurrent";
            this.grdInvCurrent.Size = new System.Drawing.Size(529, 516);
            this.grdInvCurrent.TabIndex = 14;
            this.grdInvCurrent.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4});
            this.gridView2.GridControl = this.grdInvCurrent;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsFind.AlwaysVisible = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "Code";
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 105;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "Name";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 184;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "Tran Type";
            this.gridColumn4.FieldName = "TranType";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Width = 101;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnNewInvCurr);
            this.panel2.Controls.Add(this.btnCloseInvCurr);
            this.panel2.Controls.Add(this.btnEditInvCurr);
            this.panel2.Controls.Add(this.btnDelInvCurr);
            this.panel2.Location = new System.Drawing.Point(540, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(105, 517);
            this.panel2.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 484);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // btnNewInvCurr
            // 
            this.btnNewInvCurr.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewInvCurr.Location = new System.Drawing.Point(5, 8);
            this.btnNewInvCurr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewInvCurr.Name = "btnNewInvCurr";
            this.btnNewInvCurr.Size = new System.Drawing.Size(94, 30);
            this.btnNewInvCurr.TabIndex = 0;
            this.btnNewInvCurr.Tag = "btnAdd";
            this.btnNewInvCurr.Text = "&New";
            this.btnNewInvCurr.UseVisualStyleBackColor = true;
            this.btnNewInvCurr.Click += new System.EventHandler(this.btnNewInvCurr_Click);
            // 
            // btnCloseInvCurr
            // 
            this.btnCloseInvCurr.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseInvCurr.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseInvCurr.Location = new System.Drawing.Point(5, 96);
            this.btnCloseInvCurr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCloseInvCurr.Name = "btnCloseInvCurr";
            this.btnCloseInvCurr.Size = new System.Drawing.Size(94, 30);
            this.btnCloseInvCurr.TabIndex = 3;
            this.btnCloseInvCurr.Text = "&Close";
            this.btnCloseInvCurr.UseVisualStyleBackColor = true;
            this.btnCloseInvCurr.Click += new System.EventHandler(this.btnCloseInvCurr_Click);
            // 
            // btnEditInvCurr
            // 
            this.btnEditInvCurr.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditInvCurr.Location = new System.Drawing.Point(5, 37);
            this.btnEditInvCurr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditInvCurr.Name = "btnEditInvCurr";
            this.btnEditInvCurr.Size = new System.Drawing.Size(94, 30);
            this.btnEditInvCurr.TabIndex = 1;
            this.btnEditInvCurr.Tag = "btnEdit";
            this.btnEditInvCurr.Text = "&Edit";
            this.btnEditInvCurr.UseVisualStyleBackColor = true;
            this.btnEditInvCurr.Click += new System.EventHandler(this.btnEditInvCurr_Click);
            // 
            // btnDelInvCurr
            // 
            this.btnDelInvCurr.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelInvCurr.Location = new System.Drawing.Point(5, 67);
            this.btnDelInvCurr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelInvCurr.Name = "btnDelInvCurr";
            this.btnDelInvCurr.Size = new System.Drawing.Size(94, 30);
            this.btnDelInvCurr.TabIndex = 2;
            this.btnDelInvCurr.Tag = "btnDelete";
            this.btnDelInvCurr.Text = "&Delete";
            this.btnDelInvCurr.UseVisualStyleBackColor = true;
            this.btnDelInvCurr.Click += new System.EventHandler(this.btnDelInvCurr_Click);
            // 
            // tpLiability
            // 
            this.tpLiability.BackColor = System.Drawing.Color.SlateGray;
            this.tpLiability.Controls.Add(this.grdLiability);
            this.tpLiability.Controls.Add(this.panel3);
            this.tpLiability.Location = new System.Drawing.Point(4, 27);
            this.tpLiability.Name = "tpLiability";
            this.tpLiability.Size = new System.Drawing.Size(653, 530);
            this.tpLiability.TabIndex = 2;
            this.tpLiability.Text = "Liability";
            // 
            // grdLiability
            // 
            this.grdLiability.Location = new System.Drawing.Point(5, 5);
            this.grdLiability.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdLiability.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdLiability.LookAndFeel.UseWindowsXPTheme = true;
            this.grdLiability.MainView = this.gridView3;
            this.grdLiability.Name = "grdLiability";
            this.grdLiability.Size = new System.Drawing.Size(529, 515);
            this.grdLiability.TabIndex = 14;
            this.grdLiability.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8});
            this.gridView3.GridControl = this.grdLiability;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsFind.AlwaysVisible = true;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.Caption = "Code";
            this.gridColumn5.FieldName = "Code";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 105;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "Name";
            this.gridColumn6.FieldName = "Name";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 184;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.Caption = "Tran Type";
            this.gridColumn8.FieldName = "TranType";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 101;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnNewLiability);
            this.panel3.Controls.Add(this.btnCloseLiability);
            this.panel3.Controls.Add(this.btnEditLiability);
            this.panel3.Controls.Add(this.btnDelLiability);
            this.panel3.Location = new System.Drawing.Point(539, 5);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(105, 516);
            this.panel3.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 481);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // btnNewLiability
            // 
            this.btnNewLiability.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewLiability.Location = new System.Drawing.Point(5, 8);
            this.btnNewLiability.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewLiability.Name = "btnNewLiability";
            this.btnNewLiability.Size = new System.Drawing.Size(94, 30);
            this.btnNewLiability.TabIndex = 0;
            this.btnNewLiability.Tag = "btnAdd";
            this.btnNewLiability.Text = "&New";
            this.btnNewLiability.UseVisualStyleBackColor = true;
            this.btnNewLiability.Click += new System.EventHandler(this.btnNewLiability_Click);
            // 
            // btnCloseLiability
            // 
            this.btnCloseLiability.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseLiability.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseLiability.Location = new System.Drawing.Point(5, 96);
            this.btnCloseLiability.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCloseLiability.Name = "btnCloseLiability";
            this.btnCloseLiability.Size = new System.Drawing.Size(94, 30);
            this.btnCloseLiability.TabIndex = 3;
            this.btnCloseLiability.Text = "&Close";
            this.btnCloseLiability.UseVisualStyleBackColor = true;
            this.btnCloseLiability.Click += new System.EventHandler(this.btnCloseLiability_Click);
            // 
            // btnEditLiability
            // 
            this.btnEditLiability.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditLiability.Location = new System.Drawing.Point(5, 37);
            this.btnEditLiability.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditLiability.Name = "btnEditLiability";
            this.btnEditLiability.Size = new System.Drawing.Size(94, 30);
            this.btnEditLiability.TabIndex = 1;
            this.btnEditLiability.Tag = "btnEdit";
            this.btnEditLiability.Text = "&Edit";
            this.btnEditLiability.UseVisualStyleBackColor = true;
            this.btnEditLiability.Click += new System.EventHandler(this.btnEditLiability_Click);
            // 
            // btnDelLiability
            // 
            this.btnDelLiability.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelLiability.Location = new System.Drawing.Point(5, 67);
            this.btnDelLiability.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelLiability.Name = "btnDelLiability";
            this.btnDelLiability.Size = new System.Drawing.Size(94, 30);
            this.btnDelLiability.TabIndex = 2;
            this.btnDelLiability.Tag = "btnDelete";
            this.btnDelLiability.Text = "&Delete";
            this.btnDelLiability.UseVisualStyleBackColor = true;
            this.btnDelLiability.Click += new System.EventHandler(this.btnDelLiability_Click);
            // 
            // fInvestmentHeads
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(672, 575);
            this.Controls.Add(this.tbInvestment);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fInvestmentHeads";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Investment Heads";
            this.Load += new System.EventHandler(this.fInvestmentHeads_Load);
            this.tbInvestment.ResumeLayout(false);
            this.tpFixedAsset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInvFixed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tpCurrAsset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInvCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tpLiability.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLiability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbInvestment;
        private System.Windows.Forms.TabPage tpFixedAsset;
        private System.Windows.Forms.TabPage tpCurrAsset;
        private System.Windows.Forms.TabPage tpLiability;
        private DevExpress.XtraGrid.GridControl grdInvFixed;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clnCode;
        private DevExpress.XtraGrid.Columns.GridColumn clnName;
        private DevExpress.XtraGrid.Columns.GridColumn clnTranType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private DevExpress.XtraGrid.GridControl grdInvCurrent;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewInvCurr;
        private System.Windows.Forms.Button btnCloseInvCurr;
        private System.Windows.Forms.Button btnEditInvCurr;
        private System.Windows.Forms.Button btnDelInvCurr;
        private DevExpress.XtraGrid.GridControl grdLiability;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNewLiability;
        private System.Windows.Forms.Button btnCloseLiability;
        private System.Windows.Forms.Button btnEditLiability;
        private System.Windows.Forms.Button btnDelLiability;

    }
}