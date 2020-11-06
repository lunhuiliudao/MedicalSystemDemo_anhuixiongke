/*----------------------------------------------------------------
      // Copyright (C) 2005 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����MedSymbol.cs
      // �ļ�����������������
      //
      // 
      // ������ʶ��������-2008-10-22
      // �޸ı�ʶ��������
----------------------------------------------------------------*/
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// ��������
    /// </summary>
    [Serializable]
    public enum MedSymbolType
    {
        /// <summary>
        /// ����
        /// </summary>
        [Description("����")]
        Square,

        /// <summary>
        /// ��ʯ��
        /// </summary>
        [Description("��ʯ��")]
        Diamond,

        /// <summary>
        /// ������
        /// </summary>
        [Description("������")]
        Triangle,

        /// <summary>
        /// Բ��
        /// </summary>
        [Description("Բ��")]
        Circle,

        /// <summary>
        /// СԲ��
        /// </summary>
        [Description("СԲ��")]
        MiniCircle,

        /// <summary>
        /// ������
        /// </summary>
        [Description("������")]
        XCross,

        /// <summary>
        /// ������
        /// </summary>
        [Description("����������")]
        XCrossVLine,

        /// <summary>
        /// �Ӻ�
        /// </summary>
        [Description("�Ӻ�")]
        Plus,

        /// <summary>
        /// ����
        /// </summary>
        [Description("����")]
        Star,

        /// <summary>
        /// ��������
        /// </summary>
        [Description("��������")]
        TriangleDown,

        /// <summary>
        /// ˮƽ��
        /// </summary>
        [Description("ˮƽ��")]
        HDash,

        /// <summary>
        /// ��ֱ��
        /// </summary>
        [Description("��ֱ��")]
        VDash,

        /// <summary>
        /// ��
        /// </summary>
        [Description("��")]
        Point,

        /// <summary>
        /// �����ʶ
        /// </summary>
        [Description("�����ʶ")]
        Anesthesia,

        /// <summary>
        /// ������ʶ
        /// </summary>
        [Description("������ʶ")]
        Operation,

        /// <summary>
        /// �ù�
        /// </summary>
        [Description("�ù�")]
        PutPipe,
        /// <summary>
        /// �ù�1
        /// </summary>
        [Description("�ù�1")]
        PutPipe1,
        /// <summary>
        /// �ù�2
        /// </summary>
        [Description("�ù�2")]
        PutPipe2,
        /// <summary>
        /// �ι�
        /// </summary>
        [Description("�ι�")]
        PullPipe,
        /// <summary>
        /// �ι�1
        /// </summary>
        [Description("�ι�1")]
        PullPipe1,
        /// <summary>
        /// ��V��
        /// </summary>
        [Description("��V��")]
        VLetterDown,
        /// <summary>
        /// ��V��
        /// </summary>
        [Description("��V������")]
        VLetterDownLine,

        /// <summary>
        /// V��
        /// </summary>
        [Description("V��")]
        VLetter,

        /// <summary>
        /// V������
        /// </summary>
        [Description("V������")]
        VLetterLine,

        /// <summary>
        /// Բ�е�
        /// </summary>
        [Description("Բ�е�")]
        CircleDot,
        /// <summary>
        /// СԲб��
        /// </summary>
        [Description("СԲб��")]
        MiniCircleLine,
        /// <summary>
        /// ʵ��Բ
        /// </summary>
        [Description("ʵ��Բ")]
        FillCircle,
        /// <summary>
        /// ʵ��СԲ
        /// </summary>
        [Description("ʵ��СԲ")]
        FillMiniCircle,
        /// <summary>
        /// Բ�ڼӺ�
        /// </summary>
        [Description("Բ�ڼӺ�")]
        CirclePlus,

        /// <summary>
        /// Բ�ڽ�����
        /// </summary>
        [Description("Բ�ڽ�����")]
        CircleXCross,

        /// <summary>
        /// Բ��ˮƽ��ͷ
        /// </summary>
        [Description("Բ��ˮƽ��ͷ")]
        CircleHArrow,

        /// <summary>
        /// Բ�ڴ�ֱ��ͷ
        /// </summary>
        [Description("Բ�ڴ�ֱ��ͷ")]
        CircleVArrow,

        /// <summary>
        /// ����Բ
        /// </summary>
        [Description("����Բ")]
        CircleHLine,

        /// <summary>
        /// ����Բ
        /// </summary>
        [Description("����Բ")]
        CircleVLine,

        /// <summary>
        /// ��еͨ��
        /// </summary>
        [Description("��еͨ��")]
        MachineAir,

        /// <summary>
        /// �ı�
        /// </summary>
        [Description("�ı�")]
        Text,

        /// <summary>
        /// ͼ��
        /// </summary>
        [Description("ͼ��")]
        Image,

        /// <summary>
        /// Բ���X���ĸ���
        /// </summary>
        [Description("ͼ��")]
        CircleXCrossDot,

        /// <summary>
        /// ���δ������ͷ
        /// </summary>
        [Description("��������")]
        InOperationRoom,

        /// <summary>
        /// ���δ������ͷ
        /// </summary>
        [Description("��������")]
        OutOperationRoom,

        /// <summary>
        /// �������
        /// </summary>
        [Description("����1")]
        InHouZhao,

        /// <summary>
        /// �γ�����
        /// </summary>
        [Description("����2")]
        OutHouZhao,

        /// <summary>
        /// δ����
        /// </summary>
        [Description("δ����")]
        None
    }

    /// <summary>
    /// ������
    /// </summary>
    [Serializable]
    public class MedSymbol
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

        private string _text;

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
        public MedSymbol(System.Drawing.Image image)
        {
            _symboltype = MedSymbolType.Image;
            Image = image;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="symboltype">��������</param>
        public MedSymbol(MedSymbolType symboltype)
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

        Font _font = new Font("����", 9);
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

        #endregion ����
    }
}
