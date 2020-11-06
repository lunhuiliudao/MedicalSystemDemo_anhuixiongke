using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
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
        private static readonly string Update_Med_Operation_Schedule = "update med_operation_schedule set oper_id = :operId  Where patient_id = :patientId and visit_id = :visitId and schedule_id = :scheduleId";
        private static readonly string Select_Insert_Med_Operation_Master = "select count(*) FROM med_operation_master Where patient_id = :patientId and visit_id = :visitId and oper_id = :scheduleId";
        private static readonly string Insert_Med_Operation_Master = @"insert into med_operation_master(PATIENT_ID, VISIT_ID,OPER_ID,HOSP_BRANCH,
                                       WARD_CODE,DEPT_CODE, OPER_ROOM,  OPER_ROOM_NO,SEQUENCE, OPER_CLASS,  DIAG_BEFORE_OPERATION, PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,WOUND_NUMBER,ASA_GRADE,DIAG_AFTER_OPERATION,
                                       EMERGENCY_IND, OPER_SOURCE, ISOLATION_IND,  INFECTED_IND, RADIATE_IND, SURGEON, FIRST_OPER_ASSISTANT, SECOND_OPER_ASSISTANT, THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,
                                       ANES_METHOD, ANES_DOCTOR, FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT, THIRD_ANES_ASSISTANT,  FOURTH_ANES_ASSISTANT, FIRST_ANES_NURSE,
                                       SECOND_ANES_NURSE, THIRD_ANES_NURSE, CPB_DOCTOR, FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT, THIRD_CPB_ASSISTANT, FOURTH_CPB_ASSISTANT, FIRST_OPER_NURSE,  SECOND_OPER_NURSE,
                                       THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED01,RESERVED02,RESERVED03) 
                                                                                                            Select PATIENT_ID, VISIT_ID,OPER_ID,HOSP_BRANCH,
                                       WARD_CODE,DEPT_CODE, OPER_ROOM,  OPER_ROOM_NO,SEQUENCE, OPER_CLASS,  DIAG_BEFORE_OPERATION, PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,WOUND_NUMBER,ASA_GRADE,DIAG_AFTER_OPERATION,
                                       EMERGENCY_IND, OPER_SOURCE, ISOLATION_IND,  INFECTED_IND, RADIATE_IND, SURGEON, FIRST_OPER_ASSISTANT, SECOND_OPER_ASSISTANT, THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,
                                       ANES_METHOD, ANES_DOCTOR, FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT, THIRD_ANES_ASSISTANT,  FOURTH_ANES_ASSISTANT, FIRST_ANES_NURSE,
                                       SECOND_ANES_NURSE, THIRD_ANES_NURSE, CPB_DOCTOR, FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT, THIRD_CPB_ASSISTANT, FOURTH_CPB_ASSISTANT, FIRST_OPER_NURSE,  SECOND_OPER_NURSE,
                                       THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED01,RESERVED02,RESERVED03 
                                                                        FROM med_operation_schedule Where patient_id = :patientId and visit_id = :visitId and schedule_id = :scheduleId";
        private static readonly string Select_Insert_Med_Operation_Name = "select count(*) FROM med_operation_name Where patient_id = :patientId and visit_id = :visitId and oper_id = :scheduleId ";
        private static readonly string Insert_Med_Operation_Name = @"insert into med_operation_name(PATIENT_ID,VISIT_ID,OPER_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4)
                                                                        select PATIENT_ID,VISIT_ID,schedule_Id,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4
                                                                        FROM MED_OPERATION_SCHEDULE_NAME Where patient_id = :patientId and visit_id = :visitId and schedule_id = :scheduleId ";

        private static readonly string Update_Med_Operation_Schedule_SQL = "update med_operation_schedule set oper_id = @operId  Where patient_id = @patientId and visit_id = @visitId and schedule_id = @scheduleId";
        private static readonly string Select_Insert_Med_Operation_Master_SQL = "select count(*) FROM med_operation_master Where patient_id = @patientId and visit_id = @visitId and oper_id = @scheduleId";
        private static readonly string Insert_Med_Operation_Master_SQL = @"insert into med_operation_master(PATIENT_ID,VISIT_ID,OPER_ID,DEPT_STAYED,OPERATING_ROOM,OPERATING_ROOM_NO,
                                                                        DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,
                                                                        FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,
                                                                        ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,FIRST_OPERATION_NURSE,SECOND_OPERATION_NURSE,FIRST_SUPPLY_NURSE,
                                                                        SECOND_SUPPLY_NURSE,ENTERED_BY,THIRD_SUPPLY_NURSE,EMERGENCY_INDICATOR,SECOND_ANESTHESIA_ASSISTANT,
                                                                        THIRD_ANESTHESIA_ASSISTANT,FOURTH_ANESTHESIA_ASSISTANT,BED_NO,SEQUENCE ) 
                                                                        Select PATIENT_ID,VISIT_ID,OPER_ID,DEPT_STAYED,OPERATING_ROOM,OPERATING_ROOM_NO,DIAG_BEFORE_OPERATION,
                                                                        PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,FIRST_ASSISTANT,
                                                                        SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,
                                                                        ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,FIRST_OPERATION_NURSE,SECOND_OPERATION_NURSE,
                                                                        FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,ENTERED_BY,THIRD_SUPPLY_NURSE,EMERGENCY_INDICATOR,
                                                                        SECOND_ANESTHESIA_ASSISTANT,THIRD_ANESTHESIA_ASSISTANT,FOURTH_ANESTHESIA_ASSISTANT ,BED_NO,SEQUENCE
                                                                        FROM med_operation_schedule Where patient_id = @patientId and visit_id = @visitId and schedule_id = @scheduleId";
        private static readonly string Select_Insert_Med_Operation_Name_SQL = "select count(*) FROM med_operation_name Where patient_id = @patientId and visit_id = @visitId and oper_id = @scheduleId ";
        private static readonly string Insert_Med_Operation_Name_SQL = @"insert into med_operation_name(PATIENT_ID,VISIT_ID,OPER_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4
                                                                        )
                                                                        select PATIENT_ID,VISIT_ID,schedule_Id,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4
                                                                        FROM MED_OPERATION_SCHEDULE_NAME Where patient_id = @patientId and visit_id = @visitId and schedule_id = @scheduleId ";

        //V4版本MedOperationMaster 添加体位 特殊器材  感染标志  RESERVED1,RESERVED2,RESERVED3,  RESERVED4,RESERVED5,RESERVED6 备用字段
        private static readonly string Insert_Med_Operation_Master_V4 = @"INSERT INTO MED_OPERATION_MASTER(PATIENT_ID,VISIT_ID, OPER_ID,
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
   RESERVED01, RESERVED02 ,RESERVED03,OPER_STATUS_CODE) 
                                                                        SELECT PATIENT_ID, VISIT_ID,  OPER_ID, HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,
         SEQUENCE,OPER_CLASS, DIAG_BEFORE_OPERATION, PATIENT_CONDITION, OPER_SCALE,
         WOUND_TYPE, ASA_GRADE,EMERGENCY_IND, OPER_SOURCE, ISOLATION_IND,INFECTED_IND, RADIATE_IND, SURGEON, FIRST_OPER_ASSISTANT, SECOND_OPER_ASSISTANT,
         THIRD_OPER_ASSISTANT, FOURTH_OPER_ASSISTANT,ANES_METHOD, ANES_DOCTOR, FIRST_ANES_ASSISTANT, SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT, FOURTH_ANES_ASSISTANT,  FIRST_ANES_NURSE, SECOND_ANES_NURSE, THIRD_ANES_NURSE, CPB_DOCTOR,FIRST_CPB_ASSISTANT, SECOND_CPB_ASSISTANT, THIRD_CPB_ASSISTANT, FOURTH_CPB_ASSISTANT, FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE, FOURTH_OPER_NURSE, FIRST_SUPPLY_NURSE, SECOND_SUPPLY_NURSE, THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE, PACU_DOCTOR,
         FIRST_PACU_ASSISTANT, SECOND_PACU_ASSISTANT,  FIRST_PACU_NURSE, SECOND_PACU_NURSE, REQ_DATE_TIME, SCHEDULED_DATE_TIME, OPER_POSITION,
         BED_NO,  OPERATION_NAME, HIS_PATIENT_ID, HIS_VISIT_ID, HIS_SCHEDULE_ID, HIS_OPER_STATUS, RESERVED1,  RESERVED2, RESERVED3,0
                                                                        FROM MED_OPERATION_SCHEDULE WHERE PATIENT_ID = :PATIENTID AND VISIT_ID = :VISITID AND SCHEDULE_ID = :SCHEDULEID";

        //,OPERATION_POSITION, SPECIAL_EQUIPMENT,SPECIAL_INFECT 2013-12-03  RESERVED1,RESERVED2,RESERVED3,  RESERVED4,RESERVED5,RESERVED6 
        private static readonly string Insert_Med_Operation_Master_SQL_V4 = @"INSERT INTO MED_OPERATION_MASTER(PATIENT_ID,VISIT_ID, OPER_ID,
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
                                                                       FROM MED_OPERATION_SCHEDULE WHERE PATIENT_ID = @PATIENTID AND VISIT_ID = @VISITID AND SCHEDULE_ID = @SCHEDULEID";

        //UpdateMed_Operation_Master和Med_Operation_Name内容
        private static readonly string Update_Med_Operation_Master = @"UPDATE MED_OPERATION_MASTER T1
                                                                       SET (    T1.HOSP_BRANCH, T1.WARD_CODE, T1.DEPT_CODE, T1.OPER_ROOM, T1.OPER_ROOM_NO, T1.SEQUENCE, T1.OPER_CLASS, T1.DIAG_BEFORE_OPERATION, T1.PATIENT_CONDITION, T1. OPER_SCALE, T1.WOUND_TYPE, T1.ASA_GRADE, 
    T1.EMERGENCY_IND, T1.OPER_SOURCE, T1.ISOLATION_IND, T1.INFECTED_IND, T1.RADIATE_IND, T1.SURGEON, T1.FIRST_OPER_ASSISTANT, 
T1.SECOND_OPER_ASSISTANT, T1.THIRD_OPER_ASSISTANT, T1.FOURTH_OPER_ASSISTANT, T1. ANES_METHOD, T1.ANES_DOCTOR, T1.FIRST_ANES_ASSISTANT, T1.SECOND_ANES_ASSISTANT, T1. THIRD_ANES_ASSISTANT, T1.FOURTH_ANES_ASSISTANT, 
T1.FIRST_ANES_NURSE, T1. SECOND_ANES_NURSE, T1.THIRD_ANES_NURSE, T1.CPB_DOCTOR, T1. FIRST_CPB_ASSISTANT, T1. SECOND_CPB_ASSISTANT, T1. THIRD_CPB_ASSISTANT, T1. FOURTH_CPB_ASSISTANT, T1. FIRST_OPER_NURSE, T1. SECOND_OPER_NURSE, 
T1. THIRD_OPER_NURSE, T1.FOURTH_OPER_NURSE, T1.FIRST_SUPPLY_NURSE, T1.SECOND_SUPPLY_NURSE, T1.THIRD_SUPPLY_NURSE, T1.FOURTH_SUPPLY_NURSE, T1.PACU_DOCTOR, T1.FIRST_PACU_ASSISTANT, T1.SECOND_PACU_ASSISTANT, T1.FIRST_PACU_NURSE, T1.SECOND_PACU_NURSE, T1.REQ_DATE_TIME, T1.SCHEDULED_DATE_TIME, T1.OPER_POSITION, T1.BED_NO, T1.OPERATION_NAME, T1.HIS_PATIENT_ID, T1.HIS_VISIT_ID, T1.HIS_SCHEDULE_ID, T1.HIS_OPER_STATUS, T1.RESERVED01, T1.RESERVED02, T1.RESERVED03 )
                                                                       =(select  T2.HOSP_BRANCH, T2.WARD_CODE, T2.DEPT_CODE, T2.OPER_ROOM, T2.OPER_ROOM_NO, T2.SEQUENCE, T2.OPER_CLASS, T2.DIAG_BEFORE_OPERATION, T2.PATIENT_CONDITION, T2. OPER_SCALE, T2.WOUND_TYPE, T2.ASA_GRADE, 
   T2.EMERGENCY_IND, T2.OPER_SOURCE, T2.ISOLATION_IND, T2.INFECTED_IND, T2.RADIATE_IND, T2.SURGEON, T2.FIRST_OPER_ASSISTANT, 
T2.SECOND_OPER_ASSISTANT, T2.THIRD_OPER_ASSISTANT, T2.FOURTH_OPER_ASSISTANT, T2. ANES_METHOD, T2.ANES_DOCTOR, T2.FIRST_ANES_ASSISTANT, T2.SECOND_ANES_ASSISTANT, T2. THIRD_ANES_ASSISTANT, T2.FOURTH_ANES_ASSISTANT,  
 T2.FIRST_ANES_NURSE, T2. SECOND_ANES_NURSE, T2.THIRD_ANES_NURSE, T2.CPB_DOCTOR, T2. FIRST_CPB_ASSISTANT, T2. SECOND_CPB_ASSISTANT, T2. THIRD_CPB_ASSISTANT, T2. FOURTH_CPB_ASSISTANT, T2. FIRST_OPER_NURSE, T2. SECOND_OPER_NURSE, 
T2.THIRD_OPER_NURSE, T2.FOURTH_OPER_NURSE, T2.FIRST_SUPPLY_NURSE, T2.SECOND_SUPPLY_NURSE, T2.THIRD_SUPPLY_NURSE, T2.FOURTH_SUPPLY_NURSE, T2.PACU_DOCTOR, T2.FIRST_PACU_ASSISTANT, T2.SECOND_PACU_ASSISTANT, T2.FIRST_PACU_NURSE, T2.SECOND_PACU_NURSE, T2.REQ_DATE_TIME, T2.SCHEDULED_DATE_TIME, T2.OPER_POSITION, T2.BED_NO, T2.OPERATION_NAME, T2.HIS_PATIENT_ID, T2.HIS_VISIT_ID, T2.HIS_SCHEDULE_ID, T2.HIS_OPER_STATUS, T2.RESERVED1, T2.RESERVED2, T2.RESERVED3           
                                                                        from MED_OPERATION_SCHEDULE T2
                                                                       WHERE T1.PATIENT_ID = T2.PATIENT_ID AND T1.VISIT_ID = T2.VISIT_ID AND T1.OPER_ID = T2.SCHEDULE_ID
                                                                       AND (T1.OPER_STATUS_CODE = '0' OR T1.OPER_STATUS_CODE IS NULL) and  T2.patient_id =:patientId and T2.visit_id =:visitId and t2.schedule_id =:scheduleId)
                                                                        where exists (select 1 from med_operation_schedule T2 where T2.patient_id = T1.patient_id 
                                                                        and T2.visit_id = T1.visit_id and T2.schedule_id = T1.oper_id) and T1.patient_id =:patientId2 and T1.visit_id =:visitId2 and T1.oper_id=:operId and (T1.OPER_STATUS_CODE = '0' OR T1.OPER_STATUS_CODE IS NULL) ";

        private static readonly string Update_Med_Operation_Master_SQL = @"UPDATE MED_OPERATION_MASTER
                                                                        SET MED_OPERATION_MASTER.PATIENT_ID = T2.PATIENT_ID,
                                                                        MED_OPERATION_MASTER.VISIT_ID = T2.VISIT_ID,
                                                                        MED_OPERATION_MASTER.OPER_ID = T2.SCHEDULE_ID,
                                                                        MED_OPERATION_MASTER.HOSP_BRANCH=T2.HOSP_BRANCH
                                                                       ,MED_OPERATION_MASTER.WARD_CODE=T2.WARD_CODE
                                                                       ,MED_OPERATION_MASTER.DEPT_CODE=T2.DEPT_CODE
                                                                       ,MED_OPERATION_MASTER.OPER_ROOM=T2. OPER_ROOM
                                                                       ,MED_OPERATION_MASTER.OPER_ROOM_NO=T2.OPER_ROOM_NO
                                                                       ,MED_OPERATION_MASTER.SEQUENCE=T2.SEQUENCE
                                                                       ,MED_OPERATION_MASTER.OPER_CLASS=T2.OPER_CLASS
                                                                       ,MED_OPERATION_MASTER.DIAG_BEFORE_OPERATION=T2.DIAG_BEFORE_OPERATION
                                                                       ,MED_OPERATION_MASTER.PATIENT_CONDITION=T2.PATIENT_CONDITION
                                                                       ,MED_OPERATION_MASTER.OPER_SCALE=T2.OPER_SCALE
                                                                       ,MED_OPERATION_MASTER.WOUND_TYPE=T2.WOUND_TYPE
                                                                     
                                                                       ,MED_OPERATION_MASTER.ASA_GRADE=T2.ASA_GRADE
                                                                        
                                                                       ,MED_OPERATION_MASTER.EMERGENCY_IND=T2.EMERGENCY_IND
                                                                       ,MED_OPERATION_MASTER.OPER_SOURCE=T2.OPER_SOURCE
                                                                       ,MED_OPERATION_MASTER.ISOLATION_IND=T2.ISOLATION_IND
                                                                       ,MED_OPERATION_MASTER.INFECTED_IND=T2.INFECTED_IND
                                                                       ,MED_OPERATION_MASTER.RADIATE_IND=T2.RADIATE_IND
                                                                       ,MED_OPERATION_MASTER.SURGEON=T2.SURGEON
                                                                       ,MED_OPERATION_MASTER.FIRST_OPER_ASSISTANT=T2.FIRST_OPER_ASSISTANT
                                                                       ,MED_OPERATION_MASTER.SECOND_OPER_ASSISTANT=T2.SECOND_OPER_ASSISTANT
                                                                       ,MED_OPERATION_MASTER.THIRD_OPER_ASSISTANT=T2.THIRD_OPER_ASSISTANT
                                                                       ,MED_OPERATION_MASTER.FOURTH_OPER_ASSISTANT=T2.FOURTH_OPER_ASSISTANT
                                                                       ,MED_OPERATION_MASTER.ANES_METHOD=T2.ANES_METHOD
                                                                       ,MED_OPERATION_MASTER.ANES_DOCTOR=T2.ANES_DOCTOR
                                                                       ,MED_OPERATION_MASTER.FIRST_ANES_ASSISTANT=T2.FIRST_ANES_ASSISTANT
                                                                       ,MED_OPERATION_MASTER.SECOND_ANES_ASSISTANT=T2.SECOND_ANES_ASSISTANT
                                                                       ,MED_OPERATION_MASTER.THIRD_ANES_ASSISTANT=T2.THIRD_ANES_ASSISTANT
                                                                       ,MED_OPERATION_MASTER.FOURTH_ANES_ASSISTANT=T2.FOURTH_ANES_ASSISTANT
                                                                       ,MED_OPERATION_MASTER.FIRST_ANES_NURSE=T2.FIRST_ANES_NURSE
                                                                       ,MED_OPERATION_MASTER.SECOND_ANES_NURSE=T2.SECOND_ANES_NURSE
                                                                       ,MED_OPERATION_MASTER.THIRD_ANES_NURSE=T2.THIRD_ANES_NURSE
                                                                       ,MED_OPERATION_MASTER.CPB_DOCTOR=T2.CPB_DOCTOR
                                                                       ,MED_OPERATION_MASTER.FIRST_CPB_ASSISTANT=T2.FIRST_CPB_ASSISTANT
                                                                       ,MED_OPERATION_MASTER.SECOND_CPB_ASSISTANT=T2.SECOND_CPB_ASSISTANT
                                                                       ,MED_OPERATION_MASTER.THIRD_CPB_ASSISTANT=T2.THIRD_CPB_ASSISTANT
                                                                       ,MED_OPERATION_MASTER.FOURTH_CPB_ASSISTANT=T2.FOURTH_CPB_ASSISTANT
                                                                       ,MED_OPERATION_MASTER.FIRST_OPER_NURSE=T2.FIRST_OPER_NURSE
                                                                       ,MED_OPERATION_MASTER.SECOND_OPER_NURSE=T2.SECOND_OPER_NURSE
                                                                       ,MED_OPERATION_MASTER.THIRD_OPER_NURSE=T2.THIRD_OPER_NURSE
                                                                       ,MED_OPERATION_MASTER.FOURTH_OPER_NURSE=T2.FOURTH_OPER_NURSE
                                                                       ,MED_OPERATION_MASTER.FIRST_SUPPLY_NURSE=T2.FIRST_SUPPLY_NURSE
                                                                       ,MED_OPERATION_MASTER.SECOND_SUPPLY_NURSE=T2.SECOND_SUPPLY_NURSE
                                                                       ,MED_OPERATION_MASTER.THIRD_SUPPLY_NURSE=T2.THIRD_SUPPLY_NURSE
                                                                       ,MED_OPERATION_MASTER.FOURTH_SUPPLY_NURSE=T2.FOURTH_SUPPLY_NURSE
                                                                       ,MED_OPERATION_MASTER.PACU_DOCTOR=T2.PACU_DOCTOR
                                                                       ,MED_OPERATION_MASTER.FIRST_PACU_ASSISTANT=T2.FIRST_PACU_ASSISTANT
                                                                       ,MED_OPERATION_MASTER.SECOND_PACU_ASSISTANT=T2.SECOND_PACU_ASSISTANT
                                                                       ,MED_OPERATION_MASTER.FIRST_PACU_NURSE=T2.FIRST_PACU_NURSE
                                                                       ,MED_OPERATION_MASTER.SECOND_PACU_NURSE=T2.SECOND_PACU_NURSE
                                                                       ,MED_OPERATION_MASTER.REQ_DATE_TIME=T2.REQ_DATE_TIME
                                                                       ,MED_OPERATION_MASTER.SCHEDULED_DATE_TIME=T2.SCHEDULED_DATE_TIME
                                                                       ,MED_OPERATION_MASTER.OPER_POSITION=T2.OPER_POSITION
                                                                       ,MED_OPERATION_MASTER.BED_NO=T2.BED_NO
                                                                       ,MED_OPERATION_MASTER.OPERATION_NAME=T2.OPERATION_NAME
                                                                       ,MED_OPERATION_MASTER.HIS_PATIENT_ID=T2.HIS_PATIENT_ID
                                                                       ,MED_OPERATION_MASTER.HIS_VISIT_ID=T2.HIS_VISIT_ID
                                                                       ,MED_OPERATION_MASTER.HIS_SCHEDULE_ID=T2.HIS_SCHEDULE_ID
                                                                       ,MED_OPERATION_MASTER.HIS_OPER_STATUS=T2.HIS_OPER_STATUS
                                                                       ,MED_OPERATION_MASTER.RESERVED01=T2.RESERVED01
                                                                       ,MED_OPERATION_MASTER.RESERVED02=T2.RESERVED02
                                                                       ,MED_OPERATION_MASTER.RESERVED03=T2.RESERVED03
                                                                        FROM MED_OPERATION_SCHEDULE T2
                                                                        WHERE MED_OPERATION_MASTER.PATIENT_ID =T2.PATIENT_ID AND MED_OPERATION_MASTER.VISIT_ID =T2.VISIT_ID AND MED_OPERATION_MASTER.OPER_ID =T2.SCHEDULE_ID AND MED_OPERATION_MASTER.OPER_STATUS_CODE = '0'  AND T2.PATIENT_ID =@patientId AND T2.VISIT_ID =@visitId AND T2.SCHEDULE_ID =@scheduleId";

        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {

                if (sqlParms == "UpdateMedOperationScheduleOperId")
                {
                    parms = new OracleParameter[]{
                        new OracleParameter(":operId",OracleType.Number), 
                        new OracleParameter(":patientId",OracleType.VarChar),
                        new OracleParameter(":visitId",OracleType.Number),                                 
                        new OracleParameter(":scheduleId",OracleType.Number)
                    };
                }
                else
                {
                    if (sqlParms == "InsertMedOperationMasterAndName")
                    {
                        parms = new OracleParameter[]{
                        new OracleParameter(":patientId",OracleType.VarChar),
                        new OracleParameter(":visitId",OracleType.Number),                                 
                        new OracleParameter(":scheduleId",OracleType.Number)
                        };
                    }
                    else
                    {
                        if (sqlParms == "InsertMedOperationName")
                        {
                            parms = new OracleParameter[]{
                            new OracleParameter(":patientId",OracleType.VarChar),
                            new OracleParameter(":visitId",OracleType.Number),                                 
                            new OracleParameter(":scheduleId",OracleType.Number)
                            };
                        }
                        else
                        {
                            if (sqlParms == "UpdateMedOperationMasterAndName")
                            {
                                parms = new OracleParameter[]{
                                    new OracleParameter(":patientId",OracleType.VarChar),
                                    new OracleParameter(":visitId",OracleType.Number),                                 
                                    new OracleParameter(":scheduleId",OracleType.Number),
                                    new OracleParameter(":patientId2",OracleType.VarChar),
                                    new OracleParameter(":visitId2",OracleType.Number),                                 
                                    new OracleParameter(":operId",OracleType.Number),
                                };
                            }
                        }
                    }

                }


                OracleHelper.CacheParameters(sqlParms, parms);
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
        public int UpdateMedOperationSchedule(string patientId, decimal visitId, decimal scheduledId, decimal operId)
        {
            using (OracleConnection oraConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] updateMedOperationSchedule = GetParameter("UpdateMedOperationScheduleOperId");

                updateMedOperationSchedule[0].Value = operId;
                updateMedOperationSchedule[1].Value = patientId;
                updateMedOperationSchedule[2].Value = visitId;
                updateMedOperationSchedule[3].Value = scheduledId;

                return OracleHelper.ExecuteNonQuery(oraConn, CommandType.Text, Update_Med_Operation_Schedule, updateMedOperationSchedule);
            }

        }
        /// <summary>
        /// 更新MedOperationMaster记录
        /// </summary>
        /// <param name="patientId">The patient id.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <param name="operId">The oper id.</param>
        /// <returns></returns>
        public int UpdateMedOperationMaster(string patientId, decimal visitId, decimal scheduledId)
        {
            using (OracleConnection oraConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] updateMedOperationMaster = GetParameter("UpdateMedOperationMasterAndName");
                updateMedOperationMaster[0].Value = patientId;
                updateMedOperationMaster[1].Value = visitId;
                updateMedOperationMaster[2].Value = scheduledId;
                updateMedOperationMaster[3].Value = patientId;
                updateMedOperationMaster[4].Value = visitId;
                updateMedOperationMaster[5].Value = scheduledId;

                return OracleHelper.ExecuteNonQuery(oraConn, CommandType.Text, Update_Med_Operation_Master, updateMedOperationMaster);
            }

        }
        /// <summary>
        /// Inserts the med operation master.
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <returns></returns>
        public int InsertMedOperationMaster(string patientID, decimal visitId, decimal scheduledId)
        {
            using (OracleConnection oraConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedOperationMasterAndName");

                oneInert[0].Value = patientID;
                oneInert[1].Value = visitId;
                oneInert[2].Value = scheduledId;
                int returnValue;
                using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, Select_Insert_Med_Operation_Master, oneInert))
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
                    return OracleHelper.ExecuteNonQuery(oraConn, CommandType.Text, Insert_Med_Operation_Master, oneInert);
                else
                    return 0;
            }
        }

        /// <summary>
        /// Inserts the med operation master V4.
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <returns></returns>
        public int InsertMedOperationMasterV4(string patientID, decimal visitId, decimal scheduledId)
        {
            using (OracleConnection oraConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedOperationMasterAndName");

                oneInert[0].Value = patientID;
                oneInert[1].Value = visitId;
                oneInert[2].Value = scheduledId;
                int returnValue;
                using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, Select_Insert_Med_Operation_Master, oneInert))
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
                    return OracleHelper.ExecuteNonQuery(oraConn, CommandType.Text, Insert_Med_Operation_Master_V4, oneInert);
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
        public int InsertMedOperationName(string patientID, decimal visitId, decimal scheduledId, decimal operId)
        {
            using (OracleConnection oraConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedOperationName");

                oneInert[0].Value = patientID;
                oneInert[1].Value = visitId;
                oneInert[2].Value = scheduledId;
                int returnValue;
                using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, Select_Insert_Med_Operation_Name, oneInert))
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
                    return OracleHelper.ExecuteNonQuery(oraConn, CommandType.Text, Insert_Med_Operation_Name, oneInert);
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
        public int MedOperationMasterAndOperationName(string patientID, decimal visitId, decimal operId)
        {
            int rtn = 0;

            rtn = UpdateMedOperationSchedule(patientID, visitId, operId, operId);
            if (rtn < 0) return -1;

            rtn = InsertMedOperationMaster(patientID, visitId, operId);
            if (rtn < 0) return -1;

            rtn = InsertMedOperationName(patientID, visitId, operId, operId);
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
        public int MedOperationMasterAndOperationNameV4(string patientID, decimal visitId, decimal operId)
        {
            int rtn = 0;

            rtn = UpdateMedOperationSchedule(patientID, visitId, operId, operId);
            if (rtn < 0) return -1;

            rtn = InsertMedOperationMasterV4(patientID, visitId, operId);
            if (rtn < 0) return -1;

            rtn = InsertMedOperationName(patientID, visitId, operId, operId);
            if (rtn < 0) return -1;

            rtn = UpdateMedOperationMaster(patientID, visitId, operId);
            if (rtn < 0) return -1;
            return 1;
        }

        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {

                if (sqlParms == "UpdateMedOperationScheduleOperId")
                {
                    parms = new SqlParameter[]{
                        new SqlParameter("@operId",SqlDbType.Decimal), 
                        new SqlParameter("@patientId",SqlDbType.VarChar),
                        new SqlParameter("@visitId",SqlDbType.Decimal),                                 
                        new SqlParameter("@scheduleId",SqlDbType.Decimal)
                    };
                }
                else
                {
                    if (sqlParms == "InsertMedOperationMasterAndName")
                    {
                        parms = new SqlParameter[]{
                        new SqlParameter("@patientId",SqlDbType.VarChar),
                        new SqlParameter("@visitId",SqlDbType.Decimal),                                 
                        new SqlParameter("@scheduleId",SqlDbType.Decimal)
                        };
                    }
                    else
                    {
                        if (sqlParms == "InsertMedOperationName")
                        {
                            parms = new SqlParameter[]{
                                new SqlParameter("@patientId",SqlDbType.VarChar),
                                new SqlParameter("@visitId",SqlDbType.Decimal),                                 
                                new SqlParameter("@scheduleId",SqlDbType.Decimal)
                            };
                        }
                        else
                        {
                            if (sqlParms == "UpdateMedOperationMasterAndName")
                            {
                                parms = new SqlParameter[]{
                                    new SqlParameter("@patientId",SqlDbType.VarChar),
                                    new SqlParameter("@visitId",SqlDbType.Decimal),                                 
                                    new SqlParameter("@scheduleId",SqlDbType.Decimal)
                                };
                            }
                        }
                    }
                }


                SqlHelper.CacheParameters(sqlParms, parms);
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
        public int UpdateMedOperationScheduleSQL(string patientId, decimal visitId, decimal scheduledId, decimal operId)
        {
            using (SqlConnection oraConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] updateMedOperationSchedule = GetParameterSQL("UpdateMedOperationScheduleOperId");

                updateMedOperationSchedule[0].Value = operId;
                updateMedOperationSchedule[1].Value = patientId;
                updateMedOperationSchedule[2].Value = visitId;
                updateMedOperationSchedule[3].Value = scheduledId;

                return SqlHelper.ExecuteNonQuery(oraConn, CommandType.Text, Update_Med_Operation_Schedule_SQL, updateMedOperationSchedule);
            }

        }
        /// <summary>
        /// 更新MedOperationMaster记录SQL
        /// </summary>
        /// <param name="patientId">The patient id.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <param name="operId">The oper id.</param>
        /// <returns></returns>
        public int UpdateMedOperationMasterSQL(string patientId, decimal visitId, decimal scheduledId)
        {
            using (SqlConnection oraConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] updateMedOperationMaster = GetParameterSQL("UpdateMedOperationMasterAndName");
                updateMedOperationMaster[0].Value = patientId;
                updateMedOperationMaster[1].Value = visitId;
                updateMedOperationMaster[2].Value = scheduledId;

                return SqlHelper.ExecuteNonQuery(oraConn, CommandType.Text, Update_Med_Operation_Master_SQL, updateMedOperationMaster);
            }

        }
        /// <summary>
        /// Inserts the med operation master.
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <returns></returns>
        public int InsertMedOperationMasterSQL(string patientID, decimal visitId, decimal scheduledId)
        {
            using (SqlConnection oraConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedOperationMasterAndName");

                oneInert[0].Value = patientID;
                oneInert[1].Value = visitId;
                oneInert[2].Value = scheduledId;
                int returnValue;
                using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, Select_Insert_Med_Operation_Master_SQL, oneInert))
                {
                    if (oleReader.Read())
                    {
                        returnValue = Convert.ToInt32(oleReader[0]);
                    }
                    else
                    {
                        returnValue = 0;
                    }
                }
                if (returnValue < 1)
                    return SqlHelper.ExecuteNonQuery(oraConn, CommandType.Text, Insert_Med_Operation_Master_SQL, oneInert);
                else
                    return 0;
            }
        }
        /// <summary>
        /// Inserts the med operation master SQL V4.
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <returns></returns>
        public int InsertMedOperationMasterSQLV4(string patientID, decimal visitId, decimal scheduledId)
        {
            using (SqlConnection oraConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedOperationMasterAndName");

                oneInert[0].Value = patientID;
                oneInert[1].Value = visitId;
                oneInert[2].Value = scheduledId;
                int returnValue;
                using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, Select_Insert_Med_Operation_Master_SQL, oneInert))
                {
                    if (oleReader.Read())
                    {
                        returnValue = Convert.ToInt32(oleReader[0]);
                    }
                    else
                    {
                        returnValue = 0;
                    }
                }
                if (returnValue < 1)
                    return SqlHelper.ExecuteNonQuery(oraConn, CommandType.Text, Insert_Med_Operation_Master_SQL_V4, oneInert);
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
        public int InsertMedOperationNameSQL(string patientID, decimal visitId, decimal scheduledId, decimal operId)
        {
            using (SqlConnection oraConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedOperationName");

                oneInert[0].Value = patientID;
                oneInert[1].Value = visitId;
                oneInert[2].Value = scheduledId;
                int returnValue;
                using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, Select_Insert_Med_Operation_Name_SQL, oneInert))
                {
                    if (oleReader.Read())
                    {
                        returnValue = Convert.ToInt32(oleReader[0]);
                    }
                    else
                    {
                        returnValue = 0;
                    }
                }
                if (returnValue < 1)
                    return SqlHelper.ExecuteNonQuery(oraConn, CommandType.Text, Insert_Med_Operation_Name_SQL, oneInert);
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
        public int MedOperationMasterAndOperationNameSQL(string patientID, decimal visitId, decimal operId)
        {
            int rtn = 0;

            rtn = UpdateMedOperationScheduleSQL(patientID, visitId, operId, operId);
            if (rtn < 0) return -1;

            rtn = InsertMedOperationMasterSQL(patientID, visitId, operId);
            if (rtn < 0) return -1;

            rtn = InsertMedOperationNameSQL(patientID, visitId, operId, operId);
            if (rtn < 0) return -1;

            return 1;
        }
        /// <summary>
        /// 同步的同时写手术主记录信息V4
        /// </summary>
        /// <param name="patientID">The patient ID.</param>
        /// <param name="visitId">The visit id.</param>
        /// <param name="scheduledId">The scheduled id.</param>
        /// <returns></returns>
        public int MedOperationMasterAndOperationNameSQLV4(string patientID, decimal visitId, decimal operId)
        {
            int rtn = 0;

            rtn = UpdateMedOperationScheduleSQL(patientID, visitId, operId, operId);
            if (rtn < 0) return -1;

            rtn = InsertMedOperationMasterSQLV4(patientID, visitId, operId);
            if (rtn < 0) return -1;


            rtn = InsertMedOperationNameSQL(patientID, visitId, operId, operId);
            if (rtn < 0) return -1;

            rtn = UpdateMedOperationMasterSQL(patientID, visitId, operId);
            if (rtn < 0) return -1;
            return 1;
        }
    }
}
