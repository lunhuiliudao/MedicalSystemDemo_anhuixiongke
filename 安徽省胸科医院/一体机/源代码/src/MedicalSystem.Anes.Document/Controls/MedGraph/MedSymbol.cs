using System;
/*----------------------------------------------------------------
      // Copyright (C) 2005 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����MedSymbol.cs
      // �ļ�����������������
      //
      // 
      // ������ʶ��������
      // �޸ı�ʶ��������-2008-02-26
      // �޸����������ע��
----------------------------------------------------------------*/
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// ��������
    /// </summary>
    public enum MedSymbolTypeICU
    {
        /// <summary>
        /// ����
        /// </summary>
        Square,

        /// <summary>
        /// ��ʯ��
        /// </summary>
        Diamond,

        /// <summary>
        /// ������
        /// </summary>
        Triangle,

        /// <summary>
        /// Բ��
        /// </summary>
        Circle,

        /// <summary>
        /// ������
        /// </summary>
        XCross,

        /// <summary>
        /// �Ӻ�
        /// </summary>
        Plus,

        /// <summary>
        /// ����
        /// </summary>
        Star,

        /// <summary>
        /// ��������
        /// </summary>
        TriangleDown,

        /// <summary>
        /// ˮƽ��
        /// </summary>
        HDash,

        /// <summary>
        /// ��ֱ��
        /// </summary>
        VDash,

        /// <summary>
        /// ��
        /// </summary>
        Point,

        /// <summary>
        /// ͼ��
        /// </summary>
        Image,

        /// <summary>
        /// δ����
        /// </summary>
        None
    }

    /// <summary>
    /// ������
    /// </summary>
    public class MedSymbolICU : IDisposable
    {

        #region ����

        /// <summary>
        /// ��������
        /// </summary>
        private MedSymbolType _symboltype;

        /// <summary>
        /// ͼƬ
        /// </summary>
        private System.Drawing.Image _image;

        /// <summary>
        /// ����
        /// </summary>
        private System.Drawing.Pen _pen = new Pen(Color.Black);

        /// <summary>
        /// ��ˢ
        /// </summary>
        private System.Drawing.Brush _brush;

        /// <summary>
        /// ��С
        /// </summary>
        private float _size = 10;

        #endregion ����

        #region ���췽��

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="image">ͼƬ</param>
        public MedSymbolICU(System.Drawing.Image image)
        {
            Image = image;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="symboltype">��������</param>
        public MedSymbolICU(MedSymbolType symboltype)
        {
            _symboltype = symboltype;
        }

        #endregion ���췽��

        #region ����

        /// <summary>
        /// ��������
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
        /// ͼƬ
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
        /// ����
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
        /// ��ˢ
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
        /// ��С
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

        #endregion ����

        #region ����

        /// <summary>
        /// ���Ʒ���
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="X">ˮƽ����</param>
        /// <param name="Y">��ֱ����</param>
        public void Draw(System.Drawing.Graphics g, float X, float Y)
        {
            ///����ͼƬ
            if (_symboltype == MedSymbolType.Image)
            {
                g.DrawImage(_image, X - _image.Width / 2, Y - _image.Height / 2);
            }
            ///����·��
            else if (_symboltype != MedSymbolType.None)
            {
                Matrix saveMatrix = g.Transform;
                g.TranslateTransform(X, Y);

                ///��������·��
                GraphicsPath path = MakePath(g);

                ///���·��
                if (_brush != null)
                {
                    g.FillPath(_brush, path);
                }

                g.DrawPath(_pen, path);
                g.Transform = saveMatrix;
            }
        }

        /// <summary>
        /// ��������·��
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <returns>·��</returns>
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

        #endregion ����

        #region IDisposable ��Ա

        public void Dispose()
        {
            if (_pen != null)
                _pen.Dispose();
        }

        #endregion
    }
}
