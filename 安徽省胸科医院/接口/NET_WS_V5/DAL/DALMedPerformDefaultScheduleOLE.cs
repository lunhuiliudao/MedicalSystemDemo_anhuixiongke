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
    public partial class DALMedPerformDefaultSchedule
    {
        private static readonly string MED_PERFORM_DEFAULT_SCHEDULE_Insert_OLE = "INSERT INTO MED_PERFORM_DEFAULT_SCHEDULE (SERIAL_NO,FREQ_DESC,ADMINISTRATION,DEFAULT_SCHEDULE) values (?,?,?,?)";
        private static readonly string MED_PERFORM_DEFAULT_SCHEDULE_Update_OLE = "UPDATE MED_PERFORM_DEFAULT_SCHEDULE SET SERIAL_NO=?,FREQ_DESC=?,ADMINISTRATION=?,DEFAULT_SCHEDULE=? WHERE  FREQ_DESC=? AND ADMINISTRATION=?";
        private static readonly string MED_PERFORM_DEFAULT_SCHEDULE_Delete_OLE = "DELETE MED_PERFORM_DEFAULT_SCHEDULE WHERE  FREQ_DESC=? AND ADMINISTRATION=?";
        private static readonly string MED_PERFORM_DEFAULT_SCHEDULE_Select_OLE = "SELECT SERIAL_NO,FREQ_DESC,ADMINISTRATION,DEFAULT_SCHEDULE FROM MED_PERFORM_DEFAULT_SCHEDULE where  FREQ_DESC=? AND ADMINISTRATION=?";
        private static readonly string MED_PERFORM_DEFAULT_SCHEDULE_Select_Freq_OLE = "SELECT SERIAL_NO,FREQ_DESC,ADMINISTRATION,DEFAULT_SCHEDULE FROM MED_PERFORM_DEFAULT_SCHEDULE where  FREQ_DESC=?";
        private static readonly string MED_PERFORM_DEFAULT_SCHEDULE_Select_ALL_OLE = "SELECT SERIAL_NO,FREQ_DESC,ADMINISTRATION,DEFAULT_SCHEDULE FROM MED_PERFORM_DEFAULT_SCHEDULE";
        private static readonly string MED_PERFORM_DEFAULT_SCHEDULE_Insert_ODBC = "INSERT INTO MED_PERFORM_DEFAULT_SCHEDULE (SERIAL_NO,FREQ_DESC,ADMINISTRATION,DEFAULT_SCHEDULE) values (?,?,?,?)";
        private static readonly string MED_PERFORM_DEFAULT_SCHEDULE_Update_ODBC = "UPDATE MED_PERFORM_DEFAULT_SCHEDULE SET SERIAL_NO=?,FREQ_DESC=?,ADMINISTRATION=?,DEFAULT_SCHEDULE=? WHERE  FREQ_DESC=? AND ADMINISTRATION=?";
        private static readonly string MED_PERFORM_DEFAULT_SCHEDULE_Delete_ODBC = "DELETE MED_PERFORM_DEFAULT_SCHEDULE WHERE  FREQ_DESC=? AND ADMINISTRATION=?";
        private static readonly string MED_PERFORM_DEFAULT_SCHEDULE_Select_ODBC = "SELECT SERIAL_NO,FREQ_DESC,ADMINISTRATION,DEFAULT_SCHEDULE FROM MED_PERFORM_DEFAULT_SCHEDULE where  FREQ_DESC=? AND ADMINISTRATION=?";
        private static readonly string MED_PERFORM_DEFAULT_SCHEDULE_Select_Freq_ODBC = "SELECT SERIAL_NO,FREQ_DESC,ADMINISTRATION,DEFAULT_SCHEDULE FROM MED_PERFORM_DEFAULT_SCHEDULE where  FREQ_DESC=?";
        private static readonly string MED_PERFORM_DEFAULT_SCHEDULE_Select_ALL_ODBC = "SELECT SERIAL_NO,FREQ_DESC,ADMINISTRATION,DEFAULT_SCHEDULE FROM MED_PERFORM_DEFAULT_SCHEDULE";

        #region [获取参数ODBC]
        /// <summary>
        ///获取参数MedPerformDefaultSchedule ODBC
        /// </summary>
        public static OdbcParameter[] GetParameterODBC(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);

            if (parms == null)
            {
                if (sqlParms == "InsertMedPerformDefaultSchedule")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("@SerialNo",SqlDbType.Decimal),
							new OdbcParameter("@FreqDesc",SqlDbType.VarChar),
							new OdbcParameter("@Administration",SqlDbType.VarChar),
							new OdbcParameter("@DefaultSchedule",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedPerformDefaultSchedule")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("@SerialNo",SqlDbType.Decimal),
							new OdbcParameter("@FreqDesc",SqlDbType.VarChar),
							new OdbcParameter("@Administration",SqlDbType.VarChar),
							new OdbcParameter("@DefaultSchedule",SqlDbType.VarChar),
							new OdbcParameter("@FreqDesc",SqlDbType.Decimal),
							new OdbcParameter("@Administration",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedPerformDefaultSchedule")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("@FreqDesc",SqlDbType.VarChar),
							new OdbcParameter("@Administration",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPerformDefaultSchedule")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("@FreqDesc",SqlDbType.VarChar),
							new OdbcParameter("@Administration",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPerformDefaultScheduleFreq")
                {
                    parms = new OdbcParameter[]{
							new OdbcParameter("@FreqDesc",SqlDbType.VarChar),
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录ODBC]
        /// <summary>
        ///Add    model  MedPerformDefaultSchedule 
        ///Insert Table MED_PERFORM_DEFAULT_SCHEDULE
        /// </summary>
        public int InsertMedPerformDefaultScheduleODBC(MedPerformDefaultSchedule model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterODBC("InsertMedPerformDefaultSchedule");
                if (model.SerialNo.ToString() != null)
                    oneInert[0].Value = model.SerialNo;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.FreqDesc != null)
                    oneInert[1].Value = model.FreqDesc;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.Administration != null)
                    oneInert[2].Value = model.Administration;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.DefaultSchedule != null)
                    oneInert[3].Value = model.DefaultSchedule;
                else
                    oneInert[3].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Insert_ODBC, oneInert);
            }
        }
        #endregion
        #region [更新一条记录ODBC]
        /// <summary>
        ///Update    model  MedPerformDefaultSchedule 
        ///Update Table     MED_PERFORM_DEFAULT_SCHEDULE
        /// </summary>
        public int UpdateMedPerformDefaultScheduleODBC(MedPerformDefaultSchedule model)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterODBC("UpdateMedPerformDefaultSchedule");
                if (model.SerialNo.ToString() != null)
                    oneUpdate[0].Value = model.SerialNo;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.FreqDesc != null)
                    oneUpdate[1].Value = model.FreqDesc;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.Administration != null)
                    oneUpdate[2].Value = model.Administration;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.DefaultSchedule != null)
                    oneUpdate[3].Value = model.DefaultSchedule;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.FreqDesc != null)
                    oneUpdate[4].Value = model.FreqDesc;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.Administration != null)
                    oneUpdate[5].Value = model.Administration;
                else
                    oneUpdate[5].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Update_ODBC, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录ODBC]
        /// <summary>
        ///Delete    model  MedPerformDefaultSchedule 
        ///Delete Table MED_PERFORM_DEFAULT_SCHEDULE by (string FREQ_DESC,string ADMINISTRATION)
        /// </summary>
        public int DeleteMedPerformDefaultScheduleODBC(string FREQ_DESC, string ADMINISTRATION)
        {
            using (OdbcConnection oleCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneDelete = GetParameterODBC("DeleteMedPerformDefaultSchedule");
                if (FREQ_DESC != null)
                    oneDelete[0].Value = FREQ_DESC;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (ADMINISTRATION != null)
                    oneDelete[1].Value = ADMINISTRATION;
                else
                    oneDelete[1].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcHelper.ConnectionString, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Delete_ODBC, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录ODBC]
        /// <summary>
        ///Select    model  MedPerformDefaultSchedule 
        ///select Table MED_PERFORM_DEFAULT_SCHEDULE by (string FREQ_DESC,string ADMINISTRATION)
        /// </summary>
        public MedPerformDefaultSchedule SelectMedPerformDefaultScheduleODBC(string FREQ_DESC, string ADMINISTRATION)
        {
            MedPerformDefaultSchedule model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedPerformDefaultSchedule");
            parameterValues[0].Value = FREQ_DESC;
            parameterValues[1].Value = ADMINISTRATION;
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Select_ODBC, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPerformDefaultSchedule();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.FreqDesc = oleReader["FREQ_DESC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.Administration = oleReader["ADMINISTRATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.DefaultSchedule = oleReader["DEFAULT_SCHEDULE"].ToString().Trim();
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
        public List<MedPerformDefaultSchedule> SelectMedPerformDefaultScheduleListODBC()
        {
            List<MedPerformDefaultSchedule> modelList = new List<MedPerformDefaultSchedule>();
            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Select_ALL_ODBC, null))
            {
                while (oleReader.Read())
                {
                    MedPerformDefaultSchedule model = new MedPerformDefaultSchedule();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.FreqDesc = oleReader["FREQ_DESC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.Administration = oleReader["ADMINISTRATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.DefaultSchedule = oleReader["DEFAULT_SCHEDULE"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
        #region  [获取一条记录ODBC--FREQ_DESC]
        /// <summary>
        ///Select    model  MedPerformDefaultSchedule 
        ///select Table MED_PERFORM_DEFAULT_SCHEDULE by (string FREQ_DESC)
        /// </summary>
        public MedPerformDefaultSchedule SelectMedPerformDefaultScheduleODBC(string FREQ_DESC)
        {
            MedPerformDefaultSchedule model;
            OdbcParameter[] parameterValues = GetParameterODBC("SelectMedPerformDefaultScheduleFreq");
            parameterValues[0].Value = FREQ_DESC;

            using (OdbcDataReader oleReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Select_Freq_ODBC, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPerformDefaultSchedule();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.FreqDesc = oleReader["FREQ_DESC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.Administration = oleReader["ADMINISTRATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.DefaultSchedule = oleReader["DEFAULT_SCHEDULE"].ToString().Trim();
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
        ///获取参数MedPerformDefaultSchedule
        /// </summary>
        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedPerformDefaultSchedule")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter(":SerialNo",OleDbType.Decimal),
							new OleDbParameter(":FreqDesc",OleDbType.VarChar),
							new OleDbParameter(":Administration",OleDbType.VarChar),
							new OleDbParameter(":DefaultSchedule",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "UpdateMedPerformDefaultSchedule")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter(":SerialNo",OleDbType.Decimal),
							new OleDbParameter(":FreqDesc",OleDbType.VarChar),
							new OleDbParameter(":Administration",OleDbType.VarChar),
							new OleDbParameter(":DefaultSchedule",OleDbType.VarChar),
							new OleDbParameter(":FreqDesc",OleDbType.Decimal),
							new OleDbParameter(":Administration",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedPerformDefaultSchedule")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter(":FreqDesc",OleDbType.VarChar),
							new OleDbParameter(":Administration",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPerformDefaultSchedule")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter(":FreqDesc",OleDbType.VarChar),
							new OleDbParameter(":Administration",OleDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedPerformDefaultScheduleFreq")
                {
                    parms = new OleDbParameter[]{
							new OleDbParameter(":FreqDesc",OleDbType.VarChar),
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录OLE]
        /// <summary>
        ///Add    model  MedPerformDefaultSchedule 
        ///Insert Table MED_PERFORM_DEFAULT_SCHEDULE
        /// </summary>
        public int InsertMedPerformDefaultScheduleOLE(MedPerformDefaultSchedule model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedPerformDefaultSchedule");
                if (model.SerialNo.ToString() != null)
                    oneInert[0].Value = model.SerialNo;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.FreqDesc != null)
                    oneInert[1].Value = model.FreqDesc;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.Administration != null)
                    oneInert[2].Value = model.Administration;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.DefaultSchedule != null)
                    oneInert[3].Value = model.DefaultSchedule;
                else
                    oneInert[3].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Insert_OLE, oneInert);
            }
        }
        #endregion
        #region [更新一条记录OLE]
        /// <summary>
        ///Update    model  MedPerformDefaultSchedule 
        ///Update Table     MED_PERFORM_DEFAULT_SCHEDULE
        /// </summary>
        public int UpdateMedPerformDefaultScheduleOLE(MedPerformDefaultSchedule model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedPerformDefaultSchedule");
                if (model.SerialNo.ToString() != null)
                    oneUpdate[0].Value = model.SerialNo;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.FreqDesc != null)
                    oneUpdate[1].Value = model.FreqDesc;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.Administration != null)
                    oneUpdate[2].Value = model.Administration;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.DefaultSchedule != null)
                    oneUpdate[3].Value = model.DefaultSchedule;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.FreqDesc != null)
                    oneUpdate[4].Value = model.FreqDesc;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.Administration != null)
                    oneUpdate[5].Value = model.Administration;
                else
                    oneUpdate[5].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Update_OLE, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录OLE]
        /// <summary>
        ///Delete    model  MedPerformDefaultSchedule 
        ///Delete Table MED_PERFORM_DEFAULT_SCHEDULE by (string FREQ_DESC,string ADMINISTRATION)
        /// </summary>
        public int DeleteMedPerformDefaultScheduleOLE(string FREQ_DESC, string ADMINISTRATION)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneDelete = GetParameterOLE("DeleteMedPerformDefaultSchedule");
                if (FREQ_DESC != null)
                    oneDelete[0].Value = FREQ_DESC;
                else
                    oneDelete[0].Value = DBNull.Value;
                if (ADMINISTRATION != null)
                    oneDelete[1].Value = ADMINISTRATION;
                else
                    oneDelete[1].Value = DBNull.Value;

                return OleDbHelper.ExecuteNonQuery(OleDbHelper.ConnectionString, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Delete_OLE, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录OLE]
        /// <summary>
        ///Select    model  MedPerformDefaultSchedule 
        ///select Table MED_PERFORM_DEFAULT_SCHEDULE by (string FREQ_DESC,string ADMINISTRATION)
        /// </summary>
        public MedPerformDefaultSchedule SelectMedPerformDefaultScheduleOLE(string FREQ_DESC, string ADMINISTRATION)
        {
            MedPerformDefaultSchedule model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedPerformDefaultSchedule");
            parameterValues[0].Value = FREQ_DESC;
            parameterValues[1].Value = ADMINISTRATION;
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Select_OLE, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPerformDefaultSchedule();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.FreqDesc = oleReader["FREQ_DESC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.Administration = oleReader["ADMINISTRATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.DefaultSchedule = oleReader["DEFAULT_SCHEDULE"].ToString().Trim();
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
        public List<MedPerformDefaultSchedule> SelectMedPerformDefaultScheduleListOLE()
        {
            List<MedPerformDefaultSchedule> modelList = new List<MedPerformDefaultSchedule>();
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Select_ALL_OLE, null))
            {
                while (oleReader.Read())
                {
                    MedPerformDefaultSchedule model = new MedPerformDefaultSchedule();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.FreqDesc = oleReader["FREQ_DESC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.Administration = oleReader["ADMINISTRATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.DefaultSchedule = oleReader["DEFAULT_SCHEDULE"].ToString().Trim();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
        #region  [获取一条记录--FREQ_DESC]
        /// <summary>
        ///Select    model  MedPerformDefaultSchedule 
        ///select Table MED_PERFORM_DEFAULT_SCHEDULE by (string FREQ_DESC)
        /// </summary>
        public MedPerformDefaultSchedule SelectMedPerformDefaultScheduleOLE(string FREQ_DESC)
        {
            MedPerformDefaultSchedule model;
            OleDbParameter[] parameterValues = GetParameterOLE("SelectMedPerformDefaultScheduleFreq");
            parameterValues[0].Value = FREQ_DESC;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Select_Freq_OLE, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPerformDefaultSchedule();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.FreqDesc = oleReader["FREQ_DESC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.Administration = oleReader["ADMINISTRATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.DefaultSchedule = oleReader["DEFAULT_SCHEDULE"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
    }
}
