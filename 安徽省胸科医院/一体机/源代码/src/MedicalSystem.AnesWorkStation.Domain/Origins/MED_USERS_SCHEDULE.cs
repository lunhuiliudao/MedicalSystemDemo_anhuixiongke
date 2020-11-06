using System;
using System.Collections.Generic;
using Dapper.Data;

/// <summary>
/// 改实体只做传输参数使用
/// </summary>
namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 实体 登录用户信息表
    /// </summary>
    [Table("MED_USERS")]
    public partial class MED_USERS_SCHEDULE : BaseModel
    {
        /// <summary>
        /// 主键 用户ID	
        /// </summary>
        [Key]
        public string USER_ID { get; set; }

        /// <summary>
        /// 医护人员工号	;	医护人员工号
        /// </summary>
        public string USER_JOB_ID { get; set; }
        /// <summary>
        /// 登录名称	；	登录账号
        /// </summary>
        public string LOGIN_NAME { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string LOGIN_PWD { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string USER_NAME { get; set; }
        /// <summary>
        /// 停用标识	;	T 有效    F无效
        /// </summary>
        public string IS_VALID { get; set; }
    }
}