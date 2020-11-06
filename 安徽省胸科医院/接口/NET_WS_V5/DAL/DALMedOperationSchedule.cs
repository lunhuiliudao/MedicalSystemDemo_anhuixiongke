

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 21:47:09
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
namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedOperationSchedule
	/// </summary>
	
	public partial class DALMedOperationSchedule
	{

        private static string Select="select PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME from MED_OPERATION_SCHEDULE WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND SCHEDULE_ID=:ScheduleId";


        private static string Update="Update MED_OPERATION_SCHEDULE set OPER_ID=:OperId,HOSP_BRANCH=:HospBranch,WARD_CODE=:WardCode,DEPT_CODE=:DeptCode,OPER_DEPT_CODE=:OperDeptCode,OPER_ROOM=:OperRoom,OPER_ROOM_NO=:OperRoomNo,SEQUENCE=:Sequence,OPER_CLASS=:OperClass,DIAG_BEFORE_OPERATION=:DiagBeforeOperation,PATIENT_CONDITION=:PatientCondition,OPER_SCALE=:OperScale,WOUND_TYPE=:WoundType,ASA_GRADE=:AsaGrade,EMERGENCY_IND=:EmergencyInd,OPER_SOURCE=:OperSource,ISOLATION_IND=:IsolationInd,INFECTED_IND=:InfectedInd,RADIATE_IND=:RadiateInd,SURGEON=:Surgeon,FIRST_OPER_ASSISTANT=:FirstOperAssistant,SECOND_OPER_ASSISTANT=:SecondOperAssistant,THIRD_OPER_ASSISTANT=:ThirdOperAssistant,FOURTH_OPER_ASSISTANT=:FourthOperAssistant,ANES_METHOD=:AnesMethod,ANES_DOCTOR=:AnesDoctor,FIRST_ANES_ASSISTANT=:FirstAnesAssistant,SECOND_ANES_ASSISTANT=:SecondAnesAssistant,THIRD_ANES_ASSISTANT=:ThirdAnesAssistant,FOURTH_ANES_ASSISTANT=:FourthAnesAssistant,FIRST_ANES_NURSE=:FirstAnesNurse,SECOND_ANES_NURSE=:SecondAnesNurse,THIRD_ANES_NURSE=:ThirdAnesNurse,CPB_DOCTOR=:CpbDoctor,FIRST_CPB_ASSISTANT=:FirstCpbAssistant,SECOND_CPB_ASSISTANT=:SecondCpbAssistant,THIRD_CPB_ASSISTANT=:ThirdCpbAssistant,FOURTH_CPB_ASSISTANT=:FourthCpbAssistant,FIRST_OPER_NURSE=:FirstOperNurse,SECOND_OPER_NURSE=:SecondOperNurse,THIRD_OPER_NURSE=:ThirdOperNurse,FOURTH_OPER_NURSE=:FourthOperNurse,FIRST_SUPPLY_NURSE=:FirstSupplyNurse,SECOND_SUPPLY_NURSE=:SecondSupplyNurse,THIRD_SUPPLY_NURSE=:ThirdSupplyNurse,FOURTH_SUPPLY_NURSE=:FourthSupplyNurse,PACU_DOCTOR=:PacuDoctor,FIRST_PACU_ASSISTANT=:FirstPacuAssistant,SECOND_PACU_ASSISTANT=:SecondPacuAssistant,FIRST_PACU_NURSE=:FirstPacuNurse,SECOND_PACU_NURSE=:SecondPacuNurse,REQ_DATE_TIME=:ReqDateTime,SCHEDULED_DATE_TIME=:ScheduledDateTime,OPER_POSITION=:OperPosition,BED_NO=:BedNo,OPERATION_NAME=:OperationName,SPECIAL_EQUIPMENT=:SpecialEquipment,SPECIAL_INFECT=:SpecialInfect,ANES_CONFIRM=:AnesConfirm,NURSE_CONFIRM=:NurseConfirm,OPER_STATUS_CODE=:OperStatusCode,NOTES_ON_OPERATION=:NotesOnOperation,OPERATOR=:Operator,HIS_PATIENT_ID=:HisPatientId,HIS_VISIT_ID=:HisVisitId,HIS_SCHEDULE_ID=:HisScheduleId,HIS_OPER_STATUS=:HisOperStatus,RESERVED1=:Reserved1,RESERVED2=:Reserved2,RESERVED3=:Reserved3,OPERATING_TIME=:OperatingTime where PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND SCHEDULE_ID=:ScheduleId";
         

        private static string Insert = "Insert into MED_OPERATION_SCHEDULE  (PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME) values(:PatientId,:VisitId,:ScheduleId,:OperId,:HospBranch,:WardCode,:DeptCode,:OperDeptCode,:OperRoom,:OperRoomNo,:Sequence,:OperClass,:DiagBeforeOperation,:PatientCondition,:OperScale,:WoundType,:AsaGrade,:EmergencyInd,:OperSource,:IsolationInd,:InfectedInd,:RadiateInd,:Surgeon,:FirstOperAssistant,:SecondOperAssistant,:ThirdOperAssistant,:FourthOperAssistant,:AnesMethod,:AnesDoctor,:FirstAnesAssistant,:SecondAnesAssistant,:ThirdAnesAssistant,:FourthAnesAssistant,:FirstAnesNurse,:SecondAnesNurse,:ThirdAnesNurse,:CpbDoctor,:FirstCpbAssistant,:SecondCpbAssistant,:ThirdCpbAssistant,:FourthCpbAssistant,:FirstOperNurse,:SecondOperNurse,:ThirdOperNurse,:FourthOperNurse,:FirstSupplyNurse,:SecondSupplyNurse,:ThirdSupplyNurse,:FourthSupplyNurse,:PacuDoctor,:FirstPacuAssistant,:SecondPacuAssistant,:FirstPacuNurse,:SecondPacuNurse,:ReqDateTime,:ScheduledDateTime,:OperPosition,:BedNo,:OperationName,:SpecialEquipment,:SpecialInfect,:AnesConfirm,:NurseConfirm,:OperStatusCode,:NotesOnOperation,:Operator,:HisPatientId,:HisVisitId,:HisScheduleId,:HisOperStatus,:Reserved1,:Reserved2,:Reserved3,:OperatingTime)";


        private static string Select_SQL = "select PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME from MED_OPERATION_SCHEDULE WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND SCHEDULE_ID=@ScheduleId";


        private static string Update_SQL = "Update MED_OPERATION_SCHEDULE set OPER_ID=@OperId,HOSP_BRANCH=@HospBranch,WARD_CODE=@WardCode,DEPT_CODE=@DeptCode,OPER_DEPT_CODE=@OperDeptCode,OPER_ROOM=@OperRoom,OPER_ROOM_NO=@OperRoomNo,SEQUENCE=@Sequence,OPER_CLASS=@OperClass,DIAG_BEFORE_OPERATION=@DiagBeforeOperation,PATIENT_CONDITION=@PatientCondition,OPER_SCALE=@OperScale,WOUND_TYPE=@WoundType,ASA_GRADE=@AsaGrade,EMERGENCY_IND=@EmergencyInd,OPER_SOURCE=@OperSource,ISOLATION_IND=@IsolationInd,INFECTED_IND=@InfectedInd,RADIATE_IND=@RadiateInd,SURGEON=@Surgeon,FIRST_OPER_ASSISTANT=@FirstOperAssistant,SECOND_OPER_ASSISTANT=@SecondOperAssistant,THIRD_OPER_ASSISTANT=@ThirdOperAssistant,FOURTH_OPER_ASSISTANT=@FourthOperAssistant,ANES_METHOD=@AnesMethod,ANES_DOCTOR=@AnesDoctor,FIRST_ANES_ASSISTANT=@FirstAnesAssistant,SECOND_ANES_ASSISTANT=@SecondAnesAssistant,THIRD_ANES_ASSISTANT=@ThirdAnesAssistant,FOURTH_ANES_ASSISTANT=@FourthAnesAssistant,FIRST_ANES_NURSE=@FirstAnesNurse,SECOND_ANES_NURSE=@SecondAnesNurse,THIRD_ANES_NURSE=@ThirdAnesNurse,CPB_DOCTOR=@CpbDoctor,FIRST_CPB_ASSISTANT=@FirstCpbAssistant,SECOND_CPB_ASSISTANT=@SecondCpbAssistant,THIRD_CPB_ASSISTANT=@ThirdCpbAssistant,FOURTH_CPB_ASSISTANT=@FourthCpbAssistant,FIRST_OPER_NURSE=@FirstOperNurse,SECOND_OPER_NURSE=@SecondOperNurse,THIRD_OPER_NURSE=@ThirdOperNurse,FOURTH_OPER_NURSE=@FourthOperNurse,FIRST_SUPPLY_NURSE=@FirstSupplyNurse,SECOND_SUPPLY_NURSE=@SecondSupplyNurse,THIRD_SUPPLY_NURSE=@ThirdSupplyNurse,FOURTH_SUPPLY_NURSE=@FourthSupplyNurse,PACU_DOCTOR=@PacuDoctor,FIRST_PACU_ASSISTANT=@FirstPacuAssistant,SECOND_PACU_ASSISTANT=@SecondPacuAssistant,FIRST_PACU_NURSE=@FirstPacuNurse,SECOND_PACU_NURSE=@SecondPacuNurse,REQ_DATE_TIME=@ReqDateTime,SCHEDULED_DATE_TIME=@ScheduledDateTime,OPER_POSITION=@OperPosition,BED_NO=@BedNo,OPERATION_NAME=@OperationName,SPECIAL_EQUIPMENT=@SpecialEquipment,SPECIAL_INFECT=@SpecialInfect,ANES_CONFIRM=@AnesConfirm,NURSE_CONFIRM=@NurseConfirm,OPER_STATUS_CODE=@OperStatusCode,NOTES_ON_OPERATION=@NotesOnOperation,OPERATOR=@Operator,HIS_PATIENT_ID=@HisPatientId,HIS_VISIT_ID=@HisVisitId,HIS_SCHEDULE_ID=@HisScheduleId,HIS_OPER_STATUS=@HisOperStatus,RESERVED1=@Reserved1,RESERVED2=@Reserved2,RESERVED3=@Reserved3,OPERATING_TIME=@OperatingTime where PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND SCHEDULE_ID=@ScheduleId";


        private static string Insert_SQL = "Insert into MED_OPERATION_SCHEDULE  (PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME) values(@PatientId,@VisitId,@ScheduleId,@OperId,@HospBranch,@WardCode,@DeptCode,@OperDeptCode,@OperRoom,@OperRoomNo,@Sequence,@OperClass,@DiagBeforeOperation,@PatientCondition,@OperScale,@WoundType,@AsaGrade,@EmergencyInd,@OperSource,@IsolationInd,@InfectedInd,@RadiateInd,@Surgeon,@FirstOperAssistant,@SecondOperAssistant,@ThirdOperAssistant,@FourthOperAssistant,@AnesMethod,@AnesDoctor,@FirstAnesAssistant,@SecondAnesAssistant,@ThirdAnesAssistant,@FourthAnesAssistant,@FirstAnesNurse,@SecondAnesNurse,@ThirdAnesNurse,@CpbDoctor,@FirstCpbAssistant,@SecondCpbAssistant,@ThirdCpbAssistant,@FourthCpbAssistant,@FirstOperNurse,@SecondOperNurse,@ThirdOperNurse,@FourthOperNurse,@FirstSupplyNurse,@SecondSupplyNurse,@ThirdSupplyNurse,@FourthSupplyNurse,@PacuDoctor,@FirstPacuAssistant,@SecondPacuAssistant,@FirstPacuNurse,@SecondPacuNurse,@ReqDateTime,@ScheduledDateTime,@OperPosition,@BedNo,@OperationName,@SpecialEquipment,@SpecialInfect,@AnesConfirm,@NurseConfirm,@OperStatusCode,@NotesOnOperation,@Operator,@HisPatientId,@HisVisitId,@HisScheduleId,@HisOperStatus,@Reserved1,@Reserved2,@Reserved3,@OperatingTime)";





        //新增OPERATION_POSITION, SPECIAL_EQUIPMENT,SPECIAL_INFECT
        private static readonly string MED_OPERATION_SCHEDULE_Select_Max_ScheduleId_SQL = "select isnull(max(SCHEDULE_ID),0) from MED_OPERATION_SCHEDULE where PATIENT_ID = @patientId and VISIT_ID = @visitId";
        private static readonly string MED_OPERATION_SCHEDULE_Select_Count_SQL = "Select count(*) from MED_OPERATION_SCHEDULE where PATIENT_ID = @patientId and visit_id = @visitId and SCHEDULE_ID = @scheduleId ";
        //private static readonly string MED_OPERATION_SCHEDULE_Insert_SQL = "INSERT INTO MED_OPERATION_SCHEDULE (PATIENT_ID,VISIT_ID,SCHEDULE_ID,DEPT_STAYED,BED_NO,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,FIRST_OPERATION_NURSE,SECOND_OPERATION_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,NOTES_ON_OPERATION,ENTERED_BY,REQ_DATE_TIME,THIRD_SUPPLY_NURSE,ACK_INDICATOR,EMERGENCY_INDICATOR,RECK_GROUP,OPER_ID,SECOND_ANESTHESIA_ASSISTANT,THIRD_ANESTHESIA_ASSISTANT,FOURTH_ANESTHESIA_ASSISTANT,SECOND_ANESTHESIA_DOCTOR,THIRD_ANESTHESIA_DOCTOR,RESERVED1,RESERVED2,OPERATION_POSITION,SPECIAL_EQUIPMENT,SPECIAL_INFECT,HEPATITIS_INDICATOR,OPERATION_ID,RESERVED3,RESERVED4,RESERVED5,RESERVED6,RESERVED7,RESERVED8,RESERVED9,RESERVED10,RESERVED11,RESERVED12,STATE,OPERATION_NAME,Third_Operation_Nurse) values (@PatientId,@VisitId,@ScheduleId,@DeptStayed,@BedNo,@ScheduledDateTime,@OperatingRoom,@OperatingRoomNo,@Sequence,@DiagBeforeOperation,@PatientCondition,@OperationScale,@IsolationIndicator,@OperatingDept,@Surgeon,@FirstAssistant,@SecondAssistant,@ThirdAssistant,@FourthAssistant,@AnesthesiaMethod,@AnesthesiaDoctor,@AnesthesiaAssistant,@BloodTranDoctor,@FirstOperationNurse,@SecondOperationNurse,@FirstSupplyNurse,@SecondSupplyNurse,@NotesOnOperation,@EnteredBy,@ReqDateTime,@ThirdSupplyNurse,@AckIndicator,@EmergencyIndicator,@ReckGroup,@OperId,@SecondAnesthesiaAssistant,@ThirdAnesthesiaAssistant,@FourthAnesthesiaAssistant,@SecondAnesthesiaDoctor,@ThirdAnesthesiaDoctor,@Reserved1,@Reserved2,@OperationPosition,@SpecialEquipment,@SpecialInfect,@HepatitisIndicator,@OperationId,@Reserved3,@Reserved4,@Reserved5,@Reserved6,@Reserved7,@Reserved8,@Reserved9,@Reserved10,@Reserved11,@Reserved12,@State,@OperationName,@ThirdOperationNurse)";
       // private static readonly string MED_OPERATION_SCHEDULE_Update_SQL = "UPDATE MED_OPERATION_SCHEDULE SET PATIENT_ID=@PatientId,VISIT_ID=@VisitId,SCHEDULE_ID=@ScheduleId,DEPT_STAYED=@DeptStayed,BED_NO=@BedNo,SCHEDULED_DATE_TIME=@ScheduledDateTime,OPERATING_ROOM=@OperatingRoom,OPERATING_ROOM_NO=@OperatingRoomNo,SEQUENCE=@Sequence,DIAG_BEFORE_OPERATION=@DiagBeforeOperation,PATIENT_CONDITION=@PatientCondition,OPERATION_SCALE=@OperationScale,ISOLATION_INDICATOR=@IsolationIndicator,OPERATING_DEPT=@OperatingDept,SURGEON=@Surgeon,FIRST_ASSISTANT=@FirstAssistant,SECOND_ASSISTANT=@SecondAssistant,THIRD_ASSISTANT=@ThirdAssistant,FOURTH_ASSISTANT=@FourthAssistant,ANESTHESIA_METHOD=@AnesthesiaMethod,ANESTHESIA_DOCTOR=@AnesthesiaDoctor,ANESTHESIA_ASSISTANT=@AnesthesiaAssistant,BLOOD_TRAN_DOCTOR=@BloodTranDoctor,FIRST_OPERATION_NURSE=@FirstOperationNurse,SECOND_OPERATION_NURSE=@SecondOperationNurse,FIRST_SUPPLY_NURSE=@FirstSupplyNurse,SECOND_SUPPLY_NURSE=@SecondSupplyNurse,NOTES_ON_OPERATION=@NotesOnOperation,ENTERED_BY=@EnteredBy,REQ_DATE_TIME=@ReqDateTime,THIRD_SUPPLY_NURSE=@ThirdSupplyNurse,ACK_INDICATOR=@AckIndicator,EMERGENCY_INDICATOR=@EmergencyIndicator,RECK_GROUP=@ReckGroup,OPER_ID=@OperId,SECOND_ANESTHESIA_ASSISTANT=@SecondAnesthesiaAssistant,THIRD_ANESTHESIA_ASSISTANT=@ThirdAnesthesiaAssistant,FOURTH_ANESTHESIA_ASSISTANT=@FourthAnesthesiaAssistant,SECOND_ANESTHESIA_DOCTOR=@SecondAnesthesiaDoctor,THIRD_ANESTHESIA_DOCTOR=@ThirdAnesthesiaDoctor,RESERVED1=@Reserved1,RESERVED2=@Reserved2,OPERATION_POSITION=@OperationPosition,SPECIAL_EQUIPMENT=@SpecialEquipment,SPECIAL_INFECT=@SpecialInfect,HEPATITIS_INDICATOR=@HepatitisIndicator,OPERATION_ID=@OperationId,RESERVED3=@Reserved3,RESERVED4=@Reserved4,RESERVED5=@Reserved5,RESERVED6=@Reserved6,RESERVED7=@Reserved7,RESERVED8=@Reserved8,RESERVED9=@Reserved9,RESERVED10=@Reserved10,RESERVED11=@Reserved11,RESERVED12=@Reserved12,STATE=@State,Operation_Name=@OperationName,Third_Operation_Nurse=@ThirdOperationNurse WHERE PATIENT_ID=@PatientIdP AND VISIT_ID=@VisitIdP AND SCHEDULE_ID=@ScheduleIdP";
        private static readonly string MED_OPERATION_SCHEDULE_Delete_SQL = "Delete MED_OPERATION_SCHEDULE WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND SCHEDULE_ID=@ScheduleId";
        private static readonly string MED_OPERATION_SCHEDULE_Select_SQL = "SELECT PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME   FROM MED_OPERATION_SCHEDULE where PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND SCHEDULE_ID=@ScheduleId";
        private static readonly string MED_OPERATION_SCHEDULE_Select_ALL_SQL = "SELECT  PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME  FROM MED_OPERATION_SCHEDULE";
        //2013-4-18 孙凯增加
        private static readonly string MED_OPERATION_SCHEDULE_Select_OperId_SQL = "SELECT   PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME   FROM MED_OPERATION_SCHEDULE where PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND oper_id=@OperId";
        private static readonly string MED_OPERATION_SCHEDULE_Select_Max_ScheduleId = "select nvl(max(SCHEDULE_ID),0) from MED_OPERATION_SCHEDULE where patient_id = :patientId and visit_id = :visitId";
        private static readonly string MED_OPERATION_SCHEDULE_Select_Count = "Select count(*) from MED_OPERATION_SCHEDULE where patient_id = :patientId and visit_id = :visitId and schedule_id = :scheduleId ";
        //  private static readonly string MED_OPERATION_SCHEDULE_Insert = "INSERT INTO MED_OPERATION_SCHEDULE (PATIENT_ID,VISIT_ID,SCHEDULE_ID,DEPT_STAYED,BED_NO,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,FIRST_OPERATION_NURSE,SECOND_OPERATION_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,NOTES_ON_OPERATION,ENTERED_BY,REQ_DATE_TIME,THIRD_SUPPLY_NURSE,ACK_INDICATOR,EMERGENCY_INDICATOR,RECK_GROUP,OPER_ID,SECOND_ANESTHESIA_ASSISTANT,THIRD_ANESTHESIA_ASSISTANT,FOURTH_ANESTHESIA_ASSISTANT,SECOND_ANESTHESIA_DOCTOR,THIRD_ANESTHESIA_DOCTOR,RESERVED1,RESERVED2,OPERATION_POSITION,SPECIAL_EQUIPMENT,SPECIAL_INFECT,HEPATITIS_INDICATOR,OPERATION_ID,RESERVED3,RESERVED4,RESERVED5,RESERVED6,RESERVED7,RESERVED8,RESERVED9,RESERVED10,RESERVED11,RESERVED12,STATE,OPERATION_NAME,Third_Operation_Nurse) values (:PatientId,:VisitId,:ScheduleId,:DeptStayed,:BedNo,:ScheduledDateTime,:OperatingRoom,:OperatingRoomNo,:Sequence,:DiagBeforeOperation,:PatientCondition,:OperationScale,:IsolationIndicator,:OperatingDept,:Surgeon,:FirstAssistant,:SecondAssistant,:ThirdAssistant,:FourthAssistant,:AnesthesiaMethod,:AnesthesiaDoctor,:AnesthesiaAssistant,:BloodTranDoctor,:FirstOperationNurse,:SecondOperationNurse,:FirstSupplyNurse,:SecondSupplyNurse,:NotesOnOperation,:EnteredBy,:ReqDateTime,:ThirdSupplyNurse,:AckIndicator,:EmergencyIndicator,:ReckGroup,:OperId,:SecondAnesthesiaAssistant,:ThirdAnesthesiaAssistant,:FourthAnesthesiaAssistant,:SecondAnesthesiaDoctor,:ThirdAnesthesiaDoctor,:Reserved1,:Reserved2,:OperationPosition,:SpecialEquipment,:SpecialInfect,:HepatitisIndicator,:OperationId,:Reserved3,:Reserved4,:Reserved5,:Reserved6,:Reserved7,:Reserved8,:Reserved9,:Reserved10,:Reserved11,:Reserved12,:State,:OperationName,:ThirdOperationNurse)";
        //  private static readonly string MED_OPERATION_SCHEDULE_Update = "UPDATE MED_OPERATION_SCHEDULE SET PATIENT_ID=:PatientId,VISIT_ID=:VisitId,SCHEDULE_ID=:ScheduleId,DEPT_STAYED=:DeptStayed,BED_NO=:BedNo,SCHEDULED_DATE_TIME=:ScheduledDateTime,OPERATING_ROOM=:OperatingRoom,OPERATING_ROOM_NO=:OperatingRoomNo,SEQUENCE=:Sequence,DIAG_BEFORE_OPERATION=:DiagBeforeOperation,PATIENT_CONDITION=:PatientCondition,OPERATION_SCALE=:OperationScale,ISOLATION_INDICATOR=:IsolationIndicator,OPERATING_DEPT=:OperatingDept,SURGEON=:Surgeon,FIRST_ASSISTANT=:FirstAssistant,SECOND_ASSISTANT=:SecondAssistant,THIRD_ASSISTANT=:ThirdAssistant,FOURTH_ASSISTANT=:FourthAssistant,ANESTHESIA_METHOD=:AnesthesiaMethod,ANESTHESIA_DOCTOR=:AnesthesiaDoctor,ANESTHESIA_ASSISTANT=:AnesthesiaAssistant,BLOOD_TRAN_DOCTOR=:BloodTranDoctor,FIRST_OPERATION_NURSE=:FirstOperationNurse,SECOND_OPERATION_NURSE=:SecondOperationNurse,FIRST_SUPPLY_NURSE=:FirstSupplyNurse,SECOND_SUPPLY_NURSE=:SecondSupplyNurse,NOTES_ON_OPERATION=:NotesOnOperation,ENTERED_BY=:EnteredBy,REQ_DATE_TIME=:ReqDateTime,THIRD_SUPPLY_NURSE=:ThirdSupplyNurse,ACK_INDICATOR=:AckIndicator,EMERGENCY_INDICATOR=:EmergencyIndicator,RECK_GROUP=:ReckGroup,OPER_ID=:OperId,SECOND_ANESTHESIA_ASSISTANT=:SecondAnesthesiaAssistant,THIRD_ANESTHESIA_ASSISTANT=:ThirdAnesthesiaAssistant,FOURTH_ANESTHESIA_ASSISTANT=:FourthAnesthesiaAssistant,SECOND_ANESTHESIA_DOCTOR=:SecondAnesthesiaDoctor,THIRD_ANESTHESIA_DOCTOR=:ThirdAnesthesiaDoctor,RESERVED1=:Reserved1,RESERVED2=:Reserved2,OPERATION_POSITION=:OperationPosition,SPECIAL_EQUIPMENT=:SpecialEquipment,SPECIAL_INFECT=:SpecialInfect,HEPATITIS_INDICATOR=:HepatitisIndicator,OPERATION_ID=:OperationId,RESERVED3=:Reserved3,RESERVED4=:Reserved4,RESERVED5=:Reserved5,RESERVED6=:Reserved6,RESERVED7=:Reserved7,RESERVED8=:Reserved8,RESERVED9=:Reserved9,RESERVED10=:Reserved10,RESERVED11=:Reserved11,RESERVED12=:Reserved12,STATE = :State,Operation_Name=:OperationName,Third_Operation_Nurse= :ThirdOperationNurse WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND SCHEDULE_ID=:ScheduleId";
        private static readonly string MED_OPERATION_SCHEDULE_Delete = "Delete MED_OPERATION_SCHEDULE WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND SCHEDULE_ID=:ScheduleId";
        //新增OPERATION_POSITION, SPECIAL_EQUIPMENT,SPECIAL_INFECT
       // private static readonly string MED_OPERATION_SCHEDULE_Select = "SELECT PATIENT_ID,VISIT_ID,SCHEDULE_ID,DEPT_STAYED,BED_NO,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,FIRST_OPERATION_NURSE,SECOND_OPERATION_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,NOTES_ON_OPERATION,ENTERED_BY,REQ_DATE_TIME,THIRD_SUPPLY_NURSE,ACK_INDICATOR,EMERGENCY_INDICATOR,RECK_GROUP,OPER_ID,SECOND_ANESTHESIA_ASSISTANT,THIRD_ANESTHESIA_ASSISTANT,FOURTH_ANESTHESIA_ASSISTANT,SECOND_ANESTHESIA_DOCTOR,THIRD_ANESTHESIA_DOCTOR,RESERVED1,RESERVED2,OPERATION_POSITION,SPECIAL_EQUIPMENT,SPECIAL_INFECT,HEPATITIS_INDICATOR,OPERATION_ID,RESERVED3,RESERVED4,RESERVED5,RESERVED6,RESERVED7,RESERVED8,RESERVED9,RESERVED10,RESERVED11,RESERVED12,STATE,OPERATION_NAME FROM MED_OPERATION_SCHEDULE where PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND SCHEDULE_ID=:ScheduleId";
        private static readonly string MED_OPERATION_SCHEDULE_Select_ALL = "select PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME   FROM MED_OPERATION_SCHEDULE";
		//2013-4-18 孙凯增加
        private static readonly string MED_OPERATION_SCHEDULE_Select_OperId = "select PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,ASA_GRADE,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,OPER_POSITION,BED_NO,OPERATION_NAME,SPECIAL_EQUIPMENT,SPECIAL_INFECT,ANES_CONFIRM,NURSE_CONFIRM,OPER_STATUS_CODE,NOTES_ON_OPERATION,OPERATOR,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED1,RESERVED2,RESERVED3,OPERATING_TIME FROM MED_OPERATION_SCHEDULE where PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND oper_id=:OperId";
        public DALMedOperationSchedule ()
		{
		}
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedOperationSchedule SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOperationSchedule")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
                            new SqlParameter("@VisitId",SqlDbType.Decimal),
                            new SqlParameter("@ScheduleId",SqlDbType.Decimal),
                            new SqlParameter("@OperId",SqlDbType.Decimal),
                            new SqlParameter("@HospBranch",SqlDbType.VarChar),
                            new SqlParameter("@WardCode",SqlDbType.VarChar),
                            new SqlParameter("@DeptCode",SqlDbType.VarChar),
                            new SqlParameter("@OperDeptCode",SqlDbType.VarChar),
                            new SqlParameter("@OperRoom",SqlDbType.VarChar),
                            new SqlParameter("@OperRoomNo",SqlDbType.VarChar),
                            new SqlParameter("@Sequence",SqlDbType.Decimal),
                            new SqlParameter("@OperClass",SqlDbType.VarChar),
                            new SqlParameter("@DiagBeforeOperation",SqlDbType.VarChar),
                            new SqlParameter("@PatientCondition",SqlDbType.VarChar),
                            new SqlParameter("@OperScale",SqlDbType.VarChar),
                            new SqlParameter("@WoundType",SqlDbType.VarChar),
                            new SqlParameter("@AsaGrade",SqlDbType.VarChar),
                            new SqlParameter("@EmergencyInd",SqlDbType.Decimal),
                            new SqlParameter("@OperSource",SqlDbType.Decimal),
                            new SqlParameter("@IsolationInd",SqlDbType.Decimal),
                            new SqlParameter("@InfectedInd",SqlDbType.Decimal),
                            new SqlParameter("@RadiateInd",SqlDbType.Decimal),
                            new SqlParameter("@Surgeon",SqlDbType.VarChar),
                            new SqlParameter("@FirstOperAssistant",SqlDbType.VarChar),
                            new SqlParameter("@SecondOperAssistant",SqlDbType.VarChar),
                            new SqlParameter("@ThirdOperAssistant",SqlDbType.VarChar),
                            new SqlParameter("@FourthOperAssistant",SqlDbType.VarChar),
                            new SqlParameter("@AnesMethod",SqlDbType.VarChar),
                            new SqlParameter("@AnesDoctor",SqlDbType.VarChar),
                            new SqlParameter("@FirstAnesAssistant",SqlDbType.VarChar),
                            new SqlParameter("@SecondAnesAssistant",SqlDbType.VarChar),
                            new SqlParameter("@ThirdAnesAssistant",SqlDbType.VarChar),
                            new SqlParameter("@FourthAnesAssistant",SqlDbType.VarChar),
                            new SqlParameter("@FirstAnesNurse",SqlDbType.VarChar),
                            new SqlParameter("@SecondAnesNurse",SqlDbType.VarChar),
                            new SqlParameter("@ThirdAnesNurse",SqlDbType.VarChar),
                            new SqlParameter("@CpbDoctor",SqlDbType.VarChar),
                            new SqlParameter("@FirstCpbAssistant",SqlDbType.VarChar),
                            new SqlParameter("@SecondCpbAssistant",SqlDbType.VarChar),
                            new SqlParameter("@ThirdCpbAssistant",SqlDbType.VarChar),
                            new SqlParameter("@FourthCpbAssistant",SqlDbType.VarChar),
                            new SqlParameter("@FirstOperNurse",SqlDbType.VarChar),
                            new SqlParameter("@SecondOperNurse",SqlDbType.VarChar),
                            new SqlParameter("@ThirdOperNurse",SqlDbType.VarChar),
                            new SqlParameter("@FourthOperNurse",SqlDbType.VarChar),
                            new SqlParameter("@FirstSupplyNurse",SqlDbType.VarChar),
                            new SqlParameter("@SecondSupplyNurse",SqlDbType.VarChar),
                            new SqlParameter("@ThirdSupplyNurse",SqlDbType.VarChar),
                            new SqlParameter("@FourthSupplyNurse",SqlDbType.VarChar),
                            new SqlParameter("@PacuDoctor",SqlDbType.VarChar),
                            new SqlParameter("@FirstPacuAssistant",SqlDbType.VarChar),
                            new SqlParameter("@SecondPacuAssistant",SqlDbType.VarChar),
                            new SqlParameter("@FirstPacuNurse",SqlDbType.VarChar),
                            new SqlParameter("@SecondPacuNurse",SqlDbType.VarChar),
                            new SqlParameter("@ReqDateTime",SqlDbType.DateTime),
                            new SqlParameter("@ScheduledDateTime",SqlDbType.DateTime),
                            new SqlParameter("@OperPosition",SqlDbType.VarChar),
                            new SqlParameter("@BedNo",SqlDbType.VarChar),
                            new SqlParameter("@OperationName",SqlDbType.VarChar),
                            new SqlParameter("@SpecialEquipment",SqlDbType.VarChar),
                            new SqlParameter("@SpecialInfect",SqlDbType.VarChar),
                            new SqlParameter("@AnesConfirm",SqlDbType.VarChar),
                            new SqlParameter("@NurseConfirm",SqlDbType.VarChar),
                            new SqlParameter("@OperStatusCode",SqlDbType.VarChar),
                            new SqlParameter("@NotesOnOperation",SqlDbType.VarChar),
                            new SqlParameter("@Operator",SqlDbType.VarChar),
                            new SqlParameter("@HisPatientId",SqlDbType.VarChar),
                            new SqlParameter("@HisVisitId",SqlDbType.VarChar),
                            new SqlParameter("@HisScheduleId",SqlDbType.VarChar),
                            new SqlParameter("@HisOperStatus",SqlDbType.VarChar),
                            new SqlParameter("@Reserved1",SqlDbType.VarChar),
                            new SqlParameter("@Reserved2",SqlDbType.VarChar),
                            new SqlParameter("@Reserved3",SqlDbType.VarChar),
                            new SqlParameter("@OperatingTime",SqlDbType.Decimal),
                    };
                }
				else if (sqlParms == "UpdateMedOperationSchedule")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
                        new SqlParameter("@VisitId",SqlDbType.Decimal),
                        new SqlParameter("@ScheduleId",SqlDbType.Decimal),
                        new SqlParameter("@OperId",SqlDbType.Decimal),
                        new SqlParameter("@HospBranch",SqlDbType.VarChar),
                        new SqlParameter("@WardCode",SqlDbType.VarChar),
                        new SqlParameter("@DeptCode",SqlDbType.VarChar),
                        new SqlParameter("@OperDeptCode",SqlDbType.VarChar),
                        new SqlParameter("@OperRoom",SqlDbType.VarChar),
                        new SqlParameter("@OperRoomNo",SqlDbType.VarChar),
                        new SqlParameter("@Sequence",SqlDbType.Decimal),
                        new SqlParameter("@OperClass",SqlDbType.VarChar),
                        new SqlParameter("@DiagBeforeOperation",SqlDbType.VarChar),
                        new SqlParameter("@PatientCondition",SqlDbType.VarChar),
                        new SqlParameter("@OperScale",SqlDbType.VarChar),
                        new SqlParameter("@WoundType",SqlDbType.VarChar),
                        new SqlParameter("@AsaGrade",SqlDbType.VarChar),
                        new SqlParameter("@EmergencyInd",SqlDbType.Decimal),
                        new SqlParameter("@OperSource",SqlDbType.Decimal),
                        new SqlParameter("@IsolationInd",SqlDbType.Decimal),
                        new SqlParameter("@InfectedInd",SqlDbType.Decimal),
                        new SqlParameter("@RadiateInd",SqlDbType.Decimal),
                        new SqlParameter("@Surgeon",SqlDbType.VarChar),
                        new SqlParameter("@FirstOperAssistant",SqlDbType.VarChar),
                        new SqlParameter("@SecondOperAssistant",SqlDbType.VarChar),
                        new SqlParameter("@ThirdOperAssistant",SqlDbType.VarChar),
                        new SqlParameter("@FourthOperAssistant",SqlDbType.VarChar),
                        new SqlParameter("@AnesMethod",SqlDbType.VarChar),
                        new SqlParameter("@AnesDoctor",SqlDbType.VarChar),
                        new SqlParameter("@FirstAnesAssistant",SqlDbType.VarChar),
                        new SqlParameter("@SecondAnesAssistant",SqlDbType.VarChar),
                        new SqlParameter("@ThirdAnesAssistant",SqlDbType.VarChar),
                        new SqlParameter("@FourthAnesAssistant",SqlDbType.VarChar),
                        new SqlParameter("@FirstAnesNurse",SqlDbType.VarChar),
                        new SqlParameter("@SecondAnesNurse",SqlDbType.VarChar),
                        new SqlParameter("@ThirdAnesNurse",SqlDbType.VarChar),
                        new SqlParameter("@CpbDoctor",SqlDbType.VarChar),
                        new SqlParameter("@FirstCpbAssistant",SqlDbType.VarChar),
                        new SqlParameter("@SecondCpbAssistant",SqlDbType.VarChar),
                        new SqlParameter("@ThirdCpbAssistant",SqlDbType.VarChar),
                        new SqlParameter("@FourthCpbAssistant",SqlDbType.VarChar),
                        new SqlParameter("@FirstOperNurse",SqlDbType.VarChar),
                        new SqlParameter("@SecondOperNurse",SqlDbType.VarChar),
                        new SqlParameter("@ThirdOperNurse",SqlDbType.VarChar),
                        new SqlParameter("@FourthOperNurse",SqlDbType.VarChar),
                        new SqlParameter("@FirstSupplyNurse",SqlDbType.VarChar),
                        new SqlParameter("@SecondSupplyNurse",SqlDbType.VarChar),
                        new SqlParameter("@ThirdSupplyNurse",SqlDbType.VarChar),
                        new SqlParameter("@FourthSupplyNurse",SqlDbType.VarChar),
                        new SqlParameter("@PacuDoctor",SqlDbType.VarChar),
                        new SqlParameter("@FirstPacuAssistant",SqlDbType.VarChar),
                        new SqlParameter("@SecondPacuAssistant",SqlDbType.VarChar),
                        new SqlParameter("@FirstPacuNurse",SqlDbType.VarChar),
                        new SqlParameter("@SecondPacuNurse",SqlDbType.VarChar),
                        new SqlParameter("@ReqDateTime",SqlDbType.DateTime),
                        new SqlParameter("@ScheduledDateTime",SqlDbType.DateTime),
                        new SqlParameter("@OperPosition",SqlDbType.VarChar),
                        new SqlParameter("@BedNo",SqlDbType.VarChar),
                        new SqlParameter("@OperationName",SqlDbType.VarChar),
                        new SqlParameter("@SpecialEquipment",SqlDbType.VarChar),
                        new SqlParameter("@SpecialInfect",SqlDbType.VarChar),
                        new SqlParameter("@AnesConfirm",SqlDbType.VarChar),
                        new SqlParameter("@NurseConfirm",SqlDbType.VarChar),
                        new SqlParameter("@OperStatusCode",SqlDbType.VarChar),
                        new SqlParameter("@NotesOnOperation",SqlDbType.VarChar),
                        new SqlParameter("@Operator",SqlDbType.VarChar),
                        new SqlParameter("@HisPatientId",SqlDbType.VarChar),
                        new SqlParameter("@HisVisitId",SqlDbType.VarChar),
                        new SqlParameter("@HisScheduleId",SqlDbType.VarChar),
                        new SqlParameter("@HisOperStatus",SqlDbType.VarChar),
                        new SqlParameter("@Reserved1",SqlDbType.VarChar),
                        new SqlParameter("@Reserved2",SqlDbType.VarChar),
                        new SqlParameter("@Reserved3",SqlDbType.VarChar),
                        new SqlParameter("@OperatingTime",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedOperationSchedule")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@ScheduleId",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "SelectMedOperationSchedule")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@ScheduleId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMaxScheduleIdMedOperationSchedule")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectCountMedOperationSchedule")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@ScheduleId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedOperationScheduleOperId")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OperId",SqlDbType.Decimal),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedOperationSchedule 
		///Insert Table MED_OPERATION_SCHEDULE
		/// </summary>
		public int InsertMedOperationScheduleSQL(MedOperationSchedule model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedOperationSchedule");
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
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString,Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedOperationSchedule 
		///Update Table     MED_OPERATION_SCHEDULE
		/// </summary>
		public int UpdateMedOperationScheduleSQL(MedOperationSchedule model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedOperationSchedule");
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
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, Update_SQL , oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedOperationSchedule 
		///Delete Table MED_OPERATION_SCHEDULE by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
		/// </summary>
		public int DeleteMedOperationScheduleSQL(string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedOperationSchedule");
					if (PATIENT_ID != null)
						oneDelete[0].Value =PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (VISIT_ID.ToString() != null)
						oneDelete[1].Value =VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
                    if (SCHEDULE_ID.ToString() != null)
						oneDelete[2].Value =SCHEDULE_ID;
					else
						oneDelete[2].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_OPERATION_SCHEDULE_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedOperationSchedule 
		///select Table MED_OPERATION_SCHEDULE by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
		/// </summary>
		public MedOperationSchedule  SelectMedOperationScheduleSQL(string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
		{
			MedOperationSchedule model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedOperationSchedule");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
				parameterValues[2].Value=SCHEDULE_ID;
			 using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_SCHEDULE_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedOperationSchedule();
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
		#endregion	
        #region  [根据operid获取一条记录SQL]
        /// <summary>
        ///Select    model  MedOperationSchedule 
        ///select Table MED_OPERATION_SCHEDULE by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
        /// </summary>
        public MedOperationSchedule SelectMedOperationScheduleWithOperIdSQL(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID)
        {
            MedOperationSchedule model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedOperationScheduleOperId");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = OPER_ID;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_SCHEDULE_Select_OperId_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedOperationSchedule();
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
        #endregion	
		#region  [获取所有记录SQL]
		/// <summary>
		///获取所有记录
		/// </summary>
		public List<MedOperationSchedule> SelectMedOperationScheduleListSQL()
		{
			List<MedOperationSchedule> modelList = new List<MedOperationSchedule>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_SCHEDULE_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedOperationSchedule model = new MedOperationSchedule();
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
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
        public int SelectMaxScheduleIdSQL(string patientId, decimal visitId)
        {
            SqlParameter[] medMaxScheduleId = GetParameterSQL("SelectMaxScheduleIdMedOperationSchedule");
            medMaxScheduleId[0].Value = patientId;
            medMaxScheduleId[1].Value = visitId;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_SCHEDULE_Select_Max_ScheduleId_SQL, medMaxScheduleId))
            {
                if (oleReader.Read())
                {
                    return Convert.ToInt32(oleReader[0]);
                }
                else
                {
                    return 0;
                }
            }
        }

        public int SelectCountMedOperationScheduleSQL(string patientId, decimal visitId, decimal scheduleId)
        {
            SqlParameter[] countMedOperationSchedule = GetParameterSQL("SelectCountMedOperationSchedule");
            countMedOperationSchedule[0].Value = patientId;
            countMedOperationSchedule[1].Value = visitId;
            countMedOperationSchedule[2].Value = scheduleId;

            object count = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_SCHEDULE_Select_Count_SQL, countMedOperationSchedule);
            if (count == null)
                count = (object)0;
            return Convert.ToInt32(count);
        }

		#region [获取参数]
		/// <summary>
		///获取参数MedOperationSchedule
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOperationSchedule")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
                            new OracleParameter(":VisitId",OracleType.Number),
                            new OracleParameter(":ScheduleId",OracleType.Number),
                            new OracleParameter(":OperId",OracleType.Number),
                            new OracleParameter(":HospBranch",OracleType.VarChar),
                            new OracleParameter(":WardCode",OracleType.VarChar),
                            new OracleParameter(":DeptCode",OracleType.VarChar),
                            new OracleParameter(":OperDeptCode",OracleType.VarChar),
                            new OracleParameter(":OperRoom",OracleType.VarChar),
                            new OracleParameter(":OperRoomNo",OracleType.VarChar),
                            new OracleParameter(":Sequence",OracleType.Number),
                            new OracleParameter(":OperClass",OracleType.VarChar),
                            new OracleParameter(":DiagBeforeOperation",OracleType.VarChar),
                            new OracleParameter(":PatientCondition",OracleType.VarChar),
                            new OracleParameter(":OperScale",OracleType.VarChar),
                            new OracleParameter(":WoundType",OracleType.VarChar),
                            new OracleParameter(":AsaGrade",OracleType.VarChar),
                            new OracleParameter(":EmergencyInd",OracleType.Number),
                            new OracleParameter(":OperSource",OracleType.Number),
                            new OracleParameter(":IsolationInd",OracleType.Number),
                            new OracleParameter(":InfectedInd",OracleType.Number),
                            new OracleParameter(":RadiateInd",OracleType.Number),
                            new OracleParameter(":Surgeon",OracleType.VarChar),
                            new OracleParameter(":FirstOperAssistant",OracleType.VarChar),
                            new OracleParameter(":SecondOperAssistant",OracleType.VarChar),
                            new OracleParameter(":ThirdOperAssistant",OracleType.VarChar),
                            new OracleParameter(":FourthOperAssistant",OracleType.VarChar),
                            new OracleParameter(":AnesMethod",OracleType.VarChar),
                            new OracleParameter(":AnesDoctor",OracleType.VarChar),
                            new OracleParameter(":FirstAnesAssistant",OracleType.VarChar),
                            new OracleParameter(":SecondAnesAssistant",OracleType.VarChar),
                            new OracleParameter(":ThirdAnesAssistant",OracleType.VarChar),
                            new OracleParameter(":FourthAnesAssistant",OracleType.VarChar),
                            new OracleParameter(":FirstAnesNurse",OracleType.VarChar),
                            new OracleParameter(":SecondAnesNurse",OracleType.VarChar),
                            new OracleParameter(":ThirdAnesNurse",OracleType.VarChar),
                            new OracleParameter(":CpbDoctor",OracleType.VarChar),
                            new OracleParameter(":FirstCpbAssistant",OracleType.VarChar),
                            new OracleParameter(":SecondCpbAssistant",OracleType.VarChar),
                            new OracleParameter(":ThirdCpbAssistant",OracleType.VarChar),
                            new OracleParameter(":FourthCpbAssistant",OracleType.VarChar),
                            new OracleParameter(":FirstOperNurse",OracleType.VarChar),
                            new OracleParameter(":SecondOperNurse",OracleType.VarChar),
                            new OracleParameter(":ThirdOperNurse",OracleType.VarChar),
                            new OracleParameter(":FourthOperNurse",OracleType.VarChar),
                            new OracleParameter(":FirstSupplyNurse",OracleType.VarChar),
                            new OracleParameter(":SecondSupplyNurse",OracleType.VarChar),
                            new OracleParameter(":ThirdSupplyNurse",OracleType.VarChar),
                            new OracleParameter(":FourthSupplyNurse",OracleType.VarChar),
                            new OracleParameter(":PacuDoctor",OracleType.VarChar),
                            new OracleParameter(":FirstPacuAssistant",OracleType.VarChar),
                            new OracleParameter(":SecondPacuAssistant",OracleType.VarChar),
                            new OracleParameter(":FirstPacuNurse",OracleType.VarChar),
                            new OracleParameter(":SecondPacuNurse",OracleType.VarChar),
                            new OracleParameter(":ReqDateTime",OracleType.DateTime),
                            new OracleParameter(":ScheduledDateTime",OracleType.DateTime),
                            new OracleParameter(":OperPosition",OracleType.VarChar),
                            new OracleParameter(":BedNo",OracleType.VarChar),
                            new OracleParameter(":OperationName",OracleType.VarChar),
                            new OracleParameter(":SpecialEquipment",OracleType.VarChar),
                            new OracleParameter(":SpecialInfect",OracleType.VarChar),
                            new OracleParameter(":AnesConfirm",OracleType.VarChar),
                            new OracleParameter(":NurseConfirm",OracleType.VarChar),
                            new OracleParameter(":OperStatusCode",OracleType.VarChar),
                            new OracleParameter(":NotesOnOperation",OracleType.VarChar),
                            new OracleParameter(":Operator",OracleType.VarChar),
                            new OracleParameter(":HisPatientId",OracleType.VarChar),
                            new OracleParameter(":HisVisitId",OracleType.VarChar),
                            new OracleParameter(":HisScheduleId",OracleType.VarChar),
                            new OracleParameter(":HisOperStatus",OracleType.VarChar),
                            new OracleParameter(":Reserved1",OracleType.VarChar),
                            new OracleParameter(":Reserved2",OracleType.VarChar),
                            new OracleParameter(":Reserved3",OracleType.VarChar),
                            new OracleParameter(":OperatingTime",OracleType.Number),
                    };
                }
				else if (sqlParms == "UpdateMedOperationSchedule")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":OperId",OracleType.Number),
                            new OracleParameter(":HospBranch",OracleType.VarChar),
                            new OracleParameter(":WardCode",OracleType.VarChar),
                            new OracleParameter(":DeptCode",OracleType.VarChar),
                            new OracleParameter(":OperDeptCode",OracleType.VarChar),
                            new OracleParameter(":OperRoom",OracleType.VarChar),
                            new OracleParameter(":OperRoomNo",OracleType.VarChar),
                            new OracleParameter(":Sequence",OracleType.Number),
                            new OracleParameter(":OperClass",OracleType.VarChar),
                            new OracleParameter(":DiagBeforeOperation",OracleType.VarChar),
                            new OracleParameter(":PatientCondition",OracleType.VarChar),
                            new OracleParameter(":OperScale",OracleType.VarChar),
                            new OracleParameter(":WoundType",OracleType.VarChar),
                            new OracleParameter(":AsaGrade",OracleType.VarChar),
                            new OracleParameter(":EmergencyInd",OracleType.Number),
                            new OracleParameter(":OperSource",OracleType.Number),
                            new OracleParameter(":IsolationInd",OracleType.Number),
                            new OracleParameter(":InfectedInd",OracleType.Number),
                            new OracleParameter(":RadiateInd",OracleType.Number),
                            new OracleParameter(":Surgeon",OracleType.VarChar),
                            new OracleParameter(":FirstOperAssistant",OracleType.VarChar),
                            new OracleParameter(":SecondOperAssistant",OracleType.VarChar),
                            new OracleParameter(":ThirdOperAssistant",OracleType.VarChar),
                            new OracleParameter(":FourthOperAssistant",OracleType.VarChar),
                            new OracleParameter(":AnesMethod",OracleType.VarChar),
                            new OracleParameter(":AnesDoctor",OracleType.VarChar),
                            new OracleParameter(":FirstAnesAssistant",OracleType.VarChar),
                            new OracleParameter(":SecondAnesAssistant",OracleType.VarChar),
                            new OracleParameter(":ThirdAnesAssistant",OracleType.VarChar),
                            new OracleParameter(":FourthAnesAssistant",OracleType.VarChar),
                            new OracleParameter(":FirstAnesNurse",OracleType.VarChar),
                            new OracleParameter(":SecondAnesNurse",OracleType.VarChar),
                            new OracleParameter(":ThirdAnesNurse",OracleType.VarChar),
                            new OracleParameter(":CpbDoctor",OracleType.VarChar),
                            new OracleParameter(":FirstCpbAssistant",OracleType.VarChar),
                            new OracleParameter(":SecondCpbAssistant",OracleType.VarChar),
                            new OracleParameter(":ThirdCpbAssistant",OracleType.VarChar),
                            new OracleParameter(":FourthCpbAssistant",OracleType.VarChar),
                            new OracleParameter(":FirstOperNurse",OracleType.VarChar),
                            new OracleParameter(":SecondOperNurse",OracleType.VarChar),
                            new OracleParameter(":ThirdOperNurse",OracleType.VarChar),
                            new OracleParameter(":FourthOperNurse",OracleType.VarChar),
                            new OracleParameter(":FirstSupplyNurse",OracleType.VarChar),
                            new OracleParameter(":SecondSupplyNurse",OracleType.VarChar),
                            new OracleParameter(":ThirdSupplyNurse",OracleType.VarChar),
                            new OracleParameter(":FourthSupplyNurse",OracleType.VarChar),
                            new OracleParameter(":PacuDoctor",OracleType.VarChar),
                            new OracleParameter(":FirstPacuAssistant",OracleType.VarChar),
                            new OracleParameter(":SecondPacuAssistant",OracleType.VarChar),
                            new OracleParameter(":FirstPacuNurse",OracleType.VarChar),
                            new OracleParameter(":SecondPacuNurse",OracleType.VarChar),
                            new OracleParameter(":ReqDateTime",OracleType.DateTime),
                            new OracleParameter(":ScheduledDateTime",OracleType.DateTime),
                            new OracleParameter(":OperPosition",OracleType.VarChar),
                            new OracleParameter(":BedNo",OracleType.VarChar),
                            new OracleParameter(":OperationName",OracleType.VarChar),
                            new OracleParameter(":SpecialEquipment",OracleType.VarChar),
                            new OracleParameter(":SpecialInfect",OracleType.VarChar),
                            new OracleParameter(":AnesConfirm",OracleType.VarChar),
                            new OracleParameter(":NurseConfirm",OracleType.VarChar),
                            new OracleParameter(":OperStatusCode",OracleType.VarChar),
                            new OracleParameter(":NotesOnOperation",OracleType.VarChar),
                            new OracleParameter(":Operator",OracleType.VarChar),
                            new OracleParameter(":HisPatientId",OracleType.VarChar),
                            new OracleParameter(":HisVisitId",OracleType.VarChar),
                            new OracleParameter(":HisScheduleId",OracleType.VarChar),
                            new OracleParameter(":HisOperStatus",OracleType.VarChar),
                            new OracleParameter(":Reserved1",OracleType.VarChar),
                            new OracleParameter(":Reserved2",OracleType.VarChar),
                            new OracleParameter(":Reserved3",OracleType.VarChar),
                            new OracleParameter(":OperatingTime",OracleType.Number),
                            new OracleParameter(":PatientId",OracleType.VarChar),
                            new OracleParameter(":VisitId",OracleType.Number),
                            new OracleParameter(":ScheduleId",OracleType.Number),
                    };
                }
				else if(sqlParms == "DeleteMedOperationSchedule")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":ScheduleId",OracleType.Number),
                    };
                }
				else if(sqlParms == "SelectMedOperationSchedule")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":ScheduleId",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectMaxScheduleIdMedOperationSchedule")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectCountMedOperationSchedule")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":ScheduleId",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectMedOperationScheduleOperId")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OperId",OracleType.Number),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedOperationSchedule 
		///Insert Table MED_OPERATION_SCHEDULE
		/// </summary>
		public int InsertMedOperationSchedule(MedOperationSchedule model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedOperationSchedule");
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
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedOperationSchedule 
		///Update Table     MED_OPERATION_SCHEDULE
		/// </summary>
        public int UpdateMedOperationSchedule(MedOperationSchedule model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedOperationSchedule");
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
                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, Update, oneUpdate);
            }
        }
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedOperationSchedule 
		///Delete Table MED_OPERATION_SCHEDULE by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
		/// </summary>
		public int DeleteMedOperationSchedule(string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedOperationSchedule");
					if (PATIENT_ID != null)
						oneDelete[0].Value =PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (VISIT_ID.ToString() != null)
						oneDelete[1].Value =VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
                    if (SCHEDULE_ID.ToString() != null)
						oneDelete[2].Value =SCHEDULE_ID;
					else
						oneDelete[2].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_OPERATION_SCHEDULE_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedOperationSchedule 
		///select Table MED_OPERATION_SCHEDULE by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
		/// </summary>
		public MedOperationSchedule  SelectMedOperationSchedule(string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
		{
			MedOperationSchedule model;
			OracleParameter[] parameterValues = GetParameter("SelectMedOperationSchedule");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
				parameterValues[2].Value=SCHEDULE_ID;
                using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, Select, parameterValues))
			   {
				if (oleReader.Read())
				{
					model = new MedOperationSchedule();
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
		#endregion	
        #region  [根据operid获取一条记录]
        /// <summary>
        ///Select    model  MedOperationSchedule 
        ///select Table MED_OPERATION_SCHEDULE by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
        /// </summary>
        public MedOperationSchedule SelectMedOperationScheduleWithOperId(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID)
        {
            MedOperationSchedule model;
            OracleParameter[] parameterValues = GetParameter("SelectMedOperationScheduleOperId");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = OPER_ID;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_SCHEDULE_Select_OperId, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedOperationSchedule();
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
        #endregion	
		#region  [获取所有记录]
		/// <summary>
		///获取所有记录
		/// </summary>
		public List<MedOperationSchedule> SelectMedOperationScheduleList()
		{
			List<MedOperationSchedule> modelList = new List<MedOperationSchedule>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_SCHEDULE_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedOperationSchedule model = new MedOperationSchedule();
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
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	

        public int SelectMaxScheduleId(string patientId, decimal visitId)
        {
            OracleParameter[] medMaxScheduleId = GetParameter("SelectMaxScheduleIdMedOperationSchedule");
            medMaxScheduleId[0].Value = patientId;
            medMaxScheduleId[1].Value = visitId;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_SCHEDULE_Select_Max_ScheduleId, medMaxScheduleId))
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

        public int SelectCountMedOperationSchedule(string patientId, decimal visitId, decimal scheduleId)
        {
            OracleParameter[] countMedOperationSchedule = GetParameter("SelectCountMedOperationSchedule");
            countMedOperationSchedule[0].Value = patientId;
            countMedOperationSchedule[1].Value = visitId;
            countMedOperationSchedule[2].Value = scheduleId;

            object count = OracleHelper.ExecuteScalar(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_SCHEDULE_Select_Count, countMedOperationSchedule);
            if (count == null)
                count = (object)0;
            return Convert.ToInt32(count);
        }
		
	}
}
