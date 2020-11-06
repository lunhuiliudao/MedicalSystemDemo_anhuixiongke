using System;
using System.Collections.Generic;

using Dapper.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_PAT_MASTER_INDEX
    {

        [NotMapped]
        public virtual string OPERATION_NAME { get; set; }
    }
}
