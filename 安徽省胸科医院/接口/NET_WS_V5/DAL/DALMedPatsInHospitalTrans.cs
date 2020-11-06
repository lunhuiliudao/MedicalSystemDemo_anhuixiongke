

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

        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedPatsInHospital 
        ///Insert Table MED_PATS_IN_HOSPITAL
        /// </summary>
        public int InsertMedPatsInHospitalSQL(MedPatsInHospital model, System.Data.Common.DbTransaction oleCisTrans)
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


            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, Insert_SQL, oneInert);

        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedPatsInHospital 
        ///Update Table     MED_PATS_IN_HOSPITAL
        /// </summary>
        public int UpdateMedPatsInHospitalSQL(MedPatsInHospital model, System.Data.Common.DbTransaction oleCisTrans)
        {
            SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedPatsInHospital");
            if (model.InpNo != null)
                oneUpdate[0].Value = model.InpNo;
            else
                oneUpdate[0].Value = DBNull.Value;
            if (model.VisitId != null)
                oneUpdate[1].Value = model.VisitId;
            else
                oneUpdate[1].Value = DBNull.Value;
            if (model.PatientSource != null)
                oneUpdate[2].Value = model.PatientSource;
            else
                oneUpdate[2].Value = DBNull.Value;
            if (model.HospBranch != null)
                oneUpdate[3].Value = model.HospBranch;
            else
                oneUpdate[3].Value = DBNull.Value;
            if (model.DepId != null)
                oneUpdate[4].Value = model.DepId;
            else
                oneUpdate[4].Value = DBNull.Value;
            if (model.WardCode != null)
                oneUpdate[5].Value = model.WardCode;
            else
                oneUpdate[5].Value = DBNull.Value;
            if (model.DeptCode != null)
                oneUpdate[6].Value = model.DeptCode;
            else
                oneUpdate[6].Value = DBNull.Value;
            if (model.BedNo != null)
                oneUpdate[7].Value = model.BedNo;
            else
                oneUpdate[7].Value = DBNull.Value;
            if (model.AdmissionDateTime != null)
                oneUpdate[8].Value = model.AdmissionDateTime;
            else
                oneUpdate[8].Value = DBNull.Value;
            if (model.AdmWardDateTime != null)
                oneUpdate[9].Value = model.AdmWardDateTime;
            else
                oneUpdate[9].Value = DBNull.Value;
            if (model.Diagnosis != null)
                oneUpdate[10].Value = model.Diagnosis;
            else
                oneUpdate[10].Value = DBNull.Value;
            if (model.PatientCondition != null)
                oneUpdate[11].Value = model.PatientCondition;
            else
                oneUpdate[11].Value = DBNull.Value;
            if (model.BloodType != null)
                oneUpdate[12].Value = model.BloodType;
            else
                oneUpdate[12].Value = DBNull.Value;
            if (model.BloodTypeRh != null)
                oneUpdate[13].Value = model.BloodTypeRh;
            else
                oneUpdate[13].Value = DBNull.Value;
            if (model.BodyHeight != null)
                oneUpdate[14].Value = model.BodyHeight;
            else
                oneUpdate[14].Value = DBNull.Value;
            if (model.BodyWeight != null)
                oneUpdate[15].Value = model.BodyWeight;
            else
                oneUpdate[15].Value = DBNull.Value;
            if (model.NursingClass != null)
                oneUpdate[16].Value = model.NursingClass;
            else
                oneUpdate[16].Value = DBNull.Value;
            if (model.DoctorInCharge != null)
                oneUpdate[17].Value = model.DoctorInCharge;
            else
                oneUpdate[17].Value = DBNull.Value;
            if (model.NurseInCharge != null)
                oneUpdate[18].Value = model.NurseInCharge;
            else
                oneUpdate[18].Value = DBNull.Value;
            if (model.OperatingDate != null)
                oneUpdate[19].Value = model.OperatingDate;
            else
                oneUpdate[19].Value = DBNull.Value;
            if (model.BillingDateTime != null)
                oneUpdate[20].Value = model.BillingDateTime;
            else
                oneUpdate[20].Value = DBNull.Value;
            if (model.Prepayments != null)
                oneUpdate[21].Value = model.Prepayments;
            else
                oneUpdate[21].Value = DBNull.Value;
            if (model.TotalCosts != null)
                oneUpdate[22].Value = model.TotalCosts;
            else
                oneUpdate[22].Value = DBNull.Value;
            if (model.TotalCharges != null)
                oneUpdate[23].Value = model.TotalCharges;
            else
                oneUpdate[23].Value = DBNull.Value;
            if (model.Guarantor != null)
                oneUpdate[24].Value = model.Guarantor;
            else
                oneUpdate[24].Value = DBNull.Value;
            if (model.GuarantorOrg != null)
                oneUpdate[25].Value = model.GuarantorOrg;
            else
                oneUpdate[25].Value = DBNull.Value;
            if (model.GuarantorPhoneNum != null)
                oneUpdate[26].Value = model.GuarantorPhoneNum;
            else
                oneUpdate[26].Value = DBNull.Value;
            if (model.BillCheckedDateTime != null)
                oneUpdate[27].Value = model.BillCheckedDateTime;
            else
                oneUpdate[27].Value = DBNull.Value;
            if (model.SettledIndicator != null)
                oneUpdate[28].Value = model.SettledIndicator;
            else
                oneUpdate[28].Value = DBNull.Value;
            if (model.Reserved01 != null)
                oneUpdate[29].Value = model.Reserved01;
            else
                oneUpdate[29].Value = DBNull.Value;
            if (model.Reserved02 != null)
                oneUpdate[30].Value = model.Reserved02;
            else
                oneUpdate[30].Value = DBNull.Value;
            if (model.Reserved03 != null)
                oneUpdate[31].Value = model.Reserved03;
            else
                oneUpdate[31].Value = DBNull.Value;
            if (model.ReservedDate01 != null)
                oneUpdate[32].Value = model.ReservedDate01;
            else
                oneUpdate[32].Value = DBNull.Value;
            if (model.ReservedDate02 != null)
                oneUpdate[33].Value = model.ReservedDate02;
            else
                oneUpdate[33].Value = DBNull.Value;
            if (model.PatientId != null)
                oneUpdate[34].Value = model.PatientId;
            else
                oneUpdate[34].Value = DBNull.Value;
 

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, Update_SQL, oneUpdate);
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedPatsInHospital 
        ///Delete Table MED_PATS_IN_HOSPITAL by (string PATIENT_ID)
        /// </summary>
        public int DeleteMedPatsInHospitalSQL(string PATIENT_ID, System.Data.Common.DbTransaction oleCisTrans)
        {
            SqlParameter[] oneDelete = GetParameterSQL("DeleteMedPatsInHospital");
            if (PATIENT_ID != null)
                oneDelete[0].Value = PATIENT_ID;
            else
                oneDelete[0].Value = DBNull.Value;

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_PATS_IN_HOSPITAL_Delete_SQL, oneDelete);

        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedPatsInHospital 
        ///select Table MED_PATS_IN_HOSPITAL by (string PATIENT_ID)
        /// </summary>
        public MedPatsInHospital SelectMedPatsInHospitalSQL(string PATIENT_ID, System.Data.Common.DbConnection oleCisConn)
        {
            MedPatsInHospital model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedPatsInHospital");
            parameterValues[0].Value = PATIENT_ID;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, Select_SQL, parameterValues))
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
        public List<MedPatsInHospital> SelectMedPatsInHospitalListSQL(System.Data.Common.DbConnection oleCisConn)
        {
            List<MedPatsInHospital> modelList = new List<MedPatsInHospital>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_PATS_IN_HOSPITAL_Select_ALL_SQL, null))
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
        public List<Model.MedPatsInHospital> SelectDeptMedPatsInHospitalSQL(string wardCode, System.Data.Common.DbConnection oleCisConn)
        {
            List<Model.MedPatsInHospital> deptMedPatsInHospital = new List<Model.MedPatsInHospital>();

            SqlParameter[] mdPatsInHospital = GetParameterSQL("SelectDeptMedPatsInHospital");
            mdPatsInHospital[0].Value = wardCode;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_PATS_IN_HOSPITAL_Select_Dept_SQL, mdPatsInHospital))
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

        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedPatsInHospital 
        ///Insert Table MED_PATS_IN_HOSPITAL
        /// </summary>
        public int InsertMedPatsInHospital(MedPatsInHospital model, System.Data.Common.DbTransaction oleCisTrans)
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


            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, Insert, oneInert);

        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedPatsInHospital 
        ///Update Table     MED_PATS_IN_HOSPITAL
        /// </summary>
        public int UpdateMedPatsInHospital(MedPatsInHospital model, System.Data.Common.DbTransaction oleCisTrans)
        {
            OracleParameter[] oneUpdate = GetParameter("UpdateMedPatsInHospital");
            if (model.InpNo != null)
                oneUpdate[0].Value = model.InpNo;
            else
                oneUpdate[0].Value = DBNull.Value;
            if (model.VisitId != null)
                oneUpdate[1].Value = model.VisitId;
            else
                oneUpdate[1].Value = DBNull.Value;
            if (model.PatientSource != null)
                oneUpdate[2].Value = model.PatientSource;
            else
                oneUpdate[2].Value = DBNull.Value;
            if (model.HospBranch != null)
                oneUpdate[3].Value = model.HospBranch;
            else
                oneUpdate[3].Value = DBNull.Value;
            if (model.DepId != null)
                oneUpdate[4].Value = model.DepId;
            else
                oneUpdate[4].Value = DBNull.Value;
            if (model.WardCode != null)
                oneUpdate[5].Value = model.WardCode;
            else
                oneUpdate[5].Value = DBNull.Value;
            if (model.DeptCode != null)
                oneUpdate[6].Value = model.DeptCode;
            else
                oneUpdate[6].Value = DBNull.Value;
            if (model.BedNo != null)
                oneUpdate[7].Value = model.BedNo;
            else
                oneUpdate[7].Value = DBNull.Value;
            if (model.AdmissionDateTime != null)
                oneUpdate[8].Value = model.AdmissionDateTime;
            else
                oneUpdate[8].Value = DBNull.Value;
            if (model.AdmWardDateTime != null)
                oneUpdate[9].Value = model.AdmWardDateTime;
            else
                oneUpdate[9].Value = DBNull.Value;
            if (model.Diagnosis != null)
                oneUpdate[10].Value = model.Diagnosis;
            else
                oneUpdate[10].Value = DBNull.Value;
            if (model.PatientCondition != null)
                oneUpdate[11].Value = model.PatientCondition;
            else
                oneUpdate[11].Value = DBNull.Value;
            if (model.BloodType != null)
                oneUpdate[12].Value = model.BloodType;
            else
                oneUpdate[12].Value = DBNull.Value;
            if (model.BloodTypeRh != null)
                oneUpdate[13].Value = model.BloodTypeRh;
            else
                oneUpdate[13].Value = DBNull.Value;
            if (model.BodyHeight != null)
                oneUpdate[14].Value = model.BodyHeight;
            else
                oneUpdate[14].Value = DBNull.Value;
            if (model.BodyWeight != null)
                oneUpdate[15].Value = model.BodyWeight;
            else
                oneUpdate[15].Value = DBNull.Value;
            if (model.NursingClass != null)
                oneUpdate[16].Value = model.NursingClass;
            else
                oneUpdate[16].Value = DBNull.Value;
            if (model.DoctorInCharge != null)
                oneUpdate[17].Value = model.DoctorInCharge;
            else
                oneUpdate[17].Value = DBNull.Value;
            if (model.NurseInCharge != null)
                oneUpdate[18].Value = model.NurseInCharge;
            else
                oneUpdate[18].Value = DBNull.Value;
            if (model.OperatingDate != null)
                oneUpdate[19].Value = model.OperatingDate;
            else
                oneUpdate[19].Value = DBNull.Value;
            if (model.BillingDateTime != null)
                oneUpdate[20].Value = model.BillingDateTime;
            else
                oneUpdate[20].Value = DBNull.Value;
            if (model.Prepayments != null)
                oneUpdate[21].Value = model.Prepayments;
            else
                oneUpdate[21].Value = DBNull.Value;
            if (model.TotalCosts != null)
                oneUpdate[22].Value = model.TotalCosts;
            else
                oneUpdate[22].Value = DBNull.Value;
            if (model.TotalCharges != null)
                oneUpdate[23].Value = model.TotalCharges;
            else
                oneUpdate[23].Value = DBNull.Value;
            if (model.Guarantor != null)
                oneUpdate[24].Value = model.Guarantor;
            else
                oneUpdate[24].Value = DBNull.Value;
            if (model.GuarantorOrg != null)
                oneUpdate[25].Value = model.GuarantorOrg;
            else
                oneUpdate[25].Value = DBNull.Value;
            if (model.GuarantorPhoneNum != null)
                oneUpdate[26].Value = model.GuarantorPhoneNum;
            else
                oneUpdate[26].Value = DBNull.Value;
            if (model.BillCheckedDateTime != null)
                oneUpdate[27].Value = model.BillCheckedDateTime;
            else
                oneUpdate[27].Value = DBNull.Value;
            if (model.SettledIndicator != null)
                oneUpdate[28].Value = model.SettledIndicator;
            else
                oneUpdate[28].Value = DBNull.Value;
            if (model.Reserved01 != null)
                oneUpdate[29].Value = model.Reserved01;
            else
                oneUpdate[29].Value = DBNull.Value;
            if (model.Reserved02 != null)
                oneUpdate[30].Value = model.Reserved02;
            else
                oneUpdate[30].Value = DBNull.Value;
            if (model.Reserved03 != null)
                oneUpdate[31].Value = model.Reserved03;
            else
                oneUpdate[31].Value = DBNull.Value;
            if (model.ReservedDate01 != null)
                oneUpdate[32].Value = model.ReservedDate01;
            else
                oneUpdate[32].Value = DBNull.Value;
            if (model.ReservedDate02 != null)
                oneUpdate[33].Value = model.ReservedDate02;
            else
                oneUpdate[33].Value = DBNull.Value;
            if (model.PatientId != null)
                oneUpdate[34].Value = model.PatientId;
            else
                oneUpdate[34].Value = DBNull.Value;
 
            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, Update, oneUpdate);

        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedPatsInHospital 
        ///Delete Table MED_PATS_IN_HOSPITAL by (string PATIENT_ID)
        /// </summary>
        public int DeleteMedPatsInHospital(string PATIENT_ID, System.Data.Common.DbTransaction oleCisTrans)
        {
            OracleParameter[] oneDelete = GetParameter("DeleteMedPatsInHospital");
            if (PATIENT_ID != null)
                oneDelete[0].Value = PATIENT_ID;
            else
                oneDelete[0].Value = DBNull.Value;

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_PATS_IN_HOSPITAL_Delete, oneDelete);

        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedPatsInHospital 
        ///select Table MED_PATS_IN_HOSPITAL by (string PATIENT_ID)
        /// </summary>
        public MedPatsInHospital SelectMedPatsInHospital(string PATIENT_ID, System.Data.Common.DbConnection oleCisConn)
        {
            MedPatsInHospital model;
            OracleParameter[] parameterValues = GetParameter("SelectMedPatsInHospital");
            parameterValues[0].Value = PATIENT_ID;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, Select, parameterValues))
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
        public List<MedPatsInHospital> SelectMedPatsInHospitalList(System.Data.Common.DbConnection oleCisConn)
        {
            List<MedPatsInHospital> modelList = new List<MedPatsInHospital>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_PATS_IN_HOSPITAL_Select_ALL, null))
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
        public List<Model.MedPatsInHospital> SelectDeptMedPatsInHospital(string wardCode, System.Data.Common.DbConnection oleCisConn)
        {
            List<Model.MedPatsInHospital> deptMedPatsInHospital = new List<Model.MedPatsInHospital>();

            OracleParameter[] mdPatsInHospital = GetParameter("SelectDeptMedPatsInHospital");
            mdPatsInHospital[0].Value = wardCode;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_PATS_IN_HOSPITAL_Select_Dept, mdPatsInHospital))
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
