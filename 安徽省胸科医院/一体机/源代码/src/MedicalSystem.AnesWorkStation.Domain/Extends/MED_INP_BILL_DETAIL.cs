using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_INP_BILL_DETAIL
    {
        [NotMapped]
        public String PRICE_CLASS_NAME { get; set; } 
    }
}
