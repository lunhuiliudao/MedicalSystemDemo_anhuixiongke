namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 PARS麻醉评分
    /// </summary>
    [Table("MED_PARS_SCORING_RESULT")]
    public partial class MED_PARS_SCORING_RESULT : BaseModel
    {
                [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public Int32 DEP_ID { get; set; }
        [Key]
        public DateTime SCORING_DATE_TIME { get; set; }
        /// <summary>
        /// 活动
        /// </summary>
        public Nullable<Int32> S1 { get; set; }
        /// <summary>
        /// 呼吸
        /// </summary>
        public Nullable<Int32> S2 { get; set; }
        /// <summary>
        /// 循环
        /// </summary>
        public Nullable<Int32> S3 { get; set; }
        /// <summary>
        /// 意识
        /// </summary>
        public Nullable<Int32> S4 { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public Nullable<Int32> S5 { get; set; }
        /// <summary>
        /// 病情描述
        /// </summary>
        public string MEMO { get; set; }

    }
}