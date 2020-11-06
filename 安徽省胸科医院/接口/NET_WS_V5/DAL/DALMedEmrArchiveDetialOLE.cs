

/*********************************************************************
 * Author    雷锋爷爷
 * Date      2010-08-31 175251
 * 
 * Notes
 * 
* ******************************************************************/

using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Data.Odbc;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedEmrArchiveDetial
	/// </summary>
    public partial class DALMedEmrArchiveDetial
    {
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Insert_OLE = "INSERT INTO MED_EMR_ARCHIVE_DETIAL (PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO) values ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Update_OLE = "UPDATE MED_EMR_ARCHIVE_DETIAL SET PATIENT_ID= ?,VISIT_ID= ?,MR_CLASS= ?,MR_SUB_CLASS= ?,ARCHIVE_KEY= ?,EMR_FILE_INDEX= ?,ARCHIVE_TIMES= ?,TOPIC= ?,EMR_FILE_NAME= ?,EMR_TYPE= ?,ARCHIVE_DATE_TIME= ?,ARCHIVE_TYPE= ?,ARCHIVE_STATUS= ?,EMR_OWNER= ?,OPERATOR= ?,ARCHIVE_PC= ?,ARCHIVE_MODE= ?,ARCHIVE_ACCESS= ?,MEMO= ? WHERE  PATIENT_ID= ? AND VISIT_ID= ? AND MR_CLASS= ? AND MR_SUB_CLASS= ? AND ARCHIVE_KEY= ? AND EMR_FILE_INDEX= ? AND ARCHIVE_TIMES= ?";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Delete_OLE = "DELETE MED_EMR_ARCHIVE_DETIAL WHERE  PATIENT_ID= ? AND VISIT_ID= ? AND MR_CLASS= ? AND MR_SUB_CLASS= ? AND ARCHIVE_KEY= ? AND EMR_FILE_INDEX= ? AND ARCHIVE_TIMES= ?";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_OLE = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL where  PATIENT_ID= ? AND VISIT_ID= ? AND MR_CLASS= ? AND MR_SUB_CLASS= ? AND ARCHIVE_KEY= ? AND EMR_FILE_INDEX= ? AND ARCHIVE_TIMES= ?";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_NoIndex_OLE = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL where  PATIENT_ID= ? AND VISIT_ID= ? AND MR_CLASS= ? AND MR_SUB_CLASS= ? AND ARCHIVE_KEY= ? AND ARCHIVE_TIMES= ?";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_MRCLASS_ArchiveKey_OLE = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL where  PATIENT_ID= ? AND VISIT_ID= ? AND MR_CLASS= ? AND ARCHIVE_KEY= ?";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_MRCLASS_OLE = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL where  PATIENT_ID= ? AND VISIT_ID= ? AND MR_CLASS=MrClass";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_ALL_OLE = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL";

        #region [获取参数]
        /// <summary>
        ///获取参数MedEmrArchiveDetial
        /// </summary>
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedEmrArchiveDetial")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("MrClass",OleDbType.VarChar),
							new OleDbParameter("MrSubClass",OleDbType.VarChar),
							new OleDbParameter("ArchiveKey",OleDbType.VarChar),
							new OleDbParameter("EmrFileIndex",OleDbType.Decimal),
							new OleDbParameter("ArchiveTimes",OleDbType.Decimal),
							new OleDbParameter("Topic",OleDbType.VarChar),
							new OleDbParameter("EmrFileName",OleDbType.VarChar),
							new OleDbParameter("EmrType",OleDbType.VarChar),
							new OleDbParameter("ArchiveDateTime",OleDbType.DBTimeStamp),
							new OleDbParameter("ArchiveType",OleDbType.VarChar),
							new OleDbParameter("ArchiveStatus",OleDbType.VarChar),
							new OleDbParameter("EmrOwner",OleDbType.VarChar),
							new OleDbParameter("Operator",OleDbType.VarChar),
							new OleDbParameter("ArchivePc",OleDbType.VarChar),
							new OleDbParameter("ArchiveMode",OleDbType.VarChar),
							new OleDbParameter("ArchiveAccess",OleDbType.VarChar),
							new OleDbParameter("Memo",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedEmrArchiveDetial")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("MrClass",OleDbType.VarChar),
							new OleDbParameter("MrSubClass",OleDbType.VarChar),
							new OleDbParameter("ArchiveKey",OleDbType.VarChar),
							new OleDbParameter("EmrFileIndex",OleDbType.Decimal),
							new OleDbParameter("ArchiveTimes",OleDbType.Decimal),
							new OleDbParameter("Topic",OleDbType.VarChar),
							new OleDbParameter("EmrFileName",OleDbType.VarChar),
							new OleDbParameter("EmrType",OleDbType.VarChar),
							new OleDbParameter("ArchiveDateTime",OleDbType.DBTimeStamp),
							new OleDbParameter("ArchiveType",OleDbType.VarChar),
							new OleDbParameter("ArchiveStatus",OleDbType.VarChar),
							new OleDbParameter("EmrOwner",OleDbType.VarChar),
							new OleDbParameter("Operator",OleDbType.VarChar),
							new OleDbParameter("ArchivePc",OleDbType.VarChar),
							new OleDbParameter("ArchiveMode",OleDbType.VarChar),
							new OleDbParameter("ArchiveAccess",OleDbType.VarChar),
							new OleDbParameter("Memo",OleDbType.VarChar),
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("MrClass",OleDbType.VarChar),
							new OleDbParameter("MrSubClass",OleDbType.VarChar),
							new OleDbParameter("ArchiveKey",OleDbType.VarChar),
							new OleDbParameter("EmrFileIndex",OleDbType.Decimal),
							new OleDbParameter("ArchiveTimes",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedEmrArchiveDetial")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("MrClass",OleDbType.VarChar),
							new OleDbParameter("MrSubClass",OleDbType.VarChar),
							new OleDbParameter("ArchiveKey",OleDbType.VarChar),
							new OleDbParameter("EmrFileIndex",OleDbType.Decimal),
							new OleDbParameter("ArchiveTimes",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedEmrArchiveDetial")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("MrClass",OleDbType.VarChar),
							new OleDbParameter("MrSubClass",OleDbType.VarChar),
							new OleDbParameter("ArchiveKey",OleDbType.VarChar),
							new OleDbParameter("EmrFileIndex",OleDbType.Decimal),
							new OleDbParameter("ArchiveTimes",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedEmrArchiveDetialList")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("MrClass",OleDbType.VarChar),
							new OleDbParameter("MrSubClass",OleDbType.VarChar),
							new OleDbParameter("ArchiveKey",OleDbType.VarChar),
							new OleDbParameter("ArchiveTimes",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedEmrArchiveDetialMrClassArchiveKey")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("PatientId",OleDbType.VarChar),
						new OleDbParameter("VisitId",OleDbType.Decimal),
						new OleDbParameter("MrClass",OleDbType.VarChar),
						new OleDbParameter("ArchiveKey",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrArchiveDetialMrClass")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("PatientId",OleDbType.VarChar),
						new OleDbParameter("VisitId",OleDbType.Decimal),
						new OleDbParameter("MrClass",OleDbType.VarChar),
						new OleDbParameter("ArchiveKey",OleDbType.VarChar),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedEmrArchiveDetial 
        ///Insert Table MED_EMR_ARCHIVE_DETIAL
        /// </summary>
        public int InsertMedEmrArchiveDetialOLE(MedEmrArchiveDetial model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedEmrArchiveDetial");
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

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Insert_OLE, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedEmrArchiveDetial 
        ///Update Table     MED_EMR_ARCHIVE_DETIAL
        /// </summary>
        public int UpdateMedEmrArchiveDetialOLE(MedEmrArchiveDetial model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedEmrArchiveDetial");
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
                    oneUpdate[19].Value = model.PatientId;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneUpdate[20].Value = model.VisitId;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.MrClass != null)
                    oneUpdate[21].Value = model.MrClass;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.MrSubClass != null)
                    oneUpdate[22].Value = model.MrSubClass;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.ArchiveKey != null)
                    oneUpdate[23].Value = model.ArchiveKey;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.EmrFileIndex.ToString() != null)
                    oneUpdate[24].Value = model.EmrFileIndex;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.ArchiveTimes.ToString() != null)
                    oneUpdate[25].Value = model.ArchiveTimes;
                else
                    oneUpdate[25].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Update_OLE, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedEmrArchiveDetial 
        ///Delete Table MED_EMR_ARCHIVE_DETIAL by (string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
        /// </summary>
        public int DeleteMedEmrArchiveDetialOLE(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS, string MR_SUB_CLASS, string ARCHIVE_KEY, decimal EMR_FILE_INDEX, decimal ARCHIVE_TIMES)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedEmrArchiveDetial");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (VISIT_ID.ToString() != null)
                    oneDelete[1].Value = VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (MR_CLASS != null)
                    oneDelete[2].Value = MR_CLASS;
                else
                    oneDelete[2].Value = DBNull.Value;
                if (MR_SUB_CLASS != null)
                    oneDelete[3].Value = MR_SUB_CLASS;
                else
                    oneDelete[3].Value = DBNull.Value;
                if (ARCHIVE_KEY != null)
                    oneDelete[4].Value = ARCHIVE_KEY;
                else
                    oneDelete[4].Value = DBNull.Value;
                if (EMR_FILE_INDEX.ToString() != null)
                    oneDelete[5].Value = EMR_FILE_INDEX;
                else
                    oneDelete[5].Value = DBNull.Value;
                if (ARCHIVE_TIMES.ToString() != null)
                    oneDelete[6].Value = ARCHIVE_TIMES;
                else
                    oneDelete[6].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Delete_OLE, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedEmrArchiveDetial 
        ///select Table MED_EMR_ARCHIVE_DETIAL by (string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
        /// </summary>
        public MedEmrArchiveDetial SelectMedEmrArchiveDetialOLE(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS, string MR_SUB_CLASS, string ARCHIVE_KEY, decimal EMR_FILE_INDEX, decimal ARCHIVE_TIMES)
        {
            MedEmrArchiveDetial model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedEmrArchiveDetial");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;
            parameterValues[3].Value = MR_SUB_CLASS;
            parameterValues[4].Value = ARCHIVE_KEY;
            parameterValues[5].Value = EMR_FILE_INDEX;
            parameterValues[6].Value = ARCHIVE_TIMES;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_OLE, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedEmrArchiveDetial();
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
        public List<MedEmrArchiveDetial> SelectMedEmrArchiveDetialOLE(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS, string MR_SUB_CLASS, string ARCHIVE_KEY, decimal ARCHIVE_TIMES)
        {
            List<MedEmrArchiveDetial> modelList = new List<MedEmrArchiveDetial>();

            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedEmrArchiveDetialList");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;
            parameterValues[3].Value = MR_SUB_CLASS;
            parameterValues[4].Value = ARCHIVE_KEY;
            parameterValues[5].Value = ARCHIVE_TIMES;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_NoIndex_OLE, parameterValues))
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
        #region  [获取所有记录]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedEmrArchiveDetial> SelectMedEmrArchiveDetialListOLE()
        {
            List<MedEmrArchiveDetial> modelList = new List<MedEmrArchiveDetial>();
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_ALL_OLE, null))
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
        #region  [获取记录 MR_CLASS ARCHIVE_KEY]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedEmrArchiveDetial> SelectMedEmrArchiveDetialListOLE(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS, string ARCHIVE_KEY)
        {
            List<MedEmrArchiveDetial> modelList = new List<MedEmrArchiveDetial>();
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedEmrArchiveDetialMrClassArchiveKey");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;
            parameterValues[4].Value = ARCHIVE_KEY;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_MRCLASS_ArchiveKey_OLE, parameterValues))
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
        public List<MedEmrArchiveDetial> SelectMedEmrArchiveDetialListOLE(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS)
        {
            List<MedEmrArchiveDetial> modelList = new List<MedEmrArchiveDetial>();
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedEmrArchiveDetialMrClass");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_MRCLASS_OLE, parameterValues))
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

        private static readonly string MED_EMR_ARCHIVE_DETIAL_Insert_Odbc = "INSERT INTO MED_EMR_ARCHIVE_DETIAL (PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO) values ( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Update_Odbc = "UPDATE MED_EMR_ARCHIVE_DETIAL SET PATIENT_ID= ?,VISIT_ID= ?,MR_CLASS= ?,MR_SUB_CLASS= ?,ARCHIVE_KEY= ?,EMR_FILE_INDEX= ?,ARCHIVE_TIMES= ?,TOPIC= ?,EMR_FILE_NAME= ?,EMR_TYPE= ?,ARCHIVE_DATE_TIME= ?, ARCHIVE_TYPE= ?,ARCHIVE_STATUS= ?,EMR_OWNER= ?,OPERATOR= ?,ARCHIVE_PC= ?,ARCHIVE_MODE= ?,ARCHIVE_ACCESS= ?,MEMO= ? WHERE  PATIENT_ID= ? AND VISIT_ID= ? AND MR_CLASS= ? AND MR_SUB_CLASS= ? AND ARCHIVE_KEY= ? AND EMR_FILE_INDEX= ? AND ARCHIVE_TIMES= ?";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Delete_Odbc = "DELETE MED_EMR_ARCHIVE_DETIAL WHERE  PATIENT_ID= ? AND VISIT_ID= ? AND MR_CLASS= ? AND MR_SUB_CLASS= ? AND ARCHIVE_KEY= ? AND EMR_FILE_INDEX= ? AND ARCHIVE_TIMES= ?";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_Odbc = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL where  PATIENT_ID= ? AND VISIT_ID= ? AND MR_CLASS= ? AND MR_SUB_CLASS= ? AND ARCHIVE_KEY= ? AND EMR_FILE_INDEX= ? AND ARCHIVE_TIMES= ?";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_NoIndex_Odbc = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL where  PATIENT_ID= ? AND VISIT_ID= ? AND MR_CLASS= ? AND MR_SUB_CLASS= ? AND ARCHIVE_KEY= ? AND ARCHIVE_TIMES= ?";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_MRCLASS_ArchiveKey_Odbc = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL where  PATIENT_ID= ? AND VISIT_ID= ? AND MR_CLASS= ? AND ARCHIVE_KEY= ?";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_MRCLASS_Odbc = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL where  PATIENT_ID= ? AND VISIT_ID= ? AND MR_CLASS= ?";
        private static readonly string MED_EMR_ARCHIVE_DETIAL_Select_ALL_Odbc = "SELECT PATIENT_ID,VISIT_ID,MR_CLASS,MR_SUB_CLASS,ARCHIVE_KEY,EMR_FILE_INDEX,ARCHIVE_TIMES,TOPIC,EMR_FILE_NAME,EMR_TYPE,ARCHIVE_DATE_TIME,ARCHIVE_TYPE,ARCHIVE_STATUS,EMR_OWNER,OPERATOR,ARCHIVE_PC,ARCHIVE_MODE,ARCHIVE_ACCESS,MEMO FROM MED_EMR_ARCHIVE_DETIAL";

        #region [获取参数]
        /// <summary>
        ///获取参数MedEmrArchiveDetial
        /// </summary>
        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedEmrArchiveDetial")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("MrClass",OdbcType.VarChar),
							new OdbcParameter("MrSubClass",OdbcType.VarChar),
							new OdbcParameter("ArchiveKey",OdbcType.VarChar),
							new OdbcParameter("EmrFileIndex",OdbcType.Decimal),
							new OdbcParameter("ArchiveTimes",OdbcType.Decimal),
							new OdbcParameter("Topic",OdbcType.VarChar),
							new OdbcParameter("EmrFileName",OdbcType.VarChar),
							new OdbcParameter("EmrType",OdbcType.VarChar),
							new OdbcParameter("ArchiveDateTime",OdbcType.DateTime),
							new OdbcParameter("ArchiveType",OdbcType.VarChar),
							new OdbcParameter("ArchiveStatus",OdbcType.VarChar),
							new OdbcParameter("EmrOwner",OdbcType.VarChar),
							new OdbcParameter("Operator",OdbcType.VarChar),
							new OdbcParameter("ArchivePc",OdbcType.VarChar),
							new OdbcParameter("ArchiveMode",OdbcType.VarChar),
							new OdbcParameter("ArchiveAccess",OdbcType.VarChar),
							new OdbcParameter("Memo",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedEmrArchiveDetial")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("MrClass",OdbcType.VarChar),
							new OdbcParameter("MrSubClass",OdbcType.VarChar),
							new OdbcParameter("ArchiveKey",OdbcType.VarChar),
							new OdbcParameter("EmrFileIndex",OdbcType.Decimal),
							new OdbcParameter("ArchiveTimes",OdbcType.Decimal),
							new OdbcParameter("Topic",OdbcType.VarChar),
							new OdbcParameter("EmrFileName",OdbcType.VarChar),
							new OdbcParameter("EmrType",OdbcType.VarChar),
							new OdbcParameter("ArchiveDateTime",OdbcType.DateTime),
							new OdbcParameter("ArchiveType",OdbcType.VarChar),
							new OdbcParameter("ArchiveStatus",OdbcType.VarChar),
							new OdbcParameter("EmrOwner",OdbcType.VarChar),
							new OdbcParameter("Operator",OdbcType.VarChar),
							new OdbcParameter("ArchivePc",OdbcType.VarChar),
							new OdbcParameter("ArchiveMode",OdbcType.VarChar),
							new OdbcParameter("ArchiveAccess",OdbcType.VarChar),
							new OdbcParameter("Memo",OdbcType.VarChar),
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("MrClass",OdbcType.VarChar),
							new OdbcParameter("MrSubClass",OdbcType.VarChar),
							new OdbcParameter("ArchiveKey",OdbcType.VarChar),
							new OdbcParameter("EmrFileIndex",OdbcType.Decimal),
							new OdbcParameter("ArchiveTimes",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedEmrArchiveDetial")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("MrClass",OdbcType.VarChar),
							new OdbcParameter("MrSubClass",OdbcType.VarChar),
							new OdbcParameter("ArchiveKey",OdbcType.VarChar),
							new OdbcParameter("EmrFileIndex",OdbcType.Decimal),
							new OdbcParameter("ArchiveTimes",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedEmrArchiveDetial")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("MrClass",OdbcType.VarChar),
							new OdbcParameter("MrSubClass",OdbcType.VarChar),
							new OdbcParameter("ArchiveKey",OdbcType.VarChar),
							new OdbcParameter("EmrFileIndex",OdbcType.Decimal),
							new OdbcParameter("ArchiveTimes",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedEmrArchiveDetialList")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("MrClass",OdbcType.VarChar),
							new OdbcParameter("MrSubClass",OdbcType.VarChar),
							new OdbcParameter("ArchiveKey",OdbcType.VarChar),
							new OdbcParameter("ArchiveTimes",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedEmrArchiveDetialMrClassArchiveKey")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("PatientId",OdbcType.VarChar),
						new OdbcParameter("VisitId",OdbcType.Decimal),
						new OdbcParameter("MrClass",OdbcType.VarChar),
						new OdbcParameter("ArchiveKey",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrArchiveDetialMrClass")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("PatientId",OdbcType.VarChar),
						new OdbcParameter("VisitId",OdbcType.Decimal),
						new OdbcParameter("MrClass",OdbcType.VarChar),
						new OdbcParameter("ArchiveKey",OdbcType.VarChar),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedEmrArchiveDetial 
        ///Insert Table MED_EMR_ARCHIVE_DETIAL
        /// </summary>
        public int InsertMedEmrArchiveDetialOdbc(MedEmrArchiveDetial model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedEmrArchiveDetial");
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

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Insert_Odbc, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedEmrArchiveDetial 
        ///Update Table     MED_EMR_ARCHIVE_DETIAL
        /// </summary>
        public int UpdateMedEmrArchiveDetialOdbc(MedEmrArchiveDetial model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedEmrArchiveDetial");
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
                    oneUpdate[19].Value = model.PatientId;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneUpdate[20].Value = model.VisitId;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.MrClass != null)
                    oneUpdate[21].Value = model.MrClass;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.MrSubClass != null)
                    oneUpdate[22].Value = model.MrSubClass;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.ArchiveKey != null)
                    oneUpdate[23].Value = model.ArchiveKey;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.EmrFileIndex.ToString() != null)
                    oneUpdate[24].Value = model.EmrFileIndex;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.ArchiveTimes.ToString() != null)
                    oneUpdate[25].Value = model.ArchiveTimes;
                else
                    oneUpdate[25].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Update_Odbc, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedEmrArchiveDetial 
        ///Delete Table MED_EMR_ARCHIVE_DETIAL by (string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
        /// </summary>
        public int DeleteMedEmrArchiveDetialOdbc(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS, string MR_SUB_CLASS, string ARCHIVE_KEY, decimal EMR_FILE_INDEX, decimal ARCHIVE_TIMES)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterOdbc("DeleteMedEmrArchiveDetial");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (VISIT_ID.ToString() != null)
                    oneDelete[1].Value = VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (MR_CLASS != null)
                    oneDelete[2].Value = MR_CLASS;
                else
                    oneDelete[2].Value = DBNull.Value;
                if (MR_SUB_CLASS != null)
                    oneDelete[3].Value = MR_SUB_CLASS;
                else
                    oneDelete[3].Value = DBNull.Value;
                if (ARCHIVE_KEY != null)
                    oneDelete[4].Value = ARCHIVE_KEY;
                else
                    oneDelete[4].Value = DBNull.Value;
                if (EMR_FILE_INDEX.ToString() != null)
                    oneDelete[5].Value = EMR_FILE_INDEX;
                else
                    oneDelete[5].Value = DBNull.Value;
                if (ARCHIVE_TIMES.ToString() != null)
                    oneDelete[6].Value = ARCHIVE_TIMES;
                else
                    oneDelete[6].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Delete_Odbc, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedEmrArchiveDetial 
        ///select Table MED_EMR_ARCHIVE_DETIAL by (string PATIENT_ID,decimal VISIT_ID,string MR_CLASS,string MR_SUB_CLASS,string ARCHIVE_KEY,decimal EMR_FILE_INDEX,decimal ARCHIVE_TIMES)
        /// </summary>
        public MedEmrArchiveDetial SelectMedEmrArchiveDetialOdbc(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS, string MR_SUB_CLASS, string ARCHIVE_KEY, decimal EMR_FILE_INDEX, decimal ARCHIVE_TIMES)
        {
            MedEmrArchiveDetial model;
            OdbcParameter[] parameterValues = GetParameterOdbc("SelectMedEmrArchiveDetial");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;
            parameterValues[3].Value = MR_SUB_CLASS;
            parameterValues[4].Value = ARCHIVE_KEY;
            parameterValues[5].Value = EMR_FILE_INDEX;
            parameterValues[6].Value = ARCHIVE_TIMES;
            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_Odbc, parameterValues))
            {
                if (OdbcReader.Read())
                {
                    model = new MedEmrArchiveDetial();
                    if (!OdbcReader.IsDBNull(0))
                    {
                        model.PatientId = OdbcReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(1))
                    {
                        model.VisitId = decimal.Parse(OdbcReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(2))
                    {
                        model.MrClass = OdbcReader["MR_CLASS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(3))
                    {
                        model.MrSubClass = OdbcReader["MR_SUB_CLASS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(4))
                    {
                        model.ArchiveKey = OdbcReader["ARCHIVE_KEY"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(5))
                    {
                        model.EmrFileIndex = decimal.Parse(OdbcReader["EMR_FILE_INDEX"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(6))
                    {
                        model.ArchiveTimes = decimal.Parse(OdbcReader["ARCHIVE_TIMES"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(7))
                    {
                        model.Topic = OdbcReader["TOPIC"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(8))
                    {
                        model.EmrFileName = OdbcReader["EMR_FILE_NAME"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(9))
                    {
                        model.EmrType = OdbcReader["EMR_TYPE"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(10))
                    {
                        model.ArchiveDateTime = DateTime.Parse(OdbcReader["ARCHIVE_DATE_TIME"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(11))
                    {
                        model.ArchiveType = OdbcReader["ARCHIVE_TYPE"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(12))
                    {
                        model.ArchiveStatus = OdbcReader["ARCHIVE_STATUS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(13))
                    {
                        model.EmrOwner = OdbcReader["EMR_OWNER"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(14))
                    {
                        model.Operator = OdbcReader["OPERATOR"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(15))
                    {
                        model.ArchivePc = OdbcReader["ARCHIVE_PC"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(16))
                    {
                        model.ArchiveMode = OdbcReader["ARCHIVE_MODE"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(17))
                    {
                        model.ArchiveAccess = OdbcReader["ARCHIVE_ACCESS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(18))
                    {
                        model.Memo = OdbcReader["MEMO"].ToString().Trim();
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
        public List<MedEmrArchiveDetial> SelectMedEmrArchiveDetialOdbc(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS, string MR_SUB_CLASS, string ARCHIVE_KEY, decimal ARCHIVE_TIMES)
        {
            List<MedEmrArchiveDetial> modelList = new List<MedEmrArchiveDetial>();

            OdbcParameter[] parameterValues = GetParameterOdbc("SelectMedEmrArchiveDetialList");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;
            parameterValues[3].Value = MR_SUB_CLASS;
            parameterValues[4].Value = ARCHIVE_KEY;
            parameterValues[5].Value = ARCHIVE_TIMES;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_NoIndex_Odbc, parameterValues))
            {
                while (OdbcReader.Read())
                {
                    MedEmrArchiveDetial model = new MedEmrArchiveDetial();
                    if (!OdbcReader.IsDBNull(0))
                    {
                        model.PatientId = OdbcReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(1))
                    {
                        model.VisitId = decimal.Parse(OdbcReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(2))
                    {
                        model.MrClass = OdbcReader["MR_CLASS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(3))
                    {
                        model.MrSubClass = OdbcReader["MR_SUB_CLASS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(4))
                    {
                        model.ArchiveKey = OdbcReader["ARCHIVE_KEY"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(5))
                    {
                        model.EmrFileIndex = decimal.Parse(OdbcReader["EMR_FILE_INDEX"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(6))
                    {
                        model.ArchiveTimes = decimal.Parse(OdbcReader["ARCHIVE_TIMES"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(7))
                    {
                        model.Topic = OdbcReader["TOPIC"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(8))
                    {
                        model.EmrFileName = OdbcReader["EMR_FILE_NAME"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(9))
                    {
                        model.EmrType = OdbcReader["EMR_TYPE"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(10))
                    {
                        model.ArchiveDateTime = DateTime.Parse(OdbcReader["ARCHIVE_DATE_TIME"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(11))
                    {
                        model.ArchiveType = OdbcReader["ARCHIVE_TYPE"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(12))
                    {
                        model.ArchiveStatus = OdbcReader["ARCHIVE_STATUS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(13))
                    {
                        model.EmrOwner = OdbcReader["EMR_OWNER"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(14))
                    {
                        model.Operator = OdbcReader["OPERATOR"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(15))
                    {
                        model.ArchivePc = OdbcReader["ARCHIVE_PC"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(16))
                    {
                        model.ArchiveMode = OdbcReader["ARCHIVE_MODE"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(17))
                    {
                        model.ArchiveAccess = OdbcReader["ARCHIVE_ACCESS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(18))
                    {
                        model.Memo = OdbcReader["MEMO"].ToString().Trim();
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
        public List<MedEmrArchiveDetial> SelectMedEmrArchiveDetialListOdbc()
        {
            List<MedEmrArchiveDetial> modelList = new List<MedEmrArchiveDetial>();
            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_ALL_Odbc, null))
            {
                while (OdbcReader.Read())
                {
                    MedEmrArchiveDetial model = new MedEmrArchiveDetial();
                    if (!OdbcReader.IsDBNull(0))
                    {
                        model.PatientId = OdbcReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(1))
                    {
                        model.VisitId = decimal.Parse(OdbcReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(2))
                    {
                        model.MrClass = OdbcReader["MR_CLASS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(3))
                    {
                        model.MrSubClass = OdbcReader["MR_SUB_CLASS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(4))
                    {
                        model.ArchiveKey = OdbcReader["ARCHIVE_KEY"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(5))
                    {
                        model.EmrFileIndex = decimal.Parse(OdbcReader["EMR_FILE_INDEX"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(6))
                    {
                        model.ArchiveTimes = decimal.Parse(OdbcReader["ARCHIVE_TIMES"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(7))
                    {
                        model.Topic = OdbcReader["TOPIC"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(8))
                    {
                        model.EmrFileName = OdbcReader["EMR_FILE_NAME"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(9))
                    {
                        model.EmrType = OdbcReader["EMR_TYPE"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(10))
                    {
                        model.ArchiveDateTime = DateTime.Parse(OdbcReader["ARCHIVE_DATE_TIME"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(11))
                    {
                        model.ArchiveType = OdbcReader["ARCHIVE_TYPE"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(12))
                    {
                        model.ArchiveStatus = OdbcReader["ARCHIVE_STATUS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(13))
                    {
                        model.EmrOwner = OdbcReader["EMR_OWNER"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(14))
                    {
                        model.Operator = OdbcReader["OPERATOR"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(15))
                    {
                        model.ArchivePc = OdbcReader["ARCHIVE_PC"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(16))
                    {
                        model.ArchiveMode = OdbcReader["ARCHIVE_MODE"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(17))
                    {
                        model.ArchiveAccess = OdbcReader["ARCHIVE_ACCESS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(18))
                    {
                        model.Memo = OdbcReader["MEMO"].ToString().Trim();
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
        public List<MedEmrArchiveDetial> SelectMedEmrArchiveDetialListOdbc(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS, string ARCHIVE_KEY)
        {
            List<MedEmrArchiveDetial> modelList = new List<MedEmrArchiveDetial>();
            OdbcParameter[] parameterValues = GetParameterOdbc("SelectMedEmrArchiveDetialMrClassArchiveKey");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;
            parameterValues[4].Value = ARCHIVE_KEY;
            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_MRCLASS_ArchiveKey_Odbc, parameterValues))
            {
                while (OdbcReader.Read())
                {
                    MedEmrArchiveDetial model = new MedEmrArchiveDetial();
                    if (!OdbcReader.IsDBNull(0))
                    {
                        model.PatientId = OdbcReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(1))
                    {
                        model.VisitId = decimal.Parse(OdbcReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(2))
                    {
                        model.MrClass = OdbcReader["MR_CLASS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(3))
                    {
                        model.MrSubClass = OdbcReader["MR_SUB_CLASS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(4))
                    {
                        model.ArchiveKey = OdbcReader["ARCHIVE_KEY"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(5))
                    {
                        model.EmrFileIndex = decimal.Parse(OdbcReader["EMR_FILE_INDEX"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(6))
                    {
                        model.ArchiveTimes = decimal.Parse(OdbcReader["ARCHIVE_TIMES"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(7))
                    {
                        model.Topic = OdbcReader["TOPIC"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(8))
                    {
                        model.EmrFileName = OdbcReader["EMR_FILE_NAME"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(9))
                    {
                        model.EmrType = OdbcReader["EMR_TYPE"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(10))
                    {
                        model.ArchiveDateTime = DateTime.Parse(OdbcReader["ARCHIVE_DATE_TIME"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(11))
                    {
                        model.ArchiveType = OdbcReader["ARCHIVE_TYPE"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(12))
                    {
                        model.ArchiveStatus = OdbcReader["ARCHIVE_STATUS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(13))
                    {
                        model.EmrOwner = OdbcReader["EMR_OWNER"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(14))
                    {
                        model.Operator = OdbcReader["OPERATOR"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(15))
                    {
                        model.ArchivePc = OdbcReader["ARCHIVE_PC"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(16))
                    {
                        model.ArchiveMode = OdbcReader["ARCHIVE_MODE"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(17))
                    {
                        model.ArchiveAccess = OdbcReader["ARCHIVE_ACCESS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(18))
                    {
                        model.Memo = OdbcReader["MEMO"].ToString().Trim();
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
        public List<MedEmrArchiveDetial> SelectMedEmrArchiveDetialListOdbc(string PATIENT_ID, decimal VISIT_ID, string MR_CLASS)
        {
            List<MedEmrArchiveDetial> modelList = new List<MedEmrArchiveDetial>();
            OdbcParameter[] parameterValues = GetParameterOdbc("SelectMedEmrArchiveDetialMrClass");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = MR_CLASS;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_EMR_ARCHIVE_DETIAL_Select_MRCLASS_Odbc, parameterValues))
            {
                while (OdbcReader.Read())
                {
                    MedEmrArchiveDetial model = new MedEmrArchiveDetial();
                    if (!OdbcReader.IsDBNull(0))
                    {
                        model.PatientId = OdbcReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(1))
                    {
                        model.VisitId = decimal.Parse(OdbcReader["VISIT_ID"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(2))
                    {
                        model.MrClass = OdbcReader["MR_CLASS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(3))
                    {
                        model.MrSubClass = OdbcReader["MR_SUB_CLASS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(4))
                    {
                        model.ArchiveKey = OdbcReader["ARCHIVE_KEY"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(5))
                    {
                        model.EmrFileIndex = decimal.Parse(OdbcReader["EMR_FILE_INDEX"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(6))
                    {
                        model.ArchiveTimes = decimal.Parse(OdbcReader["ARCHIVE_TIMES"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(7))
                    {
                        model.Topic = OdbcReader["TOPIC"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(8))
                    {
                        model.EmrFileName = OdbcReader["EMR_FILE_NAME"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(9))
                    {
                        model.EmrType = OdbcReader["EMR_TYPE"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(10))
                    {
                        model.ArchiveDateTime = DateTime.Parse(OdbcReader["ARCHIVE_DATE_TIME"].ToString().Trim());
                    }
                    if (!OdbcReader.IsDBNull(11))
                    {
                        model.ArchiveType = OdbcReader["ARCHIVE_TYPE"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(12))
                    {
                        model.ArchiveStatus = OdbcReader["ARCHIVE_STATUS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(13))
                    {
                        model.EmrOwner = OdbcReader["EMR_OWNER"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(14))
                    {
                        model.Operator = OdbcReader["OPERATOR"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(15))
                    {
                        model.ArchivePc = OdbcReader["ARCHIVE_PC"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(16))
                    {
                        model.ArchiveMode = OdbcReader["ARCHIVE_MODE"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(17))
                    {
                        model.ArchiveAccess = OdbcReader["ARCHIVE_ACCESS"].ToString().Trim();
                    }
                    if (!OdbcReader.IsDBNull(18))
                    {
                        model.Memo = OdbcReader["MEMO"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion


    }
}
