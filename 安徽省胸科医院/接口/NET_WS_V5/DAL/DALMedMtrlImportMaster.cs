

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/5/6 15:25:37
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
	/// DAL MedMtrlImportMaster
	/// </summary>
	
	public class DALMedMtrlImportMaster
	{
		private static readonly string MED_MTRL_IMPORT_MASTER_Insert_SQL = "INSERT INTO MED_MTRL_IMPORT_MASTER (DOCUMENT_NO,STORAGE_CODE,IMPORT_DATE,SUPPLIER,ACCOUNT_RECEIVABLE,ACCOUNT_PAYED,ADDITIONAL_FEE,IMPORT_CLASS,SUB_STORAGE,ACCOUNT_INDICATOR,MEMOS,OPERATOR) values (@DocumentNo,@StorageCode,@ImportDate,@Supplier,@AccountReceivable,@AccountPayed,@AdditionalFee,@ImportClass,@SubStorage,@AccountIndicator,@Memos,@Operator)";
		private static readonly string MED_MTRL_IMPORT_MASTER_Update_SQL = "UPDATE MED_MTRL_IMPORT_MASTER SET DOCUMENT_NO=@DocumentNo,STORAGE_CODE=@StorageCode,IMPORT_DATE=@ImportDate,SUPPLIER=@Supplier,ACCOUNT_RECEIVABLE=@AccountReceivable,ACCOUNT_PAYED=@AccountPayed,ADDITIONAL_FEE=@AdditionalFee,IMPORT_CLASS=@ImportClass,SUB_STORAGE=@SubStorage,ACCOUNT_INDICATOR=@AccountIndicator,MEMOS=@Memos,OPERATOR=@Operator WHERE  DOCUMENT_NO=@DocumentNo";
		private static readonly string MED_MTRL_IMPORT_MASTER_Delete_SQL = "DELETE MED_MTRL_IMPORT_MASTER WHERE  DOCUMENT_NO=@DocumentNo";
		private static readonly string MED_MTRL_IMPORT_MASTER_Select_SQL = "SELECT DOCUMENT_NO,STORAGE_CODE,IMPORT_DATE,SUPPLIER,ACCOUNT_RECEIVABLE,ACCOUNT_PAYED,ADDITIONAL_FEE,IMPORT_CLASS,SUB_STORAGE,ACCOUNT_INDICATOR,MEMOS,OPERATOR FROM MED_MTRL_IMPORT_MASTER where  DOCUMENT_NO=@DocumentNo";
		private static readonly string MED_MTRL_IMPORT_MASTER_Select_ALL_SQL = "SELECT DOCUMENT_NO,STORAGE_CODE,IMPORT_DATE,SUPPLIER,ACCOUNT_RECEIVABLE,ACCOUNT_PAYED,ADDITIONAL_FEE,IMPORT_CLASS,SUB_STORAGE,ACCOUNT_INDICATOR,MEMOS,OPERATOR FROM MED_MTRL_IMPORT_MASTER";
		private static readonly string MED_MTRL_IMPORT_MASTER_Insert = "INSERT INTO MED_MTRL_IMPORT_MASTER (DOCUMENT_NO,STORAGE_CODE,IMPORT_DATE,SUPPLIER,ACCOUNT_RECEIVABLE,ACCOUNT_PAYED,ADDITIONAL_FEE,IMPORT_CLASS,SUB_STORAGE,ACCOUNT_INDICATOR,MEMOS,OPERATOR) values (:DocumentNo,:StorageCode,:ImportDate,:Supplier,:AccountReceivable,:AccountPayed,:AdditionalFee,:ImportClass,:SubStorage,:AccountIndicator,:Memos,:Operator)";
		private static readonly string MED_MTRL_IMPORT_MASTER_Update = "UPDATE MED_MTRL_IMPORT_MASTER SET DOCUMENT_NO=:DocumentNo,STORAGE_CODE=:StorageCode,IMPORT_DATE=:ImportDate,SUPPLIER=:Supplier,ACCOUNT_RECEIVABLE=:AccountReceivable,ACCOUNT_PAYED=:AccountPayed,ADDITIONAL_FEE=:AdditionalFee,IMPORT_CLASS=:ImportClass,SUB_STORAGE=:SubStorage,ACCOUNT_INDICATOR=:AccountIndicator,MEMOS=:Memos,OPERATOR=:Operator WHERE  DOCUMENT_NO=:DocumentNo";
		private static readonly string MED_MTRL_IMPORT_MASTER_Delete = "DELETE MED_MTRL_IMPORT_MASTER WHERE  DOCUMENT_NO=:DocumentNo";
		private static readonly string MED_MTRL_IMPORT_MASTER_Select = "SELECT DOCUMENT_NO,STORAGE_CODE,IMPORT_DATE,SUPPLIER,ACCOUNT_RECEIVABLE,ACCOUNT_PAYED,ADDITIONAL_FEE,IMPORT_CLASS,SUB_STORAGE,ACCOUNT_INDICATOR,MEMOS,OPERATOR FROM MED_MTRL_IMPORT_MASTER where  DOCUMENT_NO=:DocumentNo";
		private static readonly string MED_MTRL_IMPORT_MASTER_Select_ALL = "SELECT DOCUMENT_NO,STORAGE_CODE,IMPORT_DATE,SUPPLIER,ACCOUNT_RECEIVABLE,ACCOUNT_PAYED,ADDITIONAL_FEE,IMPORT_CLASS,SUB_STORAGE,ACCOUNT_INDICATOR,MEMOS,OPERATOR FROM MED_MTRL_IMPORT_MASTER";
		
		public DALMedMtrlImportMaster ()
		{
		}
		
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedMtrlImportMaster SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedMtrlImportMaster")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DocumentNo",SqlDbType.VarChar),
							new SqlParameter("@StorageCode",SqlDbType.VarChar),
							new SqlParameter("@ImportDate",SqlDbType.DateTime),
							new SqlParameter("@Supplier",SqlDbType.VarChar),
							new SqlParameter("@AccountReceivable",SqlDbType.Decimal),
							new SqlParameter("@AccountPayed",SqlDbType.Decimal),
							new SqlParameter("@AdditionalFee",SqlDbType.Decimal),
							new SqlParameter("@ImportClass",SqlDbType.VarChar),
							new SqlParameter("@SubStorage",SqlDbType.VarChar),
							new SqlParameter("@AccountIndicator",SqlDbType.Decimal),
							new SqlParameter("@Memos",SqlDbType.VarChar),
							new SqlParameter("@Operator",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedMtrlImportMaster")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DocumentNo",SqlDbType.VarChar),
							new SqlParameter("@StorageCode",SqlDbType.VarChar),
							new SqlParameter("@ImportDate",SqlDbType.DateTime),
							new SqlParameter("@Supplier",SqlDbType.VarChar),
							new SqlParameter("@AccountReceivable",SqlDbType.Decimal),
							new SqlParameter("@AccountPayed",SqlDbType.Decimal),
							new SqlParameter("@AdditionalFee",SqlDbType.Decimal),
							new SqlParameter("@ImportClass",SqlDbType.VarChar),
							new SqlParameter("@SubStorage",SqlDbType.VarChar),
							new SqlParameter("@AccountIndicator",SqlDbType.Decimal),
							new SqlParameter("@Memos",SqlDbType.VarChar),
							new SqlParameter("@Operator",SqlDbType.VarChar),
							new SqlParameter("@DocumentNo",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedMtrlImportMaster")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DocumentNo",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedMtrlImportMaster")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DocumentNo",SqlDbType.VarChar),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedMtrlImportMaster 
		///Insert Table MED_MTRL_IMPORT_MASTER
		/// </summary>
		public int InsertMedMtrlImportMasterSQL(MedMtrlImportMaster model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedMtrlImportMaster");
					if (model.DocumentNo != null)
						oneInert[0].Value = model.DocumentNo;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.StorageCode != null)
						oneInert[1].Value = model.StorageCode;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.ImportDate != null)
						oneInert[2].Value = model.ImportDate;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.Supplier != null)
						oneInert[3].Value = model.Supplier;
					else
						oneInert[3].Value = DBNull.Value;
                    if (model.AccountReceivable.ToString() != null)
						oneInert[4].Value = model.AccountReceivable;
					else
						oneInert[4].Value = DBNull.Value;
                    if (model.AccountPayed.ToString() != null)
						oneInert[5].Value = model.AccountPayed;
					else
						oneInert[5].Value = DBNull.Value;
                    if (model.AdditionalFee.ToString() != null)
						oneInert[6].Value = model.AdditionalFee;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.ImportClass != null)
						oneInert[7].Value = model.ImportClass;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.SubStorage != null)
						oneInert[8].Value = model.SubStorage;
					else
						oneInert[8].Value = DBNull.Value;
                    if (model.AccountIndicator.ToString() != null)
						oneInert[9].Value = model.AccountIndicator;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.Memos != null)
						oneInert[10].Value = model.Memos;
					else
						oneInert[10].Value = DBNull.Value;
					if (model.Operator != null)
						oneInert[11].Value = model.Operator;
					else
						oneInert[11].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_MTRL_IMPORT_MASTER_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedMtrlImportMaster 
		///Update Table     MED_MTRL_IMPORT_MASTER
		/// </summary>
		public int UpdateMedMtrlImportMasterSQL(MedMtrlImportMaster model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedMtrlImportMaster");
					if (model.DocumentNo != null)
						oneUpdate[0].Value = model.DocumentNo;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.StorageCode != null)
						oneUpdate[1].Value = model.StorageCode;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.ImportDate != null)
						oneUpdate[2].Value = model.ImportDate;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.Supplier != null)
						oneUpdate[3].Value = model.Supplier;
					else
						oneUpdate[3].Value = DBNull.Value;
                    if (model.AccountReceivable.ToString() != null)
						oneUpdate[4].Value = model.AccountReceivable;
					else
						oneUpdate[4].Value = DBNull.Value;
                    if (model.AccountPayed.ToString() != null)
						oneUpdate[5].Value = model.AccountPayed;
					else
						oneUpdate[5].Value = DBNull.Value;
                    if (model.AdditionalFee.ToString() != null)
						oneUpdate[6].Value = model.AdditionalFee;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.ImportClass != null)
						oneUpdate[7].Value = model.ImportClass;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.SubStorage != null)
						oneUpdate[8].Value = model.SubStorage;
					else
						oneUpdate[8].Value = DBNull.Value;
                    if (model.AccountIndicator.ToString() != null)
						oneUpdate[9].Value = model.AccountIndicator;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.Memos != null)
						oneUpdate[10].Value = model.Memos;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.Operator != null)
						oneUpdate[11].Value = model.Operator;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.DocumentNo != null)
						oneUpdate[12].Value =model.DocumentNo;
					else
						oneUpdate[12].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_MTRL_IMPORT_MASTER_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedMtrlImportMaster 
		///Delete Table MED_MTRL_IMPORT_MASTER by (string DOCUMENT_NO)
		/// </summary>
		public int DeleteMedMtrlImportMasterSQL(string DOCUMENT_NO)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedMtrlImportMaster");
					if (DOCUMENT_NO != null)
						oneDelete[0].Value =DOCUMENT_NO;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_MTRL_IMPORT_MASTER_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedMtrlImportMaster 
		///select Table MED_MTRL_IMPORT_MASTER by (string DOCUMENT_NO)
		/// </summary>
		public MedMtrlImportMaster  SelectMedMtrlImportMasterSQL(string DOCUMENT_NO)
		{
			MedMtrlImportMaster model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedMtrlImportMaster");
				parameterValues[0].Value=DOCUMENT_NO;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_MTRL_IMPORT_MASTER_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedMtrlImportMaster();
						if (!oleReader.IsDBNull(0))
						{
							model.DocumentNo = oleReader["DOCUMENT_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.StorageCode = oleReader["STORAGE_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.ImportDate = DateTime.Parse(oleReader["IMPORT_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.Supplier = oleReader["SUPPLIER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.AccountReceivable = decimal.Parse(oleReader["ACCOUNT_RECEIVABLE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.AccountPayed = decimal.Parse(oleReader["ACCOUNT_PAYED"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.AdditionalFee = decimal.Parse(oleReader["ADDITIONAL_FEE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.ImportClass = oleReader["IMPORT_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.SubStorage = oleReader["SUB_STORAGE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.AccountIndicator = decimal.Parse(oleReader["ACCOUNT_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Memos = oleReader["MEMOS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Operator = oleReader["OPERATOR"].ToString().Trim() ;
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
		public List<MedMtrlImportMaster> SelectMedMtrlImportMasterListSQL()
		{
			List<MedMtrlImportMaster> modelList = new List<MedMtrlImportMaster>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_MTRL_IMPORT_MASTER_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedMtrlImportMaster model = new MedMtrlImportMaster();
						if (!oleReader.IsDBNull(0))
						{
							model.DocumentNo = oleReader["DOCUMENT_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.StorageCode = oleReader["STORAGE_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.ImportDate = DateTime.Parse(oleReader["IMPORT_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.Supplier = oleReader["SUPPLIER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.AccountReceivable = decimal.Parse(oleReader["ACCOUNT_RECEIVABLE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.AccountPayed = decimal.Parse(oleReader["ACCOUNT_PAYED"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.AdditionalFee = decimal.Parse(oleReader["ADDITIONAL_FEE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.ImportClass = oleReader["IMPORT_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.SubStorage = oleReader["SUB_STORAGE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.AccountIndicator = decimal.Parse(oleReader["ACCOUNT_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Memos = oleReader["MEMOS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Operator = oleReader["OPERATOR"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [获取参数]
		/// <summary>
		///获取参数MedMtrlImportMaster
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedMtrlImportMaster")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DocumentNo",OracleType.VarChar),
							new OracleParameter(":StorageCode",OracleType.VarChar),
							new OracleParameter(":ImportDate",OracleType.DateTime),
							new OracleParameter(":Supplier",OracleType.VarChar),
							new OracleParameter(":AccountReceivable",OracleType.Number),
							new OracleParameter(":AccountPayed",OracleType.Number),
							new OracleParameter(":AdditionalFee",OracleType.Number),
							new OracleParameter(":ImportClass",OracleType.VarChar),
							new OracleParameter(":SubStorage",OracleType.VarChar),
							new OracleParameter(":AccountIndicator",OracleType.Number),
							new OracleParameter(":Memos",OracleType.VarChar),
							new OracleParameter(":Operator",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedMtrlImportMaster")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DocumentNo",OracleType.VarChar),
							new OracleParameter(":StorageCode",OracleType.VarChar),
							new OracleParameter(":ImportDate",OracleType.DateTime),
							new OracleParameter(":Supplier",OracleType.VarChar),
							new OracleParameter(":AccountReceivable",OracleType.Number),
							new OracleParameter(":AccountPayed",OracleType.Number),
							new OracleParameter(":AdditionalFee",OracleType.Number),
							new OracleParameter(":ImportClass",OracleType.VarChar),
							new OracleParameter(":SubStorage",OracleType.VarChar),
							new OracleParameter(":AccountIndicator",OracleType.Number),
							new OracleParameter(":Memos",OracleType.VarChar),
							new OracleParameter(":Operator",OracleType.VarChar),
							new OracleParameter(":DocumentNo",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedMtrlImportMaster")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DocumentNo",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedMtrlImportMaster")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DocumentNo",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedMtrlImportMaster 
		///Insert Table MED_MTRL_IMPORT_MASTER
		/// </summary>
		public int InsertMedMtrlImportMaster(MedMtrlImportMaster model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedMtrlImportMaster");
					if (model.DocumentNo != null)
						oneInert[0].Value = model.DocumentNo;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.StorageCode != null)
						oneInert[1].Value = model.StorageCode;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.ImportDate != null)
						oneInert[2].Value = model.ImportDate;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.Supplier != null)
						oneInert[3].Value = model.Supplier;
					else
						oneInert[3].Value = DBNull.Value;
                    if (model.AccountReceivable.ToString() != null)
						oneInert[4].Value = model.AccountReceivable;
					else
						oneInert[4].Value = DBNull.Value;
                    if (model.AccountPayed.ToString() != null)
						oneInert[5].Value = model.AccountPayed;
					else
						oneInert[5].Value = DBNull.Value;
                    if (model.AdditionalFee.ToString() != null)
						oneInert[6].Value = model.AdditionalFee;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.ImportClass != null)
						oneInert[7].Value = model.ImportClass;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.SubStorage != null)
						oneInert[8].Value = model.SubStorage;
					else
						oneInert[8].Value = DBNull.Value;
                    if (model.AccountIndicator.ToString() != null)
						oneInert[9].Value = model.AccountIndicator;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.Memos != null)
						oneInert[10].Value = model.Memos;
					else
						oneInert[10].Value = DBNull.Value;
					if (model.Operator != null)
						oneInert[11].Value = model.Operator;
					else
						oneInert[11].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_MTRL_IMPORT_MASTER_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedMtrlImportMaster 
		///Update Table     MED_MTRL_IMPORT_MASTER
		/// </summary>
		public int UpdateMedMtrlImportMaster(MedMtrlImportMaster model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedMtrlImportMaster");
					if (model.DocumentNo != null)
						oneUpdate[0].Value = model.DocumentNo;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.StorageCode != null)
						oneUpdate[1].Value = model.StorageCode;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.ImportDate != null)
						oneUpdate[2].Value = model.ImportDate;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.Supplier != null)
						oneUpdate[3].Value = model.Supplier;
					else
						oneUpdate[3].Value = DBNull.Value;
                    if (model.AccountReceivable.ToString() != null)
						oneUpdate[4].Value = model.AccountReceivable;
					else
						oneUpdate[4].Value = DBNull.Value;
                    if (model.AccountPayed.ToString() != null)
						oneUpdate[5].Value = model.AccountPayed;
					else
						oneUpdate[5].Value = DBNull.Value;
                    if (model.AdditionalFee.ToString() != null)
						oneUpdate[6].Value = model.AdditionalFee;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.ImportClass != null)
						oneUpdate[7].Value = model.ImportClass;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.SubStorage != null)
						oneUpdate[8].Value = model.SubStorage;
					else
						oneUpdate[8].Value = DBNull.Value;
                    if (model.AccountIndicator.ToString() != null)
						oneUpdate[9].Value = model.AccountIndicator;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.Memos != null)
						oneUpdate[10].Value = model.Memos;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.Operator != null)
						oneUpdate[11].Value = model.Operator;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.DocumentNo != null)
						oneUpdate[12].Value =model.DocumentNo;
					else
						oneUpdate[12].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_MTRL_IMPORT_MASTER_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedMtrlImportMaster 
		///Delete Table MED_MTRL_IMPORT_MASTER by (string DOCUMENT_NO)
		/// </summary>
		public int DeleteMedMtrlImportMaster(string DOCUMENT_NO)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedMtrlImportMaster");
					if (DOCUMENT_NO != null)
						oneDelete[0].Value =DOCUMENT_NO;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_MTRL_IMPORT_MASTER_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedMtrlImportMaster 
		///select Table MED_MTRL_IMPORT_MASTER by (string DOCUMENT_NO)
		/// </summary>
		public MedMtrlImportMaster  SelectMedMtrlImportMaster(string DOCUMENT_NO)
		{
			MedMtrlImportMaster model;
			OracleParameter[] parameterValues = GetParameter("SelectMedMtrlImportMaster");
				parameterValues[0].Value=DOCUMENT_NO;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_MTRL_IMPORT_MASTER_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedMtrlImportMaster();
						if (!oleReader.IsDBNull(0))
						{
							model.DocumentNo = oleReader["DOCUMENT_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.StorageCode = oleReader["STORAGE_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.ImportDate = DateTime.Parse(oleReader["IMPORT_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.Supplier = oleReader["SUPPLIER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.AccountReceivable = decimal.Parse(oleReader["ACCOUNT_RECEIVABLE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.AccountPayed = decimal.Parse(oleReader["ACCOUNT_PAYED"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.AdditionalFee = decimal.Parse(oleReader["ADDITIONAL_FEE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.ImportClass = oleReader["IMPORT_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.SubStorage = oleReader["SUB_STORAGE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.AccountIndicator = decimal.Parse(oleReader["ACCOUNT_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Memos = oleReader["MEMOS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Operator = oleReader["OPERATOR"].ToString().Trim() ;
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
		public List<MedMtrlImportMaster> SelectMedMtrlImportMasterList()
		{
			List<MedMtrlImportMaster> modelList = new List<MedMtrlImportMaster>();
		    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_MTRL_IMPORT_MASTER_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedMtrlImportMaster model = new MedMtrlImportMaster();
						if (!oleReader.IsDBNull(0))
						{
							model.DocumentNo = oleReader["DOCUMENT_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.StorageCode = oleReader["STORAGE_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.ImportDate = DateTime.Parse(oleReader["IMPORT_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.Supplier = oleReader["SUPPLIER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.AccountReceivable = decimal.Parse(oleReader["ACCOUNT_RECEIVABLE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.AccountPayed = decimal.Parse(oleReader["ACCOUNT_PAYED"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.AdditionalFee = decimal.Parse(oleReader["ADDITIONAL_FEE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.ImportClass = oleReader["IMPORT_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.SubStorage = oleReader["SUB_STORAGE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.AccountIndicator = decimal.Parse(oleReader["ACCOUNT_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Memos = oleReader["MEMOS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Operator = oleReader["OPERATOR"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
