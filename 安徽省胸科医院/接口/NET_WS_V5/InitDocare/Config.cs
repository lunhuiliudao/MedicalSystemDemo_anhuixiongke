using System;
using System.Collections.Generic;
using System.Text;
using InitDocare;
using System.Data;
using MedicalSytem.Soft.DAL;
 

using System.Web;
using MedicalSytem.Soft.Model;

namespace MedicalSytem.Soft.InitDocare
{
    public class Config
    {
        string dbtype = PublicA.GetConfig("DataServerType").ToUpper();
        System.Web.Caching.Cache objCache = HttpRuntime.Cache;

        /// <summary>
        /// 清理缓存
        /// </summary>
        public void ClearCache()
        {
            objCache.Remove("MedInitDict");
            objCache.Remove("MedIfTransDict");
            objCache.Remove("MedIfHisViewSql");
            objCache.Remove("HIS");
            objCache.Remove("HIS_SECOND");
            objCache.Remove("LIS");
            objCache.Remove("LIS2");
            objCache.Remove("PACS");
            objCache.Remove("EMR");
            objCache.Remove("PIS");
            objCache.Remove("CSSD");
        }

        #region    属性

        /// <summary>
        /// 获取transDict 集合
        /// </summary>
        public List<MedIfTransDict> MedIfTransList
        {
            get
            {
                if (objCache.Get("MedIfTransDict") == null)
                {
                    objCache.Insert("MedIfTransDict", GetTransDict());
                    return GetTransDict();
                }
                else
                {
                    return objCache.Get("MedIfTransDict") as List<MedIfTransDict>;
                }
            }
        }

        /// <summary>
        /// 获取某单个MED_IF_HIS_VIEW_SQL
        /// </summary>
        /// <param name="medTableName"></param>
        /// <param name="dbmstype"></param>
        /// <returns></returns>
        public MedIfHisViewSql SelectMedIfHisViewSql(string medTableName, string dbmstype)
        {
            return MedIfHisViewSqlList.Find(P => P.MedTableName == medTableName && P.DBMSType == dbmstype);
        }

        /// <summary>
        /// 根据功能点获取连接字符串
        /// </summary>
        /// <param name="medTableName"></param>
        /// <returns></returns>
        public List<MedIfHisViewSql> SelectMedIfHisViewSql(string medTableName)
        {
            return MedIfHisViewSqlList.FindAll(P => P.MedTableName == medTableName);
        }

        /// <summary>
        /// 根据某个TransName 获取数据库连接属性
        /// </summary>
        /// <param name="transName"></param>
        /// <returns></returns>
        public MedIfTransDict SelectOneMedIfTransDict(string transName)
        {
            return MedIfTransList.Find(P => P.TransName == transName);
        }

        /// <summary>
        /// 获取HisViewSql
        /// </summary>
        public List<MedIfHisViewSql> MedIfHisViewSqlList
        {
            get
            {
                if (objCache.Get("MedIfHisViewSql") == null)
                {
                    objCache.Insert("MedIfHisViewSql", GetMedIfHisViewSql());
                    return GetMedIfHisViewSql();
                }
                else
                {
                    return objCache.Get("MedIfHisViewSql") as List<MedIfHisViewSql>;
                }
            }
        }

        /// <summary>
        /// 获取RunConfig
        /// </summary>
        public Dictionary<string, MedInitDict> DicMedInitDict
        {
            get
            {
                if (objCache.Get("MedInitDict") == null)
                {
                    objCache.Insert("objCache", GetRunConfig());
                    return GetRunConfig();
                }
                return GetRunConfig();
            }
        }

        /// <summary>
        /// 根据APP_CLASS 获取某单个runconfig
        /// </summary>
        /// <param name="appClass"></param>
        /// <returns></returns>
        public MedInitDict SelectOneMedInitDict(string appClass)
        {
            return DicMedInitDict[appClass];
        }

        #endregion

        public Config()
        {

        }

        #region med_if_his_view_Sql
        public List<MedIfHisViewSql> GetMedIfHisViewSql()
        {
            List<MedIfHisViewSql> result = new List<MedIfHisViewSql>();
            DataSet ds = new DataSet();
            string sqlselect = "select * from med_if_his_view_sql";

            if (dbtype == "ORACLE")
            {
                ds =  OracleHelper.GetDataSet(OracleHelper.ConnectionString, CommandType.Text, sqlselect, null);
            }
            else if (dbtype.IndexOf("SQLSERVER") >= 0)
            {
                ds = SqlHelper.GetDataSet(SqlHelper.ConnectionString, CommandType.Text, sqlselect, null);
            }
            else if (dbtype.IndexOf("OLE") >= 0)
            {
                ds = OleDbHelper.GetDataSet(OleDbHelper.ConnectionString, CommandType.Text, sqlselect, null);
            }
            if (ds == null || ds.Tables.Count == 0)
            {
                return result;
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MedIfHisViewSql entity = new MedIfHisViewSql();
                entity.Commandtype = dr["COMMAND_TYPE"].ToString();
                entity.DBMSType = dr["DBMS_TYPE"].ToString();
                entity.Description = dr["DESCRIPTION"].ToString();
                entity.HisTableName = dr["HIS_TABLE_NAME"].ToString();
                entity.MedTableName = dr["MED_TABLE_NAME"].ToString();
                entity.ParaCode = dr["PARA_CODE"].ToString();
                entity.SqlText = dr["SQL_TEXT"].ToString();
                entity.SqlType = dr["SQL_TYPE"].ToString();
                result.Add(entity);
            }
            return result;
        }


