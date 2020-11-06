using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_OPERATION_SCHEDULE
    {
        [NotMapped]
        public virtual string NAME { get; set; }

        [NotMapped]
        public virtual string OPER_DEPT_NAME { get; set; }

        [NotMapped]
        public virtual DateTime DATE_OF_BIRTH { get; set; }

        [NotMapped]
        public virtual string AGE { get; set; }

        [NotMapped]
        public virtual string INP_NO { get; set; }

        [NotMapped]
        public virtual string SEX { get; set; }

        [NotMapped]
        public virtual int SORT_NO { get; set; }

        [NotMapped]
        public virtual string SURGEON_NAME { get; set; }

        [NotMapped]
        public virtual string FIRST_OPER_ASSISTANT_NAME { get; set; }

        [NotMapped]
        public virtual string ANES_DOCTOR_NAME { get; set; }

        [NotMapped]
        public virtual string ANES_ALL_DOCTOR_NAME { get; set; }

        [NotMapped]
        public virtual string SURGEON_ALL_NAME { get; set; }

        [NotMapped]
        public virtual string FIRST_ANES_ASSISTANT_NAME { get; set; }

        [NotMapped]
        public virtual string FIRST_OPER_NURSE_NAME { get; set; }

        [NotMapped]
        public virtual string SECOND_OPER_NURSE_NAME { get; set; }

        [NotMapped]
        public virtual string FIRST_SUPPLY_NURSE_NAME { get; set; }

        [NotMapped]
        public virtual string SECOND_SUPPLY_NURSE_NAME { get; set; }

        [NotMapped]
        public virtual byte[] DELETEIMAGE { get; set; }

        [NotMapped]
        public virtual bool ISCHECKED { get; set; }


        /// <summary>
        /// 时间
        /// </summary>
        [NotMapped]
        public string SCHEDULED_DATE_TIME_SHORT { get; set; }

        /// <summary>
        /// 助手2
        /// </summary>
        [NotMapped]
        public string SECOND_OPER_ASSISTANT_NAME { get; set; }

        /// <summary>
        /// 助手3
        /// </summary>
        [NotMapped]
        public string THIRD_OPER_ASSISTANT_NAME { get; set; }


        /// <summary>
        /// 副麻2
        /// </summary>
        [NotMapped]
        public string SECOND_ANES_ASSISTANT_NAME { get; set; }

        /// <summary>
        /// 隔离
        /// </summary>
        [NotMapped]
        public string ISOLATION_IND_NM { get; set; }

        /// <summary>
        /// 科室
        /// </summary>
        [NotMapped]
        public string DEPT_NAME { get; set; }

        /// <summary>
        /// 手术名称
        /// </summary>
        [NotMapped]
        public string TEMP_OPER_NAME { get; set; }
    }
}
