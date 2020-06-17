namespace StockTool
{
    partial class Setting
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtStockCode = new System.Windows.Forms.TextBox();
            this.txtUpdateInterval = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiffSeconds = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiff = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.ckAlert = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "股票代码";
            // 
            // txtStockCode
            // 
            this.txtStockCode.Location = new System.Drawing.Point(84, 23);
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Size = new System.Drawing.Size(118, 21);
            this.txtStockCode.TabIndex = 1;
            this.txtStockCode.Text = "sh000001";
            // 
            // txtUpdateInterval
            // 
            this.txtUpdateInterval.Location = new System.Drawing.Point(84, 55);
            this.txtUpdateInterval.Name = "txtUpdateInterval";
            this.txtUpdateInterval.Size = new System.Drawing.Size(41, 21);
            this.txtUpdateInterval.TabIndex = 2;
            this.txtUpdateInterval.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "更新间隔";
            // 
            // txtDiffSeconds
            // 
            this.txtDiffSeconds.Location = new System.Drawing.Point(3, 3);
            this.txtDiffSeconds.Name = "txtDiffSeconds";
            this.txtDiffSeconds.Size = new System.Drawing.Size(41, 21);
            this.txtDiffSeconds.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(124, 143);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(205, 143);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "秒";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "秒内相差";
            // 
            // txtDiff
            // 
            this.txtDiff.Location = new System.Drawing.Point(104, 3);
            this.txtDiff.Name = "txtDiff";
            this.txtDiff.Size = new System.Drawing.Size(41, 21);
            this.txtDiff.TabIndex = 4;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "元",
            "%"});
            this.cmbType.Location = new System.Drawing.Point(151, 3);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(46, 20);
            this.cmbType.TabIndex = 5;
            // 
            // ckAlert
            // 
            this.ckAlert.AutoSize = true;
            this.ckAlert.Location = new System.Drawing.Point(29, 90);
            this.ckAlert.Name = "ckAlert";
            this.ckAlert.Size = new System.Drawing.Size(48, 16);
            this.ckAlert.TabIndex = 3;
            this.ckAlert.Text = "提醒";
            this.ckAlert.UseVisualStyleBackColor = true;
            this.ckAlert.CheckedChanged += new System.EventHandler(this.ckAlert_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDiffSeconds);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.txtDiff);
            this.panel1.Location = new System.Drawing.Point(80, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 37);
            this.panel1.TabIndex = 4;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(292, 178);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ckAlert);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtUpdateInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStockCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Setting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStockCode;
        private System.Windows.Forms.TextBox txtUpdateInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiffSeconds;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiff;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.CheckBox ckAlert;
        private System.Windows.Forms.Panel panel1;
    }
}