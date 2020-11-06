using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
//using MedicalSystem.AnesWorkStation.Domain.AnesQuery;
using MedicalSystem.Common.FileManage;
using MedicalSystem.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPlatformWeiXinService
    {
        #region  手术信息界面
        //查询手术信息
        dynamic GetOperInfo(OperQueryParaModel model);
        #endregion

        #region 统计

        dynamic GetWeiXinOperInfo(OperQueryParaModel model);


        /// <summary>
        /// EChart图标统计
        /// </summary>
        IList<dynamic> QueryRightEChartReportForDirectionIndex(OperQueryParaModel model);

        /// <summary>
        /// 手术信息EChart图标统计
        /// </summary>
        IList<dynamic> QueryOperEChartReportForDirectionIndex(OperQueryParaModel model);

        #endregion

        #region 质控

        /// <summary>
        /// 获取主索引数据
        /// </summary>
        /// <returns></returns>
        List<MED_QC_REPORT_IND> GetQuanlityControlReportInd();

        IList<MED_QC_REPORT_LIST> GetQuanlityControlReportBakItemList(string reportName);

        #endregion

    }
    public class PlatformWeiXinService : BaseService<PlatformAnesQueryService>, IPlatformWeiXinService
    {
        protected PlatformWeiXinService()
            : base() { }
        public PlatformWeiXinService(IDapperContext context)
            : base(context)
        {

        }

        #region 手术信息
        //查询手术信息
        public dynamic GetOperInfo(OperQueryParaModel model)
        {
            //string sql = sqlDict.GetSQLByKey("QueryOperInfosForDirectorIndex");  
            //针对oracle ora-03113: 通信通道的文件结束 报错使用以下SQL
            string sql = @"      select 
                            (select count(1) from (
                             select *  from Med_Operation_Master m left join MED_ANESTHESIA_INPUT_DATA a on m.patient_id=a.Patient_Id and m.visit_id = a.Visit_Id and m.oper_id=a.Oper_Id
                              where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate,'YYYY-MM-DD')) t ) as TodayTotalCount,
                            (select count(1) from (
                             select *  from Med_Operation_Master m left join MED_ANESTHESIA_INPUT_DATA a on m.patient_id=a.Patient_Id and m.visit_id = a.Visit_Id and m.oper_id=a.Oper_Id
                              where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate,'YYYY-MM-DD')) t  where t.Oper_Status_Code>=35) as TodayCompletedCount,
                            (select count(1) from (
                             select *  from Med_Operation_Master m left join MED_ANESTHESIA_INPUT_DATA a on m.patient_id=a.Patient_Id and m.visit_id = a.Visit_Id and m.oper_id=a.Oper_Id
                              where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate,'YYYY-MM-DD')) t  where t.Oper_Status_Code>=5 and  t.Oper_Status_Code<=35) as TodayOperatingCount,
                            (select count(1) from (
                             select *  from Med_Operation_Master m left join MED_ANESTHESIA_INPUT_DATA a on m.patient_id=a.Patient_Id and m.visit_id = a.Visit_Id and m.oper_id=a.Oper_Id
                              where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate,'YYYY-MM-DD')) t  where t.Oper_Status_Code=-80) as TodayCancelCount,
                            (select count(1) from  (
                             select *  from Med_Operation_Master m left join MED_ANESTHESIA_INPUT_DATA a on m.patient_id=a.Patient_Id and m.visit_id = a.Visit_Id and m.oper_id=a.Oper_Id
                              where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate,'YYYY-MM-DD')) t  where t.Oper_Status_Code>=0 and Oper_Status_Code<5) as TodayWaitingCount,
                            (select count(1) from (
                             select *  from Med_Operation_Master m left join MED_ANESTHESIA_INPUT_DATA a on m.patient_id=a.Patient_Id and m.visit_id = a.Visit_Id and m.oper_id=a.Oper_Id
                              where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate,'YYYY-MM-DD')) t where Emergency_Ind=1 ) as TodayEmergencyCount,
                            (select count(1) from (
                             select *  from Med_Operation_Master m left join MED_ANESTHESIA_INPUT_DATA a on m.patient_id=a.Patient_Id and m.visit_id = a.Visit_Id and m.oper_id=a.Oper_Id
                              where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate,'YYYY-MM-DD')) t where Isolation_Ind=2 or INFECTED_IND =2) as TodayGLGRCount,
                            (select count(1) from (
                             select *  from Med_Operation_Master m left join MED_ANESTHESIA_INPUT_DATA a on m.patient_id=a.Patient_Id and m.visit_id = a.Visit_Id and m.oper_id=a.Oper_Id
                              where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate,'YYYY-MM-DD')) t where oper_class in (2,3) ) as TodayRescueCount,
                            (select count(1) from (
                             select *  from Med_Operation_Master m left join MED_ANESTHESIA_INPUT_DATA a on m.patient_id=a.Patient_Id and m.visit_id = a.Visit_Id and m.oper_id=a.Oper_Id
                              where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate,'YYYY-MM-DD')) t where t.anes_death=1 and t.death_after_oper =1 ) as TodayDeathCount,
                            (select count(1) from (
                             select *  from Med_Operation_Master m left join MED_ANESTHESIA_INPUT_DATA a on m.patient_id=a.Patient_Id and m.visit_id = a.Visit_Id and m.oper_id=a.Oper_Id
                              where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate,'YYYY-MM-DD')) t where CANCELED_TYPE = '1' or PACU_TEMPERATURE =1 or CONS_DISTURBANCE =1
                                                                    or TRACHEA_6H = 1 or OXYGEN_SATURATION =1 or ANES_ANAPHYLAXIS =1 or
                                                                    ANES_DEATH = 1 or RES_TRACT_OBSTRUCE =1 or CENTRAL_VENOUS = 1
                                                                    or ANES_START_24H_DEATH = 1 or ANES_START_24H_STOP = 1 or SPINAL_ANES_COMP =1 
                                                                    or TRACHEA_HOARSE = 1 or AFTER_ANES_COMA = 1 or USE_REMINDERS = 1 or 
                                                                    RES_TRACT_OBSTRUCE = 1 or OTHER_NOT_EXP = 1 or NO_PLAN_IN_ICU = 1) as TodayUnExpectCount,
                            (select count(1) from (
                             select *  from Med_Operation_Master m left join MED_ANESTHESIA_INPUT_DATA a on m.patient_id=a.Patient_Id and m.visit_id = a.Visit_Id and m.oper_id=a.Oper_Id
                              where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate,'YYYY-MM-DD')) t  where t.Oper_Status_Code=65) as TodayToICUCount,
                            (select count(1) from (
                             select *  from Med_Operation_Master m left join MED_ANESTHESIA_INPUT_DATA a on m.patient_id=a.Patient_Id and m.visit_id = a.Visit_Id and m.oper_id=a.Oper_Id
                              where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate,'YYYY-MM-DD')) t  where TRUNC((T.OUT_PACU_DATE_TIME-T.IN_PACU_DATE_TIME)*1440 ) >= 120) as TodayPacuCount,
                            (select count(1) from (
                             select *  from Med_Operation_Master m  where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate+1,'YYYY-MM-DD')
                             ) t ) as TomorrowTotalCount,
                            (select count(1) from (
                            select *  from Med_Operation_Master m 
                             where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate-1,'YYYY-MM-DD')) t ) as YesterdayTotalCount,
 (select count(1) from (
                             select *  from Med_Operation_Master m left join MED_ANESTHESIA_INPUT_DATA a on m.patient_id=a.Patient_Id and m.visit_id = a.Visit_Id and m.oper_id=a.Oper_Id
                              where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate-1,'YYYY-MM-DD')) t  where t.Oper_Status_Code>=35) as YesterdayCompletedCount,
 (select count(1) from  (
                             select *  from Med_Operation_Master m left join MED_ANESTHESIA_INPUT_DATA a on m.patient_id=a.Patient_Id and m.visit_id = a.Visit_Id and m.oper_id=a.Oper_Id
                              where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate-1,'YYYY-MM-DD')) t  where t.Oper_Status_Code>=0 and Oper_Status_Code<5) as YesterdayWaitingCount,
