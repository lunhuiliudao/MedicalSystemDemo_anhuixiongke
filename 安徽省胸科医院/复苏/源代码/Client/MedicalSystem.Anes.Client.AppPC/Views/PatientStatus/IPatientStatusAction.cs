using MedicalSystem.Anes.Client.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.AppPC
{
    public interface IPatientStatusAction
    {
        object Excute(OperationStatus operationStatus);
    }
}
