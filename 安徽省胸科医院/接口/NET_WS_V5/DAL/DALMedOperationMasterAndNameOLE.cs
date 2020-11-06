using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.OracleClient;
using System.Data.SqlClient;
using MedicalSytem.Soft.Model;



/// <summary>
/// 解决数据同步时直接放入术前功能
/// </summary>

namespace MedicalSytem.Soft.DAL
{

    /// <summary>
    /// 
    /// </summary>
    public partial class DALMedOperationMasterAndName
    {
        private static readonly string Update_Operation_Schedule_OLE = "update med_operation_schedule set oper_id = ? Where patient_id = ? and visit_id = ? and schedule_id = ?";
        private static readonly string Select_Insert_Operation_Master_OLE = "select count(*) FROM med_operation_master Where patient_id = ? and visit_id = ? and oper_id = ?";
    
        private static readonly string Insert_Operation_Master_OLE = @"insert into med_operation_master(PATIENT_ID,VISIT_ID,OPER_ID,DEPT_STAYED,OPERATING_ROOM,OPERATING_ROOM_NO,
                                                                        DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,
                                                                        FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,
                                                                        ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,FIRST_OPERATION_NURSE,SECOND_OPERATION_NURSE,FIRST_SUPPLY_NURSE,
                                                                        SECOND_SUPPLY_NURSE,ENTERED_BY,THIRD_SUPPLY_NURSE,EMERGENCY_INDICATOR,SECOND_ANESTHESIA_ASSISTANT,
                                                                        THIRD_ANESTHESIA_ASSISTANT,FOURTH_ANESTHESIA_ASSISTANT,SCHEDULED_DATE_TIME,BED_NO,SEQUENCE ) 
                                                                        Select PATIENT_ID,VISIT_ID,OPER_ID,DEPT_STAYED,OPERATING_ROOM,OPERATING_ROOM_NO,DIAG_BEFORE_OPERATION,
                                                                        PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,FIRST_ASSISTANT,
                                                                        SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,
                                                                        ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,FIRST_OPERATION_NURSE,SECOND_OPERATION_NURSE,
                                                                        FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,ENTERED_BY,THIRD_SUPPLY_NURSE,EMERGENCY_INDICATOR,
                                                                        SECOND_ANESTHESIA_ASSISTANT,THIRD_ANESTHESIA_ASSISTANT,FOURTH_ANESTHESIA_ASSISTANT,SCHEDULED_DATE_TIME,BED_NO,SEQUENCE 
                                                                        FROM med_operation_schedule Where patient_id = ? and visit_id = ? and schedule_id = ?";
        private static readonly string Select_Insert_Operation_Name_OLE = "select count(*) FROM med_operation_name Where patient_id = ? and visit_id = ? and oper_id = ? ";
        //新增 2013-12-03 RESERVED2,RESERVED3,RESERVED4
        private static readonly string Insert_Operation_Name_OLE = @"insert into med_operation_name(PATIENT_ID,VISIT_ID,OPER_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4)
                                                                        select PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4
                                                                        FROM MED_OPERATION_SCHEDULE_NAME Where patient_id = ? and visit_id = ? and schedule_id = ? ";


