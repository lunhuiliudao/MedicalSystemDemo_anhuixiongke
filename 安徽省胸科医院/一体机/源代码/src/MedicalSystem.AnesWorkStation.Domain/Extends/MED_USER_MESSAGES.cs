using System;
using System.Collections.Generic;
using Dapper.Data;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_USER_MESSAGES
    {
        [NotMapped]
        public virtual string SEND_USER_NAME { get; set; }
        [NotMapped]
        public virtual bool ISREAD { get; set; }
    }
}
