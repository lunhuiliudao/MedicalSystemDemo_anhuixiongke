

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:05:58
 * 
 * Notes:
 * 
* ******************************************************************/

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using MedicalSytem.Soft.Model;

namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedVsHisOperBillConsts
	/// </summary>
	
	public class DALMedVsHisOperBillConsts
	{
		
		private static readonly string MED_VS_HIS_OPER_BILL_CONSTS_Insert_SQL = "INSERT INTO MED_VS_HIS_OPER_BILL_CONSTS (PATIENT_ID,VISIT_ID,OPER_ID,CONSTS_COUNT,ITEM_NO_STRING,ITEM_NO_STRING_INDICATOR,RESERVED1,RESERVED2,RESERVED3) values (@PatientId,@VisitId,@OperId,@ConstsCount,@ItemNoString,@ItemNoStringIndicator,@Reserved1,@Reserved2,@Reserved3)";
        private static readonly string MED_VS_HIS_OPER_BILL_CONSTS_Update_SQL = "UPDATE MED_VS_HIS_OPER_BILL_CONSTS SET PATIENT_ID=@PatientId,VISIT_ID=@VisitId,OPER_ID=@OperId,CONSTS_COUNT=@ConstsCount,ITEM_NO_STRING=@ItemNoString,ITEM_NO_STRING_INDICATOR=@ItemNoStringIndicator,RESERVED1=@Reserved1,RESERVED2=@Reserved2,RESERVED3=@Reserved3 WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND OPER_ID=@OperId AND CONSTS_COUNT=@ConstsCount AND ITEM_NO_STRING=@ItemNoString";
        private static readonly string MED_VS_HIS_OPER_BILL_CONSTS_Delete_SQL = "Delete MED_VS_HIS_OPER_BILL_CONSTS WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND OPER_ID=@OperId AND CONSTS_COUNT=@ConstsCount AND ITEM_NO_STRING=@ItemNoString";
        private static readonly string MED_VS_HIS_OPER_BILL_CONSTS_Select_SQL = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,CONSTS_COUNT,ITEM_NO_STRING,ITEM_NO_STRING_INDICATOR,RESERVED1,RESERVED2,RESERVED3 FROM MED_VS_HIS_OPER_BILL_CONSTS where PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND OPER_ID=@OperId AND CONSTS_COUNT=@ConstsCount AND ITEM_NO_STRING=@ItemNoString";
		private static readonly string MED_VS_HIS_OPER_BILL_CONSTS_Select_ALL_SQL = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,CONSTS_COUNT,ITEM_NO_STRING,ITEM_NO_STRING_INDICATOR,RESERVED1,RESERVED2,RESERVED3 FROM MED_VS_HIS_OPER_BILL_CONSTS";
        private static readonly string MED_VS_HIS_OPER_BILL_Consts_Select_Count_SQL = "SELECT isnull(max(consts_count),0) from med_vs_his_oper_bill_consts where patient_id = @patientId and  visit_id = @visitId and oper_id = @operId";
        private static readonly string MED_VS_HIS_OPER_BILL_Consts_Select_OneMore_SQL = "SELECT patient_id, visit_id, oper_id, consts_count, item_no_string, item_no_string_indicator, reserved1, reserved2, reserved3 from med_vs_his_oper_bill_consts where patient_id = @patientId and  visit_id = @visitId and oper_id = @operId and consts_count = @constsCount ";
        private static readonly string MED_VS_HIS_OPER_BILL_Consts_Select_OneMore_ItemNo_SQL = "SELECT patient_id, visit_id, oper_id, consts_count, item_no_string, item_no_string_indicator, reserved1, reserved2, reserved3 from med_vs_his_oper_bill_consts where patient_id = @patientId and  visit_id = @visitId and oper_id = @operId ";
        private static readonly string MED_VS_HIS_OPER_BILL_CONSTS_Insert = "INSERT INTO MED_VS_HIS_OPER_BILL_CONSTS (PATIENT_ID,VISIT_ID,OPER_ID,CONSTS_COUNT,ITEM_NO_STRING,ITEM_NO_STRING_INDICATOR,RESERVED1,RESERVED2,RESERVED3) values (:PatientId,:VisitId,:OperId,:ConstsCount,:ItemNoString,:ItemNoStringIndicator,:Reserved1,:Reserved2,:Reserved3)";
        private static readonly string MED_VS_HIS_OPER_BILL_CONSTS_Update = "UPDATE MED_VS_HIS_OPER_BILL_CONSTS SET PATIENT_ID=:PatientId,VISIT_ID=:VisitId,OPER_ID=:OperId,CONSTS_COUNT=:ConstsCount,ITEM_NO_STRING=:ItemNoString,ITEM_NO_STRING_INDICATOR=:ItemNoStringIndicator,RESERVED1=:Reserved1,RESERVED2=:Reserved2,RESERVED3=:Reserved3 WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND OPER_ID=:OperId AND CONSTS_COUNT=:ConstsCount AND ITEM_NO_STRING=:ItemNoString";
        private static readonly string MED_VS_HIS_OPER_BILL_CONSTS_Delete = "Delete MED_VS_HIS_OPER_BILL_CONSTS WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND OPER_ID=:OperId AND CONSTS_COUNT=:ConstsCount AND ITEM_NO_STRING=:ItemNoString";
        private static readonly string MED_VS_HIS_OPER_BILL_CONSTS_Select = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,CONSTS_COUNT,ITEM_NO_STRING,ITEM_NO_STRING_INDICATOR,RESERVED1,RESERVED2,RESERVED3 FROM MED_VS_HIS_OPER_BILL_CONSTS where PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND OPER_ID=:OperId AND CONSTS_COUNT=:ConstsCount AND ITEM_NO_STRING=:ItemNoString";
		private static readonly string MED_VS_HIS_OPER_BILL_CONSTS_Select_ALL = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,CONSTS_COUNT,ITEM_NO_STRING,ITEM_NO_STRING_INDICATOR,RESERVED1,RESERVED2,RESERVED3 FROM MED_VS_HIS_OPER_BILL_CONSTS";
        private static readonly string MED_VS_HIS_OPER_BILL_Consts_Select_Count = "SELECT nvl(max(consts_count),0) from med_vs_his_oper_bill_consts where patient_id = :patientId and  visit_id = :visitId and oper_id = :operId";
        private static readonly string MED_VS_HIS_OPER_BILL_Consts_Select_OneMore = "SELECT patient_id, visit_id, oper_id, consts_count, item_no_string, item_no_string_indicator, reserved1, reserved2, reserved3 from med_vs_his_oper_bill_consts where patient_id = :patientId and  visit_id = :visitId and oper_id = :operId and consts_count = :constsCount ";
        private static readonly string MED_VS_HIS_OPER_BILL_Consts_Select_OneMore_ItemNo = "SELECT patient_id, visit_id, oper_id, consts_count, item_no_string, item_no_string_indicator, reserved1, reserved2, reserved3 from med_vs_his_oper_bill_consts where patient_id = :patientId and  visit_id = :visitId and oper_id = :operId ";

        public DALMedVsHisOperBillConsts ()
		{
		}
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedVsHisOperBillConsts SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOperBillConsts")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OperId",SqlDbType.Decimal),
							new SqlParameter("@ConstsCount",SqlDbType.Decimal),
							new SqlParameter("@ItemNoString",SqlDbType.VarChar),
							new SqlParameter("@ItemNoStringIndicator",SqlDbType.VarChar),
							new SqlParameter("@Reserved1",SqlDbType.VarChar),
							new SqlParameter("@Reserved2",SqlDbType.VarChar),
							new SqlParameter("@Reserved3",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedVsHisOperBillConsts")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OperId",SqlDbType.Decimal),
							new SqlParameter("@ConstsCount",SqlDbType.Decimal),
							new SqlParameter("@ItemNoString",SqlDbType.VarChar),
							new SqlParameter("@ItemNoStringIndicator",SqlDbType.VarChar),
							new SqlParameter("@Reserved1",SqlDbType.VarChar),
							new SqlParameter("@Reserved2",SqlDbType.VarChar),
							new SqlParameter("@Reserved3",SqlDbType.VarChar),
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OperId",SqlDbType.Decimal),
							new SqlParameter("@ConstsCount",SqlDbType.Decimal),
							new SqlParameter("@ItemNoString",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedVsHisOperBillConsts")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OperId",SqlDbType.Decimal),
							new SqlParameter("@ConstsCount",SqlDbType.Decimal),
							new SqlParameter("@ItemNoString",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedVsHisOperBillConsts")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@OperId",SqlDbType.Decimal),
						new SqlParameter("@ConstsCount",SqlDbType.Decimal),
						new SqlParameter("@ItemNoString",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectCountMedVsHisOperBillConsts")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@OperId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectOneMoreMedVsHisOperBillConsts")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@OperId",SqlDbType.Decimal),
						new SqlParameter("@ConstsCount",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectOneMoreItemNoMedVsHisOperBillConsts")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@PatientId",SqlDbType.VarChar),
						new SqlParameter("@VisitId",SqlDbType.Decimal),
						new SqlParameter("@OperId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOperBillConstsOperId")
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
		///Add    model  MedVsHisOperBillConsts 
		///Insert Table MED_VS_HIS_OPER_BILL_CONSTS
		/// </summary>
		public int InsertMedVsHisOperBillConstsSQL(MedVsHisOperBillConsts model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedVsHisOperBillConsts");
					if (model.PatientId != null)
						oneInert[0].Value = model.PatientId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneInert[1].Value = model.VisitId;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.OperId.ToString() != null)
						oneInert[2].Value = model.OperId;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.ConstsCount.ToString() != null)
						oneInert[3].Value = model.ConstsCount;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.ItemNoString != null)
						oneInert[4].Value = model.ItemNoString;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.ItemNoStringIndicator != null)
						oneInert[5].Value = model.ItemNoStringIndicator;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.Reserved1 != null)
						oneInert[6].Value = model.Reserved1;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.Reserved2 != null)
						oneInert[7].Value = model.Reserved2;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.Reserved3 != null)
						oneInert[8].Value = model.Reserved3;
					else
						oneInert[8].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_OPER_BILL_CONSTS_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedVsHisOperBillConsts 
		///Update Table     MED_VS_HIS_OPER_BILL_CONSTS
		/// </summary>
		public int UpdateMedVsHisOperBillConstsSQL(MedVsHisOperBillConsts model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedVsHisOperBillConsts");
					if (model.PatientId != null)
						oneUpdate[0].Value = model.PatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneUpdate[1].Value = model.VisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.OperId.ToString() != null)
						oneUpdate[2].Value = model.OperId;
					else
						oneUpdate[2].Value = DBNull.Value;
                    if (model.ConstsCount.ToString() != null)
						oneUpdate[3].Value = model.ConstsCount;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.ItemNoString != null)
						oneUpdate[4].Value = model.ItemNoString;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.ItemNoStringIndicator != null)
						oneUpdate[5].Value = model.ItemNoStringIndicator;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.Reserved1 != null)
						oneUpdate[6].Value = model.Reserved1;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.Reserved2 != null)
						oneUpdate[7].Value = model.Reserved2;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.Reserved3 != null)
						oneUpdate[8].Value = model.Reserved3;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[9].Value =model.PatientId;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneUpdate[10].Value =model.VisitId;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.OperId.ToString() != null)
						oneUpdate[11].Value =model.OperId;
					else
						oneUpdate[11].Value = DBNull.Value;
                    if (model.ConstsCount.ToString() != null)
						oneUpdate[12].Value =model.ConstsCount;
					else
						oneUpdate[12].Value = DBNull.Value;
					if (model.ItemNoString != null)
						oneUpdate[13].Value =model.ItemNoString;
					else
						oneUpdate[13].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_OPER_BILL_CONSTS_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedVsHisOperBillConsts 
		///Delete Table MED_VS_HIS_OPER_BILL_CONSTS by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal CONSTS_COUNT,string ITEM_NO_STRING)
		/// </summary>
		public int DeleteMedVsHisOperBillConstsSQL(string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal CONSTS_COUNT,string ITEM_NO_STRING)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedVsHisOperBillConsts");
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
                    if (CONSTS_COUNT.ToString() != null)
						oneDelete[3].Value =CONSTS_COUNT;
					else
						oneDelete[3].Value = DBNull.Value;
					if (ITEM_NO_STRING != null)
						oneDelete[4].Value =ITEM_NO_STRING;
					else
						oneDelete[4].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_OPER_BILL_CONSTS_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedVsHisOperBillConsts 
		///select Table MED_VS_HIS_OPER_BILL_CONSTS by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal CONSTS_COUNT,string ITEM_NO_STRING)
		/// </summary>
		public MedVsHisOperBillConsts  SelectMedVsHisOperBillConstsSQL(string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal CONSTS_COUNT,string ITEM_NO_STRING)
		{
			MedVsHisOperBillConsts model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedVsHisOperBillConsts");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
				parameterValues[2].Value=OPER_ID;
				parameterValues[3].Value=CONSTS_COUNT;
				parameterValues[4].Value=ITEM_NO_STRING;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_CONSTS_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedVsHisOperBillConsts();
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
							model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.ConstsCount = decimal.Parse(oleReader["CONSTS_COUNT"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ItemNoString = oleReader["ITEM_NO_STRING"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.ItemNoStringIndicator = oleReader["ITEM_NO_STRING_INDICATOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Reserved1 = oleReader["RESERVED1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Reserved2 = oleReader["RESERVED2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved3 = oleReader["RESERVED3"].ToString().Trim() ;
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
		public List<MedVsHisOperBillConsts> SelectMedVsHisOperBillConstsListSQL()
		{
			List<MedVsHisOperBillConsts> modelList = new List<MedVsHisOperBillConsts>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_CONSTS_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedVsHisOperBillConsts model = new MedVsHisOperBillConsts();
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
							model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.ConstsCount = decimal.Parse(oleReader["CONSTS_COUNT"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ItemNoString = oleReader["ITEM_NO_STRING"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.ItemNoStringIndicator = oleReader["ITEM_NO_STRING_INDICATOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Reserved1 = oleReader["RESERVED1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Reserved2 = oleReader["RESERVED2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved3 = oleReader["RESERVED3"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
        public int SelectCountMedVsHisOperBillConstsSQL(string patientId, decimal visitId, decimal operId)
        {
            SqlParameter[] countMedVsHisOperBillConsts = GetParameterSQL("SelectCountMedVsHisOperBillConsts");
            countMedVsHisOperBillConsts[0].Value = patientId;
            countMedVsHisOperBillConsts[1].Value = visitId;
            countMedVsHisOperBillConsts[2].Value = operId;

            object count = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_Consts_Select_Count_SQL, countMedVsHisOperBillConsts);
            if (count == null)
                count = (object)0;
            return Convert.ToInt32(count);
        }

        public List<Model.MedVsHisOperBillConsts> SelectOneMoreMedVsHisOperBillConstsSQL(string patientId, decimal visitId, decimal operId, decimal constsCount)
        {
            List<Model.MedVsHisOperBillConsts> MedVsHisOperBillConstsList = new List<Model.MedVsHisOperBillConsts>();
            Model.MedVsHisOperBillConsts MedVsHisOperBillConsts = null;

            SqlParameter[] mdPats = GetParameterSQL("SelectOneMoreMedVsHisOperBillConsts");
            mdPats[0].Value = patientId;
            mdPats[1].Value = visitId;
            mdPats[2].Value = operId;
            mdPats[3].Value = constsCount;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_Consts_Select_OneMore_SQL, mdPats))
            {
                while (oleReader.Read())
                {
                    MedVsHisOperBillConsts = new Model.MedVsHisOperBillConsts();
                    MedVsHisOperBillConsts.PatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        MedVsHisOperBillConsts.VisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        MedVsHisOperBillConsts.OperId = oleReader.GetDecimal(2);
                    if (!oleReader.IsDBNull(3))
                        MedVsHisOperBillConsts.ConstsCount = oleReader.GetDecimal(3);
                    if (!oleReader.IsDBNull(4))
                        MedVsHisOperBillConsts.ItemNoString = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        MedVsHisOperBillConsts.ItemNoStringIndicator = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        MedVsHisOperBillConsts.Reserved1 = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        MedVsHisOperBillConsts.Reserved2 = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        MedVsHisOperBillConsts.Reserved3 = oleReader.GetString(8);
                    MedVsHisOperBillConstsList.Add(MedVsHisOperBillConsts);
                }

            }
            return MedVsHisOperBillConstsList;
        }

        public List<Model.MedVsHisOperBillConsts> SelectOneMoreItemNoMedVsHisOperBillConstsSQL(string patientId, decimal visitId, decimal operId, string itemNo)
        {
            List<Model.MedVsHisOperBillConsts> MedVsHisOperBillConstsList = new List<Model.MedVsHisOperBillConsts>();
            Model.MedVsHisOperBillConsts MedVsHisOperBillConsts = null;

            SqlParameter[] mdPats = GetParameterSQL("SelectOneMoreItemNoMedVsHisOperBillConsts");
            mdPats[0].Value = patientId;
            mdPats[1].Value = visitId;
            mdPats[2].Value = operId;
            StringBuilder MED_VS_HIS_OPER_BILL_Consts_Select_OneMore_ItemNo_SQL_In = new StringBuilder();//
            MED_VS_HIS_OPER_BILL_Consts_Select_OneMore_ItemNo_SQL_In.Append(MED_VS_HIS_OPER_BILL_Consts_Select_OneMore_ItemNo_SQL);
            MED_VS_HIS_OPER_BILL_Consts_Select_OneMore_ItemNo_SQL_In.Append("and item_no_string in ( " + itemNo + " ) ");

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_Consts_Select_OneMore_ItemNo_SQL_In.ToString(), mdPats))
            {
                while (oleReader.Read())
                {
                    MedVsHisOperBillConsts = new Model.MedVsHisOperBillConsts();
                    MedVsHisOperBillConsts.PatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        MedVsHisOperBillConsts.VisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        MedVsHisOperBillConsts.OperId = oleReader.GetDecimal(2);
                    if (!oleReader.IsDBNull(3))
                        MedVsHisOperBillConsts.ConstsCount = oleReader.GetDecimal(3);
                    if (!oleReader.IsDBNull(4))
                        MedVsHisOperBillConsts.ItemNoString = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        MedVsHisOperBillConsts.ItemNoStringIndicator = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        MedVsHisOperBillConsts.Reserved1 = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        MedVsHisOperBillConsts.Reserved2 = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        MedVsHisOperBillConsts.Reserved3 = oleReader.GetString(8);
                    MedVsHisOperBillConstsList.Add(MedVsHisOperBillConsts);
                }

            }
            return MedVsHisOperBillConstsList;
        }

        public List<Model.MedVsHisOperBillConsts> SelectMedVsHisOperBillConstsSQL(string patientId, decimal visitId, decimal operId)
        {
            List<Model.MedVsHisOperBillConsts> MedVsHisOperBillConstsList = new List<Model.MedVsHisOperBillConsts>();

            SqlParameter[] mdPats = GetParameterSQL("SelectMedVsHisOperBillConstsOperId");
            mdPats[0].Value = patientId;
            mdPats[1].Value = visitId;
            mdPats[2].Value = operId;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_Consts_Select_OneMore_ItemNo, mdPats))
            {
                while (oleReader.Read())
                {
                    Model.MedVsHisOperBillConsts oneMedVsHisOperBillConsts = new Model.MedVsHisOperBillConsts();
                    oneMedVsHisOperBillConsts.PatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisOperBillConsts.VisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisOperBillConsts.OperId = oleReader.GetDecimal(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisOperBillConsts.ConstsCount = oleReader.GetDecimal(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisOperBillConsts.ItemNoString = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisOperBillConsts.ItemNoStringIndicator = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisOperBillConsts.Reserved1 = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisOperBillConsts.Reserved2 = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        oneMedVsHisOperBillConsts.Reserved3 = oleReader.GetString(8);
                    MedVsHisOperBillConstsList.Add(oneMedVsHisOperBillConsts);
                }
            }
            return MedVsHisOperBillConstsList;
        }

		#region [获取参数]
		/// <summary>
		///获取参数MedVsHisOperBillConsts
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOperBillConsts")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OperId",OracleType.Number),
							new OracleParameter(":ConstsCount",OracleType.Number),
							new OracleParameter(":ItemNoString",OracleType.VarChar),
							new OracleParameter(":ItemNoStringIndicator",OracleType.VarChar),
							new OracleParameter(":Reserved1",OracleType.VarChar),
							new OracleParameter(":Reserved2",OracleType.VarChar),
							new OracleParameter(":Reserved3",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedVsHisOperBillConsts")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OperId",OracleType.Number),
							new OracleParameter(":ConstsCount",OracleType.Number),
							new OracleParameter(":ItemNoString",OracleType.VarChar),
							new OracleParameter(":ItemNoStringIndicator",OracleType.VarChar),
							new OracleParameter(":Reserved1",OracleType.VarChar),
							new OracleParameter(":Reserved2",OracleType.VarChar),
							new OracleParameter(":Reserved3",OracleType.VarChar),
							new OracleParameter(":PatientId",SqlDbType.VarChar),
							new OracleParameter(":VisitId",SqlDbType.Decimal),
							new OracleParameter(":OperId",SqlDbType.Decimal),
							new OracleParameter(":ConstsCount",SqlDbType.Decimal),
							new OracleParameter(":ItemNoString",SqlDbType.VarChar),
                    };
                }
				else if(sqlParms == "DeleteMedVsHisOperBillConsts")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OperId",OracleType.Number),
							new OracleParameter(":ConstsCount",OracleType.Number),
							new OracleParameter(":ItemNoString",OracleType.VarChar),
                    };
                }
				else if(sqlParms == "SelectMedVsHisOperBillConsts")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":PatientId",OracleType.VarChar),
						new OracleParameter(":VisitId",OracleType.Number),
						new OracleParameter(":OperId",OracleType.Number),
						new OracleParameter(":ConstsCount",OracleType.Number),
						new OracleParameter(":ItemNoString",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectCountMedVsHisOperBillConsts")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":PatientId",OracleType.VarChar),
						new OracleParameter(":VisitId",OracleType.Number),
						new OracleParameter(":OperId",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectOneMoreMedVsHisOperBillConsts")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":PatientId",OracleType.VarChar),
						new OracleParameter(":VisitId",OracleType.Number),
						new OracleParameter(":OperId",OracleType.Number),
						new OracleParameter(":ConstsCount",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectOneMoreMedVsHisOperBillConsts")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":PatientId",OracleType.VarChar),
						new OracleParameter(":VisitId",OracleType.Number),
						new OracleParameter(":OperId",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOperBillConstsOperId")
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
		///Add    model  MedVsHisOperBillConsts 
		///Insert Table MED_VS_HIS_OPER_BILL_CONSTS
		/// </summary>
		public int InsertMedVsHisOperBillConsts(MedVsHisOperBillConsts model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedVsHisOperBillConsts");
					if (model.PatientId != null)
						oneInert[0].Value = model.PatientId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneInert[1].Value = model.VisitId;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.OperId.ToString() != null)
						oneInert[2].Value = model.OperId;
					else
						oneInert[2].Value = DBNull.Value;
                    if (model.ConstsCount.ToString() != null)
						oneInert[3].Value = model.ConstsCount;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.ItemNoString != null)
						oneInert[4].Value = model.ItemNoString;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.ItemNoStringIndicator != null)
						oneInert[5].Value = model.ItemNoStringIndicator;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.Reserved1 != null)
						oneInert[6].Value = model.Reserved1;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.Reserved2 != null)
						oneInert[7].Value = model.Reserved2;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.Reserved3 != null)
						oneInert[8].Value = model.Reserved3;
					else
						oneInert[8].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_OPER_BILL_CONSTS_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedVsHisOperBillConsts 
		///Update Table     MED_VS_HIS_OPER_BILL_CONSTS
		/// </summary>
		public int UpdateMedVsHisOperBillConsts(MedVsHisOperBillConsts model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedVsHisOperBillConsts");
					if (model.PatientId != null)
						oneUpdate[0].Value = model.PatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneUpdate[1].Value = model.VisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.OperId.ToString() != null)
						oneUpdate[2].Value = model.OperId;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.ConstsCount.ToString() != null)
						oneUpdate[3].Value = model.ConstsCount;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.ItemNoString != null)
						oneUpdate[4].Value = model.ItemNoString;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.ItemNoStringIndicator != null)
						oneUpdate[5].Value = model.ItemNoStringIndicator;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.Reserved1 != null)
						oneUpdate[6].Value = model.Reserved1;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.Reserved2 != null)
						oneUpdate[7].Value = model.Reserved2;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.Reserved3 != null)
						oneUpdate[8].Value = model.Reserved3;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.PatientId != null)
						oneUpdate[9].Value =model.PatientId;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.VisitId.ToString() != null)
						oneUpdate[10].Value =model.VisitId;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.OperId.ToString() != null)
						oneUpdate[11].Value =model.OperId;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.ConstsCount.ToString() != null)
						oneUpdate[12].Value =model.ConstsCount;
					else
						oneUpdate[12].Value = DBNull.Value;
					if (model.ItemNoString != null)
						oneUpdate[13].Value =model.ItemNoString;
					else
						oneUpdate[13].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_OPER_BILL_CONSTS_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedVsHisOperBillConsts 
		///Delete Table MED_VS_HIS_OPER_BILL_CONSTS by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal CONSTS_COUNT,string ITEM_NO_STRING)
		/// </summary>
		public int DeleteMedVsHisOperBillConsts(string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal CONSTS_COUNT,string ITEM_NO_STRING)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedVsHisOperBillConsts");
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
                    if (CONSTS_COUNT.ToString() != null)
						oneDelete[3].Value =CONSTS_COUNT;
					else
						oneDelete[3].Value = DBNull.Value;
					if (ITEM_NO_STRING != null)
						oneDelete[4].Value =ITEM_NO_STRING;
					else
						oneDelete[4].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_OPER_BILL_CONSTS_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedVsHisOperBillConsts 
		///select Table MED_VS_HIS_OPER_BILL_CONSTS by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal CONSTS_COUNT,string ITEM_NO_STRING)
		/// </summary>
		public MedVsHisOperBillConsts  SelectMedVsHisOperBillConsts(string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal CONSTS_COUNT,string ITEM_NO_STRING)
		{
			MedVsHisOperBillConsts model;
			OracleParameter[] parameterValues = GetParameter("SelectMedVsHisOperBillConsts");
				parameterValues[0].Value=PATIENT_ID;
				parameterValues[1].Value=VISIT_ID;
				parameterValues[2].Value=OPER_ID;
				parameterValues[3].Value=CONSTS_COUNT;
				parameterValues[4].Value=ITEM_NO_STRING;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_CONSTS_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedVsHisOperBillConsts();
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
							model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.ConstsCount = decimal.Parse(oleReader["CONSTS_COUNT"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ItemNoString = oleReader["ITEM_NO_STRING"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.ItemNoStringIndicator = oleReader["ITEM_NO_STRING_INDICATOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Reserved1 = oleReader["RESERVED1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Reserved2 = oleReader["RESERVED2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved3 = oleReader["RESERVED3"].ToString().Trim() ;
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
		public List<MedVsHisOperBillConsts> SelectMedVsHisOperBillConstsList()
		{
			List<MedVsHisOperBillConsts> modelList = new List<MedVsHisOperBillConsts>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_CONSTS_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedVsHisOperBillConsts model = new MedVsHisOperBillConsts();
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
							model.OperId = decimal.Parse(oleReader["OPER_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.ConstsCount = decimal.Parse(oleReader["CONSTS_COUNT"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.ItemNoString = oleReader["ITEM_NO_STRING"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.ItemNoStringIndicator = oleReader["ITEM_NO_STRING_INDICATOR"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.Reserved1 = oleReader["RESERVED1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.Reserved2 = oleReader["RESERVED2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved3 = oleReader["RESERVED3"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
        public int SelectCountMedVsHisOperBillConsts(string patientId, decimal visitId, decimal operId)
        {
            OracleParameter[] countMedVsHisOperBillConsts = GetParameter("SelectCountMedVsHisOperBillConsts");
            countMedVsHisOperBillConsts[0].Value = patientId;
            countMedVsHisOperBillConsts[1].Value = visitId;
            countMedVsHisOperBillConsts[2].Value = operId;

            object count = OracleHelper.ExecuteScalar(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_Consts_Select_Count, countMedVsHisOperBillConsts);
            if (count == null)
                count = (object)0;
            return Convert.ToInt32(count);
        }

        public List<Model.MedVsHisOperBillConsts> SelectOneMoreMedVsHisOperBillConsts(string patientId, decimal visitId, decimal operId, decimal constsCount)
        {
            List<Model.MedVsHisOperBillConsts> MedVsHisOperBillConstsList = new List<Model.MedVsHisOperBillConsts>();
            Model.MedVsHisOperBillConsts MedVsHisOperBillConsts = null;

            OracleParameter[] mdPats = GetParameter("SelectOneMoreMedVsHisOperBillConsts");
            mdPats[0].Value = patientId;
            mdPats[1].Value = visitId;
            mdPats[2].Value = operId;
            mdPats[3].Value = constsCount;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_Consts_Select_OneMore, mdPats))
            {
                while (oleReader.Read())
                {
                    MedVsHisOperBillConsts = new Model.MedVsHisOperBillConsts();
                    MedVsHisOperBillConsts.PatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        MedVsHisOperBillConsts.VisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        MedVsHisOperBillConsts.OperId = oleReader.GetDecimal(2);
                    if (!oleReader.IsDBNull(3))
                        MedVsHisOperBillConsts.ConstsCount = oleReader.GetDecimal(3);
                    if (!oleReader.IsDBNull(4))
                        MedVsHisOperBillConsts.ItemNoString = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        MedVsHisOperBillConsts.ItemNoStringIndicator = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        MedVsHisOperBillConsts.Reserved1 = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        MedVsHisOperBillConsts.Reserved2 = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        MedVsHisOperBillConsts.Reserved3 = oleReader.GetString(8);
                    MedVsHisOperBillConstsList.Add(MedVsHisOperBillConsts);
                }

            }
            return MedVsHisOperBillConstsList;
        }

        public List<Model.MedVsHisOperBillConsts> SelectOneMoreItemNoMedVsHisOperBillConsts(string patientId, decimal visitId, decimal operId, string itemNo)
        {
            List<Model.MedVsHisOperBillConsts> MedVsHisOperBillConstsList = new List<Model.MedVsHisOperBillConsts>();
            Model.MedVsHisOperBillConsts MedVsHisOperBillConsts = null;

            OracleParameter[] mdPats = GetParameter("SelectOneMoreMedVsHisOperBillConsts");
            mdPats[0].Value = patientId;
            mdPats[1].Value = visitId;
            mdPats[2].Value = operId;
            StringBuilder MED_VS_HIS_OPER_BILL_Consts_Select_OneMore_ItemNo_In = new StringBuilder();
            MED_VS_HIS_OPER_BILL_Consts_Select_OneMore_ItemNo_In.Append(MED_VS_HIS_OPER_BILL_Consts_Select_OneMore_ItemNo);
            MED_VS_HIS_OPER_BILL_Consts_Select_OneMore_ItemNo_In.Append("and item_no_string in ( " + itemNo + " ) ");

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_Consts_Select_OneMore_ItemNo_In.ToString(), mdPats))
            {
                while (oleReader.Read())
                {
                    MedVsHisOperBillConsts = new Model.MedVsHisOperBillConsts();
                    MedVsHisOperBillConsts.PatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        MedVsHisOperBillConsts.VisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        MedVsHisOperBillConsts.OperId = oleReader.GetDecimal(2);
                    if (!oleReader.IsDBNull(3))
                        MedVsHisOperBillConsts.ConstsCount = oleReader.GetDecimal(3);
                    if (!oleReader.IsDBNull(4))
                        MedVsHisOperBillConsts.ItemNoString = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        MedVsHisOperBillConsts.ItemNoStringIndicator = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        MedVsHisOperBillConsts.Reserved1 = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        MedVsHisOperBillConsts.Reserved2 = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        MedVsHisOperBillConsts.Reserved3 = oleReader.GetString(8);
                    MedVsHisOperBillConstsList.Add(MedVsHisOperBillConsts);
                }

            }
            return MedVsHisOperBillConstsList;
        }

        public List<Model.MedVsHisOperBillConsts> SelectMedVsHisOperBillConsts(string patientId, decimal visitId, decimal operId)
        {
            List<Model.MedVsHisOperBillConsts> MedVsHisOperBillConstsList = new List<Model.MedVsHisOperBillConsts>();

            OracleParameter[] mdPats = GetParameter("SelectMedVsHisOperBillConstsOperId");
            mdPats[0].Value = patientId;
            mdPats[1].Value = visitId;
            mdPats[2].Value = operId;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_Consts_Select_OneMore_ItemNo, mdPats))
            {
                while (oleReader.Read())
                {
                    Model.MedVsHisOperBillConsts oneMedVsHisOperBillConsts = new Model.MedVsHisOperBillConsts();
                    oneMedVsHisOperBillConsts.PatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisOperBillConsts.VisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisOperBillConsts.OperId = oleReader.GetDecimal(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisOperBillConsts.ConstsCount = oleReader.GetDecimal(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisOperBillConsts.ItemNoString = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisOperBillConsts.ItemNoStringIndicator = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisOperBillConsts.Reserved1 = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisOperBillConsts.Reserved2 = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        oneMedVsHisOperBillConsts.Reserved3 = oleReader.GetString(8);
                    MedVsHisOperBillConstsList.Add(oneMedVsHisOperBillConsts);
                }

            }
            return MedVsHisOperBillConstsList;
        }

	}
}
