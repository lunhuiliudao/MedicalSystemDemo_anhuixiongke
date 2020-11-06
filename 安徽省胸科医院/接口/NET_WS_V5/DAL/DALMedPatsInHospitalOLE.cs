using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Data.Odbc;
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

        private static string Select_OLE="select PATIENT_ID_PK,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02 from MED_PATS_IN_HOSPITAL WHERE PATIENT_ID=?";


        private static string Update_OLE = "Update MED_PATS_IN_HOSPITAL set INP_NO=?,PATIENT_SOURCE=?,HOSP_BRANCH=?,DEP_ID=?,WARD_CODE=?,DEPT_CODE=?,BED_NO=?,ADMISSION_DATE_TIME=?,ADM_WARD_DATE_TIME=?,DIAGNOSIS=?,PATIENT_CONDITION=?,BLOOD_TYPE=?,BLOOD_TYPE_RH=?,BODY_HEIGHT=?,BODY_WEIGHT=?,NURSING_CLASS=?,DOCTOR_IN_CHARGE=?,NURSE_IN_CHARGE=?,OPERATING_DATE=?,BILLING_DATE_TIME=?,PREPAYMENTS=?,TOTAL_COSTS=?,TOTAL_CHARGES=?,GUARANTOR=?,GUARANTOR_ORG=?,GUARANTOR_PHONE_NUM=?,BILL_CHECKED_DATE_TIME=?,SETTLED_INDICATOR=?,RESERVED01=?,RESERVED02=?,RESERVED03=?,RESERVED_DATE01=?,RESERVED_DATE02=? where PATIENT_ID=? and VISIT_ID=?";
 

        private static string Insert_OLE = "Insert into MED_PATS_IN_HOSPITAL  (PATIENT_ID,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";


        private static readonly string Select_MedPatsInHospital_OLE = "SELECT PATIENT_ID_PK,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02 FROM MED_PATS_IN_HOSPITAL WHERE PATIENT_ID = ?";
        private static readonly string Select_DeptMedPatsInHospital_OLE = "SELECT PATIENT_ID_PK,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02 FROM MED_PATS_IN_HOSPITAL WHERE ward_code = ? ";
        private static readonly string Select_ReservedMedPatsInHospital_OLE = "SELECT PATIENT_ID_PK,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02 FROM MED_PATS_IN_HOSPITAL WHERE reserved01 = ? AND reserved02 = ?";
         //  private static readonly string Insert_MedPatsInHospital_OLE = "INSERT INTO MED_PATS_IN_HOSPITAL(patient_id,visit_id,ward_code,dept_code,bed_no,admission_date_time,adm_ward_date_time,diagnosis,patient_condition,nursing_class,prepayments,total_costs,total_charges,doctor_in_charge,reserved01,reserved02,reserved03,operating_date,dep_id) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?) ";
        //   private static readonly string Update_MedPatsInHospital_OLE = "UPDATE MED_PATS_IN_HOSPITAL SET  VISIT_ID = ?, ward_code = ?,dept_code = ?,bed_no = ?,admission_date_time = ?,adm_ward_date_time = ?,diagnosis = ?,patient_condition = ?,nursing_class = ?,prepayments = ?,total_costs = ?,total_charges = ?,doctor_in_charge = ?,reserved01 = ?, reserved02 = ?, reserved03 = ?,operating_date = ?,dep_id = ? WHERE PATIENT_ID = ?";
        private static readonly string Delete_MedPatsInhospital_OLE = "DELETE MED_PATS_IN_HOSPITAL WHERE PATIENT_ID = ?";




        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedPatsInHospital" || sqlParms == "DeleteMedPatsInHospital")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar)
                    };

                }
                else
                {
                    if (sqlParms == "InsertMedPatsInHospital")
                    {
                        parms = new OleDbParameter[]{
                            new OleDbParameter("PatientId",OleDbType.VarChar),
                            new OleDbParameter("InpNo",OleDbType.VarChar),
                            new OleDbParameter("VisitId",OleDbType.Decimal),
                            new OleDbParameter("PatientSource",OleDbType.Decimal),
                            new OleDbParameter("HospBranch",OleDbType.VarChar),
                            new OleDbParameter("DepId",OleDbType.Decimal),
                            new OleDbParameter("WardCode",OleDbType.VarChar),
                            new OleDbParameter("DeptCode",OleDbType.VarChar),
                            new OleDbParameter("BedNo",OleDbType.VarChar),
                            new OleDbParameter("AdmissionDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter("AdmWardDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter("Diagnosis",OleDbType.VarChar),
                            new OleDbParameter("PatientCondition",OleDbType.VarChar),
                            new OleDbParameter("BloodType",OleDbType.VarChar),
                            new OleDbParameter("BloodTypeRh",OleDbType.VarChar),
                            new OleDbParameter("BodyHeight",OleDbType.Decimal),
                            new OleDbParameter("BodyWeight",OleDbType.Decimal),
                            new OleDbParameter("NursingClass",OleDbType.VarChar),
                            new OleDbParameter("DoctorInCharge",OleDbType.VarChar),
                            new OleDbParameter("NurseInCharge",OleDbType.VarChar),
                            new OleDbParameter("OperatingDate",OleDbType.DBTimeStamp),
                            new OleDbParameter("BillingDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter("Prepayments",OleDbType.Decimal),
                            new OleDbParameter("TotalCosts",OleDbType.Decimal),
                            new OleDbParameter("TotalCharges",OleDbType.Decimal),
                            new OleDbParameter("Guarantor",OleDbType.VarChar),
                            new OleDbParameter("GuarantorOrg",OleDbType.VarChar),
                            new OleDbParameter("GuarantorPhoneNum",OleDbType.VarChar),
                            new OleDbParameter("BillCheckedDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter("SettledIndicator",OleDbType.Decimal),
                            new OleDbParameter("Reserved01",OleDbType.VarChar),
                            new OleDbParameter("Reserved02",OleDbType.VarChar),
                            new OleDbParameter("Reserved03",OleDbType.VarChar),
                            new OleDbParameter("ReservedDate01",OleDbType.DBTimeStamp),
                            new OleDbParameter("ReservedDate02",OleDbType.DBTimeStamp),
                        };
                    }
                    else if (sqlParms == "UpdateMedPatsInHospital")
                    {
                        parms = new OleDbParameter[]{
                            new OleDbParameter("InpNo",OleDbType.VarChar),
                        
                            new OleDbParameter("PatientSource",OleDbType.Decimal),
                            new OleDbParameter("HospBranch",OleDbType.VarChar),
                            new OleDbParameter("DepId",OleDbType.Decimal),
                            new OleDbParameter("WardCode",OleDbType.VarChar),
                            new OleDbParameter("DeptCode",OleDbType.VarChar),
                            new OleDbParameter("BedNo",OleDbType.VarChar),
                            new OleDbParameter("AdmissionDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter("AdmWardDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter("Diagnosis",OleDbType.VarChar),
                            new OleDbParameter("PatientCondition",OleDbType.VarChar),
                            new OleDbParameter("BloodType",OleDbType.VarChar),
                            new OleDbParameter("BloodTypeRh",OleDbType.VarChar),
                            new OleDbParameter("BodyHeight",OleDbType.Decimal),
                            new OleDbParameter("BodyWeight",OleDbType.Decimal),
                            new OleDbParameter("NursingClass",OleDbType.VarChar),
                            new OleDbParameter("DoctorInCharge",OleDbType.VarChar),
                            new OleDbParameter("NurseInCharge",OleDbType.VarChar),
                            new OleDbParameter("OperatingDate",OleDbType.DBTimeStamp),
                            new OleDbParameter("BillingDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter("Prepayments",OleDbType.Decimal),
                            new OleDbParameter("TotalCosts",OleDbType.Decimal),
                            new OleDbParameter("TotalCharges",OleDbType.Decimal),
                            new OleDbParameter("Guarantor",OleDbType.VarChar),
                            new OleDbParameter("GuarantorOrg",OleDbType.VarChar),
                            new OleDbParameter("GuarantorPhoneNum",OleDbType.VarChar),
                            new OleDbParameter("BillCheckedDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter("SettledIndicator",OleDbType.Decimal),
                            new OleDbParameter("Reserved01",OleDbType.VarChar),
                            new OleDbParameter("Reserved02",OleDbType.VarChar),
                            new OleDbParameter("Reserved03",OleDbType.VarChar),
                            new OleDbParameter("ReservedDate01",OleDbType.DBTimeStamp),
                            new OleDbParameter("ReservedDate02",OleDbType.DBTimeStamp),
                            new OleDbParameter("PatientId",OleDbType.VarChar),
                            new OleDbParameter("VisitId",OleDbType.Decimal),
                            
                        };
                    }
                    else if (sqlParms == "SelectDeptMedPatsInHospital")
                    {
                        parms = new OleDbParameter[]{
                            new OleDbParameter("wardCode",OleDbType.VarChar)
                        };
                    }
                    else if (sqlParms == "SelectReservedMedPatsInHospital")
                    {
                        parms = new OleDbParameter[]{
                            new OleDbParameter("reserved01",OleDbType.VarChar),
                            new OleDbParameter("reserved02",OleDbType.VarChar)
                        };
                    }
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public List<Model.MedPatsInHospital> SelectDeptMedPatsInHospitalOLE(string wardCode)
        {
            List<Model.MedPatsInHospital> deptMedPatsInHospital = new List<Model.MedPatsInHospital>();

            OleDbParameter[] mdPatsInHospital = GetParameterOLE("SelectDeptMedPatsInHospital");
            mdPatsInHospital[0].Value = wardCode;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_DeptMedPatsInHospital_OLE, mdPatsInHospital))
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

        public List<Model.MedPatsInHospital> SelectReservedMedPatsInHospitalOLE(string reserved01, string reserved02)
        {
            List<Model.MedPatsInHospital> deptMedPatsInHospital = new List<Model.MedPatsInHospital>();

            OleDbParameter[] mdPatsInHospital = GetParameterOLE("SelectReservedMedPatsInHospital");
            mdPatsInHospital[0].Value = reserved01;
            mdPatsInHospital[1].Value = reserved02;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_ReservedMedPatsInHospital_OLE, mdPatsInHospital))
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

        public Model.MedPatsInHospital SelectMedPatsInHospitalOLE(string patientId)
        {
            Model.MedPatsInHospital model = null;

            OleDbParameter[] mdPatsInHospital = GetParameterOLE("SelectMedPatsInHospital");
            mdPatsInHospital[0].Value = patientId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedPatsInHospital_OLE, mdPatsInHospital))
            {
                if (oleReader.Read())
                {
                    model = new Model.MedPatsInHospital();
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

        public int InsertMedPatsInHospitalOLE(Model.MedPatsInHospital model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedPatsInHospital");
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

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_OLE, oneInert);
            }
        }

        public int UpdateMedPatsInHospitalOLE(Model.MedPatsInHospital model)
        {
            using (OleDbConnection oleCisConn1 = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedPatsInHospital");
               
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

                return OleDbHelper.ExecuteNonQuery(oleCisConn1, CommandType.Text, Update_OLE, oneUpdate);
            }
        }

        public int DeleteMedPatsInHospitalOLE(Model.MedPatsInHospital MedPatsInHospital)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedPatsInHospital");
                oneDelete[0].Value = MedPatsInHospital.PatientId;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Delete_MedPatsInhospital_OLE, oneDelete);
            }
        }

        private static string Select_ODBC="select PATIENT_ID_PK,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02 from MED_PATS_IN_HOSPITAL WHERE PATIENT_ID=?";


        private static string Update_ODBC="Update MED_PATS_IN_HOSPITAL set INP_NO=?,VISIT_ID=?,PATIENT_SOURCE=?,HOSP_BRANCH=?,DEP_ID=?,WARD_CODE=?,DEPT_CODE=?,BED_NO=?,ADMISSION_DATE_TIME=?,ADM_WARD_DATE_TIME=?,DIAGNOSIS=?,PATIENT_CONDITION=?,BLOOD_TYPE=?,BLOOD_TYPE_RH=?,BODY_HEIGHT=?,BODY_WEIGHT=?,NURSING_CLASS=?,DOCTOR_IN_CHARGE=?,NURSE_IN_CHARGE=?,OPERATING_DATE=?,BILLING_DATE_TIME=?,PREPAYMENTS=?,TOTAL_COSTS=?,TOTAL_CHARGES=?,GUARANTOR=?,GUARANTOR_ORG=?,GUARANTOR_PHONE_NUM=?,BILL_CHECKED_DATE_TIME=?,SETTLED_INDICATOR=?,RESERVED01=?,RESERVED02=?,RESERVED03=?,RESERVED_DATE01=?,RESERVED_DATE02=? where PATIENT_ID=?";


        private static string Insert_ODBC = "Insert into MED_PATS_IN_HOSPITAL  (PATIENT_ID,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

        private static readonly string Select_MedPatsInHospital_Odbc = "SELECT PATIENT_ID_PK,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02 FROM MED_PATS_IN_HOSPITAL WHERE PATIENT_ID = ?";
        private static readonly string Select_DeptMedPatsInHospital_Odbc = "SELECT PATIENT_ID_PK,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02 FROM MED_PATS_IN_HOSPITAL WHERE ward_code = ? ";
        private static readonly string Select_ReservedMedPatsInHospital_Odbc = "SELECT PATIENT_ID_PK,INP_NO,VISIT_ID,PATIENT_SOURCE,HOSP_BRANCH,DEP_ID,WARD_CODE,DEPT_CODE,BED_NO,ADMISSION_DATE_TIME,ADM_WARD_DATE_TIME,DIAGNOSIS,PATIENT_CONDITION,BLOOD_TYPE,BLOOD_TYPE_RH,BODY_HEIGHT,BODY_WEIGHT,NURSING_CLASS,DOCTOR_IN_CHARGE,NURSE_IN_CHARGE,OPERATING_DATE,BILLING_DATE_TIME,PREPAYMENTS,TOTAL_COSTS,TOTAL_CHARGES,GUARANTOR,GUARANTOR_ORG,GUARANTOR_PHONE_NUM,BILL_CHECKED_DATE_TIME,SETTLED_INDICATOR,RESERVED01,RESERVED02,RESERVED03,RESERVED_DATE01,RESERVED_DATE02 FROM MED_PATS_IN_HOSPITAL WHERE reserved01 = ? AND reserved02 = ?";
        //private static readonly string Insert_MedPatsInHospital_Odbc = "INSERT INTO MED_PATS_IN_HOSPITAL(patient_id,visit_id,ward_code,dept_code,bed_no,admission_date_time,adm_ward_date_time,diagnosis,patient_condition,nursing_class,prepayments,total_costs,total_charges,doctor_in_charge,reserved01,reserved02,reserved03,operating_date,dep_id) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?) ";
        //private static readonly string Update_MedPatsInHospital_Odbc = "UPDATE MED_PATS_IN_HOSPITAL SET  VISIT_ID = ?,ward_code = ?,dept_code = ?,bed_no = ?,admission_date_time = ?,adm_ward_date_time = ?,diagnosis = ?,patient_condition = ?,nursing_class = ?,prepayments = ?,total_costs = ?,total_charges = ?,doctor_in_charge = ?,reserved01 = ?, reserved02 = ?, reserved03 = ?,operating_date = ?,dep_id =? WHERE PATIENT_ID = ?";
        private static readonly string Delete_MedPatsInhospital_Odbc = "DELETE MED_PATS_IN_HOSPITAL WHERE PATIENT_ID = ?";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedPatsInHospital" || sqlParms == "DeleteMedPatsInHospital")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar)
                    };

                }
                else
                {
                    if (sqlParms == "InsertMedPatsInHospital")
                    {
                        parms = new OdbcParameter[]{
                            new OdbcParameter("PatientId",OdbcType.VarChar),
                            new OdbcParameter("InpNo",OdbcType.VarChar),
                            new OdbcParameter("VisitId",OdbcType.Decimal),
                            new OdbcParameter("PatientSource",OdbcType.Decimal),
                            new OdbcParameter("HospBranch",OdbcType.VarChar),
                            new OdbcParameter("DepId",OdbcType.Decimal),
                            new OdbcParameter("WardCode",OdbcType.VarChar),
                            new OdbcParameter("DeptCode",OdbcType.VarChar),
                            new OdbcParameter("BedNo",OdbcType.VarChar),
                            new OdbcParameter("AdmissionDateTime",OdbcType.DateTime),
                            new OdbcParameter("AdmWardDateTime",OdbcType.DateTime),
                            new OdbcParameter("Diagnosis",OdbcType.VarChar),
                            new OdbcParameter("PatientCondition",OdbcType.VarChar),
                            new OdbcParameter("BloodType",OdbcType.VarChar),
                            new OdbcParameter("BloodTypeRh",OdbcType.VarChar),
                            new OdbcParameter("BodyHeight",OdbcType.Decimal),
                            new OdbcParameter("BodyWeight",OdbcType.Decimal),
                            new OdbcParameter("NursingClass",OdbcType.VarChar),
                            new OdbcParameter("DoctorInCharge",OdbcType.VarChar),
                            new OdbcParameter("NurseInCharge",OdbcType.VarChar),
                            new OdbcParameter("OperatingDate",OdbcType.DateTime),
                            new OdbcParameter("BillingDateTime",OdbcType.DateTime),
                            new OdbcParameter("Prepayments",OdbcType.Decimal),
                            new OdbcParameter("TotalCosts",OdbcType.Decimal),
                            new OdbcParameter("TotalCharges",OdbcType.Decimal),
                            new OdbcParameter("Guarantor",OdbcType.VarChar),
                            new OdbcParameter("GuarantorOrg",OdbcType.VarChar),
                            new OdbcParameter("GuarantorPhoneNum",OdbcType.VarChar),
                            new OdbcParameter("BillCheckedDateTime",OdbcType.DateTime),
                            new OdbcParameter("SettledIndicator",OdbcType.Decimal),
                            new OdbcParameter("Reserved01",OdbcType.VarChar),
                            new OdbcParameter("Reserved02",OdbcType.VarChar),
                            new OdbcParameter("Reserved03",OdbcType.VarChar),
                            new OdbcParameter("ReservedDate01",OdbcType.DateTime),
                            new OdbcParameter("ReservedDate02",OdbcType.DateTime),
                        };
                    }
                    else if (sqlParms == "UpdateMedPatsInHospital")
                    {
                        parms = new OdbcParameter[]{
                            new OdbcParameter("InpNo",OdbcType.VarChar),
                            new OdbcParameter("VisitId",OdbcType.Decimal),
                            new OdbcParameter("PatientSource",OdbcType.Decimal),
                            new OdbcParameter("HospBranch",OdbcType.VarChar),
                            new OdbcParameter("DepId",OdbcType.Decimal),
                            new OdbcParameter("WardCode",OdbcType.VarChar),
                            new OdbcParameter("DeptCode",OdbcType.VarChar),
                            new OdbcParameter("BedNo",OdbcType.VarChar),
                            new OdbcParameter("AdmissionDateTime",OdbcType.DateTime),
                            new OdbcParameter("AdmWardDateTime",OdbcType.DateTime),
                            new OdbcParameter("Diagnosis",OdbcType.VarChar),
                            new OdbcParameter("PatientCondition",OdbcType.VarChar),
                            new OdbcParameter("BloodType",OdbcType.VarChar),
                            new OdbcParameter("BloodTypeRh",OdbcType.VarChar),
                            new OdbcParameter("BodyHeight",OdbcType.Decimal),
                            new OdbcParameter("BodyWeight",OdbcType.Decimal),
                            new OdbcParameter("NursingClass",OdbcType.VarChar),
                            new OdbcParameter("DoctorInCharge",OdbcType.VarChar),
                            new OdbcParameter("NurseInCharge",OdbcType.VarChar),
                            new OdbcParameter("OperatingDate",OdbcType.DateTime),
                            new OdbcParameter("BillingDateTime",OdbcType.DateTime),
                            new OdbcParameter("Prepayments",OdbcType.Decimal),
                            new OdbcParameter("TotalCosts",OdbcType.Decimal),
                            new OdbcParameter("TotalCharges",OdbcType.Decimal),
                            new OdbcParameter("Guarantor",OdbcType.VarChar),
                            new OdbcParameter("GuarantorOrg",OdbcType.VarChar),
                            new OdbcParameter("GuarantorPhoneNum",OdbcType.VarChar),
                            new OdbcParameter("BillCheckedDateTime",OdbcType.DateTime),
                            new OdbcParameter("SettledIndicator",OdbcType.Decimal),
                            new OdbcParameter("Reserved01",OdbcType.VarChar),
                            new OdbcParameter("Reserved02",OdbcType.VarChar),
                            new OdbcParameter("Reserved03",OdbcType.VarChar),
                            new OdbcParameter("ReservedDate01",OdbcType.DateTime),
                            new OdbcParameter("ReservedDate02",OdbcType.DateTime),
                            new OdbcParameter("PatientId",OdbcType.VarChar),
                        };
                    }
                    else if (sqlParms == "SelectDeptMedPatsInHospital")
                    {
                        parms = new OdbcParameter[]{
                            new OdbcParameter("wardCode",OdbcType.VarChar)
                        };
                    }
                    else if (sqlParms == "SelectReservedMedPatsInHospital")
                    {
                        parms = new OdbcParameter[]{
                            new OdbcParameter("reserved01",OdbcType.VarChar),
                            new OdbcParameter("reserved02",OdbcType.VarChar)
                        };
                    }
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public List<Model.MedPatsInHospital> SelectDeptMedPatsInHospitalOdbc(string wardCode)
        {
            List<Model.MedPatsInHospital> deptMedPatsInHospital = new List<Model.MedPatsInHospital>();

            OdbcParameter[] mdPatsInHospital = GetParameterOdbc("SelectDeptMedPatsInHospital");
            mdPatsInHospital[0].Value = wardCode;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_DeptMedPatsInHospital_Odbc, mdPatsInHospital))
            {
                while (oleReader.Read())
                {
                    Model.MedPatsInHospital model = new Model.MedPatsInHospital();
                    if (!oleReader.IsDBNull(0))
                        {
                        model.PatientId=oleReader["PATIENT_ID"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(1))
                        {
                        model.InpNo=oleReader["INP_NO"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(2))
                        {
                        model.VisitId=decimal.Parse(oleReader["VISIT_ID"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(3))
                        {
                        model.PatientSource=decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(4))
                        {
                        model.HospBranch=oleReader["HOSP_BRANCH"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(5))
                        {
                        model.DepId=decimal.Parse(oleReader["DEP_ID"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(6))
                        {
                        model.WardCode=oleReader["WARD_CODE"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(7))
                        {
                        model.DeptCode=oleReader["DEPT_CODE"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(8))
                        {
                        model.BedNo=oleReader["BED_NO"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(9))
                        {
                        model.AdmissionDateTime=DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(10))
                        {
                        model.AdmWardDateTime=DateTime.Parse(oleReader["ADM_WARD_DATE_TIME"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(11))
                        {
                        model.Diagnosis=oleReader["DIAGNOSIS"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(12))
                        {
                        model.PatientCondition=oleReader["PATIENT_CONDITION"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(13))
                        {
                        model.BloodType=oleReader["BLOOD_TYPE"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(14))
                        {
                        model.BloodTypeRh=oleReader["BLOOD_TYPE_RH"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(15))
                        {
                        model.BodyHeight=decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(16))
                        {
                        model.BodyWeight=decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(17))
                        {
                        model.NursingClass=oleReader["NURSING_CLASS"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(18))
                        {
                        model.DoctorInCharge=oleReader["DOCTOR_IN_CHARGE"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(19))
                        {
                        model.NurseInCharge=oleReader["NURSE_IN_CHARGE"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(20))
                        {
                        model.OperatingDate=DateTime.Parse(oleReader["OPERATING_DATE"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(21))
                        {
                        model.BillingDateTime=DateTime.Parse(oleReader["BILLING_DATE_TIME"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(22))
                        {
                        model.Prepayments=decimal.Parse(oleReader["PREPAYMENTS"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(23))
                        {
                        model.TotalCosts=decimal.Parse(oleReader["TOTAL_COSTS"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(24))
                        {
                        model.TotalCharges=decimal.Parse(oleReader["TOTAL_CHARGES"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(25))
                        {
                        model.Guarantor=oleReader["GUARANTOR"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(26))
                        {
                        model.GuarantorOrg=oleReader["GUARANTOR_ORG"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(27))
                        {
                        model.GuarantorPhoneNum=oleReader["GUARANTOR_PHONE_NUM"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(28))
                        {
                        model.BillCheckedDateTime=DateTime.Parse(oleReader["BILL_CHECKED_DATE_TIME"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(29))
                        {
                        model.SettledIndicator=decimal.Parse(oleReader["SETTLED_INDICATOR"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(30))
                        {
                        model.Reserved01=oleReader["RESERVED01"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(31))
                        {
                        model.Reserved02=oleReader["RESERVED02"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(32))
                        {
                        model.Reserved03=oleReader["RESERVED03"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(33))
                        {
                        model.ReservedDate01=DateTime.Parse(oleReader["RESERVED_DATE01"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(34))
                        {
                        model.ReservedDate02=DateTime.Parse(oleReader["RESERVED_DATE02"].ToString().Trim());
                        }
                    deptMedPatsInHospital.Add(model);
                }
            }
            return deptMedPatsInHospital;
        }

        public List<Model.MedPatsInHospital> SelectReservedMedPatsInHospitalOdbc(string reserved01, string reserved02)
        {
            List<Model.MedPatsInHospital> deptMedPatsInHospital = new List<Model.MedPatsInHospital>();

            OdbcParameter[] mdPatsInHospital = GetParameterOdbc("SelectReservedMedPatsInHospital");
            mdPatsInHospital[0].Value = reserved01;
            mdPatsInHospital[1].Value = reserved02;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_ReservedMedPatsInHospital_Odbc, mdPatsInHospital))
            {
                while (oleReader.Read())
                {
                    Model.MedPatsInHospital model = new Model.MedPatsInHospital();
                   if (!oleReader.IsDBNull(0))
                    {
                    model.PatientId=oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                    model.InpNo=oleReader["INP_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                    model.VisitId=decimal.Parse(oleReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                    model.PatientSource=decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                    model.HospBranch=oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                    model.DepId=decimal.Parse(oleReader["DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                    model.WardCode=oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                    model.DeptCode=oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                    model.BedNo=oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                    model.AdmissionDateTime=DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                    model.AdmWardDateTime=DateTime.Parse(oleReader["ADM_WARD_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                    model.Diagnosis=oleReader["DIAGNOSIS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                    model.PatientCondition=oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                    model.BloodType=oleReader["BLOOD_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                    model.BloodTypeRh=oleReader["BLOOD_TYPE_RH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                    model.BodyHeight=decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                    model.BodyWeight=decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                    model.NursingClass=oleReader["NURSING_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                    model.DoctorInCharge=oleReader["DOCTOR_IN_CHARGE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                    model.NurseInCharge=oleReader["NURSE_IN_CHARGE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                    model.OperatingDate=DateTime.Parse(oleReader["OPERATING_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                    model.BillingDateTime=DateTime.Parse(oleReader["BILLING_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                    model.Prepayments=decimal.Parse(oleReader["PREPAYMENTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                    model.TotalCosts=decimal.Parse(oleReader["TOTAL_COSTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                    model.TotalCharges=decimal.Parse(oleReader["TOTAL_CHARGES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                    model.Guarantor=oleReader["GUARANTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                    model.GuarantorOrg=oleReader["GUARANTOR_ORG"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                    model.GuarantorPhoneNum=oleReader["GUARANTOR_PHONE_NUM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                    model.BillCheckedDateTime=DateTime.Parse(oleReader["BILL_CHECKED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                    model.SettledIndicator=decimal.Parse(oleReader["SETTLED_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                    model.Reserved01=oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                    model.Reserved02=oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                    model.Reserved03=oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                    model.ReservedDate01=DateTime.Parse(oleReader["RESERVED_DATE01"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                    model.ReservedDate02=DateTime.Parse(oleReader["RESERVED_DATE02"].ToString().Trim());
                    }
                    deptMedPatsInHospital.Add(model);
                }
            }
            return deptMedPatsInHospital;
        }

        public Model.MedPatsInHospital SelectMedPatsInHospitalOdbc(string patientId)
        {
            Model.MedPatsInHospital model = null;

            OdbcParameter[] mdPatsInHospital = GetParameterOdbc("SelectMedPatsInHospital");
            mdPatsInHospital[0].Value = patientId;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MedPatsInHospital_Odbc, mdPatsInHospital))
            {
                if (oleReader.Read())
                {
                    model = new Model.MedPatsInHospital();
                       if (!oleReader.IsDBNull(0))
                        {
                        model.PatientId=oleReader["PATIENT_ID"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(1))
                        {
                        model.InpNo=oleReader["INP_NO"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(2))
                        {
                        model.VisitId=decimal.Parse(oleReader["VISIT_ID"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(3))
                        {
                        model.PatientSource=decimal.Parse(oleReader["PATIENT_SOURCE"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(4))
                        {
                        model.HospBranch=oleReader["HOSP_BRANCH"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(5))
                        {
                        model.DepId=decimal.Parse(oleReader["DEP_ID"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(6))
                        {
                        model.WardCode=oleReader["WARD_CODE"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(7))
                        {
                        model.DeptCode=oleReader["DEPT_CODE"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(8))
                        {
                        model.BedNo=oleReader["BED_NO"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(9))
                        {
                        model.AdmissionDateTime=DateTime.Parse(oleReader["ADMISSION_DATE_TIME"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(10))
                        {
                        model.AdmWardDateTime=DateTime.Parse(oleReader["ADM_WARD_DATE_TIME"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(11))
                        {
                        model.Diagnosis=oleReader["DIAGNOSIS"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(12))
                        {
                        model.PatientCondition=oleReader["PATIENT_CONDITION"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(13))
                        {
                        model.BloodType=oleReader["BLOOD_TYPE"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(14))
                        {
                        model.BloodTypeRh=oleReader["BLOOD_TYPE_RH"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(15))
                        {
                        model.BodyHeight=decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(16))
                        {
                        model.BodyWeight=decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(17))
                        {
                        model.NursingClass=oleReader["NURSING_CLASS"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(18))
                        {
                        model.DoctorInCharge=oleReader["DOCTOR_IN_CHARGE"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(19))
                        {
                        model.NurseInCharge=oleReader["NURSE_IN_CHARGE"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(20))
                        {
                        model.OperatingDate=DateTime.Parse(oleReader["OPERATING_DATE"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(21))
                        {
                        model.BillingDateTime=DateTime.Parse(oleReader["BILLING_DATE_TIME"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(22))
                        {
                        model.Prepayments=decimal.Parse(oleReader["PREPAYMENTS"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(23))
                        {
                        model.TotalCosts=decimal.Parse(oleReader["TOTAL_COSTS"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(24))
                        {
                        model.TotalCharges=decimal.Parse(oleReader["TOTAL_CHARGES"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(25))
                        {
                        model.Guarantor=oleReader["GUARANTOR"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(26))
                        {
                        model.GuarantorOrg=oleReader["GUARANTOR_ORG"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(27))
                        {
                        model.GuarantorPhoneNum=oleReader["GUARANTOR_PHONE_NUM"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(28))
                        {
                        model.BillCheckedDateTime=DateTime.Parse(oleReader["BILL_CHECKED_DATE_TIME"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(29))
                        {
                        model.SettledIndicator=decimal.Parse(oleReader["SETTLED_INDICATOR"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(30))
                        {
                        model.Reserved01=oleReader["RESERVED01"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(31))
                        {
                        model.Reserved02=oleReader["RESERVED02"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(32))
                        {
                        model.Reserved03=oleReader["RESERVED03"].ToString().Trim();
                        }
                        if (!oleReader.IsDBNull(33))
                        {
                        model.ReservedDate01=DateTime.Parse(oleReader["RESERVED_DATE01"].ToString().Trim());
                        }
                        if (!oleReader.IsDBNull(34))
                        {
                        model.ReservedDate02=DateTime.Parse(oleReader["RESERVED_DATE02"].ToString().Trim());
                        }
                }
                else
                    model = null;
            }
            return model;
        }

        public int InsertMedPatsInHospitalOdbc(Model.MedPatsInHospital model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedPatsInHospital");
                    if (model.PatientId!= null)
                    oneInert[0].Value = model.PatientId;
                     else
                    oneInert[0].Value = DBNull.Value;
                    if (model.InpNo!= null)
                    oneInert[1].Value = model.InpNo;
                     else
                    oneInert[1].Value = DBNull.Value;
                    if (model.VisitId!= null)
                    oneInert[2].Value = model.VisitId;
                     else
                    oneInert[2].Value = DBNull.Value;
                    if (model.PatientSource!= null)
                    oneInert[3].Value = model.PatientSource;
                     else
                    oneInert[3].Value = DBNull.Value;
                    if (model.HospBranch!= null)
                    oneInert[4].Value = model.HospBranch;
                     else
                    oneInert[4].Value = DBNull.Value;
                    if (model.DepId!= null)
                    oneInert[5].Value = model.DepId;
                     else
                    oneInert[5].Value = DBNull.Value;
                    if (model.WardCode!= null)
                    oneInert[6].Value = model.WardCode;
                     else
                    oneInert[6].Value = DBNull.Value;
                    if (model.DeptCode!= null)
                    oneInert[7].Value = model.DeptCode;
                     else
                    oneInert[7].Value = DBNull.Value;
                    if (model.BedNo!= null)
                    oneInert[8].Value = model.BedNo;
                     else
                    oneInert[8].Value = DBNull.Value;
                    if (model.AdmissionDateTime!= null)
                    oneInert[9].Value = model.AdmissionDateTime;
                     else
                    oneInert[9].Value = DBNull.Value;
                    if (model.AdmWardDateTime!= null)
                    oneInert[10].Value = model.AdmWardDateTime;
                     else
                    oneInert[10].Value = DBNull.Value;
                    if (model.Diagnosis!= null)
                    oneInert[11].Value = model.Diagnosis;
                     else
                    oneInert[11].Value = DBNull.Value;
                    if (model.PatientCondition!= null)
                    oneInert[12].Value = model.PatientCondition;
                     else
                    oneInert[12].Value = DBNull.Value;
                    if (model.BloodType!= null)
                    oneInert[13].Value = model.BloodType;
                     else
                    oneInert[13].Value = DBNull.Value;
                    if (model.BloodTypeRh!= null)
                    oneInert[14].Value = model.BloodTypeRh;
                     else
                    oneInert[14].Value = DBNull.Value;
                    if (model.BodyHeight!= null)
                    oneInert[15].Value = model.BodyHeight;
                     else
                    oneInert[15].Value = DBNull.Value;
                    if (model.BodyWeight!= null)
                    oneInert[16].Value = model.BodyWeight;
                     else
                    oneInert[16].Value = DBNull.Value;
                    if (model.NursingClass!= null)
                    oneInert[17].Value = model.NursingClass;
                     else
                    oneInert[17].Value = DBNull.Value;
                    if (model.DoctorInCharge!= null)
                    oneInert[18].Value = model.DoctorInCharge;
                     else
                    oneInert[18].Value = DBNull.Value;
                    if (model.NurseInCharge!= null)
                    oneInert[19].Value = model.NurseInCharge;
                     else
                    oneInert[19].Value = DBNull.Value;
                    if (model.OperatingDate!= null)
                    oneInert[20].Value = model.OperatingDate;
                     else
                    oneInert[20].Value = DBNull.Value;
                    if (model.BillingDateTime!= null)
                    oneInert[21].Value = model.BillingDateTime;
                     else
                    oneInert[21].Value = DBNull.Value;
                    if (model.Prepayments!= null)
                    oneInert[22].Value = model.Prepayments;
                     else
                    oneInert[22].Value = DBNull.Value;
                    if (model.TotalCosts!= null)
                    oneInert[23].Value = model.TotalCosts;
                     else
                    oneInert[23].Value = DBNull.Value;
                    if (model.TotalCharges!= null)
                    oneInert[24].Value = model.TotalCharges;
                     else
                    oneInert[24].Value = DBNull.Value;
                    if (model.Guarantor!= null)
                    oneInert[25].Value = model.Guarantor;
                     else
                    oneInert[25].Value = DBNull.Value;
                    if (model.GuarantorOrg!= null)
                    oneInert[26].Value = model.GuarantorOrg;
                     else
                    oneInert[26].Value = DBNull.Value;
                    if (model.GuarantorPhoneNum!= null)
                    oneInert[27].Value = model.GuarantorPhoneNum;
                     else
                    oneInert[27].Value = DBNull.Value;
                    if (model.BillCheckedDateTime!= null)
                    oneInert[28].Value = model.BillCheckedDateTime;
                     else
                    oneInert[28].Value = DBNull.Value;
                    if (model.SettledIndicator!= null)
                    oneInert[29].Value = model.SettledIndicator;
                     else
                    oneInert[29].Value = DBNull.Value;
                    if (model.Reserved01!= null)
                    oneInert[30].Value = model.Reserved01;
                     else
                    oneInert[30].Value = DBNull.Value;
                    if (model.Reserved02!= null)
                    oneInert[31].Value = model.Reserved02;
                     else
                    oneInert[31].Value = DBNull.Value;
                    if (model.Reserved03!= null)
                    oneInert[32].Value = model.Reserved03;
                     else
                    oneInert[32].Value = DBNull.Value;
                    if (model.ReservedDate01!= null)
                    oneInert[33].Value = model.ReservedDate01;
                     else
                    oneInert[33].Value = DBNull.Value;
                    if (model.ReservedDate02!= null)
                    oneInert[34].Value = model.ReservedDate02;
                     else
                    oneInert[34].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_ODBC, oneInert);
            }
        }

        public int UpdateMedPatsInHospitalOdbc(Model.MedPatsInHospital model)
        {
            using (OdbcConnection OdbcCisConn1 = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedPatsInHospital");
                        if (model.InpNo!= null)
                        oneUpdate[0].Value = model.InpNo;
                         else
                        oneUpdate[0].Value = DBNull.Value;
                        if (model.VisitId!= null)
                        oneUpdate[1].Value = model.VisitId;
                         else
                        oneUpdate[1].Value = DBNull.Value;
                        if (model.PatientSource!= null)
                        oneUpdate[2].Value = model.PatientSource;
                         else
                        oneUpdate[2].Value = DBNull.Value;
                        if (model.HospBranch!= null)
                        oneUpdate[3].Value = model.HospBranch;
                         else
                        oneUpdate[3].Value = DBNull.Value;
                        if (model.DepId!= null)
                        oneUpdate[4].Value = model.DepId;
                         else
                        oneUpdate[4].Value = DBNull.Value;
                        if (model.WardCode!= null)
                        oneUpdate[5].Value = model.WardCode;
                         else
                        oneUpdate[5].Value = DBNull.Value;
                        if (model.DeptCode!= null)
                        oneUpdate[6].Value = model.DeptCode;
                         else
                        oneUpdate[6].Value = DBNull.Value;
                        if (model.BedNo!= null)
                        oneUpdate[7].Value = model.BedNo;
                         else
                        oneUpdate[7].Value = DBNull.Value;
                        if (model.AdmissionDateTime!= null)
                        oneUpdate[8].Value = model.AdmissionDateTime;
                         else
                        oneUpdate[8].Value = DBNull.Value;
                        if (model.AdmWardDateTime!= null)
                        oneUpdate[9].Value = model.AdmWardDateTime;
                         else
                        oneUpdate[9].Value = DBNull.Value;
                        if (model.Diagnosis!= null)
                        oneUpdate[10].Value = model.Diagnosis;
                         else
                        oneUpdate[10].Value = DBNull.Value;
                        if (model.PatientCondition!= null)
                        oneUpdate[11].Value = model.PatientCondition;
                         else
                        oneUpdate[11].Value = DBNull.Value;
                        if (model.BloodType!= null)
                        oneUpdate[12].Value = model.BloodType;
                         else
                        oneUpdate[12].Value = DBNull.Value;
                        if (model.BloodTypeRh!= null)
                        oneUpdate[13].Value = model.BloodTypeRh;
                         else
                        oneUpdate[13].Value = DBNull.Value;
                        if (model.BodyHeight!= null)
                        oneUpdate[14].Value = model.BodyHeight;
                         else
                        oneUpdate[14].Value = DBNull.Value;
                        if (model.BodyWeight!= null)
                        oneUpdate[15].Value = model.BodyWeight;
                         else
                        oneUpdate[15].Value = DBNull.Value;
                        if (model.NursingClass!= null)
                        oneUpdate[16].Value = model.NursingClass;
                         else
                        oneUpdate[16].Value = DBNull.Value;
                        if (model.DoctorInCharge!= null)
                        oneUpdate[17].Value = model.DoctorInCharge;
                         else
                        oneUpdate[17].Value = DBNull.Value;
                        if (model.NurseInCharge!= null)
                        oneUpdate[18].Value = model.NurseInCharge;
                         else
                        oneUpdate[18].Value = DBNull.Value;
                        if (model.OperatingDate!= null)
                        oneUpdate[19].Value = model.OperatingDate;
                         else
                        oneUpdate[19].Value = DBNull.Value;
                        if (model.BillingDateTime!= null)
                        oneUpdate[20].Value = model.BillingDateTime;
                         else
                        oneUpdate[20].Value = DBNull.Value;
                        if (model.Prepayments!= null)
                        oneUpdate[21].Value = model.Prepayments;
                         else
                        oneUpdate[21].Value = DBNull.Value;
                        if (model.TotalCosts!= null)
                        oneUpdate[22].Value = model.TotalCosts;
                         else
                        oneUpdate[22].Value = DBNull.Value;
                        if (model.TotalCharges!= null)
                        oneUpdate[23].Value = model.TotalCharges;
                         else
                        oneUpdate[23].Value = DBNull.Value;
                        if (model.Guarantor!= null)
                        oneUpdate[24].Value = model.Guarantor;
                         else
                        oneUpdate[24].Value = DBNull.Value;
                        if (model.GuarantorOrg!= null)
                        oneUpdate[25].Value = model.GuarantorOrg;
                         else
                        oneUpdate[25].Value = DBNull.Value;
                        if (model.GuarantorPhoneNum!= null)
                        oneUpdate[26].Value = model.GuarantorPhoneNum;
                         else
                        oneUpdate[26].Value = DBNull.Value;
                        if (model.BillCheckedDateTime!= null)
                        oneUpdate[27].Value = model.BillCheckedDateTime;
                         else
                        oneUpdate[27].Value = DBNull.Value;
                        if (model.SettledIndicator!= null)
                        oneUpdate[28].Value = model.SettledIndicator;
                         else
                        oneUpdate[28].Value = DBNull.Value;
                        if (model.Reserved01!= null)
                        oneUpdate[29].Value = model.Reserved01;
                         else
                        oneUpdate[29].Value = DBNull.Value;
                        if (model.Reserved02!= null)
                        oneUpdate[30].Value = model.Reserved02;
                         else
                        oneUpdate[30].Value = DBNull.Value;
                        if (model.Reserved03!= null)
                        oneUpdate[31].Value = model.Reserved03;
                         else
                        oneUpdate[31].Value = DBNull.Value;
                        if (model.ReservedDate01!= null)
                        oneUpdate[32].Value = model.ReservedDate01;
                         else
                        oneUpdate[32].Value = DBNull.Value;
                        if (model.ReservedDate02!= null)
                        oneUpdate[33].Value = model.ReservedDate02;
                         else
                        oneUpdate[33].Value = DBNull.Value;
                     if (model.PatientId!= null)
                        oneUpdate[34].Value = model.PatientId;
                         else
                        oneUpdate[34].Value = DBNull.Value;
 
                return OdbcHelper.ExecuteNonQuery(OdbcCisConn1, CommandType.Text, Update_ODBC, oneUpdate);
            }
        }

        public int DeleteMedPatsInHospitalOdbc(Model.MedPatsInHospital MedPatsInHospital)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterOdbc("DeleteMedPatsInHospital");
                oneDelete[0].Value = MedPatsInHospital.PatientId;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Delete_MedPatsInhospital_Odbc, oneDelete);
            }
        }
    }
}
