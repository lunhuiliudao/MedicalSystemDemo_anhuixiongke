

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:09
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
using System.Data.Odbc;
using MedicalSytem.Soft.Model;

namespace MedicalSytem.Soft.DAL
{
	/// <summary>
    /// DAL MedInOrOutRec
	/// </summary>
	
	public partial class DALMedInOrOutRec
	{
        private static readonly string MED_IN_OR_OUT_REC_Insert_ODBC = "INSERT INTO med_in_or_out_rec (RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,ORDER_NO,ORDER_SUB_NO,IN_OR_OUT,PATIENT_ID,VISIT_ID,DEP_ID) values (?,?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_IN_OR_OUT_REC_Update_ODBC = "UPDATE med_in_or_out_rec SET VITAL_SIGNS_VALUES=?,IN_OR_OUT =? WHERE PATIENT_ID=? and VISIT_ID=? and DEP_ID = ? and RECORDING_DATE=? and TIME_POINT=? and VITAL_SIGNS=? and ORDER_NO=? and ORDER_SUB_NO=?";

        private static readonly string MED_IN_OR_OUT_REC_Select_ODBC = "SELECT RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,ORDER_NO,ORDER_SUB_NO,IN_OR_OUT FROM med_in_or_out_rec where PATIENT_ID=? and VISIT_ID=? and DEP_ID = ?";

        private static readonly string MED_IN_OR_OUT_REC_Insert_SQL = "INSERT INTO med_in_or_out_rec (RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,ORDER_NO,ORDER_SUB_NO,IN_OR_OUT,PATIENT_ID,VISIT_ID,DEP_ID) values (@recordingDate,@timePoint,@vitalSigns,@vitalSignsValues,@orderNo,@orderSubNo,@inOrOut,@patientId,@visitId,@depId)";
        private static readonly string MED_IN_OR_OUT_REC_Update_SQL = "UPDATE med_in_or_out_rec SET VITAL_SIGNS_VALUES=@vitalSignsValues,IN_OR_OUT =@inOrOut WHERE PATIENT_ID=@patientId and VISIT_ID=@visitId and DEP_ID = @depId and RECORDING_DATE=@recordingDate and TIME_POINT=@timePoint and VITAL_SIGNS=@vitalSigns and ORDER_NO=@orderNo and ORDER_SUB_NO=@orderSubNo";

        private static readonly string MED_IN_OR_OUT_REC_Select_SQL = "SELECT RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,ORDER_NO,ORDER_SUB_NO,IN_OR_OUT FROM med_in_or_out_rec where PATIENT_ID=@patientId and VISIT_ID=@visitId and DEP_ID = @depId";

