

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:03:05
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
	/// DAL MedVsHisPat
	/// </summary>
	
	public partial class DALMedVsHisPat
	{
		
		private static readonly string MED_VS_HIS_PAT_Insert_SQL = "INSERT INTO MED_VS_HIS_PAT (MED_PATIENT_ID,MED_VISIT_ID,HIS_PATIENT_ID,HIS_INP_NO,HIS_VISIT_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08) values (@MedPatientId,@MedVisitId,@HisPatientId,@HisInpNo,@HisVisitId,@CreateDate,@Reserved01,@Reserved02,@Reserved03,@Reserved04,@Reserved05,@Reserved06,@Reserved07,@Reserved08)";
        private static readonly string MED_VS_HIS_PAT_Update_SQL = "UPDATE MED_VS_HIS_PAT SET MED_PATIENT_ID=@MedPatientId,MED_VISIT_ID=@MedVisitId,HIS_PATIENT_ID=@HisPatientId,HIS_INP_NO=@HisInpNo,HIS_VISIT_ID=@HisVisitId,CREATE_DATE=@CreateDate,RESERVED01=@Reserved01,RESERVED02=@Reserved02,RESERVED03=@Reserved03,RESERVED04=@Reserved04,RESERVED05=@Reserved05,RESERVED06=@Reserved06,RESERVED07=@Reserved07,RESERVED08=@Reserved08 WHERE MED_PATIENT_ID=@MedPatientId AND MED_VISIT_ID=@MedVisitId";
        private static readonly string MED_VS_HIS_PAT_Delete_SQL = "Delete MED_VS_HIS_PAT WHERE MED_PATIENT_ID=@MedPatientId AND MED_VISIT_ID=@MedVisitId";
        private static readonly string MED_VS_HIS_PAT_Select_SQL = "SELECT MED_PATIENT_ID,MED_VISIT_ID,HIS_PATIENT_ID,HIS_INP_NO,HIS_VISIT_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08 FROM MED_VS_HIS_PAT where MED_PATIENT_ID=@MedPatientId AND MED_VISIT_ID=@MedVisitId";
		private static readonly string MED_VS_HIS_PAT_Select_ALL_SQL = "SELECT MED_PATIENT_ID,MED_VISIT_ID,HIS_PATIENT_ID,HIS_INP_NO,HIS_VISIT_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08 FROM MED_VS_HIS_PAT";
        private static readonly string MED_VS_HIS_PAT_Select_Max_His_SQL = "SELECT isnull(max(MED_VISIT_ID),0) from MED_VS_HIS_PAT where MED_PATIENT_ID = @medPatientId";
        private static readonly string MED_VS_HIS_PAT_Select_His_SQL = "SELECT MED_PATIENT_ID, MED_VISIT_ID, HIS_PATIENT_ID, HIS_INP_NO, HIS_VISIT_ID, create_date, reserved01, reserved02, reserved03, reserved04, reserved05, reserved06, reserved07, reserved08 from med_vs_his_pat where his_patient_id = @hisPatientId and his_inp_no = @hisInpNo and his_visit_id = @hisVisitId";
        
        private static readonly string MED_VS_HIS_PAT_Insert = "INSERT INTO MED_VS_HIS_PAT (MED_PATIENT_ID,MED_VISIT_ID,HIS_PATIENT_ID,HIS_INP_NO,HIS_VISIT_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08) values (:MedPatientId,:MedVisitId,:HisPatientId,:HisInpNo,:HisVisitId,:CreateDate,:Reserved01,:Reserved02,:Reserved03,:Reserved04,:Reserved05,:Reserved06,:Reserved07,:Reserved08)";
        private static readonly string MED_VS_HIS_PAT_Update = "UPDATE MED_VS_HIS_PAT SET MED_PATIENT_ID=:MedPatientId,MED_VISIT_ID=:MedVisitId,HIS_PATIENT_ID=:HisPatientId,HIS_INP_NO=:HisInpNo,HIS_VISIT_ID=:HisVisitId,CREATE_DATE=:CreateDate,RESERVED01=:Reserved01,RESERVED02=:Reserved02,RESERVED03=:Reserved03,RESERVED04=:Reserved04,RESERVED05=:Reserved05,RESERVED06=:Reserved06,RESERVED07=:Reserved07,RESERVED08=:Reserved08 WHERE MED_PATIENT_ID=:MedPatientId AND MED_VISIT_ID=:MedVisitId";
        private static readonly string MED_VS_HIS_PAT_Delete = "Delete MED_VS_HIS_PAT WHERE MED_PATIENT_ID=:MedPatientId AND MED_VISIT_ID=:MedVisitId";
        private static readonly string MED_VS_HIS_PAT_Select = "SELECT MED_PATIENT_ID,MED_VISIT_ID,HIS_PATIENT_ID,HIS_INP_NO,HIS_VISIT_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08 FROM MED_VS_HIS_PAT where MED_PATIENT_ID=:MedPatientId AND MED_VISIT_ID=:MedVisitId";
		private static readonly string MED_VS_HIS_PAT_Select_ALL = "SELECT MED_PATIENT_ID,MED_VISIT_ID,HIS_PATIENT_ID,HIS_INP_NO,HIS_VISIT_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08 FROM MED_VS_HIS_PAT";
        private static readonly string MED_VS_HIS_PAT_Select_Max_His = "SELECT nvl(max(MED_VISIT_ID),0) from MED_VS_HIS_PAT where MED_PATIENT_ID = :medPatientId";
        private static readonly string MED_VS_HIS_PAT_Select_His = "SELECT MED_PATIENT_ID, MED_VISIT_ID, HIS_PATIENT_ID, HIS_INP_NO, HIS_VISIT_ID, create_date, reserved01, reserved02, reserved03, reserved04, reserved05, reserved06, reserved07, reserved08 from med_vs_his_pat where his_patient_id = :hisPatientId and his_inp_no = :hisInpNo and his_visit_id = :hisVisitId";

        public DALMedVsHisPat ()
		{
		}
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedVsHisPat SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisPat")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@MedPatientId",SqlDbType.VarChar),
							new SqlParameter("@MedVisitId",SqlDbType.Decimal),
							new SqlParameter("@HisPatientId",SqlDbType.VarChar),
							new SqlParameter("@HisInpNo",SqlDbType.VarChar),
							new SqlParameter("@HisVisitId",SqlDbType.VarChar),
							new SqlParameter("@CreateDate",SqlDbType.DateTime),
							new SqlParameter("@Reserved01",SqlDbType.VarChar),
							new SqlParameter("@Reserved02",SqlDbType.VarChar),
							new SqlParameter("@Reserved03",SqlDbType.VarChar),
							new SqlParameter("@Reserved04",SqlDbType.VarChar),
							new SqlParameter("@Reserved05",SqlDbType.VarChar),
							new SqlParameter("@Reserved06",SqlDbType.VarChar),
							new SqlParameter("@Reserved07",SqlDbType.VarChar),
							new SqlParameter("@Reserved08",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedVsHisPat")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@MedPatientId",SqlDbType.VarChar),
							new SqlParameter("@MedVisitId",SqlDbType.Decimal),
							new SqlParameter("@HisPatientId",SqlDbType.VarChar),
							new SqlParameter("@HisInpNo",SqlDbType.VarChar),
							new SqlParameter("@HisVisitId",SqlDbType.VarChar),
							new SqlParameter("@CreateDate",SqlDbType.DateTime),
							new SqlParameter("@Reserved01",SqlDbType.VarChar),
							new SqlParameter("@Reserved02",SqlDbType.VarChar),
							new SqlParameter("@Reserved03",SqlDbType.VarChar),
							new SqlParameter("@Reserved04",SqlDbType.VarChar),
							new SqlParameter("@Reserved05",SqlDbType.VarChar),
							new SqlParameter("@Reserved06",SqlDbType.VarChar),
							new SqlParameter("@Reserved07",SqlDbType.VarChar),
							new SqlParameter("@Reserved08",SqlDbType.VarChar),
							new SqlParameter("@MedPatientId",SqlDbType.VarChar),
							new SqlParameter("@MedVisitId",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedVsHisPat")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@MedPatientId",SqlDbType.VarChar),
							new SqlParameter("@MedVisitId",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "SelectMedVsHisPat")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@MedPatientId",SqlDbType.VarChar),
						new SqlParameter("@MedVisitId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisPat")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@MedPatientId",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedVsHisPatHisForHis")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@HisPatientId",SqlDbType.VarChar),
						new SqlParameter("@HisInpNo",SqlDbType.VarChar),
						new SqlParameter("@HisVisitId",SqlDbType.VarChar),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedVsHisPat 
		///Insert Table MED_VS_HIS_PAT
		/// </summary>
		public int InsertMedVsHisPatSQL(MedVsHisPat model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedVsHisPat");
					if (model.MedPatientId != null)
						oneInert[0].Value = model.MedPatientId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.MedVisitId.ToString() != null)
						oneInert[1].Value = model.MedVisitId;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.HisPatientId != null)
						oneInert[2].Value = model.HisPatientId;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.HisInpNo != null)
						oneInert[3].Value = model.HisInpNo;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.HisVisitId != null)
						oneInert[4].Value = model.HisVisitId;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.CreateDate > DateTime.MinValue)
						oneInert[5].Value = model.CreateDate;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.Reserved01 != null)
						oneInert[6].Value = model.Reserved01;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.Reserved02 != null)
						oneInert[7].Value = model.Reserved02;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.Reserved03 != null)
						oneInert[8].Value = model.Reserved03;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.Reserved04 != null)
						oneInert[9].Value = model.Reserved04;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.Reserved05 != null)
						oneInert[10].Value = model.Reserved05;
					else
						oneInert[10].Value = DBNull.Value;
					if (model.Reserved06 != null)
						oneInert[11].Value = model.Reserved06;
					else
						oneInert[11].Value = DBNull.Value;
					if (model.Reserved07 != null)
						oneInert[12].Value = model.Reserved07;
					else
						oneInert[12].Value = DBNull.Value;
					if (model.Reserved08 != null)
						oneInert[13].Value = model.Reserved08;
					else
						oneInert[13].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_PAT_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedVsHisPat 
		///Update Table     MED_VS_HIS_PAT
		/// </summary>
		public int UpdateMedVsHisPatSQL(MedVsHisPat model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedVsHisPat");
					if (model.MedPatientId != null)
						oneUpdate[0].Value = model.MedPatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.MedVisitId.ToString() != null)
						oneUpdate[1].Value = model.MedVisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.HisPatientId != null)
						oneUpdate[2].Value = model.HisPatientId;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.HisInpNo != null)
						oneUpdate[3].Value = model.HisInpNo;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.HisVisitId != null)
						oneUpdate[4].Value = model.HisVisitId;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.CreateDate > DateTime.MinValue)
						oneUpdate[5].Value = model.CreateDate;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.Reserved01 != null)
						oneUpdate[6].Value = model.Reserved01;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.Reserved02 != null)
						oneUpdate[7].Value = model.Reserved02;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.Reserved03 != null)
						oneUpdate[8].Value = model.Reserved03;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.Reserved04 != null)
						oneUpdate[9].Value = model.Reserved04;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.Reserved05 != null)
						oneUpdate[10].Value = model.Reserved05;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.Reserved06 != null)
						oneUpdate[11].Value = model.Reserved06;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.Reserved07 != null)
						oneUpdate[12].Value = model.Reserved07;
					else
						oneUpdate[12].Value = DBNull.Value;
					if (model.Reserved08 != null)
						oneUpdate[13].Value = model.Reserved08;
					else
						oneUpdate[13].Value = DBNull.Value;
					if (model.MedPatientId != null)
						oneUpdate[14].Value =model.MedPatientId;
					else
						oneUpdate[14].Value = DBNull.Value;
					if (model.MedVisitId.ToString() != null)
						oneUpdate[15].Value =model.MedVisitId;
					else
						oneUpdate[15].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_PAT_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedVsHisPat 
		///Delete Table MED_VS_HIS_PAT by (string MED_PATIENT_ID,decimal MED_VISIT_ID)
		/// </summary>
		public int DeleteMedVsHisPatSQL(string MED_PATIENT_ID,decimal MED_VISIT_ID)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedVsHisPat");
					if (MED_PATIENT_ID != null)
						oneDelete[0].Value =MED_PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
					if (MED_VISIT_ID.ToString() != null)
						oneDelete[1].Value =MED_VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_PAT_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedVsHisPat 
		///select Table MED_VS_HIS_PAT by (string MED_PATIENT_ID,decimal MED_VISIT_ID)
		/// </summary>
		public MedVsHisPat  SelectMedVsHisPatSQL(string MED_PATIENT_ID,decimal MED_VISIT_ID)
		{
			MedVsHisPat model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedVsHisPat");
				parameterValues[0].Value=MED_PATIENT_ID;
				parameterValues[1].Value=MED_VISIT_ID;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedVsHisPat();
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
							model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.HisInpNo = oleReader["HIS_INP_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved04 = oleReader["RESERVED04"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Reserved05 = oleReader["RESERVED05"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Reserved06 = oleReader["RESERVED06"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.Reserved07 = oleReader["RESERVED07"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.Reserved08 = oleReader["RESERVED08"].ToString().Trim() ;
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
		public List<MedVsHisPat> SelectMedVsHisPatListSQL()
		{
			List<MedVsHisPat> modelList = new List<MedVsHisPat>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedVsHisPat model = new MedVsHisPat();
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
							model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.HisInpNo = oleReader["HIS_INP_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved04 = oleReader["RESERVED04"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Reserved05 = oleReader["RESERVED05"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Reserved06 = oleReader["RESERVED06"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.Reserved07 = oleReader["RESERVED07"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.Reserved08 = oleReader["RESERVED08"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
        public int SelectMaxMedVsHisPatSQL(string patientId)
        {
            SqlParameter[] maxMedVsHis = GetParameterSQL("SelectMaxMedVsHisPat");
            maxMedVsHis[0].Value = patientId;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Select_Max_His_SQL, maxMedVsHis))
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

        public Model.MedVsHisPat SelectMedVsHisPatHisSQL(string hisPatientId, string hisInpNo, string hisVisitId)
        {
            Model.MedVsHisPat oneMedVsHisPat = null;
            SqlParameter[] MedVsHisPatParams = GetParameterSQL("SelectMedVsHisPatHisForHis");
            MedVsHisPatParams[0].Value = hisPatientId;
            MedVsHisPatParams[1].Value = hisInpNo;
            MedVsHisPatParams[2].Value = hisVisitId;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Select_His_SQL, MedVsHisPatParams))
            {
                if (oleReader.Read())
                {
                    oneMedVsHisPat = new Model.MedVsHisPat();
                    if (!oleReader.IsDBNull(0))
                        oneMedVsHisPat.MedPatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisPat.MedVisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisPat.HisPatientId = oleReader.GetString(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisPat.HisInpNo = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisPat.HisVisitId = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisPat.CreateDate = oleReader.GetDateTime(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisPat.Reserved01 = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisPat.Reserved02 = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        oneMedVsHisPat.Reserved03 = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        oneMedVsHisPat.Reserved04 = oleReader.GetString(9);
                    if (!oleReader.IsDBNull(10))
                        oneMedVsHisPat.Reserved05 = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        oneMedVsHisPat.Reserved06 = oleReader.GetString(11);
                    if (!oleReader.IsDBNull(12))
                        oneMedVsHisPat.Reserved07 = oleReader.GetString(12);
                    if (!oleReader.IsDBNull(13))
                        oneMedVsHisPat.Reserved08 = oleReader.GetString(13);
                }
                else
                    oneMedVsHisPat = null;
            }
            return oneMedVsHisPat;
        }

		#region [获取参数]
		/// <summary>
		///获取参数MedVsHisPat
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisPat")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":MedPatientId",OracleType.VarChar),
							new OracleParameter(":MedVisitId",OracleType.Number),
							new OracleParameter(":HisPatientId",OracleType.VarChar),
							new OracleParameter(":HisInpNo",OracleType.VarChar),
							new OracleParameter(":HisVisitId",OracleType.VarChar),
							new OracleParameter(":CreateDate",OracleType.DateTime),
							new OracleParameter(":Reserved01",OracleType.VarChar),
							new OracleParameter(":Reserved02",OracleType.VarChar),
							new OracleParameter(":Reserved03",OracleType.VarChar),
							new OracleParameter(":Reserved04",OracleType.VarChar),
							new OracleParameter(":Reserved05",OracleType.VarChar),
							new OracleParameter(":Reserved06",OracleType.VarChar),
							new OracleParameter(":Reserved07",OracleType.VarChar),
							new OracleParameter(":Reserved08",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedVsHisPat")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":MedPatientId",OracleType.VarChar),
							new OracleParameter(":MedVisitId",OracleType.Number),
							new OracleParameter(":HisPatientId",OracleType.VarChar),
							new OracleParameter(":HisInpNo",OracleType.VarChar),
							new OracleParameter(":HisVisitId",OracleType.VarChar),
							new OracleParameter(":CreateDate",OracleType.DateTime),
							new OracleParameter(":Reserved01",OracleType.VarChar),
							new OracleParameter(":Reserved02",OracleType.VarChar),
							new OracleParameter(":Reserved03",OracleType.VarChar),
							new OracleParameter(":Reserved04",OracleType.VarChar),
							new OracleParameter(":Reserved05",OracleType.VarChar),
							new OracleParameter(":Reserved06",OracleType.VarChar),
							new OracleParameter(":Reserved07",OracleType.VarChar),
							new OracleParameter(":Reserved08",OracleType.VarChar),
							new OracleParameter(":MedPatientId",SqlDbType.VarChar),
							new OracleParameter(":MedVisitId",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedVsHisPat")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":MedPatientId",OracleType.VarChar),
							new OracleParameter(":MedVisitId",OracleType.Number),
                    };
                }
				else if(sqlParms == "SelectMedVsHisPat")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":MedPatientId",OracleType.VarChar),
							new OracleParameter(":MedVisitId",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisPat")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":MedPatientId",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedVsHisPatHisForHis")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":HisPatientId",OracleType.VarChar),
						new OracleParameter(":HisInpNo",OracleType.VarChar),
						new OracleParameter(":HisVisitId",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedVsHisPat 
		///Insert Table MED_VS_HIS_PAT
		/// </summary>
		public int InsertMedVsHisPat(MedVsHisPat model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedVsHisPat");
					if (model.MedPatientId != null)
						oneInert[0].Value = model.MedPatientId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.MedVisitId.ToString() != null)
						oneInert[1].Value = model.MedVisitId;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.HisPatientId != null)
						oneInert[2].Value = model.HisPatientId;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.HisInpNo != null)
						oneInert[3].Value = model.HisInpNo;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.HisVisitId != null)
						oneInert[4].Value = model.HisVisitId;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.CreateDate > DateTime.MinValue)
						oneInert[5].Value = model.CreateDate;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.Reserved01 != null)
						oneInert[6].Value = model.Reserved01;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.Reserved02 != null)
						oneInert[7].Value = model.Reserved02;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.Reserved03 != null)
						oneInert[8].Value = model.Reserved03;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.Reserved04 != null)
						oneInert[9].Value = model.Reserved04;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.Reserved05 != null)
						oneInert[10].Value = model.Reserved05;
					else
						oneInert[10].Value = DBNull.Value;
					if (model.Reserved06 != null)
						oneInert[11].Value = model.Reserved06;
					else
						oneInert[11].Value = DBNull.Value;
					if (model.Reserved07 != null)
						oneInert[12].Value = model.Reserved07;
					else
						oneInert[12].Value = DBNull.Value;
					if (model.Reserved08 != null)
						oneInert[13].Value = model.Reserved08;
					else
						oneInert[13].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_PAT_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedVsHisPat 
		///Update Table     MED_VS_HIS_PAT
		/// </summary>
		public int UpdateMedVsHisPat(MedVsHisPat model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedVsHisPat");
					if (model.MedPatientId != null)
						oneUpdate[0].Value = model.MedPatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.MedVisitId.ToString() != null)
						oneUpdate[1].Value = model.MedVisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.HisPatientId != null)
						oneUpdate[2].Value = model.HisPatientId;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.HisInpNo != null)
						oneUpdate[3].Value = model.HisInpNo;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.HisVisitId != null)
						oneUpdate[4].Value = model.HisVisitId;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.CreateDate > DateTime.MinValue)
						oneUpdate[5].Value = model.CreateDate;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.Reserved01 != null)
						oneUpdate[6].Value = model.Reserved01;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.Reserved02 != null)
						oneUpdate[7].Value = model.Reserved02;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.Reserved03 != null)
						oneUpdate[8].Value = model.Reserved03;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.Reserved04 != null)
						oneUpdate[9].Value = model.Reserved04;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.Reserved05 != null)
						oneUpdate[10].Value = model.Reserved05;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.Reserved06 != null)
						oneUpdate[11].Value = model.Reserved06;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.Reserved07 != null)
						oneUpdate[12].Value = model.Reserved07;
					else
						oneUpdate[12].Value = DBNull.Value;
					if (model.Reserved08 != null)
						oneUpdate[13].Value = model.Reserved08;
					else
						oneUpdate[13].Value = DBNull.Value;
					if (model.MedPatientId != null)
						oneUpdate[14].Value =model.MedPatientId;
					else
						oneUpdate[14].Value = DBNull.Value;
					if (model.MedVisitId.ToString() != null)
						oneUpdate[15].Value =model.MedVisitId;
					else
						oneUpdate[15].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_PAT_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedVsHisPat 
		///Delete Table MED_VS_HIS_PAT by (string MED_PATIENT_ID,decimal MED_VISIT_ID)
		/// </summary>
		public int DeleteMedVsHisPat(string MED_PATIENT_ID,decimal MED_VISIT_ID)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedVsHisPat");
					if (MED_PATIENT_ID != null)
						oneDelete[0].Value =MED_PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
					if (MED_VISIT_ID.ToString() != null)
						oneDelete[1].Value =MED_VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_PAT_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedVsHisPat 
		///select Table MED_VS_HIS_PAT by (string MED_PATIENT_ID,decimal MED_VISIT_ID)
		/// </summary>
		public MedVsHisPat  SelectMedVsHisPat(string MED_PATIENT_ID,decimal MED_VISIT_ID)
		{
			MedVsHisPat model;
			OracleParameter[] parameterValues = GetParameter("SelectMedVsHisPat");
				parameterValues[0].Value=MED_PATIENT_ID;
				parameterValues[1].Value=MED_VISIT_ID;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedVsHisPat();
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
							model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.HisInpNo = oleReader["HIS_INP_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved04 = oleReader["RESERVED04"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Reserved05 = oleReader["RESERVED05"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Reserved06 = oleReader["RESERVED06"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.Reserved07 = oleReader["RESERVED07"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.Reserved08 = oleReader["RESERVED08"].ToString().Trim() ;
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
		public List<MedVsHisPat> SelectMedVsHisPatList()
		{
			List<MedVsHisPat> modelList = new List<MedVsHisPat>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedVsHisPat model = new MedVsHisPat();
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
							model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.HisInpNo = oleReader["HIS_INP_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved04 = oleReader["RESERVED04"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Reserved05 = oleReader["RESERVED05"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Reserved06 = oleReader["RESERVED06"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.Reserved07 = oleReader["RESERVED07"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.Reserved08 = oleReader["RESERVED08"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
        public int SelectMaxMedVsHisPat(string patientId)
        {
            OracleParameter[] maxMedVsHis = GetParameter("SelectMaxMedVsHisPat");
            maxMedVsHis[0].Value = patientId;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Select_Max_His, maxMedVsHis))
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

        public Model.MedVsHisPat SelectMedVsHisPatHis(string hisPatientId, string hisInpNo, string hisVisitId)
        {
            Model.MedVsHisPat oneMedVsHisPat = null;
            OracleParameter[] MedVsHisPatParams = GetParameter("SelectMedVsHisPatHisForHis");
            MedVsHisPatParams[0].Value = hisPatientId;
            MedVsHisPatParams[1].Value = hisInpNo;
            MedVsHisPatParams[2].Value = hisVisitId;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Select_His, MedVsHisPatParams))
            {
                if (oleReader.Read())
                {
                    oneMedVsHisPat = new Model.MedVsHisPat();
                    if (!oleReader.IsDBNull(0))
                        oneMedVsHisPat.MedPatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisPat.MedVisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisPat.HisPatientId = oleReader.GetString(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisPat.HisInpNo = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisPat.HisVisitId = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisPat.CreateDate = oleReader.GetDateTime(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisPat.Reserved01 = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisPat.Reserved02 = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        oneMedVsHisPat.Reserved03 = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        oneMedVsHisPat.Reserved04 = oleReader.GetString(9);
                    if (!oleReader.IsDBNull(10))
                        oneMedVsHisPat.Reserved05 = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        oneMedVsHisPat.Reserved06 = oleReader.GetString(11);
                    if (!oleReader.IsDBNull(12))
                        oneMedVsHisPat.Reserved07 = oleReader.GetString(12);
                    if (!oleReader.IsDBNull(13))
                        oneMedVsHisPat.Reserved08 = oleReader.GetString(13);
                }
                else
                    oneMedVsHisPat = null;
            }
            return oneMedVsHisPat;
        }
	}
}
