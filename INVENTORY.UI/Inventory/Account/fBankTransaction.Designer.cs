namespace INVENTORY.UI
{
    partial class fBankTransaction
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
            this.txtCheckNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ctlAnotherBank = new INVENTORY.UI.ctlCustomControl();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ctlSupplier = new INVENTORY.UI.ctlCustomControl();
            this.ctlCustomer = new INVENTORY.UI.ctlCustomControl();
            this.label3 = new System.Windows.Forms.Label();
            this.ctlBank = new INVENTORY.UI.ctlCustomControl();
            this.txtTransactionNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numRPAmount = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboTranType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.numTotalAmt = new System.Windows.Forms.NumericUpDown();
            this.lblTransacto = new System.Windows.Forms.Label();
            this.numTotalBalance = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.numEditAmt = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRPAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalBalance)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEditAmt)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCheckNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.ctlAnotherBank);
            this.groupBox1.Controls.Add(this.lblTransacto);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numTotalAmt);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ctlSupplier);
            this.groupBox1.Controls.Add(this.ctlCustomer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ctlBank);
            this.groupBox1.Controls.Add(this.txtTransactionNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numRPAmount);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboTranType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, -5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(532, 399);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckNo.Location = new System.Drawing.Point(130, 311);
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(373, 27);
            this.txtCheckNo.TabIndex = 89;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 21);
            this.label5.TabIndex = 90;
            this.label5.Text = "Check No";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 21);
            this.label9.TabIndex = 88;
            this.label9.Text = "Bank Name";
            // 
            // ctlAnotherBank
            // 
            this.ctlAnotherBank.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlAnotherBank.Location = new System.Drawing.Point(130, 206);
            this.ctlAnotherBank.Margin = new System.Windows.Forms.Padding(4);
            this.ctlAnotherBank.Name = "ctlAnotherBank";
            this.ctlAnotherBank.ObjectName = "Bank";
            this.ctlAnotherBank.Size = new System.Drawing.Size(373, 36);
            this.ctlAnotherBank.TabIndex = 87;
            this.ctlAnotherBank.SelectedItemChanged += new INVENTORY.UI.SelectionChangedEvent(this.ctlAnotherBank_SelectedItemChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 21);
            this.label8.TabIndex = 86;
            this.label8.Text = "Supplier";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 21);
            this.label7.TabIndex = 85;
            this.label7.Text = "Customer";
            // 
            // ctlSupplier
            // 
            this.ctlSupplier.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlSupplier.Location = new System.Drawing.Point(130, 167);
            this.ctlSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.ctlSupplier.Name = "ctlSupplier";
            this.ctlSupplier.ObjectName = "CCompany";
            this.ctlSupplier.Size = new System.Drawing.Size(373, 36);
            this.ctlSupplier.TabIndex = 84;
            this.ctlSupplier.SelectedItemChanged += new INVENTORY.UI.SelectionChangedEvent(this.ctlSupplier_SelectedItemChanged);
            // 
            // ctlCustomer
            // 
            this.ctlCustomer.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCustomer.Location = new System.Drawing.Point(130, 130);
            this.ctlCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.ctlCustomer.Name = "ctlCustomer";
            this.ctlCustomer.ObjectName = "CCustomer";
            this.ctlCustomer.Size = new System.Drawing.Size(373, 36);
            this.ctlCustomer.TabIndex = 83;
            this.ctlCustomer.SelectedItemChanged += new INVENTORY.UI.SelectionChangedEvent(this.ctlCustomer_SelectedItemChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 21);
            this.label3.TabIndex = 79;
            this.label3.Text = "Bank Name";
            // 
            // ctlBank
            // 
            this.ctlBank.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlBank.Location = new System.Drawing.Point(130, 94);
            this.ctlBank.Margin = new System.Windows.Forms.Padding(4);
            this.ctlBank.Name = "ctlBank";
            this.ctlBank.ObjectName = "Bank";
            this.ctlBank.Size = new System.Drawing.Size(373, 36);
            this.ctlBank.TabIndex = 3;
            this.ctlBank.SelectedItemChanged += new INVENTORY.UI.SelectionChangedEvent(this.ctlBank_SelectedItemChanged);
            // 
            // txtTransactionNumber
            // 
            this.txtTransactionNumber.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransactionNumber.Location = new System.Drawing.Point(394, 34);
            this.txtTransactionNumber.Name = "txtTransactionNumber";
            this.txtTransactionNumber.Size = new System.Drawing.Size(105, 27);
            this.txtTransactionNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(310, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 32;
            this.label1.Text = "Tran. No";
            // 
            // numRPAmount
            // 
            this.numRPAmount.DecimalPlaces = 2;
            this.numRPAmount.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRPAmount.Location = new System.Drawing.Point(130, 278);
            this.numRPAmount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numRPAmount.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.numRPAmount.Name = "numRPAmount";
            this.numRPAmount.Size = new System.Drawing.Size(159, 27);
            this.numRPAmount.TabIndex = 6;
            this.numRPAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRPAmount.ValueChanged += new System.EventHandler(this.numAmount_ValueChanged);
            this.numRPAmount.Enter += new System.EventHandler(this.numAmount_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 279);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 21);
            this.label11.TabIndex = 26;
            this.label11.Text = "Amount";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(130, 346);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(373, 43);
            this.txtDescription.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 351);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 21);
            this.label10.TabIndex = 23;
            this.label10.Text = "Remarks";
            // 
            // cboTranType
            // 
            this.cboTranType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTranType.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTranType.FormattingEnabled = true;
            this.cboTranType.Location = new System.Drawing.Point(130, 63);
            this.cboTranType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTranType.Name = "cboTranType";
            this.cboTranType.Size = new System.Drawing.Size(159, 29);
            this.cboTranType.TabIndex = 2;
            this.cboTranType.SelectedIndexChanged += new System.EventHandler(this.cboTranType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tran. Type";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd MMM yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(130, 30);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(159, 27);
            this.dtpDate.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Entry Date";
            // 
            // numTotalAmt
            // 
            this.numTotalAmt.BackColor = System.Drawing.Color.SlateGray;
            this.numTotalAmt.DecimalPlaces = 2;
            this.numTotalAmt.Enabled = false;
            this.numTotalAmt.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTotalAmt.ForeColor = System.Drawing.Color.White;
            this.numTotalAmt.Location = new System.Drawing.Point(130, 245);
            this.numTotalAmt.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numTotalAmt.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.numTotalAmt.Name = "numTotalAmt";
            this.numTotalAmt.ReadOnly = true;
            this.numTotalAmt.Size = new System.Drawing.Size(159, 27);
            this.numTotalAmt.TabIndex = 7;
            this.numTotalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTransacto
            // 
            this.lblTransacto.AutoSize = true;
            this.lblTransacto.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransacto.Location = new System.Drawing.Point(9, 248);
            this.lblTransacto.Name = "lblTransacto";
            this.lblTransacto.Size = new System.Drawing.Size(94, 21);
            this.lblTransacto.TabIndex = 30;
            this.lblTransacto.Text = "Pre Amount";
            // 
            // numTotalBalance
            // 
            this.numTotalBalance.BackColor = System.Drawing.Color.SlateGray;
            this.numTotalBalance.DecimalPlaces = 2;
            this.numTotalBalance.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTotalBalance.ForeColor = System.Drawing.Color.White;
            this.numTotalBalance.Location = new System.Drawing.Point(139, 20);
            this.numTotalBalance.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numTotalBalance.Name = "numTotalBalance";
            this.numTotalBalance.ReadOnly = true;
            this.numTotalBalance.Size = new System.Drawing.Size(72, 29);
            this.numTotalBalance.TabIndex = 10;
            this.numTotalBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTotalBalance.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 22);
            this.label12.TabIndex = 28;
            this.label12.Text = "Recent Balance";
            this.label12.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numEditAmt);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.numTotalBalance);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(5, 392);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(532, 56);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(307, 14);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 34);
            this.btnSave.TabIndex = 0;
            this.btnSave.Tag = "btnSave";
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(402, 14);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 34);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // numEditAmt
            // 
            this.numEditAmt.BackColor = System.Drawing.Color.SlateGray;
            this.numEditAmt.DecimalPlaces = 2;
            this.numEditAmt.Enabled = false;
            this.numEditAmt.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numEditAmt.ForeColor = System.Drawing.Color.White;
            this.numEditAmt.Location = new System.Drawing.Point(217, 15);
            this.numEditAmt.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numEditAmt.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.numEditAmt.Name = "numEditAmt";
            this.numEditAmt.ReadOnly = true;
            this.numEditAmt.Size = new System.Drawing.Size(57, 27);
            this.numEditAmt.TabIndex = 29;
            this.numEditAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numEditAmt.Visible = false;
            // 
            // fBankTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(546, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fBankTransaction";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Transaction";
            this.Load += new System.EventHandler(this.fCashTransaction_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRPAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalBalance)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEditAmt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numTotalAmt;
        private System.Windows.Forms.Label lblTransacto;
        private System.Windows.Forms.NumericUpDown numTotalBalance;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboTranType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTransactionNumber;
        private System.Windows.Forms.Label label1;
        private ctlCustomControl ctlBank;
        private System.Windows.Forms.Label label3;
        private ctlCustomControl ctlSupplier;
        private ctlCustomControl ctlCustomer;
        private System.Windows.Forms.Label label9;
        private ctlCustomControl ctlAnotherBank;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numRPAmount;
        private System.Windows.Forms.TextBox txtCheckNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numEditAmt;
    }
}