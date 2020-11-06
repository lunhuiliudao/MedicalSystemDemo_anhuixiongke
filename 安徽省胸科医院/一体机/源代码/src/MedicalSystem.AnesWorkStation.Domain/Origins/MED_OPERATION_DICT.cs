namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 手术字典表
    /// </summary>
    [Table("MED_OPERATION_DICT")]
    public partial class MED_OPERATION_DICT : BaseModel
    {
        /// <summary>
        /// 主键 手术编码
        /// </summary>
        [Key]
        public string OPER_CODE { get; set; }
        /// <summary>
        /// 手术名称
        /// </summary>
        public string OPER_NAME { get; set; }
        /// <summary>
        /// 手术等级
        /// </summary>
        public string OPER_SCALE { get; set; }
        /// <summary>
        /// 证明标志
        /// </summary>
        public Nullable<Int32> STD_INDICATOR { get; set; }
        /// <summary>
        /// 标准化标志
        /// </summary>
        public Nullable<Int32> APPROVED_INDICATOR { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public Nullable<DateTime> CREATE_DATE { get; set; }
        /// <summary>
        /// 输入码
        /// </summary>
        public string INPUT_CODE { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public Nullable<Int32> SORT_NO { get; set; }
    }
}