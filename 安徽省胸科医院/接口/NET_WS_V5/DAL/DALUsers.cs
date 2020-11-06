

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2011-06-12 12:28:37
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
	/// DAL Users
	/// </summary>
	
	public partial class DALUsers
	{
		private static readonly string USERS_Insert_SQL = "INSERT INTO USERS (USER_ID,USER_NAME,USER_GENDER,USER_POWER,PART_NAME,OFFICE_NAME,USER_POST,USER_ACCOUNT,USER_PASS,USER_CARD,USER_IDENTITY_CARD,FLAG) values (@UserId,@UserName,@UserGender,@UserPower,@PartName,@OfficeName,@UserPost,@UserAccount,@UserPass,@UserCard,@UserIdentityCard,@Flag)";
		private static readonly string USERS_Update_SQL = "UPDATE USERS SET USER_ID=@UserId,USER_NAME=@UserName,USER_GENDER=@UserGender,USER_POWER=@UserPower,PART_NAME=@PartName,OFFICE_NAME=@OfficeName,USER_POST=@UserPost,USER_ACCOUNT=@UserAccount,USER_PASS=@UserPass,USER_CARD=@UserCard,USER_IDENTITY_CARD=@UserIdentityCard,FLAG=@Flag WHERE  USER_ID=@UserId";
		private static readonly string USERS_Delete_SQL = "DELETE USERS WHERE  USER_ID=@UserId";
		private static readonly string USERS_Select_SQL = "SELECT USER_ID,USER_NAME,USER_GENDER,USER_POWER,PART_NAME,OFFICE_NAME,USER_POST,USER_ACCOUNT,USER_PASS,USER_CARD,USER_IDENTITY_CARD,FLAG FROM USERS where  USER_ID=@UserId";
        private static readonly string USERS_Select_UserName_SQL = "SELECT USER_ID,USER_NAME,USER_GENDER,USER_POWER,PART_NAME,OFFICE_NAME,USER_POST,USER_ACCOUNT,USER_PASS,USER_CARD,USER_IDENTITY_CARD,FLAG FROM USERS where  USER_NAME=@UserName";
        private static readonly string USERS_Select_ALL_SQL = "SELECT USER_ID,USER_NAME,USER_GENDER,USER_POWER,PART_NAME,OFFICE_NAME,USER_POST,USER_ACCOUNT,USER_PASS,USER_CARD,USER_IDENTITY_CARD,FLAG FROM USERS";
		private static readonly string USERS_Insert = "INSERT INTO USERS (USER_ID,USER_NAME,USER_GENDER,USER_POWER,PART_NAME,OFFICE_NAME,USER_POST,USER_ACCOUNT,USER_PASS,USER_CARD,USER_IDENTITY_CARD,FLAG) values (:UserId,:UserName,:UserGender,:UserPower,:PartName,:OfficeName,:UserPost,:UserAccount,:UserPass,:UserCard,:UserIdentityCard,:Flag)";
		private static readonly string USERS_Update = "UPDATE USERS SET USER_ID=:UserId,USER_NAME=:UserName,USER_GENDER=:UserGender,USER_POWER=:UserPower,PART_NAME=:PartName,OFFICE_NAME=:OfficeName,USER_POST=:UserPost,USER_ACCOUNT=:UserAccount,USER_PASS=:UserPass,USER_CARD=:UserCard,USER_IDENTITY_CARD=:UserIdentityCard,FLAG=:Flag WHERE  USER_ID=:UserId";
		private static readonly string USERS_Delete = "DELETE USERS WHERE  USER_ID=:UserId";
		private static readonly string USERS_Select = "SELECT USER_ID,USER_NAME,USER_GENDER,USER_POWER,PART_NAME,OFFICE_NAME,USER_POST,USER_ACCOUNT,USER_PASS,USER_CARD,USER_IDENTITY_CARD,FLAG FROM USERS where  USER_ID=:UserId";
        private static readonly string USERS_Select_UserName = "SELECT USER_ID,USER_NAME,USER_GENDER,USER_POWER,PART_NAME,OFFICE_NAME,USER_POST,USER_ACCOUNT,USER_PASS,USER_CARD,USER_IDENTITY_CARD,FLAG FROM USERS where  USER_NAME=:UserName";
        private static readonly string USERS_Select_ALL = "SELECT USER_ID,USER_NAME,USER_GENDER,USER_POWER,PART_NAME,OFFICE_NAME,USER_POST,USER_ACCOUNT,USER_PASS,USER_CARD,USER_IDENTITY_CARD,FLAG FROM USERS";
		
		public DALUsers ()
		{
		}
		
		#region [获取参数SQL]
		/// <summary>
		///获取参数Users SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertUsers")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserId",SqlDbType.VarChar),
							new SqlParameter("@UserName",SqlDbType.VarChar),
							new SqlParameter("@UserGender",SqlDbType.VarChar),
							new SqlParameter("@UserPower",SqlDbType.VarChar),
							new SqlParameter("@PartName",SqlDbType.VarChar),
							new SqlParameter("@OfficeName",SqlDbType.VarChar),
							new SqlParameter("@UserPost",SqlDbType.VarChar),
							new SqlParameter("@UserAccount",SqlDbType.VarChar),
							new SqlParameter("@UserPass",SqlDbType.VarChar),
							new SqlParameter("@UserCard",SqlDbType.VarChar),
							new SqlParameter("@UserIdentityCard",SqlDbType.VarChar),
							new SqlParameter("@Flag",SqlDbType.Decimal),
                    };
                }
				else if (sqlParms == "UpdateUsers")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserId",SqlDbType.VarChar),
							new SqlParameter("@UserName",SqlDbType.VarChar),
							new SqlParameter("@UserGender",SqlDbType.VarChar),
							new SqlParameter("@UserPower",SqlDbType.VarChar),
							new SqlParameter("@PartName",SqlDbType.VarChar),
							new SqlParameter("@OfficeName",SqlDbType.VarChar),
							new SqlParameter("@UserPost",SqlDbType.VarChar),
							new SqlParameter("@UserAccount",SqlDbType.VarChar),
							new SqlParameter("@UserPass",SqlDbType.VarChar),
							new SqlParameter("@UserCard",SqlDbType.VarChar),
							new SqlParameter("@UserIdentityCard",SqlDbType.VarChar),
							new SqlParameter("@Flag",SqlDbType.Decimal),
							new SqlParameter("@UserId",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteUsers")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserId",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectUsers")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserId",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectUsersName")
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
		///Add    model  Users 
		///Insert Table USERS
		/// </summary>
		public int InsertUsersSQL(Users model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertUsers");
					if (model.UserId != null)
						oneInert[0].Value = model.UserId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.UserName != null)
						oneInert[1].Value = model.UserName;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.UserGender != null)
						oneInert[2].Value = model.UserGender;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.UserPower != null)
						oneInert[3].Value = model.UserPower;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.PartName != null)
						oneInert[4].Value = model.PartName;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.OfficeName != null)
						oneInert[5].Value = model.OfficeName;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.UserPost != null)
						oneInert[6].Value = model.UserPost;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.UserAccount != null)
						oneInert[7].Value = model.UserAccount;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.UserPass != null)
						oneInert[8].Value = model.UserPass;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.UserCard != null)
						oneInert[9].Value = model.UserCard;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.UserIdentityCard != null)
						oneInert[10].Value = model.UserIdentityCard;
					else
						oneInert[10].Value = DBNull.Value;
                    if (model.Flag.ToString() != null)
						oneInert[11].Value = model.Flag;
					else
						oneInert[11].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, USERS_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  Users 
		///Update Table     USERS
		/// </summary>
		public int UpdateUsersSQL(Users model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateUsers");
					if (model.UserId != null)
						oneUpdate[0].Value = model.UserId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.UserName != null)
						oneUpdate[1].Value = model.UserName;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.UserGender != null)
						oneUpdate[2].Value = model.UserGender;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.UserPower != null)
						oneUpdate[3].Value = model.UserPower;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.PartName != null)
						oneUpdate[4].Value = model.PartName;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.OfficeName != null)
						oneUpdate[5].Value = model.OfficeName;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.UserPost != null)
						oneUpdate[6].Value = model.UserPost;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.UserAccount != null)
						oneUpdate[7].Value = model.UserAccount;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.UserPass != null)
						oneUpdate[8].Value = model.UserPass;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.UserCard != null)
						oneUpdate[9].Value = model.UserCard;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.UserIdentityCard != null)
						oneUpdate[10].Value = model.UserIdentityCard;
					else
						oneUpdate[10].Value = DBNull.Value;
                    if (model.Flag.ToString() != null)
						oneUpdate[11].Value = model.Flag;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.UserId != null)
						oneUpdate[12].Value =model.UserId;
					else
						oneUpdate[12].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, USERS_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  Users 
		///Delete Table USERS by (string USER_ID)
		/// </summary>
		public int DeleteUsersSQL(string USER_ID)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteUsers");
					if (USER_ID != null)
						oneDelete[0].Value =USER_ID;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, USERS_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  Users 
		///select Table USERS by (string USER_ID)
		/// </summary>
		public Users  SelectUsersSQL(string USER_ID)
		{
			Users model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectUsers");
				parameterValues[0].Value=USER_ID;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, USERS_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new Users();
						if (!oleReader.IsDBNull(0))
						{
							model.UserId = oleReader["USER_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.UserName = oleReader["USER_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.UserGender = oleReader["USER_GENDER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.UserPower = oleReader["USER_POWER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.PartName = oleReader["PART_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.OfficeName = oleReader["OFFICE_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.UserPost = oleReader["USER_POST"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.UserAccount = oleReader["USER_ACCOUNT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.UserPass = oleReader["USER_PASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.UserCard = oleReader["USER_CARD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.UserIdentityCard = oleReader["USER_IDENTITY_CARD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Flag = decimal.Parse(oleReader["FLAG"].ToString().Trim()) ;
						}
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
        #region  [获取一条记录OLE USER_NAME]
        /// <summary>
        ///Select    model  Users 
        ///select Table USERS by (string USER_NAME)
        /// </summary>
        public Users SelectUsersName(string USER_NAME)
        {
            Users model;
            OracleParameter[] parameterValues = GetParameter("SelectUsersName");
            parameterValues[0].Value = USER_NAME;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, USERS_Select_UserName, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new Users();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.UserId = oleReader["USER_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.UserGender = oleReader["USER_GENDER"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.UserPower = oleReader["USER_POWER"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.PartName = oleReader["PART_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OfficeName = oleReader["OFFICE_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.UserPost = oleReader["USER_POST"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.UserAccount = oleReader["USER_ACCOUNT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.UserPass = oleReader["USER_PASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.UserCard = oleReader["USER_CARD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.UserIdentityCard = oleReader["USER_IDENTITY_CARD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Flag = decimal.Parse(oleReader["FLAG"].ToString().Trim());
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
		public List<Users> SelectUsersListSQL()
		{
			List<Users> modelList = new List<Users>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, USERS_Select_ALL_SQL, null))
			{
				while (oleReader.Read())
				{
					Users model = new Users();
						if (!oleReader.IsDBNull(0))
						{
							model.UserId = oleReader["USER_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.UserName = oleReader["USER_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.UserGender = oleReader["USER_GENDER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.UserPower = oleReader["USER_POWER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.PartName = oleReader["PART_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.OfficeName = oleReader["OFFICE_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.UserPost = oleReader["USER_POST"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.UserAccount = oleReader["USER_ACCOUNT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.UserPass = oleReader["USER_PASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.UserCard = oleReader["USER_CARD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.UserIdentityCard = oleReader["USER_IDENTITY_CARD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Flag = decimal.Parse(oleReader["FLAG"].ToString().Trim()) ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [获取参数]
		/// <summary>
		///获取参数Users
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertUsers")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":UserId",OracleType.VarChar),
							new OracleParameter(":UserName",OracleType.VarChar),
							new OracleParameter(":UserGender",OracleType.VarChar),
							new OracleParameter(":UserPower",OracleType.VarChar),
							new OracleParameter(":PartName",OracleType.VarChar),
							new OracleParameter(":OfficeName",OracleType.VarChar),
							new OracleParameter(":UserPost",OracleType.VarChar),
							new OracleParameter(":UserAccount",OracleType.VarChar),
							new OracleParameter(":UserPass",OracleType.VarChar),
							new OracleParameter(":UserCard",OracleType.VarChar),
							new OracleParameter(":UserIdentityCard",OracleType.VarChar),
							new OracleParameter(":Flag",OracleType.Number),
                    };
                }
				else if (sqlParms == "UpdateUsers")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":UserId",OracleType.VarChar),
							new OracleParameter(":UserName",OracleType.VarChar),
							new OracleParameter(":UserGender",OracleType.VarChar),
							new OracleParameter(":UserPower",OracleType.VarChar),
							new OracleParameter(":PartName",OracleType.VarChar),
							new OracleParameter(":OfficeName",OracleType.VarChar),
							new OracleParameter(":UserPost",OracleType.VarChar),
							new OracleParameter(":UserAccount",OracleType.VarChar),
							new OracleParameter(":UserPass",OracleType.VarChar),
							new OracleParameter(":UserCard",OracleType.VarChar),
							new OracleParameter(":UserIdentityCard",OracleType.VarChar),
							new OracleParameter(":Flag",OracleType.Number),
							new OracleParameter(":UserId",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteUsers")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":UserId",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "SelectUsers")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":UserId",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectUsersName")
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
		///Add    model  Users 
		///Insert Table USERS
		/// </summary>
		public int InsertUsers(Users model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertUsers");
					if (model.UserId != null)
						oneInert[0].Value = model.UserId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.UserName != null)
						oneInert[1].Value = model.UserName;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.UserGender != null)
						oneInert[2].Value = model.UserGender;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.UserPower != null)
						oneInert[3].Value = model.UserPower;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.PartName != null)
						oneInert[4].Value = model.PartName;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.OfficeName != null)
						oneInert[5].Value = model.OfficeName;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.UserPost != null)
						oneInert[6].Value = model.UserPost;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.UserAccount != null)
						oneInert[7].Value = model.UserAccount;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.UserPass != null)
						oneInert[8].Value = model.UserPass;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.UserCard != null)
						oneInert[9].Value = model.UserCard;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.UserIdentityCard != null)
						oneInert[10].Value = model.UserIdentityCard;
					else
						oneInert[10].Value = DBNull.Value;
                    if (model.Flag.ToString() != null)
						oneInert[11].Value = model.Flag;
					else
						oneInert[11].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, USERS_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  Users 
		///Update Table     USERS
		/// </summary>
		public int UpdateUsers(Users model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateUsers");
					if (model.UserId != null)
						oneUpdate[0].Value = model.UserId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.UserName != null)
						oneUpdate[1].Value = model.UserName;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.UserGender != null)
						oneUpdate[2].Value = model.UserGender;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.UserPower != null)
						oneUpdate[3].Value = model.UserPower;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.PartName != null)
						oneUpdate[4].Value = model.PartName;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.OfficeName != null)
						oneUpdate[5].Value = model.OfficeName;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.UserPost != null)
						oneUpdate[6].Value = model.UserPost;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.UserAccount != null)
						oneUpdate[7].Value = model.UserAccount;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.UserPass != null)
						oneUpdate[8].Value = model.UserPass;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.UserCard != null)
						oneUpdate[9].Value = model.UserCard;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.UserIdentityCard != null)
						oneUpdate[10].Value = model.UserIdentityCard;
					else
						oneUpdate[10].Value = DBNull.Value;
                    if (model.Flag.ToString() != null)
						oneUpdate[11].Value = model.Flag;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.UserId != null)
						oneUpdate[12].Value =model.UserId;
					else
						oneUpdate[12].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, USERS_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  Users 
		///Delete Table USERS by (string USER_ID)
		/// </summary>
		public int DeleteUsers(string USER_ID)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteUsers");
					if (USER_ID != null)
						oneDelete[0].Value =USER_ID;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, USERS_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  Users 
		///select Table USERS by (string USER_ID)
		/// </summary>
		public Users  SelectUsers(string USER_ID)
		{
			Users model;
			OracleParameter[] parameterValues = GetParameter("SelectUsers");
				parameterValues[0].Value=USER_ID;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, USERS_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new Users();
						if (!oleReader.IsDBNull(0))
						{
							model.UserId = oleReader["USER_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.UserName = oleReader["USER_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.UserGender = oleReader["USER_GENDER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.UserPower = oleReader["USER_POWER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.PartName = oleReader["PART_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.OfficeName = oleReader["OFFICE_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.UserPost = oleReader["USER_POST"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.UserAccount = oleReader["USER_ACCOUNT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.UserPass = oleReader["USER_PASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.UserCard = oleReader["USER_CARD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.UserIdentityCard = oleReader["USER_IDENTITY_CARD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Flag = decimal.Parse(oleReader["FLAG"].ToString().Trim()) ;
						}
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
        #region  [获取一条记录OLE USER_NAME]
        /// <summary>
        ///Select    model  Users 
        ///select Table USERS by (string USER_NAME)
        /// </summary>
        public Users SelectUsersNameSQL(string USER_NAME)
        {
            Users model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectUsersName");
            parameterValues[0].Value = USER_NAME;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, USERS_Select_UserName_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new Users();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.UserId = oleReader["USER_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.UserGender = oleReader["USER_GENDER"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.UserPower = oleReader["USER_POWER"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.PartName = oleReader["PART_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OfficeName = oleReader["OFFICE_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.UserPost = oleReader["USER_POST"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.UserAccount = oleReader["USER_ACCOUNT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.UserPass = oleReader["USER_PASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.UserCard = oleReader["USER_CARD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.UserIdentityCard = oleReader["USER_IDENTITY_CARD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Flag = decimal.Parse(oleReader["FLAG"].ToString().Trim());
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
		public List<Users> SelectUsersList()
		{
			List<Users> modelList = new List<Users>();
		    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, USERS_Select_ALL, null))
			{
				while (oleReader.Read())
				{
					Users model = new Users();
						if (!oleReader.IsDBNull(0))
						{
							model.UserId = oleReader["USER_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.UserName = oleReader["USER_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.UserGender = oleReader["USER_GENDER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.UserPower = oleReader["USER_POWER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.PartName = oleReader["PART_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.OfficeName = oleReader["OFFICE_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.UserPost = oleReader["USER_POST"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.UserAccount = oleReader["USER_ACCOUNT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.UserPass = oleReader["USER_PASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.UserCard = oleReader["USER_CARD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.UserIdentityCard = oleReader["USER_IDENTITY_CARD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Flag = decimal.Parse(oleReader["FLAG"].ToString().Trim()) ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
