namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 用户信息（HIS）
    /// </summary>
    [Table("MED_HIS_USERS")]
    public partial class MED_HIS_USERS : BaseModel
    {
        /// <summary>
        /// 主键 医护人员工号	;医护人员工号
        /// </summary>
        [Key]
        public string USER_JOB_ID { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string USER_NAME { get; set; }
        /// <summary>
        /// 所在科室	;对应科室代码表
        /// </summary>
        public string USER_DEPT_CODE { get; set; }
        /// <summary>
        /// 输入码	
        /// </summary>
        public string INPUT_CODE { get; set; }
        /// <summary>
        /// 职别	;医生、护士
        /// </summary>
        public string USER_JOB { get; set; }
        /// <summary>
        /// 用户状态;1 正常，0 停用
        /// </summary>
        public Nullable<Int32> USER_STATUS { get; set; }
        /// <summary>
        /// 创建日期	
        /// </summary>
        public Nullable<DateTime> CREATE_DATE { get; set; }
        /// <summary>
        /// 停用日期
        /// </summary>
        public Nullable<DateTime> STOP_DATE { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public Nullable<Int32> SORT_NO { get; set; }
        /// <summary>
        /// 备用字段
        /// </summary>
        public string RESERVED01 { get; set; }
    }
}