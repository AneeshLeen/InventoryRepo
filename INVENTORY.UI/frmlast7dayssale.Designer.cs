namespace INVENTORY.UI
{
    partial class frmlast7dayssale
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.crtlast7days = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.crtlast7days)).BeginInit();
            this.SuspendLayout();
            // 
            // crtlast7days
            // 
            chartArea2.Name = "ChartArea1";
            this.crtlast7days.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.crtlast7days.Legends.Add(legend2);
            this.crtlast7days.Location = new System.Drawing.Point(33, 45);
            this.crtlast7days.Name = "crtlast7days";
            this.crtlast7days.Size = new System.Drawing.Size(736, 370);
            this.crtlast7days.TabIndex = 0;
            this.crtlast7days.Text = "chart1";
            // 
            // frmlast7dayssale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crtlast7days);
            this.Name = "frmlast7dayssale";
            this.Text = "Last7daysSale";
            this.Load += new System.EventHandler(this.frmlast7dayssale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.crtlast7days)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart crtlast7days;
    }
}