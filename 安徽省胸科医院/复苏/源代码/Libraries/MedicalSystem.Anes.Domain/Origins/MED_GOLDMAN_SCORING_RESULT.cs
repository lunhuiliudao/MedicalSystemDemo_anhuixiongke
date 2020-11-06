namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 GOLDMAN麻醉评分
    /// </summary>
    [Table("MED_GOLDMAN_SCORING_RESULT")]
    public partial class MED_GOLDMAN_SCORING_RESULT : BaseModel
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
        /// 年龄>70岁
        /// </summary>
        public Nullable<Int32> S1 { get; set; }
        public Nullable<Int32> S2 { get; set; }
        /// <summary>
        /// 6个月以内心肌梗死
        /// </summary>
        public Nullable<Int32> S3 { get; set; }
        /// <summary>
        /// S3奔马率和颈静脉怒张
        /// </summary>
        public Nullable<Int32> S4 { get; set; }
        /// <summary>
        /// 重度主动脉狭窄
        /// </summary>
        public Nullable<Int32> S5 { get; set; }
        /// <summary>
        /// ECG显示非窦性心律伙房室性前收缩
        /// </summary>
        public Nullable<Int32> S6 { get; set; }
        /// <summary>
        /// 房室前收缩5次/分
        /// </summary>
        public Nullable<Int32> S7 { get; set; }
        /// <summary>
        /// 全身情况
        /// </summary>
        public Nullable<Int32> S8 { get; set; }
        /// <summary>
        /// 腹腔、胸腔或主动脉手术
        /// </summary>
        public Nullable<Int32> S9 { get; set; }
        /// <summary>
        /// 急症手术
        /// </summary>
        public string MEMO { get; set; }

    }
}