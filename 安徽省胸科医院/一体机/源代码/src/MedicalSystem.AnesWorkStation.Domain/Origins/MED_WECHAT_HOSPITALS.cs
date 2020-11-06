namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;
    using Dapper.Data;


    /// <summary>
    /// 实体 登录用户信息表
    /// </summary>
    [Table("MED_WECHAT_HOSPITALS")]
    public partial class MED_WECHAT_HOSPITALS : BaseModel
    {
        /// <summary>
        /// 主键医院ID	
        /// </summary>
        [Key]
        public string HOSPITAL_ID { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HOSPITAL_NAME { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string PROVINCE { get; set; }
        /// <summary>
        /// 省ID
        /// </summary>
        public string PROVINCE_ID { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string CITY { get; set; }
        /// <summary>
        /// 市ID
        /// </summary>
        public string CITY_ID { get; set; }
        /// <summary>
        /// 医院外网IP
        /// </summary>
        public string IP_ADDRESS { get; set; }
        /// <summary>
        /// 医院名称缩写		
        /// </summary>
        public string SHORT_NAME { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LOGIN_NAME { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string PASSWORD { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int ENABLE { get; set; }
    }
}