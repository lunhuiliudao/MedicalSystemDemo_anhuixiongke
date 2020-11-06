/*----------------------------------------------------------------
      // Copyright (C) 2008 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����AnesBand.cs
      // �ļ����������������������
      //
      // 
      // ������ʶ��������-2008-11-11
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
    /// �߿�����
    /// </summary>
    [Serializable]
    public enum BorderType
    {
        /// <summary>
        /// ����
        /// </summary>
        [Description("����")]
        Rectangle,
        /// <summary>
        /// �޶�����
        /// </summary>
        [Description("�޶�����")]
        NoTop,
        /// <summary>
        /// �޵׾���
        /// </summary>
        [Description("�޵׾���")]
        NoBottom,
        /// <summary>
        /// ������
        /// </summary>
        [Description("������")]
        RightBottom,
        /// <summary>
        /// ������
        /// </summary>
        [Description("������")]
        LeftRight,
        /// <summary>
        /// ����
        /// </summary>
        [Description("����")]
        OnlyLeft,
        /// <summary>
        /// ����
        /// </summary>
        [Description("����")]
        OnlyRight,
        /// <summary>
        /// ����
        /// </summary>
        [Description("����")]
        OnlyTop,
        /// <summary>
        /// ����
        /// </summary>
        [Description("����")]
        OnlyBottom,
        /// <summary>
        /// ��ƫ��������
        /// </summary>
        [Description("��ƫ��������")]
        LeftRightMoveLeft,
        /// <summary>
        /// ��ƫ��������
        /// </summary>
        [Description("��ƫ��������")]
        LeftRightMoveRight,
        /// <summary>
        /// ��
        /// </summary>
        [Description("��")]
        None,
        [Description("������")]
        LeftTop,
        [Description("������")]
        LeftBottom,
        [Description("������")]
        RightTop,
        [Description("������")]
        TopBottom,
        [Description("��������")]
        LeftTopBottom,
        [Description("��������")]
        RightTopBottom,
        [Description("��������")]
        LeftBottomRight,
        [Description("��������")]
        LeftTopRight


    }


    /// <summary>
    /// �����������
    /// </summary>
    [Serializable,ToolboxItem(false)]
    public partial class AnesBand : UserControl
    {
        #region ���췽��

        public AnesBand()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        #endregion ���췽��

        #region �¼��ӿ�

        public delegate void AnesBandEventHandle(AnesBand sender,object selectObject,EventArgs e); 

        protected static readonly object _customEditEventHandle = new object();

        /// <summary>
        /// �Զ���༭�¼�
        /// </summary>
        [Description("�Զ���༭�¼�")]
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

        #endregion �¼��ӿ�

        #region ����

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
        /// ���ű���
        /// </summary>
        protected float _scaleRate = 1;

        /// <summary>
        /// ԭʼ��ͼ���
        /// </summary>
        private float _originWidth = 100;

        /// <summary>
        /// ԭʼ��ͼ�߶�
        /// </summary>
        private float _originHeight = 100;

        /// <summary>
        /// �߿���ɫ
        /// </summary>
        protected Color _borderColor = Color.Red;

        /// <summary>
        /// �̶�ֵ��ɫ
        /// </summary>
        protected Color _scaleValueColor = Color.Red;

        /// <summary>
        /// �Ƿ񻭱߿�
        /// </summary>
        protected bool _drawBorder = true;

        /// <summary>
        /// �߿���
        /// </summary>
        protected int _borderWidth = 1;

        protected BorderType _borderType = BorderType.Rectangle;

        #endregion ����

        #region ����

        [Category("����-�Զ���"), DisplayName("�߿�����")]
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
        /// �߿���
        /// </summary>
        [Category("����-�Զ���"), DisplayName("�߿���")]
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
        /// �Ƿ񻭱߿�
        /// </summary>
        [Category("����-�Զ���"), DisplayName("�߿�")]
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
        /// �̶�ֵ��ɫ
        /// </summary>
        [Category("����-�Զ���"), DisplayName("�̶�ֵ��ɫ")]
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
        /// �߿���ɫ
        /// </summary>
        [Category("����-�Զ���"), DisplayName("�߿���ɫ")]
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
        [Category("����-�Զ���"), DisplayName("���ı�߶�")]
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
        /// ���ű���
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
        /// ԭʼ��ͼ���
        /// </summary>
        [Category("����-�Զ���"), DisplayName("ԭʼ��ͼ���"), Browsable(false)]
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
        /// ԭʼ��ͼ�߶�
        /// </summary>
        [Category("����-�Զ���"), DisplayName("ԭʼ��ͼ�߶�"), Browsable(false)]
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
        [Category("����-�Զ���"), DisplayName("�Ҳ�������")]
        public int RightRetainWidth
        {
            get { return _rightRetainWidth; }
            set { _rightRetainWidth = value; }
        }

        protected float _zoomRate = 1;

        [Category("����-�Զ���"), DisplayName("ԭʼ��ͼ����"), Browsable(false)]
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

        #endregion ����

        #region ����

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
        /// ���ƿؼ�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.ResetTransform();
            ///�ȱ�����
            e.Graphics.ScaleTransform(_scaleRate, _scaleRate);
            //e.Graphics.ScaleTransform(0.8f, 1f);
            DrawGraphics(e.Graphics);
        }

        /// <summary>
        /// ���߿�
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
        /// �ػ�����-����Ӧ����д�÷���
        /// </summary>
        /// <param name="g"></param>
        public virtual void DrawGraphics(Graphics g)
        {
            DoDrawBorder(g);
        }

        #endregion ����
    }
}
