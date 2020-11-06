using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MedicalSystem.DataServices.Domain;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    public class PatInfoController : BaseController
    {
        private IPatInfoService patInfoService;
        public PatInfoController(IPatInfoService patInfoService)
        {
            this.patInfoService = patInfoService;
        }

        [HttpGet]
        public RequestResult<List<MED_PAT_INFO>> GetPatientInfosByDateTime(DateTime dt, string deptCode, string operRoomNo = "")
        {
            List<MED_PAT_INFO> list = this.patInfoService.GetPatientInfosByDateTime(dt, deptCode, operRoomNo);
            return Success(list);
        }

        [HttpGet]
        public RequestResult<List<MED_PAT_INFO>> GetPatientInfosInWeek(DateTime startDt, DateTime endDt, string deptCode, string operRoomNo = "")
        {
            List<MED_PAT_INFO> list = this.patInfoService.GetPatientInfosInWeek(startDt, endDt, deptCode, operRoomNo);
            return Success(list);
        }

        /// <summary>
        /// 获取当前正在手术的患者信息
        /// </summary>
        [HttpGet]
        public RequestResult<MED_PAT_INFO> GetCurPatientInfo(string deptCode, string operRoomNo = "")
        {
            MED_PAT_INFO list = this.patInfoService.GetCurPatientInfo(deptCode, operRoomNo);
            return Success(list);
        }

        /// <summary>
        /// 根据病人ID获取患者信息
        /// </summary>
        /// <param name="patient_id"></param>
        /// <param name="visit_id"></param>
        /// <param name="oper_id"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<MED_PAT_INFO> GetPatInfoByIds(string patient_id, decimal visit_id, decimal oper_id)
        {
            MED_PAT_INFO list = this.patInfoService.GetPatInfoByIds(patient_id, visit_id, oper_id);
            return Success(list);
        }

        /// <summary>
        /// 根据输入值获取匹配患者ID
        /// </summary>
        /// <param name="inputStr"></param>
        /// <param name="showCount"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_OPERATION_MASTER>> GetPatientList(string inputStr, int showCount, bool isInpNo)
        {
            List<MED_OPERATION_MASTER> list = this.patInfoService.GetPatientList(inputStr, showCount, isInpNo);

            return Success(list);
        }

        /// <summary>
        /// 搜索命令：根据对应的idOrName获取手术信息列表
        /// </summary>
        public RequestResult<List<MED_PAT_INFO>> GetPatInfos(string idOrName, string deptCode)
        {
            List<MED_PAT_INFO> list = this.patInfoService.GetPatInfos(idOrName, deptCode);

            return Success(list);
        }
        /// <summary>
        /// 搜索命令：根据对应的scheduledTime获取手术信息列表
        /// </summary>
        /// <param name="scheduledTime">手术时间</param>
        ///    /// <param name="roomNo">手术间号</param>
        ///       /// <param name="idOrName">病人ID,住院号或姓名</param>
        ///          /// <param name="deptCode">科室代码</param>
        public RequestResult<List<MED_PAT_INFO>> GetPatInfosByData(DateTime scheduledTime, string roomNo, string idOrName, string deptCode)
        {
            List<MED_PAT_INFO> list = this.patInfoService.GetPatInfosByData(scheduledTime, roomNo, idOrName, deptCode);
            return Success(list);
        }
        /// <summary>
        /// 获取PACU相关信息
        /// </summary>
        public RequestResult<List<MED_PACU_INFO>> GetPACUInfos()
        {
            List<MED_PACU_INFO> list = this.patInfoService.GetPACUInfos();

            return Success(list);
        }

        /// <summary>
        /// 待入PACU患者信息
        /// </summary>
        public RequestResult<List<MED_OPERATION_MASTER>> GetWaitingInfos()
        {
            List<MED_OPERATION_MASTER> list = this.patInfoService.GetWaitingInfos();

            return Success(list);
        }
    }
}