using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Domain
{
    public partial class MED_ANESTHESIA_EVENT
    {
        [NotMapped]
        public virtual string ITEM_CLASS_NAME { get; set; } 
    }
}
