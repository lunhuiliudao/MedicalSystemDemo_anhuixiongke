// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      BreathParaModel.cs
// 功能描述(Description)：    呼吸参数实体类
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
using System.Collections.Generic;

namespace MedicalSystem.AnesWorkStation.Model.InOperationModel
{
    /// <summary>
    /// 呼吸参数明细实体类
    /// </summary>
    public class BreathParaDetail
    {
        private string _TopParamVal;                             // 上边参数值
        private string _LeftParamVal;                            // 左边参数值
        private string _RightParamVal;                           // 右边参数值

        /// <summary>
        /// 上边参数值
        /// </summary>
        public string TopParamVal
        {
            get { return _TopParamVal; }
            set { _TopParamVal = value; }
        }

        /// <summary>
        /// 左边参数值
        /// </summary>
        public string LeftParamVal
        {
            get { return _LeftParamVal; }
            set { _LeftParamVal = value; }
        }

        /// <summary>
        /// 右边参数值
        /// </summary>
        public string RightParamVal
        {
            get { return _RightParamVal; }
            set { _RightParamVal = value; }
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        public BreathParaDetail() 
        {
        }

        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="TopParamVal">上边参数值</param>
        /// <param name="LeftParamVal">左边参数值</param>
        /// <param name="RightParamVal">右边参数值</param>
        public BreathParaDetail(string TopParamVal, string LeftParamVal, string RightParamVal) 
        {
            _TopParamVal = TopParamVal;
            _LeftParamVal = LeftParamVal;
            _RightParamVal = RightParamVal;
        }
    }

    /// <summary>
    /// 呼吸参数实体类
    /// </summary>
    public class BreathParaModel : ObservableObject
    {
        private string _TopParamName;                        // 上边参数名称
        private string _TopParamCode;                        // 上边参数代码
        private string _LeftParamName;                       // 左边参数名称
        private string _LeftParamCode;                       // 左边参数代码
        private string _RightParamName;                      // 右边参数名称
        private string _RightParamCode;                      // 右边参数代码
        private Dictionary<DateTime, BreathParaDetail> _breathParalList = new Dictionary<DateTime, BreathParaDetail>(); // 呼吸参数明细
         
        /// <summary>
        /// 上边参数名称
        /// </summary>
        public string TopParamName
        {
            get { return _TopParamName; }
            set { _TopParamName = value; }
        }
        
        /// <summary>
        /// 上边参数代码
        /// </summary>
        public string TopParamCode
        {
            get { return _TopParamCode; }
            set { _TopParamCode = value; }
        }
        
        /// <summary>
        /// 左边参数名称
        /// </summary>
        public string LeftParamName
        {
            get { return _LeftParamName; }
            set { _LeftParamName = value; }
        }
        
        /// <summary>
        /// 左边参数代码
        /// </summary>
        public string LeftParamCode
        {
            get { return _LeftParamCode; }
            set { _LeftParamCode = value; }
        }
        
        /// <summary>
        /// 右边参数名称
        /// </summary>
        public string RightParamName
        {
            get { return _RightParamName; }
            set { _RightParamName = value; }
        }
        
        /// <summary>
        /// 右边参数代码
        /// </summary>
        public string RightParamCode
        {
            get { return _RightParamCode; }
            set { _RightParamCode = value; }
        }

        /// <summary>
        /// 时间明细
        /// </summary>
        public Dictionary<DateTime, BreathParaDetail> BreathParalList
        {
            get
            {
                return _breathParalList;
            }
            set
            {
                _breathParalList = value;
            }
        }

        /// <summary>
        /// y坐标值
        /// </summary>
        public Nullable<double> YLocation { get; set; }

        /// <summary>
        /// Y坐标索引
        /// </summary>
        public int YAxisIndex { get; set; }
    }
}
