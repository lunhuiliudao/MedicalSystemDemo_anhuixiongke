using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using MedicalSytem.Soft.DAL;
using System.Data;
using MedicalSytem.Soft.Model;
using System.Data.OracleClient;
using System.Data.OleDb;

namespace MedicalSytem.Soft.DAL
{
    public  class DALMedIFLog
    {

        #region SqlServer 版本
        static   string sqlSelectByDate = "select * from Med_if_log where Date=@Date";
        static   string sqlselectAll = "select * from Med_if_log";
        static string sqlInsert = "Insert into Med_if_log(Id,LDate,LTime,Title,Module,Grade,Content,Source,Category,isShow,currentUser)values(@Id,@LDate,@LTime,@Title,@Module,@Grade,@Content,@Source,@Category,@isShow,@currentUser)";

        /// <summary>
        ///获取参数MedHisViewSql
        /// </summary>
        private static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedIfLogByDate")
                {
                    parms = new SqlParameter[]{
                            new SqlParameter("@Date",SqlDbType.VarChar),
                        };
                }
                else if (sqlParms == "InsertMedIfLog")
                {
                    parms = new SqlParameter[] {
                      new SqlParameter("@Id",SqlDbType.VarChar),
                      new SqlParameter("@LDate",SqlDbType.VarChar),
                      new SqlParameter("@LTime",SqlDbType.VarChar),
                      new SqlParameter("@Title",SqlDbType.VarChar),
                      new SqlParameter("@Module",SqlDbType.VarChar),
                      new SqlParameter("@Grade",SqlDbType.VarChar),
                      new SqlParameter("@Content",SqlDbType.VarChar),
                      new SqlParameter("@Source",SqlDbType.VarChar),
                      new SqlParameter("@Category",SqlDbType.VarChar),
                      new SqlParameter("@isShow",SqlDbType.VarChar),
                      new SqlParameter("@currentUser",SqlDbType.VarChar)
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        /// <summary>
        /// 根据日期查询日志
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static  List<MedIfLog> GetMedIFLogByDateSQL(string date)
        {
            List<MedIfLog> result = new List<MedIfLog>();
            MedIfLog entity = null;
            SqlParameter[] p = GetParameterSQL("SelectMedIfLogByDate");
            p[0].Value = date;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sqlSelectByDate, p))
            {
                while (sdr.Read())
                {
                    entity = new MedIfLog();
                    entity.Id = sdr["Id"].ToString();
                    entity.Module = sdr["Module"].ToString();
                    entity.Category = sdr["Category"].ToString();
                    entity.Content = sdr["Content"].ToString();
                    entity.Date = sdr["Date"].ToString();
                    entity.Grade = sdr["Grade"].ToString();
                    entity.Source = sdr["Source"].ToString();
                    entity.Time = sdr["Time"].ToString();
                    entity.Title = sdr["Title"].ToString();
                    entity.IsShow = sdr["isShow"].ToString();
                    entity.CurrentUser = sdr["currentUser"].ToString();
                    result.Add(entity);
                }

            }
            return result;
        }

        /// <summary>
        /// 插入一条日志
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static  int InsertMedifLogSQL(MedIfLog entity)
        {
            SqlParameter[] p = GetParameterSQL("InsertMedIfLog");
            p[0].Value = entity.Id;
            p[1].Value = entity.Date;
            p[2].Value = entity.Time;
            p[3].Value = entity.Title;
            p[4].Value = entity.Module;
            p[5].Value = entity.Grade;
            p[6].Value = entity.Content;
            p[7].Value = entity.Source;
            p[8].Value = entity.Category;
            p[9].Value = entity.IsShow;
            p[10].Value = entity.CurrentUser;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, sqlInsert, p);
        }
        #endregion 

        #region Oracle 版本
       static  string sqlSelectByDateOracle = "select * from Med_if_log where Date=:Date";

       static string sqlInsertOracle = "Insert into Med_if_log(Id,LDate,LTime,Title,Module,Grade,Content,Source,Category,isShow,currentUser)values(:Id,:LDate,:LTime,:Title,:Module,:Grade,:Content,:Source,:Category,:isShow,:currentUser)";

