using System;
using System.Collections.Generic;
using Dapper.Data;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_ORDERS
    {
        [NotMapped]
        public virtual string REPEAT_INDICATORTXT { get; set; }

    }
}
