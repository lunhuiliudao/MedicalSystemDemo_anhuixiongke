

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:06:12
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
using System.Data.SqlClient;
using System.Data.OracleClient;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedOperationBillItems
    /// </summary>

    public partial class DALMedOperationBillItems
    {

        private static readonly string MED_OPERATION_BILL_ITEMS_Insert_SQL = "INSERT INTO MED_OPERATION_BILL_ITEMS (PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,ORDERED_BY,PERFORMED_BY,COSTS,CHARGES,NOTES,VERIFIED_INDICATOR,ENTERED_BY,CLASS_ON_RECKONING,INPBILL_ITEM_NO,EVENT_ITEM_NO,EXCHANGE_INDICATOR,STORAGE_INDICATOR,BILL_ATTR,SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR) values (@PatientId,@VisitId,@OperId,@ItemNo,@ItemClass,@ItemName,@ItemCode,@ItemSpec,@Amount,@Units,@OrderedBy,@PerformedBy,@Costs,@Charges,@Notes,@VerifiedIndicator,@EnteredBy,@ClassOnReckoning,@InpbillItemNo,@EventItemNo,@ExchangeIndicator,@StorageIndicator,@BillAttr,@SupplierName,@BillDate,@Price,@Operator,@ClassOnInRcpt,@SubjCode,@ClassOnMr)";
        private static readonly string MED_OPERATION_BILL_ITEMS_Update_SQL = "UPDATE MED_OPERATION_BILL_ITEMS SET PATIENT_ID=@PatientId,VISIT_ID=@VisitId,OPER_ID=@OperId,ITEM_NO=@ItemNo,ITEM_CLASS=@ItemClass,ITEM_NAME=@ItemName,ITEM_CODE=@ItemCode,ITEM_SPEC=@ItemSpec,AMOUNT=@Amount,UNITS=@Units,ORDERED_BY=@OrderedBy,PERFORMED_BY=@PerformedBy,COSTS=@Costs,CHARGES=@Charges,NOTES=@Notes,VERIFIED_INDICATOR=@VerifiedIndicator,ENTERED_BY=@EnteredBy,CLASS_ON_RECKONING=@ClassOnReckoning,INPBILL_ITEM_NO=@InpbillItemNo,EVENT_ITEM_NO=@EventItemNo,EXCHANGE_INDICATOR=@ExchangeIndicator,STORAGE_INDICATOR=@StorageIndicator,BILL_ATTR=@BillAttr,SUPPLIER_NAME=@SupplierName,BILL_DATE=@BillDate ,PRICE = @Price,OPERATOR=@Operator,CLASS_ON_INP_RCPT=@ClassOnInRcpt,SUBJ_CODE=@SubjCode,CLASS_ON_MR=@ClassOnMr WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND OPER_ID=@OperId AND ITEM_NO=@ItemNo";
        private static readonly string MED_OPERATION_BILL_ITEMS_Delete_SQL = "Delete MED_OPERATION_BILL_ITEMS WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND OPER_ID=@OperId AND ITEM_NO=@ItemNo";
      
        private static readonly string MED_OPERATION_BILL_ITEMS_Select_SQL = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,ORDERED_BY,PERFORMED_BY,COSTS,CHARGES,NOTES,VERIFIED_INDICATOR,ENTERED_BY,CLASS_ON_RECKONING,INPBILL_ITEM_NO,EVENT_ITEM_NO,EXCHANGE_INDICATOR,STORAGE_INDICATOR,BILL_ATTR,SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR FROM MED_OPERATION_BILL_ITEMS where PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND OPER_ID=@OperId and BILL_ATTR= @billAttr and EXCHANGE_INDICATOR =2 and amount <>0";// AND ITEM_NO=?";麻醉5.0利用bill_attr来区分是 手术(护士)收费和麻醉收费 EXCHANGE_INDICATOR = 0是未收费

        private static readonly string MED_OPERATION_BILL_ITEMS_Select_ONE_SQL = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,ORDERED_BY,PERFORMED_BY,COSTS,CHARGES,NOTES,VERIFIED_INDICATOR,ENTERED_BY,CLASS_ON_RECKONING,INPBILL_ITEM_NO,EVENT_ITEM_NO,EXCHANGE_INDICATOR,STORAGE_INDICATOR,BILL_ATTR,SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR FROM MED_OPERATION_BILL_ITEMS where PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND OPER_ID=@OperId and ITEM_NO= @ItemNo";// AND ITEM_NO=?";麻醉5.0利用bill_attr来区分是 手术(护士)收费和麻醉收费 EXCHANGE_INDICATOR = 0是未收费
       
        private static readonly string MED_OPERATION_BILL_ITEMS_Select_ALL_SQL = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,ORDERED_BY,PERFORMED_BY,COSTS,CHARGES,NOTES,VERIFIED_INDICATOR,ENTERED_BY,CLASS_ON_RECKONING,INPBILL_ITEM_NO,EVENT_ITEM_NO,EXCHANGE_INDICATOR,STORAGE_INDICATOR,BILL_ATTR,SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR,ORDERED_DOCTOR,PERFORMED_DOCTOR FROM MED_OPERATION_BILL_ITEMS";
        private static readonly string MED_OPERATION_BILL_ITEMS_Select_No_SQL = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE, ITEM_SPEC, AMOUNT, UNITS, ORDERED_BY, PERFORMED_BY, COSTS, CHARGES, NOTES, VERIFIED_INDICATOR, ENTERED_BY, CLASS_ON_RECKONING, INPBILL_ITEM_NO, EVENT_ITEM_NO, EXCHANGE_INDICATOR, STORAGE_INDICATOR, BILL_ATTR, SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR,ORDERED_DOCTOR,PERFORMED_DOCTOR from MED_OPERATION_BILL_ITEMS where PATIENT_ID = @patientId and  VISIT_ID = @visitId and OPER_ID = @operId and item_class = @itemClass and  item_code = @itemCode and item_spec = @itemSpec and units = @units  ";

        private static readonly string MED_OPERATION_BILL_ITEMS_Insert = "INSERT INTO MED_OPERATION_BILL_ITEMS (PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,ORDERED_BY,PERFORMED_BY,COSTS,CHARGES,NOTES,VERIFIED_INDICATOR,ENTERED_BY,CLASS_ON_RECKONING,INPBILL_ITEM_NO,EVENT_ITEM_NO,EXCHANGE_INDICATOR,STORAGE_INDICATOR,BILL_ATTR,SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR) values (:PatientId,:VisitId,:OperId,:ItemNo,:ItemClass,:ItemName,:ItemCode,:ItemSpec,:Amount,:Units,:OrderedBy,:PerformedBy,:Costs,:Charges,:Notes,:VerifiedIndicator,:EnteredBy,:ClassOnReckoning,:InpbillItemNo,:EventItemNo,:ExchangeIndicator,:StorageIndicator,:BillAttr,:SupplierName,:BillDate,:Price,:Operator,:ClassOnInRcpt,:SubjCode,:ClassOnMr)";
        private static readonly string MED_OPERATION_BILL_ITEMS_Update = "UPDATE MED_OPERATION_BILL_ITEMS SET PATIENT_ID=:PatientId,VISIT_ID=:VisitId,OPER_ID=:OperId,ITEM_NO=:ItemNo,ITEM_CLASS=:ItemClass,ITEM_NAME=:ItemName,ITEM_CODE=:ItemCode,ITEM_SPEC=:ItemSpec,AMOUNT=:Amount,UNITS=:Units,ORDERED_BY=:OrderedBy,PERFORMED_BY=:PerformedBy,COSTS=:Costs,CHARGES=:Charges,NOTES=:Notes,VERIFIED_INDICATOR=:VerifiedIndicator,ENTERED_BY=:EnteredBy,CLASS_ON_RECKONING=:ClassOnReckoning,INPBILL_ITEM_NO=:InpbillItemNo,EVENT_ITEM_NO=:EventItemNo,EXCHANGE_INDICATOR=:ExchangeIndicator,STORAGE_INDICATOR=:StorageIndicator,BILL_ATTR=:BillAttr,SUPPLIER_NAME=:SupplierName,BILL_DATE=:BillDate,PRICE = :Price,OPERATOR=:Operator,CLASS_ON_INP_RCPT=:ClassOnInRcpt,SUBJ_CODE=:SubjCode,CLASS_ON_MR=:ClassOnMr WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND OPER_ID=:OperId AND ITEM_NO=:ItemNo";
        private static readonly string MED_OPERATION_BILL_ITEMS_Delete = "Delete MED_OPERATION_BILL_ITEMS WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND OPER_ID=:OperId AND ITEM_NO=:ItemNo";
     
        private static readonly string MED_OPERATION_BILL_ITEMS_Select = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,ORDERED_BY,PERFORMED_BY,COSTS,CHARGES,NOTES,VERIFIED_INDICATOR,ENTERED_BY,CLASS_ON_RECKONING,INPBILL_ITEM_NO,EVENT_ITEM_NO,EXCHANGE_INDICATOR,STORAGE_INDICATOR,BILL_ATTR,SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR FROM MED_OPERATION_BILL_ITEMS where PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND OPER_ID=:OperId and BILL_ATTR= :billAttr and EXCHANGE_INDICATOR  =2 and amount <>0";// AND ITEM_NO=?";麻醉5.0利用bill_attr来区分是 手术(护士)收费和麻醉收费 EXCHANGE_INDICATOR = 0-是暂存 1-收费确认 2-待收费

        private static readonly string MED_OPERATION_BILL_ITEMS_ONE_Select = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,ORDERED_BY,PERFORMED_BY,COSTS,CHARGES,NOTES,VERIFIED_INDICATOR,ENTERED_BY,CLASS_ON_RECKONING,INPBILL_ITEM_NO,EVENT_ITEM_NO,EXCHANGE_INDICATOR,STORAGE_INDICATOR,BILL_ATTR,SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR FROM MED_OPERATION_BILL_ITEMS where PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND OPER_ID=:OperId and ITEM_NO= :ItemNo";// AND ITEM_NO=?";麻醉5.0利用bill_attr来区分是 手术(护士)收费和麻醉收费 EXCHANGE_INDICATOR = 0-是暂存 1-收费确认 2-待收费
     

        private static readonly string MED_OPERATION_BILL_ITEMS_Select_ALL = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,ORDERED_BY,PERFORMED_BY,COSTS,CHARGES,NOTES,VERIFIED_INDICATOR,ENTERED_BY,CLASS_ON_RECKONING,INPBILL_ITEM_NO,EVENT_ITEM_NO,EXCHANGE_INDICATOR,STORAGE_INDICATOR,BILL_ATTR,SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR,ORDERED_DOCTOR,PERFORMED_DOCTOR FROM MED_OPERATION_BILL_ITEMS";

        private static readonly string MED_OPERATION_BILL_ITEMS_Select_No = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE, ITEM_SPEC, AMOUNT, UNITS, ORDERED_BY, PERFORMED_BY, COSTS, CHARGES, NOTES, VERIFIED_INDICATOR, ENTERED_BY, CLASS_ON_RECKONING, INPBILL_ITEM_NO, EVENT_ITEM_NO, EXCHANGE_INDICATOR, STORAGE_INDICATOR, BILL_ATTR, SUPPLIER_NAME,BILL_DATE,PRICE,OPERATOR,CLASS_ON_INP_RCPT,SUBJ_CODE,CLASS_ON_MR,ORDERED_DOCTOR,PERFORMED_DOCTOR from MED_OPERATION_BILL_ITEMS where PATIENT_ID = :patientId and  VISIT_ID = :visitId and OPER_ID = :operId and item_class = :itemClass and  item_code = :itemCode and item_spec = :itemSpec and units = :units ";

        public DALMedOperationBillItems()
        {
        }
        #region [获取参数SQL]
        /// <summary>
        ///获取参数MedOperationBillItems SQL
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOperationBillItems")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OperId",SqlDbType.Decimal),
							new SqlParameter("@ItemNo",SqlDbType.Decimal),
							new SqlParameter("@ItemClass",SqlDbType.VarChar),
							new SqlParameter("@ItemName",SqlDbType.VarChar),
							new SqlParameter("@ItemCode",SqlDbType.VarChar),
							new SqlParameter("@ItemSpec",SqlDbType.VarChar),
							new SqlParameter("@Amount",SqlDbType.Decimal),
							new SqlParameter("@Units",SqlDbType.VarChar),
							new SqlParameter("@OrderedBy",SqlDbType.VarChar),
							new SqlParameter("@PerformedBy",SqlDbType.VarChar),
							new SqlParameter("@Costs",SqlDbType.Decimal),
							new SqlParameter("@Charges",SqlDbType.Decimal),
							new SqlParameter("@Notes",SqlDbType.VarChar),
							new SqlParameter("@VerifiedIndicator",SqlDbType.Decimal),
							new SqlParameter("@EnteredBy",SqlDbType.VarChar),
							new SqlParameter("@ClassOnReckoning",SqlDbType.VarChar),
							new SqlParameter("@InpbillItemNo",SqlDbType.Decimal),
							new SqlParameter("@EventItemNo",SqlDbType.Decimal),
							new SqlParameter("@ExchangeIndicator",SqlDbType.Decimal),
							new SqlParameter("@StorageIndicator",SqlDbType.Decimal),
							new SqlParameter("@BillAttr",SqlDbType.Decimal),
							new SqlParameter("@SupplierName",SqlDbType.VarChar),
							new SqlParameter("@BillDate",SqlDbType.DateTime),
                            new SqlParameter("@Price",SqlDbType.Decimal),
                            new SqlParameter("@Operator",SqlDbType.VarChar),
                            new SqlParameter("@ClassOnInRcpt",SqlDbType.VarChar),
                            new SqlParameter("@SubjCode",SqlDbType.VarChar),
                            new SqlParameter("@ClassOnMr",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedOperationBillItems")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OperId",SqlDbType.Decimal),
							new SqlParameter("@ItemNo",SqlDbType.Decimal),
							new SqlParameter("@ItemClass",SqlDbType.VarChar),
							new SqlParameter("@ItemName",SqlDbType.VarChar),
							new SqlParameter("@ItemCode",SqlDbType.VarChar),
							new SqlParameter("@ItemSpec",SqlDbType.VarChar),
							new SqlParameter("@Amount",SqlDbType.Decimal),
							new SqlParameter("@Units",SqlDbType.VarChar),
							new SqlParameter("@OrderedBy",SqlDbType.VarChar),
							new SqlParameter("@PerformedBy",SqlDbType.VarChar),
							new SqlParameter("@Costs",SqlDbType.Decimal),
							new SqlParameter("@Charges",SqlDbType.Decimal),
							new SqlParameter("@Notes",SqlDbType.VarChar),
							new SqlParameter("@VerifiedIndicator",SqlDbType.Decimal),
							new SqlParameter("@EnteredBy",SqlDbType.VarChar),
							new SqlParameter("@ClassOnReckoning",SqlDbType.VarChar),
							new SqlParameter("@InpbillItemNo",SqlDbType.Decimal),
							new SqlParameter("@EventItemNo",SqlDbType.Decimal),
							new SqlParameter("@ExchangeIndicator",SqlDbType.Decimal),
							new SqlParameter("@StorageIndicator",SqlDbType.Decimal),
							new SqlParameter("@BillAttr",SqlDbType.Decimal),
							new SqlParameter("@SupplierName",SqlDbType.VarChar),
							new SqlParameter("@BillDate",SqlDbType.DateTime),
                            new SqlParameter("@Price",SqlDbType.Decimal),
                            new SqlParameter("@Operator",SqlDbType.VarChar),
                            new SqlParameter("@ClassOnInRcpt",SqlDbType.VarChar),
                            new SqlParameter("@SubjCode",SqlDbType.VarChar),
                            new SqlParameter("@ClassOnMr",SqlDbType.VarChar),
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OperId",SqlDbType.Decimal),
							new SqlParameter("@ItemNo",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedOperationBillItems")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OperId",SqlDbType.Decimal),
							new SqlParameter("@ItemNo",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedOperationBillItems")
                {
                    parms = new SqlParameter[]{                            
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OperId",SqlDbType.Decimal),
                            new SqlParameter("@ItemNo",SqlDbType.Decimal),
							
                    };
                }
                else if (sqlParms == "SelectMedOperationBillItemsNo")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OperId",SqlDbType.Decimal),
							new SqlParameter("@ItemClass",SqlDbType.VarChar),
							new SqlParameter("@ItemCode",SqlDbType.VarChar),
							new SqlParameter("@ItemSpec",SqlDbType.VarChar),
							new SqlParameter("@Units",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedOperationBillItemsForIn")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OperId",SqlDbType.Decimal),
                            new SqlParameter("@billAttr",SqlDbType.Decimal),
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedOperationBillItems 
        ///Insert Table MED_OPERATION_BILL_ITEMS
        /// </summary>
        public int InsertMedOperationBillItemsSQL(MedOperationBillItems model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedOperationBillItems");
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

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_OPERATION_BILL_ITEMS_Insert_SQL, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedOperationBillItems 
        ///Update Table     MED_OPERATION_BILL_ITEMS
        /// </summary>
        public int UpdateMedOperationBillItemsSQL(MedOperationBillItems model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedOperationBillItems");
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

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_OPERATION_BILL_ITEMS_Update_SQL, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedOperationBillItems 
        ///Delete Table MED_OPERATION_BILL_ITEMS by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal ITEM_NO)
        /// </summary>
        public int DeleteMedOperationBillItemsSQL(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID, decimal ITEM_NO)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneDelete = GetParameterSQL("DeleteMedOperationBillItems");
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

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_OPERATION_BILL_ITEMS_Delete_SQL, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedOperationBillItems 
        ///select Table MED_OPERATION_BILL_ITEMS by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal ITEM_NO)
        /// </summary>
        public MedOperationBillItems SelectMedOperationBillItemsSQL(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID, decimal ITEM_NO)
        {
            MedOperationBillItems model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedOperationBillItems");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = OPER_ID;
            parameterValues[3].Value = ITEM_NO;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Select_ONE_SQL, parameterValues))
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
        public List<MedOperationBillItems> SelectMedOperationBillItemsListSQL()
        {
            List<MedOperationBillItems> modelList = new List<MedOperationBillItems>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Select_ALL_SQL, null))
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

        public List<Model.MedOperationBillItems> SelectMedOperationBillItemsNoSQL(string patientId, decimal visitId, decimal operId, string itemClass, string itemCode, string itemSpec, string units)
        {
            List<Model.MedOperationBillItems> MedOperationBillItemsList = new List<Model.MedOperationBillItems>();

            SqlParameter[] mdPats = GetParameterSQL("SelectMedOperationBillItemsNo");
            mdPats[0].Value = patientId;
            mdPats[1].Value = visitId;
            mdPats[2].Value = operId;
            mdPats[3].Value = itemClass;
            mdPats[4].Value = itemCode;
            mdPats[5].Value = itemSpec;
            mdPats[6].Value = units;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Select_No_SQL, mdPats))
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

        public List<Model.MedOperationBillItems> SelectMedOperationBillItemsForInSQL(string patientId, decimal visitId, decimal operId, decimal billAttr)
        {
            List<Model.MedOperationBillItems> MedOperationBillItemsList = new List<Model.MedOperationBillItems>();

            SqlParameter[] mdPats = GetParameterSQL("SelectMedOperationBillItemsForIn");
            mdPats[0].Value = patientId;
            mdPats[1].Value = visitId;
            mdPats[2].Value = operId;
            mdPats[3].Value = billAttr;

            StringBuilder MED_OPERATION_BILL_ITEMS_Select_SQL_ForIn = new StringBuilder();
            MED_OPERATION_BILL_ITEMS_Select_SQL_ForIn.Append(MED_OPERATION_BILL_ITEMS_Select_SQL);
            //MED_OPERATION_BILL_ITEMS_Select_SQL_ForIn.Append("and item_no in ( " + itemNoInStr + " ) ");

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Select_SQL_ForIn.ToString(), mdPats))
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
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOperationBillItems")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OperId",OracleType.Number),
							new OracleParameter(":ItemNo",OracleType.Number),
							new OracleParameter(":ItemClass",OracleType.VarChar),
							new OracleParameter(":ItemName",OracleType.VarChar),
							new OracleParameter(":ItemCode",OracleType.VarChar),
							new OracleParameter(":ItemSpec",OracleType.VarChar),
							new OracleParameter(":Amount",OracleType.Number),
							new OracleParameter(":Units",OracleType.VarChar),
							new OracleParameter(":OrderedBy",OracleType.VarChar),
							new OracleParameter(":PerformedBy",OracleType.VarChar),
							new OracleParameter(":Costs",OracleType.Number),
							new OracleParameter(":Charges",OracleType.Number),
							new OracleParameter(":Notes",OracleType.VarChar),
							new OracleParameter(":VerifiedIndicator",OracleType.Number),
							new OracleParameter(":EnteredBy",OracleType.VarChar),
							new OracleParameter(":ClassOnReckoning",OracleType.VarChar),
							new OracleParameter(":InpbillItemNo",OracleType.Number),
							new OracleParameter(":EventItemNo",OracleType.Number),
							new OracleParameter(":ExchangeIndicator",OracleType.Number),
							new OracleParameter(":StorageIndicator",OracleType.Number),
							new OracleParameter(":BillAttr",OracleType.Number),
							new OracleParameter(":SupplierName",OracleType.VarChar),
							new OracleParameter(":BillDate",OracleType.DateTime),
                            new OracleParameter(":Price",OracleType.Number),
                            new OracleParameter(":Operator",OracleType.VarChar),
                            new OracleParameter(":ClassOnInRcpt",OracleType.VarChar),
                            new OracleParameter(":SubjCode",OracleType.VarChar),
                            new OracleParameter(":ClassOnMr",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedOperationBillItems")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OperId",OracleType.Number),
							new OracleParameter(":ItemNo",OracleType.Number),
							new OracleParameter(":ItemClass",OracleType.VarChar),
							new OracleParameter(":ItemName",OracleType.VarChar),
							new OracleParameter(":ItemCode",OracleType.VarChar),
							new OracleParameter(":ItemSpec",OracleType.VarChar),
							new OracleParameter(":Amount",OracleType.Number),
							new OracleParameter(":Units",OracleType.VarChar),
							new OracleParameter(":OrderedBy",OracleType.VarChar),
							new OracleParameter(":PerformedBy",OracleType.VarChar),
							new OracleParameter(":Costs",OracleType.Number),
							new OracleParameter(":Charges",OracleType.Number),
							new OracleParameter(":Notes",OracleType.VarChar),
							new OracleParameter(":VerifiedIndicator",OracleType.Number),
							new OracleParameter(":EnteredBy",OracleType.VarChar),
							new OracleParameter(":ClassOnReckoning",OracleType.VarChar),
							new OracleParameter(":InpbillItemNo",OracleType.Number),
							new OracleParameter(":EventItemNo",OracleType.Number),
							new OracleParameter(":ExchangeIndicator",OracleType.Number),
							new OracleParameter(":StorageIndicator",OracleType.Number),
							new OracleParameter(":BillAttr",OracleType.Number),
							new OracleParameter(":SupplierName",OracleType.VarChar),
							new OracleParameter(":BillDate",OracleType.DateTime),
                            new OracleParameter(":Price",OracleType.Number),
                            new OracleParameter(":Operator",OracleType.VarChar),
                            new OracleParameter(":ClassOnInRcpt",OracleType.VarChar),
                            new OracleParameter(":SubjCode",OracleType.VarChar),
                            new OracleParameter(":ClassOnMr",OracleType.VarChar),
							new OracleParameter(":PatientId",SqlDbType.VarChar),
							new OracleParameter(":VisitId",SqlDbType.Decimal),
							new OracleParameter(":OperId",SqlDbType.Decimal),
							new OracleParameter(":ItemNo",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedOperationBillItems")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OperId",OracleType.Number),
							new OracleParameter(":ItemNo",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectMedOperationBillItems")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OperId",OracleType.Number),
							new OracleParameter(":ItemNo",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectMedOperationBillItemsNo")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OperId",OracleType.Number),
							new OracleParameter(":ItemClass",OracleType.VarChar),
							new OracleParameter(":ItemCode",OracleType.VarChar),
							new OracleParameter(":ItemSpec",OracleType.VarChar),
							new OracleParameter(":Units",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedOperationBillItemsForIn")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OperId",OracleType.Number),
							new OracleParameter(":billAttr",OracleType.Number),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedOperationBillItems 
        ///Insert Table MED_OPERATION_BILL_ITEMS
        /// </summary>
        public int InsertMedOperationBillItems(MedOperationBillItems model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedOperationBillItems");
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
                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_OPERATION_BILL_ITEMS_Insert, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedOperationBillItems 
        ///Update Table     MED_OPERATION_BILL_ITEMS
        /// </summary>
        public int UpdateMedOperationBillItems(MedOperationBillItems model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedOperationBillItems");
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

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_OPERATION_BILL_ITEMS_Update, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedOperationBillItems 
        ///Delete Table MED_OPERATION_BILL_ITEMS by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal ITEM_NO)
        /// </summary>
        public int DeleteMedOperationBillItems(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID, decimal ITEM_NO)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneDelete = GetParameter("DeleteMedOperationBillItems");
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

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_OPERATION_BILL_ITEMS_Delete, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedOperationBillItems 
        ///select Table MED_OPERATION_BILL_ITEMS by (string PATIENT_ID,decimal VISIT_ID,decimal OPER_ID,decimal ITEM_NO)
        /// </summary>
        public MedOperationBillItems SelectMedOperationBillItems(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID, decimal ITEM_NO)
        {
            MedOperationBillItems model;
            OracleParameter[] parameterValues = GetParameter("SelectMedOperationBillItems");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = OPER_ID;
            parameterValues[3].Value = ITEM_NO;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_ONE_Select, parameterValues))
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
        public List<MedOperationBillItems> SelectMedOperationBillItemsList()
        {
            List<MedOperationBillItems> modelList = new List<MedOperationBillItems>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Select_ALL, null))
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

        public List<Model.MedOperationBillItems> SelectMedOperationBillItemsNo(string patientId, decimal visitId, decimal operId, string itemClass, string itemCode, string itemSpec, string units)
        {
            List<Model.MedOperationBillItems> MedOperationBillItemsList = new List<Model.MedOperationBillItems>();

            OracleParameter[] mdPats = GetParameter("SelectMedOperationBillItemsNo");
            mdPats[0].Value = patientId;
            mdPats[1].Value = visitId;
            mdPats[2].Value = operId;
            mdPats[3].Value = itemClass;
            mdPats[4].Value = itemCode;
            mdPats[5].Value = itemSpec;
            mdPats[6].Value = units;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Select_No, mdPats))
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

        public List<Model.MedOperationBillItems> SelectMedOperationBillItemsForIn(string patientId, decimal visitId, decimal operId, decimal billAttr)
        {
            List<Model.MedOperationBillItems> MedOperationBillItemsList = new List<Model.MedOperationBillItems>();

            OracleParameter[] mdPats = GetParameter("SelectMedOperationBillItemsForIn");
            mdPats[0].Value = patientId;
            mdPats[1].Value = visitId;
            mdPats[2].Value = operId;
            mdPats[3].Value = billAttr;

            StringBuilder MED_OPERATION_BILL_ITEMS_Select_ForIn = new StringBuilder();
            MED_OPERATION_BILL_ITEMS_Select_ForIn.Append(MED_OPERATION_BILL_ITEMS_Select);
          
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_OPERATION_BILL_ITEMS_Select_ForIn.ToString(), mdPats))
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
