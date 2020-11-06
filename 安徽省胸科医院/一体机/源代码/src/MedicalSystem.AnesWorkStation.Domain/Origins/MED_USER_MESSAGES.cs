namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;   
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 用户留言表
    /// </summary>
    [Table("MED_USER_MESSAGES")]
    public partial class MED_USER_MESSAGES : BaseModel
    {
        /// <summary>
        /// 主键 留言的主键
        /// </summary>
        [Key]
        public string MSG_ID { get; set; }
        /// <summary>
        /// 发送的用户ID
        /// </summary>
        public string SEND_USER_ID { get; set; }
        /// <summary>
        /// 接收的用户ID
        /// </summary>
        public string RECEIVE_USER_ID { get; set; }
        /// <summary>
        /// 接收的角色ID
        /// </summary>
        public string RECEIVE_ROLE_ID { get; set; }
        /// <summary>
        /// 接收的科室代码    对应科室代码表
        /// </summary>
        public string RECEIVE_DEPT_CODE { get; set; }
        /// <summary>
        /// 留言内容
        /// </summary>
        public string MEMO { get; set; }
        /// <summary>
        /// 留言日期
        /// </summary>
        public Nullable<DateTime> CREATE_DATE { get; set; }
        /// <summary>
        /// 阅读状态
        /// </summary>
        public Nullable<Int32> READ_STATE { get; set; }

    }
}