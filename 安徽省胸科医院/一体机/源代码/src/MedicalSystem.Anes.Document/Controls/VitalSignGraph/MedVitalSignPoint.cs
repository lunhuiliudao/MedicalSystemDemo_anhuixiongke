/*----------------------------------------------------------------
      // Copyright (C) 2008 ���˹��(����)ҽ�ƿƼ���չ���޹�˾
      // �ļ�����MedVitalSignPoint.cs
      // �ļ������������������ߵ���
      //
      // 
      // ������ʶ��������-2008-10-21
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// �������ߵ���
    /// </summary>
    [Serializable]
    public class MedVitalSignPoint
    {

        #region ���췽��

        public MedVitalSignPoint(DateTime time,object value,MedVitalSignCurve curve)
        {
            _time = time;
            _value = value;
            _curve = curve;
        }
        public MedVitalSignPoint(DateTime time, object value, MedVitalSignCurve curve,bool isModify)
        {
            _time = time;
            _value = value;
            _curve = curve;
            this.isModify = isModify;
        }

        #endregion ���췽��

        #region ����

        private MedVitalSignCurve _curve;
        public MedVitalSignCurve Curve
        {
            get
            {
                return _curve;
            }
        }

        /// <summary>
        /// ʱ��
        /// </summary>
        private DateTime _time;

        /// <summary>
        /// ֵ
        /// </summary>
        private object _value;

        #endregion ����
        private float _x, _y;


        #region ����

        /// <summary>
        /// ʱ��
        /// </summary>
        public DateTime Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
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
            }
            set
            {
                _value = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
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

        private bool _isKzhx = false;
        public bool IsKzhx
        {
            get
            {
                return _isKzhx;
            }
            set
            {
                _isKzhx = value;
            }
        }
        /// <summary>
        /// 20110818���� ���Ƿ�Ϊ�޸ĵ�
        /// </summary>
        private bool isModify = false;
        public bool IsModify
        {
            get
            {
                return isModify;
            }
            set
            {
                isModify = value;
            }
        }
        #endregion ����
    }
}
