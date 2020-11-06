

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2011-06-12 12:28:21
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
	/// DAL Medicalcases
	/// </summary>
	
	public partial class DALMedicalcases
	{
		private static readonly string MEDICALCASES_Insert_OLE = "INSERT INTO MEDICALCASES (MEDICAL_ID,PATIENT_ID,PATIENT_NAME,USER_ID,USER_NAME,OFFICE_NAME,CREATE_DATE,CREATE_TIME,VISIT_DATE,VISIT_NO,VISIT_TIME,FLAG,SIGN_PAGE) values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
		private static readonly string MEDICALCASES_Update_OLE = "UPDATE MEDICALCASES SET MEDICAL_ID=?,PATIENT_ID=?,PATIENT_NAME=?,USER_ID=?,USER_NAME=?,OFFICE_NAME=?,CREATE_DATE=?,CREATE_TIME=?,VISIT_DATE=?,VISIT_NO=?,VISIT_TIME=?,FLAG=?,SIGN_PAGE=? WHERE  MEDICAL_ID=?";
		private static readonly string MEDICALCASES_Delete_OLE = "DELETE MEDICALCASES WHERE  MEDICAL_ID=?";
		private static readonly string MEDICALCASES_Select_OLE = "SELECT MEDICAL_ID,PATIENT_ID,PATIENT_NAME,USER_ID,USER_NAME,OFFICE_NAME,CREATE_DATE,CREATE_TIME,VISIT_DATE,VISIT_NO,VISIT_TIME,FLAG,SIGN_PAGE FROM MEDICALCASES where  MEDICAL_ID=?";
		private static readonly string MEDICALCASES_Select_ALL_OLE = "SELECT MEDICAL_ID,PATIENT_ID,PATIENT_NAME,USER_ID,USER_NAME,OFFICE_NAME,CREATE_DATE,CREATE_TIME,VISIT_DATE,VISIT_NO,VISIT_TIME,FLAG,SIGN_PAGE FROM MEDICALCASES";
        
		
		#region [获取参数OLE]
		/// <summary>
		///获取参数Medicalcases OLE
		/// </summary>
		public static OleDbParameter[] GetParameterOLE(string OLEParms)
		{
			OleDbParameter[] parms = OleDbHelper.GetCachedParameters(OLEParms);
            if (parms == null)
            {
                if (OLEParms == "InsertMedicalcases")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("MedicalId",OleDbType.VarChar),
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("PatientName",OleDbType.VarChar),
							new OleDbParameter("UserId",OleDbType.VarChar),
							new OleDbParameter("UserName",OleDbType.VarChar),
							new OleDbParameter("OfficeName",OleDbType.VarChar),
							new OleDbParameter("CreateDate",OleDbType.VarChar),
							new OleDbParameter("CreateTime",OleDbType.VarChar),
							new OleDbParameter("VisitDate",OleDbType.VarChar),
							new OleDbParameter("VisitNo",OleDbType.VarChar),
							new OleDbParameter("VisitTime",OleDbType.DBTimeStamp),
							new OleDbParameter("Flag",OleDbType.Decimal),
							new OleDbParameter("SignPage",OleDbType.Decimal),
                    };
                }
				else if (OLEParms == "UpdateMedicalcases")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("MedicalId",OleDbType.VarChar),
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("PatientName",OleDbType.VarChar),
							new OleDbParameter("UserId",OleDbType.VarChar),
							new OleDbParameter("UserName",OleDbType.VarChar),
							new OleDbParameter("OfficeName",OleDbType.VarChar),
							new OleDbParameter("CreateDate",OleDbType.VarChar),
							new OleDbParameter("CreateTime",OleDbType.VarChar),
							new OleDbParameter("VisitDate",OleDbType.VarChar),
							new OleDbParameter("VisitNo",OleDbType.VarChar),
							new OleDbParameter("VisitTime",OleDbType.DBTimeStamp),
							new OleDbParameter("Flag",OleDbType.Decimal),
							new OleDbParameter("SignPage",OleDbType.Decimal),
							new OleDbParameter("MedicalId",OleDbType.VarChar),
                    };
                }
				else if(OLEParms == "DeleteMedicalcases")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("MedicalId",OleDbType.VarChar),
                    };
                }
				else if(OLEParms == "SelectMedicalcases")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("MedicalId",OleDbType.VarChar),
                    };
                }
            	OleDbHelper.CacheParameters(OLEParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录OLE]
		/// <summary>
		///Add    model  Medicalcases 
		///Insert Table MEDICALCASES
		/// </summary>
		public int InsertMedicalcasesOLE(Medicalcases model)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
				OleDbParameter[] oneInert = GetParameterOLE("InsertMedicalcases");
					if (model.MedicalId != null)
						oneInert[0].Value = model.MedicalId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.PatientId != null)
						oneInert[1].Value = model.PatientId;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.PatientName != null)
						oneInert[2].Value = model.PatientName;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.UserId != null)
						oneInert[3].Value = model.UserId;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.UserName != null)
						oneInert[4].Value = model.UserName;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.OfficeName != null)
						oneInert[5].Value = model.OfficeName;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.CreateDate != null)
						oneInert[6].Value = model.CreateDate;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.CreateTime != null)
						oneInert[7].Value = model.CreateTime;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.VisitDate != null)
						oneInert[8].Value = model.VisitDate;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.VisitNo != null)
						oneInert[9].Value = model.VisitNo;
					else
						oneInert[9].Value = DBNull.Value;
                    if (model.VisitTime > DateTime.MinValue)
						oneInert[10].Value = model.VisitTime;
					else
						oneInert[10].Value = DBNull.Value;
                    if (model.Flag.ToString() != null)
						oneInert[11].Value = model.Flag;
					else
						oneInert[11].Value = DBNull.Value;
                    if (model.SignPage.ToString() != null)
						oneInert[12].Value = model.SignPage;
					else
						oneInert[12].Value = DBNull.Value;
			
				return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MEDICALCASES_Insert_OLE, oneInert);
			}
		}
		#endregion
		#region [更新一条记录OLE]
		/// <summary>
		///Update    model  Medicalcases 
		///Update Table     MEDICALCASES
		/// </summary>
		public int UpdateMedicalcasesOLE(Medicalcases model)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
				OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedicalcases");
					if (model.MedicalId != null)
						oneUpdate[0].Value = model.MedicalId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[1].Value = model.PatientId;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.PatientName != null)
						oneUpdate[2].Value = model.PatientName;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.UserId != null)
						oneUpdate[3].Value = model.UserId;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.UserName != null)
						oneUpdate[4].Value = model.UserName;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.OfficeName != null)
						oneUpdate[5].Value = model.OfficeName;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.CreateDate != null)
						oneUpdate[6].Value = model.CreateDate;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.CreateTime != null)
						oneUpdate[7].Value = model.CreateTime;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.VisitDate != null)
						oneUpdate[8].Value = model.VisitDate;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.VisitNo != null)
						oneUpdate[9].Value = model.VisitNo;
					else
						oneUpdate[9].Value = DBNull.Value;
                    if (model.VisitTime > DateTime.MinValue)
						oneUpdate[10].Value = model.VisitTime;
					else
						oneUpdate[10].Value = DBNull.Value;
                    if (model.Flag.ToString() != null)
						oneUpdate[11].Value = model.Flag;
					else
						oneUpdate[11].Value = DBNull.Value;
                    if (model.SignPage.ToString() != null)
						oneUpdate[12].Value = model.SignPage;
					else
						oneUpdate[12].Value = DBNull.Value;
					if (model.MedicalId != null)
						oneUpdate[13].Value =model.MedicalId;
					else
						oneUpdate[13].Value = DBNull.Value;
			
				return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString,CommandType.Text, MEDICALCASES_Update_OLE, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录OLE]
		/// <summary>
		///Delete    model  Medicalcases 
		///Delete Table MEDICALCASES by (string MEDICAL_ID)
		/// </summary>
		public int DeleteMedicalcasesOLE(string MEDICAL_ID)
		{
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
				OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedicalcases");
					if (MEDICAL_ID != null)
						oneDelete[0].Value =MEDICAL_ID;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MEDICALCASES_Delete_OLE, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录OLE]
		/// <summary>
		///Select    model  Medicalcases 
		///select Table MEDICALCASES by (string MEDICAL_ID)
		/// </summary>
		public Medicalcases  SelectMedicalcasesOLE(string MEDICAL_ID)
		{
			Medicalcases model;
			OleDbParameter[] parameterValues = GetParameterOLE("SelectMedicalcases");
				parameterValues[0].Value=MEDICAL_ID;
			using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MEDICALCASES_Select_OLE, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new Medicalcases();
						if (!oleReader.IsDBNull(0))
						{
							model.MedicalId = oleReader["MEDICAL_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.PatientName = oleReader["PATIENT_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.UserId = oleReader["USER_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.UserName = oleReader["USER_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.OfficeName = oleReader["OFFICE_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.CreateDate = oleReader["CREATE_DATE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.CreateTime = oleReader["CREATE_TIME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.VisitDate = oleReader["VISIT_DATE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.VisitNo = oleReader["VISIT_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.VisitTime = DateTime.Parse(oleReader["VISIT_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Flag = decimal.Parse(oleReader["FLAG"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.SignPage = decimal.Parse(oleReader["SIGN_PAGE"].ToString().Trim()) ;
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
		public List<Medicalcases> SelectMedicalcasesListOLE()
		{
			List<Medicalcases> modelList = new List<Medicalcases>();
		    using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MEDICALCASES_Select_ALL_OLE, null))
			{
				while (oleReader.Read())
				{
					Medicalcases model = new Medicalcases();
						if (!oleReader.IsDBNull(0))
						{
							model.MedicalId = oleReader["MEDICAL_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.PatientName = oleReader["PATIENT_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.UserId = oleReader["USER_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.UserName = oleReader["USER_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.OfficeName = oleReader["OFFICE_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.CreateDate = oleReader["CREATE_DATE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.CreateTime = oleReader["CREATE_TIME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.VisitDate = oleReader["VISIT_DATE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.VisitNo = oleReader["VISIT_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.VisitTime = DateTime.Parse(oleReader["VISIT_TIME"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Flag = decimal.Parse(oleReader["FLAG"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.SignPage = decimal.Parse(oleReader["SIGN_PAGE"].ToString().Trim()) ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
        private static readonly string MEDICALCASES_Insert_ODBC = "INSERT INTO MEDICALCASES (MEDICAL_ID,PATIENT_ID,PATIENT_NAME,USER_ID,USER_NAME,OFFICE_NAME,CREATE_DATE,CREATE_TIME,VISIT_DATE,VISIT_NO,VISIT_TIME,FLAG,SIGN_PAGE) values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string MEDICALCASES_Update_ODBC = "UPDATE MEDICALCASES SET MEDICAL_ID=?,PATIENT_ID=?,PATIENT_NAME=?,USER_ID=?,USER_NAME=?,OFFICE_NAME=?,CREATE_DATE=?,CREATE_TIME=?,VISIT_DATE=?,VISIT_NO=?,VISIT_TIME=?,FLAG=?,SIGN_PAGE=? WHERE  MEDICAL_ID=?";
        private static readonly string MEDICALCASES_Delete_ODBC = "DELETE MEDICALCASES WHERE  MEDICAL_ID=?";
        private static readonly string MEDICALCASES_Select_ODBC = "SELECT MEDICAL_ID,PATIENT_ID,PATIENT_NAME,USER_ID,USER_NAME,OFFICE_NAME,CREATE_DATE,CREATE_TIME,VISIT_DATE,VISIT_NO,VISIT_TIME,FLAG,SIGN_PAGE FROM MEDICALCASES where  MEDICAL_ID=?";
        private static readonly string MEDICALCASES_Select_ALL_ODBC = "SELECT MEDICAL_ID,PATIENT_ID,PATIENT_NAME,USER_ID,USER_NAME,OFFICE_NAME,CREATE_DATE,CREATE_TIME,VISIT_DATE,VISIT_NO,VISIT_TIME,FLAG,SIGN_PAGE FROM MEDICALCASES";

		#region [获取参数ODBC]
		/// <summary>
		///获取参数Medicalcases
		/// </summary>
		public static OdbcParameter[] GetParameterODBC(string OLEParms)
		{
			OdbcParameter[] parms = OdbcHelper.GetCachedParameters(OLEParms);
            if (parms == null)
            {
                if (OLEParms == "InsertMedicalcases")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("MedicalId",OdbcType.VarChar),
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("PatientName",OdbcType.VarChar),
							new OdbcParameter("UserId",OdbcType.VarChar),
							new OdbcParameter("UserName",OdbcType.VarChar),
							new OdbcParameter("OfficeName",OdbcType.VarChar),
							new OdbcParameter("CreateDate",OdbcType.VarChar),
							new OdbcParameter("CreateTime",OdbcType.VarChar),
							new OdbcParameter("VisitDate",OdbcType.VarChar),
							new OdbcParameter("VisitNo",OdbcType.VarChar),
							new OdbcParameter("VisitTime",OdbcType.DateTime),
							new OdbcParameter("Flag",OdbcType.Numeric),
							new OdbcParameter("SignPage",OdbcType.Numeric),
                    };
                }
				else if (OLEParms == "UpdateMedicalcases")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("MedicalId",OdbcType.VarChar),
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("PatientName",OdbcType.VarChar),
							new OdbcParameter("UserId",OdbcType.VarChar),
							new OdbcParameter("UserName",OdbcType.VarChar),
							new OdbcParameter("OfficeName",OdbcType.VarChar),
							new OdbcParameter("CreateDate",OdbcType.VarChar),
							new OdbcParameter("CreateTime",OdbcType.VarChar),
							new OdbcParameter("VisitDate",OdbcType.VarChar),
							new OdbcParameter("VisitNo",OdbcType.VarChar),
							new OdbcParameter("VisitTime",OdbcType.DateTime),
							new OdbcParameter("Flag",OdbcType.Numeric),
							new OdbcParameter("SignPage",OdbcType.Numeric),
							new OdbcParameter("MedicalId",OdbcType.VarChar),
                    };
                }
				else if(OLEParms == "DeleteMedicalcases")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("MedicalId",OdbcType.VarChar),
                    };
                }
				else if(OLEParms == "SelectMedicalcases")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("MedicalId",OdbcType.VarChar),
                    };
                }
            	OdbcHelper.CacheParameters(OLEParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  Medicalcases 
		///Insert Table MEDICALCASES
		/// </summary>
        public int InsertMedicalcasesOdbc(Medicalcases model)
		{
			using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
				OdbcParameter[] oneInert = GetParameterODBC("InsertMedicalcases");
					if (model.MedicalId != null)
						oneInert[0].Value = model.MedicalId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.PatientId != null)
						oneInert[1].Value = model.PatientId;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.PatientName != null)
						oneInert[2].Value = model.PatientName;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.UserId != null)
						oneInert[3].Value = model.UserId;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.UserName != null)
						oneInert[4].Value = model.UserName;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.OfficeName != null)
						oneInert[5].Value = model.OfficeName;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.CreateDate != null)
						oneInert[6].Value = model.CreateDate;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.CreateTime != null)
						oneInert[7].Value = model.CreateTime;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.VisitDate != null)
						oneInert[8].Value = model.VisitDate;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.VisitNo != null)
						oneInert[9].Value = model.VisitNo;
					else
						oneInert[9].Value = DBNull.Value;
                    if (model.VisitTime > DateTime.MinValue)
						oneInert[10].Value = model.VisitTime;
					else
						oneInert[10].Value = DBNull.Value;
                    if (model.Flag.ToString() != null)
						oneInert[11].Value = model.Flag;
					else
						oneInert[11].Value = DBNull.Value;
                    if (model.SignPage.ToString() != null)
						oneInert[12].Value = model.SignPage;
					else
						oneInert[12].Value = DBNull.Value;

                    return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MEDICALCASES_Insert_ODBC, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  Medicalcases 
		///Update Table     MEDICALCASES
		/// </summary>
        public int UpdateMedicalcasesOdbc(Medicalcases model)
		{
			using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
				OdbcParameter[] oneUpdate = GetParameterODBC("UpdateMedicalcases");
					if (model.MedicalId != null)
						oneUpdate[0].Value = model.MedicalId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[1].Value = model.PatientId;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.PatientName != null)
						oneUpdate[2].Value = model.PatientName;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.UserId != null)
						oneUpdate[3].Value = model.UserId;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.UserName != null)
						oneUpdate[4].Value = model.UserName;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.OfficeName != null)
						oneUpdate[5].Value = model.OfficeName;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.CreateDate != null)
						oneUpdate[6].Value = model.CreateDate;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.CreateTime != null)
						oneUpdate[7].Value = model.CreateTime;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.VisitDate != null)
						oneUpdate[8].Value = model.VisitDate;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.VisitNo != null)
						oneUpdate[9].Value = model.VisitNo;
					else
						oneUpdate[9].Value = DBNull.Value;
                    if (model.VisitTime > DateTime.MinValue)
						oneUpdate[10].Value = model.VisitTime;
					else
						oneUpdate[10].Value = DBNull.Value;
                    if (model.Flag.ToString() != null)
						oneUpdate[11].Value = model.Flag;
					else
						oneUpdate[11].Value = DBNull.Value;
                    if (model.SignPage.ToString() != null)
						oneUpdate[12].Value = model.SignPage;
					else
						oneUpdate[12].Value = DBNull.Value;
					if (model.MedicalId != null)
						oneUpdate[13].Value =model.MedicalId;
					else
						oneUpdate[13].Value = DBNull.Value;

                    return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString,CommandType.Text, MEDICALCASES_Update_ODBC, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  Medicalcases 
		///Delete Table MEDICALCASES by (string MEDICAL_ID)
		/// </summary>
		public int DeleteMedicalcasesOdbc(string MEDICAL_ID)
		{
			using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
				OdbcParameter[] oneDelete = GetParameterODBC("DeleteMedicalcases");
					if (MEDICAL_ID != null)
						oneDelete[0].Value =MEDICAL_ID;
					else
						oneDelete[0].Value = DBNull.Value;

                    return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MEDICALCASES_Delete_ODBC, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  Medicalcases 
		///select Table MEDICALCASES by (string MEDICAL_ID)
		/// </summary>
		public Medicalcases  SelectMedicalcasesOdbc(string MEDICAL_ID)
		{
			Medicalcases model;
			OdbcParameter[] parameterValues = GetParameterODBC("SelectMedicalcases");
				parameterValues[0].Value=MEDICAL_ID;
                using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MEDICALCASES_Select_ODBC, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new Medicalcases();
					if (!oleReader.IsDBNull(0))
					{
						model.MedicalId = oleReader["MEDICAL_ID"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(1))
					{
						model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(2))
					{
						model.PatientName = oleReader["PATIENT_NAME"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(3))
					{
						model.UserId = oleReader["USER_ID"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(4))
					{
						model.UserName = oleReader["USER_NAME"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(5))
					{
						model.OfficeName = oleReader["OFFICE_NAME"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(6))
					{
						model.CreateDate = oleReader["CREATE_DATE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(7))
					{
						model.CreateTime = oleReader["CREATE_TIME"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(8))
					{
						model.VisitDate = oleReader["VISIT_DATE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(9))
					{
						model.VisitNo = oleReader["VISIT_NO"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(10))
					{
						model.VisitTime = DateTime.Parse(oleReader["VISIT_TIME"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(11))
					{
						model.Flag = decimal.Parse(oleReader["FLAG"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(12))
					{
						model.SignPage = decimal.Parse(oleReader["SIGN_PAGE"].ToString().Trim()) ;
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
		public List<Medicalcases> SelectMedicalcasesListOdbc()
		{
			List<Medicalcases> modelList = new List<Medicalcases>();
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MEDICALCASES_Select_ALL_ODBC, null))
			{
				while (oleReader.Read())
				{
					Medicalcases model = new Medicalcases();
					if (!oleReader.IsDBNull(0))
					{
						model.MedicalId = oleReader["MEDICAL_ID"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(1))
					{
						model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(2))
					{
						model.PatientName = oleReader["PATIENT_NAME"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(3))
					{
						model.UserId = oleReader["USER_ID"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(4))
					{
						model.UserName = oleReader["USER_NAME"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(5))
					{
						model.OfficeName = oleReader["OFFICE_NAME"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(6))
					{
						model.CreateDate = oleReader["CREATE_DATE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(7))
					{
						model.CreateTime = oleReader["CREATE_TIME"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(8))
					{
						model.VisitDate = oleReader["VISIT_DATE"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(9))
					{
						model.VisitNo = oleReader["VISIT_NO"].ToString().Trim() ;
					}
					if (!oleReader.IsDBNull(10))
					{
						model.VisitTime = DateTime.Parse(oleReader["VISIT_TIME"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(11))
					{
						model.Flag = decimal.Parse(oleReader["FLAG"].ToString().Trim()) ;
					}
					if (!oleReader.IsDBNull(12))
					{
						model.SignPage = decimal.Parse(oleReader["SIGN_PAGE"].ToString().Trim()) ;
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
