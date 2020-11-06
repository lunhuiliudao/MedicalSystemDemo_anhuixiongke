
using MedicalSystem.AnesPlatform.Service.WebApi.App_Start.Swagger;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.Report;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Platform
{
    /// <summary>
    /// 首页/主任站/日常查询
    /// </summary>
    [ControllerGroup("首页/主任站/日常查询", "接口")]
    public class PlatformAnesQueryController : PlatformBaseController
    {
        IPlatformAnesQueryService AnesQuery;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="AnesQueryParam"></param>
        public PlatformAnesQueryController(IPlatformAnesQueryService AnesQueryParam)
        {
            AnesQuery = AnesQueryParam;
        }

        #region   麻醉平台首页

        #region 医生首页统计


        /// <summary>
        /// 医生手术查询
        /// </summary>
        [HttpPost]
        public RequestPageResult<IList<OperQuerytForDoctorIndexEntity>> QueryOperListForDoctorIndex(OperQueryParaModel model)
        {

            IList<OperQuerytForDoctorIndexEntity> list = AnesQuery.GetOperListForDoctorIndex(model);

            IList<OperQuerytForDoctorIndexEntity> pageList = list;
            //分页处理
            if (list.Count > model.PageSize)
            {
                //pageList = (IList<OperQuerytForDoctorIndexEntity>)list.Where(p => (p.ID - 1) >=
                //(model.CurrentPage - 1) * model.PageSize && (p.ID - 1) < model.CurrentPage * model.PageSize).ToList(); ;

                pageList = pageList.Skip((model.CurrentPage - 1) * model.PageSize).Take(model.PageSize).ToList();
            }

            return PageSuccess(pageList, model.PageSize, model.CurrentPage, list.Count);
        }

        /// <summary>
        /// 医生/护士手术查询  
        /// </summary>
        [HttpPost]
        public RequestPageResult<IList<OperQuerytForDoctorIndexEntity>> QuerySelfOperListForDoctorIndex(OperQueryParaModel model)
        {

            IList<OperQuerytForDoctorIndexEntity> list = AnesQuery.GetOperSelfListForDoctorIndex(model);

            IList<OperQuerytForDoctorIndexEntity> pageList = list;
            //分页处理
            if (list.Count > model.PageSize)
            {
                //pageList = (IList<OperQuerytForDoctorIndexEntity>)list.Where(p => (p.ID - 1) >=
                //(model.CurrentPage - 1) * model.PageSize && (p.ID - 1) < model.CurrentPage * model.PageSize).ToList(); ;
                pageList = pageList.Skip((model.CurrentPage - 1) * model.PageSize).Take(model.PageSize).ToList();

            }
            return PageSuccess(pageList, model.PageSize, model.CurrentPage, list.Count);

        }


        /// <summary>
        /// 医生首页手术信息集中统计查询
        /// </summary>
        [HttpPost]
        public RequestResult<OperInfosForDoctorIndexEntity> QueryOperInfosForDoctorIndex(OperQueryParaModel model)
        {

            OperInfosForDoctorIndexEntity list = AnesQuery.QueryOperInfosForDoctorIndex(model);

            return Success(list);
        }
        #endregion

        #region 护士首页统计

        /// <summary>
        /// 护士手术查询
        /// </summary>
        [HttpPost]
        public RequestPageResult<IList<OperQuerytForDoctorIndexEntity>> QueryOperListForNurseIndex(OperQueryParaModel model)
        {

            IList<OperQuerytForDoctorIndexEntity> list = AnesQuery.GetOperListForNurseIndex(model);

            IList<OperQuerytForDoctorIndexEntity> pageList = list;
            //分页处理
            if (list.Count > model.PageSize)
            {
                //pageList = (IList<OperQuerytForDoctorIndexEntity>)list.Where(p => (p.ID - 1) >=
                //(model.CurrentPage - 1) * model.PageSize && (p.ID - 1) < model.CurrentPage * model.PageSize).ToList(); ;

                pageList = pageList.Skip((model.CurrentPage - 1) * model.PageSize).Take(model.PageSize).ToList();

            }
            return PageSuccess(pageList, model.PageSize, model.CurrentPage, list.Count);
        }

        /// <summary>
        /// 护士手术查询  
        /// </summary>
        [HttpPost]
        public RequestPageResult<IList<OperQuerytForDoctorIndexEntity>> QuerySelfOperListForNurseIndex(OperQueryParaModel model)
        {

            IList<OperQuerytForDoctorIndexEntity> list = AnesQuery.GetOperSelfListForNurseIndex(model);

            IList<OperQuerytForDoctorIndexEntity> pageList = list;
            //分页处理
            if (list.Count > model.PageSize)
            {
                //pageList = (IList<OperQuerytForDoctorIndexEntity>)list.Where(p => (p.ID - 1) >=
                //(model.CurrentPage - 1) * model.PageSize && (p.ID - 1) < model.CurrentPage * model.PageSize).ToList(); ;

                pageList = pageList.Skip((model.CurrentPage - 1) * model.PageSize).Take(model.PageSize).ToList();

            }
            return PageSuccess(pageList, model.PageSize, model.CurrentPage, list.Count);


        }


        /// <summary>
        /// 护士首页手术信息集中统计查询
        /// </summary>
        [HttpPost]
        public RequestResult<OperInfosForDoctorIndexEntity> QueryOperInfosForNurseIndex(OperQueryParaModel model)
        {

            OperInfosForDoctorIndexEntity list = AnesQuery.QueryOperInfosForNurseIndex(model);

            return Success(list);
        }
        #endregion

        #region 主任首页统计


        /// <summary>
        /// 主任首页手术信息集中统计查询
        /// </summary>
        [HttpPost]
        public RequestResult<OperInfosForDirectorIndexEntity> QueryOperInfosForDirectorIndex()
        {

            OperInfosForDirectorIndexEntity list = AnesQuery.QueryOperInfosForDirectorIndex();

            return Success(list);
        }


        /// <summary>
        /// 主任首页手术信息EChart图标统计
        /// </summary>
        [HttpPost]
        public RequestResult<IList<EChartsItemEntity>> QueryOperEChartReportForDirectionIndex(OperQueryParaModel modela)
        {

            IList<EChartsItemEntity> list = AnesQuery.QueryOperEChartReportForDirectionIndex(modela);

            return Success(list);
        }
        /// <summary>
        /// 主任首页手术信息情况报表统计
        /// </summary>
        [HttpPost]
        public RequestResult<OperReportForDirectionEntity> QueryOperReportForDirectionIndex(OperQueryParaModel modela)
        {

            OperReportForDirectionEntity list = AnesQuery.QueryOperReportForDirectionIndex(modela);

            return Success(list);
        }

        /// <summary>
        /// 主任首页右侧饼图EChart图标统计
        /// </summary>
        [HttpPost]
        public RequestResult<IList<EChartsItemEntity>> QueryRightEChartReportForDirectionIndex(OperQueryParaModel modela)
        {

            IList<EChartsItemEntity> list = AnesQuery.QueryRightEChartReportForDirectionIndex(modela);

            return Success(list);
        }


        /// <summary>
        /// 主任首页弹出层明细
        /// </summary>
        [HttpPost]
        public RequestPageResult<IList<OperDetailListForDirectorIndexEntity>> QueryOperDetailForDirectorIndex(OperQueryParaModel model)
        {

            IList<OperDetailListForDirectorIndexEntity> list = AnesQuery.QueryOperDetailForDirectorIndex(model);

            IList<OperDetailListForDirectorIndexEntity> pageList = list;
            //分页处理
            if (list.Count > model.PageSize)
            {
                //pageList = (IList<OperDetailListForDirectorIndexEntity>)list.Where(p => (p.ID - 1) >=
                //(model.CurrentPage - 1) * model.PageSize && (p.ID - 1) < model.CurrentPage * model.PageSize).ToList(); ;

                pageList = pageList.Skip((model.CurrentPage - 1) * model.PageSize).Take(model.PageSize).ToList();

            }
            return PageSuccess(pageList, model.PageSize, model.CurrentPage, list.Count);
        }




        /// <summary>
        /// 主任首页EChart弹出层明细
        /// </summary>
        [HttpPost]
        public RequestPageResult<IList<OperDetailListForDirectorIndexEntity>> QueryEChartOperDetailForDirectorIndex(OperQueryParaModel model)
        {

            IList<OperDetailListForDirectorIndexEntity> list = AnesQuery.QueryEChartOperDetailForDirectorIndex(model);

            IList<OperDetailListForDirectorIndexEntity> pageList = list;
            //分页处理
            if (list.Count > model.PageSize)
            {
                //pageList = (IList<OperDetailListForDirectorIndexEntity>)list.Where(p => (p.ID - 1) >=
                //(model.CurrentPage - 1) * model.PageSize && (p.ID - 1) < model.CurrentPage * model.PageSize).ToList(); ;

                pageList = pageList.Skip((model.CurrentPage - 1) * model.PageSize).Take(model.PageSize).ToList();

            }
            return PageSuccess(pageList, model.PageSize, model.CurrentPage, list.Count);
        }
        #endregion

        #endregion

        #region 报表配置器
        /// <summary>
        /// 获取指定报表信息
        /// </summary>
        /// <param name="reportKey"></param>
        /// <param name="clearSql">清空sql语句</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<ReportInformation> GetReportConfigByKey([FromUri]string reportKey, [FromUri]bool clearSql = true)
        {
            ReportInformation result = AnesQuery.GetReportConfigByKey(reportKey, clearSql);
            return Success(result);
        }

        /// <summary>
        /// 获取所有报表列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<KeyValue>> GetReportConfig()
        {
            return Success(AnesQuery.GetReportConfig());
        }

        /// <summary>
        /// 保存报表配置信息
        /// </summary>
        /// <param name="reportInformation"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<bool> SaveReportConfig(ReportInformation reportInformation)
        {
            return Success(AnesQuery.SaveReportConfig(reportInformation));
        }

        /// <summary>
        ///  执行SQL语句
        /// </summary>
        /// <param name="key">报表key</param>
        /// <param name="reportInformation">报表信息</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <param name="PageSize">每页条数</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<dynamic> ExecSql([FromUri]string key, ReportInformation reportInformation, [FromUri]int CurrentPage = 1, [FromUri]int PageSize = 20)
        {
            List<dynamic> DataList = AnesQuery.ExecSql(key, reportInformation);
            // 在前端显示总计信息，需要将所有数据allData传到前端进行计算。数据流小时用前端方便
            dynamic dynamicInfo = new
            {
                total = DataList.Count,
                currentPage = CurrentPage,
                currentData = DataList.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList<dynamic>(),
                allData = DataList
            };

            // 在后台添加总计信息，当数据流大时应该用后端计算
            //dynamic total = GetTotalInfo(key, DataList);
            //PageSize = PageSize - 1;
            //dynamic dynamicInfo = new
            //{
            //    total = DataList.Count,
            //    currentPage = CurrentPage,
            //    currentData = DataList.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList<dynamic>()
            //};
            //dynamicInfo.currentData.Add(total);

            return Success<dynamic>(dynamicInfo);
        }

        private dynamic GetTotalInfo(string key, List<dynamic> DataList)
        {
            List<ReportColumn> colums = (AnesQuery as PlatformAnesQueryService).ReportDataDict[key].ReportColumnList;
            dynamic total = null;
            if (DataList.Count > 0)
            {
                IDictionary<string, object> dicData = DataList[0] as IDictionary<string, object>;
                if (dicData != null)
                {
                    bool hasTotalColumn = false;
                    total = new System.Dynamic.ExpandoObject();
                    for (int i = 0; i < colums.Count; i++)
                    {
                        if (!hasTotalColumn && colums[i].IsSHow)
                        {
                            hasTotalColumn = true;
                            ((IDictionary<string, object>)total).Add(colums[i].FieldName, "总计");
                            continue;
                        }

                        double totalCoum = 0.0;
                        double tempValue = 0.0;
                        bool isNum = true;
                        foreach (dynamic x in DataList)
                        {
                            dicData = x as IDictionary<string, object>;
                            if (null != dicData && null != dicData[colums[i].FieldName])
                            {
                                if (double.TryParse(dicData[colums[i].FieldName].ToString(), out tempValue))
                                {
                                    totalCoum += tempValue;
                                }
                                else
                                {
                                    isNum = false;
                                    break;
                                }
                            }
                        }

                        if (isNum)
                        {
                            ((IDictionary<string, object>)total).Add(colums[i].FieldName, totalCoum);
                        }
                        else
                        {
                            ((IDictionary<string, object>)total).Add(colums[i].FieldName, "");
                        }
                    }
                }
            }

            return total;
        }

        /// <summary>
        /// 导出报表数据
        /// </summary>
        /// <param name="key">报表key</param>
        /// <param name="reportInformation">报表信息</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<string> ExportExcel(string key, ReportInformation reportInformation)
        {
            return Success(AnesQuery.ExportExcel(key, reportInformation));
        }

        /// <summary>
        /// 获取字典数据
        /// </summary>
        /// <param name="reportCondition">查询条件对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<List<KeyValue>> GetDict(ReportCondition reportCondition)
        {
            return Success(AnesQuery.GetDict(reportCondition));
        }

        /// <summary>
        /// 执行子报表SQL语句
        /// </summary>
        /// <param name="key">父报表名称</param>
        /// <param name="subkey">子报表名称</param>
        /// <param name="reportInformation">报表信息</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <param name="PageSize">每页条数</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<dynamic> ExecSubSql([FromUri]string key, [FromUri]string subkey, ReportInformation reportInformation, [FromUri]int CurrentPage = 1, [FromUri]int PageSize = 20)
        {
            List<dynamic> DataList = AnesQuery.ExecSubSql(key, subkey, reportInformation);
            dynamic dynamicInfo = new
            {
                total = DataList.Count,
                currentPage = CurrentPage,
                currentData = DataList.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList<dynamic>()
            };
            return Success<dynamic>(dynamicInfo);
        }

        /// <summary>
        /// 导出报表数据
        /// </summary>
        /// <param name="key">报表key</param>
        /// <param name="reportInformation">报表信息</param>
        /// <param name="subkey">子报表名称</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<string> ExportSubReportExcel([FromUri]string key, [FromUri]string subkey, ReportInformation reportInformation)
        {
            return Success(AnesQuery.ExportSubReportExcel(key, subkey, reportInformation));
        }

        /// <summary>
        /// 获取SQL语句
        /// </summary>
        /// <param name="key">报表key</param>
        /// <param name="type">获取sql的类型type:0 参数解析出来，type:1 默认sql </param>
        /// <param name="reportInformation">报表信息</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<string> GetReportSQL([FromUri]string key, [FromUri]int type, ReportInformation reportInformation)
        {
            return Success(AnesQuery.GetReportSQL(key, type, reportInformation));
        }

        /// <summary>
        /// 获取子报表SQL语句
        /// </summary>
        /// <param name="key">报表key</param>
        /// <param name="type">获取sql的类型type:0 参数解析出来，type:1 默认sql </param>
        /// <param name="reportInformation">报表信息</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<string> GetSubReportSQL([FromUri]string key, [FromUri]int type, ReportInformation reportInformation)
        {
            return Success(AnesQuery.GetSubReportSQL(key, type, reportInformation));
        }

        /// <summary>
        /// 获取对应sql的所有列名
        /// </summary>
        /// <param name="reportInformation"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<List<string>> GetReportColumList([FromUri]string pkey, [FromUri]bool isSubReport, ReportInformation reportInformation)
        {
            return Success(AnesQuery.GetReportColumList(pkey, isSubReport,reportInformation));
        }

        /// <summary>
        /// 获取对应路径下所有的excel 文件   默认"Config\\ExcelModel\\AnesQueryExcelModel" 
        /// </summary>
        /// <param name="ExcelPath"> 想要返回的模版集合的文件夹路径</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<List<KeyValue>> GetAnesQueryExeclModelList(string ExcelPath = "Config\\ExcelModel\\AnesQueryExcelModel")
        {
            return Success(AnesQuery.GetExeclModelName(ExcelPath));
        }


        /// <summary>
        /// 上传到统计相关Excel模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<string> UploadExcelToAnesQueryPath()
        {
            return Success(AnesQuery.UploadExcelToPath("Config\\ExcelModel\\AnesQueryExcelModel"));
        }

        /// <summary>
        /// 删除统计相关Excel模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<string> DeleteAnesQueryExcelModele(string ExcelModeleName)
        {
            return Success(AnesQuery.DeleteExcelModeleWithPathAndExcelName("Config\\ExcelModel\\AnesQueryExcelModel", ExcelModeleName));
        }
        #endregion


        #region   十七项指标相关


        #region   获取 Config\\ExcelModel\\IndexExcelModel  下所有的excel 文件
        /// <summary>
        /// 获取对应路径下所有的excel 文件  默认为 Config\\ExcelModel\\IndexExcelModel 
        /// </summary>
        /// <param name="ExcelPath"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<List<KeyValue>> GetExeclModelName(string ExcelPath = "Config\\ExcelModel\\IndexExcelModel")
        {

            return Success(AnesQuery.GetExeclModelName(ExcelPath));

        }


        #endregion

        #region    根据  开始时间、结束时间、excel的名称  生成一个以 html 格式 返回的报表



        /// <summary>
        /// /从Excel模板读取一张报表，并返回html 格式的数据
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="execlModelName"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<string> GetReportQueryFromExeclModel(string StartTime, string EndTime, string ExeclModelName = "江苏省麻醉质控.xlsx")
        {
            return Success(AnesQuery.GetReportQueryFromExeclModel(StartTime, EndTime, ExeclModelName));
        }

        #endregion

        #region    获取xml 文件 的key  value  
        /// <summary>
        /// 获取Config\\ExcelDataFormat.xml 路径下对应组的键值列表
        /// </summary>
        /// <param name="GroupName">要查询节点的名称</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<KeyValue>> GetExcelModleDataDictDefautPath(string GroupName)
        {

            return Success(AnesQuery.GetExcelModleDataDictDefautPath(GroupName));
        }

        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<List<KeyValue>> GetExcelModleDictDefautPathAndDefautGroupName()
        {

            return Success(AnesQuery.GetExcelModleDictDefautPathAndDefautGroupName());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<List<KeyValue>> GetExcelModleDataDict(string Path, string GroupName)
        {

            return Success(AnesQuery.GetExcelModleDataDict(Path, GroupName));
        }


        #endregion

        #region      更新sql  默认是 “Config\\ExcelDataFormat.xml” 中的

        /// <summary>
        /// 十七项指标中更新sql 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<string> InsertOrUpdateSqlToExcelModleData(dynamic data)
        {
            KeyValue item = new KeyValue();
            string key = data.Key;
            string value = data.Value;
            string groupName = data.GroupName;
            item.Key = key;
            item.Value = value;
            return Success(AnesQuery.InsertOrUpdateSqlToExcelModleDataToGroup(item, groupName));
        }

        #endregion

        #region     测试sql  返回结果
        /// <summary>
        /// 十七项指标中自己配置的sql进行自我核对
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<string> ExecuteOrTestSQLFromUser(dynamic data)
        {


            return Success(AnesQuery.ExecuteOrTestSQLFromUser(data));
        }

        #endregion

        #region     上传Excel模板

        /// <summary>
        /// 上传十七项指标相关Excel模板 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<string> UploadExcelToDefautPath()
        {
            return Success(AnesQuery.UploadExcelToDefautPath());
        }

        #endregion

        #region    测试

        /// <summary>
        /// 简单测试
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<string> Test()
        {
            return Success(AnesQuery.Test());
        }
        #endregion


        #region     脏数据处理

        /// <summary>
        /// 获取  Config\\DataFormat.xml 文件下 ASA等级  切口等级 等集合项
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<Dictionary<string, List<KeyValue>>> GetFilteDaTaFromDicXml()
        {
            return Success(AnesQuery.GetFilteDaTaFromDicXml());
        }

        /// <summary>
        /// 更新 Config\\DataFormat.xml 文件下 ASA等级  切口等级 等集合项
        /// </summary>
        /// <param name="GroupName"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public RequestResult<string> UpdateFilteDaTaToDicXml(string GroupName, KeyValue keyValue)
        {
            return Success(AnesQuery.UpdateFilteDaTaToDicXml(GroupName, keyValue));
        }


        /// <summary>
        /// 删除十七项指标相关Excel模板  路径为Config\\ExcelModel\\IndexExcelModel 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<string> DeleteExcelModele(string ExcelModeleName)
        {
            return Success(AnesQuery.DeleteExcelModeleWithPathAndExcelName("Config\\ExcelModel\\IndexExcelModel", ExcelModeleName));
        }
        #endregion
        #endregion
    }
}
