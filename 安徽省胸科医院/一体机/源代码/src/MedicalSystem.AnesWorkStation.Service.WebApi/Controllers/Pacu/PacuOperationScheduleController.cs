using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.DataServices.Domain;
using MedicalSystem.Common.SecretManage;
using Newtonsoft.Json;
using MedicalSystem.Services;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Pacu
{
    public class PacuOperationScheduleController : BaseController
    {
        IPacuOperationScheduleService _pacuOperationScheduleService = null;

        public PacuOperationScheduleController(IPacuOperationScheduleService pacuOperationScheduleService)
            : base()
        {
            _pacuOperationScheduleService = pacuOperationScheduleService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="emergencyFlg"></param>
        /// <param name="hospBranch"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_OPERATION_SCHEDULE>> GetOperationScheduleList(DateTime startTime, DateTime endTime, string emergencyFlg, string hospBranch, string operRoom)
        {
            return Success(_pacuOperationScheduleService.GetOperationScheduleList(startTime, endTime, emergencyFlg, hospBranch, operRoom));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<bool> UpdateOperationSchedule(List<MED_OPERATION_SCHEDULE> item, string type)
        {
            return Success(_pacuOperationScheduleService.UpdateOperationSchedule(item, type));
        }

        [HttpPost]
        public RequestResult<bool> UpdateOperationScheduleByPatientInfo(MED_OPERATION_SCHEDULE item, string type)
        {
            return Success(_pacuOperationScheduleService.UpdateOperationScheduleByPatientInfo(item, type));
        }

        [HttpGet]
        public RequestResult<int> GetMaxOperID(string patientID, int visitID)
        {
            return Success(_pacuOperationScheduleService.GetMaxOperID(patientID, visitID));
        }

        [HttpGet]
        public RequestResult<MED_OPERATION_SCHEDULE> GetOperationScheduleListByPatientInfo(string patientID, int visitID, int scheduleID)
        {
            return Success(_pacuOperationScheduleService.GetOperationScheduleListByPatientInfo(patientID, visitID, scheduleID));
        }

        [HttpGet]
        public RequestResult<List<MED_OPERATION_SCHEDULE_NAME>> GetOperationScheduleNameListByPatientInfo(string patientID, int visitID, int scheduleID)
        {
          return Success(_pacuOperationScheduleService.GetOperationScheduleNameListByPatientInfo(patientID, visitID, scheduleID));
        }

        [HttpGet]
        public RequestResult<int> GetMaxOperationNo(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationScheduleService.GetMaxOperationNo(patientID, visitID, operID));
        }

    }
}