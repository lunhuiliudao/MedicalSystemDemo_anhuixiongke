using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace InterFaceV5
{
    public class DALBASE
    {
        //private static readonly string Select_MedIfTransDict_OLE = "SELECT TRANS_NAME,DBMS,SERVER_NAME,DATABASE,LOG_ID,LOG_PASS,NLS_LANG,DBPARM,MEMO FROM MED_IF_TRANS_DICT WHERE TRANS_NAME = ? ";
        //private static readonly string Select_MedIfRunConfigDict_OLE = "SELECT APP_CLASS,SECTION,MAIN_KEY,KEY_VALUE,MEMO FROM MED_IF_RUN_CONFIG_DICT WHERE APP_CLASS = ? ";
        //private static readonly string Select_MedIfTransDict = "SELECT TRANS_NAME,DBMS,SERVER_NAME,DATABASE,LOG_ID,LOG_PASS,NLS_LANG,DBPARM,MEMO FROM MED_IF_TRANS_DICT WHERE TRANS_NAME = :transName ";
        //private static readonly string Select_MedIfRunConfigDict = "SELECT APP_CLASS,SECTION,MAIN_KEY,KEY_VALUE,MEMO FROM MED_IF_RUN_CONFIG_DICT WHERE APP_CLASS = :appClass ";
        //private static readonly string Select_MedIfTransDict_SQL = "SELECT TRANS_NAME,DBMS,SERVER_NAME,DATA_BASE,LOG_ID,LOG_PASS,NLS_LANG,DBPARM,MEMO FROM MED_IF_TRANS_DICT WHERE TRANS_NAME = @transName ";
        //private static readonly string Select_MedIfRunConfigDict_SQL = "SELECT APP_CLASS,SECTION,MAIN_KEY,KEY_VALUE,MEMO FROM MED_IF_RUN_CONFIG_DICT WHERE APP_CLASS = @appClass ";

        //public static OleDbParameter[] GetParameterOLE(string sqlParms)
        //{
        //    OleDbParameter[] parms = DataProcessOleDbHelper.GetCachedParameters(sqlParms);
        //    if (parms == null)
        //    {
        //        if (sqlParms == "SelectMedIfTransDict")
        //        {
        //            parms = new OleDbParameter[]{
        //                new OleDbParameter("transName",OleDbType.VarChar)
        //            };
        //        }
        //        else
        //        {
        //            if (sqlParms == "SelectMedIfRunConfigDict")
        //            {
        //                parms = new OleDbParameter[]{
        //                    new OleDbParameter("appClass",OleDbType.VarChar)
        //                };
        //            }
        //        }
        //        DataProcessOleDbHelper.CacheParameters(sqlParms, parms);
        //    }
        //    return parms;
        //}
        /////// <summary>
        ///// 获取基本数据
        ///// </summary>
        ///// <param name="transNameConn">DoCare连接字符串</param>
        ///// <param name="transName"></param>
        ///// <param name="appClass"></param>
        ///// <returns></returns>
        //public static GPublicIni SelectTransDictOLE(string transNameConn, string transName, string appClass)
        //{
        //    GPublicIni medIfTransDict = null;

        //    OleDbParameter[] oneTransDict = GetParameterOLE("SelectMedIfTransDict");
        //    oneTransDict[0].Value = transName;

        //    OleDbParameter[] twoTransDict = GetParameterOLE("SelectMedIfRunConfigDict");
        //    twoTransDict[0].Value = appClass;

        //    using (OleDbDataReader oleReader = DataProcessOleDbHelper.ExecuteReader(transNameConn, CommandType.Text, Select_MedIfTransDict_OLE, oneTransDict))
        //    {
        //        if (oleReader.Read())
        //        {
        //            medIfTransDict = new GPublicIni();
        //            if (!oleReader.IsDBNull(0))
        //                medIfTransDict.TransName = oleReader.GetString(0);
        //            if (!oleReader.IsDBNull(1))
        //                medIfTransDict.Dbms = oleReader.GetString(1);
        //            if (!oleReader.IsDBNull(2))
        //                medIfTransDict.ServerName = oleReader.GetString(2);
        //            if (!oleReader.IsDBNull(3))
        //                medIfTransDict.Database = oleReader.GetString(3);
        //            if (!oleReader.IsDBNull(4))
        //                medIfTransDict.LogId = oleReader.GetString(4);
        //            if (!oleReader.IsDBNull(5))
        //                medIfTransDict.LogPass = oleReader.GetString(5);
        //            if (!oleReader.IsDBNull(6))
        //                medIfTransDict.NlsLang = oleReader.GetString(6);
        //            if (!oleReader.IsDBNull(7))
        //                medIfTransDict.Dbparm = oleReader.GetString(7);
        //            if (!oleReader.IsDBNull(8))
        //                medIfTransDict.Memo = oleReader.GetString(8);
        //        }
        //        else
        //            medIfTransDict = null;
        //    }

        //    using (OleDbDataReader oleReader = DataProcessOleDbHelper.ExecuteReader(transNameConn, CommandType.Text, Select_MedIfRunConfigDict_OLE, twoTransDict))
        //    {
        //        if (medIfTransDict == null)
        //            medIfTransDict = new GPublicIni();

        //        while (oleReader.Read())
        //        {
        //            if (!oleReader.IsDBNull(3))
        //            {
        //                if (oleReader.GetString(2).ToString() == "HISSUPPLY")
        //                    medIfTransDict.DoCareHisSupply = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "PERFORMEDCODE")
        //                    medIfTransDict.DoCarePerformedcode = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "REFRESHTIME")
        //                    medIfTransDict.DoCareRefreshtime = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISTRANSFER")
        //                    medIfTransDict.DoCareIstransfer = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISORDERS")
        //                    medIfTransDict.DoCareIsOrders = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISLABRESULT")
        //                    medIfTransDict.DoCareIsLabResult = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISEMR")
        //                    medIfTransDict.DoCareIsEmr = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISEXAMREPORT")
        //                    medIfTransDict.DoCareIsExamReport = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISEXAMREPORTDICOM")
        //                    medIfTransDict.DoCareIsExamReportDicom = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISPISREPORT")
        //                    medIfTransDict.DoCareIsPisReport = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "FORUSERID")
        //                    medIfTransDict.DoCareForUserId = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "FORPASSWORD")
        //                    medIfTransDict.DoCareForPassWord = oleReader.GetString(3);

        //            }
        //        }
        //    }

        //    return medIfTransDict;
        //}

        //public static OracleParameter[] GetParameter(string sqlParms)
        //{
        //    OracleParameter[] parms = DataProcessOracleHelper.GetCachedParameters(sqlParms);
        //    if (parms == null)
        //    {
        //        if (sqlParms == "SelectMedIfTransDict")
        //        {
        //            parms = new OracleParameter[]{
        //                new OracleParameter(":transName",OracleType.VarChar)
        //            };
        //        }
        //        else
        //        {
        //            if (sqlParms == "SelectMedIfRunConfigDict")
        //            {
        //                parms = new OracleParameter[]{
        //                    new OracleParameter(":appClass",OracleType.VarChar)
        //                };
        //            }
        //        }
        //        DataProcessOracleHelper.CacheParameters(sqlParms, parms);
        //    }
        //    return parms;
        //}
        ///// <summary>
        ///// 获取基本数据
        ///// </summary>
        ///// <param name="transNameConn">DoCare连接字符串</param>
        ///// <param name="transName"></param>
        ///// <param name="appClass"></param>
        ///// <returns></returns>
        //public static GPublicIni SelectTransDict(string transNameConn, string transName, string appClass)
        //{
        //    GPublicIni medIfTransDict = null;

        //    OracleParameter[] oneTransDict = GetParameter("SelectMedIfTransDict");
        //    oneTransDict[0].Value = transName;

        //    OracleParameter[] twoTransDict = GetParameter("SelectMedIfRunConfigDict");
        //    twoTransDict[0].Value = appClass;

        //    using (OracleDataReader oleReader = DataProcessOracleHelper.ExecuteReader(transNameConn, CommandType.Text, Select_MedIfTransDict, oneTransDict))
        //    {
        //        if (oleReader.Read())
        //        {
        //            medIfTransDict = new GPublicIni();
        //            if (!oleReader.IsDBNull(0))
        //                medIfTransDict.TransName = oleReader.GetString(0);
        //            if (!oleReader.IsDBNull(1))
        //                medIfTransDict.Dbms = oleReader.GetString(1);
        //            if (!oleReader.IsDBNull(2))
        //                medIfTransDict.ServerName = oleReader.GetString(2);
        //            if (!oleReader.IsDBNull(3))
        //                medIfTransDict.Database = oleReader.GetString(3);
        //            if (!oleReader.IsDBNull(4))
        //                medIfTransDict.LogId = oleReader.GetString(4);
        //            if (!oleReader.IsDBNull(5))
        //                medIfTransDict.LogPass = oleReader.GetString(5);
        //            if (!oleReader.IsDBNull(6))
        //                medIfTransDict.NlsLang = oleReader.GetString(6);
        //            if (!oleReader.IsDBNull(7))
        //                medIfTransDict.Dbparm = oleReader.GetString(7);
        //            if (!oleReader.IsDBNull(8))
        //                medIfTransDict.Memo = oleReader.GetString(8);
        //        }
        //        else
        //            medIfTransDict = null;
        //    }

        //    using (OracleDataReader oleReader = DataProcessOracleHelper.ExecuteReader(transNameConn, CommandType.Text, Select_MedIfRunConfigDict, twoTransDict))
        //    {
        //        if (medIfTransDict == null)
        //            medIfTransDict = new GPublicIni();

        //        while (oleReader.Read())
        //        {
        //            if (!oleReader.IsDBNull(3))
        //            {

        //                if (oleReader.GetString(2).ToString() == "HISSUPPLY")
        //                    medIfTransDict.DoCareHisSupply = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "PERFORMEDCODE")
        //                    medIfTransDict.DoCarePerformedcode = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "REFRESHTIME")
        //                    medIfTransDict.DoCareRefreshtime = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISTRANSFER")
        //                    medIfTransDict.DoCareIstransfer = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISORDERS")
        //                    medIfTransDict.DoCareIsOrders = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISLABRESULT")
        //                    medIfTransDict.DoCareIsLabResult = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISEMR")
        //                    medIfTransDict.DoCareIsEmr = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISEXAMREPORT")
        //                    medIfTransDict.DoCareIsExamReport = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISEXAMREPORTDICOM")
        //                    medIfTransDict.DoCareIsExamReportDicom = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISPISREPORT")
        //                    medIfTransDict.DoCareIsPisReport = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "FORUSERID")
        //                    medIfTransDict.DoCareForUserId = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "FORPASSWORD")
        //                    medIfTransDict.DoCareForPassWord = oleReader.GetString(3);

        //            }
        //        }
        //    }

        //    return medIfTransDict;
        //}

        //public static SqlParameter[] GetParameterSQL(string sqlParms)
        //{
        //    SqlParameter[] parms = DataProcessSQLHelper.GetCachedParameters(sqlParms);
        //    if (parms == null)
        //    {
        //        if (sqlParms == "SelectMedIfTransDict")
        //        {
        //            parms = new SqlParameter[]{
        //                new SqlParameter("@transName",SqlDbType.VarChar)
        //            };
        //        }
        //        else
        //        {
        //            if (sqlParms == "SelectMedIfRunConfigDict")
        //            {
        //                parms = new SqlParameter[]{
        //                    new SqlParameter("@appClass",SqlDbType.VarChar)
        //                };
        //            }
        //        }
        //        DataProcessSQLHelper.CacheParameters(sqlParms, parms);
        //    }
        //    return parms;
        //}
        ///// <summary>
        ///// 获取基本数据
        ///// </summary>
        ///// <param name="transNameConn">DoCare连接字符串</param>
        ///// <param name="transName"></param>
        ///// <param name="appClass"></param>
        ///// <returns></returns>
        //public static GPublicIni SelectTransDictSQL(string transNameConn, string transName, string appClass)
        //{
        //    GPublicIni medIfTransDict = null;

        //    SqlParameter[] oneTransDict = GetParameterSQL("SelectMedIfTransDict");
        //    oneTransDict[0].Value = transName;

        //    SqlParameter[] twoTransDict = GetParameterSQL("SelectMedIfRunConfigDict");
        //    twoTransDict[0].Value = appClass;

        //    using (SqlDataReader oleReader = DataProcessSQLHelper.ExecuteReader(transNameConn, CommandType.Text, Select_MedIfTransDict_SQL, oneTransDict))
        //    {
        //        if (oleReader.Read())
        //        {
        //            medIfTransDict = new GPublicIni();
        //            if (!oleReader.IsDBNull(0))
        //                medIfTransDict.TransName = oleReader.GetString(0);
        //            if (!oleReader.IsDBNull(1))
        //                medIfTransDict.Dbms = oleReader.GetString(1);
        //            if (!oleReader.IsDBNull(2))
        //                medIfTransDict.ServerName = oleReader.GetString(2);
        //            if (!oleReader.IsDBNull(3))
        //                medIfTransDict.Database = oleReader.GetString(3);
        //            if (!oleReader.IsDBNull(4))
        //                medIfTransDict.LogId = oleReader.GetString(4);
        //            if (!oleReader.IsDBNull(5))
        //                medIfTransDict.LogPass = oleReader.GetString(5);
        //            if (!oleReader.IsDBNull(6))
        //                medIfTransDict.NlsLang = oleReader.GetString(6);
        //            if (!oleReader.IsDBNull(7))
        //                medIfTransDict.Dbparm = oleReader.GetString(7);
        //            if (!oleReader.IsDBNull(8))
        //                medIfTransDict.Memo = oleReader.GetString(8);
        //        }
        //        else
        //            medIfTransDict = null;
        //    }

        //    using (SqlDataReader oleReader = DataProcessSQLHelper.ExecuteReader(transNameConn, CommandType.Text, Select_MedIfRunConfigDict_SQL, twoTransDict))
        //    {
        //        if (medIfTransDict == null)
        //            medIfTransDict = new GPublicIni();

        //        while (oleReader.Read())
        //        {
        //            if (!oleReader.IsDBNull(3))
        //            {
        //                if (oleReader.GetString(2).ToString() == "HISSUPPLY")
        //                    medIfTransDict.DoCareHisSupply = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "PERFORMEDCODE")
        //                    medIfTransDict.DoCarePerformedcode = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "REFRESHTIME")
        //                    medIfTransDict.DoCareRefreshtime = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISTRANSFER")
        //                    medIfTransDict.DoCareIstransfer = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISORDERS")
        //                    medIfTransDict.DoCareIsOrders = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISLABRESULT")
        //                    medIfTransDict.DoCareIsLabResult = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISEMR")
        //                    medIfTransDict.DoCareIsEmr = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISEXAMREPORT")
        //                    medIfTransDict.DoCareIsExamReport = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISEXAMREPORTDICOM")
        //                    medIfTransDict.DoCareIsExamReportDicom = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "ISPISREPORT")
        //                    medIfTransDict.DoCareIsPisReport = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "FORUSERID")
        //                    medIfTransDict.DoCareForUserId = oleReader.GetString(3);
        //                if (oleReader.GetString(2).ToString() == "FORPASSWORD")
        //                    medIfTransDict.DoCareForPassWord = oleReader.GetString(3);

        //            }
        //        }
        //    }

        //    return medIfTransDict;
        //}
    }
}
