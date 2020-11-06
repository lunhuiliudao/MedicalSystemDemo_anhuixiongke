using System;
using System.Linq;
using System.Text;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using System.Security.Cryptography;
using MedicalSystem.AnesWorkStation.Domain.Screen;
using System.Data;
using System.Collections.Generic;
using Dapper;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IOperProgressService
    {
        #region 主任工作站大屏，当前手术进程信息

        DataResult GetOperProgressViewData(QueryParams queryParams);

        DataResult GetTodayOperInfo(QueryParams queryParams);


        DataResult GetYesterdayOperInfo(QueryParams queryParams);


        DataResult GetYesterdayPacuOtInfo(QueryParams queryParams);


        DataResult GetTomorrowSchduleInfo(QueryParams queryParams);



        DataResult GetOperSeqenceInfo(QueryParams queryParams);

        DataResult GetMonitorAlarmInfo(QueryParams queryParams);

        #endregion

        #region 医务工作站，整体手术进程信息

        DataResult GetTotalProInfo(QueryParams queryParams);


        #endregion

        #region 手术间详情大屏
        DataResult GetOperInfoByOperRoom(QueryParams queryParams);
       
        #endregion
    }

    /// <summary>
    /// 账号类
    /// </summary>
    public class OperProgressService : BaseService<OperProgressService>, IOperProgressService
    {
        ConvertSqlHelper sqlHelper = new ConvertSqlHelper();
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected OperProgressService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public OperProgressService(IDapperContext context)
            : base(context) { }

        #region 主任工作站大屏，当前手术进程信息

        public DataResult GetOperProgressViewData(QueryParams queryParams)
        {

            string baseSql = sqlDict.GetSQLByKey("GetOperProgressViewData");
            DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
            string sql = sqlHelper.FillPara(baseSql, queryParams);
            return ToResult(dapper.Fill(sql, dynamicParams));
        }

        public DataResult GetTodayOperInfo(QueryParams queryParams)
        {
            string baseSql = sqlDict.GetSQLByKey("GetTodayOperInfo");
            DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
            string sql = sqlHelper.FillPara(baseSql, queryParams);
            return ToResult(dapper.Fill(sql, dynamicParams));
        }

        public DataResult GetYesterdayOperInfo(QueryParams queryParams)
        {
            string baseSql = sqlDict.GetSQLByKey("GetYesterdayOperInfo");
            DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
            string sql = sqlHelper.FillPara(baseSql, queryParams);
            return ToResult(dapper.Fill(sql, dynamicParams));
        }

        public DataResult GetYesterdayPacuOtInfo(QueryParams queryParams)
        {

            string baseSql = sqlDict.GetSQLByKey("GetYesterdayPacuOtInfo");
            DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
            string sql = sqlHelper.FillPara(baseSql, queryParams);
            return ToResult(dapper.Fill(sql, dynamicParams));
        }

        public DataResult GetTomorrowSchduleInfo(QueryParams queryParams)
        {

            string baseSql = sqlDict.GetSQLByKey("GetTomorrowSchduleInfo");
            DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
            string sql = sqlHelper.FillPara(baseSql, queryParams);
            return ToResult(dapper.Fill(sql, dynamicParams));
        }

        public DataResult GetOperSeqenceInfo(QueryParams queryParams)
        {

            string baseSql = sqlDict.GetSQLByKey("GetOperSeqenceInfo");
            DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
            string sql = sqlHelper.FillPara(baseSql, queryParams);
            return ToResult(dapper.Fill(sql, dynamicParams));
        }

        public DataResult GetMonitorAlarmInfo(QueryParams queryParams)
        {

            string baseSql = sqlDict.GetSQLByKey("GetMonitorAlarmInfo");
            DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
            string sql = sqlHelper.FillPara(baseSql, queryParams);
            return ToResult(dapper.Fill(sql, dynamicParams));
        }
        #endregion

        #region 医务工作站，整体手术进程信息

        public DataResult GetTotalProInfo(QueryParams queryParams)
        {
            string baseSql = sqlDict.GetSQLByKey("GetTotalProInfo");
            DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
            string sql = sqlHelper.FillPara(baseSql, queryParams);
            return ToResult(dapper.Fill(sql, dynamicParams));
        }

        #endregion

        #region 手术间详情大屏
        public DataResult GetOperInfoByOperRoom(QueryParams queryParams)
        {
            string baseSql = sqlDict.GetSQLByKey("GetOperInfoByDeptAndRoom");
            DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
            string sql = sqlHelper.FillPara(baseSql, queryParams);
            return ToResult(dapper.Fill(sql, dynamicParams));
        }
        #endregion


        public DataResult ToResult(DataTable dt)
        {
            DataResult result = new DataResult()
            {
                Columns = new List<ColumnDefine>(),
                Rows = new List<DataResultRow>()
            };

            if (dt != null)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    result.Columns.Add(new ColumnDefine()
                    {
                        FieldName = column.ColumnName,
                        Title = column.ColumnName,
                        Width = 0,
                        IsSHow = 1,
                        DataType = column.DataType.FullName
                    });
                }

                foreach (DataRow row in dt.Rows)
                {
                    DataResultRow rRow = new DataResultRow()
                    {
                        Data = new List<object>(row.ItemArray)
                    };

                    result.Rows.Add(rRow);
                }
            }

            return result;

        }
    }
}
