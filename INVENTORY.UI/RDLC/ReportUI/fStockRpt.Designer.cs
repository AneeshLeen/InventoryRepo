namespace ESRP.UI
{
    partial class fStockRpt
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
            this.numLess = new System.Windows.Forms.NumericUpDown();
            this.numGreater = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctlColor = new ESRP.UI.ctlCustomControl();
            this.rbColorCode = new System.Windows.Forms.RadioButton();
            this.ctlPreOrProduct = new ESRP.UI.ctlCustomControl();
            this.ctlCategory = new ESRP.UI.ctlCustomControl();
            this.ctlBrand = new ESRP.UI.ctlCustomControl();
            this.rbCompany = new System.Windows.Forms.RadioButton();
            this.rbModel = new System.Windows.Forms.RadioButton();
            this.rbCategory = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGreater)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numLess);
            this.groupBox2.Controls.Add(this.numGreater);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnPreview);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(8, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 59);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // numLess
            // 
            this.numLess.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLess.Location = new System.Drawing.Point(64, 17);
            this.numLess.Name = "numLess";
            this.numLess.Size = new System.Drawing.Size(64, 27);
            this.numLess.TabIndex = 19;
            this.numLess.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLess.Visible = false;
            // 
            // numGreater
            // 
            this.numGreater.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGreater.Location = new System.Drawing.Point(257, 21);
            this.numGreater.Name = "numGreater";
            this.numGreater.Size = new System.Drawing.Size(65, 27);
            this.numGreater.TabIndex = 20;
            this.numGreater.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGreater.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 22);
            this.label1.TabIndex = 17;
            this.label1.Text = "Less Than";
            this.label1.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(456, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 33);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(359, 17);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(95, 33);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "&Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(199, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 22);
            this.label2.TabIndex = 18;
            this.label2.Text = "Greater Than";
            this.label2.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctlColor);
            this.groupBox1.Controls.Add(this.rbColorCode);
            this.groupBox1.Controls.Add(this.ctlPreOrProduct);
            this.groupBox1.Controls.Add(this.ctlCategory);
            this.groupBox1.Controls.Add(this.ctlBrand);
            this.groupBox1.Controls.Add(this.rbCompany);
            this.groupBox1.Controls.Add(this.rbModel);
            this.groupBox1.Controls.Add(this.rbCategory);
            this.groupBox1.Location = new System.Drawing.Point(7, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 186);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ctlColor
            // 
            this.ctlColor.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlColor.Location = new System.Drawing.Point(117, 137);
            this.ctlColor.Margin = new System.Windows.Forms.Padding(4);
            this.ctlColor.Name = "ctlColor";
            this.ctlColor.ObjectName = "Color";
            this.ctlColor.Size = new System.Drawing.Size(398, 37);
            this.ctlColor.TabIndex = 3;
            this.ctlColor.SelectedItemChanged += new ESRP.UI.SelectionChangedEvent(this.ctlColor_SelectedItemChanged);
            // 
            // rbColorCode
            // 
            this.rbColorCode.AutoSize = true;
            this.rbColorCode.Location = new System.Drawing.Point(14, 144);
            this.rbColorCode.Name = "rbColorCode";
            this.rbColorCode.Size = new System.Drawing.Size(98, 23);
            this.rbColorCode.TabIndex = 19;
            this.rbColorCode.TabStop = true;
            this.rbColorCode.Text = "Color Code";
            this.rbColorCode.UseVisualStyleBackColor = true;
            // 
            // ctlPreOrProduct
            // 
            this.ctlPreOrProduct.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPreOrProduct.Location = new System.Drawing.Point(117, 96);
            this.ctlPreOrProduct.Margin = new System.Windows.Forms.Padding(4);
            this.ctlPreOrProduct.Name = "ctlPreOrProduct";
            this.ctlPreOrProduct.ObjectName = "OProduct";
            this.ctlPreOrProduct.Size = new System.Drawing.Size(398, 34);
            this.ctlPreOrProduct.TabIndex = 2;
            this.ctlPreOrProduct.SelectedItemChanged += new ESRP.UI.SelectionChangedEvent(this.ctlPreOrProduct_SelectedItemChanged);
            // 
            // ctlCategory
            // 
            this.ctlCategory.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlCategory.Location = new System.Drawing.Point(117, 55);
            this.ctlCategory.Margin = new System.Windows.Forms.Padding(4);
            this.ctlCategory.Name = "ctlCategory";
            this.ctlCategory.ObjectName = "Category";
            this.ctlCategory.Size = new System.Drawing.Size(398, 36);
            this.ctlCategory.TabIndex = 1;
            this.ctlCategory.SelectedItemChanged += new ESRP.UI.SelectionChangedEvent(this.ctlCategory_SelectedItemChanged);
            // 
            // ctlBrand
            // 
            this.ctlBrand.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlBrand.Location = new System.Drawing.Point(117, 16);
            this.ctlBrand.Margin = new System.Windows.Forms.Padding(4);
            this.ctlBrand.Name = "ctlBrand";
            this.ctlBrand.ObjectName = "BCompany";
            this.ctlBrand.Size = new System.Drawing.Size(398, 36);
            this.ctlBrand.TabIndex = 0;
            this.ctlBrand.SelectedItemChanged += new ESRP.UI.SelectionChangedEvent(this.ctlBrand_SelectedItemChanged);
            // 
            // rbCompany
            // 
            this.rbCompany.AutoSize = true;
            this.rbCompany.Location = new System.Drawing.Point(16, 25);
            this.rbCompany.Name = "rbCompany";
            this.rbCompany.Size = new System.Drawing.Size(90, 23);
            this.rbCompany.TabIndex = 13;
            this.rbCompany.TabStop = true;
            this.rbCompany.Text = "Company";
            this.rbCompany.UseVisualStyleBackColor = true;
            this.rbCompany.CheckedChanged += new System.EventHandler(this.rbCompany_CheckedChanged);
            // 
            // rbModel
            // 
            this.rbModel.AutoSize = true;
            this.rbModel.Location = new System.Drawing.Point(17, 102);
            this.rbModel.Name = "rbModel";
            this.rbModel.Size = new System.Drawing.Size(77, 23);
            this.rbModel.TabIndex = 12;
            this.rbModel.TabStop = true;
            this.rbModel.Text = "Product";
            this.rbModel.UseVisualStyleBackColor = true;
            this.rbModel.CheckedChanged += new System.EventHandler(this.rbModel_CheckedChanged);
            // 
            // rbCategory
            // 
            this.rbCategory.AutoSize = true;
            this.rbCategory.Location = new System.Drawing.Point(16, 64);
            this.rbCategory.Name = "rbCategory";
            this.rbCategory.Size = new System.Drawing.Size(86, 23);
            this.rbCategory.TabIndex = 11;
            this.rbCategory.TabStop = true;
            this.rbCategory.Text = "Category";
            this.rbCategory.UseVisualStyleBackColor = true;
            this.rbCategory.CheckedChanged += new System.EventHandler(this.rbCategory_CheckedChanged);
            // 
            // fStockRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(576, 254);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fStockRpt";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Available Stock Info";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGreater)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbModel;
        private System.Windows.Forms.RadioButton rbCategory;
        private System.Windows.Forms.RadioButton rbCompany;
        private System.Windows.Forms.NumericUpDown numGreater;
        private System.Windows.Forms.NumericUpDown numLess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ctlCustomControl ctlBrand;
        private ctlCustomControl ctlCategory;
        private ctlCustomControl ctlPreOrProduct;
        private ctlCustomControl ctlColor;
        private System.Windows.Forms.RadioButton rbColorCode;
    }
}