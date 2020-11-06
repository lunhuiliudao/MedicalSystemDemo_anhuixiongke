using Dapper.Data;
using System;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 实体 北京CA
    /// </summary>
    [Table("MED_BJCA_SIGN")]
    public partial class MED_BJCA_SIGN : BaseModel
    {
        /// <summary>
        /// 签名标记
        /// </summary>
        [Key]
        public string SIGNID { get; set; }

        /// <summary>
        /// 主键 病人ID	;非空，唯一确定手术病人
        /// </summary>
        public string PATIENT_ID { get; set; }

        /// <summary>
        /// 主键 入院次数	;	住院病人每次住院加1
        /// </summary>
        public Int32 VISIT_ID { get; set; }

        /// <summary>
        /// 主键 手术号
        /// </summary>
        public Int32 OPER_ID { get; set; }

        /// <summary>
        /// CA签名人
        /// </summary>
        public string SIGNNAME { get; set; }

        /// <summary>
        /// 文书名称
        /// </summary>
        public string SIGNDOCNAME { get; set; }

        /// <summary>
        /// 签名日期
        /// </summary>
        public Nullable<DateTime> SIGNDATE { get; set; }

        /// <summary>
        /// 签名类型(0为创建，1为修改)
        /// </summary>
        public Nullable<Int32> SIGNTYPE { get; set; }
        
        /// <summary>
        /// 证书SN号
        /// </summary>
        public string CERTSN { get; set; }

        /// <summary>
        /// 签名值
        /// </summary>
        public byte[] SIGNVALUE { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public byte[] TIMESTAMPVALUE { get; set; }

        /// <summary>
        /// 证书
        /// </summary>
        public byte[] SIGNCERT { get; set; }

        /// <summary>
        /// 签名图片
        /// </summary>
        public byte[] SIGNIMAGE { get; set; }

        [NotMapped]
        public string B64SIGNIMAGE { get; set; }

        /// <summary>
        /// 原文
        /// </summary>
        public byte[] ORGDATA { get; set; }

        /// <summary>
        /// 控件名称
        /// </summary>
        public string CONTROLID { get; set; }
    }
}
