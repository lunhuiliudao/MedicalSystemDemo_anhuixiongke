

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:08:41
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
	/// DAL MedLabTestItems
	/// </summary>
	
	public class DALMedLabTestItems
	{
		
		private static readonly string MED_LAB_TEST_ITEMS_Insert_SQL = "INSERT INTO MED_LAB_TEST_ITEMS (TEST_NO,ITEM_NO,ITEM_NAME,ITEM_CODE) values (@TestNo,@ItemNo,@ItemName,@ItemCode)";
        private static readonly string MED_LAB_TEST_ITEMS_Update_SQL = "UPDATE MED_LAB_TEST_ITEMS SET TEST_NO=@TestNo,ITEM_NO=@ItemNo,ITEM_NAME=@ItemName,ITEM_CODE=@ItemCode WHERE TEST_NO=@TestNo AND ITEM_NO=@ItemNo";
        private static readonly string MED_LAB_TEST_ITEMS_Delete_SQL = "Delete MED_LAB_TEST_ITEMS WHERE TEST_NO=@TestNo AND ITEM_NO=@ItemNo";
        private static readonly string MED_LAB_TEST_ITEMS_Select_SQL = "SELECT TEST_NO,ITEM_NO,ITEM_NAME,ITEM_CODE FROM MED_LAB_TEST_ITEMS where TEST_NO=@TestNo AND ITEM_NO=@ItemNo";
		private static readonly string MED_LAB_TEST_ITEMS_Select_ALL_SQL = "SELECT TEST_NO,ITEM_NO,ITEM_NAME,ITEM_CODE FROM MED_LAB_TEST_ITEMS";
		private static readonly string MED_LAB_TEST_ITEMS_Insert = "INSERT INTO MED_LAB_TEST_ITEMS (TEST_NO,ITEM_NO,ITEM_NAME,ITEM_CODE) values (:TestNo,:ItemNo,:ItemName,:ItemCode)";
        private static readonly string MED_LAB_TEST_ITEMS_Update = "UPDATE MED_LAB_TEST_ITEMS SET TEST_NO=:TestNo,ITEM_NO=:ItemNo,ITEM_NAME=:ItemName,ITEM_CODE=:ItemCode WHERE TEST_NO=:TestNo AND ITEM_NO=:ItemNo";
        private static readonly string MED_LAB_TEST_ITEMS_Delete = "Delete MED_LAB_TEST_ITEMS WHERE TEST_NO=:TestNo AND ITEM_NO=:ItemNo";
        private static readonly string MED_LAB_TEST_ITEMS_Select = "SELECT TEST_NO,ITEM_NO,ITEM_NAME,ITEM_CODE FROM MED_LAB_TEST_ITEMS where TEST_NO=:TestNo AND ITEM_NO=:ItemNo";
		private static readonly string MED_LAB_TEST_ITEMS_Select_ALL = "SELECT TEST_NO,ITEM_NO,ITEM_NAME,ITEM_CODE FROM MED_LAB_TEST_ITEMS";
		public DALMedLabTestItems ()
		{
		}
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedLabTestItems SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedLabTestItems")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@TestNo",SqlDbType.VarChar),
							new SqlParameter("@ItemNo",SqlDbType.Decimal),
							new SqlParameter("@ItemName",SqlDbType.VarChar),
							new SqlParameter("@ItemCode",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedLabTestItems")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@TestNo",SqlDbType.VarChar),
							new SqlParameter("@ItemNo",SqlDbType.Decimal),
							new SqlParameter("@ItemName",SqlDbType.VarChar),
							new SqlParameter("@ItemCode",SqlDbType.VarChar),
							new SqlParameter("@TestNo",SqlDbType.VarChar),
							new SqlParameter("@ItemNo",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedLabTestItems")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@TestNo",SqlDbType.VarChar),
							new SqlParameter("@ItemNo",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "SelectMedLabTestItems")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@TestNo",SqlDbType.VarChar),
							new SqlParameter("@ItemNo",SqlDbType.Decimal),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedLabTestItems 
		///Insert Table MED_LAB_TEST_ITEMS
		/// </summary>
		public int InsertMedLabTestItemsSQL(MedLabTestItems model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedLabTestItems");
					if (model.TestNo != null)
						oneInert[0].Value = model.TestNo;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.ItemNo.ToString() != null)
						oneInert[1].Value = model.ItemNo;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.ItemName != null)
						oneInert[2].Value = model.ItemName;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.ItemCode != null)
						oneInert[3].Value = model.ItemCode;
					else
						oneInert[3].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_LAB_TEST_ITEMS_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedLabTestItems 
		///Update Table     MED_LAB_TEST_ITEMS
		/// </summary>
		public int UpdateMedLabTestItemsSQL(MedLabTestItems model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedLabTestItems");
					if (model.TestNo != null)
						oneUpdate[0].Value = model.TestNo;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.ItemNo.ToString() != null)
						oneUpdate[1].Value = model.ItemNo;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.ItemName != null)
						oneUpdate[2].Value = model.ItemName;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.ItemCode != null)
						oneUpdate[3].Value = model.ItemCode;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.TestNo != null)
						oneUpdate[4].Value =model.TestNo;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.ItemNo.ToString() != null)
						oneUpdate[5].Value =model.ItemNo;
					else
						oneUpdate[5].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_LAB_TEST_ITEMS_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedLabTestItems 
		///Delete Table MED_LAB_TEST_ITEMS by (string TEST_NO,decimal ITEM_NO)
		/// </summary>
		public int DeleteMedLabTestItemsSQL(string TEST_NO,decimal ITEM_NO)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedLabTestItems");
					if (TEST_NO != null)
						oneDelete[0].Value =TEST_NO;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (ITEM_NO.ToString() != null)
						oneDelete[1].Value =ITEM_NO;
					else
						oneDelete[1].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_LAB_TEST_ITEMS_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedLabTestItems 
		///select Table MED_LAB_TEST_ITEMS by (string TEST_NO,decimal ITEM_NO)
		/// </summary>
		public MedLabTestItems  SelectMedLabTestItemsSQL(string TEST_NO,decimal ITEM_NO)
		{
			MedLabTestItems model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedLabTestItems");
				parameterValues[0].Value=TEST_NO;
				parameterValues[1].Value=ITEM_NO;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_LAB_TEST_ITEMS_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedLabTestItems();
						if (!oleReader.IsDBNull(0))
						{
							model.TestNo = oleReader["TEST_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.ItemName = oleReader["ITEM_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.ItemCode = oleReader["ITEM_CODE"].ToString().Trim() ;
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
		public List<MedLabTestItems> SelectMedLabTestItemsListSQL()
		{
			List<MedLabTestItems> modelList = new List<MedLabTestItems>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_LAB_TEST_ITEMS_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedLabTestItems model = new MedLabTestItems();
						if (!oleReader.IsDBNull(0))
						{
							model.TestNo = oleReader["TEST_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.ItemName = oleReader["ITEM_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.ItemCode = oleReader["ITEM_CODE"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [获取参数]
		/// <summary>
		///获取参数MedLabTestItems
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedLabTestItems")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":TestNo",OracleType.VarChar),
							new OracleParameter(":ItemNo",OracleType.Number),
							new OracleParameter(":ItemName",OracleType.VarChar),
							new OracleParameter(":ItemCode",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedLabTestItems")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":TestNo",OracleType.VarChar),
							new OracleParameter(":ItemNo",OracleType.Number),
							new OracleParameter(":ItemName",OracleType.VarChar),
							new OracleParameter(":ItemCode",OracleType.VarChar),
							new OracleParameter(":TestNo",SqlDbType.VarChar),
							new OracleParameter(":ItemNo",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedLabTestItems")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":TestNo",OracleType.VarChar),
							new OracleParameter(":ItemNo",OracleType.Number),
                    };
                }
				else if(sqlParms == "SelectMedLabTestItems")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":TestNo",OracleType.VarChar),
							new OracleParameter(":ItemNo",OracleType.Number),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedLabTestItems 
		///Insert Table MED_LAB_TEST_ITEMS
		/// </summary>
		public int InsertMedLabTestItems(MedLabTestItems model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedLabTestItems");
					if (model.TestNo != null)
						oneInert[0].Value = model.TestNo;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.ItemNo.ToString() != null)
						oneInert[1].Value = model.ItemNo;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.ItemName != null)
						oneInert[2].Value = model.ItemName;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.ItemCode != null)
						oneInert[3].Value = model.ItemCode;
					else
						oneInert[3].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_LAB_TEST_ITEMS_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedLabTestItems 
		///Update Table     MED_LAB_TEST_ITEMS
		/// </summary>
		public int UpdateMedLabTestItems(MedLabTestItems model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedLabTestItems");
					if (model.TestNo != null)
						oneUpdate[0].Value = model.TestNo;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.ItemNo.ToString() != null)
						oneUpdate[1].Value = model.ItemNo;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.ItemName != null)
						oneUpdate[2].Value = model.ItemName;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.ItemCode != null)
						oneUpdate[3].Value = model.ItemCode;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.TestNo != null)
						oneUpdate[4].Value =model.TestNo;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.ItemNo.ToString() != null)
						oneUpdate[5].Value =model.ItemNo;
					else
						oneUpdate[5].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_LAB_TEST_ITEMS_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedLabTestItems 
		///Delete Table MED_LAB_TEST_ITEMS by (string TEST_NO,decimal ITEM_NO)
		/// </summary>
		public int DeleteMedLabTestItems(string TEST_NO,decimal ITEM_NO)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedLabTestItems");
					if (TEST_NO != null)
						oneDelete[0].Value =TEST_NO;
					else
						oneDelete[0].Value = DBNull.Value;
					if (ITEM_NO.ToString() != null)
						oneDelete[1].Value =ITEM_NO;
					else
						oneDelete[1].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_LAB_TEST_ITEMS_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedLabTestItems 
		///select Table MED_LAB_TEST_ITEMS by (string TEST_NO,decimal ITEM_NO)
		/// </summary>
		public MedLabTestItems  SelectMedLabTestItems(string TEST_NO,decimal ITEM_NO)
		{
			MedLabTestItems model;
			OracleParameter[] parameterValues = GetParameter("SelectMedLabTestItems");
				parameterValues[0].Value=TEST_NO;
				parameterValues[1].Value=ITEM_NO;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_LAB_TEST_ITEMS_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedLabTestItems();
						if (!oleReader.IsDBNull(0))
						{
							model.TestNo = oleReader["TEST_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.ItemName = oleReader["ITEM_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.ItemCode = oleReader["ITEM_CODE"].ToString().Trim() ;
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
		public List<MedLabTestItems> SelectMedLabTestItemsList()
		{
			List<MedLabTestItems> modelList = new List<MedLabTestItems>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_LAB_TEST_ITEMS_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedLabTestItems model = new MedLabTestItems();
						if (!oleReader.IsDBNull(0))
						{
							model.TestNo = oleReader["TEST_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.ItemName = oleReader["ITEM_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.ItemCode = oleReader["ITEM_CODE"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
