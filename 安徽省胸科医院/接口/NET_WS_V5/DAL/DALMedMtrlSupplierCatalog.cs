

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/5/6 15:25:05
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
	/// DAL MedMtrlSupplierCatalog
	/// </summary>
	
	public class DALMedMtrlSupplierCatalog
	{
		private static readonly string MED_MTRL_SUPPLIER_CATALOG_Insert_SQL = "INSERT INTO MED_MTRL_SUPPLIER_CATALOG (SUPPLIER_ID,SUPPLIER,SUPPLIER_CLASS,CODE_IN_HIS,INPUT_CODE) values (@SupplierId,@Supplier,@SupplierClass,@CodeInHis,@InputCode)";
		private static readonly string MED_MTRL_SUPPLIER_CATALOG_Update_SQL = "UPDATE MED_MTRL_SUPPLIER_CATALOG SET SUPPLIER_ID=@SupplierId,SUPPLIER=@Supplier,SUPPLIER_CLASS=@SupplierClass,CODE_IN_HIS=@CodeInHis,INPUT_CODE=@InputCode WHERE  SUPPLIER_ID=@SupplierId";
		private static readonly string MED_MTRL_SUPPLIER_CATALOG_Delete_SQL = "DELETE MED_MTRL_SUPPLIER_CATALOG WHERE  SUPPLIER_ID=@SupplierId";
		private static readonly string MED_MTRL_SUPPLIER_CATALOG_Select_SQL = "SELECT SUPPLIER_ID,SUPPLIER,SUPPLIER_CLASS,CODE_IN_HIS,INPUT_CODE FROM MED_MTRL_SUPPLIER_CATALOG where  SUPPLIER_ID=@SupplierId";
		private static readonly string MED_MTRL_SUPPLIER_CATALOG_Select_ALL_SQL = "SELECT SUPPLIER_ID,SUPPLIER,SUPPLIER_CLASS,CODE_IN_HIS,INPUT_CODE FROM MED_MTRL_SUPPLIER_CATALOG";
		private static readonly string MED_MTRL_SUPPLIER_CATALOG_Insert = "INSERT INTO MED_MTRL_SUPPLIER_CATALOG (SUPPLIER_ID,SUPPLIER,SUPPLIER_CLASS,CODE_IN_HIS,INPUT_CODE) values (:SupplierId,:Supplier,:SupplierClass,:CodeInHis,:InputCode)";
		private static readonly string MED_MTRL_SUPPLIER_CATALOG_Update = "UPDATE MED_MTRL_SUPPLIER_CATALOG SET SUPPLIER_ID=:SupplierId,SUPPLIER=:Supplier,SUPPLIER_CLASS=:SupplierClass,CODE_IN_HIS=:CodeInHis,INPUT_CODE=:InputCode WHERE  SUPPLIER_ID=:SupplierId";
		private static readonly string MED_MTRL_SUPPLIER_CATALOG_Delete = "DELETE MED_MTRL_SUPPLIER_CATALOG WHERE  SUPPLIER_ID=:SupplierId";
		private static readonly string MED_MTRL_SUPPLIER_CATALOG_Select = "SELECT SUPPLIER_ID,SUPPLIER,SUPPLIER_CLASS,CODE_IN_HIS,INPUT_CODE FROM MED_MTRL_SUPPLIER_CATALOG where  SUPPLIER_ID=:SupplierId";
		private static readonly string MED_MTRL_SUPPLIER_CATALOG_Select_ALL = "SELECT SUPPLIER_ID,SUPPLIER,SUPPLIER_CLASS,CODE_IN_HIS,INPUT_CODE FROM MED_MTRL_SUPPLIER_CATALOG";
		
		public DALMedMtrlSupplierCatalog ()
		{
		}
		
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedMtrlSupplierCatalog SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedMtrlSupplierCatalog")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@SupplierId",SqlDbType.VarChar),
							new SqlParameter("@Supplier",SqlDbType.VarChar),
							new SqlParameter("@SupplierClass",SqlDbType.VarChar),
							new SqlParameter("@CodeInHis",SqlDbType.VarChar),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedMtrlSupplierCatalog")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@SupplierId",SqlDbType.VarChar),
							new SqlParameter("@Supplier",SqlDbType.VarChar),
							new SqlParameter("@SupplierClass",SqlDbType.VarChar),
							new SqlParameter("@CodeInHis",SqlDbType.VarChar),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
							new SqlParameter("@SupplierId",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedMtrlSupplierCatalog")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@SupplierId",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedMtrlSupplierCatalog")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@SupplierId",SqlDbType.VarChar),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedMtrlSupplierCatalog 
		///Insert Table MED_MTRL_SUPPLIER_CATALOG
		/// </summary>
		public int InsertMedMtrlSupplierCatalogSQL(MedMtrlSupplierCatalog model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedMtrlSupplierCatalog");
					if (model.SupplierId != null)
						oneInert[0].Value = model.SupplierId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.Supplier != null)
						oneInert[1].Value = model.Supplier;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.SupplierClass != null)
						oneInert[2].Value = model.SupplierClass;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.CodeInHis != null)
						oneInert[3].Value = model.CodeInHis;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.InputCode != null)
						oneInert[4].Value = model.InputCode;
					else
						oneInert[4].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_MTRL_SUPPLIER_CATALOG_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedMtrlSupplierCatalog 
		///Update Table     MED_MTRL_SUPPLIER_CATALOG
		/// </summary>
		public int UpdateMedMtrlSupplierCatalogSQL(MedMtrlSupplierCatalog model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedMtrlSupplierCatalog");
					if (model.SupplierId != null)
						oneUpdate[0].Value = model.SupplierId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.Supplier != null)
						oneUpdate[1].Value = model.Supplier;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.SupplierClass != null)
						oneUpdate[2].Value = model.SupplierClass;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.CodeInHis != null)
						oneUpdate[3].Value = model.CodeInHis;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.InputCode != null)
						oneUpdate[4].Value = model.InputCode;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.SupplierId != null)
						oneUpdate[5].Value =model.SupplierId;
					else
						oneUpdate[5].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_MTRL_SUPPLIER_CATALOG_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedMtrlSupplierCatalog 
		///Delete Table MED_MTRL_SUPPLIER_CATALOG by (string SUPPLIER_ID)
		/// </summary>
		public int DeleteMedMtrlSupplierCatalogSQL(string SUPPLIER_ID)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedMtrlSupplierCatalog");
					if (SUPPLIER_ID != null)
						oneDelete[0].Value =SUPPLIER_ID;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_MTRL_SUPPLIER_CATALOG_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedMtrlSupplierCatalog 
		///select Table MED_MTRL_SUPPLIER_CATALOG by (string SUPPLIER_ID)
		/// </summary>
		public MedMtrlSupplierCatalog  SelectMedMtrlSupplierCatalogSQL(string SUPPLIER_ID)
		{
			MedMtrlSupplierCatalog model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedMtrlSupplierCatalog");
				parameterValues[0].Value=SUPPLIER_ID;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_MTRL_SUPPLIER_CATALOG_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedMtrlSupplierCatalog();
						if (!oleReader.IsDBNull(0))
						{
							model.SupplierId = oleReader["SUPPLIER_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.Supplier = oleReader["SUPPLIER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.SupplierClass = oleReader["SUPPLIER_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.CodeInHis = oleReader["CODE_IN_HIS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
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
		public List<MedMtrlSupplierCatalog> SelectMedMtrlSupplierCatalogListSQL()
		{
			List<MedMtrlSupplierCatalog> modelList = new List<MedMtrlSupplierCatalog>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_MTRL_SUPPLIER_CATALOG_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedMtrlSupplierCatalog model = new MedMtrlSupplierCatalog();
						if (!oleReader.IsDBNull(0))
						{
							model.SupplierId = oleReader["SUPPLIER_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.Supplier = oleReader["SUPPLIER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.SupplierClass = oleReader["SUPPLIER_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.CodeInHis = oleReader["CODE_IN_HIS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
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
		///获取参数MedMtrlSupplierCatalog
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedMtrlSupplierCatalog")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":SupplierId",OracleType.VarChar),
							new OracleParameter(":Supplier",OracleType.VarChar),
							new OracleParameter(":SupplierClass",OracleType.VarChar),
							new OracleParameter(":CodeInHis",OracleType.VarChar),
							new OracleParameter(":InputCode",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedMtrlSupplierCatalog")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":SupplierId",OracleType.VarChar),
							new OracleParameter(":Supplier",OracleType.VarChar),
							new OracleParameter(":SupplierClass",OracleType.VarChar),
							new OracleParameter(":CodeInHis",OracleType.VarChar),
							new OracleParameter(":InputCode",OracleType.VarChar),
							new OracleParameter(":SupplierId",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedMtrlSupplierCatalog")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":SupplierId",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedMtrlSupplierCatalog")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":SupplierId",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedMtrlSupplierCatalog 
		///Insert Table MED_MTRL_SUPPLIER_CATALOG
		/// </summary>
		public int InsertMedMtrlSupplierCatalog(MedMtrlSupplierCatalog model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedMtrlSupplierCatalog");
					if (model.SupplierId != null)
						oneInert[0].Value = model.SupplierId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.Supplier != null)
						oneInert[1].Value = model.Supplier;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.SupplierClass != null)
						oneInert[2].Value = model.SupplierClass;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.CodeInHis != null)
						oneInert[3].Value = model.CodeInHis;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.InputCode != null)
						oneInert[4].Value = model.InputCode;
					else
						oneInert[4].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_MTRL_SUPPLIER_CATALOG_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedMtrlSupplierCatalog 
		///Update Table     MED_MTRL_SUPPLIER_CATALOG
		/// </summary>
		public int UpdateMedMtrlSupplierCatalog(MedMtrlSupplierCatalog model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedMtrlSupplierCatalog");
					if (model.SupplierId != null)
						oneUpdate[0].Value = model.SupplierId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.Supplier != null)
						oneUpdate[1].Value = model.Supplier;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.SupplierClass != null)
						oneUpdate[2].Value = model.SupplierClass;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.CodeInHis != null)
						oneUpdate[3].Value = model.CodeInHis;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.InputCode != null)
						oneUpdate[4].Value = model.InputCode;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.SupplierId != null)
						oneUpdate[5].Value =model.SupplierId;
					else
						oneUpdate[5].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_MTRL_SUPPLIER_CATALOG_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedMtrlSupplierCatalog 
		///Delete Table MED_MTRL_SUPPLIER_CATALOG by (string SUPPLIER_ID)
		/// </summary>
		public int DeleteMedMtrlSupplierCatalog(string SUPPLIER_ID)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedMtrlSupplierCatalog");
					if (SUPPLIER_ID != null)
						oneDelete[0].Value =SUPPLIER_ID;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_MTRL_SUPPLIER_CATALOG_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedMtrlSupplierCatalog 
		///select Table MED_MTRL_SUPPLIER_CATALOG by (string SUPPLIER_ID)
		/// </summary>
		public MedMtrlSupplierCatalog  SelectMedMtrlSupplierCatalog(string SUPPLIER_ID)
		{
			MedMtrlSupplierCatalog model;
			OracleParameter[] parameterValues = GetParameter("SelectMedMtrlSupplierCatalog");
				parameterValues[0].Value=SUPPLIER_ID;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_MTRL_SUPPLIER_CATALOG_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedMtrlSupplierCatalog();
						if (!oleReader.IsDBNull(0))
						{
							model.SupplierId = oleReader["SUPPLIER_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.Supplier = oleReader["SUPPLIER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.SupplierClass = oleReader["SUPPLIER_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.CodeInHis = oleReader["CODE_IN_HIS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
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
		public List<MedMtrlSupplierCatalog> SelectMedMtrlSupplierCatalogList()
		{
			List<MedMtrlSupplierCatalog> modelList = new List<MedMtrlSupplierCatalog>();
		    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_MTRL_SUPPLIER_CATALOG_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedMtrlSupplierCatalog model = new MedMtrlSupplierCatalog();
						if (!oleReader.IsDBNull(0))
						{
							model.SupplierId = oleReader["SUPPLIER_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.Supplier = oleReader["SUPPLIER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.SupplierClass = oleReader["SUPPLIER_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.CodeInHis = oleReader["CODE_IN_HIS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
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
