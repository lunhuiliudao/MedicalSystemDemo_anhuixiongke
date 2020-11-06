

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:32
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
    /// DAL MedPatsInHospital
    /// </summary>

    public partial class DALMedPatsInHospital
    {


        private static string Select = "select PATIENT_ID,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02 from MED_PATS_IN_HOSPITAL WHERE PATIENT_ID=:PatientId and VISIT_ID=:VisitId";
        private static string Update = "Update MED_PATS_IN_HOSPITAL set INP_NO=:InpNo,PATIENT_SOURCE=:PatientSource,HOSP_BRANCH=:HospBranch,DEP_ID=:DepId,WARD_CODE=:WardCode,DEPT_CODE=:DeptCode,BED_NO=:BedNo,ADMISSION_DATE_TIME=:AdmissionDateTime,ADM_WARD_DATE_TIME=:AdmWardDateTime,DIAGNOSIS=:Diagnosis,PATIENT_CONDITION=:PatientCondition,BLOOD_TYPE=:BloodType,BLOOD_TYPE_RH=:BloodTypeRh,BODY_HEIGHT=:BodyHeight,BODY_WEIGHT=:BodyWeight,NURSING_CLASS=:NursingClass,DOCTOR_IN_CHARGE=:DoctorInCharge,NURSE_IN_CHARGE=:NurseInCharge,OPERATING_DATE=:OperatingDate,BILLING_DATE_TIME=:BillingDateTime,PREPAYMENTS=:Prepayments,TOTAL_COSTS=:TotalCosts,TOTAL_CHARGES=:TotalCharges,GUARANTOR=:Guarantor,GUARANTOR_ORG=:GuarantorOrg,GUARANTOR_PHONE_NUM=:GuarantorPhoneNum,BILL_CHECKED_DATE_TIME=:BillCheckedDateTime,SETTLED_INDICATOR=:SettledIndicator,RESERVED01=:Reserved01,RESERVED02=:Reserved02,RESERVED03=:Reserved03,RESERVED_DATE01=:ReservedDate01,RESERVED_DATE02=:ReservedDate02 where PATIENT_ID=:PatientId and VISIT_ID=:VisitId";
        private static string Insert = "Insert into MED_PATS_IN_HOSPITAL  (PATIENT_ID,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02) values(:PatientId,:InpNo,:VisitId,:PatientSource,:HospBranch,:DepId,:WardCode,:DeptCode,:BedNo,:AdmissionDateTime,:AdmWardDateTime,:Diagnosis,:PatientCondition,:BloodType,:BloodTypeRh,:BodyHeight,:BodyWeight,:NursingClass,:DoctorInCharge,:NurseInCharge,:OperatingDate,:BillingDateTime,:Prepayments,:TotalCosts,:TotalCharges,:Guarantor,:GuarantorOrg,:GuarantorPhoneNum,:BillCheckedDateTime,:SettledIndicator,:Reserved01,:Reserved02,:Reserved03,:ReservedDate01,:ReservedDate02)";
        private static string Select_SQL = "select PATIENT_ID,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02 from MED_PATS_IN_HOSPITAL WHERE PATIENT_ID=@PatientId";
        private static string Update_SQL = "Update MED_PATS_IN_HOSPITAL set INP_NO=@InpNo,PATIENT_SOURCE=@PatientSource,HOSP_BRANCH=@HospBranch,DEP_ID=@DepId,WARD_CODE=@WardCode,DEPT_CODE=@DeptCode,BED_NO=@BedNo,ADMISSION_DATE_TIME=@AdmissionDateTime,ADM_WARD_DATE_TIME=@AdmWardDateTime,DIAGNOSIS=@Diagnosis,PATIENT_CONDITION=@PatientCondition,BLOOD_TYPE=@BloodType,BLOOD_TYPE_RH=@BloodTypeRh,BODY_HEIGHT=@BodyHeight,BODY_WEIGHT=@BodyWeight,NURSING_CLASS=@NursingClass,DOCTOR_IN_CHARGE=@DoctorInCharge,NURSE_IN_CHARGE=@NurseInCharge,OPERATING_DATE=@OperatingDate,BILLING_DATE_TIME=@BillingDateTime,PREPAYMENTS=@Prepayments,TOTAL_COSTS=@TotalCosts,TOTAL_CHARGES=@TotalCharges,GUARANTOR=@Guarantor,GUARANTOR_ORG=@GuarantorOrg,GUARANTOR_PHONE_NUM=@GuarantorPhoneNum,BILL_CHECKED_DATE_TIME=@BillCheckedDateTime,SETTLED_INDICATOR=@SettledIndicator,RESERVED01=@Reserved01,RESERVED02=@Reserved02,RESERVED03=@Reserved03,RESERVED_DATE01=@ReservedDate01,RESERVED_DATE02=@ReservedDate02 where PATIENT_ID=@PatientId and VISIT_ID=@VisitId";
        private static string Insert_SQL = "Insert into   (PATIENT_ID,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02) values(@PatientId,@InpNo,@VisitId,@PatientSource,@HospBranch,@DepId,@WardCode,@DeptCode,@BedNo,@AdmissionDateTime,@AdmWardDateTime,@Diagnosis,@PatientCondition,@BloodType,@BloodTypeRh,@BodyHeight,@BodyWeight,@NursingClass,@DoctorInCharge,@NurseInCharge,@OperatingDate,@BillingDateTime,@Prepayments,@TotalCosts,@TotalCharges,@Guarantor,@GuarantorOrg,@GuarantorPhoneNum,@BillCheckedDateTime,@SettledIndicator,@Reserved01,@Reserved02,@Reserved03,@ReservedDate01,@ReservedDate02)";
        private static readonly string MED_PATS_IN_HOSPITAL_Delete_SQL = "DELETE MED_PATS_IN_HOSPITAL WHERE  PATIENT_ID=@PatientId";
        private static readonly string MED_PATS_IN_HOSPITAL_Select_ALL_SQL = "select PATIENT_ID,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02 FROM MED_PATS_IN_HOSPITAL";
        private static readonly string MED_PATS_IN_HOSPITAL_Select_Dept_SQL = "select PATIENT_ID,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02 FROM  MED_PATS_IN_HOSPITAL WHERE WARD_CODE = @wardCode ";
        private static readonly string MED_PATS_IN_HOSPITAL_Delete = "DELETE MED_PATS_IN_HOSPITAL WHERE  PATIENT_ID=:PatientId ";
         private static readonly string MED_PATS_IN_HOSPITAL_Select_ALL = "SELECT  PATIENT_ID,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02 FROM MED_PATS_IN_HOSPITAL";
         private static readonly string MED_PATS_IN_HOSPITAL_Select_Dept = "SELECT PATIENT_ID,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02 from MED_PATS_IN_HOSPITAL  WHERE WARD_CODE = :wardCode ";

        public DALMedPatsInHospital()
        {

        }
        #region [获取参数SQL]
        /// <summary>
        ///获取参数MedPatsInHospital SQL
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedPatsInHospital")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
                        new SqlParameter("@InpNo",SqlDbType.VarChar),
                        new SqlParameter("@VisitId",SqlDbType.Decimal),
                        new SqlParameter("@PatientSource",SqlDbType.Decimal),
                        new SqlParameter("@HospBranch",SqlDbType.VarChar),
                        new SqlParameter("@DepId",SqlDbType.Decimal),
                        new SqlParameter("@WardCode",SqlDbType.VarChar),
                        new SqlParameter("@DeptCode",SqlDbType.VarChar),
                        new SqlParameter("@BedNo",SqlDbType.VarChar),
                        new SqlParameter("@AdmissionDateTime",SqlDbType.DateTime),
                        new SqlParameter("@AdmWardDateTime",SqlDbType.DateTime),
                        new SqlParameter("@Diagnosis",SqlDbType.VarChar),
                        new SqlParameter("@PatientCondition",SqlDbType.VarChar),
                        new SqlParameter("@BloodType",SqlDbType.VarChar),
                        new SqlParameter("@BloodTypeRh",SqlDbType.VarChar),
                        new SqlParameter("@BodyHeight",SqlDbType.Decimal),
                        new SqlParameter("@BodyWeight",SqlDbType.Decimal),
                        new SqlParameter("@NursingClass",SqlDbType.VarChar),
                        new SqlParameter("@DoctorInCharge",SqlDbType.VarChar),
                        new SqlParameter("@NurseInCharge",SqlDbType.VarChar),
                        new SqlParameter("@OperatingDate",SqlDbType.DateTime),
                        new SqlParameter("@BillingDateTime",SqlDbType.DateTime),
                        new SqlParameter("@Prepayments",SqlDbType.Decimal),
                        new SqlParameter("@TotalCosts",SqlDbType.Decimal),
                        new SqlParameter("@TotalCharges",SqlDbType.Decimal),
                        new SqlParameter("@Guarantor",SqlDbType.VarChar),
                        new SqlParameter("@GuarantorOrg",SqlDbType.VarChar),
                        new SqlParameter("@GuarantorPhoneNum",SqlDbType.VarChar),
                        new SqlParameter("@BillCheckedDateTime",SqlDbType.DateTime),
                        new SqlParameter("@SettledIndicator",SqlDbType.Decimal),
                        new SqlParameter("@Reserved01",SqlDbType.VarChar),
                        new SqlParameter("@Reserved02",SqlDbType.VarChar),
                        new SqlParameter("@Reserved03",SqlDbType.VarChar),
                        new SqlParameter("@ReservedDate01",SqlDbType.DateTime),
                        new SqlParameter("@ReservedDate02",SqlDbType.DateTime),
                    };
                }
                else if (sqlParms == "UpdateMedPatsInHospital")
                {
                    parms = new SqlParameter[]{
					    new SqlParameter("@InpNo",SqlDbType.VarChar),
                      
                        new SqlParameter("@PatientSource",SqlDbType.Decimal),
                        new SqlParameter("@HospBranch",SqlDbType.VarChar),
                        new SqlParameter("@DepId",SqlDbType.Decimal),
                        new SqlParameter("@WardCode",SqlDbType.VarChar),
                        new SqlParameter("@DeptCode",SqlDbType.VarChar),
                        new SqlParameter("@BedNo",SqlDbType.VarChar),
                        new SqlParameter("@AdmissionDateTime",SqlDbType.DateTime),
                        new SqlParameter("@AdmWardDateTime",SqlDbType.DateTime),
                        new SqlParameter("@Diagnosis",SqlDbType.VarChar),
                        new SqlParameter("@PatientCondition",SqlDbType.VarChar),
                        new SqlParameter("@BloodType",SqlDbType.VarChar),
                        new SqlParameter("@BloodTypeRh",SqlDbType.VarChar),
                        new SqlParameter("@BodyHeight",SqlDbType.Decimal),
                        new SqlParameter("@BodyWeight",SqlDbType.Decimal),
                        new SqlParameter("@NursingClass",SqlDbType.VarChar),
                        new SqlParameter("@DoctorInCharge",SqlDbType.VarChar),
                        new SqlParameter("@NurseInCharge",SqlDbType.VarChar),
                        new SqlParameter("@OperatingDate",SqlDbType.DateTime),
                        new SqlParameter("@BillingDateTime",SqlDbType.DateTime),
                        new SqlParameter("@Prepayments",SqlDbType.Decimal),
                        new SqlParameter("@TotalCosts",SqlDbType.Decimal),
                        new SqlParameter("@TotalCharges",SqlDbType.Decimal),
                        new SqlParameter("@Guarantor",SqlDbType.VarChar),
                        new SqlParameter("@GuarantorOrg",SqlDbType.VarChar),
                        new SqlParameter("@GuarantorPhoneNum",SqlDbType.VarChar),
                        new SqlParameter("@BillCheckedDateTime",SqlDbType.DateTime),
                        new SqlParameter("@SettledIndicator",SqlDbType.Decimal),
                        new SqlParameter("@Reserved01",SqlDbType.VarChar),
                        new SqlParameter("@Reserved02",SqlDbType.VarChar),
                        new SqlParameter("@Reserved03",SqlDbType.VarChar),
                        new SqlParameter("@ReservedDate01",SqlDbType.DateTime),
                        new SqlParameter("@ReservedDate02",SqlDbType.DateTime),
                        new SqlParameter("@PatientId",SqlDbType.VarChar),
                          new SqlParameter("@VisitId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedPatsInHospital")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPatsInHospital")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectDeptMedPatsInHospital")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@WardCode",SqlDbType.VarChar),
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedPatsInHospital 
        ///Insert Table MED_PATS_IN_HOSPITAL
        /// </summary>
        public int InsertMedPatsInHospitalSQL(MedPatsInHospital model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedPatsInHospital");
                if (model.PatientId != null)
                    oneInert[0].Value = model.PatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.InpNo != null)
                    oneInert[1].Value = model.InpNo;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneInert[2].Value = model.VisitId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.PatientSource != null)
                    oneInert[3].Value = model.PatientSource;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.HospBranch != null)
                    oneInert[4].Value = model.HospBranch;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.DepId != null)
                    oneInert[5].Value = model.DepId;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneInert[6].Value = model.WardCode;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneInert[7].Value = model.DeptCode;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneInert[8].Value = model.BedNo;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.AdmissionDateTime != null)
                    oneInert[9].Value = model.AdmissionDateTime;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.AdmWardDateTime != null)
                    oneInert[10].Value = model.AdmWardDateTime;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.Diagnosis != null)
                    oneInert[11].Value = model.Diagnosis;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.PatientCondition != null)
                    oneInert[12].Value = model.PatientCondition;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.BloodType != null)
                    oneInert[13].Value = model.BloodType;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.BloodTypeRh != null)
                    oneInert[14].Value = model.BloodTypeRh;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.BodyHeight != null)
                    oneInert[15].Value = model.BodyHeight;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.BodyWeight != null)
                    oneInert[16].Value = model.BodyWeight;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.NursingClass != null)
                    oneInert[17].Value = model.NursingClass;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.DoctorInCharge != null)
                    oneInert[18].Value = model.DoctorInCharge;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.NurseInCharge != null)
                    oneInert[19].Value = model.NurseInCharge;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.OperatingDate != null)
                    oneInert[20].Value = model.OperatingDate;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.BillingDateTime != null)
                    oneInert[21].Value = model.BillingDateTime;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.Prepayments != null)
                    oneInert[22].Value = model.Prepayments;
                else
                    oneInert[22].Value = DBNull.Value;
                if (model.TotalCosts != null)
                    oneInert[23].Value = model.TotalCosts;
                else
                    oneInert[23].Value = DBNull.Value;
                if (model.TotalCharges != null)
                    oneInert[24].Value = model.TotalCharges;
                else
                    oneInert[24].Value = DBNull.Value;
                if (model.Guarantor != null)
                    oneInert[25].Value = model.Guarantor;
                else
                    oneInert[25].Value = DBNull.Value;
                if (model.GuarantorOrg != null)
                    oneInert[26].Value = model.GuarantorOrg;
                else
                    oneInert[26].Value = DBNull.Value;
                if (model.GuarantorPhoneNum != null)
                    oneInert[27].Value = model.GuarantorPhoneNum;
                else
                    oneInert[27].Value = DBNull.Value;
                if (model.BillCheckedDateTime != null)
                    oneInert[28].Value = model.BillCheckedDateTime;
                else
                    oneInert[28].Value = DBNull.Value;
                if (model.SettledIndicator != null)
                    oneInert[29].Value = model.SettledIndicator;
                else
                    oneInert[29].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneInert[30].Value = model.Reserved01;
                else
                    oneInert[30].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneInert[31].Value = model.Reserved02;
                else
                    oneInert[31].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneInert[32].Value = model.Reserved03;
                else
                    oneInert[32].Value = DBNull.Value;
                if (model.ReservedDate01 != null)
                    oneInert[33].Value = model.ReservedDate01;
                else
                    oneInert[33].Value = DBNull.Value;
                if (model.ReservedDate02 != null)
                    oneInert[34].Value = model.ReservedDate02;
                else
                    oneInert[34].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, Insert_SQL, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedPatsInHospital 
        ///Update Table     MED_PATS_IN_HOSPITAL
        /// </summary>
        public int UpdateMedPatsInHospitalSQL(MedPatsInHospital model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedPatsInHospital");
               
                if (model.InpNo != null)
                    oneUpdate[0].Value = model.InpNo;
                else
                    oneUpdate[0].Value = DBNull.Value;

                if (model.PatientSource != null)
                    oneUpdate[1].Value = model.PatientSource;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.HospBranch != null)
                    oneUpdate[2].Value = model.HospBranch;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.DepId != null)
                    oneUpdate[3].Value = model.DepId;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneUpdate[4].Value = model.WardCode;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneUpdate[5].Value = model.DeptCode;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneUpdate[6].Value = model.BedNo;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.AdmissionDateTime != null)
                    oneUpdate[7].Value = model.AdmissionDateTime;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.AdmWardDateTime != null)
                    oneUpdate[8].Value = model.AdmWardDateTime;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.Diagnosis != null)
                    oneUpdate[9].Value = model.Diagnosis;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.PatientCondition != null)
                    oneUpdate[10].Value = model.PatientCondition;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.BloodType != null)
                    oneUpdate[11].Value = model.BloodType;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.BloodTypeRh != null)
                    oneUpdate[12].Value = model.BloodTypeRh;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.BodyHeight != null)
                    oneUpdate[13].Value = model.BodyHeight.Value;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.BodyWeight != null)
                    oneUpdate[14].Value = model.BodyWeight.Value;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.NursingClass != null)
                    oneUpdate[15].Value = model.NursingClass;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.DoctorInCharge != null)
                    oneUpdate[16].Value = model.DoctorInCharge;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.NurseInCharge != null)
                    oneUpdate[17].Value = model.NurseInCharge;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.OperatingDate != null)
                    oneUpdate[18].Value = model.OperatingDate;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.BillingDateTime != null)
                    oneUpdate[19].Value = model.BillingDateTime;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.Prepayments != null)
                    oneUpdate[20].Value = model.Prepayments.Value;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.TotalCosts != null)
                    oneUpdate[21].Value = model.TotalCosts.Value;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.TotalCharges.HasValue)
                    oneUpdate[22].Value = model.TotalCharges.Value;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.Guarantor != null)
                    oneUpdate[23].Value = model.Guarantor;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.GuarantorOrg != null)
                    oneUpdate[24].Value = model.GuarantorOrg;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.GuarantorPhoneNum != null)
                    oneUpdate[25].Value = model.GuarantorPhoneNum;
                else
                    oneUpdate[25].Value = DBNull.Value;
                if (model.BillCheckedDateTime != null)
                    oneUpdate[26].Value = model.BillCheckedDateTime;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (model.SettledIndicator.HasValue)
                    oneUpdate[27].Value = model.SettledIndicator.Value;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneUpdate[28].Value = model.Reserved01;
                else
                    oneUpdate[28].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneUpdate[29].Value = model.Reserved02;
                else
                    oneUpdate[29].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneUpdate[30].Value = model.Reserved03;
                else
                    oneUpdate[30].Value = DBNull.Value;
                if (model.ReservedDate01.HasValue)
                    oneUpdate[31].Value = model.ReservedDate01.Value;
                else
                    oneUpdate[31].Value = DBNull.Value;
                if (model.ReservedDate02.HasValue)
                    oneUpdate[32].Value = model.ReservedDate02.Value;
                else
                    oneUpdate[32].Value = DBNull.Value;

                if (model.PatientId != null)
                    oneUpdate[33].Value = model.PatientId;
                else
                    oneUpdate[33].Value = DBNull.Value;

                if (model.VisitId != null)
                    oneUpdate[34].Value = model.VisitId;
                else
                    oneUpdate[34].Value = DBNull.Value;
              
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, Update_SQL, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedPatsInHospital 
        ///Delete Table MED_PATS_IN_HOSPITAL by (string PATIENT_ID)
        /// </summary>
        public int DeleteMedPatsInHospitalSQL(string PATIENT_ID)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneDelete = GetParameterSQL("DeleteMedPatsInHospital");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_PATS_IN_HOSPITAL_Delete_SQL, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedPatsInHospital 
        ///select Table MED_PATS_IN_HOSPITAL by (string PATIENT_ID)
        /// </summary>
        public MedPatsInHospital SelectMedPatsInHospitalSQL(string PATIENT_ID)
        {
            MedPatsInHospital model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedPatsInHospital");
            parameterValues[0].Value = PATIENT_ID;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPatsInHospital();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.PatientId = oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.InpNo = oleReader["INP_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.PatientSource = decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DepId = decimal.Parse(oleReader["DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.AdmWardDateTime = DateTime.Parse(oleReader["ADM_WARD_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Diagnosis = oleReader["DIAGNOSIS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.BloodType = oleReader["BLOOD_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.BloodTypeRh = oleReader["BLOOD_TYPE_RH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.BodyHeight = decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.BodyWeight = decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.NursingClass = oleReader["NURSING_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.NurseInCharge = oleReader["NURSE_IN_CHARGE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.OperatingDate = DateTime.Parse(oleReader["OPERATING_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.BillingDateTime = DateTime.Parse(oleReader["BILLING_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Prepayments = decimal.Parse(oleReader["PREPAYMENTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.TotalCosts = decimal.Parse(oleReader["TOTAL_COSTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.TotalCharges = decimal.Parse(oleReader["TOTAL_CHARGES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Guarantor = oleReader["GUARANTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.GuarantorOrg = oleReader["GUARANTOR_ORG"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.GuarantorPhoneNum = oleReader["GUARANTOR_PHONE_NUM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.BillCheckedDateTime = DateTime.Parse(oleReader["BILL_CHECKED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.SettledIndicator = decimal.Parse(oleReader["SETTLED_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.ReservedDate01 = DateTime.Parse(oleReader["RESERVED_DATE01"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.ReservedDate02 = DateTime.Parse(oleReader["RESERVED_DATE02"].ToString().Trim());
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
        public List<MedPatsInHospital> SelectMedPatsInHospitalListSQL()
        {
            List<MedPatsInHospital> modelList = new List<MedPatsInHospital>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_PATS_IN_HOSPITAL_Select_ALL_SQL, null))
            {
                while (oleReader.Read())
                {
                    MedPatsInHospital model = new MedPatsInHospital();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.PatientId = oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.InpNo = oleReader["INP_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.PatientSource = decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DepId = decimal.Parse(oleReader["DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.AdmWardDateTime = DateTime.Parse(oleReader["ADM_WARD_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Diagnosis = oleReader["DIAGNOSIS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.BloodType = oleReader["BLOOD_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.BloodTypeRh = oleReader["BLOOD_TYPE_RH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.BodyHeight = decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.BodyWeight = decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.NursingClass = oleReader["NURSING_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.NurseInCharge = oleReader["NURSE_IN_CHARGE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.OperatingDate = DateTime.Parse(oleReader["OPERATING_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.BillingDateTime = DateTime.Parse(oleReader["BILLING_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Prepayments = decimal.Parse(oleReader["PREPAYMENTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.TotalCosts = decimal.Parse(oleReader["TOTAL_COSTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.TotalCharges = decimal.Parse(oleReader["TOTAL_CHARGES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Guarantor = oleReader["GUARANTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.GuarantorOrg = oleReader["GUARANTOR_ORG"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.GuarantorPhoneNum = oleReader["GUARANTOR_PHONE_NUM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.BillCheckedDateTime = DateTime.Parse(oleReader["BILL_CHECKED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.SettledIndicator = decimal.Parse(oleReader["SETTLED_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.ReservedDate01 = DateTime.Parse(oleReader["RESERVED_DATE01"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.ReservedDate02 = DateTime.Parse(oleReader["RESERVED_DATE02"].ToString().Trim());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
        #region  [根据病区代码获取相关信息]
        /// <summary>
        /// 根据病区代码获取相关信息
        /// </summary>
        /// <param name="wardCode">病区代码</param>
        /// <returns>所在病区病人信息</returns>
        public List<Model.MedPatsInHospital> SelectDeptMedPatsInHospitalSQL(string wardCode)
        {
            List<Model.MedPatsInHospital> deptMedPatsInHospital = new List<Model.MedPatsInHospital>();

            SqlParameter[] mdPatsInHospital = GetParameterSQL("SelectDeptMedPatsInHospital");
            mdPatsInHospital[0].Value = wardCode;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_PATS_IN_HOSPITAL_Select_Dept_SQL, mdPatsInHospital))
            {
                while (oleReader.Read())
                {
                    Model.MedPatsInHospital model = new Model.MedPatsInHospital();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.PatientId = oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.InpNo = oleReader["INP_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.PatientSource = decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DepId = decimal.Parse(oleReader["DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.AdmWardDateTime = DateTime.Parse(oleReader["ADM_WARD_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Diagnosis = oleReader["DIAGNOSIS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.BloodType = oleReader["BLOOD_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.BloodTypeRh = oleReader["BLOOD_TYPE_RH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.BodyHeight = decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.BodyWeight = decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.NursingClass = oleReader["NURSING_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.NurseInCharge = oleReader["NURSE_IN_CHARGE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.OperatingDate = DateTime.Parse(oleReader["OPERATING_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.BillingDateTime = DateTime.Parse(oleReader["BILLING_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Prepayments = decimal.Parse(oleReader["PREPAYMENTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.TotalCosts = decimal.Parse(oleReader["TOTAL_COSTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.TotalCharges = decimal.Parse(oleReader["TOTAL_CHARGES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Guarantor = oleReader["GUARANTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.GuarantorOrg = oleReader["GUARANTOR_ORG"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.GuarantorPhoneNum = oleReader["GUARANTOR_PHONE_NUM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.BillCheckedDateTime = DateTime.Parse(oleReader["BILL_CHECKED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.SettledIndicator = decimal.Parse(oleReader["SETTLED_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.ReservedDate01 = DateTime.Parse(oleReader["RESERVED_DATE01"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.ReservedDate02 = DateTime.Parse(oleReader["RESERVED_DATE02"].ToString().Trim());
                    }
                    deptMedPatsInHospital.Add(model);
                }
            }
            return deptMedPatsInHospital;
        }
        #endregion


        #region [获取参数]
        /// <summary>
        ///获取参数MedPatsInHospital
        /// </summary>
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedPatsInHospital")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
                            new OracleParameter(":InpNo",OracleType.VarChar),
                            new OracleParameter(":VisitId",OracleType.Number),
                            new OracleParameter(":PatientSource",OracleType.Number),
                            new OracleParameter(":HospBranch",OracleType.VarChar),
                            new OracleParameter(":DepId",OracleType.Number),
                            new OracleParameter(":WardCode",OracleType.VarChar),
                            new OracleParameter(":DeptCode",OracleType.VarChar),
                            new OracleParameter(":BedNo",OracleType.VarChar),
                            new OracleParameter(":AdmissionDateTime",OracleType.DateTime),
                            new OracleParameter(":AdmWardDateTime",OracleType.DateTime),
                            new OracleParameter(":Diagnosis",OracleType.VarChar),
                            new OracleParameter(":PatientCondition",OracleType.VarChar),
                            new OracleParameter(":BloodType",OracleType.VarChar),
                            new OracleParameter(":BloodTypeRh",OracleType.VarChar),
                            new OracleParameter(":BodyHeight",OracleType.Number),
                            new OracleParameter(":BodyWeight",OracleType.Number),
                            new OracleParameter(":NursingClass",OracleType.VarChar),
                            new OracleParameter(":DoctorInCharge",OracleType.VarChar),
                            new OracleParameter(":NurseInCharge",OracleType.VarChar),
                            new OracleParameter(":OperatingDate",OracleType.DateTime),
                            new OracleParameter(":BillingDateTime",OracleType.DateTime),
                            new OracleParameter(":Prepayments",OracleType.Number),
                            new OracleParameter(":TotalCosts",OracleType.Number),
                            new OracleParameter(":TotalCharges",OracleType.Number),
                            new OracleParameter(":Guarantor",OracleType.VarChar),
                            new OracleParameter(":GuarantorOrg",OracleType.VarChar),
                            new OracleParameter(":GuarantorPhoneNum",OracleType.VarChar),
                            new OracleParameter(":BillCheckedDateTime",OracleType.DateTime),
                            new OracleParameter(":SettledIndicator",OracleType.Number),
                            new OracleParameter(":Reserved01",OracleType.VarChar),
                            new OracleParameter(":Reserved02",OracleType.VarChar),
                            new OracleParameter(":Reserved03",OracleType.VarChar),
                            new OracleParameter(":ReservedDate01",OracleType.DateTime),
                            new OracleParameter(":ReservedDate02",OracleType.DateTime),
                    };
                }
                else if (sqlParms == "UpdateMedPatsInHospital")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":InpNo",OracleType.VarChar),
                            new OracleParameter(":PatientSource",OracleType.Number),
                            new OracleParameter(":HospBranch",OracleType.VarChar),
                            new OracleParameter(":DepId",OracleType.Number),
                            new OracleParameter(":WardCode",OracleType.VarChar),
                            new OracleParameter(":DeptCode",OracleType.VarChar),
                            new OracleParameter(":BedNo",OracleType.VarChar),
                            new OracleParameter(":AdmissionDateTime",OracleType.DateTime),
                            new OracleParameter(":AdmWardDateTime",OracleType.DateTime),
                            new OracleParameter(":Diagnosis",OracleType.VarChar),
                            new OracleParameter(":PatientCondition",OracleType.VarChar),
                            new OracleParameter(":BloodType",OracleType.VarChar),
                            new OracleParameter(":BloodTypeRh",OracleType.VarChar),
                            new OracleParameter(":BodyHeight",OracleType.Number),
                            new OracleParameter(":BodyWeight",OracleType.Number),
                            new OracleParameter(":NursingClass",OracleType.VarChar),
                            new OracleParameter(":DoctorInCharge",OracleType.VarChar),
                            new OracleParameter(":NurseInCharge",OracleType.VarChar),
                            new OracleParameter(":OperatingDate",OracleType.DateTime),
                            new OracleParameter(":BillingDateTime",OracleType.DateTime),
                            new OracleParameter(":Prepayments",OracleType.Number),
                            new OracleParameter(":TotalCosts",OracleType.Number),
                            new OracleParameter(":TotalCharges",OracleType.Number),
                            new OracleParameter(":Guarantor",OracleType.VarChar),
                            new OracleParameter(":GuarantorOrg",OracleType.VarChar),
                            new OracleParameter(":GuarantorPhoneNum",OracleType.VarChar),
                            new OracleParameter(":BillCheckedDateTime",OracleType.DateTime),
                            new OracleParameter(":SettledIndicator",OracleType.Number),
                            new OracleParameter(":Reserved01",OracleType.VarChar),
                            new OracleParameter(":Reserved02",OracleType.VarChar),
                            new OracleParameter(":Reserved03",OracleType.VarChar),
                            new OracleParameter(":ReservedDate01",OracleType.DateTime),
                            new OracleParameter(":ReservedDate02",OracleType.DateTime),
                            new OracleParameter(":PatientId",OracleType.VarChar),
                            new OracleParameter(":VisitId",OracleType.Number),
                    };
                }
                else if (sqlParms == "DeleteMedPatsInHospital")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPatsInHospital")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
                             new OracleParameter(":VisitId",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectDeptMedPatsInHospital")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":WardCode",OracleType.VarChar),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedPatsInHospital 
        ///Insert Table MED_PATS_IN_HOSPITAL
        /// </summary>
        public int InsertMedPatsInHospital(MedPatsInHospital model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedPatsInHospital");
                if (model.PatientId != null)
                    oneInert[0].Value = model.PatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.InpNo != null)
                    oneInert[1].Value = model.InpNo;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneInert[2].Value = model.VisitId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.PatientSource != null)
                    oneInert[3].Value = model.PatientSource;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.HospBranch != null)
                    oneInert[4].Value = model.HospBranch;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.DepId != null)
                    oneInert[5].Value = model.DepId;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneInert[6].Value = model.WardCode;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneInert[7].Value = model.DeptCode;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneInert[8].Value = model.BedNo;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.AdmissionDateTime != null)
                    oneInert[9].Value = model.AdmissionDateTime;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.AdmWardDateTime != null)
                    oneInert[10].Value = model.AdmWardDateTime;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.Diagnosis != null)
                    oneInert[11].Value = model.Diagnosis;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.PatientCondition != null)
                    oneInert[12].Value = model.PatientCondition;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.BloodType != null)
                    oneInert[13].Value = model.BloodType;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.BloodTypeRh != null)
                    oneInert[14].Value = model.BloodTypeRh;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.BodyHeight != null)
                    oneInert[15].Value = model.BodyHeight;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.BodyWeight != null)
                    oneInert[16].Value = model.BodyWeight;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.NursingClass != null)
                    oneInert[17].Value = model.NursingClass;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.DoctorInCharge != null)
                    oneInert[18].Value = model.DoctorInCharge;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.NurseInCharge != null)
                    oneInert[19].Value = model.NurseInCharge;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.OperatingDate != null)
                    oneInert[20].Value = model.OperatingDate;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.BillingDateTime != null)
                    oneInert[21].Value = model.BillingDateTime;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.Prepayments != null)
                    oneInert[22].Value = model.Prepayments;
                else
                    oneInert[22].Value = DBNull.Value;
                if (model.TotalCosts != null)
                    oneInert[23].Value = model.TotalCosts;
                else
                    oneInert[23].Value = DBNull.Value;
                if (model.TotalCharges != null)
                    oneInert[24].Value = model.TotalCharges;
                else
                    oneInert[24].Value = DBNull.Value;
                if (model.Guarantor != null)
                    oneInert[25].Value = model.Guarantor;
                else
                    oneInert[25].Value = DBNull.Value;
                if (model.GuarantorOrg != null)
                    oneInert[26].Value = model.GuarantorOrg;
                else
                    oneInert[26].Value = DBNull.Value;
                if (model.GuarantorPhoneNum != null)
                    oneInert[27].Value = model.GuarantorPhoneNum;
                else
                    oneInert[27].Value = DBNull.Value;
                if (model.BillCheckedDateTime != null)
                    oneInert[28].Value = model.BillCheckedDateTime;
                else
                    oneInert[28].Value = DBNull.Value;
                if (model.SettledIndicator != null)
                    oneInert[29].Value = model.SettledIndicator;
                else
                    oneInert[29].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneInert[30].Value = model.Reserved01;
                else
                    oneInert[30].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneInert[31].Value = model.Reserved02;
                else
                    oneInert[31].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneInert[32].Value = model.Reserved03;
                else
                    oneInert[32].Value = DBNull.Value;
                if (model.ReservedDate01 != null)
                    oneInert[33].Value = model.ReservedDate01;
                else
                    oneInert[33].Value = DBNull.Value;
                if (model.ReservedDate02 != null)
                    oneInert[34].Value = model.ReservedDate02;
                else
                    oneInert[34].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, Insert, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedPatsInHospital 
        ///Update Table     MED_PATS_IN_HOSPITAL
        /// </summary>
        public int UpdateMedPatsInHospital(MedPatsInHospital model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedPatsInHospital");
                if (model.InpNo != null)
                    oneUpdate[0].Value = model.InpNo;
                else
                    oneUpdate[0].Value = DBNull.Value;

                if (model.PatientSource != null)
                    oneUpdate[1].Value = model.PatientSource;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.HospBranch != null)
                    oneUpdate[2].Value = model.HospBranch;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.DepId != null)
                    oneUpdate[3].Value = model.DepId;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneUpdate[4].Value = model.WardCode;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneUpdate[5].Value = model.DeptCode;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneUpdate[6].Value = model.BedNo;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.AdmissionDateTime != null)
                    oneUpdate[7].Value = model.AdmissionDateTime;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.AdmWardDateTime != null)
                    oneUpdate[8].Value = model.AdmWardDateTime;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.Diagnosis != null)
                    oneUpdate[9].Value = model.Diagnosis;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.PatientCondition != null)
                    oneUpdate[10].Value = model.PatientCondition;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.BloodType != null)
                    oneUpdate[11].Value = model.BloodType;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.BloodTypeRh != null)
                    oneUpdate[12].Value = model.BloodTypeRh;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.BodyHeight != null)
                    oneUpdate[13].Value = model.BodyHeight.Value;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.BodyWeight != null)
                    oneUpdate[14].Value = model.BodyWeight.Value;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.NursingClass != null)
                    oneUpdate[15].Value = model.NursingClass;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.DoctorInCharge != null)
                    oneUpdate[16].Value = model.DoctorInCharge;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.NurseInCharge != null)
                    oneUpdate[17].Value = model.NurseInCharge;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.OperatingDate != null)
                    oneUpdate[18].Value = model.OperatingDate;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.BillingDateTime != null)
                    oneUpdate[19].Value = model.BillingDateTime;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.Prepayments != null)
                    oneUpdate[20].Value = model.Prepayments.Value;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.TotalCosts != null)
                    oneUpdate[21].Value = model.TotalCosts.Value;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.TotalCharges.HasValue)
                    oneUpdate[22].Value = model.TotalCharges.Value;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.Guarantor != null)
                    oneUpdate[23].Value = model.Guarantor;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.GuarantorOrg != null)
                    oneUpdate[24].Value = model.GuarantorOrg;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.GuarantorPhoneNum != null)
                    oneUpdate[25].Value = model.GuarantorPhoneNum;
                else
                    oneUpdate[25].Value = DBNull.Value;
                if (model.BillCheckedDateTime != null)
                    oneUpdate[26].Value = model.BillCheckedDateTime;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (model.SettledIndicator.HasValue)
                    oneUpdate[27].Value = model.SettledIndicator.Value;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneUpdate[28].Value = model.Reserved01;
                else
                    oneUpdate[28].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneUpdate[29].Value = model.Reserved02;
                else
                    oneUpdate[29].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneUpdate[30].Value = model.Reserved03;
                else
                    oneUpdate[30].Value = DBNull.Value;
                if (model.ReservedDate01.HasValue)
                    oneUpdate[31].Value = model.ReservedDate01.Value;
                else
                    oneUpdate[31].Value = DBNull.Value;
                if (model.ReservedDate02.HasValue)
                    oneUpdate[32].Value = model.ReservedDate02.Value;
                else
                    oneUpdate[32].Value = DBNull.Value;

                if (model.PatientId != null)
                    oneUpdate[33].Value = model.PatientId;
                else
                    oneUpdate[33].Value = DBNull.Value;

                if (model.VisitId != null)
                    oneUpdate[34].Value = model.VisitId;
                else
                    oneUpdate[34].Value = DBNull.Value;
              
                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, Update, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedPatsInHospital 
        ///Delete Table MED_PATS_IN_HOSPITAL by (string PATIENT_ID)
        /// </summary>
        public int DeleteMedPatsInHospital(string PATIENT_ID)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneDelete = GetParameter("DeleteMedPatsInHospital");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_PATS_IN_HOSPITAL_Delete, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedPatsInHospital 
        ///select Table MED_PATS_IN_HOSPITAL by (string PATIENT_ID)
        /// </summary>
        public MedPatsInHospital SelectMedPatsInHospital(string PATIENT_ID,decimal VISIT_ID)
        {
            MedPatsInHospital model;
            OracleParameter[] parameterValues = GetParameter("SelectMedPatsInHospital");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
           
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPatsInHospital();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.PatientId = oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.InpNo = oleReader["INP_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.PatientSource = decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DepId = decimal.Parse(oleReader["DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.AdmWardDateTime = DateTime.Parse(oleReader["ADM_WARD_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Diagnosis = oleReader["DIAGNOSIS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.BloodType = oleReader["BLOOD_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.BloodTypeRh = oleReader["BLOOD_TYPE_RH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.BodyHeight = decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.BodyWeight = decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.NursingClass = oleReader["NURSING_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.NurseInCharge = oleReader["NURSE_IN_CHARGE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.OperatingDate = DateTime.Parse(oleReader["OPERATING_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.BillingDateTime = DateTime.Parse(oleReader["BILLING_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Prepayments = decimal.Parse(oleReader["PREPAYMENTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.TotalCosts = decimal.Parse(oleReader["TOTAL_COSTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.TotalCharges = decimal.Parse(oleReader["TOTAL_CHARGES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Guarantor = oleReader["GUARANTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.GuarantorOrg = oleReader["GUARANTOR_ORG"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.GuarantorPhoneNum = oleReader["GUARANTOR_PHONE_NUM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.BillCheckedDateTime = DateTime.Parse(oleReader["BILL_CHECKED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.SettledIndicator = decimal.Parse(oleReader["SETTLED_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.ReservedDate01 = DateTime.Parse(oleReader["RESERVED_DATE01"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.ReservedDate02 = DateTime.Parse(oleReader["RESERVED_DATE02"].ToString().Trim());
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
        public List<MedPatsInHospital> SelectMedPatsInHospitalList()
        {
            List<MedPatsInHospital> modelList = new List<MedPatsInHospital>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_PATS_IN_HOSPITAL_Select_ALL, null))
            {
                while (oleReader.Read())
                {
                    MedPatsInHospital model = new MedPatsInHospital();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.PatientId = oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.InpNo = oleReader["INP_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.PatientSource = decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DepId = decimal.Parse(oleReader["DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.AdmWardDateTime = DateTime.Parse(oleReader["ADM_WARD_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Diagnosis = oleReader["DIAGNOSIS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.BloodType = oleReader["BLOOD_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.BloodTypeRh = oleReader["BLOOD_TYPE_RH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.BodyHeight = decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.BodyWeight = decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.NursingClass = oleReader["NURSING_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.NurseInCharge = oleReader["NURSE_IN_CHARGE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.OperatingDate = DateTime.Parse(oleReader["OPERATING_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.BillingDateTime = DateTime.Parse(oleReader["BILLING_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Prepayments = decimal.Parse(oleReader["PREPAYMENTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.TotalCosts = decimal.Parse(oleReader["TOTAL_COSTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.TotalCharges = decimal.Parse(oleReader["TOTAL_CHARGES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Guarantor = oleReader["GUARANTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.GuarantorOrg = oleReader["GUARANTOR_ORG"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.GuarantorPhoneNum = oleReader["GUARANTOR_PHONE_NUM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.BillCheckedDateTime = DateTime.Parse(oleReader["BILL_CHECKED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.SettledIndicator = decimal.Parse(oleReader["SETTLED_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.ReservedDate01 = DateTime.Parse(oleReader["RESERVED_DATE01"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.ReservedDate02 = DateTime.Parse(oleReader["RESERVED_DATE02"].ToString().Trim());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
        #region  [根据病区代码获取相关信息]
        /// <summary>
        /// 根据病区代码获取相关信息
        /// </summary>
        /// <param name="wardCode">病区代码</param>
        /// <returns>所在病区病人信息</returns>
        public List<Model.MedPatsInHospital> SelectDeptMedPatsInHospital(string wardCode)
        {
            List<Model.MedPatsInHospital> deptMedPatsInHospital = new List<Model.MedPatsInHospital>();

            OracleParameter[] mdPatsInHospital = GetParameter("SelectDeptMedPatsInHospital");
            mdPatsInHospital[0].Value = wardCode;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_PATS_IN_HOSPITAL_Select_Dept, mdPatsInHospital))
            {
                while (oleReader.Read())
                {
                    Model.MedPatsInHospital model = new Model.MedPatsInHospital();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.PatientId = oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.InpNo = oleReader["INP_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.PatientSource = decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DepId = decimal.Parse(oleReader["DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.AdmissionDateTime = DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.AdmWardDateTime = DateTime.Parse(oleReader["ADM_WARD_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Diagnosis = oleReader["DIAGNOSIS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.BloodType = oleReader["BLOOD_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.BloodTypeRh = oleReader["BLOOD_TYPE_RH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.BodyHeight = decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.BodyWeight = decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.NursingClass = oleReader["NURSING_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.DoctorInCharge = oleReader["DOCTOR_IN_CHARGE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.NurseInCharge = oleReader["NURSE_IN_CHARGE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.OperatingDate = DateTime.Parse(oleReader["OPERATING_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.BillingDateTime = DateTime.Parse(oleReader["BILLING_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Prepayments = decimal.Parse(oleReader["PREPAYMENTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.TotalCosts = decimal.Parse(oleReader["TOTAL_COSTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.TotalCharges = decimal.Parse(oleReader["TOTAL_CHARGES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Guarantor = oleReader["GUARANTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.GuarantorOrg = oleReader["GUARANTOR_ORG"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.GuarantorPhoneNum = oleReader["GUARANTOR_PHONE_NUM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.BillCheckedDateTime = DateTime.Parse(oleReader["BILL_CHECKED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.SettledIndicator = decimal.Parse(oleReader["SETTLED_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.ReservedDate01 = DateTime.Parse(oleReader["RESERVED_DATE01"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.ReservedDate02 = DateTime.Parse(oleReader["RESERVED_DATE02"].ToString().Trim());
                    }
                    deptMedPatsInHospital.Add(model);
                }
            }
            return deptMedPatsInHospital;
        }
        #endregion
    }
}
