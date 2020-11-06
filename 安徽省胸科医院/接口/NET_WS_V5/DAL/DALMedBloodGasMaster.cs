using System;
using System.Collections.Generic;
using System.Text;
using MedicalSytem.Soft.Model;
using System.Data.OleDb;
using MedicalSytem.Soft.DAL;
using System.Data.SqlClient;
using System.Data;
using System.Data.OracleClient;
using System.Data.Common;

namespace  MedicalSytem.Soft.DAL
{
    public class DALMedBloodGasMaster
    {

        private static string Select_SQL = @"select PATIENT_ID,VISIT_ID,OPER_ID,RECORD_DATE,NURSE_MEMO1,NURSE_MEMO2, a.DETAIL_ID, a.OPERATOR,SPECIMEN, EQUIPMENT,b.BLG_CODE,b.BLG_VALUE,b.OP_DATE,b.ABNORMAL_INDICATOR
  from MED_BLOOD_GAS_MASTER a left join 
  MED_BLOOD_GAS_DETAIL  b on a.DETAIL_ID=b.DETAIL_ID 
 WHERE PATIENT_ID = @PatientId and VISIT_ID = @VisitId";
        private static string Update_SQL = "Update MED_BLOOD_GAS_MASTER set RECORD_DATE=@RecordDate,NURSE_MEMO1=@NurseMemo1,NURSE_MEMO2=@NurseMemo2,DETAIL_ID=@DetailId,OPERATOR=@Operator,OP_DATE=@OpDate,SPECIMEN=@Specimen,EQUIPMENT=@Equipment where PATIENT_ID=@PatientId,VISIT_ID=@VisitId,OPER_ID=@OperId";
        private static string Insert_SQL = "Insert into MED_BLOOD_GAS_MASTER(PATIENT_ID,VISIT_ID,OPER_ID,RECORD_DATE,NURSE_MEMO1,NURSE_MEMO2,DETAIL_ID,OPERATOR,OP_DATE,SPECIMEN,EQUIPMENT) values(@PatientId,@VisitId,@OperId,@RecordDate,@NurseMemo1,@NurseMemo2,@DetailId,@Operator,@OpDate,@Specimen,@Equipment)";
        private static string Select = @"select PATIENT_ID,VISIT_ID,OPER_ID,RECORD_DATE,NURSE_MEMO1,NURSE_MEMO2, a.DETAIL_ID, a.OPERATOR,SPECIMEN, EQUIPMENT,b.BLG_CODE,b.BLG_VALUE,b.OP_DATE,b.ABNORMAL_INDICATOR
  from MED_BLOOD_GAS_MASTER a left join 
  MED_BLOOD_GAS_DETAIL  b on a.DETAIL_ID=b.DETAIL_ID  WHERE PATIENT_ID=:PatientId AND VISIT_ID=:VisitId";
        private static string Update="Update MED_BLOOD_GAS_MASTER set RECORD_DATE=:RecordDate,NURSE_MEMO1=:NurseMemo1,NURSE_MEMO2=:NurseMemo2,DETAIL_ID=:DetailId,OPERATOR=:Operator,OP_DATE=:OpDate,SPECIMEN=:Specimen,EQUIPMENT=:Equipment where PATIENT_ID=:PatientId AND  VISIT_ID=:VisitId AND  OPER_ID=:OperId";
        private static string Insert = "Insert into MED_BLOOD_GAS_MASTER  (PATIENT_ID,VISIT_ID,OPER_ID,RECORD_DATE,NURSE_MEMO1,NURSE_MEMO2,DETAIL_ID,OPERATOR,OP_DATE,SPECIMEN,EQUIPMENT) values(:PatientId,:VisitId,:OperId,:RecordDate,:NurseMemo1,:NurseMemo2,:DetailId,:Operator,:OpDate,:Specimen,:Equipment)";
        private static string Select_OLE = @"select PATIENT_ID,VISIT_ID,OPER_ID,RECORD_DATE,NURSE_MEMO1,NURSE_MEMO2, a.DETAIL_ID, a.OPERATOR,SPECIMEN, EQUIPMENT,b.BLG_CODE,b.BLG_VALUE,b.OP_DATE,b.ABNORMAL_INDICATOR
  from MED_BLOOD_GAS_MASTER a left join 
  MED_BLOOD_GAS_DETAIL  b on a.DETAIL_ID=b.DETAIL_ID  WHERE PATIENT_ID=? AND VISIT_ID=? ";
        private static string Update_OLE = "Update MED_BLOOD_GAS_MASTER set RECORD_DATE=?,NURSE_MEMO1=?,NURSE_MEMO2=?,DETAIL_ID=?,OPERATOR=?,OP_DATE=?,SPECIMEN=?,EQUIPMENT=? where PATIENT_ID=? AND VISIT_ID=? AND OPER_ID=? ";
        private static string Insert_OLE = "Insert into MED_BLOOD_GAS_MASTER  (PATIENT_ID,VISIT_ID,OPER_ID,RECORD_DATE,NURSE_MEMO1,NURSE_MEMO2,DETAIL_ID,OPERATOR,OP_DATE,SPECIMEN,EQUIPMENT) values(?,?,?,?,?,?,?,?,?,?,?)";


