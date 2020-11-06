using System;
using System.Collections.Generic;
using Dapper.Data;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_RESCUE_MESSAGE_LOG
    {
        [NotMapped]
        public virtual bool ISCHECKED { get; set; }

        [NotMapped]
        public virtual string SEND_USER_NAME { get; set; }
    }
}
