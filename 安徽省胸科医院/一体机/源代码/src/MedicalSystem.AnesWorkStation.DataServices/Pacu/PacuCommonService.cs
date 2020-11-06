using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Linq.Expressions;

namespace MedicalSystem.AnesWorkStation.DataServices
{

    public interface IPacuCommonService
    {
        int GetMaxCancelID(string patientID, int visitID);
        List<STANDARD_KEYWORD> GetAcsContextByKeyWord(string keyWord);
        DataTable GetAcsArticleKeyWord();
        bool UpdateDataTable(string sql);
        int UpdateOperationCanceled(MED_OPERATION_CANCELED item);
        //List<MED_OPERATION_CANCELED> GetOperationCanceled(string patientID, int visitID, string reserved1);
        List<MED_ANESTHESIA_EVENT_TEMPLET> GetAnesEventTemplet(string templetName);
        List<MED_ANESTHESIA_EVENT_TEMPLET> GetAnesEventTempletAll();

        bool SaveAnesEventTempletList(List<MED_ANESTHESIA_EVENT_TEMPLET> item);
        int DelAnesEventTemplet(MED_ANESTHESIA_EVENT_TEMPLET item);
        List<MED_DOCUMENT_TEMPLET> GetDocumentTemplet();
        int SaveDocumentTemplet(MED_DOCUMENT_TEMPLET item);
        int SaveDocumentTempletList(List<MED_DOCUMENT_TEMPLET> item);
        List<MED_QIXIE_TEMPLET_MASTER> GetQiXieTempletMaster();
        int SaveQiXieMaster(MED_QIXIE_TEMPLET_MASTER item);
        int SaveQiXieMasterList(List<MED_QIXIE_TEMPLET_MASTER> item);
        List<MED_QIXIE_TEMPLET_DETAIL> GetQiXieTempletDetail(string templetGuid);
        int SaveQiXieDetailList(List<MED_QIXIE_TEMPLET_DETAIL> item);
        List<MED_OPERATION_EXTENDED> GetOperExtended(string patientID, int visitID, int operID);
        List<MED_POSTOPERATIVE_EXTENDED> GetPostoperativeExtended(string patientID, int visitID, int operID);
        List<MED_PREOPERATIVE_EXPANSION> GetPreoperativeExpansion(string patientID, int visitID, int operID);
        int SaveOperExtendedList(List<MED_OPERATION_EXTENDED> item);
        int SavePostExtendedList(List<MED_POSTOPERATIVE_EXTENDED> item);
        int SavePreExpansionList(List<MED_PREOPERATIVE_EXPANSION> item);
        List<MED_SCREEN_MSG> GetScreenMsgList();
        int SaveScreenMsg(MED_SCREEN_MSG item);
        List<MED_EMR_ARCHIVE_DETIAL> GetEmrArchiveList(string patientID, int visitID, string operID, string docName);
        List<MED_EMR_ARCHIVE_DETIAL> GetEmrArchiveListByStatus(string patientID, int visitID, string operID);
        int SaveEmrArchiveList(List<MED_EMR_ARCHIVE_DETIAL> item);
        List<MED_BJCA_SIGN> GetBjcaSignList(string patientID, int visitID, int operID);
        int SaveBjcaSign(MED_BJCA_SIGN item);
        int UpdateBjcaSignList(List<MED_BJCA_SIGN> item);

        List<MED_LAB_TEST_MASTER> GetMedLabTestMaster(string patientId, int visitId);

        List<MED_LAB_RESULT> GetMedLabResult(string testNo);

        List<MED_LAB_RESULT> GetMedLabResult(string patientId, int visitId);

        List<MED_LAB_PATIENT> GetLabPatientList(string patientID, int visitID);
    }

    public class PacuCommonService : BaseService<PacuCommDictService>, IPacuCommonService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PacuCommonService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PacuCommonService(IDapperContext context)
            : base(context)
        {
        }

        public int GetMaxCancelID(string patientID, int visitID)
        {
            string sqlText = @"SELECT NVL(MAX(CANCEL_ID), 0) AS CANCEL_ID FROM MED_OPERATION_CANCELED WHERE PATIENT_ID = '" + patientID + "' AND VISIT_ID = '" + visitID + "' ";
            int data = dapper.Set<MED_OPERATION_CANCELED>().Query(sqlText).Select(x => x.CANCEL_ID).FirstOrDefault();
            return data;
        }


        public List<STANDARD_KEYWORD> GetAcsContextByKeyWord(string keyWord)
        {
            List<STANDARD_KEYWORD> acsContent = new List<STANDARD_KEYWORD>();
            string sqlText = @"SELECT T1.WORD , T2.* FROM STANDARD_ARTICLE_KEYWORD T1 
                               LEFT JOIN STANDARD_ARTICLE T2 ON T1.ART_ID = T2.ART_ID 
                              WHERE T1.WORD LIKE";
            sqlText += " '%" + keyWord + "%'";

            DapperContext context = new DapperContext("AcsConn");

            IDapperSet<STANDARD_KEYWORD> _standardRepository = context.Set<STANDARD_KEYWORD>();

            acsContent = _standardRepository.Query(sqlText) as List<STANDARD_KEYWORD>;

            return acsContent;

        }

