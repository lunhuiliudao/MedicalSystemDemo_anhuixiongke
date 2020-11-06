using Dapper;
using Dapper.Data;
using MedicalSystem.AnesPlatform.DataServices;
using MedicalSystem.AnesPlatform.Domain.Utils;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.Report;
using MedicalSystem.Common.FileManage;
using MedicalSystem.Configurations;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using static MedicalSystem.Common.FileManage.DictXML;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 麻醉平台统计查询service   add by xiapei.y@2017-06-08 16:57:06
    /// </summary>
    public interface IPlatformAnesQueryService
    {
        #region 首页统计

        #region 医生首页

        /// <summary>
        /// 医生首页手术动态明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IList<OperQuerytForDoctorIndexEntity> GetOperSelfListForDoctorIndex(OperQueryParaModel model);
        /// <summary>
        /// 医生首页手术列表查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IList<OperQuerytForDoctorIndexEntity> GetOperListForDoctorIndex(OperQueryParaModel model);


        /// <summary>
        /// 医生首页手术信息集中统计查询
        /// </summary>
        OperInfosForDoctorIndexEntity QueryOperInfosForDoctorIndex(OperQueryParaModel model);

        #endregion

        #region 护士首页

        /// <summary>
        /// 护士首页手术动态明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IList<OperQuerytForDoctorIndexEntity> GetOperSelfListForNurseIndex(OperQueryParaModel model);
        /// <summary>
        /// 护士首页手术列表查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IList<OperQuerytForDoctorIndexEntity> GetOperListForNurseIndex(OperQueryParaModel model);


        /// <summary>
        /// 护士首页手术信息集中统计查询
        /// </summary>
        OperInfosForDoctorIndexEntity QueryOperInfosForNurseIndex(OperQueryParaModel model);

        #endregion

        #region 主任首页统计


        /// <summary>
        /// 主任首页手术信息集中统计查询
        /// </summary>
        OperInfosForDirectorIndexEntity QueryOperInfosForDirectorIndex();

        /// <summary>
        /// 主任首页手术信息EChart图标统计
        /// </summary>
        IList<EChartsItemEntity> QueryOperEChartReportForDirectionIndex(OperQueryParaModel model);

        /// <summary>
        /// 主任首页手术信息EChart图标下方集中统计统计
        /// </summary>
        OperReportForDirectionEntity QueryOperReportForDirectionIndex(OperQueryParaModel model);


        /// <summary>
        /// 主任首页右侧EChart图标统计
        /// </summary>
        IList<EChartsItemEntity> QueryRightEChartReportForDirectionIndex(OperQueryParaModel model);

        /// <summary>
        /// 主任首页集中统计数量弹出明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IList<OperDetailListForDirectorIndexEntity> QueryOperDetailForDirectorIndex(OperQueryParaModel model);



        /// <summary>
        /// 主任首页EChart统计数量弹出明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IList<OperDetailListForDirectorIndexEntity> QueryEChartOperDetailForDirectorIndex(OperQueryParaModel model);
        #endregion

        #endregion

        #region 报表配置器
        ReportInformation GetReportConfigByKey(string reportKey, bool clearSql = true);

        List<KeyValue> GetReportConfig();

        bool SaveReportConfig(ReportInformation reportInformation);

        List<dynamic> ExecSql(string key, ReportInformation reportInformation);

        string ExportExcel(string key, ReportInformation reportInformation);

        List<dynamic> ExecSubSql(string key, string subkey, ReportInformation reportInformation);

        string ExportSubReportExcel(string key, string subkey, ReportInformation reportInformation);

        List<KeyValue> GetDict(ReportCondition reportCondition);

        string GetReportSQL(string key, int type, ReportInformation reportInformation);

        string GetSubReportSQL(string key, int type, ReportInformation reportInformation);

        /// <summary>
        /// 返回要查询sql的列
        /// </summary>
        /// <param name="pkey">父报表名</param>
        /// <param name="isSubReport">是否子报表</param>
        /// <param name="reportInformation"></param>
        /// <returns></returns>
        List<string> GetReportColumList(string pkey, Boolean isSubReport, ReportInformation reportInformation);

        /// <summary>
        /// 删除报表模板
        /// </summary>
        /// <param name="ExcelModeleName"></param>
        /// <returns></returns>

        string DeleteExcelModeleWithPathAndExcelName(string ExcelPath, string ExcelModeleName);

        #endregion

        #region  十七项指标操作

        string GetReportQueryFromExeclModel(string StartTime, string EndTime, string ExeclModelName);
        List<KeyValue> GetExeclModelName(string ExcelPath);
        List<KeyValue> GetExcelModleDataDict(string Path, string GroupName);
        List<KeyValue> GetExcelModleDataDictDefautPath(string GroupName);
        List<KeyValue> GetExcelModleDictDefautPathAndDefautGroupName();

        string ExecuteOrTestSQLFromUser(dynamic data);

        #region  更新sql或插入sql  到xml

        //更新sql或插入sql  到xml
        string InsertOrUpdateSqlToExcelModleData(KeyValue keyValue);

        //更新sql或插入sql  到固定的xml组中  
        string InsertOrUpdateSqlToExcelModleDataToGroup(KeyValue keyValue, string groupName);

        //更新sql或插入sql  到固定的xml路径中，默认保存在第一个节点中  
        string InsertOrUpdateSqlToExcelModleDataToPath(KeyValue keyValue, string Path);

        //更新sql或插入sql  到固定的xml组中  
        string InsertOrUpdateSqlToExcelModleDataToPathAndGroup(KeyValue keyValue, string Path, bool isNeedIdentity, string groupName);


        string InsertOrUpdateSqlListExcelModleData(List<KeyValue> kevList);

        #endregion

        #region  上传excel 模板
        //上传excel模板到
        string UploadExcelToDefautPath();
        string UploadExcelToPath(string ExcelPath);

        #endregion
        string Test();

        #region  脏数据处理
        /// <summary>
        /// 获取  Config\\DataFormat.xml 文件下 ASA等级  切口等级 等集合项，并按组名保存在字典中 
        /// </summary>
        /// <returns></returns>
        Dictionary<string, List<KeyValue>> GetFilteDaTaFromDicXml();
        /// <summary>
        ///  更新用户自己需要的数据分类
        /// </summary>
        /// <param name="groupName">要更新的组名</param>
        /// <param name="keyValue">要更新的键值对</param>
        /// <returns></returns>
        string UpdateFilteDaTaToDicXml(string groupName, KeyValue keyValue);

        #endregion


        #endregion
    }

    public class PlatformAnesQueryService : BaseService<PlatformAnesQueryService>, IPlatformAnesQueryService
    {
        /// <summary>
        /// MDK配置信息
        /// </summary>
        IMdkConfiguration mdkConfig;
        /// <summary>
        /// 报表配置文件列表
        /// </summary>
        private static Dictionary<string, ReportInformation> _reportDataDict;
        public Dictionary<string, ReportInformation> ReportDataDict
        {
            get
            {
                if (_reportDataDict == null)
                {
                    ExcelModelDict = new Dictionary<string, string>();
                    string appPath = GetAppPath();
                    string filepath = Path.Combine(appPath, "Config\\ExcelModel");
                    DirectoryInfo folder = new DirectoryInfo(filepath);

                    foreach (FileInfo file in folder.GetFiles("*.xlsx"))
                    {
                        ExcelModelDict.Add(Path.GetFileNameWithoutExtension(file.FullName), file.FullName);
                    }

                    DirectoryInfo[] directoryInfos = folder.GetDirectories();

                    if (directoryInfos != null && directoryInfos.Length > 0)
                    {
                        foreach (DirectoryInfo item in directoryInfos)
                        {
                            foreach (FileInfo file in item.GetFiles("*.xlsx"))
                            {
                                ExcelModelDict.Add(Path.GetFileNameWithoutExtension(file.FullName), file.FullName);
                            }
                        }
                    }

                    //载入报表文件
                    _reportDataDict = new Dictionary<string, ReportInformation>();
                    filepath = Path.Combine(appPath, "Config\\ReportData");
                    folder = new DirectoryInfo(filepath);

                    foreach (FileInfo file in folder.GetFiles("*.xml"))
                    {
                        try
                        {
                            //XML格式错误，导致加载错误不影响其他XML文件解析
                            DataSet ds = XMLFileHelper.ConvertXMLFileToDataSet(file.FullName);
                            List<ReportInformation> reoprtDataList = (List<ReportInformation>)XmlHelper.DataSetToIList<ReportInformation>(ds, "XMLData");
                            if (reoprtDataList != null && reoprtDataList.Count > 0)
                            {
                                ReportDataDict.Add(reoprtDataList[0].ReportTitle.ReportName, reoprtDataList[0]);
                            }
                        }
                        catch (Exception) { }
                    }
                    _reportDataDict = ReportDataDict.OrderBy(x => x.Value.ReportTitle.SortNumber).ToDictionary(t => t.Key, t => t.Value);
                }
                return _reportDataDict;
            }
        }
        /// <summary>
        /// 导出报表模板
        /// </summary>
        static Dictionary<string, string> ExcelModelDict;
        protected PlatformAnesQueryService()
            : base() { }
        public PlatformAnesQueryService(IDapperContext context)
            : base(context)
        {
            MdkConfiguration.AddCustomConfig<XmlDictConfig>();
            mdkConfig = MdkConfiguration.GetConfig();
        }

        #region 平台首页查询
        #region 医生首页统计
        /// <summary>
        /// 医生首页手术查询
        /// </summary>
        public IList<OperQuerytForDoctorIndexEntity> GetOperListForDoctorIndex(OperQueryParaModel model)
        {
            string sql = sqlDict.GetSQLByKey("GetOperListForDoctorIndex");

            if (!string.IsNullOrEmpty(model.OrderName) && !string.IsNullOrEmpty(model.OrderSort))
            {
                if (model.OrderSort.ToLower() == "ascending")
                {
                    sql += " ORDER BY " + model.OrderName + " ASC ";
                }
                else if (model.OrderSort.ToLower() == "descending")
                {
                    sql += " ORDER BY " + model.OrderName + " DESC ";
                }
            }

            List<DictXML.DictGroup> lstASA = mdkConfig.XmlDict.GetGroupByName("ASAGrade");
            List<DictXML.DictGroup> lstScale = mdkConfig.XmlDict.GetGroupByName("OperScale");
            //List<AAAStatistics.AAAGroup> lstWound = GetAAAByGroupName("WoundGrade");

            List<string> sqlStr = new List<string>();
            sqlStr = mdkConfig.XmlDict.ReplaceParamsForSql(lstASA, sqlStr);
            sqlStr = mdkConfig.XmlDict.ReplaceParamsForSql(lstScale, sqlStr);
            // sqlStr = ReplaceParamsForSql(lstWound, sqlStr);
            sql = string.Format(sql, sqlStr.ToArray());
            return dapper.Set<OperQuerytForDoctorIndexEntity>().Query(sql, new
            {
                PatName = model.PatName,
                InpNo = model.InpNo,
                OperDept = model.OperDept,
                OperDoctor = model.OperDoctor,
                OperName = model.OperName,
                AnesDoctor = model.AnesDoctor,
                Nurse = model.Nurse,
                AnesMethod = model.AnesMethod,
                OperScale = model.OperScale,
                ASA = model.ASA,
                EMERGENCY = model.EMERGENCY == true ? 1 : 0,
                ISOLATION = model.ISOLATION == true ? 2 : 0,
                CurrentUserId = model.CurrentUserId,
                //ASINFECTEDA = model.ASINFECTEDA,
                StartDate = Convert.ToDateTime(Convert.ToDateTime(model.StartDate).ToShortDateString()),
                EndDate = Convert.ToDateTime(Convert.ToDateTime(model.StartDate).AddDays(1).ToShortDateString())
            });
        }

        /// <summary>
        /// 医生首页手术查询
        /// </summary>
        public IList<OperQuerytForDoctorIndexEntity> GetOperSelfListForDoctorIndex(OperQueryParaModel model)
        {
            //基础SQL
            string sql = sqlDict.GetSQLByKey("GetOperSelfListForDoctorIndex");
            string sqlWhere = @"  where OPERATING_ROOM_NO IS NOT NULL AND (AnesDoctorIds LIKE '%' || :AnesDoctor || '%'  OR  :AnesDoctor IS NULL ) ";

            //时间条件
            //时间条件
            DateTime startDate = Convert.ToDateTime(Convert.ToDateTime(model.StartDate).ToShortDateString());
            DateTime endDate = startDate.AddDays(1);

            //动态添加条件
            switch (model.QueryType)
            {
                case "1":  //总数
                    break;
                case "2":  //已完成台数
                    sqlWhere += " and Oper_Status_Code >= 35 ";
                    break;
                case "3":  //手术中台数
                    sqlWhere += " and Oper_status_code >=5 and  Oper_status_code <35 ";
                    break;
                case "4":  //转ICU台数
                    sqlWhere += " and Oper_Status_Code = 65";
                    break;
                case "5":  //复苏时长≥2h
                    sqlWhere += " and TRUNC((OUT_PACU_DATE_TIME - IN_PACU_DATE_TIME) * 1440) >= 120";
                    break;
                case "6":  //本月累计
                    startDate = Convert.ToDateTime(startDate.Year + "-" + startDate.Month + "-01");
                    endDate = startDate.AddMonths(1);
                    break;
                case "7":  //抢救台数
                    startDate = Convert.ToDateTime(startDate.Year + "-" + startDate.Month + "-01");
                    endDate = startDate.AddMonths(1);
                    sqlWhere += " and ISRESCURE = 1 ";
                    break;
                case "8":  //急诊急救台数
                    startDate = Convert.ToDateTime(startDate.Year + "-" + startDate.Month + "-01");
                    endDate = startDate.AddMonths(1);
                    sqlWhere += " and Emergency_Ind = 1";
                    break;
            }

            if (Convert.ToInt32(model.QueryType) < 6)
            {
                sqlWhere += " and nvl(in_date_time,SCHEDULED_DATE_TIME)>= :StartDate AND nvl(in_date_time,SCHEDULED_DATE_TIME) < :EndDate";
            }
            else
            {
                sqlWhere += " and start_date_time>= :StartDate AND start_date_time < :EndDate and Oper_Status_Code>=35";
            }
            sql += sqlWhere;
            return dapper.Set<OperQuerytForDoctorIndexEntity>().Query(sql, new
            {
                AnesDoctor = model.AnesDoctor,
                CurrentUserId = model.AnesDoctor,
                StartDate = startDate,
                EndDate = endDate
            });
        }

        /// <summary>
        /// 医生首页手术信息集中统计查询
        /// </summary>
        public OperInfosForDoctorIndexEntity QueryOperInfosForDoctorIndex(OperQueryParaModel model)
        {
            string sql = sqlDict.GetSQLByKey("QueryOperInfosForDoctorIndex1");
            // //针对oracle ora-03113: 通信通道的文件结束 报错使用以下SQL
            return dapper.Set<OperInfosForDoctorIndexEntity>().Query(sql, new
            {
                OperDate = Convert.ToDateTime(Convert.ToDateTime(model.StartDate).ToShortDateString()),
                YOperDate = Convert.ToDateTime(Convert.ToDateTime(model.StartDate).ToShortDateString()).AddDays(-1),
                TOperDate = Convert.ToDateTime(Convert.ToDateTime(model.StartDate).ToShortDateString()).AddDays(+1),
                AnesDoctor = model.AnesDoctor
            }).FirstOrDefault();
        }
        #endregion

        #region 护士首页统计
        /// <summary>
        /// 护士首页手术查询
        /// </summary>
        public IList<OperQuerytForDoctorIndexEntity> GetOperListForNurseIndex(OperQueryParaModel model)
        {
            string sql = sqlDict.GetSQLByKey("GetOperListForNurseIndex");

            if (!string.IsNullOrEmpty(model.OrderName) && !string.IsNullOrEmpty(model.OrderSort))
            {
                if (model.OrderSort.ToLower() == "ascending")
                {
                    sql += " ORDER BY " + model.OrderName + " ASC ";
                }
                else if (model.OrderSort.ToLower() == "descending")
                {
                    sql += " ORDER BY " + model.OrderName + " DESC ";
                }
            }

            List<DictXML.DictGroup> lstASA = mdkConfig.XmlDict.GetGroupByName("ASAGrade");
            List<DictXML.DictGroup> lstScale = mdkConfig.XmlDict.GetGroupByName("OperScale");
            //List<AAAStatistics.AAAGroup> lstWound = GetAAAByGroupName("WoundGrade");

            List<string> sqlStr = new List<string>();
            sqlStr = mdkConfig.XmlDict.ReplaceParamsForSql(lstASA, sqlStr);
            sqlStr = mdkConfig.XmlDict.ReplaceParamsForSql(lstScale, sqlStr);
            // sqlStr = ReplaceParamsForSql(lstWound, sqlStr);
            sql = string.Format(sql, sqlStr.ToArray());
            return dapper.Set<OperQuerytForDoctorIndexEntity>().Query(sql, new
            {
                PatName = model.PatName,
                InpNo = model.InpNo,
                OperDept = model.OperDept,
                OperDoctor = model.OperDoctor,
                OperName = model.OperName,
                AnesDoctor = model.AnesDoctor,
                Nurse = model.Nurse,
                AnesMethod = model.AnesMethod,
                OperScale = model.OperScale,
                ASA = model.ASA,
                CurrentUserId = model.CurrentUserId,
                EMERGENCY = model.EMERGENCY == true ? 1 : 0,
                ISOLATION = model.ISOLATION == true ? 2 : 0,
                //ASINFECTEDA = model.ASINFECTEDA,
                StartDate = Convert.ToDateTime(Convert.ToDateTime(model.StartDate).ToShortDateString()),
                EndDate = Convert.ToDateTime(Convert.ToDateTime(model.StartDate).AddDays(1).ToShortDateString())
            });
        }

        /// <summary>
        /// 护士首页手术查询
        /// </summary>
        public IList<OperQuerytForDoctorIndexEntity> GetOperSelfListForNurseIndex(OperQueryParaModel model)
        {
            //基础SQL
            string sql = sqlDict.GetSQLByKey("GetOperSelfListForNurseIndex");
            string sqlWhere = @"  where OPERATING_ROOM_NO IS NOT NULL  AND (NurseIds LIKE '%' || :Nurse || '%'  OR :Nurse IS NULL ) ";

            //时间条件
            DateTime startDate = Convert.ToDateTime(Convert.ToDateTime(model.StartDate).ToShortDateString());
            DateTime endDate = startDate.AddDays(1);
            //动态添加条件
            switch (model.QueryType)
            {
                case "1":  //总数
                    break;
                case "2":  //已完成台数
                    sqlWhere += " and Oper_Status_Code >= 35 ";
                    break;
                case "3":  //手术中台数
                    sqlWhere += " and Oper_status_code >=5 and  Oper_status_code <35 ";
                    break;
                case "4":  //转ICU台数
                    sqlWhere += " and Oper_Status_Code = 65";
                    break;
                case "5":  //复苏时长≥2h
                    sqlWhere += " and TRUNC((OUT_PACU_DATE_TIME - IN_PACU_DATE_TIME) * 1440) >= 120";
                    break;
                case "6":  //本月累计
                    startDate = Convert.ToDateTime(startDate.Year + "-" + startDate.Month + "-01");
                    endDate = startDate.AddMonths(1);
                    break;
                case "7":  //抢救台数
                    startDate = Convert.ToDateTime(startDate.Year + "-" + startDate.Month + "-01");
                    endDate = startDate.AddMonths(1);
                    sqlWhere += " and ISRESCURE = 1 ";
                    break;
                case "8":  //急诊急救台数
                    startDate = Convert.ToDateTime(startDate.Year + "-" + startDate.Month + "-01");
                    endDate = startDate.AddMonths(1);
                    sqlWhere += " and Emergency_Ind = 1";
                    break;
            }
            if (Convert.ToInt32(model.QueryType) < 6)
            {
                sqlWhere += " and nvl(in_date_time,SCHEDULED_DATE_TIME)>= :StartDate AND nvl(in_date_time,SCHEDULED_DATE_TIME) < :EndDate ";
            }
            else
            {
                sqlWhere += " and start_date_time>= :StartDate AND start_date_time < :EndDate and Oper_Status_Code>=35";
            }
            sql += sqlWhere;
            return dapper.Set<OperQuerytForDoctorIndexEntity>().Query(sql, new
            {
                Nurse = model.Nurse,
                CurrentUserId = model.Nurse,
                StartDate = startDate,
                EndDate = endDate
            });
        }

        /// <summary>
        /// 护士首页手术信息集中统计查询
        /// </summary>
        public OperInfosForDoctorIndexEntity QueryOperInfosForNurseIndex(OperQueryParaModel model)
        {
            string sql = sqlDict.GetSQLByKey("QueryOperInfosForNurseIndex");

            return dapper.Set<OperInfosForDoctorIndexEntity>().Query(sql, new
            {
                OperDate = Convert.ToDateTime(Convert.ToDateTime(model.StartDate).ToShortDateString()),
                Nurse = model.Nurse
            }).FirstOrDefault();
        }
        #endregion

        #region 主任首页统计
        /// <summary>
        /// 主任首页手术信息集中统计查询
        /// </summary>
        public OperInfosForDirectorIndexEntity QueryOperInfosForDirectorIndex()
        {
            string sql = sqlDict.GetSQLByKey("QueryOperInfosForDirectorIndex1");
            return dapper.Set<OperInfosForDirectorIndexEntity>().Query(sql, new { }).FirstOrDefault();
        }
        /// <summary>
        /// 主任首页手术信息EChart图标统计
        /// </summary>
        public virtual IList<EChartsItemEntity> QueryOperEChartReportForDirectionIndex(OperQueryParaModel model)
        {
            string sql = "";
            if (model.TimeType == "month")
            {
                DateTime date = Convert.ToDateTime(Convert.ToDateTime(model.StartDate).Year + "-" + Convert.ToDateTime(model.StartDate).Month + "-01");
                //统计月

                sql = sqlDict.GetSQLByKey("QueryLeftEChartReportForMonthDirectionIndex");
                return dapper.Set<EChartsItemEntity>().Query(sql, new { StartDate = date.ToShortDateString() });
            }
            //统计年
            else //if (model.TimeType == "year")
            {
                sql = sqlDict.GetSQLByKey("QueryLeftEChartReportForYearDirectionIndex");
                return dapper.Set<EChartsItemEntity>().Query(sql, new { StartDate = Convert.ToDateTime(model.StartDate).ToShortDateString() });
            }

        }
        /// <summary>
        /// 主任首页手术信息EChart图标下方集中统计统计
        /// </summary>
        public OperReportForDirectionEntity QueryOperReportForDirectionIndex(OperQueryParaModel model)
        {
            string sql = "";
            if (model.TimeType == "month")
            {
                //统计月
                sql = sqlDict.GetSQLByKey("QueryLeftEChartInfosForMonthDirectionIndex");
                return dapper.Set<OperReportForDirectionEntity>().Query(sql, new { Year = Convert.ToDateTime(model.StartDate).Year, Month = Convert.ToDateTime(model.StartDate).Month }).FirstOrDefault();
            }
            else if (model.TimeType == "year")
            {
                //统计年
                sql = sqlDict.GetSQLByKey("QueryLeftEChartInfosForYearDirectionIndex");
                return dapper.Set<OperReportForDirectionEntity>().Query(sql, new { Year = Convert.ToDateTime(model.StartDate).Year, Month = Convert.ToDateTime(model.StartDate).Month }).FirstOrDefault();
            }
            //统计年
            return dapper.Set<OperReportForDirectionEntity>().Query(sql, new { }).FirstOrDefault();
        }

        /// <summary>
        /// 主任首页右侧饼图EChart图标统计
        /// </summary>
        public IList<EChartsItemEntity> QueryRightEChartReportForDirectionIndex(OperQueryParaModel model)
        {

            string sql = "";

            if (model.QueryType == "ASA")
            {
                #region ASA统计
                if (model.TimeType == "month")
                {
                    //统计月
                    sql = sqlDict.GetSQLByKey("QueryRightChartForASAForMonthDirectorIndex");
                    List<DictXML.DictGroup> lstASA = mdkConfig.XmlDict.GetGroupByName("ASAGrade");
                    List<string> sqlStr = new List<string>();
                    sqlStr = mdkConfig.XmlDict.ReplaceParamsForSql(lstASA, sqlStr);
                    sql = string.Format(sql, sqlStr.ToArray());
                    return dapper.Set<EChartsItemEntity>().Query(sql, new { Year = Convert.ToDateTime(model.StartDate).Year, Month = Convert.ToDateTime(model.StartDate).Month });
                }
                else if (model.TimeType == "year")
                {
                    //统计年
                    sql = sqlDict.GetSQLByKey("QueryRightChartForASAForYearDirectorIndex");
                    List<DictXML.DictGroup> lstASA = mdkConfig.XmlDict.GetGroupByName("ASAGrade");
                    List<string> sqlStr = new List<string>();
                    sqlStr = mdkConfig.XmlDict.ReplaceParamsForSql(lstASA, sqlStr);
                    sql = string.Format(sql, sqlStr.ToArray());
                    return dapper.Set<EChartsItemEntity>().Query(sql, new { Year = Convert.ToDateTime(model.StartDate).Year });
                }
                #endregion
            }
            else if (model.QueryType == "AnesMethod")
            {
                if (model.TimeType == "month")
                {
                    sql = sqlDict.GetSQLByKey("QueryRightChartForMethodForMonthDirectorIndex");
                    return dapper.Set<EChartsItemEntity>().Query(sql, new { Year = Convert.ToDateTime(model.StartDate).Year, Month = Convert.ToDateTime(model.StartDate).Month });
                }
                else if (model.TimeType == "year")
                {

                    sql = sqlDict.GetSQLByKey("QueryRightChartForMethodForYearDirectorIndex");
                    return dapper.Set<EChartsItemEntity>().Query(sql, new { Year = Convert.ToDateTime(model.StartDate).Year });
                }
            }


            return dapper.Set<EChartsItemEntity>().Query(sql, new { });
        }

        /// <summary>
        /// 主任首页弹出手术明细列表
        /// </summary>
        public IList<OperDetailListForDirectorIndexEntity> QueryOperDetailForDirectorIndex(OperQueryParaModel model)
        {


            string sqlBasic = sqlDict.GetSQLByKey("QueryOperDetailForDirectorIndex");

            string sqlWhere = " 1=1 ";

            //动态添加条件
            switch (model.SearchMark)
            {
                case "1":  //总数
                    break;
                case "2":  //已完成台数
                    sqlWhere += " and Oper_status_code >=35";
                    break;
                case "3":  //手术中台数
                    sqlWhere += " and Oper_status_code >=5 and  Oper_status_code <35";
                    break;
                case "4":  //取消手术
                    sqlWhere += " and Oper_status_code = -80 ";
                    break;
                case "5":  //待完成
                    sqlWhere += " and oper_status_code>=0 and oper_status_code<5";
                    break;
                case "6":  //急诊台数
                    sqlWhere += " and Emergency_Ind=1";
                    break;
                case "7":  //隔离、感染台数
                    sqlWhere += " and (Isolation_Ind = 1 or INFECTED_IND = 1) ";
                    break;
                case "8":  //抢救台数
                    sqlWhere += " and ISRESCURE = 1 ";
                    break;
                case "9":  //死亡台数
                    sqlWhere += " and anes_death = 1 ";
                    break;
                case "10":  //非预期事件例数
                    sqlWhere += @" and (CANCELED_TYPE = '1' or PACU_TEMPERATURE =1 or CONS_DISTURBANCE =1
                                        or TRACHEA_6H = 1 or OXYGEN_SATURATION = 1 or ANES_ANAPHYLAXIS = 1 or
                                          ANES_DEATH = 1 or RES_TRACT_OBSTRUCE = 1 or CENTRAL_VENOUS = 1
                                        or ANES_START_24H_DEATH = 1 or ANES_START_24H_STOP = 1 or SPINAL_ANES_COMP = 1
                                        or TRACHEA_HOARSE = 1 or AFTER_ANES_COMA = 1 or USE_REMINDERS = 1 or
                                        RES_TRACT_OBSTRUCE = 1 or OTHER_NOT_EXP = 1 or NO_PLAN_IN_ICU = 1) ";
                    break;
                case "11":  //术后转ICU
                    sqlWhere += " and Oper_status_code = 65 ";
                    break;
                case "12":  //复苏时长》2小时
                    sqlWhere += " and  TRUNC((OUT_PACU_DATE_TIME-IN_PACU_DATE_TIME)*1440 ) >= 120 ";
                    break;
                case "13":  //明日预约 
                    break;
                case "14":  //昨日手术总数

                    break;
                case "15":  //昨日隔离、感染台数
                    sqlWhere += " and (Isolation_Ind = 1 or INFECTED_IND = 1 ) ";
                    break;
                case "16":  //昨日抢救台数
                    sqlWhere += " and ISRESCURE = 1  ";
                    break;
                case "17":  //昨日术后转ICU
                    sqlWhere += " and Oper_status_code = 65 ";
                    break;
                case "18":  //昨日复苏时长》2小时
                    sqlWhere += " and  TRUNC((OUT_PACU_DATE_TIME-IN_PACU_DATE_TIME)*1440 ) >= 120 ";
                    break;
            }


            string timeWhere = " ";
            if (Convert.ToInt32(model.SearchMark) < 12)
            {
                timeWhere = "  to_char(nvl(in_date_time,scheduled_date_time),'YYYY-MM-DD')=to_char(sysdate,'YYYY-MM-DD')";
            }
            else if (Convert.ToInt32(model.SearchMark) == 13)// 预约手术
            {
                timeWhere = "  to_char(scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate+1,'YYYY-MM-DD')";
            }
            else if (Convert.ToInt32(model.SearchMark) > 13)
            {
                timeWhere = "  to_char(start_date_time,'YYYY-MM-DD')=to_char(sysdate-1,'YYYY-MM-DD')";
            }
            else
            {
                timeWhere = "  to_char(nvl(in_date_time,scheduled_date_time),'YYYY-MM-DD')=to_char(sysdate,'YYYY-MM-DD')";
            }

            sqlBasic = string.Format(sqlBasic, sqlWhere, timeWhere);


            return dapper.Set<OperDetailListForDirectorIndexEntity>().Query(sqlBasic, new { });
        }

        /// <summary>
        /// 主任首页弹出手术明细列表
        /// </summary>
        public IList<OperDetailListForDirectorIndexEntity> QueryEChartOperDetailForDirectorIndex(OperQueryParaModel model)
        {

            string sqlBasic = sqlDict.GetSQLByKey("QueryEChartOperDetailForDirectorIndex");
            string sql = "";
            DateTime startDate = DateTime.Now;
            if (model.QueryType == "line")//line折线图明细
            {
                DateTime dateTime = Convert.ToDateTime(model.StartDate);
                startDate = Convert.ToDateTime(dateTime.Year + "-" + dateTime.Month + "-" + model.SearchMark);

                string sqlWhere = " START_DATE_TIME >= :StartDate AND START_DATE_TIME < :EndDate and Oper_Status_code >= 35 ";
                sql = string.Format(sqlBasic, sqlWhere);
            }
            else if (model.QueryType == "")//饼图
            {

            }


            return dapper.Set<OperDetailListForDirectorIndexEntity>().Query(sql, new
            {
                StartDate = startDate,
                EndDate = startDate.AddDays(1)
            });
        }
        #endregion

        #endregion

        #region 报表配置器
        /// <summary>
        /// 获取制定报表
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="clearSql">清空sql语句</param>
        /// <returns></returns>
        public ReportInformation GetReportConfigByKey(string reportName, bool clearSql = true)
        {
            try
            {
                if (ReportDataDict.ContainsKey(reportName))
                {

                    ReportInformation result = (ReportInformation)ReportDataDict[reportName].DeepClone();
                    if (clearSql)
                    {
                        //父报表对应SQL语句清空
                        result.ReportTitle.StrSql = string.Empty;
                        //子报表对应SQL语句清空
                        if (result.SubReportInformationList != null && result.SubReportInformationList.Count > 0)
                        {
                            foreach (var item in result.SubReportInformationList)
                            {
                                item.ReportTitle.StrSql = string.Empty;
                            }
                        }
                    }

                    result.ReportConditionList.ForEach(r =>
                    {
                        if (r.ControlType == EnumControlType.DatePick)
                        {
                            if (r.DateDefaultVal == EnumDateDefaultVal.CurrentDate)
                            {
                                r.Value = DateTime.Now.ToString("yyyy-MM-dd");
                            }
                            else if (r.DateDefaultVal == EnumDateDefaultVal.CurrentFirstDate)
                            {
                                r.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd");
                            }
                            else if (r.DateDefaultVal == EnumDateDefaultVal.CurrentLastDate)
                            {
                                r.Value = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
                            }
                        }
                    });
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取所有报表列表
        /// </summary>
        /// <returns></returns>
        public List<KeyValue> GetReportConfig()
        {
            _reportDataDict = null;
            List<KeyValue> result = new List<KeyValue>();
            foreach (var item in ReportDataDict)
            {
                result.Add(new KeyValue() { Key = item.Value.ReportTitle.ReportName, Value = item.Value.ReportTitle.Menu, flag = item.Value.ReportTitle.SortNumber });
            }
            result = result.OrderBy(x => x.flag).ToList();//排序
            return result;
        }

        public List<KeyValue> GetDict(ReportCondition reportCondition)
        {
            List<KeyValue> result = new List<KeyValue>();
            switch (reportCondition.DictType)
            {
                case EnumDictType.NurseDict:
                    result = dapper.Set<MED_HIS_USERS>().Select(d => d.USER_JOB.Contains("护士")).OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.USER_JOB_ID, Value = x.USER_NAME, InputCode = string.IsNullOrEmpty(x.INPUT_CODE) ? StringManage.GetPYString(x.USER_NAME) : x.INPUT_CODE }).ToList();
                    break;
                case EnumDictType.DoctorDict:
                    result = dapper.Set<MED_HIS_USERS>().Select(d => d.USER_JOB.Contains("医生")).OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.USER_JOB_ID, Value = x.USER_NAME, InputCode = string.IsNullOrEmpty(x.INPUT_CODE) ? StringManage.GetPYString(x.USER_NAME) : x.INPUT_CODE }).ToList();
                    break;
                case EnumDictType.DeptDict:
                    result = dapper.Set<MED_DEPT_DICT>().Select().OrderBy(d => d.INPUT_CODE).Select(x => new KeyValue() { Key = x.DEPT_CODE, Value = x.DEPT_NAME, InputCode = string.IsNullOrEmpty(x.INPUT_CODE) ? StringManage.GetPYString(x.DEPT_NAME).ToUpper() : x.INPUT_CODE.ToUpper() }).ToList();
                    break;
                case EnumDictType.DynamicDict:
                    if (reportCondition.DynamicDictDes != null)
                    {
                        string sqlstr = string.Format("SELECT {0} as Key,{1} as Value From {2} WHERE 1=1 {3}",
                            reportCondition.DynamicDictDes.KeyColumn,
                            reportCondition.DynamicDictDes.ValColumn,
                            reportCondition.DynamicDictDes.TableName,
                            string.IsNullOrWhiteSpace(reportCondition.DynamicDictDes.Condition) ? "" : "AND " + reportCondition.DynamicDictDes.Condition);
                        result = dapper.Query<KeyValue>(sqlstr);
                        List<KeyValue> tempResult = new List<KeyValue>();
                        foreach (KeyValue key in result)
                        {
                            if (!string.IsNullOrEmpty(key.Value))
                            {
                                key.InputCode = StringManage.GetPYString(key.Value);
                            }

                            tempResult.Add(key);
                        }
                        result = tempResult;
                    }
                    else
                    {
                        result = new List<KeyValue>();
                    }
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// 保存报表配置信息
        /// </summary>
        /// <param name="reportInformation"></param>
        /// <returns></returns>
        public bool SaveReportConfig(ReportInformation reportInformation)
        {
            try
            {
                if (reportInformation != null)
                {
                    List<ReportInformation> list = new List<ReportInformation>();
                    list.Add(reportInformation);
                    DataSet dts = XmlHelper.IListToDataSet(list);
                    XMLFileHelper.ConvertDataSetToXMLFile(dts, string.Format("{0}\\Config\\ReportData\\{1}.xml", GetAppPath(), reportInformation.ReportTitle.ReportName));
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 处理报表查询条件
        /// </summary>
        /// <param name="reportConditionList"></param>
        /// <param name="dp"></param>
        /// <returns></returns>
        private DynamicParameters CreateDynamicParameters(List<ReportCondition> reportConditionList, DynamicParameters dp = null)
        {
            if (dp == null)
                dp = new DynamicParameters();
            if (reportConditionList != null)
            {
                foreach (ReportCondition item in reportConditionList)
                {
                    if (string.IsNullOrWhiteSpace(item.Value))
                    {
                        item.Value = null;
                    }
                    switch (item.DataType)
                    {
                        case EnumDataType.String:
                            dp.Add(item.FieldName, Convert.ToString(item.Value), DbType.String);
                            break;
                        case EnumDataType.DateTime:
                            if (item.DateControlType == EnumDateControlType.year)
                            {
                                dp.Add(item.FieldName, Convert.ToDateTime(item.Value).ToString("yyyy"), DbType.String);
                            }
                            else if (item.DateControlType == EnumDateControlType.month)
                            {
                                dp.Add(item.FieldName, Convert.ToDateTime(item.Value).ToString("yyyy-MM"), DbType.String);
                            }
                            else
                            {
                                if (item.FieldName.ToUpper() == "ENDTIME" && item.DateControlType != EnumDateControlType.datetime)
                                {
                                    dp.Add(item.FieldName, Convert.ToDateTime(item.Value).AddDays(1).AddSeconds(-1), DbType.DateTime);
                                }
                                else
                                {
                                    dp.Add(item.FieldName, Convert.ToDateTime(item.Value), DbType.DateTime);
                                }
                            }
                            break;
                        case EnumDataType.Int:
                            dp.Add(item.FieldName, Convert.ToInt32(item.Value), DbType.Int32);
                            break;
                        case EnumDataType.Double:
                            dp.Add(item.FieldName, Convert.ToDouble(item.Value), DbType.Double);
                            break;
                        case EnumDataType.Bool:
                            dp.Add(item.FieldName, Convert.ToBoolean(item.Value), DbType.Boolean);
                            break;
                        default:
                            dp.Add(item.FieldName, Convert.ToString(item.Value), DbType.String);
                            break;
                    }
                }
            }
            return dp;
        }

        /// <summary>
        /// 处理报表查询条件
        /// </summary>
        /// <param name="reportConditionList"></param>
        /// <param name="dp"></param>
        /// <returns></returns>
        private DynamicParameters CreateDynamicParameters(List<ReportSubCondition> reportSubConditionList, DynamicParameters dp = null)
        {
            if (dp == null)
                dp = new DynamicParameters();
            if (reportSubConditionList != null)
            {
                foreach (ReportSubCondition item in reportSubConditionList)
                {
                    if (string.IsNullOrWhiteSpace(item.Value))
                    {
                        item.Value = null;
                    }
                    switch (item.DataType)
                    {
                        case EnumDataType.String:
                            dp.Add(item.ParamName.Trim(), Convert.ToString(item.Value), DbType.String);
                            break;
                        case EnumDataType.DateTime:
                            dp.Add(item.ParamName.Trim(), Convert.ToDateTime(item.Value), DbType.DateTime);
                            break;
                        case EnumDataType.Int:
                            dp.Add(item.ParamName.Trim(), Convert.ToInt32(item.Value), DbType.Int32);
                            break;
                        case EnumDataType.Double:
                            dp.Add(item.ParamName.Trim(), Convert.ToDouble(item.Value), DbType.Double);
                            break;
                        case EnumDataType.Bool:
                            dp.Add(item.ParamName.Trim(), Convert.ToBoolean(item.Value), DbType.Boolean);
                            break;
                        default:
                            dp.Add(item.ParamName.Trim(), Convert.ToString(item.Value), DbType.String);
                            break;
                    }
                }
            }
            return dp;
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="key"></param>
        /// <param name="reportCondition"></param>
        /// <returns></returns>
        public List<dynamic> ExecSql(string key, ReportInformation reportInformation)
        {
            try
            {
                List<dynamic> result = new List<dynamic>();
                if (ReportDataDict.ContainsKey(key))
                {
                    DynamicParameters dp = CreateDynamicParameters(reportInformation.ReportConditionList);
                    dp = CreateDynamicParameters(reportInformation.ReportSubConditionList, dp);
                    //返回动态对象
                    result = dapper.Query<dynamic>(ReportDataDict[key].ReportTitle.StrSql, dp);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="key"></param>
        /// <param name="reportCondition"></param>
        /// <returns></returns>
        public string ExportExcel(string key, ReportInformation reportInformation)
        {
            try
            {
                DataTable dtColumn = new DataTable();
                dtColumn.Columns.Add("Title");
                dtColumn.Columns.Add("FieldName");
                List<dynamic> result = new List<dynamic>();
                if (ReportDataDict.ContainsKey(key))
                {
                    string directoryName = string.Concat(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "TempExprotExcel\\");
                    if (!Directory.Exists(directoryName))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(directoryName);
                        DirectorySecurity dirSecurity = di.GetAccessControl();
                        dirSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
                        di.SetAccessControl(dirSecurity);
                    }

                    DynamicParameters dp = CreateDynamicParameters(reportInformation.ReportConditionList);
                    dp = CreateDynamicParameters(reportInformation.ReportSubConditionList, dp);

                    DataTable dt = dapper.Fill(ReportDataDict[key].ReportTitle.StrSql, dp);
                    dt.TableName = "Table";
                    string FileName = key + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                    string FilePath = string.Concat(directoryName, FileName);
                    if (ExcelModelDict.ContainsKey(key) && !string.IsNullOrWhiteSpace(reportInformation.ReportTitle.ModelFileName))
                    {
                        string modelExcelPath = ExcelModelDict[key];
                        byte[] bytes = FileLibHelper.FileToBytes(modelExcelPath);
                        Stream stream = new MemoryStream(bytes);
                        ExcelFileHelper.ExportExcelForModel(dt, stream, FilePath);
                    }
                    else
                    {
                        //导出Excel,构造需要导出的列
                        foreach (ReportColumn item in ReportDataDict[key].ReportColumnList)
                        {
                            if (item.IsExport)
                            {
                                DataRow newRow = dtColumn.NewRow();
                                newRow["Title"] = item.Title;
                                newRow["FieldName"] = item.FieldName;
                                dtColumn.Rows.Add(newRow);
                            }
                        }
                        ExcelFileHelper.ExportExcelWithAspose(dt, dtColumn, FilePath);
                    }
                    return FileName;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取当前根目录
        /// </summary>
        /// <returns></returns>
        private string GetAppPath()
        {
            string result = string.Empty;

            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                result = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath);

            }
            else
            {

                string path = Application.ExecutablePath;
                if (path.Contains(@"\"))
                {
                    int pos = path.LastIndexOf(@"\");
                    path = path.Remove(pos + 1);
                }
                if (!path.EndsWith(@"\"))
                    path += @"\";
                result = path;

            }
            return result;
        }

        /// <summary>
        /// 执行子报表SQL语句
        /// </summary>
        /// <param name="key"></param>
        /// <param name="reportInformation"></param>
        /// <returns></returns>
        public List<dynamic> ExecSubSql(string key, string subkey, ReportInformation reportInformation)
        {
            try
            {
                List<dynamic> result = new List<dynamic>();
                if (ReportDataDict.ContainsKey(key))
                {
                    DynamicParameters dp = CreateDynamicParameters(reportInformation.ReportConditionList);
                    dp = CreateDynamicParameters(reportInformation.ReportSubConditionList, dp);
                    ReportInformation subReportInformation = ReportDataDict[key].SubReportInformationList.FirstOrDefault(d => d.ReportTitle.ReportName == subkey);
                    //返回动态对象
                    result = dapper.Query<dynamic>(subReportInformation.ReportTitle.StrSql, dp);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="key"></param>
        /// <param name="reportCondition"></param>
        /// <returns></returns>
        public string ExportSubReportExcel(string key, string subkey, ReportInformation reportInformation)
        {
            try
            {
                DataTable dtColumn = new DataTable();
                dtColumn.Columns.Add("Title");
                dtColumn.Columns.Add("FieldName");
                List<dynamic> result = new List<dynamic>();
                if (ReportDataDict.ContainsKey(key))
                {
                    string directoryName = string.Concat(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "TempExprotExcel\\");
                    if (!Directory.Exists(directoryName))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(directoryName);
                        DirectorySecurity dirSecurity = di.GetAccessControl();
                        dirSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
                        di.SetAccessControl(dirSecurity);
                    }

                    DynamicParameters dp = CreateDynamicParameters(reportInformation.ReportConditionList);
                    dp = CreateDynamicParameters(reportInformation.ReportSubConditionList, dp);
                    ReportInformation subReportInformation = ReportDataDict[key].SubReportInformationList.FirstOrDefault(d => d.ReportTitle.ReportName == subkey);

                    DataTable dt = dapper.Fill(subReportInformation.ReportTitle.StrSql, dp);
                    dt.TableName = "Table";
                    string FileName = key + "_" + subkey + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

                    FileName = FileName.Replace(":", "-");

                    string FilePath = string.Concat(directoryName, FileName);
                    if (ExcelModelDict.ContainsKey(key) && !string.IsNullOrWhiteSpace(subReportInformation.ReportTitle.ModelFileName))
                    {
                        string modelExcelPath = ExcelModelDict[key];
                        byte[] bytes = FileLibHelper.FileToBytes(modelExcelPath);
                        Stream stream = new MemoryStream(bytes);
                        ExcelFileHelper.ExportExcelForModel(dt, stream, FilePath);
                    }
                    else
                    {
                        //导出Excel,构造需要导出的列
                        foreach (ReportColumn item in subReportInformation.ReportColumnList)
                        {
                            //if (item.IsExport)
                            //{
                            DataRow newRow = dtColumn.NewRow();
                            newRow["Title"] = item.Title;
                            newRow["FieldName"] = item.FieldName;
                            dtColumn.Rows.Add(newRow);
                            //}
                        }
                        ExcelFileHelper.ExportExcelWithAspose(dt, dtColumn, FilePath);
                    }
                    return FileName;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取SQL语句
        /// </summary>
        /// <param name="key">报表名称</param>
        /// <param name="type">获取sql的类型type:0 参数解析出来，type:1 默认sql </param>
        /// <param name="reportConditionList">条件列表</param>
        /// <returns></returns>
        public string GetReportSQL(string key, int type, ReportInformation reportInformation)
        {
            string result = string.Empty;
            if (ReportDataDict.ContainsKey(key))
            {
                if (type == 0)
                {
                    DynamicParameters dp = CreateDynamicParameters(reportInformation.ReportConditionList);
                    dp = CreateDynamicParameters(reportInformation.ReportSubConditionList, dp);
                    result = ThrowSql(ReportDataDict[key].ReportTitle.StrSql, dp);
                }
                else
                {
                    result = ReportDataDict[key].ReportTitle.StrSql;
                }
            }
            return result;
        }

        /// <summary>
        /// 获取子报表SQL语句
        /// </summary>
        /// <param name="key">报表名称</param>
        /// <param name="type">获取sql的类型type:0 参数解析出来，type:1 默认sql </param>
        /// <param name="reportConditionList">条件列表</param>
        /// <returns></returns>
        public string GetSubReportSQL(string key, int type, ReportInformation reportInformation)
        {
            string result = string.Empty;
            if (ReportDataDict.ContainsKey(reportInformation.ReportTitle.ReportName))
            {
                if (type == 0)
                {
                    ReportInformation subReportInformation = ReportDataDict[reportInformation.ReportTitle.ReportName].SubReportInformationList.Find(r => r.ReportTitle.ReportName == key);
                    DynamicParameters dp = CreateDynamicParameters(reportInformation.ReportConditionList);
                    dp = CreateDynamicParameters(subReportInformation.ReportSubConditionList, dp);
                    result = ThrowSql(subReportInformation.ReportTitle.StrSql, dp);
                }
                else
                {
                    result = ReportDataDict[reportInformation.ReportTitle.ReportName].SubReportInformationList.Find(r => r.ReportTitle.ReportName == key).ReportTitle.StrSql;
                }
            }
            return result;
        }

        /// <summary>
        /// 获取参数名
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>参数名哈希表</returns>
        private HashSet<string> GetParamters(string sql)
        {
            string pattern = @"[:@][A-Za-z]+([A-Za-z0-9_]+)?";
            var matches = Regex.Matches(sql, pattern);

            string[] ParamsStr = matches.Cast<Match>()
                .Select(x => x.Value.Replace(":", "").Replace("@", ""))
                .Distinct().ToArray();

            HashSet<string> ParamsHS = new HashSet<string>();
            foreach (var paramter in ParamsStr)
            {
                ParamsHS.Add(paramter.ToUpper());
            }

            return ParamsHS;
        }

        /// <summary>
        /// 丢出包含SQL脚本的异常
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ex"></param>
        private string ThrowSql(string sql, object parameters)
        {
            sql = sql.ToUpper();
            HashSet<string> hs = GetParamters(sql);
            string ParamPrefix = ":";
            if (dapper.DBType == DatabaseType.SqlServer)
                ParamPrefix = "@";

            if (parameters != null && parameters is DynamicParameters)
            {
                DynamicParameters dParameters = parameters as DynamicParameters;
                var names = dParameters.ParameterNames;
                if (names != null)
                {
                    foreach (var name in names)
                    {
                        string nameUP = name.ToUpper();
                        if (hs.Contains(nameUP))
                        {
                            DbType paramValueType = dParameters.GetValueType(name);

                            dynamic tempValue = (dParameters.Get<dynamic>(name) ?? "");

                            if (paramValueType == DbType.String)
                                tempValue = "'" + tempValue + "'";
                            else if (paramValueType == DbType.DateTime)
                            {
                                if (dapper.DBType == DatabaseType.Oracle)
                                    tempValue = "to_date('" + tempValue + "','yyyy-mm-dd hh24:mi:ss')";
                                else
                                    tempValue = "'" + tempValue + "'";
                            }
                            string field = ParamPrefix + nameUP;
                            Regex regex = new Regex(field + "[^A-Za-z1-9_]");
                            var match = regex.Match(sql);
                            if (match != null && match.Success)
                            {
                                Group g = match.Groups.Cast<Group>().OrderBy(x => x.Length).First();
                                tempValue += g.Value.Replace(field, "");
                                sql = sql.Replace(g.Value, tempValue);
                            }
                            else
                            {
                                sql = sql.Replace(ParamPrefix + nameUP, tempValue);
                            }
                        }
                    }
                }
            }
            else if (parameters != null)
            {
                Type t = parameters.GetType();
                var list = t.GetProperties().Select(x => x.Name).ToList();
                foreach (var name in hs)
                {
                    string propValue = Convert.ToString(t.GetProperty(list.FirstOrDefault(x => x.ToLower() == name.ToLower()) ?? name)
                        .GetValue(parameters, null));
                    sql = sql.Replace(ParamPrefix + name, "'" + (propValue ?? "") + "'");
                }
            }
            return sql;
        }

        #endregion


        #region   根据开始时间 结束时间，查出用户定义的每一项查询，并将结果以 html 的形式返回
        /// <summary>
        /// /根据开始时间 结束时间，查出用户定义的每一项查询，并将结果以 html 的形式返回
        /// </summary>
        /// <param name="StartTime">报表查询开始时间</param>
        /// <param name="EndTime">报表查询结束时间</param>
        /// <param name="ExeclModelName">excel报表模板名称</param>
        /// <returns></returns>
        public string GetReportQueryFromExeclModel(string StartTime, string EndTime, string ExeclModelName)
        {
            //根据传入的模板名称进性组装数据到excel后  以htmL的形式返回客户端数据
            //此处取默认的组，默认取第一组  如后期需要取其他组数据，可传入相对应的组名字获取
            List<DictXML.DictGroup> groups = GetDictXMLByGroupName(ExeclModelName);


            List<KeyValue> keyValueList = new List<KeyValue>();
            if (groups != null)
            {
                foreach (DictXML.DictGroup group in groups)
                {

                    if (String.IsNullOrEmpty(group.Value))
                    {
                        KeyValue keyValue = new KeyValue();
                        keyValue.Key = group.Key;
                        keyValue.Value = "";
                        keyValueList.Add(keyValue);
                    }
                    else
                    {

                        KeyValue keyValue = new KeyValue();
                        keyValue.Key = group.Key;
                        //有值包含两种情况，一种是固定数值（不含SELECT），一种是包含SQL语句（不管怎样肯定会有SELECT）
                        if (group.Value.ToUpper().Contains("SELECT"))
                        {
                            DynamicParameters dp = new DynamicParameters();

                            if (group.Value.Contains("{0}") || group.Value.Contains("{1}"))
                            {
                                group.Value = group.Value.Replace("{0}", " :STARTTIME ").Replace("{1}", " :ENDTIME ");
                            }
                            //这里只传入两个参数，开始时间，结束时间
                            dp.Add("STARTTIME", StartTime, DbType.Time);
                            dp.Add("ENDTIME", EndTime, DbType.Time);
                            string stringSqlView = GetVanesInfoSql();

                            if (group.Value.Contains("V_MED_ANES_INFO"))
                            {
                                group.Value = group.Value.Replace("V_MED_ANES_INFO", " ( " + stringSqlView + " ) ");
                            }
                            try
                            {
                                HashSet<string> hs = GetParamters(group.Value);

                                DataTable table = null;
                                if (hs.Count > 0)
                                {
                                    if (String.IsNullOrEmpty(StartTime) || String.IsNullOrEmpty(EndTime))
                                    {
                                        // Message = "开始时间或结束时间未填写,请检查后再执行语句";
                                    }
                                    else
                                    {
                                        table = dapper.Fill(group.Value, dp);
                                    }

                                }
                                else
                                {

                                    table = dapper.Fill(group.Value, null);
                                }
                                //查询结果转换
                                if (table != null)
                                {
                                    foreach (DataColumn colum in table.Columns)
                                    {
                                        if (table.Columns.Count > 1)
                                        {
                                            keyValue.Value += Convert.ToString(table.Rows[0][colum.ColumnName]) + "#";
                                        }
                                        else
                                        {
                                            keyValue.Value += Convert.ToString(table.Rows[0][colum.ColumnName]);
                                        }
                                        keyValueList.Add(keyValue);

                                    }

                                }

                            }
                            catch (Exception e)
                            {

                            }
                        }
                        else
                        {
                            keyValue.Value = group.Value;
                            keyValueList.Add(keyValue);
                        }

                    }



                }
            }
            //为结果增加算法
            AddAlgorithmForItem(keyValueList);

            //拼接一个完整的路径
            string filepath = Path.Combine(GetAppPath(), "Config\\ExcelModel\\IndexExcelModel\\" + ExeclModelName);

            //将要读取的Excel模板传入工具类进行读取
            ExcelToHtml excel = new ExcelToHtml(filepath, ExeclModelName);

            //将数据传入工具类,如果传入为空，则默认显示模板数据
            excel.setKeyValueList(keyValueList);

            //开始进行Excel 转 Html
            string str = excel.ToHtml();
            if (excel.wb != null)
            {
                excel.wb.Close();
            }
            if (excel._work != null)
            {
                excel._work.Close();
            }
            return str;
        }



        /// <summary>
        ///   为获取的配置值 增加算法
        /// </summary>
        /// <param name="keyValueList"></param>
        public void AddAlgorithmForItem(List<KeyValue> keyValueList)
        {
            if (keyValueList.Count <= 0)
            {
                return;
            }

            foreach (KeyValue item in keyValueList)
            {
                #region         除法运算
                if (item.Key.Contains("/"))
                {
                    double proportion = 0.00;
                    double molecule = 0, Denominator = 0;

                    string[] keyArray = item.Key.Split(new char[] { '/' });
                    if (keyArray.Length >= 2)
                    {
                        //分子 
                        KeyValue keyMolecule = keyValueList.Find(keyvalue => keyvalue.Key.Equals(keyArray[0]));

                        //分母
                        KeyValue keyDenominator = keyValueList.Find(keyvalue => keyvalue.Key.Equals(keyArray[1]));

                        if (keyMolecule == null)
                        {
                            item.Value = proportion + "%";
                        }
                        else
                        {

                            if (!string.IsNullOrEmpty(keyMolecule.Value))
                            {
                                int a = 0, b = 0;
                                if (int.TryParse(keyMolecule.Value, out a))
                                {
                                    molecule = a;
                                }
                                if (int.TryParse(keyDenominator.Value, out b))
                                {
                                    Denominator = b;
                                }

                                //分母为零 结果为零
                                if (Denominator == 0)
                                {
                                    proportion = 0.00;
                                }
                                else
                                {
                                    proportion = (molecule / Denominator) * 100;
                                    proportion = Math.Round(proportion, 2);

                                }


                            }
                            item.Value = proportion + "%";
                        }




                    }
                }
                #endregion

                #region         加法运算
                if (item.Key.Contains("+"))
                {
                    double proportion = 0.00;
                    double molecule = 0, Denominator = 0;

                    string[] keyArray = item.Key.Split(new char[] { '+' });
                    if (keyArray.Length >= 2)
                    {
                        //分子 
                        KeyValue keyMolecule = keyValueList.Find(keyvalue => keyvalue.Key.Equals(keyArray[0]));

                        //分母
                        KeyValue keyDenominator = keyValueList.Find(keyvalue => keyvalue.Key.Equals(keyArray[1]));

                        if (keyMolecule == null && keyDenominator == null)
                        {
                            item.Value = "0";
                        }
                        else
                        {

                            if (!string.IsNullOrEmpty(keyMolecule.Value))
                            {
                                int a = 0, b = 0;
                                if (int.TryParse(keyMolecule.Value, out a))
                                {
                                    molecule = a;
                                }
                                if (int.TryParse(keyDenominator.Value, out b))
                                {
                                    Denominator = b;
                                }



                                proportion = molecule + Denominator;




                            }
                            item.Value = proportion + "";
                        }




                    }
                }
                #endregion
            }



        }

        /// XML配置信息
        /// </summary>
        /// <returns></returns>
        public DictXML GetDictXML(string path)
        {
            string filepath = Path.Combine(GetAppPath(), path);
            string xml = File.ReadAllText(filepath);

            DictXML dict = XmlUtil.Deserialize<DictXML>(xml);
            return dict;
        }

        /// <summary>
        /// 获取配置XML分组的信息
        /// </summary>
        /// <param name="groupname">分组名称</param>
        /// <returns></returns>
        /// <summary>
        public List<DictXML.DictGroup> GetDictXMLByGroupName(string groupname, string dataFormatXml = "Config\\ExcelDataFormat.xml")
        {

            DictXML xmlDic = GetDictXML(dataFormatXml);

            if (xmlDic != null && xmlDic.Model != null)
            {
                if (!string.IsNullOrEmpty(groupname))
                {
                    try
                    {
                        if (xmlDic.Model.Where(x => x.GroupName == groupname).Select(x => x.Group).FirstOrDefault().Count > 0)
                        {

                            return xmlDic.Model.Where(x => x.GroupName == groupname).Select(x => x.Group).FirstOrDefault();

                        }
                        else
                        {
                            XmlUtil.InsertGroupNameToExcelModelXML(groupname, GetAppPath());
                        }

                    }
                    catch
                    {
                        //没有组名    插入一个新的

                        XmlUtil.InsertGroupNameToExcelModelXML(groupname, GetAppPath());
                    }


                }
                else
                {
                    foreach (DictModel model in xmlDic.Model)
                    {
                        return model.Group;

                    }

                }


            }

            return null;
        }


        #endregion

        #region  将需要保存的sql语句，保存到对应的模板的对应组中

        /// <summary>
        /// 插入一个  KeyValue 数据 到xml节点 下
        /// 由于没有写插入具体哪个GroupName 下 默认插入第一组下面
        /// </summary>
        /// <param name="keyv"></param>
        /// <returns></returns>
        public string InsertOrUpdateSqlToExcelModleData(KeyValue keyValue)
        {

            return InsertOrUpdateSqlToExcelModleDataToPathAndGroup(keyValue, "Config\\ExcelDataFormat.xml", true, "");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyv">  插入一个  KeyValue 数据 到xml节点 下 </param>
        /// <param name="fileName">要插入excel模板文件位置     "Config\\ExcelDataFormat.xml" </param>
        /// <returns></returns>
        public string InsertOrUpdateSqlToExcelModleDataToPath(KeyValue KeyValue, string FileName)
        {

            return InsertOrUpdateSqlToExcelModleDataToPathAndGroup(KeyValue, FileName, true, "");


        }

        public string InsertOrUpdateSqlToExcelModleDataToGroup(KeyValue keyValue, string groupName)
        {

            return InsertOrUpdateSqlToExcelModleDataToPathAndGroup(keyValue, "Config\\ExcelDataFormat.xml", true, groupName);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyv">  插入一个  KeyValue 数据 到xml节点 下 </param>
        /// <param name="fileName">要插入excel模板文件位置     "Config\\ExcelDataFormat.xml" </param>
        /// <param name="GroupName">要插入excel模板文件位置中的组     "Config\\ExcelDataFormat.xml"  下的 "十七项指标" 就是组名称，如果不写，默认为插入为第一个组中</param> 
        // <returns></returns>
        public string InsertOrUpdateSqlToExcelModleDataToPathAndGroup(KeyValue KeyValue, string FileName, bool isNeedIdentity, string GroupName)
        {
            int i = 0;
            ///如果需要加额外的标识
            if (isNeedIdentity)
            {
                bool isSaveSuccess = XmlUtil.SaveXMLFileValue(string.IsNullOrEmpty(FileName) ? "Config\\ExcelDataFormat.xml" : FileName, KeyValue.Key.Contains("mdsd") ? KeyValue.Key : "mdsd" + KeyValue.Key, KeyValue.Value.ToUpper(), GetAppPath(), GroupName);
                if (isSaveSuccess)
                {
                    i++;
                }
            }
            else
            {
                bool isSaveSuccess = XmlUtil.SaveXMLFileValue(string.IsNullOrEmpty(FileName) ? "Config\\ExcelDataFormat.xml" : FileName, KeyValue.Key, KeyValue.Value.ToUpper(), GetAppPath(), GroupName);
                if (isSaveSuccess)
                {
                    i++;
                }
            }

            return Convert.ToString(i);


        }

        /// <summary>
        /// 插入一个集合
        /// </summary>
        /// <param name="kevList">  插入一个集合 </param>
        /// <returns></returns>
        public string InsertOrUpdateSqlListExcelModleData(List<KeyValue> kevList)
        {
            int i = 0;
            foreach (KeyValue kev in kevList)
            {
                string resout = InsertOrUpdateSqlToExcelModleData(kev);

                try
                {
                    int a = int.Parse(resout);
                    i = i + a;
                }
                catch
                {


                    i = i + 0;

                }



            }
            return "" + i;

        }



        #endregion

        #region   从固定的Xml模板中读取配置的sql

        /// <summary>
        /// 默认获取 "Config\\ExcelDataFormat.xml 路径下  组名为 十七项指标 的组的配置
        /// </summary>
        /// <returns></returns>
        public List<KeyValue> GetExcelModleDictDefautPathAndDefautGroupName()
        {

            return GetExcelModleDataDictDefautPath("十七项指标");

        }

        /// <summary>
        /// 获取 "Config\\ExcelDataFormat.xml 路径下  相应组名的配置
        /// </summary>
        /// <param name="GroupName">   需要获取的组名  </param>
        /// <returns></returns>
        public List<KeyValue> GetExcelModleDataDictDefautPath(string GroupName)
        {

            return GetExcelModleDataDict("Config\\ExcelDataFormat.xml", GroupName);
        }

        /// <summary>
        /// 
        /// 获取相应路径下  相应组名的配置
        /// </summary>
        /// <param name="Path">  需要获取的路径  </param>
        /// <param name="GroupName"> 需要获取的组名 </param>
        /// <returns></returns>
        public List<KeyValue> GetExcelModleDataDict(string Path, string GroupName)
        {
            List<DictXML.DictGroup> groups = GetDictXMLByGroupName(GroupName, Path);

            List<KeyValue> keyValueList = new List<KeyValue>();
            foreach (DictXML.DictGroup group in groups)
            {
                KeyValue keyValue = new KeyValue();
                if (!group.Key.Contains("/"))
                {
                    keyValue.Key = keyValue.Key = group.Key.ToLower().Contains("mdsd") ?
                                          Regex.Split(group.Key, "mdsd", RegexOptions.IgnoreCase)[1].Equals("mdsd") ?
                                          Regex.Split(group.Key, "mdsd", RegexOptions.IgnoreCase)[0] :
                                          Regex.Split(group.Key, "mdsd", RegexOptions.IgnoreCase)[1] : keyValue.Key;
                    keyValue.Value = group.Value;
                    if (!string.IsNullOrEmpty(group.Key))
                        keyValue.InputCode = StringManage.GetPYString(group.Key);

                    keyValueList.Add(keyValue);
                }
            }
            return keyValueList;

        }

        #endregion

        #region   用户自己写的sql进行数据库校验

        /// <summary>
        /// 用户自己写的sql进行数据库校验
        /// </summary>
        /// <param name="data">用户界面上传上的参数,动态传值</param>
        /// <returns></returns>
        public string ExecuteOrTestSQLFromUser(dynamic data)
        {
            GetVanesInfoSql();
            string key = data.Key;
            string value = data.Value;
            string startTime = data.StartTime;
            string endTime = data.EndTime;

            string Message = "";

            if (value.Contains("SELECT"))
            {
                DynamicParameters dp = new DynamicParameters();

                if (value.Contains("{0}") || value.Contains("{1}"))
                {
                    value = value.Replace("{0}", " :STARTTIME ").Replace("{1}", " :ENDTIME ");
                }

                dp.Add("STARTTIME", startTime, DbType.Time);
                dp.Add("ENDTIME", endTime, DbType.Time);
                try
                {
                    HashSet<string> hs = GetParamters(value);

                    DataTable table = null;
                    if (hs.Count > 0)
                    {
                        if (String.IsNullOrEmpty(startTime) || String.IsNullOrEmpty(endTime))
                        {
                            Message = "开始时间或结束时间未填写,请检查后再执行语句";
                        }
                        else
                        {
                            table = dapper.Fill(value, dp);
                        }

                    }
                    else
                    {
                        table = dapper.Fill(value, null);
                    }
                    if (table != null)
                    {

                        foreach (DataColumn colum in table.Columns)
                        {
                            if (table.Columns.Count > 1)
                            {
                                Message += Convert.ToString(table.Rows[0][colum.ColumnName]) + "#";
                            }
                            else
                            {
                                Message += Convert.ToString(table.Rows[0][colum.ColumnName]);
                            }


                        }

                    }
                    return Message;

                }



                catch (Exception e)
                {


                    return e.Message;

                }
            }
            else
            {
                return value;
            }

        }

        #endregion

        #region         获取相应路径下所有的excel
        /// <summary>
        /// 获取相应路径下所有的excel
        /// </summary>
        /// <param name="ExcelPath"></param>
        /// <returns></returns>
        public List<KeyValue> GetExeclModelName(string ExcelPath)
        {
            string appPath = GetAppPath();
            string filepath = Path.Combine(appPath, ExcelPath);
            DirectoryInfo folder = new DirectoryInfo(filepath);
            List<KeyValue> result = new List<KeyValue>();

            foreach (FileInfo file in folder.GetFiles())
            {
                if (file.Name.EndsWith(".xls") || file.Name.EndsWith(".xlsx"))
                {
                    KeyValue keyValue = new KeyValue();
                    keyValue.Key = Path.GetFileName(file.FullName);
                    keyValue.Value = file.FullName;
                    result.Add(keyValue);
                }
            }
            return result;

        }
        #endregion

        #region         获取大视图Sql




        /// <summary>
        /// 获取大视图数据--ASAGrade字段已做处理
        /// </summary>
        /// 
        /// <returns></returns>
        public string GetVanesInfoSql()
        {

            List<DictXML.DictGroup> lstASA = GetDictXMLByGroupName("ASAGrade", "Config\\DataFormat.xml");
            List<DictXML.DictGroup> lstScale = GetDictXMLByGroupName("OperScale", "Config\\DataFormat.xml");
            List<DictXML.DictGroup> lstWound = GetDictXMLByGroupName("WoundGrade", "Config\\DataFormat.xml");

            List<string> sqlStr = new List<string>();
            sqlStr = ReplaceParamsForSql(lstASA, sqlStr);
            sqlStr = ReplaceParamsForSql(lstScale, sqlStr);
            sqlStr = ReplaceParamsForSql(lstWound, sqlStr);


            string sql = sqlDict.GetSQLByKey("GetVAnesInfo");
            sql = string.Format(sql, sqlStr.ToArray());
            // DataTable table=   dapper.Fill(sql, null);
            // CommonDA da = new CommonDA();
            //  return da.GetVAnesInfo(queryParams, args: sqlStr.ToArray());
            return sql;
        }

        /// <summary>
        /// 替换SQL语句中的参数
        /// </summary>
        /// <param name="list">配置XML内容</param>
        /// <param name="resultList">返回结果</param>
        /// <param name="isAddKey">是否添加key 默认添加</param>
        /// <returns></returns>
        public List<string> ReplaceParamsForSql(List<DictXML.DictGroup> list, List<string> resultList, bool isAddKey = true)
        {
            foreach (DictXML.DictGroup item in list)
            {
                resultList.Add("," + item.Value.Replace("'", "") + ", ");
                if (isAddKey)
                    resultList.Add(item.Key);
            }
            return resultList;
        }


        #endregion

        #region       上传Excel模板
        /// <summary>
        /// /上传Excel模板 到默认位置
        /// </summary>
        /// <returns></returns>
        public string UploadExcelToDefautPath()
        {
            return UploadExcelToPath("Config\\ExcelModel\\IndexExcelModel");
        }
        /// <summary>
        /// 上传Excel模板到指定位置
        /// </summary>
        /// <param name="ExcelPath"></param>
        /// <returns></returns>
        public string UploadExcelToPath(string ExcelPath)
        {
            try
            {
                HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                //HttpPostedFile file = HttpContext.Current.Request.Files[1];
                if (files == null || files.Count == 0)
                {
                    return "上传的文件不能为空";

                }
                HttpPostedFile file = System.Web.HttpContext.Current.Request.Files[0];
                string basePath = GetAppPath() + ExcelPath;
                if (!Directory.Exists(basePath))
                {
                    Directory.CreateDirectory(basePath);
                }
                string filePath = string.Empty;
                string generateFileName = file.FileName;
                filePath = Path.Combine(basePath, generateFileName);
                file.SaveAs(filePath);
                return "成功上传了";
            }
            catch (Exception e)
            {
                return "失败了:" + e.Message;

            }
        }

        public string Test()
        {
            ReportInformation reportInformation = null;
            string result = string.Empty;
            if (!string.IsNullOrEmpty(reportInformation.ReportTitle.StrSql))
            {
                DynamicParameters dp = CreateDynamicParameters(reportInformation.ReportConditionList);
                dp = CreateDynamicParameters(reportInformation.ReportSubConditionList, dp);
                result = ThrowSql(reportInformation.ReportTitle.StrSql, dp);
            }

            DataTable table = null;

            table = dapper.Fill(result, null);
            List<string> columStrList = new List<string>();
            if (table.Columns.Count > 0)
            {
                foreach (DataColumn colum in table.Columns)
                {
                    columStrList.Add(colum.ColumnName);
                }
            }
            else
            {

            }

            throw new NotImplementedException();
        }

        #endregion



        #region  脏数据管理
        /// <summary>
        ///  获取ASA 等级  手术等级  切口等级  等可能存在脏数据的配置项
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<KeyValue>> GetFilteDaTaFromDicXml()
        {
            Dictionary<string, List<KeyValue>> dictXml = new Dictionary<string, List<KeyValue>>();

            dictXml.Add("ASAGrade", group2KeyValue(GetDictXMLByGroupName("ASAGrade", "Config\\DataFormat.xml")));
            dictXml.Add("OperScale", group2KeyValue(GetDictXMLByGroupName("OperScale", "Config\\DataFormat.xml")));
            dictXml.Add("WoundGrade", group2KeyValue(GetDictXMLByGroupName("WoundGrade", "Config\\DataFormat.xml")));
            return dictXml;

        }
        /// <summary>
        /// 将DictXML.DictGroup  转化为  List<KeyValue>    主要是为了能根据InputCode  进行快速检索
        /// <param name="groupList"></param>
        /// <returns></returns>
        List<KeyValue> group2KeyValue(List<DictXML.DictGroup> groupList)
        {
            List<KeyValue> keyValueList = new List<KeyValue>();
            foreach (DictXML.DictGroup group in groupList)
            {
                KeyValue keyValue = new KeyValue();
                keyValue.Key = group.Key;
                keyValue.Value = group.Value;
                keyValue.InputCode = StringManage.GetPYString(group.Key);
                keyValueList.Add(keyValue);
            }
            return keyValueList;
        }

        /// <summary>
        /// /更新 需要过滤的数据
        /// </summary>
        /// <param name="groupName"> 要插入的组名</param>
        /// <param name="keyValue">  要插入的键值对</param>
        /// <returns></returns>
        public string UpdateFilteDaTaToDicXml(string groupName, KeyValue keyValue)
        {
            return InsertOrUpdateSqlToExcelModleDataToPathAndGroup(keyValue, "Config\\DataFormat.xml", false, groupName);
        }

        public List<string> GetReportColumList(string pkey, Boolean isSubReport, ReportInformation reportInformation)
        {
            string result = reportInformation.ReportTitle.StrSql;
            DynamicParameters dp = null;
            if (!string.IsNullOrEmpty(result))
            {
                if (isSubReport)
                {
                    ReportInformation parantReportInformation = ReportDataDict[pkey];
                    dp = CreateDynamicParameters(parantReportInformation.ReportConditionList);
                    dp = CreateDynamicParameters(reportInformation.ReportSubConditionList, dp);
                }
                else
                {
                    dp = CreateDynamicParameters(reportInformation.ReportConditionList);
                    dp = CreateDynamicParameters(reportInformation.ReportSubConditionList, dp);
                }
                // result = ThrowSql(reportInformation.ReportTitle.StrSql, dp);
            }
            DataTable table = null;
            table = dapper.Fill(result, dp);
            List<string> columStrList = new List<string>();
            if (table.Columns.Count > 0)
            {
                foreach (DataColumn colum in table.Columns)
                {
                    columStrList.Add(colum.ColumnName);

                }
            }
            return columStrList;
        }

        public string DeleteExcelModeleWithPathAndExcelName(string ExcelPath, string ExcelModeleName)
        {
            string appPath = GetAppPath();
            string filepath = Path.Combine(appPath, ExcelPath);
            DirectoryInfo folder = new DirectoryInfo(filepath);
            string message = "";
            FileInfo file = new FileInfo(filepath + "\\" + ExcelModeleName);
            if (file.Exists)
            {
                file.Delete();
            }
            else
            {
                message = "文件不存在";
            }
            return message;
        }
        #endregion
    }
}