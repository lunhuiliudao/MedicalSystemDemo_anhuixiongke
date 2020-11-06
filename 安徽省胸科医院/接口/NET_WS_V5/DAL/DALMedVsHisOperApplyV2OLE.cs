using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedVsHisOperApplyV2
    /// </summary>

    public partial class DALMedVsHisOperApplyV2
    {
        private static readonly string Select_Count_MED_VS_HIS_OPER_APPLY_V2_ReqDateTime_OLE = "select Count(*) from MED_VS_HIS_OPER_APPLY_V2 where his_apply_no = ? and his_patient_id = ? and his_visit_id = ? and his_schedule_id = ? and req_date_time = ?";
        private static readonly string Select_Count_MED_VS_HIS_OPER_APPLY_V2_OLE = "select Count(*) from MED_VS_HIS_OPER_APPLY_V2 where his_apply_no = ? and his_patient_id = ? and his_visit_id = ? and his_schedule_id = ?";
        private static readonly string Select_MED_VS_HIS_OPER_APPLY_V2_His_OLE = "select med_patient_id, med_visit_id, med_schedule_id, his_apply_no, his_patient_id, his_visit_id, his_schedule_id, req_date_time from MED_VS_HIS_OPER_APPLY_V2 where his_apply_no = ? and his_patient_id = ? and his_visit_id = ? and his_schedule_id = ?";

        private static readonly string Select_MED_VS_HIS_OPER_APPLY_V2_His_OLE_List = "select med_patient_id, med_visit_id, med_schedule_id, his_apply_no, his_patient_id, his_visit_id, his_schedule_id, req_date_time from MED_VS_HIS_OPER_APPLY_V2 where  his_patient_id = ? and his_visit_id = ? ";

        private static readonly string Select_MED_VS_HIS_OPER_APPLY_V2_OLE = "select med_patient_id, med_visit_id, med_schedule_id, his_apply_no, his_patient_id, his_visit_id, his_schedule_id, req_date_time from MED_VS_HIS_OPER_APPLY_V2 where med_patient_id = ? and med_visit_id = ? and med_schedule_id = ?";
        private static readonly string Insert_MED_VS_HIS_OPER_APPLY_V2_OLE = "insert into MED_VS_HIS_OPER_APPLY_V2 (med_patient_id, med_visit_id, med_schedule_id, his_apply_no, his_patient_id, his_visit_id, his_schedule_id, req_date_time) values(?, ?, ?, ?, ?, ?, ?, ?) ";
        private static readonly string Update_MED_VS_HIS_OPER_APPLY_V2_OLE = "update MED_VS_HIS_OPER_APPLY_V2 set his_apply_no = ? ,his_patient_id = ? ,his_visit_id = ?, his_schedule_id = ?, req_date_time = ? where med_patient_id = ? and  med_visit_id = ? and med_schedule_id = ?";
        private static readonly string Delete_MED_VS_HIS_OPER_APPLY_V2_OLE = "Delete MED_VS_HIS_OPER_APPLY_V2 WHERE med_patient_id= ? AND med_visit_id= ? AND med_schedule_id= ?";
        
        public static OleDbParameter[] GetParameterOLE(string sqlParams)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParams);
            if (parms == null)
            {
                if (sqlParams == "SelectMedVsHisOperApplyHis" || sqlParams == "SelectCountMedVsHisOperApplyHis")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("hisApplyNo",OleDbType.VarChar),
                        new OleDbParameter("hisPatientId",OleDbType.VarChar),
                        new OleDbParameter("hisVisitId",OleDbType.VarChar),
                        new OleDbParameter("hisScheduleId",OleDbType.Decimal)
                    };
                }
                else if (sqlParams == "InsertMedVsHisOperApply")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("medPatientId",OleDbType.VarChar),
                        new OleDbParameter("medVisitId",OleDbType.Decimal),
                        new OleDbParameter("medScheduleId",OleDbType.Decimal),
                        new OleDbParameter("hisApplyNo",OleDbType.VarChar),
                        new OleDbParameter("hisPatientId",OleDbType.VarChar),
                        new OleDbParameter("hisVisitId",OleDbType.VarChar),
                        new OleDbParameter("hisScheduleId",OleDbType.Decimal),
                        new OleDbParameter("reqDateTime",OleDbType.VarChar)
                    };
                }
                else if (sqlParams == "UpdateMedVsHisOperApply")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("hisApplyNo",OleDbType.VarChar),
                        new OleDbParameter("hisPatientId",OleDbType.VarChar),
                        new OleDbParameter("hisVisitId",OleDbType.VarChar),
                        new OleDbParameter("hisScheduleId",OleDbType.Decimal),
                        new OleDbParameter("reqDateTime",OleDbType.VarChar),
                        new OleDbParameter("medPatientId",OleDbType.VarChar),
                        new OleDbParameter("medVisitId",OleDbType.Decimal),
                        new OleDbParameter("medScheduleId",OleDbType.Decimal)
                    };
                }
                else if (sqlParams == "SelectCountMedVsHisOperApplyReqDateTime")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("hisApplyNo",OleDbType.VarChar),
                        new OleDbParameter("hisPatientId",OleDbType.VarChar),
                        new OleDbParameter("hisVisitId",OleDbType.VarChar),
                        new OleDbParameter("hisScheduleId",OleDbType.Decimal),
                        new OleDbParameter("reqDateTime",OleDbType.VarChar)
                    };
                }
                else if (sqlParams == "SelectMedVsHisOperApply")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("medPatientId",OleDbType.VarChar),
                        new OleDbParameter("medVisitId",OleDbType.Decimal),
                        new OleDbParameter("medScheduleId",OleDbType.Decimal)
                    };
                }
                else if (sqlParams == "DeleteMedVsHisOperApply")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("medPatientId",OleDbType.VarChar),
                        new OleDbParameter("medVisitId",OleDbType.Decimal),
                        new OleDbParameter("medScheduleId",OleDbType.Decimal)
                    };
                }
                else if (sqlParams == "SelectMedVsHisOperApplyHisList")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("hisPatientId",OleDbType.VarChar),
                        new OleDbParameter("hisVisitId",OleDbType.VarChar)
                    };
                
                }
                OleDbHelper.CacheParameters(sqlParams, parms);
            }
            return parms;
        }
        /// <summary>
        /// 根据HIS下申请日期REQ_DATE_TIME HIS手术流水号  HIS病人ID号 HIS的住院号 确认是否有记录
        /// </summary>
        /// <param name="hisApplyNo">HIS手术流水号</param>
        /// <param name="hisPatientId">HIS病人ID号</param>
        /// <param name="hisVisitId">HIS的住院号</param>
        /// <param name="hisScheduleId">HIS手术流水号</param>
        /// <param name="reqDateTime">HIS下申请日期REQ_DATE_TIME</param>
        /// <returns></returns>
        public int SelectCountMedVsHisOperApplyV2ReqDateTimeOLE(string hisApplyNo, string hisPatientId, string hisVisitId, decimal hisScheduleId, string reqDateTime)
        {
            OleDbParameter[] medVsHisOperApplyParams = GetParameterOLE("SelectCountMedVsHisOperApplyReqDateTime");
            medVsHisOperApplyParams[0].Value = hisApplyNo;
            medVsHisOperApplyParams[1].Value = hisPatientId;
            medVsHisOperApplyParams[2].Value = hisVisitId;
            medVsHisOperApplyParams[3].Value = hisScheduleId;
            medVsHisOperApplyParams[4].Value = reqDateTime;

            object count = OleDbHelper.ExecuteScalar(OleDbHelper.ConnectionString, CommandType.Text, Select_Count_MED_VS_HIS_OPER_APPLY_V2_ReqDateTime_OLE, medVsHisOperApplyParams);
            if (count == null)
                count = (object)0;
            return Convert.ToInt32(count);
        }
        /// <summary>
        /// 根据HIS手术流水号  HIS病人ID号 HIS的住院号 确认是否有记录
        /// </summary>
        /// <param name="hisApplyNo">HIS手术流水号</param>
        /// <param name="hisPatientId">HIS病人ID号</param>
        /// <param name="hisVisitId">HIS的住院号</param>
        /// <param name="hisScheduleId">HIS手术流水号</param>
        /// <returns></returns>
        public int SelectCountMedVsHisOperApplyV2HisOLE(string hisApplyNo, string hisPatientId, string hisVisitId, string  hisScheduleId)
        {
            OleDbParameter[] medVsHisOperApplyParams = GetParameterOLE("SelectCountMedVsHisOperApplyHis");
            medVsHisOperApplyParams[0].Value = hisApplyNo;
            medVsHisOperApplyParams[1].Value = hisPatientId;
            medVsHisOperApplyParams[2].Value = hisVisitId;
            medVsHisOperApplyParams[3].Value = hisScheduleId;

            object count = OleDbHelper.ExecuteScalar(OleDbHelper.ConnectionString, CommandType.Text, Select_Count_MED_VS_HIS_OPER_APPLY_V2_OLE, medVsHisOperApplyParams);
            if (count == null)
                count = (object)0;
            return Convert.ToInt32(count);
        }

        /// <summary>
        /// 获取MED_VS_HIS_OPER_APPLY_V2记录(HIS手术流水号  HIS病人ID号 HIS的住院号)
        /// </summary>
        /// <param name="hisApplyNo">HIS手术流水号</param>
        /// <param name="hisPatientId">HIS病人ID号</param>
        /// <param name="hisVisitId">HIS的住院号</param>
        /// <param name="hisScheduleId">HIS手术流水号</param>
        /// <returns></returns>
       
        public List<Model.MedVsHisOperApplyV2> SelectMedVsHisOperApplyV2HisOLEList(string hisPatientId, string hisVisitId)
        {
            List<Model.MedVsHisOperApplyV2> result = new List<MedVsHisOperApplyV2>();
            OleDbParameter[] medVsHisOperApplyParams = GetParameterOLE("SelectMedVsHisOperApplyHisList");
      
            medVsHisOperApplyParams[0].Value = hisPatientId;
            medVsHisOperApplyParams[1].Value = hisVisitId;


            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MED_VS_HIS_OPER_APPLY_V2_His_OLE_List, medVsHisOperApplyParams))
            {
                while (oleReader.Read())
                {
                    MedVsHisOperApplyV2 oneMedVsHisOperApply = new Model.MedVsHisOperApplyV2();
                    if (!oleReader.IsDBNull(0))
                        oneMedVsHisOperApply.MedPatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisOperApply.MedVisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisOperApply.MedScheduleId = oleReader.GetDecimal(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisOperApply.HisApplyNo = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisOperApply.HisPatientId = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisOperApply.HisVisitId = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisOperApply.HisScheduleId = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisOperApply.ReqDateTime = oleReader.GetString(7);
                    result.Add(oneMedVsHisOperApply);
                }
               
            }
            return result;
        }

        /// <summary>
        /// 获取MED_VS_HIS_OPER_APPLY_V2记录(HIS手术流水号  HIS病人ID号 HIS的住院号)
        /// </summary>
        /// <param name="hisApplyNo">HIS手术流水号</param>
        /// <param name="hisPatientId">HIS病人ID号</param>
        /// <param name="hisVisitId">HIS的住院号</param>
        /// <param name="hisScheduleId">HIS手术流水号</param>
        /// <returns></returns>
        public Model.MedVsHisOperApplyV2 SelectMedVsHisOperApplyV2HisOLE(string hisApplyNo, string hisPatientId, string hisVisitId, string  hisScheduleId)
        {
            Model.MedVsHisOperApplyV2 oneMedVsHisOperApply = null;
            OleDbParameter[] medVsHisOperApplyParams = GetParameterOLE("SelectMedVsHisOperApplyHis");
            medVsHisOperApplyParams[0].Value = hisApplyNo;
            medVsHisOperApplyParams[1].Value = hisPatientId;
            medVsHisOperApplyParams[2].Value = hisVisitId;
            medVsHisOperApplyParams[3].Value = hisScheduleId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MED_VS_HIS_OPER_APPLY_V2_His_OLE, medVsHisOperApplyParams))
            {
                if (oleReader.Read())
                {
                    oneMedVsHisOperApply = new Model.MedVsHisOperApplyV2();
                    if (!oleReader.IsDBNull(0))
                        oneMedVsHisOperApply.MedPatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisOperApply.MedVisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisOperApply.MedScheduleId = oleReader.GetDecimal(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisOperApply.HisApplyNo = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisOperApply.HisPatientId = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisOperApply.HisVisitId = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisOperApply.HisScheduleId = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisOperApply.ReqDateTime = oleReader.GetString(7);
                }
                else
                    oneMedVsHisOperApply = null;
            }
            return oneMedVsHisOperApply;
        }
     
        /// <summary>
        /// 获取MED_VS_HIS_OPER_APPLY_V2记录(根据主索引)
        /// </summary>
        /// <param name="medPatientId">病人ID号</param>
        /// <param name="medVisitId">病人住院次数</param>
        /// <param name="medScheduleId">本次手术次数</param>
        /// <returns></returns>
        public Model.MedVsHisOperApplyV2 SelectMedVsHisOperApplyV2OLE(string medPatientId, decimal medVisitId, decimal medScheduleId)
        {
            Model.MedVsHisOperApplyV2 oneMedVsHisOperApply = null;
            OleDbParameter[] medVsHisOperApplyParams = GetParameterOLE("SelectMedVsHisOperApply");
            medVsHisOperApplyParams[0].Value = medPatientId;
            medVsHisOperApplyParams[1].Value = medVisitId;
            medVsHisOperApplyParams[2].Value = medScheduleId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MED_VS_HIS_OPER_APPLY_V2_OLE, medVsHisOperApplyParams))
            {
                if (oleReader.Read())
                {
                    oneMedVsHisOperApply = new Model.MedVsHisOperApplyV2();
                    if (!oleReader.IsDBNull(0))
                        oneMedVsHisOperApply.MedPatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisOperApply.MedVisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisOperApply.MedScheduleId = oleReader.GetDecimal(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisOperApply.HisApplyNo = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisOperApply.HisPatientId = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisOperApply.HisVisitId = oleReader.GetString(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisOperApply.HisScheduleId = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisOperApply.ReqDateTime = oleReader.GetString(7);
                }
                else
                    oneMedVsHisOperApply = null;
            }
            return oneMedVsHisOperApply;
        }
        /// <summary>
        /// 插入MED_VS_HIS_OPER_APPLY_V2记录
        /// </summary>
        /// <param name="oneMedVsHisOperApply">MED_VS_HIS_OPER_APPLY_V2实体类</param>
        /// <returns></returns>
        public int InsertMedVsHisOperApplyV2OLE(Model.MedVsHisOperApplyV2 oneMedVsHisOperApply)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedVsHisOperApply");
                oneInert[0].Value = oneMedVsHisOperApply.MedPatientId;
                oneInert[1].Value = oneMedVsHisOperApply.MedVisitId;
                oneInert[2].Value = oneMedVsHisOperApply.MedScheduleId;
                if (oneMedVsHisOperApply.HisApplyNo != null)
                    oneInert[3].Value = oneMedVsHisOperApply.HisApplyNo;
                else
                    oneInert[3].Value = DBNull.Value;
                if (oneMedVsHisOperApply.HisPatientId != null)
                    oneInert[4].Value = oneMedVsHisOperApply.HisPatientId;
                else
                    oneInert[4].Value = DBNull.Value;
                if (oneMedVsHisOperApply.HisVisitId.ToString() != null)
                    oneInert[5].Value = oneMedVsHisOperApply.HisVisitId;
                else
                    oneInert[5].Value = DBNull.Value;
                if (oneMedVsHisOperApply.HisScheduleId.ToString() != null)
                    oneInert[6].Value = oneMedVsHisOperApply.HisScheduleId;
                else
                    oneInert[6].Value = DBNull.Value;
                if (oneMedVsHisOperApply.ReqDateTime != null)
                    oneInert[7].Value = oneMedVsHisOperApply.ReqDateTime;
                else
                    oneInert[7].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_MED_VS_HIS_OPER_APPLY_V2_OLE, oneInert);
            }
        }
        /// <summary>
        /// 更新MED_VS_HIS_OPER_APPLY_V2记录
        /// </summary>
        /// <param name="oneMedVsHisOperApply">MED_VS_HIS_OPER_APPLY_V2实体类</param>
        /// <returns></returns>
        public int UpdateMedVsHisOperApplyV2OLE(Model.MedVsHisOperApplyV2 oneMedVsHisOperApply)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedVsHisOperApply");

                if (oneMedVsHisOperApply.HisApplyNo != null)
                    oneUpdate[0].Value = oneMedVsHisOperApply.HisApplyNo;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (oneMedVsHisOperApply.HisPatientId != null)
                    oneUpdate[1].Value = oneMedVsHisOperApply.HisPatientId;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (oneMedVsHisOperApply.HisVisitId.ToString() != null)
                    oneUpdate[2].Value = oneMedVsHisOperApply.HisVisitId;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (oneMedVsHisOperApply.HisScheduleId.ToString() != null)
                    oneUpdate[3].Value = oneMedVsHisOperApply.HisScheduleId;
                else
                    oneUpdate[3].Value = DBNull.Value;
                oneUpdate[4].Value = oneMedVsHisOperApply.ReqDateTime;
                oneUpdate[5].Value = oneMedVsHisOperApply.MedPatientId;
                oneUpdate[6].Value = oneMedVsHisOperApply.MedVisitId;
                oneUpdate[7].Value = oneMedVsHisOperApply.MedScheduleId;
                

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_MED_VS_HIS_OPER_APPLY_V2_OLE, oneUpdate);
            }
        }
        /// <summary>
        ///Delete    model  MedVsHisOperApplyV2 
        ///Delete Table MED_VS_HIS_OPER_APPLY_V2 by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_SCHEDULE_ID)
        /// </summary>
        public int DeleteMedVsHisOperApplyV2OLE(string medPatientId, decimal medVisitId, decimal medScheduleId)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedVsHisOperApply");
                if (medPatientId != null)
                    oneDelete[0].Value = medPatientId;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (medVisitId.ToString() != null)
                    oneDelete[1].Value = medVisitId;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (medScheduleId.ToString() != null)
                    oneDelete[2].Value = medScheduleId;
                else
                    oneDelete[2].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, Delete_MED_VS_HIS_OPER_APPLY_V2_OLE, oneDelete);
            }
        }

        private static readonly string Select_Count_MED_VS_HIS_OPER_APPLY_V2_ReqDateTime_Odbc = "select Count(*) from MED_VS_HIS_OPER_APPLY_V2 where his_apply_no = ? and his_patient_id = ? and his_visit_id = ? and his_schedule_id = ? and req_date_time = ?";
        private static readonly string Select_Count_MED_VS_HIS_OPER_APPLY_V2_Odbc = "select Count(*) from MED_VS_HIS_OPER_APPLY_V2 where his_apply_no = ? and his_patient_id = ? and his_visit_id = ? and his_schedule_id = ?";
        private static readonly string Select_MED_VS_HIS_OPER_APPLY_V2_His_Odbc = "select med_patient_id, med_visit_id, med_schedule_id, his_apply_no, his_patient_id, his_visit_id, his_schedule_id, req_date_time from MED_VS_HIS_OPER_APPLY_V2 where his_apply_no = ? and his_patient_id = ? and his_visit_id = ? and his_schedule_id = ?";
        private static readonly string Select_MED_VS_HIS_OPER_APPLY_V2_Odbc = "select med_patient_id, med_visit_id, med_schedule_id, his_apply_no, his_patient_id, his_visit_id, his_schedule_id, req_date_time from MED_VS_HIS_OPER_APPLY_V2 where med_patient_id = ? and med_visit_id = ? and med_schedule_id = ?";
        private static readonly string Insert_MED_VS_HIS_OPER_APPLY_V2_Odbc = "insert into MED_VS_HIS_OPER_APPLY_V2 (med_patient_id, med_visit_id, med_schedule_id, his_apply_no, his_patient_id, his_visit_id, his_schedule_id, req_date_time) values(?, ?, ?, ?, ?, ?, ?, ?) ";
        private static readonly string Update_MED_VS_HIS_OPER_APPLY_V2_Odbc = "update MED_VS_HIS_OPER_APPLY_V2 set his_apply_no = ? ,his_patient_id = ? ,his_visit_id = ?, his_schedule_id = ?, req_date_time = ? where med_patient_id = ? and  med_visit_id = ? and med_schedule_id = ?";
        private static readonly string Delete_MED_VS_HIS_OPER_APPLY_V2_Odbc = "Delete MED_VS_HIS_OPER_APPLY_V2 WHERE med_patient_id= ? AND med_visit_id= ? AND med_schedule_id= ?";
        
        public static OdbcParameter[] GetParameterOdbc(string sqlParams)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParams);
            if (parms == null)
            {
                if (sqlParams == "SelectMedVsHisOperApplyHis" || sqlParams == "SelectCountMedVsHisOperApplyHis")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("hisApplyNo",OdbcType.VarChar),
                        new OdbcParameter("hisPatientId",OdbcType.VarChar),
                        new OdbcParameter("hisVisitId",OdbcType.VarChar),
                        new OdbcParameter("hisScheduleId",OdbcType.Decimal)
                    };
                }
                else if (sqlParams == "InsertMedVsHisOperApply")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("medPatientId",OdbcType.VarChar),
                        new OdbcParameter("medVisitId",OdbcType.Decimal),
                        new OdbcParameter("medScheduleId",OdbcType.Decimal),
                        new OdbcParameter("hisApplyNo",OdbcType.VarChar),
                        new OdbcParameter("hisPatientId",OdbcType.VarChar),
                        new OdbcParameter("hisVisitId",OdbcType.VarChar),
                        new OdbcParameter("hisScheduleId",OdbcType.Decimal),
                        new OdbcParameter("reqDateTime",OdbcType.VarChar)
                    };
                }
                else if (sqlParams == "UpdateMedVsHisOperApply")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("hisApplyNo",OdbcType.VarChar),
                        new OdbcParameter("hisPatientId",OdbcType.VarChar),
                        new OdbcParameter("hisVisitId",OdbcType.VarChar),
                        new OdbcParameter("hisScheduleId",OdbcType.Decimal),
                        new OdbcParameter("reqDateTime",OdbcType.VarChar),
                        new OdbcParameter("medPatientId",OdbcType.VarChar),
                        new OdbcParameter("medVisitId",OdbcType.Decimal),
                        new OdbcParameter("medScheduleId",OdbcType.Decimal)
                    };
                }
                else if (sqlParams == "SelectCountMedVsHisOperApplyReqDateTime")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("hisApplyNo",OdbcType.VarChar),
                        new OdbcParameter("hisPatientId",OdbcType.VarChar),
                        new OdbcParameter("hisVisitId",OdbcType.VarChar),
                        new OdbcParameter("hisScheduleId",OdbcType.Decimal),
                        new OdbcParameter("reqDateTime",OdbcType.VarChar)
                    };
                }
                else if (sqlParams == "SelectMedVsHisOperApply")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("medPatientId",OdbcType.VarChar),
                        new OdbcParameter("medVisitId",OdbcType.Decimal),
                        new OdbcParameter("medScheduleId",OdbcType.Decimal)
                    };
                }
                else if (sqlParams == "DeleteMedVsHisOperApply")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("medPatientId",OdbcType.VarChar),
                        new OdbcParameter("medVisitId",OdbcType.Decimal),
                        new OdbcParameter("medScheduleId",OdbcType.Decimal)
                    };
                }
                OdbcHelper.CacheParameters(sqlParams, parms);
            }
            return parms;
        }
        /// <summary>
        /// 根据HIS下申请日期REQ_DATE_TIME HIS手术流水号  HIS病人ID号 HIS的住院号 确认是否有记录
        /// </summary>
        /// <param name="hisApplyNo">HIS手术流水号</param>
        /// <param name="hisPatientId">HIS病人ID号</param>
        /// <param name="hisVisitId">HIS的住院号</param>
        /// <param name="hisScheduleId">HIS手术流水号</param>
        /// <param name="reqDateTime">HIS下申请日期REQ_DATE_TIME</param>
        /// <returns></returns>
        public int SelectCountMedVsHisOperApplyV2ReqDateTimeOdbc(string hisApplyNo, string hisPatientId, string hisVisitId, decimal hisScheduleId, string reqDateTime)
        {
            OdbcParameter[] medVsHisOperApplyParams = GetParameterOdbc("SelectCountMedVsHisOperApplyReqDateTime");
            medVsHisOperApplyParams[0].Value = hisApplyNo;
            medVsHisOperApplyParams[1].Value = hisPatientId;
            medVsHisOperApplyParams[2].Value = hisVisitId;
            medVsHisOperApplyParams[3].Value = hisScheduleId;
            medVsHisOperApplyParams[4].Value = reqDateTime;

            object count = OdbcHelper.ExecuteScalar(OdbcHelper.ConnectionString, CommandType.Text, Select_Count_MED_VS_HIS_OPER_APPLY_V2_ReqDateTime_Odbc, medVsHisOperApplyParams);
            if (count == null)
                count = (object)0;
            return Convert.ToInt32(count);
        }
        /// <summary>
        /// 根据HIS手术流水号  HIS病人ID号 HIS的住院号 确认是否有记录
        /// </summary>
        /// <param name="hisApplyNo">HIS手术流水号</param>
        /// <param name="hisPatientId">HIS病人ID号</param>
        /// <param name="hisVisitId">HIS的住院号</param>
        /// <param name="hisScheduleId">HIS手术流水号</param>
        /// <returns></returns>
        public int SelectCountMedVsHisOperApplyV2HisOdbc(string hisApplyNo, string hisPatientId, string hisVisitId, string  hisScheduleId)
        {
            OdbcParameter[] medVsHisOperApplyParams = GetParameterOdbc("SelectCountMedVsHisOperApplyHis");
            medVsHisOperApplyParams[0].Value = hisApplyNo;
            medVsHisOperApplyParams[1].Value = hisPatientId;
            medVsHisOperApplyParams[2].Value = hisVisitId;
            medVsHisOperApplyParams[3].Value = hisScheduleId;

            object count = OdbcHelper.ExecuteScalar(OdbcHelper.ConnectionString, CommandType.Text, Select_Count_MED_VS_HIS_OPER_APPLY_V2_Odbc, medVsHisOperApplyParams);
            if (count == null)
                count = (object)0;
            return Convert.ToInt32(count);
        }
        /// <summary>
        /// 获取MED_VS_HIS_OPER_APPLY_V2记录(HIS手术流水号  HIS病人ID号 HIS的住院号)
        /// </summary>
        /// <param name="hisApplyNo">HIS手术流水号</param>
        /// <param name="hisPatientId">HIS病人ID号</param>
        /// <param name="hisVisitId">HIS的住院号</param>
        /// <param name="hisScheduleId">HIS手术流水号</param>
        /// <returns></returns>
        public Model.MedVsHisOperApplyV2 SelectMedVsHisOperApplyV2HisOdbc(string hisApplyNo, string hisPatientId, string hisVisitId, string  hisScheduleId)
        {
            Model.MedVsHisOperApplyV2 oneMedVsHisOperApply = null;
            OdbcParameter[] medVsHisOperApplyParams = GetParameterOdbc("SelectMedVsHisOperApplyHis");
            medVsHisOperApplyParams[0].Value = hisApplyNo;
            medVsHisOperApplyParams[1].Value = hisPatientId;
            medVsHisOperApplyParams[2].Value = hisVisitId;
            medVsHisOperApplyParams[3].Value = hisScheduleId;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MED_VS_HIS_OPER_APPLY_V2_His_Odbc, medVsHisOperApplyParams))
            {
                if (OdbcReader.Read())
                {
                    oneMedVsHisOperApply = new Model.MedVsHisOperApplyV2();
                    if (!OdbcReader.IsDBNull(0))
                        oneMedVsHisOperApply.MedPatientId = OdbcReader.GetString(0);
                    if (!OdbcReader.IsDBNull(1))
                        oneMedVsHisOperApply.MedVisitId = OdbcReader.GetDecimal(1);
                    if (!OdbcReader.IsDBNull(2))
                        oneMedVsHisOperApply.MedScheduleId = OdbcReader.GetDecimal(2);
                    if (!OdbcReader.IsDBNull(3))
                        oneMedVsHisOperApply.HisApplyNo = OdbcReader.GetString(3);
                    if (!OdbcReader.IsDBNull(4))
                        oneMedVsHisOperApply.HisPatientId = OdbcReader.GetString(4);
                    if (!OdbcReader.IsDBNull(5))
                        oneMedVsHisOperApply.HisVisitId = OdbcReader.GetString(5);
                    if (!OdbcReader.IsDBNull(6))
                        oneMedVsHisOperApply.HisScheduleId = OdbcReader.GetString(6);
                    if (!OdbcReader.IsDBNull(7))
                        oneMedVsHisOperApply.ReqDateTime = OdbcReader.GetString(7);
                }
                else
                    oneMedVsHisOperApply = null;
            }
            return oneMedVsHisOperApply;
        }
        /// <summary>
        /// 获取MED_VS_HIS_OPER_APPLY_V2记录(根据主索引)
        /// </summary>
        /// <param name="medPatientId">病人ID号</param>
        /// <param name="medVisitId">病人住院次数</param>
        /// <param name="medScheduleId">本次手术次数</param>
        /// <returns></returns>
        public Model.MedVsHisOperApplyV2 SelectMedVsHisOperApplyV2Odbc(string medPatientId, decimal medVisitId, decimal medScheduleId)
        {
            Model.MedVsHisOperApplyV2 oneMedVsHisOperApply = null;
            OdbcParameter[] medVsHisOperApplyParams = GetParameterOdbc("SelectMedVsHisOperApply");
            medVsHisOperApplyParams[0].Value = medPatientId;
            medVsHisOperApplyParams[1].Value = medVisitId;
            medVsHisOperApplyParams[2].Value = medScheduleId;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MED_VS_HIS_OPER_APPLY_V2_Odbc, medVsHisOperApplyParams))
            {
                if (OdbcReader.Read())
                {
                    oneMedVsHisOperApply = new Model.MedVsHisOperApplyV2();
                    if (!OdbcReader.IsDBNull(0))
                        oneMedVsHisOperApply.MedPatientId = OdbcReader.GetString(0);
                    if (!OdbcReader.IsDBNull(1))
                        oneMedVsHisOperApply.MedVisitId = OdbcReader.GetDecimal(1);
                    if (!OdbcReader.IsDBNull(2))
                        oneMedVsHisOperApply.MedScheduleId = OdbcReader.GetDecimal(2);
                    if (!OdbcReader.IsDBNull(3))
                        oneMedVsHisOperApply.HisApplyNo = OdbcReader.GetString(3);
                    if (!OdbcReader.IsDBNull(4))
                        oneMedVsHisOperApply.HisPatientId = OdbcReader.GetString(4);
                    if (!OdbcReader.IsDBNull(5))
                        oneMedVsHisOperApply.HisVisitId = OdbcReader.GetString(5);
                    if (!OdbcReader.IsDBNull(6))
                        oneMedVsHisOperApply.HisScheduleId = OdbcReader.GetString(6);
                    if (!OdbcReader.IsDBNull(7))
                        oneMedVsHisOperApply.ReqDateTime = OdbcReader.GetString(7);
                }
                else
                    oneMedVsHisOperApply = null;
            }
            return oneMedVsHisOperApply;
        }
        /// <summary>
        /// 插入MED_VS_HIS_OPER_APPLY_V2记录
        /// </summary>
        /// <param name="oneMedVsHisOperApply">MED_VS_HIS_OPER_APPLY_V2实体类</param>
        /// <returns></returns>
        public int InsertMedVsHisOperApplyV2Odbc(Model.MedVsHisOperApplyV2 oneMedVsHisOperApply)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedVsHisOperApply");
                oneInert[0].Value = oneMedVsHisOperApply.MedPatientId;
                oneInert[1].Value = oneMedVsHisOperApply.MedVisitId;
                oneInert[2].Value = oneMedVsHisOperApply.MedScheduleId;
                if (oneMedVsHisOperApply.HisApplyNo != null)
                    oneInert[3].Value = oneMedVsHisOperApply.HisApplyNo;
                else
                    oneInert[3].Value = DBNull.Value;
                if (oneMedVsHisOperApply.HisPatientId != null)
                    oneInert[4].Value = oneMedVsHisOperApply.HisPatientId;
                else
                    oneInert[4].Value = DBNull.Value;
                if (oneMedVsHisOperApply.HisVisitId.ToString() != null)
                    oneInert[5].Value = oneMedVsHisOperApply.HisVisitId;
                else
                    oneInert[5].Value = DBNull.Value;
                if (oneMedVsHisOperApply.HisScheduleId.ToString() != null)
                    oneInert[6].Value = oneMedVsHisOperApply.HisScheduleId;
                else
                    oneInert[6].Value = DBNull.Value;
                if (oneMedVsHisOperApply.ReqDateTime != null)
                    oneInert[7].Value = oneMedVsHisOperApply.ReqDateTime;
                else
                    oneInert[7].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_MED_VS_HIS_OPER_APPLY_V2_Odbc, oneInert);
            }
        }
        /// <summary>
        /// 更新MED_VS_HIS_OPER_APPLY_V2记录
        /// </summary>
        /// <param name="oneMedVsHisOperApply">MED_VS_HIS_OPER_APPLY_V2实体类</param>
        /// <returns></returns>
        public int UpdateMedVsHisOperApplyV2Odbc(Model.MedVsHisOperApplyV2 oneMedVsHisOperApply)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedVsHisOperApply");

                if (oneMedVsHisOperApply.HisApplyNo != null)
                    oneUpdate[0].Value = oneMedVsHisOperApply.HisApplyNo;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (oneMedVsHisOperApply.HisPatientId != null)
                    oneUpdate[1].Value = oneMedVsHisOperApply.HisPatientId;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (oneMedVsHisOperApply.HisVisitId.ToString() != null)
                    oneUpdate[2].Value = oneMedVsHisOperApply.HisVisitId;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (oneMedVsHisOperApply.HisScheduleId.ToString() != null)
                    oneUpdate[3].Value = oneMedVsHisOperApply.HisScheduleId;
                else
                    oneUpdate[3].Value = DBNull.Value;
                oneUpdate[4].Value = oneMedVsHisOperApply.ReqDateTime;
                oneUpdate[5].Value = oneMedVsHisOperApply.MedPatientId;
                oneUpdate[6].Value = oneMedVsHisOperApply.MedVisitId;
                oneUpdate[7].Value = oneMedVsHisOperApply.MedScheduleId;


                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_MED_VS_HIS_OPER_APPLY_V2_Odbc, oneUpdate);
            }
        }
        /// <summary>
        ///删除MED_VS_HIS_OPER_APPLY_V2 记录
        /// </summary>
        public int DeleteMedVsHisOperApplyV2Odbc(string medPatientId, decimal medVisitId, decimal medScheduleId)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterOdbc("DeleteMedVsHisOperApply");
                if (medPatientId != null)
                    oneDelete[0].Value = medPatientId;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (medVisitId.ToString() != null)
                    oneDelete[1].Value = medVisitId;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (medScheduleId.ToString() != null)
                    oneDelete[2].Value = medScheduleId;
                else
                    oneDelete[2].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, Delete_MED_VS_HIS_OPER_APPLY_V2_Odbc, oneDelete);
            }
        }
    }
}
