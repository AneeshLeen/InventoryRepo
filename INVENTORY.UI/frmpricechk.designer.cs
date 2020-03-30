namespace INVENTORY.UI
{
    partial class frmpricechk
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.lblprice = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.lbltax = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblname1 = new System.Windows.Forms.Label();
            this.lblprice1 = new System.Windows.Forms.Label();
            this.lbltax1 = new System.Windows.Forms.Label();
            this.lblrate1 = new System.Windows.Forms.Label();
            this.lblrate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Check Price :";
            // 
            // txtsearch
            // 
            this.txtsearch.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtsearch.Location = new System.Drawing.Point(162, 29);
            this.txtsearch.Multiline = true;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(217, 33);
            this.txtsearch.TabIndex = 1;
            this.txtsearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsearch_KeyDown);
            this.txtsearch.Validated += new System.EventHandler(this.textBox1_Validated);
            // 
            // lblprice
            // 
            this.lblprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprice.Location = new System.Drawing.Point(3, 131);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(96, 26);
            this.lblprice.TabIndex = 2;
            this.lblprice.Text = "Price  :";
            // 
            // lblname
            // 
            this.lblname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(3, 82);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(86, 26);
            this.lblname.TabIndex = 3;
            this.lblname.Text = "Name :";
            // 
            // lbltax
            // 
            this.lbltax.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltax.Location = new System.Drawing.Point(3, 192);
            this.lbltax.Name = "lbltax";
            this.lbltax.Size = new System.Drawing.Size(86, 26);
            this.lbltax.TabIndex = 4;
            this.lbltax.Text = "Tax    :";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(162, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.Enter += new System.EventHandler(this.button1_Enter);
            // 
            // lblname1
            // 
            this.lblname1.AutoSize = true;
            this.lblname1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblname1.Location = new System.Drawing.Point(95, 82);
            this.lblname1.Name = "lblname1";
            this.lblname1.Size = new System.Drawing.Size(0, 31);
            this.lblname1.TabIndex = 6;
            // 
            // lblprice1
            // 
            this.lblprice1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprice1.Location = new System.Drawing.Point(95, 131);
            this.lblprice1.Name = "lblprice1";
            this.lblprice1.Size = new System.Drawing.Size(107, 26);
            this.lblprice1.TabIndex = 7;
            // 
            // lbltax1
            // 
            this.lbltax1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltax1.Location = new System.Drawing.Point(95, 192);
            this.lbltax1.Name = "lbltax1";
            this.lbltax1.Size = new System.Drawing.Size(107, 26);
            this.lbltax1.TabIndex = 8;
            // 
            // lblrate1
            // 
            this.lblrate1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrate1.Location = new System.Drawing.Point(3, 245);
            this.lblrate1.Name = "lblrate1";
            this.lblrate1.Size = new System.Drawing.Size(100, 26);
            this.lblrate1.TabIndex = 9;
            this.lblrate1.Text = "Rate  :";
            // 
            // lblrate
            // 
            this.lblrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrate.Location = new System.Drawing.Point(95, 245);
            this.lblrate.Name = "lblrate";
            this.lblrate.Size = new System.Drawing.Size(100, 26);
            this.lblrate.TabIndex = 10;
            // 
            // frmpricechk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(588, 345);
            this.Controls.Add(this.lblrate);
            this.Controls.Add(this.lblrate1);
            this.Controls.Add(this.lbltax1);
            this.Controls.Add(this.lblprice1);
            this.Controls.Add(this.lblname1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbltax);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.lblprice);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmpricechk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Price Check";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label lblprice;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lbltax;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblname1;
        private System.Windows.Forms.Label lblprice1;
        private System.Windows.Forms.Label lbltax1;
        private System.Windows.Forms.Label lblrate1;
        private System.Windows.Forms.Label lblrate;
    }
}