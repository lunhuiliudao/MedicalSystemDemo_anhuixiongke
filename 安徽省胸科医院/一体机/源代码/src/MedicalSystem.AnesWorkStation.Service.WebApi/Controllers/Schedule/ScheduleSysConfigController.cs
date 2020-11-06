using System;
using System.Web.Http;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.DataServices.Domain;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Schedule
{
    public class ScheduleSysConfigController : BaseController
    {
        IScheduleSyncInfoService SyncInfoService;
        public ScheduleSysConfigController(IScheduleSyncInfoService SyncInfoServiceParam)
        {
            SyncInfoService = SyncInfoServiceParam;
        }
        /// <summary>
        /// 同步病人排班信息
        /// </summary>
        /// <param name="ScheduleDateTime"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult SyncOperList(DateTime ScheduleDateTime)
        {
            return Success(SyncInfoService.SyncWrite_OPER101(ScheduleDateTime));
        }

        /// <summary>
        /// 同步病人检验结果
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult SyncLIS101(string patientID, int visitID)
        {
            return Success(SyncInfoService.SyncWrite_LIS101(patientID, visitID));
        }

        /// <summary>
        /// 同步医嘱信息
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult SyncOrder103(string patientID, int visitID)
        {
            return Success(SyncInfoService.SyncWrite_ORDER103(patientID, visitID));
        }
    }
}
