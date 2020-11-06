

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
    /// DAL DALMedVitalSignsRecTemp
	/// </summary>
	
	public partial class DALMedVitalSignsRecTemp
	{
        private static readonly string MED_VITAL_SIGNS_REC_TEMP_Insert_OLE = "INSERT INTO med_vital_signs_rec_temp (RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,UNITS,OPERATOR,PATIENT_ID,VISIT_ID,DEP_ID) values (?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_VITAL_SIGNS_REC_TEMP_Update_OLE = "UPDATE med_vital_signs_rec_temp SET VITAL_SIGNS_VALUES=?,UNITS =?,OPERATOR=? WHERE PATIENT_ID=? and VISIT_ID=? and DEP_ID = ? and RECORDING_DATE=? and TIME_POINT=? and VITAL_SIGNS=?";

        private static readonly string MED_VITAL_SIGNS_REC_TEMP_Select_OLE = "SELECT RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,UNITS,OPERATOR FROM med_vital_signs_rec_temp where PATIENT_ID=? and VISIT_ID=? and DEP_ID = ?";
        private static readonly string MED_VITAL_SIGNS_REC_TEMP_Select_ALL_OLE = "SELECT RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,UNITS,OPERATOR FROM med_vital_signs_rec_temp where PATIENT_ID=? and VISIT_ID=?";

        private static readonly string MED_VITAL_SIGNS_REC_TEMP_Insert = "INSERT INTO med_vital_signs_rec_temp (RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,UNITS,OPERATOR,PATIENT_ID,VISIT_ID,DEP_ID) values (:recordingDate,:timePoint,:vitalSigns,:vitalSignsValues,:units,:operator,:patientId,:visitId,:depId)";
        private static readonly string MED_VITAL_SIGNS_REC_TEMP_Update = "UPDATE med_vital_signs_rec_temp SET VITAL_SIGNS_VALUES=:vitalSignsValues,UNITS =:units,OPERATOR=:operator WHERE PATIENT_ID=:patientId and VISIT_ID=:visitId and DEP_ID = :depId and RECORDING_DATE=:recordingDate and TIME_POINT=:timePoint and VITAL_SIGNS=:vitalSigns";

        private static readonly string MED_VITAL_SIGNS_REC_TEMP_Select = "SELECT RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,UNITS,OPERATOR FROM med_vital_signs_rec_temp where PATIENT_ID=:patientId and VISIT_ID=:visitId and DEP_ID = :depId";
        private static readonly string MED_VITAL_SIGNS_REC_TEMP_Select_ALL = "SELECT RECORDING_DATE,TIME_POINT,VITAL_SIGNS,VITAL_SIGNS_VALUES,UNITS,OPERATOR FROM med_vital_signs_rec_temp where PATIENT_ID=:patientId and VISIT_ID=:visitId";
        public DALMedVitalSignsRecTemp()
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
                if (sqlParms == "InsertMedVitalSignsRecTemp")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("recordingDate",OleDbType.DBTimeStamp),
							new OleDbParameter("timePoint",OleDbType.DBTimeStamp),
							new OleDbParameter("vitalSigns",OleDbType.VarChar),
							new OleDbParameter("vitalSignsValues",OleDbType.Decimal),
                            new OleDbParameter("units",OleDbType.VarChar),
                            new OleDbParameter("operator",OleDbType.VarChar),
                            new OleDbParameter("patientId",OleDbType.VarChar),
                            new OleDbParameter("visitId",OleDbType.Decimal),
                            new OleDbParameter("depId",OleDbType.Decimal),
                        };
                }
                else if (sqlParms == "UpdateMedVitalSignsRecTemp")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("vitalSignsValues",OleDbType.Decimal),
                            new OleDbParameter("units",OleDbType.VarChar),
                            new OleDbParameter("operator",OleDbType.VarChar),
                            new OleDbParameter("patientId",OleDbType.VarChar),
                            new OleDbParameter("visitId",OleDbType.Decimal),
                            new OleDbParameter("depId",OleDbType.Decimal),
							new OleDbParameter("recordingDate",OleDbType.DBTimeStamp),
							new OleDbParameter("timePoint",OleDbType.DBTimeStamp),
							new OleDbParameter("vitalSigns",OleDbType.VarChar),
                        };
                }
                else if (sqlParms == "SelectMedVitalSignsRecTemp")
                {
                    parms = new OleDbParameter[]{
                            new OleDbParameter("patientId",OleDbType.VarChar),
                            new OleDbParameter("visitId",OleDbType.Decimal),
                            new OleDbParameter("depId",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectALLMedVitalSignsRecTemp")
                {
                    parms = new OleDbParameter[]{
                            new OleDbParameter("patientId",OleDbType.VarChar),
                            new OleDbParameter("visitId",OleDbType.Decimal),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
        #region [添加一条记录OLE]
        /// <summary>
		///Add    model  MedDeptDict 
		///Insert Table MED_DEPT_DICT
		/// </summary>
        public int InsertMedVitalSignsRecTempOLE(MedVitalSignsRecTemp model)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                    OleDbParameter[] oneInert = GetParameterOLE("InsertMedVitalSignsRecTemp");
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

                    return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_VITAL_SIGNS_REC_TEMP_Insert_OLE, oneInert);
			}
		}
		#endregion
        #region [更新一条记录OLE]
        /// <summary>
		///Update    model  MedDeptDict 
		///Update Table     MED_DEPT_DICT
		/// </summary>
        public int UpdateMedVitalSignsRecTempOLE(MedVitalSignsRecTemp model)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedVitalSignsRecTemp");
                
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

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_VITAL_SIGNS_REC_TEMP_Update_OLE, oneUpdate);
			}
		}
		#endregion	
        #region  [获取一条记录OLE]
        /// <summary>
		///Select    model  MedDeptDict 
		///select Table MED_DEPT_DICT by (string DEPT_CODE)
		/// </summary>
        public MedVitalSignsRecTemp SelectMedVitalSignsRecTempOLE(string patientId, decimal visitId, decimal depId)
		{
            MedVitalSignsRecTemp model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedVitalSignsRecTemp");
            parameterValues[0].Value = patientId;
            parameterValues[1].Value = visitId;
            parameterValues[2].Value = depId;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VITAL_SIGNS_REC_TEMP_Select_OLE, parameterValues))
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
        #region  [获取所有记录OLE]
        /// <summary>
        ///Select    model  MedDeptDict 
        ///select Table MED_DEPT_DICT by (string DEPT_CODE)
        /// </summary>
        public List<MedVitalSignsRecTemp> SelectMedVitalSignsRecTempALLOLE(string patientId, decimal visitId)
        {
            List<MedVitalSignsRecTemp> modelList = new List<MedVitalSignsRecTemp>();
            
            OleDbParameter[] parameterValues = GetParameterOLE("SelectALLMedVitalSignsRecTemp");
            parameterValues[0].Value = patientId;
            parameterValues[1].Value = visitId;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VITAL_SIGNS_REC_TEMP_Select_ALL_OLE, parameterValues))
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
		#region [获取参数]
		/// <summary>
		///获取参数MedDeptDict
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVitalSignsRecTemp")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":recordingDate",OracleType.DateTime),
							new OracleParameter(":timePoint",OracleType.DateTime),
							new OracleParameter(":vitalSigns",OracleType.VarChar),
							new OracleParameter(":vitalSignsValues",OracleType.Number),
                            new OracleParameter(":units",OracleType.VarChar),
                            new OracleParameter(":operator",OracleType.VarChar),
                            new OracleParameter(":patientId",OracleType.VarChar),
                            new OracleParameter(":visitId",OracleType.Number),
                            new OracleParameter(":depId",OracleType.Number),
                        };
                }
                else if (sqlParms == "UpdateMedVitalSignsRecTemp")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":vitalSignsValues",OracleType.Number),
                            new OracleParameter(":units",OracleType.VarChar),
                            new OracleParameter(":operator",OracleType.VarChar),
                            new OracleParameter(":patientId",OracleType.VarChar),
                            new OracleParameter(":visitId",OracleType.Number),
                            new OracleParameter(":depId",OracleType.Number),
							new OracleParameter(":recordingDate",OracleType.DateTime),
							new OracleParameter(":timePoint",OracleType.DateTime),
							new OracleParameter(":vitalSigns",OracleType.VarChar),
                        };
                }

                else if (sqlParms == "SelectMedVitalSignsRecTemp")
                {
                    parms = new OracleParameter[]{
                            new OracleParameter(":patientId",OracleType.VarChar),
                            new OracleParameter(":visitId",OracleType.Number),
                            new OracleParameter(":depId",OracleType.Number),
                        };
                }
                else if (sqlParms == "SelectALLMedVitalSignsRecTemp")
                {
                    parms = new OracleParameter[]{
                            new OracleParameter(":patientId",OracleType.VarChar),
                            new OracleParameter(":visitId",OracleType.Number),
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
        public int InsertMedVitalSignsRecTemp(MedVitalSignsRecTemp model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedVitalSignsRecTemp");
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

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VITAL_SIGNS_REC_TEMP_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedDeptDict 
		///Update Table     MED_DEPT_DICT
		/// </summary>
        public int UpdateMedVitalSignsRecTemp(MedVitalSignsRecTemp model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedVitalSignsRecTemp");
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

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VITAL_SIGNS_REC_TEMP_Update, oneUpdate);
			}
		}
		#endregion	
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedDeptDict 
		///select Table MED_DEPT_DICT by (string DEPT_CODE)
		/// </summary>
        public MedVitalSignsRecTemp SelectMedVitalSignsRecTemp(string patientId, decimal visitId, decimal depId)
		{
            MedVitalSignsRecTemp model;
            OracleParameter[] parameterValues = GetParameter("SelectMedVitalSignsRecTemp");
            parameterValues[0].Value = patientId;
            parameterValues[1].Value = visitId;
            parameterValues[2].Value = depId;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VITAL_SIGNS_REC_TEMP_Select, parameterValues))
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
        #region  [获取所有记录]
        /// <summary>
        ///Select    model  MedDeptDict 
        ///select Table MED_DEPT_DICT by (string DEPT_CODE)
        /// </summary>
        public List<MedVitalSignsRecTemp> SelectMedVitalSignsRecTempALL(string patientId, decimal visitId)
        {
            List<MedVitalSignsRecTemp> modelList = new List<MedVitalSignsRecTemp>();
            OracleParameter[] parameterValues = GetParameter("SelectALLMedVitalSignsRecTemp");
            parameterValues[0].Value = patientId;
            parameterValues[1].Value = visitId;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VITAL_SIGNS_REC_TEMP_Select_ALL, parameterValues))
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
