namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 抢救专家组与科室对应表
    /// </summary>
    [Table("MED_RESCUE_GROUP_VS_DEPT")]
    public partial class MED_RESCUE_GROUP_VS_DEPT : BaseModel
    {
        /// <summary>
        /// 主键 专家组ID
        /// </summary>
        [Key]
        public string GROUP_ID { get; set; }
        /// <summary>
        /// 主键 科室代码
        /// </summary>
        [Key]
        public string DEPT_CODE { get; set; }
    }
}