using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_PRICE_LIST
    {
        [NotMapped]
        public string INPUT_CODE { get; set; }
    }
}
