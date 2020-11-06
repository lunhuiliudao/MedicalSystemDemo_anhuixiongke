namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 角色信息表
    /// </summary>
    [Table("MED_ROLES")]
    public partial class MED_ROLES : BaseModel
    {
        /// <summary>
        /// 主键 角色ID
        /// </summary>
        [Key]
        public string ROLE_ID { get; set; }
        /// <summary>
        /// 应用程序ID
        /// </summary>
        public string APP_ID { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string ROLE_NAME { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        public string MEMO { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public Nullable<DateTime> CREATE_DATE { get; set; }
    }
}