using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
//using MedicalSystem.AnesWorkStation.Domain.AnesQuery;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using MedicalSystem.AnesWorkStation.Domain.ViewModule;
using MedicalSystem.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.AccessControl;
using System.Runtime.InteropServices;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 护理管理接口
    /// </summary>
    public interface IPlatformNurseManageService
    {
        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <param name="model">查询条件</param>
        /// <returns></returns>
        List<dynamic> GetPatientInfoList(OperQueryParaModel model);
        /// <summary>
        /// 获取人员详情
        /// </summary>
        /// <param name="PATIENTID">PATIENTID</param>
        /// <param name="VISITID">VISITID</param>
        /// <param name="OPERID">OPERID</param>
        /// <returns></returns>
        dynamic GetPatientDetailInfo(string PATIENTID, string VISITID, string OPERID);

        /// <summary>
        /// 保存术前自定义表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        int SaveMedPreoperativeExpansion(List<MED_PREOPERATIVE_EXPANSION> list);

        /// <summary>
        /// 保存术中自定义表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        int SaveMedPostoperaticeExtended(List<MED_POSTOPERATIVE_EXTENDED> list);

        /// <summary>
        /// 保存术后自定义表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        int SaveMedOperationExtended(List<MED_OPERATION_EXTENDED> list);
        /// <summary>
        /// 获取自定义数据
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="PATIENTID">PATIENTID</param>
        /// <param name="VISITID">VISITID</param>
        /// <param name="OPERID">OPERID</param>
        /// <returns></returns>
        dynamic GetCustomData(string TableName, string PATIENTID, string VISITID, string OPERID);
        /// <summary>
        /// 获取文书绑定数据
        /// </summary>
        /// <param name="PATIENTID">PATIENTID</param>
        /// <param name="VISITID">VISITID</param>
        /// <param name="OPERID">OPERID</param>
        /// <returns></returns>
        MedicalBasicDoc QueryMedicalBasicDoc(string PATIENTID, int VISITID, int OPERID, string StatusType, string DocName);

        /// <summary>
        /// 批量保存文书 数据
        /// </summary>
        /// <param name="basicData"></param>
        /// <returns></returns>
        int SaveMedicalBasicDoc(MedicalBasicDoc basicData);
        /// <summary>
        /// 获取字典数据
        /// </summary>
        /// <param name="data">data</param>
        /// <returns></returns>
        dynamic GetDicData(dynamic data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DeptName"></param>
        /// <returns></returns>
        IList<MED_DEPT_DICT> GetMedDeptInOperRoomDict(string DeptName);
        /// <summary>
        /// 上传pdf文书
        /// </summary>
        /// <param name="PDFobj">PDFobj</param>
        /// <returns></returns>
        int PDFUpload(dynamic PDFobj);

        /// <summary>
        /// 获取字典
        /// </summary>
        /// <param name="itemClass"></param>
        /// <returns></returns>
        IList<MED_ANESTHESIA_INPUT_DICT> GetAnesInputDict(string itemClass);

        /// <summary>
        /// 获取排班数据
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        MED_OPERATION_SCHEDULE GetOperationSchedule(string patientID, decimal visitID, decimal operID);

        int CancelOperationSchedule(OperCancelAndDetailEntity operationCanceled);

        List<AnesDocumentPDFSrcEntity> GetUnUploadPatientInfos(OperQueryParaModel model);


    }
    /// <summary>
    /// 护理管理接口
    /// </summary>
    public class PlatformNurseManageService : BaseService<PlatformNurseManageService>, IPlatformNurseManageService
    {
        IPlatformSysConfigServices sysConfigService;

        ICommonService commonService;

        protected PlatformNurseManageService()
            : base() { }
        public PlatformNurseManageService(IDapperContext context, IPlatformSysConfigServices sysConfigServicesParam, ICommonService commonServiceParam)
            : base(context)
        {
            sysConfigService = sysConfigServicesParam;
            commonService = commonServiceParam;
        }

        [DllImport("EMRFSRVS.dll")]
        protected static extern int putfile(string host_addr, string local_file, string remote_file, int Protocol, int option);


        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <param name="model">查询条件</param>
        /// <returns></returns>
        public List<dynamic> GetPatientInfoList(OperQueryParaModel model)
        {
            string sql = sqlDict.GetSQLByKey("GetPatientInfoList");
            DateTime? startTime = null;
            DateTime? endTime = null;
            if (!string.IsNullOrWhiteSpace(model.StartDate))
            {
                startTime = Convert.ToDateTime(model.StartDate);
                endTime = Convert.ToDateTime(model.EndDate).AddDays(1);
            }
            List<dynamic> list = dapper.Set<dynamic>().Query(sql, new
            {
                model.PatName,
                model.InpNo,
                model.AnesDoctor,
                model.OperDept,
                model.OperRoomNo,
                StartDate = startTime,
                EndDate = endTime,
            });

            List<dynamic> returnList = new List<dynamic>();

            if (model.Status == "术前")
            {
                returnList = list.FindAll(d => d.OPER_STATUS_CODE < 5);
            }
            else if (model.Status == "术中")
            {
                returnList = list.FindAll(d => d.OPER_STATUS_CODE >= 5 && d.OPER_STATUS_CODE < 35);
            }
            else if (model.Status == "术后")
            {
                returnList = list.FindAll(d => d.OPER_STATUS_CODE >= 35);
            }
            else
            {
                returnList = list.FindAll(d => d.OPER_STATUS_CODE >= 0);
            }


            if (model.EMERGENCY_IND != -1)//急诊择期
            {
                returnList = returnList.FindAll(d => d.EMERGENCY_IND == model.EMERGENCY_IND);
            }


            return returnList;
        }
        /// <summary>
        /// 获取人员详情
        /// </summary>
        /// <param name="PATIENTID">PATIENTID</param>
        /// <param name="VISITID">VISITID</param>
        /// <param name="OPERID">OPERID</param>
        /// <returns></returns>
        public dynamic GetPatientDetailInfo(string PATIENTID, string VISITID, string OPERID)
        {
            string sql = sqlDict.GetSQLByKey("GetPatientDetailInfo");
            return dapper.Set<dynamic>().Query(sql, new
            {
                PatientId = PATIENTID,
                VisitId = VISITID,
                OperId = OPERID
            }).Find(d => 1 == 1);
        }
        /// <summary>
        /// 保存术前自定义表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveMedPreoperativeExpansion(List<MED_PREOPERATIVE_EXPANSION> list)
        {
            //if(list.Count>0)
            //{ 
            //List<MED_PREOPERATIVE_EXPANSION> configList = dapper.Set<MED_PREOPERATIVE_EXPANSION>().Select(p=>p.PATIENT_ID== list[0].PATIENT_ID &&p.VISIT_ID==list[0].VISIT_ID&&);
            //}

            int result = dapper.Set<MED_PREOPERATIVE_EXPANSION>().Update(list) > 0 ? 1 : 0;
            dapper.SaveChanges();
            return result;
        }
        /// <summary>
        /// 保存术中自定义表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int SaveMedPostoperaticeExtended(List<MED_POSTOPERATIVE_EXTENDED> list)
        {
            int result = dapper.Set<MED_POSTOPERATIVE_EXTENDED>().Save(list) > 0 ? 1 : 0;
            dapper.SaveChanges();
            return result;
        }
        /// <summary>
        /// 保存术后自定义表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int SaveMedOperationExtended(List<MED_OPERATION_EXTENDED> list)
        {
            int result = dapper.Set<MED_OPERATION_EXTENDED>().Update(list) > 0 ? 1 : 0;
            dapper.SaveChanges();
            return result;
        }
        /// <summary>
        /// 获取自定义数据
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="PATIENTID">PATIENTID</param>
        /// <param name="VISITID">VISITID</param>
        /// <param name="OPERID">OPERID</param>
        /// <returns></returns>
        public dynamic GetCustomData2(string TableName, string PATIENTID, string VISITID, string OPERID)
        {
            string sql = string.Format("SELECT ITEM_NAME FROM {0} WHERE PATIENT_ID=:PATIENTID AND VISIT_ID=:VISITID AND OPER_ID=:OPERID", TableName);

            StringBuilder columnStr = new StringBuilder();
            List<dynamic> columnobj = dapper.Query(sql, new
            {
                PATIENTID,
                VISITID,
                OPERID
            });
            foreach (var item in columnobj)
            {
                columnStr.Append(",'" + item.ITEM_NAME + "' " + item.ITEM_NAME.Replace(".", "__"));
            }

            if (columnobj.Count > 0)
            {
                string sql2 = string.Format("select * from (SELECT item_name,item_value FROM {0} where PATIENT_ID=:PATIENTID AND VISIT_ID=:VISITID AND OPER_ID=:OPERID) pivot (max(item_value) for item_name in ({1}))", TableName, columnStr.ToString().TrimStart(','));
                return dapper.Set<dynamic>().Query(sql2, new
                {
                    PATIENTID,
                    VISITID,
                    OPERID
                }).Find(d => 1 == 1);

            }
            return null;
        }

        /// <summary>
        /// 获取自定义数据
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="PATIENTID">PATIENTID</param>
        /// <param name="VISITID">VISITID</param>
        /// <param name="OPERID">OPERID</param>
        /// <returns></returns>
        public dynamic GetCustomData(string TableName, string PATIENTID, string VISITID, string OPERID)
        {
            string sql = string.Format("SELECT * FROM {0} WHERE PATIENT_ID=:PATIENTID AND VISIT_ID=:VISITID AND OPER_ID=:OPERID", TableName);

            List<dynamic> list = dapper.Query(sql, new
            {
                PATIENTID,
                VISITID,
                OPERID
            });


            DataTable table = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(list));


            DataTable dt = new DataTable();

            foreach (DataRow item in table.Rows)
            {

                string itemName = item["ITEM_NAME"].ToString();

                if (!string.IsNullOrEmpty(itemName))
                {
                    dt.Columns.Add(itemName.Replace(".", "__"), typeof(string));
                }
            }


            if (dt.Columns.Count > 0)
            {
                DataRow dr = dt.NewRow();

                foreach (DataColumn item in dt.Columns)
                {
                    var columnName = item.ColumnName.Replace("__", ".");


                    DataRow[] findRows = table.Select("ITEM_NAME = '" + columnName + "'");

                    if (findRows != null && findRows.Length > 0)
                    {
                        dr[item.ColumnName] = findRows[0]["ITEM_VALUE"];
                    }
                }

                dt.Rows.Add(dr);

                return JsonConvert.DeserializeObject<List<dynamic>>(JsonConvert.SerializeObject(dt)).Find(d => 1 == 1);
            }

            return null;
        }

        public MED_ANESTHESIA_PLAN GetMedAnesthesiaPlan(string PATIENTID, int VISITID, int OPERID)
        {
            MED_ANESTHESIA_PLAN anesPlan = dapper.Set<MED_ANESTHESIA_PLAN>().Single(d => d.PATIENT_ID == PATIENTID && d.VISIT_ID == VISITID && d.OPER_ID == OPERID);
            if (anesPlan == null)
            {
                anesPlan = new MED_ANESTHESIA_PLAN()
                {
                    PATIENT_ID = PATIENTID,
                    VISIT_ID = VISITID,
                    OPER_ID = OPERID
                };

                dapper.Set<MED_ANESTHESIA_PLAN>().Insert(anesPlan);
                dapper.SaveChanges();
                anesPlan = dapper.Set<MED_ANESTHESIA_PLAN>().Single(d => d.PATIENT_ID == PATIENTID && d.VISIT_ID == VISITID && d.OPER_ID == OPERID);
            }

            return anesPlan;
        }

        public MED_ANESTHESIA_PLAN_PMH GetMedAnesthesiaPlanPmh(string PATIENTID, int VISITID, int OPERID)
        {
            MED_ANESTHESIA_PLAN_PMH anesPlanPmh = dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Single(d => d.PATIENT_ID == PATIENTID && d.VISIT_ID == VISITID && d.OPER_ID == OPERID);

            if (anesPlanPmh == null)
            {
                anesPlanPmh = new MED_ANESTHESIA_PLAN_PMH()
                {
                    PATIENT_ID = PATIENTID,
                    VISIT_ID = VISITID,
                    OPER_ID = OPERID
                };

                dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Insert(anesPlanPmh);
                dapper.SaveChanges();
                anesPlanPmh = dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Single(d => d.PATIENT_ID == PATIENTID && d.VISIT_ID == VISITID && d.OPER_ID == OPERID);
            }

            return anesPlanPmh;
        }

        public MED_ANESTHESIA_PLAN_EXAM GetMedAnesthesiaPlanExam(string PATIENTID, int VISITID, int OPERID)
        {
            MED_ANESTHESIA_PLAN_EXAM anesPlanExam = dapper.Set<MED_ANESTHESIA_PLAN_EXAM>().Single(d => d.PATIENT_ID == PATIENTID && d.VISIT_ID == VISITID && d.OPER_ID == OPERID);
            if (anesPlanExam == null)
            {
                anesPlanExam = new MED_ANESTHESIA_PLAN_EXAM()
                {
                    PATIENT_ID = PATIENTID,
                    VISIT_ID = VISITID,
                    OPER_ID = OPERID
                };

                dapper.Set<MED_ANESTHESIA_PLAN_EXAM>().Insert(anesPlanExam);
                dapper.SaveChanges();
                anesPlanExam = dapper.Set<MED_ANESTHESIA_PLAN_EXAM>().Single(d => d.PATIENT_ID == PATIENTID && d.VISIT_ID == VISITID && d.OPER_ID == OPERID);
            }

            return anesPlanExam;
        }

        public MED_ANESTHESIA_RECOVER GetMedAnesthesiaRecover(string PATIENTID, int VISITID, int OPERID)
        {
            MED_ANESTHESIA_RECOVER anesRecover = dapper.Set<MED_ANESTHESIA_RECOVER>().Single(d => d.PATIENT_ID == PATIENTID && d.VISIT_ID == VISITID && d.OPER_ID == OPERID);
            if (null == anesRecover)
            {
                anesRecover = new MED_ANESTHESIA_RECOVER
                {
                    PATIENT_ID = PATIENTID,
                    VISIT_ID = VISITID,
                    OPER_ID = OPERID
                };

                dapper.Set<MED_ANESTHESIA_RECOVER>().Insert(anesRecover);
                dapper.SaveChanges();
                anesRecover = dapper.Set<MED_ANESTHESIA_RECOVER>().Single(d => d.PATIENT_ID == PATIENTID && d.VISIT_ID == VISITID && d.OPER_ID == OPERID);
            }

            return anesRecover;
        }

        public MED_ANESTHESIA_INQUIRY GetMedAnesthesiaInquiry(string PATIENTID, int VISITID, int OPERID)
        {
            MED_ANESTHESIA_INQUIRY anesInquiry = dapper.Set<MED_ANESTHESIA_INQUIRY>().Single(d => d.PATIENT_ID == PATIENTID && d.VISIT_ID == VISITID && d.OPER_ID == OPERID);
            if (null == anesInquiry)
            {
                anesInquiry = new MED_ANESTHESIA_INQUIRY
                {
                    PATIENT_ID = PATIENTID,
                    VISIT_ID = VISITID,
                    OPER_ID = OPERID,
                    INQUIRY_NO = 1
                };

                dapper.Set<MED_ANESTHESIA_INQUIRY>().Insert(anesInquiry);
                dapper.SaveChanges();
                anesInquiry = dapper.Set<MED_ANESTHESIA_INQUIRY>().Single(d => d.PATIENT_ID == PATIENTID && d.VISIT_ID == VISITID && d.OPER_ID == OPERID);
            }

            return anesInquiry;
        }

        public MED_SAFETY_CHECKS GetMedSafetyChecks(string PATIENTID, int VISITID, int OPERID)
        {
            MED_SAFETY_CHECKS safetyChecks = dapper.Set<MED_SAFETY_CHECKS>().Single(d => d.PATIENT_ID == PATIENTID && d.VISIT_ID == VISITID && d.OPER_ID == OPERID);
            if (safetyChecks == null)
            {
                safetyChecks = new MED_SAFETY_CHECKS()
                {
                    PATIENT_ID = PATIENTID,
                    VISIT_ID = VISITID,
                    OPER_ID = OPERID
                };
                dapper.Set<MED_SAFETY_CHECKS>().Insert(safetyChecks);
                dapper.SaveChanges();
                safetyChecks = dapper.Set<MED_SAFETY_CHECKS>().Single(d => d.PATIENT_ID == PATIENTID && d.VISIT_ID == VISITID && d.OPER_ID == OPERID);
            }

            return safetyChecks;
        }

        public MED_PRESSUREESTIMATE_DOC GetMedPressureEstimateDoc(string PATIENTID, int VISITID, int OPERID)
        {
            MED_PRESSUREESTIMATE_DOC result = dapper.Set<MED_PRESSUREESTIMATE_DOC>().Single(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            if(null == result)
            {
                result = new MED_PRESSUREESTIMATE_DOC() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID};
                dapper.Set<MED_PRESSUREESTIMATE_DOC>().Insert(result);
                dapper.SaveChanges();
                result = dapper.Set<MED_PRESSUREESTIMATE_DOC>().Single(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            }

            return result;
        }

        public MED_PAT_VISIT GetMedPatVisit(string PATIENTID, int VISITID)
        {
            MED_PAT_VISIT patVisit = dapper.Set<MED_PAT_VISIT>().Single(d => d.PATIENT_ID == PATIENTID && d.VISIT_ID == VISITID);
            if (patVisit == null)
            {
                patVisit = new MED_PAT_VISIT()
                {
                    PATIENT_ID = PATIENTID,
                    VISIT_ID = VISITID
                };

                dapper.Set<MED_PAT_VISIT>().Insert(patVisit);
                dapper.SaveChanges();
                patVisit = dapper.Set<MED_PAT_VISIT>().Single(d => d.PATIENT_ID == PATIENTID && d.VISIT_ID == VISITID);
            }

            return patVisit;
        }

        public MED_NURSING_AFTER GetMedNursingAfter(string PATIENTID, int VISITID, int OPERID)
        {
            MED_NURSING_AFTER result = dapper.Set<MED_NURSING_AFTER>().Single(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            if(result == null)
            {
                result = new MED_NURSING_AFTER
                {
                    PATIENT_ID = PATIENTID,
                    VISIT_ID = VISITID,
                    OPER_ID = OPERID
                };

                dapper.Set<MED_NURSING_AFTER>().Insert(result);
                dapper.SaveChanges();
                result = dapper.Set<MED_NURSING_AFTER>().Single(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            }

            return result;
        }

        public MED_NURSING_AFTERSHIFT_PACU GetMedNursingAfterShiftPacu(string PATIENTID, int VISITID, int OPERID)
        {
            MED_NURSING_AFTERSHIFT_PACU result = dapper.Set<MED_NURSING_AFTERSHIFT_PACU>().Single(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            if (result == null)
            {
                result = new MED_NURSING_AFTERSHIFT_PACU
                {
                    PATIENT_ID = PATIENTID,
                    VISIT_ID = VISITID,
                    OPER_ID = OPERID
                };

                dapper.Set<MED_NURSING_AFTERSHIFT_PACU>().Insert(result);
                dapper.SaveChanges();
                result = dapper.Set<MED_NURSING_AFTERSHIFT_PACU>().Single(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            }

            return result;
        }

        public MED_NURSING_AFTERSHIFT_WARD GetMedNursingAfterShiftWard(string PATIENTID, int VISITID, int OPERID)
        {
            MED_NURSING_AFTERSHIFT_WARD result = dapper.Set<MED_NURSING_AFTERSHIFT_WARD>().Single(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            if (result == null)
            {
                result = new MED_NURSING_AFTERSHIFT_WARD
                {
                    PATIENT_ID = PATIENTID,
                    VISIT_ID = VISITID,
                    OPER_ID = OPERID
                };

                dapper.Set<MED_NURSING_AFTERSHIFT_WARD>().Insert(result);
                dapper.SaveChanges();
                result = dapper.Set<MED_NURSING_AFTERSHIFT_WARD>().Single(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            }

            return result;
        }

        public MED_NURSING_BEFOREASSESS GetMedNursingBeforeAssess(string PATIENTID, int VISITID, int OPERID)
        {
            MED_NURSING_BEFOREASSESS result = dapper.Set<MED_NURSING_BEFOREASSESS>().Single(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            if (result == null)
            {
                result = new MED_NURSING_BEFOREASSESS
                {
                    PATIENT_ID = PATIENTID,
                    VISIT_ID = VISITID,
                    OPER_ID = OPERID
                };

                dapper.Set<MED_NURSING_BEFOREASSESS>().Insert(result);
                dapper.SaveChanges();
                result = dapper.Set<MED_NURSING_BEFOREASSESS>().Single(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            }

            return result;
        }

        public MED_NURSING_BEFORESHIFT GetMedNursingBeforeShift(string PATIENTID, int VISITID, int OPERID)
        {
            MED_NURSING_BEFORESHIFT result = dapper.Set<MED_NURSING_BEFORESHIFT>().Single(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            if (result == null)
            {
                result = new MED_NURSING_BEFORESHIFT
                {
                    PATIENT_ID = PATIENTID,
                    VISIT_ID = VISITID,
                    OPER_ID = OPERID
                };

                dapper.Set<MED_NURSING_BEFORESHIFT>().Insert(result);
                dapper.SaveChanges();
                result = dapper.Set<MED_NURSING_BEFORESHIFT>().Single(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            }

            return result;
        }

        public MED_NURSING_QDNURSE GetMedNursingQdNurse(string PATIENTID, int VISITID, int OPERID)
        {
            MED_NURSING_QDNURSE result = dapper.Set<MED_NURSING_QDNURSE>().Single(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            if (result == null)
            {
                result = new MED_NURSING_QDNURSE
                {
                    PATIENT_ID = PATIENTID,
                    VISIT_ID = VISITID,
                    OPER_ID = OPERID
                };

                dapper.Set<MED_NURSING_QDNURSE>().Insert(result);
                dapper.SaveChanges();
                result = dapper.Set<MED_NURSING_QDNURSE>().Single(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            }

            return result;
        }

        public List<MED_NURSING_TOUR> GetMedNursingTour(string PATIENTID, int VISITID, int OPERID)
        {
            List<MED_NURSING_TOUR> result = dapper.Set<MED_NURSING_TOUR>().Select(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            if (result == null || result.Count == 0)
            {
                result = new List<MED_NURSING_TOUR>();
                for (int i = 1; i <= 8; i++)
                {
                    result.Add(new MED_NURSING_TOUR() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = i });
                }

                dapper.Set<MED_NURSING_TOUR>().Insert(result);
                dapper.SaveChanges();
                result = dapper.Set<MED_NURSING_TOUR>().Select(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            }

            List<MED_HIS_USERS> user = dapper.Set<MED_HIS_USERS>().Select(x => x.USER_JOB == "护士");
            result.ForEach(x =>
            {
                if(!string.IsNullOrEmpty(x.NURSE) && null != user.SingleOrDefault(u => u.USER_JOB_ID == x.NURSE))
                {
                    x.NURSE_NAME = user.SingleOrDefault(u => u.USER_JOB_ID == x.NURSE).USER_NAME;
                }
            });

            return result;
        }

        public MED_NURSING_YWASSESS GetMedNursingYwAssess(string PATIENTID, int VISITID, int OPERID)
        {
            MED_NURSING_YWASSESS result = dapper.Set<MED_NURSING_YWASSESS>().Single(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            if (result == null)
            {
                result = new MED_NURSING_YWASSESS
                {
                    PATIENT_ID = PATIENTID,
                    VISIT_ID = VISITID,
                    OPER_ID = OPERID
                };

                dapper.Set<MED_NURSING_YWASSESS>().Insert(result);
                dapper.SaveChanges();
                result = dapper.Set<MED_NURSING_YWASSESS>().Single(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            }

            return result;
        }

        public List<MED_NURSING_QINGDIAN> GetMedNursingQingDian(string PATIENTID, int VISITID, int OPERID)
        {
            List<MED_NURSING_QINGDIAN> result = dapper.Set<MED_NURSING_QINGDIAN>().Select(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            if(result == null || result.Count == 0)
            {
                result = new List<MED_NURSING_QINGDIAN>();
                result.Add(new MED_NURSING_QINGDIAN() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = 1, ITEM_NAME1="巾钳", ITEM_NAME2="缝针"});
                result.Add(new MED_NURSING_QINGDIAN() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = 2, ITEM_NAME1 = "蚊式钳", ITEM_NAME2 = "长条纱布" });
                result.Add(new MED_NURSING_QINGDIAN() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = 3, ITEM_NAME1 = "血管钳", ITEM_NAME2 = "盐水垫" });
                result.Add(new MED_NURSING_QINGDIAN() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = 4, ITEM_NAME1 = "持针器", ITEM_NAME2 = "大纱布" });
                result.Add(new MED_NURSING_QINGDIAN() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = 5, ITEM_NAME1 = "组织钳", ITEM_NAME2 = "小纱布" });
                result.Add(new MED_NURSING_QINGDIAN() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = 6, ITEM_NAME1 = "库克", ITEM_NAME2 = "棉球" });
                result.Add(new MED_NURSING_QINGDIAN() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = 7, ITEM_NAME1 = "剪刀", ITEM_NAME2 = "脑棉" });
                result.Add(new MED_NURSING_QINGDIAN() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = 8, ITEM_NAME1 = "刀柄", ITEM_NAME2 = "花生米" });
                result.Add(new MED_NURSING_QINGDIAN() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = 9, ITEM_NAME1 = "刀片", ITEM_NAME2 = "沙球" });
                result.Add(new MED_NURSING_QINGDIAN() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = 10, ITEM_NAME1 = "镊子", ITEM_NAME2 = "纱带" });
                result.Add(new MED_NURSING_QINGDIAN() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = 11, ITEM_NAME1 = "卵圆钳", ITEM_NAME2 = "注射器" });
                result.Add(new MED_NURSING_QINGDIAN() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = 12, ITEM_NAME1 = "拉钩", ITEM_NAME2 = "针头" });
                result.Add(new MED_NURSING_QINGDIAN() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = 13, ITEM_NAME1 = "吸引器头", ITEM_NAME2 = "血管夹" });
                result.Add(new MED_NURSING_QINGDIAN() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = 14, ITEM_NAME1 = "胸止", ITEM_NAME2 = "阻断带" });
                result.Add(new MED_NURSING_QINGDIAN() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = 15, ITEM_NAME1 = "压肠板", ITEM_NAME2 = "血管吊带" });
                result.Add(new MED_NURSING_QINGDIAN() { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID, ITEM_NO = 16, ITEM_NAME1 = "肠钳", ITEM_NAME2 = "橡皮筋" });
                dapper.Set<MED_NURSING_QINGDIAN>().Insert(result);
                dapper.SaveChanges();
                result = dapper.Set<MED_NURSING_QINGDIAN>().Select(x => x.PATIENT_ID == PATIENTID && x.VISIT_ID == VISITID && x.OPER_ID == OPERID);
            }

            return result;
        }

        /// <summary>
        /// 获取文书绑定数据
        /// </summary>
        /// <param name="PATIENTID">PATIENTID</param>
        /// <param name="VISITID">VISITID</param>
        /// <param name="OPERID">OPERID</param>
        /// <returns></returns>
        public MedicalBasicDoc QueryMedicalBasicDoc(string PATIENTID, int VISITID, int OPERID, string StatusType, string DocName)
        {
            string sql = sqlDict.GetSQLByKey("GetMedicalBasicDocOperationMaster");

            // 文书表定义，各个文书所需的数据表不同，需要区分开，不然数据量太大
            MED_PAT_VISIT medPatVisit = null;
            MED_OPERATION_MASTER medOperationMaster = null;
            MED_ANESTHESIA_PLAN medAnesthesiaPlan = null;
            MED_ANESTHESIA_PLAN_PMH medAnesthesiaPlanPmh = null;
            MED_ANESTHESIA_PLAN_EXAM medAnesthesiaPlanExam = null;
            MED_ANESTHESIA_RECOVER medAnesthesiaRecover = null;
            MED_ANESTHESIA_INQUIRY medAnesthesiaInquiry = null;
            MED_SAFETY_CHECKS medSafetyChecks = null;
            MED_PRESSUREESTIMATE_DOC medPressureEstimateDoc = null;
            MED_NURSING_AFTER medNursingAfter = null;
            MED_NURSING_AFTERSHIFT_PACU medNursingAfterShiftPacu = null;
            MED_NURSING_AFTERSHIFT_WARD medNursingAfterShiftWard = null;
            MED_NURSING_BEFOREASSESS medNursingBeforeAssess = null;
            MED_NURSING_BEFORESHIFT medNursingBeforeShift = null;
            MED_NURSING_QDNURSE medNursingQdNurse = null;
            List<MED_NURSING_TOUR> medNursingTour = null;
            MED_NURSING_YWASSESS medNursingYwAssess = null;
            List<MED_NURSING_QINGDIAN> medNursingQingDian = null;

            medOperationMaster = dapper.Query<MED_OPERATION_MASTER>(sql, new { PATIENT_ID = PATIENTID, VISIT_ID = VISITID, OPER_ID = OPERID }).Find(d => 1 == 1);
            medPatVisit = this.GetMedPatVisit(PATIENTID, VISITID);

            // 根据文书获取对应的数据表
            switch (DocName)
            {
                case "手术访视记录单":
                    medAnesthesiaPlan = this.GetMedAnesthesiaPlan(PATIENTID, VISITID, OPERID);
                    medAnesthesiaPlanPmh = this.GetMedAnesthesiaPlanPmh(PATIENTID, VISITID, OPERID);
                    medAnesthesiaPlanExam = this.GetMedAnesthesiaPlanExam(PATIENTID, VISITID, OPERID);
                    medAnesthesiaRecover = this.GetMedAnesthesiaRecover(PATIENTID, VISITID, OPERID);
                    medAnesthesiaInquiry = this.GetMedAnesthesiaInquiry(PATIENTID, VISITID, OPERID);
                    break;
                case "手术安全核查单":
                    medSafetyChecks = this.GetMedSafetyChecks(PATIENTID, VISITID, OPERID);
                    break;
                case "护理记录单":
                    medAnesthesiaPlanPmh = this.GetMedAnesthesiaPlanPmh(PATIENTID, VISITID, OPERID);
                    medNursingAfter = this.GetMedNursingAfter(PATIENTID, VISITID, OPERID);
                    medNursingAfterShiftPacu = this.GetMedNursingAfterShiftPacu(PATIENTID, VISITID, OPERID);
                    medNursingAfterShiftWard = this.GetMedNursingAfterShiftWard(PATIENTID, VISITID, OPERID);
                    medNursingBeforeAssess = this.GetMedNursingBeforeAssess(PATIENTID, VISITID, OPERID);
                    medNursingBeforeShift = this.GetMedNursingBeforeShift(PATIENTID, VISITID, OPERID);
                    medNursingQdNurse = this.GetMedNursingQdNurse(PATIENTID, VISITID, OPERID);
                    medNursingTour = this.GetMedNursingTour(PATIENTID, VISITID, OPERID);
                    medNursingYwAssess = this.GetMedNursingYwAssess(PATIENTID, VISITID, OPERID);
                    medNursingQingDian = this.GetMedNursingQingDian(PATIENTID, VISITID, OPERID);
                    break;
                case "压疮评估单":
                    medAnesthesiaPlanPmh = this.GetMedAnesthesiaPlanPmh(PATIENTID, VISITID, OPERID);
                    medPressureEstimateDoc = this.GetMedPressureEstimateDoc(PATIENTID, VISITID, OPERID);
                    break;
                default:
                    break;
            }

            //局麻登记
            string sql1 = sqlDict.GetSQLByKey("GetOutOperationRoomRecordByPatient");
            List<OutOperatingRoomAnesRecordEntity> list = dapper.Set<OutOperatingRoomAnesRecordEntity>().Query(sql1, new
            {
                PatientId = PATIENTID,
                VisitId = VISITID,
                OperId = OPERID
            });

            foreach (var item in list)
            {
                if (item.OPERATION_NAME != null)
                {
                    item.OPERATION_NAMES = item.OPERATION_NAME.Split('+');
                }

                if (item.DIAG_BEFORE_OPERATION != null)
                {
                    item.DIAG_BEFORE_OPERATIONS = item.DIAG_BEFORE_OPERATION.Split(';');
                }
            }

            string TableName = StatusType == "1" ? "MED_PREOPERATIVE_EXPANSION" : StatusType == "2" ? "MED_OPERATION_EXTENDED" : "MED_POSTOPERATIVE_EXTENDED";
            MedicalBasicDoc mbd = new MedicalBasicDoc
            {
                PATIENT_ID = PATIENTID,
                VISIT_ID = VISITID,
                OPER_ID = OPERID,
                MED_OPERATION_MASTER = medOperationMaster,
                MED_SAFETY_CHECKS = medSafetyChecks,
                MED_PAT_VISIT = medPatVisit,
                MED_ANESTHESIA_PLAN = medAnesthesiaPlan,
                MED_ANESTHESIA_PLAN_EXAM = medAnesthesiaPlanExam,
                MED_ANESTHESIA_PLAN_PMH = medAnesthesiaPlanPmh,
                CustomData = GetCustomData(TableName, PATIENTID, VISITID.ToString(), OPERID.ToString()),
                PatientDetail = GetPatientDetailInfo(PATIENTID, VISITID.ToString(), OPERID.ToString()),
                OutOperatingRoomAnesRecordEntity = list[0],
                MED_ANESTHESIA_RECOVER = medAnesthesiaRecover,
                MED_ANESTHESIA_INQUIRY = medAnesthesiaInquiry,
                MED_PRESSUREESTIMATE_DOC = medPressureEstimateDoc,
                MED_NURSING_AFTER = medNursingAfter,
                MED_NURSING_AFTERSHIFT_PACU = medNursingAfterShiftPacu,
                MED_NURSING_AFTERSHIFT_WARD = medNursingAfterShiftWard,
                MED_NURSING_BEFOREASSESS = medNursingBeforeAssess,
                MED_NURSING_BEFORESHIFT = medNursingBeforeShift,
                MED_NURSING_QDNURSE = medNursingQdNurse,
                MED_NURSING_TOUR = medNursingTour,
                MED_NURSING_YWASSESS = medNursingYwAssess,
                MED_NURSING_QINGDIAN = medNursingQingDian
            };

            return mbd;
        }
        /// <summary>
        /// 批量保存文书 数据
        /// </summary>
        /// <param name="basicData"></param>
        /// <returns></returns>
        public int SaveMedicalBasicDoc(MedicalBasicDoc basicData)
        {
            int result = 1;
            try
            {
                if (basicData.DocName == "护理记录单")
                {
                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_OPERATION_MASTER：" + JsonConvert.SerializeObject(basicData.MED_OPERATION_MASTER));
                    dapper.Set<MED_OPERATION_MASTER>().Save(basicData.MED_OPERATION_MASTER);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_ANESTHESIA_PLAN_PMH：" + JsonConvert.SerializeObject(basicData.MED_ANESTHESIA_PLAN_PMH));
                    dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Save(basicData.MED_ANESTHESIA_PLAN_PMH);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_NURSING_AFTER：" + JsonConvert.SerializeObject(basicData.MED_NURSING_AFTER));
                    dapper.Set<MED_NURSING_AFTER>().Save(basicData.MED_NURSING_AFTER);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_NURSING_AFTERSHIFT_PACU：" + JsonConvert.SerializeObject(basicData.MED_NURSING_AFTERSHIFT_PACU));
                    dapper.Set<MED_NURSING_AFTERSHIFT_PACU>().Save(basicData.MED_NURSING_AFTERSHIFT_PACU);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_NURSING_AFTERSHIFT_WARD：" + JsonConvert.SerializeObject(basicData.MED_NURSING_AFTERSHIFT_WARD));
                    dapper.Set<MED_NURSING_AFTERSHIFT_WARD>().Save(basicData.MED_NURSING_AFTERSHIFT_WARD);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_NURSING_BEFOREASSESS：" + JsonConvert.SerializeObject(basicData.MED_NURSING_BEFOREASSESS));
                    dapper.Set<MED_NURSING_BEFOREASSESS>().Save(basicData.MED_NURSING_BEFOREASSESS);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_NURSING_BEFORESHIFT：" + JsonConvert.SerializeObject(basicData.MED_NURSING_BEFORESHIFT));
                    dapper.Set<MED_NURSING_BEFORESHIFT>().Save(basicData.MED_NURSING_BEFORESHIFT);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_NURSING_QDNURSE：" + JsonConvert.SerializeObject(basicData.MED_NURSING_QDNURSE));
                    dapper.Set<MED_NURSING_QDNURSE>().Save(basicData.MED_NURSING_QDNURSE);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_NURSING_TOUR：" + JsonConvert.SerializeObject(basicData.MED_NURSING_TOUR));
                    dapper.Set<MED_NURSING_TOUR>().Save(basicData.MED_NURSING_TOUR);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_NURSING_YWASSESS：" + JsonConvert.SerializeObject(basicData.MED_NURSING_YWASSESS));
                    dapper.Set<MED_NURSING_YWASSESS>().Save(basicData.MED_NURSING_YWASSESS);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_NURSING_QINGDIAN：" + JsonConvert.SerializeObject(basicData.MED_NURSING_QINGDIAN));
                    dapper.Set<MED_NURSING_QINGDIAN>().Save(basicData.MED_NURSING_QINGDIAN);
                }
                else if (basicData.DocName == "压疮评估单")
                {
                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_OPERATION_MASTER：" + JsonConvert.SerializeObject(basicData.MED_OPERATION_MASTER));
                    dapper.Set<MED_OPERATION_MASTER>().Save(basicData.MED_OPERATION_MASTER);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_ANESTHESIA_PLAN_PMH：" + JsonConvert.SerializeObject(basicData.MED_ANESTHESIA_PLAN_PMH));
                    dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Save(basicData.MED_ANESTHESIA_PLAN_PMH);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_PRESSUREESTIMATE_DOC：" + JsonConvert.SerializeObject(basicData.MED_PRESSUREESTIMATE_DOC));
                    dapper.Set<MED_PRESSUREESTIMATE_DOC>().Save(basicData.MED_PRESSUREESTIMATE_DOC);
                }
                else if (basicData.DocName == "手术安全核查单")
                {
                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_OPERATION_MASTER：" + JsonConvert.SerializeObject(basicData.MED_OPERATION_MASTER));
                    dapper.Set<MED_OPERATION_MASTER>().Save(basicData.MED_OPERATION_MASTER);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_SAFETY_CHECKS：" + JsonConvert.SerializeObject(basicData.MED_SAFETY_CHECKS));
                    dapper.Set<MED_SAFETY_CHECKS>().Save(basicData.MED_SAFETY_CHECKS);
                }
                else if (basicData.DocName == "手术访视记录单")
                {
                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_OPERATION_MASTER：" + JsonConvert.SerializeObject(basicData.MED_OPERATION_MASTER));
                    dapper.Set<MED_OPERATION_MASTER>().Save(basicData.MED_OPERATION_MASTER);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_ANESTHESIA_PLAN：" + JsonConvert.SerializeObject(basicData.MED_ANESTHESIA_PLAN));
                    dapper.Set<MED_ANESTHESIA_PLAN>().Save(basicData.MED_ANESTHESIA_PLAN);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_ANESTHESIA_PLAN_PMH：" + JsonConvert.SerializeObject(basicData.MED_ANESTHESIA_PLAN_PMH));
                    dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Save(basicData.MED_ANESTHESIA_PLAN_PMH);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_ANESTHESIA_PLAN_EXAM：" + JsonConvert.SerializeObject(basicData.MED_ANESTHESIA_PLAN_EXAM));
                    dapper.Set<MED_ANESTHESIA_PLAN_EXAM>().Save(basicData.MED_ANESTHESIA_PLAN_EXAM);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_ANESTHESIA_INQUIRY：" + JsonConvert.SerializeObject(basicData.MED_ANESTHESIA_INQUIRY));
                    dapper.Set<MED_ANESTHESIA_INQUIRY>().Save(basicData.MED_ANESTHESIA_INQUIRY);

                    Logger.Error("文书保存(" + basicData.DocName + ")--MED_ANESTHESIA_RECOVER：" + JsonConvert.SerializeObject(basicData.MED_ANESTHESIA_RECOVER));
                    dapper.Set<MED_ANESTHESIA_RECOVER>().Save(basicData.MED_ANESTHESIA_RECOVER);
                }

                //保存自定义表
                if (basicData.CustomData != null)
                {
                    switch (basicData.StatusType)
                    {
                        case "1":  //术前
                            List<MED_PREOPERATIVE_EXPANSION> list = new List<MED_PREOPERATIVE_EXPANSION>();

                            for (int i = 0; i < ((JContainer)basicData.CustomData).Count; i++)
                            {

                                MED_PREOPERATIVE_EXPANSION model = new MED_PREOPERATIVE_EXPANSION();
                                model.PATIENT_ID = basicData.PATIENT_ID;
                                model.VISIT_ID = basicData.VISIT_ID;
                                model.OPER_ID = basicData.OPER_ID;
                                model.ITEM_NAME = ((JProperty)((JContainer)basicData.CustomData).ToList()[i]).Name.Replace("__", ".");
                                model.ITEM_VALUE = ((JProperty)((JContainer)basicData.CustomData).ToList()[i]).Value.ToString();
                                list.Add(model);
                            }
                            dapper.Set<MED_PREOPERATIVE_EXPANSION>().Save(list);

                            break;
                        case "2": //术中
                            List<MED_OPERATION_EXTENDED> list2 = new List<MED_OPERATION_EXTENDED>();
                            for (int i = 0; i < ((JContainer)basicData.CustomData).Count; i++)
                            {

                                MED_OPERATION_EXTENDED model = new MED_OPERATION_EXTENDED();
                                model.PATIENT_ID = basicData.PATIENT_ID;
                                model.VISIT_ID = basicData.VISIT_ID;
                                model.OPER_ID = basicData.OPER_ID;
                                model.ITEM_NAME = ((JProperty)((JContainer)basicData.CustomData).ToList()[i]).Name.Replace("__", ".");
                                model.ITEM_VALUE = ((JProperty)((JContainer)basicData.CustomData).ToList()[i]).Value.ToString();
                                list2.Add(model);

                            }
                            dapper.Set<MED_OPERATION_EXTENDED>().Save(list2);

                            break;
                        default:   //默认术后
                            List<MED_POSTOPERATIVE_EXTENDED> list1 = new List<MED_POSTOPERATIVE_EXTENDED>();
                            for (int i = 0; i < ((JContainer)basicData.CustomData).Count; i++)
                            {

                                MED_POSTOPERATIVE_EXTENDED model = new MED_POSTOPERATIVE_EXTENDED();
                                model.PATIENT_ID = basicData.PATIENT_ID;
                                model.VISIT_ID = basicData.VISIT_ID;
                                model.OPER_ID = basicData.OPER_ID;
                                model.ITEM_NAME = ((JProperty)((JContainer)basicData.CustomData).ToList()[i]).Name.Replace("__", ".");
                                model.ITEM_VALUE = ((JProperty)((JContainer)basicData.CustomData).ToList()[i]).Value.ToString();
                                list1.Add(model);
                            }
                            dapper.Set<MED_POSTOPERATIVE_EXTENDED>().Save(list1);
                            break;
                    }
                }

                dapper.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Error("SaveMedicalBasicDoc:" + ex);
                result = 0;  //执行错误返回0
            }

            return result;
        }

        private MedicalBasicDoc MergeData(MedicalBasicDoc basicData)
        {

            string operName = basicData.MED_OPERATION_MASTER.OPERATION_NAME;// 手术名称

            string operScale = basicData.MED_OPERATION_MASTER.OPER_SCALE;//手术等级

            int? emergencyId = basicData.MED_OPERATION_MASTER.EMERGENCY_IND;//急诊择期

            string diagBeforeOperation = basicData.MED_OPERATION_MASTER.DIAG_BEFORE_OPERATION;//术前诊断

            string surgeon = basicData.MED_OPERATION_MASTER.SURGEON;//主刀

            string firstOperAssistant = basicData.MED_OPERATION_MASTER.FIRST_OPER_ASSISTANT;//第一助手

            MedicalBasicDoc basicDataMain = basicData;

            try
            {
                //合并master表,以一体机数据为主
                MED_OPERATION_MASTER masterNew = dapper.Set<MED_OPERATION_MASTER>().Single(d =>
                d.PATIENT_ID == basicData.MED_OPERATION_MASTER.PATIENT_ID
                && d.VISIT_ID == basicData.MED_OPERATION_MASTER.VISIT_ID
                && d.OPER_ID == basicData.MED_OPERATION_MASTER.OPER_ID);

                MED_OPERATION_MASTER masterOld = basicData.MED_OPERATION_MASTER;

                if (masterNew != null)
                {
                    List<MED_OPERATION_MASTER> masterNewList = new List<MED_OPERATION_MASTER>();
                    masterNewList.Add(masterNew);

                    DataTable dtMasterNew = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(masterNewList));

                    List<MED_OPERATION_MASTER> masterOldList = new List<MED_OPERATION_MASTER>();
                    masterOldList.Add(masterOld);

                    DataTable dtMasterOld = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(masterOldList));

                    dtMasterNew = MergeColumnData(dtMasterNew, dtMasterOld);

                    masterNewList = JsonConvert.DeserializeObject<List<MED_OPERATION_MASTER>>(JsonConvert.SerializeObject(dtMasterNew));

                    basicDataMain.MED_OPERATION_MASTER = masterNewList[0];

                    basicDataMain.MED_OPERATION_MASTER.OPERATION_NAME = operName;

                    basicDataMain.MED_OPERATION_MASTER.OPER_SCALE = operScale;

                    basicDataMain.MED_OPERATION_MASTER.EMERGENCY_IND = emergencyId;

                    basicDataMain.MED_OPERATION_MASTER.DIAG_BEFORE_OPERATION = diagBeforeOperation;

                    basicDataMain.MED_OPERATION_MASTER.SURGEON = surgeon;

                    basicDataMain.MED_OPERATION_MASTER.FIRST_OPER_ASSISTANT = firstOperAssistant;
                }



                //合并安全核查表，以一体机为主
                MED_SAFETY_CHECKS safteyCheckNew = dapper.Set<MED_SAFETY_CHECKS>().Single(d =>
                d.PATIENT_ID == basicData.MED_SAFETY_CHECKS.PATIENT_ID
                && d.VISIT_ID == basicData.MED_SAFETY_CHECKS.VISIT_ID
                && d.OPER_ID == basicData.MED_SAFETY_CHECKS.OPER_ID);

                MED_SAFETY_CHECKS safteyCheckOld = basicData.MED_SAFETY_CHECKS;

                if (safteyCheckNew != null)
                {
                    List<MED_SAFETY_CHECKS> safteyCheckNewList = new List<MED_SAFETY_CHECKS>();
                    safteyCheckNewList.Add(safteyCheckNew);

                    DataTable dtSafteyCheckNew = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(safteyCheckNewList));

                    List<MED_SAFETY_CHECKS> safteyCheckOldList = new List<MED_SAFETY_CHECKS>();
                    safteyCheckOldList.Add(safteyCheckOld);

                    DataTable dtSafteyCheckOld = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(safteyCheckOldList));

                    dtSafteyCheckNew = MergeColumnData(dtSafteyCheckNew, dtSafteyCheckOld);

                    safteyCheckNewList = JsonConvert.DeserializeObject<List<MED_SAFETY_CHECKS>>(JsonConvert.SerializeObject(dtSafteyCheckNew));

                    basicDataMain.MED_SAFETY_CHECKS = safteyCheckNewList[0];
                }


                //合并MED_PAT_VISIT表，以一体机为主
                MED_PAT_VISIT patVisitNew = dapper.Set<MED_PAT_VISIT>().Single(d =>
                d.PATIENT_ID == basicData.MED_PAT_VISIT.PATIENT_ID
                && d.VISIT_ID == basicData.MED_PAT_VISIT.VISIT_ID);

                MED_PAT_VISIT patVisitOld = basicData.MED_PAT_VISIT;

                if (patVisitNew != null)
                {
                    List<MED_PAT_VISIT> patVisitNewList = new List<MED_PAT_VISIT>();
                    patVisitNewList.Add(patVisitNew);

                    DataTable dtPatVisitNew = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(patVisitNewList));

                    List<MED_PAT_VISIT> patVisitOldList = new List<MED_PAT_VISIT>();
                    patVisitOldList.Add(patVisitOld);

                    DataTable dtPatVisitOld = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(patVisitOldList));

                    dtPatVisitNew = MergeColumnData(dtPatVisitNew, dtPatVisitOld);

                    patVisitNewList = JsonConvert.DeserializeObject<List<MED_PAT_VISIT>>(JsonConvert.SerializeObject(dtPatVisitNew));

                    basicDataMain.MED_PAT_VISIT = patVisitNewList[0];
                }

                //合并MED_ANESTHESIA_PLAN表，以一体机为主
                MED_ANESTHESIA_PLAN anesPlanNew = dapper.Set<MED_ANESTHESIA_PLAN>().Single(d =>
                d.PATIENT_ID == basicData.MED_ANESTHESIA_PLAN.PATIENT_ID
                && d.VISIT_ID == basicData.MED_ANESTHESIA_PLAN.VISIT_ID
                && d.OPER_ID == basicData.MED_ANESTHESIA_PLAN.VISIT_ID);

                MED_ANESTHESIA_PLAN anesPlanOld = basicData.MED_ANESTHESIA_PLAN;

                if (anesPlanNew != null)
                {
                    List<MED_ANESTHESIA_PLAN> anesPlanNewList = new List<MED_ANESTHESIA_PLAN>();
                    anesPlanNewList.Add(anesPlanNew);

                    DataTable dtAnesPlanNew = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(anesPlanNewList));

                    List<MED_ANESTHESIA_PLAN> anesPlanOldList = new List<MED_ANESTHESIA_PLAN>();
                    anesPlanOldList.Add(anesPlanOld);

                    DataTable dtAnesPlanOld = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(anesPlanOldList));

                    dtAnesPlanNew = MergeColumnData(dtAnesPlanNew, dtAnesPlanOld);

                    anesPlanNewList = JsonConvert.DeserializeObject<List<MED_ANESTHESIA_PLAN>>(JsonConvert.SerializeObject(dtAnesPlanNew));

                    basicDataMain.MED_ANESTHESIA_PLAN = anesPlanNewList[0];
                }

                //合并MED_ANESTHESIA_PLAN表，以一体机为主
                MED_ANESTHESIA_PLAN_EXAM anesPlanExamNew = dapper.Set<MED_ANESTHESIA_PLAN_EXAM>().Single(d =>
                d.PATIENT_ID == basicData.MED_ANESTHESIA_PLAN_EXAM.PATIENT_ID
                && d.VISIT_ID == basicData.MED_ANESTHESIA_PLAN_EXAM.VISIT_ID
                && d.OPER_ID == basicData.MED_ANESTHESIA_PLAN_EXAM.VISIT_ID);

                MED_ANESTHESIA_PLAN_EXAM anesPlanExamOld = basicData.MED_ANESTHESIA_PLAN_EXAM;

                if (anesPlanExamNew != null)
                {
                    List<MED_ANESTHESIA_PLAN_EXAM> anesPlanExamNewList = new List<MED_ANESTHESIA_PLAN_EXAM>();
                    anesPlanExamNewList.Add(anesPlanExamNew);

                    DataTable dtAnesPlanExamNew = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(anesPlanExamNewList));

                    List<MED_ANESTHESIA_PLAN_EXAM> anesPlanExamOldList = new List<MED_ANESTHESIA_PLAN_EXAM>();
                    anesPlanExamOldList.Add(anesPlanExamOld);

                    DataTable dtAnesPlanExamOld = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(anesPlanExamOldList));

                    dtAnesPlanExamNew = MergeColumnData(dtAnesPlanExamNew, dtAnesPlanExamOld);

                    anesPlanExamNewList = JsonConvert.DeserializeObject<List<MED_ANESTHESIA_PLAN_EXAM>>(JsonConvert.SerializeObject(dtAnesPlanExamNew));

                    basicDataMain.MED_ANESTHESIA_PLAN_EXAM = anesPlanExamNewList[0];
                }


                //合并MED_ANESTHESIA_PLAN表，以一体机为主
                MED_ANESTHESIA_PLAN_PMH anesPlanPmhNew = dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Single(d =>
                d.PATIENT_ID == basicData.MED_ANESTHESIA_PLAN_PMH.PATIENT_ID
                && d.VISIT_ID == basicData.MED_ANESTHESIA_PLAN_PMH.VISIT_ID
                && d.OPER_ID == basicData.MED_ANESTHESIA_PLAN_PMH.VISIT_ID);

                MED_ANESTHESIA_PLAN_PMH anesPlanPmhOld = basicData.MED_ANESTHESIA_PLAN_PMH;

                if (anesPlanPmhNew != null)
                {
                    List<MED_ANESTHESIA_PLAN_PMH> anesPlanPmhNewList = new List<MED_ANESTHESIA_PLAN_PMH>();
                    anesPlanPmhNewList.Add(anesPlanPmhNew);

                    DataTable dtAnesPlanPmhNew = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(anesPlanPmhNewList));

                    List<MED_ANESTHESIA_PLAN_PMH> anesPlanPmhOldList = new List<MED_ANESTHESIA_PLAN_PMH>();
                    anesPlanPmhOldList.Add(anesPlanPmhOld);

                    DataTable dtAnesPlanPmhOld = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(anesPlanPmhOldList));

                    dtAnesPlanPmhNew = MergeColumnData(dtAnesPlanPmhNew, dtAnesPlanPmhOld);

                    anesPlanPmhNewList = JsonConvert.DeserializeObject<List<MED_ANESTHESIA_PLAN_PMH>>(JsonConvert.SerializeObject(dtAnesPlanPmhNew));

                    basicDataMain.MED_ANESTHESIA_PLAN_PMH = anesPlanPmhNewList[0];
                }
            }
            catch (Exception ex)
            {
                Logger.Error("MedicalBasicDoc->MergeData", ex);
            }

            return basicDataMain;

        }

        private DataTable MergeColumnData(DataTable dtMasterNew, DataTable dtMasterOld)
        {
            foreach (DataColumn itemDclNew in dtMasterNew.Columns)
            {
                string dclValueNew = dtMasterNew.Rows[0][itemDclNew].ToString();

                foreach (DataColumn itemDclOld in dtMasterOld.Columns)
                {
                    string dclValueOld = dtMasterOld.Rows[0][itemDclOld].ToString();

                    if (itemDclNew.ColumnName.Equals(itemDclOld.ColumnName))
                    {
                        if (string.IsNullOrEmpty(dclValueNew) && !string.IsNullOrEmpty(dclValueOld))
                        {
                            dclValueNew = dclValueOld;
                        }
                    }
                }

                dtMasterNew.Rows[0][itemDclNew] = dclValueNew;
            }

            return dtMasterNew;
        }


        /// <summary>
        /// 获取字典数据
        /// </summary>
        /// <param name="data">data</param>
        /// <returns></returns>
        public dynamic GetDicData(dynamic data)
        {

            string AnesWardCode = AppSettings.AnesWardCode;

            string OperDeptCode = AppSettings.OperDeptCode;

            MED_CONFIGSET config = sysConfigService.GetMedConfigSet();


            StringBuilder strSQL = new StringBuilder();
            string otherQueryStr = "";

            string sqlExistData = "";

            string otherQueryStr2 = "";


            if (data.queryObj.otherQuery != null)
            {
                foreach (var item in data.queryObj.otherQuery)
                {
                    otherQueryStr += string.Format(" and {0}='{1}' ", item.name, item.value);
                }
            }

            if (data.queryObj.tablename != null && data.queryObj.tablename.ToString().ToUpper() == "MED_HIS_USERS")
            {
                if (data.queryObj.type != null)
                {
                    if (data.queryObj.type.ToString().ToUpper() == "SURGEON")//主刀医生
                    {
                        if (config != null && !string.IsNullOrEmpty(config.DeptCodeStr))
                        {
                            otherQueryStr += string.Format(" and USER_DEPT_CODE IN ({0}) ", config.DeptCodeStr);
                        }
                    }
                    else if (data.queryObj.type.ToString().ToUpper() == "ANESDOCTOR")//麻醉医生
                    {
                        otherQueryStr += string.Format(" and USER_DEPT_CODE IN ('{0}') ", AnesWardCode);
                    }
                    else if (data.queryObj.type.ToString().ToUpper() == "NURSE")//护士
                    {
                        otherQueryStr += string.Format(" and USER_DEPT_CODE IN ('{0}') ", OperDeptCode);
                    }
                }

                if (data.queryObj.BindedData != null)//已绑定的数据
                {
                    foreach (var item in data.queryObj.BindedData)
                    {

                        if (item.NAME.ToString().ToUpper() == "MED_OPERATION_MASTER".ToUpper())
                        {
                            if (item.PATIENTINFO != null)
                            {
                                string patientId = item.PATIENTINFO.PATIENT_ID.ToString();
                                decimal visitId = Convert.ToDecimal(item.PATIENTINFO.VISIT_ID.ToString());
                                decimal operId = Convert.ToDecimal(item.PATIENTINFO.OPER_ID.ToString());

                                if (!string.IsNullOrEmpty(patientId))
                                {
                                    MED_OPERATION_MASTER operMaster = dapper.Set<MED_OPERATION_MASTER>().Single(d => d.PATIENT_ID == patientId && d.VISIT_ID == visitId && d.OPER_ID == operId);

                                    string[] strListFields = item.FIELDS.ToString().Split(',');

                                    foreach (string itemField in strListFields)
                                    {
                                        if (itemField.ToUpper() == "SURGEON")//主刀医生
                                        {
                                            var doctorValue = operMaster.SURGEON;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "FIRST_OPER_ASSISTANT")
                                        {
                                            var doctorValue = operMaster.FIRST_OPER_ASSISTANT;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "SECOND_OPER_ASSISTANT")
                                        {
                                            var doctorValue = operMaster.SECOND_OPER_ASSISTANT;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "THIRD_OPER_ASSISTANT")
                                        {
                                            var doctorValue = operMaster.THIRD_OPER_ASSISTANT;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "FOURTH_OPER_ASSISTANT")
                                        {
                                            var doctorValue = operMaster.FOURTH_OPER_ASSISTANT;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}'OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "ANES_DOCTOR")//麻醉医生
                                        {
                                            var doctorValue = operMaster.ANES_DOCTOR;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "FIRST_ANES_ASSISTANT")
                                        {
                                            var doctorValue = operMaster.FIRST_ANES_ASSISTANT;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "SECOND_ANES_ASSISTANT")
                                        {
                                            var doctorValue = operMaster.SECOND_ANES_ASSISTANT;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "THIRD_ANES_ASSISTANT")
                                        {
                                            var doctorValue = operMaster.THIRD_ANES_ASSISTANT;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "FOURTH_ANES_ASSISTANT")
                                        {
                                            var doctorValue = operMaster.FOURTH_ANES_ASSISTANT;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "FIRST_OPER_NURSE")//洗手护士
                                        {
                                            var doctorValue = operMaster.FIRST_OPER_NURSE;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}'OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "SECOND_OPER_NURSE")
                                        {
                                            var doctorValue = operMaster.SECOND_OPER_NURSE;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "THIRD_OPER_NURSE")
                                        {
                                            var doctorValue = operMaster.THIRD_OPER_NURSE;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "FOURTH_OPER_NURSE")
                                        {
                                            var doctorValue = operMaster.FOURTH_OPER_NURSE;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "FIRST_SUPPLY_NURSE")//巡回护士
                                        {
                                            var doctorValue = operMaster.FIRST_SUPPLY_NURSE;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "SECOND_SUPPLY_NURSE")
                                        {
                                            var doctorValue = operMaster.SECOND_SUPPLY_NURSE;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "THIRD_SUPPLY_NURSE")
                                        {
                                            var doctorValue = operMaster.THIRD_SUPPLY_NURSE;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "FOURTH_SUPPLY_NURSE")
                                        {
                                            var doctorValue = operMaster.FOURTH_SUPPLY_NURSE;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "FIRST_PACU_ASSISTANT")//PACU 助手
                                        {
                                            var doctorValue = operMaster.FIRST_PACU_ASSISTANT;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "SECOND_PACU_ASSISTANT")
                                        {
                                            var doctorValue = operMaster.SECOND_PACU_ASSISTANT;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "FIRST_PACU_NURSE")//PACU 护士
                                        {
                                            var doctorValue = operMaster.FIRST_PACU_NURSE;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "SECOND_PACU_NURSE")
                                        {
                                            var doctorValue = operMaster.SECOND_PACU_NURSE;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "FIRST_CPB_ASSISTANT")//CPB 助手
                                        {
                                            var doctorValue = operMaster.FIRST_CPB_ASSISTANT;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "SECOND_CPB_ASSISTANT")
                                        {
                                            var doctorValue = operMaster.SECOND_CPB_ASSISTANT;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "THIRD_CPB_ASSISTANT")
                                        {
                                            var doctorValue = operMaster.THIRD_CPB_ASSISTANT;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                        else if (itemField.ToUpper() == "FOURTH_CPB_ASSISTANT")
                                        {
                                            var doctorValue = operMaster.FOURTH_CPB_ASSISTANT;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( USER_JOB_ID ='{0}' OR USER_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (data.queryObj.tablename != null && data.queryObj.tablename.ToString().ToUpper() == "MED_DEPT_DICT")
            {
                if (data.queryObj.BindedData != null)//已绑定的数据
                {
                    foreach (var item in data.queryObj.BindedData)
                    {

                        if (item.NAME.ToString().ToUpper() == "MED_OPERATION_MASTER".ToUpper())
                        {
                            if (item.PATIENTINFO != null)
                            {
                                string patientId = item.PATIENTINFO.PATIENT_ID.ToString();
                                decimal visitId = Convert.ToDecimal(item.PATIENTINFO.VISIT_ID.ToString());
                                decimal operId = Convert.ToDecimal(item.PATIENTINFO.OPER_ID.ToString());

                                if (!string.IsNullOrEmpty(patientId))
                                {
                                    MED_OPERATION_MASTER operMaster = dapper.Set<MED_OPERATION_MASTER>().Single(d => d.PATIENT_ID == patientId && d.VISIT_ID == visitId && d.OPER_ID == operId);

                                    string[] strListFields = item.FIELDS.ToString().Split(',');

                                    foreach (string itemField in strListFields)
                                    {
                                        if (itemField.ToUpper() == "DEPT_CODE")//科室
                                        {
                                            var doctorValue = operMaster.DEPT_CODE;
                                            if (!string.IsNullOrEmpty(doctorValue))
                                            {
                                                otherQueryStr2 += string.Format(" OR ( DEPT_CODE ='{0}' OR DEPT_NAME ='{0}') ", doctorValue);
                                            }
                                        }
                                    }
                                }
                            }

                            //foreach (var itemField in item.FIELDS)
                            //{
                            //    if (itemField.key.ToString().ToUpper() == "DEPT_CODE")//科室
                            //    {
                            //        var doctorValue = itemField.value.ToString();
                            //        if (!string.IsNullOrEmpty(doctorValue))
                            //        {
                            //            otherQueryStr2 += string.Format(" OR ( DEPT_CODE ='{0}' OR DEPT_NAME ='{0}') ", doctorValue);
                            //        }
                            //    }
                            //}
                        }
                    }
                }
            }
            #region
            //else if (data.queryObj.tablename != null && data.queryObj.tablename.ToString().ToUpper() == "MED_DIAGNOSIS_DICT")
            //{

            //    if (data.queryObj.BindedData != null)//已绑定的数据
            //    {
            //        foreach (var item in data.queryObj.BindedData)
            //        {

            //            if (item.NAME.ToString().ToUpper() == "MED_OPERATION_MASTER".ToUpper())
            //            {
            //                if (item.PATIENTINFO != null)
            //                {
            //                    string patientId = item.PATIENTINFO.PATIENT_ID.ToString();
            //                    decimal visitId = Convert.ToDecimal(item.PATIENTINFO.VISIT_ID.ToString());
            //                    decimal operId = Convert.ToDecimal(item.PATIENTINFO.OPER_ID.ToString());


            //                    foreach (var itemField in item.FIELDS)
            //                    {
            //                        var doctorValue = itemField.value.ToString();
            //                        if (!string.IsNullOrEmpty(doctorValue))
            //                        {
            //                            otherQueryStr2 += string.Format(" OR ( DIAGNOSIS_CODE ='{0}' OR DIAGNOSIS_NAME ='{0}') ", doctorValue);
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //else if (data.queryObj.tablename != null && data.queryObj.tablename.ToString().ToUpper() == "MED_OPERATION_DICT")
            //{

            //    if (data.queryObj.BindedData != null)//已绑定的数据
            //    {
            //        foreach (var item in data.queryObj.BindedData)
            //        {

            //            if (item.NAME.ToString().ToUpper() == "MED_OPERATION_MASTER".ToUpper())
            //            {
            //                if (item.PATIENTINFO != null)
            //                {
            //                    string patientId = item.PATIENTINFO.PATIENT_ID.ToString();
            //                    decimal visitId = Convert.ToDecimal(item.PATIENTINFO.VISIT_ID.ToString());
            //                    decimal operId = Convert.ToDecimal(item.PATIENTINFO.OPER_ID.ToString());

            //                    MED_OPERATION_MASTER operMaster = dapper.Set<MED_OPERATION_MASTER>().Single(d => d.PATIENT_ID == patientId && d.VISIT_ID == visitId && d.OPER_ID == operId);

            //                    string[] strListFields = item.FIELDS.ToString().Split(',');

            //                    foreach (string itemField in strListFields)
            //                    {
            //                        if (itemField.ToUpper() == "OPERATION_NAME")//手术名称
            //                        {
            //                            var doctorValue = operMaster.OPERATION_NAME;
            //                            if (!string.IsNullOrEmpty(doctorValue))
            //                            {
            //                                otherQueryStr2 += string.Format(" OR ( OPER_CODE ='{0}' OR OPER_NAME ='{0}') ", doctorValue);
            //                            }
            //                        }

            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion

            if (data.inputObj != null && data.inputObj.value.Value != "")
            {
                StringBuilder sqlWhere = new StringBuilder();

                if (data.queryObj.queryFieldName != null)
                {
                    string[] queryFieldNameList = data.queryObj.queryFieldName.ToString().Split(',');

                    if (queryFieldNameList.Length > 0)
                    {
                        sqlWhere.AppendFormat(" and ( ");

                        for (int i = 0; i < queryFieldNameList.Length; i++)
                        {
                            var item = queryFieldNameList[i];

                            if (i == queryFieldNameList.Length - 1)
                            {
                                sqlWhere.AppendFormat(" {0} like '%{1}%'  ", item, data.inputObj.value.Value.ToString().ToUpper());
                            }
                            else
                            {
                                sqlWhere.AppendFormat(" {0} like '%{1}%'  or", item, data.inputObj.value.Value.ToString().ToUpper());
                            }
                        }

                        sqlWhere.AppendFormat("  ) ");
                    }

                    strSQL.AppendFormat("select * from (select {0} as textLable,{1} as valueLable, row_number() over(order by {0}) rn  from {2} where 1=1 {3} {4}) t where t.rn <= 50 ", data.queryObj.textLable, data.queryObj.valueLable, data.queryObj.tablename, otherQueryStr, sqlWhere.ToString());

                }
                else
                {

                    sqlWhere.AppendFormat(" and {0} like '%{1}%'", data.queryObj.textLable, data.inputObj.value.Value.ToString().ToUpper());
                    strSQL.AppendFormat("select * from (select {0} as textLable,{1} as valueLable, row_number() over(order by {0}) rn  from {2} where 1=1 {3} {4}) t where t.rn <= 50 ", data.queryObj.textLable, data.queryObj.valueLable, data.queryObj.tablename, otherQueryStr, sqlWhere.ToString());

                }
            }
            else
            {
                strSQL.AppendFormat("select * from (select {0} as textLable,{1} as valueLable, row_number() over(order by {0}) rn  from {2} where 1=1 {3}) t where t.rn <= 50 ", data.queryObj.textLable, data.queryObj.valueLable, data.queryObj.tablename, otherQueryStr);

            }

            List<dynamic> list = dapper.Query(strSQL.ToString());

            if (!string.IsNullOrEmpty(otherQueryStr2))
            {
                sqlExistData = string.Format(@"select * from (select {0} as textLable,{1} as valueLable, row_number() over(order by {0}) rn  from {2} where  {3}) t where t.rn <= 50 ",
       data.queryObj.textLable, data.queryObj.valueLable, data.queryObj.tablename, otherQueryStr2.Trim().TrimStart('O').TrimStart('R'));

                List<dynamic> listExist = dapper.Query(sqlExistData.ToString());

                if (listExist.Count > 0)
                {

                    foreach (var item in list)
                    {
                        if (listExist.Find(d => d.VALUELABLE == item.VALUELABLE) == null)
                        {
                            listExist.Add(item);
                        }
                    }

                    //DataTable dt = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(listExist));

                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    DataRow dr = dt.Rows[i];

                    //    dr["RN"] = i + 1;
                    //}


                    //list = JsonConvert.DeserializeObject<List<dynamic>>(JsonConvert.SerializeObject(dt));

                    list = listExist;
                }
            }



            return list;
        }

        public IList<MED_DEPT_DICT> GetMedDeptInOperRoomDict(string DeptName)
        {
            string sql = sqlDict.GetSQLByKey("GetMedDeptInOperRoomDict");
            List<MED_DEPT_DICT> list = dapper.Query<MED_DEPT_DICT>(sql, new { });
            return list;
        }
        /// <summary>
        /// 上传pdf文书
        /// </summary>
        /// <param name="PDFobj">PDFobj</param>
        /// <returns></returns>
        public int PDFUpload(dynamic PDFobj)
        {
            string PATIENT_ID = PDFobj.pdfInfo.PATIENT_ID.Value;
            int VISIT_ID = Convert.ToInt32(PDFobj.pdfInfo.VISIT_ID.Value);
            string OPER_ID = PDFobj.pdfInfo.OPER_ID.Value.ToString();
            string docName = PDFobj.pdfInfo.docName.Value;
            string UserId = PDFobj.UserId.Value.ToString();

            MED_EMR_ARCHIVE_DETIAL mead = dapper.Set<MED_EMR_ARCHIVE_DETIAL>().Single(d => d.PATIENT_ID == PATIENT_ID &&
              d.VISIT_ID == VISIT_ID && d.ARCHIVE_KEY == OPER_ID &&
              d.MR_CLASS == "麻醉" && d.MR_SUB_CLASS == docName);

            string directoryName = string.Concat(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "TempUploadPDF\\");
            if (!Directory.Exists(directoryName))
            {
                DirectoryInfo di = Directory.CreateDirectory(directoryName);
                DirectorySecurity dirSecurity = di.GetAccessControl();
                dirSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
                di.SetAccessControl(dirSecurity);
            }
            // 生成文书
            string fileName = String.Format("{0}_{1}_麻醉_{2}_{3}_{4}.pdf", PATIENT_ID, VISIT_ID, docName, OPER_ID, 1);
            string FilePath = string.Concat(directoryName, fileName);
            string content = PDFobj.content;
            byte[] bytes = Convert.FromBase64String(content.Substring(51));
            FileStream fs = new FileStream(FilePath, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
            // 文书上传


            int result = commonService.PostPDFFile(
                   new { FILE = bytes, FileName = fileName, PatientID = PATIENT_ID, VisitID = VISIT_ID.ToString() });
            if (result == 1)
            {
                // 更新EMR表
                if (mead == null)
                {
                    string path = string.Format("{0}\\{1}\\{2}\\", PATIENT_ID.Substring(PATIENT_ID.Length - 3, 3), PATIENT_ID.Substring(0, PATIENT_ID.Length - 3), VISIT_ID);
                    mead = new MED_EMR_ARCHIVE_DETIAL()
                    {
                        PATIENT_ID = PATIENT_ID,
                        VISIT_ID = VISIT_ID,
                        MR_CLASS = "麻醉",
                        MR_SUB_CLASS = docName,
                        ARCHIVE_KEY = OPER_ID,
                        EMR_FILE_INDEX = 0,
                        ARCHIVE_TIMES = 1,
                        TOPIC = docName + "_" + OPER_ID,
                        EMR_FILE_NAME = fileName,
                        EMR_TYPE = "PDF",
                        ARCHIVE_DATE_TIME = DateTime.Now,
                        ARCHIVE_TYPE = "正常",
                        ARCHIVE_STATUS = "已归档",
                        ARCHIVE_MODE = "分布",
                        EMR_OWNER = UserId,
                        OPERATOR = UserId,
                        ARCHIVE_ACCESS = path
                    };
                    dapper.Set<MED_EMR_ARCHIVE_DETIAL>().Insert(mead);
                }
                else
                {
                    mead.ARCHIVE_DATE_TIME = DateTime.Now;
                    mead.EMR_OWNER = UserId;
                    mead.OPERATOR = UserId;
                    dapper.Set<MED_EMR_ARCHIVE_DETIAL>().Update(mead);
                }
                dapper.SaveChanges();

                //文件上传结束之后，删除本地PDF缓存文件

                if (File.Exists(FilePath))
                {
                    try
                    {
                        FileInfo fi = new FileInfo(FilePath);
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                            fi.Attributes = FileAttributes.Normal;
                        File.Delete(FilePath);//直接删除其中的文件 
                    }
                    catch
                    {
                        Logger.Error("本地PDF文件删除失败：" + FilePath);
                    }
                }
            }
            return result;


            //// 调用EMRFSRVS中的putfile就行文件上传
            //int result = 0;
            //result = putfile(sysConfigService.GetFromConfigTable("PDFServerUrl"), FilePath, FileName, 1, 1);
            //if (result == 0)
            //{
            //    // 更新EMR表
            //    if (mead == null)
            //    {
            //        string path = string.Format("{0}\\{1}\\{2}\\", PATIENT_ID.Substring(PATIENT_ID.Length - 3, 3), PATIENT_ID.Substring(0, PATIENT_ID.Length - 3), VISIT_ID);
            //        mead = new MED_EMR_ARCHIVE_DETIAL()
            //        {
            //            PATIENT_ID = PATIENT_ID,
            //            VISIT_ID = VISIT_ID,
            //            MR_CLASS = "麻醉",
            //            MR_SUB_CLASS = docName,
            //            ARCHIVE_KEY = OPER_ID,
            //            EMR_FILE_INDEX = 0,
            //            ARCHIVE_TIMES = 1,
            //            TOPIC = docName + "_" + OPER_ID,
            //            EMR_FILE_NAME = FileName,
            //            EMR_TYPE = "PDF",
            //            ARCHIVE_DATE_TIME = DateTime.Now,
            //            ARCHIVE_TYPE = "正常",
            //            ARCHIVE_STATUS = "已归档",
            //            ARCHIVE_MODE = "分布",
            //            EMR_OWNER = UserId,
            //            OPERATOR = UserId,
            //            ARCHIVE_ACCESS = path
            //        };
            //        dapper.Set<MED_EMR_ARCHIVE_DETIAL>().Insert(mead);
            //    }
            //    else
            //    {
            //        mead.ARCHIVE_DATE_TIME = DateTime.Now;
            //        mead.EMR_OWNER = UserId;
            //        mead.OPERATOR = UserId;
            //        dapper.Set<MED_EMR_ARCHIVE_DETIAL>().Update(mead);
            //    }
            //    dapper.SaveChanges();
            //    // 调用接口
            //    sysConfigService.SyncOPER505W(mead);


            //    //文件上传结束之后，删除本地PDF缓存文件

            //    if (File.Exists(FilePath))
            //    {
            //        try
            //        {
            //            FileInfo fi = new FileInfo(FilePath);
            //            if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
            //                fi.Attributes = FileAttributes.Normal;
            //            File.Delete(FilePath);//直接删除其中的文件 
            //        }
            //        catch
            //        {
            //            Logger.Error("本地PDF文件删除失败：" + FilePath);
            //        }
            //    }
            //}
            //return result;
        }

        /// <summary>
        /// 获取字典
        /// </summary>
        /// <param name="itemClass"></param>
        /// <returns></returns>
        public IList<MED_ANESTHESIA_INPUT_DICT> GetAnesInputDict(string itemClass)
        {
            return dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Select(r => r.ITEM_CLASS == itemClass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        public MED_OPERATION_SCHEDULE GetOperationSchedule(string patientID, decimal visitID, decimal operID)
        {
            string sql = sqlDict.GetSQLByKey("GetOperDetail");
            return dapper.Set<MED_OPERATION_SCHEDULE>().Query(sql, new { PatientID = patientID, VisitID = visitID, OperID = operID }).FirstOrDefault();
        }

        /// <summary>
        /// 手术取消
        /// </summary>
        /// <param name="operationCanceled"></param>
        /// <returns></returns>
        public int CancelOperationSchedule(OperCancelAndDetailEntity operationCanceled)
        {
            int result = 0; // 0: 失败  1 ：成功  2：麻醉先回退到术前状态  3：记录不存在 4 :手术已取消

            //判断状态

            MED_OPERATION_MASTER master = dapper.Set<MED_OPERATION_MASTER>().Single(d => d.PATIENT_ID == operationCanceled.OperCanceled.PATIENT_ID && d.VISIT_ID == operationCanceled.OperCanceled.VISIT_ID && d.OPER_ID == operationCanceled.OperCanceled.OPER_ID);

            if (master != null)
            {
                if (master.OPER_STATUS_CODE > 0)
                {
                    return 2;
                }
                else
                {
                    if (master.OPER_STATUS_CODE == -80)
                    {
                        return 4;
                    }
                }
            }
            else
            {
                return 3;
            }

            MED_OPERATION_SCHEDULE opsche = dapper.Set<MED_OPERATION_SCHEDULE>().Single(d => d.PATIENT_ID == operationCanceled.OperCanceled.PATIENT_ID && d.VISIT_ID == operationCanceled.OperCanceled.VISIT_ID && d.OPER_ID == operationCanceled.OperCanceled.OPER_ID);
            int CancelID = GetMaxOperCancelCancelID(operationCanceled.OperCanceled);
            operationCanceled.OperCanceled.OPER_ID = opsche.OPER_ID;
            operationCanceled.OperCanceled.CANCEL_ID = ++CancelID;
            bool flag = dapper.Set<MED_OPERATION_CANCELED>().Insert(operationCanceled.OperCanceled);

            if (operationCanceled.AnesInputDict != null && operationCanceled.AnesInputDict.Count > 0)
            {
                foreach (var item in operationCanceled.AnesInputDict)
                {
                    dapper.Set<MED_OPERATION_CANCELED_DETAIL>().Insert(new MED_OPERATION_CANCELED_DETAIL
                    {
                        PATIENT_ID = operationCanceled.OperCanceled.PATIENT_ID,
                        VISIT_ID = operationCanceled.OperCanceled.VISIT_ID,
                        CANCEL_ID = operationCanceled.OperCanceled.CANCEL_ID,
                        CANCEL_CLASS = item.ITEM_CLASS,
                        CANCEL_TYPE = item.ITEM_NAME
                    });
                }
            }
            if (flag)
            {
                opsche.OPER_ROOM_NO = null;
                opsche.SEQUENCE = 0;
                opsche.OPERATING_TIME = 0;
                //opsche.ANES_CONFIRM = 0;
                //opsche.NURSE_CONFIRM = 0;
                opsche.FIRST_OPER_NURSE = null;
                opsche.FIRST_SUPPLY_NURSE = null;
                opsche.ANES_DOCTOR = null;
                opsche.FIRST_ANES_ASSISTANT = null;
                opsche.OPER_STATUS_CODE = -80;
                dapper.Set<MED_OPERATION_SCHEDULE>().Update(opsche, d => new
                {
                    d.OPER_ROOM_NO,
                    d.SEQUENCE,
                    d.OPERATING_TIME,
                    //d.ANES_CONFIRM,
                    //d.NURSE_CONFIRM,
                    d.FIRST_OPER_NURSE,
                    d.FIRST_SUPPLY_NURSE,
                    d.ANES_DOCTOR,
                    d.FIRST_ANES_ASSISTANT,
                    d.OPER_STATUS_CODE,
                });


                master.OPER_STATUS_CODE = -80;

                dapper.Set<MED_OPERATION_MASTER>().Update(master, d => new
                {
                    d.OPER_STATUS_CODE,
                });

                //if (AppSettings.OpenHIS212)
                //{
                //    SyncInfoService.SyncWrite_OPER504W(opsche.PATIENT_ID, opsche.VISIT_ID, opsche.SCHEDULE_ID);
                //}

                result = flag ? 1 : 0;
            }

            dapper.SaveChanges();



            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private int GetMaxOperCancelCancelID(MED_OPERATION_CANCELED item)
        {
            string sql_GetMaxOperCancelCancelID = sqlDict.GetSQLByKey("GetMaxOperCancelCancelID");
            return dapper.ExecuteScalar<int>(sql_GetMaxOperCancelCancelID, new { PatientID = item.PATIENT_ID, VisitID = item.VISIT_ID, ScheduleID = item.SCHEDULE_ID });
        }


        /// <summary>
        /// 获取未上传、或者未上传完整的患者列表
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        public List<AnesDocumentPDFSrcEntity> GetUnUploadPatientInfos(OperQueryParaModel model)
        {
            string sql = sqlDict.GetSQLByKey("GetUnUploadPatientInfos");
            List<AnesDocumentPDFSrcEntity> list = dapper.Set<AnesDocumentPDFSrcEntity>().Query(sql, new { STARTDATE = model.StartDate, ENDDATE = model.EndDate, Nurse = model.Nurse });


            return list;
        }

    }
}
