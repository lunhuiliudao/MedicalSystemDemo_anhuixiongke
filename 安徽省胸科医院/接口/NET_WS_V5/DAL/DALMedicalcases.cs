

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
using System.Data.SqlClient;
using System.Data.OracleClient;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL Medicalcases
	/// </summary>
	
	public partial class DALMedicalcases
	{
		private static readonly string MEDICALCASES_Insert_SQL = "INSERT INTO MEDICALCASES (MEDICAL_ID,PATIENT_ID,PATIENT_NAME,USER_ID,USER_NAME,OFFICE_NAME,CREATE_DATE,CREATE_TIME,VISIT_DATE,VISIT_NO,VISIT_TIME,FLAG,SIGN_PAGE) values (@MedicalId,@PatientId,@PatientName,@UserId,@UserName,@OfficeName,@CreateDate,@CreateTime,@VisitDate,@VisitNo,@VisitTime,@Flag,@SignPage)";
		private static readonly string MEDICALCASES_Update_SQL = "UPDATE MEDICALCASES SET MEDICAL_ID=@MedicalId,PATIENT_ID=@PatientId,PATIENT_NAME=@PatientName,USER_ID=@UserId,USER_NAME=@UserName,OFFICE_NAME=@OfficeName,CREATE_DATE=@CreateDate,CREATE_TIME=@CreateTime,VISIT_DATE=@VisitDate,VISIT_NO=@VisitNo,VISIT_TIME=@VisitTime,FLAG=@Flag,SIGN_PAGE=@SignPage WHERE  MEDICAL_ID=@MedicalId";
		private static readonly string MEDICALCASES_Delete_SQL = "DELETE MEDICALCASES WHERE  MEDICAL_ID=@MedicalId";
		private static readonly string MEDICALCASES_Select_SQL = "SELECT MEDICAL_ID,PATIENT_ID,PATIENT_NAME,USER_ID,USER_NAME,OFFICE_NAME,CREATE_DATE,CREATE_TIME,VISIT_DATE,VISIT_NO,VISIT_TIME,FLAG,SIGN_PAGE FROM MEDICALCASES where  MEDICAL_ID=@MedicalId";
		private static readonly string MEDICALCASES_Select_ALL_SQL = "SELECT MEDICAL_ID,PATIENT_ID,PATIENT_NAME,USER_ID,USER_NAME,OFFICE_NAME,CREATE_DATE,CREATE_TIME,VISIT_DATE,VISIT_NO,VISIT_TIME,FLAG,SIGN_PAGE FROM MEDICALCASES";
		private static readonly string MEDICALCASES_Insert = "INSERT INTO MEDICALCASES (MEDICAL_ID,PATIENT_ID,PATIENT_NAME,USER_ID,USER_NAME,OFFICE_NAME,CREATE_DATE,CREATE_TIME,VISIT_DATE,VISIT_NO,VISIT_TIME,FLAG,SIGN_PAGE) values (:MedicalId,:PatientId,:PatientName,:UserId,:UserName,:OfficeName,:CreateDate,:CreateTime,:VisitDate,:VisitNo,:VisitTime,:Flag,:SignPage)";
		private static readonly string MEDICALCASES_Update = "UPDATE MEDICALCASES SET MEDICAL_ID=:MedicalId,PATIENT_ID=:PatientId,PATIENT_NAME=:PatientName,USER_ID=:UserId,USER_NAME=:UserName,OFFICE_NAME=:OfficeName,CREATE_DATE=:CreateDate,CREATE_TIME=:CreateTime,VISIT_DATE=:VisitDate,VISIT_NO=:VisitNo,VISIT_TIME=:VisitTime,FLAG=:Flag,SIGN_PAGE=:SignPage WHERE  MEDICAL_ID=:MedicalId";
		private static readonly string MEDICALCASES_Delete = "DELETE MEDICALCASES WHERE  MEDICAL_ID=:MedicalId";
		private static readonly string MEDICALCASES_Select = "SELECT MEDICAL_ID,PATIENT_ID,PATIENT_NAME,USER_ID,USER_NAME,OFFICE_NAME,CREATE_DATE,CREATE_TIME,VISIT_DATE,VISIT_NO,VISIT_TIME,FLAG,SIGN_PAGE FROM MEDICALCASES where  MEDICAL_ID=:MedicalId";
		private static readonly string MEDICALCASES_Select_ALL = "SELECT MEDICAL_ID,PATIENT_ID,PATIENT_NAME,USER_ID,USER_NAME,OFFICE_NAME,CREATE_DATE,CREATE_TIME,VISIT_DATE,VISIT_NO,VISIT_TIME,FLAG,SIGN_PAGE FROM MEDICALCASES";
		
		public DALMedicalcases ()
		{
		}
		
		#region [获取参数SQL]
		/// <summary>
		///获取参数Medicalcases SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedicalcases")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@MedicalId",SqlDbType.VarChar),
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@PatientName",SqlDbType.VarChar),
							new SqlParameter("@UserId",SqlDbType.VarChar),
							new SqlParameter("@UserName",SqlDbType.VarChar),
							new SqlParameter("@OfficeName",SqlDbType.VarChar),
							new SqlParameter("@CreateDate",SqlDbType.VarChar),
							new SqlParameter("@CreateTime",SqlDbType.VarChar),
							new SqlParameter("@VisitDate",SqlDbType.VarChar),
							new SqlParameter("@VisitNo",SqlDbType.VarChar),
							new SqlParameter("@VisitTime",SqlDbType.DateTime),
							new SqlParameter("@Flag",SqlDbType.Decimal),
							new SqlParameter("@SignPage",SqlDbType.Decimal),
                    };
                }
				else if (sqlParms == "UpdateMedicalcases")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@MedicalId",SqlDbType.VarChar),
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@PatientName",SqlDbType.VarChar),
							new SqlParameter("@UserId",SqlDbType.VarChar),
							new SqlParameter("@UserName",SqlDbType.VarChar),
							new SqlParameter("@OfficeName",SqlDbType.VarChar),
							new SqlParameter("@CreateDate",SqlDbType.VarChar),
							new SqlParameter("@CreateTime",SqlDbType.VarChar),
							new SqlParameter("@VisitDate",SqlDbType.VarChar),
							new SqlParameter("@VisitNo",SqlDbType.VarChar),
							new SqlParameter("@VisitTime",SqlDbType.DateTime),
							new SqlParameter("@Flag",SqlDbType.Decimal),
							new SqlParameter("@SignPage",SqlDbType.Decimal),
							new SqlParameter("@MedicalId",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedicalcases")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@MedicalId",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedicalcases")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@MedicalId",SqlDbType.VarChar),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  Medicalcases 
		///Insert Table MEDICALCASES
		/// </summary>
		public int InsertMedicalcasesSQL(Medicalcases model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedicalcases");
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
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MEDICALCASES_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  Medicalcases 
		///Update Table     MEDICALCASES
		/// </summary>
		public int UpdateMedicalcasesSQL(Medicalcases model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedicalcases");
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
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MEDICALCASES_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  Medicalcases 
		///Delete Table MEDICALCASES by (string MEDICAL_ID)
		/// </summary>
		public int DeleteMedicalcasesSQL(string MEDICAL_ID)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedicalcases");
					if (MEDICAL_ID != null)
						oneDelete[0].Value =MEDICAL_ID;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MEDICALCASES_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  Medicalcases 
		///select Table MEDICALCASES by (string MEDICAL_ID)
		/// </summary>
		public Medicalcases  SelectMedicalcasesSQL(string MEDICAL_ID)
		{
			Medicalcases model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedicalcases");
				parameterValues[0].Value=MEDICAL_ID;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MEDICALCASES_Select_SQL, parameterValues))
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
		#region  [获取所有记录SQL]
		/// <summary>
		///获取所有记录
		/// </summary>
		public List<Medicalcases> SelectMedicalcasesListSQL()
		{
			List<Medicalcases> modelList = new List<Medicalcases>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MEDICALCASES_Select_ALL_SQL, null))
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
		
		#region [获取参数]
		/// <summary>
		///获取参数Medicalcases
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedicalcases")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":MedicalId",OracleType.VarChar),
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":PatientName",OracleType.VarChar),
							new OracleParameter(":UserId",OracleType.VarChar),
							new OracleParameter(":UserName",OracleType.VarChar),
							new OracleParameter(":OfficeName",OracleType.VarChar),
							new OracleParameter(":CreateDate",OracleType.VarChar),
							new OracleParameter(":CreateTime",OracleType.VarChar),
							new OracleParameter(":VisitDate",OracleType.VarChar),
							new OracleParameter(":VisitNo",OracleType.VarChar),
							new OracleParameter(":VisitTime",OracleType.DateTime),
							new OracleParameter(":Flag",OracleType.Number),
							new OracleParameter(":SignPage",OracleType.Number),
                    };
                }
				else if (sqlParms == "UpdateMedicalcases")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":MedicalId",OracleType.VarChar),
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":PatientName",OracleType.VarChar),
							new OracleParameter(":UserId",OracleType.VarChar),
							new OracleParameter(":UserName",OracleType.VarChar),
							new OracleParameter(":OfficeName",OracleType.VarChar),
							new OracleParameter(":CreateDate",OracleType.VarChar),
							new OracleParameter(":CreateTime",OracleType.VarChar),
							new OracleParameter(":VisitDate",OracleType.VarChar),
							new OracleParameter(":VisitNo",OracleType.VarChar),
							new OracleParameter(":VisitTime",OracleType.DateTime),
							new OracleParameter(":Flag",OracleType.Number),
							new OracleParameter(":SignPage",OracleType.Number),
							new OracleParameter(":MedicalId",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedicalcases")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":MedicalId",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedicalcases")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":MedicalId",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  Medicalcases 
		///Insert Table MEDICALCASES
		/// </summary>
		public int InsertMedicalcases(Medicalcases model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedicalcases");
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
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MEDICALCASES_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  Medicalcases 
		///Update Table     MEDICALCASES
		/// </summary>
		public int UpdateMedicalcases(Medicalcases model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedicalcases");
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
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MEDICALCASES_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  Medicalcases 
		///Delete Table MEDICALCASES by (string MEDICAL_ID)
		/// </summary>
		public int DeleteMedicalcases(string MEDICAL_ID)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedicalcases");
					if (MEDICAL_ID != null)
						oneDelete[0].Value =MEDICAL_ID;
					else
						oneDelete[0].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MEDICALCASES_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  Medicalcases 
		///select Table MEDICALCASES by (string MEDICAL_ID)
		/// </summary>
		public Medicalcases  SelectMedicalcases(string MEDICAL_ID)
		{
			Medicalcases model;
			OracleParameter[] parameterValues = GetParameter("SelectMedicalcases");
				parameterValues[0].Value=MEDICAL_ID;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MEDICALCASES_Select, parameterValues))
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
		public List<Medicalcases> SelectMedicalcasesList()
		{
			List<Medicalcases> modelList = new List<Medicalcases>();
		    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MEDICALCASES_Select_ALL, null))
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
