

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
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedVsHisOrders 
		///Insert Table MED_VS_HIS_ORDERS
		/// </summary>
        public int InsertMedVsHisOrdersSQL(MedVsHisOrders model, System.Data.Common.DbTransaction oleCisTrans)
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

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_VS_HIS_ORDERS_Insert_SQL, oneInert);

		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedVsHisOrders 
		///Update Table     MED_VS_HIS_ORDERS
		/// </summary>
        public int UpdateMedVsHisOrdersSQL(MedVsHisOrders model, System.Data.Common.DbTransaction oleCisTrans)
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

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_VS_HIS_ORDERS_Update_SQL, oneUpdate);

		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedVsHisOrders 
		///Delete Table MED_VS_HIS_ORDERS by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_ORDER_NO,decimal MED_ORDER_SUB_NO,decimal MED_REPEAT_INDICATOR)
		/// </summary>
        public int DeleteMedVsHisOrdersSQL(string MED_PATIENT_ID, decimal MED_VISIT_ID, string MED_ORDER_NO, decimal MED_ORDER_SUB_NO, decimal MED_REPEAT_INDICATOR, System.Data.Common.DbTransaction oleCisTrans)
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

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_VS_HIS_ORDERS_Delete_SQL, oneDelete);

		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedVsHisOrders 
		///select Table MED_VS_HIS_ORDERS by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_ORDER_NO,decimal MED_ORDER_SUB_NO,decimal MED_REPEAT_INDICATOR)
		/// </summary>
        public MedVsHisOrders SelectMedVsHisOrdersSQL(string MED_PATIENT_ID, decimal MED_VISIT_ID, string MED_ORDER_NO, decimal MED_ORDER_SUB_NO, decimal MED_REPEAT_INDICATOR, System.Data.Common.DbConnection oleCisConn)
		{
			MedVsHisOrders model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedVsHisOrders");
			parameterValues[0].Value=MED_PATIENT_ID;
			parameterValues[1].Value=MED_VISIT_ID;
			parameterValues[2].Value=MED_ORDER_NO;
			parameterValues[3].Value=MED_ORDER_SUB_NO;
			parameterValues[4].Value=MED_REPEAT_INDICATOR;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_VS_HIS_ORDERS_Select_SQL, parameterValues))
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
        public List<MedVsHisOrders> SelectMedVsHisOrdersListSQL(System.Data.Common.DbConnection oleCisConn)
		{
			List<MedVsHisOrders> modelList = new List<MedVsHisOrders>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_VS_HIS_ORDERS_Select_ALL_SQL, null))
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
        public Model.MedVsHisOrders SelectMedVsHisOrdersHisSQL(string hisOrderNo, string hisOrderSubNo, DateTime createDate, System.Data.Common.DbConnection oleCisConn)
        {
            Model.MedVsHisOrders oneMedVsHisOrders = null;
            SqlParameter[] MedVsHisOrdersParams = GetParameterSQL("SelectMedVsHisOrdersHis");
            MedVsHisOrdersParams[0].Value = hisOrderNo;
            MedVsHisOrdersParams[1].Value = hisOrderSubNo;
            MedVsHisOrdersParams[2].Value = createDate;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_VS_HIS_ORDERS_His_Select_SQL, MedVsHisOrdersParams))
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
        public Model.MedVsHisOrders SelectMedVsHisOrdersHisSQL(string medPatientId, decimal medVisitId, string hisOrderNo, string hisOrderSubNo, DateTime createDate, System.Data.Common.DbConnection oleCisConn)
        {
            Model.MedVsHisOrders oneMedVsHisOrders = null;
            SqlParameter[] MedVsHisOrdersParams = GetParameterSQL("SelectMedVsHisOrdersHisOnly");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = hisOrderNo;
            MedVsHisOrdersParams[3].Value = hisOrderSubNo;
            MedVsHisOrdersParams[4].Value = createDate;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_VS_HIS_ORDERS_His_Only_Select_SQL, MedVsHisOrdersParams))
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
        public int SelectMaxMedOrdersSQL(System.Data.Common.DbTransaction oleCisTrans)
        {
            object count = SqlHelper.ExecuteScalar((SqlTransaction)oleCisTrans, CommandType.Text, MED_ORDERSNO_Select_Top_SQL, null);
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
        public int SelectMaxMedOrdersSubNoSQL(string medPatientId, decimal medVisitId, string medOrderNo, System.Data.Common.DbTransaction oleCisTrans)
        {
            SqlParameter[] MedVsHisOrdersParams = GetParameterSQL("SelectMaxMedVsHisOrdersOrderSubNo");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = medOrderNo;

            object count = SqlHelper.ExecuteScalar((SqlTransaction)oleCisTrans, CommandType.Text, MED_VS_HIS_ORDERSSubNo_Select_Top_SQL, MedVsHisOrdersParams);
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
        public int SelectMaxMedOrdersSubNoFromHisSQL(string medPatientId, decimal medVisitId, string HisOrderSubNo, System.Data.Common.DbTransaction oleCisTrans)
        {
            SqlParameter[] MedVsHisOrdersParams = GetParameterSQL("SelectMaxMedVsHisOrdersOrderSubNoFromHis");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = HisOrderSubNo;

            object count = SqlHelper.ExecuteScalar((SqlTransaction)oleCisTrans, CommandType.Text, MED_VS_HIS_ORDERSSubNo_FromHis_Select_Top_SQL, MedVsHisOrdersParams);
            if (count == null || count == DBNull.Value)
                count = (object)0;
            return Convert.ToInt32(count);

        }

		#region [添加一条记录]
		/// <summary>
		///Add    model  MedVsHisOrders 
		///Insert Table MED_VS_HIS_ORDERS
		/// </summary>
        public int InsertMedVsHisOrders(MedVsHisOrders model, System.Data.Common.DbTransaction oleCisTrans)
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

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_VS_HIS_ORDERS_Insert, oneInert);

		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedVsHisOrders 
		///Update Table     MED_VS_HIS_ORDERS
		/// </summary>
        public int UpdateMedVsHisOrders(MedVsHisOrders model, System.Data.Common.DbTransaction oleCisTrans)
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

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_VS_HIS_ORDERS_Update, oneUpdate);

		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedVsHisOrders 
		///Delete Table MED_VS_HIS_ORDERS by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_ORDER_NO,decimal MED_ORDER_SUB_NO,decimal MED_REPEAT_INDICATOR)
		/// </summary>
        public int DeleteMedVsHisOrders(string MED_PATIENT_ID, decimal MED_VISIT_ID, string MED_ORDER_NO, decimal MED_ORDER_SUB_NO, decimal MED_REPEAT_INDICATOR, System.Data.Common.DbTransaction oleCisTrans)
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

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_VS_HIS_ORDERS_Delete, oneDelete);

		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedVsHisOrders 
		///select Table MED_VS_HIS_ORDERS by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_ORDER_NO,decimal MED_ORDER_SUB_NO,decimal MED_REPEAT_INDICATOR)
		/// </summary>
        public MedVsHisOrders SelectMedVsHisOrders(string MED_PATIENT_ID, decimal MED_VISIT_ID, string MED_ORDER_NO, decimal MED_ORDER_SUB_NO, decimal MED_REPEAT_INDICATOR, System.Data.Common.DbConnection oleCisConn)
		{
			MedVsHisOrders model;
			OracleParameter[] parameterValues = GetParameter("SelectMedVsHisOrders");
			parameterValues[0].Value=MED_PATIENT_ID;
			parameterValues[1].Value=MED_VISIT_ID;
			parameterValues[2].Value=MED_ORDER_NO;
			parameterValues[3].Value=MED_ORDER_SUB_NO;
			parameterValues[4].Value=MED_REPEAT_INDICATOR;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_VS_HIS_ORDERS_Select, parameterValues))
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
        public List<MedVsHisOrders> SelectMedVsHisOrdersList(System.Data.Common.DbConnection oleCisConn)
		{
			List<MedVsHisOrders> modelList = new List<MedVsHisOrders>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_VS_HIS_ORDERS_Select_ALL, null))
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
        public Model.MedVsHisOrders SelectMedVsHisOrdersHis(string hisOrderNo, string hisOrderSubNo, DateTime createDate, System.Data.Common.DbConnection oleCisConn)
        {
            Model.MedVsHisOrders oneMedVsHisOrders = null;
            OracleParameter[] MedVsHisOrdersParams = GetParameter("SelectMedVsHisOrdersHis");
            MedVsHisOrdersParams[0].Value = hisOrderNo;
            MedVsHisOrdersParams[1].Value = hisOrderSubNo;
            MedVsHisOrdersParams[2].Value = createDate;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_VS_HIS_ORDERS_His_Select, MedVsHisOrdersParams))
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
        public Model.MedVsHisOrders SelectMedVsHisOrdersHis(string medPatientId, decimal medVisitId, string hisOrderNo, string hisOrderSubNo, DateTime createDate, System.Data.Common.DbConnection oleCisConn)
        {
            Model.MedVsHisOrders oneMedVsHisOrders = null;
            OracleParameter[] MedVsHisOrdersParams = GetParameter("SelectMedVsHisOrdersHisOnly");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = hisOrderNo;
            MedVsHisOrdersParams[3].Value = hisOrderSubNo;
            MedVsHisOrdersParams[4].Value = createDate;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_VS_HIS_ORDERS_His_Only_Select, MedVsHisOrdersParams))
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
        public int SelectMaxMedOrders(System.Data.Common.DbTransaction oleCisTrans)
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
        public int SelectMaxMedOrdersSubNo(string medPatientId, decimal medVisitId, string medOrderNo, System.Data.Common.DbTransaction oleCisTrans)
        {
            OracleParameter[] MedVsHisOrdersParams = GetParameter("SelectMaxMedVsHisOrdersOrderSubNo");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = medOrderNo;

            object count = OracleHelper.ExecuteScalar((OracleTransaction)oleCisTrans, CommandType.Text, MED_VS_HIS_ORDERSSubNo_Select_Top, MedVsHisOrdersParams);
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
        public int SelectMaxMedOrdersSubNoFromHis(string medPatientId, decimal medVisitId, string HisOrderSubNo, System.Data.Common.DbTransaction oleCisTrans)
        {
            OracleParameter[] MedVsHisOrdersParams = GetParameter("SelectMaxMedVsHisOrdersOrderSubNoFromHis");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = HisOrderSubNo;

            object count = OracleHelper.ExecuteScalar((OracleTransaction)oleCisTrans, CommandType.Text, MED_VS_HIS_ORDERSSubNo_FromHis_Select_Top, MedVsHisOrdersParams);
            if (count == null || count == DBNull.Value)
                count = (object)0;
            return Convert.ToInt32(count);

        }
		
	}
}
