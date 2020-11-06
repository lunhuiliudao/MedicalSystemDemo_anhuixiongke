using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_EVENT_DICT
    {
        [NotMapped]
        public virtual string EventNamePY { get; set; }
    }
}
