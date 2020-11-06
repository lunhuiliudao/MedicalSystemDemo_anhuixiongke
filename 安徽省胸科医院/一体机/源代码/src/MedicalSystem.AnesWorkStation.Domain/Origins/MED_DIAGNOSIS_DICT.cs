namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 诊断字典
    /// </summary>
    [Table("MED_DIAGNOSIS_DICT")]
    public partial class MED_DIAGNOSIS_DICT : BaseModel
    {
        /// <summary>
        /// 主键 诊断代码
        /// </summary>
        [Key]
        public string DIAGNOSIS_CODE { get; set; }
        /// <summary>
        /// 诊断名称
        /// </summary>
        public string DIAGNOSIS_NAME { get; set; }
        /// <summary>
        /// 	正名标识
        /// </summary>
        public Nullable<Int32> STD_INDICATOR { get; set; }
        /// <summary>
        /// 标准化标识
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
        /// 诊断简称
        /// </summary>
        public string DIAGNOSIS_ABBR { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public Nullable<Int32> SORT_NO { get; set; }
    }
}