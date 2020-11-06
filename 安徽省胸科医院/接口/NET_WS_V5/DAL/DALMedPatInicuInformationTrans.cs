

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
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedPatInicuInformation
    /// </summary>

    public partial class DALMedPatInicuInformation
    {

        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedPatInicuInformation 
        ///Insert Table MED_PAT_INICU_INFORMATION
        /// </summary>
        public int InsertMedPatInicuInformationSQL(MedPatInicuInformation model, System.Data.Common.DbTransaction oleCisTrans)
        {
            SqlParameter[] oneInert = GetParameterSQL("InsertMedPatInicuInformation");
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

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_PAT_INICU_INFORMATION_Insert_SQL, oneInert);

        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedPatInicuInformation 
        ///Update Table     MED_PAT_INICU_INFORMATION
        /// </summary>
        public int UpdateMedPatInicuInformationSQL(MedPatInicuInformation model, System.Data.Common.DbTransaction oleCisTrans)
        {
            SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedPatInicuInformation");
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

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_PAT_INICU_INFORMATION_Update_SQL, oneUpdate);
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedPatInicuInformation 
        ///Delete Table MED_PAT_INICU_INFORMATION by (string PATIENT_ID,decimal VISIT_ID,decimal DEP_ID,decimal IN_ICU_TIMES)
        /// </summary>
        public int DeleteMedPatInicuInformationSQL(string PATIENT_ID, decimal VISIT_ID, decimal DEP_ID, decimal IN_ICU_TIMES, System.Data.Common.DbTransaction oleCisTrans)
        {
            SqlParameter[] oneDelete = GetParameterSQL("DeleteMedPatInicuInformation");
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

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_PAT_INICU_INFORMATION_Delete_SQL, oneDelete);

        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedPatInicuInformation 
        ///select Table MED_PAT_INICU_INFORMATION by (string PATIENT_ID,decimal VISIT_ID,decimal DEP_ID,decimal IN_ICU_TIMES)
        /// </summary>
        public MedPatInicuInformation SelectMedPatInicuInformationSQL(string PATIENT_ID, decimal VISIT_ID, decimal DEP_ID, decimal IN_ICU_TIMES, System.Data.Common.DbConnection oleCisConn)
        {
            MedPatInicuInformation model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedPatInicuInformation");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = DEP_ID;
            parameterValues[3].Value = IN_ICU_TIMES;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_PAT_INICU_INFORMATION_Select_SQL, parameterValues))
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
        #region  [获取所有记录SQL]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedPatInicuInformation> SelectMedPatInicuInformationListSQL(System.Data.Common.DbConnection oleCisConn)
        {
            List<MedPatInicuInformation> modelList = new List<MedPatInicuInformation>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_PAT_INICU_INFORMATION_Select_ALL_SQL, null))
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

        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedPatInicuInformation 
        ///Insert Table MED_PAT_INICU_INFORMATION
        /// </summary>
        public int InsertMedPatInicuInformation(MedPatInicuInformation model, System.Data.Common.DbTransaction oleCisTrans)
        {

            OracleParameter[] oneInert = GetParameter("InsertMedPatInicuInformation");
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

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_PAT_INICU_INFORMATION_Insert, oneInert);
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedPatInicuInformation 
        ///Update Table     MED_PAT_INICU_INFORMATION
        /// </summary>
        public int UpdateMedPatInicuInformation(MedPatInicuInformation model, System.Data.Common.DbTransaction oleCisTrans)
        {

            OracleParameter[] oneUpdate = GetParameter("UpdateMedPatInicuInformation");
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

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_PAT_INICU_INFORMATION_Update, oneUpdate);

        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedPatInicuInformation 
        ///Delete Table MED_PAT_INICU_INFORMATION by (string PATIENT_ID,decimal VISIT_ID,decimal DEP_ID,decimal IN_ICU_TIMES)
        /// </summary>
        public int DeleteMedPatInicuInformation(string PATIENT_ID, decimal VISIT_ID, decimal DEP_ID, decimal IN_ICU_TIMES, System.Data.Common.DbTransaction oleCisTrans)
        {
            OracleParameter[] oneDelete = GetParameter("DeleteMedPatInicuInformation");
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

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_PAT_INICU_INFORMATION_Delete, oneDelete);

        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedPatInicuInformation 
        ///select Table MED_PAT_INICU_INFORMATION by (string PATIENT_ID,decimal VISIT_ID,decimal DEP_ID,decimal IN_ICU_TIMES)
        /// </summary>
        public MedPatInicuInformation SelectMedPatInicuInformation(string PATIENT_ID, decimal VISIT_ID, decimal DEP_ID, decimal IN_ICU_TIMES, System.Data.Common.DbConnection oleCisConn)
        {
            MedPatInicuInformation model;
            OracleParameter[] parameterValues = GetParameter("SelectMedPatInicuInformation");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = DEP_ID;
            parameterValues[3].Value = IN_ICU_TIMES;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_PAT_INICU_INFORMATION_Select, parameterValues))
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
        #region  [获取所有记录]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedPatInicuInformation> SelectMedPatInicuInformationList(System.Data.Common.DbConnection oleCisConn)
        {
            List<MedPatInicuInformation> modelList = new List<MedPatInicuInformation>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_PAT_INICU_INFORMATION_Select_ALL, null))
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
