/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：AnesBand.cs
      // 文件功能描述：麻醉单区域基类
      //
      // 
      // 创建标识：戴呈祥-2008-11-11
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 边框类型
    /// </summary>
    [Serializable]
    public enum BorderType
    {
        /// <summary>
        /// 矩形
        /// </summary>
        [Description("矩形")]
        Rectangle,
        /// <summary>
        /// 无顶矩形
        /// </summary>
        [Description("无顶矩形")]
        NoTop,
        /// <summary>
        /// 无底矩形
        /// </summary>
        [Description("无底矩形")]
        NoBottom,
        /// <summary>
        /// 右下线
        /// </summary>
        [Description("右下线")]
        RightBottom,
        /// <summary>
        /// 左右线
        /// </summary>
        [Description("左右线")]
        LeftRight,
        /// <summary>
        /// 左线
        /// </summary>
        [Description("左线")]
        OnlyLeft,
        /// <summary>
        /// 右线
        /// </summary>
        [Description("右线")]
        OnlyRight,
        /// <summary>
        /// 顶线
        /// </summary>
        [Description("顶线")]
        OnlyTop,
        /// <summary>
        /// 底线
        /// </summary>
        [Description("底线")]
        OnlyBottom,
        /// <summary>
        /// 左偏移左右线
        /// </summary>
        [Description("左偏移左右线")]
        LeftRightMoveLeft,
        /// <summary>
        /// 右偏移左右线
        /// </summary>
        [Description("右偏移左右线")]
        LeftRightMoveRight,
        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        None,
        [Description("左上线")]
        LeftTop,
        [Description("左下线")]
        LeftBottom,
        [Description("右上线")]
        RightTop,
        [Description("上下线")]
        TopBottom,
        [Description("左上下线")]
        LeftTopBottom,
        [Description("右上下线")]
        RightTopBottom,
        [Description("左下右线")]
        LeftBottomRight,
        [Description("左上右线")]
        LeftTopRight


    }


    /// <summary>
    /// 麻醉单区域基类
    /// </summary>
    [Serializable,ToolboxItem(false)]
    public partial class AnesBand : UserControl
    {
        #region 构造方法

        public AnesBand()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        #endregion 构造方法

        #region 事件接口

        public delegate void AnesBandEventHandle(AnesBand sender,object selectObject,EventArgs e); 

        protected static readonly object _customEditEventHandle = new object();

        /// <summary>
        /// 自定义编辑事件
        /// </summary>
        [Description("自定义编辑事件")]
        public event AnesBandEventHandle CustomEdit
        {
            add
            {
                Events.AddHandler(_customEditEventHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_customEditEventHandle, value);
            }
        }

        #endregion 事件接口

        #region 变量

        protected int _backHeight = -1;
        public int BackHeight
        {
            get
            {
                return _backHeight;
            }
            set
            {
                _backHeight = value;
            }
        }

        protected float _showZoomRate = 1f;
        [Browsable(false)]
        public float ShowZoomRate
        {
            get
            {
                return _showZoomRate;
            }
            set
            {
                _showZoomRate = value;
            }
        }

        protected bool _printing = false;
        /// <summary>
        /// 缩放比率
        /// </summary>
        protected float _scaleRate = 1;

        /// <summary>
        /// 原始作图宽度
        /// </summary>
        private float _originWidth = 100;

        /// <summary>
        /// 原始作图高度
        /// </summary>
        private float _originHeight = 100;

        /// <summary>
        /// 边框颜色
        /// </summary>
        protected Color _borderColor = Color.Red;

        /// <summary>
        /// 刻度值颜色
        /// </summary>
        protected Color _scaleValueColor = Color.Red;

        /// <summary>
        /// 是否画边框
        /// </summary>
        protected bool _drawBorder = true;

        /// <summary>
        /// 边框宽度
        /// </summary>
        protected int _borderWidth = 1;

        protected BorderType _borderType = BorderType.Rectangle;

        #endregion 变量

        #region 属性

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
        /// 是否画边框
        /// </summary>
        [Category("数据-自定义"), DisplayName("边框")]
        public bool DrawBorder
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

        /// <summary>
        /// 刻度值颜色
        /// </summary>
        [Category("数据-自定义"), DisplayName("刻度值颜色")]
        public Color ScaleValueColor
        {
            get
            {
                return _scaleValueColor;
            }
            set
            {
                _scaleValueColor = value;
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
                _scaleValueColor = value;
            }
        }

        private bool _noChangeHeight = false;
        [Category("数据-自定义"), DisplayName("不改变高度")]
        public bool NoChangeHeight
        {
            get
            {
                return _noChangeHeight;
            }
            set
            {
                _noChangeHeight = value;
                if (_noChangeHeight)
                {
                    //Height = _oldHeight;
                }
            }
        }

        private int _oldHeight = 100;
        /// <summary>
        /// 缩放比率
        /// </summary>
        public float ScaleRate
        {
            get
            {
                return _scaleRate;
            }
            set
            {
                _scaleRate = value;
                if (_noChangeHeight)
                {
                }
                else
                {
                    _oldHeight = Height;
                    //Height = (int)(_scaleRate * _originHeight);
                }
                //Invalidate();
            }
        }

        /// <summary>
        /// 原始作图宽度
        /// </summary>
        [Category("数据-自定义"), DisplayName("原始作图宽度"), Browsable(false)]
        public float OriginWidth
        {
            get
            {
                return _originWidth;
            }
            set
            {
                _originWidth = value;
            }
        }

        /// <summary>
        /// 原始作图高度
        /// </summary>
        [Category("数据-自定义"), DisplayName("原始作图高度"), Browsable(false)]
        public float OriginHeight
        {
            get
            {
                return _originHeight;
            }
            set
            {
                _originHeight = value;
            }
        }

        private int _rightRetainWidth = 0;
        [Category("数据-自定义"), DisplayName("右侧留存宽度")]
        public int RightRetainWidth
        {
            get { return _rightRetainWidth; }
            set { _rightRetainWidth = value; }
        }

        protected float _zoomRate = 1;

        [Category("数据-自定义"), DisplayName("原始作图矩形"), Browsable(false)]
        public Rectangle OriginRect
        {
            get
            {
                Rectangle rect = ClientRectangle;
               // return new Rectangle((int)(rect.X * _zoomRate), (int)(rect.Y * _zoomRate), (int)(980 * _zoomRate) - _rightRetainWidth, (int)(rect.Height * _zoomRate));
                return new Rectangle((int)(rect.X * _zoomRate),(int)(rect.Y * _zoomRate),(int)(rect.Width * _zoomRate)-_rightRetainWidth,(int)(rect.Height * _zoomRate));
                //float width = _originWidth;
                //if (width < Width / 2) width = Width;
                //float height = _originHeight;
                //if (height < Height / 2) height = Height;
                //return new Rectangle(0, 0, (int)width, (int)height);
            }
        }

        #endregion 属性

        #region 方法

        protected Metafile GetMetafile(string fileName, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bmp);
            Rectangle rect = new Rectangle(0, 0, width, height);
            Metafile metafile = new Metafile(fileName, graphics.GetHdc(), rect, MetafileFrameUnit.Pixel);
            graphics.Dispose();
            return metafile;
        }

        protected void GetMetafile()
        {
            _zoomRate = 2;
            Metafile metafile = GetMetafile(@"c:\test.wmf", Width, Height);
            Graphics g = Graphics.FromImage(metafile);
            DrawGraphics(g);
            g.Save();
            g.Dispose();
            metafile.Dispose();
            _zoomRate = 1;
        }

        /// <summary>
        /// 绘制控件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.ResetTransform();
            ///等比缩放
            e.Graphics.ScaleTransform(_scaleRate, _scaleRate);
            //e.Graphics.ScaleTransform(0.8f, 1f);
            DrawGraphics(e.Graphics);
        }

        /// <summary>
        /// 画边框
        /// </summary>
        protected virtual void DoDrawBorder(Graphics g)
        {
            if (_drawBorder && _borderType != BorderType.None)
            {
                Rectangle rect = OriginRect;
                rect.Width += -1;
                rect.Height += -1;
                //rect.X += 1;
                g.FillRectangle(new SolidBrush(BackColor), rect);
                Pen P = new Pen(_borderColor,_borderWidth);
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
                        g.DrawLine(P, rect.Right-1, rect.Top, rect.Right-1, rect.Bottom);
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
        /// 重画区域-子类应该重写该方法
        /// </summary>
        /// <param name="g"></param>
        public virtual void DrawGraphics(Graphics g)
        {
            DoDrawBorder(g);
        }

        #endregion 方法
    }
}
