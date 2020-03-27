using System;
using INVENTORY.UI.BL;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lblNetTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblhst = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.grppromo = new System.Windows.Forms.GroupBox();
            this.lblcashback = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.SLNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pctboxpromo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductspromo)).BeginInit();
            this.grppromo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pctboxpromo
            // 
            this.pctboxpromo.Location = new System.Drawing.Point(638, 23);
            this.pctboxpromo.Margin = new System.Windows.Forms.Padding(4);
            this.pctboxpromo.Name = "pctboxpromo";
            this.pctboxpromo.Size = new System.Drawing.Size(632, 694);
            this.pctboxpromo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctboxpromo.TabIndex = 0;
            this.pctboxpromo.TabStop = false;
            // 
            // dgProductspromo
            // 
            this.dgProductspromo.AllowUserToAddRows = false;
            this.dgProductspromo.AllowUserToDeleteRows = false;
            this.dgProductspromo.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgProductspromo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductspromo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SLNO,
            this.clnName,
            this.clnQTY,
            this.clnUnitPrice,
            this.clnTotal,
            this.clVAT});
            this.dgProductspromo.Location = new System.Drawing.Point(8, 15);
            this.dgProductspromo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dgProductspromo.MultiSelect = false;
            this.dgProductspromo.Name = "dgProductspromo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProductspromo.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProductspromo.RowHeadersVisible = false;
            this.dgProductspromo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProductspromo.Size = new System.Drawing.Size(610, 418);
            this.dgProductspromo.TabIndex = 6;
            // 
            // lblbilltotal
            // 
            this.lblbilltotal.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbilltotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblbilltotal.Location = new System.Drawing.Point(226, 434);
            this.lblbilltotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbilltotal.Name = "lblbilltotal";
            this.lblbilltotal.Size = new System.Drawing.Size(405, 56);
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
            this.lblsavings.Location = new System.Drawing.Point(500, 546);
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
            this.lblrefundqty.Location = new System.Drawing.Point(501, 519);
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
            this.label58.Location = new System.Drawing.Point(378, 522);
            this.label58.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(104, 25);
            this.label58.TabIndex = 284;
            this.label58.Text = "Refund       :";
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Black;
            this.label51.Location = new System.Drawing.Point(378, 493);
            this.label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(104, 25);
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
            // lblNetTotal
            // 
            this.lblNetTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetTotal.ForeColor = System.Drawing.Color.Black;
            this.lblNetTotal.Location = new System.Drawing.Point(501, 491);
            this.lblNetTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNetTotal.Name = "lblNetTotal";
            this.lblNetTotal.Size = new System.Drawing.Size(107, 28);
            this.lblNetTotal.TabIndex = 290;
            this.lblNetTotal.Text = "0.00\r\n\r\n";
            this.lblNetTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(379, 546);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 289;
            this.label2.Text = "Saving        :";
            // 
            // lblhst
            // 
            this.lblhst.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhst.ForeColor = System.Drawing.Color.Black;
            this.lblhst.Location = new System.Drawing.Point(188, 542);
            this.lblhst.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblhst.Name = "lblhst";
            this.lblhst.Size = new System.Drawing.Size(163, 28);
            this.lblhst.TabIndex = 288;
            this.lblhst.Text = "0.00\r\n\r\n";
            this.lblhst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(25, 544);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 24);
            this.label4.TabIndex = 287;
            this.label4.Text = "HST :";
            // 
            // lblPayment
            // 
            this.lblPayment.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPayment.Location = new System.Drawing.Point(256, 591);
            this.lblPayment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(375, 51);
            this.lblPayment.TabIndex = 292;
            this.lblPayment.Text = "0.00\r\n\r\n";
            this.lblPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(21, 591);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 34);
            this.label6.TabIndex = 291;
            this.label6.Text = "Payment :";
            // 
            // lblBalance
            // 
            this.lblBalance.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBalance.Location = new System.Drawing.Point(258, 642);
            this.lblBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(373, 49);
            this.lblBalance.TabIndex = 294;
            this.lblBalance.Text = "0.00\r\n\r\n";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(22, 642);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(201, 40);
            this.label8.TabIndex = 293;
            this.label8.Text = "Balance  :";
            // 
            // grppromo
            // 
            this.grppromo.Controls.Add(this.lblcashback);
            this.grppromo.Controls.Add(this.label59);
            this.grppromo.Controls.Add(this.dgProductspromo);
            this.grppromo.Controls.Add(this.lblBalance);
            this.grppromo.Controls.Add(this.label52);
            this.grppromo.Controls.Add(this.label8);
            this.grppromo.Controls.Add(this.lblbilltotal);
            this.grppromo.Controls.Add(this.lblPayment);
            this.grppromo.Controls.Add(this.label55);
            this.grppromo.Controls.Add(this.label6);
            this.grppromo.Controls.Add(this.label53);
            this.grppromo.Controls.Add(this.lblNetTotal);
            this.grppromo.Controls.Add(this.lblbillqty);
            this.grppromo.Controls.Add(this.label2);
            this.grppromo.Controls.Add(this.lblbilldisc);
            this.grppromo.Controls.Add(this.lblhst);
            this.grppromo.Controls.Add(this.label51);
            this.grppromo.Controls.Add(this.label4);
            this.grppromo.Controls.Add(this.label58);
            this.grppromo.Controls.Add(this.lblsavings);
            this.grppromo.Controls.Add(this.lblrefundqty);
            this.grppromo.Location = new System.Drawing.Point(12, 12);
            this.grppromo.Name = "grppromo";
            this.grppromo.Size = new System.Drawing.Size(621, 706);
            this.grppromo.TabIndex = 295;
            this.grppromo.TabStop = false;
            // 
            // lblcashback
            // 
            this.lblcashback.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcashback.ForeColor = System.Drawing.Color.Black;
            this.lblcashback.Location = new System.Drawing.Point(527, 570);
            this.lblcashback.Name = "lblcashback";
            this.lblcashback.Size = new System.Drawing.Size(80, 22);
            this.lblcashback.TabIndex = 296;
            this.lblcashback.Text = "0.00\r\n\r\n";
            this.lblcashback.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label59
            // 
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.ForeColor = System.Drawing.Color.Black;
            this.label59.Location = new System.Drawing.Point(378, 570);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(113, 20);
            this.label59.TabIndex = 295;
            this.label59.Text = "Cashback   :";
            // 
            // SLNO
            // 
            this.SLNO.HeaderText = "SLNO";
            this.SLNO.Name = "SLNO";
            this.SLNO.Visible = false;
            // 
            // clnName
            // 
            this.clnName.DataPropertyName = "ItemName";
            this.clnName.HeaderText = "DESCRIPTION";
            this.clnName.Name = "clnName";
            this.clnName.ReadOnly = true;
            this.clnName.Width = 300;
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
            this.clnUnitPrice.DataPropertyName = "SRate";
            this.clnUnitPrice.HeaderText = "PRICE";
            this.clnUnitPrice.Name = "clnUnitPrice";
            this.clnUnitPrice.ReadOnly = true;
            // 
            // clnTotal
            // 
            this.clnTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnTotal.DataPropertyName = "Amount";
            this.clnTotal.HeaderText = "AMOUNT";
            this.clnTotal.Name = "clnTotal";
            this.clnTotal.ReadOnly = true;
            // 
            // clVAT
            // 
            this.clVAT.DataPropertyName = "HST";
            this.clVAT.HeaderText = "VAT";
            this.clVAT.Name = "clVAT";
            this.clVAT.Visible = false;
            // 
            // frmpromo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 730);
            this.Controls.Add(this.grppromo);
            this.Controls.Add(this.pctboxpromo);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmpromo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmpromo_Load);
            this.Shown += new System.EventHandler(this.frmpromo_Shown);
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
        private System.Windows.Forms.Label lblNetTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblhst;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.DataGridView dgProductspromo;
        internal System.Windows.Forms.GroupBox grppromo;
        internal System.Windows.Forms.PictureBox pctboxpromo;
        private System.Windows.Forms.Label lblcashback;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVAT;
    }
}