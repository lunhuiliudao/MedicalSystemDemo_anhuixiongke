using InitDocare;
using MedicalSytem.Soft.DAL;
using MedicalSytem.Soft.Model;
using NET_WS_V5;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace InitDocare
{
    public class Config2
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
            objCache.Remove("MedIfHisViewSql2");
        }

        #region    属性

        /// <summary>
        /// 手麻数据类型
        /// </summary>
        public EnumDataBase DocareDbType
        {
            get
            {
                if (dbtype == "ORACLE")
                {
                    return EnumDataBase.ORACLE;
                }
                else if (dbtype.IndexOf("SQLSERVER") >= 0)
                {
                    return EnumDataBase.SQLSERVER; ;
                }
                else if (dbtype.IndexOf("OLE") >= 0)
                {
                    return EnumDataBase.OLEDB;
                }
                else
                {
                    throw new  Exception("数据库类型未定义");
                }
            }
        }

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
        /// 根据功能点获取连接字符串
        /// </summary>
        /// <param name="medTableName"></param>
        /// <returns></returns>
        public List<MedIfHisViewSql2> SelectMedIfHisViewSql(string appCode)
        {
            return MedIfHisViewSqlList.FindAll(P => P.AppCode == appCode); //DICT101
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
        public List<MedIfHisViewSql2> MedIfHisViewSqlList
        {
            get
            {
                if (objCache.Get("MedIfHisViewSql2") == null)
                {
                    objCache.Insert("MedIfHisViewSql2", GetMedIfHisViewSql());
                    return GetMedIfHisViewSql();
                }
                else
                {
                    return objCache.Get("MedIfHisViewSql2") as List<MedIfHisViewSql2>;
                }
            }
        }

        /// <summary>
        /// 额外功能，不需要修改代码，能匹配实现,配置时候需要设置Memo1==1
        /// </summary>
        public List<MedIfHisViewSql2> MedIfHisViewSqlCommList
        {
            get
            {
                return MedIfHisViewSqlList.FindAll(P => P.Memo1 == "1"); //DICT101z
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

        public Config2()
        {

        }

        #region med_if_his_view_Sql
        public List<MedIfHisViewSql2> GetMedIfHisViewSql()
        {
            List<MedIfHisViewSql2> result = new List<MedIfHisViewSql2>();
            DataSet ds = new DataSet();
            string sqlselect = "select * from med_if_his_view_sql2";

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
                MedIfHisViewSql2 entity = new MedIfHisViewSql2();
                entity.AppCode = dr["App_Code"].ToString();
                entity.TransName = dr["Trans_Name"].ToString();
                entity.Description = dr["DESCRIPTION"].ToString();
                entity.DataSourceName = dr["Data_Source_Name"].ToString();
                entity.MedTableName = dr["MED_TABLE_NAME"].ToString();
                entity.SqlPara = dr["Sql_Para"].ToString();
                entity.SqlText = dr["Sql_Text"].ToString();
                entity.CommandType = dr["CommandType"].ToString();
                entity.Memo1 = dr["Memo1"].ToString();
                entity.Memo2 = dr["Memo2"].ToString();
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
            return result;
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

        public object obj
        {
            get;
            set;
        }
    }
}
