

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:07:32
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
	/// DAL MedOperationName
	/// </summary>
	
	public partial class DALMedOperationName
	{

        private static string Update = "Update MED_OPERATION_NAME set OPER_NAME=:OperName,OPER_CODE=:OperCode,OPER_SCALE=:OperScale,WOUND_TYPE=:WoundType,RESERVED1=:Reserved1,RESERVED2=:Reserved2,RESERVED3=:Reserved3,RESERVED4=:Reserved4 where PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND  OPER_ID=:OperId AND  OPER_NO=:OperNo ";


        private static string Insert = "Insert into MED_OPERATION_NAME  (PATIENT_ID,VISIT_ID,OPER_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4) values(:PatientId,:VisitId,:OperId,:OperNo,:OperName,:OperCode,:OperScale,:WoundType,:Reserved1,:Reserved2,:Reserved3,:Reserved4)";



        private static string Update_SQL = "Update MED_OPERATION_NAME set OPER_NAME=@OperName,OPER_CODE=@OperCode,OPER_SCALE=@OperScale,WOUND_TYPE=@WoundType,RESERVED1=@Reserved1,RESERVED2=@Reserved2,RESERVED3=@Reserved3,RESERVED4=@Reserved4 where PATIENT_ID=@PatientId,VISIT_ID=@VisitId,OPER_ID=@OperId,OPER_NO=@OperNo";


        private static string Insert_SQL = "Insert into MED_OPERATION_NAME  (PATIENT_ID,VISIT_ID,OPER_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4) values(@PatientId,@VisitId,@OperId,@OperNo,@OperName,@OperCode,@OperScale,@WoundType,@Reserved1,@Reserved2,@Reserved3,@Reserved4)";

		
        //private static readonly string MED_OPERATION_NAME_Insert_SQL = "INSERT INTO MED_OPERATION_NAME (PATIENT_ID,VISIT_ID,OPER_ID,OPERATION_NO,OPERATION,OPERATION_CODE,OPERATION_SCALE,WOUND_GRADE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5) values (@PatientId,@VisitId,@OperId,@OperationNo,@Operation,@OperationCode,@OperationScale,@WoundGrade,@Reserved1,@Reserved2,@Reserved3,@Reserved4,@Reserved5)";
        //private static readonly string MED_OPERATION_NAME_Update_SQL = "UPDATE MED_OPERATION_NAME SET PATIENT_ID=@PatientId,VISIT_ID=@VisitId,OPER_ID=@OperId,OPERATION_NO=@OperationNo,OPERATION=@Operation,OPERATION_CODE=@OperationCode,OPERATION_SCALE=@OperationScale,WOUND_GRADE=@WoundGrade,RESERVED1=@Reserved1,RESERVED2=@Reserved2,RESERVED3=@Reserved3,RESERVED4=@Reserved4,RESERVED5=@Reserved5 WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND OPER_ID=@OperId AND OPERATION_NO=@OperationNo";
        private static readonly string MED_OPERATION_NAME_Delete_SQL = "Delete MED_OPERATION_NAME WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND OPER_ID=@OperId AND OPERATION_NO=@OperationNo";
        private static readonly string MED_OPERATION_NAME_Select_SQL = "SELECT  PATIENT_ID,VISIT_ID,OPER_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 FROM MED_OPERATION_NAME where PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND OPER_ID=@OperId AND OPERATION_NO=@OperationNo";
        private static readonly string MED_OPERATION_NAME_Select_OperId_SQL = "SELECT  PATIENT_ID,VISIT_ID,OPER_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 FROM MED_OPERATION_NAME where PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND OPER_ID=@OperId";
        private static readonly string MED_OPERATION_NAME_Select_ALL_SQL = "SELECT  PATIENT_ID,VISIT_ID,OPER_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 FROM MED_OPERATION_NAME";
		//private static readonly string MED_OPERATION_NAME_Insert = "INSERT INTO MED_OPERATION_NAME (PATIENT_ID,VISIT_ID,OPER_ID,OPERATION_NO,OPERATION,OPERATION_CODE,OPERATION_SCALE,WOUND_GRADE,RESERVED1,RESERVED2,RESERVED3,RESERVED4,RESERVED5) values (:PatientId,:VisitId,:OperId,:OperationNo,:Operation,:OperationCode,:OperationScale,:WoundGrade,:Reserved1,:Reserved2,:Reserved3,:Reserved4,:Reserved5)";
        // private static readonly string MED_OPERATION_NAME_Update = "UPDATE MED_OPERATION_NAME SET PATIENT_ID=:PatientId,VISIT_ID=:VisitId,OPER_ID=:OperId,OPERATION_NO=:OperationNo,OPERATION=:Operation,OPERATION_CODE=:OperationCode,OPERATION_SCALE=:OperationScale,WOUND_GRADE=:WoundGrade,RESERVED1=:Reserved1,RESERVED2=:Reserved2,RESERVED3=:Reserved3,RESERVED4=:Reserved4,RESERVED5=:Reserved5 WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND OPER_ID=:OperId AND OPERATION_NO=:OperationNo";
        private static readonly string MED_OPERATION_NAME_Delete = "Delete MED_OPERATION_NAME WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND OPER_ID=:OperId AND OPERATION_NO=:OperationNo";
        private static readonly string MED_OPERATION_NAME_Select = "SELECT  PATIENT_ID,VISIT_ID,OPER_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 FROM MED_OPERATION_NAME where PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND OPER_ID=:OperId AND OPERATION_NO=:OperationNo";
        private static readonly string MED_OPERATION_NAME_Select_OperId = "SELECT  PATIENT_ID,VISIT_ID,OPER_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 FROM MED_OPERATION_NAME where PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND OPER_ID=:OperId";
        private static readonly string MED_OPERATION_NAME_Select_ALL = "SELECT  PATIENT_ID,VISIT_ID,OPER_ID,OPER_NO,OPER_NAME,OPER_CODE,OPER_SCALE,WOUND_TYPE,RESERVED1,RESERVED2,RESERVED3,RESERVED4 FROM MED_OPERATION_NAME";
		public DALMedOperationName ()
		{
		}
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedOperationName SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOperationName")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
                        new SqlParameter("@VisitId",SqlDbType.Decimal),
                        new SqlParameter("@OperId",SqlDbType.Decimal),
                        new SqlParameter("@OperNo",SqlDbType.Decimal),
                        new SqlParameter("@OperName",SqlDbType.VarChar),
                        new SqlParameter("@OperCode",SqlDbType.VarChar),
                        new SqlParameter("@OperScale",SqlDbType.VarChar),
                        new SqlParameter("@WoundType",SqlDbType.VarChar),
                        new SqlParameter("@Reserved1",SqlDbType.VarChar),
                        new SqlParameter("@Reserved2",SqlDbType.VarChar),
                        new SqlParameter("@Reserved3",SqlDbType.VarChar),
                        new SqlParameter("@Reserved4",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedOperationName")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@OperName",SqlDbType.VarChar),
                        new SqlParameter("@OperCode",SqlDbType.VarChar),
                        new SqlParameter("@OperScale",SqlDbType.VarChar),
                        new SqlParameter("@WoundType",SqlDbType.VarChar),
                        new SqlParameter("@Reserved1",SqlDbType.VarChar),
                        new SqlParameter("@Reserved2",SqlDbType.VarChar),
                        new SqlParameter("@Reserved3",SqlDbType.VarChar),
                        new SqlParameter("@Reserved4",SqlDbType.VarChar),
                        new SqlParameter("@PatientId",SqlDbType.VarChar),
                        new SqlParameter("@VisitId",SqlDbType.Decimal),
                        new SqlParameter("@OperId",SqlDbType.Decimal),
                        new SqlParameter("@OperNo",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedOperationName")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OperId",SqlDbType.Decimal),
							new SqlParameter("@OperationNo",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "SelectMedOperationName")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OperId",SqlDbType.Decimal),
							new SqlParameter("@OperationNo",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedOperationNameOperId")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OperId",SqlDbType.Decimal),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedOperationName 
		///Insert Table MED_OPERATION_NAME
		/// </summary>
		public int InsertMedOperationNameSQL(MedOperationName model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedOperationName");
                if (model.PatientId != null)
                    oneInert[0].Value = model.PatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneInert[1].Value = model.VisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.OperId != null)
                    oneInert[2].Value = model.OperId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.OperNo != null)
                    oneInert[3].Value = model.OperNo;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.OperName != null)
                    oneInert[4].Value = model.OperName;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.OperCode != null)
                    oneInert[5].Value = model.OperCode;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.OperScale != null)
                    oneInert[6].Value = model.OperScale;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.WoundType != null)
                    oneInert[7].Value = model.WoundType;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneInert[8].Value = model.Reserved1;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Reserved2 != null)
                    oneInert[9].Value = model.Reserved2;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.Reserved3 != null)
                    oneInert[10].Value = model.Reserved3;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.Reserved4 != null)
                    oneInert[11].Value = model.Reserved4;
                else
                    oneInert[11].Value = DBNull.Value;
			
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedOperationName 
		///Update Table     MED_OPERATION_NAME
		/// </summary>
		public int UpdateMedOperationNameSQL(MedOperationName model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedOperationName");
                if (model.OperName != null)
                    oneUpdate[0].Value = model.OperName;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.OperCode != null)
                    oneUpdate[1].Value = model.OperCode;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.OperScale != null)
                    oneUpdate[2].Value = model.OperScale;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.WoundType != null)
                    oneUpdate[3].Value = model.WoundType;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneUpdate[4].Value = model.Reserved1;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.Reserved2 != null)
                    oneUpdate[5].Value = model.Reserved2;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.Reserved3 != null)
                    oneUpdate[6].Value = model.Reserved3;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.Reserved4 != null)
                    oneUpdate[7].Value = model.Reserved4;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[8].Value = model.PatientId;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneUpdate[9].Value = model.VisitId;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.OperId != null)
                    oneUpdate[10].Value = model.OperId;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.OperNo != null)
                    oneUpdate[11].Value = model.OperNo;
                else
                    oneUpdate[11].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedOperationName 
		///Delete Table MED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal OPERATION_NO)
		/// </summary>
		public int DeleteMedOperationNameSQL(string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal OPERATION_NO)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedOperationName");
					if (PATIENT_ID != null)
						oneDelete[0].Value =PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (VISIT_ID.ToString() != null)
						oneDelete[1].Value =VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
                    if (OPER_ID.ToString() != null)
						oneDelete[2].Value =OPER_ID;
					else
						oneDelete[2].Value = DBNull.Value;
                    if (OPERATION_NO.ToString() != null)
						oneDelete[3].Value =OPERATION_NO;
					else
						oneDelete[3].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_OPERATION_NAME_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedOperationName 
		///select Table MED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal OPERATION_NO)
		/// </summary>
		public MedOperationName  SelectMedOperationNameSQL(string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal OPERATION_NO)
		{
			MedOperationName model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedOperationName");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
				parameterValues[2].Value=OPER_ID;
				parameterValues[3].Value=OPERATION_NO;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_NAME_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedOperationName();
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OperNo = decimal.Parse(oleReader["OPER_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.OperName = oleReader["OPER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OperCode = oleReader["OPER_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved4 = oleReader["RESERVED4"].ToString().Trim();
                    }
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
        #region  [获取一条记录SQL -OPER_ID]
        /// <summary>
        ///Select    model  MedOperationName 
        ///select Table MED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal OPERATION_NO)
        /// </summary>
        public List<MedOperationName> SelectMedOperationNameSQL(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID)
        {
            List<Model.MedOperationName> modelList = new List<Model.MedOperationName>();
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedOperationNameOperId");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = OPER_ID;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_NAME_Select_OperId_SQL, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedOperationName model = new MedOperationName();
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OperNo = decimal.Parse(oleReader["OPER_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.OperName = oleReader["OPER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OperCode = oleReader["OPER_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved4 = oleReader["RESERVED4"].ToString().Trim();
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
		public List<MedOperationName> SelectMedOperationNameListSQL()
		{
			List<MedOperationName> modelList = new List<MedOperationName>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_NAME_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedOperationName model = new MedOperationName();
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OperNo = decimal.Parse(oleReader["OPER_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.OperName = oleReader["OPER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OperCode = oleReader["OPER_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved4 = oleReader["RESERVED4"].ToString().Trim();
                    }
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [获取参数]
		/// <summary>
		///获取参数MedOperationName
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOperationName")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OperId",OracleType.Number),
							new OracleParameter(":OperationNo",OracleType.Number),
							new OracleParameter(":Operation",OracleType.VarChar),
							new OracleParameter(":OperationCode",OracleType.VarChar),
							new OracleParameter(":OperationScale",OracleType.VarChar),
							new OracleParameter(":WoundGrade",OracleType.VarChar),
							new OracleParameter(":Reserved1",OracleType.VarChar),
							new OracleParameter(":Reserved2",OracleType.VarChar),
							new OracleParameter(":Reserved3",OracleType.VarChar),
							new OracleParameter(":Reserved4",OracleType.VarChar),
							new OracleParameter(":Reserved5",OracleType.Number),
                    };
                }
				else if (sqlParms == "UpdateMedOperationName")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OperId",OracleType.Number),
							new OracleParameter(":OperationNo",OracleType.Number),
							new OracleParameter(":Operation",OracleType.VarChar),
							new OracleParameter(":OperationCode",OracleType.VarChar),
							new OracleParameter(":OperationScale",OracleType.VarChar),
							new OracleParameter(":WoundGrade",OracleType.VarChar),
							new OracleParameter(":Reserved1",OracleType.VarChar),
							new OracleParameter(":Reserved2",OracleType.VarChar),
							new OracleParameter(":Reserved3",OracleType.VarChar),
							new OracleParameter(":Reserved4",OracleType.VarChar),
							new OracleParameter(":Reserved5",OracleType.Number),
							new OracleParameter(":PatientId",SqlDbType.VarChar),
							new OracleParameter(":VisitId",SqlDbType.Decimal),
							new OracleParameter(":OperId",SqlDbType.Decimal),
							new OracleParameter(":OperationNo",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedOperationName")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OperId",OracleType.Number),
							new OracleParameter(":OperationNo",OracleType.Number),
                    };
                }
				else if(sqlParms == "SelectMedOperationName")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OperId",OracleType.Number),
							new OracleParameter(":OperationNo",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectMedOperationNameOperId")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OperId",OracleType.Number),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedOperationName 
		///Insert Table MED_OPERATION_NAME
		/// </summary>
		public int InsertMedOperationName(MedOperationName model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedOperationName");
                if (model.PatientId != null)
                    oneInert[0].Value = model.PatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneInert[1].Value = model.VisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.OperId != null)
                    oneInert[2].Value = model.OperId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.OperNo != null)
                    oneInert[3].Value = model.OperNo;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.OperName != null)
                    oneInert[4].Value = model.OperName;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.OperCode != null)
                    oneInert[5].Value = model.OperCode;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.OperScale != null)
                    oneInert[6].Value = model.OperScale;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.WoundType != null)
                    oneInert[7].Value = model.WoundType;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneInert[8].Value = model.Reserved1;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Reserved2 != null)
                    oneInert[9].Value = model.Reserved2;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.Reserved3 != null)
                    oneInert[10].Value = model.Reserved3;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.Reserved4 != null)
                    oneInert[11].Value = model.Reserved4;
                else
                    oneInert[11].Value = DBNull.Value;

				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedOperationName 
		///Update Table     MED_OPERATION_NAME
		/// </summary>
		public int UpdateMedOperationName(MedOperationName model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedOperationName");
                if (model.OperName != null)
                    oneUpdate[0].Value = model.OperName;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.OperCode != null)
                    oneUpdate[1].Value = model.OperCode;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.OperScale != null)
                    oneUpdate[2].Value = model.OperScale;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.WoundType != null)
                    oneUpdate[3].Value = model.WoundType;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneUpdate[4].Value = model.Reserved1;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.Reserved2 != null)
                    oneUpdate[5].Value = model.Reserved2;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.Reserved3 != null)
                    oneUpdate[6].Value = model.Reserved3;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.Reserved4 != null)
                    oneUpdate[7].Value = model.Reserved4;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[8].Value = model.PatientId;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.VisitId != null)
                    oneUpdate[9].Value = model.VisitId;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.OperId != null)
                    oneUpdate[10].Value = model.OperId;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.OperNo != null)
                    oneUpdate[11].Value = model.OperNo;
                else
                    oneUpdate[11].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedOperationName 
		///Delete Table MED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal OPERATION_NO)
		/// </summary>
		public int DeleteMedOperationName(string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal OPERATION_NO)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedOperationName");
					if (PATIENT_ID != null)
						oneDelete[0].Value =PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (VISIT_ID.ToString() != null)
						oneDelete[1].Value =VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
                    if (OPER_ID.ToString() != null)
						oneDelete[2].Value =OPER_ID;
					else
						oneDelete[2].Value = DBNull.Value;
                    if (OPERATION_NO.ToString() != null)
						oneDelete[3].Value =OPERATION_NO;
					else
						oneDelete[3].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_OPERATION_NAME_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedOperationName 
		///select Table MED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal OPERATION_NO)
		/// </summary>
		public MedOperationName  SelectMedOperationName(string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal OPERATION_NO)
		{
			MedOperationName model;
			OracleParameter[] parameterValues = GetParameter("SelectMedOperationName");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
				parameterValues[2].Value=OPER_ID;
				parameterValues[3].Value=OPERATION_NO;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_NAME_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedOperationName();
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OperNo = decimal.Parse(oleReader["OPER_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.OperName = oleReader["OPER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OperCode = oleReader["OPER_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved4 = oleReader["RESERVED4"].ToString().Trim();
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
        ///Select    model  MedOperationName 
        ///select Table MED_OPERATION_NAME by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal OPERATION_NO)
        /// </summary>
        public List<Model.MedOperationName> SelectMedOperationName(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID)
        {
            List<Model.MedOperationName> modelList = new List<Model.MedOperationName>();

            OracleParameter[] parameterValues = GetParameter("SelectMedOperationNameOperId");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = OPER_ID;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_NAME_Select_OperId, parameterValues))
            {
                while (oleReader.Read())
                {
                    MedOperationName model = new MedOperationName();
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OperNo = decimal.Parse(oleReader["OPER_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.OperName = oleReader["OPER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OperCode = oleReader["OPER_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved4 = oleReader["RESERVED4"].ToString().Trim();
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
		public List<MedOperationName> SelectMedOperationNameList()
		{
			List<MedOperationName> modelList = new List<MedOperationName>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_NAME_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedOperationName model = new MedOperationName();
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
                        model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OperNo = decimal.Parse(oleReader["OPER_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.OperName = oleReader["OPER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OperCode = oleReader["OPER_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OperScale = oleReader["OPER_SCALE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.WoundType = oleReader["WOUND_TYPE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved2 = oleReader["RESERVED2"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved3 = oleReader["RESERVED3"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved4 = oleReader["RESERVED4"].ToString().Trim();
                    }
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
