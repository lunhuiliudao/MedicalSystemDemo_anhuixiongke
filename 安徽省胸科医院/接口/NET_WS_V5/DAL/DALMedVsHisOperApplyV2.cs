

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 21:56:40
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
	/// DAL MedVsHisOperApplyV2
	/// </summary>
	
	public partial class DALMedVsHisOperApplyV2
	{
		
		private static readonly string MED_VS_HIS_OPER_APPLY_V2_Insert_SQL = "INSERT INTO MED_VS_HIS_OPER_APPLY_V2 (MED_PATIENT_ID,MED_VISIT_ID,MED_SCHEDULE_ID,HIS_APPLY_NO,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,REQ_DATE_TIME) values (@MedPatientId,@MedVisitId,@MedScheduleId,@HisApplyNo,@HisPatientId,@HisVisitId,@HisScheduleId,@ReqDateTime)";
        private static readonly string MED_VS_HIS_OPER_APPLY_V2_Update_SQL = "UPDATE MED_VS_HIS_OPER_APPLY_V2 SET MED_PATIENT_ID=@MedPatientId,MED_VISIT_ID=@MedVisitId,MED_SCHEDULE_ID=@MedScheduleId,HIS_APPLY_NO=@HisApplyNo,HIS_PATIENT_ID=@HisPatientId,HIS_VISIT_ID=@HisVisitId,HIS_SCHEDULE_ID=@HisScheduleId,REQ_DATE_TIME=@ReqDateTime WHERE MED_PATIENT_ID=@MedPatientIdP AND MED_VISIT_ID=@MedVisitIdP AND MED_SCHEDULE_ID=@MedScheduleIdP";
        private static readonly string MED_VS_HIS_OPER_APPLY_V2_Delete_SQL = "Delete MED_VS_HIS_OPER_APPLY_V2 WHERE MED_PATIENT_ID=@MedPatientId AND MED_VISIT_ID=@MedVisitId AND MED_SCHEDULE_ID=@MedScheduleId";
        private static readonly string MED_VS_HIS_OPER_APPLY_V2_Select_SQL = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_SCHEDULE_ID,HIS_APPLY_NO,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,REQ_DATE_TIME FROM MED_VS_HIS_OPER_APPLY_V2 where MED_PATIENT_ID=@MedPatientId AND MED_VISIT_ID=@MedVisitId AND MED_SCHEDULE_ID=@MedScheduleId";
		private static readonly string MED_VS_HIS_OPER_APPLY_V2_Select_ALL_SQL = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_SCHEDULE_ID,HIS_APPLY_NO,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,REQ_DATE_TIME FROM MED_VS_HIS_OPER_APPLY_V2";
        private static readonly string MED_VS_HIS_OPER_APPLY_V2_Select_ALL = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_SCHEDULE_ID,HIS_APPLY_NO,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,REQ_DATE_TIME FROM MED_VS_HIS_OPER_APPLY_V2";
        private static readonly string MED_VS_HIS_OPER_APPLY_V2_ReqDateTime_Select_Count_SQL = "select Count(*) from Med_Vs_His_Oper_Apply_V2 where his_apply_no = @hisApplyNo and his_patient_id = @hisPatientId and his_visit_id = @hisVisitId and his_schedule_id = @hisScheduleId and req_date_time = @reqDateTime";
        private static readonly string MED_VS_HIS_OPER_APPLY_V2_Select_Count_SQL = "select Count(*) from Med_Vs_His_Oper_Apply_V2 where his_apply_no = @hisApplyNo and his_patient_id = @hisPatientId and his_visit_id = @hisVisitId and his_schedule_id = @hisScheduleId";
        private static readonly string MED_VS_HIS_OPER_APPLY_V2_His_Select_SQL = "select med_patient_id, med_visit_id, med_schedule_id, his_apply_no, his_patient_id, his_visit_id, his_schedule_id, req_date_time from Med_Vs_His_Oper_Apply_V2 where his_apply_no = @hisApplyNo and his_patient_id = @hisPatientId and his_visit_id = @hisVisitId and his_schedule_id = @hisScheduleId ";

        private static readonly string MED_VS_HIS_OPER_APPLY_V2_His_Select_List_SQL = "select med_patient_id, med_visit_id, med_schedule_id, his_apply_no, his_patient_id, his_visit_id, his_schedule_id, req_date_time from Med_Vs_His_Oper_Apply_V2 where   his_patient_id = @hisPatientId and his_visit_id = @hisVisitId   ";

        private static readonly string MED_VS_HIS_OPER_APPLY_V2_Insert = "INSERT INTO MED_VS_HIS_OPER_APPLY_V2 (MED_PATIENT_ID,MED_VISIT_ID,MED_SCHEDULE_ID,HIS_APPLY_NO,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,REQ_DATE_TIME) values (:MedPatientId,:MedVisitId,:MedScheduleId,:HisApplyNo,:HisPatientId,:HisVisitId,:HisScheduleId,:ReqDateTime)";
        private static readonly string MED_VS_HIS_OPER_APPLY_V2_Update = "UPDATE MED_VS_HIS_OPER_APPLY_V2 SET MED_PATIENT_ID=:MedPatientId,MED_VISIT_ID=:MedVisitId,MED_SCHEDULE_ID=:MedScheduleId,HIS_APPLY_NO=:HisApplyNo,HIS_PATIENT_ID=:HisPatientId,HIS_VISIT_ID=:HisVisitId,HIS_SCHEDULE_ID=:HisScheduleId,REQ_DATE_TIME=:ReqDateTime WHERE MED_PATIENT_ID=:MedPatientId AND MED_VISIT_ID=:MedVisitId AND MED_SCHEDULE_ID=:MedScheduleId";
        private static readonly string MED_VS_HIS_OPER_APPLY_V2_Delete = "Delete MED_VS_HIS_OPER_APPLY_V2 WHERE MED_PATIENT_ID=:MedPatientId AND MED_VISIT_ID=:MedVisitId AND MED_SCHEDULE_ID=:MedScheduleId";
        private static readonly string MED_VS_HIS_OPER_APPLY_V2_Select = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_SCHEDULE_ID,HIS_APPLY_NO,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,REQ_DATE_TIME FROM MED_VS_HIS_OPER_APPLY_V2 where MED_PATIENT_ID=:MedPatientId AND MED_VISIT_ID=:MedVisitId AND MED_SCHEDULE_ID=:MedScheduleId";
        private static readonly string MED_VS_HIS_OPER_APPLY_V2_ReqDateTime_Select_Count = "select Count(*) from Med_Vs_His_Oper_Apply_V2 where his_apply_no = :hisApplyNo and his_patient_id = :hisPatientId and his_visit_id = :hisVisitId and his_schedule_id = :hisScheduleId and req_date_time = :reqDateTime";
        private static readonly string MED_VS_HIS_OPER_APPLY_V2_Select_Count = "select Count(*) from Med_Vs_His_Oper_Apply_V2 where his_apply_no = :hisApplyNo and his_patient_id = :hisPatientId and his_visit_id = :hisVisitId and his_schedule_id = :hisScheduleId";
        private static readonly string MED_VS_HIS_OPER_APPLY_V2_His_Select = "select med_patient_id, med_visit_id, med_schedule_id, his_apply_no, his_patient_id, his_visit_id, his_schedule_id, req_date_time from Med_Vs_His_Oper_Apply_V2 where his_apply_no = :hisApplyNo and his_patient_id = :hisPatientId and his_visit_id = :hisVisitId and his_schedule_id = :hisScheduleId ";
        private static readonly string MED_VS_HIS_OPER_APPLY_V2_His_SelectReq = "select med_patient_id, med_visit_id, med_schedule_id, his_apply_no, his_patient_id, his_visit_id, his_schedule_id, req_date_time from Med_Vs_His_Oper_Apply_V2 where his_apply_no = :hisApplyNo and his_patient_id = :hisPatientId and his_visit_id = :hisVisitId and his_schedule_id = :hisScheduleId and req_date_time = :ReqDateTime";
 

        private static readonly string MED_VS_HIS_OPER_APPLY_V2_His_SelectHis_List = "select med_patient_id, med_visit_id, med_schedule_id, his_apply_no, his_patient_id, his_visit_id, his_schedule_id, req_date_time from Med_Vs_His_Oper_Apply_V2 where his_patient_id = :hisPatientId and his_visit_id = :hisVisitId ";

		#region [获取参数SQL]
		/// <summary>
		///获取参数MedVsHisOperApplyV2 SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOperApplyV2")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@MedPatientId",SqlDbType.VarChar),
							new SqlParameter("@MedVisitId",SqlDbType.Decimal),
							new SqlParameter("@MedScheduleId",SqlDbType.Decimal),
							new SqlParameter("@HisApplyNo",SqlDbType.VarChar),
							new SqlParameter("@HisPatientId",SqlDbType.VarChar),
							new SqlParameter("@HisVisitId",SqlDbType.VarChar),
							new SqlParameter("@HisScheduleId",SqlDbType.Decimal),
							new SqlParameter("@ReqDateTime",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedVsHisOperApplyV2")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@MedPatientId",SqlDbType.VarChar),
							new SqlParameter("@MedVisitId",SqlDbType.Decimal),
							new SqlParameter("@MedScheduleId",SqlDbType.Decimal),
							new SqlParameter("@HisApplyNo",SqlDbType.VarChar),
							new SqlParameter("@HisPatientId",SqlDbType.VarChar),
							new SqlParameter("@HisVisitId",SqlDbType.VarChar),
							new SqlParameter("@HisScheduleId",SqlDbType.Decimal),
							new SqlParameter("@ReqDateTime",SqlDbType.VarChar),
							new SqlParameter("@MedPatientIdP",SqlDbType.VarChar),
							new SqlParameter("@MedVisitIdP",SqlDbType.Decimal),
							new SqlParameter("@MedScheduleIdP",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedVsHisOperApplyV2")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@MedPatientId",SqlDbType.VarChar),
							new SqlParameter("@MedVisitId",SqlDbType.Decimal),
							new SqlParameter("@MedScheduleId",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "SelectMedVsHisOperApplyV2")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@MedPatientId",SqlDbType.VarChar),
							new SqlParameter("@MedVisitId",SqlDbType.Decimal),
							new SqlParameter("@MedScheduleId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectCountMedVsHisOperApplyV2ReqDateTime")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@HisApplyNo",SqlDbType.VarChar),
						new SqlParameter("@HisPatientId",SqlDbType.VarChar),
						new SqlParameter("@HisVisitId",SqlDbType.VarChar),
						new SqlParameter("@HisScheduleId",SqlDbType.Decimal),
						new SqlParameter("@ReqDateTime",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectCountMedVsHisOperApplyV2His")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@HisApplyNo",SqlDbType.VarChar),
						new SqlParameter("@HisPatientId",SqlDbType.VarChar),
						new SqlParameter("@HisVisitId",SqlDbType.VarChar),
						new SqlParameter("@HisScheduleId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOperApplyV2His")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@HisApplyNo",SqlDbType.VarChar),
						new SqlParameter("@HisPatientId",SqlDbType.VarChar),
						new SqlParameter("@HisVisitId",SqlDbType.VarChar),
						new SqlParameter("@HisScheduleId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOperApplyV2HisList")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@HisPatientId",SqlDbType.VarChar),
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
		///Add    model  MedVsHisOperApplyV2 
		///Insert Table MED_VS_HIS_OPER_APPLY_V2
		/// </summary>
		public int InsertMedVsHisOperApplyV2SQL(MedVsHisOperApplyV2 model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedVsHisOperApplyV2");
					if (model.MedPatientId != null)
						oneInert[0].Value = model.MedPatientId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.MedVisitId.ToString() != null)
						oneInert[1].Value = model.MedVisitId;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.MedScheduleId.ToString() != null)
						oneInert[2].Value = model.MedScheduleId;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.HisApplyNo != null)
						oneInert[3].Value = model.HisApplyNo;
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
					if (model.HisScheduleId.ToString() != null)
						oneInert[6].Value = model.HisScheduleId;
					else
						oneInert[6].Value = DBNull.Value;
                    if (model.ReqDateTime != null)
						oneInert[7].Value = model.ReqDateTime;
					else
						oneInert[7].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_OPER_APPLY_V2_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedVsHisOperApplyV2 
		///Update Table     MED_VS_HIS_OPER_APPLY_V2
		/// </summary>
		public int UpdateMedVsHisOperApplyV2SQL(MedVsHisOperApplyV2 model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedVsHisOperApplyV2");
				if (model.MedPatientId != null)
					oneUpdate[0].Value = model.MedPatientId;
				else
					oneUpdate[0].Value = DBNull.Value;
				if (model.MedVisitId.ToString() != null)
					oneUpdate[1].Value = model.MedVisitId;
				else
					oneUpdate[1].Value = DBNull.Value;
				if (model.MedScheduleId.ToString() != null)
					oneUpdate[2].Value = model.MedScheduleId;
				else
					oneUpdate[2].Value = DBNull.Value;
				if (model.HisApplyNo != null)
					oneUpdate[3].Value = model.HisApplyNo;
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
				if (model.HisScheduleId.ToString() != null)
					oneUpdate[6].Value = model.HisScheduleId;
				else
					oneUpdate[6].Value = DBNull.Value;
                if (model.ReqDateTime != null)
					oneUpdate[7].Value = model.ReqDateTime;
				else
					oneUpdate[7].Value = DBNull.Value;
				if (model.MedPatientId != null)
					oneUpdate[8].Value =model.MedPatientId;
				else
					oneUpdate[8].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
					oneUpdate[9].Value =model.MedVisitId;
				else
					oneUpdate[9].Value = DBNull.Value;
				if (model.MedScheduleId.ToString() != null)
					oneUpdate[10].Value =model.MedScheduleId;
				else
					oneUpdate[10].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_OPER_APPLY_V2_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedVsHisOperApplyV2 
		///Delete Table MED_VS_HIS_OPER_APPLY_V2 by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_SCHEDULE_ID)
		/// </summary>
		public int DeleteMedVsHisOperApplyV2SQL(string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_SCHEDULE_ID)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedVsHisOperApplyV2");
					if (MED_PATIENT_ID != null)
						oneDelete[0].Value =MED_PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (MED_VISIT_ID.ToString() != null)
						oneDelete[1].Value =MED_VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
                    if (MED_SCHEDULE_ID.ToString() != null)
						oneDelete[2].Value =MED_SCHEDULE_ID;
					else
						oneDelete[2].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_OPER_APPLY_V2_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedVsHisOperApplyV2 
		///select Table MED_VS_HIS_OPER_APPLY_V2 by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_SCHEDULE_ID)
		/// </summary>
		public MedVsHisOperApplyV2  SelectMedVsHisOperApplyV2SQL(string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_SCHEDULE_ID)
		{
			MedVsHisOperApplyV2 model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedVsHisOperApplyV2");
				parameterValues[0].Value=MED_PATIENT_ID;
				parameterValues[1].Value=MED_VISIT_ID;
				parameterValues[2].Value=MED_SCHEDULE_ID;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_APPLY_V2_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedVsHisOperApplyV2();
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
							model.MedScheduleId = decimal.Parse(oleReader["MED_SCHEDULE_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.HisApplyNo = oleReader["HIS_APPLY_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
                            model.HisScheduleId = oleReader["HIS_SCHEDULE_ID"].ToString().Trim(); ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.ReqDateTime = oleReader["REQ_DATE_TIME"].ToString().Trim() ;
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
		public List<MedVsHisOperApplyV2> SelectMedVsHisOperApplyV2ListSQL()
		{
			List<MedVsHisOperApplyV2> modelList = new List<MedVsHisOperApplyV2>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_APPLY_V2_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedVsHisOperApplyV2 model = new MedVsHisOperApplyV2();
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
							model.MedScheduleId = decimal.Parse(oleReader["MED_SCHEDULE_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.HisApplyNo = oleReader["HIS_APPLY_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.HisScheduleId = oleReader["HIS_SCHEDULE_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.ReqDateTime = oleReader["REQ_DATE_TIME"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		/// <summary>
        /// 根据HIS下申请日期REQ_DATE_TIME HIS手术流水号  HIS病人ID号 HIS的住院号 确认是否有记录
		/// </summary>
        /// <param name="hisApplyNo">HIS手术流水号</param>
        /// <param name="hisPatientId">HIS病人ID号</param>
        /// <param name="hisVisitId">HIS的住院号</param>
        /// <param name="hisScheduleId">HIS手术流水号</param>
        /// <param name="reqDateTime">HIS下申请日期REQ_DATE_TIME</param>
		/// <returns></returns>
        public int SelectCountMedVsHisOperApplyV2ReqDateTimeSQL(string hisApplyNo, string hisPatientId, string hisVisitId, decimal hisScheduleId, string reqDateTime)
        {
            SqlParameter[] medVsHisOperApplyParams = GetParameterSQL("SelectCountMedVsHisOperApplyV2ReqDateTime");
            medVsHisOperApplyParams[0].Value = hisApplyNo;
            medVsHisOperApplyParams[1].Value = hisPatientId;
            medVsHisOperApplyParams[2].Value = hisVisitId;
            medVsHisOperApplyParams[3].Value = hisScheduleId;
            medVsHisOperApplyParams[4].Value = reqDateTime;

            object count = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_APPLY_V2_ReqDateTime_Select_Count_SQL, medVsHisOperApplyParams);
            if (count == null)
                count = (object)0;
            return Convert.ToInt32(count);
        }
        /// <summary>
        /// 根据HIS手术流水号  HIS病人ID号 HIS的住院号 确认是否有记录
        /// </summary>
        /// <param name="hisApplyNo">HIS手术流水号</param>
        /// <param name="hisPatientId">HIS病人ID号</param>
        /// <param name="hisVisitId">HIS的住院号</param>
        /// <param name="hisScheduleId">HIS手术流水号</param>
        /// <returns></returns>
        public int SelectCountMedVsHisOperApplyV2HisSQL(string hisApplyNo, string hisPatientId, string hisVisitId, string  hisScheduleId)
        {
            SqlParameter[] medVsHisOperApplyParams = GetParameterSQL("SelectCountMedVsHisOperApplyV2His");
            medVsHisOperApplyParams[0].Value = hisApplyNo;
            medVsHisOperApplyParams[1].Value = hisPatientId;
            medVsHisOperApplyParams[2].Value = hisVisitId;
            medVsHisOperApplyParams[3].Value = hisScheduleId;

            object count = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_APPLY_V2_Select_Count_SQL, medVsHisOperApplyParams);
            if (count == null)
                count = (object)0;
            return Convert.ToInt32(count);
        }


        /// <summary>
        /// 获取Med_Vs_His_Oper_Apply_V2记录(HIS手术流水号  HIS病人ID号 HIS的住院号)
        /// </summary>
        /// <param name="hisApplyNo">HIS手术流水号</param>
        /// <param name="hisPatientId">HIS病人ID号</param>
        /// <param name="hisVisitId">HIS的住院号</param>
        /// <param name="hisScheduleId">HIS手术流水号</param>
        /// <returns></returns>
        public List<MedVsHisOperApplyV2> SelectMedVsHisOperApplyV2HisSQLList(string hisPatientId, string hisVisitId)
        {
            List<MedVsHisOperApplyV2> Result=new List<MedVsHisOperApplyV2>();  
            SqlParameter[] medVsHisOperApplyParams = GetParameterSQL("SelectMedVsHisOperApplyV2HisList");
            medVsHisOperApplyParams[0].Value = hisPatientId;
            medVsHisOperApplyParams[1].Value = hisVisitId;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_APPLY_V2_His_Select_List_SQL, medVsHisOperApplyParams))
            {
                while(oleReader.Read())
                {
                  MedVsHisOperApplyV2  oneMedVsHisOperApply = new MedVsHisOperApplyV2();
                    if (!oleReader.IsDBNull(0))
                        oneMedVsHisOperApply.MedPatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisOperApply.MedVisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisOperApply.MedScheduleId = oleReader.GetDecimal(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisOperApply.HisApplyNo = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisOperApply.HisPatientId = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisOperApply.HisVisitId = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisOperApply.HisScheduleId = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisOperApply.ReqDateTime = oleReader.GetString(7);

                    Result.Add(oneMedVsHisOperApply);
                }
                
                 
            }
            return Result;
        }


        /// <summary>
        /// 获取Med_Vs_His_Oper_Apply_V2记录(HIS手术流水号  HIS病人ID号 HIS的住院号)
        /// </summary>
        /// <param name="hisApplyNo">HIS手术流水号</param>
        /// <param name="hisPatientId">HIS病人ID号</param>
        /// <param name="hisVisitId">HIS的住院号</param>
        /// <param name="hisScheduleId">HIS手术流水号</param>
        /// <returns></returns>
        public MedVsHisOperApplyV2 SelectMedVsHisOperApplyV2HisSQL(string hisApplyNo, string hisPatientId, string hisVisitId, string  hisScheduleId)
        {
            MedVsHisOperApplyV2 oneMedVsHisOperApply = null;
            SqlParameter[] medVsHisOperApplyParams = GetParameterSQL("SelectMedVsHisOperApplyV2His");
            medVsHisOperApplyParams[0].Value = hisApplyNo;
            medVsHisOperApplyParams[1].Value = hisPatientId;
            medVsHisOperApplyParams[2].Value = hisVisitId;
            medVsHisOperApplyParams[3].Value = hisScheduleId;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_APPLY_V2_His_Select_SQL, medVsHisOperApplyParams))
            {
                if (oleReader.Read())
                {
                    oneMedVsHisOperApply = new MedVsHisOperApplyV2();
                    if (!oleReader.IsDBNull(0))
                        oneMedVsHisOperApply.MedPatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisOperApply.MedVisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisOperApply.MedScheduleId = oleReader.GetDecimal(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisOperApply.HisApplyNo = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisOperApply.HisPatientId = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisOperApply.HisVisitId = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisOperApply.HisScheduleId = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisOperApply.ReqDateTime = oleReader.GetString(7);
                }
                else
                    oneMedVsHisOperApply = null;
            }
            return oneMedVsHisOperApply;
        }

		#region [获取参数]
		/// <summary>
		///获取参数MedVsHisOperApplyV2
		/// </summary>
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOperApplyV2")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":MedPatientId",OracleType.VarChar),
						new OracleParameter(":MedVisitId",OracleType.Number),
						new OracleParameter(":MedScheduleId",OracleType.Number),
						new OracleParameter(":HisApplyNo",OracleType.VarChar),
						new OracleParameter(":HisPatientId",OracleType.VarChar),
						new OracleParameter(":HisVisitId",OracleType.VarChar),
						new OracleParameter(":HisScheduleId",OracleType.VarChar),
						new OracleParameter(":ReqDateTime",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedVsHisOperApplyV2")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":MedPatientId",OracleType.VarChar),
						new OracleParameter(":MedVisitId",OracleType.Number),
						new OracleParameter(":MedScheduleId",OracleType.Number),
						new OracleParameter(":HisApplyNo",OracleType.VarChar),
						new OracleParameter(":HisPatientId",OracleType.VarChar),
						new OracleParameter(":HisVisitId",OracleType.VarChar),
						new OracleParameter(":HisScheduleId",OracleType.VarChar),
						new OracleParameter(":ReqDateTime",OracleType.VarChar),
						new OracleParameter(":MedPatientId",SqlDbType.VarChar),
						new OracleParameter(":MedVisitId",SqlDbType.Decimal),
						new OracleParameter(":MedScheduleId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedVsHisOperApplyV2")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":MedPatientId",OracleType.VarChar),
						new OracleParameter(":MedVisitId",OracleType.Number),
						new OracleParameter(":MedScheduleId",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOperApplyV2")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":MedPatientId",OracleType.VarChar),
						    new OracleParameter(":MedVisitId",OracleType.Number),
						    new OracleParameter(":MedScheduleId",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectCountMedVsHisOperApplyV2ReqDateTime")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":HisApplyNo",OracleType.VarChar),
						new OracleParameter(":HisPatientId",OracleType.VarChar),
						new OracleParameter(":HisVisitId",OracleType.VarChar),
						new OracleParameter(":HisScheduleId",OracleType.VarChar),
						new OracleParameter(":ReqDateTime",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectCountMedVsHisOperApplyV2His")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":HisApplyNo",OracleType.VarChar),
						new OracleParameter(":HisPatientId",OracleType.VarChar),
						new OracleParameter(":HisVisitId",OracleType.VarChar),
						new OracleParameter(":HisScheduleId",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOperApplyV2HisReq")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":HisApplyNo",OracleType.VarChar),
						new OracleParameter(":HisPatientId",OracleType.VarChar),
						new OracleParameter(":HisVisitId",OracleType.VarChar),
						new OracleParameter(":HisScheduleId",OracleType.VarChar),
                        new OracleParameter(":ReqDateTime",OracleType.VarChar),
                    };
                }

                else if (sqlParms == "SelectMedVsHisOperApplyV2HisList")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":HisPatientId",OracleType.VarChar),
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
		///Add    model  MedVsHisOperApplyV2 
		///Insert Table MED_VS_HIS_OPER_APPLY_V2
		/// </summary>
		public int InsertMedVsHisOperApplyV2(MedVsHisOperApplyV2 model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedVsHisOperApplyV2");
					if (model.MedPatientId != null)
						oneInert[0].Value = model.MedPatientId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.MedVisitId.ToString() != null)
						oneInert[1].Value = model.MedVisitId;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.MedScheduleId.ToString() != null)
						oneInert[2].Value = model.MedScheduleId;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.HisApplyNo != null)
						oneInert[3].Value = model.HisApplyNo;
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
					if (model.HisScheduleId.ToString() != null)
						oneInert[6].Value = model.HisScheduleId;
					else
						oneInert[6].Value = DBNull.Value;
                    if (model.ReqDateTime != null)
						oneInert[7].Value = model.ReqDateTime;
					else
						oneInert[7].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_OPER_APPLY_V2_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedVsHisOperApplyV2 
		///Update Table     MED_VS_HIS_OPER_APPLY_V2
		/// </summary>
		public int UpdateMedVsHisOperApplyV2(MedVsHisOperApplyV2 model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedVsHisOperApplyV2");
					if (model.MedPatientId != null)
						oneUpdate[0].Value = model.MedPatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.MedVisitId.ToString() != null)
						oneUpdate[1].Value = model.MedVisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.MedScheduleId.ToString() != null)
						oneUpdate[2].Value = model.MedScheduleId;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.HisApplyNo != null)
						oneUpdate[3].Value = model.HisApplyNo;
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
					if (model.HisScheduleId.ToString() != null)
						oneUpdate[6].Value = model.HisScheduleId;
					else
						oneUpdate[6].Value = DBNull.Value;
                    if (model.ReqDateTime != null)
						oneUpdate[7].Value = model.ReqDateTime;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.MedPatientId != null)
						oneUpdate[8].Value =model.MedPatientId;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.MedVisitId.ToString() != null)
						oneUpdate[9].Value =model.MedVisitId;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.MedScheduleId.ToString() != null)
						oneUpdate[10].Value =model.MedScheduleId;
					else
						oneUpdate[10].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_OPER_APPLY_V2_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedVsHisOperApplyV2 
		///Delete Table MED_VS_HIS_OPER_APPLY_V2 by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_SCHEDULE_ID)
		/// </summary>
		public int DeleteMedVsHisOperApplyV2(string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_SCHEDULE_ID)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedVsHisOperApplyV2");
					if (MED_PATIENT_ID != null)
						oneDelete[0].Value =MED_PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (MED_VISIT_ID.ToString() != null)
						oneDelete[1].Value =MED_VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
                    if (MED_SCHEDULE_ID.ToString() != null)
						oneDelete[2].Value =MED_SCHEDULE_ID;
					else
						oneDelete[2].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_OPER_APPLY_V2_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedVsHisOperApplyV2 
		///select Table MED_VS_HIS_OPER_APPLY_V2 by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_SCHEDULE_ID)
		/// </summary>
		public MedVsHisOperApplyV2  SelectMedVsHisOperApplyV2(string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_SCHEDULE_ID)
		{
			MedVsHisOperApplyV2 model;
			OracleParameter[] parameterValues = GetParameter("SelectMedVsHisOperApplyV2");
			parameterValues[0].Value=MED_PATIENT_ID;
			parameterValues[1].Value=MED_VISIT_ID;
			parameterValues[2].Value=MED_SCHEDULE_ID;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_APPLY_V2_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedVsHisOperApplyV2();
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
							model.MedScheduleId = decimal.Parse(oleReader["MED_SCHEDULE_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.HisApplyNo = oleReader["HIS_APPLY_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.HisScheduleId =  oleReader["HIS_SCHEDULE_ID"].ToString().Trim()  ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.ReqDateTime = oleReader["REQ_DATE_TIME"].ToString().Trim() ;
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
		public List<MedVsHisOperApplyV2> SelectMedVsHisOperApplyV2List()
		{
			List<MedVsHisOperApplyV2> modelList = new List<MedVsHisOperApplyV2>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_APPLY_V2_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedVsHisOperApplyV2 model = new MedVsHisOperApplyV2();
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
							model.MedScheduleId = decimal.Parse(oleReader["MED_SCHEDULE_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.HisApplyNo = oleReader["HIS_APPLY_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.HisScheduleId =  oleReader["HIS_SCHEDULE_ID"].ToString().Trim()  ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.ReqDateTime = oleReader["REQ_DATE_TIME"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		/// <summary>
        ///  根据HIS下申请日期REQ_DATE_TIME HIS手术流水号  HIS病人ID号 HIS的住院号 确认是否有记录
		/// </summary>
        /// <param name="hisApplyNo">HIS手术流水号</param>
        /// <param name="hisPatientId">HIS病人ID号</param>
        /// <param name="hisVisitId">HIS的住院号</param>
        /// <param name="hisScheduleId">HIS手术流水号</param>
        /// <param name="reqDateTime">HIS下申请日期REQ_DATE_TIME</param>
		/// <returns></returns>
        public int SelectCountMedVsHisOperApplyV2ReqDateTime(string hisApplyNo, string hisPatientId, string hisVisitId, decimal hisScheduleId, string reqDateTime)
        {
            OracleParameter[] medVsHisOperApplyParams = GetParameter("SelectCountMedVsHisOperApplyV2ReqDateTime");
            medVsHisOperApplyParams[0].Value = hisApplyNo;
            medVsHisOperApplyParams[1].Value = hisPatientId;
            medVsHisOperApplyParams[2].Value = hisVisitId;
            medVsHisOperApplyParams[3].Value = hisScheduleId;
            medVsHisOperApplyParams[4].Value = reqDateTime;

            object count = OracleHelper.ExecuteScalar(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_APPLY_V2_ReqDateTime_Select_Count, medVsHisOperApplyParams);
            if (count == null)
                count = (object)0;
            return Convert.ToInt32(count);
        }
        /// <summary>
        /// 根据HIS手术流水号  HIS病人ID号 HIS的住院号 确认是否有记录
        /// </summary>
        /// <param name="hisApplyNo">HIS手术流水号</param>
        /// <param name="hisPatientId">HIS病人ID号</param>
        /// <param name="hisVisitId">HIS的住院号</param>
        /// <param name="hisScheduleId">HIS手术流水号</param>
        /// <returns></returns>
        public int SelectCountMedVsHisOperApplyV2His(string hisApplyNo, string hisPatientId, string hisVisitId, string  hisScheduleId)
        {
            OracleParameter[] medVsHisOperApplyParams = GetParameter("SelectCountMedVsHisOperApplyV2His");
            medVsHisOperApplyParams[0].Value = hisApplyNo;
            medVsHisOperApplyParams[1].Value = hisPatientId;
            medVsHisOperApplyParams[2].Value = hisVisitId;
            medVsHisOperApplyParams[3].Value = hisScheduleId;

            object count = OracleHelper.ExecuteScalar(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_APPLY_V2_Select_Count, medVsHisOperApplyParams);
            if (count == null)
                count = (object)0;
            return Convert.ToInt32(count);
        }

        /// <summary>
        /// 获取Med_Vs_His_Oper_Apply_V2记录(HIS手术流水号  HIS病人ID号 HIS的住院号)
        /// </summary>
        /// <param name="hisApplyNo">HIS手术流水号</param>
        /// <param name="hisPatientId">HIS病人ID号</param>
        /// <param name="hisVisitId">HIS的住院号</param>
        /// <param name="hisScheduleId">HIS手术流水号</param>
        /// <returns></returns>
        public MedVsHisOperApplyV2 SelectMedVsHisOperApplyV2His(string hisApplyNo, string hisPatientId, string hisVisitId, string  hisScheduleId)
        {
            MedVsHisOperApplyV2 oneMedVsHisOperApply = null;
            OracleParameter[] medVsHisOperApplyParams = GetParameter("SelectMedVsHisOperApplyV2His");
            medVsHisOperApplyParams[0].Value = hisApplyNo;
            medVsHisOperApplyParams[1].Value = hisPatientId;
            medVsHisOperApplyParams[2].Value = hisVisitId;
            medVsHisOperApplyParams[3].Value = hisScheduleId;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_APPLY_V2_His_Select, medVsHisOperApplyParams))
            {
                if (oleReader.Read())
                {
                    oneMedVsHisOperApply = new MedVsHisOperApplyV2();
                    if (!oleReader.IsDBNull(0))
                        oneMedVsHisOperApply.MedPatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisOperApply.MedVisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisOperApply.MedScheduleId = oleReader.GetDecimal(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisOperApply.HisApplyNo = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisOperApply.HisPatientId = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisOperApply.HisVisitId = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisOperApply.HisScheduleId = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisOperApply.ReqDateTime = oleReader.GetString(7);
                }
                else
                    oneMedVsHisOperApply = null;
            }
            return oneMedVsHisOperApply;
        }


        /// <summary>
        /// 获取Med_Vs_His_Oper_Apply_V2记录(HIS手术流水号  HIS病人ID号 HIS的住院号)
        /// </summary>
        /// <param name="hisApplyNo">HIS手术流水号</param>
        /// <param name="hisPatientId">HIS病人ID号</param>
        /// <param name="hisVisitId">HIS的住院号</param>
        /// <param name="hisScheduleId">HIS手术流水号</param>
        /// <returns></returns>
        public List<MedVsHisOperApplyV2> SelectMedVsHisOperApplyV2HisList(string hisPatientId, string hisVisitId)
        {

            List<MedVsHisOperApplyV2> result = new List<MedVsHisOperApplyV2>();  
            OracleParameter[] medVsHisOperApplyParams = GetParameter("SelectMedVsHisOperApplyV2HisList");
          
            medVsHisOperApplyParams[0].Value = hisPatientId;
            medVsHisOperApplyParams[1].Value = hisVisitId;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_APPLY_V2_His_SelectHis_List, medVsHisOperApplyParams))
            {
                while (oleReader.Read())
                {
                    MedVsHisOperApplyV2 oneMedVsHisOperApply = new MedVsHisOperApplyV2();
                    if (!oleReader.IsDBNull(0))
                        oneMedVsHisOperApply.MedPatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisOperApply.MedVisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisOperApply.MedScheduleId = oleReader.GetDecimal(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisOperApply.HisApplyNo = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisOperApply.HisPatientId = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisOperApply.HisVisitId = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisOperApply.HisScheduleId = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisOperApply.ReqDateTime = oleReader.GetString(7);
                    result.Add(oneMedVsHisOperApply);
                }
                 
            }
         
            return result;
        }

        /// <summary>
        /// 获取Med_Vs_His_Oper_Apply_V2记录(HIS手术流水号  HIS病人ID号 HIS的住院号)
        /// </summary>
        /// <param name="hisApplyNo">HIS手术流水号</param>
        /// <param name="hisPatientId">HIS病人ID号</param>
        /// <param name="hisVisitId">HIS的住院号</param>
        /// <param name="hisScheduleId">HIS手术流水号</param>
        /// <returns></returns>
        public MedVsHisOperApplyV2 SelectMedVsHisOperApplyV2HisReq(string hisApplyNo, string hisPatientId, string hisVisitId, string hisScheduleId,string reqdatetime)
        {
            MedVsHisOperApplyV2 oneMedVsHisOperApply = null;
            OracleParameter[] medVsHisOperApplyParams = GetParameter("SelectMedVsHisOperApplyV2HisReq");
            medVsHisOperApplyParams[0].Value = hisApplyNo;
            medVsHisOperApplyParams[1].Value = hisPatientId;
            medVsHisOperApplyParams[2].Value = hisVisitId;
            medVsHisOperApplyParams[3].Value = hisScheduleId;
            medVsHisOperApplyParams[4].Value = reqdatetime;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_APPLY_V2_His_SelectReq, medVsHisOperApplyParams))
            {
                if (oleReader.Read())
                {
                    oneMedVsHisOperApply = new MedVsHisOperApplyV2();
                    if (!oleReader.IsDBNull(0))
                        oneMedVsHisOperApply.MedPatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisOperApply.MedVisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisOperApply.MedScheduleId = oleReader.GetDecimal(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisOperApply.HisApplyNo = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisOperApply.HisPatientId = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisOperApply.HisVisitId = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisOperApply.HisScheduleId = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisOperApply.ReqDateTime = oleReader.GetString(7);
                }
                else
                    oneMedVsHisOperApply = null;
            }
            return oneMedVsHisOperApply;
        }


	}
}
