

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
using System.Data.Odbc;
using System.Data.OleDb;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedEmrWorkPath
	/// </summary>
	
	public partial class DALMedEmrWorkPath
	{
        private static readonly string MED_EMR_WORK_PATH_Insert_OLE = "INSERT INTO MED_EMR_WORK_PATH (APPLICATION,EMR_PATH,USER_NAME,USER_PWD,IP_ADDR) values ( ?, ?, ?, ?, ?)";
        private static readonly string MED_EMR_WORK_PATH_Update_OLE = "UPDATE MED_EMR_WORK_PATH SET APPLICATION= ?,EMR_PATH= ?,USER_NAME= ?,USER_PWD= ?,IP_ADDR= ? WHERE  APPLICATION= ? AND EMR_PATH= ?";
        private static readonly string MED_EMR_WORK_PATH_Select_OLE = "SELECT APPLICATION,EMR_PATH,USER_NAME,USER_PWD,IP_ADDR FROM MED_EMR_WORK_PATH where  APPLICATION= ? AND EMR_PATH= ?";
        private static readonly string MED_EMR_WORK_PATH_Select_Application_OLE = "SELECT APPLICATION,EMR_PATH,USER_NAME,USER_PWD,IP_ADDR FROM MED_EMR_WORK_PATH where  APPLICATION= ?";

		#region [获取参数OLE]
		/// <summary>
		///获取参数MedEmrWorkPath SQL
		/// </summary>
		public static OleDbParameter[] GetParameterOLE(string sqlParms)
		{
			OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedEmrWorkPath")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("@Application",OleDbType.VarChar),
							new OleDbParameter("@EmrPath",OleDbType.VarChar),
							new OleDbParameter("@UserName",OleDbType.VarChar),
							new OleDbParameter("@UserPwd",OleDbType.VarChar),
							new OleDbParameter("@IpAddr",OleDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedEmrWorkPath")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("@Application",OleDbType.VarChar),
							new OleDbParameter("@EmrPath",OleDbType.VarChar),
							new OleDbParameter("@UserName",OleDbType.VarChar),
							new OleDbParameter("@UserPwd",OleDbType.VarChar),
							new OleDbParameter("@IpAddr",OleDbType.VarChar),
							new OleDbParameter("@Application",OleDbType.VarChar),
							new OleDbParameter("@EmrPath",OleDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedEmrWorkPath")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("@Application",OleDbType.VarChar),
							new OleDbParameter("@EmrPath",OleDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedEmrWorkPath")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("@Application",OleDbType.VarChar),
							new OleDbParameter("@EmrPath",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrWorkPathApplication")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter(":Application",OleDbType.VarChar),
                    };
                }
            	OleDbHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录OLE]
		/// <summary>
		///Add    model  MedEmrWorkPath 
		///Insert Table MED_EMR_WORK_PATH
		/// </summary>
		public int InsertMedEmrWorkPathOLE(MedEmrWorkPath model)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
				OleDbParameter[] oneInert = GetParameterOLE("InsertMedEmrWorkPath");
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

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_EMR_WORK_PATH_Insert_OLE, oneInert);
			}
		}
		#endregion
		#region [更新一条记录OLE]
		/// <summary>
		///Update    model  MedEmrWorkPath 
		///Update Table     MED_EMR_WORK_PATH
		/// </summary>
        public int UpdateMedEmrWorkPathOLE(MedEmrWorkPath model)
		{
			using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
				OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedEmrWorkPath");
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
						oneUpdate[5].Value =model.Application;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.EmrPath != null)
						oneUpdate[6].Value =model.EmrPath;
					else
						oneUpdate[6].Value = DBNull.Value;
			
				return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_EMR_WORK_PATH_Update_OLE, oneUpdate);
			}
		}
		#endregion	
        
		#region  [获取一条记录OLE]
		/// <summary>
		///Select    model  MedEmrWorkPath 
		///select Table MED_EMR_WORK_PATH by (string APPLICATION,string EMR_PATH)
		/// </summary>
        public MedEmrWorkPath SelectMedEmrWorkPathOLE(string APPLICATION, string EMR_PATH)
		{
			MedEmrWorkPath model;
			OleDbParameter[] parameterValues = GetParameterOLE("SelectMedEmrWorkPath");
			parameterValues[0].Value=APPLICATION;
			parameterValues[1].Value=EMR_PATH;
			using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_EMR_WORK_PATH_Select_OLE, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedEmrWorkPath();
						if (!oleReader.IsDBNull(0))
						{
							model.Application = oleReader["APPLICATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.EmrPath = oleReader["EMR_PATH"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.UserName = oleReader["USER_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.UserPwd = oleReader["USER_PWD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.IpAddr = oleReader["IP_ADDR"].ToString().Trim() ;
						}
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
        #region  [获取一条记录OLE 入参APPLICATION]
        /// <summary>
        ///Select    model  MedEmrWorkPath 
        ///select Table MED_EMR_WORK_PATH by (string APPLICATION)
        /// </summary>
        public MedEmrWorkPath SelectMedEmrWorkPathOLE(string APPLICATION)
        {
            MedEmrWorkPath model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedEmrWorkPathApplication");
            parameterValues[0].Value = APPLICATION;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_EMR_WORK_PATH_Select_Application_OLE, parameterValues))
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

        private static readonly string MED_EMR_WORK_PATH_Insert_Odbc = "INSERT INTO MED_EMR_WORK_PATH (APPLICATION,EMR_PATH,USER_NAME,USER_PWD,IP_ADDR) values ( ?, ?, ?, ?, ?)";
        private static readonly string MED_EMR_WORK_PATH_Update_Odbc = "UPDATE MED_EMR_WORK_PATH SET APPLICATION= ?,EMR_PATH= ?,USER_NAME= ?,USER_PWD= ?,IP_ADDR= ? WHERE  APPLICATION= ? AND EMR_PATH= ?";
        private static readonly string MED_EMR_WORK_PATH_Select_Odbc = "SELECT APPLICATION,EMR_PATH,USER_NAME,USER_PWD,IP_ADDR FROM MED_EMR_WORK_PATH where  APPLICATION= ? AND EMR_PATH= ?";
        private static readonly string MED_EMR_WORK_PATH_Select_Application_Odbc = "SELECT APPLICATION,EMR_PATH,USER_NAME,USER_PWD,IP_ADDR FROM MED_EMR_WORK_PATH where  APPLICATION= ?";

        #region [获取参数Odbc]
        /// <summary>
        ///获取参数MedEmrWorkPath SQL
        /// </summary>
        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedEmrWorkPath")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("Application",OdbcType.VarChar),
							new OdbcParameter("EmrPath",OdbcType.VarChar),
							new OdbcParameter("UserName",OdbcType.VarChar),
							new OdbcParameter("UserPwd",OdbcType.VarChar),
							new OdbcParameter("IpAddr",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedEmrWorkPath")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("Application",OdbcType.VarChar),
							new OdbcParameter("EmrPath",OdbcType.VarChar),
							new OdbcParameter("UserName",OdbcType.VarChar),
							new OdbcParameter("UserPwd",OdbcType.VarChar),
							new OdbcParameter("IpAddr",OdbcType.VarChar),
							new OdbcParameter("Application",OdbcType.VarChar),
							new OdbcParameter("EmrPath",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedEmrWorkPath")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("@Application",OdbcType.VarChar),
							new OdbcParameter("@EmrPath",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrWorkPath")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("@Application",OdbcType.VarChar),
							new OdbcParameter("@EmrPath",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrWorkPathApplication")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter(":Application",OdbcType.VarChar),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录Odbc]
        /// <summary>
        ///Add    model  MedEmrWorkPath 
        ///Insert Table MED_EMR_WORK_PATH
        /// </summary>
        public int InsertMedEmrWorkPathOdbc(MedEmrWorkPath model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedEmrWorkPath");
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

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_EMR_WORK_PATH_Insert_Odbc, oneInert);
            }
        }
        #endregion
        #region [更新一条记录Odbc]
        /// <summary>
        ///Update    model  MedEmrWorkPath 
        ///Update Table     MED_EMR_WORK_PATH
        /// </summary>
        public int UpdateMedEmrWorkPathOdbc(MedEmrWorkPath model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedEmrWorkPath");
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

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_EMR_WORK_PATH_Update_Odbc, oneUpdate);
            }
        }
        #endregion

        #region  [获取一条记录Odbc]
        /// <summary>
        ///Select    model  MedEmrWorkPath 
        ///select Table MED_EMR_WORK_PATH by (string APPLICATION,string EMR_PATH)
        /// </summary>
        public MedEmrWorkPath SelectMedEmrWorkPathOdbc(string APPLICATION, string EMR_PATH)
        {
            MedEmrWorkPath model;
            OdbcParameter[] parameterValues = GetParameterOdbc("SelectMedEmrWorkPath");
            parameterValues[0].Value = APPLICATION;
            parameterValues[1].Value = EMR_PATH;
            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_EMR_WORK_PATH_Select_Odbc, parameterValues))
            {
                if (OdbcReader.Read())
                {
                    model = new MedEmrWorkPath();
                    if (!OdbcReader.IsDBNull(0))
                    {
                        model.Application = OdbcReader["APPLICATION"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(1))
                    {
                        model.EmrPath = OdbcReader["EMR_PATH"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(2))
                    {
                        model.UserName = OdbcReader["USER_NAME"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(3))
                    {
                        model.UserPwd = OdbcReader["USER_PWD"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(4))
                    {
                        model.IpAddr = OdbcReader["IP_ADDR"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        #region  [获取一条记录Odbc 入参APPLICATION]
        /// <summary>
        ///Select    model  MedEmrWorkPath 
        ///select Table MED_EMR_WORK_PATH by (string APPLICATION)
        /// </summary>
        public MedEmrWorkPath SelectMedEmrWorkPathOdbc(string APPLICATION)
        {
            MedEmrWorkPath model;
            OdbcParameter[] parameterValues = GetParameterOdbc("SelectMedEmrWorkPathApplication");
            parameterValues[0].Value = APPLICATION;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_EMR_WORK_PATH_Select_Application_Odbc, parameterValues))
            {
                if (OdbcReader.Read())
                {
                    model = new MedEmrWorkPath();
                    if (!OdbcReader.IsDBNull(0))
                    {
                        model.Application = OdbcReader["APPLICATION"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(1))
                    {
                        model.EmrPath = OdbcReader["EMR_PATH"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(2))
                    {
                        model.UserName = OdbcReader["USER_NAME"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(3))
                    {
                        model.UserPwd = OdbcReader["USER_PWD"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(4))
                    {
                        model.IpAddr = OdbcReader["IP_ADDR"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion	
	}
}
