using System;
using System.Collections.Generic;
using System.Linq;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPacuOperationInfoService
    {
        bool SavePatientOperation(MED_OPERATION_SCHEDULE operSchedule, MED_PAT_VISIT patVisit, MED_PAT_MASTER_INDEX patMasterIndex, List<MED_OPERATION_NAME> operNameOldList, List<MED_OPERATION_NAME> operNameNewList, MED_OPERATION_MASTER operationMaster, MED_ANESTHESIA_PLAN anesPlan, MED_ANESTHESIA_PLAN_PMH anesPlanPmh, MED_ANESTHESIA_PLAN_EXAM anesPlanExam, MED_OPERATION_MASTER_EXT operMasterExt);

        bool SaveMedicalBasicDoc(MED_OPERATION_MASTER operMaster, MED_PAT_MASTER_INDEX patMasterIndex, MED_PAT_VISIT patVisit, MED_PATS_IN_HOSPITAL patsInHospital,
                MED_ANESTHESIA_PLAN anesPlan, MED_ANESTHESIA_PLAN_EXAM anesPlanExam, MED_ANESTHESIA_PLAN_PMH anesPlanPmh, List<MED_OPERATION_EXTENDED> operExtended,
                List<MED_POSTOPERATIVE_EXTENDED> postExtended, List<MED_PREOPERATIVE_EXPANSION> preExpansion);
        int UpdateAnesPlanOperName(MED_ANESTHESIA_PLAN anesPlan);

        MED_PAT_VISIT GetPatVisit(string patientID, int visitID);

        List<MED_PAT_VISIT> GetPatVisitList(string patientID);

        List<MED_PAT_VISIT> GetPatVisitListByInpNo(string inpNo);

        List<MED_OPERATION_MASTER> GetOperMasterList(string patientID, int visitID);

        List<MED_OPERATION_MASTER> GetOperMasterByRoom(string operRoomNo);

        List<MED_OPERATION_MASTER> GetOperMasterByStatus(int statusCode, int endStatusCode);

        List<MED_OPERATION_SCHEDULE> GetOperScheduleList(string patientID, int visitID);

        int SaveOperScheduleList(List<MED_OPERATION_SCHEDULE> item);

        MED_PAT_MASTER_INDEX GetPatMasterIndex(string patientID);

        MED_OPERATION_MASTER GetOperMaster(string patientID, int visitID, int operID);

        MED_OPERATION_MASTER_EXT GetOperMasterExt(string patientID, int visitID, int operID);

        List<MED_ANESTHESIA_EVENT> GetAnesEventList(string patientID, int visitID, int operID);

        List<MED_ANESTHESIA_EVENT> GetAnesEventList(string patientID, int visitID, int operID, string eventNo);

        int SaveAnesthesiaEventList(List<MED_ANESTHESIA_EVENT> item);

        List<MED_PAT_MONITOR_DATA_EXT> GetPatMonitorExtList(string patientID, int visitID, int operID);

        List<MED_PAT_MONITOR_DATA_EXT> GetPatMonitorExtList(string patientID, int visitID, int operID, string eventNo);

        List<MED_PAT_MONITOR_DATA> GetPatMonitorDataList(string patientID, int visitID, int operID);

        List<MED_PAT_MONITOR_DATA> GetPatMonitorDataListByEvent(string patientID, int visitID, int operID, string eventNo);

        List<MED_PAT_MONITOR_DATA_HISTORY> GetPatMonitorHistoryList(string patientID, int visitID, int operID);

        List<MED_PAT_MONITOR_DATA_HISTORY> GetPatMonitorHistoryList(string patientID, int visitID, int operID, string eventNo);

        List<MED_COMM_VITAL_REC> GetCommVitalRecList(string patientID, int visitID, int operID);

        List<MED_COMM_VITAL_REC> GetCommVitalRecListByEventNo(string patientID, int visitID, int operID, string eventNo);

        List<MED_COMM_VITAL_REC_EXTEND> GetCommVitalRecExtendList(string patientID, int visitID, int operID);

        List<MED_COMM_VITAL_REC_EXTEND> GetCommVitalRecExtendListByEventNo(string patientID, int visitID, int operID, string eventNo);

        List<MED_BLOOD_GAS_MASTER> GetBloodGasMasterList(string patientID, int visitID, int operID);

        List<MED_BLOOD_GAS_MASTER> GetBloodGasMasterAllList();

        List<MED_BLOOD_GAS_MASTER> GetBloodGasMasterListByID(string detailID);

        List<MED_BLOOD_GAS_DETAIL> GetBloodGasDetailList(string detailID);

        int SavePatMasterIndex(MED_PAT_MASTER_INDEX item);

        int SavePatMasterIndexList(List<MED_PAT_MASTER_INDEX> item);

        int SaveOperMaster(MED_OPERATION_MASTER item);

        int SaveOperMasterList(List<MED_OPERATION_MASTER> item);

        int SavePatVisit(MED_PAT_VISIT item);

        int SavePatVisitList(List<MED_PAT_VISIT> item);

        int SavePatMonitorExtList(List<MED_PAT_MONITOR_DATA_EXT> item);

        int SaveCommVitalRecList(List<MED_COMM_VITAL_REC> item);

        int SaveCommVitalRecExtList(List<MED_COMM_VITAL_REC_EXTEND> item);

        List<MED_OPERATION_SHIFT_RECORD> GetShiftRecordList(string patientID, int visitID, int operID, string shiftDuty);

        List<MED_OPERATION_SHIFT_RECORD> GetShiftRecordListByID(string patientID, int visitID, int operID);

        int SaveShiftRecordList(List<MED_OPERATION_SHIFT_RECORD> item);

        bool DelShiftRecord(MED_OPERATION_SHIFT_RECORD item);

        MED_SAFETY_CHECKS GetSafetyCheckList(string patientID, int visitID, int operID);

        List<MED_SAFETY_CHECKS> GetSafetyCheckLists(string patientID, int visitID, int operID);

        int SaveSafetyCheckList(List<MED_SAFETY_CHECKS> item);

        int SaveSafetyCheck(MED_SAFETY_CHECKS item);

        MED_ANESTHESIA_PLAN GetAnesPlan(string patientID, int visitID, int operID);

        MED_ANESTHESIA_PLAN_PMH GetAnesPlanPmh(string patientID, int visitID, int operID);

        MED_ANESTHESIA_PLAN_EXAM GetAnesPlanExam(string patientID, int visitID, int operID);

        int DeleteOperNameList(List<MED_OPERATION_NAME> item);

        List<MED_OPERATION_NAME> GetOperNameList(string patientID, int visitID, int operID);

        int SaveOperNameList(List<MED_OPERATION_NAME> item);

        int SaveAnesPlan(MED_ANESTHESIA_PLAN item);

        int SaveAnesPlanPmh(MED_ANESTHESIA_PLAN_PMH item);

        int SaveAnesPlanExam(MED_ANESTHESIA_PLAN_EXAM item);

        MED_ANESTHESIA_INPUT_DATA GetAnesInputData(string patientID, int visitID, int operID);

        int SaveAnesInputData(MED_ANESTHESIA_INPUT_DATA item);

        MED_ANESTHESIA_RECOVER GetAnesRecoverData(string patientID, int visitID, int operID);

        int SaveAnesRecoverData(MED_ANESTHESIA_RECOVER item);

        List<MED_ANESTHESIA_INQUIRY> GetAnesInquiryList(string patientID, int visitID, int operID);

        int SaveAnesInquiryData(MED_ANESTHESIA_INQUIRY item);

        List<MED_CONSULTATION_REGISTRATION> GetConsultationList(string patientID, int visitID);

        List<MED_CONSULTATION_REGISTRATION> GetConsultationListByID(string patientID);

        int SaveConsultationData(MED_CONSULTATION_REGISTRATION item);

        MED_PATS_IN_HOSPITAL GetPatsInHospital(string inpNo);

        MED_PATS_IN_HOSPITAL GetPatsInHospitalByID(string patientID, int visitID);

        int SavePatsInHospital(MED_PATS_IN_HOSPITAL item);

        MED_OPERATION_ANALGESIC_MASTER GetAnalgesicMaster(string patientID, int visitID, int operID);

        int SaveAnalgesicMaster(MED_OPERATION_ANALGESIC_MASTER item);

        List<MED_OPER_ANALGESIC_TOTAL> GetAnalgesicTotalList(string patientID, int visitID, int operID);

        int SaveAnalgesicTotalList(List<MED_OPER_ANALGESIC_TOTAL> item);

        List<MED_OPER_ANALGESIC_MEDICINE> GetAnalgesicMedicineList(string patientID, int visitID, int operID);

        int SaveAnalgesicMedicineList(List<MED_OPER_ANALGESIC_MEDICINE> item);

        MED_OPER_RISK_ESTIMATE GetRickEstimate(string patientID, int visitID, int operID);

        int SaveRickEstimate(MED_OPER_RISK_ESTIMATE item);

        List<MED_QIXIE_QINGDIAN> GetOperCheckList(string patientID, int visitID, int operID);

        int SaveOperCheckList(List<MED_QIXIE_QINGDIAN> item);

        int SaveBloodGasMaster(List<MED_BLOOD_GAS_MASTER> item);

        int SaveBloodGasDetail(List<MED_BLOOD_GAS_DETAIL> item);

        MED_PATIENT_MONITOR_CONFIG GetMonitorConfig(string patientID, int visitID, int operID, string eventNo);

        int SaveMonitorConfig(MED_PATIENT_MONITOR_CONFIG item);

        MED_CONFIRMATION_PACU GetConfirmationPACU(string patientID, int visitID, int operID, int operStatusCode);

        int SaveConfirmationPACU(MED_CONFIRMATION_PACU item);

        List<MED_STEWARD_MARK> GetStewardMarkList(string patientID, int visitID, int operID);

        int SaveStewardMarkList(List<MED_STEWARD_MARK> item);


        List<MED_ORDERS> GetOrders(string PATIENT_ID, int? VISIT_ID, DateTime? ExecuteBeginTime, DateTime? ExecuteEndTime);

    }

    public class PacuOperationInfoService : BaseService<PacuOperationInfoService>, IPacuOperationInfoService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PacuOperationInfoService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PacuOperationInfoService(IDapperContext context)
            : base(context)
        {
        }

        public bool SavePatientOperation(MED_OPERATION_SCHEDULE operSchedule, MED_PAT_VISIT patVisit,
           MED_PAT_MASTER_INDEX patMasterIndex, List<MED_OPERATION_NAME> operNameOldList,
           List<MED_OPERATION_NAME> operNameNewList, MED_OPERATION_MASTER operMaster,
           MED_ANESTHESIA_PLAN anesPlan, MED_ANESTHESIA_PLAN_PMH anesPlanPmh,
           MED_ANESTHESIA_PLAN_EXAM anesPlanExam, MED_OPERATION_MASTER_EXT operMasterExt)
        {
            bool flag = true;

            if (operSchedule != null)
            {
                flag = flag & dapper.Set<MED_OPERATION_SCHEDULE>().Save(operSchedule);
            }
            if (patVisit != null)
            {
                flag = flag & dapper.Set<MED_PAT_VISIT>().Save(patVisit);
            }
            if (patMasterIndex != null)
            {
                flag = flag & dapper.Set<MED_PAT_MASTER_INDEX>().Save(patMasterIndex);
            }
            if (operNameOldList != null && operNameOldList.Count > 0)
            {
                foreach (var item in operNameNewList)
                {
                    flag = flag & dapper.Set<MED_OPERATION_NAME>().Delete(item);
                }
            }
            if (operNameNewList != null && operNameNewList.Count > 0)
            {
                foreach (var item in operNameNewList)
                {
                    flag = flag & dapper.Set<MED_OPERATION_NAME>().Save(item);
                }
            }
            if (operMaster != null)
            {
                flag = flag & dapper.Set<MED_OPERATION_MASTER>().Save(operMaster);
            }
            if (anesPlan != null)
            {
                flag = flag & dapper.Set<MED_ANESTHESIA_PLAN>().Save(anesPlan);
            }
            if (anesPlanPmh != null)
            {
                flag = flag & dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Save(anesPlanPmh);
            }
            if (anesPlanExam != null)
            {
                flag = flag & dapper.Set<MED_ANESTHESIA_PLAN_EXAM>().Save(anesPlanExam);
            }
            if (operMasterExt != null)
            {
                flag = flag & dapper.Set<MED_OPERATION_MASTER_EXT>().Save(operMasterExt);
            }
            if (flag)
            {
                dapper.SaveChanges();
            }

            return flag;
        }

        public bool SaveMedicalBasicDoc(MED_OPERATION_MASTER operMaster, MED_PAT_MASTER_INDEX patMasterIndex, MED_PAT_VISIT patVisit, MED_PATS_IN_HOSPITAL patsInHospital,
                MED_ANESTHESIA_PLAN anesPlan, MED_ANESTHESIA_PLAN_EXAM anesPlanExam, MED_ANESTHESIA_PLAN_PMH anesPlanPmh, List<MED_OPERATION_EXTENDED> operExtended,
                List<MED_POSTOPERATIVE_EXTENDED> postExtended, List<MED_PREOPERATIVE_EXPANSION> preExpansion)
        {
            bool flag = true;
            if (operMaster != null)
            {
                flag = flag & dapper.Set<MED_OPERATION_MASTER>().Save(operMaster);
            }
            if (patVisit != null)
            {
                flag = flag & dapper.Set<MED_PAT_VISIT>().Save(patVisit);
            }
            if (patMasterIndex != null)
            {
                flag = flag & dapper.Set<MED_PAT_MASTER_INDEX>().Save(patMasterIndex);
            }
            if (patsInHospital != null)
            {
                flag = flag & dapper.Set<MED_PATS_IN_HOSPITAL>().Save(patsInHospital);
            }
            if (anesPlan != null)
            {
                flag = flag & dapper.Set<MED_ANESTHESIA_PLAN>().Save(anesPlan);
            }
            if (anesPlanPmh != null)
            {
                flag = flag & dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Save(anesPlanPmh);
            }
            if (anesPlanExam != null)
            {
                flag = flag & dapper.Set<MED_ANESTHESIA_PLAN_EXAM>().Save(anesPlanExam);
            }
            if (operExtended != null && operExtended.Count > 0)
            {

                flag = flag & dapper.Set<MED_OPERATION_EXTENDED>().Save(operExtended) > 0 ? true : false;

                //foreach (var item in operExtended)
                //{
                //    flag = flag & dapper.Set<MED_OPERATION_EXTENDED>().Save(item);
                //}
            }
            if (postExtended != null && postExtended.Count > 0)
            {

                flag = flag & dapper.Set<MED_POSTOPERATIVE_EXTENDED>().Save(postExtended) > 0 ? true : false;

                //foreach (var item in postExtended)
                //{
                //    flag = flag & dapper.Set<MED_POSTOPERATIVE_EXTENDED>().Save(item);
                //}
            }
            if (preExpansion != null && preExpansion.Count > 0)
            {
                flag = flag & dapper.Set<MED_PREOPERATIVE_EXPANSION>().Save(preExpansion) > 0 ? true : false;

                //foreach (var item in preExpansion)
                //{
                //    flag = flag & dapper.Set<MED_PREOPERATIVE_EXPANSION>().Save(item);
                //}
            }
            if (flag)
            {
                dapper.SaveChanges();
            }
            return flag;
        }

        public int UpdateAnesPlanOperName(MED_ANESTHESIA_PLAN item)
        {
            int result = dapper.Set<MED_ANESTHESIA_PLAN>().Update(item, p => new { p.OPERATION_NAME });
            dapper.SaveChanges();
            return result;
        }

        public MED_PAT_VISIT GetPatVisit(string patientID, int visitID)
        {
            return dapper.Set<MED_PAT_VISIT>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID).FirstOrDefault();
        }

        public List<MED_PAT_VISIT> GetPatVisitList(string patientID)
        {
            return dapper.Set<MED_PAT_VISIT>().Select(d => d.PATIENT_ID == patientID);
        }

        public List<MED_PAT_VISIT> GetPatVisitListByInpNo(string inpNo)
        {
            return dapper.Set<MED_PAT_VISIT>().Select(d => d.INP_NO == inpNo);
        }

        public List<MED_OPERATION_MASTER> GetOperMasterList(string patientID, int visitID)
        {
            return dapper.Set<MED_OPERATION_MASTER>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID);
        }

        public List<MED_OPERATION_MASTER> GetOperMasterByRoom(string operRoomNo)
        {
            return dapper.Set<MED_OPERATION_MASTER>().Select(d => d.OPER_ROOM_NO == operRoomNo);
        }

        public List<MED_OPERATION_MASTER> GetOperMasterByStatus(int statusCode, int endStatusCode)
        {
            return dapper.Set<MED_OPERATION_MASTER>().Select(d => d.OPER_STATUS_CODE >= statusCode && d.OPER_STATUS_CODE < endStatusCode && d.OUT_DATE_TIME.HasValue);
        }

        public List<MED_OPERATION_SCHEDULE> GetOperScheduleList(string patientID, int visitID)
        {
            return dapper.Set<MED_OPERATION_SCHEDULE>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID);
        }

        public int SaveOperScheduleList(List<MED_OPERATION_SCHEDULE> item)
        {
            int result = dapper.Set<MED_OPERATION_SCHEDULE>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public MED_PAT_MASTER_INDEX GetPatMasterIndex(string patientID)
        {
            return dapper.Set<MED_PAT_MASTER_INDEX>().Select(d => d.PATIENT_ID == patientID).FirstOrDefault();
        }

        public MED_OPERATION_MASTER GetOperMaster(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_OPERATION_MASTER>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).FirstOrDefault();
        }

        public MED_OPERATION_MASTER_EXT GetOperMasterExt(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_OPERATION_MASTER_EXT>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).FirstOrDefault();
        }

        public List<MED_ANESTHESIA_EVENT> GetAnesEventList(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_ANESTHESIA_EVENT>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).OrderBy(t => t.PATIENT_ID).ToList();
        }

        public List<MED_ANESTHESIA_EVENT> GetAnesEventList(string patientID, int visitID, int operID, string eventNo)
        {
            return dapper.Set<MED_ANESTHESIA_EVENT>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID && d.EVENT_NO == eventNo).OrderBy(t => t.PATIENT_ID).ToList();
        }

        public int SaveAnesthesiaEventList(List<MED_ANESTHESIA_EVENT> item)
        {
            int result = dapper.Set<MED_ANESTHESIA_EVENT>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public List<MED_PAT_MONITOR_DATA_EXT> GetPatMonitorExtList(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_PAT_MONITOR_DATA_EXT>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).OrderBy(t => t.TIME_POINT).ToList();
        }

        public List<MED_PAT_MONITOR_DATA_EXT> GetPatMonitorExtList(string patientID, int visitID, int operID, string eventNo)
        {
            return dapper.Set<MED_PAT_MONITOR_DATA_EXT>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID && d.DATA_TYPE == eventNo).OrderBy(t => t.TIME_POINT).ToList();
        }

        public List<MED_PAT_MONITOR_DATA> GetPatMonitorDataList(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_PAT_MONITOR_DATA>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).OrderBy(t => t.TIME_POINT).ToList();
        }

        public List<MED_PAT_MONITOR_DATA> GetPatMonitorDataListByEvent(string patientID, int visitID, int operID, string eventNo)
        {
            return dapper.Set<MED_PAT_MONITOR_DATA>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID && d.DATA_TYPE == eventNo).OrderBy(t => t.TIME_POINT).ToList();
        }

        public List<MED_PAT_MONITOR_DATA_HISTORY> GetPatMonitorHistoryList(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_PAT_MONITOR_DATA_HISTORY>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).OrderBy(t => t.TIME_POINT).ToList();
        }

        public List<MED_PAT_MONITOR_DATA_HISTORY> GetPatMonitorHistoryList(string patientID, int visitID, int operID, string eventNo)
        {
            return dapper.Set<MED_PAT_MONITOR_DATA_HISTORY>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID && d.DATA_TYPE == eventNo).OrderBy(t => t.TIME_POINT).ToList();
        }

        public List<MED_COMM_VITAL_REC> GetCommVitalRecList(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_COMM_VITAL_REC>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).OrderBy(t => t.TIME_POINT).ToList();
        }

        public List<MED_COMM_VITAL_REC> GetCommVitalRecListByEventNo(string patientID, int visitID, int operID, string eventNo)
        {
            return dapper.Set<MED_COMM_VITAL_REC>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID && d.DATA_TYPE == eventNo).OrderBy(t => t.TIME_POINT).ToList();
        }

        public List<MED_COMM_VITAL_REC_EXTEND> GetCommVitalRecExtendList(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_COMM_VITAL_REC_EXTEND>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).OrderBy(t => t.TIME_POINT).ToList();
        }

        public List<MED_COMM_VITAL_REC_EXTEND> GetCommVitalRecExtendListByEventNo(string patientID, int visitID, int operID, string eventNo)
        {
            return dapper.Set<MED_COMM_VITAL_REC_EXTEND>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID && d.DATA_TYPE == eventNo).OrderBy(t => t.TIME_POINT).ToList();
        }

        public List<MED_BLOOD_GAS_MASTER> GetBloodGasMasterList(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_BLOOD_GAS_MASTER>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).OrderBy(t => t.PATIENT_ID).ToList();
        }

        public List<MED_BLOOD_GAS_MASTER> GetBloodGasMasterAllList()
        {
            return dapper.Set<MED_BLOOD_GAS_MASTER>().Select().OrderBy(t => t.PATIENT_ID).ToList();
        }

        public List<MED_BLOOD_GAS_MASTER> GetBloodGasMasterListByID(string detailID)
        {
            return dapper.Set<MED_BLOOD_GAS_MASTER>().Select(d => d.DETAIL_ID == detailID).OrderBy(t => t.PATIENT_ID).ToList();
        }

        public List<MED_BLOOD_GAS_DETAIL> GetBloodGasDetailList(string detailID)
        {
            return dapper.Set<MED_BLOOD_GAS_DETAIL>().Select(d => d.DETAIL_ID == detailID).OrderBy(t => t.BLG_CODE).ToList();
        }

        public int SavePatMasterIndex(MED_PAT_MASTER_INDEX item)
        {
            int result = dapper.Set<MED_PAT_MASTER_INDEX>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public int SavePatMasterIndexList(List<MED_PAT_MASTER_INDEX> item)
        {
            int result = dapper.Set<MED_PAT_MASTER_INDEX>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public int SaveOperMaster(MED_OPERATION_MASTER item)
        {
            int result = dapper.Set<MED_OPERATION_MASTER>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public int SaveOperMasterList(List<MED_OPERATION_MASTER> item)
        {
            int result = dapper.Set<MED_OPERATION_MASTER>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public int SavePatVisit(MED_PAT_VISIT item)
        {
            int result = dapper.Set<MED_PAT_VISIT>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public int SavePatVisitList(List<MED_PAT_VISIT> item)
        {
            int result = dapper.Set<MED_PAT_VISIT>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public int SavePatMonitorExtList(List<MED_PAT_MONITOR_DATA_EXT> item)
        {
            int result = dapper.Set<MED_PAT_MONITOR_DATA_EXT>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public int SaveCommVitalRecList(List<MED_COMM_VITAL_REC> item)
        {
            int result = dapper.Set<MED_COMM_VITAL_REC>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public int SaveCommVitalRecExtList(List<MED_COMM_VITAL_REC_EXTEND> item)
        {
            int result = dapper.Set<MED_COMM_VITAL_REC_EXTEND>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public List<MED_OPERATION_SHIFT_RECORD> GetShiftRecordList(string patientID, int visitID, int operID, string shiftDuty)
        {
            return dapper.Set<MED_OPERATION_SHIFT_RECORD>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID && d.SHIFT_DUTY == shiftDuty).OrderByDescending(t => t.START_DATE_TIME).ToList();
        }

        public List<MED_OPERATION_SHIFT_RECORD> GetShiftRecordListByID(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_OPERATION_SHIFT_RECORD>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).OrderByDescending(t => t.START_DATE_TIME).ToList();
        }

        public int SaveShiftRecordList(List<MED_OPERATION_SHIFT_RECORD> item)
        {
            int result = dapper.Set<MED_OPERATION_SHIFT_RECORD>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public bool DelShiftRecord(MED_OPERATION_SHIFT_RECORD item)
        {
            bool result = dapper.Set<MED_OPERATION_SHIFT_RECORD>().Delete(item);

            dapper.SaveChanges();

            return result;
        }

        public MED_SAFETY_CHECKS GetSafetyCheckList(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_SAFETY_CHECKS>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).FirstOrDefault();
        }

        public List<MED_SAFETY_CHECKS> GetSafetyCheckLists(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_SAFETY_CHECKS>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID);
        }

        public int SaveSafetyCheckList(List<MED_SAFETY_CHECKS> item)
        {
            int result = dapper.Set<MED_SAFETY_CHECKS>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public int SaveSafetyCheck(MED_SAFETY_CHECKS item)
        {
            int result = dapper.Set<MED_SAFETY_CHECKS>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public MED_ANESTHESIA_PLAN GetAnesPlan(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_ANESTHESIA_PLAN>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).FirstOrDefault();
        }

        public MED_ANESTHESIA_PLAN_PMH GetAnesPlanPmh(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).FirstOrDefault();
        }

        public MED_ANESTHESIA_PLAN_EXAM GetAnesPlanExam(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_ANESTHESIA_PLAN_EXAM>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).FirstOrDefault();
        }

        public int DeleteOperNameList(List<MED_OPERATION_NAME> item)
        {
            int result = dapper.Set<MED_OPERATION_NAME>().Delete(item);

            dapper.SaveChanges();

            return result;
        }

        public List<MED_OPERATION_NAME> GetOperNameList(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_OPERATION_NAME>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID);
        }

        public int SaveOperNameList(List<MED_OPERATION_NAME> item)
        {
            int result = dapper.Set<MED_OPERATION_NAME>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public int SaveAnesPlan(MED_ANESTHESIA_PLAN item)
        {
            int result = dapper.Set<MED_ANESTHESIA_PLAN>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public int SaveAnesPlanPmh(MED_ANESTHESIA_PLAN_PMH item)
        {
            int result = dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public int SaveAnesPlanExam(MED_ANESTHESIA_PLAN_EXAM item)
        {
            int result = dapper.Set<MED_ANESTHESIA_PLAN_EXAM>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public MED_ANESTHESIA_INPUT_DATA GetAnesInputData(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_ANESTHESIA_INPUT_DATA>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).FirstOrDefault();
        }

        public int SaveAnesInputData(MED_ANESTHESIA_INPUT_DATA item)
        {
            int result = dapper.Set<MED_ANESTHESIA_INPUT_DATA>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public MED_ANESTHESIA_RECOVER GetAnesRecoverData(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_ANESTHESIA_RECOVER>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).FirstOrDefault();
        }

        public int SaveAnesRecoverData(MED_ANESTHESIA_RECOVER item)
        {
            int result = dapper.Set<MED_ANESTHESIA_RECOVER>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public List<MED_ANESTHESIA_INQUIRY> GetAnesInquiryList(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_ANESTHESIA_INQUIRY>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).OrderByDescending(t => t.INQUIRY_NO).ToList();
        }

        public int SaveAnesInquiryData(MED_ANESTHESIA_INQUIRY item)
        {
            int result = dapper.Set<MED_ANESTHESIA_INQUIRY>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public List<MED_CONSULTATION_REGISTRATION> GetConsultationList(string patientID, int visitID)
        {
            return dapper.Set<MED_CONSULTATION_REGISTRATION>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID).OrderByDescending(t => t.CONSULTATION_DATE_TIME).ToList();
        }

        public List<MED_CONSULTATION_REGISTRATION> GetConsultationListByID(string patientID)
        {
            return dapper.Set<MED_CONSULTATION_REGISTRATION>().Select(d => d.PATIENT_ID == patientID).OrderByDescending(t => t.CONSULTATION_DATE_TIME).ToList();
        }

        public int SaveConsultationData(MED_CONSULTATION_REGISTRATION item)
        {
            int result = dapper.Set<MED_CONSULTATION_REGISTRATION>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public MED_PATS_IN_HOSPITAL GetPatsInHospital(string inpNo)
        {
            return dapper.Set<MED_PATS_IN_HOSPITAL>().Select(d => d.INP_NO == inpNo).FirstOrDefault();
        }

        public MED_PATS_IN_HOSPITAL GetPatsInHospitalByID(string patientID, int visitID)
        {
            return dapper.Set<MED_PATS_IN_HOSPITAL>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID).FirstOrDefault();
        }

        public int SavePatsInHospital(MED_PATS_IN_HOSPITAL item)
        {
            int result = dapper.Set<MED_PATS_IN_HOSPITAL>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public MED_OPERATION_ANALGESIC_MASTER GetAnalgesicMaster(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_OPERATION_ANALGESIC_MASTER>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).FirstOrDefault();
        }

        public int SaveAnalgesicMaster(MED_OPERATION_ANALGESIC_MASTER item)
        {
            int result = dapper.Set<MED_OPERATION_ANALGESIC_MASTER>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public List<MED_OPER_ANALGESIC_TOTAL> GetAnalgesicTotalList(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_OPER_ANALGESIC_TOTAL>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID);
        }

        public int SaveAnalgesicTotalList(List<MED_OPER_ANALGESIC_TOTAL> item)
        {
            int result = dapper.Set<MED_OPER_ANALGESIC_TOTAL>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public List<MED_OPER_ANALGESIC_MEDICINE> GetAnalgesicMedicineList(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_OPER_ANALGESIC_MEDICINE>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).OrderByDescending(t => t.MEDICINE_NAME).ToList();
        }

        public int SaveAnalgesicMedicineList(List<MED_OPER_ANALGESIC_MEDICINE> item)
        {
            int result = dapper.Set<MED_OPER_ANALGESIC_MEDICINE>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public MED_OPER_RISK_ESTIMATE GetRickEstimate(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_OPER_RISK_ESTIMATE>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).FirstOrDefault();
        }

        public int SaveRickEstimate(MED_OPER_RISK_ESTIMATE item)
        {
            int result = dapper.Set<MED_OPER_RISK_ESTIMATE>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public List<MED_QIXIE_QINGDIAN> GetOperCheckList(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_QIXIE_QINGDIAN>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID);
        }

        public int SaveOperCheckList(List<MED_QIXIE_QINGDIAN> item)
        {
            int result = dapper.Set<MED_QIXIE_QINGDIAN>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public int SaveBloodGasMaster(List<MED_BLOOD_GAS_MASTER> item)
        {
            int result = dapper.Set<MED_BLOOD_GAS_MASTER>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public int SaveBloodGasDetail(List<MED_BLOOD_GAS_DETAIL> item)
        {
            int result = dapper.Set<MED_BLOOD_GAS_DETAIL>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public MED_PATIENT_MONITOR_CONFIG GetMonitorConfig(string patientID, int visitID, int operID, string eventNo)
        {
            return dapper.Set<MED_PATIENT_MONITOR_CONFIG>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID && d.EVENT_NO == eventNo).FirstOrDefault();
        }

        public int SaveMonitorConfig(MED_PATIENT_MONITOR_CONFIG item)
        {
            int result = dapper.Set<MED_PATIENT_MONITOR_CONFIG>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public MED_CONFIRMATION_PACU GetConfirmationPACU(string patientID, int visitID, int operID, int operStatusCode)
        {
            return dapper.Set<MED_CONFIRMATION_PACU>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID && d.OPER_STATUS_CODE == operStatusCode).FirstOrDefault();
        }

        public int SaveConfirmationPACU(MED_CONFIRMATION_PACU item)
        {
            int result = dapper.Set<MED_CONFIRMATION_PACU>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public List<MED_STEWARD_MARK> GetStewardMarkList(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_STEWARD_MARK>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID);
        }

        public int SaveStewardMarkList(List<MED_STEWARD_MARK> item)
        {
            int result = dapper.Set<MED_STEWARD_MARK>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public List<MED_ORDERS> GetOrders(string PATIENT_ID, int? VISIT_ID, DateTime? ExecuteBeginTime, DateTime? ExecuteEndTime)
        {
            return dapper.Set<MED_ORDERS>().Select(d => d.PATIENT_ID == PATIENT_ID && d.VISIT_ID == VISIT_ID && d.START_DATE_TIME >= ExecuteBeginTime && d.START_DATE_TIME <= ExecuteEndTime);
        }
    }
}
