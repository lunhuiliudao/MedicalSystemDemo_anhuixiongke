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
    public interface IScreenConfigService
    {


        /// <summary>
        /// 大屏字典表
        /// </summary>
        /// <param name="queryParams">无参数</param>
        /// <returns></returns>
        DataResult GetScreenDict(QueryParams queryParams);


        int UpdateScreenDict(QueryParams queryParams);


        int InsertScreenDict(QueryParams queryParams);

        int DeleteScreenDict(QueryParams queryParams);


        /// <summary>
        /// 根据编号获取大屏配置表
        /// </summary>
        /// <param name="queryParams">大屏编号</param>
        /// <returns></returns>
        DataResult GetScreenConfig(QueryParams queryParams);


        int UpdateScreenNormalConfig(QueryParams queryParams);


        int InsertScreenNormalConfig(QueryParams queryParams);


        /// <summary>
        /// 大屏显示字段
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        DataTable GetScreenViewEmptyData(QueryParams queryParams);


        DataResult GetScreenFieldsData(QueryParams queryParams);


        int InsertScreenFields(QueryParams queryParams);


        int DeleteScreenFields(QueryParams queryParams);


        int UpdateScreenFields(QueryParams queryParams);


        /// <summary>
        /// 大屏通告信息表
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        DataResult GetMsgData(QueryParams queryParams);


        int InsertScreenMsg(QueryParams queryParams);


        int DeleteScreenMsg(QueryParams queryParams);


        int UpdateScreenMsg(QueryParams queryParams);
        
    }

    /// <summary>
    /// 账号类
    /// </summary>
    public class ScreenConfigService : BaseService<ScreenConfigService>, IScreenConfigService
    {
        ConvertSqlHelper sqlHelper = new ConvertSqlHelper();

        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected ScreenConfigService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public ScreenConfigService(IDapperContext context)
            : base(context) { }



        /// <summary>
        /// 获取大屏字典表
        /// </summary>
        /// <param name="queryParams">无参数</param>
        /// <returns></returns>
        public DataResult GetScreenDict(QueryParams queryParams)
        {

            if (queryParams.QueryDefines == null)
            {
                string sql = sqlDict.GetSQLByKey("GetScreenDict");
                return ToResult(dapper.Fill(sql));
            }
            else
            {

                string baseSql = sqlDict.GetSQLByKey("GetScreenDictByNo");
                DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
                string sql = sqlHelper.FillPara(baseSql, queryParams);
                return ToResult(dapper.Fill(sql, dynamicParams));
            }
        }

        public int UpdateScreenDict(QueryParams queryParams)
        {
            string columnStr = string.Empty;
            string valueStr = "1=1 ";
            var dynamicParams = new DynamicParameters();
            if (queryParams != null && queryParams.QueryDefines != null)
            {
                for (int i = 0; i < queryParams.QueryDefines.Count; i++)
                {
                    var define = queryParams.QueryDefines[i];
                    if (define.QueryName.ToUpper() == "SCREEN_NO")
                        valueStr += " AND " + define.QueryName + "=" + sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName;
                    else
                        columnStr += define.QueryName + "=" + sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName + ",";
                    dynamicParams.Add(define.QueryName, define.QueryValue, sqlHelper.ConvertTypeToDbType(define.QueryType));
                }
            }
            columnStr = columnStr.TrimEnd(',');
            valueStr = valueStr.TrimEnd(',');
            string sql = string.Format("update MED_SMART_SCREEN_DICT set {0} where {1} ", columnStr, valueStr);

            
            int result=  dapper.Execute(sql, dynamicParams);
            dapper.SaveChanges();
            return result;
        }

        public int InsertScreenDict(QueryParams queryParams)
        {
            string columnStr = string.Empty;
            string valueStr = string.Empty;
            var dynamicParams = new DynamicParameters();
            if (queryParams != null && queryParams.QueryDefines != null)
            {
                for (int i = 0; i < queryParams.QueryDefines.Count; i++)
                {
                    var define = queryParams.QueryDefines[i];
                    columnStr += define.QueryName + ",";
                    valueStr += sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName + ",";
                    dynamicParams.Add(define.QueryName, define.QueryValue, sqlHelper.ConvertTypeToDbType(define.QueryType));
                }
            }
            columnStr = columnStr.TrimEnd(',');
            valueStr = valueStr.TrimEnd(',');
            string sql = string.Format("insert into MED_SMART_SCREEN_DICT ({0})values ({1})", columnStr, valueStr);

            int restult= dapper.Execute(sql, dynamicParams);
            dapper.SaveChanges();
            return restult;
            //return Execute("InsertScreenDict", queryParams);
        }

        public int DeleteScreenDict(QueryParams queryParams)
        {
            string columnStr = string.Empty;
            var dynamicParams = new DynamicParameters();
            if (queryParams != null && queryParams.QueryDefines != null)
            {
                for (int i = 0; i < queryParams.QueryDefines.Count; i++)
                {
                    var define = queryParams.QueryDefines[i];
                    columnStr += define.QueryName + "=" + sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName + ",";
                    dynamicParams.Add(define.QueryName, define.QueryValue, sqlHelper.ConvertTypeToDbType(define.QueryType));
                }
            }
            columnStr = columnStr.TrimEnd(',');
            string sql = string.Format("delete from MED_SMART_SCREEN_DICT where {0} ", columnStr);

            int result = dapper.Execute(sql, dynamicParams);
            dapper.SaveChanges();
            return result;
        }

        /// <summary>
        /// 获取大屏配置
        /// </summary>
        /// <param name="queryParams">大屏编号</param>
        /// <returns></returns>
        public DataResult GetScreenConfig(QueryParams queryParams)
        {
            if (queryParams.QueryDefines == null)
            {
                string sql = sqlDict.GetSQLByKey("GetAllScreenConfig");
                return ToResult(dapper.Fill(sql));
            }
            else
            {

                string baseSql = sqlDict.GetSQLByKey("GetScreenConfigByNo");
                DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
                string sql = sqlHelper.FillPara(baseSql, queryParams);
                return ToResult(dapper.Fill(sql, dynamicParams));
            }
        }

        public int InsertScreenNormalConfig(QueryParams queryParams)
        {
            string columnStr = string.Empty;
            string valueStr = string.Empty;
            var dynamicParams = new DynamicParameters();
            if (queryParams != null && queryParams.QueryDefines != null)
            {
                for (int i = 0; i < queryParams.QueryDefines.Count; i++)
                {
                    var define = queryParams.QueryDefines[i];
                    columnStr += define.QueryName + ",";
                    valueStr += sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName + ",";
                    dynamicParams.Add(define.QueryName, define.QueryValue, sqlHelper.ConvertTypeToDbType(define.QueryType));
                }
            }
            columnStr = columnStr.TrimEnd(',');
            valueStr = valueStr.TrimEnd(',');
            string sql = string.Format("insert into MED_SMART_SCREEN_CONFIG ({0})values ({1})", columnStr, valueStr);

            int result = dapper.Execute(sql, dynamicParams);
            dapper.SaveChanges();
            return result;
            //return Execute("InsertScreenDict", queryParams);
        }

        public int UpdateScreenNormalConfig(QueryParams queryParams)
        {
            string columnStr = string.Empty;
            string valueStr = "1=1 ";
            var dynamicParams = new DynamicParameters();

            if (queryParams != null && queryParams.QueryDefines != null)
            {
                for (int i = 0; i < queryParams.QueryDefines.Count; i++)
                {
                    var define = queryParams.QueryDefines[i];
                    if (define.QueryName.ToUpper() == "SCREEN_NO")
                    {
                        valueStr += " AND " + define.QueryName + "=" + sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName;
                    }
                    else
                        columnStr += define.QueryName + "=" + sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName + ",";
                    dynamicParams.Add(define.QueryName, define.QueryValue, sqlHelper.ConvertTypeToDbType(define.QueryType));
                }
            }
            columnStr = columnStr.TrimEnd(',');
            valueStr = valueStr.TrimEnd(',');
            string sql = string.Format("update MED_SMART_SCREEN_CONFIG set {0} where {1} ", columnStr, valueStr);

            int result = dapper.Execute(sql, dynamicParams);
            dapper.SaveChanges();
            return result;
        }

        public DataTable GetScreenViewEmptyData(QueryParams queryParams)
        {
            //
            string baseSql = sqlDict.GetSQLByKey("GetScreenViewEmptyData");
            DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
            string sql = sqlHelper.FillPara(baseSql, queryParams);
            return dapper.Fill(sql, dynamicParams);
            //return dapper.Fill("GetScreenViewEmptyData");
        }


        public DataResult GetScreenFieldsData(QueryParams queryParams)
        {
            string baseSql = sqlDict.GetSQLByKey("GetFieldsDataByNo");
            DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
            string sql = sqlHelper.FillPara(baseSql, queryParams);
            return ToResult(dapper.Fill(sql, dynamicParams));
        }

        public int InsertScreenFields(QueryParams queryParams)
        {
            string columnStr = string.Empty;
            string valueStr = string.Empty;
            var dynamicParams = new DynamicParameters();
            if (queryParams != null && queryParams.QueryDefines != null)
            {
                for (int i = 0; i < queryParams.QueryDefines.Count; i++)
                {
                    var define = queryParams.QueryDefines[i];
                    columnStr += define.QueryName + ",";
                    valueStr += sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName + ",";
                    dynamicParams.Add(define.QueryName, define.QueryValue, sqlHelper.ConvertTypeToDbType(define.QueryType));
                }
            }
            columnStr = columnStr.TrimEnd(',');
            valueStr = valueStr.TrimEnd(',');
            string sql = string.Format("insert into MED_SCREEN_FIELDS ({0})values ({1})", columnStr, valueStr);

            int result = dapper.Execute(sql, dynamicParams);
            dapper.SaveChanges();
            return result;
            //return Execute("InsertScreenDict", queryParams);
        }

        public int DeleteScreenFields(QueryParams queryParams)
        {
            string valueStr = "1=1 ";
            var dynamicParams = new DynamicParameters();
            if (queryParams != null && queryParams.QueryDefines != null)
            {
                for (int i = 0; i < queryParams.QueryDefines.Count; i++)
                {
                    var define = queryParams.QueryDefines[i];
                    if (define.QueryName.ToUpper() == "SCREEN_NO" || define.QueryName.ToUpper() == "FIELD_NAME")
                    {
                        valueStr += " AND " + define.QueryName + "=" + sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName;
                        dynamicParams.Add(define.QueryName, define.QueryValue, sqlHelper.ConvertTypeToDbType(define.QueryType));
                    }
                }
            }
            valueStr = valueStr.TrimEnd(',');
            string sql = string.Format("delete from MED_SCREEN_FIELDS where {0} ", valueStr);

            int result = dapper.Execute(sql, dynamicParams);
            dapper.SaveChanges();
            return result;
        }

        public int UpdateScreenFields(QueryParams queryParams)
        {
            string columnStr = string.Empty;
            string valueStr = "1=1 ";
            var dynamicParams = new DynamicParameters();

            if (queryParams != null && queryParams.QueryDefines != null)
            {
                for (int i = 0; i < queryParams.QueryDefines.Count; i++)
                {
                    var define = queryParams.QueryDefines[i];
                    if (define.QueryName.ToUpper() == "SCREEN_NO" || define.QueryName.ToUpper() == "FIELD_NAME")
                    {
                        valueStr += " AND " + define.QueryName + "=" + sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName;
                    }
                    else
                        columnStr += define.QueryName + "=" + sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName + ",";
                    dynamicParams.Add(define.QueryName, define.QueryValue, sqlHelper.ConvertTypeToDbType(define.QueryType));
                }
            }
            columnStr = columnStr.TrimEnd(',');
            valueStr = valueStr.TrimEnd(',');
            string sql = string.Format("update MED_SCREEN_FIELDS set {0} where {1} ", columnStr, valueStr);

            int result = dapper.Execute(sql, dynamicParams);
            dapper.SaveChanges();
            return result;
        }

        public DataResult GetMsgData(QueryParams queryParams)
        {
            string baseSql = sqlDict.GetSQLByKey("GetMsgDataByNo");
            DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
            string sql = sqlHelper.FillPara(baseSql, queryParams);
            return ToResult(dapper.Fill(sql, dynamicParams));
            //return ToResult(dapper.Fill("GetMsgDataByNo", queryParams));
        }

        public int InsertScreenMsg(QueryParams queryParams)
        {
            string columnStr = string.Empty;
            string valueStr = string.Empty;
            var dynamicParams = new DynamicParameters();
            if (queryParams != null && queryParams.QueryDefines != null)
            {
                for (int i = 0; i < queryParams.QueryDefines.Count; i++)
                {
                    var define = queryParams.QueryDefines[i];
                    columnStr += define.QueryName + ",";
                    valueStr += sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName + ",";
                    dynamicParams.Add(define.QueryName, define.QueryValue, sqlHelper.ConvertTypeToDbType(define.QueryType));
                }
            }
            columnStr = columnStr.TrimEnd(',');
            valueStr = valueStr.TrimEnd(',');
            string sql = string.Format("insert into MED_SCREEN_STATIC_MSG ({0})values ({1})", columnStr, valueStr);

            int result = dapper.Execute(sql, dynamicParams);
            dapper.SaveChanges();
            return result;
            //return Execute("InsertScreenDict", queryParams);
        }

        public int DeleteScreenMsg(QueryParams queryParams)
        {
            string valueStr = "1=1 ";
            var dynamicParams = new DynamicParameters();
            if (queryParams != null && queryParams.QueryDefines != null)
            {
                for (int i = 0; i < queryParams.QueryDefines.Count; i++)
                {
                    var define = queryParams.QueryDefines[i];
                    if (define.QueryName.ToUpper() == "SCREEN_NO" || define.QueryName.ToUpper() == "MSG_ID")
                    {
                        valueStr += " AND " + define.QueryName + "=" + sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName;
                        dynamicParams.Add(define.QueryName, define.QueryValue, sqlHelper.ConvertTypeToDbType(define.QueryType));
                    }
                }
            }
            valueStr = valueStr.TrimEnd(',');
            string sql = string.Format("delete from MED_SCREEN_STATIC_MSG where {0} ", valueStr);

            int result = dapper.Execute(sql, dynamicParams);
            dapper.SaveChanges();
            return result;
        }

        public int UpdateScreenMsg(QueryParams queryParams)
        {
            string columnStr = string.Empty;
            string valueStr = "1=1 ";
            var dynamicParams = new DynamicParameters();

            if (queryParams != null && queryParams.QueryDefines != null)
            {
                for (int i = 0; i < queryParams.QueryDefines.Count; i++)
                {
                    var define = queryParams.QueryDefines[i];
                    if (define.QueryName.ToUpper() == "SCREEN_NO" || define.QueryName.ToUpper() == "MSG_ID")
                    {
                        valueStr += " AND " + define.QueryName + "=" + sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName;
                    }
                    else
                        columnStr += define.QueryName + "=" + sqlHelper.GetDataTypeParasSign(dapper.DBType) + define.QueryName + ",";
                    dynamicParams.Add(define.QueryName, define.QueryValue, sqlHelper.ConvertTypeToDbType(define.QueryType));
                }
            }
            columnStr = columnStr.TrimEnd(',');
            valueStr = valueStr.TrimEnd(',');
            string sql = string.Format("update MED_SCREEN_STATIC_MSG set {0} where {1} ", columnStr, valueStr);

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
