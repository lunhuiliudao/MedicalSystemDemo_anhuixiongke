

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
using System.Data.OleDb;
using System.Data.Odbc;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL Users
	/// </summary>
	
	public partial class DALUsers
	{
		private static readonly string USERS_Insert_OLE = "INSERT INTO USERS (USER_ID,USER_NAME,USER_GENDER,USER_POWER,PART_NAME,OFFICE_NAME,USER_POST,USER_ACCOUNT,USER_PASS,USER_CARD,USER_IDENTITY_CARD,FLAG) values (?,?,?,?,?,?,?,?,?,?,?,?)";
		private static readonly string USERS_Update_OLE = "UPDATE USERS SET USER_ID=?,USER_NAME=?,USER_GENDER=?,USER_POWER=?,PART_NAME=?,OFFICE_NAME=?,USER_POST=?,USER_ACCOUNT=?,USER_PASS=?,USER_CARD=?,USER_IDENTITY_CARD=?,FLAG=? WHERE  USER_ID=?";
		private static readonly string USERS_Delete_OLE = "DELETE USERS WHERE  USER_ID=?";
		private static readonly string USERS_Select_OLE = "SELECT USER_ID,USER_NAME,USER_GENDER,USER_POWER,PART_NAME,OFFICE_NAME,USER_POST,USER_ACCOUNT,USER_PASS,USER_CARD,USER_IDENTITY_CARD,FLAG FROM USERS where  USER_ID=?";
        private static readonly string USERS_Select_UserName_OLE = "SELECT USER_ID,USER_NAME,USER_GENDER,USER_POWER,PART_NAME,OFFICE_NAME,USER_POST,USER_ACCOUNT,USER_PASS,USER_CARD,USER_IDENTITY_CARD,FLAG FROM USERS where  USER_NAME=?";
        private static readonly string USERS_Select_ALL_OLE = "SELECT USER_ID,USER_NAME,USER_GENDER,USER_POWER,PART_NAME,OFFICE_NAME,USER_POST,USER_ACCOUNT,USER_PASS,USER_CARD,USER_IDENTITY_CARD,FLAG FROM USERS";

		#region [获取参数OLE]
		/// <summary>
		///获取参数Users OLE
		/// </summary>
		public static OleDbParameter[] GetParameterOLE(string OLEParms)
		{
			OleDbParameter[] parms = OleDbHelper.GetCachedParameters(OLEParms);
            if (parms == null)
            {
                if (OLEParms == "InsertUsers")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("UserId",OleDbType.VarChar),
							new OleDbParameter("UserName",OleDbType.VarChar),
							new OleDbParameter("UserGender",OleDbType.VarChar),
							new OleDbParameter("UserPower",OleDbType.VarChar),
							new OleDbParameter("PartName",OleDbType.VarChar),
							new OleDbParameter("OfficeName",OleDbType.VarChar),
							new OleDbParameter("UserPost",OleDbType.VarChar),
							new OleDbParameter("UserAccount",OleDbType.VarChar),
							new OleDbParameter("UserPass",OleDbType.VarChar),
							new OleDbParameter("UserCard",OleDbType.VarChar),
							new OleDbParameter("UserIdentityCard",OleDbType.VarChar),
							new OleDbParameter("Flag",OleDbType.Decimal),
                    };
                }
				else if (OLEParms == "UpdateUsers")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("UserId",OleDbType.VarChar),
							new OleDbParameter("UserName",OleDbType.VarChar),
							new OleDbParameter("UserGender",OleDbType.VarChar),
							new OleDbParameter("UserPower",OleDbType.VarChar),
							new OleDbParameter("PartName",OleDbType.VarChar),
							new OleDbParameter("OfficeName",OleDbType.VarChar),
							new OleDbParameter("UserPost",OleDbType.VarChar),
							new OleDbParameter("UserAccount",OleDbType.VarChar),
							new OleDbParameter("UserPass",OleDbType.VarChar),
							new OleDbParameter("UserCard",OleDbType.VarChar),
							new OleDbParameter("UserIdentityCard",OleDbType.VarChar),
							new OleDbParameter("Flag",OleDbType.Decimal),
							new OleDbParameter("UserId",OleDbType.VarChar),
                    };
                }
				else if(OLEParms == "DeleteUsers")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("UserId",OleDbType.VarChar),
                    };
                }
				else if(OLEParms == "SelectUsers")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("UserId",OleDbType.VarChar),
                    };
                }
                else if (OLEParms == "SelectUsersName")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("UserName",OleDbType.VarChar),
                    };
                }
            	OleDbHelper.CacheParameters(OLEParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录OLE]
		/// <summary>
		///Add    model  Users 
		///Insert Table USERS
		/// </summary>
		public int InsertUsersOLE(Users model)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
				OleDbParameter[] oneInert = GetParameterOLE("InsertUsers");
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
			
				return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, USERS_Insert_OLE, oneInert);
			}
		}
		#endregion
		#region [更新一条记录OLE]
		/// <summary>
		///Update    model  Users 
		///Update Table     USERS
		/// </summary>
		public int UpdateUsersOLE(Users model)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
				OleDbParameter[] oneUpdate = GetParameterOLE("UpdateUsers");
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
			
				return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString,CommandType.Text, USERS_Update_OLE, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录OLE]
		/// <summary>
		///Delete    model  Users 
		///Delete Table USERS by (string USER_ID)
		/// </summary>
		public int DeleteUsersOLE(string USER_ID)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
				OleDbParameter[] oneDelete = GetParameterOLE("DeleteUsers");
					if (USER_ID != null)
						oneDelete[0].Value =USER_ID;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, USERS_Delete_OLE, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录OLE]
		/// <summary>
		///Select    model  Users 
		///select Table USERS by (string USER_ID)
		/// </summary>
		public Users  SelectUsersOLE(string USER_ID)
		{
			Users model;
			OleDbParameter[] parameterValues = GetParameterOLE("SelectUsers");
				parameterValues[0].Value=USER_ID;
			using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, USERS_Select_OLE, parameterValues))
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
        public Users SelectUsersNameOLE(string USER_NAME)
        {
            Users model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectUsersName");
            parameterValues[0].Value = USER_NAME;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, USERS_Select_UserName_OLE, parameterValues))
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
		#region  [获取所有记录OLE]
		/// <summary>
		///获取所有记录
		/// </summary>
		public List<Users> SelectUsersListOLE()
		{
			List<Users> modelList = new List<Users>();
		    using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, USERS_Select_ALL_OLE, null))
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
		
        private static readonly string USERS_Insert_ODBC = "INSERT INTO USERS (USER_ID,USER_NAME,USER_GENDER,USER_POWER,PART_NAME,OFFICE_NAME,USER_POST,USER_ACCOUNT,USER_PASS,USER_CARD,USER_IDENTITY_CARD,FLAG) values (?,?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string USERS_Update_ODBC = "UPDATE USERS SET USER_ID=?,USER_NAME=?,USER_GENDER=?,USER_POWER=?,PART_NAME=?,OFFICE_NAME=?,USER_POST=?,USER_ACCOUNT=?,USER_PASS=?,USER_CARD=?,USER_IDENTITY_CARD=?,FLAG=? WHERE  USER_ID=?";
        private static readonly string USERS_Delete_ODBC = "DELETE USERS WHERE  USER_ID=?";
        private static readonly string USERS_Select_ODBC = "SELECT USER_ID,USER_NAME,USER_GENDER,USER_POWER,PART_NAME,OFFICE_NAME,USER_POST,USER_ACCOUNT,USER_PASS,USER_CARD,USER_IDENTITY_CARD,FLAG FROM USERS where  USER_ID=?";
        private static readonly string USERS_Select_UserName_ODBC = "SELECT USER_ID,USER_NAME,USER_GENDER,USER_POWER,PART_NAME,OFFICE_NAME,USER_POST,USER_ACCOUNT,USER_PASS,USER_CARD,USER_IDENTITY_CARD,FLAG FROM USERS where  USER_NAME=?";
        private static readonly string USERS_Select_ALL_ODBC = "SELECT USER_ID,USER_NAME,USER_GENDER,USER_POWER,PART_NAME,OFFICE_NAME,USER_POST,USER_ACCOUNT,USER_PASS,USER_CARD,USER_IDENTITY_CARD,FLAG FROM USERS";
		

		#region [获取参数ODBC]
		/// <summary>
		///获取参数Users
		/// </summary>
		public static OdbcParameter[] GetParameterODBC(string OLEParms)
		{
			OdbcParameter[] parms = OdbcHelper.GetCachedParameters(OLEParms);
            if (parms == null)
            {
                if (OLEParms == "InsertUsers")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("UserId",OdbcType.VarChar),
							new OdbcParameter("UserName",OdbcType.VarChar),
							new OdbcParameter("UserGender",OdbcType.VarChar),
							new OdbcParameter("UserPower",OdbcType.VarChar),
							new OdbcParameter("PartName",OdbcType.VarChar),
							new OdbcParameter("OfficeName",OdbcType.VarChar),
							new OdbcParameter("UserPost",OdbcType.VarChar),
							new OdbcParameter("UserAccount",OdbcType.VarChar),
							new OdbcParameter("UserPass",OdbcType.VarChar),
							new OdbcParameter("UserCard",OdbcType.VarChar),
							new OdbcParameter("UserIdentityCard",OdbcType.VarChar),
							new OdbcParameter("Flag",OdbcType.Numeric),
                    };
                }
				else if (OLEParms == "UpdateUsers")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("UserId",OdbcType.VarChar),
							new OdbcParameter("UserName",OdbcType.VarChar),
							new OdbcParameter("UserGender",OdbcType.VarChar),
							new OdbcParameter("UserPower",OdbcType.VarChar),
							new OdbcParameter("PartName",OdbcType.VarChar),
							new OdbcParameter("OfficeName",OdbcType.VarChar),
							new OdbcParameter("UserPost",OdbcType.VarChar),
							new OdbcParameter("UserAccount",OdbcType.VarChar),
							new OdbcParameter("UserPass",OdbcType.VarChar),
							new OdbcParameter("UserCard",OdbcType.VarChar),
							new OdbcParameter("UserIdentityCard",OdbcType.VarChar),
							new OdbcParameter("Flag",OdbcType.Numeric),
							new OdbcParameter("UserId",OdbcType.VarChar),
                    };
                }
				else if(OLEParms == "DeleteUsers")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("UserId",OdbcType.VarChar),
                    };
                }
				else if(OLEParms == "SelectUsers")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("UserId",OdbcType.VarChar),
                    };
                }
                else if (OLEParms == "SelectUsersName")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("UserName",OdbcType.VarChar),
                    };
                }
            	OdbcHelper.CacheParameters(OLEParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  Users 
		///Insert Table USERS
		/// </summary>
		public int InsertUsersOdbc(Users model)
		{
			using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
				OdbcParameter[] oneInert = GetParameterODBC("InsertUsers");
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

                    return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, USERS_Insert_ODBC, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  Users 
		///Update Table     USERS
		/// </summary>
		public int UpdateUsersOdbc(Users model)
		{
			using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
				OdbcParameter[] oneUpdate = GetParameterODBC("UpdateUsers");
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

                    return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, USERS_Update_ODBC, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  Users 
		///Delete Table USERS by (string USER_ID)
		/// </summary>
		public int DeleteUsersOdbc(string USER_ID)
		{
			using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
				OdbcParameter[] oneDelete = GetParameterODBC("DeleteUsers");
					if (USER_ID != null)
						oneDelete[0].Value =USER_ID;
					else
						oneDelete[0].Value = DBNull.Value;

                    return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, USERS_Delete_ODBC, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  Users 
		///select Table USERS by (string USER_ID)
		/// </summary>
		public Users  SelectUsersOdbc(string USER_ID)
		{
			Users model;
			OdbcParameter[] parameterValues = GetParameterODBC("SelectUsers");
			parameterValues[0].Value=USER_ID;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, USERS_Select_ODBC, parameterValues))
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
        public Users SelectUsersNameODBC(string USER_NAME)
        {
            Users model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectUsersName");
            parameterValues[0].Value = USER_NAME;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, USERS_Select_UserName_ODBC, parameterValues))
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
		public List<Users> SelectUsersListOdbc()
		{
			List<Users> modelList = new List<Users>();
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, USERS_Select_ALL_ODBC, null))
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