(select count(1) from (
                             select *  from Med_Operation_Master m left join MED_ANESTHESIA_INPUT_DATA a on m.patient_id=a.Patient_Id and m.visit_id = a.Visit_Id and m.oper_id=a.Oper_Id
                              where  to_char(m.scheduled_date_time,'YYYY-MM-DD')=to_char(sysdate-1,'YYYY-MM-DD')) t  where t.Oper_Status_Code=-80) as YesterdayCancelCount,
                            (select count(1) from (
                            select *  from Med_Operation_Master m 
                             where  to_char(m.start_date_time,'YYYY-MM-DD')=to_char(sysdate-1,'YYYY-MM-DD')) t where Isolation_Ind=2 or INFECTED_IND =2) as YesterdayGLGRCount,
                            (select count(1) from (
                            select *  from Med_Operation_Master m 
                             where  to_char(m.start_date_time,'YYYY-MM-DD')=to_char(sysdate-1,'YYYY-MM-DD')) t where oper_class in (2,3) ) as YesterdayRescueCount,
                            (select count(1) from (
                            select *  from Med_Operation_Master m 
                             where  to_char(m.start_date_time,'YYYY-MM-DD')=to_char(sysdate-1,'YYYY-MM-DD')) t  where t.Oper_Status_Code=65) as YesterdayToICUCount,
                            (select count(1) from (
                            select *  from Med_Operation_Master m 
                             where  to_char(m.start_date_time,'YYYY-MM-DD')=to_char(sysdate-1,'YYYY-MM-DD')) t  where TRUNC((T.OUT_PACU_DATE_TIME-T.IN_PACU_DATE_TIME)*1440 ) >= 120) as YesterdayPacuCount
                            from dual
                                ";
            return dapper.Set<dynamic>().Query(sql, new { }).FirstOrDefault();
        }
        #endregion

        #region 统计
        /// <summary>
        /// MDK配置信息
        /// </summary>
        IMdkConfiguration mdkConfig;

        /// <summary>
        /// 手术信息EChart图标下方集中统计统计
        /// </summary>
        public dynamic GetWeiXinOperInfo(OperQueryParaModel model)
        {
            //string sql = sqlDict.GetSQLByKey("QueryOperInfosForDirectorIndex");
            //年月日SQL暂时未定怎么存放   暂时放此处
            string sql = "";
            if (model.TimeType == "month")
            {
                //统计月
                sql = @"with temp as
                         (select *
                            from medsurgery.MED_OPERATION_MASTER m
                           WHERE TO_CHAR(START_DATE_TIME, 'YYYY') = :Year
                             AND TO_CHAR(START_DATE_TIME, 'MM') = :Month and m.Oper_Status_Code>=35 )

                        select 
                        ( select count(1) from temp ) TotalCount,
                        decode((select count(1) operCount from  (select  1 from temp group by to_char(START_DATE_TIME,'yyyy-MM-dd'))),0,0,  round(( select  count(1) from temp )/ (select count(1) operCount from  (select  1 from temp group by to_char(START_DATE_TIME,'yyyy-MM-dd'))),0)) DayAvgCount,
                        (select dateTime  from  (select to_char(START_DATE_TIME,'yyyy-MM-dd') dateTime,  count(1) operCount from temp group by to_char(START_DATE_TIME,'yyyy-MM-dd') order by count(1) desc) where rownum=1)  MostOperDate,
                        (select operCount  from  (select to_char(START_DATE_TIME,'yyyy-MM-dd') dateTime,  count(1) operCount from temp group by to_char(START_DATE_TIME,'yyyy-MM-dd') order by count(1) desc) where rownum=1)  MostOperCount,
                        (select dateTime  from  (select to_char(START_DATE_TIME,'yyyy-MM-dd') dateTime,  count(1) operCount from temp group by to_char(START_DATE_TIME,'yyyy-MM-dd') order by count(1) ) where rownum=1) LeastOperDate,
                        (select operCount  from  (select to_char(START_DATE_TIME,'yyyy-MM-dd') dateTime,  count(1) operCount from temp group by to_char(START_DATE_TIME,'yyyy-MM-dd') order by count(1) ) where rownum=1)  LeastOperCount,
                        ( select count(1) from temp where   to_char(START_DATE_TIME,'day') ='星期六' or  to_char(START_DATE_TIME,'day')='星期日' ) WeekOperCount,
                        ( select count(1) from temp where Emergency_Ind=1 ) EmergencyCount
                         from dual 
 
                         ";

                return dapper.Set<dynamic>().Query(sql, new { Year = Convert.ToDateTime(model.StartDate).Year, Month = Convert.ToDateTime(model.StartDate).Month }).FirstOrDefault();
            }
            else if (model.TimeType == "year")
            {
                //统计年
                sql = @"with temp as
                         (select *
                            from medsurgery.MED_OPERATION_MASTER m
                           WHERE TO_CHAR(START_DATE_TIME, 'YYYY') = :Year and m.Oper_Status_Code>=35 )

                        select 
                        ( select count(1) from temp ) TotalCount,
                       decode((select count(1) operCount from  (select  1 from temp group by to_char(START_DATE_TIME,'yyyy-MM-dd'))),0,0,  round(( select  count(1) from temp )/ (select count(1) operCount from  (select  1 from temp group by to_char(START_DATE_TIME,'yyyy-MM-dd'))),0)) DayAvgCount,
                        (select dateTime  from  (select to_char(START_DATE_TIME,'yyyy-MM-dd') dateTime,  count(1) operCount from temp group by to_char(START_DATE_TIME,'yyyy-MM-dd') order by count(1) desc) where rownum=1)  MostOperDate,
                        (select operCount  from  (select to_char(START_DATE_TIME,'yyyy-MM-dd') dateTime,  count(1) operCount from temp group by to_char(START_DATE_TIME,'yyyy-MM-dd') order by count(1) desc) where rownum=1)  MostOperCount,
                        (select dateTime  from  (select to_char(START_DATE_TIME,'yyyy-MM-dd') dateTime,  count(1) operCount from temp group by to_char(START_DATE_TIME,'yyyy-MM-dd') order by count(1) ) where rownum=1) LeastOperDate,
                        (select operCount  from  (select to_char(START_DATE_TIME,'yyyy-MM-dd') dateTime,  count(1) operCount from temp group by to_char(START_DATE_TIME,'yyyy-MM-dd') order by count(1) ) where rownum=1)  LeastOperCount,
                        ( select count(1) from temp where   to_char(START_DATE_TIME,'day') ='星期六' or  to_char(START_DATE_TIME,'day')='星期日' ) WeekOperCount,
                        ( select count(1) from temp where Emergency_Ind=1 ) EmergencyCount
                         from dual 
 
                         ";

                return dapper.Set<dynamic>().Query(sql, new { Year = Convert.ToDateTime(model.StartDate).Year, Month = Convert.ToDateTime(model.StartDate).Month }).FirstOrDefault();
            }
            //统计年
            return dapper.Set<dynamic>().Query(sql, new { }).FirstOrDefault();
        }

        /// <summary>
        /// 手术信息EChart图标统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual IList<dynamic> QueryOperEChartReportForDirectionIndex(OperQueryParaModel model)
        {
            //string sql = sqlDict.GetSQLByKey("QueryOperInfosForDirectorIndex");
            //年月日SQL暂时未定怎么存放   暂时放此处
            string sql = "";
            if (model.TimeType == "month")
            {
                DateTime date = Convert.ToDateTime(Convert.ToDateTime(model.StartDate).Year + "-" + Convert.ToDateTime(model.StartDate).Month + "-01");
                //统计月
                sql = @"
                    select a.s_date name, nvl(b.value, 0) value
                      from (select rownum s_date
                              from dual
        
                            connect by rownum <= last_day(to_date('" + date+ @"', 'yyyy-mm-dd')) -
                                       to_date('" + date + @"', 'yyyy-mm-dd') + 1) a
                      left join (
             
                                 select to_number(to_char(START_DATE_TIME, 'dd')) name,
                                         count(1) value
                                   from MED_OPERATION_MASTER
                                  where Oper_Status_Code >= 35
                                    and to_char(START_DATE_TIME, 'yyyy-MM') =
                                        to_char(to_date('" + date + @"', 'yyyy-MM-dd'), 'yyyy-MM')
                                  group by to_char(START_DATE_TIME, 'dd')
                                  order by to_char(START_DATE_TIME, 'dd')) b
                        on a.s_date = b.name
                     order by a.s_date";
            }
            //统计年
            else if (model.TimeType == "year")
            {
                //sql = @"select to_number(to_char(START_DATE_TIME,'MM')) name,count(1) value
                //        from MED_OPERATION_MASTER where Oper_Status_Code>=35 and to_char(START_DATE_TIME, 'yyyy') = to_char(to_date('" + Convert.ToDateTime(model.StartDate).ToShortDateString() + @"', 'yyyy-MM-dd'), 'yyyy') group by to_char(START_DATE_TIME, 'MM')
                //          order by to_char(START_DATE_TIME, 'MM')";
                sql = @"select a.mon name, nvl(b.value, 0) value
                  from (select level mon from dual connect by level < 13) a
                  left join (select to_number(to_char(START_DATE_TIME, 'MM')) name,
                                    count(1) value
                               from MED_OPERATION_MASTER a
                              where Oper_Status_Code >= 35
                                and to_char(START_DATE_TIME, 'yyyy') =
                                    to_char(to_date('" + Convert.ToDateTime(model.StartDate) + @"', 'yyyy-MM-dd'), 'yyyy') group by to_char(START_DATE_TIME, 'MM')
                              order by to_char(START_DATE_TIME, 'MM')) b
                    on a.mon = b.name
                 order by a.mon";

            }
            return dapper.Set<dynamic>().Query(sql, new { });
        }

        /// <summary>
        /// 饼图EChart图标统计
        /// </summary>
        public IList<dynamic> QueryRightEChartReportForDirectionIndex(OperQueryParaModel model)
        {
            //string sql = sqlDict.GetSQLByKey("QueryOperInfosForDirectorIndex");

            //年月日SQL暂时未定怎么存放   暂时放此处


            string sql = "";



            if (model.QueryType == "ASA")
            {
                #region ASA统计
                if (model.TimeType == "month")
                {
                    //统计月
                    sql = @"select ASA  name,COUNT(1) value from ( SELECT 
                        CASE WHEN INSTR('{0}',T.OLD_ASA_GRADE)>0 THEN '{1}'
                             WHEN INSTR('{2}',T.OLD_ASA_GRADE)>0 THEN '{3}'  
                             WHEN INSTR('{4}',T.OLD_ASA_GRADE)>0 THEN '{5}'  
                             WHEN INSTR('{6}',T.OLD_ASA_GRADE)>0 THEN '{7}'  
                             WHEN INSTR('{8}',T.OLD_ASA_GRADE)>0 THEN '{9}'  
                             WHEN INSTR('{10}',T.OLD_ASA_GRADE)>0 THEN '{11}'  
                        ELSE '其他' END AS ASA
                        FROM (
                        SELECT
                        START_DATE_TIME, ','||TRIM(ASA_GRADE)||',' OLD_ASA_GRADE 
                        FROM V_MED_ANES_INFO WHERE   TO_CHAR(START_DATE_TIME,'YYYY')=:Year AND TO_CHAR(START_DATE_TIME,'MM')=:Month
                        ) T

                        ) main
                group by Asa order by ASA 
                ";
                    List<DictXML.DictGroup> lstASA = mdkConfig.XmlDict.GetGroupByName("ASAGrade");
                    List<string> sqlStr = new List<string>();
                    sqlStr = mdkConfig.XmlDict.ReplaceParamsForSql(lstASA, sqlStr);
                    sql = string.Format(sql, sqlStr.ToArray());
                    return dapper.Set<dynamic>().Query(sql, new { Year = Convert.ToDateTime(model.StartDate).Year, Month = Convert.ToDateTime(model.StartDate).Month });
                }
                else if (model.TimeType == "year")
                {
                    //统计年
                    sql = @"select ASA  name,COUNT(1) value from ( SELECT 
                        CASE WHEN INSTR('{0}',T.OLD_ASA_GRADE)>0 THEN '{1}'
                             WHEN INSTR('{2}',T.OLD_ASA_GRADE)>0 THEN '{3}'  
                             WHEN INSTR('{4}',T.OLD_ASA_GRADE)>0 THEN '{5}'  
                             WHEN INSTR('{6}',T.OLD_ASA_GRADE)>0 THEN '{7}'  
                             WHEN INSTR('{8}',T.OLD_ASA_GRADE)>0 THEN '{9}'  
                             WHEN INSTR('{10}',T.OLD_ASA_GRADE)>0 THEN '{11}'  
                        ELSE '其他' END AS ASA
                        FROM (
                        SELECT
                        START_DATE_TIME, ','||TRIM(ASA_GRADE)||',' OLD_ASA_GRADE 
                        FROM V_MED_ANES_INFO WHERE   TO_CHAR(START_DATE_TIME,'YYYY')=:Year 
                        ) T

                        ) main
                group by Asa order by ASA 
                ";
                    List<DictXML.DictGroup> lstASA = mdkConfig.XmlDict.GetGroupByName("ASAGrade");
                    List<string> sqlStr = new List<string>();
                    sqlStr = mdkConfig.XmlDict.ReplaceParamsForSql(lstASA, sqlStr);
                    sql = string.Format(sql, sqlStr.ToArray());
                    return dapper.Set<dynamic>().Query(sql, new { Year = Convert.ToDateTime(model.StartDate).Year });
                }
                #endregion
            }
            else if (model.QueryType == "AnesMethod")
            {
                if (model.TimeType == "month")
                {
                    sql = @"select nvl(mad.ANAESTHESIA_TYPE,'其他麻醉')   name,COUNT(1) value from medsurgery.MED_OPERATION_MASTER  m
                            left join MED_ANESTHESIA_DICT mad on m.Anes_Method = mad.Anaesthesia_Name
                             WHERE m.oper_status_code>=35 and TO_CHAR(START_DATE_TIME, 'YYYY') = :Year AND TO_CHAR(START_DATE_TIME,'MM')= :Month
                                            group by nvl(mad.ANAESTHESIA_TYPE,'其他麻醉')  ";
                    return dapper.Set<dynamic>().Query(sql, new { Year = Convert.ToDateTime(model.StartDate).Year, Month = Convert.ToDateTime(model.StartDate).Month });
                }
                else if (model.TimeType == "year")
                {
                    sql = @"select nvl(mad.ANAESTHESIA_TYPE,'其他麻醉')  name,COUNT(1) value from medsurgery.MED_OPERATION_MASTER  m
                            left join MED_ANESTHESIA_DICT mad on m.Anes_Method = mad.Anaesthesia_Name
                             WHERE m.oper_status_code>=35 and TO_CHAR(START_DATE_TIME, 'YYYY') = :Year 
                                            group by nvl(mad.ANAESTHESIA_TYPE,'其他麻醉')";
                    return dapper.Set<dynamic>().Query(sql, new { Year = Convert.ToDateTime(model.StartDate).Year });
                }
            }


            return dapper.Set<dynamic>().Query(sql, new { });
        }

        #endregion

        #region 质控
        /// <summary>
        /// 获取主索引报表数据
        /// </summary>
        /// <returns></returns>
        public List<MED_QC_REPORT_IND> GetQuanlityControlReportInd()
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlReportInd");
            return dapper.Set<MED_QC_REPORT_IND>().Query(sql);
        }

        /// <summary>
        /// 获取备份数据
        /// </summary>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        public IList<MED_QC_REPORT_LIST> GetQuanlityControlReportBakItemList(string reportName)
        {
            IList<MED_QC_REPORT_DATA_BAK> master = GetQuanlityControlReportDataBak(reportName);
            IList<MED_QC_REPORT_LIST> itemList = GetQuanlityControlReportList();
            foreach (var item in itemList)
            {
                decimal valueFenZi = 0;
                decimal valueFenMu = 0;
                if (!string.IsNullOrEmpty(item.NMRTR_CODE))
                {
                    MED_QC_REPORT_DATA_BAK dataFind = master.FirstOrDefault<MED_QC_REPORT_DATA_BAK>(t => t.QC_CODE == item.NMRTR_CODE);
                    if (dataFind != null)
                    {
                        valueFenZi = dataFind.QC_VALUE;//分子
                        item.NMRTR_CODE_VALUE = valueFenZi.ToString();
                        item.REPORT_ID = dataFind.REPORT_ID;
                        item.DETAILS_COUNT = dataFind.DETAILS_COUNT;
                    }
                    else
                    {
                        valueFenZi = 0;
                        item.NMRTR_CODE_VALUE = "0";
                        item.DETAILS_COUNT = 0;
                    }
                }
                if (!string.IsNullOrEmpty(item.DNMTR_CODE))
                {
                    MED_QC_REPORT_DATA_BAK dataFind = master.FirstOrDefault<MED_QC_REPORT_DATA_BAK>(t => t.QC_CODE == item.DNMTR_CODE);
                    if (dataFind != null)
                    {
                        valueFenMu = dataFind.QC_VALUE;//分子
                        item.DNMTR_CODE_VALUE = valueFenMu.ToString();
                        item.REPORT_ID = dataFind.REPORT_ID;
                    }
                    else
                    {
                        valueFenMu = 0;
                        item.DNMTR_CODE_VALUE = "0";
                    }
                }
                item.PERCENT = valueFenMu == 0 ? "0.00" : (Math.Round(valueFenZi * 100 / valueFenMu, 2).ToString() + "%");
            }
            return itemList;
        }

        /// <summary>
        /// 获取质控备份数据
        /// </summary>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        public List<MED_QC_REPORT_DATA_BAK> GetQuanlityControlReportDataBak(string reportName)
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlReportDataBakForWeiXin");
            return dapper.Set<MED_QC_REPORT_DATA_BAK>().Query(sql, new { REPORT_MONTH = reportName });
        }

        /// <summary>
        /// 获取报表样式
        /// </summary>
        /// <param name="reportMonth"></param>
        /// <returns></returns>
        public IList<MED_QC_REPORT_LIST> GetQuanlityControlReportList()
        {
            string sql = sqlDict.GetSQLByKey("GetQuanlityControlReportList");
            return dapper.Set<MED_QC_REPORT_LIST>().Query(sql);
        }

        #endregion

    }
}
