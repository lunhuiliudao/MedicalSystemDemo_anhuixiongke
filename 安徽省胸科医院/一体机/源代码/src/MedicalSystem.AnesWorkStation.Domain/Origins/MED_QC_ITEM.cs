using Dapper.Data;
using System;

namespace MedicalSystem.AnesWorkStation.Domain
{
    [Table("MED_QC_ITEM")]
    public partial class MED_QC_ITEM : BaseModel
    {
        /// <summary>
        /// 质控项目编号
        /// </summary>
        [Key]
        public string QC_CODE { get; set; }
        /// <summary>
        /// 质控项目名称
        /// </summary>
        public string QC_NAME { get; set; }
        /// <summary>
        /// 获取数据条件
        /// </summary>
        public string CONDITION { get; set; }
        /// <summary>
        /// 省级平台对应的编码,有对应的上报编码则上报省级质控平台。无编码的为院内质控项目
        /// </summary>
        public string REPORT_CODE { get; set; }
        /// <summary>
        /// 不良事件标识,1是,0不是
        /// </summary>
        public decimal AE_MARK { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public decimal SORT_NO { get; set; }

        /// <summary>
        /// 项目名称简写
        /// </summary>
        public string SHORT_NAME { get; set; }

        /// <summary>
        /// 获取不良事件数据条件
        /// </summary>
        public string AE_CONDITION { get; set; }

    }
}
