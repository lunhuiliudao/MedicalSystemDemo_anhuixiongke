

/*********************************************************************
 * Author:    酒小龙
 * Date:      2011/9/23 12:06:12
 * 
 * Notes:
 * 
* ******************************************************************/

using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
//using System.Data.SqlClient;
//using System.Data.OracleClient;
using MedicalSytem.Soft.Model;
using System.Data.OleDb;
using System.Data.Odbc;

namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedOperationBillItems
    /// </summary>

    public partial class DALMedOperationBillItems
    {

        private static readonly string MED_OPERATION_BILL_ITEMS_Insert_ODBC = "INSERT INTO MED_OPERATION_BILL_ITEMS (PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,ORDERED_BY,PERFORMED_BY,COSTS,CHARGES,NOTES,VERIFIED_INDICATOR,ENTERED_BY,CLASS_ON_RECKONING,INPBILL_ITEM_NO,EVENT_ITEM_NO,EXCHANGE_INDICATOR,STORAGE_INDICATOR,BILL_ATTR,SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_OPERATION_BILL_ITEMS_Update_ODBC = "UPDATE MED_OPERATION_BILL_ITEMS SET PATIENT_ID=?,VISIT_ID=?,OPER_ID=?,ITEM_NO=?,ITEM_CLASS=?,ITEM_NAME=?,ITEM_CODE=?,ITEM_SPEC=?,AMOUNT=?,UNITS=?,ORDERED_BY=?,PERFORMED_BY=?,COSTS=?,CHARGES=?,NOTES=?,VERIFIED_INDICATOR=?,ENTERED_BY=?,CLASS_ON_RECKONING=?,INPBILL_ITEM_NO=?,EVENT_ITEM_NO=?,EXCHANGE_INDICATOR=?,STORAGE_INDICATOR=?,BILL_ATTR=?,SUPPLIER_NAME=?,BILL_DATE=?,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR WHERE PATIENT_ID=? AND VISIT_ID=? AND OPER_ID=? AND ITEM_NO=?";
        private static readonly string MED_OPERATION_BILL_ITEMS_Delete_ODBC = "Delete MED_OPERATION_BILL_ITEMS WHERE PATIENT_ID=? AND VISIT_ID=? AND OPER_ID=? AND ITEM_NO=?";
        
        private static readonly string MED_OPERATION_BILL_ITEMS_Select_ODBC = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,ORDERED_BY,PERFORMED_BY,COSTS,CHARGES,NOTES,VERIFIED_INDICATOR,ENTERED_BY,CLASS_ON_RECKONING,INPBILL_ITEM_NO,EVENT_ITEM_NO,EXCHANGE_INDICATOR,STORAGE_INDICATOR,BILL_ATTR,SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR FROM MED_OPERATION_BILL_ITEMS where PATIENT_ID=? AND VISIT_ID=? AND OPER_ID=? and BILL_ATTR= ? and EXCHANGE_INDICATOR  =2 and amount <>0";// AND ITEM_NO=?";麻醉5.0利用bill_attr来区分是 手术(护士)收费和麻醉收费 EXCHANGE_INDICATOR = 0-是暂存 1-收费确认 2-待收费

        private static readonly string MED_OPERATION_BILL_ITEMS_Select_ONE_ODBC = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,ORDERED_BY,PERFORMED_BY,COSTS,CHARGES,NOTES,VERIFIED_INDICATOR,ENTERED_BY,CLASS_ON_RECKONING,INPBILL_ITEM_NO,EVENT_ITEM_NO,EXCHANGE_INDICATOR,STORAGE_INDICATOR,BILL_ATTR,SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR FROM MED_OPERATION_BILL_ITEMS where PATIENT_ID=? AND VISIT_ID=? AND OPER_ID=? and ITEM_NO= ? ";// AND ITEM_NO=?";麻醉5.0利用bill_attr来区分是 手术(护士)收费和麻醉收费 EXCHANGE_INDICATOR = 0-是暂存 1-收费确认 2-待收费
        

        private static readonly string MED_OPERATION_BILL_ITEMS_Select_ALL_ODBC = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,ORDERED_BY,PERFORMED_BY,COSTS,CHARGES,NOTES,VERIFIED_INDICATOR,ENTERED_BY,CLASS_ON_RECKONING,INPBILL_ITEM_NO,EVENT_ITEM_NO,EXCHANGE_INDICATOR,STORAGE_INDICATOR,BILL_ATTR,SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR, ORDERED_DOCTOR,PERFORMED_DOCTOR FROM MED_OPERATION_BILL_ITEMS";
        private static readonly string MED_OPERATION_BILL_ITEMS_Select_No_ODBC = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE, ITEM_SPEC, AMOUNT, UNITS, ORDERED_BY, PERFORMED_BY, COSTS, CHARGES, NOTES, VERIFIED_INDICATOR, ENTERED_BY, CLASS_ON_RECKONING, INPBILL_ITEM_NO, EVENT_ITEM_NO, EXCHANGE_INDICATOR, STORAGE_INDICATOR, BILL_ATTR, SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR from MED_OPERATION_BILL_ITEMS where PATIENT_ID = ? and  VISIT_ID = ? and OPER_ID = ? and item_class = ? and  item_code = ? and item_spec = ? and units = ?  ";

        private static readonly string MED_OPERATION_BILL_ITEMS_Insert_OLE = "INSERT INTO MED_OPERATION_BILL_ITEMS (PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,ORDERED_BY,PERFORMED_BY,COSTS,CHARGES,NOTES,VERIFIED_INDICATOR,ENTERED_BY,CLASS_ON_RECKONING,INPBILL_ITEM_NO,EVENT_ITEM_NO,EXCHANGE_INDICATOR,STORAGE_INDICATOR,BILL_ATTR,SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_OPERATION_BILL_ITEMS_Update_OLE = "UPDATE MED_OPERATION_BILL_ITEMS SET PATIENT_ID=?,VISIT_ID=?,OPER_ID=?,ITEM_NO=?,ITEM_CLASS=?,ITEM_NAME=?,ITEM_CODE=?,ITEM_SPEC=?,AMOUNT=?,UNITS=?,ORDERED_BY=?,PERFORMED_BY=?,COSTS=?,CHARGES=?,NOTES=?,VERIFIED_INDICATOR=?,ENTERED_BY=?,CLASS_ON_RECKONING=?,INPBILL_ITEM_NO=?,EVENT_ITEM_NO=?,EXCHANGE_INDICATOR=?,STORAGE_INDICATOR=?,BILL_ATTR=?,SUPPLIER_NAME=?,BILL_DATE=?,PRICE=?,OPERATOR=?,CLASS_ON_INP_RCPT=?,SUBJ_CODE=?,CLASS_ON_MR=? WHERE PATIENT_ID=? AND VISIT_ID=? AND OPER_ID=? AND ITEM_NO=?";
        private static readonly string MED_OPERATION_BILL_ITEMS_Delete_OLE = "Delete MED_OPERATION_BILL_ITEMS WHERE PATIENT_ID=? AND VISIT_ID=? AND OPER_ID=? AND ITEM_NO=?";
      
        private static readonly string MED_OPERATION_BILL_ITEMS_Select_OLE = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,ORDERED_BY,PERFORMED_BY,COSTS,CHARGES,NOTES,VERIFIED_INDICATOR,ENTERED_BY,CLASS_ON_RECKONING,INPBILL_ITEM_NO,EVENT_ITEM_NO,EXCHANGE_INDICATOR,STORAGE_INDICATOR,BILL_ATTR,SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR FROM MED_OPERATION_BILL_ITEMS where PATIENT_ID=? AND VISIT_ID=? AND OPER_ID=? and BILL_ATTR= ? and EXCHANGE_INDICATOR  =2 and amount <>0";// AND ITEM_NO=?";麻醉5.0利用bill_attr来区分是 手术(护士)收费和麻醉收费 EXCHANGE_INDICATOR = 0-是暂存 1-收费确认 2-待收费

        private static readonly string MED_OPERATION_BILL_ITEMS_Select_ONE_OLE = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,ORDERED_BY,PERFORMED_BY,COSTS,CHARGES,NOTES,VERIFIED_INDICATOR,ENTERED_BY,CLASS_ON_RECKONING,INPBILL_ITEM_NO,EVENT_ITEM_NO,EXCHANGE_INDICATOR,STORAGE_INDICATOR,BILL_ATTR,SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR FROM MED_OPERATION_BILL_ITEMS where PATIENT_ID=? AND VISIT_ID=? AND OPER_ID=? and ITEM_NO= ?  ";// AND ITEM_NO=?";麻醉5.0利用bill_attr来区分是 手术(护士)收费和麻醉收费 EXCHANGE_INDICATOR = 0-是暂存 1-收费确认 2-待收费
      

        private static readonly string MED_OPERATION_BILL_ITEMS_Select_ALL_OLE = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,ORDERED_BY,PERFORMED_BY,COSTS,CHARGES,NOTES,VERIFIED_INDICATOR,ENTERED_BY,CLASS_ON_RECKONING,INPBILL_ITEM_NO,EVENT_ITEM_NO,EXCHANGE_INDICATOR,STORAGE_INDICATOR,BILL_ATTR,SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR,ORDERED_DOCTOR,PERFORMED_DOCTOR FROM MED_OPERATION_BILL_ITEMS";
        private static readonly string MED_OPERATION_BILL_ITEMS_Select_No_OLE = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE, ITEM_SPEC, AMOUNT, UNITS, ORDERED_BY, PERFORMED_BY, COSTS, CHARGES, NOTES, VERIFIED_INDICATOR, ENTERED_BY, CLASS_ON_RECKONING, INPBILL_ITEM_NO, EVENT_ITEM_NO, EXCHANGE_INDICATOR, STORAGE_INDICATOR, BILL_ATTR, SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR,ORDERED_DOCTOR,PERFORMED_DOCTOR from MED_OPERATION_BILL_ITEMS where PATIENT_ID = ? and  VISIT_ID = ? and OPER_ID = ? and item_class = ? and  item_code = ? and item_spec = ? and units = ?  ";

        //public DALMedOperationBillItems()
        //{
        //}
        #region [获取参数ODBC]
        /// <summary>
        ///获取参数MedOperationBillItems ODBC
        /// </summary>
        public static OdbcParameter[] GetParameterODBC(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOperationBillItems")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("OperId",OdbcType.Decimal),
							new OdbcParameter("ItemNo",OdbcType.Decimal),
							new OdbcParameter("ItemClass",OdbcType.VarChar),
							new OdbcParameter("ItemName",OdbcType.VarChar),
							new OdbcParameter("ItemCode",OdbcType.VarChar),
							new OdbcParameter("ItemSpec",OdbcType.VarChar),
							new OdbcParameter("Amount",OdbcType.Decimal),
							new OdbcParameter("Units",OdbcType.VarChar),
							new OdbcParameter("OrderedBy",OdbcType.VarChar),
							new OdbcParameter("PerformedBy",OdbcType.VarChar),
							new OdbcParameter("Costs",OdbcType.Decimal),
							new OdbcParameter("Charges",OdbcType.Decimal),
							new OdbcParameter("Notes",OdbcType.VarChar),
							new OdbcParameter("VerifiedIndicator",OdbcType.Decimal),
							new OdbcParameter("EnteredBy",OdbcType.VarChar),
							new OdbcParameter("ClassOnReckoning",OdbcType.VarChar),
							new OdbcParameter("InpbillItemNo",OdbcType.Decimal),
							new OdbcParameter("EventItemNo",OdbcType.Decimal),
							new OdbcParameter("ExchangeIndicator",OdbcType.Decimal),
							new OdbcParameter("StorageIndicator",OdbcType.Decimal),
							new OdbcParameter("BillAttr",OdbcType.Decimal),
							new OdbcParameter("SupplierName",OdbcType.VarChar),
							new OdbcParameter("BillDate",OdbcType.DateTime),
                            new OdbcParameter("Price",OdbcType.Decimal),
                            new OdbcParameter("Operator",OdbcType.VarChar),
                            new OdbcParameter("ClassOnInRcpt",OdbcType.VarChar),
                            new OdbcParameter("SubjCode",OdbcType.VarChar),
                            new OdbcParameter("ClassOnMr",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedOperationBillItems")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("OperId",OdbcType.Decimal),
							new OdbcParameter("ItemNo",OdbcType.Decimal),
							new OdbcParameter("ItemClass",OdbcType.VarChar),
							new OdbcParameter("ItemName",OdbcType.VarChar),
							new OdbcParameter("ItemCode",OdbcType.VarChar),
							new OdbcParameter("ItemSpec",OdbcType.VarChar),
							new OdbcParameter("Amount",OdbcType.Decimal),
							new OdbcParameter("Units",OdbcType.VarChar),
							new OdbcParameter("OrderedBy",OdbcType.VarChar),
							new OdbcParameter("PerformedBy",OdbcType.VarChar),
							new OdbcParameter("Costs",OdbcType.Decimal),
							new OdbcParameter("Charges",OdbcType.Decimal),
							new OdbcParameter("Notes",OdbcType.VarChar),
							new OdbcParameter("VerifiedIndicator",OdbcType.Decimal),
							new OdbcParameter("EnteredBy",OdbcType.VarChar),
							new OdbcParameter("ClassOnReckoning",OdbcType.VarChar),
							new OdbcParameter("InpbillItemNo",OdbcType.Decimal),
							new OdbcParameter("EventItemNo",OdbcType.Decimal),
							new OdbcParameter("ExchangeIndicator",OdbcType.Decimal),
							new OdbcParameter("StorageIndicator",OdbcType.Decimal),
							new OdbcParameter("BillAttr",OdbcType.Decimal),
							new OdbcParameter("SupplierName",OdbcType.VarChar),
							new OdbcParameter("BillDate",OdbcType.DateTime),
                            new OdbcParameter("Price",OdbcType.Decimal),
                            new OdbcParameter("Operator",OdbcType.VarChar),
                            new OdbcParameter("ClassOnInRcpt",OdbcType.VarChar),
                            new OdbcParameter("SubjCode",OdbcType.VarChar),
                            new OdbcParameter("ClassOnMr",OdbcType.VarChar),
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("OperId",OdbcType.Decimal),
							new OdbcParameter("ItemNo",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedOperationBillItems")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("OperId",OdbcType.Decimal),
							new OdbcParameter("ItemNo",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedOperationBillItems")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("OperId",OdbcType.Decimal),
							new OdbcParameter("ItemNo",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedOperationBillItemsNo")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("OperId",OdbcType.Decimal),
							new OdbcParameter("ItemClass",OdbcType.VarChar),
							new OdbcParameter("ItemCode",OdbcType.VarChar),
							new OdbcParameter("ItemSpec",OdbcType.VarChar),
							new OdbcParameter("Units",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedOperationBillItemsForIn")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("PatientId",OdbcType.VarChar),
							new OdbcParameter("VisitId",OdbcType.Decimal),
							new OdbcParameter("OperId",OdbcType.Decimal),
                            new OdbcParameter("BillAttr",OdbcType.Decimal),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedOperationBillItems 
        ///Insert Table MED_OPERATION_BILL_ITEMS
        /// </summary>
        public int InsertMedOperationBillItemsODBC(MedOperationBillItems model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterODBC("InsertMedOperationBillItems");
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
                if (model.ItemNo.ToString() != null)
                    oneInert[3].Value = model.ItemNo;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.ItemClass != null)
                    oneInert[4].Value = model.ItemClass;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.ItemName != null)
                    oneInert[5].Value = model.ItemName;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.ItemCode != null)
                    oneInert[6].Value = model.ItemCode;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.ItemSpec != null)
                    oneInert[7].Value = model.ItemSpec;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.Amount.ToString() != null)
                    oneInert[8].Value = model.Amount;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Units != null)
                    oneInert[9].Value = model.Units;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.OrderedBy != null)
                    oneInert[10].Value = model.OrderedBy;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.PerformedBy != null)
                    oneInert[11].Value = model.PerformedBy;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.Costs.ToString() != null)
                    oneInert[12].Value = model.Costs;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.Charges.ToString() != null)
                    oneInert[13].Value = model.Charges;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.Notes != null)
                    oneInert[14].Value = model.Notes;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.VerifiedIndicator.ToString() != null)
                    oneInert[15].Value = model.VerifiedIndicator;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.EnteredBy != null)
                    oneInert[16].Value = model.EnteredBy;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.ClassOnReckoning != null)
                    oneInert[17].Value = model.ClassOnReckoning;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.InpbillItemNo.ToString() != null)
                    oneInert[18].Value = model.InpbillItemNo;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.EventItemNo.ToString() != null)
                    oneInert[19].Value = model.EventItemNo;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.ExchangeIndicator.ToString() != null)
                    oneInert[20].Value = model.ExchangeIndicator;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.StorageIndicator.ToString() != null)
                    oneInert[21].Value = model.StorageIndicator;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.BillAttr.ToString() != null)
                    oneInert[22].Value = model.BillAttr;
                else
                    oneInert[22].Value = DBNull.Value;
                if (model.SupplierName != null)
                    oneInert[23].Value = model.SupplierName;
                else
                    oneInert[23].Value = DBNull.Value;
                if (model.BillDate > DateTime.MinValue)
                    oneInert[24].Value = model.BillDate;
                else
                    oneInert[24].Value = DBNull.Value;
                if (model.Price.ToString() != null)
                {
                    oneInert[25].Value = model.Price;
                }
                else
                {
                    oneInert[25].Value = DBNull.Value;
                }
                if (model.Operator != null)
                {
                    oneInert[26].Value = model.Operator;
                }
                else
                {
                    oneInert[26].Value = DBNull.Value;
                }
                if (model.ClassOnInRcpt != null)
                {
                    oneInert[27].Value = model.ClassOnInRcpt;
                }
                else
                {
                    oneInert[27].Value = DBNull.Value;
                }
                if (model.SubjCode != null)
                {
                    oneInert[28].Value = model.SubjCode;
                }
                else
                {
                    oneInert[28].Value = DBNull.Value;
                }
                if (model.ClassOnMr != null)
                {
                    oneInert[29].Value = model.ClassOnMr;
                }
                else
                {
                    oneInert[29].Value = DBNull.Value;
                }
                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Insert_ODBC, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedOperationBillItems 
        ///Update Table     MED_OPERATION_BILL_ITEMS
        /// </summary>
        public int UpdateMedOperationBillItemsODBC(MedOperationBillItems model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterODBC("UpdateMedOperationBillItems");
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
                if (model.ItemNo.ToString() != null)
                    oneUpdate[3].Value = model.ItemNo;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.ItemClass != null)
                    oneUpdate[4].Value = model.ItemClass;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.ItemName != null)
                    oneUpdate[5].Value = model.ItemName;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.ItemCode != null)
                    oneUpdate[6].Value = model.ItemCode;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.ItemSpec != null)
                    oneUpdate[7].Value = model.ItemSpec;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.Amount.ToString() != null)
                    oneUpdate[8].Value = model.Amount;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.Units != null)
                    oneUpdate[9].Value = model.Units;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.OrderedBy != null)
                    oneUpdate[10].Value = model.OrderedBy;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.PerformedBy != null)
                    oneUpdate[11].Value = model.PerformedBy;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.Costs.ToString() != null)
                    oneUpdate[12].Value = model.Costs;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.Charges.ToString() != null)
                    oneUpdate[13].Value = model.Charges;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.Notes != null)
                    oneUpdate[14].Value = model.Notes;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.VerifiedIndicator.ToString() != null)
                    oneUpdate[15].Value = model.VerifiedIndicator;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.EnteredBy != null)
                    oneUpdate[16].Value = model.EnteredBy;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.ClassOnReckoning != null)
                    oneUpdate[17].Value = model.ClassOnReckoning;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.InpbillItemNo.ToString() != null)
                    oneUpdate[18].Value = model.InpbillItemNo;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.EventItemNo.ToString() != null)
                    oneUpdate[19].Value = model.EventItemNo;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.ExchangeIndicator.ToString() != null)
                    oneUpdate[20].Value = model.ExchangeIndicator;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.StorageIndicator.ToString() != null)
                    oneUpdate[21].Value = model.StorageIndicator;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.BillAttr.ToString() != null)
                    oneUpdate[22].Value = model.BillAttr;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.SupplierName != null)
                    oneUpdate[23].Value = model.SupplierName;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.BillDate > DateTime.MinValue)
                    oneUpdate[24].Value = model.BillDate;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.Price.ToString() != null)
                {
                    oneUpdate[25].Value = model.Price;
                }
                else
                {
                    oneUpdate[25].Value = DBNull.Value;
                }
                if (model.Operator != null)
                {
                    oneUpdate[26].Value = model.Operator;
                }
                else
                {
                    oneUpdate[26].Value = DBNull.Value;
                }
                if (model.ClassOnInRcpt != null)
                {
                    oneUpdate[27].Value = model.ClassOnInRcpt;
                }
                else
                {
                    oneUpdate[27].Value = DBNull.Value;
                }
                if (model.SubjCode != null)
                {
                    oneUpdate[28].Value = model.SubjCode;
                }
                else
                {
                    oneUpdate[28].Value = DBNull.Value;
                }
                if (model.ClassOnMr != null)
                {
                    oneUpdate[29].Value = model.ClassOnMr;
                }
                else
                {
                    oneUpdate[29].Value = DBNull.Value;
                }

                if (model.PatientId != null)
                    oneUpdate[30].Value = model.PatientId;
                else
                    oneUpdate[30].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneUpdate[31].Value = model.VisitId;
                else
                    oneUpdate[31].Value = DBNull.Value;
                if (model.OperId.ToString() != null)
                    oneUpdate[32].Value = model.OperId;
                else
                    oneUpdate[32].Value = DBNull.Value;
                if (model.ItemNo.ToString() != null)
                    oneUpdate[33].Value = model.ItemNo;
                else
                    oneUpdate[33].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Update_ODBC, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedOperationBillItems 
        ///Delete Table MED_OPERATION_BILL_ITEMS by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal ITEM_NO)
        /// </summary>
        public int DeleteMedOperationBillItemsODBC(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID, decimal ITEM_NO)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterODBC("DeleteMedOperationBillItems");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (VISIT_ID.ToString() != null)
                    oneDelete[1].Value = VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (OPER_ID.ToString() != null)
                    oneDelete[2].Value = OPER_ID;
                else
                    oneDelete[2].Value = DBNull.Value;
                if (ITEM_NO.ToString() != null)
                    oneDelete[3].Value = ITEM_NO;
                else
                    oneDelete[3].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Delete_ODBC, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedOperationBillItems 
        ///select Table MED_OPERATION_BILL_ITEMS by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal ITEM_NO)
        /// </summary>
        public MedOperationBillItems SelectMedOperationBillItemsODBC(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID, decimal ITEM_NO)
        {
            MedOperationBillItems model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedOperationBillItems");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = OPER_ID;
            parameterValues[3].Value = ITEM_NO;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Select_ONE_ODBC, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedOperationBillItems();
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
                        model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ItemClass = oleReader["ITEM_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.ItemName = oleReader["ITEM_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ItemCode = oleReader["ITEM_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.ItemSpec = oleReader["ITEM_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Amount = decimal.Parse(oleReader["AMOUNT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Units = oleReader["UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.OrderedBy = oleReader["ORDERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.PerformedBy = oleReader["PERFORMED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.Costs = decimal.Parse(oleReader["COSTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Charges = decimal.Parse(oleReader["CHARGES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Notes = oleReader["NOTES"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.VerifiedIndicator = decimal.Parse(oleReader["VERIFIED_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.EnteredBy = oleReader["ENTERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.ClassOnReckoning = oleReader["CLASS_ON_RECKONING"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.InpbillItemNo = decimal.Parse(oleReader["INPBILL_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.EventItemNo = decimal.Parse(oleReader["EVENT_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.ExchangeIndicator = decimal.Parse(oleReader["EXCHANGE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.StorageIndicator = decimal.Parse(oleReader["STORAGE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.BillAttr = decimal.Parse(oleReader["BILL_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.SupplierName = oleReader["SUPPLIER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.BillDate = DateTime.Parse(oleReader["BILL_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Price = decimal.Parse(oleReader["PRICE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.ClassOnInRcpt = oleReader["CLASS_ON_INP_RCPT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.SubjCode = oleReader["SUBJ_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.ClassOnMr = oleReader["CLASS_ON_MR"].ToString().Trim();
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
        public List<MedOperationBillItems> SelectMedOperationBillItemsListODBC()
        {
            List<MedOperationBillItems> modelList = new List<MedOperationBillItems>();
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Select_ALL_ODBC, null))
            {
                while (oleReader.Read())
                {
                    MedOperationBillItems model = new MedOperationBillItems();
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
                        model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ItemClass = oleReader["ITEM_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.ItemName = oleReader["ITEM_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ItemCode = oleReader["ITEM_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.ItemSpec = oleReader["ITEM_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Amount = decimal.Parse(oleReader["AMOUNT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Units = oleReader["UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.OrderedBy = oleReader["ORDERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.PerformedBy = oleReader["PERFORMED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.Costs = decimal.Parse(oleReader["COSTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Charges = decimal.Parse(oleReader["CHARGES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Notes = oleReader["NOTES"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.VerifiedIndicator = decimal.Parse(oleReader["VERIFIED_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.EnteredBy = oleReader["ENTERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.ClassOnReckoning = oleReader["CLASS_ON_RECKONING"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.InpbillItemNo = decimal.Parse(oleReader["INPBILL_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.EventItemNo = decimal.Parse(oleReader["EVENT_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.ExchangeIndicator = decimal.Parse(oleReader["EXCHANGE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.StorageIndicator = decimal.Parse(oleReader["STORAGE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.BillAttr = decimal.Parse(oleReader["BILL_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.SupplierName = oleReader["SUPPLIER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.BillDate = DateTime.Parse(oleReader["BILL_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Price = decimal.Parse(oleReader["PRICE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.ClassOnInRcpt = oleReader["CLASS_ON_INP_RCPT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.SubjCode = oleReader["SUBJ_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.ClassOnMr = oleReader["CLASS_ON_MR"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        public List<Model.MedOperationBillItems> SelectMedOperationBillItemsNoODBC(string patientId, decimal visitId, decimal operId, string itemClass, string itemCode, string itemSpec, string units)
        {
            List<Model.MedOperationBillItems> MedOperationBillItemsList = new List<Model.MedOperationBillItems>();

            OdbcParameter[] mdPats = GetParameterODBC("SelectMedOperationBillItemsNo");
            mdPats[0].Value = patientId;
            mdPats[1].Value = visitId;
            mdPats[2].Value = operId;
            mdPats[3].Value = itemClass;
            mdPats[4].Value = itemCode;
            mdPats[5].Value = itemSpec;
            mdPats[6].Value = units;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Select_No_ODBC, mdPats))
            {
                while (oleReader.Read())
                {
                    Model.MedOperationBillItems model = new MedOperationBillItems();
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
                        model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ItemClass = oleReader["ITEM_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.ItemName = oleReader["ITEM_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ItemCode = oleReader["ITEM_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.ItemSpec = oleReader["ITEM_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Amount = decimal.Parse(oleReader["AMOUNT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Units = oleReader["UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.OrderedBy = oleReader["ORDERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.PerformedBy = oleReader["PERFORMED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.Costs = decimal.Parse(oleReader["COSTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Charges = decimal.Parse(oleReader["CHARGES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Notes = oleReader["NOTES"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.VerifiedIndicator = decimal.Parse(oleReader["VERIFIED_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.EnteredBy = oleReader["ENTERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.ClassOnReckoning = oleReader["CLASS_ON_RECKONING"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.InpbillItemNo = decimal.Parse(oleReader["INPBILL_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.EventItemNo = decimal.Parse(oleReader["EVENT_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.ExchangeIndicator = decimal.Parse(oleReader["EXCHANGE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.StorageIndicator = decimal.Parse(oleReader["STORAGE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.BillAttr = decimal.Parse(oleReader["BILL_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.SupplierName = oleReader["SUPPLIER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.BillDate = DateTime.Parse(oleReader["BILL_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Price = decimal.Parse(oleReader["PRICE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.ClassOnInRcpt = oleReader["CLASS_ON_INP_RCPT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.SubjCode = oleReader["SUBJ_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.ClassOnMr = oleReader["CLASS_ON_MR"].ToString().Trim();
                    }
                    MedOperationBillItemsList.Add(model);
                }
            }
            return MedOperationBillItemsList;
        }

        public List<Model.MedOperationBillItems> SelectMedOperationBillItemsForInODBC(string patientId, decimal visitId, decimal operId, decimal billAttr)
        {
            List<Model.MedOperationBillItems> MedOperationBillItemsList = new List<Model.MedOperationBillItems>();

            OdbcParameter[] mdPats = GetParameterODBC("SelectMedOperationBillItemsForIn");
            mdPats[0].Value = patientId;
            mdPats[1].Value = visitId;
            mdPats[2].Value = operId;
            mdPats[3].Value = billAttr;

            StringBuilder MED_OPERATION_BILL_ITEMS_Select_ODBC_ForIn = new StringBuilder();
            MED_OPERATION_BILL_ITEMS_Select_ODBC_ForIn.Append(MED_OPERATION_BILL_ITEMS_Select_ODBC);
            //MED_OPERATION_BILL_ITEMS_Select_ODBC_ForIn.Append("and item_no in ( " + itemNoInStr + " ) ");

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Select_ODBC_ForIn.ToString(), mdPats))
            {
                while (oleReader.Read())
                {
                    Model.MedOperationBillItems model = new MedOperationBillItems();
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
                        model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ItemClass = oleReader["ITEM_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.ItemName = oleReader["ITEM_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ItemCode = oleReader["ITEM_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.ItemSpec = oleReader["ITEM_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Amount = decimal.Parse(oleReader["AMOUNT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Units = oleReader["UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.OrderedBy = oleReader["ORDERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.PerformedBy = oleReader["PERFORMED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.Costs = decimal.Parse(oleReader["COSTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Charges = decimal.Parse(oleReader["CHARGES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Notes = oleReader["NOTES"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.VerifiedIndicator = decimal.Parse(oleReader["VERIFIED_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.EnteredBy = oleReader["ENTERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.ClassOnReckoning = oleReader["CLASS_ON_RECKONING"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.InpbillItemNo = decimal.Parse(oleReader["INPBILL_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.EventItemNo = decimal.Parse(oleReader["EVENT_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.ExchangeIndicator = decimal.Parse(oleReader["EXCHANGE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.StorageIndicator = decimal.Parse(oleReader["STORAGE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.BillAttr = decimal.Parse(oleReader["BILL_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.SupplierName = oleReader["SUPPLIER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.BillDate = DateTime.Parse(oleReader["BILL_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Price = decimal.Parse(oleReader["PRICE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.ClassOnInRcpt = oleReader["CLASS_ON_INP_RCPT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.SubjCode = oleReader["SUBJ_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.ClassOnMr = oleReader["CLASS_ON_MR"].ToString().Trim();
                    }
                    MedOperationBillItemsList.Add(model);
                }
            }
            return MedOperationBillItemsList;
        }

        #region [获取参数]
        /// <summary>
        ///获取参数MedOperationBillItems
        /// </summary>
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOperationBillItems")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("OperId",OleDbType.Decimal),
							new OleDbParameter("ItemNo",OleDbType.Decimal),
							new OleDbParameter("ItemClass",OleDbType.VarChar),
							new OleDbParameter("ItemName",OleDbType.VarChar),
							new OleDbParameter("ItemCode",OleDbType.VarChar),
							new OleDbParameter("ItemSpec",OleDbType.VarChar),
							new OleDbParameter("Amount",OleDbType.Decimal),
							new OleDbParameter("Units",OleDbType.VarChar),
							new OleDbParameter("OrderedBy",OleDbType.VarChar),
							new OleDbParameter("PerformedBy",OleDbType.VarChar),
							new OleDbParameter("Costs",OleDbType.Decimal),
							new OleDbParameter("Charges",OleDbType.Decimal),
							new OleDbParameter("Notes",OleDbType.VarChar),
							new OleDbParameter("VerifiedIndicator",OleDbType.Decimal),
							new OleDbParameter("EnteredBy",OleDbType.VarChar),
							new OleDbParameter("ClassOnReckoning",OleDbType.VarChar),
							new OleDbParameter("InpbillItemNo",OleDbType.Decimal),
							new OleDbParameter("EventItemNo",OleDbType.Decimal),
							new OleDbParameter("ExchangeIndicator",OleDbType.Decimal),
							new OleDbParameter("StorageIndicator",OleDbType.Decimal),
							new OleDbParameter("BillAttr",OleDbType.Decimal),
							new OleDbParameter("SupplierName",OleDbType.VarChar),
							new OleDbParameter("BillDate",OleDbType.DBTimeStamp),
                            new OleDbParameter("Price",OleDbType.Decimal),
                            new OleDbParameter("Operator",OleDbType.VarChar),
                            new OleDbParameter("ClassOnInRcpt",OleDbType.VarChar),
                            new OleDbParameter("SubjCode",OleDbType.VarChar),
                            new OleDbParameter("ClassOnMr",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedOperationBillItems")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("OperId",OleDbType.Decimal),
							new OleDbParameter("ItemNo",OleDbType.Decimal),
							new OleDbParameter("ItemClass",OleDbType.VarChar),
							new OleDbParameter("ItemName",OleDbType.VarChar),
							new OleDbParameter("ItemCode",OleDbType.VarChar),
							new OleDbParameter("ItemSpec",OleDbType.VarChar),
							new OleDbParameter("Amount",OleDbType.Decimal),
							new OleDbParameter("Units",OleDbType.VarChar),
							new OleDbParameter("OrderedBy",OleDbType.VarChar),
							new OleDbParameter("PerformedBy",OleDbType.VarChar),
							new OleDbParameter("Costs",OleDbType.Decimal),
							new OleDbParameter("Charges",OleDbType.Decimal),
							new OleDbParameter("Notes",OleDbType.VarChar),
							new OleDbParameter("VerifiedIndicator",OleDbType.Decimal),
							new OleDbParameter("EnteredBy",OleDbType.VarChar),
							new OleDbParameter("ClassOnReckoning",OleDbType.VarChar),
							new OleDbParameter("InpbillItemNo",OleDbType.Decimal),
							new OleDbParameter("EventItemNo",OleDbType.Decimal),
							new OleDbParameter("ExchangeIndicator",OleDbType.Decimal),
							new OleDbParameter("StorageIndicator",OleDbType.Decimal),
							new OleDbParameter("BillAttr",OleDbType.Decimal),
							new OleDbParameter("SupplierName",OleDbType.VarChar),
							new OleDbParameter("BillDate",OleDbType.DBTimeStamp),
                            new OleDbParameter("Price",OleDbType.Decimal),
                            new OleDbParameter("Operator",OleDbType.VarChar),
                            new OleDbParameter("ClassOnInRcpt",OleDbType.VarChar),
                            new OleDbParameter("SubjCode",OleDbType.VarChar),
                            new OleDbParameter("ClassOnMr",OleDbType.VarChar),
							new OleDbParameter("PatientId",OdbcType.VarChar),
							new OleDbParameter("VisitId",OdbcType.Decimal),
							new OleDbParameter("OperId",OdbcType.Decimal),
							new OleDbParameter("ItemNo",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedOperationBillItems")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("OperId",OleDbType.Decimal),
							new OleDbParameter("ItemNo",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedOperationBillItems")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("OperId",OleDbType.Decimal),
							new OleDbParameter("ItemNo",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedOperationBillItemsNo")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("OperId",OleDbType.Decimal),
							new OleDbParameter("ItemClass",OleDbType.VarChar),
							new OleDbParameter("ItemCode",OleDbType.VarChar),
							new OleDbParameter("ItemSpec",OleDbType.VarChar),
							new OleDbParameter("Units",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedOperationBillItemsForIn")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("OperId",OleDbType.Decimal),
							new OleDbParameter("BillAttr",OleDbType.Decimal),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedOperationBillItems 
        ///Insert Table MED_OPERATION_BILL_ITEMS
        /// </summary>
        public int InsertMedOperationBillItemsOLE(MedOperationBillItems model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedOperationBillItems");
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
                if (model.ItemNo.ToString() != null)
                    oneInert[3].Value = model.ItemNo;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.ItemClass != null)
                    oneInert[4].Value = model.ItemClass;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.ItemName != null)
                    oneInert[5].Value = model.ItemName;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.ItemCode != null)
                    oneInert[6].Value = model.ItemCode;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.ItemSpec != null)
                    oneInert[7].Value = model.ItemSpec;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.Amount.ToString() != null)
                    oneInert[8].Value = model.Amount;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Units != null)
                    oneInert[9].Value = model.Units;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.OrderedBy != null)
                    oneInert[10].Value = model.OrderedBy;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.PerformedBy != null)
                    oneInert[11].Value = model.PerformedBy;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.Costs.ToString() != null)
                    oneInert[12].Value = model.Costs;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.Charges.ToString() != null)
                    oneInert[13].Value = model.Charges;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.Notes != null)
                    oneInert[14].Value = model.Notes;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.VerifiedIndicator.ToString() != null)
                    oneInert[15].Value = model.VerifiedIndicator;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.EnteredBy != null)
                    oneInert[16].Value = model.EnteredBy;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.ClassOnReckoning != null)
                    oneInert[17].Value = model.ClassOnReckoning;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.InpbillItemNo.ToString() != null)
                    oneInert[18].Value = model.InpbillItemNo;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.EventItemNo.ToString() != null)
                    oneInert[19].Value = model.EventItemNo;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.ExchangeIndicator.ToString() != null)
                    oneInert[20].Value = model.ExchangeIndicator;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.StorageIndicator.ToString() != null)
                    oneInert[21].Value = model.StorageIndicator;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.BillAttr.ToString() != null)
                    oneInert[22].Value = model.BillAttr;
                else
                    oneInert[22].Value = DBNull.Value;
                if (model.SupplierName != null)
                    oneInert[23].Value = model.SupplierName;
                else
                    oneInert[23].Value = DBNull.Value;
                if (model.BillDate > DateTime.MinValue)
                    oneInert[24].Value = model.BillDate;
                else
                    oneInert[24].Value = DBNull.Value;
                if (model.Price.ToString() != null)
                {
                    oneInert[25].Value = model.Price;
                }
                else
                {
                    oneInert[25].Value = DBNull.Value;
                }
                if (model.Operator != null)
                {
                    oneInert[26].Value = model.Operator;
                }
                else
                {
                    oneInert[26].Value = DBNull.Value;
                }
                if (model.ClassOnInRcpt != null)
                {
                    oneInert[27].Value = model.ClassOnInRcpt;
                }
                else
                {
                    oneInert[27].Value = DBNull.Value;
                }
                if (model.SubjCode != null)
                {
                    oneInert[28].Value = model.SubjCode;
                }
                else
                {
                    oneInert[28].Value = DBNull.Value;
                }
                if (model.ClassOnMr != null)
                {
                    oneInert[29].Value = model.ClassOnMr;
                }
                else
                {
                    oneInert[29].Value = DBNull.Value;
                }
                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Insert_OLE, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedOperationBillItems 
        ///Update Table     MED_OPERATION_BILL_ITEMS
        /// </summary>
        public int UpdateMedOperationBillItemsOLE(MedOperationBillItems model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedOperationBillItems");
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
                if (model.ItemNo.ToString() != null)
                    oneUpdate[3].Value = model.ItemNo;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.ItemClass != null)
                    oneUpdate[4].Value = model.ItemClass;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.ItemName != null)
                    oneUpdate[5].Value = model.ItemName;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.ItemCode != null)
                    oneUpdate[6].Value = model.ItemCode;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.ItemSpec != null)
                    oneUpdate[7].Value = model.ItemSpec;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.Amount.ToString() != null)
                    oneUpdate[8].Value = model.Amount;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.Units != null)
                    oneUpdate[9].Value = model.Units;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.OrderedBy != null)
                    oneUpdate[10].Value = model.OrderedBy;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.PerformedBy != null)
                    oneUpdate[11].Value = model.PerformedBy;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.Costs.ToString() != null)
                    oneUpdate[12].Value = model.Costs;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.Charges.ToString() != null)
                    oneUpdate[13].Value = model.Charges;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.Notes != null)
                    oneUpdate[14].Value = model.Notes;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.VerifiedIndicator.ToString() != null)
                    oneUpdate[15].Value = model.VerifiedIndicator;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.EnteredBy != null)
                    oneUpdate[16].Value = model.EnteredBy;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.ClassOnReckoning != null)
                    oneUpdate[17].Value = model.ClassOnReckoning;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.InpbillItemNo.ToString() != null)
                    oneUpdate[18].Value = model.InpbillItemNo;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.EventItemNo.ToString() != null)
                    oneUpdate[19].Value = model.EventItemNo;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.ExchangeIndicator.ToString() != null)
                    oneUpdate[20].Value = model.ExchangeIndicator;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.StorageIndicator.ToString() != null)
                    oneUpdate[21].Value = model.StorageIndicator;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.BillAttr.ToString() != null)
                    oneUpdate[22].Value = model.BillAttr;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.SupplierName != null)
                    oneUpdate[23].Value = model.SupplierName;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.BillDate > DateTime.MinValue)
                    oneUpdate[24].Value = model.BillDate;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.Price.ToString() != null)
                {
                    oneUpdate[25].Value = model.Price;
                }
                else
                {
                    oneUpdate[25].Value = DBNull.Value;
                }
                if (model.Operator != null)
                {
                    oneUpdate[26].Value = model.Operator;
                }
                else
                {
                    oneUpdate[26].Value = DBNull.Value;
                }
                if (model.ClassOnInRcpt != null)
                {
                    oneUpdate[27].Value = model.ClassOnInRcpt;
                }
                else
                {
                    oneUpdate[27].Value = DBNull.Value;
                }
                if (model.SubjCode != null)
                {
                    oneUpdate[28].Value = model.SubjCode;
                }
                else
                {
                    oneUpdate[28].Value = DBNull.Value;
                }
                if (model.ClassOnMr != null)
                {
                    oneUpdate[29].Value = model.ClassOnMr;
                }
                else
                {
                    oneUpdate[29].Value = DBNull.Value;
                }

                if (model.PatientId != null)
                    oneUpdate[30].Value = model.PatientId;
                else
                    oneUpdate[30].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneUpdate[31].Value = model.VisitId;
                else
                    oneUpdate[31].Value = DBNull.Value;
                if (model.OperId.ToString() != null)
                    oneUpdate[32].Value = model.OperId;
                else
                    oneUpdate[32].Value = DBNull.Value;
                if (model.ItemNo.ToString() != null)
                    oneUpdate[33].Value = model.ItemNo;
                else
                    oneUpdate[33].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Update_OLE, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedOperationBillItems 
        ///Delete Table MED_OPERATION_BILL_ITEMS by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal ITEM_NO)
        /// </summary>
        public int DeleteMedOperationBillItemsOLE(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID, decimal ITEM_NO)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedOperationBillItems");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (VISIT_ID.ToString() != null)
                    oneDelete[1].Value = VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (OPER_ID.ToString() != null)
                    oneDelete[2].Value = OPER_ID;
                else
                    oneDelete[2].Value = DBNull.Value;
                if (ITEM_NO.ToString() != null)
                    oneDelete[3].Value = ITEM_NO;
                else
                    oneDelete[3].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Delete_OLE, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedOperationBillItems 
        ///select Table MED_OPERATION_BILL_ITEMS by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal ITEM_NO)
        /// </summary>
        public MedOperationBillItems SelectMedOperationBillItemsOLE(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID, decimal ITEM_NO)
        {
            MedOperationBillItems model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedOperationBillItems");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = OPER_ID;
            parameterValues[3].Value = ITEM_NO;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Select_ONE_OLE, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedOperationBillItems();
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
                        model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ItemClass = oleReader["ITEM_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.ItemName = oleReader["ITEM_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ItemCode = oleReader["ITEM_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.ItemSpec = oleReader["ITEM_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Amount = decimal.Parse(oleReader["AMOUNT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Units = oleReader["UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.OrderedBy = oleReader["ORDERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.PerformedBy = oleReader["PERFORMED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.Costs = decimal.Parse(oleReader["COSTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Charges = decimal.Parse(oleReader["CHARGES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Notes = oleReader["NOTES"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.VerifiedIndicator = decimal.Parse(oleReader["VERIFIED_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.EnteredBy = oleReader["ENTERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.ClassOnReckoning = oleReader["CLASS_ON_RECKONING"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.InpbillItemNo = decimal.Parse(oleReader["INPBILL_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.EventItemNo = decimal.Parse(oleReader["EVENT_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.ExchangeIndicator = decimal.Parse(oleReader["EXCHANGE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.StorageIndicator = decimal.Parse(oleReader["STORAGE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.BillAttr = decimal.Parse(oleReader["BILL_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.SupplierName = oleReader["SUPPLIER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.BillDate = DateTime.Parse(oleReader["BILL_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Price = decimal.Parse(oleReader["PRICE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.ClassOnInRcpt = oleReader["CLASS_ON_INP_RCPT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.SubjCode = oleReader["SUBJ_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.ClassOnMr = oleReader["CLASS_ON_MR"].ToString().Trim();
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
        public List<MedOperationBillItems> SelectMedOperationBillItemsListOLE()
        {
            List<MedOperationBillItems> modelList = new List<MedOperationBillItems>();
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Select_ALL_OLE, null))
            {
                while (oleReader.Read())
                {
                    MedOperationBillItems model = new MedOperationBillItems();
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
                        model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ItemClass = oleReader["ITEM_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.ItemName = oleReader["ITEM_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ItemCode = oleReader["ITEM_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.ItemSpec = oleReader["ITEM_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Amount = decimal.Parse(oleReader["AMOUNT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Units = oleReader["UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.OrderedBy = oleReader["ORDERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.PerformedBy = oleReader["PERFORMED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.Costs = decimal.Parse(oleReader["COSTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Charges = decimal.Parse(oleReader["CHARGES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Notes = oleReader["NOTES"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.VerifiedIndicator = decimal.Parse(oleReader["VERIFIED_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.EnteredBy = oleReader["ENTERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.ClassOnReckoning = oleReader["CLASS_ON_RECKONING"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.InpbillItemNo = decimal.Parse(oleReader["INPBILL_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.EventItemNo = decimal.Parse(oleReader["EVENT_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.ExchangeIndicator = decimal.Parse(oleReader["EXCHANGE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.StorageIndicator = decimal.Parse(oleReader["STORAGE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.BillAttr = decimal.Parse(oleReader["BILL_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.SupplierName = oleReader["SUPPLIER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.BillDate = DateTime.Parse(oleReader["BILL_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Price = decimal.Parse(oleReader["PRICE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.ClassOnInRcpt = oleReader["CLASS_ON_INP_RCPT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.SubjCode = oleReader["SUBJ_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.ClassOnMr = oleReader["CLASS_ON_MR"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        public List<Model.MedOperationBillItems> SelectMedOperationBillItemsNoOLE(string patientId, decimal visitId, decimal operId, string itemClass, string itemCode, string itemSpec, string units)
        {
            List<Model.MedOperationBillItems> MedOperationBillItemsList = new List<Model.MedOperationBillItems>();

            OleDbParameter[] mdPats = GetParameterOLE("SelectMedOperationBillItemsNo");
            mdPats[0].Value = patientId;
            mdPats[1].Value = visitId;
            mdPats[2].Value = operId;
            mdPats[3].Value = itemClass;
            mdPats[4].Value = itemCode;
            mdPats[5].Value = itemSpec;
            mdPats[6].Value = units;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Select_No_OLE, mdPats))
            {
                while (oleReader.Read())
                {
                    Model.MedOperationBillItems model = new MedOperationBillItems();
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
                        model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ItemClass = oleReader["ITEM_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.ItemName = oleReader["ITEM_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ItemCode = oleReader["ITEM_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.ItemSpec = oleReader["ITEM_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Amount = decimal.Parse(oleReader["AMOUNT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Units = oleReader["UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.OrderedBy = oleReader["ORDERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.PerformedBy = oleReader["PERFORMED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.Costs = decimal.Parse(oleReader["COSTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Charges = decimal.Parse(oleReader["CHARGES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Notes = oleReader["NOTES"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.VerifiedIndicator = decimal.Parse(oleReader["VERIFIED_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.EnteredBy = oleReader["ENTERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.ClassOnReckoning = oleReader["CLASS_ON_RECKONING"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.InpbillItemNo = decimal.Parse(oleReader["INPBILL_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.EventItemNo = decimal.Parse(oleReader["EVENT_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.ExchangeIndicator = decimal.Parse(oleReader["EXCHANGE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.StorageIndicator = decimal.Parse(oleReader["STORAGE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.BillAttr = decimal.Parse(oleReader["BILL_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.SupplierName = oleReader["SUPPLIER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.BillDate = DateTime.Parse(oleReader["BILL_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Price = decimal.Parse(oleReader["PRICE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.ClassOnInRcpt = oleReader["CLASS_ON_INP_RCPT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.SubjCode = oleReader["SUBJ_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.ClassOnMr = oleReader["CLASS_ON_MR"].ToString().Trim();
                    }
                    MedOperationBillItemsList.Add(model);
                }

            }
            return MedOperationBillItemsList;
        }

        public List<Model.MedOperationBillItems> SelectMedOperationBillItemsForInOLE(string patientId, decimal visitId, decimal operId, decimal billAttr)
        {
            List<Model.MedOperationBillItems> MedOperationBillItemsList = new List<Model.MedOperationBillItems>();

            OleDbParameter[] mdPats = GetParameterOLE("SelectMedOperationBillItemsForIn");
            mdPats[0].Value = patientId;
            mdPats[1].Value = visitId;
            mdPats[2].Value = operId;
            mdPats[3].Value = billAttr;

            StringBuilder MED_OPERATION_BILL_ITEMS_Select_ForIn = new StringBuilder();
            MED_OPERATION_BILL_ITEMS_Select_ForIn.Append(MED_OPERATION_BILL_ITEMS_Select_OLE);
            //MED_OPERATION_BILL_ITEMS_Select_ForIn.Append("and item_no in ( " + itemNoInStr + " ) ");

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Select_ForIn.ToString(), mdPats))
            {
                while (oleReader.Read())
                {
                    Model.MedOperationBillItems model = new MedOperationBillItems();
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
                        model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.ItemClass = oleReader["ITEM_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.ItemName = oleReader["ITEM_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ItemCode = oleReader["ITEM_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.ItemSpec = oleReader["ITEM_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Amount = decimal.Parse(oleReader["AMOUNT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Units = oleReader["UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.OrderedBy = oleReader["ORDERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.PerformedBy = oleReader["PERFORMED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.Costs = decimal.Parse(oleReader["COSTS"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Charges = decimal.Parse(oleReader["CHARGES"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Notes = oleReader["NOTES"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.VerifiedIndicator = decimal.Parse(oleReader["VERIFIED_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.EnteredBy = oleReader["ENTERED_BY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.ClassOnReckoning = oleReader["CLASS_ON_RECKONING"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.InpbillItemNo = decimal.Parse(oleReader["INPBILL_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.EventItemNo = decimal.Parse(oleReader["EVENT_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.ExchangeIndicator = decimal.Parse(oleReader["EXCHANGE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.StorageIndicator = decimal.Parse(oleReader["STORAGE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.BillAttr = decimal.Parse(oleReader["BILL_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.SupplierName = oleReader["SUPPLIER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.BillDate = DateTime.Parse(oleReader["BILL_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Price = decimal.Parse(oleReader["PRICE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.Operator = oleReader["OPERATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.ClassOnInRcpt = oleReader["CLASS_ON_INP_RCPT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.SubjCode = oleReader["SUBJ_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.ClassOnMr = oleReader["CLASS_ON_MR"].ToString().Trim();
                    }
                    MedOperationBillItemsList.Add(model);
                }
            }
            return MedOperationBillItemsList;
        }
    }
}
