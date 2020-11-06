using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors;
using DevExpress.LookAndFeel;

namespace MedicalSystem.MedScreen.Controls
{
    public class AutoClosedMsgBox
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool EndDialog(IntPtr hDlg, int nResult);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public static IntPtr ptr = IntPtr.Zero;

        const int WM_CLOSE = 0x10;
        /// <summary>
        /// 弹出自动关闭的MessageBox窗口
        /// </summary>
        /// <param name="text">弹出窗口的显示内容</param>
        /// <param name="caption">弹出窗口的标题</param>
        /// <param name="milliseconds">窗口持续显示时间(毫秒)</param>
        /// <returns>固定返回DialogResult.OK</returns>
        public static DialogResult Show(string text, string caption, int milliseconds, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DialogResult ret = DialogResult.OK;
            if (milliseconds == 0)
            {
                milliseconds = int.MaxValue;
            }
           
            Timer timer = new Timer();
            timer.Interval = milliseconds;
            timer.Tick += (a, b) =>
            {
                ptr = FindWindow(null, caption);
                if (ptr != IntPtr.Zero)
                {
                    //EndDialog(ptr, 0);
                    PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                }
                timer.Stop();
            };
            timer.Start();
            UserLookAndFeel lookFeel = new UserLookAndFeel(null);
            lookFeel.SetSkinStyle("Blue");
            ptr = FindWindow(null, caption);
            if (ptr == IntPtr.Zero)
            {
                ret = XtraMessageBox.Show(lookFeel, text, caption, buttons, icon);
            }
            //ret = MessageBox.Show(text, caption, buttons, icon);
            return ret;
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DialogResult ret = DialogResult.OK;
            UserLookAndFeel lookFeel = new UserLookAndFeel(null);
            lookFeel.SetSkinStyle("Blue");
            ret = XtraMessageBox.Show(lookFeel, text, caption, buttons, icon);
            return ret;
        }
    }
}
