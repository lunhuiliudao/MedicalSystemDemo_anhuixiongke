using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Data.Odbc;

namespace MedicalSytem.Soft.DAL
{
    public partial class DALMedPatVisit
    {
        private static readonly string Select_MedPatVisit_OLE = "select PATIENT_ID,VISIT_ID,INP_NO,HOSP_BRANCH,PATIENT_SOURCE,RESERVED02,DEPT_ADMISSION_TO,RESERVED01,ADMISSION_DATE_TIME,CONSULTING_DATE,PAT_ADM_CONDITION,DOCTOR_IN_CHARGE from MED_PAT_VISIT WHERE PATIENT_ID=? AND VISIT_ID=? ";
        private static readonly string Insert_MedPatVisit_OLE = "Insert into MED_PAT_VISIT  (PATIENT_ID,VISIT_ID,INP_NO,HOSP_BRANCH,PATIENT_SOURCE,RESERVED02,DEPT_ADMISSION_TO,RESERVED01,ADMISSION_DATE_TIME,CONSULTING_DATE,PAT_ADM_CONDITION,DOCTOR_IN_CHARGE) values(?,?,?,?,?,?,?,?,?,?,?,?) ";
        private static readonly string Update_MedPatVisit_OLE = "Update MED_PAT_VISIT set INP_NO=?,HOSP_BRANCH=?,PATIENT_SOURCE=?,RESERVED02=?,DEPT_ADMISSION_TO=?,RESERVED01=?,ADMISSION_DATE_TIME=?,CONSULTING_DATE=?,PAT_ADM_CONDITION=?,DOCTOR_IN_CHARGE=? where PATIENT_ID=? AND VISIT_ID=?";

        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedPatVisit")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "InsertMedPatVisit")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("PatientId",OleDbType.VarChar),
                        new OleDbParameter("VisitId",OleDbType.Decimal),
                        new OleDbParameter("InpNo",OleDbType.VarChar),
                        new OleDbParameter("HospBranch",OleDbType.VarChar),
                        new OleDbParameter("PatientSource",OleDbType.Decimal),
                        new OleDbParameter("WardCode",OleDbType.VarChar),
                        new OleDbParameter("DEPT_ADMISSION_TO",OleDbType.VarChar),
                        new OleDbParameter("BedNo",OleDbType.VarChar),
                        new OleDbParameter("AdmissionDateTime",OleDbType.DBTimeStamp),
                        new OleDbParameter("AdmWardDateTime",OleDbType.DBTimeStamp),
                        new OleDbParameter("PAT_ADM_CONDITION",OleDbType.VarChar),
                        new OleDbParameter("DoctorInCharge",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedPatVisit")
                {
                    parms = new OleDbParameter[]{
                            new OleDbParameter(":InpNo",OleDbType.VarChar),
                            new OleDbParameter(":HospBranch",OleDbType.VarChar),
                            new OleDbParameter(":PatientSource",OleDbType.Decimal),
                            new OleDbParameter(":WardCode",OleDbType.VarChar),
                            new OleDbParameter(":DEPT_ADMISSION_TO",OleDbType.VarChar),
                            new OleDbParameter(":BedNo",OleDbType.VarChar),
                            new OleDbParameter(":AdmissionDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter(":AdmWardDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter(":PAT_ADM_CONDITION",OleDbType.VarChar),
                            new OleDbParameter(":DoctorInCharge",OleDbType.VarChar),
                            new OleDbParameter(":PatientId",OleDbType.VarChar),
                            new OleDbParameter(":VisitId",OleDbType.Decimal),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedPatVisit SelectMedPatVisitOLE(string patientId, decimal visitId)
        {
            Model.MedPatVisit model = null;

            OleDbParameter[] mdPatVisit = GetParameterOLE("SelectMedPatVisit");
            mdPatVisit[0].Value = patientId;
            mdPatVisit[1].Value = visitId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedPatVisit_OLE, mdPatVisit))
            {
                if (oleReader.Read())
                {
                    model = new Model.MedPatVisit();
                    model.PatientId = oleReader.GetString(0);
                    model.VisitId = oleReader.GetDecimal(1);
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

        public int InsertMedPatVisitOLE(Model.MedPatVisit model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedPatVisit");
                oneInert[0].Value = model.PatientId;
                oneInert[1].Value = model.VisitId;
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

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_MedPatVisit_OLE, oneInert);
            }
        }

        public int UpdateMedPatVisitOLE(Model.MedPatVisit model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedPatVisit");

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
                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_MedPatVisit_OLE, oneUpdate);
            }
        }

        private static readonly string Select_MedPatVisit_Odbc = "select PATIENT_ID,VISIT_ID,INP_NO,HOSP_BRANCH,PATIENT_SOURCE,RESERVED02,DEPT_ADMISSION_TO,RESERVED01,ADMISSION_DATE_TIME,CONSULTING_DATE,PAT_ADM_CONDITION,DOCTOR_IN_CHARGE from MED_PAT_VISIT WHERE PATIENT_ID=?,VISIT_ID=?";
        private static readonly string Insert_MedPatVisit_Odbc = "Insert into MED_PAT_VISIT  (PATIENT_ID,VISIT_ID,INP_NO,HOSP_BRANCH,PATIENT_SOURCE,RESERVED02,DEPT_ADMISSION_TO,RESERVED01,ADMISSION_DATE_TIME,CONSULTING_DATE,PAT_ADM_CONDITION,DOCTOR_IN_CHARGE) values(?,?,?,?,?,?,?,?,?,?,?,?) ";
        private static readonly string Update_MedPatVisit_Odbc = "Update MED_PAT_VISIT set INP_NO=?,HOSP_BRANCH=?,PATIENT_SOURCE=?,RESERVED02=?,DEPT_ADMISSION_TO=?,RESERVED01=?,ADMISSION_DATE_TIME=?,CONSULTING_DATE=?,PAT_ADM_CONDITION=?,DOCTOR_IN_CHARGE=? where PATIENT_ID=?,VISIT_ID=?";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedPatVisit")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "InsertMedPatVisit")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("PatientId",OdbcType.VarChar),
                        new OdbcParameter("VisitId",OdbcType.Decimal),
                        new OdbcParameter("InpNo",OdbcType.VarChar),
                        new OdbcParameter("HospBranch",OdbcType.VarChar),
                        new OdbcParameter("PatientSource",OdbcType.Decimal),
                        new OdbcParameter("WardCode",OdbcType.VarChar),
                        new OdbcParameter("DEPT_ADMISSION_TO",OdbcType.VarChar),
                        new OdbcParameter("BedNo",OdbcType.VarChar),
                        new OdbcParameter("AdmissionDateTime",OdbcType.DateTime),
                        new OdbcParameter("AdmWardDateTime",OdbcType.DateTime),
                        new OdbcParameter("PAT_ADM_CONDITION",OdbcType.VarChar),
                        new OdbcParameter("DoctorInCharge",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedPatVisit")
                {
                    parms = new OdbcParameter[]{
                       new OdbcParameter(":InpNo",OdbcType.VarChar),
                        new OdbcParameter(":HospBranch",OdbcType.VarChar),
                        new OdbcParameter(":PatientSource",OdbcType.Decimal),
                        new OdbcParameter(":WardCode",OdbcType.VarChar),
                        new OdbcParameter(":DEPT_ADMISSION_TO",OdbcType.VarChar),
                        new OdbcParameter(":BedNo",OdbcType.VarChar),
                        new OdbcParameter(":AdmissionDateTime",OdbcType.DateTime),
                        new OdbcParameter(":AdmWardDateTime",OdbcType.DateTime),
                        new OdbcParameter(":PAT_ADM_CONDITION",OdbcType.VarChar),
                        new OdbcParameter(":DoctorInCharge",OdbcType.VarChar),
                        new OdbcParameter(":PatientId",OdbcType.VarChar),
                        new OdbcParameter(":VisitId",OdbcType.Decimal),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedPatVisit SelectMedPatVisitOdbc(string patientId, decimal visitId)
        {
            Model.MedPatVisit model = null;

            OdbcParameter[] mdPatVisit = GetParameterOdbc("SelectMedPatVisit");
            mdPatVisit[0].Value = patientId;
            mdPatVisit[1].Value = visitId;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MedPatVisit_Odbc, mdPatVisit))
            {
                if (OdbcReader.Read())
                {
                    model = new Model.MedPatVisit();
                    if (!OdbcReader.IsDBNull(0))
                    {
                        model.PatientId = OdbcReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(1))
                    {
                        model.VisitId = decimal.Parse(OdbcReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(2))
                    {
                        model.InpNo = OdbcReader["INP_NO"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(3))
                    {
                        model.HospBranch = OdbcReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(4))
                    {
                        model.PatientSource = decimal.Parse(OdbcReader["PATIENT_SOURCE"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(5))
                    {
                        model.Reserved01 = OdbcReader["RESERVED02"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(6))
                    {
                        model.DEPT_ADMISSION_TO = OdbcReader["DEPT_ADMISSION_TO"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(7))
                    {
                        model.Reserved02 = OdbcReader["RESERVED01"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(8))
                    {
                        model.AdmissionDateTime = DateTime.Parse(OdbcReader["ADMISSION_DATE_TIME"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(9))
                    {
                        model.Reserved05 = OdbcReader["CONSULTING_DATE"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(10))
                    {
                        model.Reserved04 = OdbcReader["PAT_ADM_CONDITION"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(11))
                    {
                        model.DoctorInCharge = OdbcReader["DOCTOR_IN_CHARGE"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }

        public int InsertMedPatVisitOdbc(Model.MedPatVisit model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedPatVisit");
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

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_MedPatVisit_Odbc, oneInert);
            }
        }

        public int UpdateMedPatVisitOdbc(Model.MedPatVisit model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedPatVisit");

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

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_MedPatVisit_Odbc, oneUpdate);
            }
        }

    }
}
