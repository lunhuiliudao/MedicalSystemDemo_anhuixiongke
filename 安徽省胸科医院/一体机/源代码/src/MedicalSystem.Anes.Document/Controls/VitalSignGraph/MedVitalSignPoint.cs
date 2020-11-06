/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedVitalSignPoint.cs
      // 文件功能描述：体征曲线点类
      //
      // 
      // 创建标识：戴呈祥-2008-10-21
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 体征曲线点类
    /// </summary>
    [Serializable]
    public class MedVitalSignPoint
    {

        #region 构造方法

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

        #endregion 构造方法

        #region 变量

        private MedVitalSignCurve _curve;
        public MedVitalSignCurve Curve
        {
            get
            {
                return _curve;
            }
        }

        /// <summary>
        /// 时间
        /// </summary>
        private DateTime _time;

        /// <summary>
        /// 值
        /// </summary>
        private object _value;

        #endregion 变量
        private float _x, _y;


        #region 属性

        /// <summary>
        /// 时间
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
        /// 值
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
        /// 20110818新增 ，是否为修改点
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
        #endregion 属性
    }
}
