

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/5/6 15:24:54
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
	/// DAL MedMtrlDict
	/// </summary>
	
	public class DALMedMtrlDict
	{
		private static readonly string MED_MTRL_DICT_Insert_SQL = "INSERT INTO MED_MTRL_DICT (MTRL_CODE,MTRL_NAME,MTRL_SPEC,UNITS,MTRL_CLASS,CODE_IN_HIS,INPUT_CODE) values (@MtrlCode,@MtrlName,@MtrlSpec,@Units,@MtrlClass,@CodeInHis,@InputCode)";
		private static readonly string MED_MTRL_DICT_Update_SQL = "UPDATE MED_MTRL_DICT SET MTRL_CODE=@MtrlCode,MTRL_NAME=@MtrlName,MTRL_SPEC=@MtrlSpec,UNITS=@Units,MTRL_CLASS=@MtrlClass,CODE_IN_HIS=@CodeInHis,INPUT_CODE=@InputCode WHERE  MTRL_CODE=@MtrlCode AND MTRL_SPEC=@MtrlSpec";
		private static readonly string MED_MTRL_DICT_Delete_SQL = "DELETE MED_MTRL_DICT WHERE  MTRL_CODE=@MtrlCode AND MTRL_SPEC=@MtrlSpec";
		private static readonly string MED_MTRL_DICT_Select_SQL = "SELECT MTRL_CODE,MTRL_NAME,MTRL_SPEC,UNITS,MTRL_CLASS,CODE_IN_HIS,INPUT_CODE FROM MED_MTRL_DICT where  MTRL_CODE=@MtrlCode AND MTRL_SPEC=@MtrlSpec";
		private static readonly string MED_MTRL_DICT_Select_ALL_SQL = "SELECT MTRL_CODE,MTRL_NAME,MTRL_SPEC,UNITS,MTRL_CLASS,CODE_IN_HIS,INPUT_CODE FROM MED_MTRL_DICT";
		private static readonly string MED_MTRL_DICT_Insert = "INSERT INTO MED_MTRL_DICT (MTRL_CODE,MTRL_NAME,MTRL_SPEC,UNITS,MTRL_CLASS,CODE_IN_HIS,INPUT_CODE) values (:MtrlCode,:MtrlName,:MtrlSpec,:Units,:MtrlClass,:CodeInHis,:InputCode)";
		private static readonly string MED_MTRL_DICT_Update = "UPDATE MED_MTRL_DICT SET MTRL_CODE=:MtrlCode,MTRL_NAME=:MtrlName,MTRL_SPEC=:MtrlSpec,UNITS=:Units,MTRL_CLASS=:MtrlClass,CODE_IN_HIS=:CodeInHis,INPUT_CODE=:InputCode WHERE  MTRL_CODE=:MtrlCode AND MTRL_SPEC=:MtrlSpec";
		private static readonly string MED_MTRL_DICT_Delete = "DELETE MED_MTRL_DICT WHERE  MTRL_CODE=:MtrlCode AND MTRL_SPEC=:MtrlSpec";
		private static readonly string MED_MTRL_DICT_Select = "SELECT MTRL_CODE,MTRL_NAME,MTRL_SPEC,UNITS,MTRL_CLASS,CODE_IN_HIS,INPUT_CODE FROM MED_MTRL_DICT where  MTRL_CODE=:MtrlCode AND MTRL_SPEC=:MtrlSpec";
		private static readonly string MED_MTRL_DICT_Select_ALL = "SELECT MTRL_CODE,MTRL_NAME,MTRL_SPEC,UNITS,MTRL_CLASS,CODE_IN_HIS,INPUT_CODE FROM MED_MTRL_DICT";
		
		public DALMedMtrlDict ()
		{
		}
		
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedMtrlDict SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedMtrlDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@MtrlCode",SqlDbType.VarChar),
							new SqlParameter("@MtrlName",SqlDbType.VarChar),
							new SqlParameter("@MtrlSpec",SqlDbType.VarChar),
							new SqlParameter("@Units",SqlDbType.VarChar),
							new SqlParameter("@MtrlClass",SqlDbType.VarChar),
							new SqlParameter("@CodeInHis",SqlDbType.VarChar),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedMtrlDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@MtrlCode",SqlDbType.VarChar),
							new SqlParameter("@MtrlName",SqlDbType.VarChar),
							new SqlParameter("@MtrlSpec",SqlDbType.VarChar),
							new SqlParameter("@Units",SqlDbType.VarChar),
							new SqlParameter("@MtrlClass",SqlDbType.VarChar),
							new SqlParameter("@CodeInHis",SqlDbType.VarChar),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
							new SqlParameter("@MtrlCode",SqlDbType.VarChar),
							new SqlParameter("@MtrlSpec",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedMtrlDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@MtrlCode",SqlDbType.VarChar),
							new SqlParameter("@MtrlSpec",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedMtrlDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@MtrlCode",SqlDbType.VarChar),
							new SqlParameter("@MtrlSpec",SqlDbType.VarChar),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedMtrlDict 
		///Insert Table MED_MTRL_DICT
		/// </summary>
		public int InsertMedMtrlDictSQL(MedMtrlDict model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedMtrlDict");
					if (model.MtrlCode != null)
						oneInert[0].Value = model.MtrlCode;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.MtrlName != null)
						oneInert[1].Value = model.MtrlName;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.MtrlSpec != null)
						oneInert[2].Value = model.MtrlSpec;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.Units != null)
						oneInert[3].Value = model.Units;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.MtrlClass != null)
						oneInert[4].Value = model.MtrlClass;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.CodeInHis != null)
						oneInert[5].Value = model.CodeInHis;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.InputCode != null)
						oneInert[6].Value = model.InputCode;
					else
						oneInert[6].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_MTRL_DICT_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedMtrlDict 
		///Update Table     MED_MTRL_DICT
		/// </summary>
		public int UpdateMedMtrlDictSQL(MedMtrlDict model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedMtrlDict");
					if (model.MtrlCode != null)
						oneUpdate[0].Value = model.MtrlCode;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.MtrlName != null)
						oneUpdate[1].Value = model.MtrlName;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.MtrlSpec != null)
						oneUpdate[2].Value = model.MtrlSpec;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.Units != null)
						oneUpdate[3].Value = model.Units;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.MtrlClass != null)
						oneUpdate[4].Value = model.MtrlClass;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.CodeInHis != null)
						oneUpdate[5].Value = model.CodeInHis;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.InputCode != null)
						oneUpdate[6].Value = model.InputCode;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.MtrlCode != null)
						oneUpdate[7].Value =model.MtrlCode;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.MtrlSpec != null)
						oneUpdate[8].Value =model.MtrlSpec;
					else
						oneUpdate[8].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_MTRL_DICT_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedMtrlDict 
		///Delete Table MED_MTRL_DICT by (string MTRL_CODE,string MTRL_SPEC)
		/// </summary>
		public int DeleteMedMtrlDictSQL(string MTRL_CODE,string MTRL_SPEC)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedMtrlDict");
					if (MTRL_CODE != null)
						oneDelete[0].Value =MTRL_CODE;
					else
						oneDelete[0].Value = DBNull.Value;
					if (MTRL_SPEC != null)
						oneDelete[1].Value =MTRL_SPEC;
					else
						oneDelete[1].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_MTRL_DICT_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedMtrlDict 
		///select Table MED_MTRL_DICT by (string MTRL_CODE,string MTRL_SPEC)
		/// </summary>
		public MedMtrlDict  SelectMedMtrlDictSQL(string MTRL_CODE,string MTRL_SPEC)
		{
			MedMtrlDict model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedMtrlDict");
				parameterValues[0].Value=MTRL_CODE;
				parameterValues[1].Value=MTRL_SPEC;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_MTRL_DICT_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedMtrlDict();
						if (!oleReader.IsDBNull(0))
						{
							model.MtrlCode = oleReader["MTRL_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.MtrlName = oleReader["MTRL_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MtrlSpec = oleReader["MTRL_SPEC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.Units = oleReader["UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.MtrlClass = oleReader["MTRL_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.CodeInHis = oleReader["CODE_IN_HIS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
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
		public List<MedMtrlDict> SelectMedMtrlDictListSQL()
		{
			List<MedMtrlDict> modelList = new List<MedMtrlDict>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_MTRL_DICT_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedMtrlDict model = new MedMtrlDict();
						if (!oleReader.IsDBNull(0))
						{
							model.MtrlCode = oleReader["MTRL_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.MtrlName = oleReader["MTRL_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MtrlSpec = oleReader["MTRL_SPEC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.Units = oleReader["UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.MtrlClass = oleReader["MTRL_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.CodeInHis = oleReader["CODE_IN_HIS"].ToString().Trim() ;
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
		
		#region [获取参数]
		/// <summary>
		///获取参数MedMtrlDict
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedMtrlDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":MtrlCode",OracleType.VarChar),
							new OracleParameter(":MtrlName",OracleType.VarChar),
							new OracleParameter(":MtrlSpec",OracleType.VarChar),
							new OracleParameter(":Units",OracleType.VarChar),
							new OracleParameter(":MtrlClass",OracleType.VarChar),
							new OracleParameter(":CodeInHis",OracleType.VarChar),
							new OracleParameter(":InputCode",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedMtrlDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":MtrlCode",OracleType.VarChar),
							new OracleParameter(":MtrlName",OracleType.VarChar),
							new OracleParameter(":MtrlSpec",OracleType.VarChar),
							new OracleParameter(":Units",OracleType.VarChar),
							new OracleParameter(":MtrlClass",OracleType.VarChar),
							new OracleParameter(":CodeInHis",OracleType.VarChar),
							new OracleParameter(":InputCode",OracleType.VarChar),
							new OracleParameter(":MtrlCode",SqlDbType.VarChar),
							new OracleParameter(":MtrlSpec",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedMtrlDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":MtrlCode",OracleType.VarChar),
							new OracleParameter(":MtrlSpec",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedMtrlDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":MtrlCode",OracleType.VarChar),
							new OracleParameter(":MtrlSpec",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedMtrlDict 
		///Insert Table MED_MTRL_DICT
		/// </summary>
		public int InsertMedMtrlDict(MedMtrlDict model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedMtrlDict");
					if (model.MtrlCode != null)
						oneInert[0].Value = model.MtrlCode;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.MtrlName != null)
						oneInert[1].Value = model.MtrlName;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.MtrlSpec != null)
						oneInert[2].Value = model.MtrlSpec;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.Units != null)
						oneInert[3].Value = model.Units;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.MtrlClass != null)
						oneInert[4].Value = model.MtrlClass;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.CodeInHis != null)
						oneInert[5].Value = model.CodeInHis;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.InputCode != null)
						oneInert[6].Value = model.InputCode;
					else
						oneInert[6].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_MTRL_DICT_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedMtrlDict 
		///Update Table     MED_MTRL_DICT
		/// </summary>
		public int UpdateMedMtrlDict(MedMtrlDict model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedMtrlDict");
					if (model.MtrlCode != null)
						oneUpdate[0].Value = model.MtrlCode;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.MtrlName != null)
						oneUpdate[1].Value = model.MtrlName;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.MtrlSpec != null)
						oneUpdate[2].Value = model.MtrlSpec;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.Units != null)
						oneUpdate[3].Value = model.Units;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.MtrlClass != null)
						oneUpdate[4].Value = model.MtrlClass;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.CodeInHis != null)
						oneUpdate[5].Value = model.CodeInHis;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.InputCode != null)
						oneUpdate[6].Value = model.InputCode;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.MtrlCode != null)
						oneUpdate[7].Value =model.MtrlCode;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.MtrlSpec != null)
						oneUpdate[8].Value =model.MtrlSpec;
					else
						oneUpdate[8].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_MTRL_DICT_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedMtrlDict 
		///Delete Table MED_MTRL_DICT by (string MTRL_CODE,string MTRL_SPEC)
		/// </summary>
		public int DeleteMedMtrlDict(string MTRL_CODE,string MTRL_SPEC)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedMtrlDict");
					if (MTRL_CODE != null)
						oneDelete[0].Value =MTRL_CODE;
					else
						oneDelete[0].Value = DBNull.Value;
					if (MTRL_SPEC != null)
						oneDelete[1].Value =MTRL_SPEC;
					else
						oneDelete[1].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_MTRL_DICT_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedMtrlDict 
		///select Table MED_MTRL_DICT by (string MTRL_CODE,string MTRL_SPEC)
		/// </summary>
		public MedMtrlDict  SelectMedMtrlDict(string MTRL_CODE,string MTRL_SPEC)
		{
			MedMtrlDict model;
			OracleParameter[] parameterValues = GetParameter("SelectMedMtrlDict");
				parameterValues[0].Value=MTRL_CODE;
				parameterValues[1].Value=MTRL_SPEC;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_MTRL_DICT_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedMtrlDict();
						if (!oleReader.IsDBNull(0))
						{
							model.MtrlCode = oleReader["MTRL_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.MtrlName = oleReader["MTRL_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MtrlSpec = oleReader["MTRL_SPEC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.Units = oleReader["UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.MtrlClass = oleReader["MTRL_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.CodeInHis = oleReader["CODE_IN_HIS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
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
		public List<MedMtrlDict> SelectMedMtrlDictList()
		{
			List<MedMtrlDict> modelList = new List<MedMtrlDict>();
		    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_MTRL_DICT_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedMtrlDict model = new MedMtrlDict();
						if (!oleReader.IsDBNull(0))
						{
							model.MtrlCode = oleReader["MTRL_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.MtrlName = oleReader["MTRL_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MtrlSpec = oleReader["MTRL_SPEC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.Units = oleReader["UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.MtrlClass = oleReader["MTRL_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.CodeInHis = oleReader["CODE_IN_HIS"].ToString().Trim() ;
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
