/*----------------------------------------------------------------
      // Copyright (C) 2008 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����MedDrugPoint.cs
      // �ļ�������������ҩ����
      //
      // 
      // ������ʶ��������-2008-10-20
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// ��ҩ������
    /// </summary>
    [Serializable]
    public enum PointType
    {
        /// <summary>
        /// ������
        /// </summary>
        SinglePoint,
        /// <summary>
        /// ������ҩ�ĵ�
        /// </summary>
        ProLonged
    }

    /// <summary>
    /// ������ʾ����
    /// </summary>
    [Serializable]
    public enum ProLongedShowType
    {
        /// <summary>
        /// ����
        /// </summary>
        Speed,
        /// <summary>
        /// ��λ
        /// </summary>
        Unit
        ,
        /// <summary>
        /// ����������
        /// </summary>
        TotalAndSpeed,
        /// <summary>
        /// Ĭ��ֵ
        /// </summary>
        Default
    }

    /// <summary>
    /// ��ҩ����
    /// </summary>
    [Serializable]
    public class MedDrugPoint
    {
        #region ���췽��

        public MedDrugPoint() { }

        #endregion ���췽��

        #region ����

        /// <summary>
        /// ������
        /// </summary>
        private PointType _pointType = PointType.SinglePoint;
        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        private DateTime _startTime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        private DateTime _endTime;
        /// <summary>
        /// ֵ
        /// </summary>
        private object _value;
        /// <summary>
        /// ��λ
        /// </summary>
        private string _unit;
        /// <summary>
        /// ÿ������
        /// </summary>
        private double _speed;

        /// <summary>
        /// ������ʾ����
        /// </summary>
        private ProLongedShowType _showType = ProLongedShowType.Default;

        /// <summary>
        /// Ũ��
        /// </summary>
        private double _thickNess;

        /// <summary>
        /// Ũ�ȵ�λ
        /// </summary>
        private string _thickNessUnit;

        /// <summary>
        /// ;��
        /// </summary>
        private string _route;

        /// <summary>
        /// ���ٵ�λ
        /// </summary>
        private string _speedUnit;

        private float _x1, _x2, _y;

        #endregion ����

        #region ����

        private MedDrugCurve _curve;
        public MedDrugCurve Curve
        {
            get
            {
                return _curve;
            }
            set
            {
                _curve = value;
            }
        }

        private bool _isArrow = false;
        public bool IsArrow
        {
            get
            {
                return _isArrow;
            }
            set
            {
                _isArrow = value;
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        public PointType PointType
        {
            get
            {
                return _pointType;
            }
            set
            {
                _pointType = value;
            }
        }

        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        /// <summary>
        /// ֵ
        /// </summary>
        public object Value
        {
            get
            {
                return _value;
                //if (_value != null)
                //{
                //    return _value;
                //}
                //else
                //{
                //    TimeSpan ts = _endTime - _startTime;
                //    return ts.TotalSeconds * _speed;
                //}
            }
            set
            {
                _value = value;
            }
        }

        private object _value2;
        /// <summary>
        /// �ڶ���ֵ
        /// </summary>
        public object Value2
        {
            get
            {
                return _value2;
            }
            set
            {
                _value2 = value;
            }
        }

        /// <summary>
        /// ��λ
        /// </summary>
        public string Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
            }
        }

        /// <summary>
        /// ÿ������
        /// </summary>
        public double Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        /// <summary>
        /// ������ʾ����
        /// </summary>
        public ProLongedShowType ShowType
        {
            get
            {
                return _showType;
            }
            set
            {
                _showType = value;
            }
        }

        /// <summary>
        /// Ũ��
        /// </summary>
        public double ThickNess
        {
            get
            {
                return _thickNess;
            }
            set
            {
                _thickNess = value;
            }
        }

        /// <summary>
        /// Ũ�ȵ�λ
        /// </summary>
        public string ThickNessUnit
        {
            get
            {
                return _thickNessUnit;
            }
            set
            {
                _thickNessUnit = value;
            }
        }

        /// <summary>
        /// ;��
        /// </summary>
        public string Route
        {
            get
            {
                return _route;
            }
            set
            {
                _route = value;
            }
        }

        /// <summary>
        /// ���ٵ�λ
        /// </summary>
        public string SpeedUnit
        {
            get
            {
                return _speedUnit;
            }
            set
            {
                _speedUnit = value;
            }
        }

        public float X1
        {
            get
            {
                return _x1;
            }
            set
            {
                _x1 = value;
            }
        }

        public float X2
        {
            get
            {
                return _x2;
            }
            set
            {
                _x2 = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        private string _text;
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

        #endregion ����
    }
}