using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class OperationInfoRepository : BaseRepository
    {
        public RequestResult<MED_PAT_VISIT> GetPatVisit(string patientID, int visitID)
        {
            string address = "PacuOperationInfo/GetPatVisit?patientID=" + patientID + "&visitID=" + visitID;
            return BaseRepository.GetCallApi<MED_PAT_VISIT>(address);
        }
        public RequestResult<MED_PAT_MASTER_INDEX> GetPatMasterIndex(string patientID)
        {
            string address = "PacuOperationInfo/GetPatMasterIndex?patientID=" + patientID;
            return BaseRepository.GetCallApi<MED_PAT_MASTER_INDEX>(address);
        }
        public RequestResult<MED_OPERATION_MASTER> GetOperMaster(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetOperMaster?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<MED_OPERATION_MASTER>(address);
        }
        public RequestResult<MED_OPERATION_MASTER_EXT> GetOperMasterExt(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetOperMasterExt?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<MED_OPERATION_MASTER_EXT>(address);
        }
        public RequestResult<List<MED_OPERATION_MASTER>> GetOperMasterByRoom(string operRoomNo)
        {
            string address = "PacuOperationInfo/GetOperMasterByRoom?operRoomNo=" + operRoomNo;
            return BaseRepository.GetCallApi<List<MED_OPERATION_MASTER>>(address);
        }
        public RequestResult<List<MED_ANESTHESIA_EVENT>> GetAnesEventList(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetAnesEventList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_ANESTHESIA_EVENT>>(address);
        }
        public RequestResult<List<MED_ANESTHESIA_EVENT>> GetAnesEventList(string patientID, int visitID, int operID, string eventNo)
        {
            string address = "PacuOperationInfo/GetAnesEventList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID + "&eventNo=" + eventNo;
            return BaseRepository.GetCallApi<List<MED_ANESTHESIA_EVENT>>(address);
        }
        public RequestResult<int> SaveAnesthesiaEventList(List<MED_ANESTHESIA_EVENT> item)
        {
            string address = "PacuOperationInfo/SaveAnesthesiaEventList";
            return BaseRepository.PostCallApi<List<MED_ANESTHESIA_EVENT>>(address, item);
        }
        public RequestResult<List<MED_PAT_MONITOR_DATA_EXT>> GetPatMonitorExtList(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetPatMonitorExtList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_PAT_MONITOR_DATA_EXT>>(address);
        }
        public RequestResult<List<MED_PAT_MONITOR_DATA_EXT>> GetPatMonitorExtList(string patientID, int visitID, int operID, string eventNo)
        {
            string address = "PacuOperationInfo/GetPatMonitorExtList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID + "&eventNo=" + eventNo;
            return BaseRepository.GetCallApi<List<MED_PAT_MONITOR_DATA_EXT>>(address);
        }
        public RequestResult<List<MED_PAT_MONITOR_DATA>> GetPatMonitorDataList(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetPatMonitorDataList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_PAT_MONITOR_DATA>>(address);
        }
        public RequestResult<List<MED_PAT_MONITOR_DATA>> GetPatMonitorDataListByEvent(string patientID, int visitID, int operID, string eventNo)
        {
            string address = "PacuOperationInfo/GetPatMonitorDataListByEvent?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID + "&eventNo=" + eventNo;
            return BaseRepository.GetCallApi<List<MED_PAT_MONITOR_DATA>>(address);
        }
        public RequestResult<List<MED_PAT_MONITOR_DATA_HISTORY>> GetPatMonitorHistoryList(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetPatMonitorHistoryList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_PAT_MONITOR_DATA_HISTORY>>(address);
        }
        public RequestResult<List<MED_PAT_MONITOR_DATA_HISTORY>> GetPatMonitorHistoryList(string patientID, int visitID, int operID, string eventNo)
        {
            string address = "PacuOperationInfo/GetPatMonitorHistoryList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID + "&eventNo=" + eventNo;
            return BaseRepository.GetCallApi<List<MED_PAT_MONITOR_DATA_HISTORY>>(address);
        }
        public RequestResult<List<MED_COMM_VITAL_REC>> GetCommVitalRecList(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetCommVitalRecList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_COMM_VITAL_REC>>(address);
        }
        public RequestResult<List<MED_COMM_VITAL_REC>> GetCommVitalRecListByEventNo(string patientID, int visitID, int operID, string eventNo)
        {
            string address = "PacuOperationInfo/GetCommVitalRecListByEventNo?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID + "&eventNo=" + eventNo;
            return BaseRepository.GetCallApi<List<MED_COMM_VITAL_REC>>(address);
        }

        public RequestResult<List<MED_COMM_VITAL_REC_EXTEND>> GetCommVitalRecExtendList(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetCommVitalRecExtendList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_COMM_VITAL_REC_EXTEND>>(address);
        }
        public RequestResult<List<MED_COMM_VITAL_REC_EXTEND>> GetCommVitalRecExtendListByEventNo(string patientID, int visitID, int operID, string eventNo)
        {
            string address = "PacuOperationInfo/GetCommVitalRecExtendListByEventNo?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID + "&eventNo=" + eventNo;
            return BaseRepository.GetCallApi<List<MED_COMM_VITAL_REC_EXTEND>>(address);
        }

        public RequestResult<List<MED_BLOOD_GAS_MASTER>> GetBloodGasMasterList(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetBloodGasMasterList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_BLOOD_GAS_MASTER>>(address);
        }
        public RequestResult<List<MED_BLOOD_GAS_MASTER>> GetBloodGasMasterListByID(string detailID)
        {
            string address = "PacuOperationInfo/GetBloodGasMasterListByID?detailID=" + detailID;
            return BaseRepository.GetCallApi<List<MED_BLOOD_GAS_MASTER>>(address);
        }
        public RequestResult<List<MED_BLOOD_GAS_MASTER>> GetBloodGasMasterAllList()
        {
            string address = "PacuOperationInfo/GetBloodGasMasterAllList";
            return BaseRepository.GetCallApi<List<MED_BLOOD_GAS_MASTER>>(address);
        }
        public RequestResult<List<MED_BLOOD_GAS_DETAIL>> GetBloodGasDetailList(string detailID)
        {
            string address = "PacuOperationInfo/GetBloodGasDetailList?detailID=" + detailID;
            return BaseRepository.GetCallApi<List<MED_BLOOD_GAS_DETAIL>>(address);
        }
        /// <summary>
        /// 保存患者基本信息表
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        public RequestResult<int> SavePatMasterIndex(MED_PAT_MASTER_INDEX item)
        {
            string address = "PacuOperationInfo/SavePatMasterIndex";
            return BaseRepository.PostCallApi<MED_PAT_MASTER_INDEX>(address, item);

        }
        /// <summary>
        /// 批量保存患者基本信息表
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        public RequestResult<int> SavePatMasterIndexList(List<MED_PAT_MASTER_INDEX> item)
        {
            string address = "PacuOperationInfo/SavePatMasterIndexList";
            return BaseRepository.PostCallApi<List<MED_PAT_MASTER_INDEX>>(address, item);
        }

        /// <summary>
        /// 保存患者手术信息表
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        public RequestResult<int> SaveOperMaster(MED_OPERATION_MASTER item)
        {
            string address = "PacuOperationInfo/SaveOperMaster";
            return BaseRepository.PostCallApi<MED_OPERATION_MASTER>(address, item);

        }
        /// <summary>
        /// 批量保存患者手术信息表
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        public RequestResult<int> SaveOperMasterList(List<MED_OPERATION_MASTER> item)
        {
            string address = "PacuOperationInfo/SaveOperMasterList";
            return BaseRepository.PostCallApi<List<MED_OPERATION_MASTER>>(address, item);
        }

        /// <summary>
        /// 保存患者住院记录表
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        public RequestResult<int> SavePatVisit(MED_PAT_VISIT item)
        {
            string address = "PacuOperationInfo/SavePatVisit";
            return BaseRepository.PostCallApi<MED_PAT_VISIT>(address, item);

        }
        /// <summary>
        /// 批量保存患者住院记录表
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        public RequestResult<int> SavePatVisitList(List<MED_PAT_VISIT> item)
        {
            string address = "PacuOperationInfo/SavePatVisitList";
            return BaseRepository.PostCallApi<List<MED_PAT_VISIT>>(address, item);
        }
        public RequestResult<bool> SaveMedicalBasicDoc(dynamic dyParams)
        {
            string address = "PacuOperationInfo/SaveMedicalBasicDoc";
            return BaseRepository.PostCallApi<dynamic, bool>(address, dyParams);
        }
        public RequestResult<bool> SavePatientOperation(dynamic dyParams)
        {
            string address = "PacuOperationInfo/SavePatientOperation";
            return BaseRepository.PostCallApi<dynamic, bool>(address, dyParams);
        }
        /// <summary>
        /// 批量保存体征修改表
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public RequestResult<int> SavePatMonitorExtList(List<MED_PAT_MONITOR_DATA_EXT> item)
        {
            string address = "PacuOperationInfo/SavePatMonitorExtList";
            return BaseRepository.PostCallApi<List<MED_PAT_MONITOR_DATA_EXT>>(address, item);
        }
        public RequestResult<int> SaveCommVitalRecList(List<MED_COMM_VITAL_REC> item)
        {
            string address = "PacuOperationInfo/SaveCommVitalRecList";
            return BaseRepository.PostCallApi<List<MED_COMM_VITAL_REC>>(address, item);
        }
        public RequestResult<int> SaveCommVitalRecExtList(List<MED_COMM_VITAL_REC_EXTEND> item)
        {
            string address = "PacuOperationInfo/SaveCommVitalRecExtList";
            return BaseRepository.PostCallApi<List<MED_COMM_VITAL_REC_EXTEND>>(address, item);
        }
        public RequestResult<List<MED_OPERATION_SHIFT_RECORD>> GetShiftRecordList(string patientID, int visitID, int operID, string shiftDuty)
        {
            string address = "PacuOperationInfo/GetShiftRecordList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID + "&shiftDuty=" + shiftDuty;
            return BaseRepository.GetCallApi<List<MED_OPERATION_SHIFT_RECORD>>(address);
        }
        public RequestResult<List<MED_OPERATION_SHIFT_RECORD>> GetShiftRecordListByID(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetShiftRecordListByID?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_OPERATION_SHIFT_RECORD>>(address);
        }
        public RequestResult<int> SaveShiftRecordList(List<MED_OPERATION_SHIFT_RECORD> item)
        {
            string address = "PacuOperationInfo/SaveShiftRecordList";
            return BaseRepository.PostCallApi<List<MED_OPERATION_SHIFT_RECORD>>(address, item);
        }
        public RequestResult<bool> DelShiftRecord(MED_OPERATION_SHIFT_RECORD item)
        {
            string address = "AnesEvent/DelShiftRecord";
            return BaseRepository.PostCallApi<MED_OPERATION_SHIFT_RECORD, bool>(address, item);
        }
        public RequestResult<List<MED_PAT_VISIT>> GetPatVisitList(string patientID)
        {
            string address = "PacuOperationInfo/GetPatVisitList?patientID=" + patientID;
            return BaseRepository.GetCallApi<List<MED_PAT_VISIT>>(address);
        }

        public RequestResult<List<MED_PAT_VISIT>> GetPatVisitListByInpNo(string inpNo)
        {
            string address = "PacuOperationInfo/GetPatVisitListByInpNo?inpNo=" + inpNo;
            return BaseRepository.GetCallApi<List<MED_PAT_VISIT>>(address);
        }

        public RequestResult<List<MED_OPERATION_MASTER>> GetOperMasterList(string patientID, int visitID)
        {
            string address = "PacuOperationInfo/GetOperMasterList?patientID=" + patientID + "&visitID=" + visitID;
            return BaseRepository.GetCallApi<List<MED_OPERATION_MASTER>>(address);
        }
        public RequestResult<List<MED_OPERATION_SCHEDULE>> GetOperScheduleList(string patientID, int visitID)
        {
            string address = "PacuOperationInfo/GetOperScheduleList?patientID=" + patientID + "&visitID=" + visitID;
            return BaseRepository.GetCallApi<List<MED_OPERATION_SCHEDULE>>(address);
        }
        public RequestResult<int> SaveOperScheduleList(List<MED_OPERATION_SCHEDULE> item)
        {
            string address = "PacuOperationInfo/SaveOperScheduleList";
            return BaseRepository.PostCallApi<List<MED_OPERATION_SCHEDULE>>(address, item);
        }
        public RequestResult<List<MED_SAFETY_CHECKS>> GetSafetyCheckLists(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetSafetyCheckLists?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_SAFETY_CHECKS>>(address);
        }
        public RequestResult<MED_SAFETY_CHECKS> GetSafetyCheckList(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetSafetyCheckLists?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<MED_SAFETY_CHECKS>(address);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public RequestResult<int> SaveSafetyCheckList(List<MED_SAFETY_CHECKS> item)
        {
            string address = "PacuOperationInfo/SaveSafetyCheckList";
            return BaseRepository.PostCallApi<List<MED_SAFETY_CHECKS>>(address, item);
        }
        public RequestResult<int> SaveSafetyCheck(MED_SAFETY_CHECKS item)
        {
            string address = "PacuOperationInfo/SaveSafetyCheck";
            return BaseRepository.PostCallApi<MED_SAFETY_CHECKS>(address, item);
        }

        public RequestResult<List<MED_OPERATION_NAME>> GetOperNameList(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetOperNameList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_OPERATION_NAME>>(address);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public RequestResult<int> SaveOperNameList(List<MED_OPERATION_NAME> item)
        {
            string address = "PacuOperationInfo/SaveOperNameList";
            return BaseRepository.PostCallApi<List<MED_OPERATION_NAME>>(address, item);
        }

        /// <summary>
        /// 删除手术名称表
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>

        public RequestResult<int> DeleteOperNameList(List<MED_OPERATION_NAME> item)
        {
            string address = "PacuOperationInfo/DeleteOperNameList";
            return BaseRepository.PostCallApi<List<MED_OPERATION_NAME>, int>(address, item);
        }

        /// <summary>
        /// 获取麻醉计划表 术前访视
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <returns></returns>
        public RequestResult<MED_ANESTHESIA_PLAN> GetAnesPlan(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetAnesPlan?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<MED_ANESTHESIA_PLAN>(address);
        }

        /// <summary>
        /// 获取麻醉计划表 术前访视（病史）
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <returns></returns>
        public RequestResult<MED_ANESTHESIA_PLAN_PMH> GetAnesPlanPmh(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetAnesPlanPmh?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<MED_ANESTHESIA_PLAN_PMH>(address);
        }

        /// <summary>
        /// 获取麻醉计划表 术前访视（检查）
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <returns></returns>
        public RequestResult<MED_ANESTHESIA_PLAN_EXAM> GetAnesPlanExam(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetAnesPlanExam?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<MED_ANESTHESIA_PLAN_EXAM>(address);
        }

        /// <summary>
        /// 保存麻醉计划表
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        public RequestResult<int> SaveAnesPlan(MED_ANESTHESIA_PLAN item)
        {
            string address = "PacuOperationInfo/SaveAnesPlan";
            return BaseRepository.PostCallApi<MED_ANESTHESIA_PLAN>(address, item);

        }

        /// <summary>
        /// 保存麻醉计划表 术前访视（病史）
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        public RequestResult<int> SaveAnesPlanPmh(MED_ANESTHESIA_PLAN_PMH item)
        {
            string address = "PacuOperationInfo/SaveAnesPlanPmh";
            return BaseRepository.PostCallApi<MED_ANESTHESIA_PLAN_PMH>(address, item);

        }

        /// <summary>
        /// 保存麻醉计划表 术前访视（检查）
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        public RequestResult<int> SaveAnesPlanExam(MED_ANESTHESIA_PLAN_EXAM item)
        {
            string address = "PacuOperationInfo/SaveAnesPlanExam";
            return BaseRepository.PostCallApi<MED_ANESTHESIA_PLAN_EXAM>(address, item);

        }

        /// <summary>
        /// 获取麻醉质控数据
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <returns></returns>
        public RequestResult<MED_ANESTHESIA_INPUT_DATA> GetAnesInputData(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetAnesInputData?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<MED_ANESTHESIA_INPUT_DATA>(address);
        }

        /// <summary>
        /// 保存麻醉质控数据
        /// </summary>
        /// <returns><![CDATA[RequestResult<string>]]></returns>
        public RequestResult<int> SaveAnesInputData(MED_ANESTHESIA_INPUT_DATA item)
        {
            string address = "PacuOperationInfo/SaveAnesInputData";
            return BaseRepository.PostCallApi<MED_ANESTHESIA_INPUT_DATA>(address, item);

        }

        public RequestResult<int> UpdateAnesPlanOperName(MED_ANESTHESIA_PLAN item)
        {
            string address = "PacuOperationInfo/UpdateAnesPlanOperName";
            return BaseRepository.PostCallApi<MED_ANESTHESIA_PLAN>(address, item);

        }
        /// <summary>
        /// 术后随访记录单
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        public RequestResult<MED_ANESTHESIA_RECOVER> GetAnesRecoverData(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetAnesRecoverData?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<MED_ANESTHESIA_RECOVER>(address);
        }
        public RequestResult<int> SaveAnesRecoverData(MED_ANESTHESIA_RECOVER item)
        {
            string address = "PacuOperationInfo/SaveAnesRecoverData";
            return BaseRepository.PostCallApi<MED_ANESTHESIA_RECOVER>(address, item);
        }
        public RequestResult<List<MED_ANESTHESIA_INQUIRY>> GetAnesInquiryList(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetAnesInquiryList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_ANESTHESIA_INQUIRY>>(address);
        }
        public RequestResult<int> SaveAnesInquiryData(MED_ANESTHESIA_INQUIRY item)
        {
            string address = "PacuOperationInfo/SaveAnesInquiryData";
            return BaseRepository.PostCallApi<MED_ANESTHESIA_INQUIRY>(address, item);
        }
        public RequestResult<List<MED_CONSULTATION_REGISTRATION>> GetConsultationList(string patientID, int visitID)
        {
            string address = "PacuOperationInfo/GetConsultationList?patientID=" + patientID + "&visitID=" + visitID;
            return BaseRepository.GetCallApi<List<MED_CONSULTATION_REGISTRATION>>(address);
        }
        public RequestResult<List<MED_CONSULTATION_REGISTRATION>> GetConsultationListByID(string patientID)
        {
            string address = "PacuOperationInfo/GetConsultationListByID?patientID=" + patientID;
            return BaseRepository.GetCallApi<List<MED_CONSULTATION_REGISTRATION>>(address);
        }
        public RequestResult<int> SaveConsultationData(MED_CONSULTATION_REGISTRATION item)
        {
            string address = "PacuOperationInfo/SaveConsultationData";
            return BaseRepository.PostCallApi<MED_CONSULTATION_REGISTRATION>(address, item);
        }
        public RequestResult<MED_PATS_IN_HOSPITAL> GetPatsInHospital(string inpNo)
        {
            string address = "PacuOperationInfo/GetPatsInHospital?inpNo=" + inpNo;
            return BaseRepository.GetCallApi<MED_PATS_IN_HOSPITAL>(address);
        }
        public RequestResult<MED_PATS_IN_HOSPITAL> GetPatsInHospitalByID(string patientID, int visitID)
        {
            string address = "PacuOperationInfo/GetPatsInHospitalByID?patientID=" + patientID + "&visitID=" + visitID;
            return BaseRepository.GetCallApi<MED_PATS_IN_HOSPITAL>(address);
        }
        public RequestResult<int> SavePatsInHospital(MED_PATS_IN_HOSPITAL item)
        {
            string address = "PacuOperationInfo/SavePatsInHospital";
            return BaseRepository.PostCallApi<MED_PATS_IN_HOSPITAL>(address, item);
        }
        public RequestResult<MED_OPERATION_ANALGESIC_MASTER> GetAnalgesicMaster(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetAnalgesicMaster?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<MED_OPERATION_ANALGESIC_MASTER>(address);
        }
        public RequestResult<int> SaveAnalgesicMaster(MED_OPERATION_ANALGESIC_MASTER item)
        {
            string address = "PacuOperationInfo/SaveAnalgesicMaster";
            return BaseRepository.PostCallApi<MED_OPERATION_ANALGESIC_MASTER>(address, item);
        }
        public RequestResult<List<MED_OPER_ANALGESIC_TOTAL>> GetAnalgesicTotalList(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetAnalgesicTotalList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_OPER_ANALGESIC_TOTAL>>(address);
        }
        public RequestResult<int> SaveAnalgesicTotalList(List<MED_OPER_ANALGESIC_TOTAL> item)
        {
            string address = "PacuOperationInfo/SaveAnalgesicTotalList";
            return BaseRepository.PostCallApi<List<MED_OPER_ANALGESIC_TOTAL>>(address, item);
        }
        public RequestResult<List<MED_OPER_ANALGESIC_MEDICINE>> GetAnalgesicMedicineList(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetAnalgesicMedicineList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_OPER_ANALGESIC_MEDICINE>>(address);
        }
        public RequestResult<int> SaveAnalgesicMedicineList(List<MED_OPER_ANALGESIC_MEDICINE> item)
        {
            string address = "PacuOperationInfo/SaveAnalgesicMedicineList";
            return BaseRepository.PostCallApi<List<MED_OPER_ANALGESIC_MEDICINE>>(address, item);
        }
        public RequestResult<MED_OPER_RISK_ESTIMATE> GetRickEstimate(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetRickEstimate?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<MED_OPER_RISK_ESTIMATE>(address);
        }
        public RequestResult<int> SaveRickEstimate(MED_OPER_RISK_ESTIMATE item)
        {
            string address = "PacuOperationInfo/SaveRickEstimate";
            return BaseRepository.PostCallApi<MED_OPER_RISK_ESTIMATE>(address, item);
        }
        public RequestResult<List<MED_QIXIE_QINGDIAN>> GetOperCheckList(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetOperCheckList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_QIXIE_QINGDIAN>>(address);
        }
        public RequestResult<int> SaveOperCheckList(List<MED_QIXIE_QINGDIAN> item)
        {
            string address = "PacuOperationInfo/SaveOperCheckList";
            return BaseRepository.PostCallApi<List<MED_QIXIE_QINGDIAN>>(address, item);
        }
        public RequestResult<int> SaveBloodGasMaster(List<MED_BLOOD_GAS_MASTER> item)
        {
            string address = "PacuOperationInfo/SaveBloodGasMaster";
            return BaseRepository.PostCallApi<List<MED_BLOOD_GAS_MASTER>>(address, item);
        }
        public RequestResult<int> SaveBloodGasDetail(List<MED_BLOOD_GAS_DETAIL> item)
        {
            string address = "PacuOperationInfo/SaveBloodGasDetail";
            return BaseRepository.PostCallApi<List<MED_BLOOD_GAS_DETAIL>>(address, item);
        }
        public RequestResult<MED_PATIENT_MONITOR_CONFIG> GetMonitorConfig(string patientID, int visitID, int operID, string eventNo)
        {
            string address = "PacuOperationInfo/GetMonitorConfig?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID + "&eventNo=" + eventNo;
            return BaseRepository.GetCallApi<MED_PATIENT_MONITOR_CONFIG>(address);
        }
        public RequestResult<int> SaveMonitorConfig(MED_PATIENT_MONITOR_CONFIG item)
        {
            string address = "PacuOperationInfo/SaveMonitorConfig";
            return BaseRepository.PostCallApi<MED_PATIENT_MONITOR_CONFIG>(address, item);
        }
        public RequestResult<MED_CONFIRMATION_PACU> GetConfirmationPACU(string patientID, int visitID, int operID, int operStatusCode)
        {
            string address = "PacuOperationInfo/GetConfirmationPACU?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID + "&operStatusCode=" + operStatusCode;
            return BaseRepository.GetCallApi<MED_CONFIRMATION_PACU>(address);
        }
        public RequestResult<int> SaveConfirmationPACU(MED_CONFIRMATION_PACU item)
        {
            string address = "PacuOperationInfo/SaveConfirmationPACU";
            return BaseRepository.PostCallApi<MED_CONFIRMATION_PACU>(address, item);
        }
        public RequestResult<List<MED_STEWARD_MARK>> GetStewardMarkList(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationInfo/GetStewardMarkList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_STEWARD_MARK>>(address);
        }
        public RequestResult<int> SaveStewardMarkList(List<MED_STEWARD_MARK> item)
        {
            string address = "PacuOperationInfo/SaveStewardMarkList";
            return BaseRepository.PostCallApi<List<MED_STEWARD_MARK>>(address, item);
        }

        public RequestResult<List<MED_ORDERS>> GetOrders(string patientID, int? visitID, DateTime? ExecuteBeginTime, DateTime? ExecuteEndTime)
        {
            string address = "PacuOperationInfo/GetOrders?patientID=" + patientID + "&visitID=" + visitID + "&ExecuteBeginTime=" + ExecuteBeginTime + "&ExecuteEndTime=" + ExecuteEndTime;
            return BaseRepository.GetCallApi<List<MED_ORDERS>>(address);
        }
    }
}
