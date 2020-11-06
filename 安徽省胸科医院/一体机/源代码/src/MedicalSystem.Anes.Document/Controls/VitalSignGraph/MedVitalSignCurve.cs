/*----------------------------------------------------------------
      // Copyright (C) 2008 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����MedVitalSignGraph.cs
      // �ļ���������������������
      //
      // 
      // ������ʶ��������-2008-10-21
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Controls
{

    /// <summary>
    /// ������������
    /// </summary>
    [Serializable]
    public enum VitalSignCurveType
    {
        /// <summary>
        /// �����
        /// </summary>
        LineAndPoints,
        /// <summary>
        /// �㼯��
        /// </summary>
        Points
    }


    /// <summary>
    /// ����������
    /// </summary>
    [Serializable]
    public class MedVitalSignCurve
    {

        #region ���췽��

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="text">�ı������ƣ�</param>
        /// <param name="yAxisIndex">Y��������</param>
        /// <param name="color">��ɫ</param>
        /// <param name="symbol">��ʶ</param>
        public MedVitalSignCurve(string text, int yAxisIndex, Color color, MedSymbol symbol)
            : this(text, yAxisIndex, color, symbol, false)
        {

        }
        public MedVitalSignCurve(string text, int yAxisIndex, Color color, MedSymbol symbol, bool isDigit)
        {
            _text = text;
            _yAxisIndex = yAxisIndex;
            _color = color;
            _symbol = symbol;
            _symbol.Pen.Color = color;
            _isDigit = isDigit;
        }

        public MedVitalSignCurve(string text, string code, int yAxisIndex, Color color, MedSymbol symbol, bool isDigit)
        {
            _code = code;
            _text = text;
            _yAxisIndex = yAxisIndex;
            _color = color;
            _symbol = symbol;
            _symbol.Pen.Color = color;
            _isDigit = isDigit;
        }

        #endregion ���췽��

        #region ����

        /// <summary>
        /// �ı������ƣ�
        /// </summary>
        private string _text;

        /// <summary>
        /// ���루���룩
        /// </summary>
        private string _code;

        /// <summary>
        /// �㼯��
        /// </summary>
        private List<MedVitalSignPoint> _points = new List<MedVitalSignPoint>();

        /// <summary>
        /// ��ɫ
        /// </summary>
        private Color _color = Color.Black;

        /// <summary>
        /// ���
        /// </summary>
        private int _width;

        /// <summary>
        /// Y��������
        /// </summary>
        private int _yAxisIndex;

        /// <summary>
        /// ��ʶ
        /// </summary>
        private MedSymbol _symbol;

        /// <summary>
        /// ��������
        /// </summary>
        private VitalSignCurveType _curveType;

        #endregion ����

        #region ����
        private string _alias = "";
        public string Alias
        {
            get
            {
                return _alias;
            }
            set
            {
                _alias = value;
            }
        }
        private string _displayText = "";
        public string DisplayText
        {
            get
            {
                return _displayText;
            }
            set
            {
                _displayText = value;
            }
        }

        private bool _isDigit = false;
        public bool IsDigit
        {
            get
            {
                return _isDigit;
            }
            set
            {
                _isDigit = value;
            }
        }

        /// <summary>
        /// �ı������ƣ�
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
        /// �ı������ƣ�
        /// </summary>
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        /// <summary>
        /// �㼯��
        /// </summary>
        public List<MedVitalSignPoint> Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
            }
        }

        private int _dotNumber = 0;
        /// <summary>
        /// С��λ��
        /// </summary>
        public int DotNumber
        {
            get
            {
                return _dotNumber;
            }
            set
            {
                if (value >= 0)
                {
                    _dotNumber = value;
                }
                else
                {
                    _dotNumber = 0;
                }
            }
        }

        /// <summary>
        /// ��ɫ
        /// </summary>
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                if (_symbol != null) _symbol.Pen.Color = _color;
            }
        }

        /// <summary>
        /// ���
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        /// <summary>
        /// Y��������
        /// </summary>
        public int YAxisIndex
        {
            get
            {
                return _yAxisIndex;
            }
            set
            {
                _yAxisIndex = value;
            }
        }

        /// <summary>
        /// ��ʶ
        /// </summary>
        public MedSymbol Symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                _symbol = value;
                _symbol.Pen.Color = _color;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public VitalSignCurveType CurveType
        {
            get
            {
                return _curveType;
            }
            set
            {
                _curveType = value;
            }
        }

        private bool _canUpdate = true;
        public bool CanUpdate
        {
            get
            {
                return _canUpdate;
            }
            set
            {
                _canUpdate = value;
            }
        }


        // �������̶� ���������� �����1���̶ȣ��򲻻�����
        protected double _lineMaxScale = 5.01;
        public double LineMaxscale
        {
            get { return _lineMaxScale - 0.01; }
            set { _lineMaxScale = value + 0.01; }
        }

        #endregion ����

        #region ����

        /// <summary>
        /// ���ӵ�
        /// </summary>
        /// <param name="time">ʱ��</param>
        /// <param name="value">ֵ</param>
        public void AddPoint(DateTime time, double value)
        {
            _points.Add(new MedVitalSignPoint(time, value, this));
        }

        public void AddPoint(DateTime time, double value, bool isKzhx)
        {
            MedVitalSignPoint point = new MedVitalSignPoint(time, value, this);
            point.IsKzhx = isKzhx;
            _points.Add(point);
        }

        /// <summary>
        /// ������е�
        /// </summary>
        public void Clear()
        {
            _points.Clear();
        }

        #endregion ����
    }
}
