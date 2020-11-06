namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 协同终端列表;手术间协同终端列表，保存各个终端的IP，实现点对点通讯。终端登录时，要更新客户端状态为已登录。未登录的终端，不显示在发送终端列表中。
    /// </summary>
    [Table("MED_CLIENT_COMPUTER")]
    public partial class MED_CLIENT_COMPUTER : BaseModel
    {
        /// <summary>
        /// 主键 客户端ID
        /// </summary>
        [Key]
        public string CLIENT_ID { get; set; }
        /// <summary>
        /// 客户端名称;如果是手术间，则为MED_OPERATING_ROOM .BED_LABEL
        /// </summary>
        public string CLIENT_NAME { get; set; }
        /// <summary>
        /// 客户端类型;	0 手术间，1 复苏室，2 办公区。默认手术间 0
        /// </summary>
        public Int32 CLIENT_TYPE { get; set; }
        /// <summary>
        /// 客户端状态;	0 未登陆，1 已登录。默认 0
        /// </summary>
        public Int32 CLIENT_STATUS { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP_ADDR { get; set; }
        /// <summary>
        /// 手术间号;当终端为手术间时，此项不能空
        /// </summary>
        public string ROOM_NO { get; set; }
        /// <summary>
        /// 手术科室代码;	当终端为手术间时，此项不能空
        /// </summary>
        public string DEPT_CODE { get; set; }
    }
}