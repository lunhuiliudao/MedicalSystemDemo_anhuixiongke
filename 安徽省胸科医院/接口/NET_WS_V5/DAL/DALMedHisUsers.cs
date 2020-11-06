

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:05
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
	/// DAL MedHisUsers
	/// </summary>
	
	public partial class DALMedHisUsers
	{
		
		private static readonly string MED_HIS_USERS_Insert_SQL = "INSERT INTO MED_HIS_USERS (USER_JOB_ID,USER_NAME,USER_DEPT_CODE,USER_JOB,RESERVED01,CREATE_DATE,INPUT_CODE,USER_STATUS) values (@UserJobId,@UserName,@UserDeptCode,@UserJob,@Reserved01,@CreateDate,@InputCode,@UserStatus )";
        private static readonly string MED_HIS_USERS_Update_SQL = "UPDATE MED_HIS_USERS SET USER_NAME=@UserName,USER_DEPT_CODE=@UserDeptCode,USER_JOB=@UserJob,RESERVED01=@Reserved01,CREATE_DATE=@CreateDate,INPUT_CODE=@InputCode,USER_STATUS=@UserStatus  WHERE USER_JOB_ID=@UserJobId";
		private static readonly string MED_HIS_USERS_Delete_SQL = "Delete MED_HIS_USERS WHERE USER_JOB_ID=@UserJobId";
        private static readonly string MED_HIS_USERS_Select_SQL = "SELECT USER_JOB_ID,USER_NAME,USER_DEPT_CODE,USER_JOB,RESERVED01,CREATE_DATE,INPUT_CODE,USER_STATUS,SORT_NO FROM MED_HIS_USERS where USER_ID=@UserId";
        private static readonly string MED_HIS_USERS_Select_Name_SQL = "SELECT USER_JOB_ID,USER_NAME,USER_DEPT_CODE,USER_JOB,RESERVED01,CREATE_DATE,INPUT_CODE,USER_STATUS,SORT_NO FROM MED_HIS_USERS where USER_NAME=@UserName";
        private static readonly string MED_HIS_USERS_Select_ALL_SQL = "SELECT USER_JOB_ID,USER_NAME,USER_DEPT_CODE,USER_JOB,RESERVED01,CREATE_DATE,INPUT_CODE,USER_STATUS,SORT_NO FROM MED_HIS_USERS";

        private static readonly string MED_HIS_USERS_Insert = "INSERT INTO MED_HIS_USERS (USER_JOB_ID,USER_NAME,USER_DEPT_CODE,USER_JOB,RESERVED01,CREATE_DATE,INPUT_CODE,USER_STATUS) values (:UserJobId,:UserName,:UserDeptCode,:UserJob,:Reserved01,:CreateDate,:InputCode,:UserStatus )";
        private static readonly string MED_HIS_USERS_Update = "UPDATE MED_HIS_USERS SET USER_NAME=:UserName,USER_DEPT_CODE=:UserDeptCode,USER_JOB=:UserJob,RESERVED01=:Reserved01,CREATE_DATE=:CreateDate,INPUT_CODE=:InputCode,USER_STATUS=:UserStatus  WHERE USER_JOB_ID=:UserJobId";

        private static readonly string MED_HIS_USERS_Delete = "Delete MED_HIS_USERS WHERE USER_JOB_ID=:UserJobId";
        private static readonly string MED_HIS_USERS_Select = "SELECT USER_JOB_ID,USER_NAME,USER_DEPT_CODE,USER_JOB,RESERVED01,CREATE_DATE,INPUT_CODE FROM MED_HIS_USERS where USER_JOB_ID=:UserJobId";

        private static readonly string MED_HIS_USERS_Select_Name = "SELECT USER_JOB_ID,USER_NAME,USER_DEPT_CODE,USER_JOB,RESERVED01,CREATE_DATE,INPUT_CODE,USER_STATUS,SORT_NO FROM MED_HIS_USERS where USER_NAME=:UserName";
        private static readonly string MED_HIS_USERS_Select_ALL = "SELECT USER_JOB_ID,USER_NAME,USER_DEPT_CODE,USER_JOB,RESERVED01,CREATE_DATE,INPUT_CODE,USER_STATUS,SORT_NO FROM MED_HIS_USERS";
		public DALMedHisUsers ()
		{
		}
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedHisUsers SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedHisUsers")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserjobId",SqlDbType.VarChar),
							new SqlParameter("@UserName",SqlDbType.VarChar),
							new SqlParameter("@UserDeptCode",SqlDbType.VarChar),
							new SqlParameter("@UserJob",SqlDbType.VarChar),
							new SqlParameter("@Reserved01",SqlDbType.VarChar),
							new SqlParameter("@CreateDate",SqlDbType.DateTime),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
                            new SqlParameter("@UserStatus",SqlDbType.Decimal),

                          
                    };
                }
				else if (sqlParms == "UpdateMedHisUsers")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserName",SqlDbType.VarChar),
							new SqlParameter("@UserDeptCode",SqlDbType.VarChar),
							new SqlParameter("@UserJob",SqlDbType.VarChar),
							new SqlParameter("@Reserved01",SqlDbType.VarChar),
							new SqlParameter("@CreateDate",SqlDbType.DateTime),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
							new SqlParameter("@UserStatus",SqlDbType.VarChar),
							new SqlParameter("@UserjobId",SqlDbType.VarChar),

                          
                    };
                }
				else if(sqlParms == "DeleteMedHisUsers")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserId",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedHisUsers")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserId",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedHisUsersName")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserName",SqlDbType.VarChar),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedHisUsers 
		///Insert Table MED_HIS_USERS
		/// </summary>
		public int InsertMedHisUsersSQL(MedHisUsers model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedHisUsers");
                if (model.UserJobId != null)
                    oneInert[0].Value = model.UserJobId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.UserName != null)
                    oneInert[1].Value = model.UserName;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.UserDeptCode != null)
                    oneInert[2].Value = model.UserDeptCode;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.UserJob != null)
                    oneInert[3].Value = model.UserJob;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneInert[4].Value = model.Reserved01;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.CreateDate > DateTime.MinValue)
                    oneInert[5].Value = model.CreateDate;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.InputCode != null)
                    oneInert[6].Value = model.InputCode;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.UserStatus != null)
                    oneInert[7].Value = model.UserStatus;
                else
                    oneInert[7].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_HIS_USERS_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedHisUsers 
		///Update Table     MED_HIS_USERS
		/// </summary>
	public int UpdateMedHisUsersSQL(MedHisUsers model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedHisUsers");
                if (model.UserName != null)
                    oneUpdate[0].Value = model.UserName;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.UserDeptCode != null)
                    oneUpdate[1].Value = model.UserDeptCode;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.UserJob != null)
                    oneUpdate[2].Value = model.UserJob;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneUpdate[3].Value = model.Reserved01;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.CreateDate > DateTime.MinValue)
                    oneUpdate[4].Value = model.CreateDate;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.InputCode != null)
                    oneUpdate[5].Value = model.InputCode;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.UserStatus != null)
                    oneUpdate[6].Value = model.UserStatus;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.UserJobId != null)
                    oneUpdate[7].Value = model.UserJobId;
                else
                    oneUpdate[7].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_HIS_USERS_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedHisUsers 
		///Delete Table MED_HIS_USERS by (string USER_ID)
		/// </summary>
		public int DeleteMedHisUsersSQL(string USER_ID)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedHisUsers");
					if (USER_ID != null)
						oneDelete[0].Value =USER_ID;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_HIS_USERS_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedHisUsers 
		///select Table MED_HIS_USERS by (string USER_ID)
		/// </summary>
		public MedHisUsers  SelectMedHisUsersSQL(string USER_ID)
		{
			MedHisUsers model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedHisUsers");
				parameterValues[0].Value=USER_ID;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_HIS_USERS_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedHisUsers();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.UserJobId = oleReader["USER_JOB_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.UserDeptCode = oleReader["USER_DEPT_Code"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.UserJob = oleReader["USER_JOB"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
        #region  [获取一条记录[NAME]SQL]
        /// <summary>
        ///Select    model  MedHisUsers 
        ///select Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public MedHisUsers SelectMedHisUsersNameSQL(string USER_NAME)
        {
            MedHisUsers model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedHisUsersNAME");
            parameterValues[0].Value = USER_NAME;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_HIS_USERS_Select_Name_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedHisUsers();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.UserJobId = oleReader["USER_JOB_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.UserDeptCode = oleReader["USER_DEPT_Code"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.UserJob = oleReader["USER_JOB"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
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
		public List<MedHisUsers> SelectMedHisUsersListSQL()
		{
			List<MedHisUsers> modelList = new List<MedHisUsers>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_HIS_USERS_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedHisUsers model = new MedHisUsers();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.UserJobId = oleReader["USER_JOB_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.UserDeptCode = oleReader["USER_DEPT_Code"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.UserJob = oleReader["USER_JOB"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [获取参数]
		/// <summary>
		///获取参数MedHisUsers
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedHisUsers")
                {  //:UserJobId,:UserName,:UserDeptCode,:UserJob,:Reserved01,:CreateDate,:InputCode,:UserStatus,:SortNo
                    parms = new OracleParameter[]{
							new OracleParameter(":UserjobId",OracleType.VarChar),
							new OracleParameter(":UserName",OracleType.VarChar),
							new OracleParameter(":UserDeptCode",OracleType.VarChar),
							new OracleParameter(":UserJob",OracleType.VarChar),
							new OracleParameter(":Reserved01",OracleType.VarChar),
							new OracleParameter(":CreateDate",OracleType.DateTime),
							new OracleParameter(":InputCode",OracleType.VarChar),
                            new OracleParameter(":UserStatus",OracleType.Number),
                        
                    };
                }
				else if (sqlParms == "UpdateMedHisUsers")
                {
                    parms = new OracleParameter[]{
						 
							new OracleParameter(":UserName",OracleType.VarChar),
							new OracleParameter(":UserDeptCode",OracleType.VarChar),
							new OracleParameter(":UserJob",OracleType.VarChar),
							new OracleParameter(":Reserved01",OracleType.VarChar),
							new OracleParameter(":CreateDate",OracleType.DateTime),
							new OracleParameter(":InputCode",OracleType.VarChar),
                            new OracleParameter(":UserStatus",OracleType.Number),
                        
							new OracleParameter(":UserjobId",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedHisUsers")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":UserJobId",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedHisUsers")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":UserJobId",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedHisUsersNAME")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":UserName",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedHisUsers 
		///Insert Table MED_HIS_USERS
		/// </summary>
		public int InsertMedHisUsers(MedHisUsers model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
 
				OracleParameter[] oneInert = GetParameter("InsertMedHisUsers");
					if (model.UserJobId != null)
                        oneInert[0].Value = model.UserJobId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.UserName != null)
						oneInert[1].Value = model.UserName;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.UserDeptCode != null)
                        oneInert[2].Value = model.UserDeptCode;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.UserJob != null)
						oneInert[3].Value = model.UserJob;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.Reserved01 != null)
						oneInert[4].Value = model.Reserved01;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.CreateDate > DateTime.MinValue)
						oneInert[5].Value = model.CreateDate;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.InputCode != null)
						oneInert[6].Value = model.InputCode;
					else
						oneInert[6].Value = DBNull.Value;
                    if (model.UserStatus != null)
                        oneInert[7].Value = model.UserStatus;
                    else
                        oneInert[7].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_HIS_USERS_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedHisUsers 
		///Update Table     MED_HIS_USERS
		/// </summary>
		public int UpdateMedHisUsers(MedHisUsers model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {

                
				OracleParameter[] oneUpdate = GetParameter("UpdateMedHisUsers");
                    if (model.UserName != null)
                    oneUpdate[0].Value = model.UserName;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.UserDeptCode != null)
                        oneUpdate[1].Value = model.UserDeptCode;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.UserJob != null)
                        oneUpdate[2].Value = model.UserJob;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.Reserved01 != null)
                        oneUpdate[3].Value = model.Reserved01;
					else
						oneUpdate[3].Value = DBNull.Value;
                    if (model.CreateDate > DateTime.MinValue)
                        oneUpdate[4].Value = model.CreateDate;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.InputCode!=null)
                        oneUpdate[5].Value = model.InputCode;
					else
						oneUpdate[5].Value = DBNull.Value;
                    if (model.UserStatus != null)
                        oneUpdate[6].Value = model.UserStatus;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.UserJobId != null)
                        oneUpdate[7].Value = model.UserJobId;
					else
						oneUpdate[7].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_HIS_USERS_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedHisUsers 
		///Delete Table MED_HIS_USERS by (string USER_ID)
		/// </summary>
		public int DeleteMedHisUsers(string USER_ID)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedHisUsers");
					if (USER_ID != null)
						oneDelete[0].Value =USER_ID;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_HIS_USERS_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedHisUsers 
		///select Table MED_HIS_USERS by (string USER_ID)
		/// </summary>
		public MedHisUsers  SelectMedHisUsers(string USER_ID)
		{
			MedHisUsers model;
			OracleParameter[] parameterValues = GetParameter("SelectMedHisUsers");
				parameterValues[0].Value=USER_ID;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_HIS_USERS_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedHisUsers();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.UserJobId = oleReader["USER_JOB_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.UserDeptCode = oleReader["USER_DEPT_Code"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.UserJob = oleReader["USER_JOB"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
        #region  [获取一条记录[NAME]]
        /// <summary>
        ///Select    model  MedHisUsers 
        ///select Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public MedHisUsers SelectMedHisUsersName(string USER_NAME)
        {
            MedHisUsers model;
            OracleParameter[] parameterValues = GetParameter("SelectMedHisUsersNAME");
            parameterValues[0].Value = USER_NAME;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_HIS_USERS_Select_Name, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedHisUsers();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.UserJobId = oleReader["USER_JOB_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.UserDeptCode = oleReader["USER_DEPT_Code"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.UserJob = oleReader["USER_JOB"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
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
		public List<MedHisUsers> SelectMedHisUsersList()
		{
			List<MedHisUsers> modelList = new List<MedHisUsers>();
		    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_HIS_USERS_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedHisUsers model = new MedHisUsers();
						if (!oleReader.IsDBNull(0))
						{
							model.UserJobId = oleReader["USER_JOB_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.UserName = oleReader["USER_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
                            model.UserDeptCode = oleReader["USER_DEPT_Code"].ToString().Trim();
						}
						if (!oleReader.IsDBNull(3))
						{
							model.UserJob = oleReader["USER_JOB"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.InputCode = oleReader["INPUT_CODE"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
