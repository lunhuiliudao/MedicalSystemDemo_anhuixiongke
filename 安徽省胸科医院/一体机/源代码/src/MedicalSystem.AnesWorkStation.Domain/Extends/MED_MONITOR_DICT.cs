using System;
using System.Collections.Generic;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_MONITOR_DICT
    {
        [NotMapped]
        public virtual string MONITOR_TYPE { get; set; }
    }
}
