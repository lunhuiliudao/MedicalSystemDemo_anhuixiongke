

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/5/6 15:24:37
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
	/// DAL MedDrugNameDict
	/// </summary>
	
	public class DALMedDrugNameDict
	{
		private static readonly string MED_DRUG_NAME_DICT_Insert_SQL = "INSERT INTO MED_DRUG_NAME_DICT (DRUG_CODE,DRUG_NAME,STD_INDICATOR,INPUT_CODE) values (@DrugCode,@DrugName,@StdIndicator,@InputCode)";
		private static readonly string MED_DRUG_NAME_DICT_Update_SQL = "UPDATE MED_DRUG_NAME_DICT SET DRUG_CODE=@DrugCode,DRUG_NAME=@DrugName,STD_INDICATOR=@StdIndicator,INPUT_CODE=@InputCode WHERE  DRUG_CODE=@DrugCode AND DRUG_NAME=@DrugName";
		private static readonly string MED_DRUG_NAME_DICT_Delete_SQL = "DELETE MED_DRUG_NAME_DICT WHERE  DRUG_CODE=@DrugCode AND DRUG_NAME=@DrugName";
		private static readonly string MED_DRUG_NAME_DICT_Select_SQL = "SELECT DRUG_CODE,DRUG_NAME,STD_INDICATOR,INPUT_CODE FROM MED_DRUG_NAME_DICT where  DRUG_CODE=@DrugCode AND DRUG_NAME=@DrugName";
		private static readonly string MED_DRUG_NAME_DICT_Select_ALL_SQL = "SELECT DRUG_CODE,DRUG_NAME,STD_INDICATOR,INPUT_CODE FROM MED_DRUG_NAME_DICT";
		private static readonly string MED_DRUG_NAME_DICT_Insert = "INSERT INTO MED_DRUG_NAME_DICT (DRUG_CODE,DRUG_NAME,STD_INDICATOR,INPUT_CODE) values (:DrugCode,:DrugName,:StdIndicator,:InputCode)";
		private static readonly string MED_DRUG_NAME_DICT_Update = "UPDATE MED_DRUG_NAME_DICT SET DRUG_CODE=:DrugCode,DRUG_NAME=:DrugName,STD_INDICATOR=:StdIndicator,INPUT_CODE=:InputCode WHERE  DRUG_CODE=:DrugCode AND DRUG_NAME=:DrugName";
		private static readonly string MED_DRUG_NAME_DICT_Delete = "DELETE MED_DRUG_NAME_DICT WHERE  DRUG_CODE=:DrugCode AND DRUG_NAME=:DrugName";
		private static readonly string MED_DRUG_NAME_DICT_Select = "SELECT DRUG_CODE,DRUG_NAME,STD_INDICATOR,INPUT_CODE FROM MED_DRUG_NAME_DICT where  DRUG_CODE=:DrugCode AND DRUG_NAME=:DrugName";
		private static readonly string MED_DRUG_NAME_DICT_Select_ALL = "SELECT DRUG_CODE,DRUG_NAME,STD_INDICATOR,INPUT_CODE FROM MED_DRUG_NAME_DICT";
		
		public DALMedDrugNameDict ()
		{
		}
		
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedDrugNameDict SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedDrugNameDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DrugCode",SqlDbType.VarChar),
							new SqlParameter("@DrugName",SqlDbType.VarChar),
							new SqlParameter("@StdIndicator",SqlDbType.Decimal),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedDrugNameDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DrugCode",SqlDbType.VarChar),
							new SqlParameter("@DrugName",SqlDbType.VarChar),
							new SqlParameter("@StdIndicator",SqlDbType.Decimal),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
							new SqlParameter("@DrugCode",SqlDbType.VarChar),
							new SqlParameter("@DrugName",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedDrugNameDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DrugCode",SqlDbType.VarChar),
							new SqlParameter("@DrugName",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedDrugNameDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DrugCode",SqlDbType.VarChar),
							new SqlParameter("@DrugName",SqlDbType.VarChar),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedDrugNameDict 
		///Insert Table MED_DRUG_NAME_DICT
		/// </summary>
		public int InsertMedDrugNameDictSQL(MedDrugNameDict model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedDrugNameDict");
					if (model.DrugCode != null)
						oneInert[0].Value = model.DrugCode;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.DrugName != null)
						oneInert[1].Value = model.DrugName;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.StdIndicator.ToString() != null)
						oneInert[2].Value = model.StdIndicator.ToString();
					else
						oneInert[2].Value = DBNull.Value;
					if (model.InputCode != null)
						oneInert[3].Value = model.InputCode;
					else
						oneInert[3].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_DRUG_NAME_DICT_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedDrugNameDict 
		///Update Table     MED_DRUG_NAME_DICT
		/// </summary>
		public int UpdateMedDrugNameDictSQL(MedDrugNameDict model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedDrugNameDict");
					if (model.DrugCode != null)
						oneUpdate[0].Value = model.DrugCode;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.DrugName != null)
						oneUpdate[1].Value = model.DrugName;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.StdIndicator.ToString() != null)
						oneUpdate[2].Value = model.StdIndicator.ToString();
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.InputCode != null)
						oneUpdate[3].Value = model.InputCode;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.DrugCode != null)
						oneUpdate[4].Value =model.DrugCode;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.DrugName != null)
						oneUpdate[5].Value =model.DrugName;
					else
						oneUpdate[5].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_DRUG_NAME_DICT_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedDrugNameDict 
		///Delete Table MED_DRUG_NAME_DICT by (string DRUG_CODE,string DRUG_NAME)
		/// </summary>
		public int DeleteMedDrugNameDictSQL(string DRUG_CODE,string DRUG_NAME)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedDrugNameDict");
					if (DRUG_CODE != null)
						oneDelete[0].Value =DRUG_CODE;
					else
						oneDelete[0].Value = DBNull.Value;
					if (DRUG_NAME != null)
						oneDelete[1].Value =DRUG_NAME;
					else
						oneDelete[1].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_DRUG_NAME_DICT_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedDrugNameDict 
		///select Table MED_DRUG_NAME_DICT by (string DRUG_CODE,string DRUG_NAME)
		/// </summary>
		public MedDrugNameDict  SelectMedDrugNameDictSQL(string DRUG_CODE,string DRUG_NAME)
		{
			MedDrugNameDict model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedDrugNameDict");
				parameterValues[0].Value=DRUG_CODE;
				parameterValues[1].Value=DRUG_NAME;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_DRUG_NAME_DICT_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedDrugNameDict();
						if (!oleReader.IsDBNull(0))
						{
							model.DrugCode = oleReader["DRUG_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.DrugName = oleReader["DRUG_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.StdIndicator = decimal.Parse(oleReader["STD_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.InputCode = oleReader["INPUT_CODE"].ToString().Trim() ;
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
		public List<MedDrugNameDict> SelectMedDrugNameDictListSQL()
		{
			List<MedDrugNameDict> modelList = new List<MedDrugNameDict>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_DRUG_NAME_DICT_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedDrugNameDict model = new MedDrugNameDict();
						if (!oleReader.IsDBNull(0))
						{
							model.DrugCode = oleReader["DRUG_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.DrugName = oleReader["DRUG_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.StdIndicator = decimal.Parse(oleReader["STD_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.InputCode = oleReader["INPUT_CODE"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [获取参数]
		/// <summary>
		///获取参数MedDrugNameDict
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedDrugNameDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DrugCode",OracleType.VarChar),
							new OracleParameter(":DrugName",OracleType.VarChar),
							new OracleParameter(":StdIndicator",OracleType.Number),
							new OracleParameter(":InputCode",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedDrugNameDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DrugCode",OracleType.VarChar),
							new OracleParameter(":DrugName",OracleType.VarChar),
							new OracleParameter(":StdIndicator",OracleType.Number),
							new OracleParameter(":InputCode",OracleType.VarChar),
							new OracleParameter(":DrugCode",SqlDbType.VarChar),
							new OracleParameter(":DrugName",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedDrugNameDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DrugCode",OracleType.VarChar),
							new OracleParameter(":DrugName",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedDrugNameDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DrugCode",OracleType.VarChar),
							new OracleParameter(":DrugName",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedDrugNameDict 
		///Insert Table MED_DRUG_NAME_DICT
		/// </summary>
		public int InsertMedDrugNameDict(MedDrugNameDict model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedDrugNameDict");
					if (model.DrugCode != null)
						oneInert[0].Value = model.DrugCode;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.DrugName != null)
						oneInert[1].Value = model.DrugName;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.StdIndicator.ToString() != null)
						oneInert[2].Value = model.StdIndicator.ToString();
					else
						oneInert[2].Value = DBNull.Value;
					if (model.InputCode != null)
						oneInert[3].Value = model.InputCode;
					else
						oneInert[3].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_DRUG_NAME_DICT_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedDrugNameDict 
		///Update Table     MED_DRUG_NAME_DICT
		/// </summary>
		public int UpdateMedDrugNameDict(MedDrugNameDict model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedDrugNameDict");
					if (model.DrugCode != null)
						oneUpdate[0].Value = model.DrugCode;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.DrugName != null)
						oneUpdate[1].Value = model.DrugName;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.StdIndicator.ToString() != null)
						oneUpdate[2].Value = model.StdIndicator.ToString();
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.InputCode != null)
						oneUpdate[3].Value = model.InputCode;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.DrugCode != null)
						oneUpdate[4].Value =model.DrugCode;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.DrugName != null)
						oneUpdate[5].Value =model.DrugName;
					else
						oneUpdate[5].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_DRUG_NAME_DICT_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedDrugNameDict 
		///Delete Table MED_DRUG_NAME_DICT by (string DRUG_CODE,string DRUG_NAME)
		/// </summary>
		public int DeleteMedDrugNameDict(string DRUG_CODE,string DRUG_NAME)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedDrugNameDict");
					if (DRUG_CODE != null)
						oneDelete[0].Value =DRUG_CODE;
					else
						oneDelete[0].Value = DBNull.Value;
					if (DRUG_NAME != null)
						oneDelete[1].Value =DRUG_NAME;
					else
						oneDelete[1].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_DRUG_NAME_DICT_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedDrugNameDict 
		///select Table MED_DRUG_NAME_DICT by (string DRUG_CODE,string DRUG_NAME)
		/// </summary>
		public MedDrugNameDict  SelectMedDrugNameDict(string DRUG_CODE,string DRUG_NAME)
		{
			MedDrugNameDict model;
			OracleParameter[] parameterValues = GetParameter("SelectMedDrugNameDict");
				parameterValues[0].Value=DRUG_CODE;
				parameterValues[1].Value=DRUG_NAME;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_DRUG_NAME_DICT_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedDrugNameDict();
						if (!oleReader.IsDBNull(0))
						{
							model.DrugCode = oleReader["DRUG_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.DrugName = oleReader["DRUG_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.StdIndicator = decimal.Parse(oleReader["STD_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.InputCode = oleReader["INPUT_CODE"].ToString().Trim() ;
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
		public List<MedDrugNameDict> SelectMedDrugNameDictList()
		{
			List<MedDrugNameDict> modelList = new List<MedDrugNameDict>();
		    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_DRUG_NAME_DICT_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedDrugNameDict model = new MedDrugNameDict();
						if (!oleReader.IsDBNull(0))
						{
							model.DrugCode = oleReader["DRUG_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.DrugName = oleReader["DRUG_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.StdIndicator = decimal.Parse(oleReader["STD_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
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
