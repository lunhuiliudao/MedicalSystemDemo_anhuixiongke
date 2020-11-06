namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic; 
    using Dapper.Data;
    
    

    /// <summary>
    /// 手术主表名称
    /// </summary>
    public partial class MED_OPERATION_MASTER
    {
        /// <summary>
        /// 患者姓名
        /// </summary>
        [NotMapped]
        public string NAME { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [NotMapped]
        public string AGE { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [NotMapped]
        public string SEX { get; set; }

        /// <summary>
        /// 手术医生
        /// </summary>
        [NotMapped]
        public string SURGEON_NAME { get; set; }

        /// <summary>
        /// 第一助手
        /// </summary>
        [NotMapped]
        public string FIRST_OPER_ASSISTANT_NAME { get; set; }


        /// <summary>
        /// 科室
        /// </summary>
        [NotMapped]
        public string DEPT_NAME { get; set; }

        /// <summary>
        /// 主麻
        /// </summary>
        [NotMapped]
        public string ANES_DOCTOR_NAME { get; set; }
    }
}