        //V4版本MedOperationMaster ,OPERATION_POSITION, SPECIAL_EQUIPMENT,SPECIAL_INFECT  2013-12-3 RESERVED1,RESERVED2,RESERVED3, RESERVED4,RESERVED5,RESERVED6  
        private static readonly string Insert_Operation_Master_OLE_V4 = @"INSERT INTO MED_OPERATION_MASTER(PATIENT_ID,VISIT_ID, OPER_ID,
   HOSP_BRANCH, WARD_CODE,DEPT_CODE,
   OPER_ROOM, OPER_ROOM_NO, SEQUENCE,
   OPER_CLASS, DIAG_BEFORE_OPERATION, PATIENT_CONDITION,
   OPER_SCALE,WOUND_TYPE, ASA_GRADE,EMERGENCY_IND, OPER_SOURCE, ISOLATION_IND,
   INFECTED_IND, RADIATE_IND, SURGEON,
   FIRST_OPER_ASSISTANT, SECOND_OPER_ASSISTANT, THIRD_OPER_ASSISTANT,
   FOURTH_OPER_ASSISTANT, ANES_METHOD, ANES_DOCTOR, FIRST_ANES_ASSISTANT, SECOND_ANES_ASSISTANT, THIRD_ANES_ASSISTANT,
   FOURTH_ANES_ASSISTANT, FIRST_ANES_NURSE, SECOND_ANES_NURSE,
   THIRD_ANES_NURSE, CPB_DOCTOR, FIRST_CPB_ASSISTANT, SECOND_CPB_ASSISTANT, THIRD_CPB_ASSISTANT, FOURTH_CPB_ASSISTANT, FIRST_OPER_NURSE, SECOND_OPER_NURSE,
   THIRD_OPER_NURSE, FOURTH_OPER_NURSE, FIRST_SUPPLY_NURSE,
   SECOND_SUPPLY_NURSE, THIRD_SUPPLY_NURSE, FOURTH_SUPPLY_NURSE, PACU_DOCTOR, FIRST_PACU_ASSISTANT, SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,
   SECOND_PACU_NURSE, REQ_DATE_TIME, SCHEDULED_DATE_TIME, OPER_POSITION, BED_NO, OPERATION_NAME, HIS_PATIENT_ID, HIS_VISIT_ID, HIS_SCHEDULE_ID, HIS_OPER_STATUS,
   RESERVED01, RESERVED02 , RESERVED03,OPER_STATUS_CODE) 
                                                                                                                                            SELECT PATIENT_ID, VISIT_ID,  OPER_ID, HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,
         SEQUENCE,OPER_CLASS, DIAG_BEFORE_OPERATION, PATIENT_CONDITION, OPER_SCALE,
         WOUND_TYPE, ASA_GRADE,EMERGENCY_IND, OPER_SOURCE, ISOLATION_IND,INFECTED_IND, RADIATE_IND, SURGEON, FIRST_OPER_ASSISTANT, SECOND_OPER_ASSISTANT,
         THIRD_OPER_ASSISTANT, FOURTH_OPER_ASSISTANT,ANES_METHOD, ANES_DOCTOR, FIRST_ANES_ASSISTANT, SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT, FOURTH_ANES_ASSISTANT,  FIRST_ANES_NURSE, SECOND_ANES_NURSE, THIRD_ANES_NURSE, CPB_DOCTOR,FIRST_CPB_ASSISTANT, SECOND_CPB_ASSISTANT, THIRD_CPB_ASSISTANT, FOURTH_CPB_ASSISTANT, FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE, FOURTH_OPER_NURSE, FIRST_SUPPLY_NURSE, SECOND_SUPPLY_NURSE, THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE, PACU_DOCTOR,
         FIRST_PACU_ASSISTANT, SECOND_PACU_ASSISTANT,  FIRST_PACU_NURSE, SECOND_PACU_NURSE, REQ_DATE_TIME, SCHEDULED_DATE_TIME, OPER_POSITION,
         BED_NO,  OPERATION_NAME, HIS_PATIENT_ID, HIS_VISIT_ID, HIS_SCHEDULE_ID, HIS_OPER_STATUS, RESERVED1,  RESERVED2, RESERVED3,0
                                                                        FROM MED_OPERATION_SCHEDULE WHERE PATIENT_ID = ? AND VISIT_ID = ? AND SCHEDULE_ID = ?";

        //UpdateMed_Operation_Master和Med_Operation_Name内容 新增2013-12-03 OPERATION_POSITION, SPECIAL_EQUIPMENT,SPECIAL_INFECT  2013-12-3 RESERVED1,RESERVED2,RESERVED3, RESERVED4,RESERVED5,RESERVED6  
        private static readonly string Update_Med_Operation_Master_OLE = @"UPDATE MED_OPERATION_MASTER T1
                                                                       SET (      T1.HOSP_BRANCH, T1.WARD_CODE, T1.DEPT_CODE, T1.OPER_ROOM, T1.OPER_ROOM_NO, T1.SEQUENCE, T1.OPER_CLASS, T1.DIAG_BEFORE_OPERATION, T1.PATIENT_CONDITION, T1. OPER_SCALE, T1.WOUND_TYPE, T1.ASA_GRADE, 
    T1.EMERGENCY_IND, T1.OPER_SOURCE, T1.ISOLATION_IND, T1.INFECTED_IND, T1.RADIATE_IND, T1.SURGEON, T1.FIRST_OPER_ASSISTANT, 
T1.SECOND_OPER_ASSISTANT, T1.THIRD_OPER_ASSISTANT, T1.FOURTH_OPER_ASSISTANT, T1. ANES_METHOD, T1.ANES_DOCTOR, T1.FIRST_ANES_ASSISTANT, T1.SECOND_ANES_ASSISTANT, T1. THIRD_ANES_ASSISTANT, T1.FOURTH_ANES_ASSISTANT, 
T1.FIRST_ANES_NURSE, T1. SECOND_ANES_NURSE, T1.THIRD_ANES_NURSE, T1.CPB_DOCTOR, T1. FIRST_CPB_ASSISTANT, T1. SECOND_CPB_ASSISTANT, T1. THIRD_CPB_ASSISTANT, T1. FOURTH_CPB_ASSISTANT, T1. FIRST_OPER_NURSE, T1. SECOND_OPER_NURSE, 
T1. THIRD_OPER_NURSE, T1.FOURTH_OPER_NURSE, T1.FIRST_SUPPLY_NURSE, T1.SECOND_SUPPLY_NURSE, T1.THIRD_SUPPLY_NURSE, T1.FOURTH_SUPPLY_NURSE, T1.PACU_DOCTOR, T1.FIRST_PACU_ASSISTANT, T1.SECOND_PACU_ASSISTANT, T1.FIRST_PACU_NURSE, T1.SECOND_PACU_NURSE, T1.REQ_DATE_TIME, T1.SCHEDULED_DATE_TIME, T1.OPER_POSITION, T1.BED_NO, T1.OPERATION_NAME, T1.HIS_PATIENT_ID, T1.HIS_VISIT_ID, T1.HIS_SCHEDULE_ID, T1.HIS_OPER_STATUS, T1.RESERVED01, T1.RESERVED02, T1.RESERVED03)
                                                                                                                                               =(select T2.HOSP_BRANCH, T2.WARD_CODE, T2.DEPT_CODE, T2.OPER_ROOM, T2.OPER_ROOM_NO, T2.SEQUENCE, T2.OPER_CLASS, T2.DIAG_BEFORE_OPERATION, T2.PATIENT_CONDITION, T2. OPER_SCALE, T2.WOUND_TYPE, T2.ASA_GRADE, 
   T2.EMERGENCY_IND, T2.OPER_SOURCE, T2.ISOLATION_IND, T2.INFECTED_IND, T2.RADIATE_IND, T2.SURGEON, T2.FIRST_OPER_ASSISTANT, 
T2.SECOND_OPER_ASSISTANT, T2.THIRD_OPER_ASSISTANT, T2.FOURTH_OPER_ASSISTANT, T2. ANES_METHOD, T2.ANES_DOCTOR, T2.FIRST_ANES_ASSISTANT, T2.SECOND_ANES_ASSISTANT, T2. THIRD_ANES_ASSISTANT, T2.FOURTH_ANES_ASSISTANT,  
 T2.FIRST_ANES_NURSE, T2. SECOND_ANES_NURSE, T2.THIRD_ANES_NURSE, T2.CPB_DOCTOR, T2. FIRST_CPB_ASSISTANT, T2. SECOND_CPB_ASSISTANT, T2. THIRD_CPB_ASSISTANT, T2. FOURTH_CPB_ASSISTANT, T2. FIRST_OPER_NURSE, T2. SECOND_OPER_NURSE, 
T2.THIRD_OPER_NURSE, T2.FOURTH_OPER_NURSE, T2.FIRST_SUPPLY_NURSE, T2.SECOND_SUPPLY_NURSE, T2.THIRD_SUPPLY_NURSE, T2.FOURTH_SUPPLY_NURSE, T2.PACU_DOCTOR, T2.FIRST_PACU_ASSISTANT, T2.SECOND_PACU_ASSISTANT, T2.FIRST_PACU_NURSE, T2.SECOND_PACU_NURSE, T2.REQ_DATE_TIME, T2.SCHEDULED_DATE_TIME, T2.OPER_POSITION, T2.BED_NO, T2.OPERATION_NAME, T2.HIS_PATIENT_ID, T2.HIS_VISIT_ID, T2.HIS_SCHEDULE_ID, T2.HIS_OPER_STATUS, T2.RESERVED1, T2.RESERVED2, T2.RESERVED3
                                                                       from MED_OPERATION_SCHEDULE T2
                                                                       WHERE T1.PATIENT_ID = T2.PATIENT_ID AND T1.VISIT_ID = T2.VISIT_ID AND T1.OPER_ID = T2.SCHEDULE_ID
                                                                       AND (T1.OPER_STATUS = 0 OR T1.OPER_STATUS IS NULL) and  T2.patient_id =? and T2.visit_id =? and t2.schedule_id =?)
                                                                        where exists (select 1 from med_operation_schedule T2 where T2.patient_id = T1.patient_id 
                                                                        and T2.visit_id = T1.visit_id and T2.schedule_id = T1.oper_id) and T1.patient_id =? and T1.visit_id =? and T1.oper_id=? and (T1.OPER_STATUS = 0 OR T1.OPER_STATUS IS NULL) ";


        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {

                if (sqlParms == "UpdateMedOperationScheduleOperId")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("operId",OleDbType.Decimal),
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("scheduleId",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "InsertMedOperationMasterAndName")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("scheduleId",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "InsertMedOperationName")
                {
                    parms = new OleDbParameter[]{
                        //new OleDbParameter("scheduleId",OleDbType.Decimal),
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("scheduleId",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "SelectInsertMedOperationName")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("operId",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "UpdateMedOperationMasterAndName")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("operId",OleDbType.Decimal),
                        new OleDbParameter("patientId2",OleDbType.VarChar),
                        new OleDbParameter("visitId2",OleDbType.Decimal),
                        new OleDbParameter("operId2",OleDbType.Decimal),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        /// <summary>
        /// 更新MedSchedule记录
        /// </summary>
        /// <param name="patientId">The patient id.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <param name="operId">The oper id.</param>
        /// <returns></returns>
        public int UpdateMedOperationScheduleOLE(string patientId, decimal visitId, decimal scheduledId, decimal operId)
        {
            using (OleDbConnection oraConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] updateMedOperationSchedule = GetParameterOLE("UpdateMedOperationScheduleOperId");

                updateMedOperationSchedule[0].Value = operId;
                updateMedOperationSchedule[1].Value = patientId;
                updateMedOperationSchedule[2].Value = visitId;
                updateMedOperationSchedule[3].Value = scheduledId;

                return OleDbHelper.ExecuteNonQuery(oraConn, CommandType.Text, Update_Operation_Schedule_OLE, updateMedOperationSchedule);
            }

        }
        /// <summary>
        /// 更新MedOperationMaster记录OLE
        /// </summary>
        /// <param name="patientId">The patient id.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <param name="operId">The oper id.</param>
        /// <returns></returns>
        public int UpdateMedOperationMasterOLE(string patientId, decimal visitId, decimal scheduledId)
        {
            using (OleDbConnection oraConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] updateMedOperationMaster = GetParameterOLE("UpdateMedOperationMasterAndName");
                updateMedOperationMaster[0].Value = patientId;
                updateMedOperationMaster[1].Value = visitId;
                updateMedOperationMaster[2].Value = scheduledId;
                updateMedOperationMaster[3].Value = patientId;
                updateMedOperationMaster[4].Value = visitId;
                updateMedOperationMaster[5].Value = scheduledId;

                return OleDbHelper.ExecuteNonQuery(oraConn, CommandType.Text, Update_Med_Operation_Master_OLE, updateMedOperationMaster);
            }

        }
        /// <summary>
        /// Inserts the med operation master.
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <returns></returns>
        public int InsertMedOperationMasterOLE(string patientID, decimal visitId, decimal scheduledId)
        {
            using (OleDbConnection oraConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedOperationMasterAndName");

                oneInert[0].Value = patientID;
                oneInert[1].Value = visitId;
                oneInert[2].Value = scheduledId;

                int returnValue;
                using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(oraConn, CommandType.Text, Select_Insert_Operation_Master_OLE, oneInert))
                {
                    if (oleReader.Read())
                    {
                        returnValue = (int)oleReader.GetDecimal(0);
                    }
                    else
                    {
                        returnValue = 0;
                    }
                }
                if (returnValue < 1)
                {
                    return OleDbHelper.ExecuteNonQuery(oraConn, CommandType.Text, Insert_Operation_Master_OLE, oneInert);
                }
                else
                    return 0;
            }
        }
        /// <summary>
        /// Inserts the med operation master v4.
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <returns></returns>
        public int InsertMedOperationMasterOLEV4(string patientID, decimal visitId, decimal scheduledId)
        {
            using (OleDbConnection oraConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedOperationMasterAndName");

                oneInert[0].Value = patientID;
                oneInert[1].Value = visitId;
                oneInert[2].Value = scheduledId;

                int returnValue;
                using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(oraConn, CommandType.Text, Select_Insert_Operation_Master_OLE, oneInert))
                {
                    if (oleReader.Read())
                    {
                        returnValue = (int)oleReader.GetDecimal(0);
                    }
                    else
                    {
                        returnValue = 0;
                    }
                }
                if (returnValue < 1)
                {
                    return OleDbHelper.ExecuteNonQuery(oraConn, CommandType.Text, Insert_Operation_Master_OLE_V4, oneInert);
                }
                else
                    return 0;
            }
        }
        /// <summary>
        /// Inserts the med operation Name.
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <param name="operId">The oper id.</param>
        /// <returns></returns>
        public int InsertMedOperationNameOLE(string patientID, decimal visitId, decimal scheduledId, decimal operId)
        {
            using (OleDbConnection oraConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("SelectInsertMedOperationName");
                oneInert[0].Value = patientID;
                oneInert[1].Value = visitId;
                oneInert[2].Value = scheduledId;

                int returnValue;
                using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(oraConn, CommandType.Text, Select_Insert_Operation_Name_OLE, oneInert))
                {
                    if (oleReader.Read())
                    {
                        returnValue = (int)oleReader.GetDecimal(0);
                    }
                    else
                    {
                        returnValue = 0;
                    }
                }
                if (returnValue < 1)
                {
                    OleDbParameter[] oneInert2 = GetParameterOLE("InsertMedOperationName");
                    oneInert2[0].Value = patientID;
                    oneInert2[1].Value = visitId;
                    oneInert2[2].Value = scheduledId;

                    return OleDbHelper.ExecuteNonQuery(oraConn, CommandType.Text, Insert_Operation_Name_OLE, oneInert2);
                }
                else
                    return 0;
            }
        }
        /// <summary>
        /// 同步的同时写手术主记录信息
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <returns></returns>
        public int MedOperationMasterAndOperationNameOLE(string patientID, decimal visitId, decimal operId)
        {
            int rtn = 0;

            rtn = UpdateMedOperationScheduleOLE(patientID, visitId, operId, operId);
            if (rtn < 0) return -1;

            rtn = InsertMedOperationMasterOLE(patientID, visitId, operId);
            if (rtn < 0) return -1;

            rtn = InsertMedOperationNameOLE(patientID, visitId, operId, operId);
            if (rtn < 0) return -1;

            return 1;
        }
        /// <summary>
        /// 同步的同时写手术主记录信息v4
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <returns></returns>
        public int MedOperationMasterAndOperationNameOLEV4(string patientID, decimal visitId, decimal operId)
        {
            int rtn = 0;

            rtn = UpdateMedOperationScheduleOLE(patientID, visitId, operId, operId);
            if (rtn < 0) return -1;

            rtn = InsertMedOperationMasterOLEV4(patientID, visitId, operId);
            if (rtn < 0) return -1;

            rtn = InsertMedOperationNameOLE(patientID, visitId, operId, operId);
            if (rtn < 0) return -1;

            rtn = UpdateMedOperationMasterOLE(patientID, visitId, operId);
            if (rtn < 0) return -1;

            return 1;
        }

        private static readonly string Update_Operation_Schedule_Odbc = "update med_operation_schedule set oper_id = ?  Where patient_id = ? and visit_id = ? and schedule_id = ?";
        private static readonly string Select_Insert_Operation_Master_Odbc = "select count(*) FROM med_operation_master Where patient_id = ? and visit_id = ? and oper_id = ?";
        private static readonly string Insert_Operation_Master_Odbc = @"insert into med_operation_master(PATIENT_ID,VISIT_ID,OPER_ID,DEPT_STAYED,OPERATING_ROOM,OPERATING_ROOM_NO,
                                                                        DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,
                                                                        FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,
                                                                        ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,FIRST_OPERATION_NURSE,SECOND_OPERATION_NURSE,FIRST_SUPPLY_NURSE,
                                                                        SECOND_SUPPLY_NURSE,ENTERED_BY,THIRD_SUPPLY_NURSE,EMERGENCY_INDICATOR,SECOND_ANESTHESIA_ASSISTANT,
                                                                        THIRD_ANESTHESIA_ASSISTANT,FOURTH_ANESTHESIA_ASSISTANT,SCHEDULED_DATE_TIME,BED_NO,SEQUENCE ) 
                                                                        Select PATIENT_ID,VISIT_ID,OPER_ID,DEPT_STAYED,OPERATING_ROOM,OPERATING_ROOM_NO,DIAG_BEFORE_OPERATION,
                                                                        PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,FIRST_ASSISTANT,
                                                                        SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,
                                                                        ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,FIRST_OPERATION_NURSE,SECOND_OPERATION_NURSE,
                                                                        FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,ENTERED_BY,THIRD_SUPPLY_NURSE,EMERGENCY_INDICATOR,
                                                                        SECOND_ANESTHESIA_ASSISTANT,THIRD_ANESTHESIA_ASSISTANT,FOURTH_ANESTHESIA_ASSISTANT,SCHEDULED_DATE_TIME,BED_NO,SEQUENCE 
                                                                        FROM med_operation_schedule Where patient_id = ? and visit_id = ? and schedule_id = ?";
        private static readonly string Select_Insert_Operation_Name_Odbc = "select count(*) FROM med_operation_name Where patient_id = ? and visit_id = ? and oper_id = ? ";
        private static readonly string Insert_Operation_Name_Odbc = @"insert into med_operation_name(PATIENT_ID,VISIT_ID,OPER_ID,OPERATION_NO,OPERATION,OPERATION_CODE,OPERATION_SCALE, RESERVED2,RESERVED3,RESERVED4)
                                                                        select PATIENT_ID,VISIT_ID,SCHEDULE_ID OPER_ID,OPERATION_NO,OPERATION,OPERATION_CODE,OPERATION_SCALE , RESERVED2,RESERVED3,RESERVED4
                                                                        FROM MED_OPERATION_SCHEDULE_NAME Where patient_id = ? and visit_id = ? and schedule_id = ? ";
        //V4版本MedOperationMaster  ,OPERATION_POSITION, SPECIAL_EQUIPMENT,SPECIAL_INFECT 2013-12-01
        private static readonly string Insert_Operation_Master_Odbc_V4 = @"INSERT INTO MED_OPERATION_MASTER(PATIENT_ID,VISIT_ID, OPER_ID,
   HOSP_BRANCH, WARD_CODE,DEPT_CODE,
   OPER_ROOM, OPER_ROOM_NO, SEQUENCE,
   OPER_CLASS, DIAG_BEFORE_OPERATION, PATIENT_CONDITION,
   OPER_SCALE,WOUND_TYPE, ASA_GRADE,EMERGENCY_IND, OPER_SOURCE, ISOLATION_IND,
   INFECTED_IND, RADIATE_IND, SURGEON,
   FIRST_OPER_ASSISTANT, SECOND_OPER_ASSISTANT, THIRD_OPER_ASSISTANT,
   FOURTH_OPER_ASSISTANT, ANES_METHOD, ANES_DOCTOR, FIRST_ANES_ASSISTANT, SECOND_ANES_ASSISTANT, THIRD_ANES_ASSISTANT,
   FOURTH_ANES_ASSISTANT, FIRST_ANES_NURSE, SECOND_ANES_NURSE,
   THIRD_ANES_NURSE, CPB_DOCTOR, FIRST_CPB_ASSISTANT, SECOND_CPB_ASSISTANT, THIRD_CPB_ASSISTANT, FOURTH_CPB_ASSISTANT, FIRST_OPER_NURSE, SECOND_OPER_NURSE,
   THIRD_OPER_NURSE, FOURTH_OPER_NURSE, FIRST_SUPPLY_NURSE,
   SECOND_SUPPLY_NURSE, THIRD_SUPPLY_NURSE, FOURTH_SUPPLY_NURSE, PACU_DOCTOR, FIRST_PACU_ASSISTANT, SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,
   SECOND_PACU_NURSE, REQ_DATE_TIME, SCHEDULED_DATE_TIME, OPER_POSITION, BED_NO, OPERATION_NAME, HIS_PATIENT_ID, HIS_VISIT_ID, HIS_SCHEDULE_ID, HIS_OPER_STATUS,
   RESERVED01, RESERVED02 , RESERVED03,OPER_STATUS_CODE) 
                                                                                                                        SELECT PATIENT_ID, VISIT_ID,  OPER_ID, HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,
         SEQUENCE,OPER_CLASS, DIAG_BEFORE_OPERATION, PATIENT_CONDITION, OPER_SCALE,
         WOUND_TYPE, ASA_GRADE,EMERGENCY_IND, OPER_SOURCE, ISOLATION_IND,INFECTED_IND, RADIATE_IND, SURGEON, FIRST_OPER_ASSISTANT, SECOND_OPER_ASSISTANT,
         THIRD_OPER_ASSISTANT, FOURTH_OPER_ASSISTANT,ANES_METHOD, ANES_DOCTOR, FIRST_ANES_ASSISTANT, SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT, FOURTH_ANES_ASSISTANT,  FIRST_ANES_NURSE, SECOND_ANES_NURSE, THIRD_ANES_NURSE, CPB_DOCTOR,FIRST_CPB_ASSISTANT, SECOND_CPB_ASSISTANT, THIRD_CPB_ASSISTANT, FOURTH_CPB_ASSISTANT, FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE, FOURTH_OPER_NURSE, FIRST_SUPPLY_NURSE, SECOND_SUPPLY_NURSE, THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE, PACU_DOCTOR,
         FIRST_PACU_ASSISTANT, SECOND_PACU_ASSISTANT,  FIRST_PACU_NURSE, SECOND_PACU_NURSE, REQ_DATE_TIME, SCHEDULED_DATE_TIME, OPER_POSITION,
         BED_NO,  OPERATION_NAME, HIS_PATIENT_ID, HIS_VISIT_ID, HIS_SCHEDULE_ID, HIS_OPER_STATUS, RESERVED1,  RESERVED2, RESERVED3,0
                                                                        FROM MED_OPERATION_SCHEDULE WHERE PATIENT_ID = ? AND VISIT_ID = ? AND SCHEDULE_ID = ?";

        private static readonly string Update_Med_Operation_Master_ODBC = @"UPDATE MED_OPERATION_MASTER T1
                                                                       SET (    T1.HOSP_BRANCH, T1.WARD_CODE, T1.DEPT_CODE, T1.OPER_ROOM, T1.OPER_ROOM_NO, T1.SEQUENCE, T1.OPER_CLASS, T1.DIAG_BEFORE_OPERATION, T1.PATIENT_CONDITION, T1. OPER_SCALE, T1.WOUND_TYPE, T1.ASA_GRADE, 
    T1.EMERGENCY_IND, T1.OPER_SOURCE, T1.ISOLATION_IND, T1.INFECTED_IND, T1.RADIATE_IND, T1.SURGEON, T1.FIRST_OPER_ASSISTANT, 
T1.SECOND_OPER_ASSISTANT, T1.THIRD_OPER_ASSISTANT, T1.FOURTH_OPER_ASSISTANT, T1. ANES_METHOD, T1.ANES_DOCTOR, T1.FIRST_ANES_ASSISTANT, T1.SECOND_ANES_ASSISTANT, T1. THIRD_ANES_ASSISTANT, T1.FOURTH_ANES_ASSISTANT, 
T1.FIRST_ANES_NURSE, T1. SECOND_ANES_NURSE, T1.THIRD_ANES_NURSE, T1.CPB_DOCTOR, T1. FIRST_CPB_ASSISTANT, T1. SECOND_CPB_ASSISTANT, T1. THIRD_CPB_ASSISTANT, T1. FOURTH_CPB_ASSISTANT, T1. FIRST_OPER_NURSE, T1. SECOND_OPER_NURSE, 
T1. THIRD_OPER_NURSE, T1.FOURTH_OPER_NURSE, T1.FIRST_SUPPLY_NURSE, T1.SECOND_SUPPLY_NURSE, T1.THIRD_SUPPLY_NURSE, T1.FOURTH_SUPPLY_NURSE, T1.PACU_DOCTOR, T1.FIRST_PACU_ASSISTANT, T1.SECOND_PACU_ASSISTANT, T1.FIRST_PACU_NURSE, T1.SECOND_PACU_NURSE, T1.REQ_DATE_TIME, T1.SCHEDULED_DATE_TIME, T1.OPER_POSITION, T1.BED_NO, T1.OPERATION_NAME, T1.HIS_PATIENT_ID, T1.HIS_VISIT_ID, T1.HIS_SCHEDULE_ID, T1.HIS_OPER_STATUS, T1.RESERVED01, T1.RESERVED02, T1.RESERVED03
                                                                           ) =(select  T2.HOSP_BRANCH, T2.WARD_CODE, T2.DEPT_CODE, T2.OPER_ROOM, T2.OPER_ROOM_NO, T2.SEQUENCE, T2.OPER_CLASS, T2.DIAG_BEFORE_OPERATION, T2.PATIENT_CONDITION, T2. OPER_SCALE, T2.WOUND_TYPE, T2.ASA_GRADE, 
   T2.EMERGENCY_IND, T2.OPER_SOURCE, T2.ISOLATION_IND, T2.INFECTED_IND, T2.RADIATE_IND, T2.SURGEON, T2.FIRST_OPER_ASSISTANT, 
T2.SECOND_OPER_ASSISTANT, T2.THIRD_OPER_ASSISTANT, T2.FOURTH_OPER_ASSISTANT, T2. ANES_METHOD, T2.ANES_DOCTOR, T2.FIRST_ANES_ASSISTANT, T2.SECOND_ANES_ASSISTANT, T2. THIRD_ANES_ASSISTANT, T2.FOURTH_ANES_ASSISTANT,  
 T2.FIRST_ANES_NURSE, T2. SECOND_ANES_NURSE, T2.THIRD_ANES_NURSE, T2.CPB_DOCTOR, T2. FIRST_CPB_ASSISTANT, T2. SECOND_CPB_ASSISTANT, T2. THIRD_CPB_ASSISTANT, T2. FOURTH_CPB_ASSISTANT, T2. FIRST_OPER_NURSE, T2. SECOND_OPER_NURSE, 
T2.THIRD_OPER_NURSE, T2.FOURTH_OPER_NURSE, T2.FIRST_SUPPLY_NURSE, T2.SECOND_SUPPLY_NURSE, T2.THIRD_SUPPLY_NURSE, T2.FOURTH_SUPPLY_NURSE, T2.PACU_DOCTOR, T2.FIRST_PACU_ASSISTANT, T2.SECOND_PACU_ASSISTANT, T2.FIRST_PACU_NURSE, T2.SECOND_PACU_NURSE, T2.REQ_DATE_TIME, T2.SCHEDULED_DATE_TIME, T2.OPER_POSITION, T2.BED_NO, T2.OPERATION_NAME, T2.HIS_PATIENT_ID, T2.HIS_VISIT_ID, T2.HIS_SCHEDULE_ID, T2.HIS_OPER_STATUS, T2.RESERVED1, T2.RESERVED2, T2.RESERVED3
                                                                     from MED_OPERATION_SCHEDULE T2
                                                                       WHERE T1.PATIENT_ID = T2.PATIENT_ID AND T1.VISIT_ID = T2.VISIT_ID AND T1.OPER_ID = T2.SCHEDULE_ID
                                                                       AND (T1.OPER_STATUS = 0 OR T1.OPER_STATUS IS NULL) and  T2.patient_id =? and T2.visit_id =? and t2.schedule_id =?)
                                                                        where exists (select 1 from med_operation_schedule T2 where T2.patient_id = T1.patient_id 
                                                                        and T2.visit_id = T1.visit_id and T2.schedule_id = T1.oper_id) and T1.patient_id =? and T1.visit_id =? and T1.oper_id=? and (T1.OPER_STATUS = 0 OR T1.OPER_STATUS IS NULL) ";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {

                if (sqlParms == "UpdateMedOperationScheduleOperId")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("operId",OdbcType.Decimal),
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("scheduleId",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "InsertMedOperationMasterAndName")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("scheduleId",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "InsertMedOperationNameAndName")
                {
                    parms = new OdbcParameter[]{
                        //new OdbcParameter("scheduleId",OdbcType.Decimal),
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("scheduleId",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "SelectInsertMedOperationName")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("operId",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "UpdateMedOperationMaster")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("operId",OdbcType.Decimal),
                        new OdbcParameter("patientId2",OdbcType.VarChar),
                        new OdbcParameter("visitId2",OdbcType.Decimal),
                        new OdbcParameter("operId2",OdbcType.Decimal),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        /// <summary>
        /// 更新MedSchedule记录
        /// </summary>
        /// <param name="patientId">The patient id.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <param name="operId">The oper id.</param>
        /// <returns></returns>
        public int UpdateMedOperationScheduleOdbc(string patientId, decimal visitId, decimal scheduledId, decimal operId)
        {
            using (OdbcConnection oraConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] updateMedOperationSchedule = GetParameterOdbc("UpdateMedOperationScheduleOperId");

                updateMedOperationSchedule[0].Value = operId;
                updateMedOperationSchedule[1].Value = patientId;
                updateMedOperationSchedule[2].Value = visitId;
                updateMedOperationSchedule[3].Value = scheduledId;

                return OdbcHelper.ExecuteNonQuery(oraConn, CommandType.Text, Update_Operation_Schedule_Odbc, updateMedOperationSchedule);
            }

        }
        /// <summary>
        /// 更新MedOperationMaster记录ODBC
        /// </summary>
        /// <param name="patientId">The patient id.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <param name="operId">The oper id.</param>
        /// <returns></returns>
        public int UpdateMedOperationMasterODBC(string patientId, decimal visitId, decimal scheduledId)
        {
            using (OdbcConnection oraConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] updateMedOperationMaster = GetParameterOdbc("UpdateMedOperationMasterAndName");
                updateMedOperationMaster[0].Value = patientId;
                updateMedOperationMaster[1].Value = visitId;
                updateMedOperationMaster[2].Value = scheduledId;
                updateMedOperationMaster[3].Value = patientId;
                updateMedOperationMaster[4].Value = visitId;
                updateMedOperationMaster[5].Value = scheduledId;

                return OdbcHelper.ExecuteNonQuery(oraConn, CommandType.Text, Update_Med_Operation_Master_ODBC, updateMedOperationMaster);
            }

        }
        /// <summary>
        /// Inserts the med operation master.
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <returns></returns>
        public int InsertMedOperationMasterOdbc(string patientID, decimal visitId, decimal scheduledId)
        {
            using (OdbcConnection oraConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedOperationMasterAndName");

                oneInert[0].Value = patientID;
                oneInert[1].Value = visitId;
                oneInert[2].Value = scheduledId;

                int returnValue;
                using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(oraConn, CommandType.Text, Select_Insert_Operation_Master_Odbc, oneInert))
                {
                    if (OdbcReader.Read())
                    {
                        returnValue = (int)OdbcReader.GetDecimal(0);
                    }
                    else
                    {
                        returnValue = 0;
                    }
                }
                if (returnValue < 1)
                {
                    return OdbcHelper.ExecuteNonQuery(oraConn, CommandType.Text, Insert_Operation_Master_Odbc, oneInert);
                }
                else
                    return 0;
            }
        }
        /// <summary>
        /// Inserts the med operation master v4.
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <returns></returns>
        public int InsertMedOperationMasterOdbcV4(string patientID, decimal visitId, decimal scheduledId)
        {
            using (OdbcConnection oraConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedOperationMasterAndName");

                oneInert[0].Value = patientID;
                oneInert[1].Value = visitId;
                oneInert[2].Value = scheduledId;

                int returnValue;
                using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(oraConn, CommandType.Text, Select_Insert_Operation_Master_Odbc, oneInert))
                {
                    if (OdbcReader.Read())
                    {
                        returnValue = (int)OdbcReader.GetDecimal(0);
                    }
                    else
                    {
                        returnValue = 0;
                    }
                }
                if (returnValue < 1)
                {
                    return OdbcHelper.ExecuteNonQuery(oraConn, CommandType.Text, Insert_Operation_Master_Odbc_V4, oneInert);
                }
                else
                    return 0;
            }
        }
        /// <summary>
        /// Inserts the med operation Name.
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <param name="operId">The oper id.</param>
        /// <returns></returns>
        public int InsertMedOperationNameOdbc(string patientID, decimal visitId, decimal scheduledId, decimal operId)
        {
            using (OdbcConnection oraConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("SelectInsertMedOperationName");
                oneInert[0].Value = patientID;
                oneInert[1].Value = visitId;
                oneInert[2].Value = scheduledId;

                int returnValue;
                using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(oraConn, CommandType.Text, Select_Insert_Operation_Name_Odbc, oneInert))
                {
                    if (OdbcReader.Read())
                    {
                        returnValue = (int)OdbcReader.GetDecimal(0);
                    }
                    else
                    {
                        returnValue = 0;
                    }
                }
                if (returnValue < 1)
                {
                    OdbcParameter[] oneInert2 = GetParameterOdbc("InsertMedOperationName");
                    oneInert2[0].Value = patientID;
                    oneInert2[1].Value = visitId;
                    oneInert2[2].Value = scheduledId;

                    return OdbcHelper.ExecuteNonQuery(oraConn, CommandType.Text, Insert_Operation_Name_Odbc, oneInert2);
                }
                else
                    return 0;
            }
        }
        /// <summary>
        /// 同步的同时写手术主记录信息
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <returns></returns>
        public int MedOperationMasterAndOperationNameOdbc(string patientID, decimal visitId, decimal operId)
        {
            int rtn = 0;

            rtn = UpdateMedOperationScheduleOdbc(patientID, visitId, operId, operId);
            if (rtn < 0) return -1;

            rtn = InsertMedOperationMasterOdbc(patientID, visitId, operId);
            if (rtn < 0) return -1;

            rtn = InsertMedOperationNameOdbc(patientID, visitId, operId, operId);
            if (rtn < 0) return -1;

            return 1;
        }
        /// <summary>
        /// 同步的同时写手术主记录信息ODBCv4
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <returns></returns>
        public int MedOperationMasterAndOperationNameOdbcV4(string patientID, decimal visitId, decimal operId)
        {
            int rtn = 0;

            rtn = UpdateMedOperationScheduleOdbc(patientID, visitId, operId, operId);
            if (rtn < 0) return -1;

            rtn = InsertMedOperationMasterOdbcV4(patientID, visitId, operId);
            if (rtn < 0) return -1;

            rtn = InsertMedOperationNameOdbc(patientID, visitId, operId, operId);
            if (rtn < 0) return -1;

            rtn = UpdateMedOperationMasterODBC(patientID, visitId, operId);
            if (rtn < 0) return -1;

            return 1;
        }
    }
}
