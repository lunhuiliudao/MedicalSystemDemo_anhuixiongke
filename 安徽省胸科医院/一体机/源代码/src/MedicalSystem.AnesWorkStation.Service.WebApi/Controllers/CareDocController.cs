using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalSystem.DataServices.Domain;
using MedicalSystem.AnesWorkStation.Domain.Origins;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    public class CareDocController : BaseController
    {
        ICareDocService _careDocService;
        public CareDocController(ICareDocService careDocService)
        {
            _careDocService = careDocService;
        }

        /// <summary>
        /// 获取手术清点记录
        /// </summary>
        /// <param name="patID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_QIXIE_QINGDIAN>> GetOperCheckList(string patID, int visitID, int operID)
        {
            List<MED_QIXIE_QINGDIAN> qxqdData = _careDocService.GetOperCheckList(patID, visitID, operID);
            if (qxqdData == null)
            {
                return Failed<List<MED_QIXIE_QINGDIAN>>("获取手术清点信息错误。");
            }
            else
            {
                return Success(qxqdData);
            }
        }
        [HttpGet]
        public RequestResult<List<MED_SAFETY_CHECKS>> GetSafetyCheckData(string patID, int visitID, int operID)
        {
            List<MED_SAFETY_CHECKS> dataList = _careDocService.GetSafetyCheckData(patID, visitID, operID);
            if (dataList == null)
            {
                return Failed<List<MED_SAFETY_CHECKS>>("获取信息错误。");
            }
            else
            {
                return Success(dataList);
            }
        }
        [HttpGet]
        public RequestResult<List<MED_OPER_ANALGESIC_MEDICINE>> GetAnalgesicMedicineList(string patID, int visitID, int operID)
        {
            List<MED_OPER_ANALGESIC_MEDICINE> dataList = _careDocService.GetAnalgesicMedicineList(patID, visitID, operID);
            if (dataList == null)
            {
                return Failed<List<MED_OPER_ANALGESIC_MEDICINE>>("获取信息错误。");
            }
            else
            {
                return Success(dataList);
            }
        }
        [HttpGet]
        public RequestResult<List<MED_OPER_ANALGESIC_TOTAL>> GetAnalgesicTotalList(string patID, int visitID, int operID)
        {
            List<MED_OPER_ANALGESIC_TOTAL> dataList = _careDocService.GetAnalgesicTotalList(patID, visitID, operID);
            if (dataList == null)
            {
                return Failed<List<MED_OPER_ANALGESIC_TOTAL>>("获取信息错误。");
            }
            else
            {
                return Success(dataList);
            }
        }
        [HttpGet]
        public RequestResult<List<MED_OPERATION_NAME>> GetOperNameList(string patID, int visitID, int operID)
        {
            List<MED_OPERATION_NAME> dataList = _careDocService.GetOperNameList(patID, visitID, operID);
            if (dataList == null)
            {
                return Failed<List<MED_OPERATION_NAME>>("获取信息错误。");
            }
            else
            {
                return Success(dataList);
            }
        }

        [HttpPost]
        public RequestResult<bool> SaveOperNameList(List<MED_OPERATION_NAME> dataList)
        {
            return Success(_careDocService.SaveOperNameList(dataList));
        }

        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_INQUIRY>> GetAnesInquiry(string patID, int visitID, int operID)
        {
            List<MED_ANESTHESIA_INQUIRY> dataList = _careDocService.GetAnesInquiry(patID, visitID, operID);
            if (dataList == null)
            {
                return Failed<List<MED_ANESTHESIA_INQUIRY>>("获取信息错误。");
            }
            else
            {
                return Success(dataList);
            }
        }
        [HttpGet]
        public RequestResult<List<MED_OPERATION_EXTENDED>> GetOperExtended(string patID, int visitID, int operID)
        {
            List<MED_OPERATION_EXTENDED> dataList = _careDocService.GetOperExtended(patID, visitID, operID);
            if (dataList == null)
            {
                return Failed<List<MED_OPERATION_EXTENDED>>("获取信息错误。");
            }
            else
            {
                return Success(dataList);
            }
        }
        [HttpGet]
        public RequestResult<List<MED_POSTOPERATIVE_EXTENDED>> GetPostoperativeExtended(string patID, int visitID, int operID)
        {
            List<MED_POSTOPERATIVE_EXTENDED> dataList = _careDocService.GetPostoperativeExtended(patID, visitID, operID);
            if (dataList == null)
            {
                return Failed<List<MED_POSTOPERATIVE_EXTENDED>>("获取信息错误。");
            }
            else
            {
                return Success(dataList);
            }
        }
        [HttpGet]
        public RequestResult<List<MED_PREOPERATIVE_EXPANSION>> GetPreoperativeExpansion(string patID, int visitID, int operID)
        {
            List<MED_PREOPERATIVE_EXPANSION> dataList = _careDocService.GetPreoperativeExpansion(patID, visitID, operID);
            if (dataList == null)
            {
                return Failed<List<MED_PREOPERATIVE_EXPANSION>>("获取信息错误。");
            }
            else
            {
                return Success(dataList);
            }
        }
        [HttpGet]
        public RequestResult<List<MED_EMR_ARCHIVE_DETIAL>> GetEmrArchiveList(string patID, int visitID, string operID, string docName)
        {
            List<MED_EMR_ARCHIVE_DETIAL> dataList = _careDocService.GetEmrArchiveList(patID, visitID, operID, docName);
            if (dataList == null)
            {
                return Failed<List<MED_EMR_ARCHIVE_DETIAL>>("获取信息错误。");
            }
            else
            {
                return Success(dataList);
            }
        }
        [HttpGet]
        public RequestResult<MED_PAT_VISIT> GetPatVisit(string patientID, int visitID)
        {
            MED_PAT_VISIT data = _careDocService.GetPatVisit(patientID, visitID);
            if (data == null)
            {
                return Failed<MED_PAT_VISIT>("获取信息错误。");
            }
            else
            {
                return Success(data);
            }
        }
        [HttpGet]
        public RequestResult<MED_ANESTHESIA_PLAN_PMH> GetAnesthesiaPlanPMH(string patID, int visitID, int operID)
        {
            MED_ANESTHESIA_PLAN_PMH data = _careDocService.GetAnesthesiaPlanPMH(patID, visitID, operID);
            if (data == null)
            {
                return Failed<MED_ANESTHESIA_PLAN_PMH>("获取信息错误。");
            }
            else
            {
                return Success(data);
            }
        }
        [HttpGet]
        public RequestResult<MED_ANESTHESIA_PLAN_EXAM> GetAnesthesiaPlanEXAM(string patID, int visitID, int operID)
        {
            MED_ANESTHESIA_PLAN_EXAM data = _careDocService.GetAnesthesiaPlanEXAM(patID, visitID, operID);
            if (data == null)
            {
                return Failed<MED_ANESTHESIA_PLAN_EXAM>("获取信息错误。");
            }
            else
            {
                return Success(data);
            }
        }
        [HttpGet]
        public RequestResult<MED_ANESTHESIA_RECOVER> GetAnesRecoverData(string patID, int visitID, int operID)
        {
            MED_ANESTHESIA_RECOVER data = _careDocService.GetAnesRecoverData(patID, visitID, operID);
            if (data == null)
            {
                return Failed<MED_ANESTHESIA_RECOVER>("获取信息错误。");
            }
            else
            {
                return Success(data);
            }
        }
        [HttpGet]
        public RequestResult<MED_OPERATION_ANALGESIC_MASTER> GetAnalgesicMaster(string patID, int visitID, int operID)
        {
            MED_OPERATION_ANALGESIC_MASTER data = _careDocService.GetAnalgesicMaster(patID, visitID, operID);
            if (data == null)
            {
                return Failed<MED_OPERATION_ANALGESIC_MASTER>("获取信息错误。");
            }
            else
            {
                return Success(data);
            }
        }
        [HttpGet]
        public RequestResult<MED_OPER_RISK_ESTIMATE> GetRickEstimate(string patID, int visitID, int operID)
        {
            MED_OPER_RISK_ESTIMATE data = _careDocService.GetRickEstimate(patID, visitID, operID);
            if (data == null)
            {
                return Failed<MED_OPER_RISK_ESTIMATE>("获取信息错误。");
            }
            else
            {
                return Success(data);
            }
        }
        [HttpGet]
        public RequestResult<MED_ANESTHESIA_INPUT_DATA> GetAnesthestaInputData(string patID, int visitID, int operID)
        {
            MED_ANESTHESIA_INPUT_DATA data = _careDocService.GetAnesthestaInputData(patID, visitID, operID);
            if (data == null)
            {
                return Failed<MED_ANESTHESIA_INPUT_DATA>("获取信息错误。");
            }
            else
            {
                return Success(data);
            }
        }

        [HttpGet]
        public RequestResult<List<MED_CAMERA_PICINFO>> GetPicInfoList(string patID, int visitID, int operID)
        {
            List<MED_CAMERA_PICINFO> dataList = _careDocService.GetPicInfoList(patID, visitID, operID);
            if (dataList == null)
            {
                return Failed<List<MED_CAMERA_PICINFO>>("获取信息错误。");
            }
            else
            {
                return Success(dataList);
            }
        }

        [HttpPost]
        public RequestResult<bool> SaveCameraPic(MED_CAMERA_PICINFO data)
        {
            return Success(_careDocService.SaveCameraPic(data));
        }

        [HttpPost]
        public RequestResult<bool> SaveAnesInputData(MED_ANESTHESIA_INPUT_DATA data)
        {
            return Success(_careDocService.SaveAnesInputData(data));
        }
        [HttpPost]
        public RequestResult<bool> SaveAnalgesicMaster(MED_OPERATION_ANALGESIC_MASTER dataList)
        {
            return Success(_careDocService.SaveAnalgesicMaster(dataList));
        }
        [HttpPost]
        public RequestResult<bool> SaveAnalgesicMedicineList(List<MED_OPER_ANALGESIC_MEDICINE> dataList)
        {
            return Success(_careDocService.SaveAnalgesicMedicineList(dataList));
        }
        [HttpPost]
        public RequestResult<bool> SaveAnalgesicTotalList(List<MED_OPER_ANALGESIC_TOTAL> dataList)
        {
            return Success(_careDocService.SaveAnalgesicTotalList(dataList));
        }

        [HttpPost]
        public RequestResult<bool> SaveEmrArchiveList(List<MED_EMR_ARCHIVE_DETIAL> dataList)
        {
            return Success(_careDocService.SaveEmrArchiveList(dataList));
        }

        [HttpPost]
        public RequestResult<bool> SaveOperExtendedList(List<MED_OPERATION_EXTENDED> dataList)
        {
            return Success(_careDocService.SaveOperExtendedList(dataList));
        }
        [HttpPost]
        public RequestResult<bool> SaveAnesRecoverData(MED_ANESTHESIA_RECOVER data)
        {
            return Success(_careDocService.SaveAnesRecoverData(data));
        }
        [HttpPost]
        public RequestResult<bool> SaveAnesInquiryData(MED_ANESTHESIA_INQUIRY data)
        {
            return Success(_careDocService.SaveAnesInquiryData(data));
        }

        [HttpPost]
        public RequestResult<bool> SavePacuSocre(List<MED_PACU_SORCE> data)
        {
            return Success(_careDocService.SavePacuSocre(data));
        }

        [HttpPost]
        public RequestResult<bool> SaveOperCheckList(List<MED_QIXIE_QINGDIAN> dataList)
        {
            return Success(_careDocService.SaveOperCheckList(dataList));
        }
        [HttpPost]
        public RequestResult<bool> SaveSafetyCheck(MED_SAFETY_CHECKS data)
        {
            return Success(_careDocService.SaveSafetyCheck(data));
        }
        [HttpPost]
        public RequestResult<bool> SaveRickEstimate(MED_OPER_RISK_ESTIMATE data)
        {
            return Success(_careDocService.SaveRickEstimate(data));
        }

        [HttpPost]
        public RequestResult<List<MED_PACU_SORCE>> GetPACUStore(string patID, int visitID, int operID)
        {
            List<MED_PACU_SORCE> data = _careDocService.GetPACUStore(patID, visitID, operID);
            //if (data == null)
            //{
            //    return Failed<MED_PACU_SORCE>("获取信息错误。");
            //}
            //else
            //{
                return Success(data);
            //}
        }

        [HttpGet]
        public RequestResult<List<MED_CHUFANG_RECORD>> GetMedChuFangRecordList(string patID, int visitID, int operID, int chuFangClass)
        {
            List<MED_CHUFANG_RECORD> data = _careDocService.GetMedChuFangRecordList(patID, visitID, operID, chuFangClass);
            return Success(data);
        }

        [HttpPost]
        public RequestResult<bool> SaveMedChuFangRecordList(List<MED_CHUFANG_RECORD> list)
        {
            return Success(_careDocService.SaveMedChuFangRecordList(list));
        }

        [HttpPost]
        public RequestResult<bool> SaveMedChuFangRecord(MED_CHUFANG_RECORD chuFangRecord)
        {
            return Success(_careDocService.SaveMedChuFangRecord(chuFangRecord));
        }

        [HttpGet]
        public RequestResult<long> GetMedChuFangRecordMaxIndex()
        {
            return Success(_careDocService.GetMedChuFangRecordMaxIndex());
        }

        /// <summary>
        /// 保存文书数据源
        /// </summary>
        /// <param name="operMaster"></param>
        /// <param name="patMasterIndex"></param>
        /// <param name="patVisit"></param>
        /// <param name="patsInHospital"></param>
        /// <param name="anesPlan"></param>
        /// <param name="anesPlanExam"></param>
        /// <param name="anesPlanPmh"></param>
        /// <param name="operExtended"></param>
        /// <param name="postExtended"></param>
        /// <param name="preExpansion"></param>
        [HttpPost]
        public RequestResult<bool> SaveMedicalBasicDoc(dynamic item)
        {
            return Success(_careDocService.SaveMedicalBasicDoc(item));
        }
        [HttpGet]
        public RequestResult<MED_OPERATION_MASTER> GetOperationMaster(string patID, int visitID, int operID)
        {
            MED_OPERATION_MASTER data = _careDocService.GetOperationMaster(patID, visitID, operID);
            return Success(data);
        }

        [HttpGet]
        public RequestResult<MED_OPERATION_MASTER_EXT> GetOperationMasterExt(string patID, int visitID, int operID)
        {
            MED_OPERATION_MASTER_EXT data = _careDocService.GetOperationMasterExt(patID, visitID, operID);
            return Success(data);
        }

        [HttpGet]
        public RequestResult<MED_PAT_MASTER_INDEX> GetPatMasterIndex(string patientID)
        {
            MED_PAT_MASTER_INDEX data = _careDocService.GetPatMasterIndex(patientID);
            return Success(data);
        }

        [HttpGet]
        public RequestResult<MED_PATS_IN_HOSPITAL> GetPatsInHospital(string patientID, int visitID)
        {
            MED_PATS_IN_HOSPITAL data = _careDocService.GetPatsInHospital(patientID, visitID);
            return Success(data);
        }

        [HttpGet]
        public RequestResult<MED_ANESTHESIA_PLAN> GetAnesthesiaPlan(string patientID, int visitID, int operID)
        {
            MED_ANESTHESIA_PLAN data = _careDocService.GetAnesthesiaPlan(patientID, visitID, operID);
            return Success(data);
        }

        [HttpPost]
        public RequestResult<bool> SaveDocData(dynamic dyParams)
        {
            return Success(_careDocService.SaveDocData(dyParams));
        }

        [HttpPost]
        public RequestResult<bool> SaveDocDataPars(DocDataPars docData)
        {
            return Success(_careDocService.SaveDocDataPars(docData));
        }

        [HttpPost]
        public RequestResult<List<MED_BJCA_SIGN>> GetBjcaSignList(string patID, int visitID, int operID,
            string strDocName)
        {
            List<MED_BJCA_SIGN> result = _careDocService.GetBjcaSignList(patID, visitID, operID, strDocName);
            return Success(result);
        }

        [HttpPost]
        public RequestResult<bool> SaveBjcaSign(MED_BJCA_SIGN row)
        {
            return Success(_careDocService.SaveBjcaSign(row));
        }

        [HttpPost]
        public RequestResult<bool> UpdateBjcaSignList(List<MED_BJCA_SIGN> dataList)
        {
            return Success(_careDocService.UpdateBjcaSignList(dataList));
        }
    }
}
