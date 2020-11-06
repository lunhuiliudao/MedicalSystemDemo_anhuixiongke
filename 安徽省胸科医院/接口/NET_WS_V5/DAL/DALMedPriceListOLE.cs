using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.OracleClient;
using System.Data.SqlClient;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
    public partial class DALMedPriceList
    {
        //手工维护 MED_BILL_ITEM_CLASS_DICT表数据
        private static readonly string Select_MedPriceList_OLE = "select item_class, item_code, item_name, item_spec, units, price, prefer_price, foreigner_price, performed_by, fee_type_mask, class_on_inp_rcpt, class_on_outp_rcpt, class_on_reckoning, subj_code, class_on_mr, memo, start_date, stop_date, operator, enter_date, input_code, reserved1, reserved2, reserved3, reserved4, reserved5 from med_price_list where item_class = ? and  item_code = ? and item_spec = ? and units = ? ";
        private static readonly string Insert_MedPriceList_OLE = "insert into med_price_list(item_class, item_code, item_name, item_spec, units, price, prefer_price, foreigner_price, performed_by, fee_type_mask, class_on_inp_rcpt, class_on_outp_rcpt, class_on_reckoning, subj_code, class_on_mr, memo, start_date, stop_date, operator, enter_date, input_code, reserved1, reserved2, reserved3, reserved4, reserved5) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private static readonly string Update_MedPriceList_OLE = "update med_price_list set item_name = ?, price = ?,  prefer_price = ?, foreigner_price = ?, performed_by = ?, fee_type_mask = ?,  class_on_inp_rcpt = ?, class_on_outp_rcpt = ?, class_on_reckoning = ?, subj_code = ?, class_on_mr = ?, memo = ?, start_date = ?, stop_date = ?, operator = ?,  enter_date = ?,  input_code = ?, reserved1 = ?,  reserved2 = ?, reserved3 = ?, reserved4 = ?,  reserved5 = ? where item_class = ? and item_code = ?  and item_spec = ? and units = ?";
        private static readonly string Delete_ALL_MedPriceList_OLE = "delete med_price_list ";

        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectOneMedPriceList")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("itemClass",OleDbType.VarChar),
                        new OleDbParameter("itemCode",OleDbType.VarChar),
                        new OleDbParameter("itemSpec",OleDbType.VarChar),
                        new OleDbParameter("units",OleDbType.VarChar)
                    };
                }
                else if (sqlParms == "InsertMedPriceList")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("itemClass",OleDbType.VarChar),
                        new OleDbParameter("itemCode",OleDbType.VarChar),
                        new OleDbParameter("itemName",OleDbType.VarChar), 
                        new OleDbParameter("itemSpec",OleDbType.VarChar),
                        new OleDbParameter("units",OleDbType.VarChar),
                        new OleDbParameter("price",OleDbType.Decimal),
                        new OleDbParameter("preferPrice",OleDbType.Decimal),
                        new OleDbParameter("foreignerPrice",OleDbType.Decimal),
                        new OleDbParameter("performedBy",OleDbType.VarChar),
                        new OleDbParameter("feeTypeMask",OleDbType.Decimal),
                        new OleDbParameter("classOnInpRcpt",OleDbType.VarChar),
                        new OleDbParameter("classOnOutpRcpt",OleDbType.VarChar),
                        new OleDbParameter("classOnReckoning",OleDbType.VarChar),
                        new OleDbParameter("subjCode",OleDbType.VarChar),
                        new OleDbParameter("classOnMr",OleDbType.VarChar),
                        new OleDbParameter("memo",OleDbType.VarChar),
                        new OleDbParameter("startDate",OleDbType.DBTimeStamp),
                        new OleDbParameter("stopDate",OleDbType.DBTimeStamp),
                        new OleDbParameter("operator",OleDbType.VarChar),
                        new OleDbParameter("enterDate",OleDbType.DBTimeStamp),
                        new OleDbParameter("inputCode",OleDbType.VarChar),
                        new OleDbParameter("reserved1",OleDbType.VarChar),
                        new OleDbParameter("reserved2",OleDbType.VarChar),
                        new OleDbParameter("reserved3",OleDbType.VarChar),
                        new OleDbParameter("reserved4",OleDbType.Decimal),
                        new OleDbParameter("reserved5",OleDbType.Decimal)
                    };
                }
                else if (sqlParms == "UpdateMedPriceList")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("itemName",OleDbType.VarChar),
                        new OleDbParameter("price",OleDbType.Decimal),
                        new OleDbParameter("preferPrice",OleDbType.Decimal),
                        new OleDbParameter("foreignerPrice",OleDbType.Decimal),
                        new OleDbParameter("performedBy",OleDbType.VarChar),
                        new OleDbParameter("feeTypeMask",OleDbType.Decimal),
                        new OleDbParameter("classOnInpRcpt",OleDbType.VarChar),
                        new OleDbParameter("classOnOutpRcpt",OleDbType.VarChar),
                        new OleDbParameter("classOnReckoning",OleDbType.VarChar),
                        new OleDbParameter("subjCode",OleDbType.VarChar),
                        new OleDbParameter("classOnMr",OleDbType.VarChar),
                        new OleDbParameter("memo",OleDbType.VarChar),
                        new OleDbParameter("startDate",OleDbType.DBTimeStamp),
                        new OleDbParameter("stopDate",OleDbType.DBTimeStamp),
                        new OleDbParameter("operator",OleDbType.VarChar),
                        new OleDbParameter("enterDate",OleDbType.DBTimeStamp),
                        new OleDbParameter("inputCode",OleDbType.VarChar),
                        new OleDbParameter("reserved1",OleDbType.VarChar),
                        new OleDbParameter("reserved2",OleDbType.VarChar),
                        new OleDbParameter("reserved3",OleDbType.VarChar),
                        new OleDbParameter("reserved4",OleDbType.Decimal),
                        new OleDbParameter("reserved5",OleDbType.Decimal),
                        new OleDbParameter("itemClass",OleDbType.VarChar),
                        new OleDbParameter("itemCode",OleDbType.VarChar),
                        new OleDbParameter("itemSpec",OleDbType.VarChar),
                        new OleDbParameter("units",OleDbType.VarChar)
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedPriceList SelectMedPriceListOLE(string itemClass, string itemCode, string itemSpec, string units)
        {
            Model.MedPriceList OneMedPriceList = null;

            OleDbParameter[] paramPriceList = GetParameterOLE("SelectOneMedPriceList");
            paramPriceList[0].Value = itemClass;
            paramPriceList[1].Value = itemCode;
            paramPriceList[2].Value = itemSpec;
            paramPriceList[3].Value = units;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedPriceList_OLE, paramPriceList))
            {
                if (oleReader.Read())
                {
                    OneMedPriceList = new Model.MedPriceList();
                    if (!oleReader.IsDBNull(0))
                        OneMedPriceList.ItemClass = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        OneMedPriceList.ItemCode = oleReader.GetString(1);
                    if (!oleReader.IsDBNull(2))
                        OneMedPriceList.ItemName = oleReader.GetString(2);
                    if (!oleReader.IsDBNull(3))
                        OneMedPriceList.ItemSpec = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        OneMedPriceList.Units = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        OneMedPriceList.Price = oleReader.GetDecimal(5);
                    if (!oleReader.IsDBNull(6))
                        OneMedPriceList.PreferPrice = oleReader.GetDecimal(6);
                    if (!oleReader.IsDBNull(7))
                        OneMedPriceList.ForeignerPrice = oleReader.GetDecimal(7);
                    if (!oleReader.IsDBNull(8))
                        OneMedPriceList.PerformedBy = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        OneMedPriceList.FeeTypeMask = oleReader.GetDecimal(9);
                    if (!oleReader.IsDBNull(10))
                        OneMedPriceList.ClassOnInpRcpt = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        OneMedPriceList.ClassOnOutpRcpt = oleReader.GetString(11);
                    if (!oleReader.IsDBNull(12))
                        OneMedPriceList.ClassOnReckoning = oleReader.GetString(12);
                    if (!oleReader.IsDBNull(13))
                        OneMedPriceList.SubjCode = oleReader.GetString(13);
                    if (!oleReader.IsDBNull(14))
                        OneMedPriceList.ClassOnMr = oleReader.GetString(14);
                    if (!oleReader.IsDBNull(15))
                        OneMedPriceList.Memo = oleReader.GetString(15);
                    if (!oleReader.IsDBNull(16))
                        OneMedPriceList.StartDate = oleReader.GetDateTime(16);
                    if (!oleReader.IsDBNull(17))
                        OneMedPriceList.StopDate = oleReader.GetDateTime(17);
                    if (!oleReader.IsDBNull(18))
                        OneMedPriceList.Operator = oleReader.GetString(18);
                    if (!oleReader.IsDBNull(19))
                        OneMedPriceList.EnterDate = oleReader.GetDateTime(19);
                    if (!oleReader.IsDBNull(20))
                        OneMedPriceList.InputCode = oleReader.GetString(20);
                    if (!oleReader.IsDBNull(21))
                        OneMedPriceList.Reserved1 = oleReader.GetString(21);
                    if (!oleReader.IsDBNull(22))
                        OneMedPriceList.Reserved2 = oleReader.GetString(22);
                    if (!oleReader.IsDBNull(23))
                        OneMedPriceList.Reserved3 = oleReader.GetString(23);
                    if (!oleReader.IsDBNull(24))
                        OneMedPriceList.Reserved4 = oleReader.GetDecimal(24);
                    if (!oleReader.IsDBNull(25))
                        OneMedPriceList.Reserved5 = oleReader.GetDecimal(25);
                }
                else
                    OneMedPriceList = null;
            }
            return OneMedPriceList;
        }

        public int InsertMedPriceListOLE(Model.MedPriceList MedPriceList)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedPriceList");
                if (MedPriceList.ItemClass != null)
                    oneInert[0].Value = MedPriceList.ItemClass;
                else
                    oneInert[0].Value = DBNull.Value;
                if (MedPriceList.ItemCode != null)
                    oneInert[1].Value = MedPriceList.ItemCode;
                else
                    oneInert[1].Value = DBNull.Value;
                if (MedPriceList.ItemName != null)
                    oneInert[2].Value = MedPriceList.ItemName;
                else
                    oneInert[2].Value = DBNull.Value;
                if (MedPriceList.ItemSpec != null)
                    oneInert[3].Value = MedPriceList.ItemSpec;
                else
                    oneInert[3].Value = DBNull.Value;
                if (MedPriceList.Units != null)
                    oneInert[4].Value = MedPriceList.Units;
                else
                    oneInert[4].Value = DBNull.Value;
                if (MedPriceList.Price.ToString() != null)
                    oneInert[5].Value = MedPriceList.Price;
                else
                    oneInert[5].Value = DBNull.Value;
                if (MedPriceList.PreferPrice.ToString() != null)
                    oneInert[6].Value = MedPriceList.PreferPrice;
                else
                    oneInert[6].Value = DBNull.Value;
                //------------------------------------------------
                if (MedPriceList.ForeignerPrice.ToString() != null)
                    oneInert[7].Value = MedPriceList.ForeignerPrice;
                else
                    oneInert[7].Value = DBNull.Value;
                if (MedPriceList.PerformedBy != null)
                    oneInert[8].Value = MedPriceList.PerformedBy;
                else
                    oneInert[8].Value = DBNull.Value;
                if (MedPriceList.FeeTypeMask.ToString() != null)
                    oneInert[9].Value = MedPriceList.FeeTypeMask;
                else
                    oneInert[9].Value = DBNull.Value;
                if (MedPriceList.ClassOnInpRcpt != null)
                    oneInert[10].Value = MedPriceList.ClassOnInpRcpt;
                else
                    oneInert[10].Value = DBNull.Value;
                if (MedPriceList.ClassOnOutpRcpt != null)
                    oneInert[11].Value = MedPriceList.ClassOnOutpRcpt;
                else
                    oneInert[11].Value = DBNull.Value;
                if (MedPriceList.ClassOnReckoning != null)
                    oneInert[12].Value = MedPriceList.ClassOnReckoning;
                else
                    oneInert[12].Value = DBNull.Value;
                if (MedPriceList.SubjCode != null)
                    oneInert[13].Value = MedPriceList.SubjCode;
                else
                    oneInert[13].Value = DBNull.Value;
                if (MedPriceList.ClassOnMr != null)
                    oneInert[14].Value = MedPriceList.ClassOnMr;
                else
                    oneInert[14].Value = DBNull.Value;
                if (MedPriceList.Memo != null)
                    oneInert[15].Value = MedPriceList.Memo;
                else
                    oneInert[15].Value = DBNull.Value;
                if (MedPriceList.StartDate > DateTime.MinValue)
                    oneInert[16].Value = MedPriceList.StartDate;
                else
                    oneInert[16].Value = DBNull.Value;
                if (MedPriceList.StopDate > DateTime.MinValue)
                    oneInert[17].Value = MedPriceList.StopDate;
                else
                    oneInert[17].Value = DBNull.Value;
                if (MedPriceList.Operator != null)
                    oneInert[18].Value = MedPriceList.Operator;
                else
                    oneInert[18].Value = DBNull.Value;
                if (MedPriceList.EnterDate > DateTime.MinValue)
                    oneInert[19].Value = MedPriceList.EnterDate;
                else
                    oneInert[19].Value = DBNull.Value;
                if (MedPriceList.InputCode != null)
                    oneInert[20].Value = MedPriceList.InputCode;
                else
                    oneInert[20].Value = DBNull.Value;
                if (MedPriceList.Reserved1 != null)
                    oneInert[21].Value = MedPriceList.Reserved1;
                else
                    oneInert[21].Value = DBNull.Value;
                if (MedPriceList.Reserved2 != null)
                    oneInert[22].Value = MedPriceList.Reserved2;
                else
                    oneInert[22].Value = DBNull.Value;
                if (MedPriceList.Reserved3 != null)
                    oneInert[23].Value = MedPriceList.Reserved3;
                else
                    oneInert[23].Value = DBNull.Value;
                if (MedPriceList.Reserved4.ToString() != null)
                    oneInert[24].Value = MedPriceList.Reserved4;
                else
                    oneInert[24].Value = DBNull.Value;
                if (MedPriceList.Reserved5.ToString() != null)
                    oneInert[25].Value = MedPriceList.Reserved5;
                else
                    oneInert[25].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_MedPriceList_OLE, oneInert);
            }
        }

        public int UpdateMedPriceListOLE(Model.MedPriceList MedPriceList)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedPriceList");

                if (MedPriceList.ItemName != null)
                    oneUpdate[0].Value = MedPriceList.ItemName;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (MedPriceList.Price.ToString() != null)
                    oneUpdate[1].Value = MedPriceList.Price;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (MedPriceList.PreferPrice.ToString() != null)
                    oneUpdate[2].Value = MedPriceList.PreferPrice;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (MedPriceList.ForeignerPrice.ToString() != null)
                    oneUpdate[3].Value = MedPriceList.ForeignerPrice;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (MedPriceList.PerformedBy != null)
                    oneUpdate[4].Value = MedPriceList.PerformedBy;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (MedPriceList.FeeTypeMask.ToString() != null)
                    oneUpdate[5].Value = MedPriceList.FeeTypeMask;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (MedPriceList.ClassOnInpRcpt != null)
                    oneUpdate[6].Value = MedPriceList.ClassOnInpRcpt;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (MedPriceList.ClassOnOutpRcpt != null)
                    oneUpdate[7].Value = MedPriceList.ClassOnOutpRcpt;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (MedPriceList.ClassOnReckoning != null)
                    oneUpdate[8].Value = MedPriceList.ClassOnReckoning;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (MedPriceList.SubjCode != null)
                    oneUpdate[9].Value = MedPriceList.SubjCode;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (MedPriceList.ClassOnMr != null)
                    oneUpdate[10].Value = MedPriceList.ClassOnMr;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (MedPriceList.Memo != null)
                    oneUpdate[11].Value = MedPriceList.Memo;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (MedPriceList.StartDate > DateTime.MinValue)
                    oneUpdate[12].Value = MedPriceList.StartDate;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (MedPriceList.StopDate > DateTime.MinValue)
                    oneUpdate[13].Value = MedPriceList.StopDate;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (MedPriceList.Operator != null)
                    oneUpdate[14].Value = MedPriceList.Operator;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (MedPriceList.EnterDate > DateTime.MinValue)
                    oneUpdate[15].Value = MedPriceList.EnterDate;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (MedPriceList.InputCode != null)
                    oneUpdate[16].Value = MedPriceList.InputCode;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (MedPriceList.Reserved1 != null)
                    oneUpdate[17].Value = MedPriceList.Reserved1;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (MedPriceList.Reserved2 != null)
                    oneUpdate[18].Value = MedPriceList.Reserved2;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (MedPriceList.Reserved3 != null)
                    oneUpdate[19].Value = MedPriceList.Reserved3;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (MedPriceList.Reserved4.ToString() != null)
                    oneUpdate[20].Value = MedPriceList.Reserved4;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (MedPriceList.Reserved5.ToString() != null)
                    oneUpdate[21].Value = MedPriceList.Reserved5;
                else
                    oneUpdate[21].Value = DBNull.Value;

                if (MedPriceList.ItemClass != null)
                    oneUpdate[22].Value = MedPriceList.ItemClass;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (MedPriceList.ItemCode != null)
                    oneUpdate[23].Value = MedPriceList.ItemCode;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (MedPriceList.ItemSpec != null)
                    oneUpdate[24].Value = MedPriceList.ItemSpec;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (MedPriceList.Units.ToString() != null)
                    oneUpdate[25].Value = MedPriceList.Units;
                else
                    oneUpdate[25].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_MedPriceList_OLE, oneUpdate);
            }
        }

        public int DeleteAllMedPriceListOLE()
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Delete_ALL_MedPriceList_OLE, null);
            }
        }


        private static readonly string Select_MedPriceList_Odbc = "select item_class, item_code, item_name, item_spec, units, price, prefer_price, foreigner_price, performed_by, fee_type_mask, class_on_inp_rcpt, class_on_outp_rcpt, class_on_reckoning, subj_code, class_on_mr, memo, start_date, stop_date, operator, enter_date, input_code, reserved1, reserved2, reserved3, reserved4, reserved5 from med_price_list where item_class = ? and  item_code = ? and item_spec = ? and units = ? ";
        private static readonly string Insert_MedPriceList_Odbc = "insert into med_price_list(item_class, item_code, item_name, item_spec, units, price, prefer_price, foreigner_price, performed_by, fee_type_mask, class_on_inp_rcpt, class_on_outp_rcpt, class_on_reckoning, subj_code, class_on_mr, memo, start_date, stop_date, operator, enter_date, input_code, reserved1, reserved2, reserved3, reserved4, reserved5) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        private static readonly string Update_MedPriceList_Odbc = "update med_price_list set item_name = ?, price = ?,  prefer_price = ?, foreigner_price = ?, performed_by = ?, fee_type_mask = ?,  class_on_inp_rcpt = ?, class_on_outp_rcpt = ?, class_on_reckoning = ?, subj_code = ?, class_on_mr = ?, memo = ?, start_date = ?, stop_date = ?, operator = ?,  enter_date = ?,  input_code = ?, reserved1 = ?,  reserved2 = ?, reserved3 = ?, reserved4 = ?,  reserved5 = ? where item_class = ? and item_code = ?  and item_spec = ? and units = ?";
        private static readonly string Delete_ALL_MedPriceList_Odbc = "delete med_price_list ";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectOneMedPriceList")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("itemClass",OdbcType.VarChar),
                        new OdbcParameter("itemCode",OdbcType.VarChar),
                        new OdbcParameter("itemSpec",OdbcType.VarChar),
                        new OdbcParameter("units",OdbcType.VarChar)
                    };
                }
                else if (sqlParms == "InsertMedPriceList")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("itemClass",OdbcType.VarChar),
                        new OdbcParameter("itemCode",OdbcType.VarChar),
                        new OdbcParameter("itemName",OdbcType.VarChar), 
                        new OdbcParameter("itemSpec",OdbcType.VarChar),
                        new OdbcParameter("units",OdbcType.VarChar),
                        new OdbcParameter("price",OdbcType.Decimal),
                        new OdbcParameter("preferPrice",OdbcType.Decimal),
                        new OdbcParameter("foreignerPrice",OdbcType.Decimal),
                        new OdbcParameter("performedBy",OdbcType.VarChar),
                        new OdbcParameter("feeTypeMask",OdbcType.Decimal),
                        new OdbcParameter("classOnInpRcpt",OdbcType.VarChar),
                        new OdbcParameter("classOnOutpRcpt",OdbcType.VarChar),
                        new OdbcParameter("classOnReckoning",OdbcType.VarChar),
                        new OdbcParameter("subjCode",OdbcType.VarChar),
                        new OdbcParameter("classOnMr",OdbcType.VarChar),
                        new OdbcParameter("memo",OdbcType.VarChar),
                        new OdbcParameter("startDate",OdbcType.DateTime),
                        new OdbcParameter("stopDate",OdbcType.DateTime),
                        new OdbcParameter("operator",OdbcType.VarChar),
                        new OdbcParameter("enterDate",OdbcType.DateTime),
                        new OdbcParameter("inputCode",OdbcType.VarChar),
                        new OdbcParameter("reserved1",OdbcType.VarChar),
                        new OdbcParameter("reserved2",OdbcType.VarChar),
                        new OdbcParameter("reserved3",OdbcType.VarChar),
                        new OdbcParameter("reserved4",OdbcType.Decimal),
                        new OdbcParameter("reserved5",OdbcType.Decimal)
                    };
                }
                else if (sqlParms == "UpdateMedPriceList")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("itemName",OdbcType.VarChar),
                        new OdbcParameter("price",OdbcType.Decimal),
                        new OdbcParameter("preferPrice",OdbcType.Decimal),
                        new OdbcParameter("foreignerPrice",OdbcType.Decimal),
                        new OdbcParameter("performedBy",OdbcType.VarChar),
                        new OdbcParameter("feeTypeMask",OdbcType.Decimal),
                        new OdbcParameter("classOnInpRcpt",OdbcType.VarChar),
                        new OdbcParameter("classOnOutpRcpt",OdbcType.VarChar),
                        new OdbcParameter("classOnReckoning",OdbcType.VarChar),
                        new OdbcParameter("subjCode",OdbcType.VarChar),
                        new OdbcParameter("classOnMr",OdbcType.VarChar),
                        new OdbcParameter("memo",OdbcType.VarChar),
                        new OdbcParameter("startDate",OdbcType.DateTime),
                        new OdbcParameter("stopDate",OdbcType.DateTime),
                        new OdbcParameter("operator",OdbcType.VarChar),
                        new OdbcParameter("enterDate",OdbcType.DateTime),
                        new OdbcParameter("inputCode",OdbcType.VarChar),
                        new OdbcParameter("reserved1",OdbcType.VarChar),
                        new OdbcParameter("reserved2",OdbcType.VarChar),
                        new OdbcParameter("reserved3",OdbcType.VarChar),
                        new OdbcParameter("reserved4",OdbcType.Decimal),
                        new OdbcParameter("reserved5",OdbcType.Decimal),
                        new OdbcParameter("itemClass",OdbcType.VarChar),
                        new OdbcParameter("itemCode",OdbcType.VarChar),
                        new OdbcParameter("itemSpec",OdbcType.VarChar),
                        new OdbcParameter("units",OdbcType.VarChar)
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }

        public Model.MedPriceList SelectMedPriceListOdbc(string itemClass, string itemCode, string itemSpec, string units)
        {
            Model.MedPriceList OneMedPriceList = null;

            OdbcParameter[] paramPriceList = GetParameterOdbc("SelectOneMedPriceList");
            paramPriceList[0].Value = itemClass;
            paramPriceList[1].Value = itemCode;
            paramPriceList[2].Value = itemSpec;
            paramPriceList[3].Value = units;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MedPriceList_Odbc, paramPriceList))
            {
                if (OdbcReader.Read())
                {
                    OneMedPriceList = new Model.MedPriceList();
                    if (!OdbcReader.IsDBNull(0))
                        OneMedPriceList.ItemClass = OdbcReader.GetString(0);
                    if (!OdbcReader.IsDBNull(1))
                        OneMedPriceList.ItemCode = OdbcReader.GetString(1);
                    if (!OdbcReader.IsDBNull(2))
                        OneMedPriceList.ItemName = OdbcReader.GetString(2);
                    if (!OdbcReader.IsDBNull(3))
                        OneMedPriceList.ItemSpec = OdbcReader.GetString(3);
                    if (!OdbcReader.IsDBNull(4))
                        OneMedPriceList.Units = OdbcReader.GetString(4);
                    if (!OdbcReader.IsDBNull(5))
                        OneMedPriceList.Price = OdbcReader.GetDecimal(5);
                    if (!OdbcReader.IsDBNull(6))
                        OneMedPriceList.PreferPrice = OdbcReader.GetDecimal(6);
                    if (!OdbcReader.IsDBNull(7))
                        OneMedPriceList.ForeignerPrice = OdbcReader.GetDecimal(7);
                    if (!OdbcReader.IsDBNull(8))
                        OneMedPriceList.PerformedBy = OdbcReader.GetString(8);
                    if (!OdbcReader.IsDBNull(9))
                        OneMedPriceList.FeeTypeMask = OdbcReader.GetDecimal(9);
                    if (!OdbcReader.IsDBNull(10))
                        OneMedPriceList.ClassOnInpRcpt = OdbcReader.GetString(10);
                    if (!OdbcReader.IsDBNull(11))
                        OneMedPriceList.ClassOnOutpRcpt = OdbcReader.GetString(11);
                    if (!OdbcReader.IsDBNull(12))
                        OneMedPriceList.ClassOnReckoning = OdbcReader.GetString(12);
                    if (!OdbcReader.IsDBNull(13))
                        OneMedPriceList.SubjCode = OdbcReader.GetString(13);
                    if (!OdbcReader.IsDBNull(14))
                        OneMedPriceList.ClassOnMr = OdbcReader.GetString(14);
                    if (!OdbcReader.IsDBNull(15))
                        OneMedPriceList.Memo = OdbcReader.GetString(15);
                    if (!OdbcReader.IsDBNull(16))
                        OneMedPriceList.StartDate = OdbcReader.GetDateTime(16);
                    if (!OdbcReader.IsDBNull(17))
                        OneMedPriceList.StopDate = OdbcReader.GetDateTime(17);
                    if (!OdbcReader.IsDBNull(18))
                        OneMedPriceList.Operator = OdbcReader.GetString(18);
                    if (!OdbcReader.IsDBNull(19))
                        OneMedPriceList.EnterDate = OdbcReader.GetDateTime(19);
                    if (!OdbcReader.IsDBNull(20))
                        OneMedPriceList.InputCode = OdbcReader.GetString(20);
                    if (!OdbcReader.IsDBNull(21))
                        OneMedPriceList.Reserved1 = OdbcReader.GetString(21);
                    if (!OdbcReader.IsDBNull(22))
                        OneMedPriceList.Reserved2 = OdbcReader.GetString(22);
                    if (!OdbcReader.IsDBNull(23))
                        OneMedPriceList.Reserved3 = OdbcReader.GetString(23);
                    if (!OdbcReader.IsDBNull(24))
                        OneMedPriceList.Reserved4 = OdbcReader.GetDecimal(24);
                    if (!OdbcReader.IsDBNull(25))
                        OneMedPriceList.Reserved5 = OdbcReader.GetDecimal(25);
                }
                else
                    OneMedPriceList = null;
            }
            return OneMedPriceList;
        }

        public int InsertMedPriceListOdbc(Model.MedPriceList MedPriceList)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedPriceList");
                if (MedPriceList.ItemClass != null)
                    oneInert[0].Value = MedPriceList.ItemClass;
                else
                    oneInert[0].Value = DBNull.Value;
                if (MedPriceList.ItemCode != null)
                    oneInert[1].Value = MedPriceList.ItemCode;
                else
                    oneInert[1].Value = DBNull.Value;
                if (MedPriceList.ItemName != null)
                    oneInert[2].Value = MedPriceList.ItemName;
                else
                    oneInert[2].Value = DBNull.Value;
                if (MedPriceList.ItemSpec != null)
                    oneInert[3].Value = MedPriceList.ItemSpec;
                else
                    oneInert[3].Value = DBNull.Value;
                if (MedPriceList.Units != null)
                    oneInert[4].Value = MedPriceList.Units;
                else
                    oneInert[4].Value = DBNull.Value;
                if (MedPriceList.Price.ToString() != null)
                    oneInert[5].Value = MedPriceList.Price;
                else
                    oneInert[5].Value = DBNull.Value;
                if (MedPriceList.PreferPrice.ToString() != null)
                    oneInert[6].Value = MedPriceList.PreferPrice;
                else
                    oneInert[6].Value = DBNull.Value;
                //------------------------------------------------
                if (MedPriceList.ForeignerPrice.ToString() != null)
                    oneInert[7].Value = MedPriceList.ForeignerPrice;
                else
                    oneInert[7].Value = DBNull.Value;
                if (MedPriceList.PerformedBy != null)
                    oneInert[8].Value = MedPriceList.PerformedBy;
                else
                    oneInert[8].Value = DBNull.Value;
                if (MedPriceList.FeeTypeMask.ToString() != null)
                    oneInert[9].Value = MedPriceList.FeeTypeMask;
                else
                    oneInert[9].Value = DBNull.Value;
                if (MedPriceList.ClassOnInpRcpt != null)
                    oneInert[10].Value = MedPriceList.ClassOnInpRcpt;
                else
                    oneInert[10].Value = DBNull.Value;
                if (MedPriceList.ClassOnOutpRcpt != null)
                    oneInert[11].Value = MedPriceList.ClassOnOutpRcpt;
                else
                    oneInert[11].Value = DBNull.Value;
                if (MedPriceList.ClassOnReckoning != null)
                    oneInert[12].Value = MedPriceList.ClassOnReckoning;
                else
                    oneInert[12].Value = DBNull.Value;
                if (MedPriceList.SubjCode != null)
                    oneInert[13].Value = MedPriceList.SubjCode;
                else
                    oneInert[13].Value = DBNull.Value;
                if (MedPriceList.ClassOnMr != null)
                    oneInert[14].Value = MedPriceList.ClassOnMr;
                else
                    oneInert[14].Value = DBNull.Value;
                if (MedPriceList.Memo != null)
                    oneInert[15].Value = MedPriceList.Memo;
                else
                    oneInert[15].Value = DBNull.Value;
                if (MedPriceList.StartDate > DateTime.MinValue)
                    oneInert[16].Value = MedPriceList.StartDate;
                else
                    oneInert[16].Value = DBNull.Value;
                if (MedPriceList.StopDate > DateTime.MinValue)
                    oneInert[17].Value = MedPriceList.StopDate;
                else
                    oneInert[17].Value = DBNull.Value;
                if (MedPriceList.Operator != null)
                    oneInert[18].Value = MedPriceList.Operator;
                else
                    oneInert[18].Value = DBNull.Value;
                if (MedPriceList.EnterDate > DateTime.MinValue)
                    oneInert[19].Value = MedPriceList.EnterDate;
                else
                    oneInert[19].Value = DBNull.Value;
                if (MedPriceList.InputCode != null)
                    oneInert[20].Value = MedPriceList.InputCode;
                else
                    oneInert[20].Value = DBNull.Value;
                if (MedPriceList.Reserved1 != null)
                    oneInert[21].Value = MedPriceList.Reserved1;
                else
                    oneInert[21].Value = DBNull.Value;
                if (MedPriceList.Reserved2 != null)
                    oneInert[22].Value = MedPriceList.Reserved2;
                else
                    oneInert[22].Value = DBNull.Value;
                if (MedPriceList.Reserved3 != null)
                    oneInert[23].Value = MedPriceList.Reserved3;
                else
                    oneInert[23].Value = DBNull.Value;
                if (MedPriceList.Reserved4.ToString() != null)
                    oneInert[24].Value = MedPriceList.Reserved4;
                else
                    oneInert[24].Value = DBNull.Value;
                if (MedPriceList.Reserved5.ToString() != null)
                    oneInert[25].Value = MedPriceList.Reserved5;
                else
                    oneInert[25].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_MedPriceList_Odbc, oneInert);
            }
        }

        public int UpdateMedPriceListOdbc(Model.MedPriceList MedPriceList)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedPriceList");

                if (MedPriceList.ItemName != null)
                    oneUpdate[0].Value = MedPriceList.ItemName;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (MedPriceList.Price.ToString() != null)
                    oneUpdate[1].Value = MedPriceList.Price;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (MedPriceList.PreferPrice.ToString() != null)
                    oneUpdate[2].Value = MedPriceList.PreferPrice;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (MedPriceList.ForeignerPrice.ToString() != null)
                    oneUpdate[3].Value = MedPriceList.ForeignerPrice;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (MedPriceList.PerformedBy != null)
                    oneUpdate[4].Value = MedPriceList.PerformedBy;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (MedPriceList.FeeTypeMask.ToString() != null)
                    oneUpdate[5].Value = MedPriceList.FeeTypeMask;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (MedPriceList.ClassOnInpRcpt != null)
                    oneUpdate[6].Value = MedPriceList.ClassOnInpRcpt;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (MedPriceList.ClassOnOutpRcpt != null)
                    oneUpdate[7].Value = MedPriceList.ClassOnOutpRcpt;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (MedPriceList.ClassOnReckoning != null)
                    oneUpdate[8].Value = MedPriceList.ClassOnReckoning;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (MedPriceList.SubjCode != null)
                    oneUpdate[9].Value = MedPriceList.SubjCode;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (MedPriceList.ClassOnMr != null)
                    oneUpdate[10].Value = MedPriceList.ClassOnMr;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (MedPriceList.Memo != null)
                    oneUpdate[11].Value = MedPriceList.Memo;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (MedPriceList.StartDate > DateTime.MinValue)
                    oneUpdate[12].Value = MedPriceList.StartDate;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (MedPriceList.StopDate > DateTime.MinValue)
                    oneUpdate[13].Value = MedPriceList.StopDate;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (MedPriceList.Operator != null)
                    oneUpdate[14].Value = MedPriceList.Operator;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (MedPriceList.EnterDate > DateTime.MinValue)
                    oneUpdate[15].Value = MedPriceList.EnterDate;
                else
                    oneUpdate[15].Value = DBNull.Value;
                if (MedPriceList.InputCode != null)
                    oneUpdate[16].Value = MedPriceList.InputCode;
                else
                    oneUpdate[16].Value = DBNull.Value;
                if (MedPriceList.Reserved1 != null)
                    oneUpdate[17].Value = MedPriceList.Reserved1;
                else
                    oneUpdate[17].Value = DBNull.Value;
                if (MedPriceList.Reserved2 != null)
                    oneUpdate[18].Value = MedPriceList.Reserved2;
                else
                    oneUpdate[18].Value = DBNull.Value;
                if (MedPriceList.Reserved3 != null)
                    oneUpdate[19].Value = MedPriceList.Reserved3;
                else
                    oneUpdate[19].Value = DBNull.Value;
                if (MedPriceList.Reserved4.ToString() != null)
                    oneUpdate[20].Value = MedPriceList.Reserved4;
                else
                    oneUpdate[20].Value = DBNull.Value;
                if (MedPriceList.Reserved5.ToString() != null)
                    oneUpdate[21].Value = MedPriceList.Reserved5;
                else
                    oneUpdate[21].Value = DBNull.Value;

                if (MedPriceList.ItemClass != null)
                    oneUpdate[22].Value = MedPriceList.ItemClass;
                else
                    oneUpdate[22].Value = DBNull.Value;
                if (MedPriceList.ItemCode != null)
                    oneUpdate[23].Value = MedPriceList.ItemCode;
                else
                    oneUpdate[23].Value = DBNull.Value;
                if (MedPriceList.ItemSpec != null)
                    oneUpdate[24].Value = MedPriceList.ItemSpec;
                else
                    oneUpdate[24].Value = DBNull.Value;
                if (MedPriceList.Units.ToString() != null)
                    oneUpdate[25].Value = MedPriceList.Units;
                else
                    oneUpdate[25].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_MedPriceList_Odbc, oneUpdate);
            }
        }

        public int DeleteAllMedPriceListOdbc()
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Delete_ALL_MedPriceList_Odbc, null);
            }
        }
    }
}
