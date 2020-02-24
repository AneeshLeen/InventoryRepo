namespace INVENTORY.UI
{
    partial class fInvestments
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
            this.lblFA = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbcInvestment = new System.Windows.Forms.TabControl();
            this.tpInvestment = new System.Windows.Forms.TabPage();
            this.grdInvestment = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clnPurpose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnInvAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnInvHead = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnEnterDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpCAssets = new System.Windows.Forms.TabPage();
            this.grdCAssets = new DevExpress.XtraGrid.GridControl();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnCAEntryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCA = new System.Windows.Forms.Label();
            this.lblCAsset = new System.Windows.Forms.Label();
            this.btnNewCAsset = new System.Windows.Forms.Button();
            this.btnCloseAsset = new System.Windows.Forms.Button();
            this.btnEditCAsset = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tbLiabilitiesRec = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblLR = new System.Windows.Forms.Label();
            this.btnNewLiabilityRec = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLRClose = new System.Windows.Forms.Button();
            this.btnRecLoan = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.grdLiabilitiesRec = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnEntryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbLiabilitiesPay = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblLP = new System.Windows.Forms.Label();
            this.btnNewLiabilityPay = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLPClose = new System.Windows.Forms.Button();
            this.btnPayLoan = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.grdLiabilitiesPay = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clnLPEntryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            this.tbcInvestment.SuspendLayout();
            this.tpInvestment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvestment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tpCAssets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCAssets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            this.panel2.SuspendLayout();
            this.tbLiabilitiesRec.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLiabilitiesRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.tbLiabilitiesPay.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLiabilitiesPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblFA);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(720, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(96, 467);
            this.panel1.TabIndex = 9;
            // 
            // lblFA
            // 
            this.lblFA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFA.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFA.ForeColor = System.Drawing.Color.White;
            this.lblFA.Location = new System.Drawing.Point(3, 186);
            this.lblFA.Name = "lblFA";
            this.lblFA.Size = new System.Drawing.Size(88, 49);
            this.lblFA.TabIndex = 13;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(9, 438);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(65, 21);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "lblTotal";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(5, 8);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(85, 33);
            this.btnNew.TabIndex = 0;
            this.btnNew.Tag = "btnAddInvest";
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(5, 77);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 33);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(5, 43);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(85, 33);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "btnEdit";
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(13, 138);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 33);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "btnDelete";
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbcInvestment
            // 
            this.tbcInvestment.Controls.Add(this.tpInvestment);
            this.tbcInvestment.Controls.Add(this.tpCAssets);
            this.tbcInvestment.Controls.Add(this.tbLiabilitiesRec);
            this.tbcInvestment.Controls.Add(this.tbLiabilitiesPay);
            this.tbcInvestment.Location = new System.Drawing.Point(3, 7);
            this.tbcInvestment.Name = "tbcInvestment";
            this.tbcInvestment.SelectedIndex = 0;
            this.tbcInvestment.Size = new System.Drawing.Size(831, 515);
            this.tbcInvestment.TabIndex = 10;
            this.tbcInvestment.SelectedIndexChanged += new System.EventHandler(this.tbcInvestment_SelectedIndexChanged);
            // 
            // tpInvestment
            // 
            this.tpInvestment.BackColor = System.Drawing.Color.SlateGray;
            this.tpInvestment.Controls.Add(this.grdInvestment);
            this.tpInvestment.Controls.Add(this.panel1);
            this.tpInvestment.Location = new System.Drawing.Point(4, 30);
            this.tpInvestment.Name = "tpInvestment";
            this.tpInvestment.Padding = new System.Windows.Forms.Padding(3);
            this.tpInvestment.Size = new System.Drawing.Size(823, 481);
            this.tpInvestment.TabIndex = 0;
            this.tpInvestment.Text = "Fixed Assets";
            // 
            // grdInvestment
            // 
            this.grdInvestment.Location = new System.Drawing.Point(6, 7);
            this.grdInvestment.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdInvestment.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdInvestment.LookAndFeel.UseWindowsXPTheme = true;
            this.grdInvestment.MainView = this.gridView1;
            this.grdInvestment.Name = "grdInvestment";
            this.grdInvestment.Size = new System.Drawing.Size(710, 469);
            this.grdInvestment.TabIndex = 13;
            this.grdInvestment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clnPurpose,
            this.clnInvAmt,
            this.clnInvHead,
            this.clnEnterDate});
            this.gridView1.GridControl = this.grdInvestment;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // clnPurpose
            // 
            this.clnPurpose.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnPurpose.AppearanceCell.Options.UseFont = true;
            this.clnPurpose.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnPurpose.AppearanceHeader.Options.UseFont = true;
            this.clnPurpose.Caption = "Purpose";
            this.clnPurpose.FieldName = "Purpose";
            this.clnPurpose.Name = "clnPurpose";
            this.clnPurpose.OptionsColumn.AllowEdit = false;
            this.clnPurpose.Visible = true;
            this.clnPurpose.VisibleIndex = 2;
            this.clnPurpose.Width = 235;
            // 
            // clnInvAmt
            // 
            this.clnInvAmt.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnInvAmt.AppearanceCell.Options.UseFont = true;
            this.clnInvAmt.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnInvAmt.AppearanceHeader.Options.UseFont = true;
            this.clnInvAmt.Caption = "Amount";
            this.clnInvAmt.FieldName = "Amount";
            this.clnInvAmt.Name = "clnInvAmt";
            this.clnInvAmt.OptionsColumn.AllowEdit = false;
            this.clnInvAmt.Visible = true;
            this.clnInvAmt.VisibleIndex = 3;
            this.clnInvAmt.Width = 126;
            // 
            // clnInvHead
            // 
            this.clnInvHead.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnInvHead.AppearanceCell.Options.UseFont = true;
            this.clnInvHead.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnInvHead.AppearanceHeader.Options.UseFont = true;
            this.clnInvHead.Caption = "Invest Head";
            this.clnInvHead.FieldName = "InvHead";
            this.clnInvHead.Name = "clnInvHead";
            this.clnInvHead.Visible = true;
            this.clnInvHead.VisibleIndex = 1;
            this.clnInvHead.Width = 205;
            // 
            // clnEnterDate
            // 
            this.clnEnterDate.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnEnterDate.AppearanceCell.Options.UseFont = true;
            this.clnEnterDate.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnEnterDate.AppearanceHeader.Options.UseFont = true;
            this.clnEnterDate.Caption = "Enter Date";
            this.clnEnterDate.FieldName = "EntryDate";
            this.clnEnterDate.Name = "clnEnterDate";
            this.clnEnterDate.Visible = true;
            this.clnEnterDate.VisibleIndex = 0;
            this.clnEnterDate.Width = 126;
            // 
            // tpCAssets
            // 
            this.tpCAssets.BackColor = System.Drawing.Color.SlateGray;
            this.tpCAssets.Controls.Add(this.grdCAssets);
            this.tpCAssets.Controls.Add(this.panel2);
            this.tpCAssets.Location = new System.Drawing.Point(4, 30);
            this.tpCAssets.Name = "tpCAssets";
            this.tpCAssets.Size = new System.Drawing.Size(823, 481);
            this.tpCAssets.TabIndex = 4;
            this.tpCAssets.Text = "Current Assets";
            // 
            // grdCAssets
            // 
            this.grdCAssets.Location = new System.Drawing.Point(6, 6);
            this.grdCAssets.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdCAssets.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdCAssets.LookAndFeel.UseWindowsXPTheme = true;
            this.grdCAssets.MainView = this.gridView5;
            this.grdCAssets.Name = "grdCAssets";
            this.grdCAssets.Size = new System.Drawing.Size(710, 469);
            this.grdCAssets.TabIndex = 15;
            this.grdCAssets.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView5});
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn14,
            this.clnCAEntryDate});
            this.gridView5.GridControl = this.grdCAssets;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsFind.AlwaysVisible = true;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn11.AppearanceCell.Options.UseFont = true;
            this.gridColumn11.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn11.AppearanceHeader.Options.UseFont = true;
            this.gridColumn11.Caption = "Purpose";
            this.gridColumn11.FieldName = "Purpose";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn11.Width = 231;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn12.AppearanceCell.Options.UseFont = true;
            this.gridColumn12.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn12.AppearanceHeader.Options.UseFont = true;
            this.gridColumn12.Caption = "Amount";
            this.gridColumn12.FieldName = "Amount";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 3;
            this.gridColumn12.Width = 125;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn14.AppearanceCell.Options.UseFont = true;
            this.gridColumn14.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn14.AppearanceHeader.Options.UseFont = true;
            this.gridColumn14.Caption = "Invest Head";
            this.gridColumn14.FieldName = "InvHead";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 1;
            this.gridColumn14.Width = 212;
            // 
            // clnCAEntryDate
            // 
            this.clnCAEntryDate.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnCAEntryDate.AppearanceCell.Options.UseFont = true;
            this.clnCAEntryDate.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnCAEntryDate.AppearanceHeader.Options.UseFont = true;
            this.clnCAEntryDate.Caption = "Entry Date";
            this.clnCAEntryDate.FieldName = "EntryDate";
            this.clnCAEntryDate.Name = "clnCAEntryDate";
            this.clnCAEntryDate.Visible = true;
            this.clnCAEntryDate.VisibleIndex = 0;
            this.clnCAEntryDate.Width = 124;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblCA);
            this.panel2.Controls.Add(this.lblCAsset);
            this.panel2.Controls.Add(this.btnNewCAsset);
            this.panel2.Controls.Add(this.btnCloseAsset);
            this.panel2.Controls.Add(this.btnEditCAsset);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Location = new System.Drawing.Point(720, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(96, 467);
            this.panel2.TabIndex = 14;
            // 
            // lblCA
            // 
            this.lblCA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCA.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCA.ForeColor = System.Drawing.Color.White;
            this.lblCA.Location = new System.Drawing.Point(3, 195);
            this.lblCA.Name = "lblCA";
            this.lblCA.Size = new System.Drawing.Size(88, 49);
            this.lblCA.TabIndex = 14;
            // 
            // lblCAsset
            // 
            this.lblCAsset.AutoSize = true;
            this.lblCAsset.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCAsset.Location = new System.Drawing.Point(9, 438);
            this.lblCAsset.Name = "lblCAsset";
            this.lblCAsset.Size = new System.Drawing.Size(52, 21);
            this.lblCAsset.TabIndex = 12;
            this.lblCAsset.Text = "label4";
            // 
            // btnNewCAsset
            // 
            this.btnNewCAsset.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCAsset.Location = new System.Drawing.Point(5, 8);
            this.btnNewCAsset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewCAsset.Name = "btnNewCAsset";
            this.btnNewCAsset.Size = new System.Drawing.Size(85, 33);
            this.btnNewCAsset.TabIndex = 0;
            this.btnNewCAsset.Tag = "btnAddInvest";
            this.btnNewCAsset.Text = "&New";
            this.btnNewCAsset.UseVisualStyleBackColor = true;
            this.btnNewCAsset.Click += new System.EventHandler(this.btnNewCAsset_Click);
            // 
            // btnCloseAsset
            // 
            this.btnCloseAsset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseAsset.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseAsset.Location = new System.Drawing.Point(5, 77);
            this.btnCloseAsset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCloseAsset.Name = "btnCloseAsset";
            this.btnCloseAsset.Size = new System.Drawing.Size(85, 33);
            this.btnCloseAsset.TabIndex = 3;
            this.btnCloseAsset.Text = "&Close";
            this.btnCloseAsset.UseVisualStyleBackColor = true;
            this.btnCloseAsset.Click += new System.EventHandler(this.btnCloseAsset_Click);
            // 
            // btnEditCAsset
            // 
            this.btnEditCAsset.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditCAsset.Location = new System.Drawing.Point(5, 43);
            this.btnEditCAsset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditCAsset.Name = "btnEditCAsset";
            this.btnEditCAsset.Size = new System.Drawing.Size(85, 33);
            this.btnEditCAsset.TabIndex = 1;
            this.btnEditCAsset.Tag = "btnEdit";
            this.btnEditCAsset.Text = "&Edit";
            this.btnEditCAsset.UseVisualStyleBackColor = true;
            this.btnEditCAsset.Click += new System.EventHandler(this.btnEditCAsset_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(13, 138);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(66, 33);
            this.button6.TabIndex = 2;
            this.button6.Tag = "btnDelete";
            this.button6.Text = "&Delete";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            // 
            // tbLiabilitiesRec
            // 
            this.tbLiabilitiesRec.BackColor = System.Drawing.Color.SlateGray;
            this.tbLiabilitiesRec.Controls.Add(this.panel3);
            this.tbLiabilitiesRec.Controls.Add(this.grdLiabilitiesRec);
            this.tbLiabilitiesRec.Location = new System.Drawing.Point(4, 30);
            this.tbLiabilitiesRec.Name = "tbLiabilitiesRec";
            this.tbLiabilitiesRec.Padding = new System.Windows.Forms.Padding(3);
            this.tbLiabilitiesRec.Size = new System.Drawing.Size(823, 481);
            this.tbLiabilitiesRec.TabIndex = 2;
            this.tbLiabilitiesRec.Text = "Liabilites Rec.";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblLR);
            this.panel3.Controls.Add(this.btnNewLiabilityRec);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnLRClose);
            this.panel3.Controls.Add(this.btnRecLoan);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Location = new System.Drawing.Point(722, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(98, 473);
            this.panel3.TabIndex = 15;
            // 
            // lblLR
            // 
            this.lblLR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLR.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLR.ForeColor = System.Drawing.Color.White;
            this.lblLR.Location = new System.Drawing.Point(4, 200);
            this.lblLR.Name = "lblLR";
            this.lblLR.Size = new System.Drawing.Size(88, 49);
            this.lblLR.TabIndex = 14;
            // 
            // btnNewLiabilityRec
            // 
            this.btnNewLiabilityRec.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewLiabilityRec.Location = new System.Drawing.Point(5, 9);
            this.btnNewLiabilityRec.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewLiabilityRec.Name = "btnNewLiabilityRec";
            this.btnNewLiabilityRec.Size = new System.Drawing.Size(84, 33);
            this.btnNewLiabilityRec.TabIndex = 13;
            this.btnNewLiabilityRec.Tag = "btnAddLiability";
            this.btnNewLiabilityRec.Text = "&New";
            this.btnNewLiabilityRec.UseVisualStyleBackColor = true;
            this.btnNewLiabilityRec.Click += new System.EventHandler(this.btnNewLiabilityRec_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "label2";
            // 
            // btnLRClose
            // 
            this.btnLRClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLRClose.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLRClose.Location = new System.Drawing.Point(5, 76);
            this.btnLRClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLRClose.Name = "btnLRClose";
            this.btnLRClose.Size = new System.Drawing.Size(84, 33);
            this.btnLRClose.TabIndex = 3;
            this.btnLRClose.Text = "&Close";
            this.btnLRClose.UseVisualStyleBackColor = true;
            this.btnLRClose.Click += new System.EventHandler(this.btnLRClose_Click);
            // 
            // btnRecLoan
            // 
            this.btnRecLoan.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecLoan.Location = new System.Drawing.Point(5, 42);
            this.btnRecLoan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRecLoan.Name = "btnRecLoan";
            this.btnRecLoan.Size = new System.Drawing.Size(84, 33);
            this.btnRecLoan.TabIndex = 1;
            this.btnRecLoan.Tag = "btnEdit";
            this.btnRecLoan.Text = "&Edit";
            this.btnRecLoan.UseVisualStyleBackColor = true;
            this.btnRecLoan.Click += new System.EventHandler(this.btnRecLoan_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(17, 128);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(54, 33);
            this.button4.TabIndex = 2;
            this.button4.Tag = "btnDelete";
            this.button4.Text = "&Delete";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // grdLiabilitiesRec
            // 
            this.grdLiabilitiesRec.Location = new System.Drawing.Point(12, 3);
            this.grdLiabilitiesRec.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdLiabilitiesRec.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdLiabilitiesRec.LookAndFeel.UseWindowsXPTheme = true;
            this.grdLiabilitiesRec.MainView = this.gridView3;
            this.grdLiabilitiesRec.Name = "grdLiabilitiesRec";
            this.grdLiabilitiesRec.Size = new System.Drawing.Size(706, 474);
            this.grdLiabilitiesRec.TabIndex = 14;
            this.grdLiabilitiesRec.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn6,
            this.clnEntryDate});
            this.gridView3.GridControl = this.grdLiabilitiesRec;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsFind.AlwaysVisible = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "Purpose";
            this.gridColumn1.FieldName = "Purpose";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 230;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "Amount";
            this.gridColumn4.FieldName = "Amount";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 126;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "Invest Head";
            this.gridColumn6.FieldName = "InvHead";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 207;
            // 
            // clnEntryDate
            // 
            this.clnEntryDate.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnEntryDate.AppearanceCell.Options.UseFont = true;
            this.clnEntryDate.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnEntryDate.AppearanceHeader.Options.UseFont = true;
            this.clnEntryDate.Caption = "Entry Date";
            this.clnEntryDate.FieldName = "EntryDate";
            this.clnEntryDate.Name = "clnEntryDate";
            this.clnEntryDate.Visible = true;
            this.clnEntryDate.VisibleIndex = 0;
            this.clnEntryDate.Width = 125;
            // 
            // tbLiabilitiesPay
            // 
            this.tbLiabilitiesPay.BackColor = System.Drawing.Color.SlateGray;
            this.tbLiabilitiesPay.Controls.Add(this.panel4);
            this.tbLiabilitiesPay.Controls.Add(this.grdLiabilitiesPay);
            this.tbLiabilitiesPay.Location = new System.Drawing.Point(4, 30);
            this.tbLiabilitiesPay.Name = "tbLiabilitiesPay";
            this.tbLiabilitiesPay.Padding = new System.Windows.Forms.Padding(3);
            this.tbLiabilitiesPay.Size = new System.Drawing.Size(823, 481);
            this.tbLiabilitiesPay.TabIndex = 3;
            this.tbLiabilitiesPay.Text = "Liabilities Pay";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblLP);
            this.panel4.Controls.Add(this.btnNewLiabilityPay);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.btnLPClose);
            this.panel4.Controls.Add(this.btnPayLoan);
            this.panel4.Controls.Add(this.button9);
            this.panel4.Location = new System.Drawing.Point(715, 7);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(102, 467);
            this.panel4.TabIndex = 16;
            // 
            // lblLP
            // 
            this.lblLP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLP.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLP.ForeColor = System.Drawing.Color.White;
            this.lblLP.Location = new System.Drawing.Point(5, 184);
            this.lblLP.Name = "lblLP";
            this.lblLP.Size = new System.Drawing.Size(89, 49);
            this.lblLP.TabIndex = 14;
            // 
            // btnNewLiabilityPay
            // 
            this.btnNewLiabilityPay.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewLiabilityPay.Location = new System.Drawing.Point(5, 9);
            this.btnNewLiabilityPay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewLiabilityPay.Name = "btnNewLiabilityPay";
            this.btnNewLiabilityPay.Size = new System.Drawing.Size(84, 33);
            this.btnNewLiabilityPay.TabIndex = 13;
            this.btnNewLiabilityPay.Tag = "btnAddLiability";
            this.btnNewLiabilityPay.Text = "&New";
            this.btnNewLiabilityPay.UseVisualStyleBackColor = true;
            this.btnNewLiabilityPay.Click += new System.EventHandler(this.btnNewLiabilityPay_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "label3";
            // 
            // btnLPClose
            // 
            this.btnLPClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLPClose.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLPClose.Location = new System.Drawing.Point(5, 76);
            this.btnLPClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLPClose.Name = "btnLPClose";
            this.btnLPClose.Size = new System.Drawing.Size(84, 33);
            this.btnLPClose.TabIndex = 3;
            this.btnLPClose.Text = "&Close";
            this.btnLPClose.UseVisualStyleBackColor = true;
            this.btnLPClose.Click += new System.EventHandler(this.btnLPClose_Click);
            // 
            // btnPayLoan
            // 
            this.btnPayLoan.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayLoan.Location = new System.Drawing.Point(5, 42);
            this.btnPayLoan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPayLoan.Name = "btnPayLoan";
            this.btnPayLoan.Size = new System.Drawing.Size(84, 33);
            this.btnPayLoan.TabIndex = 1;
            this.btnPayLoan.Tag = "btnEdit";
            this.btnPayLoan.Text = "&Edit";
            this.btnPayLoan.UseVisualStyleBackColor = true;
            this.btnPayLoan.Click += new System.EventHandler(this.btnPayLoan_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(17, 128);
            this.button9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(54, 33);
            this.button9.TabIndex = 2;
            this.button9.Tag = "btnDelete";
            this.button9.Text = "&Delete";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            // 
            // grdLiabilitiesPay
            // 
            this.grdLiabilitiesPay.Location = new System.Drawing.Point(6, 6);
            this.grdLiabilitiesPay.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdLiabilitiesPay.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdLiabilitiesPay.LookAndFeel.UseWindowsXPTheme = true;
            this.grdLiabilitiesPay.MainView = this.gridView4;
            this.grdLiabilitiesPay.Name = "grdLiabilitiesPay";
            this.grdLiabilitiesPay.Size = new System.Drawing.Size(705, 469);
            this.grdLiabilitiesPay.TabIndex = 15;
            this.grdLiabilitiesPay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn10,
            this.clnLPEntryDate});
            this.gridView4.GridControl = this.grdLiabilitiesPay;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsFind.AlwaysVisible = true;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.Caption = "Purpose";
            this.gridColumn7.FieldName = "Purpose";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 229;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.Caption = "Amount";
            this.gridColumn8.FieldName = "Amount";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 137;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.gridColumn10.AppearanceCell.Options.UseFont = true;
            this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn10.AppearanceHeader.Options.UseFont = true;
            this.gridColumn10.Caption = "Invest Head";
            this.gridColumn10.FieldName = "InvHead";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 206;
            // 
            // clnLPEntryDate
            // 
            this.clnLPEntryDate.AppearanceCell.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.clnLPEntryDate.AppearanceCell.Options.UseFont = true;
            this.clnLPEntryDate.AppearanceHeader.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.clnLPEntryDate.AppearanceHeader.Options.UseFont = true;
            this.clnLPEntryDate.Caption = "Entry Date";
            this.clnLPEntryDate.FieldName = "EntryDate";
            this.clnLPEntryDate.Name = "clnLPEntryDate";
            this.clnLPEntryDate.Visible = true;
            this.clnLPEntryDate.VisibleIndex = 0;
            this.clnLPEntryDate.Width = 115;
            // 
            // fInvestments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(839, 527);
            this.Controls.Add(this.tbcInvestment);
            this.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "fInvestments";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Share Investments";
            this.Load += new System.EventHandler(this.fInvestments_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tbcInvestment.ResumeLayout(false);
            this.tpInvestment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInvestment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tpCAssets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCAssets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tbLiabilitiesRec.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLiabilitiesRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.tbLiabilitiesPay.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLiabilitiesPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TabControl tbcInvestment;
        private System.Windows.Forms.TabPage tpInvestment;
        private DevExpress.XtraGrid.GridControl grdInvestment;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clnPurpose;
        private DevExpress.XtraGrid.Columns.GridColumn clnInvAmt;
        private DevExpress.XtraGrid.Columns.GridColumn clnInvHead;
        private System.Windows.Forms.TabPage tbLiabilitiesRec;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnNewLiabilityRec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLRClose;
        private System.Windows.Forms.Button btnRecLoan;
        private System.Windows.Forms.Button button4;
        private DevExpress.XtraGrid.GridControl grdLiabilitiesRec;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.TabPage tbLiabilitiesPay;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnNewLiabilityPay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLPClose;
        private System.Windows.Forms.Button btnPayLoan;
        private System.Windows.Forms.Button button9;
        private DevExpress.XtraGrid.GridControl grdLiabilitiesPay;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private System.Windows.Forms.TabPage tpCAssets;
        private DevExpress.XtraGrid.GridControl grdCAssets;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCAsset;
        private System.Windows.Forms.Button btnNewCAsset;
        private System.Windows.Forms.Button btnCloseAsset;
        private System.Windows.Forms.Button btnEditCAsset;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label lblFA;
        private System.Windows.Forms.Label lblCA;
        private System.Windows.Forms.Label lblLR;
        private System.Windows.Forms.Label lblLP;
        private DevExpress.XtraGrid.Columns.GridColumn clnEnterDate;
        private DevExpress.XtraGrid.Columns.GridColumn clnCAEntryDate;
        private DevExpress.XtraGrid.Columns.GridColumn clnEntryDate;
        private DevExpress.XtraGrid.Columns.GridColumn clnLPEntryDate;
    }
}