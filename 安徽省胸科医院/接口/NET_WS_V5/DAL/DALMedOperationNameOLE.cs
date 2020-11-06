

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
	
	public partial class DALMedOperationName
	{

        private static readonly string Select_One_Med_Operation_Name_OLE = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 from med_operation_name where patient_id = ? and visit_id = ? and oper_id = ? and operation_no = ? ";
        private static readonly string Select_One_Med_Operation_Name_OperId_OLE = "select PATIENT_ID,VISIT_ID,OPER_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 from med_operation_name where patient_id = ? and visit_id = ? and oper_id = ? ";
        private static readonly string Select_Med_Operation_Name_OLE = "select PATIENT_ID,VISIT_ID,OPER_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 from med_operation_name where patient_id = ? and visit_id = ? ";
        private static readonly string Insert_Med_Operation_Name_OLE = "insert into med_operation_name (patient_id, visit_id, oper_id, operation_no, operation, operation_code, operation_scale, wound_grade, reserved1, reserved2, reserved3, reserved4, reserved5)values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private static readonly string Update_Med_Operation_Name_OLE = "update med_operation_name set operation = ?,operation_code = ?,operation_scale = ?,wound_grade = ?,reserved1 = ?, reserved2 = ?,reserved3 = ?,reserved4 = ?,reserved5 = ? where patient_id = ? and visit_id = ? and oper_id = ? and operation_no = ?";
        
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectOneMedOperationName")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("operId",OleDbType.Decimal),
                        new OleDbParameter("operationNo",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "SelectPatMedOperationName")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "InsertMedOperationName")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal), 
                        new OleDbParameter("operId",OleDbType.Decimal), 
                        new OleDbParameter("operationNo",OleDbType.Decimal), 
                        new OleDbParameter("operation",OleDbType.VarChar), 
                        new OleDbParameter("operationCode",OleDbType.VarChar), 
                        new OleDbParameter("operationScale",OleDbType.VarChar), 
                        new OleDbParameter("woundGrade",OleDbType.VarChar), 
                        new OleDbParameter("reserved1",OleDbType.VarChar), 
                        new OleDbParameter("reserved2",OleDbType.VarChar), 
                        new OleDbParameter("reserved3",OleDbType.VarChar), 
                        new OleDbParameter("reserved4",OleDbType.VarChar), 
                        new OleDbParameter("reserved5",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "UpdateMedOperationName")
                {
                    parms = new OleDbParameter[]{
                                new OleDbParameter("operation",OleDbType.VarChar), 
                        new OleDbParameter("operationCode",OleDbType.VarChar), 
                        new OleDbParameter("operationScale",OleDbType.VarChar), 
                        new OleDbParameter("woundGrade",OleDbType.VarChar), 
                        new OleDbParameter("reserved1",OleDbType.VarChar), 
                        new OleDbParameter("reserved2",OleDbType.VarChar), 
                        new OleDbParameter("reserved3",OleDbType.VarChar), 
                        new OleDbParameter("reserved4",OleDbType.VarChar), 
                        new OleDbParameter("reserved5",OleDbType.Decimal),
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal), 
                        new OleDbParameter("operId",OleDbType.Decimal), 
                        new OleDbParameter("operationNo",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "SelectOneMedOperationNameOperId")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("operId",OleDbType.Decimal),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedOperationName SelectMedOperationNameOLE(string patientId, decimal visitId, decimal operId, decimal operationNo)
        {
            Model.MedOperationName model = null;

            OleDbParameter[] medOperationNameParams = GetParameterOLE("SelectOneMedOperationName");
            medOperationNameParams[0].Value = patientId;
            medOperationNameParams[1].Value = visitId;
            medOperationNameParams[2].Value = operId;
            medOperationNameParams[3].Value = operationNo;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_One_Med_Operation_Name_OLE, medOperationNameParams))
            {
                if (oleReader.Read())
                {
                    model = new MedOperationName();

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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
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

        public List<Model.MedOperationName> SelectMedOperationNameOLE(string patientId, decimal visitId, decimal operId)
        {
            List<Model.MedOperationName> MedOperationNameList = new List<Model.MedOperationName>();

            OleDbParameter[] medOperationNameParams = GetParameterOLE("SelectOneMedOperationNameOperId");
            medOperationNameParams[0].Value = patientId;
            medOperationNameParams[1].Value = visitId;
            medOperationNameParams[2].Value = operId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_One_Med_Operation_Name_OperId_OLE, medOperationNameParams))
            {
                while (oleReader.Read())
                {
                    Model.MedOperationName model = new Model.MedOperationName();
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
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
                    MedOperationNameList.Add(model);
                }

            }
            return MedOperationNameList;
        }

        public List<Model.MedOperationName> SelectMedOperationNameOLE(string patientId, decimal visitId)
        {
            List<Model.MedOperationName> MedOperationNameList = new List<Model.MedOperationName>();

            OleDbParameter[] operationName = GetParameterOLE("SelectPatMedOperationName");
            operationName[0].Value = patientId;
            operationName[1].Value = visitId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_Med_Operation_Name_OLE, operationName))
            {
                while (oleReader.Read())
                {
                    Model.MedOperationName model = new Model.MedOperationName();
                   
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
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
                    MedOperationNameList.Add(model);
                }
            }
            return MedOperationNameList;
        }

        public int InsertMedOperationNameOLE(Model.MedOperationName model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedOperationName");
                if (model.PatientId != null)
                    oneInert[0].Value = model.PatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneInert[1].Value = model.VisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.OperId != null)
                    oneInert[2].Value = model.OperId;
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
			
			
                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_Med_Operation_Name_OLE, oneInert);
            }
        }

        public int UpdateMedOperationNameOLE(Model.MedOperationName model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedOperationName");
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
                if (model.OperId != null)
                    oneUpdate[10].Value = model.OperId;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.OperNo != null)
                    oneUpdate[11].Value = model.OperNo;
                else
                    oneUpdate[11].Value = DBNull.Value;
                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_Med_Operation_Name_OLE, oneUpdate);
            }
        }

        private static readonly string Select_One_Med_Operation_Name_Odbc = "select patient_id, visit_id, oper_id, operation_no, operation, operation_code, operation_scale, wound_grade, reserved1, reserved2, reserved3, reserved4, reserved5 from med_operation_name where patient_id = ? and visit_id = ? and oper_id = ? and operation_no = ? ";
        private static readonly string Select_One_Med_Operation_Name_OperId_Odbc = "select patient_id, visit_id, oper_id, operation_no, operation, operation_code, operation_scale, wound_grade, reserved1, reserved2, reserved3, reserved4, reserved5 from med_operation_name where patient_id = ? and visit_id = ? and oper_id = ? ";
        private static readonly string Select_Med_Operation_Name_Odbc = "select patient_id, visit_id, oper_id, operation_no, operation, operation_code, operation_scale, wound_grade, reserved1, reserved2, reserved3, reserved4, reserved5 from med_operation_name where patient_id = ? and visit_id = ? ";
        private static readonly string Insert_Med_Operation_Name_Odbc = "insert into med_operation_name (patient_id, visit_id, oper_id, operation_no, operation, operation_code, operation_scale, wound_grade, reserved1, reserved2, reserved3, reserved4, reserved5)values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private static readonly string Update_Med_Operation_Name_Odbc = "update med_operation_name set operation = ?,operation_code = ?,operation_scale = ?,wound_grade = ?,reserved1 = ?, reserved2 = ?,reserved3 = ?,reserved4 = ?,reserved5 = ? where patient_id = ? and visit_id = ? and oper_id = ? and operation_no = ?";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectOneMedOperationName")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("operId",OdbcType.Decimal),
                        new OdbcParameter("operationNo",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "SelectPatMedOperationName")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "InsertMedOperationName")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal), 
                        new OdbcParameter("operId",OdbcType.Decimal), 
                        new OdbcParameter("operationNo",OdbcType.Decimal), 
                        new OdbcParameter("operation",OdbcType.VarChar), 
                        new OdbcParameter("operationCode",OdbcType.VarChar), 
                        new OdbcParameter("operationScale",OdbcType.VarChar), 
                        new OdbcParameter("woundGrade",OdbcType.VarChar), 
                        new OdbcParameter("reserved1",OdbcType.VarChar), 
                        new OdbcParameter("reserved2",OdbcType.VarChar), 
                        new OdbcParameter("reserved3",OdbcType.VarChar), 
                        new OdbcParameter("reserved4",OdbcType.VarChar), 
                        new OdbcParameter("reserved5",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "UpdateMedOperationName")
                {
                    parms = new OdbcParameter[]{
                                new OdbcParameter("operation",OdbcType.VarChar), 
                        new OdbcParameter("operationCode",OdbcType.VarChar), 
                        new OdbcParameter("operationScale",OdbcType.VarChar), 
                        new OdbcParameter("woundGrade",OdbcType.VarChar), 
                        new OdbcParameter("reserved1",OdbcType.VarChar), 
                        new OdbcParameter("reserved2",OdbcType.VarChar), 
                        new OdbcParameter("reserved3",OdbcType.VarChar), 
                        new OdbcParameter("reserved4",OdbcType.VarChar), 
                        new OdbcParameter("reserved5",OdbcType.Decimal),
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal), 
                        new OdbcParameter("operId",OdbcType.Decimal), 
                        new OdbcParameter("operationNo",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "SelectOneMedOperationNameOperId")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("operId",OdbcType.Decimal),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedOperationName SelectMedOperationNameOdbc(string patientId, decimal visitId, decimal operId, decimal operationNo)
        {
            Model.MedOperationName model = null;

            OdbcParameter[] medOperationNameParams = GetParameterOdbc("SelectOneMedOperationName");
            medOperationNameParams[0].Value = patientId;
            medOperationNameParams[1].Value = visitId;
            medOperationNameParams[2].Value = operId;
            medOperationNameParams[3].Value = operationNo;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_One_Med_Operation_Name_Odbc, medOperationNameParams))
            {
                if (oleReader.Read())
                {
                    model = new MedOperationName();
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
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

        public List<Model.MedOperationName> SelectMedOperationNameOdbc(string patientId, decimal visitId, decimal operId)
        {
            List<Model.MedOperationName> MedOperationNameList = new List<Model.MedOperationName>();

            OdbcParameter[] medOperationNameParams = GetParameterOdbc("SelectOneMedOperationNameOperId");
            medOperationNameParams[0].Value = patientId;
            medOperationNameParams[1].Value = visitId;
            medOperationNameParams[2].Value = operId;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_One_Med_Operation_Name_OperId_Odbc, medOperationNameParams))
            {
                while (oleReader.Read())
                {
                    Model.MedOperationName model = new Model.MedOperationName();
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
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
                    MedOperationNameList.Add(model);
                }

            }
            return MedOperationNameList;
        }

        public List<Model.MedOperationName> SelectMedOperationNameOdbc(string patientId, decimal visitId)
        {
            List<Model.MedOperationName> MedOperationNameList = new List<Model.MedOperationName>();

            OdbcParameter[] operationName = GetParameterOdbc("SelectPatMedOperationName");
            operationName[0].Value = patientId;
            operationName[1].Value = visitId;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_Med_Operation_Name_Odbc, operationName))
            {
                while (oleReader.Read())
                {
                    Model.MedOperationName model = new Model.MedOperationName();
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
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
                    MedOperationNameList.Add(model);
                }
            }
            return MedOperationNameList;
        }

        public int InsertMedOperationNameOdbc(Model.MedOperationName model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedOperationName");
                if (model.PatientId != null)
                    oneInert[0].Value = model.PatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneInert[1].Value = model.VisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.OperId != null)
                    oneInert[2].Value = model.OperId;
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
                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_Med_Operation_Name_Odbc, oneInert);
            }
        }

        public int UpdateMedOperationNameOdbc(Model.MedOperationName model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedOperationName");
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
                if (model.OperId != null)
                    oneUpdate[10].Value = model.OperId;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.OperNo != null)
                    oneUpdate[11].Value = model.OperNo;
                else
                    oneUpdate[11].Value = DBNull.Value;
			
                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_Med_Operation_Name_Odbc, oneUpdate);
            }
        }
	}
}
