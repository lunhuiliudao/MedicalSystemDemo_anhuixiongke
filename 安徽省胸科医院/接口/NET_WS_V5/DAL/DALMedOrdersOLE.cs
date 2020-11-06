

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
using System.Text;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedOrders
    /// </summary>

    public partial class DALMedOrders
    {

        private static readonly string Select_One_MedOrders_OLE = "SELECT patient_id,visit_id,order_no,order_sub_no,repeat_indicator,order_class,order_text,order_code,dosage,dosage_units,administration,start_date_time,stop_date_time,duration,duration_units,frequency,freq_counter,freq_interval,freq_interval_unit,freq_detail,perform_schedule,perform_result,ordering_dept,doctor,stop_doctor,nurse,stop_nurse,enter_date_time,stop_order_date_time,order_status FROM MED_ORDERS WHERE PATIENT_ID = ? AND VISIT_ID = ? AND ORDER_NO = ? AND ORDER_SUB_NO = ?";
        private static readonly string Select_MedOrders_OLE = "SELECT patient_id,visit_id,order_no,order_sub_no,repeat_indicator,order_class,order_text,order_code,dosage,dosage_units,administration,start_date_time,stop_date_time,duration,duration_units,frequency,freq_counter,freq_interval,freq_interval_unit,freq_detail,perform_schedule,perform_result,ordering_dept,doctor,stop_doctor,nurse,stop_nurse,enter_date_time,stop_order_date_time,order_status FROM MED_ORDERS ";
        private static readonly string Insert_MedOrders_OLE = "INSERT INTO MED_ORDERS(patient_id,visit_id,order_no,order_sub_no,repeat_indicator,order_class,order_text,order_code,dosage,dosage_units,administration,start_date_time,stop_date_time,duration,duration_units,frequency,freq_counter,freq_interval,freq_interval_unit,freq_detail,perform_schedule,perform_result,ordering_dept,doctor,stop_doctor,nurse,stop_nurse,enter_date_time,stop_order_date_time,order_status,BILLING_ATTR,LAST_PERFORM_DATE_TIME,LAST_ACCTING_DATE_TIME,DRUG_BILLING_ATTR,TREAT_SHEET_FLAG,PHAM_STD_CODE,AMOUNT,RESERVED1,DISPENSE_MEMOS,CURRENT_PRESC_NO,DRUG_SPEC,QTY) VALUES (?,?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?,?,?,?,?,?,?,?,?,?) ";
        //private static readonly string Update_MedOrders_OLE = "UPDATE MED_ORDERS SET repeat_Indicator = ?, order_Class = ?, order_text = ?, order_Code = ?,DOSAGE = ?,dosage_units = ?, administration = ?, start_date_time = ?, stop_date_time = ?, duration = ?, duration_units = ?, frequency = ?, freq_counter = ?, freq_interval = ?, freq_interval_unit = ?, freq_detail = ?,perform_schedule = ?,perform_result = ?,ordering_dept = ?,doctor = ?,stop_doctor = ?,nurse = ?,stop_nurse = ?,enter_date_time = ?,stop_order_date_time = ?,order_status = ? WHERE PATIENT_ID = ? AND VISIT_ID = ? AND ORDER_NO = ? AND ORDER_SUB_NO = ? ";
        private static readonly string Update_MedOrders_OLE = "UPDATE MED_ORDERS SET PATIENT_ID=?,VISIT_ID=?,ORDER_NO=?,ORDER_SUB_NO=?,REPEAT_INDICATOR=?,ORDER_CLASS=?,ORDER_TEXT=?,ORDER_CODE=?,DOSAGE=?,DOSAGE_UNITS=?,ADMINISTRATION=?,START_DATE_TIME=?,STOP_DATE_TIME=?,DURATION=?,DURATION_UNITS=?,FREQUENCY=?,FREQ_COUNTER=?,FREQ_INTERVAL=?,FREQ_INTERVAL_UNIT=?,FREQ_DETAIL=?,PERFORM_SCHEDULE=?,PERFORM_RESULT=?,ORDERING_DEPT=?,DOCTOR=?,STOP_DOCTOR=?,NURSE=?,STOP_NURSE=?,ENTER_DATE_TIME=?,STOP_ORDER_DATE_TIME=?,ORDER_STATUS=?,BILLING_ATTR=?,LAST_PERFORM_DATE_TIME=?,LAST_ACCTING_DATE_TIME=?,DRUG_BILLING_ATTR=?,TREAT_SHEET_FLAG=?,PHAM_STD_CODE=?,AMOUNT=?,RESERVED1=?,DISPENSE_MEMOS=?,CURRENT_PRESC_NO=?,DRUG_SPEC=?,QTY=? WHERE PATIENT_ID=? AND VISIT_ID=? AND ORDER_NO=? AND ORDER_SUB_NO=?";
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectOneMedOrders")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("orderNo",OleDbType.VarChar),
                        new OleDbParameter("orderSubNo",OleDbType.Decimal)
                    };
                }
                else
                {
                    if (sqlParms == "SelectMedOrders")
                    {
                        parms = new OleDbParameter[]{
                            new OleDbParameter("patientId",OleDbType.VarChar),
                            new OleDbParameter("visitId",OleDbType.Decimal),
                        };
                    }
                    else
                    {
                        if (sqlParms == "InsertMedOrders")
                        {
                            parms = new OleDbParameter[]{
                                new OleDbParameter("patientId",OleDbType.VarChar),
                                new OleDbParameter("visitId",OleDbType.Decimal), 
                                new OleDbParameter("orderNo",OleDbType.VarChar), 
                                new OleDbParameter("orderSubNo",OleDbType.Decimal), 
                                new OleDbParameter("repeatIndicator",OleDbType.Decimal), 
                                new OleDbParameter("orderClass",OleDbType.VarChar), 
                                new OleDbParameter("orderText",OleDbType.VarChar), 
                                new OleDbParameter("orderCode",OleDbType.VarChar), 
                                new OleDbParameter("dosage",OleDbType.Decimal), 
                                new OleDbParameter("dosageUnits",OleDbType.VarChar), 
                                new OleDbParameter("administration",OleDbType.VarChar), 
                                new OleDbParameter("startDateTime",OleDbType.DBTimeStamp), 
                                new OleDbParameter("stopDateTime",OleDbType.DBTimeStamp), 
                                new OleDbParameter("duration",OleDbType.Decimal), 
                                new OleDbParameter("durationUnits",OleDbType.VarChar), 
                                new OleDbParameter("frequency",OleDbType.VarChar), 
                                new OleDbParameter("freqCounter",OleDbType.Decimal), 
                                new OleDbParameter("freqInterval",OleDbType.Decimal), 
                                new OleDbParameter("freqIntervalUnit",OleDbType.VarChar), 
                                new OleDbParameter("freqDetail",OleDbType.VarChar),
                                new OleDbParameter("performSchedule",OleDbType.VarChar),
                                new OleDbParameter("performResult",OleDbType.VarChar),
                                new OleDbParameter("orderingDept",OleDbType.VarChar),
                                new OleDbParameter("doctor",OleDbType.VarChar),
                                new OleDbParameter("stopDoctor",OleDbType.VarChar),
                                new OleDbParameter("nurse",OleDbType.VarChar),
                                new OleDbParameter("stopNurse",OleDbType.VarChar),
                                new OleDbParameter("enterDateTime",OleDbType.DBTimeStamp),
                                new OleDbParameter("stopOrderDateTime",OleDbType.DBTimeStamp),
                                new OleDbParameter("orderStatus",OleDbType.VarChar),


                                new OleDbParameter("BillingAttr",OleDbType.Decimal),
							new OleDbParameter("LastPerformDateTime",OleDbType.DBTimeStamp),
							new OleDbParameter("LastAcctingDateTime",OleDbType.DBTimeStamp),
							new OleDbParameter("DrugBillingAttr",OleDbType.Decimal),
							new OleDbParameter("TreatSheetFlag",OleDbType.VarChar),
							new OleDbParameter("PhamStdCode",OleDbType.VarChar),
							new OleDbParameter("Amount",OleDbType.Decimal),
							new OleDbParameter("Reserved1",OleDbType.VarChar),
							new OleDbParameter("DispenseMemos",OleDbType.VarChar),
							new OleDbParameter("CurrentPrescNo",OleDbType.Decimal),
							new OleDbParameter("DrugSpec",OleDbType.VarChar),
                            new OleDbParameter("Qty",OleDbType.Decimal),

                               // BILLING_ATTR,LAST_PERFORM_DATE_TIME,LAST_ACCTING_DATE_TIME,DRUG_DILLING_ATTR,TREAT_SHEET_FLAG,PHAM_STD_CODE,AMOUNT,CURRENT_PRESC_NO
                            };
                        }
                        else
                        {
                            if (sqlParms == "UpdateMedOrders")
                            {
                                parms = new OleDbParameter[]{
							new OleDbParameter("PatientId",OleDbType.VarChar),
							new OleDbParameter("VisitId",OleDbType.Decimal),
							new OleDbParameter("OrderNo",OleDbType.VarChar),
							new OleDbParameter("OrderSubNo",OleDbType.Decimal),
							new OleDbParameter("RepeatIndicator",OleDbType.Decimal),
							new OleDbParameter("OrderClass",OleDbType.VarChar),
							new OleDbParameter("OrderText",OleDbType.VarChar),
							new OleDbParameter("OrderCode",OleDbType.VarChar),
							new OleDbParameter("Dosage",OleDbType.Decimal),
							new OleDbParameter("DosageUnits",OleDbType.VarChar),
							new OleDbParameter("Administration",OleDbType.VarChar),
							new OleDbParameter("StartDateTime",OleDbType.DBTimeStamp),
							new OleDbParameter("StopDateTime",OleDbType.DBTimeStamp),
							new OleDbParameter("Duration",OleDbType.Decimal),
							new OleDbParameter("DurationUnits",OleDbType.VarChar),
							new OleDbParameter("Frequency",OleDbType.VarChar),
							new OleDbParameter("FreqCounter",OleDbType.Decimal),
							new OleDbParameter("FreqInterval",OleDbType.Decimal),
							new OleDbParameter("FreqIntervalUnit",OleDbType.VarChar),
							new OleDbParameter("FreqDetail",OleDbType.VarChar),
							new OleDbParameter("PerformSchedule",OleDbType.VarChar),
							new OleDbParameter("PerformResult",OleDbType.VarChar),
							new OleDbParameter("OrderingDept",OleDbType.VarChar),
							new OleDbParameter("Doctor",OleDbType.VarChar),
							new OleDbParameter("StopDoctor",OleDbType.VarChar),
							new OleDbParameter("Nurse",OleDbType.VarChar),
							new OleDbParameter("StopNurse",OleDbType.VarChar),
							new OleDbParameter("EnterDateTime",OleDbType.DBTimeStamp),
							new OleDbParameter("StopOrderDateTime",OleDbType.DBTimeStamp),
							new OleDbParameter("OrderStatus",OleDbType.VarChar),
							new OleDbParameter("BillingAttr",OleDbType.Decimal),
							new OleDbParameter("LastPerformDateTime",OleDbType.DBTimeStamp),
							new OleDbParameter("LastAcctingDateTime",OleDbType.DBTimeStamp),
							new OleDbParameter("DrugBillingAttr",OleDbType.Decimal),
							new OleDbParameter("TreatSheetFlag",OleDbType.VarChar),
							new OleDbParameter("PhamStdCode",OleDbType.VarChar),
							new OleDbParameter("Amount",OleDbType.Decimal),
							new OleDbParameter("Reserved1",OleDbType.VarChar),
							new OleDbParameter("DispenseMemos",OleDbType.VarChar),
							new OleDbParameter("CurrentPrescNo",OleDbType.Decimal),
							new OleDbParameter("DrugSpec",OleDbType.VarChar),
                            new OleDbParameter("Qty",OleDbType.Decimal),
							new OleDbParameter("PatientId",SqlDbType.VarChar),
							new OleDbParameter("VisitId",SqlDbType.Decimal),
							new OleDbParameter("OrderNo",SqlDbType.VarChar),
							new OleDbParameter("OrderSubNo",SqlDbType.Decimal),
                                };   
                            }
                        }
                    }
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedOrders SelectMedOrdersOLE(string patientId, decimal visitId, string orderNo, decimal orderSubNo)
        {
            Model.MedOrders medOrder = null;

            OleDbParameter[] oneOrder = GetParameterOLE("SelectOneMedOrders");
            oneOrder[0].Value = patientId;
            oneOrder[1].Value = visitId;
            oneOrder[2].Value = orderNo;
            oneOrder[3].Value = orderSubNo;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_One_MedOrders_OLE, oneOrder))
            {
                if (oleReader.Read())
                {
                    medOrder = new Model.MedOrders();
                    medOrder.PatientId = oleReader.GetString(0);
                    medOrder.VisitId = oleReader.GetDecimal(1);
                    medOrder.OrderNo = oleReader.GetString(2);
                    medOrder.OrderSubNo = oleReader.GetDecimal(3);
                    if (!oleReader.IsDBNull(4))
                        medOrder.RepeatIndicator = oleReader.GetDecimal(4);
                    if (!oleReader.IsDBNull(5))
                        medOrder.OrderClass = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        medOrder.OrderText = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        medOrder.OrderCode = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        medOrder.Dosage = oleReader.GetDecimal(8);
                    if (!oleReader.IsDBNull(9))
                        medOrder.DosageUnits = oleReader.GetString(9);
                    if (!oleReader.IsDBNull(10))
                        medOrder.Administration = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        medOrder.StartDateTime = oleReader.GetDateTime(11);
                    if (!oleReader.IsDBNull(12))
                        medOrder.StopDateTime = oleReader.GetDateTime(12);
                    if (!oleReader.IsDBNull(13))
                        medOrder.Duration = oleReader.GetDecimal(13);
                    if (!oleReader.IsDBNull(14))
                        medOrder.DurationUnits = oleReader.GetString(14);
                    if (!oleReader.IsDBNull(15))
                        medOrder.Frequency = oleReader.GetString(15);
                    if (!oleReader.IsDBNull(16))
                        medOrder.FreqCounter = oleReader.GetDecimal(16);
                    if (!oleReader.IsDBNull(17))
                        medOrder.FreqInterval = oleReader.GetDecimal(17);
                    if (!oleReader.IsDBNull(18))
                        medOrder.FreqIntervalUnit = oleReader.GetString(18);
                    if (!oleReader.IsDBNull(19))
                        medOrder.FreqDetail = oleReader.GetString(19);
                    if (!oleReader.IsDBNull(20))
                        medOrder.PerformSchedule = oleReader.GetString(20);
                    if (!oleReader.IsDBNull(21))
                        medOrder.PerformResult = oleReader.GetString(21);
                    if (!oleReader.IsDBNull(22))
                        medOrder.OrderingDept = oleReader.GetString(22);
                    if (!oleReader.IsDBNull(23))
                        medOrder.Doctor = oleReader.GetString(23);
                    if (!oleReader.IsDBNull(24))
                        medOrder.StopDoctor = oleReader.GetString(24);
                    if (!oleReader.IsDBNull(25))
                        medOrder.Nurse = oleReader.GetString(25);
                    if (!oleReader.IsDBNull(26))
                        medOrder.StopNurse = oleReader.GetString(26);
                    if (!oleReader.IsDBNull(27))
                        medOrder.EnterDateTime = oleReader.GetDateTime(27);
                    if (!oleReader.IsDBNull(28))
                        medOrder.StopOrderDateTime = oleReader.GetDateTime(28);
                    if (!oleReader.IsDBNull(29))
                        medOrder.OrderStatus = oleReader.GetString(29);
                }
                else
                    medOrder = null;
            }
            return medOrder;
        }

        public List<Model.MedOrders> SelectMedOrdersListOLE()
        {
            List<Model.MedOrders> medOrders = new List<Model.MedOrders>();

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedOrders_OLE, null))
            {
                while (oleReader.Read())
                {
                    Model.MedOrders medOrder = new Model.MedOrders();
                    medOrder.PatientId = oleReader.GetString(0);
                    medOrder.VisitId = oleReader.GetDecimal(1);
                    medOrder.OrderNo = oleReader.GetString(2);
                    medOrder.OrderSubNo = oleReader.GetDecimal(3);
                    if (!oleReader.IsDBNull(4))
                        medOrder.RepeatIndicator = oleReader.GetDecimal(4);
                    if (!oleReader.IsDBNull(5))
                        medOrder.OrderClass = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        medOrder.OrderText = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        medOrder.OrderCode = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        medOrder.Dosage = oleReader.GetDecimal(8);
                    if (!oleReader.IsDBNull(9))
                        medOrder.DosageUnits = oleReader.GetString(9);
                    if (!oleReader.IsDBNull(10))
                        medOrder.Administration = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        medOrder.StartDateTime = oleReader.GetDateTime(11);
                    if (!oleReader.IsDBNull(12))
                        medOrder.StopDateTime = oleReader.GetDateTime(12);
                    if (!oleReader.IsDBNull(13))
                        medOrder.Duration = oleReader.GetDecimal(13);
                    if (!oleReader.IsDBNull(14))
                        medOrder.DurationUnits = oleReader.GetString(14);
                    if (!oleReader.IsDBNull(15))
                        medOrder.Frequency = oleReader.GetString(15);
                    if (!oleReader.IsDBNull(16))
                        medOrder.FreqCounter = oleReader.GetDecimal(16);
                    if (!oleReader.IsDBNull(17))
                        medOrder.FreqInterval = oleReader.GetDecimal(17);
                    if (!oleReader.IsDBNull(18))
                        medOrder.FreqIntervalUnit = oleReader.GetString(18);
                    if (!oleReader.IsDBNull(19))
                        medOrder.FreqDetail = oleReader.GetString(19);
                    if (!oleReader.IsDBNull(20))
                        medOrder.PerformSchedule = oleReader.GetString(20);
                    if (!oleReader.IsDBNull(21))
                        medOrder.PerformResult = oleReader.GetString(21);
                    if (!oleReader.IsDBNull(22))
                        medOrder.OrderingDept = oleReader.GetString(22);
                    if (!oleReader.IsDBNull(23))
                        medOrder.Doctor = oleReader.GetString(23);
                    if (!oleReader.IsDBNull(24))
                        medOrder.StopDoctor = oleReader.GetString(24);
                    if (!oleReader.IsDBNull(25))
                        medOrder.Nurse = oleReader.GetString(25);
                    if (!oleReader.IsDBNull(26))
                        medOrder.StopNurse = oleReader.GetString(26);
                    if (!oleReader.IsDBNull(27))
                        medOrder.EnterDateTime = oleReader.GetDateTime(27);
                    if (!oleReader.IsDBNull(28))
                        medOrder.StopOrderDateTime = oleReader.GetDateTime(28);
                    if (!oleReader.IsDBNull(29))
                        medOrder.OrderStatus = oleReader.GetString(29);
                    medOrders.Add(medOrder);
                }
            }
            return medOrders;
        }

        public int InsertMedOrdersOLE(Model.MedOrders medOrders)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedOrders");
                oneInert[0].Value = medOrders.PatientId;
                oneInert[1].Value = medOrders.VisitId;
                oneInert[2].Value = medOrders.OrderNo;
                oneInert[3].Value = medOrders.OrderSubNo;
                if (medOrders.RepeatIndicator.ToString() != null)
                    oneInert[4].Value = medOrders.RepeatIndicator;
                else
                    oneInert[4].Value = DBNull.Value;
                if (medOrders.OrderClass != null)
                    oneInert[5].Value = medOrders.OrderClass;
                else
                    oneInert[5].Value = DBNull.Value;
                if (medOrders.OrderText != null)
                    oneInert[6].Value = medOrders.OrderText;
                else
                    oneInert[6].Value = DBNull.Value;
                if (medOrders.OrderCode != null)
                    oneInert[7].Value = medOrders.OrderCode;
                else
                    oneInert[7].Value = DBNull.Value;
                if (medOrders.Dosage.ToString() != null)
                    oneInert[8].Value = medOrders.Dosage;
                else
                    oneInert[8].Value = DBNull.Value;
                if (medOrders.DosageUnits != null)
                    oneInert[9].Value = medOrders.DosageUnits;
                else
                    oneInert[9].Value = DBNull.Value;
                if (medOrders.Administration != null)
                    oneInert[10].Value = medOrders.Administration;
                else
                    oneInert[10].Value = DBNull.Value;
                if (medOrders.StartDateTime > DateTime.MinValue)
                    oneInert[11].Value = medOrders.StartDateTime;
                else
                    oneInert[11].Value = DBNull.Value;
                if (medOrders.StopDateTime > DateTime.MinValue)
                    oneInert[12].Value = medOrders.StopDateTime;
                else
                    oneInert[12].Value = DBNull.Value;
                if (medOrders.Duration.ToString() != null)
                    oneInert[13].Value = medOrders.Duration;
                else
                    oneInert[13].Value = DBNull.Value;
                if (medOrders.DurationUnits != null)
                    oneInert[14].Value = medOrders.DurationUnits;
                else
                    oneInert[14].Value = DBNull.Value;
                if (medOrders.Frequency != null)
                    oneInert[15].Value = medOrders.Frequency;
                else
                    oneInert[15].Value = DBNull.Value;
                if (medOrders.FreqCounter.ToString() != null)
                    oneInert[16].Value = medOrders.FreqCounter;
                else
                    oneInert[16].Value = DBNull.Value;
                if (medOrders.FreqInterval.ToString() != null)
                    oneInert[17].Value = medOrders.FreqInterval;
                else
                    oneInert[17].Value = DBNull.Value;
                if (medOrders.FreqIntervalUnit != null)
                    oneInert[18].Value = medOrders.FreqIntervalUnit;
                else
                    oneInert[18].Value = DBNull.Value;
                if (medOrders.FreqDetail != null)
                    oneInert[19].Value = medOrders.FreqDetail;
                else
                    oneInert[19].Value = DBNull.Value;
                if (medOrders.PerformSchedule != null)
                    oneInert[20].Value = medOrders.PerformSchedule;
                else
                    oneInert[20].Value = DBNull.Value;
                if (medOrders.PerformResult != null)
                    oneInert[21].Value = medOrders.PerformResult;
                else
                    oneInert[21].Value = DBNull.Value;
                if (medOrders.OrderingDept != null)
                    oneInert[22].Value = medOrders.OrderingDept;
                else
                    oneInert[22].Value = DBNull.Value;
                if (medOrders.Doctor != null)
                    oneInert[23].Value = medOrders.Doctor;
                else
                    oneInert[23].Value = DBNull.Value;
                if (medOrders.StopDoctor != null)
                    oneInert[24].Value = medOrders.StopDoctor;
                else
                    oneInert[24].Value = DBNull.Value;
                if (medOrders.Nurse != null)
                    oneInert[25].Value = medOrders.Nurse;
                else
                    oneInert[25].Value = DBNull.Value;
                if (medOrders.StopNurse != null)
                    oneInert[26].Value = medOrders.StopNurse;
                else
                    oneInert[26].Value = DBNull.Value;
                if (medOrders.EnterDateTime > DateTime.MinValue)
                    oneInert[27].Value = medOrders.EnterDateTime;
                else
                    oneInert[27].Value = DBNull.Value;
                if (medOrders.StopOrderDateTime > DateTime.MinValue)
                    oneInert[28].Value = medOrders.StopOrderDateTime;
                else
                    oneInert[28].Value = DBNull.Value;
                if (medOrders.OrderStatus != null)
                    oneInert[29].Value = medOrders.OrderStatus;
                else
                    oneInert[29].Value = DBNull.Value;

                if (medOrders.BillingAttr.ToString() != null)
                    oneInert[30].Value = medOrders.BillingAttr;
                else
                    oneInert[30].Value = DBNull.Value;
                if (medOrders.LastPerformDateTime > DateTime.MinValue)
                    oneInert[31].Value = medOrders.LastPerformDateTime;
                else
                    oneInert[31].Value = DBNull.Value;
                if (medOrders.LastAcctingDateTime > DateTime.MinValue)
                    oneInert[32].Value = medOrders.LastAcctingDateTime;
                else
                    oneInert[32].Value = DBNull.Value;
                if (medOrders.DrugBillingAttr.ToString() != null)
                    oneInert[33].Value = medOrders.DrugBillingAttr;
                else
                    oneInert[33].Value = DBNull.Value;
                if (medOrders.TreatSheetFlag != null)
                    oneInert[34].Value = medOrders.TreatSheetFlag;
                else
                    oneInert[34].Value = DBNull.Value;
                if (medOrders.PhamStdCode != null)
                    oneInert[35].Value = medOrders.PhamStdCode;
                else
                    oneInert[35].Value = DBNull.Value;
                if (medOrders.Amount.ToString() != null)
                    oneInert[36].Value = medOrders.Amount;
                else
                    oneInert[36].Value = DBNull.Value;
                if (medOrders.Reserved1 != null)
                    oneInert[37].Value = medOrders.Reserved1;
                else
                    oneInert[37].Value = DBNull.Value;
                if (medOrders.DispenseMemos != null)
                    oneInert[38].Value = medOrders.DispenseMemos;
                else
                    oneInert[38].Value = DBNull.Value;
                if (medOrders.CurrentPrescNo.ToString() != null)
                    oneInert[39].Value = medOrders.CurrentPrescNo;
                else
                    oneInert[39].Value = DBNull.Value;
                if (medOrders.DrugSpec != null)
                    oneInert[40].Value = medOrders.DrugSpec;
                else
                    oneInert[40].Value = DBNull.Value;
                if (medOrders.Qty.ToString() != null)
                    oneInert[41].Value = medOrders.Qty;
                else
                    oneInert[41].Value = DBNull.Value;
                
                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_MedOrders_OLE, oneInert);
            }
        }

        public int UpdateMedOrdersOLE(Model.MedOrders model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedOrders");

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

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_MedOrders_OLE, oneUpdate);
            }
        }

        private static readonly string Select_One_MedOrders_Odbc = "SELECT patient_id,visit_id,order_no,order_sub_no,repeat_indicator,order_class,order_text,order_code,dosage,dosage_units,administration,start_date_time,stop_date_time,duration,duration_units,frequency,freq_counter,freq_interval,freq_interval_unit,freq_detail,perform_schedule,perform_result,ordering_dept,doctor,stop_doctor,nurse,stop_nurse,enter_date_time,stop_order_date_time,order_status FROM MED_ORDERS WHERE PATIENT_ID = ? AND VISIT_ID = ? AND ORDER_NO = ? AND ORDER_SUB_NO = ?";
        private static readonly string Select_MedOrders_Odbc = "SELECT patient_id,visit_id,order_no,order_sub_no,repeat_indicator,order_class,order_text,order_code,dosage,dosage_units,administration,start_date_time,stop_date_time,duration,duration_units,frequency,freq_counter,freq_interval,freq_interval_unit,freq_detail,perform_schedule,perform_result,ordering_dept,doctor,stop_doctor,nurse,stop_nurse,enter_date_time,stop_order_date_time,order_status FROM MED_ORDERS ";
        private static readonly string Insert_MedOrders_Odbc = "INSERT INTO MED_ORDERS(patient_id,visit_id,order_no,order_sub_no,repeat_indicator,order_class,order_text,order_code,dosage,dosage_units,administration,start_date_time,stop_date_time,duration,duration_units,frequency,freq_counter,freq_interval,freq_interval_unit,freq_detail,perform_schedule,perform_result,ordering_dept,doctor,stop_doctor,nurse,stop_nurse,enter_date_time,stop_order_date_time,order_status) VALUES (?,?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?) ";
        private static readonly string Update_MedOrders_Odbc = "UPDATE MED_ORDERS SET repeat_Indicator = ?, order_Class = ?, order_text = ?, order_Code = ?,DOSAGE = ?,dosage_units = ?, administration = ?, start_date_time = ?, stop_date_time = ?, duration = ?, duration_units = ?, frequency = ?, freq_counter = ?, freq_interval = ?, freq_interval_unit = ?, freq_detail = ?,perform_schedule = ?,perform_result = ?,ordering_dept = ?,doctor = ?,stop_doctor = ?,nurse = ?,stop_nurse = ?,enter_date_time = ?,stop_order_date_time = ?,order_status = ? WHERE PATIENT_ID = ? AND VISIT_ID = ? AND ORDER_NO = ? AND ORDER_SUB_NO = ? ";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectOneMedOrders")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("orderNo",OdbcType.VarChar),
                        new OdbcParameter("orderSubNo",OdbcType.Decimal)
                    };
                }
                else
                {
                    if (sqlParms == "SelectMedOrders")
                    {
                        parms = new OdbcParameter[]{
                            new OdbcParameter("patientId",OdbcType.VarChar),
                            new OdbcParameter("visitId",OdbcType.Decimal),
                        };
                    }
                    else
                    {
                        if (sqlParms == "InsertMedOrders")
                        {
                            parms = new OdbcParameter[]{
                                new OdbcParameter("patientId",OdbcType.VarChar),
                                new OdbcParameter("visitId",OdbcType.Decimal), 
                                new OdbcParameter("orderNo",OdbcType.VarChar), 
                                new OdbcParameter("orderSubNo",OdbcType.Decimal), 
                                new OdbcParameter("repeatIndicator",OdbcType.Decimal), 
                                new OdbcParameter("orderClass",OdbcType.VarChar), 
                                new OdbcParameter("orderText",OdbcType.VarChar), 
                                new OdbcParameter("orderCode",OdbcType.VarChar), 
                                new OdbcParameter("dosage",OdbcType.Decimal), 
                                new OdbcParameter("dosageUnits",OdbcType.VarChar), 
                                new OdbcParameter("administration",OdbcType.VarChar), 
                                new OdbcParameter("startDateTime",OdbcType.DateTime), 
                                new OdbcParameter("stopDateTime",OdbcType.DateTime), 
                                new OdbcParameter("duration",OdbcType.Decimal), 
                                new OdbcParameter("durationUnits",OdbcType.VarChar), 
                                new OdbcParameter("frequency",OdbcType.VarChar), 
                                new OdbcParameter("freqCounter",OdbcType.Decimal), 
                                new OdbcParameter("freqInterval",OdbcType.Decimal), 
                                new OdbcParameter("freqIntervalUnit",OdbcType.VarChar), 
                                new OdbcParameter("freqDetail",OdbcType.VarChar),
                                new OdbcParameter("performSchedule",OdbcType.VarChar),
                                new OdbcParameter("performResult",OdbcType.VarChar),
                                new OdbcParameter("orderingDept",OdbcType.VarChar),
                                new OdbcParameter("doctor",OdbcType.VarChar),
                                new OdbcParameter("stopDoctor",OdbcType.VarChar),
                                new OdbcParameter("nurse",OdbcType.VarChar),
                                new OdbcParameter("stopNurse",OdbcType.VarChar),
                                new OdbcParameter("enterDateTime",OdbcType.DateTime),
                                new OdbcParameter("stopOrderDateTime",OdbcType.DateTime),
                                new OdbcParameter("orderStatus",OdbcType.VarChar)
                            };
                        }
                        else
                        {
                            if (sqlParms == "UpdateMedOrders")
                            {
                                parms = new OdbcParameter[]{
                                    new OdbcParameter("repeatIndicator",OdbcType.Decimal), 
                                    new OdbcParameter("orderClass",OdbcType.VarChar), 
                                    new OdbcParameter("orderText",OdbcType.VarChar), 
                                    new OdbcParameter("orderCode",OdbcType.VarChar), 
                                    new OdbcParameter("dosage",OdbcType.Decimal), 
                                    new OdbcParameter("dosageUnits",OdbcType.VarChar), 
                                    new OdbcParameter("administration",OdbcType.VarChar), 
                                    new OdbcParameter("startDateTime",OdbcType.DateTime), 
                                    new OdbcParameter("stopDateTime",OdbcType.DateTime), 
                                    new OdbcParameter("duration",OdbcType.Decimal), 
                                    new OdbcParameter("durationUnits",OdbcType.VarChar), 
                                    new OdbcParameter("frequency",OdbcType.VarChar), 
                                    new OdbcParameter("freqCounter",OdbcType.Decimal), 
                                    new OdbcParameter("freqInterval",OdbcType.Decimal), 
                                    new OdbcParameter("freqIntervalUnit",OdbcType.VarChar), 
                                    new OdbcParameter("freqDetail",OdbcType.VarChar),
                                    new OdbcParameter("performSchedule",OdbcType.VarChar),
                                    new OdbcParameter("performResult",OdbcType.VarChar),
                                    new OdbcParameter("orderingDept",OdbcType.VarChar),
                                    new OdbcParameter("doctor",OdbcType.VarChar),
                                    new OdbcParameter("stopDoctor",OdbcType.VarChar),
                                    new OdbcParameter("nurse",OdbcType.VarChar),
                                    new OdbcParameter("stopNurse",OdbcType.VarChar),
                                    new OdbcParameter("enterDateTime",OdbcType.DateTime),
                                    new OdbcParameter("stopOrderDateTime",OdbcType.DateTime),
                                    new OdbcParameter("orderStatus",OdbcType.VarChar),
                                    new OdbcParameter("patientId",OdbcType.VarChar),
                                    new OdbcParameter("visitId",OdbcType.Decimal), 
                                    new OdbcParameter("orderNo",OdbcType.VarChar), 
                                    new OdbcParameter("orderSubNo",OdbcType.Decimal)
                                };
                            }
                        }
                    }
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedOrders SelectMedOrdersOdbc(string patientId, decimal visitId, string orderNo, decimal orderSubNo)
        {
            Model.MedOrders medOrder = null;

            OdbcParameter[] oneOrder = GetParameterOdbc("SelectOneMedOrders");
            oneOrder[0].Value = patientId;
            oneOrder[1].Value = visitId;
            oneOrder[2].Value = orderNo;
            oneOrder[3].Value = orderSubNo;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_One_MedOrders_Odbc, oneOrder))
            {
                if (OdbcReader.Read())
                {
                    medOrder = new Model.MedOrders();
                    medOrder.PatientId = OdbcReader.GetString(0);
                    medOrder.VisitId = OdbcReader.GetDecimal(1);
                    medOrder.OrderNo = OdbcReader.GetString(2);
                    medOrder.OrderSubNo = OdbcReader.GetDecimal(3);
                    if (!OdbcReader.IsDBNull(4))
                        medOrder.RepeatIndicator = OdbcReader.GetDecimal(4);
                    if (!OdbcReader.IsDBNull(5))
                        medOrder.OrderClass = OdbcReader.GetString(5);
                    if (!OdbcReader.IsDBNull(6))
                        medOrder.OrderText = OdbcReader.GetString(6);
                    if (!OdbcReader.IsDBNull(7))
                        medOrder.OrderCode = OdbcReader.GetString(7);
                    if (!OdbcReader.IsDBNull(8))
                        medOrder.Dosage = OdbcReader.GetDecimal(8);
                    if (!OdbcReader.IsDBNull(9))
                        medOrder.DosageUnits = OdbcReader.GetString(9);
                    if (!OdbcReader.IsDBNull(10))
                        medOrder.Administration = OdbcReader.GetString(10);
                    if (!OdbcReader.IsDBNull(11))
                        medOrder.StartDateTime = OdbcReader.GetDateTime(11);
                    if (!OdbcReader.IsDBNull(12))
                        medOrder.StopDateTime = OdbcReader.GetDateTime(12);
                    if (!OdbcReader.IsDBNull(13))
                        medOrder.Duration = OdbcReader.GetDecimal(13);
                    if (!OdbcReader.IsDBNull(14))
                        medOrder.DurationUnits = OdbcReader.GetString(14);
                    if (!OdbcReader.IsDBNull(15))
                        medOrder.Frequency = OdbcReader.GetString(15);
                    if (!OdbcReader.IsDBNull(16))
                        medOrder.FreqCounter = OdbcReader.GetDecimal(16);
                    if (!OdbcReader.IsDBNull(17))
                        medOrder.FreqInterval = OdbcReader.GetDecimal(17);
                    if (!OdbcReader.IsDBNull(18))
                        medOrder.FreqIntervalUnit = OdbcReader.GetString(18);
                    if (!OdbcReader.IsDBNull(19))
                        medOrder.FreqDetail = OdbcReader.GetString(19);
                    if (!OdbcReader.IsDBNull(20))
                        medOrder.PerformSchedule = OdbcReader.GetString(20);
                    if (!OdbcReader.IsDBNull(21))
                        medOrder.PerformResult = OdbcReader.GetString(21);
                    if (!OdbcReader.IsDBNull(22))
                        medOrder.OrderingDept = OdbcReader.GetString(22);
                    if (!OdbcReader.IsDBNull(23))
                        medOrder.Doctor = OdbcReader.GetString(23);
                    if (!OdbcReader.IsDBNull(24))
                        medOrder.StopDoctor = OdbcReader.GetString(24);
                    if (!OdbcReader.IsDBNull(25))
                        medOrder.Nurse = OdbcReader.GetString(25);
                    if (!OdbcReader.IsDBNull(26))
                        medOrder.StopNurse = OdbcReader.GetString(26);
                    if (!OdbcReader.IsDBNull(27))
                        medOrder.EnterDateTime = OdbcReader.GetDateTime(27);
                    if (!OdbcReader.IsDBNull(28))
                        medOrder.StopOrderDateTime = OdbcReader.GetDateTime(28);
                    if (!OdbcReader.IsDBNull(29))
                        medOrder.OrderStatus = OdbcReader.GetString(29);
                }
                else
                    medOrder = null;
            }
            return medOrder;
        }

        public List<Model.MedOrders> SelectMedOrdersListOdbc()
        {
            List<Model.MedOrders> medOrders = new List<Model.MedOrders>();

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MedOrders_Odbc, null))
            {
                while (OdbcReader.Read())
                {
                    Model.MedOrders medOrder = new Model.MedOrders();
                    medOrder.PatientId = OdbcReader.GetString(0);
                    medOrder.VisitId = OdbcReader.GetDecimal(1);
                    medOrder.OrderNo = OdbcReader.GetString(2);
                    medOrder.OrderSubNo = OdbcReader.GetDecimal(3);
                    if (!OdbcReader.IsDBNull(4))
                        medOrder.RepeatIndicator = OdbcReader.GetDecimal(4);
                    if (!OdbcReader.IsDBNull(5))
                        medOrder.OrderClass = OdbcReader.GetString(5);
                    if (!OdbcReader.IsDBNull(6))
                        medOrder.OrderText = OdbcReader.GetString(6);
                    if (!OdbcReader.IsDBNull(7))
                        medOrder.OrderCode = OdbcReader.GetString(7);
                    if (!OdbcReader.IsDBNull(8))
                        medOrder.Dosage = OdbcReader.GetDecimal(8);
                    if (!OdbcReader.IsDBNull(9))
                        medOrder.DosageUnits = OdbcReader.GetString(9);
                    if (!OdbcReader.IsDBNull(10))
                        medOrder.Administration = OdbcReader.GetString(10);
                    if (!OdbcReader.IsDBNull(11))
                        medOrder.StartDateTime = OdbcReader.GetDateTime(11);
                    if (!OdbcReader.IsDBNull(12))
                        medOrder.StopDateTime = OdbcReader.GetDateTime(12);
                    if (!OdbcReader.IsDBNull(13))
                        medOrder.Duration = OdbcReader.GetDecimal(13);
                    if (!OdbcReader.IsDBNull(14))
                        medOrder.DurationUnits = OdbcReader.GetString(14);
                    if (!OdbcReader.IsDBNull(15))
                        medOrder.Frequency = OdbcReader.GetString(15);
                    if (!OdbcReader.IsDBNull(16))
                        medOrder.FreqCounter = OdbcReader.GetDecimal(16);
                    if (!OdbcReader.IsDBNull(17))
                        medOrder.FreqInterval = OdbcReader.GetDecimal(17);
                    if (!OdbcReader.IsDBNull(18))
                        medOrder.FreqIntervalUnit = OdbcReader.GetString(18);
                    if (!OdbcReader.IsDBNull(19))
                        medOrder.FreqDetail = OdbcReader.GetString(19);
                    if (!OdbcReader.IsDBNull(20))
                        medOrder.PerformSchedule = OdbcReader.GetString(20);
                    if (!OdbcReader.IsDBNull(21))
                        medOrder.PerformResult = OdbcReader.GetString(21);
                    if (!OdbcReader.IsDBNull(22))
                        medOrder.OrderingDept = OdbcReader.GetString(22);
                    if (!OdbcReader.IsDBNull(23))
                        medOrder.Doctor = OdbcReader.GetString(23);
                    if (!OdbcReader.IsDBNull(24))
                        medOrder.StopDoctor = OdbcReader.GetString(24);
                    if (!OdbcReader.IsDBNull(25))
                        medOrder.Nurse = OdbcReader.GetString(25);
                    if (!OdbcReader.IsDBNull(26))
                        medOrder.StopNurse = OdbcReader.GetString(26);
                    if (!OdbcReader.IsDBNull(27))
                        medOrder.EnterDateTime = OdbcReader.GetDateTime(27);
                    if (!OdbcReader.IsDBNull(28))
                        medOrder.StopOrderDateTime = OdbcReader.GetDateTime(28);
                    if (!OdbcReader.IsDBNull(29))
                        medOrder.OrderStatus = OdbcReader.GetString(29);
                    medOrders.Add(medOrder);
                }
            }
            return medOrders;
        }

        public int InsertMedOrdersOdbc(Model.MedOrders medOrders)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedOrders");
                oneInert[0].Value = medOrders.PatientId;
                oneInert[1].Value = medOrders.VisitId;
                oneInert[2].Value = medOrders.OrderNo;
                oneInert[3].Value = medOrders.OrderSubNo;
                if (medOrders.RepeatIndicator.ToString() != null)
                    oneInert[4].Value = medOrders.RepeatIndicator;
                else
                    oneInert[4].Value = DBNull.Value;
                if (medOrders.OrderClass != null)
                    oneInert[5].Value = medOrders.OrderClass;
                else
                    oneInert[5].Value = DBNull.Value;
                if (medOrders.OrderText != null)
                    oneInert[6].Value = medOrders.OrderText;
                else
                    oneInert[6].Value = DBNull.Value;
                if (medOrders.OrderCode != null)
                    oneInert[7].Value = medOrders.OrderCode;
                else
                    oneInert[7].Value = DBNull.Value;
                if (medOrders.Dosage.ToString() != null)
                    oneInert[8].Value = medOrders.Dosage;
                else
                    oneInert[8].Value = DBNull.Value;
                if (medOrders.DosageUnits != null)
                    oneInert[9].Value = medOrders.DosageUnits;
                else
                    oneInert[9].Value = DBNull.Value;
                if (medOrders.Administration != null)
                    oneInert[10].Value = medOrders.Administration;
                else
                    oneInert[10].Value = DBNull.Value;
                if (medOrders.StartDateTime > DateTime.MinValue)
                    oneInert[11].Value = medOrders.StartDateTime;
                else
                    oneInert[11].Value = DBNull.Value;
                if (medOrders.StopDateTime > DateTime.MinValue)
                    oneInert[12].Value = medOrders.StopDateTime;
                else
                    oneInert[12].Value = DBNull.Value;
                if (medOrders.Duration.ToString() != null)
                    oneInert[13].Value = medOrders.Duration;
                else
                    oneInert[13].Value = DBNull.Value;
                if (medOrders.DurationUnits != null)
                    oneInert[14].Value = medOrders.DurationUnits;
                else
                    oneInert[14].Value = DBNull.Value;
                if (medOrders.Frequency != null)
                    oneInert[15].Value = medOrders.Frequency;
                else
                    oneInert[15].Value = DBNull.Value;
                if (medOrders.FreqCounter.ToString() != null)
                    oneInert[16].Value = medOrders.FreqCounter;
                else
                    oneInert[16].Value = DBNull.Value;
                if (medOrders.FreqInterval.ToString() != null)
                    oneInert[17].Value = medOrders.FreqInterval;
                else
                    oneInert[17].Value = DBNull.Value;
                if (medOrders.FreqIntervalUnit != null)
                    oneInert[18].Value = medOrders.FreqIntervalUnit;
                else
                    oneInert[18].Value = DBNull.Value;
                if (medOrders.FreqDetail != null)
                    oneInert[19].Value = medOrders.FreqDetail;
                else
                    oneInert[19].Value = DBNull.Value;
                if (medOrders.PerformSchedule != null)
                    oneInert[20].Value = medOrders.PerformSchedule;
                else
                    oneInert[20].Value = DBNull.Value;
                if (medOrders.PerformResult != null)
                    oneInert[21].Value = medOrders.PerformResult;
                else
                    oneInert[21].Value = DBNull.Value;
                if (medOrders.OrderingDept != null)
                    oneInert[22].Value = medOrders.OrderingDept;
                else
                    oneInert[22].Value = DBNull.Value;
                if (medOrders.Doctor != null)
                    oneInert[23].Value = medOrders.Doctor;
                else
                    oneInert[23].Value = DBNull.Value;
                if (medOrders.StopDoctor != null)
                    oneInert[24].Value = medOrders.StopDoctor;
                else
                    oneInert[24].Value = DBNull.Value;
                if (medOrders.Nurse != null)
                    oneInert[25].Value = medOrders.Nurse;
                else
                    oneInert[25].Value = DBNull.Value;
                if (medOrders.StopNurse != null)
                    oneInert[26].Value = medOrders.StopNurse;
                else
                    oneInert[26].Value = DBNull.Value;
                if (medOrders.EnterDateTime > DateTime.MinValue)
                    oneInert[27].Value = medOrders.EnterDateTime;
                else
                    oneInert[27].Value = DBNull.Value;
                if (medOrders.StopOrderDateTime > DateTime.MinValue)
                    oneInert[28].Value = medOrders.StopOrderDateTime;
                else
                    oneInert[28].Value = DBNull.Value;
                if (medOrders.OrderStatus != null)
                    oneInert[29].Value = medOrders.OrderStatus;
                else
                    oneInert[29].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_MedOrders_Odbc, oneInert);
            }
        }

        public int UpdateMedOrdersOdbc(Model.MedOrders medOrders)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedOrders");

                if (medOrders.RepeatIndicator.ToString() != null)
                    oneUpdate[0].Value = medOrders.RepeatIndicator;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (medOrders.OrderClass != null)
                    oneUpdate[1].Value = medOrders.OrderClass;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (medOrders.OrderText != null)
                    oneUpdate[2].Value = medOrders.OrderText;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (medOrders.OrderCode != null)
                    oneUpdate[3].Value = medOrders.OrderCode;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (medOrders.Dosage.ToString() != null)
                    oneUpdate[4].Value = medOrders.Dosage;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (medOrders.DosageUnits != null)
                    oneUpdate[5].Value = medOrders.DosageUnits;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (medOrders.Administration != null)
                    oneUpdate[6].Value = medOrders.Administration;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (medOrders.StartDateTime > DateTime.MinValue)
                    oneUpdate[7].Value = medOrders.StartDateTime;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (medOrders.StopDateTime > DateTime.MinValue)
                    oneUpdate[8].Value = medOrders.StopDateTime;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (medOrders.Duration.ToString() != null)
                    oneUpdate[9].Value = medOrders.Duration;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (medOrders.DurationUnits != null)
                    oneUpdate[10].Value = medOrders.DurationUnits;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (medOrders.Frequency != null)
                    oneUpdate[11].Value = medOrders.Frequency;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (medOrders.FreqCounter.ToString() != null)
                    oneUpdate[12].Value = medOrders.FreqCounter;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (medOrders.FreqInterval.ToString() != null)
                    oneUpdate[13].Value = medOrders.FreqInterval;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (medOrders.FreqIntervalUnit != null)
                    oneUpdate[14].Value = medOrders.FreqIntervalUnit;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (medOrders.FreqDetail != null)
                    oneUpdate[15].Value = medOrders.FreqDetail;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (medOrders.PerformSchedule != null)
                    oneUpdate[16].Value = medOrders.PerformSchedule;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (medOrders.PerformResult != null)
                    oneUpdate[17].Value = medOrders.PerformResult;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (medOrders.OrderingDept != null)
                    oneUpdate[18].Value = medOrders.OrderingDept;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (medOrders.Doctor != null)
                    oneUpdate[19].Value = medOrders.Doctor;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (medOrders.StopDoctor != null)
                    oneUpdate[20].Value = medOrders.StopDoctor;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (medOrders.Nurse != null)
                    oneUpdate[21].Value = medOrders.Nurse;
                else
                    oneUpdate[21].Value = DBNull.Value;
                if (medOrders.StopNurse != null)
                    oneUpdate[22].Value = medOrders.StopNurse;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (medOrders.EnterDateTime > DateTime.MinValue)
                    oneUpdate[23].Value = medOrders.EnterDateTime;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (medOrders.StopOrderDateTime > DateTime.MinValue)
                    oneUpdate[24].Value = medOrders.StopOrderDateTime;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (medOrders.OrderStatus != null)
                    oneUpdate[25].Value = medOrders.OrderStatus;
                else
                    oneUpdate[25].Value = DBNull.Value;
                oneUpdate[26].Value = medOrders.PatientId;
                oneUpdate[27].Value = medOrders.VisitId;
                oneUpdate[28].Value = medOrders.OrderNo;
                oneUpdate[29].Value = medOrders.OrderSubNo;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_MedOrders_Odbc, oneUpdate);
            }
        }
    }
}
