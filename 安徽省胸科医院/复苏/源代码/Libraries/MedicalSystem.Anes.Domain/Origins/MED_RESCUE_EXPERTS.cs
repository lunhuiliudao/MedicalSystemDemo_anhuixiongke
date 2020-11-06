namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 抢救呼叫专家列表
    /// </summary>
    [Table("MED_RESCUE_EXPERTS")]
    public partial class MED_RESCUE_EXPERTS : BaseModel
    {
        /// <summary>
        /// 主键 专家ID
        /// </summary>
        [Key]
        public string EXPERT_ID { get; set; }
        /// <summary>
        /// 专家名称
        /// </summary>
        public string EXPERT_NAME { get; set; }
        /// <summary>
        /// 专家等级
        /// </summary>
        public Nullable<Int32> EXPERT_GRADE { get; set; }
        /// <summary>
        /// 专家状态;0 不可用，1 可用。默认 1
        /// </summary>
        public Nullable<Int32> EXPERT_STATUS { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP_ADDR { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string PHONE_NUMBER { get; set; }
        /// <summary>
        /// 微信号码
        /// </summary>
        public string WECHAT_NUMBR { get; set; }
        /// <summary>
        /// 所属科室代码
        /// </summary>
        public string DEPT_CODE { get; set; }
    }
}