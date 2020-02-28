namespace INVENTORY.UI
{
    partial class frmmultipayment
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
            this.dgProducts = new System.Windows.Forms.DataGridView();
            this.clnpay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btndoll1 = new System.Windows.Forms.Button();
            this.btncash = new System.Windows.Forms.Button();
            this.lblbillamt = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.lblpaidamt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbldueamt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtclear = new System.Windows.Forms.TextBox();
            this.btnclear = new System.Windows.Forms.Button();
            this.btncard = new System.Windows.Forms.Button();
            this.btndoll2 = new System.Windows.Forms.Button();
            this.btnchque = new System.Windows.Forms.Button();
            this.btndoll10 = new System.Windows.Forms.Button();
            this.btnvoucher = new System.Windows.Forms.Button();
            this.btndoll20 = new System.Windows.Forms.Button();
            this.btnaccount = new System.Windows.Forms.Button();
            this.btndoll50 = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btndoll100 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn00 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btndot = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProducts
            // 
            this.dgProducts.AllowUserToAddRows = false;
            this.dgProducts.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnpay,
            this.clnamount});
            this.dgProducts.Location = new System.Drawing.Point(2, 34);
            this.dgProducts.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgProducts.Name = "dgProducts";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProducts.Size = new System.Drawing.Size(320, 257);
            this.dgProducts.TabIndex = 6;
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
            // btndoll1
            // 
            this.btndoll1.BackColor = System.Drawing.Color.Magenta;
            this.btndoll1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndoll1.Location = new System.Drawing.Point(328, 34);
            this.btndoll1.Name = "btndoll1";
            this.btndoll1.Size = new System.Drawing.Size(131, 81);
            this.btndoll1.TabIndex = 244;
            this.btndoll1.Text = "$ 1";
            this.btndoll1.UseVisualStyleBackColor = false;
            // 
            // btncash
            // 
            this.btncash.BackColor = System.Drawing.Color.Magenta;
            this.btncash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncash.Location = new System.Drawing.Point(461, 34);
            this.btncash.Name = "btncash";
            this.btncash.Size = new System.Drawing.Size(131, 81);
            this.btncash.TabIndex = 245;
            this.btncash.Text = "CASH";
            this.btncash.UseVisualStyleBackColor = false;
            // 
            // lblbillamt
            // 
            this.lblbillamt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbillamt.ForeColor = System.Drawing.Color.Maroon;
            this.lblbillamt.Location = new System.Drawing.Point(185, 10);
            this.lblbillamt.Name = "lblbillamt";
            this.lblbillamt.Size = new System.Drawing.Size(135, 20);
            this.lblbillamt.TabIndex = 275;
            this.lblbillamt.Text = "0.00\r\n\r\n";
            this.lblbillamt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.Color.Maroon;
            this.label55.Location = new System.Drawing.Point(13, 8);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(136, 18);
            this.label55.TabIndex = 274;
            this.label55.Text = "Bill Amount   :";
            // 
            // lblpaidamt
            // 
            this.lblpaidamt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpaidamt.ForeColor = System.Drawing.Color.Black;
            this.lblpaidamt.Location = new System.Drawing.Point(182, 295);
            this.lblpaidamt.Name = "lblpaidamt";
            this.lblpaidamt.Size = new System.Drawing.Size(135, 20);
            this.lblpaidamt.TabIndex = 277;
            this.lblpaidamt.Text = "0.00\r\n\r\n";
            this.lblpaidamt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 18);
            this.label2.TabIndex = 276;
            this.label2.Text = "Paid Amount  :";
            // 
            // lbldueamt
            // 
            this.lbldueamt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldueamt.ForeColor = System.Drawing.Color.Maroon;
            this.lbldueamt.Location = new System.Drawing.Point(182, 319);
            this.lbldueamt.Name = "lbldueamt";
            this.lbldueamt.Size = new System.Drawing.Size(135, 20);
            this.lbldueamt.TabIndex = 279;
            this.lbldueamt.Text = "0.00\r\n\r\n";
            this.lbldueamt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(15, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 18);
            this.label4.TabIndex = 278;
            this.label4.Text = "Due Amount  :";
            // 
            // txtclear
            // 
            this.txtclear.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtclear.Location = new System.Drawing.Point(6, 346);
            this.txtclear.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtclear.Name = "txtclear";
            this.txtclear.Size = new System.Drawing.Size(224, 22);
            this.txtclear.TabIndex = 280;
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.Magenta;
            this.btnclear.Location = new System.Drawing.Point(236, 344);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(86, 25);
            this.btnclear.TabIndex = 281;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            // 
            // btncard
            // 
            this.btncard.BackColor = System.Drawing.Color.Magenta;
            this.btncard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncard.Location = new System.Drawing.Point(461, 117);
            this.btncard.Name = "btncard";
            this.btncard.Size = new System.Drawing.Size(131, 81);
            this.btncard.TabIndex = 283;
            this.btncard.Text = "CARD";
            this.btncard.UseVisualStyleBackColor = false;
            // 
            // btndoll2
            // 
            this.btndoll2.BackColor = System.Drawing.Color.Magenta;
            this.btndoll2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndoll2.Location = new System.Drawing.Point(328, 117);
            this.btndoll2.Name = "btndoll2";
            this.btndoll2.Size = new System.Drawing.Size(131, 81);
            this.btndoll2.TabIndex = 282;
            this.btndoll2.Text = "$ 2";
            this.btndoll2.UseVisualStyleBackColor = false;
            // 
            // btnchque
            // 
            this.btnchque.BackColor = System.Drawing.Color.Magenta;
            this.btnchque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnchque.Location = new System.Drawing.Point(461, 201);
            this.btnchque.Name = "btnchque";
            this.btnchque.Size = new System.Drawing.Size(131, 81);
            this.btnchque.TabIndex = 285;
            this.btnchque.Text = "CHEQUE";
            this.btnchque.UseVisualStyleBackColor = false;
            // 
            // btndoll10
            // 
            this.btndoll10.BackColor = System.Drawing.Color.Magenta;
            this.btndoll10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndoll10.Location = new System.Drawing.Point(328, 201);
            this.btndoll10.Name = "btndoll10";
            this.btndoll10.Size = new System.Drawing.Size(131, 81);
            this.btndoll10.TabIndex = 284;
            this.btndoll10.Text = "$ 10";
            this.btndoll10.UseVisualStyleBackColor = false;
            // 
            // btnvoucher
            // 
            this.btnvoucher.BackColor = System.Drawing.Color.Magenta;
            this.btnvoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnvoucher.Location = new System.Drawing.Point(461, 282);
            this.btnvoucher.Name = "btnvoucher";
            this.btnvoucher.Size = new System.Drawing.Size(131, 81);
            this.btnvoucher.TabIndex = 287;
            this.btnvoucher.Text = "VOUCHER";
            this.btnvoucher.UseVisualStyleBackColor = false;
            // 
            // btndoll20
            // 
            this.btndoll20.BackColor = System.Drawing.Color.Magenta;
            this.btndoll20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndoll20.Location = new System.Drawing.Point(328, 283);
            this.btndoll20.Name = "btndoll20";
            this.btndoll20.Size = new System.Drawing.Size(131, 81);
            this.btndoll20.TabIndex = 286;
            this.btndoll20.Text = "$ 20";
            this.btndoll20.UseVisualStyleBackColor = false;
            // 
            // btnaccount
            // 
            this.btnaccount.BackColor = System.Drawing.Color.Magenta;
            this.btnaccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaccount.Location = new System.Drawing.Point(461, 365);
            this.btnaccount.Name = "btnaccount";
            this.btnaccount.Size = new System.Drawing.Size(131, 81);
            this.btnaccount.TabIndex = 289;
            this.btnaccount.Text = "ACCOUNT";
            this.btnaccount.UseVisualStyleBackColor = false;
            // 
            // btndoll50
            // 
            this.btndoll50.BackColor = System.Drawing.Color.Magenta;
            this.btndoll50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndoll50.Location = new System.Drawing.Point(328, 365);
            this.btndoll50.Name = "btndoll50";
            this.btndoll50.Size = new System.Drawing.Size(131, 81);
            this.btndoll50.TabIndex = 288;
            this.btndoll50.Text = "$ 50";
            this.btndoll50.UseVisualStyleBackColor = false;
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.Location = new System.Drawing.Point(461, 449);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(131, 81);
            this.btnexit.TabIndex = 291;
            this.btnexit.Text = "EXIT";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btndoll100
            // 
            this.btndoll100.BackColor = System.Drawing.Color.Magenta;
            this.btndoll100.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndoll100.Location = new System.Drawing.Point(328, 449);
            this.btndoll100.Name = "btndoll100";
            this.btndoll100.Size = new System.Drawing.Size(131, 81);
            this.btndoll100.TabIndex = 290;
            this.btndoll100.Text = "$ 100";
            this.btndoll100.UseVisualStyleBackColor = false;
            // 
            // btn7
            // 
            this.btn7.BackColor = System.Drawing.Color.Magenta;
            this.btn7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.Location = new System.Drawing.Point(2, 370);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(75, 54);
            this.btn7.TabIndex = 292;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = false;
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.Color.Magenta;
            this.btn8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.Location = new System.Drawing.Point(84, 370);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(75, 54);
            this.btn8.TabIndex = 293;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = false;
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.Color.Magenta;
            this.btn9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.Location = new System.Drawing.Point(166, 370);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(75, 54);
            this.btn9.TabIndex = 294;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = false;
            // 
            // btn00
            // 
            this.btn00.BackColor = System.Drawing.Color.Magenta;
            this.btn00.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn00.Location = new System.Drawing.Point(247, 373);
            this.btn00.Name = "btn00";
            this.btn00.Size = new System.Drawing.Size(75, 54);
            this.btn00.TabIndex = 295;
            this.btn00.Text = "00";
            this.btn00.UseVisualStyleBackColor = false;
            // 
            // btn0
            // 
            this.btn0.BackColor = System.Drawing.Color.Magenta;
            this.btn0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.Location = new System.Drawing.Point(247, 424);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(75, 54);
            this.btn0.TabIndex = 299;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = false;
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.Magenta;
            this.btn6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.Location = new System.Drawing.Point(166, 424);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(75, 54);
            this.btn6.TabIndex = 298;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = false;
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.Magenta;
            this.btn5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.Location = new System.Drawing.Point(84, 424);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(75, 54);
            this.btn5.TabIndex = 297;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = false;
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.Magenta;
            this.btn4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.Location = new System.Drawing.Point(2, 424);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(75, 54);
            this.btn4.TabIndex = 296;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = false;
            // 
            // btndot
            // 
            this.btndot.BackColor = System.Drawing.Color.Magenta;
            this.btndot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndot.Location = new System.Drawing.Point(247, 478);
            this.btndot.Name = "btndot";
            this.btndot.Size = new System.Drawing.Size(75, 54);
            this.btndot.TabIndex = 303;
            this.btndot.Text = ".";
            this.btndot.UseVisualStyleBackColor = false;
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.Magenta;
            this.btn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Location = new System.Drawing.Point(166, 478);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(75, 54);
            this.btn3.TabIndex = 302;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = false;
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.Magenta;
            this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(84, 478);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 54);
            this.btn2.TabIndex = 301;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = false;
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.Magenta;
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(2, 478);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 54);
            this.btn1.TabIndex = 300;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = false;
            // 
            // frmmultipayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(597, 537);
            this.Controls.Add(this.btndot);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn00);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btndoll100);
            this.Controls.Add(this.btnaccount);
            this.Controls.Add(this.btndoll50);
            this.Controls.Add(this.btnvoucher);
            this.Controls.Add(this.btndoll20);
            this.Controls.Add(this.btnchque);
            this.Controls.Add(this.btndoll10);
            this.Controls.Add(this.btncard);
            this.Controls.Add(this.btndoll2);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.txtclear);
            this.Controls.Add(this.lbldueamt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblpaidamt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblbillamt);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.btncash);
            this.Controls.Add(this.btndoll1);
            this.Controls.Add(this.dgProducts);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmmultipayment";
            this.Text = "Multi Payment";
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn clnpay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnamount;
        private System.Windows.Forms.Button btndoll1;
        private System.Windows.Forms.Button btncash;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtclear;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btncard;
        private System.Windows.Forms.Button btndoll2;
        private System.Windows.Forms.Button btnchque;
        private System.Windows.Forms.Button btndoll10;
        private System.Windows.Forms.Button btnvoucher;
        private System.Windows.Forms.Button btndoll20;
        private System.Windows.Forms.Button btnaccount;
        private System.Windows.Forms.Button btndoll50;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btndoll100;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn00;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btndot;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        internal System.Windows.Forms.DataGridView dgProducts;
        internal System.Windows.Forms.Label lblbillamt;
        internal System.Windows.Forms.Label lblpaidamt;
        internal System.Windows.Forms.Label lbldueamt;
    }
}