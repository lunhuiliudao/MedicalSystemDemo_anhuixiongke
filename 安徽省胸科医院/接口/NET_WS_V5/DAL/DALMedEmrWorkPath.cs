

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010-08-13 10:02:08
 * 
 * Notes:
 * 
* ******************************************************************/

using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data.OracleClient;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedEmrWorkPath
	/// </summary>

    public partial class DALMedEmrWorkPath
    {
        private static readonly string MED_EMR_WORK_PATH_Insert_SQL = "INSERT INTO MED_EMR_WORK_PATH (APPLICATION,EMR_PATH,USER_NAME,USER_PWD,IP_ADDR) values (@Application,@EmrPath,@UserName,@UserPwd,@IpAddr)";
        private static readonly string MED_EMR_WORK_PATH_Update_SQL = "UPDATE MED_EMR_WORK_PATH SET APPLICATION=@Application,EMR_PATH=@EmrPath,USER_NAME=@UserName,USER_PWD=@UserPwd,IP_ADDR=@IpAddr WHERE  APPLICATION=@Application AND EMR_PATH=@EmrPath";
        private static readonly string MED_EMR_WORK_PATH_Delete_SQL = "DELETE MED_EMR_WORK_PATH WHERE  APPLICATION=@Application AND EMR_PATH=@EmrPath";
        private static readonly string MED_EMR_WORK_PATH_Select_SQL = "SELECT APPLICATION,EMR_PATH,USER_NAME,USER_PWD,IP_ADDR FROM MED_EMR_WORK_PATH where  APPLICATION=@Application AND EMR_PATH=@EmrPath";
        private static readonly string MED_EMR_WORK_PATH_Select_Application_SQL = "SELECT APPLICATION,EMR_PATH,USER_NAME,USER_PWD,IP_ADDR FROM MED_EMR_WORK_PATH where  APPLICATION=@Application";
        private static readonly string MED_EMR_WORK_PATH_Select_ALL_SQL = "SELECT APPLICATION,EMR_PATH,USER_NAME,USER_PWD,IP_ADDR FROM MED_EMR_WORK_PATH";
        private static readonly string MED_EMR_WORK_PATH_Insert = "INSERT INTO MED_EMR_WORK_PATH (APPLICATION,EMR_PATH,USER_NAME,USER_PWD,IP_ADDR) values (:Application,:EmrPath,:UserName,:UserPwd,:IpAddr)";
        private static readonly string MED_EMR_WORK_PATH_Update = "UPDATE MED_EMR_WORK_PATH SET APPLICATION=:Application,EMR_PATH=:EmrPath,USER_NAME=:UserName,USER_PWD=:UserPwd,IP_ADDR=:IpAddr WHERE  APPLICATION=:Application AND EMR_PATH=:EmrPath";
        private static readonly string MED_EMR_WORK_PATH_Delete = "DELETE MED_EMR_WORK_PATH WHERE  APPLICATION=:Application AND EMR_PATH=:EmrPath";
        private static readonly string MED_EMR_WORK_PATH_Select = "SELECT APPLICATION,EMR_PATH,USER_NAME,USER_PWD,IP_ADDR FROM MED_EMR_WORK_PATH where  APPLICATION=:Application AND EMR_PATH=:EmrPath";
        private static readonly string MED_EMR_WORK_PATH_Select_Application = "SELECT APPLICATION,EMR_PATH,USER_NAME,USER_PWD,IP_ADDR FROM MED_EMR_WORK_PATH where  APPLICATION=:Application";
        private static readonly string MED_EMR_WORK_PATH_Select_ALL = "SELECT APPLICATION,EMR_PATH,USER_NAME,USER_PWD,IP_ADDR FROM MED_EMR_WORK_PATH";

        public DALMedEmrWorkPath()
        {
        }

        #region [获取参数SQL]
        /// <summary>
        ///获取参数MedEmrWorkPath SQL
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedEmrWorkPath")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@Application",SqlDbType.VarChar),
							new SqlParameter("@EmrPath",SqlDbType.VarChar),
							new SqlParameter("@UserName",SqlDbType.VarChar),
							new SqlParameter("@UserPwd",SqlDbType.VarChar),
							new SqlParameter("@IpAddr",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedEmrWorkPath")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@Application",SqlDbType.VarChar),
							new SqlParameter("@EmrPath",SqlDbType.VarChar),
							new SqlParameter("@UserName",SqlDbType.VarChar),
							new SqlParameter("@UserPwd",SqlDbType.VarChar),
							new SqlParameter("@IpAddr",SqlDbType.VarChar),
							new SqlParameter("@Application",SqlDbType.VarChar),
							new SqlParameter("@EmrPath",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedEmrWorkPath")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@Application",SqlDbType.VarChar),
							new SqlParameter("@EmrPath",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrWorkPath")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@Application",SqlDbType.VarChar),
							new SqlParameter("@EmrPath",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrWorkPathApplication")
                {
                    parms = new SqlParameter[]{
							new SqlParameter(":Application",SqlDbType.VarChar),
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedEmrWorkPath 
        ///Insert Table MED_EMR_WORK_PATH
        /// </summary>
        public int InsertMedEmrWorkPathSQL(MedEmrWorkPath model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedEmrWorkPath");
                if (model.Application != null)
                    oneInert[0].Value = model.Application;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.EmrPath != null)
                    oneInert[1].Value = model.EmrPath;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.UserName != null)
                    oneInert[2].Value = model.UserName;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.UserPwd != null)
                    oneInert[3].Value = model.UserPwd;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.IpAddr != null)
                    oneInert[4].Value = model.IpAddr;
                else
                    oneInert[4].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_EMR_WORK_PATH_Insert_SQL, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedEmrWorkPath 
        ///Update Table     MED_EMR_WORK_PATH
        /// </summary>
        public int UpdateMedEmrWorkPathSQL(MedEmrWorkPath model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedEmrWorkPath");
                if (model.Application != null)
                    oneUpdate[0].Value = model.Application;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.EmrPath != null)
                    oneUpdate[1].Value = model.EmrPath;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.UserName != null)
                    oneUpdate[2].Value = model.UserName;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.UserPwd != null)
                    oneUpdate[3].Value = model.UserPwd;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.IpAddr != null)
                    oneUpdate[4].Value = model.IpAddr;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.Application != null)
                    oneUpdate[5].Value = model.Application;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.EmrPath != null)
                    oneUpdate[6].Value = model.EmrPath;
                else
                    oneUpdate[6].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_EMR_WORK_PATH_Update_SQL, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedEmrWorkPath 
        ///Delete Table MED_EMR_WORK_PATH by (string APPLICATION,string EMR_PATH)
        /// </summary>
        public int DeleteMedEmrWorkPathSQL(string APPLICATION, string EMR_PATH)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneDelete = GetParameterSQL("DeleteMedEmrWorkPath");
                if (APPLICATION != null)
                    oneDelete[0].Value = APPLICATION;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (EMR_PATH != null)
                    oneDelete[1].Value = EMR_PATH;
                else
                    oneDelete[1].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_EMR_WORK_PATH_Delete_SQL, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedEmrWorkPath 
        ///select Table MED_EMR_WORK_PATH by (string APPLICATION,string EMR_PATH)
        /// </summary>
        public MedEmrWorkPath SelectMedEmrWorkPathSQL(string APPLICATION, string EMR_PATH)
        {
            MedEmrWorkPath model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedEmrWorkPath");
            parameterValues[0].Value = APPLICATION;
            parameterValues[1].Value = EMR_PATH;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_EMR_WORK_PATH_Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedEmrWorkPath();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.Application = oleReader["APPLICATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.EmrPath = oleReader["EMR_PATH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.UserPwd = oleReader["USER_PWD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.IpAddr = oleReader["IP_ADDR"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        #region  [获取一条记录SQL 入参APPLICATION]
        /// <summary>
        ///Select    model  MedEmrWorkPath 
        ///select Table MED_EMR_WORK_PATH by (string APPLICATION)
        /// </summary>
        public MedEmrWorkPath SelectMedEmrWorkPathSQL(string APPLICATION)
        {
            MedEmrWorkPath model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedEmrWorkPathApplication");
            parameterValues[0].Value = APPLICATION;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_EMR_WORK_PATH_Select_Application_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedEmrWorkPath();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.Application = oleReader["APPLICATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.EmrPath = oleReader["EMR_PATH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.UserPwd = oleReader["USER_PWD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.IpAddr = oleReader["IP_ADDR"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        #region  [获取所有记录SQL]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedEmrWorkPath> SelectMedEmrWorkPathListSQL()
        {
            List<MedEmrWorkPath> modelList = new List<MedEmrWorkPath>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_EMR_WORK_PATH_Select_ALL_SQL, null))
            {
                while (oleReader.Read())
                {
                    MedEmrWorkPath model = new MedEmrWorkPath();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.Application = oleReader["APPLICATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.EmrPath = oleReader["EMR_PATH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.UserPwd = oleReader["USER_PWD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.IpAddr = oleReader["IP_ADDR"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region [获取参数]
        /// <summary>
        ///获取参数MedEmrWorkPath
        /// </summary>
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedEmrWorkPath")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":Application",OracleType.VarChar),
							new OracleParameter(":EmrPath",OracleType.VarChar),
							new OracleParameter(":UserName",OracleType.VarChar),
							new OracleParameter(":UserPwd",OracleType.VarChar),
							new OracleParameter(":IpAddr",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedEmrWorkPath")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":Application",OracleType.VarChar),
							new OracleParameter(":EmrPath",OracleType.VarChar),
							new OracleParameter(":UserName",OracleType.VarChar),
							new OracleParameter(":UserPwd",OracleType.VarChar),
							new OracleParameter(":IpAddr",OracleType.VarChar),
							new OracleParameter(":Application",OracleType.VarChar),
							new OracleParameter(":EmrPath",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedEmrWorkPath")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":Application",OracleType.VarChar),
							new OracleParameter(":EmrPath",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrWorkPath")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":Application",OracleType.VarChar),
							new OracleParameter(":EmrPath",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrWorkPathApplication")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":Application",OracleType.VarChar),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedEmrWorkPath 
        ///Insert Table MED_EMR_WORK_PATH
        /// </summary>
        public int InsertMedEmrWorkPath(MedEmrWorkPath model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedEmrWorkPath");
                if (model.Application != null)
                    oneInert[0].Value = model.Application;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.EmrPath != null)
                    oneInert[1].Value = model.EmrPath;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.UserName != null)
                    oneInert[2].Value = model.UserName;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.UserPwd != null)
                    oneInert[3].Value = model.UserPwd;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.IpAddr != null)
                    oneInert[4].Value = model.IpAddr;
                else
                    oneInert[4].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_EMR_WORK_PATH_Insert, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedEmrWorkPath 
        ///Update Table     MED_EMR_WORK_PATH
        /// </summary>
        public int UpdateMedEmrWorkPath(MedEmrWorkPath model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedEmrWorkPath");
                if (model.Application != null)
                    oneUpdate[0].Value = model.Application;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.EmrPath != null)
                    oneUpdate[1].Value = model.EmrPath;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.UserName != null)
                    oneUpdate[2].Value = model.UserName;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.UserPwd != null)
                    oneUpdate[3].Value = model.UserPwd;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.IpAddr != null)
                    oneUpdate[4].Value = model.IpAddr;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.Application != null)
                    oneUpdate[5].Value = model.Application;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.EmrPath != null)
                    oneUpdate[6].Value = model.EmrPath;
                else
                    oneUpdate[6].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_EMR_WORK_PATH_Update, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedEmrWorkPath 
        ///Delete Table MED_EMR_WORK_PATH by (string APPLICATION,string EMR_PATH)
        /// </summary>
        public int DeleteMedEmrWorkPath(string APPLICATION, string EMR_PATH)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneDelete = GetParameter("DeleteMedEmrWorkPath");
                if (APPLICATION != null)
                    oneDelete[0].Value = APPLICATION;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (EMR_PATH != null)
                    oneDelete[1].Value = EMR_PATH;
                else
                    oneDelete[1].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_EMR_WORK_PATH_Delete, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedEmrWorkPath 
        ///select Table MED_EMR_WORK_PATH by (string APPLICATION,string EMR_PATH)
        /// </summary>
        public MedEmrWorkPath SelectMedEmrWorkPath(string APPLICATION, string EMR_PATH)
        {
            MedEmrWorkPath model;
            OracleParameter[] parameterValues = GetParameter("SelectMedEmrWorkPath");
            parameterValues[0].Value = APPLICATION;
            parameterValues[1].Value = EMR_PATH;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_EMR_WORK_PATH_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedEmrWorkPath();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.Application = oleReader["APPLICATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.EmrPath = oleReader["EMR_PATH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.UserPwd = oleReader["USER_PWD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.IpAddr = oleReader["IP_ADDR"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        #region  [获取一条记录 入参APPLICATION]
        /// <summary>
        ///Select    model  MedEmrWorkPath 
        ///select Table MED_EMR_WORK_PATH by (string APPLICATION)
        /// </summary>
        public MedEmrWorkPath SelectMedEmrWorkPath(string APPLICATION)
        {
            MedEmrWorkPath model;
            OracleParameter[] parameterValues = GetParameter("SelectMedEmrWorkPathApplication");
            parameterValues[0].Value = APPLICATION;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_EMR_WORK_PATH_Select_Application, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedEmrWorkPath();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.Application = oleReader["APPLICATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.EmrPath = oleReader["EMR_PATH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.UserPwd = oleReader["USER_PWD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.IpAddr = oleReader["IP_ADDR"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        #region  [获取所有记录]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedEmrWorkPath> SelectMedEmrWorkPathList()
        {
            List<MedEmrWorkPath> modelList = new List<MedEmrWorkPath>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_EMR_WORK_PATH_Select_ALL, null))
            {
                while (oleReader.Read())
                {
                    MedEmrWorkPath model = new MedEmrWorkPath();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.Application = oleReader["APPLICATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.EmrPath = oleReader["EMR_PATH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.UserPwd = oleReader["USER_PWD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.IpAddr = oleReader["IP_ADDR"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

    }
}
