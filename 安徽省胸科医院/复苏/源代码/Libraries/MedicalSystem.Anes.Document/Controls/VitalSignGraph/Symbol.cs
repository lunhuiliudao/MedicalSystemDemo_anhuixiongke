/*----------------------------------------------------------------
      // Copyright (C) 2005 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedSymbol.cs
      // 文件功能描述：符号类
      //
      // 
      // 创建标识：戴呈祥-2008-10-22
      // 修改标识：戴呈祥
----------------------------------------------------------------*/
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 符号类型
    /// </summary>
    [Serializable]
    public enum MedSymbolType
    {
        /// <summary>
        /// 矩形
        /// </summary>
        [Description("矩形")]
        Square,

        /// <summary>
        /// 钻石形
        /// </summary>
        [Description("钻石形")]
        Diamond,

        /// <summary>
        /// 三角形
        /// </summary>
        [Description("三角形")]
        Triangle,

        /// <summary>
        /// 圆形
        /// </summary>
        [Description("圆形")]
        Circle,

        /// <summary>
        /// 小圆形
        /// </summary>
        [Description("小圆形")]
        MiniCircle,

        /// <summary>
        /// 交叉线
        /// </summary>
        [Description("交叉线")]
        XCross,

        /// <summary>
        /// 交叉线
        /// </summary>
        [Description("交叉线竖线")]
        XCrossVLine,

        /// <summary>
        /// 加号
        /// </summary>
        [Description("加号")]
        Plus,

        /// <summary>
        /// 星形
        /// </summary>
        [Description("星形")]
        Star,

        /// <summary>
        /// 倒三角形
        /// </summary>
        [Description("倒三角形")]
        TriangleDown,

        /// <summary>
        /// 水平点
        /// </summary>
        [Description("水平点")]
        HDash,

        /// <summary>
        /// 垂直点
        /// </summary>
        [Description("垂直点")]
        VDash,

        /// <summary>
        /// 点
        /// </summary>
        [Description("点")]
        Point,

        /// <summary>
        /// 麻醉标识
        /// </summary>
        [Description("麻醉标识")]
        Anesthesia,

        /// <summary>
        /// 手术标识
        /// </summary>
        [Description("手术标识")]
        Operation,

        /// <summary>
        /// 置管
        /// </summary>
        [Description("置管")]
        PutPipe,
        /// <summary>
        /// 置管1
        /// </summary>
        [Description("置管1")]
        PutPipe1,
        /// <summary>
        /// 置管2
        /// </summary>
        [Description("置管2")]
        PutPipe2,
        /// <summary>
        /// 拔管
        /// </summary>
        [Description("拔管")]
        PullPipe,
        /// <summary>
        /// 拔管1
        /// </summary>
        [Description("拔管1")]
        PullPipe1,
        /// <summary>
        /// 倒V形
        /// </summary>
        [Description("倒V形")]
        VLetterDown,
        /// <summary>
        /// 倒V形
        /// </summary>
        [Description("倒V形竖线")]
        VLetterDownLine,

        /// <summary>
        /// V形
        /// </summary>
        [Description("V形")]
        VLetter,

        /// <summary>
        /// V形竖线
        /// </summary>
        [Description("V形竖线")]
        VLetterLine,

        /// <summary>
        /// 圆中点
        /// </summary>
        [Description("圆中点")]
        CircleDot,
        /// <summary>
        /// 小圆斜线
        /// </summary>
        [Description("小圆斜线")]
        MiniCircleLine,
        /// <summary>
        /// 实心圆
        /// </summary>
        [Description("实心圆")]
        FillCircle,
        /// <summary>
        /// 实心小圆
        /// </summary>
        [Description("实心小圆")]
        FillMiniCircle,
        /// <summary>
        /// 圆内加号
        /// </summary>
        [Description("圆内加号")]
        CirclePlus,

        /// <summary>
        /// 圆内交叉线
        /// </summary>
        [Description("圆内交叉线")]
        CircleXCross,

        /// <summary>
        /// 圆内水平箭头
        /// </summary>
        [Description("圆内水平箭头")]
        CircleHArrow,

        /// <summary>
        /// 圆内垂直箭头
        /// </summary>
        [Description("圆内垂直箭头")]
        CircleVArrow,

        /// <summary>
        /// 横线圆
        /// </summary>
        [Description("横线圆")]
        CircleHLine,

        /// <summary>
        /// 竖线圆
        /// </summary>
        [Description("竖线圆")]
        CircleVLine,

        /// <summary>
        /// 机械通气
        /// </summary>
        [Description("机械通气")]
        MachineAir,

        /// <summary>
        /// 文本
        /// </summary>
        [Description("文本")]
        Text,

        /// <summary>
        /// 图像
        /// </summary>
        [Description("图像")]
        Image,

        /// <summary>
        /// 圆里带X加四个点
        /// </summary>
        [Description("图像")]
        CircleXCrossDot,

        /// <summary>
        /// 矩形带横向箭头
        /// </summary>
        [Description("入手术室")]
        InOperationRoom,

        /// <summary>
        /// 矩形带横向箭头
        /// </summary>
        [Description("出手术室")]
        OutOperationRoom,

        /// <summary>
        /// 置入喉罩
        /// </summary>
        [Description("喉罩1")]
        InHouZhao,

        /// <summary>
        /// 拔出喉罩
        /// </summary>
        [Description("喉罩2")]
        OutHouZhao,

        /// <summary>
        /// 未定义
        /// </summary>
        [Description("未定义")]
        None
    }

    /// <summary>
    /// 符号类
    /// </summary>
    [Serializable]
    public class MedSymbol
    {

        #region 变量

        /// <summary>
        /// 符号类型
        /// </summary>
        private MedSymbolType _symboltype;

        /// <summary>
        /// 图片
        /// </summary>
        private System.Drawing.Image _image;

        private string _text;

        /// <summary>
        /// 画笔
        /// </summary>
        private System.Drawing.Pen _pen = new Pen(Color.Black);

        /// <summary>
        /// 画刷
        /// </summary>
        private System.Drawing.Brush _brush;

        /// <summary>
        /// 大小
        /// </summary>
        private float _size = 10;

        #endregion 变量

        #region 构造方法

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="image">图片</param>
        public MedSymbol(System.Drawing.Image image)
        {
            _symboltype = MedSymbolType.Image;
            Image = image;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="symboltype">符号类型</param>
        public MedSymbol(MedSymbolType symboltype)
        {
            _symboltype = symboltype;
        }

        #endregion 构造方法

        #region 属性

        /// <summary>
        /// 符号类型
        /// </summary>
        public MedSymbolType SymbolType
        {
            get
            {
                return _symboltype;
            }
            set
            {
                _symboltype = value;
            }
        }

        /// <summary>
        /// 图片
        /// </summary>
        public System.Drawing.Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _symboltype = MedSymbolType.Image;
                _image = value;
            }
        }

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }


        /// <summary>
        /// 画笔
        /// </summary>
        public System.Drawing.Pen Pen
        {
            get
            {
                return _pen;
            }
            set
            {
                _pen = value;
            }
        }

        /// <summary>
        /// 画刷
        /// </summary>
        public System.Drawing.Brush Brush
        {
            get
            {
                return _brush;
            }
            set
            {
                _brush = value;
            }
        }

        /// <summary>
        /// 大小
        /// </summary>
        public float Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }

        Font _font = new Font("宋体", 9);
        public Font Font
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
            }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 绘制符号
        /// </summary>
        /// <param name="g">作图对象</param>
        /// <param name="X">水平坐标</param>
        /// <param name="Y">垂直坐标</param>
        public void Draw(System.Drawing.Graphics g, float X, float Y)
        {
            ///绘制图片
            if (_symboltype == MedSymbolType.Image)
            {
                if (_image is Bitmap)
                {
                    (_image as Bitmap).MakeTransparent();
                }
                g.DrawImage(_image, new Rectangle((int)(X - _size / 2 - 1), (int)(Y - _size / 2 - 1), (int)_size + 2, (int)_size + 2));
            }
            else if (_symboltype == MedSymbolType.Text)
            {
                if (_text != null)
                {
                    g.DrawString(_text, _font, _pen.Brush, X - g.MeasureString(_text, _font).Width / 2, Y - g.MeasureString(_text, _font).Height / 2);
                }
            }
            ///绘制路径
            else if (_symboltype != MedSymbolType.None)
            {
                Matrix saveMatrix = g.Transform;
                g.TranslateTransform(X, Y);

                ///创建符号路径
                GraphicsPath path = MakePath(g);

                ///填充路径
                if (_brush != null)
                {
                    g.FillPath(_brush, path);
                }

                if (_symboltype == MedSymbolType.Point || _symboltype == MedSymbolType.FillCircle || _symboltype == MedSymbolType.FillMiniCircle)
                {
                    g.FillPath(new SolidBrush(_pen.Color), path);
                }
                else
                {
                    g.DrawPath(_pen, path);
                    if (_symboltype == MedSymbolType.CircleXCrossDot)
                    {
                        g.FillEllipse(Brushes.Black, -1f, 1 - _size / 2, 2f, 2f);
                        g.FillEllipse(Brushes.Black, -1f, _size / 2 - 3, 2f, 2f);
                        g.FillEllipse(Brushes.Black, _size / 2 - 3, -1f, 2f, 2f);
                        g.FillEllipse(Brushes.Black, 1 - _size / 2, -1f, 2f, 2f);
                    }
                }
                g.Transform = saveMatrix;
            }
        }

        /// <summary>
        /// 创建符号路径
        /// </summary>
        /// <param name="g">作图对象</param>
        /// <returns>路径</returns>
        public GraphicsPath MakePath(Graphics g)
        {
            float scaleFactor = 1;
            float scaledSize = (float)(_size * scaleFactor);
            float hsize = scaledSize / 2, hsize1 = hsize + 1;

            GraphicsPath path = new GraphicsPath();

            switch (_symboltype)
            {
                case MedSymbolType.Square:
                    path.AddLine(-hsize, -hsize, hsize, -hsize);
                    path.AddLine(hsize, -hsize, hsize, hsize);
                    path.AddLine(hsize, hsize, -hsize, hsize);
                    path.AddLine(-hsize, hsize, -hsize, -hsize);
                    break;

                case MedSymbolType.Diamond:
                    path.AddLine(0, -hsize, hsize, 0);
                    path.AddLine(hsize, 0, 0, hsize);
                    path.AddLine(0, hsize, -hsize, 0);
                    path.AddLine(-hsize, 0, 0, -hsize);
                    break;
                case MedSymbolType.Triangle:
                    path.AddLine(0, -hsize, hsize, hsize);
                    path.AddLine(hsize, hsize, -hsize, hsize);
                    path.AddLine(-hsize, hsize, 0, -hsize);
                    break;
                case MedSymbolType.VLetterDown:
                    path.AddLine(0, -hsize, hsize, hsize);
                    path.StartFigure();
                    path.AddLine(-hsize, hsize, 0, -hsize);
                    break;
                case MedSymbolType.VLetterDownLine:
                    path.AddLine(0, -hsize, hsize, hsize);
                    path.StartFigure();
                    path.AddLine(-hsize, hsize, 0, -hsize);
                    path.StartFigure();
                    path.AddLine(0, hsize, 0, -hsize);
                    break;
                case MedSymbolType.Circle:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    break;
                case MedSymbolType.MiniCircle:
                    path.AddEllipse(-hsize / 2, -hsize / 2, hsize, hsize);
                    break;
                case MedSymbolType.MiniCircleLine:
                    path.AddEllipse(-hsize / 2, -hsize / 2, hsize, hsize);
                    path.StartFigure();
                    path.AddLine(-2, -2 - hsize, 2 + hsize, 2);
                    break;
                case MedSymbolType.FillCircle:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    break;
                case MedSymbolType.FillMiniCircle:
                    path.AddEllipse(-hsize / 2, -hsize / 2, hsize, hsize);
                    break;
                case MedSymbolType.CircleDot:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(0, -1, 0, 1);
                    path.StartFigure();
                    path.AddLine(-1, 0, 1, 0);
                    break;
                case MedSymbolType.CircleHLine:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(-hsize - 2, 0, hsize + 2, 0);
                    break;
                case MedSymbolType.CircleVLine:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(0, -hsize - 2, 0, hsize + 2);
                    break;
                case MedSymbolType.CirclePlus:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(0, -hsize + 1, 0, hsize - 1);
                    path.StartFigure();
                    path.AddLine(-hsize + 1, 0, hsize - 1, 0);
                    break;

                case MedSymbolType.CircleVArrow:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(0, -hsize + 1, 0, hsize - 1);
                    path.AddLine(0, hsize - 1, -2, 0);
                    path.StartFigure();
                    path.AddLine(0, hsize - 1, 2, 0);
                    break;
                case MedSymbolType.CircleHArrow:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(-hsize + 1, 0, hsize - 1, 0);
                    path.AddLine(hsize - 1, 0, 0, -2);
                    path.StartFigure();
                    path.AddLine(hsize - 1, 0, 0, 2);
                    break;

                case MedSymbolType.InOperationRoom:
                    path.AddLine(-hsize, -hsize, hsize, -hsize);
                    path.AddLine(hsize, -hsize, hsize, hsize);
                    path.AddLine(hsize, hsize, -hsize, hsize);
                    path.StartFigure();
                    path.AddLine(-hsize, 0, hsize - 1, 0);
                    path.AddLine(hsize, 0, 0, -2);
                    path.StartFigure();
                    path.AddLine(hsize, 0, 0, 2);
                    break;
                case MedSymbolType.OutOperationRoom:
                    path.AddLine(-hsize, -hsize, hsize, -hsize);
                    path.AddLine(hsize, hsize, -hsize, hsize);
                    path.AddLine(-hsize, hsize, -hsize, -hsize);
                    path.StartFigure();
                    path.AddLine(-hsize + 1, 0, hsize, 0);
                    path.AddLine(hsize, 0, 0, -2);
                    path.StartFigure();
                    path.AddLine(hsize, 0, 0, 2);
                    break;

                case MedSymbolType.MachineAir:
                    hsize = hsize * 2 / 2.5f;
                    path.AddLine(-hsize * 2, hsize, -hsize, -hsize);
                    path.AddLine(-hsize, -hsize, 0, hsize);
                    path.AddLine(0, hsize, hsize, -hsize);
                    path.AddLine(hsize, -hsize, hsize * 2, hsize);
                    path.AddLine(hsize * 2, hsize, hsize * 3, -hsize);
                    break;
                case MedSymbolType.CircleXCross:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(-hsize + 1, -hsize + 1, hsize - 1, hsize - 1);
                    path.StartFigure();
                    path.AddLine(hsize - 1, -hsize + 1, -hsize + 1, hsize - 1);
                    break;
                case MedSymbolType.CircleXCrossDot:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(-hsize + 1, -hsize + 1, hsize - 1, hsize - 1);
                    path.StartFigure();
                    path.AddLine(hsize - 1, -hsize + 1, -hsize + 1, hsize - 1);
                    break;
                case MedSymbolType.XCross:
                    path.AddLine(-hsize, -hsize, hsize, hsize);
                    path.StartFigure();
                    path.AddLine(hsize, -hsize, -hsize, hsize);
                    break;
                case MedSymbolType.XCrossVLine:
                    path.AddLine(-hsize, -hsize, hsize, hsize);
                    path.StartFigure();
                    path.AddLine(hsize, -hsize, -hsize, hsize);
                    path.StartFigure();
                    path.AddLine(0, -1 - hsize, 0, hsize + 1);
                    break;
                case MedSymbolType.Plus:
                    path.AddLine(0, -hsize, 0, hsize1);
                    path.StartFigure();
                    path.AddLine(-hsize, 0, hsize1, 0);
                    break;
                case MedSymbolType.Star:
                    path.AddLine(0, -hsize, 0, hsize);
                    path.StartFigure();
                    path.AddLine(-hsize, 0, hsize, 0);
                    path.StartFigure();
                    path.AddLine(-hsize, -hsize, hsize, hsize);
                    path.StartFigure();
                    path.AddLine(hsize, -hsize, -hsize, hsize);
                    break;
                case MedSymbolType.TriangleDown:
                    path.AddLine(0, hsize, hsize, -hsize);
                    path.AddLine(hsize, -hsize, -hsize, -hsize);
                    path.AddLine(-hsize, -hsize, 0, hsize);
                    break;
                case MedSymbolType.VLetter:
                    path.AddLine(0, hsize, hsize, -hsize);
                    path.StartFigure();
                    path.AddLine(-hsize, -hsize, 0, hsize);
                    break;
                case MedSymbolType.VLetterLine:
                    path.AddLine(0, hsize, hsize, -hsize);
                    path.StartFigure();
                    path.AddLine(-hsize, -hsize, 0, hsize);
                    path.StartFigure();
                    path.AddLine(0, -hsize, 0, hsize);
                    break;
                case MedSymbolType.HDash:
                    path.AddLine(-hsize, 0, hsize1, 0);
                    break;
                case MedSymbolType.VDash:
                    path.AddLine(0, -hsize, 0, hsize1);
                    break;
                case MedSymbolType.Point:
                    path.AddEllipse(-hsize / 1.5f, -hsize / 1.5f, scaledSize / 1.5f, scaledSize / 1.5f);
                    break;
                case MedSymbolType.Anesthesia:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(-hsize + 2, -hsize + 2, hsize1 - 2, hsize1 - 2);
                    path.StartFigure();
                    path.AddLine(hsize - 2, -hsize + 2, -hsize1 + 2, hsize1 - 2);
                    break;
                case MedSymbolType.Operation:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(-hsize + 2, 0, hsize - 2, 0);
                    break;
                case MedSymbolType.PutPipe:
                    path.AddEllipse(-hsize, -hsize + 2, scaledSize, scaledSize * .6f);
                    path.StartFigure();
                    path.AddLine(0, -hsize1, 0, hsize1);
                    path.StartFigure();
                    path.AddLine(-2, hsize1, 2, hsize1);
                    path.StartFigure();
                    path.AddLine(-2, -hsize1, 2, -hsize1);
                    break;
                case MedSymbolType.PutPipe1:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(hsize, -hsize, -hsize, hsize);
                    break;
                case MedSymbolType.PutPipe2:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(-hsize, -hsize, hsize, hsize);
                    break;
                case MedSymbolType.PullPipe:
                    path.AddEllipse(-hsize + 2, -hsize, scaledSize * .6f, scaledSize);
                    path.StartFigure();
                    path.AddLine(-hsize1, 0, hsize1, 0);
                    path.StartFigure();
                    path.AddLine(hsize1, -2, hsize1, 2);
                    path.StartFigure();
                    path.AddLine(-hsize1, -2, -hsize1, 2);
                    break;
                case MedSymbolType.PullPipe1:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(0, -hsize1, 0, hsize1);
                    break;
                case MedSymbolType.OutHouZhao:
                    path.AddEllipse(-hsize, -hsize, scaledSize - 3, scaledSize - 3);
                    path.StartFigure();
                    path.AddEllipse(-hsize - 3, -hsize - 3, scaledSize + 3, scaledSize + 3);
                    path.StartFigure();
                    path.AddLine(-1, -hsize1 - 3, -1, hsize1 + 2);
                    break;
                case MedSymbolType.InHouZhao:
                    path.AddEllipse(-hsize, -hsize, scaledSize - 3, scaledSize - 3);
                    path.StartFigure();
                    path.AddEllipse(-hsize - 3, -hsize - 3, scaledSize + 3, scaledSize + 3);
                    path.StartFigure();
                    path.AddLine(-hsize - 2, -1, hsize + 1, -1);
                    break;
            }

            return path;
        }

        #endregion 方法
    }
}
