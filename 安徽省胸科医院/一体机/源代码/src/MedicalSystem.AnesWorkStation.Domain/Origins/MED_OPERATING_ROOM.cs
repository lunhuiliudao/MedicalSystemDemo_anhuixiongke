namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 手术间代码表
    /// </summary>
    [Table("MED_OPERATING_ROOM")]
    public partial class MED_OPERATING_ROOM : BaseModel
    {
        /// <summary>
        /// 主键 手术间号
        /// </summary>
        [Key]
        public string ROOM_NO { get; set; }
        /// <summary>
        /// 主键 所属科室代码	;手术室代码
        /// </summary>
        [Key]
        public string DEPT_CODE { get; set; }
        /// <summary>
        /// 手术间所在地	;如日间手术间、产房手术间
        /// </summary>
        public string LOCATION { get; set; }
        /// <summary>
        /// 床位标号	;系统显示名称
        /// </summary>
        public string BED_LABEL { get; set; }
        /// <summary>
        /// 排序号	;专门为排序使用，默认 0
        /// </summary>
        public Nullable<Int32> SORT_NO { get; set; }
        /// <summary>
        ///  床位类型;0 手术间，1 PACU
        /// </summary>
        public string BED_TYPE { get; set; }
        /// <summary>
        /// 手术间状态	;0 可用 ，1 不可用.默认 0
        /// </summary>
        public string STATUS { get; set; }
        /// <summary>
        /// 病人ID	;非空，唯一确定手术病人
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 入院次数	;	住院病人每次住院加1
        /// </summary>
        public Nullable<Int32> VISIT_ID { get; set; }
        /// <summary>
        /// 手术号
        /// </summary>
        public Nullable<Int32> OPER_ID { get; set; }
    }
}