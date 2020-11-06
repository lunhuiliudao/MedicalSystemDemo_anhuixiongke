using System;
using System.Collections.Generic;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.Domain.Origins
{
    /// <summary>
    /// 实体 登录用户信息表
    /// </summary>
    [Table("MED_WECHAT_USERS")]
    public class MED_WECHAT_USERS: BaseModel
    {
        /// <summary>
        /// 主键 用户ID	
        /// </summary>
        [Key]
        public string ID { get; set; }
        /// <summary>
        /// 医护人员工号
        /// </summary>
        public string USER_JOB_ID { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string USER_NAME { get; set; }
        /// <summary>
        /// 输入码  
        /// </summary>
        public string INPUT_CODE { get; set; }
        /// <summary>
        /// 用户状态;1 正常，0 停用
        /// </summary>
        public int USER_STATUS { get; set; }
        /// <summary>
        /// 医院唯一标识
        /// </summary>
        public string HOSPITAL_ID { get; set; }

        /// <summary>
        /// UnionID机制 与 OPENID关联
        /// </summary>
        public string OPEN_ID { get; set; }

        /// <summary>
        /// 用户特权ID
        /// </summary>
        public string PERMISSION_ID { get; set; }

        /// <summary>
        /// 创建日期  
        /// </summary>
        public DateTime? CREATE_DATE { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        [NotMapped]
        public string HOSPITAL_NAME { get; set; }


    }
}
