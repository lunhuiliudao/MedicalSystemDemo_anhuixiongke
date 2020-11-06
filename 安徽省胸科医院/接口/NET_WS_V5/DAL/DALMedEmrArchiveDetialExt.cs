

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010-08-31 17:52:57
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
	/// DAL MedEmrArchiveDetialExt
	/// </summary>
	
	public class DALMedEmrArchiveDetialExt
	{
		private static readonly string MED_EMR_ARCHIVE_DETIAL_EXT_Insert_SQL = "INSERT INTO MED_EMR_ARCHIVE_DETIAL_EXT (PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO,EMR_XML_FILE,EMR_XML_NAME,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08,RESERVED09) values (@PatientId,@VisitId,@MrClass,@MrSubClass,@ArchiveKey,@EmrFileIndex,@ArchiveTimes,@Topic,@EmrFileName,@EmrType,@ArchiveDateTime,@ArchiveType,@ArchiveStatus,@EmrOwner,@Operator,@ArchivePc,@ArchiveMode,@ArchiveAccess,@Memo,@EmrXmlFile,@EmrXmlName,@Reserved01,@Reserved02,@Reserved03,@Reserved04,@Reserved05,@Reserved06,@Reserved07,@Reserved08,@Reserved09)";
		private static readonly string MED_EMR_ARCHIVE_DETIAL_EXT_Update_SQL = "UPDATE MED_EMR_ARCHIVE_DETIAL_EXT SET PATIENT_ID=@PatientId,VISIT_ID=@VisitId,MR_CLASS=@MrClass,MR_SUB_CLASS=@MrSubClass,ARCHIVE_KEY=@ArchiveKey,EMR_FILE_INDEX=@EmrFileIndex,ARCHIVE_TIMES=@ArchiveTimes,TOPIC=@Topic,EMR_FILE_NAME=@EmrFileName,EMR_TYPE=@EmrType,ARCHIVE_DATE_TIME=@ArchiveDateTime,ARCHIVE_TYPE=@ArchiveType,ARCHIVE_STATUS=@ArchiveStatus,EMR_OWNER=@EmrOwner,OPERATOR=@Operator,ARCHIVE_PC=@ArchivePc,ARCHIVE_MODE=@ArchiveMode,ARCHIVE_ACCESS=@ArchiveAccess,MEMO=@Memo,EMR_XML_FILE=@EmrXmlFile,EMR_XML_NAME=@EmrXmlName,RESERVED01=@Reserved01,RESERVED02=@Reserved02,RESERVED03=@Reserved03,RESERVED04=@Reserved04,RESERVED05=@Reserved05,RESERVED06=@Reserved06,RESERVED07=@Reserved07,RESERVED08=@Reserved08,RESERVED09=@Reserved09 WHERE  PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND MR_CLASS=@MrClass AND MR_SUB_CLASS=@MrSubClass AND ARCHIVE_KEY=@ArchiveKey AND EMR_FILE_INDEX=@EmrFileIndex AND ARCHIVE_TIMES=@ArchiveTimes";
		private static readonly string MED_EMR_ARCHIVE_DETIAL_EXT_Delete_SQL = "DELETE MED_EMR_ARCHIVE_DETIAL_EXT WHERE  PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND MR_CLASS=@MrClass AND MR_SUB_CLASS=@MrSubClass AND ARCHIVE_KEY=@ArchiveKey AND EMR_FILE_INDEX=@EmrFileIndex AND ARCHIVE_TIMES=@ArchiveTimes";
		private static readonly string MED_EMR_ARCHIVE_DETIAL_EXT_Select_SQL = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO,EMR_XML_FILE,EMR_XML_NAME,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08,RESERVED09 FROM MED_EMR_ARCHIVE_DETIAL_EXT where  PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND MR_CLASS=@MrClass AND MR_SUB_CLASS=@MrSubClass AND ARCHIVE_KEY=@ArchiveKey AND EMR_FILE_INDEX=@EmrFileIndex AND ARCHIVE_TIMES=@ArchiveTimes";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_EXT_Select_MRCLASS_SQL = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO,EMR_XML_FILE,EMR_XML_NAME,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08,RESERVED09 FROM MED_EMR_ARCHIVE_DETIAL_EXT where  PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND MR_CLASS=@MrClass  ORDER BY PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES DESC";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_EXT_Select_MRCLASS_ARCHIVE_KEY_SQL = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO,EMR_XML_FILE,EMR_XML_NAME,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08,RESERVED09 FROM MED_EMR_ARCHIVE_DETIAL_EXT where  PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND MR_CLASS=@MrClass AND ARCHIVE_KEY >= @ArchiveKey1 AND ARCHIVE_KEY <= @ArchiveKey2  ORDER BY PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES DESC";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_EXT_Select_ALL_SQL = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO,EMR_XML_FILE,EMR_XML_NAME,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08,RESERVED09 FROM MED_EMR_ARCHIVE_DETIAL_EXT";
		private static readonly string MED_EMR_ARCHIVE_DETIAL_EXT_Insert = "INSERT INTO MED_EMR_ARCHIVE_DETIAL_EXT (PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO,EMR_XML_FILE,EMR_XML_NAME,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08,RESERVED09) values (:PatientId,:VisitId,:MrClass,:MrSubClass,:ArchiveKey,:EmrFileIndex,:ArchiveTimes,:Topic,:EmrFileName,:EmrType,:ArchiveDateTime,:ArchiveType,:ArchiveStatus,:EmrOwner,:Operator,:ArchivePc,:ArchiveMode,:ArchiveAccess,:Memo,:EmrXmlFile,:EmrXmlName,:Reserved01,:Reserved02,:Reserved03,:Reserved04,:Reserved05,:Reserved06,:Reserved07,:Reserved08,:Reserved09)";
		private static readonly string MED_EMR_ARCHIVE_DETIAL_EXT_Update = "UPDATE MED_EMR_ARCHIVE_DETIAL_EXT SET PATIENT_ID=:PatientId,VISIT_ID=:VisitId,MR_CLASS=:MrClass,MR_SUB_CLASS=:MrSubClass,ARCHIVE_KEY=:ArchiveKey,EMR_FILE_INDEX=:EmrFileIndex,ARCHIVE_TIMES=:ArchiveTimes,TOPIC=:Topic,EMR_FILE_NAME=:EmrFileName,EMR_TYPE=:EmrType,ARCHIVE_DATE_TIME=:ArchiveDateTime,ARCHIVE_TYPE=:ArchiveType,ARCHIVE_STATUS=:ArchiveStatus,EMR_OWNER=:EmrOwner,OPERATOR=:Operator,ARCHIVE_PC=:ArchivePc,ARCHIVE_MODE=:ArchiveMode,ARCHIVE_ACCESS=:ArchiveAccess,MEMO=:Memo,EMR_XML_FILE=:EmrXmlFile,EMR_XML_NAME=:EmrXmlName,RESERVED01=:Reserved01,RESERVED02=:Reserved02,RESERVED03=:Reserved03,RESERVED04=:Reserved04,RESERVED05=:Reserved05,RESERVED06=:Reserved06,RESERVED07=:Reserved07,RESERVED08=:Reserved08,RESERVED09=:Reserved09 WHERE  PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND MR_CLASS=:MrClass AND MR_SUB_CLASS=:MrSubClass AND ARCHIVE_KEY=:ArchiveKey AND EMR_FILE_INDEX=:EmrFileIndex AND ARCHIVE_TIMES=:ArchiveTimes";
		private static readonly string MED_EMR_ARCHIVE_DETIAL_EXT_Delete = "DELETE MED_EMR_ARCHIVE_DETIAL_EXT WHERE  PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND MR_CLASS=:MrClass AND MR_SUB_CLASS=:MrSubClass AND ARCHIVE_KEY=:ArchiveKey AND EMR_FILE_INDEX=:EmrFileIndex AND ARCHIVE_TIMES=:ArchiveTimes";
		private static readonly string MED_EMR_ARCHIVE_DETIAL_EXT_Select = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO,EMR_XML_FILE,EMR_XML_NAME,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08,RESERVED09 FROM MED_EMR_ARCHIVE_DETIAL_EXT where  PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND MR_CLASS=:MrClass AND MR_SUB_CLASS=:MrSubClass AND ARCHIVE_KEY=:ArchiveKey AND EMR_FILE_INDEX=:EmrFileIndex AND ARCHIVE_TIMES=:ArchiveTimes";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_EXT_Select_MRCLASS = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO,EMR_XML_FILE,EMR_XML_NAME,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08,RESERVED09 FROM MED_EMR_ARCHIVE_DETIAL_EXT where  PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND MR_CLASS=:MrClass  ORDER BY PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES DESC";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_EXT_Select_MRCLASS_ARCHIVE_KEY = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO,EMR_XML_FILE,EMR_XML_NAME,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08,RESERVED09 FROM MED_EMR_ARCHIVE_DETIAL_EXT where  PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND MR_CLASS=:MrClass AND ARCHIVE_KEY >= :ArchiveKey1 AND ARCHIVE_KEY <= :ArchiveKey2  ORDER BY PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES DESC";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_EXT_Select_ALL = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO,EMR_XML_FILE,EMR_XML_NAME,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08,RESERVED09 FROM MED_EMR_ARCHIVE_DETIAL_EXT";
		
		public DALMedEmrArchiveDetialExt ()
		{
		}
		
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedEmrArchiveDetialExt SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedEmrArchiveDetialExt")
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
							new SqlParameter("@EmrXmlFile",SqlDbType.Binary),
							new SqlParameter("@EmrXmlName",SqlDbType.VarChar),
							new SqlParameter("@Reserved01",SqlDbType.VarChar),
							new SqlParameter("@Reserved02",SqlDbType.VarChar),
							new SqlParameter("@Reserved03",SqlDbType.VarChar),
							new SqlParameter("@Reserved04",SqlDbType.VarChar),
							new SqlParameter("@Reserved05",SqlDbType.VarChar),
							new SqlParameter("@Reserved06",SqlDbType.Decimal),
							new SqlParameter("@Reserved07",SqlDbType.Decimal),
							new SqlParameter("@Reserved08",SqlDbType.Binary),
							new SqlParameter("@Reserved09",SqlDbType.Binary),
                    };
                }
				else if (sqlParms == "UpdateMedEmrArchiveDetialExt")
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
							new SqlParameter("@EmrXmlFile",SqlDbType.Binary),
							new SqlParameter("@EmrXmlName",SqlDbType.VarChar),
							new SqlParameter("@Reserved01",SqlDbType.VarChar),
							new SqlParameter("@Reserved02",SqlDbType.VarChar),
							new SqlParameter("@Reserved03",SqlDbType.VarChar),
							new SqlParameter("@Reserved04",SqlDbType.VarChar),
							new SqlParameter("@Reserved05",SqlDbType.VarChar),
							new SqlParameter("@Reserved06",SqlDbType.Decimal),
							new SqlParameter("@Reserved07",SqlDbType.Decimal),
							new SqlParameter("@Reserved08",SqlDbType.Binary),
							new SqlParameter("@Reserved09",SqlDbType.Binary),
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@MrClass",SqlDbType.VarChar),
							new SqlParameter("@MrSubClass",SqlDbType.VarChar),
							new SqlParameter("@ArchiveKey",SqlDbType.VarChar),
							new SqlParameter("@EmrFileIndex",SqlDbType.Decimal),
							new SqlParameter("@ArchiveTimes",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedEmrArchiveDetialExt")
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
				else if(sqlParms == "SelectMedEmrArchiveDetialExt")
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
                else if (sqlParms == "SelectMedEmrArchiveDetialExtMrClass")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@MrClass",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrArchiveDetialExtMrClassArchiveKey")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@MrClass",SqlDbType.VarChar),
                            new SqlParameter("@ArchiveKey1",SqlDbType.VarChar),
                            new SqlParameter("@ArchiveKey2",SqlDbType.VarChar),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedEmrArchiveDetialExt 
		///Insert Table MED_EMR_ARCHIVE_DETIAL_EXT
		/// </summary>
		public int InsertMedEmrArchiveDetialExtSQL(MedEmrArchiveDetialExt model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedEmrArchiveDetialExt");
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
				if (model.EmrXmlFile != null)
					oneInert[19].Value = model.EmrXmlFile;
				else
					oneInert[19].Value = DBNull.Value;
				if (model.EmrXmlName != null)
					oneInert[20].Value = model.EmrXmlName;
				else
					oneInert[20].Value = DBNull.Value;
				if (model.Reserved01 != null)
					oneInert[21].Value = model.Reserved01;
				else
					oneInert[21].Value = DBNull.Value;
				if (model.Reserved02 != null)
					oneInert[22].Value = model.Reserved02;
				else
					oneInert[22].Value = DBNull.Value;
				if (model.Reserved03 != null)
					oneInert[23].Value = model.Reserved03;
				else
					oneInert[23].Value = DBNull.Value;
				if (model.Reserved04 != null)
					oneInert[24].Value = model.Reserved04;
				else
					oneInert[24].Value = DBNull.Value;
				if (model.Reserved05 != null)
					oneInert[25].Value = model.Reserved05;
				else
					oneInert[25].Value = DBNull.Value;
                if (model.Reserved06.ToString() != null)
					oneInert[26].Value = model.Reserved06;
				else
					oneInert[26].Value = DBNull.Value;
                if (model.Reserved07.ToString() != null)
					oneInert[27].Value = model.Reserved07;
				else
					oneInert[27].Value = DBNull.Value;
				if (model.Reserved08 != null)
					oneInert[28].Value = model.Reserved08;
				else
					oneInert[28].Value = DBNull.Value;
				if (model.Reserved09 != null)
					oneInert[29].Value = model.Reserved09;
				else
					oneInert[29].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_EMR_ARCHIVE_DETIAL_EXT_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedEmrArchiveDetialExt 
		///Update Table     MED_EMR_ARCHIVE_DETIAL_EXT
		/// </summary>
		public int UpdateMedEmrArchiveDetialExtSQL(MedEmrArchiveDetialExt model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedEmrArchiveDetialExt");
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
				if (model.EmrXmlFile != null)
					oneUpdate[19].Value = model.EmrXmlFile;
				else
					oneUpdate[19].Value = DBNull.Value;
				if (model.EmrXmlName != null)
					oneUpdate[20].Value = model.EmrXmlName;
				else
					oneUpdate[20].Value = DBNull.Value;
				if (model.Reserved01 != null)
					oneUpdate[21].Value = model.Reserved01;
				else
					oneUpdate[21].Value = DBNull.Value;
				if (model.Reserved02 != null)
					oneUpdate[22].Value = model.Reserved02;
				else
					oneUpdate[22].Value = DBNull.Value;
				if (model.Reserved03 != null)
					oneUpdate[23].Value = model.Reserved03;
				else
					oneUpdate[23].Value = DBNull.Value;
				if (model.Reserved04 != null)
					oneUpdate[24].Value = model.Reserved04;
				else
					oneUpdate[24].Value = DBNull.Value;
				if (model.Reserved05 != null)
					oneUpdate[25].Value = model.Reserved05;
				else
					oneUpdate[25].Value = DBNull.Value;
                if (model.Reserved06.ToString() != null)
					oneUpdate[26].Value = model.Reserved06;
				else
					oneUpdate[26].Value = DBNull.Value;
                if (model.Reserved07.ToString() != null)
					oneUpdate[27].Value = model.Reserved07;
				else
					oneUpdate[27].Value = DBNull.Value;
				if (model.Reserved08 != null)
					oneUpdate[28].Value = model.Reserved08;
				else
					oneUpdate[28].Value = DBNull.Value;
				if (model.Reserved09 != null)
					oneUpdate[29].Value = model.Reserved09;
				else
					oneUpdate[29].Value = DBNull.Value;
				if (model.PatientId != null)
					oneUpdate[30].Value =model.PatientId;
				else
					oneUpdate[30].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
					oneUpdate[31].Value =model.VisitId;
				else
					oneUpdate[31].Value = DBNull.Value;
				if (model.MrClass != null)
					oneUpdate[32].Value =model.MrClass;
				else
					oneUpdate[32].Value = DBNull.Value;
				if (model.MrSubClass != null)
					oneUpdate[33].Value =model.MrSubClass;
				else
					oneUpdate[33].Value = DBNull.Value;
				if (model.ArchiveKey != null)
					oneUpdate[34].Value =model.ArchiveKey;
				else
					oneUpdate[34].Value = DBNull.Value;
                if (model.EmrFileIndex.ToString() != null)
					oneUpdate[35].Value =model.EmrFileIndex;
				else
					oneUpdate[35].Value = DBNull.Value;
                if (model.ArchiveTimes.ToString() != null)
					oneUpdate[36].Value =model.ArchiveTimes;
				else
					oneUpdate[36].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_EMR_ARCHIVE_DETIAL_EXT_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedEmrArchiveDetialExt 
		///Delete Table MED_EMR_ARCHIVE_DETIAL_EXT by (string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
		/// </summary>
		public int DeleteMedEmrArchiveDetialExtSQL(string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedEmrArchiveDetialExt");
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
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_EMR_ARCHIVE_DETIAL_EXT_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedEmrArchiveDetialExt 
		///select Table MED_EMR_ARCHIVE_DETIAL_EXT by (string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
		/// </summary>
		public MedEmrArchiveDetialExt  SelectMedEmrArchiveDetialExtSQL(string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
		{
			MedEmrArchiveDetialExt model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedEmrArchiveDetialExt");
			parameterValues[0].Value=PATIENT_ID;
			parameterValues[1].Value=VISIT_ID;
			parameterValues[2].Value=MR_CLASS;
			parameterValues[3].Value=MR_SUB_CLASS;
			parameterValues[4].Value=ARCHIVE_KEY;
			parameterValues[5].Value=EMR_FILE_INDEX;
			parameterValues[6].Value=ARCHIVE_TIMES;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_EXT_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedEmrArchiveDetialExt();
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
					if (!oleReader.IsDBNull(19))
					{
                        model.EmrXmlFile = (byte[])oleReader["EMR_XML_FILE"];
					}
					if (!oleReader.IsDBNull(20))
					{
						model.EmrXmlName = oleReader["EMR_XML_NAME"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(21))
					{
						model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(22))
					{
						model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(23))
					{
						model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(24))
					{
						model.Reserved04 = oleReader["RESERVED04"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(25))
					{
						model.Reserved05 = oleReader["RESERVED05"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(26))
					{
						model.Reserved06 = decimal.Parse(oleReader["RESERVED06"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(27))
					{
						model.Reserved07 = decimal.Parse(oleReader["RESERVED07"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(28))
					{
                        model.Reserved08 = (byte[])oleReader["RESERVED08"];
					}
					if (!oleReader.IsDBNull(29))
					{
                        model.Reserved09 = (byte[])oleReader["RESERVED09"];
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
		public List<MedEmrArchiveDetialExt> SelectMedEmrArchiveDetialExtListSQL()
		{
			List<MedEmrArchiveDetialExt> modelList = new List<MedEmrArchiveDetialExt>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_EXT_Select_ALL_SQL, null))
			{
				while (oleReader.Read())
				{
					MedEmrArchiveDetialExt model = new MedEmrArchiveDetialExt();
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
						if (!oleReader.IsDBNull(19))
						{
                            model.EmrXmlFile = (byte[])oleReader["EMR_XML_FILE"];
						}
						if (!oleReader.IsDBNull(20))
						{
							model.EmrXmlName = oleReader["EMR_XML_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(23))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(24))
						{
							model.Reserved04 = oleReader["RESERVED04"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(25))
						{
							model.Reserved05 = oleReader["RESERVED05"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(26))
						{
							model.Reserved06 = decimal.Parse(oleReader["RESERVED06"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(27))
						{
							model.Reserved07 = decimal.Parse(oleReader["RESERVED07"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(28))
						{
                            model.Reserved08 = (byte[])oleReader["RESERVED08"];
						}
						if (!oleReader.IsDBNull(29))
						{
                            model.Reserved09 = (byte[])oleReader["RESERVED09"];
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
        public List<MedEmrArchiveDetialExt> SelectMedEmrArchiveDetialExtListSQL(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS)
        {
            List<MedEmrArchiveDetialExt> modelList = new List<MedEmrArchiveDetialExt>();
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedEmrArchiveDetialExtMrClass");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_EXT_Select_MRCLASS_SQL, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedEmrArchiveDetialExt model = new MedEmrArchiveDetialExt();
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
                    if (!oleReader.IsDBNull(19))
                    {
                        model.EmrXmlFile = (byte[])oleReader["EMR_XML_FILE"];
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.EmrXmlName = oleReader["EMR_XML_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Reserved06 = decimal.Parse(oleReader["RESERVED06"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.Reserved07 = decimal.Parse(oleReader["RESERVED07"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.Reserved08 = (byte[])oleReader["RESERVED08"];
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.Reserved09 = (byte[])oleReader["RESERVED09"];
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion	

        #region  [获取记录SQL MR_CLASS  ARCHIVE_KEY1 ARCHIVE_KEY2]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedEmrArchiveDetialExt> SelectMedEmrArchiveDetialExtListSQL(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS, string ARCHIVE_KEY1, string ARCHIVE_KEY2)
        {
            List<MedEmrArchiveDetialExt> modelList = new List<MedEmrArchiveDetialExt>();
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedEmrArchiveDetialExtMrClassArchiveKey");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;
            parameterValues[3].Value = ARCHIVE_KEY1;
            parameterValues[4].Value = ARCHIVE_KEY2;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_EXT_Select_MRCLASS_ARCHIVE_KEY_SQL, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedEmrArchiveDetialExt model = new MedEmrArchiveDetialExt();
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
                    if (!oleReader.IsDBNull(19))
                    {
                        model.EmrXmlFile = (byte[])oleReader["EMR_XML_FILE"];
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.EmrXmlName = oleReader["EMR_XML_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Reserved06 = decimal.Parse(oleReader["RESERVED06"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.Reserved07 = decimal.Parse(oleReader["RESERVED07"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.Reserved08 = (byte[])oleReader["RESERVED08"];
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.Reserved09 = (byte[])oleReader["RESERVED09"];
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion	

		#region [获取参数]
		/// <summary>
		///获取参数MedEmrArchiveDetialExt
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedEmrArchiveDetialExt")
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
							new OracleParameter(":EmrXmlFile",OracleType.Blob),
							new OracleParameter(":EmrXmlName",OracleType.VarChar),
							new OracleParameter(":Reserved01",OracleType.VarChar),
							new OracleParameter(":Reserved02",OracleType.VarChar),
							new OracleParameter(":Reserved03",OracleType.VarChar),
							new OracleParameter(":Reserved04",OracleType.VarChar),
							new OracleParameter(":Reserved05",OracleType.VarChar),
							new OracleParameter(":Reserved06",OracleType.Number),
							new OracleParameter(":Reserved07",OracleType.Number),
							new OracleParameter(":Reserved08",OracleType.Blob),
							new OracleParameter(":Reserved09",OracleType.Blob),
                    };
                }
				else if (sqlParms == "UpdateMedEmrArchiveDetialExt")
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
							new OracleParameter(":EmrXmlFile",OracleType.Blob),
							new OracleParameter(":EmrXmlName",OracleType.VarChar),
							new OracleParameter(":Reserved01",OracleType.VarChar),
							new OracleParameter(":Reserved02",OracleType.VarChar),
							new OracleParameter(":Reserved03",OracleType.VarChar),
							new OracleParameter(":Reserved04",OracleType.VarChar),
							new OracleParameter(":Reserved05",OracleType.VarChar),
							new OracleParameter(":Reserved06",OracleType.Number),
							new OracleParameter(":Reserved07",OracleType.Number),
							new OracleParameter(":Reserved08",OracleType.Blob),
							new OracleParameter(":Reserved09",OracleType.Blob),
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":MrClass",OracleType.VarChar),
							new OracleParameter(":MrSubClass",OracleType.VarChar),
							new OracleParameter(":ArchiveKey",OracleType.VarChar),
							new OracleParameter(":EmrFileIndex",OracleType.Number),
							new OracleParameter(":ArchiveTimes",OracleType.Number),
                    };
                }
				else if(sqlParms == "DeleteMedEmrArchiveDetialExt")
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
				else if(sqlParms == "SelectMedEmrArchiveDetialExt")
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
                else if (sqlParms == "SelectMedEmrArchiveDetialExtMrClass")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":MrClass",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrArchiveDetialExtMrClassArchiveKey")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":MrClass",OracleType.VarChar),
                            new OracleParameter(":ArchiveKey1",OracleType.VarChar),
                            new OracleParameter(":ArchiveKey2",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedEmrArchiveDetialExt 
		///Insert Table MED_EMR_ARCHIVE_DETIAL_EXT
		/// </summary>
		public int InsertMedEmrArchiveDetialExt(MedEmrArchiveDetialExt model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedEmrArchiveDetialExt");
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
					if (model.EmrXmlFile != null)
						oneInert[19].Value = model.EmrXmlFile;
					else
						oneInert[19].Value = DBNull.Value;
					if (model.EmrXmlName != null)
						oneInert[20].Value = model.EmrXmlName;
					else
						oneInert[20].Value = DBNull.Value;
					if (model.Reserved01 != null)
						oneInert[21].Value = model.Reserved01;
					else
						oneInert[21].Value = DBNull.Value;
					if (model.Reserved02 != null)
						oneInert[22].Value = model.Reserved02;
					else
						oneInert[22].Value = DBNull.Value;
					if (model.Reserved03 != null)
						oneInert[23].Value = model.Reserved03;
					else
						oneInert[23].Value = DBNull.Value;
					if (model.Reserved04 != null)
						oneInert[24].Value = model.Reserved04;
					else
						oneInert[24].Value = DBNull.Value;
					if (model.Reserved05 != null)
						oneInert[25].Value = model.Reserved05;
					else
						oneInert[25].Value = DBNull.Value;
                    if (model.Reserved06.ToString() != null)
						oneInert[26].Value = model.Reserved06;
					else
						oneInert[26].Value = DBNull.Value;
                    if (model.Reserved07.ToString() != null)
						oneInert[27].Value = model.Reserved07;
					else
						oneInert[27].Value = DBNull.Value;
					if (model.Reserved08 != null)
						oneInert[28].Value = model.Reserved08;
					else
						oneInert[28].Value = DBNull.Value;
					if (model.Reserved09 != null)
						oneInert[29].Value = model.Reserved09;
					else
						oneInert[29].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_EMR_ARCHIVE_DETIAL_EXT_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedEmrArchiveDetialExt 
		///Update Table     MED_EMR_ARCHIVE_DETIAL_EXT
		/// </summary>
		public int UpdateMedEmrArchiveDetialExt(MedEmrArchiveDetialExt model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedEmrArchiveDetialExt");
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
					if (model.EmrXmlFile != null)
						oneUpdate[19].Value = model.EmrXmlFile;
					else
						oneUpdate[19].Value = DBNull.Value;
					if (model.EmrXmlName != null)
						oneUpdate[20].Value = model.EmrXmlName;
					else
						oneUpdate[20].Value = DBNull.Value;
					if (model.Reserved01 != null)
						oneUpdate[21].Value = model.Reserved01;
					else
						oneUpdate[21].Value = DBNull.Value;
					if (model.Reserved02 != null)
						oneUpdate[22].Value = model.Reserved02;
					else
						oneUpdate[22].Value = DBNull.Value;
					if (model.Reserved03 != null)
						oneUpdate[23].Value = model.Reserved03;
					else
						oneUpdate[23].Value = DBNull.Value;
					if (model.Reserved04 != null)
						oneUpdate[24].Value = model.Reserved04;
					else
						oneUpdate[24].Value = DBNull.Value;
					if (model.Reserved05 != null)
						oneUpdate[25].Value = model.Reserved05;
					else
						oneUpdate[25].Value = DBNull.Value;
                    if (model.Reserved06.ToString() != null)
						oneUpdate[26].Value = model.Reserved06;
					else
						oneUpdate[26].Value = DBNull.Value;
                    if (model.Reserved07.ToString() != null)
						oneUpdate[27].Value = model.Reserved07;
					else
						oneUpdate[27].Value = DBNull.Value;
					if (model.Reserved08 != null)
						oneUpdate[28].Value = model.Reserved08;
					else
						oneUpdate[28].Value = DBNull.Value;
					if (model.Reserved09 != null)
						oneUpdate[29].Value = model.Reserved09;
					else
						oneUpdate[29].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[30].Value =model.PatientId;
					else
						oneUpdate[30].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneUpdate[31].Value =model.VisitId;
					else
						oneUpdate[31].Value = DBNull.Value;
					if (model.MrClass != null)
						oneUpdate[32].Value =model.MrClass;
					else
						oneUpdate[32].Value = DBNull.Value;
					if (model.MrSubClass != null)
						oneUpdate[33].Value =model.MrSubClass;
					else
						oneUpdate[33].Value = DBNull.Value;
					if (model.ArchiveKey != null)
						oneUpdate[34].Value =model.ArchiveKey;
					else
						oneUpdate[34].Value = DBNull.Value;
                    if (model.EmrFileIndex.ToString() != null)
						oneUpdate[35].Value =model.EmrFileIndex;
					else
						oneUpdate[35].Value = DBNull.Value;
                    if (model.ArchiveTimes.ToString() != null)
						oneUpdate[36].Value =model.ArchiveTimes;
					else
						oneUpdate[36].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_EMR_ARCHIVE_DETIAL_EXT_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedEmrArchiveDetialExt 
		///Delete Table MED_EMR_ARCHIVE_DETIAL_EXT by (string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
		/// </summary>
		public int DeleteMedEmrArchiveDetialExt(string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedEmrArchiveDetialExt");
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
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_EMR_ARCHIVE_DETIAL_EXT_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedEmrArchiveDetialExt 
		///select Table MED_EMR_ARCHIVE_DETIAL_EXT by (string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
		/// </summary>
		public MedEmrArchiveDetialExt  SelectMedEmrArchiveDetialExt(string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
		{
			MedEmrArchiveDetialExt model;
			OracleParameter[] parameterValues = GetParameter("SelectMedEmrArchiveDetialExt");
			parameterValues[0].Value=PATIENT_ID;
			parameterValues[1].Value=VISIT_ID;
			parameterValues[2].Value=MR_CLASS;
			parameterValues[3].Value=MR_SUB_CLASS;
			parameterValues[4].Value=ARCHIVE_KEY;
			parameterValues[5].Value=EMR_FILE_INDEX;
			parameterValues[6].Value=ARCHIVE_TIMES;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_EXT_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedEmrArchiveDetialExt();
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
					if (!oleReader.IsDBNull(19))
					{
                        model.EmrXmlFile = (byte[])oleReader["EMR_XML_FILE"];
					}
					if (!oleReader.IsDBNull(20))
					{
						model.EmrXmlName = oleReader["EMR_XML_NAME"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(21))
					{
						model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(22))
					{
						model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(23))
					{
						model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(24))
					{
						model.Reserved04 = oleReader["RESERVED04"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(25))
					{
						model.Reserved05 = oleReader["RESERVED05"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(26))
					{
						model.Reserved06 = decimal.Parse(oleReader["RESERVED06"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(27))
					{
						model.Reserved07 = decimal.Parse(oleReader["RESERVED07"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(28))
					{
                        model.Reserved08 = (byte[])oleReader["RESERVED08"];
					}
					if (!oleReader.IsDBNull(29))
					{
                        model.Reserved09 = (byte[])oleReader["RESERVED09"];
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
		public List<MedEmrArchiveDetialExt> SelectMedEmrArchiveDetialExtList()
		{
			List<MedEmrArchiveDetialExt> modelList = new List<MedEmrArchiveDetialExt>();
		    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_EXT_Select_ALL, null))
			{
				while (oleReader.Read())
				{
					MedEmrArchiveDetialExt model = new MedEmrArchiveDetialExt();
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
						if (!oleReader.IsDBNull(19))
						{
                            model.EmrXmlFile = (byte[])oleReader["EMR_XML_FILE"];
						}
						if (!oleReader.IsDBNull(20))
						{
							model.EmrXmlName = oleReader["EMR_XML_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(23))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(24))
						{
							model.Reserved04 = oleReader["RESERVED04"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(25))
						{
							model.Reserved05 = oleReader["RESERVED05"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(26))
						{
							model.Reserved06 = decimal.Parse(oleReader["RESERVED06"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(27))
						{
							model.Reserved07 = decimal.Parse(oleReader["RESERVED07"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(28))
						{
                            model.Reserved08 = (byte[])oleReader["RESERVED08"];
						}
						if (!oleReader.IsDBNull(29))
						{
                            model.Reserved09 = (byte[])oleReader["RESERVED09"];
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
        public List<MedEmrArchiveDetialExt> SelectMedEmrArchiveDetialExtList(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS)
        {
            List<MedEmrArchiveDetialExt> modelList = new List<MedEmrArchiveDetialExt>();
            OracleParameter[] parameterValues = GetParameter("SelectMedEmrArchiveDetialExtMrClass");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_EXT_Select_MRCLASS, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedEmrArchiveDetialExt model = new MedEmrArchiveDetialExt();
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
                    if (!oleReader.IsDBNull(19))
                    {
                        model.EmrXmlFile = (byte[])oleReader["EMR_XML_FILE"];
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.EmrXmlName = oleReader["EMR_XML_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Reserved06 = decimal.Parse(oleReader["RESERVED06"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.Reserved07 = decimal.Parse(oleReader["RESERVED07"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.Reserved08 = (byte[])oleReader["RESERVED08"];
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.Reserved09 = (byte[])oleReader["RESERVED09"];
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion	

        #region  [获取记录 MR_CLASS ARCHIVE_KEY1 ARCHIVE_KEY2]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedEmrArchiveDetialExt> SelectMedEmrArchiveDetialExtList(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS, string ARCHIVE_KEY1, string ARCHIVE_KEY2)
        {
            List<MedEmrArchiveDetialExt> modelList = new List<MedEmrArchiveDetialExt>();
            OracleParameter[] parameterValues = GetParameter("SelectMedEmrArchiveDetialExtMrClassArchiveKey");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;
            parameterValues[3].Value = ARCHIVE_KEY1;
            parameterValues[4].Value = ARCHIVE_KEY2;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_EXT_Select_MRCLASS_ARCHIVE_KEY, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedEmrArchiveDetialExt model = new MedEmrArchiveDetialExt();
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
                    if (!oleReader.IsDBNull(19))
                    {
                        model.EmrXmlFile = (byte[])oleReader["EMR_XML_FILE"];
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.EmrXmlName = oleReader["EMR_XML_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Reserved06 = decimal.Parse(oleReader["RESERVED06"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.Reserved07 = decimal.Parse(oleReader["RESERVED07"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.Reserved08 = (byte[])oleReader["RESERVED08"];
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.Reserved09 = (byte[])oleReader["RESERVED09"];
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion	
	}
}