        private static string Select_detail_ole = "select DETAIL_ID,BLG_CODE,BLG_VALUE,OPERATOR,OP_DATE,ABNORMAL_INDICATOR from MED_BLOOD_GAS_DETAIL WHERE DETAIL_ID=? AND BLG_CODE=? ";
        private static string Select_detail = "select DETAIL_ID,BLG_CODE,BLG_VALUE,OPERATOR,OP_DATE,ABNORMAL_INDICATOR from MED_BLOOD_GAS_DETAIL WHERE DETAIL_ID=:DetailId AND BLG_CODE=:BlgCode ";
        private static string Select_detail_sql = "select DETAIL_ID,BLG_CODE,BLG_VALUE,OPERATOR,OP_DATE,ABNORMAL_INDICATOR from MED_BLOOD_GAS_DETAIL WHERE DETAIL_ID=@DetailId,BLG_CODE=@BlgCode";


        private static string Update_Detail_SQL = "Update MED_BLOOD_GAS_DETAIL set BLG_VALUE=@BlgValue,OPERATOR=@Operator,OP_DATE=@OpDate,ABNORMAL_INDICATOR=@AbnormalIndicator where DETAIL_ID=@DetailId,BLG_CODE=@BlgCode";
        private static string Insert_Detail_SQL = "Insert into MED_BLOOD_GAS_DETAIL  (DETAIL_ID,BLG_CODE,BLG_VALUE,OPERATOR,OP_DATE,ABNORMAL_INDICATOR) values(@DetailId,@BlgCode,@BlgValue,@Operator,@OpDate,@AbnormalIndicator)";
        private static string Update_Detail_OLE = "Update MED_BLOOD_GAS_DETAIL set BLG_VALUE=?,OPERATOR=?,OP_DATE=?,ABNORMAL_INDICATOR=? where DETAIL_ID=? AND BLG_CODE=? ";
        private static string Insert_Detail_OLE = "Insert into MED_BLOOD_GAS_DETAIL  (DETAIL_ID,BLG_CODE,BLG_VALUE,OPERATOR,OP_DATE,ABNORMAL_INDICATOR) values(?,?,?,?,?,?)";
        private static string Update_Detail="Update MED_BLOOD_GAS_DETAIL set BLG_VALUE=:BlgValue,OPERATOR=:Operator,OP_DATE=:OpDate,ABNORMAL_INDICATOR=:AbnormalIndicator where DETAIL_ID=:DetailId AND  BLG_CODE=:BlgCode";
        private static string Insert_Detail = "Insert into MED_BLOOD_GAS_DETAIL  (DETAIL_ID,BLG_CODE,BLG_VALUE,OPERATOR,OP_DATE,ABNORMAL_INDICATOR) values(:DetailId,:BlgCode,:BlgValue,:Operator,:OpDate,:AbnormalIndicator)";
   


        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
               
