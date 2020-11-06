using System;
using System.Collections.Generic;
using System.Text;
using MedicalSytem.Soft.DAL;
using MedicalSytem.Soft.Model;
using System.Data;
using System.Data.OleDb;

namespace MedicalSytem.Soft.DAL
{
    public partial class DALMedVsHisOperBillItems
    {
        private static readonly string MED_VS_HIS_OPER_BILL_ITEMS_Insert_OLE = "INSERT INTO MED_VS_HIS_OPER_BILL_ITEMS (MED_PATIENT_ID,MED_VISIT_ID,MED_OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_VS_HIS_OPER_BILL_ITEMS_Select_OLE = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_OPER_ID,ITEM_NO,ITEM_CLASS,ITEM_NAME,ITEM_CODE,ITEM_SPEC,AMOUNT,UNITS,HIS_PATIENT_ID,HIS_VISIT_ID,HIS_SCHEDULE_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05 FROM MED_VS_HIS_OPER_BILL_ITEMS WHERE MED_PATIENT_ID = ? AND MED_VISIT_ID = ? AND MED_OPER_ID = ? AND ITEM_NO = ?";
        private static readonly string MED_VS_HIS_OPER_BILL_ITEMS_Update_OLE = @"update MED_VS_HIS_OPER_BILL_ITEMS      SET MED_PATIENT_ID  = ?,       MED_VISIT_ID    = ?,       MED_OPER_ID     = ?,       ITEM_NO         = ?,       ITEM_CLASS      = ?,       ITEM_NAME       =?,       ITEM_CODE       = ?,       ITEM_SPEC       = ?,       AMOUNT          = ?,       UNITS           = ?,       HIS_PATIENT_ID  =?,       HIS_VISIT_ID    =?,       HIS_SCHEDULE_ID = ?,       CREATE_DATE     = ?,
       RESERVED01      = ?,       RESERVED02      = ?,       RESERVED03      = ?,       RESERVED04      = ?,       RESERVED05      = ?  WHERE MED_PATIENT_ID = ?   AND MED_VISIT_ID = ?   AND MED_OPER_ID = ?   AND ITEM_NO = ? ";



        #region [获取参数]
        /// <summary>
        ///获取参数MedDeptDict
        /// </summary>
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisOperBillItems")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("medPatientId",OleDbType.VarChar),
							new OleDbParameter("medVisitId",OleDbType.Decimal),
							new OleDbParameter("medOperId",OleDbType.Decimal),
							new OleDbParameter("itemNo",OleDbType.Decimal),
                            new OleDbParameter("itemClass",OleDbType.VarChar),
                            new OleDbParameter("itemName",OleDbType.VarChar),
                            new OleDbParameter("itemCode",OleDbType.VarChar),
                            new OleDbParameter("itemSpec",OleDbType.VarChar),
                            new OleDbParameter("amount",OleDbType.Decimal),
                            new OleDbParameter("units",OleDbType.VarChar),
                            new OleDbParameter("hisPatientId",OleDbType.VarChar),
                            new OleDbParameter("hisVisitId",OleDbType.VarChar),
                            new OleDbParameter("hisScheduleId",OleDbType.Decimal),
                            new OleDbParameter("createDate",OleDbType.DBTimeStamp),
                            new OleDbParameter("reserved01",OleDbType.VarChar),
                            new OleDbParameter("reserved02",OleDbType.VarChar),
                            new OleDbParameter("reserved03",OleDbType.VarChar),
                            new OleDbParameter("reserved04",OleDbType.VarChar),
                            new OleDbParameter("reserved05",OleDbType.VarChar)
                    };
                }
                else if (sqlParms == "SelectMedVsHisOperBillItems")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter("medPatientId",OleDbType.VarChar),
							new OleDbParameter("medVisitId",OleDbType.Decimal),
							new OleDbParameter("medOperId",OleDbType.Decimal),
							new OleDbParameter("itemNo",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "UpdateMedVsHisOperBillItems")
                {
                    parms = new OleDbParameter[]{
                        	new OleDbParameter("medPatientId",OleDbType.VarChar),
							new OleDbParameter("medVisitId",OleDbType.Decimal),
							new OleDbParameter("medOperId",OleDbType.Decimal),
							new OleDbParameter("itemNo",OleDbType.Decimal),
                            new OleDbParameter("itemClass",OleDbType.VarChar),
                            new OleDbParameter("itemName",OleDbType.VarChar),
                            new OleDbParameter("itemCode",OleDbType.VarChar),
                            new OleDbParameter("itemSpec",OleDbType.VarChar),
                            new OleDbParameter("amount",OleDbType.Decimal),
                            new OleDbParameter("units",OleDbType.VarChar),
                            new OleDbParameter("hisPatientId",OleDbType.VarChar),
                            new OleDbParameter("hisVisitId",OleDbType.VarChar),
                            new OleDbParameter("hisScheduleId",OleDbType.Decimal),
                            new OleDbParameter("createDate",OleDbType.DBTimeStamp),
                            new OleDbParameter("reserved01",OleDbType.VarChar),
                            new OleDbParameter("reserved02",OleDbType.VarChar),
                            new OleDbParameter("reserved03",OleDbType.VarChar),
                            new OleDbParameter("reserved04",OleDbType.VarChar),
                            new OleDbParameter("reserved05",OleDbType.VarChar),
							new OleDbParameter("medPatientId",OleDbType.VarChar),
							new OleDbParameter("medVisitId",OleDbType.Decimal),
							new OleDbParameter("medOperId",OleDbType.Decimal),
							new OleDbParameter("itemNo",OleDbType.Decimal)
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model   
        ///Insert Table 
        /// </summary>
        public int InsertMedVsHisOperBillItemsOLE(MedVsHisOperBillItems model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedVsHisOperBillItems");
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

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString,CommandType.Text,MED_VS_HIS_OPER_BILL_ITEMS_Insert_OLE, oneInert);
            }
        }


        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model   
        ///select Table 
        /// </summary>
        public MedVsHisOperBillItems SelectMedVsHisOperBillItemsOLE(string patientId, decimal visitId, decimal operId, decimal itemNo)
        {
            MedVsHisOperBillItems model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedVsHisOperBillItems");
            parameterValues[0].Value = patientId;
            parameterValues[1].Value = visitId;
            parameterValues[2].Value = operId;
            parameterValues[3].Value = itemNo;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_ITEMS_Select, parameterValues))
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

        #region [更新一条记录]
        /// <summary>
        ///Add    model   
        ///Insert Table 
        /// </summary>
        public int UpdateMedVsHisOperBillItemsOLE(MedVsHisOperBillItems model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("UpdateMedVsHisOperBillItems");
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

                if (model.MedPatientId != null)
                    oneInert[19].Value = model.MedPatientId;
                else
                    oneInert[19].Value = DBNull.Value;
                if (model.MedVisitId != null)
                    oneInert[20].Value = model.MedVisitId;
                else
                    oneInert[20].Value = DBNull.Value;
                if (model.MedOperId != null)
                    oneInert[21].Value = model.MedOperId;
                else
                    oneInert[21].Value = DBNull.Value;
                if (model.ItemNo != null)
                    oneInert[22].Value = model.ItemNo;
                else
                    oneInert[22].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_OPER_BILL_ITEMS_Update_OLE, oneInert);
            }
        }


        #endregion

    }
}
