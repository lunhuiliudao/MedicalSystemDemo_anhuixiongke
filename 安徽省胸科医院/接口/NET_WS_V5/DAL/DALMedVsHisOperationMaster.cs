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
    /// DAL MedVsHisOperationMaster
    /// </summary>

    public partial class DALMedVsHisOperationMaster
    {
        private static readonly string MED_VS_HIS_OPERATION_MASTER_Insert_SQL = "INSERT INTO MED_VS_HIS_OPERATION_MASTER (MED_PATIENT_ID,MED_VISIT_ID,MED_OPER_ID,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_OPER_ID,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,SURGEON,FIRST_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,FIRST_OPERATION_NURSE,FIRST_SUPPLY_NURSE,OPER_STATUS,OPERATION_NAME,CREATE_DATE,ALTER_DATE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5,RESERVED6,START_DATE_TIME,END_DATE_TIME,IN_DATE_TIME,OUT_DATE_TIME,IN_PACU_DATE_TIME,OUT_PACU_DATE_TIME,ANES_START_TIME,ANES_END_TIME) values (@medpatientid,@medvisitid,@medoperid,@hispatientid,@hisvisitid,@hisoperid,@scheduleddatetime,@operatingroom,@operatingroomno,@sequence,@surgeon,@firstassistant,@anesthesiamethod,@anesthesiadoctor,@anesthesiaassistant,@firstoperationnurse,@firstsupplynurse,@operstatus,@operationname,@createdate,@alterdate,@reserved1,@reserved2,@reserved3,@reserved4,@reserved5,@reserved6,@startdatetime,@enddatetime,@indatetime,@outdatetime,@inpacudatetime,@outpacudatetime,@anesstarttime,@anesendtime)";
        private static readonly string MED_VS_HIS_OPERATION_MASTER_Update_SQL = "UPDATE MED_VS_HIS_OPERATION_MASTER SET MED_PATIENT_ID = @medpatientid,MED_VISIT_ID = @medvisitid,MED_OPER_ID = @medoperid,HIS_PATIENT_ID = @hispatientid,HIS_VISIT_ID = @hisvisitid,HIS_OPER_ID = @hisoperid,SCHEDULED_DATE_TIME = @scheduleddatetime,OPERATING_ROOM = @operatingroom,OPERATING_ROOM_NO = @operatingroomno,SEQUENCE = @sequence,SURGEON = @surgeon,FIRST_ASSISTANT = @firstassistant,ANESTHESIA_METHOD = @anesthesiamethod,ANESTHESIA_DOCTOR = @anesthesiadoctor,ANESTHESIA_ASSISTANT = @anesthesiaassistant,FIRST_OPERATION_NURSE = @firstoperationnurse,FIRST_SUPPLY_NURSE = @firstsupplynurse,OPER_STATUS = @operstatus,OPERATION_NAME = @operationname,ALTER_DATE = @alterdate,RESERVED1 = @reserved1,RESERVED2 = @reserved2,RESERVED3 = @reserved3,RESERVED4 = @reserved4,RESERVED5 = @reserved5,RESERVED6 = @reserved6,START_DATE_TIME = @startdatetime,END_DATE_TIME = @enddatetime,IN_DATE_TIME = @indatetime,OUT_DATE_TIME = @outdatetime,IN_PACU_DATE_TIME = @inpacudatetime,OUT_PACU_DATE_TIME = @outpacudatetime,ANES_START_TIME = @anesstarttime,ANES_END_TIME = @anesendtime  WHERE MED_PATIENT_ID=@PatientIdP AND MED_VISIT_ID=@VisitIdP AND MED_OPER_ID=@OperIdP";
        private static readonly string MED_VS_HIS_OPERATION_MASTER_Select_SQL = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_OPER_ID,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_OPER_ID,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,SURGEON,FIRST_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,FIRST_OPERATION_NURSE,FIRST_SUPPLY_NURSE,OPER_STATUS,OPERATION_NAME,CREATE_DATE,ALTER_DATE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5,RESERVED6,START_DATE_TIME,END_DATE_TIME,IN_DATE_TIME,OUT_DATE_TIME,IN_PACU_DATE_TIME,OUT_PACU_DATE_TIME,ANES_START_TIME,ANES_END_TIME FROM MED_VS_HIS_OPERATION_MASTER where MED_PATIENT_ID=@PatientIdP AND MED_VISIT_ID=@VisitIdP AND MED_OPER_ID=@OperIdP";


        private static readonly string MED_VS_HIS_OPERATION_MASTER_Insert = "INSERT INTO MED_VS_HIS_OPERATION_MASTER (MED_PATIENT_ID,MED_VISIT_ID,MED_OPER_ID,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_OPER_ID,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,SURGEON,FIRST_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,FIRST_OPERATION_NURSE,FIRST_SUPPLY_NURSE,OPER_STATUS,OPERATION_NAME,CREATE_DATE,ALTER_DATE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5,RESERVED6,START_DATE_TIME,END_DATE_TIME,IN_DATE_TIME,OUT_DATE_TIME,IN_PACU_DATE_TIME,OUT_PACU_DATE_TIME,ANES_START_TIME,ANES_END_TIME) values (:medpatientid,:medvisitid,:medoperid,:hispatientid,:hisvisitid,:hisoperid,:scheduleddatetime,:operatingroom,:operatingroomno,:sequence,:surgeon,:firstassistant,:anesthesiamethod,:anesthesiadoctor,:anesthesiaassistant,:firstoperationnurse,:firstsupplynurse,:operstatus,:operationname,:createdate,:alterdate,:reserved1,:reserved2,:reserved3,:reserved4,:reserved5,:reserved6,:startdatetime,:enddatetime,:indatetime,:outdatetime,:inpacudatetime,:outpacudatetime,:anesstarttime,:anesendtime)";
        private static readonly string MED_VS_HIS_OPERATION_MASTER_Update = "UPDATE MED_VS_HIS_OPERATION_MASTER SET MED_PATIENT_ID = :medpatientid,MED_VISIT_ID = :medvisitid,MED_OPER_ID = :medoperid,HIS_PATIENT_ID = :hispatientid,HIS_VISIT_ID = :hisvisitid,HIS_OPER_ID = :hisoperid,SCHEDULED_DATE_TIME = :scheduleddatetime,OPERATING_ROOM = :operatingroom,OPERATING_ROOM_NO = :operatingroomno,SEQUENCE = :sequence,SURGEON = :surgeon,FIRST_ASSISTANT = :firstassistant,ANESTHESIA_METHOD = :anesthesiamethod,ANESTHESIA_DOCTOR = :anesthesiadoctor,ANESTHESIA_ASSISTANT = :anesthesiaassistant,FIRST_OPERATION_NURSE = :firstoperationnurse,FIRST_SUPPLY_NURSE = :firstsupplynurse,OPER_STATUS = :operstatus,OPERATION_NAME = :operationname,ALTER_DATE = :alterdate,RESERVED1 = :reserved1,RESERVED2 = :reserved2,RESERVED3 = :reserved3,RESERVED4 = :reserved4,RESERVED5 = :reserved5,RESERVED6 = :reserved6,START_DATE_TIME = :startdatetime,END_DATE_TIME = :enddatetime,IN_DATE_TIME = :indatetime,OUT_DATE_TIME = :outdatetime,IN_PACU_DATE_TIME = :inpacudatetime,OUT_PACU_DATE_TIME = :outpacudatetime,ANES_START_TIME = :anesstarttime,ANES_END_TIME = :anesendtime  WHERE MED_PATIENT_ID=:PatientIdP AND MED_VISIT_ID=:VisitIdP AND MED_OPER_ID=:OperIdP";
        private static readonly string MED_VS_HIS_OPERATION_MASTER_Select = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_OPER_ID,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_OPER_ID,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,SURGEON,FIRST_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,FIRST_OPERATION_NURSE,FIRST_SUPPLY_NURSE,OPER_STATUS,OPERATION_NAME,CREATE_DATE,ALTER_DATE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5,RESERVED6,START_DATE_TIME,END_DATE_TIME,IN_DATE_TIME,OUT_DATE_TIME,IN_PACU_DATE_TIME,OUT_PACU_DATE_TIME,ANES_START_TIME,ANES_END_TIME FROM MED_VS_HIS_OPERATION_MASTER where MED_PATIENT_ID=:PatientIdP AND MED_VISIT_ID=:VisitIdP AND MED_OPER_ID=:OperIdP";

        public DALMedVsHisOperationMaster()
        {
        }
        #region [获取参数SQL]
        /// <summary>
        ///获取参数MedVsHisOperationMaster SQL
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOperationMaster")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@medpatientid",SqlDbType.VarChar),
							new SqlParameter("@medvisitid",SqlDbType.Decimal),
							new SqlParameter("@medoperid",SqlDbType.Decimal),
							new SqlParameter("@hispatientid",SqlDbType.VarChar),
							new SqlParameter("@hisvisitid",SqlDbType.VarChar),
							new SqlParameter("@hisoperid",SqlDbType.VarChar),
							new SqlParameter("@scheduleddatetime",SqlDbType.DateTime),
							new SqlParameter("@operatingroom",SqlDbType.VarChar),
							new SqlParameter("@operatingroomno",SqlDbType.VarChar),
							new SqlParameter("@sequence",SqlDbType.Decimal),
							new SqlParameter("@surgeon",SqlDbType.VarChar),
							new SqlParameter("@firstassistant",SqlDbType.VarChar),
							new SqlParameter("@anesthesiamethod",SqlDbType.VarChar),
							new SqlParameter("@anesthesiadoctor",SqlDbType.VarChar),
							new SqlParameter("@anesthesiaassistant",SqlDbType.VarChar),
							new SqlParameter("@firstoperationnurse",SqlDbType.VarChar),
							new SqlParameter("@firstsupplynurse",SqlDbType.VarChar),
							new SqlParameter("@operstatus",SqlDbType.Decimal),
							new SqlParameter("@operationname",SqlDbType.VarChar),
                            new SqlParameter("@createdate",SqlDbType.DateTime),
							new SqlParameter("@alterdate",SqlDbType.DateTime),
							new SqlParameter("@reserved1",SqlDbType.VarChar),
							new SqlParameter("@reserved2",SqlDbType.VarChar),
							new SqlParameter("@reserved3",SqlDbType.VarChar),
							new SqlParameter("@reserved4",SqlDbType.VarChar),
							new SqlParameter("@reserved5",SqlDbType.VarChar),
							new SqlParameter("@reserved6",SqlDbType.VarChar),
                            new SqlParameter("@startdatetime",SqlDbType.DateTime),
                            new SqlParameter("@enddatetime",SqlDbType.DateTime),
                            new SqlParameter("@indatetime",SqlDbType.DateTime),
                            new SqlParameter("@outdatetime",SqlDbType.DateTime),
                            new SqlParameter("@inpacudatetime",SqlDbType.DateTime),
                            new SqlParameter("@outpacudatetime",SqlDbType.DateTime),
                            new SqlParameter("@anesstarttime",SqlDbType.DateTime),
                            new SqlParameter("@anesendtime",SqlDbType.DateTime)
                    };
                }
                else if (sqlParms == "UpdateMedVsHisOperationMaster")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@medpatientid",SqlDbType.VarChar),
							new SqlParameter("@medvisitid",SqlDbType.Decimal),
							new SqlParameter("@medoperid",SqlDbType.Decimal),
							new SqlParameter("@hispatientid",SqlDbType.VarChar),
							new SqlParameter("@hisvisitid",SqlDbType.VarChar),
							new SqlParameter("@hisoperid",SqlDbType.VarChar),
							new SqlParameter("@scheduleddatetime",SqlDbType.DateTime),
							new SqlParameter("@operatingroom",SqlDbType.VarChar),
							new SqlParameter("@operatingroomno",SqlDbType.VarChar),
							new SqlParameter("@sequence",SqlDbType.Decimal),
							new SqlParameter("@surgeon",SqlDbType.VarChar),
							new SqlParameter("@firstassistant",SqlDbType.VarChar),
							new SqlParameter("@anesthesiamethod",SqlDbType.VarChar),
							new SqlParameter("@anesthesiadoctor",SqlDbType.VarChar),
							new SqlParameter("@anesthesiaassistant",SqlDbType.VarChar),
							new SqlParameter("@firstoperationnurse",SqlDbType.VarChar),
							new SqlParameter("@firstsupplynurse",SqlDbType.VarChar),
							new SqlParameter("@operstatus",SqlDbType.Decimal),
							new SqlParameter("@operationname",SqlDbType.VarChar),
							new SqlParameter("@alterdate",SqlDbType.DateTime),
							new SqlParameter("@reserved1",SqlDbType.VarChar),
							new SqlParameter("@reserved2",SqlDbType.VarChar),
							new SqlParameter("@reserved3",SqlDbType.VarChar),
							new SqlParameter("@reserved4",SqlDbType.VarChar),
							new SqlParameter("@reserved5",SqlDbType.VarChar),
							new SqlParameter("@reserved6",SqlDbType.VarChar),
                            new SqlParameter("@startdatetime",SqlDbType.DateTime),
                            new SqlParameter("@enddatetime",SqlDbType.DateTime),
                            new SqlParameter("@indatetime",SqlDbType.DateTime),
                            new SqlParameter("@outdatetime",SqlDbType.DateTime),
                            new SqlParameter("@inpacudatetime",SqlDbType.DateTime),
                            new SqlParameter("@outpacudatetime",SqlDbType.DateTime),
                            new SqlParameter("@anesstarttime",SqlDbType.DateTime),
                            new SqlParameter("@anesendtime",SqlDbType.DateTime),
                            new SqlParameter("@PatientIdP",SqlDbType.VarChar),
                            new SqlParameter("@VisitIdP",SqlDbType.Decimal),
                            new SqlParameter("@OperIdP",SqlDbType.Decimal)
                    };
                }
                else if (sqlParms == "SelectMedVsHisOperationMaster")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientIdP",SqlDbType.VarChar),
							new SqlParameter("@VisitIdP",SqlDbType.Decimal),
							new SqlParameter("@OperIdP",SqlDbType.Decimal),
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
        ///Insert Table MED_VS_HIS_OPERATION_SCHEDULE
        /// </summary>
        public int InsertMedVsHisOperationMasterSQL(MedVsHisOperationMaster model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedVsHisOperationMaster");
                if (model.MedPatientId != null)
                    oneInert[0].Value = model.MedPatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneInert[1].Value = model.MedVisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.MedOperId.ToString() != null)
                    oneInert[2].Value = model.MedOperId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneInert[3].Value = model.HisPatientId;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneInert[4].Value = model.HisVisitId;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.HisOperId != null)
                    oneInert[5].Value = model.HisOperId;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.ScheduledDateTime > DateTime.MinValue)
                    oneInert[6].Value = model.ScheduledDateTime;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.OperatingRoom != null)
                    oneInert[7].Value = model.OperatingRoom;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.OperatingRoomNo != null)
                    oneInert[8].Value = model.OperatingRoomNo;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Sequence.ToString() != null)
                    oneInert[9].Value = model.Sequence;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.Surgeon != null)
                    oneInert[10].Value = model.Surgeon;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.FirstAssistant != null)
                    oneInert[11].Value = model.FirstAssistant;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.AnesthesiaMethod != null)
                    oneInert[12].Value = model.AnesthesiaMethod;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.AnesthesiaDoctor != null)
                    oneInert[13].Value = model.AnesthesiaDoctor;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.AnesthesiaAssistant != null)
                    oneInert[14].Value = model.AnesthesiaAssistant;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.FirstOperationNurse != null)
                    oneInert[15].Value = model.FirstOperationNurse;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.FirstSupplyNurse != null)
                    oneInert[16].Value = model.FirstSupplyNurse;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.OperStatus.ToString() != null)
                    oneInert[17].Value = model.OperStatus;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.OperationName != null)
                    oneInert[18].Value = model.OperationName;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.CreateDate > DateTime.MinValue)
                    oneInert[19].Value = model.CreateDate;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.AlterDate > DateTime.MinValue)
                    oneInert[20].Value = model.AlterDate;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneInert[21].Value = model.Reserved1;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.Reserved2 != null)
                    oneInert[22].Value = model.Reserved2;
                else
                    oneInert[22].Value = DBNull.Value;
                if (model.Reserved3 != null)
                    oneInert[23].Value = model.Reserved3;
                else
                    oneInert[23].Value = DBNull.Value;
                if (model.Reserved4 != null)
                    oneInert[24].Value = model.Reserved4;
                else
                    oneInert[24].Value = DBNull.Value;
                if (model.Reserved5 != null)
                    oneInert[25].Value = model.Reserved5;
                else
                    oneInert[25].Value = DBNull.Value;
                if (model.Reserved6 != null)
                    oneInert[26].Value = model.Reserved6;
                else
                    oneInert[26].Value = DBNull.Value;
                if (model.StartDateTime > DateTime.MinValue)
                    oneInert[27].Value = model.StartDateTime;
                else
                    oneInert[27].Value = DBNull.Value;
                if (model.EndDateTime > DateTime.MinValue)
                    oneInert[28].Value = model.EndDateTime;
                else
                    oneInert[28].Value = DBNull.Value;
                if (model.InDateTime > DateTime.MinValue)
                    oneInert[29].Value = model.InDateTime;
                else
                    oneInert[29].Value = DBNull.Value;
                if (model.OutDateTime > DateTime.MinValue)
                    oneInert[30].Value = model.OutDateTime;
                else
                    oneInert[30].Value = DBNull.Value;
                if (model.InPacuDateTime > DateTime.MinValue)
                    oneInert[31].Value = model.InPacuDateTime;
                else
                    oneInert[31].Value = DBNull.Value;
                if (model.OutPacuDateTime > DateTime.MinValue)
                    oneInert[32].Value = model.OutPacuDateTime;
                else
                    oneInert[32].Value = DBNull.Value;
                if (model.AnesStartTime > DateTime.MinValue)
                    oneInert[33].Value = model.AnesStartTime;
                else
                    oneInert[33].Value = DBNull.Value;
                if (model.AnesEndTime > DateTime.MinValue)
                    oneInert[34].Value = model.AnesEndTime;
                else
                    oneInert[34].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_OPERATION_MASTER_Insert_SQL, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedOperationSchedule 
        ///Update Table     MED_OPERATION_SCHEDULE
        /// </summary>
        public int UpdateMedVsHisOperationMasterSQL(MedVsHisOperationMaster model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedVsHisOperationMaster");
                if (model.MedPatientId != null)
                    oneUpdate[0].Value = model.MedPatientId;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneUpdate[1].Value = model.MedVisitId;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.MedOperId.ToString() != null)
                    oneUpdate[2].Value = model.MedOperId;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneUpdate[3].Value = model.HisPatientId;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneUpdate[4].Value = model.HisVisitId;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.HisOperId != null)
                    oneUpdate[5].Value = model.HisOperId;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.ScheduledDateTime > DateTime.MinValue)
                    oneUpdate[6].Value = model.ScheduledDateTime;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.OperatingRoom != null)
                    oneUpdate[7].Value = model.OperatingRoom;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.OperatingRoomNo != null)
                    oneUpdate[8].Value = model.OperatingRoomNo;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.Sequence.ToString() != null)
                    oneUpdate[9].Value = model.Sequence;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.Surgeon != null)
                    oneUpdate[10].Value = model.Surgeon;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.FirstAssistant != null)
                    oneUpdate[11].Value = model.FirstAssistant;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.AnesthesiaMethod != null)
                    oneUpdate[12].Value = model.AnesthesiaMethod;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.AnesthesiaDoctor != null)
                    oneUpdate[13].Value = model.AnesthesiaDoctor;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.AnesthesiaAssistant != null)
                    oneUpdate[14].Value = model.AnesthesiaAssistant;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.FirstOperationNurse != null)
                    oneUpdate[15].Value = model.FirstOperationNurse;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.FirstSupplyNurse != null)
                    oneUpdate[16].Value = model.FirstSupplyNurse;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.OperStatus.ToString() != null)
                    oneUpdate[17].Value = model.OperStatus;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.OperationName != null)
                    oneUpdate[18].Value = model.OperationName;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.AlterDate > DateTime.MinValue)
                    oneUpdate[19].Value = model.AlterDate;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneUpdate[20].Value = model.Reserved1;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.Reserved2 != null)
                    oneUpdate[21].Value = model.Reserved2;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.Reserved3 != null)
                    oneUpdate[22].Value = model.Reserved3;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.Reserved4 != null)
                    oneUpdate[23].Value = model.Reserved4;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.Reserved5 != null)
                    oneUpdate[24].Value = model.Reserved5;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.Reserved6 != null)
                    oneUpdate[25].Value = model.Reserved6;
                else
                    oneUpdate[25].Value = DBNull.Value;
                if (model.StartDateTime > DateTime.MinValue)
                    oneUpdate[26].Value = model.StartDateTime;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (model.EndDateTime > DateTime.MinValue)
                    oneUpdate[27].Value = model.EndDateTime;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (model.InDateTime > DateTime.MinValue)
                    oneUpdate[28].Value = model.InDateTime;
                else
                    oneUpdate[28].Value = DBNull.Value;
                if (model.OutDateTime > DateTime.MinValue)
                    oneUpdate[29].Value = model.OutDateTime;
                else
                    oneUpdate[29].Value = DBNull.Value;
                if (model.InPacuDateTime > DateTime.MinValue)
                    oneUpdate[30].Value = model.InPacuDateTime;
                else
                    oneUpdate[30].Value = DBNull.Value;
                if (model.OutPacuDateTime > DateTime.MinValue)
                    oneUpdate[31].Value = model.OutPacuDateTime;
                else
                    oneUpdate[31].Value = DBNull.Value;
                if (model.AnesStartTime > DateTime.MinValue)
                    oneUpdate[32].Value = model.AnesStartTime;
                else
                    oneUpdate[32].Value = DBNull.Value;
                if (model.AnesEndTime > DateTime.MinValue)
                    oneUpdate[33].Value = model.AnesEndTime;
                else
                    oneUpdate[33].Value = DBNull.Value;
                if (model.MedPatientId != null)
                    oneUpdate[34].Value = model.MedPatientId;
                else
                    oneUpdate[34].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneUpdate[35].Value = model.MedVisitId;
                else
                    oneUpdate[35].Value = DBNull.Value;
                if (model.MedOperId.ToString() != null)
                    oneUpdate[36].Value = model.MedOperId;
                else
                    oneUpdate[36].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_OPERATION_MASTER_Update_SQL, oneUpdate);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedOperationSchedule 
        ///select Table MED_OPERATION_SCHEDULE by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
        /// </summary>
        public MedVsHisOperationMaster SelectMedVsHisOperationMasterSQL(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID)
        {
            MedVsHisOperationMaster model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedVsHisOperationMaster");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = OPER_ID;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPERATION_MASTER_Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new  MedVsHisOperationMaster();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.MedPatientId = oleReader["MED_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.MedVisitId = decimal.Parse(oleReader["MED_VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.MedOperId = decimal.Parse(oleReader["MED_OPER_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.HisOperId = oleReader["HIS_OPER_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ScheduledDateTime = DateTime.Parse(oleReader["SCHEDULED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.OperatingRoom = oleReader["OPERATING_ROOM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.OperatingRoomNo = oleReader["OPERATING_ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Sequence = decimal.Parse(oleReader["SEQUENCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Surgeon = oleReader["SURGEON"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.FirstAssistant = oleReader["FIRST_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.AnesthesiaMethod = oleReader["ANESTHESIA_METHOD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.AnesthesiaDoctor = oleReader["ANESTHESIA_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.AnesthesiaAssistant = oleReader["ANESTHESIA_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.FirstOperationNurse = oleReader["FIRST_OPERATION_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.FirstSupplyNurse = oleReader["FIRST_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.OperStatus = decimal.Parse(oleReader["OPER_STATUS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.OperationName = oleReader["OPERATION_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.AlterDate = DateTime.Parse(oleReader["ALTER_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.Reserved4 = oleReader["RESERVED4"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Reserved5 = oleReader["RESERVED5"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Reserved6 = oleReader["RESERVED6"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.StartDateTime = DateTime.Parse(oleReader["START_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.EndDateTime = DateTime.Parse(oleReader["END_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.InDateTime = DateTime.Parse(oleReader["IN_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.OutDateTime = DateTime.Parse(oleReader["OUT_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.InPacuDateTime = DateTime.Parse(oleReader["IN_PACU_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.OutPacuDateTime = DateTime.Parse(oleReader["OUT_PACU_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.AnesStartTime = DateTime.Parse(oleReader["ANES_START_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.AnesEndTime = DateTime.Parse(oleReader["ANES_END_TIME"].ToString().Trim());
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion

        #region [获取参数]
        /// <summary>
        ///获取参数MedVsHisOperationMaster SQL
        /// </summary>
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOperationMaster")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":medpatientid",OracleType.VarChar),
							new OracleParameter(":medvisitid",OracleType.Number),
							new OracleParameter(":medoperid",OracleType.Number),
							new OracleParameter(":hispatientid",OracleType.VarChar),
							new OracleParameter(":hisvisitid",OracleType.VarChar),
							new OracleParameter(":hisoperid",OracleType.VarChar),
							new OracleParameter(":scheduleddatetime",OracleType.DateTime),
							new OracleParameter(":operatingroom",OracleType.VarChar),
							new OracleParameter(":operatingroomno",OracleType.VarChar),
							new OracleParameter(":sequence",OracleType.Number),
							new OracleParameter(":surgeon",OracleType.VarChar),
							new OracleParameter(":firstassistant",OracleType.VarChar),
							new OracleParameter(":anesthesiamethod",OracleType.VarChar),
							new OracleParameter(":anesthesiadoctor",OracleType.VarChar),
							new OracleParameter(":anesthesiaassistant",OracleType.VarChar),
							new OracleParameter(":firstoperationnurse",OracleType.VarChar),
							new OracleParameter(":firstsupplynurse",OracleType.VarChar),
							new OracleParameter(":operstatus",OracleType.Number),
							new OracleParameter(":operationname",OracleType.VarChar),
                            new OracleParameter(":createdate",OracleType.DateTime),
							new OracleParameter(":alterdate",OracleType.DateTime),
							new OracleParameter(":reserved1",OracleType.VarChar),
							new OracleParameter(":reserved2",OracleType.VarChar),
							new OracleParameter(":reserved3",OracleType.VarChar),
							new OracleParameter(":reserved4",OracleType.VarChar),
							new OracleParameter(":reserved5",OracleType.VarChar),
							new OracleParameter(":reserved6",OracleType.VarChar),
                            new OracleParameter(":startdatetime",OracleType.DateTime),
                            new OracleParameter(":enddatetime",OracleType.DateTime),
                            new OracleParameter(":indatetime",OracleType.DateTime),
                            new OracleParameter(":outdatetime",OracleType.DateTime),
                            new OracleParameter(":inpacudatetime",OracleType.DateTime),
                            new OracleParameter(":outpacudatetime",OracleType.DateTime),
                            new OracleParameter(":anesstarttime",OracleType.DateTime),
                            new OracleParameter(":anesendtime",OracleType.DateTime)
                    };
                }
                else if (sqlParms == "UpdateMedVsHisOperationMaster")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":medpatientid",OracleType.VarChar),
							new OracleParameter(":medvisitid",OracleType.Number),
							new OracleParameter(":medoperid",OracleType.Number),
							new OracleParameter(":hispatientid",OracleType.VarChar),
							new OracleParameter(":hisvisitid",OracleType.VarChar),
							new OracleParameter(":hisoperid",OracleType.VarChar),
							new OracleParameter(":scheduleddatetime",OracleType.DateTime),
							new OracleParameter(":operatingroom",OracleType.VarChar),
							new OracleParameter(":operatingroomno",OracleType.VarChar),
							new OracleParameter(":sequence",OracleType.Number),
							new OracleParameter(":surgeon",OracleType.VarChar),
							new OracleParameter(":firstassistant",OracleType.VarChar),
							new OracleParameter(":anesthesiamethod",OracleType.VarChar),
							new OracleParameter(":anesthesiadoctor",OracleType.VarChar),
							new OracleParameter(":anesthesiaassistant",OracleType.VarChar),
							new OracleParameter(":firstoperationnurse",OracleType.VarChar),
							new OracleParameter(":firstsupplynurse",OracleType.VarChar),
							new OracleParameter(":operstatus",OracleType.Number),
							new OracleParameter(":operationname",OracleType.VarChar),
							new OracleParameter(":alterdate",OracleType.DateTime),
							new OracleParameter(":reserved1",OracleType.VarChar),
							new OracleParameter(":reserved2",OracleType.VarChar),
							new OracleParameter(":reserved3",OracleType.VarChar),
							new OracleParameter(":reserved4",OracleType.VarChar),
							new OracleParameter(":reserved5",OracleType.VarChar),
							new OracleParameter(":reserved6",OracleType.VarChar),
                            new OracleParameter(":startdatetime",OracleType.DateTime),
                            new OracleParameter(":enddatetime",OracleType.DateTime),
                            new OracleParameter(":indatetime",OracleType.DateTime),
                            new OracleParameter(":outdatetime",OracleType.DateTime),
                            new OracleParameter(":inpacudatetime",OracleType.DateTime),
                            new OracleParameter(":outpacudatetime",OracleType.DateTime),
                            new OracleParameter(":anesstarttime",OracleType.DateTime),
                            new OracleParameter(":anesendtime",OracleType.DateTime),
                            new OracleParameter(":PatientIdP",OracleType.VarChar),
                            new OracleParameter(":VisitIdP",OracleType.Number),
                            new OracleParameter(":OperIdP",OracleType.Number)
                    };
                }
                else if (sqlParms == "SelectMedVsHisOperationMaster")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientIdP",OracleType.VarChar),
							new OracleParameter(":VisitIdP",OracleType.Number),
							new OracleParameter(":OperIdP",OracleType.Number),
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
        ///Insert Table MED_VS_HIS_OPERATION_SCHEDULE
        /// </summary>
        public int InsertMedVsHisOperationMaster(MedVsHisOperationMaster model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedVsHisOperationMaster");
                if (model.MedPatientId != null)
                    oneInert[0].Value = model.MedPatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneInert[1].Value = model.MedVisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.MedOperId.ToString() != null)
                    oneInert[2].Value = model.MedOperId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneInert[3].Value = model.HisPatientId;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneInert[4].Value = model.HisVisitId;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.HisOperId != null)
                    oneInert[5].Value = model.HisOperId;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.ScheduledDateTime > DateTime.MinValue)
                    oneInert[6].Value = model.ScheduledDateTime;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.OperatingRoom != null)
                    oneInert[7].Value = model.OperatingRoom;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.OperatingRoomNo != null)
                    oneInert[8].Value = model.OperatingRoomNo;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Sequence.ToString() != null)
                    oneInert[9].Value = model.Sequence;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.Surgeon != null)
                    oneInert[10].Value = model.Surgeon;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.FirstAssistant != null)
                    oneInert[11].Value = model.FirstAssistant;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.AnesthesiaMethod != null)
                    oneInert[12].Value = model.AnesthesiaMethod;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.AnesthesiaDoctor != null)
                    oneInert[13].Value = model.AnesthesiaDoctor;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.AnesthesiaAssistant != null)
                    oneInert[14].Value = model.AnesthesiaAssistant;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.FirstOperationNurse != null)
                    oneInert[15].Value = model.FirstOperationNurse;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.FirstSupplyNurse != null)
                    oneInert[16].Value = model.FirstSupplyNurse;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.OperStatus.ToString() != null)
                    oneInert[17].Value = model.OperStatus;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.OperationName != null)
                    oneInert[18].Value = model.OperationName;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.CreateDate > DateTime.MinValue)
                    oneInert[19].Value = model.CreateDate;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.AlterDate > DateTime.MinValue)
                    oneInert[20].Value = model.AlterDate;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneInert[21].Value = model.Reserved1;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.Reserved2 != null)
                    oneInert[22].Value = model.Reserved2;
                else
                    oneInert[22].Value = DBNull.Value;
                if (model.Reserved3 != null)
                    oneInert[23].Value = model.Reserved3;
                else
                    oneInert[23].Value = DBNull.Value;
                if (model.Reserved4 != null)
                    oneInert[24].Value = model.Reserved4;
                else
                    oneInert[24].Value = DBNull.Value;
                if (model.Reserved5 != null)
                    oneInert[25].Value = model.Reserved5;
                else
                    oneInert[25].Value = DBNull.Value;
                if (model.Reserved6 != null)
                    oneInert[26].Value = model.Reserved6;
                else
                    oneInert[26].Value = DBNull.Value;
                if (model.StartDateTime > DateTime.MinValue)
                    oneInert[27].Value = model.StartDateTime;
                else
                    oneInert[27].Value = DBNull.Value;
                if (model.EndDateTime > DateTime.MinValue)
                    oneInert[28].Value = model.EndDateTime;
                else
                    oneInert[28].Value = DBNull.Value;
                if (model.InDateTime > DateTime.MinValue)
                    oneInert[29].Value = model.InDateTime;
                else
                    oneInert[29].Value = DBNull.Value;
                if (model.OutDateTime > DateTime.MinValue)
                    oneInert[30].Value = model.OutDateTime;
                else
                    oneInert[30].Value = DBNull.Value;
                if (model.InPacuDateTime > DateTime.MinValue)
                    oneInert[31].Value = model.InPacuDateTime;
                else
                    oneInert[31].Value = DBNull.Value;
                if (model.OutPacuDateTime > DateTime.MinValue)
                    oneInert[32].Value = model.OutPacuDateTime;
                else
                    oneInert[32].Value = DBNull.Value;
                if (model.AnesStartTime > DateTime.MinValue)
                    oneInert[33].Value = model.AnesStartTime;
                else
                    oneInert[33].Value = DBNull.Value;
                if (model.AnesEndTime > DateTime.MinValue)
                    oneInert[34].Value = model.AnesEndTime;
                else
                    oneInert[34].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_OPERATION_MASTER_Insert, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedOperationSchedule 
        ///Update Table     MED_OPERATION_SCHEDULE
        /// </summary>
        public int UpdateMedVsHisOperationMaster(MedVsHisOperationMaster model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedVsHisOperationMaster");
                if (model.MedPatientId != null)
                    oneUpdate[0].Value = model.MedPatientId;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneUpdate[1].Value = model.MedVisitId;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.MedOperId.ToString() != null)
                    oneUpdate[2].Value = model.MedOperId;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneUpdate[3].Value = model.HisPatientId;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneUpdate[4].Value = model.HisVisitId;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.HisOperId != null)
                    oneUpdate[5].Value = model.HisOperId;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.ScheduledDateTime > DateTime.MinValue)
                    oneUpdate[6].Value = model.ScheduledDateTime;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.OperatingRoom != null)
                    oneUpdate[7].Value = model.OperatingRoom;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.OperatingRoomNo != null)
                    oneUpdate[8].Value = model.OperatingRoomNo;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.Sequence.ToString() != null)
                    oneUpdate[9].Value = model.Sequence;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.Surgeon != null)
                    oneUpdate[10].Value = model.Surgeon;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.FirstAssistant != null)
                    oneUpdate[11].Value = model.FirstAssistant;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.AnesthesiaMethod != null)
                    oneUpdate[12].Value = model.AnesthesiaMethod;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.AnesthesiaDoctor != null)
                    oneUpdate[13].Value = model.AnesthesiaDoctor;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.AnesthesiaAssistant != null)
                    oneUpdate[14].Value = model.AnesthesiaAssistant;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.FirstOperationNurse != null)
                    oneUpdate[15].Value = model.FirstOperationNurse;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.FirstSupplyNurse != null)
                    oneUpdate[16].Value = model.FirstSupplyNurse;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.OperStatus.ToString() != null)
                    oneUpdate[17].Value = model.OperStatus;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.OperationName != null)
                    oneUpdate[18].Value = model.OperationName;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.AlterDate > DateTime.MinValue)
                    oneUpdate[19].Value = model.AlterDate;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneUpdate[20].Value = model.Reserved1;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.Reserved2 != null)
                    oneUpdate[21].Value = model.Reserved2;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.Reserved3 != null)
                    oneUpdate[22].Value = model.Reserved3;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.Reserved4 != null)
                    oneUpdate[23].Value = model.Reserved4;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.Reserved5 != null)
                    oneUpdate[24].Value = model.Reserved5;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.Reserved6 != null)
                    oneUpdate[25].Value = model.Reserved6;
                else
                    oneUpdate[25].Value = DBNull.Value;
                if (model.StartDateTime > DateTime.MinValue)
                    oneUpdate[26].Value = model.StartDateTime;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (model.EndDateTime > DateTime.MinValue)
                    oneUpdate[27].Value = model.EndDateTime;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (model.InDateTime > DateTime.MinValue)
                    oneUpdate[28].Value = model.InDateTime;
                else
                    oneUpdate[28].Value = DBNull.Value;
                if (model.OutDateTime > DateTime.MinValue)
                    oneUpdate[29].Value = model.OutDateTime;
                else
                    oneUpdate[29].Value = DBNull.Value;
                if (model.InPacuDateTime > DateTime.MinValue)
                    oneUpdate[30].Value = model.InPacuDateTime;
                else
                    oneUpdate[30].Value = DBNull.Value;
                if (model.OutPacuDateTime > DateTime.MinValue)
                    oneUpdate[31].Value = model.OutPacuDateTime;
                else
                    oneUpdate[31].Value = DBNull.Value;
                if (model.AnesStartTime > DateTime.MinValue)
                    oneUpdate[32].Value = model.AnesStartTime;
                else
                    oneUpdate[32].Value = DBNull.Value;
                if (model.AnesEndTime > DateTime.MinValue)
                    oneUpdate[33].Value = model.AnesEndTime;
                else
                    oneUpdate[33].Value = DBNull.Value;
                if (model.MedPatientId != null)
                    oneUpdate[34].Value = model.MedPatientId;
                else
                    oneUpdate[34].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneUpdate[35].Value = model.MedVisitId;
                else
                    oneUpdate[35].Value = DBNull.Value;
                if (model.MedOperId.ToString() != null)
                    oneUpdate[36].Value = model.MedOperId;
                else
                    oneUpdate[36].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_OPERATION_MASTER_Update, oneUpdate);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedOperationSchedule 
        ///select Table MED_OPERATION_SCHEDULE by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
        /// </summary>
        public MedVsHisOperationMaster SelectMedVsHisOperationMaster(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID)
        {
            MedVsHisOperationMaster model;
            OracleParameter[] parameterValues = GetParameter("SelectMedVsHisOperationMaster");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = OPER_ID;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPERATION_MASTER_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisOperationMaster();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.MedPatientId = oleReader["MED_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.MedVisitId = decimal.Parse(oleReader["MED_VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.MedOperId = decimal.Parse(oleReader["MED_OPER_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.HisOperId = oleReader["HIS_OPER_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ScheduledDateTime = DateTime.Parse(oleReader["SCHEDULED_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.OperatingRoom = oleReader["OPERATING_ROOM"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.OperatingRoomNo = oleReader["OPERATING_ROOM_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Sequence = decimal.Parse(oleReader["SEQUENCE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Surgeon = oleReader["SURGEON"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.FirstAssistant = oleReader["FIRST_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.AnesthesiaMethod = oleReader["ANESTHESIA_METHOD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.AnesthesiaDoctor = oleReader["ANESTHESIA_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.AnesthesiaAssistant = oleReader["ANESTHESIA_ASSISTANT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.FirstOperationNurse = oleReader["FIRST_OPERATION_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.FirstSupplyNurse = oleReader["FIRST_SUPPLY_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.OperStatus = decimal.Parse(oleReader["OPER_STATUS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.OperationName = oleReader["OPERATION_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.AlterDate = DateTime.Parse(oleReader["ALTER_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.Reserved4 = oleReader["RESERVED4"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Reserved5 = oleReader["RESERVED5"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Reserved6 = oleReader["RESERVED6"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.StartDateTime = DateTime.Parse(oleReader["START_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.EndDateTime = DateTime.Parse(oleReader["END_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.InDateTime = DateTime.Parse(oleReader["IN_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.OutDateTime = DateTime.Parse(oleReader["OUT_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.InPacuDateTime = DateTime.Parse(oleReader["IN_PACU_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.OutPacuDateTime = DateTime.Parse(oleReader["OUT_PACU_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.AnesStartTime = DateTime.Parse(oleReader["ANES_START_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.AnesEndTime = DateTime.Parse(oleReader["ANES_END_TIME"].ToString().Trim());
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion

    }
}
