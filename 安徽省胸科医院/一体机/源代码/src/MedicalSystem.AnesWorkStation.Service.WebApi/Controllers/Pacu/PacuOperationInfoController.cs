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
    public class PacuOperationInfoController : BaseController
    {

        IPacuOperationInfoService _pacuOperationInfoService;

        public PacuOperationInfoController(IPacuOperationInfoService pacuOperationInfoService)
        {
            _pacuOperationInfoService = pacuOperationInfoService;
        }

        /// <summary>
        /// 获取住院信息表
        /// </summary>
        [HttpGet]
        public RequestResult<MED_PAT_VISIT> GetPatVisit(string patientID, int visitID)
        {
            return Success(_pacuOperationInfoService.GetPatVisit(patientID, visitID));
        }

        /// <summary>
        /// 获取住院信息列表
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_PAT_VISIT>> GetPatVisitList(string patientID)
        {
            return Success(_pacuOperationInfoService.GetPatVisitList(patientID));
        }
        /// <summary>
        /// 获取住院信息列表
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_PAT_VISIT>> GetPatVisitListByInpNo(string inpNo)
        {
            return Success(_pacuOperationInfoService.GetPatVisitListByInpNo(inpNo));
        }

        /// <summary>
        /// 获取患者主表列表
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_OPERATION_MASTER>> GetOperMasterList(string patientID, int visitID)
        {
            return Success(_pacuOperationInfoService.GetOperMasterList(patientID, visitID));
        }
        [HttpGet]
        public RequestResult<List<MED_OPERATION_MASTER>> GetOperMasterByRoom(string operRoomNo)
        {
            return Success(_pacuOperationInfoService.GetOperMasterByRoom(operRoomNo));
        }
        [HttpGet]
        public RequestResult<List<MED_OPERATION_MASTER>> GetOperMasterByStatus(int statusCode, int endStatusCode)
        {
            return Success(_pacuOperationInfoService.GetOperMasterByStatus(statusCode, endStatusCode));
        }
        /// <summary>
        /// 获取患者预约列表
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_OPERATION_SCHEDULE>> GetOperScheduleList(string patientID, int visitID)
        {
            return Success(_pacuOperationInfoService.GetOperScheduleList(patientID, visitID));
        }
        [HttpPost]
        public RequestResult<int> SaveOperScheduleList(List<MED_OPERATION_SCHEDULE> item)
        {
            return Success(_pacuOperationInfoService.SaveOperScheduleList(item));
        }
        /// <summary>
        /// 获取基本信息表
        /// </summary>
        [HttpGet]
        public RequestResult<MED_PAT_MASTER_INDEX> GetPatMasterIndex(string patientID)
        {
            return Success(_pacuOperationInfoService.GetPatMasterIndex(patientID));
        }
        /// <summary>
        /// 获取患者主表表
        /// </summary>
        [HttpGet]
        public RequestResult<MED_OPERATION_MASTER> GetOperMaster(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetOperMaster(patientID, visitID, operID));
        }

        /// <summary>
        /// 获取患者主表表
        /// </summary>
        [HttpGet]
        public RequestResult<MED_OPERATION_MASTER_EXT> GetOperMasterExt(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetOperMasterExt(patientID, visitID, operID));
        }

        /// <summary>
        /// 获取麻醉事件表
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_EVENT>> GetAnesEventList(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetAnesEventList(patientID, visitID, operID));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_EVENT>> GetAnesEventList(string patientID, int visitID, int operID, string eventNo)
        {
            return Success(_pacuOperationInfoService.GetAnesEventList(patientID, visitID, operID, eventNo));
        }
        [HttpPost]
        public RequestResult<int> SaveAnesthesiaEventList(List<MED_ANESTHESIA_EVENT> item)
        {
            return Success(_pacuOperationInfoService.SaveAnesthesiaEventList(item));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_PAT_MONITOR_DATA_EXT>> GetPatMonitorExtList(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetPatMonitorExtList(patientID, visitID, operID));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <returns></returns>

        [HttpGet]
        public RequestResult<List<MED_PAT_MONITOR_DATA_EXT>> GetPatMonitorExtList(string patientID, int visitID, int operID, string eventNo)
        {
            return Success(_pacuOperationInfoService.GetPatMonitorExtList(patientID, visitID, operID, eventNo));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_PAT_MONITOR_DATA>> GetPatMonitorDataList(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetPatMonitorDataList(patientID, visitID, operID));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_PAT_MONITOR_DATA>> GetPatMonitorDataListByEvent(string patientID, int visitID, int operID, string eventNo)
        {
            return Success(_pacuOperationInfoService.GetPatMonitorDataListByEvent(patientID, visitID, operID, eventNo));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_PAT_MONITOR_DATA_HISTORY>> GetPatMonitorHistoryList(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetPatMonitorHistoryList(patientID, visitID, operID));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_PAT_MONITOR_DATA_HISTORY>> GetPatMonitorHistoryList(string patientID, int visitID, int operID, string eventNo)
        {
            return Success(_pacuOperationInfoService.GetPatMonitorHistoryList(patientID, visitID, operID, eventNo));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_COMM_VITAL_REC>> GetCommVitalRecList(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetCommVitalRecList(patientID, visitID, operID));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_COMM_VITAL_REC>> GetCommVitalRecListByEventNo(string patientID, int visitID, int operID, string eventNo)
        {
            return Success(_pacuOperationInfoService.GetCommVitalRecListByEventNo(patientID, visitID, operID, eventNo));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_COMM_VITAL_REC_EXTEND>> GetCommVitalRecExtendList(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetCommVitalRecExtendList(patientID, visitID, operID));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_COMM_VITAL_REC_EXTEND>> GetCommVitalRecExtendListByEventNo(string patientID, int visitID, int operID, string eventNo)
        {
            return Success(_pacuOperationInfoService.GetCommVitalRecExtendListByEventNo(patientID, visitID, operID, eventNo));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_BLOOD_GAS_MASTER>> GetBloodGasMasterList(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetBloodGasMasterList(patientID, visitID, operID));
        }

        [HttpGet]
        public RequestResult<List<MED_BLOOD_GAS_MASTER>> GetBloodGasMasterAllList()
        {
            return Success(_pacuOperationInfoService.GetBloodGasMasterAllList());
        }

        [HttpGet]
        public RequestResult<List<MED_BLOOD_GAS_MASTER>> GetBloodGasMasterListByID(string detailID)
        {
            return Success(_pacuOperationInfoService.GetBloodGasMasterListByID(detailID));
        }
        /// <summary>
        /// 血气分析
        /// </summary>
        /// <param name="detailID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_BLOOD_GAS_DETAIL>> GetBloodGasDetailList(string detailID)
        {
            return Success(_pacuOperationInfoService.GetBloodGasDetailList(detailID));
        }
        /// 保存患者基本信息表
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<int> SavePatMasterIndex(MED_PAT_MASTER_INDEX item)
        {
            return Success(_pacuOperationInfoService.SavePatMasterIndex(item));
        }

        /// <summary>
        /// 批量保存患者基本信息表
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<int> SavePatMasterIndexList(List<MED_PAT_MASTER_INDEX> item)
        {
            return Success(_pacuOperationInfoService.SavePatMasterIndexList(item));
        }

        /// <summary>
        /// 保存患者手术信息表
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<int> SaveOperMaster(MED_OPERATION_MASTER item)
        {
            return Success(_pacuOperationInfoService.SaveOperMaster(item));
        }

        /// <summary>
        /// 批量保存患者手术信息表
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<int> SaveOperMasterList(List<MED_OPERATION_MASTER> item)
        {
            return Success(_pacuOperationInfoService.SaveOperMasterList(item));
        }

        /// <summary>
        /// 保存患者住院记录表
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<int> SavePatVisit(MED_PAT_VISIT item)
        {
            return Success(_pacuOperationInfoService.SavePatVisit(item));
        }

        /// <summary>
        /// 批量保存患者住院记录表
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<int> SavePatVisitList(List<MED_PAT_VISIT> item)
        {
            return Success(_pacuOperationInfoService.SavePatVisitList(item));
        }
        /// <summary>
        /// 保存文书基础表Basic table of medical instruments
        /// </summary>
        /// <param name="dyParams"></param>
        /// <returns></returns>
        /// <summary>
        public RequestResult<bool> SaveMedicalBasicDoc(dynamic dyParams)
        {
            RequestResult<bool> Result = new RequestResult<bool>();
            try
            {
                MED_OPERATION_MASTER operMaster = null;
                MED_PAT_MASTER_INDEX patMasterIndex = null;
                MED_PAT_VISIT patVisit = null;
                MED_PATS_IN_HOSPITAL patsInHospital = null;
                MED_ANESTHESIA_PLAN anesPlan = null;
                MED_ANESTHESIA_PLAN_EXAM anesPlanExam = null;
                MED_ANESTHESIA_PLAN_PMH anesPlanPmh = null;
                List<MED_OPERATION_EXTENDED> operExtended = null;
                List<MED_POSTOPERATIVE_EXTENDED> postExtended = null;
                List<MED_PREOPERATIVE_EXPANSION> preExpansion = null;
                if (dyParams.operMaster != null)
                {
                    string value = dyParams.operMaster.ToString();
                    operMaster = JsonConvert.DeserializeObject<MED_OPERATION_MASTER>(value);
                }
                if (dyParams.patMasterIndex != null)
                {
                    string value = dyParams.patMasterIndex.ToString();
                    patMasterIndex = JsonConvert.DeserializeObject<MED_PAT_MASTER_INDEX>(value);
                }
                if (dyParams.patVisit != null)
                {
                    string value = dyParams.patVisit.ToString();
                    patVisit = JsonConvert.DeserializeObject<MED_PAT_VISIT>(value);
                }
                if (dyParams.patsInHospital != null)
                {
                    string value = dyParams.patsInHospital.ToString();
                    patsInHospital = JsonConvert.DeserializeObject<MED_PATS_IN_HOSPITAL>(value);
                }
                if (dyParams.anesPlan != null)
                {
                    string value = dyParams.anesPlan.ToString();
                    anesPlan = JsonConvert.DeserializeObject<MED_ANESTHESIA_PLAN>(value);
                }
                if (dyParams.anesPlanExam != null)
                {
                    string value = dyParams.anesPlanExam.ToString();
                    anesPlanExam = JsonConvert.DeserializeObject<MED_ANESTHESIA_PLAN_EXAM>(value);
                }
                if (dyParams.anesPlanPmh != null)
                {
                    string value = dyParams.anesPlanPmh.ToString();
                    anesPlanPmh = JsonConvert.DeserializeObject<MED_ANESTHESIA_PLAN_PMH>(value);
                }
                if (dyParams.operExtended != null)
                {
                    string value = dyParams.operExtended.ToString();
                    operExtended = JsonConvert.DeserializeObject<List<MED_OPERATION_EXTENDED>>(value);
                }
                if (dyParams.postExtended != null)
                {
                    string value = dyParams.postExtended.ToString();
                    postExtended = JsonConvert.DeserializeObject<List<MED_POSTOPERATIVE_EXTENDED>>(value);
                }
                if (dyParams.preExpansion != null)
                {
                    string value = dyParams.preExpansion.ToString();
                    preExpansion = JsonConvert.DeserializeObject<List<MED_PREOPERATIVE_EXPANSION>>(value);
                }

                Result = Success(_pacuOperationInfoService.SaveMedicalBasicDoc(operMaster, patMasterIndex, patVisit, patsInHospital, anesPlan, anesPlanExam, anesPlanPmh, operExtended, postExtended, preExpansion));
            }
            catch (Exception ex)
            {
                Logger.Error("SaveMedicalBasicDoc:" + ex.Message);
            }
            return Result;
        }
        /// 保存手术信息
        /// </summary>
        /// <param name="dyParams"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<bool> SavePatientOperation(dynamic dyParams)
        {
            RequestResult<bool> Result = new RequestResult<bool>();
            try
            {
                List<MED_OPERATION_NAME> operNameOldList = null;
                List<MED_OPERATION_NAME> operNameNewList = null;
                MED_OPERATION_MASTER operMaster = null;
                MED_ANESTHESIA_PLAN anesPlan = null;
                MED_ANESTHESIA_PLAN_PMH anesPlanPmh = null;
                MED_ANESTHESIA_PLAN_EXAM anesPlanExam = null;
                MED_PAT_MASTER_INDEX patMasterIndex = null;
                MED_PAT_VISIT patVisit = null;
                MED_OPERATION_SCHEDULE operSchedlue = null;
                MED_OPERATION_MASTER_EXT operMasterExt = null;

                if (dyParams.operSchedlue != null)
                {
                    string value = dyParams.operSchedlue.ToString();
                    operSchedlue = JsonConvert.DeserializeObject<MED_OPERATION_SCHEDULE>(value);
                }
                if (dyParams.patVisit != null)
                {
                    string value = dyParams.patVisit.ToString();
                    patVisit = JsonConvert.DeserializeObject<MED_PAT_VISIT>(value);
                }
                if (dyParams.patMasterIndex != null)
                {
                    string value = dyParams.patMasterIndex.ToString();
                    patMasterIndex = JsonConvert.DeserializeObject<MED_PAT_MASTER_INDEX>(value);
                }
                if (dyParams.operNameOldList != null)
                {
                    string value = dyParams.operNameOldList.ToString();
                    operNameOldList = JsonConvert.DeserializeObject<List<MED_OPERATION_NAME>>(value);
                }
                if (dyParams.operNameNewList != null)
                {
                    string value = dyParams.operNameNewList.ToString();
                    operNameNewList = JsonConvert.DeserializeObject<List<MED_OPERATION_NAME>>(value);
                }
                if (dyParams.operMaster != null)
                {
                    string value = dyParams.operMaster.ToString();
                    operMaster = JsonConvert.DeserializeObject<MED_OPERATION_MASTER>(value);
                }
                if (dyParams.anesPlan != null)
                {
                    string value = dyParams.anesPlan.ToString();
                    anesPlan = JsonConvert.DeserializeObject<MED_ANESTHESIA_PLAN>(value);
                }
                if (dyParams.anesPlanPmh != null)
                {
                    string value = dyParams.anesPlanPmh.ToString();
                    anesPlanPmh = JsonConvert.DeserializeObject<MED_ANESTHESIA_PLAN_PMH>(value);
                }
                if (dyParams.anesPlanExam != null)
                {
                    string value = dyParams.anesPlanExam.ToString();
                    anesPlanExam = JsonConvert.DeserializeObject<MED_ANESTHESIA_PLAN_EXAM>(value);
                }
                if (dyParams.operMasterExt != null)
                {
                    string value = dyParams.operMasterExt.ToString();
                    operMasterExt = JsonConvert.DeserializeObject<MED_OPERATION_MASTER_EXT>(value);
                }

                Result = Success(_pacuOperationInfoService.SavePatientOperation(operSchedlue, patVisit, patMasterIndex, operNameOldList, operNameNewList, operMaster, anesPlan, anesPlanPmh, anesPlanExam, operMasterExt));
            }
            catch (Exception ex)
            {
                Logger.Error("SavePatientOperation:" + ex.Message);
            }
            return Result;

        }

        /// <summary>
        /// 批量保存体征修改表
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> SavePatMonitorExtList(List<MED_PAT_MONITOR_DATA_EXT> item)
        {
            return Success(_pacuOperationInfoService.SavePatMonitorExtList(item));
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> SaveCommVitalRecList(List<MED_COMM_VITAL_REC> item)
        {
            return Success(_pacuOperationInfoService.SaveCommVitalRecList(item));
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> SaveCommVitalRecExtList(List<MED_COMM_VITAL_REC_EXTEND> item)
        {
            return Success(_pacuOperationInfoService.SaveCommVitalRecExtList(item));
        }
        /// <summary>
        /// 人员交班信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_OPERATION_SHIFT_RECORD>> GetShiftRecordList(string patientID, int visitID, int operID, string shiftDuty)
        {
            return Success(_pacuOperationInfoService.GetShiftRecordList(patientID, visitID, operID, shiftDuty));
        }

        [HttpGet]
        public RequestResult<List<MED_OPERATION_SHIFT_RECORD>> GetShiftRecordListByID(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetShiftRecordListByID(patientID, visitID, operID));
        }
        /// <summary>
        /// 保存人员交班信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> SaveShiftRecordList(List<MED_OPERATION_SHIFT_RECORD> item)
        {
            return Success(_pacuOperationInfoService.SaveShiftRecordList(item));
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<bool> DelShiftRecord(MED_OPERATION_SHIFT_RECORD item)
        {
            return Success(_pacuOperationInfoService.DelShiftRecord(item));
        }
        /// <summary>
        /// 获取安全核查表
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<MED_SAFETY_CHECKS> GetSafetyCheckList(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetSafetyCheckList(patientID, visitID, operID));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_SAFETY_CHECKS>> GetSafetyCheckLists(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetSafetyCheckLists(patientID, visitID, operID));
        }
        /// <summary>
        /// 保存安全核查表
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> SaveSafetyCheckList(List<MED_SAFETY_CHECKS> item)
        {
            return Success(_pacuOperationInfoService.SaveSafetyCheckList(item));
        }
        [HttpPost]
        public RequestResult<int> SaveSafetyCheck(MED_SAFETY_CHECKS item)
        {
            return Success(_pacuOperationInfoService.SaveSafetyCheck(item));
        }
        /// <summary>
        /// 获取麻醉计划表
        /// </summary>
        [HttpGet]
        public RequestResult<MED_ANESTHESIA_PLAN> GetAnesPlan(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetAnesPlan(patientID, visitID, operID));
        }

        /// <summary>
        /// 获取麻醉计划表 术前访视（病史）
        /// </summary>
        [HttpGet]
        public RequestResult<MED_ANESTHESIA_PLAN_PMH> GetAnesPlanPmh(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetAnesPlanPmh(patientID, visitID, operID));
        }

        /// <summary>
        /// 获取麻醉计划表 术前访视（检查）
        /// </summary>
        [HttpGet]
        public RequestResult<MED_ANESTHESIA_PLAN_EXAM> GetAnesPlanExam(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetAnesPlanExam(patientID, visitID, operID));
        }

        /// <summary>
        /// 批量删除患者基本信息表
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<int> DeleteOperNameList(List<MED_OPERATION_NAME> item)
        {
            return Success(_pacuOperationInfoService.DeleteOperNameList(item));
        }

        /// <summary>
        /// 获取手术名称
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_OPERATION_NAME>> GetOperNameList(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetOperNameList(patientID, visitID, operID));
        }

        // <summary>
        /// 保存手术名称表
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> SaveOperNameList(List<MED_OPERATION_NAME> item)
        {
            return Success(_pacuOperationInfoService.SaveOperNameList(item));
        }

        /// <summary>
        /// 保存麻醉计划表
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<int> SaveAnesPlan(MED_ANESTHESIA_PLAN item)
        {
            return Success(_pacuOperationInfoService.SaveAnesPlan(item));
        }

        /// <summary>
        /// 保存麻醉计划表 术前访视（病史）
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<int> SaveAnesPlanPmh(MED_ANESTHESIA_PLAN_PMH item)
        {
            return Success(_pacuOperationInfoService.SaveAnesPlanPmh(item));
        }

        /// <summary>
        /// 保存麻醉计划表 术前访视（检查）
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<int> SaveAnesPlanExam(MED_ANESTHESIA_PLAN_EXAM item)
        {
            return Success(_pacuOperationInfoService.SaveAnesPlanExam(item));
        }

        /// <summary>
        /// 获取麻醉质控数据
        /// </summary>
        [HttpGet]
        public RequestResult<MED_ANESTHESIA_INPUT_DATA> GetAnesInputData(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetAnesInputData(patientID, visitID, operID));
        }
        /// <summary>
        /// 保存麻醉质控数据
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        [HttpPost]
        public RequestResult<int> SaveAnesInputData(MED_ANESTHESIA_INPUT_DATA item)
        {
            return Success(_pacuOperationInfoService.SaveAnesInputData(item));
        }

        [HttpPost]
        public RequestResult<int> UpdateAnesPlanOperName(MED_ANESTHESIA_PLAN item)
        {
            return Success(_pacuOperationInfoService.UpdateAnesPlanOperName(item));
        }
        /// <summary>
        /// 术后随访
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<MED_ANESTHESIA_RECOVER> GetAnesRecoverData(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetAnesRecoverData(patientID, visitID, operID));
        }
        /// <summary>
        /// 保存术后随访记录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> SaveAnesRecoverData(MED_ANESTHESIA_RECOVER item)
        {
            return Success(_pacuOperationInfoService.SaveAnesRecoverData(item));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_INQUIRY>> GetAnesInquiryList(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetAnesInquiryList(patientID, visitID, operID));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> SaveAnesInquiryData(MED_ANESTHESIA_INQUIRY item)
        {
            return Success(_pacuOperationInfoService.SaveAnesInquiryData(item));
        }
        [HttpGet]
        public RequestResult<List<MED_CONSULTATION_REGISTRATION>> GetConsultationList(string patientID, int visitID)
        {
            return Success(_pacuOperationInfoService.GetConsultationList(patientID, visitID));
        }
        [HttpGet]
        public RequestResult<List<MED_CONSULTATION_REGISTRATION>> GetConsultationListByID(string patientID)
        {
            return Success(_pacuOperationInfoService.GetConsultationListByID(patientID));
        }
        [HttpPost]
        public RequestResult<int> SaveConsultationData(MED_CONSULTATION_REGISTRATION item)
        {
            return Success(_pacuOperationInfoService.SaveConsultationData(item));
        }
        [HttpGet]
        public RequestResult<MED_PATS_IN_HOSPITAL> GetPatsInHospital(string inpNo)
        {
            return Success(_pacuOperationInfoService.GetPatsInHospital(inpNo));
        }
        [HttpGet]
        public RequestResult<MED_PATS_IN_HOSPITAL> GetPatsInHospitalByID(string patientID, int visitID)
        {
            return Success(_pacuOperationInfoService.GetPatsInHospitalByID(patientID, visitID));
        }
        [HttpPost]
        public RequestResult<int> SavePatsInHospital(MED_PATS_IN_HOSPITAL item)
        {
            return Success(_pacuOperationInfoService.SavePatsInHospital(item));
        }
        [HttpGet]
        public RequestResult<MED_OPERATION_ANALGESIC_MASTER> GetAnalgesicMaster(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetAnalgesicMaster(patientID, visitID, operID));
        }
        [HttpPost]
        public RequestResult<int> SaveAnalgesicMaster(MED_OPERATION_ANALGESIC_MASTER item)
        {
            return Success(_pacuOperationInfoService.SaveAnalgesicMaster(item));
        }
        [HttpGet]
        public RequestResult<List<MED_OPER_ANALGESIC_TOTAL>> GetAnalgesicTotalList(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetAnalgesicTotalList(patientID, visitID, operID));
        }
        [HttpPost]
        public RequestResult<int> SaveAnalgesicTotalList(List<MED_OPER_ANALGESIC_TOTAL> item)
        {
            return Success(_pacuOperationInfoService.SaveAnalgesicTotalList(item));
        }
        [HttpGet]
        public RequestResult<List<MED_OPER_ANALGESIC_MEDICINE>> GetAnalgesicMedicineList(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetAnalgesicMedicineList(patientID, visitID, operID));
        }
        [HttpPost]
        public RequestResult<int> SaveAnalgesicMedicineList(List<MED_OPER_ANALGESIC_MEDICINE> item)
        {
            return Success(_pacuOperationInfoService.SaveAnalgesicMedicineList(item));
        }
        [HttpGet]
        public RequestResult<MED_OPER_RISK_ESTIMATE> GetRickEstimate(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetRickEstimate(patientID, visitID, operID));
        }
        [HttpPost]
        public RequestResult<int> SaveRickEstimate(MED_OPER_RISK_ESTIMATE item)
        {
            return Success(_pacuOperationInfoService.SaveRickEstimate(item));
        }
        [HttpGet]
        public RequestResult<List<MED_QIXIE_QINGDIAN>> GetOperCheckList(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetOperCheckList(patientID, visitID, operID));
        }
        [HttpPost]
        public RequestResult<int> SaveOperCheckList(List<MED_QIXIE_QINGDIAN> item)
        {
            return Success(_pacuOperationInfoService.SaveOperCheckList(item));
        }
        [HttpPost]
        public RequestResult<int> SaveBloodGasMaster(List<MED_BLOOD_GAS_MASTER> item)
        {
            return Success(_pacuOperationInfoService.SaveBloodGasMaster(item));
        }
        [HttpPost]
        public RequestResult<int> SaveBloodGasDetail(List<MED_BLOOD_GAS_DETAIL> item)
        {
            return Success(_pacuOperationInfoService.SaveBloodGasDetail(item));
        }
        [HttpGet]
        public RequestResult<MED_PATIENT_MONITOR_CONFIG> GetMonitorConfig(string patientID, int visitID, int operID, string eventNo)
        {
            return Success(_pacuOperationInfoService.GetMonitorConfig(patientID, visitID, operID, eventNo));
        }
        [HttpPost]
        public RequestResult<int> SaveMonitorConfig(MED_PATIENT_MONITOR_CONFIG item)
        {
            return Success(_pacuOperationInfoService.SaveMonitorConfig(item));
        }
        [HttpGet]
        public RequestResult<MED_CONFIRMATION_PACU> GetConfirmationPACU(string patientID, int visitID, int operID, int operStatusCode)
        {
            return Success(_pacuOperationInfoService.GetConfirmationPACU(patientID, visitID, operID, operStatusCode));
        }
        [HttpPost]
        public RequestResult<int> SaveConfirmationPACU(MED_CONFIRMATION_PACU item)
        {
            return Success(_pacuOperationInfoService.SaveConfirmationPACU(item));
        }
        [HttpGet]
        public RequestResult<List<MED_STEWARD_MARK>> GetStewardMarkList(string patientID, int visitID, int operID)
        {
            return Success(_pacuOperationInfoService.GetStewardMarkList(patientID, visitID, operID));
        }
        [HttpPost]
        public RequestResult<int> SaveStewardMarkList(List<MED_STEWARD_MARK> item)
        {
            return Success(_pacuOperationInfoService.SaveStewardMarkList(item));
        }

        [HttpGet]
        public RequestResult<List<MED_ORDERS>> GetOrders(string patientID, int? visitID, DateTime? ExecuteBeginTime, DateTime? ExecuteEndTime)
        {
            return Success(_pacuOperationInfoService.GetOrders(patientID, visitID, ExecuteBeginTime, ExecuteEndTime));
        }
    }
}