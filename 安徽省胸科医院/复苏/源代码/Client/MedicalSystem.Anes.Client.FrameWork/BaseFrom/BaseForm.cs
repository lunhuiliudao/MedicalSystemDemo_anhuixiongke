using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.FrameWork
{
    /// <summary>
    /// 基类窗口，热键设置等。
    /// </summary>
    [ComVisible(true)]
    public partial class BaseForm : Form, IBaseView
    {
        public BaseForm()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Padding = new Padding(1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.IsMainForm = false;
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); //双缓冲
        }

        /// <summary>
        /// 是否是系统启动的主窗口
        /// </summary>
        public bool IsMainForm { get; set; }

        public virtual bool IsDirty { get; set; }

        /// <summary>
        /// 通过热键注册控件
        /// </summary>
        public virtual bool RegisterControlByHotKey(string keyCode)
        {
            switch (keyCode)
            {
                case KeyCode.AppCode.HOME:
                case KeyCode.AppCode.Back:
                    if (!IsMainForm)
                    {
                        this.Close();
                        return true;
                    }
                    break;
            }
            return false;
        }
        public virtual bool RegisterControlByHotKey(Keys key)
        {
            return false;
        }


        public virtual void RegisterControlByImeMode(ImeMode imeMode)
        {

        }

        protected override void OnResize(EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                this.Top = 0;
                this.Left = 0;
                this.Width = Screen.PrimaryScreen.WorkingArea.Width;
                this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            }
            base.OnResize(e);
        }


        #region 热键设置

        private delegate void OnKeyCodeHander(string keyCode);
        public void RegisterKeyCodeSync(string keyCode)
        {
            this.BeginInvoke(new OnKeyCodeHander(RegisterKeyCode), new object[] { keyCode });
        }
        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="appCode"></param>
        public void RegisterKeyCode(string keyCode)
        {
            //主窗口热键设置
            if (!RegisterControlByHotKey(keyCode))
            {
                //子窗口自己处理内部控件
                RegisterControls(this.Controls, keyCode);
            }
        }

        private delegate void OnKeysHander(Keys key);

        public void RegisterKeysSync(Keys key)
        {
            this.BeginInvoke(new OnKeysHander(RegisterKeys), new object[] { key });
        }

        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="appCode"></param>
        public void RegisterKeys(Keys key)
        {
            //主窗口热键设置
            if (!RegisterControlByHotKey(key))
            {
                //子窗口自己处理内部控件
                RegisterControls(this.Controls, key);
            }
        }

        /// <summary>
        /// 获取当前激活BaseControl
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        private BaseControl IsBaseControl(Control ctrl)
        {
            if (ctrl is BaseControl)
                return ctrl as BaseControl;
            else
                return IsBaseControl(ctrl.Parent);
        }

        /// <summary>
        /// 注册子控件的热键设置
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        protected virtual bool RegisterControls(Control.ControlCollection controls, string keyCode)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is IBaseView && (ctrl as IBaseView).RegisterControlByHotKey(keyCode))
                {
                    return true;
                }
                if (RegisterControls(ctrl.Controls, keyCode))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 注册子控件的热键设置
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        protected virtual bool RegisterControls(Control.ControlCollection controls, Keys key)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is IBaseView && (ctrl as IBaseView).RegisterControlByHotKey(key))
                {
                    return true;
                }
                if (RegisterControls(ctrl.Controls, key))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region 窗体特效API

        /// <summary>
        /// 动态窗口特效 声明API函数 【导入user32.dll】
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="dwTime"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32")]
        protected static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        //正面_水平方向
        protected const int AW_HOR_POSITIVE = 0x0001;
        //负面_水平方向
        protected const int AW_HOR_NEGATIVE = 0x0002;
        //正面_垂直方向
        protected const int AW_VER_POSITIVE = 0x0004;
        //负面_垂直方向
        protected const int AW_VER_NEGATIVE = 0x0008;
        //由中间四周展开或由四周向中间缩小
        protected const int AW_CENTER = 0x0010;
        //隐藏对象
        protected const int AW_HIDE = 0x10000;
        //显示对象
        protected const int AW_ACTIVATE = 0x20000;
        //拉幕滑动效果
        protected const int AW_SLIDE = 0x40000;
        //淡入淡出渐变效果
        protected const int AW_BLEND = 0x80000;

        #endregion

        #region [渐进式扩张]打开窗体特效，[渐进式收缩]关闭窗体特效

        /// <summary>
        /// 动画特效时长
        /// </summary>
        protected virtual int dwTime { get { return 300; } }

        /// <summary>
        /// 打开界面时居中特效
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //特效
            AnimateWindow(this.Handle, dwTime, AW_CENTER | AW_ACTIVATE | AW_HOR_POSITIVE);
        }

        /// <summary>
        /// 关闭时的特效
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            //特效
            AnimateWindow(this.Handle, dwTime, AW_CENTER | AW_HIDE | AW_HOR_NEGATIVE);

            base.OnClosing(e);
        }

        #endregion

        #region 花边框

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.FromArgb(132, 135, 137)))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            int xy = this.Padding.Top;
            if (this.Padding.Top < 10)
            {
                xy = 26;
            }
            if (e.Location.X >= this.Width - xy && e.Location.Y <= xy)
            {
                this.Close();
                this.Dispose(true);
            }
            base.OnMouseClick(e);
        }

        #endregion

        #region 移动窗口

        [DllImport("User32.DLL")]
        protected static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("User32.DLL")]
        protected static extern bool ReleaseCapture();
        protected const uint WM_SYSCOMMAND = 0x0112;
        protected const int SC_MOVE = 61456;
        protected const int HTCAPTION = 2;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE | HTCAPTION, 0);
            }
            base.OnMouseMove(e);
        }

        #endregion

        #region 解决界面闪烁情况

        protected override CreateParams CreateParams
        {
            get
            {
                if (!DesignMode)
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                    return cp;
                }
                return base.CreateParams;
            }
        }

        #endregion

        #region 设置默认的DataGridView的样式

        /// <summary>
        /// 设置默认的DataGridView的样式
        /// </summary>
        /// <param name="dgv"></param>
        public virtual void SetDefaultGridViewStyle(DataGridView dgv, int RowHeight = 40, int ColumnHeight = 50)
        {
            if (dgv == null)
                return;

            if (dgv.RowsDefaultCellStyle == null)
            {
                dgv.RowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            }
            dgv.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));

            if (dgv.DefaultCellStyle == null)
            {
                dgv.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            }
            dgv.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
            dgv.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F);
            dgv.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;

            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;// System.Drawing.SystemColors.HighlightText;

            if (dgv.AlternatingRowsDefaultCellStyle == null)
            {
                dgv.AlternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            }

            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));


            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));

            if (dgv.ColumnHeadersDefaultCellStyle == null)
            {
                dgv.ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            }
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.RowTemplate.Height = RowHeight;
            dgv.ColumnHeadersHeight = ColumnHeight;
        }

        #endregion





    }
}
