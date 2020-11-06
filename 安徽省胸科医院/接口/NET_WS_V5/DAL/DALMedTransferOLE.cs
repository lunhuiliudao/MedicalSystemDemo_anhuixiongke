using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using MedicalSytem.Soft.Model;

namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedTransfer
    /// </summary>

    public partial class DALMedTransfer
    {
        private static readonly string Select_MedTransfer_OLE = "SELECT patient_id, visit_id, dept_stayed, admission_date_time, discharge_date_time, dept_transfered_to, doctor_in_charge, ward_stayed, ward_transfered_to, reserved1, bed_no, reserved2, reserved3 FROM MED_TRANSFER WHERE PATIENT_ID = ? AND VISIT_ID = ? AND admission_date_time = ? ";
        private static readonly string Insert_MedTransfer_OLE = "INSERT INTO MED_TRANSFER(patient_id, visit_id, dept_stayed, admission_date_time, discharge_date_time, dept_transfered_to, doctor_in_charge, ward_stayed, ward_transfered_to, reserved1, bed_no, reserved2, reserved3) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?) ";
        private static readonly string Update_MedTransfer_OLE = "UPDATE MED_TRANSFER SET dept_stayed = ?,discharge_date_time = ?,dept_transfered_to = ?,doctor_in_charge = ?,ward_stayed = ?,ward_transfered_to = ?,reserved1 = ?,bed_no = ?,reserved2 = ?,reserved3 = ? WHERE PATIENT_ID = ? AND VISIT_ID = ? AND admission_date_time = ? ";

        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedTransfer")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("admissionDateTime",OleDbType.DBTimeStamp)
                    };
                }
                else if (sqlParms == "InsertMedTransfer")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("deptStayed",OleDbType.VarChar), 
                        new OleDbParameter("admissionDateTime",OleDbType.DBTimeStamp), 
                        new OleDbParameter("dischargeDateTime",OleDbType.DBTimeStamp),
                        new OleDbParameter("deptTransferedTo",OleDbType.VarChar), 
                        new OleDbParameter("doctorInCharge",OleDbType.VarChar), 
                        new OleDbParameter("wardStayed",OleDbType.VarChar), 
                        new OleDbParameter("wardTransferedTo",OleDbType.VarChar), 
                        new OleDbParameter("reserved1",OleDbType.VarChar), 
                        new OleDbParameter("bedNo",OleDbType.VarChar), 
                        new OleDbParameter("reserved2",OleDbType.VarChar), 
                        new OleDbParameter("reserved3",OleDbType.DBTimeStamp)
                    };
                }
                else if (sqlParms == "UpdateMedTransfer")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("deptStayed",OleDbType.VarChar), 
                        new OleDbParameter("dischargeDateTime",OleDbType.DBTimeStamp),
                        new OleDbParameter("deptTransferedTo",OleDbType.VarChar), 
                        new OleDbParameter("doctorInCharge",OleDbType.VarChar), 
                        new OleDbParameter("wardStayed",OleDbType.VarChar), 
                        new OleDbParameter("wardTransferedTo",OleDbType.VarChar), 
                        new OleDbParameter("reserved1",OleDbType.VarChar), 
                        new OleDbParameter("bedNo",OleDbType.VarChar), 
                        new OleDbParameter("reserved2",OleDbType.VarChar), 
                        new OleDbParameter("reserved3",OleDbType.DBTimeStamp),
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("admissionDateTime",OleDbType.DBTimeStamp)
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedTransfer SelectMedTransferOLE(string patientId, decimal visitId, DateTime admissionDateTime)
        {
            Model.MedTransfer medTransfer = null;

            OleDbParameter[] transferParm = GetParameterOLE("SelectMedTransfer");
            transferParm[0].Value = patientId;
            transferParm[1].Value = visitId;
            transferParm[2].Value = admissionDateTime;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedTransfer_OLE, transferParm))
            {
                if (oleReader.Read())
                {
                    medTransfer = new Model.MedTransfer();
                    medTransfer.PatientId = oleReader.GetString(0);
                    medTransfer.VisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        medTransfer.DeptStayed = oleReader.GetString(2);
                    medTransfer.AdmissionDateTime = oleReader.GetDateTime(3);
                    if (!oleReader.IsDBNull(4))
                        medTransfer.DischargeDateTime = oleReader.GetDateTime(4);
                    if (!oleReader.IsDBNull(5))
                        medTransfer.DeptTransferedTo = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        medTransfer.DoctorInCharge = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        medTransfer.WardStayed = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        medTransfer.WardTransferedTo = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        medTransfer.Reserved1 = oleReader.GetDecimal(9);
                    if (!oleReader.IsDBNull(10))
                        medTransfer.BedNo = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        medTransfer.Reserved2 = oleReader.GetDecimal(11);
                    if (!oleReader.IsDBNull(12))
                        medTransfer.Reserved3 = oleReader.GetDateTime(12);
                }
                else
                    medTransfer = null;
            }
            return medTransfer;
        }

        public int InsertMedTransferOLE(Model.MedTransfer MedTransfer)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedTransfer");
                oneInert[0].Value = MedTransfer.PatientId;
                oneInert[1].Value = MedTransfer.VisitId;
                if (MedTransfer.DeptStayed != null)
                    oneInert[2].Value = MedTransfer.DeptStayed;
                else
                    oneInert[2].Value = DBNull.Value;
                if (MedTransfer.AdmissionDateTime > DateTime.MinValue)
                    oneInert[3].Value = MedTransfer.AdmissionDateTime;
                else
                    oneInert[3].Value = DBNull.Value;
                if (MedTransfer.DischargeDateTime > DateTime.MinValue)
                    oneInert[4].Value = MedTransfer.DischargeDateTime;
                else
                    oneInert[4].Value = DBNull.Value;
                if (MedTransfer.DeptTransferedTo != null)
                    oneInert[5].Value = MedTransfer.DeptTransferedTo;
                else
                    oneInert[5].Value = DBNull.Value;
                if (MedTransfer.DoctorInCharge != null)
                    oneInert[6].Value = MedTransfer.DoctorInCharge;
                else
                    oneInert[6].Value = DBNull.Value;
                if (MedTransfer.WardStayed != null)
                    oneInert[7].Value = MedTransfer.WardStayed;
                else
                    oneInert[7].Value = DBNull.Value;
                if (MedTransfer.WardTransferedTo != null)
                    oneInert[8].Value = MedTransfer.WardTransferedTo;
                else
                    oneInert[8].Value = DBNull.Value;
                if (MedTransfer.Reserved1.ToString() != null)
                    oneInert[9].Value = MedTransfer.Reserved1;
                else
                    oneInert[9].Value = DBNull.Value;
                if (MedTransfer.BedNo != null)
                    oneInert[10].Value = MedTransfer.BedNo;
                else
                    oneInert[10].Value = DBNull.Value;
                if (MedTransfer.Reserved2.ToString() != null)
                    oneInert[11].Value = MedTransfer.Reserved2;
                else
                    oneInert[11].Value = DBNull.Value;
                if (MedTransfer.Reserved3 > DateTime.MinValue)
                    oneInert[12].Value = MedTransfer.Reserved3;
                else
                    oneInert[12].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_MedTransfer_OLE, oneInert);
            }
        }

        public int UpdateMedTransferOLE(Model.MedTransfer MedTransfer)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedTransfer");
                if (MedTransfer.DeptStayed != null)
                    oneUpdate[0].Value = MedTransfer.DeptStayed;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (MedTransfer.DischargeDateTime > DateTime.MinValue)
                    oneUpdate[1].Value = MedTransfer.DischargeDateTime;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (MedTransfer.DeptTransferedTo != null)
                    oneUpdate[2].Value = MedTransfer.DeptTransferedTo;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (MedTransfer.DoctorInCharge != null)
                    oneUpdate[3].Value = MedTransfer.DoctorInCharge;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (MedTransfer.WardStayed != null)
                    oneUpdate[4].Value = MedTransfer.WardStayed;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (MedTransfer.WardTransferedTo != null)
                    oneUpdate[5].Value = MedTransfer.WardTransferedTo;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (MedTransfer.Reserved1.ToString() != null)
                    oneUpdate[6].Value = MedTransfer.Reserved1;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (MedTransfer.BedNo != null)
                    oneUpdate[7].Value = MedTransfer.BedNo;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (MedTransfer.Reserved2.ToString() != null)
                    oneUpdate[8].Value = MedTransfer.Reserved2;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (MedTransfer.Reserved3 > DateTime.MinValue)
                    oneUpdate[9].Value = MedTransfer.Reserved3;
                else
                    oneUpdate[9].Value = DBNull.Value;
                oneUpdate[10].Value = MedTransfer.PatientId;
                oneUpdate[11].Value = MedTransfer.VisitId;
                oneUpdate[12].Value = MedTransfer.AdmissionDateTime;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_MedTransfer_OLE, oneUpdate);
            }
        }

        private static readonly string Select_MedTransfer_Odbc = "SELECT patient_id, visit_id, dept_stayed, admission_date_time, discharge_date_time, dept_transfered_to, doctor_in_charge, ward_stayed, ward_transfered_to, reserved1, bed_no, reserved2, reserved3 FROM MED_TRANSFER WHERE PATIENT_ID = ? AND VISIT_ID = ? AND admission_date_time = ? ";
        private static readonly string Insert_MedTransfer_Odbc = "INSERT INTO MED_TRANSFER(patient_id, visit_id, dept_stayed, admission_date_time, discharge_date_time, dept_transfered_to, doctor_in_charge, ward_stayed, ward_transfered_to, reserved1, bed_no, reserved2, reserved3) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?) ";
        private static readonly string Update_MedTransfer_Odbc = "UPDATE MED_TRANSFER SET dept_stayed = ?,discharge_date_time = ?,dept_transfered_to = ?,doctor_in_charge = ?,ward_stayed = ?,ward_transfered_to = ?,reserved1 = ?,bed_no = ?,reserved2 = ?,reserved3 = ? WHERE PATIENT_ID = ? AND VISIT_ID = ? AND admission_date_time = ? ";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedTransfer")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("admissionDateTime",OdbcType.DateTime)
                    };
                }
                else if (sqlParms == "InsertMedTransfer")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("deptStayed",OdbcType.VarChar), 
                        new OdbcParameter("admissionDateTime",OdbcType.DateTime), 
                        new OdbcParameter("dischargeDateTime",OdbcType.DateTime),
                        new OdbcParameter("deptTransferedTo",OdbcType.VarChar), 
                        new OdbcParameter("doctorInCharge",OdbcType.VarChar), 
                        new OdbcParameter("wardStayed",OdbcType.VarChar), 
                        new OdbcParameter("wardTransferedTo",OdbcType.VarChar), 
                        new OdbcParameter("reserved1",OdbcType.VarChar), 
                        new OdbcParameter("bedNo",OdbcType.VarChar), 
                        new OdbcParameter("reserved2",OdbcType.VarChar), 
                        new OdbcParameter("reserved3",OdbcType.DateTime)
                    };
                }
                else if (sqlParms == "UpdateMedTransfer")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("deptStayed",OdbcType.VarChar), 
                        new OdbcParameter("dischargeDateTime",OdbcType.DateTime),
                        new OdbcParameter("deptTransferedTo",OdbcType.VarChar), 
                        new OdbcParameter("doctorInCharge",OdbcType.VarChar), 
                        new OdbcParameter("wardStayed",OdbcType.VarChar), 
                        new OdbcParameter("wardTransferedTo",OdbcType.VarChar), 
                        new OdbcParameter("reserved1",OdbcType.VarChar), 
                        new OdbcParameter("bedNo",OdbcType.VarChar), 
                        new OdbcParameter("reserved2",OdbcType.VarChar), 
                        new OdbcParameter("reserved3",OdbcType.DateTime),
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("admissionDateTime",OdbcType.DateTime)
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedTransfer SelectMedTransferOdbc(string patientId, decimal visitId, DateTime admissionDateTime)
        {
            Model.MedTransfer medTransfer = null;

            OdbcParameter[] transferParm = GetParameterOdbc("SelectMedTransfer");
            transferParm[0].Value = patientId;
            transferParm[1].Value = visitId;
            transferParm[2].Value = admissionDateTime;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MedTransfer_Odbc, transferParm))
            {
                if (OdbcReader.Read())
                {
                    medTransfer = new Model.MedTransfer();
                    medTransfer.PatientId = OdbcReader.GetString(0);
                    medTransfer.VisitId = OdbcReader.GetDecimal(1);
                    if (!OdbcReader.IsDBNull(2))
                        medTransfer.DeptStayed = OdbcReader.GetString(2);
                    medTransfer.AdmissionDateTime = OdbcReader.GetDateTime(3);
                    if (!OdbcReader.IsDBNull(4))
                        medTransfer.DischargeDateTime = OdbcReader.GetDateTime(4);
                    if (!OdbcReader.IsDBNull(5))
                        medTransfer.DeptTransferedTo = OdbcReader.GetString(5);
                    if (!OdbcReader.IsDBNull(6))
                        medTransfer.DoctorInCharge = OdbcReader.GetString(6);
                    if (!OdbcReader.IsDBNull(7))
                        medTransfer.WardStayed = OdbcReader.GetString(7);
                    if (!OdbcReader.IsDBNull(8))
                        medTransfer.WardTransferedTo = OdbcReader.GetString(8);
                    if (!OdbcReader.IsDBNull(9))
                        medTransfer.Reserved1 = OdbcReader.GetDecimal(9);
                    if (!OdbcReader.IsDBNull(10))
                        medTransfer.BedNo = OdbcReader.GetString(10);
                    if (!OdbcReader.IsDBNull(11))
                        medTransfer.Reserved2 = OdbcReader.GetDecimal(11);
                    if (!OdbcReader.IsDBNull(12))
                        medTransfer.Reserved3 = OdbcReader.GetDateTime(12);
                }
                else
                    medTransfer = null;
            }
            return medTransfer;
        }

        public int InsertMedTransferOdbc(Model.MedTransfer MedTransfer)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedTransfer");
                oneInert[0].Value = MedTransfer.PatientId;
                oneInert[1].Value = MedTransfer.VisitId;
                if (MedTransfer.DeptStayed != null)
                    oneInert[2].Value = MedTransfer.DeptStayed;
                else
                    oneInert[2].Value = DBNull.Value;
                if (MedTransfer.AdmissionDateTime > DateTime.MinValue)
                    oneInert[3].Value = MedTransfer.AdmissionDateTime;
                else
                    oneInert[3].Value = DBNull.Value;
                if (MedTransfer.DischargeDateTime > DateTime.MinValue)
                    oneInert[4].Value = MedTransfer.DischargeDateTime;
                else
                    oneInert[4].Value = DBNull.Value;
                if (MedTransfer.DeptTransferedTo != null)
                    oneInert[5].Value = MedTransfer.DeptTransferedTo;
                else
                    oneInert[5].Value = DBNull.Value;
                if (MedTransfer.DoctorInCharge != null)
                    oneInert[6].Value = MedTransfer.DoctorInCharge;
                else
                    oneInert[6].Value = DBNull.Value;
                if (MedTransfer.WardStayed != null)
                    oneInert[7].Value = MedTransfer.WardStayed;
                else
                    oneInert[7].Value = DBNull.Value;
                if (MedTransfer.WardTransferedTo != null)
                    oneInert[8].Value = MedTransfer.WardTransferedTo;
                else
                    oneInert[8].Value = DBNull.Value;
                if (MedTransfer.Reserved1.ToString() != null)
                    oneInert[9].Value = MedTransfer.Reserved1;
                else
                    oneInert[9].Value = DBNull.Value;
                if (MedTransfer.BedNo != null)
                    oneInert[10].Value = MedTransfer.BedNo;
                else
                    oneInert[10].Value = DBNull.Value;
                if (MedTransfer.Reserved2.ToString() != null)
                    oneInert[11].Value = MedTransfer.Reserved2;
                else
                    oneInert[11].Value = DBNull.Value;
                if (MedTransfer.Reserved3 > DateTime.MinValue)
                    oneInert[12].Value = MedTransfer.Reserved3;
                else
                    oneInert[12].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_MedTransfer_Odbc, oneInert);
            }
        }

        public int UpdateMedTransferOdbc(Model.MedTransfer MedTransfer)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedTransfer");
                if (MedTransfer.DeptStayed != null)
                    oneUpdate[0].Value = MedTransfer.DeptStayed;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (MedTransfer.DischargeDateTime > DateTime.MinValue)
                    oneUpdate[1].Value = MedTransfer.DischargeDateTime;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (MedTransfer.DeptTransferedTo != null)
                    oneUpdate[2].Value = MedTransfer.DeptTransferedTo;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (MedTransfer.DoctorInCharge != null)
                    oneUpdate[3].Value = MedTransfer.DoctorInCharge;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (MedTransfer.WardStayed != null)
                    oneUpdate[4].Value = MedTransfer.WardStayed;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (MedTransfer.WardTransferedTo != null)
                    oneUpdate[5].Value = MedTransfer.WardTransferedTo;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (MedTransfer.Reserved1.ToString() != null)
                    oneUpdate[6].Value = MedTransfer.Reserved1;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (MedTransfer.BedNo != null)
                    oneUpdate[7].Value = MedTransfer.BedNo;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (MedTransfer.Reserved2.ToString() != null)
                    oneUpdate[8].Value = MedTransfer.Reserved2;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (MedTransfer.Reserved3 > DateTime.MinValue)
                    oneUpdate[9].Value = MedTransfer.Reserved3;
                else
                    oneUpdate[9].Value = DBNull.Value;
                oneUpdate[10].Value = MedTransfer.PatientId;
                oneUpdate[11].Value = MedTransfer.VisitId;
                oneUpdate[12].Value = MedTransfer.AdmissionDateTime;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_MedTransfer_Odbc, oneUpdate);
            }
        }
    }
}
