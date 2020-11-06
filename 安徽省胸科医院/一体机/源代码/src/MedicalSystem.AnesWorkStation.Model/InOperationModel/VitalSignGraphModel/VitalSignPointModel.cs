// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      VitalSignPointModel.cs
// 功能描述(Description)：    体征曲线单个时间节点的实体类
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

namespace MedicalSystem.AnesWorkStation.Model.InOperationModel
{
    /// <summary>
    /// 体征曲线单个时间节点的实体类
    /// </summary>
    public class VitalSignPointModel : ObservableObject
    {
        private VitalSignCurveDetailModel _curve;                                  // 节点的明细
        private SymbolModel _symbol = new SymbolModel(SymbolType.Circle);          // 节点的图标
        private DateTime _time;                                                    // 节点对应的时间点
        private object _value;                                                     // 节点的值
        private bool isModify;                                                     // 是否可修改

        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="time">时间节点</param>
        /// <param name="value">值</param>
        /// <param name="curve">明细实体</param>
        /// <param name="symbol">事件图标</param>
        /// <param name="flag">修改标识：为1时标识可修改</param>
        public VitalSignPointModel(DateTime time, object value, VitalSignCurveDetailModel curve, SymbolModel symbol, string flag)
        {
            _time = time;
            _value = value;
            _curve = curve;
            _symbol = symbol;
            if (!string.IsNullOrEmpty(flag) && flag.Equals("1"))
            {
                isModify = true;
            }
        }

        /// <summary>
        /// 体征单个节点的明细
        /// </summary>
        public VitalSignCurveDetailModel Curve
        {
            get
            {
                return _curve;
            }
        }
        
        /// <summary>
        /// 节点的图标
        /// </summary>
        public SymbolModel Symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                _symbol = value;
            }
        }

        /// <summary>
        /// 节点对应的时间点
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
        
        /// <summary>
        /// 是否可修改
        /// </summary>
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
    }
}
