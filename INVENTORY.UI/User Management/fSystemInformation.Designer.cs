namespace INVENTORY.UI
{
    partial class fSystemInformation
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
            this.dlgOpenFolderCPP = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpSysStartDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnProPhotoClear = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnProductPhoto = new System.Windows.Forms.Button();
            this.txtProPhotoPath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEmpPPClear = new System.Windows.Forms.Button();
            this.txtEmpPhoto = new System.Windows.Forms.TextBox();
            this.btnEmpPhotoPath = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSuppClear = new System.Windows.Forms.Button();
            this.txtSuppPhotoPath = new System.Windows.Forms.TextBox();
            this.btnSuppPhoto = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPhotoClearCus = new System.Windows.Forms.Button();
            this.txtPhotoPathCus = new System.Windows.Forms.TextBox();
            this.btnPhotoPathCus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbCompAdd = new System.Windows.Forms.RichTextBox();
            this.txtWebAdd = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dlgOpenFolderCNP = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgOpenFolderSPP = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgOpenFolderSDP = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgOpenFolderProduct = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgOpenFolderEmp = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpSysStartDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(6, 320);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(620, 49);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System Information";
            // 
            // dtpSysStartDate
            // 
            this.dtpSysStartDate.CustomFormat = "MMM yyyy";
            this.dtpSysStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSysStartDate.Location = new System.Drawing.Point(173, 15);
            this.dtpSysStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpSysStartDate.Name = "dtpSysStartDate";
            this.dtpSysStartDate.Size = new System.Drawing.Size(176, 25);
            this.dtpSysStartDate.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 21);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "System Start Date";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(6, 384);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 43);
            this.panel1.TabIndex = 15;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(415, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(514, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnProPhotoClear
            // 
            this.btnProPhotoClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProPhotoClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProPhotoClear.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold);
            this.btnProPhotoClear.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnProPhotoClear.Location = new System.Drawing.Point(546, 289);
            this.btnProPhotoClear.Name = "btnProPhotoClear";
            this.btnProPhotoClear.Size = new System.Drawing.Size(59, 27);
            this.btnProPhotoClear.TabIndex = 29;
            this.btnProPhotoClear.Text = "Clear";
            this.btnProPhotoClear.Click += new System.EventHandler(this.btnProPhotoClear_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 290);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 19);
            this.label11.TabIndex = 26;
            this.label11.Text = "Product Photo Path";
            // 
            // btnProductPhoto
            // 
            this.btnProductPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProductPhoto.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.btnProductPhoto.Location = new System.Drawing.Point(500, 290);
            this.btnProductPhoto.Name = "btnProductPhoto";
            this.btnProductPhoto.Size = new System.Drawing.Size(45, 26);
            this.btnProductPhoto.TabIndex = 28;
            this.btnProductPhoto.Text = "....";
            this.btnProductPhoto.Click += new System.EventHandler(this.btnProductPhoto_Click);
            // 
            // txtProPhotoPath
            // 
            this.txtProPhotoPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtProPhotoPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProPhotoPath.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold);
            this.txtProPhotoPath.Location = new System.Drawing.Point(171, 289);
            this.txtProPhotoPath.Name = "txtProPhotoPath";
            this.txtProPhotoPath.ReadOnly = true;
            this.txtProPhotoPath.Size = new System.Drawing.Size(327, 27);
            this.txtProPhotoPath.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEmpPPClear);
            this.groupBox1.Controls.Add(this.txtEmpPhoto);
            this.groupBox1.Controls.Add(this.btnProPhotoClear);
            this.groupBox1.Controls.Add(this.btnEmpPhotoPath);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnProductPhoto);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtProPhotoPath);
            this.groupBox1.Controls.Add(this.btnSuppClear);
            this.groupBox1.Controls.Add(this.txtSuppPhotoPath);
            this.groupBox1.Controls.Add(this.btnSuppPhoto);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnPhotoClearCus);
            this.groupBox1.Controls.Add(this.txtPhotoPathCus);
            this.groupBox1.Controls.Add(this.btnPhotoPathCus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rtbCompAdd);
            this.groupBox1.Controls.Add(this.txtWebAdd);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtTelephone);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, -2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(620, 323);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Company Information";
            // 
            // btnEmpPPClear
            // 
            this.btnEmpPPClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmpPPClear.Enabled = false;
            this.btnEmpPPClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmpPPClear.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold);
            this.btnEmpPPClear.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnEmpPPClear.Location = new System.Drawing.Point(545, 260);
            this.btnEmpPPClear.Name = "btnEmpPPClear";
            this.btnEmpPPClear.Size = new System.Drawing.Size(59, 27);
            this.btnEmpPPClear.TabIndex = 33;
            this.btnEmpPPClear.Text = "Clear";
            this.btnEmpPPClear.Click += new System.EventHandler(this.btnEmpPPClear_Click);
            // 
            // txtEmpPhoto
            // 
            this.txtEmpPhoto.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmpPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpPhoto.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold);
            this.txtEmpPhoto.Location = new System.Drawing.Point(171, 260);
            this.txtEmpPhoto.Name = "txtEmpPhoto";
            this.txtEmpPhoto.ReadOnly = true;
            this.txtEmpPhoto.Size = new System.Drawing.Size(327, 27);
            this.txtEmpPhoto.TabIndex = 7;
            // 
            // btnEmpPhotoPath
            // 
            this.btnEmpPhotoPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmpPhotoPath.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.btnEmpPhotoPath.Location = new System.Drawing.Point(500, 261);
            this.btnEmpPhotoPath.Name = "btnEmpPhotoPath";
            this.btnEmpPhotoPath.Size = new System.Drawing.Size(51, 26);
            this.btnEmpPhotoPath.TabIndex = 32;
            this.btnEmpPhotoPath.Text = "....";
            this.btnEmpPhotoPath.Click += new System.EventHandler(this.btnEmpPhotoPath_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 263);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(148, 19);
            this.label12.TabIndex = 30;
            this.label12.Text = "Employee Photo Path";
            // 
            // btnSuppClear
            // 
            this.btnSuppClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuppClear.Enabled = false;
            this.btnSuppClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSuppClear.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold);
            this.btnSuppClear.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSuppClear.Location = new System.Drawing.Point(546, 230);
            this.btnSuppClear.Name = "btnSuppClear";
            this.btnSuppClear.Size = new System.Drawing.Size(59, 27);
            this.btnSuppClear.TabIndex = 21;
            this.btnSuppClear.Text = "Clear";
            this.btnSuppClear.Click += new System.EventHandler(this.btnSuppClear_Click);
            // 
            // txtSuppPhotoPath
            // 
            this.txtSuppPhotoPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtSuppPhotoPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSuppPhotoPath.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold);
            this.txtSuppPhotoPath.Location = new System.Drawing.Point(172, 230);
            this.txtSuppPhotoPath.Name = "txtSuppPhotoPath";
            this.txtSuppPhotoPath.ReadOnly = true;
            this.txtSuppPhotoPath.Size = new System.Drawing.Size(327, 27);
            this.txtSuppPhotoPath.TabIndex = 6;
            // 
            // btnSuppPhoto
            // 
            this.btnSuppPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSuppPhoto.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.btnSuppPhoto.Location = new System.Drawing.Point(501, 231);
            this.btnSuppPhoto.Name = "btnSuppPhoto";
            this.btnSuppPhoto.Size = new System.Drawing.Size(51, 26);
            this.btnSuppPhoto.TabIndex = 20;
            this.btnSuppPhoto.Text = "....";
            this.btnSuppPhoto.Click += new System.EventHandler(this.btnSuppPhoto_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 233);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "Photo Path (Supplier)";
            // 
            // btnPhotoClearCus
            // 
            this.btnPhotoClearCus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPhotoClearCus.Enabled = false;
            this.btnPhotoClearCus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPhotoClearCus.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold);
            this.btnPhotoClearCus.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnPhotoClearCus.Location = new System.Drawing.Point(547, 201);
            this.btnPhotoClearCus.Name = "btnPhotoClearCus";
            this.btnPhotoClearCus.Size = new System.Drawing.Size(59, 27);
            this.btnPhotoClearCus.TabIndex = 13;
            this.btnPhotoClearCus.Text = "Clear";
            this.btnPhotoClearCus.Click += new System.EventHandler(this.btnPhotoClearCus_Click);
            // 
            // txtPhotoPathCus
            // 
            this.txtPhotoPathCus.BackColor = System.Drawing.SystemColors.Window;
            this.txtPhotoPathCus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhotoPathCus.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold);
            this.txtPhotoPathCus.Location = new System.Drawing.Point(173, 201);
            this.txtPhotoPathCus.Name = "txtPhotoPathCus";
            this.txtPhotoPathCus.ReadOnly = true;
            this.txtPhotoPathCus.Size = new System.Drawing.Size(327, 27);
            this.txtPhotoPathCus.TabIndex = 5;
            // 
            // btnPhotoPathCus
            // 
            this.btnPhotoPathCus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPhotoPathCus.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.btnPhotoPathCus.Location = new System.Drawing.Point(502, 202);
            this.btnPhotoPathCus.Name = "btnPhotoPathCus";
            this.btnPhotoPathCus.Size = new System.Drawing.Size(51, 26);
            this.btnPhotoPathCus.TabIndex = 12;
            this.btnPhotoPathCus.Text = "....";
            this.btnPhotoPathCus.Click += new System.EventHandler(this.btnPhotoPathCus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 204);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Photo Path (Customer)";
            // 
            // rtbCompAdd
            // 
            this.rtbCompAdd.Location = new System.Drawing.Point(173, 51);
            this.rtbCompAdd.Margin = new System.Windows.Forms.Padding(4);
            this.rtbCompAdd.Name = "rtbCompAdd";
            this.rtbCompAdd.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbCompAdd.Size = new System.Drawing.Size(442, 61);
            this.rtbCompAdd.TabIndex = 1;
            this.rtbCompAdd.Text = "";
            // 
            // txtWebAdd
            // 
            this.txtWebAdd.Location = new System.Drawing.Point(173, 173);
            this.txtWebAdd.Margin = new System.Windows.Forms.Padding(4);
            this.txtWebAdd.Name = "txtWebAdd";
            this.txtWebAdd.Size = new System.Drawing.Size(442, 25);
            this.txtWebAdd.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(173, 145);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(442, 25);
            this.txtEmail.TabIndex = 3;
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(173, 118);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(442, 25);
            this.txtTelephone.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(173, 21);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(442, 25);
            this.txtName.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 176);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Web Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 149);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "E-mail Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Telephone No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Company Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Company Name";
            // 
            // fSystemInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(634, 431);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fSystemInformation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Information";
            this.Load += new System.EventHandler(this.fSystemInformation_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog dlgOpenFolderCPP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpSysStartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSuppClear;
        private System.Windows.Forms.TextBox txtSuppPhotoPath;
        private System.Windows.Forms.Button btnSuppPhoto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPhotoClearCus;
        private System.Windows.Forms.TextBox txtPhotoPathCus;
        private System.Windows.Forms.Button btnPhotoPathCus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbCompAdd;
        private System.Windows.Forms.TextBox txtWebAdd;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog dlgOpenFolderCNP;
        private System.Windows.Forms.FolderBrowserDialog dlgOpenFolderSPP;
        private System.Windows.Forms.FolderBrowserDialog dlgOpenFolderSDP;
        private System.Windows.Forms.FolderBrowserDialog dlgOpenFolderProduct;
        private System.Windows.Forms.Button btnEmpPPClear;
        private System.Windows.Forms.TextBox txtEmpPhoto;
        private System.Windows.Forms.Button btnEmpPhotoPath;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.FolderBrowserDialog dlgOpenFolderEmp;
        private System.Windows.Forms.Button btnProPhotoClear;
        private System.Windows.Forms.TextBox txtProPhotoPath;
        private System.Windows.Forms.Button btnProductPhoto;
        private System.Windows.Forms.Label label11;
    }
}