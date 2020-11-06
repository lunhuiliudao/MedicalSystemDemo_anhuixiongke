using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class MED_EVENT_DICT_EXT
    {
        [NotMapped]
        public virtual string EVENT_ITEM_NAME { get; set; }
        [NotMapped]
        public virtual string EVENT_ITEM_SPEC { get; set; }
    }
}
