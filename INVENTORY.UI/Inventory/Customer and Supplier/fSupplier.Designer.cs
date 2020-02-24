namespace INVENTORY.UI
{
    partial class fSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSupplier));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numOpeningDue = new System.Windows.Forms.NumericUpDown();
            this.numPrvDue = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEngAddress = new System.Windows.Forms.TextBox();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.txtOwnerName = new System.Windows.Forms.TextBox();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pbxProPic = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.odPicture = new System.Windows.Forms.OpenFileDialog();
            this.odAttachment = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numOpeningDue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrvDue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProPic)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(899, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(31, 38);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(63, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 21);
            this.label11.TabIndex = 86;
            this.label11.Text = "Launch Due";
            // 
            // numOpeningDue
            // 
            this.numOpeningDue.BackColor = System.Drawing.Color.Honeydew;
            this.numOpeningDue.DecimalPlaces = 2;
            this.numOpeningDue.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOpeningDue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.numOpeningDue.Location = new System.Drawing.Point(173, 232);
            this.numOpeningDue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numOpeningDue.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numOpeningDue.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.numOpeningDue.Name = "numOpeningDue";
            this.numOpeningDue.Size = new System.Drawing.Size(172, 22);
            this.numOpeningDue.TabIndex = 5;
            this.numOpeningDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numOpeningDue.ValueChanged += new System.EventHandler(this.numOpeningDue_ValueChanged);
            this.numOpeningDue.Enter += new System.EventHandler(this.numOpeningDue_Enter);
            // 
            // numPrvDue
            // 
            this.numPrvDue.BackColor = System.Drawing.Color.Honeydew;
            this.numPrvDue.DecimalPlaces = 2;
            this.numPrvDue.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPrvDue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.numPrvDue.Location = new System.Drawing.Point(174, 265);
            this.numPrvDue.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numPrvDue.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.numPrvDue.Name = "numPrvDue";
            this.numPrvDue.Size = new System.Drawing.Size(171, 22);
            this.numPrvDue.TabIndex = 6;
            this.numPrvDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPrvDue.Enter += new System.EventHandler(this.numPrvDue_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(54, 257);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 22);
            this.label13.TabIndex = 31;
            this.label13.Text = "Due Amount";
            // 
            // txtEngAddress
            // 
            this.txtEngAddress.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEngAddress.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtEngAddress.Location = new System.Drawing.Point(174, 195);
            this.txtEngAddress.Multiline = true;
            this.txtEngAddress.Name = "txtEngAddress";
            this.txtEngAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEngAddress.Size = new System.Drawing.Size(247, 26);
            this.txtEngAddress.TabIndex = 4;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtContactNo.Location = new System.Drawing.Point(174, 162);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(171, 22);
            this.txtContactNo.TabIndex = 3;
            // 
            // txtOwnerName
            // 
            this.txtOwnerName.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOwnerName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtOwnerName.Location = new System.Drawing.Point(174, 96);
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.Size = new System.Drawing.Size(171, 22);
            this.txtOwnerName.TabIndex = 1;
            // 
            // txtSuppName
            // 
            this.txtSuppName.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuppName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSuppName.Location = new System.Drawing.Point(174, 129);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.Size = new System.Drawing.Size(171, 22);
            this.txtSuppName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(40, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 22);
            this.label6.TabIndex = 11;
            this.label6.Text = "Moile Number";
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.LightCyan;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowse.Location = new System.Drawing.Point(339, 408);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(96, 35);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pbxProPic
            // 
            this.pbxProPic.Image = ((System.Drawing.Image)(resources.GetObject("pbxProPic.Image")));
            this.pbxProPic.Location = new System.Drawing.Point(174, 309);
            this.pbxProPic.Name = "pbxProPic";
            this.pbxProPic.Size = new System.Drawing.Size(159, 134);
            this.pbxProPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxProPic.TabIndex = 9;
            this.pbxProPic.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(85, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "Address ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(106, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(37, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Provider Name";
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierCode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSupplierCode.Location = new System.Drawing.Point(174, 63);
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(171, 22);
            this.txtSupplierCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(53, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier A/C";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(904, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(26, 33);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightCyan;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(274, 501);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 30);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightCyan;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(172, 502);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Tag = "btnSave";
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // odPicture
            // 
            this.odPicture.FileName = "openFileDialog1";
            // 
            // odAttachment
            // 
            this.odAttachment.FileName = "openFileDialog1";
            // 
            // fSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1045, 572);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pbxProPic);
            this.Controls.Add(this.numOpeningDue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numPrvDue);
            this.Controls.Add(this.txtSupplierCode);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEngAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOwnerName);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtSuppName);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(660, 120);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fSupplier";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Supplier";
            this.Load += new System.EventHandler(this.fSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numOpeningDue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrvDue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button btnBrowse;
        public System.Windows.Forms.PictureBox pbxProPic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog odPicture;
        private System.Windows.Forms.TextBox txtEngAddress;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.TextBox txtOwnerName;
        private System.Windows.Forms.TextBox txtSuppName;
        private System.Windows.Forms.OpenFileDialog odAttachment;
        private System.Windows.Forms.NumericUpDown numPrvDue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numOpeningDue;
    }
}