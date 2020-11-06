namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 报警个性化配置字典表
    /// </summary>
    [Table("MED_PAT_MONITOR_DATA_DICT")]
    public partial class MED_PAT_MONITOR_DATA_DICT : BaseModel
    {
                [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 住院次数
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 患者入科标识
        /// </summary>
        public Nullable<Int32> DEP_ID { get; set; }
        /// <summary>
        /// 体征名称
        /// </summary>
        public string MONITOR_DATA_NAME { get; set; }
        /// <summary>
        /// 主键 体征标识
        /// </summary>
        [Key]
        public string DB_DATA_NAME { get; set; }
        /// <summary>
        /// 合理值下限
        /// </summary>
        public Nullable<decimal> LOW_SIGNS_VALUES { get; set; }
        /// <summary>
        /// 合理值上限
        /// </summary>
        public Nullable<decimal> HIGH_SIGNS_VALUES { get; set; }

    }
}