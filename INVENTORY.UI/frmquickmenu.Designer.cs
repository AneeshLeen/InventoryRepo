namespace INVENTORY.UI
{
    partial class frmquickmenu
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
            this.button38 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlbtndyan = new System.Windows.Forms.Panel();
            this.pnlbasedcat = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button38
            // 
            this.button38.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button38.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button38.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button38.Location = new System.Drawing.Point(3, 549);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(256, 35);
            this.button38.TabIndex = 234;
            this.button38.Text = "^";
            this.button38.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(3, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(256, 35);
            this.button1.TabIndex = 232;
            this.button1.Text = "^";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pnlbtndyan
            // 
            this.pnlbtndyan.AutoScroll = true;
            this.pnlbtndyan.Location = new System.Drawing.Point(3, 38);
            this.pnlbtndyan.Name = "pnlbtndyan";
            this.pnlbtndyan.Size = new System.Drawing.Size(256, 510);
            this.pnlbtndyan.TabIndex = 233;
            // 
            // pnlbasedcat
            // 
            this.pnlbasedcat.AutoScroll = true;
            this.pnlbasedcat.Location = new System.Drawing.Point(265, 1);
            this.pnlbasedcat.Name = "pnlbasedcat";
            this.pnlbasedcat.Size = new System.Drawing.Size(393, 583);
            this.pnlbasedcat.TabIndex = 235;
            // 
            // frmquickmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 619);
            this.Controls.Add(this.pnlbasedcat);
            this.Controls.Add(this.button38);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlbtndyan);
            this.Name = "frmquickmenu";
            this.Text = "frmquickmenu";
            this.Load += new System.EventHandler(this.frmquickmenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button38;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlbtndyan;
        private System.Windows.Forms.Panel pnlbasedcat;
    }
}