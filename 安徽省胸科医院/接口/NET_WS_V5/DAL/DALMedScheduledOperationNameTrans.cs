

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
		
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedScheduledOperationName 
		///Insert Table MED_SCHEDULED_OPERATION_NAME
		/// </summary>
        public int InsertMedScheduledOperationNameSQL(MedScheduledOperationName model, System.Data.Common.DbTransaction oleCisTrans)
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

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, Insert_SQL, oneInert);
			
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedScheduledOperationName 
		///Update Table     MED_SCHEDULED_OPERATION_NAME
		/// </summary>
        public int UpdateMedScheduledOperationNameSQL(MedScheduledOperationName model, System.Data.Common.DbTransaction oleCisTrans)
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

	
		return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans,CommandType.Text, Update_SQL, oneUpdate);
			
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedScheduledOperationName 
		///Delete Table MED_SCHEDULED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
		/// </summary>
        public int DeleteMedScheduledOperationNameSQL(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID, decimal OPERATION_NO, System.Data.Common.DbTransaction oleCisTrans)
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

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_SCHEDULED_OPERATION_NAME_Delete_SQL, oneDelete);
			
		}
		#endregion
        #region [删除一条记录SQL-PATIENT]
        /// <summary>
        ///Delete    model  MedScheduledOperationName 
        ///Delete Table MED_SCHEDULED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
        /// </summary>
        public int DeleteMedScheduledOperationNameSQL(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID, System.Data.Common.DbTransaction oleCisTrans)
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

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_SCHEDULED_OPERATION_NAME_Delete_PATIENT_SQL, oneDelete);

        }
        #endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedScheduledOperationName 
		///select Table MED_SCHEDULED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
		/// </summary>
        public MedScheduledOperationName SelectMedScheduledOperationNameSQL(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID, decimal OPERATION_NO, System.Data.Common.DbConnection oleCisConn)
		{
			MedScheduledOperationName model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedScheduledOperationName");
			parameterValues[0].Value=PATIENT_ID;
			parameterValues[1].Value=VISIT_ID;
			parameterValues[2].Value=SCHEDULE_ID;
			parameterValues[3].Value=OPERATION_NO;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_SCHEDULED_OPERATION_NAME_Select_SQL, parameterValues))
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
        public List<MedScheduledOperationName> SelectMedScheduledOperationNameSQL(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID, System.Data.Common.DbConnection oleCisConn)
        {
            List<MedScheduledOperationName> MedScheduledOperationNameList = new List<MedScheduledOperationName>();
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedScheduledOperationNameScheduleId");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = SCHEDULE_ID;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_SCHEDULED_OPERATION_NAME_Select_Schedule_SQL, parameterValues))
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
		public List<MedScheduledOperationName> SelectMedScheduledOperationNameListSQL(System.Data.Common.DbConnection oleCisConn)
		{
			List<MedScheduledOperationName> modelList = new List<MedScheduledOperationName>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_SCHEDULED_OPERATION_NAME_Select_ALL_SQL, null))
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
		
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedScheduledOperationName 
		///Insert Table MED_SCHEDULED_OPERATION_NAME
		/// </summary>
        public int InsertMedScheduledOperationName(MedScheduledOperationName model, System.Data.Common.DbTransaction oleCisTrans)
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

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, Insert, oneInert);
			
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedScheduledOperationName 
		///Update Table     MED_SCHEDULED_OPERATION_NAME
		/// </summary>
        public int UpdateMedScheduledOperationName(MedScheduledOperationName model, System.Data.Common.DbTransaction oleCisTrans)
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


            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, Update, oneUpdate);
			
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedScheduledOperationName 
		///Delete Table MED_SCHEDULED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
		/// </summary>
        public int DeleteMedScheduledOperationName(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID, decimal OPERATION_NO, System.Data.Common.DbTransaction oleCisTrans)
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

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_SCHEDULED_OPERATION_NAME_Delete, oneDelete);
			
		}
		#endregion
        #region [删除一条记录-PATIENT]
        /// <summary>
        ///Delete    model  MedScheduledOperationName 
        ///Delete Table MED_SCHEDULED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
        /// </summary>
        public int DeleteMedScheduledOperationName(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID, System.Data.Common.DbTransaction oleCisTrans)
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

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_SCHEDULED_OPERATION_NAME_Delete_PATIENT, oneDelete);

        }
        #endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedScheduledOperationName 
		///select Table MED_SCHEDULED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal SCHEDULE_ID,decimal OPERATION_NO)
		/// </summary>
        public MedScheduledOperationName SelectMedScheduledOperationName(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID, decimal OPERATION_NO, System.Data.Common.DbConnection oleCisConn)
		{
			MedScheduledOperationName model;
			OracleParameter[] parameterValues = GetParameter("SelectMedScheduledOperationName");
			parameterValues[0].Value=PATIENT_ID;
			parameterValues[1].Value=VISIT_ID;
			parameterValues[2].Value=SCHEDULE_ID;
			parameterValues[3].Value=OPERATION_NO;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_SCHEDULED_OPERATION_NAME_Select, parameterValues))
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
        public List<MedScheduledOperationName> SelectMedScheduledOperationName(string PATIENT_ID, decimal VISIT_ID, decimal SCHEDULE_ID, System.Data.Common.DbConnection oleCisConn)
        {
            List<MedScheduledOperationName> MedScheduledOperationNameList = new List<MedScheduledOperationName>();
            OracleParameter[] parameterValues = GetParameter("SelectMedScheduledOperationNameScheduleId");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = SCHEDULE_ID;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_SCHEDULED_OPERATION_NAME_Select_Schedule, parameterValues))
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
		public List<MedScheduledOperationName> SelectMedScheduledOperationNameList( System.Data.Common.DbConnection oleCisConn)
		{
			List<MedScheduledOperationName> modelList = new List<MedScheduledOperationName>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_SCHEDULED_OPERATION_NAME_Select_ALL, null))
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
