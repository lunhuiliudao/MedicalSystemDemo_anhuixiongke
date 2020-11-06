namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 应用程序字典表
    /// </summary>
    [Table("MED_APPLICATIONS")]
    public partial class MED_APPLICATIONS : BaseModel
    {
        /// <summary>
        /// 主键 系统ID
        /// </summary>
        [Key]
        public string APP_ID { get; set; }
        /// <summary>
        /// 系统名称
        /// </summary>
        public string APP_NAME { get; set; }
        /// <summary>
        /// 系统描述
        /// </summary>
        public string MEMO { get; set; }
    }
}