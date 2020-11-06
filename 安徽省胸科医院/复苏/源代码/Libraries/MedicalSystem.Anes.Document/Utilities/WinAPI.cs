using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MedicalSystem.Anes.Document.Utilities
{
 public class WinAPI
    {
        #region 常数声明

        /// <summary>
        /// ListView图标间距常数
        /// </summary>
        public static int LVM_SETICONSPACING = 0x1035;

        /// <summary>
        /// 鼠标键盘消息常数
        /// </summary>
        public static int WM_NCHITTEST = 0x84;
        public static int WM_CLOSE = 0x10;

        /// <summary>
        /// 客户区常数
        /// </summary>
        public static int HTCLIENT = 0x01;

        /// <summary>
        /// 标题区常数
        /// </summary>
        public static int HTCAPTION = 0x02;

        /// <summary>
        /// 系统命令常数
        /// </summary>
        public static int WM_SYSCOMMAND = 0x0112;

        /// <summary>
        /// 系统绘制消息
        /// </summary>
        public static int WM_PAINT = 0x0000F;

     /// <summary>
     /// 键盘上
     /// </summary>
        public static int WM_KEYUP = 0X101;

        /// <summary>
        /// 键盘下
        /// </summary>
        public static int WM_KEYDOWN = 0X100;

        /// <summary>
        /// 移动消息常数
        /// </summary>
        public static int SC_MOVE = 0xF012;

        public static int IME_CMODE_FULLSHAPE = 0x8;
        public static int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;

        public static int WM_USER = 0x0400;
        public static int WM_REFLECT = WM_USER + 0x1C00;
        public static int WM_COMMAND = 0x0111;
        public static int CBN_DROPDOWN = 7;

        #endregion

        [DllImport("kernel32.dll")]
        public static extern bool SetLocalTime(ref SYSTEMTIME time);



        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short year;
            public short month;
            public short dayOfWeek;
            public short day;
            public short hour;
            public short minute;
            public short second;
            public short milliseconds;
        }

        public delegate System.UInt32 FRHookProc(System.IntPtr hdlg,
                System.UInt32 uiMsg,
                System.UInt32 wParam,
                System.UInt32 lParam
                );

        [StructLayout(LayoutKind.Sequential)]
        public struct FINDREPLACE
        {
            public System.UInt32 lStructSize;
            public System.IntPtr hwndOwner;
            public System.IntPtr hInstance;
            public System.UInt32 Flags;
            public string lpstrFindWhat;
            public string lpstrReplaceWith;
            public System.UInt16 wFindWhatLen;
            public System.UInt16 wReplaceWithLen;
            public System.UInt32 lCustData;
            public FRHookProc lpfnHook;
            public String lpTemplateName;

        }

        #region 函数声明

   
        [DllImport("comdlg32.dll", CharSet = CharSet.Ansi)]
        public extern static IntPtr FindText(ref FINDREPLACE fdr);

        /// <summary>
        /// 设置父窗口
        /// </summary>
        /// <param name="hWndChild">子窗口句柄</param>
        /// <param name="hWndNewParent">父窗口句柄</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SetParent(int hWndChild, int hWndNewParent);


        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int SetTextAlign(HandleRef hDC, int nMode);

     
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="hWnd">接收消息的窗口句柄</param>
        /// <param name="msg">消息</param>
        /// <param name="wParam">消息参数</param>
        /// <param name="lParam">消息参数</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

       [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);


        [DllImportAttribute("shell32.dll")]
        public static extern IntPtr ShellExecute(int hWnd, string Operation, string FileName, string Dir,string Parameters,int ShowCmd);
        
        [DllImportAttribute("gdi32.dll")]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImportAttribute("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImportAttribute("user32.dll")]
        public static extern IntPtr SetCapture(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern void BlockInput(bool Block);

        ////声明读写INI文件的API函数 
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        //// 修改输入法全角半角API
        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hwnd);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetOpenStatus(IntPtr himc);
        [DllImport("imm32.dll")]
        public static extern bool ImmSetOpenStatus(IntPtr himc, bool b);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetConversionStatus(IntPtr himc, ref int lpdw, ref int lpdw2);
        [DllImport("imm32.dll")]
        public static extern int ImmSimulateHotKey(IntPtr hwnd, int lngHotkey);
        /// <summary>
        /// 新华医院使用的查看检查动态库函数声明
        /// </summary>
        /// <param name="MZID">门诊号</param>
        /// <param name="ZYID">住院号</param>
        /// <param name="STARTDATE">检查起始日期</param>
        /// <param name="ENDDATE">检查结束日期</param>
        /// <param name="PACSSheetID">申请单号</param>
        /// <param name="HISSheetID">HIS申请单号</param>
        /// <param name="AutoShowUI">是否显示报告界面 0 不显示 1 显示</param>
        /// <param name="ReportType">报告类型</param>
        /// <param name="TextReport">文字报告</param>
        /// <param name="YL1">预留1     -- 工号</param>
        /// <param name="YL2">预留2</param>
        /// <param name="YL3">预留3</param>
        /// <param name="YL4">预留4</param>
        /// <returns></returns>
        [DllImport("PACSReporT.dll", CharSet = CharSet.Auto)]
        public static extern bool ShowPACSReport(string MZID,
                                   string ZYID,
                                   string STARTDATE,
                                   string ENDDATE,
                                   string PACSSheetID,
                                   string HISSheetID,
                                   string AutoShowUI,
                                   string ReportType,
                                   string TextReport,
                                   string YL1,
                                   string YL2,
                                   string YL3,
                                   string YL4);

        #endregion
    }
}


