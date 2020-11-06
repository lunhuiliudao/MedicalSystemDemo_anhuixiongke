/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedVitalSignYAxis.cs
      // 文件功能描述：体征曲线Y坐标类
      //
      // 
      // 创建标识：戴呈祥-2008-10-21
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{

    [Serializable]
    public class MedVitalSignYAxisScaleValueList : List<MedVitalSignYAxisScaleValue>
    {
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (MedVitalSignYAxisScaleValue scale in this)
            {
                stringBuilder.AppendLine(scale.Value + "," + scale.ShowText);
            }
            return stringBuilder.ToString();
        }

        public static MedVitalSignYAxisScaleValueList Parse(string listStrings)
        {
            MedVitalSignYAxisScaleValueList result = new MedVitalSignYAxisScaleValueList();
            if (listStrings != null)
            {
                string[] lists = listStrings.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string list in lists)
                {
                    string[] ls = list.Split(',');
                    MedVitalSignYAxisScaleValue scale = new MedVitalSignYAxisScaleValue();
                    scale.Value = double.Parse(ls[0]);
                    scale.ShowText = ls[1];
                    result.Add(scale);
                }
            }
            return result;
        }
    }

    [Serializable]
    public class MedVitalSignYAxisScaleValue
    {
        private string _showText;
        private double _value;
        [Description("刻度值")]
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
        [Description("显示文本")]
        public string ShowText
        {
            get
            {
                return _showText;
            }
            set
            {
                _showText = value;
            }
        }

        public override string ToString()
        {
            return _showText + "[" + _value.ToString() + "]";
        }
    }

    /// <summary>
    /// 体征曲线Y坐标类
    /// </summary>
    [Serializable]
    public class MedVitalSignYAxis
    {
        #region 构造方法

        public MedVitalSignYAxis() { }

        public MedVitalSignYAxis(MedVitalSignYAxisScaleValueList scaleValues, string unit)
        {
            _scaleValues = scaleValues;
            _unit = unit;
        }

        public MedVitalSignYAxis(double[] scaleValues, string unit)
        {
            MedVitalSignYAxisScaleValueList scales = new MedVitalSignYAxisScaleValueList();
            for (int i = 0; i < scaleValues.Length; i++)
            {
                scales.Add(new MedVitalSignYAxisScaleValue());
                scales[i].Value = scaleValues[i];
            }
            _scaleValues = scales;
            _unit = unit;
        }

        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 刻度值
        /// </summary>
        private MedVitalSignYAxisScaleValueList _scaleValues;

        /// <summary>
        /// 单位
        /// </summary>
        private string _unit;

        #endregion 变量

        #region 属性

        /// <summary>
        /// 刻度值
        /// </summary>
        [Description("刻度值")]
        public MedVitalSignYAxisScaleValueList ScaleValues
        {
            get
            {
                return _scaleValues;
            }
            set
            {
                _scaleValues = value;
            }
        }

        private string _axisName = "Y坐标轴";
        /// <summary>
        /// 刻度值
        /// </summary>
        [Description("坐标轴名称")]
        public string AxisName
        {
            get
            {
                return _axisName;
            }
            set
            {
                _axisName = value;
            }
        }

        /// <summary>
        /// 单位
        /// </summary>
        [Description("单位")]
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

        #endregion 属性

        public override string ToString()
        {
            return _axisName;
        }
    }
}
