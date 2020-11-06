namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 院区代码表
    /// </summary>
    [Table("MED_HOSP_BRANCH_DICT")]
    public partial class MED_HOSP_BRANCH_DICT : BaseModel
    {
        /// <summary>
        /// 主键 院区代码
        /// </summary>
        [Key]
        public string HOSP_CODE { get; set; }
        /// <summary>
        /// 院区名称
        /// </summary>
        public string HOSP_NAME { get; set; }
        /// <summary>
        /// 上级院区代码
        /// </summary>
        public string PARENT_HOSP_ID { get; set; }
        /// <summary>
        /// 输入码
        /// </summary>
        public string INPUT_CODE { get; set; }
    }
}