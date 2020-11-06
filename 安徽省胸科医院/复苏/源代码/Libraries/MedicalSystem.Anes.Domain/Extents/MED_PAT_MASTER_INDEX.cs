using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Domain
{
    public partial class MED_PAT_MASTER_INDEX
    {

        [NotMapped]
        public virtual string OPERATION_NAME { get; set; }
    }
}
