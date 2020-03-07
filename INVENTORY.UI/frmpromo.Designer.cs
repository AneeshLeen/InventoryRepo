namespace INVENTORY.UI
{
    partial class frmpromo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pctboxpromo = new System.Windows.Forms.PictureBox();
            this.dgProductspromo = new System.Windows.Forms.DataGridView();
            this.lblbilltotal = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.lblsavings = new System.Windows.Forms.Label();
            this.lblrefundqty = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.lblbilldisc = new System.Windows.Forms.Label();
            this.lblbillqty = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.clnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grppromo = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctboxpromo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductspromo)).BeginInit();
            this.grppromo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pctboxpromo
            // 
            this.pctboxpromo.Location = new System.Drawing.Point(703, 27);
            this.pctboxpromo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pctboxpromo.Name = "pctboxpromo";
            this.pctboxpromo.Size = new System.Drawing.Size(723, 676);
            this.pctboxpromo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctboxpromo.TabIndex = 0;
            this.pctboxpromo.TabStop = false;
            // 
            // dgProductspromo
            // 
            this.dgProductspromo.AllowUserToAddRows = false;
            this.dgProductspromo.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgProductspromo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductspromo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnName,
            this.clnQTY,
            this.clnUnitPrice,
            this.clnTotal,
            this.clVAT});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProductspromo.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgProductspromo.Location = new System.Drawing.Point(8, 15);
            this.dgProductspromo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dgProductspromo.MultiSelect = false;
            this.dgProductspromo.Name = "dgProductspromo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProductspromo.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgProductspromo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProductspromo.Size = new System.Drawing.Size(663, 418);
            this.dgProductspromo.TabIndex = 6;
            // 
            // lblbilltotal
            // 
            this.lblbilltotal.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbilltotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblbilltotal.Location = new System.Drawing.Point(245, 435);
            this.lblbilltotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbilltotal.Name = "lblbilltotal";
            this.lblbilltotal.Size = new System.Drawing.Size(415, 56);
            this.lblbilltotal.TabIndex = 239;
            this.lblbilltotal.Text = "0.00\r\n\r\n";
            this.lblbilltotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label52.Location = new System.Drawing.Point(21, 439);
            this.label52.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(201, 36);
            this.label52.TabIndex = 238;
            this.label52.Text = "Bill Total\r\n\r\n";
            // 
            // lblsavings
            // 
            this.lblsavings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsavings.ForeColor = System.Drawing.Color.Black;
            this.lblsavings.Location = new System.Drawing.Point(576, 519);
            this.lblsavings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblsavings.Name = "lblsavings";
            this.lblsavings.Size = new System.Drawing.Size(107, 28);
            this.lblsavings.TabIndex = 286;
            this.lblsavings.Text = "0.00\r\n\r\n";
            this.lblsavings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblrefundqty
            // 
            this.lblrefundqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrefundqty.ForeColor = System.Drawing.Color.Black;
            this.lblrefundqty.Location = new System.Drawing.Point(575, 491);
            this.lblrefundqty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblrefundqty.Name = "lblrefundqty";
            this.lblrefundqty.Size = new System.Drawing.Size(107, 28);
            this.lblrefundqty.TabIndex = 285;
            this.lblrefundqty.Text = "0.00\r\n\r\n";
            this.lblrefundqty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label58
            // 
            this.label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.Black;
            this.label58.Location = new System.Drawing.Point(443, 522);
            this.label58.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(145, 25);
            this.label58.TabIndex = 284;
            this.label58.Text = "Refund       :";
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Black;
            this.label51.Location = new System.Drawing.Point(443, 493);
            this.label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(145, 25);
            this.label51.TabIndex = 283;
            this.label51.Text = "Net Tot       :";
            // 
            // lblbilldisc
            // 
            this.lblbilldisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbilldisc.ForeColor = System.Drawing.Color.Black;
            this.lblbilldisc.Location = new System.Drawing.Point(188, 490);
            this.lblbilldisc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbilldisc.Name = "lblbilldisc";
            this.lblbilldisc.Size = new System.Drawing.Size(155, 28);
            this.lblbilldisc.TabIndex = 282;
            this.lblbilldisc.Text = "0.00\r\n\r\n";
            this.lblbilldisc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblbillqty
            // 
            this.lblbillqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbillqty.ForeColor = System.Drawing.Color.Black;
            this.lblbillqty.Location = new System.Drawing.Point(188, 519);
            this.lblbillqty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbillqty.Name = "lblbillqty";
            this.lblbillqty.Size = new System.Drawing.Size(163, 28);
            this.lblbillqty.TabIndex = 281;
            this.lblbillqty.Text = "0.00\r\n\r\n";
            this.lblbillqty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.Color.Black;
            this.label53.Location = new System.Drawing.Point(24, 519);
            this.label53.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(156, 24);
            this.label53.TabIndex = 280;
            this.label53.Text = "No of Items :";
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.Color.Black;
            this.label55.Location = new System.Drawing.Point(24, 489);
            this.label55.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(136, 25);
            this.label55.TabIndex = 279;
            this.label55.Text = "Bill Dis :";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(577, 542);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 28);
            this.label1.TabIndex = 290;
            this.label1.Text = "0.00\r\n\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(444, 545);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 289;
            this.label2.Text = "Saving        :";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(188, 542);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 28);
            this.label3.TabIndex = 288;
            this.label3.Text = "0.00\r\n\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(25, 542);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 24);
            this.label4.TabIndex = 287;
            this.label4.Text = "HST :";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(256, 591);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(415, 51);
            this.label5.TabIndex = 292;
            this.label5.Text = "0.00\r\n\r\n";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(41, 595);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 34);
            this.label6.TabIndex = 291;
            this.label6.Text = "Payment :";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(258, 642);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(415, 49);
            this.label7.TabIndex = 294;
            this.label7.Text = "0.00\r\n\r\n";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(41, 642);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(201, 40);
            this.label8.TabIndex = 293;
            this.label8.Text = "Balance  :";
            // 
            // clnName
            // 
            this.clnName.HeaderText = "DESCRIPTION";
            this.clnName.Name = "clnName";
            this.clnName.ReadOnly = true;
            this.clnName.Width = 250;
            // 
            // clnQTY
            // 
            this.clnQTY.HeaderText = "QTY";
            this.clnQTY.Name = "clnQTY";
            this.clnQTY.ReadOnly = true;
            this.clnQTY.Width = 80;
            // 
            // clnUnitPrice
            // 
            this.clnUnitPrice.HeaderText = "PRICE";
            this.clnUnitPrice.Name = "clnUnitPrice";
            this.clnUnitPrice.ReadOnly = true;
            // 
            // clnTotal
            // 
            this.clnTotal.HeaderText = "AMOUNT";
            this.clnTotal.Name = "clnTotal";
            this.clnTotal.ReadOnly = true;
            this.clnTotal.Width = 110;
            // 
            // clVAT
            // 
            this.clVAT.HeaderText = "VAT";
            this.clVAT.Name = "clVAT";
            // 
            // grppromo
            // 
            this.grppromo.Controls.Add(this.dgProductspromo);
            this.grppromo.Controls.Add(this.label7);
            this.grppromo.Controls.Add(this.label52);
            this.grppromo.Controls.Add(this.label8);
            this.grppromo.Controls.Add(this.lblbilltotal);
            this.grppromo.Controls.Add(this.label5);
            this.grppromo.Controls.Add(this.label55);
            this.grppromo.Controls.Add(this.label6);
            this.grppromo.Controls.Add(this.label53);
            this.grppromo.Controls.Add(this.label1);
            this.grppromo.Controls.Add(this.lblbillqty);
            this.grppromo.Controls.Add(this.label2);
            this.grppromo.Controls.Add(this.lblbilldisc);
            this.grppromo.Controls.Add(this.label3);
            this.grppromo.Controls.Add(this.label51);
            this.grppromo.Controls.Add(this.label4);
            this.grppromo.Controls.Add(this.label58);
            this.grppromo.Controls.Add(this.lblsavings);
            this.grppromo.Controls.Add(this.lblrefundqty);
            this.grppromo.Location = new System.Drawing.Point(12, 12);
            this.grppromo.Name = "grppromo";
            this.grppromo.Size = new System.Drawing.Size(683, 706);
            this.grppromo.TabIndex = 295;
            this.grppromo.TabStop = false;
            // 
            // frmpromo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 730);
            this.Controls.Add(this.grppromo);
            this.Controls.Add(this.pctboxpromo);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmpromo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmpromo_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmpromo_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pctboxpromo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductspromo)).EndInit();
            this.grppromo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblbilltotal;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label lblsavings;
        private System.Windows.Forms.Label lblrefundqty;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label lblbilldisc;
        private System.Windows.Forms.Label lblbillqty;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.DataGridView dgProductspromo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVAT;
        internal System.Windows.Forms.GroupBox grppromo;
        internal System.Windows.Forms.PictureBox pctboxpromo;
    }
}