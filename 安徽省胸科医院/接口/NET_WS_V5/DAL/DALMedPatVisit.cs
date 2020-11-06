

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:27
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
    /// DAL MedPatVisit
    /// </summary>

    public partial class DALMedPatVisit
    {

        private static readonly string MED_PAT_VISIT_Insert_SQL = "Insert into MED_PAT_VISIT  (PATIENT_ID,VISIT_ID,INP_NO,HOSP_BRANCH,PATIENT_SOURCE,RESERVED02,DEPT_ADMISSION_TO,RESERVED01,ADMISSION_DATE_TIME,CONSULTING_DATE,PAT_ADM_CONDITION,DOCTOR_IN_CHARGE) values(@PatientId,@VisitId,@InpNo,@HospBranch,@PatientSource,@WardCode,@DEPT_ADMISSION_TO,@BedNo,@AdmissionDateTime,@AdmWardDateTime,@PAT_ADM_CONDITION,@DoctorInCharge)";
        private static readonly string MED_PAT_VISIT_Update_SQL = "Update MED_PAT_VISIT set INP_NO=@InpNo,HOSP_BRANCH=@HospBranch,PATIENT_SOURCE=@PatientSource,RESERVED02=@WardCode,DEPT_ADMISSION_TO=@DEPT_ADMISSION_TO,RESERVED01=@BedNo,ADMISSION_DATE_TIME=@AdmissionDateTime,CONSULTING_DATE=@AdmWardDateTime,PAT_ADM_CONDITION=@PAT_ADM_CONDITION,DOCTOR_IN_CHARGE=@DoctorInCharge where PATIENT_ID=@PatientId,VISIT_ID=@VisitId";
        private static readonly string MED_PAT_VISIT_Delete_SQL = "Delete MED_PAT_VISIT WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId";
        private static readonly string MED_PAT_VISIT_Select_SQL = "select PATIENT_ID,VISIT_ID,INP_NO,HOSP_BRANCH,PATIENT_SOURCE,RESERVED02,DEPT_ADMISSION_TO,RESERVED01,ADMISSION_DATE_TIME,CONSULTING_DATE,PAT_ADM_CONDITION,DOCTOR_IN_CHARGE from MED_PAT_VISIT WHERE PATIENT_ID=@PatientId,VISIT_ID=@VisitId";
        private static readonly string MED_PAT_VISIT_Select_ALL_SQL = "select PATIENT_ID,VISIT_ID,INP_NO,HOSP_BRANCH,PATIENT_SOURCE,RESERVED02,DEPT_ADMISSION_TO,RESERVED01,ADMISSION_DATE_TIME,CONSULTING_DATE,PAT_ADM_CONDITION,DOCTOR_IN_CHARGE from MED_PAT_VISIT";
        private static readonly string MED_PAT_VISIT_Insert = "Insert into MED_PAT_VISIT  (PATIENT_ID,VISIT_ID,INP_NO,HOSP_BRANCH,PATIENT_SOURCE,RESERVED02,DEPT_ADMISSION_TO,RESERVED01,ADMISSION_DATE_TIME,CONSULTING_DATE,PAT_ADM_CONDITION,DOCTOR_IN_CHARGE) values(:PatientId,:VisitId,:InpNo,:HospBranch,:PatientSource,:WardCode,:DEPT_ADMISSION_TO,:BedNo,:AdmissionDateTime,:AdmWardDateTime,:PAT_ADM_CONDITION,:DoctorInCharge)";
        private static readonly string MED_PAT_VISIT_Update = "Update MED_PAT_VISIT set INP_NO=:InpNo,HOSP_BRANCH=:HospBranch,PATIENT_SOURCE=:PatientSource,RESERVED02=:WardCode,DEPT_ADMISSION_TO=:DEPT_ADMISSION_TO,RESERVED01=:BedNo,ADMISSION_DATE_TIME=:AdmissionDateTime,CONSULTING_DATE=:AdmWardDateTime,PAT_ADM_CONDITION=:PAT_ADM_CONDITION,DOCTOR_IN_CHARGE=:DoctorInCharge where PATIENT_ID=:PatientId AND  VISIT_ID=:VisitId";
        private static readonly string MED_PAT_VISIT_Delete = "Delete MED_PAT_VISIT WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId";
        private static readonly string MED_PAT_VISIT_Select = "select PATIENT_ID,VISIT_ID,INP_NO,HOSP_BRANCH,PATIENT_SOURCE,RESERVED02,DEPT_ADMISSION_TO,RESERVED01,ADMISSION_DATE_TIME,CONSULTING_DATE,PAT_ADM_CONDITION,DOCTOR_IN_CHARGE from MED_PAT_VISIT WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId ";
        private static readonly string MED_PAT_VISIT_Select_ALL = "select PATIENT_ID,VISIT_ID,INP_NO,HOSP_BRANCH,PATIENT_SOURCE,RESERVED02,DEPT_ADMISSION_TO,RESERVED01,ADMISSION_DATE_TIME,CONSULTING_DATE,PAT_ADM_CONDITION,DOCTOR_IN_CHARGE from MED_PAT_VISIT";

        public DALMedPatVisit()
        {
        }
        #region [获取参数SQL]
        /// <summary>
        ///获取参数MedPatVisit SQL
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedPatVisit")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
                            new SqlParameter("@VisitId",SqlDbType.Decimal),
                            new SqlParameter("@InpNo",SqlDbType.VarChar),
                            new SqlParameter("@HospBranch",SqlDbType.VarChar),
                            new SqlParameter("@PatientSource",SqlDbType.Decimal),
                            new SqlParameter("@WardCode",SqlDbType.VarChar),
                            new SqlParameter("@DEPT_ADMISSION_TO",SqlDbType.VarChar),
                            new SqlParameter("@BedNo",SqlDbType.VarChar),
                            new SqlParameter("@AdmissionDateTime",SqlDbType.DateTime),
                            new SqlParameter("@AdmWardDateTime",SqlDbType.DateTime),
                            new SqlParameter("@PAT_ADM_CONDITION",SqlDbType.VarChar),
                            new SqlParameter("@DoctorInCharge",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedPatVisit")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@InpNo",SqlDbType.VarChar),
                            new SqlParameter("@HospBranch",SqlDbType.VarChar),
                            new SqlParameter("@PatientSource",SqlDbType.Decimal),
                            new SqlParameter("@WardCode",SqlDbType.VarChar),
                            new SqlParameter("@DEPT_ADMISSION_TO",SqlDbType.VarChar),
                            new SqlParameter("@BedNo",SqlDbType.VarChar),
                            new SqlParameter("@AdmissionDateTime",SqlDbType.DateTime),
                            new SqlParameter("@AdmWardDateTime",SqlDbType.DateTime),
                            new SqlParameter("@PAT_ADM_CONDITION",SqlDbType.VarChar),
                            new SqlParameter("@DoctorInCharge",SqlDbType.VarChar),
                            new SqlParameter("@PatientId",SqlDbType.VarChar),
                            new SqlParameter("@VisitId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedPatVisit")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedPatVisit")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedPatVisit 
        ///Insert Table MED_PAT_VISIT
        /// </summary>
        public int InsertMedPatVisitSQL(MedPatVisit model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedPatVisit");
                if (model.PatientId != null)
                    oneInert[0].Value = model.PatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneInert[1].Value = model.VisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.InpNo != null)
                    oneInert[2].Value = model.InpNo;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.HospBranch != null)
                    oneInert[3].Value = model.HospBranch;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.PatientSource != null)
                    oneInert[4].Value = model.PatientSource;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneInert[5].Value = model.Reserved01;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.DEPT_ADMISSION_TO != null)
                    oneInert[6].Value = model.DEPT_ADMISSION_TO;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneInert[7].Value = model.Reserved02;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.AdmissionDateTime != null)
                    oneInert[8].Value = model.AdmissionDateTime;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Reserved05 != null)
                    oneInert[9].Value = model.Reserved05;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.Reserved04 != null)
                    oneInert[10].Value = model.Reserved04;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.DoctorInCharge != null)
                    oneInert[11].Value = model.DoctorInCharge;
                else
                    oneInert[11].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_PAT_VISIT_Insert_SQL, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedPatVisit 
        ///Update Table     MED_PAT_VISIT
        /// </summary>
        public int UpdateMedPatVisitSQL(MedPatVisit model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedPatVisit");
                if (model.InpNo != null)
                    oneUpdate[0].Value = model.InpNo;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.HospBranch != null)
                    oneUpdate[1].Value = model.HospBranch;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.PatientSource != null)
                    oneUpdate[2].Value = model.PatientSource;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneUpdate[3].Value = model.Reserved01;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.DEPT_ADMISSION_TO != null)
                    oneUpdate[4].Value = model.DEPT_ADMISSION_TO;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneUpdate[5].Value = model.Reserved02;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.AdmissionDateTime != null)
                    oneUpdate[6].Value = model.AdmissionDateTime;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.Reserved05 != null)
                    oneUpdate[7].Value = model.Reserved05;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.Reserved04 != null)
                    oneUpdate[8].Value = model.Reserved04;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.DoctorInCharge != null)
                    oneUpdate[9].Value = model.DoctorInCharge;
                else
                    oneUpdate[9].Value = string.Empty;
                if (model.PatientId != null)
                    oneUpdate[10].Value = model.PatientId;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneUpdate[11].Value = model.VisitId;
                else
                    oneUpdate[11].Value = DBNull.Value;
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_PAT_VISIT_Update_SQL, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedPatVisit 
        ///Delete Table MED_PAT_VISIT by (string PATIENT_ID,decimal VISIT_ID)
        /// </summary>
        public int DeleteMedPatVisitSQL(string PATIENT_ID, decimal VISIT_ID)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneDelete = GetParameterSQL("DeleteMedPatVisit");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (VISIT_ID.ToString() != null)
                    oneDelete[1].Value = VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_PAT_VISIT_Delete_SQL, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedPatVisit 
        ///select Table MED_PAT_VISIT by (string PATIENT_ID,decimal VISIT_ID)
        /// </summary>
        public MedPatVisit SelectMedPatVisitSQL(string PATIENT_ID, decimal VISIT_ID)
        {
            MedPatVisit model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedPatVisit");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_PAT_VISIT_Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPatVisit();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.PatientId = oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.InpNo = oleReader["INP_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.PatientSource = decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.Reserved01 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DEPT_ADMISSION_TO = oleReader["DEPT_ADMISSION_TO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Reserved02 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved05 = oleReader["CONSULTING_DATE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved04 = oleReader["PAT_ADM_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim();
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
        public List<MedPatVisit> SelectMedPatVisitListSQL()
        {
            List<MedPatVisit> modelList = new List<MedPatVisit>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_PAT_VISIT_Select_ALL_SQL, null))
            {
                while (oleReader.Read())
                {
                    MedPatVisit model = new MedPatVisit();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.PatientId = oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.DEPT_ADMISSION_TO = oleReader["DEPT_ADMISSION_TO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DeptDischargeFrom = oleReader["DEPT_DISCHARGE_FROM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DischargeDateTime = DateTime.Parse(oleReader["DISCHARGE_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Occupation = oleReader["OCCUPATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.MaritalStatus = oleReader["MARITAL_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Identity = oleReader["IDENTITY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.ArmedServices = oleReader["ARMED_SERVICES"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Duty = oleReader["DUTY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.TopUnit = oleReader["TOP_UNIT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.ServiceSystemIndicator = decimal.Parse(oleReader["SERVICE_SYSTEM_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.UnitInContract = oleReader["UNIT_IN_CONTRACT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.ChargeType = oleReader["CHARGE_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.WorkingStatus = decimal.Parse(oleReader["WORKING_STATUS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.InsuranceType = oleReader["INSURANCE_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.InsuranceNo = oleReader["INSURANCE_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.ServiceAgency = oleReader["SERVICE_AGENCY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.MailingAddress = oleReader["MAILING_ADDRESS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.ZipCode = oleReader["ZIP_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.NextOfKin = oleReader["NEXT_OF_KIN"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Relationship = oleReader["RELATIONSHIP"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.NextOfKinAddr = oleReader["NEXT_OF_KIN_ADDR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.NextOfKinZipcode = oleReader["NEXT_OF_KIN_ZIPCODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.NextOfKinPhone = oleReader["NEXT_OF_KIN_PHONE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.PatientSource = decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.AdmissionCause = oleReader["ADMISSION_CAUSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.ConsultingDate = DateTime.Parse(oleReader["CONSULTING_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.PatAdmCondition = oleReader["PAT_ADM_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.ConsultingDoctor = oleReader["CONSULTING_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.AdmittedBy = oleReader["ADMITTED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.EmerTreatTimes = decimal.Parse(oleReader["EMER_TREAT_TIMES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.EscEmerTimes = decimal.Parse(oleReader["ESC_EMER_TIMES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.SeriousCondDays = decimal.Parse(oleReader["SERIOUS_COND_DAYS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.CriticalCondDays = decimal.Parse(oleReader["CRITICAL_COND_DAYS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.IcuDays = decimal.Parse(oleReader["ICU_DAYS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.CcuDays = decimal.Parse(oleReader["CCU_DAYS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.SpecLevelNursDays = decimal.Parse(oleReader["SPEC_LEVEL_NURS_DAYS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.FirstLevelNursDays = decimal.Parse(oleReader["FIRST_LEVEL_NURS_DAYS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.SecondLevelNursDays = decimal.Parse(oleReader["SECOND_LEVEL_NURS_DAYS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.AutopsyIndicator = decimal.Parse(oleReader["AUTOPSY_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(42))
                    {
                        model.BloodType = oleReader["BLOOD_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(43))
                    {
                        model.BloodTypeRh = oleReader["BLOOD_TYPE_RH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(44))
                    {
                        model.InfusionReactTimes = decimal.Parse(oleReader["INFUSION_REACT_TIMES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(45))
                    {
                        model.BloodTranTimes = decimal.Parse(oleReader["BLOOD_TRAN_TIMES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(46))
                    {
                        model.BloodTranVol = decimal.Parse(oleReader["BLOOD_TRAN_VOL"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(47))
                    {
                        model.BloodTranReactTimes = decimal.Parse(oleReader["BLOOD_TRAN_REACT_TIMES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(48))
                    {
                        model.DecubitalUlcerTimes = decimal.Parse(oleReader["DECUBITAL_ULCER_TIMES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(49))
                    {
                        model.AlergyDrugs = oleReader["ALERGY_DRUGS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(50))
                    {
                        model.AdverseReactionDrugs = oleReader["ADVERSE_REACTION_DRUGS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(51))
                    {
                        model.MrValue = oleReader["MR_VALUE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(52))
                    {
                        model.MrQuality = oleReader["MR_QUALITY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(53))
                    {
                        model.FollowIndicator = decimal.Parse(oleReader["FOLLOW_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(54))
                    {
                        model.FollowInterval = decimal.Parse(oleReader["FOLLOW_INTERVAL"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(55))
                    {
                        model.FollowIntervalUnits = oleReader["FOLLOW_INTERVAL_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(56))
                    {
                        model.Director = oleReader["DIRECTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(57))
                    {
                        model.AttendingDoctor = oleReader["ATTENDING_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(58))
                    {
                        model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(59))
                    {
                        model.DischargeDisposition = oleReader["DISCHARGE_DISPOSITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(60))
                    {
                        model.TotalCosts = decimal.Parse(oleReader["TOTAL_COSTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(61))
                    {
                        model.TotalPayments = decimal.Parse(oleReader["TOTAL_PAYMENTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(62))
                    {
                        model.CatalogDate = DateTime.Parse(oleReader["CATALOG_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(63))
                    {
                        model.Cataloger = oleReader["CATALOGER"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(64))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(65))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(66))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(67))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(68))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(69))
                    {
                        model.Reserved06 = oleReader["RESERVED06"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(70))
                    {
                        model.Reserved07 = oleReader["RESERVED07"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(71))
                    {
                        model.Reserved08 = oleReader["RESERVED08"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(72))
                    {
                        model.Reserved09 = oleReader["RESERVED09"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(73))
                    {
                        model.Reserved10 = oleReader["RESERVED10"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(74))
                    {
                        model.ReservedDate01 = DateTime.Parse(oleReader["RESERVED_DATE01"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(75))
                    {
                        model.ReservedDate02 = DateTime.Parse(oleReader["RESERVED_DATE02"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(76))
                    {
                        model.BodyHeight = decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(77))
                    {
                        model.BodyWeight = decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(78))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(79))
                    {
                        model.Abnormal = oleReader["ABNORMAL"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region [获取参数]
        /// <summary>
        ///获取参数MedPatVisit
        /// </summary>
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedPatVisit")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
                            new OracleParameter(":VisitId",OracleType.Number),
                            new OracleParameter(":InpNo",OracleType.VarChar),
                            new OracleParameter(":HospBranch",OracleType.VarChar),
                            new OracleParameter(":PatientSource",OracleType.Number),
                            new OracleParameter(":WardCode",OracleType.VarChar),
                            new OracleParameter(":DEPT_ADMISSION_TO",OracleType.VarChar),
                            new OracleParameter(":BedNo",OracleType.VarChar),
                            new OracleParameter(":AdmissionDateTime",OracleType.DateTime),
                            new OracleParameter(":AdmWardDateTime",OracleType.VarChar),
                            new OracleParameter(":PAT_ADM_CONDITION",OracleType.VarChar),
                            new OracleParameter(":DoctorInCharge",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedPatVisit")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":InpNo",OracleType.VarChar),
                            new OracleParameter(":HospBranch",OracleType.VarChar),
                            new OracleParameter(":PatientSource",OracleType.Number),
                            new OracleParameter(":WardCode",OracleType.VarChar),
                            new OracleParameter(":DEPT_ADMISSION_TO",OracleType.VarChar),
                            new OracleParameter(":BedNo",OracleType.VarChar),
                            new OracleParameter(":AdmissionDateTime",OracleType.DateTime),
                            new OracleParameter(":AdmWardDateTime",OracleType.VarChar),
                            new OracleParameter(":PAT_ADM_CONDITION",OracleType.VarChar),
                            new OracleParameter(":DoctorInCharge",OracleType.VarChar),
                            new OracleParameter(":PatientId",OracleType.VarChar),
                            new OracleParameter(":VisitId",OracleType.Number),
                    };
                }
                else if (sqlParms == "DeleteMedPatVisit")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectMedPatVisit")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedPatVisit 
        ///Insert Table MED_PAT_VISIT
        /// </summary>
        public int InsertMedPatVisit(MedPatVisit model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedPatVisit");
                if (model.PatientId != null)
                    oneInert[0].Value = model.PatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneInert[1].Value = model.VisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.InpNo != null)
                    oneInert[2].Value = model.InpNo;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.HospBranch != null)
                    oneInert[3].Value = model.HospBranch;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.PatientSource != null)
                    oneInert[4].Value = model.PatientSource;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneInert[5].Value = model.Reserved01;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.DEPT_ADMISSION_TO != null)
                    oneInert[6].Value = model.DEPT_ADMISSION_TO;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneInert[7].Value = model.Reserved02;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.AdmissionDateTime != null)
                    oneInert[8].Value = model.AdmissionDateTime;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Reserved05 != null)
                    oneInert[9].Value = model.Reserved05;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.Reserved04 != null)
                    oneInert[10].Value = model.Reserved04;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.DoctorInCharge != null)
                    oneInert[11].Value = model.DoctorInCharge;
                else
                    oneInert[11].Value = DBNull.Value;


                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_PAT_VISIT_Insert, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedPatVisit 
        ///Update Table     MED_PAT_VISIT
        /// </summary>
        public int UpdateMedPatVisit(MedPatVisit model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedPatVisit");
                if (model.InpNo != null)
                    oneUpdate[0].Value = model.InpNo;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.HospBranch != null)
                    oneUpdate[1].Value = model.HospBranch;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.PatientSource != null)
                    oneUpdate[2].Value = model.PatientSource;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneUpdate[3].Value = model.Reserved01;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.DEPT_ADMISSION_TO != null)
                    oneUpdate[4].Value = model.DEPT_ADMISSION_TO;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneUpdate[5].Value = model.Reserved02;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.AdmissionDateTime != null)
                    oneUpdate[6].Value = model.AdmissionDateTime;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.Reserved05 != null)
                    oneUpdate[7].Value = model.Reserved05;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.Reserved04 != null)
                    oneUpdate[8].Value = model.Reserved04;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.DoctorInCharge != null)
                    oneUpdate[9].Value = model.DoctorInCharge;
                else
                    oneUpdate[9].Value = string.Empty;

                if (model.PatientId != null)
                    oneUpdate[10].Value = model.PatientId;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneUpdate[11].Value = model.VisitId;
                else
                    oneUpdate[11].Value = DBNull.Value;
                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_PAT_VISIT_Update, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedPatVisit 
        ///Delete Table MED_PAT_VISIT by (string PATIENT_ID,decimal VISIT_ID)
        /// </summary>
        public int DeleteMedPatVisit(string PATIENT_ID, decimal VISIT_ID)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneDelete = GetParameter("DeleteMedPatVisit");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (VISIT_ID.ToString() != null)
                    oneDelete[1].Value = VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_PAT_VISIT_Delete, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedPatVisit 
        ///select Table MED_PAT_VISIT by (string PATIENT_ID,decimal VISIT_ID)
        /// </summary>
        public MedPatVisit SelectMedPatVisit(string PATIENT_ID, decimal VISIT_ID)
        {
            MedPatVisit model;
            OracleParameter[] parameterValues = GetParameter("SelectMedPatVisit");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_PAT_VISIT_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPatVisit();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.PatientId = oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.InpNo = oleReader["INP_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.PatientSource = decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.Reserved01 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DEPT_ADMISSION_TO = oleReader["DEPT_ADMISSION_TO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Reserved02 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved05 = oleReader["CONSULTING_DATE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved04 = oleReader["PAT_ADM_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim();
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
        public List<MedPatVisit> SelectMedPatVisitList()
        {
            List<MedPatVisit> modelList = new List<MedPatVisit>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_PAT_VISIT_Select_ALL, null))
            {
                while (oleReader.Read())
                {
                    MedPatVisit model = new MedPatVisit();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.PatientId = oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.InpNo = oleReader["INP_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.PatientSource = decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.Reserved01 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DEPT_ADMISSION_TO = oleReader["DEPT_ADMISSION_TO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Reserved02 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved05 = oleReader["CONSULTING_DATE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved04 = oleReader["PAT_ADM_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

    }
}
