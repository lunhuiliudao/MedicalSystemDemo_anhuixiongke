using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.Odbc;
namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedOperationMaster
    /// </summary>

    public partial class DALMedOperationMaster
    {
        //新增,OPERATION_POSITION, SPECIAL_EQUIPMENT,SPECIAL_INFECT
        private static readonly string Select_One_Med_Operation_Master_OLE = "select PATIENT_ID,VISIT_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,WOUND_NUMBER,ASA_GRADE,DIAG_AFTER_OPERATION,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,IN_DATE_TIME,OUT_DATE_TIME,ANES_START_TIME,ANES_END_TIME,START_DATE_TIME,END_DATE_TIME,IN_PACU_DATE_TIME,OUT_PACU_DATE_TIME,OPER_STATUS_CODE,OPER_POSITION,BED_NO,OPERATION_NAME,PAT_WHEREABORTS,SATISFACTION_DEGREE,SMOOTH_INDICATOR,ENTERED_BY,ORDER_TRANSFER,CHARGE_TRANSFER,END_INDICATOR,MEMO,ANESTHESIA_ID,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED01,RESERVED02,RESERVED03 from MED_OPERATION_MASTER WHERE PATIENT_ID=? AND VISIT_ID=? AND OPER_ID=? ";
        private static readonly string Select_Med_Operation_Master_OLE = "select PATIENT_ID,VISIT_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,WOUND_NUMBER,ASA_GRADE,DIAG_AFTER_OPERATION,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,IN_DATE_TIME,OUT_DATE_TIME,ANES_START_TIME,ANES_END_TIME,START_DATE_TIME,END_DATE_TIME,IN_PACU_DATE_TIME,OUT_PACU_DATE_TIME,OPER_STATUS_CODE,OPER_POSITION,BED_NO,OPERATION_NAME,PAT_WHEREABORTS,SATISFACTION_DEGREE,SMOOTH_INDICATOR,ENTERED_BY,ORDER_TRANSFER,CHARGE_TRANSFER,END_INDICATOR,MEMO,ANESTHESIA_ID,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED01,RESERVED02,RESERVED03 from MED_OPERATION_MASTER";
        private static readonly string Select_Max_OperId_Med_Operation_Master_OLE = "select nvl(max(oper_id),0) from med_operation_master where patient_id = ? and visit_id = ?";
        private static readonly string Insert_Med_Operation_Master_OLE = "Insert into MED_OPERATION_MASTER  (PATIENT_ID,VISIT_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,WOUND_NUMBER,ASA_GRADE,DIAG_AFTER_OPERATION,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,IN_DATE_TIME,OUT_DATE_TIME,ANES_START_TIME,ANES_END_TIME,START_DATE_TIME,END_DATE_TIME,IN_PACU_DATE_TIME,OUT_PACU_DATE_TIME,OPER_STATUS_CODE,OPER_POSITION,BED_NO,OPERATION_NAME,PAT_WHEREABORTS,SATISFACTION_DEGREE,SMOOTH_INDICATOR,ENTERED_BY,ORDER_TRANSFER,CHARGE_TRANSFER,END_INDICATOR,MEMO,ANESTHESIA_ID,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED01,RESERVED02,RESERVED03) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string Update_Med_Operation_Master_OLE = "Update MED_OPERATION_MASTER set HOSP_BRANCH=?,WARD_CODE=?,DEPT_CODE=?,OPER_DEPT_CODE=?,OPER_ROOM=?,OPER_ROOM_NO=?,SEQUENCE=?,OPER_CLASS=?,DIAG_BEFORE_OPERATION=?,PATIENT_CONDITION=?,OPER_SCALE=?,WOUND_TYPE=?,WOUND_NUMBER=?,ASA_GRADE=?,DIAG_AFTER_OPERATION=?,EMERGENCY_IND=?,OPER_SOURCE=?,ISOLATION_IND=?,INFECTED_IND=?,RADIATE_IND=?,SURGEON=?,FIRST_OPER_ASSISTANT=?,SECOND_OPER_ASSISTANT=?,THIRD_OPER_ASSISTANT=?,FOURTH_OPER_ASSISTANT=?,ANES_METHOD=?,ANES_DOCTOR=?,FIRST_ANES_ASSISTANT=?,SECOND_ANES_ASSISTANT=?,THIRD_ANES_ASSISTANT=?,FOURTH_ANES_ASSISTANT=?,FIRST_ANES_NURSE=?,SECOND_ANES_NURSE=?,THIRD_ANES_NURSE=?,CPB_DOCTOR=?,FIRST_CPB_ASSISTANT=?,SECOND_CPB_ASSISTANT=?,THIRD_CPB_ASSISTANT=?,FOURTH_CPB_ASSISTANT=?,FIRST_OPER_NURSE=?,SECOND_OPER_NURSE=?,THIRD_OPER_NURSE=?,FOURTH_OPER_NURSE=?,FIRST_SUPPLY_NURSE=?,SECOND_SUPPLY_NURSE=?,THIRD_SUPPLY_NURSE=?,FOURTH_SUPPLY_NURSE=?,PACU_DOCTOR=?,FIRST_PACU_ASSISTANT=?,SECOND_PACU_ASSISTANT=?,FIRST_PACU_NURSE=?,SECOND_PACU_NURSE=?,REQ_DATE_TIME=?,SCHEDULED_DATE_TIME=?,IN_DATE_TIME=?,OUT_DATE_TIME=?,ANES_START_TIME=?,ANES_END_TIME=?,START_DATE_TIME=?,END_DATE_TIME=?,IN_PACU_DATE_TIME=?,OUT_PACU_DATE_TIME=?,OPER_STATUS_CODE=?,OPER_POSITION=?,BED_NO=?,OPERATION_NAME=?,PAT_WHEREABORTS=?,SATISFACTION_DEGREE=?,SMOOTH_INDICATOR=?,ENTERED_BY=?,ORDER_TRANSFER=?,CHARGE_TRANSFER=?,END_INDICATOR=?,MEMO=?,ANESTHESIA_ID=?,HIS_PATIENT_ID=?,HIS_VISIT_ID=?,HIS_SCHEDULE_ID=?,HIS_OPER_STATUS=?,RESERVED01=?,RESERVED02=?,RESERVED03=? where PATIENT_ID=? AND VISIT_ID=? AND OPER_ID=?  ";

        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectOneMedOperationMaster")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("operId",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "SelectPatMedOperationMaster" || sqlParms == "SelectMaxOperIdMedOperationMaster")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "InsertMedOperationMaster")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("PatientId",OleDbType.VarChar),
                        new OleDbParameter("VisitId",OleDbType.Decimal),
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
                        new OleDbParameter("WoundNumber",OleDbType.Decimal),
                        new OleDbParameter("AsaGrade",OleDbType.VarChar),
                        new OleDbParameter("DiagAfterOperation",OleDbType.VarChar),
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
                        new OleDbParameter("InDateTime",OleDbType.DBTimeStamp),
                        new OleDbParameter("OutDateTime",OleDbType.DBTimeStamp),
                        new OleDbParameter("AnesStartTime",OleDbType.DBTimeStamp),
                        new OleDbParameter("AnesEndTime",OleDbType.DBTimeStamp),
                        new OleDbParameter("StartDateTime",OleDbType.DBTimeStamp),
                        new OleDbParameter("EndDateTime",OleDbType.DBTimeStamp),
                        new OleDbParameter("InPacuDateTime",OleDbType.DBTimeStamp),
                        new OleDbParameter("OutPacuDateTime",OleDbType.DBTimeStamp),
                        new OleDbParameter("OperStatusCode",OleDbType.VarChar),
                        new OleDbParameter("OperPosition",OleDbType.VarChar),
                        new OleDbParameter("BedNo",OleDbType.VarChar),
                        new OleDbParameter("OperationName",OleDbType.VarChar),
                        new OleDbParameter("PatWhereaborts",OleDbType.VarChar),
                        new OleDbParameter("SatisfactionDegree",OleDbType.Decimal),
                        new OleDbParameter("SmoothIndicator",OleDbType.Decimal),
                        new OleDbParameter("EnteredBy",OleDbType.VarChar),
                        new OleDbParameter("OrderTransfer",OleDbType.Decimal),
                        new OleDbParameter("ChargeTransfer",OleDbType.Decimal),
                        new OleDbParameter("EndIndicator",OleDbType.Decimal),
                        new OleDbParameter("Memo",OleDbType.VarChar),
                        new OleDbParameter("AnesthesiaId",OleDbType.VarChar),
                        new OleDbParameter("HisPatientId",OleDbType.VarChar),
                        new OleDbParameter("HisVisitId",OleDbType.VarChar),
                        new OleDbParameter("HisScheduleId",OleDbType.VarChar),
                        new OleDbParameter("HisOperStatus",OleDbType.VarChar),
                        new OleDbParameter("RESERVED01",OleDbType.VarChar),
                        new OleDbParameter("RESERVED02",OleDbType.VarChar),
                        new OleDbParameter("RESERVED03",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedOperationMaster")
                {
                    parms = new OleDbParameter[]{
                            new OleDbParameter(":HospBranch",OleDbType.VarChar),
                            new OleDbParameter(":WardCode",OleDbType.VarChar),
                            new OleDbParameter(":DeptCode",OleDbType.VarChar),
                            new OleDbParameter(":OperDeptCode",OleDbType.VarChar),
                            new OleDbParameter(":OperRoom",OleDbType.VarChar),
                            new OleDbParameter(":OperRoomNo",OleDbType.VarChar),
                            new OleDbParameter(":Sequence",OleDbType.Decimal),
                            new OleDbParameter(":OperClass",OleDbType.VarChar),
                            new OleDbParameter(":DiagBeforeOperation",OleDbType.VarChar),
                            new OleDbParameter(":PatientCondition",OleDbType.VarChar),
                            new OleDbParameter(":OperScale",OleDbType.VarChar),
                            new OleDbParameter(":WoundType",OleDbType.VarChar),
                            new OleDbParameter(":WoundNumber",OleDbType.Decimal),
                            new OleDbParameter(":AsaGrade",OleDbType.VarChar),
                            new OleDbParameter(":DiagAfterOperation",OleDbType.VarChar),
                            new OleDbParameter(":EmergencyInd",OleDbType.Decimal),
                            new OleDbParameter(":OperSource",OleDbType.Decimal),
                            new OleDbParameter(":IsolationInd",OleDbType.Decimal),
                            new OleDbParameter(":InfectedInd",OleDbType.Decimal),
                            new OleDbParameter(":RadiateInd",OleDbType.Decimal),
                            new OleDbParameter(":Surgeon",OleDbType.VarChar),
                            new OleDbParameter(":FirstOperAssistant",OleDbType.VarChar),
                            new OleDbParameter(":SecondOperAssistant",OleDbType.VarChar),
                            new OleDbParameter(":ThirdOperAssistant",OleDbType.VarChar),
                            new OleDbParameter(":FourthOperAssistant",OleDbType.VarChar),
                            new OleDbParameter(":AnesMethod",OleDbType.VarChar),
                            new OleDbParameter(":AnesDoctor",OleDbType.VarChar),
                            new OleDbParameter(":FirstAnesAssistant",OleDbType.VarChar),
                            new OleDbParameter(":SecondAnesAssistant",OleDbType.VarChar),
                            new OleDbParameter(":ThirdAnesAssistant",OleDbType.VarChar),
                            new OleDbParameter(":FourthAnesAssistant",OleDbType.VarChar),
                            new OleDbParameter(":FirstAnesNurse",OleDbType.VarChar),
                            new OleDbParameter(":SecondAnesNurse",OleDbType.VarChar),
                            new OleDbParameter(":ThirdAnesNurse",OleDbType.VarChar),
                            new OleDbParameter(":CpbDoctor",OleDbType.VarChar),
                            new OleDbParameter(":FirstCpbAssistant",OleDbType.VarChar),
                            new OleDbParameter(":SecondCpbAssistant",OleDbType.VarChar),
                            new OleDbParameter(":ThirdCpbAssistant",OleDbType.VarChar),
                            new OleDbParameter(":FourthCpbAssistant",OleDbType.VarChar),
                            new OleDbParameter(":FirstOperNurse",OleDbType.VarChar),
                            new OleDbParameter(":SecondOperNurse",OleDbType.VarChar),
                            new OleDbParameter(":ThirdOperNurse",OleDbType.VarChar),
                            new OleDbParameter(":FourthOperNurse",OleDbType.VarChar),
                            new OleDbParameter(":FirstSupplyNurse",OleDbType.VarChar),
                            new OleDbParameter(":SecondSupplyNurse",OleDbType.VarChar),
                            new OleDbParameter(":ThirdSupplyNurse",OleDbType.VarChar),
                            new OleDbParameter(":FourthSupplyNurse",OleDbType.VarChar),
                            new OleDbParameter(":PacuDoctor",OleDbType.VarChar),
                            new OleDbParameter(":FirstPacuAssistant",OleDbType.VarChar),
                            new OleDbParameter(":SecondPacuAssistant",OleDbType.VarChar),
                            new OleDbParameter(":FirstPacuNurse",OleDbType.VarChar),
                            new OleDbParameter(":SecondPacuNurse",OleDbType.VarChar),
                            new OleDbParameter(":ReqDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter(":ScheduledDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter(":InDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter(":OutDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter(":AnesStartTime",OleDbType.DBTimeStamp),
                            new OleDbParameter(":AnesEndTime",OleDbType.DBTimeStamp),
                            new OleDbParameter(":StartDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter(":EndDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter(":InPacuDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter(":OutPacuDateTime",OleDbType.DBTimeStamp),
                            new OleDbParameter(":OperStatusCode",OleDbType.VarChar),
                            new OleDbParameter(":OperPosition",OleDbType.VarChar),
                            new OleDbParameter(":BedNo",OleDbType.VarChar),
                            new OleDbParameter(":OperationName",OleDbType.VarChar),
                            new OleDbParameter(":PatWhereaborts",OleDbType.VarChar),
                            new OleDbParameter(":SatisfactionDegree",OleDbType.Decimal),
                            new OleDbParameter(":SmoothIndicator",OleDbType.Decimal),
                            new OleDbParameter(":EnteredBy",OleDbType.VarChar),
                            new OleDbParameter(":OrderTransfer",OleDbType.Decimal),
                            new OleDbParameter(":ChargeTransfer",OleDbType.Decimal),
                            new OleDbParameter(":EndIndicator",OleDbType.Decimal),
                            new OleDbParameter(":Memo",OleDbType.VarChar),
                            new OleDbParameter(":AnesthesiaId",OleDbType.VarChar),
                            new OleDbParameter(":HisPatientId",OleDbType.VarChar),
                            new OleDbParameter(":HisVisitId",OleDbType.VarChar),
                            new OleDbParameter(":HisScheduleId",OleDbType.VarChar),
                            new OleDbParameter(":HisOperStatus",OleDbType.VarChar),
                            new OleDbParameter(":RESERVED01",OleDbType.VarChar),
                            new OleDbParameter(":RESERVED02",OleDbType.VarChar),
                            new OleDbParameter(":RESERVED03",OleDbType.VarChar),
                            new OleDbParameter(":PatientId",OleDbType.VarChar),
                            new OleDbParameter(":VisitId",OleDbType.Decimal),
                            new OleDbParameter(":OperId",OleDbType.Decimal),
                        };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public int SelectMaxOperIdOLE(string patientId, decimal visitId)
        {
            OleDbParameter[] medMaxOperId = GetParameterOLE("SelectMaxOperIdMedOperationMaster");
            medMaxOperId[0].Value = patientId;
            medMaxOperId[1].Value = visitId;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_Max_OperId_Med_Operation_Master_OLE, medMaxOperId))
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

        public Model.MedOperationMaster SelectMedOperationMasterOLE(string patientId, decimal visitId, decimal operId)
        {
            Model.MedOperationMaster model = null;

            OleDbParameter[] medOperationMasterParams = GetParameterOLE("SelectOneMedOperationMaster");
            medOperationMasterParams[0].Value = patientId;
            medOperationMasterParams[1].Value = visitId;
            medOperationMasterParams[2].Value = operId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_One_Med_Operation_Master_OLE, medOperationMasterParams))
            {
                if (oleReader.Read())
                {
                    model = new MedicalSytem.Soft.Model.MedOperationMaster();
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
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OperDeptCode = oleReader["OPER_DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.OperRoom = oleReader["OPER_ROOM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.OperRoomNo = oleReader["OPER_ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Sequence = decimal.Parse(oleReader["SEQUENCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.OperClass = oleReader["OPER_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.DiagBeforeOperation = oleReader["DIAG_BEFORE_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.WoundNumber = decimal.Parse(oleReader["WOUND_NUMBER"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.AsaGrade = oleReader["ASA_GRADE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.DiagAfterOperation = oleReader["DIAG_AFTER_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.EmergencyInd = decimal.Parse(oleReader["EMERGENCY_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.OperSource = decimal.Parse(oleReader["OPER_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.IsolationInd = decimal.Parse(oleReader["ISOLATION_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.InfectedInd = decimal.Parse(oleReader["INFECTED_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.RadiateInd = decimal.Parse(oleReader["RADIATE_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Surgeon = oleReader["SURGEON"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.FirstOperAssistant = oleReader["FIRST_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.SecondOperAssistant = oleReader["SECOND_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.ThirdOperAssistant = oleReader["THIRD_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.FourthOperAssistant = oleReader["FOURTH_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.AnesMethod = oleReader["ANES_METHOD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.AnesDoctor = oleReader["ANES_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.FirstAnesAssistant = oleReader["FIRST_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.SecondAnesAssistant = oleReader["SECOND_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.ThirdAnesAssistant = oleReader["THIRD_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.FourthAnesAssistant = oleReader["FOURTH_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.FirstAnesNurse = oleReader["FIRST_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.SecondAnesNurse = oleReader["SECOND_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.ThirdAnesNurse = oleReader["THIRD_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.CpbDoctor = oleReader["CPB_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.FirstCpbAssistant = oleReader["FIRST_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.SecondCpbAssistant = oleReader["SECOND_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.ThirdCpbAssistant = oleReader["THIRD_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.FourthCpbAssistant = oleReader["FOURTH_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(42))
                    {
                        model.FirstOperNurse = oleReader["FIRST_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(43))
                    {
                        model.SecondOperNurse = oleReader["SECOND_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(44))
                    {
                        model.ThirdOperNurse = oleReader["THIRD_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(45))
                    {
                        model.FourthOperNurse = oleReader["FOURTH_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(46))
                    {
                        model.FirstSupplyNurse = oleReader["FIRST_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(47))
                    {
                        model.SecondSupplyNurse = oleReader["SECOND_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(48))
                    {
                        model.ThirdSupplyNurse = oleReader["THIRD_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(49))
                    {
                        model.FourthSupplyNurse = oleReader["FOURTH_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(50))
                    {
                        model.PacuDoctor = oleReader["PACU_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(51))
                    {
                        model.FirstPacuAssistant = oleReader["FIRST_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(52))
                    {
                        model.SecondPacuAssistant = oleReader["SECOND_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(53))
                    {
                        model.FirstPacuNurse = oleReader["FIRST_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(54))
                    {
                        model.SecondPacuNurse = oleReader["SECOND_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(55))
                    {
                        model.ReqDateTime = DateTime.Parse(oleReader["REQ_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(56))
                    {
                        model.ScheduledDateTime = DateTime.Parse(oleReader["SCHEDULED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(57))
                    {
                        model.InDateTime = DateTime.Parse(oleReader["IN_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(58))
                    {
                        model.OutDateTime = DateTime.Parse(oleReader["OUT_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(59))
                    {
                        model.AnesStartTime = DateTime.Parse(oleReader["ANES_START_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(60))
                    {
                        model.AnesEndTime = DateTime.Parse(oleReader["ANES_END_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(61))
                    {
                        model.StartDateTime = DateTime.Parse(oleReader["START_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(62))
                    {
                        model.EndDateTime = DateTime.Parse(oleReader["END_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(63))
                    {
                        model.InPacuDateTime = DateTime.Parse(oleReader["IN_PACU_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(64))
                    {
                        model.OutPacuDateTime = DateTime.Parse(oleReader["OUT_PACU_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(65))
                    {
                        model.OperStatusCode = oleReader["OPER_STATUS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(66))
                    {
                        model.OperPosition = oleReader["OPER_POSITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(67))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(68))
                    {
                        model.OperationName = oleReader["OPERATION_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(69))
                    {
                        model.PatWhereaborts = oleReader["PAT_WHEREABORTS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(70))
                    {
                        model.SatisfactionDegree = decimal.Parse(oleReader["SATISFACTION_DEGREE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(71))
                    {
                        model.SmoothIndicator = decimal.Parse(oleReader["SMOOTH_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(72))
                    {
                        model.EnteredBy = oleReader["ENTERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(73))
                    {
                        model.OrderTransfer = decimal.Parse(oleReader["ORDER_TRANSFER"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(74))
                    {
                        model.ChargeTransfer = decimal.Parse(oleReader["CHARGE_TRANSFER"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(75))
                    {
                        model.EndIndicator = decimal.Parse(oleReader["END_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(76))
                    {
                        model.Memo = oleReader["MEMO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(77))
                    {
                        model.AnesthesiaId = oleReader["ANESTHESIA_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(78))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(79))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(80))
                    {
                        model.HisScheduleId = oleReader["HIS_SCHEDULE_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(81))
                    {
                        model.HisOperStatus = oleReader["HIS_OPER_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(82))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(83))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(84))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }

        public List<Model.MedOperationMaster> SelectMedOperationMasterOLE(string patientId, decimal visitId)
        {
            List<Model.MedOperationMaster> MedOperationMasterList = new List<Model.MedOperationMaster>();

            OleDbParameter[] OperationMaster = GetParameterOLE("SelectPatOperationMaster");
            OperationMaster[0].Value = patientId;
            OperationMaster[1].Value = visitId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_Med_Operation_Master_OLE, OperationMaster))
            {
                while (oleReader.Read())
                {
                    Model.MedOperationMaster model = new Model.MedOperationMaster();
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
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OperDeptCode = oleReader["OPER_DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.OperRoom = oleReader["OPER_ROOM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.OperRoomNo = oleReader["OPER_ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Sequence = decimal.Parse(oleReader["SEQUENCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.OperClass = oleReader["OPER_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.DiagBeforeOperation = oleReader["DIAG_BEFORE_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.WoundNumber = decimal.Parse(oleReader["WOUND_NUMBER"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.AsaGrade = oleReader["ASA_GRADE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.DiagAfterOperation = oleReader["DIAG_AFTER_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.EmergencyInd = decimal.Parse(oleReader["EMERGENCY_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.OperSource = decimal.Parse(oleReader["OPER_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.IsolationInd = decimal.Parse(oleReader["ISOLATION_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.InfectedInd = decimal.Parse(oleReader["INFECTED_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.RadiateInd = decimal.Parse(oleReader["RADIATE_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Surgeon = oleReader["SURGEON"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.FirstOperAssistant = oleReader["FIRST_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.SecondOperAssistant = oleReader["SECOND_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.ThirdOperAssistant = oleReader["THIRD_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.FourthOperAssistant = oleReader["FOURTH_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.AnesMethod = oleReader["ANES_METHOD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.AnesDoctor = oleReader["ANES_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.FirstAnesAssistant = oleReader["FIRST_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.SecondAnesAssistant = oleReader["SECOND_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.ThirdAnesAssistant = oleReader["THIRD_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.FourthAnesAssistant = oleReader["FOURTH_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.FirstAnesNurse = oleReader["FIRST_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.SecondAnesNurse = oleReader["SECOND_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.ThirdAnesNurse = oleReader["THIRD_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.CpbDoctor = oleReader["CPB_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.FirstCpbAssistant = oleReader["FIRST_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.SecondCpbAssistant = oleReader["SECOND_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.ThirdCpbAssistant = oleReader["THIRD_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.FourthCpbAssistant = oleReader["FOURTH_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(42))
                    {
                        model.FirstOperNurse = oleReader["FIRST_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(43))
                    {
                        model.SecondOperNurse = oleReader["SECOND_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(44))
                    {
                        model.ThirdOperNurse = oleReader["THIRD_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(45))
                    {
                        model.FourthOperNurse = oleReader["FOURTH_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(46))
                    {
                        model.FirstSupplyNurse = oleReader["FIRST_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(47))
                    {
                        model.SecondSupplyNurse = oleReader["SECOND_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(48))
                    {
                        model.ThirdSupplyNurse = oleReader["THIRD_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(49))
                    {
                        model.FourthSupplyNurse = oleReader["FOURTH_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(50))
                    {
                        model.PacuDoctor = oleReader["PACU_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(51))
                    {
                        model.FirstPacuAssistant = oleReader["FIRST_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(52))
                    {
                        model.SecondPacuAssistant = oleReader["SECOND_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(53))
                    {
                        model.FirstPacuNurse = oleReader["FIRST_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(54))
                    {
                        model.SecondPacuNurse = oleReader["SECOND_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(55))
                    {
                        model.ReqDateTime = DateTime.Parse(oleReader["REQ_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(56))
                    {
                        model.ScheduledDateTime = DateTime.Parse(oleReader["SCHEDULED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(57))
                    {
                        model.InDateTime = DateTime.Parse(oleReader["IN_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(58))
                    {
                        model.OutDateTime = DateTime.Parse(oleReader["OUT_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(59))
                    {
                        model.AnesStartTime = DateTime.Parse(oleReader["ANES_START_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(60))
                    {
                        model.AnesEndTime = DateTime.Parse(oleReader["ANES_END_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(61))
                    {
                        model.StartDateTime = DateTime.Parse(oleReader["START_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(62))
                    {
                        model.EndDateTime = DateTime.Parse(oleReader["END_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(63))
                    {
                        model.InPacuDateTime = DateTime.Parse(oleReader["IN_PACU_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(64))
                    {
                        model.OutPacuDateTime = DateTime.Parse(oleReader["OUT_PACU_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(65))
                    {
                        model.OperStatusCode = oleReader["OPER_STATUS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(66))
                    {
                        model.OperPosition = oleReader["OPER_POSITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(67))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(68))
                    {
                        model.OperationName = oleReader["OPERATION_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(69))
                    {
                        model.PatWhereaborts = oleReader["PAT_WHEREABORTS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(70))
                    {
                        model.SatisfactionDegree = decimal.Parse(oleReader["SATISFACTION_DEGREE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(71))
                    {
                        model.SmoothIndicator = decimal.Parse(oleReader["SMOOTH_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(72))
                    {
                        model.EnteredBy = oleReader["ENTERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(73))
                    {
                        model.OrderTransfer = decimal.Parse(oleReader["ORDER_TRANSFER"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(74))
                    {
                        model.ChargeTransfer = decimal.Parse(oleReader["CHARGE_TRANSFER"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(75))
                    {
                        model.EndIndicator = decimal.Parse(oleReader["END_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(76))
                    {
                        model.Memo = oleReader["MEMO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(77))
                    {
                        model.AnesthesiaId = oleReader["ANESTHESIA_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(78))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(79))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(80))
                    {
                        model.HisScheduleId = oleReader["HIS_SCHEDULE_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(81))
                    {
                        model.HisOperStatus = oleReader["HIS_OPER_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(82))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(83))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(84))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    MedOperationMasterList.Add(model);
                }
            }
            return MedOperationMasterList;
        }

        public int InsertMedOperationMasterOLE(Model.MedOperationMaster model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedOperationMaster");
                oneInert[0].Value = model.PatientId;
                oneInert[1].Value = model.VisitId;
                oneInert[2].Value = model.OperId;
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
                if (model.HospBranch != null)
                    oneInert[3].Value = model.HospBranch;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneInert[4].Value = model.WardCode;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneInert[5].Value = model.DeptCode;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.OperDeptCode != null)
                    oneInert[6].Value = model.OperDeptCode;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.OperRoom != null)
                    oneInert[7].Value = model.OperRoom;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.OperRoomNo != null)
                    oneInert[8].Value = model.OperRoomNo;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Sequence != null)
                    oneInert[9].Value = model.Sequence;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.OperClass != null)
                    oneInert[10].Value = model.OperClass;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.DiagBeforeOperation != null)
                    oneInert[11].Value = model.DiagBeforeOperation;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.PatientCondition != null)
                    oneInert[12].Value = model.PatientCondition;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.OperScale != null)
                    oneInert[13].Value = model.OperScale;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.WoundType != null)
                    oneInert[14].Value = model.WoundType;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.WoundNumber != null)
                    oneInert[15].Value = model.WoundNumber;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.AsaGrade != null)
                    oneInert[16].Value = model.AsaGrade;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.DiagAfterOperation != null)
                    oneInert[17].Value = model.DiagAfterOperation;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.EmergencyInd != null)
                    oneInert[18].Value = model.EmergencyInd;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.OperSource != null)
                    oneInert[19].Value = model.OperSource;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.IsolationInd != null)
                    oneInert[20].Value = model.IsolationInd;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.InfectedInd != null)
                    oneInert[21].Value = model.InfectedInd;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.RadiateInd != null)
                    oneInert[22].Value = model.RadiateInd;
                else
                    oneInert[22].Value = DBNull.Value;
                if (model.Surgeon != null)
                    oneInert[23].Value = model.Surgeon;
                else
                    oneInert[23].Value = DBNull.Value;
                if (model.FirstOperAssistant != null)
                    oneInert[24].Value = model.FirstOperAssistant;
                else
                    oneInert[24].Value = DBNull.Value;
                if (model.SecondOperAssistant != null)
                    oneInert[25].Value = model.SecondOperAssistant;
                else
                    oneInert[25].Value = DBNull.Value;
                if (model.ThirdOperAssistant != null)
                    oneInert[26].Value = model.ThirdOperAssistant;
                else
                    oneInert[26].Value = DBNull.Value;
                if (model.FourthOperAssistant != null)
                    oneInert[27].Value = model.FourthOperAssistant;
                else
                    oneInert[27].Value = DBNull.Value;
                if (model.AnesMethod != null)
                    oneInert[28].Value = model.AnesMethod;
                else
                    oneInert[28].Value = DBNull.Value;
                if (model.AnesDoctor != null)
                    oneInert[29].Value = model.AnesDoctor;
                else
                    oneInert[29].Value = DBNull.Value;
                if (model.FirstAnesAssistant != null)
                    oneInert[30].Value = model.FirstAnesAssistant;
                else
                    oneInert[30].Value = DBNull.Value;
                if (model.SecondAnesAssistant != null)
                    oneInert[31].Value = model.SecondAnesAssistant;
                else
                    oneInert[31].Value = DBNull.Value;
                if (model.ThirdAnesAssistant != null)
                    oneInert[32].Value = model.ThirdAnesAssistant;
                else
                    oneInert[32].Value = DBNull.Value;
                if (model.FourthAnesAssistant != null)
                    oneInert[33].Value = model.FourthAnesAssistant;
                else
                    oneInert[33].Value = DBNull.Value;
                if (model.FirstAnesNurse != null)
                    oneInert[34].Value = model.FirstAnesNurse;
                else
                    oneInert[34].Value = DBNull.Value;
                if (model.SecondAnesNurse != null)
                    oneInert[35].Value = model.SecondAnesNurse;
                else
                    oneInert[35].Value = DBNull.Value;
                if (model.ThirdAnesNurse != null)
                    oneInert[36].Value = model.ThirdAnesNurse;
                else
                    oneInert[36].Value = DBNull.Value;
                if (model.CpbDoctor != null)
                    oneInert[37].Value = model.CpbDoctor;
                else
                    oneInert[37].Value = DBNull.Value;
                if (model.FirstCpbAssistant != null)
                    oneInert[38].Value = model.FirstCpbAssistant;
                else
                    oneInert[38].Value = DBNull.Value;
                if (model.SecondCpbAssistant != null)
                    oneInert[39].Value = model.SecondCpbAssistant;
                else
                    oneInert[39].Value = DBNull.Value;
                if (model.ThirdCpbAssistant != null)
                    oneInert[40].Value = model.ThirdCpbAssistant;
                else
                    oneInert[40].Value = DBNull.Value;
                if (model.FourthCpbAssistant != null)
                    oneInert[41].Value = model.FourthCpbAssistant;
                else
                    oneInert[41].Value = DBNull.Value;
                if (model.FirstOperNurse != null)
                    oneInert[42].Value = model.FirstOperNurse;
                else
                    oneInert[42].Value = DBNull.Value;
                if (model.SecondOperNurse != null)
                    oneInert[43].Value = model.SecondOperNurse;
                else
                    oneInert[43].Value = DBNull.Value;
                if (model.ThirdOperNurse != null)
                    oneInert[44].Value = model.ThirdOperNurse;
                else
                    oneInert[44].Value = DBNull.Value;
                if (model.FourthOperNurse != null)
                    oneInert[45].Value = model.FourthOperNurse;
                else
                    oneInert[45].Value = DBNull.Value;
                if (model.FirstSupplyNurse != null)
                    oneInert[46].Value = model.FirstSupplyNurse;
                else
                    oneInert[46].Value = DBNull.Value;
                if (model.SecondSupplyNurse != null)
                    oneInert[47].Value = model.SecondSupplyNurse;
                else
                    oneInert[47].Value = DBNull.Value;
                if (model.ThirdSupplyNurse != null)
                    oneInert[48].Value = model.ThirdSupplyNurse;
                else
                    oneInert[48].Value = DBNull.Value;
                if (model.FourthSupplyNurse != null)
                    oneInert[49].Value = model.FourthSupplyNurse;
                else
                    oneInert[49].Value = DBNull.Value;
                if (model.PacuDoctor != null)
                    oneInert[50].Value = model.PacuDoctor;
                else
                    oneInert[50].Value = DBNull.Value;
                if (model.FirstPacuAssistant != null)
                    oneInert[51].Value = model.FirstPacuAssistant;
                else
                    oneInert[51].Value = DBNull.Value;
                if (model.SecondPacuAssistant != null)
                    oneInert[52].Value = model.SecondPacuAssistant;
                else
                    oneInert[52].Value = DBNull.Value;
                if (model.FirstPacuNurse != null)
                    oneInert[53].Value = model.FirstPacuNurse;
                else
                    oneInert[53].Value = DBNull.Value;
                if (model.SecondPacuNurse != null)
                    oneInert[54].Value = model.SecondPacuNurse;
                else
                    oneInert[54].Value = DBNull.Value;
                if (model.ReqDateTime != null)
                    oneInert[55].Value = model.ReqDateTime;
                else
                    oneInert[55].Value = DBNull.Value;
                if (model.ScheduledDateTime != null)
                    oneInert[56].Value = model.ScheduledDateTime;
                else
                    oneInert[56].Value = DBNull.Value;
                if (model.InDateTime != null)
                    oneInert[57].Value = model.InDateTime;
                else
                    oneInert[57].Value = DBNull.Value;
                if (model.OutDateTime != null)
                    oneInert[58].Value = model.OutDateTime;
                else
                    oneInert[58].Value = DBNull.Value;
                if (model.AnesStartTime != null)
                    oneInert[59].Value = model.AnesStartTime;
                else
                    oneInert[59].Value = DBNull.Value;
                if (model.AnesEndTime != null)
                    oneInert[60].Value = model.AnesEndTime;
                else
                    oneInert[60].Value = DBNull.Value;
                if (model.StartDateTime != null)
                    oneInert[61].Value = model.StartDateTime;
                else
                    oneInert[61].Value = DBNull.Value;
                if (model.EndDateTime != null)
                    oneInert[62].Value = model.EndDateTime;
                else
                    oneInert[62].Value = DBNull.Value;
                if (model.InPacuDateTime != null)
                    oneInert[63].Value = model.InPacuDateTime;
                else
                    oneInert[63].Value = DBNull.Value;
                if (model.OutPacuDateTime != null)
                    oneInert[64].Value = model.OutPacuDateTime;
                else
                    oneInert[64].Value = DBNull.Value;
                if (model.OperStatusCode != null)
                    oneInert[65].Value = model.OperStatusCode;
                else
                    oneInert[65].Value = DBNull.Value;
                if (model.OperPosition != null)
                    oneInert[66].Value = model.OperPosition;
                else
                    oneInert[66].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneInert[67].Value = model.BedNo;
                else
                    oneInert[67].Value = DBNull.Value;
                if (model.OperationName != null)
                    oneInert[68].Value = model.OperationName;
                else
                    oneInert[68].Value = DBNull.Value;
                if (model.PatWhereaborts != null)
                    oneInert[69].Value = model.PatWhereaborts;
                else
                    oneInert[69].Value = DBNull.Value;
                if (model.SatisfactionDegree != null)
                    oneInert[70].Value = model.SatisfactionDegree;
                else
                    oneInert[70].Value = DBNull.Value;
                if (model.SmoothIndicator != null)
                    oneInert[71].Value = model.SmoothIndicator;
                else
                    oneInert[71].Value = DBNull.Value;
                if (model.EnteredBy != null)
                    oneInert[72].Value = model.EnteredBy;
                else
                    oneInert[72].Value = DBNull.Value;
                if (model.OrderTransfer != null)
                    oneInert[73].Value = model.OrderTransfer;
                else
                    oneInert[73].Value = DBNull.Value;
                if (model.ChargeTransfer != null)
                    oneInert[74].Value = model.ChargeTransfer;
                else
                    oneInert[74].Value = DBNull.Value;
                if (model.EndIndicator != null)
                    oneInert[75].Value = model.EndIndicator;
                else
                    oneInert[75].Value = DBNull.Value;
                if (model.Memo != null)
                    oneInert[76].Value = model.Memo;
                else
                    oneInert[76].Value = DBNull.Value;
                if (model.AnesthesiaId != null)
                    oneInert[77].Value = model.AnesthesiaId;
                else
                    oneInert[77].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneInert[78].Value = model.HisPatientId;
                else
                    oneInert[78].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneInert[79].Value = model.HisVisitId;
                else
                    oneInert[79].Value = DBNull.Value;
                if (model.HisScheduleId != null)
                    oneInert[80].Value = model.HisScheduleId;
                else
                    oneInert[80].Value = DBNull.Value;
                if (model.HisOperStatus != null)
                    oneInert[81].Value = model.HisOperStatus;
                else
                    oneInert[81].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneInert[82].Value = model.Reserved01;
                else
                    oneInert[82].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneInert[83].Value = model.Reserved02;
                else
                    oneInert[83].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneInert[84].Value = model.Reserved03;
                else
                    oneInert[84].Value = DBNull.Value;
                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_Med_Operation_Master_OLE, oneInert);
            }
        }

        public int UpdateMedOperationMasterOLE(Model.MedOperationMaster model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedOperationMaster");

                if (model.HospBranch != null)
                    oneUpdate[0].Value = model.HospBranch;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneUpdate[1].Value = model.WardCode;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneUpdate[2].Value = model.DeptCode;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.OperDeptCode != null)
                    oneUpdate[3].Value = model.OperDeptCode;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.OperRoom != null)
                    oneUpdate[4].Value = model.OperRoom;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.OperRoomNo != null)
                    oneUpdate[5].Value = model.OperRoomNo;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.Sequence != null)
                    oneUpdate[6].Value = model.Sequence;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.OperClass != null)
                    oneUpdate[7].Value = model.OperClass;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.DiagBeforeOperation != null)
                    oneUpdate[8].Value = model.DiagBeforeOperation;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.PatientCondition != null)
                    oneUpdate[9].Value = model.PatientCondition;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.OperScale != null)
                    oneUpdate[10].Value = model.OperScale;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.WoundType != null)
                    oneUpdate[11].Value = model.WoundType;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.WoundNumber != null)
                    oneUpdate[12].Value = model.WoundNumber;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.AsaGrade != null)
                    oneUpdate[13].Value = model.AsaGrade;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.DiagAfterOperation != null)
                    oneUpdate[14].Value = model.DiagAfterOperation;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.EmergencyInd != null)
                    oneUpdate[15].Value = model.EmergencyInd;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.OperSource != null)
                    oneUpdate[16].Value = model.OperSource;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.IsolationInd != null)
                    oneUpdate[17].Value = model.IsolationInd;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.InfectedInd != null)
                    oneUpdate[18].Value = model.InfectedInd;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.RadiateInd != null)
                    oneUpdate[19].Value = model.RadiateInd;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.Surgeon != null)
                    oneUpdate[20].Value = model.Surgeon;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.FirstOperAssistant != null)
                    oneUpdate[21].Value = model.FirstOperAssistant;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.SecondOperAssistant != null)
                    oneUpdate[22].Value = model.SecondOperAssistant;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.ThirdOperAssistant != null)
                    oneUpdate[23].Value = model.ThirdOperAssistant;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.FourthOperAssistant != null)
                    oneUpdate[24].Value = model.FourthOperAssistant;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.AnesMethod != null)
                    oneUpdate[25].Value = model.AnesMethod;
                else
                    oneUpdate[25].Value = DBNull.Value;
                if (model.AnesDoctor != null)
                    oneUpdate[26].Value = model.AnesDoctor;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (model.FirstAnesAssistant != null)
                    oneUpdate[27].Value = model.FirstAnesAssistant;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (model.SecondAnesAssistant != null)
                    oneUpdate[28].Value = model.SecondAnesAssistant;
                else
                    oneUpdate[28].Value = DBNull.Value;
                if (model.ThirdAnesAssistant != null)
                    oneUpdate[29].Value = model.ThirdAnesAssistant;
                else
                    oneUpdate[29].Value = DBNull.Value;
                if (model.FourthAnesAssistant != null)
                    oneUpdate[30].Value = model.FourthAnesAssistant;
                else
                    oneUpdate[30].Value = DBNull.Value;
                if (model.FirstAnesNurse != null)
                    oneUpdate[31].Value = model.FirstAnesNurse;
                else
                    oneUpdate[31].Value = DBNull.Value;
                if (model.SecondAnesNurse != null)
                    oneUpdate[32].Value = model.SecondAnesNurse;
                else
                    oneUpdate[32].Value = DBNull.Value;
                if (model.ThirdAnesNurse != null)
                    oneUpdate[33].Value = model.ThirdAnesNurse;
                else
                    oneUpdate[33].Value = DBNull.Value;
                if (model.CpbDoctor != null)
                    oneUpdate[34].Value = model.CpbDoctor;
                else
                    oneUpdate[34].Value = DBNull.Value;
                if (model.FirstCpbAssistant != null)
                    oneUpdate[35].Value = model.FirstCpbAssistant;
                else
                    oneUpdate[35].Value = DBNull.Value;
                if (model.SecondCpbAssistant != null)
                    oneUpdate[36].Value = model.SecondCpbAssistant;
                else
                    oneUpdate[36].Value = DBNull.Value;
                if (model.ThirdCpbAssistant != null)
                    oneUpdate[37].Value = model.ThirdCpbAssistant;
                else
                    oneUpdate[37].Value = DBNull.Value;
                if (model.FourthCpbAssistant != null)
                    oneUpdate[38].Value = model.FourthCpbAssistant;
                else
                    oneUpdate[38].Value = DBNull.Value;
                if (model.FirstOperNurse != null)
                    oneUpdate[39].Value = model.FirstOperNurse;
                else
                    oneUpdate[39].Value = DBNull.Value;
                if (model.SecondOperNurse != null)
                    oneUpdate[40].Value = model.SecondOperNurse;
                else
                    oneUpdate[40].Value = DBNull.Value;
                if (model.ThirdOperNurse != null)
                    oneUpdate[41].Value = model.ThirdOperNurse;
                else
                    oneUpdate[41].Value = DBNull.Value;
                if (model.FourthOperNurse != null)
                    oneUpdate[42].Value = model.FourthOperNurse;
                else
                    oneUpdate[42].Value = DBNull.Value;
                if (model.FirstSupplyNurse != null)
                    oneUpdate[43].Value = model.FirstSupplyNurse;
                else
                    oneUpdate[43].Value = DBNull.Value;
                if (model.SecondSupplyNurse != null)
                    oneUpdate[44].Value = model.SecondSupplyNurse;
                else
                    oneUpdate[44].Value = DBNull.Value;
                if (model.ThirdSupplyNurse != null)
                    oneUpdate[45].Value = model.ThirdSupplyNurse;
                else
                    oneUpdate[45].Value = DBNull.Value;
                if (model.FourthSupplyNurse != null)
                    oneUpdate[46].Value = model.FourthSupplyNurse;
                else
                    oneUpdate[46].Value = DBNull.Value;
                if (model.PacuDoctor != null)
                    oneUpdate[47].Value = model.PacuDoctor;
                else
                    oneUpdate[47].Value = DBNull.Value;
                if (model.FirstPacuAssistant != null)
                    oneUpdate[48].Value = model.FirstPacuAssistant;
                else
                    oneUpdate[48].Value = DBNull.Value;
                if (model.SecondPacuAssistant != null)
                    oneUpdate[49].Value = model.SecondPacuAssistant;
                else
                    oneUpdate[49].Value = DBNull.Value;
                if (model.FirstPacuNurse != null)
                    oneUpdate[50].Value = model.FirstPacuNurse;
                else
                    oneUpdate[50].Value = DBNull.Value;
                if (model.SecondPacuNurse != null)
                    oneUpdate[51].Value = model.SecondPacuNurse;
                else
                    oneUpdate[51].Value = DBNull.Value;
                if (model.ReqDateTime != null)
                    oneUpdate[52].Value = model.ReqDateTime;
                else
                    oneUpdate[52].Value = DBNull.Value;
                if (model.ScheduledDateTime != null)
                    oneUpdate[53].Value = model.ScheduledDateTime;
                else
                    oneUpdate[53].Value = DBNull.Value;
                if (model.InDateTime != null)
                    oneUpdate[54].Value = model.InDateTime;
                else
                    oneUpdate[54].Value = DBNull.Value;
                if (model.OutDateTime != null)
                    oneUpdate[55].Value = model.OutDateTime;
                else
                    oneUpdate[55].Value = DBNull.Value;
                if (model.AnesStartTime != null)
                    oneUpdate[56].Value = model.AnesStartTime;
                else
                    oneUpdate[56].Value = DBNull.Value;
                if (model.AnesEndTime != null)
                    oneUpdate[57].Value = model.AnesEndTime;
                else
                    oneUpdate[57].Value = DBNull.Value;
                if (model.StartDateTime != null)
                    oneUpdate[58].Value = model.StartDateTime;
                else
                    oneUpdate[58].Value = DBNull.Value;
                if (model.EndDateTime != null)
                    oneUpdate[59].Value = model.EndDateTime;
                else
                    oneUpdate[59].Value = DBNull.Value;
                if (model.InPacuDateTime != null)
                    oneUpdate[60].Value = model.InPacuDateTime;
                else
                    oneUpdate[60].Value = DBNull.Value;
                if (model.OutPacuDateTime != null)
                    oneUpdate[61].Value = model.OutPacuDateTime;
                else
                    oneUpdate[61].Value = DBNull.Value;
                if (model.OperStatusCode != null)
                    oneUpdate[62].Value = model.OperStatusCode;
                else
                    oneUpdate[62].Value = DBNull.Value;
                if (model.OperPosition != null)
                    oneUpdate[63].Value = model.OperPosition;
                else
                    oneUpdate[63].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneUpdate[64].Value = model.BedNo;
                else
                    oneUpdate[64].Value = DBNull.Value;
                if (model.OperationName != null)
                    oneUpdate[65].Value = model.OperationName;
                else
                    oneUpdate[65].Value = DBNull.Value;
                if (model.PatWhereaborts != null)
                    oneUpdate[66].Value = model.PatWhereaborts;
                else
                    oneUpdate[66].Value = DBNull.Value;
                if (model.SatisfactionDegree != null)
                    oneUpdate[67].Value = model.SatisfactionDegree;
                else
                    oneUpdate[67].Value = DBNull.Value;
                if (model.SmoothIndicator != null)
                    oneUpdate[68].Value = model.SmoothIndicator;
                else
                    oneUpdate[68].Value = DBNull.Value;
                if (model.EnteredBy != null)
                    oneUpdate[69].Value = model.EnteredBy;
                else
                    oneUpdate[69].Value = DBNull.Value;
                if (model.OrderTransfer != null)
                    oneUpdate[70].Value = model.OrderTransfer;
                else
                    oneUpdate[70].Value = DBNull.Value;
                if (model.ChargeTransfer != null)
                    oneUpdate[71].Value = model.ChargeTransfer;
                else
                    oneUpdate[71].Value = DBNull.Value;
                if (model.EndIndicator != null)
                    oneUpdate[72].Value = model.EndIndicator;
                else
                    oneUpdate[72].Value = DBNull.Value;
                if (model.Memo != null)
                    oneUpdate[73].Value = model.Memo;
                else
                    oneUpdate[73].Value = DBNull.Value;
                if (model.AnesthesiaId != null)
                    oneUpdate[74].Value = model.AnesthesiaId;
                else
                    oneUpdate[74].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneUpdate[75].Value = model.HisPatientId;
                else
                    oneUpdate[75].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneUpdate[76].Value = model.HisVisitId;
                else
                    oneUpdate[76].Value = DBNull.Value;
                if (model.HisScheduleId != null)
                    oneUpdate[77].Value = model.HisScheduleId;
                else
                    oneUpdate[77].Value = DBNull.Value;
                if (model.HisOperStatus != null)
                    oneUpdate[78].Value = model.HisOperStatus;
                else
                    oneUpdate[78].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneUpdate[79].Value = model.Reserved01;
                else
                    oneUpdate[79].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneUpdate[80].Value = model.Reserved02;
                else
                    oneUpdate[80].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneUpdate[81].Value = model.Reserved03;
                else
                    oneUpdate[81].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[82].Value = model.PatientId;
                else
                    oneUpdate[82].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneUpdate[83].Value = model.VisitId;
                else
                    oneUpdate[83].Value = DBNull.Value;
                if (model.OperId != null)
                    oneUpdate[84].Value = model.OperId;
                else
                    oneUpdate[84].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_Med_Operation_Master_OLE, oneUpdate);
            }
        }


        private static readonly string Select_One_Med_Operation_Master_Odbc = "select PATIENT_ID,VISIT_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,WOUND_NUMBER,ASA_GRADE,DIAG_AFTER_OPERATION,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,IN_DATE_TIME,OUT_DATE_TIME,ANES_START_TIME,ANES_END_TIME,START_DATE_TIME,END_DATE_TIME,IN_PACU_DATE_TIME,OUT_PACU_DATE_TIME,OPER_STATUS_CODE,OPER_POSITION,BED_NO,OPERATION_NAME,PAT_WHEREABORTS,SATISFACTION_DEGREE,SMOOTH_INDICATOR,ENTERED_BY,ORDER_TRANSFER,CHARGE_TRANSFER,END_INDICATOR,MEMO,ANESTHESIA_ID,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED01,RESERVED02,RESERVED03 from MED_OPERATION_MASTER WHERE PATIENT_ID=?  and VISIT_ID=? and OPER_ID=? ";
        private static readonly string Select_Med_Operation_Master_Odbc = "select PATIENT_ID,VISIT_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,WOUND_NUMBER,ASA_GRADE,DIAG_AFTER_OPERATION,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,IN_DATE_TIME,OUT_DATE_TIME,ANES_START_TIME,ANES_END_TIME,START_DATE_TIME,END_DATE_TIME,IN_PACU_DATE_TIME,OUT_PACU_DATE_TIME,OPER_STATUS_CODE,OPER_POSITION,BED_NO,OPERATION_NAME,PAT_WHEREABORTS,SATISFACTION_DEGREE,SMOOTH_INDICATOR,ENTERED_BY,ORDER_TRANSFER,CHARGE_TRANSFER,END_INDICATOR,MEMO,ANESTHESIA_ID,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED01,RESERVED02,RESERVED03 from MED_OPERATION_MASTER ";
        private static readonly string Select_Max_OperId_Med_Operation_Master_Odbc = "select nvl(max(oper_id),0) from med_operation_master where patient_id = ? and visit_id = ?";
        private static readonly string Insert_Med_Operation_Master_Odbc = "Insert into MED_OPERATION_MASTER  (PATIENT_ID,VISIT_ID,OPER_ID,HOSP_BRANCH,WARD_CODE,DEPT_CODE,OPER_DEPT_CODE,OPER_ROOM,OPER_ROOM_NO,SEQUENCE,OPER_CLASS,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPER_SCALE,WOUND_TYPE,WOUND_NUMBER,ASA_GRADE,DIAG_AFTER_OPERATION,EMERGENCY_IND,OPER_SOURCE,ISOLATION_IND,INFECTED_IND,RADIATE_IND,SURGEON,FIRST_OPER_ASSISTANT,SECOND_OPER_ASSISTANT,THIRD_OPER_ASSISTANT,FOURTH_OPER_ASSISTANT,ANES_METHOD,ANES_DOCTOR,FIRST_ANES_ASSISTANT,SECOND_ANES_ASSISTANT,THIRD_ANES_ASSISTANT,FOURTH_ANES_ASSISTANT,FIRST_ANES_NURSE,SECOND_ANES_NURSE,THIRD_ANES_NURSE,CPB_DOCTOR,FIRST_CPB_ASSISTANT,SECOND_CPB_ASSISTANT,THIRD_CPB_ASSISTANT,FOURTH_CPB_ASSISTANT,FIRST_OPER_NURSE,SECOND_OPER_NURSE,THIRD_OPER_NURSE,FOURTH_OPER_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,FOURTH_SUPPLY_NURSE,PACU_DOCTOR,FIRST_PACU_ASSISTANT,SECOND_PACU_ASSISTANT,FIRST_PACU_NURSE,SECOND_PACU_NURSE,REQ_DATE_TIME,SCHEDULED_DATE_TIME,IN_DATE_TIME,OUT_DATE_TIME,ANES_START_TIME,ANES_END_TIME,START_DATE_TIME,END_DATE_TIME,IN_PACU_DATE_TIME,OUT_PACU_DATE_TIME,OPER_STATUS_CODE,OPER_POSITION,BED_NO,OPERATION_NAME,PAT_WHEREABORTS,SATISFACTION_DEGREE,SMOOTH_INDICATOR,ENTERED_BY,ORDER_TRANSFER,CHARGE_TRANSFER,END_INDICATOR,MEMO,ANESTHESIA_ID,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,HIS_OPER_STATUS,RESERVED01,RESERVED02,RESERVED03) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string Update_Med_Operation_Master_Odbc = "Update MED_OPERATION_MASTER set HOSP_BRANCH=?,WARD_CODE=?,DEPT_CODE=?,OPER_DEPT_CODE=?,OPER_ROOM=?,OPER_ROOM_NO=?,SEQUENCE=?,OPER_CLASS=?,DIAG_BEFORE_OPERATION=?,PATIENT_CONDITION=?,OPER_SCALE=?,WOUND_TYPE=?,WOUND_NUMBER=?,ASA_GRADE=?,DIAG_AFTER_OPERATION=?,EMERGENCY_IND=?,OPER_SOURCE=?,ISOLATION_IND=?,INFECTED_IND=?,RADIATE_IND=?,SURGEON=?,FIRST_OPER_ASSISTANT=?,SECOND_OPER_ASSISTANT=?,THIRD_OPER_ASSISTANT=?,FOURTH_OPER_ASSISTANT=?,ANES_METHOD=?,ANES_DOCTOR=?,FIRST_ANES_ASSISTANT=?,SECOND_ANES_ASSISTANT=?,THIRD_ANES_ASSISTANT=?,FOURTH_ANES_ASSISTANT=?,FIRST_ANES_NURSE=?,SECOND_ANES_NURSE=?,THIRD_ANES_NURSE=?,CPB_DOCTOR=?,FIRST_CPB_ASSISTANT=?,SECOND_CPB_ASSISTANT=?,THIRD_CPB_ASSISTANT=?,FOURTH_CPB_ASSISTANT=?,FIRST_OPER_NURSE=?,SECOND_OPER_NURSE=?,THIRD_OPER_NURSE=?,FOURTH_OPER_NURSE=?,FIRST_SUPPLY_NURSE=?,SECOND_SUPPLY_NURSE=?,THIRD_SUPPLY_NURSE=?,FOURTH_SUPPLY_NURSE=?,PACU_DOCTOR=?,FIRST_PACU_ASSISTANT=?,SECOND_PACU_ASSISTANT=?,FIRST_PACU_NURSE=?,SECOND_PACU_NURSE=?,REQ_DATE_TIME=?,SCHEDULED_DATE_TIME=?,IN_DATE_TIME=?,OUT_DATE_TIME=?,ANES_START_TIME=?,ANES_END_TIME=?,START_DATE_TIME=?,END_DATE_TIME=?,IN_PACU_DATE_TIME=?,OUT_PACU_DATE_TIME=?,OPER_STATUS_CODE=?,OPER_POSITION=?,BED_NO=?,OPERATION_NAME=?,PAT_WHEREABORTS=?,SATISFACTION_DEGREE=?,SMOOTH_INDICATOR=?,ENTERED_BY=?,ORDER_TRANSFER=?,CHARGE_TRANSFER=?,END_INDICATOR=?,MEMO=?,ANESTHESIA_ID=?,HIS_PATIENT_ID=?,HIS_VISIT_ID=?,HIS_SCHEDULE_ID=?,HIS_OPER_STATUS=?,RESERVED01=?,RESERVED02=?,RESERVED03=? where PATIENT_ID=? and VISIT_ID=? and OPER_ID=?";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectOneMedOperationMaster")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("operId",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "SelectPatMedOperationMaster" || sqlParms == "SelectMaxOperIdMedOperationMaster")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "InsertMedOperationMaster")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("PatientId",OdbcType.VarChar),
                        new OdbcParameter("VisitId",OdbcType.Decimal),
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
                        new OdbcParameter("WoundNumber",OdbcType.Decimal),
                        new OdbcParameter("AsaGrade",OdbcType.VarChar),
                        new OdbcParameter("DiagAfterOperation",OdbcType.VarChar),
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
                        new OdbcParameter("InDateTime",OdbcType.DateTime),
                        new OdbcParameter("OutDateTime",OdbcType.DateTime),
                        new OdbcParameter("AnesStartTime",OdbcType.DateTime),
                        new OdbcParameter("AnesEndTime",OdbcType.DateTime),
                        new OdbcParameter("StartDateTime",OdbcType.DateTime),
                        new OdbcParameter("EndDateTime",OdbcType.DateTime),
                        new OdbcParameter("InPacuDateTime",OdbcType.DateTime),
                        new OdbcParameter("OutPacuDateTime",OdbcType.DateTime),
                        new OdbcParameter("OperStatusCode",OdbcType.VarChar),
                        new OdbcParameter("OperPosition",OdbcType.VarChar),
                        new OdbcParameter("BedNo",OdbcType.VarChar),
                        new OdbcParameter("OperationName",OdbcType.VarChar),
                        new OdbcParameter("PatWhereaborts",OdbcType.VarChar),
                        new OdbcParameter("SatisfactionDegree",OdbcType.Decimal),
                        new OdbcParameter("SmoothIndicator",OdbcType.Decimal),
                        new OdbcParameter("EnteredBy",OdbcType.VarChar),
                        new OdbcParameter("OrderTransfer",OdbcType.Decimal),
                        new OdbcParameter("ChargeTransfer",OdbcType.Decimal),
                        new OdbcParameter("EndIndicator",OdbcType.Decimal),
                        new OdbcParameter("Memo",OdbcType.VarChar),
                        new OdbcParameter("AnesthesiaId",OdbcType.VarChar),
                        new OdbcParameter("HisPatientId",OdbcType.VarChar),
                        new OdbcParameter("HisVisitId",OdbcType.VarChar),
                        new OdbcParameter("HisScheduleId",OdbcType.VarChar),
                        new OdbcParameter("HisOperStatus",OdbcType.VarChar),
                        new OdbcParameter("RESERVED01",OdbcType.VarChar),
                        new OdbcParameter("RESERVED02",OdbcType.VarChar),
                        new OdbcParameter("RESERVED03",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedOperationMaster")
                {
                    parms = new OdbcParameter[]{
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
                            new OdbcParameter("WoundNumber",OdbcType.Decimal),
                            new OdbcParameter("AsaGrade",OdbcType.VarChar),
                            new OdbcParameter("DiagAfterOperation",OdbcType.VarChar),
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
                            new OdbcParameter("InDateTime",OdbcType.DateTime),
                            new OdbcParameter("OutDateTime",OdbcType.DateTime),
                            new OdbcParameter("AnesStartTime",OdbcType.DateTime),
                            new OdbcParameter("AnesEndTime",OdbcType.DateTime),
                            new OdbcParameter("StartDateTime",OdbcType.DateTime),
                            new OdbcParameter("EndDateTime",OdbcType.DateTime),
                            new OdbcParameter("InPacuDateTime",OdbcType.DateTime),
                            new OdbcParameter("OutPacuDateTime",OdbcType.DateTime),
                            new OdbcParameter("OperStatusCode",OdbcType.VarChar),
                            new OdbcParameter("OperPosition",OdbcType.VarChar),
                            new OdbcParameter("BedNo",OdbcType.VarChar),
                            new OdbcParameter("OperationName",OdbcType.VarChar),
                            new OdbcParameter("PatWhereaborts",OdbcType.VarChar),
                            new OdbcParameter("SatisfactionDegree",OdbcType.Decimal),
                            new OdbcParameter("SmoothIndicator",OdbcType.Decimal),
                            new OdbcParameter("EnteredBy",OdbcType.VarChar),
                            new OdbcParameter("OrderTransfer",OdbcType.Decimal),
                            new OdbcParameter("ChargeTransfer",OdbcType.Decimal),
                            new OdbcParameter("EndIndicator",OdbcType.Decimal),
                            new OdbcParameter("Memo",OdbcType.VarChar),
                            new OdbcParameter("AnesthesiaId",OdbcType.VarChar),
                            new OdbcParameter("HisPatientId",OdbcType.VarChar),
                            new OdbcParameter("HisVisitId",OdbcType.VarChar),
                            new OdbcParameter("HisScheduleId",OdbcType.VarChar),
                            new OdbcParameter("HisOperStatus",OdbcType.VarChar),
                            new OdbcParameter("RESERVED01",OdbcType.VarChar),
                            new OdbcParameter("RESERVED02",OdbcType.VarChar),
                            new OdbcParameter("RESERVED03",OdbcType.VarChar),
                            new OdbcParameter("PatientId",OdbcType.VarChar),
                            new OdbcParameter("VisitId",OdbcType.Decimal),
                            new OdbcParameter("OperId",OdbcType.Decimal),
                        };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public int SelectMaxOperIdOdbc(string patientId, decimal visitId)
        {
            OdbcParameter[] medMaxOperId = GetParameterOdbc("SelectMaxOperIdMedOperationMaster");
            medMaxOperId[0].Value = patientId;
            medMaxOperId[1].Value = visitId;
            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_Max_OperId_Med_Operation_Master_Odbc, medMaxOperId))
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

        public Model.MedOperationMaster SelectMedOperationMasterOdbc(string patientId, decimal visitId, decimal operId)
        {
            Model.MedOperationMaster model = null;

            OdbcParameter[] medOperationMasterParams = GetParameterOdbc("SelectOneMedOperationMaster");
            medOperationMasterParams[0].Value = patientId;
            medOperationMasterParams[1].Value = visitId;
            medOperationMasterParams[2].Value = operId;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_One_Med_Operation_Master_Odbc, medOperationMasterParams))
            {
                if (oleReader.Read())
                {
                    model = new MedicalSytem.Soft.Model.MedOperationMaster();
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
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OperDeptCode = oleReader["OPER_DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.OperRoom = oleReader["OPER_ROOM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.OperRoomNo = oleReader["OPER_ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Sequence = decimal.Parse(oleReader["SEQUENCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.OperClass = oleReader["OPER_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.DiagBeforeOperation = oleReader["DIAG_BEFORE_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.WoundNumber = decimal.Parse(oleReader["WOUND_NUMBER"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.AsaGrade = oleReader["ASA_GRADE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.DiagAfterOperation = oleReader["DIAG_AFTER_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.EmergencyInd = decimal.Parse(oleReader["EMERGENCY_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.OperSource = decimal.Parse(oleReader["OPER_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.IsolationInd = decimal.Parse(oleReader["ISOLATION_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.InfectedInd = decimal.Parse(oleReader["INFECTED_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.RadiateInd = decimal.Parse(oleReader["RADIATE_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Surgeon = oleReader["SURGEON"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.FirstOperAssistant = oleReader["FIRST_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.SecondOperAssistant = oleReader["SECOND_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.ThirdOperAssistant = oleReader["THIRD_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.FourthOperAssistant = oleReader["FOURTH_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.AnesMethod = oleReader["ANES_METHOD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.AnesDoctor = oleReader["ANES_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.FirstAnesAssistant = oleReader["FIRST_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.SecondAnesAssistant = oleReader["SECOND_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.ThirdAnesAssistant = oleReader["THIRD_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.FourthAnesAssistant = oleReader["FOURTH_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.FirstAnesNurse = oleReader["FIRST_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.SecondAnesNurse = oleReader["SECOND_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.ThirdAnesNurse = oleReader["THIRD_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.CpbDoctor = oleReader["CPB_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.FirstCpbAssistant = oleReader["FIRST_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.SecondCpbAssistant = oleReader["SECOND_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.ThirdCpbAssistant = oleReader["THIRD_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.FourthCpbAssistant = oleReader["FOURTH_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(42))
                    {
                        model.FirstOperNurse = oleReader["FIRST_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(43))
                    {
                        model.SecondOperNurse = oleReader["SECOND_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(44))
                    {
                        model.ThirdOperNurse = oleReader["THIRD_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(45))
                    {
                        model.FourthOperNurse = oleReader["FOURTH_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(46))
                    {
                        model.FirstSupplyNurse = oleReader["FIRST_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(47))
                    {
                        model.SecondSupplyNurse = oleReader["SECOND_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(48))
                    {
                        model.ThirdSupplyNurse = oleReader["THIRD_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(49))
                    {
                        model.FourthSupplyNurse = oleReader["FOURTH_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(50))
                    {
                        model.PacuDoctor = oleReader["PACU_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(51))
                    {
                        model.FirstPacuAssistant = oleReader["FIRST_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(52))
                    {
                        model.SecondPacuAssistant = oleReader["SECOND_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(53))
                    {
                        model.FirstPacuNurse = oleReader["FIRST_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(54))
                    {
                        model.SecondPacuNurse = oleReader["SECOND_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(55))
                    {
                        model.ReqDateTime = DateTime.Parse(oleReader["REQ_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(56))
                    {
                        model.ScheduledDateTime = DateTime.Parse(oleReader["SCHEDULED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(57))
                    {
                        model.InDateTime = DateTime.Parse(oleReader["IN_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(58))
                    {
                        model.OutDateTime = DateTime.Parse(oleReader["OUT_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(59))
                    {
                        model.AnesStartTime = DateTime.Parse(oleReader["ANES_START_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(60))
                    {
                        model.AnesEndTime = DateTime.Parse(oleReader["ANES_END_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(61))
                    {
                        model.StartDateTime = DateTime.Parse(oleReader["START_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(62))
                    {
                        model.EndDateTime = DateTime.Parse(oleReader["END_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(63))
                    {
                        model.InPacuDateTime = DateTime.Parse(oleReader["IN_PACU_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(64))
                    {
                        model.OutPacuDateTime = DateTime.Parse(oleReader["OUT_PACU_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(65))
                    {
                        model.OperStatusCode = oleReader["OPER_STATUS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(66))
                    {
                        model.OperPosition = oleReader["OPER_POSITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(67))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(68))
                    {
                        model.OperationName = oleReader["OPERATION_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(69))
                    {
                        model.PatWhereaborts = oleReader["PAT_WHEREABORTS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(70))
                    {
                        model.SatisfactionDegree = decimal.Parse(oleReader["SATISFACTION_DEGREE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(71))
                    {
                        model.SmoothIndicator = decimal.Parse(oleReader["SMOOTH_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(72))
                    {
                        model.EnteredBy = oleReader["ENTERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(73))
                    {
                        model.OrderTransfer = decimal.Parse(oleReader["ORDER_TRANSFER"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(74))
                    {
                        model.ChargeTransfer = decimal.Parse(oleReader["CHARGE_TRANSFER"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(75))
                    {
                        model.EndIndicator = decimal.Parse(oleReader["END_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(76))
                    {
                        model.Memo = oleReader["MEMO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(77))
                    {
                        model.AnesthesiaId = oleReader["ANESTHESIA_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(78))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(79))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(80))
                    {
                        model.HisScheduleId = oleReader["HIS_SCHEDULE_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(81))
                    {
                        model.HisOperStatus = oleReader["HIS_OPER_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(82))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(83))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(84))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }

        public List<Model.MedOperationMaster> SelectMedOperationMasterOdbc(string patientId, decimal visitId)
        {
            List<Model.MedOperationMaster> MedOperationMasterList = new List<Model.MedOperationMaster>();

            OdbcParameter[] OperationMaster = GetParameterOdbc("SelectPatOperationMaster");
            OperationMaster[0].Value = patientId;
            OperationMaster[1].Value = visitId;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_Med_Operation_Master_Odbc, OperationMaster))
            {
                while (oleReader.Read())
                {
                    Model.MedOperationMaster model = new Model.MedOperationMaster();
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
                        model.HospBranch = oleReader["HOSP_BRANCH"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OperDeptCode = oleReader["OPER_DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.OperRoom = oleReader["OPER_ROOM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.OperRoomNo = oleReader["OPER_ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Sequence = decimal.Parse(oleReader["SEQUENCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.OperClass = oleReader["OPER_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.DiagBeforeOperation = oleReader["DIAG_BEFORE_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.WoundNumber = decimal.Parse(oleReader["WOUND_NUMBER"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.AsaGrade = oleReader["ASA_GRADE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.DiagAfterOperation = oleReader["DIAG_AFTER_OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.EmergencyInd = decimal.Parse(oleReader["EMERGENCY_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.OperSource = decimal.Parse(oleReader["OPER_SOURCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.IsolationInd = decimal.Parse(oleReader["ISOLATION_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.InfectedInd = decimal.Parse(oleReader["INFECTED_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.RadiateInd = decimal.Parse(oleReader["RADIATE_IND"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Surgeon = oleReader["SURGEON"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.FirstOperAssistant = oleReader["FIRST_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.SecondOperAssistant = oleReader["SECOND_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.ThirdOperAssistant = oleReader["THIRD_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.FourthOperAssistant = oleReader["FOURTH_OPER_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.AnesMethod = oleReader["ANES_METHOD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.AnesDoctor = oleReader["ANES_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.FirstAnesAssistant = oleReader["FIRST_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.SecondAnesAssistant = oleReader["SECOND_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.ThirdAnesAssistant = oleReader["THIRD_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.FourthAnesAssistant = oleReader["FOURTH_ANES_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.FirstAnesNurse = oleReader["FIRST_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.SecondAnesNurse = oleReader["SECOND_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.ThirdAnesNurse = oleReader["THIRD_ANES_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.CpbDoctor = oleReader["CPB_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.FirstCpbAssistant = oleReader["FIRST_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.SecondCpbAssistant = oleReader["SECOND_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.ThirdCpbAssistant = oleReader["THIRD_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.FourthCpbAssistant = oleReader["FOURTH_CPB_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(42))
                    {
                        model.FirstOperNurse = oleReader["FIRST_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(43))
                    {
                        model.SecondOperNurse = oleReader["SECOND_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(44))
                    {
                        model.ThirdOperNurse = oleReader["THIRD_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(45))
                    {
                        model.FourthOperNurse = oleReader["FOURTH_OPER_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(46))
                    {
                        model.FirstSupplyNurse = oleReader["FIRST_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(47))
                    {
                        model.SecondSupplyNurse = oleReader["SECOND_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(48))
                    {
                        model.ThirdSupplyNurse = oleReader["THIRD_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(49))
                    {
                        model.FourthSupplyNurse = oleReader["FOURTH_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(50))
                    {
                        model.PacuDoctor = oleReader["PACU_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(51))
                    {
                        model.FirstPacuAssistant = oleReader["FIRST_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(52))
                    {
                        model.SecondPacuAssistant = oleReader["SECOND_PACU_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(53))
                    {
                        model.FirstPacuNurse = oleReader["FIRST_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(54))
                    {
                        model.SecondPacuNurse = oleReader["SECOND_PACU_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(55))
                    {
                        model.ReqDateTime = DateTime.Parse(oleReader["REQ_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(56))
                    {
                        model.ScheduledDateTime = DateTime.Parse(oleReader["SCHEDULED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(57))
                    {
                        model.InDateTime = DateTime.Parse(oleReader["IN_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(58))
                    {
                        model.OutDateTime = DateTime.Parse(oleReader["OUT_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(59))
                    {
                        model.AnesStartTime = DateTime.Parse(oleReader["ANES_START_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(60))
                    {
                        model.AnesEndTime = DateTime.Parse(oleReader["ANES_END_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(61))
                    {
                        model.StartDateTime = DateTime.Parse(oleReader["START_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(62))
                    {
                        model.EndDateTime = DateTime.Parse(oleReader["END_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(63))
                    {
                        model.InPacuDateTime = DateTime.Parse(oleReader["IN_PACU_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(64))
                    {
                        model.OutPacuDateTime = DateTime.Parse(oleReader["OUT_PACU_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(65))
                    {
                        model.OperStatusCode = oleReader["OPER_STATUS_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(66))
                    {
                        model.OperPosition = oleReader["OPER_POSITION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(67))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(68))
                    {
                        model.OperationName = oleReader["OPERATION_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(69))
                    {
                        model.PatWhereaborts = oleReader["PAT_WHEREABORTS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(70))
                    {
                        model.SatisfactionDegree = decimal.Parse(oleReader["SATISFACTION_DEGREE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(71))
                    {
                        model.SmoothIndicator = decimal.Parse(oleReader["SMOOTH_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(72))
                    {
                        model.EnteredBy = oleReader["ENTERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(73))
                    {
                        model.OrderTransfer = decimal.Parse(oleReader["ORDER_TRANSFER"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(74))
                    {
                        model.ChargeTransfer = decimal.Parse(oleReader["CHARGE_TRANSFER"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(75))
                    {
                        model.EndIndicator = decimal.Parse(oleReader["END_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(76))
                    {
                        model.Memo = oleReader["MEMO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(77))
                    {
                        model.AnesthesiaId = oleReader["ANESTHESIA_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(78))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(79))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(80))
                    {
                        model.HisScheduleId = oleReader["HIS_SCHEDULE_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(81))
                    {
                        model.HisOperStatus = oleReader["HIS_OPER_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(82))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(83))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(84))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    MedOperationMasterList.Add(model);
                }
            }
            return MedOperationMasterList;
        }

        public int InsertMedOperationMasterOdbc(Model.MedOperationMaster model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedOperationMaster");
                oneInert[0].Value = model.PatientId;
                oneInert[1].Value = model.VisitId;
                oneInert[2].Value = model.OperId;
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
                if (model.HospBranch != null)
                    oneInert[3].Value = model.HospBranch;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneInert[4].Value = model.WardCode;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneInert[5].Value = model.DeptCode;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.OperDeptCode != null)
                    oneInert[6].Value = model.OperDeptCode;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.OperRoom != null)
                    oneInert[7].Value = model.OperRoom;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.OperRoomNo != null)
                    oneInert[8].Value = model.OperRoomNo;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Sequence != null)
                    oneInert[9].Value = model.Sequence;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.OperClass != null)
                    oneInert[10].Value = model.OperClass;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.DiagBeforeOperation != null)
                    oneInert[11].Value = model.DiagBeforeOperation;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.PatientCondition != null)
                    oneInert[12].Value = model.PatientCondition;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.OperScale != null)
                    oneInert[13].Value = model.OperScale;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.WoundType != null)
                    oneInert[14].Value = model.WoundType;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.WoundNumber != null)
                    oneInert[15].Value = model.WoundNumber;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.AsaGrade != null)
                    oneInert[16].Value = model.AsaGrade;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.DiagAfterOperation != null)
                    oneInert[17].Value = model.DiagAfterOperation;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.EmergencyInd != null)
                    oneInert[18].Value = model.EmergencyInd;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.OperSource != null)
                    oneInert[19].Value = model.OperSource;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.IsolationInd != null)
                    oneInert[20].Value = model.IsolationInd;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.InfectedInd != null)
                    oneInert[21].Value = model.InfectedInd;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.RadiateInd != null)
                    oneInert[22].Value = model.RadiateInd;
                else
                    oneInert[22].Value = DBNull.Value;
                if (model.Surgeon != null)
                    oneInert[23].Value = model.Surgeon;
                else
                    oneInert[23].Value = DBNull.Value;
                if (model.FirstOperAssistant != null)
                    oneInert[24].Value = model.FirstOperAssistant;
                else
                    oneInert[24].Value = DBNull.Value;
                if (model.SecondOperAssistant != null)
                    oneInert[25].Value = model.SecondOperAssistant;
                else
                    oneInert[25].Value = DBNull.Value;
                if (model.ThirdOperAssistant != null)
                    oneInert[26].Value = model.ThirdOperAssistant;
                else
                    oneInert[26].Value = DBNull.Value;
                if (model.FourthOperAssistant != null)
                    oneInert[27].Value = model.FourthOperAssistant;
                else
                    oneInert[27].Value = DBNull.Value;
                if (model.AnesMethod != null)
                    oneInert[28].Value = model.AnesMethod;
                else
                    oneInert[28].Value = DBNull.Value;
                if (model.AnesDoctor != null)
                    oneInert[29].Value = model.AnesDoctor;
                else
                    oneInert[29].Value = DBNull.Value;
                if (model.FirstAnesAssistant != null)
                    oneInert[30].Value = model.FirstAnesAssistant;
                else
                    oneInert[30].Value = DBNull.Value;
                if (model.SecondAnesAssistant != null)
                    oneInert[31].Value = model.SecondAnesAssistant;
                else
                    oneInert[31].Value = DBNull.Value;
                if (model.ThirdAnesAssistant != null)
                    oneInert[32].Value = model.ThirdAnesAssistant;
                else
                    oneInert[32].Value = DBNull.Value;
                if (model.FourthAnesAssistant != null)
                    oneInert[33].Value = model.FourthAnesAssistant;
                else
                    oneInert[33].Value = DBNull.Value;
                if (model.FirstAnesNurse != null)
                    oneInert[34].Value = model.FirstAnesNurse;
                else
                    oneInert[34].Value = DBNull.Value;
                if (model.SecondAnesNurse != null)
                    oneInert[35].Value = model.SecondAnesNurse;
                else
                    oneInert[35].Value = DBNull.Value;
                if (model.ThirdAnesNurse != null)
                    oneInert[36].Value = model.ThirdAnesNurse;
                else
                    oneInert[36].Value = DBNull.Value;
                if (model.CpbDoctor != null)
                    oneInert[37].Value = model.CpbDoctor;
                else
                    oneInert[37].Value = DBNull.Value;
                if (model.FirstCpbAssistant != null)
                    oneInert[38].Value = model.FirstCpbAssistant;
                else
                    oneInert[38].Value = DBNull.Value;
                if (model.SecondCpbAssistant != null)
                    oneInert[39].Value = model.SecondCpbAssistant;
                else
                    oneInert[39].Value = DBNull.Value;
                if (model.ThirdCpbAssistant != null)
                    oneInert[40].Value = model.ThirdCpbAssistant;
                else
                    oneInert[40].Value = DBNull.Value;
                if (model.FourthCpbAssistant != null)
                    oneInert[41].Value = model.FourthCpbAssistant;
                else
                    oneInert[41].Value = DBNull.Value;
                if (model.FirstOperNurse != null)
                    oneInert[42].Value = model.FirstOperNurse;
                else
                    oneInert[42].Value = DBNull.Value;
                if (model.SecondOperNurse != null)
                    oneInert[43].Value = model.SecondOperNurse;
                else
                    oneInert[43].Value = DBNull.Value;
                if (model.ThirdOperNurse != null)
                    oneInert[44].Value = model.ThirdOperNurse;
                else
                    oneInert[44].Value = DBNull.Value;
                if (model.FourthOperNurse != null)
                    oneInert[45].Value = model.FourthOperNurse;
                else
                    oneInert[45].Value = DBNull.Value;
                if (model.FirstSupplyNurse != null)
                    oneInert[46].Value = model.FirstSupplyNurse;
                else
                    oneInert[46].Value = DBNull.Value;
                if (model.SecondSupplyNurse != null)
                    oneInert[47].Value = model.SecondSupplyNurse;
                else
                    oneInert[47].Value = DBNull.Value;
                if (model.ThirdSupplyNurse != null)
                    oneInert[48].Value = model.ThirdSupplyNurse;
                else
                    oneInert[48].Value = DBNull.Value;
                if (model.FourthSupplyNurse != null)
                    oneInert[49].Value = model.FourthSupplyNurse;
                else
                    oneInert[49].Value = DBNull.Value;
                if (model.PacuDoctor != null)
                    oneInert[50].Value = model.PacuDoctor;
                else
                    oneInert[50].Value = DBNull.Value;
                if (model.FirstPacuAssistant != null)
                    oneInert[51].Value = model.FirstPacuAssistant;
                else
                    oneInert[51].Value = DBNull.Value;
                if (model.SecondPacuAssistant != null)
                    oneInert[52].Value = model.SecondPacuAssistant;
                else
                    oneInert[52].Value = DBNull.Value;
                if (model.FirstPacuNurse != null)
                    oneInert[53].Value = model.FirstPacuNurse;
                else
                    oneInert[53].Value = DBNull.Value;
                if (model.SecondPacuNurse != null)
                    oneInert[54].Value = model.SecondPacuNurse;
                else
                    oneInert[54].Value = DBNull.Value;
                if (model.ReqDateTime != null)
                    oneInert[55].Value = model.ReqDateTime;
                else
                    oneInert[55].Value = DBNull.Value;
                if (model.ScheduledDateTime != null)
                    oneInert[56].Value = model.ScheduledDateTime;
                else
                    oneInert[56].Value = DBNull.Value;
                if (model.InDateTime != null)
                    oneInert[57].Value = model.InDateTime;
                else
                    oneInert[57].Value = DBNull.Value;
                if (model.OutDateTime != null)
                    oneInert[58].Value = model.OutDateTime;
                else
                    oneInert[58].Value = DBNull.Value;
                if (model.AnesStartTime != null)
                    oneInert[59].Value = model.AnesStartTime;
                else
                    oneInert[59].Value = DBNull.Value;
                if (model.AnesEndTime != null)
                    oneInert[60].Value = model.AnesEndTime;
                else
                    oneInert[60].Value = DBNull.Value;
                if (model.StartDateTime != null)
                    oneInert[61].Value = model.StartDateTime;
                else
                    oneInert[61].Value = DBNull.Value;
                if (model.EndDateTime != null)
                    oneInert[62].Value = model.EndDateTime;
                else
                    oneInert[62].Value = DBNull.Value;
                if (model.InPacuDateTime != null)
                    oneInert[63].Value = model.InPacuDateTime;
                else
                    oneInert[63].Value = DBNull.Value;
                if (model.OutPacuDateTime != null)
                    oneInert[64].Value = model.OutPacuDateTime;
                else
                    oneInert[64].Value = DBNull.Value;
                if (model.OperStatusCode != null)
                    oneInert[65].Value = model.OperStatusCode;
                else
                    oneInert[65].Value = DBNull.Value;
                if (model.OperPosition != null)
                    oneInert[66].Value = model.OperPosition;
                else
                    oneInert[66].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneInert[67].Value = model.BedNo;
                else
                    oneInert[67].Value = DBNull.Value;
                if (model.OperationName != null)
                    oneInert[68].Value = model.OperationName;
                else
                    oneInert[68].Value = DBNull.Value;
                if (model.PatWhereaborts != null)
                    oneInert[69].Value = model.PatWhereaborts;
                else
                    oneInert[69].Value = DBNull.Value;
                if (model.SatisfactionDegree != null)
                    oneInert[70].Value = model.SatisfactionDegree;
                else
                    oneInert[70].Value = DBNull.Value;
                if (model.SmoothIndicator != null)
                    oneInert[71].Value = model.SmoothIndicator;
                else
                    oneInert[71].Value = DBNull.Value;
                if (model.EnteredBy != null)
                    oneInert[72].Value = model.EnteredBy;
                else
                    oneInert[72].Value = DBNull.Value;
                if (model.OrderTransfer != null)
                    oneInert[73].Value = model.OrderTransfer;
                else
                    oneInert[73].Value = DBNull.Value;
                if (model.ChargeTransfer != null)
                    oneInert[74].Value = model.ChargeTransfer;
                else
                    oneInert[74].Value = DBNull.Value;
                if (model.EndIndicator != null)
                    oneInert[75].Value = model.EndIndicator;
                else
                    oneInert[75].Value = DBNull.Value;
                if (model.Memo != null)
                    oneInert[76].Value = model.Memo;
                else
                    oneInert[76].Value = DBNull.Value;
                if (model.AnesthesiaId != null)
                    oneInert[77].Value = model.AnesthesiaId;
                else
                    oneInert[77].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneInert[78].Value = model.HisPatientId;
                else
                    oneInert[78].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneInert[79].Value = model.HisVisitId;
                else
                    oneInert[79].Value = DBNull.Value;
                if (model.HisScheduleId != null)
                    oneInert[80].Value = model.HisScheduleId;
                else
                    oneInert[80].Value = DBNull.Value;
                if (model.HisOperStatus != null)
                    oneInert[81].Value = model.HisOperStatus;
                else
                    oneInert[81].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneInert[82].Value = model.Reserved01;
                else
                    oneInert[82].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneInert[83].Value = model.Reserved02;
                else
                    oneInert[83].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneInert[84].Value = model.Reserved03;
                else
                    oneInert[84].Value = DBNull.Value;
                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_Med_Operation_Master_Odbc, oneInert);
            }
        }

        public int UpdateMedOperationMasterOdbc(Model.MedOperationMaster model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedOperationMaster");

                if (model.HospBranch != null)
                    oneUpdate[0].Value = model.HospBranch;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneUpdate[1].Value = model.WardCode;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneUpdate[2].Value = model.DeptCode;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.OperDeptCode != null)
                    oneUpdate[3].Value = model.OperDeptCode;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.OperRoom != null)
                    oneUpdate[4].Value = model.OperRoom;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.OperRoomNo != null)
                    oneUpdate[5].Value = model.OperRoomNo;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.Sequence != null)
                    oneUpdate[6].Value = model.Sequence;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.OperClass != null)
                    oneUpdate[7].Value = model.OperClass;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.DiagBeforeOperation != null)
                    oneUpdate[8].Value = model.DiagBeforeOperation;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.PatientCondition != null)
                    oneUpdate[9].Value = model.PatientCondition;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.OperScale != null)
                    oneUpdate[10].Value = model.OperScale;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.WoundType != null)
                    oneUpdate[11].Value = model.WoundType;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.WoundNumber != null)
                    oneUpdate[12].Value = model.WoundNumber;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.AsaGrade != null)
                    oneUpdate[13].Value = model.AsaGrade;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.DiagAfterOperation != null)
                    oneUpdate[14].Value = model.DiagAfterOperation;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.EmergencyInd != null)
                    oneUpdate[15].Value = model.EmergencyInd;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.OperSource != null)
                    oneUpdate[16].Value = model.OperSource;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.IsolationInd != null)
                    oneUpdate[17].Value = model.IsolationInd;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.InfectedInd != null)
                    oneUpdate[18].Value = model.InfectedInd;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.RadiateInd != null)
                    oneUpdate[19].Value = model.RadiateInd;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.Surgeon != null)
                    oneUpdate[20].Value = model.Surgeon;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.FirstOperAssistant != null)
                    oneUpdate[21].Value = model.FirstOperAssistant;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.SecondOperAssistant != null)
                    oneUpdate[22].Value = model.SecondOperAssistant;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.ThirdOperAssistant != null)
                    oneUpdate[23].Value = model.ThirdOperAssistant;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.FourthOperAssistant != null)
                    oneUpdate[24].Value = model.FourthOperAssistant;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.AnesMethod != null)
                    oneUpdate[25].Value = model.AnesMethod;
                else
                    oneUpdate[25].Value = DBNull.Value;
                if (model.AnesDoctor != null)
                    oneUpdate[26].Value = model.AnesDoctor;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (model.FirstAnesAssistant != null)
                    oneUpdate[27].Value = model.FirstAnesAssistant;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (model.SecondAnesAssistant != null)
                    oneUpdate[28].Value = model.SecondAnesAssistant;
                else
                    oneUpdate[28].Value = DBNull.Value;
                if (model.ThirdAnesAssistant != null)
                    oneUpdate[29].Value = model.ThirdAnesAssistant;
                else
                    oneUpdate[29].Value = DBNull.Value;
                if (model.FourthAnesAssistant != null)
                    oneUpdate[30].Value = model.FourthAnesAssistant;
                else
                    oneUpdate[30].Value = DBNull.Value;
                if (model.FirstAnesNurse != null)
                    oneUpdate[31].Value = model.FirstAnesNurse;
                else
                    oneUpdate[31].Value = DBNull.Value;
                if (model.SecondAnesNurse != null)
                    oneUpdate[32].Value = model.SecondAnesNurse;
                else
                    oneUpdate[32].Value = DBNull.Value;
                if (model.ThirdAnesNurse != null)
                    oneUpdate[33].Value = model.ThirdAnesNurse;
                else
                    oneUpdate[33].Value = DBNull.Value;
                if (model.CpbDoctor != null)
                    oneUpdate[34].Value = model.CpbDoctor;
                else
                    oneUpdate[34].Value = DBNull.Value;
                if (model.FirstCpbAssistant != null)
                    oneUpdate[35].Value = model.FirstCpbAssistant;
                else
                    oneUpdate[35].Value = DBNull.Value;
                if (model.SecondCpbAssistant != null)
                    oneUpdate[36].Value = model.SecondCpbAssistant;
                else
                    oneUpdate[36].Value = DBNull.Value;
                if (model.ThirdCpbAssistant != null)
                    oneUpdate[37].Value = model.ThirdCpbAssistant;
                else
                    oneUpdate[37].Value = DBNull.Value;
                if (model.FourthCpbAssistant != null)
                    oneUpdate[38].Value = model.FourthCpbAssistant;
                else
                    oneUpdate[38].Value = DBNull.Value;
                if (model.FirstOperNurse != null)
                    oneUpdate[39].Value = model.FirstOperNurse;
                else
                    oneUpdate[39].Value = DBNull.Value;
                if (model.SecondOperNurse != null)
                    oneUpdate[40].Value = model.SecondOperNurse;
                else
                    oneUpdate[40].Value = DBNull.Value;
                if (model.ThirdOperNurse != null)
                    oneUpdate[41].Value = model.ThirdOperNurse;
                else
                    oneUpdate[41].Value = DBNull.Value;
                if (model.FourthOperNurse != null)
                    oneUpdate[42].Value = model.FourthOperNurse;
                else
                    oneUpdate[42].Value = DBNull.Value;
                if (model.FirstSupplyNurse != null)
                    oneUpdate[43].Value = model.FirstSupplyNurse;
                else
                    oneUpdate[43].Value = DBNull.Value;
                if (model.SecondSupplyNurse != null)
                    oneUpdate[44].Value = model.SecondSupplyNurse;
                else
                    oneUpdate[44].Value = DBNull.Value;
                if (model.ThirdSupplyNurse != null)
                    oneUpdate[45].Value = model.ThirdSupplyNurse;
                else
                    oneUpdate[45].Value = DBNull.Value;
                if (model.FourthSupplyNurse != null)
                    oneUpdate[46].Value = model.FourthSupplyNurse;
                else
                    oneUpdate[46].Value = DBNull.Value;
                if (model.PacuDoctor != null)
                    oneUpdate[47].Value = model.PacuDoctor;
                else
                    oneUpdate[47].Value = DBNull.Value;
                if (model.FirstPacuAssistant != null)
                    oneUpdate[48].Value = model.FirstPacuAssistant;
                else
                    oneUpdate[48].Value = DBNull.Value;
                if (model.SecondPacuAssistant != null)
                    oneUpdate[49].Value = model.SecondPacuAssistant;
                else
                    oneUpdate[49].Value = DBNull.Value;
                if (model.FirstPacuNurse != null)
                    oneUpdate[50].Value = model.FirstPacuNurse;
                else
                    oneUpdate[50].Value = DBNull.Value;
                if (model.SecondPacuNurse != null)
                    oneUpdate[51].Value = model.SecondPacuNurse;
                else
                    oneUpdate[51].Value = DBNull.Value;
                if (model.ReqDateTime != null)
                    oneUpdate[52].Value = model.ReqDateTime;
                else
                    oneUpdate[52].Value = DBNull.Value;
                if (model.ScheduledDateTime != null)
                    oneUpdate[53].Value = model.ScheduledDateTime;
                else
                    oneUpdate[53].Value = DBNull.Value;
                if (model.InDateTime != null)
                    oneUpdate[54].Value = model.InDateTime;
                else
                    oneUpdate[54].Value = DBNull.Value;
                if (model.OutDateTime != null)
                    oneUpdate[55].Value = model.OutDateTime;
                else
                    oneUpdate[55].Value = DBNull.Value;
                if (model.AnesStartTime != null)
                    oneUpdate[56].Value = model.AnesStartTime;
                else
                    oneUpdate[56].Value = DBNull.Value;
                if (model.AnesEndTime != null)
                    oneUpdate[57].Value = model.AnesEndTime;
                else
                    oneUpdate[57].Value = DBNull.Value;
                if (model.StartDateTime != null)
                    oneUpdate[58].Value = model.StartDateTime;
                else
                    oneUpdate[58].Value = DBNull.Value;
                if (model.EndDateTime != null)
                    oneUpdate[59].Value = model.EndDateTime;
                else
                    oneUpdate[59].Value = DBNull.Value;
                if (model.InPacuDateTime != null)
                    oneUpdate[60].Value = model.InPacuDateTime;
                else
                    oneUpdate[60].Value = DBNull.Value;
                if (model.OutPacuDateTime != null)
                    oneUpdate[61].Value = model.OutPacuDateTime;
                else
                    oneUpdate[61].Value = DBNull.Value;
                if (model.OperStatusCode != null)
                    oneUpdate[62].Value = model.OperStatusCode;
                else
                    oneUpdate[62].Value = DBNull.Value;
                if (model.OperPosition != null)
                    oneUpdate[63].Value = model.OperPosition;
                else
                    oneUpdate[63].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneUpdate[64].Value = model.BedNo;
                else
                    oneUpdate[64].Value = DBNull.Value;
                if (model.OperationName != null)
                    oneUpdate[65].Value = model.OperationName;
                else
                    oneUpdate[65].Value = DBNull.Value;
                if (model.PatWhereaborts != null)
                    oneUpdate[66].Value = model.PatWhereaborts;
                else
                    oneUpdate[66].Value = DBNull.Value;
                if (model.SatisfactionDegree != null)
                    oneUpdate[67].Value = model.SatisfactionDegree;
                else
                    oneUpdate[67].Value = DBNull.Value;
                if (model.SmoothIndicator != null)
                    oneUpdate[68].Value = model.SmoothIndicator;
                else
                    oneUpdate[68].Value = DBNull.Value;
                if (model.EnteredBy != null)
                    oneUpdate[69].Value = model.EnteredBy;
                else
                    oneUpdate[69].Value = DBNull.Value;
                if (model.OrderTransfer != null)
                    oneUpdate[70].Value = model.OrderTransfer;
                else
                    oneUpdate[70].Value = DBNull.Value;
                if (model.ChargeTransfer != null)
                    oneUpdate[71].Value = model.ChargeTransfer;
                else
                    oneUpdate[71].Value = DBNull.Value;
                if (model.EndIndicator != null)
                    oneUpdate[72].Value = model.EndIndicator;
                else
                    oneUpdate[72].Value = DBNull.Value;
                if (model.Memo != null)
                    oneUpdate[73].Value = model.Memo;
                else
                    oneUpdate[73].Value = DBNull.Value;
                if (model.AnesthesiaId != null)
                    oneUpdate[74].Value = model.AnesthesiaId;
                else
                    oneUpdate[74].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneUpdate[75].Value = model.HisPatientId;
                else
                    oneUpdate[75].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneUpdate[76].Value = model.HisVisitId;
                else
                    oneUpdate[76].Value = DBNull.Value;
                if (model.HisScheduleId != null)
                    oneUpdate[77].Value = model.HisScheduleId;
                else
                    oneUpdate[77].Value = DBNull.Value;
                if (model.HisOperStatus != null)
                    oneUpdate[78].Value = model.HisOperStatus;
                else
                    oneUpdate[78].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneUpdate[79].Value = model.Reserved01;
                else
                    oneUpdate[79].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneUpdate[80].Value = model.Reserved02;
                else
                    oneUpdate[80].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneUpdate[81].Value = model.Reserved03;
                else
                    oneUpdate[81].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[82].Value = model.PatientId;
                else
                    oneUpdate[82].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneUpdate[83].Value = model.VisitId;
                else
                    oneUpdate[83].Value = DBNull.Value;
                if (model.OperId != null)
                    oneUpdate[84].Value = model.OperId;
                else
                    oneUpdate[84].Value = DBNull.Value;
                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_Med_Operation_Master_Odbc, oneUpdate);
            }
        }
    }
}
