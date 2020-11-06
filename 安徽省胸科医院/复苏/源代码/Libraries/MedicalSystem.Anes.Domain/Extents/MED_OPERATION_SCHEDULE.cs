using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Domain
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

    }
}
