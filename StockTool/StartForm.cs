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
        Thread updateThread;
        IntPtr hTaskList;

        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            IntPtr hTaskbar = API.FindWindow("Shell_SecondaryTrayWnd", null);
            IntPtr hTray = API.FindWindowEx(hTaskbar, IntPtr.Zero, "WorkerW", null);
            hTaskList = API.FindWindowEx(hTray, IntPtr.Zero, "MSTaskListWClass", null);

            API.SetParent(this.Handle, hTaskList);
            SetAppPos();

            StartUpdate();
        }

        void SetAppPos()
        {
            Rectangle pos = new Rectangle();

            API.GetWindowRect(hTaskList, out var rcBar);

            AppBarData taskbarInfo = new AppBarData();
            API.SHAppBarMessage(0x00000005, ref taskbarInfo);

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

            API.MoveWindow(this.Handle, pos.X, pos.Y, pos.Width, pos.Height, true);
        }

        void StartUpdate()
        {
            updateThread = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    var str = httpClient.GetStringAsync("http://hq.sinajs.cn/list=" + GlobalInfo.StockCode).Result;
                    var vars = str.Substring(str.IndexOf("=")).Trim('"').Split(',');
                    var nowPrice = float.Parse(vars[3]);
                    var lastPrice = float.Parse(vars[2]);
                    var up = (nowPrice - lastPrice) / lastPrice * 100;

                    this.Invoke(new Action(() =>
                    {
                        this.labPrice.Text = nowPrice.ToString("0.##");
                        this.labRate.Text = up.ToString("0.##");

                        this.labRate.ForeColor = labPrice.ForeColor = up < 0 ? Color.Green : Color.Red;
                    }));

                    Thread.Sleep(GlobalInfo.SleepSeconds * 1000);
                }
            }))
            { IsBackground = true };

            updateThread.Start();
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // fetchThread?.Abort();
        }
    }
}
