/*----------------------------------------------------------------
      // Copyright (C) 2008 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����MedDrugCurve.cs
      // �ļ�������������ҩ������
      //
      // 
      // ������ʶ��������-2008-10-20
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// ��ҩ������
    /// </summary>
    [Serializable]
    public class MedDrugCurve
    {
        #region ���췽��

        public MedDrugCurve()
        {
        }

        public MedDrugCurve(string text, Color color) 
        { 
            _text = text;
            _color = color; 
        }

        #endregion ���췽��

        #region ����

        /// <summary>
        /// ��ɫ
        /// </summary>
        private Color _color = Color.Blue;

        /// <summary>
        /// ����
        /// </summary>
        private string _text;

        /// <summary>
        /// �����ĵ�
        /// </summary>
        private List<MedDrugPoint> _points = new List<MedDrugPoint>();

        #endregion ����

        #region ����

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

        /// <summary>
        /// ����
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

        public string DisplayText = "";
        public string DisplayText2 = "";
        public string DisplayUnit = "";
        public string DisplayUnit2 = "";
        private string _text2 = null;
        /// <summary>
        /// �ڶ�����
        /// </summary>
        public string Text2
        {
            get
            {
                return _text2;
            }
            set
            {
                _text2 = value;
            }
        }

        private string _unit2 = null;
        /// <summary>
        /// �ڶ�����
        /// </summary>
        public string Unit2
        {
            get
            {
                return _unit2;
            }
            set
            {
                _unit2 = value;
            }
        }

        /// <summary>
        /// ֵ�������м�
        /// </summary>
        private bool _centerValue = false;
        public bool CenterValue
        {
            get
            {
                return _centerValue;
            }
            set
            {
                _centerValue = value;
            }
        }

        /// <summary>
        /// �����ĵ�
        /// </summary>
        public List<MedDrugPoint> Points
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

        /// <summary>
        /// ����
        /// </summary>
        public double Totalvalue
        {
            get
            {
                double totalValue = 0;
                foreach (MedDrugPoint point in _points)
                {
                    if (point.Value is double)
                    {
                        totalValue += (double)point.Value;
                    }
                }
                return totalValue;
            }
        }

        private string _unit;
        /// <summary>
        /// ��λ
        /// </summary>
        public string Unit
        {
            get
            {
                if(string.IsNullOrEmpty(_unit))
                {
                    foreach (MedDrugPoint point in _points)
                    {
                        if (!string.IsNullOrEmpty(point.Unit))
                        {
                            _unit = point.Unit;
                            break;
                        }
                    }
                }
                return _unit;
            }
            set
            {
                _unit = value;
            }
        }

        private string _route;
        /// <summary>
        /// ;��
        /// </summary>
        public string Route
        {
            get
            {
                if (string.IsNullOrEmpty(_route))
                {
                    foreach (MedDrugPoint point in _points)
                    {
                        if (!string.IsNullOrEmpty(point.Route))
                        {
                            _route = point.Route;
                            break;
                        }
                    }
                }
                return _route;
            }
            set
            {
                _route = value;
            }
        }

        private string _speedUnit;
        /// <summary>
        /// ����
        /// </summary>
        public string SpeedUnit
        {
            get
            {
                if (string.IsNullOrEmpty(_speedUnit))
                {
                    foreach (MedDrugPoint point in _points)
                    {
                        if (!string.IsNullOrEmpty(point.SpeedUnit))
                        {
                            _speedUnit = point.SpeedUnit;
                            break;
                        }
                    }
                }
                return _speedUnit;
            }
            set
            {
                _speedUnit = value;
            }
        }

        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                if (_points != null && _points.Count > 0)
                {
                    return _points[0].StartTime;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        
        }

        public static readonly double MINVALUE = -100000;
        /// <summary>
        /// ���ֵ
        /// </summary>
        private double _maxValue = MINVALUE;
        public double MaxValue
        {
            get
            {
                return _maxValue;
            }
            set
            {
                _maxValue = value;
            }
        }

        private float _Y1;
        [System.ComponentModel.Browsable(false)]
        public float Y1
        {
            get
            {
                return _Y1;
            }
            set
            {
                _Y1 = value;
            }
        }

        private float _Y2;
        [System.ComponentModel.Browsable(false)]
        public float Y2
        {
            get
            {
                return _Y2;
            }
            set
            {
                _Y2 = value;
            }
        }

        #endregion ����

        #region ����

        /// <summary>
        /// ���ɵ�
        /// </summary>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="value">����</param>
        /// <param name="unit">��λ</param>
        /// <param name="thickNess">Ũ��</param>
        /// <param name="thickNessUnit">Ũ�ȵ�λ</param>
        /// <param name="route">;��</param>
        /// <returns>��</returns>
        private MedDrugPoint GenPoint(DateTime startTime, double value, string unit, double thickNess, string thickNessUnit, string route)
        {
            MedDrugPoint point = new MedDrugPoint();
            point.StartTime = startTime;
            point.Value = value;
            point.Unit = unit;
            point.ThickNess = thickNess;
            point.ThickNessUnit = thickNessUnit;
            point.Route = route;
            return point;
        }

        private MedDrugPoint GenPoint(DateTime startTime, double value, string unit, double thickNess, string thickNessUnit, string route,DateTime endTime,double speed,string speedUnit,PointType pointType)
        {
            MedDrugPoint point = GenPoint(startTime,value,unit,thickNess,thickNessUnit,route);
            point.EndTime = endTime;
            point.PointType = pointType;
            point.Speed = speed;
            point.SpeedUnit = speedUnit;
            return point;
        }

        /// <summary>
        /// ���ӵ�
        /// </summary>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="value">����</param>
        /// <param name="unit">��λ</param>
        /// <param name="thickNess">Ũ��</param>
        /// <param name="thickNessUnit">Ũ�ȵ�λ</param>
        /// <param name="route">;��</param>
        public void AddPoint(DateTime startTime, double value, string unit, double thickNess, string thickNessUnit, string route)
        {
            _points.Add(GenPoint(startTime,value,unit, thickNess,thickNessUnit,route));
        }

        public MedDrugPoint AddPoint(DateTime startTime, double value, string unit, double thickNess, string thickNessUnit, string route, DateTime endTime, double speed, string speedUnit, PointType pointType)
        {
            MedDrugPoint point = GenPoint(startTime, value, unit, thickNess, thickNessUnit, route, endTime, speed, speedUnit, pointType);
            _points.Add(point);
            return point;
        }

        #endregion ����
    }
}
