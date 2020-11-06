using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalSystem.DataServices.WebApi;
using Dapper.Data;
using System.Linq.Expressions;
using System.Data;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 麻醉信息接口
    /// </summary>
    public interface IAnesInfoService
    {
        MED_OPERATION_MASTER GetOperationMaster(string patientID, int visitID, int operID);
        MED_OPERATION_MASTER_EXT GetOperationMasterExt(string patientID, int visitID, int operID);
        List<MED_OPERATION_MASTER> GetOperationMaster(string patientID);
        List<MED_PAT_MASTER_INDEX> GetPatMasterIndex(string patientID);
        List<MED_PATS_IN_HOSPITAL> GetPatsInHospitalList(string patientID, int visitID);

        List<MED_PATS_IN_HOSPITAL> GetPatsInHospitalListByID(string PatientID);

        List<MED_PATS_IN_HOSPITAL> GetPatsInHospitalListByInpNo(string InpNo);

        List<MED_ANESTHESIA_PLAN> GetAnesthesiaPlan(string patientID, int visitID, int operID);
        List<MED_ANESTHESIA_PLAN> GetAnesthesiaPlan(string patientID);
        List<MED_PAT_MONITOR_DATA> GetPatMonitorDataList(string patientID, int visitID, int operID);
        List<MED_PAT_MONITOR_DATA> GetPatMonitorDataListByEvent(string patientID, int visitID, int operID, string eventNo);
        List<MED_PAT_MONITOR_DATA_EXT> GetPatMonitorExtList(string patientID, int visitID, int operID);
        List<MED_PAT_MONITOR_DATA_EXT> GetPatMonitorExtListByEvent(string patientID, int visitID, int operID, string eventNo);
        bool SavePatMonitorExtList(List<MED_PAT_MONITOR_DATA_EXT> data);
        List<MED_COMM_VITAL_REC> GetCommVitalRecList(string patientID, int visitID, int operID);
        List<MED_COMM_VITAL_REC> GetCommVitalRecListByEventNo(string patientID, int visitID, int operID, string eventNo);
        List<MED_COMM_VITAL_REC_EXTEND> GetCommVitalRecExtendList(string patientID, int visitID, int operID);
        List<MED_COMM_VITAL_REC_EXTEND> GetCommVitalRecExtendListByEventNo(string patientID, int visitID, int operID, string eventNo);
        List<MED_BLOOD_GAS_MASTER> GetBloodGasMasterList(string patientID, int visitID, int operID);
        List<MED_BLOOD_GAS_MASTER> GetBloodGasMasterAllList();
        List<MED_BLOOD_GAS_MASTER> GetBloodGasMasterListByID(string detailID);
        List<MED_BLOOD_GAS_DETAIL> GetBloodGasDetailList(string detailID);
        List<MED_BLOOD_GAS_DETAIL_SHOW> GetBloodGasDetailExtShowList(string detailID);
        List<MED_BLOOD_GAS_DETAIL_EXT> GetBloodGasDetailExtList(string detailID);
        List<MED_BLOOD_GAS_DETAIL_SHOW> GetBloodGasDetailShowList(string detailID);
        MED_PATIENT_MONITOR_CONFIG GetPatientMonitorConfig(string patientID, int visitID, int operID, string eventNo);
        List<MED_VITAL_SIGN> GetVitalSignData(string patientID, int visitID, int operID, string eventNo, bool isHistory);
        List<MED_PAT_MONITOR_DATA> GetPatMonitorList(string patientID, int visitID, int operID, string eventNo);
        List<MED_COMM_VITAL_REC> GetCommVitalRec(string patientID, int visitID, int operID, string eventNo);
        List<MED_COMM_VITAL_REC_EXTEND> GetCommVitalRecExtend(string patientID, int visitID, int operID, string eventNo);
        string[] GetVitalSignTitles(string patientID, int visitID, int operID, string eventNo, string roomNo);
        List<MED_VITAL_SIGN> TransVitalSignData(List<MED_VITAL_SIGN> vitalSignDataTable, List<MED_PAT_MONITOR_DATA> patMonitorDataDataTables, List<MED_PAT_MONITOR_DATA_EXT> patMonitorExtList);
        List<MED_VITAL_SIGN> TransVitalSignData(List<MED_VITAL_SIGN> vitalSignDataTable, List<MED_COMM_VITAL_REC> patMonitorHistoryList, List<MED_COMM_VITAL_REC_EXTEND> commVitalRecListExtend, List<MED_PAT_MONITOR_DATA_EXT> patMonitorExtList);
        Dictionary<string, string> GetMonitorFunctionCodeDict();

        List<MED_ANESTHESIA_EVENT> GetAnesthesiaEventList(string patientID, int visitID, int operID);
        List<MED_ANESTHESIA_EVENT> GetAnesthesiaEventByItemClass(string patientID, int visitID, int operID, string itemClass);
        List<MED_ANESTHESIA_EVENT> GetAnesthesiaEventByItemName(string patientID, int visitID, int operID, string itemName);
        List<MED_ANESTHESIA_EVENT> GetAnesthesiaEventByEventNo(string patientID, int visitID, int operID, string eventNo);
        List<MED_ANESTHESIA_EVENT> GetAnesthesiaEventByEventNoItemClass(string patientID, int visitID, int operID, string eventNo, string itemClass);
        List<MED_ANESTHESIA_EVENT> GetAnesthesiaEventByEventNoItemName(string patientID, int visitID, int operID, string eventNo, string itemName);
        List<MED_POSTPDF_SHOW> GetPostPDFShowList(string anesDoc);
        MED_OPERATION_SCHEDULE GetOperSchedule(string patientID, int visitID, int operID);
        bool UpadteAnesthesiaEventRow(MED_ANESTHESIA_EVENT anesEventRow);
        bool UpadteOperationMasterRow(MED_OPERATION_MASTER operMasterRow);
        bool UpadteAnesthesiaEvent(List<MED_ANESTHESIA_EVENT> anesEvent);
        bool UpadteAnesPlanRow(MED_ANESTHESIA_PLAN anesPlanRow);

        bool InsertAnesthesiaEventRow(MED_ANESTHESIA_EVENT anesEventRow);
        bool InsertAnesthesiaEvent(List<MED_ANESTHESIA_EVENT> anesEvent);
        bool InsertAnesthesiaPlanRow(MED_ANESTHESIA_PLAN anesthesiaPlanRow);
        bool InsertOperationMasterRow(MED_OPERATION_MASTER operationMasterRow);

        bool DeleteAnesthesiaEventRow(MED_ANESTHESIA_EVENT anesEventRow);
        bool DeleteAnesthesiaEvent(List<MED_ANESTHESIA_EVENT> anesEvent);

        bool DeletePatMonitorData(List<MED_PAT_MONITOR_DATA> monitorData);
        bool DeletePatMonitorExtData(List<MED_PAT_MONITOR_DATA_EXT> monitorExtData);

        bool SaveBloodGasMaster(List<MED_BLOOD_GAS_MASTER> dataList);
        bool InsertBloodGasMaster(MED_BLOOD_GAS_MASTER newMaster);
        bool DeleteBloodGasMaster(MED_BLOOD_GAS_MASTER deleRow);
        bool SaveBloodGasDetail(List<MED_BLOOD_GAS_DETAIL> dataList);
        bool DeleteBloodGasDetail(string detailID);
        bool updatePatMonitorConfig(MED_PATIENT_MONITOR_CONFIG data);
        bool updateOperSchedule(MED_OPERATION_SCHEDULE data);
        bool updatePatsInHospital(MED_PATS_IN_HOSPITAL data);
        List<MED_ANESTHESIA_EVENT_TEMPLET> GetAnesEventTemplet();
        bool SaveAnesEventTemplet(List<MED_ANESTHESIA_EVENT_TEMPLET> dataList);

        List<MED_OPERATION_SHIFT_RECORD> GetOperShiftRecord(string patientID, int visitID, int operID);
        bool SaveOperShiftRecord(List<MED_OPERATION_SHIFT_RECORD> dataList);
    }
    /// <summary>
    /// 麻醉信息
    /// </summary>
    public class AnesInfoService : BaseService<AnesInfoService>, IAnesInfoService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>

        IDictService _dictService;
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected AnesInfoService()
            : base() { }


        public AnesInfoService(IDapperContext context, IDictService dictService)
            : base(context)
        {
            _dictService = dictService;
        }

        /// <summary>
        /// 获取病人手术信息
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <param name="visitID">住院次数</param>
        /// <param name="operID">手术次数</param>
        /// <returns></returns>
        [HttpGet]
        public virtual MED_OPERATION_MASTER GetOperationMaster(string patientID, int visitID, int operID)
        {
            string sql = string.Format(@"
SELECT MOM.*,
       NVL(MDD.DEPT_NAME, MOM.DEPT_CODE) AS DEPT_NAME
  FROM MED_OPERATION_MASTER MOM
  LEFT JOIN MED_DEPT_DICT MDD ON MDD.DEPT_CODE = MOM.DEPT_CODE
 WHERE MOM.PATIENT_ID = '{0}'
   AND MOM.VISIT_ID = {1}
   AND MOM.OPER_ID = {2}
", patientID, visitID, operID);
            MED_OPERATION_MASTER operationMaster = dapper.Query<MED_OPERATION_MASTER>(sql, null).FirstOrDefault();

            return operationMaster;
        }

        /// <summary>
        /// 获取病人手术信息列表
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <param name="visitID">住院次数</param>
        /// <param name="operID">手术次数</param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_OPERATION_MASTER> GetOperationMaster(string patientID)
        {
            List<MED_OPERATION_MASTER> operationMasterDataList = dapper.Set<MED_OPERATION_MASTER>().Select(
                x => x.PATIENT_ID == patientID).ToList();
            return operationMasterDataList;
        }

        [HttpGet]
        public virtual MED_OPERATION_MASTER_EXT GetOperationMasterExt(string patientID, int visitID, int operID)
        {
            MED_OPERATION_MASTER_EXT operationMasterExt = dapper.Set<MED_OPERATION_MASTER_EXT>().Single(
                 x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID);
            return operationMasterExt;
        }

        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_PAT_MASTER_INDEX> GetPatMasterIndex(string patientID)
        {
            List<MED_PAT_MASTER_INDEX> patMasterIndexList = dapper.Set<MED_PAT_MASTER_INDEX>().Select(
                x => x.PATIENT_ID == patientID).ToList();
            return patMasterIndexList;
        }

        /// <summary>
        /// 获取病人住院信息
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_PATS_IN_HOSPITAL> GetPatsInHospitalList(string patientID, int visitID)
        {
            List<MED_PATS_IN_HOSPITAL> patsInHospitalList = dapper.Set<MED_PATS_IN_HOSPITAL>().Select(
                x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID).ToList();
            return patsInHospitalList;
        }
        [HttpGet]
        public virtual List<MED_PATS_IN_HOSPITAL> GetPatsInHospitalListByID(string PatientID)
        {
            List<MED_PATS_IN_HOSPITAL> patsInHospitalList = dapper.Set<MED_PATS_IN_HOSPITAL>().Select(
                 x => x.PATIENT_ID == PatientID).ToList();
            return patsInHospitalList;
        }

        [HttpGet]
        public virtual List<MED_PATS_IN_HOSPITAL> GetPatsInHospitalListByInpNo(string InpNo)
        {
            List<MED_PATS_IN_HOSPITAL> patsInHospitalList = dapper.Set<MED_PATS_IN_HOSPITAL>().Select(
                 x => x.INP_NO == InpNo).ToList();
            return patsInHospitalList;
        }


        /// <summary>
        /// 获取麻醉计划
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_ANESTHESIA_PLAN> GetAnesthesiaPlan(string patientID, int visitID, int operID)
        {
            List<MED_ANESTHESIA_PLAN> anesthesiaPlan = dapper.Set<MED_ANESTHESIA_PLAN>().Select(
                x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID).ToList();
            return anesthesiaPlan;
        }

        /// <summary>
        /// 通过患者ID获取麻醉计划
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_ANESTHESIA_PLAN> GetAnesthesiaPlan(string patientID)
        {
            List<MED_ANESTHESIA_PLAN> anesthesiaPlan = dapper.Set<MED_ANESTHESIA_PLAN>().Select(
                x => x.PATIENT_ID == patientID).ToList();
            return anesthesiaPlan;
        }

        /// <summary>
        /// 获取最新的病人体征
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <param name="visitID">住院次数</param>
        /// <param name="operID">手术次数</param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_PAT_MONITOR_DATA> GetPatMonitorDataList(string patientID, int visitID, int operID)
        {
            List<MED_PAT_MONITOR_DATA> monitorDataList = dapper.Set<MED_PAT_MONITOR_DATA>().Select(
                x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID).OrderBy(p => p.TIME_POINT).ToList();
            return monitorDataList;
        }
        /// <summary>
        /// 获取最新的病人体征
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <param name="visitID">住院次数</param>
        /// <param name="operID">手术次数</param>
        /// <param name="eventNo">手术类型</param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_PAT_MONITOR_DATA> GetPatMonitorDataListByEvent(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_PAT_MONITOR_DATA> monitorDataList = dapper.Set<MED_PAT_MONITOR_DATA>().Select(
                x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.DATA_TYPE == eventNo).OrderBy(p => p.TIME_POINT).ToList();
            return monitorDataList;
        }

        /// <summary>
        /// 获取体征扩展表
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <param name="visitID">住院次数</param>
        /// <param name="operID">手术次数</param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_PAT_MONITOR_DATA_EXT> GetPatMonitorExtList(string patientID, int visitID, int operID)
        {
            List<MED_PAT_MONITOR_DATA_EXT> monitorDataList = dapper.Set<MED_PAT_MONITOR_DATA_EXT>().Select(
                x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID).OrderBy(p => p.TIME_POINT).ToList();
            return monitorDataList;
        }
        /// <summary>
        /// 获取体征扩展表
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <param name="visitID">住院次数</param>
        /// <param name="operID">手术次数</param>
        /// <param name="eventNo">手术类型</param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_PAT_MONITOR_DATA_EXT> GetPatMonitorExtListByEvent(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_PAT_MONITOR_DATA_EXT> monitorDataList = dapper.Set<MED_PAT_MONITOR_DATA_EXT>().Select(
                x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.DATA_TYPE == eventNo).OrderBy(p => p.TIME_POINT).ToList();
            return monitorDataList;
        }

        /// <summary>
        /// 更新体征扩展表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual bool SavePatMonitorExtList(List<MED_PAT_MONITOR_DATA_EXT> data)
        {
            bool ret = false;
            try
            {
                ret = UpdateWholeList(data);
                dapper.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        /// <summary>
        /// 密集体征
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_COMM_VITAL_REC> GetCommVitalRecList(string patientID, int visitID, int operID)
        {
            List<MED_COMM_VITAL_REC> vitalRecList = dapper.Set<MED_COMM_VITAL_REC>().Select(
             x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID).OrderBy(p => p.TIME_POINT).ToList();
            return vitalRecList;
        }
        /// <summary>
        /// 密集体征
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_COMM_VITAL_REC> GetCommVitalRecListByEventNo(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_COMM_VITAL_REC> vitalRecList = dapper.Set<MED_COMM_VITAL_REC>().Select(
              x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.DATA_TYPE == eventNo).OrderBy(p => p.TIME_POINT).ToList();
            return vitalRecList;
        }
        /// <summary>
        /// 密集体征扩展
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_COMM_VITAL_REC_EXTEND> GetCommVitalRecExtendList(string patientID, int visitID, int operID)
        {
            List<MED_COMM_VITAL_REC_EXTEND> vitalRecList = dapper.Set<MED_COMM_VITAL_REC_EXTEND>().Select(
              x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID).OrderBy(p => p.TIME_POINT).ToList();
            return vitalRecList;
        }
        /// <summary>
        /// 密集提振扩展
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_COMM_VITAL_REC_EXTEND> GetCommVitalRecExtendListByEventNo(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_COMM_VITAL_REC_EXTEND> vitalRecList = dapper.Set<MED_COMM_VITAL_REC_EXTEND>().Select(
              x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.DATA_TYPE == eventNo).OrderBy(p => p.TIME_POINT).ToList();
            return vitalRecList;
        }

        /// <summary>
        /// 血气分析主表
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_BLOOD_GAS_MASTER> GetBloodGasMasterList(string patientID, int visitID, int operID)
        {
            List<MED_BLOOD_GAS_MASTER> bloodMsterList = dapper.Set<MED_BLOOD_GAS_MASTER>().Select(
              x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID).OrderBy(x => x.RECORD_DATE).ToList();
            return bloodMsterList;
        }
        /// <summary>
        /// 血气分析所有
        /// </summary> 
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_BLOOD_GAS_MASTER> GetBloodGasMasterAllList()
        {
            List<MED_BLOOD_GAS_MASTER> bloodAllList = dapper.Set<MED_BLOOD_GAS_MASTER>().Select();
            return bloodAllList;
        }
        /// <summary>
        /// 血气分析主表
        /// </summary>
        /// <param name="detailID">明细表</param> 
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_BLOOD_GAS_MASTER> GetBloodGasMasterListByID(string detailID)
        {
            List<MED_BLOOD_GAS_MASTER> bloodMasterList = dapper.Set<MED_BLOOD_GAS_MASTER>().Select(
             x => x.DETAIL_ID == detailID);
            return bloodMasterList;
        }
        /// <summary>
        /// 血气分析
        /// </summary>
        /// <param name="detailID"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_BLOOD_GAS_DETAIL> GetBloodGasDetailList(string detailID)
        {
            List<MED_BLOOD_GAS_DETAIL> bloodList = dapper.Set<MED_BLOOD_GAS_DETAIL>().Select(
             x => x.DETAIL_ID == detailID);
            return bloodList;
        }
        /// <summary>
        /// 血气分析修改数据另存的表
        /// </summary>
        /// <param name="detailID"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_BLOOD_GAS_DETAIL_EXT> GetBloodGasDetailExtList(string detailID)
        {
            List<MED_BLOOD_GAS_DETAIL_EXT> bloodList = dapper.Set<MED_BLOOD_GAS_DETAIL_EXT>().Select(
             x => x.DETAIL_ID == detailID);
            return bloodList;
        }

        /// <summary>
        /// 血气分析
        /// </summary>
        [HttpGet]
        public virtual List<MED_BLOOD_GAS_DETAIL_SHOW> GetBloodGasDetailShowList(string detailID)
        {
            string sql = string.Format(@"SELECT ROWNUM, M.*, A.BLG_NAME, A.BLG_SHOWID, A.BLG_UNIT, A.BLG_REFER_VALUE, A.BLG_STATUS,
                                                       A.BLG_INPUT_CODE, A.BLG_ATTR_CODE, A.BLG_ITEM_ID  
                                        FROM MED_BLOOD_GAS_DETAIL M
                                        LEFT JOIN MED_BLOOD_GAS_DICT A ON M.BLG_CODE=A.BLG_CODE
                                        WHERE DETAIL_ID='{0}' order by A.BLG_SHOWID ", detailID);
            List<MED_BLOOD_GAS_DETAIL_SHOW> bloodList = dapper.Query<MED_BLOOD_GAS_DETAIL_SHOW>(sql, null);
            return bloodList;
        }

        /// <summary>
        /// 血气分析修改数据另存表
        /// </summary>
        [HttpGet]
        public virtual List<MED_BLOOD_GAS_DETAIL_SHOW> GetBloodGasDetailExtShowList(string detailID)
        {
            string sql = string.Format(@"SELECT ROWNUM, M.*, A.BLG_NAME, A.BLG_SHOWID, A.BLG_UNIT, A.BLG_REFER_VALUE, A.BLG_STATUS,
                                                       A.BLG_INPUT_CODE, A.BLG_ATTR_CODE, A.BLG_ITEM_ID  
                                        FROM MED_BLOOD_GAS_DETAIL_EXT M
                                        LEFT JOIN MED_BLOOD_GAS_DICT A ON M.BLG_CODE=A.BLG_CODE
                                        WHERE DETAIL_ID='{0}' order by A.BLG_SHOWID ", detailID);
            List<MED_BLOOD_GAS_DETAIL_SHOW> bloodList = dapper.Query<MED_BLOOD_GAS_DETAIL_SHOW>(sql, null);
            return bloodList;
        }

        [HttpGet]
        public virtual MED_PATIENT_MONITOR_CONFIG GetPatientMonitorConfig(string patientID, int visitID, int operID, string eventNo)
        {
            MED_PATIENT_MONITOR_CONFIG patMonitorConfigList = dapper.Set<MED_PATIENT_MONITOR_CONFIG>().Single(
                x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.EVENT_NO == eventNo);
            return patMonitorConfigList;
        }

        /// <summary>
        /// 获取监测数据表
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID"></param>
        /// <param name="operID">手术ID</param>
        /// <returns>监测数据表</returns>
        /// DATA_MARK 0-删除；1新增OR修改（手工录入）
        [HttpGet]
        public virtual List<MED_VITAL_SIGN> GetVitalSignData(string patientID, int visitID, int operID, string eventNo, bool isHistory)
        {
            List<MED_VITAL_SIGN> vitalSignList = new List<MED_VITAL_SIGN>();
            List<MED_PAT_MONITOR_DATA> patMonitorDataList = null;
            List<MED_PAT_MONITOR_DATA_EXT> patMonitorExtList = GetPatMonitorExtList(patientID, visitID, operID);
            List<MED_COMM_VITAL_REC> commVitalRecList = null;
            List<MED_PAT_MONITOR_DATA_EXT> monitorExtDeleteList = null;
            if (isHistory)
            {
                commVitalRecList = GetCommVitalRec(patientID, visitID, operID, eventNo);
                List<MED_COMM_VITAL_REC_EXTEND> commVitalRecListExtend = GetCommVitalRecExtend(patientID, visitID, operID, eventNo);
                monitorExtDeleteList = patMonitorExtList.Where(x => x.DATA_MARK == 0 && x.DATA_TYPE == eventNo).ToList();
                TransVitalSignData(vitalSignList, commVitalRecList, commVitalRecListExtend, monitorExtDeleteList);
            }
            else
            {
                patMonitorDataList = GetPatMonitorList(patientID, visitID, operID, eventNo);
                monitorExtDeleteList = patMonitorExtList.Where(x => x.DATA_MARK == 0 && x.DATA_TYPE == eventNo).ToList();
                TransVitalSignData(vitalSignList, patMonitorDataList, monitorExtDeleteList);
            }
            if (patMonitorDataList == null) patMonitorDataList = new List<MED_PAT_MONITOR_DATA>();
            if (patMonitorExtList != null && patMonitorExtList.Count > 0)
            {
                List<MED_PAT_MONITOR_DATA_EXT> monitorExtAddList = patMonitorExtList.Where(x => x.DATA_MARK == 1 && x.DATA_TYPE == eventNo).ToList();
                if (monitorExtAddList != null)
                    monitorExtAddList.ForEach(extRow =>
                    {
                        MED_VITAL_SIGN nrow = vitalSignList.FirstOrDefault(x => x.TIME_POINT.Equals(extRow.TIME_POINT) && x.ITEM_CODE.Equals(extRow.ITEM_CODE));
                        if (nrow != null)
                        {
                            nrow.ITEM_VALUE = extRow.ITEM_VALUE;
                            nrow.Flag = "1";
                        }
                        else
                        {
                            nrow = new MED_VITAL_SIGN();
                            nrow.ITEM_NAME = extRow.ITEM_NAME;
                            nrow.ITEM_CODE = extRow.ITEM_CODE;
                            nrow.TIME_POINT = extRow.TIME_POINT;
                            nrow.ITEM_VALUE = extRow.ITEM_VALUE.Equals("/") ? "" : extRow.ITEM_VALUE;
                            nrow.Flag = "2";
                            vitalSignList.Add(nrow);
                        }
                    });
            }
            if (vitalSignList != null && vitalSignList.Count > 0)
            {
                vitalSignList = vitalSignList.OrderBy(x => x.TIME_POINT).ToList();
            }
            return vitalSignList;
        }
        [HttpGet]
        public virtual List<MED_PAT_MONITOR_DATA> GetPatMonitorList(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_PAT_MONITOR_DATA> monitorData = GetPatMonitorDataListByEvent(patientID, visitID, operID, eventNo);
            if (monitorData != null && monitorData.Count > 0)
            {
                foreach (MED_PAT_MONITOR_DATA row in monitorData)
                {
                    row.TIME_POINT = Convert.ToDateTime(row.TIME_POINT.ToString("yyyy-MM-dd HH:mm"));
                }
            }
            return monitorData;
        }
        [HttpGet]
        public virtual List<MED_COMM_VITAL_REC> GetCommVitalRec(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_COMM_VITAL_REC> commVitalData = GetCommVitalRecListByEventNo(patientID, visitID, operID, eventNo);
            //if (commVitalData != null && commVitalData.Count > 0)
            //{
            //    foreach (MED_COMM_VITAL_REC row in commVitalData)
            //    {
            //        row.TIME_POINT = Convert.ToDateTime(row.TIME_POINT.ToString("yyyy-MM-dd HH:mm"));
            //    }
            //}此处存在30秒数据 所以不能这么写
            return commVitalData;
        }
        [HttpGet]
        public virtual List<MED_COMM_VITAL_REC_EXTEND> GetCommVitalRecExtend(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_COMM_VITAL_REC_EXTEND> commVitalExtendData = GetCommVitalRecExtendListByEventNo(patientID, visitID, operID, eventNo);
            //if (commVitalExtendData != null && commVitalExtendData.Count > 0)
            //{
            //    foreach (MED_COMM_VITAL_REC_EXTEND row in commVitalExtendData)
            //    {
            //        row.TIME_POINT = Convert.ToDateTime(row.TIME_POINT.ToString("yyyy-MM-dd HH:mm"));
            //    }
            //}此处存在30秒数据 所以不能这么写
            return commVitalExtendData;
        }
        /// <summary>
        /// 取采集项目code和名称字典
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual string[] GetVitalSignTitles(string patientID, int visitID, int operID, string eventNo, string roomNo)
        {
            //string[] monitorValues = null;
            List<string> monitorValueList = new List<string>();
            Dictionary<string, string> monitorFunctionCodeDict = GetMonitorFunctionCodeDict();
            //现 麻醉、复苏 检测采集项目，只取数据表中第一行 作为依据 ,固定为 0 ，
            List<MED_PAT_MONITOR_DATA> patMonitorDateDataTable = GetPatMonitorDataListByEvent(patientID, visitID, operID, eventNo);
            if (patMonitorDateDataTable != null && patMonitorDateDataTable.Count > 0)
            {
                foreach (MED_PAT_MONITOR_DATA row in patMonitorDateDataTable)
                {
                    if (!string.IsNullOrEmpty(row.ITEM_VALUE) && !string.IsNullOrEmpty(row.ITEM_NAME) && !monitorValueList.Contains(row.ITEM_CODE))
                    {
                        monitorValueList.Add(row.ITEM_CODE);
                    }
                }
            }
            List<MED_PAT_MONITOR_DATA_EXT> patMonitorDataExtDataTable = GetPatMonitorExtList(patientID, visitID, operID);

            if (patMonitorDataExtDataTable != null && patMonitorDataExtDataTable.Count > 0)
            {
                foreach (MED_PAT_MONITOR_DATA_EXT row in patMonitorDataExtDataTable)
                {
                    if (!string.IsNullOrEmpty(row.ITEM_VALUE) && !string.IsNullOrEmpty(row.ITEM_NAME) && !monitorValueList.Contains(row.ITEM_CODE))
                    {
                        monitorValueList.Add(row.ITEM_CODE);
                    }
                }
            }
            List<MED_MONITOR_DICT> mointorDictDataTable = _dictService.GetMonitorDictListByBedNo(roomNo);
            if (mointorDictDataTable != null)
            {
                foreach (MED_MONITOR_DICT row in mointorDictDataTable)
                {
                    if (!string.IsNullOrEmpty(row.PATIENT_ID) && row.VISIT_ID.HasValue && row.OPER_ID.HasValue && row.PATIENT_ID.Equals(patientID)
                        && row.VISIT_ID.Equals(visitID) && row.OPER_ID.Equals(operID) && !string.IsNullOrEmpty(row.CURRENT_RECV_ITEMS))
                    {
                        string[] strs = row.CURRENT_RECV_ITEMS.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string str in strs)
                        {
                            if (!string.IsNullOrEmpty(str.Trim()) && !monitorValueList.Contains(str.Trim()))
                            {
                                monitorValueList.Add(str.Trim());
                            }
                        }
                    }
                }
            }
            // 当体征项为空时显示999配置的默认项
            if (monitorValueList.Count == 0)
            {
                //monitorValueList = new List<string>(new string[] { "40", "44", "65", "66", "71", "92", "188", "112", "148", "89", "90" });
                monitorValueList = this.GetCommonPatientMonitorConfigCodeList(eventNo);
            }
            else
            {
                // 当体征项不为空时，则和999项取并集
                List<string> commonList = this.GetCommonPatientMonitorConfigCodeList(eventNo);
                foreach (string item in commonList)
                {
                    if (!monitorValueList.Contains(item))
                    {
                        monitorValueList.Add(item);
                    }
                }
            }

            List<MED_MONITOR_FUNCTION_CODE> tmpList = new List<MED_MONITOR_FUNCTION_CODE>();
            List<MED_MONITOR_FUNCTION_CODE> listMonitorFunction = _dictService.GetMonitorFuctionCodeList();
            int emptyNum = 100;
            for (int i = 0; i < monitorValueList.Count; i++)
            {
                MED_MONITOR_FUNCTION_CODE item = listMonitorFunction.Find(x => x.ITEM_CODE == monitorValueList[i]);
                if (item == null)
                {
                    item = new MED_MONITOR_FUNCTION_CODE();
                    item.ITEM_ID = 10000 + emptyNum;
                    item.ITEM_NAME = monitorValueList[i];
                    item.ITEM_CODE = monitorValueList[i];
                }
                if (item != null && !item.PRINT_ITEM_NO.HasValue)
                {
                    item.PRINT_ITEM_NO = emptyNum;
                    emptyNum++;
                }
                tmpList.Add(item);
            }
            return tmpList.OrderBy(x => x.PRINT_ITEM_NO).Select(x => x.ITEM_CODE).ToArray();
            //return monitorValueList.ToArray();
        }

        /// <summary>
        /// 获取"999"中的体征编码列表
        /// </summary>
        private List<string> GetCommonPatientMonitorConfigCodeList(string eventNo)
        {
            List<string> result = new List<string>();
            try
            {
                MED_PATIENT_MONITOR_CONFIG commonConfig = this.GetPatientMonitorConfig("999", 0, 0, eventNo);
                if (commonConfig != null && !string.IsNullOrEmpty(commonConfig.CONTENT.ToString()))
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(commonConfig.CONTENT);
                    stream.Position = 0;
                    DataSet ds = new DataSet();
                    ds.ReadXml(stream);
                    if (ds.Tables.Count > 0)
                    {
                        string tableName = "UserVitalShowSet" + ((Convert.ToInt32(eventNo) < 0) ? "0" : eventNo);
                        DataTable dataTable = ds.Tables[tableName];
                        foreach (DataRow row in dataTable.Rows)
                        {
                            result.Add(row[0].ToString());
                        }
                    }
                    ds.Dispose();
                    stream.Close();
                    stream.Dispose();
                }
            }
            catch
            {
            }

            // 如果通用的999没有数据，则给出一份默认数据
            if (result.Count == 0)
            {
                result.AddRange(new string[] { "40", "44", "65", "66", "71", "92", "188", "112", "148", "89", "90" });
            }

            return result;
        }

        [HttpGet]
        public virtual List<MED_VITAL_SIGN> TransVitalSignData(List<MED_VITAL_SIGN> vitalSignDataTable, List<MED_PAT_MONITOR_DATA> patMonitorDataDataTables, List<MED_PAT_MONITOR_DATA_EXT> patMonitorExtList)
        {
            List<MED_VITAL_SIGN> vitalSignList = vitalSignDataTable;
            if (patMonitorDataDataTables != null && patMonitorDataDataTables.Count > 0)
            {
                patMonitorDataDataTables.ForEach(row =>
                {
                    List<MED_PAT_MONITOR_DATA_EXT> deleteList = patMonitorExtList.Where(x => x.TIME_POINT.Equals(row.TIME_POINT) && x.ITEM_CODE.Equals(row.ITEM_CODE)).ToList();
                    if (deleteList.Count == 0)
                    {
                        MED_VITAL_SIGN nrow = new MED_VITAL_SIGN();
                        nrow.ITEM_NAME = row.ITEM_NAME;
                        nrow.ITEM_CODE = row.ITEM_CODE;
                        nrow.TIME_POINT = row.TIME_POINT;
                        nrow.ITEM_VALUE = row.ITEM_VALUE;
                        vitalSignList.Add(nrow);
                    }
                });
            }
            return vitalSignList;
        }
        [HttpGet]
        public virtual List<MED_VITAL_SIGN> TransVitalSignData(List<MED_VITAL_SIGN> vitalSignDataTable, List<MED_COMM_VITAL_REC> patMonitorHistoryList, List<MED_COMM_VITAL_REC_EXTEND> commVitalRecListExtend, List<MED_PAT_MONITOR_DATA_EXT> patMonitorExtList)
        {
            List<MED_VITAL_SIGN> vitalSignList = vitalSignDataTable;
            if (patMonitorHistoryList != null && patMonitorHistoryList.Count > 0)
            {
                patMonitorHistoryList.ForEach(row =>
                {
                    row.ToVitalSignList().ForEach(item =>
                    {
                        bool exist = patMonitorExtList.Exists(x => x.TIME_POINT.Equals(item.TIME_POINT) && x.ITEM_CODE.Equals(item.ITEM_CODE));
                        if (!exist)
                        {
                            vitalSignList.Add(item);
                        }
                    });
                });
            }
            if (commVitalRecListExtend != null && commVitalRecListExtend.Count > 0)
            {
                commVitalRecListExtend.ForEach(row =>
                {
                    bool exist = patMonitorExtList.Exists(x => x.TIME_POINT.Equals(row.TIME_POINT) && x.ITEM_CODE.Equals(row.ITEM_CODE));
                    if (!exist)
                    {
                        MED_VITAL_SIGN nrow = new MED_VITAL_SIGN();
                        nrow.ITEM_NAME = row.VITAL_SIGNS;
                        nrow.ITEM_CODE = row.ITEM_CODE;
                        nrow.TIME_POINT = row.TIME_POINT;
                        nrow.ITEM_VALUE = row.VITAL_SIGNS_VALUES;
                        vitalSignList.Add(nrow);
                    }
                });
            }
            return vitalSignList;
        }
        /// <summary>
        /// 所有采集项目字典
        /// </summary>
        [HttpGet]
        public virtual Dictionary<string, string> GetMonitorFunctionCodeDict()
        {
            Dictionary<string, string> monitorFunctionCodeDict = new Dictionary<string, string>();
            List<MED_MONITOR_FUNCTION_CODE> monitorFunctionCodeDataTable = _dictService.GetMonitorFuctionCodeList();
            if (monitorFunctionCodeDataTable != null && monitorFunctionCodeDataTable.Count > 0)
            {
                monitorFunctionCodeDataTable.ForEach(codeRow =>
                {
                    if (!monitorFunctionCodeDict.ContainsKey(codeRow.ITEM_CODE))
                    {
                        if (!string.IsNullOrEmpty(codeRow.ITEM_NAME))
                            monitorFunctionCodeDict.Add(codeRow.ITEM_CODE, codeRow.ITEM_NAME);
                    }
                });

            }
            if (!monitorFunctionCodeDict.ContainsKey("ECG"))
            {
                monitorFunctionCodeDict.Add("ECG", "ECG");
            }
            return monitorFunctionCodeDict;
        }

        [HttpGet]
        public virtual List<MED_ANESTHESIA_EVENT> GetAnesthesiaEventList(string patientID, int visitID, int operID)
        {
            List<MED_ANESTHESIA_EVENT> anesEventList = dapper.Set<MED_ANESTHESIA_EVENT>().Select(
               x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID).OrderBy(p => p.ITEM_NO).ToList();
            return anesEventList;
        }

        [HttpGet]
        public virtual List<MED_ANESTHESIA_EVENT> GetAnesthesiaEventByItemClass(string patientID, int visitID, int operID, string itemClass)
        {
            List<MED_ANESTHESIA_EVENT> anesEventList = dapper.Set<MED_ANESTHESIA_EVENT>().Select(
               x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.EVENT_CLASS_CODE == itemClass).OrderBy(p => p.ITEM_NO).ToList();
            return anesEventList;
        }

        [HttpGet]
        public virtual List<MED_ANESTHESIA_EVENT> GetAnesthesiaEventByItemName(string patientID, int visitID, int operID, string itemName)
        {
            List<MED_ANESTHESIA_EVENT> anesEventList = dapper.Set<MED_ANESTHESIA_EVENT>().Select(
               x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.EVENT_ITEM_NAME.Contains(itemName)).OrderBy(p => p.ITEM_NO).ToList();
            return anesEventList;
        }

        /// <summary>
        /// 根据用户信息和eventNO 获取麻醉事件表数据
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_ANESTHESIA_EVENT> GetAnesthesiaEventByEventNo(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_ANESTHESIA_EVENT> anesEventList = dapper.Set<MED_ANESTHESIA_EVENT>().Select(
               x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.EVENT_NO == eventNo).OrderBy(p => p.ITEM_NO).ToList();

            return anesEventList;
        }

        /// <summary>
        /// 根据ItemClass获取麻醉事件表数据
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <param name="itemClass"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_ANESTHESIA_EVENT> GetAnesthesiaEventByEventNoItemClass(string patientID, int visitID, int operID, string eventNo, string itemClass)
        {
            List<MED_ANESTHESIA_EVENT> anesEventList = dapper.Set<MED_ANESTHESIA_EVENT>().Select(
               x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.EVENT_NO == eventNo && x.EVENT_CLASS_CODE == itemClass).OrderBy(p => p.ITEM_NO).ToList();
            return anesEventList;
        }

        /// <summary>
        /// 根据ItemName获取麻醉事件表数据
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <param name="eventNo"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_ANESTHESIA_EVENT> GetAnesthesiaEventByEventNoItemName(string patientID, int visitID, int operID, string eventNo, string itemName)
        {
            List<MED_ANESTHESIA_EVENT> anesEventList = dapper.Set<MED_ANESTHESIA_EVENT>().Select(
               x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID && x.EVENT_NO == eventNo && x.EVENT_ITEM_NAME.Contains(itemName)).OrderBy(p => p.ITEM_NO).ToList();
            return anesEventList;
        }

        /// <summary>
        /// 更新麻醉事件表中某一行
        /// </summary>
        /// <param name="anesEventRow"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual bool UpadteAnesthesiaEventRow(MED_ANESTHESIA_EVENT anesEventRow)
        {
            bool flag = dapper.Set<MED_ANESTHESIA_EVENT>().Save(anesEventRow);
            dapper.SaveChanges();

            return flag;
        }

        /// <summary>
        /// 更新主表
        /// </summary>
        /// <param name="operMasterRow"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual bool UpadteOperationMasterRow(MED_OPERATION_MASTER operMasterRow)
        {
            bool flag = dapper.Set<MED_OPERATION_MASTER>().Save(operMasterRow);
            dapper.SaveChanges();

            return flag;
        }

        /// <summary>
        /// 更新麻醉计划表
        /// </summary>
        /// <param name="anesPlanRow"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual bool UpadteAnesPlanRow(MED_ANESTHESIA_PLAN anesPlanRow)
        {
            bool flag = dapper.Set<MED_ANESTHESIA_PLAN>().Save(anesPlanRow);
            dapper.SaveChanges();

            return flag;
        }


        /// <summary>
        /// 更新麻醉事件表
        /// </summary>
        /// <param name="anesEvent"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual bool UpadteAnesthesiaEvent(List<MED_ANESTHESIA_EVENT> anesEvent)
        {
            bool flag = UpdateWholeList(anesEvent);
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 麻醉事件表中插入一行
        /// </summary>
        /// <param name="anesEventRow"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual bool InsertAnesthesiaEventRow(MED_ANESTHESIA_EVENT anesEventRow)
        {
            bool flag = dapper.Set<MED_ANESTHESIA_EVENT>().Insert(anesEventRow);
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 麻醉事件表整表插入
        /// </summary>
        /// <param name="anesEvent"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual bool InsertAnesthesiaEvent(List<MED_ANESTHESIA_EVENT> anesEvent)
        {
            int i = dapper.Set<MED_ANESTHESIA_EVENT>().Insert(anesEvent);
            dapper.SaveChanges();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除麻醉事件表中的某一条数据
        /// </summary>
        /// <param name="anesEventRow"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual bool DeleteAnesthesiaEventRow(MED_ANESTHESIA_EVENT anesEventRow)
        {
            bool flag = dapper.Set<MED_ANESTHESIA_EVENT>().Delete(anesEventRow);
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 删除麻醉事件表的所有事件
        /// </summary>
        /// <param name="anesEvent"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual bool DeleteAnesthesiaEvent(List<MED_ANESTHESIA_EVENT> anesEvent)
        {
            int i = dapper.Set<MED_ANESTHESIA_EVENT>().Delete(anesEvent);
            dapper.SaveChanges();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除麻醉事件表的所有事件
        /// </summary>
        /// <param name="anesEvent"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual bool DeletePatMonitorData(List<MED_PAT_MONITOR_DATA> monitorData)
        {
            int i = dapper.Set<MED_PAT_MONITOR_DATA>().Delete(monitorData);
            dapper.SaveChanges();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除麻醉事件表的所有事件
        /// </summary>
        /// <param name="anesEvent"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual bool DeletePatMonitorExtData(List<MED_PAT_MONITOR_DATA_EXT> monitorExtData)
        {
            int i = dapper.Set<MED_PAT_MONITOR_DATA_EXT>().Delete(monitorExtData);
            dapper.SaveChanges();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public virtual bool SaveBloodGasMaster(List<MED_BLOOD_GAS_MASTER> dataList)
        {
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }
        [HttpPost]
        public virtual bool InsertBloodGasMaster(MED_BLOOD_GAS_MASTER newMaster)
        {
            bool flag = dapper.Set<MED_BLOOD_GAS_MASTER>().Insert(newMaster);
            dapper.SaveChanges();
            return flag;
        }

        [HttpPost]
        public virtual bool DeleteBloodGasMaster(MED_BLOOD_GAS_MASTER deleRow)
        {
            bool flag = dapper.Set<MED_BLOOD_GAS_MASTER>().Delete(deleRow);
            dapper.SaveChanges();
            return flag;
        }

        [HttpPost]
        public virtual bool SaveBloodGasDetail(List<MED_BLOOD_GAS_DETAIL> dataList)
        {
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }
        [HttpGet]
        public virtual bool DeleteBloodGasDetail(string detailID)
        {
            string strDelSql = string.Format("DELETE MED_BLOOD_GAS_DETAIL WHERE DETAIL_ID='{0}'", detailID);
            int result = dapper.Execute(strDelSql);
            dapper.SaveChanges();
            return result > 0;
        }
        [HttpPost]
        public virtual bool updatePatMonitorConfig(MED_PATIENT_MONITOR_CONFIG data)
        {
            bool flag = dapper.Set<MED_PATIENT_MONITOR_CONFIG>().Save(data);
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 手术记录主表中插入一行
        /// </summary>
        /// <param name="operationMasterRow"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual bool InsertOperationMasterRow(MED_OPERATION_MASTER operationMasterRow)
        {
            bool flag = dapper.Set<MED_OPERATION_MASTER>().Insert(operationMasterRow);
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 手术计划表中插入一行
        /// </summary>
        /// <param name="anesthesiaPlanRow"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual bool InsertAnesthesiaPlanRow(MED_ANESTHESIA_PLAN anesthesiaPlanRow)
        {
            bool flag = dapper.Set<MED_ANESTHESIA_PLAN>().Insert(anesthesiaPlanRow);
            dapper.SaveChanges();
            return flag;
        }

        [HttpGet]
        public virtual List<MED_ANESTHESIA_EVENT_TEMPLET> GetAnesEventTemplet()
        {
            List<MED_ANESTHESIA_EVENT_TEMPLET> anesEventTempletList = dapper.Set<MED_ANESTHESIA_EVENT_TEMPLET>().Select();
            return anesEventTempletList;
        }

        [HttpPost]
        public virtual bool SaveAnesEventTemplet(List<MED_ANESTHESIA_EVENT_TEMPLET> dataList)
        {
            int num = 0;
            foreach (var item in dataList)
            {
                switch (item.ModelStatus)
                {
                    case ModelStatus.Default:                  
                    case ModelStatus.Modeified:
                        Expression<Func<MED_ANESTHESIA_EVENT_TEMPLET, bool>> where = p => p.TEMPLET_NAME == item.TEMPLET_NAME && p.TEMPLET_CLASS == item.TEMPLET_CLASS && p.CREATE_BY == item.CREATE_BY;
                        num += dapper.Set<MED_ANESTHESIA_EVENT_TEMPLET>().Save(item, where) ? 1 : 0;
                        break;
                    case ModelStatus.Add:
                        num += dapper.Set<MED_ANESTHESIA_EVENT_TEMPLET>().Insert(item) ? 1 : 0;
                        break;
                    case ModelStatus.Deleted:
                        // 没有设置主键，只能这么删除
                        num += dapper.Set<MED_ANESTHESIA_EVENT_TEMPLET>().Delete(d => d.ANESTHESIA_METHOD == item.ANESTHESIA_METHOD && d.TEMPLET_NAME == item.TEMPLET_NAME
                    && d.CREATE_BY == item.CREATE_BY && d.EVENT_ITEM_NO == item.EVENT_ITEM_NO && d.TEMPLET_CLASS == item.TEMPLET_CLASS);
                        break;
                    default:
                        break;
                }
            }
            dapper.SaveChanges();
            return dataList.Count() == num;
        }
        [HttpGet]
        public virtual MED_OPERATION_SCHEDULE GetOperSchedule(string patientID, int visitID, int operID)
        {
            MED_OPERATION_SCHEDULE operationMaster = dapper.Set<MED_OPERATION_SCHEDULE>().Single(
                 x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID);
            return operationMaster;
        }
        [HttpPost]
        public virtual bool updateOperSchedule(MED_OPERATION_SCHEDULE data)
        {
            bool flag = dapper.Set<MED_OPERATION_SCHEDULE>().Save(data);
            dapper.SaveChanges();
            return flag;
        }

        [HttpPost]
        public virtual bool updatePatsInHospital(MED_PATS_IN_HOSPITAL data)
        {

            bool flag = false;
            if (data.ModelStatus == ModelStatus.Add)
            {
                flag = dapper.Set<MED_PATS_IN_HOSPITAL>().Insert(data);
            }
            else
            {
                flag = dapper.Set<MED_PATS_IN_HOSPITAL>().Save(data);
            }
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 获取交班记录
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_OPERATION_SHIFT_RECORD> GetOperShiftRecord(string patientID, int visitID, int operID)
        {
            //List<MED_OPERATION_SHIFT_RECORD> operShiftRecord = dapper.Set<MED_OPERATION_SHIFT_RECORD>().Select(
            //   x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID).ToList();

            string sql = string.Format(@"select a.*,NVL(b.user_name, a.person) AS PERSON_NAME,
nvl(c.user_name,a.shift_person) as SHIFT_PERSON_NAME
  from MED_OPERATION_SHIFT_RECORD a
  left join med_his_users b
    on a.person = b.user_job_id
  left join med_his_users c
    on a.shift_person = c.user_job_id
WHERE a.PATIENT_ID = '{0}'
   AND a.VISIT_ID = {1}
   AND a.OPER_ID = {2}", patientID, visitID, operID);
            List<MED_OPERATION_SHIFT_RECORD> operShiftRecord = dapper.Query<MED_OPERATION_SHIFT_RECORD>(sql, null);


            return operShiftRecord;
        }

        [HttpPost]
        public virtual bool SaveOperShiftRecord(List<MED_OPERATION_SHIFT_RECORD> dataList)
        {
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 获取文书上传信息列表
        /// </summary>
        [HttpGet]
        public virtual List<MED_POSTPDF_SHOW> GetPostPDFShowList(string anesDoc)
        {
            DateTime now = DateTime.Now;
            DateTime start = new DateTime(now.AddDays(-3.0).Year, now.AddDays(-3.0).Month, now.AddDays(-3.0).Day);
            DateTime end = new DateTime(now.Year, now.Month, now.Day);
            //DateTime start = new DateTime(2018, 7, 15);
            //DateTime end = new DateTime(2018, 7, 18);
            string sql = string.Format(@"SELECT ROWNUM, T.*
                                        FROM
                                        ( SELECT M.PATIENT_ID, M.VISIT_ID, M.OPER_ID, B.NAME, 
                                        M.ANES_DOCTOR, M.IN_DATE_TIME, M.OPER_STATUS_CODE, A.EXIST_DOCNAMES, 
                                        NULL AS NO_EXIST_DOCNAMES
                                        FROM MED_OPERATION_MASTER M 
                                        LEFT JOIN (SELECT PATIENT_ID, VISIT_ID, ARCHIVE_KEY, 
                                                    WM_CONCAT(MR_SUB_CLASS) AS EXIST_DOCNAMES
                                                    FROM MED_EMR_ARCHIVE_DETIAL 
                                                    GROUP BY PATIENT_ID, VISIT_ID, ARCHIVE_KEY) A 
                                                ON M.PATIENT_ID=A.PATIENT_ID AND M.VISIT_ID=A.VISIT_ID 
                                                    AND M.OPER_ID=A.ARCHIVE_KEY
                                        LEFT JOIN MED_PAT_MASTER_INDEX B ON M.PATIENT_ID=B.PATIENT_ID
                                        WHERE M.OPER_STATUS_CODE >= 35 AND 
                                                M.IN_DATE_TIME < TO_DATE('{0}', 'YYYY-MM-DD HH24:MI:SS') AND
                                                M.ANES_DOCTOR='{1}'
                                        ORDER BY IN_DATE_TIME
                                        ) T",
                                        end.ToString("yyyy-MM-dd HH:mm:ss"),
                                        anesDoc);

            List<MED_POSTPDF_SHOW> result = dapper.Query<MED_POSTPDF_SHOW>(sql, null);
            return result;
        }
    }
}
