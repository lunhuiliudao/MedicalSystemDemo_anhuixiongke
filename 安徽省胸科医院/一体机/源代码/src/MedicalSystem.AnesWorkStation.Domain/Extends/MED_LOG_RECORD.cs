using System;
using System.Collections.Generic;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_LOG_RECORD
    {
        public virtual MED_USERS MED_USERS { get; set; }
    }
}
