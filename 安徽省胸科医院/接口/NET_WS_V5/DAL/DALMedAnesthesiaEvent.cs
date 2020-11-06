using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OracleClient;
using MedicalSytem.Soft.Model;

//**************2012年9月10日新增
namespace MedicalSytem.Soft.DAL
{
    public partial class DALMedAnesthesiaEvent
    {
        private static readonly string Med_Anesthesia_Event_Select = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,EVENT_NO,ITEM_NAME,ITEM_CODE,ITEM_SPEC,DOSAGE_UNITS,DOSAGE,ADMINISTRATOR,START_TIME,END_DATE,BILL_INDICATOR,DURATIVE_INDICATOR,METHOD,PERFORM_SPEED,SPEED_UNIT,PARENT_ITEM_NO,EVENT_ATTR,CONCENTRATION,CONCENTRATION_UNIT,BILL_ATTR,SUPPLIER_NAME,METHOD_PARENT_NO FROM MED_ANESTHESIA_EVENT WHERE PATIENT_ID = :PATIENT_ID AND VISIT_ID = :VISIT_ID AND OPER_ID = :OPER_ID";
        private static readonly string Med_Anesthesia_Event_Select_SQL = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,EVENT_NO,ITEM_NAME,ITEM_CODE,ITEM_SPEC,DOSAGE_UNITS,DOSAGE,ADMINISTRATOR,START_TIME,END_DATE,BILL_INDICATOR,DURATIVE_INDICATOR,METHOD,PERFORM_SPEED,SPEED_UNIT,PARENT_ITEM_NO,EVENT_ATTR,CONCENTRATION,CONCENTRATION_UNIT,BILL_ATTR,SUPPLIER_NAME,METHOD_PARENT_NO FROM MED_ANESTHESIA_EVENT WHERE PATIENT_ID = @PATIENT_ID AND VISIT_ID = @VISIT_ID AND OPER_ID = @OPER_ID";
        private static readonly string Med_Anesthesia_Event_Select_ALL = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,EVENT_NO,ITEM_NAME,ITEM_CODE,ITEM_SPEC,DOSAGE_UNITS,DOSAGE,ADMINISTRATOR,START_TIME,END_DATE,BILL_INDICATOR,DURATIVE_INDICATOR,METHOD,PERFORM_SPEED,SPEED_UNIT,PARENT_ITEM_NO,EVENT_ATTR,CONCENTRATION,CONCENTRATION_UNIT,BILL_ATTR,SUPPLIER_NAME,METHOD_PARENT_NO FROM MED_ANESTHESIA_EVENT";
        private static readonly string Med_Anesthesia_Event_Select_ALL_SQL = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,ITEM_NO,ITEM_CLASS,EVENT_NO,ITEM_NAME,ITEM_CODE,ITEM_SPEC,DOSAGE_UNITS,DOSAGE,ADMINISTRATOR,START_TIME,END_DATE,BILL_INDICATOR,DURATIVE_INDICATOR,METHOD,PERFORM_SPEED,SPEED_UNIT,PARENT_ITEM_NO,EVENT_ATTR,CONCENTRATION,CONCENTRATION_UNIT,BILL_ATTR,SUPPLIER_NAME,METHOD_PARENT_NO FROM MED_ANESTHESIA_EVENT";

        
        #region [获取参数Oracle]
        public static OracleParameter[] GetParameterOracle(string sqlparm)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlparm);
            if (parms == null)
            {
                switch (sqlparm)
                {
                    case "SelectMedAnesthesiaEventSelect":
                        parms = new OracleParameter[]{
                               new OracleParameter(":PATIENT_ID",OracleType.VarChar),
                               new OracleParameter(":VISIT_ID",OracleType.Number),
                               new OracleParameter(":OPER_ID",OracleType.Number)

                             };
                        break;
                    default:
                        parms = null;
                        break;
                }
                OracleHelper.CacheParameters(sqlparm, parms);
            }
            return parms;
        }
        #endregion
        #region [获取一条记录Oracle]
        /// <summary>
        /// 获取一条记录Oracle
        /// </summary>
        /// <param name="PATIENT_ID"></param>
        /// <param name="VISIT_ID"></param>
        /// <param name="OPER_ID"></param>
        /// <returns></returns>
        public MedAnesthesiaEvent SelectMedAnesiaEvent(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID)
        {
            MedAnesthesiaEvent model=null;
            OracleParameter[] paras = GetParameterOracle("SelectMedAnesthesiaEventSelect");
            paras[0].Value = PATIENT_ID;
            paras[1].Value = VISIT_ID;
            paras[2].Value = OPER_ID;
           // List<MedAnesthesiaEvent> reult=new List<MedAnesthesiaEvent>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, Med_Anesthesia_Event_Select, paras))
            {
               while (oleReader.Read())
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
                  // reult.Add(model);
                }
             
            }
            return model;
        }
        #endregion
        #region [获取全部记录Oracle]
        /// <summary>
        /// 获取全部记录Oracle
        /// </summary>
        /// <returns></returns>
        public List<MedAnesthesiaEvent> SelectMedAnesiaEventListOracle()
        {
            List<MedAnesthesiaEvent> modelList = new List<MedAnesthesiaEvent>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, Med_Anesthesia_Event_Select_ALL, null))
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

        #region [获取参数SQL]
        public static SqlParameter[] GetParameterSQL(string sqlparm)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlparm);
            if (parms == null)
            {
                switch (sqlparm)
                {
                    case "SelectMedAnesthesiaEventSelect":
                        parms = new SqlParameter[]{
                               new SqlParameter("@PATIENT_ID",SqlDbType.VarChar),
                               new SqlParameter("@VISIT_ID",SqlDbType.Decimal),
                               new SqlParameter("@OPER_ID",SqlDbType.Decimal)

                             };
                        break;
                    default:
                        parms = null;
                        break;
                }
                SqlHelper.CacheParameters(sqlparm, parms);
            }
            return parms;
        }
        #endregion
        #region [获取一条记录SQL]
        /// <summary>
        /// 获取一条记录SQL
        /// </summary>
        /// <param name="PATIENT_ID"></param>
        /// <param name="VISIT_ID"></param>
        /// <param name="OPER_ID"></param>
        /// <returns></returns>
        public MedAnesthesiaEvent SelectMedAnesiaEventSQL(string PATIENT_ID, decimal VISIT_ID, decimal OPER_ID)
        {
            MedAnesthesiaEvent model;
            SqlParameter[] paras = GetParameterSQL("SelectMedAnesthesiaEventSelect");
            paras[0].Value = PATIENT_ID;
            paras[1].Value = VISIT_ID;
            paras[2].Value = OPER_ID;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, Med_Anesthesia_Event_Select_SQL, paras))
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
        #region [获取全部记录SQL]
        /// <summary>
        /// 获取全部记录SQL
        /// </summary>
        /// <returns></returns>
        public List<MedAnesthesiaEvent> SelectMedAnesiaEventListSQL()
        {
            List<MedAnesthesiaEvent> modelList = new List<MedAnesthesiaEvent>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, Med_Anesthesia_Event_Select_ALL_SQL, null))
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
