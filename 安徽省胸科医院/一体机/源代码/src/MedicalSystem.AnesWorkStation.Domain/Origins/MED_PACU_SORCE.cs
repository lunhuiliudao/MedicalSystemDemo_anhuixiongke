namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;
    using Dapper.Data;



    /// <summary>
    /// 实体 复苏评分
    /// </summary>
    [Table("MED_PACU_SORCE")]
    public partial class MED_PACU_SORCE : BaseModel
    {
        
               [Key]
        public string ORDER_ID { get; set; }
        /// <summary>
        /// 主键 病人id
        /// </summary>
        [Key]
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 主键 住院次数
        /// </summary>
        [Key]
        public Int32 VISIT_ID { get; set; }
        /// <summary>
        /// 主键 
        /// </summary>
        [Key]
        public Int32 OPER_ID { get; set; }
        [Key]
        public string CRITERION { get; set; }

        public string ZERO { get; set; }

        public string ONE { get; set; }

        public string TWO { get; set; }

        public string EVENTHAPPEN { get; set; }

        public DateTime TIME { get; set; }

        public Int32 MYODYNAMIA { get; set; }

        public Int32 BREATH { get; set; }

        public Int32 CYCLE { get; set; }

        public Int32 SPO2 { get; set; }

        public Int32 CONSCIOUSNESS { get; set; }

        public Nullable<Int32> TOTAL { get; set; }

        public string SIGNATURE { get; set; }
    }
}