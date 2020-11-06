using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace MedicalSytem.Soft.DAL
{
    public partial class DALMedInitDict
    {
        private static readonly string Select_MedIfTransDict_OLE = "SELECT TRANS_NAME,DBMS,SERVER_NAME,DATABASE,LOG_ID,LOG_PASS,NLS_LANG,DBPARM,MEMO FROM MED_IF_TRANS_DICT WHERE TRANS_NAME = ? ";
        private static readonly string Select_MedIfRunConfigDict_OLE = "SELECT APP_CLASS,SECTION,MAIN_KEY,KEY_VALUE,MEMO FROM MED_IF_RUN_CONFIG_DICT WHERE APP_CLASS = ? ";

        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedIfTransDict")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("transName",OleDbType.VarChar)
                    };
                }
                else if (sqlParms == "SelectMedIfRunConfigDict")
                {
                    parms = new OleDbParameter[]{
                            new OleDbParameter("appClass",OleDbType.VarChar)
                        };
                }

                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public static Model.MedInitDict SelectMedIfRunConfigDictOLE(string appClass)
        {
            Model.MedInitDict medIfTransDict = null;

            OleDbParameter[] oneTransDict = GetParameterOLE("SelectMedIfRunConfigDict");
            oneTransDict[0].Value = appClass;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedIfRunConfigDict_OLE, oneTransDict))
            {
                if (medIfTransDict == null)
                    medIfTransDict = new Model.MedInitDict();
                while (oleReader.Read())
                {
                    if (!oleReader.IsDBNull(3))
                    {
                        if (oleReader.GetString(2).ToString() == "HISSUPPLY")
                            medIfTransDict.DoCareHisSupply = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "PERFORMEDCODE")
                            medIfTransDict.DoCarePerformedcode = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "REFRESHTIME")
                            medIfTransDict.DoCareRefreshtime = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISTRANSFER")
                            medIfTransDict.DoCareIsTransfer = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISORDERS")
                            medIfTransDict.DoCareIsOrders = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISLABRESULT")
                            medIfTransDict.DoCareIsLabResult = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISEMR")
                            medIfTransDict.DoCareIsEmr = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISEXAMREPORT")
                            medIfTransDict.DoCareIsExamReport = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISEXAMREPORTDICOM")
                            medIfTransDict.DoCareIsExamReportDicom = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "DAYNUM")
                            medIfTransDict.DoCareDayNum = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISCHARGE")
                            medIfTransDict.DoCareIsCharge = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISELEAUTO")
                            medIfTransDict.DoCareEleAuto = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "FORUSERID")
                            medIfTransDict.DoCareForUserId = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "FORPASSWORD")
                            medIfTransDict.DoCareForPassWord = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISOPERSCHEDULETOHIS")
                            medIfTransDict.DoCareIsOperCheduleToHis = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISOPERMASTERTOHIS")
                            medIfTransDict.DoCareIsOperMasterToHis = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISOPERSTATUSTOHIS")
                            medIfTransDict.DoCareIsOperStatusToHis = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISLOG")
                            medIfTransDict.IsLog = oleReader.GetString(3);
                    }
                }
            }

            return medIfTransDict;
        }

        public static Model.MedInitDict SelectTransDictOLE(string transName, string appClass)
        {
            Model.MedInitDict medIfTransDict = null;

            OleDbParameter[] oneTransDict = GetParameterOLE("SelectMedIfTransDict");
            oneTransDict[0].Value = transName;

            OleDbParameter[] twoTransDict = GetParameterOLE("SelectMedIfRunConfigDict");
            twoTransDict[0].Value = appClass;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedIfTransDict_OLE, oneTransDict))
            {
                if (oleReader.Read())
                {
                    medIfTransDict = new Model.MedInitDict();
                    if (!oleReader.IsDBNull(0))
                        medIfTransDict.TransName = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        medIfTransDict.Dbms = oleReader.GetString(1);
                    if (!oleReader.IsDBNull(2))
                        medIfTransDict.ServerName = oleReader.GetString(2);
                    if (!oleReader.IsDBNull(3))
                        medIfTransDict.Database = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        medIfTransDict.LogId = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        medIfTransDict.LogPass = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        medIfTransDict.NlsLang = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        medIfTransDict.Dbparm = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        medIfTransDict.Memo = oleReader.GetString(8);
                }
            }

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedIfRunConfigDict_OLE, twoTransDict))
            {
                if (medIfTransDict == null)
                    medIfTransDict = new Model.MedInitDict();

                while (oleReader.Read())
                {
                    if (!oleReader.IsDBNull(3))
                    {
                        if (oleReader.GetString(2).ToString() == "HISSUPPLY")
                            medIfTransDict.DoCareHisSupply = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "PERFORMEDCODE")
                            medIfTransDict.DoCarePerformedcode = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "REFRESHTIME")
                            medIfTransDict.DoCareRefreshtime = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISTRANSFER")
                            medIfTransDict.DoCareIsTransfer = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISORDERS")
                            medIfTransDict.DoCareIsOrders = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISLABRESULT")
                            medIfTransDict.DoCareIsLabResult = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISEMR")
                            medIfTransDict.DoCareIsEmr = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISEXAMREPORT")
                            medIfTransDict.DoCareIsExamReport = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISEXAMREPORTDICOM")
                            medIfTransDict.DoCareIsExamReportDicom = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "DAYNUM")
                            medIfTransDict.DoCareDayNum = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISCHARGE")
                            medIfTransDict.DoCareIsCharge = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISELEAUTO")
                            medIfTransDict.DoCareEleAuto = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "FORUSERID")
                            medIfTransDict.DoCareForUserId = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "FORPASSWORD")
                            medIfTransDict.DoCareForPassWord = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "OPERMASTER")
                            medIfTransDict.DoCareOperMaster = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISOPERSCHEDULETOHIS")
                            medIfTransDict.DoCareIsOperCheduleToHis = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISOPERMASTERTOHIS")
                            medIfTransDict.DoCareIsOperMasterToHis = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISOPERSTATUSTOHIS")
                            medIfTransDict.DoCareIsOperStatusToHis = oleReader.GetString(3);
                        if (oleReader.GetString(2).ToString() == "ISLOG")
                            medIfTransDict.IsLog = oleReader.GetString(3);
                    }
                }
            }

            return medIfTransDict;
        }

        private static readonly string Select_MedIfTransDict_Odbc = "SELECT TRANS_NAME,DBMS,SERVER_NAME,DATABASE,LOG_ID,LOG_PASS,NLS_LANG,DBPARM,MEMO FROM MED_IF_TRANS_DICT WHERE TRANS_NAME = ? ";
        private static readonly string Select_MedIfRunConfigDict_Odbc = "SELECT APP_CLASS,SECTION,MAIN_KEY,KEY_VALUE,MEMO FROM MED_IF_RUN_CONFIG_DICT WHERE APP_CLASS = ? ";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedIfTransDict")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("transName",OdbcType.VarChar)
                    };
                }
                else if (sqlParms == "SelectMedIfRunConfigDict")
                {
                    parms = new OdbcParameter[]{
                            new OdbcParameter("appClass",OdbcType.VarChar)
                        };
                }

                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public static Model.MedInitDict SelectMedIfRunConfigDictOdbc(string appClass)
        {
            Model.MedInitDict medIfTransDict = null;

            OdbcParameter[] oneTransDict = GetParameterOdbc("SelectMedIfRunConfigDict");
            oneTransDict[0].Value = appClass;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MedIfRunConfigDict_Odbc, oneTransDict))
            {
                if (medIfTransDict == null)
                    medIfTransDict = new Model.MedInitDict();
                while (OdbcReader.Read())
                {
                    if (!OdbcReader.IsDBNull(3))
                    {
                        if (OdbcReader.GetString(2).ToString() == "HISSUPPLY")
                            medIfTransDict.DoCareHisSupply = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "PERFORMEDCODE")
                            medIfTransDict.DoCarePerformedcode = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "REFRESHTIME")
                            medIfTransDict.DoCareRefreshtime = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISTRANSFER")
                            medIfTransDict.DoCareIsTransfer = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISORDERS")
                            medIfTransDict.DoCareIsOrders = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISLABRESULT")
                            medIfTransDict.DoCareIsLabResult = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISEMR")
                            medIfTransDict.DoCareIsEmr = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISEXAMREPORT")
                            medIfTransDict.DoCareIsExamReport = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISEXAMREPORTDICOM")
                            medIfTransDict.DoCareIsExamReportDicom = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "DAYNUM")
                            medIfTransDict.DoCareDayNum = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISCHARGE")
                            medIfTransDict.DoCareIsCharge = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISELEAUTO")
                            medIfTransDict.DoCareEleAuto = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "FORUSERID")
                            medIfTransDict.DoCareForUserId = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "FORPASSWORD")
                            medIfTransDict.DoCareForPassWord = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "OPERMASTER")
                            medIfTransDict.DoCareOperMaster = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISOPERSCHEDULETOHIS")
                            medIfTransDict.DoCareIsOperCheduleToHis = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISOPERMASTERTOHIS")
                            medIfTransDict.DoCareIsOperMasterToHis = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISOPERSTATUSTOHIS")
                            medIfTransDict.DoCareIsOperStatusToHis = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISLOG")
                            medIfTransDict.IsLog = OdbcReader.GetString(3);
                    }
                }
            }

            return medIfTransDict;
        }

        public static Model.MedInitDict SelectTransDictOdbc(string transName, string appClass)
        {
            Model.MedInitDict medIfTransDict = null;

            OdbcParameter[] oneTransDict = GetParameterOdbc("SelectMedIfTransDict");
            oneTransDict[0].Value = transName;

            OdbcParameter[] twoTransDict = GetParameterOdbc("SelectMedIfRunConfigDict");
            twoTransDict[0].Value = appClass;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MedIfTransDict_Odbc, oneTransDict))
            {
                if (OdbcReader.Read())
                {
                    medIfTransDict = new Model.MedInitDict();
                    if (!OdbcReader.IsDBNull(0))
                        medIfTransDict.TransName = OdbcReader.GetString(0);
                    if (!OdbcReader.IsDBNull(1))
                        medIfTransDict.Dbms = OdbcReader.GetString(1);
                    if (!OdbcReader.IsDBNull(2))
                        medIfTransDict.ServerName = OdbcReader.GetString(2);
                    if (!OdbcReader.IsDBNull(3))
                        medIfTransDict.Database = OdbcReader.GetString(3);
                    if (!OdbcReader.IsDBNull(4))
                        medIfTransDict.LogId = OdbcReader.GetString(4);
                    if (!OdbcReader.IsDBNull(5))
                        medIfTransDict.LogPass = OdbcReader.GetString(5);
                    if (!OdbcReader.IsDBNull(6))
                        medIfTransDict.NlsLang = OdbcReader.GetString(6);
                    if (!OdbcReader.IsDBNull(7))
                        medIfTransDict.Dbparm = OdbcReader.GetString(7);
                    if (!OdbcReader.IsDBNull(8))
                        medIfTransDict.Memo = OdbcReader.GetString(8);
                }
            }

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MedIfRunConfigDict_Odbc, twoTransDict))
            {
                if (medIfTransDict == null)
                    medIfTransDict = new Model.MedInitDict();

                while (OdbcReader.Read())
                {
                    if (!OdbcReader.IsDBNull(3))
                    {
                        if (OdbcReader.GetString(2).ToString() == "HISSUPPLY")
                            medIfTransDict.DoCareHisSupply = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "PERFORMEDCODE")
                            medIfTransDict.DoCarePerformedcode = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "REFRESHTIME")
                            medIfTransDict.DoCareRefreshtime = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISTRANSFER")
                            medIfTransDict.DoCareIsTransfer = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISORDERS")
                            medIfTransDict.DoCareIsOrders = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISLABRESULT")
                            medIfTransDict.DoCareIsLabResult = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISEMR")
                            medIfTransDict.DoCareIsEmr = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISEXAMREPORT")
                            medIfTransDict.DoCareIsExamReport = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISEXAMREPORTDICOM")
                            medIfTransDict.DoCareIsExamReportDicom = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "DAYNUM")
                            medIfTransDict.DoCareDayNum = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISCHARGE")
                            medIfTransDict.DoCareIsCharge = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISELEAUTO")
                            medIfTransDict.DoCareEleAuto = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "FORUSERID")
                            medIfTransDict.DoCareForUserId = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "FORPASSWORD")
                            medIfTransDict.DoCareForPassWord = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "OPERMASTER")
                            medIfTransDict.DoCareOperMaster = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISOPERSCHEDULETOHIS")
                            medIfTransDict.DoCareIsOperCheduleToHis = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISOPERSTATUSTOHIS")
                            medIfTransDict.DoCareIsOperStatusToHis = OdbcReader.GetString(3);
                        if (OdbcReader.GetString(2).ToString() == "ISLOG")
                            medIfTransDict.IsLog = OdbcReader.GetString(3);
                    }
                }
            }
            return medIfTransDict;
        }
    }
}
