

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:22
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
    /// DAL MedPatMasterIndex
    /// </summary>

    public partial class DALMedPatMasterIndex
    {

        private static readonly string MED_PAT_MASTER_INDEX_Insert_SQL = "Insert into MED_PAT_MASTER_INDEX  (PATIENT_ID,NAME,NAME_PHONETIC,SEX,DATE_OF_BIRTH,BIRTH_PLACE,CITIZENSHIP,NATION,ID_NO,IDENTITY,UNIT_IN_CONTRACT,MAILING_ADDRESS,ZIP_CODE,PHONE_NUMBER_HOME,PHONE_NUMBER_BUSINESS,NEXT_OF_KIN,RELATIONSHIP,NEXT_OF_KIN_ADDR,NEXT_OF_KIN_ZIP_CODE,NEXT_OF_KIN_PHONE) values(@PatientId,@Name,@NamePhonetic,@Sex,@DateOfBirth,@BirthPlace,@Citizenship,@Nation,@IdNo,@Identity,@UnitInContract,@MailingAddress,@ZipCode,@PhoneNumberHome,@PhoneNumberBusiness,@NextOfKin,@Relationship,@NextOfKinAddr,@NextOfKinZipCode,@NextOfKinPhone)";
        private static readonly string MED_PAT_MASTER_INDEX_Update_SQL = "Update MED_PAT_MASTER_INDEX set NAME=@Name,NAME_PHONETIC=@NamePhonetic,SEX=@Sex,DATE_OF_BIRTH=@DateOfBirth,BIRTH_PLACE=@BirthPlace,CITIZENSHIP=@Citizenship,NATION=@Nation,ID_NO=@IdNo,IDENTITY=@Identity,UNIT_IN_CONTRACT=@UnitInContract,MAILING_ADDRESS=@MailingAddress,ZIP_CODE=@ZipCode,PHONE_NUMBER_HOME=@PhoneNumberHome,PHONE_NUMBER_BUSINESS=@PhoneNumberBusiness,NEXT_OF_KIN=@NextOfKin,RELATIONSHIP=@Relationship,NEXT_OF_KIN_ADDR=@NextOfKinAddr,NEXT_OF_KIN_ZIP_CODE=@NextOfKinZipCode,NEXT_OF_KIN_PHONE=@NextOfKinPhone where PATIENT_ID=@PatientId";
        private static readonly string MED_PAT_MASTER_INDEX_Delete_SQL = "Delete MED_PAT_MASTER_INDEX WHERE PATIENT_ID=@PatientId";
        private static readonly string MED_PAT_MASTER_INDEX_Select_SQL = "select PATIENT_ID,NAME,NAME_PHONETIC,SEX,DATE_OF_BIRTH,BIRTH_PLACE,CITIZENSHIP,NATION,ID_NO,IDENTITY,UNIT_IN_CONTRACT,MAILING_ADDRESS,ZIP_CODE,PHONE_NUMBER_HOME,PHONE_NUMBER_BUSINESS,NEXT_OF_KIN,RELATIONSHIP,NEXT_OF_KIN_ADDR,NEXT_OF_KIN_ZIP_CODE,NEXT_OF_KIN_PHONE from MED_PAT_MASTER_INDEX WHERE PATIENT_ID=@PatientId";
        private static readonly string MED_PAT_MASTER_INDEX_Select_ALL_SQL = "select PATIENT_ID,NAME,NAME_PHONETIC,SEX,DATE_OF_BIRTH,BIRTH_PLACE,CITIZENSHIP,NATION,ID_NO,IDENTITY,UNIT_IN_CONTRACT,MAILING_ADDRESS,ZIP_CODE,PHONE_NUMBER_HOME,PHONE_NUMBER_BUSINESS,NEXT_OF_KIN,RELATIONSHIP,NEXT_OF_KIN_ADDR,NEXT_OF_KIN_ZIP_CODE,NEXT_OF_KIN_PHONE from MED_PAT_MASTER_INDEX";
        private static readonly string MED_PAT_MASTER_INDEX_Insert = "Insert into MED_PAT_MASTER_INDEX  (PATIENT_ID,NAME,NAME_PHONETIC,SEX,DATE_OF_BIRTH,BIRTH_PLACE,CITIZENSHIP,NATION,ID_NO,IDENTITY,UNIT_IN_CONTRACT,MAILING_ADDRESS,ZIP_CODE,PHONE_NUMBER_HOME,PHONE_NUMBER_BUSINESS,NEXT_OF_KIN,RELATIONSHIP,NEXT_OF_KIN_ADDR,NEXT_OF_KIN_ZIP_CODE,NEXT_OF_KIN_PHONE, CHARGE_TYPE, LCLJ) values(:PatientId,:Name,:NamePhonetic,:Sex,:DateOfBirth,:BirthPlace,:Citizenship,:Nation,:IdNo,:Identity,:UnitInContract,:MailingAddress,:ZipCode,:PhoneNumberHome,:PhoneNumberBusiness,:NextOfKin,:Relationship,:NextOfKinAddr,:NextOfKinZipCode,:NextOfKinPhone, :ChargeType, :Lclj)";
        private static readonly string MED_PAT_MASTER_INDEX_Update = "Update MED_PAT_MASTER_INDEX set NAME=:Name,NAME_PHONETIC=:NamePhonetic,SEX=:Sex,DATE_OF_BIRTH=:DateOfBirth,BIRTH_PLACE=:BirthPlace,CITIZENSHIP=:Citizenship,NATION=:Nation,ID_NO=:IdNo,IDENTITY=:Identity,UNIT_IN_CONTRACT=:UnitInContract,MAILING_ADDRESS=:MailingAddress,ZIP_CODE=:ZipCode,PHONE_NUMBER_HOME=:PhoneNumberHome,PHONE_NUMBER_BUSINESS=:PhoneNumberBusiness,NEXT_OF_KIN=:NextOfKin,RELATIONSHIP=:Relationship,NEXT_OF_KIN_ADDR=:NextOfKinAddr,NEXT_OF_KIN_ZIP_CODE=:NextOfKinZipCode,NEXT_OF_KIN_PHONE=:NextOfKinPhone, CHARGE_TYPE=:ChargeType, LCLJ=:Lclj where PATIENT_ID=:PatientId";
        private static readonly string MED_PAT_MASTER_INDEX_Delete = "Delete MED_PAT_MASTER_INDEX WHERE PATIENT_ID=:PatientId";
        private static readonly string MED_PAT_MASTER_INDEX_Select = "select PATIENT_ID,NAME,NAME_PHONETIC,SEX,DATE_OF_BIRTH,BIRTH_PLACE,CITIZENSHIP,NATION,ID_NO,IDENTITY,UNIT_IN_CONTRACT,MAILING_ADDRESS,ZIP_CODE,PHONE_NUMBER_HOME,PHONE_NUMBER_BUSINESS,NEXT_OF_KIN,RELATIONSHIP,NEXT_OF_KIN_ADDR,NEXT_OF_KIN_ZIP_CODE,NEXT_OF_KIN_PHONE from MED_PAT_MASTER_INDEX WHERE PATIENT_ID=:PatientId ";
        private static readonly string MED_PAT_MASTER_INDEX_Select_ALL = "select PATIENT_ID,NAME,NAME_PHONETIC,SEX,DATE_OF_BIRTH,BIRTH_PLACE,CITIZENSHIP,NATION,ID_NO,IDENTITY,UNIT_IN_CONTRACT,MAILING_ADDRESS,ZIP_CODE,PHONE_NUMBER_HOME,PHONE_NUMBER_BUSINESS,NEXT_OF_KIN,RELATIONSHIP,NEXT_OF_KIN_ADDR,NEXT_OF_KIN_ZIP_CODE,NEXT_OF_KIN_PHONE from MED_PAT_MASTER_INDEX";
        public DALMedPatMasterIndex()
        {
        }
        #region [获取参数SQL]
        /// <summary>
        ///获取参数MedPatMasterIndex SQL
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedPatMasterIndex")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
                            new SqlParameter("@Name",SqlDbType.VarChar),
                            new SqlParameter("@NamePhonetic",SqlDbType.VarChar),
                            new SqlParameter("@Sex",SqlDbType.VarChar),
                            new SqlParameter("@DateOfBirth",SqlDbType.DateTime),
                            new SqlParameter("@BirthPlace",SqlDbType.VarChar),
                            new SqlParameter("@Citizenship",SqlDbType.VarChar),
                            new SqlParameter("@Nation",SqlDbType.VarChar),
                            new SqlParameter("@IdNo",SqlDbType.VarChar),
                            new SqlParameter("@Identity",SqlDbType.VarChar),
                            new SqlParameter("@UnitInContract",SqlDbType.VarChar),
                            new SqlParameter("@MailingAddress",SqlDbType.VarChar),
                            new SqlParameter("@ZipCode",SqlDbType.VarChar),
                            new SqlParameter("@PhoneNumberHome",SqlDbType.VarChar),
                            new SqlParameter("@PhoneNumberBusiness",SqlDbType.VarChar),
                            new SqlParameter("@NextOfKin",SqlDbType.VarChar),
                            new SqlParameter("@Relationship",SqlDbType.VarChar),
                            new SqlParameter("@NextOfKinAddr",SqlDbType.VarChar),
                            new SqlParameter("@NextOfKinZipCode",SqlDbType.VarChar),
                            new SqlParameter("@NextOfKinPhone",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedPatMasterIndex")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@Name",SqlDbType.VarChar),
                            new SqlParameter("@NamePhonetic",SqlDbType.VarChar),
                            new SqlParameter("@Sex",SqlDbType.VarChar),
                            new SqlParameter("@DateOfBirth",SqlDbType.DateTime),
                            new SqlParameter("@BirthPlace",SqlDbType.VarChar),
                            new SqlParameter("@Citizenship",SqlDbType.VarChar),
                            new SqlParameter("@Nation",SqlDbType.VarChar),
                            new SqlParameter("@IdNo",SqlDbType.VarChar),
                            new SqlParameter("@Identity",SqlDbType.VarChar),
                            new SqlParameter("@UnitInContract",SqlDbType.VarChar),
                            new SqlParameter("@MailingAddress",SqlDbType.VarChar),
                            new SqlParameter("@ZipCode",SqlDbType.VarChar),
                            new SqlParameter("@PhoneNumberHome",SqlDbType.VarChar),
                            new SqlParameter("@PhoneNumberBusiness",SqlDbType.VarChar),
                            new SqlParameter("@NextOfKin",SqlDbType.VarChar),
                            new SqlParameter("@Relationship",SqlDbType.VarChar),
                            new SqlParameter("@NextOfKinAddr",SqlDbType.VarChar),
                            new SqlParameter("@NextOfKinZipCode",SqlDbType.VarChar),
                            new SqlParameter("@NextOfKinPhone",SqlDbType.VarChar),
                            new SqlParameter("@PatientId",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedPatMasterIndex")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPatMasterIndex")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedPatMasterIndex 
        ///Insert Table MED_PAT_MASTER_INDEX
        /// </summary>
        public int InsertMedPatMasterIndexSQL(MedPatMasterIndex model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedPatMasterIndex");
                if (model.PatientId != null)
                    oneInert[0].Value = model.PatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.Name != null)
                    oneInert[1].Value = model.Name;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.NamePhonetic != null)
                    oneInert[2].Value = model.NamePhonetic;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.Sex != null)
                    oneInert[3].Value = model.Sex;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.DateOfBirth != null)
                    oneInert[4].Value = model.DateOfBirth;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.BirthPlace != null)
                    oneInert[5].Value = model.BirthPlace;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.Citizenship != null)
                    oneInert[6].Value = model.Citizenship;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.Nation != null)
                    oneInert[7].Value = model.Nation;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.IdNo != null)
                    oneInert[8].Value = model.IdNo;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Identity != null)
                    oneInert[9].Value = model.Identity;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.UnitInContract != null)
                    oneInert[10].Value = model.UnitInContract;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.MailingAddress != null)
                    oneInert[11].Value = model.MailingAddress;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.ZipCode != null)
                    oneInert[12].Value = model.ZipCode;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.PhoneNumberHome != null)
                    oneInert[13].Value = model.PhoneNumberHome;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.PhoneNumberBusiness != null)
                    oneInert[14].Value = model.PhoneNumberBusiness;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.NextOfKin != null)
                    oneInert[15].Value = model.NextOfKin;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.Relationship != null)
                    oneInert[16].Value = model.Relationship;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.NextOfKinAddr != null)
                    oneInert[17].Value = model.NextOfKinAddr;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.NextOfKinZipCode != null)
                    oneInert[18].Value = model.NextOfKinZipCode;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.NextOfKinPhone != null)
                    oneInert[19].Value = model.NextOfKinPhone;
                else
                    oneInert[19].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_PAT_MASTER_INDEX_Insert_SQL, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedPatMasterIndex 
        ///Update Table     MED_PAT_MASTER_INDEX
        /// </summary>
        public int UpdateMedPatMasterIndexSQL(MedPatMasterIndex model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedPatMasterIndex");
                if (model.Name != null)
                    oneUpdate[0].Value = model.Name;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.NamePhonetic != null)
                    oneUpdate[1].Value = model.NamePhonetic;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.Sex != null)
                    oneUpdate[2].Value = model.Sex;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.DateOfBirth != null)
                    oneUpdate[3].Value = model.DateOfBirth;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.BirthPlace != null)
                    oneUpdate[4].Value = model.BirthPlace;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.Citizenship != null)
                    oneUpdate[5].Value = model.Citizenship;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.Nation != null)
                    oneUpdate[6].Value = model.Nation;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.IdNo != null)
                    oneUpdate[7].Value = model.IdNo;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.Identity != null)
                    oneUpdate[8].Value = model.Identity;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.UnitInContract != null)
                    oneUpdate[9].Value = model.UnitInContract;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.MailingAddress != null)
                    oneUpdate[10].Value = model.MailingAddress;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.ZipCode != null)
                    oneUpdate[11].Value = model.ZipCode;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.PhoneNumberHome != null)
                    oneUpdate[12].Value = model.PhoneNumberHome;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.PhoneNumberBusiness != null)
                    oneUpdate[13].Value = model.PhoneNumberBusiness;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.NextOfKin != null)
                    oneUpdate[14].Value = model.NextOfKin;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.Relationship != null)
                    oneUpdate[15].Value = model.Relationship;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.NextOfKinAddr != null)
                    oneUpdate[16].Value = model.NextOfKinAddr;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.NextOfKinZipCode != null)
                    oneUpdate[17].Value = model.NextOfKinZipCode;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.NextOfKinPhone != null)
                    oneUpdate[18].Value = model.NextOfKinPhone;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[19].Value = model.PatientId;
                else
                    oneUpdate[19].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_PAT_MASTER_INDEX_Update_SQL, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedPatMasterIndex 
        ///Delete Table MED_PAT_MASTER_INDEX by (string PATIENT_ID)
        /// </summary>
        public int DeleteMedPatMasterIndexSQL(string PATIENT_ID)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneDelete = GetParameterSQL("DeleteMedPatMasterIndex");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_PAT_MASTER_INDEX_Delete_SQL, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedPatMasterIndex 
        ///select Table MED_PAT_MASTER_INDEX by (string PATIENT_ID)
        /// </summary>
        public MedPatMasterIndex SelectMedPatMasterIndexSQL(string PATIENT_ID)
        {
            MedPatMasterIndex model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedPatMasterIndex");
            parameterValues[0].Value = PATIENT_ID;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_PAT_MASTER_INDEX_Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPatMasterIndex();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.PatientId = oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.Name = oleReader["NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.NamePhonetic = oleReader["NAME_PHONETIC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Sex = oleReader["SEX"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DateOfBirth = DateTime.Parse(oleReader["DATE_OF_BIRTH"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.BirthPlace = oleReader["BIRTH_PLACE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Citizenship = oleReader["CITIZENSHIP"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Nation = oleReader["NATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.IdNo = oleReader["ID_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Identity = oleReader["IDENTITY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.UnitInContract = oleReader["UNIT_IN_CONTRACT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.MailingAddress = oleReader["MAILING_ADDRESS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.ZipCode = oleReader["ZIP_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.PhoneNumberHome = oleReader["PHONE_NUMBER_HOME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.PhoneNumberBusiness = oleReader["PHONE_NUMBER_BUSINESS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.NextOfKin = oleReader["NEXT_OF_KIN"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.Relationship = oleReader["RELATIONSHIP"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.NextOfKinAddr = oleReader["NEXT_OF_KIN_ADDR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.NextOfKinZipCode = oleReader["NEXT_OF_KIN_ZIP_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.NextOfKinPhone = oleReader["NEXT_OF_KIN_PHONE"].ToString().Trim();
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
        public List<MedPatMasterIndex> SelectMedPatMasterIndexListSQL()
        {
            List<MedPatMasterIndex> modelList = new List<MedPatMasterIndex>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_PAT_MASTER_INDEX_Select_ALL_SQL, null))
            {
                while (oleReader.Read())
                {
                    MedPatMasterIndex model = new MedPatMasterIndex();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.PatientId = oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.Name = oleReader["NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.NamePhonetic = oleReader["NAME_PHONETIC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Sex = oleReader["SEX"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DateOfBirth = DateTime.Parse(oleReader["DATE_OF_BIRTH"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.BirthPlace = oleReader["BIRTH_PLACE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Citizenship = oleReader["CITIZENSHIP"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Nation = oleReader["NATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.IdNo = oleReader["ID_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Identity = oleReader["IDENTITY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.UnitInContract = oleReader["UNIT_IN_CONTRACT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.MailingAddress = oleReader["MAILING_ADDRESS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.ZipCode = oleReader["ZIP_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.PhoneNumberHome = oleReader["PHONE_NUMBER_HOME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.PhoneNumberBusiness = oleReader["PHONE_NUMBER_BUSINESS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.NextOfKin = oleReader["NEXT_OF_KIN"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.Relationship = oleReader["RELATIONSHIP"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.NextOfKinAddr = oleReader["NEXT_OF_KIN_ADDR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.NextOfKinZipCode = oleReader["NEXT_OF_KIN_ZIP_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.NextOfKinPhone = oleReader["NEXT_OF_KIN_PHONE"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region [获取参数]
        /// <summary>
        ///获取参数MedPatMasterIndex
        /// </summary>
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedPatMasterIndex")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
                            new OracleParameter(":Name",OracleType.VarChar),
                            new OracleParameter(":NamePhonetic",OracleType.VarChar),
                            new OracleParameter(":Sex",OracleType.VarChar),
                            new OracleParameter(":DateOfBirth",OracleType.DateTime),
                            new OracleParameter(":BirthPlace",OracleType.VarChar),
                            new OracleParameter(":Citizenship",OracleType.VarChar),
                            new OracleParameter(":Nation",OracleType.VarChar),
                            new OracleParameter(":IdNo",OracleType.VarChar),
                            new OracleParameter(":Identity",OracleType.VarChar),
                            new OracleParameter(":UnitInContract",OracleType.VarChar),
                            new OracleParameter(":MailingAddress",OracleType.VarChar),
                            new OracleParameter(":ZipCode",OracleType.VarChar),
                            new OracleParameter(":PhoneNumberHome",OracleType.VarChar),
                            new OracleParameter(":PhoneNumberBusiness",OracleType.VarChar),
                            new OracleParameter(":NextOfKin",OracleType.VarChar),
                            new OracleParameter(":Relationship",OracleType.VarChar),
                            new OracleParameter(":NextOfKinAddr",OracleType.VarChar),
                            new OracleParameter(":NextOfKinZipCode",OracleType.VarChar),
                            new OracleParameter(":NextOfKinPhone",OracleType.VarChar),
                            new OracleParameter(":ChargeType",OracleType.VarChar),
                            new OracleParameter(":Lclj",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedPatMasterIndex")
                {
                    parms = new OracleParameter[]{
                            new OracleParameter(":Name",OracleType.VarChar),
                            new OracleParameter(":NamePhonetic",OracleType.VarChar),
                            new OracleParameter(":Sex",OracleType.VarChar),
                            new OracleParameter(":DateOfBirth",OracleType.DateTime),
                            new OracleParameter(":BirthPlace",OracleType.VarChar),
                            new OracleParameter(":Citizenship",OracleType.VarChar),
                            new OracleParameter(":Nation",OracleType.VarChar),
                            new OracleParameter(":IdNo",OracleType.VarChar),
                            new OracleParameter(":Identity",OracleType.VarChar),
                            new OracleParameter(":UnitInContract",OracleType.VarChar),
                            new OracleParameter(":MailingAddress",OracleType.VarChar),
                            new OracleParameter(":ZipCode",OracleType.VarChar),
                            new OracleParameter(":PhoneNumberHome",OracleType.VarChar),
                            new OracleParameter(":PhoneNumberBusiness",OracleType.VarChar),
                            new OracleParameter(":NextOfKin",OracleType.VarChar),
                            new OracleParameter(":Relationship",OracleType.VarChar),
                            new OracleParameter(":NextOfKinAddr",OracleType.VarChar),
                            new OracleParameter(":NextOfKinZipCode",OracleType.VarChar),
                            new OracleParameter(":NextOfKinPhone",OracleType.VarChar),
                            new OracleParameter(":PatientId",OracleType.VarChar),
                            new OracleParameter(":ChargeType",OracleType.VarChar),
                            new OracleParameter(":Lclj",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedPatMasterIndex")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPatMasterIndex")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedPatMasterIndex 
        ///Insert Table MED_PAT_MASTER_INDEX
        /// </summary>
        public int InsertMedPatMasterIndex(MedPatMasterIndex model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedPatMasterIndex");
                if (model.PatientId != null)
                    oneInert[0].Value = model.PatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.Name != null)
                    oneInert[1].Value = model.Name;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.NamePhonetic != null)
                    oneInert[2].Value = model.NamePhonetic;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.Sex != null)
                    oneInert[3].Value = model.Sex;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.DateOfBirth != null)
                    oneInert[4].Value = model.DateOfBirth;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.BirthPlace != null)
                    oneInert[5].Value = model.BirthPlace;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.Citizenship != null)
                    oneInert[6].Value = model.Citizenship;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.Nation != null)
                    oneInert[7].Value = model.Nation;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.IdNo != null)
                    oneInert[8].Value = model.IdNo;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Identity != null)
                    oneInert[9].Value = model.Identity;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.UnitInContract != null)
                    oneInert[10].Value = model.UnitInContract;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.MailingAddress != null)
                    oneInert[11].Value = model.MailingAddress;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.ZipCode != null)
                    oneInert[12].Value = model.ZipCode;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.PhoneNumberHome != null)
                    oneInert[13].Value = model.PhoneNumberHome;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.PhoneNumberBusiness != null)
                    oneInert[14].Value = model.PhoneNumberBusiness;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.NextOfKin != null)
                    oneInert[15].Value = model.NextOfKin;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.Relationship != null)
                    oneInert[16].Value = model.Relationship;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.NextOfKinAddr != null)
                    oneInert[17].Value = model.NextOfKinAddr;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.NextOfKinZipCode != null)
                    oneInert[18].Value = model.NextOfKinZipCode;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.NextOfKinPhone != null)
                    oneInert[19].Value = model.NextOfKinPhone;
                else
                    oneInert[19].Value = DBNull.Value;

                // 收费列表
                if (model.ChargeType != null)
                {
                    oneInert[20].Value = model.ChargeType;
                }
                else
                {
                    oneInert[20].Value = DBNull.Value;
                }

                // 临床路径
                if (model.Lclj != null)
                {
                    oneInert[21].Value = model.Lclj;
                }
                else
                {
                    oneInert[21].Value = DBNull.Value;
                }

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_PAT_MASTER_INDEX_Insert, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedPatMasterIndex 
        ///Update Table     MED_PAT_MASTER_INDEX
        /// </summary>
        public int UpdateMedPatMasterIndex(MedPatMasterIndex model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedPatMasterIndex");
                if (model.Name != null)
                    oneUpdate[0].Value = model.Name;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.NamePhonetic != null)
                    oneUpdate[1].Value = model.NamePhonetic;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.Sex != null)
                    oneUpdate[2].Value = model.Sex;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.DateOfBirth != null)
                    oneUpdate[3].Value = model.DateOfBirth;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.BirthPlace != null)
                    oneUpdate[4].Value = model.BirthPlace;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.Citizenship != null)
                    oneUpdate[5].Value = model.Citizenship;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.Nation != null)
                    oneUpdate[6].Value = model.Nation;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.IdNo != null)
                    oneUpdate[7].Value = model.IdNo;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.Identity != null)
                    oneUpdate[8].Value = model.Identity;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.UnitInContract != null)
                    oneUpdate[9].Value = model.UnitInContract;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.MailingAddress != null)
                    oneUpdate[10].Value = model.MailingAddress;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.ZipCode != null)
                    oneUpdate[11].Value = model.ZipCode;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.PhoneNumberHome != null)
                    oneUpdate[12].Value = model.PhoneNumberHome;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.PhoneNumberBusiness != null)
                    oneUpdate[13].Value = model.PhoneNumberBusiness;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.NextOfKin != null)
                    oneUpdate[14].Value = model.NextOfKin;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.Relationship != null)
                    oneUpdate[15].Value = model.Relationship;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.NextOfKinAddr != null)
                    oneUpdate[16].Value = model.NextOfKinAddr;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.NextOfKinZipCode != null)
                    oneUpdate[17].Value = model.NextOfKinZipCode;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.NextOfKinPhone != null)
                    oneUpdate[18].Value = model.NextOfKinPhone;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[19].Value = model.PatientId;
                else
                    oneUpdate[19].Value = DBNull.Value;

                // 收费列表
                if(model.ChargeType != null)
                {
                    oneUpdate[20].Value = model.ChargeType;
                }
                else
                {
                    oneUpdate[20].Value = DBNull.Value;
                }

                // 临床路径
                if(model.Lclj != null)
                {
                    oneUpdate[21].Value = model.Lclj;
                }
                else
                {
                    oneUpdate[21].Value = DBNull.Value;
                }

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_PAT_MASTER_INDEX_Update, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedPatMasterIndex 
        ///Delete Table MED_PAT_MASTER_INDEX by (string PATIENT_ID)
        /// </summary>
        public int DeleteMedPatMasterIndex(string PATIENT_ID)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneDelete = GetParameter("DeleteMedPatMasterIndex");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_PAT_MASTER_INDEX_Delete, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedPatMasterIndex 
        ///select Table MED_PAT_MASTER_INDEX by (string PATIENT_ID)
        /// </summary>
        public MedPatMasterIndex SelectMedPatMasterIndex(string PATIENT_ID)
        {
            MedPatMasterIndex model;
            OracleParameter[] parameterValues = GetParameter("SelectMedPatMasterIndex");
            parameterValues[0].Value = PATIENT_ID;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_PAT_MASTER_INDEX_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPatMasterIndex();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.PatientId = oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.Name = oleReader["NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.NamePhonetic = oleReader["NAME_PHONETIC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Sex = oleReader["SEX"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DateOfBirth = DateTime.Parse(oleReader["DATE_OF_BIRTH"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.BirthPlace = oleReader["BIRTH_PLACE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Citizenship = oleReader["CITIZENSHIP"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Nation = oleReader["NATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.IdNo = oleReader["ID_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Identity = oleReader["IDENTITY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.UnitInContract = oleReader["UNIT_IN_CONTRACT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.MailingAddress = oleReader["MAILING_ADDRESS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.ZipCode = oleReader["ZIP_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.PhoneNumberHome = oleReader["PHONE_NUMBER_HOME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.PhoneNumberBusiness = oleReader["PHONE_NUMBER_BUSINESS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.NextOfKin = oleReader["NEXT_OF_KIN"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.Relationship = oleReader["RELATIONSHIP"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.NextOfKinAddr = oleReader["NEXT_OF_KIN_ADDR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.NextOfKinZipCode = oleReader["NEXT_OF_KIN_ZIP_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.NextOfKinPhone = oleReader["NEXT_OF_KIN_PHONE"].ToString().Trim();
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
        public List<MedPatMasterIndex> SelectMedPatMasterIndexList()
        {
            List<MedPatMasterIndex> modelList = new List<MedPatMasterIndex>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_PAT_MASTER_INDEX_Select_ALL, null))
            {
                while (oleReader.Read())
                {
                    MedPatMasterIndex model = new MedPatMasterIndex();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.PatientId = oleReader["PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.Name = oleReader["NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.NamePhonetic = oleReader["NAME_PHONETIC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Sex = oleReader["SEX"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DateOfBirth = DateTime.Parse(oleReader["DATE_OF_BIRTH"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.BirthPlace = oleReader["BIRTH_PLACE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Citizenship = oleReader["CITIZENSHIP"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Nation = oleReader["NATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.IdNo = oleReader["ID_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Identity = oleReader["IDENTITY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.UnitInContract = oleReader["UNIT_IN_CONTRACT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.MailingAddress = oleReader["MAILING_ADDRESS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.ZipCode = oleReader["ZIP_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.PhoneNumberHome = oleReader["PHONE_NUMBER_HOME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.PhoneNumberBusiness = oleReader["PHONE_NUMBER_BUSINESS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.NextOfKin = oleReader["NEXT_OF_KIN"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.Relationship = oleReader["RELATIONSHIP"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.NextOfKinAddr = oleReader["NEXT_OF_KIN_ADDR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.NextOfKinZipCode = oleReader["NEXT_OF_KIN_ZIP_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.NextOfKinPhone = oleReader["NEXT_OF_KIN_PHONE"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

    }
}