        public DataTable GetAcsArticleKeyWord()
        {
            DataTable acsContent = new DataTable();

            string sqlText = @"SELECT * FROM STANDARD_ARTICLE_KEYWORD";

            DapperContext context = new DapperContext("AcsConn");

            acsContent = context.Fill(sqlText);

            return acsContent;
        }


        /// <summary>
        /// 修改访问麻醉5.0数据库
        /// </summary>
        /// <param name="strAnesFiveConnection">5.0数据库连接字符串</param>
        /// <param name="sql">执行的sql语句</param>
        public virtual bool UpdateDataTable(string sql)
        {
            bool result = true;
            DapperContext context = new DapperContext("Anes5");
            OracleConnection con = new OracleConnection(context.Connection.ConnectionString);
            try
            {
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }

                OracleCommand command = new OracleCommand(sql, con);
                command.CommandType = System.Data.CommandType.Text;

                result = command.ExecuteNonQuery() > 0;
            }
            catch
            {
                result = false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

            return result;
        }

        public int UpdateOperationCanceled(MED_OPERATION_CANCELED item)
        {
            int result = dapper.Set<MED_OPERATION_CANCELED>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        //public List<MED_OPERATION_CANCELED> GetOperationCanceled(string patientID, int visitID, string reserved1)
        //{
        //    return dapper.Set<MED_OPERATION_CANCELED>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.RESERVED1 == reserved1);
        //}

        public List<MED_ANESTHESIA_EVENT_TEMPLET> GetAnesEventTemplet(string templetName)
        {
            return dapper.Set<MED_ANESTHESIA_EVENT_TEMPLET>().Select(d => d.TEMPLET_NAME == templetName).OrderByDescending(t => t.EVENT_ITEM_NO).ToList();
        }

        public List<MED_ANESTHESIA_EVENT_TEMPLET> GetAnesEventTempletAll()
        {
            return dapper.Set<MED_ANESTHESIA_EVENT_TEMPLET>().Select().OrderBy(t => t.TEMPLET_NAME).ToList();
        }

        public bool SaveAnesEventTempletList(List<MED_ANESTHESIA_EVENT_TEMPLET> itemList)
        {
            int num = 0;
            foreach (var item in itemList)
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
                        num += dapper.Set<MED_ANESTHESIA_EVENT_TEMPLET>().Delete(item) ? 1 : 0;
                        break;
                    default:
                        break;
                }
            }
            dapper.SaveChanges();
            return itemList.Count() == num;
        }

        public int DelAnesEventTemplet(MED_ANESTHESIA_EVENT_TEMPLET item)
        {
            int result = dapper.Set<MED_ANESTHESIA_EVENT_TEMPLET>().Delete(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public List<MED_DOCUMENT_TEMPLET> GetDocumentTemplet()
        {
            return dapper.Set<MED_DOCUMENT_TEMPLET>().Select();
        }

        public int SaveDocumentTemplet(MED_DOCUMENT_TEMPLET item)
        {
            int result = dapper.Set<MED_DOCUMENT_TEMPLET>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public int SaveDocumentTempletList(List<MED_DOCUMENT_TEMPLET> item)
        {
            int result = dapper.Set<MED_DOCUMENT_TEMPLET>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public List<MED_QIXIE_TEMPLET_MASTER> GetQiXieTempletMaster()
        {
            return dapper.Set<MED_QIXIE_TEMPLET_MASTER>().Select();
        }

        public int SaveQiXieMaster(MED_QIXIE_TEMPLET_MASTER item)
        {
            int result = dapper.Set<MED_QIXIE_TEMPLET_MASTER>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public int SaveQiXieMasterList(List<MED_QIXIE_TEMPLET_MASTER> item)
        {
            int result = dapper.Set<MED_QIXIE_TEMPLET_MASTER>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public List<MED_QIXIE_TEMPLET_DETAIL> GetQiXieTempletDetail(string templetGuid)
        {
            return dapper.Set<MED_QIXIE_TEMPLET_DETAIL>().Select(d => d.TEMPLET_GUID == templetGuid).OrderByDescending(t => t.SERIAL_NO).ToList();
        }

        public int SaveQiXieDetailList(List<MED_QIXIE_TEMPLET_DETAIL> item)
        {
            int result = dapper.Set<MED_QIXIE_TEMPLET_DETAIL>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public List<MED_OPERATION_EXTENDED> GetOperExtended(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_OPERATION_EXTENDED>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).OrderByDescending(t => t.ITEM_NAME).ToList();
        }

        public List<MED_POSTOPERATIVE_EXTENDED> GetPostoperativeExtended(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_POSTOPERATIVE_EXTENDED>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).OrderByDescending(t => t.ITEM_NAME).ToList();
        }

        public List<MED_PREOPERATIVE_EXPANSION> GetPreoperativeExpansion(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_PREOPERATIVE_EXPANSION>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).OrderByDescending(t => t.ITEM_NAME).ToList();
        }

        public int SaveOperExtendedList(List<MED_OPERATION_EXTENDED> item)
        {
            int result = dapper.Set<MED_OPERATION_EXTENDED>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public int SavePostExtendedList(List<MED_POSTOPERATIVE_EXTENDED> item)
        {

            int result = dapper.Set<MED_POSTOPERATIVE_EXTENDED>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public int SavePreExpansionList(List<MED_PREOPERATIVE_EXPANSION> item)
        {

            int result = dapper.Set<MED_PREOPERATIVE_EXPANSION>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public List<MED_SCREEN_MSG> GetScreenMsgList()
        {
            return dapper.Set<MED_SCREEN_MSG>().Select(d => d.STATUS == 1 && d.TYPE == 2).OrderBy(t => t.INSERT_TIME).ToList();
        }

        public int SaveScreenMsg(MED_SCREEN_MSG item)
        {
            int result = dapper.Set<MED_SCREEN_MSG>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public List<MED_EMR_ARCHIVE_DETIAL> GetEmrArchiveList(string patientID, int visitID, string operID, string docName)
        {
            return dapper.Set<MED_EMR_ARCHIVE_DETIAL>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.ARCHIVE_KEY == operID && d.MR_SUB_CLASS == docName).OrderBy(t => t.ARCHIVE_TIMES).ToList();
        }

        public List<MED_EMR_ARCHIVE_DETIAL> GetEmrArchiveListByStatus(string patientID, int visitID, string operID)
        {
            return dapper.Set<MED_EMR_ARCHIVE_DETIAL>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.ARCHIVE_KEY == operID && d.ARCHIVE_STATUS != "作废").OrderBy(t => t.ARCHIVE_TIMES).ToList();
        }

        public int SaveEmrArchiveList(List<MED_EMR_ARCHIVE_DETIAL> item)
        {
            int result = dapper.Set<MED_EMR_ARCHIVE_DETIAL>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public List<MED_BJCA_SIGN> GetBjcaSignList(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_BJCA_SIGN>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID).OrderByDescending(t => t.SIGNDATE).ToList();
        }

        public int SaveBjcaSign(MED_BJCA_SIGN item)
        {
            int result = dapper.Set<MED_BJCA_SIGN>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public int UpdateBjcaSignList(List<MED_BJCA_SIGN> item)
        {
            int result = dapper.Set<MED_BJCA_SIGN>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        /// <summary>
        /// 获取检验信息主信息
        /// </summary>
        public virtual List<MED_LAB_TEST_MASTER> GetMedLabTestMaster(string patientId, int visitId)
        {
            List<MED_LAB_TEST_MASTER> result = dapper.Set<MED_LAB_TEST_MASTER>().
                                                      Select(x => x.PATIENT_ID.Equals(patientId) && x.VISIT_ID == visitId).
                                                      OrderByDescending(x => x.SPCM_RECEIVED_DATE_TIME).ToList();
            return result;
        }

        /// <summary>
        /// 获取检验信息明细
        /// </summary>
        public virtual List<MED_LAB_RESULT> GetMedLabResult(string testNo)
        {
            List<MED_LAB_RESULT> result = dapper.Set<MED_LAB_RESULT>().Select(x => x.TEST_NO.Equals(testNo)).ToList();
            return result;
        }

        /// <summary>
        /// 根据患者ID获取检验结果明细
        /// </summary>
        public virtual List<MED_LAB_RESULT> GetMedLabResult(string patientId, int visitId)
        {
            string strSql = string.Format(@"SELECT A.* FROM MED_LAB_RESULT A
                                            LEFT JOIN MED_LAB_TEST_MASTER B ON A.TEST_NO=B.TEST_NO
                                            WHERE B.PATIENT_ID='{0}' AND B.VISIT_ID={1}", patientId, visitId);
            List<MED_LAB_RESULT> result = dapper.Query<MED_LAB_RESULT>(strSql, null);
            return result;
        }

        public virtual List<MED_LAB_PATIENT> GetLabPatientList(string patientID, int visitID)
        {
            List<MED_LAB_PATIENT> LabPatientList = new List<MED_LAB_PATIENT>();
            string sqlText = @"SELECT B.PATIENT_ID,B.VISIT_ID, A.REPORT_ITEM_NAME, A.RESULT, A.UNITS, B.TEST_CAUSE,A.ABNORMAL_INDICATOR,A.REFERENCE_RESULT,B.RESULTS_RPT_DATE_TIME as RESULT_DATE_TIME
                               FROM MED_LAB_RESULT A, MED_LAB_TEST_MASTER B
                               WHERE A.TEST_NO = B.TEST_NO ";
            sqlText += " AND B.PATIENT_ID='" + patientID + "' AND B.VISIT_ID=" + visitID;
            sqlText += " ORDER BY B.RESULTS_RPT_DATE_TIME DESC ";
            LabPatientList = dapper.Query<MED_LAB_PATIENT>(sqlText, null);
            return LabPatientList;
        }
    }
}
