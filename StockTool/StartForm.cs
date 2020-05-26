using System;
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

        public StartForm()
        {
            InitializeComponent();

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
                string html = string.Empty;
                var url = "http://hq.sinajs.cn/list=" + GlobalInfo.StockCode;
                while (true)
                {
                    html = httpClient.GetStringAsync(url).Result;
                    var vars = html.Substring(html.IndexOf("=")).Trim('"').Split(',');
                    var nowPrice = float.Parse(vars[3]);
                    var lastPrice = float.Parse(vars[2]);
                    var up = (nowPrice - lastPrice) / lastPrice * 100;

                    this.Invoke(new Action(() =>
                    {
                        this.labPrice.Text = nowPrice.ToString("0.00");
                        this.labRate.Text = up.ToString("0.00") + "%";

                        this.labRate.ForeColor = labPrice.ForeColor = up < 0 ? Color.Green : Color.Red;
                    }));

                    Thread.Sleep(GlobalInfo.SleepSeconds * 1000);
                }
            }))
            { IsBackground = true }
            .Start();
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
            }
        }
    }
}
