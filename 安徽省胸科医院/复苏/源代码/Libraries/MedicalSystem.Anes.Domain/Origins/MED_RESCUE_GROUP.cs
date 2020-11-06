namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 抢救呼叫组
    /// </summary>
    [Table("MED_RESCUE_GROUP")]
    public partial class MED_RESCUE_GROUP : BaseModel
    {
        /// <summary>
        /// 主键 专家组ID
        /// </summary>
        [Key]
        public string GROUP_ID { get; set; }
        /// <summary>
        /// 专家组名称
        /// </summary>
        public string GROUP_NAME { get; set; }
    }
}