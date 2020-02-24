namespace INVENTORY.UI
{
    partial class fDamageProduct
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
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.numTPrice = new System.Windows.Forms.NumericUpDown();
            this.numUP = new System.Windows.Forms.NumericUpDown();
            this.numQTY = new System.Windows.Forms.NumericUpDown();
            this.ctlProduct = new INVENTORY.UI.ctlCustomControl();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQTY)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numStock);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.numTPrice);
            this.groupBox1.Controls.Add(this.numUP);
            this.groupBox1.Controls.Add(this.numQTY);
            this.groupBox1.Controls.Add(this.ctlProduct);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(545, 163);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // numStock
            // 
            this.numStock.BackColor = System.Drawing.Color.SlateGray;
            this.numStock.Enabled = false;
            this.numStock.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numStock.ForeColor = System.Drawing.Color.White;
            this.numStock.Location = new System.Drawing.Point(115, 57);
            this.numStock.Margin = new System.Windows.Forms.Padding(4);
            this.numStock.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numStock.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.numStock.Name = "numStock";
            this.numStock.ReadOnly = true;
            this.numStock.Size = new System.Drawing.Size(145, 29);
            this.numStock.TabIndex = 5;
            this.numStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 61);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 22);
            this.label17.TabIndex = 181;
            this.label17.Text = "Total Stock";
            // 
            // numTPrice
            // 
            this.numTPrice.DecimalPlaces = 2;
            this.numTPrice.Enabled = false;
            this.numTPrice.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTPrice.Location = new System.Drawing.Point(380, 92);
            this.numTPrice.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numTPrice.Name = "numTPrice";
            this.numTPrice.Size = new System.Drawing.Size(146, 27);
            this.numTPrice.TabIndex = 4;
            this.numTPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numUP
            // 
            this.numUP.Enabled = false;
            this.numUP.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUP.Location = new System.Drawing.Point(380, 58);
            this.numUP.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numUP.Name = "numUP";
            this.numUP.Size = new System.Drawing.Size(146, 27);
            this.numUP.TabIndex = 3;
            this.numUP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numUP.ValueChanged += new System.EventHandler(this.numUP_ValueChanged);
            // 
            // numQTY
            // 
            this.numQTY.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQTY.Location = new System.Drawing.Point(115, 123);
            this.numQTY.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numQTY.Name = "numQTY";
            this.numQTY.Size = new System.Drawing.Size(145, 27);
            this.numQTY.TabIndex = 1;
            this.numQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numQTY.ValueChanged += new System.EventHandler(this.numQTY_ValueChanged);
            this.numQTY.Enter += new System.EventHandler(this.numQTY_Enter);
            // 
            // ctlProduct
            // 
            this.ctlProduct.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlProduct.Location = new System.Drawing.Point(115, 16);
            this.ctlProduct.Margin = new System.Windows.Forms.Padding(4);
            this.ctlProduct.Name = "ctlProduct";
            this.ctlProduct.ObjectName = "StockDetail";
            this.ctlProduct.Size = new System.Drawing.Size(411, 36);
            this.ctlProduct.TabIndex = 0;
            this.ctlProduct.SelectedItemChanged += new INVENTORY.UI.SelectionChangedEvent(this.ctlProduct_SelectedItemChanged);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd MMM yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(115, 92);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(145, 27);
            this.dtpDate.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(286, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(286, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Unit Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Entry Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Location = new System.Drawing.Point(6, 163);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(545, 57);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(441, 16);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 33);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(346, 16);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 33);
            this.btnSave.TabIndex = 0;
            this.btnSave.Tag = "btnSave";
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // fDamageProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(555, 227);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fDamageProduct";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Damage Product";
            this.Load += new System.EventHandler(this.fDamageProduct_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQTY)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ctlCustomControl ctlProduct;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.NumericUpDown numQTY;
        private System.Windows.Forms.NumericUpDown numTPrice;
        private System.Windows.Forms.NumericUpDown numUP;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.Label label17;
    }
}