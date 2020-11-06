// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      DrugPointModel.cs
// 功能描述(Description)：    用药节点的实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight;
using System;

namespace MedicalSystem.AnesWorkStation.Model.InOperationModel.DrugGraphModel
{
    /// <summary>
    /// 用药点类型
    /// </summary>
    [Serializable]
    public enum PointType
    {
        /// <summary>
        /// 单个点
        /// </summary>
        SinglePoint,
        /// <summary>
        /// 持续用药的点
        /// </summary>
        ProLonged
    }

    /// <summary>
    /// 持续显示类型
    /// </summary>
    [Serializable]
    public enum ProLongedShowType
    {
        /// <summary>
        /// 流速
        /// </summary>
        Speed,
        /// <summary>
        /// 单位
        /// </summary>
        Unit,
        /// <summary>
        /// 总量和流速
        /// </summary>
        TotalAndSpeed
    }

    /// <summary>
    /// 用药点类
    /// </summary>
    [Serializable]
    public class DrugPointModel : ObservableObject
    {
        #region 构造方法
        //public MedDrugPoint() { }

        #endregion 构造方法

        #region 变量

        /// <summary>
        /// 点类型
        /// </summary>
        private PointType _pointType = PointType.SinglePoint;
        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime _startTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        private DateTime _endTime;
        /// <summary>
        /// 值
        /// </summary>
        private object _value;
        /// <summary>
        /// 单位
        /// </summary>
        private string _unit;
        /// <summary>
        /// 每秒流速
        /// </summary>
        private double _speed;

        /// <summary>
        /// 持续显示类型
        /// </summary>
        private ProLongedShowType _showType = ProLongedShowType.Speed;

        /// <summary>
        /// 浓度
        /// </summary>
        private double _thickNess;

        /// <summary>
        /// 浓度单位
        /// </summary>
        private string _thickNessUnit;

        /// <summary>
        /// 途径
        /// </summary>
        private string _route;

        /// <summary>
        /// 流速单位
        /// </summary>
        private string _speedUnit;

        private float _x1, _x2, _y;

        #endregion 变量

        #region 属性

        private DrugCurveModel _curve;
        public DrugCurveModel Curve
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
        /// 点类型
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
        /// 开始时间
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
        /// 结束时间
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

        private object _value2;
        /// <summary>
        /// 第二组值
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
        /// 单位
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
        /// 每秒流速
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
        /// 持续显示类型
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
        /// 浓度
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
        /// 浓度单位
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
        /// 途径
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
        /// 流速单位
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

        #endregion 属性
    }
}
