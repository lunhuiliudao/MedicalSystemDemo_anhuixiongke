

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:04:39
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
	/// DAL MedBillItemClassDict
	/// </summary>
	
	public class DALMedBillItemClassDict
	{
		
		private static readonly string MED_BILL_ITEM_CLASS_DICT_Insert_SQL = "INSERT INTO MED_BILL_ITEM_CLASS_DICT (SERIAL_NO,CLASS_CODE,CLASS_NAME,INPUT_CODE) values (@SerialNo,@ClassCode,@ClassName,@InputCode)";
		private static readonly string MED_BILL_ITEM_CLASS_DICT_Update_SQL = "UPDATE MED_BILL_ITEM_CLASS_DICT SET SERIAL_NO=@SerialNo,CLASS_CODE=@ClassCode,CLASS_NAME=@ClassName,INPUT_CODE=@InputCode WHERE CLASS_CODE=@ClassCode";
		private static readonly string MED_BILL_ITEM_CLASS_DICT_Delete_SQL = "Delete MED_BILL_ITEM_CLASS_DICT WHERE CLASS_CODE=@ClassCode";
		private static readonly string MED_BILL_ITEM_CLASS_DICT_Select_SQL = "SELECT SERIAL_NO,CLASS_CODE,CLASS_NAME,INPUT_CODE FROM MED_BILL_ITEM_CLASS_DICT where CLASS_CODE=@ClassCode";
		private static readonly string MED_BILL_ITEM_CLASS_DICT_Select_ALL_SQL = "SELECT SERIAL_NO,CLASS_CODE,CLASS_NAME,INPUT_CODE FROM MED_BILL_ITEM_CLASS_DICT";
		private static readonly string MED_BILL_ITEM_CLASS_DICT_Insert = "INSERT INTO MED_BILL_ITEM_CLASS_DICT (SERIAL_NO,CLASS_CODE,CLASS_NAME,INPUT_CODE) values (:SerialNo,:ClassCode,:ClassName,:InputCode)";
		private static readonly string MED_BILL_ITEM_CLASS_DICT_Update = "UPDATE MED_BILL_ITEM_CLASS_DICT SET SERIAL_NO=:SerialNo,CLASS_CODE=:ClassCode,CLASS_NAME=:ClassName,INPUT_CODE=:InputCode WHERE CLASS_CODE=:ClassCode";
		private static readonly string MED_BILL_ITEM_CLASS_DICT_Delete = "Delete MED_BILL_ITEM_CLASS_DICT WHERE CLASS_CODE=:ClassCode";
		private static readonly string MED_BILL_ITEM_CLASS_DICT_Select = "SELECT SERIAL_NO,CLASS_CODE,CLASS_NAME,INPUT_CODE FROM MED_BILL_ITEM_CLASS_DICT where CLASS_CODE=:ClassCode";
		private static readonly string MED_BILL_ITEM_CLASS_DICT_Select_ALL = "SELECT SERIAL_NO,CLASS_CODE,CLASS_NAME,INPUT_CODE FROM MED_BILL_ITEM_CLASS_DICT";
		public DALMedBillItemClassDict ()
		{
		}
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedBillItemClassDict SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedBillItemClassDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@SerialNo",SqlDbType.Decimal),
							new SqlParameter("@ClassCode",SqlDbType.VarChar),
							new SqlParameter("@ClassName",SqlDbType.VarChar),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedBillItemClassDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@SerialNo",SqlDbType.Decimal),
							new SqlParameter("@ClassCode",SqlDbType.VarChar),
							new SqlParameter("@ClassName",SqlDbType.VarChar),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
							new SqlParameter("@ClassCode",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedBillItemClassDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@ClassCode",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "SelectMedBillItemClassDict")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@ClassCode",SqlDbType.Decimal),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedBillItemClassDict 
		///Insert Table MED_BILL_ITEM_CLASS_DICT
		/// </summary>
		public int InsertMedBillItemClassDictSQL(MedBillItemClassDict model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedBillItemClassDict");
                if (model.SerialNo.ToString() != null)
						oneInert[0].Value = model.SerialNo;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.ClassCode != null)
						oneInert[1].Value = model.ClassCode;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.ClassName != null)
						oneInert[2].Value = model.ClassName;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.InputCode != null)
						oneInert[3].Value = model.InputCode;
					else
						oneInert[3].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_BILL_ITEM_CLASS_DICT_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedBillItemClassDict 
		///Update Table     MED_BILL_ITEM_CLASS_DICT
		/// </summary>
		public int UpdateMedBillItemClassDictSQL(MedBillItemClassDict model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedBillItemClassDict");
                if (model.SerialNo.ToString() != null)
						oneUpdate[0].Value = model.SerialNo;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.ClassCode != null)
						oneUpdate[1].Value = model.ClassCode;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.ClassName != null)
						oneUpdate[2].Value = model.ClassName;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.InputCode != null)
						oneUpdate[3].Value = model.InputCode;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.ClassCode != null)
						oneUpdate[4].Value =model.ClassCode;
					else
						oneUpdate[4].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_BILL_ITEM_CLASS_DICT_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedBillItemClassDict 
		///Delete Table MED_BILL_ITEM_CLASS_DICT by (string CLASS_CODE)
		/// </summary>
		public int DeleteMedBillItemClassDictSQL(string CLASS_CODE)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedBillItemClassDict");
				if (CLASS_CODE != null)
					oneDelete[0].Value =CLASS_CODE;
				else
					oneDelete[0].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_BILL_ITEM_CLASS_DICT_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedBillItemClassDict 
		///select Table MED_BILL_ITEM_CLASS_DICT by (string CLASS_CODE)
		/// </summary>
		public MedBillItemClassDict  SelectMedBillItemClassDictSQL(string CLASS_CODE)
		{
			MedBillItemClassDict model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedBillItemClassDict");
				parameterValues[0].Value=CLASS_CODE;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_BILL_ITEM_CLASS_DICT_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedBillItemClassDict();
					if (!oleReader.IsDBNull(0))
					{
						model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(1))
					{
						model.ClassCode = oleReader["CLASS_CODE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(2))
					{
						model.ClassName = oleReader["CLASS_NAME"].ToString().Trim() ;
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
		public List<MedBillItemClassDict> SelectMedBillItemClassDictListSQL()
		{
			List<MedBillItemClassDict> modelList = new List<MedBillItemClassDict>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_BILL_ITEM_CLASS_DICT_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedBillItemClassDict model = new MedBillItemClassDict();
					if (!oleReader.IsDBNull(0))
					{
						model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(1))
					{
						model.ClassCode = oleReader["CLASS_CODE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(2))
					{
						model.ClassName = oleReader["CLASS_NAME"].ToString().Trim() ;
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
		///获取参数MedBillItemClassDict
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedBillItemClassDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":SerialNo",OracleType.Number),
							new OracleParameter(":ClassCode",OracleType.VarChar),
							new OracleParameter(":ClassName",OracleType.VarChar),
							new OracleParameter(":InputCode",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedBillItemClassDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":SerialNo",OracleType.Number),
							new OracleParameter(":ClassCode",OracleType.VarChar),
							new OracleParameter(":ClassName",OracleType.VarChar),
							new OracleParameter(":InputCode",OracleType.VarChar),
							new OracleParameter(":ClassCode",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedBillItemClassDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":ClassCode",OracleType.Number),
                    };
                }
				else if(sqlParms == "SelectMedBillItemClassDict")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":ClassCode",OracleType.Number),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedBillItemClassDict 
		///Insert Table MED_BILL_ITEM_CLASS_DICT
		/// </summary>
		public int InsertMedBillItemClassDict(MedBillItemClassDict model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedBillItemClassDict");
                if (model.SerialNo.ToString() != null)
					oneInert[0].Value = model.SerialNo;
				else
					oneInert[0].Value = DBNull.Value;
				if (model.ClassCode != null)
					oneInert[1].Value = model.ClassCode;
				else
					oneInert[1].Value = DBNull.Value;
				if (model.ClassName != null)
					oneInert[2].Value = model.ClassName;
				else
					oneInert[2].Value = DBNull.Value;
				if (model.InputCode != null)
					oneInert[3].Value = model.InputCode;
				else
					oneInert[3].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_BILL_ITEM_CLASS_DICT_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedBillItemClassDict 
		///Update Table     MED_BILL_ITEM_CLASS_DICT
		/// </summary>
		public int UpdateMedBillItemClassDict(MedBillItemClassDict model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedBillItemClassDict");
                if (model.SerialNo.ToString() != null)
					oneUpdate[0].Value = model.SerialNo;
				else
					oneUpdate[0].Value = DBNull.Value;
				if (model.ClassCode != null)
					oneUpdate[1].Value = model.ClassCode;
				else
					oneUpdate[1].Value = DBNull.Value;
				if (model.ClassName != null)
					oneUpdate[2].Value = model.ClassName;
				else
					oneUpdate[2].Value = DBNull.Value;
				if (model.InputCode != null)
					oneUpdate[3].Value = model.InputCode;
				else
					oneUpdate[3].Value = DBNull.Value;
				if (model.ClassCode != null)
					oneUpdate[4].Value =model.ClassCode;
				else
					oneUpdate[4].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_BILL_ITEM_CLASS_DICT_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedBillItemClassDict 
		///Delete Table MED_BILL_ITEM_CLASS_DICT by (string CLASS_CODE)
		/// </summary>
		public int DeleteMedBillItemClassDict(string CLASS_CODE)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedBillItemClassDict");
				if (CLASS_CODE != null)
					oneDelete[0].Value =CLASS_CODE;
				else
					oneDelete[0].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_BILL_ITEM_CLASS_DICT_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedBillItemClassDict 
		///select Table MED_BILL_ITEM_CLASS_DICT by (string CLASS_CODE)
		/// </summary>
		public MedBillItemClassDict  SelectMedBillItemClassDict(string CLASS_CODE)
		{
			MedBillItemClassDict model;
			OracleParameter[] parameterValues = GetParameter("SelectMedBillItemClassDict");
				parameterValues[0].Value=CLASS_CODE;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_BILL_ITEM_CLASS_DICT_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedBillItemClassDict();
					if (!oleReader.IsDBNull(0))
					{
						model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(1))
					{
						model.ClassCode = oleReader["CLASS_CODE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(2))
					{
						model.ClassName = oleReader["CLASS_NAME"].ToString().Trim() ;
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
		public List<MedBillItemClassDict> SelectMedBillItemClassDictList()
		{
			List<MedBillItemClassDict> modelList = new List<MedBillItemClassDict>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_BILL_ITEM_CLASS_DICT_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedBillItemClassDict model = new MedBillItemClassDict();
					if (!oleReader.IsDBNull(0))
					{
						model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(1))
					{
						model.ClassCode = oleReader["CLASS_CODE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(2))
					{
						model.ClassName = oleReader["CLASS_NAME"].ToString().Trim() ;
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
