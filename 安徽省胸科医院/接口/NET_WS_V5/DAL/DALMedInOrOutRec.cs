

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
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.OracleClient;
using MedicalSytem.Soft.Model;

namespace MedicalSytem.Soft.DAL
{
	/// <summary>
    /// DAL MedInOrOutRec
	/// </summary>
	
	public partial class DALMedInOrOutRec
	{
        private static readonly string MED_IN_OR_OUT_REC_Insert_OLE = "INSERT INTO med_in_or_out_rec (RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,ORDER_NO,ORDER_SUB_NO,IN_OR_OUT,PATIENT_ID,VISIT_ID,DEP_ID) values (?,?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_IN_OR_OUT_REC_Update_OLE = "UPDATE med_in_or_out_rec SET VITAL_SIGNS_VALUES=?,IN_OR_OUT =? WHERE PATIENT_ID=? and VISIT_ID=? and DEP_ID = ? and RECORDING_DATE=? and TIME_POINT=? and VITAL_SIGNS=? and ORDER_NO=? and ORDER_SUB_NO=?";

        private static readonly string MED_IN_OR_OUT_REC_Select_OLE = "SELECT RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,ORDER_NO,ORDER_SUB_NO,IN_OR_OUT FROM med_in_or_out_rec where PATIENT_ID=? and VISIT_ID=? and DEP_ID = ?";

        private static readonly string MED_IN_OR_OUT_REC_Insert = "INSERT INTO med_in_or_out_rec (RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,ORDER_NO,ORDER_SUB_NO,IN_OR_OUT,PATIENT_ID,VISIT_ID,DEP_ID) values (:recordingDate,:timePoint,:vitalSigns,:vitalSignsValues,:orderNo,:orderSubNo,:inOrOut,:patientId,:visitId,:depId)";
        private static readonly string MED_IN_OR_OUT_REC_Update = "UPDATE med_in_or_out_rec SET VITAL_SIGNS_VALUES=:vitalSignsValues,IN_OR_OUT =:inOrOut WHERE PATIENT_ID=:patientId and VISIT_ID=:visitId and DEP_ID = :depId and RECORDING_DATE=:recordingDate and TIME_POINT=:timePoint and VITAL_SIGNS=:vitalSigns and ORDER_NO=:orderNo and ORDER_SUB_NO=:orderSubNo";

        private static readonly string MED_IN_OR_OUT_REC_Select = "SELECT RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,ORDER_NO,ORDER_SUB_NO,IN_OR_OUT FROM med_in_or_out_rec where PATIENT_ID=:patientId and VISIT_ID=:visitId and DEP_ID = :depId";
        public DALMedInOrOutRec()
		{
		}

