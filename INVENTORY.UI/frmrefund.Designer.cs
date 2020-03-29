namespace INVENTORY.UI
{
    partial class frmrefund
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmrefund));
            this.dgProducts = new System.Windows.Forms.DataGridView();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtorderrefno = new System.Windows.Forms.TextBox();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblbilltotal = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.chkrefund = new System.Windows.Forms.CheckBox();
            this.clnitmno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnrefundqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnrefundamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOrderDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProducts
            // 
            this.dgProducts.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProducts.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnitmno,
            this.clnQTY,
            this.clnUnitPrice,
            this.clnTotal,
            this.clnrefundqty,
            this.clnrefundamt,
            this.SOrderDetailID});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProducts.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgProducts.Location = new System.Drawing.Point(2, 75);
            this.dgProducts.Margin = new System.Windows.Forms.Padding(4);
            this.dgProducts.Name = "dgProducts";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgProducts.RowHeadersVisible = false;
            this.dgProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProducts.Size = new System.Drawing.Size(655, 382);
            this.dgProducts.TabIndex = 6;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBarcode.Location = new System.Drawing.Point(13, 29);
            this.lblBarcode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(97, 19);
            this.lblBarcode.TabIndex = 18;
            this.lblBarcode.Text = "Order Ref No";
            // 
            // txtorderrefno
            // 
            this.txtorderrefno.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtorderrefno.Location = new System.Drawing.Point(118, 28);
            this.txtorderrefno.Margin = new System.Windows.Forms.Padding(4);
            this.txtorderrefno.Name = "txtorderrefno";
            this.txtorderrefno.Size = new System.Drawing.Size(183, 22);
            this.txtorderrefno.TabIndex = 17;
            this.txtorderrefno.WordWrap = false;
            this.txtorderrefno.Enter += new System.EventHandler(this.txtorderrefno_Enter);
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.Magenta;
            this.btn5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn5.BackgroundImage")));
            this.btn5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn5.Location = new System.Drawing.Point(444, 8);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(80, 60);
            this.btn5.TabIndex = 250;
            this.btn5.UseVisualStyleBackColor = false;
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.Magenta;
            this.btn4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn4.BackgroundImage")));
            this.btn4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn4.Location = new System.Drawing.Point(556, 8);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(80, 60);
            this.btn4.TabIndex = 249;
            this.btn4.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Magenta;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(556, 504);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 60);
            this.button1.TabIndex = 252;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Magenta;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(431, 504);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 60);
            this.button2.TabIndex = 251;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // lblbilltotal
            // 
            this.lblbilltotal.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblbilltotal.ForeColor = System.Drawing.Color.Black;
            this.lblbilltotal.Location = new System.Drawing.Point(530, 470);
            this.lblbilltotal.Name = "lblbilltotal";
            this.lblbilltotal.Size = new System.Drawing.Size(115, 24);
            this.lblbilltotal.TabIndex = 254;
            this.lblbilltotal.Text = "0.00\r\n\r\n";
            this.lblbilltotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.Black;
            this.label52.Location = new System.Drawing.Point(412, 470);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(112, 24);
            this.label52.TabIndex = 253;
            this.label52.Text = "Total\r\n\r\n";
            // 
            // chkrefund
            // 
            this.chkrefund.AutoSize = true;
            this.chkrefund.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkrefund.Location = new System.Drawing.Point(269, 518);
            this.chkrefund.Name = "chkrefund";
            this.chkrefund.Size = new System.Drawing.Size(112, 24);
            this.chkrefund.TabIndex = 255;
            this.chkrefund.Text = "Refund All";
            this.chkrefund.UseVisualStyleBackColor = true;
            // 
            // clnitmno
            // 
            this.clnitmno.DataPropertyName = "ItemName";
            this.clnitmno.HeaderText = "Item Name";
            this.clnitmno.Name = "clnitmno";
            this.clnitmno.ReadOnly = true;
            this.clnitmno.Width = 200;
            // 
            // clnQTY
            // 
            this.clnQTY.DataPropertyName = "Quantity";
            this.clnQTY.HeaderText = "QTY";
            this.clnQTY.Name = "clnQTY";
            this.clnQTY.ReadOnly = true;
            this.clnQTY.Width = 80;
            // 
            // clnUnitPrice
            // 
            this.clnUnitPrice.DataPropertyName = "UnitPrice";
            this.clnUnitPrice.HeaderText = "Unit Price";
            this.clnUnitPrice.Name = "clnUnitPrice";
            this.clnUnitPrice.ReadOnly = true;
            // 
            // clnTotal
            // 
            this.clnTotal.DataPropertyName = "Amount";
            this.clnTotal.HeaderText = "Amount";
            this.clnTotal.Name = "clnTotal";
            this.clnTotal.ReadOnly = true;
            this.clnTotal.Width = 80;
            // 
            // clnrefundqty
            // 
            this.clnrefundqty.DataPropertyName = "RefundQty";
            this.clnrefundqty.HeaderText = "Refund Qty";
            this.clnrefundqty.Name = "clnrefundqty";
            this.clnrefundqty.Width = 80;
            // 
            // clnrefundamt
            // 
            this.clnrefundamt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnrefundamt.DataPropertyName = "RefundAmt";
            this.clnrefundamt.HeaderText = "Refund Amount";
            this.clnrefundamt.Name = "clnrefundamt";
            // 
            // SOrderDetailID
            // 
            this.SOrderDetailID.DataPropertyName = "SOrderDetailID";
            this.SOrderDetailID.HeaderText = "SOrderDetailID";
            this.SOrderDetailID.Name = "SOrderDetailID";
            this.SOrderDetailID.Visible = false;
            // 
            // frmrefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 570);
            this.Controls.Add(this.chkrefund);
            this.Controls.Add(this.lblbilltotal);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.txtorderrefno);
            this.Controls.Add(this.dgProducts);
            this.Name = "frmrefund";
            this.Text = "Refund All";
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgProducts;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtorderrefno;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblbilltotal;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.CheckBox chkrefund;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnitmno;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnrefundqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnrefundamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOrderDetailID;
    }
}