using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Dapper.Data;
using MedicalSystem.DataServices.WebApi;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using Newtonsoft.Json;
using MedicalSystem.AnesWorkStation.Model;
using System.Reflection;
using System.Web;
using System.Collections.Specialized;
using System.IO;
using System.Configuration;
using MedicalSystem.AnesWorkStation.Domain.Report;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 通用接口
    /// </summary>
    public interface ICommonService
    {
        /// <summary>
        /// 测试连接
        /// </summary>
        bool TestNet();

        /// <summary>
        /// 测试数据库连接
        /// </summary>
        bool TestDbConn();

        /// <summary>
        /// 获取服务器当前时间
        /// </summary>
        /// <returns></returns>
        DateTime GetServerTime();

        List<MED_QIXIE_TEMPLET_MASTER> GetQiXieTempletMaster();

        List<MED_DOCUMENT_TEMPLET> GetDocumentTemplet();

        List<MED_QIXIE_TEMPLET_DETAIL> GetQiXieTempletDetail(string strGuid);

        bool SaveDocumentTemplet(MED_DOCUMENT_TEMPLET row);

        bool SaveChangeRoomNo(List<MED_CHANGE_ROOM_NO> list);
        bool SaveOperationJump(List<MED_OPERATION_JUMP> list);
        List<MED_CHANGE_ROOM_NO> GetChangeRoomNo(string patientID, int visitID, int operID);
        List<MED_OPERATION_JUMP> GetOperationJump(string patientID, int visitID, int operID);
        List<MED_OPERATION_CANCELED> GetOperationCanceled(string patientID, int visitID);
        bool SaveOperationCanceled(List<MED_OPERATION_CANCELED> list);
        bool SaveOperationScreen(List<MED_SCREEN_MSG> list);
        List<MED_OPERATION_CANCELED_DETAIL> GetOperationCanceledDetail(string patientID, int visitID, int cancelID);
        bool SaveOperationCanceledDetail(List<MED_OPERATION_CANCELED_DETAIL> list);
        List<MED_TRANSPORT_MESSAGE> GetTransportMessage(string strOperRoomNo);

        bool SaveTransportMessage(List<MED_TRANSPORT_MESSAGE> list);

        List<MED_TRANSPORT_MESSAGE> GetNotReadTransportMessage(string strOperRoomNo);

        List<MED_LAB_TEST_MASTER> GetMedLabTestMaster(string patientId, int visitId);

        List<MED_LAB_RESULT> GetMedLabResult(string testNo);

        List<MED_LAB_RESULT> GetMedLabResult(string patientId, int visitId);

        List<MED_LAB_PATIENT> GetLabPatientList(string patientID, int visitID);
        List<MED_OPERATION_RESCUE> GetOperationRescue(string patientID, int visitID, int operID);
        List<MED_INTERFACE_DETAIL> GetInterfaceDetail();
        bool SaveOperationRescue(List<MED_OPERATION_RESCUE> list);

        /// <summary>
        /// 使用事务批量处理数据,传递的参数一定是TransactionParamsters.ToString()
        /// </summary>
        bool UpdateByTransaction(dynamic dyParams);

        int PostFile(dynamic dyParams);


        List<KeyValue> GetDict(QueryDictConfig config);

        /// <summary>
        /// 根据条件获取MED_ANESTHESIA_CONFIG表的麻醉方法分类数据
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        List<string> GetAnesConfigByParams(string para);

        int PostPDFFile(dynamic dyParams);

        List<MED_VER_INFO> GetVerInfoList(string appID);
    }

    /// <summary>
    /// 通用类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommonService : BaseService<CommonService>, ICommonService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected CommonService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public CommonService(IDapperContext context)
            : base(context)
        {
        }
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual bool TestNet()
        {
            return true;
        }

        /// <summary>
        /// 测试数据库连接
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual bool TestDbConn()
        {
            if (dapper.Connection.State != System.Data.ConnectionState.Open)
            {
                dapper.Connection.Open();
            }
            return true;
        }

        /// <summary>
        /// 获取服务器当前时间
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual DateTime GetServerTime()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 更改单个类型的数据
        /// </summary>
        /// <typeparam name="T">数据表类型</typeparam>
        /// <param name="strValue">传递过来的序列化字符串</param>
        public void UpdateSingleItem<T>(string strValue, ref bool isFindTable) where T : BaseModel
        {
            isFindTable = true;
            List<T> tempList = JsonConvert.DeserializeObject<List<T>>(strValue);
            this.UpdateWholeList(tempList);
        }

        /// <summary>
        /// 使用事务批量处理数据,传递的参数一定是TransactionParamsters.ToString()
        /// </summary>
        [HttpPost]
        public virtual bool UpdateByTransaction(dynamic transParams)
        {
            bool Result = true;

            bool isFindTable = false;
            TransactionParamsters tp = JsonConvert.DeserializeObject<TransactionParamsters>(transParams.ToString());
            if (null != tp)
            {
                foreach (KeyValuePair<Type, string> item in tp)
                {
                    isFindTable = false;
                    if (item.Key.Equals(typeof(MED_BLOOD_GAS_DETAIL_EXT)))
                    {
                        this.UpdateSingleItem<MED_BLOOD_GAS_DETAIL_EXT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ANESTHESIA_EVENT)))
                    {
                        this.UpdateSingleItem<MED_ANESTHESIA_EVENT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_EVENT_SORT)))
                    {
                        this.UpdateSingleItem<MED_EVENT_SORT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_BLOOD_GAS_DETAIL)))
                    {
                        this.UpdateSingleItem<MED_BLOOD_GAS_DETAIL>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_BLOOD_GAS_MASTER)))
                    {
                        this.UpdateSingleItem<MED_BLOOD_GAS_MASTER>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_MASTER)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_MASTER>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ANESTHESIA_PLAN)))
                    {
                        this.UpdateSingleItem<MED_ANESTHESIA_PLAN>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_NAME)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_NAME>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PATS_IN_HOSPITAL)))
                    {
                        this.UpdateSingleItem<MED_PATS_IN_HOSPITAL>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_SHIFT_RECORD)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_SHIFT_RECORD>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ANESTHESIA_INPUT_DATA)))
                    {
                        this.UpdateSingleItem<MED_ANESTHESIA_INPUT_DATA>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_CHANGE_ROOM_NO)))
                    {
                        this.UpdateSingleItem<MED_CHANGE_ROOM_NO>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_JUMP)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_JUMP>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATING_ROOM)))
                    {
                        this.UpdateSingleItem<MED_OPERATING_ROOM>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_MONITOR_DICT)))
                    {
                        this.UpdateSingleItem<MED_MONITOR_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_CANCELED)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_CANCELED>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_CANCELED_DETAIL)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_CANCELED_DETAIL>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ADMINISTRATION_DICT)))
                    {
                        this.UpdateSingleItem<MED_ADMINISTRATION_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ALDRETE_SCORING_RESULT)))
                    {
                        this.UpdateSingleItem<MED_ALDRETE_SCORING_RESULT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ANES_ALARM_MESSAGE)))
                    {
                        this.UpdateSingleItem<MED_ANES_ALARM_MESSAGE>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ANESTHESIA_DICT)))
                    {
                        this.UpdateSingleItem<MED_ANESTHESIA_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ANESTHESIA_EVENT_LOG)))
                    {
                        this.UpdateSingleItem<MED_ANESTHESIA_EVENT_LOG>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ANESTHESIA_EVENT_TEMPLET)))
                    {
                        this.UpdateSingleItem<MED_ANESTHESIA_EVENT_TEMPLET>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ANESTHESIA_INPUT_DICT)))
                    {
                        this.UpdateSingleItem<MED_ANESTHESIA_INPUT_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ANESTHESIA_INQUIRY)))
                    {
                        this.UpdateSingleItem<MED_ANESTHESIA_INQUIRY>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ANESTHESIA_PLAN_EXAM)))
                    {
                        this.UpdateSingleItem<MED_ANESTHESIA_PLAN_EXAM>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ANESTHESIA_PLAN_PMH)))
                    {
                        this.UpdateSingleItem<MED_ANESTHESIA_PLAN_PMH>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ANESTHESIA_RECOVER)))
                    {
                        this.UpdateSingleItem<MED_ANESTHESIA_RECOVER>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_APACHE2_SCORING_RESULT)))
                    {
                        this.UpdateSingleItem<MED_APACHE2_SCORING_RESULT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_APPLICATIONS)))
                    {
                        this.UpdateSingleItem<MED_APPLICATIONS>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_BALTHAZAR_SCORING_RESULT)))
                    {
                        this.UpdateSingleItem<MED_BALTHAZAR_SCORING_RESULT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_BILL_ITEM_CLASS_DICT)))
                    {
                        this.UpdateSingleItem<MED_BILL_ITEM_CLASS_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_BLOOD_GAS_DICT)))
                    {
                        this.UpdateSingleItem<MED_BLOOD_GAS_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_CHILDPUGH_SCORING_RESULT)))
                    {
                        this.UpdateSingleItem<MED_CHILDPUGH_SCORING_RESULT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_CLIENT_COMPUTER)))
                    {
                        this.UpdateSingleItem<MED_CLIENT_COMPUTER>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_COMM_VITAL_REC)))
                    {
                        this.UpdateSingleItem<MED_COMM_VITAL_REC>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_COMM_VITAL_REC_EXTEND)))
                    {
                        this.UpdateSingleItem<MED_COMM_VITAL_REC_EXTEND>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_CONFIG)))
                    {
                        this.UpdateSingleItem<MED_CONFIG>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_CONFIRMATION_PACU)))
                    {
                        this.UpdateSingleItem<MED_CONFIRMATION_PACU>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_CONSULTATION_REGISTRATION)))
                    {
                        this.UpdateSingleItem<MED_CONSULTATION_REGISTRATION>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_DAILY_SCHEDULE)))
                    {
                        this.UpdateSingleItem<MED_DAILY_SCHEDULE>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_DEPT_DICT)))
                    {
                        this.UpdateSingleItem<MED_DEPT_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_DIAGNOSIS_DICT)))
                    {
                        this.UpdateSingleItem<MED_DIAGNOSIS_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_DOCUMENT_TEMPLET)))
                    {
                        this.UpdateSingleItem<MED_DOCUMENT_TEMPLET>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_EMR_ARCHIVE_DETIAL)))
                    {
                        this.UpdateSingleItem<MED_EMR_ARCHIVE_DETIAL>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_EVENT_DICT)))
                    {
                        this.UpdateSingleItem<MED_EVENT_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_EVENT_DICT_EXT)))
                    {
                        this.UpdateSingleItem<MED_EVENT_DICT_EXT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_EVENT_ITEM_CLASS_DICT)))
                    {
                        this.UpdateSingleItem<MED_EVENT_ITEM_CLASS_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_EVENT_VS_BILL)))
                    {
                        this.UpdateSingleItem<MED_EVENT_VS_BILL>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_EXAM_MASTER)))
                    {
                        this.UpdateSingleItem<MED_EXAM_MASTER>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_EXAM_REPORT)))
                    {
                        this.UpdateSingleItem<MED_EXAM_REPORT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_GOLDMAN_SCORING_RESULT)))
                    {
                        this.UpdateSingleItem<MED_GOLDMAN_SCORING_RESULT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_HIS_USERS)))
                    {
                        this.UpdateSingleItem<MED_HIS_USERS>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_HIS_USERS_INFO)))
                    {
                        this.UpdateSingleItem<MED_HIS_USERS_INFO>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_HOSP_BRANCH_DICT)))
                    {
                        this.UpdateSingleItem<MED_HOSP_BRANCH_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_HOSPITAL_CONFIG)))
                    {
                        this.UpdateSingleItem<MED_HOSPITAL_CONFIG>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_LAB_RESULT)))
                    {
                        this.UpdateSingleItem<MED_LAB_RESULT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_LAB_TEST_MASTER)))
                    {
                        this.UpdateSingleItem<MED_LAB_TEST_MASTER>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_LUTZ_SCORING_RESULT)))
                    {
                        this.UpdateSingleItem<MED_LUTZ_SCORING_RESULT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_MESSAGE_LOG)))
                    {
                        this.UpdateSingleItem<MED_MESSAGE_LOG>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_MESSAGE_TEMPLET)))
                    {
                        this.UpdateSingleItem<MED_MESSAGE_TEMPLET>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_METHOD_DICT)))
                    {
                        this.UpdateSingleItem<MED_METHOD_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_MONITOR_DICT)))
                    {
                        this.UpdateSingleItem<MED_MONITOR_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_MONITOR_FUNCTION_CODE)))
                    {
                        this.UpdateSingleItem<MED_MONITOR_FUNCTION_CODE>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPER_ANALGESIC_MEDICINE)))
                    {
                        this.UpdateSingleItem<MED_OPER_ANALGESIC_MEDICINE>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPER_ANALGESIC_TOTAL)))
                    {
                        this.UpdateSingleItem<MED_OPER_ANALGESIC_TOTAL>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPER_RISK_ESTIMATE)))
                    {
                        this.UpdateSingleItem<MED_OPER_RISK_ESTIMATE>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATING_ROOM)))
                    {
                        this.UpdateSingleItem<MED_OPERATING_ROOM>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATING_ROOM_VS_MONITOR)))
                    {
                        this.UpdateSingleItem<MED_OPERATING_ROOM_VS_MONITOR>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_ANALGESIC_MASTER)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_ANALGESIC_MASTER>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_BILL_DETAIL)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_BILL_DETAIL>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_BILL_MASTER)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_BILL_MASTER>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_DICT)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_EXTENDED)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_EXTENDED>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_LOG)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_LOG>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_MASTER_EXT)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_MASTER_EXT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_RESCUE)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_RESCUE>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_SCHEDULE)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_SCHEDULE>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_SCHEDULE_NAME)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_SCHEDULE_NAME>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_STATUS_DICT)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_STATUS_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERATION_STATUS_EXT)))
                    {
                        this.UpdateSingleItem<MED_OPERATION_STATUS_EXT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_OPERSCORE_DICT)))
                    {
                        this.UpdateSingleItem<MED_OPERSCORE_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ORDERS)))
                    {
                        this.UpdateSingleItem<MED_ORDERS>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PACU_SORCE)))
                    {
                        this.UpdateSingleItem<MED_PACU_SORCE>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PARS_SCORING_RESULT)))
                    {
                        this.UpdateSingleItem<MED_PARS_SCORING_RESULT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PAT_MASTER_INDEX)))
                    {
                        this.UpdateSingleItem<MED_PAT_MASTER_INDEX>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PAT_MONITOR_DATA)))
                    {
                        this.UpdateSingleItem<MED_PAT_MONITOR_DATA>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PAT_MONITOR_DATA_DICT)))
                    {
                        this.UpdateSingleItem<MED_PAT_MONITOR_DATA_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PAT_MONITOR_DATA_EXT)))
                    {
                        this.UpdateSingleItem<MED_PAT_MONITOR_DATA_EXT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PAT_MONITOR_DATA_LOG)))
                    {
                        this.UpdateSingleItem<MED_PAT_MONITOR_DATA_LOG>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PAT_VISIT)))
                    {
                        this.UpdateSingleItem<MED_PAT_VISIT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PATIENT_MONITOR_CONFIG)))
                    {
                        this.UpdateSingleItem<MED_PATIENT_MONITOR_CONFIG>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PATIENT_SCORING_RESULT)))
                    {
                        this.UpdateSingleItem<MED_PATIENT_SCORING_RESULT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PATS_IN_HOSPITAL)))
                    {
                        this.UpdateSingleItem<MED_PATS_IN_HOSPITAL>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PERIOPERATIVE_EVENT_CONFIG)))
                    {
                        this.UpdateSingleItem<MED_PERIOPERATIVE_EVENT_CONFIG>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PERIOPERATIVE_EVENT_INDEX)))
                    {
                        this.UpdateSingleItem<MED_PERIOPERATIVE_EVENT_INDEX>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PERMISSIONS)))
                    {
                        this.UpdateSingleItem<MED_PERMISSIONS>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_POSTOPERATIVE_EXTENDED)))
                    {
                        this.UpdateSingleItem<MED_POSTOPERATIVE_EXTENDED>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PREOPERATIVE_EXPANSION)))
                    {
                        this.UpdateSingleItem<MED_PREOPERATIVE_EXPANSION>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_PRIMARY_FIELD_MODIFY)))
                    {
                        this.UpdateSingleItem<MED_PRIMARY_FIELD_MODIFY>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_QIXIE_QINGDIAN)))
                    {
                        this.UpdateSingleItem<MED_QIXIE_QINGDIAN>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_QIXIE_TEMPLET_DETAIL)))
                    {
                        this.UpdateSingleItem<MED_QIXIE_TEMPLET_DETAIL>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_QIXIE_TEMPLET_MASTER)))
                    {
                        this.UpdateSingleItem<MED_QIXIE_TEMPLET_MASTER>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_RESCUE_EXPERTS)))
                    {
                        this.UpdateSingleItem<MED_RESCUE_EXPERTS>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_RESCUE_EXPERTS_GROUP)))
                    {
                        this.UpdateSingleItem<MED_RESCUE_EXPERTS_GROUP>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_RESCUE_GROUP)))
                    {
                        this.UpdateSingleItem<MED_RESCUE_GROUP>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_RESCUE_GROUP_VS_DEPT)))
                    {
                        this.UpdateSingleItem<MED_RESCUE_GROUP_VS_DEPT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_RESCUE_MESSAGE_LOG)))
                    {
                        this.UpdateSingleItem<MED_RESCUE_MESSAGE_LOG>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ROLES)))
                    {
                        this.UpdateSingleItem<MED_ROLES>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_ROLES_PERMISSIONS)))
                    {
                        this.UpdateSingleItem<MED_ROLES_PERMISSIONS>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_SAFETY_CHECKS)))
                    {
                        this.UpdateSingleItem<MED_SAFETY_CHECKS>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_SCREEN_MSG)))
                    {
                        this.UpdateSingleItem<MED_SCREEN_MSG>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_SHIFT_OPERATION_DATA)))
                    {
                        this.UpdateSingleItem<MED_SHIFT_OPERATION_DATA>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_SHIFT_OPERATION_FILES)))
                    {
                        this.UpdateSingleItem<MED_SHIFT_OPERATION_FILES>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_SHIFT_OPERATION_MASTER)))
                    {
                        this.UpdateSingleItem<MED_SHIFT_OPERATION_MASTER>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_SHIFT_OPERATION_SIGN)))
                    {
                        this.UpdateSingleItem<MED_SHIFT_OPERATION_SIGN>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_STEWARD_MARK)))
                    {
                        this.UpdateSingleItem<MED_STEWARD_MARK>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_STEWARD_SCORING_RESULT)))
                    {
                        this.UpdateSingleItem<MED_STEWARD_SCORING_RESULT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_TISS_SCORING_RESULT_DETAIL)))
                    {
                        this.UpdateSingleItem<MED_TISS_SCORING_RESULT_DETAIL>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_TRANSPORT_MESSAGE)))
                    {
                        this.UpdateSingleItem<MED_TRANSPORT_MESSAGE>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_UNIT_DICT)))
                    {
                        this.UpdateSingleItem<MED_UNIT_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_USER_MESSAGES)))
                    {
                        this.UpdateSingleItem<MED_USER_MESSAGES>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_USER_NOTE)))
                    {
                        this.UpdateSingleItem<MED_USER_NOTE>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_USERS)))
                    {
                        this.UpdateSingleItem<MED_USERS>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_USERS_ROLES)))
                    {
                        this.UpdateSingleItem<MED_USERS_ROLES>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(MED_WARD_DICT)))
                    {
                        this.UpdateSingleItem<MED_WARD_DICT>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(SCHEDULEREPORTVIEW)))
                    {
                        this.UpdateSingleItem<SCHEDULEREPORTVIEW>(item.Value, ref isFindTable);
                    }
                    else if (item.Key.Equals(typeof(SHIFT_OPERATION_INFO)))
                    {
                        this.UpdateSingleItem<SHIFT_OPERATION_INFO>(item.Value, ref isFindTable);
                    }

                    // 没有找到对应的数据表时主动抛出异常
                    if (!isFindTable)
                    {
                        throw new Exception(string.Format("批量更改数据时，在UpdateByTransaction方法中没有找到对应的类型表：{0}进行解析，请添加数据表！",
                                                          item.Key.FullName));
                    }
                }

                dapper.SaveChanges();
            }
            else
            {
                Result = false;
            }

            return Result;
        }

        [HttpGet]
        public virtual List<MED_QIXIE_TEMPLET_MASTER> GetQiXieTempletMaster()
        {
            List<MED_QIXIE_TEMPLET_MASTER> templetMaster = dapper.Set<MED_QIXIE_TEMPLET_MASTER>().Select();
            return templetMaster;
        }

        [HttpGet]
        public virtual List<MED_DOCUMENT_TEMPLET> GetDocumentTemplet()
        {
            List<MED_DOCUMENT_TEMPLET> docTemplet = dapper.Set<MED_DOCUMENT_TEMPLET>().Select();
            return docTemplet;
        }

        [HttpGet]
        public virtual List<MED_QIXIE_TEMPLET_DETAIL> GetQiXieTempletDetail(string strGuid)
        {
            return dapper.Set<MED_QIXIE_TEMPLET_DETAIL>().Select(x => x.TEMPLET_GUID.Equals(strGuid));
        }

        [HttpPost]
        public virtual bool SaveDocumentTemplet(MED_DOCUMENT_TEMPLET row)
        {
            bool ret = false;
            try
            {
                ret = dapper.Set<MED_DOCUMENT_TEMPLET>().Insert(row);
                dapper.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        /// <summary>
        /// 更新数据到数据库
        /// </summary>
        [HttpPost]
        public virtual bool SaveChangeRoomNo(List<MED_CHANGE_ROOM_NO> list)
        {
            bool flag = UpdateWholeList(list);
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 更新数据到数据库
        /// </summary>
        [HttpPost]
        public virtual bool SaveOperationJump(List<MED_OPERATION_JUMP> list)
        {
            bool flag = UpdateWholeList(list);
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 根据ID获取对应的数据表
        /// </summary>
        [HttpGet]
        public virtual List<MED_CHANGE_ROOM_NO> GetChangeRoomNo(string patientID, int visitID, int operID)
        {
            List<MED_CHANGE_ROOM_NO> result = dapper.Set<MED_CHANGE_ROOM_NO>().
                                                     Select(x => x.PATIENT_ID.Equals(patientID) && x.VISIT_ID == visitID && x.OPER_ID == operID).
                                                     OrderByDescending(x => x.CHANGE_NO).ToList();
            return result;
        }

        /// <summary>
        /// 根据ID获取对应的数据表
        /// </summary>
        [HttpGet]
        public virtual List<MED_OPERATION_JUMP> GetOperationJump(string patientID, int visitID, int operID)
        {
            List<MED_OPERATION_JUMP> result = dapper.Set<MED_OPERATION_JUMP>().
                                                     Select(x => x.PATIENT_ID.Equals(patientID) && x.VISIT_ID == visitID && x.OPER_ID == operID).
                                                     OrderByDescending(x => x.JUMP_DATE).ToList();
            return result;
        }

        /// <summary>
        /// 获得手术取消
        /// </summary>
        [HttpGet]
        public virtual List<MED_OPERATION_CANCELED> GetOperationCanceled(string patientID, int visitID)
        {
            List<MED_OPERATION_CANCELED> result = dapper.Set<MED_OPERATION_CANCELED>().
                                                         Select(x => x.PATIENT_ID.Equals(patientID) && x.VISIT_ID == visitID).
                                                         OrderByDescending(x => x.CANCEL_ID).ToList();
            return result;
        }

        /// <summary>
        /// 获得抢救明细
        /// </summary>
        [HttpGet]
        public virtual List<MED_OPERATION_RESCUE> GetOperationRescue(string patientID, int visitID, int operID)
        {
            List<MED_OPERATION_RESCUE> result = dapper.Set<MED_OPERATION_RESCUE>().
                                                         Select(x => x.PATIENT_ID.Equals(patientID) && x.VISIT_ID == visitID && x.OPER_ID == operID).
                                                         OrderByDescending(x => x.RESCUE_ID).ToList();
            return result;
        }

        /// <summary>
        /// 保存抢救明细
        /// </summary>
        [HttpPost]
        public virtual bool SaveOperationRescue(List<MED_OPERATION_RESCUE> list)
        {
            bool flag = UpdateWholeList(list);
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 保存手术取消
        /// </summary>
        [HttpPost]
        public virtual bool SaveOperationCanceled(List<MED_OPERATION_CANCELED> list)
        {
            bool flag = UpdateWholeList(list);
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 保存家属大屏信息
        /// </summary>
        [HttpPost]
        public virtual bool SaveOperationScreen(List<MED_SCREEN_MSG> list)
        {
            bool flag = UpdateWholeList(list);
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 获得手术取消明细表
        /// </summary>
        [HttpGet]
        public virtual List<MED_OPERATION_CANCELED_DETAIL> GetOperationCanceledDetail(string patientID, int visitID, int cancelID)
        {
            List<MED_OPERATION_CANCELED_DETAIL> result = dapper.Set<MED_OPERATION_CANCELED_DETAIL>().
                                                                Select(x => x.PATIENT_ID.Equals(patientID) && x.VISIT_ID == visitID && x.CANCEL_ID == cancelID).
                                                                OrderByDescending(x => x.CANCEL_ID).ToList();
            return result;
        }

        /// <summary>
        /// 保存手术取消明细
        /// </summary>
        [HttpPost]
        public virtual bool SaveOperationCanceledDetail(List<MED_OPERATION_CANCELED_DETAIL> list)
        {
            //int i = dapper.Set<MED_OPERATION_CANCELED_DETAIL>().Insert(list);
            //dapper.SaveChanges();
            bool flag = UpdateWholeList(list);
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 获取当前手术间的消息
        /// </summary>
        [HttpGet]
        public virtual List<MED_TRANSPORT_MESSAGE> GetTransportMessage(string strOperRoomNo)
        {
            List<MED_TRANSPORT_MESSAGE> result = dapper.Set<MED_TRANSPORT_MESSAGE>().
                                                        Select(x => x.TARGET_ROOM_NO.Equals(strOperRoomNo) || x.SOURCE_ROOM_NO.Equals(strOperRoomNo)).
                                                        OrderByDescending(x => x.TRANS_DATE).ToList();

            return result;
        }

        /// <summary>
        /// 获取当前手术间未读取的消息
        /// </summary>
        [HttpGet]
        public virtual List<MED_TRANSPORT_MESSAGE> GetNotReadTransportMessage(string strOperRoomNo)
        {
            List<MED_TRANSPORT_MESSAGE> result = dapper.Set<MED_TRANSPORT_MESSAGE>().
                                                        Select(x => x.TARGET_ROOM_NO.Equals(strOperRoomNo) && x.HAS_READ == 0).
                                                        OrderByDescending(x => x.TRANS_DATE).ToList();

            return result;
        }

        /// <summary>
        /// 保存消息
        /// </summary>
        [HttpPost]
        public virtual bool SaveTransportMessage(List<MED_TRANSPORT_MESSAGE> list)
        {
            bool flag = UpdateWholeList(list);
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 获取检验信息主信息
        /// </summary>
        [HttpGet]
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
        [HttpGet]
        public virtual List<MED_LAB_RESULT> GetMedLabResult(string testNo)
        {
            List<MED_LAB_RESULT> result = dapper.Set<MED_LAB_RESULT>().Select(x => x.TEST_NO.Equals(testNo)).ToList();
            return result;
        }

        /// <summary>
        /// 根据患者ID获取检验结果明细
        /// </summary>
        [HttpGet]
        public virtual List<MED_LAB_RESULT> GetMedLabResult(string patientId, int visitId)
        {
            string strSql = string.Format(@"SELECT A.* FROM MED_LAB_RESULT A
                                            LEFT JOIN MED_LAB_TEST_MASTER B ON A.TEST_NO=B.TEST_NO
                                            WHERE B.PATIENT_ID='{0}' AND B.VISIT_ID={1}", patientId, visitId);
            List<MED_LAB_RESULT> result = dapper.Query<MED_LAB_RESULT>(strSql, null);
            return result;
        }

        [HttpGet]
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

        [HttpGet]
        public virtual List<MED_INTERFACE_DETAIL> GetInterfaceDetail()
        {
            return this.dapper.Set<MED_INTERFACE_DETAIL>().Select();
        }

        /// <summary>
        /// 上传日志文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual int PostFile(dynamic file)
        {
            string operatingRoom = file.OperRoomNo;
            string fileName = file.FileName;

            Dictionary<string, string> dicFiles = new Dictionary<string, string>();

            string UploadFileAddress = ConfigurationManager.AppSettings["LogUpdateAddress"];//文件上传的文件存储地址

            string root = UploadFileAddress + "\\" + operatingRoom + "\\";//指定要将文件存入的服务器物理位置

            // 根目录文件夹地址
            if (!Directory.Exists(root))//判断文件夹是否存在 
            {
                Directory.CreateDirectory(root);//不存在则创建文件夹 
            }

            byte[] file1 = file.FILE;
            if (!string.IsNullOrEmpty(fileName))
            {
                string filePath = root + "\\" + fileName;

                FileStream fs = new FileStream(filePath, FileMode.Create);
                fs.Write(file1, 0, file1.Length);
                fs.Close();
                dicFiles.Add(fileName, filePath);
            }

            if (dicFiles.Count > 0)
            { return 1; }
            else { return 0; }
        }


        public List<KeyValue> GetDict(QueryDictConfig config)
        {
            int count = config.Romote ? 50 : 500; //实时检索返回前50行数据
            string key = config.Key == null ? "" : config.Key.ToUpper();
            List<KeyValue> result = new List<KeyValue>();

            string operDept = AppSettings.OperDeptCode;

            switch (config.DictType)
            {
                case "ASADict":
                    //result.Add(new KeyValue() { Key = "Ⅰ级", Value = "Ⅰ级", InputCode = "1" });
                    //result.Add(new KeyValue() { Key = "Ⅱ级", Value = "Ⅱ级", InputCode = "2" });
                    //result.Add(new KeyValue() { Key = "Ⅲ级", Value = "Ⅲ级", InputCode = "3" });
                    //result.Add(new KeyValue() { Key = "Ⅳ级", Value = "Ⅳ级", InputCode = "4" });
                    //result.Add(new KeyValue() { Key = "Ⅴ级", Value = "Ⅴ级", InputCode = "5" });
                    //result.Add(new KeyValue() { Key = "Ⅵ级", Value = "Ⅵ级", InputCode = "6" });
                    result = dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Select(d => d.ITEM_CLASS == "ASA分级").OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.ITEM_NAME, Value = x.ITEM_NAME, InputCode = x.INPUT_CODE }).ToList();
                    break;
                case "OperScaleDict":
                    result = dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Select(d => d.ITEM_CLASS == "手术等级").OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.ITEM_NAME, Value = x.ITEM_NAME, InputCode = x.INPUT_CODE }).ToList();
                    break;
                case "DoctorNurseDict":
                    if (config.IsLocal)
                    {
                        result = dapper.Set<MED_HIS_USERS>().Select().OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.USER_JOB_ID, Value = x.USER_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    else
                    {
                        result = dapper.Set<MED_HIS_USERS>().Select(d => d.USER_JOB_ID.Contains(key) || d.USER_NAME.Contains(key) || d.INPUT_CODE.Contains(key)).OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.USER_JOB_ID, Value = x.USER_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    break;
                case "NurseDict":
                    if (config.IsLocal)
                    {
                        result = dapper.Set<MED_HIS_USERS>().Select(d => d.USER_JOB.Contains("护士")).OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.USER_JOB_ID, Value = x.USER_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    else
                    {
                        result = dapper.Set<MED_HIS_USERS>().Select(d => d.USER_JOB.Contains("护士") && (d.USER_JOB_ID.Contains(key) || d.USER_NAME.Contains(key) || d.INPUT_CODE.Contains(key))).OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.USER_JOB_ID, Value = x.USER_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    break;
                case "NurseDictInOperRoom":
                    if (config.IsLocal)
                    {
                        result = dapper.Set<MED_HIS_USERS>().Select(d => d.USER_DEPT_CODE == operDept && d.USER_JOB.Contains("护士")).OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.USER_JOB_ID, Value = x.USER_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    else
                    {
                        result = dapper.Set<MED_HIS_USERS>().Select(d => d.USER_DEPT_CODE == operDept && d.USER_JOB.Contains("护士") && (d.USER_JOB_ID.Contains(key) || d.USER_NAME.Contains(key) || d.INPUT_CODE.Contains(key))).OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.USER_JOB_ID, Value = x.USER_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    break;
                case "AnesDoctorDict":
                    if (config.IsLocal)
                    {
                        result = dapper.Set<MED_HIS_USERS>().Select(d => d.USER_JOB.Contains("医生")).OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.USER_JOB_ID, Value = x.USER_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    else
                    {
                        result = dapper.Set<MED_HIS_USERS>().Select(d => d.USER_JOB.Contains("医生") && (d.USER_JOB_ID.Contains(key) || d.USER_NAME.Contains(key) || d.INPUT_CODE.Contains(key))).OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.USER_JOB_ID, Value = x.USER_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    break;
                case "SurgeonDict":
                    if (config.IsLocal)
                    {
                        result = dapper.Set<MED_HIS_USERS>().Select().OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.USER_JOB_ID, Value = x.USER_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    else
                    {
                        result = dapper.Set<MED_HIS_USERS>().Select(d => (d.USER_JOB_ID.Contains(key) || d.USER_NAME.Contains(key) || d.INPUT_CODE.Contains(key))).OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.USER_JOB_ID, Value = x.USER_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    break;
                case "DeptDict":
                    if (config.IsLocal)
                    {
                        result = dapper.Set<MED_DEPT_DICT>().Select().OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.DEPT_CODE, Value = x.DEPT_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    else
                    {
                        result = dapper.Set<MED_DEPT_DICT>().Select(d => d.DEPT_CODE.Contains(key) || d.DEPT_NAME.Contains(key) || d.INPUT_CODE.Contains(config.Key)).Take(count).OrderBy(d => d.INPUT_CODE).Take(count).Select(x => new KeyValue() { Key = x.DEPT_CODE, Value = x.DEPT_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    break;
                case "AnesMethodDict":
                    if (config.IsLocal)
                    {
                        result = dapper.Set<MED_ANESTHESIA_DICT>().Select().OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.ANAESTHESIA_NAME, Value = x.ANAESTHESIA_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    else
                    {
                        result = dapper.Set<MED_ANESTHESIA_DICT>().Select(d => (d.ANAESTHESIA_NAME.Contains(key) || d.INPUT_CODE.Contains(key))).OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.ANAESTHESIA_NAME, Value = x.ANAESTHESIA_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    break;
                case "OperNameDict":
                    if (config.IsLocal)
                    {
                        result = dapper.Set<MED_OPERATION_DICT>().Select().OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.OPER_NAME, Value = x.OPER_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    else
                    {
                        result = dapper.Set<MED_OPERATION_DICT>().Select(d => (d.OPER_NAME.Contains(key) || d.INPUT_CODE.Contains(key))).OrderBy(d => d.INPUT_CODE).Take(count).Select(x => new KeyValue() { Key = x.OPER_NAME, Value = x.OPER_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    break;
                case "DiagnosisDict":
                    if (config.IsLocal)
                    {
                        result = dapper.Set<MED_DIAGNOSIS_DICT>().Select().OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.DIAGNOSIS_NAME, Value = x.DIAGNOSIS_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    else
                    {
                        result = dapper.Set<MED_DIAGNOSIS_DICT>().Select(d => (d.DIAGNOSIS_NAME.Contains(key) || d.INPUT_CODE.Contains(key))).OrderBy(d => d.INPUT_CODE).Take(count).Select(x => new KeyValue() { Key = x.DIAGNOSIS_NAME, Value = x.DIAGNOSIS_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    break;
                case "OperatingRoomDict":
                    // AppSettings.OperDeptCode  是否需要添加科室配置
                    if (config.IsLocal)
                    {
                        result = dapper.Set<MED_OPERATING_ROOM>().Select().OrderBy(d => d.ROOM_NO).Select(x => new KeyValue()
                        {
                            Key = x.ROOM_NO
                            ,
                            Value = x.BED_LABEL
                        }).ToList();
                    }
                    else
                    {
                        result = dapper.Set<MED_OPERATING_ROOM>().Select(d => d.ROOM_NO.Contains(key)).OrderBy(d => d.ROOM_NO).Take(count).Select(x => new KeyValue() { Key = x.ROOM_NO, Value = x.BED_LABEL }).ToList();
                    }
                    break;
                case "OperPosition":
                    // 体位字典
                    if (config.IsLocal)
                    {
                        result = dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Select(x => x.ITEM_CLASS.Equals("手术体位")).Select(x => new KeyValue() { Key = x.ITEM_NAME, Value = x.ITEM_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    else
                    {
                        result = dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Select(x => x.ITEM_CLASS.Equals("手术体位") && (x.ITEM_NAME.Contains(key) || x.INPUT_CODE.Contains(key))).Select(x => new KeyValue() { Key = x.ITEM_NAME, Value = x.ITEM_NAME, InputCode = x.INPUT_CODE }).ToList();
                    }
                    break;
                case "DynamicDict":
                    //if (DictObj != "")
                    //{
                    //    string sqlstr = string.Format("SELECT {0} as Key,{1} as Value From {2} WHERE 1=1 {3}",
                    //        reportCondition.DynamicDictDes.KeyColumn,
                    //        reportCondition.DynamicDictDes.ValColumn,
                    //        reportCondition.DynamicDictDes.TableName,
                    //        string.IsNullOrWhiteSpace(reportCondition.DynamicDictDes.Condition) ? "" : "AND " + reportCondition.DynamicDictDes.Condition);
                    //    result = dapper.Query<KeyValue>(sqlstr);
                    //}
                    //else
                    //{
                    //    result = new List<KeyValue>();
                    //}
                    break;
                default:
                    break;
            }
            return result;
        }

        [HttpGet]
        public virtual List<string> GetAnesConfigByParams(string para)
        {
            List<string> _list = new List<string>();
            if (!string.IsNullOrEmpty(para))
            {
                string sqlText = @"SELECT C.ITEM_VALUE FROM MED_ANESTHESIA_CONFIG C 
            START WITH C.ITEM_VALUE = '" + para + "'  CONNECT BY PRIOR C.ITEM_ID = C.ITEM_PARENTID ";

                _list = dapper.Query<string>(sqlText, null);
            }
            return _list;
        }

        [HttpGet]
        public virtual List<MED_VER_INFO> GetVerInfoList(string appID)
        {
            string sql = string.Format(@"SELECT A.* FROM MED_VER_INFO A
                                         LEFT JOIN MED_APP_INFO B ON A.APP_ID=B.APP_ID
                                         WHERE B.APP_KEY='{0}'", appID);
            List<MED_VER_INFO> list = dapper.Query<MED_VER_INFO>(sql);
            return list;
        }

        /// <summary>
        /// 上传文书PDF文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual int PostPDFFile(dynamic file)
        {
            string patientID = file.PatientID;
            string visitID = file.VisitID;
            string fileName = file.FileName;

            Dictionary<string, string> dicFiles = new Dictionary<string, string>();

            string UploadFileAddress = ConfigurationManager.AppSettings["PDFUpdateAddress"];//文件上传的文件存储地址

            string patientID1 = patientID.Substring(patientID.Length - 3, 3);
            string patientID2 = patientID.Substring(0, patientID.Length - 3);

            string root = UploadFileAddress + "\\" + patientID1 + "\\" + patientID2 + "\\" + visitID + "\\";//指定要将文件存入的服务器物理位置

            // 根目录文件夹地址
            if (!Directory.Exists(root))//判断文件夹是否存在 
            {
                Directory.CreateDirectory(root);//不存在则创建文件夹 
            }

            byte[] file1 = file.FILE;
            if (!string.IsNullOrEmpty(fileName))
            {
                string filePath = root + "\\" + fileName;

                FileStream fs = new FileStream(filePath, FileMode.Create);
                fs.Write(file1, 0, file1.Length);
                fs.Close();
                dicFiles.Add(fileName, filePath);
            }

            if (dicFiles.Count > 0)
            { return 1; }
            else { return 0; }
        }
    }
}
