using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_ANES_BILL_TEMPLET
    {
        [NotMapped]
        public virtual string ITEM_CLASS_NAME { get; set; }
    }
}
