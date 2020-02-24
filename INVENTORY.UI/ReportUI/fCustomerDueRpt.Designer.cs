namespace INVENTORY.UI
{
    partial class fCustomerDueRpt
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkCredit = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkDealer = new System.Windows.Forms.CheckBox();
            this.chkRetail = new System.Windows.Forms.CheckBox();
            this.ctlCustomer = new INVENTORY.UI.ctlCustomControl();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkCredit);
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.chkDealer);
            this.groupBox2.Controls.Add(this.chkRetail);
            this.groupBox2.Controls.Add(this.ctlCustomer);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, -3);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox2.Size = new System.Drawing.Size(570, 141);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // chkCredit
            // 
            this.chkCredit.AutoSize = true;
            this.chkCredit.Location = new System.Drawing.Point(366, 89);
            this.chkCredit.Name = "chkCredit";
            this.chkCredit.Size = new System.Drawing.Size(69, 23);
            this.chkCredit.TabIndex = 18;
            this.chkCredit.Text = "Credit";
            this.chkCredit.UseVisualStyleBackColor = true;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(126, 89);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(49, 23);
            this.chkAll.TabIndex = 17;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkDealer
            // 
            this.chkDealer.AutoSize = true;
            this.chkDealer.Location = new System.Drawing.Point(279, 89);
            this.chkDealer.Name = "chkDealer";
            this.chkDealer.Size = new System.Drawing.Size(72, 23);
            this.chkDealer.TabIndex = 16;
            this.chkDealer.Text = "Dealer";
            this.chkDealer.UseVisualStyleBackColor = true;
            this.chkDealer.CheckedChanged += new System.EventHandler(this.chkDealer_CheckedChanged);
            // 
            // chkRetail
            // 
            this.chkRetail.AutoSize = true;
            this.chkRetail.Location = new System.Drawing.Point(200, 89);
            this.chkRetail.Name = "chkRetail";
            this.chkRetail.Size = new System.Drawing.Size(67, 23);
            this.chkRetail.TabIndex = 15;
            this.chkRetail.Text = "Retail";
            this.chkRetail.UseVisualStyleBackColor = true;
            this.chkRetail.CheckedChanged += new System.EventHandler(this.chkRetail_CheckedChanged);
            // 
            // ctlCustomer
            // 
            this.ctlCustomer.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCustomer.Location = new System.Drawing.Point(106, 23);
            this.ctlCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.ctlCustomer.Name = "ctlCustomer";
            this.ctlCustomer.ObjectName = "Customer";
            this.ctlCustomer.Size = new System.Drawing.Size(411, 36);
            this.ctlCustomer.TabIndex = 14;
            this.ctlCustomer.SelectedItemChanged += new INVENTORY.UI.SelectionChangedEvent(this.ctlCustomer_SelectedItemChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnPreview);
            this.groupBox1.Location = new System.Drawing.Point(3, 133);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox1.Size = new System.Drawing.Size(571, 54);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(438, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 31);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(337, 15);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(101, 32);
            this.btnPreview.TabIndex = 2;
            this.btnPreview.Text = "&Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // fCustomerDueRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(578, 196);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fCustomerDueRpt";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Due Report";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnPreview;
        private ctlCustomControl ctlCustomer;
        private System.Windows.Forms.CheckBox chkDealer;
        private System.Windows.Forms.CheckBox chkRetail;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkCredit;
    }
}