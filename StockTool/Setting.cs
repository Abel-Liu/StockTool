using System;
using System.Drawing;
using System.Windows.Forms;

namespace StockTool
{
    public partial class Setting : Form
    {
        public bool SettingUpdated { get; set; } = false;

        public Setting()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SaveConfig())
            {
                SettingUpdated = true;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SettingUpdated = false;
            this.Close();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        protected void LoadConfig()
        {
            var config = GlobalInfo.ReadConfig();
            if (config != null)
            {
                txtStockCode.Text = config.StockCode;
                txtUpdateInterval.Text = config.UpdateInterval.ToString();
                txtDiff.Text = config.Diff.HasValue ? config.Diff.ToString() : string.Empty;
                txtDiffSeconds.Text = config.DiffSeconds.HasValue ? config.DiffSeconds.ToString() : string.Empty;
                cmbType.SelectedItem = config.DiffType;
                ckAlert.Checked = config.AlertEnabled;
            }
            else
            {
                ckAlert.Checked = false;
            }

            ckAlert_CheckedChanged(ckAlert, null);
        }

        protected bool SaveConfig()
        {
            var config = new Config();
            config.StockCode = txtStockCode.Text.Trim();

            if (!int.TryParse(txtUpdateInterval.Text.Trim(), out var i) || i < 1)
            {
                txtUpdateInterval.BackColor = Color.LightCoral;
                return false;
            }

            txtUpdateInterval.BackColor = SystemColors.Window;
            config.UpdateInterval = i;

            if (config.AlertEnabled = ckAlert.Checked)
            {
                if (!int.TryParse(txtDiffSeconds.Text.Trim(), out var ds) || ds < 1)
                {
                    txtDiffSeconds.BackColor = Color.LightCoral;
                    return false;
                }

                txtDiffSeconds.BackColor = SystemColors.Window;
                config.DiffSeconds = ds;

                if (!float.TryParse(txtDiff.Text.Trim(), out var d) || d <= 0)
                {
                    txtDiff.BackColor = Color.LightCoral;
                    return false;
                }

                txtDiff.BackColor = SystemColors.Window;
                config.Diff = d;

                if (string.IsNullOrEmpty(config.DiffType = cmbType.SelectedItem + ""))
                    return false;
            }

            GlobalInfo.SaveConfig(config);

            return true;
        }

        private void ckAlert_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = ckAlert.Checked;
        }
    }
}
