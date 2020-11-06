using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MedicalSytem.Soft.Model;
using System.Data.OleDb;
using System.Data.Odbc;
using MedicalSytem.Soft.DAL;

namespace MedicalSytem.Soft.DAL
{
    public partial class DALMedAnesthesiaEvent
    {
        private static readonly string Med_Anesthesia_Event_Select_OLE = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,EVENT_NO,ITEM_NAME,ITEM_CODE,ITEM_SPEC,DOSAGE_UNITS,DOSAGE,ADMINISTRATOR,START_TIME,END_DATE,BILL_INDICATOR,DURATIVE_INDICATOR,METHOD,PERFORM_SPEED,SPEED_UNIT,PARENT_ITEM_NO,EVENT_ATTR,CONCENTRATION,CONCENTRATION_UNIT,BILL_ATTR,SUPPLIER_NAME,METHOD_PARENT_NO FROM MED_ANESTHESIA_EVENT WHERE PATIENT_ID = ? AND VISIT_ID = ? AND OPER_ID = ?";
        private static readonly string Med_Anesthesia_Event_Select_ALL_OLE = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,EVENT_NO,ITEM_NAME,ITEM_CODE,ITEM_SPEC,DOSAGE_UNITS,DOSAGE,ADMINISTRATOR,START_TIME,END_DATE,BILL_INDICATOR,DURATIVE_INDICATOR,METHOD,PERFORM_SPEED,SPEED_UNIT,PARENT_ITEM_NO,EVENT_ATTR,CONCENTRATION,CONCENTRATION_UNIT,BILL_ATTR,SUPPLIER_NAME,METHOD_PARENT_NO FROM MED_ANESTHESIA_EVENT";

