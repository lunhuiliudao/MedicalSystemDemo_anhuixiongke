namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_OPER_RISK_ESTIMATE")]
    public partial class MED_OPER_RISK_ESTIMATE : BaseModel
    {
                [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 手术清洁度
        /// </summary>
        public string OPER_CLEAN { get; set; }
        /// <summary>
        /// ASA分级
        /// </summary>
        public string ASA_GRADE { get; set; }
        /// <summary>
        /// 手术持续时间
        /// </summary>
        public string DURATIVE_TIME { get; set; }
        /// <summary>
        /// 手术类别
        /// </summary>
        public string OPER_TYPE { get; set; }
        /// <summary>
        /// 切口甲级愈合
        /// </summary>
        public string WOUND_MEND { get; set; }
        /// <summary>
        /// 切口感染
        /// </summary>
        public string WOUND_INFECT { get; set; }
        /// <summary>
        /// 手术医生
        /// </summary>
        public string OPER_DOCTOR { get; set; }
        /// <summary>
        /// 麻醉医生
        /// </summary>
        public string ANES_DOCTOR { get; set; }
        /// <summary>
        /// 巡回护士
        /// </summary>
        public string SUPPLY_NURSE { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string MEMO { get; set; }

    }
}