namespace INVENTORY.UI
{
    partial class fCollectionRpt
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ctlSupplier = new INVENTORY.UI.ctlCustomControl();
            this.label3 = new System.Windows.Forms.Label();
            this.ctlCustomer = new INVENTORY.UI.ctlCustomControl();
            this.rbCashDelivery = new System.Windows.Forms.RadioButton();
            this.rbCashCollection = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnPreview);
            this.groupBox2.Location = new System.Drawing.Point(6, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(606, 56);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(499, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 32);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(404, 17);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(95, 32);
            this.btnPreview.TabIndex = 7;
            this.btnPreview.Text = "&Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ctlSupplier);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ctlCustomer);
            this.groupBox1.Controls.Add(this.rbCashDelivery);
            this.groupBox1.Controls.Add(this.rbCashCollection);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 192);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 22);
            this.label4.TabIndex = 16;
            this.label4.Text = "Supplier";
            // 
            // ctlSupplier
            // 
            this.ctlSupplier.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlSupplier.Location = new System.Drawing.Point(104, 101);
            this.ctlSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.ctlSupplier.Name = "ctlSupplier";
            this.ctlSupplier.ObjectName = "CCompany";
            this.ctlSupplier.Size = new System.Drawing.Size(411, 36);
            this.ctlSupplier.TabIndex = 14;
            this.ctlSupplier.SelectedItemChanged += new INVENTORY.UI.SelectionChangedEvent(this.ctlSupplier_SelectedItemChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 22);
            this.label3.TabIndex = 15;
            this.label3.Text = "Customer";
            // 
            // ctlCustomer
            // 
            this.ctlCustomer.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCustomer.Location = new System.Drawing.Point(104, 57);
            this.ctlCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.ctlCustomer.Name = "ctlCustomer";
            this.ctlCustomer.ObjectName = "Customer";
            this.ctlCustomer.Size = new System.Drawing.Size(411, 36);
            this.ctlCustomer.TabIndex = 13;
            this.ctlCustomer.SelectedItemChanged += new INVENTORY.UI.SelectionChangedEvent(this.ctlCustomer_SelectedItemChanged);
            // 
            // rbCashDelivery
            // 
            this.rbCashDelivery.AutoSize = true;
            this.rbCashDelivery.Location = new System.Drawing.Point(343, 27);
            this.rbCashDelivery.Name = "rbCashDelivery";
            this.rbCashDelivery.Size = new System.Drawing.Size(133, 26);
            this.rbCashDelivery.TabIndex = 10;
            this.rbCashDelivery.TabStop = true;
            this.rbCashDelivery.Text = "Cash Delivery";
            this.rbCashDelivery.UseVisualStyleBackColor = true;
            this.rbCashDelivery.CheckedChanged += new System.EventHandler(this.rbCashDelivery_CheckedChanged);
            // 
            // rbCashCollection
            // 
            this.rbCashCollection.AutoSize = true;
            this.rbCashCollection.Location = new System.Drawing.Point(110, 27);
            this.rbCashCollection.Name = "rbCashCollection";
            this.rbCashCollection.Size = new System.Drawing.Size(145, 26);
            this.rbCashCollection.TabIndex = 9;
            this.rbCashCollection.TabStop = true;
            this.rbCashCollection.Text = "Cash Collection";
            this.rbCashCollection.UseVisualStyleBackColor = true;
            this.rbCashCollection.CheckedChanged += new System.EventHandler(this.rbCashCollection_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(287, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "To";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd MMM, yyyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(347, 144);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(164, 29);
            this.dtpToDate.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "From";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd MMM, yyyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(104, 145);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(164, 29);
            this.dtpFromDate.TabIndex = 3;
            // 
            // fCollectionRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(619, 250);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "fCollectionRpt";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Due Collection ";
            this.Load += new System.EventHandler(this.fCollectionRpt_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.RadioButton rbCashDelivery;
        private System.Windows.Forms.RadioButton rbCashCollection;
        private System.Windows.Forms.Label label4;
        private ctlCustomControl ctlSupplier;
        private System.Windows.Forms.Label label3;
        private ctlCustomControl ctlCustomer;
    }
}