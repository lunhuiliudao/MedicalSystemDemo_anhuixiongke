

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010-11-10 13:32:24
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
	/// DAL MedOperationNameCanceled
	/// </summary>

    public partial class DALMedOperationNameCanceled
	{
		private static readonly string MED_OPERATION_NAME_CANCELED_Insert_SQL = "INSERT INTO MED_OPERATION_NAME_CANCELED (PATIENT_ID,VISIT_ID,CANCEL_ID,OPERATION_NO,OPERATION,OPERATION_SCALE,OPERATION_CODE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5) values (@PatientId,@VisitId,@CancelId,@OperationNo,@Operation,@OperationScale,@OperationCode,@Reserved1,@Reserved2,@Reserved3,@Reserved4,@Reserved5)";
		private static readonly string MED_OPERATION_NAME_CANCELED_Update_SQL = "UPDATE MED_OPERATION_NAME_CANCELED SET PATIENT_ID=@PatientId,VISIT_ID=@VisitId,CANCEL_ID=@CancelId,OPERATION_NO=@OperationNo,OPERATION=@Operation,OPERATION_SCALE=@OperationScale,OPERATION_CODE=@OperationCode,RESERVED1=@Reserved1,RESERVED2=@Reserved2,RESERVED3=@Reserved3,RESERVED4=@Reserved4,RESERVED5=@Reserved5 WHERE  PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND CANCEL_ID=@CancelId AND OPERATION_NO=@OperationNo";
		private static readonly string MED_OPERATION_NAME_CANCELED_Delete_SQL = "DELETE MED_OPERATION_NAME_CANCELED WHERE  PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND CANCEL_ID=@CancelId AND OPERATION_NO=@OperationNo";
		private static readonly string MED_OPERATION_NAME_CANCELED_Select_SQL = "SELECT PATIENT_ID,VISIT_ID,CANCEL_ID,OPERATION_NO,OPERATION,OPERATION_SCALE,OPERATION_CODE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5 FROM MED_OPERATION_NAME_CANCELED where  PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND CANCEL_ID=@CancelId AND OPERATION_NO=@OperationNo";
        private static readonly string MED_OPERATION_NAME_CANCELED_Select_OperId_SQL = "SELECT PATIENT_ID,VISIT_ID,CANCEL_ID,OPERATION_NO,OPERATION,OPERATION_SCALE,OPERATION_CODE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5 FROM MED_OPERATION_NAME_CANCELED where  PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND CANCEL_ID=@CancelId";
        private static readonly string MED_OPERATION_NAME_CANCELED_Select_ALL_SQL = "SELECT PATIENT_ID,VISIT_ID,CANCEL_ID,OPERATION_NO,OPERATION,OPERATION_SCALE,OPERATION_CODE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5 FROM MED_OPERATION_NAME_CANCELED";
		private static readonly string MED_OPERATION_NAME_CANCELED_Insert = "INSERT INTO MED_OPERATION_NAME_CANCELED (PATIENT_ID,VISIT_ID,CANCEL_ID,OPERATION_NO,OPERATION,OPERATION_SCALE,OPERATION_CODE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5) values (:PatientId,:VisitId,:CancelId,:OperationNo,:Operation,:OperationScale,:OperationCode,:Reserved1,:Reserved2,:Reserved3,:Reserved4,:Reserved5)";
		private static readonly string MED_OPERATION_NAME_CANCELED_Update = "UPDATE MED_OPERATION_NAME_CANCELED SET PATIENT_ID=:PatientId,VISIT_ID=:VisitId,CANCEL_ID=:CancelId,OPERATION_NO=:OperationNo,OPERATION=:Operation,OPERATION_SCALE=:OperationScale,OPERATION_CODE=:OperationCode,RESERVED1=:Reserved1,RESERVED2=:Reserved2,RESERVED3=:Reserved3,RESERVED4=:Reserved4,RESERVED5=:Reserved5 WHERE  PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND CANCEL_ID=:CancelId AND OPERATION_NO=:OperationNo";
		private static readonly string MED_OPERATION_NAME_CANCELED_Delete = "DELETE MED_OPERATION_NAME_CANCELED WHERE  PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND CANCEL_ID=:CancelId AND OPERATION_NO=:OperationNo";
		private static readonly string MED_OPERATION_NAME_CANCELED_Select = "SELECT PATIENT_ID,VISIT_ID,CANCEL_ID,OPERATION_NO,OPERATION,OPERATION_SCALE,OPERATION_CODE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5 FROM MED_OPERATION_NAME_CANCELED where  PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND CANCEL_ID=:CancelId AND OPERATION_NO=:OperationNo";
        private static readonly string MED_OPERATION_NAME_CANCELED_Select_OperId = "SELECT PATIENT_ID,VISIT_ID,CANCEL_ID,OPERATION_NO,OPERATION,OPERATION_SCALE,OPERATION_CODE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5 FROM MED_OPERATION_NAME_CANCELED where  PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND CANCEL_ID=:CancelId";
        private static readonly string MED_OPERATION_NAME_CANCELED_Select_ALL = "SELECT PATIENT_ID,VISIT_ID,CANCEL_ID,OPERATION_NO,OPERATION,OPERATION_SCALE,OPERATION_CODE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5 FROM MED_OPERATION_NAME_CANCELED";
		
		public DALMedOperationNameCanceled ()
		{
		}
		
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedOperationNameCanceled SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOperationNameCanceled")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@CancelId",SqlDbType.Decimal),
						new SqlParameter("@OperationNo",SqlDbType.Decimal),
						new SqlParameter("@Operation",SqlDbType.VarChar),
						new SqlParameter("@OperationScale",SqlDbType.VarChar),
						new SqlParameter("@OperationCode",SqlDbType.VarChar),
						new SqlParameter("@Reserved1",SqlDbType.VarChar),
						new SqlParameter("@Reserved2",SqlDbType.VarChar),
						new SqlParameter("@Reserved3",SqlDbType.VarChar),
						new SqlParameter("@Reserved4",SqlDbType.VarChar),
						new SqlParameter("@Reserved5",SqlDbType.Decimal),
                    };
                }
				else if (sqlParms == "UpdateMedOperationNameCanceled")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@CancelId",SqlDbType.Decimal),
						new SqlParameter("@OperationNo",SqlDbType.Decimal),
						new SqlParameter("@Operation",SqlDbType.VarChar),
						new SqlParameter("@OperationScale",SqlDbType.VarChar),
						new SqlParameter("@OperationCode",SqlDbType.VarChar),
						new SqlParameter("@Reserved1",SqlDbType.VarChar),
						new SqlParameter("@Reserved2",SqlDbType.VarChar),
						new SqlParameter("@Reserved3",SqlDbType.VarChar),
						new SqlParameter("@Reserved4",SqlDbType.VarChar),
						new SqlParameter("@Reserved5",SqlDbType.Decimal),
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@CancelId",SqlDbType.Decimal),
						new SqlParameter("@OperationNo",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedOperationNameCanceled")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@CancelId",SqlDbType.Decimal),
						new SqlParameter("@OperationNo",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "SelectMedOperationNameCanceled")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@CancelId",SqlDbType.Decimal),
						new SqlParameter("@OperationNo",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectOperIdMedOperationNameCanceled")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@CancelId",SqlDbType.Decimal),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedOperationNameCanceled 
		///Insert Table MED_OPERATION_NAME_CANCELED
		/// </summary>
		public int InsertMedOperationNameCanceledSQL(MedOperationNameCanceled model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedOperationNameCanceled");
					if (model.PatientId != null)
						oneInert[0].Value = model.PatientId;
					else
						oneInert[0].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneInert[1].Value = model.VisitId;
					else
						oneInert[1].Value = DBNull.Value;
                    if (model.CancelId.ToString() != null)
						oneInert[2].Value = model.CancelId;
					else
						oneInert[2].Value = DBNull.Value;
                    if (model.OperationNo.ToString() != null)
						oneInert[3].Value = model.OperationNo;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.Operation != null)
						oneInert[4].Value = model.Operation;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.OperationScale != null)
						oneInert[5].Value = model.OperationScale;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.OperationCode != null)
						oneInert[6].Value = model.OperationCode;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.Reserved1 != null)
						oneInert[7].Value = model.Reserved1;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.Reserved2 != null)
						oneInert[8].Value = model.Reserved2;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.Reserved3 != null)
						oneInert[9].Value = model.Reserved3;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.Reserved4 != null)
						oneInert[10].Value = model.Reserved4;
					else
						oneInert[10].Value = DBNull.Value;
                    if (model.Reserved5.ToString() != null)
						oneInert[11].Value = model.Reserved5;
					else
						oneInert[11].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_OPERATION_NAME_CANCELED_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedOperationNameCanceled 
		///Update Table     MED_OPERATION_NAME_CANCELED
		/// </summary>
		public int UpdateMedOperationNameCanceledSQL(MedOperationNameCanceled model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedOperationNameCanceled");
					if (model.PatientId != null)
						oneUpdate[0].Value = model.PatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneUpdate[1].Value = model.VisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
                    if (model.CancelId.ToString() != null)
						oneUpdate[2].Value = model.CancelId;
					else
						oneUpdate[2].Value = DBNull.Value;
                    if (model.OperationNo.ToString() != null)
						oneUpdate[3].Value = model.OperationNo;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.Operation != null)
						oneUpdate[4].Value = model.Operation;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.OperationScale != null)
						oneUpdate[5].Value = model.OperationScale;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.OperationCode != null)
						oneUpdate[6].Value = model.OperationCode;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.Reserved1 != null)
						oneUpdate[7].Value = model.Reserved1;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.Reserved2 != null)
						oneUpdate[8].Value = model.Reserved2;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.Reserved3 != null)
						oneUpdate[9].Value = model.Reserved3;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.Reserved4 != null)
						oneUpdate[10].Value = model.Reserved4;
					else
						oneUpdate[10].Value = DBNull.Value;
                    if (model.Reserved5.ToString() != null)
						oneUpdate[11].Value = model.Reserved5;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[12].Value =model.PatientId;
					else
						oneUpdate[12].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneUpdate[13].Value =model.VisitId;
					else
						oneUpdate[13].Value = DBNull.Value;
                    if (model.CancelId.ToString() != null)
						oneUpdate[14].Value =model.CancelId;
					else
						oneUpdate[14].Value = DBNull.Value;
                    if (model.OperationNo.ToString() != null)
						oneUpdate[15].Value =model.OperationNo;
					else
						oneUpdate[15].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_OPERATION_NAME_CANCELED_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedOperationNameCanceled 
		///Delete Table MED_OPERATION_NAME_CANCELED by (string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID,decimal OPERATION_NO)
		/// </summary>
		public int DeleteMedOperationNameCanceledSQL(string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID,decimal OPERATION_NO)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedOperationNameCanceled");
					if (PATIENT_ID != null)
						oneDelete[0].Value =PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (VISIT_ID.ToString() != null)
						oneDelete[1].Value =VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
                    if (CANCEL_ID.ToString() != null)
						oneDelete[2].Value =CANCEL_ID;
					else
						oneDelete[2].Value = DBNull.Value;
                    if (OPERATION_NO.ToString() != null)
						oneDelete[3].Value =OPERATION_NO;
					else
						oneDelete[3].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_OPERATION_NAME_CANCELED_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedOperationNameCanceled 
		///select Table MED_OPERATION_NAME_CANCELED by (string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID,decimal OPERATION_NO)
		/// </summary>
		public MedOperationNameCanceled  SelectMedOperationNameCanceledSQL(string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID,decimal OPERATION_NO)
		{
			MedOperationNameCanceled model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedOperationNameCanceled");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
				parameterValues[2].Value=CANCEL_ID;
				parameterValues[3].Value=OPERATION_NO;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_NAME_CANCELED_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedOperationNameCanceled();
						if (!oleReader.IsDBNull(0))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.CancelId = decimal.Parse(oleReader["CANCEL_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.OperationNo = decimal.Parse(oleReader["OPERATION_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Operation = oleReader["OPERATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.OperationScale = oleReader["OPERATION_SCALE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.OperationCode = oleReader["OPERATION_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Reserved1 = oleReader["RESERVED1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved2 = oleReader["RESERVED2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved3 = oleReader["RESERVED3"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Reserved4 = oleReader["RESERVED4"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Reserved5 = decimal.Parse(oleReader["RESERVED5"].ToString().Trim()) ;
						}
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
        #region  [获取一条记录SQL  -OPER_ID]
        /// <summary>
        ///Select    model  MedOperationNameCanceled 
        ///select Table MED_OPERATION_NAME_CANCELED by (string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID,decimal OPERATION_NO)
        /// </summary>
        public List<MedOperationNameCanceled> SelectMedOperationNameCanceledSQL(string PATIENT_ID, decimal VISIT_ID, decimal CANCEL_ID)
        {
            List<MedOperationNameCanceled> modelList = new List<MedOperationNameCanceled> ();
            SqlParameter[] parameterValues = GetParameterSQL("SelectOperIdMedOperationNameCanceled");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = CANCEL_ID;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_NAME_CANCELED_Select_OperId_SQL, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedOperationNameCanceled model = new MedOperationNameCanceled();
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
                        model.CancelId = decimal.Parse(oleReader["CANCEL_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OperationNo = decimal.Parse(oleReader["OPERATION_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.Operation = oleReader["OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OperationScale = oleReader["OPERATION_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OperationCode = oleReader["OPERATION_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved4 = oleReader["RESERVED4"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved5 = decimal.Parse(oleReader["RESERVED5"].ToString().Trim());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion	
		#region  [获取所有记录SQL]
		/// <summary>
		///获取所有记录
		/// </summary>
		public List<MedOperationNameCanceled> SelectMedOperationNameCanceledListSQL()
		{
			List<MedOperationNameCanceled> modelList = new List<MedOperationNameCanceled>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_NAME_CANCELED_Select_ALL_SQL, null))
			{
				while (oleReader.Read())
				{
					MedOperationNameCanceled model = new MedOperationNameCanceled();
						if (!oleReader.IsDBNull(0))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.CancelId = decimal.Parse(oleReader["CANCEL_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.OperationNo = decimal.Parse(oleReader["OPERATION_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Operation = oleReader["OPERATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.OperationScale = oleReader["OPERATION_SCALE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.OperationCode = oleReader["OPERATION_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Reserved1 = oleReader["RESERVED1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved2 = oleReader["RESERVED2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved3 = oleReader["RESERVED3"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Reserved4 = oleReader["RESERVED4"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Reserved5 = decimal.Parse(oleReader["RESERVED5"].ToString().Trim()) ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [获取参数]
		/// <summary>
		///获取参数MedOperationNameCanceled
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOperationNameCanceled")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":CancelId",OracleType.Number),
							new OracleParameter(":OperationNo",OracleType.Number),
							new OracleParameter(":Operation",OracleType.VarChar),
							new OracleParameter(":OperationScale",OracleType.VarChar),
							new OracleParameter(":OperationCode",OracleType.VarChar),
							new OracleParameter(":Reserved1",OracleType.VarChar),
							new OracleParameter(":Reserved2",OracleType.VarChar),
							new OracleParameter(":Reserved3",OracleType.VarChar),
							new OracleParameter(":Reserved4",OracleType.VarChar),
							new OracleParameter(":Reserved5",OracleType.Number),
                    };
                }
				else if (sqlParms == "UpdateMedOperationNameCanceled")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":CancelId",OracleType.Number),
							new OracleParameter(":OperationNo",OracleType.Number),
							new OracleParameter(":Operation",OracleType.VarChar),
							new OracleParameter(":OperationScale",OracleType.VarChar),
							new OracleParameter(":OperationCode",OracleType.VarChar),
							new OracleParameter(":Reserved1",OracleType.VarChar),
							new OracleParameter(":Reserved2",OracleType.VarChar),
							new OracleParameter(":Reserved3",OracleType.VarChar),
							new OracleParameter(":Reserved4",OracleType.VarChar),
							new OracleParameter(":Reserved5",OracleType.Number),
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":CancelId",OracleType.Number),
							new OracleParameter(":OperationNo",OracleType.Number),
                    };
                }
				else if(sqlParms == "DeleteMedOperationNameCanceled")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":CancelId",OracleType.Number),
							new OracleParameter(":OperationNo",OracleType.Number),
                    };
                }
				else if(sqlParms == "SelectMedOperationNameCanceled")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":CancelId",OracleType.Number),
							new OracleParameter(":OperationNo",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectOperIdMedOperationNameCanceled")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":CancelId",OracleType.Number),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedOperationNameCanceled 
		///Insert Table MED_OPERATION_NAME_CANCELED
		/// </summary>
		public int InsertMedOperationNameCanceled(MedOperationNameCanceled model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedOperationNameCanceled");
					if (model.PatientId != null)
						oneInert[0].Value = model.PatientId;
					else
						oneInert[0].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneInert[1].Value = model.VisitId;
					else
						oneInert[1].Value = DBNull.Value;
                    if (model.CancelId.ToString() != null)
						oneInert[2].Value = model.CancelId;
					else
						oneInert[2].Value = DBNull.Value;
                    if (model.OperationNo.ToString() != null)
						oneInert[3].Value = model.OperationNo;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.Operation != null)
						oneInert[4].Value = model.Operation;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.OperationScale != null)
						oneInert[5].Value = model.OperationScale;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.OperationCode != null)
						oneInert[6].Value = model.OperationCode;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.Reserved1 != null)
						oneInert[7].Value = model.Reserved1;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.Reserved2 != null)
						oneInert[8].Value = model.Reserved2;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.Reserved3 != null)
						oneInert[9].Value = model.Reserved3;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.Reserved4 != null)
						oneInert[10].Value = model.Reserved4;
					else
						oneInert[10].Value = DBNull.Value;
                    if (model.Reserved5.ToString() != null)
						oneInert[11].Value = model.Reserved5;
					else
						oneInert[11].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_OPERATION_NAME_CANCELED_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedOperationNameCanceled 
		///Update Table     MED_OPERATION_NAME_CANCELED
		/// </summary>
		public int UpdateMedOperationNameCanceled(MedOperationNameCanceled model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedOperationNameCanceled");
					if (model.PatientId != null)
						oneUpdate[0].Value = model.PatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneUpdate[1].Value = model.VisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
                    if (model.CancelId.ToString() != null)
						oneUpdate[2].Value = model.CancelId;
					else
						oneUpdate[2].Value = DBNull.Value;
                    if (model.OperationNo.ToString() != null)
						oneUpdate[3].Value = model.OperationNo;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.Operation != null)
						oneUpdate[4].Value = model.Operation;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.OperationScale != null)
						oneUpdate[5].Value = model.OperationScale;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.OperationCode != null)
						oneUpdate[6].Value = model.OperationCode;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.Reserved1 != null)
						oneUpdate[7].Value = model.Reserved1;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.Reserved2 != null)
						oneUpdate[8].Value = model.Reserved2;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.Reserved3 != null)
						oneUpdate[9].Value = model.Reserved3;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.Reserved4 != null)
						oneUpdate[10].Value = model.Reserved4;
					else
						oneUpdate[10].Value = DBNull.Value;
                    if (model.Reserved5.ToString() != null)
						oneUpdate[11].Value = model.Reserved5;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[12].Value =model.PatientId;
					else
						oneUpdate[12].Value = DBNull.Value;
                    if (model.VisitId.ToString() != null)
						oneUpdate[13].Value =model.VisitId;
					else
						oneUpdate[13].Value = DBNull.Value;
                    if (model.CancelId.ToString() != null)
						oneUpdate[14].Value =model.CancelId;
					else
						oneUpdate[14].Value = DBNull.Value;
                    if (model.OperationNo.ToString() != null)
						oneUpdate[15].Value =model.OperationNo;
					else
						oneUpdate[15].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_OPERATION_NAME_CANCELED_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedOperationNameCanceled 
		///Delete Table MED_OPERATION_NAME_CANCELED by (string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID,decimal OPERATION_NO)
		/// </summary>
		public int DeleteMedOperationNameCanceled(string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID,decimal OPERATION_NO)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedOperationNameCanceled");
					if (PATIENT_ID != null)
						oneDelete[0].Value =PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (VISIT_ID.ToString() != null)
						oneDelete[1].Value =VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
                    if (CANCEL_ID.ToString() != null)
						oneDelete[2].Value =CANCEL_ID;
					else
						oneDelete[2].Value = DBNull.Value;
                    if (OPERATION_NO.ToString() != null)
						oneDelete[3].Value =OPERATION_NO;
					else
						oneDelete[3].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_OPERATION_NAME_CANCELED_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedOperationNameCanceled 
		///select Table MED_OPERATION_NAME_CANCELED by (string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID,decimal OPERATION_NO)
		/// </summary>
		public MedOperationNameCanceled  SelectMedOperationNameCanceled(string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID,decimal OPERATION_NO)
		{
			MedOperationNameCanceled model;
			OracleParameter[] parameterValues = GetParameter("SelectMedOperationNameCanceled");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
				parameterValues[2].Value=CANCEL_ID;
				parameterValues[3].Value=OPERATION_NO;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_NAME_CANCELED_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedOperationNameCanceled();
						if (!oleReader.IsDBNull(0))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.CancelId = decimal.Parse(oleReader["CANCEL_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.OperationNo = decimal.Parse(oleReader["OPERATION_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Operation = oleReader["OPERATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.OperationScale = oleReader["OPERATION_SCALE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.OperationCode = oleReader["OPERATION_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Reserved1 = oleReader["RESERVED1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved2 = oleReader["RESERVED2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved3 = oleReader["RESERVED3"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Reserved4 = oleReader["RESERVED4"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Reserved5 = decimal.Parse(oleReader["RESERVED5"].ToString().Trim()) ;
						}
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
        #region  [获取一条记录 -OPER_ID]
        /// <summary>
        ///Select    model  MedOperationNameCanceled 
        ///select Table MED_OPERATION_NAME_CANCELED by (string PATIENT_ID,decimal VISIT_ID,decimal CANCEL_ID,decimal OPERATION_NO)
        /// </summary>
        public List<MedOperationNameCanceled> SelectMedOperationNameCanceled(string PATIENT_ID, decimal VISIT_ID, decimal CANCEL_ID)
        {
            List<MedOperationNameCanceled> modelList = new List<MedOperationNameCanceled>();
            OracleParameter[] parameterValues = GetParameter("SelectOperIdMedOperationNameCanceled");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = CANCEL_ID;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_NAME_CANCELED_Select_OperId, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedOperationNameCanceled model = new MedOperationNameCanceled();
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
                        model.CancelId = decimal.Parse(oleReader["CANCEL_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OperationNo = decimal.Parse(oleReader["OPERATION_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.Operation = oleReader["OPERATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OperationScale = oleReader["OPERATION_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OperationCode = oleReader["OPERATION_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved4 = oleReader["RESERVED4"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved5 = decimal.Parse(oleReader["RESERVED5"].ToString().Trim());
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
		public List<MedOperationNameCanceled> SelectMedOperationNameCanceledList()
		{
			List<MedOperationNameCanceled> modelList = new List<MedOperationNameCanceled>();
		    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_NAME_CANCELED_Select_ALL, null))
			{
				while (oleReader.Read())
				{
					MedOperationNameCanceled model = new MedOperationNameCanceled();
						if (!oleReader.IsDBNull(0))
						{
							model.PatientId = oleReader["PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.VisitId = decimal.Parse(oleReader["VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.CancelId = decimal.Parse(oleReader["CANCEL_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.OperationNo = decimal.Parse(oleReader["OPERATION_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Operation = oleReader["OPERATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.OperationScale = oleReader["OPERATION_SCALE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.OperationCode = oleReader["OPERATION_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Reserved1 = oleReader["RESERVED1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved2 = oleReader["RESERVED2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved3 = oleReader["RESERVED3"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Reserved4 = oleReader["RESERVED4"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Reserved5 = decimal.Parse(oleReader["RESERVED5"].ToString().Trim()) ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
