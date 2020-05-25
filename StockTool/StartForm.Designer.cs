namespace StockTool
{
    partial class StartForm
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
            this.labPrice = new System.Windows.Forms.Label();
            this.labRate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labPrice
            // 
            this.labPrice.AutoSize = true;
            this.labPrice.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPrice.ForeColor = System.Drawing.Color.Red;
            this.labPrice.Location = new System.Drawing.Point(2, -3);
            this.labPrice.Name = "labPrice";
            this.labPrice.Size = new System.Drawing.Size(143, 34);
            this.labPrice.TabIndex = 0;
            this.labPrice.Text = "00000.00";
            // 
            // labRate
            // 
            this.labRate.AutoSize = true;
            this.labRate.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRate.ForeColor = System.Drawing.Color.Red;
            this.labRate.Location = new System.Drawing.Point(10, 26);
            this.labRate.Name = "labRate";
            this.labRate.Size = new System.Drawing.Size(56, 17);
            this.labRate.TabIndex = 1;
            this.labRate.Text = "-0.00%";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(153, 47);
            this.Controls.Add(this.labRate);
            this.Controls.Add(this.labPrice);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.TransparencyKey = System.Drawing.SystemColors.Desktop;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartForm_FormClosing);
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labPrice;
        private System.Windows.Forms.Label labRate;
    }
}