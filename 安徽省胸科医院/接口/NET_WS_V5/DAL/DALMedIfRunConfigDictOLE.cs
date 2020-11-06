using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.Odbc;

namespace MedicalSytem.Soft.DAL
{
    public partial class DALMedIfRunConfigDict
    {
        private static readonly string Select_MedIfRunConfigDict_OLE = "select app_class, section, main_key, key_value, memo from med_if_run_config_dict WHERE app_class = ? and section = ? and main_key =?";
        private static readonly string Insert_MedIfRunConfigDict_OLE = "insert into med_if_run_config_dict (app_class, section, main_key, key_value, memo) values (?, ?, ?, ?,?)";
        private static readonly string Update_MedIfRunConfigDict_OLE = "update med_if_run_config_dict set key_value = ?, memo = ? where app_class = ? and section = ? and main_key = ?";

        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedIfRunConfigDict")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("appClass",OleDbType.VarChar),
                        new OleDbParameter("section",OleDbType.VarChar),
                        new OleDbParameter("mainKey",OleDbType.VarChar)
                    };
                }
                else if (sqlParms == "InsertMedIfRunConfigDict")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("appClass",OleDbType.VarChar),
                        new OleDbParameter("section",OleDbType.VarChar), 
                        new OleDbParameter("mainKey",OleDbType.VarChar), 
                        new OleDbParameter("keyValue",OleDbType.VarChar),
                        new OleDbParameter("memo",OleDbType.VarChar)
                    };
                }
                else if (sqlParms == "UpdateMedIfRunConfigDict")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("keyValue",OleDbType.VarChar),
                        new OleDbParameter("memo",OleDbType.VarChar),
                        new OleDbParameter("appClass",OleDbType.VarChar),
                        new OleDbParameter("section",OleDbType.VarChar), 
                        new OleDbParameter("mainKey",OleDbType.VarChar)
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public MedicalSytem.Soft.Model.MedIfRunConfigDict SelectMedIfRunConfigDictOLE(string appClass, string section, string mainKey)
        {
            MedicalSytem.Soft.Model.MedIfRunConfigDict OneMedIfRunConfigDict = null;

            OleDbParameter[] paramHisUsers = GetParameterOLE("SelectMedIfRunConfigDict");
            paramHisUsers[0].Value = appClass;
            paramHisUsers[1].Value = section;
            paramHisUsers[2].Value = mainKey;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedIfRunConfigDict_OLE, paramHisUsers))
            {
                if (oleReader.Read())
                {
                    OneMedIfRunConfigDict = new MedicalSytem.Soft.Model.MedIfRunConfigDict();
                    if (!oleReader.IsDBNull(0))
                        OneMedIfRunConfigDict.AppClass = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        OneMedIfRunConfigDict.Section = oleReader.GetString(1);
                    if (!oleReader.IsDBNull(2))
                        OneMedIfRunConfigDict.MainKey = oleReader.GetString(2);
                    if (!oleReader.IsDBNull(3))
                        OneMedIfRunConfigDict.KeyValue = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        OneMedIfRunConfigDict.Memo = oleReader.GetString(4);
                }
                else
                    OneMedIfRunConfigDict = null;
            }
            return OneMedIfRunConfigDict;
        }

        public int InsertMedIfRunConfigDictOLE(MedicalSytem.Soft.Model.MedIfRunConfigDict MedIfRunConfigDict)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedIfRunConfigDict");
                if (MedIfRunConfigDict.AppClass != null)
                    oneInert[0].Value = MedIfRunConfigDict.AppClass;
                else
                    oneInert[0].Value = DBNull.Value;
                if (MedIfRunConfigDict.Section != null)
                    oneInert[1].Value = MedIfRunConfigDict.Section;
                else
                    oneInert[1].Value = DBNull.Value;
                if (MedIfRunConfigDict.MainKey != null)
                    oneInert[2].Value = MedIfRunConfigDict.MainKey;
                else
                    oneInert[2].Value = DBNull.Value;
                if (MedIfRunConfigDict.KeyValue != null)
                    oneInert[3].Value = MedIfRunConfigDict.KeyValue;
                else
                    oneInert[3].Value = DBNull.Value;
                if (MedIfRunConfigDict.Memo != null)
                    oneInert[4].Value = MedIfRunConfigDict.Memo;
                else
                    oneInert[4].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_MedIfRunConfigDict_OLE, oneInert);
            }
        }

        public int UpdateMedIfRunConfigDictOLE(MedicalSytem.Soft.Model.MedIfRunConfigDict MedIfRunConfigDict)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedIfRunConfigDict");

                if (MedIfRunConfigDict.KeyValue != null)
                    oneUpdate[0].Value = MedIfRunConfigDict.KeyValue;
                else
                    oneUpdate[0].Value = DBNull.Value;

                if (MedIfRunConfigDict.Memo != null)
                    oneUpdate[1].Value = MedIfRunConfigDict.Memo;
                else
                    oneUpdate[1].Value = DBNull.Value;

                if (MedIfRunConfigDict.AppClass != null)
                    oneUpdate[2].Value = MedIfRunConfigDict.AppClass;
                else
                    oneUpdate[2].Value = DBNull.Value;

                if (MedIfRunConfigDict.Section != null)
                    oneUpdate[3].Value = MedIfRunConfigDict.Section;
                else
                    oneUpdate[3].Value = DBNull.Value;

                if (MedIfRunConfigDict.MainKey != null)
                    oneUpdate[4].Value = MedIfRunConfigDict.MainKey;
                else
                    oneUpdate[4].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_MedIfRunConfigDict_OLE, oneUpdate);
            }
        }

        private static readonly string Select_MedIfRunConfigDict_Odbc = "select app_class, section, main_key, key_value, memo from med_if_run_config_dict WHERE app_class = ? and section = ? and main_key =?";
        private static readonly string Insert_MedIfRunConfigDict_Odbc = "insert into med_if_run_config_dict (app_class, section, main_key, key_value, memo) values (?, ?, ?, ?,?)";
        private static readonly string Update_MedIfRunConfigDict_Odbc = "update med_if_run_config_dict set key_value = ?, memo = ? where app_class = ? and section = ? and main_key = ?";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedIfRunConfigDict")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("appClass",OdbcType.VarChar),
                        new OdbcParameter("section",OdbcType.VarChar),
                        new OdbcParameter("mainKey",OdbcType.VarChar)
                    };
                }
                else if (sqlParms == "InsertMedIfRunConfigDict")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("appClass",OdbcType.VarChar),
                        new OdbcParameter("section",OdbcType.VarChar), 
                        new OdbcParameter("mainKey",OdbcType.VarChar), 
                        new OdbcParameter("keyValue",OdbcType.VarChar),
                        new OdbcParameter("memo",OdbcType.VarChar)
                    };
                }
                else if (sqlParms == "UpdateMedIfRunConfigDict")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("keyValue",OdbcType.VarChar),
                        new OdbcParameter("memo",OdbcType.VarChar),
                        new OdbcParameter("appClass",OdbcType.VarChar),
                        new OdbcParameter("section",OdbcType.VarChar), 
                        new OdbcParameter("mainKey",OdbcType.VarChar)
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public MedicalSytem.Soft.Model.MedIfRunConfigDict SelectMedIfRunConfigDictOdbc(string appClass, string section, string mainKey)
        {
            MedicalSytem.Soft.Model.MedIfRunConfigDict OneMedIfRunConfigDict = null;

            OdbcParameter[] paramHisUsers = GetParameterOdbc("SelectMedIfRunConfigDict");
            paramHisUsers[0].Value = appClass;
            paramHisUsers[1].Value = section;
            paramHisUsers[2].Value = mainKey;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MedIfRunConfigDict_Odbc, paramHisUsers))
            {
                if (OdbcReader.Read())
                {
                    OneMedIfRunConfigDict = new MedicalSytem.Soft.Model.MedIfRunConfigDict();
                    if (!OdbcReader.IsDBNull(0))
                        OneMedIfRunConfigDict.AppClass = OdbcReader.GetString(0);
                    if (!OdbcReader.IsDBNull(1))
                        OneMedIfRunConfigDict.Section = OdbcReader.GetString(1);
                    if (!OdbcReader.IsDBNull(2))
                        OneMedIfRunConfigDict.MainKey = OdbcReader.GetString(2);
                    if (!OdbcReader.IsDBNull(3))
                        OneMedIfRunConfigDict.KeyValue = OdbcReader.GetString(3);
                    if (!OdbcReader.IsDBNull(4))
                        OneMedIfRunConfigDict.Memo = OdbcReader.GetString(4);
                }
                else
                    OneMedIfRunConfigDict = null;
            }
            return OneMedIfRunConfigDict;
        }

        public int InsertMedIfRunConfigDictOdbc(MedicalSytem.Soft.Model.MedIfRunConfigDict MedIfRunConfigDict)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedIfRunConfigDict");
                if (MedIfRunConfigDict.AppClass != null)
                    oneInert[0].Value = MedIfRunConfigDict.AppClass;
                else
                    oneInert[0].Value = DBNull.Value;
                if (MedIfRunConfigDict.Section != null)
                    oneInert[1].Value = MedIfRunConfigDict.Section;
                else
                    oneInert[1].Value = DBNull.Value;
                if (MedIfRunConfigDict.MainKey != null)
                    oneInert[2].Value = MedIfRunConfigDict.MainKey;
                else
                    oneInert[2].Value = DBNull.Value;
                if (MedIfRunConfigDict.KeyValue != null)
                    oneInert[3].Value = MedIfRunConfigDict.KeyValue;
                else
                    oneInert[3].Value = DBNull.Value;
                if (MedIfRunConfigDict.Memo != null)
                    oneInert[4].Value = MedIfRunConfigDict.Memo;
                else
                    oneInert[4].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_MedIfRunConfigDict_Odbc, oneInert);
            }
        }

        public int UpdateMedIfRunConfigDictOdbc(MedicalSytem.Soft.Model.MedIfRunConfigDict MedIfRunConfigDict)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedIfRunConfigDict");

                if (MedIfRunConfigDict.KeyValue != null)
                    oneUpdate[0].Value = MedIfRunConfigDict.KeyValue;
                else
                    oneUpdate[0].Value = DBNull.Value;

                if (MedIfRunConfigDict.Memo != null)
                    oneUpdate[1].Value = MedIfRunConfigDict.Memo;
                else
                    oneUpdate[1].Value = DBNull.Value;

                if (MedIfRunConfigDict.AppClass != null)
                    oneUpdate[2].Value = MedIfRunConfigDict.AppClass;
                else
                    oneUpdate[2].Value = DBNull.Value;

                if (MedIfRunConfigDict.Section != null)
                    oneUpdate[3].Value = MedIfRunConfigDict.Section;
                else
                    oneUpdate[3].Value = DBNull.Value;

                if (MedIfRunConfigDict.MainKey != null)
                    oneUpdate[4].Value = MedIfRunConfigDict.MainKey;
                else
                    oneUpdate[4].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_MedIfRunConfigDict_Odbc, oneUpdate);
            }
        }
    }
}
