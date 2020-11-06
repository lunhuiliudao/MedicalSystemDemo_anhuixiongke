

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:03:12
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
	/// DAL MedVsHisOrderClass
	/// </summary>
	
	public partial class DALMedVsHisOrderClass
	{
		
		private static readonly string MED_VS_HIS_ORDER_CLASS_Insert_SQL = "INSERT INTO MED_VS_HIS_ORDER_CLASS (SERIAL_NO,HIS_CLASS_CODE,HIS_CLASS_NAME,MED_CLASS_CODE,MED_CLASS_NAME) values (@SerialNo,@HisClassCode,@HisClassName,@MedClassCode,@MedClassName)";
		private static readonly string MED_VS_HIS_ORDER_CLASS_Update_SQL = "UPDATE MED_VS_HIS_ORDER_CLASS SET SERIAL_NO=@SerialNo,HIS_CLASS_CODE=@HisClassCode,HIS_CLASS_NAME=@HisClassName,MED_CLASS_CODE=@MedClassCode,MED_CLASS_NAME=@MedClassName WHERE HIS_CLASS_CODE=@HisClassCode";
		private static readonly string MED_VS_HIS_ORDER_CLASS_Delete_SQL = "Delete MED_VS_HIS_ORDER_CLASS WHERE HIS_CLASS_CODE=@HisClassCode";
		private static readonly string MED_VS_HIS_ORDER_CLASS_Select_SQL = "SELECT SERIAL_NO,HIS_CLASS_CODE,HIS_CLASS_NAME,MED_CLASS_CODE,MED_CLASS_NAME FROM MED_VS_HIS_ORDER_CLASS where HIS_CLASS_CODE=@HisClassCode";
        private static readonly string MED_VS_HIS_ORDER_CLASS_HIS_CLASS_NAME_Select_SQL = "SELECT SERIAL_NO,HIS_CLASS_CODE,HIS_CLASS_NAME,MED_CLASS_CODE,MED_CLASS_NAME FROM MED_VS_HIS_ORDER_CLASS where HIS_CLASS_NAME=@HisClassName";
        private static readonly string MED_VS_HIS_ORDER_CLASS_Select_ALL_SQL = "SELECT SERIAL_NO,HIS_CLASS_CODE,HIS_CLASS_NAME,MED_CLASS_CODE,MED_CLASS_NAME FROM MED_VS_HIS_ORDER_CLASS";
		private static readonly string MED_VS_HIS_ORDER_CLASS_Insert = "INSERT INTO MED_VS_HIS_ORDER_CLASS (SERIAL_NO,HIS_CLASS_CODE,HIS_CLASS_NAME,MED_CLASS_CODE,MED_CLASS_NAME) values (:SerialNo,:HisClassCode,:HisClassName,:MedClassCode,:MedClassName)";
		private static readonly string MED_VS_HIS_ORDER_CLASS_Update = "UPDATE MED_VS_HIS_ORDER_CLASS SET SERIAL_NO=:SerialNo,HIS_CLASS_CODE=:HisClassCode,HIS_CLASS_NAME=:HisClassName,MED_CLASS_CODE=:MedClassCode,MED_CLASS_NAME=:MedClassName WHERE HIS_CLASS_CODE=:HisClassCode";
		private static readonly string MED_VS_HIS_ORDER_CLASS_Delete = "Delete MED_VS_HIS_ORDER_CLASS WHERE HIS_CLASS_CODE=:HisClassCode";
		private static readonly string MED_VS_HIS_ORDER_CLASS_Select = "SELECT SERIAL_NO,HIS_CLASS_CODE,HIS_CLASS_NAME,MED_CLASS_CODE,MED_CLASS_NAME FROM MED_VS_HIS_ORDER_CLASS where HIS_CLASS_CODE=:HisClassCode";
        private static readonly string MED_VS_HIS_ORDER_CLASS_HIS_CLASS_NAME_Select = "SELECT SERIAL_NO,HIS_CLASS_CODE,HIS_CLASS_NAME,MED_CLASS_CODE,MED_CLASS_NAME FROM MED_VS_HIS_ORDER_CLASS where HIS_CLASS_NAME=:HisClassName";
        private static readonly string MED_VS_HIS_ORDER_CLASS_Select_ALL = "SELECT SERIAL_NO,HIS_CLASS_CODE,HIS_CLASS_NAME,MED_CLASS_CODE,MED_CLASS_NAME FROM MED_VS_HIS_ORDER_CLASS";
		public DALMedVsHisOrderClass ()
		{
		}
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedVsHisOrderClass SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOrderClass")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@SerialNo",SqlDbType.Decimal),
							new SqlParameter("@HisClassCode",SqlDbType.VarChar),
							new SqlParameter("@HisClassName",SqlDbType.VarChar),
							new SqlParameter("@MedClassCode",SqlDbType.VarChar),
							new SqlParameter("@MedClassName",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedVsHisOrderClass")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@SerialNo",SqlDbType.Decimal),
							new SqlParameter("@HisClassCode",SqlDbType.VarChar),
							new SqlParameter("@HisClassName",SqlDbType.VarChar),
							new SqlParameter("@MedClassCode",SqlDbType.VarChar),
							new SqlParameter("@MedClassName",SqlDbType.VarChar),
							new SqlParameter("@HisClassCode",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedVsHisOrderClass")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@HisClassCode",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedVsHisOrderClass")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@HisClassCode",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOrderClassHisClassName")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@HisClassName",SqlDbType.VarChar),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedVsHisOrderClass 
		///Insert Table MED_VS_HIS_ORDER_CLASS
		/// </summary>
		public int InsertMedVsHisOrderClassSQL(MedVsHisOrderClass model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedVsHisOrderClass");
					if (model.SerialNo.ToString() != null)
						oneInert[0].Value = model.SerialNo;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.HisClassCode != null)
						oneInert[1].Value = model.HisClassCode;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.HisClassName != null)
						oneInert[2].Value = model.HisClassName;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.MedClassCode != null)
						oneInert[3].Value = model.MedClassCode;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.MedClassName != null)
						oneInert[4].Value = model.MedClassName;
					else
						oneInert[4].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_ORDER_CLASS_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedVsHisOrderClass 
		///Update Table     MED_VS_HIS_ORDER_CLASS
		/// </summary>
		public int UpdateMedVsHisOrderClassSQL(MedVsHisOrderClass model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedVsHisOrderClass");
                if (model.SerialNo.ToString() != null)
						oneUpdate[0].Value = model.SerialNo;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.HisClassCode != null)
						oneUpdate[1].Value = model.HisClassCode;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.HisClassName != null)
						oneUpdate[2].Value = model.HisClassName;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.MedClassCode != null)
						oneUpdate[3].Value = model.MedClassCode;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.MedClassName != null)
						oneUpdate[4].Value = model.MedClassName;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.HisClassCode != null)
						oneUpdate[5].Value =model.HisClassCode;
					else
						oneUpdate[5].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_ORDER_CLASS_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedVsHisOrderClass 
		///Delete Table MED_VS_HIS_ORDER_CLASS by (string HIS_CLASS_CODE)
		/// </summary>
		public int DeleteMedVsHisOrderClassSQL(string HIS_CLASS_CODE)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedVsHisOrderClass");
					if (HIS_CLASS_CODE != null)
						oneDelete[0].Value =HIS_CLASS_CODE;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_ORDER_CLASS_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedVsHisOrderClass 
		///select Table MED_VS_HIS_ORDER_CLASS by (string HIS_CLASS_CODE)
		/// </summary>
		public MedVsHisOrderClass  SelectMedVsHisOrderClassSQL(string HIS_CLASS_CODE)
		{
			MedVsHisOrderClass model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedVsHisOrderClass");
			parameterValues[0].Value=HIS_CLASS_CODE;
            decimal dc;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDER_CLASS_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedVsHisOrderClass();
						if (!oleReader.IsDBNull(0))
						{
                            if (decimal.TryParse(oleReader["SERIAL_NO"].ToString().Trim(), out dc))
							    model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.HisClassCode = oleReader["HIS_CLASS_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.HisClassName = oleReader["HIS_CLASS_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.MedClassCode = oleReader["MED_CLASS_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.MedClassName = oleReader["MED_CLASS_NAME"].ToString().Trim() ;
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
		public List<MedVsHisOrderClass> SelectMedVsHisOrderClassListSQL()
		{
			List<MedVsHisOrderClass> modelList = new List<MedVsHisOrderClass>();
            decimal dc;
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDER_CLASS_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedVsHisOrderClass model = new MedVsHisOrderClass();
						if (!oleReader.IsDBNull(0))
						{
                            if (decimal.TryParse(oleReader["SERIAL_NO"].ToString().Trim(), out dc))
							    model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.HisClassCode = oleReader["HIS_CLASS_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.HisClassName = oleReader["HIS_CLASS_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.MedClassCode = oleReader["MED_CLASS_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.MedClassName = oleReader["MED_CLASS_NAME"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
        #region  [获取一条记录SQL-HisClassName]
        /// <summary>
        ///Select    model  MedVsHisOrderClass 
        ///select Table MED_VS_HIS_ORDER_CLASS by (string HIS_CLASS_NAME)
        /// </summary>
        public MedVsHisOrderClass SelectMedVsHisOrderClassHisClassNameSQL(string HIS_CLASS_NAME)
        {
            MedVsHisOrderClass model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedVsHisOrderClassHisClassName");
            parameterValues[0].Value = HIS_CLASS_NAME;
            decimal dc;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDER_CLASS_HIS_CLASS_NAME_Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisOrderClass();
                    if (!oleReader.IsDBNull(0))
                    {
                        if (decimal.TryParse(oleReader["SERIAL_NO"].ToString().Trim(), out dc))
                            model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.HisClassCode = oleReader["HIS_CLASS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.HisClassName = oleReader["HIS_CLASS_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MedClassCode = oleReader["MED_CLASS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.MedClassName = oleReader["MED_CLASS_NAME"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion	
		#region [获取参数]
		/// <summary>
		///获取参数MedVsHisOrderClass
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOrderClass")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":SerialNo",OracleType.Number),
						new OracleParameter(":HisClassCode",OracleType.VarChar),
						new OracleParameter(":HisClassName",OracleType.VarChar),
						new OracleParameter(":MedClassCode",OracleType.VarChar),
						new OracleParameter(":MedClassName",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedVsHisOrderClass")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":SerialNo",OracleType.Number),
						new OracleParameter(":HisClassCode",OracleType.VarChar),
						new OracleParameter(":HisClassName",OracleType.VarChar),
						new OracleParameter(":MedClassCode",OracleType.VarChar),
						new OracleParameter(":MedClassName",OracleType.VarChar),
						new OracleParameter(":HisClassCode",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedVsHisOrderClass")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":HisClassCode",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedVsHisOrderClass")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":HisClassCode",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOrderClassHisClassName")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":HisClassName",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedVsHisOrderClass 
		///Insert Table MED_VS_HIS_ORDER_CLASS
		/// </summary>
		public int InsertMedVsHisOrderClass(MedVsHisOrderClass model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedVsHisOrderClass");
                if (model.SerialNo.ToString() != null)
					oneInert[0].Value = model.SerialNo;
				else
					oneInert[0].Value = DBNull.Value;
				if (model.HisClassCode != null)
					oneInert[1].Value = model.HisClassCode;
				else
					oneInert[1].Value = DBNull.Value;
				if (model.HisClassName != null)
					oneInert[2].Value = model.HisClassName;
				else
					oneInert[2].Value = DBNull.Value;
				if (model.MedClassCode != null)
					oneInert[3].Value = model.MedClassCode;
				else
					oneInert[3].Value = DBNull.Value;
				if (model.MedClassName != null)
					oneInert[4].Value = model.MedClassName;
				else
					oneInert[4].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_ORDER_CLASS_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedVsHisOrderClass 
		///Update Table     MED_VS_HIS_ORDER_CLASS
		/// </summary>
		public int UpdateMedVsHisOrderClass(MedVsHisOrderClass model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedVsHisOrderClass");
                if (model.SerialNo.ToString() != null)
						oneUpdate[0].Value = model.SerialNo;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.HisClassCode != null)
						oneUpdate[1].Value = model.HisClassCode;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.HisClassName != null)
						oneUpdate[2].Value = model.HisClassName;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.MedClassCode != null)
						oneUpdate[3].Value = model.MedClassCode;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.MedClassName != null)
						oneUpdate[4].Value = model.MedClassName;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.HisClassCode != null)
						oneUpdate[5].Value =model.HisClassCode;
					else
						oneUpdate[5].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_ORDER_CLASS_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedVsHisOrderClass 
		///Delete Table MED_VS_HIS_ORDER_CLASS by (string HIS_CLASS_CODE)
		/// </summary>
		public int DeleteMedVsHisOrderClass(string HIS_CLASS_CODE)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedVsHisOrderClass");
					if (HIS_CLASS_CODE != null)
						oneDelete[0].Value =HIS_CLASS_CODE;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_ORDER_CLASS_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedVsHisOrderClass 
		///select Table MED_VS_HIS_ORDER_CLASS by (string HIS_CLASS_CODE)
		/// </summary>
		public MedVsHisOrderClass  SelectMedVsHisOrderClass(string HIS_CLASS_CODE)
		{
			MedVsHisOrderClass model;
			OracleParameter[] parameterValues = GetParameter("SelectMedVsHisOrderClass");
			parameterValues[0].Value=HIS_CLASS_CODE;
            decimal dc;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDER_CLASS_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedVsHisOrderClass();
						if (!oleReader.IsDBNull(0))
						{
                            if(decimal.TryParse(oleReader["SERIAL_NO"].ToString().Trim(),out dc))
							    model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.HisClassCode = oleReader["HIS_CLASS_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.HisClassName = oleReader["HIS_CLASS_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.MedClassCode = oleReader["MED_CLASS_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.MedClassName = oleReader["MED_CLASS_NAME"].ToString().Trim() ;
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
		public List<MedVsHisOrderClass> SelectMedVsHisOrderClassList()
		{
			List<MedVsHisOrderClass> modelList = new List<MedVsHisOrderClass>();
            decimal dc;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDER_CLASS_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedVsHisOrderClass model = new MedVsHisOrderClass();
						if (!oleReader.IsDBNull(0))
						{
                            if (decimal.TryParse(oleReader["SERIAL_NO"].ToString().Trim(), out dc))
							    model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.HisClassCode = oleReader["HIS_CLASS_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.HisClassName = oleReader["HIS_CLASS_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.MedClassCode = oleReader["MED_CLASS_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.MedClassName = oleReader["MED_CLASS_NAME"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
        #region  [获取一条记录-HisClassName]
        /// <summary>
        ///Select    model  MedVsHisOrderClass 
        ///select Table MED_VS_HIS_ORDER_CLASS by (string HIS_CLASS_NAME)
        /// </summary>
        public MedVsHisOrderClass SelectMedVsHisOrderClassHisClassName(string HIS_CLASS_NAME)
        {
            MedVsHisOrderClass model;
            OracleParameter[] parameterValues = GetParameter("SelectMedVsHisOrderClassHisClassName");
            parameterValues[0].Value = HIS_CLASS_NAME;
            decimal dc;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDER_CLASS_HIS_CLASS_NAME_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisOrderClass();
                    if (!oleReader.IsDBNull(0))
                    {
                        if (decimal.TryParse(oleReader["SERIAL_NO"].ToString().Trim(), out dc))
                            model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.HisClassCode = oleReader["HIS_CLASS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.HisClassName = oleReader["HIS_CLASS_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MedClassCode = oleReader["MED_CLASS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.MedClassName = oleReader["MED_CLASS_NAME"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion	
	}
}
