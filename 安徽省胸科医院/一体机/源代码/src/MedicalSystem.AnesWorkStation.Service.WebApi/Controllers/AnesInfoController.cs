using MedicalSystem.AnesWorkStation.DataServices;
using System.Web.Http;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedicalSystem.DataServices.Domain;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    public class AnesInfoController : BaseController
    {
        IAnesInfoService _anesInfoService;
        public AnesInfoController(IAnesInfoService anesInfoService)
        {
            _anesInfoService = anesInfoService;
        }
        [HttpGet]
        public RequestResult<MED_OPERATION_MASTER> GetOperationMaster(string patientID, int visitID, int operID)
        {
            MED_OPERATION_MASTER operationMasterDataList = _anesInfoService.GetOperationMaster(patientID, visitID, operID);
            return Success(operationMasterDataList);
        }
        [HttpGet]
        public RequestResult<MED_OPERATION_MASTER_EXT> GetOperationMasterExt(string patientID, int visitID, int operID)
        {
            MED_OPERATION_MASTER_EXT operationMasterDataList = _anesInfoService.GetOperationMasterExt(patientID, visitID, operID);
            return Success(operationMasterDataList);
        }
        [HttpGet]
        public RequestResult<List<MED_OPERATION_MASTER>> GetOperationMaster(string patientID)
        {
            List<MED_OPERATION_MASTER> operationMasterDataList = _anesInfoService.GetOperationMaster(patientID);
            return Success(operationMasterDataList);
        }
        [HttpGet]
        public RequestResult<List<MED_PAT_MASTER_INDEX>> GetPatMasterIndex(string patientID)
        {
            List<MED_PAT_MASTER_INDEX> patMasterIndexList = _anesInfoService.GetPatMasterIndex(patientID);
            return Success(patMasterIndexList);
        }
        [HttpGet]
        public RequestResult<List<MED_PATS_IN_HOSPITAL>> GetPatsInHospitalList(string patientID, int visitID)
        {
            List<MED_PATS_IN_HOSPITAL> patsInHospitalList = _anesInfoService.GetPatsInHospitalList(patientID, visitID);
            return Success(patsInHospitalList);
        }
        [HttpGet]
        public RequestResult<List<MED_PATS_IN_HOSPITAL>> GetPatsInHospitalListByID(string PatientID)
        {
            List<MED_PATS_IN_HOSPITAL> patsInHospitalList = _anesInfoService.GetPatsInHospitalListByID(PatientID);
            return Success(patsInHospitalList);
        }

        [HttpGet]
        public RequestResult<List<MED_PATS_IN_HOSPITAL>> GetPatsInHospitalListByInpNo(string InpNo)
        {
            List<MED_PATS_IN_HOSPITAL> patsInHospitalList = _anesInfoService.GetPatsInHospitalListByInpNo(InpNo);
            return Success(patsInHospitalList);
        }

        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_PLAN>> GetAnesthesiaPlan(string patientID, int visitID, int operID)
        {
            List<MED_ANESTHESIA_PLAN> anesthesiaPlanList = _anesInfoService.GetAnesthesiaPlan(patientID, visitID, operID);

            if (anesthesiaPlanList == null || anesthesiaPlanList.Count == 0)
            {
                anesthesiaPlanList = new List<MED_ANESTHESIA_PLAN>();
                MED_ANESTHESIA_PLAN anesthesiaPlan = new MED_ANESTHESIA_PLAN();
                anesthesiaPlan.PATIENT_ID = patientID;
                anesthesiaPlan.VISIT_ID = visitID;
                anesthesiaPlan.OPER_ID = operID;
                anesthesiaPlan.ModelStatus = ModelStatus.Add;
                anesthesiaPlanList.Add(anesthesiaPlan);
            }

            return Success(anesthesiaPlanList);
        }

        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_PLAN>> GetAnesthesiaPlan(string patientID)
        {
            List<MED_ANESTHESIA_PLAN> anesthesiaPlanList = _anesInfoService.GetAnesthesiaPlan(patientID);

            if (anesthesiaPlanList == null || anesthesiaPlanList.Count == 0)
            {
                anesthesiaPlanList = new List<MED_ANESTHESIA_PLAN>();
                MED_ANESTHESIA_PLAN anesthesiaPlan = new MED_ANESTHESIA_PLAN();
                anesthesiaPlan.PATIENT_ID = patientID;
                anesthesiaPlan.VISIT_ID = 1;
                anesthesiaPlan.OPER_ID = 1;
                anesthesiaPlan.ModelStatus = ModelStatus.Add;
                anesthesiaPlanList.Add(anesthesiaPlan);
            }

            return Success(anesthesiaPlanList);
        }

        [HttpGet]
        public RequestResult<List<MED_PAT_MONITOR_DATA>> GetPatMonitorDataList(string patientID, int visitID, int operID)
        {
            List<MED_PAT_MONITOR_DATA> patMonitorList = _anesInfoService.GetPatMonitorDataList(patientID, visitID, operID);
            return Success(patMonitorList);
        }
        [HttpGet]
        public RequestResult<List<MED_PAT_MONITOR_DATA>> GetPatMonitorDataListByEvent(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_PAT_MONITOR_DATA> patMonitorList = _anesInfoService.GetPatMonitorDataListByEvent(patientID, visitID, operID, eventNo);
            return Success(patMonitorList);
        }
        [HttpGet]
        public RequestResult<List<MED_PAT_MONITOR_DATA_EXT>> GetPatMonitorExtList(string patientID, int visitID, int operID)
        {
            List<MED_PAT_MONITOR_DATA_EXT> patMonitorList = _anesInfoService.GetPatMonitorExtList(patientID, visitID, operID);
            return Success(patMonitorList);
        }
        [HttpGet]
        public RequestResult<List<MED_PAT_MONITOR_DATA_EXT>> GetPatMonitorExtListByEvent(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_PAT_MONITOR_DATA_EXT> patMonitorList = _anesInfoService.GetPatMonitorExtListByEvent(patientID, visitID, operID, eventNo);
            return Success(patMonitorList);
        }

        [HttpPost]
        public RequestResult<bool> SavePatMonitorExtList(List<MED_PAT_MONITOR_DATA_EXT> data)
        {
            return Success(_anesInfoService.SavePatMonitorExtList(data));
        }

        [HttpGet]
        public RequestResult<List<MED_COMM_VITAL_REC>> GetCommVitalRecList(string patientID, int visitID, int operID)
        {
            List<MED_COMM_VITAL_REC> vitalRecList = _anesInfoService.GetCommVitalRecList(patientID, visitID, operID);
            return Success(vitalRecList);
        }
        [HttpGet]
        public RequestResult<List<MED_COMM_VITAL_REC>> GetCommVitalRecListByEventNo(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_COMM_VITAL_REC> vitalRecList = _anesInfoService.GetCommVitalRecListByEventNo(patientID, visitID, operID, eventNo);
            return Success(vitalRecList);
        }
        [HttpGet]
        public RequestResult<List<MED_COMM_VITAL_REC_EXTEND>> GetCommVitalRecExtendList(string patientID, int visitID, int operID)
        {
            List<MED_COMM_VITAL_REC_EXTEND> vitalRecExtendList = _anesInfoService.GetCommVitalRecExtendList(patientID, visitID, operID);
            return Success(vitalRecExtendList);
        }
        [HttpGet]
        public RequestResult<List<MED_COMM_VITAL_REC_EXTEND>> GetCommVitalRecExtendListByEventNo(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_COMM_VITAL_REC_EXTEND> vitalRecExtendList = _anesInfoService.GetCommVitalRecExtendListByEventNo(patientID, visitID, operID, eventNo);
            return Success(vitalRecExtendList);
        }
        [HttpGet]
        public RequestResult<List<MED_BLOOD_GAS_MASTER>> GetBloodGasMasterList(string patientID, int visitID, int operID)
        {
            List<MED_BLOOD_GAS_MASTER> bloodGasMasterList = _anesInfoService.GetBloodGasMasterList(patientID, visitID, operID);
            return Success(bloodGasMasterList);
        }
        [HttpGet]
        public RequestResult<List<MED_BLOOD_GAS_MASTER>> GetBloodGasMasterAllList()
        {
            List<MED_BLOOD_GAS_MASTER> bloodAllList = _anesInfoService.GetBloodGasMasterAllList();
            return Success(bloodAllList);
        }
        [HttpGet]
        public RequestResult<List<MED_BLOOD_GAS_MASTER>> GetBloodGasMasterListByID(string detailID)
        {
            List<MED_BLOOD_GAS_MASTER> bloodGasMasterList = _anesInfoService.GetBloodGasMasterListByID(detailID);
            return Success(bloodGasMasterList);
        }
        [HttpGet]
        public RequestResult<List<MED_BLOOD_GAS_DETAIL>> GetBloodGasDetailList(string detailID)
        {
            List<MED_BLOOD_GAS_DETAIL> bloodGasDetalList = _anesInfoService.GetBloodGasDetailList(detailID);
            return Success(bloodGasDetalList);
        }
        /// <summary>
        /// 血气修改数据另存MED_BLOOD_GAS_DETAIL_EXT
        /// </summary>
        /// <param name="detailID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_BLOOD_GAS_DETAIL_EXT>> GetBloodGasDetailExtList(string detailID)
        {
            List<MED_BLOOD_GAS_DETAIL_EXT> bloodGasDetalList = _anesInfoService.GetBloodGasDetailExtList(detailID);
            return Success(bloodGasDetalList);
        }
        // <summary>
        /// 血气修改数据另存MED_BLOOD_GAS_DETAIL_SHOW
        /// </summary>
        /// <param name="detailID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_BLOOD_GAS_DETAIL_SHOW>> GetBloodGasDetailExtShowList(string detailID)
        {
            List<MED_BLOOD_GAS_DETAIL_SHOW> list = _anesInfoService.GetBloodGasDetailExtShowList(detailID);
            return Success(list);
        }

        [HttpGet]
        public RequestResult<List<MED_BLOOD_GAS_DETAIL_SHOW>> GetBloodGasDetailShowList(string detailID)
        {
            List<MED_BLOOD_GAS_DETAIL_SHOW> list = _anesInfoService.GetBloodGasDetailShowList(detailID);
            return Success(list);
        }

        [HttpGet]
        public RequestResult<MED_PATIENT_MONITOR_CONFIG> GetPatientMonitorConfig(string patientID, int visitID, int operID, string eventNo)
        {
            MED_PATIENT_MONITOR_CONFIG patMontirConfig = _anesInfoService.GetPatientMonitorConfig(patientID, visitID, operID, eventNo);
            return Success(patMontirConfig);
        }
        [HttpGet]
        public RequestResult<List<MED_VITAL_SIGN>> GetVitalSignData(string patientID, int visitID, int operID, string eventNo, bool isHistory)
        {
            List<MED_VITAL_SIGN> vitalSignList = _anesInfoService.GetVitalSignData(patientID, visitID, operID, eventNo, isHistory);
            return Success(vitalSignList);
        }
        [HttpGet]
        public RequestResult<List<MED_PAT_MONITOR_DATA>> GetPatMonitorList(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_PAT_MONITOR_DATA> patMonitorList = _anesInfoService.GetPatMonitorList(patientID, visitID, operID, eventNo);
            return Success(patMonitorList);
        }
        [HttpGet]
        public RequestResult<List<MED_COMM_VITAL_REC>> GetCommVitalRec(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_COMM_VITAL_REC> vitalRecList = _anesInfoService.GetCommVitalRec(patientID, visitID, operID, eventNo);
            return Success(vitalRecList);
        }
        [HttpGet]
        public RequestResult<List<MED_COMM_VITAL_REC_EXTEND>> GetCommVitalRecExtend(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_COMM_VITAL_REC_EXTEND> vitalRecExtendList = _anesInfoService.GetCommVitalRecExtend(patientID, visitID, operID, eventNo);
            return Success(vitalRecExtendList);
        }
        [HttpGet]
        public RequestResult<string[]> GetVitalSignTitles(string patientID, int visitID, int operID, string eventNo, string roomNo)
        {
            string[] vitalSignTitles = _anesInfoService.GetVitalSignTitles(patientID, visitID, operID, eventNo, roomNo);
            return Success(vitalSignTitles);
        }
        [HttpGet]
        public RequestResult<List<MED_VITAL_SIGN>> TransVitalSignData(List<MED_VITAL_SIGN> vitalSignDataTable, List<MED_PAT_MONITOR_DATA> patMonitorDataDataTables, List<MED_PAT_MONITOR_DATA_EXT> patMonitorExtList)
        {
            List<MED_VITAL_SIGN> vitalSignList = _anesInfoService.TransVitalSignData(vitalSignDataTable, patMonitorDataDataTables, patMonitorExtList);
            return Success(vitalSignList);
        }
        [HttpGet]
        public RequestResult<List<MED_VITAL_SIGN>> TransVitalSignData(List<MED_VITAL_SIGN> vitalSignDataTable, List<MED_COMM_VITAL_REC> patMonitorHistoryList, List<MED_COMM_VITAL_REC_EXTEND> commVitalRecListExtend, List<MED_PAT_MONITOR_DATA_EXT> patMonitorExtList)
        {
            List<MED_VITAL_SIGN> vitalSignList = _anesInfoService.TransVitalSignData(vitalSignDataTable, patMonitorHistoryList, commVitalRecListExtend, patMonitorExtList);
            return Success(vitalSignList);
        }
        [HttpGet]
        public RequestResult<Dictionary<string, string>> GetMonitorFunctionCodeDict()
        {
            Dictionary<string, string> functionCodeDict = _anesInfoService.GetMonitorFunctionCodeDict();
            return Success(functionCodeDict);
        }

        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_EVENT>> GetAnesthesiaEventList(string patientID, int visitID, int operID)
        {
            List<MED_ANESTHESIA_EVENT> anesEventList = _anesInfoService.GetAnesthesiaEventList(patientID, visitID, operID);
            return Success(anesEventList);
        }

        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_EVENT>> GetAnesthesiaEventByItemClass(string patientID, int visitID, int operID, string itemClass)
        {
            List<MED_ANESTHESIA_EVENT> anesEventList = _anesInfoService.GetAnesthesiaEventByItemClass(patientID, visitID, operID, itemClass);
            return Success(anesEventList);
        }

        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_EVENT>> GetAnesthesiaEventByItemName(string patientID, int visitID, int operID, string itemName)
        {
            List<MED_ANESTHESIA_EVENT> anesEventList = _anesInfoService.GetAnesthesiaEventByItemName(patientID, visitID, operID, itemName);
            return Success(anesEventList);
        }

        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_EVENT>> GetAnesthesiaEventByEventNo(string patientID, int visitID, int operID, string eventNo)
        {
            List<MED_ANESTHESIA_EVENT> anesEventList = _anesInfoService.GetAnesthesiaEventByEventNo(patientID, visitID, operID, eventNo);
            return Success(anesEventList);
        }

        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_EVENT>> GetAnesthesiaEventByEventNoItemClass(string patientID, int visitID, int operID, string eventNo, string itemClass)
        {
            List<MED_ANESTHESIA_EVENT> anesEventList = _anesInfoService.GetAnesthesiaEventByEventNoItemClass(patientID, visitID, operID, eventNo, itemClass);
            return Success(anesEventList);
        }

        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_EVENT>> GetAnesthesiaEventByEventNoItemName(string patientID, int visitID, int operID, string eventNo, string itemName)
        {
            List<MED_ANESTHESIA_EVENT> anesEventList = _anesInfoService.GetAnesthesiaEventByEventNoItemName(patientID, visitID, operID, eventNo, itemName);
            return Success(anesEventList);
        }

        [HttpPost]
        public RequestResult<bool> UpadteAnesthesiaEventRow(MED_ANESTHESIA_EVENT anesEventRow)
        {
            return Success(_anesInfoService.UpadteAnesthesiaEventRow(anesEventRow));
        }

        [HttpPost]
        public RequestResult<bool> UpadteOperationMasterRow(MED_OPERATION_MASTER operMasterRow)
        {
            return Success(_anesInfoService.UpadteOperationMasterRow(operMasterRow));
        }

        [HttpPost]
        public RequestResult<bool> UpadteAnesPlanRow(MED_ANESTHESIA_PLAN anesPlanRow)
        {
            return Success(_anesInfoService.UpadteAnesPlanRow(anesPlanRow));
        }

        [HttpPost]
        public RequestResult<bool> UpadteAnesthesiaEvent(List<MED_ANESTHESIA_EVENT> anesEvent)
        {
            return Success(_anesInfoService.UpadteAnesthesiaEvent(anesEvent));
        }

        [HttpPost]
        public RequestResult<bool> InsertAnesthesiaEventRow(MED_ANESTHESIA_EVENT anesEventRow)
        {
            return Success(_anesInfoService.InsertAnesthesiaEventRow(anesEventRow));
        }

        [HttpPost]
        public RequestResult<bool> InsertAnesthesiaEvent(List<MED_ANESTHESIA_EVENT> anesEvent)
        {
            return Success(_anesInfoService.InsertAnesthesiaEvent(anesEvent));
        }

        [HttpPost]
        public RequestResult<bool> InsertAnesthesiaPlanRow(MED_ANESTHESIA_PLAN anesthesiaPlanRow)
        {
            return Success(_anesInfoService.InsertAnesthesiaPlanRow(anesthesiaPlanRow));
        }

        [HttpPost]
        public RequestResult<bool> InsertOperationMasterRow(MED_OPERATION_MASTER operationMasterRow)
        {
            return Success(_anesInfoService.InsertOperationMasterRow(operationMasterRow));
        }

        [HttpPost]
        public RequestResult<bool> DeleteAnesthesiaEventRow(MED_ANESTHESIA_EVENT anesEventRow)
        {
            return Success(_anesInfoService.DeleteAnesthesiaEventRow(anesEventRow));
        }

        [HttpPost]
        public RequestResult<bool> DeleteAnesthesiaEvent(List<MED_ANESTHESIA_EVENT> anesEvent)
        {
            return Success(_anesInfoService.DeleteAnesthesiaEvent(anesEvent));
        }

        [HttpPost]
        public RequestResult<bool> DeletePatMonitorData(List<MED_PAT_MONITOR_DATA> monitorData)
        {
            return Success(_anesInfoService.DeletePatMonitorData(monitorData));
        }
        [HttpPost]
        public RequestResult<bool> DeletePatMonitorExtData(List<MED_PAT_MONITOR_DATA_EXT> monitorExtData)
        {
            return Success(_anesInfoService.DeletePatMonitorExtData(monitorExtData));
        }

        [HttpPost]
        public RequestResult<bool> SaveBloodGasMaster(List<MED_BLOOD_GAS_MASTER> dataList)
        {
            return Success(_anesInfoService.SaveBloodGasMaster(dataList));
        }
        [HttpPost]
        public RequestResult<bool> InsertBloodGasMaster(MED_BLOOD_GAS_MASTER newMaster)
        {
            return Success(_anesInfoService.InsertBloodGasMaster(newMaster));
        }
        [HttpPost]
        public RequestResult<bool> DeleteBloodGasMaster(MED_BLOOD_GAS_MASTER deleRow)
        {
            return Success(_anesInfoService.DeleteBloodGasMaster(deleRow));
        }
        [HttpPost]
        public RequestResult<bool> SaveBloodGasDetail(List<MED_BLOOD_GAS_DETAIL> dataList)
        {
            return Success(_anesInfoService.SaveBloodGasDetail(dataList));
        }
        [HttpGet]
        public RequestResult<bool> DeleteBloodGasDetail(string detailID)
        {
            return Success(_anesInfoService.DeleteBloodGasDetail(detailID));
        }
        [HttpPost]
        public RequestResult<bool> updatePatMonitorConfig(MED_PATIENT_MONITOR_CONFIG data)
        {
            return Success(_anesInfoService.updatePatMonitorConfig(data));
        }

        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_EVENT_TEMPLET>> GetAnesEventTemplet()
        {
            List<MED_ANESTHESIA_EVENT_TEMPLET> anesEventTempletList = _anesInfoService.GetAnesEventTemplet();
            return Success(anesEventTempletList);
        }
        [HttpPost]
        public RequestResult<bool> SaveAnesEventTemplet(List<MED_ANESTHESIA_EVENT_TEMPLET> dataList)
        {
            return Success(_anesInfoService.SaveAnesEventTemplet(dataList));
        }
        [HttpGet]
        public RequestResult<MED_OPERATION_SCHEDULE> GetOperSchedule(string patientID, int visitID, int operID)
        {
            MED_OPERATION_SCHEDULE operSchedule = _anesInfoService.GetOperSchedule(patientID, visitID, operID);
            return Success(operSchedule);
        }
        [HttpPost]
        public RequestResult<bool> updateOperSchedule(MED_OPERATION_SCHEDULE data)
        {
            return Success(_anesInfoService.updateOperSchedule(data));
        }

        [HttpPost]
        public RequestResult<bool> updatePatsInHospital(MED_PATS_IN_HOSPITAL data)
        {
            return Success(_anesInfoService.updatePatsInHospital(data));
        }

        [HttpGet]
        public RequestResult<List<MED_OPERATION_SHIFT_RECORD>> GetOperShiftRecord(string patientID, int visitID, int operID)
        {
            List<MED_OPERATION_SHIFT_RECORD> operShiftRecord = _anesInfoService.GetOperShiftRecord(patientID, visitID, operID);
            return Success(operShiftRecord);
        }

        [HttpPost]
        public RequestResult<bool> SaveOperShiftRecord(List<MED_OPERATION_SHIFT_RECORD> data)
        {
            return Success(_anesInfoService.SaveOperShiftRecord(data));
        }

        [HttpGet]
        public RequestResult<List<MED_POSTPDF_SHOW>> GetPostPDFShowList(string anesDoc)
        {
            List<MED_POSTPDF_SHOW> list = _anesInfoService.GetPostPDFShowList(anesDoc);
            return Success(list);
        }
    }
}