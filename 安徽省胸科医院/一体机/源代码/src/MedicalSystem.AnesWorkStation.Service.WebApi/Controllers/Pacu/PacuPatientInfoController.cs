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
    /// <summary>
    /// Demo演示
    /// </summary>
    public class PacuPatientInfoController : BaseController
    {
        IPacuPatientInfoService _pacuPatientInfoService;

        public PacuPatientInfoController(IPacuPatientInfoService pacuPatientInfoService)
        {
            _pacuPatientInfoService = pacuPatientInfoService;
        }

        /// <summary>
        /// 获取患者基本信息表
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="containsType">匹配方式1:Contains 2:StartsWith 3:EndsWith</param>
        /// <returns><![CDATA[RequestResult<List<MED_PAT_MASTER_INDEX>>]]></returns>      
        [HttpGet]
        public RequestResult<List<MED_OPERATION_MASTER>> GetPatMasterInfoList(string startDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
            , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1, string isSelfOpera, string isJiZhen, string isZeQi, string userName)
        {

            return Success(_pacuPatientInfoService.GetPatMasterInfoList(startDate, patientID, patientName, anesthesiaDoctor, departCode
                , operationStatus, asa, operationName, anesthesiaMethod, age, age1, isSelfOpera, isJiZhen, isZeQi, userName));//调用扩展方法抓取手术信息
        }

        /// <summary>
        /// 获取患者列表信息
        /// </summary>
        /// <param name="operDateTime"></param>
        /// <param name="patientID"></param>
        /// <param name="operRoomNo"></param>
        /// <param name="operRoom"></param>
        /// <param name="hospBranch"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_PATIENT_CARD>> GetPatCardList(DateTime operDateTime, string inpNo, string operRoomNo, string operRoom, string hospBranch, bool IsSearch)
        {
            return Success(_pacuPatientInfoService.GetPatCardList(operDateTime, inpNo, operRoomNo, operRoom, hospBranch, IsSearch));
        }

        [HttpGet]
        public RequestResult<MED_PATIENT_CARD> GetPatCard(string patientID, int visitID, int operID)
        {
            return Success(_pacuPatientInfoService.GetPatCard(patientID, visitID, operID));
        }

        /// <summary>
        /// 获取当前患者列表信息
        /// </summary>
        /// <param name="operDateTime"></param>
        /// <param name="operRoomNo"></param>
        /// <param name="operRoom"></param>
        /// <param name="hospBranch"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_PATIENT_CARD>> GetCurrentPatCardList(DateTime operDateTime, string operRoomNo, string operRoom, string hospBranch)
        {
            return Success(_pacuPatientInfoService.GetCurrentPatCardList(operDateTime, operRoomNo, operRoom, hospBranch));
        }

        [HttpGet]
        public RequestResult<List<MED_PATIENT_CARD>> GetPatientListByDate(DateTime operStartTime, DateTime operEndTime, string operRoomNo, string operRoom, string hospBranch)
        {
            return Success(_pacuPatientInfoService.GetPatientListByDate(operStartTime, operEndTime, operRoomNo, operRoom, hospBranch));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operDateTime"></param>
        /// <param name="operRoom"></param>
        /// <param name="hospBranch"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_OPERATION_MASTER>> GetOperMasterListByPacuTime(DateTime operDateTime, string operRoom, string hospBranch)
        {
            return Success(_pacuPatientInfoService.GetOperMasterListByPacuTime(operDateTime, operRoom, hospBranch));
        }

        [HttpGet]
        public RequestResult<List<MED_PATIENT_CARD>> GetPatientListDataTable(DateTime startDate, string deptCode, string hospBranch)
        {
            return Success(_pacuPatientInfoService.GetPatientListDataTable(startDate, deptCode, hospBranch));
        }

        [HttpGet]
        public RequestResult<List<MED_PATIENT_CARD>> GetPatientListDataTableByPACU(DateTime startDate, string deptCode, string hospBranch, string searchStr)
        {
            return Success(_pacuPatientInfoService.GetPatientListDataTableByPACU(startDate, deptCode, hospBranch, searchStr));
        }

        [HttpGet]
        public RequestResult<List<MED_PATIENT_CARD>> GetPatientListDataTableByPatientID(string patientID, string deptCode, string hospBranch)
        {
            return Success(_pacuPatientInfoService.GetPatientListDataTableByPatientID(patientID, deptCode, hospBranch));
        }
    }
}