

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
    /// DAL DALMedVitalSignsRecTemp
	/// </summary>
	
	public partial class DALMedVitalSignsRecTemp
	{
        private static readonly string MED_VITAL_SIGNS_REC_TEMP_Insert_ODBC = "INSERT INTO med_vital_signs_rec_temp (RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,UNITS,OPERATOR,PATIENT_ID,VISIT_ID,DEP_ID) values (?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_VITAL_SIGNS_REC_TEMP_Update_ODBC = "UPDATE med_vital_signs_rec_temp SET VITAL_SIGNS_VALUES=?,UNITS =?,OPERATOR=? WHERE PATIENT_ID=? and VISIT_ID=? and DEP_ID = ? and RECORDING_DATE=? and TIME_POINT=? and VITAL_SIGNS=?";

        private static readonly string MED_VITAL_SIGNS_REC_TEMP_Select_ODBC = "SELECT RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,UNITS,OPERATOR FROM med_vital_signs_rec_temp where PATIENT_ID=? and VISIT_ID=? and DEP_ID = ?";
        private static readonly string MED_VITAL_SIGNS_REC_TEMP_Select_ALL_ODBC = "SELECT RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,UNITS,OPERATOR FROM med_vital_signs_rec_temp where PATIENT_ID=? and VISIT_ID=?";

        private static readonly string MED_VITAL_SIGNS_REC_TEMP_Insert_SQL = "INSERT INTO med_vital_signs_rec_temp (RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,UNITS,OPERATOR,PATIENT_ID,VISIT_ID,DEP_ID) values (:recordingDate,:timePoint,:vitalSigns,:vitalSignsValues,:units,:operator,:patientId,:visitId,:depId)";
        private static readonly string MED_VITAL_SIGNS_REC_TEMP_Update_SQL = "UPDATE med_vital_signs_rec_temp SET VITAL_SIGNS_VALUES=:vitalSignsValues,UNITS =:units,OPERATOR=:operator WHERE PATIENT_ID=:patientId and VISIT_ID=:visitId and DEP_ID = :depId and RECORDING_DATE=:recordingDate and TIME_POINT=:timePoint and VITAL_SIGNS=:vitalSigns";

        private static readonly string MED_VITAL_SIGNS_REC_TEMP_Select_SQL = "SELECT RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,UNITS,OPERATOR FROM med_vital_signs_rec_temp where PATIENT_ID=:patientId and VISIT_ID=:visitId and DEP_ID = :depId";
        private static readonly string MED_VITAL_SIGNS_REC_TEMP_Select_ALL_SQL = "SELECT RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,UNITS,OPERATOR FROM med_vital_signs_rec_temp where PATIENT_ID=:patientId and VISIT_ID=:visitId";


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
                if (sqlParms == "InsertMedVitalSignsRecTemp")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("recordingDate",OdbcType.DateTime),
							new OdbcParameter("timePoint",OdbcType.DateTime),
							new OdbcParameter("vitalSigns",OdbcType.VarChar),
							new OdbcParameter("vitalSignsValues",OdbcType.Decimal),
                            new OdbcParameter("units",OdbcType.VarChar),
                            new OdbcParameter("operator",OdbcType.VarChar),
                            new OdbcParameter("patientId",OdbcType.VarChar),
                            new OdbcParameter("visitId",OdbcType.Decimal),
                            new OdbcParameter("depId",OdbcType.Decimal),
                        };
                }
                else if (sqlParms == "UpdateMedVitalSignsRecTemp")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("vitalSignsValues",OdbcType.Decimal),
                            new OdbcParameter("units",OdbcType.VarChar),
                            new OdbcParameter("operator",OdbcType.VarChar),
                            new OdbcParameter("patientId",OdbcType.VarChar),
                            new OdbcParameter("visitId",OdbcType.Decimal),
                            new OdbcParameter("depId",OdbcType.Decimal),
							new OdbcParameter("recordingDate",OdbcType.DateTime),
							new OdbcParameter("timePoint",OdbcType.DateTime),
							new OdbcParameter("vitalSigns",OdbcType.VarChar),
                        };
                }
                else if (sqlParms == "SelectMedVitalSignsRecTemp")
                {
                    parms = new OdbcParameter[]{
                            new OdbcParameter("patientId",OdbcType.VarChar),
                            new OdbcParameter("visitId",OdbcType.Decimal),
                            new OdbcParameter("depId",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "SelectALLMedVitalSignsRecTemp")
                {
                    parms = new OdbcParameter[]{
                            new OdbcParameter("patientId",OdbcType.VarChar),
                            new OdbcParameter("visitId",OdbcType.Decimal),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
        #region [添加一条记录ODBC]
        /// <summary>
		///Add    model  MedDeptDict 
		///Insert Table MED_DEPT_DICT
		/// </summary>
        public int InsertMedVitalSignsRecTempODBC(MedVitalSignsRecTemp model)
		{
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                    OdbcParameter[] oneInert = GetParameterODBC("InsertMedVitalSignsRecTemp");
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
                    if (model.Units != null)
                        oneInert[4].Value = model.Units;
                    else
                        oneInert[4].Value = DBNull.Value;

                    if (model.Operator != null)
                        oneInert[5].Value = model.Operator;
                    else
                        oneInert[5].Value = DBNull.Value;
                    if (model.PatientId != null)
						oneInert[6].Value = model.PatientId;
					else
						oneInert[6].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneInert[7].Value = model.VisitId;
					else
						oneInert[7].Value = DBNull.Value;
                    if (model.DepId.ToString() != null)
						oneInert[8].Value = model.DepId;
					else
						oneInert[8].Value = DBNull.Value;

                    return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_VITAL_SIGNS_REC_TEMP_Insert_ODBC, oneInert);
			}
		}
		#endregion
        #region [更新一条记录ODBC]
        /// <summary>
		///Update    model  MedDeptDict 
		///Update Table     MED_DEPT_DICT
		/// </summary>
        public int UpdateMedVitalSignsRecTempODBC(MedVitalSignsRecTemp model)
		{
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterODBC("UpdateMedVitalSignsRecTemp");
                
                if (model.VitalSignsValues.ToString() != null)
                    oneUpdate[0].Value = model.VitalSignsValues;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.Units != null)
                    oneUpdate[1].Value = model.Units;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.Operator != null)
                    oneUpdate[2].Value = model.Operator;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[3].Value = model.PatientId;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneUpdate[4].Value = model.VisitId;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.DepId.ToString() != null)
                    oneUpdate[5].Value = model.DepId;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.RecordingDate.ToString() != null)
                    oneUpdate[6].Value = model.RecordingDate;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.TimePoint.ToString() != null)
                    oneUpdate[7].Value = model.TimePoint;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.VitalSigns != null)
                    oneUpdate[8].Value = model.VitalSigns;
                else
                    oneUpdate[8].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_VITAL_SIGNS_REC_TEMP_Update_ODBC, oneUpdate);
			}
		}
		#endregion	
        #region  [获取一条记录Odbc]
        /// <summary>
		///Select    model  MedDeptDict 
		///select Table MED_DEPT_DICT by (string DEPT_CODE)
		/// </summary>
        public MedVitalSignsRecTemp SelectMedVitalSignsRecTempODBC(string patientId, decimal visitId, decimal depId)
		{
            MedVitalSignsRecTemp model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedVitalSignsRecTemp");
            parameterValues[0].Value = patientId;
            parameterValues[1].Value = visitId;
            parameterValues[2].Value = depId;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VITAL_SIGNS_REC_TEMP_Select_ODBC, parameterValues))
			{
				if (oleReader.Read())
				{
                    //RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES
                        model = new MedVitalSignsRecTemp();
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
                            model.Units = oleReader["UNITS"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(5))
                        {
                            model.Operator = oleReader["OPERATOR"].ToString().Trim();
                        }
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
        #region  [获取所有记录ODBC]
        /// <summary>
        ///Select    model  MedDeptDict 
        ///select Table MED_DEPT_DICT by (string DEPT_CODE)
        /// </summary>
        public List<MedVitalSignsRecTemp> SelectMedVitalSignsRecTempALLODBC(string patientId, decimal visitId)
        {
            List<MedVitalSignsRecTemp> modelList = new List<MedVitalSignsRecTemp>();
            
            OdbcParameter[] parameterValues = GetParameterODBC("SelectALLMedVitalSignsRecTemp");
            parameterValues[0].Value = patientId;
            parameterValues[1].Value = visitId;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VITAL_SIGNS_REC_TEMP_Select_ALL_ODBC, parameterValues))
            {
                while (oleReader.Read())
                {
                    //RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES
                    MedVitalSignsRecTemp model = new MedVitalSignsRecTemp();
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
                        model.Units = oleReader["UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion	
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedDeptDict
		/// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVitalSignsRecTemp")
                {
                    parms = new SqlParameter[]{
							new SqlParameter(":recordingDate",SqlDbType.DateTime),
							new SqlParameter(":timePoint",SqlDbType.DateTime),
							new SqlParameter(":vitalSigns",SqlDbType.VarChar),
							new SqlParameter(":vitalSignsValues",SqlDbType.Decimal),
                            new SqlParameter(":units",SqlDbType.VarChar),
                            new SqlParameter(":operator",SqlDbType.VarChar),
                            new SqlParameter(":patientId",SqlDbType.VarChar),
                            new SqlParameter(":visitId",SqlDbType.Decimal),
                            new SqlParameter(":depId",SqlDbType.Decimal),
                        };
                }
                else if (sqlParms == "UpdateMedVitalSignsRecTemp")
                {
                    parms = new SqlParameter[]{
							new SqlParameter(":vitalSignsValues",SqlDbType.Decimal),
                            new SqlParameter(":units",SqlDbType.VarChar),
                            new SqlParameter(":operator",SqlDbType.VarChar),
                            new SqlParameter(":patientId",SqlDbType.VarChar),
                            new SqlParameter(":visitId",SqlDbType.Decimal),
                            new SqlParameter(":depId",SqlDbType.Decimal),
							new SqlParameter(":recordingDate",SqlDbType.DateTime),
							new SqlParameter(":timePoint",SqlDbType.DateTime),
							new SqlParameter(":vitalSigns",SqlDbType.VarChar),
                        };
                }

                else if (sqlParms == "SelectMedVitalSignsRecTemp")
                {
                    parms = new SqlParameter[]{
                            new SqlParameter(":patientId",SqlDbType.VarChar),
                            new SqlParameter(":visitId",SqlDbType.Decimal),
                            new SqlParameter(":depId",SqlDbType.Decimal),
                        };
                }
                else if (sqlParms == "SelectALLMedVitalSignsRecTemp")
                {
                    parms = new SqlParameter[]{
                            new SqlParameter(":patientId",SqlDbType.VarChar),
                            new SqlParameter(":visitId",SqlDbType.Decimal),
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
        public int InsertMedVitalSignsRecTempSQL(MedVitalSignsRecTemp model)
		{
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedVitalSignsRecTemp");
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
                if (model.Units != null)
                    oneInert[4].Value = model.Units;
                else
                    oneInert[4].Value = DBNull.Value;

                if (model.Operator != null)
                    oneInert[5].Value = model.Operator;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneInert[6].Value = model.PatientId;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneInert[7].Value = model.VisitId;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.DepId.ToString() != null)
                    oneInert[8].Value = model.DepId;
                else
                    oneInert[8].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VITAL_SIGNS_REC_TEMP_Insert_SQL, oneInert);
			}
		}
		#endregion
        #region [更新一条记录SQL]
        /// <summary>
		///Update    model  MedDeptDict 
		///Update Table     MED_DEPT_DICT
		/// </summary>
        public int UpdateMedVitalSignsRecTempSQL(MedVitalSignsRecTemp model)
		{
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedVitalSignsRecTemp");
                if (model.VitalSignsValues.ToString() != null)
                    oneUpdate[0].Value = model.VitalSignsValues;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.Units != null)
                    oneUpdate[1].Value = model.Units;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.Operator != null)
                    oneUpdate[2].Value = model.Operator;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[3].Value = model.PatientId;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneUpdate[4].Value = model.VisitId;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.DepId.ToString() != null)
                    oneUpdate[5].Value = model.DepId;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.RecordingDate.ToString() != null)
                    oneUpdate[6].Value = model.RecordingDate;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.TimePoint.ToString() != null)
                    oneUpdate[7].Value = model.TimePoint;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.VitalSigns != null)
                    oneUpdate[8].Value = model.VitalSigns;
                else
                    oneUpdate[8].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VITAL_SIGNS_REC_TEMP_Update_SQL, oneUpdate);
			}
		}
		#endregion	
        #region  [获取一条记录SQL]
        /// <summary>
		///Select    model  MedDeptDict 
		///select Table MED_DEPT_DICT by (string DEPT_CODE)
		/// </summary>
        public MedVitalSignsRecTemp SelectMedVitalSignsRecTempSQL(string patientId, decimal visitId, decimal depId)
		{
            MedVitalSignsRecTemp model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedVitalSignsRecTemp");
            parameterValues[0].Value = patientId;
            parameterValues[1].Value = visitId;
            parameterValues[2].Value = depId;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VITAL_SIGNS_REC_TEMP_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
                    model = new MedVitalSignsRecTemp();
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
                        model.Units = oleReader["UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
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
        ///Select    model  MedDeptDict 
        ///select Table MED_DEPT_DICT by (string DEPT_CODE)
        /// </summary>
        public List<MedVitalSignsRecTemp> SelectMedVitalSignsRecTempALLSQL(string patientId, decimal visitId)
        {
            List<MedVitalSignsRecTemp> modelList = new List<MedVitalSignsRecTemp>();
            SqlParameter[] parameterValues = GetParameterSQL("SelectALLMedVitalSignsRecTemp");
            parameterValues[0].Value = patientId;
            parameterValues[1].Value = visitId;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VITAL_SIGNS_REC_TEMP_Select_ALL_SQL, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedVitalSignsRecTemp model = new MedVitalSignsRecTemp();
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
                        model.Units = oleReader["UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion	
	}
}
