using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.ViewModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalSystem.DataServices.Domain;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Schedule
{
    public class ScheduleOperCancelController : BaseController
    {
        protected IScheduleOperCancelService OperCancel;
        public ScheduleOperCancelController(IScheduleOperCancelService OperScheduleParam)
        {
            OperCancel = OperScheduleParam;
        }

        [HttpGet]
        public RequestResult<IList<OperCancelEntity>> GetOperCancelList(DateTime ScheduleDateTime)
        {
            return Success(OperCancel.GetOperCancelList(ScheduleDateTime, AppSettings.OperDeptCode));
        }

        [HttpPost]
        public RequestResult<bool> RebackCancelOper(dynamic obj)
        {
            return Success(OperCancel.RebackCancelOper((string)obj.PatientID, (decimal)obj.VisitID, (decimal)obj.ScheduleID));
        }
    }
}
