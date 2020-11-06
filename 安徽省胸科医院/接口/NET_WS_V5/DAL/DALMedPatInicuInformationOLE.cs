

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2011-03-05 16:32:46
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
using System.Data.OleDb;
using System.Data.Odbc;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedPatInicuInformation
    /// </summary>

    public partial class DALMedPatInicuInformation
    {
        private static readonly string MED_PAT_INICU_INFORMATION_Insert_OLE = "INSERT INTO MED_PAT_INICU_INFORMATION (PATIENT_ID,VISIT_ID,DEP_ID,IN_ICU_TIMES,IN_ICU_DATETIME,OUT_ICU_DATETIME,DIAGNOSE,BED_NO,DOCTOR,BODY_WEIGHT,BODY_HEIGHT,WARD_CODE,COMMIT_STATUS,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08,RESERVED09,RESERVED10,RESERVED11,RESERVED12,RESERVED13,RESERVED14,RESERVED15,RESERVED16,RESERVED17,RESERVED18,RESERVED19,RESERVED20) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_PAT_INICU_INFORMATION_Update_OLE = "UPDATE MED_PAT_INICU_INFORMATION SET PATIENT_ID=?,VISIT_ID=?,DEP_ID=?,IN_ICU_TIMES=?,IN_ICU_DATETIME=?,OUT_ICU_DATETIME=?,DIAGNOSE=?,BED_NO=?,DOCTOR=?,BODY_WEIGHT=?,BODY_HEIGHT=?,WARD_CODE=?,COMMIT_STATUS=?,RESERVED01=?,RESERVED02=?,RESERVED03=?,RESERVED04=?,RESERVED05=?,RESERVED06=?,RESERVED07=?,RESERVED08=?,RESERVED09=?,RESERVED10=?,RESERVED11=?,RESERVED12=?,RESERVED13=?,RESERVED14=?,RESERVED15=?,RESERVED16=?,RESERVED17=?,RESERVED18=?,RESERVED19=?,RESERVED20=? WHERE  PATIENT_ID=? AND VISIT_ID=? AND DEP_ID=? AND IN_ICU_TIMES=?";
        private static readonly string MED_PAT_INICU_INFORMATION_Delete_OLE = "DELETE MED_PAT_INICU_INFORMATION WHERE  PATIENT_ID=? AND VISIT_ID=? AND DEP_ID=? AND IN_ICU_TIMES=?";
        private static readonly string MED_PAT_INICU_INFORMATION_Select_OLE = "SELECT PATIENT_ID,VISIT_ID,DEP_ID,IN_ICU_TIMES,IN_ICU_DATETIME,OUT_ICU_DATETIME,DIAGNOSE,BED_NO,DOCTOR,BODY_WEIGHT,BODY_HEIGHT,WARD_CODE,COMMIT_STATUS,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08,RESERVED09,RESERVED10,RESERVED11,RESERVED12,RESERVED13,RESERVED14,RESERVED15,RESERVED16,RESERVED17,RESERVED18,RESERVED19,RESERVED20 FROM MED_PAT_INICU_INFORMATION where  PATIENT_ID=? AND VISIT_ID=? AND DEP_ID=? AND IN_ICU_TIMES=?";
        private static readonly string MED_PAT_INICU_INFORMATION_Select_ALL_OLE = "SELECT PATIENT_ID,VISIT_ID,DEP_ID,IN_ICU_TIMES,IN_ICU_DATETIME,OUT_ICU_DATETIME,DIAGNOSE,BED_NO,DOCTOR,BODY_WEIGHT,BODY_HEIGHT,WARD_CODE,COMMIT_STATUS,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08,RESERVED09,RESERVED10,RESERVED11,RESERVED12,RESERVED13,RESERVED14,RESERVED15,RESERVED16,RESERVED17,RESERVED18,RESERVED19,RESERVED20 FROM MED_PAT_INICU_INFORMATION";

        private static readonly string MED_PAT_INICU_INFORMATION_Insert_ODBC = "INSERT INTO MED_PAT_INICU_INFORMATION (PATIENT_ID,VISIT_ID,DEP_ID,IN_ICU_TIMES,IN_ICU_DATETIME,OUT_ICU_DATETIME,DIAGNOSE,BED_NO,DOCTOR,BODY_WEIGHT,BODY_HEIGHT,WARD_CODE,COMMIT_STATUS,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08,RESERVED09,RESERVED10,RESERVED11,RESERVED12,RESERVED13,RESERVED14,RESERVED15,RESERVED16,RESERVED17,RESERVED18,RESERVED19,RESERVED20) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_PAT_INICU_INFORMATION_Update_ODBC = "UPDATE MED_PAT_INICU_INFORMATION SET PATIENT_ID=?,VISIT_ID=?,DEP_ID=?,IN_ICU_TIMES=?,IN_ICU_DATETIME=?,OUT_ICU_DATETIME=?,DIAGNOSE=?,BED_NO=?,DOCTOR=?,BODY_WEIGHT=?,BODY_HEIGHT=?,WARD_CODE=?,COMMIT_STATUS=?,RESERVED01=?,RESERVED02=?,RESERVED03=?,RESERVED04=?,RESERVED05=?,RESERVED06=?,RESERVED07=?,RESERVED08=?,RESERVED09=?,RESERVED10=?,RESERVED11=?,RESERVED12=?,RESERVED13=?,RESERVED14=?,RESERVED15=?,RESERVED16=?,RESERVED17=?,RESERVED18=?,RESERVED19=?,RESERVED20=? WHERE  PATIENT_ID=? AND VISIT_ID=? AND DEP_ID=? AND IN_ICU_TIMES=?";
        private static readonly string MED_PAT_INICU_INFORMATION_Delete_ODBC = "DELETE MED_PAT_INICU_INFORMATION WHERE  PATIENT_ID=? AND VISIT_ID=? AND DEP_ID=? AND IN_ICU_TIMES=?";
        private static readonly string MED_PAT_INICU_INFORMATION_Select_ODBC = "SELECT PATIENT_ID,VISIT_ID,DEP_ID,IN_ICU_TIMES,IN_ICU_DATETIME,OUT_ICU_DATETIME,DIAGNOSE,BED_NO,DOCTOR,BODY_WEIGHT,BODY_HEIGHT,WARD_CODE,COMMIT_STATUS,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08,RESERVED09,RESERVED10,RESERVED11,RESERVED12,RESERVED13,RESERVED14,RESERVED15,RESERVED16,RESERVED17,RESERVED18,RESERVED19,RESERVED20 FROM MED_PAT_INICU_INFORMATION where  PATIENT_ID=? AND VISIT_ID=? AND DEP_ID=? AND IN_ICU_TIMES=?";
        private static readonly string MED_PAT_INICU_INFORMATION_Select_ALL_ODBC = "SELECT PATIENT_ID,VISIT_ID,DEP_ID,IN_ICU_TIMES,IN_ICU_DATETIME,OUT_ICU_DATETIME,DIAGNOSE,BED_NO,DOCTOR,BODY_WEIGHT,BODY_HEIGHT,WARD_CODE,COMMIT_STATUS,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08,RESERVED09,RESERVED10,RESERVED11,RESERVED12,RESERVED13,RESERVED14,RESERVED15,RESERVED16,RESERVED17,RESERVED18,RESERVED19,RESERVED20 FROM MED_PAT_INICU_INFORMATION";


        #region [获取参数OLEDB]
        /// <summary>
        ///获取参数MedPatInicuInformation SQL
        /// </summary>
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedPatInicuInformation")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("DepId",OleDbType.Decimal),
							new OleDbParameter("InIcuTimes",OleDbType.Decimal),
							new OleDbParameter("InIcuDatetime",OleDbType.DBTimeStamp),
							new OleDbParameter("OutIcuDatetime",OleDbType.DBTimeStamp),
							new OleDbParameter("Diagnose",OleDbType.VarChar),
							new OleDbParameter("BedNo",OleDbType.VarChar),
							new OleDbParameter("Doctor",OleDbType.VarChar),
							new OleDbParameter("BodyWeight",OleDbType.Decimal),
							new OleDbParameter("BodyHeight",OleDbType.Decimal),
							new OleDbParameter("WardCode",OleDbType.VarChar),
							new OleDbParameter("CommitStatus",OleDbType.VarChar),
							new OleDbParameter("Reserved01",OleDbType.VarChar),
							new OleDbParameter("Reserved02",OleDbType.VarChar),
							new OleDbParameter("Reserved03",OleDbType.VarChar),
							new OleDbParameter("Reserved04",OleDbType.VarChar),
							new OleDbParameter("Reserved05",OleDbType.VarChar),
							new OleDbParameter("Reserved06",OleDbType.VarChar),
							new OleDbParameter("Reserved07",OleDbType.VarChar),
							new OleDbParameter("Reserved08",OleDbType.VarChar),
							new OleDbParameter("Reserved09",OleDbType.VarChar),
							new OleDbParameter("Reserved10",OleDbType.VarChar),
							new OleDbParameter("Reserved11",OleDbType.VarChar),
							new OleDbParameter("Reserved12",OleDbType.VarChar),
							new OleDbParameter("Reserved13",OleDbType.VarChar),
							new OleDbParameter("Reserved14",OleDbType.VarChar),
							new OleDbParameter("Reserved15",OleDbType.VarChar),
							new OleDbParameter("Reserved16",OleDbType.VarChar),
							new OleDbParameter("Reserved17",OleDbType.VarChar),
							new OleDbParameter("Reserved18",OleDbType.VarChar),
							new OleDbParameter("Reserved19",OleDbType.VarChar),
							new OleDbParameter("Reserved20",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedPatInicuInformation")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("DepId",OleDbType.Decimal),
							new OleDbParameter("InIcuTimes",OleDbType.Decimal),
							new OleDbParameter("InIcuDatetime",OleDbType.DBTimeStamp),
							new OleDbParameter("OutIcuDatetime",OleDbType.DBTimeStamp),
							new OleDbParameter("Diagnose",OleDbType.VarChar),
							new OleDbParameter("BedNo",OleDbType.VarChar),
							new OleDbParameter("Doctor",OleDbType.VarChar),
							new OleDbParameter("BodyWeight",OleDbType.Decimal),
							new OleDbParameter("BodyHeight",OleDbType.Decimal),
							new OleDbParameter("WardCode",OleDbType.VarChar),
							new OleDbParameter("CommitStatus",OleDbType.VarChar),
							new OleDbParameter("Reserved01",OleDbType.VarChar),
							new OleDbParameter("Reserved02",OleDbType.VarChar),
							new OleDbParameter("Reserved03",OleDbType.VarChar),
							new OleDbParameter("Reserved04",OleDbType.VarChar),
							new OleDbParameter("Reserved05",OleDbType.VarChar),
							new OleDbParameter("Reserved06",OleDbType.VarChar),
							new OleDbParameter("Reserved07",OleDbType.VarChar),
							new OleDbParameter("Reserved08",OleDbType.VarChar),
							new OleDbParameter("Reserved09",OleDbType.VarChar),
							new OleDbParameter("Reserved10",OleDbType.VarChar),
							new OleDbParameter("Reserved11",OleDbType.VarChar),
							new OleDbParameter("Reserved12",OleDbType.VarChar),
							new OleDbParameter("Reserved13",OleDbType.VarChar),
							new OleDbParameter("Reserved14",OleDbType.VarChar),
							new OleDbParameter("Reserved15",OleDbType.VarChar),
							new OleDbParameter("Reserved16",OleDbType.VarChar),
							new OleDbParameter("Reserved17",OleDbType.VarChar),
							new OleDbParameter("Reserved18",OleDbType.VarChar),
							new OleDbParameter("Reserved19",OleDbType.VarChar),
							new OleDbParameter("Reserved20",OleDbType.VarChar),
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("DepId",OleDbType.Decimal),
							new OleDbParameter("InIcuTimes",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedPatInicuInformation")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("DepId",OleDbType.Decimal),
							new OleDbParameter("InIcuTimes",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedPatInicuInformation")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("DepId",OleDbType.Decimal),
							new OleDbParameter("InIcuTimes",OleDbType.Decimal),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录OLEDB]
        /// <summary>
        ///Add    model  MedPatInicuInformation 
        ///Insert Table MED_PAT_INICU_INFORMATION
        /// </summary>
        public int InsertMedPatInicuInformationOLE(MedPatInicuInformation model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedPatInicuInformation");
                if (model.PatientId != null)
                    oneInert[0].Value = model.PatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneInert[1].Value = model.VisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.DepId.ToString() != null)
                    oneInert[2].Value = model.DepId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.InIcuTimes.ToString() != null)
                    oneInert[3].Value = model.InIcuTimes;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.InIcuDatetime > DateTime.MinValue)
                    oneInert[4].Value = model.InIcuDatetime;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.OutIcuDatetime > DateTime.MinValue)
                    oneInert[5].Value = model.OutIcuDatetime;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.Diagnose != null)
                    oneInert[6].Value = model.Diagnose;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneInert[7].Value = model.BedNo;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.Doctor != null)
                    oneInert[8].Value = model.Doctor;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.BodyWeight.ToString() != null)
                    oneInert[9].Value = model.BodyWeight;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.BodyHeight.ToString() != null)
                    oneInert[10].Value = model.BodyHeight;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneInert[11].Value = model.WardCode;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.CommitStatus != null)
                    oneInert[12].Value = model.CommitStatus;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneInert[13].Value = model.Reserved01;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneInert[14].Value = model.Reserved02;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneInert[15].Value = model.Reserved03;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.Reserved04 != null)
                    oneInert[16].Value = model.Reserved04;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.Reserved05 != null)
                    oneInert[17].Value = model.Reserved05;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.Reserved06 != null)
                    oneInert[18].Value = model.Reserved06;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.Reserved07 != null)
                    oneInert[19].Value = model.Reserved07;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.Reserved08 != null)
                    oneInert[20].Value = model.Reserved08;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.Reserved09 != null)
                    oneInert[21].Value = model.Reserved09;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.Reserved10 != null)
                    oneInert[22].Value = model.Reserved10;
                else
                    oneInert[22].Value = DBNull.Value;
                if (model.Reserved11 != null)
                    oneInert[23].Value = model.Reserved11;
                else
                    oneInert[23].Value = DBNull.Value;
                if (model.Reserved12 != null)
                    oneInert[24].Value = model.Reserved12;
                else
                    oneInert[24].Value = DBNull.Value;
                if (model.Reserved13 != null)
                    oneInert[25].Value = model.Reserved13;
                else
                    oneInert[25].Value = DBNull.Value;
                if (model.Reserved14 != null)
                    oneInert[26].Value = model.Reserved14;
                else
                    oneInert[26].Value = DBNull.Value;
                if (model.Reserved15 != null)
                    oneInert[27].Value = model.Reserved15;
                else
                    oneInert[27].Value = DBNull.Value;
                if (model.Reserved16 != null)
                    oneInert[28].Value = model.Reserved16;
                else
                    oneInert[28].Value = DBNull.Value;
                if (model.Reserved17 != null)
                    oneInert[29].Value = model.Reserved17;
                else
                    oneInert[29].Value = DBNull.Value;
                if (model.Reserved18 != null)
                    oneInert[30].Value = model.Reserved18;
                else
                    oneInert[30].Value = DBNull.Value;
                if (model.Reserved19 != null)
                    oneInert[31].Value = model.Reserved19;
                else
                    oneInert[31].Value = DBNull.Value;
                if (model.Reserved20 != null)
                    oneInert[32].Value = model.Reserved20;
                else
                    oneInert[32].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, MED_PAT_INICU_INFORMATION_Insert_OLE, oneInert);
            }
        }
        #endregion
        #region [更新一条记录OLEDB]
        /// <summary>
        ///Update    model  MedPatInicuInformation 
        ///Update Table     MED_PAT_INICU_INFORMATION
        /// </summary>
        public int UpdateMedPatInicuInformationOLE(MedPatInicuInformation model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedPatInicuInformation");
                if (model.PatientId != null)
                    oneUpdate[0].Value = model.PatientId;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneUpdate[1].Value = model.VisitId;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.DepId.ToString() != null)
                    oneUpdate[2].Value = model.DepId;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.InIcuTimes.ToString() != null)
                    oneUpdate[3].Value = model.InIcuTimes;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.InIcuDatetime > DateTime.MinValue)
                    oneUpdate[4].Value = model.InIcuDatetime;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.OutIcuDatetime > DateTime.MinValue)
                    oneUpdate[5].Value = model.OutIcuDatetime;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.Diagnose != null)
                    oneUpdate[6].Value = model.Diagnose;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneUpdate[7].Value = model.BedNo;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.Doctor != null)
                    oneUpdate[8].Value = model.Doctor;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.BodyWeight.ToString() != null)
                    oneUpdate[9].Value = model.BodyWeight;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.BodyHeight.ToString() != null)
                    oneUpdate[10].Value = model.BodyHeight;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneUpdate[11].Value = model.WardCode;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.CommitStatus != null)
                    oneUpdate[12].Value = model.CommitStatus;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneUpdate[13].Value = model.Reserved01;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneUpdate[14].Value = model.Reserved02;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneUpdate[15].Value = model.Reserved03;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.Reserved04 != null)
                    oneUpdate[16].Value = model.Reserved04;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.Reserved05 != null)
                    oneUpdate[17].Value = model.Reserved05;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.Reserved06 != null)
                    oneUpdate[18].Value = model.Reserved06;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.Reserved07 != null)
                    oneUpdate[19].Value = model.Reserved07;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.Reserved08 != null)
                    oneUpdate[20].Value = model.Reserved08;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.Reserved09 != null)
                    oneUpdate[21].Value = model.Reserved09;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.Reserved10 != null)
                    oneUpdate[22].Value = model.Reserved10;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.Reserved11 != null)
                    oneUpdate[23].Value = model.Reserved11;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.Reserved12 != null)
                    oneUpdate[24].Value = model.Reserved12;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.Reserved13 != null)
                    oneUpdate[25].Value = model.Reserved13;
                else
                    oneUpdate[25].Value = DBNull.Value;
                if (model.Reserved14 != null)
                    oneUpdate[26].Value = model.Reserved14;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (model.Reserved15 != null)
                    oneUpdate[27].Value = model.Reserved15;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (model.Reserved16 != null)
                    oneUpdate[28].Value = model.Reserved16;
                else
                    oneUpdate[28].Value = DBNull.Value;
                if (model.Reserved17 != null)
                    oneUpdate[29].Value = model.Reserved17;
                else
                    oneUpdate[29].Value = DBNull.Value;
                if (model.Reserved18 != null)
                    oneUpdate[30].Value = model.Reserved18;
                else
                    oneUpdate[30].Value = DBNull.Value;
                if (model.Reserved19 != null)
                    oneUpdate[31].Value = model.Reserved19;
                else
                    oneUpdate[31].Value = DBNull.Value;
                if (model.Reserved20 != null)
                    oneUpdate[32].Value = model.Reserved20;
                else
                    oneUpdate[32].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[33].Value = model.PatientId;
                else
                    oneUpdate[33].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneUpdate[34].Value = model.VisitId;
                else
                    oneUpdate[34].Value = DBNull.Value;
                if (model.DepId.ToString() != null)
                    oneUpdate[35].Value = model.DepId;
                else
                    oneUpdate[35].Value = DBNull.Value;
                if (model.InIcuTimes.ToString() != null)
                    oneUpdate[36].Value = model.InIcuTimes;
                else
                    oneUpdate[36].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, MED_PAT_INICU_INFORMATION_Update_OLE, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录OLEDB]
        /// <summary>
        ///Delete    model  MedPatInicuInformation 
        ///Delete Table MED_PAT_INICU_INFORMATION by (string PATIENT_ID,decimal VISIT_ID,decimal DEP_ID,decimal IN_ICU_TIMES)
        /// </summary>
        public int DeleteMedPatInicuInformationOLE(string PATIENT_ID, decimal VISIT_ID, decimal DEP_ID, decimal IN_ICU_TIMES)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(SqlHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedPatInicuInformation");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (VISIT_ID.ToString() != null)
                    oneDelete[1].Value = VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (DEP_ID.ToString() != null)
                    oneDelete[2].Value = DEP_ID;
                else
                    oneDelete[2].Value = DBNull.Value;
                if (IN_ICU_TIMES.ToString() != null)
                    oneDelete[3].Value = IN_ICU_TIMES;
                else
                    oneDelete[3].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, MED_PAT_INICU_INFORMATION_Delete_OLE, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录OLEDB]
        /// <summary>
        ///Select    model  MedPatInicuInformation 
        ///select Table MED_PAT_INICU_INFORMATION by (string PATIENT_ID,decimal VISIT_ID,decimal DEP_ID,decimal IN_ICU_TIMES)
        /// </summary>
        public MedPatInicuInformation SelectMedPatInicuInformationOLE(string PATIENT_ID, decimal VISIT_ID, decimal DEP_ID, decimal IN_ICU_TIMES)
        {
            MedPatInicuInformation model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedPatInicuInformation");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = DEP_ID;
            parameterValues[3].Value = IN_ICU_TIMES;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_PAT_INICU_INFORMATION_Select_OLE, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPatInicuInformation();
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
                        model.DepId = decimal.Parse(oleReader["DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.InIcuTimes = decimal.Parse(oleReader["IN_ICU_TIMES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.InIcuDatetime = DateTime.Parse(oleReader["IN_ICU_DATETIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OutIcuDatetime = DateTime.Parse(oleReader["OUT_ICU_DATETIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Diagnose = oleReader["DIAGNOSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Doctor = oleReader["DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.BodyWeight = decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.BodyHeight = decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.CommitStatus = oleReader["COMMIT_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.Reserved06 = oleReader["RESERVED06"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.Reserved07 = oleReader["RESERVED07"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.Reserved08 = oleReader["RESERVED08"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.Reserved09 = oleReader["RESERVED09"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Reserved10 = oleReader["RESERVED10"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Reserved11 = oleReader["RESERVED11"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.Reserved12 = oleReader["RESERVED12"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Reserved13 = oleReader["RESERVED13"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Reserved14 = oleReader["RESERVED14"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.Reserved15 = oleReader["RESERVED15"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.Reserved16 = oleReader["RESERVED16"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.Reserved17 = oleReader["RESERVED17"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.Reserved18 = oleReader["RESERVED18"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.Reserved19 = oleReader["RESERVED19"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.Reserved20 = oleReader["RESERVED20"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        #region  [获取所有记录OLEDB]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedPatInicuInformation> SelectMedPatInicuInformationListOLE()
        {
            List<MedPatInicuInformation> modelList = new List<MedPatInicuInformation>();
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_PAT_INICU_INFORMATION_Select_ALL_OLE, null))
            {
                while (oleReader.Read())
                {
                    MedPatInicuInformation model = new MedPatInicuInformation();
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
                        model.DepId = decimal.Parse(oleReader["DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.InIcuTimes = decimal.Parse(oleReader["IN_ICU_TIMES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.InIcuDatetime = DateTime.Parse(oleReader["IN_ICU_DATETIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OutIcuDatetime = DateTime.Parse(oleReader["OUT_ICU_DATETIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Diagnose = oleReader["DIAGNOSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Doctor = oleReader["DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.BodyWeight = decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.BodyHeight = decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.CommitStatus = oleReader["COMMIT_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.Reserved06 = oleReader["RESERVED06"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.Reserved07 = oleReader["RESERVED07"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.Reserved08 = oleReader["RESERVED08"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.Reserved09 = oleReader["RESERVED09"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Reserved10 = oleReader["RESERVED10"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Reserved11 = oleReader["RESERVED11"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.Reserved12 = oleReader["RESERVED12"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Reserved13 = oleReader["RESERVED13"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Reserved14 = oleReader["RESERVED14"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.Reserved15 = oleReader["RESERVED15"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.Reserved16 = oleReader["RESERVED16"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.Reserved17 = oleReader["RESERVED17"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.Reserved18 = oleReader["RESERVED18"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.Reserved19 = oleReader["RESERVED19"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.Reserved20 = oleReader["RESERVED20"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region [获取参数ODBC]
        /// <summary>
        ///获取参数MedPatInicuInformation
        /// </summary>
        public static OdbcParameter[] GetParameterODBC(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedPatInicuInformation")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("DepId",OdbcType.Decimal),
							new OdbcParameter("InIcuTimes",OdbcType.Decimal),
							new OdbcParameter("InIcuDatetime",OdbcType.DateTime),
							new OdbcParameter("OutIcuDatetime",OdbcType.DateTime),
							new OdbcParameter("Diagnose",OdbcType.VarChar),
							new OdbcParameter("BedNo",OdbcType.VarChar),
							new OdbcParameter("Doctor",OdbcType.VarChar),
							new OdbcParameter("BodyWeight",OdbcType.Decimal),
							new OdbcParameter("BodyHeight",OdbcType.Decimal),
							new OdbcParameter("WardCode",OdbcType.VarChar),
							new OdbcParameter("CommitStatus",OdbcType.VarChar),
							new OdbcParameter("Reserved01",OdbcType.VarChar),
							new OdbcParameter("Reserved02",OdbcType.VarChar),
							new OdbcParameter("Reserved03",OdbcType.VarChar),
							new OdbcParameter("Reserved04",OdbcType.VarChar),
							new OdbcParameter("Reserved05",OdbcType.VarChar),
							new OdbcParameter("Reserved06",OdbcType.VarChar),
							new OdbcParameter("Reserved07",OdbcType.VarChar),
							new OdbcParameter("Reserved08",OdbcType.VarChar),
							new OdbcParameter("Reserved09",OdbcType.VarChar),
							new OdbcParameter("Reserved10",OdbcType.VarChar),
							new OdbcParameter("Reserved11",OdbcType.VarChar),
							new OdbcParameter("Reserved12",OdbcType.VarChar),
							new OdbcParameter("Reserved13",OdbcType.VarChar),
							new OdbcParameter("Reserved14",OdbcType.VarChar),
							new OdbcParameter("Reserved15",OdbcType.VarChar),
							new OdbcParameter("Reserved16",OdbcType.VarChar),
							new OdbcParameter("Reserved17",OdbcType.VarChar),
							new OdbcParameter("Reserved18",OdbcType.VarChar),
							new OdbcParameter("Reserved19",OdbcType.VarChar),
							new OdbcParameter("Reserved20",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedPatInicuInformation")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("DepId",OdbcType.Decimal),
							new OdbcParameter("InIcuTimes",OdbcType.Decimal),
							new OdbcParameter("InIcuDatetime",OdbcType.DateTime),
							new OdbcParameter("OutIcuDatetime",OdbcType.DateTime),
							new OdbcParameter("Diagnose",OdbcType.VarChar),
							new OdbcParameter("BedNo",OdbcType.VarChar),
							new OdbcParameter("Doctor",OdbcType.VarChar),
							new OdbcParameter("BodyWeight",OdbcType.Decimal),
							new OdbcParameter("BodyHeight",OdbcType.Decimal),
							new OdbcParameter("WardCode",OdbcType.VarChar),
							new OdbcParameter("CommitStatus",OdbcType.VarChar),
							new OdbcParameter("Reserved01",OdbcType.VarChar),
							new OdbcParameter("Reserved02",OdbcType.VarChar),
							new OdbcParameter("Reserved03",OdbcType.VarChar),
							new OdbcParameter("Reserved04",OdbcType.VarChar),
							new OdbcParameter("Reserved05",OdbcType.VarChar),
							new OdbcParameter("Reserved06",OdbcType.VarChar),
							new OdbcParameter("Reserved07",OdbcType.VarChar),
							new OdbcParameter("Reserved08",OdbcType.VarChar),
							new OdbcParameter("Reserved09",OdbcType.VarChar),
							new OdbcParameter("Reserved10",OdbcType.VarChar),
							new OdbcParameter("Reserved11",OdbcType.VarChar),
							new OdbcParameter("Reserved12",OdbcType.VarChar),
							new OdbcParameter("Reserved13",OdbcType.VarChar),
							new OdbcParameter("Reserved14",OdbcType.VarChar),
							new OdbcParameter("Reserved15",OdbcType.VarChar),
							new OdbcParameter("Reserved16",OdbcType.VarChar),
							new OdbcParameter("Reserved17",OdbcType.VarChar),
							new OdbcParameter("Reserved18",OdbcType.VarChar),
							new OdbcParameter("Reserved19",OdbcType.VarChar),
							new OdbcParameter("Reserved20",OdbcType.VarChar),
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("DepId",OdbcType.Decimal),
							new OdbcParameter("InIcuTimes",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedPatInicuInformation")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("DepId",OdbcType.Decimal),
							new OdbcParameter("InIcuTimes",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedPatInicuInformation")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("DepId",OdbcType.Decimal),
							new OdbcParameter("InIcuTimes",OdbcType.Decimal),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录ODBC]
        /// <summary>
        ///Add    model  MedPatInicuInformation 
        ///Insert Table MED_PAT_INICU_INFORMATION
        /// </summary>
        public int InsertMedPatInicuInformationODBC(MedPatInicuInformation model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterODBC("InsertMedPatInicuInformation");
                if (model.PatientId != null)
                    oneInert[0].Value = model.PatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneInert[1].Value = model.VisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.DepId.ToString() != null)
                    oneInert[2].Value = model.DepId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.InIcuTimes.ToString() != null)
                    oneInert[3].Value = model.InIcuTimes;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.InIcuDatetime > DateTime.MinValue)
                    oneInert[4].Value = model.InIcuDatetime;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.OutIcuDatetime > DateTime.MinValue)
                    oneInert[5].Value = model.OutIcuDatetime;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.Diagnose != null)
                    oneInert[6].Value = model.Diagnose;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneInert[7].Value = model.BedNo;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.Doctor != null)
                    oneInert[8].Value = model.Doctor;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.BodyWeight.ToString() != null)
                    oneInert[9].Value = model.BodyWeight;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.BodyHeight.ToString() != null)
                    oneInert[10].Value = model.BodyHeight;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneInert[11].Value = model.WardCode;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.CommitStatus != null)
                    oneInert[12].Value = model.CommitStatus;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneInert[13].Value = model.Reserved01;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneInert[14].Value = model.Reserved02;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneInert[15].Value = model.Reserved03;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.Reserved04 != null)
                    oneInert[16].Value = model.Reserved04;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.Reserved05 != null)
                    oneInert[17].Value = model.Reserved05;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.Reserved06 != null)
                    oneInert[18].Value = model.Reserved06;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.Reserved07 != null)
                    oneInert[19].Value = model.Reserved07;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.Reserved08 != null)
                    oneInert[20].Value = model.Reserved08;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.Reserved09 != null)
                    oneInert[21].Value = model.Reserved09;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.Reserved10 != null)
                    oneInert[22].Value = model.Reserved10;
                else
                    oneInert[22].Value = DBNull.Value;
                if (model.Reserved11 != null)
                    oneInert[23].Value = model.Reserved11;
                else
                    oneInert[23].Value = DBNull.Value;
                if (model.Reserved12 != null)
                    oneInert[24].Value = model.Reserved12;
                else
                    oneInert[24].Value = DBNull.Value;
                if (model.Reserved13 != null)
                    oneInert[25].Value = model.Reserved13;
                else
                    oneInert[25].Value = DBNull.Value;
                if (model.Reserved14 != null)
                    oneInert[26].Value = model.Reserved14;
                else
                    oneInert[26].Value = DBNull.Value;
                if (model.Reserved15 != null)
                    oneInert[27].Value = model.Reserved15;
                else
                    oneInert[27].Value = DBNull.Value;
                if (model.Reserved16 != null)
                    oneInert[28].Value = model.Reserved16;
                else
                    oneInert[28].Value = DBNull.Value;
                if (model.Reserved17 != null)
                    oneInert[29].Value = model.Reserved17;
                else
                    oneInert[29].Value = DBNull.Value;
                if (model.Reserved18 != null)
                    oneInert[30].Value = model.Reserved18;
                else
                    oneInert[30].Value = DBNull.Value;
                if (model.Reserved19 != null)
                    oneInert[31].Value = model.Reserved19;
                else
                    oneInert[31].Value = DBNull.Value;
                if (model.Reserved20 != null)
                    oneInert[32].Value = model.Reserved20;
                else
                    oneInert[32].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, MED_PAT_INICU_INFORMATION_Insert_ODBC, oneInert);
            }
        }
        #endregion
        #region [更新一条记录ODBC]
        /// <summary>
        ///Update    model  MedPatInicuInformation 
        ///Update Table     MED_PAT_INICU_INFORMATION
        /// </summary>
        public int UpdateMedPatInicuInformationODBC(MedPatInicuInformation model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterODBC("UpdateMedPatInicuInformation");
                if (model.PatientId != null)
                    oneUpdate[0].Value = model.PatientId;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneUpdate[1].Value = model.VisitId;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.DepId.ToString() != null)
                    oneUpdate[2].Value = model.DepId;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.InIcuTimes.ToString() != null)
                    oneUpdate[3].Value = model.InIcuTimes;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.InIcuDatetime > DateTime.MinValue)
                    oneUpdate[4].Value = model.InIcuDatetime;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.OutIcuDatetime > DateTime.MinValue)
                    oneUpdate[5].Value = model.OutIcuDatetime;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.Diagnose != null)
                    oneUpdate[6].Value = model.Diagnose;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.BedNo != null)
                    oneUpdate[7].Value = model.BedNo;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.Doctor != null)
                    oneUpdate[8].Value = model.Doctor;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.BodyWeight.ToString() != null)
                    oneUpdate[9].Value = model.BodyWeight;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.BodyHeight.ToString() != null)
                    oneUpdate[10].Value = model.BodyHeight;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.WardCode != null)
                    oneUpdate[11].Value = model.WardCode;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.CommitStatus != null)
                    oneUpdate[12].Value = model.CommitStatus;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneUpdate[13].Value = model.Reserved01;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneUpdate[14].Value = model.Reserved02;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneUpdate[15].Value = model.Reserved03;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.Reserved04 != null)
                    oneUpdate[16].Value = model.Reserved04;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.Reserved05 != null)
                    oneUpdate[17].Value = model.Reserved05;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.Reserved06 != null)
                    oneUpdate[18].Value = model.Reserved06;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.Reserved07 != null)
                    oneUpdate[19].Value = model.Reserved07;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.Reserved08 != null)
                    oneUpdate[20].Value = model.Reserved08;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.Reserved09 != null)
                    oneUpdate[21].Value = model.Reserved09;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.Reserved10 != null)
                    oneUpdate[22].Value = model.Reserved10;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.Reserved11 != null)
                    oneUpdate[23].Value = model.Reserved11;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.Reserved12 != null)
                    oneUpdate[24].Value = model.Reserved12;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.Reserved13 != null)
                    oneUpdate[25].Value = model.Reserved13;
                else
                    oneUpdate[25].Value = DBNull.Value;
                if (model.Reserved14 != null)
                    oneUpdate[26].Value = model.Reserved14;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (model.Reserved15 != null)
                    oneUpdate[27].Value = model.Reserved15;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (model.Reserved16 != null)
                    oneUpdate[28].Value = model.Reserved16;
                else
                    oneUpdate[28].Value = DBNull.Value;
                if (model.Reserved17 != null)
                    oneUpdate[29].Value = model.Reserved17;
                else
                    oneUpdate[29].Value = DBNull.Value;
                if (model.Reserved18 != null)
                    oneUpdate[30].Value = model.Reserved18;
                else
                    oneUpdate[30].Value = DBNull.Value;
                if (model.Reserved19 != null)
                    oneUpdate[31].Value = model.Reserved19;
                else
                    oneUpdate[31].Value = DBNull.Value;
                if (model.Reserved20 != null)
                    oneUpdate[32].Value = model.Reserved20;
                else
                    oneUpdate[32].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[33].Value = model.PatientId;
                else
                    oneUpdate[33].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneUpdate[34].Value = model.VisitId;
                else
                    oneUpdate[34].Value = DBNull.Value;
                if (model.DepId.ToString() != null)
                    oneUpdate[35].Value = model.DepId;
                else
                    oneUpdate[35].Value = DBNull.Value;
                if (model.InIcuTimes.ToString() != null)
                    oneUpdate[36].Value = model.InIcuTimes;
                else
                    oneUpdate[36].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, MED_PAT_INICU_INFORMATION_Update_ODBC, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录ODBC]
        /// <summary>
        ///Delete    model  MedPatInicuInformation 
        ///Delete Table MED_PAT_INICU_INFORMATION by (string PATIENT_ID,decimal VISIT_ID,decimal DEP_ID,decimal IN_ICU_TIMES)
        /// </summary>
        public int DeleteMedPatInicuInformationODBC(string PATIENT_ID, decimal VISIT_ID, decimal DEP_ID, decimal IN_ICU_TIMES)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterODBC("DeleteMedPatInicuInformation");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (VISIT_ID.ToString() != null)
                    oneDelete[1].Value = VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (DEP_ID.ToString() != null)
                    oneDelete[2].Value = DEP_ID;
                else
                    oneDelete[2].Value = DBNull.Value;
                if (IN_ICU_TIMES.ToString() != null)
                    oneDelete[3].Value = IN_ICU_TIMES;
                else
                    oneDelete[3].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, MED_PAT_INICU_INFORMATION_Delete_ODBC, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录ODBC]
        /// <summary>
        ///Select    model  MedPatInicuInformation 
        ///select Table MED_PAT_INICU_INFORMATION by (string PATIENT_ID,decimal VISIT_ID,decimal DEP_ID,decimal IN_ICU_TIMES)
        /// </summary>
        public MedPatInicuInformation SelectMedPatInicuInformationODBC(string PATIENT_ID, decimal VISIT_ID, decimal DEP_ID, decimal IN_ICU_TIMES)
        {
            MedPatInicuInformation model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedPatInicuInformation");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = DEP_ID;
            parameterValues[3].Value = IN_ICU_TIMES;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_PAT_INICU_INFORMATION_Select_ODBC, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPatInicuInformation();
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
                        model.DepId = decimal.Parse(oleReader["DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.InIcuTimes = decimal.Parse(oleReader["IN_ICU_TIMES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.InIcuDatetime = DateTime.Parse(oleReader["IN_ICU_DATETIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OutIcuDatetime = DateTime.Parse(oleReader["OUT_ICU_DATETIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Diagnose = oleReader["DIAGNOSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Doctor = oleReader["DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.BodyWeight = decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.BodyHeight = decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.CommitStatus = oleReader["COMMIT_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.Reserved06 = oleReader["RESERVED06"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.Reserved07 = oleReader["RESERVED07"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.Reserved08 = oleReader["RESERVED08"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.Reserved09 = oleReader["RESERVED09"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Reserved10 = oleReader["RESERVED10"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Reserved11 = oleReader["RESERVED11"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.Reserved12 = oleReader["RESERVED12"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Reserved13 = oleReader["RESERVED13"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Reserved14 = oleReader["RESERVED14"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.Reserved15 = oleReader["RESERVED15"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.Reserved16 = oleReader["RESERVED16"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.Reserved17 = oleReader["RESERVED17"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.Reserved18 = oleReader["RESERVED18"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.Reserved19 = oleReader["RESERVED19"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.Reserved20 = oleReader["RESERVED20"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        #region  [获取所有记录ODBC]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedPatInicuInformation> SelectMedPatInicuInformationListODBC()
        {
            List<MedPatInicuInformation> modelList = new List<MedPatInicuInformation>();
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_PAT_INICU_INFORMATION_Select_ALL_ODBC, null))
            {
                while (oleReader.Read())
                {
                    MedPatInicuInformation model = new MedPatInicuInformation();
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
                        model.DepId = decimal.Parse(oleReader["DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.InIcuTimes = decimal.Parse(oleReader["IN_ICU_TIMES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.InIcuDatetime = DateTime.Parse(oleReader["IN_ICU_DATETIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OutIcuDatetime = DateTime.Parse(oleReader["OUT_ICU_DATETIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Diagnose = oleReader["DIAGNOSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.BedNo = oleReader["BED_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Doctor = oleReader["DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.BodyWeight = decimal.Parse(oleReader["BODY_WEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.BodyHeight = decimal.Parse(oleReader["BODY_HEIGHT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.WardCode = oleReader["WARD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.CommitStatus = oleReader["COMMIT_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.Reserved06 = oleReader["RESERVED06"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.Reserved07 = oleReader["RESERVED07"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.Reserved08 = oleReader["RESERVED08"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.Reserved09 = oleReader["RESERVED09"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.Reserved10 = oleReader["RESERVED10"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Reserved11 = oleReader["RESERVED11"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.Reserved12 = oleReader["RESERVED12"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Reserved13 = oleReader["RESERVED13"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Reserved14 = oleReader["RESERVED14"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.Reserved15 = oleReader["RESERVED15"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.Reserved16 = oleReader["RESERVED16"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.Reserved17 = oleReader["RESERVED17"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.Reserved18 = oleReader["RESERVED18"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.Reserved19 = oleReader["RESERVED19"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.Reserved20 = oleReader["RESERVED20"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
    }
}
