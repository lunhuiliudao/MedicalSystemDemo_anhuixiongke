using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;

namespace Pat
{
    /// <summary>
    /// </summary>
    public class DBExceptionExtend : Exception
    {

        private DbException DbException
        {
            get;
            set;
        }

        public DBExceptionExtend()
        {

        }

        public DBExceptionExtend(DbParameter[] dbParameterList, string sqlString, DbException dbException)
        {
            this.DbParameterList = dbParameterList;
            this.SqlString = sqlString;
            this.DbException = dbException;
        }

        private DbParameter[] DbParameterList
        {
            get;
            set;
        }

        private string SqlString
        {
            get;
            set;
        }

        public string SqlMessage
        {
            get
            {
                return ChangeMessage();
            }
        }

        private string ChangeMessage()
        {
            return ChangeMessage(DbParameterList, SqlString);
        }

        private string ChangeMessage(DbParameter[] parameters, string sql)
        {
            if (parameters == null)
            {
                return string.Empty;
            }

            DbParameter dbp = parameters[0];

            if (dbp is SqlParameter)
            {
                ExecMessage(parameters as SqlParameter[], ref sql);
            }

            //else if (dbp is OracleParameter)
            //{
            //    ExecMessage(parameters as OracleParameter[], ref sql);
            //}
            //else if (dbp is OleDbParameter)
            //{
            //    ExecMessage(parameters as OleDbParameter[], ref sql);
            //}
            //else if (dbp is OdbcParameter)
            //{
            //    ExecMessage(parameters as OdbcParameter[], ref sql);
            //}

            return sql;
        }

        private void ExecMessage(SqlParameter[] sqlParameters, ref string sql)
        {
            Dictionary<SqlParameter, int> dic = new Dictionary<SqlParameter, int>();
            foreach (SqlParameter para in sqlParameters)
            {
                dic.Add(para, para.ParameterName.Length);
            }
            List<KeyValuePair<SqlParameter, int>> myList = new List<KeyValuePair<SqlParameter, int>>(dic);
            myList.Sort(delegate(KeyValuePair<SqlParameter, int> s1, KeyValuePair<SqlParameter, int> s2)
            {
                return s1.Value.CompareTo(s2.Value);
            });
            List<SqlParameter> paraList = new List<SqlParameter>();
            for (int i = myList.Count - 1; i >= 0; i--)
            {
                paraList.Add(myList[i].Key);
            }
            foreach (SqlParameter para in paraList)
            {
                string paraName = para.ParameterName;
                string paraValue = para.Value == null ? "" : para.Value.ToString();

                switch (para.SqlDbType)
                {
                    case System.Data.SqlDbType.VarChar:
                    case System.Data.SqlDbType.NVarChar:
                    case System.Data.SqlDbType.NChar:
                    case System.Data.SqlDbType.Char:
                        sql = sql.Replace(paraName, "'" + paraValue.Replace("'", "") + "'");
                        break;
                    case System.Data.SqlDbType.Decimal:
                    case System.Data.SqlDbType.Float:
                    case System.Data.SqlDbType.Int:
                
                        sql = sql.Replace(paraName, paraValue);
                        break;
                    case System.Data.SqlDbType.Date:
                    case System.Data.SqlDbType.DateTime:
                 
                        sql = sql.Replace(paraName, "'" + paraValue.Replace("'", "") + "'");
                        break;
                    default:
                        sql = sql.Replace(paraName, "'" + paraValue.Replace("'", "") + "'");
                        break;
                }
            }
        }

   
        private void ExecMessage(OleDbParameter[] sqlParameters, ref string sql)
        {
            foreach (OleDbParameter para in sqlParameters)
            {
                string paraName = "?";
                string paraValue = para.Value == null ? "" : para.Value.ToString();
                string first = sql.Substring(0, sql.IndexOf("?") + 1);
                string last = sql.Substring(sql.IndexOf("?") + 1);
                switch (para.OleDbType)
                {
                    case OleDbType.VarChar:
                        first = first.Replace(paraName, "'" + paraValue.Replace("'", "") + "'");
                        break;
                    case OleDbType.Decimal:
                    case OleDbType.Double:
                    case OleDbType.Numeric:
                        first = first.Replace(paraName, paraValue);
                        break;
                    case OleDbType.DBTimeStamp:
                        first = first.Replace(paraName, "TO_DATE('" + paraValue.Replace("'", "") + "', 'YYYY-MM-DD HH24:MI:SS')");
                        break;
                }
                sql = first + last;
            }
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="sqlParameters"></param>
        /// <param name="sql"></param>
        private void ExecMessage(OdbcParameter[] odbcParameters, ref string sql)
        {
            foreach (OdbcParameter para in odbcParameters)
            {
                string paraName = "?";
                string paraValue = para.Value == null ? "" : para.Value.ToString();
                string first = sql.Substring(0, sql.IndexOf("?") + 1);
                string last = sql.Substring(sql.IndexOf("?") + 1);
                switch (para.OdbcType)
                {
                    case OdbcType.VarChar:
                    case OdbcType.NVarChar:
                        first = first.Replace(paraName, "'" + paraValue.Replace("'", "") + "'");
                        break;
                    case OdbcType.Double:
                        first = first.Replace(paraName, paraValue);
                        break;
                    case OdbcType.DateTime:
                        first = first.Replace(paraName, "TO_DATE('" + paraValue.Replace("'", "") + "', 'YYYY-MM-DD HH24:MI:SS')");
                        break;
                }
                sql = first + last;
            }
        }
    }
}