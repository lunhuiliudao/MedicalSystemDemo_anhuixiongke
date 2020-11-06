namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 协同消息记录;记录消息发送的所有记录
    /// </summary>
    [Table("MED_MESSAGE_LOG")]
    public partial class MED_MESSAGE_LOG : BaseModel
    {
        /// <summary>
        /// 主键 消息ID
        /// </summary>
        [Key]
        public string MESSAGE_ID { get; set; }
        /// <summary>
        /// 发送端ID
        /// </summary>
        public string SEND_CLIENT_ID { get; set; }
        /// <summary>
        /// 发送方
        /// </summary>
        public string SEND_USER_ID { get; set; }
        /// <summary>
        /// 接收端ID
        /// </summary>
        public string RECEIVE_CLIENT_ID { get; set; }
        /// <summary>
        /// 接收方
        /// </summary>
        public string RECEIVE_USER_ID { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MESSAGE { get; set; }
        /// <summary>
        /// 接收时间
        /// </summary>
        public DateTime SEND_TIME { get; set; }
        public Nullable<DateTime> RECEIVE_TIME { get; set; }
        /// <summary>
        /// 接收确认;0 未接收，1 已接收。默认 0 
        /// </summary>
        public Nullable<Int32> RECEIVE_CONFIRM { get; set; }
    }
}