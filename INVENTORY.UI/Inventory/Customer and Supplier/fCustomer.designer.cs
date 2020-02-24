namespace INVENTORY.UI
{
    partial class fCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCustomer));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtNID = new System.Windows.Forms.GroupBox();
            this.cboCusType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numOpeningDue = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numPrevDue = new System.Windows.Forms.NumericUpDown();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pbxProPic = new System.Windows.Forms.PictureBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNIDNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.odPicture = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRefAddress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRefFather = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRefContact = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRefName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpeningDue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrevDue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProPic)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.SlateGray;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(720, 443);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(159, 57);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightCyan;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(277, 477);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 34);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightCyan;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(160, 477);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 34);
            this.btnSave.TabIndex = 0;
            this.btnSave.Tag = "btnSave";
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNID
            // 
            this.txtNID.BackColor = System.Drawing.Color.SlateGray;
            this.txtNID.Controls.Add(this.txtCompany);
            this.txtNID.Controls.Add(this.txtEmail);
            this.txtNID.Controls.Add(this.label13);
            this.txtNID.Controls.Add(this.label2);
            this.txtNID.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNID.Location = new System.Drawing.Point(767, 398);
            this.txtNID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNID.Name = "txtNID";
            this.txtNID.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNID.Size = new System.Drawing.Size(112, 37);
            this.txtNID.TabIndex = 0;
            this.txtNID.TabStop = false;
            this.txtNID.Text = "Customer Information";
            this.txtNID.Visible = false;
            this.txtNID.Enter += new System.EventHandler(this.txtNID_Enter);
            // 
            // cboCusType
            // 
            this.cboCusType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCusType.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCusType.FormattingEnabled = true;
            this.cboCusType.Location = new System.Drawing.Point(164, 188);
            this.cboCusType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCusType.Name = "cboCusType";
            this.cboCusType.Size = new System.Drawing.Size(147, 24);
            this.cboCusType.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label14.Location = new System.Drawing.Point(42, 187);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 19);
            this.label14.TabIndex = 86;
            this.label14.Text = "Customer Type";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label11.Location = new System.Drawing.Point(54, 218);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 21);
            this.label11.TabIndex = 84;
            this.label11.Text = "Launch Due";
            // 
            // numOpeningDue
            // 
            this.numOpeningDue.BackColor = System.Drawing.Color.Honeydew;
            this.numOpeningDue.DecimalPlaces = 2;
            this.numOpeningDue.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOpeningDue.ForeColor = System.Drawing.Color.Black;
            this.numOpeningDue.Location = new System.Drawing.Point(164, 218);
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
            this.numOpeningDue.Size = new System.Drawing.Size(147, 22);
            this.numOpeningDue.TabIndex = 7;
            this.numOpeningDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numOpeningDue.ValueChanged += new System.EventHandler(this.numOpeningDue_ValueChanged);
            this.numOpeningDue.Enter += new System.EventHandler(this.numOpeningDue_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label10.Location = new System.Drawing.Point(28, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 21);
            this.label10.TabIndex = 32;
            this.label10.Text = "Customer Name";
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany.Location = new System.Drawing.Point(553, 263);
            this.txtCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(97, 27);
            this.txtCompany.TabIndex = 2;
            this.txtCompany.Visible = false;
            // 
            // txtFName
            // 
            this.txtFName.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFName.Location = new System.Drawing.Point(164, 161);
            this.txtFName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(201, 22);
            this.txtFName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(50, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 21);
            this.label3.TabIndex = 30;
            this.label3.Text = "Father Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label7.Location = new System.Drawing.Point(42, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 21);
            this.label7.TabIndex = 29;
            this.label7.Text = " Due Amount";
            // 
            // numPrevDue
            // 
            this.numPrevDue.BackColor = System.Drawing.Color.Honeydew;
            this.numPrevDue.DecimalPlaces = 2;
            this.numPrevDue.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPrevDue.ForeColor = System.Drawing.Color.Black;
            this.numPrevDue.Location = new System.Drawing.Point(164, 366);
            this.numPrevDue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numPrevDue.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numPrevDue.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.numPrevDue.Name = "numPrevDue";
            this.numPrevDue.ReadOnly = true;
            this.numPrevDue.Size = new System.Drawing.Size(147, 22);
            this.numPrevDue.TabIndex = 8;
            this.numPrevDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPrevDue.Enter += new System.EventHandler(this.numPrevDue_Enter);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.LightCyan;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowse.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(404, 390);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(150, 29);
            this.btnBrowse.TabIndex = 19;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pbxProPic
            // 
            this.pbxProPic.Image = ((System.Drawing.Image)(resources.GetObject("pbxProPic.Image")));
            this.pbxProPic.Location = new System.Drawing.Point(407, 252);
            this.pbxProPic.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbxProPic.Name = "pbxProPic";
            this.pbxProPic.Size = new System.Drawing.Size(150, 132);
            this.pbxProPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxProPic.TabIndex = 27;
            this.pbxProPic.TabStop = false;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(164, 127);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAddress.Size = new System.Drawing.Size(148, 26);
            this.txtAddress.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label5.Location = new System.Drawing.Point(83, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Address";
            // 
            // txtNIDNo
            // 
            this.txtNIDNo.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNIDNo.Location = new System.Drawing.Point(164, 396);
            this.txtNIDNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNIDNo.Name = "txtNIDNo";
            this.txtNIDNo.Size = new System.Drawing.Size(201, 22);
            this.txtNIDNo.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label15.Location = new System.Drawing.Point(60, 393);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 21);
            this.label15.TabIndex = 5;
            this.label15.Text = "ID Number";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(541, 251);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(92, 27);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.Visible = false;
            // 
            // txtMobile
            // 
            this.txtMobile.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile.Location = new System.Drawing.Point(164, 102);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(147, 22);
            this.txtMobile.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(483, 251);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 21);
            this.label13.TabIndex = 1;
            this.label13.Text = "Email Address";
            this.label13.Visible = false;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(164, 72);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(201, 22);
            this.txtName.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label12.Location = new System.Drawing.Point(29, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 21);
            this.label12.TabIndex = 1;
            this.label12.Text = "Mobile Number";
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(164, 44);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(147, 22);
            this.txtCode.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(464, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contact Person";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(43, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer A/C";
            // 
            // odPicture
            // 
            this.odPicture.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(810, 382);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(69, 33);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reference Information";
            this.groupBox1.Visible = false;
            // 
            // txtRefAddress
            // 
            this.txtRefAddress.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefAddress.Location = new System.Drawing.Point(164, 307);
            this.txtRefAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRefAddress.Multiline = true;
            this.txtRefAddress.Name = "txtRefAddress";
            this.txtRefAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRefAddress.Size = new System.Drawing.Size(203, 23);
            this.txtRefAddress.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label9.Location = new System.Drawing.Point(66, 311);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 21);
            this.label9.TabIndex = 11;
            this.label9.Text = "Address 2";
            // 
            // txtRefFather
            // 
            this.txtRefFather.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefFather.Location = new System.Drawing.Point(164, 277);
            this.txtRefFather.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRefFather.Name = "txtRefFather";
            this.txtRefFather.Size = new System.Drawing.Size(149, 22);
            this.txtRefFather.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label8.Location = new System.Drawing.Point(48, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 21);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ref. Relation ";
            // 
            // txtRefContact
            // 
            this.txtRefContact.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefContact.Location = new System.Drawing.Point(164, 339);
            this.txtRefContact.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRefContact.Name = "txtRefContact";
            this.txtRefContact.Size = new System.Drawing.Size(149, 22);
            this.txtRefContact.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label6.Location = new System.Drawing.Point(71, 339);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 21);
            this.label6.TabIndex = 4;
            this.label6.Text = "Contact 2";
            // 
            // txtRefName
            // 
            this.txtRefName.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefName.Location = new System.Drawing.Point(164, 248);
            this.txtRefName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRefName.Name = "txtRefName";
            this.txtRefName.Size = new System.Drawing.Size(149, 22);
            this.txtRefName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Location = new System.Drawing.Point(65, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ref. Name";
            // 
            // fCustomer
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(992, 546);
            this.Controls.Add(this.cboCusType);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtRefAddress);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.numOpeningDue);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRefFather);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRefContact);
            this.Controls.Add(this.numPrevDue);
            this.Controls.Add(this.txtNID);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pbxProPic);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtRefName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNIDNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.txtName);
            this.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(650, 120);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fCustomer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Customer Detail";
            this.Load += new System.EventHandler(this.fCustomer_Load_1);
            this.txtNID.ResumeLayout(false);
            this.txtNID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpeningDue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrevDue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox txtNID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNIDNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pbxProPic;
        private System.Windows.Forms.OpenFileDialog odPicture;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numPrevDue;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRefAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRefFather;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRefContact;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRefName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numOpeningDue;
        private System.Windows.Forms.ComboBox cboCusType;
        private System.Windows.Forms.Label label14;

    }
}