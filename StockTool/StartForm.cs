using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;

namespace StockTool
{
    public partial class StartForm : Form
    {
        HttpClient httpClient = new HttpClient();
        IntPtr hTaskList;
        Config config;
        LinkedList<KeyValuePair<DateTime, float>> history = new LinkedList<KeyValuePair<DateTime, float>>();
        int maxHistoryCount = 10000;
        bool isAlerting = false;

        public StartForm()
        {
            InitializeComponent();

            config = GlobalInfo.ReadConfig();
            if (config == null)
            {
                config = new Config()
                {
                    StockCode = "sh000001",
                    UpdateInterval = 5
                };
            }

            this.MouseUp += StartForm_MouseUp;

            foreach (Control c in this.Controls)
            {
                c.MouseUp += StartForm_MouseUp;
            }
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            //IntPtr hTaskbar = API.FindWindow("Shell_SecondaryTrayWnd", null);
            //IntPtr hTray = API.FindWindowEx(hTaskbar, IntPtr.Zero, "WorkerW", null);
            //hTaskList = API.FindWindowEx(hTray, IntPtr.Zero, "MSTaskListWClass", null);

            IntPtr hTaskbar = API.FindWindow("Shell_TrayWnd", null);
            IntPtr hReBar = API.FindWindowEx(hTaskbar, IntPtr.Zero, "ReBarWindow32", null);
            IntPtr ht = API.FindWindowEx(hReBar, IntPtr.Zero, "MSTaskSwWClass", null);
            hTaskList = API.FindWindowEx(ht, IntPtr.Zero, "MSTaskListWClass", null);

            API.SetParent(this.Handle, hTaskList);
            SetAppPos();
            StartUpdate();
        }

        void SetAppPos()
        {
            new Thread(new ThreadStart(() =>
            {
                Rectangle pos = new Rectangle();
                AppBarData taskbarInfo = new AppBarData();

                while (true)
                {
                    API.GetWindowRect(hTaskList, out var rcBar);

                    API.SHAppBarMessage(0x00000005, ref taskbarInfo);

                    this.Invoke(new Action(() =>
                    {
                        this.Width = labPrice.Width;
                    }));

                    switch (taskbarInfo.uEdge)
                    {
                        case 3://任务栏在下边
                            pos.X = rcBar.Right - rcBar.Left - this.Width;
                            pos.Y = 0;
                            pos.Width = this.Width;
                            pos.Height = rcBar.Bottom - rcBar.Top;
                            break;
                        default:
                            break;
                    }

                    this.Invoke(new Action(() =>
                    {
                        API.MoveWindow(this.Handle, pos.X, pos.Y, pos.Width, pos.Height, true);
                    }));

                    Thread.Sleep(100);
                }
            }))
            { IsBackground = true }
            .Start();
        }

        void StartUpdate()
        {
            new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    UpdateOnce();
                    Thread.Sleep(config.UpdateInterval * 1000);
                }
            }))
            { IsBackground = true }
            .Start();
        }

        void UpdateOnce()
        {
            var url = "http://hq.sinajs.cn/list=" + config.StockCode;
            var html = httpClient.GetStringAsync(url).Result;
            var vars = html.Substring(html.IndexOf("=")).Trim('"').Split(',');
            if (vars.Length<4)
            {
                return;
            }
            var nowPrice = float.Parse(vars[3]);
            var lastPrice = float.Parse(vars[2]);
            var up = (nowPrice - lastPrice) / lastPrice * 100;

            this.Invoke(new Action(() =>
            {
                this.labPrice.Text = nowPrice.ToString("0.00");
                this.labRate.Text = up.ToString("0.00") + "%";

                this.labRate.ForeColor = labPrice.ForeColor = up < 0 ? Color.Green : Color.Red;
            }));

            lock (history)
            {
                history.AddLast(new LinkedListNode<KeyValuePair<DateTime, float>>(new KeyValuePair<DateTime, float>(DateTime.Now, nowPrice)));
                if (history.Count > maxHistoryCount)
                {
                    history.RemoveFirst();
                }

                if (config.AlertEnabled && !isAlerting)
                {
                    var now = DateTime.Now;
                    var maxPrice = nowPrice;
                    var minPrice = nowPrice;
                    LinkedListNode<KeyValuePair<DateTime, float>> node = history.Last;

                    while (true)
                    {
                        if ((now - node.Value.Key).TotalSeconds > config.DiffSeconds)
                            break;

                        if (node.Value.Value > maxPrice)
                            maxPrice = node.Value.Value;

                        if (node.Value.Value < minPrice)
                            minPrice = node.Value.Value;

                        if (config.DiffType == "%")
                        {
                            if ((maxPrice - minPrice) / maxPrice >= config.Diff.Value / 100)
                            {
                                DoAlert();
                                break;
                            }
                        }
                        else
                        {
                            if (maxPrice - minPrice >= config.Diff.Value)
                            {
                                DoAlert();
                                break;
                            }
                        }

                        if (node.Previous == null)
                            break;

                        node = node.Previous;
                    }
                }
            }
        }

        private void DoAlert()
        {
            lock (history)
            {
                isAlerting = true;
            }

            new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    if (!isAlerting)
                        break;

                    this.Invoke(new Action(() =>
                    {
                        labRate.Visible = labPrice.Visible = !labPrice.Visible;
                    }));

                    Thread.Sleep(300);
                }
            }))
            { IsBackground = true }.Start();
        }

        private void cancelAlertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (history)
            {
                isAlerting = false;
                history.Clear();
            }

            Thread.Sleep(300);
            labRate.Visible = labPrice.Visible = true;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(this, e.Location);
                this.cancelAlertToolStripMenuItem.Enabled = isAlerting;
            }
        }

        public static Setting settingForm;

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (settingForm == null)
            {
                settingForm = new Setting();
                settingForm.Show();
                settingForm.Location = new Point(MousePosition.X - settingForm.Width, MousePosition.Y - settingForm.Height);

                settingForm.FormClosed += (s, arg) =>
                {
                    if (settingForm.SettingUpdated)
                    {
                        config = GlobalInfo.ReadConfig();
                        UpdateOnce();
                    }

                    settingForm.Dispose();
                    settingForm = null;
                };

            }
            else
            {
                settingForm.Show();
                settingForm.WindowState = FormWindowState.Normal;
                settingForm.BringToFront();
            }
        }

    }
}
