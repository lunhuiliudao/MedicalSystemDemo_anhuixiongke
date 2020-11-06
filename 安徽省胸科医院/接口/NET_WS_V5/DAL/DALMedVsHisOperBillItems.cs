using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using MedicalSytem.Soft.DAL;
using MedicalSytem.Soft.Model;
using System.Data;
using System.Data.SqlClient;

namespace MedicalSytem.Soft.DAL
{
    public partial class DALMedVsHisOperBillItems
    {
        private static readonly string MED_VS_HIS_OPER_BILL_ITEMS_Insert_SQL = "INSERT INTO MED_VS_HIS_OPER_BILL_ITEMS (MED_PATIENT_ID,MED_VISIT_ID,MED_OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05) values (@medPatientId,@medVisitId,@medOperId,@itemNo,@itemClass,@itemName,@itemCode,@itemSpec,@amount,@units,@hisPatientId,@hisVisitId,@hisScheduleId,@createDate,@reserved01,@reserved02,@reserved03,@reserved04,@reserved05)";
        private static readonly string MED_VS_HIS_OPER_BILL_ITEMS_Select_SQL = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05 FROM MED_VS_HIS_OPER_BILL_ITEMS WHERE MED_PATIENT_ID = @medPatientId AND MED_VISIT_ID = @medVisitId AND MED_OPER_ID = @medOperId AND ITEM_NO = @itemNo";
        private static readonly string MED_VS_HIS_OPER_BILL_ITEMS_Insert = "INSERT INTO MED_VS_HIS_OPER_BILL_ITEMS (MED_PATIENT_ID,MED_VISIT_ID,MED_OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05) values (:medPatientId,:medVisitId,:medOperId,:itemNo,:itemClass,:itemName,:itemCode,:itemSpec,:amount,:units,:hisPatientId,:hisVisitId,:hisScheduleId,:createDate,:reserved01,:reserved02,:reserved03,:reserved04,:reserved05)";
        private static readonly string MED_VS_HIS_OPER_BILL_ITEMS_Select = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05 FROM MED_VS_HIS_OPER_BILL_ITEMS WHERE MED_PATIENT_ID = :medPatientId AND MED_VISIT_ID = :medVisitId AND MED_OPER_ID = :medOperId AND ITEM_NO = :itemNo";
        private static readonly string MED_VS_HIS_OPER_BILL_ITEMS_Select_Max = "SELECT MAX(RESERVED01) FROM MED_VS_HIS_OPER_BILL_ITEMS WHERE MED_PATIENT_ID = :medPatientId AND MED_VISIT_ID = :medVisitId AND MED_OPER_ID = :medOperId";

