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
            this.components = new System.ComponentModel.Container();
            this.labPrice = new System.Windows.Forms.Label();
            this.labRate = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelAlertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labPrice
            // 
            this.labPrice.AutoSize = true;
            this.labPrice.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPrice.ForeColor = System.Drawing.Color.Red;
            this.labPrice.Location = new System.Drawing.Point(2, -3);
            this.labPrice.Name = "labPrice";
            this.labPrice.Size = new System.Drawing.Size(127, 34);
            this.labPrice.TabIndex = 0;
            this.labPrice.Text = "0000.00";
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelAlertToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // cancelAlertToolStripMenuItem
            // 
            this.cancelAlertToolStripMenuItem.Name = "cancelAlertToolStripMenuItem";
            this.cancelAlertToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cancelAlertToolStripMenuItem.Text = "CancelAlert";
            this.cancelAlertToolStripMenuItem.Click += new System.EventHandler(this.cancelAlertToolStripMenuItem_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(130, 47);
            this.Controls.Add(this.labRate);
            this.Controls.Add(this.labPrice);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labPrice;
        private System.Windows.Forms.Label labRate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelAlertToolStripMenuItem;
    }
}