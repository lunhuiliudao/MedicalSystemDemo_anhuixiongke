

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

		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedOperationSchedule 
		///Insert Table MED_OPERATION_SCHEDULE
		/// </summary>
		public int InsertMedOperationScheduleSQL(MedOperationSchedule model, System.Data.Common.DbTransaction oleCisTrans)
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
            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, Insert_SQL, oneInert);

		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedOperationSchedule 
		///Update Table     MED_OPERATION_SCHEDULE
		/// </summary>
        public int UpdateMedOperationScheduleSQL(MedOperationSchedule model, System.Data.Common.DbTransaction oleCisTrans)
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
            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, Update_SQL, oneUpdate);

		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedOperationSchedule 
		///Delete Table MED_OPERATION_SCHEDULE by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
		/// </summary>
        public int DeleteMedOperationScheduleSQL(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID, System.Data.Common.DbTransaction oleCisTrans)
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

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_OPERATION_SCHEDULE_Delete_SQL, oneDelete);
			
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedOperationSchedule 
		///select Table MED_OPERATION_SCHEDULE by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
		/// </summary>
        public MedOperationSchedule SelectMedOperationScheduleSQL(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID, System.Data.Common.DbConnection oleCisConn)
		{
			MedOperationSchedule model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedOperationSchedule");
			parameterValues[0].Value=PATIENT_ID;
			parameterValues[1].Value=VISIT_ID;
			parameterValues[2].Value=SCHEDULE_ID;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_OPERATION_SCHEDULE_Select_SQL, parameterValues))
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
		public List<MedOperationSchedule> SelectMedOperationScheduleListSQL( System.Data.Common.DbConnection oleCisConn)
		{
			List<MedOperationSchedule> modelList = new List<MedOperationSchedule>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_OPERATION_SCHEDULE_Select_ALL_SQL, null))
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
		/// <summary>
        /// 获取最大的手术次数
		/// </summary>
		/// <param name="patientId"></param>
		/// <param name="visitId"></param>
		/// <returns></returns>
        public int SelectMaxScheduleIdSQL(string patientId, decimal visitId, System.Data.Common.DbConnection oleCisConn)
        {
            SqlParameter[] medMaxScheduleId = GetParameterSQL("SelectMaxScheduleIdMedOperationSchedule");
            medMaxScheduleId[0].Value = patientId;
            medMaxScheduleId[1].Value = visitId;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_OPERATION_SCHEDULE_Select_Max_ScheduleId_SQL, medMaxScheduleId))
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

        public int SelectCountMedOperationScheduleSQL(string patientId, decimal visitId, decimal scheduleId, System.Data.Common.DbTransaction oleCisTrans)
        {
            SqlParameter[] countMedOperationSchedule = GetParameterSQL("SelectCountMedOperationSchedule");
            countMedOperationSchedule[0].Value = patientId;
            countMedOperationSchedule[1].Value = visitId;
            countMedOperationSchedule[2].Value = scheduleId;

            object count = SqlHelper.ExecuteScalar((SqlTransaction)oleCisTrans, CommandType.Text, MED_OPERATION_SCHEDULE_Select_Count_SQL, countMedOperationSchedule);
            if (count == null)
                count = (object)0;
            return Convert.ToInt32(count);
        }

		#region [添加一条记录]
		/// <summary>
		///Add    model  MedOperationSchedule 
		///Insert Table MED_OPERATION_SCHEDULE
		/// </summary>
        public int InsertMedOperationSchedule(MedOperationSchedule model, System.Data.Common.DbTransaction oleCisTrans)
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

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, Insert , oneInert);

		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedOperationSchedule 
		///Update Table     MED_OPERATION_SCHEDULE
		/// </summary>
        public int UpdateMedOperationSchedule(MedOperationSchedule model, System.Data.Common.DbTransaction oleCisTrans)
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
			
				return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, Update, oneUpdate);
			
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedOperationSchedule 
		///Delete Table MED_OPERATION_SCHEDULE by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
		/// </summary>
        public int DeleteMedOperationSchedule(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID, System.Data.Common.DbTransaction oleCisTrans)
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
        public MedOperationSchedule SelectMedOperationSchedule(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID, System.Data.Common.DbConnection oleCisConn)
		{
			MedOperationSchedule model;
			OracleParameter[] parameterValues = GetParameter("SelectMedOperationSchedule");
			   parameterValues[0].Value=PATIENT_ID;
			   parameterValues[1].Value=VISIT_ID;
			   parameterValues[2].Value=SCHEDULE_ID;
               using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text,Select , parameterValues))
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
		public List<MedOperationSchedule> SelectMedOperationScheduleList( System.Data.Common.DbConnection oleCisConn)
		{
			List<MedOperationSchedule> modelList = new List<MedOperationSchedule>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_OPERATION_SCHEDULE_Select_ALL, null))
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
        /// <summary>
        /// 获取最大的手术次数
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="visitId"></param>
        /// <returns></returns>
        public int SelectMaxScheduleId(string patientId, decimal visitId, System.Data.Common.DbConnection oleCisConn)
        {
            OracleParameter[] medMaxScheduleId = GetParameter("SelectMaxScheduleIdMedOperationSchedule");
            medMaxScheduleId[0].Value = patientId;
            medMaxScheduleId[1].Value = visitId;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_OPERATION_SCHEDULE_Select_Max_ScheduleId, medMaxScheduleId))
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

        public int SelectCountMedOperationSchedule(string patientId, decimal visitId, decimal scheduleId, System.Data.Common.DbTransaction oleCisTrans)
        {
            OracleParameter[] countMedOperationSchedule = GetParameter("SelectCountMedOperationSchedule");
            countMedOperationSchedule[0].Value = patientId;
            countMedOperationSchedule[1].Value = visitId;
            countMedOperationSchedule[2].Value = scheduleId;

            object count = OracleHelper.ExecuteScalar((OracleTransaction)oleCisTrans, CommandType.Text, MED_OPERATION_SCHEDULE_Select_Count, countMedOperationSchedule);
            if (count == null)
                count = (object)0;
            return Convert.ToInt32(count);
        }
		
	}
}
