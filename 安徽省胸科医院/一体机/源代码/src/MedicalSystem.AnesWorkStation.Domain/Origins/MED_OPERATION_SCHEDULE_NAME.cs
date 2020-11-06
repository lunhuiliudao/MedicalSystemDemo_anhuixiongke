namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;  
    using Dapper.Data;
    
    

    /// <summary>
    /// 实体 手术安排手术名称表
    /// </summary>
    [Table("MED_OPERATION_SCHEDULE_NAME")]
    public partial class MED_OPERATION_SCHEDULE_NAME : BaseModel
    {
        /// <summary>
        /// 主键 病人ID	;非空，唯一确定手术病人
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 入院次数	;	住院病人每次住院加1
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 手术号	;			一个病人一次住院期间手术的标识，从1开始顺序排列
        /// </summary>
        [Key]
        public Int32 SCHEDULE_ID { get; set; }
        /// <summary>
        /// 主键 手术序号	;			手术序号(用于区分一台手术包含的多个部位的手术，从1开始顺序排列)，一般情况下第一个为主手术
        /// </summary>
        [Key]
        public Int32 OPER_NO { get; set; }
        /// <summary>
        /// 手术名称	;			OPERATION
        /// </summary>
        public string OPER_NAME { get; set; }
        /// <summary>
        /// 手术编码				
        /// </summary>
        public string OPER_CODE { get; set; }
        /// <summary>
        /// 手术等级	;			对应手术等级代码表,OPERATION_SCALE
        /// </summary>
        public string OPER_SCALE { get; set; }
        /// <summary>
        /// 切口类型	;			对应切口类型代码表,WOUND_GRADE
        /// </summary>
        public string WOUND_TYPE { get; set; }
        public string RESERVED1 { get; set; }
        public string RESERVED2 { get; set; }
        public string RESERVED3 { get; set; }
        public string RESERVED4 { get; set; }
    }
}