using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.DataServices.Domain;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    /// <summary>
    /// 常用方法类
    /// </summary>
    public class SyncInfoController : BaseController
    {
        ISyncInfoService _syncInfoService;
        public SyncInfoController(ISyncInfoService syncInfoService)
        {
            _syncInfoService = syncInfoService;
        }

        /// <summary>
        /// 根据ID获取权限信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<string> SyncLis(string patientID, EventHandler eventHandle)
        {
            return Success(_syncInfoService.SyncLis(patientID, eventHandle));
        }

        /// <summary>
        /// 根据病人ID提取同步检验信息
        /// </summary>
        [HttpGet]
        public RequestResult<string> SyncLis(string patientID, int visitId, EventHandler eventHandle)
        {
            return Success(_syncInfoService.SyncLis(patientID, visitId, eventHandle));
        }


        /// <summary>
        /// 根据ID同步病人申请或预约信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<string> SyncScheduleInfo(string patientID, DateTime operDateTime)
        {
            return Success(_syncInfoService.SyncScheduleInfo(patientID, operDateTime));
        }

        /// <summary>
        /// 同步单病人基本信息及住院信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<string> SyncPatientInfoAndInHospital(string patientID)
        {
            return Success(_syncInfoService.SyncPatientInfoAndInHospital(patientID));
        }

        [HttpGet]
        public RequestResult<string> SyncPACSNoAndType(string inpNo)
        {
            return Success(_syncInfoService.SyncPACSNoAndType(inpNo));
        }
    }
}