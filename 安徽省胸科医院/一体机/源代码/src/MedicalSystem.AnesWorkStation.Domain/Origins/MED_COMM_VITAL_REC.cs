namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 体征密集表
    /// </summary>
    [Table("MED_COMM_VITAL_REC")]
    public partial class MED_COMM_VITAL_REC : BaseModel
    {
        /// <summary>
        /// 主键 病人ID
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 住院次数
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 入科次数或者手术次数
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        public Nullable<DateTime> RECORDING_TIME { get; set; }
        /// <summary>
        /// 主键 体征时间
        /// </summary>
        [Key]
        public DateTime TIME_POINT { get; set; }
        /// <summary>
        /// 操作者
        /// </summary>
        public string OPERATOR { get; set; }
        /// <summary>
        /// 收缩压
        /// </summary>
        public Nullable<Int32> NIBP_SYS { get; set; }
        /// <summary>
        /// 舒张压
        /// </summary>
        public Nullable<Int32> NIBP_DIA { get; set; }
        /// <summary>
        /// 有创收缩压
        /// </summary>
        public Nullable<Int32> IBP_SYS { get; set; }
        /// <summary>
        /// 有创舒张压
        /// </summary>
        public Nullable<Int32> IBP_DIA { get; set; }
        /// <summary>
        /// 有创平均压
        /// </summary>
        public Nullable<Int32> IBP_MEAN { get; set; }
        /// <summary>
        /// 中心静脉压
        /// </summary>
        public Nullable<Int32> CVP { get; set; }
        /// <summary>
        /// 脉搏
        /// </summary>
        public Nullable<Int32> PULSE { get; set; }
        /// <summary>
        /// 心率
        /// </summary>
        public Nullable<Int32> HR { get; set; }
        /// <summary>
        /// 呼吸
        /// </summary>
        public Nullable<Int32> RESP { get; set; }
        /// <summary>
        /// 体温
        /// </summary>
        public Nullable<decimal> BODY_TEMP { get; set; }
        /// <summary>
        /// 直肠温
        /// </summary>
        public Nullable<decimal> RECTAL_TEMP { get; set; }
        /// <summary>
        /// 血氧饱和度
        /// </summary>
        public Nullable<Int32> SPO2 { get; set; }
        /// <summary>
        /// 数据类型(0-手术、1-术后复苏)
        /// </summary>
        public string DATA_TYPE { get; set; }

    }
}