		#region [获取参数OLE]
		/// <summary>
		///获取参数MedDeptDict SQL
		/// </summary>
		public static OleDbParameter[] GetParameterOLE(string sqlParms)
		{
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                //RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,PATIENT_ID,VISIT_ID,DEP_ID
                if (sqlParms == "InsertMedInOrOutRec")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("recordingDate",OleDbType.DBTimeStamp),
							new OleDbParameter("timePoint",OleDbType.DBTimeStamp),
							new OleDbParameter("vitalSigns",OleDbType.VarChar),
							new OleDbParameter("vitalSignsValues",OleDbType.Decimal),
                            new OleDbParameter("orderNo",OleDbType.VarChar),
							new OleDbParameter("orderSubNo",OleDbType.Decimal),
                            new OleDbParameter("inOrOut",OleDbType.Decimal),
                            new OleDbParameter("patientId",OleDbType.VarChar),
                            new OleDbParameter("visitId",OleDbType.Decimal),
                            new OleDbParameter("depId",OleDbType.Decimal),
                        };
                }
                else if (sqlParms == "UpdateMedInOrOutRec")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("vitalSignsValues",OleDbType.Decimal),
                            new OleDbParameter("inOrOut",OleDbType.Decimal),
                            new OleDbParameter("patientId",OleDbType.VarChar),
                            new OleDbParameter("visitId",OleDbType.Decimal),
                            new OleDbParameter("depId",OleDbType.Decimal),
							new OleDbParameter("recordingDate",OleDbType.DBTimeStamp),
							new OleDbParameter("timePoint",OleDbType.DBTimeStamp),
							new OleDbParameter("vitalSigns",OleDbType.VarChar),
                            new OleDbParameter("orderNo",OleDbType.VarChar),
							new OleDbParameter("orderSubNo",OleDbType.Decimal),
                        };
                }
                else if (sqlParms == "SelectMedInOrOutRec")
                {
                    parms = new OleDbParameter[]{
                            new OleDbParameter("patientId",OleDbType.VarChar),
                            new OleDbParameter("visitId",OleDbType.Decimal),
                            new OleDbParameter("depId",OleDbType.Decimal),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
        #region [添加一条记录OLE]
        /// <summary>
        ///Add    model  MedInOrOutRec 
        ///Insert Table MedInOrOutRec
		/// </summary>
        public int InsertMedInOrOutRecOLE(MedInOrOutRec model)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedInOrOutRec");
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

                    return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_IN_OR_OUT_REC_Insert_OLE, oneInert);
			}
		}
		#endregion
        #region [更新一条记录OLE]
        /// <summary>
		///Update    model  MedDeptDict 
		///Update Table     MED_DEPT_DICT
		/// </summary>
        public int UpdateMedInOrOutRecOLE(MedInOrOutRec model)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedInOrOutRec");
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

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_IN_OR_OUT_REC_Update_OLE, oneUpdate);
			}
		}
		#endregion	
        #region  [获取一条记录OLE]
        /// <summary>
		///Select    model  MedDeptDict 
		///select Table MED_DEPT_DICT by (string DEPT_CODE)
		/// </summary>
        public MedInOrOutRec SelectMedInOrOutRecOLE(string patientId, decimal visitId, decimal depId)
		{
            MedInOrOutRec model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedInOrOutRec");
            parameterValues[0].Value = patientId;
            parameterValues[1].Value = visitId;
            parameterValues[2].Value = depId;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_IN_OR_OUT_REC_Select_OLE, parameterValues))
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
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedInOrOutRec")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":recordingDate",OracleType.DateTime),
							new OracleParameter(":timePoint",OracleType.DateTime),
							new OracleParameter(":vitalSigns",OracleType.VarChar),
							new OracleParameter(":vitalSignsValues",OracleType.Number),
                            new OracleParameter(":orderNo",OracleType.VarChar),
							new OracleParameter(":orderSubNo",OracleType.Number),
                            new OracleParameter(":inOrOut",OracleType.Number),
                            new OracleParameter(":patientId",OracleType.VarChar),
                            new OracleParameter(":visitId",OracleType.Number),
                            new OracleParameter(":depId",OracleType.Number),
                        };
                }
                else if (sqlParms == "UpdateMedInOrOutRec")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":vitalSignsValues",OracleType.Number),
                            new OracleParameter(":inOrOut",OracleType.Number),
                            new OracleParameter(":patientId",OracleType.VarChar),
                            new OracleParameter(":visitId",OracleType.Number),
                            new OracleParameter(":depId",OracleType.Number),
							new OracleParameter(":recordingDate",OracleType.DateTime),
							new OracleParameter(":timePoint",OracleType.DateTime),
							new OracleParameter(":vitalSigns",OracleType.VarChar),
                            new OracleParameter(":orderNo",OracleType.VarChar),
							new OracleParameter(":orderSubNo",OracleType.Number),
                        };
                }

                else if (sqlParms == "SelectMedInOrOutRec")
                {
                    parms = new OracleParameter[]{
                            new OracleParameter(":patientId",OracleType.VarChar),
                            new OracleParameter(":visitId",OracleType.Number),
                            new OracleParameter(":depId",OracleType.Number),
                        };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedDeptDict 
		///Insert Table MED_DEPT_DICT
		/// </summary>
        public int InsertMedInOrOutRec(MedInOrOutRec model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedInOrOutRec");
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

                    return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_IN_OR_OUT_REC_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedDeptDict 
		///Update Table     MED_DEPT_DICT
		/// </summary>
        public int UpdateMedInOrOutRec(MedInOrOutRec model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedInOrOutRec");
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

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_IN_OR_OUT_REC_Update, oneUpdate);
			}
		}
		#endregion	
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedDeptDict 
		///select Table MED_DEPT_DICT by (string DEPT_CODE)
		/// </summary>
        public MedInOrOutRec SelectMedInOrOutRec(string patientId, decimal visitId, decimal depId)
		{
            MedInOrOutRec model;
            OracleParameter[] parameterValues = GetParameter("SelectMedInOrOutRec");
            parameterValues[0].Value = patientId;
            parameterValues[1].Value = visitId;
            parameterValues[2].Value = depId;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_IN_OR_OUT_REC_Select, parameterValues))
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
