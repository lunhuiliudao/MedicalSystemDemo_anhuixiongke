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
    public class PacuQueryController : BaseController
    {

        IPacuQueryService _pacuQueryService = null;

        public PacuQueryController(IPacuQueryService pacuQueryService)
        {
            _pacuQueryService = pacuQueryService;


        }
        #region IQueryDataInterface 成员

        public RequestResult<System.Data.DataTable> GetOperationList(DateTime startTime, DateTime endTime, string inpNo, string name, string operationName, string oper_scale, string surgeon, string oper_dept_code, string anes_doctor, string anes_method, string asa_grade, int emergency_ind)
        {
            return Success(_pacuQueryService.GetOperationList(startTime, endTime, inpNo, name, operationName, oper_scale, surgeon, oper_dept_code, anes_doctor, anes_method, asa_grade, emergency_ind));
        }

        #endregion

        /// <summary>
        /// 工作量统计
        /// </summary>
        /// <param name="startTime">报表时间</param>
        /// <param name="report">报表类型,1:日报；2:月报；3:年报</param>
        /// <returns>报表结果</returns>
        public RequestResult<System.Data.DataTable> GetOperationReport(DateTime startTime, int report)
        {
            return Success(_pacuQueryService.GetOperationReport(startTime, report));
        }



    }
}