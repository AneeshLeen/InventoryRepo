namespace INVENTORY.UI
{
    partial class fBranch
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtNID = new System.Windows.Forms.GroupBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numTotalAmt = new System.Windows.Forms.NumericUpDown();
            this.numOpeningBalance = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ctlBank = new INVENTORY.UI.ctlCustomControl();
            this.btnItemShow = new System.Windows.Forms.Button();
            this.btnNewBank = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.txtNID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOpeningBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.SlateGray;
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Font = new System.Drawing.Font("Siyam Rupali", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(4, 270);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(627, 58);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(514, 16);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 34);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(412, 16);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 34);
            this.btnSave.TabIndex = 0;
            this.btnSave.Tag = "btnSave";
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNID
            // 
            this.txtNID.BackColor = System.Drawing.Color.SlateGray;
            this.txtNID.Controls.Add(this.txtAddress);
            this.txtNID.Controls.Add(this.label5);
            this.txtNID.Controls.Add(this.label7);
            this.txtNID.Controls.Add(this.numTotalAmt);
            this.txtNID.Controls.Add(this.numOpeningBalance);
            this.txtNID.Controls.Add(this.label4);
            this.txtNID.Controls.Add(this.txtAccountNo);
            this.txtNID.Controls.Add(this.label6);
            this.txtNID.Controls.Add(this.ctlBank);
            this.txtNID.Controls.Add(this.btnItemShow);
            this.txtNID.Controls.Add(this.btnNewBank);
            this.txtNID.Controls.Add(this.label3);
            this.txtNID.Controls.Add(this.txtName);
            this.txtNID.Controls.Add(this.txtCode);
            this.txtNID.Controls.Add(this.label2);
            this.txtNID.Controls.Add(this.label1);
            this.txtNID.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNID.Location = new System.Drawing.Point(4, -4);
            this.txtNID.Margin = new System.Windows.Forms.Padding(4);
            this.txtNID.Name = "txtNID";
            this.txtNID.Padding = new System.Windows.Forms.Padding(4);
            this.txtNID.Size = new System.Drawing.Size(627, 281);
            this.txtNID.TabIndex = 5;
            this.txtNID.TabStop = false;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(123, 127);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAddress.Size = new System.Drawing.Size(270, 36);
            this.txtAddress.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 130);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 22);
            this.label5.TabIndex = 84;
            this.label5.Text = "Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 21);
            this.label7.TabIndex = 83;
            this.label7.Text = "Total Amt.";
            // 
            // numTotalAmt
            // 
            this.numTotalAmt.BackColor = System.Drawing.Color.Pink;
            this.numTotalAmt.DecimalPlaces = 2;
            this.numTotalAmt.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTotalAmt.ForeColor = System.Drawing.Color.White;
            this.numTotalAmt.Location = new System.Drawing.Point(123, 241);
            this.numTotalAmt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numTotalAmt.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numTotalAmt.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.numTotalAmt.Name = "numTotalAmt";
            this.numTotalAmt.ReadOnly = true;
            this.numTotalAmt.Size = new System.Drawing.Size(177, 29);
            this.numTotalAmt.TabIndex = 6;
            this.numTotalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numOpeningBalance
            // 
            this.numOpeningBalance.DecimalPlaces = 2;
            this.numOpeningBalance.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOpeningBalance.Location = new System.Drawing.Point(123, 205);
            this.numOpeningBalance.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numOpeningBalance.Name = "numOpeningBalance";
            this.numOpeningBalance.Size = new System.Drawing.Size(176, 29);
            this.numOpeningBalance.TabIndex = 5;
            this.numOpeningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numOpeningBalance.ValueChanged += new System.EventHandler(this.numOpeningBalance_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 21);
            this.label4.TabIndex = 81;
            this.label4.Text = "Opening Amt.";
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNo.Location = new System.Drawing.Point(123, 171);
            this.txtAccountNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(248, 27);
            this.txtAccountNo.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 21);
            this.label6.TabIndex = 79;
            this.label6.Text = "Account No";
            // 
            // ctlBank
            // 
            this.ctlBank.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlBank.Location = new System.Drawing.Point(123, 48);
            this.ctlBank.Margin = new System.Windows.Forms.Padding(4);
            this.ctlBank.Name = "ctlBank";
            this.ctlBank.ObjectName = "Bank";
            this.ctlBank.Size = new System.Drawing.Size(270, 36);
            this.ctlBank.TabIndex = 1;
            this.ctlBank.SelectedItemChanged += new INVENTORY.UI.SelectionChangedEvent(this.ctlCategory_SelectedItemChanged);
            // 
            // btnItemShow
            // 
            this.btnItemShow.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemShow.Location = new System.Drawing.Point(510, 50);
            this.btnItemShow.Name = "btnItemShow";
            this.btnItemShow.Size = new System.Drawing.Size(112, 31);
            this.btnItemShow.TabIndex = 8;
            this.btnItemShow.Text = "&All Bank";
            this.btnItemShow.UseVisualStyleBackColor = true;
            this.btnItemShow.Click += new System.EventHandler(this.btnItemShow_Click);
            // 
            // btnNewBank
            // 
            this.btnNewBank.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewBank.Location = new System.Drawing.Point(398, 50);
            this.btnNewBank.Name = "btnNewBank";
            this.btnNewBank.Size = new System.Drawing.Size(112, 31);
            this.btnNewBank.TabIndex = 7;
            this.btnNewBank.Text = "&New Bank";
            this.btnNewBank.UseVisualStyleBackColor = true;
            this.btnNewBank.Click += new System.EventHandler(this.btnNewItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 22);
            this.label3.TabIndex = 26;
            this.label3.Text = "Bank";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(123, 87);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtName.Size = new System.Drawing.Size(270, 36);
            this.txtName.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(123, 15);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(198, 29);
            this.txtCode.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Branch Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code";
            // 
            // fBranch
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(637, 330);
            this.Controls.Add(this.txtNID);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "fBranch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Branch";
            this.Load += new System.EventHandler(this.fProduct_Load);
            this.groupBox3.ResumeLayout(false);
            this.txtNID.ResumeLayout(false);
            this.txtNID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOpeningBalance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox txtNID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnItemShow;
        private System.Windows.Forms.Button btnNewBank;
        private ctlCustomControl ctlBank;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numOpeningBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numTotalAmt;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;

    }
}