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
    public class ScheduleOperNoticeController : BaseController
    {
        IScheduleOperScheduleService OperSchedule;
        public ScheduleOperNoticeController(IScheduleOperScheduleService OperScheduleParam)
        {
            OperSchedule = OperScheduleParam;
        }

        [HttpGet]
        public RequestResult<dynamic> GetOperNoticeList(DateTime ScheduleDateTime)
        {
            return Success<dynamic>(OperSchedule.GetOperNoticeList(ScheduleDateTime));
        }

        [HttpGet]
        public RequestResult<dynamic> GetOperScheduleQueryList(DateTime ScheduleDateTime,string DeptCode,string Doctor)
        {
            return Success<dynamic>(OperSchedule.GetOperScheduleQueryList(ScheduleDateTime, DeptCode,Doctor));
        }

        #region 导出报表数据
        /// <summary>
        /// 导出报表数据
        /// </summary>
        /// <param name="obj">报表信息</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<string> ExportExcel(dynamic obj)
        {
            return Success(OperSchedule.ExportExcel(obj.reportMonth.Value, obj.reportName.Value, obj.exprotExcelColumns));
        }
        #endregion
    }
}
