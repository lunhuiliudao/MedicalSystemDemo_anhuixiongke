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
    public interface IScreenService
    {

        DataResult GetScreenViewNormal(QueryParams queryParams);

        DataResult GetValidMsgData(QueryParams queryParams);

        DataResult GetNoticeMsgData(QueryParams queryParams);


        int UpdateNoticeMsgData(QueryParams queryParams);
        
    }

    /// <summary>
    /// 账号类
    /// </summary>
    public class ScreenService : BaseService<ScreenService>, IScreenService
    {
        ConvertSqlHelper sqlHelper = new ConvertSqlHelper();

        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected ScreenService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public ScreenService(IDapperContext context)
            : base(context) { }



        public DataResult GetScreenViewNormal(QueryParams queryParams)
        {
            string baseSql = sqlDict.GetSQLByKey("GetScreenViewNormal");
            DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
            string sql = sqlHelper.FillPara(baseSql, queryParams);
            return ToResult(dapper.Fill(sql, dynamicParams));
        }

        public DataResult GetValidMsgData(QueryParams queryParams)
        {
            string baseSql = sqlDict.GetSQLByKey("GetValidMsgDataByNo");
            DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
            string sql = sqlHelper.FillPara(baseSql, queryParams);
            return ToResult(dapper.Fill(sql, dynamicParams));
        }

        public DataResult GetNoticeMsgData(QueryParams queryParams)
        {
    
            string baseSql = sqlDict.GetSQLByKey("GetNoticeMsgData");
            DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
            string sql = sqlHelper.FillPara(baseSql, queryParams);
            return ToResult(dapper.Fill(sql, dynamicParams));
        }

        public int UpdateNoticeMsgData(QueryParams queryParams)
        {
            string columnStr = string.Empty;
            string valueStr = "1=1 ";
            var dynamicParams = new DynamicParameters();
            if (queryParams != null && queryParams.QueryDefines != null)
            {
                for (int i = 0; i < queryParams.QueryDefines.Count; i++)
                {
                    var define = queryParams.QueryDefines[i];
                    if (define.QueryName.ToUpper() == "ID")
                        valueStr += " AND " + define.QueryName + "=" + sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName;
                    else
                        columnStr += define.QueryName + "=" + sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName + ",";
                    dynamicParams.Add(define.QueryName, define.QueryValue, sqlHelper.ConvertTypeToDbType(define.QueryType));
                }
            }
            columnStr = columnStr.TrimEnd(',');
            valueStr = valueStr.TrimEnd(',');
            string sql = string.Format("update MED_SCREEN_MSG set {0} where {1} ", columnStr, valueStr);

            int result = dapper.Execute(sql, dynamicParams);
            dapper.SaveChanges();
            return result;
        }

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
