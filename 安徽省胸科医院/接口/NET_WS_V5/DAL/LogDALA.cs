using System;
using System.Collections.Generic;
using System.Text;
using MedicalSytem.Soft.DAL;
using MedicalSytem.Soft.Model;
using System.IO;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.Common;

 

/// <summary>
/// 公用类
/// </summary>
namespace InitDocare
{
    public class LogDALA
    {
        public static MedicalSytem.Soft.Model.MedInitDict doCareDict = null;

        #region Debug

        public static void InsertDB(string title, string module, string grade, string content, string source, string category, string currentUser)
        {
            MedIfLog log = new MedIfLog();
            log.Title = title;
            log.Module = module;
            log.Grade = grade;
            log.Content = content;
            log.Source = source;
            log.Category = category;
            log.IsShow = false.GetHashCode().ToString();
            log.Category = currentUser;
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(object message)
        {

            string current = System.AppDomain.CurrentDomain.BaseDirectory + "\\sqllog\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "\\sqllog\\"))
            {
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "\\sqllog\\");
            }
            if (!File.Exists(current))
            {
                FileStream fs = new FileStream(current, FileMode.Create, FileAccess.Write);//创建写入文件      
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("-----------------------------------------------------------");
                sw.WriteLine("接口日志：时间 " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
                sw.Write(message + "");
                sw.Close();
                fs.Close();
            }
            else
            {
                using (StreamWriter sw = File.AppendText(current))
                {
                    sw.WriteLine("-----------------------------------------------------------");
                    sw.WriteLine("接口日志：时间 " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
                    sw.Write(message + "");
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

            string current = System.AppDomain.CurrentDomain.BaseDirectory + "\\sqllog\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "\\sqllog\\"))
            {
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "\\sqllog\\");
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

        #endregion

      

        private static List<MedIfLog> logEntityList
        {
            get;
            set;
        }

        ///// <summary>
        ///// 新增一条日期记录
        ///// </summary>
        ///// <param name="category"></param>
        ///// <param name="grade"></param>
        ///// <param name="module"></param>
        ///// <param name="coruce"></param>
        ///// <param name="content"></param>
        ///// <param name="currentUser"></param>
        ///// <param name="title"></param>
        //public static void ToLogCache(EmunLog.EnumTypeCategory category, EmunLog.EnumTypeGrade grade, EmunLog.EnumTypeModule module, InitDocare.EmunLog.EnumTypeSource source, string content, string currentUser, string title)
        //{

        //    MedIfLog logEntity = new MedIfLog();
        //    logEntity.Category = category.ToString();
        //    logEntity.Content = content;
        //    logEntity.Date = DateTime.Now.ToString("yyyy-MM-dd");
        //    logEntity.Grade = grade.ToString();
        //    logEntity.Id = Guid.NewGuid().ToString();
        //    logEntity.IsShow = false.GetHashCode().ToString();
        //    logEntity.Module = module.ToString();
        //    logEntity.Source = source.ToString();
        //    logEntity.Time = DateTime.Now.ToString("HH:mm:ss");
        //    logEntity.Title = title;
        //    logEntity.CurrentUser = currentUser;

        //    List<MedIfLog> logEntityListTemp = logEntityList;
        //    if (logEntityListTemp == null)
        //    {
        //        logEntityListTemp = new List<MedIfLog>();
        //    }
        //    logEntityListTemp.Add(logEntity);
        //    logEntityList = logEntityListTemp;
        //}

        /// <summary>
        /// 写入数据库
        /// </summary>
        public static void LogCommit()
        {
            
            try
            {
                //foreach (MedIfLog entity in logEntityList)
                //{
                //    if (DateType.Contains("OLE"))
                //    {
                //        MedicalSytem.Soft.DAL.DALMedIFLog.InsertMedifLogOleDb(entity);
                //    }
                //    else if (DateType.ToUpper().Contains("SQLSERVER"))
                //    {
                //        MedicalSytem.Soft.DAL.DALMedIFLog.InsertMedifLogSQL(entity);
                //    }
                //    else if (DateType.ToUpper().Contains("ORACLE"))
                //    {
                //        MedicalSytem.Soft.DAL.DALMedIFLog.InsertMedifLog(entity);
                //    }
                //}
            }
            catch (Exception ex)
            {
               // InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n");
            }
            ///插入完数据清理属性记录
            logEntityList = null;
        }
    }

}