        #endregion

        #region med_if_trans_dict

        private List<MedIfTransDict> GetTransDict()
        {
            List<MedIfTransDict> result = new List<MedIfTransDict>();
            string sqlselect = "select * from med_if_trans_dict";
            DataSet ds = new DataSet();
            if (dbtype == "ORACLE")
            {
                ds = OracleHelper.GetDataSet(OracleHelper.ConnectionString, CommandType.Text, sqlselect, null);
            }
            else if (dbtype.IndexOf("SQLSERVER") >= 0)
            {
                ds = SqlHelper.GetDataSet(SqlHelper.ConnectionString, CommandType.Text, sqlselect, null);
            }
            else if (dbtype.IndexOf("OLE") >= 0)
            {
                ds = OleDbHelper.GetDataSet(OleDbHelper.ConnectionString, CommandType.Text, sqlselect, null);
            }
            if (ds == null || ds.Tables.Count == 0)
            {
                return result;
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MedIfTransDict entity = new MedIfTransDict();
                entity.Database = dr["DATABASE"].ToString();
                if (dr["DBMS"].ToString().ToUpper() == "ORACLE")
                {
                    entity.Dbms = EnumDataBase.ORACLE;
                }
                else if (dr["DBMS"].ToString().ToUpper() == "OLEDB")
                {
                    entity.Dbms = EnumDataBase.OLEDB;
                }
                else if (dr["DBMS"].ToString().ToUpper() == "SQLSERVER")
                {
                    entity.Dbms = EnumDataBase.SQLSERVER;
                }
                else if (dr["DBMS"].ToString().ToUpper() == "ODBC")
                {
                    entity.Dbms = EnumDataBase.ODBC;
                }
                else
                {
                    entity.Dbms = EnumDataBase.Undefined;
                }
                entity.Dbparm = dr["DBPARM"].ToString();
                entity.LogId = dr["LOG_ID"].ToString();
                entity.LogPass = dr["LOG_PASS"].ToString();
                entity.Memo = dr["MEMO"].ToString();
                entity.NlsLang = dr["NLS_LANG"].ToString();
                entity.ServerName = dr["SERVER_NAME"].ToString();
                entity.TransName = dr["TRANS_NAME"].ToString();
                result.Add(entity);
            }
            foreach (MedIfTransDict entity in result)
            {
                if (entity.TransName == "HIS")
                {
                    objCache.Insert("HIS", entity.NlsLang);
                }
                else if (entity.TransName == "HIS_SECOND")
                {
                    objCache.Insert("HIS_SECOND", entity.NlsLang);
                }
                else if (entity.TransName == "LIS")
                {
                    objCache.Insert("LIS", entity.NlsLang);
                }
                else if (entity.TransName == "LIS2")
                {
                    objCache.Insert("LIS2", entity.NlsLang);
                }
                else if (entity.TransName == "PACS")
                {
                    objCache.Insert("PACS", entity.NlsLang);
                }
                else if (entity.TransName == "PIS")
                {
                    objCache.Insert("PIS", entity.NlsLang);
                }
                else if (entity.TransName == "EMR")
                {
                    objCache.Insert("EMR", entity.NlsLang);
                }
                else if (entity.TransName == "CSSD")
                {
                    objCache.Insert("CSSD", entity.NlsLang);
                }
            }
            return result;
        }


        public string HisConnection
        {
            get
            {
                if (objCache.Get("HisConnection") == null)
                {
                    GetTransDict();
                    return objCache.Get("HisConnection") as string;
                }
                return objCache.Get("HisConnection") as string;
            }
        }

        public string HisConnection2
        {
            get
            {
                if (objCache.Get("HIS_SECOND") == null)
                {
                    GetTransDict();
                    return objCache.Get("HIS_SECOND") as string;
                }
                return objCache.Get("HIS_SECOND") as string;
            }
        }

