namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 登录用户信息表
    /// </summary>
    [Table("MED_USERS_ROLES")]
    public partial class MED_USERS_ROLES : BaseModel
    {
        /// <summary>
        /// 主键 用户ID	
        /// </summary>
        [Key]
        public string USER_ID { get; set; }
        /// <summary>
        /// 主键 角色ID
        /// </summary>
        [Key]
        public string ROLE_ID { get; set; }
    }
}