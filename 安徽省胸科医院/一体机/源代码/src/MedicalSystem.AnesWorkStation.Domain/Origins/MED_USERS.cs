namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
   

    /// <summary>
    /// 实体 登录用户信息表
    /// </summary>
    [Table("MED_USERS")]
    public partial class MED_USERS : BaseModel
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
        /// 用户科室代码		对应科室代码表
        /// </summary>
        public string USER_DEPT_CODE { get; set; }
        /// <summary>
        /// 建立日期
        /// </summary>
        public Nullable<DateTime> CREATE_DATE { get; set; }
        /// <summary>
        /// 停用标识	;	T 有效    F无效
        /// </summary>
        public string IS_VALID { get; set; }
        /// <summary>
        /// 停用日期
        /// </summary>
        public Nullable<DateTime> STOP_DATE { get; set; }
        /// <summary>
        /// 描述	
        /// </summary>
        public string MEMO { get; set; }
        /// <summary>
        /// 登录模式;1-手术间模式，2-PACU模式,3-办公室模式
        /// </summary>
        public Nullable<Int32> RUN_MODE { get; set; }
        /// <summary>
        /// 登录位置信息说明;手术间模式下记录手术间号
        /// </summary>
        public string RUN_ADDRESS { get; set; }

        [NotMapped]
        public bool isMDSD { get; set; }
    }
}