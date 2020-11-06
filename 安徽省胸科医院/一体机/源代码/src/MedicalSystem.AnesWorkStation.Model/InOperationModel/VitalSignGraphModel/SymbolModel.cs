// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      SymbolModel.cs
// 功能描述(Description)：    图标的实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MedicalSystem.AnesWorkStation.Model.InOperationModel
{
    /// <summary>
    /// 图标类型枚举
    /// </summary>
    public enum SymbolType
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
        /// 未定义
        /// </summary>
        [Description("未定义")]
        None,

        /// <summary>
        /// 圆中圆(扩展)
        /// </summary>
        Ext_CircleInCircle = 900,

        /// <summary>
        /// 实心圆(扩展)
        /// </summary>
        Ext_FillCircle = 901,

        /// <summary>
        /// 三角叉
        /// </summary>
        Ext_Breath = 902,

        /// <summary>
        /// 倒三角（扩展）
        /// </summary>
        Ext_TriangleDown = 903,

        /// <summary>
        /// 正方形
        /// </summary>
        CustomRectangle = 9999
    }

    /// <summary>
    /// 图标实体类
    /// </summary>
    [Serializable]
    public class SymbolModel : ObservableObject
    {
        private SymbolType _symboltype;                                           // 图标类型
        private System.Drawing.Image _image;                                      // 图标图标，针对图标是图片类型
        private string _text;                                                     // 图标对应的文本信息
        private System.Drawing.Pen _pen = new Pen(Color.Black);                   // 画笔
        private System.Drawing.Brush _brush;                                      // 画刷
        private float _size = 10;                                                 // 图标大小
        private Font _font = new Font("宋体", 9);                                 // 图标文本信息的字体

        /// <summary>
        /// 符号类型
        /// </summary>
        public SymbolType SymbolType
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
        /// 图片，默认图标类型为图片类型
        /// </summary>
        public System.Drawing.Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _symboltype = SymbolType.Image;
                _image = value;
            }
        }

        /// <summary>
        /// 图标对应的文本信息
        /// </summary>
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

        /// <summary>
        /// 图标文本信息的字体
        /// </summary>
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

        /// <summary>
        /// 有参构造：设置图片作为图标
        /// </summary>
        /// <param name="image">图片</param>
        public SymbolModel(System.Drawing.Image image)
        {
            _symboltype = SymbolType.Image;
            Image = image;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="symboltype">符号类型</param>
        public SymbolModel(SymbolType symboltype)
        {
            _symboltype = symboltype;
        }

        /// <summary>
        /// 绘制符号
        /// </summary>
        /// <param name="g">作图对象</param>
        /// <param name="X">水平坐标</param>
        /// <param name="Y">垂直坐标</param>
        public void Draw(System.Drawing.Graphics g, float X, float Y)
        {
            if (_symboltype == SymbolType.Image) // 图片类型
            {
                if (_image is Bitmap)
                {
                    (_image as Bitmap).MakeTransparent();
                }

                g.DrawImage(_image, new Rectangle((int)(X - _size / 2 - 1), (int)(Y - _size / 2 - 1), (int)_size + 2, (int)_size + 2));
            }
            else if (_symboltype == SymbolType.Text) // 文本类型
            {
                if (_text != null)
                {
                    g.DrawString(_text, _font, _pen.Brush, X - g.MeasureString(_text, _font).Width / 2, Y - g.MeasureString(_text, _font).Height / 2);
                }
            }
            else if (_symboltype != SymbolType.None) // 其他类型，各种特殊符号
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

                if (_symboltype == SymbolType.Point || _symboltype == SymbolType.FillCircle || _symboltype == SymbolType.FillMiniCircle)
                {
                    g.FillPath(new SolidBrush(_pen.Color), path);
                }
                else
                {
                    g.DrawPath(_pen, path);
                    if (_symboltype == SymbolType.CircleXCrossDot)
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
                case SymbolType.Square:
                    path.AddLine(-hsize, -hsize, hsize, -hsize);
                    path.AddLine(hsize, -hsize, hsize, hsize);
                    path.AddLine(hsize, hsize, -hsize, hsize);
                    path.AddLine(-hsize, hsize, -hsize, -hsize);
                    break;
                case SymbolType.Diamond:
                    path.AddLine(0, -hsize, hsize, 0);
                    path.AddLine(hsize, 0, 0, hsize);
                    path.AddLine(0, hsize, -hsize, 0);
                    path.AddLine(-hsize, 0, 0, -hsize);
                    break;
                case SymbolType.Triangle:
                    path.AddLine(0, -hsize, hsize, hsize);
                    path.AddLine(hsize, hsize, -hsize, hsize);
                    path.AddLine(-hsize, hsize, 0, -hsize);
                    break;
                case SymbolType.VLetterDown:
                    path.AddLine(0, -hsize, hsize, hsize);
                    path.StartFigure();
                    path.AddLine(-hsize, hsize, 0, -hsize);
                    break;
                case SymbolType.VLetterDownLine:
                    path.AddLine(0, -hsize, hsize, hsize);
                    path.StartFigure();
                    path.AddLine(-hsize, hsize, 0, -hsize);
                    path.StartFigure();
                    path.AddLine(0, hsize, 0, -hsize);
                    break;
                case SymbolType.Circle:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    break;
                case SymbolType.MiniCircle:
                    path.AddEllipse(-hsize / 2, -hsize / 2, hsize, hsize);
                    break;
                case SymbolType.MiniCircleLine:
                    path.AddEllipse(-hsize / 2, -hsize / 2, hsize, hsize);
                    path.StartFigure();
                    path.AddLine(-2, -2 - hsize, 2 + hsize, 2);
                    break;
                case SymbolType.FillCircle:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    break;
                case SymbolType.FillMiniCircle:
                    path.AddEllipse(-hsize / 2, -hsize / 2, hsize, hsize);
                    break;
                case SymbolType.CircleDot:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(0, -1, 0, 1);
                    path.StartFigure();
                    path.AddLine(-1, 0, 1, 0);
                    break;
                case SymbolType.CircleHLine:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(-hsize - 2, 0, hsize + 2, 0);
                    break;
                case SymbolType.CircleVLine:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(0, -hsize - 2, 0, hsize + 2);
                    break;
                case SymbolType.CirclePlus:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(0, -hsize + 1, 0, hsize - 1);
                    path.StartFigure();
                    path.AddLine(-hsize + 1, 0, hsize - 1, 0);
                    break;
                case SymbolType.InOperationRoom:
                    path.AddLine(-hsize, -hsize, hsize, -hsize);
                    path.AddLine(hsize, -hsize, hsize, hsize);
                    path.AddLine(hsize, hsize, -hsize, hsize);
                    path.StartFigure();
                    path.AddLine(-hsize, 0, hsize - 1, 0);
                    path.AddLine(hsize, 0, 0, -2);
                    path.StartFigure();
                    path.AddLine(hsize, 0, 0, 2);
                    break;
                case SymbolType.OutOperationRoom:
                    path.AddLine(-hsize, -hsize, hsize, -hsize);
                    path.AddLine(hsize, hsize, -hsize, hsize);
                    path.AddLine(-hsize, hsize, -hsize, -hsize);
                    path.StartFigure();
                    path.AddLine(-hsize + 1, 0, hsize, 0);
                    path.AddLine(hsize, 0, 0, -2);
                    path.StartFigure();
                    path.AddLine(hsize, 0, 0, 2);
                    break;
                case SymbolType.CircleVArrow:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(0, -hsize + 1, 0, hsize - 1);
                    path.AddLine(0, hsize - 1, -2, 0);
                    path.StartFigure();
                    path.AddLine(0, hsize - 1, 2, 0);
                    break;
                case SymbolType.CircleHArrow:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(-hsize + 1, 0, hsize - 1, 0);
                    path.AddLine(hsize - 1, 0, 0, -2);
                    path.StartFigure();
                    path.AddLine(hsize - 1, 0, 0, 2);
                    break;
                case SymbolType.MachineAir:
                    hsize = hsize * 2 / 2.5f;
                    path.AddLine(-hsize * 2, hsize, -hsize, -hsize);
                    path.AddLine(-hsize, -hsize, 0, hsize);
                    path.AddLine(0, hsize, hsize, -hsize);
                    path.AddLine(hsize, -hsize, hsize * 2, hsize);
                    path.AddLine(hsize * 2, hsize, hsize * 3, -hsize);
                    break;
                case SymbolType.CircleXCross:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(-hsize + 1, -hsize + 1, hsize - 1, hsize - 1);
                    path.StartFigure();
                    path.AddLine(hsize - 1, -hsize + 1, -hsize + 1, hsize - 1);
                    break;
                case SymbolType.CircleXCrossDot:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(-hsize + 1, -hsize + 1, hsize - 1, hsize - 1);
                    path.StartFigure();
                    path.AddLine(hsize - 1, -hsize + 1, -hsize + 1, hsize - 1);
                    break;
                case SymbolType.XCross:
                    path.AddLine(-hsize, -hsize, hsize, hsize);
                    path.StartFigure();
                    path.AddLine(hsize, -hsize, -hsize, hsize);
                    break;
                case SymbolType.XCrossVLine:
                    path.AddLine(-hsize, -hsize, hsize, hsize);
                    path.StartFigure();
                    path.AddLine(hsize, -hsize, -hsize, hsize);
                    path.StartFigure();
                    path.AddLine(0, -1 - hsize, 0, hsize + 1);
                    break;
                case SymbolType.Plus:
                    path.AddLine(0, -hsize, 0, hsize1);
                    path.StartFigure();
                    path.AddLine(-hsize, 0, hsize1, 0);
                    break;
                case SymbolType.Star:
                    path.AddLine(0, -hsize, 0, hsize);
                    path.StartFigure();
                    path.AddLine(-hsize, 0, hsize, 0);
                    path.StartFigure();
                    path.AddLine(-hsize, -hsize, hsize, hsize);
                    path.StartFigure();
                    path.AddLine(hsize, -hsize, -hsize, hsize);
                    break;
                case SymbolType.TriangleDown:
                    path.AddLine(0, hsize, hsize, -hsize);
                    path.AddLine(hsize, -hsize, -hsize, -hsize);
                    path.AddLine(-hsize, -hsize, 0, hsize);
                    break;
                case SymbolType.VLetter:
                    path.AddLine(0, hsize, hsize, -hsize);
                    path.StartFigure();
                    path.AddLine(-hsize, -hsize, 0, hsize);
                    break;
                case SymbolType.VLetterLine:
                    path.AddLine(0, hsize, hsize, -hsize);
                    path.StartFigure();
                    path.AddLine(-hsize, -hsize, 0, hsize);
                    path.StartFigure();
                    path.AddLine(0, -hsize, 0, hsize);
                    break;
                case SymbolType.HDash:
                    path.AddLine(-hsize, 0, hsize1, 0);
                    break;
                case SymbolType.VDash:
                    path.AddLine(0, -hsize, 0, hsize1);
                    break;
                case SymbolType.Point:
                    path.AddEllipse(-hsize / 1.5f, -hsize / 1.5f, scaledSize / 1.5f, scaledSize / 1.5f);
                    break;
                case SymbolType.Anesthesia:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(-hsize + 2, -hsize + 2, hsize1 - 2, hsize1 - 2);
                    path.StartFigure();
                    path.AddLine(hsize - 2, -hsize + 2, -hsize1 + 2, hsize1 - 2);
                    break;
                case SymbolType.Operation:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(-hsize + 2, 0, hsize - 2, 0);
                    break;
                case SymbolType.PutPipe:
                    path.AddEllipse(-hsize, -hsize + 2, scaledSize, scaledSize * .6f);
                    path.StartFigure();
                    path.AddLine(0, -hsize1, 0, hsize1);
                    path.StartFigure();
                    path.AddLine(-2, hsize1, 2, hsize1);
                    path.StartFigure();
                    path.AddLine(-2, -hsize1, 2, -hsize1);
                    break;
                case SymbolType.PutPipe1:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(hsize, -hsize, -hsize, hsize);
                    break;
                case SymbolType.PutPipe2:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(-hsize, -hsize, hsize, hsize);
                    break;
                case SymbolType.PullPipe:
                    path.AddEllipse(-hsize + 2, -hsize, scaledSize * .6f, scaledSize);
                    path.StartFigure();
                    path.AddLine(-hsize1, 0, hsize1, 0);
                    path.StartFigure();
                    path.AddLine(hsize1, -2, hsize1, 2);
                    path.StartFigure();
                    path.AddLine(-hsize1, -2, -hsize1, 2);
                    break;
                case SymbolType.PullPipe1:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    path.StartFigure();
                    path.AddLine(0, -hsize1, 0, hsize1);
                    break;
            }

            return path;
        }
    }
}
