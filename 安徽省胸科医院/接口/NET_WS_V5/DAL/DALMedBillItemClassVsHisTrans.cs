

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:04:46
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
	/// DAL MedBillItemClassVsHis
	/// </summary>
	
	public partial class DALMedBillItemClassVsHis
	{

        public Model.MedBillItemClassVsHis SelectMedBillItemClassVsHisSQL(string classCode, System.Data.Common.DbConnection oleCisConn)
        {
            Model.MedBillItemClassVsHis OneMedBillItemClassVsHis = null;

            SqlParameter[] paramItemClassVsHis = GetParameterSQL("SelectOneMedBillItemClassVsHis");
            paramItemClassVsHis[0].Value = classCode;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_BILL_ITEM_CLASS_VS_HIS_CODE_Select_SQL, paramItemClassVsHis))
            {
                if (oleReader.Read())
                {
                    OneMedBillItemClassVsHis = new Model.MedBillItemClassVsHis();
                    if (!oleReader.IsDBNull(0))
                        OneMedBillItemClassVsHis.ClassCode = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        OneMedBillItemClassVsHis.CodeInHis = oleReader.GetString(1);
                }
                else
                    OneMedBillItemClassVsHis = null;
            }
            return OneMedBillItemClassVsHis;
        }

        public Model.MedBillItemClassVsHis SelectHisMedBillItemClassVsHisSQL(string codeInHis, System.Data.Common.DbConnection oleCisConn)
        {
            Model.MedBillItemClassVsHis OneMedBillItemClassVsHis = null;

            SqlParameter[] paramItemClassVsHis = GetParameterSQL("SelectOneHisMedBillItemClassVsHis");
            paramItemClassVsHis[0].Value = codeInHis;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_BILL_ITEM_CLASS_VS_HIS_Select_His_SQL, paramItemClassVsHis))
            {
                if (oleReader.Read())
                {
                    OneMedBillItemClassVsHis = new Model.MedBillItemClassVsHis();
                    if (!oleReader.IsDBNull(0))
                        OneMedBillItemClassVsHis.ClassCode = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        OneMedBillItemClassVsHis.CodeInHis = oleReader.GetString(1);

                }
                else
                    OneMedBillItemClassVsHis = null;
            }
            return OneMedBillItemClassVsHis;
        }

        public Model.MedBillItemClassVsHis SelectMedBillItemClassVsHis(string classCode, System.Data.Common.DbConnection oleCisConn)
        {
            Model.MedBillItemClassVsHis OneMedBillItemClassVsHis = null;

            OracleParameter[] paramItemClassVsHis = GetParameter("SelectOneMedBillItemClassVsHis");
            paramItemClassVsHis[0].Value = classCode;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_BILL_ITEM_CLASS_VS_HIS_CODE_Select, paramItemClassVsHis))
            {
                if (oleReader.Read())
                {
                    OneMedBillItemClassVsHis = new Model.MedBillItemClassVsHis();
                    if (!oleReader.IsDBNull(0))
                        OneMedBillItemClassVsHis.ClassCode = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        OneMedBillItemClassVsHis.CodeInHis = oleReader.GetString(1);
                }
                else
                    OneMedBillItemClassVsHis = null;
            }
            return OneMedBillItemClassVsHis;
        }

        public Model.MedBillItemClassVsHis SelectHisMedBillItemClassVsHis(string codeInHis, System.Data.Common.DbConnection oleCisConn)
        {
            Model.MedBillItemClassVsHis OneMedBillItemClassVsHis = null;

            OracleParameter[] paramItemClassVsHis = GetParameter("SelectOneHisMedBillItemClassVsHis");
            paramItemClassVsHis[0].Value = codeInHis;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_BILL_ITEM_CLASS_VS_HIS_Select_His, paramItemClassVsHis))
            {
                if (oleReader.Read())
                {
                    OneMedBillItemClassVsHis = new Model.MedBillItemClassVsHis();
                    if (!oleReader.IsDBNull(0))
                        OneMedBillItemClassVsHis.ClassCode = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        OneMedBillItemClassVsHis.CodeInHis = oleReader.GetString(1);
                }
                else
                    OneMedBillItemClassVsHis = null;
            }
            return OneMedBillItemClassVsHis;
        }
	}
}
