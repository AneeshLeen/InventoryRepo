namespace INVENTORY.UI
{
    partial class fCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCategory));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkInactive = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.chkIsVat = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbVat = new System.Windows.Forms.ComboBox();
            this.chkSeperateSale = new System.Windows.Forms.CheckBox();
            this.chkPayout = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAge = new System.Windows.Forms.ComboBox();
            this.cmbbackcolor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbforecolor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btncolorprev = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(0, 26);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(48, 10);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(625, 211);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(42, 42);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(199, 172);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(270, 29);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(199, 135);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(270, 29);
            this.txtCode.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(76, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Category";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(144, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(326, 378);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 38);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(199, 378);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 38);
            this.btnSave.TabIndex = 6;
            this.btnSave.Tag = "btnSave";
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkInactive
            // 
            this.chkInactive.AutoSize = true;
            this.chkInactive.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInactive.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkInactive.Location = new System.Drawing.Point(444, 225);
            this.chkInactive.Name = "chkInactive";
            this.chkInactive.Size = new System.Drawing.Size(88, 26);
            this.chkInactive.TabIndex = 8;
            this.chkInactive.Text = "Inactive";
            this.chkInactive.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(-15, -15);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(95, 23);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // chkIsVat
            // 
            this.chkIsVat.AutoSize = true;
            this.chkIsVat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkIsVat.Location = new System.Drawing.Point(444, 254);
            this.chkIsVat.Name = "chkIsVat";
            this.chkIsVat.Size = new System.Drawing.Size(181, 23);
            this.chkIsVat.TabIndex = 10;
            this.chkIsVat.Text = "Department Sales (Vat)";
            this.chkIsVat.UseVisualStyleBackColor = true;
            this.chkIsVat.CheckedChanged += new System.EventHandler(this.chkIsVat_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(440, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Vat";
            // 
            // cmbVat
            // 
            this.cmbVat.FormattingEnabled = true;
            this.cmbVat.Location = new System.Drawing.Point(493, 279);
            this.cmbVat.Name = "cmbVat";
            this.cmbVat.Size = new System.Drawing.Size(121, 26);
            this.cmbVat.TabIndex = 12;
            // 
            // chkSeperateSale
            // 
            this.chkSeperateSale.AutoSize = true;
            this.chkSeperateSale.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkSeperateSale.Location = new System.Drawing.Point(444, 356);
            this.chkSeperateSale.Name = "chkSeperateSale";
            this.chkSeperateSale.Size = new System.Drawing.Size(182, 23);
            this.chkSeperateSale.TabIndex = 14;
            this.chkSeperateSale.Text = "Seperate from shop sale";
            this.chkSeperateSale.UseVisualStyleBackColor = true;
            // 
            // chkPayout
            // 
            this.chkPayout.AutoSize = true;
            this.chkPayout.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkPayout.Location = new System.Drawing.Point(444, 327);
            this.chkPayout.Name = "chkPayout";
            this.chkPayout.Size = new System.Drawing.Size(83, 23);
            this.chkPayout.TabIndex = 13;
            this.chkPayout.Text = "Pay Out";
            this.chkPayout.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(76, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 22);
            this.label4.TabIndex = 16;
            this.label4.Text = "Age Restriction";
            // 
            // cmbAge
            // 
            this.cmbAge.FormattingEnabled = true;
            this.cmbAge.Location = new System.Drawing.Point(199, 208);
            this.cmbAge.Name = "cmbAge";
            this.cmbAge.Size = new System.Drawing.Size(121, 26);
            this.cmbAge.TabIndex = 17;
            // 
            // cmbbackcolor
            // 
            this.cmbbackcolor.FormattingEnabled = true;
            this.cmbbackcolor.Location = new System.Drawing.Point(199, 240);
            this.cmbbackcolor.Name = "cmbbackcolor";
            this.cmbbackcolor.Size = new System.Drawing.Size(121, 26);
            this.cmbbackcolor.TabIndex = 19;
            this.cmbbackcolor.SelectedIndexChanged += new System.EventHandler(this.cmbbackcolor_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(76, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 22);
            this.label5.TabIndex = 18;
            this.label5.Text = "Back Color";
            // 
            // cmbforecolor
            // 
            this.cmbforecolor.FormattingEnabled = true;
            this.cmbforecolor.Location = new System.Drawing.Point(199, 272);
            this.cmbforecolor.Name = "cmbforecolor";
            this.cmbforecolor.Size = new System.Drawing.Size(121, 26);
            this.cmbforecolor.TabIndex = 21;
            this.cmbforecolor.SelectedIndexChanged += new System.EventHandler(this.cmbforecolor_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(76, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 22);
            this.label6.TabIndex = 20;
            this.label6.Text = "Fore Color";
            // 
            // btncolorprev
            // 
            this.btncolorprev.Location = new System.Drawing.Point(326, 240);
            this.btncolorprev.Name = "btncolorprev";
            this.btncolorprev.Size = new System.Drawing.Size(96, 59);
            this.btncolorprev.TabIndex = 22;
            this.btncolorprev.UseVisualStyleBackColor = true;
            // 
            // fCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(987, 579);
            this.Controls.Add(this.btncolorprev);
            this.Controls.Add(this.cmbforecolor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbbackcolor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbAge);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkSeperateSale);
            this.Controls.Add(this.chkPayout);
            this.Controls.Add(this.cmbVat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkIsVat);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.chkInactive);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(650, 120);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fCategory";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Category";
            this.Load += new System.EventHandler(this.fCategory_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkInactive;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox chkIsVat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbVat;
        private System.Windows.Forms.CheckBox chkSeperateSale;
        private System.Windows.Forms.CheckBox chkPayout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAge;
        private System.Windows.Forms.ComboBox cmbbackcolor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbforecolor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btncolorprev;
    }
}