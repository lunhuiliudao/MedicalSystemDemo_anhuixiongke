namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_CONSULTATION_REGISTRATION")]
    public partial class MED_CONSULTATION_REGISTRATION : BaseModel
    {
                [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public Int32 OPER_ID { get; set; }
        public string HOSP_BRANCH { get; set; }
        public string WARD_CODE { get; set; }
        public string DEPT_CODE { get; set; }
        public string OPER_DEPT_CODE { get; set; }
        public string OPER_ROOM { get; set; }
        public string OPER_ROOM_NO { get; set; }
        public string BED_NO { get; set; }
        public string CONSULTATION_REASON { get; set; }
        public Nullable<DateTime> CONSULTATION_DATE_TIME { get; set; }
        public string ANES_METHOD { get; set; }
        public string ANES_DOCTOR { get; set; }
        public string FIRST_ANES_ASSISTANT { get; set; }
        public string CONSULTATION_OTHER { get; set; }
        public string CONSULTATION_OPINIONS { get; set; }
        public string RESERVED01 { get; set; }
        public string RESERVED02 { get; set; }
        public string RESERVED03 { get; set; }
        public Nullable<DateTime> RESERVED04 { get; set; }
        public Nullable<Int32> RESERVED05 { get; set; }

    }
}