        public DALMedVsHisOperBillItems()
        {
        }
        #region [获取参数SQL]
        /// <summary>
        ///获取参数
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOperBillItems")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@medPatientId",SqlDbType.VarChar),
							new SqlParameter("@medVisitId",SqlDbType.Decimal),
							new SqlParameter("@medOperId",SqlDbType.Decimal),
							new SqlParameter("@itemNo",SqlDbType.Decimal),
                            new SqlParameter("@itemClass",SqlDbType.VarChar),
                            new SqlParameter("@itemName",SqlDbType.VarChar),
                            new SqlParameter("@itemCode",SqlDbType.VarChar),
                            new SqlParameter("@itemSpec",SqlDbType.VarChar),
                            new SqlParameter("@amount",SqlDbType.Decimal),
                            new SqlParameter("@units",SqlDbType.VarChar),
                            new SqlParameter("@hisPatientId",SqlDbType.VarChar),
                            new SqlParameter("@hisVisitId",SqlDbType.VarChar),
                            new SqlParameter("@hisScheduleId",SqlDbType.Decimal),
                            new SqlParameter("@createDate",SqlDbType.DateTime),
                            new SqlParameter("@reserved01",SqlDbType.VarChar),
                            new SqlParameter("@reserved02",SqlDbType.VarChar),
                            new SqlParameter("@reserved03",SqlDbType.VarChar),
                            new SqlParameter("@reserved04",SqlDbType.VarChar),
                            new SqlParameter("@reserved05",SqlDbType.VarChar)
                    };
                }
                else if (sqlParms == "SelectMedVsHisOperBillItems")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@medPatientId",SqlDbType.VarChar),
							new SqlParameter("@medVisitId",SqlDbType.Decimal),
							new SqlParameter("@medOperId",SqlDbType.Decimal),
							new SqlParameter("@itemNo",SqlDbType.Decimal)
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model   
        ///Insert Table 
        /// </summary>
        public int InsertMedVsHisOperBillItemsSQL(MedVsHisOperBillItems model)
        {
            using (SqlConnection oleCisConn = new  SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedVsHisOperBillItems");
                if (model.MedPatientId != null)
                    oneInert[0].Value = model.MedPatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.MedVisitId != null)
                    oneInert[1].Value = model.MedVisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.MedOperId != null)
                    oneInert[2].Value = model.MedOperId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.ItemNo != null)
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
                if (model.Amount != null)
                    oneInert[8].Value = model.Amount;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Units != null)
                    oneInert[9].Value = model.Units;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneInert[10].Value = model.HisPatientId;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneInert[11].Value = model.HisVisitId;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.HisScheduleId != null)
                    oneInert[12].Value = model.HisScheduleId;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.CreateDate > DateTime.MinValue)
                    oneInert[13].Value = model.CreateDate;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneInert[14].Value = model.Reserved01;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneInert[15].Value = model.Reserved02;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneInert[16].Value = model.Reserved03;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.Reserved04 != null)
                    oneInert[17].Value = model.Reserved04;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.Reserved05 != null)
                    oneInert[18].Value = model.Reserved05;
                else
                    oneInert[18].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_VS_HIS_OPER_BILL_ITEMS_Insert_SQL, oneInert);
            }
        }


        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model   
        ///select Table 
        /// </summary>
        public MedVsHisOperBillItems SelectMedVsHisOperBillItemsSQL(string patientId, decimal visitId, decimal operId, decimal itemNo)
        {
            MedVsHisOperBillItems model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedVsHisOperBillItems");
            parameterValues[0].Value = patientId;
            parameterValues[1].Value = visitId;
            parameterValues[2].Value = operId;
            parameterValues[3].Value = itemNo;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_ITEMS_Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisOperBillItems();
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
                        model.MedOperId = decimal.Parse(oleReader["MED_OPER_ID"].ToString().Trim());
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
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.HisScheduleId = decimal.Parse(oleReader["HIS_SCHEDULE_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["HIS_VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
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

        #region [获取参数]
        /// <summary>
        ///获取参数MedDeptDict
        /// </summary>
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOperBillItems")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":medPatientId",OracleType.VarChar),
							new OracleParameter(":medVisitId",OracleType.Number),
							new OracleParameter(":medOperId",OracleType.Number),
							new OracleParameter(":itemNo",OracleType.Number),
                            new OracleParameter(":itemClass",OracleType.VarChar),
                            new OracleParameter(":itemName",OracleType.VarChar),
                            new OracleParameter(":itemCode",OracleType.VarChar),
                            new OracleParameter(":itemSpec",OracleType.VarChar),
                            new OracleParameter(":amount",OracleType.Number),
                            new OracleParameter(":units",OracleType.VarChar),
                            new OracleParameter(":hisPatientId",OracleType.VarChar),
                            new OracleParameter(":hisVisitId",OracleType.VarChar),
                            new OracleParameter(":hisScheduleId",OracleType.Number),
                            new OracleParameter(":createDate",OracleType.DateTime),
                            new OracleParameter(":reserved01",OracleType.VarChar),
                            new OracleParameter(":reserved02",OracleType.VarChar),
                            new OracleParameter(":reserved03",OracleType.VarChar),
                            new OracleParameter(":reserved04",OracleType.VarChar),
                            new OracleParameter(":reserved05",OracleType.VarChar)
                    };
                }
                else if (sqlParms == "SelectMedVsHisOperBillItems")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":medPatientId",OracleType.VarChar),
							new OracleParameter(":medVisitId",OracleType.Number),
							new OracleParameter(":medOperId",OracleType.Number),
							new OracleParameter(":itemNo",OracleType.Number)
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisOperBillItems")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":medPatientId",OracleType.VarChar),
							new OracleParameter(":medVisitId",OracleType.Number),
							new OracleParameter(":medOperId",OracleType.Number),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model   
        ///Insert Table 
        /// </summary>
        public int InsertMedVsHisOperBillItems(MedVsHisOperBillItems model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedVsHisOperBillItems");
                if (model.MedPatientId != null)
                    oneInert[0].Value = model.MedPatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.MedVisitId != null)
                    oneInert[1].Value = model.MedVisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.MedOperId != null)
                    oneInert[2].Value = model.MedOperId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.ItemNo != null)
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
                if (model.Amount != null)
                    oneInert[8].Value = model.Amount;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Units != null)
                    oneInert[9].Value = model.Units;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneInert[10].Value = model.HisPatientId;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneInert[11].Value = model.HisVisitId;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.HisScheduleId != null)
                    oneInert[12].Value = model.HisScheduleId;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.CreateDate > DateTime.MinValue)
                    oneInert[13].Value = model.CreateDate;
                else
                    oneInert[13].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneInert[14].Value = model.Reserved01;
                else
                    oneInert[14].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneInert[15].Value = model.Reserved02;
                else
                    oneInert[15].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneInert[16].Value = model.Reserved03;
                else
                    oneInert[16].Value = DBNull.Value;
                if (model.Reserved04 != null)
                    oneInert[17].Value = model.Reserved04;
                else
                    oneInert[17].Value = DBNull.Value;
                if (model.Reserved05 != null)
                    oneInert[18].Value = model.Reserved05;
                else
                    oneInert[18].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_VS_HIS_OPER_BILL_ITEMS_Insert, oneInert);
            }
        }


        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model   
        ///select Table 
        /// </summary>
        public MedVsHisOperBillItems SelectMedVsHisOperBillItems(string patientId, decimal visitId, decimal operId, decimal itemNo)
        {
            MedVsHisOperBillItems model;
            OracleParameter[] parameterValues = GetParameter("SelectMedVsHisOperBillItems");
            parameterValues[0].Value = patientId;
            parameterValues[1].Value = visitId;
            parameterValues[2].Value = operId;
            parameterValues[3].Value = itemNo;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_ITEMS_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisOperBillItems();
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
                        model.MedOperId = decimal.Parse(oleReader["MED_OPER_ID"].ToString().Trim());
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
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.HisScheduleId = decimal.Parse(oleReader["HIS_SCHEDULE_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["HIS_VISIT_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(14))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(15))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(16))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(17))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(18))
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
        #region  [获取最大唯一号]
        /// <summary>
        ///Select    model   
        ///select Table 
        /// </summary>
        public int SelectMaxMedVsHisOperBillItems(string patientId, decimal visitId, decimal operId)
        {
            OracleParameter[] parameterValues = GetParameter("SelectMaxMedVsHisOperBillItems");
            parameterValues[0].Value = patientId;
            parameterValues[1].Value = visitId;
            parameterValues[2].Value = operId;

            object count = OracleHelper.ExecuteScalar(OracleHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_ITEMS_Select_Max, parameterValues);
            if (count == null || count == DBNull.Value)
                count = (object)1000;
            return Convert.ToInt32(count);
        }
        #endregion

    }
}