        public string LisConnection
        {

            get
            {
                if (objCache.Get("LIS") == null)
                {
                    GetTransDict();
                    return objCache.Get("LIS") as string;
                }
                return objCache.Get("LIS") as string;
            }
        }

        public string LisConnection2
        {
            get
            {
                if (objCache.Get("LIS2") == null)
                {
                    GetTransDict();
                    return objCache.Get("LIS2") as string;
                }
                return objCache.Get("LIS2") as string;
            }
        }

        public string PacsConnection
        {
            get
            {
                if (objCache.Get("PACS") == null)
                {
                    GetTransDict();
                    return objCache.Get("PACS") as string;
                }
                return objCache.Get("PACS") as string;
            }
        }

        public string PisConnection
        {
            get
            {
                if (objCache.Get("PIS") == null)
                {
                    GetTransDict();
                    return objCache.Get("PIS") as string;
                }
                return objCache.Get("PIS") as string;
            }
        }
        public string CssdConnection
        {
            get
            {
                if (objCache.Get("CSSD") == null)
                {
                    GetTransDict();
                    return objCache.Get("CSSD") as string;
                }
                return objCache.Get("CSSD") as string;
            }
        }

        public string EmrConnection
        {
            get
            {
                if (objCache.Get("EMR") == null)
                {
                    GetTransDict();
                    return objCache.Get("EMR") as string;
                }
                return objCache.Get("EMR") as string;
            }
        }

        #endregion

        #region med_if_run_config

        /// <summary>
        /// string 系统类别
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, MedInitDict> GetRunConfig()
        {
            Dictionary<string, MedInitDict> dic = new Dictionary<string, MedInitDict>();

            string sqlselect = "select med_if_run_config_dict";
            DataSet ds = new DataSet();
            if (dbtype == "ORACLE")
            {
                ds = OracleHelper.GetDataSet(OracleHelper.ConnectionString, CommandType.Text, sqlselect, null);
            }
            else if (dbtype.IndexOf("SQLSERVER") >= 0)
            {
                ds = SqlHelper.GetDataSet(SqlHelper.ConnectionString, CommandType.Text, sqlselect, null);
            }
            else if (dbtype.IndexOf("OLE") >= 0)
            {
                ds = OleDbHelper.GetDataSet(OleDbHelper.ConnectionString, CommandType.Text, sqlselect, null);
            }
            if (ds == null || ds.Tables.Count == 0)
            {
                return null;
            }

            DataView dv = ds.Tables[0].DefaultView;
            DataTable dataTableDistinct = dv.ToTable(true, "APP_CLASS");

            var v = from r in dataTableDistinct.AsEnumerable() select r.Field<string>("APP_CLASS");

            foreach (string str in v)
            {
                MedInitDict medIfTransDict = new MedInitDict();
                var temp = from r in ds.Tables[0].AsEnumerable().Where(P => P.Field<string>("APP_CLASS") == str) select r;
                foreach (DataRow dr in temp)
                {
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "HISSUPPLY")
                        medIfTransDict.DoCareHisSupply = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "PERFORMEDCODE")
                        medIfTransDict.DoCarePerformedcode = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "REFRESHTIME")
                        medIfTransDict.DoCareRefreshtime = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "ISTRANSFER")
                        medIfTransDict.DoCareIsTransfer = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "ISORDERS")
                        medIfTransDict.DoCareIsOrders = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "ISLABRESULT")
                        medIfTransDict.DoCareIsLabResult = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "ISEMR")
                        medIfTransDict.DoCareIsEmr = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "ISEXAMREPORT")
                        medIfTransDict.DoCareIsExamReport = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "ISEXAMREPORTDICOM")
                        medIfTransDict.DoCareIsExamReportDicom = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "DAYNUM")
                        medIfTransDict.DoCareDayNum = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "ISCHARGE")
                        medIfTransDict.DoCareIsCharge = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "ISELEAUTO")
                        medIfTransDict.DoCareEleAuto = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "FORUSERID")
                        medIfTransDict.DoCareForUserId = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "FORPASSWORD")
                        medIfTransDict.DoCareForPassWord = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "OPERMASTER")
                        medIfTransDict.DoCareOperMaster = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "ISOPERSCHEDULETOHIS")
                        medIfTransDict.DoCareIsOperCheduleToHis = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "ISOPERMASTERTOHIS")
                        medIfTransDict.DoCareIsOperMasterToHis = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "ISOPERSTATUSTOHIS")
                        medIfTransDict.DoCareIsOperStatusToHis = dr["KEY_VALUE"].ToString();
                    if (dr["MAIN_KEY"].ToString().ToUpper() == "ISLOG")
                        medIfTransDict.IsLog = dr["KEY_VALUE"].ToString();
                }
                dic.Add(str, medIfTransDict);
            }
            return dic;
        }
         #endregion
    }
}
