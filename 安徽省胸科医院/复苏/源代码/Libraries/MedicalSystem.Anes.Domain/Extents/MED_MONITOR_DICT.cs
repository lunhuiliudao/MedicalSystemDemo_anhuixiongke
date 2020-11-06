using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Domain
{
    public partial class MED_MONITOR_DICT
    {
        [NotMapped]
        public virtual string MONITOR_TYPE { get; set; }
    }
}
