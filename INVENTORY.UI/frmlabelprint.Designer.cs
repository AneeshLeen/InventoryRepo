namespace INVENTORY.UI
{
    partial class frmlabelprint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmlabelprint));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.dgProducts = new System.Windows.Forms.DataGridView();
            this.clnSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnadd = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btncleattext = new System.Windows.Forms.Button();
            this.dgupdatproducts = new System.Windows.Forms.DataGridView();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtproductcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtproductname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsalesprice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtnooflabels = new System.Windows.Forms.TextBox();
            this.btnselectall = new System.Windows.Forms.Button();
            this.btnunselectall = new System.Windows.Forms.Button();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.btnaddselect = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnsearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgupdatproducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.Magenta;
            this.btnprint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnprint.BackgroundImage")));
            this.btnprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnprint.Location = new System.Drawing.Point(634, 580);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(80, 60);
            this.btnprint.TabIndex = 266;
            this.btnprint.UseVisualStyleBackColor = false;
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Magenta;
            this.btnclose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnclose.BackgroundImage")));
            this.btnclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclose.Location = new System.Drawing.Point(720, 580);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(80, 60);
            this.btnclose.TabIndex = 265;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgProducts
            // 
            this.dgProducts.AllowUserToAddRows = false;
            this.dgProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgProducts.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnSN,
            this.clnName,
            this.clnQTY,
            this.clnUnitPrice,
            this.clnTotal});
            this.dgProducts.Location = new System.Drawing.Point(2, 65);
            this.dgProducts.Margin = new System.Windows.Forms.Padding(4);
            this.dgProducts.Name = "dgProducts";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProducts.Size = new System.Drawing.Size(798, 197);
            this.dgProducts.TabIndex = 267;
            // 
            // clnSN
            // 
            this.clnSN.HeaderText = "Product Code";
            this.clnSN.Name = "clnSN";
            this.clnSN.ReadOnly = true;
            this.clnSN.Width = 97;
            // 
            // clnName
            // 
            this.clnName.HeaderText = "BarCode";
            this.clnName.Name = "clnName";
            this.clnName.ReadOnly = true;
            this.clnName.Width = 73;
            // 
            // clnQTY
            // 
            this.clnQTY.HeaderText = "Description";
            this.clnQTY.Name = "clnQTY";
            this.clnQTY.ReadOnly = true;
            this.clnQTY.Width = 85;
            // 
            // clnUnitPrice
            // 
            this.clnUnitPrice.HeaderText = "Price";
            this.clnUnitPrice.Name = "clnUnitPrice";
            this.clnUnitPrice.ReadOnly = true;
            this.clnUnitPrice.Width = 56;
            // 
            // clnTotal
            // 
            this.clnTotal.HeaderText = "No Of Labels";
            this.clnTotal.Name = "clnTotal";
            this.clnTotal.ReadOnly = true;
            this.clnTotal.Width = 94;
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.Magenta;
            this.btnadd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnadd.BackgroundImage")));
            this.btnadd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnadd.Location = new System.Drawing.Point(636, 12);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(54, 51);
            this.btnadd.TabIndex = 270;
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.button4_Click);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.Magenta;
            this.btncancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btncancel.BackgroundImage")));
            this.btncancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncancel.Location = new System.Drawing.Point(746, 12);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(54, 51);
            this.btncancel.TabIndex = 269;
            this.btncancel.UseVisualStyleBackColor = false;
            // 
            // btncleattext
            // 
            this.btncleattext.BackColor = System.Drawing.Color.Magenta;
            this.btncleattext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btncleattext.BackgroundImage")));
            this.btncleattext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncleattext.Location = new System.Drawing.Point(691, 12);
            this.btncleattext.Name = "btncleattext";
            this.btncleattext.Size = new System.Drawing.Size(54, 51);
            this.btncleattext.TabIndex = 268;
            this.btncleattext.UseVisualStyleBackColor = false;
            // 
            // dgupdatproducts
            // 
            this.dgupdatproducts.AllowUserToAddRows = false;
            this.dgupdatproducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgupdatproducts.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgupdatproducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgupdatproducts.Location = new System.Drawing.Point(2, 376);
            this.dgupdatproducts.Margin = new System.Windows.Forms.Padding(4);
            this.dgupdatproducts.Name = "dgupdatproducts";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgupdatproducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgupdatproducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgupdatproducts.Size = new System.Drawing.Size(798, 200);
            this.dgupdatproducts.TabIndex = 271;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBarcode.Location = new System.Drawing.Point(0, 17);
            this.lblBarcode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(59, 19);
            this.lblBarcode.TabIndex = 273;
            this.lblBarcode.Text = "Barcode";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(3, 40);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(106, 22);
            this.txtBarcode.TabIndex = 272;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            this.txtBarcode.Validated += new System.EventHandler(this.txtBarcode_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(116, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 275;
            this.label1.Text = "Product Code";
            // 
            // txtproductcode
            // 
            this.txtproductcode.Enabled = false;
            this.txtproductcode.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproductcode.Location = new System.Drawing.Point(113, 40);
            this.txtproductcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtproductcode.Name = "txtproductcode";
            this.txtproductcode.Size = new System.Drawing.Size(124, 22);
            this.txtproductcode.TabIndex = 274;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(237, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 19);
            this.label2.TabIndex = 277;
            this.label2.Text = "Product Name";
            // 
            // txtproductname
            // 
            this.txtproductname.Enabled = false;
            this.txtproductname.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproductname.Location = new System.Drawing.Point(239, 40);
            this.txtproductname.Margin = new System.Windows.Forms.Padding(4);
            this.txtproductname.Name = "txtproductname";
            this.txtproductname.Size = new System.Drawing.Size(217, 22);
            this.txtproductname.TabIndex = 276;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(454, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 279;
            this.label3.Text = "Sales Price";
            // 
            // txtsalesprice
            // 
            this.txtsalesprice.Enabled = false;
            this.txtsalesprice.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsalesprice.Location = new System.Drawing.Point(459, 40);
            this.txtsalesprice.Margin = new System.Windows.Forms.Padding(4);
            this.txtsalesprice.Name = "txtsalesprice";
            this.txtsalesprice.Size = new System.Drawing.Size(81, 22);
            this.txtsalesprice.TabIndex = 278;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(543, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 19);
            this.label4.TabIndex = 281;
            this.label4.Text = "No Of Labels";
            // 
            // txtnooflabels
            // 
            this.txtnooflabels.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnooflabels.Location = new System.Drawing.Point(543, 40);
            this.txtnooflabels.Margin = new System.Windows.Forms.Padding(4);
            this.txtnooflabels.Name = "txtnooflabels";
            this.txtnooflabels.Size = new System.Drawing.Size(88, 22);
            this.txtnooflabels.TabIndex = 280;
            // 
            // btnselectall
            // 
            this.btnselectall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnselectall.Location = new System.Drawing.Point(4, 580);
            this.btnselectall.Name = "btnselectall";
            this.btnselectall.Size = new System.Drawing.Size(90, 23);
            this.btnselectall.TabIndex = 282;
            this.btnselectall.Text = "Select All";
            this.btnselectall.UseVisualStyleBackColor = true;
            // 
            // btnunselectall
            // 
            this.btnunselectall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnunselectall.Location = new System.Drawing.Point(100, 581);
            this.btnunselectall.Name = "btnunselectall";
            this.btnunselectall.Size = new System.Drawing.Size(90, 23);
            this.btnunselectall.TabIndex = 283;
            this.btnunselectall.Text = "Unselect All";
            this.btnunselectall.UseVisualStyleBackColor = true;
            // 
            // btnrefresh
            // 
            this.btnrefresh.BackColor = System.Drawing.Color.Magenta;
            this.btnrefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnrefresh.BackgroundImage")));
            this.btnrefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnrefresh.Location = new System.Drawing.Point(602, 320);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(63, 50);
            this.btnrefresh.TabIndex = 286;
            this.btnrefresh.UseVisualStyleBackColor = false;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // btnaddselect
            // 
            this.btnaddselect.BackColor = System.Drawing.SystemColors.Control;
            this.btnaddselect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnaddselect.BackgroundImage")));
            this.btnaddselect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnaddselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnaddselect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnaddselect.Location = new System.Drawing.Point(671, 319);
            this.btnaddselect.Name = "btnaddselect";
            this.btnaddselect.Size = new System.Drawing.Size(129, 50);
            this.btnaddselect.TabIndex = 285;
            this.btnaddselect.Text = "Add Select";
            this.btnaddselect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnaddselect.UseVisualStyleBackColor = false;
            this.btnaddselect.Click += new System.EventHandler(this.btnaddselect_Click);
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.SystemColors.Control;
            this.btnclear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.Location = new System.Drawing.Point(533, 319);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(63, 50);
            this.btnclear.TabIndex = 284;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(0, 350);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 19);
            this.label5.TabIndex = 287;
            this.label5.Text = "Date From";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/mm/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(91, 350);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(116, 20);
            this.dateTimePicker1.TabIndex = 288;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/mm/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(296, 350);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(116, 20);
            this.dateTimePicker2.TabIndex = 290;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(229, 350);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 19);
            this.label6.TabIndex = 289;
            this.label6.Text = "Date To";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(0, 285);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 19);
            this.label7.TabIndex = 291;
            this.label7.Text = "Total No Of Labels :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(235, 285);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 19);
            this.label8.TabIndex = 292;
            this.label8.Text = "Full Pages :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(430, 285);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 19);
            this.label9.TabIndex = 293;
            this.label9.Text = "Remaining Labels :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(155, 285);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 19);
            this.label10.TabIndex = 294;
            this.label10.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(335, 285);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 19);
            this.label11.TabIndex = 295;
            this.label11.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(598, 285);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 19);
            this.label12.TabIndex = 296;
            this.label12.Text = "0";
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnsearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnsearch.BackgroundImage")));
            this.btnsearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.Location = new System.Drawing.Point(61, 1);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(47, 35);
            this.btnsearch.TabIndex = 297;
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // frmlabelprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 640);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.btnaddselect);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnunselectall);
            this.Controls.Add(this.btnselectall);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtnooflabels);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtsalesprice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtproductname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtproductcode);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.dgupdatproducts);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btncleattext);
            this.Controls.Add(this.dgProducts);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btnclose);
            this.Name = "frmlabelprint";
            this.Text = "Label Print";
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgupdatproducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.DataGridView dgProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTotal;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btncleattext;
        private System.Windows.Forms.DataGridView dgupdatproducts;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtproductcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtproductname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtsalesprice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtnooflabels;
        private System.Windows.Forms.Button btnselectall;
        private System.Windows.Forms.Button btnunselectall;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.Button btnaddselect;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnsearch;
    }
}