namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 系统操作日志表
    /// </summary>
    [Table("MED_OPERATION_LOG")]
    public partial class MED_OPERATION_LOG : BaseModel
    {
        /// <summary>
        /// 主键 主键ID
        /// </summary>
        [Key]
        public string LOGID { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public Nullable<DateTime> LOGTIME { get; set; }
        /// <summary>
        /// 系统名称
        /// </summary>
        public string APP_ID { get; set; }
        /// <summary>
        /// 子系统名称
        /// </summary>
        public string SUB_APP_NAME { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string MODULE_NAME { get; set; }
        /// <summary>
        /// 功能名称
        /// </summary>
        public string FUNC_NAME { get; set; }
        /// <summary>
        /// 调用的方法名称
        /// </summary>
        public string METHOD_NAME { get; set; }
        /// <summary>
        /// 返回值的描述
        /// </summary>
        public string RETURN_VALUE { get; set; }
        /// <summary>
        /// 参数的描述
        /// </summary>
        public string PARAMETER { get; set; }
        /// <summary>
        /// 客户端IP
        /// </summary>
        public string CLIENT_IP { get; set; }
        /// <summary>
        /// 客户端名称
        /// </summary>
        public string CLIENT_NAME { get; set; }
        /// <summary>
        /// 安装位置;手术间、主任办公室、护士站、医生办公室、护士长办公室等
        /// </summary>
        public string CLIENT_POSITION { get; set; }
        /// <summary>
        /// 服务端IP
        /// </summary>
        public string SERVER_IP { get; set; }
        /// <summary>
        /// 服务器名称
        /// </summary>
        public string SERVER_NAME { get; set; }
        /// <summary>
        /// 操作者
        /// </summary>
        public string OPERATOR { get; set; }
    }
}