        #region 获取参数OLE
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedAnesthesiaEventSelect")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("patientId",OleDbType.VarChar),
                        new OleDbParameter("visitId",OleDbType.Decimal),
                        new OleDbParameter("operId",OleDbType.Decimal)
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [获取一条记录OracleOLE]
        /// <summary>
        /// 获取一条记录OracleOLE
        /// </summary>
        /// <param name="PATIENT_ID"></param>
        /// <param name="VISIT_ID"></param>
        /// <param name="OPER_ID"></param>
        /// <returns></returns>
        public MedAnesthesiaEvent SelectMedAnesiaEventOLE(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID)
        {
            MedAnesthesiaEvent model;
            OleDbParameter[] paras = GetParameterOLE("SelectMedAnesthesiaEventSelect");
            paras[0].Value = PATIENT_ID;
            paras[1].Value = VISIT_ID;
            paras[2].Value = OPER_ID;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Med_Anesthesia_Event_Select_OLE, paras))
            {
                if (oleReader.Read())
                {
                    model = new MedAnesthesiaEvent();
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
                        model.EventNo = decimal.Parse(oleReader["EVENT_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ItemName = oleReader["ITEM_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.ItemCode = oleReader["ITEM_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.ItemSpec = oleReader["ITEM_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.DosageUnits = oleReader["DOSAGE_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Dosage = decimal.Parse(oleReader["DOSAGE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Administrator = oleReader["ADMINISTRATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.StartTime = DateTime.Parse(oleReader["START_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.EndDate = DateTime.Parse(oleReader["END_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.BillIndicator = decimal.Parse(oleReader["BILL_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.DurativeIndicator = decimal.Parse(oleReader["DURATIVE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.Method = oleReader["METHOD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.PerformSpeed = decimal.Parse(oleReader["PERFORM_SPEED"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.SpeedUnit = oleReader["SPEED_UNIT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.ParentItemNo = decimal.Parse(oleReader["PARENT_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.EventAttr = oleReader["EVENT_ATTR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.Concentration = decimal.Parse(oleReader["CONCENTRATION"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.ConcetrationUnit = oleReader["CONCENTRATION_UNIT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.BillAttr = decimal.Parse(oleReader["BILL_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.SupplierName = oleReader["SUPPLIER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.MethodParentNo = decimal.Parse(oleReader["METHOD_PARENT_NO"].ToString().Trim());
                    }
                }
                else
                {
                    model = null;
                }
            }
            return model;
        }
        #endregion
        #region [获取全部记录OracleOLE]
        /// <summary>
        /// 获取全部记录OracleOLE
        /// </summary>
        /// <returns></returns>
        public List<MedAnesthesiaEvent> SelectMedAnesiaEventListOLE()
        {
            List<MedAnesthesiaEvent> modelList = new List<MedAnesthesiaEvent>();
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Med_Anesthesia_Event_Select_ALL_OLE, null))
            {
                while (oleReader.Read())
                {
                    MedAnesthesiaEvent model = new MedAnesthesiaEvent();
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
                        model.EventNo = decimal.Parse(oleReader["EVENT_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ItemName = oleReader["ITEM_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.ItemCode = oleReader["ITEM_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.ItemSpec = oleReader["ITEM_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.DosageUnits = oleReader["DOSAGE_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Dosage = decimal.Parse(oleReader["DOSAGE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Administrator = oleReader["ADMINISTRATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.StartTime = DateTime.Parse(oleReader["START_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.EndDate = DateTime.Parse(oleReader["END_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.BillIndicator = decimal.Parse(oleReader["BILL_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.DurativeIndicator = decimal.Parse(oleReader["DURATIVE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.Method = oleReader["METHOD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.PerformSpeed = decimal.Parse(oleReader["PERFORM_SPEED"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.SpeedUnit = oleReader["SPEED_UNIT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.ParentItemNo = decimal.Parse(oleReader["PARENT_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.EventAttr = oleReader["EVENT_ATTR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.Concentration = decimal.Parse(oleReader["CONCENTRATION"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.ConcetrationUnit = oleReader["CONCENTRATION_UNIT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.BillAttr = decimal.Parse(oleReader["BILL_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.SupplierName = oleReader["SUPPLIER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.MethodParentNo = decimal.Parse(oleReader["METHOD_PARENT_NO"].ToString().Trim());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion


        private static readonly string Med_Anesthesia_Event_Select_ODBC = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,EVENT_NO,ITEM_NAME,ITEM_CODE,ITEM_SPEC,DOSAGE_UNITS,DOSAGE,ADMINISTRATOR,START_TIME,END_DATE,BILL_INDICATOR,DURATIVE_INDICATOR,METHOD,PERFORM_SPEED,SPEED_UNIT,PARENT_ITEM_NO,EVENT_ATTR,CONCENTRATION,CONCENTRATION_UNIT,BILL_ATTR,SUPPLIER_NAME,METHOD_PARENT_NO FROM MED_ANESTHESIA_EVENT WHERE PATIENT_ID = ? AND VISIT_ID = ? AND OPER_ID = ?";
        private static readonly string Med_Anesthesia_Event_Select_ALL_ODBC = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,EVENT_NO,ITEM_NAME,ITEM_CODE,ITEM_SPEC,DOSAGE_UNITS,DOSAGE,ADMINISTRATOR,START_TIME,END_DATE,BILL_INDICATOR,DURATIVE_INDICATOR,METHOD,PERFORM_SPEED,SPEED_UNIT,PARENT_ITEM_NO,EVENT_ATTR,CONCENTRATION,CONCENTRATION_UNIT,BILL_ATTR,SUPPLIER_NAME,METHOD_PARENT_NO FROM MED_ANESTHESIA_EVENT";

        #region 获取参数ODBC
        public static OdbcParameter[] GetParameterODBC(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedAnesthesiaEventSelect")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("patientId",OdbcType.VarChar),
                        new OdbcParameter("visitId",OdbcType.Decimal),
                        new OdbcParameter("operId",OdbcType.Decimal)
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [获取一条记录OracleODBC]
        /// <summary>
        /// 获取一条记录OracleOLE
        /// </summary>
        /// <param name="PATIENT_ID"></param>
        /// <param name="VISIT_ID"></param>
        /// <param name="OPER_ID"></param>
        /// <returns></returns>
        public MedAnesthesiaEvent SelectMedAnesiaEventODBC(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID)
        {
            MedAnesthesiaEvent model;
            OdbcParameter[] paras = GetParameterODBC("SelectMedAnesthesiaEventSelect");
            paras[0].Value = PATIENT_ID;
            paras[1].Value = VISIT_ID;
            paras[2].Value = OPER_ID;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Med_Anesthesia_Event_Select_OLE, paras))
            {
                if (oleReader.Read())
                {
                    model = new MedAnesthesiaEvent();
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
                        model.EventNo = decimal.Parse(oleReader["EVENT_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ItemName = oleReader["ITEM_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.ItemCode = oleReader["ITEM_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.ItemSpec = oleReader["ITEM_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.DosageUnits = oleReader["DOSAGE_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Dosage = decimal.Parse(oleReader["DOSAGE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Administrator = oleReader["ADMINISTRATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.StartTime = DateTime.Parse(oleReader["START_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.EndDate = DateTime.Parse(oleReader["END_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.BillIndicator = decimal.Parse(oleReader["BILL_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.DurativeIndicator = decimal.Parse(oleReader["DURATIVE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.Method = oleReader["METHOD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.PerformSpeed = decimal.Parse(oleReader["PERFORM_SPEED"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.SpeedUnit = oleReader["SPEED_UNIT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.ParentItemNo = decimal.Parse(oleReader["PARENT_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.EventAttr = oleReader["EVENT_ATTR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.Concentration = decimal.Parse(oleReader["CONCENTRATION"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.ConcetrationUnit = oleReader["CONCENTRATION_UNIT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.BillAttr = decimal.Parse(oleReader["BILL_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.SupplierName = oleReader["SUPPLIER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.MethodParentNo = decimal.Parse(oleReader["METHOD_PARENT_NO"].ToString().Trim());
                    }
                }
                else
                {
                    model = null;
                }
            }
            return model;
        }
        #endregion
        #region [获取全部记录OracleODBC]
        /// <summary>
        /// 获取全部记录OracleOLE
        /// </summary>
        /// <returns></returns>
        public List<MedAnesthesiaEvent> SelectMedAnesiaEventListODBC()
        {
            List<MedAnesthesiaEvent> modelList = new List<MedAnesthesiaEvent>();
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Med_Anesthesia_Event_Select_ALL_OLE, null))
            {
                while (oleReader.Read())
                {
                    MedAnesthesiaEvent model = new MedAnesthesiaEvent();
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
                        model.EventNo = decimal.Parse(oleReader["EVENT_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.ItemName = oleReader["ITEM_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.ItemCode = oleReader["ITEM_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.ItemSpec = oleReader["ITEM_SPEC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.DosageUnits = oleReader["DOSAGE_UNITS"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Dosage = decimal.Parse(oleReader["DOSAGE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Administrator = oleReader["ADMINISTRATOR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.StartTime = DateTime.Parse(oleReader["START_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.EndDate = DateTime.Parse(oleReader["END_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.BillIndicator = decimal.Parse(oleReader["BILL_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.DurativeIndicator = decimal.Parse(oleReader["DURATIVE_INDICATOR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.Method = oleReader["METHOD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.PerformSpeed = decimal.Parse(oleReader["PERFORM_SPEED"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(18))
                    {
                        model.SpeedUnit = oleReader["SPEED_UNIT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(19))
                    {
                        model.ParentItemNo = decimal.Parse(oleReader["PARENT_ITEM_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(20))
                    {
                        model.EventAttr = oleReader["EVENT_ATTR"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(21))
                    {
                        model.Concentration = decimal.Parse(oleReader["CONCENTRATION"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(22))
                    {
                        model.ConcetrationUnit = oleReader["CONCENTRATION_UNIT"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(23))
                    {
                        model.BillAttr = decimal.Parse(oleReader["BILL_ATTR"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(24))
                    {
                        model.SupplierName = oleReader["SUPPLIER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(25))
                    {
                        model.MethodParentNo = decimal.Parse(oleReader["METHOD_PARENT_NO"].ToString().Trim());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
    }
}
