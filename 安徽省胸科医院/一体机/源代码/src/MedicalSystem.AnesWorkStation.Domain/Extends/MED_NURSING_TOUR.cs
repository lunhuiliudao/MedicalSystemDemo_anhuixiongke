using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MED_NURSING_TOUR
    {
        [NotMapped]
        public virtual string NURSE_NAME { get; set; }

    }
}
