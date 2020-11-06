using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.Odbc;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
    public partial class DALMedIfTransDict
    {
        private static readonly string Select_MedIfTransDict_All = "select trans_name, dbms, server_name, database, log_id, log_pass, nls_lang, dbparm, memo from med_if_trans_dict";
        private static readonly string Select_MedIfTransDict_OLE = "select trans_name, dbms, server_name, database, log_id, log_pass, nls_lang, dbparm, memo from med_if_trans_dict WHERE trans_name = ? ";
        private static readonly string Insert_MedIfTransDict_OLE = "insert into med_if_trans_dict(trans_name, dbms, server_name, database, log_id, log_pass, nls_lang, dbparm, memo) values(?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private static readonly string Update_MedIfTransDict_OLE = "update med_if_trans_dict set dbms = ?, server_name = ?, database = ?, log_id = ?, log_pass = ?, nls_lang = ?, dbparm = ?, memo = ? where trans_name = ?";

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
                else if (sqlParms == "InsertMedIfTransDict")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("transName",OleDbType.VarChar),
                        new OleDbParameter("dbms",OleDbType.VarChar), 
                        new OleDbParameter("serverName",OleDbType.VarChar), 
                        new OleDbParameter("database",OleDbType.VarChar),
                        new OleDbParameter("logId",OleDbType.VarChar),
                        new OleDbParameter("logPass",OleDbType.VarChar),
                        new OleDbParameter("nlsLang",OleDbType.VarChar),
                        new OleDbParameter("dbparm",OleDbType.VarChar),
                        new OleDbParameter("memo",OleDbType.VarChar)
                    };
                }
                else if (sqlParms == "UpdateMedIfTransDict")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("dbms",OleDbType.VarChar), 
                        new OleDbParameter("serverName",OleDbType.VarChar), 
                        new OleDbParameter("database",OleDbType.VarChar),
                        new OleDbParameter("logId",OleDbType.VarChar),
                        new OleDbParameter("logPass",OleDbType.VarChar),
                        new OleDbParameter("nlsLang",OleDbType.VarChar),
                        new OleDbParameter("dbparm",OleDbType.VarChar),
                        new OleDbParameter("memo",OleDbType.VarChar),
                        new OleDbParameter("nlsLang1",OleDbType.VarChar)
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedIfTransDict SelectMedIfTransDictOLE(string transName)
        {
            Model.MedIfTransDict OneMedIfTransDict = null;

            OleDbParameter[] paramHisUsers = GetParameterOLE("SelectMedIfTransDict");
            paramHisUsers[0].Value = transName;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedIfTransDict_All, paramHisUsers))
            {
                if (oleReader.Read())
                {
                    OneMedIfTransDict = new Model.MedIfTransDict();
                    if (!oleReader.IsDBNull(0))
                        OneMedIfTransDict.TransName = oleReader.GetString(0);

                    if (!oleReader.IsDBNull(2))
                        OneMedIfTransDict.ServerName = oleReader.GetString(2);
                    if (!oleReader.IsDBNull(3))
                        OneMedIfTransDict.Database = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        OneMedIfTransDict.LogId = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        OneMedIfTransDict.LogPass = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        OneMedIfTransDict.NlsLang = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        OneMedIfTransDict.Dbparm = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        OneMedIfTransDict.Memo = oleReader.GetString(8);

                    if (oleReader.GetString(1) == "SQLSERVER")
                        OneMedIfTransDict.Dbms = EnumDataBase.SQLSERVER;
                    else if (oleReader.GetString(1) == "ORACLE")
                        OneMedIfTransDict.Dbms = EnumDataBase.ORACLE;
                    else if (oleReader.GetString(1) == "ODBC")
                        OneMedIfTransDict.Dbms = EnumDataBase.ODBC;
                    else if (oleReader.GetString(1) == "OLEDB")
                        OneMedIfTransDict.Dbms = EnumDataBase.OLEDB;
                    else if (oleReader.GetString(1) == "MYSQL")
                        OneMedIfTransDict.Dbms = EnumDataBase.MYSQL;
                    else
                        OneMedIfTransDict.Dbms = EnumDataBase.Undefined;
                }
                else
                    OneMedIfTransDict = null;
            }
            return OneMedIfTransDict;
        }

        public int InsertMedIfTransDictOLE(Model.MedIfTransDict MedIfTransDict)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedIfTransDict");
                if (MedIfTransDict.TransName != null)
                    oneInert[0].Value = MedIfTransDict.TransName;
                else
                    oneInert[0].Value = DBNull.Value;
                if (MedIfTransDict.Dbms != null)
                    oneInert[1].Value = MedIfTransDict.Dbms;
                else
                    oneInert[1].Value = DBNull.Value;
                if (MedIfTransDict.ServerName != null)
                    oneInert[2].Value = MedIfTransDict.ServerName;
                else
                    oneInert[2].Value = DBNull.Value;
                if (MedIfTransDict.Database != null)
                    oneInert[3].Value = MedIfTransDict.Database;
                else
                    oneInert[3].Value = DBNull.Value;
                if (MedIfTransDict.LogId != null)
                    oneInert[4].Value = MedIfTransDict.LogId;
                else
                    oneInert[4].Value = DBNull.Value;
                if (MedIfTransDict.LogPass != null)
                    oneInert[5].Value = MedIfTransDict.LogPass;
                else
                    oneInert[5].Value = DBNull.Value;
                if (MedIfTransDict.NlsLang != null)
                    oneInert[6].Value = MedIfTransDict.NlsLang;
                else
                    oneInert[6].Value = DBNull.Value;
                if (MedIfTransDict.Dbparm != null)
                    oneInert[7].Value = MedIfTransDict.Dbparm;
                else
                    oneInert[7].Value = DBNull.Value;
                if (MedIfTransDict.Memo != null)
                    oneInert[8].Value = MedIfTransDict.Memo;
                else
                    oneInert[8].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_MedIfTransDict_OLE, oneInert);
            }
        }

        public void InsertMedIfTransDictOLE(List<Model.MedIfTransDict> MedIfTransDict)
        {
            OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString);
            oleCisConn.Open();
            OleDbTransaction oleCisTrans = oleCisConn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                foreach (Model.MedIfTransDict OneMedIfTransDict in MedIfTransDict)
                {
                    OleDbParameter[] oneInert = GetParameterOLE("InsertMedIfTransDict");
                    if (OneMedIfTransDict.TransName != null)
                        oneInert[0].Value = OneMedIfTransDict.TransName;
                    else
                        oneInert[0].Value = DBNull.Value;
                    if (OneMedIfTransDict.Dbms != null)
                        oneInert[1].Value = OneMedIfTransDict.Dbms;
                    else
                        oneInert[1].Value = DBNull.Value;
                    if (OneMedIfTransDict.ServerName != null)
                        oneInert[2].Value = OneMedIfTransDict.ServerName;
                    else
                        oneInert[2].Value = DBNull.Value;
                    if (OneMedIfTransDict.Database != null)
                        oneInert[3].Value = OneMedIfTransDict.Database;
                    else
                        oneInert[3].Value = DBNull.Value;
                    if (OneMedIfTransDict.LogId != null)
                        oneInert[4].Value = OneMedIfTransDict.LogId;
                    else
                        oneInert[4].Value = DBNull.Value;
                    if (OneMedIfTransDict.LogPass != null)
                        oneInert[5].Value = OneMedIfTransDict.LogPass;
                    else
                        oneInert[5].Value = DBNull.Value;
                    if (OneMedIfTransDict.NlsLang != null)
                        oneInert[6].Value = OneMedIfTransDict.NlsLang;
                    else
                        oneInert[6].Value = DBNull.Value;
                    if (OneMedIfTransDict.Dbparm != null)
                        oneInert[7].Value = OneMedIfTransDict.Dbparm;
                    else
                        oneInert[7].Value = DBNull.Value;
                    if (OneMedIfTransDict.Memo != null)
                        oneInert[8].Value = OneMedIfTransDict.Memo;
                    else
                        oneInert[8].Value = DBNull.Value;

                    OleDbHelper.ExecuteNonQuery(oleCisTrans, CommandType.Text, Insert_MedIfTransDict_OLE, oneInert);
                }
                oleCisTrans.Commit();
            }
            catch (Exception ex)
            {
                oleCisTrans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                oleCisConn.Close();
            }
        }

        public int UpdateMedIfTransDictOLE(Model.MedIfTransDict MedIfTransDict)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedIfTransDict");

                if (MedIfTransDict.Dbms != null)
                    oneUpdate[0].Value = MedIfTransDict.Dbms;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (MedIfTransDict.ServerName != null)
                    oneUpdate[1].Value = MedIfTransDict.ServerName;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (MedIfTransDict.Database != null)
                    oneUpdate[2].Value = MedIfTransDict.Database;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (MedIfTransDict.LogId != null)
                    oneUpdate[3].Value = MedIfTransDict.LogId;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (MedIfTransDict.LogPass != null)
                    oneUpdate[4].Value = MedIfTransDict.LogPass;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (MedIfTransDict.NlsLang != null)
                    oneUpdate[5].Value = MedIfTransDict.NlsLang;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (MedIfTransDict.Dbparm != null)
                    oneUpdate[6].Value = MedIfTransDict.Dbparm;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (MedIfTransDict.Memo != null)
                    oneUpdate[7].Value = MedIfTransDict.Memo;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (MedIfTransDict.NlsLang != null)
                    oneUpdate[8].Value = MedIfTransDict.NlsLang;
                else
                    oneUpdate[8].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_MedIfTransDict_OLE, oneUpdate);
            }
        }

        public void UpdateMedIfTransDictOLE(List<Model.MedIfTransDict> MedIfTransDict)
        {

            OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString);
            oleCisConn.Open();
            OleDbTransaction oleCisTrans = oleCisConn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                foreach (Model.MedIfTransDict oneMedIfTransDict in MedIfTransDict)
                {
                    OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedIfTransDict");

                    if (oneMedIfTransDict.Dbms != null)
                        oneUpdate[0].Value = oneMedIfTransDict.Dbms;
                    else
                        oneUpdate[0].Value = DBNull.Value;
                    if (oneMedIfTransDict.ServerName != null)
                        oneUpdate[1].Value = oneMedIfTransDict.ServerName;
                    else
                        oneUpdate[1].Value = DBNull.Value;
                    if (oneMedIfTransDict.Database != null)
                        oneUpdate[2].Value = oneMedIfTransDict.Database;
                    else
                        oneUpdate[2].Value = DBNull.Value;
                    if (oneMedIfTransDict.LogId != null)
                        oneUpdate[3].Value = oneMedIfTransDict.LogId;
                    else
                        oneUpdate[3].Value = DBNull.Value;
                    if (oneMedIfTransDict.LogPass != null)
                        oneUpdate[4].Value = oneMedIfTransDict.LogPass;
                    else
                        oneUpdate[4].Value = DBNull.Value;
                    if (oneMedIfTransDict.NlsLang != null)
                        oneUpdate[5].Value = oneMedIfTransDict.NlsLang;
                    else
                        oneUpdate[5].Value = DBNull.Value;
                    if (oneMedIfTransDict.Dbparm != null)
                        oneUpdate[6].Value = oneMedIfTransDict.Dbparm;
                    else
                        oneUpdate[6].Value = DBNull.Value;
                    if (oneMedIfTransDict.Memo != null)
                        oneUpdate[7].Value = oneMedIfTransDict.Memo;
                    else
                        oneUpdate[7].Value = DBNull.Value;
                    if (oneMedIfTransDict.TransName != null)
                        oneUpdate[8].Value = oneMedIfTransDict.TransName;
                    else
                        oneUpdate[8].Value = DBNull.Value;

                    OleDbHelper.ExecuteNonQuery(oleCisTrans, CommandType.Text, Update_MedIfTransDict_OLE, oneUpdate);
                }
                oleCisTrans.Commit();
            }
            catch (Exception ex)
            {
                oleCisTrans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                oleCisConn.Close();
            }
        }

        public List<MedIfTransDict> SelectMedIfTransDictListOLE()
        {
            List<Model.MedIfTransDict> OneMedIfTransDictResult = null;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedIfTransDict_All, null))
            {
                if (oleReader.Read())
                {
                    MedIfTransDict OneMedIfTransDict = new Model.MedIfTransDict();
                    if (!oleReader.IsDBNull(0))
                        OneMedIfTransDict.TransName = oleReader.GetString(0);
                    
                    if (!oleReader.IsDBNull(2))
                        OneMedIfTransDict.ServerName = oleReader.GetString(2);
                    if (!oleReader.IsDBNull(3))
                        OneMedIfTransDict.Database = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        OneMedIfTransDict.LogId = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        OneMedIfTransDict.LogPass = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        OneMedIfTransDict.NlsLang = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        OneMedIfTransDict.Dbparm = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        OneMedIfTransDict.Memo = oleReader.GetString(8);

                    if (oleReader.GetString(1) == "SQLSERVER")
                        OneMedIfTransDict.Dbms = EnumDataBase.SQLSERVER;
                    else if (oleReader.GetString(1) == "ORACLE")
                        OneMedIfTransDict.Dbms = EnumDataBase.ORACLE;
                    else if (oleReader.GetString(1) == "ODBC")
                        OneMedIfTransDict.Dbms = EnumDataBase.ODBC;
                    else if (oleReader.GetString(1) == "OLEDB")
                        OneMedIfTransDict.Dbms = EnumDataBase.OLEDB;
                    else if (oleReader.GetString(1) == "MYSQL")
                        OneMedIfTransDict.Dbms = EnumDataBase.MYSQL;
                    else
                        OneMedIfTransDict.Dbms = EnumDataBase.Undefined;
                    OneMedIfTransDictResult.Add(OneMedIfTransDict);
                }
            
            }
            return OneMedIfTransDictResult;
        }

        private static readonly string Select_MedIfTransDict_Odbc = "select trans_name, dbms, server_name, database, log_id, log_pass, nls_lang, dbparm, memo from med_if_trans_dict WHERE trans_name = ? ";
        private static readonly string Insert_MedIfTransDict_Odbc = "insert into med_if_trans_dict(trans_name, dbms, server_name, database, log_id, log_pass, nls_lang, dbparm, memo) values(?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private static readonly string Update_MedIfTransDict_Odbc = "update med_if_trans_dict set dbms = ?, server_name = ?, database = ?, log_id = ?, log_pass = ?, nls_lang = ?, dbparm = ?, memo = ? where trans_name = ?";

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
                else if (sqlParms == "InsertMedIfTransDict")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("transName",OdbcType.VarChar),
                        new OdbcParameter("dbms",OdbcType.VarChar), 
                        new OdbcParameter("serverName",OdbcType.VarChar), 
                        new OdbcParameter("database",OdbcType.VarChar),
                        new OdbcParameter("logId",OdbcType.VarChar),
                        new OdbcParameter("logPass",OdbcType.VarChar),
                        new OdbcParameter("nlsLang",OdbcType.VarChar),
                        new OdbcParameter("dbparm",OdbcType.VarChar),
                        new OdbcParameter("memo",OdbcType.VarChar)
                    };
                }
                else if (sqlParms == "UpdateMedIfTransDict")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("dbms",OdbcType.VarChar), 
                        new OdbcParameter("serverName",OdbcType.VarChar), 
                        new OdbcParameter("database",OdbcType.VarChar),
                        new OdbcParameter("logId",OdbcType.VarChar),
                        new OdbcParameter("logPass",OdbcType.VarChar),
                        new OdbcParameter("nlsLang",OdbcType.VarChar),
                        new OdbcParameter("dbparm",OdbcType.VarChar),
                        new OdbcParameter("memo",OdbcType.VarChar),
                        new OdbcParameter("transName",OdbcType.VarChar)
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedIfTransDict SelectMedIfTransDictOdbc(string transName)
        {
            Model.MedIfTransDict OneMedIfTransDict = null;

            OdbcParameter[] paramHisUsers = GetParameterOdbc("SelectMedIfTransDict");
            paramHisUsers[0].Value = transName;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MedIfTransDict_Odbc, paramHisUsers))
            {
                if (OdbcReader.Read())
                {
                    OneMedIfTransDict = new Model.MedIfTransDict();
                    if (!OdbcReader.IsDBNull(0))
                        OneMedIfTransDict.TransName = OdbcReader.GetString(0);
                    //if (!OdbcReader.IsDBNull(2))
                    //    OneMedIfTransDict.Dbms = OdbcReader.GetString(1);
                    if (!OdbcReader.IsDBNull(2))
                        OneMedIfTransDict.ServerName = OdbcReader.GetString(2);
                    if (!OdbcReader.IsDBNull(3))
                        OneMedIfTransDict.Database = OdbcReader.GetString(3);
                    if (!OdbcReader.IsDBNull(4))
                        OneMedIfTransDict.LogId = OdbcReader.GetString(4);
                    if (!OdbcReader.IsDBNull(5))
                        OneMedIfTransDict.LogPass = OdbcReader.GetString(5);
                    if (!OdbcReader.IsDBNull(6))
                        OneMedIfTransDict.NlsLang = OdbcReader.GetString(6);
                    if (!OdbcReader.IsDBNull(7))
                        OneMedIfTransDict.Dbparm = OdbcReader.GetString(7);
                    if (!OdbcReader.IsDBNull(8))
                        OneMedIfTransDict.Memo = OdbcReader.GetString(8);
                }
                else
                    OneMedIfTransDict = null;
            }
            return OneMedIfTransDict;
        }

        public int InsertMedIfTransDictOdbc(Model.MedIfTransDict MedIfTransDict)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedIfTransDict");
                if (MedIfTransDict.TransName != null)
                    oneInert[0].Value = MedIfTransDict.TransName;
                else
                    oneInert[0].Value = DBNull.Value;
                if (MedIfTransDict.Dbms.ToString() != null)
                    oneInert[1].Value = MedIfTransDict.Dbms;
                else
                    oneInert[1].Value = DBNull.Value;
                if (MedIfTransDict.ServerName != null)
                    oneInert[2].Value = MedIfTransDict.ServerName;
                else
                    oneInert[2].Value = DBNull.Value;
                if (MedIfTransDict.Database != null)
                    oneInert[3].Value = MedIfTransDict.Database;
                else
                    oneInert[3].Value = DBNull.Value;
                if (MedIfTransDict.LogId != null)
                    oneInert[4].Value = MedIfTransDict.LogId;
                else
                    oneInert[4].Value = DBNull.Value;
                if (MedIfTransDict.LogPass != null)
                    oneInert[5].Value = MedIfTransDict.LogPass;
                else
                    oneInert[5].Value = DBNull.Value;
                if (MedIfTransDict.NlsLang != null)
                    oneInert[6].Value = MedIfTransDict.NlsLang;
                else
                    oneInert[6].Value = DBNull.Value;
                if (MedIfTransDict.Dbparm != null)
                    oneInert[7].Value = MedIfTransDict.Dbparm;
                else
                    oneInert[7].Value = DBNull.Value;
                if (MedIfTransDict.Memo != null)
                    oneInert[8].Value = MedIfTransDict.Memo;
                else
                    oneInert[8].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_MedIfTransDict_Odbc, oneInert);
            }
        }

        public void InsertMedIfTransDictOdbc(List<Model.MedIfTransDict> MedIfTransDict)
        {
            OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString);
            OdbcCisConn.Open();
            OdbcTransaction OdbcCisTrans = OdbcCisConn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                foreach (Model.MedIfTransDict OneMedIfTransDict in MedIfTransDict)
                {
                    OdbcParameter[] oneInert = GetParameterOdbc("InsertMedIfTransDict");
                    if (OneMedIfTransDict.TransName != null)
                        oneInert[0].Value = OneMedIfTransDict.TransName;
                    else
                        oneInert[0].Value = DBNull.Value;
                    if (OneMedIfTransDict.Dbms != null)
                        oneInert[1].Value = OneMedIfTransDict.Dbms;
                    else
                        oneInert[1].Value = DBNull.Value;
                    if (OneMedIfTransDict.ServerName != null)
                        oneInert[2].Value = OneMedIfTransDict.ServerName;
                    else
                        oneInert[2].Value = DBNull.Value;
                    if (OneMedIfTransDict.Database != null)
                        oneInert[3].Value = OneMedIfTransDict.Database;
                    else
                        oneInert[3].Value = DBNull.Value;
                    if (OneMedIfTransDict.LogId != null)
                        oneInert[4].Value = OneMedIfTransDict.LogId;
                    else
                        oneInert[4].Value = DBNull.Value;
                    if (OneMedIfTransDict.LogPass != null)
                        oneInert[5].Value = OneMedIfTransDict.LogPass;
                    else
                        oneInert[5].Value = DBNull.Value;
                    if (OneMedIfTransDict.NlsLang != null)
                        oneInert[6].Value = OneMedIfTransDict.NlsLang;
                    else
                        oneInert[6].Value = DBNull.Value;
                    if (OneMedIfTransDict.Dbparm != null)
                        oneInert[7].Value = OneMedIfTransDict.Dbparm;
                    else
                        oneInert[7].Value = DBNull.Value;
                    if (OneMedIfTransDict.Memo != null)
                        oneInert[8].Value = OneMedIfTransDict.Memo;
                    else
                        oneInert[8].Value = DBNull.Value;

                    OdbcHelper.ExecuteNonQuery(OdbcCisTrans, CommandType.Text, Insert_MedIfTransDict_Odbc, oneInert);
                }
                OdbcCisTrans.Commit();
            }
            catch (Exception ex)
            {
                OdbcCisTrans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                OdbcCisConn.Close();
            }
        }

        public int UpdateMedIfTransDictOdbc(Model.MedIfTransDict MedIfTransDict)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedIfTransDict");

                if (MedIfTransDict.Dbms != null)
                    oneUpdate[0].Value = MedIfTransDict.Dbms;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (MedIfTransDict.ServerName != null)
                    oneUpdate[1].Value = MedIfTransDict.ServerName;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (MedIfTransDict.Database != null)
                    oneUpdate[2].Value = MedIfTransDict.Database;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (MedIfTransDict.LogId != null)
                    oneUpdate[3].Value = MedIfTransDict.LogId;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (MedIfTransDict.LogPass != null)
                    oneUpdate[4].Value = MedIfTransDict.LogPass;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (MedIfTransDict.NlsLang != null)
                    oneUpdate[5].Value = MedIfTransDict.NlsLang;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (MedIfTransDict.Dbparm != null)
                    oneUpdate[6].Value = MedIfTransDict.Dbparm;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (MedIfTransDict.Memo != null)
                    oneUpdate[7].Value = MedIfTransDict.Memo;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (MedIfTransDict.TransName != null)
                    oneUpdate[8].Value = MedIfTransDict.TransName;
                else
                    oneUpdate[8].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_MedIfTransDict_Odbc, oneUpdate);
            }
        }

        public void UpdateMedIfTransDictOdbc(List<Model.MedIfTransDict> MedIfTransDict)
        {

            OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString);
            OdbcCisConn.Open();
            OdbcTransaction OdbcCisTrans = OdbcCisConn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                foreach (Model.MedIfTransDict oneMedIfTransDict in MedIfTransDict)
                {
                    OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedIfTransDict");

                    if (oneMedIfTransDict.Dbms != null)
                        oneUpdate[0].Value = oneMedIfTransDict.Dbms;
                    else
                        oneUpdate[0].Value = DBNull.Value;
                    if (oneMedIfTransDict.ServerName != null)
                        oneUpdate[1].Value = oneMedIfTransDict.ServerName;
                    else
                        oneUpdate[1].Value = DBNull.Value;
                    if (oneMedIfTransDict.Database != null)
                        oneUpdate[2].Value = oneMedIfTransDict.Database;
                    else
                        oneUpdate[2].Value = DBNull.Value;
                    if (oneMedIfTransDict.LogId != null)
                        oneUpdate[3].Value = oneMedIfTransDict.LogId;
                    else
                        oneUpdate[3].Value = DBNull.Value;
                    if (oneMedIfTransDict.LogPass != null)
                        oneUpdate[4].Value = oneMedIfTransDict.LogPass;
                    else
                        oneUpdate[4].Value = DBNull.Value;
                    if (oneMedIfTransDict.NlsLang != null)
                        oneUpdate[5].Value = oneMedIfTransDict.NlsLang;
                    else
                        oneUpdate[5].Value = DBNull.Value;
                    if (oneMedIfTransDict.Dbparm != null)
                        oneUpdate[6].Value = oneMedIfTransDict.Dbparm;
                    else
                        oneUpdate[6].Value = DBNull.Value;
                    if (oneMedIfTransDict.Memo != null)
                        oneUpdate[7].Value = oneMedIfTransDict.Memo;
                    else
                        oneUpdate[7].Value = DBNull.Value;
                    if (oneMedIfTransDict.TransName != null)
                        oneUpdate[8].Value = oneMedIfTransDict.TransName;
                    else
                        oneUpdate[8].Value = DBNull.Value;

                    OdbcHelper.ExecuteNonQuery(OdbcCisTrans, CommandType.Text, Update_MedIfTransDict_Odbc, oneUpdate);
                }
                OdbcCisTrans.Commit();
            }
            catch (Exception ex)
            {
                OdbcCisTrans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                OdbcCisConn.Close();
            }
        }
    }
}
