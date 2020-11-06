namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 角色权限信息表
    /// </summary>
    [Table("MED_ROLES_PERMISSIONS")]
    public partial class MED_ROLES_PERMISSIONS : BaseModel
    {
        /// <summary>
        /// 主键 角色ID
        /// </summary>
        [Key]
        public string ROLE_ID { get; set; }
        /// <summary>
        /// 主键 权限ID
        /// </summary>
        [Key]
        public string PERMISSION_ID { get; set; }
    }
}