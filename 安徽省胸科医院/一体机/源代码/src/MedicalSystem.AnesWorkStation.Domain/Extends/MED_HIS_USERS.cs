using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_HIS_USERS
    {
        [NotMapped]
        public virtual string USER_DEPT_NAME { get; set; }
    }
}
