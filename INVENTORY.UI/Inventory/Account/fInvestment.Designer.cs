namespace INVENTORY.UI
{
    partial class fInvestment
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctlLiability = new INVENTORY.UI.ctlCustomControl();
            this.ctlCAsset = new INVENTORY.UI.ctlCustomControl();
            this.ctlFAssets = new INVENTORY.UI.ctlCustomControl();
            this.btnNewLiabilityRec = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numInvAmt = new System.Windows.Forms.NumericUpDown();
            this.txtPerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboTranType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInvAmt)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctlLiability);
            this.groupBox1.Controls.Add(this.ctlCAsset);
            this.groupBox1.Controls.Add(this.ctlFAssets);
            this.groupBox1.Controls.Add(this.btnNewLiabilityRec);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numInvAmt);
            this.groupBox1.Controls.Add(this.txtPerName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(5, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(602, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ctlLiability
            // 
            this.ctlLiability.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlLiability.Location = new System.Drawing.Point(143, 48);
            this.ctlLiability.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ctlLiability.Name = "ctlLiability";
            this.ctlLiability.ObjectName = "Liability";
            this.ctlLiability.Size = new System.Drawing.Size(326, 35);
            this.ctlLiability.TabIndex = 1;
            this.ctlLiability.SelectedItemChanged += new INVENTORY.UI.SelectionChangedEvent(this.ctlLiability_SelectedItemChanged);
            // 
            // ctlCAsset
            // 
            this.ctlCAsset.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCAsset.Location = new System.Drawing.Point(143, 48);
            this.ctlCAsset.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ctlCAsset.Name = "ctlCAsset";
            this.ctlCAsset.ObjectName = "CAsset";
            this.ctlCAsset.Size = new System.Drawing.Size(318, 35);
            this.ctlCAsset.TabIndex = 43;
            this.ctlCAsset.SelectedItemChanged += new INVENTORY.UI.SelectionChangedEvent(this.ctlCAsset_SelectedItemChanged);
            // 
            // ctlFAssets
            // 
            this.ctlFAssets.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFAssets.Location = new System.Drawing.Point(143, 48);
            this.ctlFAssets.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ctlFAssets.Name = "ctlFAssets";
            this.ctlFAssets.ObjectName = "FAsset";
            this.ctlFAssets.Size = new System.Drawing.Size(318, 35);
            this.ctlFAssets.TabIndex = 42;
            this.ctlFAssets.SelectedItemChanged += new INVENTORY.UI.SelectionChangedEvent(this.ctlFAssets_SelectedItemChanged);
            // 
            // btnNewLiabilityRec
            // 
            this.btnNewLiabilityRec.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewLiabilityRec.Location = new System.Drawing.Point(482, 54);
            this.btnNewLiabilityRec.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNewLiabilityRec.Name = "btnNewLiabilityRec";
            this.btnNewLiabilityRec.Size = new System.Drawing.Size(104, 33);
            this.btnNewLiabilityRec.TabIndex = 5;
            this.btnNewLiabilityRec.Tag = "btnAddLiability";
            this.btnNewLiabilityRec.Text = "&New";
            this.btnNewLiabilityRec.UseVisualStyleBackColor = true;
            this.btnNewLiabilityRec.Visible = false;
            this.btnNewLiabilityRec.Click += new System.EventHandler(this.btnNewLiabilityRec_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd MMM yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(143, 19);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(163, 27);
            this.dtpDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 38;
            this.label1.Text = "Invest Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 21);
            this.label7.TabIndex = 33;
            this.label7.Text = "Investment Amt.";
            // 
            // numInvAmt
            // 
            this.numInvAmt.DecimalPlaces = 2;
            this.numInvAmt.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numInvAmt.ForeColor = System.Drawing.Color.White;
            this.numInvAmt.Location = new System.Drawing.Point(143, 142);
            this.numInvAmt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numInvAmt.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numInvAmt.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.numInvAmt.Name = "numInvAmt";
            this.numInvAmt.Size = new System.Drawing.Size(216, 27);
            this.numInvAmt.TabIndex = 4;
            this.numInvAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numInvAmt.Enter += new System.EventHandler(this.numInvAmt_Enter);
            // 
            // txtPerName
            // 
            this.txtPerName.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPerName.Location = new System.Drawing.Point(143, 90);
            this.txtPerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPerName.Multiline = true;
            this.txtPerName.Name = "txtPerName";
            this.txtPerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPerName.Size = new System.Drawing.Size(321, 43);
            this.txtPerName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Description";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 21);
            this.label10.TabIndex = 36;
            this.label10.Text = "Investment";
            // 
            // cboTranType
            // 
            this.cboTranType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTranType.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTranType.FormattingEnabled = true;
            this.cboTranType.Location = new System.Drawing.Point(178, 20);
            this.cboTranType.Name = "cboTranType";
            this.cboTranType.Size = new System.Drawing.Size(151, 29);
            this.cboTranType.TabIndex = 3;
            this.cboTranType.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 45;
            this.label2.Text = "Pay Type";
            this.label2.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cboTranType);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Location = new System.Drawing.Point(5, 193);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(602, 60);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(494, 16);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 36);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(394, 16);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 36);
            this.btnSave.TabIndex = 0;
            this.btnSave.Tag = "btnSave";
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // fInvestment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(612, 259);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "fInvestment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Investment";
            this.Load += new System.EventHandler(this.fInvestment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInvAmt)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numInvAmt;
        private System.Windows.Forms.TextBox txtPerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewLiabilityRec;
        private ctlCustomControl ctlFAssets;
        private ctlCustomControl ctlLiability;
        private ctlCustomControl ctlCAsset;
        private System.Windows.Forms.ComboBox cboTranType;
        private System.Windows.Forms.Label label2;
    }
}