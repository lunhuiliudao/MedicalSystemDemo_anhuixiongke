using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.OracleClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Collections;
using System.Data;


namespace InitDocare
{
    public class LogHelper
    {
   
        public static void LogWrite(string sql)
        {
            string current = System.AppDomain.CurrentDomain.BaseDirectory + "\\sqllogs\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "\\sqllogs\\"))
            {
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "\\sqllogs\\");
            }
            if (!File.Exists(current))
            {
                FileStream fs = new FileStream(current, FileMode.Create, FileAccess.Write);//创建写入文件      
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("-----------------------------------------------------------");
                sw.WriteLine("接口日志：时间 " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
                sw.Write(sql);
                sw.Close();
                fs.Close();
            }
            else
            {
                using (StreamWriter sw = File.AppendText(current))
                {
                    sw.WriteLine("-----------------------------------------------------------");
                    sw.WriteLine("接口日志：时间 " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
                    sw.Write(sql);
                    sw.Close();
                }
            }
        }
      
        public static void LogWrite(DbParameter[] parameters, string sql)
        {
            if (parameters == null)
            {
                return;
            }
           
            DbParameter dbp = parameters[0];

            if (dbp is SqlParameter)
            {
                LogWrite(parameters as SqlParameter[], ref sql);
            }
            else if (dbp is OracleParameter)
            {
                LogWrite(parameters as OracleParameter[], ref sql);
            }
            else if (dbp is OleDbParameter)
            {
                LogWrite(parameters as OleDbParameter[], ref sql);
            }
            else if (dbp is OdbcParameter)
            {
                LogWrite(parameters as OdbcParameter[], ref sql);
            }

            string current = System.AppDomain.CurrentDomain.BaseDirectory + "\\sqllogs\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "\\sqllogs\\"))
            {
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "\\sqllogs\\");
            }
            if (!File.Exists(current))
            {
                FileStream fs = new FileStream(current, FileMode.Create, FileAccess.Write);//创建写入文件      
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("-----------------------------------------------------------");
                sw.WriteLine("接口日志：时间 " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
                sw.Write(sql);
                sw.Close();
                fs.Close();
            }
            else
            {
                using (StreamWriter sw = File.AppendText(current))
                {
                    sw.WriteLine("-----------------------------------------------------------");
                    sw.WriteLine("接口日志：时间 " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
                    sw.Write(sql);
                    sw.Close();
                }
            }
        }

        private static void LogWrite(SqlParameter[] sqlParameters, ref string sql)
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
                        sql = sql.Replace(paraName, "'" + paraValue.Replace("'", "") + "'");
                        break;
                    case System.Data.SqlDbType.Decimal:
                    case System.Data.SqlDbType.Float:
                        sql = sql.Replace(paraName, paraValue);
                        break;
                    case System.Data.SqlDbType.Date:
                    case System.Data.SqlDbType.DateTime:
                        sql = sql.Replace(paraName, "'" + paraValue.Replace("'", "") + "'");
                        break;
                }
            }
        }

        private static void LogWrite(OracleParameter[] sqlParameters, ref string sql)
        {

            Dictionary<OracleParameter, int> dic = new Dictionary<OracleParameter, int>();
            foreach (OracleParameter para in sqlParameters)
            {
                dic.Add(para, para.ParameterName.Length);
            }
            List<KeyValuePair<OracleParameter, int>> myList = new List<KeyValuePair<OracleParameter, int>>(dic);
            myList.Sort(delegate(KeyValuePair<OracleParameter, int> s1, KeyValuePair<OracleParameter, int> s2)
            {
                return s1.Value.CompareTo(s2.Value);
            });
            List<OracleParameter> paraList = new List<OracleParameter>();
            for (int i = myList.Count - 1; i >= 0; i--)
            {
                paraList.Add(myList[i].Key);
            }
            foreach (OracleParameter para in paraList)
            {
                string paraName = para.ParameterName;
                string paraValue = para.Value == null ? "" : para.Value.ToString();
                switch (para.OracleType)
                {
                    case OracleType.VarChar:
                    case OracleType.NVarChar:
                        sql = sql.Replace(paraName, "'" + paraValue.Replace("'", "") + "'");
                        break;
                    case OracleType.Number:
                    case OracleType.Double:
                        sql = sql.Replace(paraName, paraValue);
                        break;
                    case OracleType.DateTime:
                        sql = sql.Replace(paraName, "TO_DATE('" + paraValue.Replace("'", "") + "', 'YYYY-MM-DD HH24:MI:SS')");
                        break;
                }
            }
        }

        private static void LogWrite(OleDbParameter[] sqlParameters, ref string sql)
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
        private static void LogWrite(OdbcParameter[] odbcParameters, ref string sql)
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
