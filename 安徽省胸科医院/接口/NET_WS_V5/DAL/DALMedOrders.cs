

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:03:32
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
    /// DAL MedOrders
    /// </summary>

    public partial class DALMedOrders
    {

        private static readonly string MED_ORDERS_Insert_SQL = "INSERT INTO MED_ORDERS (PATIENT_ID,VISIT_ID,ORDER_NO,ORDER_SUB_NO,REPEAT_INDICATOR,ORDER_CLASS,ORDER_TEXT,ORDER_CODE,DOSAGE,DOSAGE_UNITS,ADMINISTRATION,START_DATE_TIME,STOP_DATE_TIME,DURATION,DURATION_UNITS,FREQUENCY,FREQ_COUNTER,FREQ_INTERVAL,FREQ_INTERVAL_UNIT,FREQ_DETAIL,PERFORM_SCHEDULE,PERFORM_RESULT,ORDERING_DEPT,DOCTOR,STOP_DOCTOR,NURSE,STOP_NURSE,ENTER_DATE_TIME,STOP_ORDER_DATE_TIME,ORDER_STATUS,BILLING_ATTR,LAST_PERFORM_DATE_TIME,LAST_ACCTING_DATE_TIME,DRUG_BILLING_ATTR,TREAT_SHEET_FLAG,PHAM_STD_CODE,AMOUNT,RESERVED1,DISPENSE_MEMOS,CURRENT_PRESC_NO,DRUG_SPEC,QTY) values (@PatientId,@VisitId,@OrderNo,@OrderSubNo,@RepeatIndicator,@OrderClass,@OrderText,@OrderCode,@Dosage,@DosageUnits,@Administration,@StartDateTime,@StopDateTime,@Duration,@DurationUnits,@Frequency,@FreqCounter,@FreqInterval,@FreqIntervalUnit,@FreqDetail,@PerformSchedule,@PerformResult,@OrderingDept,@Doctor,@StopDoctor,@Nurse,@StopNurse,@EnterDateTime,@StopOrderDateTime,@OrderStatus,@BillingAttr,@LastPerformDateTime,@LastAcctingDateTime,@DrugBillingAttr,@TreatSheetFlag,@PhamStdCode,@Amount,@Reserved1,@DispenseMemos,@CurrentPrescNo,@DrugSpec,@Qty)";
        private static readonly string MED_ORDERS_Update_SQL = "UPDATE MED_ORDERS SET PATIENT_ID=@PatientId,VISIT_ID=@VisitId,ORDER_NO=@OrderNo,ORDER_SUB_NO=@OrderSubNo,REPEAT_INDICATOR=@RepeatIndicator,ORDER_CLASS=@OrderClass,ORDER_TEXT=@OrderText,ORDER_CODE=@OrderCode,DOSAGE=@Dosage,DOSAGE_UNITS=@DosageUnits,ADMINISTRATION=@Administration,START_DATE_TIME=@StartDateTime,STOP_DATE_TIME=@StopDateTime,DURATION=@Duration,DURATION_UNITS=@DurationUnits,FREQUENCY=@Frequency,FREQ_COUNTER=@FreqCounter,FREQ_INTERVAL=@FreqInterval,FREQ_INTERVAL_UNIT=@FreqIntervalUnit,FREQ_DETAIL=@FreqDetail,PERFORM_SCHEDULE=@PerformSchedule,PERFORM_RESULT=@PerformResult,ORDERING_DEPT=@OrderingDept,DOCTOR=@Doctor,STOP_DOCTOR=@StopDoctor,NURSE=@Nurse,STOP_NURSE=@StopNurse,ENTER_DATE_TIME=@EnterDateTime,STOP_ORDER_DATE_TIME=@StopOrderDateTime,ORDER_STATUS=@OrderStatus,BILLING_ATTR=@BillingAttr,LAST_PERFORM_DATE_TIME=@LastPerformDateTime,LAST_ACCTING_DATE_TIME=@LastAcctingDateTime,DRUG_BILLING_ATTR=@DrugBillingAttr,TREAT_SHEET_FLAG=@TreatSheetFlag,PHAM_STD_CODE=@PhamStdCode,AMOUNT=@Amount,RESERVED1=@Reserved1,DISPENSE_MEMOS=@DispenseMemos,CURRENT_PRESC_NO=@CurrentPrescNo,DRUG_SPEC=@DrugSpec,QTY=@Qty WHERE PATIENT_ID=@PatientIdP AND VISIT_ID=@VisitIdP AND ORDER_NO=@OrderNoP AND ORDER_SUB_NO=@OrderSubNoP";
        private static readonly string MED_ORDERS_Delete_SQL = "Delete MED_ORDERS WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND ORDER_NO=@OrderNo AND ORDER_SUB_NO=@OrderSubNo";
        private static readonly string MED_ORDERS_ALL_Delete_SQL = "Delete MED_ORDERS WHERE PATIENT_ID=@PatientId AND VISIT_ID=@VisitId";
        private static readonly string MED_ORDERS_Select_SQL = "SELECT PATIENT_ID,VISIT_ID,ORDER_NO,ORDER_SUB_NO,REPEAT_INDICATOR,ORDER_CLASS,ORDER_TEXT,ORDER_CODE,DOSAGE,DOSAGE_UNITS,ADMINISTRATION,START_DATE_TIME,STOP_DATE_TIME,DURATION,DURATION_UNITS,FREQUENCY,FREQ_COUNTER,FREQ_INTERVAL,FREQ_INTERVAL_UNIT,FREQ_DETAIL,PERFORM_SCHEDULE,PERFORM_RESULT,ORDERING_DEPT,DOCTOR,STOP_DOCTOR,NURSE,STOP_NURSE,ENTER_DATE_TIME,STOP_ORDER_DATE_TIME,ORDER_STATUS,BILLING_ATTR,LAST_PERFORM_DATE_TIME,LAST_ACCTING_DATE_TIME,DRUG_BILLING_ATTR,TREAT_SHEET_FLAG,PHAM_STD_CODE,AMOUNT,RESERVED1,DISPENSE_MEMOS,CURRENT_PRESC_NO,DRUG_SPEC,QTY FROM MED_ORDERS where PATIENT_ID=@PatientId AND VISIT_ID=@VisitId AND ORDER_NO=@OrderNo AND ORDER_SUB_NO=@OrderSubNo";
        private static readonly string MED_ORDERS_Select_ALL_SQL = "SELECT PATIENT_ID,VISIT_ID,ORDER_NO,ORDER_SUB_NO,REPEAT_INDICATOR,ORDER_CLASS,ORDER_TEXT,ORDER_CODE,DOSAGE,DOSAGE_UNITS,ADMINISTRATION,START_DATE_TIME,STOP_DATE_TIME,DURATION,DURATION_UNITS,FREQUENCY,FREQ_COUNTER,FREQ_INTERVAL,FREQ_INTERVAL_UNIT,FREQ_DETAIL,PERFORM_SCHEDULE,PERFORM_RESULT,ORDERING_DEPT,DOCTOR,STOP_DOCTOR,NURSE,STOP_NURSE,ENTER_DATE_TIME,STOP_ORDER_DATE_TIME,ORDER_STATUS,BILLING_ATTR,LAST_PERFORM_DATE_TIME,LAST_ACCTING_DATE_TIME,DRUG_BILLING_ATTR,TREAT_SHEET_FLAG,PHAM_STD_CODE,AMOUNT,RESERVED1,DISPENSE_MEMOS,CURRENT_PRESC_NO,DRUG_SPEC,QTY FROM MED_ORDERS";
        private static readonly string MED_ORDERS_Insert = "INSERT INTO MED_ORDERS (PATIENT_ID,VISIT_ID,ORDER_NO,ORDER_SUB_NO,REPEAT_INDICATOR,ORDER_CLASS,ORDER_TEXT,ORDER_CODE,DOSAGE,DOSAGE_UNITS,ADMINISTRATION,START_DATE_TIME,STOP_DATE_TIME,DURATION,DURATION_UNITS,FREQUENCY,FREQ_COUNTER,FREQ_INTERVAL,FREQ_INTERVAL_UNIT,FREQ_DETAIL,PERFORM_SCHEDULE,PERFORM_RESULT,ORDERING_DEPT,DOCTOR,STOP_DOCTOR,NURSE,STOP_NURSE,ENTER_DATE_TIME,STOP_ORDER_DATE_TIME,ORDER_STATUS,BILLING_ATTR,LAST_PERFORM_DATE_TIME,LAST_ACCTING_DATE_TIME,DRUG_BILLING_ATTR,TREAT_SHEET_FLAG,PHAM_STD_CODE,AMOUNT,RESERVED1,DISPENSE_MEMOS,CURRENT_PRESC_NO,DRUG_SPEC,QTY) values (:PatientId,:VisitId,:OrderNo,:OrderSubNo,:RepeatIndicator,:OrderClass,:OrderText,:OrderCode,:Dosage,:DosageUnits,:Administration,:StartDateTime,:StopDateTime,:Duration,:DurationUnits,:Frequency,:FreqCounter,:FreqInterval,:FreqIntervalUnit,:FreqDetail,:PerformSchedule,:PerformResult,:OrderingDept,:Doctor,:StopDoctor,:Nurse,:StopNurse,:EnterDateTime,:StopOrderDateTime,:OrderStatus,:BillingAttr,:LastPerformDateTime,:LastAcctingDateTime,:DrugBillingAttr,:TreatSheetFlag,:PhamStdCode,:Amount,:Reserved1,:DispenseMemos,:CurrentPrescNo,:DrugSpec,:Qty)";
        private static readonly string MED_ORDERS_Update = "UPDATE MED_ORDERS SET PATIENT_ID=:PatientId,VISIT_ID=:VisitId,ORDER_NO=:OrderNo,ORDER_SUB_NO=:OrderSubNo,REPEAT_INDICATOR=:RepeatIndicator,ORDER_CLASS=:OrderClass,ORDER_TEXT=:OrderText,ORDER_CODE=:OrderCode,DOSAGE=:Dosage,DOSAGE_UNITS=:DosageUnits,ADMINISTRATION=:Administration,START_DATE_TIME=:StartDateTime,STOP_DATE_TIME=:StopDateTime,DURATION=:Duration,DURATION_UNITS=:DurationUnits,FREQUENCY=:Frequency,FREQ_COUNTER=:FreqCounter,FREQ_INTERVAL=:FreqInterval,FREQ_INTERVAL_UNIT=:FreqIntervalUnit,FREQ_DETAIL=:FreqDetail,PERFORM_SCHEDULE=:PerformSchedule,PERFORM_RESULT=:PerformResult,ORDERING_DEPT=:OrderingDept,DOCTOR=:Doctor,STOP_DOCTOR=:StopDoctor,NURSE=:Nurse,STOP_NURSE=:StopNurse,ENTER_DATE_TIME=:EnterDateTime,STOP_ORDER_DATE_TIME=:StopOrderDateTime,ORDER_STATUS=:OrderStatus,BILLING_ATTR=:BillingAttr,LAST_PERFORM_DATE_TIME=:LastPerformDateTime,LAST_ACCTING_DATE_TIME=:LastAcctingDateTime,DRUG_BILLING_ATTR=:DrugBillingAttr,TREAT_SHEET_FLAG=:TreatSheetFlag,PHAM_STD_CODE=:PhamStdCode,AMOUNT=:Amount,RESERVED1=:Reserved1,DISPENSE_MEMOS=:DispenseMemos,CURRENT_PRESC_NO=:CurrentPrescNo,DRUG_SPEC=:DrugSpec,QTY=:Qty WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND ORDER_NO=:OrderNo AND ORDER_SUB_NO=:OrderSubNo";
        private static readonly string MED_ORDERS_Delete = "Delete MED_ORDERS WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND ORDER_NO=:OrderNo AND ORDER_SUB_NO=:OrderSubNo";
        private static readonly string MED_ORDERS_ALL_Delete = "Delete MED_ORDERS WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId ";
        private static readonly string MED_ORDERS_Select = "SELECT PATIENT_ID,VISIT_ID,ORDER_NO,ORDER_SUB_NO,REPEAT_INDICATOR,ORDER_CLASS,ORDER_TEXT,ORDER_CODE,DOSAGE,DOSAGE_UNITS,ADMINISTRATION,START_DATE_TIME,STOP_DATE_TIME,DURATION,DURATION_UNITS,FREQUENCY,FREQ_COUNTER,FREQ_INTERVAL,FREQ_INTERVAL_UNIT,FREQ_DETAIL,PERFORM_SCHEDULE,PERFORM_RESULT,ORDERING_DEPT,DOCTOR,STOP_DOCTOR,NURSE,STOP_NURSE,ENTER_DATE_TIME,STOP_ORDER_DATE_TIME,ORDER_STATUS,BILLING_ATTR,LAST_PERFORM_DATE_TIME,LAST_ACCTING_DATE_TIME,DRUG_BILLING_ATTR,TREAT_SHEET_FLAG,PHAM_STD_CODE,AMOUNT,RESERVED1,DISPENSE_MEMOS,CURRENT_PRESC_NO,DRUG_SPEC,QTY FROM MED_ORDERS where PATIENT_ID=:PatientId AND VISIT_ID=:VisitId AND ORDER_NO=:OrderNo AND ORDER_SUB_NO=:OrderSubNo";
        private static readonly string MED_ORDERS_Select_ALL = "SELECT PATIENT_ID,VISIT_ID,ORDER_NO,ORDER_SUB_NO,REPEAT_INDICATOR,ORDER_CLASS,ORDER_TEXT,ORDER_CODE,DOSAGE,DOSAGE_UNITS,ADMINISTRATION,START_DATE_TIME,STOP_DATE_TIME,DURATION,DURATION_UNITS,FREQUENCY,FREQ_COUNTER,FREQ_INTERVAL,FREQ_INTERVAL_UNIT,FREQ_DETAIL,PERFORM_SCHEDULE,PERFORM_RESULT,ORDERING_DEPT,DOCTOR,STOP_DOCTOR,NURSE,STOP_NURSE,ENTER_DATE_TIME,STOP_ORDER_DATE_TIME,ORDER_STATUS,BILLING_ATTR,LAST_PERFORM_DATE_TIME,LAST_ACCTING_DATE_TIME,DRUG_BILLING_ATTR,TREAT_SHEET_FLAG,PHAM_STD_CODE,AMOUNT,RESERVED1,DISPENSE_MEMOS,CURRENT_PRESC_NO,DRUG_SPEC,QTY FROM MED_ORDERS";
        public DALMedOrders()
        {
        }
        #region [获取参数SQL]
        /// <summary>
        ///获取参数MedOrders SQL
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOrders")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OrderNo",SqlDbType.VarChar),
							new SqlParameter("@OrderSubNo",SqlDbType.Decimal),
							new SqlParameter("@RepeatIndicator",SqlDbType.Decimal),
							new SqlParameter("@OrderClass",SqlDbType.VarChar),
							new SqlParameter("@OrderText",SqlDbType.VarChar),
							new SqlParameter("@OrderCode",SqlDbType.VarChar),
							new SqlParameter("@Dosage",SqlDbType.Decimal),
							new SqlParameter("@DosageUnits",SqlDbType.VarChar),
							new SqlParameter("@Administration",SqlDbType.VarChar),
							new SqlParameter("@StartDateTime",SqlDbType.DateTime),
							new SqlParameter("@StopDateTime",SqlDbType.DateTime),
							new SqlParameter("@Duration",SqlDbType.Decimal),
							new SqlParameter("@DurationUnits",SqlDbType.VarChar),
							new SqlParameter("@Frequency",SqlDbType.VarChar),
							new SqlParameter("@FreqCounter",SqlDbType.Decimal),
							new SqlParameter("@FreqInterval",SqlDbType.Decimal),
							new SqlParameter("@FreqIntervalUnit",SqlDbType.VarChar),
							new SqlParameter("@FreqDetail",SqlDbType.VarChar),
							new SqlParameter("@PerformSchedule",SqlDbType.VarChar),
							new SqlParameter("@PerformResult",SqlDbType.VarChar),
							new SqlParameter("@OrderingDept",SqlDbType.VarChar),
							new SqlParameter("@Doctor",SqlDbType.VarChar),
							new SqlParameter("@StopDoctor",SqlDbType.VarChar),
							new SqlParameter("@Nurse",SqlDbType.VarChar),
							new SqlParameter("@StopNurse",SqlDbType.VarChar),
							new SqlParameter("@EnterDateTime",SqlDbType.DateTime),
							new SqlParameter("@StopOrderDateTime",SqlDbType.DateTime),
							new SqlParameter("@OrderStatus",SqlDbType.VarChar),
							new SqlParameter("@BillingAttr",SqlDbType.Decimal),
							new SqlParameter("@LastPerformDateTime",SqlDbType.DateTime),
							new SqlParameter("@LastAcctingDateTime",SqlDbType.DateTime),
							new SqlParameter("@DrugBillingAttr",SqlDbType.Decimal),
							new SqlParameter("@TreatSheetFlag",SqlDbType.VarChar),
							new SqlParameter("@PhamStdCode",SqlDbType.VarChar),
							new SqlParameter("@Amount",SqlDbType.Decimal),
							new SqlParameter("@Reserved1",SqlDbType.VarChar),
							new SqlParameter("@DispenseMemos",SqlDbType.VarChar),
							new SqlParameter("@CurrentPrescNo",SqlDbType.Decimal),
							new SqlParameter("@DrugSpec",SqlDbType.VarChar),
                            new SqlParameter("@Qty",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "UpdateMedOrders")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OrderNo",SqlDbType.VarChar),
							new SqlParameter("@OrderSubNo",SqlDbType.Decimal),
							new SqlParameter("@RepeatIndicator",SqlDbType.Decimal),
							new SqlParameter("@OrderClass",SqlDbType.VarChar),
							new SqlParameter("@OrderText",SqlDbType.VarChar),
							new SqlParameter("@OrderCode",SqlDbType.VarChar),
							new SqlParameter("@Dosage",SqlDbType.Decimal),
							new SqlParameter("@DosageUnits",SqlDbType.VarChar),
							new SqlParameter("@Administration",SqlDbType.VarChar),
							new SqlParameter("@StartDateTime",SqlDbType.DateTime),
							new SqlParameter("@StopDateTime",SqlDbType.DateTime),
							new SqlParameter("@Duration",SqlDbType.Decimal),
							new SqlParameter("@DurationUnits",SqlDbType.VarChar),
							new SqlParameter("@Frequency",SqlDbType.VarChar),
							new SqlParameter("@FreqCounter",SqlDbType.Decimal),
							new SqlParameter("@FreqInterval",SqlDbType.Decimal),
							new SqlParameter("@FreqIntervalUnit",SqlDbType.VarChar),
							new SqlParameter("@FreqDetail",SqlDbType.VarChar),
							new SqlParameter("@PerformSchedule",SqlDbType.VarChar),
							new SqlParameter("@PerformResult",SqlDbType.VarChar),
							new SqlParameter("@OrderingDept",SqlDbType.VarChar),
							new SqlParameter("@Doctor",SqlDbType.VarChar),
							new SqlParameter("@StopDoctor",SqlDbType.VarChar),
							new SqlParameter("@Nurse",SqlDbType.VarChar),
							new SqlParameter("@StopNurse",SqlDbType.VarChar),
							new SqlParameter("@EnterDateTime",SqlDbType.DateTime),
							new SqlParameter("@StopOrderDateTime",SqlDbType.DateTime),
							new SqlParameter("@OrderStatus",SqlDbType.VarChar),
							new SqlParameter("@BillingAttr",SqlDbType.Decimal),
							new SqlParameter("@LastPerformDateTime",SqlDbType.DateTime),
							new SqlParameter("@LastAcctingDateTime",SqlDbType.DateTime),
							new SqlParameter("@DrugBillingAttr",SqlDbType.Decimal),
							new SqlParameter("@TreatSheetFlag",SqlDbType.VarChar),
							new SqlParameter("@PhamStdCode",SqlDbType.VarChar),
							new SqlParameter("@Amount",SqlDbType.Decimal),
							new SqlParameter("@Reserved1",SqlDbType.VarChar),
							new SqlParameter("@DispenseMemos",SqlDbType.VarChar),
							new SqlParameter("@CurrentPrescNo",SqlDbType.Decimal),
							new SqlParameter("@DrugSpec",SqlDbType.VarChar),
                            new SqlParameter("@Qty",SqlDbType.Decimal),
							new SqlParameter("@PatientIdP",SqlDbType.VarChar),
							new SqlParameter("@VisitIdP",SqlDbType.Decimal),
							new SqlParameter("@OrderNoP",SqlDbType.VarChar),
							new SqlParameter("@OrderSubNoP",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedOrders")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OrderNo",SqlDbType.VarChar),
							new SqlParameter("@OrderSubNo",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedOrdersAll")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedOrders")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@PatientId",SqlDbType.VarChar),
							new SqlParameter("@VisitId",SqlDbType.Decimal),
							new SqlParameter("@OrderNo",SqlDbType.VarChar),
							new SqlParameter("@OrderSubNo",SqlDbType.Decimal),
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedOrders 
        ///Insert Table MED_ORDERS
        /// </summary>
        public int InsertMedOrdersSQL(MedOrders model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedOrders");
                if (model.PatientId != null)
                    oneInert[0].Value = model.PatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneInert[1].Value = model.VisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.OrderNo.ToString() != null)
                    oneInert[2].Value = model.OrderNo;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.OrderSubNo.ToString() != null)
                    oneInert[3].Value = model.OrderSubNo;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.RepeatIndicator.ToString() != null)
                    oneInert[4].Value = model.RepeatIndicator;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.OrderClass != null)
                    oneInert[5].Value = model.OrderClass;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.OrderText != null)
                    oneInert[6].Value = model.OrderText;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.OrderCode != null)
                    oneInert[7].Value = model.OrderCode;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.Dosage.ToString() != null)
                    oneInert[8].Value = model.Dosage;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.DosageUnits != null)
                    oneInert[9].Value = model.DosageUnits;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.Administration != null)
                    oneInert[10].Value = model.Administration;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.StartDateTime > DateTime.MinValue)
                    oneInert[11].Value = model.StartDateTime;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.StopDateTime > DateTime.MinValue)
                    oneInert[12].Value = model.StopDateTime;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.Duration.ToString() != null)
                    oneInert[13].Value = model.Duration;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.DurationUnits != null)
                    oneInert[14].Value = model.DurationUnits;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.Frequency != null)
                    oneInert[15].Value = model.Frequency;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.FreqCounter.ToString() != null)
                    oneInert[16].Value = model.FreqCounter;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.FreqInterval.ToString() != null)
                    oneInert[17].Value = model.FreqInterval;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.FreqIntervalUnit != null)
                    oneInert[18].Value = model.FreqIntervalUnit;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.FreqDetail != null)
                    oneInert[19].Value = model.FreqDetail;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.PerformSchedule != null)
                    oneInert[20].Value = model.PerformSchedule;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.PerformResult != null)
                    oneInert[21].Value = model.PerformResult;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.OrderingDept != null)
                    oneInert[22].Value = model.OrderingDept;
                else
                    oneInert[22].Value = DBNull.Value;
                if (model.Doctor != null)
                    oneInert[23].Value = model.Doctor;
                else
                    oneInert[23].Value = DBNull.Value;
                if (model.StopDoctor != null)
                    oneInert[24].Value = model.StopDoctor;
                else
                    oneInert[24].Value = DBNull.Value;
                if (model.Nurse != null)
                    oneInert[25].Value = model.Nurse;
                else
                    oneInert[25].Value = DBNull.Value;
                if (model.StopNurse != null)
                    oneInert[26].Value = model.StopNurse;
                else
                    oneInert[26].Value = DBNull.Value;
                if (model.EnterDateTime > DateTime.MinValue)
                    oneInert[27].Value = model.EnterDateTime;
                else
                    oneInert[27].Value = DBNull.Value;
                if (model.StopOrderDateTime > DateTime.MinValue)
                    oneInert[28].Value = model.StopOrderDateTime;
                else
                    oneInert[28].Value = DBNull.Value;
                if (model.OrderStatus != null)
                    oneInert[29].Value = model.OrderStatus;
                else
                    oneInert[29].Value = DBNull.Value;
                if (model.BillingAttr.ToString() != null)
                    oneInert[30].Value = model.BillingAttr;
                else
                    oneInert[30].Value = DBNull.Value;
                if (model.LastPerformDateTime > DateTime.MinValue)
                    oneInert[31].Value = model.LastPerformDateTime;
                else
                    oneInert[31].Value = DBNull.Value;
                if (model.LastAcctingDateTime > DateTime.MinValue)
                    oneInert[32].Value = model.LastAcctingDateTime;
                else
                    oneInert[32].Value = DBNull.Value;
                if (model.DrugBillingAttr.ToString() != null)
                    oneInert[33].Value = model.DrugBillingAttr;
                else
                    oneInert[33].Value = DBNull.Value;
                if (model.TreatSheetFlag != null)
                    oneInert[34].Value = model.TreatSheetFlag;
                else
                    oneInert[34].Value = DBNull.Value;
                if (model.PhamStdCode != null)
                    oneInert[35].Value = model.PhamStdCode;
                else
                    oneInert[35].Value = DBNull.Value;
                if (model.Amount.ToString() != null)
                    oneInert[36].Value = model.Amount;
                else
                    oneInert[36].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneInert[37].Value = model.Reserved1;
                else
                    oneInert[37].Value = DBNull.Value;
                if (model.DispenseMemos != null)
                    oneInert[38].Value = model.DispenseMemos;
                else
                    oneInert[38].Value = DBNull.Value;
                if (model.CurrentPrescNo.ToString() != null)
                    oneInert[39].Value = model.CurrentPrescNo;
                else
                    oneInert[39].Value = DBNull.Value;
                if (model.DrugSpec != null)
                    oneInert[40].Value = model.DrugSpec;
                else
                    oneInert[40].Value = DBNull.Value;
                if (model.Qty.ToString() != null)
                    oneInert[41].Value = model.Qty;
                else
                    oneInert[41].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_ORDERS_Insert_SQL, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedOrders 
        ///Update Table     MED_ORDERS
        /// </summary>
        public int UpdateMedOrdersSQL(MedOrders model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedOrders");
                if (model.PatientId != null)
                    oneUpdate[0].Value = model.PatientId;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneUpdate[1].Value = model.VisitId;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.OrderNo.ToString() != null)
                    oneUpdate[2].Value = model.OrderNo;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.OrderSubNo.ToString() != null)
                    oneUpdate[3].Value = model.OrderSubNo;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.RepeatIndicator.ToString() != null)
                    oneUpdate[4].Value = model.RepeatIndicator;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.OrderClass != null)
                    oneUpdate[5].Value = model.OrderClass;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.OrderText != null)
                    oneUpdate[6].Value = model.OrderText;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.OrderCode != null)
                    oneUpdate[7].Value = model.OrderCode;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.Dosage.ToString() != null)
                    oneUpdate[8].Value = model.Dosage;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.DosageUnits != null)
                    oneUpdate[9].Value = model.DosageUnits;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.Administration != null)
                    oneUpdate[10].Value = model.Administration;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.StartDateTime > DateTime.MinValue)
                    oneUpdate[11].Value = model.StartDateTime;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.StopDateTime > DateTime.MinValue)
                    oneUpdate[12].Value = model.StopDateTime;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.Duration.ToString() != null)
                    oneUpdate[13].Value = model.Duration;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.DurationUnits != null)
                    oneUpdate[14].Value = model.DurationUnits;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.Frequency != null)
                    oneUpdate[15].Value = model.Frequency;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.FreqCounter.ToString() != null)
                    oneUpdate[16].Value = model.FreqCounter;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.FreqInterval.ToString() != null)
                    oneUpdate[17].Value = model.FreqInterval;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.FreqIntervalUnit != null)
                    oneUpdate[18].Value = model.FreqIntervalUnit;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.FreqDetail != null)
                    oneUpdate[19].Value = model.FreqDetail;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.PerformSchedule != null)
                    oneUpdate[20].Value = model.PerformSchedule;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.PerformResult != null)
                    oneUpdate[21].Value = model.PerformResult;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.OrderingDept != null)
                    oneUpdate[22].Value = model.OrderingDept;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.Doctor != null)
                    oneUpdate[23].Value = model.Doctor;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.StopDoctor != null)
                    oneUpdate[24].Value = model.StopDoctor;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.Nurse != null)
                    oneUpdate[25].Value = model.Nurse;
                else
                    oneUpdate[25].Value = DBNull.Value;
                if (model.StopNurse != null)
                    oneUpdate[26].Value = model.StopNurse;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (model.EnterDateTime > DateTime.MinValue)
                    oneUpdate[27].Value = model.EnterDateTime;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (model.StopOrderDateTime > DateTime.MinValue)
                    oneUpdate[28].Value = model.StopOrderDateTime;
                else
                    oneUpdate[28].Value = DBNull.Value;
                if (model.OrderStatus != null)
                    oneUpdate[29].Value = model.OrderStatus;
                else
                    oneUpdate[29].Value = DBNull.Value;
                if (model.BillingAttr.ToString() != null)
                    oneUpdate[30].Value = model.BillingAttr;
                else
                    oneUpdate[30].Value = DBNull.Value;
                if (model.LastPerformDateTime > DateTime.MinValue)
                    oneUpdate[31].Value = model.LastPerformDateTime;
                else
                    oneUpdate[31].Value = DBNull.Value;
                if (model.LastAcctingDateTime > DateTime.MinValue)
                    oneUpdate[32].Value = model.LastAcctingDateTime;
                else
                    oneUpdate[32].Value = DBNull.Value;
                if (model.DrugBillingAttr.ToString() != null)
                    oneUpdate[33].Value = model.DrugBillingAttr;
                else
                    oneUpdate[33].Value = DBNull.Value;
                if (model.TreatSheetFlag != null)
                    oneUpdate[34].Value = model.TreatSheetFlag;
                else
                    oneUpdate[34].Value = DBNull.Value;
                if (model.PhamStdCode != null)
                    oneUpdate[35].Value = model.PhamStdCode;
                else
                    oneUpdate[35].Value = DBNull.Value;
                if (model.Amount.ToString() != null)
                    oneUpdate[36].Value = model.Amount;
                else
                    oneUpdate[36].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneUpdate[37].Value = model.Reserved1;
                else
                    oneUpdate[37].Value = DBNull.Value;
                if (model.DispenseMemos != null)
                    oneUpdate[38].Value = model.DispenseMemos;
                else
                    oneUpdate[38].Value = DBNull.Value;
                if (model.CurrentPrescNo.ToString() != null)
                    oneUpdate[39].Value = model.CurrentPrescNo;
                else
                    oneUpdate[39].Value = DBNull.Value;
                if (model.DrugSpec != null)
                    oneUpdate[40].Value = model.DrugSpec;
                else
                    oneUpdate[40].Value = DBNull.Value;
                if (model.Qty.ToString() != null)
                    oneUpdate[41].Value = model.Qty;
                else
                    oneUpdate[41].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[42].Value = model.PatientId;
                else
                    oneUpdate[42].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneUpdate[43].Value = model.VisitId;
                else
                    oneUpdate[43].Value = DBNull.Value;
                if (model.OrderNo != null)
                    oneUpdate[44].Value = model.OrderNo;
                else
                    oneUpdate[44].Value = DBNull.Value;
                if (model.OrderSubNo.ToString() != null)
                    oneUpdate[45].Value = model.OrderSubNo;
                else
                    oneUpdate[45].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_ORDERS_Update_SQL, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedOrders 
        ///Delete Table MED_ORDERS by (string PATIENT_ID,decimal VISIT_ID,decimal ORDER_NO,decimal ORDER_SUB_NO)
        /// </summary>
        public int DeleteMedOrdersSQL(string PATIENT_ID, decimal VISIT_ID, string ORDER_NO, decimal ORDER_SUB_NO)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneDelete = GetParameterSQL("DeleteMedOrders");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (VISIT_ID.ToString() != null)
                    oneDelete[1].Value = VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (ORDER_NO.ToString() != null)
                    oneDelete[2].Value = ORDER_NO;
                else
                    oneDelete[2].Value = DBNull.Value;
                if (ORDER_SUB_NO.ToString() != null)
                    oneDelete[3].Value = ORDER_SUB_NO;
                else
                    oneDelete[3].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_ORDERS_Delete_SQL, oneDelete);
            }
        }
        #endregion
        #region [删除所有记录SQL]
        /// <summary>
        ///Delete    model  MedOrders 
        ///Delete Table MED_ORDERS by (string PATIENT_ID,decimal VISIT_ID,decimal ORDER_NO,decimal ORDER_SUB_NO)
        /// </summary>
        public int DeleteMedOrdersSQL(string PATIENT_ID, decimal VISIT_ID)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneDelete = GetParameterSQL("DeleteMedOrdersAll");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (VISIT_ID.ToString() != null)
                    oneDelete[1].Value = VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_ORDERS_ALL_Delete_SQL, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedOrders 
        ///select Table MED_ORDERS by (string PATIENT_ID,decimal VISIT_ID,decimal ORDER_NO,decimal ORDER_SUB_NO)
        /// </summary>
        public MedOrders SelectMedOrdersSQL(string PATIENT_ID, decimal VISIT_ID, string ORDER_NO, decimal ORDER_SUB_NO)
        {
            MedOrders model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedOrders");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = ORDER_NO;
            parameterValues[3].Value = ORDER_SUB_NO;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_ORDERS_Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedOrders();
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
                        model.OrderNo = oleReader["ORDER_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OrderSubNo = decimal.Parse(oleReader["ORDER_SUB_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.RepeatIndicator = decimal.Parse(oleReader["REPEAT_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OrderClass = oleReader["ORDER_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OrderText = oleReader["ORDER_TEXT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.OrderCode = oleReader["ORDER_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Dosage = decimal.Parse(oleReader["DOSAGE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.DosageUnits = oleReader["DOSAGE_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Administration = oleReader["ADMINISTRATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.StartDateTime = DateTime.Parse(oleReader["START_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.StopDateTime = DateTime.Parse(oleReader["STOP_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Duration = decimal.Parse(oleReader["DURATION"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.DurationUnits = oleReader["DURATION_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.Frequency = oleReader["FREQUENCY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.FreqCounter = decimal.Parse(oleReader["FREQ_COUNTER"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.FreqInterval = decimal.Parse(oleReader["FREQ_INTERVAL"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.FreqIntervalUnit = oleReader["FREQ_INTERVAL_UNIT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.FreqDetail = oleReader["FREQ_DETAIL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.PerformSchedule = oleReader["PERFORM_SCHEDULE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.PerformResult = oleReader["PERFORM_RESULT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.OrderingDept = oleReader["ORDERING_DEPT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Doctor = oleReader["DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.StopDoctor = oleReader["STOP_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Nurse = oleReader["NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.StopNurse = oleReader["STOP_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.EnterDateTime = DateTime.Parse(oleReader["ENTER_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.StopOrderDateTime = DateTime.Parse(oleReader["STOP_ORDER_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.OrderStatus = oleReader["ORDER_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.BillingAttr = decimal.Parse(oleReader["BILLING_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.LastPerformDateTime = DateTime.Parse(oleReader["LAST_PERFORM_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.LastAcctingDateTime = DateTime.Parse(oleReader["LAST_ACCTING_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.DrugBillingAttr = decimal.Parse(oleReader["DRUG_BILLING_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.TreatSheetFlag = oleReader["TREAT_SHEET_FLAG"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.PhamStdCode = oleReader["PHAM_STD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.Amount = decimal.Parse(oleReader["AMOUNT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.DispenseMemos = oleReader["DISPENSE_MEMOS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.CurrentPrescNo = decimal.Parse(oleReader["CURRENT_PRESC_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.DrugSpec = oleReader["DRUG_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.Qty = decimal.Parse(oleReader["QTY"].ToString().Trim());
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
        public List<MedOrders> SelectMedOrdersListSQL()
        {
            List<MedOrders> modelList = new List<MedOrders>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_ORDERS_Select_ALL_SQL, null))
            {
                while (oleReader.Read())
                {
                    MedOrders model = new MedOrders();
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
                        model.OrderNo = oleReader["ORDER_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OrderSubNo = decimal.Parse(oleReader["ORDER_SUB_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.RepeatIndicator = decimal.Parse(oleReader["REPEAT_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OrderClass = oleReader["ORDER_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OrderText = oleReader["ORDER_TEXT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.OrderCode = oleReader["ORDER_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Dosage = decimal.Parse(oleReader["DOSAGE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.DosageUnits = oleReader["DOSAGE_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Administration = oleReader["ADMINISTRATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.StartDateTime = DateTime.Parse(oleReader["START_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.StopDateTime = DateTime.Parse(oleReader["STOP_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Duration = decimal.Parse(oleReader["DURATION"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.DurationUnits = oleReader["DURATION_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.Frequency = oleReader["FREQUENCY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.FreqCounter = decimal.Parse(oleReader["FREQ_COUNTER"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.FreqInterval = decimal.Parse(oleReader["FREQ_INTERVAL"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.FreqIntervalUnit = oleReader["FREQ_INTERVAL_UNIT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.FreqDetail = oleReader["FREQ_DETAIL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.PerformSchedule = oleReader["PERFORM_SCHEDULE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.PerformResult = oleReader["PERFORM_RESULT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.OrderingDept = oleReader["ORDERING_DEPT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Doctor = oleReader["DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.StopDoctor = oleReader["STOP_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Nurse = oleReader["NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.StopNurse = oleReader["STOP_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.EnterDateTime = DateTime.Parse(oleReader["ENTER_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.StopOrderDateTime = DateTime.Parse(oleReader["STOP_ORDER_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.OrderStatus = oleReader["ORDER_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.BillingAttr = decimal.Parse(oleReader["BILLING_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.LastPerformDateTime = DateTime.Parse(oleReader["LAST_PERFORM_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.LastAcctingDateTime = DateTime.Parse(oleReader["LAST_ACCTING_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.DrugBillingAttr = decimal.Parse(oleReader["DRUG_BILLING_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.TreatSheetFlag = oleReader["TREAT_SHEET_FLAG"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.PhamStdCode = oleReader["PHAM_STD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.Amount = decimal.Parse(oleReader["AMOUNT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.DispenseMemos = oleReader["DISPENSE_MEMOS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.CurrentPrescNo = decimal.Parse(oleReader["CURRENT_PRESC_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.DrugSpec = oleReader["DRUG_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.Qty = decimal.Parse(oleReader["QTY"].ToString().Trim());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region [获取参数]
        /// <summary>
        ///获取参数MedOrders
        /// </summary>
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedOrders")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OrderNo",OracleType.VarChar),
							new OracleParameter(":OrderSubNo",OracleType.Number),
							new OracleParameter(":RepeatIndicator",OracleType.Number),
							new OracleParameter(":OrderClass",OracleType.VarChar),
							new OracleParameter(":OrderText",OracleType.VarChar),
							new OracleParameter(":OrderCode",OracleType.VarChar),
							new OracleParameter(":Dosage",OracleType.Number),
							new OracleParameter(":DosageUnits",OracleType.VarChar),
							new OracleParameter(":Administration",OracleType.VarChar),
							new OracleParameter(":StartDateTime",OracleType.DateTime),
							new OracleParameter(":StopDateTime",OracleType.DateTime),
							new OracleParameter(":Duration",OracleType.Number),
							new OracleParameter(":DurationUnits",OracleType.VarChar),
							new OracleParameter(":Frequency",OracleType.VarChar),
							new OracleParameter(":FreqCounter",OracleType.Number),
							new OracleParameter(":FreqInterval",OracleType.Number),
							new OracleParameter(":FreqIntervalUnit",OracleType.VarChar),
							new OracleParameter(":FreqDetail",OracleType.VarChar),
							new OracleParameter(":PerformSchedule",OracleType.VarChar),
							new OracleParameter(":PerformResult",OracleType.VarChar),
							new OracleParameter(":OrderingDept",OracleType.VarChar),
							new OracleParameter(":Doctor",OracleType.VarChar),
							new OracleParameter(":StopDoctor",OracleType.VarChar),
							new OracleParameter(":Nurse",OracleType.VarChar),
							new OracleParameter(":StopNurse",OracleType.VarChar),
							new OracleParameter(":EnterDateTime",OracleType.DateTime),
							new OracleParameter(":StopOrderDateTime",OracleType.DateTime),
							new OracleParameter(":OrderStatus",OracleType.VarChar),
							new OracleParameter(":BillingAttr",OracleType.Number),
							new OracleParameter(":LastPerformDateTime",OracleType.DateTime),
							new OracleParameter(":LastAcctingDateTime",OracleType.DateTime),
							new OracleParameter(":DrugBillingAttr",OracleType.Number),
							new OracleParameter(":TreatSheetFlag",OracleType.VarChar),
							new OracleParameter(":PhamStdCode",OracleType.VarChar),
							new OracleParameter(":Amount",OracleType.Number),
							new OracleParameter(":Reserved1",OracleType.VarChar),
							new OracleParameter(":DispenseMemos",OracleType.VarChar),
							new OracleParameter(":CurrentPrescNo",OracleType.Number),
							new OracleParameter(":DrugSpec",OracleType.VarChar),
                            new OracleParameter(":Qty",OracleType.Number),
                    };
                }
                else if (sqlParms == "UpdateMedOrders")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OrderNo",OracleType.VarChar),
							new OracleParameter(":OrderSubNo",OracleType.Number),
							new OracleParameter(":RepeatIndicator",OracleType.Number),
							new OracleParameter(":OrderClass",OracleType.VarChar),
							new OracleParameter(":OrderText",OracleType.VarChar),
							new OracleParameter(":OrderCode",OracleType.VarChar),
							new OracleParameter(":Dosage",OracleType.Number),
							new OracleParameter(":DosageUnits",OracleType.VarChar),
							new OracleParameter(":Administration",OracleType.VarChar),
							new OracleParameter(":StartDateTime",OracleType.DateTime),
							new OracleParameter(":StopDateTime",OracleType.DateTime),
							new OracleParameter(":Duration",OracleType.Number),
							new OracleParameter(":DurationUnits",OracleType.VarChar),
							new OracleParameter(":Frequency",OracleType.VarChar),
							new OracleParameter(":FreqCounter",OracleType.Number),
							new OracleParameter(":FreqInterval",OracleType.Number),
							new OracleParameter(":FreqIntervalUnit",OracleType.VarChar),
							new OracleParameter(":FreqDetail",OracleType.VarChar),
							new OracleParameter(":PerformSchedule",OracleType.VarChar),
							new OracleParameter(":PerformResult",OracleType.VarChar),
							new OracleParameter(":OrderingDept",OracleType.VarChar),
							new OracleParameter(":Doctor",OracleType.VarChar),
							new OracleParameter(":StopDoctor",OracleType.VarChar),
							new OracleParameter(":Nurse",OracleType.VarChar),
							new OracleParameter(":StopNurse",OracleType.VarChar),
							new OracleParameter(":EnterDateTime",OracleType.DateTime),
							new OracleParameter(":StopOrderDateTime",OracleType.DateTime),
							new OracleParameter(":OrderStatus",OracleType.VarChar),
							new OracleParameter(":BillingAttr",OracleType.Number),
							new OracleParameter(":LastPerformDateTime",OracleType.DateTime),
							new OracleParameter(":LastAcctingDateTime",OracleType.DateTime),
							new OracleParameter(":DrugBillingAttr",OracleType.Number),
							new OracleParameter(":TreatSheetFlag",OracleType.VarChar),
							new OracleParameter(":PhamStdCode",OracleType.VarChar),
							new OracleParameter(":Amount",OracleType.Number),
							new OracleParameter(":Reserved1",OracleType.VarChar),
							new OracleParameter(":DispenseMemos",OracleType.VarChar),
							new OracleParameter(":CurrentPrescNo",OracleType.Number),
							new OracleParameter(":DrugSpec",OracleType.VarChar),
                            new OracleParameter(":Qty",OracleType.Number),
							new OracleParameter(":PatientId",SqlDbType.VarChar),
							new OracleParameter(":VisitId",SqlDbType.Decimal),
							new OracleParameter(":OrderNo",SqlDbType.VarChar),
							new OracleParameter(":OrderSubNo",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedOrders")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OrderNo",OracleType.VarChar),
							new OracleParameter(":OrderSubNo",OracleType.Number),
                    };
                }
                else if (sqlParms == "DeleteMedOrdersAll")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
                    };
                }
                else if (sqlParms == "SelectMedOrders")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":PatientId",OracleType.VarChar),
							new OracleParameter(":VisitId",OracleType.Number),
							new OracleParameter(":OrderNo",OracleType.VarChar),
							new OracleParameter(":OrderSubNo",OracleType.Number),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
         #region [添加一条记录]
        /// <summary>
        ///添加一条记录Add    model  MedOrders 
        ///Insert Table MED_ORDERS
        /// </summary>
        /// <param name="model">医嘱的强类型</param>
        public int InsertMedOrders(MedOrders model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedOrders");
                if (model.PatientId != null)
                    oneInert[0].Value = model.PatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneInert[1].Value = model.VisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.OrderNo.ToString() != null)
                    oneInert[2].Value = model.OrderNo;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.OrderSubNo.ToString() != null)
                    oneInert[3].Value = model.OrderSubNo;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.RepeatIndicator.ToString() != null)
                    oneInert[4].Value = model.RepeatIndicator;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.OrderClass != null)
                    oneInert[5].Value = model.OrderClass;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.OrderText != null)
                    oneInert[6].Value = model.OrderText;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.OrderCode != null)
                    oneInert[7].Value = model.OrderCode;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.Dosage.ToString() != null)
                    oneInert[8].Value = model.Dosage;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.DosageUnits != null)
                    oneInert[9].Value = model.DosageUnits;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.Administration != null)
                    oneInert[10].Value = model.Administration;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.StartDateTime.HasValue)
                    oneInert[11].Value = model.StartDateTime;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.StopDateTime.HasValue)
                    oneInert[12].Value = model.StopDateTime;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.Duration.ToString() != null)
                    oneInert[13].Value = model.Duration;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.DurationUnits != null)
                    oneInert[14].Value = model.DurationUnits;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.Frequency != null)
                    oneInert[15].Value = model.Frequency;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.FreqCounter.ToString() != null)
                    oneInert[16].Value = model.FreqCounter;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.FreqInterval.ToString() != null)
                    oneInert[17].Value = model.FreqInterval;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.FreqIntervalUnit != null)
                    oneInert[18].Value = model.FreqIntervalUnit;
                else
                    oneInert[18].Value = DBNull.Value;
                if (model.FreqDetail != null)
                    oneInert[19].Value = model.FreqDetail;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.PerformSchedule != null)
                    oneInert[20].Value = model.PerformSchedule;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.PerformResult != null)
                    oneInert[21].Value = model.PerformResult;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.OrderingDept != null)
                    oneInert[22].Value = model.OrderingDept;
                else
                    oneInert[22].Value = DBNull.Value;
                if (model.Doctor != null)
                    oneInert[23].Value = model.Doctor;
                else
                    oneInert[23].Value = DBNull.Value;
                if (model.StopDoctor != null)
                    oneInert[24].Value = model.StopDoctor;
                else
                    oneInert[24].Value = DBNull.Value;
                if (model.Nurse != null)
                    oneInert[25].Value = model.Nurse;
                else
                    oneInert[25].Value = DBNull.Value;
                if (model.StopNurse != null)
                    oneInert[26].Value = model.StopNurse;
                else
                    oneInert[26].Value = DBNull.Value;
                if (model.EnterDateTime > DateTime.MinValue)
                    oneInert[27].Value = model.EnterDateTime;
                else
                    oneInert[27].Value = DBNull.Value;
                if (model.StopOrderDateTime > DateTime.MinValue)
                    oneInert[28].Value = model.StopOrderDateTime;
                else
                    oneInert[28].Value = DBNull.Value;
                if (model.OrderStatus != null)
                    oneInert[29].Value = model.OrderStatus;
                else
                    oneInert[29].Value = DBNull.Value;
                if (model.BillingAttr.ToString() != null)
                    oneInert[30].Value = model.BillingAttr;
                else
                    oneInert[30].Value = DBNull.Value;
                if (model.LastPerformDateTime > DateTime.MinValue)
                    oneInert[31].Value = model.LastPerformDateTime;
                else
                    oneInert[31].Value = DBNull.Value;
                if (model.LastAcctingDateTime > DateTime.MinValue)
                    oneInert[32].Value = model.LastAcctingDateTime;
                else
                    oneInert[32].Value = DBNull.Value;
                if (model.DrugBillingAttr.ToString() != null)
                    oneInert[33].Value = model.DrugBillingAttr;
                else
                    oneInert[33].Value = DBNull.Value;
                if (model.TreatSheetFlag != null)
                    oneInert[34].Value = model.TreatSheetFlag;
                else
                    oneInert[34].Value = DBNull.Value;
                if (model.PhamStdCode != null)
                    oneInert[35].Value = model.PhamStdCode;
                else
                    oneInert[35].Value = DBNull.Value;
                if (model.Amount.ToString() != null)
                    oneInert[36].Value = model.Amount;
                else
                    oneInert[36].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneInert[37].Value = model.Reserved1;
                else
                    oneInert[37].Value = DBNull.Value;
                if (model.DispenseMemos != null)
                    oneInert[38].Value = model.DispenseMemos;
                else
                    oneInert[38].Value = DBNull.Value;
                if (model.CurrentPrescNo.ToString() != null)
                    oneInert[39].Value = model.CurrentPrescNo;
                else
                    oneInert[39].Value = DBNull.Value;
                if (model.DrugSpec != null)
                    oneInert[40].Value = model.DrugSpec;
                else
                    oneInert[40].Value = DBNull.Value;
                if (model.Qty.ToString() != null)
                    oneInert[41].Value = model.Qty;
                else
                    oneInert[41].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_ORDERS_Insert, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedOrders 
        ///Update Table     MED_ORDERS
        /// </summary>
        public int UpdateMedOrders(MedOrders model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedOrders");
                if (model.PatientId != null)
                    oneUpdate[0].Value = model.PatientId;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneUpdate[1].Value = model.VisitId;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.OrderNo.ToString() != null)
                    oneUpdate[2].Value = model.OrderNo;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.OrderSubNo.ToString() != null)
                    oneUpdate[3].Value = model.OrderSubNo;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.RepeatIndicator.ToString() != null)
                    oneUpdate[4].Value = model.RepeatIndicator;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.OrderClass != null)
                    oneUpdate[5].Value = model.OrderClass;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.OrderText != null)
                    oneUpdate[6].Value = model.OrderText;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.OrderCode != null)
                    oneUpdate[7].Value = model.OrderCode;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.Dosage.ToString() != null)
                    oneUpdate[8].Value = model.Dosage;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.DosageUnits != null)
                    oneUpdate[9].Value = model.DosageUnits;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.Administration != null)
                    oneUpdate[10].Value = model.Administration;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.StartDateTime.HasValue) 
                    oneUpdate[11].Value = model.StartDateTime.Value;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.StopDateTime.HasValue)
                    oneUpdate[12].Value = model.StopDateTime.Value;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.Duration.ToString() != null)
                    oneUpdate[13].Value = model.Duration;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.DurationUnits != null)
                    oneUpdate[14].Value = model.DurationUnits;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.Frequency != null)
                    oneUpdate[15].Value = model.Frequency;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (model.FreqCounter.ToString() != null)
                    oneUpdate[16].Value = model.FreqCounter;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (model.FreqInterval.ToString() != null)
                    oneUpdate[17].Value = model.FreqInterval;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (model.FreqIntervalUnit != null)
                    oneUpdate[18].Value = model.FreqIntervalUnit;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (model.FreqDetail != null)
                    oneUpdate[19].Value = model.FreqDetail;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (model.PerformSchedule != null)
                    oneUpdate[20].Value = model.PerformSchedule;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (model.PerformResult != null)
                    oneUpdate[21].Value = model.PerformResult;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (model.OrderingDept != null)
                    oneUpdate[22].Value = model.OrderingDept;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (model.Doctor != null)
                    oneUpdate[23].Value = model.Doctor;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (model.StopDoctor != null)
                    oneUpdate[24].Value = model.StopDoctor;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (model.Nurse != null)
                    oneUpdate[25].Value = model.Nurse;
                else
                    oneUpdate[25].Value = DBNull.Value;
                if (model.StopNurse != null)
                    oneUpdate[26].Value = model.StopNurse;
                else
                    oneUpdate[26].Value = DBNull.Value;
                if (model.EnterDateTime > DateTime.MinValue)
                    oneUpdate[27].Value = model.EnterDateTime;
                else
                    oneUpdate[27].Value = DBNull.Value;
                if (model.StopOrderDateTime > DateTime.MinValue)
                    oneUpdate[28].Value = model.StopOrderDateTime;
                else
                    oneUpdate[28].Value = DBNull.Value;
                if (model.OrderStatus != null)
                    oneUpdate[29].Value = model.OrderStatus;
                else
                    oneUpdate[29].Value = DBNull.Value;
                if (model.BillingAttr.ToString() != null)
                    oneUpdate[30].Value = model.BillingAttr;
                else
                    oneUpdate[30].Value = DBNull.Value;
                if (model.LastPerformDateTime > DateTime.MinValue)
                    oneUpdate[31].Value = model.LastPerformDateTime;
                else
                    oneUpdate[31].Value = DBNull.Value;
                if (model.LastAcctingDateTime > DateTime.MinValue)
                    oneUpdate[32].Value = model.LastAcctingDateTime;
                else
                    oneUpdate[32].Value = DBNull.Value;
                if (model.DrugBillingAttr.ToString() != null)
                    oneUpdate[33].Value = model.DrugBillingAttr;
                else
                    oneUpdate[33].Value = DBNull.Value;
                if (model.TreatSheetFlag != null)
                    oneUpdate[34].Value = model.TreatSheetFlag;
                else
                    oneUpdate[34].Value = DBNull.Value;
                if (model.PhamStdCode != null)
                    oneUpdate[35].Value = model.PhamStdCode;
                else
                    oneUpdate[35].Value = DBNull.Value;
                if (model.Amount.ToString() != null)
                    oneUpdate[36].Value = model.Amount;
                else
                    oneUpdate[36].Value = DBNull.Value;
                if (model.Reserved1 != null)
                    oneUpdate[37].Value = model.Reserved1;
                else
                    oneUpdate[37].Value = DBNull.Value;
                if (model.DispenseMemos != null)
                    oneUpdate[38].Value = model.DispenseMemos;
                else
                    oneUpdate[38].Value = DBNull.Value;
                if (model.CurrentPrescNo.ToString() != null)
                    oneUpdate[39].Value = model.CurrentPrescNo;
                else
                    oneUpdate[39].Value = DBNull.Value;
                if (model.DrugSpec != null)
                    oneUpdate[40].Value = model.DrugSpec;
                else
                    oneUpdate[40].Value = DBNull.Value;
                if (model.Qty.ToString() != null)
                    oneUpdate[41].Value = model.Qty;
                else
                    oneUpdate[41].Value = DBNull.Value;
                if (model.PatientId != null)
                    oneUpdate[42].Value = model.PatientId;
                else
                    oneUpdate[42].Value = DBNull.Value;
                if (model.VisitId.ToString() != null)
                    oneUpdate[43].Value = model.VisitId;
                else
                    oneUpdate[43].Value = DBNull.Value;
                if (model.OrderNo != null)
                    oneUpdate[44].Value = model.OrderNo;
                else
                    oneUpdate[44].Value = DBNull.Value;
                if (model.OrderSubNo.ToString() != null)
                    oneUpdate[45].Value = model.OrderSubNo;
                else
                    oneUpdate[45].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_ORDERS_Update, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedOrders 
        ///Delete Table MED_ORDERS by (string PATIENT_ID,decimal VISIT_ID,decimal ORDER_NO,decimal ORDER_SUB_NO)
        /// </summary>
        public int DeleteMedOrders(string PATIENT_ID, decimal VISIT_ID, string ORDER_NO, decimal ORDER_SUB_NO)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneDelete = GetParameter("DeleteMedOrders");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (VISIT_ID.ToString() != null)
                    oneDelete[1].Value = VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (ORDER_NO.ToString() != null)
                    oneDelete[2].Value = ORDER_NO;
                else
                    oneDelete[2].Value = DBNull.Value;
                if (ORDER_SUB_NO.ToString() != null)
                    oneDelete[3].Value = ORDER_SUB_NO;
                else
                    oneDelete[3].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_ORDERS_Delete, oneDelete);
            }
        }
        #endregion
        #region [删除所有记录]
        /// <summary>
        ///Delete    model  MedOrders 
        ///Delete Table MED_ORDERS by (string PATIENT_ID,decimal VISIT_ID,decimal ORDER_NO,decimal ORDER_SUB_NO)
        /// </summary>
        public int DeleteMedOrders(string PATIENT_ID, decimal VISIT_ID)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneDelete = GetParameter("DeleteMedOrdersAll");
                if (PATIENT_ID != null)
                    oneDelete[0].Value = PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (VISIT_ID.ToString() != null)
                    oneDelete[1].Value = VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_ORDERS_ALL_Delete, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedOrders 
        ///select Table MED_ORDERS by (string PATIENT_ID,decimal VISIT_ID,decimal ORDER_NO,decimal ORDER_SUB_NO)
        /// </summary>
        public MedOrders SelectMedOrders(string PATIENT_ID, decimal VISIT_ID, string ORDER_NO, decimal ORDER_SUB_NO)
        {
            MedOrders model;
            OracleParameter[] parameterValues = GetParameter("SelectMedOrders");
            parameterValues[0].Value = PATIENT_ID;
            parameterValues[1].Value = VISIT_ID;
            parameterValues[2].Value = ORDER_NO;
            parameterValues[3].Value = ORDER_SUB_NO;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_ORDERS_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedOrders();
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
                        model.OrderNo = oleReader["ORDER_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OrderSubNo = decimal.Parse(oleReader["ORDER_SUB_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.RepeatIndicator = decimal.Parse(oleReader["REPEAT_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OrderClass = oleReader["ORDER_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OrderText = oleReader["ORDER_TEXT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.OrderCode = oleReader["ORDER_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Dosage = decimal.Parse(oleReader["DOSAGE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.DosageUnits = oleReader["DOSAGE_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Administration = oleReader["ADMINISTRATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.StartDateTime = DateTime.Parse(oleReader["START_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.StopDateTime = DateTime.Parse(oleReader["STOP_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Duration = decimal.Parse(oleReader["DURATION"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.DurationUnits = oleReader["DURATION_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.Frequency = oleReader["FREQUENCY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.FreqCounter = decimal.Parse(oleReader["FREQ_COUNTER"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.FreqInterval = decimal.Parse(oleReader["FREQ_INTERVAL"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.FreqIntervalUnit = oleReader["FREQ_INTERVAL_UNIT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.FreqDetail = oleReader["FREQ_DETAIL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.PerformSchedule = oleReader["PERFORM_SCHEDULE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.PerformResult = oleReader["PERFORM_RESULT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.OrderingDept = oleReader["ORDERING_DEPT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Doctor = oleReader["DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.StopDoctor = oleReader["STOP_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Nurse = oleReader["NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.StopNurse = oleReader["STOP_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.EnterDateTime = DateTime.Parse(oleReader["ENTER_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.StopOrderDateTime = DateTime.Parse(oleReader["STOP_ORDER_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.OrderStatus = oleReader["ORDER_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.BillingAttr = decimal.Parse(oleReader["BILLING_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.LastPerformDateTime = DateTime.Parse(oleReader["LAST_PERFORM_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.LastAcctingDateTime = DateTime.Parse(oleReader["LAST_ACCTING_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.DrugBillingAttr = decimal.Parse(oleReader["DRUG_BILLING_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.TreatSheetFlag = oleReader["TREAT_SHEET_FLAG"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.PhamStdCode = oleReader["PHAM_STD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.Amount = decimal.Parse(oleReader["AMOUNT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.DispenseMemos = oleReader["DISPENSE_MEMOS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.CurrentPrescNo = decimal.Parse(oleReader["CURRENT_PRESC_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.DrugSpec = oleReader["DRUG_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.Qty = decimal.Parse(oleReader["QTY"].ToString().Trim());
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
        public List<MedOrders> SelectMedOrdersList()
        {
            List<MedOrders> modelList = new List<MedOrders>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_ORDERS_Select_ALL, null))
            {
                while (oleReader.Read())
                {
                    MedOrders model = new MedOrders();
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
                        model.OrderNo = oleReader["ORDER_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.OrderSubNo = decimal.Parse(oleReader["ORDER_SUB_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.RepeatIndicator = decimal.Parse(oleReader["REPEAT_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.OrderClass = oleReader["ORDER_CLASS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.OrderText = oleReader["ORDER_TEXT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.OrderCode = oleReader["ORDER_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Dosage = decimal.Parse(oleReader["DOSAGE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.DosageUnits = oleReader["DOSAGE_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Administration = oleReader["ADMINISTRATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.StartDateTime = DateTime.Parse(oleReader["START_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.StopDateTime = DateTime.Parse(oleReader["STOP_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Duration = decimal.Parse(oleReader["DURATION"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.DurationUnits = oleReader["DURATION_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.Frequency = oleReader["FREQUENCY"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.FreqCounter = decimal.Parse(oleReader["FREQ_COUNTER"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.FreqInterval = decimal.Parse(oleReader["FREQ_INTERVAL"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.FreqIntervalUnit = oleReader["FREQ_INTERVAL_UNIT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.FreqDetail = oleReader["FREQ_DETAIL"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.PerformSchedule = oleReader["PERFORM_SCHEDULE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.PerformResult = oleReader["PERFORM_RESULT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.OrderingDept = oleReader["ORDERING_DEPT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.Doctor = oleReader["DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.StopDoctor = oleReader["STOP_DOCTOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.Nurse = oleReader["NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(26))
                    {
                        model.StopNurse = oleReader["STOP_NURSE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(27))
                    {
                        model.EnterDateTime = DateTime.Parse(oleReader["ENTER_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(28))
                    {
                        model.StopOrderDateTime = DateTime.Parse(oleReader["STOP_ORDER_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(29))
                    {
                        model.OrderStatus = oleReader["ORDER_STATUS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(30))
                    {
                        model.BillingAttr = decimal.Parse(oleReader["BILLING_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(31))
                    {
                        model.LastPerformDateTime = DateTime.Parse(oleReader["LAST_PERFORM_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(32))
                    {
                        model.LastAcctingDateTime = DateTime.Parse(oleReader["LAST_ACCTING_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(33))
                    {
                        model.DrugBillingAttr = decimal.Parse(oleReader["DRUG_BILLING_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(34))
                    {
                        model.TreatSheetFlag = oleReader["TREAT_SHEET_FLAG"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(35))
                    {
                        model.PhamStdCode = oleReader["PHAM_STD_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(36))
                    {
                        model.Amount = decimal.Parse(oleReader["AMOUNT"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(37))
                    {
                        model.Reserved1 = oleReader["RESERVED1"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(38))
                    {
                        model.DispenseMemos = oleReader["DISPENSE_MEMOS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(39))
                    {
                        model.CurrentPrescNo = decimal.Parse(oleReader["CURRENT_PRESC_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(40))
                    {
                        model.DrugSpec = oleReader["DRUG_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(41))
                    {
                        model.Qty = decimal.Parse(oleReader["QTY"].ToString().Trim());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

    }
}
