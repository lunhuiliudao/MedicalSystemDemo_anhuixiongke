

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 21:56:30
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
	/// DAL MedIfRunConfigDict
	/// </summary>
	
	public partial class DALMedIfRunConfigDict
	{
		
		private static readonly string MED_IF_RUN_CONFIG_DICT_Insert_SQL = "INSERT INTO MED_IF_RUN_CONFIG_DICT (APP_CLASS,SECTION,MAIN_KEY,KEY_VALUE,MEMO) values (@AppClass,@Section,@MainKey,@KeyValue,@Memo)";
        private static readonly string MED_IF_RUN_CONFIG_DICT_Update_SQL = "UPDATE MED_IF_RUN_CONFIG_DICT SET APP_CLASS=@AppClass,SECTION=@Section,MAIN_KEY=@MainKey,KEY_VALUE=@KeyValue,MEMO=@Memo WHERE APP_CLASS=@AppClass AND SECTION=@Section AND MAIN_KEY=@MainKey";
        private static readonly string MED_IF_RUN_CONFIG_DICT_Delete_SQL = "Delete MED_IF_RUN_CONFIG_DICT WHERE APP_CLASS=@AppClass AND SECTION=@Section AND MAIN_KEY=@MainKey";
        private static readonly string MED_IF_RUN_CONFIG_DICT_Select_SQL = "SELECT APP_CLASS,SECTION,MAIN_KEY,KEY_VALUE,MEMO FROM MED_IF_RUN_CONFIG_DICT where APP_CLASS=@AppClass AND SECTION=@Section AND MAIN_KEY=@MainKey";
		private static readonly string MED_IF_RUN_CONFIG_DICT_Select_ALL_SQL = "SELECT APP_CLASS,SECTION,MAIN_KEY,KEY_VALUE,MEMO FROM MED_IF_RUN_CONFIG_DICT";
		private static readonly string MED_IF_RUN_CONFIG_DICT_Insert = "INSERT INTO MED_IF_RUN_CONFIG_DICT (APP_CLASS,SECTION,MAIN_KEY,KEY_VALUE,MEMO) values (:AppClass,:Section,:MainKey,:KeyValue,:Memo)";
        private static readonly string MED_IF_RUN_CONFIG_DICT_Update = "UPDATE MED_IF_RUN_CONFIG_DICT SET APP_CLASS=:AppClass,SECTION=:Section,MAIN_KEY=:MainKey,KEY_VALUE=:KeyValue,MEMO=:Memo WHERE APP_CLASS=:AppClass AND SECTION=:Section AND MAIN_KEY=:MainKey";
        private static readonly string MED_IF_RUN_CONFIG_DICT_Delete = "Delete MED_IF_RUN_CONFIG_DICT WHERE APP_CLASS=:AppClass AND SECTION=:Section AND MAIN_KEY=:MainKey";
        private static readonly string MED_IF_RUN_CONFIG_DICT_Select = "SELECT APP_CLASS,SECTION,MAIN_KEY,KEY_VALUE,MEMO FROM MED_IF_RUN_CONFIG_DICT where APP_CLASS=:AppClass AND SECTION=:Section AND MAIN_KEY=:MainKey";
		private static readonly string MED_IF_RUN_CONFIG_DICT_Select_ALL = "SELECT APP_CLASS,SECTION,MAIN_KEY,KEY_VALUE,MEMO FROM MED_IF_RUN_CONFIG_DICT";
		public DALMedIfRunConfigDict ()
		{
		}
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedIfRunConfigDict SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedIfRunConfigDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@AppClass",SqlDbType.VarChar),
							new SqlParameter("@Section",SqlDbType.VarChar),
							new SqlParameter("@MainKey",SqlDbType.VarChar),
							new SqlParameter("@KeyValue",SqlDbType.VarChar),
							new SqlParameter("@Memo",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedIfRunConfigDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@AppClass",SqlDbType.VarChar),
							new SqlParameter("@Section",SqlDbType.VarChar),
							new SqlParameter("@MainKey",SqlDbType.VarChar),
							new SqlParameter("@KeyValue",SqlDbType.VarChar),
							new SqlParameter("@Memo",SqlDbType.VarChar),
							new SqlParameter("@AppClass",SqlDbType.VarChar),
							new SqlParameter("@Section",SqlDbType.VarChar),
							new SqlParameter("@MainKey",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedIfRunConfigDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@AppClass",SqlDbType.VarChar),
							new SqlParameter("@Section",SqlDbType.VarChar),
							new SqlParameter("@MainKey",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedIfRunConfigDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@AppClass",SqlDbType.VarChar),
							new SqlParameter("@Section",SqlDbType.VarChar),
							new SqlParameter("@MainKey",SqlDbType.VarChar),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedIfRunConfigDict 
		///Insert Table MED_IF_RUN_CONFIG_DICT
		/// </summary>
		public int InsertMedIfRunConfigDictSQL(MedIfRunConfigDict model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedIfRunConfigDict");
					if (model.AppClass != null)
						oneInert[0].Value = model.AppClass;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.Section != null)
						oneInert[1].Value = model.Section;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.MainKey != null)
						oneInert[2].Value = model.MainKey;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.KeyValue != null)
						oneInert[3].Value = model.KeyValue;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.Memo != null)
						oneInert[4].Value = model.Memo;
					else
						oneInert[4].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_IF_RUN_CONFIG_DICT_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedIfRunConfigDict 
		///Update Table     MED_IF_RUN_CONFIG_DICT
		/// </summary>
		public int UpdateMedIfRunConfigDictSQL(MedIfRunConfigDict model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedIfRunConfigDict");
					if (model.AppClass != null)
						oneUpdate[0].Value = model.AppClass;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.Section != null)
						oneUpdate[1].Value = model.Section;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.MainKey != null)
						oneUpdate[2].Value = model.MainKey;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.KeyValue != null)
						oneUpdate[3].Value = model.KeyValue;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.Memo != null)
						oneUpdate[4].Value = model.Memo;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.AppClass != null)
						oneUpdate[5].Value =model.AppClass;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.Section != null)
						oneUpdate[6].Value =model.Section;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.MainKey != null)
						oneUpdate[7].Value =model.MainKey;
					else
						oneUpdate[7].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_IF_RUN_CONFIG_DICT_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedIfRunConfigDict 
		///Delete Table MED_IF_RUN_CONFIG_DICT by (string APP_CLASS,string SECTION,string MAIN_KEY)
		/// </summary>
		public int DeleteMedIfRunConfigDictSQL(string APP_CLASS,string SECTION,string MAIN_KEY)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedIfRunConfigDict");
					if (APP_CLASS != null)
						oneDelete[0].Value =APP_CLASS;
					else
						oneDelete[0].Value = DBNull.Value;
					if (SECTION != null)
						oneDelete[1].Value =SECTION;
					else
						oneDelete[1].Value = DBNull.Value;
					if (MAIN_KEY != null)
						oneDelete[2].Value =MAIN_KEY;
					else
						oneDelete[2].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_IF_RUN_CONFIG_DICT_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedIfRunConfigDict 
		///select Table MED_IF_RUN_CONFIG_DICT by (string APP_CLASS,string SECTION,string MAIN_KEY)
		/// </summary>
		public MedIfRunConfigDict  SelectMedIfRunConfigDictSQL(string APP_CLASS,string SECTION,string MAIN_KEY)
		{
			MedIfRunConfigDict model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedIfRunConfigDict");
				parameterValues[0].Value=APP_CLASS;
				parameterValues[1].Value=SECTION;
				parameterValues[2].Value=MAIN_KEY;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_IF_RUN_CONFIG_DICT_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedIfRunConfigDict();
						if (!oleReader.IsDBNull(0))
						{
							model.AppClass = oleReader["APP_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.Section = oleReader["SECTION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MainKey = oleReader["MAIN_KEY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.KeyValue = oleReader["KEY_VALUE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Memo = oleReader["MEMO"].ToString().Trim() ;
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
		public List<MedIfRunConfigDict> SelectMedIfRunConfigDictListSQL()
		{
			List<MedIfRunConfigDict> modelList = new List<MedIfRunConfigDict>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_IF_RUN_CONFIG_DICT_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedIfRunConfigDict model = new MedIfRunConfigDict();
						if (!oleReader.IsDBNull(0))
						{
							model.AppClass = oleReader["APP_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.Section = oleReader["SECTION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MainKey = oleReader["MAIN_KEY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.KeyValue = oleReader["KEY_VALUE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Memo = oleReader["MEMO"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [获取参数]
		/// <summary>
		///获取参数MedIfRunConfigDict
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedIfRunConfigDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":AppClass",OracleType.VarChar),
							new OracleParameter(":Section",OracleType.VarChar),
							new OracleParameter(":MainKey",OracleType.VarChar),
							new OracleParameter(":KeyValue",OracleType.VarChar),
							new OracleParameter(":Memo",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedIfRunConfigDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":AppClass",OracleType.VarChar),
							new OracleParameter(":Section",OracleType.VarChar),
							new OracleParameter(":MainKey",OracleType.VarChar),
							new OracleParameter(":KeyValue",OracleType.VarChar),
							new OracleParameter(":Memo",OracleType.VarChar),
							new OracleParameter(":AppClass",SqlDbType.VarChar),
							new OracleParameter(":Section",SqlDbType.VarChar),
							new OracleParameter(":MainKey",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedIfRunConfigDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":AppClass",OracleType.VarChar),
							new OracleParameter(":Section",OracleType.VarChar),
							new OracleParameter(":MainKey",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedIfRunConfigDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":AppClass",OracleType.VarChar),
							new OracleParameter(":Section",OracleType.VarChar),
							new OracleParameter(":MainKey",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedIfRunConfigDict 
		///Insert Table MED_IF_RUN_CONFIG_DICT
		/// </summary>
		public int InsertMedIfRunConfigDict(MedIfRunConfigDict model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedIfRunConfigDict");
					if (model.AppClass != null)
						oneInert[0].Value = model.AppClass;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.Section != null)
						oneInert[1].Value = model.Section;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.MainKey != null)
						oneInert[2].Value = model.MainKey;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.KeyValue != null)
						oneInert[3].Value = model.KeyValue;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.Memo != null)
						oneInert[4].Value = model.Memo;
					else
						oneInert[4].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_IF_RUN_CONFIG_DICT_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedIfRunConfigDict 
		///Update Table     MED_IF_RUN_CONFIG_DICT
		/// </summary>
		public int UpdateMedIfRunConfigDict(MedIfRunConfigDict model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedIfRunConfigDict");
					if (model.AppClass != null)
						oneUpdate[0].Value = model.AppClass;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.Section != null)
						oneUpdate[1].Value = model.Section;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.MainKey != null)
						oneUpdate[2].Value = model.MainKey;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.KeyValue != null)
						oneUpdate[3].Value = model.KeyValue;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.Memo != null)
						oneUpdate[4].Value = model.Memo;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.AppClass != null)
						oneUpdate[5].Value =model.AppClass;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.Section != null)
						oneUpdate[6].Value =model.Section;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.MainKey != null)
						oneUpdate[7].Value =model.MainKey;
					else
						oneUpdate[7].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_IF_RUN_CONFIG_DICT_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedIfRunConfigDict 
		///Delete Table MED_IF_RUN_CONFIG_DICT by (string APP_CLASS,string SECTION,string MAIN_KEY)
		/// </summary>
		public int DeleteMedIfRunConfigDict(string APP_CLASS,string SECTION,string MAIN_KEY)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedIfRunConfigDict");
					if (APP_CLASS != null)
						oneDelete[0].Value =APP_CLASS;
					else
						oneDelete[0].Value = DBNull.Value;
					if (SECTION != null)
						oneDelete[1].Value =SECTION;
					else
						oneDelete[1].Value = DBNull.Value;
					if (MAIN_KEY != null)
						oneDelete[2].Value =MAIN_KEY;
					else
						oneDelete[2].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_IF_RUN_CONFIG_DICT_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedIfRunConfigDict 
		///select Table MED_IF_RUN_CONFIG_DICT by (string APP_CLASS,string SECTION,string MAIN_KEY)
		/// </summary>
		public MedIfRunConfigDict  SelectMedIfRunConfigDict(string APP_CLASS,string SECTION,string MAIN_KEY)
		{
			MedIfRunConfigDict model;
			OracleParameter[] parameterValues = GetParameter("SelectMedIfRunConfigDict");
				parameterValues[0].Value=APP_CLASS;
				parameterValues[1].Value=SECTION;
				parameterValues[2].Value=MAIN_KEY;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_IF_RUN_CONFIG_DICT_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedIfRunConfigDict();
						if (!oleReader.IsDBNull(0))
						{
							model.AppClass = oleReader["APP_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.Section = oleReader["SECTION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MainKey = oleReader["MAIN_KEY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.KeyValue = oleReader["KEY_VALUE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Memo = oleReader["MEMO"].ToString().Trim() ;
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
		public List<MedIfRunConfigDict> SelectMedIfRunConfigDictList()
		{
			List<MedIfRunConfigDict> modelList = new List<MedIfRunConfigDict>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_IF_RUN_CONFIG_DICT_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedIfRunConfigDict model = new MedIfRunConfigDict();
						if (!oleReader.IsDBNull(0))
						{
							model.AppClass = oleReader["APP_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.Section = oleReader["SECTION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MainKey = oleReader["MAIN_KEY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.KeyValue = oleReader["KEY_VALUE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Memo = oleReader["MEMO"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
