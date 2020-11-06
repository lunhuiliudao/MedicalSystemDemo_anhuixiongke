using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalSystem.Anes.Domain
{
    public partial class MED_OPERATION_MASTER
    {

        [NotMapped]
        [Association("MED_OPERATION_MASTERMED_PAT_MASTER_INDEX", "PATIENT_ID", "PATIENT_ID")]
        public virtual MED_PAT_MASTER_INDEX MED_PAT_MASTER_INDEX { get; set; }

        [NotMapped]
        [Association("MED_OPERATION_MASTERMED_OPERATION_NAME", "PATIENT_ID,VISIT_ID,OPER_ID", "PATIENT_ID,VISIT_ID,OPER_ID")]
        public virtual ICollection<MED_OPERATION_NAME> MED_OPERATION_NAME { get; set; }

        [NotMapped]
        [Association("MED_OPERATION_MASTERMED_DEPT_DICT", "DEPT_STAYED", "DEPT_CODE")]
        public virtual MED_DEPT_DICT MED_DEPT_DICT { get; set; }

        [NotMapped]
        [Association("MED_OPERATION_MASTERMED_DEPT_DICT1", "OPERATING_DEPT", "DEPT_CODE")]
        public virtual MED_DEPT_DICT MED_DEPT_DICT1 { get; set; }
    }
}
