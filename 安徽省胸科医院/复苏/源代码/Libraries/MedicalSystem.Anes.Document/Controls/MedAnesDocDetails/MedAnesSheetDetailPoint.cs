/*----------------------------------------------------------------
      // Copyright (C) 2008 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����MedAnesSheetDetailPoint.cs
      // �ļ�����������������ϸ������
      //
      // 
      // ������ʶ��������-2008-10-24
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using MedicalSystem.Anes.Domain;


namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// ������ϸ������
    /// </summary>
    public class MedAnesSheetDetailPoint
    {

        #region ���췽��

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="text">�ı������ƣ�</param>
        public MedAnesSheetDetailPoint(DateTime startTime, string text)
        {
            _startTime = startTime;
            _text = text;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="text">�ı������ƣ�</param>
        public MedAnesSheetDetailPoint(DateTime startTime, string text, MED_ANESTHESIA_EVENT row)
        {
            _startTime = startTime;
            _text = text;
            _datarow = row;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="endTime">����ʱ��</param>
        /// <param name="text">�ı������ƣ�</param>
        public MedAnesSheetDetailPoint(DateTime startTime, DateTime endTime, string text,MED_ANESTHESIA_EVENT row)
            : this(startTime, text, row)
        {
            _endTime = endTime;
            _pointType = PointType.ProLonged;

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="text">�ı������ƣ�</param>
        /// <param name="value">ֵ</param>
        /// <param name="unit">��λ</param>
        /// <param name="route">;��</param>
        public MedAnesSheetDetailPoint(DateTime startTime, string text, double value, string unit, string route, MED_ANESTHESIA_EVENT row)
            : this(startTime, text, row)
        {
            _value = value;
            _unit = unit;
            _route = route;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="endTime">����ʱ��</param>
        /// <param name="text">�ı������ƣ�</param>
        /// <param name="value">ֵ</param>
        /// <param name="unit">��λ</param>
        /// <param name="route">;��</param>
        public MedAnesSheetDetailPoint(DateTime startTime, DateTime endTime, string text, double value, string unit, string route, MED_ANESTHESIA_EVENT row)
            : this(startTime, text, value, unit, route, row)
        {
            _endTime = endTime;
            _pointType = PointType.ProLonged;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="text">�ı������ƣ�</param>
        /// <param name="value">ֵ</param>
        /// <param name="unit">��λ</param>
        public MedAnesSheetDetailPoint(string text, double value, string unit, MED_ANESTHESIA_EVENT row)
        {
            _text = text;
            _value = value;
            _unit = unit;
            _datarow = row;
        }

        #endregion ���췽��

        #region ����

        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        private DateTime _startTime;

        /// <summary>
        /// ����ʱ��
        /// </summary>
        private DateTime _endTime;

        /// <summary>
        /// ������
        /// </summary>
        private PointType _pointType = PointType.SinglePoint;

        /// <summary>
        /// �ı������ƣ�
        /// </summary>
        private string _text;

        /// <summary>
        /// ֵ
        /// </summary>
        private double _value;

        /// <summary>
        /// ��λ
        /// </summary>
        private string _unit;

        /// <summary>
        /// ;��
        /// </summary>
        private string _route;

        private RectangleF _rectF;


        private MED_ANESTHESIA_EVENT _datarow;

        #endregion ����

        #region ����

        private object _tag;
        public object Tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        }

        public MED_ANESTHESIA_EVENT DataRow
        {
            get { return _datarow; }
        }

        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        [Description("��ʼʱ��")]
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
        [Description("����ʱ��")]
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
        /// �ı������ƣ�
        /// </summary>
        [Description("����")]
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
        /// ֵ
        /// </summary>
        [Description("ֵ")]
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        /// <summary>
        /// ��λ
        /// </summary>
        [Description("��λ")]
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
        /// ;��
        /// </summary>
        [Description(";��")]
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

        private double _thickNess;
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

        private string _thickNessUnit;
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

        private string _speedUnit;
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

        private double _speed;
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

        public RectangleF RectF
        {
            get
            {
                return _rectF;
            }
            set
            {
                _rectF = value;
            }
        }

        private int _index;
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }

        private MedAnesSheetDetailCollection _collection;
        public MedAnesSheetDetailCollection Collection
        {
            get
            {
                return _collection;
            }
            set
            {
                _collection = value;
            }
        }

        private Color _color;
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
            }
        }

        private string _attrubite;
        public string Attrubite
        {
            get
            {
                return _attrubite;
            }
            set
            {
                _attrubite = value;
            }
        }

        #endregion ����
    }
}
