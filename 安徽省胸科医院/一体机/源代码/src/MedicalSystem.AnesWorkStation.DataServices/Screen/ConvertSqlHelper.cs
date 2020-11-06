
using Dapper;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.Screen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 基本操作
    /// </summary>
    public class ConvertSqlHelper : BaseService<ConvertSqlHelper>
    {
        private string paramPrefix = ":";

        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        public ConvertSqlHelper()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public ConvertSqlHelper(IDapperContext context)
            : base(context) {
            if (dapper.DBType == DatabaseType.Oracle)
            {
                paramPrefix = ":";
            }
            else if (dapper.DBType == DatabaseType.SqlServer)
            {
                paramPrefix = "@";
            }
        }


        #region Query方法
        /// <summary>
        /// 查询数据 
        /// </summary>
        public IEnumerable<T> QuerySql<T>(string sql, object param = null)
        {

            IEnumerable<T> result = null;

            using (var dbConn = dapper.Connection)
            {
                try
                {
                    result = dbConn.Query<T>(sql, param);
                    dbConn.Close();
                    dbConn.Dispose();
                }
                catch (Exception ex)
                {
                    ThrowSqlException(sql, param, ex);
                }
            }

            return result;
        }

        #endregion

        #region Execute方法

        /// <summary>
        /// 执行语句，返回受影响的记录数
        /// </summary>
        /// <param name="key">xml的节点名称</param>
        /// <param name="queryParams">动态多参数，分先后顺序</param>
        /// <example>
        /// var parameters = new DynamicParameters();
        /// parameters.Add("foo", "bar");
        /// Execute("drop proc SO25069578");
        /// </example>
        /// <returns>受影响的记录数</returns>
        //public int Execute(string key, QueryParams queryParams)
        //{
        //    string sql = GetSqlScript(key);
        //    HashSet<string> hs = GetParamters(sql);

        //    var dynamicParams = new DynamicParameters();

        //    if (queryParams != null && queryParams.QueryDefines != null)
        //    {
        //        for (int i = 0; i < queryParams.QueryDefines.Count; i++)
        //        {
        //            var define = queryParams.QueryDefines[i];
        //            foreach (var item in hs)
        //            {
        //                if (define.QueryName.ToUpper() == item.ToUpper())
        //                {
        //                    dynamicParams.Add(define.QueryName, define.QueryValue, ConvertTypeToDbType(define.QueryType));
        //                    queryParams.QueryDefines.Remove(define);
        //                    i--;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    return Execute(key, (object)dynamicParams);
        //}

        /// <summary>
        /// 执行语句，返回受影响的记录数
        /// </summary>
        /// <param name="key">xml的节点名称</param>
        /// <param name="param">写法如下：new { }</param>
        /// <example>
        /// var parameters = new DynamicParameters();
        /// parameters.Add("foo", "bar");
        /// Execute("drop proc SO25069578");
        /// 或
        /// Execute(@"insert MyTable(colA, colB) values (@a, @b)",
        ///    new[] { new { a=1, b=1 }, new { a=2, b=2 }, new { a=3, b=3 } }
        /// ).IsEqualTo(3); // 3 rows inserted: "1,1", "2,2" and "3,3"
        /// </example>
        /// <returns>受影响的记录数</returns>
        //public int Execute(string key, object param = null)
        //{
        //    string sql = GetSqlScript(key);
        //    return ExecuteSql(sql);
        //}

        /// <summary>
        /// 执行语句，返回受影响的记录数
        /// </summary>
        /// <param name="key">SQL语句</param>
        /// <param name="param">写法如下：new { }</param>
        public int ExecuteSql(string sql, object param = null)
        {
            int result = 0;


            try
            {
                result = dapper.Execute(sql, param);
            }
            catch (Exception ex)
            {
                ThrowSqlException(sql, param, ex);
            }


            return result;
        }

        #endregion

        #region Fill方法



        /// <summary>
        /// 动态参数的查询模式
        /// </summary>
        /// <param name="key">xml的节点名称</param>
        /// <param name="queryParams">动态多参数，分先后顺序</param>
        /// <param name="select">select列过滤</param>
        /// <param name="args">格式化脚本string.Format(sql, args)</param>
        /// <returns></returns>
        public string FillPara(string sql, QueryParams queryParams, string select = null, params string[] args)
        {
            var dynamicParams = new DynamicParameters();
            DataTable table = new DataTable();

            bool getSQL = false;
            if (queryParams != null && queryParams.ContainsQueryName(AppSettings.GET_SQL_EXCEPTION))
            {
                queryParams.RemoveQueryDefine(AppSettings.GET_SQL_EXCEPTION);
                getSQL = true;
            }

            string returnsql = FormatSql(sql, queryParams, select, dynamicParams, args);

            if (getSQL)
            {
                ThrowSqlException("SQL语句查看，请点击详细信息。\r\n SQLKey：" + 1 + "\r\n-------------------------------------------------------------------------------\r\n" + sql, dynamicParams, null);
            }

            return returnsql;
        }




        public DataTable FillForSQL(string sql, QueryParams queryParams)
        {
            var dynamicParams = new DynamicParameters();
            DataTable table = new DataTable();

            bool getSQL = false;
            if (queryParams != null && queryParams.ContainsQueryName(AppSettings.GET_SQL_EXCEPTION))
            {
                queryParams.RemoveQueryDefine(AppSettings.GET_SQL_EXCEPTION);
                getSQL = true;
            }

            string tsql = FormatSqlForSQL(sql, queryParams, dynamicParams);

            if (getSQL)
            {
                ThrowSqlException("SQL语句查看，请点击详细信息。\r\n SQL语句如下：\r\n-------------------------------------------------------------------------------\r\n" + tsql, dynamicParams, null);
            }
            return FillSql(tsql, dynamicParams);
        }

        /// <summary>
        /// 查询SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable FillSql(string sql, object param = null)
        {
            DataTable result = new DataTable();

            try
            {
                result = dapper.Fill(sql, param);
            }
            catch (Exception ex)
            {
                ThrowSqlException(sql, param, ex);
            }

            return result;
        }

        #endregion



        /// <summary>
        /// 查询SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public object ScalarSql(string sql, object param = null)
        {

            object result = null;

            try
            {
                result = dapper.ExecuteScalar(sql, param);
            }
            catch (Exception ex)
            {
                ThrowSqlException(sql, param, ex);
            }

            return result;
        }


        #region 格式化SQL脚本

        /// <summary>
        /// 防止生成重复名称的脚本
        /// </summary>
        private List<string> paramsNameList = new List<string>();
        private int paramsInt = 0;


        public DynamicParameters GetDynamicParams(string baseSql, QueryParams queryParams)
        {
            DynamicParameters dynamicParams = new DynamicParameters();
            //dynamicParams.Add(define.QueryName, define.QueryValue, ConvertTypeToDbType(define.QueryType));
            HashSet<string> hs = GetParamters(baseSql);
            if (queryParams != null && queryParams.QueryDefines != null)
            {
                for (int i = 0; i < queryParams.QueryDefines.Count; i++)
                {
                    var define = queryParams.QueryDefines[i];
                    foreach (var item in hs)
                    {
                        if (define.QueryName == item)
                        {
                            dynamicParams.Add(define.QueryName, define.QueryValue, ConvertTypeToDbType(define.QueryType));
                            queryParams.QueryDefines.Remove(define);
                            i--;
                            break;
                        }
                    }
                }
            }

            return dynamicParams;
        }

        /// <summary>
        /// 格式化SQL
        /// </summary>
        /// <param name="key"></param>
        /// <param name="queryParams"></param>
        /// <param name="select"></param>
        /// <param name="dynamicParams"></param>
        /// <returns></returns>
        public string FormatSql(string sql, QueryParams queryParams, string select, DynamicParameters dynamicParams, params string[] args)
        {
            paramsNameList.Clear();
            paramsInt = 0;

           // string sql = GetSqlScript(key);
            if (args != null && args.Length > 0)
            {
                sql = string.Format(sql, args);
            }
            HashSet<string> hs = GetParamters(sql);

            if (queryParams != null && queryParams.QueryDefines != null)
            {
                for (int i = 0; i < queryParams.QueryDefines.Count; i++)
                {
                    var define = queryParams.QueryDefines[i];
                    foreach (var item in hs)
                    {
                        if (define.QueryName == item)
                        {
                            paramsNameList.Add(define.QueryName);
                            dynamicParams.Add(define.QueryName, define.QueryValue, ConvertTypeToDbType(define.QueryType));
                            queryParams.QueryDefines.Remove(define);
                            i--;
                            break;
                        }
                    }
                }
            }

            string where = null;

            if (queryParams != null && queryParams.QueryDefines != null && queryParams.QueryDefines.Count > 0)
            {
                where = string.Join(" ", queryParams.QueryDefines
                    .Select(x => FormatWhere(x, dynamicParams))
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToArray());

                where = where.Trim();
            }

            if (!string.IsNullOrEmpty(select) || !string.IsNullOrEmpty(where))
            {
                sql = string.Format("SELECT {0} FROM ( {1} ) m WHERE 1=1 {2}",
                    string.IsNullOrEmpty(select) ? "*" : select,
                    sql,
                    where ?? "");
            }

            return sql;
        }


        /// <summary>
        /// 格式化SQL语句
        /// </summary>
        /// <param name="sql">直接SQL脚本语句</param>
        /// <param name="queryParams"></param>
        /// <param name="dynamicParams"></param>
        /// <returns></returns>
        public string FormatSqlForSQL(string sql, QueryParams queryParams, DynamicParameters dynamicParams)
        {
            paramsNameList.Clear();
            paramsInt = 0;
            HashSet<string> hs = GetParamters(sql);

            if (queryParams != null && queryParams.QueryDefines != null)
            {
                for (int i = 0; i < queryParams.QueryDefines.Count; i++)
                {
                    var define = queryParams.QueryDefines[i];
                    foreach (var item in hs)
                    {
                        if (define.QueryName == item)
                        {
                            paramsNameList.Add(define.QueryName);
                            dynamicParams.Add(define.QueryName, define.QueryValue, ConvertTypeToDbType(define.QueryType));
                            queryParams.QueryDefines.Remove(define);
                            i--;
                            break;
                        }
                    }
                }
            }

            string where = null;

            if (queryParams != null && queryParams.QueryDefines != null && queryParams.QueryDefines.Count > 0)
            {
                where = string.Join(" ", queryParams.QueryDefines
                    .Select(x => FormatWhere(x, dynamicParams))
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToArray());

                where = where.Trim();
            }
            return sql;
        }


        /// <summary>
        /// 格式化筛选条件转SQL
        /// </summary>
        /// <param name="query">筛选条件</param>
        /// <param name="dynamicParams">动态参数</param>
        /// <returns></returns>
        public string FormatWhere(QueryDefine define, DynamicParameters dynamicParams)
        {
            string paramName = string.Format("p{0}", paramsInt++);
            while (paramsNameList.Contains(paramName))
            {
                paramName = string.Format("p{0}", paramsInt++);
            }

            string sql = null;
            switch (define.Operation)
            {
                case OperationEnum.Equal:
                    if (define.QueryValue.ToLower() == "null")
                    {
                        sql = string.Format(" AND ({0} IS NULL OR {0} = '') ", define.QueryName);
                        return sql;
                    }
                    else
                    {
                        sql = string.Format(" AND ({0} = {1}{2}) ", define.QueryName, paramPrefix, paramName);
                    }
                    break;
                case OperationEnum.NotEqual:
                    sql = string.Format(" AND ({0} != {1}{2}) ", define.QueryName, paramPrefix, paramName);
                    break;
                case OperationEnum.Like:
                    if (dapper.DBType == DatabaseType.Oracle)
                    {
                        sql = string.Format(" AND ({0} LIKE '%'||{1}{2}||'%') ", define.QueryName, paramPrefix, paramName);
                    }
                    else if (dapper.DBType == DatabaseType.SqlServer)
                    {
                        sql = string.Format(" AND ({0} LIKE '%'+{1}{2}+'%') ", define.QueryName, paramPrefix, paramName);
                    }
                    else
                    {
                        throw new Exception("不识别给数据库类型的参数。");
                    }
                    break;
                case OperationEnum.StartWith:
                    if (dapper.DBType == DatabaseType.Oracle)
                    {
                        sql = string.Format(" AND ({0} LIKE '%'||{1}{2}) ", define.QueryName, paramPrefix, paramName);
                    }
                    else if (dapper.DBType == DatabaseType.SqlServer)
                    {
                        sql = string.Format(" AND ({0} LIKE '%'+{1}{2}) ", define.QueryName, paramPrefix, paramName);
                    }
                    else
                    {
                        throw new Exception("不识别给数据库类型的参数。");
                    }
                    break;
                case OperationEnum.EndWith:
                    if (dapper.DBType == DatabaseType.Oracle)
                    {
                        sql = string.Format(" AND ({0} LIKE {1}{2}||'%') ", define.QueryName, paramPrefix, paramName);
                    }
                    else if (dapper.DBType == DatabaseType.SqlServer)
                    {
                        sql = string.Format(" AND ({0} LIKE {1}{2}+'%') ", define.QueryName, paramPrefix, paramName);
                    }
                    else
                    {
                        throw new Exception("不识别给数据库类型的参数。");
                    }
                    break;
                case OperationEnum.Greater:
                    sql = string.Format(" AND ({0} > {1}{2}) ", define.QueryName, paramPrefix, paramName);
                    break;
                case OperationEnum.GreaterThanOrEqual:
                    sql = string.Format(" AND ({0} >= {1}{2}) ", define.QueryName, paramPrefix, paramName);
                    break;
                case OperationEnum.Less:
                    sql = string.Format(" AND ({0} < {1}{2}) ", define.QueryName, paramPrefix, paramName);
                    break;
                case OperationEnum.LessThanOrEqual:
                    sql = string.Format(" AND ({0} <= {1}{2}) ", define.QueryName, paramPrefix, paramName);
                    break;
                case OperationEnum.IsNull:
                    sql = string.Format(" AND ({0} IS NULL OR {0} = '') ", define.QueryName);
                    return sql;
                case OperationEnum.NotNull:
                    sql = string.Format(" AND ({0} IS NOT NULL OR {0} != '') ", define.QueryName);
                    return sql;
                case OperationEnum.Or:
                    if (!string.IsNullOrEmpty(define.QueryValue))
                    {
                        var vals = define.QueryValue.Split(',').ToList();
                        vals.ForEach(value =>
                        {
                            while (paramsNameList.Contains(paramName))
                            {
                                paramsNameList.Add(paramName);
                                paramName = string.Format("p{0}", paramsInt++);
                            }

                            if (string.IsNullOrEmpty(sql))
                            {
                                sql = string.Format(" {0} = {1}{2} ", define.QueryName, paramPrefix, paramName);
                            }
                            else
                            {
                                sql = string.Format(" OR {0} = {1}{2} ", define.QueryName, paramPrefix, paramName);
                            }

                            dynamicParams.Add(paramName, value, ConvertTypeToDbType(define.QueryType));
                        });
                    }
                    sql = string.Format(" AND ({0}) ", sql);
                    return sql;
                default:
                    sql = "";
                    break;
            }

            if (!string.IsNullOrEmpty(sql))
            {
                if (!string.IsNullOrEmpty(define.QueryValue))
                {
                    dynamicParams.Add(paramName, define.QueryValue, ConvertTypeToDbType(define.QueryType));
                }
                else
                {
                    sql = null;
                }
            }

            return sql;
        }

        #endregion

        #region 内部使用方法

        /// <summary>
        /// 数据类型转数据库的类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public DbType ConvertTypeToDbType(string typeName)
        {
            switch (typeName)
            {
                case "Boolean":
                    return DbType.Boolean;
                case "Char":
                    return DbType.StringFixedLength;
                case "SByte":
                    return DbType.SByte;
                case "Byte":
                    return DbType.Byte;
                case "Int16":
                    return DbType.Int16;
                case "UInt16":
                    return DbType.UInt16;
                case "Int32":
                    return DbType.Int32;
                case "UInt32":
                    return DbType.UInt32;
                case "Int64":
                    return DbType.Int64;
                case "UInt64":
                    return DbType.UInt64;
                case "Single":
                    return DbType.Single;
                case "Double":
                    return DbType.Double;
                case "Decimal":
                    return DbType.Decimal;
                case "DateTime":
                    return DbType.DateTime;
                case "String":
                default:
                    return DbType.String;
            }
        }

        /// <summary>
        /// 获取参数名
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>参数名哈希表</returns>
        public HashSet<string> GetParamters(string sql)
        {
            //string sqlStr = sql.Replace("(:", "(@").Replace(" :", " @").Replace("=:", "=@");
            //string[] ParamsStr = sqlStr.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
            //HashSet<string> ParamsHS = new HashSet<string>();
            //foreach (string item in ParamsStr)
            //{
            //    string paramter = item.Split(new string[] { " ", "\n", @"=", @">", @"<", @"|", @")", @",", "\r" }, StringSplitOptions.RemoveEmptyEntries)[0];
            //    ParamsHS.Add(paramter);
            //}
            string pattern = @"[:@][A-Za-z]+([A-Za-z0-9_]+)?";
            var matches = Regex.Matches(sql, pattern);

            string[] ParamsStr = matches.Cast<Match>()
                .Select(x => x.Value.Replace(":", "").Replace("@", ""))
                .Distinct().ToArray();

            HashSet<string> ParamsHS = new HashSet<string>();
            foreach (var paramter in ParamsStr)
            {
                ParamsHS.Add(paramter);
            }

            return ParamsHS;
        }

        #endregion

        #region Exception Add Sql

        /// <summary>
        /// 丢出包含SQL脚本的异常
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ex"></param>
        public void ThrowSqlException(string sql, object parameters, Exception ex)
        {
            HashSet<string> hs = GetParamters(sql);
            if (parameters != null && parameters is DynamicParameters)
            {
                DynamicParameters dParameters = parameters as DynamicParameters;
                var names = dParameters.ParameterNames;
                if (names != null)
                {
                    foreach (var name in names)
                    {
                        if (hs.Contains(name))
                        {
                            DbType paramValueType = dParameters.GetValueType(name);

                            string tempValue = (dParameters.Get<string>(name) ?? "");

                            if (paramValueType == DbType.String)
                                tempValue = "'" + tempValue + "'";
                            else if (paramValueType == DbType.DateTime)
                            {
                                if (dapper.DBType == DatabaseType.Oracle)
                                    tempValue = "to_date('" + tempValue + "','yyyy-mm-dd hh24:mi:ss')";
                                else
                                    tempValue = "'" + tempValue + "'";
                            }
                            string field = paramPrefix + name;
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
                                sql = sql.Replace(paramPrefix + name, tempValue);
                            }
                            //sql = sql.Replace(DbContext.Instance.ParamPrefix + name, tempValue);
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
                    sql = sql.Replace(paramPrefix + name,
                        "'" + (propValue ?? "") + "'");
                }
            }

            if (ex != null)
            {
                throw new Exception(ex.Message.Trim() + @"
" + sql, ex);
            }
            else
            {
                throw new Exception(sql);
            }
        }

        #endregion

        /// <summary>
        /// 根据数据库类型获取参数符号
        /// </summary>
        /// <returns></returns>
        public string GetDataTypeParasSign(DatabaseType dbType)
        {
            string result = string.Empty;
            if (dbType == DatabaseType.Oracle)
            {
                result = ":";
            }
            else if (dbType == DatabaseType.SqlServer)
            {
                result = "@";
            }
            return result;
        }
    }
}
