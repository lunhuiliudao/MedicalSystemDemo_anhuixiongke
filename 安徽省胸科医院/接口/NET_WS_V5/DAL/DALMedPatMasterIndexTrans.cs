

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
		
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedPatMasterIndex 
		///Insert Table MED_PAT_MASTER_INDEX
		/// </summary>
        public int InsertMedPatMasterIndexSQL(MedPatMasterIndex model, System.Data.Common.DbTransaction oleCisTrans)
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


                    return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_PAT_MASTER_INDEX_Insert_SQL, oneInert);
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedPatMasterIndex 
		///Update Table     MED_PAT_MASTER_INDEX
		/// </summary>
        public int UpdateMedPatMasterIndexSQL(MedPatMasterIndex model, System.Data.Common.DbTransaction oleCisTrans)
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

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_PAT_MASTER_INDEX_Update_SQL, oneUpdate);
			
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedPatMasterIndex 
		///Delete Table MED_PAT_MASTER_INDEX by (string PATIENT_ID)
		/// </summary>
        public int DeleteMedPatMasterIndexSQL(string PATIENT_ID, System.Data.Common.DbTransaction oleCisTrans)
		{
			SqlParameter[] oneDelete = GetParameterSQL("DeleteMedPatMasterIndex");
			if (PATIENT_ID != null)
				oneDelete[0].Value =PATIENT_ID;
			else
				oneDelete[0].Value = DBNull.Value;

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_PAT_MASTER_INDEX_Delete_SQL, oneDelete);

		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedPatMasterIndex 
		///select Table MED_PAT_MASTER_INDEX by (string PATIENT_ID)
		/// </summary>
        public MedPatMasterIndex SelectMedPatMasterIndexSQL(string PATIENT_ID, System.Data.Common.DbConnection oleCisConn)
		{
			MedPatMasterIndex model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedPatMasterIndex");
				parameterValues[0].Value=PATIENT_ID;
                using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_PAT_MASTER_INDEX_Select_SQL, parameterValues))
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
		public List<MedPatMasterIndex> SelectMedPatMasterIndexListSQL(System.Data.Common.DbConnection oleCisConn)
		{
			List<MedPatMasterIndex> modelList = new List<MedPatMasterIndex>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_PAT_MASTER_INDEX_Select_ALL_SQL, null))
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
		
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedPatMasterIndex 
		///Insert Table MED_PAT_MASTER_INDEX
		/// </summary>
        public int InsertMedPatMasterIndex(MedPatMasterIndex model, System.Data.Common.DbTransaction oleCisTrans)
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


            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_PAT_MASTER_INDEX_Insert, oneInert);

		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedPatMasterIndex 
		///Update Table     MED_PAT_MASTER_INDEX
		/// </summary>
        public int UpdateMedPatMasterIndex(MedPatMasterIndex model, System.Data.Common.DbTransaction oleCisTrans)
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

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_PAT_MASTER_INDEX_Update, oneUpdate);

		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedPatMasterIndex 
		///Delete Table MED_PAT_MASTER_INDEX by (string PATIENT_ID)
		/// </summary>
        public int DeleteMedPatMasterIndex(string PATIENT_ID, System.Data.Common.DbTransaction oleCisTrans)
		{
			OracleParameter[] oneDelete = GetParameter("DeleteMedPatMasterIndex");
			if (PATIENT_ID != null)
				oneDelete[0].Value =PATIENT_ID;
			else
				oneDelete[0].Value = DBNull.Value;
            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_PAT_MASTER_INDEX_Delete, oneDelete);
			
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedPatMasterIndex 
		///select Table MED_PAT_MASTER_INDEX by (string PATIENT_ID)
		/// </summary>
        public MedPatMasterIndex SelectMedPatMasterIndex(string PATIENT_ID, System.Data.Common.DbConnection oleCisConn)
		{
			MedPatMasterIndex model;
			OracleParameter[] parameterValues = GetParameter("SelectMedPatMasterIndex");
			parameterValues[0].Value=PATIENT_ID;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_PAT_MASTER_INDEX_Select, parameterValues))
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
		public List<MedPatMasterIndex> SelectMedPatMasterIndexList( System.Data.Common.DbConnection oleCisConn)
		{
			List<MedPatMasterIndex> modelList = new List<MedPatMasterIndex>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_PAT_MASTER_INDEX_Select_ALL, null))
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
