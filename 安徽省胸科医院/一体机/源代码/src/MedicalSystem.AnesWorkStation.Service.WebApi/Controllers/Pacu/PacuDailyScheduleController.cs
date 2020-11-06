using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.DataServices.Domain;
using MedicalSystem.Common.SecretManage;
using Newtonsoft.Json;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Pacu
{
    public class PacuDailyScheduleController : BaseController
    {

        IPacuDailyScheduleService _pacuDailyScheduleService;

        public PacuDailyScheduleController(IPacuDailyScheduleService pacuDailyScheduleService)
        {
            _pacuDailyScheduleService = pacuDailyScheduleService;
        }


        #region IDailyScheduleDataInterface 成员

        public RequestResult<bool> AddDailySchedule(MED_DAILY_SCHEDULE item)
        {
            return Success(_pacuDailyScheduleService.AddDailySchedule(item));
        }

        public RequestResult<bool> SaveDailySchedule(MED_DAILY_SCHEDULE item)
        {
            return Success(_pacuDailyScheduleService.SaveDailySchedule(item));
        }

        public RequestResult<List<MED_DAILY_SCHEDULE>> GetDayList(DateTime currentDay, string loginName)
        {
            return Success(_pacuDailyScheduleService.GetDayList(currentDay, loginName));
        }

        public RequestResult<List<MED_DAILY_SCHEDULE>> GetMonthList(DateTime currentMonth, string loginName)
        {
            return Success(_pacuDailyScheduleService.GetDayList(currentMonth, loginName));
        }

        #endregion
    }
}