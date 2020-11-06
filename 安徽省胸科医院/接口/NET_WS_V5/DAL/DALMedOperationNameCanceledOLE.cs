

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:07:32
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
	/// DAL MedOperationName
	/// </summary>

    public partial class DALMedOperationNameCanceled
	{

        private static readonly string Select_One_Med_Operation_Name_Canceled_OLE = "select patient_id, visit_id, cancel_id, operation_no, operation, operation_code, operation_scale, reserved1, reserved2, reserved3, reserved4, reserved5 from med_operation_name_canceled where patient_id = ? and visit_id = ? and cancel_id = ? and operation_no = ? ";
        private static readonly string Select_One_Med_Operation_Name_Canceled_OperId_OLE = "select patient_id, visit_id, cancel_id, operation_no, operation, operation_code, operation_scale, reserved1, reserved2, reserved3, reserved4, reserved5 from med_operation_name_canceled where patient_id = ? and visit_id = ? and cancel_id = ? ";
        private static readonly string Select_Med_Operation_Name_Canceled_OLE = "select patient_id, visit_id, cancel_id, operation_no, operation, operation_code, operation_scale, reserved1, reserved2, reserved3, reserved4, reserved5 from med_operation_name_canceled where patient_id = ? and visit_id = ? ";
        private static readonly string Insert_Med_Operation_Name_Canceled_OLE = "insert into med_operation_name_canceled (patient_id, visit_id, cancel_id, operation_no, operation, operation_code, operation_scale, reserved1, reserved2, reserved3, reserved4, reserved5)values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private static readonly string Update_Med_Operation_Name_Canceled_OLE = "update med_operation_name_canceled set operation = ?,operation_code = ?,operation_scale = ?,reserved1 = ?, reserved2 = ?,reserved3 = ?,reserved4 = ?,reserved5 = ? where patient_id = ? and visit_id = ? and cancel_id = ? and operation_no = ?";
        
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectOneMedOperationNameCanceled")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("cancelId",OleDbType.Decimal),
                        new OleDbParameter("operationNo",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "SelectPatMedOperationNameCanceled")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "InsertMedOperationNameCanceled")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal), 
                        new OleDbParameter("cancelId",OleDbType.Decimal), 
                        new OleDbParameter("operationNo",OleDbType.Decimal), 
                        new OleDbParameter("operation",OleDbType.VarChar), 
                        new OleDbParameter("operationCode",OleDbType.VarChar), 
                        new OleDbParameter("operationScale",OleDbType.VarChar), 
                        new OleDbParameter("reserved1",OleDbType.VarChar), 
                        new OleDbParameter("reserved2",OleDbType.VarChar), 
                        new OleDbParameter("reserved3",OleDbType.VarChar), 
                        new OleDbParameter("reserved4",OleDbType.VarChar), 
                        new OleDbParameter("reserved5",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "UpdateMedOperationNameCanceled")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("operation",OleDbType.VarChar), 
                        new OleDbParameter("operationCode",OleDbType.VarChar), 
                        new OleDbParameter("operationScale",OleDbType.VarChar), 
                        new OleDbParameter("reserved1",OleDbType.VarChar), 
                        new OleDbParameter("reserved2",OleDbType.VarChar), 
                        new OleDbParameter("reserved3",OleDbType.VarChar), 
                        new OleDbParameter("reserved4",OleDbType.VarChar), 
                        new OleDbParameter("reserved5",OleDbType.Decimal),
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal), 
                        new OleDbParameter("cancelId",OleDbType.Decimal), 
                        new OleDbParameter("operationNo",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "SelectOneMedOperationNameCanceledOperId")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("cancelId",OleDbType.Decimal),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedOperationNameCanceled SelectMedOperationNameCanceledOLE(string patientId, decimal visitId, decimal canceledId, decimal operationNo)
        {
            Model.MedOperationNameCanceled oneMedOperationName = null;

            OleDbParameter[] medOperationNameParams = GetParameterOLE("SelectOneMedOperationNameCanceled");
            medOperationNameParams[0].Value = patientId;
            medOperationNameParams[1].Value = visitId;
            medOperationNameParams[2].Value = canceledId;
            medOperationNameParams[3].Value = operationNo;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_One_Med_Operation_Name_Canceled_OLE, medOperationNameParams))
            {
                if (oleReader.Read())
                {
                    oneMedOperationName = new Model.MedOperationNameCanceled();
                    oneMedOperationName.PatientId = oleReader.GetString(0);
                    oneMedOperationName.VisitId = oleReader.GetDecimal(1);
                    oneMedOperationName.CancelId = oleReader.GetDecimal(2);
                    oneMedOperationName.OperationNo = oleReader.GetDecimal(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedOperationName.Operation = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedOperationName.OperationCode = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedOperationName.OperationScale = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedOperationName.Reserved1 = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        oneMedOperationName.Reserved2 = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        oneMedOperationName.Reserved3 = oleReader.GetString(9);
                    if (!oleReader.IsDBNull(10))
                        oneMedOperationName.Reserved4 = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        oneMedOperationName.Reserved5 = oleReader.GetDecimal(11);

                }
                else
                    oneMedOperationName = null;
            }
            return oneMedOperationName;
        }

        public List<Model.MedOperationNameCanceled> SelectMedOperationNameCanceledOLE(string patientId, decimal visitId, decimal canceledId)
        {
            List<Model.MedOperationNameCanceled> MedOperationNameList = new List<Model.MedOperationNameCanceled>();

            OleDbParameter[] medOperationNameParams = GetParameterOLE("SelectOneMedOperationNameCanceledOperId");
            medOperationNameParams[0].Value = patientId;
            medOperationNameParams[1].Value = visitId;
            medOperationNameParams[2].Value = canceledId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_One_Med_Operation_Name_Canceled_OperId_OLE, medOperationNameParams))
            {
                while (oleReader.Read())
                {
                    Model.MedOperationNameCanceled oneMedOperationName = new Model.MedOperationNameCanceled();
                    oneMedOperationName.PatientId = oleReader.GetString(0);
                    oneMedOperationName.VisitId = oleReader.GetDecimal(1);
                    oneMedOperationName.CancelId = oleReader.GetDecimal(2);
                    oneMedOperationName.OperationNo = oleReader.GetDecimal(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedOperationName.Operation = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedOperationName.OperationCode = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedOperationName.OperationScale = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedOperationName.Reserved1 = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        oneMedOperationName.Reserved2 = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        oneMedOperationName.Reserved3 = oleReader.GetString(9);
                    if (!oleReader.IsDBNull(10))
                        oneMedOperationName.Reserved4 = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        oneMedOperationName.Reserved5 = oleReader.GetDecimal(11);
                    MedOperationNameList.Add(oneMedOperationName);
                }

            }
            return MedOperationNameList;
        }

        public List<Model.MedOperationNameCanceled> SelectMedOperationNameCanceledOLE(string patientId, decimal visitId)
        {
            List<Model.MedOperationNameCanceled> MedOperationNameList = new List<Model.MedOperationNameCanceled>();

            OleDbParameter[] operationName = GetParameterOLE("SelectPatMedOperationName");
            operationName[0].Value = patientId;
            operationName[1].Value = visitId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_Med_Operation_Name_Canceled_OLE, operationName))
            {
                while (oleReader.Read())
                {
                    Model.MedOperationNameCanceled oneMedOperationNameCancelId = new Model.MedOperationNameCanceled();
                    oneMedOperationNameCancelId = new Model.MedOperationNameCanceled();
                    oneMedOperationNameCancelId.PatientId = oleReader.GetString(0);
                    oneMedOperationNameCancelId.VisitId = oleReader.GetDecimal(1);
                    oneMedOperationNameCancelId.CancelId = oleReader.GetDecimal(2);
                    oneMedOperationNameCancelId.OperationNo = oleReader.GetDecimal(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedOperationNameCancelId.Operation = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedOperationNameCancelId.OperationCode = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedOperationNameCancelId.OperationScale = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedOperationNameCancelId.Reserved1 = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        oneMedOperationNameCancelId.Reserved2 = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        oneMedOperationNameCancelId.Reserved3 = oleReader.GetString(9);
                    if (!oleReader.IsDBNull(10))
                        oneMedOperationNameCancelId.Reserved4 = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        oneMedOperationNameCancelId.Reserved5 = oleReader.GetDecimal(11);
                    MedOperationNameList.Add(oneMedOperationNameCancelId);
                }
            }
            return MedOperationNameList;
        }

        public int InsertMedOperationNameOLE(Model.MedOperationNameCanceled operationNameCanceled)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedOperationName");
                oneInert[0].Value = operationNameCanceled.PatientId;
                oneInert[1].Value = operationNameCanceled.VisitId;
                oneInert[2].Value = operationNameCanceled.CancelId;
                oneInert[3].Value = operationNameCanceled.OperationNo;
                if (operationNameCanceled.Operation != null)
                    oneInert[4].Value = operationNameCanceled.Operation;
                else
                    oneInert[4].Value = DBNull.Value;
                if (operationNameCanceled.OperationCode != null)
                    oneInert[5].Value = operationNameCanceled.OperationCode;
                else
                    oneInert[5].Value = DBNull.Value;
                if (operationNameCanceled.OperationScale != null)
                    oneInert[6].Value = operationNameCanceled.OperationScale;
                else
                    oneInert[6].Value = DBNull.Value;
                if (operationNameCanceled.Reserved1 != null)
                    oneInert[7].Value = operationNameCanceled.Reserved1;
                else
                    oneInert[7].Value = DBNull.Value;
                if (operationNameCanceled.Reserved2 != null)
                    oneInert[8].Value = operationNameCanceled.Reserved2;
                else
                    oneInert[8].Value = DBNull.Value;
                if (operationNameCanceled.Reserved3 != null)
                    oneInert[9].Value = operationNameCanceled.Reserved3;
                else
                    oneInert[9].Value = DBNull.Value;
                if (operationNameCanceled.Reserved3 != null)
                    oneInert[10].Value = operationNameCanceled.Reserved5;
                else
                    oneInert[10].Value = DBNull.Value;
                if (operationNameCanceled.Reserved5.ToString() != null)
                    oneInert[11].Value = operationNameCanceled.Reserved5;
                else
                    oneInert[11].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_Med_Operation_Name_Canceled_OLE, oneInert);
            }
        }

        public int UpdateMedOperationNameCanceledOLE(Model.MedOperationNameCanceled operationNameCanceled)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedOperationName");
                if (operationNameCanceled.Operation != null)
                    oneUpdate[0].Value = operationNameCanceled.Operation;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (operationNameCanceled.OperationCode != null)
                    oneUpdate[1].Value = operationNameCanceled.OperationCode;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (operationNameCanceled.OperationScale != null)
                    oneUpdate[2].Value = operationNameCanceled.OperationScale;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (operationNameCanceled.Reserved1 != null)
                    oneUpdate[3].Value = operationNameCanceled.Reserved1;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (operationNameCanceled.Reserved2 != null)
                    oneUpdate[4].Value = operationNameCanceled.Reserved2;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (operationNameCanceled.Reserved3 != null)
                    oneUpdate[5].Value = operationNameCanceled.Reserved3;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (operationNameCanceled.Reserved3 != null)
                    oneUpdate[6].Value = operationNameCanceled.Reserved5;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (operationNameCanceled.Reserved5.ToString() != null)
                    oneUpdate[7].Value = operationNameCanceled.Reserved5;
                else
                    oneUpdate[7].Value = DBNull.Value;
                oneUpdate[8].Value = operationNameCanceled.PatientId;
                oneUpdate[9].Value = operationNameCanceled.VisitId;
                oneUpdate[10].Value = operationNameCanceled.CancelId;
                oneUpdate[11].Value = operationNameCanceled.OperationNo;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_Med_Operation_Name_Canceled_OLE, oneUpdate);
            }
        }

        private static readonly string Select_One_Med_Operation_Name_Canceled_Odbc = "select patient_id, visit_id, cancel_id, operation_no, operation, operation_code, operation_scale, reserved1, reserved2, reserved3, reserved4, reserved5 from med_operation_name_canceled where patient_id = ? and visit_id = ? and cancel_id = ? and operation_no = ? ";
        private static readonly string Select_One_Med_Operation_Name_Canceled_OperId_Odbc = "select patient_id, visit_id, cancel_id, operation_no, operation, operation_code, operation_scale, reserved1, reserved2, reserved3, reserved4, reserved5 from med_operation_name_canceled where patient_id = ? and visit_id = ? and cancel_id = ? ";
        private static readonly string Select_Med_Operation_Name_Canceled_Odbc = "select patient_id, visit_id, cancel_id, operation_no, operation, operation_code, operation_scale, reserved1, reserved2, reserved3, reserved4, reserved5 from med_operation_name_canceled where patient_id = ? and visit_id = ? ";
        private static readonly string Insert_Med_Operation_Name_Canceled_Odbc = "insert into med_operation_name_canceled (patient_id, visit_id, cancel_id, operation_no, operation, operation_code, operation_scale, reserved1, reserved2, reserved3, reserved4, reserved5)values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private static readonly string Update_Med_Operation_Name_Canceled_Odbc = "update med_operation_name_canceled set operation = ?,operation_code = ?,operation_scale = ?,reserved1 = ?, reserved2 = ?,reserved3 = ?,reserved4 = ?,reserved5 = ? where patient_id = ? and visit_id = ? and cancel_id = ? and operation_no = ?";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectOneMedOperationNameCanceled")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("cancelId",OdbcType.Decimal),
                        new OdbcParameter("operationNo",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "SelectPatMedOperationNameCanceled")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "InsertMedOperationNameCanceled")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal), 
                        new OdbcParameter("cancelId",OdbcType.Decimal), 
                        new OdbcParameter("operationNo",OdbcType.Decimal), 
                        new OdbcParameter("operation",OdbcType.VarChar), 
                        new OdbcParameter("operationCode",OdbcType.VarChar), 
                        new OdbcParameter("operationScale",OdbcType.VarChar), 
                        new OdbcParameter("reserved1",OdbcType.VarChar), 
                        new OdbcParameter("reserved2",OdbcType.VarChar), 
                        new OdbcParameter("reserved3",OdbcType.VarChar), 
                        new OdbcParameter("reserved4",OdbcType.VarChar), 
                        new OdbcParameter("reserved5",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "UpdateMedOperationNameCanceled")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("operation",OdbcType.VarChar), 
                        new OdbcParameter("operationCode",OdbcType.VarChar), 
                        new OdbcParameter("operationScale",OdbcType.VarChar), 
                        new OdbcParameter("reserved1",OdbcType.VarChar), 
                        new OdbcParameter("reserved2",OdbcType.VarChar), 
                        new OdbcParameter("reserved3",OdbcType.VarChar), 
                        new OdbcParameter("reserved4",OdbcType.VarChar), 
                        new OdbcParameter("reserved5",OdbcType.Decimal),
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal), 
                        new OdbcParameter("cancelId",OdbcType.Decimal), 
                        new OdbcParameter("operationNo",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "SelectOneMedOperationNameCanceledOperId")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("cancelId",OdbcType.Decimal),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedOperationNameCanceled SelectMedOperationNameCanceledOdbc(string patientId, decimal visitId, decimal canceledId, decimal operationNo)
        {
            Model.MedOperationNameCanceled oneMedOperationName = null;

            OdbcParameter[] medOperationNameParams = GetParameterOdbc("SelectOneMedOperationNameCanceled");
            medOperationNameParams[0].Value = patientId;
            medOperationNameParams[1].Value = visitId;
            medOperationNameParams[2].Value = canceledId;
            medOperationNameParams[3].Value = operationNo;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_One_Med_Operation_Name_Canceled_Odbc, medOperationNameParams))
            {
                if (OdbcReader.Read())
                {
                    oneMedOperationName = new Model.MedOperationNameCanceled();
                    oneMedOperationName.PatientId = OdbcReader.GetString(0);
                    oneMedOperationName.VisitId = OdbcReader.GetDecimal(1);
                    oneMedOperationName.CancelId = OdbcReader.GetDecimal(2);
                    oneMedOperationName.OperationNo = OdbcReader.GetDecimal(3);
                    if (!OdbcReader.IsDBNull(4))
                        oneMedOperationName.Operation = OdbcReader.GetString(4);
                    if (!OdbcReader.IsDBNull(5))
                        oneMedOperationName.OperationCode = OdbcReader.GetString(5);
                    if (!OdbcReader.IsDBNull(6))
                        oneMedOperationName.OperationScale = OdbcReader.GetString(6);
                    if (!OdbcReader.IsDBNull(7))
                        oneMedOperationName.Reserved1 = OdbcReader.GetString(7);
                    if (!OdbcReader.IsDBNull(8))
                        oneMedOperationName.Reserved2 = OdbcReader.GetString(8);
                    if (!OdbcReader.IsDBNull(9))
                        oneMedOperationName.Reserved3 = OdbcReader.GetString(9);
                    if (!OdbcReader.IsDBNull(10))
                        oneMedOperationName.Reserved4 = OdbcReader.GetString(10);
                    if (!OdbcReader.IsDBNull(11))
                        oneMedOperationName.Reserved5 = OdbcReader.GetDecimal(11);

                }
                else
                    oneMedOperationName = null;
            }
            return oneMedOperationName;
        }

        public List<Model.MedOperationNameCanceled> SelectMedOperationNameCanceledOdbc(string patientId, decimal visitId, decimal canceledId)
        {
            List<Model.MedOperationNameCanceled> MedOperationNameList = new List<Model.MedOperationNameCanceled>();

            OdbcParameter[] medOperationNameParams = GetParameterOdbc("SelectOneMedOperationNameCanceledOperId");
            medOperationNameParams[0].Value = patientId;
            medOperationNameParams[1].Value = visitId;
            medOperationNameParams[2].Value = canceledId;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_One_Med_Operation_Name_Canceled_OperId_Odbc, medOperationNameParams))
            {
                while (OdbcReader.Read())
                {
                    Model.MedOperationNameCanceled oneMedOperationName = new Model.MedOperationNameCanceled();
                    oneMedOperationName.PatientId = OdbcReader.GetString(0);
                    oneMedOperationName.VisitId = OdbcReader.GetDecimal(1);
                    oneMedOperationName.CancelId = OdbcReader.GetDecimal(2);
                    oneMedOperationName.OperationNo = OdbcReader.GetDecimal(3);
                    if (!OdbcReader.IsDBNull(4))
                        oneMedOperationName.Operation = OdbcReader.GetString(4);
                    if (!OdbcReader.IsDBNull(5))
                        oneMedOperationName.OperationCode = OdbcReader.GetString(5);
                    if (!OdbcReader.IsDBNull(6))
                        oneMedOperationName.OperationScale = OdbcReader.GetString(6);
                    if (!OdbcReader.IsDBNull(7))
                        oneMedOperationName.Reserved1 = OdbcReader.GetString(7);
                    if (!OdbcReader.IsDBNull(8))
                        oneMedOperationName.Reserved2 = OdbcReader.GetString(8);
                    if (!OdbcReader.IsDBNull(9))
                        oneMedOperationName.Reserved3 = OdbcReader.GetString(9);
                    if (!OdbcReader.IsDBNull(10))
                        oneMedOperationName.Reserved4 = OdbcReader.GetString(10);
                    if (!OdbcReader.IsDBNull(11))
                        oneMedOperationName.Reserved5 = OdbcReader.GetDecimal(11);
                    MedOperationNameList.Add(oneMedOperationName);
                }

            }
            return MedOperationNameList;
        }

        public List<Model.MedOperationNameCanceled> SelectMedOperationNameCanceledOdbc(string patientId, decimal visitId)
        {
            List<Model.MedOperationNameCanceled> MedOperationNameList = new List<Model.MedOperationNameCanceled>();

            OdbcParameter[] operationName = GetParameterOdbc("SelectPatMedOperationName");
            operationName[0].Value = patientId;
            operationName[1].Value = visitId;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_Med_Operation_Name_Canceled_Odbc, operationName))
            {
                while (OdbcReader.Read())
                {
                    Model.MedOperationNameCanceled oneMedOperationNameCancelId = new Model.MedOperationNameCanceled();
                    oneMedOperationNameCancelId = new Model.MedOperationNameCanceled();
                    oneMedOperationNameCancelId.PatientId = OdbcReader.GetString(0);
                    oneMedOperationNameCancelId.VisitId = OdbcReader.GetDecimal(1);
                    oneMedOperationNameCancelId.CancelId = OdbcReader.GetDecimal(2);
                    oneMedOperationNameCancelId.OperationNo = OdbcReader.GetDecimal(3);
                    if (!OdbcReader.IsDBNull(4))
                        oneMedOperationNameCancelId.Operation = OdbcReader.GetString(4);
                    if (!OdbcReader.IsDBNull(5))
                        oneMedOperationNameCancelId.OperationCode = OdbcReader.GetString(5);
                    if (!OdbcReader.IsDBNull(6))
                        oneMedOperationNameCancelId.OperationScale = OdbcReader.GetString(6);
                    if (!OdbcReader.IsDBNull(7))
                        oneMedOperationNameCancelId.Reserved1 = OdbcReader.GetString(7);
                    if (!OdbcReader.IsDBNull(8))
                        oneMedOperationNameCancelId.Reserved2 = OdbcReader.GetString(8);
                    if (!OdbcReader.IsDBNull(9))
                        oneMedOperationNameCancelId.Reserved3 = OdbcReader.GetString(9);
                    if (!OdbcReader.IsDBNull(10))
                        oneMedOperationNameCancelId.Reserved4 = OdbcReader.GetString(10);
                    if (!OdbcReader.IsDBNull(11))
                        oneMedOperationNameCancelId.Reserved5 = OdbcReader.GetDecimal(11);
                    MedOperationNameList.Add(oneMedOperationNameCancelId);
                }
            }
            return MedOperationNameList;
        }

        public int InsertMedOperationNameOdbc(Model.MedOperationNameCanceled operationNameCanceled)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedOperationName");
                oneInert[0].Value = operationNameCanceled.PatientId;
                oneInert[1].Value = operationNameCanceled.VisitId;
                oneInert[2].Value = operationNameCanceled.CancelId;
                oneInert[3].Value = operationNameCanceled.OperationNo;
                if (operationNameCanceled.Operation != null)
                    oneInert[4].Value = operationNameCanceled.Operation;
                else
                    oneInert[4].Value = DBNull.Value;
                if (operationNameCanceled.OperationCode != null)
                    oneInert[5].Value = operationNameCanceled.OperationCode;
                else
                    oneInert[5].Value = DBNull.Value;
                if (operationNameCanceled.OperationScale != null)
                    oneInert[6].Value = operationNameCanceled.OperationScale;
                else
                    oneInert[6].Value = DBNull.Value;
                if (operationNameCanceled.Reserved1 != null)
                    oneInert[7].Value = operationNameCanceled.Reserved1;
                else
                    oneInert[7].Value = DBNull.Value;
                if (operationNameCanceled.Reserved2 != null)
                    oneInert[8].Value = operationNameCanceled.Reserved2;
                else
                    oneInert[8].Value = DBNull.Value;
                if (operationNameCanceled.Reserved3 != null)
                    oneInert[9].Value = operationNameCanceled.Reserved3;
                else
                    oneInert[9].Value = DBNull.Value;
                if (operationNameCanceled.Reserved3 != null)
                    oneInert[10].Value = operationNameCanceled.Reserved5;
                else
                    oneInert[10].Value = DBNull.Value;
                if (operationNameCanceled.Reserved5.ToString() != null)
                    oneInert[11].Value = operationNameCanceled.Reserved5;
                else
                    oneInert[11].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_Med_Operation_Name_Canceled_Odbc, oneInert);
            }
        }

        public int UpdateMedOperationNameCanceledOdbc(Model.MedOperationNameCanceled operationNameCanceled)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedOperationName");
                if (operationNameCanceled.Operation != null)
                    oneUpdate[0].Value = operationNameCanceled.Operation;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (operationNameCanceled.OperationCode != null)
                    oneUpdate[1].Value = operationNameCanceled.OperationCode;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (operationNameCanceled.OperationScale != null)
                    oneUpdate[2].Value = operationNameCanceled.OperationScale;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (operationNameCanceled.Reserved1 != null)
                    oneUpdate[3].Value = operationNameCanceled.Reserved1;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (operationNameCanceled.Reserved2 != null)
                    oneUpdate[4].Value = operationNameCanceled.Reserved2;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (operationNameCanceled.Reserved3 != null)
                    oneUpdate[5].Value = operationNameCanceled.Reserved3;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (operationNameCanceled.Reserved3 != null)
                    oneUpdate[6].Value = operationNameCanceled.Reserved5;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (operationNameCanceled.Reserved5.ToString() != null)
                    oneUpdate[7].Value = operationNameCanceled.Reserved5;
                else
                    oneUpdate[7].Value = DBNull.Value;
                oneUpdate[8].Value = operationNameCanceled.PatientId;
                oneUpdate[9].Value = operationNameCanceled.VisitId;
                oneUpdate[10].Value = operationNameCanceled.CancelId;
                oneUpdate[11].Value = operationNameCanceled.OperationNo;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_Med_Operation_Name_Canceled_Odbc, oneUpdate);
            }
        }
	}
}
