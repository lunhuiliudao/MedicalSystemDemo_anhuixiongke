

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010-08-31 17:52:51
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
	/// DAL MedEmrArchiveDetial
	/// </summary>
	public partial class DALMedEmrArchiveDetial
	{
		private static readonly string MED_EMR_ARCHIVE_DETIAL_Insert_SQL = "INSERT INTO MED_EMR_ARCHIVE_DETIAL (PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO) values (@PatientId,@VisitId,@MrClass,@MrSubClass,@ArchiveKey,@EmrFileIndex,@ArchiveTimes,@Topic,@EmrFileName,@EmrType,@ArchiveDateTime,@ArchiveType,@ArchiveStatus,@EmrOwner,@Operator,@ArchivePc,@ArchiveMode,@ArchiveAccess,@Memo)";
		private static readonly string MED_EMR_ARCHIVE_DETIAL_Update_SQL = "UPDATE MED_EMR_ARCHIVE_DETIAL SET PATIENT_ID=@PatientId,VISIT_ID=@VisitId,MR_CLASS=@MrClass,MR_SUB_CLASS=@MrSubClass,ARCHIVE_KEY=@ArchiveKey,EMR_FILE_INDEX=@EmrFileIndex,ARCHIVE_TIMES=@ArchiveTimes,TOPIC=@Topic,EMR_FILE_NAME=@EmrFileName,EMR_TYPE=@EmrType,ARCHIVE_DATE_TIME=@ArchiveDateTime,ARCHIVE_TYPE=@ArchiveType,ARCHIVE_STATUS=@ArchiveStatus,EMR_OWNER=@EmrOwner,OPERATOR=@Operator,ARCHIVE_PC=@ArchivePc,ARCHIVE_MODE=@ArchiveMode,ARCHIVE_ACCESS=@ArchiveAccess,MEMO=@Memo WHERE  PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND MR_CLASS=@MrClass AND MR_SUB_CLASS=@MrSubClass AND ARCHIVE_KEY=@ArchiveKey AND EMR_FILE_INDEX=@EmrFileIndex AND ARCHIVE_TIMES=@ArchiveTimes";
		private static readonly string MED_EMR_ARCHIVE_DETIAL_Delete_SQL = "DELETE MED_EMR_ARCHIVE_DETIAL WHERE  PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND MR_CLASS=@MrClass AND MR_SUB_CLASS=@MrSubClass AND ARCHIVE_KEY=@ArchiveKey AND EMR_FILE_INDEX=@EmrFileIndex AND ARCHIVE_TIMES=@ArchiveTimes";
		private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_SQL = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL where  PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND MR_CLASS=@MrClass AND MR_SUB_CLASS=@MrSubClass AND ARCHIVE_KEY=@ArchiveKey AND EMR_FILE_INDEX=@EmrFileIndex AND ARCHIVE_TIMES=@ArchiveTimes";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_NoIndex_SQL = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL where  PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND MR_CLASS=@MrClass AND MR_SUB_CLASS=@MrSubClass AND ARCHIVE_KEY=@ArchiveKey AND ARCHIVE_TIMES=@ArchiveTimes";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_MRCLASS_ArchiveKey_SQL = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL where  PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND MR_CLASS=@MrClass AND ARCHIVE_KEY=@ArchiveKey";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_MRCLASS_SQL = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL where  PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND MR_CLASS=@MrClass";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_ALL_SQL = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL";
		private static readonly string MED_EMR_ARCHIVE_DETIAL_Insert = "INSERT INTO MED_EMR_ARCHIVE_DETIAL (PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO) values (:PatientId,:VisitId,:MrClass,:MrSubClass,:ArchiveKey,:EmrFileIndex,:ArchiveTimes,:Topic,:EmrFileName,:EmrType,:ArchiveDateTime,:ArchiveType,:ArchiveStatus,:EmrOwner,:Operator,:ArchivePc,:ArchiveMode,:ArchiveAccess,:Memo)";
		private static readonly string MED_EMR_ARCHIVE_DETIAL_Update = "UPDATE MED_EMR_ARCHIVE_DETIAL SET PATIENT_ID=:PatientId,VISIT_ID=:VisitId,MR_CLASS=:MrClass,MR_SUB_CLASS=:MrSubClass,ARCHIVE_KEY=:ArchiveKey,EMR_FILE_INDEX=:EmrFileIndex,ARCHIVE_TIMES=:ArchiveTimes,TOPIC=:Topic,EMR_FILE_NAME=:EmrFileName,EMR_TYPE=:EmrType,ARCHIVE_DATE_TIME=:ArchiveDateTime,ARCHIVE_TYPE=:ArchiveType,ARCHIVE_STATUS=:ArchiveStatus,EMR_OWNER=:EmrOwner,OPERATOR=:Operator,ARCHIVE_PC=:ArchivePc,ARCHIVE_MODE=:ArchiveMode,ARCHIVE_ACCESS=:ArchiveAccess,MEMO=:Memo WHERE  PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND MR_CLASS=:MrClass AND MR_SUB_CLASS=:MrSubClass AND ARCHIVE_KEY=:ArchiveKey AND EMR_FILE_INDEX=:EmrFileIndex AND ARCHIVE_TIMES=:ArchiveTimes";
		private static readonly string MED_EMR_ARCHIVE_DETIAL_Delete = "DELETE MED_EMR_ARCHIVE_DETIAL WHERE  PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND MR_CLASS=:MrClass AND MR_SUB_CLASS=:MrSubClass AND ARCHIVE_KEY=:ArchiveKey AND EMR_FILE_INDEX=:EmrFileIndex AND ARCHIVE_TIMES=:ArchiveTimes";
		private static readonly string MED_EMR_ARCHIVE_DETIAL_Select = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL where  PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND MR_CLASS=:MrClass AND MR_SUB_CLASS=:MrSubClass AND ARCHIVE_KEY=:ArchiveKey AND EMR_FILE_INDEX=:EmrFileIndex AND ARCHIVE_TIMES=:ArchiveTimes";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_NoIndex = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL where  PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND MR_CLASS=:MrClass AND MR_SUB_CLASS=:MrSubClass AND ARCHIVE_KEY=:ArchiveKey AND ARCHIVE_TIMES=:ArchiveTimes";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_MRCLASS_ArchiveKey = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL where  PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND MR_CLASS=:MrClass AND ARCHIVE_KEY=:ArchiveKey";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_MRCLASS = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL where  PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND MR_CLASS=:MrClass";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_ALL = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL";
		
		public DALMedEmrArchiveDetial ()
		{
		}

		#region [获取参数SQL]
		/// <summary>
		///获取参数MedEmrArchiveDetial SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedEmrArchiveDetial")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@MrClass",SqlDbType.VarChar),
						new SqlParameter("@MrSubClass",SqlDbType.VarChar),
						new SqlParameter("@ArchiveKey",SqlDbType.VarChar),
						new SqlParameter("@EmrFileIndex",SqlDbType.Decimal),
						new SqlParameter("@ArchiveTimes",SqlDbType.Decimal),
						new SqlParameter("@Topic",SqlDbType.VarChar),
						new SqlParameter("@EmrFileName",SqlDbType.VarChar),
						new SqlParameter("@EmrType",SqlDbType.VarChar),
						new SqlParameter("@ArchiveDateTime",SqlDbType.DateTime),
						new SqlParameter("@ArchiveType",SqlDbType.VarChar),
						new SqlParameter("@ArchiveStatus",SqlDbType.VarChar),
						new SqlParameter("@EmrOwner",SqlDbType.VarChar),
						new SqlParameter("@Operator",SqlDbType.VarChar),
						new SqlParameter("@ArchivePc",SqlDbType.VarChar),
						new SqlParameter("@ArchiveMode",SqlDbType.VarChar),
						new SqlParameter("@ArchiveAccess",SqlDbType.VarChar),
						new SqlParameter("@Memo",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedEmrArchiveDetial")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@MrClass",SqlDbType.VarChar),
						new SqlParameter("@MrSubClass",SqlDbType.VarChar),
						new SqlParameter("@ArchiveKey",SqlDbType.VarChar),
						new SqlParameter("@EmrFileIndex",SqlDbType.Decimal),
						new SqlParameter("@ArchiveTimes",SqlDbType.Decimal),
						new SqlParameter("@Topic",SqlDbType.VarChar),
						new SqlParameter("@EmrFileName",SqlDbType.VarChar),
						new SqlParameter("@EmrType",SqlDbType.VarChar),
						new SqlParameter("@ArchiveDateTime",SqlDbType.DateTime),
						new SqlParameter("@ArchiveType",SqlDbType.VarChar),
						new SqlParameter("@ArchiveStatus",SqlDbType.VarChar),
						new SqlParameter("@EmrOwner",SqlDbType.VarChar),
						new SqlParameter("@Operator",SqlDbType.VarChar),
						new SqlParameter("@ArchivePc",SqlDbType.VarChar),
						new SqlParameter("@ArchiveMode",SqlDbType.VarChar),
						new SqlParameter("@ArchiveAccess",SqlDbType.VarChar),
						new SqlParameter("@Memo",SqlDbType.VarChar),
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@MrClass",SqlDbType.VarChar),
						new SqlParameter("@MrSubClass",SqlDbType.VarChar),
						new SqlParameter("@ArchiveKey",SqlDbType.VarChar),
						new SqlParameter("@EmrFileIndex",SqlDbType.Decimal),
						new SqlParameter("@ArchiveTimes",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedEmrArchiveDetial")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@MrClass",SqlDbType.VarChar),
						new SqlParameter("@MrSubClass",SqlDbType.VarChar),
						new SqlParameter("@ArchiveKey",SqlDbType.VarChar),
						new SqlParameter("@EmrFileIndex",SqlDbType.Decimal),
						new SqlParameter("@ArchiveTimes",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "SelectMedEmrArchiveDetial")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@MrClass",SqlDbType.VarChar),
						new SqlParameter("@MrSubClass",SqlDbType.VarChar),
						new SqlParameter("@ArchiveKey",SqlDbType.VarChar),
						new SqlParameter("@EmrFileIndex",SqlDbType.Decimal),
						new SqlParameter("@ArchiveTimes",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedEmrArchiveDetialList")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@MrClass",SqlDbType.VarChar),
						new SqlParameter("@MrSubClass",SqlDbType.VarChar),
						new SqlParameter("@ArchiveKey",SqlDbType.VarChar),
						new SqlParameter("@ArchiveTimes",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedEmrArchiveDetialMrClassArchiveKey")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@MrClass",SqlDbType.VarChar),
						new SqlParameter("@ArchiveKey",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrArchiveDetialMrClass")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@MrClass",SqlDbType.VarChar),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedEmrArchiveDetial 
		///Insert Table MED_EMR_ARCHIVE_DETIAL
		/// </summary>
		public int InsertMedEmrArchiveDetialSQL(MedEmrArchiveDetial model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedEmrArchiveDetial");
					if (model.PatientId != null)
						oneInert[0].Value = model.PatientId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneInert[1].Value = model.VisitId;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.MrClass != null)
						oneInert[2].Value = model.MrClass;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.MrSubClass != null)
						oneInert[3].Value = model.MrSubClass;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.ArchiveKey != null)
						oneInert[4].Value = model.ArchiveKey;
					else
						oneInert[4].Value = DBNull.Value;
                    if (model.EmrFileIndex.ToString() != null)
						oneInert[5].Value = model.EmrFileIndex;
					else
						oneInert[5].Value = DBNull.Value;
                    if (model.ArchiveTimes.ToString() != null)
						oneInert[6].Value = model.ArchiveTimes;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.Topic != null)
						oneInert[7].Value = model.Topic;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.EmrFileName != null)
						oneInert[8].Value = model.EmrFileName;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.EmrType != null)
						oneInert[9].Value = model.EmrType;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.ArchiveDateTime != null)
						oneInert[10].Value = model.ArchiveDateTime;
					else
						oneInert[10].Value = DBNull.Value;
					if (model.ArchiveType != null)
						oneInert[11].Value = model.ArchiveType;
					else
						oneInert[11].Value = DBNull.Value;
					if (model.ArchiveStatus != null)
						oneInert[12].Value = model.ArchiveStatus;
					else
						oneInert[12].Value = DBNull.Value;
					if (model.EmrOwner != null)
						oneInert[13].Value = model.EmrOwner;
					else
						oneInert[13].Value = DBNull.Value;
					if (model.Operator != null)
						oneInert[14].Value = model.Operator;
					else
						oneInert[14].Value = DBNull.Value;
					if (model.ArchivePc != null)
						oneInert[15].Value = model.ArchivePc;
					else
						oneInert[15].Value = DBNull.Value;
					if (model.ArchiveMode != null)
						oneInert[16].Value = model.ArchiveMode;
					else
						oneInert[16].Value = DBNull.Value;
					if (model.ArchiveAccess != null)
						oneInert[17].Value = model.ArchiveAccess;
					else
						oneInert[17].Value = DBNull.Value;
					if (model.Memo != null)
						oneInert[18].Value = model.Memo;
					else
						oneInert[18].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_EMR_ARCHIVE_DETIAL_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedEmrArchiveDetial 
		///Update Table     MED_EMR_ARCHIVE_DETIAL
		/// </summary>
		public int UpdateMedEmrArchiveDetialSQL(MedEmrArchiveDetial model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedEmrArchiveDetial");
					if (model.PatientId != null)
						oneUpdate[0].Value = model.PatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneUpdate[1].Value = model.VisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.MrClass != null)
						oneUpdate[2].Value = model.MrClass;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.MrSubClass != null)
						oneUpdate[3].Value = model.MrSubClass;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.ArchiveKey != null)
						oneUpdate[4].Value = model.ArchiveKey;
					else
						oneUpdate[4].Value = DBNull.Value;
                    if (model.EmrFileIndex.ToString() != null)
						oneUpdate[5].Value = model.EmrFileIndex;
					else
						oneUpdate[5].Value = DBNull.Value;
                    if (model.ArchiveTimes.ToString() != null)
						oneUpdate[6].Value = model.ArchiveTimes;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.Topic != null)
						oneUpdate[7].Value = model.Topic;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.EmrFileName != null)
						oneUpdate[8].Value = model.EmrFileName;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.EmrType != null)
						oneUpdate[9].Value = model.EmrType;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.ArchiveDateTime != null)
						oneUpdate[10].Value = model.ArchiveDateTime;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.ArchiveType != null)
						oneUpdate[11].Value = model.ArchiveType;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.ArchiveStatus != null)
						oneUpdate[12].Value = model.ArchiveStatus;
					else
						oneUpdate[12].Value = DBNull.Value;
					if (model.EmrOwner != null)
						oneUpdate[13].Value = model.EmrOwner;
					else
						oneUpdate[13].Value = DBNull.Value;
					if (model.Operator != null)
						oneUpdate[14].Value = model.Operator;
					else
						oneUpdate[14].Value = DBNull.Value;
					if (model.ArchivePc != null)
						oneUpdate[15].Value = model.ArchivePc;
					else
						oneUpdate[15].Value = DBNull.Value;
					if (model.ArchiveMode != null)
						oneUpdate[16].Value = model.ArchiveMode;
					else
						oneUpdate[16].Value = DBNull.Value;
					if (model.ArchiveAccess != null)
						oneUpdate[17].Value = model.ArchiveAccess;
					else
						oneUpdate[17].Value = DBNull.Value;
					if (model.Memo != null)
						oneUpdate[18].Value = model.Memo;
					else
						oneUpdate[18].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[19].Value =model.PatientId;
					else
						oneUpdate[19].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneUpdate[20].Value =model.VisitId;
					else
						oneUpdate[20].Value = DBNull.Value;
					if (model.MrClass != null)
						oneUpdate[21].Value =model.MrClass;
					else
						oneUpdate[21].Value = DBNull.Value;
					if (model.MrSubClass != null)
						oneUpdate[22].Value =model.MrSubClass;
					else
						oneUpdate[22].Value = DBNull.Value;
					if (model.ArchiveKey != null)
						oneUpdate[23].Value =model.ArchiveKey;
					else
						oneUpdate[23].Value = DBNull.Value;
                    if (model.EmrFileIndex.ToString() != null)
						oneUpdate[24].Value =model.EmrFileIndex;
					else
						oneUpdate[24].Value = DBNull.Value;
                    if (model.ArchiveTimes.ToString() != null)
						oneUpdate[25].Value =model.ArchiveTimes;
					else
						oneUpdate[25].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_EMR_ARCHIVE_DETIAL_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedEmrArchiveDetial 
		///Delete Table MED_EMR_ARCHIVE_DETIAL by (string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
		/// </summary>
		public int DeleteMedEmrArchiveDetialSQL(string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedEmrArchiveDetial");
					if (PATIENT_ID != null)
						oneDelete[0].Value =PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (VISIT_ID.ToString() != null)
						oneDelete[1].Value =VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
					if (MR_CLASS != null)
						oneDelete[2].Value =MR_CLASS;
					else
						oneDelete[2].Value = DBNull.Value;
					if (MR_SUB_CLASS != null)
						oneDelete[3].Value =MR_SUB_CLASS;
					else
						oneDelete[3].Value = DBNull.Value;
					if (ARCHIVE_KEY != null)
						oneDelete[4].Value =ARCHIVE_KEY;
					else
						oneDelete[4].Value = DBNull.Value;
                    if (EMR_FILE_INDEX.ToString() != null)
						oneDelete[5].Value =EMR_FILE_INDEX;
					else
						oneDelete[5].Value = DBNull.Value;
                    if (ARCHIVE_TIMES.ToString() != null)
						oneDelete[6].Value =ARCHIVE_TIMES;
					else
						oneDelete[6].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_EMR_ARCHIVE_DETIAL_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedEmrArchiveDetial 
		///select Table MED_EMR_ARCHIVE_DETIAL by (string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
		/// </summary>
		public MedEmrArchiveDetial  SelectMedEmrArchiveDetialSQL(string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
		{
			MedEmrArchiveDetial model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedEmrArchiveDetial");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
				parameterValues[2].Value=MR_CLASS;
				parameterValues[3].Value=MR_SUB_CLASS;
				parameterValues[4].Value=ARCHIVE_KEY;
				parameterValues[5].Value=EMR_FILE_INDEX;
				parameterValues[6].Value=ARCHIVE_TIMES;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedEmrArchiveDetial();
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
						model.MrClass = oleReader["MR_CLASS"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(3))
					{
						model.MrSubClass = oleReader["MR_SUB_CLASS"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(4))
					{
						model.ArchiveKey = oleReader["ARCHIVE_KEY"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(5))
					{
						model.EmrFileIndex = decimal.Parse(oleReader["EMR_FILE_INDEX"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(6))
					{
						model.ArchiveTimes = decimal.Parse(oleReader["ARCHIVE_TIMES"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(7))
					{
						model.Topic = oleReader["TOPIC"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(8))
					{
						model.EmrFileName = oleReader["EMR_FILE_NAME"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(9))
					{
						model.EmrType = oleReader["EMR_TYPE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(10))
					{
						model.ArchiveDateTime = DateTime.Parse(oleReader["ARCHIVE_DATE_TIME"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(11))
					{
						model.ArchiveType = oleReader["ARCHIVE_TYPE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(12))
					{
						model.ArchiveStatus = oleReader["ARCHIVE_STATUS"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(13))
					{
						model.EmrOwner = oleReader["EMR_OWNER"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(14))
					{
						model.Operator = oleReader["OPERATOR"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(15))
					{
						model.ArchivePc = oleReader["ARCHIVE_PC"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(16))
					{
						model.ArchiveMode = oleReader["ARCHIVE_MODE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(17))
					{
						model.ArchiveAccess = oleReader["ARCHIVE_ACCESS"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(18))
					{
						model.Memo = oleReader["MEMO"].ToString().Trim() ;
					}
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
        #region  [获取NO-EMR_FILE_INDEX记录SQL]
        /// <summary>
        ///Select    model  MedEmrArchiveDetial 
        ///select Table MED_EMR_ARCHIVE_DETIAL by (string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal ARCHIVE_TIMES)
        /// </summary>
        public List<MedEmrArchiveDetial> SelectMedEmrArchiveDetialSQL(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS, string MR_SUB_CLASS, string ARCHIVE_KEY, decimal ARCHIVE_TIMES)
        {
            List<MedEmrArchiveDetial> modelList = new List<MedEmrArchiveDetial>();
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedEmrArchiveDetialList");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;
            parameterValues[3].Value = MR_SUB_CLASS;
            parameterValues[4].Value = ARCHIVE_KEY;
            parameterValues[5].Value = ARCHIVE_TIMES;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_NoIndex_SQL, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedEmrArchiveDetial model = new MedEmrArchiveDetial();
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
                        model.MrClass = oleReader["MR_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MrSubClass = oleReader["MR_SUB_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ArchiveKey = oleReader["ARCHIVE_KEY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.EmrFileIndex = decimal.Parse(oleReader["EMR_FILE_INDEX"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ArchiveTimes = decimal.Parse(oleReader["ARCHIVE_TIMES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Topic = oleReader["TOPIC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.EmrFileName = oleReader["EMR_FILE_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.EmrType = oleReader["EMR_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.ArchiveDateTime = DateTime.Parse(oleReader["ARCHIVE_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.ArchiveType = oleReader["ARCHIVE_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.ArchiveStatus = oleReader["ARCHIVE_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.EmrOwner = oleReader["EMR_OWNER"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.ArchivePc = oleReader["ARCHIVE_PC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.ArchiveMode = oleReader["ARCHIVE_MODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.ArchiveAccess = oleReader["ARCHIVE_ACCESS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.Memo = oleReader["MEMO"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion	
		#region  [获取所有记录SQL]
		/// <summary>
		///获取所有记录
		/// </summary>
		public List<MedEmrArchiveDetial> SelectMedEmrArchiveDetialListSQL()
		{
			List<MedEmrArchiveDetial> modelList = new List<MedEmrArchiveDetial>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_ALL_SQL, null))
			{
				while (oleReader.Read())
				{
					MedEmrArchiveDetial model = new MedEmrArchiveDetial();
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
							model.MrClass = oleReader["MR_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.MrSubClass = oleReader["MR_SUB_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ArchiveKey = oleReader["ARCHIVE_KEY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.EmrFileIndex = decimal.Parse(oleReader["EMR_FILE_INDEX"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.ArchiveTimes = decimal.Parse(oleReader["ARCHIVE_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Topic = oleReader["TOPIC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.EmrFileName = oleReader["EMR_FILE_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.EmrType = oleReader["EMR_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.ArchiveDateTime = DateTime.Parse(oleReader["ARCHIVE_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.ArchiveType = oleReader["ARCHIVE_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.ArchiveStatus = oleReader["ARCHIVE_STATUS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.EmrOwner = oleReader["EMR_OWNER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.Operator = oleReader["OPERATOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.ArchivePc = oleReader["ARCHIVE_PC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.ArchiveMode = oleReader["ARCHIVE_MODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.ArchiveAccess = oleReader["ARCHIVE_ACCESS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.Memo = oleReader["MEMO"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
        #region  [获取记录SQL MR_CLASS ARCHIVE_KEY]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedEmrArchiveDetial> SelectMedEmrArchiveDetialListSQL(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS, string ARCHIVE_KEY)
        {
            List<MedEmrArchiveDetial> modelList = new List<MedEmrArchiveDetial>();
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedEmrArchiveDetialMrClassArchiveKey");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;
            parameterValues[3].Value = ARCHIVE_KEY;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_MRCLASS_ArchiveKey_SQL, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedEmrArchiveDetial model = new MedEmrArchiveDetial();
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
                        model.MrClass = oleReader["MR_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MrSubClass = oleReader["MR_SUB_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ArchiveKey = oleReader["ARCHIVE_KEY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.EmrFileIndex = decimal.Parse(oleReader["EMR_FILE_INDEX"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ArchiveTimes = decimal.Parse(oleReader["ARCHIVE_TIMES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Topic = oleReader["TOPIC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.EmrFileName = oleReader["EMR_FILE_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.EmrType = oleReader["EMR_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.ArchiveDateTime = DateTime.Parse(oleReader["ARCHIVE_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.ArchiveType = oleReader["ARCHIVE_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.ArchiveStatus = oleReader["ARCHIVE_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.EmrOwner = oleReader["EMR_OWNER"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.ArchivePc = oleReader["ARCHIVE_PC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.ArchiveMode = oleReader["ARCHIVE_MODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.ArchiveAccess = oleReader["ARCHIVE_ACCESS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.Memo = oleReader["MEMO"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion	
        #region  [获取记录SQL MR_CLASS]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedEmrArchiveDetial> SelectMedEmrArchiveDetialListSQL(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS)
        {
            List<MedEmrArchiveDetial> modelList = new List<MedEmrArchiveDetial>();
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedEmrArchiveDetialMrClass");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_MRCLASS_SQL, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedEmrArchiveDetial model = new MedEmrArchiveDetial();
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
                        model.MrClass = oleReader["MR_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MrSubClass = oleReader["MR_SUB_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ArchiveKey = oleReader["ARCHIVE_KEY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.EmrFileIndex = decimal.Parse(oleReader["EMR_FILE_INDEX"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ArchiveTimes = decimal.Parse(oleReader["ARCHIVE_TIMES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Topic = oleReader["TOPIC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.EmrFileName = oleReader["EMR_FILE_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.EmrType = oleReader["EMR_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.ArchiveDateTime = DateTime.Parse(oleReader["ARCHIVE_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.ArchiveType = oleReader["ARCHIVE_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.ArchiveStatus = oleReader["ARCHIVE_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.EmrOwner = oleReader["EMR_OWNER"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.ArchivePc = oleReader["ARCHIVE_PC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.ArchiveMode = oleReader["ARCHIVE_MODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.ArchiveAccess = oleReader["ARCHIVE_ACCESS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.Memo = oleReader["MEMO"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion	

		#region [获取参数]
		/// <summary>
		///获取参数MedEmrArchiveDetial
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedEmrArchiveDetial")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":MrClass",OracleType.VarChar),
							new OracleParameter(":MrSubClass",OracleType.VarChar),
							new OracleParameter(":ArchiveKey",OracleType.VarChar),
							new OracleParameter(":EmrFileIndex",OracleType.Number),
							new OracleParameter(":ArchiveTimes",OracleType.Number),
							new OracleParameter(":Topic",OracleType.VarChar),
							new OracleParameter(":EmrFileName",OracleType.VarChar),
							new OracleParameter(":EmrType",OracleType.VarChar),
							new OracleParameter(":ArchiveDateTime",OracleType.DateTime),
							new OracleParameter(":ArchiveType",OracleType.VarChar),
							new OracleParameter(":ArchiveStatus",OracleType.VarChar),
							new OracleParameter(":EmrOwner",OracleType.VarChar),
							new OracleParameter(":Operator",OracleType.VarChar),
							new OracleParameter(":ArchivePc",OracleType.VarChar),
							new OracleParameter(":ArchiveMode",OracleType.VarChar),
							new OracleParameter(":ArchiveAccess",OracleType.VarChar),
							new OracleParameter(":Memo",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedEmrArchiveDetial")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":MrClass",OracleType.VarChar),
							new OracleParameter(":MrSubClass",OracleType.VarChar),
							new OracleParameter(":ArchiveKey",OracleType.VarChar),
							new OracleParameter(":EmrFileIndex",OracleType.Number),
							new OracleParameter(":ArchiveTimes",OracleType.Number),
							new OracleParameter(":Topic",OracleType.VarChar),
							new OracleParameter(":EmrFileName",OracleType.VarChar),
							new OracleParameter(":EmrType",OracleType.VarChar),
							new OracleParameter(":ArchiveDateTime",OracleType.DateTime),
							new OracleParameter(":ArchiveType",OracleType.VarChar),
							new OracleParameter(":ArchiveStatus",OracleType.VarChar),
							new OracleParameter(":EmrOwner",OracleType.VarChar),
							new OracleParameter(":Operator",OracleType.VarChar),
							new OracleParameter(":ArchivePc",OracleType.VarChar),
							new OracleParameter(":ArchiveMode",OracleType.VarChar),
							new OracleParameter(":ArchiveAccess",OracleType.VarChar),
							new OracleParameter(":Memo",OracleType.VarChar),
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":MrClass",OracleType.VarChar),
							new OracleParameter(":MrSubClass",OracleType.VarChar),
							new OracleParameter(":ArchiveKey",OracleType.VarChar),
							new OracleParameter(":EmrFileIndex",OracleType.Number),
							new OracleParameter(":ArchiveTimes",OracleType.Number),
                    };
                }
				else if(sqlParms == "DeleteMedEmrArchiveDetial")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":MrClass",OracleType.VarChar),
							new OracleParameter(":MrSubClass",OracleType.VarChar),
							new OracleParameter(":ArchiveKey",OracleType.VarChar),
							new OracleParameter(":EmrFileIndex",OracleType.Number),
							new OracleParameter(":ArchiveTimes",OracleType.Number),
                    };
                }
				else if(sqlParms == "SelectMedEmrArchiveDetial")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":MrClass",OracleType.VarChar),
							new OracleParameter(":MrSubClass",OracleType.VarChar),
							new OracleParameter(":ArchiveKey",OracleType.VarChar),
							new OracleParameter(":EmrFileIndex",OracleType.Number),
							new OracleParameter(":ArchiveTimes",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectMedEmrArchiveDetialList")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":MrClass",OracleType.VarChar),
							new OracleParameter(":MrSubClass",OracleType.VarChar),
							new OracleParameter(":ArchiveKey",OracleType.VarChar),
							new OracleParameter(":ArchiveTimes",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectMedEmrArchiveDetialMrClassArchiveKey")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":PatientId",OracleType.VarChar),
						new OracleParameter(":VisitId",OracleType.Number),
						new OracleParameter(":MrClass",OracleType.VarChar),
						new OracleParameter(":ArchiveKey",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrArchiveDetialMrClass")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":PatientId",OracleType.VarChar),
						new OracleParameter(":VisitId",OracleType.Number),
						new OracleParameter(":MrClass",OracleType.VarChar),
						new OracleParameter(":ArchiveKey",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedEmrArchiveDetial 
		///Insert Table MED_EMR_ARCHIVE_DETIAL
		/// </summary>
		public int InsertMedEmrArchiveDetial(MedEmrArchiveDetial model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedEmrArchiveDetial");
					if (model.PatientId != null)
						oneInert[0].Value = model.PatientId;
					else
						oneInert[0].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneInert[1].Value = model.VisitId;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.MrClass != null)
						oneInert[2].Value = model.MrClass;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.MrSubClass != null)
						oneInert[3].Value = model.MrSubClass;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.ArchiveKey != null)
						oneInert[4].Value = model.ArchiveKey;
					else
						oneInert[4].Value = DBNull.Value;
                    if (model.EmrFileIndex.ToString() != null)
						oneInert[5].Value = model.EmrFileIndex;
					else
						oneInert[5].Value = DBNull.Value;
                    if (model.ArchiveTimes.ToString() != null)
						oneInert[6].Value = model.ArchiveTimes;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.Topic != null)
						oneInert[7].Value = model.Topic;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.EmrFileName != null)
						oneInert[8].Value = model.EmrFileName;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.EmrType != null)
						oneInert[9].Value = model.EmrType;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.ArchiveDateTime != null)
						oneInert[10].Value = model.ArchiveDateTime;
					else
						oneInert[10].Value = DBNull.Value;
					if (model.ArchiveType != null)
						oneInert[11].Value = model.ArchiveType;
					else
						oneInert[11].Value = DBNull.Value;
					if (model.ArchiveStatus != null)
						oneInert[12].Value = model.ArchiveStatus;
					else
						oneInert[12].Value = DBNull.Value;
					if (model.EmrOwner != null)
						oneInert[13].Value = model.EmrOwner;
					else
						oneInert[13].Value = DBNull.Value;
					if (model.Operator != null)
						oneInert[14].Value = model.Operator;
					else
						oneInert[14].Value = DBNull.Value;
					if (model.ArchivePc != null)
						oneInert[15].Value = model.ArchivePc;
					else
						oneInert[15].Value = DBNull.Value;
					if (model.ArchiveMode != null)
						oneInert[16].Value = model.ArchiveMode;
					else
						oneInert[16].Value = DBNull.Value;
					if (model.ArchiveAccess != null)
						oneInert[17].Value = model.ArchiveAccess;
					else
						oneInert[17].Value = DBNull.Value;
					if (model.Memo != null)
						oneInert[18].Value = model.Memo;
					else
						oneInert[18].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_EMR_ARCHIVE_DETIAL_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedEmrArchiveDetial 
		///Update Table     MED_EMR_ARCHIVE_DETIAL
		/// </summary>
		public int UpdateMedEmrArchiveDetial(MedEmrArchiveDetial model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedEmrArchiveDetial");
					if (model.PatientId != null)
						oneUpdate[0].Value = model.PatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneUpdate[1].Value = model.VisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.MrClass != null)
						oneUpdate[2].Value = model.MrClass;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.MrSubClass != null)
						oneUpdate[3].Value = model.MrSubClass;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.ArchiveKey != null)
						oneUpdate[4].Value = model.ArchiveKey;
					else
						oneUpdate[4].Value = DBNull.Value;
                    if (model.EmrFileIndex.ToString() != null)
						oneUpdate[5].Value = model.EmrFileIndex;
					else
						oneUpdate[5].Value = DBNull.Value;
                    if (model.ArchiveTimes.ToString() != null)
						oneUpdate[6].Value = model.ArchiveTimes;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.Topic != null)
						oneUpdate[7].Value = model.Topic;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.EmrFileName != null)
						oneUpdate[8].Value = model.EmrFileName;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.EmrType != null)
						oneUpdate[9].Value = model.EmrType;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.ArchiveDateTime != null)
						oneUpdate[10].Value = model.ArchiveDateTime;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.ArchiveType != null)
						oneUpdate[11].Value = model.ArchiveType;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.ArchiveStatus != null)
						oneUpdate[12].Value = model.ArchiveStatus;
					else
						oneUpdate[12].Value = DBNull.Value;
					if (model.EmrOwner != null)
						oneUpdate[13].Value = model.EmrOwner;
					else
						oneUpdate[13].Value = DBNull.Value;
					if (model.Operator != null)
						oneUpdate[14].Value = model.Operator;
					else
						oneUpdate[14].Value = DBNull.Value;
					if (model.ArchivePc != null)
						oneUpdate[15].Value = model.ArchivePc;
					else
						oneUpdate[15].Value = DBNull.Value;
					if (model.ArchiveMode != null)
						oneUpdate[16].Value = model.ArchiveMode;
					else
						oneUpdate[16].Value = DBNull.Value;
					if (model.ArchiveAccess != null)
						oneUpdate[17].Value = model.ArchiveAccess;
					else
						oneUpdate[17].Value = DBNull.Value;
					if (model.Memo != null)
						oneUpdate[18].Value = model.Memo;
					else
						oneUpdate[18].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[19].Value =model.PatientId;
					else
						oneUpdate[19].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneUpdate[20].Value =model.VisitId;
					else
						oneUpdate[20].Value = DBNull.Value;
					if (model.MrClass != null)
						oneUpdate[21].Value =model.MrClass;
					else
						oneUpdate[21].Value = DBNull.Value;
					if (model.MrSubClass != null)
						oneUpdate[22].Value =model.MrSubClass;
					else
						oneUpdate[22].Value = DBNull.Value;
					if (model.ArchiveKey != null)
						oneUpdate[23].Value =model.ArchiveKey;
					else
						oneUpdate[23].Value = DBNull.Value;
                    if (model.EmrFileIndex.ToString() != null)
						oneUpdate[24].Value =model.EmrFileIndex;
					else
						oneUpdate[24].Value = DBNull.Value;
                    if (model.ArchiveTimes.ToString() != null)
						oneUpdate[25].Value =model.ArchiveTimes;
					else
						oneUpdate[25].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_EMR_ARCHIVE_DETIAL_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedEmrArchiveDetial 
		///Delete Table MED_EMR_ARCHIVE_DETIAL by (string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
		/// </summary>
		public int DeleteMedEmrArchiveDetial(string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedEmrArchiveDetial");
					if (PATIENT_ID != null)
						oneDelete[0].Value =PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (VISIT_ID.ToString() != null)
						oneDelete[1].Value =VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
					if (MR_CLASS != null)
						oneDelete[2].Value =MR_CLASS;
					else
						oneDelete[2].Value = DBNull.Value;
					if (MR_SUB_CLASS != null)
						oneDelete[3].Value =MR_SUB_CLASS;
					else
						oneDelete[3].Value = DBNull.Value;
					if (ARCHIVE_KEY != null)
						oneDelete[4].Value =ARCHIVE_KEY;
					else
						oneDelete[4].Value = DBNull.Value;
                    if (EMR_FILE_INDEX.ToString() != null)
						oneDelete[5].Value =EMR_FILE_INDEX;
					else
						oneDelete[5].Value = DBNull.Value;
                    if (ARCHIVE_TIMES.ToString() != null)
						oneDelete[6].Value =ARCHIVE_TIMES;
					else
						oneDelete[6].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_EMR_ARCHIVE_DETIAL_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedEmrArchiveDetial 
		///select Table MED_EMR_ARCHIVE_DETIAL by (string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
		/// </summary>
		public MedEmrArchiveDetial  SelectMedEmrArchiveDetial(string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
		{
			MedEmrArchiveDetial model;
			OracleParameter[] parameterValues = GetParameter("SelectMedEmrArchiveDetial");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
				parameterValues[2].Value=MR_CLASS;
				parameterValues[3].Value=MR_SUB_CLASS;
				parameterValues[4].Value=ARCHIVE_KEY;
				parameterValues[5].Value=EMR_FILE_INDEX;
				parameterValues[6].Value=ARCHIVE_TIMES;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedEmrArchiveDetial();
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
							model.MrClass = oleReader["MR_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.MrSubClass = oleReader["MR_SUB_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ArchiveKey = oleReader["ARCHIVE_KEY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.EmrFileIndex = decimal.Parse(oleReader["EMR_FILE_INDEX"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.ArchiveTimes = decimal.Parse(oleReader["ARCHIVE_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Topic = oleReader["TOPIC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.EmrFileName = oleReader["EMR_FILE_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.EmrType = oleReader["EMR_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.ArchiveDateTime = DateTime.Parse(oleReader["ARCHIVE_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.ArchiveType = oleReader["ARCHIVE_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.ArchiveStatus = oleReader["ARCHIVE_STATUS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.EmrOwner = oleReader["EMR_OWNER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.Operator = oleReader["OPERATOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.ArchivePc = oleReader["ARCHIVE_PC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.ArchiveMode = oleReader["ARCHIVE_MODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.ArchiveAccess = oleReader["ARCHIVE_ACCESS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.Memo = oleReader["MEMO"].ToString().Trim() ;
						}
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
        #region  [获取NO-EMR_FILE_INDEX记录]
        /// <summary>
        ///Select    model  MedEmrArchiveDetial 
        ///select Table MED_EMR_ARCHIVE_DETIAL by (string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
        /// </summary>
        public List<MedEmrArchiveDetial> SelectMedEmrArchiveDetial(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS, string MR_SUB_CLASS, string ARCHIVE_KEY, decimal ARCHIVE_TIMES)
        {
            List<MedEmrArchiveDetial> modelList = new List<MedEmrArchiveDetial>();

            OracleParameter[] parameterValues = GetParameter("SelectMedEmrArchiveDetialList");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;
            parameterValues[3].Value = MR_SUB_CLASS;
            parameterValues[4].Value = ARCHIVE_KEY;
            parameterValues[5].Value = ARCHIVE_TIMES;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_NoIndex, parameterValues))
            {
                if (oleReader.Read())
                {
                    MedEmrArchiveDetial model = new MedEmrArchiveDetial();
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
                        model.MrClass = oleReader["MR_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MrSubClass = oleReader["MR_SUB_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ArchiveKey = oleReader["ARCHIVE_KEY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.EmrFileIndex = decimal.Parse(oleReader["EMR_FILE_INDEX"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ArchiveTimes = decimal.Parse(oleReader["ARCHIVE_TIMES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Topic = oleReader["TOPIC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.EmrFileName = oleReader["EMR_FILE_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.EmrType = oleReader["EMR_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.ArchiveDateTime = DateTime.Parse(oleReader["ARCHIVE_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.ArchiveType = oleReader["ARCHIVE_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.ArchiveStatus = oleReader["ARCHIVE_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.EmrOwner = oleReader["EMR_OWNER"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.ArchivePc = oleReader["ARCHIVE_PC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.ArchiveMode = oleReader["ARCHIVE_MODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.ArchiveAccess = oleReader["ARCHIVE_ACCESS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.Memo = oleReader["MEMO"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion	
		#region  [获取所有记录]
		/// <summary>
		///获取所有记录
		/// </summary>
		public List<MedEmrArchiveDetial> SelectMedEmrArchiveDetialList()
		{
			List<MedEmrArchiveDetial> modelList = new List<MedEmrArchiveDetial>();
		    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_ALL, null))
			{
				while (oleReader.Read())
				{
					MedEmrArchiveDetial model = new MedEmrArchiveDetial();
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
							model.MrClass = oleReader["MR_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.MrSubClass = oleReader["MR_SUB_CLASS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ArchiveKey = oleReader["ARCHIVE_KEY"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.EmrFileIndex = decimal.Parse(oleReader["EMR_FILE_INDEX"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.ArchiveTimes = decimal.Parse(oleReader["ARCHIVE_TIMES"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Topic = oleReader["TOPIC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.EmrFileName = oleReader["EMR_FILE_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.EmrType = oleReader["EMR_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.ArchiveDateTime = DateTime.Parse(oleReader["ARCHIVE_DATE_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.ArchiveType = oleReader["ARCHIVE_TYPE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.ArchiveStatus = oleReader["ARCHIVE_STATUS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.EmrOwner = oleReader["EMR_OWNER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.Operator = oleReader["OPERATOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.ArchivePc = oleReader["ARCHIVE_PC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.ArchiveMode = oleReader["ARCHIVE_MODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.ArchiveAccess = oleReader["ARCHIVE_ACCESS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.Memo = oleReader["MEMO"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
        #region  [获取记录 MR_CLASS ARCHIVE_KEY]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedEmrArchiveDetial> SelectMedEmrArchiveDetialList(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS, string ARCHIVE_KEY)
        {
            List<MedEmrArchiveDetial> modelList = new List<MedEmrArchiveDetial>();
            OracleParameter[] parameterValues = GetParameter("SelectMedEmrArchiveDetialMrClassArchiveKey");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;
            parameterValues[4].Value = ARCHIVE_KEY;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_MRCLASS_ArchiveKey, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedEmrArchiveDetial model = new MedEmrArchiveDetial();
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
                        model.MrClass = oleReader["MR_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MrSubClass = oleReader["MR_SUB_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ArchiveKey = oleReader["ARCHIVE_KEY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.EmrFileIndex = decimal.Parse(oleReader["EMR_FILE_INDEX"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ArchiveTimes = decimal.Parse(oleReader["ARCHIVE_TIMES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Topic = oleReader["TOPIC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.EmrFileName = oleReader["EMR_FILE_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.EmrType = oleReader["EMR_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.ArchiveDateTime = DateTime.Parse(oleReader["ARCHIVE_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.ArchiveType = oleReader["ARCHIVE_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.ArchiveStatus = oleReader["ARCHIVE_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.EmrOwner = oleReader["EMR_OWNER"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.ArchivePc = oleReader["ARCHIVE_PC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.ArchiveMode = oleReader["ARCHIVE_MODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.ArchiveAccess = oleReader["ARCHIVE_ACCESS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.Memo = oleReader["MEMO"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion	
        #region  [获取记录 MR_CLASS]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedEmrArchiveDetial> SelectMedEmrArchiveDetialList(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS)
        {
            List<MedEmrArchiveDetial> modelList = new List<MedEmrArchiveDetial>();
            OracleParameter[] parameterValues = GetParameter("SelectMedEmrArchiveDetialMrClass");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_MRCLASS, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedEmrArchiveDetial model = new MedEmrArchiveDetial();
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
                        model.MrClass = oleReader["MR_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MrSubClass = oleReader["MR_SUB_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ArchiveKey = oleReader["ARCHIVE_KEY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.EmrFileIndex = decimal.Parse(oleReader["EMR_FILE_INDEX"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ArchiveTimes = decimal.Parse(oleReader["ARCHIVE_TIMES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Topic = oleReader["TOPIC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.EmrFileName = oleReader["EMR_FILE_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.EmrType = oleReader["EMR_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.ArchiveDateTime = DateTime.Parse(oleReader["ARCHIVE_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.ArchiveType = oleReader["ARCHIVE_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.ArchiveStatus = oleReader["ARCHIVE_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.EmrOwner = oleReader["EMR_OWNER"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.ArchivePc = oleReader["ARCHIVE_PC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.ArchiveMode = oleReader["ARCHIVE_MODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.ArchiveAccess = oleReader["ARCHIVE_ACCESS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.Memo = oleReader["MEMO"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion	
	}
}
