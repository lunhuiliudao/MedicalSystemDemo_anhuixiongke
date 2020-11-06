

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:06:26
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
using System.Data.OleDb;
using System.Data.Odbc;
namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedOperationCanceled
	/// </summary>

    public partial class DALMedOperationCanceled
    {

        private static readonly string Select_Max_CanceledId_Med_Operation_Canceled_OLE = "select nvl(max(cancel_id),0) from med_operation_canceled where patient_id = ? and visit_id = ?";

        private static readonly string Select_One_CanceledId_Med_Operation_Canceled_OLE = @"select PATIENT_ID,VISIT_ID,CANCEL_ID,DEPT_STAYED,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,DIAG_BEFORE_OPERATION,
                                                                                            PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,
                                                                                            FOURTH_ASSISTANT ,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,NOTES_ON_OPERATION,ENTERED_BY,CANCEL_REASON
                                                                                            from med_operation_canceled
                                                                                            where patient_id=? and visit_id=? and cancel_id = ?";

        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMaxCanceledIdMedOperationCanceled")
                {
                    parms = new OleDbParameter[]{
                            new OleDbParameter("patientId",OleDbType.VarChar),
                            new OleDbParameter("visitId",OleDbType.Decimal)
                        };
                }
                else if (sqlParms == "SelectOneMedOperationCanceled")
                {
                    parms = new OleDbParameter[]{
                            new OleDbParameter("patientId",OleDbType.VarChar),
                            new OleDbParameter("visitId",OleDbType.Decimal),
                            new OleDbParameter("cancelid",OleDbType.Decimal)
                        };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            
            
            return parms;
        }

        public int SelectMaxCanceledIdOLE(string patientId, decimal visitId)
        {
            OleDbParameter[] medMaxCanceledId = GetParameterOLE("SelectMaxCanceledIdMedOperationCanceled");
            medMaxCanceledId[0].Value = patientId;
            medMaxCanceledId[1].Value = visitId;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_Max_CanceledId_Med_Operation_Canceled_OLE, medMaxCanceledId))
            {
                if (oleReader.Read())
                {
                    return (int)oleReader.GetDecimal(0);
                }
                else
                {
                    return 0;
                }
            }
        }

        public MedOperationCanceled SelectMedOperationCanceledOLE(string patientId, decimal visitId, decimal cancelId)
        {
            Model.MedOperationCanceled oneMedOperationCanceled = null;

            OleDbParameter[] medOperationCanceledParams = GetParameterOLE("SelectOneMedOperationCanceled");
            medOperationCanceledParams[0].Value = patientId;
            medOperationCanceledParams[1].Value = visitId;
            medOperationCanceledParams[2].Value = cancelId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_One_CanceledId_Med_Operation_Canceled_OLE, medOperationCanceledParams))
            {
                if (oleReader.Read())
                {
                    oneMedOperationCanceled = new Model.MedOperationCanceled();
                    oneMedOperationCanceled.PatientId = oleReader.GetString(0);
                    oneMedOperationCanceled.VisitId = oleReader.GetDecimal(1);
                    oneMedOperationCanceled.CancelId = oleReader.GetDecimal(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedOperationCanceled.DeptStayed = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedOperationCanceled.ScheduledDateTime = oleReader.GetDateTime(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedOperationCanceled.OperatingRoom = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedOperationCanceled.OperatingRoomNo = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedOperationCanceled.Sequence = oleReader.GetDecimal(7);
                    if (!oleReader.IsDBNull(8))
                        oneMedOperationCanceled.DiagBeforeOperation = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        oneMedOperationCanceled.PatientCondition = oleReader.GetString(9);
                    if (!oleReader.IsDBNull(10))
                        oneMedOperationCanceled.OperationScale = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        oneMedOperationCanceled.IsolationIndicator = oleReader.GetDecimal(11);
                    if (!oleReader.IsDBNull(12))
                        oneMedOperationCanceled.OperatingDept = oleReader.GetString(12);
                    if (!oleReader.IsDBNull(13))
                        oneMedOperationCanceled.Surgeon = oleReader.GetString(13);
                    if (!oleReader.IsDBNull(14))
                        oneMedOperationCanceled.FirstAssistant = oleReader.GetString(14);
                    if (!oleReader.IsDBNull(15))
                        oneMedOperationCanceled.SecondAssistant = oleReader.GetString(15);
                    if (!oleReader.IsDBNull(16))
                        oneMedOperationCanceled.ThirdAssistant = oleReader.GetString(16);
                    if (!oleReader.IsDBNull(17))
                        oneMedOperationCanceled.FourthAssistant = oleReader.GetString(17);
                    if (!oleReader.IsDBNull(18))
                        oneMedOperationCanceled.AnesthesiaMethod = oleReader.GetString(18);
                    if (!oleReader.IsDBNull(19))
                        oneMedOperationCanceled.AnesthesiaDoctor = oleReader.GetString(19);
                    if (!oleReader.IsDBNull(20))
                        oneMedOperationCanceled.AnesthesiaAssistant = oleReader.GetString(20);
                    if (!oleReader.IsDBNull(21))
                        oneMedOperationCanceled.BloodTranDoctor = oleReader.GetString(21);
                    if (!oleReader.IsDBNull(22))
                        oneMedOperationCanceled.NotesOnOperation = oleReader.GetString(22);
                    if (!oleReader.IsDBNull(23))
                        oneMedOperationCanceled.EnteredBy = oleReader.GetString(23);
                    if (!oleReader.IsDBNull(24))
                        oneMedOperationCanceled.CancelReason = oleReader.GetString(24);
                }
                else
                    oneMedOperationCanceled = null;
            }
            return oneMedOperationCanceled;
        }
        private static readonly string Select_Max_CanceledId_Med_Operation_Canceled_Odbc = "select nvl(max(cancel_id),0) from med_operation_canceled where patient_id = ? and visit_id = ?";

        private static readonly string Select_One_CanceledId_Med_Operation_Canceled_Odbc = @"select PATIENT_ID,VISIT_ID,CANCEL_ID,DEPT_STAYED,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,DIAG_BEFORE_OPERATION,
                                                                                            PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,
                                                                                            FOURTH_ASSISTANT ,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,NOTES_ON_OPERATION,ENTERED_BY,CANCEL_REASON
                                                                                            from med_operation_canceled
                                                                                            where patient_id=? and visit_id=? and cancel_id = ?";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMaxCanceledIdMedOperationCanceled")
                {
                    parms = new OdbcParameter[]{
                            new OdbcParameter("patientId",OdbcType.VarChar),
                            new OdbcParameter("visitId",OdbcType.Decimal)
                        };
                }
                else if (sqlParms == "SelectOneMedOperationCanceled")
                {
                    parms = new OdbcParameter[]{
                            new OdbcParameter("patientId",OdbcType.VarChar),
                            new OdbcParameter("visitId",OdbcType.Decimal),
                            new OdbcParameter("cancelid",OdbcType.Decimal)
                        };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }


            return parms;
        }

        public int SelectMaxCanceledIdOdbc(string patientId, decimal visitId)
        {
            OdbcParameter[] medMaxCanceledId = GetParameterOdbc("SelectMaxCanceledIdMedOperationCanceled");
            medMaxCanceledId[0].Value = patientId;
            medMaxCanceledId[1].Value = visitId;
            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_Max_CanceledId_Med_Operation_Canceled_Odbc, medMaxCanceledId))
            {
                if (OdbcReader.Read())
                {
                    return (int)OdbcReader.GetDecimal(0);
                }
                else
                {
                    return 0;
                }
            }
        }

        public MedOperationCanceled SelectMedOperationCanceledOdbc(string patientId, decimal visitId, decimal cancelId)
        {
            Model.MedOperationCanceled oneMedOperationCanceled = null;

            OdbcParameter[] medOperationCanceledParams = GetParameterOdbc("SelectOneMedOperationCanceled");
            medOperationCanceledParams[0].Value = patientId;
            medOperationCanceledParams[1].Value = visitId;
            medOperationCanceledParams[2].Value = cancelId;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_One_CanceledId_Med_Operation_Canceled_Odbc, medOperationCanceledParams))
            {
                if (OdbcReader.Read())
                {
                    oneMedOperationCanceled = new Model.MedOperationCanceled();
                    oneMedOperationCanceled.PatientId = OdbcReader.GetString(0);
                    oneMedOperationCanceled.VisitId = OdbcReader.GetDecimal(1);
                    oneMedOperationCanceled.CancelId = OdbcReader.GetDecimal(2);
                    if (!OdbcReader.IsDBNull(3))
                        oneMedOperationCanceled.DeptStayed = OdbcReader.GetString(3);
                    if (!OdbcReader.IsDBNull(4))
                        oneMedOperationCanceled.ScheduledDateTime = OdbcReader.GetDateTime(4);
                    if (!OdbcReader.IsDBNull(5))
                        oneMedOperationCanceled.OperatingRoom = OdbcReader.GetString(5);
                    if (!OdbcReader.IsDBNull(6))
                        oneMedOperationCanceled.OperatingRoomNo = OdbcReader.GetString(6);
                    if (!OdbcReader.IsDBNull(7))
                        oneMedOperationCanceled.Sequence = OdbcReader.GetDecimal(7);
                    if (!OdbcReader.IsDBNull(8))
                        oneMedOperationCanceled.DiagBeforeOperation = OdbcReader.GetString(8);
                    if (!OdbcReader.IsDBNull(9))
                        oneMedOperationCanceled.PatientCondition = OdbcReader.GetString(9);
                    if (!OdbcReader.IsDBNull(10))
                        oneMedOperationCanceled.OperationScale = OdbcReader.GetString(10);
                    if (!OdbcReader.IsDBNull(11))
                        oneMedOperationCanceled.IsolationIndicator = OdbcReader.GetDecimal(11);
                    if (!OdbcReader.IsDBNull(12))
                        oneMedOperationCanceled.OperatingDept = OdbcReader.GetString(12);
                    if (!OdbcReader.IsDBNull(13))
                        oneMedOperationCanceled.Surgeon = OdbcReader.GetString(13);
                    if (!OdbcReader.IsDBNull(14))
                        oneMedOperationCanceled.FirstAssistant = OdbcReader.GetString(14);
                    if (!OdbcReader.IsDBNull(15))
                        oneMedOperationCanceled.SecondAssistant = OdbcReader.GetString(15);
                    if (!OdbcReader.IsDBNull(16))
                        oneMedOperationCanceled.ThirdAssistant = OdbcReader.GetString(16);
                    if (!OdbcReader.IsDBNull(17))
                        oneMedOperationCanceled.FourthAssistant = OdbcReader.GetString(17);
                    if (!OdbcReader.IsDBNull(18))
                        oneMedOperationCanceled.AnesthesiaMethod = OdbcReader.GetString(18);
                    if (!OdbcReader.IsDBNull(19))
                        oneMedOperationCanceled.AnesthesiaDoctor = OdbcReader.GetString(19);
                    if (!OdbcReader.IsDBNull(20))
                        oneMedOperationCanceled.AnesthesiaAssistant = OdbcReader.GetString(20);
                    if (!OdbcReader.IsDBNull(21))
                        oneMedOperationCanceled.BloodTranDoctor = OdbcReader.GetString(21);
                    if (!OdbcReader.IsDBNull(22))
                        oneMedOperationCanceled.NotesOnOperation = OdbcReader.GetString(22);
                    if (!OdbcReader.IsDBNull(23))
                        oneMedOperationCanceled.EnteredBy = OdbcReader.GetString(23);
                    if (!OdbcReader.IsDBNull(24))
                        oneMedOperationCanceled.CancelReason = OdbcReader.GetString(24);
                }
                else
                    oneMedOperationCanceled = null;
            }
            return oneMedOperationCanceled;
        }
    }
}
