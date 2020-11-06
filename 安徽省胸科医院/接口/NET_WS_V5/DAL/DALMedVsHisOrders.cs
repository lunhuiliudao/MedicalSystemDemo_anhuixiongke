

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:03:17
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
	/// DAL MedVsHisOrders
	/// </summary>
	
	public partial class DALMedVsHisOrders
	{
		
		private static readonly string MED_VS_HIS_ORDERS_Insert_SQL = "INSERT INTO MED_VS_HIS_ORDERS (MED_PATIENT_ID,MED_VISIT_ID,MED_ORDER_NO,MED_ORDER_SUB_NO,MED_REPEAT_INDICATOR,HIS_ORDER_NO,HIS_ORDER_SUB_NO,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05) values (@MedPatientId,@MedVisitId,@MedOrderNo,@MedOrderSubNo,@MedRepeatIndicator,@HisOrderNo,@HisOrderSubNo,@CreateDate,@Reserved01,@Reserved02,@Reserved03,@Reserved04,@Reserved05)";
        private static readonly string MED_VS_HIS_ORDERS_Update_SQL = "UPDATE MED_VS_HIS_ORDERS SET MED_PATIENT_ID=@MedPatientId,MED_VISIT_ID=@MedVisitId,MED_ORDER_NO=@MedOrderNo,MED_ORDER_SUB_NO=@MedOrderSubNo,MED_REPEAT_INDICATOR=@MedRepeatIndicator,HIS_ORDER_NO=@HisOrderNo,HIS_ORDER_SUB_NO=@HisOrderSubNo,CREATE_DATE=@CreateDate,RESERVED01=@Reserved01,RESERVED02=@Reserved02,RESERVED03=@Reserved03,RESERVED04=@Reserved04,RESERVED05=@Reserved05 WHERE MED_PATIENT_ID=@MedPatientIdP AND MED_VISIT_ID=@MedVisitIdP AND MED_ORDER_NO=@MedOrderNoP AND MED_ORDER_SUB_NO=@MedOrderSubNoP AND MED_REPEAT_INDICATOR=@MedRepeatIndicatorP";
        private static readonly string MED_VS_HIS_ORDERS_Delete_SQL = "Delete MED_VS_HIS_ORDERS WHERE MED_PATIENT_ID=@MedPatientId AND MED_VISIT_ID=@MedVisitId AND MED_ORDER_NO=@MedOrderNo AND MED_ORDER_SUB_NO=@MedOrderSubNo AND MED_REPEAT_INDICATOR=@MedRepeatIndicator";
        private static readonly string MED_VS_HIS_ORDERS_Select_SQL = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_ORDER_NO,MED_ORDER_SUB_NO,MED_REPEAT_INDICATOR,HIS_ORDER_NO,HIS_ORDER_SUB_NO,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05 FROM MED_VS_HIS_ORDERS where MED_PATIENT_ID=@MedPatientId AND MED_VISIT_ID=@MedVisitId AND MED_ORDER_NO=@MedOrderNo AND MED_ORDER_SUB_NO=@MedOrderSubNo AND MED_REPEAT_INDICATOR=@MedRepeatIndicator";
		private static readonly string MED_VS_HIS_ORDERS_Select_ALL_SQL = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_ORDER_NO,MED_ORDER_SUB_NO,MED_REPEAT_INDICATOR,HIS_ORDER_NO,HIS_ORDER_SUB_NO,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05 FROM MED_VS_HIS_ORDERS";
        private static readonly string MED_VS_HIS_ORDERS_His_Select_SQL = "select med_patient_id, med_visit_id, med_order_no, med_order_sub_no, med_repeat_indicator, his_order_no, his_order_sub_no, create_date, reserved01, reserved02, reserved03, reserved04, reserved05 from med_vs_his_orders where his_order_no = @hisOrderNo and his_order_sub_no = @hisOrderSubNo and create_date = @createDate ";
        private static readonly string MED_VS_HIS_ORDERS_His_Only_Select_SQL = "select med_patient_id, med_visit_id, med_order_no, med_order_sub_no, med_repeat_indicator, his_order_no, his_order_sub_no, create_date, reserved01, reserved02, reserved03, reserved04, reserved05 from med_vs_his_orders where med_patient_id = @medPatientId and med_visit_id = @medVisitId and his_order_no = @hisOrderNo and his_order_sub_no = @hisOrderSubNo and create_date = @createDate ";
        private static readonly string MED_VS_HIS_ORDERSSubNo_Select_Top_SQL = "select Max(med_order_sub_no) from med_vs_his_orders where med_patient_id = @medPatientId and med_visit_id = @medVisitId and med_order_no = @medOrderNo ";
        private static readonly string MED_VS_HIS_ORDERSSubNo_FromHis_Select_Top_SQL = "select Max(med_order_sub_no) from med_vs_his_orders where med_patient_id = @medPatientId and med_visit_id = @medVisitId and his_order_sub_no = @hisOrderSubNo ";
        private static readonly string MED_ORDERSNO_Select_Top_SQL = "select Max(order_no) from med_orders";
        private static readonly string MED_VS_HIS_ORDERS_Insert = "INSERT INTO MED_VS_HIS_ORDERS (MED_PATIENT_ID,MED_VISIT_ID,MED_ORDER_NO,MED_ORDER_SUB_NO,MED_REPEAT_INDICATOR,HIS_ORDER_NO,HIS_ORDER_SUB_NO,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05) values (:MedPatientId,:MedVisitId,:MedOrderNo,:MedOrderSubNo,:MedRepeatIndicator,:HisOrderNo,:HisOrderSubNo,:CreateDate,:Reserved01,:Reserved02,:Reserved03,:Reserved04,:Reserved05)";
        private static readonly string MED_VS_HIS_ORDERS_Update = "UPDATE MED_VS_HIS_ORDERS SET MED_PATIENT_ID=:MedPatientId,MED_VISIT_ID=:MedVisitId,MED_ORDER_NO=:MedOrderNo,MED_ORDER_SUB_NO=:MedOrderSubNo,MED_REPEAT_INDICATOR=:MedRepeatIndicator,HIS_ORDER_NO=:HisOrderNo,HIS_ORDER_SUB_NO=:HisOrderSubNo,CREATE_DATE=:CreateDate,RESERVED01=:Reserved01,RESERVED02=:Reserved02,RESERVED03=:Reserved03,RESERVED04=:Reserved04,RESERVED05=:Reserved05 WHERE MED_PATIENT_ID=:MedPatientId AND MED_VISIT_ID=:MedVisitId AND MED_ORDER_NO=:MedOrderNo AND MED_ORDER_SUB_NO=:MedOrderSubNo AND MED_REPEAT_INDICATOR=:MedRepeatIndicator";
        private static readonly string MED_VS_HIS_ORDERS_Delete = "Delete MED_VS_HIS_ORDERS WHERE MED_PATIENT_ID=:MedPatientId AND MED_VISIT_ID=:MedVisitId AND MED_ORDER_NO=:MedOrderNo AND MED_ORDER_SUB_NO=:MedOrderSubNo AND MED_REPEAT_INDICATOR=:MedRepeatIndicator";
        private static readonly string MED_VS_HIS_ORDERS_Select = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_ORDER_NO,MED_ORDER_SUB_NO,MED_REPEAT_INDICATOR,HIS_ORDER_NO,HIS_ORDER_SUB_NO,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05 FROM MED_VS_HIS_ORDERS where MED_PATIENT_ID=:MedPatientId AND MED_VISIT_ID=:MedVisitId AND MED_ORDER_NO=:MedOrderNo AND MED_ORDER_SUB_NO=:MedOrderSubNo AND MED_REPEAT_INDICATOR=:MedRepeatIndicator";
		private static readonly string MED_VS_HIS_ORDERS_Select_ALL = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_ORDER_NO,MED_ORDER_SUB_NO,MED_REPEAT_INDICATOR,HIS_ORDER_NO,HIS_ORDER_SUB_NO,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05 FROM MED_VS_HIS_ORDERS";
        private static readonly string MED_VS_HIS_ORDERS_His_Select = "select med_patient_id, med_visit_id, med_order_no, med_order_sub_no, med_repeat_indicator, his_order_no, his_order_sub_no, create_date, reserved01, reserved02, reserved03, reserved04, reserved05 from med_vs_his_orders where his_order_no = :hisOrderNo and his_order_sub_no = :hisOrderSubNo and create_date = :createDate ";
        private static readonly string MED_VS_HIS_ORDERS_His_Only_Select = "select med_patient_id, med_visit_id, med_order_no, med_order_sub_no, med_repeat_indicator, his_order_no, his_order_sub_no, create_date, reserved01, reserved02, reserved03, reserved04, reserved05 from med_vs_his_orders where med_patient_id = :medPatientId and med_visit_id = :medVisitId and his_order_no = :hisOrderNo and his_order_sub_no = :hisOrderSubNo and create_date = :createDate ";
        private static readonly string MED_VS_HIS_ORDERSSubNo_Select_Top = "select Max(med_order_sub_no) from med_vs_his_orders where med_patient_id = :medPatientId and med_visit_id = :medVisitId and med_order_no = :medOrderNo ";
        private static readonly string MED_VS_HIS_ORDERSSubNo_FromHis_Select_Top = "select Max(med_order_sub_no) from med_vs_his_orders where med_patient_id = :medPatientId and med_visit_id = :medVisitId and his_order_sub_no = :hisOrderSubNo ";
        private static readonly string MED_ORDERSNO_Select_Top = "select Max(order_no) from med_orders";
        
        public DALMedVsHisOrders ()
		{
		}
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedVsHisOrders SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOrders")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@MedPatientId",SqlDbType.VarChar),
						new SqlParameter("@MedVisitId",SqlDbType.Decimal),
						new SqlParameter("@MedOrderNo",SqlDbType.VarChar),
						new SqlParameter("@MedOrderSubNo",SqlDbType.Decimal),
						new SqlParameter("@MedRepeatIndicator",SqlDbType.Decimal),
						new SqlParameter("@HisOrderNo",SqlDbType.VarChar),
						new SqlParameter("@HisOrderSubNo",SqlDbType.VarChar),
						new SqlParameter("@CreateDate",SqlDbType.DateTime),
						new SqlParameter("@Reserved01",SqlDbType.VarChar),
						new SqlParameter("@Reserved02",SqlDbType.VarChar),
						new SqlParameter("@Reserved03",SqlDbType.VarChar),
						new SqlParameter("@Reserved04",SqlDbType.VarChar),
						new SqlParameter("@Reserved05",SqlDbType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedVsHisOrders")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@MedPatientId",SqlDbType.VarChar),
						new SqlParameter("@MedVisitId",SqlDbType.Decimal),
						new SqlParameter("@MedOrderNo",SqlDbType.VarChar),
						new SqlParameter("@MedOrderSubNo",SqlDbType.Decimal),
						new SqlParameter("@MedRepeatIndicator",SqlDbType.Decimal),
						new SqlParameter("@HisOrderNo",SqlDbType.VarChar),
						new SqlParameter("@HisOrderSubNo",SqlDbType.VarChar),
						new SqlParameter("@CreateDate",SqlDbType.DateTime),
						new SqlParameter("@Reserved01",SqlDbType.VarChar),
						new SqlParameter("@Reserved02",SqlDbType.VarChar),
						new SqlParameter("@Reserved03",SqlDbType.VarChar),
						new SqlParameter("@Reserved04",SqlDbType.VarChar),
						new SqlParameter("@Reserved05",SqlDbType.VarChar),
                        new SqlParameter("@MedPatientIdP",SqlDbType.VarChar),
                        new SqlParameter("@MedVisitIdP",SqlDbType.Decimal),
                        new SqlParameter("@MedOrderNoP",SqlDbType.Decimal),
                        new SqlParameter("@MedOrderSubNoP",SqlDbType.Decimal),
                        new SqlParameter("@MedRepeatIndicatorP",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedVsHisOrders")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@MedPatientId",SqlDbType.VarChar),
						new SqlParameter("@MedVisitId",SqlDbType.Decimal),
						new SqlParameter("@MedOrderNo",SqlDbType.VarChar),
						new SqlParameter("@MedOrderSubNo",SqlDbType.Decimal),
						new SqlParameter("@MedRepeatIndicator",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "SelectMedVsHisOrders")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@MedPatientId",SqlDbType.VarChar),
						new SqlParameter("@MedVisitId",SqlDbType.Decimal),
						new SqlParameter("@MedOrderNo",SqlDbType.VarChar),
						new SqlParameter("@MedOrderSubNo",SqlDbType.Decimal),
						new SqlParameter("@MedRepeatIndicator",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOrdersHis")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@HisOrderNo",SqlDbType.VarChar),
						new SqlParameter("@HisOrderSubNo",SqlDbType.VarChar),
						new SqlParameter("@CreateDate",SqlDbType.DateTime),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOrdersHisOnly")
                {
                    parms = new SqlParameter[]{
                        new SqlParameter("@MedPatientId",SqlDbType.VarChar),
					    new SqlParameter("@MedVisitId",SqlDbType.Decimal),
						new SqlParameter("@HisOrderNo",SqlDbType.VarChar),
						new SqlParameter("@HisOrderSubNo",SqlDbType.VarChar),
						new SqlParameter("@CreateDate",SqlDbType.DateTime),
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisOrdersOrderSubNo")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@MedPatientId",SqlDbType.VarChar),
						new SqlParameter("@MedVisitId",SqlDbType.Decimal),
						new SqlParameter("@MedOrderNo",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisOrdersOrderSubNoFromHis")
                {
                    parms = new SqlParameter[]{
						new SqlParameter("@MedPatientId",SqlDbType.VarChar),
						new SqlParameter("@MedVisitId",SqlDbType.Decimal),
                        new SqlParameter("@HisOrderNo",SqlDbType.VarChar),
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedVsHisOrders 
		///Insert Table MED_VS_HIS_ORDERS
		/// </summary>
		public int InsertMedVsHisOrdersSQL(MedVsHisOrders model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedVsHisOrders");
					if (model.MedPatientId != null)
						oneInert[0].Value = model.MedPatientId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.MedVisitId.ToString() != null)
						oneInert[1].Value = model.MedVisitId;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.MedOrderNo.ToString() != null)
						oneInert[2].Value = model.MedOrderNo;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.MedOrderSubNo.ToString() != null)
						oneInert[3].Value = model.MedOrderSubNo;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.MedRepeatIndicator.ToString() != null)
						oneInert[4].Value = model.MedRepeatIndicator;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.HisOrderNo != null)
						oneInert[5].Value = model.HisOrderNo;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.HisOrderSubNo != null)
						oneInert[6].Value = model.HisOrderSubNo;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.CreateDate > DateTime.MinValue)
						oneInert[7].Value = model.CreateDate;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.Reserved01 != null)
						oneInert[8].Value = model.Reserved01;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.Reserved02 != null)
						oneInert[9].Value = model.Reserved02;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.Reserved03 != null)
						oneInert[10].Value = model.Reserved03;
					else
						oneInert[10].Value = DBNull.Value;
					if (model.Reserved04 != null)
						oneInert[11].Value = model.Reserved04;
					else
						oneInert[11].Value = DBNull.Value;
					if (model.Reserved05 != null)
						oneInert[12].Value = model.Reserved05;
					else
						oneInert[12].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_ORDERS_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedVsHisOrders 
		///Update Table     MED_VS_HIS_ORDERS
		/// </summary>
		public int UpdateMedVsHisOrdersSQL(MedVsHisOrders model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedVsHisOrders");
					if (model.MedPatientId != null)
						oneUpdate[0].Value = model.MedPatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.MedVisitId.ToString() != null)
						oneUpdate[1].Value = model.MedVisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.MedOrderNo.ToString() != null)
						oneUpdate[2].Value = model.MedOrderNo;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.MedOrderSubNo.ToString() != null)
						oneUpdate[3].Value = model.MedOrderSubNo;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.MedRepeatIndicator.ToString() != null)
						oneUpdate[4].Value = model.MedRepeatIndicator;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.HisOrderNo != null)
						oneUpdate[5].Value = model.HisOrderNo;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.HisOrderSubNo != null)
						oneUpdate[6].Value = model.HisOrderSubNo;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.CreateDate > DateTime.MinValue)
						oneUpdate[7].Value = model.CreateDate;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.Reserved01 != null)
						oneUpdate[8].Value = model.Reserved01;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.Reserved02 != null)
						oneUpdate[9].Value = model.Reserved02;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.Reserved03 != null)
						oneUpdate[10].Value = model.Reserved03;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.Reserved04 != null)
						oneUpdate[11].Value = model.Reserved04;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.Reserved05 != null)
						oneUpdate[12].Value = model.Reserved05;
					else
						oneUpdate[12].Value = DBNull.Value;
                    if (model.MedPatientId != null)
                        oneUpdate[13].Value = model.MedPatientId;
                    else
                        oneUpdate[13].Value = DBNull.Value;
                    if (model.MedVisitId.ToString() != null)
                        oneUpdate[14].Value = model.MedVisitId;
                    else
                        oneUpdate[14].Value = DBNull.Value;
                    if (model.MedOrderNo.ToString() != null)
                        oneUpdate[15].Value = model.MedOrderNo;
                    else
                        oneUpdate[15].Value = DBNull.Value;
                    if (model.MedOrderSubNo.ToString() != null)
                        oneUpdate[16].Value = model.MedOrderSubNo;
                    else
                        oneUpdate[16].Value = DBNull.Value;
                    if (model.MedRepeatIndicator.ToString() != null)
                        oneUpdate[17].Value = model.MedRepeatIndicator;
                    else
                        oneUpdate[17].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_ORDERS_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedVsHisOrders 
		///Delete Table MED_VS_HIS_ORDERS by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_ORDER_NO,decimal MED_ORDER_SUB_NO,decimal MED_REPEAT_INDICATOR)
		/// </summary>
		public int DeleteMedVsHisOrdersSQL(string MED_PATIENT_ID,decimal MED_VISIT_ID,string MED_ORDER_NO,decimal MED_ORDER_SUB_NO,decimal MED_REPEAT_INDICATOR)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedVsHisOrders");
					if (MED_PATIENT_ID != null)
						oneDelete[0].Value =MED_PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (MED_VISIT_ID.ToString() != null)
						oneDelete[1].Value =MED_VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
                    if (MED_ORDER_NO.ToString() != null)
						oneDelete[2].Value =MED_ORDER_NO;
					else
						oneDelete[2].Value = DBNull.Value;
                    if (MED_ORDER_SUB_NO.ToString() != null)
						oneDelete[3].Value =MED_ORDER_SUB_NO;
					else
						oneDelete[3].Value = DBNull.Value;
                    if (MED_REPEAT_INDICATOR.ToString() != null)
						oneDelete[4].Value =MED_REPEAT_INDICATOR;
					else
						oneDelete[4].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_ORDERS_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedVsHisOrders 
		///select Table MED_VS_HIS_ORDERS by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_ORDER_NO,decimal MED_ORDER_SUB_NO,decimal MED_REPEAT_INDICATOR)
		/// </summary>
		public MedVsHisOrders  SelectMedVsHisOrdersSQL(string MED_PATIENT_ID,decimal MED_VISIT_ID,string MED_ORDER_NO,decimal MED_ORDER_SUB_NO,decimal MED_REPEAT_INDICATOR)
		{
			MedVsHisOrders model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedVsHisOrders");
				parameterValues[0].Value=MED_PATIENT_ID;
				parameterValues[1].Value=MED_VISIT_ID;
				parameterValues[2].Value=MED_ORDER_NO;
				parameterValues[3].Value=MED_ORDER_SUB_NO;
				parameterValues[4].Value=MED_REPEAT_INDICATOR;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedVsHisOrders();
						if (!oleReader.IsDBNull(0))
						{
							model.MedPatientId = oleReader["MED_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.MedVisitId = decimal.Parse(oleReader["MED_VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MedOrderNo = oleReader["MED_ORDER_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.MedOrderSubNo = decimal.Parse(oleReader["MED_ORDER_SUB_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.MedRepeatIndicator = decimal.Parse(oleReader["MED_REPEAT_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.HisOrderNo = oleReader["HIS_ORDER_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.HisOrderSubNo = oleReader["HIS_ORDER_SUB_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Reserved04 = oleReader["RESERVED04"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.Reserved05 = oleReader["RESERVED05"].ToString().Trim() ;
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
		public List<MedVsHisOrders> SelectMedVsHisOrdersListSQL()
		{
			List<MedVsHisOrders> modelList = new List<MedVsHisOrders>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedVsHisOrders model = new MedVsHisOrders();
						if (!oleReader.IsDBNull(0))
						{
							model.MedPatientId = oleReader["MED_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.MedVisitId = decimal.Parse(oleReader["MED_VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MedOrderNo = oleReader["MED_ORDER_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.MedOrderSubNo = decimal.Parse(oleReader["MED_ORDER_SUB_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.MedRepeatIndicator = decimal.Parse(oleReader["MED_REPEAT_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.HisOrderNo = oleReader["HIS_ORDER_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.HisOrderSubNo = oleReader["HIS_ORDER_SUB_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Reserved04 = oleReader["RESERVED04"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.Reserved05 = oleReader["RESERVED05"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
        /// <summary>
        /// 获取医嘱信息
        /// </summary>
        /// <param name="hisOrderNo">HIS医嘱主编号</param>
        /// <param name="hisOrderSubNo">HIS医嘱子编号</param>
        /// <param name="createDate">创建时间</param>
        /// <returns></returns>
        public Model.MedVsHisOrders SelectMedVsHisOrdersHisSQL(string hisOrderNo, string hisOrderSubNo, DateTime createDate)
        {
            Model.MedVsHisOrders oneMedVsHisOrders = null;
            SqlParameter[] MedVsHisOrdersParams = GetParameterSQL("SelectMedVsHisOrdersHis");
            MedVsHisOrdersParams[0].Value = hisOrderNo;
            MedVsHisOrdersParams[1].Value = hisOrderSubNo;
            MedVsHisOrdersParams[2].Value = createDate;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_His_Select_SQL, MedVsHisOrdersParams))
            {
                if (oleReader.Read())
                {
                    oneMedVsHisOrders = new Model.MedVsHisOrders();
                    if (!oleReader.IsDBNull(0))
                        oneMedVsHisOrders.MedPatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisOrders.MedVisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisOrders.MedOrderNo = oleReader.GetString(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisOrders.MedOrderSubNo = oleReader.GetDecimal(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisOrders.MedRepeatIndicator = oleReader.GetDecimal(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisOrders.HisOrderNo = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisOrders.HisOrderSubNo = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisOrders.CreateDate = oleReader.GetDateTime(7);
                    if (!oleReader.IsDBNull(8))
                        oneMedVsHisOrders.Reserved01 = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        oneMedVsHisOrders.Reserved02 = oleReader.GetString(9);
                    if (!oleReader.IsDBNull(10))
                        oneMedVsHisOrders.Reserved03 = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        oneMedVsHisOrders.Reserved04 = oleReader.GetString(11);
                    if (!oleReader.IsDBNull(12))
                        oneMedVsHisOrders.Reserved05 = oleReader.GetString(12);
                }
                else
                    oneMedVsHisOrders = null;
            }
            return oneMedVsHisOrders;
        }
        /// <summary>
        /// 获取医嘱信息
        /// </summary>
        /// <param name="medPatientId">病人ID号</param>
        /// <param name="medVisitId">病人住院次数</param>
        /// <param name="hisOrderNo">HIS医嘱主编号</param>
        /// <param name="hisOrderSubNo">HIS医嘱子编号</param>
        /// <param name="createDate">创建时间</param>
        /// <returns></returns>
        public Model.MedVsHisOrders SelectMedVsHisOrdersHisSQL(string medPatientId, decimal medVisitId, string hisOrderNo, string hisOrderSubNo, DateTime createDate)
        {
            Model.MedVsHisOrders oneMedVsHisOrders = null;
            SqlParameter[] MedVsHisOrdersParams = GetParameterSQL("SelectMedVsHisOrdersHisOnly");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = hisOrderNo;
            MedVsHisOrdersParams[3].Value = hisOrderSubNo;
            MedVsHisOrdersParams[4].Value = createDate;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_His_Only_Select_SQL, MedVsHisOrdersParams))
            {
                if (oleReader.Read())
                {
                    oneMedVsHisOrders = new Model.MedVsHisOrders();
                    if (!oleReader.IsDBNull(0))
                        oneMedVsHisOrders.MedPatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisOrders.MedVisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisOrders.MedOrderNo = oleReader.GetString(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisOrders.MedOrderSubNo = oleReader.GetDecimal(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisOrders.MedRepeatIndicator = oleReader.GetDecimal(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisOrders.HisOrderNo = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisOrders.HisOrderSubNo = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisOrders.CreateDate = oleReader.GetDateTime(7);
                    if (!oleReader.IsDBNull(8))
                        oneMedVsHisOrders.Reserved01 = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        oneMedVsHisOrders.Reserved02 = oleReader.GetString(9);
                    if (!oleReader.IsDBNull(10))
                        oneMedVsHisOrders.Reserved03 = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        oneMedVsHisOrders.Reserved04 = oleReader.GetString(11);
                    if (!oleReader.IsDBNull(12))
                        oneMedVsHisOrders.Reserved05 = oleReader.GetString(12);
                }
                else
                    oneMedVsHisOrders = null;
            }
            return oneMedVsHisOrders;
        }
        /// <summary>
        /// 获取最大主医嘱编号
        /// </summary>
        /// <returns></returns>
        public int SelectMaxMedOrdersSQL()
        {
            object count = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, MED_ORDERSNO_Select_Top_SQL, null);
            if (count == null || count == DBNull.Value)
                count = (object)0;
            return Convert.ToInt32(count);
        }
        /// <summary>
        /// 获取最大子医嘱编号
        /// </summary>
        /// <param name="medPatientId">病人ID号</param>
        /// <param name="medVisitId">病人住院次数</param>
        /// <param name="medOrderNo">主医嘱编号</param>
        /// <returns></returns>
        public int SelectMaxMedOrdersSubNoSQL(string medPatientId, decimal medVisitId, string medOrderNo)
        {
            SqlParameter[] MedVsHisOrdersParams = GetParameterSQL("SelectMaxMedVsHisOrdersOrderSubNo");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = medOrderNo;

            object count = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERSSubNo_Select_Top_SQL, MedVsHisOrdersParams);
            if (count == null || count == DBNull.Value)
                count = (object)0;
            return Convert.ToInt32(count);

        }
        /// <summary>
        /// 获取最大子医嘱编号
        /// </summary>
        /// <param name="medPatientId">病人ID号</param>
        /// <param name="medVisitId">病人住院次数</param>
        /// <param name="HisOrderSubNo">HIS医嘱编号</param>
        /// <returns></returns>
        public int SelectMaxMedOrdersSubNoFromHisSQL(string medPatientId, decimal medVisitId, string HisOrderSubNo)
        {
            SqlParameter[] MedVsHisOrdersParams = GetParameterSQL("SelectMaxMedVsHisOrdersOrderSubNoFromHis");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = HisOrderSubNo;

            object count = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERSSubNo_FromHis_Select_Top_SQL, MedVsHisOrdersParams);
            if (count == null || count == DBNull.Value)
                count = (object)0;
            return Convert.ToInt32(count);

        }

		#region [获取参数]
		/// <summary>
		///获取参数MedVsHisOrders
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOrders")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":MedPatientId",OracleType.VarChar),
						new OracleParameter(":MedVisitId",OracleType.Number),
						new OracleParameter(":MedOrderNo",OracleType.VarChar),
						new OracleParameter(":MedOrderSubNo",OracleType.Number),
						new OracleParameter(":MedRepeatIndicator",OracleType.Number),
						new OracleParameter(":HisOrderNo",OracleType.VarChar),
						new OracleParameter(":HisOrderSubNo",OracleType.VarChar),
						new OracleParameter(":CreateDate",OracleType.DateTime),
						new OracleParameter(":Reserved01",OracleType.VarChar),
						new OracleParameter(":Reserved02",OracleType.VarChar),
						new OracleParameter(":Reserved03",OracleType.VarChar),
						new OracleParameter(":Reserved04",OracleType.VarChar),
						new OracleParameter(":Reserved05",OracleType.VarChar),
                    };
                }
				else if (sqlParms == "UpdateMedVsHisOrders")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":MedPatientId",OracleType.VarChar),
						new OracleParameter(":MedVisitId",OracleType.Number),
						new OracleParameter(":MedOrderNo",OracleType.VarChar),
						new OracleParameter(":MedOrderSubNo",OracleType.Number),
						new OracleParameter(":MedRepeatIndicator",OracleType.Number),
						new OracleParameter(":HisOrderNo",OracleType.VarChar),
						new OracleParameter(":HisOrderSubNo",OracleType.VarChar),
						new OracleParameter(":CreateDate",OracleType.DateTime),
						new OracleParameter(":Reserved01",OracleType.VarChar),
						new OracleParameter(":Reserved02",OracleType.VarChar),
						new OracleParameter(":Reserved03",OracleType.VarChar),
						new OracleParameter(":Reserved04",OracleType.VarChar),
						new OracleParameter(":Reserved05",OracleType.VarChar),
						new OracleParameter(":MedPatientId",SqlDbType.VarChar),
						new OracleParameter(":MedVisitId",SqlDbType.Decimal),
						new OracleParameter(":MedOrderNo",SqlDbType.Decimal),
						new OracleParameter(":MedOrderSubNo",SqlDbType.Decimal),
						new OracleParameter(":MedRepeatIndicator",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedVsHisOrders")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":MedPatientId",OracleType.VarChar),
						new OracleParameter(":MedVisitId",OracleType.Number),
						new OracleParameter(":MedOrderNo",OracleType.VarChar),
						new OracleParameter(":MedOrderSubNo",OracleType.Number),
						new OracleParameter(":MedRepeatIndicator",OracleType.Number),
                    };
                }
				else if(sqlParms == "SelectMedVsHisOrders")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":MedPatientId",OracleType.VarChar),
						new OracleParameter(":MedVisitId",OracleType.Number),
						new OracleParameter(":MedOrderNo",OracleType.VarChar),
						new OracleParameter(":MedOrderSubNo",OracleType.Number),
						new OracleParameter(":MedRepeatIndicator",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOrdersHis")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":HisOrderNo",OracleType.VarChar),
						new OracleParameter(":HisOrderSubNo",OracleType.VarChar),
						new OracleParameter(":CreateDate",OracleType.DateTime),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOrdersHisOnly")
                {
                    parms = new OracleParameter[]{
                        new OracleParameter(":MedPatientId",OracleType.VarChar),
						new OracleParameter(":MedVisitId",OracleType.Number),
						new OracleParameter(":HisOrderNo",OracleType.VarChar),
						new OracleParameter(":HisOrderSubNo",OracleType.VarChar),
						new OracleParameter(":CreateDate",OracleType.DateTime),
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisOrdersOrderSubNo")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":MedPatientId",OracleType.VarChar),
						new OracleParameter(":MedVisitId",OracleType.Number),
						new OracleParameter(":MedOrderNo",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisOrdersOrderSubNoFromHis")
                {
                    parms = new OracleParameter[]{
						new OracleParameter(":MedPatientId",OracleType.VarChar),
						new OracleParameter(":MedVisitId",OracleType.Number),
                        new OracleParameter(":HisOrderSubNo",OracleType.VarChar),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedVsHisOrders 
		///Insert Table MED_VS_HIS_ORDERS
		/// </summary>
		public int InsertMedVsHisOrders(MedVsHisOrders model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedVsHisOrders");
					if (model.MedPatientId != null)
						oneInert[0].Value = model.MedPatientId;
					else
						oneInert[0].Value = DBNull.Value;
					if (model.MedVisitId.ToString() != null)
						oneInert[1].Value = model.MedVisitId;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.MedOrderNo.ToString() != null)
						oneInert[2].Value = model.MedOrderNo;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.MedOrderSubNo.ToString() != null)
						oneInert[3].Value = model.MedOrderSubNo;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.MedRepeatIndicator.ToString() != null)
						oneInert[4].Value = model.MedRepeatIndicator;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.HisOrderNo != null)
						oneInert[5].Value = model.HisOrderNo;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.HisOrderSubNo != null)
						oneInert[6].Value = model.HisOrderSubNo;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.CreateDate > DateTime.MinValue)
						oneInert[7].Value = model.CreateDate;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.Reserved01 != null)
						oneInert[8].Value = model.Reserved01;
					else
						oneInert[8].Value = DBNull.Value;
					if (model.Reserved02 != null)
						oneInert[9].Value = model.Reserved02;
					else
						oneInert[9].Value = DBNull.Value;
					if (model.Reserved03 != null)
						oneInert[10].Value = model.Reserved03;
					else
						oneInert[10].Value = DBNull.Value;
					if (model.Reserved04 != null)
						oneInert[11].Value = model.Reserved04;
					else
						oneInert[11].Value = DBNull.Value;
					if (model.Reserved05 != null)
						oneInert[12].Value = model.Reserved05;
					else
						oneInert[12].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_ORDERS_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedVsHisOrders 
		///Update Table     MED_VS_HIS_ORDERS
		/// </summary>
		public int UpdateMedVsHisOrders(MedVsHisOrders model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedVsHisOrders");
					if (model.MedPatientId != null)
						oneUpdate[0].Value = model.MedPatientId;
					else
						oneUpdate[0].Value = DBNull.Value;
					if (model.MedVisitId.ToString() != null)
						oneUpdate[1].Value = model.MedVisitId;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.MedOrderNo.ToString() != null)
						oneUpdate[2].Value = model.MedOrderNo;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.MedOrderSubNo.ToString() != null)
						oneUpdate[3].Value = model.MedOrderSubNo;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.MedRepeatIndicator.ToString() != null)
						oneUpdate[4].Value = model.MedRepeatIndicator;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.HisOrderNo != null)
						oneUpdate[5].Value = model.HisOrderNo;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.HisOrderSubNo != null)
						oneUpdate[6].Value = model.HisOrderSubNo;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.CreateDate > DateTime.MinValue)
						oneUpdate[7].Value = model.CreateDate;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.Reserved01 != null)
						oneUpdate[8].Value = model.Reserved01;
					else
						oneUpdate[8].Value = DBNull.Value;
					if (model.Reserved02 != null)
						oneUpdate[9].Value = model.Reserved02;
					else
						oneUpdate[9].Value = DBNull.Value;
					if (model.Reserved03 != null)
						oneUpdate[10].Value = model.Reserved03;
					else
						oneUpdate[10].Value = DBNull.Value;
					if (model.Reserved04 != null)
						oneUpdate[11].Value = model.Reserved04;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.Reserved05 != null)
						oneUpdate[12].Value = model.Reserved05;
					else
						oneUpdate[12].Value = DBNull.Value;
					if (model.MedPatientId != null)
						oneUpdate[13].Value =model.MedPatientId;
					else
						oneUpdate[13].Value = DBNull.Value;
					if (model.MedVisitId.ToString() != null)
						oneUpdate[14].Value =model.MedVisitId;
					else
						oneUpdate[14].Value = DBNull.Value;
					if (model.MedOrderNo.ToString() != null)
						oneUpdate[15].Value =model.MedOrderNo;
					else
						oneUpdate[15].Value = DBNull.Value;
					if (model.MedOrderSubNo.ToString() != null)
						oneUpdate[16].Value =model.MedOrderSubNo;
					else
						oneUpdate[16].Value = DBNull.Value;
					if (model.MedRepeatIndicator.ToString() != null)
						oneUpdate[17].Value =model.MedRepeatIndicator;
					else
						oneUpdate[17].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_ORDERS_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedVsHisOrders 
		///Delete Table MED_VS_HIS_ORDERS by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_ORDER_NO,decimal MED_ORDER_SUB_NO,decimal MED_REPEAT_INDICATOR)
		/// </summary>
		public int DeleteMedVsHisOrders(string MED_PATIENT_ID,decimal MED_VISIT_ID,string MED_ORDER_NO,decimal MED_ORDER_SUB_NO,decimal MED_REPEAT_INDICATOR)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedVsHisOrders");
					if (MED_PATIENT_ID != null)
						oneDelete[0].Value =MED_PATIENT_ID;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (MED_VISIT_ID.ToString() != null)
						oneDelete[1].Value =MED_VISIT_ID;
					else
						oneDelete[1].Value = DBNull.Value;
                    if (MED_ORDER_NO.ToString() != null)
						oneDelete[2].Value =MED_ORDER_NO;
					else
						oneDelete[2].Value = DBNull.Value;
                    if (MED_ORDER_SUB_NO.ToString() != null)
						oneDelete[3].Value =MED_ORDER_SUB_NO;
					else
						oneDelete[3].Value = DBNull.Value;
					if (MED_REPEAT_INDICATOR.ToString() != null)
						oneDelete[4].Value =MED_REPEAT_INDICATOR;
					else
						oneDelete[4].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_ORDERS_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedVsHisOrders 
		///select Table MED_VS_HIS_ORDERS by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_ORDER_NO,decimal MED_ORDER_SUB_NO,decimal MED_REPEAT_INDICATOR)
		/// </summary>
		public MedVsHisOrders  SelectMedVsHisOrders(string MED_PATIENT_ID,decimal MED_VISIT_ID,string MED_ORDER_NO,decimal MED_ORDER_SUB_NO,decimal MED_REPEAT_INDICATOR)
		{
			MedVsHisOrders model;
			OracleParameter[] parameterValues = GetParameter("SelectMedVsHisOrders");
				parameterValues[0].Value=MED_PATIENT_ID;
				parameterValues[1].Value=MED_VISIT_ID;
				parameterValues[2].Value=MED_ORDER_NO;
				parameterValues[3].Value=MED_ORDER_SUB_NO;
				parameterValues[4].Value=MED_REPEAT_INDICATOR;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedVsHisOrders();
						if (!oleReader.IsDBNull(0))
						{
							model.MedPatientId = oleReader["MED_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.MedVisitId = decimal.Parse(oleReader["MED_VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MedOrderNo = oleReader["MED_ORDER_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.MedOrderSubNo = decimal.Parse(oleReader["MED_ORDER_SUB_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.MedRepeatIndicator = decimal.Parse(oleReader["MED_REPEAT_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.HisOrderNo = oleReader["HIS_ORDER_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.HisOrderSubNo = oleReader["HIS_ORDER_SUB_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Reserved04 = oleReader["RESERVED04"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.Reserved05 = oleReader["RESERVED05"].ToString().Trim() ;
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
		public List<MedVsHisOrders> SelectMedVsHisOrdersList()
		{
			List<MedVsHisOrders> modelList = new List<MedVsHisOrders>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedVsHisOrders model = new MedVsHisOrders();
						if (!oleReader.IsDBNull(0))
						{
							model.MedPatientId = oleReader["MED_PATIENT_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.MedVisitId = decimal.Parse(oleReader["MED_VISIT_ID"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MedOrderNo = oleReader["MED_ORDER_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.MedOrderSubNo = decimal.Parse(oleReader["MED_ORDER_SUB_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.MedRepeatIndicator = decimal.Parse(oleReader["MED_REPEAT_INDICATOR"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.HisOrderNo = oleReader["HIS_ORDER_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.HisOrderSubNo = oleReader["HIS_ORDER_SUB_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.Reserved01 = oleReader["RESERVED01"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.Reserved02 = oleReader["RESERVED02"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Reserved03 = oleReader["RESERVED03"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.Reserved04 = oleReader["RESERVED04"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.Reserved05 = oleReader["RESERVED05"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
        /// <summary>
        /// 获取医嘱信息
        /// </summary>
        /// <param name="hisOrderNo">HIS医嘱主编号</param>
        /// <param name="hisOrderSubNo">HIS医嘱子编号</param>
        /// <param name="createDate">创建时间</param>
        /// <returns></returns>
        public Model.MedVsHisOrders SelectMedVsHisOrdersHis(string hisOrderNo, string hisOrderSubNo, DateTime createDate)
        {
            Model.MedVsHisOrders oneMedVsHisOrders = null;
            OracleParameter[] MedVsHisOrdersParams = GetParameter("SelectMedVsHisOrdersHis");
            MedVsHisOrdersParams[0].Value = hisOrderNo;
            MedVsHisOrdersParams[1].Value = hisOrderSubNo;
            MedVsHisOrdersParams[2].Value = createDate;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_His_Select, MedVsHisOrdersParams))
            {
                if (oleReader.Read())
                {
                    oneMedVsHisOrders = new Model.MedVsHisOrders();
                    if (!oleReader.IsDBNull(0))
                        oneMedVsHisOrders.MedPatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisOrders.MedVisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisOrders.MedOrderNo = oleReader.GetString(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisOrders.MedOrderSubNo = oleReader.GetDecimal(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisOrders.MedRepeatIndicator = oleReader.GetDecimal(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisOrders.HisOrderNo = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisOrders.HisOrderSubNo = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisOrders.CreateDate = oleReader.GetDateTime(7);
                    if (!oleReader.IsDBNull(8))
                        oneMedVsHisOrders.Reserved01 = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        oneMedVsHisOrders.Reserved02 = oleReader.GetString(9);
                    if (!oleReader.IsDBNull(10))
                        oneMedVsHisOrders.Reserved03 = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        oneMedVsHisOrders.Reserved04 = oleReader.GetString(11);
                    if (!oleReader.IsDBNull(12))
                        oneMedVsHisOrders.Reserved05 = oleReader.GetString(12);
                }
                else
                    oneMedVsHisOrders = null;
            }
            return oneMedVsHisOrders;
        }
        /// <summary>
        /// 获取医嘱信息
        /// </summary>
        /// <param name="medPatientId">病人ID号</param>
        /// <param name="medVisitId">病人住院次数</param>
        /// <param name="hisOrderNo">HIS医嘱主编号</param>
        /// <param name="hisOrderSubNo">HIS医嘱子编号</param>
        /// <param name="createDate">创建时间</param>
        /// <returns></returns>
        public Model.MedVsHisOrders SelectMedVsHisOrdersHis(string medPatientId, decimal medVisitId, string hisOrderNo, string hisOrderSubNo, DateTime createDate)
        {
            Model.MedVsHisOrders oneMedVsHisOrders = null;
            OracleParameter[] MedVsHisOrdersParams = GetParameter("SelectMedVsHisOrdersHisOnly");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = hisOrderNo;
            MedVsHisOrdersParams[3].Value = hisOrderSubNo;
            MedVsHisOrdersParams[4].Value = createDate;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_His_Only_Select, MedVsHisOrdersParams))
            {
                if (oleReader.Read())
                {
                    oneMedVsHisOrders = new Model.MedVsHisOrders();
                    if (!oleReader.IsDBNull(0))
                        oneMedVsHisOrders.MedPatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisOrders.MedVisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisOrders.MedOrderNo = oleReader.GetString(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisOrders.MedOrderSubNo = oleReader.GetDecimal(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisOrders.MedRepeatIndicator = oleReader.GetDecimal(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisOrders.HisOrderNo = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisOrders.HisOrderSubNo = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisOrders.CreateDate = oleReader.GetDateTime(7);
                    if (!oleReader.IsDBNull(8))
                        oneMedVsHisOrders.Reserved01 = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        oneMedVsHisOrders.Reserved02 = oleReader.GetString(9);
                    if (!oleReader.IsDBNull(10))
                        oneMedVsHisOrders.Reserved03 = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        oneMedVsHisOrders.Reserved04 = oleReader.GetString(11);
                    if (!oleReader.IsDBNull(12))
                        oneMedVsHisOrders.Reserved05 = oleReader.GetString(12);
                }
                else
                    oneMedVsHisOrders = null;
            }
            return oneMedVsHisOrders;
        }
        /// <summary>
        /// 获取最大主医嘱编号
        /// </summary>
        /// <returns></returns>
        public int SelectMaxMedOrders()
        {
            object count = OracleHelper.ExecuteScalar(OracleHelper.ConnectionString, CommandType.Text, MED_ORDERSNO_Select_Top, null);
            if (count == null || count == DBNull.Value)
                count = (object)0;
            return Convert.ToInt32(count);
        }
        /// <summary>
        /// 获取最大子医嘱编号
        /// </summary>
        /// <param name="medPatientId">病人ID号</param>
        /// <param name="medVisitId">病人住院次数</param>
        /// <param name="medOrderNo">主医嘱编号</param>
        /// <returns></returns>
        public int SelectMaxMedOrdersSubNo(string medPatientId, decimal medVisitId, string medOrderNo)
        {
            OracleParameter[] MedVsHisOrdersParams = GetParameter("SelectMaxMedVsHisOrdersOrderSubNo");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = medOrderNo;

            object count = OracleHelper.ExecuteScalar(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERSSubNo_Select_Top, MedVsHisOrdersParams);
            if (count == null || count == DBNull.Value)
                count = (object)0;
            return Convert.ToInt32(count);

        }
        /// <summary>
        /// 获取最大子医嘱编号
        /// </summary>
        /// <param name="medPatientId">病人ID号</param>
        /// <param name="medVisitId">病人住院次数</param>
        /// <param name="medOrderNo">主医嘱编号</param>
        /// <returns></returns>
        public int SelectMaxMedOrdersSubNoFromHis(string medPatientId, decimal medVisitId, string HisOrderSubNo)
        {
            OracleParameter[] MedVsHisOrdersParams = GetParameter("SelectMaxMedVsHisOrdersOrderSubNoFromHis");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = HisOrderSubNo;

            object count = OracleHelper.ExecuteScalar(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERSSubNo_FromHis_Select_Top, MedVsHisOrdersParams);
            if (count == null || count == DBNull.Value)
                count = (object)0;
            return Convert.ToInt32(count);

        }
		
	}
}
