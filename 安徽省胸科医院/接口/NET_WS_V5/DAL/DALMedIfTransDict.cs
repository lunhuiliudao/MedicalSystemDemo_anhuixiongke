

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 21:56:35
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
using InitDocare;
namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedIfTransDict
	/// </summary>
	
	public partial class DALMedIfTransDict
	{
		
		private static readonly string MED_IF_TRANS_DICT_Insert_SQL = "INSERT INTO MED_IF_TRANS_DICT (TRANS_NAME,DBMS,SERVER_NAME,DATA_BASE,LOG_ID,LOG_PASS,NLS_LANG,DBPARM,MEMO) values (@TransName,@Dbms,@ServerName,@Database,@LogId,@LogPass,@NlsLang,@Dbparm,@Memo)";
        private static readonly string MED_IF_TRANS_DICT_Update_SQL = "UPDATE MED_IF_TRANS_DICT SET TRANS_NAME=@TransName,DBMS=@Dbms,SERVER_NAME=@ServerName,DATA_BASE=@Database,LOG_ID=@LogId,LOG_PASS=@LogPass,NLS_LANG=@NlsLang,DBPARM=@Dbparm,MEMO=@Memo WHERE TRANS_NAME=@NlsLang1";
		private static readonly string MED_IF_TRANS_DICT_Delete_SQL = "Delete MED_IF_TRANS_DICT WHERE TRANS_NAME=@TransName";
        private static readonly string MED_IF_TRANS_DICT_Select_SQL = "SELECT TRANS_NAME,DBMS,SERVER_NAME,DATA_BASE,LOG_ID,LOG_PASS,NLS_LANG,DBPARM,MEMO FROM MED_IF_TRANS_DICT where TRANS_NAME=@TransName";
        private static readonly string MED_IF_TRANS_DICT_Select_ALL_SQL = "SELECT TRANS_NAME,DBMS,SERVER_NAME,DATA_BASE,LOG_ID,LOG_PASS,NLS_LANG,DBPARM,MEMO FROM MED_IF_TRANS_DICT";
		private static readonly string MED_IF_TRANS_DICT_Insert = "INSERT INTO MED_IF_TRANS_DICT (TRANS_NAME,DBMS,SERVER_NAME,DATABASE,LOG_ID,LOG_PASS,NLS_LANG,DBPARM,MEMO) values (:TransName,:Dbms,:ServerName,:Database,:LogId,:LogPass,:NlsLang,:Dbparm,:Memo)";
        private static readonly string MED_IF_TRANS_DICT_Update = "UPDATE MED_IF_TRANS_DICT SET TRANS_NAME=:TransName,DBMS=:Dbms,SERVER_NAME=:ServerName,DATABASE=:Database,LOG_ID=:LogId,LOG_PASS=:LogPass,NLS_LANG=:NlsLang,DBPARM=:Dbparm,MEMO=:Memo WHERE TRANS_NAME=:NlsLang";
		private static readonly string MED_IF_TRANS_DICT_Delete = "Delete MED_IF_TRANS_DICT WHERE TRANS_NAME=:TransName";
		private static readonly string MED_IF_TRANS_DICT_Select = "SELECT TRANS_NAME,DBMS,SERVER_NAME,DATABASE,LOG_ID,LOG_PASS,NLS_LANG,DBPARM,MEMO FROM MED_IF_TRANS_DICT where TRANS_NAME=:TransName";
		private static readonly string MED_IF_TRANS_DICT_Select_ALL = "SELECT TRANS_NAME,DBMS,SERVER_NAME,DATABASE,LOG_ID,LOG_PASS,NLS_LANG,DBPARM,MEMO FROM MED_IF_TRANS_DICT";
		public DALMedIfTransDict ()
		{
		}
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedIfTransDict SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedIfTransDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@TransName",SqlDbType.VarChar),
							new SqlParameter("@Dbms",SqlDbType.VarChar),
							new SqlParameter("@ServerName",SqlDbType.VarChar),
							new SqlParameter("@Database",SqlDbType.VarChar),
							new SqlParameter("@LogId",SqlDbType.VarChar),
							new SqlParameter("@LogPass",SqlDbType.VarChar),
							new SqlParameter("@NlsLang",SqlDbType.VarChar),
							new SqlParameter("@Dbparm",SqlDbType.VarChar),
							new SqlParameter("@Memo",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedIfTransDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@TransName",SqlDbType.VarChar),
							new SqlParameter("@Dbms",SqlDbType.VarChar),
							new SqlParameter("@ServerName",SqlDbType.VarChar),
							new SqlParameter("@Database",SqlDbType.VarChar),
							new SqlParameter("@LogId",SqlDbType.VarChar),
							new SqlParameter("@LogPass",SqlDbType.VarChar),
							new SqlParameter("@NlsLang",SqlDbType.VarChar),
							new SqlParameter("@Dbparm",SqlDbType.VarChar),
							new SqlParameter("@Memo",SqlDbType.VarChar),
							new SqlParameter("@NlsLang1",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedIfTransDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@TransName",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedIfTransDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@TransName",SqlDbType.VarChar),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedIfTransDict 
		///Insert Table MED_IF_TRANS_DICT
		/// </summary>
		public int InsertMedIfTransDictSQL(MedIfTransDict model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedIfTransDict");
					if (model.TransName != null)
						oneInert[0].Value = model.TransName;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.Dbms != null)
						oneInert[1].Value = model.Dbms;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.ServerName != null)
						oneInert[2].Value = model.ServerName;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.Database != null)
						oneInert[3].Value = model.Database;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.LogId != null)
						oneInert[4].Value = model.LogId;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.LogPass != null)
						oneInert[5].Value = model.LogPass;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.NlsLang != null)
						oneInert[6].Value = model.NlsLang;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.Dbparm != null)
						oneInert[7].Value = model.Dbparm;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.Memo != null)
						oneInert[8].Value = model.Memo;
					else
						oneInert[8].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_IF_TRANS_DICT_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedIfTransDict 
		///Update Table     MED_IF_TRANS_DICT
		/// </summary>
		public int UpdateMedIfTransDictSQL(MedIfTransDict model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedIfTransDict");
					if (model.TransName != null)
						oneUpdate[0].Value = model.TransName;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.Dbms != null)
						oneUpdate[1].Value = model.Dbms.ToString();
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.ServerName != null)
						oneUpdate[2].Value = model.ServerName;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.Database != null)
						oneUpdate[3].Value = model.Database;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.LogId != null)
						oneUpdate[4].Value = model.LogId;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.LogPass != null)
						oneUpdate[5].Value = model.LogPass;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.NlsLang != null)
						oneUpdate[6].Value = model.NlsLang;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.Dbparm != null)
						oneUpdate[7].Value = model.Dbparm;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.Memo != null)
						oneUpdate[8].Value = model.Memo;
					else
						oneUpdate[8].Value = DBNull.Value;
                    if (model.NlsLang != null)
						oneUpdate[9].Value =model.NlsLang;
					else
						oneUpdate[9].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_IF_TRANS_DICT_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedIfTransDict 
		///Delete Table MED_IF_TRANS_DICT by (string TRANS_NAME)
		/// </summary>
		public int DeleteMedIfTransDictSQL(string TRANS_NAME)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedIfTransDict");
					if (TRANS_NAME != null)
						oneDelete[0].Value =TRANS_NAME;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_IF_TRANS_DICT_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedIfTransDict 
		///select Table MED_IF_TRANS_DICT by (string TRANS_NAME)
		/// </summary>
		public MedIfTransDict  SelectMedIfTransDictSQL(string TRANS_NAME)
		{
			MedIfTransDict model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedIfTransDict");
				parameterValues[0].Value=TRANS_NAME;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_IF_TRANS_DICT_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedIfTransDict();
						if (!oleReader.IsDBNull(0))
						{
							model.TransName = oleReader["TRANS_NAME"].ToString().Trim() ;
						}
					 
						if (!oleReader.IsDBNull(2))
						{
							model.ServerName = oleReader["SERVER_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.Database = oleReader["DATA_BASE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.LogId = oleReader["LOG_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.LogPass = oleReader["LOG_PASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.NlsLang = oleReader["NLS_LANG"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Dbparm = oleReader["DBPARM"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Memo = oleReader["MEMO"].ToString().Trim() ;
						}

                        if (oleReader["DBMS"].ToString().Trim() == "SQLSERVER")
                            model.Dbms = EnumDataBase.SQLSERVER;
                        else if (oleReader["DBMS"].ToString().Trim() == "ORACLE")
                            model.Dbms = EnumDataBase.ORACLE;
                        else if (oleReader["DBMS"].ToString().Trim() == "ODBC")
                            model.Dbms = EnumDataBase.ODBC;
                        else if (oleReader["DBMS"].ToString().Trim() == "OLEDB")
                            model.Dbms = EnumDataBase.OLEDB;
                        else if (oleReader["DBMS"].ToString().Trim() == "MYSQL")
                            model.Dbms = EnumDataBase.MYSQL;
                        else
                            model.Dbms = EnumDataBase.Undefined;
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
		public List<MedIfTransDict> SelectMedIfTransDictListSQL()
		{
			List<MedIfTransDict> modelList = new List<MedIfTransDict>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_IF_TRANS_DICT_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedIfTransDict model = new MedIfTransDict();
						if (!oleReader.IsDBNull(0))
						{
							model.TransName = oleReader["TRANS_NAME"].ToString().Trim() ;
						}
						 
						if (!oleReader.IsDBNull(2))
						{
							model.ServerName = oleReader["SERVER_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
                            model.Database = oleReader["DATA_BASE"].ToString().Trim();
						}
						if (!oleReader.IsDBNull(4))
						{
							model.LogId = oleReader["LOG_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.LogPass = oleReader["LOG_PASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.NlsLang = oleReader["NLS_LANG"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Dbparm = oleReader["DBPARM"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Memo = oleReader["MEMO"].ToString().Trim() ;
						}

                        if (oleReader["DBMS"].ToString().Trim() == "SQLSERVER")
                            model.Dbms = EnumDataBase.SQLSERVER;
                        else if (oleReader["DBMS"].ToString().Trim() == "ORACLE")
                            model.Dbms = EnumDataBase.ORACLE;
                        else if (oleReader["DBMS"].ToString().Trim() == "ODBC")
                            model.Dbms = EnumDataBase.ODBC;
                        else if (oleReader["DBMS"].ToString().Trim() == "OLEDB")
                            model.Dbms = EnumDataBase.OLEDB;
                        else if (oleReader["DBMS"].ToString().Trim() == "MYSQL")
                            model.Dbms = EnumDataBase.MYSQL;
                        else
                            model.Dbms = EnumDataBase.Undefined;
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [获取参数]
		/// <summary>
		///获取参数MedIfTransDict
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedIfTransDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":TransName",OracleType.VarChar),
							new OracleParameter(":Dbms",OracleType.VarChar),
							new OracleParameter(":ServerName",OracleType.VarChar),
							new OracleParameter(":Database",OracleType.VarChar),
							new OracleParameter(":LogId",OracleType.VarChar),
							new OracleParameter(":LogPass",OracleType.VarChar),
							new OracleParameter(":NlsLang",OracleType.VarChar),
							new OracleParameter(":Dbparm",OracleType.VarChar),
							new OracleParameter(":Memo",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedIfTransDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":TransName",OracleType.VarChar),
							new OracleParameter(":Dbms",OracleType.VarChar),
							new OracleParameter(":ServerName",OracleType.VarChar),
							new OracleParameter(":Database",OracleType.VarChar),
							new OracleParameter(":LogId",OracleType.VarChar),
							new OracleParameter(":LogPass",OracleType.VarChar),
							new OracleParameter(":NlsLang",OracleType.VarChar),
							new OracleParameter(":Dbparm",OracleType.VarChar),
							new OracleParameter(":Memo",OracleType.VarChar),
							new OracleParameter(":NlsLang",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedIfTransDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":TransName",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedIfTransDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":TransName",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedIfTransDict 
		///Insert Table MED_IF_TRANS_DICT
		/// </summary>
		public int InsertMedIfTransDict(MedIfTransDict model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedIfTransDict");
					if (model.TransName != null)
						oneInert[0].Value = model.TransName;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.Dbms != null)
						oneInert[1].Value = model.Dbms;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.ServerName != null)
						oneInert[2].Value = model.ServerName;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.Database != null)
						oneInert[3].Value = model.Database;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.LogId != null)
						oneInert[4].Value = model.LogId;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.LogPass != null)
						oneInert[5].Value = model.LogPass;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.NlsLang != null)
						oneInert[6].Value = model.NlsLang;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.Dbparm != null)
						oneInert[7].Value = model.Dbparm;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.Memo != null)
						oneInert[8].Value = model.Memo;
					else
						oneInert[8].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_IF_TRANS_DICT_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedIfTransDict 
		///Update Table     MED_IF_TRANS_DICT
		/// </summary>
		public int UpdateMedIfTransDict(MedIfTransDict model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedIfTransDict");
					if (model.TransName != null)
						oneUpdate[0].Value = model.TransName;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.Dbms != null)
						oneUpdate[1].Value = model.Dbms;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.ServerName != null)
						oneUpdate[2].Value = model.ServerName;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.Database != null)
						oneUpdate[3].Value = model.Database;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.LogId != null)
						oneUpdate[4].Value = model.LogId;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.LogPass != null)
						oneUpdate[5].Value = model.LogPass;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.NlsLang != null)
						oneUpdate[6].Value = model.NlsLang;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.Dbparm != null)
						oneUpdate[7].Value = model.Dbparm;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.Memo != null)
						oneUpdate[8].Value = model.Memo;
					else
						oneUpdate[8].Value = DBNull.Value;
                    if (model.NlsLang != null)
                        oneUpdate[9].Value = model.NlsLang;
                    else
                        oneUpdate[9].Value = DBNull.Value;

                    LogHelper.LogWrite(oneUpdate, MED_IF_TRANS_DICT_Update);
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_IF_TRANS_DICT_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedIfTransDict 
		///Delete Table MED_IF_TRANS_DICT by (string TRANS_NAME)
		/// </summary>
		public int DeleteMedIfTransDict(string TRANS_NAME)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedIfTransDict");
					if (TRANS_NAME != null)
						oneDelete[0].Value =TRANS_NAME;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_IF_TRANS_DICT_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedIfTransDict 
		///select Table MED_IF_TRANS_DICT by (string TRANS_NAME)
		/// </summary>
		public MedIfTransDict  SelectMedIfTransDict(string TRANS_NAME)
		{
			MedIfTransDict model;
			OracleParameter[] parameterValues = GetParameter("SelectMedIfTransDict");
				parameterValues[0].Value=TRANS_NAME;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_IF_TRANS_DICT_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedIfTransDict();
						if (!oleReader.IsDBNull(0))
						{
							model.TransName = oleReader["TRANS_NAME"].ToString().Trim() ;
						}
					 
						if (!oleReader.IsDBNull(2))
						{
							model.ServerName = oleReader["SERVER_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.Database = oleReader["DATABASE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.LogId = oleReader["LOG_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.LogPass = oleReader["LOG_PASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.NlsLang = oleReader["NLS_LANG"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Dbparm = oleReader["DBPARM"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Memo = oleReader["MEMO"].ToString().Trim() ;
						}

                        if (oleReader["DBMS"].ToString().Trim() == "SQLSERVER")
                            model.Dbms = EnumDataBase.SQLSERVER;
                        else if (oleReader["DBMS"].ToString().Trim() == "ORACLE")
                            model.Dbms = EnumDataBase.ORACLE;
                        else if (oleReader["DBMS"].ToString().Trim() == "ODBC")
                            model.Dbms = EnumDataBase.ODBC;
                        else if (oleReader["DBMS"].ToString().Trim() == "OLEDB")
                            model.Dbms = EnumDataBase.OLEDB;
                        else if (oleReader["DBMS"].ToString().Trim() == "MYSQL")
                            model.Dbms = EnumDataBase.MYSQL;
                        else
                            model.Dbms = EnumDataBase.Undefined;
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
		public List<MedIfTransDict> SelectMedIfTransDictList()
		{
			List<MedIfTransDict> modelList = new List<MedIfTransDict>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_IF_TRANS_DICT_Select_ALL, null))
			{
                while (oleReader.Read())
                {
                    MedIfTransDict model = new MedIfTransDict();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.TransName = oleReader["TRANS_NAME"].ToString().Trim();
                    }
                    //if (!oleReader.IsDBNull(1))
                    //{
                    //    model.Dbms = oleReader["DBMS"].ToString().Trim() ;
                    //}

                    if (!oleReader.IsDBNull(2))
                    {
                        model.ServerName = oleReader["SERVER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Database = oleReader["DATABASE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.LogId = oleReader["LOG_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.LogPass = oleReader["LOG_PASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.NlsLang = oleReader["NLS_LANG"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Dbparm = oleReader["DBPARM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Memo = oleReader["MEMO"].ToString().Trim();
                    }

                    if (oleReader["DBMS"].ToString().Trim() == "SQLSERVER")
                        model.Dbms = EnumDataBase.SQLSERVER;
                    else if (oleReader["DBMS"].ToString().Trim() == "ORACLE")
                        model.Dbms = EnumDataBase.ORACLE;
                    else if (oleReader["DBMS"].ToString().Trim() == "ODBC")
                        model.Dbms = EnumDataBase.ODBC;
                    else if (oleReader["DBMS"].ToString().Trim() == "OLEDB")
                        model.Dbms = EnumDataBase.OLEDB;
                    else if (oleReader["DBMS"].ToString().Trim() == "MYSQL")
                        model.Dbms = EnumDataBase.MYSQL;
                    else
                        model.Dbms = EnumDataBase.Undefined;

                    modelList.Add(model);
                }
			}
			return modelList;
		}
		#endregion	
		
	}
}
