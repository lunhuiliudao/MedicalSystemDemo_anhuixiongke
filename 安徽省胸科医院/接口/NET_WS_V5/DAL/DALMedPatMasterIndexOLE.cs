

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
using System.Data.OleDb;
using System.Data.Odbc;
namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedPatMasterIndex
    /// </summary>

    public partial class DALMedPatMasterIndex
    {

        private static readonly string Select_MedPatMasterIndex_OLE = "select PATIENT_ID,NAME,NAME_PHONETIC,SEX,DATE_OF_BIRTH,BIRTH_PLACE,CITIZENSHIP,NATION,ID_NO,IDENTITY,UNIT_IN_CONTRACT,MAILING_ADDRESS,ZIP_CODE,PHONE_NUMBER_HOME,PHONE_NUMBER_BUSINESS,NEXT_OF_KIN,RELATIONSHIP,NEXT_OF_KIN_ADDR,NEXT_OF_KIN_ZIP_CODE,NEXT_OF_KIN_PHONE from MED_PAT_MASTER_INDEX WHERE PATIENT_ID=?";
        private static readonly string Insert_MedPatMasterIndex_OLE = "Insert into MED_PAT_MASTER_INDEX  (PATIENT_ID,NAME,NAME_PHONETIC,SEX,DATE_OF_BIRTH,BIRTH_PLACE,CITIZENSHIP,NATION,ID_NO,IDENTITY,UNIT_IN_CONTRACT,MAILING_ADDRESS,ZIP_CODE,PHONE_NUMBER_HOME,PHONE_NUMBER_BUSINESS,NEXT_OF_KIN,RELATIONSHIP,NEXT_OF_KIN_ADDR,NEXT_OF_KIN_ZIP_CODE,NEXT_OF_KIN_PHONE) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";
        private static readonly string Update_MedPatMasterIndex_OLE = "Update MED_PAT_MASTER_INDEX set NAME=?,NAME_PHONETIC=?,SEX=?,DATE_OF_BIRTH=?,BIRTH_PLACE=?,CITIZENSHIP=?,NATION=?,ID_NO=?,IDENTITY=?,UNIT_IN_CONTRACT=?,MAILING_ADDRESS=?,ZIP_CODE=?,PHONE_NUMBER_HOME=?,PHONE_NUMBER_BUSINESS=?,NEXT_OF_KIN=?,RELATIONSHIP=?,NEXT_OF_KIN_ADDR=?,NEXT_OF_KIN_ZIP_CODE=?,NEXT_OF_KIN_PHONE=? where PATIENT_ID=? ";
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedPatMasterIndex")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar)
                    };
                }
                else
                {
                    if (sqlParms == "InsertMedPatMasterIndex")
                    {
                        parms = new OleDbParameter[]{
                            new OleDbParameter("PatientId",OleDbType.VarChar),
                            new OleDbParameter("Name",OleDbType.VarChar),
                            new OleDbParameter("NamePhonetic",OleDbType.VarChar),
                            new OleDbParameter("Sex",OleDbType.VarChar),
                            new OleDbParameter("DateOfBirth",OleDbType.DBTimeStamp),
                            new OleDbParameter("BirthPlace",OleDbType.VarChar),
                            new OleDbParameter("Citizenship",OleDbType.VarChar),
                            new OleDbParameter("Nation",OleDbType.VarChar),
                            new OleDbParameter("IdNo",OleDbType.VarChar),
                            new OleDbParameter("Identity",OleDbType.VarChar),
                            new OleDbParameter("UnitInContract",OleDbType.VarChar),
                            new OleDbParameter("MailingAddress",OleDbType.VarChar),
                            new OleDbParameter("ZipCode",OleDbType.VarChar),
                            new OleDbParameter("PhoneNumberHome",OleDbType.VarChar),
                            new OleDbParameter("PhoneNumberBusiness",OleDbType.VarChar),
                            new OleDbParameter("NextOfKin",OleDbType.VarChar),
                            new OleDbParameter("Relationship",OleDbType.VarChar),
                            new OleDbParameter("NextOfKinAddr",OleDbType.VarChar),
                            new OleDbParameter("NextOfKinZipCode",OleDbType.VarChar),
                            new OleDbParameter("NextOfKinPhone",OleDbType.VarChar),
                        };
                    }
                    else
                    {
                        if (sqlParms == "UpdateMedPatMasterIndex")
                        {
                            parms = new OleDbParameter[]{
                               new OleDbParameter(":Name",OleDbType.VarChar),
                                new OleDbParameter(":NamePhonetic",OleDbType.VarChar),
                                new OleDbParameter(":Sex",OleDbType.VarChar),
                                new OleDbParameter(":DateOfBirth",OleDbType.DBTimeStamp),
                                new OleDbParameter(":BirthPlace",OleDbType.VarChar),
                                new OleDbParameter(":Citizenship",OleDbType.VarChar),
                                new OleDbParameter(":Nation",OleDbType.VarChar),
                                new OleDbParameter(":IdNo",OleDbType.VarChar),
                                new OleDbParameter(":Identity",OleDbType.VarChar),
                                new OleDbParameter(":UnitInContract",OleDbType.VarChar),
                                new OleDbParameter(":MailingAddress",OleDbType.VarChar),
                                new OleDbParameter(":ZipCode",OleDbType.VarChar),
                                new OleDbParameter(":PhoneNumberHome",OleDbType.VarChar),
                                new OleDbParameter(":PhoneNumberBusiness",OleDbType.VarChar),
                                new OleDbParameter(":NextOfKin",OleDbType.VarChar),
                                new OleDbParameter(":Relationship",OleDbType.VarChar),
                                new OleDbParameter(":NextOfKinAddr",OleDbType.VarChar),
                                new OleDbParameter(":NextOfKinZipCode",OleDbType.VarChar),
                                new OleDbParameter(":NextOfKinPhone",OleDbType.VarChar),
                                new OleDbParameter(":PatientId",OleDbType.VarChar),
                            };
                        }
                    }
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedPatMasterIndex SelectMedPatMasterIndexOLE(string patientId)
        {
            Model.MedPatMasterIndex model = null;

            OleDbParameter[] mdPatMasterIndex = GetParameterOLE("SelectMedPatMasterIndex");
            mdPatMasterIndex[0].Value = patientId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedPatMasterIndex_OLE, mdPatMasterIndex))
            {
                if (oleReader.Read())
                {
                    model = new Model.MedPatMasterIndex();
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

        public int InsertMedPatMasterIndexOLE(Model.MedPatMasterIndex model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedPatMasterIndex");
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

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_MedPatMasterIndex_OLE, oneInert);
            }
        }

        public int UpdateMedPatMasterIndexOLE(Model.MedPatMasterIndex model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedPatMasterIndex");
                //if (MedPatMasterIndex.InpNo != null)
                //    oneUpdate[0].Value = MedPatMasterIndex.InpNo;
                //else
                //    oneUpdate[0].Value = DBNull.Value;
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

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_MedPatMasterIndex_OLE, oneUpdate);
            }
        }


        private static readonly string Select_MedPatMasterIndex_Odbc = "select PATIENT_ID,NAME,NAME_PHONETIC,SEX,DATE_OF_BIRTH,BIRTH_PLACE,CITIZENSHIP,NATION,ID_NO,IDENTITY,UNIT_IN_CONTRACT,MAILING_ADDRESS,ZIP_CODE,PHONE_NUMBER_HOME,PHONE_NUMBER_BUSINESS,NEXT_OF_KIN,RELATIONSHIP,NEXT_OF_KIN_ADDR,NEXT_OF_KIN_ZIP_CODE,NEXT_OF_KIN_PHONE from MED_PAT_MASTER_INDEX WHERE PATIENT_ID=?";
        private static readonly string Insert_MedPatMasterIndex_Odbc = "Insert into MED_PAT_MASTER_INDEX  (PATIENT_ID,NAME,NAME_PHONETIC,SEX,DATE_OF_BIRTH,BIRTH_PLACE,CITIZENSHIP,NATION,ID_NO,IDENTITY,UNIT_IN_CONTRACT,MAILING_ADDRESS,ZIP_CODE,PHONE_NUMBER_HOME,PHONE_NUMBER_BUSINESS,NEXT_OF_KIN,RELATIONSHIP,NEXT_OF_KIN_ADDR,NEXT_OF_KIN_ZIP_CODE,NEXT_OF_KIN_PHONE) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string Update_MedPatMasterIndex_Odbc = "Update MED_PAT_MASTER_INDEX set NAME=?,NAME_PHONETIC=?,SEX=?,DATE_OF_BIRTH=?,BIRTH_PLACE=?,CITIZENSHIP=?,NATION=?,ID_NO=?,IDENTITY=?,UNIT_IN_CONTRACT=?,MAILING_ADDRESS=?,ZIP_CODE=?,PHONE_NUMBER_HOME=?,PHONE_NUMBER_BUSINESS=?,NEXT_OF_KIN=?,RELATIONSHIP=?,NEXT_OF_KIN_ADDR=?,NEXT_OF_KIN_ZIP_CODE=?,NEXT_OF_KIN_PHONE=? where PATIENT_ID=?";
        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedPatMasterIndex")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar)
                    };
                }
                else
                {
                    if (sqlParms == "InsertMedPatMasterIndex")
                    {
                        parms = new OdbcParameter[]{
                            new OdbcParameter("PatientId",OdbcType.VarChar),
                            new OdbcParameter("Name",OdbcType.VarChar),
                            new OdbcParameter("NamePhonetic",OdbcType.VarChar),
                            new OdbcParameter("Sex",OdbcType.VarChar),
                            new OdbcParameter("DateOfBirth",OdbcType.DateTime),
                            new OdbcParameter("BirthPlace",OdbcType.VarChar),
                            new OdbcParameter("Citizenship",OdbcType.VarChar),
                            new OdbcParameter("Nation",OdbcType.VarChar),
                            new OdbcParameter("IdNo",OdbcType.VarChar),
                            new OdbcParameter("Identity",OdbcType.VarChar),
                            new OdbcParameter("UnitInContract",OdbcType.VarChar),
                            new OdbcParameter("MailingAddress",OdbcType.VarChar),
                            new OdbcParameter("ZipCode",OdbcType.VarChar),
                            new OdbcParameter("PhoneNumberHome",OdbcType.VarChar),
                            new OdbcParameter("PhoneNumberBusiness",OdbcType.VarChar),
                            new OdbcParameter("NextOfKin",OdbcType.VarChar),
                            new OdbcParameter("Relationship",OdbcType.VarChar),
                            new OdbcParameter("NextOfKinAddr",OdbcType.VarChar),
                            new OdbcParameter("NextOfKinZipCode",OdbcType.VarChar),
                            new OdbcParameter("NextOfKinPhone",OdbcType.VarChar),
                        };
                    }
                    else
                    {
                        if (sqlParms == "UpdateMedPatMasterIndex")
                        {
                            parms = new OdbcParameter[]{
                              new OdbcParameter(":Name",OdbcType.VarChar),
                                new OdbcParameter(":NamePhonetic",OdbcType.VarChar),
                                new OdbcParameter(":Sex",OdbcType.VarChar),
                                new OdbcParameter(":DateOfBirth",OdbcType.DateTime),
                                new OdbcParameter(":BirthPlace",OdbcType.VarChar),
                                new OdbcParameter(":Citizenship",OdbcType.VarChar),
                                new OdbcParameter(":Nation",OdbcType.VarChar),
                                new OdbcParameter(":IdNo",OdbcType.VarChar),
                                new OdbcParameter(":Identity",OdbcType.VarChar),
                                new OdbcParameter(":UnitInContract",OdbcType.VarChar),
                                new OdbcParameter(":MailingAddress",OdbcType.VarChar),
                                new OdbcParameter(":ZipCode",OdbcType.VarChar),
                                new OdbcParameter(":PhoneNumberHome",OdbcType.VarChar),
                                new OdbcParameter(":PhoneNumberBusiness",OdbcType.VarChar),
                                new OdbcParameter(":NextOfKin",OdbcType.VarChar),
                                new OdbcParameter(":Relationship",OdbcType.VarChar),
                                new OdbcParameter(":NextOfKinAddr",OdbcType.VarChar),
                                new OdbcParameter(":NextOfKinZipCode",OdbcType.VarChar),
                                new OdbcParameter(":NextOfKinPhone",OdbcType.VarChar),
                                new OdbcParameter(":PatientId",OdbcType.VarChar),
                            };
                        }
                    }
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedPatMasterIndex SelectMedPatMasterIndexOdbc(string patientId)
        {
            Model.MedPatMasterIndex model = null;

            OdbcParameter[] mdPatMasterIndex = GetParameterOdbc("SelectMedPatMasterIndex");
            mdPatMasterIndex[0].Value = patientId;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MedPatMasterIndex_Odbc, mdPatMasterIndex))
            {
                if (oleReader.Read())
                {
                    model = new Model.MedPatMasterIndex();
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

        public int InsertMedPatMasterIndexOdbc(Model.MedPatMasterIndex model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedPatMasterIndex");
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
                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_MedPatMasterIndex_Odbc, oneInert);
            }
        }

        public int UpdateMedPatMasterIndexOdbc(Model.MedPatMasterIndex model)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedPatMasterIndex");
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

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_MedPatMasterIndex_Odbc, oneUpdate);
            }
        }

    }
}
