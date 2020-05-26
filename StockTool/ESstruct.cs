using System;
using System.IO;
using System.Runtime.InteropServices;

namespace StockTool
{
    public static class GlobalInfo
    {
        public static string StockCode = "sh000001";

        public static int SleepSeconds = 5;

        static GlobalInfo()
        {
            var settings = File.ReadAllLines("config");

            try
            {
                StockCode = settings[0];
                SleepSeconds = int.Parse(settings[1]);
            }
            catch (Exception e)
            {

            }
        }
    }

    /// <summary>
    /// 包含进程模块的信息
    /// </summary>
    public struct MODULEENTRY32
    {
        public const int MAX_PATH = 255;
        public uint dwSize;
        public uint th32ModuleID;
        public uint th32ProcessID;
        public uint GlblcntUsage;
        public uint ProccntUsage;
        public IntPtr modBaseAddr;
        public uint modBaseSize;
        public IntPtr hModule;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
        public string szModule;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 5)]
        public string szExePath;
    }


    /// <summary>
    /// 键盘钩子的封送结构类型 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class KeyboardHookStruct
    {
        /// <summary>
        /// 表示一个在1到254间的虚似键盘码
        /// </summary>
        public int vkCode;
        public int scanCode;   //表示硬件扫描码 
        public int flags;
        public int time;
        public int dwExtraInfo;
    }

    /// <summary>
    /// 包含reBar的句柄、位置和大小
    /// </summary>
    public struct reBarInfo
    {
        public IntPtr hreBar;
        public IntPtr hTaskBar;
        public int x;
        public int y;
        public int width;
        public int height;
    }

    /// <summary>
    /// 包含任务栏的信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AppBarData
    {
        public int cbSize;
        public IntPtr hWnd;
        public int uCallbackMessage;
        /// <summary>
        /// 任务栏位置左0,上1,右2,下3
        /// </summary>
        public int uEdge;
        /// <summary>
        /// 任务栏的坐标
        /// </summary>
        public RECT rc;
        public IntPtr lParam;
    }

    /// <summary>
    /// 包含消息的结构体
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CopyDataStruct
    {
        public IntPtr dwData;
        public int cbData;
        /// <summary>
        /// 包含要添加的文件路径
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpData;
    }

    [Flags()]
    public enum KeyModifiers
    {
        None = 0,
        Alt = 1,
        Ctrl = 2,
        Shift = 4,
        WindowsKey = 8
    }

    /// <summary>
    /// 矩形结构
    /// </summary>
    public struct RECT
    {
        public RECT(System.Drawing.Rectangle rectangle)
        {
            Left = rectangle.Left;
            Top = rectangle.Top;
            Right = rectangle.Right;
            Bottom = rectangle.Bottom;
        }
        public RECT(System.Drawing.Point location, System.Drawing.Size size)
        {
            Left = location.X;
            Top = location.Y;
            Right = location.X + size.Width;
            Bottom = location.Y + size.Height;
        }
        public Int32 Left;
        public Int32 Top;
        public Int32 Right;
        public Int32 Bottom;
    }
}