        /// <summary>
        ///获取参数MedHisViewSql
        /// </summary>
        private static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedIfLogByDate")
                {
                    parms = new OracleParameter[]{
                            new OracleParameter(":Date", OracleType.VarChar),
                        };
                }
                else if (sqlParms == "InsertMedIfLog")
                {
                    parms = new OracleParameter[] {
                      new OracleParameter(":Id",OracleType.VarChar),
                      new OracleParameter(":LDate",OracleType.VarChar),
                      new OracleParameter(":LTime",OracleType.VarChar),
                      new OracleParameter(":Title",OracleType.VarChar),
                      new OracleParameter(":Module",OracleType.VarChar),
                      new OracleParameter(":Grade",OracleType.VarChar),
                      new OracleParameter(":Content",OracleType.VarChar),
                      new OracleParameter(":Source",OracleType.VarChar),
                      new OracleParameter(":Category",OracleType.VarChar),
                      new OracleParameter(":isShow",OracleType.VarChar),
                      new OracleParameter(":currentUser",OracleType.VarChar),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        /// <summary>
        /// 根据日期查询日志
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static  List<MedIfLog> GetMedIFLogByDate(string date)
        {
            List<MedIfLog> result = new List<MedIfLog>();
            MedIfLog entity = null;
            OracleParameter[] p = GetParameter("SelectMedIfLogByDate");
            p[0].Value = date;

            using (OracleDataReader sdr = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, sqlSelectByDateOracle, p))
            {
                while (sdr.Read())
                {
                    entity = new MedIfLog();
                    entity.Id = sdr["Id"].ToString();
                    entity.Module = sdr["Module"].ToString();
                    entity.Category = sdr["Category"].ToString();
                    entity.Content = sdr["Content"].ToString();
                    entity.Date = sdr["Date"].ToString();
                    entity.Grade = sdr["Grade"].ToString();
                    entity.Source = sdr["Source"].ToString();
                    entity.Time = sdr["Time"].ToString();
                    entity.Title = sdr["Title"].ToString();
                    entity.IsShow = sdr["isShow"].ToString();
                    entity.CurrentUser = sdr["currentUser"].ToString();
                    result.Add(entity);
                }

            }
            return result;
        }

        /// <summary>
        /// 插入一条日志
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static  int InsertMedifLog(MedIfLog entity)
        {
            OracleParameter[] p = GetParameter("InsertMedIfLog");
            p[0].Value = entity.Id;
            p[1].Value = entity.Date;
            p[2].Value = entity.Time;
            p[3].Value = entity.Title;
            p[4].Value = entity.Module;
            p[5].Value = entity.Grade;
            p[6].Value = entity.Content;
            p[7].Value = entity.Source;
            p[8].Value = entity.Category;
            p[9].Value = entity.IsShow;
            p[10].Value = entity.CurrentUser;
            return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, sqlInsertOracle, p);
        }
        #endregion 

        #region OraOLE 版本
       static  string sqlSelectByDateOraOLE = "select * from Med_if_log where Date=?";

       static string sqlInsertOraOLE = "Insert into Med_if_log(Id,LDate,LTime,Title,Module,Grade,Content,Source,Category,isShow,currentUser)values(?,?,?,?,?,?,?,?,?,?,?)";

        /// <summary>
        ///获取参数MedHisViewSql
        /// </summary>
        private static OleDbParameter[] GetParameterOLEDB(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedIfLogByDate")
                {
                    parms = new OleDbParameter[]{
                            new OleDbParameter("Date", OleDbType.VarChar),
                        };
                }
                else if (sqlParms == "InsertMedIfLog")
                {
                    parms = new OleDbParameter[] {
                      new OleDbParameter("Id",OleDbType.VarChar),
                      new OleDbParameter("LDate",OleDbType.VarChar),
                      new OleDbParameter("LTime",OleDbType.VarChar),
                      new OleDbParameter("Title",OleDbType.VarChar),
                      new OleDbParameter("Module",OleDbType.VarChar),
                      new OleDbParameter("Grade",OleDbType.VarChar),
                      new OleDbParameter("Content",OleDbType.VarChar),
                      new OleDbParameter("Source",OleDbType.VarChar),
                      new OleDbParameter("Category",OleDbType.VarChar),
                      new OleDbParameter("IsShow",OleDbType.VarChar),
                      new OleDbParameter("CurrentUser",OleDbType.VarChar),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        /// <summary>
        /// 根据日期查询日志
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static  List<MedIfLog> GetMedIFLogByDateOleDb(string date)
        {
            List<MedIfLog> result = new List<MedIfLog>();
            MedIfLog entity = null;
            OleDbParameter[] p = GetParameterOLEDB("SelectMedIfLogByDate");
            p[0].Value = date;

            using (OleDbDataReader sdr = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, sqlSelectByDateOraOLE, p))
            {
                while (sdr.Read())
                {
                    entity = new MedIfLog();
                    entity.Id = sdr["Id"].ToString();
                    entity.Module = sdr["Module"].ToString();
                    entity.Category = sdr["Category"].ToString();
                    entity.Content = sdr["Content"].ToString();
                    entity.Date = sdr["Date"].ToString();
                    entity.Grade = sdr["Grade"].ToString();
                    entity.Source = sdr["Source"].ToString();
                    entity.Time = sdr["Time"].ToString();
                    entity.Title = sdr["Title"].ToString();
                    entity.IsShow = sdr["isShow"].ToString();
                    entity.CurrentUser = sdr["currentUser"].ToString();
                    result.Add(entity);
                }

            }
            return result;
        }

        /// <summary>
        /// 插入一条日志
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static  int InsertMedifLogOleDb(MedIfLog entity)
        {
            OleDbParameter[] p = GetParameterOLEDB("InsertMedIfLog");
            p[0].Value = entity.Id;
            p[1].Value = entity.Date;
            p[2].Value = entity.Time;
            p[3].Value = entity.Title;
            p[4].Value = entity.Module;
            p[5].Value = entity.Grade;
            p[6].Value = entity.Content;
            p[7].Value = entity.Source;
            p[8].Value = entity.Category;
            p[9].Value = entity.IsShow;
            p[10].Value = entity.CurrentUser; 
            return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString,  CommandType.Text ,sqlInsertOraOLE, p);
        }
        #endregion 
    }
}
