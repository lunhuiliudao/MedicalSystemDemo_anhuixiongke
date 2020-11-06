

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2011-03-02 16:24:52
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
	/// DAL MedVsHisDepId
	/// </summary>
	
	public partial class DALMedVsHisDepId
	{
		private static readonly string MED_VS_HIS_DEP_ID_Insert_SQL = "INSERT INTO MED_VS_HIS_DEP_ID (MED_PATIENT_ID,MED_VISIT_ID,MED_DEP_ID,HIS_ADM_WARD_DATE_TIME,HIS_PATIENT_ID,HIS_VISIT_ID) values (@MedPatientId,@MedVisitId,@MedDepId,@HisAdmWardDateTime,@HisPatientId,@HisVisitId)";
		private static readonly string MED_VS_HIS_DEP_ID_Update_SQL = "UPDATE MED_VS_HIS_DEP_ID SET MED_PATIENT_ID=@MedPatientId,MED_VISIT_ID=@MedVisitId,MED_DEP_ID=@MedDepId,HIS_ADM_WARD_DATE_TIME=@HisAdmWardDateTime,HIS_PATIENT_ID=@HisPatientId,HIS_VISIT_ID=@HisVisitId WHERE  MED_PATIENT_ID=@MedPatientId AND MED_VISIT_ID=@MedVisitId AND MED_DEP_ID=@MedDepId";
		private static readonly string MED_VS_HIS_DEP_ID_Delete_SQL = "DELETE MED_VS_HIS_DEP_ID WHERE  MED_PATIENT_ID=@MedPatientId AND MED_VISIT_ID=@MedVisitId AND MED_DEP_ID=@MedDepId";
		private static readonly string MED_VS_HIS_DEP_ID_Select_SQL = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_DEP_ID,HIS_ADM_WARD_DATE_TIME,HIS_PATIENT_ID,HIS_VISIT_ID FROM MED_VS_HIS_DEP_ID where  MED_PATIENT_ID=@MedPatientId AND MED_VISIT_ID=@MedVisitId AND MED_DEP_ID=@MedDepId";
		private static readonly string MED_VS_HIS_DEP_ID_Select_ALL_SQL = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_DEP_ID,HIS_ADM_WARD_DATE_TIME,HIS_PATIENT_ID,HIS_VISIT_ID FROM MED_VS_HIS_DEP_ID";
        private static readonly string MED_VS_HIS_DEP_ID_Select_His_SQL = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_DEP_ID,HIS_ADM_WARD_DATE_TIME,HIS_PATIENT_ID,HIS_VISIT_ID FROM MED_VS_HIS_DEP_ID where  HIS_PATIENT_ID=@HisPatientId AND HIS_VISIT_ID=@HisVisitId AND HIS_ADM_WARD_DATE_TIME=@HisAdmWardDateTime";
        private static readonly string MED_VS_HIS_DEP_ID_Select_Max_His_SQL = "SELECT isnull(max(MED_DEP_ID),0) from MED_VS_HIS_DEP_ID where MED_PATIENT_ID=@MedPatientId AND MED_VISIT_ID=@MedVisitId";
     
        private static readonly string MED_VS_HIS_DEP_ID_Insert = "INSERT INTO MED_VS_HIS_DEP_ID (MED_PATIENT_ID,MED_VISIT_ID,MED_DEP_ID,HIS_ADM_WARD_DATE_TIME,HIS_PATIENT_ID,HIS_VISIT_ID) values (:MedPatientId,:MedVisitId,:MedDepId,:HisAdmWardDateTime,:HisPatientId,:HisVisitId)";
		private static readonly string MED_VS_HIS_DEP_ID_Update = "UPDATE MED_VS_HIS_DEP_ID SET MED_PATIENT_ID=:MedPatientId,MED_VISIT_ID=:MedVisitId,MED_DEP_ID=:MedDepId,HIS_ADM_WARD_DATE_TIME=:HisAdmWardDateTime,HIS_PATIENT_ID=:HisPatientId,HIS_VISIT_ID=:HisVisitId WHERE  MED_PATIENT_ID=:MedPatientId AND MED_VISIT_ID=:MedVisitId AND MED_DEP_ID=:MedDepId";
		private static readonly string MED_VS_HIS_DEP_ID_Delete = "DELETE MED_VS_HIS_DEP_ID WHERE  MED_PATIENT_ID=:MedPatientId AND MED_VISIT_ID=:MedVisitId AND MED_DEP_ID=:MedDepId";
		private static readonly string MED_VS_HIS_DEP_ID_Select = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_DEP_ID,HIS_ADM_WARD_DATE_TIME,HIS_PATIENT_ID,HIS_VISIT_ID FROM MED_VS_HIS_DEP_ID where  MED_PATIENT_ID=:MedPatientId AND MED_VISIT_ID=:MedVisitId AND MED_DEP_ID=:MedDepId";
		private static readonly string MED_VS_HIS_DEP_ID_Select_ALL = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_DEP_ID,HIS_ADM_WARD_DATE_TIME,HIS_PATIENT_ID,HIS_VISIT_ID FROM MED_VS_HIS_DEP_ID";
        private static readonly string MED_VS_HIS_DEP_ID_Select_His = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_DEP_ID,HIS_ADM_WARD_DATE_TIME,HIS_PATIENT_ID,HIS_VISIT_ID FROM MED_VS_HIS_DEP_ID where  HIS_PATIENT_ID=:HisPatientId AND HIS_VISIT_ID=:HisVisitId AND HIS_ADM_WARD_DATE_TIME=:HisAdmWardDateTime";
        private static readonly string MED_VS_HIS_DEP_ID_Select_Max_His = "SELECT nvl(max(MED_DEP_ID),0) from MED_VS_HIS_DEP_ID where MED_PATIENT_ID=:MedPatientId AND MED_VISIT_ID=:MedVisitId";
        
		public DALMedVsHisDepId ()
		{
		}
		
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedVsHisDepId SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisDepId")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@MedPatientId",SqlDbType.VarChar),
						new SqlParameter("@MedVisitId",SqlDbType.Decimal),
						new SqlParameter("@MedDepId",SqlDbType.Decimal),
						new SqlParameter("@HisAdmWardDateTime",SqlDbType.DateTime),
						new SqlParameter("@HisPatientId",SqlDbType.VarChar),
						new SqlParameter("@HisVisitId",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedVsHisDepId")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@MedPatientId",SqlDbType.VarChar),
						new SqlParameter("@MedVisitId",SqlDbType.Decimal),
						new SqlParameter("@MedDepId",SqlDbType.Decimal),
						new SqlParameter("@HisAdmWardDateTime",SqlDbType.DateTime),
						new SqlParameter("@HisPatientId",SqlDbType.VarChar),
						new SqlParameter("@HisVisitId",SqlDbType.VarChar),
						new SqlParameter("@MedPatientId",SqlDbType.VarChar),
						new SqlParameter("@MedVisitId",SqlDbType.Decimal),
						new SqlParameter("@MedDepId",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedVsHisDepId")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@MedPatientId",SqlDbType.VarChar),
						new SqlParameter("@MedVisitId",SqlDbType.Decimal),
						new SqlParameter("@MedDepId",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "SelectMedVsHisDepId")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@MedPatientId",SqlDbType.VarChar),
						new SqlParameter("@MedVisitId",SqlDbType.Decimal),
						new SqlParameter("@MedDepId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedVsHisDepIdHis")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@HisPatientId",SqlDbType.VarChar),
						new SqlParameter("@HisVisitId",SqlDbType.Decimal),
						new SqlParameter("@HisAdmWardDateTime",SqlDbType.DateTime),
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisDepId")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@MedPatientId",SqlDbType.VarChar),
						new SqlParameter("@MedVisitId",SqlDbType.Decimal),
                    };
                }


            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedVsHisDepId 
		///Insert Table MED_VS_HIS_DEP_ID
		/// </summary>
		public int InsertMedVsHisDepIdSQL(MedVsHisDepId model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedVsHisDepId");
					if (model.MedPatientId != null)
						oneInert[0].Value = model.MedPatientId;
					else
						oneInert[0].Value = DBNull.Value;
                    if (model.MedVisitId.ToString() != null)
						oneInert[1].Value = model.MedVisitId;
					else
						oneInert[1].Value = DBNull.Value;
                    if (model.MedDepId.ToString() != null)
						oneInert[2].Value = model.MedDepId;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.HisAdmWardDateTime != null)
						oneInert[3].Value = model.HisAdmWardDateTime;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.HisPatientId != null)
						oneInert[4].Value = model.HisPatientId;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.HisVisitId != null)
						oneInert[5].Value = model.HisVisitId;
					else
						oneInert[5].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_DEP_ID_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedVsHisDepId 
		///Update Table     MED_VS_HIS_DEP_ID
		/// </summary>
		public int UpdateMedVsHisDepIdSQL(MedVsHisDepId model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedVsHisDepId");
					if (model.MedPatientId != null)
						oneUpdate[0].Value = model.MedPatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
                    if (model.MedVisitId.ToString() != null)
						oneUpdate[1].Value = model.MedVisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
                    if (model.MedDepId.ToString() != null)
						oneUpdate[2].Value = model.MedDepId;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.HisAdmWardDateTime != null)
						oneUpdate[3].Value = model.HisAdmWardDateTime;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.HisPatientId != null)
						oneUpdate[4].Value = model.HisPatientId;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.HisVisitId != null)
						oneUpdate[5].Value = model.HisVisitId;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.MedPatientId != null)
						oneUpdate[6].Value =model.MedPatientId;
					else
						oneUpdate[6].Value = DBNull.Value;
                    if (model.MedVisitId.ToString() != null)
						oneUpdate[7].Value =model.MedVisitId;
					else
						oneUpdate[7].Value = DBNull.Value;
                    if (model.MedDepId.ToString() != null)
						oneUpdate[8].Value =model.MedDepId;
					else
						oneUpdate[8].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_DEP_ID_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedVsHisDepId 
		///Delete Table MED_VS_HIS_DEP_ID by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_DEP_ID)
		/// </summary>
		public int DeleteMedVsHisDepIdSQL(string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_DEP_ID)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedVsHisDepId");
					if (MED_PATIENT_ID != null)
						oneDelete[0].Value =MED_PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (MED_VISIT_ID.ToString() != null)
						oneDelete[1].Value =MED_VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
                    if (MED_DEP_ID.ToString() != null)
						oneDelete[2].Value =MED_DEP_ID;
					else
						oneDelete[2].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_DEP_ID_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedVsHisDepId 
		///select Table MED_VS_HIS_DEP_ID by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_DEP_ID)
		/// </summary>
		public MedVsHisDepId  SelectMedVsHisDepIdSQL(string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_DEP_ID)
		{
			MedVsHisDepId model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedVsHisDepId");
				parameterValues[0].Value=MED_PATIENT_ID;
				parameterValues[1].Value=MED_VISIT_ID;
				parameterValues[2].Value=MED_DEP_ID;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedVsHisDepId();
						if (!oleReader.IsDBNull(0))
						{
							model.MedPatientId = oleReader["MED_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.MedVisitId = decimal.Parse(oleReader["MED_VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MedDepId = decimal.Parse(oleReader["MED_DEP_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.HisAdmWardDateTime = DateTime.Parse(oleReader["HIS_ADM_WARD_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim() ;
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
		public List<MedVsHisDepId> SelectMedVsHisDepIdListSQL()
		{
			List<MedVsHisDepId> modelList = new List<MedVsHisDepId>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Select_ALL_SQL, null))
			{
				while (oleReader.Read())
				{
					MedVsHisDepId model = new MedVsHisDepId();
						if (!oleReader.IsDBNull(0))
						{
							model.MedPatientId = oleReader["MED_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.MedVisitId = decimal.Parse(oleReader["MED_VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MedDepId = decimal.Parse(oleReader["MED_DEP_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.HisAdmWardDateTime = DateTime.Parse(oleReader["HIS_ADM_WARD_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
        #region  [获取一条记录SQL 根据HIS_ADM_WARD_DATE_TIME]
        /// <summary>
        ///Select    model  MedVsHisDepId 
        ///select Table MED_VS_HIS_DEP_ID by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_DEP_ID)
        /// </summary>
        public MedVsHisDepId SelectMedVsHisDepIdHisSQL(string HIS_PATIENT_ID, string HIS_VISIT_ID, DateTime HIS_ADM_WARD_DATE_TIME)
        {
            MedVsHisDepId model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedVsHisDepIdHis");
            parameterValues[0].Value = HIS_PATIENT_ID;
            parameterValues[1].Value = HIS_VISIT_ID;
            parameterValues[2].Value = HIS_ADM_WARD_DATE_TIME;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Select_His_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisDepId();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.MedPatientId = oleReader["MED_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.MedVisitId = decimal.Parse(oleReader["MED_VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.MedDepId = decimal.Parse(oleReader["MED_DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HisAdmWardDateTime = DateTime.Parse(oleReader["HIS_ADM_WARD_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion	
        /// <summary>
        /// 
        /// </summary>
        /// <param name="medPatientId"></param>
        /// <param name="medvisitId"></param>
        /// <returns></returns>
        public int SelectMaxMedVsHisDepIdSQL(string medPatientId,decimal medvisitId)
        {
            SqlParameter[] maxMedVsHis = GetParameterSQL("SelectMaxMedVsHisDepId");
            maxMedVsHis[0].Value = medPatientId;
            maxMedVsHis[1].Value = medvisitId;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Select_Max_His_SQL, maxMedVsHis))
            {
                if (oleReader.Read())
                {
                    return Convert.ToInt32(oleReader[0]);
                }
                else
                {
                    return 0;
                }
            }
        }

		#region [获取参数]
		/// <summary>
		///获取参数MedVsHisDepId Oracle
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisDepId")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":MedPatientId",OracleType.VarChar),
						new OracleParameter(":MedVisitId",OracleType.Number),
						new OracleParameter(":MedDepId",OracleType.Number),
						new OracleParameter(":HisAdmWardDateTime",OracleType.DateTime),
						new OracleParameter(":HisPatientId",OracleType.VarChar),
						new OracleParameter(":HisVisitId",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedVsHisDepId")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":MedPatientId",OracleType.VarChar),
						new OracleParameter(":MedVisitId",OracleType.Number),
						new OracleParameter(":MedDepId",OracleType.Number),
						new OracleParameter(":HisAdmWardDateTime",OracleType.DateTime),
						new OracleParameter(":HisPatientId",OracleType.VarChar),
						new OracleParameter(":HisVisitId",OracleType.VarChar),
						new OracleParameter(":MedPatientId",OracleType.VarChar),
						new OracleParameter(":MedVisitId",OracleType.Number),
						new OracleParameter(":MedDepId",OracleType.Number),
                    };
                }
				else if(sqlParms == "DeleteMedVsHisDepId")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":MedPatientId",OracleType.VarChar),
						new OracleParameter(":MedVisitId",OracleType.Number),
						new OracleParameter(":MedDepId",OracleType.Number),
                    };
                }
				else if(sqlParms == "SelectMedVsHisDepId")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":MedPatientId",OracleType.VarChar),
						new OracleParameter(":MedVisitId",OracleType.Number),
						new OracleParameter(":MedDepId",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectMedVsHisDepIdHis")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":HisPatientId",OracleType.VarChar),
						new OracleParameter(":HisVisitId",OracleType.Number),
						new OracleParameter(":HisAdmWardDateTime",OracleType.DateTime),
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisDepId")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":MedPatientId",OracleType.VarChar),
						new OracleParameter(":MedVisitId",OracleType.Number),
                    };
                }

            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedVsHisDepId 
		///Insert Table MED_VS_HIS_DEP_ID
		/// </summary>
		public int InsertMedVsHisDepId(MedVsHisDepId model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedVsHisDepId");
					if (model.MedPatientId != null)
						oneInert[0].Value = model.MedPatientId;
					else
						oneInert[0].Value = DBNull.Value;
                    if (model.MedVisitId.ToString() != null)
						oneInert[1].Value = model.MedVisitId;
					else
						oneInert[1].Value = DBNull.Value;
                    if (model.MedDepId.ToString() != null)
						oneInert[2].Value = model.MedDepId;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.HisAdmWardDateTime != null)
						oneInert[3].Value = model.HisAdmWardDateTime;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.HisPatientId != null)
						oneInert[4].Value = model.HisPatientId;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.HisVisitId != null)
						oneInert[5].Value = model.HisVisitId;
					else
						oneInert[5].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_DEP_ID_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedVsHisDepId 
		///Update Table     MED_VS_HIS_DEP_ID
		/// </summary>
		public int UpdateMedVsHisDepId(MedVsHisDepId model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedVsHisDepId");
					if (model.MedPatientId != null)
						oneUpdate[0].Value = model.MedPatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
                    if (model.MedVisitId.ToString() != null)
						oneUpdate[1].Value = model.MedVisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
                    if (model.MedDepId.ToString() != null)
						oneUpdate[2].Value = model.MedDepId;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.HisAdmWardDateTime != null)
						oneUpdate[3].Value = model.HisAdmWardDateTime;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.HisPatientId != null)
						oneUpdate[4].Value = model.HisPatientId;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.HisVisitId != null)
						oneUpdate[5].Value = model.HisVisitId;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.MedPatientId != null)
						oneUpdate[6].Value =model.MedPatientId;
					else
						oneUpdate[6].Value = DBNull.Value;
                    if (model.MedVisitId.ToString() != null)
						oneUpdate[7].Value =model.MedVisitId;
					else
						oneUpdate[7].Value = DBNull.Value;
                    if (model.MedDepId.ToString() != null)
						oneUpdate[8].Value =model.MedDepId;
					else
						oneUpdate[8].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_DEP_ID_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedVsHisDepId 
		///Delete Table MED_VS_HIS_DEP_ID by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_DEP_ID)
		/// </summary>
		public int DeleteMedVsHisDepId(string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_DEP_ID)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedVsHisDepId");
					if (MED_PATIENT_ID != null)
						oneDelete[0].Value =MED_PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (MED_VISIT_ID.ToString() != null)
						oneDelete[1].Value =MED_VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
                    if (MED_DEP_ID.ToString() != null)
						oneDelete[2].Value =MED_DEP_ID;
					else
						oneDelete[2].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_DEP_ID_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedVsHisDepId 
		///select Table MED_VS_HIS_DEP_ID by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_DEP_ID)
		/// </summary>
		public MedVsHisDepId  SelectMedVsHisDepId(string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_DEP_ID)
		{
			MedVsHisDepId model;
			OracleParameter[] parameterValues = GetParameter("SelectMedVsHisDepId");
				parameterValues[0].Value=MED_PATIENT_ID;
				parameterValues[1].Value=MED_VISIT_ID;
				parameterValues[2].Value=MED_DEP_ID;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedVsHisDepId();
						if (!oleReader.IsDBNull(0))
						{
							model.MedPatientId = oleReader["MED_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.MedVisitId = decimal.Parse(oleReader["MED_VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MedDepId = decimal.Parse(oleReader["MED_DEP_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.HisAdmWardDateTime = DateTime.Parse(oleReader["HIS_ADM_WARD_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim() ;
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
		public List<MedVsHisDepId> SelectMedVsHisDepIdList()
		{
			List<MedVsHisDepId> modelList = new List<MedVsHisDepId>();
		    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Select_ALL, null))
			{
				while (oleReader.Read())
				{
					MedVsHisDepId model = new MedVsHisDepId();
						if (!oleReader.IsDBNull(0))
						{
							model.MedPatientId = oleReader["MED_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.MedVisitId = decimal.Parse(oleReader["MED_VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MedDepId = decimal.Parse(oleReader["MED_DEP_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.HisAdmWardDateTime = DateTime.Parse(oleReader["HIS_ADM_WARD_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
        #region  [获取一条记录 根据HIS_ADM_WARD_DATE_TIME]
        /// <summary>
        ///Select    model  MedVsHisDepId 
        ///select Table MED_VS_HIS_DEP_ID by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_DEP_ID)
        /// </summary>
        public MedVsHisDepId SelectMedVsHisDepIdHis(string HIS_PATIENT_ID, string HIS_VISIT_ID, DateTime HIS_ADM_WARD_DATE_TIME)
        {
            MedVsHisDepId model;
            OracleParameter[] parameterValues = GetParameter("SelectMedVsHisDepIdHis");
            parameterValues[0].Value = HIS_PATIENT_ID;
            parameterValues[1].Value = HIS_VISIT_ID;
            parameterValues[2].Value = HIS_ADM_WARD_DATE_TIME;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Select_His, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisDepId();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.MedPatientId = oleReader["MED_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.MedVisitId = decimal.Parse(oleReader["MED_VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.MedDepId = decimal.Parse(oleReader["MED_DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HisAdmWardDateTime = DateTime.Parse(oleReader["HIS_ADM_WARD_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion	
        /// <summary>
        /// 
        /// </summary>
        /// <param name="medPatientId"></param>
        /// <param name="medvisitId"></param>
        /// <returns></returns>
        public int SelectMaxMedVsHisDepId(string medPatientId, decimal medvisitId)
        {
            OracleParameter[] maxMedVsHis = GetParameter("SelectMaxMedVsHisDepId");
            maxMedVsHis[0].Value = medPatientId;
            maxMedVsHis[1].Value = medvisitId;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Select_Max_His, maxMedVsHis))
            {
                if (oleReader.Read())
                {
                    return (int)oleReader.GetDecimal(0);
                }
                else
                {
                    return 0;
                }
            }
        }
	}
}
