using Dapper.Data;
using MedicalSystem.DataServices.WebApi;
using MedicalSystem.AnesWorkStation.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using System.Collections;
using MedicalSystem.Services;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface ICareDocService
    {
        List<MED_QIXIE_QINGDIAN> GetOperCheckList(string patID, int visitID, int operID);
        List<MED_SAFETY_CHECKS> GetSafetyCheckData(string patID, int visitID, int operID);
        List<MED_OPER_ANALGESIC_MEDICINE> GetAnalgesicMedicineList(string patID, int visitID, int operID);
        List<MED_OPER_ANALGESIC_TOTAL> GetAnalgesicTotalList(string patID, int visitID, int operID);
        List<MED_OPERATION_NAME> GetOperNameList(string patID, int visitID, int operID);
        bool SaveOperNameList(List<MED_OPERATION_NAME> dataList);
        List<MED_ANESTHESIA_INQUIRY> GetAnesInquiry(string patID, int visitID, int operID);
        List<MED_OPERATION_EXTENDED> GetOperExtended(string patID, int visitID, int operID);
        List<MED_POSTOPERATIVE_EXTENDED> GetPostoperativeExtended(string patID, int visitID, int operID);
        List<MED_PREOPERATIVE_EXPANSION> GetPreoperativeExpansion(string patID, int visitID, int operID);

        List<MED_EMR_ARCHIVE_DETIAL> GetEmrArchiveList(string patID, int visitID, string operID, string docName);

        MED_PAT_VISIT GetPatVisit(string patientID, int visitID);
        MED_ANESTHESIA_PLAN_PMH GetAnesthesiaPlanPMH(string patID, int visitID, int operID);
        MED_ANESTHESIA_PLAN_EXAM GetAnesthesiaPlanEXAM(string patID, int visitID, int operID);
        MED_ANESTHESIA_RECOVER GetAnesRecoverData(string patID, int visitID, int operID);
        MED_OPERATION_ANALGESIC_MASTER GetAnalgesicMaster(string patID, int visitID, int operID);
        MED_OPER_RISK_ESTIMATE GetRickEstimate(string patID, int visitID, int operID);
        MED_ANESTHESIA_INPUT_DATA GetAnesthestaInputData(string patID, int visitID, int operID);
        List<MED_PACU_SORCE> GetPACUStore(string patID, int visitID, int operID);
        List<MED_CHUFANG_RECORD> GetMedChuFangRecordList(string patID, int visitID, int operID, int chuFangClass);
        MED_PATS_IN_HOSPITAL GetPatsInHospital(string patientID, int visitID);
        MED_ANESTHESIA_PLAN GetAnesthesiaPlan(string patientID, int visitID, int operID);
        MED_OPERATION_MASTER GetOperationMaster(string patientID, int visitID, int operID);
        MED_OPERATION_MASTER_EXT GetOperationMasterExt(string patientID, int visitID, int operID);
        MED_PAT_MASTER_INDEX GetPatMasterIndex(string patientID);
        List<MED_BJCA_SIGN> GetBjcaSignList(string patID, int visitID, int operID, string strDocName);

        List<MED_CAMERA_PICINFO> GetPicInfoList(string patID, int visitID, int operID);

        long GetMedChuFangRecordMaxIndex();
        bool SaveMedChuFangRecordList(List<MED_CHUFANG_RECORD> list);
        bool SaveMedChuFangRecord(MED_CHUFANG_RECORD chuFangRecord);
        bool SaveAnesInputData(MED_ANESTHESIA_INPUT_DATA anesInputData);
        bool SaveAnalgesicMaster(MED_OPERATION_ANALGESIC_MASTER dataList);
        bool SaveAnalgesicMedicineList(List<MED_OPER_ANALGESIC_MEDICINE> dataList);
        bool SaveAnalgesicTotalList(List<MED_OPER_ANALGESIC_TOTAL> dataList);
        bool SaveEmrArchiveList(List<MED_EMR_ARCHIVE_DETIAL> dataList);
        bool SaveOperExtendedList(List<MED_OPERATION_EXTENDED> dataList);

        bool SaveAnesRecoverData(MED_ANESTHESIA_RECOVER data);
        bool SaveAnesInquiryData(MED_ANESTHESIA_INQUIRY data);
        bool SaveOperCheckList(List<MED_QIXIE_QINGDIAN> dataList);
        bool SavePacuSocre(List<MED_PACU_SORCE> data);
        bool SaveSafetyCheck(MED_SAFETY_CHECKS data);
        bool SaveRickEstimate(MED_OPER_RISK_ESTIMATE data);
        bool SaveBjcaSign(MED_BJCA_SIGN row);
        bool UpdateBjcaSignList(List<MED_BJCA_SIGN> dataList);
        bool InsertEmrArchive(MED_EMR_ARCHIVE_DETIAL data);
        bool SaveDocData(dynamic dyParams);
        bool SaveMedicalBasicDoc(dynamic item);
        bool SaveDocDataPars(DocDataPars docData);

        bool SaveCameraPic(MED_CAMERA_PICINFO data);
    }

    /// <summary>
    /// 账号类
    /// </summary>
    public class CareDocService : BaseService<CareDocService>, ICareDocService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected CareDocService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public CareDocService(IDapperContext context)
            : base(context)
        {
        }

        /// <summary>
        /// 获取器械清点列表
        /// </summary>
        /// <param name="patID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_QIXIE_QINGDIAN> GetOperCheckList(string patID, int visitID, int operID)
        {
            List<MED_QIXIE_QINGDIAN> dataList = dapper.Set<MED_QIXIE_QINGDIAN>().Select(
                x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.OPER_ID == operID).ToList();
            //if (dataList == null || dataList.Count == 0)
            //{
            //    MED_QIXIE_QINGDIAN data = new MED_QIXIE_QINGDIAN();
            //    data.PATIENT_ID = patID;
            //    data.VISIT_ID = visitID;
            //    data.OPER_ID = operID;
            //    dataList.Add(data);
            //}
            return dataList;
        }

        [HttpGet]
        public virtual List<MED_SAFETY_CHECKS> GetSafetyCheckData(string patID, int visitID, int operID)
        {
            List<MED_SAFETY_CHECKS> dataList = dapper.Set<MED_SAFETY_CHECKS>().Select(
                x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.OPER_ID == operID).ToList();
            if (dataList == null || dataList.Count == 0)
            {
                MED_SAFETY_CHECKS data = new MED_SAFETY_CHECKS();
                data.PATIENT_ID = patID;
                data.VISIT_ID = visitID;
                data.OPER_ID = operID;
                dataList.Add(data);
            }
            return dataList;
        }

        [HttpGet]
        public virtual List<MED_OPER_ANALGESIC_MEDICINE> GetAnalgesicMedicineList(string patID, int visitID, int operID)
        {
            List<MED_OPER_ANALGESIC_MEDICINE> dataList = dapper.Set<MED_OPER_ANALGESIC_MEDICINE>().Select(
                x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.OPER_ID == operID).ToList();
            //if (dataList == null || dataList.Count == 0)
            //{
            //    MED_OPER_ANALGESIC_MEDICINE data = new MED_OPER_ANALGESIC_MEDICINE();
            //    data.PATIENT_ID = patID;
            //    data.VISIT_ID = visitID;
            //    data.OPER_ID = operID;
            //    dataList.Add(data);
            //}
            return dataList;
        }

        [HttpGet]
        public virtual List<MED_OPER_ANALGESIC_TOTAL> GetAnalgesicTotalList(string patID, int visitID, int operID)
        {
            List<MED_OPER_ANALGESIC_TOTAL> dataList = dapper.Set<MED_OPER_ANALGESIC_TOTAL>().Select(
                x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.OPER_ID == operID).ToList();
            //if (dataList == null || dataList.Count == 0)
            //{
            //    MED_OPER_ANALGESIC_TOTAL data = new MED_OPER_ANALGESIC_TOTAL();
            //    data.PATIENT_ID = patID;
            //    data.VISIT_ID = visitID;
            //    data.OPER_ID = operID;
            //    dataList.Add(data);
            //}

            return dataList;
        }

        [HttpGet]
        public virtual List<MED_OPERATION_NAME> GetOperNameList(string patID, int visitID, int operID)
        {
            List<MED_OPERATION_NAME> dataList = dapper.Set<MED_OPERATION_NAME>().Select(
                x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.OPER_ID == operID).ToList();
            //if (dataList == null || dataList.Count == 0)
            //{
            //    MED_OPERATION_NAME data = new MED_OPERATION_NAME();
            //    data.PATIENT_ID = patID;
            //    data.VISIT_ID = visitID;
            //    data.OPER_ID = operID;
            //    dataList.Add(data);
            //}
            return dataList;
        }

        [HttpGet]
        public virtual List<MED_BJCA_SIGN> GetBjcaSignList(string patID, int visitID, int operID, string strDocName)
        {
            List<MED_BJCA_SIGN> result = dapper.Set<MED_BJCA_SIGN>().
                                         Select(x => x.PATIENT_ID.Equals(patID) && x.VISIT_ID == visitID &&
                                                     x.OPER_ID == operID && x.SIGNDOCNAME.Equals(strDocName)).OrderByDescending(x => x.SIGNDATE).ToList();

            return result;
        }

        [HttpPost]
        public virtual bool SaveBjcaSign(MED_BJCA_SIGN row)
        {
            bool ret = false;
            ret = dapper.Set<MED_BJCA_SIGN>().Save(row);
            dapper.SaveChanges();
            return ret;
        }

        [HttpPost]
        public virtual bool UpdateBjcaSignList(List<MED_BJCA_SIGN> dataList)
        {
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }

        [HttpPost]
        public virtual bool SaveOperNameList(List<MED_OPERATION_NAME> dataList)
        {
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }

        [HttpGet]
        public virtual List<MED_ANESTHESIA_INQUIRY> GetAnesInquiry(string patID, int visitID, int operID)
        {
            List<MED_ANESTHESIA_INQUIRY> dataList = dapper.Set<MED_ANESTHESIA_INQUIRY>().Select(
                x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.OPER_ID == operID).ToList();
            if (dataList == null || dataList.Count == 0)
            {
                MED_ANESTHESIA_INQUIRY data = new MED_ANESTHESIA_INQUIRY();
                data.PATIENT_ID = patID;
                data.VISIT_ID = visitID;
                data.OPER_ID = operID;
                data.INQUIRY_NO = 1;
                data.INQUIRY_DATE = DateTime.Now;
                data.ModelStatus = ModelStatus.Add;
                dataList.Add(data);
            }
            return dataList;
        }

        [HttpGet]
        public virtual List<MED_OPERATION_EXTENDED> GetOperExtended(string patID, int visitID, int operID)
        {
            List<MED_OPERATION_EXTENDED> dataList = dapper.Set<MED_OPERATION_EXTENDED>().Select(
                x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.OPER_ID == operID).ToList();
            //if (dataList == null || dataList.Count == 0)
            //{
            //    MED_OPERATION_EXTENDED data = new MED_OPERATION_EXTENDED();
            //    data.PATIENT_ID = patID;
            //    data.VISIT_ID = visitID;
            //    data.OPER_ID = operID;
            //    dataList.Add(data);
            //}
            return dataList;
        }

        [HttpGet]
        public virtual List<MED_POSTOPERATIVE_EXTENDED> GetPostoperativeExtended(string patID, int visitID, int operID)
        {
            List<MED_POSTOPERATIVE_EXTENDED> dataList = dapper.Set<MED_POSTOPERATIVE_EXTENDED>().Select(
                x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.OPER_ID == operID).ToList();
            //if (dataList == null || dataList.Count == 0)
            //{
            //    MED_POSTOPERATIVE_EXTENDED data = new MED_POSTOPERATIVE_EXTENDED();
            //    data.PATIENT_ID = patID;
            //    data.VISIT_ID = visitID;
            //    data.OPER_ID = operID;
            //    dataList.Add(data);
            //}
            return dataList;
        }

        [HttpGet]
        public virtual List<MED_EMR_ARCHIVE_DETIAL> GetEmrArchiveList(string patID, int visitID, string operID, string docName)
        {
            List<MED_EMR_ARCHIVE_DETIAL> dataList = dapper.Set<MED_EMR_ARCHIVE_DETIAL>().Select(
                   x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.ARCHIVE_KEY == operID && x.MR_SUB_CLASS == docName).ToList();

            return dataList;
        }

        [HttpGet]
        public virtual List<MED_PREOPERATIVE_EXPANSION> GetPreoperativeExpansion(string patID, int visitID, int operID)
        {
            List<MED_PREOPERATIVE_EXPANSION> dataList = dapper.Set<MED_PREOPERATIVE_EXPANSION>().Select(
                x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.OPER_ID == operID).ToList();
            //if (dataList == null || dataList.Count == 0)
            //{
            //    MED_PREOPERATIVE_EXPANSION data = new MED_PREOPERATIVE_EXPANSION();
            //    data.PATIENT_ID = patID;
            //    data.VISIT_ID = visitID;
            //    data.OPER_ID = operID;
            //    dataList.Add(data);
            //}
            return dataList;
        }

        [HttpGet]
        public virtual MED_PAT_VISIT GetPatVisit(string patientID, int visitID)
        {
            MED_PAT_VISIT data = dapper.Set<MED_PAT_VISIT>().Single(
                 x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID);
            if (data == null)
            {
                data = new MED_PAT_VISIT();
                data.PATIENT_ID = patientID;
                data.VISIT_ID = visitID;
                data.ModelStatus = ModelStatus.Add;
            }
            return data;
        }

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

        [HttpGet]
        public virtual MED_OPERATION_MASTER_EXT GetOperationMasterExt(string patientID, int visitID, int operID)
        {
            MED_OPERATION_MASTER_EXT operationMasterExt = dapper.Set<MED_OPERATION_MASTER_EXT>().Single(
                 x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID);
            if (operationMasterExt == null)
            {
                operationMasterExt = new MED_OPERATION_MASTER_EXT()
                {
                    PATIENT_ID = patientID,
                    VISIT_ID = visitID,
                    OPER_ID = operID
                };
            }

            return operationMasterExt;
        }

        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <returns></returns>
        [HttpGet]
        public virtual MED_PAT_MASTER_INDEX GetPatMasterIndex(string patientID)
        {
            MED_PAT_MASTER_INDEX patMasterIndex = dapper.Set<MED_PAT_MASTER_INDEX>().Single(
                x => x.PATIENT_ID == patientID);
            if (patMasterIndex == null)
            {
                patMasterIndex = new MED_PAT_MASTER_INDEX()
                {
                    PATIENT_ID = patientID
                };
            }

            return patMasterIndex;
        }

        /// <summary>
        /// 获取病人住院信息
        /// </summary>
        /// <param name="patID">病人ID</param>
        /// <returns></returns>
        [HttpGet]
        public virtual MED_PATS_IN_HOSPITAL GetPatsInHospital(string patientID, int visitID)
        {
            MED_PATS_IN_HOSPITAL patsInHospital = dapper.Set<MED_PATS_IN_HOSPITAL>().Single(
                x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID);
            if (patsInHospital == null)
            {
                patsInHospital = new MED_PATS_IN_HOSPITAL()
                {
                    PATIENT_ID = patientID,
                    VISIT_ID = visitID
                };
            }

            return patsInHospital;
        }

        /// <summary>
        /// 获取麻醉计划
        /// </summary>
        /// <param name="patID">病人ID</param>
        [HttpGet]
        public virtual MED_ANESTHESIA_PLAN GetAnesthesiaPlan(string patientID, int visitID, int operID)
        {
            MED_ANESTHESIA_PLAN anesthesiaPlan = dapper.Set<MED_ANESTHESIA_PLAN>().Single(x => x.PATIENT_ID == patientID && x.VISIT_ID == visitID && x.OPER_ID == operID);
            if (anesthesiaPlan == null)
            {
                anesthesiaPlan = new MED_ANESTHESIA_PLAN()
                {
                    PATIENT_ID = patientID,
                    VISIT_ID = visitID,
                    OPER_ID = operID
                };
            }

            return anesthesiaPlan;
        }

        [HttpGet]
        public virtual MED_ANESTHESIA_PLAN_PMH GetAnesthesiaPlanPMH(string patID, int visitID, int operID)
        {
            MED_ANESTHESIA_PLAN_PMH data = dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Single(
                 x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.OPER_ID == operID);
            if (data == null)
            {
                data = new MED_ANESTHESIA_PLAN_PMH();
                data.PATIENT_ID = patID;
                data.VISIT_ID = visitID;
                data.OPER_ID = operID;
                data.ModelStatus = ModelStatus.Add;
            }
            return data;
        }

        [HttpGet]
        public virtual MED_ANESTHESIA_PLAN_EXAM GetAnesthesiaPlanEXAM(string patID, int visitID, int operID)
        {
            MED_ANESTHESIA_PLAN_EXAM data = dapper.Set<MED_ANESTHESIA_PLAN_EXAM>().Single(
                 x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.OPER_ID == operID);
            if (data == null)
            {
                data = new MED_ANESTHESIA_PLAN_EXAM();
                data.PATIENT_ID = patID;
                data.VISIT_ID = visitID;
                data.OPER_ID = operID;
                data.ModelStatus = ModelStatus.Add;
            }
            return data;
        }

        [HttpGet]
        public virtual MED_ANESTHESIA_RECOVER GetAnesRecoverData(string patID, int visitID, int operID)
        {
            MED_ANESTHESIA_RECOVER data = dapper.Set<MED_ANESTHESIA_RECOVER>().Single(
                 x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.OPER_ID == operID);
            if (data == null)
            {
                data = new MED_ANESTHESIA_RECOVER();
                data.PATIENT_ID = patID;
                data.VISIT_ID = visitID;
                data.OPER_ID = operID;
                data.ModelStatus = ModelStatus.Add;
            }
            return data;
        }

        [HttpGet]
        public virtual MED_OPERATION_ANALGESIC_MASTER GetAnalgesicMaster(string patID, int visitID, int operID)
        {
            MED_OPERATION_ANALGESIC_MASTER data = dapper.Set<MED_OPERATION_ANALGESIC_MASTER>().Single(
                 x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.OPER_ID == operID);
            if (data == null)
            {
                data = new MED_OPERATION_ANALGESIC_MASTER();
                data.PATIENT_ID = patID;
                data.VISIT_ID = visitID;
                data.OPER_ID = operID;
                data.ModelStatus = ModelStatus.Add;
            }
            return data;
        }

        [HttpGet]
        public virtual MED_OPER_RISK_ESTIMATE GetRickEstimate(string patID, int visitID, int operID)
        {
            MED_OPER_RISK_ESTIMATE data = dapper.Set<MED_OPER_RISK_ESTIMATE>().Single(
                 x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.OPER_ID == operID);
            if (data == null)
            {
                data = new MED_OPER_RISK_ESTIMATE();
                data.PATIENT_ID = patID;
                data.VISIT_ID = visitID;
                data.OPER_ID = operID;
                data.ModelStatus = ModelStatus.Add;
            }
            return data;
        }

        [HttpGet]
        public virtual MED_ANESTHESIA_INPUT_DATA GetAnesthestaInputData(string patID, int visitID, int operID)
        {
            MED_ANESTHESIA_INPUT_DATA data = dapper.Set<MED_ANESTHESIA_INPUT_DATA>().Single(
                 x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.OPER_ID == operID);
            if (data == null)
            {
                data = new MED_ANESTHESIA_INPUT_DATA();
                data.PATIENT_ID = patID;
                data.VISIT_ID = visitID;
                data.OPER_ID = operID;
                data.ModelStatus = ModelStatus.Add;
            }
            return data;
        }

        [HttpGet]
        public virtual List<MED_PACU_SORCE> GetPACUStore(string patID, int visitID, int operID)
        {
            List<MED_PACU_SORCE> dataList = dapper.Set<MED_PACU_SORCE>().Select(
               x => x.PATIENT_ID == patID && x.VISIT_ID == visitID && x.OPER_ID == operID).ToList();
            //if (data == null)
            //{
            //    data = new MED_PACU_SORCE();
            //    data.PATIENT_ID = patID;
            //    data.VISIT_ID = visitID;
            //    data.OPER_ID = operID;
            //    data.ModelStatus = ModelStatus.Add;
            //}
            return dataList;
        }

        [HttpGet]
        public virtual List<MED_CHUFANG_RECORD> GetMedChuFangRecordList(string patID, int visitID, int operID, int chuFangClass)
        {
            List<MED_CHUFANG_RECORD> dataList = dapper.Set<MED_CHUFANG_RECORD>().Select(x => x.PATIENT_ID.Equals(patID) &&
                                                                                             x.VISIT_ID == visitID &&
                                                                                             x.OPER_ID == operID &&
                                                                                             x.CHUFANG_CLASS == chuFangClass).ToList();
            return dataList;
        }

        [HttpGet]
        public virtual List<MED_CAMERA_PICINFO> GetPicInfoList(string patID, int visitID, int operID)
        {
            List<MED_CAMERA_PICINFO> dataList = dapper.Set<MED_CAMERA_PICINFO>().Select(x => x.PATIENT_ID.Equals(patID) &&
                                                                                               x.VISIT_ID == visitID &&
                                                                                               x.OPER_ID == operID).ToList();
            return dataList;
        }

        [HttpPost]
        public virtual bool SaveCameraPic(MED_CAMERA_PICINFO data)
        {
            bool ret = false;
            ret = dapper.Set<MED_CAMERA_PICINFO>().Save(data);
            dapper.SaveChanges();
            return ret;
        }

        [HttpGet]
        public virtual long GetMedChuFangRecordMaxIndex()
        {
            long maxIndex = 1;
            MED_CHUFANG_RECORD temp = dapper.Set<MED_CHUFANG_RECORD>().Select().OrderByDescending(x => x.CHUFANG_INDEX).ToList().FirstOrDefault();
            if (null != temp)
            {
                maxIndex = temp.CHUFANG_INDEX + 1;
            }

            return maxIndex;
        }

        [HttpPost]
        public virtual bool SaveMedChuFangRecordList(List<MED_CHUFANG_RECORD> list)
        {
            bool flag = UpdateWholeList(list);
            dapper.SaveChanges();
            return flag;
        }

        [HttpPost]
        public virtual bool SaveMedChuFangRecord(MED_CHUFANG_RECORD chuFangRecord)
        {
            bool ret = false;
            ret = dapper.Set<MED_CHUFANG_RECORD>().Save(chuFangRecord);
            dapper.SaveChanges();
            return ret;
        }

        [HttpPost]
        public virtual bool SaveAnesInputData(MED_ANESTHESIA_INPUT_DATA anesInputData)
        {
            bool ret = false;

            ret = dapper.Set<MED_ANESTHESIA_INPUT_DATA>().Save(anesInputData);

            dapper.SaveChanges();
            return ret;
        }
        [HttpPost]
        public virtual bool SaveAnalgesicMaster(MED_OPERATION_ANALGESIC_MASTER dataList)
        {
            bool i = dapper.Set<MED_OPERATION_ANALGESIC_MASTER>().Save(dataList);
            dapper.SaveChanges();
            return i;
        }
        [HttpPost]
        public virtual bool SaveAnalgesicMedicineList(List<MED_OPER_ANALGESIC_MEDICINE> dataList)
        {
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }
        [HttpPost]
        public virtual bool SaveAnalgesicTotalList(List<MED_OPER_ANALGESIC_TOTAL> dataList)
        {
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }

        [HttpPost]
        public virtual bool SaveEmrArchiveList(List<MED_EMR_ARCHIVE_DETIAL> dataList)
        {
            //List<MED_EMR_ARCHIVE_DETIAL> emrArchiveDetailList = null;
            //if (dataList != null)
            //{
            //    string value = dataList.ToString();
            //    emrArchiveDetailList = JsonConvert.DeserializeObject<List<MED_EMR_ARCHIVE_DETIAL>>(value);
            //    bool flag = UpdateWholeList(dataList);
            //    dapper.SaveChanges();
            //    return flag;
            //}
            //else
            //    return true;
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }

        [HttpPost]
        public virtual bool SaveOperExtendedList(List<MED_OPERATION_EXTENDED> dataList)
        {
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }
        [HttpPost]
        public virtual bool SaveAnesRecoverData(MED_ANESTHESIA_RECOVER data)
        {
            bool i = dapper.Set<MED_ANESTHESIA_RECOVER>().Save(data);
            dapper.SaveChanges();
            return i;
        }
        [HttpPost]
        public virtual bool SaveAnesInquiryData(MED_ANESTHESIA_INQUIRY data)
        {
            bool i = dapper.Set<MED_ANESTHESIA_INQUIRY>().Save(data);
            dapper.SaveChanges();
            return i;
        }

        [HttpPost]
        public virtual bool SavePacuSocre(List<MED_PACU_SORCE> data)
        {
            bool flag = UpdateWholeList(data);
            dapper.SaveChanges();
            return flag;
        }
        [HttpPost]
        public virtual bool SaveOperCheckList(List<MED_QIXIE_QINGDIAN> dataList)
        {
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }
        [HttpPost]
        public virtual bool SaveSafetyCheck(MED_SAFETY_CHECKS data)
        {
            int i = dapper.Set<MED_SAFETY_CHECKS>().Update(data);
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
        public virtual bool SaveRickEstimate(MED_OPER_RISK_ESTIMATE data)
        {
            int i = dapper.Set<MED_OPER_RISK_ESTIMATE>().Update(data);
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
        public virtual bool InsertEmrArchive(MED_EMR_ARCHIVE_DETIAL data)
        {
            bool flag = dapper.Set<MED_EMR_ARCHIVE_DETIAL>().Insert(data);
            dapper.SaveChanges();
            return flag;
        }
        [HttpPost]
        public virtual bool SaveMedicalBasicDoc(dynamic dyParams)
        {
            bool Result = true;

            try
            {
                MED_OPERATION_MASTER operMaster = null;
                MED_OPERATION_MASTER_EXT operMasterExt = null;
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
                    dapper.Set<MED_OPERATION_MASTER>().Save(operMaster);
                }
                if (dyParams.operMasterEXT != null)
                {
                    string value = dyParams.operMasterEXT.ToString();
                    operMasterExt = JsonConvert.DeserializeObject<MED_OPERATION_MASTER_EXT>(value);
                    dapper.Set<MED_OPERATION_MASTER_EXT>().Save(operMasterExt);
                }
                if (dyParams.patMasterIndex != null)
                {
                    string value = dyParams.patMasterIndex.ToString();
                    patMasterIndex = JsonConvert.DeserializeObject<MED_PAT_MASTER_INDEX>(value);
                    dapper.Set<MED_PAT_MASTER_INDEX>().Save(patMasterIndex);
                }
                if (dyParams.patVisit != null)
                {
                    string value = dyParams.patVisit.ToString();
                    patVisit = JsonConvert.DeserializeObject<MED_PAT_VISIT>(value);
                    dapper.Set<MED_PAT_VISIT>().Save(patVisit);

                }
                if (dyParams.patsInHospital != null)
                {
                    string value = dyParams.patsInHospital.ToString();
                    patsInHospital = JsonConvert.DeserializeObject<MED_PATS_IN_HOSPITAL>(value);
                    dapper.Set<MED_PATS_IN_HOSPITAL>().Save(patsInHospital);

                }
                if (dyParams.anesPlan != null)
                {
                    string value = dyParams.anesPlan.ToString();
                    anesPlan = JsonConvert.DeserializeObject<MED_ANESTHESIA_PLAN>(value);
                    dapper.Set<MED_ANESTHESIA_PLAN>().Save(anesPlan);

                }
                if (dyParams.anesPlanExam != null)
                {
                    string value = dyParams.anesPlanExam.ToString();
                    anesPlanExam = JsonConvert.DeserializeObject<MED_ANESTHESIA_PLAN_EXAM>(value);
                    dapper.Set<MED_ANESTHESIA_PLAN_EXAM>().Save(anesPlanExam);

                }
                if (dyParams.anesPlanPmh != null)
                {
                    string value = dyParams.anesPlanPmh.ToString();
                    anesPlanPmh = JsonConvert.DeserializeObject<MED_ANESTHESIA_PLAN_PMH>(value);
                    dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Save(anesPlanPmh);

                }
                if (dyParams.operExtended != null)
                {
                    string value = dyParams.operExtended.ToString();
                    operExtended = JsonConvert.DeserializeObject<List<MED_OPERATION_EXTENDED>>(value);
                    UpdateWholeList(operExtended);
                }
                if (dyParams.postExtended != null)
                {
                    string value = dyParams.postExtended.ToString();
                    postExtended = JsonConvert.DeserializeObject<List<MED_POSTOPERATIVE_EXTENDED>>(value);
                    UpdateWholeList(postExtended);
                }
                if (dyParams.preExpansion != null)
                {
                    string value = dyParams.preExpansion.ToString();
                    preExpansion = JsonConvert.DeserializeObject<List<MED_PREOPERATIVE_EXPANSION>>(value);
                    UpdateWholeList(preExpansion);

                }
                dapper.SaveChanges();
            }
            catch (Exception)
            {
                Result = false;
            }
            return Result;
        }

        /// <summary>
        /// 为了解决数据不同步的情况，将3中状态的数据进行比对，判断哪些字段需要修改
        /// </summary>
        /// <typeparam name="T">只能是三个自定义表</typeparam>
        /// <param name="originalList">加载文书时，从数据获得的原始数据</param>
        /// <param name="newList">文书保存时，缓存里数据</param>
        private void SaveModelList<T>(List<T> originalList, List<T> newList) where T : BaseModel
        {
            if (null == originalList || null == newList)
            {
                return;
            }

            if (typeof(T) == typeof(MED_POSTOPERATIVE_EXTENDED) ||
                typeof(T) == typeof(MED_PREOPERATIVE_EXPANSION) ||
                typeof(T) == typeof(MED_OPERATION_EXTENDED))
            {
                List<T> temp = new List<T>(newList);
                temp.ForEach(newItem =>
                {
                    string itemName = newItem.GetValue("ITEM_NAME").ToString();
                    var itemValue = newItem.GetValue("ITEM_VALUE");

                    T t = originalList.FirstOrDefault(oriItem => oriItem.GetValue("ITEM_NAME").ToString().Equals(itemName) &&
                                       (oriItem.GetValue("ITEM_VALUE") == itemValue ||
                                       (itemValue != null && oriItem.GetValue("ITEM_VALUE") != null) &&
                                        itemValue.ToString().Equals(oriItem.GetValue("ITEM_VALUE").ToString())));
                    if (t == null)
                    {
                        // 没有找到说明有修改数据
                    }
                    else
                    {
                        // 找到了说明没有修改数据，则不修改
                        newList.Remove(newItem);
                    }
                });
            }
        }

        /// <summary>
        /// 为了解决数据不同步的情况，将3中状态的数据进行比对，判断哪些字段需要修改
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="originalData">加载文书时，从数据获得的原始数据</param>
        /// <param name="newData">文书保存时，缓存里数据</param>
        /// <param name="curDbData">当前数据库里最新的数据</param>
        private void SaveModel<T>(T originalData, T newData, T curDbData) where T : BaseModel
        {
            if (newData != null && originalData != null && curDbData != null)
            {
                PropertyInfo[] proInfos = typeof(T).GetProperties();
                // 遍历属性，获取三个对象的各个属性值
                foreach (PropertyInfo proInfo in proInfos)
                {
                    var originalValue = typeof(T).GetProperty(proInfo.Name).GetValue(originalData, null);
                    var newValue = typeof(T).GetProperty(proInfo.Name).GetValue(newData, null);
                    var curValue = typeof(T).GetProperty(proInfo.Name).GetValue(curDbData, null);

                    // 如果当前属性在 originalData 和 newData 的值相同，表示文书没有修改数据，则以数据库里的数据为主
                    if (originalValue == newValue ||
                       (originalValue != null && newValue != null && originalValue.ToString().Equals(newValue.ToString())))
                    {
                        proInfo.SetValue(newData, curValue, null);
                    }
                    else
                    {
                        // 如果当前属性在 originalData 和 newData 的值不相同，则一律以newData的数据为主
                    }
                }
                try
                {
                    // 保存newData数据
                    dapper.Set<T>().Save(newData);
                }
                catch (Exception ex)
                {
                    Logger.Error("SaveModel-" + typeof(T).Name + "保存失败: " + ex);
                }
            }
            else if (newData != null)
            {
                // 保存newData数据
                dapper.Set<T>().Save(newData);
            }
        }

        [HttpPost]
        public virtual bool SaveDocData(dynamic dyParams)
        {
            bool Result = true;

            try
            {
                MED_OPERATION_MASTER operMaster = null;
                MED_OPERATION_MASTER originalOperMaster = null;
                MED_OPERATION_MASTER_EXT operMasterExt = null;
                MED_OPERATION_MASTER_EXT originalOperMasterExt = null;
                MED_PAT_MASTER_INDEX patMasterIndex = null;
                MED_PAT_MASTER_INDEX originalPatMasterIndex = null;
                MED_PAT_VISIT patVisit = null;
                MED_PAT_VISIT originalPatVisit = null;
                MED_PATS_IN_HOSPITAL patsInHospital = null;
                MED_PATS_IN_HOSPITAL originalPatsInHospital = null;
                MED_ANESTHESIA_PLAN anesPlan = null;
                MED_ANESTHESIA_PLAN originalAnesPlan = null;
                MED_ANESTHESIA_PLAN_EXAM anesPlanExam = null;
                MED_ANESTHESIA_PLAN_EXAM originalAnesPlanExam = null;
                MED_ANESTHESIA_PLAN_PMH anesPlanPmh = null;
                MED_ANESTHESIA_PLAN_PMH originalAnesPlanPmh = null;
                MED_ANESTHESIA_INPUT_DATA anesInputData = null;
                MED_ANESTHESIA_INPUT_DATA originalAnesInputData = null;
                MED_OPERATION_ANALGESIC_MASTER operAnalgesicMaster = null;
                MED_OPERATION_ANALGESIC_MASTER originalOperAnalgesicMaster = null;
                MED_SAFETY_CHECKS safetyChecks = null;
                MED_SAFETY_CHECKS originalSafetyChecks = null;
                MED_OPER_RISK_ESTIMATE operRiskEstimate = null;
                MED_OPER_RISK_ESTIMATE originalOperRiskEstimate = null;
                List<MED_OPER_ANALGESIC_MEDICINE> operAnalgesicMedicine = null;
                List<MED_OPER_ANALGESIC_MEDICINE> originalOperAnalgesicMedicine = null;
                List<MED_OPER_ANALGESIC_TOTAL> operAnalgesicTotal = null;
                List<MED_OPER_ANALGESIC_TOTAL> originalOperAnalgesicTotal = null;
                List<MED_OPERATION_EXTENDED> operExtended = null;
                List<MED_OPERATION_EXTENDED> originalOperExtended = null;
                List<MED_POSTOPERATIVE_EXTENDED> postExtended = null;
                List<MED_POSTOPERATIVE_EXTENDED> originalPostExtended = null;
                List<MED_PREOPERATIVE_EXPANSION> preExpansion = null;
                List<MED_PREOPERATIVE_EXPANSION> originalPreExpansion = null;

                if (dyParams.anesInputData != null)
                {
                    string value = dyParams.anesInputData.ToString();
                    anesInputData = JsonConvert.DeserializeObject<MED_ANESTHESIA_INPUT_DATA>(value);
                    if (dyParams.originalAnesInputData != null)
                    {
                        value = dyParams.originalAnesInputData.ToString();
                        originalAnesInputData = JsonConvert.DeserializeObject<MED_ANESTHESIA_INPUT_DATA>(value);
                    }

                    // 数据库里的最新数据
                    MED_ANESTHESIA_INPUT_DATA curDbAnesInputData = this.GetAnesthestaInputData(anesInputData.PATIENT_ID,
                                                                                               anesInputData.VISIT_ID,
                                                                                               anesInputData.OPER_ID);
                    this.SaveModel<MED_ANESTHESIA_INPUT_DATA>(originalAnesInputData,
                                                              anesInputData,
                                                              curDbAnesInputData);
                }

                if (dyParams.operMaster != null)
                {
                    string value = dyParams.operMaster.ToString();
                    operMaster = JsonConvert.DeserializeObject<MED_OPERATION_MASTER>(value);
                    if (dyParams.originalOperMaster != null)
                    {
                        value = dyParams.originalOperMaster.ToString();
                        originalOperMaster = JsonConvert.DeserializeObject<MED_OPERATION_MASTER>(value);
                    }

                    MED_OPERATION_MASTER curDbOperMaster = this.GetOperationMaster(operMaster.PATIENT_ID,
                                                                                   operMaster.VISIT_ID,
                                                                                   operMaster.OPER_ID);
                    this.SaveModel<MED_OPERATION_MASTER>(originalOperMaster, operMaster, curDbOperMaster);
                }

                if (dyParams.operMasterExt != null)
                {
                    string value = dyParams.operMasterExt.ToString();
                    operMasterExt = JsonConvert.DeserializeObject<MED_OPERATION_MASTER_EXT>(value);
                    if (dyParams.originalOperMasterExt != null)
                    {
                        value = dyParams.originalOperMasterExt.ToString();
                        originalOperMasterExt = JsonConvert.DeserializeObject<MED_OPERATION_MASTER_EXT>(value);
                    }

                    MED_OPERATION_MASTER_EXT curDbOperMasterExt = this.GetOperationMasterExt(operMasterExt.PATIENT_ID,
                                                                                             operMasterExt.VISIT_ID,
                                                                                             operMasterExt.OPER_ID);
                    this.SaveModel<MED_OPERATION_MASTER_EXT>(originalOperMasterExt, operMasterExt, curDbOperMasterExt);
                }

                if (dyParams.patMasterIndex != null)
                {
                    string value = dyParams.patMasterIndex.ToString();
                    patMasterIndex = JsonConvert.DeserializeObject<MED_PAT_MASTER_INDEX>(value);
                    if (dyParams.originalPatMasterIndex != null)
                    {
                        value = dyParams.originalPatMasterIndex.ToString();
                        originalPatMasterIndex = JsonConvert.DeserializeObject<MED_PAT_MASTER_INDEX>(value);
                    }

                    MED_PAT_MASTER_INDEX curDbPatMasterIndex = this.GetPatMasterIndex(patMasterIndex.PATIENT_ID);
                    this.SaveModel<MED_PAT_MASTER_INDEX>(originalPatMasterIndex, patMasterIndex, curDbPatMasterIndex);
                }

                if (dyParams.patVisit != null)
                {
                    string value = dyParams.patVisit.ToString();
                    patVisit = JsonConvert.DeserializeObject<MED_PAT_VISIT>(value);
                    if (dyParams.originalPatVisit != null)
                    {
                        value = dyParams.originalPatVisit.ToString();
                        originalPatVisit = JsonConvert.DeserializeObject<MED_PAT_VISIT>(value);
                    }

                    MED_PAT_VISIT curDbPatVisit = this.GetPatVisit(patVisit.PATIENT_ID, patVisit.VISIT_ID);
                    this.SaveModel<MED_PAT_VISIT>(originalPatVisit, patVisit, curDbPatVisit);
                }

                if (dyParams.patsInHospital != null)
                {
                    string value = dyParams.patsInHospital.ToString();
                    patsInHospital = JsonConvert.DeserializeObject<MED_PATS_IN_HOSPITAL>(value);
                    if (dyParams.originalPatsInHospital != null)
                    {
                        value = dyParams.originalPatsInHospital.ToString();
                        originalPatsInHospital = JsonConvert.DeserializeObject<MED_PATS_IN_HOSPITAL>(value);
                    }

                    MED_PATS_IN_HOSPITAL curDbPatsInHospital = this.GetPatsInHospital(patsInHospital.PATIENT_ID,
                                                                                      patsInHospital.VISIT_ID);
                    this.SaveModel<MED_PATS_IN_HOSPITAL>(originalPatsInHospital, patsInHospital, curDbPatsInHospital);
                }

                if (dyParams.anesPlan != null)
                {
                    string value = dyParams.anesPlan.ToString();
                    anesPlan = JsonConvert.DeserializeObject<MED_ANESTHESIA_PLAN>(value);
                    if (dyParams.originalAnesPlan != null)
                    {
                        value = dyParams.originalAnesPlan.ToString();
                        originalAnesPlan = JsonConvert.DeserializeObject<MED_ANESTHESIA_PLAN>(value);
                    }

                    MED_ANESTHESIA_PLAN curDbAnesPlan = this.GetAnesthesiaPlan(anesPlan.PATIENT_ID,
                                                                               anesPlan.VISIT_ID,
                                                                               anesPlan.OPER_ID);
                    this.SaveModel<MED_ANESTHESIA_PLAN>(originalAnesPlan, anesPlan, curDbAnesPlan);
                }

                if (dyParams.anesPlanExam != null)
                {
                    string value = dyParams.anesPlanExam.ToString();
                    anesPlanExam = JsonConvert.DeserializeObject<MED_ANESTHESIA_PLAN_EXAM>(value);
                    if (dyParams.originalAnesPlanExam != null)
                    {
                        value = dyParams.originalAnesPlanExam.ToString();
                        originalAnesPlanExam = JsonConvert.DeserializeObject<MED_ANESTHESIA_PLAN_EXAM>(value);
                    }

                    MED_ANESTHESIA_PLAN_EXAM curDbAnesPlanExam = this.GetAnesthesiaPlanEXAM(anesPlanExam.PATIENT_ID,
                                                                                            anesPlanExam.VISIT_ID,
                                                                                            anesPlanExam.OPER_ID);
                    this.SaveModel<MED_ANESTHESIA_PLAN_EXAM>(originalAnesPlanExam, anesPlanExam, curDbAnesPlanExam);
                }

                if (dyParams.anesPlanPmh != null)
                {
                    string value = dyParams.anesPlanPmh.ToString();
                    anesPlanPmh = JsonConvert.DeserializeObject<MED_ANESTHESIA_PLAN_PMH>(value);
                    if (dyParams.originalAnesPlanPmh != null)
                    {
                        value = dyParams.originalAnesPlanPmh.ToString();
                        originalAnesPlanPmh = JsonConvert.DeserializeObject<MED_ANESTHESIA_PLAN_PMH>(value);
                    }

                    MED_ANESTHESIA_PLAN_PMH curDbAnesPlanPmh = this.GetAnesthesiaPlanPMH(anesPlanPmh.PATIENT_ID,
                                                                                         anesPlanPmh.VISIT_ID,
                                                                                         anesPlanPmh.OPER_ID);
                    this.SaveModel<MED_ANESTHESIA_PLAN_PMH>(originalAnesPlanPmh, anesPlanPmh, curDbAnesPlanPmh);
                }

                if (dyParams.operAnalgesicMaster != null)
                {
                    string value = dyParams.operAnalgesicMaster.ToString();
                    operAnalgesicMaster = JsonConvert.DeserializeObject<MED_OPERATION_ANALGESIC_MASTER>(value);
                    if (dyParams.originalOperAnalgesicMaster != null)
                    {
                        value = dyParams.originalOperAnalgesicMaster.ToString();
                        originalOperAnalgesicMaster = JsonConvert.DeserializeObject<MED_OPERATION_ANALGESIC_MASTER>(value);
                    }

                    MED_OPERATION_ANALGESIC_MASTER curDbOperAnalMaster = this.GetAnalgesicMaster(operAnalgesicMaster.PATIENT_ID,
                                                                                                 operAnalgesicMaster.VISIT_ID,
                                                                                                 operAnalgesicMaster.OPER_ID);
                    this.SaveModel<MED_OPERATION_ANALGESIC_MASTER>(originalOperAnalgesicMaster,
                                                                   operAnalgesicMaster,
                                                                   curDbOperAnalMaster);
                }

                if (dyParams.safetyChecks != null)
                {
                    string value = dyParams.safetyChecks.ToString();
                    safetyChecks = JsonConvert.DeserializeObject<MED_SAFETY_CHECKS>(value);
                    if (dyParams.originalSafetyChecks != null)
                    {
                        value = dyParams.originalSafetyChecks.ToString();
                        originalSafetyChecks = JsonConvert.DeserializeObject<MED_SAFETY_CHECKS>(value);
                    }

                    MED_SAFETY_CHECKS curDbSafetyChecks = this.GetSafetyCheckData(safetyChecks.PATIENT_ID,
                                                                                  safetyChecks.VISIT_ID,
                                                                                  safetyChecks.OPER_ID).First();
                    this.SaveModel<MED_SAFETY_CHECKS>(originalSafetyChecks, safetyChecks, curDbSafetyChecks);
                }

                if (dyParams.operRiskEstimate != null)
                {
                    string value = dyParams.operRiskEstimate.ToString();
                    operRiskEstimate = JsonConvert.DeserializeObject<MED_OPER_RISK_ESTIMATE>(value);
                    if (dyParams.originalOperRiskEstimate != null)
                    {
                        value = dyParams.originalOperRiskEstimate.ToString();
                        originalOperRiskEstimate = JsonConvert.DeserializeObject<MED_OPER_RISK_ESTIMATE>(value);
                    }

                    MED_OPER_RISK_ESTIMATE curOperRiskEstimate = this.GetRickEstimate(operRiskEstimate.PATIENT_ID,
                                                                                      operRiskEstimate.VISIT_ID,
                                                                                      operRiskEstimate.OPER_ID);
                    this.SaveModel<MED_OPER_RISK_ESTIMATE>(originalOperRiskEstimate, operRiskEstimate, curOperRiskEstimate);
                }

                if (dyParams.operAnalgesicMedicine != null)
                {
                    string value = dyParams.operAnalgesicMedicine.ToString();
                    operAnalgesicMedicine = JsonConvert.DeserializeObject<List<MED_OPER_ANALGESIC_MEDICINE>>(value);
                    this.UpdateWholeList(operAnalgesicMedicine);
                }

                if (dyParams.operAnalgesicTotal != null)
                {
                    string value = dyParams.operAnalgesicTotal.ToString();
                    operAnalgesicTotal = JsonConvert.DeserializeObject<List<MED_OPER_ANALGESIC_TOTAL>>(value);
                    this.UpdateWholeList(operAnalgesicTotal);
                }

                if (dyParams.operExtended != null)
                {
                    string value = dyParams.operExtended.ToString();
                    operExtended = JsonConvert.DeserializeObject<List<MED_OPERATION_EXTENDED>>(value);
                    if (dyParams.originalOperExtended != null)
                    {
                        value = dyParams.originalOperExtended.ToString();
                        originalOperExtended = JsonConvert.DeserializeObject<List<MED_OPERATION_EXTENDED>>(value);
                    }

                    this.SaveModelList<MED_OPERATION_EXTENDED>(originalOperExtended, operExtended);
                    this.UpdateWholeList(operExtended);
                }

                if (dyParams.postExtended != null)
                {
                    string value = dyParams.postExtended.ToString();
                    postExtended = JsonConvert.DeserializeObject<List<MED_POSTOPERATIVE_EXTENDED>>(value);
                    if (dyParams.originalPostExtended != null)
                    {
                        value = dyParams.originalPostExtended.ToString();
                        originalPostExtended = JsonConvert.DeserializeObject<List<MED_POSTOPERATIVE_EXTENDED>>(value);
                    }

                    this.SaveModelList<MED_POSTOPERATIVE_EXTENDED>(originalPostExtended, postExtended);
                    this.UpdateWholeList(postExtended);
                }

                if (dyParams.preExpansion != null)
                {
                    string value = dyParams.preExpansion.ToString();
                    preExpansion = JsonConvert.DeserializeObject<List<MED_PREOPERATIVE_EXPANSION>>(value);
                    if (dyParams.originalPreExpansion != null)
                    {
                        value = dyParams.originalPreExpansion.ToString();
                        originalPreExpansion = JsonConvert.DeserializeObject<List<MED_PREOPERATIVE_EXPANSION>>(value);
                    }

                    this.SaveModelList<MED_PREOPERATIVE_EXPANSION>(originalPreExpansion, preExpansion);
                    this.UpdateWholeList(preExpansion);
                }

                dapper.SaveChanges();
            }
            catch (Exception)
            {
                Result = false;
            }

            return Result;
        }

        public object GetPropertyValue(object classInstance, string propertyName)
        {
            return classInstance.GetType().InvokeMember(propertyName, BindingFlags.GetProperty, null, classInstance, new object[] { });
        }

        [HttpPost]
        public virtual bool SaveDocDataPars(DocDataPars docData)
        {
            bool result = true;
            try
            {
                if (null != docData.OperMaster)
                {
                    MED_OPERATION_MASTER curDbOperMaster = this.GetOperationMaster(docData.OperMaster.PATIENT_ID,
                                                                                   docData.OperMaster.VISIT_ID,
                                                                                   docData.OperMaster.OPER_ID);
                    this.SaveModel<MED_OPERATION_MASTER>(docData.OriginalOperMaster, docData.OperMaster, curDbOperMaster);
                }

                if (null != docData.OperMasterExt)
                {
                    MED_OPERATION_MASTER_EXT curDbOperMasterExt = this.GetOperationMasterExt(docData.OperMasterExt.PATIENT_ID,
                                                                                             docData.OperMasterExt.VISIT_ID,
                                                                                             docData.OperMasterExt.OPER_ID);
                    this.SaveModel<MED_OPERATION_MASTER_EXT>(docData.OriginalOperMasterExt, docData.OperMasterExt, curDbOperMasterExt);
                }

                if (null != docData.PatMasterIndex)
                {
                    MED_PAT_MASTER_INDEX curDbPatMasterIndex = this.GetPatMasterIndex(docData.PatMasterIndex.PATIENT_ID);
                    this.SaveModel<MED_PAT_MASTER_INDEX>(docData.OriginalPatMasterIndex, docData.PatMasterIndex, curDbPatMasterIndex);
                }

                if (null != docData.PatVisit)
                {
                    MED_PAT_VISIT curDbPatVisit = this.GetPatVisit(docData.PatVisit.PATIENT_ID, docData.PatVisit.VISIT_ID);
                    this.SaveModel<MED_PAT_VISIT>(docData.OriginalPatVisit, docData.PatVisit, curDbPatVisit);
                }

                if (null != docData.PatsInHospital)
                {
                    MED_PATS_IN_HOSPITAL curDbPatsInHospital = this.GetPatsInHospital(docData.PatsInHospital.PATIENT_ID,
                                                                                      docData.PatsInHospital.VISIT_ID);
                    this.SaveModel<MED_PATS_IN_HOSPITAL>(docData.OriginalPatsInHospital, docData.PatsInHospital, curDbPatsInHospital);
                }

                if (null != docData.AnesPlan)
                {
                    MED_ANESTHESIA_PLAN curDbAnesPlan = this.GetAnesthesiaPlan(docData.AnesPlan.PATIENT_ID,
                                                                               docData.AnesPlan.VISIT_ID,
                                                                               docData.AnesPlan.OPER_ID);
                    this.SaveModel<MED_ANESTHESIA_PLAN>(docData.OriginalAnesPlan, docData.AnesPlan, curDbAnesPlan);
                }

                if (null != docData.AnesPlanExam)
                {
                    MED_ANESTHESIA_PLAN_EXAM curDbAnesPlanExam = this.GetAnesthesiaPlanEXAM(docData.AnesPlanExam.PATIENT_ID,
                                                                                            docData.AnesPlanExam.VISIT_ID,
                                                                                            docData.AnesPlanExam.OPER_ID);
                    this.SaveModel<MED_ANESTHESIA_PLAN_EXAM>(docData.OriginalAnesPlanExam, docData.AnesPlanExam, curDbAnesPlanExam);
                }

                if (null != docData.AnesPlanPmh)
                {
                    MED_ANESTHESIA_PLAN_PMH curDbAnesPlanPmh = this.GetAnesthesiaPlanPMH(docData.AnesPlanPmh.PATIENT_ID,
                                                                                         docData.AnesPlanPmh.VISIT_ID,
                                                                                         docData.AnesPlanPmh.OPER_ID);
                    this.SaveModel<MED_ANESTHESIA_PLAN_PMH>(docData.OriginalAnesPlanPmh, docData.AnesPlanPmh, curDbAnesPlanPmh);
                }

                if (null != docData.AnesInputData)
                {
                    MED_ANESTHESIA_INPUT_DATA curDbAnesInputData = this.GetAnesthestaInputData(docData.AnesInputData.PATIENT_ID,
                                                                                               docData.AnesInputData.VISIT_ID,
                                                                                               docData.AnesInputData.OPER_ID);
                    this.SaveModel<MED_ANESTHESIA_INPUT_DATA>(docData.OriginalAnesInputData,
                                                              docData.AnesInputData,
                                                              curDbAnesInputData);
                }

                if (null != docData.OperAnalgesicMaster)
                {
                    MED_OPERATION_ANALGESIC_MASTER curDbOperAnalMaster = this.GetAnalgesicMaster(docData.OperAnalgesicMaster.PATIENT_ID,
                                                                                                 docData.OperAnalgesicMaster.VISIT_ID,
                                                                                                 docData.OperAnalgesicMaster.OPER_ID);
                    this.SaveModel<MED_OPERATION_ANALGESIC_MASTER>(docData.OriginalOperAnalgesicMaster,
                                                                   docData.OperAnalgesicMaster,
                                                                   curDbOperAnalMaster);
                }

                if (null != docData.SafetyChecks)
                {
                    MED_SAFETY_CHECKS curDbSafetyChecks = this.GetSafetyCheckData(docData.SafetyChecks.PATIENT_ID,
                                                                                  docData.SafetyChecks.VISIT_ID,
                                                                                  docData.SafetyChecks.OPER_ID).First();
                    this.SaveModel<MED_SAFETY_CHECKS>(docData.OriginalSafetyChecks, docData.SafetyChecks, curDbSafetyChecks);
                }

                if (null != docData.OperRiskEstimate)
                {
                    MED_OPER_RISK_ESTIMATE curOperRiskEstimate = this.GetRickEstimate(docData.OperRiskEstimate.PATIENT_ID,
                                                                                      docData.OperRiskEstimate.VISIT_ID,
                                                                                      docData.OperRiskEstimate.OPER_ID);
                    this.SaveModel<MED_OPER_RISK_ESTIMATE>(docData.OriginalOperRiskEstimate,
                                                           docData.OperRiskEstimate,
                                                           curOperRiskEstimate);
                }

                if (null != docData.AnesRecover)
                {
                    MED_ANESTHESIA_RECOVER curAnesRecover = this.GetAnesRecoverData(docData.AnesRecover.PATIENT_ID,
                                                                                    docData.AnesRecover.VISIT_ID,
                                                                                    docData.AnesRecover.OPER_ID);
                    this.SaveModel<MED_ANESTHESIA_RECOVER>(docData.OriginalAnesRecover, docData.AnesRecover, curAnesRecover);
                }

                if (null != docData.AnesInquiry)
                {
                    MED_ANESTHESIA_INQUIRY curAnesInquiry = this.GetAnesInquiry(docData.AnesInquiry.PATIENT_ID,
                                                                                docData.AnesInquiry.VISIT_ID,
                                                                                docData.AnesInquiry.OPER_ID).First();
                    this.SaveModel<MED_ANESTHESIA_INQUIRY>(docData.OriginalAnesInquiry, docData.AnesInquiry, curAnesInquiry);
                }

                if (null != docData.OperExtended)
                {
                    this.SaveModelList<MED_OPERATION_EXTENDED>(docData.OriginalOperExtended, docData.OperExtended);
                    this.UpdateWholeList(docData.OperExtended);
                }

                if (null != docData.PostExtended)
                {
                    this.SaveModelList<MED_POSTOPERATIVE_EXTENDED>(docData.OriginalPostExtended, docData.PostExtended);
                    this.UpdateWholeList(docData.PostExtended);
                }

                if (null != docData.PreExpansion)
                {
                    this.SaveModelList<MED_PREOPERATIVE_EXPANSION>(docData.OriginalPreExpansion, docData.PreExpansion);
                    this.UpdateWholeList(docData.PreExpansion);
                }

                // 普通的List数据无需比对原始数据
                if (null != docData.PacuSorce)
                {
                    this.UpdateWholeList(docData.PacuSorce);
                }

                if (null != docData.ChuFangRecord)
                {
                    this.UpdateWholeList(docData.ChuFangRecord);
                }

                if (null != docData.OperAnalgesicMedicine)
                {
                    this.UpdateWholeList(docData.OperAnalgesicMedicine);
                }

                if (null != docData.OperAnalgesicTotal)
                {
                    this.UpdateWholeList(docData.OperAnalgesicTotal);
                }

                dapper.SaveChanges();
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        }
    }
}

