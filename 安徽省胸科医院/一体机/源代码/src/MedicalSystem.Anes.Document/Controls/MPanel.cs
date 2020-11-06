using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MedicalSystem.Anes.Document.Controls;

namespace MedicalSystem.Anes.Document.Controls
{
    [ToolboxItem(true), Description("MedPanel")]
    public partial class MPanel : Panel, IPrintable
    {
        public MPanel()
        {
            base.BackColor = Color.White;

        }


        /// <summary>
        /// 是否画边框
        /// </summary>
        protected bool _drawBorder = false;

        /// <summary>
        /// 边框宽度
        /// </summary>
        protected int _borderWidth = 1;
        /// <summary>
        /// 边框颜色
        /// </summary>
        protected Color _borderColor = Color.Black;
        protected BorderType _borderType = BorderType.None;

        [Category("数据-自定义"), DisplayName("边框类型")]
        public BorderType BorderType
        {
            get
            {
                return _borderType;
            }
            set
            {
                _borderType = value;
            }
        }

        /// <summary>
        /// 边框宽度
        /// </summary>
        [Category("数据-自定义"), DisplayName("边框宽度")]
        public int BorderWidth
        {
            get
            {
                return _borderWidth;
            }
            set
            {
                _borderWidth = value;
            }
        }
        /// <summary>
        /// 边框颜色
        /// </summary>
        [Category("数据-自定义"), DisplayName("边框颜色")]
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
            }
        }
        /// <summary>
        /// 是否画边框
        /// </summary>
        [Category("数据-自定义"), DisplayName("是否画边框")]
        public bool IsDrawBorder
        {
            get
            {
                return _drawBorder;
            }
            set
            {
                _drawBorder = value;
                Refresh();
            }
        }

        private bool _drawBackground = false;
        [Category("数据-自定义"), DisplayName("打印背景")]
        public bool PrintBackGround
        {
            get
            {
                return _drawBackground;
            }
            set
            {
                _drawBackground = value;
            }
        }

        private bool _noPrint = false;
        [Category("数据-自定义"), DisplayName("不打印")]
        public bool NoPrint
        {
            get
            {
                return _noPrint;
            }
            set
            {
                _noPrint = value;
            }
        }

        /// <summary>
        /// 客户绘制事件接口
        /// </summary>
        private static readonly object _customDraw = new object();
        public event PaintEventHandler CustomDraw
        {
            add
            {
                Events.AddHandler(_customDraw, value);
            }
            remove
            {
                Events.RemoveHandler(_customDraw, value);
            }
        }

        /// <summary>
        /// 绘制控件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_drawBorder && _borderType != BorderType.None)
            {
                // e.Graphics.ScaleTransform(0.8f, 1f);
                DrawGraphics(e.Graphics);
            }
            else
            {
                base.OnPaint(e);
            }
            //base.OnPaint(e);
        }

        /// <summary>
        /// 重画区域-子类应该重写该方法
        /// </summary>
        /// <param name="g"></param>
        public virtual void DrawGraphics(Graphics g)
        {
            DrawBorder(g);
            PaintEventHandler eventHandle = Events[_customDraw] as PaintEventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, new PaintEventArgs(g, ClientRectangle));
            }
        }
        /// <summary>
        /// 画边框
        /// </summary>
        protected virtual void DrawBorder(Graphics g)
        {
            if (this.BorderStyle == BorderStyle.FixedSingle)
            {
                Rectangle rect = ClientRectangle;
                if (_drawBackground)
                    g.FillRectangle(new SolidBrush(BackColor), rect);
                rect.Width += -1;
                rect.Height += -1;
                Pen P = new Pen(_borderColor, _borderWidth);

                g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
            }
            else if (_drawBorder && _borderType != BorderType.None)
            {
                Rectangle rect = ClientRectangle;
                if (_drawBackground)
                    g.FillRectangle(new SolidBrush(BackColor), rect);
                rect.Width += -1;
                rect.Height += -1;
                Pen P = new Pen(_borderColor, _borderWidth);
                switch (_borderType)
                {
                    case BorderType.Rectangle:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    case BorderType.NoTop:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    case BorderType.RightBottom:
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    case BorderType.LeftRight:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        break;
                    case BorderType.NoBottom:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        break;
                    case BorderType.OnlyLeft:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        break;
                    case BorderType.OnlyRight:
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        break;
                    case BorderType.OnlyTop:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        break;
                    case BorderType.OnlyBottom:
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    case BorderType.LeftRightMoveLeft:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Right - 1, rect.Top, rect.Right - 1, rect.Bottom);
                        break;
                    case BorderType.LeftRightMoveRight:
                        g.DrawLine(P, rect.Left + 1, rect.Top, rect.Left + 1, rect.Bottom);
                        g.DrawLine(P, rect.Right + 1, rect.Top, rect.Right + 1, rect.Bottom);
                        break;
                    case BorderType.LeftTop:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        break;
                    case BorderType.LeftBottom:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    case BorderType.RightTop:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        break;
                    case BorderType.TopBottom:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        break;
                    case BorderType.LeftTopBottom:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        break;
                    case BorderType.RightTopBottom:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        break;
                    case BorderType.LeftBottomRight:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        break;
                    case BorderType.LeftTopRight:
                        g.DrawLine(P, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        g.DrawLine(P, rect.Left, rect.Top, rect.Right, rect.Top);
                        g.DrawLine(P, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        break;
                }
                P.Dispose();
            }
        }


        /// <summary>
        /// IPrint接口-打印
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Draw(Graphics g, float x, float y)
        {

            g.TranslateTransform(x, y);
            DrawGraphics(g);
            g.ResetTransform();

        }

    }
}
