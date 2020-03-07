namespace INVENTORY.UI
{
    partial class frmlastbill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmlastbill));
            this.dgProducts = new System.Windows.Forms.DataGridView();
            this.clnSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clnpay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbldate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblchange = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblbilltotal = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.lblcashier = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbltillno = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProducts
            // 
            this.dgProducts.AllowUserToAddRows = false;
            this.dgProducts.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnSN,
            this.clnName,
            this.clnQTY,
            this.clnUnitPrice,
            this.clnTotal});
            this.dgProducts.Location = new System.Drawing.Point(13, 13);
            this.dgProducts.Margin = new System.Windows.Forms.Padding(4);
            this.dgProducts.Name = "dgProducts";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProducts.Size = new System.Drawing.Size(321, 257);
            this.dgProducts.TabIndex = 6;
            // 
            // clnSN
            // 
            this.clnSN.HeaderText = "SN";
            this.clnSN.Name = "clnSN";
            this.clnSN.ReadOnly = true;
            this.clnSN.Width = 45;
            // 
            // clnName
            // 
            this.clnName.HeaderText = "DESCRIPTION";
            this.clnName.Name = "clnName";
            this.clnName.ReadOnly = true;
            // 
            // clnQTY
            // 
            this.clnQTY.HeaderText = "QTY";
            this.clnQTY.Name = "clnQTY";
            this.clnQTY.ReadOnly = true;
            this.clnQTY.Width = 50;
            // 
            // clnUnitPrice
            // 
            this.clnUnitPrice.HeaderText = "PRICE";
            this.clnUnitPrice.Name = "clnUnitPrice";
            this.clnUnitPrice.ReadOnly = true;
            this.clnUnitPrice.Width = 70;
            // 
            // clnTotal
            // 
            this.clnTotal.HeaderText = "AMOUNT";
            this.clnTotal.Name = "clnTotal";
            this.clnTotal.ReadOnly = true;
            this.clnTotal.Width = 80;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnpay,
            this.clnamount});
            this.dataGridView1.Location = new System.Drawing.Point(13, 300);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(320, 143);
            this.dataGridView1.TabIndex = 7;
            // 
            // clnpay
            // 
            this.clnpay.HeaderText = "Payment Method";
            this.clnpay.Name = "clnpay";
            this.clnpay.ReadOnly = true;
            this.clnpay.Width = 170;
            // 
            // clnamount
            // 
            this.clnamount.HeaderText = "Amount";
            this.clnamount.Name = "clnamount";
            this.clnamount.ReadOnly = true;
            // 
            // lbldate
            // 
            this.lbldate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.ForeColor = System.Drawing.Color.Black;
            this.lbldate.Location = new System.Drawing.Point(180, 484);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(135, 20);
            this.lbldate.TabIndex = 285;
            this.lbldate.Text = "0";
            this.lbldate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(13, 486);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 18);
            this.label4.TabIndex = 284;
            this.label4.Text = "Bill Date  :";
            // 
            // lblchange
            // 
            this.lblchange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblchange.ForeColor = System.Drawing.Color.Black;
            this.lblchange.Location = new System.Drawing.Point(180, 457);
            this.lblchange.Name = "lblchange";
            this.lblchange.Size = new System.Drawing.Size(135, 20);
            this.lblchange.TabIndex = 283;
            this.lblchange.Text = "0.00\r\n\r\n";
            this.lblchange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 457);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 18);
            this.label2.TabIndex = 282;
            this.label2.Text = "Change  :";
            // 
            // lblbilltotal
            // 
            this.lblbilltotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbilltotal.ForeColor = System.Drawing.Color.Black;
            this.lblbilltotal.Location = new System.Drawing.Point(198, 275);
            this.lblbilltotal.Name = "lblbilltotal";
            this.lblbilltotal.Size = new System.Drawing.Size(135, 20);
            this.lblbilltotal.TabIndex = 281;
            this.lblbilltotal.Text = "0.00\r\n\r\n";
            this.lblbilltotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.Color.Black;
            this.label55.Location = new System.Drawing.Point(13, 275);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(136, 18);
            this.label55.TabIndex = 280;
            this.label55.Text = "Bill Total   :";
            // 
            // lblcashier
            // 
            this.lblcashier.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcashier.ForeColor = System.Drawing.Color.Black;
            this.lblcashier.Location = new System.Drawing.Point(180, 534);
            this.lblcashier.Name = "lblcashier";
            this.lblcashier.Size = new System.Drawing.Size(135, 20);
            this.lblcashier.TabIndex = 289;
            this.lblcashier.Text = "0";
            this.lblcashier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 536);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 288;
            this.label3.Text = "Cashier  :";
            // 
            // lbltillno
            // 
            this.lbltillno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltillno.ForeColor = System.Drawing.Color.Black;
            this.lbltillno.Location = new System.Drawing.Point(180, 507);
            this.lbltillno.Name = "lbltillno";
            this.lbltillno.Size = new System.Drawing.Size(135, 20);
            this.lbltillno.TabIndex = 287;
            this.lbltillno.Text = "0";
            this.lbltillno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 511);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 18);
            this.label6.TabIndex = 286;
            this.label6.Text = "Till No  :";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(342, 202);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 68);
            this.btnClose.TabIndex = 290;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(342, 94);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 68);
            this.button1.TabIndex = 291;
            this.button1.Text = "A4 Print";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Palatino Linotype", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button2.Location = new System.Drawing.Point(342, 13);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 68);
            this.button2.TabIndex = 292;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmlastbill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(458, 568);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblcashier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbltillno);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblchange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblbilltotal);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dgProducts);
            this.Name = "frmlastbill";
            this.Text = "frmlastbill";
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgProducts;
        internal System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnpay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTotal;
        internal System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label lblchange;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label lblbilltotal;
        private System.Windows.Forms.Label label55;
        internal System.Windows.Forms.Label lblcashier;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label lbltillno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}