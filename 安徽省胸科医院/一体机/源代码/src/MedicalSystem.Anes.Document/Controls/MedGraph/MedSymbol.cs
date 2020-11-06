using System;
/*----------------------------------------------------------------
      // Copyright (C) 2005 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedSymbol.cs
      // 文件功能描述：符号类
      //
      // 
      // 创建标识：戴呈祥
      // 修改标识：戴呈祥-2008-02-26
      // 修改描述：添加注释
----------------------------------------------------------------*/
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 符号类型
    /// </summary>
    public enum MedSymbolTypeICU
    {
        /// <summary>
        /// 矩形
        /// </summary>
        Square,

        /// <summary>
        /// 钻石形
        /// </summary>
        Diamond,

        /// <summary>
        /// 三角形
        /// </summary>
        Triangle,

        /// <summary>
        /// 圆形
        /// </summary>
        Circle,

        /// <summary>
        /// 交叉线
        /// </summary>
        XCross,

        /// <summary>
        /// 加号
        /// </summary>
        Plus,

        /// <summary>
        /// 星形
        /// </summary>
        Star,

        /// <summary>
        /// 倒三角形
        /// </summary>
        TriangleDown,

        /// <summary>
        /// 水平点
        /// </summary>
        HDash,

        /// <summary>
        /// 垂直点
        /// </summary>
        VDash,

        /// <summary>
        /// 点
        /// </summary>
        Point,

        /// <summary>
        /// 图像
        /// </summary>
        Image,

        /// <summary>
        /// 未定义
        /// </summary>
        None
    }

    /// <summary>
    /// 符号类
    /// </summary>
    public class MedSymbolICU : IDisposable
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
        public MedSymbolICU(System.Drawing.Image image)
        {
            Image = image;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="symboltype">符号类型</param>
        public MedSymbolICU(MedSymbolType symboltype)
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
                if (_pen != null)
                    _pen.Dispose();
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
                g.DrawImage(_image, X - _image.Width / 2, Y - _image.Height / 2);
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

                g.DrawPath(_pen, path);
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
                case MedSymbolType.Circle:
                    path.AddEllipse(-hsize, -hsize, scaledSize, scaledSize);
                    break;
                case MedSymbolType.XCross:
                    path.AddLine(-hsize, -hsize, hsize1, hsize1);
                    path.StartFigure();
                    path.AddLine(hsize, -hsize, -hsize1, hsize1);
                    break;
                case MedSymbolType.Plus:
                    path.AddLine(0, -hsize, 0, hsize1);
                    path.StartFigure();
                    path.AddLine(-hsize, 0, hsize1, 0);
                    break;
                case MedSymbolType.Star:
                    path.AddLine(0, -hsize, 0, hsize1);
                    path.StartFigure();
                    path.AddLine(-hsize, 0, hsize1, 0);
                    path.StartFigure();
                    path.AddLine(-hsize, -hsize, hsize1, hsize1);
                    path.StartFigure();
                    path.AddLine(hsize, -hsize, -hsize1, hsize1);
                    break;
                case MedSymbolType.TriangleDown:
                    path.AddLine(0, hsize, hsize, -hsize);
                    path.AddLine(hsize, -hsize, -hsize, -hsize);
                    path.AddLine(-hsize, -hsize, 0, hsize);
                    break;
                case MedSymbolType.HDash:
                    path.AddLine(-hsize, 0, hsize1, 0);
                    break;
                case MedSymbolType.VDash:
                    path.AddLine(0, -hsize, 0, hsize1);
                    break;
                case MedSymbolType.Point:
                    path.AddLine(-1, 0, 1, 0);
                    path.AddLine(0, -1, 0, 1);
                    break;
            }

            return path;
        }

        #endregion 方法

        #region IDisposable 成员

        public void Dispose()
        {
            if (_pen != null)
                _pen.Dispose();
        }

        #endregion
    }
}
