using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_UNIT_DICT
    {
        [NotMapped]
        public virtual string UNIT_TYPE_NAME { get; set; }
    }
}
