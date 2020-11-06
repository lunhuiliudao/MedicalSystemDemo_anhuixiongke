/*----------------------------------------------------------------
      // Copyright (C) 2005 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����MedGraphPanel.cs
      // �ļ�����������ͼ��������
      //
      // 
      // ������ʶ��������-2008-01-08����������ʵ��MedGraph��Ԫ�صķ��룬�Ӷ��ﵽ�����Ŀ�ģ�����������Ժ�ǿ׳��
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// ͼ��������
    /// </summary>
    public class MedGraphPanel : IDisposable
    {

        #region ���췽��

        public MedGraphPanel(MedGraph graphControl)
        {
            _graphControl = graphControl;
        }

        #endregion ���췽��

        #region ����

        private MedGraph _graphControl;

        /// <summary>
        /// �����б�
        /// </summary>
        private MedCurveList _curveList = new MedCurveList();

        /// <summary>
        /// X������
        /// </summary>
        private MedAxisList _XaxisList = new MedAxisList(new Pen(Color.Green, 2), new Pen(Color.Green, 1));

        /// <summary>
        /// Y������
        /// </summary>
        private MedAxisList _YaxisList = new MedAxisList(new Pen(Color.Green, 2), new Pen(Color.Green, 1));

        /// <summary>
        /// ͼ��
        /// </summary>
        private MedLegend _legend = new MedLegend();

        /// <summary>
        /// �߾�
        /// </summary>
        private int _leftmargin = 5, _topmargin = 5, _rightmargin = 5, _bottommargin = 5;

        /// <summary>
        /// ������
        /// </summary>
        private MedGridRowList _rowList = new MedGridRowList(2);

        /// <summary>
        /// ����ˢ
        /// </summary>
        private Brush _rectBrush = Brushes.White, _mainrectBrush = Brushes.White, _gridTextBrush = Brushes.Black, _memoTextBrush = Brushes.Black;

        /// <summary>
        /// ����߿򻭱�
        /// </summary>
        private Pen _rectBorderPen = Pens.Black, _mainRectBorderPen = Pens.Green, _gridLinePen = Pens.Black, _memoLinePen = Pens.Black;

        /// <summary>
        /// ���������ʾ����
        /// </summary>
        private int _maxgirdRowCounts = 10;

        /// <summary>
        /// ����ͱ�ע�и߶Ȱٷֱ�
        /// </summary>
        private float _gridHeightPercent = 0.0f, _memoHeightPercent = 0.1f;

        /// <summary>
        /// �Ƿ�ͼ��
        /// </summary>
        private bool _drawlegend = true;

        /// <summary>
        /// ���������
        /// </summary>
        private int _hscrollwidth = 0;

        /// <summary>
        /// ��Ҫ������������
        /// </summary>
        private bool _hasAxisGridLine = true;

        /// <summary>
        /// X��������ڶ���
        /// </summary>
        private bool _xAxisTitleAtTop = true;

        /// <summary>
        /// Y�������λ��
        /// </summary>
        private float _yAxisTitleOffset = 0;

        #endregion ����

        #region ����

        /// <summary>
        /// �����б�
        /// </summary>
        public MedCurveList CurveList
        {
            get
            {
                return _curveList;
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        public MedGridRowList RowList
        {
            get
            {
                return _rowList;
            }
        }

        /// <summary>
        /// X������
        /// </summary>
        public MedAxisList XAxisList
        {
            get
            {
                return _XaxisList;
            }
        }

        /// <summary>
        /// Y������
        /// </summary>
        public MedAxisList YAxisList
        {
            get
            {
                return _YaxisList;
            }
        }

        /// <summary>
        /// ͼ��
        /// </summary>
        public MedLegend Legend
        {
            get
            {
                return _legend;
            }
            set
            {
                if (_legend != null)
                {
                    _legend.Dispose();
                }
                _legend = value;
            }
        }

        /// <summary>
        /// ��߾�
        /// </summary>
        public int LeftMargin
        {
            get
            {
                return _leftmargin;
            }
            set
            {
                _leftmargin = value;
            }
        }

        /// <summary>
        /// �ϱ߾�
        /// </summary>
        public int TopMargin
        {
            get
            {
                return _topmargin;
            }
            set
            {
                _topmargin = value;
            }
        }

        /// <summary>
        /// �ұ߾�
        /// </summary>
        public int RightMargin
        {
            get
            {
                return _rightmargin;
            }
            set
            {
                _rightmargin = value;
            }
        }

        /// <summary>
        /// �±߾�
        /// </summary>
        public int BottomMargin
        {
            get
            {
                return _bottommargin;
            }
            set
            {
                _bottommargin = value;
            }
        }

        /// <summary>
        /// ͼ������ˢ
        /// </summary>
        public Brush MainRectBrush
        {
            get
            {
                return _mainrectBrush;
            }
            set
            {
                _mainrectBrush = value;
            }
        }

        /// <summary>
        /// ��������ˢ
        /// </summary>
        public Brush RectBrush
        {
            get
            {
                return _rectBrush;
            }
            set
            {
                _rectBrush = value;
            }
        }

        /// <summary>
        /// �������򻭱�
        /// </summary>
        public Pen RectBorderPen
        {
            get
            {
                return _rectBorderPen;
            }
            set
            {
                _rectBorderPen = value;
            }
        }

        /// <summary>
        /// ͼ�����򻭱�
        /// </summary>
        public Pen MainRectBorderPen
        {
            get
            {
                return _mainRectBorderPen;
            }
            set
            {
                _mainRectBorderPen = value;
            }
        }

        /// <summary>
        /// ����������������
        /// </summary>
        public Pen GridLinePen
        {
            get
            {
                return _gridLinePen;
            }
            set
            {
                _gridLinePen = value;
            }
        }

        /// <summary>
        /// ���������ı���ˢ
        /// </summary>
        public Brush GridTextBrush
        {
            get
            {
                return _gridTextBrush;
            }
            set
            {
                _gridTextBrush = value;
            }
        }

        /// <summary>
        /// ��ע������������
        /// </summary>
        public Pen MemoLinePen
        {
            get
            {
                return _memoLinePen;
            }
            set
            {
                _memoLinePen = value;
            }
        }

        /// <summary>
        /// ��ע�����ı���ˢ
        /// </summary>
        public Brush MemoTextBrush
        {
            get
            {
                return _memoTextBrush;
            }
            set
            {
                _memoTextBrush = value;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        public Rectangle Rect, MainRect, GridRect, MemoRect;

        /// <summary>
        /// ������ʾ����
        /// </summary>
        public int GirdRowCounts = 10;

        /// <summary>
        /// ����ͱ�ע����
        /// </summary>
        public string SummeryTitle = "��Һƽ���ܼ�", MemoTitle = "��ע", SubTitle = "�ϼ�";

        /// <summary>
        /// ���������ͱ�����
        /// </summary>
        public float GridDataTypeHeadWidth = 30;

        /// <summary>
        /// ���������ͱ���
        /// </summary>
        public string[] DataTypeTitles = new string[] { "����", "����" };

        /// <summary>
        /// ��ֱ����λ��
        /// </summary>
        public float HShiftPos = 20.0f, HScrollPos = 0;

        /// <summary>
        /// ����
        /// </summary>
        public Font Font = new Font("����", 9);

        /// <summary>
        /// ���
        /// </summary>
        public int Width = 100;

        /// <summary>
        /// �߶�
        /// </summary>
        public int Height = 100;

        /// <summary>
        /// ���������ʾ����
        /// </summary>
        public int MaxGirdRowCounts
        {
            get
            {
                return _maxgirdRowCounts;
            }
            set
            {
                if (value >= 0) _maxgirdRowCounts = value;
            }
        }

        /// <summary>
        /// ����߶Ȱٷֱ�
        /// </summary>
        public float GridHeightPercent
        {
            get
            {
                return _gridHeightPercent;
            }
            set
            {
                if ((value >= 0) && (value < 1))
                {
                    _gridHeightPercent = value;
                }
            }
        }

        /// <summary>
        /// ע�и߶Ȱٷֱ�
        /// </summary>
        public float MemoHeightPercent
        {
            get
            {
                return _memoHeightPercent;
            }
            set
            {
                if ((value >= 0) && (value < 1))
                {
                    _memoHeightPercent = value;
                }
            }
        }

        /// <summary>
        /// �Ƿ�ͼ��
        /// </summary>
        public bool IsDrawLegend
        {
            get
            {
                return _drawlegend;
            }
            set
            {
                _drawlegend = value;
            }
        }

        /// <summary>
        /// ���������
        /// </summary>
        public int HScrollWidth
        {
            get
            {
                return _hscrollwidth;
            }
            set
            {
                if (value >= 0)
                {
                    _hscrollwidth = value;
                }
            }
        }

        /// <summary>
        /// ��Ҫ������������
        /// </summary>
        public bool HasAxisGridLine
        {
            get
            {
                return _hasAxisGridLine;
            }
            set
            {
                _hasAxisGridLine = value;
            }
        }

        /// <summary>
        /// X��������ڶ���
        /// </summary>
        public bool XAxisTitleAtTop
        {
            get
            {
                return _xAxisTitleAtTop;
            }
            set
            {
                _xAxisTitleAtTop = value;
            }
        }

        /// <summary>
        /// Y�������λ��
        /// </summary>
        public float YAxisTitleOffset
        {
            get
            {
                return _yAxisTitleOffset;
            }
            set
            {
                _yAxisTitleOffset = value;
            }
        }

        #endregion ����

        #region ����

        #region ���� - AddCurve

        public MedCurve addCurve(string title, MedPointList points)
        {
            MedCurve curve = new MedCurve(points);
            curve.Title = title;
            _curveList.Add(curve);
            return curve;
        }

        public MedCurve addCurve(MedPointList points)
        {
            return addCurve("", points);
        }

        public MedCurve addCurve(string title, MedPointList points, MedSymbol symbol, Pen pen, int xaxisindex, int yaxisindex)
        {
            MedCurve curve = new MedCurve(points, xaxisindex, yaxisindex, symbol, pen);
            curve.Title = title;
            _curveList.Add(curve);
            return curve;
        }

        public MedCurve addCurve(MedPointList points, MedSymbol symbol, Pen pen, int xaxisindex, int yaxisindex)
        {
            return addCurve("", points, symbol, pen, xaxisindex, yaxisindex);
        }

        public MedCurve addCurve(string title, MedPointList points, MedSymbol symbol, Pen pen)
        {
            return addCurve(title, points, symbol, pen, 0, 0);
        }

        public MedCurve addCurve(MedPointList points, MedSymbol symbol, Pen pen)
        {
            return addCurve("", points, symbol, pen);
        }

        public MedCurve addCurve(string title, MedPointList points, Image image, Color color, int xaxisindex, int yaxisindex)
        {
            MedCurve curve = new MedCurve(points, xaxisindex, yaxisindex, new MedSymbol(image), new Pen(color));
            curve.Title = title;
            _curveList.Add(curve);
            return curve;
        }

        public MedCurve addCurve(MedPointList points, Image image, Color color, int xaxisindex, int yaxisindex)
        {
            return addCurve("", points, image, color, xaxisindex, yaxisindex);
        }

        public MedCurve addCurve(string title, MedPointList points, string imageFileName, Color color, int xaxisindex, int yaxisindex)
        {
            return addCurve(title, points, Image.FromFile(imageFileName), color, xaxisindex, yaxisindex);
        }

        public MedCurve addCurve(MedPointList points, string imageFileName, Color color, int xaxisindex, int yaxisindex)
        {
            return addCurve("", points, imageFileName, color, xaxisindex, yaxisindex);
        }

        public MedCurve addCurve(string title, MedPointList points, Image image, Color color)
        {
            MedCurve curve = new MedCurve(points, image, color);
            curve.Title = title;
            _curveList.Add(curve);
            return curve;
        }

        public MedCurve addCurve(MedPointList points, Image image, Color color)
        {
            return addCurve("", points, image, color);
        }

        public MedCurve addCurve(string title, MedPointList points, string imageFileName, Color color)
        {
            return addCurve(title, points, Image.FromFile(imageFileName), color);
        }

        public MedCurve addCurve(MedPointList points, string imageFileName, Color color)
        {
            return addCurve("", points, imageFileName, color);
        }

        public MedCurve addCurve(string title, MedPointList points, Image image)
        {
            MedCurve curve = new MedCurve(points, image);
            curve.Title = title;
            _curveList.Add(curve);
            return curve;
        }

        public MedCurve addCurve(MedPointList points, Image image)
        {
            return addCurve("", points, image);
        }

        public MedCurve addCurve(string title, MedPointList points, string imageFileName)
        {
            return addCurve(title, points, Image.FromFile(imageFileName));
        }

        public MedCurve addCurve(MedPointList points, string imageFileName)
        {
            return addCurve("", points, imageFileName);
        }

        public MedCurve addCurve(string title, MedPointList points, Color color)
        {
            MedCurve curve = new MedCurve(points, color);
            curve.Title = title;
            _curveList.Add(curve);
            return curve;
        }

        public MedCurve addCurve(MedPointList points, Color color)
        {
            return addCurve("", points, color);
        }

        #endregion ���� - AddCurve

        #region ���� - addRow

        public MedGridRow addRow(string title, Pen pen, int datatype, MedPointList points)
        {
            MedGridRow row = new MedGridRow();
            row.Pen = pen;
            row.Title = title;
            row.DataType = datatype;
            row.Points = points;
            _rowList.Add(row, datatype);
            return row;
        }

        public MedGridRow addRow(string title, Pen pen, int datatype)
        {
            return addRow(title, pen, datatype, null);
        }

        public MedGridRow addRow(string title, int datatype)
        {
            return addRow(title, new Pen(Color.Black), datatype);
        }

        public MedGridRow addRow(string title)
        {
            return addRow(title, 0);
        }

        #endregion ���� - addRow

        #region ���㷽��

        /// <summary>
        /// ��������-ĳ��
        /// </summary>
        /// <param name="row"></param>
        /// <param name="minvalue"></param>
        /// <param name="maxvalue"></param>
        /// <returns></returns>
        public double Summery(MedGridRow row, double minvalue, double maxvalue)
        {
            double sum = 0;
            foreach (MedPoint point in row.Points)
            {
                if ((point.X >= minvalue) && (point.X < maxvalue)) sum += point.Y;
            }
            return sum;
        }

        /// <summary>
        /// ��������-������������
        /// </summary>
        /// <param name="typeindex">���ͣ�0-���� 1-����</param>
        /// <param name="minvalue"></param>
        /// <param name="maxvalue"></param>
        /// <returns></returns>
        public double Summery(int typeindex, double minvalue, double maxvalue)
        {
            double sum = 0;
            for (int i = 0; i < _rowList.CountOfType(typeindex); i++) sum += Summery(_rowList[i, typeindex], minvalue, maxvalue);
            return sum;
        }

        /// <summary>
        /// ��������-������
        /// </summary>
        /// <param name="minvalue"></param>
        /// <param name="maxvalue"></param>
        /// <returns></returns>
        public double Summery(double minvalue, double maxvalue)
        {
            return Summery(0, minvalue, maxvalue) - Summery(1, minvalue, maxvalue);
        }

        #endregion ���㷽��

        /// <summary>
        /// ��ʼ������-����ɫ�ͻ��Ʊ߿�
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="rect">����</param>
        /// <param name="brush">��仭ˢ</param>
        /// <param name="pen">�������ֻ���</param>
        /// <param name="drawrect">�Ƿ񻭱߿�</param>
        public void InitRect(Graphics g, Rectangle rect, Brush brush, Pen pen, bool drawrect)
        {
            g.FillRectangle(brush, rect);
            if (drawrect) g.DrawRectangle(pen, rect);
        }

        /// <summary>
        /// ��ʼ������-����ɫ�ͻ��Ʊ߿�
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="rect">����</param>
        /// <param name="color1">��佥��ɫ��ʼ��ɫ</param>
        /// <param name="color2">��佥��ɫ������ɫ</param>
        /// <param name="angle">��佥��ɫ�仯�Ƕ�</param>
        /// <param name="pen">�������ֻ���</param>
        /// <param name="drawrect">�Ƿ񻭱߿�</param>
        public void InitRect(Graphics g, Rectangle rect, Color color1, Color color2, float angle, Pen pen, bool drawrect)
        {
            InitRect(g, rect, new LinearGradientBrush(rect, color1, color2, angle), pen, drawrect);
        }

        /// <summary>
        /// ��ͼ��
        /// </summary>
        /// <param name="g">��ͼ����</param>
        public void DrawLegend(Graphics g)
        {
            InitRect(g, _legend.Rect, _legend.Brush, _legend.Pen, _legend.HasBorder);

            int i = 0, k = 0, curveIndex = 0, j = 0;
            int[] topOffSet = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            ///��������
            int index = -1;

            _legend.ItemRects.Clear();

            ///ͼ������������
            foreach (MedCurve curve in _curveList)
            {
                index++;
                if (!string.IsNullOrEmpty(curve.LegendTitle))
                {
                    Rectangle rect = new Rectangle();
                    if (_legend.AlignYAxis)
                    {
                        curveIndex = (_YaxisList.Count - curve.YAxisIndex - 1);
                        rect.X = _legend.Rect.X + i * _legend.Rect.Width / _legend.ColCount - 2;
                        rect.Y = topOffSet[curveIndex] * 25 + _legend.Rect.Y + 3;
                        rect.Height = (int)(topOffSet[curveIndex] * 25 + _legend.Rect.Y + 9 + g.MeasureString("A", this.Font).Height) - rect.Y + 9;
                    }
                    else
                    {
                        rect.X = _legend.Rect.X + i * _legend.Rect.Width / _legend.ColCount - 2;
                        rect.Y = j * 25 + _legend.Rect.Y + 3;
                        rect.Height = (int)g.MeasureString("A", this.Font).Height;
                    }
                    rect.Width = (int)g.MeasureString(curve.Title, this.Font).Width + 2;
                    _legend.ItemRects.Add(rect);

                    ///��ĳͼ���߿�
                    if (_legend.ItemRectIndex == k++) g.DrawRectangle(Pens.LightGray, rect);

                    //if (!((index > 0) && curve.LegendTitle.Equals(_curveList[index - 1].LegendTitle)))
                    {
                        ///��ͼ������
                        if (_legend.AlignYAxis)
                        {
                            g.DrawString(curve.LegendTitle, this.Font, curve.Pen.Brush, _legend.Rect.X + curveIndex * _legend.Rect.Width / _legend.ColCount, topOffSet[curveIndex] * 25 + _legend.Rect.Y + 5);
                        }
                        else
                        {
                            g.DrawString(curve.LegendTitle, this.Font, curve.Pen.Brush, _legend.Rect.X + i * _legend.Rect.Width / _legend.ColCount, j * 25 + _legend.Rect.Y + 5);
                        }
                        ///��ͼ����ʶ
                        //if ((index < _curveList.Count - 1) && curve.LegendTitle.Equals(_curveList[index + 1].LegendTitle))
                        //{
                        //    //curve.Symbol.Draw(g, _legend.Rect.X + i * _legend.Rect.Width / _legend.ColCount + g.MeasureString(curve.Title, this.Font).Width / 2 - 16, j * 25 + _legend.Rect.Y + 9 + g.MeasureString("A", this.Font).Height);
                        //    //_curveList[index + 1].Symbol.Draw(g, _legend.Rect.X + i * _legend.Rect.Width / _legend.ColCount + g.MeasureString(curve.Title, this.Font).Width / 2 - 2, j * 25 + _legend.Rect.Y + 9 + g.MeasureString("A", this.Font).Height);
                        //    curve.Symbol.Draw(g, _legend.Rect.X + curveIndex * _legend.Rect.Width / _legend.ColCount + g.MeasureString(curve.LegendTitle, this.Font).Width / 2 - 4, topOffSet[curveIndex] * 25 + _legend.Rect.Y + 9 + g.MeasureString("A", this.Font).Height);
                        //    i--;
                        //}
                        //else
                        {
                            if (_legend.AlignYAxis)
                            {
                                curve.Symbol.Draw(g, _legend.Rect.X + curveIndex * _legend.Rect.Width / _legend.ColCount + g.MeasureString(curve.LegendTitle, this.Font).Width / 2 - 4, topOffSet[curveIndex] * 25 + _legend.Rect.Y + 9 + g.MeasureString("A", this.Font).Height);
                            }
                            else
                            {
                                curve.Symbol.Draw(g, _legend.Rect.X + i * _legend.Rect.Width / _legend.ColCount + g.MeasureString(curve.Title, this.Font).Width / 2 - 4, j * 25 + _legend.Rect.Y + 9 + g.MeasureString("A", this.Font).Height);
                            }
                        }
                    }
                    if (_legend.AlignYAxis)
                    {
                        topOffSet[curveIndex]++;
                    }
                    else
                    {
                        i++;
                        ///����
                        if (i > _legend.ColCount - 1)
                        {
                            i = 0;
                            //j++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="leftOffSet">����λ��</param>
        /// <param name="topOffSet">����λ��</param>
        public void DrawCurves(Graphics g, int leftOffSet, int topOffSet)
        {
            float xx, yy, xx1 = 0, yy1 = 0, barCount = 0, barIndex = 0, barWidth = 0;

            for (int i = 0; i < _curveList.Count; i++)
            {
                if (((MedCurve)_curveList[i]).IsBar)
                {
                    barCount++;
                    if (barWidth <= 0) barWidth = ((MedCurve)_curveList[i]).BarWidth;
                }
            }

            for (int i = 0; i < _curveList.Count; i++)
            {
                MedCurve curve = (MedCurve)_curveList[i];
                MedPointList points = curve.Points;

                ///�����ߵ�ÿ����
                for (int j = 0; j < points.Count; j++)
                {
                    xx = TranslateX(points[j].X, curve.XAxisIndex);
                    yy = TranslateY(points[j].Y, curve.YAxisIndex);

                    ///ͼ��״ͼ
                    if (curve.IsBar)
                    {
                        g.DrawRectangle(curve.Pen, xx + leftOffSet - (barWidth * barCount / 2) + barIndex * barWidth, yy + topOffSet, barWidth, MainRect.Bottom - yy - topOffSet);
                        g.FillRectangle(new SolidBrush(curve.Pen.Color), xx + leftOffSet - (barWidth * barCount / 2) + barIndex * barWidth, yy + topOffSet, barWidth, MainRect.Bottom - yy - topOffSet);
                    }

                    ///������ͼ
                    else
                    {
                        if (j > 0)
                        {
                            if (curve.hasLine)
                            {
                                ///��������
                                g.DrawLine(curve.Pen, xx1 + leftOffSet, yy1 + topOffSet, xx + leftOffSet, yy + topOffSet);
                            }
                        }
                        if (points[j].Symbol != null)
                        {
                            ///���Ƶ��ʶ
                            points[j].Symbol.Draw(g, xx + leftOffSet, yy + topOffSet);
                        }
                        else if (curve.Symbol.SymbolType != MedSymbolType.None)
                        {
                            ///�������ߵ��ʶ
                            curve.Symbol.Draw(g, xx + leftOffSet, yy + topOffSet);
                        }
                        xx1 = xx;
                        yy1 = yy;
                    }
                }///�����ߵ�ÿ����

                if (curve.IsBar) barIndex++;

            }
        }

        /// <summary>
        /// ����������-������
        /// </summary>
        /// <param name="g">��ͼ����</param>
        public void DrawGrid(Graphics g)
        {
            if (_graphControl.CustomDrawGridEventHandle != null)
            {
                _graphControl.CustomDrawGridEventHandle(g, GridRect);
                return;
            }

            InitRect(g, new Rectangle(Rect.X, GridRect.Y, Rect.Width, GridRect.Height), Brushes.White, _gridLinePen, false);

            ///X������̶�ֵ����
            int _count = (int)((_XaxisList[0].Max - _XaxisList[0].Min) / (_XaxisList[0].Step));

            ///��X������̶���
            for (int i = 0; i <= _count; i++)
            {
                float _X = GridRect.X + i * GridRect.Width / _count;
                //g.DrawLine(GridPen, _X, GridRect.Y, _X, GridRect.Y + GridRect.Height);
                ///������
                DrawAxisGrid(g, new Rectangle((int)_X, GridRect.Y, (int)(GridRect.Width / _count), (_rowList.Count) * GridRect.Height / GirdRowCounts), _XaxisList.MinSetp, true, _gridLinePen);
            }

            ///����ʼ����
            g.DrawLine(_gridLinePen, Rect.X, GridRect.Y, GridRect.X + GridRect.Width, GridRect.Y);

            ///�и�
            float _H = GridRect.Height / GirdRowCounts;

            ///�����Y����
            float _Y = GridRect.Y + _H;

            float oldY = GridRect.Y;

            ///��������
            for (int i = 0; i < _rowList.TypeCount; i++)
            {
                ///j=0������ j=1������
                for (int j = 0; j < _rowList.CountOfType(i); j++)
                {

                    g.DrawLine(_gridLinePen, Rect.X + GridDataTypeHeadWidth, _Y, GridRect.X + GridRect.Width, _Y);

                    ///д��������ϸ������
                    g.DrawString(_rowList[j, i].Title, Font, _rowList[j, i].Pen.Brush, Rect.X + GridDataTypeHeadWidth, _Y - (_H + g.MeasureString("A", this.Font).Height) / 2);

                    ///д����������������ֵ
                    for (int k = 0; k < _count; k++)
                    {
                        for (int kk = 0; kk < _XaxisList.MinSetp; kk++)
                        {
                            double sum = Summery(_rowList[j, i], _XaxisList[0].Min + k * _XaxisList[0].Step + kk * _XaxisList[0].Step / _XaxisList.MinSetp, _XaxisList[0].Min + k * _XaxisList[0].Step + (kk + 1) * _XaxisList[0].Step / _XaxisList.MinSetp);
                            if (sum != 0) g.DrawString(sum.ToString(), this.Font, _rowList[j, i].Pen.Brush, new RectangleF(MainRect.X + k * GridRect.Width / _count + kk * GridRect.Width / _count / _XaxisList.MinSetp, _Y - (_H + g.MeasureString("A", this.Font).Height) / 2, GridRect.Width / _count / _XaxisList.MinSetp, g.MeasureString("A", this.Font).Height));
                        }
                    }

                    _Y += _H;
                }

                ///������
                g.DrawLine(_gridLinePen, Rect.X, _Y, GridRect.X + GridRect.Width, _Y);

                ///д�������߳����ϼƱ���
                if (_rowList.Count > 3)
                {
                    try
                    {
                        g.DrawString(DataTypeTitles[i] + SubTitle, this.Font, _rowList[0, i].Pen.Brush, Rect.X + GridDataTypeHeadWidth, _Y - (_H + g.MeasureString("A", this.Font).Height) / 2);
                    }
                    catch { }
                }
                else
                {
                    g.DrawString(DataTypeTitles[i] + SubTitle, this.Font, _gridTextBrush, Rect.X + GridDataTypeHeadWidth, _Y - (_H + g.MeasureString("A", this.Font).Height) / 2);
                }

                ///д�������ܻ���ֵ
                for (int k = 0; k < _count; k++)
                {
                    for (int kk = 0; kk < _XaxisList.MinSetp; kk++)
                    {
                        double sum = Summery(i, _XaxisList[0].Min + k * _XaxisList[0].Step + kk * _XaxisList[0].Step / _XaxisList.MinSetp, _XaxisList[0].Min + k * _XaxisList[0].Step + (kk + 1) * _XaxisList[0].Step / _XaxisList.MinSetp);
                        if (sum != 0) g.DrawString(sum.ToString(), this.Font, _gridTextBrush, new RectangleF(MainRect.X + k * GridRect.Width / _count + kk * GridRect.Width / _count / _XaxisList.MinSetp, _Y - (_H + g.MeasureString("A", this.Font).Height) / 2, GridRect.Width / _count / _XaxisList.MinSetp, g.MeasureString("A", this.Font).Height));
                    }
                }

                ///������������
                InitRect(g, new Rectangle(Rect.X, (int)oldY, (int)GridDataTypeHeadWidth, (int)(_Y - oldY)), Color.FromArgb(235, 242, 248), Color.FromArgb(213, 229, 242), 0, _gridLinePen, true);

                ///д�������������������
                g.DrawString(DataTypeTitles[i], this.Font, _gridTextBrush, Rect.X + (GridDataTypeHeadWidth - g.MeasureString(DataTypeTitles[i], this.Font).Width) / 2, (oldY + _Y - g.MeasureString("A", this.Font).Height) / 2);

                oldY = _Y;
                _Y += _H;
            }

            ///д����ֵ
            g.DrawString(SummeryTitle, this.Font, _gridTextBrush, Rect.X, _Y - (_H + g.MeasureString("A", this.Font).Height) / 2);
            for (int k = 0; k < _count; k++)
            {
                for (int kk = 0; kk < _XaxisList.MinSetp; kk++)
                {
                    try
                    {
                        double sum = Summery(_XaxisList[0].Min + k * _XaxisList[0].Step + kk * _XaxisList[0].Step / _XaxisList.MinSetp, _XaxisList[0].Min + k * _XaxisList[0].Step + (kk + 1) * _XaxisList[0].Step / _XaxisList.MinSetp);
                        if (sum != 0) g.DrawString(sum.ToString(), this.Font, _gridTextBrush, new RectangleF(MainRect.X + k * GridRect.Width / _count + kk * GridRect.Width / _count / _XaxisList.MinSetp, _Y - (_H + g.MeasureString("A", this.Font).Height) / 2, GridRect.Width / _count / _XaxisList.MinSetp, g.MeasureString("A", this.Font).Height));
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// ��X������
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="rect">��ͼ����</param>
        /// <param name="pen">����</param>
        /// <param name="gridPen">���񻭱�</param>
        /// <param name="index">����������</param>
        /// <param name="minstep">��С�ָ�</param>
        /// <param name="axis">������</param>
        public void DrawXAxis(Graphics g, Rectangle rect, Pen pen, Pen gridPen, int index, int minstep, MedAxis axis, int leftOffSet, int topOffSet)
        {
            int _count = (int)((axis.Max - axis.Min) / (axis.Step));
            if (_count == 0)
                return;

            for (int i = 0; i <= _count; i++)
            {
                float _X = rect.X + i * rect.Width / _count;

                if (index == 0)
                {
                    if ((_hasAxisGridLine) || (i == 0))
                    {
                        g.DrawLine(pen, _X + leftOffSet, rect.Y + topOffSet, _X + leftOffSet, rect.Y + topOffSet + rect.Height);
                    }
                    else
                    {
                        g.DrawLine(pen, _X + leftOffSet, rect.Y + topOffSet + rect.Height - 10, _X + leftOffSet, rect.Y + topOffSet + rect.Height);
                    }

                    if ((i < _count) && _hasAxisGridLine)
                    {
                        DrawAxisGrid(g, new Rectangle((int)_X + leftOffSet, rect.Y + topOffSet, (int)(rect.Width / _count), rect.Height), minstep, true, gridPen);
                    }
                }
            }
        }

        /// <summary>
        /// ����Y������
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="rect">����</param>
        /// <param name="pen">����</param>
        /// <param name="gridPen">���񻭱�</param>
        /// <param name="index">����������</param>
        /// <param name="minstep">��С�̶�</param>
        /// <param name="axis">������</param>
        public void DrawYAxis(Graphics g, Rectangle rect, Pen pen, Pen gridPen, int index, int minstep, MedAxis axis, int leftOffSet, int topOffSet)
        {
            ///�̶�����
            int _count = (int)((axis.Max - axis.Min) / (axis.Step));

            for (int i = 0; i <= _count; i++)
            {
                float _Y = rect.Y + i * rect.Height / _count;

                ///ֻ����һ��
                if (index == 0)
                {
                    if (_gridHeightPercent > 0)
                    {
                        g.DrawLine(pen, rect.X + leftOffSet, _Y + topOffSet, rect.X + rect.Width + leftOffSet, _Y + topOffSet);

                        ///��������
                        if ((i < _count) && (_hasAxisGridLine))
                        {
                            DrawAxisGrid(g, new Rectangle(rect.X + leftOffSet, (int)_Y + topOffSet, rect.Width, (int)(rect.Height / _count)), minstep, false, gridPen);
                        }
                    }
                    else
                    {
                        if ((_hasAxisGridLine) || (i == _count))
                        {
                            g.DrawLine(pen, rect.X + leftOffSet, _Y + topOffSet - i - 1, rect.X + rect.Width + leftOffSet, _Y + topOffSet - i - 1);
                        }
                        else
                        {
                            g.DrawLine(pen, rect.X + leftOffSet, _Y + topOffSet - i - 1, rect.X + 5 + leftOffSet, _Y + topOffSet - i - 1);
                        }

                        ///��������
                        if ((i < _count) && (_hasAxisGridLine))
                        {
                            DrawAxisGrid(g, new Rectangle(rect.X + leftOffSet, (int)_Y + topOffSet - i - 1, rect.Width, (int)(rect.Height / _count) - 1), minstep, false, gridPen);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ���ƿ̶�ֵ����
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="rect">����</param>
        /// <param name="pen">����</param>
        /// <param name="gridPen">���񻭱�</param>
        /// <param name="index">����������</param>
        /// <param name="minstep">��С�̶�</param>
        /// <param name="axis">������</param>
        public void DrawYAxisTitle(Graphics g, Rectangle rect, Pen pen, Pen gridPen, int index, int minstep, MedAxis axis, int leftOffSet, int topOffSet)
        {
            ///�̶�����
            int _count = (int)((axis.Max - axis.Min) / (axis.Step));

            for (int i = 0; i <= _count; i++)
            {
                float _Y = rect.Y + i * rect.Height / _count;

                /////���ƿ̶�ֵ����
                float _V = (axis.Max - axis.Step * i);
                SizeF _sizeF = g.MeasureString(_V.ToString(), axis.Font);
                SizeF _sizeF1 = g.MeasureString("1000", axis.Font);

                ///������
                if (_gridHeightPercent > 0)
                {
                    if (i < _count)
                    {
                        g.DrawString(_V.ToString(), axis.Font, axis.Brush, rect.X + leftOffSet - _sizeF.Width - index * _sizeF1.Width - 15 + _yAxisTitleOffset, _Y + topOffSet - _sizeF.Height / 2);
                    }
                }
                ///������
                else
                {
                    if ((i > 0) && (i < _count))
                    {
                        g.DrawString(_V.ToString(), axis.Font, axis.Brush, rect.X + leftOffSet - _sizeF.Width - index * _sizeF1.Width - 15, _Y + topOffSet - _sizeF.Height / 2 - i - 1);
                    }
                    else if (i > 0)
                    {
                        g.DrawString(_V.ToString(), axis.Font, axis.Brush, rect.X + leftOffSet - _sizeF.Width - index * _sizeF1.Width - 15, _Y + topOffSet - _sizeF.Height - 2);
                    }
                    else
                    {
                        g.DrawString(_V.ToString(), axis.Font, axis.Brush, rect.X + leftOffSet - _sizeF.Width - index * _sizeF1.Width - 15, _Y + topOffSet - 2);
                    }
                }

            }
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="g">��ͼ����</param>
        /// <param name="rect">��ͼ����</param>
        /// <param name="gridcount">������</param>
        /// <param name="isXaxis">�Ƿ�X����</param>
        /// <param name="pen">����</param>
        private void DrawAxisGrid(Graphics g, Rectangle rect, int gridcount, bool isXaxis, Pen pen)
        {
            if (isXaxis)
                for (int i = 0; i < gridcount; i++)
                {
                    float _X = rect.X + i * rect.Width / gridcount;
                    g.DrawLine(pen, _X, rect.Y, _X, rect.Y + rect.Height);
                }
            else
                for (int i = 0; i < gridcount; i++)
                {
                    float _Y = rect.Y + i * rect.Height / gridcount;
                    g.DrawLine(pen, rect.X, _Y, rect.X + rect.Width, _Y);
                }
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="g">��ͼ����</param>
        public void DrawAxises(Graphics g, bool hadYAxisCaption, int leftOffSet, int topOffSet)
        {
            ///��Y����
            for (int i = 0; i < _YaxisList.Count; i++)
            {
                DrawYAxis(g, MainRect, _YaxisList.Pen, _YaxisList.MinPen, i, _YaxisList.MinSetp, _YaxisList[i], leftOffSet, topOffSet);
                if (hadYAxisCaption)
                {
                    DrawYAxisTitle(g, MainRect, _YaxisList.Pen, _YaxisList.MinPen, i, _YaxisList.MinSetp, _YaxisList[i], leftOffSet, topOffSet);
                }
            }

            ///��X����
            for (int i = 0; i < _XaxisList.Count; i++)
            {
                DrawXAxis(g, MainRect, _XaxisList.Pen, _XaxisList.MinPen, i, _XaxisList.MinSetp, _XaxisList[i], leftOffSet, topOffSet);
            }

        }

        /// <summary>
        /// ����ע��
        /// </summary>
        /// <param name="g">��ͼ����</param>
        public void DrawMemo(Graphics g)
        {
            if (MemoHeightPercent < 0.05f) return;
            InitRect(g, new Rectangle(Rect.X, MemoRect.Y, Rect.Width, MemoRect.Height), Color.FromArgb(235, 242, 248), Color.FromArgb(213, 229, 242), 90, _memoLinePen, true);
            g.DrawLine(_memoLinePen, MemoRect.X, MemoRect.Y, MemoRect.X, MemoRect.Y + MemoRect.Height);
            g.DrawString(MemoTitle, this.Font, _memoTextBrush, Rect.X + 5, MemoRect.Y + (MemoRect.Height - g.MeasureString(MemoTitle, this.Font).Height) / 2);
            if (_graphControl.CustomDrawMemoEventHandle != null)
            {
                _graphControl.CustomDrawMemoEventHandle(g, MemoRect);
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="g">��ͼ����</param>
        public void CalcMainRect(Graphics g)
        {
            ///����ͼ������
            Rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            ///ͼ���ϲ�������(������)
            MainRect = new Rectangle();
            MainRect.X = LeftMargin + (int)YAxisList.Width(g);
            MainRect.Y = TopMargin + (_xAxisTitleAtTop ? (int)XAxisList.Height(g) : 0);
            MainRect.Width = Rect.Width - MainRect.X - RightMargin - _hscrollwidth;
            MainRect.Height = (int)((Rect.Height - MainRect.Y - BottomMargin) * (1 - GridHeightPercent));

            ///��������
            if (GridHeightPercent > 0)
            {
                GridRect = new Rectangle(MainRect.X, MainRect.Y + MainRect.Height, MainRect.Width, (int)(((Rect.Height - MainRect.Y - BottomMargin) - MainRect.Height) * (1 - MemoHeightPercent)));
                MemoRect = new Rectangle(GridRect.X, GridRect.Y + GridRect.Height, Rect.Width - GridRect.X, (Rect.Height - MainRect.Y - BottomMargin) - MainRect.Height - GridRect.Height);
            }

            ///��������
            GirdRowCounts = (MaxGirdRowCounts > RowList.Count) ? RowList.Count : MaxGirdRowCounts;

        }

        /// <summary>
        /// X����ת��
        /// </summary>
        /// <param name="X"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public float TranslateX(double X, int index)
        {
            return (MainRect.X + ((float)X - _XaxisList[index].Min) * (MainRect.Width) / (_XaxisList[index].Max - _XaxisList[index].Min));
        }

        /// <summary>
        /// Y����ת��
        /// </summary>
        /// <param name="Y"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public float TranslateY(double Y, int index)
        {
            return (MainRect.Y + MainRect.Height - ((float)Y - _YaxisList[index].Min) * (MainRect.Height) / (_YaxisList[index].Max - _YaxisList[index].Min));
        }

        /// <summary>
        /// ������ͼ
        /// </summary>
        /// <param name="g">��ͼ����</param>
        public void DrawGraph(Graphics g)
        {
            ///���¼�������
            CalcMainRect(g);

            InitRect(g, Rect, RectBrush, RectBorderPen, true);

            ///����ͼ��
            using (Image imageAll = new Bitmap(this.Width, this.Height + (RowList.Count) * GridRect.Height / GirdRowCounts))
            {
                ///ͼ���ϲ�������(������) + ������
                using (Image imageMainAndGrid = new Bitmap(this.Width, MainRect.Height + GridRect.Height + ((TopMargin > 5) ? TopMargin - 5 : TopMargin)))
                {
                    ///����ͼ����ͼ����
                    using (Graphics graphicsAll = Graphics.FromImage(imageAll))
                    {
                        ///��������ƽ������
                        graphicsAll.SmoothingMode = SmoothingMode.AntiAlias;

                        ///ͼ���ϲ�������(������) + ��������ͼ����
                        using (Graphics graphicsMainAndGrid = Graphics.FromImage(imageMainAndGrid))
                        {
                            ///��ʼ������
                            InitRect(graphicsAll, MainRect, MainRectBrush, MainRectBorderPen, false);

                            ///��������
                            DrawAxises(graphicsAll, false, 0, 0);

                            ///������
                            DrawCurves(graphicsAll, 0, 0);

                            ///��Y���걳��
                            InitRect(graphicsAll, new Rectangle(Rect.X, Rect.Y, MainRect.X - Rect.X, MainRect.Y + MainRect.Height - Rect.Y),
                                Color.FromArgb(243, 243, 243), Color.White, 90, new Pen(Color.Black), false);

                            for (int i = 0; i < _YaxisList.Count; i++)
                            {
                                DrawYAxisTitle(graphicsAll, MainRect, _YaxisList.Pen, _YaxisList.MinPen, i, _YaxisList.MinSetp, _YaxisList[i], 10, 0);
                            }

                            ///������
                            if (GridHeightPercent > 0.0f)
                            {
                                DrawGrid(graphicsAll);
                                DrawMemo(g);
                            }

                            ///���ƿɵ�ǰ����ʾ����
                            graphicsMainAndGrid.DrawImage(imageAll, 0, HScrollPos - MainRect.Y + TopMargin);

                            ///��ͼ��
                            if (IsDrawLegend)
                            {
                                _legend.Rect = new Rectangle(_legend.Rect.X, (int)HScrollPos, _legend.Rect.Width, _legend.Rect.Height);
                                DrawLegend(graphicsMainAndGrid);
                            }

                            ///���ݹ���������λ�Ʋ�����
                            g.DrawImage(imageMainAndGrid, 0, HShiftPos);

                            ///��X����ֵ
                            int _count = (int)((XAxisList[0].Max - XAxisList[0].Min) / (XAxisList[0].Step));
                            if (_count == 0)
                                return;
                            for (int i = 0; i <= _count; i++)
                            {
                                float _X = MainRect.X + i * MainRect.Width / _count;
                                float _V = (XAxisList[0].Min + XAxisList[0].Step * i);
                                string s;
                                if (XAxisList[0].TextFormat.Equals("HH:mm"))
                                {
                                    if (_V > 24) _V -= 24;
                                    DateTime dt = Converter.HourToHHMM(_V);
                                    if (dt.Second >= 30) dt = dt.AddMinutes(1);
                                    s = dt.ToString("HH:mm");
                                }
                                else if (XAxisList[0].TextFormat.Equals("day"))
                                {
                                    if (XAxisList[0].Month == 0 && _V > DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
                                        _V -= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                                    else if (XAxisList[0].Month > 0 && _V > DateTime.DaysInMonth(DateTime.Now.Year, XAxisList[0].Month))
                                        _V -= DateTime.DaysInMonth(DateTime.Now.Year, XAxisList[0].Month);
                                    double hours = (_V - (int)_V) * 24;
                                    if (hours != 0)
                                        //s = ((int)_V).ToString() + "-" + (int)hours;
                                        s = "";
                                    else
                                        s = _V.ToString();
                                }
                                else
                                {
                                    s = _V.ToString();
                                }
                                SizeF _sizeF = g.MeasureString(s, XAxisList[0].Font);
                                SizeF _sizeF1 = g.MeasureString("1000", XAxisList[0].Font);
                                if (_xAxisTitleAtTop)
                                {
                                    if ((_gridHeightPercent > 0) && (i == 0))
                                    {
                                        g.DrawString(s, XAxisList[0].Font, XAxisList[0].Brush, _X - _sizeF.Width / 2 + 12, MainRect.Y - _sizeF.Height - 5);
                                    }
                                    else
                                    {
                                        g.DrawString(s, XAxisList[0].Font, XAxisList[0].Brush, _X - _sizeF.Width / 2, MainRect.Y - _sizeF.Height - 5);
                                    }
                                }
                                else
                                {
                                    if ((_gridHeightPercent > 0) && (i == 0))
                                    {
                                        g.DrawString(s, XAxisList[0].Font, XAxisList[0].Brush, _X - _sizeF.Width / 2 + 12, MainRect.Y + MainRect.Height);
                                    }
                                    else
                                    {
                                        g.DrawString(s, XAxisList[0].Font, XAxisList[0].Brush, _X - _sizeF.Width / 2, MainRect.Y + MainRect.Height);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion ����


        #region IDisposable ��Ա

        public void Dispose()
        {
            if (Font != null)
            {
                Font.Dispose();
            }

            if (_legend != null)
            {
                _legend.Dispose();
            }
        }

        #endregion
    }
}
