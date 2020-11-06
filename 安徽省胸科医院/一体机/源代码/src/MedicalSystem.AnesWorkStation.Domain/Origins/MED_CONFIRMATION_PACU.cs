namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 复苏评估项目
    /// </summary>
    [Table("MED_CONFIRMATION_PACU")]
    public partial class MED_CONFIRMATION_PACU : BaseModel
    {
                [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 主键 复苏状态 ;45-入室 55-出室
        /// </summary>
        [Key]
        public Int32 OPER_STATUS_CODE { get; set; }
        /// <summary>
        /// 意识
        /// </summary>
        public string CONSCIOUSNESS { get; set; }
        /// <summary>
        /// 插管情况
        /// </summary>
        public string INTUBATION_CONDITION { get; set; }
        /// <summary>
        /// 瞳孔情况
        /// </summary>
        public string PUPIL { get; set; }
        /// <summary>
        /// 皮肤状况
        /// </summary>
        public string SKIN { get; set; }
        /// <summary>
        /// 体温
        /// </summary>
        public Nullable<decimal> BODY_TEMP { get; set; }
        /// <summary>
        /// 脉搏
        /// </summary>
        public Nullable<Int32> PULSE { get; set; }
        /// <summary>
        /// 高血压
        /// </summary>
        public Nullable<Int32> NIBP_SYS { get; set; }
        /// <summary>
        /// 低血压
        /// </summary>
        public Nullable<Int32> NIBP_DIA { get; set; }
        /// <summary>
        /// 呼吸
        /// </summary>
        public Nullable<Int32> RESP { get; set; }

    }
}