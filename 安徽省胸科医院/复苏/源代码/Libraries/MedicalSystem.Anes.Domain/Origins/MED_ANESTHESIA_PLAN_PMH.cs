namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 术前访视(病史);每条手术对应一条术前访视记录，存放术前访视的病史部分信息。既往病史past medical history
    /// </summary>
    [Table("MED_ANESTHESIA_PLAN_PMH")]
    public partial class MED_ANESTHESIA_PLAN_PMH : BaseModel
    {
        /// <summary>
        /// 主键 病人id;	非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 住院次数;	病人每次住院加1
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术号;一个病人一次住院期间手术的标识，从1开始顺序排列
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        public Nullable<decimal> HEIGHT { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        public Nullable<decimal> WEIGHT { get; set; }
        /// <summary>
        /// 血型
        /// </summary>
        public string BLOOD_TYPE { get; set; }
        /// <summary>
        /// 过敏史;	1 有，0 无。ALERGY_DRUGS_INDICATOR
        /// </summary>
        public string ALERGY_DRUGS_HISTORY { get; set; }
        /// <summary>
        /// 吸烟史;	SMOKE_DRINK_INDICATOR
        /// </summary>
        public string SMOKE_HISTORY { get; set; }
        /// <summary>
        /// 饮酒史;	DRINK_ INDICATOR
        /// </summary>
        public string DRINK_HISTORY { get; set; }
        /// <summary>
        /// 麻醉史
        /// </summary>
        public string ANES_HISTORY { get; set; }
        /// <summary>
        /// 手术史;	OPER_HISTORY_INDICATOR
        /// </summary>
        public string OPER_HISTORY { get; set; }
        /// <summary>
        /// 输血史;	BLOOD_TRANSFER_HISTORY
        /// </summary>
        public string BLOOD_TRANSFER { get; set; }
        /// <summary>
        /// 家族史
        /// </summary>
        public string FAMILY_HISTORY { get; set; }
        /// <summary>
        /// 心血管系统
        /// </summary>
        public string CARDIOVASCULAR_SYSTEM { get; set; }
        /// <summary>
        /// 呼吸系统
        /// </summary>
        public string RESPIRATORY_SYSTEM { get; set; }
        /// <summary>
        /// 神经系统
        /// </summary>
        public string NERVOUS_SYSTEM { get; set; }
        /// <summary>
        /// 血液内分泌系统
        /// </summary>
        public string ENDOCRINE_SYSTEM { get; set; }
        /// <summary>
        /// 泌尿生殖系统
        /// </summary>
        public string REPRODUCTIVE_SYSTEM { get; set; }
        /// <summary>
        /// 消化系统
        /// </summary>
        public string ALIMENTARY_SYSTEM { get; set; }
        /// <summary>
        /// 肾脏
        /// </summary>
        public string KIDNEY { get; set; }
        /// <summary>
        /// 肝脏
        /// </summary>
        public string LIVER { get; set; }
        /// <summary>
        /// 特殊药物
        /// </summary>
        public string MR_ABSTRACT { get; set; }
        /// <summary>
        /// 其他
        /// </summary>
        public string OTHER { get; set; }
        /// <summary>
        /// 肌肉骨骼系统
        /// </summary>
        public string SKELETON_SYSTEM { get; set; }
        /// <summary>
        /// 并发症
        /// </summary>
        public string COMPLICATION { get; set; }
    }
}