using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Domain
{
     public partial  class MED_LAB_RESULT
     {
         [NotMapped]
         public virtual string ABNORMAL_INDICATOR_TXT { get; set; }

    }
}
