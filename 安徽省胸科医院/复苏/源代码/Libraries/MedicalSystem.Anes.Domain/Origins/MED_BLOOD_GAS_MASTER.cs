namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 血气分析主索引表
    /// </summary>
    [Table("MED_BLOOD_GAS_MASTER")]
    public partial class MED_BLOOD_GAS_MASTER : BaseModel
    {
        /// <summary>
        /// 主键 明细表ID
        /// </summary>
        [Key]
        public string DETAIL_ID { get; set; }
        /// <summary>
        /// 病人ID	;非空，唯一确定手术病人
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 入院次数	;	住院病人每次住院加1
        /// </summary>
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime RECORD_DATE { get; set; }
        /// <summary>
        /// 备注;目前保存对血气结果的诊断信息
        /// </summary>
        public string NURSE_MEMO1 { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string NURSE_MEMO2 { get; set; }
        /// <summary>
        /// 操作者
        /// </summary>
        public string OPERATOR { get; set; }
        /// <summary>
        /// 操作日期
        /// </summary>
        public Nullable<DateTime> OP_DATE { get; set; }
        /// <summary>
        /// 标本类型;动脉血、静脉血
        /// </summary>
        public string SPECIMEN { get; set; }
        /// <summary>
        /// 样本编号;每个设备发送的内部唯一编码
        /// </summary>
        public string EQUIPMENT { get; set; }
        /// <summary>
        /// 手术次数
        /// </summary>
        public Nullable<Int32> OPER_ID { get; set; }
    }
}