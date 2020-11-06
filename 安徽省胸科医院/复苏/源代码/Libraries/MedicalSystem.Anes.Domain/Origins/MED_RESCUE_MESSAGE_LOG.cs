namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 抢救呼叫消息记录
    /// </summary>
    [Table("MED_RESCUE_MESSAGE_LOG")]
    public partial class MED_RESCUE_MESSAGE_LOG : BaseModel
    {
                /// <summary>
        /// 主键 消息ID
        /// </summary>
        [Key]
        public string MESSAGE_ID { get; set; }
        /// <summary>
        /// 主键 消息类型 0-抢救;1-体征预警
        /// </summary>
        [Key]
        public Int32 MESSAGE_TYPE { get; set; }
        /// <summary>
        /// 发送端IP;可以在任意终端发送抢救消息，记录IP地址
        /// </summary>
        public string SEND_CLIENT_IP { get; set; }
        /// <summary>
        /// 发送方登录用户ID
        /// </summary>
        public string SEND_USER_ID { get; set; }
        /// <summary>
        /// 接收专家组ID
        /// </summary>
        public string GROUP_ID { get; set; }
        /// <summary>
        /// 接收专家ID
        /// </summary>
        public string EXPERT_ID { get; set; }
        /// <summary>
        /// 病人id
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 住院次数  
        /// </summary>
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 手术号  
        /// </summary>
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MESSAGE { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SEND_TIME { get; set; }
        /// <summary>
        /// 发送确认;0 客户端保存，1 服务端已发送 
        /// </summary>
        public Nullable<Int32> SEND_CONFIRM { get; set; }
        /// <summary>
        /// 接收确认;0 未接收，1 已接收。默认 0 
        /// </summary>
        public Nullable<Int32> RECEIVE_CONFIRM { get; set; }

    }
}