                if (sqlParms == "InsertMaster")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("PatientId",OleDbType.VarChar),
                        new OleDbParameter("VisitId",OleDbType.Decimal),
                        new OleDbParameter("OperId",OleDbType.Decimal),
                        new OleDbParameter("RecordDate",OleDbType.DBTimeStamp),
                        new OleDbParameter("NurseMemo1",OleDbType.VarChar),
                        new OleDbParameter("NurseMemo2",OleDbType.VarChar),
                        new OleDbParameter("DetailId",OleDbType.VarChar),
                        new OleDbParameter("Operator",OleDbType.VarChar),
                        new OleDbParameter("OpDate",OleDbType.DBTimeStamp),
                        new OleDbParameter("Specimen",OleDbType.VarChar),
                        new OleDbParameter("Equipment",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMaster")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("RecordDate",OleDbType.DBTimeStamp),
                        new OleDbParameter("NurseMemo1",OleDbType.VarChar),
                        new OleDbParameter("NurseMemo2",OleDbType.VarChar),
                        new OleDbParameter("DetailId",OleDbType.VarChar),
                        new OleDbParameter("Operator",OleDbType.VarChar),
                        new OleDbParameter("OpDate",OleDbType.DBTimeStamp),
                        new OleDbParameter("Specimen",OleDbType.VarChar),
                        new OleDbParameter("Equipment",OleDbType.VarChar),
                        new OleDbParameter("PatientId",OleDbType.VarChar),
                        new OleDbParameter("VisitId",OleDbType.Decimal),
                        new OleDbParameter("OperId",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "UpdateDetail")
                {
                    parms = new OleDbParameter[]{
                   new OleDbParameter("BlgValue",OleDbType.VarChar),
                    new OleDbParameter("Operator",OleDbType.VarChar),
                    new OleDbParameter("OpDate",OleDbType.DBTimeStamp),
                    new OleDbParameter("AbnormalIndicator",OleDbType.VarChar),
                    new OleDbParameter(":DetailId",OleDbType.VarChar),
                    new OleDbParameter(":BlgCode",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "InsertDetail")
                {
                    parms = new OleDbParameter[]{
                    
                    new OleDbParameter("DetailId",OleDbType.VarChar),
                    new OleDbParameter("BlgCode",OleDbType.VarChar),
                    new OleDbParameter("BlgValue",OleDbType.VarChar),
                    new OleDbParameter("Operator",OleDbType.VarChar),
                    new OleDbParameter("OpDate",OleDbType.DBTimeStamp),
                    new OleDbParameter("AbnormalIndicator",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMaster")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("PatientId",OleDbType.VarChar),
                        new OleDbParameter("VisitId",OleDbType.Decimal),
                    
                  };
                }

                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }


        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMaster")
                {
                    parms = new OracleParameter[]{
                       new OracleParameter(":PatientId",OracleType.VarChar),
                        new OracleParameter(":VisitId",OracleType.Number),
                        new OracleParameter(":OperId",OracleType.Number),
                        new OracleParameter(":RecordDate",OracleType.DateTime),
                        new OracleParameter(":NurseMemo1",OracleType.VarChar),
                        new OracleParameter(":NurseMemo2",OracleType.VarChar),
                        new OracleParameter(":DetailId",OracleType.VarChar),
                        new OracleParameter(":Operator",OracleType.VarChar),
                        new OracleParameter(":OpDate",OracleType.DateTime),
                        new OracleParameter(":Specimen",OracleType.VarChar),
                        new OracleParameter(":Equipment",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMaster")
                {
                    parms = new OracleParameter[]{
                        new OracleParameter(":RecordDate",OracleType.DateTime),
                        new OracleParameter(":NurseMemo1",OracleType.VarChar),
                        new OracleParameter(":NurseMemo2",OracleType.VarChar),
                        new OracleParameter(":DetailId",OracleType.VarChar),
                        new OracleParameter(":Operator",OracleType.VarChar),
                        new OracleParameter(":OpDate",OracleType.DateTime),
                        new OracleParameter(":Specimen",OracleType.VarChar),
                        new OracleParameter(":Equipment",OracleType.VarChar),
                        new OracleParameter(":PatientId",OracleType.VarChar),
                        new OracleParameter(":VisitId",OracleType.Number),
                        new OracleParameter(":OperId",OracleType.Number),
                    };
                }
                else if (sqlParms == "UpdateDetail")
                {
                    parms = new OracleParameter[]{
                    
                    new OracleParameter(":BlgValue",OracleType.VarChar),
                    new OracleParameter(":Operator",OracleType.VarChar),
                    new OracleParameter(":OpDate",OracleType.DateTime),
                    new OracleParameter(":AbnormalIndicator",OracleType.VarChar),
                    new OracleParameter(":DetailId",OracleType.VarChar),
                    new OracleParameter(":BlgCode",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "InsertDetail")
                {
                    parms = new OracleParameter[]{
                    new OracleParameter(":DetailId",OracleType.VarChar),
                    new OracleParameter(":BlgCode",OracleType.VarChar),
                    new OracleParameter(":BlgValue",OracleType.VarChar),
                    new OracleParameter(":Operator",OracleType.VarChar),
                    new OracleParameter(":OpDate",OracleType.DateTime),
                    new OracleParameter(":AbnormalIndicator",OracleType.VarChar),
                    
                    };
                }
                else if (sqlParms == "SelectMaster")
                {
                    parms = new OracleParameter[]{
                       new OracleParameter(":PatientId",OracleType.VarChar),
                        new OracleParameter(":VisitId",OracleType.Number),
                      
                  };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                 
                if (sqlParms == "UpdateMaster")
                {
                    parms = new SqlParameter[]{
                                new SqlParameter("@RecordDate",SqlDbType.DateTime),
                                new SqlParameter("@NurseMemo1",SqlDbType.VarChar),
                                new SqlParameter("@NurseMemo2",SqlDbType.VarChar),
                                new SqlParameter("@DetailId",SqlDbType.VarChar),
                                new SqlParameter("@Operator",SqlDbType.VarChar),
                                new SqlParameter("@OpDate",SqlDbType.DateTime),
                                new SqlParameter("@Specimen",SqlDbType.VarChar),
                                new SqlParameter("@Equipment",SqlDbType.VarChar),
                                new SqlParameter("@PatientId",SqlDbType.VarChar),
                                new SqlParameter("@VisitId",SqlDbType.Decimal),
                                new SqlParameter("@OperId",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "InsertMaster")
                {
                    parms = new SqlParameter[]{
                            new SqlParameter("@PatientId",SqlDbType.VarChar),
                            new SqlParameter("@VisitId",SqlDbType.Decimal),
                            new SqlParameter("@OperId",SqlDbType.Decimal),
                            new SqlParameter("@RecordDate",SqlDbType.DateTime),
                            new SqlParameter("@NurseMemo1",SqlDbType.VarChar),
                            new SqlParameter("@NurseMemo2",SqlDbType.VarChar),
                            new SqlParameter("@DetailId",SqlDbType.VarChar),
                            new SqlParameter("@Operator",SqlDbType.VarChar),
                            new SqlParameter("@OpDate",SqlDbType.DateTime),
                            new SqlParameter("@Specimen",SqlDbType.VarChar),
                            new SqlParameter("@Equipment",SqlDbType.VarChar),
                    };
                } 
                else if (sqlParms == "UpdateDetail")
                {
                    parms = new SqlParameter[]{
                        new SqlParameter("@BlgValue",SqlDbType.VarChar),
                        new SqlParameter("@Operator",SqlDbType.VarChar),
                        new SqlParameter("@OpDate",SqlDbType.DateTime),
                        new SqlParameter("@AbnormalIndicator",SqlDbType.VarChar),
                        new SqlParameter("@DetailId",SqlDbType.VarChar),
                        new SqlParameter("@BlgCode",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "InsertDetail")
                {
                    parms = new SqlParameter[]{
                       new SqlParameter("@DetailId",SqlDbType.VarChar),
                       new SqlParameter("@BlgCode",SqlDbType.VarChar),
                       new SqlParameter("@BlgValue",SqlDbType.VarChar),
                       new SqlParameter("@Operator",SqlDbType.VarChar),
                       new SqlParameter("@OpDate",SqlDbType.DateTime),
                       new SqlParameter("@AbnormalIndicator",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMaster")
                {
                    parms = new SqlParameter[]{
                       new SqlParameter("@PatientId",SqlDbType.VarChar),
                       new SqlParameter("@VisitId",SqlDbType.Decimal),
                    
                  };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public int InsertGasMaster(MedBloodGasMaster model, string dbtype)
        {
            DbParameter[] oneInert = null;
            if (dbtype == "oracle")
            {
                oneInert = GetParameter("InsertMaster");
            }
            else if (dbtype == "sql")
            {
                oneInert = GetParameterSQL("InsertMaster");
            }
            else if (dbtype == "ole")
            {
                oneInert = GetParameterOLE("InsertMaster");
            }
            

            if (model.PatientId != null)
                oneInert[0].Value = model.PatientId;
            else
                oneInert[0].Value = DBNull.Value;
            if (model.VisitId != null)
                oneInert[1].Value = model.VisitId;
            else
                oneInert[1].Value = DBNull.Value;
            if (model.OperId != null)
                oneInert[2].Value = model.OperId;
            else
                oneInert[2].Value = DBNull.Value;
            if (model.RecordDate != null)
                oneInert[3].Value = model.RecordDate;
            else
                oneInert[3].Value = DBNull.Value;
            if (model.NurseMemo1 != null)
                oneInert[4].Value = model.NurseMemo1;
            else
                oneInert[4].Value = DBNull.Value;
            if (model.NurseMemo2 != null)
                oneInert[5].Value = model.NurseMemo2;
            else
                oneInert[5].Value = DBNull.Value;
            if (model.DetailId != null)
                oneInert[6].Value = model.DetailId;
            else
                oneInert[6].Value = DBNull.Value;
            if (model.Operator != null)
                oneInert[7].Value = model.Operator;
            else
                oneInert[7].Value = DBNull.Value;
            if (model.OpDate != null)
                oneInert[8].Value = model.OpDate;
            else
                oneInert[8].Value = DBNull.Value;
            if (model.Specimen != null)
                oneInert[9].Value = model.Specimen;
            else
                oneInert[9].Value = DBNull.Value;
            if (model.Equipment != null)
                oneInert[10].Value = model.Equipment;
            else
                oneInert[10].Value = DBNull.Value;


            if (dbtype == "oracle")
            {
                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, Insert, (OracleParameter[])oneInert);
            }
            else if (dbtype == "sql")
            {
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, Insert_SQL, (SqlParameter[])oneInert);
            }
            else if (dbtype == "ole")
            {
                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, Insert_OLE, (OleDbParameter[])oneInert);
            }
            return -1;
        }

        public int  InsertGasDetail(MedBloodGasDetail model, string dbtype)
        {  
            DbParameter[] oneInert = null;
            if (dbtype == "oracle")
            {
                oneInert = GetParameter("InsertDetail");
            }
            else if (dbtype == "sql")
            {
                oneInert = GetParameterSQL("InsertDetail");
            }
            else if (dbtype == "ole")
            {
                oneInert = GetParameterOLE("InsertDetail");
            }

                if (model.DetailId!= null)
                oneInert[0].Value = model.DetailId;
                 else
                oneInert[0].Value = DBNull.Value;
                if (model.BlgCode!= null)
                oneInert[1].Value = model.BlgCode;
                 else
                oneInert[1].Value = DBNull.Value;
                if (model.BlgValue!= null)
                oneInert[2].Value = model.BlgValue;
                 else
                oneInert[2].Value = DBNull.Value;
                if (model.Operator!= null)
                oneInert[3].Value = model.Operator;
                 else
                oneInert[3].Value = DBNull.Value;
                if (model.OpDate!= null)
                oneInert[4].Value = model.OpDate;
                 else
                oneInert[4].Value = DBNull.Value;
                if (model.AbnormalIndicator!= null)
                oneInert[5].Value = model.AbnormalIndicator;
                 else
                oneInert[5].Value = DBNull.Value;

            if (dbtype == "oracle")
            {
                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, Insert_Detail, (OracleParameter[])oneInert);
            }
            else if (dbtype == "sql")
            {
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, Insert_Detail_SQL, (SqlParameter[])oneInert);
            }
            else if (dbtype == "ole")
            {
                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, Insert_Detail_OLE, (OleDbParameter[])oneInert);
            }
            return -1;
        }

        public int UpdateGasMaster(MedBloodGasMaster model, string dbtype)
        {
            DbParameter[] oneInert = null;
            if (dbtype == "oracle")
            {
                oneInert = GetParameter("UpdateMaster");
            }
            else if (dbtype == "sql")
            {
                oneInert = GetParameterSQL("UpdateMaster");
            }
            else if (dbtype == "ole")
            {
                oneInert = GetParameterOLE("UpdateMaster");
            }


           
            if (model.RecordDate != null)
                oneInert[0].Value = model.RecordDate;
            else
                oneInert[0].Value = DBNull.Value;
            if (model.NurseMemo1 != null)
                oneInert[1].Value = model.NurseMemo1;
            else
                oneInert[1].Value = DBNull.Value;
            if (model.NurseMemo2 != null)
                oneInert[2].Value = model.NurseMemo2;
            else
                oneInert[2].Value = DBNull.Value;
            if (model.DetailId != null)
                oneInert[3].Value = model.DetailId;
            else
                oneInert[3].Value = DBNull.Value;
            if (model.Operator != null)
                oneInert[4].Value = model.Operator;
            else
                oneInert[4].Value = DBNull.Value;
            if (model.OpDate != null)
                oneInert[5].Value = model.OpDate;
            else
                oneInert[5].Value = DBNull.Value;
            if (model.Specimen != null)
                oneInert[6].Value = model.Specimen;
            else
                oneInert[6].Value = DBNull.Value;
            if (model.Equipment != null)
                oneInert[7].Value = model.Equipment;
            else
                oneInert[7].Value = DBNull.Value;
            if (model.PatientId != null)
                oneInert[8].Value = model.PatientId;
            else
                oneInert[8].Value = DBNull.Value;
            if (model.VisitId != null)
                oneInert[9].Value = model.VisitId;
            else
                oneInert[9].Value = DBNull.Value;
            if (model.OperId != null)
                oneInert[10].Value = model.OperId;
            else
                oneInert[10].Value = DBNull.Value;

            if (dbtype == "oracle")
            {
                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, Update, (OracleParameter[])oneInert);
            }
            else if (dbtype == "sql")
            {
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, Update_SQL, (SqlParameter[])oneInert);
            }
            else if (dbtype == "ole")
            {
                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, Update_OLE, (OleDbParameter[])oneInert);
            }
            return -1;
        }

        public int UpdateGasDetail(MedBloodGasDetail model, string dbtype)
        {
            DbParameter[] oneInert = null;
            if (dbtype == "oracle")
            {
                oneInert = GetParameter("UpdateDetail");
            }
            else if (dbtype == "sql")
            {
                oneInert = GetParameterSQL("UpdateDetail");
            }
            else if (dbtype == "ole")
            {
                oneInert = GetParameterOLE("UpdateDetail");
            }
            if (model.BlgValue!= null)
            oneInert[0].Value = model.BlgValue;
            else
            oneInert[0].Value = DBNull.Value;
            if (model.Operator!= null)
            oneInert[1].Value = model.Operator;
            else
            oneInert[1].Value = DBNull.Value;
            if (model.OpDate!= null)
            oneInert[2].Value = model.OpDate;
            else
            oneInert[2].Value = DBNull.Value;
            if (model.AbnormalIndicator!= null)
            oneInert[3].Value = model.AbnormalIndicator;
            else
            oneInert[3].Value = DBNull.Value;
            if (model.DetailId!= null)
            oneInert[4].Value = model.DetailId;
            else
            oneInert[4].Value = DBNull.Value;
            if (model.BlgCode!= null)
            oneInert[5].Value = model.BlgCode;
            else
            oneInert[5].Value = DBNull.Value;

            if (dbtype == "oracle")
            {
                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, Update_Detail, (OracleParameter[])oneInert);
            }
            else if (dbtype == "sql")
            {
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, Update_Detail_SQL, (SqlParameter[])oneInert);
            }
            else if (dbtype == "ole")
            {
                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, Update_Detail_OLE, (OleDbParameter[])oneInert);
            }
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientid"></param>
        /// <param name="visitid"></param>
        /// <param name="operid"></param>
        /// <param name="dbtype"></param>
        /// <param name="connstr"></param>
        /// <returns></returns>
        public Dictionary<MedBloodGasMaster, List<MedBloodGasDetail>> GetEntity(string patientid, decimal visitid, decimal operid, string dbtype, string connstr)
        {
            Dictionary<MedBloodGasMaster, List<MedBloodGasDetail>> dic = new Dictionary<MedBloodGasMaster, List<MedBloodGasDetail>>();

            DbParameter[] oneInert = null;
            if (dbtype == "oracle")
            {
                oneInert = GetParameter("SelectMaster");
            }
            else if (dbtype == "sql")
            {
                oneInert = GetParameterSQL("SelectMaster");
            }
            else if (dbtype == "ole")
            {
                oneInert = GetParameterOLE("SelectMaster");
            }

            oneInert[0].Value = patientid;
            oneInert[1].Value = visitid;

            DataSet ds = null;

            if (dbtype == "oracle")
            {
                ds = OracleHelper.GetDataSet(connstr, CommandType.Text, Select , (OracleParameter[])oneInert);
            }
            else if (dbtype == "sql")
            {
                ds = SqlHelper.GetDataSet(connstr, CommandType.Text, Select_SQL, (SqlParameter[])oneInert);
            }
            else if (dbtype == "ole")
            {
                ds = OleDbHelper.GetDataSet(connstr, CommandType.Text, Select_OLE, (OleDbParameter[])oneInert);
            }
            List<string> detailIdList = new List<string>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string detailId = dr["DETAIL_ID"].ToString();
                if (detailIdList.Contains(detailId))
                {
                    continue;
                }
                detailIdList.Add(detailId);
                MedBloodGasMaster master = new MedBloodGasMaster();
                master.PatientId = patientid;
                master.VisitId = visitid;
                master.OperId = operid;
                master.DetailId = detailId;
                master.Equipment = dr["Equipment"].ToString();
                master.NurseMemo1 = dr["NURSE_MEMO1"].ToString();
                master.NurseMemo2 = dr["NURSE_MEMO2"].ToString();
                master.OpDate = DateTime.Parse(dr["OP_DATE"].ToString());
                master.Operator = dr["Operator"].ToString();
                master.RecordDate = DateTime.Parse(dr["Record_Date"].ToString());
                master.Specimen = dr["Specimen"].ToString();

                DataRow[] drList = ds.Tables[0].Select("DETAIL_ID='" + detailId + "'");

                List<MedBloodGasDetail> detailList = new List<MedBloodGasDetail>();
                foreach (DataRow drtemp in drList)
                {
                    MedBloodGasDetail detail = new MedBloodGasDetail();
                    detail.DetailId = detailId;
                    detail.AbnormalIndicator = drtemp["Abnormal_Indicator"].ToString();
                    detail.BlgCode = drtemp["Blg_Code"].ToString();
                    detail.BlgValue = drtemp["Blg_Value"].ToString();
                    detail.OpDate = master.OpDate;
                    detail.Operator = master.Operator;
                    detailList.Add(detail);
                }

                dic.Add(master, detailList);
            }
            return dic;
        }
    }
}
