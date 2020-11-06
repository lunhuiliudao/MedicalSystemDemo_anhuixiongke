

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
using System.Data.OleDb;
using System.Data.Odbc;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL Patients
	/// </summary>
	
	public partial class DALPatients
	{
		private static readonly string PATIENTS_Insert_OLE = "INSERT INTO PATIENTS (PATIENT_ID,PATIENT_CREATE_DATE,PATIENT_NAME,PATIENT_GENDER,PATIENT_BIRTH,PATIENT_ADDRESS,PATIENT_ALLERGIES,PATIENT_TELPHONE,PATIENT_MEDICARE_CARD,PATIENT_IDENTITY_CARD,FLAG) values (?,?,?,?,?,?,?,?,?,?,?)";
		private static readonly string PATIENTS_Update_OLE = "UPDATE PATIENTS SET PATIENT_ID=?,PATIENT_CREATE_DATE=?,PATIENT_NAME=?,PATIENT_GENDER=?,PATIENT_BIRTH=?,PATIENT_ADDRESS=?,PATIENT_ALLERGIES=?,PATIENT_TELPHONE=?,PATIENT_MEDICARE_CARD=?,PATIENT_IDENTITY_CARD=?,FLAG=? WHERE  PATIENT_ID=?";
		private static readonly string PATIENTS_Delete_OLE = "DELETE PATIENTS WHERE  PATIENT_ID=?";
		private static readonly string PATIENTS_Select_OLE = "SELECT PATIENT_ID,PATIENT_CREATE_DATE,PATIENT_NAME,PATIENT_GENDER,PATIENT_BIRTH,PATIENT_ADDRESS,PATIENT_ALLERGIES,PATIENT_TELPHONE,PATIENT_MEDICARE_CARD,PATIENT_IDENTITY_CARD,FLAG FROM PATIENTS where  PATIENT_ID=?";
		private static readonly string PATIENTS_Select_ALL_OLE = "SELECT PATIENT_ID,PATIENT_CREATE_DATE,PATIENT_NAME,PATIENT_GENDER,PATIENT_BIRTH,PATIENT_ADDRESS,PATIENT_ALLERGIES,PATIENT_TELPHONE,PATIENT_MEDICARE_CARD,PATIENT_IDENTITY_CARD,FLAG FROM PATIENTS";
        
		
		#region [获取参数OLE]
		/// <summary>
		///获取参数Patients OLE
		/// </summary>
		public static OleDbParameter[] GetParameterOLE(string OLEParms)
		{
			OleDbParameter[] parms = OleDbHelper.GetCachedParameters(OLEParms);
            if (parms == null)
            {
                if (OLEParms == "InsertPatients")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("PatientCreateDate",OleDbType.VarChar),
							new OleDbParameter("PatientName",OleDbType.VarChar),
							new OleDbParameter("PatientGender",OleDbType.VarChar),
							new OleDbParameter("PatientBirth",OleDbType.VarChar),
							new OleDbParameter("PatientAddress",OleDbType.VarChar),
							new OleDbParameter("PatientAllergies",OleDbType.VarChar),
							new OleDbParameter("PatientTelphone",OleDbType.VarChar),
							new OleDbParameter("PatientMedicareCard",OleDbType.VarChar),
							new OleDbParameter("PatientIdentityCard",OleDbType.VarChar),
							new OleDbParameter("Flag",OleDbType.Decimal),
                    };
                }
				else if (OLEParms == "UpdatePatients")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("PatientCreateDate",OleDbType.VarChar),
							new OleDbParameter("PatientName",OleDbType.VarChar),
							new OleDbParameter("PatientGender",OleDbType.VarChar),
							new OleDbParameter("PatientBirth",OleDbType.VarChar),
							new OleDbParameter("PatientAddress",OleDbType.VarChar),
							new OleDbParameter("PatientAllergies",OleDbType.VarChar),
							new OleDbParameter("PatientTelphone",OleDbType.VarChar),
							new OleDbParameter("PatientMedicareCard",OleDbType.VarChar),
							new OleDbParameter("PatientIdentityCard",OleDbType.VarChar),
							new OleDbParameter("Flag",OleDbType.Decimal),
							new OleDbParameter("PatientId",OleDbType.VarChar),
                    };
                }
				else if(OLEParms == "DeletePatients")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
                    };
                }
				else if(OLEParms == "SelectPatients")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
                    };
                }
            	OleDbHelper.CacheParameters(OLEParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录OLE]
		/// <summary>
		///Add    model  Patients 
		///Insert Table PATIENTS
		/// </summary>
		public int InsertPatientsOLE(Patients model)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
				OleDbParameter[] oneInert = GetParameterOLE("InsertPatients");
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
			
				return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, PATIENTS_Insert_OLE, oneInert);
			}
		}
		#endregion
		#region [更新一条记录OLE]
		/// <summary>
		///Update    model  Patients 
		///Update Table     PATIENTS
		/// </summary>
		public int UpdatePatientsOLE(Patients model)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
				OleDbParameter[] oneUpdate = GetParameterOLE("UpdatePatients");
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
			
				return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, PATIENTS_Update_OLE, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录OLE]
		/// <summary>
		///Delete    model  Patients 
		///Delete Table PATIENTS by (string PATIENT_ID)
		/// </summary>
		public int DeletePatientsOLE(string PATIENT_ID)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
				OleDbParameter[] oneDelete = GetParameterOLE("DeletePatients");
					if (PATIENT_ID != null)
						oneDelete[0].Value =PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, PATIENTS_Delete_OLE, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录OLE]
		/// <summary>
		///Select    model  Patients 
		///select Table PATIENTS by (string PATIENT_ID)
		/// </summary>
		public Patients  SelectPatientsOLE(string PATIENT_ID)
		{
			Patients model;
			OleDbParameter[] parameterValues = GetParameterOLE("SelectPatients");
				parameterValues[0].Value=PATIENT_ID;
			using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, PATIENTS_Select_OLE, parameterValues))
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
		#region  [获取所有记录OLE]
		/// <summary>
		///获取所有记录
		/// </summary>
		public List<Patients> SelectPatientsListOLE()
		{
			List<Patients> modelList = new List<Patients>();
		    using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, PATIENTS_Select_ALL_OLE, null))
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
		
        private static readonly string PATIENTS_Insert_ODBC = "INSERT INTO PATIENTS (PATIENT_ID,PATIENT_CREATE_DATE,PATIENT_NAME,PATIENT_GENDER,PATIENT_BIRTH,PATIENT_ADDRESS,PATIENT_ALLERGIES,PATIENT_TELPHONE,PATIENT_MEDICARE_CARD,PATIENT_IDENTITY_CARD,FLAG) values (?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string PATIENTS_Update_ODBC = "UPDATE PATIENTS SET PATIENT_ID=?,PATIENT_CREATE_DATE=?,PATIENT_NAME=?,PATIENT_GENDER=?,PATIENT_BIRTH=?,PATIENT_ADDRESS=?,PATIENT_ALLERGIES=?,PATIENT_TELPHONE=?,PATIENT_MEDICARE_CARD=?,PATIENT_IDENTITY_CARD=?,FLAG=? WHERE  PATIENT_ID=?";
        private static readonly string PATIENTS_Delete_ODBC = "DELETE PATIENTS WHERE  PATIENT_ID=?";
        private static readonly string PATIENTS_Select_ODBC = "SELECT PATIENT_ID,PATIENT_CREATE_DATE,PATIENT_NAME,PATIENT_GENDER,PATIENT_BIRTH,PATIENT_ADDRESS,PATIENT_ALLERGIES,PATIENT_TELPHONE,PATIENT_MEDICARE_CARD,PATIENT_IDENTITY_CARD,FLAG FROM PATIENTS where  PATIENT_ID=?";
        private static readonly string PATIENTS_Select_ALL_ODBC = "SELECT PATIENT_ID,PATIENT_CREATE_DATE,PATIENT_NAME,PATIENT_GENDER,PATIENT_BIRTH,PATIENT_ADDRESS,PATIENT_ALLERGIES,PATIENT_TELPHONE,PATIENT_MEDICARE_CARD,PATIENT_IDENTITY_CARD,FLAG FROM PATIENTS";
		

		#region [获取参数ODBC]
		/// <summary>
		///获取参数Patients
		/// </summary>
		public static OdbcParameter[] GetParameterODBC(string OLEParms)
		{
			OdbcParameter[] parms = OdbcHelper.GetCachedParameters(OLEParms);
            if (parms == null)
            {
                if (OLEParms == "InsertPatients")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("PatientCreateDate",OdbcType.VarChar),
							new OdbcParameter("PatientName",OdbcType.VarChar),
							new OdbcParameter("PatientGender",OdbcType.VarChar),
							new OdbcParameter("PatientBirth",OdbcType.VarChar),
							new OdbcParameter("PatientAddress",OdbcType.VarChar),
							new OdbcParameter("PatientAllergies",OdbcType.VarChar),
							new OdbcParameter("PatientTelphone",OdbcType.VarChar),
							new OdbcParameter("PatientMedicareCard",OdbcType.VarChar),
							new OdbcParameter("PatientIdentityCard",OdbcType.VarChar),
							new OdbcParameter("Flag",OdbcType.Numeric),
                    };
                }
				else if (OLEParms == "UpdatePatients")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("PatientCreateDate",OdbcType.VarChar),
							new OdbcParameter("PatientName",OdbcType.VarChar),
							new OdbcParameter("PatientGender",OdbcType.VarChar),
							new OdbcParameter("PatientBirth",OdbcType.VarChar),
							new OdbcParameter("PatientAddress",OdbcType.VarChar),
							new OdbcParameter("PatientAllergies",OdbcType.VarChar),
							new OdbcParameter("PatientTelphone",OdbcType.VarChar),
							new OdbcParameter("PatientMedicareCard",OdbcType.VarChar),
							new OdbcParameter("PatientIdentityCard",OdbcType.VarChar),
							new OdbcParameter("Flag",OdbcType.Numeric),
							new OdbcParameter("PatientId",OdbcType.VarChar),
                    };
                }
				else if(OLEParms == "DeletePatients")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
                    };
                }
				else if(OLEParms == "SelectPatients")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
                    };
                }
            	OdbcHelper.CacheParameters(OLEParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  Patients 
		///Insert Table PATIENTS
		/// </summary>
		public int InsertPatientsOdbc(Patients model)
		{
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
				OdbcParameter[] oneInert = GetParameterODBC("InsertPatients");
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

                    return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString,CommandType.Text, PATIENTS_Insert_ODBC, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  Patients 
		///Update Table     PATIENTS
		/// </summary>
		public int UpdatePatientsOdbc(Patients model)
		{
			using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
				OdbcParameter[] oneUpdate = GetParameterODBC("UpdatePatients");
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

                    return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString,CommandType.Text, PATIENTS_Update_ODBC, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  Patients 
		///Delete Table PATIENTS by (string PATIENT_ID)
		/// </summary>
		public int DeletePatientsOdbc(string PATIENT_ID)
		{
			using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
				OdbcParameter[] oneDelete = GetParameterODBC("DeletePatients");
				if (PATIENT_ID != null)
					oneDelete[0].Value =PATIENT_ID;
				else
					oneDelete[0].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, PATIENTS_Delete_ODBC, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  Patients 
		///select Table PATIENTS by (string PATIENT_ID)
		/// </summary>
		public Patients  SelectPatientsOdbc(string PATIENT_ID)
		{
			Patients model;
			OdbcParameter[] parameterValues = GetParameterODBC("SelectPatients");
			parameterValues[0].Value=PATIENT_ID;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, PATIENTS_Select_ODBC, parameterValues))
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
		public List<Patients> SelectPatientsListOdbc()
		{
			List<Patients> modelList = new List<Patients>();
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, PATIENTS_Select_ALL_ODBC, null))
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
