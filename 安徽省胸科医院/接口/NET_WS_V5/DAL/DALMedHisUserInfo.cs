

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/5/21 11:28:55
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
	/// DAL MedHisUserInfo
	/// </summary>
	
	public partial class DALMedHisUserInfo
	{
		private static readonly string MED_HIS_USER_INFO_Insert_SQL = "INSERT INTO MED_HIS_USER_INFO (USER_ID,USER_NAME,USER_IMAGE,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07) values (@UserId,@UserName,@UserImage,@CreateDate,@Reserved01,@Reserved02,@Reserved03,@Reserved04,@Reserved05,@Reserved06,@Reserved07)";
		private static readonly string MED_HIS_USER_INFO_Update_SQL = "UPDATE MED_HIS_USER_INFO SET USER_ID=@UserId,USER_NAME=@UserName,USER_IMAGE=@UserImage,CREATE_DATE=@CreateDate,RESERVED01=@Reserved01,RESERVED02=@Reserved02,RESERVED03=@Reserved03,RESERVED04=@Reserved04,RESERVED05=@Reserved05,RESERVED06=@Reserved06,RESERVED07=@Reserved07 WHERE  USER_ID=@UserId";
		private static readonly string MED_HIS_USER_INFO_Delete_SQL = "DELETE MED_HIS_USER_INFO WHERE  USER_ID=@UserId";
		private static readonly string MED_HIS_USER_INFO_Select_SQL = "SELECT USER_ID,USER_NAME,USER_IMAGE,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07 FROM MED_HIS_USER_INFO where  USER_ID=@UserId";
		private static readonly string MED_HIS_USER_INFO_Select_ALL_SQL = "SELECT USER_ID,USER_NAME,USER_IMAGE,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07 FROM MED_HIS_USER_INFO";
		private static readonly string MED_HIS_USER_INFO_Insert = "INSERT INTO MED_HIS_USER_INFO (USER_ID,USER_NAME,USER_IMAGE,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07) values (:UserId,:UserName,:UserImage,:CreateDate,:Reserved01,:Reserved02,:Reserved03,:Reserved04,:Reserved05,:Reserved06,:Reserved07)";
		private static readonly string MED_HIS_USER_INFO_Update = "UPDATE MED_HIS_USER_INFO SET USER_ID=:UserId,USER_NAME=:UserName,USER_IMAGE=:UserImage,CREATE_DATE=:CreateDate,RESERVED01=:Reserved01,RESERVED02=:Reserved02,RESERVED03=:Reserved03,RESERVED04=:Reserved04,RESERVED05=:Reserved05,RESERVED06=:Reserved06,RESERVED07=:Reserved07 WHERE  USER_ID=:UserId";
		private static readonly string MED_HIS_USER_INFO_Delete = "DELETE MED_HIS_USER_INFO WHERE  USER_ID=:UserId";
		private static readonly string MED_HIS_USER_INFO_Select = "SELECT USER_ID,USER_NAME,USER_IMAGE,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07 FROM MED_HIS_USER_INFO where  USER_ID=:UserId";
		private static readonly string MED_HIS_USER_INFO_Select_ALL = "SELECT USER_ID,USER_NAME,USER_IMAGE,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07 FROM MED_HIS_USER_INFO";
		
		public DALMedHisUserInfo ()
		{
		}
		
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedHisUserInfo SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedHisUserInfo")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserId",SqlDbType.VarChar),
							new SqlParameter("@UserName",SqlDbType.VarChar),
							new SqlParameter("@UserImage",SqlDbType.Binary),
							new SqlParameter("@CreateDate",SqlDbType.DateTime),
							new SqlParameter("@Reserved01",SqlDbType.VarChar),
							new SqlParameter("@Reserved02",SqlDbType.VarChar),
							new SqlParameter("@Reserved03",SqlDbType.VarChar),
							new SqlParameter("@Reserved04",SqlDbType.DateTime),
							new SqlParameter("@Reserved05",SqlDbType.DateTime),
							new SqlParameter("@Reserved06",SqlDbType.Binary),
							new SqlParameter("@Reserved07",SqlDbType.Binary),
                    };
                }
				else if (sqlParms == "UpdateMedHisUserInfo")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserId",SqlDbType.VarChar),
							new SqlParameter("@UserName",SqlDbType.VarChar),
							new SqlParameter("@UserImage",SqlDbType.Binary),
							new SqlParameter("@CreateDate",SqlDbType.DateTime),
							new SqlParameter("@Reserved01",SqlDbType.VarChar),
							new SqlParameter("@Reserved02",SqlDbType.VarChar),
							new SqlParameter("@Reserved03",SqlDbType.VarChar),
							new SqlParameter("@Reserved04",SqlDbType.DateTime),
							new SqlParameter("@Reserved05",SqlDbType.DateTime),
							new SqlParameter("@Reserved06",SqlDbType.Binary),
							new SqlParameter("@Reserved07",SqlDbType.Binary),
							new SqlParameter("@UserId",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedHisUserInfo")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserId",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedHisUserInfo")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserId",SqlDbType.VarChar),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedHisUserInfo 
		///Insert Table MED_HIS_USER_INFO
		/// </summary>
		public int InsertMedHisUserInfoSQL(MedHisUserInfo model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedHisUserInfo");
					if (model.UserId != null)
						oneInert[0].Value = model.UserId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.UserName != null)
						oneInert[1].Value = model.UserName;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.UserImage != null)
						oneInert[2].Value = model.UserImage;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.CreateDate != null)
						oneInert[3].Value = model.CreateDate;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.Reserved01 != null)
						oneInert[4].Value = model.Reserved01;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.Reserved02 != null)
						oneInert[5].Value = model.Reserved02;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.Reserved03 != null)
						oneInert[6].Value = model.Reserved03;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.Reserved04 != null)
						oneInert[7].Value = model.Reserved04;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.Reserved05 != null)
						oneInert[8].Value = model.Reserved05;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.Reserved06 != null)
						oneInert[9].Value = model.Reserved06;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.Reserved07 != null)
						oneInert[10].Value = model.Reserved07;
					else
						oneInert[10].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_HIS_USER_INFO_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedHisUserInfo 
		///Update Table     MED_HIS_USER_INFO
		/// </summary>
		public int UpdateMedHisUserInfoSQL(MedHisUserInfo model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedHisUserInfo");
					if (model.UserId != null)
						oneUpdate[0].Value = model.UserId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.UserName != null)
						oneUpdate[1].Value = model.UserName;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.UserImage != null)
						oneUpdate[2].Value = model.UserImage;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.CreateDate != null)
						oneUpdate[3].Value = model.CreateDate;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.Reserved01 != null)
						oneUpdate[4].Value = model.Reserved01;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.Reserved02 != null)
						oneUpdate[5].Value = model.Reserved02;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.Reserved03 != null)
						oneUpdate[6].Value = model.Reserved03;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.Reserved04 != null)
						oneUpdate[7].Value = model.Reserved04;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.Reserved05 != null)
						oneUpdate[8].Value = model.Reserved05;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.Reserved06 != null)
						oneUpdate[9].Value = model.Reserved06;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.Reserved07 != null)
						oneUpdate[10].Value = model.Reserved07;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.UserId != null)
						oneUpdate[11].Value =model.UserId;
					else
						oneUpdate[11].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_HIS_USER_INFO_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedHisUserInfo 
		///Delete Table MED_HIS_USER_INFO by (string USER_ID)
		/// </summary>
		public int DeleteMedHisUserInfoSQL(string USER_ID)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedHisUserInfo");
					if (USER_ID != null)
						oneDelete[0].Value =USER_ID;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_HIS_USER_INFO_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedHisUserInfo 
		///select Table MED_HIS_USER_INFO by (string USER_ID)
		/// </summary>
		public MedHisUserInfo  SelectMedHisUserInfoSQL(string USER_ID)
		{
			MedHisUserInfo model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedHisUserInfo");
				parameterValues[0].Value=USER_ID;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_HIS_USER_INFO_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedHisUserInfo();
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
							model.UserImage = oleReader["USER_IMAGE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Reserved04 = DateTime.Parse(oleReader["RESERVED04"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved05 = DateTime.Parse(oleReader["RESERVED05"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved06 = oleReader["RESERVED06"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Reserved07 = oleReader["RESERVED07"].ToString().Trim() ;
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
		public List<MedHisUserInfo> SelectMedHisUserInfoListSQL()
		{
			List<MedHisUserInfo> modelList = new List<MedHisUserInfo>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_HIS_USER_INFO_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedHisUserInfo model = new MedHisUserInfo();
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
							model.UserImage = oleReader["USER_IMAGE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Reserved04 = DateTime.Parse(oleReader["RESERVED04"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved05 = DateTime.Parse(oleReader["RESERVED05"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved06 = oleReader["RESERVED06"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Reserved07 = oleReader["RESERVED07"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [获取参数]
		/// <summary>
		///获取参数MedHisUserInfo
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedHisUserInfo")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":UserId",OracleType.VarChar),
							new OracleParameter(":UserName",OracleType.VarChar),
							new OracleParameter(":UserImage",OracleType.Blob),
							new OracleParameter(":CreateDate",OracleType.DateTime),
							new OracleParameter(":Reserved01",OracleType.VarChar),
							new OracleParameter(":Reserved02",OracleType.VarChar),
							new OracleParameter(":Reserved03",OracleType.VarChar),
							new OracleParameter(":Reserved04",OracleType.DateTime),
							new OracleParameter(":Reserved05",OracleType.DateTime),
							new OracleParameter(":Reserved06",OracleType.Blob),
							new OracleParameter(":Reserved07",OracleType.Blob),
                    };
                }
				else if (sqlParms == "UpdateMedHisUserInfo")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":UserId",OracleType.VarChar),
							new OracleParameter(":UserName",OracleType.VarChar),
							new OracleParameter(":UserImage",OracleType.Blob),
							new OracleParameter(":CreateDate",OracleType.DateTime),
							new OracleParameter(":Reserved01",OracleType.VarChar),
							new OracleParameter(":Reserved02",OracleType.VarChar),
							new OracleParameter(":Reserved03",OracleType.VarChar),
							new OracleParameter(":Reserved04",OracleType.DateTime),
							new OracleParameter(":Reserved05",OracleType.DateTime),
							new OracleParameter(":Reserved06",OracleType.Blob),
							new OracleParameter(":Reserved07",OracleType.Blob),
							new OracleParameter(":UserId",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedHisUserInfo")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":UserId",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedHisUserInfo")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":UserId",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedHisUserInfo 
		///Insert Table MED_HIS_USER_INFO
		/// </summary>
		public int InsertMedHisUserInfo(MedHisUserInfo model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedHisUserInfo");
					if (model.UserId != null)
						oneInert[0].Value = model.UserId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.UserName != null)
						oneInert[1].Value = model.UserName;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.UserImage != null)
						oneInert[2].Value = model.UserImage;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.CreateDate != null)
						oneInert[3].Value = model.CreateDate;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.Reserved01 != null)
						oneInert[4].Value = model.Reserved01;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.Reserved02 != null)
						oneInert[5].Value = model.Reserved02;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.Reserved03 != null)
						oneInert[6].Value = model.Reserved03;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.Reserved04 != null)
						oneInert[7].Value = model.Reserved04;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.Reserved05 != null)
						oneInert[8].Value = model.Reserved05;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.Reserved06 != null)
						oneInert[9].Value = model.Reserved06;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.Reserved07 != null)
						oneInert[10].Value = model.Reserved07;
					else
						oneInert[10].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_HIS_USER_INFO_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedHisUserInfo 
		///Update Table     MED_HIS_USER_INFO
		/// </summary>
		public int UpdateMedHisUserInfo(MedHisUserInfo model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedHisUserInfo");
					if (model.UserId != null)
						oneUpdate[0].Value = model.UserId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.UserName != null)
						oneUpdate[1].Value = model.UserName;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.UserImage != null)
						oneUpdate[2].Value = model.UserImage;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.CreateDate != null)
						oneUpdate[3].Value = model.CreateDate;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.Reserved01 != null)
						oneUpdate[4].Value = model.Reserved01;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.Reserved02 != null)
						oneUpdate[5].Value = model.Reserved02;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.Reserved03 != null)
						oneUpdate[6].Value = model.Reserved03;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.Reserved04 != null)
						oneUpdate[7].Value = model.Reserved04;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.Reserved05 != null)
						oneUpdate[8].Value = model.Reserved05;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.Reserved06 != null)
						oneUpdate[9].Value = model.Reserved06;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.Reserved07 != null)
						oneUpdate[10].Value = model.Reserved07;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.UserId != null)
						oneUpdate[11].Value =model.UserId;
					else
						oneUpdate[11].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_HIS_USER_INFO_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedHisUserInfo 
		///Delete Table MED_HIS_USER_INFO by (string USER_ID)
		/// </summary>
		public int DeleteMedHisUserInfo(string USER_ID)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedHisUserInfo");
					if (USER_ID != null)
						oneDelete[0].Value =USER_ID;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_HIS_USER_INFO_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedHisUserInfo 
		///select Table MED_HIS_USER_INFO by (string USER_ID)
		/// </summary>
		public MedHisUserInfo  SelectMedHisUserInfo(string USER_ID)
		{
			MedHisUserInfo model;
			OracleParameter[] parameterValues = GetParameter("SelectMedHisUserInfo");
				parameterValues[0].Value=USER_ID;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_HIS_USER_INFO_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedHisUserInfo();
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
							model.UserImage = oleReader["USER_IMAGE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Reserved04 = DateTime.Parse(oleReader["RESERVED04"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved05 = DateTime.Parse(oleReader["RESERVED05"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved06 = oleReader["RESERVED06"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Reserved07 = oleReader["RESERVED07"].ToString().Trim() ;
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
		public List<MedHisUserInfo> SelectMedHisUserInfoList()
		{
			List<MedHisUserInfo> modelList = new List<MedHisUserInfo>();
		    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_HIS_USER_INFO_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedHisUserInfo model = new MedHisUserInfo();
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
							model.UserImage = oleReader["USER_IMAGE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Reserved04 = DateTime.Parse(oleReader["RESERVED04"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved05 = DateTime.Parse(oleReader["RESERVED05"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved06 = oleReader["RESERVED06"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Reserved07 = oleReader["RESERVED07"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
