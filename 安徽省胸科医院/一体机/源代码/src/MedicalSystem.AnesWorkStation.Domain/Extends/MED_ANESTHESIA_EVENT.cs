using System;
using System.Collections.Generic;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_ANESTHESIA_EVENT
    {
        [NotMapped]
        public virtual string ITEM_CLASS_NAME { get; set; }

    }
}
