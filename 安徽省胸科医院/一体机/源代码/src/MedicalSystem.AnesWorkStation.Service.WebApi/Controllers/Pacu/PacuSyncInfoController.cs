
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Service.WebApi.Controllers;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MedicalSystem.Anes.Service.WebApi.Controllers
{
    public class PacuSyncInfoController : BaseController
    {
        IPacuSyncInfoService _syncInfoService = null;
        public PacuSyncInfoController(IPacuSyncInfoService syncInfoService)
        {
            _syncInfoService = syncInfoService;
        }

        [HttpGet]
        public RequestResult<string> SyncPatientInfoAndInHospital(string patientID)
        {
            return Success(_syncInfoService.SyncPatientInfoAndInHospital(patientID));
        }

        [HttpGet]
        public RequestResult<string> SyncScheduleInfo(string patientID, DateTime operDateTime)
        {
            return Success(_syncInfoService.SyncScheduleInfo(patientID, operDateTime));
        }

        [HttpGet]
        public RequestResult<string> SyncPatientInfoAndInHospitalByInpNo(string inpNo)
        {
            return Success(_syncInfoService.SyncPatientInfoAndInHospitalByInpNo(inpNo));
        }
        [HttpGet]
        public RequestResult<string> SyncWriteHisOper(string patientID, int visitID, int operID)
        {
            return Success(_syncInfoService.SyncWriteHisOper(patientID, visitID, operID));
        }
        [HttpGet]
        public RequestResult<string> SyncWriteHisOperStatus(string patientID, int visitID, int operID, int state)
        {
            return Success(_syncInfoService.SyncWriteHisOperStatus(patientID, visitID, operID, state));
        }
        [HttpGet]
        public RequestResult<string> SaveOperScheduleStateToHis(string patientID, int visitID, int operID, string State)
        {
            return Success(_syncInfoService.SaveOperScheduleStateToHis(patientID, visitID, operID, State));
        }
        [HttpGet]
        public RequestResult<string> SyncScheduleInfoByDeptCode(string performedcode)
        {
            return Success(_syncInfoService.SyncScheduleInfoByDeptCode(performedcode));
        }
        [HttpGet]
        public RequestResult<string> SyncScheduleInfo(string patientID)
        {
            return Success(_syncInfoService.SyncScheduleInfo(patientID));
        }
        [HttpGet]
        public RequestResult<string> SyncScheduleInfoByDateDiff(string patientID, int dateDiff)
        {
            return Success(_syncInfoService.SyncScheduleInfoByDateDiff(patientID, dateDiff));
        }
        [HttpGet]
        public RequestResult<string> SyncScheduleInfoByDateTime(string patientID, DateTime startTime, DateTime endTime)
        {
            return Success(_syncInfoService.SyncScheduleInfoByDateTime(patientID, startTime, endTime));
        }
        [HttpGet]
        public RequestResult<string> SyncLis(string patientID, EventHandler eventHandle)
        {
            return Success(_syncInfoService.SyncLis(patientID, eventHandle));
        }
        [HttpGet]
        public RequestResult<string> SyncLisByVisitID(string patientID, decimal visitID, EventHandler eventHandle)
        {
            return Success(_syncInfoService.SyncLisByVisitID(patientID, visitID, eventHandle));
        }
        [HttpGet]
        public RequestResult<string> SyncPACS(string patientID, decimal visitID, EventHandler eventHandle)
        {
            return Success(_syncInfoService.SyncPACS(patientID, visitID, eventHandle));
        }
        [HttpGet]
        public RequestResult<string> SyncEMR(string patientID, decimal visitID, EventHandler eventHandle)
        {
            return Success(_syncInfoService.SyncEMR(patientID, visitID, eventHandle));
        }

        [HttpPost]
        public RequestResult<string> SyncOPER505W(MED_EMR_ARCHIVE_DETIAL item)
        {
            return Success(_syncInfoService.SyncOPER505W(item));
        }

        [HttpGet]
        public RequestResult<string> SyncOPER503W(string patientID, int visitID, int operID, int operStatus)
        {
            return Success(_syncInfoService.SyncOPER503W(patientID, visitID, operID, operStatus));
        }

        [HttpGet]
        public RequestResult<string> SyncOrderInfo(string patientID, int visitID)
        {
            return Success(_syncInfoService.SyncOrderInfo(patientID, visitID));
        }
    }
}