		#region [获取参数ODBC]
		/// <summary>
		///获取参数MedDeptDict SQL
		/// </summary>
		public static OdbcParameter[] GetParameterODBC(string sqlParms)
		{
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                //RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,PATIENT_ID,VISIT_ID,DEP_ID
                if (sqlParms == "InsertMedInOrOutRec")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("recordingDate",OdbcType.DateTime),
							new OdbcParameter("timePoint",OdbcType.DateTime),
							new OdbcParameter("vitalSigns",OdbcType.VarChar),
							new OdbcParameter("vitalSignsValues",OdbcType.Decimal),
                            new OdbcParameter("orderNo",OdbcType.VarChar),
							new OdbcParameter("orderSubNo",OdbcType.Decimal),
                            new OdbcParameter("inOrOut",OdbcType.Decimal),
                            new OdbcParameter("patientId",OdbcType.VarChar),
                            new OdbcParameter("visitId",OdbcType.Decimal),
                            new OdbcParameter("depId",OdbcType.Decimal),
                        };
                }
                else if (sqlParms == "UpdateMedInOrOutRec")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("vitalSignsValues",OdbcType.Decimal),
                            new OdbcParameter("inOrOut",OdbcType.Decimal),
                            new OdbcParameter("patientId",OdbcType.VarChar),
                            new OdbcParameter("visitId",OdbcType.Decimal),
                            new OdbcParameter("depId",OdbcType.Decimal),
							new OdbcParameter("recordingDate",OdbcType.DateTime),
							new OdbcParameter("timePoint",OdbcType.DateTime),
							new OdbcParameter("vitalSigns",OdbcType.VarChar),
                            new OdbcParameter("orderNo",OdbcType.VarChar),
							new OdbcParameter("orderSubNo",OdbcType.Decimal),
                        };
                }
                else if (sqlParms == "SelectMedInOrOutRec")
                {
                    parms = new OdbcParameter[]{
                            new OdbcParameter("patientId",OdbcType.VarChar),
                            new OdbcParameter("visitId",OdbcType.Decimal),
                            new OdbcParameter("depId",OdbcType.Decimal),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
        #region [添加一条记录ODBC]
        /// <summary>
        ///Add    model  MedInOrOutRec 
        ///Insert Table MedInOrOutRec
		/// </summary>
        public int InsertMedInOrOutRecODBC(MedInOrOutRec model)
		{
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterODBC("InsertMedInOrOutRec");
                    if (model.RecordingDate.ToString() != null)
                        oneInert[0].Value = model.RecordingDate;
					else
						oneInert[0].Value = DBNull.Value;
                    if (model.TimePoint.ToString() != null)
						oneInert[1].Value = model.TimePoint;
					else
						oneInert[1].Value = DBNull.Value;
                    if (model.VitalSigns != null)
                        oneInert[2].Value = model.VitalSigns;
                    else
                        oneInert[2].Value = DBNull.Value;
                    if (model.VitalSignsValues.ToString() != null)
                        oneInert[3].Value = model.VitalSignsValues;
                    else
                        oneInert[3].Value = DBNull.Value;

                    if (model.OrderNo != null)
                        oneInert[4].Value = model.OrderNo;
                    else
                        oneInert[4].Value = DBNull.Value;
                    if (model.OrderSubNo.ToString() != null)
                        oneInert[5].Value = model.OrderSubNo;
                    else
                        oneInert[5].Value = DBNull.Value;
                    if (model.InOrOut.ToString() != null)
                        oneInert[6].Value = model.InOrOut;
                    else
                        oneInert[6].Value = DBNull.Value;
                    if (model.PatientId != null)
						oneInert[7].Value = model.PatientId;
					else
						oneInert[7].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneInert[8].Value = model.VisitId;
					else
						oneInert[8].Value = DBNull.Value;
                    if (model.DepId.ToString() != null)
						oneInert[9].Value = model.DepId;
					else
						oneInert[9].Value = DBNull.Value;

                    return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_IN_OR_OUT_REC_Insert_ODBC, oneInert);
			}
		}
		#endregion
        #region [更新一条记录ODBC]
        /// <summary>
		///Update    model  MedDeptDict 
		///Update Table     MED_DEPT_DICT
		/// </summary>
        public int UpdateMedInOrOutRecODBC(MedInOrOutRec model)
		{
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterODBC("UpdateMedInOrOutRec");
                if (model.VitalSignsValues.ToString() != null)
                    oneUpdate[0].Value = model.VitalSignsValues;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.InOrOut.ToString() != null)
                    oneUpdate[1].Value = model.InOrOut;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[2].Value = model.PatientId;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneUpdate[3].Value = model.VisitId;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.DepId.ToString() != null)
                    oneUpdate[4].Value = model.DepId;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.RecordingDate.ToString() != null)
                    oneUpdate[5].Value = model.RecordingDate;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.TimePoint.ToString() != null)
                    oneUpdate[6].Value = model.TimePoint;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.VitalSigns != null)
                    oneUpdate[7].Value = model.VitalSigns;
                else
                    oneUpdate[7].Value = DBNull.Value;

                if (model.OrderNo != null)
                    oneUpdate[8].Value = model.OrderNo;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.OrderSubNo.ToString() != null)
                    oneUpdate[9].Value = model.OrderSubNo;
                else
                    oneUpdate[9].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_IN_OR_OUT_REC_Update_ODBC, oneUpdate);
			}
		}
		#endregion	
        #region  [获取一条记录ODBC]
        /// <summary>
		///Select    model  MedDeptDict 
		///select Table MED_DEPT_DICT by (string DEPT_CODE)
		/// </summary>
        public MedInOrOutRec SelectMedInOrOutRecODBC(string patientId, decimal visitId, decimal depId)
		{
            MedInOrOutRec model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedInOrOutRec");
            parameterValues[0].Value = patientId;
            parameterValues[1].Value = visitId;
            parameterValues[2].Value = depId;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_IN_OR_OUT_REC_Select_ODBC, parameterValues))
			{
				if (oleReader.Read())
				{
                    //RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES
                    model = new MedInOrOutRec();
						if (!oleReader.IsDBNull(0))
						{
                            model.RecordingDate = DateTime.Parse(oleReader["RECORDING_DATE"].ToString().Trim());
						}
						if (!oleReader.IsDBNull(1))
						{
                            model.TimePoint = DateTime.Parse(oleReader["TIME_POINT"].ToString().Trim());
						}
						if (!oleReader.IsDBNull(2))
						{
                            model.VitalSigns = oleReader["VITAL_SIGNS"].ToString().Trim();
						}
                        if (!oleReader.IsDBNull(3))
                        {
                            model.VitalSignsValues = decimal.Parse(oleReader["VITAL_SIGNS_VALUES"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(4))
                        {
                            model.OrderNo = oleReader["ORDER_NO"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(5))
                        {
                            model.OrderSubNo = decimal.Parse(oleReader["ORDER_SUB_NO"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(6))
                        {
                            model.InOrOut = decimal.Parse(oleReader["IN_OR_OUT"].ToString().Trim());
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
		///获取参数MedDeptDict
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedInOrOutRec")
                {
                    parms = new SqlParameter[]{
							new SqlParameter(":recordingDate",SqlDbType.DateTime),
							new SqlParameter(":timePoint",SqlDbType.DateTime),
							new SqlParameter(":vitalSigns",SqlDbType.VarChar),
							new SqlParameter(":vitalSignsValues",SqlDbType.Decimal),
                            new SqlParameter(":orderNo",SqlDbType.VarChar),
							new SqlParameter(":orderSubNo",SqlDbType.Decimal),
                            new SqlParameter(":inOrOut",SqlDbType.Decimal),
                            new SqlParameter(":patientId",SqlDbType.VarChar),
                            new SqlParameter(":visitId",SqlDbType.Decimal),
                            new SqlParameter(":depId",SqlDbType.Decimal),
                        };
                }
                else if (sqlParms == "UpdateMedInOrOutRec")
                {
                    parms = new SqlParameter[]{
							new SqlParameter(":vitalSignsValues",SqlDbType.Decimal),
                            new SqlParameter(":inOrOut",SqlDbType.Decimal),
                            new SqlParameter(":patientId",SqlDbType.VarChar),
                            new SqlParameter(":visitId",SqlDbType.Decimal),
                            new SqlParameter(":depId",SqlDbType.Decimal),
							new SqlParameter(":recordingDate",SqlDbType.DateTime),
							new SqlParameter(":timePoint",SqlDbType.DateTime),
							new SqlParameter(":vitalSigns",SqlDbType.VarChar),
                            new SqlParameter(":orderNo",SqlDbType.VarChar),
							new SqlParameter(":orderSubNo",SqlDbType.Decimal),
                        };
                }

                else if (sqlParms == "SelectMedInOrOutRec")
                {
                    parms = new SqlParameter[]{
                            new SqlParameter(":patientId",SqlDbType.VarChar),
                            new SqlParameter(":visitId",SqlDbType.Decimal),
                            new SqlParameter(":depId",SqlDbType.Decimal),
                        };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedDeptDict 
		///Insert Table MED_DEPT_DICT
		/// </summary>
        public int InsertMedInOrOutRecSQL(MedInOrOutRec model)
		{
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedInOrOutRec");
                if (model.RecordingDate.ToString() != null)
                    oneInert[0].Value = model.RecordingDate;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.TimePoint.ToString() != null)
                    oneInert[1].Value = model.TimePoint;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.VitalSigns != null)
                    oneInert[2].Value = model.VitalSigns;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.VitalSignsValues.ToString() != null)
                    oneInert[3].Value = model.VitalSignsValues;
                else
                    oneInert[3].Value = DBNull.Value;

                if (model.OrderNo != null)
                    oneInert[4].Value = model.OrderNo;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.OrderSubNo.ToString() != null)
                    oneInert[5].Value = model.OrderSubNo;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.InOrOut.ToString() != null)
                    oneInert[6].Value = model.InOrOut;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneInert[7].Value = model.PatientId;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneInert[8].Value = model.VisitId;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.DepId.ToString() != null)
                    oneInert[9].Value = model.DepId;
                else
                    oneInert[9].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_IN_OR_OUT_REC_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedDeptDict 
		///Update Table     MED_DEPT_DICT
		/// </summary>
        public int UpdateMedInOrOutRecSQL(MedInOrOutRec model)
		{
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedInOrOutRec");
                if (model.VitalSignsValues.ToString() != null)
                    oneUpdate[0].Value = model.VitalSignsValues;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.InOrOut.ToString() != null)
                    oneUpdate[1].Value = model.InOrOut;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[2].Value = model.PatientId;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneUpdate[3].Value = model.VisitId;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.DepId.ToString() != null)
                    oneUpdate[4].Value = model.DepId;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.RecordingDate.ToString() != null)
                    oneUpdate[5].Value = model.RecordingDate;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.TimePoint.ToString() != null)
                    oneUpdate[6].Value = model.TimePoint;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.VitalSigns != null)
                    oneUpdate[7].Value = model.VitalSigns;
                else
                    oneUpdate[7].Value = DBNull.Value;

                if (model.OrderNo != null)
                    oneUpdate[8].Value = model.OrderNo;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.OrderSubNo.ToString() != null)
                    oneUpdate[9].Value = model.OrderSubNo;
                else
                    oneUpdate[9].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_IN_OR_OUT_REC_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedDeptDict 
		///select Table MED_DEPT_DICT by (string DEPT_CODE)
		/// </summary>
        public MedInOrOutRec SelectMedInOrOutRecSQL(string patientId, decimal visitId, decimal depId)
		{
            MedInOrOutRec model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedInOrOutRec");
            parameterValues[0].Value = patientId;
            parameterValues[1].Value = visitId;
            parameterValues[2].Value = depId;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_IN_OR_OUT_REC_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
                    model = new MedInOrOutRec();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.RecordingDate = DateTime.Parse(oleReader["RECORDING_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.TimePoint = DateTime.Parse(oleReader["TIME_POINT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.VitalSigns = oleReader["VITAL_SIGNS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.VitalSignsValues = decimal.Parse(oleReader["VITAL_SIGNS_VALUES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.OrderNo = oleReader["ORDER_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OrderSubNo = decimal.Parse(oleReader["ORDER_SUB_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.InOrOut = decimal.Parse(oleReader["IN_OR_OUT"].ToString().Trim());
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
