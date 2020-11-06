

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2011-06-12 12:28:57
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
	/// DAL Patients
	/// </summary>
	
	public partial class DALPatients
	{
		private static readonly string PATIENTS_Insert_SQL = "INSERT INTO PATIENTS (PATIENT_ID,PATIENT_CREATE_DATE,PATIENT_NAME,PATIENT_GENDER,PATIENT_BIRTH,PATIENT_ADDRESS,PATIENT_ALLERGIES,PATIENT_TELPHONE,PATIENT_MEDICARE_CARD,PATIENT_IDENTITY_CARD,FLAG) values (@PatientId,@PatientCreateDate,@PatientName,@PatientGender,@PatientBirth,@PatientAddress,@PatientAllergies,@PatientTelphone,@PatientMedicareCard,@PatientIdentityCard,@Flag)";
		private static readonly string PATIENTS_Update_SQL = "UPDATE PATIENTS SET PATIENT_ID=@PatientId,PATIENT_CREATE_DATE=@PatientCreateDate,PATIENT_NAME=@PatientName,PATIENT_GENDER=@PatientGender,PATIENT_BIRTH=@PatientBirth,PATIENT_ADDRESS=@PatientAddress,PATIENT_ALLERGIES=@PatientAllergies,PATIENT_TELPHONE=@PatientTelphone,PATIENT_MEDICARE_CARD=@PatientMedicareCard,PATIENT_IDENTITY_CARD=@PatientIdentityCard,FLAG=@Flag WHERE  PATIENT_ID=@PatientId";
		private static readonly string PATIENTS_Delete_SQL = "DELETE PATIENTS WHERE  PATIENT_ID=@PatientId";
		private static readonly string PATIENTS_Select_SQL = "SELECT PATIENT_ID,PATIENT_CREATE_DATE,PATIENT_NAME,PATIENT_GENDER,PATIENT_BIRTH,PATIENT_ADDRESS,PATIENT_ALLERGIES,PATIENT_TELPHONE,PATIENT_MEDICARE_CARD,PATIENT_IDENTITY_CARD,FLAG FROM PATIENTS where  PATIENT_ID=@PatientId";
		private static readonly string PATIENTS_Select_ALL_SQL = "SELECT PATIENT_ID,PATIENT_CREATE_DATE,PATIENT_NAME,PATIENT_GENDER,PATIENT_BIRTH,PATIENT_ADDRESS,PATIENT_ALLERGIES,PATIENT_TELPHONE,PATIENT_MEDICARE_CARD,PATIENT_IDENTITY_CARD,FLAG FROM PATIENTS";
		private static readonly string PATIENTS_Insert = "INSERT INTO PATIENTS (PATIENT_ID,PATIENT_CREATE_DATE,PATIENT_NAME,PATIENT_GENDER,PATIENT_BIRTH,PATIENT_ADDRESS,PATIENT_ALLERGIES,PATIENT_TELPHONE,PATIENT_MEDICARE_CARD,PATIENT_IDENTITY_CARD,FLAG) values (:PatientId,:PatientCreateDate,:PatientName,:PatientGender,:PatientBirth,:PatientAddress,:PatientAllergies,:PatientTelphone,:PatientMedicareCard,:PatientIdentityCard,:Flag)";
		private static readonly string PATIENTS_Update = "UPDATE PATIENTS SET PATIENT_ID=:PatientId,PATIENT_CREATE_DATE=:PatientCreateDate,PATIENT_NAME=:PatientName,PATIENT_GENDER=:PatientGender,PATIENT_BIRTH=:PatientBirth,PATIENT_ADDRESS=:PatientAddress,PATIENT_ALLERGIES=:PatientAllergies,PATIENT_TELPHONE=:PatientTelphone,PATIENT_MEDICARE_CARD=:PatientMedicareCard,PATIENT_IDENTITY_CARD=:PatientIdentityCard,FLAG=:Flag WHERE  PATIENT_ID=:PatientId";
		private static readonly string PATIENTS_Delete = "DELETE PATIENTS WHERE  PATIENT_ID=:PatientId";
		private static readonly string PATIENTS_Select = "SELECT PATIENT_ID,PATIENT_CREATE_DATE,PATIENT_NAME,PATIENT_GENDER,PATIENT_BIRTH,PATIENT_ADDRESS,PATIENT_ALLERGIES,PATIENT_TELPHONE,PATIENT_MEDICARE_CARD,PATIENT_IDENTITY_CARD,FLAG FROM PATIENTS where  PATIENT_ID=:PatientId";
		private static readonly string PATIENTS_Select_ALL = "SELECT PATIENT_ID,PATIENT_CREATE_DATE,PATIENT_NAME,PATIENT_GENDER,PATIENT_BIRTH,PATIENT_ADDRESS,PATIENT_ALLERGIES,PATIENT_TELPHONE,PATIENT_MEDICARE_CARD,PATIENT_IDENTITY_CARD,FLAG FROM PATIENTS";
		
		public DALPatients ()
		{
		}
		
		#region [获取参数SQL]
		/// <summary>
		///获取参数Patients SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertPatients")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@PatientCreateDate",SqlDbType.VarChar),
							new SqlParameter("@PatientName",SqlDbType.VarChar),
							new SqlParameter("@PatientGender",SqlDbType.VarChar),
							new SqlParameter("@PatientBirth",SqlDbType.VarChar),
							new SqlParameter("@PatientAddress",SqlDbType.VarChar),
							new SqlParameter("@PatientAllergies",SqlDbType.VarChar),
							new SqlParameter("@PatientTelphone",SqlDbType.VarChar),
							new SqlParameter("@PatientMedicareCard",SqlDbType.VarChar),
							new SqlParameter("@PatientIdentityCard",SqlDbType.VarChar),
							new SqlParameter("@Flag",SqlDbType.Decimal),
                    };
                }
				else if (sqlParms == "UpdatePatients")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@PatientCreateDate",SqlDbType.VarChar),
							new SqlParameter("@PatientName",SqlDbType.VarChar),
							new SqlParameter("@PatientGender",SqlDbType.VarChar),
							new SqlParameter("@PatientBirth",SqlDbType.VarChar),
							new SqlParameter("@PatientAddress",SqlDbType.VarChar),
							new SqlParameter("@PatientAllergies",SqlDbType.VarChar),
							new SqlParameter("@PatientTelphone",SqlDbType.VarChar),
							new SqlParameter("@PatientMedicareCard",SqlDbType.VarChar),
							new SqlParameter("@PatientIdentityCard",SqlDbType.VarChar),
							new SqlParameter("@Flag",SqlDbType.Decimal),
							new SqlParameter("@PatientId",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeletePatients")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectPatients")
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
		///Add    model  Patients 
		///Insert Table PATIENTS
		/// </summary>
		public int InsertPatientsSQL(Patients model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertPatients");
					if (model.PatientId != null)
						oneInert[0].Value = model.PatientId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.PatientCreateDate != null)
						oneInert[1].Value = model.PatientCreateDate;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.PatientName != null)
						oneInert[2].Value = model.PatientName;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.PatientGender != null)
						oneInert[3].Value = model.PatientGender;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.PatientBirth != null)
						oneInert[4].Value = model.PatientBirth;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.PatientAddress != null)
						oneInert[5].Value = model.PatientAddress;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.PatientAllergies != null)
						oneInert[6].Value = model.PatientAllergies;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.PatientTelphone != null)
						oneInert[7].Value = model.PatientTelphone;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.PatientMedicareCard != null)
						oneInert[8].Value = model.PatientMedicareCard;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.PatientIdentityCard != null)
						oneInert[9].Value = model.PatientIdentityCard;
					else
						oneInert[9].Value = DBNull.Value;
                    if (model.Flag.ToString() != null)
						oneInert[10].Value = model.Flag;
					else
						oneInert[10].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, PATIENTS_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  Patients 
		///Update Table     PATIENTS
		/// </summary>
		public int UpdatePatientsSQL(Patients model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdatePatients");
					if (model.PatientId != null)
						oneUpdate[0].Value = model.PatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.PatientCreateDate != null)
						oneUpdate[1].Value = model.PatientCreateDate;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.PatientName != null)
						oneUpdate[2].Value = model.PatientName;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.PatientGender != null)
						oneUpdate[3].Value = model.PatientGender;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.PatientBirth != null)
						oneUpdate[4].Value = model.PatientBirth;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.PatientAddress != null)
						oneUpdate[5].Value = model.PatientAddress;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.PatientAllergies != null)
						oneUpdate[6].Value = model.PatientAllergies;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.PatientTelphone != null)
						oneUpdate[7].Value = model.PatientTelphone;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.PatientMedicareCard != null)
						oneUpdate[8].Value = model.PatientMedicareCard;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.PatientIdentityCard != null)
						oneUpdate[9].Value = model.PatientIdentityCard;
					else
						oneUpdate[9].Value = DBNull.Value;
                    if (model.Flag.ToString() != null)
						oneUpdate[10].Value = model.Flag;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[11].Value =model.PatientId;
					else
						oneUpdate[11].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, PATIENTS_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  Patients 
		///Delete Table PATIENTS by (string PATIENT_ID)
		/// </summary>
		public int DeletePatientsSQL(string PATIENT_ID)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeletePatients");
					if (PATIENT_ID != null)
						oneDelete[0].Value =PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, PATIENTS_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  Patients 
		///select Table PATIENTS by (string PATIENT_ID)
		/// </summary>
		public Patients  SelectPatientsSQL(string PATIENT_ID)
		{
			Patients model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectPatients");
				parameterValues[0].Value=PATIENT_ID;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, PATIENTS_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new Patients();
						if (!oleReader.IsDBNull(0))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.PatientCreateDate = oleReader["PATIENT_CREATE_DATE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.PatientName = oleReader["PATIENT_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.PatientGender = oleReader["PATIENT_GENDER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.PatientBirth = oleReader["PATIENT_BIRTH"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.PatientAddress = oleReader["PATIENT_ADDRESS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.PatientAllergies = oleReader["PATIENT_ALLERGIES"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.PatientTelphone = oleReader["PATIENT_TELPHONE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.PatientMedicareCard = oleReader["PATIENT_MEDICARE_CARD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.PatientIdentityCard = oleReader["PATIENT_IDENTITY_CARD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Flag = decimal.Parse(oleReader["FLAG"].ToString().Trim()) ;
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
		public List<Patients> SelectPatientsListSQL()
		{
			List<Patients> modelList = new List<Patients>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, PATIENTS_Select_ALL_SQL, null))
			{
				while (oleReader.Read())
				{
					Patients model = new Patients();
						if (!oleReader.IsDBNull(0))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.PatientCreateDate = oleReader["PATIENT_CREATE_DATE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.PatientName = oleReader["PATIENT_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.PatientGender = oleReader["PATIENT_GENDER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.PatientBirth = oleReader["PATIENT_BIRTH"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.PatientAddress = oleReader["PATIENT_ADDRESS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.PatientAllergies = oleReader["PATIENT_ALLERGIES"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.PatientTelphone = oleReader["PATIENT_TELPHONE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.PatientMedicareCard = oleReader["PATIENT_MEDICARE_CARD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.PatientIdentityCard = oleReader["PATIENT_IDENTITY_CARD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Flag = decimal.Parse(oleReader["FLAG"].ToString().Trim()) ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [获取参数]
		/// <summary>
		///获取参数Patients
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertPatients")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":PatientCreateDate",OracleType.VarChar),
							new OracleParameter(":PatientName",OracleType.VarChar),
							new OracleParameter(":PatientGender",OracleType.VarChar),
							new OracleParameter(":PatientBirth",OracleType.VarChar),
							new OracleParameter(":PatientAddress",OracleType.VarChar),
							new OracleParameter(":PatientAllergies",OracleType.VarChar),
							new OracleParameter(":PatientTelphone",OracleType.VarChar),
							new OracleParameter(":PatientMedicareCard",OracleType.VarChar),
							new OracleParameter(":PatientIdentityCard",OracleType.VarChar),
							new OracleParameter(":Flag",OracleType.Number),
                    };
                }
				else if (sqlParms == "UpdatePatients")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":PatientCreateDate",OracleType.VarChar),
							new OracleParameter(":PatientName",OracleType.VarChar),
							new OracleParameter(":PatientGender",OracleType.VarChar),
							new OracleParameter(":PatientBirth",OracleType.VarChar),
							new OracleParameter(":PatientAddress",OracleType.VarChar),
							new OracleParameter(":PatientAllergies",OracleType.VarChar),
							new OracleParameter(":PatientTelphone",OracleType.VarChar),
							new OracleParameter(":PatientMedicareCard",OracleType.VarChar),
							new OracleParameter(":PatientIdentityCard",OracleType.VarChar),
							new OracleParameter(":Flag",OracleType.Number),
							new OracleParameter(":PatientId",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "DeletePatients")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "SelectPatients")
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
		///Add    model  Patients 
		///Insert Table PATIENTS
		/// </summary>
		public int InsertPatients(Patients model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertPatients");
					if (model.PatientId != null)
						oneInert[0].Value = model.PatientId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.PatientCreateDate != null)
						oneInert[1].Value = model.PatientCreateDate;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.PatientName != null)
						oneInert[2].Value = model.PatientName;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.PatientGender != null)
						oneInert[3].Value = model.PatientGender;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.PatientBirth != null)
						oneInert[4].Value = model.PatientBirth;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.PatientAddress != null)
						oneInert[5].Value = model.PatientAddress;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.PatientAllergies != null)
						oneInert[6].Value = model.PatientAllergies;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.PatientTelphone != null)
						oneInert[7].Value = model.PatientTelphone;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.PatientMedicareCard != null)
						oneInert[8].Value = model.PatientMedicareCard;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.PatientIdentityCard != null)
						oneInert[9].Value = model.PatientIdentityCard;
					else
						oneInert[9].Value = DBNull.Value;
                    if (model.Flag.ToString() != null)
						oneInert[10].Value = model.Flag;
					else
						oneInert[10].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, PATIENTS_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  Patients 
		///Update Table     PATIENTS
		/// </summary>
		public int UpdatePatients(Patients model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdatePatients");
					if (model.PatientId != null)
						oneUpdate[0].Value = model.PatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.PatientCreateDate != null)
						oneUpdate[1].Value = model.PatientCreateDate;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.PatientName != null)
						oneUpdate[2].Value = model.PatientName;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.PatientGender != null)
						oneUpdate[3].Value = model.PatientGender;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.PatientBirth != null)
						oneUpdate[4].Value = model.PatientBirth;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.PatientAddress != null)
						oneUpdate[5].Value = model.PatientAddress;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.PatientAllergies != null)
						oneUpdate[6].Value = model.PatientAllergies;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.PatientTelphone != null)
						oneUpdate[7].Value = model.PatientTelphone;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.PatientMedicareCard != null)
						oneUpdate[8].Value = model.PatientMedicareCard;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.PatientIdentityCard != null)
						oneUpdate[9].Value = model.PatientIdentityCard;
					else
						oneUpdate[9].Value = DBNull.Value;
                    if (model.Flag.ToString() != null)
						oneUpdate[10].Value = model.Flag;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[11].Value =model.PatientId;
					else
						oneUpdate[11].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, PATIENTS_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  Patients 
		///Delete Table PATIENTS by (string PATIENT_ID)
		/// </summary>
		public int DeletePatients(string PATIENT_ID)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeletePatients");
					if (PATIENT_ID != null)
						oneDelete[0].Value =PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, PATIENTS_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  Patients 
		///select Table PATIENTS by (string PATIENT_ID)
		/// </summary>
		public Patients  SelectPatients(string PATIENT_ID)
		{
			Patients model;
			OracleParameter[] parameterValues = GetParameter("SelectPatients");
				parameterValues[0].Value=PATIENT_ID;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, PATIENTS_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new Patients();
						if (!oleReader.IsDBNull(0))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.PatientCreateDate = oleReader["PATIENT_CREATE_DATE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.PatientName = oleReader["PATIENT_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.PatientGender = oleReader["PATIENT_GENDER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.PatientBirth = oleReader["PATIENT_BIRTH"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.PatientAddress = oleReader["PATIENT_ADDRESS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.PatientAllergies = oleReader["PATIENT_ALLERGIES"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.PatientTelphone = oleReader["PATIENT_TELPHONE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.PatientMedicareCard = oleReader["PATIENT_MEDICARE_CARD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.PatientIdentityCard = oleReader["PATIENT_IDENTITY_CARD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Flag = decimal.Parse(oleReader["FLAG"].ToString().Trim()) ;
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
		public List<Patients> SelectPatientsList()
		{
			List<Patients> modelList = new List<Patients>();
		    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, PATIENTS_Select_ALL, null))
			{
				while (oleReader.Read())
				{
					Patients model = new Patients();
						if (!oleReader.IsDBNull(0))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.PatientCreateDate = oleReader["PATIENT_CREATE_DATE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.PatientName = oleReader["PATIENT_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.PatientGender = oleReader["PATIENT_GENDER"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.PatientBirth = oleReader["PATIENT_BIRTH"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.PatientAddress = oleReader["PATIENT_ADDRESS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.PatientAllergies = oleReader["PATIENT_ALLERGIES"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.PatientTelphone = oleReader["PATIENT_TELPHONE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.PatientMedicareCard = oleReader["PATIENT_MEDICARE_CARD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.PatientIdentityCard = oleReader["PATIENT_IDENTITY_CARD"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Flag = decimal.Parse(oleReader["FLAG"].ToString().Trim()) ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
