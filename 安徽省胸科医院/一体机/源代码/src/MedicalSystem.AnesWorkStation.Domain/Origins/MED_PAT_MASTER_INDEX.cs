namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 病人基本信息表
    /// </summary>
    [Table("MED_PAT_MASTER_INDEX")]
    public partial class MED_PAT_MASTER_INDEX : BaseModel
    {
        /// <summary>
        /// 主键 病人ID	;非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 姓名拼音
        /// </summary>
        public string NAME_PHONETIC { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string SEX { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public Nullable<DateTime> DATE_OF_BIRTH { get; set; }
        /// <summary>
        /// 出生地
        /// </summary>
        public string BIRTH_PLACE { get; set; }
        /// <summary>
        /// 国际
        /// </summary>
        public string CITIZENSHIP { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string NATION { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string ID_NO { get; set; }
        /// <summary>
        /// 身份
        /// </summary>
        public string IDENTITY { get; set; }
        /// <summary>
        /// 合同单位
        /// </summary>
        public string UNIT_IN_CONTRACT { get; set; }
        /// <summary>
        /// 通讯地址
        /// </summary>
        public string MAILING_ADDRESS { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string ZIP_CODE { get; set; }
        /// <summary>
        /// 家庭电话
        /// </summary>
        public string PHONE_NUMBER_HOME { get; set; }
        /// <summary>
        /// 单位电话
        /// </summary>
        public string PHONE_NUMBER_BUSINESS { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string NEXT_OF_KIN { get; set; }
        /// <summary>
        /// 与联系人关系
        /// </summary>
        public string RELATIONSHIP { get; set; }
        /// <summary>
        /// 联系人地址
        /// </summary>
        public string NEXT_OF_KIN_ADDR { get; set; }
        /// <summary>
        /// 联系人邮编
        /// </summary>
        public string NEXT_OF_KIN_ZIP_CODE { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string NEXT_OF_KIN_PHONE { get; set; }

        /// <summary>
        /// 收费类别
        /// </summary>
        public string CHARGE_TYPE { get; set; }

        /// <summary>
        /// 临床路径
        /// </summary>
        public string LCLJ { get; set; }

        public string RESERVED01 { get; set; }
        public string RESERVED02 { get; set; }
        public string RESERVED03 { get; set; }
        public string RESERVED04 { get; set; }
        public string RESERVED05 { get; set; }
        public string RESERVED06 { get; set; }
        public string RESERVED07 { get; set; }
        public string RESERVED08 { get; set; }
        public string RESERVED09 { get; set; }
    }
}