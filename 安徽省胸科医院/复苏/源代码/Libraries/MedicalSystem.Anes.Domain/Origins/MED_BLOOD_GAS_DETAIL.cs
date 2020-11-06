namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 血气分析数据明细表
    /// </summary>
    [Table("MED_BLOOD_GAS_DETAIL")]
    public partial class MED_BLOOD_GAS_DETAIL : BaseModel
    {
        /// <summary>
        /// 主键 唯一标识;该字段对于med_blood_gas_master.DETAIL_ID 字段
        /// </summary>
        [Key]
        public string DETAIL_ID { get; set; }
        /// <summary>
        /// 主键 项目代码; 该字段对于med_blood_gas_dict.BLG_CODE 字段
        /// </summary>
        [Key]
        public string BLG_CODE { get; set; }
        /// <summary>
        /// 项目值
        /// </summary>
        public string BLG_VALUE { get; set; }
        /// <summary>
        /// 操作者
        /// </summary>
        public string OPERATOR { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public Nullable<DateTime> OP_DATE { get; set; }
        /// <summary>
        /// 结果正常标识;结果正常与否标志，N-正常  L-低  H-高
        /// </summary>
        public string ABNORMAL_INDICATOR { get; set; }
    }
}