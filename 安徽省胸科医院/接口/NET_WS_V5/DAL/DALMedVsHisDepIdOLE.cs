

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2011-03-02 16:24:52
 * 
 * Notes:
 * 
* ******************************************************************/

using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Data.Odbc;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
    /// <summary>
    /// DAL MedVsHisDepId
    /// </summary>

    public partial class DALMedVsHisDepId
    {
        private static readonly string MED_VS_HIS_DEP_ID_Insert_ODBC = "INSERT INTO MED_VS_HIS_DEP_ID (MED_PATIENT_ID,MED_VISIT_ID,MED_DEP_ID,HIS_ADM_WARD_DATE_TIME,HIS_PATIENT_ID,HIS_VISIT_ID) values (?,?,?,?,?,?)";
        private static readonly string MED_VS_HIS_DEP_ID_Update_ODBC = "UPDATE MED_VS_HIS_DEP_ID SET MED_PATIENT_ID=?,MED_VISIT_ID=?,MED_DEP_ID=?,HIS_ADM_WARD_DATE_TIME=?,HIS_PATIENT_ID=?,HIS_VISIT_ID=? WHERE  MED_PATIENT_ID=? AND MED_VISIT_ID=? AND MED_DEP_ID=?";
        private static readonly string MED_VS_HIS_DEP_ID_Delete_ODBC = "DELETE MED_VS_HIS_DEP_ID WHERE  MED_PATIENT_ID=? AND MED_VISIT_ID=? AND MED_DEP_ID=?";
        private static readonly string MED_VS_HIS_DEP_ID_Select_ODBC = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_DEP_ID,HIS_ADM_WARD_DATE_TIME,HIS_PATIENT_ID,HIS_VISIT_ID FROM MED_VS_HIS_DEP_ID where  MED_PATIENT_ID=? AND MED_VISIT_ID=? AND MED_DEP_ID=?";
        private static readonly string MED_VS_HIS_DEP_ID_Select_ALL_ODBC = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_DEP_ID,HIS_ADM_WARD_DATE_TIME,HIS_PATIENT_ID,HIS_VISIT_ID FROM MED_VS_HIS_DEP_ID";
        private static readonly string MED_VS_HIS_DEP_ID_Select_His_ODBC = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_DEP_ID,HIS_ADM_WARD_DATE_TIME,HIS_PATIENT_ID,HIS_VISIT_ID FROM MED_VS_HIS_DEP_ID where  HIS_PATIENT_ID=? AND HIS_VISIT_ID=? AND HIS_ADM_WARD_DATE_TIME=?";
        private static readonly string MED_VS_HIS_DEP_ID_Select_Max_His_ODBC = "SELECT nvl(max(MED_DEP_ID),0) from MED_VS_HIS_DEP_ID where MED_PATIENT_ID=? AND MED_VISIT_ID=?";

        private static readonly string MED_VS_HIS_DEP_ID_Insert_OLE = "INSERT INTO MED_VS_HIS_DEP_ID (MED_PATIENT_ID,MED_VISIT_ID,MED_DEP_ID,HIS_ADM_WARD_DATE_TIME,HIS_PATIENT_ID,HIS_VISIT_ID) values (?,?,?,?,?,?)";
        private static readonly string MED_VS_HIS_DEP_ID_Update_OLE = "UPDATE MED_VS_HIS_DEP_ID SET MED_PATIENT_ID=?,MED_VISIT_ID=?,MED_DEP_ID=?,HIS_ADM_WARD_DATE_TIME=?,HIS_PATIENT_ID=?,HIS_VISIT_ID=? WHERE  MED_PATIENT_ID=? AND MED_VISIT_ID=? AND MED_DEP_ID=?";
        private static readonly string MED_VS_HIS_DEP_ID_Delete_OLE = "DELETE MED_VS_HIS_DEP_ID WHERE  MED_PATIENT_ID=? AND MED_VISIT_ID=? AND MED_DEP_ID=?";
        private static readonly string MED_VS_HIS_DEP_ID_Select_OLE = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_DEP_ID,HIS_ADM_WARD_DATE_TIME,HIS_PATIENT_ID,HIS_VISIT_ID FROM MED_VS_HIS_DEP_ID where  MED_PATIENT_ID=? AND MED_VISIT_ID=? AND MED_DEP_ID=?";
        private static readonly string MED_VS_HIS_DEP_ID_Select_ALL_OLE = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_DEP_ID,HIS_ADM_WARD_DATE_TIME,HIS_PATIENT_ID,HIS_VISIT_ID FROM MED_VS_HIS_DEP_ID";
        private static readonly string MED_VS_HIS_DEP_ID_Select_His_OLE = "SELECT MED_PATIENT_ID,MED_VISIT_ID,MED_DEP_ID,HIS_ADM_WARD_DATE_TIME,HIS_PATIENT_ID,HIS_VISIT_ID FROM MED_VS_HIS_DEP_ID where  HIS_PATIENT_ID=? AND HIS_VISIT_ID=? AND HIS_ADM_WARD_DATE_TIME=?";
        private static readonly string MED_VS_HIS_DEP_ID_Select_Max_His_OLE = "SELECT nvl(max(MED_DEP_ID),0) from MED_VS_HIS_DEP_ID where MED_PATIENT_ID=? AND MED_VISIT_ID=?";

        //public DALMedVsHisDepIdOLE()
        //{
        //}

        #region [获取参数ODBC]
        /// <summary>
        ///获取参数MedVsHisDepId ODBC
        /// </summary>
        public static OdbcParameter[] GetParameterODBC(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisDepId")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("MedPatientId",OdbcType.VarChar),
						new OdbcParameter("MedVisitId",OdbcType.Decimal),
						new OdbcParameter("MedDepId",OdbcType.Decimal),
						new OdbcParameter("HisAdmWardDateTime",OdbcType.DateTime),
						new OdbcParameter("HisPatientId",OdbcType.VarChar),
						new OdbcParameter("HisVisitId",OdbcType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedVsHisDepId")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("MedPatientId",OdbcType.VarChar),
						new OdbcParameter("MedVisitId",OdbcType.Decimal),
						new OdbcParameter("MedDepId",OdbcType.Decimal),
						new OdbcParameter("HisAdmWardDateTime",OdbcType.DateTime),
						new OdbcParameter("HisPatientId",OdbcType.VarChar),
						new OdbcParameter("HisVisitId",OdbcType.VarChar),
						new OdbcParameter("MedPatientId",OdbcType.VarChar),
						new OdbcParameter("MedVisitId",OdbcType.Decimal),
						new OdbcParameter("MedDepId",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedVsHisDepId")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("MedPatientId",OdbcType.VarChar),
						new OdbcParameter("MedVisitId",OdbcType.Decimal),
						new OdbcParameter("MedDepId",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedVsHisDepId")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("MedPatientId",OdbcType.VarChar),
						new OdbcParameter("MedVisitId",OdbcType.Decimal),
						new OdbcParameter("MedDepId",OdbcType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedVsHisDepIdHis")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("HisPatientId",OdbcType.VarChar),
						new OdbcParameter("HisVisitId",OdbcType.Decimal),
						new OdbcParameter("HisAdmWardDateTime",OdbcType.DateTime),
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisDepId")
                {
                    parms = new OdbcParameter[]{
						new OdbcParameter("MedPatientId",OdbcType.VarChar),
						new OdbcParameter("MedVisitId",OdbcType.Decimal),
                    };
                }


                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录ODBC]
        /// <summary>
        ///Add    model  MedVsHisDepId 
        ///Insert Table MED_VS_HIS_DEP_ID
        /// </summary>
        public int InsertMedVsHisDepIdODBC(MedVsHisDepId model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterODBC("InsertMedVsHisDepId");
                if (model.MedPatientId != null)
                    oneInert[0].Value = model.MedPatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneInert[1].Value = model.MedVisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.MedDepId.ToString() != null)
                    oneInert[2].Value = model.MedDepId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.HisAdmWardDateTime != null)
                    oneInert[3].Value = model.HisAdmWardDateTime;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneInert[4].Value = model.HisPatientId;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneInert[5].Value = model.HisVisitId;
                else
                    oneInert[5].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Insert_ODBC, oneInert);
            }
        }
        #endregion
        #region [更新一条记录ODBC]
        /// <summary>
        ///Update    model  MedVsHisDepId 
        ///Update Table     MED_VS_HIS_DEP_ID
        /// </summary>
        public int UpdateMedVsHisDepIdODBC(MedVsHisDepId model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterODBC("UpdateMedVsHisDepId");
                if (model.MedPatientId != null)
                    oneUpdate[0].Value = model.MedPatientId;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneUpdate[1].Value = model.MedVisitId;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.MedDepId.ToString() != null)
                    oneUpdate[2].Value = model.MedDepId;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.HisAdmWardDateTime != null)
                    oneUpdate[3].Value = model.HisAdmWardDateTime;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneUpdate[4].Value = model.HisPatientId;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneUpdate[5].Value = model.HisVisitId;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.MedPatientId != null)
                    oneUpdate[6].Value = model.MedPatientId;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneUpdate[7].Value = model.MedVisitId;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.MedDepId.ToString() != null)
                    oneUpdate[8].Value = model.MedDepId;
                else
                    oneUpdate[8].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Update_ODBC, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录ODBC]
        /// <summary>
        ///Delete    model  MedVsHisDepId 
        ///Delete Table MED_VS_HIS_DEP_ID by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_DEP_ID)
        /// </summary>
        public int DeleteMedVsHisDepIdODBC(string MED_PATIENT_ID, decimal MED_VISIT_ID, decimal MED_DEP_ID)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterODBC("DeleteMedVsHisDepId");
                if (MED_PATIENT_ID != null)
                    oneDelete[0].Value = MED_PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (MED_VISIT_ID.ToString() != null)
                    oneDelete[1].Value = MED_VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (MED_DEP_ID.ToString() != null)
                    oneDelete[2].Value = MED_DEP_ID;
                else
                    oneDelete[2].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Delete_ODBC, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录ODBC]
        /// <summary>
        ///Select    model  MedVsHisDepId 
        ///select Table MED_VS_HIS_DEP_ID by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_DEP_ID)
        /// </summary>
        public MedVsHisDepId SelectMedVsHisDepIdODBC(string MED_PATIENT_ID, decimal MED_VISIT_ID, decimal MED_DEP_ID)
        {
            MedVsHisDepId model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedVsHisDepId");
            parameterValues[0].Value = MED_PATIENT_ID;
            parameterValues[1].Value = MED_VISIT_ID;
            parameterValues[2].Value = MED_DEP_ID;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Select_ODBC, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisDepId();
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
                        model.MedDepId = decimal.Parse(oleReader["MED_DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HisAdmWardDateTime = DateTime.Parse(oleReader["HIS_ADM_WARD_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
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
        public List<MedVsHisDepId> SelectMedVsHisDepIdListODBC()
        {
            List<MedVsHisDepId> modelList = new List<MedVsHisDepId>();
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Select_ALL_ODBC, null))
            {
                while (oleReader.Read())
                {
                    MedVsHisDepId model = new MedVsHisDepId();
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
                        model.MedDepId = decimal.Parse(oleReader["MED_DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HisAdmWardDateTime = DateTime.Parse(oleReader["HIS_ADM_WARD_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
        #region  [获取一条记录ODBC 根据HIS_ADM_WARD_DATE_TIME]
        /// <summary>
        ///Select    model  MedVsHisDepId 
        ///select Table MED_VS_HIS_DEP_ID by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_DEP_ID)
        /// </summary>
        public MedVsHisDepId SelectMedVsHisDepIdHISODBC(string HIS_PATIENT_ID, string HIS_VISIT_ID, DateTime HIS_ADM_WARD_DATE_TIME)
        {
            MedVsHisDepId model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedVsHisDepIdHis");
            parameterValues[0].Value = HIS_PATIENT_ID;
            parameterValues[1].Value = HIS_VISIT_ID;
            parameterValues[2].Value = HIS_ADM_WARD_DATE_TIME;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Select_His_ODBC, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisDepId();
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
                        model.MedDepId = decimal.Parse(oleReader["MED_DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HisAdmWardDateTime = DateTime.Parse(oleReader["HIS_ADM_WARD_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="medPatientId"></param>
        /// <param name="medvisitId"></param>
        /// <returns></returns>
        public int SelectMaxMedVsHisDepIdODBC(string medPatientId, decimal medvisitId)
        {
            OdbcParameter[] maxMedVsHis = GetParameterODBC("SelectMaxMedVsHisDepId");
            maxMedVsHis[0].Value = medPatientId;
            maxMedVsHis[1].Value = medvisitId;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Select_Max_His_ODBC, maxMedVsHis))
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

        #region [获取参数]
        /// <summary>
        ///获取参数MedVsHisDepId OLE
        /// </summary>
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedVsHisDepId")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("MedPatientId",OleDbType.VarChar),
						new OleDbParameter("MedVisitId",OleDbType.Decimal),
						new OleDbParameter("MedDepId",OleDbType.Decimal),
						new OleDbParameter("HisAdmWardDateTime",OleDbType.DBTimeStamp),
						new OleDbParameter("HisPatientId",OleDbType.VarChar),
						new OleDbParameter("HisVisitId",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedVsHisDepId")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("MedPatientId",OleDbType.VarChar),
						new OleDbParameter("MedVisitId",OleDbType.Decimal),
						new OleDbParameter("MedDepId",OleDbType.Decimal),
						new OleDbParameter("HisAdmWardDateTime",OleDbType.DBTimeStamp),
						new OleDbParameter("HisPatientId",OleDbType.VarChar),
						new OleDbParameter("HisVisitId",OleDbType.VarChar),
						new OleDbParameter("MedPatientId",OleDbType.VarChar),
						new OleDbParameter("MedVisitId",OleDbType.Decimal),
						new OleDbParameter("MedDepId",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "DeleteMedVsHisDepId")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("MedPatientId",OleDbType.VarChar),
						new OleDbParameter("MedVisitId",OleDbType.Decimal),
						new OleDbParameter("MedDepId",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedVsHisDepId")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("MedPatientId",OleDbType.VarChar),
						new OleDbParameter("MedVisitId",OleDbType.Decimal),
						new OleDbParameter("MedDepId",OleDbType.Decimal),
                    };
                }
                else if (sqlParms == "SelectMedVsHisDepIdHis")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("HisPatientId",OleDbType.VarChar),
						new OleDbParameter("HisVisitId",OleDbType.Decimal),
						new OleDbParameter("HisAdmWardDateTime",OleDbType.DBTimeStamp),
                    };
                }
                else if (sqlParms == "SelectMaxMedVsHisDepId")
                {
                    parms = new OleDbParameter[]{
						new OleDbParameter("MedPatientId",OleDbType.VarChar),
						new OleDbParameter("MedVisitId",OleDbType.Decimal),
                    };
                }

                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedVsHisDepId 
        ///Insert Table MED_VS_HIS_DEP_ID
        /// </summary>
        public int InsertMedVsHisDepIdOLE(MedVsHisDepId model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedVsHisDepId");
                if (model.MedPatientId != null)
                    oneInert[0].Value = model.MedPatientId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneInert[1].Value = model.MedVisitId;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.MedDepId.ToString() != null)
                    oneInert[2].Value = model.MedDepId;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.HisAdmWardDateTime != null)
                    oneInert[3].Value = model.HisAdmWardDateTime;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneInert[4].Value = model.HisPatientId;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneInert[5].Value = model.HisVisitId;
                else
                    oneInert[5].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Insert_OLE, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedVsHisDepId 
        ///Update Table     MED_VS_HIS_DEP_ID
        /// </summary>
        public int UpdateMedVsHisDepIdOLE(MedVsHisDepId model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedVsHisDepId");
                if (model.MedPatientId != null)
                    oneUpdate[0].Value = model.MedPatientId;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneUpdate[1].Value = model.MedVisitId;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.MedDepId.ToString() != null)
                    oneUpdate[2].Value = model.MedDepId;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.HisAdmWardDateTime != null)
                    oneUpdate[3].Value = model.HisAdmWardDateTime;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.HisPatientId != null)
                    oneUpdate[4].Value = model.HisPatientId;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.HisVisitId != null)
                    oneUpdate[5].Value = model.HisVisitId;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.MedPatientId != null)
                    oneUpdate[6].Value = model.MedPatientId;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.MedVisitId.ToString() != null)
                    oneUpdate[7].Value = model.MedVisitId;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.MedDepId.ToString() != null)
                    oneUpdate[8].Value = model.MedDepId;
                else
                    oneUpdate[8].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Update_OLE, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedVsHisDepId 
        ///Delete Table MED_VS_HIS_DEP_ID by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_DEP_ID)
        /// </summary>
        public int DeleteMedVsHisDepIdOLE(string MED_PATIENT_ID, decimal MED_VISIT_ID, decimal MED_DEP_ID)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedVsHisDepId");
                if (MED_PATIENT_ID != null)
                    oneDelete[0].Value = MED_PATIENT_ID;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (MED_VISIT_ID.ToString() != null)
                    oneDelete[1].Value = MED_VISIT_ID;
                else
                    oneDelete[1].Value = DBNull.Value;
                if (MED_DEP_ID.ToString() != null)
                    oneDelete[2].Value = MED_DEP_ID;
                else
                    oneDelete[2].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Delete_OLE, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedVsHisDepId 
        ///select Table MED_VS_HIS_DEP_ID by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_DEP_ID)
        /// </summary>
        public MedVsHisDepId SelectMedVsHisDepIdOLE(string MED_PATIENT_ID, decimal MED_VISIT_ID, decimal MED_DEP_ID)
        {
            MedVsHisDepId model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedVsHisDepId");
            parameterValues[0].Value = MED_PATIENT_ID;
            parameterValues[1].Value = MED_VISIT_ID;
            parameterValues[2].Value = MED_DEP_ID;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Select_OLE, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisDepId();
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
                        model.MedDepId = decimal.Parse(oleReader["MED_DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HisAdmWardDateTime = DateTime.Parse(oleReader["HIS_ADM_WARD_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        #region  [获取所有记录]
        /// <summary>
        ///获取所有记录
        /// </summary>
        public List<MedVsHisDepId> SelectMedVsHisDepIdListOLE()
        {
            List<MedVsHisDepId> modelList = new List<MedVsHisDepId>();
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Select_ALL_OLE, null))
            {
                while (oleReader.Read())
                {
                    MedVsHisDepId model = new MedVsHisDepId();
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
                        model.MedDepId = decimal.Parse(oleReader["MED_DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HisAdmWardDateTime = DateTime.Parse(oleReader["HIS_ADM_WARD_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
        #region  [获取一条记录 根据HIS_ADM_WARD_DATE_TIME]
        /// <summary>
        ///Select    model  MedVsHisDepId 
        ///select Table MED_VS_HIS_DEP_ID by (string MED_PATIENT_ID,decimal MED_VISIT_ID,decimal MED_DEP_ID)
        /// </summary>
        public MedVsHisDepId SelectMedVsHisDepIdHisOLE(string HIS_PATIENT_ID, string HIS_VISIT_ID, DateTime HIS_ADM_WARD_DATE_TIME)
        {
            MedVsHisDepId model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedVsHisDepIdHis");
            parameterValues[0].Value = HIS_PATIENT_ID;
            parameterValues[1].Value = HIS_VISIT_ID;
            parameterValues[2].Value = HIS_ADM_WARD_DATE_TIME;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Select_His_OLE, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedVsHisDepId();
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
                        model.MedDepId = decimal.Parse(oleReader["MED_DEP_ID"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.HisAdmWardDateTime = DateTime.Parse(oleReader["HIS_ADM_WARD_DATE_TIME"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.HisPatientId = oleReader["HIS_PATIENT_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.HisVisitId = oleReader["HIS_VISIT_ID"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="medPatientId"></param>
        /// <param name="medvisitId"></param>
        /// <returns></returns>
        public int SelectMaxMedVsHisDepIdOLE(string medPatientId, decimal medvisitId)
        {
            OleDbParameter[] maxMedVsHis = GetParameterOLE("SelectMaxMedVsHisDepId");
            maxMedVsHis[0].Value = medPatientId;
            maxMedVsHis[1].Value = medvisitId;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_VS_HIS_DEP_ID_Select_Max_His_OLE, maxMedVsHis))
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

    }
}
