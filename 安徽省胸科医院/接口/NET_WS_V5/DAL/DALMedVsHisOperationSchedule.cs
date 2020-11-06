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
    /// DAL MedVsHisOperationSchedule
    /// </summary>

    public partial class DALMedVsHisOperationSchedule
    {
        private static readonly string MED_VS_HIS_OPERATION_SCHEDULE_Insert_SQL = "INSERT INTO MED_VS_HIS_OPERATION_SCHEDULE (MED_PATIENT_ID,MED_VISIT_ID,MED_SCHEDULE_ID,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,SURGEON,FIRST_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,FIRST_OPERATION_NURSE,FIRST_SUPPLY_NURSE,STATE,OPERATION_NAME,CREATE_DATE,ALTER_DATE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5,RESERVED6) values (@medpatientid,@medvisitid,@medscheduleid,@hispatientid,@hisvisitid,@hisscheduleid,@scheduleddatetime,@operatingroom,@operatingroomno,@sequence,@surgeon,@firstassistant,@anesthesiamethod,@anesthesiadoctor,@anesthesiaassistant,@firstoperationnurse,@firstsupplynurse,@state,@operationname,@createdate,@alterdate,@reserved1,@reserved2,@reserved3,@reserved4,@reserved5,@reserved6)";
        private static readonly string MED_VS_HIS_OPERATION_SCHEDULE_Update_SQL = "UPDATE MED_VS_HIS_OPERATION_SCHEDULE SET MED_PATIENT_ID = @medpatientid,MED_VISIT_ID = @medvisitid,MED_SCHEDULE_ID = @medscheduleid,HIS_PATIENT_ID = @hispatientid,HIS_VISIT_ID = @hisvisitid,HIS_SCHEDULE_ID = @hisscheduleid,SCHEDULED_DATE_TIME = @scheduleddatetime,OPERATING_ROOM = @operatingroom,OPERATING_ROOM_NO = @operatingroomno,SEQUENCE = @sequence,SURGEON = @surgeon,FIRST_ASSISTANT = @firstassistant,ANESTHESIA_METHOD = @anesthesiamethod,ANESTHESIA_DOCTOR = @anesthesiadoctor,ANESTHESIA_ASSISTANT = @anesthesiaassistant,FIRST_OPERATION_NURSE = @firstoperationnurse,FIRST_SUPPLY_NURSE = @firstsupplynurse,STATE = @state,OPERATION_NAME = @operationname,ALTER_DATE = @alterdate,RESERVED1 = @reserved1,RESERVED2 = @reserved2,RESERVED3 = @reserved3,RESERVED4 = @reserved4,RESERVED5 = @reserved5,RESERVED6 = @reserved6 WHERE MED_PATIENT_ID=@PatientIdP AND MED_VISIT_ID=@VisitIdP AND MED_SCHEDULE_ID=@ScheduleIdP";
        private static readonly string MED_VS_HIS_OPERATION_SCHEDULE_Select_SQL = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_SCHEDULE_ID,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,SURGEON,FIRST_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,FIRST_OPERATION_NURSE,FIRST_SUPPLY_NURSE,STATE,OPERATION_NAME,CREATE_DATE,ALTER_DATE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5,RESERVED6 FROM MED_VS_HIS_OPERATION_SCHEDULE where MED_PATIENT_ID=@PatientIdP AND MED_VISIT_ID=@VisitIdP AND MED_SCHEDULE_ID=@ScheduleIdP";


        private static readonly string MED_VS_HIS_OPERATION_SCHEDULE_Insert = "INSERT INTO MED_VS_HIS_OPERATION_SCHEDULE (MED_PATIENT_ID,MED_VISIT_ID,MED_SCHEDULE_ID,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,SURGEON,FIRST_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,FIRST_OPERATION_NURSE,FIRST_SUPPLY_NURSE,STATE,OPERATION_NAME,CREATE_DATE,ALTER_DATE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5,RESERVED6) values (:medpatientid,:medvisitid,:medscheduleid,:hispatientid,:hisvisitid,:hisscheduleid,:scheduleddatetime,:operatingroom,:operatingroomno,:sequence,:surgeon,:firstassistant,:anesthesiamethod,:anesthesiadoctor,:anesthesiaassistant,:firstoperationnurse,:firstsupplynurse,:state,:operationname,:createdate,:alterdate,:reserved1,:reserved2,:reserved3,:reserved4,:reserved5,:reserved6)";
        private static readonly string MED_VS_HIS_OPERATION_SCHEDULE_Update = "UPDATE MED_VS_HIS_OPERATION_SCHEDULE SET MED_PATIENT_ID = :medpatientid,MED_VISIT_ID = :medvisitid,MED_SCHEDULE_ID = :medscheduleid,HIS_PATIENT_ID = :hispatientid,HIS_VISIT_ID = :hisvisitid,HIS_SCHEDULE_ID = :hisscheduleid,SCHEDULED_DATE_TIME = :scheduleddatetime,OPERATING_ROOM = :operatingroom,OPERATING_ROOM_NO = :operatingroomno,SEQUENCE = :sequence,SURGEON = :surgeon,FIRST_ASSISTANT = :firstassistant,ANESTHESIA_METHOD = :anesthesiamethod,ANESTHESIA_DOCTOR = :anesthesiadoctor,ANESTHESIA_ASSISTANT = :anesthesiaassistant,FIRST_OPERATION_NURSE = :firstoperationnurse,FIRST_SUPPLY_NURSE = :firstsupplynurse,STATE = :state,OPERATION_NAME = :operationname,ALTER_DATE = :alterdate,RESERVED1 = :reserved1,RESERVED2 = :reserved2,RESERVED3 = :reserved3,RESERVED4 = :reserved4,RESERVED5 = :reserved5,RESERVED6 = :reserved6 WHERE MED_PATIENT_ID=:PatientIdP AND MED_VISIT_ID=:VisitIdP AND MED_SCHEDULE_ID=:ScheduleIdP";
        private static readonly string MED_VS_HIS_OPERATION_SCHEDULE_Select = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_SCHEDULE_ID,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,SCHEDULED_DATE_TIME,OPERATING_ROOM,OPERATING_ROOM_NO,SEQUENCE,SURGEON,FIRST_ASSISTANT,ANESTHESIA_METHOD,ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,FIRST_OPERATION_NURSE,FIRST_SUPPLY_NURSE,STATE,OPERATION_NAME,CREATE_DATE,ALTER_DATE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5,RESERVED6 FROM MED_VS_HIS_OPERATION_SCHEDULE where MED_PATIENT_ID=:PatientIdP AND MED_VISIT_ID=:VisitIdP AND MED_SCHEDULE_ID=:ScheduleIdP";

        public DALMedVsHisOperationSchedule()
        {
        }
        #region [获取参数SQL]
        /// <summary>
        ///获取参数MedVsHisOperationSchedule SQL
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOperationSchedule")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@medpatientid",SqlDbType.VarChar),
							new SqlParameter("@medvisitid",SqlDbType.Decimal),
							new SqlParameter("@medscheduleid",SqlDbType.Decimal),
							new SqlParameter("@hispatientid",SqlDbType.VarChar),
							new SqlParameter("@hisvisitid",SqlDbType.VarChar),
							new SqlParameter("@hisscheduleid",SqlDbType.VarChar),
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
							new SqlParameter("@state",SqlDbType.Decimal),
							new SqlParameter("@operationname",SqlDbType.VarChar),
                            new SqlParameter("@createdate",SqlDbType.DateTime),
							new SqlParameter("@alterdate",SqlDbType.DateTime),
							new SqlParameter("@reserved1",SqlDbType.VarChar),
							new SqlParameter("@reserved2",SqlDbType.VarChar),
							new SqlParameter("@reserved3",SqlDbType.VarChar),
							new SqlParameter("@reserved4",SqlDbType.VarChar),
							new SqlParameter("@reserved5",SqlDbType.VarChar),
							new SqlParameter("@reserved6",SqlDbType.VarChar)
                    };
                }
                else if (sqlParms == "UpdateMedVsHisOperationSchedule")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@medpatientid",SqlDbType.VarChar),
							new SqlParameter("@medvisitid",SqlDbType.Decimal),
							new SqlParameter("@medscheduleid",SqlDbType.Decimal),
							new SqlParameter("@hispatientid",SqlDbType.VarChar),
							new SqlParameter("@hisvisitid",SqlDbType.VarChar),
							new SqlParameter("@hisscheduleid",SqlDbType.VarChar),
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
							new SqlParameter("@state",SqlDbType.Decimal),
							new SqlParameter("@operationname",SqlDbType.VarChar),
							new SqlParameter("@alterdate",SqlDbType.DateTime),
							new SqlParameter("@reserved1",SqlDbType.VarChar),
							new SqlParameter("@reserved2",SqlDbType.VarChar),
							new SqlParameter("@reserved3",SqlDbType.VarChar),
							new SqlParameter("@reserved4",SqlDbType.VarChar),
							new SqlParameter("@reserved5",SqlDbType.VarChar),
							new SqlParameter("@reserved6",SqlDbType.VarChar),
                            new SqlParameter("@PatientIdP",SqlDbType.VarChar),
                            new SqlParameter("@VisitIdP",SqlDbType.Decimal),
                            new SqlParameter("@ScheduleIdP",SqlDbType.Decimal)
                    };
                }
                else if (sqlParms == "SelectMedVsHisOperationSchedule")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientIdP",SqlDbType.VarChar),
							new SqlParameter("@VisitIdP",SqlDbType.Decimal),
							new SqlParameter("@ScheduleIdP",SqlDbType.Decimal),
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
        public int InsertMedVsHisOperationScheduleSQL(MedVsHisOperationSchedule model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedVsHisOperationSchedule");
                if (model.MedPatientId != null)
                    oneInert[0].Value = model.MedPatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneInert[1].Value = model.MedVisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.MedScheduleId.ToString() != null)
                    oneInert[2].Value = model.MedScheduleId;
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
                if (model.HisScheduleId != null)
                    oneInert[5].Value = model.HisScheduleId;
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
                if (model.State.ToString() != null)
                    oneInert[17].Value = model.State;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.OperationName != null)
                    oneInert[18].Value = model.OperationName;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.CreateDate >DateTime.MinValue)
                    oneInert[19].Value = model.CreateDate;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.AlterDate >DateTime.MinValue)
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

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_OPERATION_SCHEDULE_Insert_SQL, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedOperationSchedule 
        ///Update Table     MED_OPERATION_SCHEDULE
        /// </summary>
        public int UpdateMedVsHisOperationScheduleSQL(MedVsHisOperationSchedule model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedVsHisOperationSchedule");
                if (model.MedPatientId != null)
                    oneUpdate[0].Value = model.MedPatientId;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneUpdate[1].Value = model.MedVisitId;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.MedScheduleId.ToString() != null)
                    oneUpdate[2].Value = model.MedScheduleId;
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
                if (model.HisScheduleId != null)
                    oneUpdate[5].Value = model.HisScheduleId;
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
                if (model.State.ToString() != null)
                    oneUpdate[17].Value = model.State;
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
                if (model.MedPatientId != null)
                    oneUpdate[26].Value = model.MedPatientId;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneUpdate[27].Value = model.MedVisitId;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (model.MedScheduleId.ToString() != null)
                    oneUpdate[28].Value = model.MedScheduleId;
                else
                    oneUpdate[28].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_OPERATION_SCHEDULE_Update_SQL, oneUpdate);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedOperationSchedule 
        ///select Table MED_OPERATION_SCHEDULE by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
        /// </summary>
        public MedVsHisOperationSchedule SelectMedVsHisOperationScheduleSQL(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID)
        {
            MedVsHisOperationSchedule model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedVsHisOperationSchedule");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = SCHEDULE_ID;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPERATION_SCHEDULE_Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new  MedVsHisOperationSchedule();
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
                        model.MedScheduleId = decimal.Parse(oleReader["MED_SCHEDULE_ID"].ToString().Trim());
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
                        model.HisScheduleId = oleReader["HIS_SCHEDULE_ID"].ToString().Trim();
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
                        model.State = decimal.Parse(oleReader["STATE"].ToString().Trim());
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
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion

        #region [获取参数]
        /// <summary>
        ///获取参数MedVsHisOperationSchedule
        /// </summary>
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOperationSchedule")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":medpatientid",OracleType.VarChar),
							new OracleParameter(":medvisitid",OracleType.Number),
							new OracleParameter(":medscheduleid",OracleType.Number),
							new OracleParameter(":hispatientid",OracleType.VarChar),
							new OracleParameter(":hisvisitid",OracleType.VarChar),
							new OracleParameter(":hisscheduleid",OracleType.VarChar),
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
							new OracleParameter(":state",OracleType.Number),
							new OracleParameter(":operationname",OracleType.VarChar),
                            new OracleParameter(":createdate",OracleType.DateTime),
							new OracleParameter(":alterdate",OracleType.DateTime),
							new OracleParameter(":reserved1",OracleType.VarChar),
							new OracleParameter(":reserved2",OracleType.VarChar),
							new OracleParameter(":reserved3",OracleType.VarChar),
							new OracleParameter(":reserved4",OracleType.VarChar),
							new OracleParameter(":reserved5",OracleType.VarChar),
							new OracleParameter(":reserved6",OracleType.VarChar)
                    };
                }
                else if (sqlParms == "UpdateMedVsHisOperationSchedule")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":medpatientid",OracleType.VarChar),
							new OracleParameter(":medvisitid",OracleType.Number),
							new OracleParameter(":medscheduleid",OracleType.Number),
							new OracleParameter(":hispatientid",OracleType.VarChar),
							new OracleParameter(":hisvisitid",OracleType.VarChar),
							new OracleParameter(":hisscheduleid",OracleType.VarChar),
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
							new OracleParameter(":state",OracleType.Number),
							new OracleParameter(":operationname",OracleType.VarChar),
							new OracleParameter(":alterdate",OracleType.DateTime),
							new OracleParameter(":reserved1",OracleType.VarChar),
							new OracleParameter(":reserved2",OracleType.VarChar),
							new OracleParameter(":reserved3",OracleType.VarChar),
							new OracleParameter(":reserved4",OracleType.VarChar),
							new OracleParameter(":reserved5",OracleType.VarChar),
							new OracleParameter(":reserved6",OracleType.VarChar),
                            new OracleParameter(":PatientIdP",OracleType.VarChar),
                            new OracleParameter(":VisitIdP",OracleType.Number),
                            new OracleParameter(":ScheduleIdP",OracleType.Number)
                    };
                }
                else if (sqlParms == "SelectMedVsHisOperationSchedule")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientIdP",OracleType.VarChar),
							new OracleParameter(":VisitIdP",OracleType.Number),
							new OracleParameter(":ScheduleIdP",OracleType.Number),
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
        public int InsertMedVsHisOperationSchedule(MedVsHisOperationSchedule model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedVsHisOperationSchedule");
                if (model.MedPatientId != null)
                    oneInert[0].Value = model.MedPatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneInert[1].Value = model.MedVisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.MedScheduleId.ToString() != null)
                    oneInert[2].Value = model.MedScheduleId;
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
                if (model.HisScheduleId != null)
                    oneInert[5].Value = model.HisScheduleId;
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
                if (model.State.ToString() != null)
                    oneInert[17].Value = model.State;
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

                return OracleHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_OPERATION_SCHEDULE_Insert, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedOperationSchedule 
        ///Update Table     MED_OPERATION_SCHEDULE
        /// </summary>
        public int UpdateMedVsHisOperationSchedule(MedVsHisOperationSchedule model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedVsHisOperationSchedule");
                if (model.MedPatientId != null)
                    oneUpdate[0].Value = model.MedPatientId;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneUpdate[1].Value = model.MedVisitId;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.MedScheduleId.ToString() != null)
                    oneUpdate[2].Value = model.MedScheduleId;
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
                if (model.HisScheduleId != null)
                    oneUpdate[5].Value = model.HisScheduleId;
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
                if (model.State.ToString() != null)
                    oneUpdate[17].Value = model.State;
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
                if (model.MedPatientId != null)
                    oneUpdate[26].Value = model.MedPatientId;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneUpdate[27].Value = model.MedVisitId;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (model.MedScheduleId.ToString() != null)
                    oneUpdate[28].Value = model.MedScheduleId;
                else
                    oneUpdate[28].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_OPERATION_SCHEDULE_Update, oneUpdate);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedOperationSchedule 
        ///select Table MED_OPERATION_SCHEDULE by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
        /// </summary>
        public MedVsHisOperationSchedule SelectMedVsHisOperationSchedule(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID)
        {
            MedVsHisOperationSchedule model;
            OracleParameter[] parameterValues = GetParameter("SelectMedVsHisOperationSchedule");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = SCHEDULE_ID;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPERATION_SCHEDULE_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisOperationSchedule();
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
                        model.MedScheduleId = decimal.Parse(oleReader["MED_SCHEDULE_ID"].ToString().Trim());
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
                        model.HisScheduleId = oleReader["HIS_SCHEDULE_ID"].ToString().Trim();
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
                        model.State = decimal.Parse(oleReader["STATE"].ToString().Trim());
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
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion

    }
}
