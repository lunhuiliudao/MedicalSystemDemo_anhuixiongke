using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Domain
{
    public partial class MED_ORDERS
    {
        [NotMapped]
        public virtual string REPEAT_INDICATORTXT { get; set; }

    }
}
