using System;
using System.Collections.Generic;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.Domain.Origins
{
    /// <summary>
    /// 实体 登录用户权限表
    /// </summary>
    [Table("MED_WECHAT_PERMISSIONS")]
    public class MED_WECHAT_PERMISSIONS : BaseModel
    {
        /// <summary>
        /// 主键 用户权限ID	
        /// </summary>
        [Key]
        public string PERMISSION_ID { get; set; }
        /// <summary>
        /// 权限功能名称
        /// </summary>
        public string PERMISSION_NAME { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public string ROLE_NAME { get; set; }
        /// <summary>
        /// 公众号名称
        /// </summary>
        public string PLAT_NAME { get; set; }
       
    }
}
