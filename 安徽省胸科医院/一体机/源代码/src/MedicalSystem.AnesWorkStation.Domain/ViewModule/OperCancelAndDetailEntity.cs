using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain.ViewModule
{
    public class OperCancelAndDetailEntity
    {
        public MED_OPERATION_CANCELED OperCanceled { get; set; }

        public List<MED_ANESTHESIA_INPUT_DICT> AnesInputDict{ get; set; }
    }
}
