using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MedicalSystem.Anes.FrameWork
{
    /// <summary>
    /// 文本下来菜单
    /// </summary>
    public class MTextBoxBorder : MTextBox
    {
        public MTextBoxBorder()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        /// <summary>   
        /// 获得当前进程，以便重绘控件   
        /// </summary>   
        /// <param name="hWnd"></param>   
        /// <returns></returns>   
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        /// <summary>   
        /// 是否启用热点效果   
        /// </summary>   
        private bool _HotTrack = true;

        /// <summary>   
        /// 热点边框颜色   
        /// </summary>   
        private Color _HotColor = Color.Blue;

        #region 属性
        /// <summary>   
        /// 是否启用热点效果   
        /// </summary>   
        [Category("行为")]
        [Description("获得或设置一个值，指示当鼠标经过控件时控件边框是否发生变化。只在控件的BorderStyle为FixedSingle时有效")]
        [DefaultValue(true)]
        public bool HotTrack
        {
            get
            {
                return this._HotTrack;
            }
            set
            {
                this._HotTrack = value;
                //在该值发生变化时重绘控件，下同   
                //在设计模式下，更改该属性时，如果不调用该语句，   
                //则不能立即看到设计试图中该控件相应的变化   
                this.Invalidate();
            }
        }
        /// <summary>   
        /// 热点时边框颜色   
        /// </summary>   
        [Category("外观")]
        [Description("获得或设置当鼠标经过控件时控件的边框颜色。只在控件的BorderStyle为FixedSingle时有效")]
        [DefaultValue(typeof(Color), "Blue")]
        public Color HotColor
        {
            get
            {
                return this._HotColor;
            }
            set
            {
                this._HotColor = value;
                this.Invalidate();
            }
        }
        #endregion 属性

        /// <summary>   
        /// 当该控件获得焦点时   
        /// </summary>   
        /// <param name="e"></param>   
        protected override void OnGotFocus(EventArgs e)
        {

            if (this._HotTrack)
            {
                //重绘   
                this.Invalidate();
            }
            base.OnGotFocus(e);
        }
        /// <summary>   
        /// 当该控件失去焦点时   
        /// </summary>   
        /// <param name="e"></param>   
        protected override void OnLostFocus(EventArgs e)
        {
            if (this._HotTrack)
            {
                //重绘   
                this.Invalidate();
            }
            base.OnLostFocus(e);
        }

        /// <summary>   
        /// 获得操作系统消息   
        /// </summary>   
        /// <param name="m"></param>   
        protected override void WndProc(ref Message m)
        {

            base.WndProc(ref m);
            if (m.Msg == 0xf || m.Msg == 0x133)
            {
                //拦截系统消息，获得当前控件进程以便重绘。   
                //一些控件（如TextBox、Button等）是由系统进程绘制，重载OnPaint方法将不起作用.   
                //所有这里并没有使用重载OnPaint方法绘制TextBox边框。   
                //   
                //MSDN:重写 OnPaint 将禁止修改所有控件的外观。   
                //那些由 Windows 完成其所有绘图的控件（例如 Textbox）从不调用它们的 OnPaint 方法，   
                //因此将永远不会使用自定义代码。请参见您要修改的特定控件的文档，   
                //查看 OnPaint 方法是否可用。如果某个控件未将 OnPaint 作为成员方法列出，   
                //则您无法通过重写此方法改变其外观。   
                //   
                //MSDN:要了解可用的 Message.Msg、Message.LParam 和 Message.WParam 值，   
                //请参考位于 MSDN Library 中的 Platform SDK 文档参考。可在 Platform SDK（“Core SDK”一节）   
                //下载中包含的 windows.h 头文件中找到实际常数值，该文件也可在 MSDN 上找到。   
                IntPtr hDC = GetWindowDC(m.HWnd);
                if (hDC.ToInt32() == 0)
                {
                    return;
                }

                //只有在边框样式为FixedSingle时自定义边框样式才有效   
                if (this.BorderStyle == BorderStyle.FixedSingle)
                {
                    //边框Width为1个像素
                    System.Drawing.Pen pen = new Pen(Color.LightGray, 1);
                    if (this._HotTrack && this.Focused)
                    {
                        //边框Width为1个像素
                        pen.Color = this._HotColor;
                    }
                    //绘制边框   
                    System.Drawing.Graphics g = Graphics.FromHdc(hDC);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                    pen.Dispose();
                    g.Dispose();
                }
                //返回结果   
                m.Result = IntPtr.Zero;
                //释放   
                ReleaseDC(m.HWnd, hDC);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

    }
}