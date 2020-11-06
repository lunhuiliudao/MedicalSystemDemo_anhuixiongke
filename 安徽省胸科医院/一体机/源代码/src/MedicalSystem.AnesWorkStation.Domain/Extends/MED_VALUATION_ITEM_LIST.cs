using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_VALUATION_ITEM_LIST
    {
        [NotMapped]
        public virtual string INPUT_CODE { get; set; }
    }
}
