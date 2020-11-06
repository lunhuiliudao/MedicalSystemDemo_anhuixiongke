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
    public partial class DALMedOperationSchedule
    {

        private static string Select_OLE = "select PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME from MED_OPERATION_SCHEDULE WHERE PATIENT_ID=? AND VISIT_ID=? AND SCHEDULE_ID=? ";


        private static string Update_OLE = "Update MED_OPERATION_SCHEDULE set OPER_ID=?,HOSP_BRANCH=?,WARD_CODE=?,DEPT_CODE=?,OPER_DEPT_CODE=?,OPER_ROOM=?,OPER_ROOM_NO=?,SEQUENCE=?,OPER_CLASS=?,DIAG_BEFORE_OPERATION=?,PATIENT_CONDITION=?,OPER_SCALE=?,WOUND_TYPE=?,ASA_GRADE=?,EMERGENCY_IND=?,OPER_SOURCE=?,ISOLATION_IND=?,INFECTED_IND=?,RADIATE_IND=?,SURGEON=?,FIRST_OPER_ASSISTANT=?,SECOND_OPER_ASSISTANT=?,THIRD_OPER_ASSISTANT=?,FOURTH_OPER_ASSISTANT=?,ANES_METHOD=?,ANES_DOCTOR=?,FIRST_ANES_ASSISTANT=?,SECOND_ANES_ASSISTANT=?,THIRD_ANES_ASSISTANT=?,FOURTH_ANES_ASSISTANT=?,FIRST_ANES_NURSE=?,SECOND_ANES_NURSE=?,THIRD_ANES_NURSE=?,CPB_DOCTOR=?,FIRST_CPB_ASSISTANT=?,SECOND_CPB_ASSISTANT=?,THIRD_CPB_ASSISTANT=?,FOURTH_CPB_ASSISTANT=?,FIRST_OPER_NURSE=?,SECOND_OPER_NURSE=?,THIRD_OPER_NURSE=?,FOURTH_OPER_NURSE=?,FIRST_SUPPLY_NURSE=?,SECOND_SUPPLY_NURSE=?,THIRD_SUPPLY_NURSE=?,FOURTH_SUPPLY_NURSE=?,PACU_DOCTOR=?,FIRST_PACU_ASSISTANT=?,SECOND_PACU_ASSISTANT=?,FIRST_PACU_NURSE=?,SECOND_PACU_NURSE=?,REQ_DATE_TIME=?,SCHEDULED_DATE_TIME=?,OPER_POSITION=?,BED_NO=?,OPERATION_NAME=?,SPECIAL_EQUIPMENT=?,SPECIAL_INFECT=?,ANES_CONFIRM=?,NURSE_CONFIRM=?,OPER_STATUS_CODE=?,NOTES_ON_OPERATION=?,OPERATOR=?,HIS_PATIENT_ID=?,HIS_VISIT_ID=?,HIS_SCHEDULE_ID=?,HIS_OPER_STATUS=?,RESERVED1=?,RESERVED2=?,RESERVED3=?,OPERATING_TIME=? where PATIENT_ID=? AND VISIT_ID=? AND SCHEDULE_ID=? ";


        private static string Insert_OLE = "Insert into MED_OPERATION_SCHEDULE  (PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";



        private static readonly string Select_Max_ScheduleId_Med_Operation_Schedule_OLE = "select nvl(max(schedule_id),0) from med_operation_schedule where patient_id = ? and visit_id = ?";
        private static readonly string Select_Count_Med_Operation_Schedule_OLE = "Select count(*) from med_operation_schedule where patient_id = ? and visit_id = ? and schedule_id = ?";
        //新增, SPECIAL_EQUIPMENT,SPECIAL_INFECT 李华东 2013-11-27
        // private static readonly string Select_One_Med_Operation_Schedule_OLE = "select patient_id, visit_id, schedule_id, dept_stayed, bed_no, scheduled_date_time, operating_room, operating_room_no, sequence, diag_before_operation, patient_condition, operation_scale, isolation_indicator, operating_dept, surgeon, first_assistant, second_assistant, third_assistant, fourth_assistant, anesthesia_method, anesthesia_doctor, anesthesia_assistant, blood_tran_doctor, first_operation_nurse, second_operation_nurse, first_supply_nurse, second_supply_nurse, notes_on_operation, entered_by, req_date_time, third_supply_nurse, ack_indicator, emergency_indicator, oper_id, second_anesthesia_assistant, third_anesthesia_assistant, fourth_anesthesia_assistant, second_anesthesia_doctor, third_anesthesia_doctor,operation_position,reserved1, reserved2, reserved3,reserved4, reserved5, reserved6, reserved7, reserved8,STATE, SPECIAL_EQUIPMENT,SPECIAL_INFECT,OPERATION_ID,OPERATION_NAME from med_operation_schedule where patient_id = ? and visit_id = ? and schedule_id = ? ";
        //2013-4-18 孙凯增加
        private static readonly string Select_One_Med_Operation_Schedule_OperId_OLE = "select PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME from med_operation_schedule where patient_id = ? and visit_id = ? and oper_id = ? ";
        private static readonly string Select_Med_Operation_Schedule_OLE = "select PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME from med_operation_schedule where patient_id = ? and visit_id = ? ";
        // private static readonly string Insert_Med_Operation_Schedule_OLE = "insert into med_operation_schedule(patient_id, visit_id, schedule_id, dept_stayed, bed_no, scheduled_date_time, operating_room, operating_room_no, sequence, diag_before_operation, patient_condition, operation_scale, isolation_indicator, operating_dept, surgeon, first_assistant, second_assistant, third_assistant, fourth_assistant, anesthesia_method, anesthesia_doctor, anesthesia_assistant, blood_tran_doctor, first_operation_nurse, second_operation_nurse, first_supply_nurse, second_supply_nurse, notes_on_operation, entered_by, req_date_time, third_supply_nurse, ack_indicator, emergency_indicator, oper_id, second_anesthesia_assistant, third_anesthesia_assistant, fourth_anesthesia_assistant, second_anesthesia_doctor, third_anesthesia_doctor,operation_position,reserved1, reserved2, reserved3,reserved4,reserved5,reserved6, reserved7, reserved8,STATE,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,OPERATION_ID,third_operation_nurse )values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,? ,? ,? ,? ,? ,? ,?, ?, ?,?,?,?,?,? ,?)";
        // private static readonly string Update_Med_Operation_Schedule_OLE = "update med_operation_schedule set  dept_stayed = ?, bed_no = ?, scheduled_date_time = ?, operating_room = ?, operating_room_no = ?, sequence = ?, diag_before_operation = ?,patient_condition = ?, operation_scale = ?, isolation_indicator = ?, operating_dept = ?, surgeon = ?, first_assistant = ?, second_assistant = ?, third_assistant = ?, fourth_assistant = ?, anesthesia_method = ?, anesthesia_doctor = ?, anesthesia_assistant = ?, blood_tran_doctor = ?, first_operation_nurse = ?, second_operation_nurse = ?, first_supply_nurse = ?, second_supply_nurse = ?, notes_on_operation = ?,  entered_by = ?, req_date_time = ?, third_supply_nurse = ?, ack_indicator = ?, emergency_indicator = ?, oper_id = ?, second_anesthesia_assistant = ?, third_anesthesia_assistant = ?, fourth_anesthesia_assistant = ?, second_anesthesia_doctor = ?, third_anesthesia_doctor = ?,operation_position = ?,reserved1 = ?, reserved2 = ? , reserved3 = ? , reserved4 = ?, reserved5 = ?, reserved6 = ?, reserved7 = ?, reserved8 = ?,state=?,operation_name=?,SPECIAL_EQUIPMENT=?,SPECIAL_INFECT=?,OPERATION_ID=?,third_operation_nurse=? where patient_id = ? and visit_id = ? and schedule_id = ? ";
        private static readonly string Delete_MedOperationSchedule_OLE = "delete med_operation_schedule where patient_id = ? and visit_id = ? and schedule_id = ? ";

        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectOneMedOperationSchedule" || sqlParms == "SelectCountMedOperationSchedule" || sqlParms == "DeleteMedOperationSchedule")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("scheduleId",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "SelectPatMedOperationSchedule" || sqlParms == "SelectMaxScheduleIdMedOperationSchedule")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "SelectOnePatMedOperationScheduleOperId")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("operId",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "InsertMedOperationSchedule")
                {
                    parms = new OleDbParameter[]{
                      new OleDbParameter("PatientId",OleDbType.VarChar),
                        new OleDbParameter("VisitId",OleDbType.Decimal),
                        new OleDbParameter("ScheduleId",OleDbType.Decimal),
                        new OleDbParameter("OperId",OleDbType.Decimal),
                        new OleDbParameter("HospBranch",OleDbType.VarChar),
                        new OleDbParameter("WardCode",OleDbType.VarChar),
                        new OleDbParameter("DeptCode",OleDbType.VarChar),
                        new OleDbParameter("OperDeptCode",OleDbType.VarChar),
                        new OleDbParameter("OperRoom",OleDbType.VarChar),
                        new OleDbParameter("OperRoomNo",OleDbType.VarChar),
                        new OleDbParameter("Sequence",OleDbType.Decimal),
                        new OleDbParameter("OperClass",OleDbType.VarChar),
                        new OleDbParameter("DiagBeforeOperation",OleDbType.VarChar),
                        new OleDbParameter("PatientCondition",OleDbType.VarChar),
                        new OleDbParameter("OperScale",OleDbType.VarChar),
                        new OleDbParameter("WoundType",OleDbType.VarChar),
                        new OleDbParameter("AsaGrade",OleDbType.VarChar),
                        new OleDbParameter("EmergencyInd",OleDbType.Decimal),
                        new OleDbParameter("OperSource",OleDbType.Decimal),
                        new OleDbParameter("IsolationInd",OleDbType.Decimal),
                        new OleDbParameter("InfectedInd",OleDbType.Decimal),
                        new OleDbParameter("RadiateInd",OleDbType.Decimal),
                        new OleDbParameter("Surgeon",OleDbType.VarChar),
                        new OleDbParameter("FirstOperAssistant",OleDbType.VarChar),
                        new OleDbParameter("SecondOperAssistant",OleDbType.VarChar),
                        new OleDbParameter("ThirdOperAssistant",OleDbType.VarChar),
                        new OleDbParameter("FourthOperAssistant",OleDbType.VarChar),
                        new OleDbParameter("AnesMethod",OleDbType.VarChar),
                        new OleDbParameter("AnesDoctor",OleDbType.VarChar),
                        new OleDbParameter("FirstAnesAssistant",OleDbType.VarChar),
                        new OleDbParameter("SecondAnesAssistant",OleDbType.VarChar),
                        new OleDbParameter("ThirdAnesAssistant",OleDbType.VarChar),
                        new OleDbParameter("FourthAnesAssistant",OleDbType.VarChar),
                        new OleDbParameter("FirstAnesNurse",OleDbType.VarChar),
                        new OleDbParameter("SecondAnesNurse",OleDbType.VarChar),
                        new OleDbParameter("ThirdAnesNurse",OleDbType.VarChar),
                        new OleDbParameter("CpbDoctor",OleDbType.VarChar),
                        new OleDbParameter("FirstCpbAssistant",OleDbType.VarChar),
                        new OleDbParameter("SecondCpbAssistant",OleDbType.VarChar),
                        new OleDbParameter("ThirdCpbAssistant",OleDbType.VarChar),
                        new OleDbParameter("FourthCpbAssistant",OleDbType.VarChar),
                        new OleDbParameter("FirstOperNurse",OleDbType.VarChar),
                        new OleDbParameter("SecondOperNurse",OleDbType.VarChar),
                        new OleDbParameter("ThirdOperNurse",OleDbType.VarChar),
                        new OleDbParameter("FourthOperNurse",OleDbType.VarChar),
                        new OleDbParameter("FirstSupplyNurse",OleDbType.VarChar),
                        new OleDbParameter("SecondSupplyNurse",OleDbType.VarChar),
                        new OleDbParameter("ThirdSupplyNurse",OleDbType.VarChar),
                        new OleDbParameter("FourthSupplyNurse",OleDbType.VarChar),
                        new OleDbParameter("PacuDoctor",OleDbType.VarChar),
                        new OleDbParameter("FirstPacuAssistant",OleDbType.VarChar),
                        new OleDbParameter("SecondPacuAssistant",OleDbType.VarChar),
                        new OleDbParameter("FirstPacuNurse",OleDbType.VarChar),
                        new OleDbParameter("SecondPacuNurse",OleDbType.VarChar),
                        new OleDbParameter("ReqDateTime",OleDbType.DBTimeStamp),
                        new OleDbParameter("ScheduledDateTime",OleDbType.DBTimeStamp),
                        new OleDbParameter("OperPosition",OleDbType.VarChar),
                        new OleDbParameter("BedNo",OleDbType.VarChar),
                        new OleDbParameter("OperationName",OleDbType.VarChar),
                        new OleDbParameter("SpecialEquipment",OleDbType.VarChar),
                        new OleDbParameter("SpecialInfect",OleDbType.VarChar),
                        new OleDbParameter("AnesConfirm",OleDbType.VarChar),
                        new OleDbParameter("NurseConfirm",OleDbType.VarChar),
                        new OleDbParameter("OperStatusCode",OleDbType.VarChar),
                        new OleDbParameter("NotesOnOperation",OleDbType.VarChar),
                        new OleDbParameter("Operator",OleDbType.VarChar),
                        new OleDbParameter("HisPatientId",OleDbType.VarChar),
                        new OleDbParameter("HisVisitId",OleDbType.VarChar),
                        new OleDbParameter("HisScheduleId",OleDbType.VarChar),
                        new OleDbParameter("HisOperStatus",OleDbType.VarChar),
                        new OleDbParameter("Reserved1",OleDbType.VarChar),
                        new OleDbParameter("Reserved2",OleDbType.VarChar),
                        new OleDbParameter("Reserved3",OleDbType.VarChar),
                        new OleDbParameter("OperatingTime",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "UpdateMedOperationSchedule")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("OperId",OleDbType.Decimal),
                        new OleDbParameter("HospBranch",OleDbType.VarChar),
                        new OleDbParameter("WardCode",OleDbType.VarChar),
                        new OleDbParameter("DeptCode",OleDbType.VarChar),
                        new OleDbParameter("OperDeptCode",OleDbType.VarChar),
                        new OleDbParameter("OperRoom",OleDbType.VarChar),
                        new OleDbParameter("OperRoomNo",OleDbType.VarChar),
                        new OleDbParameter("Sequence",OleDbType.Decimal),
                        new OleDbParameter("OperClass",OleDbType.VarChar),
                        new OleDbParameter("DiagBeforeOperation",OleDbType.VarChar),
                        new OleDbParameter("PatientCondition",OleDbType.VarChar),
                        new OleDbParameter("OperScale",OleDbType.VarChar),
                        new OleDbParameter("WoundType",OleDbType.VarChar),
                        new OleDbParameter("AsaGrade",OleDbType.VarChar),
                        new OleDbParameter("EmergencyInd",OleDbType.Decimal),
                        new OleDbParameter("OperSource",OleDbType.Decimal),
                        new OleDbParameter("IsolationInd",OleDbType.Decimal),
                        new OleDbParameter("InfectedInd",OleDbType.Decimal),
                        new OleDbParameter("RadiateInd",OleDbType.Decimal),
                        new OleDbParameter("Surgeon",OleDbType.VarChar),
                        new OleDbParameter("FirstOperAssistant",OleDbType.VarChar),
                        new OleDbParameter("SecondOperAssistant",OleDbType.VarChar),
                        new OleDbParameter("ThirdOperAssistant",OleDbType.VarChar),
                        new OleDbParameter("FourthOperAssistant",OleDbType.VarChar),
                        new OleDbParameter("AnesMethod",OleDbType.VarChar),
                        new OleDbParameter("AnesDoctor",OleDbType.VarChar),
                        new OleDbParameter("FirstAnesAssistant",OleDbType.VarChar),
                        new OleDbParameter("SecondAnesAssistant",OleDbType.VarChar),
                        new OleDbParameter("ThirdAnesAssistant",OleDbType.VarChar),
                        new OleDbParameter("FourthAnesAssistant",OleDbType.VarChar),
                        new OleDbParameter("FirstAnesNurse",OleDbType.VarChar),
                        new OleDbParameter("SecondAnesNurse",OleDbType.VarChar),
                        new OleDbParameter("ThirdAnesNurse",OleDbType.VarChar),
                        new OleDbParameter("CpbDoctor",OleDbType.VarChar),
                        new OleDbParameter("FirstCpbAssistant",OleDbType.VarChar),
                        new OleDbParameter("SecondCpbAssistant",OleDbType.VarChar),
                        new OleDbParameter("ThirdCpbAssistant",OleDbType.VarChar),
                        new OleDbParameter("FourthCpbAssistant",OleDbType.VarChar),
                        new OleDbParameter("FirstOperNurse",OleDbType.VarChar),
                        new OleDbParameter("SecondOperNurse",OleDbType.VarChar),
                        new OleDbParameter("ThirdOperNurse",OleDbType.VarChar),
                        new OleDbParameter("FourthOperNurse",OleDbType.VarChar),
                        new OleDbParameter("FirstSupplyNurse",OleDbType.VarChar),
                        new OleDbParameter("SecondSupplyNurse",OleDbType.VarChar),
                        new OleDbParameter("ThirdSupplyNurse",OleDbType.VarChar),
                        new OleDbParameter("FourthSupplyNurse",OleDbType.VarChar),
                        new OleDbParameter("PacuDoctor",OleDbType.VarChar),
                        new OleDbParameter("FirstPacuAssistant",OleDbType.VarChar),
                        new OleDbParameter("SecondPacuAssistant",OleDbType.VarChar),
                        new OleDbParameter("FirstPacuNurse",OleDbType.VarChar),
                        new OleDbParameter("SecondPacuNurse",OleDbType.VarChar),
                        new OleDbParameter("ReqDateTime",OleDbType.DBTimeStamp),
                        new OleDbParameter("ScheduledDateTime",OleDbType.DBTimeStamp),
                        new OleDbParameter("OperPosition",OleDbType.VarChar),
                        new OleDbParameter("BedNo",OleDbType.VarChar),
                        new OleDbParameter("OperationName",OleDbType.VarChar),
                        new OleDbParameter("SpecialEquipment",OleDbType.VarChar),
                        new OleDbParameter("SpecialInfect",OleDbType.VarChar),
                        new OleDbParameter("AnesConfirm",OleDbType.VarChar),
                        new OleDbParameter("NurseConfirm",OleDbType.VarChar),
                        new OleDbParameter("OperStatusCode",OleDbType.VarChar),
                        new OleDbParameter("NotesOnOperation",OleDbType.VarChar),
                        new OleDbParameter("Operator",OleDbType.VarChar),
                        new OleDbParameter("HisPatientId",OleDbType.VarChar),
                        new OleDbParameter("HisVisitId",OleDbType.VarChar),
                        new OleDbParameter("HisScheduleId",OleDbType.VarChar),
                        new OleDbParameter("HisOperStatus",OleDbType.VarChar),
                        new OleDbParameter("Reserved1",OleDbType.VarChar),
                        new OleDbParameter("Reserved2",OleDbType.VarChar),
                        new OleDbParameter("Reserved3",OleDbType.VarChar),
                        new OleDbParameter("OperatingTime",OleDbType.Decimal),
                        new OleDbParameter("PatientId",OleDbType.VarChar),
                        new OleDbParameter("VisitId",OleDbType.Decimal),
                        new OleDbParameter("ScheduleId",OleDbType.Decimal),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public int SelectMaxScheduleIdOLE(string patientId, decimal visitId)
        {
            OleDbParameter[] medMaxScheduleId = GetParameterOLE("SelectMaxScheduleIdMedOperationSchedule");
            medMaxScheduleId[0].Value = patientId;
            medMaxScheduleId[1].Value = visitId;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_Max_ScheduleId_Med_Operation_Schedule_OLE, medMaxScheduleId))
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

        public int SelectCountMedOperationScheduleOLE(string patientId, decimal visitId, decimal scheduleId)
        {
            OleDbParameter[] countMedOperationSchedule = GetParameterOLE("SelectCountMedOperationSchedule");
            countMedOperationSchedule[0].Value = patientId;
            countMedOperationSchedule[1].Value = visitId;
            countMedOperationSchedule[2].Value = scheduleId;

            object count = OleDbHelper.ExecuteScalar(OleDbHelper.ConnectionString, CommandType.Text, Select_Count_Med_Operation_Schedule_OLE, countMedOperationSchedule);
            if (count == null)
                count = (object)0;
            return Convert.ToInt32(count);
        }

        public Model.MedOperationSchedule SelectMedOperationScheduleOLE(string patientId, decimal visitId, decimal scheduleId)
        {
            Model.MedOperationSchedule model = null;

            OleDbParameter[] medOperationScheduleParams = GetParameterOLE("SelectOneMedOperationSchedule");
            medOperationScheduleParams[0].Value = patientId;
            medOperationScheduleParams[1].Value = visitId;
            medOperationScheduleParams[2].Value = scheduleId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_OLE , medOperationScheduleParams))
            {
                if (oleReader.Read())
                {
                    model = new Model.MedOperationSchedule();
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.OperDeptCode = oleReader["OPER_DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.OperRoom = oleReader["OPER_ROOM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.OperRoomNo = oleReader["OPER_ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Sequence = decimal.Parse(oleReader["SEQUENCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.OperClass = oleReader["OPER_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.DiagBeforeOperation = oleReader["DIAG_BEFORE_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.AsaGrade = oleReader["ASA_GRADE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.EmergencyInd = decimal.Parse(oleReader["EMERGENCY_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.OperSource = decimal.Parse(oleReader["OPER_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.IsolationInd = decimal.Parse(oleReader["ISOLATION_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.InfectedInd = decimal.Parse(oleReader["INFECTED_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.RadiateInd = decimal.Parse(oleReader["RADIATE_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Surgeon = oleReader["SURGEON"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.FirstOperAssistant = oleReader["FIRST_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.SecondOperAssistant = oleReader["SECOND_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.ThirdOperAssistant = oleReader["THIRD_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.FourthOperAssistant = oleReader["FOURTH_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.AnesMethod = oleReader["ANES_METHOD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.AnesDoctor = oleReader["ANES_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.FirstAnesAssistant = oleReader["FIRST_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.SecondAnesAssistant = oleReader["SECOND_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.ThirdAnesAssistant = oleReader["THIRD_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.FourthAnesAssistant = oleReader["FOURTH_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.FirstAnesNurse = oleReader["FIRST_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.SecondAnesNurse = oleReader["SECOND_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.ThirdAnesNurse = oleReader["THIRD_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.CpbDoctor = oleReader["CPB_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.FirstCpbAssistant = oleReader["FIRST_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.SecondCpbAssistant = oleReader["SECOND_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.ThirdCpbAssistant = oleReader["THIRD_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.FourthCpbAssistant = oleReader["FOURTH_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.FirstOperNurse = oleReader["FIRST_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(42))
                    {
                        model.SecondOperNurse = oleReader["SECOND_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(43))
                    {
                        model.ThirdOperNurse = oleReader["THIRD_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(44))
                    {
                        model.FourthOperNurse = oleReader["FOURTH_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(45))
                    {
                        model.FirstSupplyNurse = oleReader["FIRST_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(46))
                    {
                        model.SecondSupplyNurse = oleReader["SECOND_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(47))
                    {
                        model.ThirdSupplyNurse = oleReader["THIRD_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(48))
                    {
                        model.FourthSupplyNurse = oleReader["FOURTH_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(49))
                    {
                        model.PacuDoctor = oleReader["PACU_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(50))
                    {
                        model.FirstPacuAssistant = oleReader["FIRST_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(51))
                    {
                        model.SecondPacuAssistant = oleReader["SECOND_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(52))
                    {
                        model.FirstPacuNurse = oleReader["FIRST_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(53))
                    {
                        model.SecondPacuNurse = oleReader["SECOND_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(54))
                    {
                        model.ReqDateTime = DateTime.Parse(oleReader["REQ_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(55))
                    {
                        model.ScheduledDateTime = DateTime.Parse(oleReader["SCHEDULED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(56))
                    {
                        model.OperPosition = oleReader["OPER_POSITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(57))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(58))
                    {
                        model.OperationName = oleReader["OPERATION_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(59))
                    {
                        model.SpecialEquipment = oleReader["SPECIAL_EQUIPMENT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(60))
                    {
                        model.SpecialInfect = oleReader["SPECIAL_INFECT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(61))
                    {
                        model.AnesConfirm = oleReader["ANES_CONFIRM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(62))
                    {
                        model.NurseConfirm = oleReader["NURSE_CONFIRM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(63))
                    {
                        model.OperStatusCode = oleReader["OPER_STATUS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(64))
                    {
                        model.NotesOnOperation = oleReader["NOTES_ON_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(65))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(66))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(67))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(68))
                    {
                        model.HisScheduleId = oleReader["HIS_SCHEDULE_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(69))
                    {
                        model.HisOperStatus = oleReader["HIS_OPER_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(70))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(71))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(72))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(73))
                    {
                        model.OperatingTime = decimal.Parse(oleReader["OPERATING_TIME"].ToString().Trim());
                    }
                }
                else
                    model = null;
            }
            return model;
        }           

        public Model.MedOperationSchedule SelectMedOperationScheduleWithOperIdOLE(string patientId, decimal visitId, decimal operId)
        {
            Model.MedOperationSchedule model = null;

            OleDbParameter[] medOperationScheduleParams = GetParameterOLE("SelectOnePatMedOperationScheduleOperId");
            medOperationScheduleParams[0].Value = patientId;
            medOperationScheduleParams[1].Value = visitId;
            medOperationScheduleParams[2].Value = operId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_One_Med_Operation_Schedule_OperId_OLE, medOperationScheduleParams))
            {
                if (oleReader.Read())
                {
                    model = new MedicalSytem.Soft.Model.MedOperationSchedule();
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.OperDeptCode = oleReader["OPER_DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.OperRoom = oleReader["OPER_ROOM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.OperRoomNo = oleReader["OPER_ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Sequence = decimal.Parse(oleReader["SEQUENCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.OperClass = oleReader["OPER_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.DiagBeforeOperation = oleReader["DIAG_BEFORE_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.AsaGrade = oleReader["ASA_GRADE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.EmergencyInd = decimal.Parse(oleReader["EMERGENCY_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.OperSource = decimal.Parse(oleReader["OPER_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.IsolationInd = decimal.Parse(oleReader["ISOLATION_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.InfectedInd = decimal.Parse(oleReader["INFECTED_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.RadiateInd = decimal.Parse(oleReader["RADIATE_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Surgeon = oleReader["SURGEON"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.FirstOperAssistant = oleReader["FIRST_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.SecondOperAssistant = oleReader["SECOND_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.ThirdOperAssistant = oleReader["THIRD_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.FourthOperAssistant = oleReader["FOURTH_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.AnesMethod = oleReader["ANES_METHOD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.AnesDoctor = oleReader["ANES_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.FirstAnesAssistant = oleReader["FIRST_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.SecondAnesAssistant = oleReader["SECOND_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.ThirdAnesAssistant = oleReader["THIRD_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.FourthAnesAssistant = oleReader["FOURTH_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.FirstAnesNurse = oleReader["FIRST_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.SecondAnesNurse = oleReader["SECOND_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.ThirdAnesNurse = oleReader["THIRD_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.CpbDoctor = oleReader["CPB_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.FirstCpbAssistant = oleReader["FIRST_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.SecondCpbAssistant = oleReader["SECOND_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.ThirdCpbAssistant = oleReader["THIRD_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.FourthCpbAssistant = oleReader["FOURTH_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.FirstOperNurse = oleReader["FIRST_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(42))
                    {
                        model.SecondOperNurse = oleReader["SECOND_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(43))
                    {
                        model.ThirdOperNurse = oleReader["THIRD_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(44))
                    {
                        model.FourthOperNurse = oleReader["FOURTH_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(45))
                    {
                        model.FirstSupplyNurse = oleReader["FIRST_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(46))
                    {
                        model.SecondSupplyNurse = oleReader["SECOND_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(47))
                    {
                        model.ThirdSupplyNurse = oleReader["THIRD_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(48))
                    {
                        model.FourthSupplyNurse = oleReader["FOURTH_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(49))
                    {
                        model.PacuDoctor = oleReader["PACU_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(50))
                    {
                        model.FirstPacuAssistant = oleReader["FIRST_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(51))
                    {
                        model.SecondPacuAssistant = oleReader["SECOND_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(52))
                    {
                        model.FirstPacuNurse = oleReader["FIRST_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(53))
                    {
                        model.SecondPacuNurse = oleReader["SECOND_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(54))
                    {
                        model.ReqDateTime = DateTime.Parse(oleReader["REQ_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(55))
                    {
                        model.ScheduledDateTime = DateTime.Parse(oleReader["SCHEDULED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(56))
                    {
                        model.OperPosition = oleReader["OPER_POSITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(57))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(58))
                    {
                        model.OperationName = oleReader["OPERATION_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(59))
                    {
                        model.SpecialEquipment = oleReader["SPECIAL_EQUIPMENT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(60))
                    {
                        model.SpecialInfect = oleReader["SPECIAL_INFECT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(61))
                    {
                        model.AnesConfirm = oleReader["ANES_CONFIRM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(62))
                    {
                        model.NurseConfirm = oleReader["NURSE_CONFIRM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(63))
                    {
                        model.OperStatusCode = oleReader["OPER_STATUS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(64))
                    {
                        model.NotesOnOperation = oleReader["NOTES_ON_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(65))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(66))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(67))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(68))
                    {
                        model.HisScheduleId = oleReader["HIS_SCHEDULE_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(69))
                    {
                        model.HisOperStatus = oleReader["HIS_OPER_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(70))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(71))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(72))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(73))
                    {
                        model.OperatingTime = decimal.Parse(oleReader["OPERATING_TIME"].ToString().Trim());
                    }
                }
                else
                    model = null;
            }
            return model;
        }

        public List<Model.MedOperationSchedule> SelectMedOperationScheduleOLE(string patientId, decimal visitId)
        {
            List<Model.MedOperationSchedule> MedOperationScheduleList = new List<Model.MedOperationSchedule>();

            OleDbParameter[] OperationSchedule = GetParameterOLE("SelectPatMedOperationSchedule");
            OperationSchedule[0].Value = patientId;
            OperationSchedule[1].Value = visitId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_Med_Operation_Schedule_OLE, OperationSchedule))
            {
                while (oleReader.Read())
                {
                    Model.MedOperationSchedule model = new Model.MedOperationSchedule();
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.OperDeptCode = oleReader["OPER_DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.OperRoom = oleReader["OPER_ROOM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.OperRoomNo = oleReader["OPER_ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Sequence = decimal.Parse(oleReader["SEQUENCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.OperClass = oleReader["OPER_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.DiagBeforeOperation = oleReader["DIAG_BEFORE_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.AsaGrade = oleReader["ASA_GRADE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.EmergencyInd = decimal.Parse(oleReader["EMERGENCY_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.OperSource = decimal.Parse(oleReader["OPER_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.IsolationInd = decimal.Parse(oleReader["ISOLATION_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.InfectedInd = decimal.Parse(oleReader["INFECTED_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.RadiateInd = decimal.Parse(oleReader["RADIATE_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Surgeon = oleReader["SURGEON"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.FirstOperAssistant = oleReader["FIRST_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.SecondOperAssistant = oleReader["SECOND_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.ThirdOperAssistant = oleReader["THIRD_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.FourthOperAssistant = oleReader["FOURTH_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.AnesMethod = oleReader["ANES_METHOD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.AnesDoctor = oleReader["ANES_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.FirstAnesAssistant = oleReader["FIRST_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.SecondAnesAssistant = oleReader["SECOND_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.ThirdAnesAssistant = oleReader["THIRD_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.FourthAnesAssistant = oleReader["FOURTH_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.FirstAnesNurse = oleReader["FIRST_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.SecondAnesNurse = oleReader["SECOND_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.ThirdAnesNurse = oleReader["THIRD_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.CpbDoctor = oleReader["CPB_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.FirstCpbAssistant = oleReader["FIRST_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.SecondCpbAssistant = oleReader["SECOND_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.ThirdCpbAssistant = oleReader["THIRD_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.FourthCpbAssistant = oleReader["FOURTH_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.FirstOperNurse = oleReader["FIRST_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(42))
                    {
                        model.SecondOperNurse = oleReader["SECOND_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(43))
                    {
                        model.ThirdOperNurse = oleReader["THIRD_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(44))
                    {
                        model.FourthOperNurse = oleReader["FOURTH_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(45))
                    {
                        model.FirstSupplyNurse = oleReader["FIRST_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(46))
                    {
                        model.SecondSupplyNurse = oleReader["SECOND_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(47))
                    {
                        model.ThirdSupplyNurse = oleReader["THIRD_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(48))
                    {
                        model.FourthSupplyNurse = oleReader["FOURTH_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(49))
                    {
                        model.PacuDoctor = oleReader["PACU_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(50))
                    {
                        model.FirstPacuAssistant = oleReader["FIRST_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(51))
                    {
                        model.SecondPacuAssistant = oleReader["SECOND_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(52))
                    {
                        model.FirstPacuNurse = oleReader["FIRST_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(53))
                    {
                        model.SecondPacuNurse = oleReader["SECOND_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(54))
                    {
                        model.ReqDateTime = DateTime.Parse(oleReader["REQ_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(55))
                    {
                        model.ScheduledDateTime = DateTime.Parse(oleReader["SCHEDULED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(56))
                    {
                        model.OperPosition = oleReader["OPER_POSITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(57))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(58))
                    {
                        model.OperationName = oleReader["OPERATION_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(59))
                    {
                        model.SpecialEquipment = oleReader["SPECIAL_EQUIPMENT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(60))
                    {
                        model.SpecialInfect = oleReader["SPECIAL_INFECT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(61))
                    {
                        model.AnesConfirm = oleReader["ANES_CONFIRM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(62))
                    {
                        model.NurseConfirm = oleReader["NURSE_CONFIRM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(63))
                    {
                        model.OperStatusCode = oleReader["OPER_STATUS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(64))
                    {
                        model.NotesOnOperation = oleReader["NOTES_ON_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(65))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(66))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(67))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(68))
                    {
                        model.HisScheduleId = oleReader["HIS_SCHEDULE_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(69))
                    {
                        model.HisOperStatus = oleReader["HIS_OPER_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(70))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(71))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(72))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(73))
                    {
                        model.OperatingTime = decimal.Parse(oleReader["OPERATING_TIME"].ToString().Trim());
                    }

                    MedOperationScheduleList.Add(model);
                }
            }
            return MedOperationScheduleList;
        }

        public int InsertMedOperationScheduleOLE(Model.MedOperationSchedule model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedOperationSchedule");
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
                if (model.OperId != null)
                    oneInert[3].Value = model.OperId;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.HospBranch != null)
                    oneInert[4].Value = model.HospBranch;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneInert[5].Value = model.WardCode;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneInert[6].Value = model.DeptCode;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.OperDeptCode != null)
                    oneInert[7].Value = model.OperDeptCode;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.OperRoom != null)
                    oneInert[8].Value = model.OperRoom;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.OperRoomNo != null)
                    oneInert[9].Value = model.OperRoomNo;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.Sequence != null)
                    oneInert[10].Value = model.Sequence;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.OperClass != null)
                    oneInert[11].Value = model.OperClass;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.DiagBeforeOperation != null)
                    oneInert[12].Value = model.DiagBeforeOperation;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.PatientCondition != null)
                    oneInert[13].Value = model.PatientCondition;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.OperScale != null)
                    oneInert[14].Value = model.OperScale;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.WoundType != null)
                    oneInert[15].Value = model.WoundType;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.AsaGrade != null)
                    oneInert[16].Value = model.AsaGrade;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.EmergencyInd != null)
                    oneInert[17].Value = model.EmergencyInd;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.OperSource != null)
                    oneInert[18].Value = model.OperSource;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.IsolationInd != null)
                    oneInert[19].Value = model.IsolationInd;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.InfectedInd != null)
                    oneInert[20].Value = model.InfectedInd;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.RadiateInd != null)
                    oneInert[21].Value = model.RadiateInd;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.Surgeon != null)
                    oneInert[22].Value = model.Surgeon;
                else
                    oneInert[22].Value = DBNull.Value;
                if (model.FirstOperAssistant != null)
                    oneInert[23].Value = model.FirstOperAssistant;
                else
                    oneInert[23].Value = DBNull.Value;
                if (model.SecondOperAssistant != null)
                    oneInert[24].Value = model.SecondOperAssistant;
                else
                    oneInert[24].Value = DBNull.Value;
                if (model.ThirdOperAssistant != null)
                    oneInert[25].Value = model.ThirdOperAssistant;
                else
                    oneInert[25].Value = DBNull.Value;
                if (model.FourthOperAssistant != null)
                    oneInert[26].Value = model.FourthOperAssistant;
                else
                    oneInert[26].Value = DBNull.Value;
                if (model.AnesMethod != null)
                    oneInert[27].Value = model.AnesMethod;
                else
                    oneInert[27].Value = DBNull.Value;
                if (model.AnesDoctor != null)
                    oneInert[28].Value = model.AnesDoctor;
                else
                    oneInert[28].Value = DBNull.Value;
                if (model.FirstAnesAssistant != null)
                    oneInert[29].Value = model.FirstAnesAssistant;
                else
                    oneInert[29].Value = DBNull.Value;
                if (model.SecondAnesAssistant != null)
                    oneInert[30].Value = model.SecondAnesAssistant;
                else
                    oneInert[30].Value = DBNull.Value;
                if (model.ThirdAnesAssistant != null)
                    oneInert[31].Value = model.ThirdAnesAssistant;
                else
                    oneInert[31].Value = DBNull.Value;
                if (model.FourthAnesAssistant != null)
                    oneInert[32].Value = model.FourthAnesAssistant;
                else
                    oneInert[32].Value = DBNull.Value;
                if (model.FirstAnesNurse != null)
                    oneInert[33].Value = model.FirstAnesNurse;
                else
                    oneInert[33].Value = DBNull.Value;
                if (model.SecondAnesNurse != null)
                    oneInert[34].Value = model.SecondAnesNurse;
                else
                    oneInert[34].Value = DBNull.Value;
                if (model.ThirdAnesNurse != null)
                    oneInert[35].Value = model.ThirdAnesNurse;
                else
                    oneInert[35].Value = DBNull.Value;
                if (model.CpbDoctor != null)
                    oneInert[36].Value = model.CpbDoctor;
                else
                    oneInert[36].Value = DBNull.Value;
                if (model.FirstCpbAssistant != null)
                    oneInert[37].Value = model.FirstCpbAssistant;
                else
                    oneInert[37].Value = DBNull.Value;
                if (model.SecondCpbAssistant != null)
                    oneInert[38].Value = model.SecondCpbAssistant;
                else
                    oneInert[38].Value = DBNull.Value;
                if (model.ThirdCpbAssistant != null)
                    oneInert[39].Value = model.ThirdCpbAssistant;
                else
                    oneInert[39].Value = DBNull.Value;
                if (model.FourthCpbAssistant != null)
                    oneInert[40].Value = model.FourthCpbAssistant;
                else
                    oneInert[40].Value = DBNull.Value;
                if (model.FirstOperNurse != null)
                    oneInert[41].Value = model.FirstOperNurse;
                else
                    oneInert[41].Value = DBNull.Value;
                if (model.SecondOperNurse != null)
                    oneInert[42].Value = model.SecondOperNurse;
                else
                    oneInert[42].Value = DBNull.Value;
                if (model.ThirdOperNurse != null)
                    oneInert[43].Value = model.ThirdOperNurse;
                else
                    oneInert[43].Value = DBNull.Value;
                if (model.FourthOperNurse != null)
                    oneInert[44].Value = model.FourthOperNurse;
                else
                    oneInert[44].Value = DBNull.Value;
                if (model.FirstSupplyNurse != null)
                    oneInert[45].Value = model.FirstSupplyNurse;
                else
                    oneInert[45].Value = DBNull.Value;
                if (model.SecondSupplyNurse != null)
                    oneInert[46].Value = model.SecondSupplyNurse;
                else
                    oneInert[46].Value = DBNull.Value;
                if (model.ThirdSupplyNurse != null)
                    oneInert[47].Value = model.ThirdSupplyNurse;
                else
                    oneInert[47].Value = DBNull.Value;
                if (model.FourthSupplyNurse != null)
                    oneInert[48].Value = model.FourthSupplyNurse;
                else
                    oneInert[48].Value = DBNull.Value;
                if (model.PacuDoctor != null)
                    oneInert[49].Value = model.PacuDoctor;
                else
                    oneInert[49].Value = DBNull.Value;
                if (model.FirstPacuAssistant != null)
                    oneInert[50].Value = model.FirstPacuAssistant;
                else
                    oneInert[50].Value = DBNull.Value;
                if (model.SecondPacuAssistant != null)
                    oneInert[51].Value = model.SecondPacuAssistant;
                else
                    oneInert[51].Value = DBNull.Value;
                if (model.FirstPacuNurse != null)
                    oneInert[52].Value = model.FirstPacuNurse;
                else
                    oneInert[52].Value = DBNull.Value;
                if (model.SecondPacuNurse != null)
                    oneInert[53].Value = model.SecondPacuNurse;
                else
                    oneInert[53].Value = DBNull.Value;
                if (model.ReqDateTime != null)
                    oneInert[54].Value = model.ReqDateTime;
                else
                    oneInert[54].Value = DBNull.Value;
                if (model.ScheduledDateTime != null)
                    oneInert[55].Value = model.ScheduledDateTime;
                else
                    oneInert[55].Value = DBNull.Value;
                if (model.OperPosition != null)
                    oneInert[56].Value = model.OperPosition;
                else
                    oneInert[56].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneInert[57].Value = model.BedNo;
                else
                    oneInert[57].Value = DBNull.Value;
                if (model.OperationName != null)
                    oneInert[58].Value = model.OperationName;
                else
                    oneInert[58].Value = DBNull.Value;
                if (model.SpecialEquipment != null)
                    oneInert[59].Value = model.SpecialEquipment;
                else
                    oneInert[59].Value = DBNull.Value;
                if (model.SpecialInfect != null)
                    oneInert[60].Value = model.SpecialInfect;
                else
                    oneInert[60].Value = DBNull.Value;
                if (model.AnesConfirm != null)
                    oneInert[61].Value = model.AnesConfirm;
                else
                    oneInert[61].Value = DBNull.Value;
                if (model.NurseConfirm != null)
                    oneInert[62].Value = model.NurseConfirm;
                else
                    oneInert[62].Value = DBNull.Value;
                if (model.OperStatusCode != null)
                    oneInert[63].Value = model.OperStatusCode;
                else
                    oneInert[63].Value = DBNull.Value;
                if (model.NotesOnOperation != null)
                    oneInert[64].Value = model.NotesOnOperation;
                else
                    oneInert[64].Value = DBNull.Value;
                if (model.Operator != null)
                    oneInert[65].Value = model.Operator;
                else
                    oneInert[65].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneInert[66].Value = model.HisPatientId;
                else
                    oneInert[66].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneInert[67].Value = model.HisVisitId;
                else
                    oneInert[67].Value = DBNull.Value;
                if (model.HisScheduleId != null)
                    oneInert[68].Value = model.HisScheduleId;
                else
                    oneInert[68].Value = DBNull.Value;
                if (model.HisOperStatus != null)
                    oneInert[69].Value = model.HisOperStatus;
                else
                    oneInert[69].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneInert[70].Value = model.Reserved1;
                else
                    oneInert[70].Value = DBNull.Value;
                if (model.Reserved2 != null)
                    oneInert[71].Value = model.Reserved2;
                else
                    oneInert[71].Value = DBNull.Value;
                if (model.Reserved3 != null)
                    oneInert[72].Value = model.Reserved3;
                else
                    oneInert[72].Value = DBNull.Value;
                if (model.OperatingTime != null)
                    oneInert[73].Value = model.OperatingTime;
                else
                    oneInert[73].Value = DBNull.Value;
                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_OLE, oneInert);
            }
        }

        public int UpdateMedOperationScheduleOLE(Model.MedOperationSchedule model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedOperationSchedule");

                if (model.OperId != null)
                    oneUpdate[0].Value = model.OperId;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.HospBranch != null)
                    oneUpdate[1].Value = model.HospBranch;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneUpdate[2].Value = model.WardCode;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneUpdate[3].Value = model.DeptCode;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.OperDeptCode != null)
                    oneUpdate[4].Value = model.OperDeptCode;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.OperRoom != null)
                    oneUpdate[5].Value = model.OperRoom;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.OperRoomNo != null)
                    oneUpdate[6].Value = model.OperRoomNo;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.Sequence != null)
                    oneUpdate[7].Value = model.Sequence;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.OperClass != null)
                    oneUpdate[8].Value = model.OperClass;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.DiagBeforeOperation != null)
                    oneUpdate[9].Value = model.DiagBeforeOperation;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.PatientCondition != null)
                    oneUpdate[10].Value = model.PatientCondition;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.OperScale != null)
                    oneUpdate[11].Value = model.OperScale;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.WoundType != null)
                    oneUpdate[12].Value = model.WoundType;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.AsaGrade != null)
                    oneUpdate[13].Value = model.AsaGrade;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.EmergencyInd != null)
                    oneUpdate[14].Value = model.EmergencyInd;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.OperSource != null)
                    oneUpdate[15].Value = model.OperSource;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.IsolationInd != null)
                    oneUpdate[16].Value = model.IsolationInd;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.InfectedInd != null)
                    oneUpdate[17].Value = model.InfectedInd;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.RadiateInd != null)
                    oneUpdate[18].Value = model.RadiateInd;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.Surgeon != null)
                    oneUpdate[19].Value = model.Surgeon;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.FirstOperAssistant != null)
                    oneUpdate[20].Value = model.FirstOperAssistant;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.SecondOperAssistant != null)
                    oneUpdate[21].Value = model.SecondOperAssistant;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.ThirdOperAssistant != null)
                    oneUpdate[22].Value = model.ThirdOperAssistant;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.FourthOperAssistant != null)
                    oneUpdate[23].Value = model.FourthOperAssistant;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.AnesMethod != null)
                    oneUpdate[24].Value = model.AnesMethod;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.AnesDoctor != null)
                    oneUpdate[25].Value = model.AnesDoctor;
                else
                    oneUpdate[25].Value = DBNull.Value;
                if (model.FirstAnesAssistant != null)
                    oneUpdate[26].Value = model.FirstAnesAssistant;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (model.SecondAnesAssistant != null)
                    oneUpdate[27].Value = model.SecondAnesAssistant;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (model.ThirdAnesAssistant != null)
                    oneUpdate[28].Value = model.ThirdAnesAssistant;
                else
                    oneUpdate[28].Value = DBNull.Value;
                if (model.FourthAnesAssistant != null)
                    oneUpdate[29].Value = model.FourthAnesAssistant;
                else
                    oneUpdate[29].Value = DBNull.Value;
                if (model.FirstAnesNurse != null)
                    oneUpdate[30].Value = model.FirstAnesNurse;
                else
                    oneUpdate[30].Value = DBNull.Value;
                if (model.SecondAnesNurse != null)
                    oneUpdate[31].Value = model.SecondAnesNurse;
                else
                    oneUpdate[31].Value = DBNull.Value;
                if (model.ThirdAnesNurse != null)
                    oneUpdate[32].Value = model.ThirdAnesNurse;
                else
                    oneUpdate[32].Value = DBNull.Value;
                if (model.CpbDoctor != null)
                    oneUpdate[33].Value = model.CpbDoctor;
                else
                    oneUpdate[33].Value = DBNull.Value;
                if (model.FirstCpbAssistant != null)
                    oneUpdate[34].Value = model.FirstCpbAssistant;
                else
                    oneUpdate[34].Value = DBNull.Value;
                if (model.SecondCpbAssistant != null)
                    oneUpdate[35].Value = model.SecondCpbAssistant;
                else
                    oneUpdate[35].Value = DBNull.Value;
                if (model.ThirdCpbAssistant != null)
                    oneUpdate[36].Value = model.ThirdCpbAssistant;
                else
                    oneUpdate[36].Value = DBNull.Value;
                if (model.FourthCpbAssistant != null)
                    oneUpdate[37].Value = model.FourthCpbAssistant;
                else
                    oneUpdate[37].Value = DBNull.Value;
                if (model.FirstOperNurse != null)
                    oneUpdate[38].Value = model.FirstOperNurse;
                else
                    oneUpdate[38].Value = DBNull.Value;
                if (model.SecondOperNurse != null)
                    oneUpdate[39].Value = model.SecondOperNurse;
                else
                    oneUpdate[39].Value = DBNull.Value;
                if (model.ThirdOperNurse != null)
                    oneUpdate[40].Value = model.ThirdOperNurse;
                else
                    oneUpdate[40].Value = DBNull.Value;
                if (model.FourthOperNurse != null)
                    oneUpdate[41].Value = model.FourthOperNurse;
                else
                    oneUpdate[41].Value = DBNull.Value;
                if (model.FirstSupplyNurse != null)
                    oneUpdate[42].Value = model.FirstSupplyNurse;
                else
                    oneUpdate[42].Value = DBNull.Value;
                if (model.SecondSupplyNurse != null)
                    oneUpdate[43].Value = model.SecondSupplyNurse;
                else
                    oneUpdate[43].Value = DBNull.Value;
                if (model.ThirdSupplyNurse != null)
                    oneUpdate[44].Value = model.ThirdSupplyNurse;
                else
                    oneUpdate[44].Value = DBNull.Value;
                if (model.FourthSupplyNurse != null)
                    oneUpdate[45].Value = model.FourthSupplyNurse;
                else
                    oneUpdate[45].Value = DBNull.Value;
                if (model.PacuDoctor != null)
                    oneUpdate[46].Value = model.PacuDoctor;
                else
                    oneUpdate[46].Value = DBNull.Value;
                if (model.FirstPacuAssistant != null)
                    oneUpdate[47].Value = model.FirstPacuAssistant;
                else
                    oneUpdate[47].Value = DBNull.Value;
                if (model.SecondPacuAssistant != null)
                    oneUpdate[48].Value = model.SecondPacuAssistant;
                else
                    oneUpdate[48].Value = DBNull.Value;
                if (model.FirstPacuNurse != null)
                    oneUpdate[49].Value = model.FirstPacuNurse;
                else
                    oneUpdate[49].Value = DBNull.Value;
                if (model.SecondPacuNurse != null)
                    oneUpdate[50].Value = model.SecondPacuNurse;
                else
                    oneUpdate[50].Value = DBNull.Value;
                if (model.ReqDateTime != null)
                    oneUpdate[51].Value = model.ReqDateTime;
                else
                    oneUpdate[51].Value = DBNull.Value;
                if (model.ScheduledDateTime != null)
                    oneUpdate[52].Value = model.ScheduledDateTime;
                else
                    oneUpdate[52].Value = DBNull.Value;
                if (model.OperPosition != null)
                    oneUpdate[53].Value = model.OperPosition;
                else
                    oneUpdate[53].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneUpdate[54].Value = model.BedNo;
                else
                    oneUpdate[54].Value = DBNull.Value;
                if (model.OperationName != null)
                    oneUpdate[55].Value = model.OperationName;
                else
                    oneUpdate[55].Value = DBNull.Value;
                if (model.SpecialEquipment != null)
                    oneUpdate[56].Value = model.SpecialEquipment;
                else
                    oneUpdate[56].Value = DBNull.Value;
                if (model.SpecialInfect != null)
                    oneUpdate[57].Value = model.SpecialInfect;
                else
                    oneUpdate[57].Value = DBNull.Value;
                if (model.AnesConfirm != null)
                    oneUpdate[58].Value = model.AnesConfirm;
                else
                    oneUpdate[58].Value = DBNull.Value;
                if (model.NurseConfirm != null)
                    oneUpdate[59].Value = model.NurseConfirm;
                else
                    oneUpdate[59].Value = DBNull.Value;
                if (model.OperStatusCode != null)
                    oneUpdate[60].Value = model.OperStatusCode;
                else
                    oneUpdate[60].Value = DBNull.Value;
                if (model.NotesOnOperation != null)
                    oneUpdate[61].Value = model.NotesOnOperation;
                else
                    oneUpdate[61].Value = DBNull.Value;
                if (model.Operator != null)
                    oneUpdate[62].Value = model.Operator;
                else
                    oneUpdate[62].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneUpdate[63].Value = model.HisPatientId;
                else
                    oneUpdate[63].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneUpdate[64].Value = model.HisVisitId;
                else
                    oneUpdate[64].Value = DBNull.Value;
                if (model.HisScheduleId != null)
                    oneUpdate[65].Value = model.HisScheduleId;
                else
                    oneUpdate[65].Value = DBNull.Value;
                if (model.HisOperStatus != null)
                    oneUpdate[66].Value = model.HisOperStatus;
                else
                    oneUpdate[66].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneUpdate[67].Value = model.Reserved1;
                else
                    oneUpdate[67].Value = DBNull.Value;
                if (model.Reserved2 != null)
                    oneUpdate[68].Value = model.Reserved2;
                else
                    oneUpdate[68].Value = DBNull.Value;
                if (model.Reserved3 != null)
                    oneUpdate[69].Value = model.Reserved3;
                else
                    oneUpdate[69].Value = DBNull.Value;
                if (model.OperatingTime != null)
                    oneUpdate[70].Value = model.OperatingTime;
                else
                    oneUpdate[70].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[71].Value = model.PatientId;
                else
                    oneUpdate[71].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneUpdate[72].Value = model.VisitId;
                else
                    oneUpdate[72].Value = DBNull.Value;
                if (model.ScheduleId != null)
                    oneUpdate[73].Value = model.VisitId;
                else
                    oneUpdate[73].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_OLE, oneUpdate);
            }
        }

        public int DeleteMedOperationScheduleOLE(string PatientId, decimal VisitId, decimal ScheduleId)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedOperationSchedule");
                oneDelete[0].Value = PatientId;
                oneDelete[1].Value = VisitId;
                oneDelete[2].Value = ScheduleId;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Delete_MedOperationSchedule_OLE, oneDelete);
            }
        }


        private static string Select_ODBC = "select PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME from MED_OPERATION_SCHEDULE WHERE PATIENT_ID=? AND VISIT_ID=? AND SCHEDULE_ID=?";


        private static string Update_ODBC = "Update MED_OPERATION_SCHEDULE set OPER_ID=?,HOSP_BRANCH=?,WARD_CODE=?,DEPT_CODE=?,OPER_DEPT_CODE=?,OPER_ROOM=?,OPER_ROOM_NO=?,SEQUENCE=?,OPER_CLASS=?,DIAG_BEFORE_OPERATION=?,PATIENT_CONDITION=?,OPER_SCALE=?,WOUND_TYPE=?,ASA_GRADE=?,EMERGENCY_IND=?,OPER_SOURCE=?,ISOLATION_IND=?,INFECTED_IND=?,RADIATE_IND=?,SURGEON=?,FIRST_OPER_ASSISTANT=?,SECOND_OPER_ASSISTANT=?,THIRD_OPER_ASSISTANT=?,FOURTH_OPER_ASSISTANT=?,ANES_METHOD=?,ANES_DOCTOR=?,FIRST_ANES_ASSISTANT=?,SECOND_ANES_ASSISTANT=?,THIRD_ANES_ASSISTANT=?,FOURTH_ANES_ASSISTANT=?,FIRST_ANES_NURSE=?,SECOND_ANES_NURSE=?,THIRD_ANES_NURSE=?,CPB_DOCTOR=?,FIRST_CPB_ASSISTANT=?,SECOND_CPB_ASSISTANT=?,THIRD_CPB_ASSISTANT=?,FOURTH_CPB_ASSISTANT=?,FIRST_OPER_NURSE=?,SECOND_OPER_NURSE=?,THIRD_OPER_NURSE=?,FOURTH_OPER_NURSE=?,FIRST_SUPPLY_NURSE=?,SECOND_SUPPLY_NURSE=?,THIRD_SUPPLY_NURSE=?,FOURTH_SUPPLY_NURSE=?,PACU_DOCTOR=?,FIRST_PACU_ASSISTANT=?,SECOND_PACU_ASSISTANT=?,FIRST_PACU_NURSE=?,SECOND_PACU_NURSE=?,REQ_DATE_TIME=?,SCHEDULED_DATE_TIME=?,OPER_POSITION=?,BED_NO=?,OPERATION_NAME=?,SPECIAL_EQUIPMENT=?,SPECIAL_INFECT=?,ANES_CONFIRM=?,NURSE_CONFIRM=?,OPER_STATUS_CODE=?,NOTES_ON_OPERATION=?,OPERATOR=?,HIS_PATIENT_ID=?,HIS_VISIT_ID=?,HIS_SCHEDULE_ID=?,HIS_OPER_STATUS=?,RESERVED1=?,RESERVED2=?,RESERVED3=?,OPERATING_TIME=? where PATIENT_ID=? AND VISIT_ID=? AND SCHEDULE_ID=?";


        private static string Insert_ODBC = "Insert into MED_OPERATION_SCHEDULE  (PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";



        private static readonly string Select_Max_ScheduleId_Med_Operation_Schedule_Odbc = "select nvl(max(schedule_id),0) from med_operation_schedule where patient_id = ? and visit_id = ?";
        private static readonly string Select_Count_Med_Operation_Schedule_Odbc = "Select count(*) from med_operation_schedule where patient_id = ? and visit_id = ? and schedule_id = ?";
        private static readonly string Select_One_Med_Operation_Schedule_Odbc = "select PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME from med_operation_schedule where patient_id = ? and visit_id = ? and schedule_id = ? ";
        private static readonly string Select_One_Med_Operation_Schedule_OperId_Odbc = "select PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME from med_operation_schedule where patient_id = ? and visit_id = ? and oper_id = ? ";
        private static readonly string Select_Med_Operation_Schedule_Odbc = "select PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME from med_operation_schedule where patient_id = ? and visit_id = ? ";
        // private static readonly string Insert_Med_Operation_Schedule_Odbc = "insert into med_operation_schedule(patient_id, visit_id, schedule_id, dept_stayed, bed_no, scheduled_date_time, operating_room, operating_room_no, sequence, diag_before_operation, patient_condition, operation_scale, isolation_indicator, operating_dept, surgeon, first_assistant, second_assistant, third_assistant, fourth_assistant, anesthesia_method, anesthesia_doctor, anesthesia_assistant, blood_tran_doctor, first_operation_nurse, second_operation_nurse, first_supply_nurse, second_supply_nurse, notes_on_operation, entered_by, req_date_time, third_supply_nurse, ack_indicator, emergency_indicator, oper_id, second_anesthesia_assistant, third_anesthesia_assistant, fourth_anesthesia_assistant, second_anesthesia_doctor, third_anesthesia_doctor,operation_position,reserved1, reserved2, reserved3,reserved4,reserved5,reserved6, reserved7, reserved8,state,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,OPERATION_ID,third_operation_nurse)values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,? ,? ,? ,? ,? ,? ,?, ?, ? , ?,?,?,?,?,?)";
        //  private static readonly string Update_Med_Operation_Schedule_Odbc = "update med_operation_schedule set  dept_stayed = ?, bed_no = ?, scheduled_date_time = ?, operating_room = ?, operating_room_no = ?, sequence = ?, diag_before_operation = ?,patient_condition = ?, operation_scale = ?, isolation_indicator = ?, operating_dept = ?, surgeon = ?, first_assistant = ?, second_assistant = ?, third_assistant = ?, fourth_assistant = ?, anesthesia_method = ?, anesthesia_doctor = ?, anesthesia_assistant = ?, blood_tran_doctor = ?, first_operation_nurse = ?, second_operation_nurse = ?, first_supply_nurse = ?, second_supply_nurse = ?, notes_on_operation = ?,  entered_by = ?, req_date_time = ?, third_supply_nurse = ?, ack_indicator = ?, emergency_indicator = ?, oper_id = ?, second_anesthesia_assistant = ?, third_anesthesia_assistant = ?, fourth_anesthesia_assistant = ?, second_anesthesia_doctor = ?, third_anesthesia_doctor = ?,operation_position = ?,reserved1 = ?, reserved2 = ? , reserved3 = ? , reserved4 = ?, reserved5 = ?, reserved6 = ?, reserved7 = ?, reserved8 = ?,state =?,OPERATION_NAME=?,SPECIAL_EQUIPMENT=?,SPECIAL_INFECT=?,OPERATION_ID=?,third_operation_nurse=?  where patient_id = ? and visit_id = ? and schedule_id = ? ";
        private static readonly string Delete_MedOperationSchedule_Odbc = "delete med_operation_schedule where patient_id = ? and visit_id = ? and schedule_id = ? ";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectOneMedOperationSchedule" || sqlParms == "SelectCountMedOperationSchedule" || sqlParms == "DeleteMedOperationSchedule")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("scheduleId",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "SelectPatMedOperationSchedule" || sqlParms == "SelectMaxScheduleIdMedOperationSchedule")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "SelectOneMedOperationScheduleOperId")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("operId",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "InsertMedOperationSchedule")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("PatientId",OdbcType.VarChar),
                        new OdbcParameter("VisitId",OdbcType.Decimal),
                        new OdbcParameter("ScheduleId",OdbcType.Decimal),
                        new OdbcParameter("OperId",OdbcType.Decimal),
                        new OdbcParameter("HospBranch",OdbcType.VarChar),
                        new OdbcParameter("WardCode",OdbcType.VarChar),
                        new OdbcParameter("DeptCode",OdbcType.VarChar),
                        new OdbcParameter("OperDeptCode",OdbcType.VarChar),
                        new OdbcParameter("OperRoom",OdbcType.VarChar),
                        new OdbcParameter("OperRoomNo",OdbcType.VarChar),
                        new OdbcParameter("Sequence",OdbcType.Decimal),
                        new OdbcParameter("OperClass",OdbcType.VarChar),
                        new OdbcParameter("DiagBeforeOperation",OdbcType.VarChar),
                        new OdbcParameter("PatientCondition",OdbcType.VarChar),
                        new OdbcParameter("OperScale",OdbcType.VarChar),
                        new OdbcParameter("WoundType",OdbcType.VarChar),
                        new OdbcParameter("AsaGrade",OdbcType.VarChar),
                        new OdbcParameter("EmergencyInd",OdbcType.Decimal),
                        new OdbcParameter("OperSource",OdbcType.Decimal),
                        new OdbcParameter("IsolationInd",OdbcType.Decimal),
                        new OdbcParameter("InfectedInd",OdbcType.Decimal),
                        new OdbcParameter("RadiateInd",OdbcType.Decimal),
                        new OdbcParameter("Surgeon",OdbcType.VarChar),
                        new OdbcParameter("FirstOperAssistant",OdbcType.VarChar),
                        new OdbcParameter("SecondOperAssistant",OdbcType.VarChar),
                        new OdbcParameter("ThirdOperAssistant",OdbcType.VarChar),
                        new OdbcParameter("FourthOperAssistant",OdbcType.VarChar),
                        new OdbcParameter("AnesMethod",OdbcType.VarChar),
                        new OdbcParameter("AnesDoctor",OdbcType.VarChar),
                        new OdbcParameter("FirstAnesAssistant",OdbcType.VarChar),
                        new OdbcParameter("SecondAnesAssistant",OdbcType.VarChar),
                        new OdbcParameter("ThirdAnesAssistant",OdbcType.VarChar),
                        new OdbcParameter("FourthAnesAssistant",OdbcType.VarChar),
                        new OdbcParameter("FirstAnesNurse",OdbcType.VarChar),
                        new OdbcParameter("SecondAnesNurse",OdbcType.VarChar),
                        new OdbcParameter("ThirdAnesNurse",OdbcType.VarChar),
                        new OdbcParameter("CpbDoctor",OdbcType.VarChar),
                        new OdbcParameter("FirstCpbAssistant",OdbcType.VarChar),
                        new OdbcParameter("SecondCpbAssistant",OdbcType.VarChar),
                        new OdbcParameter("ThirdCpbAssistant",OdbcType.VarChar),
                        new OdbcParameter("FourthCpbAssistant",OdbcType.VarChar),
                        new OdbcParameter("FirstOperNurse",OdbcType.VarChar),
                        new OdbcParameter("SecondOperNurse",OdbcType.VarChar),
                        new OdbcParameter("ThirdOperNurse",OdbcType.VarChar),
                        new OdbcParameter("FourthOperNurse",OdbcType.VarChar),
                        new OdbcParameter("FirstSupplyNurse",OdbcType.VarChar),
                        new OdbcParameter("SecondSupplyNurse",OdbcType.VarChar),
                        new OdbcParameter("ThirdSupplyNurse",OdbcType.VarChar),
                        new OdbcParameter("FourthSupplyNurse",OdbcType.VarChar),
                        new OdbcParameter("PacuDoctor",OdbcType.VarChar),
                        new OdbcParameter("FirstPacuAssistant",OdbcType.VarChar),
                        new OdbcParameter("SecondPacuAssistant",OdbcType.VarChar),
                        new OdbcParameter("FirstPacuNurse",OdbcType.VarChar),
                        new OdbcParameter("SecondPacuNurse",OdbcType.VarChar),
                        new OdbcParameter("ReqDateTime",OdbcType.DateTime),
                        new OdbcParameter("ScheduledDateTime",OdbcType.DateTime),
                        new OdbcParameter("OperPosition",OdbcType.VarChar),
                        new OdbcParameter("BedNo",OdbcType.VarChar),
                        new OdbcParameter("OperationName",OdbcType.VarChar),
                        new OdbcParameter("SpecialEquipment",OdbcType.VarChar),
                        new OdbcParameter("SpecialInfect",OdbcType.VarChar),
                        new OdbcParameter("AnesConfirm",OdbcType.VarChar),
                        new OdbcParameter("NurseConfirm",OdbcType.VarChar),
                        new OdbcParameter("OperStatusCode",OdbcType.VarChar),
                        new OdbcParameter("NotesOnOperation",OdbcType.VarChar),
                        new OdbcParameter("Operator",OdbcType.VarChar),
                        new OdbcParameter("HisPatientId",OdbcType.VarChar),
                        new OdbcParameter("HisVisitId",OdbcType.VarChar),
                        new OdbcParameter("HisScheduleId",OdbcType.VarChar),
                        new OdbcParameter("HisOperStatus",OdbcType.VarChar),
                        new OdbcParameter("Reserved1",OdbcType.VarChar),
                        new OdbcParameter("Reserved2",OdbcType.VarChar),
                        new OdbcParameter("Reserved3",OdbcType.VarChar),
                        new OdbcParameter("OperatingTime",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "UpdateMedOperationSchedule")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("OperId",OdbcType.Decimal),
                        new OdbcParameter("HospBranch",OdbcType.VarChar),
                        new OdbcParameter("WardCode",OdbcType.VarChar),
                        new OdbcParameter("DeptCode",OdbcType.VarChar),
                        new OdbcParameter("OperDeptCode",OdbcType.VarChar),
                        new OdbcParameter("OperRoom",OdbcType.VarChar),
                        new OdbcParameter("OperRoomNo",OdbcType.VarChar),
                        new OdbcParameter("Sequence",OdbcType.Decimal),
                        new OdbcParameter("OperClass",OdbcType.VarChar),
                        new OdbcParameter("DiagBeforeOperation",OdbcType.VarChar),
                        new OdbcParameter("PatientCondition",OdbcType.VarChar),
                        new OdbcParameter("OperScale",OdbcType.VarChar),
                        new OdbcParameter("WoundType",OdbcType.VarChar),
                        new OdbcParameter("AsaGrade",OdbcType.VarChar),
                        new OdbcParameter("EmergencyInd",OdbcType.Decimal),
                        new OdbcParameter("OperSource",OdbcType.Decimal),
                        new OdbcParameter("IsolationInd",OdbcType.Decimal),
                        new OdbcParameter("InfectedInd",OdbcType.Decimal),
                        new OdbcParameter("RadiateInd",OdbcType.Decimal),
                        new OdbcParameter("Surgeon",OdbcType.VarChar),
                        new OdbcParameter("FirstOperAssistant",OdbcType.VarChar),
                        new OdbcParameter("SecondOperAssistant",OdbcType.VarChar),
                        new OdbcParameter("ThirdOperAssistant",OdbcType.VarChar),
                        new OdbcParameter("FourthOperAssistant",OdbcType.VarChar),
                        new OdbcParameter("AnesMethod",OdbcType.VarChar),
                        new OdbcParameter("AnesDoctor",OdbcType.VarChar),
                        new OdbcParameter("FirstAnesAssistant",OdbcType.VarChar),
                        new OdbcParameter("SecondAnesAssistant",OdbcType.VarChar),
                        new OdbcParameter("ThirdAnesAssistant",OdbcType.VarChar),
                        new OdbcParameter("FourthAnesAssistant",OdbcType.VarChar),
                        new OdbcParameter("FirstAnesNurse",OdbcType.VarChar),
                        new OdbcParameter("SecondAnesNurse",OdbcType.VarChar),
                        new OdbcParameter("ThirdAnesNurse",OdbcType.VarChar),
                        new OdbcParameter("CpbDoctor",OdbcType.VarChar),
                        new OdbcParameter("FirstCpbAssistant",OdbcType.VarChar),
                        new OdbcParameter("SecondCpbAssistant",OdbcType.VarChar),
                        new OdbcParameter("ThirdCpbAssistant",OdbcType.VarChar),
                        new OdbcParameter("FourthCpbAssistant",OdbcType.VarChar),
                        new OdbcParameter("FirstOperNurse",OdbcType.VarChar),
                        new OdbcParameter("SecondOperNurse",OdbcType.VarChar),
                        new OdbcParameter("ThirdOperNurse",OdbcType.VarChar),
                        new OdbcParameter("FourthOperNurse",OdbcType.VarChar),
                        new OdbcParameter("FirstSupplyNurse",OdbcType.VarChar),
                        new OdbcParameter("SecondSupplyNurse",OdbcType.VarChar),
                        new OdbcParameter("ThirdSupplyNurse",OdbcType.VarChar),
                        new OdbcParameter("FourthSupplyNurse",OdbcType.VarChar),
                        new OdbcParameter("PacuDoctor",OdbcType.VarChar),
                        new OdbcParameter("FirstPacuAssistant",OdbcType.VarChar),
                        new OdbcParameter("SecondPacuAssistant",OdbcType.VarChar),
                        new OdbcParameter("FirstPacuNurse",OdbcType.VarChar),
                        new OdbcParameter("SecondPacuNurse",OdbcType.VarChar),
                        new OdbcParameter("ReqDateTime",OdbcType.DateTime),
                        new OdbcParameter("ScheduledDateTime",OdbcType.DateTime),
                        new OdbcParameter("OperPosition",OdbcType.VarChar),
                        new OdbcParameter("BedNo",OdbcType.VarChar),
                        new OdbcParameter("OperationName",OdbcType.VarChar),
                        new OdbcParameter("SpecialEquipment",OdbcType.VarChar),
                        new OdbcParameter("SpecialInfect",OdbcType.VarChar),
                        new OdbcParameter("AnesConfirm",OdbcType.VarChar),
                        new OdbcParameter("NurseConfirm",OdbcType.VarChar),
                        new OdbcParameter("OperStatusCode",OdbcType.VarChar),
                        new OdbcParameter("NotesOnOperation",OdbcType.VarChar),
                        new OdbcParameter("Operator",OdbcType.VarChar),
                        new OdbcParameter("HisPatientId",OdbcType.VarChar),
                        new OdbcParameter("HisVisitId",OdbcType.VarChar),
                        new OdbcParameter("HisScheduleId",OdbcType.VarChar),
                        new OdbcParameter("HisOperStatus",OdbcType.VarChar),
                        new OdbcParameter("Reserved1",OdbcType.VarChar),
                        new OdbcParameter("Reserved2",OdbcType.VarChar),
                        new OdbcParameter("Reserved3",OdbcType.VarChar),
                        new OdbcParameter("OperatingTime",OdbcType.Decimal),
                        new OdbcParameter("PatientId",OdbcType.VarChar),
                        new OdbcParameter("VisitId",OdbcType.Decimal),
                        new OdbcParameter("ScheduleId",OdbcType.Decimal),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public int SelectMaxScheduleIdOdbc(string patientId, decimal visitId)
        {
            OdbcParameter[] medMaxScheduleId = GetParameterOdbc("SelectMaxScheduleIdMedOperationSchedule");
            medMaxScheduleId[0].Value = patientId;
            medMaxScheduleId[1].Value = visitId;
            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_Max_ScheduleId_Med_Operation_Schedule_Odbc, medMaxScheduleId))
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

        public int SelectCountMedOperationScheduleOdbc(string patientId, decimal visitId, decimal scheduleId)
        {
            OdbcParameter[] countMedOperationSchedule = GetParameterOdbc("SelectCountMedOperationSchedule");
            countMedOperationSchedule[0].Value = patientId;
            countMedOperationSchedule[1].Value = visitId;
            countMedOperationSchedule[2].Value = scheduleId;

            object count = OdbcHelper.ExecuteScalar(OdbcHelper.ConnectionString, CommandType.Text, Select_Count_Med_Operation_Schedule_Odbc, countMedOperationSchedule);
            if (count == null)
                count = (object)0;
            return Convert.ToInt32(count);
        }

        public Model.MedOperationSchedule SelectMedOperationScheduleOdbc(string patientId, decimal visitId, decimal scheduleId)
        {
            Model.MedOperationSchedule model = null;

            OdbcParameter[] medOperationScheduleParams = GetParameterOdbc("SelectOneMedOperationSchedule");
            medOperationScheduleParams[0].Value = patientId;
            medOperationScheduleParams[1].Value = visitId;
            medOperationScheduleParams[2].Value = scheduleId;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_One_Med_Operation_Schedule_Odbc, medOperationScheduleParams))
            {
                if (oleReader.Read())
                {
                    model = new MedicalSytem.Soft.Model.MedOperationSchedule();
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.OperDeptCode = oleReader["OPER_DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.OperRoom = oleReader["OPER_ROOM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.OperRoomNo = oleReader["OPER_ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Sequence = decimal.Parse(oleReader["SEQUENCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.OperClass = oleReader["OPER_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.DiagBeforeOperation = oleReader["DIAG_BEFORE_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.AsaGrade = oleReader["ASA_GRADE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.EmergencyInd = decimal.Parse(oleReader["EMERGENCY_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.OperSource = decimal.Parse(oleReader["OPER_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.IsolationInd = decimal.Parse(oleReader["ISOLATION_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.InfectedInd = decimal.Parse(oleReader["INFECTED_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.RadiateInd = decimal.Parse(oleReader["RADIATE_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Surgeon = oleReader["SURGEON"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.FirstOperAssistant = oleReader["FIRST_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.SecondOperAssistant = oleReader["SECOND_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.ThirdOperAssistant = oleReader["THIRD_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.FourthOperAssistant = oleReader["FOURTH_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.AnesMethod = oleReader["ANES_METHOD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.AnesDoctor = oleReader["ANES_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.FirstAnesAssistant = oleReader["FIRST_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.SecondAnesAssistant = oleReader["SECOND_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.ThirdAnesAssistant = oleReader["THIRD_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.FourthAnesAssistant = oleReader["FOURTH_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.FirstAnesNurse = oleReader["FIRST_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.SecondAnesNurse = oleReader["SECOND_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.ThirdAnesNurse = oleReader["THIRD_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.CpbDoctor = oleReader["CPB_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.FirstCpbAssistant = oleReader["FIRST_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.SecondCpbAssistant = oleReader["SECOND_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.ThirdCpbAssistant = oleReader["THIRD_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.FourthCpbAssistant = oleReader["FOURTH_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.FirstOperNurse = oleReader["FIRST_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(42))
                    {
                        model.SecondOperNurse = oleReader["SECOND_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(43))
                    {
                        model.ThirdOperNurse = oleReader["THIRD_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(44))
                    {
                        model.FourthOperNurse = oleReader["FOURTH_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(45))
                    {
                        model.FirstSupplyNurse = oleReader["FIRST_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(46))
                    {
                        model.SecondSupplyNurse = oleReader["SECOND_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(47))
                    {
                        model.ThirdSupplyNurse = oleReader["THIRD_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(48))
                    {
                        model.FourthSupplyNurse = oleReader["FOURTH_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(49))
                    {
                        model.PacuDoctor = oleReader["PACU_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(50))
                    {
                        model.FirstPacuAssistant = oleReader["FIRST_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(51))
                    {
                        model.SecondPacuAssistant = oleReader["SECOND_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(52))
                    {
                        model.FirstPacuNurse = oleReader["FIRST_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(53))
                    {
                        model.SecondPacuNurse = oleReader["SECOND_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(54))
                    {
                        model.ReqDateTime = DateTime.Parse(oleReader["REQ_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(55))
                    {
                        model.ScheduledDateTime = DateTime.Parse(oleReader["SCHEDULED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(56))
                    {
                        model.OperPosition = oleReader["OPER_POSITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(57))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(58))
                    {
                        model.OperationName = oleReader["OPERATION_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(59))
                    {
                        model.SpecialEquipment = oleReader["SPECIAL_EQUIPMENT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(60))
                    {
                        model.SpecialInfect = oleReader["SPECIAL_INFECT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(61))
                    {
                        model.AnesConfirm = oleReader["ANES_CONFIRM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(62))
                    {
                        model.NurseConfirm = oleReader["NURSE_CONFIRM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(63))
                    {
                        model.OperStatusCode = oleReader["OPER_STATUS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(64))
                    {
                        model.NotesOnOperation = oleReader["NOTES_ON_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(65))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(66))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(67))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(68))
                    {
                        model.HisScheduleId = oleReader["HIS_SCHEDULE_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(69))
                    {
                        model.HisOperStatus = oleReader["HIS_OPER_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(70))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(71))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(72))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(73))
                    {
                        model.OperatingTime = decimal.Parse(oleReader["OPERATING_TIME"].ToString().Trim());
                    }
                }
                else
                    model = null;
            }
            return model;
        }

        public Model.MedOperationSchedule SelectMedOperationScheduleWithOperIdOdbc(string patientId, decimal visitId, decimal operId)
        {
            Model.MedOperationSchedule model = null;

            OdbcParameter[] medOperationScheduleParams = GetParameterOdbc("SelectOneMedOperationScheduleOperId");
            medOperationScheduleParams[0].Value = patientId;
            medOperationScheduleParams[1].Value = visitId;
            medOperationScheduleParams[2].Value = operId;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_One_Med_Operation_Schedule_OperId_Odbc, medOperationScheduleParams))
            {
                if (oleReader.Read())
                {
                    model = new MedicalSytem.Soft.Model.MedOperationSchedule();
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.OperDeptCode = oleReader["OPER_DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.OperRoom = oleReader["OPER_ROOM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.OperRoomNo = oleReader["OPER_ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Sequence = decimal.Parse(oleReader["SEQUENCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.OperClass = oleReader["OPER_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.DiagBeforeOperation = oleReader["DIAG_BEFORE_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.AsaGrade = oleReader["ASA_GRADE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.EmergencyInd = decimal.Parse(oleReader["EMERGENCY_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.OperSource = decimal.Parse(oleReader["OPER_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.IsolationInd = decimal.Parse(oleReader["ISOLATION_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.InfectedInd = decimal.Parse(oleReader["INFECTED_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.RadiateInd = decimal.Parse(oleReader["RADIATE_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Surgeon = oleReader["SURGEON"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.FirstOperAssistant = oleReader["FIRST_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.SecondOperAssistant = oleReader["SECOND_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.ThirdOperAssistant = oleReader["THIRD_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.FourthOperAssistant = oleReader["FOURTH_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.AnesMethod = oleReader["ANES_METHOD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.AnesDoctor = oleReader["ANES_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.FirstAnesAssistant = oleReader["FIRST_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.SecondAnesAssistant = oleReader["SECOND_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.ThirdAnesAssistant = oleReader["THIRD_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.FourthAnesAssistant = oleReader["FOURTH_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.FirstAnesNurse = oleReader["FIRST_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.SecondAnesNurse = oleReader["SECOND_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.ThirdAnesNurse = oleReader["THIRD_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.CpbDoctor = oleReader["CPB_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.FirstCpbAssistant = oleReader["FIRST_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.SecondCpbAssistant = oleReader["SECOND_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.ThirdCpbAssistant = oleReader["THIRD_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.FourthCpbAssistant = oleReader["FOURTH_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.FirstOperNurse = oleReader["FIRST_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(42))
                    {
                        model.SecondOperNurse = oleReader["SECOND_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(43))
                    {
                        model.ThirdOperNurse = oleReader["THIRD_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(44))
                    {
                        model.FourthOperNurse = oleReader["FOURTH_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(45))
                    {
                        model.FirstSupplyNurse = oleReader["FIRST_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(46))
                    {
                        model.SecondSupplyNurse = oleReader["SECOND_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(47))
                    {
                        model.ThirdSupplyNurse = oleReader["THIRD_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(48))
                    {
                        model.FourthSupplyNurse = oleReader["FOURTH_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(49))
                    {
                        model.PacuDoctor = oleReader["PACU_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(50))
                    {
                        model.FirstPacuAssistant = oleReader["FIRST_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(51))
                    {
                        model.SecondPacuAssistant = oleReader["SECOND_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(52))
                    {
                        model.FirstPacuNurse = oleReader["FIRST_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(53))
                    {
                        model.SecondPacuNurse = oleReader["SECOND_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(54))
                    {
                        model.ReqDateTime = DateTime.Parse(oleReader["REQ_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(55))
                    {
                        model.ScheduledDateTime = DateTime.Parse(oleReader["SCHEDULED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(56))
                    {
                        model.OperPosition = oleReader["OPER_POSITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(57))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(58))
                    {
                        model.OperationName = oleReader["OPERATION_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(59))
                    {
                        model.SpecialEquipment = oleReader["SPECIAL_EQUIPMENT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(60))
                    {
                        model.SpecialInfect = oleReader["SPECIAL_INFECT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(61))
                    {
                        model.AnesConfirm = oleReader["ANES_CONFIRM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(62))
                    {
                        model.NurseConfirm = oleReader["NURSE_CONFIRM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(63))
                    {
                        model.OperStatusCode = oleReader["OPER_STATUS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(64))
                    {
                        model.NotesOnOperation = oleReader["NOTES_ON_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(65))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(66))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(67))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(68))
                    {
                        model.HisScheduleId = oleReader["HIS_SCHEDULE_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(69))
                    {
                        model.HisOperStatus = oleReader["HIS_OPER_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(70))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(71))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(72))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(73))
                    {
                        model.OperatingTime = decimal.Parse(oleReader["OPERATING_TIME"].ToString().Trim());
                    }
                }
                else
                    model = null;
            }
            return model;
        }

        public List<Model.MedOperationSchedule> SelectMedOperationScheduleOdbc(string patientId, decimal visitId)
        {
            List<Model.MedOperationSchedule> MedOperationScheduleList = new List<Model.MedOperationSchedule>();

            OdbcParameter[] OperationSchedule = GetParameterOdbc("SelectPatMedOperationSchedule");
            OperationSchedule[0].Value = patientId;
            OperationSchedule[1].Value = visitId;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_Med_Operation_Schedule_Odbc, OperationSchedule))
            {
                while (oleReader.Read())
                {
                    Model.MedOperationSchedule model = new Model.MedOperationSchedule();
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.OperDeptCode = oleReader["OPER_DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.OperRoom = oleReader["OPER_ROOM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.OperRoomNo = oleReader["OPER_ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Sequence = decimal.Parse(oleReader["SEQUENCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.OperClass = oleReader["OPER_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.DiagBeforeOperation = oleReader["DIAG_BEFORE_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.AsaGrade = oleReader["ASA_GRADE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.EmergencyInd = decimal.Parse(oleReader["EMERGENCY_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.OperSource = decimal.Parse(oleReader["OPER_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.IsolationInd = decimal.Parse(oleReader["ISOLATION_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.InfectedInd = decimal.Parse(oleReader["INFECTED_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.RadiateInd = decimal.Parse(oleReader["RADIATE_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Surgeon = oleReader["SURGEON"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.FirstOperAssistant = oleReader["FIRST_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.SecondOperAssistant = oleReader["SECOND_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.ThirdOperAssistant = oleReader["THIRD_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.FourthOperAssistant = oleReader["FOURTH_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.AnesMethod = oleReader["ANES_METHOD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.AnesDoctor = oleReader["ANES_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.FirstAnesAssistant = oleReader["FIRST_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.SecondAnesAssistant = oleReader["SECOND_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.ThirdAnesAssistant = oleReader["THIRD_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.FourthAnesAssistant = oleReader["FOURTH_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.FirstAnesNurse = oleReader["FIRST_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.SecondAnesNurse = oleReader["SECOND_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.ThirdAnesNurse = oleReader["THIRD_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.CpbDoctor = oleReader["CPB_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.FirstCpbAssistant = oleReader["FIRST_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.SecondCpbAssistant = oleReader["SECOND_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.ThirdCpbAssistant = oleReader["THIRD_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.FourthCpbAssistant = oleReader["FOURTH_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.FirstOperNurse = oleReader["FIRST_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(42))
                    {
                        model.SecondOperNurse = oleReader["SECOND_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(43))
                    {
                        model.ThirdOperNurse = oleReader["THIRD_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(44))
                    {
                        model.FourthOperNurse = oleReader["FOURTH_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(45))
                    {
                        model.FirstSupplyNurse = oleReader["FIRST_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(46))
                    {
                        model.SecondSupplyNurse = oleReader["SECOND_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(47))
                    {
                        model.ThirdSupplyNurse = oleReader["THIRD_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(48))
                    {
                        model.FourthSupplyNurse = oleReader["FOURTH_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(49))
                    {
                        model.PacuDoctor = oleReader["PACU_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(50))
                    {
                        model.FirstPacuAssistant = oleReader["FIRST_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(51))
                    {
                        model.SecondPacuAssistant = oleReader["SECOND_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(52))
                    {
                        model.FirstPacuNurse = oleReader["FIRST_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(53))
                    {
                        model.SecondPacuNurse = oleReader["SECOND_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(54))
                    {
                        model.ReqDateTime = DateTime.Parse(oleReader["REQ_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(55))
                    {
                        model.ScheduledDateTime = DateTime.Parse(oleReader["SCHEDULED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(56))
                    {
                        model.OperPosition = oleReader["OPER_POSITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(57))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(58))
                    {
                        model.OperationName = oleReader["OPERATION_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(59))
                    {
                        model.SpecialEquipment = oleReader["SPECIAL_EQUIPMENT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(60))
                    {
                        model.SpecialInfect = oleReader["SPECIAL_INFECT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(61))
                    {
                        model.AnesConfirm = oleReader["ANES_CONFIRM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(62))
                    {
                        model.NurseConfirm = oleReader["NURSE_CONFIRM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(63))
                    {
                        model.OperStatusCode = oleReader["OPER_STATUS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(64))
                    {
                        model.NotesOnOperation = oleReader["NOTES_ON_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(65))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(66))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(67))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(68))
                    {
                        model.HisScheduleId = oleReader["HIS_SCHEDULE_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(69))
                    {
                        model.HisOperStatus = oleReader["HIS_OPER_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(70))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(71))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(72))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(73))
                    {
                        model.OperatingTime = decimal.Parse(oleReader["OPERATING_TIME"].ToString().Trim());
                    }
                    MedOperationScheduleList.Add(model);
                }
            }
            return MedOperationScheduleList;
        }

        public int InsertMedOperationScheduleOdbc(Model.MedOperationSchedule model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedOperationSchedule");
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
                if (model.OperId != null)
                    oneInert[3].Value = model.OperId;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.HospBranch != null)
                    oneInert[4].Value = model.HospBranch;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneInert[5].Value = model.WardCode;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneInert[6].Value = model.DeptCode;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.OperDeptCode != null)
                    oneInert[7].Value = model.OperDeptCode;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.OperRoom != null)
                    oneInert[8].Value = model.OperRoom;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.OperRoomNo != null)
                    oneInert[9].Value = model.OperRoomNo;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.Sequence != null)
                    oneInert[10].Value = model.Sequence;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.OperClass != null)
                    oneInert[11].Value = model.OperClass;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.DiagBeforeOperation != null)
                    oneInert[12].Value = model.DiagBeforeOperation;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.PatientCondition != null)
                    oneInert[13].Value = model.PatientCondition;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.OperScale != null)
                    oneInert[14].Value = model.OperScale;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.WoundType != null)
                    oneInert[15].Value = model.WoundType;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.AsaGrade != null)
                    oneInert[16].Value = model.AsaGrade;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.EmergencyInd != null)
                    oneInert[17].Value = model.EmergencyInd;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.OperSource != null)
                    oneInert[18].Value = model.OperSource;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.IsolationInd != null)
                    oneInert[19].Value = model.IsolationInd;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.InfectedInd != null)
                    oneInert[20].Value = model.InfectedInd;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.RadiateInd != null)
                    oneInert[21].Value = model.RadiateInd;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.Surgeon != null)
                    oneInert[22].Value = model.Surgeon;
                else
                    oneInert[22].Value = DBNull.Value;
                if (model.FirstOperAssistant != null)
                    oneInert[23].Value = model.FirstOperAssistant;
                else
                    oneInert[23].Value = DBNull.Value;
                if (model.SecondOperAssistant != null)
                    oneInert[24].Value = model.SecondOperAssistant;
                else
                    oneInert[24].Value = DBNull.Value;
                if (model.ThirdOperAssistant != null)
                    oneInert[25].Value = model.ThirdOperAssistant;
                else
                    oneInert[25].Value = DBNull.Value;
                if (model.FourthOperAssistant != null)
                    oneInert[26].Value = model.FourthOperAssistant;
                else
                    oneInert[26].Value = DBNull.Value;
                if (model.AnesMethod != null)
                    oneInert[27].Value = model.AnesMethod;
                else
                    oneInert[27].Value = DBNull.Value;
                if (model.AnesDoctor != null)
                    oneInert[28].Value = model.AnesDoctor;
                else
                    oneInert[28].Value = DBNull.Value;
                if (model.FirstAnesAssistant != null)
                    oneInert[29].Value = model.FirstAnesAssistant;
                else
                    oneInert[29].Value = DBNull.Value;
                if (model.SecondAnesAssistant != null)
                    oneInert[30].Value = model.SecondAnesAssistant;
                else
                    oneInert[30].Value = DBNull.Value;
                if (model.ThirdAnesAssistant != null)
                    oneInert[31].Value = model.ThirdAnesAssistant;
                else
                    oneInert[31].Value = DBNull.Value;
                if (model.FourthAnesAssistant != null)
                    oneInert[32].Value = model.FourthAnesAssistant;
                else
                    oneInert[32].Value = DBNull.Value;
                if (model.FirstAnesNurse != null)
                    oneInert[33].Value = model.FirstAnesNurse;
                else
                    oneInert[33].Value = DBNull.Value;
                if (model.SecondAnesNurse != null)
                    oneInert[34].Value = model.SecondAnesNurse;
                else
                    oneInert[34].Value = DBNull.Value;
                if (model.ThirdAnesNurse != null)
                    oneInert[35].Value = model.ThirdAnesNurse;
                else
                    oneInert[35].Value = DBNull.Value;
                if (model.CpbDoctor != null)
                    oneInert[36].Value = model.CpbDoctor;
                else
                    oneInert[36].Value = DBNull.Value;
                if (model.FirstCpbAssistant != null)
                    oneInert[37].Value = model.FirstCpbAssistant;
                else
                    oneInert[37].Value = DBNull.Value;
                if (model.SecondCpbAssistant != null)
                    oneInert[38].Value = model.SecondCpbAssistant;
                else
                    oneInert[38].Value = DBNull.Value;
                if (model.ThirdCpbAssistant != null)
                    oneInert[39].Value = model.ThirdCpbAssistant;
                else
                    oneInert[39].Value = DBNull.Value;
                if (model.FourthCpbAssistant != null)
                    oneInert[40].Value = model.FourthCpbAssistant;
                else
                    oneInert[40].Value = DBNull.Value;
                if (model.FirstOperNurse != null)
                    oneInert[41].Value = model.FirstOperNurse;
                else
                    oneInert[41].Value = DBNull.Value;
                if (model.SecondOperNurse != null)
                    oneInert[42].Value = model.SecondOperNurse;
                else
                    oneInert[42].Value = DBNull.Value;
                if (model.ThirdOperNurse != null)
                    oneInert[43].Value = model.ThirdOperNurse;
                else
                    oneInert[43].Value = DBNull.Value;
                if (model.FourthOperNurse != null)
                    oneInert[44].Value = model.FourthOperNurse;
                else
                    oneInert[44].Value = DBNull.Value;
                if (model.FirstSupplyNurse != null)
                    oneInert[45].Value = model.FirstSupplyNurse;
                else
                    oneInert[45].Value = DBNull.Value;
                if (model.SecondSupplyNurse != null)
                    oneInert[46].Value = model.SecondSupplyNurse;
                else
                    oneInert[46].Value = DBNull.Value;
                if (model.ThirdSupplyNurse != null)
                    oneInert[47].Value = model.ThirdSupplyNurse;
                else
                    oneInert[47].Value = DBNull.Value;
                if (model.FourthSupplyNurse != null)
                    oneInert[48].Value = model.FourthSupplyNurse;
                else
                    oneInert[48].Value = DBNull.Value;
                if (model.PacuDoctor != null)
                    oneInert[49].Value = model.PacuDoctor;
                else
                    oneInert[49].Value = DBNull.Value;
                if (model.FirstPacuAssistant != null)
                    oneInert[50].Value = model.FirstPacuAssistant;
                else
                    oneInert[50].Value = DBNull.Value;
                if (model.SecondPacuAssistant != null)
                    oneInert[51].Value = model.SecondPacuAssistant;
                else
                    oneInert[51].Value = DBNull.Value;
                if (model.FirstPacuNurse != null)
                    oneInert[52].Value = model.FirstPacuNurse;
                else
                    oneInert[52].Value = DBNull.Value;
                if (model.SecondPacuNurse != null)
                    oneInert[53].Value = model.SecondPacuNurse;
                else
                    oneInert[53].Value = DBNull.Value;
                if (model.ReqDateTime != null)
                    oneInert[54].Value = model.ReqDateTime;
                else
                    oneInert[54].Value = DBNull.Value;
                if (model.ScheduledDateTime != null)
                    oneInert[55].Value = model.ScheduledDateTime;
                else
                    oneInert[55].Value = DBNull.Value;
                if (model.OperPosition != null)
                    oneInert[56].Value = model.OperPosition;
                else
                    oneInert[56].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneInert[57].Value = model.BedNo;
                else
                    oneInert[57].Value = DBNull.Value;
                if (model.OperationName != null)
                    oneInert[58].Value = model.OperationName;
                else
                    oneInert[58].Value = DBNull.Value;
                if (model.SpecialEquipment != null)
                    oneInert[59].Value = model.SpecialEquipment;
                else
                    oneInert[59].Value = DBNull.Value;
                if (model.SpecialInfect != null)
                    oneInert[60].Value = model.SpecialInfect;
                else
                    oneInert[60].Value = DBNull.Value;
                if (model.AnesConfirm != null)
                    oneInert[61].Value = model.AnesConfirm;
                else
                    oneInert[61].Value = DBNull.Value;
                if (model.NurseConfirm != null)
                    oneInert[62].Value = model.NurseConfirm;
                else
                    oneInert[62].Value = DBNull.Value;
                if (model.OperStatusCode != null)
                    oneInert[63].Value = model.OperStatusCode;
                else
                    oneInert[63].Value = DBNull.Value;
                if (model.NotesOnOperation != null)
                    oneInert[64].Value = model.NotesOnOperation;
                else
                    oneInert[64].Value = DBNull.Value;
                if (model.Operator != null)
                    oneInert[65].Value = model.Operator;
                else
                    oneInert[65].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneInert[66].Value = model.HisPatientId;
                else
                    oneInert[66].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneInert[67].Value = model.HisVisitId;
                else
                    oneInert[67].Value = DBNull.Value;
                if (model.HisScheduleId != null)
                    oneInert[68].Value = model.HisScheduleId;
                else
                    oneInert[68].Value = DBNull.Value;
                if (model.HisOperStatus != null)
                    oneInert[69].Value = model.HisOperStatus;
                else
                    oneInert[69].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneInert[70].Value = model.Reserved1;
                else
                    oneInert[70].Value = DBNull.Value;
                if (model.Reserved2 != null)
                    oneInert[71].Value = model.Reserved2;
                else
                    oneInert[71].Value = DBNull.Value;
                if (model.Reserved3 != null)
                    oneInert[72].Value = model.Reserved3;
                else
                    oneInert[72].Value = DBNull.Value;
                if (model.OperatingTime != null)
                    oneInert[73].Value = model.OperatingTime;
                else
                    oneInert[73].Value = DBNull.Value;
                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_ODBC, oneInert);
            }
        }

        public int UpdateMedOperationScheduleOdbc(Model.MedOperationSchedule model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedOperationSchedule");

                if (model.OperId != null)
                    oneUpdate[0].Value = model.OperId;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.HospBranch != null)
                    oneUpdate[1].Value = model.HospBranch;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneUpdate[2].Value = model.WardCode;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneUpdate[3].Value = model.DeptCode;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.OperDeptCode != null)
                    oneUpdate[4].Value = model.OperDeptCode;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.OperRoom != null)
                    oneUpdate[5].Value = model.OperRoom;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.OperRoomNo != null)
                    oneUpdate[6].Value = model.OperRoomNo;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.Sequence != null)
                    oneUpdate[7].Value = model.Sequence;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.OperClass != null)
                    oneUpdate[8].Value = model.OperClass;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.DiagBeforeOperation != null)
                    oneUpdate[9].Value = model.DiagBeforeOperation;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.PatientCondition != null)
                    oneUpdate[10].Value = model.PatientCondition;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.OperScale != null)
                    oneUpdate[11].Value = model.OperScale;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.WoundType != null)
                    oneUpdate[12].Value = model.WoundType;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.AsaGrade != null)
                    oneUpdate[13].Value = model.AsaGrade;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.EmergencyInd != null)
                    oneUpdate[14].Value = model.EmergencyInd;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.OperSource != null)
                    oneUpdate[15].Value = model.OperSource;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.IsolationInd != null)
                    oneUpdate[16].Value = model.IsolationInd;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.InfectedInd != null)
                    oneUpdate[17].Value = model.InfectedInd;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.RadiateInd != null)
                    oneUpdate[18].Value = model.RadiateInd;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.Surgeon != null)
                    oneUpdate[19].Value = model.Surgeon;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.FirstOperAssistant != null)
                    oneUpdate[20].Value = model.FirstOperAssistant;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.SecondOperAssistant != null)
                    oneUpdate[21].Value = model.SecondOperAssistant;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.ThirdOperAssistant != null)
                    oneUpdate[22].Value = model.ThirdOperAssistant;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.FourthOperAssistant != null)
                    oneUpdate[23].Value = model.FourthOperAssistant;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.AnesMethod != null)
                    oneUpdate[24].Value = model.AnesMethod;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.AnesDoctor != null)
                    oneUpdate[25].Value = model.AnesDoctor;
                else
                    oneUpdate[25].Value = DBNull.Value;
                if (model.FirstAnesAssistant != null)
                    oneUpdate[26].Value = model.FirstAnesAssistant;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (model.SecondAnesAssistant != null)
                    oneUpdate[27].Value = model.SecondAnesAssistant;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (model.ThirdAnesAssistant != null)
                    oneUpdate[28].Value = model.ThirdAnesAssistant;
                else
                    oneUpdate[28].Value = DBNull.Value;
                if (model.FourthAnesAssistant != null)
                    oneUpdate[29].Value = model.FourthAnesAssistant;
                else
                    oneUpdate[29].Value = DBNull.Value;
                if (model.FirstAnesNurse != null)
                    oneUpdate[30].Value = model.FirstAnesNurse;
                else
                    oneUpdate[30].Value = DBNull.Value;
                if (model.SecondAnesNurse != null)
                    oneUpdate[31].Value = model.SecondAnesNurse;
                else
                    oneUpdate[31].Value = DBNull.Value;
                if (model.ThirdAnesNurse != null)
                    oneUpdate[32].Value = model.ThirdAnesNurse;
                else
                    oneUpdate[32].Value = DBNull.Value;
                if (model.CpbDoctor != null)
                    oneUpdate[33].Value = model.CpbDoctor;
                else
                    oneUpdate[33].Value = DBNull.Value;
                if (model.FirstCpbAssistant != null)
                    oneUpdate[34].Value = model.FirstCpbAssistant;
                else
                    oneUpdate[34].Value = DBNull.Value;
                if (model.SecondCpbAssistant != null)
                    oneUpdate[35].Value = model.SecondCpbAssistant;
                else
                    oneUpdate[35].Value = DBNull.Value;
                if (model.ThirdCpbAssistant != null)
                    oneUpdate[36].Value = model.ThirdCpbAssistant;
                else
                    oneUpdate[36].Value = DBNull.Value;
                if (model.FourthCpbAssistant != null)
                    oneUpdate[37].Value = model.FourthCpbAssistant;
                else
                    oneUpdate[37].Value = DBNull.Value;
                if (model.FirstOperNurse != null)
                    oneUpdate[38].Value = model.FirstOperNurse;
                else
                    oneUpdate[38].Value = DBNull.Value;
                if (model.SecondOperNurse != null)
                    oneUpdate[39].Value = model.SecondOperNurse;
                else
                    oneUpdate[39].Value = DBNull.Value;
                if (model.ThirdOperNurse != null)
                    oneUpdate[40].Value = model.ThirdOperNurse;
                else
                    oneUpdate[40].Value = DBNull.Value;
                if (model.FourthOperNurse != null)
                    oneUpdate[41].Value = model.FourthOperNurse;
                else
                    oneUpdate[41].Value = DBNull.Value;
                if (model.FirstSupplyNurse != null)
                    oneUpdate[42].Value = model.FirstSupplyNurse;
                else
                    oneUpdate[42].Value = DBNull.Value;
                if (model.SecondSupplyNurse != null)
                    oneUpdate[43].Value = model.SecondSupplyNurse;
                else
                    oneUpdate[43].Value = DBNull.Value;
                if (model.ThirdSupplyNurse != null)
                    oneUpdate[44].Value = model.ThirdSupplyNurse;
                else
                    oneUpdate[44].Value = DBNull.Value;
                if (model.FourthSupplyNurse != null)
                    oneUpdate[45].Value = model.FourthSupplyNurse;
                else
                    oneUpdate[45].Value = DBNull.Value;
                if (model.PacuDoctor != null)
                    oneUpdate[46].Value = model.PacuDoctor;
                else
                    oneUpdate[46].Value = DBNull.Value;
                if (model.FirstPacuAssistant != null)
                    oneUpdate[47].Value = model.FirstPacuAssistant;
                else
                    oneUpdate[47].Value = DBNull.Value;
                if (model.SecondPacuAssistant != null)
                    oneUpdate[48].Value = model.SecondPacuAssistant;
                else
                    oneUpdate[48].Value = DBNull.Value;
                if (model.FirstPacuNurse != null)
                    oneUpdate[49].Value = model.FirstPacuNurse;
                else
                    oneUpdate[49].Value = DBNull.Value;
                if (model.SecondPacuNurse != null)
                    oneUpdate[50].Value = model.SecondPacuNurse;
                else
                    oneUpdate[50].Value = DBNull.Value;
                if (model.ReqDateTime != null)
                    oneUpdate[51].Value = model.ReqDateTime;
                else
                    oneUpdate[51].Value = DBNull.Value;
                if (model.ScheduledDateTime != null)
                    oneUpdate[52].Value = model.ScheduledDateTime;
                else
                    oneUpdate[52].Value = DBNull.Value;
                if (model.OperPosition != null)
                    oneUpdate[53].Value = model.OperPosition;
                else
                    oneUpdate[53].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneUpdate[54].Value = model.BedNo;
                else
                    oneUpdate[54].Value = DBNull.Value;
                if (model.OperationName != null)
                    oneUpdate[55].Value = model.OperationName;
                else
                    oneUpdate[55].Value = DBNull.Value;
                if (model.SpecialEquipment != null)
                    oneUpdate[56].Value = model.SpecialEquipment;
                else
                    oneUpdate[56].Value = DBNull.Value;
                if (model.SpecialInfect != null)
                    oneUpdate[57].Value = model.SpecialInfect;
                else
                    oneUpdate[57].Value = DBNull.Value;
                if (model.AnesConfirm != null)
                    oneUpdate[58].Value = model.AnesConfirm;
                else
                    oneUpdate[58].Value = DBNull.Value;
                if (model.NurseConfirm != null)
                    oneUpdate[59].Value = model.NurseConfirm;
                else
                    oneUpdate[59].Value = DBNull.Value;
                if (model.OperStatusCode != null)
                    oneUpdate[60].Value = model.OperStatusCode;
                else
                    oneUpdate[60].Value = DBNull.Value;
                if (model.NotesOnOperation != null)
                    oneUpdate[61].Value = model.NotesOnOperation;
                else
                    oneUpdate[61].Value = DBNull.Value;
                if (model.Operator != null)
                    oneUpdate[62].Value = model.Operator;
                else
                    oneUpdate[62].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneUpdate[63].Value = model.HisPatientId;
                else
                    oneUpdate[63].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneUpdate[64].Value = model.HisVisitId;
                else
                    oneUpdate[64].Value = DBNull.Value;
                if (model.HisScheduleId != null)
                    oneUpdate[65].Value = model.HisScheduleId;
                else
                    oneUpdate[65].Value = DBNull.Value;
                if (model.HisOperStatus != null)
                    oneUpdate[66].Value = model.HisOperStatus;
                else
                    oneUpdate[66].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneUpdate[67].Value = model.Reserved1;
                else
                    oneUpdate[67].Value = DBNull.Value;
                if (model.Reserved2 != null)
                    oneUpdate[68].Value = model.Reserved2;
                else
                    oneUpdate[68].Value = DBNull.Value;
                if (model.Reserved3 != null)
                    oneUpdate[69].Value = model.Reserved3;
                else
                    oneUpdate[69].Value = DBNull.Value;
                if (model.OperatingTime != null)
                    oneUpdate[70].Value = model.OperatingTime;
                else
                    oneUpdate[70].Value = DBNull.Value;

                if (model.PatientId != null)
                    oneUpdate[71].Value = model.PatientId;
                else
                    oneUpdate[71].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneUpdate[72].Value = model.VisitId;
                else
                    oneUpdate[72].Value = DBNull.Value;
                if (model.ScheduleId != null)
                    oneUpdate[73].Value = model.ScheduleId;
                else
                    oneUpdate[73].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_ODBC, oneUpdate);
            }
        }

        public int DeleteMedOperationScheduleOdbc(string PatientId, decimal VisitId, decimal ScheduleId)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterOdbc("DeleteMedOperationSchedule");
                oneDelete[0].Value = PatientId;
                oneDelete[1].Value = VisitId;
                oneDelete[2].Value = ScheduleId;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Delete_MedOperationSchedule_Odbc, oneDelete);
            }
        }
    }
}
