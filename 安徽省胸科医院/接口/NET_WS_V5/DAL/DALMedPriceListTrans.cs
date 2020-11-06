using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using MedicalSytem.Soft.Model;

namespace MedicalSytem.Soft.DAL
{
    public partial class DALMedPriceList
    {
        public Model.MedPriceList SelectMedPriceListSQL(string itemClass, string itemCode, string itemSpec, string units, System.Data.Common.DbConnection oleCisConn)
        {
            Model.MedPriceList OneMedPriceList = null;

            SqlParameter[] paramPriceList = GetParameterSQL("SelectOneMedPriceList");
            paramPriceList[0].Value = itemClass;
            paramPriceList[1].Value = itemCode;
            paramPriceList[2].Value = itemSpec;
            paramPriceList[3].Value = units;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, Select_MedPriceList_SQL, paramPriceList))
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

        public int InsertMedPriceListSQL(Model.MedPriceList MedPriceList, System.Data.Common.DbTransaction oleCisTrans)
        {
            SqlParameter[] oneInert = GetParameterSQL("InsertMedPriceList");
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

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, Insert_MedPriceList_SQL, oneInert);

        }

        public int UpdateMedPriceListSQL(Model.MedPriceList MedPriceList, System.Data.Common.DbTransaction oleCisTrans)
        {
            SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedPriceList");

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

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, Update_MedPriceList_SQL, oneUpdate);

        }

        public int DeleteAllMedPriceListSQL(System.Data.Common.DbTransaction oleCisTrans)
        {
            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, Delete_ALL_MedPriceList_SQL, null);
        }

        public Model.MedPriceList SelectMedPriceList(string itemClass, string itemCode, string itemSpec, string units, System.Data.Common.DbConnection oleCisConn)
        {
            Model.MedPriceList OneMedPriceList = null;

            OracleParameter[] paramPriceList = GetParameter("SelectOneMedPriceList");
            paramPriceList[0].Value = itemClass;
            paramPriceList[1].Value = itemCode;
            paramPriceList[2].Value = itemSpec;
            paramPriceList[3].Value = units;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, Select_MedPriceList, paramPriceList))
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

        public int InsertMedPriceList(Model.MedPriceList MedPriceList, System.Data.Common.DbTransaction oleCisTrans)
        {
            OracleParameter[] oneInert = GetParameter("InsertMedPriceList");
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

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, Insert_MedPriceList, oneInert);

        }

        public int UpdateMedPriceList(Model.MedPriceList MedPriceList, System.Data.Common.DbTransaction oleCisTrans)
        {
            OracleParameter[] oneUpdate = GetParameter("UpdateMedPriceList");
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

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, Update_MedPriceList, oneUpdate);
        }

        public int DeleteAllMedPriceList( System.Data.Common.DbTransaction oleCisTrans)
        {
            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, Delete_ALL_MedPriceList, null);
        }

    }
}
