using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedScheduledOperationName
    /// </summary>
    public partial class DALMedScheduledOperationName
    {
        private static string Update_OLE = "Update MED_OPERATION_SCHEDULE_NAME set OPER_NAME=?,OPER_CODE=?,OPER_SCALE=?,WOUND_TYPE=?,RESERVED1=?,RESERVED2=?,RESERVED3=?,RESERVED4=? where PATIENT_ID=? AND VISIT_ID=? AND SCHEDULE_ID=? AND OPER_NO=? ";


        private static string Insert_OLE = "Insert into MED_OPERATION_SCHEDULE_NAME  (PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4) values(?,?,?,?,?,?,?,?,?,?,?,?)";


        private static readonly string Select_One_Med_Schedule_Operation_Name_OLE = "select PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 from MED_OPERATION_SCHEDULE_NAME where patient_id = ? and visit_id = ? and schedule_id = ? and oper_no = ? ";
        private static readonly string Select_Med_Schedule_Operation_Name_Schedule_OLE = "select PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 from MED_OPERATION_SCHEDULE_NAME where patient_id = ? and visit_id = ? and schedule_id = ?";
        //private static readonly string Insert_Med_Schedule_Operation_Name_OLE = "insert into med_scheduled_operation_name(patient_id, visit_id, schedule_id, operation_no, operation, operation_scale, operation_code, reserved1, reserved2, reserved3, reserved4, reserved5)values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
         // private static readonly string Update_Med_Schedule_Operation_Name_OLE = "update med_scheduled_operation_name set operation = ?,operation_scale = ?,operation_code = ?,reserved1 = ?, reserved2 = ?,reserved3 = ?,reserved4 = ?,reserved5 = ? where patient_id = ? and visit_id = ? and schedule_id = ? and operation_no = ?";
        private static readonly string Delete_Med_Schedule_Operation_Name_OLE = "Delete MED_OPERATION_SCHEDULE_NAME WHERE PATIENT_ID= ? AND VISIT_ID= ? AND SCHEDULE_ID= ? AND OPERATION_NO= ?";
        private static readonly string Delete_Med_Schedule_Operation_Name_Patient_OLE = "Delete MED_OPERATION_SCHEDULE_NAME WHERE PATIENT_ID= ? AND VISIT_ID= ? AND SCHEDULE_ID= ?";
        
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectOneMedScheduleOperationName")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("scheduleId",OleDbType.Decimal),
                        new OleDbParameter("operationNo",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "SelectMedPatScheduleOperationName")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("scheduleId",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "InsertMedScheduleOperationName")
                {
                    parms = new OleDbParameter[]{
                       new OleDbParameter("PatientId",OleDbType.VarChar),
                        new OleDbParameter("VisitId",OleDbType.Decimal),
                        new OleDbParameter("ScheduleId",OleDbType.Decimal),
                        new OleDbParameter("OperNo",OleDbType.Decimal),
                        new OleDbParameter("OperName",OleDbType.VarChar),
                        new OleDbParameter("OperCode",OleDbType.VarChar),
                        new OleDbParameter("OperScale",OleDbType.VarChar),
                        new OleDbParameter("WoundType",OleDbType.VarChar),
                        new OleDbParameter("Reserved1",OleDbType.VarChar),
                        new OleDbParameter("Reserved2",OleDbType.VarChar),
                        new OleDbParameter("Reserved3",OleDbType.VarChar),
                        new OleDbParameter("Reserved4",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedScheduleOperationName")
                {
                    parms = new OleDbParameter[]{
                     new OleDbParameter(":OperName",OleDbType.VarChar),
                    new OleDbParameter(":OperCode",OleDbType.VarChar),
                    new OleDbParameter(":OperScale",OleDbType.VarChar),
                    new OleDbParameter(":WoundType",OleDbType.VarChar),
                    new OleDbParameter(":Reserved1",OleDbType.VarChar),
                    new OleDbParameter(":Reserved2",OleDbType.VarChar),
                    new OleDbParameter(":Reserved3",OleDbType.VarChar),
                    new OleDbParameter(":Reserved4",OleDbType.VarChar),
                    new OleDbParameter(":PatientId",OleDbType.VarChar),
                    new OleDbParameter(":VisitId",OleDbType.Decimal),
                    new OleDbParameter(":ScheduleId",OleDbType.Decimal),
                    new OleDbParameter(":OperNo",OleDbType.Decimal),
                    };
                }
                if (sqlParms == "DeleteMedScheduledOperationName")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("scheduleId",OleDbType.Decimal),
                        new OleDbParameter("operationNo",OleDbType.Decimal)
                    };
                }
                if (sqlParms == "DeleteMedScheduledOperationNamePatient")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("scheduleId",OleDbType.Decimal),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedScheduledOperationName SelectMedScheduledOperationNameOLE(string patientId, decimal visitId, decimal scheduleId, decimal operationNo)
        {
            Model.MedScheduledOperationName model = null;

            OleDbParameter[] medScheduleOperationNameParams = GetParameterOLE("SelectOneMedScheduleOperationName");
            medScheduleOperationNameParams[0].Value = patientId;
            medScheduleOperationNameParams[1].Value = visitId;
            medScheduleOperationNameParams[2].Value = scheduleId;
            medScheduleOperationNameParams[3].Value = operationNo;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_One_Med_Schedule_Operation_Name_OLE, medScheduleOperationNameParams))
            {
                if (oleReader.Read())
                {
                    model = new MedicalSytem.Soft.Model.MedScheduledOperationName();
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
                        model.ScheduleId = decimal.Parse(oleReader["SCHEDULE_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OperNo = decimal.Parse(oleReader["OPER_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.OperName = oleReader["OPER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OperCode = oleReader["OPER_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved4 = oleReader["RESERVED4"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }

        public List<Model.MedScheduledOperationName> SelectMedScheduledOperationNameOLE(string patientId, decimal visitId, decimal scheduleId)
        {
            List<Model.MedScheduledOperationName> MedScheduleOperationNameList = new List<Model.MedScheduledOperationName>();
            OleDbParameter[] ScheduleOperationName = GetParameterOLE("SelectMedPatScheduleOperationName");
            ScheduleOperationName[0].Value = patientId;
            ScheduleOperationName[1].Value = visitId;
            ScheduleOperationName[2].Value = scheduleId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_Med_Schedule_Operation_Name_Schedule_OLE, ScheduleOperationName))
            {
                while (oleReader.Read())
                {
                    Model.MedScheduledOperationName model = new Model.MedScheduledOperationName();
                 
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
                        model.ScheduleId = decimal.Parse(oleReader["SCHEDULE_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OperNo = decimal.Parse(oleReader["OPER_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.OperName = oleReader["OPER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OperCode = oleReader["OPER_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved4 = oleReader["RESERVED4"].ToString().Trim();
                    }
                    MedScheduleOperationNameList.Add(model);
                }
            }
            return MedScheduleOperationNameList;
        }

        public int InsertMedScheduledOperationNameOLE(Model.MedScheduledOperationName model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedScheduleOperationName");
                if (model.PatientId != null)
                    oneInert[0].Value = model.PatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneInert[1].Value = model.VisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.ScheduleId != null)
                    oneInert[2].Value = model.ScheduleId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.OperNo != null)
                    oneInert[3].Value = model.OperNo;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.OperName != null)
                    oneInert[4].Value = model.OperName;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.OperCode != null)
                    oneInert[5].Value = model.OperCode;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.OperScale != null)
                    oneInert[6].Value = model.OperScale;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.WoundType != null)
                    oneInert[7].Value = model.WoundType;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneInert[8].Value = model.Reserved1;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Reserved2 != null)
                    oneInert[9].Value = model.Reserved2;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.Reserved3 != null)
                    oneInert[10].Value = model.Reserved3;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.Reserved4 != null)
                    oneInert[11].Value = model.Reserved4;
                else
                    oneInert[11].Value = DBNull.Value;
                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_OLE, oneInert);
            }
        }

        public void InsertMedScheduledOperationNameOLE(List<Model.MedScheduledOperationName> MedScheduleOperationName)
        {

            OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString);
            oleCisConn.Open();
            OleDbTransaction oleCisTrans = oleCisConn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                foreach (Model.MedScheduledOperationName model in MedScheduleOperationName)
                {
                    OleDbParameter[] oneInert = GetParameterOLE("InsertMedScheduleOperationName");
                    if (model.PatientId != null)
                        oneInert[0].Value = model.PatientId;
                    else
                        oneInert[0].Value = DBNull.Value;
                    if (model.VisitId != null)
                        oneInert[1].Value = model.VisitId;
                    else
                        oneInert[1].Value = DBNull.Value;
                    if (model.ScheduleId != null)
                        oneInert[2].Value = model.ScheduleId;
                    else
                        oneInert[2].Value = DBNull.Value;
                    if (model.OperNo != null)
                        oneInert[3].Value = model.OperNo;
                    else
                        oneInert[3].Value = DBNull.Value;
                    if (model.OperName != null)
                        oneInert[4].Value = model.OperName;
                    else
                        oneInert[4].Value = DBNull.Value;
                    if (model.OperCode != null)
                        oneInert[5].Value = model.OperCode;
                    else
                        oneInert[5].Value = DBNull.Value;
                    if (model.OperScale != null)
                        oneInert[6].Value = model.OperScale;
                    else
                        oneInert[6].Value = DBNull.Value;
                    if (model.WoundType != null)
                        oneInert[7].Value = model.WoundType;
                    else
                        oneInert[7].Value = DBNull.Value;
                    if (model.Reserved1 != null)
                        oneInert[8].Value = model.Reserved1;
                    else
                        oneInert[8].Value = DBNull.Value;
                    if (model.Reserved2 != null)
                        oneInert[9].Value = model.Reserved2;
                    else
                        oneInert[9].Value = DBNull.Value;
                    if (model.Reserved3 != null)
                        oneInert[10].Value = model.Reserved3;
                    else
                        oneInert[10].Value = DBNull.Value;
                    if (model.Reserved4 != null)
                        oneInert[11].Value = model.Reserved4;
                    else
                        oneInert[11].Value = DBNull.Value;

                    OleDbHelper.ExecuteNonQuery(oleCisTrans, CommandType.Text, Insert_OLE, oneInert);
                }
                oleCisTrans.Commit();
            }
            catch (Exception ex)
            {
                oleCisTrans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                oleCisConn.Close();
            }
        }

        public int UpdateMedScheduledOperationNameOLE(Model.MedScheduledOperationName model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedScheduleOperationName");
               
                if (model.OperName != null)
                    oneUpdate[0].Value = model.OperName;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.OperCode != null)
                    oneUpdate[1].Value = model.OperCode;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.OperScale != null)
                    oneUpdate[2].Value = model.OperScale;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.WoundType != null)
                    oneUpdate[3].Value = model.WoundType;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneUpdate[4].Value = model.Reserved1;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.Reserved2 != null)
                    oneUpdate[5].Value = model.Reserved2;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.Reserved3 != null)
                    oneUpdate[6].Value = model.Reserved3;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.Reserved4 != null)
                    oneUpdate[7].Value = model.Reserved4;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[8].Value = model.PatientId;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneUpdate[9].Value = model.VisitId;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.ScheduleId != null)
                    oneUpdate[10].Value = model.ScheduleId;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.OperNo != null)
                    oneUpdate[11].Value = model.OperNo;
                else
                    oneUpdate[11].Value = DBNull.Value;


                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_OLE, oneUpdate);
            }
        }

        public void UpdateMedScheduledOperationNameOLE(List<Model.MedScheduledOperationName> ScheduleOperationNameList)
        {

            OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString);
            oleCisConn.Open();
            OleDbTransaction oleCisTrans = oleCisConn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                foreach (Model.MedScheduledOperationName model in ScheduleOperationNameList)
                {
                    OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedScheduleOperationName");

                    if (model.OperName != null)
                        oneUpdate[0].Value = model.OperName;
                    else
                        oneUpdate[0].Value = DBNull.Value;
                    if (model.OperCode != null)
                        oneUpdate[1].Value = model.OperCode;
                    else
                        oneUpdate[1].Value = DBNull.Value;
                    if (model.OperScale != null)
                        oneUpdate[2].Value = model.OperScale;
                    else
                        oneUpdate[2].Value = DBNull.Value;
                    if (model.WoundType != null)
                        oneUpdate[3].Value = model.WoundType;
                    else
                        oneUpdate[3].Value = DBNull.Value;
                    if (model.Reserved1 != null)
                        oneUpdate[4].Value = model.Reserved1;
                    else
                        oneUpdate[4].Value = DBNull.Value;
                    if (model.Reserved2 != null)
                        oneUpdate[5].Value = model.Reserved2;
                    else
                        oneUpdate[5].Value = DBNull.Value;
                    if (model.Reserved3 != null)
                        oneUpdate[6].Value = model.Reserved3;
                    else
                        oneUpdate[6].Value = DBNull.Value;
                    if (model.Reserved4 != null)
                        oneUpdate[7].Value = model.Reserved4;
                    else
                        oneUpdate[7].Value = DBNull.Value;
                    if (model.PatientId != null)
                        oneUpdate[8].Value = model.PatientId;
                    else
                        oneUpdate[8].Value = DBNull.Value;
                    if (model.VisitId != null)
                        oneUpdate[9].Value = model.VisitId;
                    else
                        oneUpdate[9].Value = DBNull.Value;
                    if (model.ScheduleId != null)
                        oneUpdate[10].Value = model.ScheduleId;
                    else
                        oneUpdate[10].Value = DBNull.Value;
                    if (model.OperNo != null)
                        oneUpdate[11].Value = model.OperNo;
                    else
                        oneUpdate[11].Value = DBNull.Value;
                    OleDbHelper.ExecuteNonQuery(oleCisTrans, CommandType.Text, Update_ODBC, oneUpdate);
                }
                oleCisTrans.Commit();
            }
            catch (Exception ex)
            {
                oleCisTrans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                oleCisConn.Close();
            }
        }

        public int DeleteMedScheduledOperationNameOLE(string patientId, decimal visitId, decimal scheduleId, decimal operationNo)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedScheduledOperationName");
                if (patientId != null)
                    oneDelete[0].Value = patientId;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (visitId.ToString() != null)
                    oneDelete[1].Value = visitId;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (scheduleId.ToString() != null)
                    oneDelete[2].Value = scheduleId;
                else
                    oneDelete[2].Value = DBNull.Value;
                if (operationNo.ToString() != null)
                    oneDelete[3].Value = operationNo;
                else
                    oneDelete[3].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, Delete_Med_Schedule_Operation_Name_OLE, oneDelete);
            }
        }

        public int DeleteMedScheduledOperationNameOLE(string patientId, decimal visitId, decimal scheduleId)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedScheduledOperationNamePatient");
                if (patientId != null)
                    oneDelete[0].Value = patientId;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (visitId.ToString() != null)
                    oneDelete[1].Value = visitId;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (scheduleId.ToString() != null)
                    oneDelete[2].Value = scheduleId;
                else
                    oneDelete[2].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, Delete_Med_Schedule_Operation_Name_Patient_OLE, oneDelete);
            }
        }

        private static string Update_ODBC = "Update MED_OPERATION_SCHEDULE_NAME set OPER_NAME=?,OPER_CODE=?,OPER_SCALE=?,WOUND_TYPE=?,RESERVED1=?,RESERVED2=?,RESERVED3=?,RESERVED4=? where PATIENT_ID=? and VISIT_ID=? and SCHEDULE_ID=? and OPER_NO=?";


        private static string Insert_ODBC = "Insert into MED_OPERATION_SCHEDULE_NAME  (PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4) values(?,?,?,?,?,?,?,?,?,?,?,?)";



        private static readonly string Select_One_Med_Schedule_Operation_Name_Odbc = "select PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 from MED_OPERATION_SCHEDULE_NAME where patient_id = ? and visit_id = ? and schedule_id = ? and operation_no = ? ";
        private static readonly string Select_Med_Schedule_Operation_Name_Schedule_Odbc = "select PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 from MED_OPERATION_SCHEDULE_NAME where patient_id = ? and visit_id = ? and schedule_id = ?";
       // private static readonly string Insert_Med_Schedule_Operation_Name_Odbc = "insert into med_scheduled_operation_name(patient_id, visit_id, schedule_id, operation_no, operation, operation_scale, operation_code, reserved1, reserved2, reserved3, reserved4, reserved5)values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
       // private static readonly string Update_Med_Schedule_Operation_Name_Odbc = "update med_scheduled_operation_name set operation = ?,operation_scale = ?,operation_code = ?,reserved1 = ?, reserved2 = ?,reserved3 = ?,reserved4 = ?,reserved5 = ? where patient_id = ? and visit_id = ? and schedule_id = ? and operation_no = ?";
        private static readonly string Delete_Med_Schedule_Operation_Name_Odbc = "Delete MED_OPERATION_SCHEDULE_NAME WHERE PATIENT_ID= ? AND VISIT_ID= ? AND SCHEDULE_ID= ? AND OPERATION_NO= ?";
        private static readonly string Delete_Med_Schedule_Operation_Name_Patient_Odbc = "Delete MED_OPERATION_SCHEDULE_NAME WHERE PATIENT_ID= ? AND VISIT_ID= ? AND SCHEDULE_ID= ?";
        
        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectOneMedScheduleOperationName")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("scheduleId",OdbcType.Decimal),
                        new OdbcParameter("operationNo",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "SelectMedPatScheduleOperationName")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("scheduleId",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "InsertMedScheduleOperationName")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal), 
                        new OdbcParameter("scheduleId",OdbcType.Decimal), 
                        new OdbcParameter("operationNo",OdbcType.Decimal), 
                        new OdbcParameter("operation",OdbcType.VarChar), 
                        new OdbcParameter("operationScale",OdbcType.VarChar), 
                        new OdbcParameter("operationCode",OdbcType.VarChar),
                        new OdbcParameter("reserved1",OdbcType.VarChar), 
                        new OdbcParameter("reserved2",OdbcType.VarChar), 
                        new OdbcParameter("reserved3",OdbcType.VarChar), 
                        new OdbcParameter("reserved4",OdbcType.VarChar), 
                        new OdbcParameter("reserved5",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "UpdateMedScheduleOperationName")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("operation",OdbcType.VarChar),
                        new OdbcParameter("operationScale",OdbcType.VarChar), 
                        new OdbcParameter("operationCode",OdbcType.VarChar), 
                        new OdbcParameter("reserved1",OdbcType.VarChar), 
                        new OdbcParameter("reserved2",OdbcType.VarChar), 
                        new OdbcParameter("reserved3",OdbcType.VarChar), 
                        new OdbcParameter("reserved4",OdbcType.VarChar), 
                        new OdbcParameter("reserved5",OdbcType.Decimal),
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal), 
                        new OdbcParameter("scheduleId",OdbcType.Decimal), 
                        new OdbcParameter("operationNo",OdbcType.Decimal)
                    };
                }
                if (sqlParms == "DeleteMedScheduledOperationName")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("scheduleId",OdbcType.Decimal),
                        new OdbcParameter("operationNo",OdbcType.Decimal)
                    };
                }
                if (sqlParms == "DeleteMedScheduledOperationNamePatient")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("scheduleId",OdbcType.Decimal),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedScheduledOperationName SelectMedScheduledOperationNameOdbc(string patientId, decimal visitId, decimal scheduleId, decimal operationNo)
        {
            Model.MedScheduledOperationName model = null;

            OdbcParameter[] medScheduleOperationNameParams = GetParameterOdbc("SelectOneMedScheduleOperationName");
            medScheduleOperationNameParams[0].Value = patientId;
            medScheduleOperationNameParams[1].Value = visitId;
            medScheduleOperationNameParams[2].Value = scheduleId;
            medScheduleOperationNameParams[3].Value = operationNo;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_One_Med_Schedule_Operation_Name_Odbc, medScheduleOperationNameParams))
            {
                if (oleReader.Read())
                {
                    model = new Model.MedScheduledOperationName();
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
                        model.ScheduleId = decimal.Parse(oleReader["SCHEDULE_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OperNo = decimal.Parse(oleReader["OPER_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.OperName = oleReader["OPER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OperCode = oleReader["OPER_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved4 = oleReader["RESERVED4"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }

        public List<Model.MedScheduledOperationName> SelectMedScheduledOperationNameOdbc(string patientId, decimal visitId, decimal scheduleId)
        {
            List<Model.MedScheduledOperationName> MedScheduleOperationNameList = new List<Model.MedScheduledOperationName>();
            OdbcParameter[] ScheduleOperationName = GetParameterOdbc("SelectMedPatScheduleOperationName");
            ScheduleOperationName[0].Value = patientId;
            ScheduleOperationName[1].Value = visitId;
            ScheduleOperationName[2].Value = scheduleId;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_Med_Schedule_Operation_Name_Schedule_Odbc, ScheduleOperationName))
            {
                while (oleReader.Read())
                {
                    Model.MedScheduledOperationName model = new Model.MedScheduledOperationName();
                   
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
                        model.ScheduleId = decimal.Parse(oleReader["SCHEDULE_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OperNo = decimal.Parse(oleReader["OPER_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.OperName = oleReader["OPER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OperCode = oleReader["OPER_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved4 = oleReader["RESERVED4"].ToString().Trim();
                    }
                    MedScheduleOperationNameList.Add(model);
                }
            }
            return MedScheduleOperationNameList;
        }

        public int InsertMedScheduledOperationNameOdbc(Model.MedScheduledOperationName model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedScheduleOperationName");
                if (model.PatientId != null)
                    oneInert[0].Value = model.PatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneInert[1].Value = model.VisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.ScheduleId != null)
                    oneInert[2].Value = model.ScheduleId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.OperNo != null)
                    oneInert[3].Value = model.OperNo;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.OperName != null)
                    oneInert[4].Value = model.OperName;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.OperCode != null)
                    oneInert[5].Value = model.OperCode;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.OperScale != null)
                    oneInert[6].Value = model.OperScale;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.WoundType != null)
                    oneInert[7].Value = model.WoundType;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneInert[8].Value = model.Reserved1;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Reserved2 != null)
                    oneInert[9].Value = model.Reserved2;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.Reserved3 != null)
                    oneInert[10].Value = model.Reserved3;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.Reserved4 != null)
                    oneInert[11].Value = model.Reserved4;
                else
                    oneInert[11].Value = DBNull.Value;
                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_ODBC, oneInert);
            }
        }

        public void InsertMedScheduledOperationNameOdbc(List<Model.MedScheduledOperationName> MedScheduleOperationName)
        {

            OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString);
            OdbcCisConn.Open();
            OdbcTransaction OdbcCisTrans = OdbcCisConn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                foreach (Model.MedScheduledOperationName model in MedScheduleOperationName)
                {
                    OdbcParameter[] oneInert = GetParameterOdbc("InsertMedScheduleOperationName");
                    if (model.PatientId != null)
                        oneInert[0].Value = model.PatientId;
                    else
                        oneInert[0].Value = DBNull.Value;
                    if (model.VisitId != null)
                        oneInert[1].Value = model.VisitId;
                    else
                        oneInert[1].Value = DBNull.Value;
                    if (model.ScheduleId != null)
                        oneInert[2].Value = model.ScheduleId;
                    else
                        oneInert[2].Value = DBNull.Value;
                    if (model.OperNo != null)
                        oneInert[3].Value = model.OperNo;
                    else
                        oneInert[3].Value = DBNull.Value;
                    if (model.OperName != null)
                        oneInert[4].Value = model.OperName;
                    else
                        oneInert[4].Value = DBNull.Value;
                    if (model.OperCode != null)
                        oneInert[5].Value = model.OperCode;
                    else
                        oneInert[5].Value = DBNull.Value;
                    if (model.OperScale != null)
                        oneInert[6].Value = model.OperScale;
                    else
                        oneInert[6].Value = DBNull.Value;
                    if (model.WoundType != null)
                        oneInert[7].Value = model.WoundType;
                    else
                        oneInert[7].Value = DBNull.Value;
                    if (model.Reserved1 != null)
                        oneInert[8].Value = model.Reserved1;
                    else
                        oneInert[8].Value = DBNull.Value;
                    if (model.Reserved2 != null)
                        oneInert[9].Value = model.Reserved2;
                    else
                        oneInert[9].Value = DBNull.Value;
                    if (model.Reserved3 != null)
                        oneInert[10].Value = model.Reserved3;
                    else
                        oneInert[10].Value = DBNull.Value;
                    if (model.Reserved4 != null)
                        oneInert[11].Value = model.Reserved4;
                    else
                        oneInert[11].Value = DBNull.Value;

                    OdbcHelper.ExecuteNonQuery(OdbcCisTrans, CommandType.Text, Insert_ODBC, oneInert);
                }
                OdbcCisTrans.Commit();
            }
            catch (Exception ex)
            {
                OdbcCisTrans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                OdbcCisConn.Close();
            }
        }

        public int UpdateMedScheduledOperationNameOdbc(Model.MedScheduledOperationName model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedScheduleOperationName");
                if (model.OperName != null)
                    oneUpdate[0].Value = model.OperName;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.OperCode != null)
                    oneUpdate[1].Value = model.OperCode;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.OperScale != null)
                    oneUpdate[2].Value = model.OperScale;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.WoundType != null)
                    oneUpdate[3].Value = model.WoundType;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneUpdate[4].Value = model.Reserved1;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.Reserved2 != null)
                    oneUpdate[5].Value = model.Reserved2;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.Reserved3 != null)
                    oneUpdate[6].Value = model.Reserved3;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.Reserved4 != null)
                    oneUpdate[7].Value = model.Reserved4;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[8].Value = model.PatientId;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneUpdate[9].Value = model.VisitId;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.ScheduleId != null)
                    oneUpdate[10].Value = model.ScheduleId;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.OperNo != null)
                    oneUpdate[11].Value = model.OperNo;
                else
                    oneUpdate[11].Value = DBNull.Value;
                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_ODBC, oneUpdate);
            }
        }

        public void UpdateMedScheduledOperationNameOdbc(List<Model.MedScheduledOperationName> ScheduleOperationNameList)
        {

            OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString);
            OdbcCisConn.Open();
            OdbcTransaction OdbcCisTrans = OdbcCisConn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                foreach (Model.MedScheduledOperationName model in ScheduleOperationNameList)
                {
                    OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedScheduleOperationName");

                    if (model.OperName != null)
                        oneUpdate[0].Value = model.OperName;
                    else
                        oneUpdate[0].Value = DBNull.Value;
                    if (model.OperCode != null)
                        oneUpdate[1].Value = model.OperCode;
                    else
                        oneUpdate[1].Value = DBNull.Value;
                    if (model.OperScale != null)
                        oneUpdate[2].Value = model.OperScale;
                    else
                        oneUpdate[2].Value = DBNull.Value;
                    if (model.WoundType != null)
                        oneUpdate[3].Value = model.WoundType;
                    else
                        oneUpdate[3].Value = DBNull.Value;
                    if (model.Reserved1 != null)
                        oneUpdate[4].Value = model.Reserved1;
                    else
                        oneUpdate[4].Value = DBNull.Value;
                    if (model.Reserved2 != null)
                        oneUpdate[5].Value = model.Reserved2;
                    else
                        oneUpdate[5].Value = DBNull.Value;
                    if (model.Reserved3 != null)
                        oneUpdate[6].Value = model.Reserved3;
                    else
                        oneUpdate[6].Value = DBNull.Value;
                    if (model.Reserved4 != null)
                        oneUpdate[7].Value = model.Reserved4;
                    else
                        oneUpdate[7].Value = DBNull.Value;
                    if (model.PatientId != null)
                        oneUpdate[8].Value = model.PatientId;
                    else
                        oneUpdate[8].Value = DBNull.Value;
                    if (model.VisitId != null)
                        oneUpdate[9].Value = model.VisitId;
                    else
                        oneUpdate[9].Value = DBNull.Value;
                    if (model.ScheduleId != null)
                        oneUpdate[10].Value = model.ScheduleId;
                    else
                        oneUpdate[10].Value = DBNull.Value;
                    if (model.OperNo != null)
                        oneUpdate[11].Value = model.OperNo;
                    else
                        oneUpdate[11].Value = DBNull.Value;

                    OdbcHelper.ExecuteNonQuery(OdbcCisTrans, CommandType.Text, Update_ODBC, oneUpdate);
                }
                OdbcCisTrans.Commit();
            }
            catch (Exception ex)
            {
                OdbcCisTrans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                OdbcCisConn.Close();
            }
        }

        public int DeleteMedScheduledOperationNameOdbc(string patientId, decimal visitId, decimal scheduleId, decimal operationNo)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterOdbc("DeleteMedScheduledOperationName");
                if (patientId != null)
                    oneDelete[0].Value = patientId;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (visitId.ToString() != null)
                    oneDelete[1].Value = visitId;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (scheduleId.ToString() != null)
                    oneDelete[2].Value = scheduleId;
                else
                    oneDelete[2].Value = DBNull.Value;
                if (operationNo.ToString() != null)
                    oneDelete[3].Value = operationNo;
                else
                    oneDelete[3].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, Delete_Med_Schedule_Operation_Name_Odbc, oneDelete);
            }
        }

        public int DeleteMedScheduledOperationNameOdbc(string patientId, decimal visitId, decimal scheduleId)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterOdbc("DeleteMedScheduledOperationNamePatient");
                if (patientId != null)
                    oneDelete[0].Value = patientId;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (visitId.ToString() != null)
                    oneDelete[1].Value = visitId;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (scheduleId.ToString() != null)
                    oneDelete[2].Value = scheduleId;
                else
                    oneDelete[2].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, Delete_Med_Schedule_Operation_Name_Patient_Odbc, oneDelete);
            }
        }

    }
}
