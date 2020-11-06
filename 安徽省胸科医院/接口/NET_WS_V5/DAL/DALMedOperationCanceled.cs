

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
namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedOperationCanceled
	/// </summary>
	
	public partial class DALMedOperationCanceled
	{
		
		private static readonly string MED_OPERATION_CANCELED_Insert_SQL = "INSERT INTO MED_OPERATION_CANCELED (PATIENT_ID,VISIT_ID,CANCEL_ID,DEPT_STAYED,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,NOTES_ON_OPERATION,ENTERED_BY,CANCEL_REASON,RESERVED1,OPERATION_ID,RESERVED2,RESERVED3,RESERVED4,RESERVED5,RESERVED6,RESERVED7,RESERVED8,RESERVED9,RESERVED10,RESERVED11,RESERVED12) values (@PatientId,@VisitId,@CancelId,@DeptStayed,@ScheduledDateTime,@OperatingRoom,@OperatingRoomNo,@Sequence,@DiagBeforeOperation,@PatientCondition,@OperationScale,@IsolationIndicator,@OperatingDept,@Surgeon,@FirstAssistant,@SecondAssistant,@ThirdAssistant,@FourthAssistant,@AnesthesiaMethod,@AnesthesiaDoctor,@AnesthesiaAssistant,@BloodTranDoctor,@NotesOnOperation,@EnteredBy,@CancelReason,@Reserved1,@OperationId,@Reserved2,@Reserved3,@Reserved4,@Reserved5,@Reserved6,@Reserved7,@Reserved8,@Reserved9,@Reserved10,@Reserved11,@Reserved12)";
        private static readonly string MED_OPERATION_CANCELED_Update_SQL = "UPDATE MED_OPERATION_CANCELED SET PATIENT_ID=@PatientId,VISIT_ID=@VisitId,CANCEL_ID=@CancelId,DEPT_STAYED=@DeptStayed,SCHEDULED_DATE_TIME=@ScheduledDateTime,OPERATING_ROOM=@OperatingRoom,OPERATING_ROOM_NO=@OperatingRoomNo,SEQUENCE=@Sequence,DIAG_BEFORE_OPERATION=@DiagBeforeOperation,PATIENT_CONDITION=@PatientCondition,OPERATION_SCALE=@OperationScale,ISOLATION_INDICATOR=@IsolationIndicator,OPERATING_DEPT=@OperatingDept,SURGEON=@Surgeon,FIRST_ASSISTANT=@FirstAssistant,SECOND_ASSISTANT=@SecondAssistant,THIRD_ASSISTANT=@ThirdAssistant,FOURTH_ASSISTANT=@FourthAssistant,ANESTHESIA_METHOD=@AnesthesiaMethod,ANESTHESIA_DOCTOR=@AnesthesiaDoctor,ANESTHESIA_ASSISTANT=@AnesthesiaAssistant,BLOOD_TRAN_DOCTOR=@BloodTranDoctor,NOTES_ON_OPERATION=@NotesOnOperation,ENTERED_BY=@EnteredBy,CANCEL_REASON=@CancelReason,RESERVED1=@Reserved1,OPERATION_ID=@OperationId,RESERVED2=@Reserved2,RESERVED3=@Reserved3,RESERVED4=@Reserved4,RESERVED5=@Reserved5,RESERVED6=@Reserved6,RESERVED7=@Reserved7,RESERVED8=@Reserved8,RESERVED9=@Reserved9,RESERVED10=@Reserved10,RESERVED11=@Reserved11,RESERVED12=@Reserved12 WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND CANCEL_ID=@CancelId";
        private static readonly string MED_OPERATION_CANCELED_Delete_SQL = "Delete MED_OPERATION_CANCELED WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND CANCEL_ID=@CancelId";
        private static readonly string MED_OPERATION_CANCELED_Select_SQL = "SELECT PATIENT_ID,VISIT_ID,CANCEL_ID,DEPT_STAYED,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,NOTES_ON_OPERATION,ENTERED_BY,CANCEL_REASON,RESERVED1,OPERATION_ID,RESERVED2,RESERVED3,RESERVED4,RESERVED5,RESERVED6,RESERVED7,RESERVED8,RESERVED9,RESERVED10,RESERVED11,RESERVED12 FROM MED_OPERATION_CANCELED where PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND CANCEL_ID=@CancelId";
		private static readonly string MED_OPERATION_CANCELED_Select_ALL_SQL = "SELECT PATIENT_ID,VISIT_ID,CANCEL_ID,DEPT_STAYED,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,NOTES_ON_OPERATION,ENTERED_BY,CANCEL_REASON,RESERVED1,OPERATION_ID,RESERVED2,RESERVED3,RESERVED4,RESERVED5,RESERVED6,RESERVED7,RESERVED8,RESERVED9,RESERVED10,RESERVED11,RESERVED12 FROM MED_OPERATION_CANCELED";
        private static readonly string MED_OPERATION_CANCELED_Select_Max_CanceledId_SQL = "SELECT isnull(max(CANCEL_ID),0) from MED_OPERATION_CANCELED where PATIENT_ID = @patientId and visit_id = @visitId";
        private static readonly string MED_OPERATION_CANCELED_Insert = "INSERT INTO MED_OPERATION_CANCELED (PATIENT_ID,VISIT_ID,CANCEL_ID,DEPT_STAYED,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,NOTES_ON_OPERATION,ENTERED_BY,CANCEL_REASON,RESERVED1,OPERATION_ID,RESERVED2,RESERVED3,RESERVED4,RESERVED5,RESERVED6,RESERVED7,RESERVED8,RESERVED9,RESERVED10,RESERVED11,RESERVED12) values (:PatientId,:VisitId,:CancelId,:DeptStayed,:ScheduledDateTime,:OperatingRoom,:OperatingRoomNo,:Sequence,:DiagBeforeOperation,:PatientCondition,:OperationScale,:IsolationIndicator,:OperatingDept,:Surgeon,:FirstAssistant,:SecondAssistant,:ThirdAssistant,:FourthAssistant,:AnesthesiaMethod,:AnesthesiaDoctor,:AnesthesiaAssistant,:BloodTranDoctor,:NotesOnOperation,:EnteredBy,:CancelReason,:Reserved1,:OperationId,:Reserved2,:Reserved3,:Reserved4,:Reserved5,:Reserved6,:Reserved7,:Reserved8,:Reserved9,:Reserved10,:Reserved11,:Reserved12)";
        private static readonly string MED_OPERATION_CANCELED_Update = "UPDATE MED_OPERATION_CANCELED SET PATIENT_ID=:PatientId,VISIT_ID=:VisitId,CANCEL_ID=:CancelId,DEPT_STAYED=:DeptStayed,SCHEDULED_DATE_TIME=:ScheduledDateTime,OPERATING_ROOM=:OperatingRoom,OPERATING_ROOM_NO=:OperatingRoomNo,SEQUENCE=:Sequence,DIAG_BEFORE_OPERATION=:DiagBeforeOperation,PATIENT_CONDITION=:PatientCondition,OPERATION_SCALE=:OperationScale,ISOLATION_INDICATOR=:IsolationIndicator,OPERATING_DEPT=:OperatingDept,SURGEON=:Surgeon,FIRST_ASSISTANT=:FirstAssistant,SECOND_ASSISTANT=:SecondAssistant,THIRD_ASSISTANT=:ThirdAssistant,FOURTH_ASSISTANT=:FourthAssistant,ANESTHESIA_METHOD=:AnesthesiaMethod,ANESTHESIA_DOCTOR=:AnesthesiaDoctor,ANESTHESIA_ASSISTANT=:AnesthesiaAssistant,BLOOD_TRAN_DOCTOR=:BloodTranDoctor,NOTES_ON_OPERATION=:NotesOnOperation,ENTERED_BY=:EnteredBy,CANCEL_REASON=:CancelReason,RESERVED1=:Reserved1,OPERATION_ID=:OperationId,RESERVED2=:Reserved2,RESERVED3=:Reserved3,RESERVED4=:Reserved4,RESERVED5=:Reserved5,RESERVED6=:Reserved6,RESERVED7=:Reserved7,RESERVED8=:Reserved8,RESERVED9=:Reserved9,RESERVED10=:Reserved10,RESERVED11=:Reserved11,RESERVED12=:Reserved12 WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND CANCEL_ID=:CancelId";
        private static readonly string MED_OPERATION_CANCELED_Delete = "Delete MED_OPERATION_CANCELED WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND CANCEL_ID=:CancelId";
        private static readonly string MED_OPERATION_CANCELED_Select = "SELECT PATIENT_ID,VISIT_ID,CANCEL_ID,DEPT_STAYED,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,NOTES_ON_OPERATION,ENTERED_BY,CANCEL_REASON,RESERVED1,OPERATION_ID,RESERVED2,RESERVED3,RESERVED4,RESERVED5,RESERVED6,RESERVED7,RESERVED8,RESERVED9,RESERVED10,RESERVED11,RESERVED12 FROM MED_OPERATION_CANCELED where PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND CANCEL_ID=:CancelId";
		private static readonly string MED_OPERATION_CANCELED_Select_ALL = "SELECT PATIENT_ID,VISIT_ID,CANCEL_ID,DEPT_STAYED,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,DIAG_BEFORE_OPERATION,PATIENT_CONDITION,OPERATION_SCALE,ISOLATION_INDICATOR,OPERATING_DEPT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,BLOOD_TRAN_DOCTOR,NOTES_ON_OPERATION,ENTERED_BY,CANCEL_REASON,RESERVED1,OPERATION_ID,RESERVED2,RESERVED3,RESERVED4,RESERVED5,RESERVED6,RESERVED7,RESERVED8,RESERVED9,RESERVED10,RESERVED11,RESERVED12 FROM MED_OPERATION_CANCELED";
        private static readonly string MED_OPERATION_CANCELED_Select_Max_CanceledId = "SELECT nvl(max(CANCEL_ID),0) from MED_OPERATION_CANCELED WHERE PATIENT_ID = :patientId and VISIT_ID = :visitId";

        
        public DALMedOperationCanceled ()
		{
		}
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedOperationCanceled SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOperationCanceled")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@CancelId",SqlDbType.Decimal),
							new SqlParameter("@DeptStayed",SqlDbType.VarChar),
							new SqlParameter("@ScheduledDateTime",SqlDbType.DateTime),
							new SqlParameter("@OperatingRoom",SqlDbType.VarChar),
							new SqlParameter("@OperatingRoomNo",SqlDbType.VarChar),
							new SqlParameter("@Sequence",SqlDbType.Decimal),
							new SqlParameter("@DiagBeforeOperation",SqlDbType.VarChar),
							new SqlParameter("@PatientCondition",SqlDbType.VarChar),
							new SqlParameter("@OperationScale",SqlDbType.VarChar),
							new SqlParameter("@IsolationIndicator",SqlDbType.Decimal),
							new SqlParameter("@OperatingDept",SqlDbType.VarChar),
							new SqlParameter("@Surgeon",SqlDbType.VarChar),
							new SqlParameter("@FirstAssistant",SqlDbType.VarChar),
							new SqlParameter("@SecondAssistant",SqlDbType.VarChar),
							new SqlParameter("@ThirdAssistant",SqlDbType.VarChar),
							new SqlParameter("@FourthAssistant",SqlDbType.VarChar),
							new SqlParameter("@AnesthesiaMethod",SqlDbType.VarChar),
							new SqlParameter("@AnesthesiaDoctor",SqlDbType.VarChar),
							new SqlParameter("@AnesthesiaAssistant",SqlDbType.VarChar),
							new SqlParameter("@BloodTranDoctor",SqlDbType.VarChar),
							new SqlParameter("@NotesOnOperation",SqlDbType.VarChar),
							new SqlParameter("@EnteredBy",SqlDbType.VarChar),
							new SqlParameter("@CancelReason",SqlDbType.VarChar),
							new SqlParameter("@Reserved1",SqlDbType.VarChar),
							new SqlParameter("@OperationId",SqlDbType.VarChar),
							new SqlParameter("@Reserved2",SqlDbType.VarChar),
							new SqlParameter("@Reserved3",SqlDbType.VarChar),
							new SqlParameter("@Reserved4",SqlDbType.VarChar),
							new SqlParameter("@Reserved5",SqlDbType.VarChar),
							new SqlParameter("@Reserved6",SqlDbType.VarChar),
							new SqlParameter("@Reserved7",SqlDbType.VarChar),
							new SqlParameter("@Reserved8",SqlDbType.VarChar),
							new SqlParameter("@Reserved9",SqlDbType.DateTime),
							new SqlParameter("@Reserved10",SqlDbType.DateTime),
							new SqlParameter("@Reserved11",SqlDbType.Decimal),
							new SqlParameter("@Reserved12",SqlDbType.Decimal),
                    };
                }
				else if (sqlParms == "UpdateMedOperationCanceled")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@CancelId",SqlDbType.Decimal),
							new SqlParameter("@DeptStayed",SqlDbType.VarChar),
							new SqlParameter("@ScheduledDateTime",SqlDbType.DateTime),
							new SqlParameter("@OperatingRoom",SqlDbType.VarChar),
							new SqlParameter("@OperatingRoomNo",SqlDbType.VarChar),
							new SqlParameter("@Sequence",SqlDbType.Decimal),
							new SqlParameter("@DiagBeforeOperation",SqlDbType.VarChar),
							new SqlParameter("@PatientCondition",SqlDbType.VarChar),
							new SqlParameter("@OperationScale",SqlDbType.VarChar),
							new SqlParameter("@IsolationIndicator",SqlDbType.Decimal),
							new SqlParameter("@OperatingDept",SqlDbType.VarChar),
							new SqlParameter("@Surgeon",SqlDbType.VarChar),
							new SqlParameter("@FirstAssistant",SqlDbType.VarChar),
							new SqlParameter("@SecondAssistant",SqlDbType.VarChar),
							new SqlParameter("@ThirdAssistant",SqlDbType.VarChar),
							new SqlParameter("@FourthAssistant",SqlDbType.VarChar),
							new SqlParameter("@AnesthesiaMethod",SqlDbType.VarChar),
							new SqlParameter("@AnesthesiaDoctor",SqlDbType.VarChar),
							new SqlParameter("@AnesthesiaAssistant",SqlDbType.VarChar),
							new SqlParameter("@BloodTranDoctor",SqlDbType.VarChar),
							new SqlParameter("@NotesOnOperation",SqlDbType.VarChar),
							new SqlParameter("@EnteredBy",SqlDbType.VarChar),
							new SqlParameter("@CancelReason",SqlDbType.VarChar),
							new SqlParameter("@Reserved1",SqlDbType.VarChar),
							new SqlParameter("@OperationId",SqlDbType.VarChar),
							new SqlParameter("@Reserved2",SqlDbType.VarChar),
							new SqlParameter("@Reserved3",SqlDbType.VarChar),
							new SqlParameter("@Reserved4",SqlDbType.VarChar),
							new SqlParameter("@Reserved5",SqlDbType.VarChar),
							new SqlParameter("@Reserved6",SqlDbType.VarChar),
							new SqlParameter("@Reserved7",SqlDbType.VarChar),
							new SqlParameter("@Reserved8",SqlDbType.VarChar),
							new SqlParameter("@Reserved9",SqlDbType.DateTime),
							new SqlParameter("@Reserved10",SqlDbType.DateTime),
							new SqlParameter("@Reserved11",SqlDbType.Decimal),
							new SqlParameter("@Reserved12",SqlDbType.Decimal),
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@CancelId",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedOperationCanceled")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@CancelId",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "SelectMedOperationCanceled")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@CancelId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMaxCanceledIdMedOperationCanceled")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedOperationCanceled 
		///Insert Table MED_OPERATION_CANCELED
		/// </summary>
		public int InsertMedOperationCanceledSQL(MedOperationCanceled model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedOperationCanceled");
					if (model.PatientId != null)
						oneInert[0].Value = model.PatientId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneInert[1].Value = model.VisitId;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.CancelId.ToString() != null)
						oneInert[2].Value = model.CancelId;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.DeptStayed != null)
						oneInert[3].Value = model.DeptStayed;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.ScheduledDateTime > DateTime.MinValue)
						oneInert[4].Value = model.ScheduledDateTime;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.OperatingRoom != null)
						oneInert[5].Value = model.OperatingRoom;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.OperatingRoomNo != null)
						oneInert[6].Value = model.OperatingRoomNo;
					else
						oneInert[6].Value = DBNull.Value;
                    if (model.Sequence.ToString() != null)
						oneInert[7].Value = model.Sequence;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.DiagBeforeOperation != null)
						oneInert[8].Value = model.DiagBeforeOperation;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.PatientCondition != null)
						oneInert[9].Value = model.PatientCondition;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.OperationScale != null)
						oneInert[10].Value = model.OperationScale;
					else
						oneInert[10].Value = DBNull.Value;
					if (model.IsolationIndicator.ToString() != null)
						oneInert[11].Value = model.IsolationIndicator;
					else
						oneInert[11].Value = DBNull.Value;
					if (model.OperatingDept != null)
						oneInert[12].Value = model.OperatingDept;
					else
						oneInert[12].Value = DBNull.Value;
					if (model.Surgeon != null)
						oneInert[13].Value = model.Surgeon;
					else
						oneInert[13].Value = DBNull.Value;
					if (model.FirstAssistant != null)
						oneInert[14].Value = model.FirstAssistant;
					else
						oneInert[14].Value = DBNull.Value;
					if (model.SecondAssistant != null)
						oneInert[15].Value = model.SecondAssistant;
					else
						oneInert[15].Value = DBNull.Value;
					if (model.ThirdAssistant != null)
						oneInert[16].Value = model.ThirdAssistant;
					else
						oneInert[16].Value = DBNull.Value;
					if (model.FourthAssistant != null)
						oneInert[17].Value = model.FourthAssistant;
					else
						oneInert[17].Value = DBNull.Value;
					if (model.AnesthesiaMethod != null)
						oneInert[18].Value = model.AnesthesiaMethod;
					else
						oneInert[18].Value = DBNull.Value;
					if (model.AnesthesiaDoctor != null)
						oneInert[19].Value = model.AnesthesiaDoctor;
					else
						oneInert[19].Value = DBNull.Value;
					if (model.AnesthesiaAssistant != null)
						oneInert[20].Value = model.AnesthesiaAssistant;
					else
						oneInert[20].Value = DBNull.Value;
					if (model.BloodTranDoctor != null)
						oneInert[21].Value = model.BloodTranDoctor;
					else
						oneInert[21].Value = DBNull.Value;
					if (model.NotesOnOperation != null)
						oneInert[22].Value = model.NotesOnOperation;
					else
						oneInert[22].Value = DBNull.Value;
					if (model.EnteredBy != null)
						oneInert[23].Value = model.EnteredBy;
					else
						oneInert[23].Value = DBNull.Value;
					if (model.CancelReason != null)
						oneInert[24].Value = model.CancelReason;
					else
						oneInert[24].Value = DBNull.Value;
					if (model.Reserved1 != null)
						oneInert[25].Value = model.Reserved1;
					else
						oneInert[25].Value = DBNull.Value;
					if (model.OperationId != null)
						oneInert[26].Value = model.OperationId;
					else
						oneInert[26].Value = DBNull.Value;
					if (model.Reserved2 != null)
						oneInert[27].Value = model.Reserved2;
					else
						oneInert[27].Value = DBNull.Value;
					if (model.Reserved3 != null)
						oneInert[28].Value = model.Reserved3;
					else
						oneInert[28].Value = DBNull.Value;
					if (model.Reserved4 != null)
						oneInert[29].Value = model.Reserved4;
					else
						oneInert[29].Value = DBNull.Value;
					if (model.Reserved5 != null)
						oneInert[30].Value = model.Reserved5;
					else
						oneInert[30].Value = DBNull.Value;
					if (model.Reserved6 != null)
						oneInert[31].Value = model.Reserved6;
					else
						oneInert[31].Value = DBNull.Value;
					if (model.Reserved7 != null)
						oneInert[32].Value = model.Reserved7;
					else
						oneInert[32].Value = DBNull.Value;
					if (model.Reserved8 != null)
						oneInert[33].Value = model.Reserved8;
					else
						oneInert[33].Value = DBNull.Value;
					if (model.Reserved9 != null)
						oneInert[34].Value = model.Reserved9;
					else
						oneInert[34].Value = DBNull.Value;
					if (model.Reserved10 != null)
						oneInert[35].Value = model.Reserved10;
					else
						oneInert[35].Value = DBNull.Value;
                    if (model.Reserved11.ToString() != null)
						oneInert[36].Value = model.Reserved11;
					else
						oneInert[36].Value = DBNull.Value;
                    if (model.Reserved12.ToString() != null)
						oneInert[37].Value = model.Reserved12;
					else
						oneInert[37].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_OPERATION_CANCELED_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedOperationCanceled 
		///Update Table     MED_OPERATION_CANCELED
		/// </summary>
		public int UpdateMedOperationCanceledSQL(MedOperationCanceled model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedOperationCanceled");
					if (model.PatientId != null)
						oneUpdate[0].Value = model.PatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneUpdate[1].Value = model.VisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.CancelId.ToString() != null)
						oneUpdate[2].Value = model.CancelId;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.DeptStayed != null)
						oneUpdate[3].Value = model.DeptStayed;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.ScheduledDateTime > DateTime.MinValue)
						oneUpdate[4].Value = model.ScheduledDateTime;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.OperatingRoom != null)
						oneUpdate[5].Value = model.OperatingRoom;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.OperatingRoomNo != null)
						oneUpdate[6].Value = model.OperatingRoomNo;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.Sequence.ToString() != null)
						oneUpdate[7].Value = model.Sequence;
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
					if (model.OperationScale != null)
						oneUpdate[10].Value = model.OperationScale;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.IsolationIndicator.ToString() != null)
						oneUpdate[11].Value = model.IsolationIndicator;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.OperatingDept != null)
						oneUpdate[12].Value = model.OperatingDept;
					else
						oneUpdate[12].Value = DBNull.Value;
					if (model.Surgeon != null)
						oneUpdate[13].Value = model.Surgeon;
					else
						oneUpdate[13].Value = DBNull.Value;
					if (model.FirstAssistant != null)
						oneUpdate[14].Value = model.FirstAssistant;
					else
						oneUpdate[14].Value = DBNull.Value;
					if (model.SecondAssistant != null)
						oneUpdate[15].Value = model.SecondAssistant;
					else
						oneUpdate[15].Value = DBNull.Value;
					if (model.ThirdAssistant != null)
						oneUpdate[16].Value = model.ThirdAssistant;
					else
						oneUpdate[16].Value = DBNull.Value;
					if (model.FourthAssistant != null)
						oneUpdate[17].Value = model.FourthAssistant;
					else
						oneUpdate[17].Value = DBNull.Value;
					if (model.AnesthesiaMethod != null)
						oneUpdate[18].Value = model.AnesthesiaMethod;
					else
						oneUpdate[18].Value = DBNull.Value;
					if (model.AnesthesiaDoctor != null)
						oneUpdate[19].Value = model.AnesthesiaDoctor;
					else
						oneUpdate[19].Value = DBNull.Value;
					if (model.AnesthesiaAssistant != null)
						oneUpdate[20].Value = model.AnesthesiaAssistant;
					else
						oneUpdate[20].Value = DBNull.Value;
					if (model.BloodTranDoctor != null)
						oneUpdate[21].Value = model.BloodTranDoctor;
					else
						oneUpdate[21].Value = DBNull.Value;
					if (model.NotesOnOperation != null)
						oneUpdate[22].Value = model.NotesOnOperation;
					else
						oneUpdate[22].Value = DBNull.Value;
					if (model.EnteredBy != null)
						oneUpdate[23].Value = model.EnteredBy;
					else
						oneUpdate[23].Value = DBNull.Value;
					if (model.CancelReason != null)
						oneUpdate[24].Value = model.CancelReason;
					else
						oneUpdate[24].Value = DBNull.Value;
					if (model.Reserved1 != null)
						oneUpdate[25].Value = model.Reserved1;
					else
						oneUpdate[25].Value = DBNull.Value;
					if (model.OperationId != null)
						oneUpdate[26].Value = model.OperationId;
					else
						oneUpdate[26].Value = DBNull.Value;
					if (model.Reserved2 != null)
						oneUpdate[27].Value = model.Reserved2;
					else
						oneUpdate[27].Value = DBNull.Value;
					if (model.Reserved3 != null)
						oneUpdate[28].Value = model.Reserved3;
					else
						oneUpdate[28].Value = DBNull.Value;
					if (model.Reserved4 != null)
						oneUpdate[29].Value = model.Reserved4;
					else
						oneUpdate[29].Value = DBNull.Value;
					if (model.Reserved5 != null)
						oneUpdate[30].Value = model.Reserved5;
					else
						oneUpdate[30].Value = DBNull.Value;
					if (model.Reserved6 != null)
						oneUpdate[31].Value = model.Reserved6;
					else
						oneUpdate[31].Value = DBNull.Value;
					if (model.Reserved7 != null)
						oneUpdate[32].Value = model.Reserved7;
					else
						oneUpdate[32].Value = DBNull.Value;
					if (model.Reserved8 != null)
						oneUpdate[33].Value = model.Reserved8;
					else
						oneUpdate[33].Value = DBNull.Value;
					if (model.Reserved9 != null)
						oneUpdate[34].Value = model.Reserved9;
					else
						oneUpdate[34].Value = DBNull.Value;
					if (model.Reserved10 != null)
						oneUpdate[35].Value = model.Reserved10;
					else
						oneUpdate[35].Value = DBNull.Value;
                    if (model.Reserved11.ToString() != null)
						oneUpdate[36].Value = model.Reserved11;
					else
						oneUpdate[36].Value = DBNull.Value;
                    if (model.Reserved12.ToString() != null)
						oneUpdate[37].Value = model.Reserved12;
					else
						oneUpdate[37].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[38].Value =model.PatientId;
					else
						oneUpdate[38].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneUpdate[39].Value =model.VisitId;
					else
						oneUpdate[39].Value = DBNull.Value;
                    if (model.CancelId.ToString() != null)
						oneUpdate[40].Value =model.CancelId;
					else
						oneUpdate[40].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_OPERATION_CANCELED_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedOperationCanceled 
		///Delete Table MED_OPERATION_CANCELED by (string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID)
		/// </summary>
		public int DeleteMedOperationCanceledSQL(string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedOperationCanceled");
					if (PATIENT_ID != null)
						oneDelete[0].Value =PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (VISIT_ID.ToString() != null)
						oneDelete[1].Value =VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
                    if (CANCEL_ID.ToString() != null)
						oneDelete[2].Value =CANCEL_ID;
					else
						oneDelete[2].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_OPERATION_CANCELED_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedOperationCanceled 
		///select Table MED_OPERATION_CANCELED by (string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID)
		/// </summary>
		public MedOperationCanceled  SelectMedOperationCanceledSQL(string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID)
		{
			MedOperationCanceled model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedOperationCanceled");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
				parameterValues[2].Value=CANCEL_ID;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_CANCELED_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedOperationCanceled();
						if (!oleReader.IsDBNull(0))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.CancelId = decimal.Parse(oleReader["CANCEL_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.DeptStayed = oleReader["DEPT_STAYED"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ScheduledDateTime = DateTime.Parse(oleReader["SCHEDULED_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.OperatingRoom = oleReader["OPERATING_ROOM"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.OperatingRoomNo = oleReader["OPERATING_ROOM_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Sequence = decimal.Parse(oleReader["SEQUENCE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.DiagBeforeOperation = oleReader["DIAG_BEFORE_OPERATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.OperationScale = oleReader["OPERATION_SCALE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.IsolationIndicator = decimal.Parse(oleReader["ISOLATION_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.OperatingDept = oleReader["OPERATING_DEPT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.Surgeon = oleReader["SURGEON"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.FirstAssistant = oleReader["FIRST_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.SecondAssistant = oleReader["SECOND_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.ThirdAssistant = oleReader["THIRD_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.FourthAssistant = oleReader["FOURTH_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.AnesthesiaMethod = oleReader["ANESTHESIA_METHOD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(19))
						{
							model.AnesthesiaDoctor = oleReader["ANESTHESIA_DOCTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(20))
						{
							model.AnesthesiaAssistant = oleReader["ANESTHESIA_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.BloodTranDoctor = oleReader["BLOOD_TRAN_DOCTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.NotesOnOperation = oleReader["NOTES_ON_OPERATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(23))
						{
							model.EnteredBy = oleReader["ENTERED_BY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(24))
						{
							model.CancelReason = oleReader["CANCEL_REASON"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(25))
						{
							model.Reserved1 = oleReader["RESERVED1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(26))
						{
							model.OperationId = oleReader["OPERATION_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(27))
						{
							model.Reserved2 = oleReader["RESERVED2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(28))
						{
							model.Reserved3 = oleReader["RESERVED3"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(29))
						{
							model.Reserved4 = oleReader["RESERVED4"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(30))
						{
							model.Reserved5 = oleReader["RESERVED5"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(31))
						{
							model.Reserved6 = oleReader["RESERVED6"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(32))
						{
							model.Reserved7 = oleReader["RESERVED7"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(33))
						{
							model.Reserved8 = oleReader["RESERVED8"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(34))
						{
							model.Reserved9 = DateTime.Parse(oleReader["RESERVED9"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(35))
						{
							model.Reserved10 = DateTime.Parse(oleReader["RESERVED10"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(36))
						{
							model.Reserved11 = decimal.Parse(oleReader["RESERVED11"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(37))
						{
							model.Reserved12 = decimal.Parse(oleReader["RESERVED12"].ToString().Trim()) ;
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
		public List<MedOperationCanceled> SelectMedOperationCanceledListSQL()
		{
			List<MedOperationCanceled> modelList = new List<MedOperationCanceled>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_CANCELED_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedOperationCanceled model = new MedOperationCanceled();
						if (!oleReader.IsDBNull(0))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.CancelId = decimal.Parse(oleReader["CANCEL_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.DeptStayed = oleReader["DEPT_STAYED"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ScheduledDateTime = DateTime.Parse(oleReader["SCHEDULED_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.OperatingRoom = oleReader["OPERATING_ROOM"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.OperatingRoomNo = oleReader["OPERATING_ROOM_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Sequence = decimal.Parse(oleReader["SEQUENCE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.DiagBeforeOperation = oleReader["DIAG_BEFORE_OPERATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.OperationScale = oleReader["OPERATION_SCALE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.IsolationIndicator = decimal.Parse(oleReader["ISOLATION_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.OperatingDept = oleReader["OPERATING_DEPT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.Surgeon = oleReader["SURGEON"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.FirstAssistant = oleReader["FIRST_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.SecondAssistant = oleReader["SECOND_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.ThirdAssistant = oleReader["THIRD_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.FourthAssistant = oleReader["FOURTH_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.AnesthesiaMethod = oleReader["ANESTHESIA_METHOD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(19))
						{
							model.AnesthesiaDoctor = oleReader["ANESTHESIA_DOCTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(20))
						{
							model.AnesthesiaAssistant = oleReader["ANESTHESIA_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.BloodTranDoctor = oleReader["BLOOD_TRAN_DOCTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.NotesOnOperation = oleReader["NOTES_ON_OPERATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(23))
						{
							model.EnteredBy = oleReader["ENTERED_BY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(24))
						{
							model.CancelReason = oleReader["CANCEL_REASON"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(25))
						{
							model.Reserved1 = oleReader["RESERVED1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(26))
						{
							model.OperationId = oleReader["OPERATION_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(27))
						{
							model.Reserved2 = oleReader["RESERVED2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(28))
						{
							model.Reserved3 = oleReader["RESERVED3"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(29))
						{
							model.Reserved4 = oleReader["RESERVED4"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(30))
						{
							model.Reserved5 = oleReader["RESERVED5"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(31))
						{
							model.Reserved6 = oleReader["RESERVED6"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(32))
						{
							model.Reserved7 = oleReader["RESERVED7"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(33))
						{
							model.Reserved8 = oleReader["RESERVED8"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(34))
						{
							model.Reserved9 = DateTime.Parse(oleReader["RESERVED9"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(35))
						{
							model.Reserved10 = DateTime.Parse(oleReader["RESERVED10"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(36))
						{
							model.Reserved11 = decimal.Parse(oleReader["RESERVED11"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(37))
						{
							model.Reserved12 = decimal.Parse(oleReader["RESERVED12"].ToString().Trim()) ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
        public int SelectMaxCanceledIdSQL(string patientId, decimal visitId)
        {
            SqlParameter[] medMaxCanceledId = GetParameterSQL("SelectMaxCanceledIdMedOperationCanceled");
            medMaxCanceledId[0].Value = patientId;
            medMaxCanceledId[1].Value = visitId;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_CANCELED_Select_Max_CanceledId_SQL, medMaxCanceledId))
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

		#region [获取参数]
		/// <summary>
		///获取参数MedOperationCanceled
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOperationCanceled")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":CancelId",OracleType.Number),
							new OracleParameter(":DeptStayed",OracleType.VarChar),
							new OracleParameter(":ScheduledDateTime",OracleType.DateTime),
							new OracleParameter(":OperatingRoom",OracleType.VarChar),
							new OracleParameter(":OperatingRoomNo",OracleType.VarChar),
							new OracleParameter(":Sequence",OracleType.Number),
							new OracleParameter(":DiagBeforeOperation",OracleType.VarChar),
							new OracleParameter(":PatientCondition",OracleType.VarChar),
							new OracleParameter(":OperationScale",OracleType.VarChar),
							new OracleParameter(":IsolationIndicator",OracleType.Number),
							new OracleParameter(":OperatingDept",OracleType.VarChar),
							new OracleParameter(":Surgeon",OracleType.VarChar),
							new OracleParameter(":FirstAssistant",OracleType.VarChar),
							new OracleParameter(":SecondAssistant",OracleType.VarChar),
							new OracleParameter(":ThirdAssistant",OracleType.VarChar),
							new OracleParameter(":FourthAssistant",OracleType.VarChar),
							new OracleParameter(":AnesthesiaMethod",OracleType.VarChar),
							new OracleParameter(":AnesthesiaDoctor",OracleType.VarChar),
							new OracleParameter(":AnesthesiaAssistant",OracleType.VarChar),
							new OracleParameter(":BloodTranDoctor",OracleType.VarChar),
							new OracleParameter(":NotesOnOperation",OracleType.VarChar),
							new OracleParameter(":EnteredBy",OracleType.VarChar),
							new OracleParameter(":CancelReason",OracleType.VarChar),
							new OracleParameter(":Reserved1",OracleType.VarChar),
							new OracleParameter(":OperationId",OracleType.VarChar),
							new OracleParameter(":Reserved2",OracleType.VarChar),
							new OracleParameter(":Reserved3",OracleType.VarChar),
							new OracleParameter(":Reserved4",OracleType.VarChar),
							new OracleParameter(":Reserved5",OracleType.VarChar),
							new OracleParameter(":Reserved6",OracleType.VarChar),
							new OracleParameter(":Reserved7",OracleType.VarChar),
							new OracleParameter(":Reserved8",OracleType.VarChar),
							new OracleParameter(":Reserved9",OracleType.DateTime),
							new OracleParameter(":Reserved10",OracleType.DateTime),
							new OracleParameter(":Reserved11",OracleType.Number),
							new OracleParameter(":Reserved12",OracleType.Number),
                    };
                }
				else if (sqlParms == "UpdateMedOperationCanceled")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":CancelId",OracleType.Number),
							new OracleParameter(":DeptStayed",OracleType.VarChar),
							new OracleParameter(":ScheduledDateTime",OracleType.DateTime),
							new OracleParameter(":OperatingRoom",OracleType.VarChar),
							new OracleParameter(":OperatingRoomNo",OracleType.VarChar),
							new OracleParameter(":Sequence",OracleType.Number),
							new OracleParameter(":DiagBeforeOperation",OracleType.VarChar),
							new OracleParameter(":PatientCondition",OracleType.VarChar),
							new OracleParameter(":OperationScale",OracleType.VarChar),
							new OracleParameter(":IsolationIndicator",OracleType.Number),
							new OracleParameter(":OperatingDept",OracleType.VarChar),
							new OracleParameter(":Surgeon",OracleType.VarChar),
							new OracleParameter(":FirstAssistant",OracleType.VarChar),
							new OracleParameter(":SecondAssistant",OracleType.VarChar),
							new OracleParameter(":ThirdAssistant",OracleType.VarChar),
							new OracleParameter(":FourthAssistant",OracleType.VarChar),
							new OracleParameter(":AnesthesiaMethod",OracleType.VarChar),
							new OracleParameter(":AnesthesiaDoctor",OracleType.VarChar),
							new OracleParameter(":AnesthesiaAssistant",OracleType.VarChar),
							new OracleParameter(":BloodTranDoctor",OracleType.VarChar),
							new OracleParameter(":NotesOnOperation",OracleType.VarChar),
							new OracleParameter(":EnteredBy",OracleType.VarChar),
							new OracleParameter(":CancelReason",OracleType.VarChar),
							new OracleParameter(":Reserved1",OracleType.VarChar),
							new OracleParameter(":OperationId",OracleType.VarChar),
							new OracleParameter(":Reserved2",OracleType.VarChar),
							new OracleParameter(":Reserved3",OracleType.VarChar),
							new OracleParameter(":Reserved4",OracleType.VarChar),
							new OracleParameter(":Reserved5",OracleType.VarChar),
							new OracleParameter(":Reserved6",OracleType.VarChar),
							new OracleParameter(":Reserved7",OracleType.VarChar),
							new OracleParameter(":Reserved8",OracleType.VarChar),
							new OracleParameter(":Reserved9",OracleType.DateTime),
							new OracleParameter(":Reserved10",OracleType.DateTime),
							new OracleParameter(":Reserved11",OracleType.Number),
							new OracleParameter(":Reserved12",OracleType.Number),
							new OracleParameter(":PatientId",SqlDbType.VarChar),
							new OracleParameter(":VisitId",SqlDbType.Decimal),
							new OracleParameter(":CancelId",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedOperationCanceled")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":CancelId",OracleType.Number),
                    };
                }
				else if(sqlParms == "SelectMedOperationCanceled")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":CancelId",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectMaxCanceledIdMedOperationCanceled")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedOperationCanceled 
		///Insert Table MED_OPERATION_CANCELED
		/// </summary>
		public int InsertMedOperationCanceled(MedOperationCanceled model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedOperationCanceled");
					if (model.PatientId != null)
						oneInert[0].Value = model.PatientId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneInert[1].Value = model.VisitId;
					else
						oneInert[1].Value = DBNull.Value;
                    if (model.CancelId.ToString() != null)
						oneInert[2].Value = model.CancelId;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.DeptStayed != null)
						oneInert[3].Value = model.DeptStayed;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.ScheduledDateTime > DateTime.MinValue)
						oneInert[4].Value = model.ScheduledDateTime;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.OperatingRoom != null)
						oneInert[5].Value = model.OperatingRoom;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.OperatingRoomNo != null)
						oneInert[6].Value = model.OperatingRoomNo;
					else
						oneInert[6].Value = DBNull.Value;
                    if (model.Sequence.ToString() != null)
						oneInert[7].Value = model.Sequence;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.DiagBeforeOperation != null)
						oneInert[8].Value = model.DiagBeforeOperation;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.PatientCondition != null)
						oneInert[9].Value = model.PatientCondition;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.OperationScale != null)
						oneInert[10].Value = model.OperationScale;
					else
						oneInert[10].Value = DBNull.Value;
					if (model.IsolationIndicator.ToString() != null)
						oneInert[11].Value = model.IsolationIndicator;
					else
						oneInert[11].Value = DBNull.Value;
					if (model.OperatingDept != null)
						oneInert[12].Value = model.OperatingDept;
					else
						oneInert[12].Value = DBNull.Value;
					if (model.Surgeon != null)
						oneInert[13].Value = model.Surgeon;
					else
						oneInert[13].Value = DBNull.Value;
					if (model.FirstAssistant != null)
						oneInert[14].Value = model.FirstAssistant;
					else
						oneInert[14].Value = DBNull.Value;
					if (model.SecondAssistant != null)
						oneInert[15].Value = model.SecondAssistant;
					else
						oneInert[15].Value = DBNull.Value;
					if (model.ThirdAssistant != null)
						oneInert[16].Value = model.ThirdAssistant;
					else
						oneInert[16].Value = DBNull.Value;
					if (model.FourthAssistant != null)
						oneInert[17].Value = model.FourthAssistant;
					else
						oneInert[17].Value = DBNull.Value;
					if (model.AnesthesiaMethod != null)
						oneInert[18].Value = model.AnesthesiaMethod;
					else
						oneInert[18].Value = DBNull.Value;
					if (model.AnesthesiaDoctor != null)
						oneInert[19].Value = model.AnesthesiaDoctor;
					else
						oneInert[19].Value = DBNull.Value;
					if (model.AnesthesiaAssistant != null)
						oneInert[20].Value = model.AnesthesiaAssistant;
					else
						oneInert[20].Value = DBNull.Value;
					if (model.BloodTranDoctor != null)
						oneInert[21].Value = model.BloodTranDoctor;
					else
						oneInert[21].Value = DBNull.Value;
					if (model.NotesOnOperation != null)
						oneInert[22].Value = model.NotesOnOperation;
					else
						oneInert[22].Value = DBNull.Value;
					if (model.EnteredBy != null)
						oneInert[23].Value = model.EnteredBy;
					else
						oneInert[23].Value = DBNull.Value;
					if (model.CancelReason != null)
						oneInert[24].Value = model.CancelReason;
					else
						oneInert[24].Value = DBNull.Value;
					if (model.Reserved1 != null)
						oneInert[25].Value = model.Reserved1;
					else
						oneInert[25].Value = DBNull.Value;
					if (model.OperationId != null)
						oneInert[26].Value = model.OperationId;
					else
						oneInert[26].Value = DBNull.Value;
					if (model.Reserved2 != null)
						oneInert[27].Value = model.Reserved2;
					else
						oneInert[27].Value = DBNull.Value;
					if (model.Reserved3 != null)
						oneInert[28].Value = model.Reserved3;
					else
						oneInert[28].Value = DBNull.Value;
					if (model.Reserved4 != null)
						oneInert[29].Value = model.Reserved4;
					else
						oneInert[29].Value = DBNull.Value;
					if (model.Reserved5 != null)
						oneInert[30].Value = model.Reserved5;
					else
						oneInert[30].Value = DBNull.Value;
					if (model.Reserved6 != null)
						oneInert[31].Value = model.Reserved6;
					else
						oneInert[31].Value = DBNull.Value;
					if (model.Reserved7 != null)
						oneInert[32].Value = model.Reserved7;
					else
						oneInert[32].Value = DBNull.Value;
					if (model.Reserved8 != null)
						oneInert[33].Value = model.Reserved8;
					else
						oneInert[33].Value = DBNull.Value;
					if (model.Reserved9 != null)
						oneInert[34].Value = model.Reserved9;
					else
						oneInert[34].Value = DBNull.Value;
					if (model.Reserved10 != null)
						oneInert[35].Value = model.Reserved10;
					else
						oneInert[35].Value = DBNull.Value;
                    if (model.Reserved11.ToString() != null)
						oneInert[36].Value = model.Reserved11;
					else
						oneInert[36].Value = DBNull.Value;
                    if (model.Reserved12.ToString() != null)
						oneInert[37].Value = model.Reserved12;
					else
						oneInert[37].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_OPERATION_CANCELED_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedOperationCanceled 
		///Update Table     MED_OPERATION_CANCELED
		/// </summary>
		public int UpdateMedOperationCanceled(MedOperationCanceled model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedOperationCanceled");
					if (model.PatientId != null)
						oneUpdate[0].Value = model.PatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneUpdate[1].Value = model.VisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.CancelId.ToString() != null)
						oneUpdate[2].Value = model.CancelId;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.DeptStayed != null)
						oneUpdate[3].Value = model.DeptStayed;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.ScheduledDateTime > DateTime.MinValue)
						oneUpdate[4].Value = model.ScheduledDateTime;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.OperatingRoom != null)
						oneUpdate[5].Value = model.OperatingRoom;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.OperatingRoomNo != null)
						oneUpdate[6].Value = model.OperatingRoomNo;
					else
						oneUpdate[6].Value = DBNull.Value;
                    if (model.Sequence.ToString() != null)
						oneUpdate[7].Value = model.Sequence;
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
					if (model.OperationScale != null)
						oneUpdate[10].Value = model.OperationScale;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.IsolationIndicator.ToString() != null)
						oneUpdate[11].Value = model.IsolationIndicator;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.OperatingDept != null)
						oneUpdate[12].Value = model.OperatingDept;
					else
						oneUpdate[12].Value = DBNull.Value;
					if (model.Surgeon != null)
						oneUpdate[13].Value = model.Surgeon;
					else
						oneUpdate[13].Value = DBNull.Value;
					if (model.FirstAssistant != null)
						oneUpdate[14].Value = model.FirstAssistant;
					else
						oneUpdate[14].Value = DBNull.Value;
					if (model.SecondAssistant != null)
						oneUpdate[15].Value = model.SecondAssistant;
					else
						oneUpdate[15].Value = DBNull.Value;
					if (model.ThirdAssistant != null)
						oneUpdate[16].Value = model.ThirdAssistant;
					else
						oneUpdate[16].Value = DBNull.Value;
					if (model.FourthAssistant != null)
						oneUpdate[17].Value = model.FourthAssistant;
					else
						oneUpdate[17].Value = DBNull.Value;
					if (model.AnesthesiaMethod != null)
						oneUpdate[18].Value = model.AnesthesiaMethod;
					else
						oneUpdate[18].Value = DBNull.Value;
					if (model.AnesthesiaDoctor != null)
						oneUpdate[19].Value = model.AnesthesiaDoctor;
					else
						oneUpdate[19].Value = DBNull.Value;
					if (model.AnesthesiaAssistant != null)
						oneUpdate[20].Value = model.AnesthesiaAssistant;
					else
						oneUpdate[20].Value = DBNull.Value;
					if (model.BloodTranDoctor != null)
						oneUpdate[21].Value = model.BloodTranDoctor;
					else
						oneUpdate[21].Value = DBNull.Value;
					if (model.NotesOnOperation != null)
						oneUpdate[22].Value = model.NotesOnOperation;
					else
						oneUpdate[22].Value = DBNull.Value;
					if (model.EnteredBy != null)
						oneUpdate[23].Value = model.EnteredBy;
					else
						oneUpdate[23].Value = DBNull.Value;
					if (model.CancelReason != null)
						oneUpdate[24].Value = model.CancelReason;
					else
						oneUpdate[24].Value = DBNull.Value;
					if (model.Reserved1 != null)
						oneUpdate[25].Value = model.Reserved1;
					else
						oneUpdate[25].Value = DBNull.Value;
					if (model.OperationId != null)
						oneUpdate[26].Value = model.OperationId;
					else
						oneUpdate[26].Value = DBNull.Value;
					if (model.Reserved2 != null)
						oneUpdate[27].Value = model.Reserved2;
					else
						oneUpdate[27].Value = DBNull.Value;
					if (model.Reserved3 != null)
						oneUpdate[28].Value = model.Reserved3;
					else
						oneUpdate[28].Value = DBNull.Value;
					if (model.Reserved4 != null)
						oneUpdate[29].Value = model.Reserved4;
					else
						oneUpdate[29].Value = DBNull.Value;
					if (model.Reserved5 != null)
						oneUpdate[30].Value = model.Reserved5;
					else
						oneUpdate[30].Value = DBNull.Value;
					if (model.Reserved6 != null)
						oneUpdate[31].Value = model.Reserved6;
					else
						oneUpdate[31].Value = DBNull.Value;
					if (model.Reserved7 != null)
						oneUpdate[32].Value = model.Reserved7;
					else
						oneUpdate[32].Value = DBNull.Value;
					if (model.Reserved8 != null)
						oneUpdate[33].Value = model.Reserved8;
					else
						oneUpdate[33].Value = DBNull.Value;
					if (model.Reserved9 != null)
						oneUpdate[34].Value = model.Reserved9;
					else
						oneUpdate[34].Value = DBNull.Value;
					if (model.Reserved10 != null)
						oneUpdate[35].Value = model.Reserved10;
					else
						oneUpdate[35].Value = DBNull.Value;
                    if (model.Reserved11.ToString() != null)
						oneUpdate[36].Value = model.Reserved11;
					else
						oneUpdate[36].Value = DBNull.Value;
                    if (model.Reserved12.ToString() != null)
						oneUpdate[37].Value = model.Reserved12;
					else
						oneUpdate[37].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[38].Value =model.PatientId;
					else
						oneUpdate[38].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneUpdate[39].Value =model.VisitId;
					else
						oneUpdate[39].Value = DBNull.Value;
					if (model.CancelId.ToString() != null)
						oneUpdate[40].Value =model.CancelId;
					else
						oneUpdate[40].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_OPERATION_CANCELED_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedOperationCanceled 
		///Delete Table MED_OPERATION_CANCELED by (string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID)
		/// </summary>
		public int DeleteMedOperationCanceled(string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedOperationCanceled");
					if (PATIENT_ID != null)
						oneDelete[0].Value =PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (VISIT_ID.ToString() != null)
						oneDelete[1].Value =VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
                    if (CANCEL_ID.ToString() != null)
						oneDelete[2].Value =CANCEL_ID;
					else
						oneDelete[2].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_OPERATION_CANCELED_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedOperationCanceled 
		///select Table MED_OPERATION_CANCELED by (string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID)
		/// </summary>
		public MedOperationCanceled  SelectMedOperationCanceled(string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID)
		{
			MedOperationCanceled model;
			OracleParameter[] parameterValues = GetParameter("SelectMedOperationCanceled");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
				parameterValues[2].Value=CANCEL_ID;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_CANCELED_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedOperationCanceled();
						if (!oleReader.IsDBNull(0))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.CancelId = decimal.Parse(oleReader["CANCEL_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.DeptStayed = oleReader["DEPT_STAYED"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ScheduledDateTime = DateTime.Parse(oleReader["SCHEDULED_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.OperatingRoom = oleReader["OPERATING_ROOM"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.OperatingRoomNo = oleReader["OPERATING_ROOM_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Sequence = decimal.Parse(oleReader["SEQUENCE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.DiagBeforeOperation = oleReader["DIAG_BEFORE_OPERATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.OperationScale = oleReader["OPERATION_SCALE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.IsolationIndicator = decimal.Parse(oleReader["ISOLATION_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.OperatingDept = oleReader["OPERATING_DEPT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.Surgeon = oleReader["SURGEON"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.FirstAssistant = oleReader["FIRST_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.SecondAssistant = oleReader["SECOND_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.ThirdAssistant = oleReader["THIRD_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.FourthAssistant = oleReader["FOURTH_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.AnesthesiaMethod = oleReader["ANESTHESIA_METHOD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(19))
						{
							model.AnesthesiaDoctor = oleReader["ANESTHESIA_DOCTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(20))
						{
							model.AnesthesiaAssistant = oleReader["ANESTHESIA_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.BloodTranDoctor = oleReader["BLOOD_TRAN_DOCTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.NotesOnOperation = oleReader["NOTES_ON_OPERATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(23))
						{
							model.EnteredBy = oleReader["ENTERED_BY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(24))
						{
							model.CancelReason = oleReader["CANCEL_REASON"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(25))
						{
							model.Reserved1 = oleReader["RESERVED1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(26))
						{
							model.OperationId = oleReader["OPERATION_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(27))
						{
							model.Reserved2 = oleReader["RESERVED2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(28))
						{
							model.Reserved3 = oleReader["RESERVED3"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(29))
						{
							model.Reserved4 = oleReader["RESERVED4"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(30))
						{
							model.Reserved5 = oleReader["RESERVED5"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(31))
						{
							model.Reserved6 = oleReader["RESERVED6"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(32))
						{
							model.Reserved7 = oleReader["RESERVED7"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(33))
						{
							model.Reserved8 = oleReader["RESERVED8"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(34))
						{
							model.Reserved9 = DateTime.Parse(oleReader["RESERVED9"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(35))
						{
							model.Reserved10 = DateTime.Parse(oleReader["RESERVED10"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(36))
						{
							model.Reserved11 = decimal.Parse(oleReader["RESERVED11"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(37))
						{
							model.Reserved12 = decimal.Parse(oleReader["RESERVED12"].ToString().Trim()) ;
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
		public List<MedOperationCanceled> SelectMedOperationCanceledList()
		{
			List<MedOperationCanceled> modelList = new List<MedOperationCanceled>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_CANCELED_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedOperationCanceled model = new MedOperationCanceled();
						if (!oleReader.IsDBNull(0))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.CancelId = decimal.Parse(oleReader["CANCEL_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.DeptStayed = oleReader["DEPT_STAYED"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ScheduledDateTime = DateTime.Parse(oleReader["SCHEDULED_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.OperatingRoom = oleReader["OPERATING_ROOM"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.OperatingRoomNo = oleReader["OPERATING_ROOM_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Sequence = decimal.Parse(oleReader["SEQUENCE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.DiagBeforeOperation = oleReader["DIAG_BEFORE_OPERATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.PatientCondition = oleReader["PATIENT_CONDITION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.OperationScale = oleReader["OPERATION_SCALE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.IsolationIndicator = decimal.Parse(oleReader["ISOLATION_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.OperatingDept = oleReader["OPERATING_DEPT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.Surgeon = oleReader["SURGEON"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.FirstAssistant = oleReader["FIRST_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.SecondAssistant = oleReader["SECOND_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.ThirdAssistant = oleReader["THIRD_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.FourthAssistant = oleReader["FOURTH_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.AnesthesiaMethod = oleReader["ANESTHESIA_METHOD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(19))
						{
							model.AnesthesiaDoctor = oleReader["ANESTHESIA_DOCTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(20))
						{
							model.AnesthesiaAssistant = oleReader["ANESTHESIA_ASSISTANT"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.BloodTranDoctor = oleReader["BLOOD_TRAN_DOCTOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.NotesOnOperation = oleReader["NOTES_ON_OPERATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(23))
						{
							model.EnteredBy = oleReader["ENTERED_BY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(24))
						{
							model.CancelReason = oleReader["CANCEL_REASON"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(25))
						{
							model.Reserved1 = oleReader["RESERVED1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(26))
						{
							model.OperationId = oleReader["OPERATION_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(27))
						{
							model.Reserved2 = oleReader["RESERVED2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(28))
						{
							model.Reserved3 = oleReader["RESERVED3"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(29))
						{
							model.Reserved4 = oleReader["RESERVED4"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(30))
						{
							model.Reserved5 = oleReader["RESERVED5"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(31))
						{
							model.Reserved6 = oleReader["RESERVED6"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(32))
						{
							model.Reserved7 = oleReader["RESERVED7"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(33))
						{
							model.Reserved8 = oleReader["RESERVED8"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(34))
						{
							model.Reserved9 = DateTime.Parse(oleReader["RESERVED9"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(35))
						{
							model.Reserved10 = DateTime.Parse(oleReader["RESERVED10"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(36))
						{
							model.Reserved11 = decimal.Parse(oleReader["RESERVED11"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(37))
						{
							model.Reserved12 = decimal.Parse(oleReader["RESERVED12"].ToString().Trim()) ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
	    
        public int SelectMaxCanceledId(string patientId, decimal visitId)
        {
            OracleParameter[] medMaxCanceledId = GetParameter("SelectMaxCanceledIdMedOperationCanceled");
            medMaxCanceledId[0].Value = patientId;
            medMaxCanceledId[1].Value = visitId;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_CANCELED_Select_Max_CanceledId, medMaxCanceledId))
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
	}
}
