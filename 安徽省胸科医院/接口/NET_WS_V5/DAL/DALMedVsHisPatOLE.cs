

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:03:05
 * 
 * Notes:
 * 
* ******************************************************************/

using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
//using System.Data.SqlClient;
//using System.Data.OracleClient;
using MedicalSytem.Soft.Model;
using System.Data.Odbc;
using System.Data.OleDb;
namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedVsHisPat
    /// </summary>

    public partial class DALMedVsHisPat
    {

        private static readonly string MED_VS_HIS_PAT_Insert_ODBC = "INSERT INTO MED_VS_HIS_PAT (MED_PATIENT_ID,MED_VISIT_ID,HIS_PATIENT_ID,HIS_INP_NO,HIS_VISIT_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_VS_HIS_PAT_Update_ODBC = "UPDATE MED_VS_HIS_PAT SET MED_PATIENT_ID=@MedPatientId,MED_VISIT_ID=?,HIS_PATIENT_ID=?,HIS_INP_NO=?,HIS_VISIT_ID=?,CREATE_DATE=?,RESERVED01=?,RESERVED02=?,RESERVED03=?,RESERVED04=?,RESERVED05=?,RESERVED06=?,RESERVED07=?,RESERVED08=? WHERE MED_PATIENT_ID=? AND MED_VISIT_ID=?";
        private static readonly string MED_VS_HIS_PAT_Delete_ODBC = "Delete MED_VS_HIS_PAT WHERE MED_PATIENT_ID=? AND MED_VISIT_ID=?";
        private static readonly string MED_VS_HIS_PAT_Select_ODBC = "SELECT MED_PATIENT_ID,MED_VISIT_ID,HIS_PATIENT_ID,HIS_INP_NO,HIS_VISIT_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08 FROM MED_VS_HIS_PAT where MED_PATIENT_ID=? AND MED_VISIT_ID=?";
        private static readonly string MED_VS_HIS_PAT_Select_ALL_ODBC = "SELECT MED_PATIENT_ID,MED_VISIT_ID,HIS_PATIENT_ID,HIS_INP_NO,HIS_VISIT_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08 FROM MED_VS_HIS_PAT";
        private static readonly string MED_VS_HIS_PAT_Select_Max_His_ODBC = "SELECT NVL(max(MED_VISIT_ID),0) from MED_VS_HIS_PAT where MED_PATIENT_ID = ?";
        private static readonly string MED_VS_HIS_PAT_Select_His_ODBC = "SELECT MED_PATIENT_ID, MED_VISIT_ID, HIS_PATIENT_ID, HIS_INP_NO, HIS_VISIT_ID, create_date, reserved01, reserved02, reserved03, reserved04, reserved05, reserved06, reserved07, reserved08 from med_vs_his_pat where his_patient_id = ? and his_inp_no = ? and his_visit_id = ?";

        private static readonly string MED_VS_HIS_PAT_Insert_OLE = "INSERT INTO MED_VS_HIS_PAT (MED_PATIENT_ID,MED_VISIT_ID,HIS_PATIENT_ID,HIS_INP_NO,HIS_VISIT_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
        private static readonly string MED_VS_HIS_PAT_Update_OLE = "UPDATE MED_VS_HIS_PAT SET MED_PATIENT_ID=@MedPatientId,MED_VISIT_ID=?,HIS_PATIENT_ID=?,HIS_INP_NO=?,HIS_VISIT_ID=?,CREATE_DATE=?,RESERVED01=?,RESERVED02=?,RESERVED03=?,RESERVED04=?,RESERVED05=?,RESERVED06=?,RESERVED07=?,RESERVED08=? WHERE MED_PATIENT_ID=? AND MED_VISIT_ID=?";
        private static readonly string MED_VS_HIS_PAT_Delete_OLE = "Delete MED_VS_HIS_PAT WHERE MED_PATIENT_ID=? AND MED_VISIT_ID=?";
        private static readonly string MED_VS_HIS_PAT_Select_OLE = "SELECT MED_PATIENT_ID,MED_VISIT_ID,HIS_PATIENT_ID,HIS_INP_NO,HIS_VISIT_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08 FROM MED_VS_HIS_PAT where MED_PATIENT_ID=? AND MED_VISIT_ID=?";
        private static readonly string MED_VS_HIS_PAT_Select_ALL_OLE = "SELECT MED_PATIENT_ID,MED_VISIT_ID,HIS_PATIENT_ID,HIS_INP_NO,HIS_VISIT_ID,CREATE_DATE,RESERVED01,RESERVED02,RESERVED03,RESERVED04,RESERVED05,RESERVED06,RESERVED07,RESERVED08 FROM MED_VS_HIS_PAT";
        private static readonly string MED_VS_HIS_PAT_Select_Max_His_OLE = "SELECT NVL(max(MED_VISIT_ID),0) from MED_VS_HIS_PAT where MED_PATIENT_ID = ?";
        private static readonly string MED_VS_HIS_PAT_Select_His_OLE = "SELECT MED_PATIENT_ID, MED_VISIT_ID, HIS_PATIENT_ID, HIS_INP_NO, HIS_VISIT_ID, create_date, reserved01, reserved02, reserved03, reserved04, reserved05, reserved06, reserved07, reserved08 from med_vs_his_pat where his_patient_id = ? and his_inp_no = ? and his_visit_id = ?";
       
        //public DALMedVsHisPat()
        //{
        //}
        #region [获取参数ODBC]
        /// <summary>
        ///获取参数MedVsHisPat ODBC
        /// </summary>
        public static OdbcParameter[] GetParameterODBC(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisPat")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("MedPatientId",OdbcType.VarChar),
							new OdbcParameter("MedVisitId",OdbcType.Decimal),
							new OdbcParameter("HisPatientId",OdbcType.VarChar),
							new OdbcParameter("HisInpNo",OdbcType.VarChar),
							new OdbcParameter("HisVisitId",OdbcType.VarChar),
							new OdbcParameter("CreateDate",OdbcType.DateTime),
							new OdbcParameter("Reserved01",OdbcType.VarChar),
							new OdbcParameter("Reserved02",OdbcType.VarChar),
							new OdbcParameter("Reserved03",OdbcType.VarChar),
							new OdbcParameter("Reserved04",OdbcType.VarChar),
							new OdbcParameter("Reserved05",OdbcType.VarChar),
							new OdbcParameter("Reserved06",OdbcType.VarChar),
							new OdbcParameter("Reserved07",OdbcType.VarChar),
							new OdbcParameter("Reserved08",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedVsHisPat")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("MedPatientId",OdbcType.VarChar),
							new OdbcParameter("MedVisitId",OdbcType.Decimal),
							new OdbcParameter("HisPatientId",OdbcType.VarChar),
							new OdbcParameter("HisInpNo",OdbcType.VarChar),
							new OdbcParameter("HisVisitId",OdbcType.VarChar),
							new OdbcParameter("CreateDate",OdbcType.DateTime),
							new OdbcParameter("Reserved01",OdbcType.VarChar),
							new OdbcParameter("Reserved02",OdbcType.VarChar),
							new OdbcParameter("Reserved03",OdbcType.VarChar),
							new OdbcParameter("Reserved04",OdbcType.VarChar),
							new OdbcParameter("Reserved05",OdbcType.VarChar),
							new OdbcParameter("Reserved06",OdbcType.VarChar),
							new OdbcParameter("Reserved07",OdbcType.VarChar),
							new OdbcParameter("Reserved08",OdbcType.VarChar),
							new OdbcParameter("MedPatientId",OdbcType.VarChar),
							new OdbcParameter("MedVisitId",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedVsHisPat")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("MedPatientId",OdbcType.VarChar),
							new OdbcParameter("MedVisitId",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedVsHisPat")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("MedPatientId",OdbcType.VarChar),
						new OdbcParameter("MedVisitId",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisPat")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("MedPatientId",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedVsHisPatHisForHis")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("HisPatientId",OdbcType.VarChar),
						new OdbcParameter("HisInpNo",OdbcType.VarChar),
						new OdbcParameter("HisVisitId",OdbcType.VarChar),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录ODBC]
        /// <summary>
        ///Add    model  MedVsHisPat 
        ///Insert Table MED_VS_HIS_PAT
        /// </summary>
        public int InsertMedVsHisPatODBC(MedVsHisPat model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterODBC("InsertMedVsHisPat");
                if (model.MedPatientId != null)
                    oneInert[0].Value = model.MedPatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneInert[1].Value = model.MedVisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneInert[2].Value = model.HisPatientId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.HisInpNo != null)
                    oneInert[3].Value = model.HisInpNo;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneInert[4].Value = model.HisVisitId;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.CreateDate > DateTime.MinValue)
                    oneInert[5].Value = model.CreateDate;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneInert[6].Value = model.Reserved01;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneInert[7].Value = model.Reserved02;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneInert[8].Value = model.Reserved03;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Reserved04 != null)
                    oneInert[9].Value = model.Reserved04;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.Reserved05 != null)
                    oneInert[10].Value = model.Reserved05;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.Reserved06 != null)
                    oneInert[11].Value = model.Reserved06;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.Reserved07 != null)
                    oneInert[12].Value = model.Reserved07;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.Reserved08 != null)
                    oneInert[13].Value = model.Reserved08;
                else
                    oneInert[13].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString,CommandType.Text, MED_VS_HIS_PAT_Insert_ODBC, oneInert);
            }
        }
        #endregion
        #region [更新一条记录ODBC]
        /// <summary>
        ///Update    model  MedVsHisPat 
        ///Update Table     MED_VS_HIS_PAT
        /// </summary>
        public int UpdateMedVsHisPatODBC(MedVsHisPat model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterODBC("UpdateMedVsHisPat");
                if (model.MedPatientId != null)
                    oneUpdate[0].Value = model.MedPatientId;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneUpdate[1].Value = model.MedVisitId;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneUpdate[2].Value = model.HisPatientId;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.HisInpNo != null)
                    oneUpdate[3].Value = model.HisInpNo;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneUpdate[4].Value = model.HisVisitId;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.CreateDate > DateTime.MinValue)
                    oneUpdate[5].Value = model.CreateDate;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneUpdate[6].Value = model.Reserved01;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneUpdate[7].Value = model.Reserved02;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneUpdate[8].Value = model.Reserved03;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.Reserved04 != null)
                    oneUpdate[9].Value = model.Reserved04;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.Reserved05 != null)
                    oneUpdate[10].Value = model.Reserved05;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.Reserved06 != null)
                    oneUpdate[11].Value = model.Reserved06;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.Reserved07 != null)
                    oneUpdate[12].Value = model.Reserved07;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.Reserved08 != null)
                    oneUpdate[13].Value = model.Reserved08;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.MedPatientId != null)
                    oneUpdate[14].Value = model.MedPatientId;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneUpdate[15].Value = model.MedVisitId;
                else
                    oneUpdate[15].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Update_ODBC, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录ODBC]
        /// <summary>
        ///Delete    model  MedVsHisPat 
        ///Delete Table MED_VS_HIS_PAT by (string MED_PATIENT_ID,decimal MED_VISIT_ID)
        /// </summary>
        public int DeleteMedVsHisPatODBC(string MED_PATIENT_ID, decimal MED_VISIT_ID)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterODBC("DeleteMedVsHisPat");
                if (MED_PATIENT_ID != null)
                    oneDelete[0].Value = MED_PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (MED_VISIT_ID.ToString() != null)
                    oneDelete[1].Value = MED_VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Delete_ODBC, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录ODBC]
        /// <summary>
        ///Select    model  MedVsHisPat 
        ///select Table MED_VS_HIS_PAT by (string MED_PATIENT_ID,decimal MED_VISIT_ID)
        /// </summary>
        public MedVsHisPat SelectMedVsHisPatODBC(string MED_PATIENT_ID, decimal MED_VISIT_ID)
        {
            MedVsHisPat model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedVsHisPat");
            parameterValues[0].Value = MED_PATIENT_ID;
            parameterValues[1].Value = MED_VISIT_ID;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Select_ODBC, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisPat();
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
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HisInpNo = oleReader["HIS_INP_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved06 = oleReader["RESERVED06"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.Reserved07 = oleReader["RESERVED07"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Reserved08 = oleReader["RESERVED08"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        #region  [获取所有记录ODBC]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedVsHisPat> SelectMedVsHisPatListODBC()
        {
            List<MedVsHisPat> modelList = new List<MedVsHisPat>();
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Select_ALL_ODBC, null))
            {
                while (oleReader.Read())
                {
                    MedVsHisPat model = new MedVsHisPat();
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
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HisInpNo = oleReader["HIS_INP_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved06 = oleReader["RESERVED06"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.Reserved07 = oleReader["RESERVED07"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Reserved08 = oleReader["RESERVED08"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        public int SelectMaxMedVsHisPatODBC(string patientId)
        {
            OdbcParameter[] maxMedVsHis = GetParameterODBC("SelectMaxMedVsHisPat");
            maxMedVsHis[0].Value = patientId;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Select_Max_His_ODBC, maxMedVsHis))
            {
                if (oleReader.Read())
                {
                    return Convert.ToInt32(oleReader[0]);
                }
                else
                {
                    return 0;
                }
            }
        }

        public Model.MedVsHisPat SelectMedVsHisPatHisODBC(string hisPatientId, string hisInpNo, string hisVisitId)
        {
            Model.MedVsHisPat oneMedVsHisPat = null;
            OdbcParameter[] MedVsHisPatParams = GetParameterODBC("SelectMedVsHisPatHisForHis");
            MedVsHisPatParams[0].Value = hisPatientId;
            MedVsHisPatParams[1].Value = hisInpNo;
            MedVsHisPatParams[2].Value = hisVisitId;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Select_His_ODBC, MedVsHisPatParams))
            {
                if (oleReader.Read())
                {
                    oneMedVsHisPat = new Model.MedVsHisPat();
                    if (!oleReader.IsDBNull(0))
                        oneMedVsHisPat.MedPatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisPat.MedVisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisPat.HisPatientId = oleReader.GetString(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisPat.HisInpNo = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisPat.HisVisitId = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisPat.CreateDate = oleReader.GetDateTime(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisPat.Reserved01 = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisPat.Reserved02 = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        oneMedVsHisPat.Reserved03 = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        oneMedVsHisPat.Reserved04 = oleReader.GetString(9);
                    if (!oleReader.IsDBNull(10))
                        oneMedVsHisPat.Reserved05 = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        oneMedVsHisPat.Reserved06 = oleReader.GetString(11);
                    if (!oleReader.IsDBNull(12))
                        oneMedVsHisPat.Reserved07 = oleReader.GetString(12);
                    if (!oleReader.IsDBNull(13))
                        oneMedVsHisPat.Reserved08 = oleReader.GetString(13);
                }
                else
                    oneMedVsHisPat = null;
            }
            return oneMedVsHisPat;
        }

        #region [获取参数OLE]
        /// <summary>
        ///获取参数MedVsHisPat
        /// </summary>
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisPat")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter(":MedPatientId",OleDbType.VarChar),
							new OleDbParameter(":MedVisitId",OleDbType.Decimal),
							new OleDbParameter(":HisPatientId",OleDbType.VarChar),
							new OleDbParameter(":HisInpNo",OleDbType.VarChar),
							new OleDbParameter(":HisVisitId",OleDbType.VarChar),
							new OleDbParameter(":CreateDate",OleDbType.DBTimeStamp),
							new OleDbParameter(":Reserved01",OleDbType.VarChar),
							new OleDbParameter(":Reserved02",OleDbType.VarChar),
							new OleDbParameter(":Reserved03",OleDbType.VarChar),
							new OleDbParameter(":Reserved04",OleDbType.VarChar),
							new OleDbParameter(":Reserved05",OleDbType.VarChar),
							new OleDbParameter(":Reserved06",OleDbType.VarChar),
							new OleDbParameter(":Reserved07",OleDbType.VarChar),
							new OleDbParameter(":Reserved08",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedVsHisPat")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter(":MedPatientId",OleDbType.VarChar),
							new OleDbParameter(":MedVisitId",OleDbType.Decimal),
							new OleDbParameter(":HisPatientId",OleDbType.VarChar),
							new OleDbParameter(":HisInpNo",OleDbType.VarChar),
							new OleDbParameter(":HisVisitId",OleDbType.VarChar),
							new OleDbParameter(":CreateDate",OleDbType.DBTimeStamp),
							new OleDbParameter(":Reserved01",OleDbType.VarChar),
							new OleDbParameter(":Reserved02",OleDbType.VarChar),
							new OleDbParameter(":Reserved03",OleDbType.VarChar),
							new OleDbParameter(":Reserved04",OleDbType.VarChar),
							new OleDbParameter(":Reserved05",OleDbType.VarChar),
							new OleDbParameter(":Reserved06",OleDbType.VarChar),
							new OleDbParameter(":Reserved07",OleDbType.VarChar),
							new OleDbParameter(":Reserved08",OleDbType.VarChar),
							new OleDbParameter(":MedPatientId",OdbcType.VarChar),
							new OleDbParameter(":MedVisitId",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedVsHisPat")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter(":MedPatientId",OleDbType.VarChar),
							new OleDbParameter(":MedVisitId",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedVsHisPat")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter(":MedPatientId",OleDbType.VarChar),
							new OleDbParameter(":MedVisitId",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisPat")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter(":MedPatientId",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedVsHisPatHisForHis")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter(":HisPatientId",OleDbType.VarChar),
						new OleDbParameter(":HisInpNo",OleDbType.VarChar),
						new OleDbParameter(":HisVisitId",OleDbType.VarChar),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录OLE]
        /// <summary>
        ///Add    model  MedVsHisPat 
        ///Insert Table MED_VS_HIS_PAT
        /// </summary>
        public int InsertMedVsHisPatOLE(MedVsHisPat model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedVsHisPat");
                if (model.MedPatientId != null)
                    oneInert[0].Value = model.MedPatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneInert[1].Value = model.MedVisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneInert[2].Value = model.HisPatientId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.HisInpNo != null)
                    oneInert[3].Value = model.HisInpNo;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneInert[4].Value = model.HisVisitId;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.CreateDate > DateTime.MinValue)
                    oneInert[5].Value = model.CreateDate;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneInert[6].Value = model.Reserved01;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneInert[7].Value = model.Reserved02;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneInert[8].Value = model.Reserved03;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.Reserved04 != null)
                    oneInert[9].Value = model.Reserved04;
                else
                    oneInert[9].Value = DBNull.Value;
                if (model.Reserved05 != null)
                    oneInert[10].Value = model.Reserved05;
                else
                    oneInert[10].Value = DBNull.Value;
                if (model.Reserved06 != null)
                    oneInert[11].Value = model.Reserved06;
                else
                    oneInert[11].Value = DBNull.Value;
                if (model.Reserved07 != null)
                    oneInert[12].Value = model.Reserved07;
                else
                    oneInert[12].Value = DBNull.Value;
                if (model.Reserved08 != null)
                    oneInert[13].Value = model.Reserved08;
                else
                    oneInert[13].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString,CommandType.Text, MED_VS_HIS_PAT_Insert_OLE, oneInert);
            }
        }
        #endregion
        #region [更新一条记录OLE]
        /// <summary>
        ///Update    model  MedVsHisPat 
        ///Update Table     MED_VS_HIS_PAT
        /// </summary>
        public int UpdateMedVsHisPatOLE(MedVsHisPat model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedVsHisPat");
                if (model.MedPatientId != null)
                    oneUpdate[0].Value = model.MedPatientId;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneUpdate[1].Value = model.MedVisitId;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneUpdate[2].Value = model.HisPatientId;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.HisInpNo != null)
                    oneUpdate[3].Value = model.HisInpNo;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneUpdate[4].Value = model.HisVisitId;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.CreateDate > DateTime.MinValue)
                    oneUpdate[5].Value = model.CreateDate;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneUpdate[6].Value = model.Reserved01;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.Reserved02 != null)
                    oneUpdate[7].Value = model.Reserved02;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.Reserved03 != null)
                    oneUpdate[8].Value = model.Reserved03;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.Reserved04 != null)
                    oneUpdate[9].Value = model.Reserved04;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.Reserved05 != null)
                    oneUpdate[10].Value = model.Reserved05;
                else
                    oneUpdate[10].Value = DBNull.Value;
                if (model.Reserved06 != null)
                    oneUpdate[11].Value = model.Reserved06;
                else
                    oneUpdate[11].Value = DBNull.Value;
                if (model.Reserved07 != null)
                    oneUpdate[12].Value = model.Reserved07;
                else
                    oneUpdate[12].Value = DBNull.Value;
                if (model.Reserved08 != null)
                    oneUpdate[13].Value = model.Reserved08;
                else
                    oneUpdate[13].Value = DBNull.Value;
                if (model.MedPatientId != null)
                    oneUpdate[14].Value = model.MedPatientId;
                else
                    oneUpdate[14].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneUpdate[15].Value = model.MedVisitId;
                else
                    oneUpdate[15].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Update_OLE, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录OLE]
        /// <summary>
        ///Delete    model  MedVsHisPat 
        ///Delete Table MED_VS_HIS_PAT by (string MED_PATIENT_ID,decimal MED_VISIT_ID)
        /// </summary>
        public int DeleteMedVsHisPatOLE(string MED_PATIENT_ID, decimal MED_VISIT_ID)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedVsHisPat");
                if (MED_PATIENT_ID != null)
                    oneDelete[0].Value = MED_PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (MED_VISIT_ID.ToString() != null)
                    oneDelete[1].Value = MED_VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Delete_OLE, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录OLE]
        /// <summary>
        ///Select    model  MedVsHisPat 
        ///select Table MED_VS_HIS_PAT by (string MED_PATIENT_ID,decimal MED_VISIT_ID)
        /// </summary>
        public MedVsHisPat SelectMedVsHisPatOLE(string MED_PATIENT_ID, decimal MED_VISIT_ID)
        {
            MedVsHisPat model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedVsHisPat");
            parameterValues[0].Value = MED_PATIENT_ID;
            parameterValues[1].Value = MED_VISIT_ID;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Select_OLE, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisPat();
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
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HisInpNo = oleReader["HIS_INP_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved06 = oleReader["RESERVED06"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.Reserved07 = oleReader["RESERVED07"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Reserved08 = oleReader["RESERVED08"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        #region  [获取所有记录OLE]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedVsHisPat> SelectMedVsHisPatListOLE()
        {
            List<MedVsHisPat> modelList = new List<MedVsHisPat>();
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Select_ALL_OLE, null))
            {
                while (oleReader.Read())
                {
                    MedVsHisPat model = new MedVsHisPat();
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
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HisInpNo = oleReader["HIS_INP_NO"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Reserved02 = oleReader["RESERVED02"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.Reserved03 = oleReader["RESERVED03"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.Reserved04 = oleReader["RESERVED04"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(10))
                    {
                        model.Reserved05 = oleReader["RESERVED05"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(11))
                    {
                        model.Reserved06 = oleReader["RESERVED06"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(12))
                    {
                        model.Reserved07 = oleReader["RESERVED07"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(13))
                    {
                        model.Reserved08 = oleReader["RESERVED08"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
        public int SelectMaxMedVsHisPatOLE(string patientId)
        {
            OleDbParameter[] maxMedVsHis = GetParameterOLE("SelectMaxMedVsHisPat");
            maxMedVsHis[0].Value = patientId;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Select_Max_His_OLE, maxMedVsHis))
            {
                if (oleReader.Read())
                {
                    return (int)oleReader.GetDecimal(0);
                }
                else
                {
                    return 0;
                }
            }
        }

        public Model.MedVsHisPat SelectMedVsHisPatHisOLE(string hisPatientId, string hisInpNo, string hisVisitId)
        {
            Model.MedVsHisPat oneMedVsHisPat = null;
            OleDbParameter[] MedVsHisPatParams = GetParameterOLE("SelectMedVsHisPatHisForHis");
            MedVsHisPatParams[0].Value = hisPatientId;
            MedVsHisPatParams[1].Value = hisInpNo;
            MedVsHisPatParams[2].Value = hisVisitId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_PAT_Select_His_OLE, MedVsHisPatParams))
            {
                if (oleReader.Read())
                {
                    oneMedVsHisPat = new Model.MedVsHisPat();
                    if (!oleReader.IsDBNull(0))
                        oneMedVsHisPat.MedPatientId = oleReader.GetString(0);
                    if (!oleReader.IsDBNull(1))
                        oneMedVsHisPat.MedVisitId = oleReader.GetDecimal(1);
                    if (!oleReader.IsDBNull(2))
                        oneMedVsHisPat.HisPatientId = oleReader.GetString(2);
                    if (!oleReader.IsDBNull(3))
                        oneMedVsHisPat.HisInpNo = oleReader.GetString(3);
                    if (!oleReader.IsDBNull(4))
                        oneMedVsHisPat.HisVisitId = oleReader.GetString(4);
                    if (!oleReader.IsDBNull(5))
                        oneMedVsHisPat.CreateDate = oleReader.GetDateTime(5);
                    if (!oleReader.IsDBNull(6))
                        oneMedVsHisPat.Reserved01 = oleReader.GetString(6);
                    if (!oleReader.IsDBNull(7))
                        oneMedVsHisPat.Reserved02 = oleReader.GetString(7);
                    if (!oleReader.IsDBNull(8))
                        oneMedVsHisPat.Reserved03 = oleReader.GetString(8);
                    if (!oleReader.IsDBNull(9))
                        oneMedVsHisPat.Reserved04 = oleReader.GetString(9);
                    if (!oleReader.IsDBNull(10))
                        oneMedVsHisPat.Reserved05 = oleReader.GetString(10);
                    if (!oleReader.IsDBNull(11))
                        oneMedVsHisPat.Reserved06 = oleReader.GetString(11);
                    if (!oleReader.IsDBNull(12))
                        oneMedVsHisPat.Reserved07 = oleReader.GetString(12);
                    if (!oleReader.IsDBNull(13))
                        oneMedVsHisPat.Reserved08 = oleReader.GetString(13);
                }
                else
                    oneMedVsHisPat = null;
            }
            return oneMedVsHisPat;
        }
    }
}
