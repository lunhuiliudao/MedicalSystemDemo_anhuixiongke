

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:04:46
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
	/// DAL MedBillItemClassVsHis
	/// </summary>

    public partial class DALMedBillItemClassVsHis
	{
		
		private static readonly string MED_BILL_ITEM_CLASS_VS_HIS_Insert_SQL = "INSERT INTO MED_BILL_ITEM_CLASS_VS_HIS (CLASS_CODE,CODE_IN_HIS) values (@ClassCode,@CodeInHis)";
        private static readonly string MED_BILL_ITEM_CLASS_VS_HIS_Update_SQL = "UPDATE MED_BILL_ITEM_CLASS_VS_HIS SET CLASS_CODE=@ClassCode,CODE_IN_HIS=@CodeInHis WHERE CLASS_CODE=@ClassCode AND CODE_IN_HIS=@CodeInHis";
        private static readonly string MED_BILL_ITEM_CLASS_VS_HIS_Delete_SQL = "Delete MED_BILL_ITEM_CLASS_VS_HIS WHERE CLASS_CODE=@ClassCode AND CODE_IN_HIS=@CodeInHis";
		private static readonly string MED_BILL_ITEM_CLASS_VS_HIS_Select_SQL = "SELECT CLASS_CODE,CODE_IN_HIS FROM MED_BILL_ITEM_CLASS_VS_HIS where CLASS_CODE=@ClassCode AND CODE_IN_HIS=@CodeInHis";
		private static readonly string MED_BILL_ITEM_CLASS_VS_HIS_Select_ALL_SQL = "SELECT CLASS_CODE,CODE_IN_HIS FROM MED_BILL_ITEM_CLASS_VS_HIS";
        private static readonly string MED_BILL_ITEM_CLASS_VS_HIS_CODE_Select_SQL = "SELECT CLASS_CODE, CODE_IN_HIS FROM MED_BILL_ITEM_CLASS_VS_HIS where CLASS_CODE = @classCode";
        private static readonly string MED_BILL_ITEM_CLASS_VS_HIS_Select_His_SQL = "SELECT CLASS_CODE, CODE_IN_HIS FROM MED_BILL_ITEM_CLASS_VS_HIS where CODE_IN_HIS = @codeInHis";
        private static readonly string MED_BILL_ITEM_CLASS_VS_HIS_Insert = "INSERT INTO MED_BILL_ITEM_CLASS_VS_HIS (CLASS_CODE,CODE_IN_HIS) values (:ClassCode,:CodeInHis)";
        private static readonly string MED_BILL_ITEM_CLASS_VS_HIS_Update = "UPDATE MED_BILL_ITEM_CLASS_VS_HIS SET CLASS_CODE=:ClassCode,CODE_IN_HIS=:CodeInHis WHERE CLASS_CODE=:ClassCode AND CODE_IN_HIS=:CodeInHis";
        private static readonly string MED_BILL_ITEM_CLASS_VS_HIS_Delete = "Delete MED_BILL_ITEM_CLASS_VS_HIS WHERE CLASS_CODE=:ClassCode AND CODE_IN_HIS=:CodeInHis";
        private static readonly string MED_BILL_ITEM_CLASS_VS_HIS_Select = "SELECT CLASS_CODE,CODE_IN_HIS FROM MED_BILL_ITEM_CLASS_VS_HIS where CLASS_CODE=:ClassCode AND CODE_IN_HIS=:CodeInHis";
		private static readonly string MED_BILL_ITEM_CLASS_VS_HIS_Select_ALL = "SELECT CLASS_CODE,CODE_IN_HIS FROM MED_BILL_ITEM_CLASS_VS_HIS";
        private static readonly string MED_BILL_ITEM_CLASS_VS_HIS_CODE_Select = "SELECT CLASS_CODE, CODE_IN_HIS FROM MED_BILL_ITEM_CLASS_VS_HIS where CLASS_CODE = :classCode ";
        private static readonly string MED_BILL_ITEM_CLASS_VS_HIS_Select_His = "SELECT CLASS_CODE, CODE_IN_HIS FROM MED_BILL_ITEM_CLASS_VS_HIS where CODE_IN_HIS = :codeInHis ";
        
        public DALMedBillItemClassVsHis()
		{
		}
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedBillItemClassVsHis SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedBillItemClassVsHis")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@ClassCode",SqlDbType.VarChar),
							new SqlParameter("@CodeInHis",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedBillItemClassVsHis")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@ClassCode",SqlDbType.VarChar),
							new SqlParameter("@CodeInHis",SqlDbType.VarChar),
							new SqlParameter("@ClassCode",SqlDbType.VarChar),
							new SqlParameter("@CodeInHis",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedBillItemClassVsHis")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@ClassCode",SqlDbType.VarChar),
							new SqlParameter("@CodeInHis",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedBillItemClassVsHis")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@ClassCode",SqlDbType.VarChar),
							new SqlParameter("@CodeInHis",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectOneMedBillItemClassVsHis")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@ClassCode",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectOneHisMedBillItemClassVsHis")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@CodeInHis",SqlDbType.VarChar),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedBillItemClassVsHis 
		///Insert Table MED_BILL_ITEM_CLASS_VS_HIS
		/// </summary>
		public int InsertMedBillItemClassVsHisSQL(MedBillItemClassVsHis model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedBillItemClassVsHis");
					if (model.ClassCode != null)
						oneInert[0].Value = model.ClassCode;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.CodeInHis != null)
						oneInert[1].Value = model.CodeInHis;
					else
						oneInert[1].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_BILL_ITEM_CLASS_VS_HIS_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedBillItemClassVsHis 
		///Update Table     MED_BILL_ITEM_CLASS_VS_HIS
		/// </summary>
		public int UpdateMedBillItemClassVsHisSQL(MedBillItemClassVsHis model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedBillItemClassVsHis");
					if (model.ClassCode != null)
						oneUpdate[0].Value = model.ClassCode;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.CodeInHis != null)
						oneUpdate[1].Value = model.CodeInHis;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.ClassCode != null)
						oneUpdate[2].Value =model.ClassCode;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.CodeInHis != null)
						oneUpdate[3].Value =model.CodeInHis;
					else
						oneUpdate[3].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_BILL_ITEM_CLASS_VS_HIS_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedBillItemClassVsHis 
		///Delete Table MED_BILL_ITEM_CLASS_VS_HIS by (string CLASS_CODE,string CODE_IN_HIS)
		/// </summary>
		public int DeleteMedBillItemClassVsHisSQL(string CLASS_CODE,string CODE_IN_HIS)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedBillItemClassVsHis");
					if (CLASS_CODE != null)
						oneDelete[0].Value =CLASS_CODE;
					else
						oneDelete[0].Value = DBNull.Value;
					if (CODE_IN_HIS != null)
						oneDelete[1].Value =CODE_IN_HIS;
					else
						oneDelete[1].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_BILL_ITEM_CLASS_VS_HIS_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedBillItemClassVsHis 
		///select Table MED_BILL_ITEM_CLASS_VS_HIS by (string CLASS_CODE,string CODE_IN_HIS)
		/// </summary>
		public MedBillItemClassVsHis  SelectMedBillItemClassVsHisSQL(string CLASS_CODE,string CODE_IN_HIS)
		{
			MedBillItemClassVsHis model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedBillItemClassVsHis");
				parameterValues[0].Value=CLASS_CODE;
				parameterValues[1].Value=CODE_IN_HIS;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_BILL_ITEM_CLASS_VS_HIS_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedBillItemClassVsHis();
						if (!oleReader.IsDBNull(0))
						{
							model.ClassCode = oleReader["CLASS_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.CodeInHis = oleReader["CODE_IN_HIS"].ToString().Trim() ;
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
		public List<MedBillItemClassVsHis> SelectMedBillItemClassVsHisListSQL()
		{
			List<MedBillItemClassVsHis> modelList = new List<MedBillItemClassVsHis>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_BILL_ITEM_CLASS_VS_HIS_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedBillItemClassVsHis model = new MedBillItemClassVsHis();
						if (!oleReader.IsDBNull(0))
						{
							model.ClassCode = oleReader["CLASS_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.CodeInHis = oleReader["CODE_IN_HIS"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
        public Model.MedBillItemClassVsHis SelectMedBillItemClassVsHisSQL(string classCode)
        {
            Model.MedBillItemClassVsHis OneMedBillItemClassVsHis = null;

            SqlParameter[] paramItemClassVsHis = GetParameterSQL("SelectOneMedBillItemClassVsHis");
            paramItemClassVsHis[0].Value = classCode;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_BILL_ITEM_CLASS_VS_HIS_CODE_Select_SQL, paramItemClassVsHis))
            {
                if (oleReader.Read())
                {
                    OneMedBillItemClassVsHis = new Model.MedBillItemClassVsHis();
                    if (!oleReader.IsDBNull(0))
                        OneMedBillItemClassVsHis.ClassCode = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        OneMedBillItemClassVsHis.CodeInHis = oleReader.GetString(1);
                }
                else
                    OneMedBillItemClassVsHis = null;
            }
            return OneMedBillItemClassVsHis;
        }

        public Model.MedBillItemClassVsHis SelectHisMedBillItemClassVsHisSQL(string codeInHis)
        {
            Model.MedBillItemClassVsHis OneMedBillItemClassVsHis = null;

            SqlParameter[] paramItemClassVsHis = GetParameterSQL("SelectOneHisMedBillItemClassVsHis");
            paramItemClassVsHis[0].Value = codeInHis;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_BILL_ITEM_CLASS_VS_HIS_Select_His_SQL, paramItemClassVsHis))
            {
                if (oleReader.Read())
                {
                    OneMedBillItemClassVsHis = new Model.MedBillItemClassVsHis();
                    if (!oleReader.IsDBNull(0))
                        OneMedBillItemClassVsHis.ClassCode = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        OneMedBillItemClassVsHis.CodeInHis = oleReader.GetString(1);

                }
                else
                    OneMedBillItemClassVsHis = null;
            }
            return OneMedBillItemClassVsHis;
        }

		#region [获取参数]
		/// <summary>
		///获取参数MedBillItemClassVsHis
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedBillItemClassVsHis")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":ClassCode",OracleType.VarChar),
							new OracleParameter(":CodeInHis",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedBillItemClassVsHis")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":ClassCode",OracleType.VarChar),
							new OracleParameter(":CodeInHis",OracleType.VarChar),
							new OracleParameter(":ClassCode",SqlDbType.VarChar),
							new OracleParameter(":CodeInHis",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedBillItemClassVsHis")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":ClassCode",OracleType.VarChar),
							new OracleParameter(":CodeInHis",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedBillItemClassVsHis")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":ClassCode",OracleType.VarChar),
							new OracleParameter(":CodeInHis",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectOneMedBillItemClassVsHis")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":ClassCode",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectOneHisMedBillItemClassVsHis")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":CodeInHis",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedBillItemClassVsHis 
		///Insert Table MED_BILL_ITEM_CLASS_VS_HIS
		/// </summary>
		public int InsertMedBillItemClassVsHis(MedBillItemClassVsHis model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedBillItemClassVsHis");
					if (model.ClassCode != null)
						oneInert[0].Value = model.ClassCode;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.CodeInHis != null)
						oneInert[1].Value = model.CodeInHis;
					else
						oneInert[1].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_BILL_ITEM_CLASS_VS_HIS_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedBillItemClassVsHis 
		///Update Table     MED_BILL_ITEM_CLASS_VS_HIS
		/// </summary>
		public int UpdateMedBillItemClassVsHis(MedBillItemClassVsHis model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedBillItemClassVsHis");
					if (model.ClassCode != null)
						oneUpdate[0].Value = model.ClassCode;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.CodeInHis != null)
						oneUpdate[1].Value = model.CodeInHis;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.ClassCode != null)
						oneUpdate[2].Value =model.ClassCode;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.CodeInHis != null)
						oneUpdate[3].Value =model.CodeInHis;
					else
						oneUpdate[3].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_BILL_ITEM_CLASS_VS_HIS_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedBillItemClassVsHis 
		///Delete Table MED_BILL_ITEM_CLASS_VS_HIS by (string CLASS_CODE,string CODE_IN_HIS)
		/// </summary>
		public int DeleteMedBillItemClassVsHis(string CLASS_CODE,string CODE_IN_HIS)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedBillItemClassVsHis");
					if (CLASS_CODE != null)
						oneDelete[0].Value =CLASS_CODE;
					else
						oneDelete[0].Value = DBNull.Value;
					if (CODE_IN_HIS != null)
						oneDelete[1].Value =CODE_IN_HIS;
					else
						oneDelete[1].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_BILL_ITEM_CLASS_VS_HIS_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedBillItemClassVsHis 
		///select Table MED_BILL_ITEM_CLASS_VS_HIS by (string CLASS_CODE,string CODE_IN_HIS)
		/// </summary>
		public MedBillItemClassVsHis  SelectMedBillItemClassVsHis(string CLASS_CODE,string CODE_IN_HIS)
		{
			MedBillItemClassVsHis model;
			OracleParameter[] parameterValues = GetParameter("SelectMedBillItemClassVsHis");
				parameterValues[0].Value=CLASS_CODE;
				parameterValues[1].Value=CODE_IN_HIS;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_BILL_ITEM_CLASS_VS_HIS_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedBillItemClassVsHis();
						if (!oleReader.IsDBNull(0))
						{
							model.ClassCode = oleReader["CLASS_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.CodeInHis = oleReader["CODE_IN_HIS"].ToString().Trim() ;
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
		public List<MedBillItemClassVsHis> SelectMedBillItemClassVsHisList()
		{
			List<MedBillItemClassVsHis> modelList = new List<MedBillItemClassVsHis>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_BILL_ITEM_CLASS_VS_HIS_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedBillItemClassVsHis model = new MedBillItemClassVsHis();
						if (!oleReader.IsDBNull(0))
						{
							model.ClassCode = oleReader["CLASS_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.CodeInHis = oleReader["CODE_IN_HIS"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
	
        public Model.MedBillItemClassVsHis SelectMedBillItemClassVsHis(string classCode)
        {
            Model.MedBillItemClassVsHis OneMedBillItemClassVsHis = null;

            OracleParameter[] paramItemClassVsHis = GetParameter("SelectOneMedBillItemClassVsHis");
            paramItemClassVsHis[0].Value = classCode;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_BILL_ITEM_CLASS_VS_HIS_CODE_Select, paramItemClassVsHis))
            {
                if (oleReader.Read())
                {
                    OneMedBillItemClassVsHis = new Model.MedBillItemClassVsHis();
                    if (!oleReader.IsDBNull(0))
                        OneMedBillItemClassVsHis.ClassCode = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        OneMedBillItemClassVsHis.CodeInHis = oleReader.GetString(1);
                }
                else
                    OneMedBillItemClassVsHis = null;
            }
            return OneMedBillItemClassVsHis;
        }

        public Model.MedBillItemClassVsHis SelectHisMedBillItemClassVsHis(string codeInHis)
        {
            Model.MedBillItemClassVsHis OneMedBillItemClassVsHis = null;

            OracleParameter[] paramItemClassVsHis = GetParameter("SelectOneHisMedBillItemClassVsHis");
            paramItemClassVsHis[0].Value = codeInHis;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_BILL_ITEM_CLASS_VS_HIS_Select_His, paramItemClassVsHis))
            {
                if (oleReader.Read())
                {
                    OneMedBillItemClassVsHis = new Model.MedBillItemClassVsHis();
                    if (!oleReader.IsDBNull(0))
                        OneMedBillItemClassVsHis.ClassCode = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        OneMedBillItemClassVsHis.CodeInHis = oleReader.GetString(1);
                }
                else
                    OneMedBillItemClassVsHis = null;
            }
            return OneMedBillItemClassVsHis;
        }
	}
}
