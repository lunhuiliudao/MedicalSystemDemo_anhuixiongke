

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
using System.Data.Odbc;
using System.Data.OleDb;

namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedVsHisOrders
    /// </summary>

    public partial class DALMedVsHisOrders
    {

        private static readonly string MED_VS_HIS_ORDERS_Insert_ODBC = "INSERT INTO MED_VS_HIS_ORDERS (MED_PATIENT_ID,MED_VISIT_ID,MED_ORDER_NO,MED_ORDER_SUB_NO,MED_REPEAT_INDICATOR,HIS_ORDER_NO,HIS_ORDER_SUB_NO,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05) values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_VS_HIS_ORDERS_Update_ODBC = "UPDATE MED_VS_HIS_ORDERS SET MED_PATIENT_ID=?,MED_VISIT_ID=?,MED_ORDER_NO=?,MED_ORDER_SUB_NO=?,MED_REPEAT_INDICATOR=?,HIS_ORDER_NO=?,HIS_ORDER_SUB_NO=?,CREATE_DATE=?,RESERVED01=?,RESERVED02=?,RESERVED03=?,RESERVED04=?,RESERVED05=? WHERE MED_PATIENT_ID=? AND MED_VISIT_ID=? AND MED_ORDER_NO=? AND MED_ORDER_SUB_NO=? AND MED_REPEAT_INDICATOR=?";
        private static readonly string MED_VS_HIS_ORDERS_Delete_ODBC = "Delete MED_VS_HIS_ORDERS WHERE MED_PATIENT_ID=? AND MED_VISIT_ID=? AND MED_ORDER_NO=? AND MED_ORDER_SUB_NO=? AND MED_REPEAT_INDICATOR=?";
        private static readonly string MED_VS_HIS_ORDERS_Select_ODBC = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_ORDER_NO,MED_ORDER_SUB_NO,MED_REPEAT_INDICATOR,HIS_ORDER_NO,HIS_ORDER_SUB_NO,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05 FROM MED_VS_HIS_ORDERS where MED_PATIENT_ID=? AND MED_VISIT_ID=? AND MED_ORDER_NO=? AND MED_ORDER_SUB_NO=? AND MED_REPEAT_INDICATOR=?";
        private static readonly string MED_VS_HIS_ORDERS_Select_ALL_ODBC = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_ORDER_NO,MED_ORDER_SUB_NO,MED_REPEAT_INDICATOR,HIS_ORDER_NO,HIS_ORDER_SUB_NO,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05 FROM MED_VS_HIS_ORDERS";
        private static readonly string MED_VS_HIS_ORDERS_His_Select_ODBC = "select med_patient_id, med_visit_id, med_order_no, med_order_sub_no, med_repeat_indicator, his_order_no, his_order_sub_no, create_date, reserved01, reserved02, reserved03, reserved04, reserved05 from med_vs_his_orders where his_order_no = ? and his_order_sub_no = ? and create_date = ? ";
        private static readonly string MED_VS_HIS_ORDERS_His_Only_Select_ODBC = "select med_patient_id, med_visit_id, med_order_no, med_order_sub_no, med_repeat_indicator, his_order_no, his_order_sub_no, create_date, reserved01, reserved02, reserved03, reserved04, reserved05 from med_vs_his_orders where med_patient_id = ? and med_visit_id = ? and his_order_no = ? and his_order_sub_no = ? and create_date = ? ";
        private static readonly string MED_VS_HIS_ORDERSSubNo_Select_Top_ODBC = "select Max(med_order_sub_no) from med_vs_his_orders where med_patient_id = ? and med_visit_id = ? and med_order_no = ? ";
        private static readonly string MED_VS_HIS_ORDERSSubNo_FromHis_Select_Top_ODBC = "select Max(med_order_sub_no) from med_vs_his_orders where med_patient_id = ? and med_visit_id = ? and his_order_sub_no = ? ";
        private static readonly string MED_ORDERSNO_Select_Top_ODBC = "select Max(order_no) from med_orders";

        private static readonly string MED_VS_HIS_ORDERS_Insert_OLE = "INSERT INTO MED_VS_HIS_ORDERS (MED_PATIENT_ID,MED_VISIT_ID,MED_ORDER_NO,MED_ORDER_SUB_NO,MED_REPEAT_INDICATOR,HIS_ORDER_NO,HIS_ORDER_SUB_NO,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05) values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_VS_HIS_ORDERS_Update_OLE = "UPDATE MED_VS_HIS_ORDERS SET MED_PATIENT_ID=?,MED_VISIT_ID=?,MED_ORDER_NO=?,MED_ORDER_SUB_NO=?,MED_REPEAT_INDICATOR=?,HIS_ORDER_NO=?,HIS_ORDER_SUB_NO=?,CREATE_DATE=?,RESERVED01=?,RESERVED02=?,RESERVED03=?,RESERVED04=?,RESERVED05=? WHERE MED_PATIENT_ID=? AND MED_VISIT_ID=? AND MED_ORDER_NO=? AND MED_ORDER_SUB_NO=? AND MED_REPEAT_INDICATOR=?";
        private static readonly string MED_VS_HIS_ORDERS_Delete_OLE = "Delete MED_VS_HIS_ORDERS WHERE MED_PATIENT_ID=? AND MED_VISIT_ID=? AND MED_ORDER_NO=? AND MED_ORDER_SUB_NO=? AND MED_REPEAT_INDICATOR=?";
        private static readonly string MED_VS_HIS_ORDERS_Select_OLE = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_ORDER_NO,MED_ORDER_SUB_NO,MED_REPEAT_INDICATOR,HIS_ORDER_NO,HIS_ORDER_SUB_NO,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05 FROM MED_VS_HIS_ORDERS where MED_PATIENT_ID=? AND MED_VISIT_ID=? AND MED_ORDER_NO=? AND MED_ORDER_SUB_NO=? AND MED_REPEAT_INDICATOR=?";
        private static readonly string MED_VS_HIS_ORDERS_Select_ALL_OLE = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_ORDER_NO,MED_ORDER_SUB_NO,MED_REPEAT_INDICATOR,HIS_ORDER_NO,HIS_ORDER_SUB_NO,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05 FROM MED_VS_HIS_ORDERS";
        private static readonly string MED_VS_HIS_ORDERS_His_Select_OLE = "select med_patient_id, med_visit_id, med_order_no, med_order_sub_no, med_repeat_indicator, his_order_no, his_order_sub_no, create_date, reserved01, reserved02, reserved03, reserved04, reserved05 from med_vs_his_orders where his_order_no = ? and his_order_sub_no = ? and create_date = ? ";
        private static readonly string MED_VS_HIS_ORDERS_His_Only_Select_OLE = "select med_patient_id, med_visit_id, med_order_no, med_order_sub_no, med_repeat_indicator, his_order_no, his_order_sub_no, create_date, reserved01, reserved02, reserved03, reserved04, reserved05 from med_vs_his_orders where med_patient_id = ? and med_visit_id = ? and his_order_no = ? and his_order_sub_no = ? and create_date = ? ";
        private static readonly string MED_VS_HIS_ORDERSSubNo_Select_Top_OLE = "select Max(med_order_sub_no) from med_vs_his_orders where med_patient_id = ? and med_visit_id = ? and med_order_no = ? ";
        private static readonly string MED_VS_HIS_ORDERSSubNo_FromHis_Select_Top_OLE = "select Max(med_order_sub_no) from med_vs_his_orders where med_patient_id = ? and med_visit_id = ? and his_order_sub_no = ? ";
        private static readonly string MED_ORDERSNO_Select_Top_OLE = "select Max(order_no) from med_orders";

        //public DALMedVsHisOrders()
        //{
        //}
        #region [获取参数ODBC]
        /// <summary>
        ///获取参数MedVsHisOrders ODBC
        /// </summary>
        public static OdbcParameter[] GetParameterODBC(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOrders")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("MedPatientId",OdbcType.VarChar),
						new OdbcParameter("MedVisitId",OdbcType.Decimal),
						new OdbcParameter("MedOrderNo",OdbcType.VarChar),
						new OdbcParameter("MedOrderSubNo",OdbcType.Decimal),
						new OdbcParameter("MedRepeatIndicator",OdbcType.Decimal),
						new OdbcParameter("HisOrderNo",OdbcType.VarChar),
						new OdbcParameter("HisOrderSubNo",OdbcType.VarChar),
						new OdbcParameter("CreateDate",OdbcType.DateTime),
						new OdbcParameter("Reserved01",OdbcType.VarChar),
						new OdbcParameter("Reserved02",OdbcType.VarChar),
						new OdbcParameter("Reserved03",OdbcType.VarChar),
						new OdbcParameter("Reserved04",OdbcType.VarChar),
						new OdbcParameter("Reserved05",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedVsHisOrders")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("MedPatientId",OdbcType.VarChar),
						new OdbcParameter("MedVisitId",OdbcType.Decimal),
						new OdbcParameter("MedOrderNo",OdbcType.VarChar),
						new OdbcParameter("MedOrderSubNo",OdbcType.Decimal),
						new OdbcParameter("MedRepeatIndicator",OdbcType.Decimal),
						new OdbcParameter("HisOrderNo",OdbcType.VarChar),
						new OdbcParameter("HisOrderSubNo",OdbcType.VarChar),
						new OdbcParameter("CreateDate",OdbcType.DateTime),
						new OdbcParameter("Reserved01",OdbcType.VarChar),
						new OdbcParameter("Reserved02",OdbcType.VarChar),
						new OdbcParameter("Reserved03",OdbcType.VarChar),
						new OdbcParameter("Reserved04",OdbcType.VarChar),
						new OdbcParameter("Reserved05",OdbcType.VarChar),
                        new OdbcParameter("MedPatientIdP",OdbcType.VarChar),
                        new OdbcParameter("MedVisitIdP",OdbcType.Decimal),
                        new OdbcParameter("MedOrderNoP",OdbcType.Decimal),
                        new OdbcParameter("MedOrderSubNoP",OdbcType.Decimal),
                        new OdbcParameter("MedRepeatIndicatorP",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedVsHisOrders")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("MedPatientId",OdbcType.VarChar),
						new OdbcParameter("MedVisitId",OdbcType.Decimal),
						new OdbcParameter("MedOrderNo",OdbcType.VarChar),
						new OdbcParameter("MedOrderSubNo",OdbcType.Decimal),
						new OdbcParameter("MedRepeatIndicator",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOrders")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("MedPatientId",OdbcType.VarChar),
						new OdbcParameter("MedVisitId",OdbcType.Decimal),
						new OdbcParameter("MedOrderNo",OdbcType.VarChar),
						new OdbcParameter("MedOrderSubNo",OdbcType.Decimal),
						new OdbcParameter("MedRepeatIndicator",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOrdersHis")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("HisOrderNo",OdbcType.VarChar),
						new OdbcParameter("HisOrderSubNo",OdbcType.VarChar),
						new OdbcParameter("CreateDate",OdbcType.DateTime),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOrdersHisOnly")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("MedPatientId",OdbcType.VarChar),
					    new OdbcParameter("MedVisitId",OdbcType.Decimal),
						new OdbcParameter("HisOrderNo",OdbcType.VarChar),
						new OdbcParameter("HisOrderSubNo",OdbcType.VarChar),
						new OdbcParameter("CreateDate",OdbcType.DateTime),
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisOrdersOrderSubNo")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("MedPatientId",OdbcType.VarChar),
						new OdbcParameter("MedVisitId",OdbcType.Decimal),
						new OdbcParameter("MedOrderNo",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisOrdersOrderSubNoFromHis")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("MedPatientId",OdbcType.VarChar),
						new OdbcParameter("MedVisitId",OdbcType.Decimal),
                        new OdbcParameter("HisOrderNo",OdbcType.VarChar),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedVsHisOrders 
        ///Insert Table MED_VS_HIS_ORDERS
        /// </summary>
        public int InsertMedVsHisOrdersODBC(MedVsHisOrders model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterODBC("InsertMedVsHisOrders");
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

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_Insert_ODBC, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedVsHisOrders 
        ///Update Table     MED_VS_HIS_ORDERS
        /// </summary>
        public int UpdateMedVsHisOrdersODBC(MedVsHisOrders model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterODBC("UpdateMedVsHisOrders");
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

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_Update_ODBC, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedVsHisOrders 
        ///Delete Table MED_VS_HIS_ORDERS by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_ORDER_NO,decimal MED_ORDER_SUB_NO,decimal MED_REPEAT_INDICATOR)
        /// </summary>
        public int DeleteMedVsHisOrdersODBC(string MED_PATIENT_ID, decimal MED_VISIT_ID, string MED_ORDER_NO, decimal MED_ORDER_SUB_NO, decimal MED_REPEAT_INDICATOR)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterODBC("DeleteMedVsHisOrders");
                if (MED_PATIENT_ID != null)
                    oneDelete[0].Value = MED_PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (MED_VISIT_ID.ToString() != null)
                    oneDelete[1].Value = MED_VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (MED_ORDER_NO.ToString() != null)
                    oneDelete[2].Value = MED_ORDER_NO;
                else
                    oneDelete[2].Value = DBNull.Value;
                if (MED_ORDER_SUB_NO.ToString() != null)
                    oneDelete[3].Value = MED_ORDER_SUB_NO;
                else
                    oneDelete[3].Value = DBNull.Value;
                if (MED_REPEAT_INDICATOR.ToString() != null)
                    oneDelete[4].Value = MED_REPEAT_INDICATOR;
                else
                    oneDelete[4].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_Delete_ODBC, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedVsHisOrders 
        ///select Table MED_VS_HIS_ORDERS by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_ORDER_NO,decimal MED_ORDER_SUB_NO,decimal MED_REPEAT_INDICATOR)
        /// </summary>
        public MedVsHisOrders SelectMedVsHisOrdersODBC(string MED_PATIENT_ID, decimal MED_VISIT_ID, string MED_ORDER_NO, decimal MED_ORDER_SUB_NO, decimal MED_REPEAT_INDICATOR)
        {
            MedVsHisOrders model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedVsHisOrders");
            parameterValues[0].Value = MED_PATIENT_ID;
            parameterValues[1].Value = MED_VISIT_ID;
            parameterValues[2].Value = MED_ORDER_NO;
            parameterValues[3].Value = MED_ORDER_SUB_NO;
            parameterValues[4].Value = MED_REPEAT_INDICATOR;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_Select_ODBC, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisOrders();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.MedPatientId = oleReader["MED_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.MedVisitId = decimal.Parse(oleReader["MED_VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.MedOrderNo = oleReader["MED_ORDER_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MedOrderSubNo = decimal.Parse(oleReader["MED_ORDER_SUB_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.MedRepeatIndicator = decimal.Parse(oleReader["MED_REPEAT_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.HisOrderNo = oleReader["HIS_ORDER_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.HisOrderSubNo = oleReader["HIS_ORDER_SUB_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
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
        public List<MedVsHisOrders> SelectMedVsHisOrdersListODBC()
        {
            List<MedVsHisOrders> modelList = new List<MedVsHisOrders>();
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_Select_ALL_ODBC, null))
            {
                while (oleReader.Read())
                {
                    MedVsHisOrders model = new MedVsHisOrders();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.MedPatientId = oleReader["MED_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.MedVisitId = decimal.Parse(oleReader["MED_VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.MedOrderNo = oleReader["MED_ORDER_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MedOrderSubNo = decimal.Parse(oleReader["MED_ORDER_SUB_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.MedRepeatIndicator = decimal.Parse(oleReader["MED_REPEAT_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.HisOrderNo = oleReader["HIS_ORDER_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.HisOrderSubNo = oleReader["HIS_ORDER_SUB_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
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
        public Model.MedVsHisOrders SelectMedVsHisOrdersHisODBC(string hisOrderNo, string hisOrderSubNo, DateTime createDate)
        {
            Model.MedVsHisOrders oneMedVsHisOrders = null;
            OdbcParameter[] MedVsHisOrdersParams = GetParameterODBC("SelectMedVsHisOrdersHis");
            MedVsHisOrdersParams[0].Value = hisOrderNo;
            MedVsHisOrdersParams[1].Value = hisOrderSubNo;
            MedVsHisOrdersParams[2].Value = createDate;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_His_Select_ODBC, MedVsHisOrdersParams))
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
        public Model.MedVsHisOrders SelectMedVsHisOrdersHisODBC(string medPatientId, decimal medVisitId, string hisOrderNo, string hisOrderSubNo, DateTime createDate)
        {
            Model.MedVsHisOrders oneMedVsHisOrders = null;
            OdbcParameter[] MedVsHisOrdersParams = GetParameterODBC("SelectMedVsHisOrdersHisOnly");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = hisOrderNo;
            MedVsHisOrdersParams[3].Value = hisOrderSubNo;
            MedVsHisOrdersParams[4].Value = createDate;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_His_Only_Select_ODBC, MedVsHisOrdersParams))
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
        public int SelectMaxMedOrdersODBC()
        {
            object count = OdbcHelper.ExecuteScalar(OdbcHelper.ConnectionString, CommandType.Text, MED_ORDERSNO_Select_Top_SQL, null);
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
        public int SelectMaxMedOrdersSubNoODBC(string medPatientId, decimal medVisitId, string medOrderNo)
        {
            OdbcParameter[] MedVsHisOrdersParams = GetParameterODBC("SelectMaxMedVsHisOrdersOrderSubNo");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = medOrderNo;

            object count = OdbcHelper.ExecuteScalar(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERSSubNo_Select_Top_ODBC, MedVsHisOrdersParams);
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
        public int SelectMaxMedOrdersSubNoFromHisODBC(string medPatientId, decimal medVisitId, string HisOrderSubNo)
        {
            OdbcParameter[] MedVsHisOrdersParams = GetParameterODBC("SelectMaxMedVsHisOrdersOrderSubNoFromHis");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = HisOrderSubNo;

            object count = OdbcHelper.ExecuteScalar(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERSSubNo_FromHis_Select_Top_ODBC, MedVsHisOrdersParams);
            if (count == null || count == DBNull.Value)
                count = (object)0;
            return Convert.ToInt32(count);

        }

        #region [获取参数]
        /// <summary>
        ///获取参数MedVsHisOrders
        /// </summary>
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOrders")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("MedPatientId",OleDbType.VarChar),
						new OleDbParameter("MedVisitId",OleDbType.Decimal),
						new OleDbParameter("MedOrderNo",OleDbType.VarChar),
						new OleDbParameter("MedOrderSubNo",OleDbType.Decimal),
						new OleDbParameter("MedRepeatIndicator",OleDbType.Decimal),
						new OleDbParameter("HisOrderNo",OleDbType.VarChar),
						new OleDbParameter("HisOrderSubNo",OleDbType.VarChar),
						new OleDbParameter("CreateDate",OleDbType.DBTimeStamp),
						new OleDbParameter("Reserved01",OleDbType.VarChar),
						new OleDbParameter("Reserved02",OleDbType.VarChar),
						new OleDbParameter("Reserved03",OleDbType.VarChar),
						new OleDbParameter("Reserved04",OleDbType.VarChar),
						new OleDbParameter("Reserved05",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedVsHisOrders")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("MedPatientId",OleDbType.VarChar),
						new OleDbParameter("MedVisitId",OleDbType.Decimal),
						new OleDbParameter("MedOrderNo",OleDbType.VarChar),
						new OleDbParameter("MedOrderSubNo",OleDbType.Decimal),
						new OleDbParameter("MedRepeatIndicator",OleDbType.Decimal),
						new OleDbParameter("HisOrderNo",OleDbType.VarChar),
						new OleDbParameter("HisOrderSubNo",OleDbType.VarChar),
						new OleDbParameter("CreateDate",OleDbType.DBTimeStamp),
						new OleDbParameter("Reserved01",OleDbType.VarChar),
						new OleDbParameter("Reserved02",OleDbType.VarChar),
						new OleDbParameter("Reserved03",OleDbType.VarChar),
						new OleDbParameter("Reserved04",OleDbType.VarChar),
						new OleDbParameter("Reserved05",OleDbType.VarChar),
						new OleDbParameter("MedPatientId",OdbcType.VarChar),
						new OleDbParameter("MedVisitId",OdbcType.Decimal),
						new OleDbParameter("MedOrderNo",OdbcType.Decimal),
						new OleDbParameter("MedOrderSubNo",OdbcType.Decimal),
						new OleDbParameter("MedRepeatIndicator",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedVsHisOrders")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("MedPatientId",OleDbType.VarChar),
						new OleDbParameter("MedVisitId",OleDbType.Decimal),
						new OleDbParameter("MedOrderNo",OleDbType.VarChar),
						new OleDbParameter("MedOrderSubNo",OleDbType.Decimal),
						new OleDbParameter("MedRepeatIndicator",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOrders")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("MedPatientId",OleDbType.VarChar),
						new OleDbParameter("MedVisitId",OleDbType.Decimal),
						new OleDbParameter("MedOrderNo",OleDbType.VarChar),
						new OleDbParameter("MedOrderSubNo",OleDbType.Decimal),
						new OleDbParameter("MedRepeatIndicator",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOrdersHis")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("HisOrderNo",OleDbType.VarChar),
						new OleDbParameter("HisOrderSubNo",OleDbType.VarChar),
						new OleDbParameter("CreateDate",OleDbType.DBTimeStamp),
                    };
                }
                else if (sqlParms == "SelectMedVsHisOrdersHisOnly")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("MedPatientId",OleDbType.VarChar),
						new OleDbParameter("MedVisitId",OleDbType.Decimal),
						new OleDbParameter("HisOrderNo",OleDbType.VarChar),
						new OleDbParameter("HisOrderSubNo",OleDbType.VarChar),
						new OleDbParameter("CreateDate",OleDbType.DBTimeStamp),
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisOrdersOrderSubNo")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("MedPatientId",OleDbType.VarChar),
						new OleDbParameter("MedVisitId",OleDbType.Decimal),
						new OleDbParameter("MedOrderNo",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisOrdersOrderSubNoFromHis")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("MedPatientId",OleDbType.VarChar),
						new OleDbParameter("MedVisitId",OleDbType.Decimal),
                        new OleDbParameter("HisOrderSubNo",OleDbType.VarChar),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedVsHisOrders 
        ///Insert Table MED_VS_HIS_ORDERS
        /// </summary>
        public int InsertMedVsHisOrdersOLE(MedVsHisOrders model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedVsHisOrders");
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

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_Insert_OLE, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedVsHisOrders 
        ///Update Table     MED_VS_HIS_ORDERS
        /// </summary>
        public int UpdateMedVsHisOrdersOLE(MedVsHisOrders model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedVsHisOrders");
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

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_Update_OLE, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedVsHisOrders 
        ///Delete Table MED_VS_HIS_ORDERS by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_ORDER_NO,decimal MED_ORDER_SUB_NO,decimal MED_REPEAT_INDICATOR)
        /// </summary>
        public int DeleteMedVsHisOrdersOLE(string MED_PATIENT_ID, decimal MED_VISIT_ID, string MED_ORDER_NO, decimal MED_ORDER_SUB_NO, decimal MED_REPEAT_INDICATOR)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedVsHisOrders");
                if (MED_PATIENT_ID != null)
                    oneDelete[0].Value = MED_PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (MED_VISIT_ID.ToString() != null)
                    oneDelete[1].Value = MED_VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (MED_ORDER_NO.ToString() != null)
                    oneDelete[2].Value = MED_ORDER_NO;
                else
                    oneDelete[2].Value = DBNull.Value;
                if (MED_ORDER_SUB_NO.ToString() != null)
                    oneDelete[3].Value = MED_ORDER_SUB_NO;
                else
                    oneDelete[3].Value = DBNull.Value;
                if (MED_REPEAT_INDICATOR.ToString() != null)
                    oneDelete[4].Value = MED_REPEAT_INDICATOR;
                else
                    oneDelete[4].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_Delete_OLE, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedVsHisOrders 
        ///select Table MED_VS_HIS_ORDERS by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_ORDER_NO,decimal MED_ORDER_SUB_NO,decimal MED_REPEAT_INDICATOR)
        /// </summary>
        public MedVsHisOrders SelectMedVsHisOrdersOLE(string MED_PATIENT_ID, decimal MED_VISIT_ID, string MED_ORDER_NO, decimal MED_ORDER_SUB_NO, decimal MED_REPEAT_INDICATOR)
        {
            MedVsHisOrders model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedVsHisOrders");
            parameterValues[0].Value = MED_PATIENT_ID;
            parameterValues[1].Value = MED_VISIT_ID;
            parameterValues[2].Value = MED_ORDER_NO;
            parameterValues[3].Value = MED_ORDER_SUB_NO;
            parameterValues[4].Value = MED_REPEAT_INDICATOR;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_Select_OLE, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisOrders();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.MedPatientId = oleReader["MED_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.MedVisitId = decimal.Parse(oleReader["MED_VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.MedOrderNo = oleReader["MED_ORDER_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MedOrderSubNo = decimal.Parse(oleReader["MED_ORDER_SUB_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.MedRepeatIndicator = decimal.Parse(oleReader["MED_REPEAT_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.HisOrderNo = oleReader["HIS_ORDER_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.HisOrderSubNo = oleReader["HIS_ORDER_SUB_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
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
        public List<MedVsHisOrders> SelectMedVsHisOrdersListOLE()
        {
            List<MedVsHisOrders> modelList = new List<MedVsHisOrders>();
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_Select_ALL_OLE, null))
            {
                while (oleReader.Read())
                {
                    MedVsHisOrders model = new MedVsHisOrders();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.MedPatientId = oleReader["MED_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.MedVisitId = decimal.Parse(oleReader["MED_VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.MedOrderNo = oleReader["MED_ORDER_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.MedOrderSubNo = decimal.Parse(oleReader["MED_ORDER_SUB_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.MedRepeatIndicator = decimal.Parse(oleReader["MED_REPEAT_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.HisOrderNo = oleReader["HIS_ORDER_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.HisOrderSubNo = oleReader["HIS_ORDER_SUB_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
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
        public Model.MedVsHisOrders SelectMedVsHisOrdersHisOLE(string hisOrderNo, string hisOrderSubNo, DateTime createDate)
        {
            Model.MedVsHisOrders oneMedVsHisOrders = null;
            OleDbParameter[] MedVsHisOrdersParams = GetParameterOLE("SelectMedVsHisOrdersHis");
            MedVsHisOrdersParams[0].Value = hisOrderNo;
            MedVsHisOrdersParams[1].Value = hisOrderSubNo;
            MedVsHisOrdersParams[2].Value = createDate;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_His_Select_OLE, MedVsHisOrdersParams))
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
        public Model.MedVsHisOrders SelectMedVsHisOrdersHisOLE(string medPatientId, decimal medVisitId, string hisOrderNo, string hisOrderSubNo, DateTime createDate)
        {
            Model.MedVsHisOrders oneMedVsHisOrders = null;
            OleDbParameter[] MedVsHisOrdersParams = GetParameterOLE("SelectMedVsHisOrdersHisOnly");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = hisOrderNo;
            MedVsHisOrdersParams[3].Value = hisOrderSubNo;
            MedVsHisOrdersParams[4].Value = createDate;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERS_His_Only_Select_OLE, MedVsHisOrdersParams))
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
        public int SelectMaxMedOrdersOLE()
        {
            object count = OleDbHelper.ExecuteScalar(OleDbHelper.ConnectionString, CommandType.Text, MED_ORDERSNO_Select_Top_OLE, null);
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
        public int SelectMaxMedOrdersSubNoOLE(string medPatientId, decimal medVisitId, string medOrderNo)
        {
            OleDbParameter[] MedVsHisOrdersParams = GetParameterOLE("SelectMaxMedVsHisOrdersOrderSubNo");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = medOrderNo;

            object count = OleDbHelper.ExecuteScalar(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERSSubNo_Select_Top_OLE, MedVsHisOrdersParams);
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
        public int SelectMaxMedOrdersSubNoFromHisOLE(string medPatientId, decimal medVisitId, string HisOrderSubNo)
        {
            OleDbParameter[] MedVsHisOrdersParams = GetParameterOLE("SelectMaxMedVsHisOrdersOrderSubNoFromHis");
            MedVsHisOrdersParams[0].Value = medPatientId;
            MedVsHisOrdersParams[1].Value = medVisitId;
            MedVsHisOrdersParams[2].Value = HisOrderSubNo;

            object count = OleDbHelper.ExecuteScalar(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_ORDERSSubNo_FromHis_Select_Top_OLE, MedVsHisOrdersParams);
            if (count == null || count == DBNull.Value)
                count = (object)0;
            return Convert.ToInt32(count);

        }

    }
}
