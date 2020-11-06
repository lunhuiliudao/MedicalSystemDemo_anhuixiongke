// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      VitalSignYAxisScaleValue.cs
// 功能描述(Description)：    体征曲线刻度实体
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.ComponentModel;

namespace MedicalSystem.AnesWorkStation.Model.InOperationModel
{
    /// <summary>
    /// 体征曲线刻度实体
    /// </summary>
    public class VitalSignYAxisScaleValue
    {
        private string _showText;                              // 显示文本
        private double _value;                                 // 刻度值
        private int _startValue;                               // Y轴起始值
        private int _endValue;                                 // Y轴最大值
        private int _minScaleValue;                            // 最小刻度值
        private int _maxScaleValue;                            // 最大刻度值
        private string _units;                                 // 单位

        /// <summary>
        /// 刻度值
        /// </summary>
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

        /// <summary>
        /// 显示文本
        /// </summary>
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

        /// <summary>
        /// Y轴开始值
        /// </summary>
        [Description("Y轴开始值")]
        public int StartValue
        {
            get { return _startValue; }
            set { _startValue = value; }
        }

        /// <summary>
        /// Y轴最大值
        /// </summary>
        [Description("Y轴最大值")]
        public int EndValue
        {
            get { return _endValue; }
            set { _endValue = value; }
        }

        /// <summary>
        /// 最小刻度值
        /// </summary>
        [Description("最小刻度值")]
        public int MinScaleValue
        {
            get { return _minScaleValue; }
            set { _minScaleValue = value; }
        }

        /// <summary>
        /// 最大刻度值
        /// </summary>
        [Description("最大刻度值")]
        public int MaxScaleValue
        {
            get { return _maxScaleValue; }
            set { _maxScaleValue = value; }
        }

        /// <summary>
        /// 单位
        /// </summary>
        [Description("单位")]
        public string Units
        {
            get { return _units; }
            set { _units = value; }
        }
    }

    /// <summary>
    /// 刻度实体类，方便界面绑定使用
    /// </summary>
    public class VitalSignYAxisModel : ObservableObject
    {
        private List<VitalSignYAxisScaleValue> _scaleValues;                            // 刻度列表

        /// <summary>
        /// 刻度值
        /// </summary>
        [Description("刻度值")]
        public List<VitalSignYAxisScaleValue> ScaleValues
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

        /// <summary>
        /// 无参构造
        /// </summary>
        public VitalSignYAxisModel() { }

        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="scaleValues">曲线刻度列表</param>
        public VitalSignYAxisModel(List<VitalSignYAxisScaleValue> scaleValues)
        {
            _scaleValues = scaleValues;
        }
    }
}
