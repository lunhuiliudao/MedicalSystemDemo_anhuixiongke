
using MedicalSystem.AnesPlatform.Service.WebApi.App_Start.Swagger;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using MedicalSystem.Common.FileManage;
using MedicalSystem.Common.HttpManage;
using MedicalSystem.Configurations;
using MedicalSystem.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Xml;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Platform
{
    /// <summary>
    /// 质控管理
    /// </summary>
    [ControllerGroup("质控管理", "接口")]
    public class PlatformQuanlityControlController : PlatformBaseController
    {
        IPlatformQuanlityControlService QuanlityControlService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="QuanlityControlServiceParam">参数</param>
        public PlatformQuanlityControlController(IPlatformQuanlityControlService QuanlityControlServiceParam)
        {
            QuanlityControlService = QuanlityControlServiceParam;
        }

        /// <summary>
        /// 获取质控报表数据
        /// </summary>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_QC_REPORT_LIST>> GetQuanlityControlReportItemList(DateTime reportMonth)
        {
            string param = reportMonth.ToString("yyyyMM");
            return Success(QuanlityControlService.GetQuanlityControlReportItemList(param));
        }

        /// <summary>
        /// 获取质控报表备份数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_QC_REPORT_LIST>> GetQuanlityControlReportBakItemList(string reportName, string isOutRoomOper)
        {
            return Success(QuanlityControlService.GetQuanlityControlReportBakItemList(reportName, isOutRoomOper));
        }

        /// <summary>
        /// 是否已经上报质控数据
        /// </summary>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<int> IsQuanlityControlDataUpload(string reportMonth)
        {
            return Success(QuanlityControlService.IsQuanlityControlDataUpload(reportMonth));
        }

        /// <summary>
        /// 是否已经上报质控数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<int> IsQuanlityControlDataUploadByReportName(string reportName)
        {
            return Success(QuanlityControlService.IsQuanlityControlDataUploadByReportName(reportName));
        }

        /// <summary>
        /// 同步质控数据
        /// </summary>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_QC_REPORT_LIST>> SyncQuanlityControlData(DateTime reportMonth)
        {
            string param = reportMonth.ToString("yyyyMM");
            string errorMessage = QuanlityControlService.SyncQuanlityControlData(param);
            return Success(QuanlityControlService.GetQuanlityControlReportItemList(param), errorMessage);
        }

        /// <summary>
        /// 转存质控备份数据以及不良事件数据
        /// </summary>
        /// <param name="reportMonth"></param>
        /// <param name="name"></param>
        [HttpGet]
        public RequestResult<string> AddQuanlityControlReportDataBak([FromUri]DateTime reportMonth, [FromUri]string name)
        {
            string param = reportMonth.ToString("yyyyMM");
            return Success(QuanlityControlService.AddQuanlityControlReportDataBak(param, name));
        }

        /// <summary>
        /// 保存质控备份数据
        /// </summary>
        /// <param name="medQcReportList"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> SaveQuanlityControlReportDataBak(dynamic obj)
        {
            List<MED_QC_REPORT_LIST> medQcReportList = JsonConvert.DeserializeObject<List<MED_QC_REPORT_LIST>>(JsonConvert.SerializeObject(obj.medQcReportList));

            string isOutRoomOper = (string)obj.isOutRoomOper;

            return QuanlityControlService.SaveQuanlityControlReportDataBak(medQcReportList, isOutRoomOper);
        }

        /// <summary>
        /// 获取不良事件备份数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_QC_AE_BAK>> GetQuanlityControlAeBakDataByReportName(string reportName)
        {
            return Success(QuanlityControlService.GetQuanlityControlAeBakDataByReportName(reportName));
        }

        /// <summary>
        /// 获取备份不良事件患者基本信息数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_QC_PATIENT_INFO>> GetQuanlityControlAeBakPatientInfoDataByReportName(string reportName)
        {
            return Success(QuanlityControlService.GetQuanlityControlAeBakPatientInfoDataByReportName(reportName));
        }

        /// <summary>
        /// 获取备份不良事件患者基本信息数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="reportNo">MED_QC_REPORT_LIST表 REPORT_NO </param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_QC_PATIENT_INFO>> GetQuanlityControlAeBakPatientInfoDataByReportNameAndReportNo(string reportName, string reportNo)
        {
            return Success(QuanlityControlService.GetQuanlityControlAeBakPatientInfoDataByReportNameAndReportNo(reportName, reportNo));
        }

        /// <summary>
        /// 获取备份不良事件患者基本信息数据
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="reportNo">MED_QC_REPORT_LIST表 REPORT_NO </param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_QC_PATIENT_INFO>> GetQuanlityControlAeBakPatientInfoDataByReportNameAndReportNoOut(string reportName, string reportNo)
        {
            return Success(QuanlityControlService.GetQuanlityControlAeBakPatientInfoDataByReportNameAndReportNoOut(reportName, reportNo));
        }

        /// <summary>
        /// 获取质控项目字典数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_QC_ITEM>> GetQuanlityControlItemList()
        {
            return Success(QuanlityControlService.GetQuanlityControlItemList());
        }

        /// <summary>
        /// 保存不良事件备份数据上传标志
        /// </summary>
        /// <param name="medQcPatientInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public void SaveQuanlityControlAeBakData(List<MED_QC_PATIENT_INFO> medQcPatientInfo)
        {
            QuanlityControlService.SaveQuanlityControlAeBakData(medQcPatientInfo);
        }

        /// <summary>
        /// 保存不良事件备份数据上传标志
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> UploadQuanlityControlAeBakData(dynamic obj)
        {
            string reportId = (string)obj.REPORT_ID;
            string patientId = (string)obj.PATIENT_ID;
            int visitId = (int)obj.VISIT_ID;
            int operId = (int)obj.OPER_ID;
            string reportNo = (string)obj.REPORT_NO;
            int upload = (int)obj.UPLOAD;

            return Success<int>(QuanlityControlService.UploadQuanlityControlAeBakData(reportId, patientId, visitId, operId, reportNo, upload));
        }

        /// <summary>
        /// 获取主索引数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_QC_REPORT_IND>> GetQuanlityControlReportInd()
        {
            return Success(QuanlityControlService.GetQuanlityControlReportInd());
        }


        /// <summary>
        /// 获取主索引数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_QC_REPORT_IND>> GetQuanlityControlReportInd2()
        {
            return Success(QuanlityControlService.GetQuanlityControlReportInd2());
        }

        /// <summary>
        /// 保存主索引数据上传标志
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> SaveQuanlityControlReportInd(dynamic obj)
        {
            string reportId = (string)obj.reportId;
            int status = (int)obj.status;
            string LoginUserId = (string)obj.LoginUserId;

            // 质控云平台用户名密码
            string QcCloudName = (string)obj.QcCloudName;
            string QcCloudPwd = (string)obj.QcCloudPwd;

            RequestResult<int> type = new Domain.RequestResult.RequestResult<int>();

            type = QuanlityControlService.SaveQuanlityControlReportInd(reportId, status, LoginUserId);

            if (type.Data == 1)
            {
                #region 调用质控云平台服务上报数据接口

                List<MED_QC_REPORT_IND> indList = QuanlityControlService.GetQuanlityControlReportIndByReportId(reportId);

                if (indList.Count > 0)
                {
                    string reportName = indList[0].REPORT_NAME;

                    List<MED_QC_REPORT_DATA_BAK> reportDataBakList = QuanlityControlService.GetQuanlityControlReportDataBakAll(reportName);

                    List<MED_QC_PATIENT_INFO> patientInfoList = QuanlityControlService.GetQuanlityControlAeBakPatientInfoDataByReportNameNoGroupBy(reportName);

                    List<MED_QC_ITEM> medQcItemList = QuanlityControlService.GetQuanlityControlItemList() as List<MED_QC_ITEM>;

                    IMdkConfiguration mdkConfig = MdkConfiguration.GetConfig();

                    QcDictXMLHelper helper = new QcDictXMLHelper();

                    helper.XmlPath = mdkConfig.XmlDict.XmlPath;

                    List<QcDictXMLHelper.QcDictGroup> lstASA = helper.GetGroupByName("质控上报ASA分级适配");//ASA分级适配

                    List<QcDictXMLHelper.QcDictGroup> lstAnesMethod = helper.GetGroupByName("质控上报麻醉方法适配");//麻醉方法适配

                    List<QcDictXMLHelper.QcDictGroup> lstReportItem = helper.GetGroupByName("质控上报17项适配");//17项适配

                    List<QcDictXMLHelper.QcDictGroup> lstSex = helper.GetGroupByName("质控上报性别适配");//性别适配

                    List<QcDictXMLHelper.QcDictGroup> lstOperType = helper.GetGroupByName("质控上报手术类型适配（急诊择期）");//手术类型适配

                    List<QcDictXMLHelper.QcDictGroup> lstEventCause = helper.GetGroupByName("质控上报不良事件因素适配");//不良因素发生的原因适配

                    List<QcDictXMLHelper.QcDictGroup> lstEventType = helper.GetGroupByName("质控上报不良事件类型适配");//不良事件类型适配

                    List<QcDictXMLHelper.QcDictGroup> lstDeptCode = helper.GetGroupByName("质控上报科室适配");//科室适配


                    #region 定义模型

                    QC.WebInterfaceModel.DataModel dataModel = new QC.WebInterfaceModel.DataModel();//回传数据封装的数据模型

                    List<QC.WebInterfaceModel.PatientModel> patientModelList = new List<QC.WebInterfaceModel.PatientModel>();//不良事件患者数据模型

                    QC.WebInterfaceModel.ReportModel reportModel = new QC.WebInterfaceModel.ReportModel();//质控报告数据模型

                    QC.WebInterfaceModel.UserModel userModel = new QC.WebInterfaceModel.UserModel();//质控用户数据模型


                    //QC.WebInterfaceModel.SecurityHelper ;//加解密助手类

                    #endregion

                    // 质控报告数据

                    #region 设置userModel内容

                    userModel.UserName = QcCloudName;
                    userModel.UserPwd = QcCloudPwd;

                    #endregion

                    #region 设置reportModel内容
                    object reportModelJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(reportModel));

                    Dictionary<string, object> list = reportModelJson as Dictionary<string, object>;

                    List<string> keylist = new List<string>();
                    keylist.AddRange(list.Keys);

                    List<QcUploadJsonModel> qcUploadJsonModelList = new List<QcUploadJsonModel>();

                    for (int i = 0; i < keylist.Count; i++)
                    {

                        string item = keylist[i];

                        if (!string.IsNullOrEmpty(item))
                        {
                            string qcCode = string.Empty;

                            qcCode = lstReportItem.Find(t => t.Key == item) != null ? lstReportItem.Find(t => t.Key == item).Value : "";

                            // 设置reportModel内容 

                            //if (!string.IsNullOrEmpty(qcCode))
                            //{
                            //    MED_QC_REPORT_DATA_BAK reportDataBak = reportDataBakList.Find(t => t.QC_CODE == qcCode);

                            //    if (reportDataBak != null)
                            //    {
                            //        list[item] = (int)reportDataBak.QC_VALUE;
                            //    }
                            //}
                            //else
                            //{
                            if (item == "ReportDate") // 报告时间（ex: 2016/12）
                            {
                                list[item] = indList[0].REPORT_MONTH.Substring(0, 4) + "/" + indList[0].REPORT_MONTH.Substring(4, 2);
                            }
                            else if (item == "IndexConfig")// 指标配置版本（需动态配置，各省的编号不一样）
                            {
                                list[item] = AppSettings.ProvincialNo; // //省区编号 湖北 29  
                            }
                            else if (item == "ReportDetailJson")//json格式给数据
                            {
                                foreach (MED_QC_REPORT_DATA_BAK dataBak in reportDataBakList)
                                {
                                    MED_QC_ITEM find = medQcItemList.Find(t => t.QC_CODE == dataBak.QC_CODE);
                                    if (find != null)
                                    {
                                        if (!string.IsNullOrEmpty(find.REPORT_CODE.Trim()))
                                        {
                                            //string[] array = find.REPORT_CODE.Split('-');

                                            //if (array.Length >= 2 && !string.IsNullOrEmpty(array[1]))
                                            {
                                                qcUploadJsonModelList.Add(new QcUploadJsonModel()
                                                {
                                                    ITEM_CODE = find.REPORT_CODE.Trim(),
                                                    ITEM_VALUE = (int)dataBak.QC_VALUE
                                                });
                                            }
                                        }
                                    }
                                }

                                list[item] = JsonConvert.SerializeObject(qcUploadJsonModelList);
                            }
                            //}
                        }
                    }

                    reportModel = JsonConvert.DeserializeObject<QC.WebInterfaceModel.ReportModel>(JsonConvert.SerializeObject(list));

                    #endregion 设置reportModel内容

                    #region 设置patientModel内容

                    if (patientInfoList.Count > 0)
                    {
                        foreach (MED_QC_PATIENT_INFO info in patientInfoList)
                        {
                            QC.WebInterfaceModel.PatientModel patientModel = new QC.WebInterfaceModel.PatientModel();//不良事件患者数据模型

                            //住院号
                            patientModel.AdamissionNo = info.INP_NO;

                            //麻醉结束时间
                            patientModel.AnesthEnd = info.ANES_END_TIME != null ? info.ANES_END_TIME : "";

                            //麻醉开始时间
                            patientModel.AnesthStart = info.ANES_START_TIME != null ? info.ANES_START_TIME : "";

                            //ASA分级
                            patientModel.ASA = info.ASA_GRADE != null ? (lstASA.Find(t => t.Value.Contains(info.ASA_GRADE)) != null ?
                                lstASA.Find(t => t.Value.Contains(info.ASA_GRADE)).Key : lstASA.Find(t => t.Value.Contains("NULL")).Key) :
                                lstASA.Find(t => t.Value.Contains("NULL")).Key;

                            //出生日期
                            patientModel.Birth = info.DATE_OF_BIRTH != null ? info.DATE_OF_BIRTH : "";

                            //诊断
                            patientModel.Diagnosis = info.DIAG_AFTER_OPERATION != null ? info.DIAG_AFTER_OPERATION : "";

                            //不良事件发生原因分析
                            patientModel.EventAnalysis = info.UNEXPECT_EVENT_REASON != null ? info.UNEXPECT_EVENT_REASON : "";//手术原因、麻醉原因、患者原因 对应的原因分析

                            //不良事件发生原因
                            patientModel.EventCause = info.EventCause != null ? (lstEventCause.Find(t => info.EventCause.Contains(t.Value)) != null ?
                                info.EventCause.Replace(lstEventCause.Find(t => info.EventCause.Contains(t.Value)).Value,
                                lstEventCause.Find(t => info.EventCause.Contains(t.Value)).Key) :
                                lstEventCause.Find(t => t.Value.Contains("NULL")).Key) : lstEventCause.Find(t => t.Value.Contains("NULL")).Key;//手术原因、麻醉原因、患者原因

                            //不良事件发生经过
                            patientModel.EventProcedure = info.EVENT_COURSE != null ? info.EVENT_COURSE : "";

                            //不良事件类型
                            //patientModel.EventType = info.AE_DETAIL_CODE != null ? (lstEventType.Find(t => t.Value.Contains(info.AE_DETAIL_CODE)) != null ?
                            //    lstEventType.Find(t => t.Value.Contains(info.AE_DETAIL_CODE)).Key : lstEventType.Find(t => t.Value.Contains("NULL")).Key)
                            //    : lstEventType.Find(t => t.Value.Contains("NULL")).Key;

                            if (!string.IsNullOrEmpty(info.REPORT_CODE.Trim()))
                            {
                                if (info.REPORT_CODE.Trim().Contains("21_"))//国标
                                {
                                    patientModel.EventType = info.REPORT_CODE.Trim();
                                }
                                else //如果未配置上报编码，则传名称到其它事件类型中。
                                {
                                    patientModel.EventOtherType = info.AE_DETAIL;
                                }

                                //string[] array = info.REPORT_CODE.Split('-');

                                //if (info.REPORT_CODE.Contains("GB"))//国标
                                //{
                                //    //不良事件类型
                                //    if (array.Length >= 2)
                                //    {
                                //        if (!string.IsNullOrEmpty(array[1]))
                                //        {
                                //            patientModel.EventType = array[1];
                                //        }
                                //        else
                                //        {
                                //            patientModel.EventOtherType = info.AE_DETAIL;//如果未配置上报编码，则传名称到其它事件类型中。
                                //        }
                                //    }
                                //    else
                                //    {
                                //        patientModel.EventOtherType = info.AE_DETAIL;//如果未配置上报编码，则传名称到其它事件类型中。
                                //    }
                                //}
                                //else if (info.REPORT_CODE.Contains("DB"))//地标
                                //{
                                //    //不良事件“其它”类型

                                //    if (array.Length >= 2)
                                //    {
                                //        if (!string.IsNullOrEmpty(array[1]))
                                //        {
                                //            patientModel.EventOtherType = array[1];
                                //        }
                                //        else
                                //        {
                                //            patientModel.EventOtherType = info.AE_DETAIL;
                                //        }
                                //    }
                                //    else
                                //    {
                                //        patientModel.EventOtherType = info.AE_DETAIL;
                                //    }
                                //}
                                //else
                                //{
                                //    if (array.Length > 0 && !string.IsNullOrEmpty(array[0].Trim()))//如果未配置上报编码，则传名称到其它事件类型中。
                                //    {
                                //        patientModel.EventType = array[0].Trim();
                                //    }
                                //    else
                                //    {
                                //        patientModel.EventOtherType = info.AE_DETAIL;
                                //    }
                                //}
                            }
                            else//如果未配置上报编码，则传名称到其它事件类型中。
                            {
                                patientModel.EventOtherType = info.AE_DETAIL;
                            }



                            //身高
                            patientModel.Height = info.BODY_HEIGHT != null ? info.BODY_HEIGHT : "";

                            //预防措施
                            patientModel.Measure = info.PREVENT_STEP != null ? info.PREVENT_STEP : "";

                            //麻醉方法
                            patientModel.Method = info.ANES_METHOD != null ? (lstAnesMethod.Find(t => t.Value.Contains(info.ANES_METHOD)) != null ?
                                lstAnesMethod.Find(t => t.Value.Contains(info.ANES_METHOD)).Key : lstAnesMethod.Find(t => t.Value.Contains("NULL")).Key)
                                : lstAnesMethod.Find(t => t.Value.Contains("NULL")).Key;

                            //手术次数
                            patientModel.Oper = info.OPER_ID.ToString();

                            //手术科室
                            patientModel.OperDept = info.DEPT_CODE != null ? (lstDeptCode.Find(t => t.Value.Contains(info.DEPT_CODE)) != null ?
                               lstDeptCode.Find(t => t.Value.Contains(info.DEPT_CODE)).Key : lstDeptCode.Find(t => t.Value.Contains("NULL")).Key) :
                               lstDeptCode.Find(t => t.Value.Contains("NULL")).Key;

                            //手术类别  //EMERGENCY_IND 0 择期 1 急诊   ；  OperMode  2  择期   1 急诊 
                            patientModel.OperMode = info.EMERGENCY_IND != null ? (lstOperType.Find(t => t.Value.Contains(info.EMERGENCY_IND)) != null ?
                                lstOperType.Find(t => t.Value.Contains(info.EMERGENCY_IND)).Key : lstOperType.Find(t => t.Value.Contains("NULL")).Key) :
                                lstOperType.Find(t => t.Value.Contains("NULL")).Key;

                            //手术名称
                            patientModel.OperName = info.OPERATION_NAME != null ? info.OPERATION_NAME : "";

                            //患者姓名
                            patientModel.PatientName = info.NAME != null ? info.NAME : "";

                            //性别       
                            patientModel.Sex = info.SEX != null ? (lstSex.Find(t => t.Value.Contains(info.SEX)) != null ?
                                lstSex.Find(t => t.Value.Contains(info.SEX)).Key : lstSex.Find(t => t.Value.Contains("NULL")).Key) :
                                lstSex.Find(t => t.Value.Contains("NULL")).Key;

                            //住院次数
                            patientModel.Visit = info.VISIT_ID.ToString();
                            //体重
                            patientModel.Weight = info.BODY_WEIGHT != null ? info.BODY_WEIGHT : "";

                            //文件地址
                            patientModel.FolderId = Guid.Empty.ToString();

                            //不良事件分级
                            patientModel.EventLevel = info.EVENT_GRADE != null ? info.EVENT_GRADE : "";

                            patientModelList.Add(patientModel);
                        }

                    }
                    #endregion  设置patientModel内容


                    #region 调用上报接口


                    bool NetInterFlow = false;

                    bool.TryParse(AppSettings.NetInterFlow, out NetInterFlow);

                    if (NetInterFlow == true)//true 表示内外网互通，false表示不通
                    {
                        #region 内外网互通的调用方式
                        string getTokenUri = GetQcUploadAddress("GetToken").Data;//获取Token

                        string tokenResult = AsyncHandleData.Get(getTokenUri);

                        var jsonDataToken = JsonConvert.DeserializeObject<ResponseResult>(tokenResult);

                        if (jsonDataToken.Status == 1)
                        {
                            #region 先上传文件

                            foreach (MED_QC_PATIENT_INFO patientInfo in patientInfoList)
                            {
                                string root = AppSettings.QcUpLoadFileAddress + "\\TempFileUpload\\";//指定要将文件存入的服务器物理位置

                                string rootChild = root + (patientInfo.PATIENT_ID + "_" + patientInfo.VISIT_ID + "_" + patientInfo.OPER_ID) + "\\";

                                // 子目录文件夹地址
                                if (Directory.Exists(rootChild))//判断文件夹是否存在 
                                {
                                    string[] fileList = Directory.GetFiles(rootChild);

                                    if (fileList.Length > 0)
                                    {
                                        Dictionary<string, string> dicFromData = new Dictionary<string, string>();
                                        Dictionary<string, string> dicFiles = new Dictionary<string, string>();

                                        foreach (string filePath in fileList)
                                        {
                                            string fileName = Path.GetFileName(filePath);

                                            dicFiles.Add(fileName, filePath);
                                        }

                                        if (dicFiles.Count > 0)
                                        {

                                            string tokenResultFile = AsyncHandleData.Get(getTokenUri);

                                            var jsonDataTokenFile = JsonConvert.DeserializeObject<ResponseResult>(tokenResultFile);

                                            if (jsonDataTokenFile.Status == 1)
                                            {
                                                string postFileDataUri = GetQcUploadAddress("UploadFile").Data;//上传文件地址

                                                RequestResult<int> postResultFileData = AsyncHandleData.PostFileData(postFileDataUri, dicFromData, dicFiles, jsonDataTokenFile.Message.Split(':')[1]);

                                                if (postResultFileData.Data == 1)
                                                {
                                                    //type.Data = 1;
                                                    if (!string.IsNullOrEmpty(postResultFileData.Message))
                                                    {
                                                        string[] array = postResultFileData.Message.Split('|');

                                                        if (array.Length > 0)
                                                        {

                                                            string errorInfo = patientInfo.PATIENT_ID + "_" + patientInfo.VISIT_ID + "_" + patientInfo.OPER_ID + postResultFileData.Message.Split('|')[0];
                                                            Logger.Error("上传文件异常信息", new Exception(errorInfo));

                                                            if (array.Length == 2)
                                                            {
                                                                string FolderId = postResultFileData.Message.Split('|')[1];// 质控云服务端存储的ID

                                                                // 返回给质控的patientModel
                                                                foreach (QC.WebInterfaceModel.PatientModel pModel in patientModelList)
                                                                {
                                                                    if (pModel.AdamissionNo == patientInfo.INP_NO
                                                                        && pModel.Visit == patientInfo.VISIT_ID.ToString()
                                                                        && pModel.Oper == patientInfo.OPER_ID.ToString())
                                                                    {
                                                                        pModel.FolderId = FolderId;
                                                                    }
                                                                }

                                                                // 转存质控数据表
                                                                List<MED_ANESTHESIA_INPUT_DATA> medAnesthesiaInputDataList = QuanlityControlService.GetMedAnesthesiaInputData(patientInfo.PATIENT_ID, (int)patientInfo.VISIT_ID, (int)patientInfo.OPER_ID);

                                                                if (medAnesthesiaInputDataList.Count > 0)
                                                                {
                                                                    MED_ANESTHESIA_INPUT_DATA medAnesthesiaInputData = medAnesthesiaInputDataList[0];

                                                                    medAnesthesiaInputData.QC_FLODID = FolderId;
                                                                    medAnesthesiaInputData.DOC_ADDRESS = rootChild;

                                                                    QuanlityControlService.SaveMedAnesthesiaInputData(medAnesthesiaInputData);//保存数据
                                                                }
                                                            }
                                                            else
                                                            {

                                                                Logger.Error("上传文件异常信息", new Exception("未从质控云服务端获得文件唯一标识"));
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    string errorInfo = patientInfo.PATIENT_ID + "_" + patientInfo.VISIT_ID + "_" + patientInfo.OPER_ID + "上传失败";
                                                    Logger.Error("上传文件异常信息", new Exception(errorInfo));
                                                }
                                            }
                                            else
                                            {
                                                Logger.Error("上传文件异常信息", new Exception("获取TOKEN失败"));
                                            }
                                        }

                                    }
                                }
                            }

                            #endregion

                            #region 设置dataModel内容

                            // 加密顺序，先序列化MODEL 再通过Encrypt 进行加密 
                            dataModel.PatientsModel = QC.WebInterfaceModel.SecurityHelper.Encrypt(JsonConvert.SerializeObject(patientModelList));

                            dataModel.ReportModel = QC.WebInterfaceModel.SecurityHelper.Encrypt(JsonConvert.SerializeObject(reportModel));

                            dataModel.UserModel = QC.WebInterfaceModel.SecurityHelper.Encrypt(JsonConvert.SerializeObject(userModel));

                            #endregion 设置dataModel内容

                            #region 后上报数据
                            string postDataUri = GetQcUploadAddress("DataImport").Data;//上报数据地址

                            string postJsonData = JsonConvert.SerializeObject(dataModel);//上报数据json

                            string postResult = AsyncHandleData.Post(postDataUri, postJsonData, jsonDataToken.Message.Split(':')[1]);


                            var jsonDataPostResult = JsonConvert.DeserializeObject<ResponseResult>(postResult);

                            if (jsonDataPostResult.Status == 1)
                            {
                                type.Data = 1;
                                type.Message = "质控数据上报成功";

                                Logger.Error("上传文件异常信息", new Exception("质控数据上报成功" + jsonDataPostResult.Message));
                            }
                            else
                            {
                                Logger.Error("质控上报JSON数据失败", new Exception("质控上报JSON数据：" + postJsonData));

                                type = QuanlityControlService.SaveQuanlityControlReportInd(reportId, 0, LoginUserId);
                                type.Data = 0;
                                type.Message = jsonDataPostResult.Message;

                                Logger.Error("上传文件异常信息", new Exception("质控数据上报失败" + jsonDataPostResult.Message));
                            }

                            #endregion 后上报数据
                        }
                        else
                        {
                            type = QuanlityControlService.SaveQuanlityControlReportInd(reportId, 0, LoginUserId);
                            type.Data = 0;
                            type.Message = jsonDataToken.Message;
                            Logger.Error("上传文件异常信息", new Exception("未获得TOKEN" + jsonDataToken.Message));
                        }
                        #endregion
                    }
                    else
                    {
                        #region 内外网不通，通过前置机转发的方式
                        //获取Token
                        string getTokenUri = GetFrontEndQcUploadAddress("GetToken").Data;//获取Token

                        string tokenResult = AsyncHandleData.Get(getTokenUri);//调用前置机接口

                        #region 先上传文件

                        foreach (MED_QC_PATIENT_INFO patientInfo in patientInfoList)
                        {
                            string root = AppSettings.QcUpLoadFileAddress + "\\TempFileUpload\\";//指定要将文件存入的服务器物理位置

                            string rootChild = root + (patientInfo.PATIENT_ID + "_" + patientInfo.VISIT_ID + "_" + patientInfo.OPER_ID) + "\\";

                            // 子目录文件夹地址
                            if (Directory.Exists(rootChild))//判断文件夹是否存在 
                            {
                                string[] fileList = Directory.GetFiles(rootChild);

                                if (fileList.Length > 0)
                                {
                                    Dictionary<string, string> dicFromData = new Dictionary<string, string>();
                                    Dictionary<string, string> dicFiles = new Dictionary<string, string>();

                                    foreach (string filePath in fileList)
                                    {
                                        string fileName = Path.GetFileName(filePath);

                                        dicFiles.Add(fileName, filePath);
                                    }

                                    if (dicFiles.Count > 0)
                                    {

                                        string tokenResultFile = AsyncHandleData.Get(getTokenUri);

                                        string postFileDataUri = GetFrontEndQcUploadAddress("UploadFile").Data;//上传文件地址



                                        RequestResult<int> postResultFileData = AsyncHandleData.PostFileData(postFileDataUri, dicFromData, dicFiles, patientInfo.PATIENT_ID, patientInfo.VISIT_ID, patientInfo.OPER_ID);


                                        // 转存质控数据表
                                        List<MED_ANESTHESIA_INPUT_DATA> medAnesthesiaInputDataList = QuanlityControlService.GetMedAnesthesiaInputData(patientInfo.PATIENT_ID, (int)patientInfo.VISIT_ID, (int)patientInfo.OPER_ID);

                                        if (medAnesthesiaInputDataList.Count > 0)
                                        {
                                            MED_ANESTHESIA_INPUT_DATA medAnesthesiaInputData = medAnesthesiaInputDataList[0];

                                            medAnesthesiaInputData.DOC_ADDRESS = rootChild;

                                            QuanlityControlService.SaveMedAnesthesiaInputData(medAnesthesiaInputData);//保存数据
                                        }


                                    }

                                }
                            }
                        }

                        #endregion

                        #region 设置dataModel内容

                        // 加密顺序，先序列化MODEL 再通过Encrypt 进行加密 
                        dataModel.PatientsModel = QC.WebInterfaceModel.SecurityHelper.Encrypt(JsonConvert.SerializeObject(patientModelList));

                        dataModel.ReportModel = QC.WebInterfaceModel.SecurityHelper.Encrypt(JsonConvert.SerializeObject(reportModel));

                        dataModel.UserModel = QC.WebInterfaceModel.SecurityHelper.Encrypt(JsonConvert.SerializeObject(userModel));


                        #endregion 设置dataModel内容

                        #region 后上报数据
                        string postDataUri = GetFrontEndQcUploadAddress("DataImport").Data;//上报数据地址

                        string postJsonData = JsonConvert.SerializeObject(dataModel);//上报数据json
                        string postResult = AsyncHandleData.Post(postDataUri, postJsonData);

                        type.Data = 1;
                        type.Message = "质控数据上报成功";


                        #endregion 后上报数据

                        #endregion
                    }

                    #endregion 调用上报接口
                }

                #endregion  调用质控云平台服务上报数据接口
            }

            return type;
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> PostFile()
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;

            NameValueCollection paramList = HttpContext.Current.Request.Params;

            string patientId = paramList.Get("PATIENT_ID");

            string visitId = paramList.Get("VISIT_ID");

            string operId = paramList.Get("OPER_ID");


            Dictionary<string, string> dicFromData = new Dictionary<string, string>();
            Dictionary<string, string> dicFiles = new Dictionary<string, string>();

            string root = AppSettings.QcUpLoadFileAddress + "\\TempFileUpload\\";//指定要将文件存入的服务器物理位置

            // 根目录文件夹地址
            if (!Directory.Exists(root))//判断文件夹是否存在 
            {
                Directory.CreateDirectory(root);//不存在则创建文件夹 
            }


            string rootChild = root + (patientId + "_" + visitId + "_" + operId);

            // 子目录文件夹地址
            if (!Directory.Exists(rootChild))//判断文件夹是否存在 
            {
                Directory.CreateDirectory(rootChild);//不存在则创建文件夹 
            }

            foreach (string key in files.AllKeys)
            {
                HttpPostedFile file1 = files[key];

                if (!string.IsNullOrEmpty(file1.FileName))
                {
                    string filePath = rootChild + "\\" + file1.FileName;

                    file1.SaveAs(filePath);

                    dicFiles.Add(file1.FileName, filePath);
                }
            }

            RequestResult<int> type = new RequestResult<int>();

            if (dicFiles.Count > 0)
            {
                type.Data = 1;
                type.Message = "保存文件成功";

                Logger.Error("上传文件异常信息", new Exception("保存文件成功"));
            }
            else
            {
                type.Data = 0;
                type.Message = "保存文件失败";
                Logger.Error("上传文件异常信息", new Exception("保存文件失败"));
            }
            return type;
        }


        /// <summary>
        /// 编辑质控项目字典数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="medQcItem">质控项目对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditQuanlityControlItem(int type, MED_QC_ITEM medQcItem)
        {
            return Success(QuanlityControlService.EditQuanlityControlItem(type, medQcItem));
        }

        /// <summary>
        /// 删除质控项目字典数据
        /// </summary>
        /// <param name="medQcItemList">项目列表</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeletedQuanlityControlItemList(List<MED_QC_ITEM> medQcItemList)
        {
            return Success(QuanlityControlService.DeletedQuanlityControlItemList(medQcItemList));
        }

        /// <summary>
        /// 获取质控项目报表样式数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_QC_REPORT_LIST>> GetQuanlityControlReportList()
        {
            return Success(QuanlityControlService.GetQuanlityControlReportList());
        }


        /// <summary>
        /// 编辑质控项目报表数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="medQcReportList">质控项目对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditQuanlityControlReportList(int type, MED_QC_REPORT_LIST medQcReportList)
        {
            return Success(QuanlityControlService.EditQuanlityControlReportList(type, medQcReportList));
        }

        /// <summary>
        /// 删除质控项目报表样式数据
        /// </summary>
        /// <param name="medQcReportList">项目列表</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeletedQuanlityControlReportList(List<MED_QC_REPORT_LIST> medQcReportList)
        {
            return Success(QuanlityControlService.DeletedQuanlityControlReportList(medQcReportList));
        }

        #region 质控平台适配XML增删改查

        /// <summary>
        /// 获取与质控匹配的XML数据
        /// </summary>
        /// <returns></returns>
        public RequestResult<List<QcDictXMLHelper.QcDictModel>> GetXmlDataForQCNoByName()
        {
            IMdkConfiguration mdkConfig = MdkConfiguration.GetConfig();

            QcDictXMLHelper qcDictXMLHelper = new QcDictXMLHelper();

            qcDictXMLHelper.XmlPath = mdkConfig.XmlDict.XmlPath;

            List<QcDictXMLHelper.QcDictModel> qcDictModelList = qcDictXMLHelper.GetDictXML(mdkConfig.XmlDict.XmlPath).Model.FindAll(t => t.GroupName.Contains("质控上报"));

            return Success(JsonConvert.DeserializeObject<List<QcDictXMLHelper.QcDictModel>>(JsonConvert.SerializeObject(qcDictModelList)));
        }

        /// <summary>
        /// 获取与质控匹配的XML数据
        /// </summary>
        /// <returns></returns>
        public RequestResult<List<QcDictXMLHelper.QcDictGroup>> GetXmlDataForQC(string groupName)
        {
            IMdkConfiguration mdkConfig = MdkConfiguration.GetConfig();

            QcDictXMLHelper qcDictXMLHelper = new QcDictXMLHelper();

            qcDictXMLHelper.XmlPath = mdkConfig.XmlDict.XmlPath;

            List<QcDictXMLHelper.QcDictGroup> lst = qcDictXMLHelper.GetGroupByName(groupName);

            return Success(JsonConvert.DeserializeObject<List<QcDictXMLHelper.QcDictGroup>>(JsonConvert.SerializeObject(lst)));
        }

        /// <summary>
        /// 保存与质控匹配的XML数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public RequestResult<int> SaveXmlDataForQC(dynamic obj)
        {
            string xmlData = obj.xmlData.ToString();

            string groupName = obj.groupName.ToString();

            QcDictXMLHelper.QcDictGroup lst = JsonConvert.DeserializeObject<QcDictXMLHelper.QcDictGroup>(xmlData);

            IMdkConfiguration mdkConfig = MdkConfiguration.GetConfig();

            QcDictXMLHelper helper = new QcDictXMLHelper();

            helper.XmlPath = mdkConfig.XmlDict.XmlPath;

            QcDictXMLHelper dictXml = helper.GetDictXML(mdkConfig.XmlDict.XmlPath);

            QcDictXMLHelper.QcDictModel findModel = dictXml.Model.Find(t => t.GroupName == groupName);

            QcDictXMLHelper.QcDictGroup find = findModel.Group.Find(tt => tt.Key == lst.Key);

            if (find != null)
            {
                find.KeyName = lst.KeyName;
                find.Value = lst.Value;
                find.ValueName = lst.ValueName;
            }
            else
            {
                find = new QcDictXMLHelper.QcDictGroup();

                find.Key = lst.Key;
                find.KeyName = lst.KeyName;
                find.Value = lst.Value;
                find.ValueName = lst.ValueName;

                findModel.Group.Add(find);
            }

            return Success<int>(helper.SaveDataFormatDict(dictXml) == true ? 1 : 0);
        }

        /// <summary>
        /// 删除与质控匹配的XML数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeletedXmlDataForQC(dynamic obj)
        {
            string xmlData = obj.xmlData.ToString();

            string groupName = obj.groupName.ToString();

            QcDictXMLHelper.QcDictGroup lst = JsonConvert.DeserializeObject<QcDictXMLHelper.QcDictGroup>(xmlData);

            IMdkConfiguration mdkConfig = MdkConfiguration.GetConfig();

            QcDictXMLHelper helper = new QcDictXMLHelper();

            helper.XmlPath = mdkConfig.XmlDict.XmlPath;

            QcDictXMLHelper dictXml = helper.GetDictXML(mdkConfig.XmlDict.XmlPath);

            QcDictXMLHelper.QcDictModel findModel = dictXml.Model.Find(t => t.GroupName == groupName);

            QcDictXMLHelper.QcDictGroup find = findModel.Group.Find(tt => tt.Key == lst.Key);

            if (find != null)
            {
                findModel.Group.Remove(find);
            }

            return Success<int>(helper.SaveDataFormatDict(dictXml) == true ? 1 : 0);
        }

        #endregion

        #region 不良事件登记增删改查

        /// <summary>
        /// 获取患者基本信息数据
        /// </summary>
        /// <param name="inpNo">  </param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_QC_PATIENT_INFO>> GetQCPatientBaseInfo(string inpNo)
        {
            return Success(QuanlityControlService.GetQCPatientBaseInfo(inpNo));
        }

        /// <summary>
        /// 获取患者基本信息数据
        /// </summary>
        /// <param name="inpNo">  </param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_QC_PATIENT_INFO>> GetQCPatientBaseInfo2(string patientId, decimal visitId, decimal operId)
        {
            return Success(QuanlityControlService.GetQCPatientBaseInfo2(patientId, visitId, operId));
        }


        /// <summary>
        /// 获取患者基本信息数据
        /// </summary>
        /// <param name="inpNo">  </param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_QC_OUT_PAT_INFO>> GetQCPatientBaseInfoOut(string inpNo)
        {
            return Success(QuanlityControlService.GetQCPatientBaseInfoOut(inpNo));
        }

        /// <summary>
        /// 获取患者基本信息数据
        /// </summary>
        /// <param name="inpNo">  </param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_QC_OUT_PAT_INFO>> GetQCPatientBaseInfoOut2(string patientId, decimal visitId, decimal operId)
        {
            return Success(QuanlityControlService.GetQCPatientBaseInfoOut2(patientId, visitId, operId));
        }

        /// <summary>
        /// 获取质控数据表数据
        /// </summary>
        /// <param name="patientId">  </param>
        /// <param name="visitId">  </param>
        /// <param name="operId">  </param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_INPUT_DATA>> GetMedAnesthesiaInputData(string patientId, int visitId, int operId)
        {
            return Success(QuanlityControlService.GetMedAnesthesiaInputData(patientId, visitId, operId));
        }

        /// <summary>
        /// 获取质控数据表数据
        /// </summary>
        /// <param name="patientId">  </param>
        /// <param name="visitId">  </param>
        /// <param name="operId">  </param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_INPUT_DATA_OUT>> GetMedAnesthesiaInputDataOut(string patientId, int visitId, int operId)
        {
            return Success(QuanlityControlService.GetMedAnesthesiaInputDataOut(patientId, visitId, operId));
        }

        /// <summary>
        /// 保存质控数据表数据
        /// </summary>
        /// <param name="medAnesthesiaInputData"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> SaveMedAnesthesiaInputData(MED_ANESTHESIA_INPUT_DATA medAnesthesiaInputData)
        {
            return Success(QuanlityControlService.SaveMedAnesthesiaInputData(medAnesthesiaInputData));
        }


        /// <summary>
        /// 保存质控数据表数据---室外
        /// </summary>
        /// <param name="medAnesthesiaInputData"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> SaveOutMedAnesthesiaInputData(dynamic dbj)
        {
            MED_QC_OUT_PAT_INFO outPatInfo = JsonConvert.DeserializeObject<MED_QC_OUT_PAT_INFO>(JsonConvert.SerializeObject(dbj.patInfo));


            MED_ANESTHESIA_INPUT_DATA_OUT outMedAnesthesiaInputData = JsonConvert.DeserializeObject<MED_ANESTHESIA_INPUT_DATA_OUT>(JsonConvert.SerializeObject(dbj.InputData));
            return Success(QuanlityControlService.SaveOutMedAnesthesiaInputData(outPatInfo, outMedAnesthesiaInputData));
        }

        #endregion

        /// <summary>
        /// 获取QC上报数据接口
        /// </summary>
        /// <param name="dataType">接口类型参数</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<string> GetQcUploadAddress(string dataType)
        {
            string scriectKey = AppSettings.QcScriectKey;//密钥

            string baseUri = AppSettings.PostQcUri;//上报URL地址

            string getTokenUri = baseUri + "GetToken?scriectKey=" + scriectKey;//获取Token

            string postDataUri = baseUri + "DataImport";//上报数据地址

            string uploadFileUri = baseUri + "UploadFile";//上传文件地址

            RequestResult<string> address = new RequestResult<string>();

            switch (dataType)
            {
                case "GetToken":
                    address = Success(getTokenUri);//获取Token
                    break;
                case "DataImport":
                    address = Success(postDataUri);//上报数据地址
                    break;
                case "UploadFile":
                    address = Success(uploadFileUri);//上传文件地址
                    break;
            }

            return address;
        }

        /// <summary>
        /// 获取QC上报数据接口
        /// </summary>
        /// <param name="dataType">接口类型参数</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<string> GetFrontEndQcUploadAddress(string dataType)
        {
            //string scriectKey = AppSettings.QcScriectKey;//密钥

            string baseUri = ConfigurationManager.AppSettings["FrontEndUri"];//上报前置机URL地址

            string getTokenUri = baseUri + "FrontEndMachine/GetToken";//获取Token

            string postDataUri = baseUri + "FrontEndMachine/DataImport";//上报数据地址

            string uploadFileUri = baseUri + "FrontEndMachine/UploadFile";//上传文件地址

            RequestResult<string> address = new RequestResult<string>();

            switch (dataType)
            {
                case "GetToken":
                    address = Success(getTokenUri);//获取Token
                    break;
                case "DataImport":
                    address = Success(postDataUri);//上报数据地址
                    break;
                case "UploadFile":
                    address = Success(uploadFileUri);//上传文件地址
                    break;
            }

            return address;
        }

        #region 导出报表数据
        /// <summary>
        /// 导出报表数据
        /// </summary>
        /// <param name="obj">报表信息</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<string> ExportExcel(dynamic obj)
        {
            return Success(QuanlityControlService.ExportExcel(obj.reportMonth.Value, obj.reportName.Value, obj.exprotExcelColumns, obj.isOutRoomOper.Value));
        }
        #endregion


    }

    /// <summary>
    /// 调用平台接口返回类型
    /// </summary>
    public class ResponseResult
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 额外数据
        /// </summary>
        public object ExtraData { get; set; }
    }

    /// <summary>
    /// 质控上报实体模型
    /// </summary>
    public class QcUploadJsonModel
    {

        /// <summary>
        /// 上报CODE
        /// </summary>
        public string ITEM_CODE { get; set; }

        /// <summary>
        /// 上报VALUE
        /// </summary>
        public int ITEM_VALUE { get; set; }
    }
}
