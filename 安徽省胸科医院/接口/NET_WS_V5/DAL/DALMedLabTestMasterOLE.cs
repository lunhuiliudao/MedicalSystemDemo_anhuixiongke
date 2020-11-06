

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:01
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
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.OracleClient;
using MedicalSytem.Soft.Model;

namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedLabTestMaster OLE
	/// </summary>
    public partial class DALMedLabTestMaster
	{

        private static readonly string Select_Med_Lab_Test_Master_OLE = "select test_no, priority_indicator, patient_id, visit_id, working_id, execute_date, name, name_phonetic, charge_type, sex, age, test_cause, relevant_clinic_diag, specimen, notes_for_spcm, spcm_received_date_time, spcm_sample_date_time, requested_date_time, ordering_dept, ordering_provider, performed_by, result_status, results_rpt_date_time, transcriptionist, verified_by, costs, charges, billing_indicator, print_indicator, subject, barcode from med_lab_test_master where test_no = ? ";
        private static readonly string Insert_Med_Lab_Test_Master_OLE = "insert into med_lab_test_master(test_no, priority_indicator, patient_id, visit_id, working_id, execute_date, name, name_phonetic, charge_type, sex, age, test_cause, relevant_clinic_diag, specimen, notes_for_spcm, spcm_received_date_time, spcm_sample_date_time, requested_date_time, ordering_dept, ordering_provider, performed_by, result_status, results_rpt_date_time, transcriptionist, verified_by, costs, charges, billing_indicator, print_indicator, subject, barcode)values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private static readonly string Update_Med_Lab_Test_Master_OLE = "update med_lab_test_master set priority_indicator = ?, patient_id = ?, visit_id = ?, working_id = ?, execute_date = ?, name = ?, name_phonetic = ?, charge_type = ?, sex = ?,age = ?,test_cause = ?,relevant_clinic_diag = ?,specimen = ?,notes_for_spcm = ?,spcm_received_date_time = ?, spcm_sample_date_time = ?, requested_date_time = ?, ordering_dept = ?, ordering_provider = ?, performed_by = ?,result_status = ?,results_rpt_date_time = ?,transcriptionist = ?,verified_by = ?,costs = ?,charges = ?, billing_indicator = ?, print_indicator = ?, subject = ?, barcode = ? where test_no = ?";

        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedLabTestMaster")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("testNo",OleDbType.VarChar)
                    };
                }
                else
                {
                    if (sqlParms == "InsertMedLabTestMaster")
                    {
                        parms = new OleDbParameter[]{
                            new OleDbParameter("testNo",OleDbType.VarChar),
                            new OleDbParameter("priorityIndicator",OleDbType.Decimal), 
                            new OleDbParameter("patientId",OleDbType.VarChar), 
                            new OleDbParameter("visitId",OleDbType.Decimal), 
                            new OleDbParameter("workingId",OleDbType.VarChar), 
                            new OleDbParameter("executeDate",OleDbType.DBTimeStamp), 
                            new OleDbParameter("name",OleDbType.VarChar), 
                            new OleDbParameter("namePhonetic",OleDbType.VarChar), 
                            new OleDbParameter("chargeType",OleDbType.VarChar), 
                            new OleDbParameter("sex",OleDbType.VarChar), 
                            new OleDbParameter("age",OleDbType.Decimal), 
                            new OleDbParameter("testCause",OleDbType.VarChar),
                            new OleDbParameter("relevantClinicDiag",OleDbType.VarChar),
                            new OleDbParameter("specimen",OleDbType.VarChar),
                            new OleDbParameter("notesForSpcm",OleDbType.VarChar),
                            new OleDbParameter("spcmReceivedDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter("spcmSampleDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter("requestedDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter("orderingDept",OleDbType.VarChar),
                            new OleDbParameter("orderingProvider",OleDbType.VarChar),
                            new OleDbParameter("performedBy",OleDbType.VarChar),
                            new OleDbParameter("resultStatus",OleDbType.VarChar),
                            new OleDbParameter("resultsRptDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter("transcriptionist",OleDbType.VarChar),
                            new OleDbParameter("verifiedBy",OleDbType.VarChar),
                            new OleDbParameter("costs",OleDbType.Decimal),
                            new OleDbParameter("charges",OleDbType.Decimal),
                            new OleDbParameter("billingIndicator",OleDbType.Decimal),
                            new OleDbParameter("printIndicator",OleDbType.Decimal),
                            new OleDbParameter("subject",OleDbType.VarChar),
                            new OleDbParameter("barcode",OleDbType.VarChar)
                        };
                    }
                    else
                    {
                        if (sqlParms == "UpdateMedLabTestMaster")
                        {
                            parms = new OleDbParameter[]{
                                new OleDbParameter("priorityIndicator",OleDbType.Decimal), 
                                new OleDbParameter("patientId",OleDbType.VarChar), 
                                new OleDbParameter("visitId",OleDbType.Decimal), 
                                new OleDbParameter("workingId",OleDbType.VarChar), 
                                new OleDbParameter("executeDate",OleDbType.DBTimeStamp), 
                                new OleDbParameter("name",OleDbType.VarChar), 
                                new OleDbParameter("namePhonetic",OleDbType.VarChar), 
                                new OleDbParameter("chargeType",OleDbType.VarChar), 
                                new OleDbParameter("sex",OleDbType.VarChar), 
                                new OleDbParameter("age",OleDbType.Decimal), 
                                new OleDbParameter("testCause",OleDbType.VarChar),
                                new OleDbParameter("relevantClinicDiag",OleDbType.VarChar),
                                new OleDbParameter("specimen",OleDbType.VarChar),
                                new OleDbParameter("notesForSpcm",OleDbType.VarChar),
                                new OleDbParameter("spcmReceivedDateTime",OleDbType.DBTimeStamp),
                                new OleDbParameter("spcmSampleDateTime",OleDbType.DBTimeStamp),
                                new OleDbParameter("requestedDateTime",OleDbType.DBTimeStamp),
                                new OleDbParameter("orderingDept",OleDbType.VarChar),
                                new OleDbParameter("orderingProvider",OleDbType.VarChar),
                                new OleDbParameter("performedBy",OleDbType.VarChar),
                                new OleDbParameter("resultStatus",OleDbType.VarChar),
                                new OleDbParameter("resultsRptDateTime",OleDbType.DBTimeStamp),
                                new OleDbParameter("transcriptionist",OleDbType.VarChar),
                                new OleDbParameter("verifiedBy",OleDbType.VarChar),
                                new OleDbParameter("costs",OleDbType.Decimal),
                                new OleDbParameter("charges",OleDbType.Decimal),
                                new OleDbParameter("billingIndicator",OleDbType.Decimal),
                                new OleDbParameter("printIndicator",OleDbType.Decimal),
                                new OleDbParameter("subject",OleDbType.VarChar),
                                new OleDbParameter("barcode",OleDbType.VarChar),
                                new OleDbParameter("testNo",OleDbType.VarChar)
                            };
                        }
                    }
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedLabTestMaster SelectMedLabTestMasterOLE(string testNo)
        {
            Model.MedLabTestMaster medLabTestMaster = null;

            OleDbParameter[] mdPats = GetParameterOLE("SelectMedLabTestMaster");
            mdPats[0].Value = testNo;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_Med_Lab_Test_Master_OLE, mdPats))
            {
                if (oleReader.Read())
                {
                    medLabTestMaster = new Model.MedLabTestMaster();
                    medLabTestMaster.TestNo = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        medLabTestMaster.PriorityIndicator = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        medLabTestMaster.PatientId = oleReader.GetString(2);
                    if (!oleReader.IsDBNull(3))
                        medLabTestMaster.VisitId = oleReader.GetDecimal(3);
                    if (!oleReader.IsDBNull(4))
                        medLabTestMaster.WorkingId = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        medLabTestMaster.ExecuteDate = oleReader.GetDateTime(5);
                    if (!oleReader.IsDBNull(6))
                        medLabTestMaster.Name = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        medLabTestMaster.NamePhonetic = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        medLabTestMaster.ChargeType = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        medLabTestMaster.Sex = oleReader.GetString(9);
                    if (!oleReader.IsDBNull(10))
                        medLabTestMaster.Age = oleReader.GetDecimal(10);
                    if (!oleReader.IsDBNull(11))
                        medLabTestMaster.TestCause = oleReader.GetString(11);
                    if (!oleReader.IsDBNull(12))
                        medLabTestMaster.RelevantClinicDiag = oleReader.GetString(12);
                    if (!oleReader.IsDBNull(13))
                        medLabTestMaster.Specimen = oleReader.GetString(13);
                    if (!oleReader.IsDBNull(14))
                        medLabTestMaster.NotesForSpcm = oleReader.GetString(14);
                    if (!oleReader.IsDBNull(15))
                        medLabTestMaster.SpcmReceivedDateTime = oleReader.GetDateTime(15);
                    if (!oleReader.IsDBNull(16))
                        medLabTestMaster.SpcmSampleDateTime = oleReader.GetDateTime(16);
                    if (!oleReader.IsDBNull(17))
                        medLabTestMaster.RequestedDateTime = oleReader.GetDateTime(17);
                    if (!oleReader.IsDBNull(18))
                        medLabTestMaster.OrderingDept = oleReader.GetString(18);
                    if (!oleReader.IsDBNull(19))
                        medLabTestMaster.OrderingProvider = oleReader.GetString(19);
                    if (!oleReader.IsDBNull(20))
                        medLabTestMaster.PerformedBy = oleReader.GetString(20);
                    if (!oleReader.IsDBNull(21))
                        medLabTestMaster.ResultStatus = oleReader.GetString(21);
                    if (!oleReader.IsDBNull(22))
                        medLabTestMaster.ResultsRptDateTime = oleReader.GetDateTime(22);
                    if (!oleReader.IsDBNull(23))
                        medLabTestMaster.Transcriptionist = oleReader.GetString(23);
                    if (!oleReader.IsDBNull(24))
                        medLabTestMaster.VerifiedBy = oleReader.GetString(24);
                    if (!oleReader.IsDBNull(25))
                        medLabTestMaster.Costs = oleReader.GetDecimal(25);
                    if (!oleReader.IsDBNull(26))
                        medLabTestMaster.Charges = oleReader.GetDecimal(26);
                    if (!oleReader.IsDBNull(27))
                        medLabTestMaster.BillingIndicator = oleReader.GetDecimal(27);
                    if (!oleReader.IsDBNull(28))
                        medLabTestMaster.PrintIndicator = oleReader.GetDecimal(28);
                    if (!oleReader.IsDBNull(29))
                        medLabTestMaster.Subject = oleReader.GetString(29);
                    if (!oleReader.IsDBNull(30))
                        medLabTestMaster.Barcode = oleReader.GetString(30);
                }
                else
                    medLabTestMaster = null;
            }
            return medLabTestMaster;
        }

        public int InsertMedLabTestMasterOLE(Model.MedLabTestMaster MedLabTestMaster)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedLabTestMaster");
                oneInert[0].Value = MedLabTestMaster.TestNo;
                if (MedLabTestMaster.PriorityIndicator.ToString() != null)
                    oneInert[1].Value = MedLabTestMaster.PriorityIndicator;
                else
                    oneInert[1].Value = DBNull.Value;
                if (MedLabTestMaster.PatientId != null)
                    oneInert[2].Value = MedLabTestMaster.PatientId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (MedLabTestMaster.VisitId.ToString() != null)
                    oneInert[3].Value = MedLabTestMaster.VisitId;
                else
                    oneInert[3].Value = DBNull.Value;
                if (MedLabTestMaster.WorkingId != null)
                    oneInert[4].Value = MedLabTestMaster.WorkingId;
                else
                    oneInert[4].Value = DBNull.Value;
                if (MedLabTestMaster.ExecuteDate > DateTime.MinValue)
                    oneInert[5].Value = MedLabTestMaster.ExecuteDate;
                else
                    oneInert[5].Value = DBNull.Value;
                if (MedLabTestMaster.Name != null)
                    oneInert[6].Value = MedLabTestMaster.Name;
                else
                    oneInert[6].Value = DBNull.Value;
                if (MedLabTestMaster.NamePhonetic != null)
                    oneInert[7].Value = MedLabTestMaster.NamePhonetic;
                else
                    oneInert[7].Value = DBNull.Value;
                if (MedLabTestMaster.ChargeType != null)
                    oneInert[8].Value = MedLabTestMaster.ChargeType;
                else
                    oneInert[8].Value = DBNull.Value;
                if (MedLabTestMaster.Sex != null)
                    oneInert[9].Value = MedLabTestMaster.Sex;
                else
                    oneInert[9].Value = DBNull.Value;
                if (MedLabTestMaster.Age.ToString() != null)
                    oneInert[10].Value = MedLabTestMaster.Age;
                else
                    oneInert[10].Value = DBNull.Value;
                if (MedLabTestMaster.TestCause != null)
                    oneInert[11].Value = MedLabTestMaster.TestCause;
                else
                    oneInert[11].Value = DBNull.Value;
                if (MedLabTestMaster.RelevantClinicDiag != null)
                    oneInert[12].Value = MedLabTestMaster.RelevantClinicDiag;
                else
                    oneInert[12].Value = DBNull.Value;
                if (MedLabTestMaster.Specimen != null)
                    oneInert[13].Value = MedLabTestMaster.Specimen;
                else
                    oneInert[13].Value = DBNull.Value;
                if (MedLabTestMaster.NotesForSpcm != null)
                    oneInert[14].Value = MedLabTestMaster.NotesForSpcm;
                else
                    oneInert[14].Value = DBNull.Value;
                if (MedLabTestMaster.SpcmReceivedDateTime > DateTime.MinValue)
                    oneInert[15].Value = MedLabTestMaster.SpcmReceivedDateTime;
                else
                    oneInert[15].Value = DBNull.Value;
                if (MedLabTestMaster.SpcmSampleDateTime > DateTime.MinValue)
                    oneInert[16].Value = MedLabTestMaster.SpcmSampleDateTime;
                else
                    oneInert[16].Value = DBNull.Value;
                if (MedLabTestMaster.RequestedDateTime > DateTime.MinValue)
                    oneInert[17].Value = MedLabTestMaster.RequestedDateTime;
                else
                    oneInert[17].Value = DBNull.Value;
                if (MedLabTestMaster.OrderingDept != null)
                    oneInert[18].Value = MedLabTestMaster.OrderingDept;
                else
                    oneInert[18].Value = DBNull.Value;
                if (MedLabTestMaster.OrderingProvider != null)
                    oneInert[19].Value = MedLabTestMaster.OrderingProvider;
                else
                    oneInert[19].Value = DBNull.Value;
                if (MedLabTestMaster.PerformedBy != null)
                    oneInert[20].Value = MedLabTestMaster.PerformedBy;
                else
                    oneInert[20].Value = DBNull.Value;
                if (MedLabTestMaster.ResultStatus != null)
                    oneInert[21].Value = MedLabTestMaster.ResultStatus;
                else
                    oneInert[21].Value = DBNull.Value;
                if (MedLabTestMaster.ResultsRptDateTime > DateTime.MinValue)
                    oneInert[22].Value = MedLabTestMaster.ResultsRptDateTime;
                else
                    oneInert[22].Value = DBNull.Value;
                if (MedLabTestMaster.Transcriptionist != null)
                    oneInert[23].Value = MedLabTestMaster.Transcriptionist;
                else
                    oneInert[23].Value = DBNull.Value;
                if (MedLabTestMaster.VerifiedBy != null)
                    oneInert[24].Value = MedLabTestMaster.VerifiedBy;
                else
                    oneInert[24].Value = DBNull.Value;
                if (MedLabTestMaster.Costs.ToString() != null)
                    oneInert[25].Value = MedLabTestMaster.Costs;
                else
                    oneInert[25].Value = DBNull.Value;
                if (MedLabTestMaster.Charges.ToString() != null)
                    oneInert[26].Value = MedLabTestMaster.Charges;
                else
                    oneInert[26].Value = DBNull.Value;
                if (MedLabTestMaster.BillingIndicator.ToString() != null)
                    oneInert[27].Value = MedLabTestMaster.BillingIndicator;
                else
                    oneInert[27].Value = DBNull.Value;
                if (MedLabTestMaster.PrintIndicator.ToString() != null)
                    oneInert[28].Value = MedLabTestMaster.PrintIndicator;
                else
                    oneInert[28].Value = DBNull.Value;
                if (MedLabTestMaster.Subject != null)
                    oneInert[29].Value = MedLabTestMaster.Subject;
                else
                    oneInert[29].Value = DBNull.Value;
                if (MedLabTestMaster.Barcode != null)
                    oneInert[30].Value = MedLabTestMaster.Barcode;
                else
                    oneInert[30].Value = DBNull.Value;


                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_Med_Lab_Test_Master_OLE, oneInert);
            }
        }

        public int UpdateMedLabTestMasterOLE(Model.MedLabTestMaster MedLabTestMaster)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedLabTestMaster");
                if (MedLabTestMaster.PriorityIndicator.ToString() != null)
                    oneUpdate[0].Value = MedLabTestMaster.PriorityIndicator;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (MedLabTestMaster.PatientId != null)
                    oneUpdate[1].Value = MedLabTestMaster.PatientId;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (MedLabTestMaster.VisitId.ToString() != null)
                    oneUpdate[2].Value = MedLabTestMaster.VisitId;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (MedLabTestMaster.WorkingId != null)
                    oneUpdate[3].Value = MedLabTestMaster.WorkingId;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (MedLabTestMaster.ExecuteDate > DateTime.MinValue)
                    oneUpdate[4].Value = MedLabTestMaster.ExecuteDate;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (MedLabTestMaster.Name != null)
                    oneUpdate[5].Value = MedLabTestMaster.Name;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (MedLabTestMaster.NamePhonetic != null)
                    oneUpdate[6].Value = MedLabTestMaster.NamePhonetic;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (MedLabTestMaster.ChargeType != null)
                    oneUpdate[7].Value = MedLabTestMaster.ChargeType;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (MedLabTestMaster.Sex != null)
                    oneUpdate[8].Value = MedLabTestMaster.Sex;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (MedLabTestMaster.Age.ToString() != null)
                    oneUpdate[9].Value = MedLabTestMaster.Age;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (MedLabTestMaster.TestCause != null)
                    oneUpdate[10].Value = MedLabTestMaster.TestCause;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (MedLabTestMaster.RelevantClinicDiag != null)
                    oneUpdate[11].Value = MedLabTestMaster.RelevantClinicDiag;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (MedLabTestMaster.Specimen != null)
                    oneUpdate[12].Value = MedLabTestMaster.Specimen;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (MedLabTestMaster.NotesForSpcm != null)
                    oneUpdate[13].Value = MedLabTestMaster.NotesForSpcm;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (MedLabTestMaster.SpcmReceivedDateTime > DateTime.MinValue)
                    oneUpdate[14].Value = MedLabTestMaster.SpcmReceivedDateTime;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (MedLabTestMaster.SpcmSampleDateTime > DateTime.MinValue)
                    oneUpdate[15].Value = MedLabTestMaster.SpcmSampleDateTime;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (MedLabTestMaster.RequestedDateTime > DateTime.MinValue)
                    oneUpdate[16].Value = MedLabTestMaster.RequestedDateTime;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (MedLabTestMaster.OrderingDept != null)
                    oneUpdate[17].Value = MedLabTestMaster.OrderingDept;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (MedLabTestMaster.OrderingProvider != null)
                    oneUpdate[18].Value = MedLabTestMaster.OrderingProvider;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (MedLabTestMaster.PerformedBy != null)
                    oneUpdate[19].Value = MedLabTestMaster.PerformedBy;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (MedLabTestMaster.ResultStatus != null)
                    oneUpdate[20].Value = MedLabTestMaster.ResultStatus;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (MedLabTestMaster.ResultsRptDateTime > DateTime.MinValue)
                    oneUpdate[21].Value = MedLabTestMaster.ResultsRptDateTime;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (MedLabTestMaster.Transcriptionist != null)
                    oneUpdate[22].Value = MedLabTestMaster.Transcriptionist;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (MedLabTestMaster.VerifiedBy != null)
                    oneUpdate[23].Value = MedLabTestMaster.VerifiedBy;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (MedLabTestMaster.Costs.ToString() != null)
                    oneUpdate[24].Value = MedLabTestMaster.Costs;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (MedLabTestMaster.Charges.ToString() != null)
                    oneUpdate[25].Value = MedLabTestMaster.Charges;
                else
                    oneUpdate[25].Value = DBNull.Value;
                if (MedLabTestMaster.BillingIndicator.ToString() != null)
                    oneUpdate[26].Value = MedLabTestMaster.BillingIndicator;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (MedLabTestMaster.PrintIndicator.ToString() != null)
                    oneUpdate[27].Value = MedLabTestMaster.PrintIndicator;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (MedLabTestMaster.Subject != null)
                    oneUpdate[28].Value = MedLabTestMaster.Subject;
                else
                    oneUpdate[28].Value = DBNull.Value;
                if (MedLabTestMaster.Barcode != null)
                    oneUpdate[29].Value = MedLabTestMaster.Barcode;
                else
                    oneUpdate[29].Value = DBNull.Value;
                oneUpdate[30].Value = MedLabTestMaster.TestNo;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_Med_Lab_Test_Master_OLE, oneUpdate);
            }
        }

        private static readonly string Select_Med_Lab_Test_Master_Odbc = "select test_no, priority_indicator, patient_id, visit_id, working_id, execute_date, name, name_phonetic, charge_type, sex, age, test_cause, relevant_clinic_diag, specimen, notes_for_spcm, spcm_received_date_time, spcm_sample_date_time, requested_date_time, ordering_dept, ordering_provider, performed_by, result_status, results_rpt_date_time, transcriptionist, verified_by, costs, charges, billing_indicator, print_indicator, subject, barcode from med_lab_test_master where test_no = ? ";
        private static readonly string Insert_Med_Lab_Test_Master_Odbc = "insert into med_lab_test_master(test_no, priority_indicator, patient_id, visit_id, working_id, execute_date, name, name_phonetic, charge_type, sex, age, test_cause, relevant_clinic_diag, specimen, notes_for_spcm, spcm_received_date_time, spcm_sample_date_time, requested_date_time, ordering_dept, ordering_provider, performed_by, result_status, results_rpt_date_time, transcriptionist, verified_by, costs, charges, billing_indicator, print_indicator, subject, barcode)values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private static readonly string Update_Med_Lab_Test_Master_Odbc = "update med_lab_test_master set priority_indicator = ?, patient_id = ?, visit_id = ?, working_id = ?, execute_date = ?, name = ?, name_phonetic = ?, charge_type = ?, sex = ?,age = ?,test_cause = ?,relevant_clinic_diag = ?,specimen = ?,notes_for_spcm = ?,spcm_received_date_time = ?, spcm_sample_date_time = ?, requested_date_time = ?, ordering_dept = ?, ordering_provider = ?, performed_by = ?,result_status = ?,results_rpt_date_time = ?,transcriptionist = ?,verified_by = ?,costs = ?,charges = ?, billing_indicator = ?, print_indicator = ?, subject = ?, barcode = ? where test_no = ?";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedLabTestMaster")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("testNo",OdbcType.VarChar)
                    };
                }
                else
                {
                    if (sqlParms == "InsertMedLabTestMaster")
                    {
                        parms = new OdbcParameter[]{
                            new OdbcParameter("testNo",OdbcType.VarChar),
                            new OdbcParameter("priorityIndicator",OdbcType.Decimal), 
                            new OdbcParameter("patientId",OdbcType.VarChar), 
                            new OdbcParameter("visitId",OdbcType.Decimal), 
                            new OdbcParameter("workingId",OdbcType.VarChar), 
                            new OdbcParameter("executeDate",OdbcType.DateTime), 
                            new OdbcParameter("name",OdbcType.VarChar), 
                            new OdbcParameter("namePhonetic",OdbcType.VarChar), 
                            new OdbcParameter("chargeType",OdbcType.VarChar), 
                            new OdbcParameter("sex",OdbcType.VarChar), 
                            new OdbcParameter("age",OdbcType.Decimal), 
                            new OdbcParameter("testCause",OdbcType.VarChar),
                            new OdbcParameter("relevantClinicDiag",OdbcType.VarChar),
                            new OdbcParameter("specimen",OdbcType.VarChar),
                            new OdbcParameter("notesForSpcm",OdbcType.VarChar),
                            new OdbcParameter("spcmReceivedDateTime",OdbcType.DateTime),
                            new OdbcParameter("spcmSampleDateTime",OdbcType.DateTime),
                            new OdbcParameter("requestedDateTime",OdbcType.DateTime),
                            new OdbcParameter("orderingDept",OdbcType.VarChar),
                            new OdbcParameter("orderingProvider",OdbcType.VarChar),
                            new OdbcParameter("performedBy",OdbcType.VarChar),
                            new OdbcParameter("resultStatus",OdbcType.VarChar),
                            new OdbcParameter("resultsRptDateTime",OdbcType.DateTime),
                            new OdbcParameter("transcriptionist",OdbcType.VarChar),
                            new OdbcParameter("verifiedBy",OdbcType.VarChar),
                            new OdbcParameter("costs",OdbcType.Decimal),
                            new OdbcParameter("charges",OdbcType.Decimal),
                            new OdbcParameter("billingIndicator",OdbcType.Decimal),
                            new OdbcParameter("printIndicator",OdbcType.Decimal),
                            new OdbcParameter("subject",OdbcType.VarChar),
                            new OdbcParameter("barcode",OdbcType.VarChar)
                        };
                    }
                    else
                    {
                        if (sqlParms == "UpdateMedLabTestMaster")
                        {
                            parms = new OdbcParameter[]{
                                new OdbcParameter("priorityIndicator",OdbcType.Decimal), 
                                new OdbcParameter("patientId",OdbcType.VarChar), 
                                new OdbcParameter("visitId",OdbcType.Decimal), 
                                new OdbcParameter("workingId",OdbcType.VarChar), 
                                new OdbcParameter("executeDate",OdbcType.DateTime), 
                                new OdbcParameter("name",OdbcType.VarChar), 
                                new OdbcParameter("namePhonetic",OdbcType.VarChar), 
                                new OdbcParameter("chargeType",OdbcType.VarChar), 
                                new OdbcParameter("sex",OdbcType.VarChar), 
                                new OdbcParameter("age",OdbcType.Decimal), 
                                new OdbcParameter("testCause",OdbcType.VarChar),
                                new OdbcParameter("relevantClinicDiag",OdbcType.VarChar),
                                new OdbcParameter("specimen",OdbcType.VarChar),
                                new OdbcParameter("notesForSpcm",OdbcType.VarChar),
                                new OdbcParameter("spcmReceivedDateTime",OdbcType.DateTime),
                                new OdbcParameter("spcmSampleDateTime",OdbcType.DateTime),
                                new OdbcParameter("requestedDateTime",OdbcType.DateTime),
                                new OdbcParameter("orderingDept",OdbcType.VarChar),
                                new OdbcParameter("orderingProvider",OdbcType.VarChar),
                                new OdbcParameter("performedBy",OdbcType.VarChar),
                                new OdbcParameter("resultStatus",OdbcType.VarChar),
                                new OdbcParameter("resultsRptDateTime",OdbcType.DateTime),
                                new OdbcParameter("transcriptionist",OdbcType.VarChar),
                                new OdbcParameter("verifiedBy",OdbcType.VarChar),
                                new OdbcParameter("costs",OdbcType.Decimal),
                                new OdbcParameter("charges",OdbcType.Decimal),
                                new OdbcParameter("billingIndicator",OdbcType.Decimal),
                                new OdbcParameter("printIndicator",OdbcType.Decimal),
                                new OdbcParameter("subject",OdbcType.VarChar),
                                new OdbcParameter("barcode",OdbcType.VarChar),
                                new OdbcParameter("testNo",OdbcType.VarChar)
                            };
                        }
                    }
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedLabTestMaster SelectMedLabTestMasterOdbc(string testNo)
        {
            Model.MedLabTestMaster medLabTestMaster = null;

            OdbcParameter[] mdPats = GetParameterOdbc("SelectMedLabTestMaster");
            mdPats[0].Value = testNo;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_Med_Lab_Test_Master_Odbc, mdPats))
            {
                if (OdbcReader.Read())
                {
                    medLabTestMaster = new Model.MedLabTestMaster();
                    medLabTestMaster.TestNo = OdbcReader.GetString(0);
                    if (!OdbcReader.IsDBNull(1))
                        medLabTestMaster.PriorityIndicator = OdbcReader.GetDecimal(1);
                    if (!OdbcReader.IsDBNull(2))
                        medLabTestMaster.PatientId = OdbcReader.GetString(2);
                    if (!OdbcReader.IsDBNull(3))
                        medLabTestMaster.VisitId = OdbcReader.GetDecimal(3);
                    if (!OdbcReader.IsDBNull(4))
                        medLabTestMaster.WorkingId = OdbcReader.GetString(4);
                    if (!OdbcReader.IsDBNull(5))
                        medLabTestMaster.ExecuteDate = OdbcReader.GetDateTime(5);
                    if (!OdbcReader.IsDBNull(6))
                        medLabTestMaster.Name = OdbcReader.GetString(6);
                    if (!OdbcReader.IsDBNull(7))
                        medLabTestMaster.NamePhonetic = OdbcReader.GetString(7);
                    if (!OdbcReader.IsDBNull(8))
                        medLabTestMaster.ChargeType = OdbcReader.GetString(8);
                    if (!OdbcReader.IsDBNull(9))
                        medLabTestMaster.Sex = OdbcReader.GetString(9);
                    if (!OdbcReader.IsDBNull(10))
                        medLabTestMaster.Age = OdbcReader.GetDecimal(10);
                    if (!OdbcReader.IsDBNull(11))
                        medLabTestMaster.TestCause = OdbcReader.GetString(11);
                    if (!OdbcReader.IsDBNull(12))
                        medLabTestMaster.RelevantClinicDiag = OdbcReader.GetString(12);
                    if (!OdbcReader.IsDBNull(13))
                        medLabTestMaster.Specimen = OdbcReader.GetString(13);
                    if (!OdbcReader.IsDBNull(14))
                        medLabTestMaster.NotesForSpcm = OdbcReader.GetString(14);
                    if (!OdbcReader.IsDBNull(15))
                        medLabTestMaster.SpcmReceivedDateTime = OdbcReader.GetDateTime(15);
                    if (!OdbcReader.IsDBNull(16))
                        medLabTestMaster.SpcmSampleDateTime = OdbcReader.GetDateTime(16);
                    if (!OdbcReader.IsDBNull(17))
                        medLabTestMaster.RequestedDateTime = OdbcReader.GetDateTime(17);
                    if (!OdbcReader.IsDBNull(18))
                        medLabTestMaster.OrderingDept = OdbcReader.GetString(18);
                    if (!OdbcReader.IsDBNull(19))
                        medLabTestMaster.OrderingProvider = OdbcReader.GetString(19);
                    if (!OdbcReader.IsDBNull(20))
                        medLabTestMaster.PerformedBy = OdbcReader.GetString(20);
                    if (!OdbcReader.IsDBNull(21))
                        medLabTestMaster.ResultStatus = OdbcReader.GetString(21);
                    if (!OdbcReader.IsDBNull(22))
                        medLabTestMaster.ResultsRptDateTime = OdbcReader.GetDateTime(22);
                    if (!OdbcReader.IsDBNull(23))
                        medLabTestMaster.Transcriptionist = OdbcReader.GetString(23);
                    if (!OdbcReader.IsDBNull(24))
                        medLabTestMaster.VerifiedBy = OdbcReader.GetString(24);
                    if (!OdbcReader.IsDBNull(25))
                        medLabTestMaster.Costs = OdbcReader.GetDecimal(25);
                    if (!OdbcReader.IsDBNull(26))
                        medLabTestMaster.Charges = OdbcReader.GetDecimal(26);
                    if (!OdbcReader.IsDBNull(27))
                        medLabTestMaster.BillingIndicator = OdbcReader.GetDecimal(27);
                    if (!OdbcReader.IsDBNull(28))
                        medLabTestMaster.PrintIndicator = OdbcReader.GetDecimal(28);
                    if (!OdbcReader.IsDBNull(29))
                        medLabTestMaster.Subject = OdbcReader.GetString(29);
                    if (!OdbcReader.IsDBNull(30))
                        medLabTestMaster.Barcode = OdbcReader.GetString(30);
                }
                else
                    medLabTestMaster = null;
            }
            return medLabTestMaster;
        }

        public int InsertMedLabTestMasterOdbc(Model.MedLabTestMaster MedLabTestMaster)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedLabTestMaster");
                oneInert[0].Value = MedLabTestMaster.TestNo;
                if (MedLabTestMaster.PriorityIndicator.ToString() != null)
                    oneInert[1].Value = MedLabTestMaster.PriorityIndicator;
                else
                    oneInert[1].Value = DBNull.Value;
                if (MedLabTestMaster.PatientId != null)
                    oneInert[2].Value = MedLabTestMaster.PatientId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (MedLabTestMaster.VisitId.ToString() != null)
                    oneInert[3].Value = MedLabTestMaster.VisitId;
                else
                    oneInert[3].Value = DBNull.Value;
                if (MedLabTestMaster.WorkingId != null)
                    oneInert[4].Value = MedLabTestMaster.WorkingId;
                else
                    oneInert[4].Value = DBNull.Value;
                if (MedLabTestMaster.ExecuteDate > DateTime.MinValue)
                    oneInert[5].Value = MedLabTestMaster.ExecuteDate;
                else
                    oneInert[5].Value = DBNull.Value;
                if (MedLabTestMaster.Name != null)
                    oneInert[6].Value = MedLabTestMaster.Name;
                else
                    oneInert[6].Value = DBNull.Value;
                if (MedLabTestMaster.NamePhonetic != null)
                    oneInert[7].Value = MedLabTestMaster.NamePhonetic;
                else
                    oneInert[7].Value = DBNull.Value;
                if (MedLabTestMaster.ChargeType != null)
                    oneInert[8].Value = MedLabTestMaster.ChargeType;
                else
                    oneInert[8].Value = DBNull.Value;
                if (MedLabTestMaster.Sex != null)
                    oneInert[9].Value = MedLabTestMaster.Sex;
                else
                    oneInert[9].Value = DBNull.Value;
                if (MedLabTestMaster.Age.ToString() != null)
                    oneInert[10].Value = MedLabTestMaster.Age;
                else
                    oneInert[10].Value = DBNull.Value;
                if (MedLabTestMaster.TestCause != null)
                    oneInert[11].Value = MedLabTestMaster.TestCause;
                else
                    oneInert[11].Value = DBNull.Value;
                if (MedLabTestMaster.RelevantClinicDiag != null)
                    oneInert[12].Value = MedLabTestMaster.RelevantClinicDiag;
                else
                    oneInert[12].Value = DBNull.Value;
                if (MedLabTestMaster.Specimen != null)
                    oneInert[13].Value = MedLabTestMaster.Specimen;
                else
                    oneInert[13].Value = DBNull.Value;
                if (MedLabTestMaster.NotesForSpcm != null)
                    oneInert[14].Value = MedLabTestMaster.NotesForSpcm;
                else
                    oneInert[14].Value = DBNull.Value;
                if (MedLabTestMaster.SpcmReceivedDateTime > DateTime.MinValue)
                    oneInert[15].Value = MedLabTestMaster.SpcmReceivedDateTime;
                else
                    oneInert[15].Value = DBNull.Value;
                if (MedLabTestMaster.SpcmSampleDateTime > DateTime.MinValue)
                    oneInert[16].Value = MedLabTestMaster.SpcmSampleDateTime;
                else
                    oneInert[16].Value = DBNull.Value;
                if (MedLabTestMaster.RequestedDateTime > DateTime.MinValue)
                    oneInert[17].Value = MedLabTestMaster.RequestedDateTime;
                else
                    oneInert[17].Value = DBNull.Value;
                if (MedLabTestMaster.OrderingDept != null)
                    oneInert[18].Value = MedLabTestMaster.OrderingDept;
                else
                    oneInert[18].Value = DBNull.Value;
                if (MedLabTestMaster.OrderingProvider != null)
                    oneInert[19].Value = MedLabTestMaster.OrderingProvider;
                else
                    oneInert[19].Value = DBNull.Value;
                if (MedLabTestMaster.PerformedBy != null)
                    oneInert[20].Value = MedLabTestMaster.PerformedBy;
                else
                    oneInert[20].Value = DBNull.Value;
                if (MedLabTestMaster.ResultStatus != null)
                    oneInert[21].Value = MedLabTestMaster.ResultStatus;
                else
                    oneInert[21].Value = DBNull.Value;
                if (MedLabTestMaster.ResultsRptDateTime > DateTime.MinValue)
                    oneInert[22].Value = MedLabTestMaster.ResultsRptDateTime;
                else
                    oneInert[22].Value = DBNull.Value;
                if (MedLabTestMaster.Transcriptionist != null)
                    oneInert[23].Value = MedLabTestMaster.Transcriptionist;
                else
                    oneInert[23].Value = DBNull.Value;
                if (MedLabTestMaster.VerifiedBy != null)
                    oneInert[24].Value = MedLabTestMaster.VerifiedBy;
                else
                    oneInert[24].Value = DBNull.Value;
                if (MedLabTestMaster.Costs.ToString() != null)
                    oneInert[25].Value = MedLabTestMaster.Costs;
                else
                    oneInert[25].Value = DBNull.Value;
                if (MedLabTestMaster.Charges.ToString() != null)
                    oneInert[26].Value = MedLabTestMaster.Charges;
                else
                    oneInert[26].Value = DBNull.Value;
                if (MedLabTestMaster.BillingIndicator.ToString() != null)
                    oneInert[27].Value = MedLabTestMaster.BillingIndicator;
                else
                    oneInert[27].Value = DBNull.Value;
                if (MedLabTestMaster.PrintIndicator.ToString() != null)
                    oneInert[28].Value = MedLabTestMaster.PrintIndicator;
                else
                    oneInert[28].Value = DBNull.Value;
                if (MedLabTestMaster.Subject != null)
                    oneInert[29].Value = MedLabTestMaster.Subject;
                else
                    oneInert[29].Value = DBNull.Value;
                if (MedLabTestMaster.Barcode != null)
                    oneInert[30].Value = MedLabTestMaster.Barcode;
                else
                    oneInert[30].Value = DBNull.Value;


                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_Med_Lab_Test_Master_Odbc, oneInert);
            }
        }

        public int UpdateMedLabTestMasterOdbc(Model.MedLabTestMaster MedLabTestMaster)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedLabTestMaster");
                if (MedLabTestMaster.PriorityIndicator.ToString() != null)
                    oneUpdate[0].Value = MedLabTestMaster.PriorityIndicator;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (MedLabTestMaster.PatientId != null)
                    oneUpdate[1].Value = MedLabTestMaster.PatientId;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (MedLabTestMaster.VisitId.ToString() != null)
                    oneUpdate[2].Value = MedLabTestMaster.VisitId;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (MedLabTestMaster.WorkingId != null)
                    oneUpdate[3].Value = MedLabTestMaster.WorkingId;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (MedLabTestMaster.ExecuteDate > DateTime.MinValue)
                    oneUpdate[4].Value = MedLabTestMaster.ExecuteDate;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (MedLabTestMaster.Name != null)
                    oneUpdate[5].Value = MedLabTestMaster.Name;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (MedLabTestMaster.NamePhonetic != null)
                    oneUpdate[6].Value = MedLabTestMaster.NamePhonetic;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (MedLabTestMaster.ChargeType != null)
                    oneUpdate[7].Value = MedLabTestMaster.ChargeType;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (MedLabTestMaster.Sex != null)
                    oneUpdate[8].Value = MedLabTestMaster.Sex;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (MedLabTestMaster.Age.ToString() != null)
                    oneUpdate[9].Value = MedLabTestMaster.Age;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (MedLabTestMaster.TestCause != null)
                    oneUpdate[10].Value = MedLabTestMaster.TestCause;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (MedLabTestMaster.RelevantClinicDiag != null)
                    oneUpdate[11].Value = MedLabTestMaster.RelevantClinicDiag;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (MedLabTestMaster.Specimen != null)
                    oneUpdate[12].Value = MedLabTestMaster.Specimen;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (MedLabTestMaster.NotesForSpcm != null)
                    oneUpdate[13].Value = MedLabTestMaster.NotesForSpcm;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (MedLabTestMaster.SpcmReceivedDateTime > DateTime.MinValue)
                    oneUpdate[14].Value = MedLabTestMaster.SpcmReceivedDateTime;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (MedLabTestMaster.SpcmSampleDateTime > DateTime.MinValue)
                    oneUpdate[15].Value = MedLabTestMaster.SpcmSampleDateTime;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (MedLabTestMaster.RequestedDateTime > DateTime.MinValue)
                    oneUpdate[16].Value = MedLabTestMaster.RequestedDateTime;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (MedLabTestMaster.OrderingDept != null)
                    oneUpdate[17].Value = MedLabTestMaster.OrderingDept;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (MedLabTestMaster.OrderingProvider != null)
                    oneUpdate[18].Value = MedLabTestMaster.OrderingProvider;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (MedLabTestMaster.PerformedBy != null)
                    oneUpdate[19].Value = MedLabTestMaster.PerformedBy;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (MedLabTestMaster.ResultStatus != null)
                    oneUpdate[20].Value = MedLabTestMaster.ResultStatus;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (MedLabTestMaster.ResultsRptDateTime > DateTime.MinValue)
                    oneUpdate[21].Value = MedLabTestMaster.ResultsRptDateTime;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (MedLabTestMaster.Transcriptionist != null)
                    oneUpdate[22].Value = MedLabTestMaster.Transcriptionist;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (MedLabTestMaster.VerifiedBy != null)
                    oneUpdate[23].Value = MedLabTestMaster.VerifiedBy;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (MedLabTestMaster.Costs.ToString() != null)
                    oneUpdate[24].Value = MedLabTestMaster.Costs;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (MedLabTestMaster.Charges.ToString() != null)
                    oneUpdate[25].Value = MedLabTestMaster.Charges;
                else
                    oneUpdate[25].Value = DBNull.Value;
                if (MedLabTestMaster.BillingIndicator.ToString() != null)
                    oneUpdate[26].Value = MedLabTestMaster.BillingIndicator;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (MedLabTestMaster.PrintIndicator.ToString() != null)
                    oneUpdate[27].Value = MedLabTestMaster.PrintIndicator;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (MedLabTestMaster.Subject != null)
                    oneUpdate[28].Value = MedLabTestMaster.Subject;
                else
                    oneUpdate[28].Value = DBNull.Value;
                if (MedLabTestMaster.Barcode != null)
                    oneUpdate[29].Value = MedLabTestMaster.Barcode;
                else
                    oneUpdate[29].Value = DBNull.Value;
                oneUpdate[30].Value = MedLabTestMaster.TestNo;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_Med_Lab_Test_Master_Odbc, oneUpdate);
            }
        }
	}
}
