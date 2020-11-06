namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 STEWARD评分表
    /// </summary>
    [Table("MED_STEWARD_MARK")]
    public partial class MED_STEWARD_MARK : BaseModel
    {
                [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 主键 评分次数
        /// </summary>
        [Key]
        public Int32 MARK_COUNT { get; set; }
        /// <summary>
        /// 清醒程度 ;0-对刺激无反应，1-对刺激有反应，2-完全苏醒
        /// </summary>
        public Nullable<Int32> CONSCIOUSNESS { get; set; }
        /// <summary>
        /// 呼吸道通畅程度 ;0-呼吸道需要予以支持，1-不用支持可以维持呼吸道通畅，2-可按医师吩咐咳嗽
        /// </summary>
        public Nullable<Int32> AIRWARY_PATENCY { get; set; }
        /// <summary>
        /// 肢体活动度 ;0-肢体无活动，1-肢体无意识活动，2-肢体能有意识的活动
        /// </summary>
        public Nullable<Int32> PHYSICAL_ACTIVITY { get; set; }
        /// <summary>
        /// 总评分
        /// </summary>
        public Nullable<Int32> TOTAL_MATK { get; set; }

    }
}