

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 21:47:29
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
	/// DAL MedScheduledOperationName
	/// </summary>
	
	public partial class DALMedScheduledOperationName
	{

       private static string Update="Update MED_OPERATION_SCHEDULE_NAME set OPER_NAME=:OperName,OPER_CODE=:OperCode,OPER_SCALE=:OperScale,WOUND_TYPE=:WoundType,RESERVED1=:Reserved1,RESERVED2=:Reserved2,RESERVED3=:Reserved3,RESERVED4=:Reserved4 where PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND  SCHEDULE_ID=:ScheduleId AND  OPER_NO=:OperNo ";


       private static string Insert = "Insert into MED_OPERATION_SCHEDULE_NAME  (PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4) values(:PatientId,:VisitId,:ScheduleId,:OperNo,:OperName,:OperCode,:OperScale,:WoundType,:Reserved1,:Reserved2,:Reserved3,:Reserved4)";

 

       private static string Update_SQL = "Update MED_OPERATION_SCHEDULE_NAME set OPER_NAME=@OperName,OPER_CODE=@OperCode,OPER_SCALE=@OperScale,WOUND_TYPE=@WoundType,RESERVED1=@Reserved1,RESERVED2=@Reserved2,RESERVED3=@Reserved3,RESERVED4=@Reserved4 where PATIENT_ID=@PatientId and VISIT_ID=@VisitId and SCHEDULE_ID=@ScheduleId and OPER_NO=@OperNo";


       private static string Insert_SQL = "Insert into MED_OPERATION_SCHEDULE_NAME  (PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4) values(@PatientId,@VisitId,@ScheduleId,@OperNo,@OperName,@OperCode,@OperScale,@WoundType,@Reserved1,@Reserved2,@Reserved3,@Reserved4)";


		//private static readonly string MED_SCHEDULED_OPERATION_NAME_Insert_SQL = "INSERT INTO MED_SCHEDULED_OPERATION_NAME (PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPERATION_NO,OPERATION,OPERATION_SCALE,OPERATION_CODE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5) values (@PatientId,@VisitId,@ScheduleId,@OperationNo,@Operation,@OperationScale,@OperationCode,@Reserved1,@Reserved2,@Reserved3,@Reserved4,@Reserved5)";
       // private static readonly string MED_SCHEDULED_OPERATION_NAME_Update_SQL = "UPDATE MED_SCHEDULED_OPERATION_NAME SET PATIENT_ID=@PatientId,VISIT_ID=@VisitId,SCHEDULE_ID=@ScheduleId,OPERATION_NO=@OperationNo,OPERATION=@Operation,OPERATION_SCALE=@OperationScale,OPERATION_CODE=@OperationCode,RESERVED1=@Reserved1,RESERVED2=@Reserved2,RESERVED3=@Reserved3,RESERVED4=@Reserved4,RESERVED5=@Reserved5 WHERE PATIENT_ID=@PatientIdP AND VISIT_ID=@VisitIdP AND SCHEDULE_ID=@ScheduleIdP AND OPERATION_NO=@OperationNoP";
       private static readonly string MED_SCHEDULED_OPERATION_NAME_Delete_SQL = "Delete MED_OPERATION_SCHEDULE_NAME WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND SCHEDULE_ID=@ScheduleId AND OPERATION_NO=@OperationNo";
       private static readonly string MED_SCHEDULED_OPERATION_NAME_Delete_PATIENT_SQL = "Delete MED_OPERATION_SCHEDULE_NAME WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND SCHEDULE_ID=@ScheduleId";
       private static readonly string MED_SCHEDULED_OPERATION_NAME_Select_SQL = "SELECT PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 FROM MED_OPERATION_SCHEDULE_NAME where PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND SCHEDULE_ID=@ScheduleId AND OPERATION_NO=@OperationNo";
        private static readonly string MED_SCHEDULED_OPERATION_NAME_Select_Schedule_SQL = "SELECT PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 FROM MED_OPERATION_SCHEDULE_NAME where PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND SCHEDULE_ID=@ScheduleId";
        private static readonly string MED_SCHEDULED_OPERATION_NAME_Select_ALL_SQL = "SELECT PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 FROM MED_OPERATION_SCHEDULE_NAME";
		//private static readonly string MED_SCHEDULED_OPERATION_NAME_Insert = "INSERT INTO MED_SCHEDULED_OPERATION_NAME (PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPERATION_NO,OPERATION,OPERATION_SCALE,OPERATION_CODE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5) values (:PatientId,:VisitId,:ScheduleId,:OperationNo,:Operation,:OperationScale,:OperationCode,:Reserved1,:Reserved2,:Reserved3,:Reserved4,:Reserved5)";
       // private static readonly string MED_SCHEDULED_OPERATION_NAME_Update = "UPDATE MED_SCHEDULED_OPERATION_NAME SET PATIENT_ID=:PatientId,VISIT_ID=:VisitId,SCHEDULE_ID=:ScheduleId,OPERATION_NO=:OperationNo,OPERATION=:Operation,OPERATION_SCALE=:OperationScale,OPERATION_CODE=:OperationCode,RESERVED1=:Reserved1,RESERVED2=:Reserved2,RESERVED3=:Reserved3,RESERVED4=:Reserved4,RESERVED5=:Reserved5 WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND SCHEDULE_ID=:ScheduleId AND OPERATION_NO=:OperationNo";
        private static readonly string MED_SCHEDULED_OPERATION_NAME_Delete = "Delete MED_OPERATION_SCHEDULE_NAME WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND SCHEDULE_ID=:ScheduleId AND OPERATION_NO=:OperationNo";
        private static readonly string MED_SCHEDULED_OPERATION_NAME_Delete_PATIENT = "Delete MED_OPERATION_SCHEDULE_NAME WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND SCHEDULE_ID=:ScheduleId";
        private static readonly string MED_SCHEDULED_OPERATION_NAME_Select = "SELECT PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 FROM MED_OPERATION_SCHEDULE_NAME where PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND SCHEDULE_ID=:ScheduleId AND OPERATION_NO=:OperationNo";
        private static readonly string MED_SCHEDULED_OPERATION_NAME_Select_Schedule = "SELECT PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 FROM MED_OPERATION_SCHEDULE_NAME where PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND SCHEDULE_ID=:ScheduleId ";
        private static readonly string MED_SCHEDULED_OPERATION_NAME_Select_ALL = "SELECT PATIENT_ID,VISIT_ID,SCHEDULE_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 FROM MED_OPERATION_SCHEDULE_NAME";
		
        public DALMedScheduledOperationName ()
		{
		}
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedScheduledOperationName SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedScheduledOperationName")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
                        new SqlParameter("@VisitId",SqlDbType.Decimal),
                        new SqlParameter("@ScheduleId",SqlDbType.Decimal),
                        new SqlParameter("@OperNo",SqlDbType.Decimal),
                        new SqlParameter("@OperName",SqlDbType.VarChar),
                        new SqlParameter("@OperCode",SqlDbType.VarChar),
                        new SqlParameter("@OperScale",SqlDbType.VarChar),
                        new SqlParameter("@WoundType",SqlDbType.VarChar),
                        new SqlParameter("@Reserved1",SqlDbType.VarChar),
                        new SqlParameter("@Reserved2",SqlDbType.VarChar),
                        new SqlParameter("@Reserved3",SqlDbType.VarChar),
                        new SqlParameter("@Reserved4",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedScheduledOperationName")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@OperName",SqlDbType.VarChar),
                        new SqlParameter("@OperCode",SqlDbType.VarChar),
                        new SqlParameter("@OperScale",SqlDbType.VarChar),
                        new SqlParameter("@WoundType",SqlDbType.VarChar),
                        new SqlParameter("@Reserved1",SqlDbType.VarChar),
                        new SqlParameter("@Reserved2",SqlDbType.VarChar),
                        new SqlParameter("@Reserved3",SqlDbType.VarChar),
                        new SqlParameter("@Reserved4",SqlDbType.VarChar),
                        new SqlParameter("@PatientId",SqlDbType.VarChar),
                        new SqlParameter("@VisitId",SqlDbType.Decimal),
                        new SqlParameter("@ScheduleId",SqlDbType.Decimal),
                        new SqlParameter("@OperNo",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedScheduledOperationName")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@ScheduleId",SqlDbType.Decimal),
						new SqlParameter("@OperationNo",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedScheduledOperationNamePatient")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@ScheduleId",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "SelectMedScheduledOperationName")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@ScheduleId",SqlDbType.Decimal),
						new SqlParameter("@OperationNo",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedScheduledOperationNameScheduleId")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@ScheduleId",SqlDbType.Decimal),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedScheduledOperationName 
		///Insert Table MED_SCHEDULED_OPERATION_NAME
		/// </summary>
		public int InsertMedScheduledOperationNameSQL(MedScheduledOperationName model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedScheduledOperationName");
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
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedScheduledOperationName 
		///Update Table     MED_SCHEDULED_OPERATION_NAME
		/// </summary>
		public int UpdateMedScheduledOperationNameSQL(MedScheduledOperationName model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedScheduledOperationName");
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
                if (model.ScheduleId != null)
                    oneUpdate[10].Value = model.ScheduleId;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.OperNo != null)
                    oneUpdate[11].Value = model.OperNo;
                else
                    oneUpdate[11].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedScheduledOperationName 
		///Delete Table MED_SCHEDULED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
		/// </summary>
		public int DeleteMedScheduledOperationNameSQL(string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedScheduledOperationName");
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
                    if (OPERATION_NO.ToString() != null)
						oneDelete[3].Value =OPERATION_NO;
					else
						oneDelete[3].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_SCHEDULED_OPERATION_NAME_Delete_SQL, oneDelete);
			}
		}
		#endregion
        #region [删除一条记录SQL-PATIENT]
        /// <summary>
        ///Delete    model  MedScheduledOperationName 
        ///Delete Table MED_SCHEDULED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
        /// </summary>
        public int DeleteMedScheduledOperationNameSQL(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneDelete = GetParameterSQL("DeleteMedScheduledOperationNamePatient");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (VISIT_ID.ToString() != null)
                    oneDelete[1].Value = VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (SCHEDULE_ID.ToString() != null)
                    oneDelete[2].Value = SCHEDULE_ID;
                else
                    oneDelete[2].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_SCHEDULED_OPERATION_NAME_Delete_PATIENT_SQL, oneDelete);
            }
        }
        #endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedScheduledOperationName 
		///select Table MED_SCHEDULED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
		/// </summary>
		public MedScheduledOperationName  SelectMedScheduledOperationNameSQL(string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
		{
			MedScheduledOperationName model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedScheduledOperationName");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
				parameterValues[2].Value=SCHEDULE_ID;
				parameterValues[3].Value=OPERATION_NO;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_SCHEDULED_OPERATION_NAME_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedScheduledOperationName();
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
		#endregion	
        #region  [获取一条记录SQL-一次手术预约的]
        /// <summary>
        ///Select    model  MedScheduledOperationName 
        ///select Table MED_SCHEDULED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
        /// </summary>
        public List<MedScheduledOperationName> SelectMedScheduledOperationNameSQL(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID)
        {
            List<MedScheduledOperationName> MedScheduledOperationNameList = new List<MedScheduledOperationName>();
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedScheduledOperationNameScheduleId");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = SCHEDULE_ID;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_SCHEDULED_OPERATION_NAME_Select_Schedule_SQL, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedScheduledOperationName model = new MedScheduledOperationName();
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
                    MedScheduledOperationNameList.Add(model);
                }
            }
            return MedScheduledOperationNameList;
        }
        #endregion	
		#region  [获取所有记录SQL]
		/// <summary>
		///获取所有记录
		/// </summary>
		public List<MedScheduledOperationName> SelectMedScheduledOperationNameListSQL()
		{
			List<MedScheduledOperationName> modelList = new List<MedScheduledOperationName>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_SCHEDULED_OPERATION_NAME_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedScheduledOperationName model = new MedScheduledOperationName();
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
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [获取参数]
		/// <summary>
		///获取参数MedScheduledOperationName
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedScheduledOperationName")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":PatientId",OracleType.VarChar),
                        new OracleParameter(":VisitId",OracleType.Number),
                        new OracleParameter(":ScheduleId",OracleType.Number),
                        new OracleParameter(":OperNo",OracleType.Number),
                        new OracleParameter(":OperName",OracleType.VarChar),
                        new OracleParameter(":OperCode",OracleType.VarChar),
                        new OracleParameter(":OperScale",OracleType.VarChar),
                        new OracleParameter(":WoundType",OracleType.VarChar),
                        new OracleParameter(":Reserved1",OracleType.VarChar),
                        new OracleParameter(":Reserved2",OracleType.VarChar),
                        new OracleParameter(":Reserved3",OracleType.VarChar),
                        new OracleParameter(":Reserved4",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedScheduledOperationName")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":OperName",OracleType.VarChar),
                        new OracleParameter(":OperCode",OracleType.VarChar),
                        new OracleParameter(":OperScale",OracleType.VarChar),
                        new OracleParameter(":WoundType",OracleType.VarChar),
                        new OracleParameter(":Reserved1",OracleType.VarChar),
                        new OracleParameter(":Reserved2",OracleType.VarChar),
                        new OracleParameter(":Reserved3",OracleType.VarChar),
                        new OracleParameter(":Reserved4",OracleType.VarChar),
                        new OracleParameter(":PatientId",OracleType.VarChar),
                        new OracleParameter(":VisitId",OracleType.Number),
                        new OracleParameter(":ScheduleId",OracleType.Number),
                        new OracleParameter(":OperNo",OracleType.Number),
                    };
                }
				else if(sqlParms == "DeleteMedScheduledOperationName")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":ScheduleId",OracleType.Number),
							new OracleParameter(":OperationNo",OracleType.Number),
                    };
                }
                else if (sqlParms == "DeleteMedScheduledOperationNamePatient")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":ScheduleId",OracleType.Number),
                    };
                }
				else if(sqlParms == "SelectMedScheduledOperationName")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":ScheduleId",OracleType.Number),
							new OracleParameter(":OperationNo",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectMedScheduledOperationNameScheduleId")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":ScheduleId",OracleType.Number),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedScheduledOperationName 
		///Insert Table MED_SCHEDULED_OPERATION_NAME
		/// </summary>
		public int InsertMedScheduledOperationName(MedScheduledOperationName model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedScheduledOperationName");
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
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, Insert , oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedScheduledOperationName 
		///Update Table     MED_SCHEDULED_OPERATION_NAME
		/// </summary>
        public int UpdateMedScheduledOperationName(MedScheduledOperationName model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedScheduledOperationName");
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
                if (model.ScheduleId != null)
                    oneUpdate[10].Value = model.ScheduleId;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.OperNo != null)
                    oneUpdate[11].Value = model.OperNo;
                else
                    oneUpdate[11].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, Update, oneUpdate);
            }
        }
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedScheduledOperationName 
		///Delete Table MED_SCHEDULED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
		/// </summary>
		public int DeleteMedScheduledOperationName(string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedScheduledOperationName");
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
                    if (OPERATION_NO.ToString() != null)
						oneDelete[3].Value =OPERATION_NO;
					else
						oneDelete[3].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_SCHEDULED_OPERATION_NAME_Delete, oneDelete);
			}
		}
		#endregion
        #region [删除一条记录-PATIENT]
        /// <summary>
        ///Delete    model  MedScheduledOperationName 
        ///Delete Table MED_SCHEDULED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
        /// </summary>
        public int DeleteMedScheduledOperationName(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneDelete = GetParameter("DeleteMedScheduledOperationNamePatient");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (VISIT_ID.ToString() != null)
                    oneDelete[1].Value = VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (SCHEDULE_ID.ToString() != null)
                    oneDelete[2].Value = SCHEDULE_ID;
                else
                    oneDelete[2].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_SCHEDULED_OPERATION_NAME_Delete_PATIENT, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedScheduledOperationName 
        ///select Table MED_SCHEDULED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
        /// </summary>
        public MedScheduledOperationName SelectMedScheduledOperationName(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID, decimal OPERATION_NO)
        {
            MedScheduledOperationName model;
            OracleParameter[] parameterValues = GetParameter("SelectMedScheduledOperationName");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = SCHEDULE_ID;
            parameterValues[3].Value = OPERATION_NO;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_SCHEDULED_OPERATION_NAME_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedScheduledOperationName();
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
        #endregion	
        #region  [获取一条记录-一次手术预约的]
        /// <summary>
		///Select    model  MedScheduledOperationName 
		///select Table MED_SCHEDULED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
		/// </summary>
		public List<MedScheduledOperationName>  SelectMedScheduledOperationName(string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID)
		{
            List<MedScheduledOperationName> MedScheduledOperationNameList = new List<MedScheduledOperationName>();
            OracleParameter[] parameterValues = GetParameter("SelectMedScheduledOperationNameScheduleId");
			parameterValues[0].Value=PATIENT_ID;
			parameterValues[1].Value=VISIT_ID;
			parameterValues[2].Value=SCHEDULE_ID;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_SCHEDULED_OPERATION_NAME_Select_Schedule, parameterValues))
			{
				while (oleReader.Read())
				{
					MedScheduledOperationName model = new MedScheduledOperationName();
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
                    MedScheduledOperationNameList.Add(model);
				}
			}
            return MedScheduledOperationNameList;
		}
		#endregion	
		#region  [获取所有记录]
		/// <summary>
		///获取所有记录
		/// </summary>
		public List<MedScheduledOperationName> SelectMedScheduledOperationNameList()
		{
			List<MedScheduledOperationName> modelList = new List<MedScheduledOperationName>();
		    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_SCHEDULED_OPERATION_NAME_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedScheduledOperationName model = new MedScheduledOperationName();
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
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
